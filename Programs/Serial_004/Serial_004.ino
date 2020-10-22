/*
 * Miriam control
 *  
 * Miriam is an isothermal amplification unit capable of real time detection that supports a 96 well PCR plate
 * This firmware allows the control over serial port string messages
 *
 * The basic configuration of the board is:
 *
 * - Temperature Sensors pins: 23,24,25,26 and sensor 5 not using but connect to 19 
 * - Heater pins: 9,10,1,13 and heat 5 not using but connect to 14 
 * - LEDS: 22,2,12,11
 *   
 * (c) 2016 Juho Terrijarvi juho@miroculus.com, Miroculus Inc.
 * (c) 2014 Juanjo Tara j.tara@arduino.cc, Arduino Verkstad AB 
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *    
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */


#include <PID_v1.h>
#include <math.h>


//Selector ping
#define SEL_1 46                 // Selector ping 1
#define SEL_2 47                 // Selector ping 2
#define SEL_3 48                 // Selector ping 3
#define SEL_4 49                 // Selector ping 4

//Temperature Sensors pin
#define TH_BOX A8                 // Temperature Sensor 2 
#define TH_MIDDLEBED_2 A9                 // Temperature Sensor 3
#define TH_UPPERBED A10                   // Temperature Sensor 1 
#define TH_EXTRA A11                   // Temperature Sensor ex 

#define OPTIMAL_MIDDLE_TEMP 63
#define OPTIMAL_UPPER_TEMP 80
#define OPTIMAL_EXTRA_TEMP 63
#define IDDLE_MIDDLE_TEMP 30
#define IDDLE_UPPER_TEMP 20
#define Threshold_temp 0.5
//Heater pins
#define HEAT_MIDDLE 2             // Heat 1
#define HEAT_UPPER 3            // Heat 2
#define HEAT_EXTRA 23            // Heat 3

//LED Sensors pin
#define PANEL_LED 22			        


// manufacturer data for episco NCP18XH103F03RB 10k thermistor
// simply delete this if you don't need it
// or use this idea to define your own thermistors
#define NCP18XH103F03RB 3380.0f,298.15f,10000.0f  // B,T0,R0


// STATES FOR STATE MACHINE
#define INIT      'I'
#define CANCEL       'C'
#define HEAT_BOARDS  'H'
#define INFO       'i'
#define SET_TEMP_UPPER 'U'
#define SET_TEMP_MIDDLE 'M'
#define SET_TEMP_EXTRA 'E'
#define READ_ASSAY 'R'


int MUL[6] = {
  A0,A1,A2,A3,A4,A5};				// Multiplexer  1



byte controlLPins[] = {
  B00000000, 
  B00000001,
  B00000010,
  B00000011,
  B00000100,
  B00000101,  
  B00000110,
  B00000111,
  B00001000,
  B00001001,
  B00001010,
  B00001011,
  B00001100,
  B00001101,
  B00001110,
  B00001111}; 


// holds incoming values from Multiplexer
int sensorValues[8][12] = {
};


//Define the aggressive and conservative Tuning Parameters
double aggKp=4, aggKi=0.4, aggKd=4; // d2
double consKp=1, consKi=0.05, consKd=0.25; //1, 0.25
double Setpoint;
//Define Variables we'll be connecting to PID's
double Input_MIDDLE, Output_MIDDLE, Setpoint_MIDDLE,Input_UPPER, Input_BOX, Setpoint_UPPER, Output_UPPER,Input_MIDDLE_2,Input_EXTRA, Output_EXTRA, Setpoint_EXTRA;

//PID Controller for Heater
PID PID_MIDDLE(&Input_MIDDLE_2, &Output_MIDDLE, &Setpoint_MIDDLE, consKp, consKi, consKd, DIRECT);
PID PID_UPPER(&Input_UPPER, &Output_UPPER, &Setpoint_UPPER, consKp, consKi, consKd, DIRECT);
PID PID_EXTRA(&Input_EXTRA, &Output_EXTRA, &Setpoint_EXTRA, consKp, consKi, consKd, DIRECT);

// enumerating 3 major temperature scales
enum {
  T_KELVIN=0,
  T_CELSIUS,
  T_FAHRENHEIT
};

byte states[] = {
  INIT, CANCEL, HEAT_BOARDS, INFO, SET_TEMP_UPPER, SET_TEMP_MIDDLE,SET_TEMP_EXTRA, READ_ASSAY};


// serial data
String inputString = "                         ";  // a string to hold incoming data
String parameters = "                         ";
String dataString = "                         ";
boolean stringComplete = false;  // whether the string is complete               
boolean LED=false;
boolean HEAT_ON = false;

int state = INIT;
char previous_state = INIT;
int defaultState = INIT;

void setup ()
{
  DDRL = DDRL | B00001111;  // this sets pins D3 to D7 as outputs

  // Temperature Sensors pin
  pinMode(TH_BOX, INPUT);
  pinMode(TH_MIDDLEBED_2, INPUT);
  pinMode(TH_UPPERBED, INPUT);
  pinMode(TH_EXTRA, INPUT);

  // Heater pins
  pinMode(HEAT_MIDDLE, OUTPUT);
  pinMode(HEAT_UPPER, OUTPUT);
  pinMode(HEAT_EXTRA, OUTPUT);
  //Panel LEDS
  pinMode(PANEL_LED,OUTPUT);


  // Read temperature sensors
  ReaderSensorTemp();

  // Set degrees for PID algorithm
  Setpoint_MIDDLE = OPTIMAL_MIDDLE_TEMP;
  Setpoint_UPPER = OPTIMAL_UPPER_TEMP;
  Setpoint_EXTRA = OPTIMAL_EXTRA_TEMP;
  // input string needs space
  inputString.reserve(30);  
  inputString = "";
  parameters = "";

  Serial.begin(9600);  // Begin the serial monitor at 9600bps
  Serial.println(F("Hope your day is nice and shiny!"));

}


void loop () {
    
  // print the string when a newline arrives:
  if (stringComplete) {
    // remove carriage returns and new lines
    inputString.replace("\n", "");
    inputString.replace("\r", "");
    Serial.println(inputString);
       
    // it there is anything to do with it, do it!
    if(isState(inputString[0])) {
      previous_state = state;
      state = inputString[0];
      parameters = inputString.substring(2);
    }
    // clear the string:

    inputString = "";
    stringComplete = false;
  }

  //Calculate PID for heaters
  if (HEAT_ON) Calculate_Heat();
  //Calculate_Heat();

  // state machine
  switch (state) {

  case INIT:
    previous_state = state;
    state = 'I';
    break;

  case CANCEL:

    HEAT_ON = false;

    Output_MIDDLE = 0;
    Output_UPPER = 0;
    Output_EXTRA = 0;
    computePIDs();
    
    Serial.println(F("Cancel$"));
    //delay(4000);

    //turn the PID's off
    PID_MIDDLE.SetMode(MANUAL);
    PID_UPPER.SetMode(MANUAL);
    
    //Setpoint_MIDDLE = IDDLE_MIDDLE_TEMP;    
    //Setpoint_UPPER = IDDLE_UPPER_TEMP;
    
    state = defaultState; 
    
    break;  

  case HEAT_BOARDS:  
    
    HEAT_ON = true;
      
    Serial.println(F("HEATING BOARDS$"));
  
    //turn the PID's on
    PID_MIDDLE.SetMode(AUTOMATIC);
    PID_UPPER.SetMode(AUTOMATIC);
    PID_EXTRA.SetMode(AUTOMATIC);
    state = defaultState;
    break;

  case INFO:

    Serial.println(String(Output_MIDDLE) + "," + String(Output_UPPER) + "," + String(Output_EXTRA) + "," + 
      String(analogRead(TH_UPPERBED)) + "," + String((analogRead(TH_MIDDLEBED_2))) + "," + String((analogRead(TH_EXTRA))) + "," + 
      String(Temperature(TH_UPPERBED,T_CELSIUS,NCP18XH103F03RB,10000.0f)) + "," + String(Temperature(TH_MIDDLEBED_2,T_CELSIUS,NCP18XH103F03RB,10000.0f) * 0.6548 + 17.931)+ "," + String(Temperature(TH_EXTRA,T_CELSIUS,NCP18XH103F03RB,10000.0f) * 0.6548 + 17.931) + "$");
    
    state = defaultState;

    break;

  case SET_TEMP_UPPER:

    Setpoint_UPPER = parameters.toInt();
    Serial.print(F("NEW UPPER TEMP:"));    
    Serial.print(Setpoint_UPPER);
    Serial.println("$");
        
    state = defaultState;
    break;

  case SET_TEMP_MIDDLE:

    Setpoint_MIDDLE = (parameters.toInt() - 17.931)/0.6548;  
    Serial.print(F("NEW MIDDLE TEMP:"));       
    Serial.print(Setpoint_MIDDLE * 0.6548 + 17.931);
    Serial.println("$");
        
    state = defaultState;

    break;

  case SET_TEMP_EXTRA:

    Setpoint_EXTRA = (parameters.toInt() - 17.931)/0.6548;  
    Serial.print(F("NEW EXTRA TEMP:"));       
    Serial.print(Setpoint_EXTRA * 0.6548 + 17.931);
    Serial.println("$");
        
    state = defaultState;

    break;
    
  case READ_ASSAY:
    
    Serial.print(F("READ ASSAY"));     
    Read_Assay();
    state = defaultState;
    break;

  } 
}

void setPin(int outputPin) {
  PORTL = controlLPins[outputPin];
}

void Read_Assay() {

  //set the PIDs to zero to boost LED power
  Output_MIDDLE = 0;
  Output_UPPER = 0;
  Output_EXTRA = 0;
  computePIDs();

  digitalWrite(22,HIGH);
  delay(500);
  
  
  //take 5 samples for measurement
  for (int j=0 ; j<5 ;j++)
  {
    for (int i = 0; i < 16; i++)
    {
      setPin(i); // choose an input pin
      ReadAssay(i);

    }    
    delay(1000);
  }


  digitalWrite(22,LOW);


  //Calculate the average of the measurements for each sample
  for (int k=0; k< 8;k++)
  {
    for (int l = 0;l < 12;l++)
    {
      sensorValues[k][l] /= 5;
    }
  }

  displayData();
  
  //Empty the array
  for (int k=0; k< 8;k++)
  {
    for (int l = 0;l < 12;l++)
    {
      sensorValues[k][l] = 0;
    }
  }
  
  //Empty possibly stored charge
  //take 5 samples for measurement
  for (int j=0 ; j<15 ;j++)
  {
    for (int i = 0; i < 16; i++)
    {
      setPin(i); // choose an input pin
      
      for (int k=0; k<5; k++) {
        
        ReadAssayEmpty(i);

      }
    }    
    delay(10);
  }  
}
void ReadAssayEmpty(int i) {

  for (int j = 0; j < 6; j++)
  {

    switch (i) {

    case 0:
      analogRead(MUL[j]);
      break;
    case 1:
      analogRead(MUL[j]);
      break;
    case 2:
      analogRead(MUL[j]);
      break;
    case 3:
      analogRead(MUL[j]);
      break;
    case 4:
      analogRead(MUL[j]);
      break;
    case 5:
      analogRead(MUL[j]);
      break;
    case 6:
      analogRead(MUL[j]);
      break;
    case 7:
      analogRead(MUL[j]);
      break;
    case 8:
      analogRead(MUL[j]);
      break;
    case 9:
      analogRead(MUL[j]);
      break;
    case 10:
      analogRead(MUL[j]);
      break;
    case 11:
      analogRead(MUL[j]);
      break;
    case 12:
      analogRead(MUL[j]);
      break;
    case 13:
      analogRead(MUL[j]);
      break;
    case 14:
      analogRead(MUL[j]);
      break;
    case 15:
      analogRead(MUL[j]);
      break;
    }
  }
}

void ReadAssay(int i) {

  //select the multiplexer
  for (int j = 0; j < 6; j++)
  {

    switch (i) {

    case 0:
      sensorValues[3][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 1:
      sensorValues[2][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 2:
      sensorValues[1][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 3:
      sensorValues[0][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 4:
      sensorValues[3][j*2]+= analogRead(MUL[j]);
      break;
    case 5:
      sensorValues[2][j*2]+= analogRead(MUL[j]);
      break;
    case 6:
      sensorValues[1][j*2]+= analogRead(MUL[j]);
      break;
    case 7:
      sensorValues[0][j*2]+= analogRead(MUL[j]);
      break;
    case 8:
      sensorValues[4][j*2]+= analogRead(MUL[j]);
      break;
    case 9:
      sensorValues[5][j*2]+= analogRead(MUL[j]);
      break;
    case 10:
      sensorValues[6][j*2]+= analogRead(MUL[j]);
      break;
    case 11:
      sensorValues[7][j*2]+= analogRead(MUL[j]);
      break;
    case 12:
      sensorValues[4][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 13:
      sensorValues[5][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 14:
      sensorValues[6][(j*2)+1]+= analogRead(MUL[j]);
      break;
    case 15:
      sensorValues[7][(j*2)+1]+= analogRead(MUL[j]);
      break;
    }

  }
}

// dumps captured data from array to serial monitor
void displayData() {
  Serial.println(F(""));

  int j=0;
  String str = "";

  for (j=0; j < 8; j++)
  {


    for (int i = 0; i < 12; i++)
    {
      str = str + sensorValues[j][i] + ",";
    }
  }
  Serial.print(str + "$");
  Serial.println(F(""));
  
}

void Calculate_Heat() {

  ReaderSensorTemp();
  SetTunings_PID();
  computePIDs();    


}    

void computePIDs() {

  PID_MIDDLE.Compute();
  PID_UPPER.Compute();
  PID_EXTRA.Compute();

  analogWrite(HEAT_MIDDLE,Output_MIDDLE);
  analogWrite(HEAT_UPPER,Output_UPPER);
  analogWrite(HEAT_EXTRA,Output_EXTRA);
  /*
  
   analogWrite(HEAT_MIDDLE,0);
   analogWrite(HEAT_UPPER,0);
   */
}


void ReaderSensorTemp() {

  Input_UPPER = Temperature(TH_UPPERBED,T_CELSIUS,NCP18XH103F03RB,10000.0f);
  Input_BOX = Temperature(TH_BOX,T_CELSIUS,NCP18XH103F03RB,10000.0f);
  Input_MIDDLE_2 = Temperature(TH_MIDDLEBED_2,T_CELSIUS,NCP18XH103F03RB,10000.0f);
  Input_EXTRA = Temperature(TH_EXTRA,T_CELSIUS,NCP18XH103F03RB,10000.0f);

}

void SetTunings_PID() {

  double gap1,gap2,gap3;

  gap1 = abs(Setpoint_MIDDLE - Temperature(TH_MIDDLEBED_2,T_CELSIUS,NCP18XH103F03RB,10000.0f)); //distance away from setpoint
  gap2 = abs(Setpoint_UPPER - Temperature(TH_UPPERBED,T_CELSIUS,NCP18XH103F03RB,10000.0f)); //distance away from setpoint
  gap3 = abs(Setpoint_EXTRA - Temperature(TH_EXTRA,T_CELSIUS,NCP18XH103F03RB,10000.0f)); //distance away from setpoint

  if(Temperature(TH_MIDDLEBED_2,T_CELSIUS,NCP18XH103F03RB,10000.0f)>Setpoint_MIDDLE-0.5)
  {  //we're close to setpoint, use conservative tuning parameters
    PID_MIDDLE.SetTunings(consKp, consKi, consKd);
    Output_MIDDLE = 0;
  }
  else
  {
    //we're far from setpoint, use aggressive tuning parameters
    PID_MIDDLE.SetTunings(aggKp, aggKi, aggKd);
  }

  if(Setpoint_UPPER-0.5<Temperature(TH_UPPERBED,T_CELSIUS,NCP18XH103F03RB,10000.0f))
  {  //we're close to setpoint, use conservative tuning parameters
    PID_UPPER.SetTunings(consKp, consKi, consKd);
    Output_UPPER = 0;
  }
  else
  {
    //we're far from setpoint, use aggressive tuning parameters
    PID_UPPER.SetTunings(aggKp, aggKi, aggKd);
  }
  
  if(Temperature(TH_EXTRA,T_CELSIUS,NCP18XH103F03RB,10000.0f)>Setpoint_EXTRA-0.5)
    {  //we're close to setpoint, use conservative tuning parameters
      PID_EXTRA.SetTunings(consKp, consKi, consKd);
      Output_EXTRA = 0;
    }
    else
    {
      //we're far from setpoint, use aggressive tuning parameters
      PID_EXTRA.SetTunings(aggKp, aggKi, aggKd);
    }  
}



// check if it is a valid state for the state machine
boolean isState(int s) {
  boolean r = false;
  for(int i = 0; i < sizeof(states); i++) {
    r = (states[i] == s);
    if(r) return r;
  }
  return r;
}

float Temperature(int AnalogInputNumber,int OutputUnit,float B,float T0,float R0,float R_Balance) {
  float R,T;

  //  R=1024.0f*R_Balance/float(analogRead(AnalogInputNumber)))-R_Balance;
  R=R_Balance/(1024.0f/float(analogRead(AnalogInputNumber))-1);

  T=1.0f/(1.0f/T0+(1.0f/B)*log(R/R0));

  switch(OutputUnit) {
  case T_CELSIUS :
    T-=273.15f;
    break;
  case T_FAHRENHEIT :
    T=9.0f*(T-273.15f)/5.0f+32.0f;
    break;
  default:
    break;
  };
  return T;
}

boolean searchString(String str, String search) {
  for (int i=0; i<str.length(); i++) {
    if (str.substring(i,i+search.length()) == search) return true;
  }
  return false;
}


// serial event
void serialEvent() {
  if (Serial.available()) {

    while (Serial.available()) {
      // get the new byte:
      char inChar = (char)Serial.read();
      // add it to the inputString:
      inputString += inChar;
      // if the incoming character is a newline, set a flag
      // so the main loop can do something about it:
      if (inChar == '\n') {
        stringComplete = true;
      }
    }
  }
  
}
