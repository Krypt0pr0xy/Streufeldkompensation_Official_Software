# Usage of the Software
## This section explains how to use the software.
`If you only want to use the software without developing the programming further, you can use the already created application.`

# Download
The software can be downloaded from the following [link][1].

Please note when the following window opens
***
![Image][2]
## Click on **More info** and then on **Run anyway**.
***
# Usage
***
![Image][3]
***
## Description:
Number | description 
--- | ---
 1\. | Serial port Selection, if you are unsure which port to use, you can open the Device Manager under Windows. 
 2\. | Once you have selected the port, you can open the interface by pressing the Open Port button. 
 3\. | The Help button sends the Help command via UART when connected to the device, the DAC sends back a message.
 4\. | The offset sets globally the voltage higher or lower.
 5\. | This setting sets the channel. 1-8
 6\. | This setting sets the voltage at the respective channel
 7\. | These buttons let you set the voltage range and the output resistance.
 8\. | This function is not yet implemented in this version.
 9\. | The textbox is a log for the current status.
 10\. | The Send command is used to transmit the data to de DAC.

## How to Connect the Hardware:
### **On the back are the connectors, first connect the power supply before the USB connection.** Each power supply needs less than 100mA.
![Image][5]

## How to Connect to the Software:
To get started you need to launch the software, it does not require admin rights. Then connect the USB cable to a free USB port on your computer. Make sure that the DAC box is powered on first. See section: [(How to Connect to Hardware)][4].
In the software you must select the serial port (number 1 from the description) and then click on Open Port.

## LED Status:
On the front panel are three LEDs for status.
LED | Status
--- | ---
EN | When this LED lights up, the device is ready for use.
DATA | Data lights up when serial data is being sent.
FAIL| This LED lights up when an error has occurred and the device stops. This can happen, for example, if a USB cable is too long or the wrong power supply is applied.

![Image][6]

## Usage without the Official Softwar
The device can also be used without the official software. The communication is done via a serial communication which is called [UART][7].  

## UART Commands
***
***
## Trouble shooting


[1]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/Streufeldkompensation_Official_Software.exe

[2]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/WindowsprotectedyourPC.PNG

[3]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/Official_Software.PNG

[4]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/Usage_of_the_Software.md#how-to-connect-the-hardware

[5]:https://github.com/Krypt0pr0xy/Streufeldkompensation/blob/master/DAC-Box-backend.jpg

[6]:https://github.com/Krypt0pr0xy/Streufeldkompensation/blob/master/DAC-Box-frontend.jpg

[7]:https://de.wikipedia.org/wiki/Universal_Asynchronous_Receiver_Transmitter
