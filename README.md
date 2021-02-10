# Streufeldkompensation

Diese Software ist Spezifisch für die Benutzung von dem Streufeldkompensatons Projekt programmiert worden. 
Mit der kann man über die Serielle Schnittstelle mit dem Mikro Controller kommunizieren. In der Normalen Anwendung können die **Acht Kanäle** eingestellt werden und 
die jeweilige Spannung dazu. 

- Zuerst sollte man sich mit dem Controller verbinden. Dazu wählt man den Richtigen Port aus welcher gegebenenfalls auch im Gerätemanager nachgeschaut werden kann und öffnet den Port. 


- Danach ist man bereit die Kanäle einzustellen. In dem Spannungsbereich **+/- 1V kann man zwischen -1V und +1V einstellen und bei +/-10V zwischen -10V und +10V**. 

![image](https://user-images.githubusercontent.com/45595553/107516830-410fc980-6bad-11eb-8da0-01fdff80f485.png)


- Der Offset stellt bei allen Kanälen eine Offsetspannung dazustellen welche Positiv oder auch negativ sein kann zwischen -100mV und +100mV. 
Bei betätigen des Spezialfunktion Knopfes klappt sich das Dialogfeld mehr aus:


- In dem kann man die Vier Spezialpins separat einstellen. Es ist möglich als Input oder als Output. In diesem Fall sin alle Pins als Eingänge definiert und wenn ein Positives Signal an den jeweiligen Pins anliegt wird in der Software die Glühbirne leuchten.

![image](https://user-images.githubusercontent.com/45595553/107516934-64d30f80-6bad-11eb-81c1-93a7304df757.png)

## --------------------------------------------------------------------------------------------------
# Visualstudio
Diese Anleitung beschreibt den Umgang und die Installation von Visualstudio mit dem C# .net Framework 
Zuerst sollte man die Visualstudio Installer Datei aus dem Internet herunterladen. Unter https://visualstudio.microsoft.com/de/downloads/ findet man die Auswahl Community und eine Download link. Nach dem ausführen dieser Datei sollte ein solches Dialogfeld erscheinen und man sollte die Community Version auswählen können.

![image](https://user-images.githubusercontent.com/45595553/107522790-5805ea00-6bb4-11eb-9c2a-2315e6ca997c.png)


Danach ist es Wichtig das Richtige Modul auszuwählen.
Für diese anwendung ist die .NET-Desktopentwicklung essentiell wichtig.
Nach der Installation kann man das Projekt von Github herunterladen und Importieren.
![image](https://user-images.githubusercontent.com/45595553/107522859-69e78d00-6bb4-11eb-8b2d-66546d49e6da.png)

Ein neues Projekt kann man unter Datei --> Öffnen --> Projekt.. hinzufügen.


![image](https://user-images.githubusercontent.com/45595553/107522911-7835a900-6bb4-11eb-9661-d49d96240180.png)


