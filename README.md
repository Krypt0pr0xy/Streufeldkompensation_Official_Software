# Streufeldkompensation

Diese Software ist Spezifisch für die Benutzung von dem Streufeldkompensatons Projekt programmiert worden. 
Mit der kann man über die Serielle Schnittstelle mit dem Mikro Controller kommunizieren. In der Normalen Anwendung können die Acht Kanäle eingestellt werden und 
die jeweilige Spannung dazu. 

- Zuerst sollte man sich mit dem Controller verbinden. Dazu wählt man den Richtigen Port aus welcher gegebenenfalls auch im Gerätemanager nachgeschaut werden kann und öffnet den Port. 


- Danach ist man bereit die Kanäle einzustellen. In dem Spannungsbereich +/- 1V kann man zwischen -1V und +1V einstellen und bei +/-10V zwischen   -10V und +10V. 

![image](https://user-images.githubusercontent.com/45595553/107516830-410fc980-6bad-11eb-8da0-01fdff80f485.png)


- Der Offset stellt bei allen Kanälen eine Offsetspannung dazustellen welche Positiv oder auch negativ sein kann zwischen -100mV und +100mV. 
Bei betätigen des Spezialfunktion Knopfes klappt sich das Dialogfeld mehr aus:


- In dem kann man die Vier Spezialpins separat einstellen. Es ist möglich als Input oder als Output. In diesem Fall sin alle Pins als Eingänge definiert und wenn ein Positives Signal an den jeweiligen Pins anliegt wird in der Software die Glühbirne leuchten.

![image](https://user-images.githubusercontent.com/45595553/107516934-64d30f80-6bad-11eb-81c1-93a7304df757.png)
