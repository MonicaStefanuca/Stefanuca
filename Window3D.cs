using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Stefanuca
{
    class Window3D : GameWindow
    {

        private KeyboardState previousKeyboard;
        private Triangle3D firstTriangle;


        // CONST
        private Color DEFAULT_BACK_COLOR = Color.LightSteelBlue;


        public Window3D() : base(1280, 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            firstTriangle = new Triangle3D("coordonate.txt");

            // Exemplu: setarea culorilor vârfurilor triunghiului
            firstTriangle.SetVertexColors(Color.Red, Color.Green, Color.Blue);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // setare fundal
            GL.ClearColor(DEFAULT_BACK_COLOR);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // setare proiectie/con vizualizare
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // setare ochi
            Matrix4 ochi = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref ochi);

            UpdateCamera();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);


            // LOGIC CODE
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }

            //Pentru cerinta 8
            /*if (currentKeyboard.IsKeyDown(Key.R))
            {
                firstTriangle.IncreaseRed();
            }
            else if (currentKeyboard.IsKeyDown(Key.T))
            {
                firstTriangle.DecreaseRed();
            }
            else if (currentKeyboard.IsKeyDown(Key.G))
            {
                firstTriangle.IncreaseGreen();
            }
            else if (currentKeyboard.IsKeyDown(Key.Y))
            {
                firstTriangle.DecreaseGreen();
            }
            else if (currentKeyboard.IsKeyDown(Key.B))
            {
                firstTriangle.IncreaseBlue();
            }
            else if (currentKeyboard.IsKeyDown(Key.N))
            {
                firstTriangle.DecreaseBlue();
            }*/

            previousKeyboard = currentKeyboard;
            // END logic code
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // RENDER CODE
            firstTriangle.Draw();

            // END render code
            SwapBuffers();

        }
        private void UpdateCamera()
        {
            Matrix4 eye = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n     MENU");
            Console.WriteLine(" H - meniu ajutor");
            Console.WriteLine(" ESC - parasire aplicatie");

            //Pentru cerinta 8
            /*Console.WriteLine(" R/T - Creste/Scade canalul Rosu");
            Console.WriteLine(" G/Y - Creste/Scade canalul Verde");
            Console.WriteLine(" B/N - Creste/Scade canalul Albastru");*/
        }

    }
}
