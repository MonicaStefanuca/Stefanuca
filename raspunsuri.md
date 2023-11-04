Laborator 3 - exercitiul 3
 
1. Un "viewport" (fereastră de vizualizare) este o zonă rectangulară din cadrul unei suprafețe sau ferestre de afișare în care se poate vizualiza conținut grafic, cum ar fi imagini, grafice, sau conținut generat pe ecran.
2. Conceptul de "frames per second" (FPS) în cadrul bibliotecii OpenGL se referă la numărul de cadre de imagine pe care GPU-ul (unitatea de procesare grafică) le poate genera și afișa pe ecran într-o secundă. FPS este o măsură a performanței unui program sau joc 3D și indică cât de fluidă și fără întreruperi este afișarea graficelor.
3. Metoda "OnUpdateFrame" este de obicei rulată în fiecare cadru de imagine, ceea ce înseamnă că este apelată de fiecare dată când se desenează un nou cadru pe ecran.
4. Modul imediat de randare (Immediate Mode Rendering) este o tehnică de randare în grafica computerizată care implică desenarea de obiecte grafice sau geometrie într-o manieră directă și imediată în fiecare cadru de imagine. Acest mod de randare implică trimiterea datelor geometrice (precum vârfuri, culori și texturi) către unitatea de procesare grafică pentru fiecare cadru de imagine. 
5. Ultima versiune de OpenGL care acceptă modul imediat este OpenGL 3.0.
6. Metoda OnRenderFrame() este apelată automat în fiecare cadru de imagine, și anume după ce au fost procesate actualizările logice în metoda OnUpdateFrame().
7. Metoda OnResize() trebuie să fie executată cel puțin o dată într-o aplicație grafică pentru a stabili sau actualiza setările legate de rezoluția și dimensiunea ferestrei de afișare. Ea asigură inițializarea sau actualizarea corectă a setărilor legate de dimensiunea ferestrei, contextul grafic și matricele de proiecție, permițând astfel aplicației să se adapteze la diferite rezoluții sau redimensionări ale ferestrei.
8. Cei mai importanti parametri ai metodei "CreatePerspectiveFieldOfView" sunt:
- fieldOfView: Acest parametru reprezintă unghiul de câmp (Field of View) care determină cât de multe din scena 3D sunt vizibile. De obicei, acesta este specificat în radiani și definește cât de larg sau strâmt este unghiul vizual al camerei. 
-aspectRatio (raportul aspectului): Acest parametru reprezintă raportul dintre lățimea și înălțimea ferestrei de vizualizare sau a ecranului. 
- nearPlaneDistance (distanța planului apropiat): Acest parametru specifică distanța la care se află planul apropiat al frustum-ului de proiecție.- farPlaneDistance (distanța planului îndepărtat): Acest parametru specifică distanța la care se află planul îndepărtat al frustum-ului de proiecție.
Domeniul de valori de valori pentru:
- fieldOfView: 0 și π

