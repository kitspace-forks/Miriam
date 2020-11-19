#include "Arduino.h"
#include "MyStatusLed.h"
    MyStatusLed::MyStatusLed(int pin, long on_time, long off_time)
    {
      ledPin = pin;
      pinMode(ledPin, OUTPUT);
          
      OnTime = on_time;
      OffTime = off_time;
        
      ledState = LOW; 
      previousMillis = 0;
      mode=LED_OFF;
    }
       
    void MyStatusLed::Update()
    {
      if ((mode==LED_OFF) or (mode==LED_ON)) return;
      
      // check to see if it's time to change the state of the LED
      unsigned long currentMillis = millis();         
      if((ledState == HIGH) && (currentMillis - previousMillis >= OnTime))
      {
        ledState = LOW;  // Turn it off
        previousMillis = currentMillis;  // Remember the time
        digitalWrite(ledPin, ledState);  // Update the actual LED
      }
      else if ((ledState == LOW) && (currentMillis - previousMillis >= OffTime))
      {
        ledState = HIGH;  // turn it on
        previousMillis = currentMillis;   // Remember the time
        digitalWrite(ledPin, ledState);   // Update the actual LED
      }
    }
    void MyStatusLed::SwitchMode(LED_MODE set_mode)
    {    
      if(set_mode==mode) return;
      mode=set_mode;
      switch (set_mode)
      {
        case LED_ON:
          ledState=HIGH;        
          break;
        case LED_OFF:
          ledState=LOW;
          break;
        case LED_BLINK:
          ledState=LOW;
          break;
      }
      digitalWrite(ledPin, ledState);
    }
