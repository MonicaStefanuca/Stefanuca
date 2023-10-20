using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace Stefanuca
{
    class Program : GameWindow
    {
        //Laborator 3: exercitii 1 si 2
        private Vector2 position = Vector2.Zero; // Poziția inițială a obiectului
        //constructor
        public Program() : base(800, 600,GraphicsMode.Default,"Object Control App")
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;
        }
        private void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            float mouseX = (float)e.X / Width * 2 - 1;
            float mouseY = 1 - (float)e.Y / Height * 2;

            position = new Vector2(mouseX, mouseY);
        }
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            Console.WriteLine($"Key pressed: {e.Key}");
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.Q)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;

            // Control cu tastele W (sus) și S (jos)
            if (e.Key == Key.W)
                position.Y += 0.1f;
            if (e.Key == Key.S)
                position.Y -= 0.1f;

            // Control cu tastele A (stânga) și D (dreapta)
            if (e.Key == Key.A)
                position.X -= 0.1f;
            if (e.Key == Key.D)
                position.X += 0.1f;
        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.LightPink);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0, 4.0);

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Momentan aplicația nu face nimic!
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.DeepPink);
            GL.Vertex2(-0.5f + position.X, 0.5f + position.Y);
            GL.Color3(Color.Fuchsia);
            GL.Vertex2(0.0f + position.X, -0.5f + position.Y);
            GL.Color3(Color.Ivory);
            GL.Vertex2(0.5f + position.X, 0.5f + position.Y);

            GL.End();

            this.SwapBuffers();
        }
        [STAThread]
        static void Main(string[] args)
        {

            // Utilizarea cuvântului-cheie "using" va permite dealocarea memoriei o dată ce obiectul nu mai este
            // în uz (vezi metoda "Dispose()").
            // Metoda "Run()" specifică cerința noastră de a avea 30 de evenimente de tip UpdateFrame per secundă
            // și un număr nelimitat de evenimente de tip randare 3D per secundă (maximul suportat de subsistemul
            // grafic). Asta nu înseamnă că vor primi garantat respectivele valori!!!
            // Ideal ar fi ca după fiecare UpdateFrame să avem si un RenderFrame astfel încât toate obiectele generate
            // în scena 3D să fie actualizate fără pierderi (desincronizări între logica aplicației și imaginea randată
            // în final pe ecran).
            using (Program example = new Program())
            {

                // Verificați semnătura funcției în documentația inline oferită de IntelliSense!
                example.Run(30.0, 0.0);
            }
        }
    }
}
