using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanuca
{
    class Triangle3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private PolygonMode polMode;

        //Pentru cerinta 9
        private Color colorA;
        private Color colorB;
        private Color colorC;
        private Random random;
        private bool colorsDisplayed = false;

        //Doar pentru cerinta 8  
        //private Color color;
        /*private float minRed = 0.0f;
        private float maxRed = 1.0f;
        private float minGreen = 0.0f;
        private float maxGreen = 1.0f;
        private float minBlue = 0.0f;
        private float maxBlue = 1.0f;
        */

        public Triangle3D(string filePath)
        {

            //Pentru cerinta 8
            //color = GenerateRandomColor();
            //Inits();

            //Pentru cerinta 9
            random = new Random();
            ReadCoordinatesFromFile(filePath);
            InitializeColors();

            visibility = true;
            linewidth = 3.0f;
            pointsize = 3.0f;
            polMode = PolygonMode.Fill;

        }
        private void Inits()
        {
            visibility = true;
            linewidth = 3.0f;
            pointsize = 3.0f;
            polMode = PolygonMode.Fill;
        }
        private void InitializeColors()
        {
            colorA = GenerateRandomColor();
            colorB = GenerateRandomColor();
            colorC = GenerateRandomColor();
        }

        //Pentru cerinta 8
        public void Draw()
        {
            /*if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.Vertex3(pointC);
                GL.End();
            }*/

        //Pentru cerinta 9

        if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.Begin(PrimitiveType.Triangles);

                GL.Color3(colorA);
                GL.Vertex3(pointA);

                GL.Color3(colorB);
                GL.Vertex3(pointB);

                GL.Color3(colorC);
                GL.Vertex3(pointC);

                GL.End();

                if (!colorsDisplayed)
                {
                    DisplayVertexColors();
                    colorsDisplayed = true;
                }
            }
        }

        
        
        private void DisplayVertexColors()
        {
            Console.WriteLine($"Vertex 1 - R: {colorA.R}, G: {colorA.G}, B: {colorA.B}");
            Console.WriteLine($"Vertex 2 - R: {colorB.R}, G: {colorB.G}, B: {colorB.B}");
            Console.WriteLine($"Vertex 3 - R: {colorC.R}, G: {colorC.G}, B: {colorC.B}");
        }
        private Color GenerateRandomColor()
        {
            //Pentru cerinta 8
            //Random random = new Random();

            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        private void ReadCoordinatesFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length >= 3)
                {
                    string[] pointALine = lines[0].Split(' ');
                    string[] pointBLine = lines[1].Split(' ');
                    string[] pointCLine = lines[2].Split(' ');

                    pointA = new Vector3(float.Parse(pointALine[0]), float.Parse(pointALine[1]), float.Parse(pointALine[2]));
                    pointB = new Vector3(float.Parse(pointBLine[0]), float.Parse(pointBLine[1]), float.Parse(pointBLine[2]));
                    pointC = new Vector3(float.Parse(pointCLine[0]), float.Parse(pointCLine[1]), float.Parse(pointCLine[2]));
                }
                else
                {
                    throw new Exception("Fisierul nu contine suficiente linii pentru a defini un triunghi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la citirea coordonatelor din fisier: " + ex.Message);
            }
        }
        //Pentru cerinta 9
        public void SetVertexColors(Color colorA, Color colorB, Color colorC)
        {
            this.colorA = colorA;
            this.colorB = colorB;
            this.colorC = colorC;
        }

        //Pentru cerinta 8
        /*public void IncreaseRed()
        {
            color = Color.FromArgb(
                Math.Min(color.R + 25, 255),
                color.G,
                color.B
            );
        }

        public void DecreaseRed()
        {
            color = Color.FromArgb(
                Math.Max(color.R - 25, 0),
                color.G,
                color.B
            );
        }

        public void IncreaseGreen()
        {
            color = Color.FromArgb(
                color.R,
                Math.Min(color.G + 25, 255),
                color.B
            );
        }

        public void DecreaseGreen()
        {
            color = Color.FromArgb(
                color.R,
                Math.Max(color.G - 25, 0),
                color.B
            );
        }

        public void IncreaseBlue()
        {
            color = Color.FromArgb(
                color.R,
                color.G,
                Math.Min(color.B + 25, 255)
            );
        }

        public void DecreaseBlue()
        {
            color = Color.FromArgb(
                color.R,
                color.G,
                Math.Max(color.B - 25, 0)
            );
        }*/

    }

}
