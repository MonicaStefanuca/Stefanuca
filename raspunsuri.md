Tema 2 - exercitiul 3
 
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


Tema 3

1. Ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)?
                                Orar.

2. Anti-aliasing este o tehnică utilizată pentru a reduce sau elimina efectul de aliasing, care apare atunci când se produc artefacte nedorite în reprezentările digitale, cum ar fi pixelarea și asprimea marginilor. Această tehnică îmbunătățește calitatea imaginilor digitale prin atenuarea acestor artefacte. Principalul scop al anti-aliasing-ului este de a face marginile obiectelor sau texturilor să pară netede și mai naturale.

3. Comanda GL.LineWidth(float) este folosită pentru a seta grosimea liniilor desenate în OpenGL. Această comandă stabilește grosimea liniilor pentru elementele geometrice desenate ulterior, cum ar fi linii și contururi de poligoane.

Comanda GL.PointSize(float) setează dimensiunea punctelor desenate în OpenGL. Această comandă determină dimensiunea punctelor reprezentate în spațiul de vizualizare.

Ambele comenzi afectează elementele desenate în interiorul zonei GL.Begin(). Atunci când sunt utilizate într-o astfel de zonă, dimensiunea liniilor și a punctelor specificate prin LineWidth și PointSize va fi aplicată pentru obiectele desenate între Begin și End.

4. 
   Atunci când se utilizează GL.LineLoop în OpenGL, aceasta creează un contur închis, desenând linii între puncte consecutive și conectând ultimul punct la primul punct, formând un contur complet. Acest lucru este valabil indiferent de numărul de segmente de dreaptă desenate în cadrul conturului. Astfel, se creează o buclă închisă, conectând automat ultimul punct desenat înapoi la primul punct, completând astfel figura geometrică și formând un contur închis.
  Atunci când se utilizează GL.LineStrip în OpenGL pentru desenarea segmentelor de dreaptă, aceasta creează un set de linii care se conectează printr-o secvență de puncte consecutive. Fiecare segment de linie începe de la ultimul punct desenat și continuă la punctul următor, formând o linie continuă care unește punctele în ordine. Acest lucru rezultă într-un lanț de segmente de dreaptă consecutive.
   Directivele OpenGL precum TriangleFan sunt folosite pentru a desena poligoane compuse din triunghiuri. Atunci când este utilizată GL.TriangleFan, OpenGL desenează un triunghi începând de la primul vârf specificat și continuă să adauge triunghiuri adiacente la fiecare vârf nou. Fiecare nou vârf generează un triunghi împreună cu vârful precedent și primul vârf specificat. Astfel, este creat un poligon care pare a fi un evantai, deoarece triunghiurile sunt conectate în ordine circulară de-a lungul perimetrului vârfurilor specificate. Acest tip de desen creează o formă compusă, desenată ca o serie de triunghiuri conectate care se extind în jurul primului vârf.
   Atunci când este folosită directiva GL.TriangleStrip în OpenGL pentru desenarea unor segmente multiple de dreaptă, aceasta creează o secvență de triunghiuri conectate. Se desenează triunghiuri folosind vârfurile specificate într-o ordine consecutivă. Primul triunghi este definit de primele trei vârfuri specificate. Apoi, fiecare vârf nou adăugat generează un nou triunghi împreună cu ultimele două vârfuri adăugate anterior, extinzându-se pe baza acestora. Astfel, sunt conectate triunghiuri succesive care creează un model continuu de triunghiuri conectate pe baza vârfurilor oferite.

6. Folosirea de culori diferite în obiectele 3D contribuie la evidențierea conturului și a detaliilor acestora. Prin această metodă, este ușor de recunoscut marginile și structura obiectelor, ajutând la o mai bună percepție a formei și adâncimii acestora în mediul tridimensional.

7. Un gradient de culoare reprezintă tranziția treptată între două sau mai multe culori. În OpenGL, gradientele pot fi obținute prin utilizarea interpolarilor de culoare în cadrul obiectelor desenate, determinând trecerea treptată între culorile specificate pentru diferitele vârfuri ale formelor geometrice.

10. Atunci când se desenează o linie sau un triunghi în modul strip și se folosesc culori diferite pentru fiecare vertex, se produce un efect de tranziție sau de gradient de culoare între aceste vârfuri. Acest lucru creează o schimbare treptată a culorilor de la un vârf la altul, adăugând profunzime și detaliu vizual obiectelor desenate. Astfel, se generează o imagine mai bogată și mai diversificată din punct de vedere vizual.