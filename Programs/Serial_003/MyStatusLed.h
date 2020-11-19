// modified from here: https://www.digikey.com/en/maker/projects/multi-tasking-the-arduino-part-1/b23d9e65c4d342389d20cbd542c46a28
enum LED_MODE {LED_OFF = 0, LED_ON = 1, LED_BLINK=2};

class MyStatusLed
{
  private:
    int ledPin;      // the number of the LED pin
    long OnTime;     // milliseconds of on-time
    long OffTime;    // milliseconds of off-time
  
    LED_MODE mode;    
      
    // These maintain the current state
    int ledState;                 // ledState used to set the LED
    unsigned long previousMillis;   // will store last time LED was updated     
  public:
    MyStatusLed(int pin, long on_time, long off_time);
    void Update();
    void SwitchMode(LED_MODE mode);
};
