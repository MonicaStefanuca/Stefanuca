using OpenTK;
using OpenTK.Graphics.OpenGL;

using System;
using System.Drawing;
using System.IO;

namespace Stefanuca
{
    class Cube3D
    {
        private Vector3[] vertices;
        private Color[] colors;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private PolygonMode polMode;
        private bool colorsDisplayed = false;

        public Cube3D(string filePath)
        {
            InitializeVerticesFromFile(filePath);
            InitializeColors();

            visibility = true;
            linewidth = 3.0f;
            pointsize = 3.0f;
            polMode = PolygonMode.Fill;
        }

        private void InitializeVerticesFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length >= 8)
                {
                    vertices = new Vector3[8];
                    for (int i = 0; i < 8; i++)
                    {
                        string[] coordinates = lines[i].Split(' ');
                        vertices[i] = new Vector3(
                            float.Parse(coordinates[0]),
                            float.Parse(coordinates[1]),
                            float.Parse(coordinates[2])
                        );
                    }
                }
                else
                {
                    throw new Exception("The file does not contain enough lines to define a cube.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading coordinates from the file: " + ex.Message);
            }
        }

        private void InitializeColors()
        {
            colors = new Color[]
            {
                Color.White, Color.LawnGreen, Color.WhiteSmoke, Color.Tomato, Color.Turquoise, Color.OldLace, Color.Olive, Color.MidnightBlue
            };
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.Begin(PrimitiveType.Triangles);

                // Draw the front face
                SetVertexColor(0);
                GL.Vertex3(vertices[0]);
                SetVertexColor(1);
                GL.Vertex3(vertices[1]);
                SetVertexColor(2);
                GL.Vertex3(vertices[2]);

                SetVertexColor(0);
                GL.Vertex3(vertices[0]);
                SetVertexColor(2);
                GL.Vertex3(vertices[2]);
                SetVertexColor(3);
                GL.Vertex3(vertices[3]);

                // Draw the back face
                SetVertexColor(4);
                GL.Vertex3(vertices[4]);
                SetVertexColor(5);
                GL.Vertex3(vertices[5]);
                SetVertexColor(6);
                GL.Vertex3(vertices[6]);

                SetVertexColor(4);
                GL.Vertex3(vertices[4]);
                SetVertexColor(6);
                GL.Vertex3(vertices[6]);
                SetVertexColor(7);
                GL.Vertex3(vertices[7]);

                // Draw the left face
                SetVertexColor(0);
                GL.Vertex3(vertices[0]);
                SetVertexColor(3);
                GL.Vertex3(vertices[3]);
                SetVertexColor(7);
                GL.Vertex3(vertices[7]);

                SetVertexColor(0);
                GL.Vertex3(vertices[0]);
                SetVertexColor(7);
                GL.Vertex3(vertices[7]);
                SetVertexColor(4);
                GL.Vertex3(vertices[4]);

                // Draw the right face
                SetVertexColor(1);
                GL.Vertex3(vertices[1]);
                SetVertexColor(2);
                GL.Vertex3(vertices[2]);
                SetVertexColor(6);
                GL.Vertex3(vertices[6]);

                SetVertexColor(1);
                GL.Vertex3(vertices[1]);
                SetVertexColor(6);
                GL.Vertex3(vertices[6]);
                SetVertexColor(5);
                GL.Vertex3(vertices[5]);

                // Draw the top face
                SetVertexColor(2);
                GL.Vertex3(vertices[2]);
                SetVertexColor(3);
                GL.Vertex3(vertices[3]);
                SetVertexColor(7);
                GL.Vertex3(vertices[7]);

                SetVertexColor(2);
                GL.Vertex3(vertices[2]);
                SetVertexColor(7);
                GL.Vertex3(vertices[7]);
                SetVertexColor(6);
                GL.Vertex3(vertices[6]);

                // Draw the bottom face
                SetVertexColor(0);
                GL.Vertex3(vertices[0]);
                SetVertexColor(1);
                GL.Vertex3(vertices[1]);
                SetVertexColor(5);
                GL.Vertex3(vertices[5]);

                SetVertexColor(0);
                GL.Vertex3(vertices[0]);
                SetVertexColor(5);
                GL.Vertex3(vertices[5]);
                SetVertexColor(4);
                GL.Vertex3(vertices[4]);

                GL.End();

                if (!colorsDisplayed)
                {
                    DisplayVertexColors();
                    colorsDisplayed = true;
                }
            }
        }

        private void SetVertexColor(int index)
        {
            GL.Color3(colors[index]);
        }

        public void DisplayVertexColors()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                Color currentColor = colors[i];
                Console.WriteLine($"Vertex {i + 1} - R: {currentColor.R}, G: {currentColor.G}, B: {currentColor.B}");
            }
        }
        public void RandomizeColors()
        {
            Random random = new Random();
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = GenerateRandomColor(random);
            }

            Console.WriteLine("Randomized colors for the cube:");
            DisplayVertexColors();
        }

        private Color GenerateRandomColor(Random random)
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        public void LoadDefaultPalette()
        {
            colors = new Color[]
            {
                Color.Orange, Color.Yellow, Color.Purple, Color.Pink, Color.Cyan, Color.Magenta, Color.Brown, Color.Gray
            };

            Console.WriteLine("Loaded default color palette for the cube:");
            DisplayVertexColors();
        }


        public void IncreaseColorRed(int[] faceIndex)
        {
            for (int i = 0; i < faceIndex.Length; i++)
            {
                if (faceIndex[i] >= 0 && faceIndex[i] < colors.Length)
                {
                    Color currentColor = colors[faceIndex[i]];
                    int newRed = Math.Min(currentColor.R + 200, 255);
                    colors[faceIndex[i]] = Color.FromArgb(newRed, currentColor.G, currentColor.B);
                    Console.WriteLine($"Increased Red for vertex {faceIndex[i]} to R = {newRed}");
                }
            }
        }

        public void DecreaseColorRed(int[] faceIndex)
        {
            for (int i = 0; i < faceIndex.Length; i++)
            {
                if (faceIndex[i] >= 0 && faceIndex[i] < colors.Length)
                {
                    Color currentColor = colors[faceIndex[i]];
                    int newRed = Math.Max(currentColor.R - 200, 0);
                    colors[faceIndex[i]] = Color.FromArgb(newRed, currentColor.G, currentColor.B);
                    Console.WriteLine($"Decreased Red for vertex {faceIndex[i]} to R = {newRed}");
                }
            }
        }

        public void IncreaseColorGreen(int[] faceIndex)
        {
            for (int i = 0; i < faceIndex.Length; i++)
            {
                if (faceIndex[i] >= 0 && faceIndex[i] < colors.Length)
                {
                    Color currentColor = colors[faceIndex[i]];
                    int newGreen = Math.Min(currentColor.G + 200, 255);
                    colors[faceIndex[i]] = Color.FromArgb(currentColor.R, newGreen, currentColor.B);
                    Console.WriteLine($"Increased Green for vertex {faceIndex[i]} to G = {newGreen}");
                }
            }
        }

        public void DecreaseColorGreen(int[] faceIndex)
        {
            for (int i = 0; i < faceIndex.Length; i++)
            {
                if (faceIndex[i] >= 0 && faceIndex[i] < colors.Length)
                {
                    Color currentColor = colors[faceIndex[i]];
                    int newGreen = Math.Max(currentColor.G - 200, 0);
                    colors[faceIndex[i]] = Color.FromArgb(currentColor.R, newGreen, currentColor.B);
                    Console.WriteLine($"Decreased Green for vertex {faceIndex[i]} to G = {newGreen}");
                }
            }
        }

        public void IncreaseColorBlue(int[] faceIndex)
        {
            for (int i = 0; i < faceIndex.Length; i++)
            {
                if (faceIndex[i] >= 0 && faceIndex[i] < colors.Length)
                {
                    Color currentColor = colors[faceIndex[i]];
                    int newBlue = Math.Max(currentColor.B - 200, 0);
                    colors[faceIndex[i]] = Color.FromArgb(currentColor.R, currentColor.G, newBlue);
                    Console.WriteLine($"Increased Blue for vertex {faceIndex[i]} to B = {newBlue}");
                }
            }
        }

        public void DecreaseColorBlue(int[] faceIndex)
        {
            for (int i = 0; i < faceIndex.Length; i++)
            {
                if (faceIndex[i] >= 0 && faceIndex[i] < colors.Length)
                {
                    Color currentColor = colors[faceIndex[i]];
                    int newBlue = Math.Max(currentColor.B - 200, 0);
                    colors[faceIndex[i]] = Color.FromArgb(currentColor.R, currentColor.G, newBlue);
                    Console.WriteLine($"Decreased Blue for vertex {faceIndex[i]} to B = {newBlue}");
                }
            }
        }
    }
}