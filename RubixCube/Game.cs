using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixCube
{
    class Game : GameWindow
    {
        int Frames = 0;
        DateTime Past = DateTime.Now;
        
        Vector3[][] corners = new Vector3[][]
        {
            new Vector3[]
            {
                new Vector3(10,20,0), new Vector3(110,200,0), new Vector3(210,20,0)
            },
            new Vector3[]
            {
                new Vector3(10,220,0), new Vector3(10,420,0), new Vector3(200,420,0), new Vector3(200,220,0)
            }
        };

        public Game(int width = 900, int height = 900)
            : base(width, height)
        {
            Title = "Rubix Tester";
            Load += GameWindowOnLoad;
            UpdateFrame += GameUpdateFrame;
            RenderFrame += GameRenderFrame;
            Resize += GameWindowResize;
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
        }

        private void GameWindowResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, Width / 2.0, 0.0, Height / 2.0, 0, -10);
        }

        private void GameRenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach(Vector3[] arr in corners)
            {
                GL.Color3(Color.Red);
                GL.Begin(PrimitiveType.Polygon);
                foreach(Vector3 vec in arr)
                {
                    GL.Vertex3(vec);
                }
                GL.End();
            }

            Frames++;

            SwapBuffers();
        }

        private void GameUpdateFrame(object sender, FrameEventArgs e)
        {
            if ((DateTime.Now - Past).Seconds >= 1)
            {
                Title = "Rubix Tester" + "  FPS:" + (int)(Frames);
                Frames = 0;
                Past = DateTime.Now;
            }
        }

        private void GameWindowOnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(1f, 1f, 1f, 1f);
        }
    }
}
