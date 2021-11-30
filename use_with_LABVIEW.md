# Usage of the Software with Labview
***
![Image][1]
***
## Description:
Number | Description 
--- | ---
 1\. | Input 
 1a\. | Channel numbers (1-8) as `[Int Array]` , corresponding Voltages (+/-10V) as a `[double array]`. Should be of the same length.
 1b\. | Visa Open and configure: Visa Refnum -> COM-port 
 2 & 3\. | Loop over input array length
 2\. | Check if input data is valid, else coerce -> Send Data
 3a\. | Wait 150ms and know how many Bytes Arrive
 3b\. | Read Port data and appand to String, read for 4 Commandlines
 4a\. | String Output
 4b\. | Port Close
 
## Corresponding front panel:
***
![Image][2]
***

## The Example can be Downloaded under: https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/set_voltage_channel_StreufeldDACbox.vi



[1]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/mainIODO_screen_shot.PNG
[2]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/mainIODO_screenshot_frontpanel.PNG
