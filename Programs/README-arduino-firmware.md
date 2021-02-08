# Arduino firmware for Miriam

This requires the [Arduino software](https://www.arduino.cc/en/Guide/Windows).

* `Serial_003` - this contains the source code ("sketch") for the Arduino
  firmware in the file `Serial_003.ino`.
* `PID_v1.zip` - this is a library for Arduino.

## Installing

1. The `PID_v1` library should be installed in the Arduino IDE [according to these
instructions](https://www.arduino.cc/en/guide/libraries).

2. In the Arduino IDE, go to "Tools > Board" then select `Arduino Mega or Mega
   2560`.

3. In the Arduino IDE, select the port to the Arduino device. Go to "Tools >
   Port" then select the correct port, which depends on your computer.

4. Then the sketch can then be uploaded using the IDE. [Here is a tutorial about
   getting started with Arduino](https://www.arduino.cc/en/main/howto).
