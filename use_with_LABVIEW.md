# Usage of the Software with Labview
***
![Image][1]
***
## Description:
Number | Description 
--- | ---
 1\. | Input 
 1a\. | Channel as a `[Int Array]` , Voltage as a `[double array]`
 1b\. | Visa Open and configure: Visa Refnum -> Comport 
 2\. | Extract Input Data and check if data is valid else coerce -> Send Data
 3a\. | Wait 150ms and know how many Bytes Arrive
 3b\. | Read Port data and appand to String, read for 4 Commandlines
 4a\. | String Output
 4b\. | Port Close
 
## Example GUI:
***
![Image][2]
***


[1]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/mainIODO_screen_shot.PNG
[2]:https://github.com/Krypt0pr0xy/Streufeldkompensation_Official_Software/blob/master/mainIODO_screenshot_frontpanel.PNG
