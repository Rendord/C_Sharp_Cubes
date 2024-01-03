using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTransformations
{
    public partial class Form1 : Form
    {

        float basetheta = -100;
        float basephi = 10;
        //view and projection transformation settings
        float theta;
        float phi;
        float r;
        float depth;

        // Axes
        AxisX x_axis;
        AxisY y_axis;
        AxisZ z_axis;

        // Objects
        Cube cube;

        //Translation Vector
        Vector TVector;

        // Window dimensions
        const int WIDTH = 800;
        const int HEIGHT = 600;

        //Scale
        double scale;

        //rotation x y z
        float deg_x;
        float deg_y;
        float deg_z;

        //parameter string
        string parameters;

        //phase
        int phase;

        //booleans for the animation, is it possible without?
        bool scaled;
        bool rotated;

        //timer
        Timer animationTimer;

        public Form1()
        {
            InitializeComponent();

            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.DoubleBuffered = true;

            //initialize variables
            InitializeVariables();

            //timer
            animationTimer = new Timer();
            animationTimer.Interval = 50;
            animationTimer.Tick += new EventHandler(animationEvent);

            // Define axes
            x_axis = new AxisX(2);
            y_axis = new AxisY(2);
            z_axis = new AxisZ(2);

            // Create objects
            cube = new Cube(Color.Blue);

            //test code

            //Vector marty = new Vector(1, 2, 3);
            //Matrix morty = new Matrix(2, 4, 6, 8, 10, 12, 14, 16, 18);
            //Matrix moriarty = Matrix.ScaleMatrix(4) * morty;
            //Console.WriteLine(moriarty.ToString());




        }






    
        private void animationEvent(Object myObject, EventArgs myEventArgs)
        {
            
            if (phase == 1)
            {
                if (!scaled)
                {
                    if (scale >= 1.5)
                    {
                        scaled = true;
                        return;
                    }
                    scale += 0.01;
                    theta--;
                } else
                {
                    if (scale <= 1.0)
                    {
                        scaled = false;
                        phase = 2;
                        return;
                    }
                    scale -= 0.01;
                    theta--;
                }
            }
            if (phase == 2)
            {
                if (!rotated)
                {
                    if (deg_x >= 45)
                    {
                        rotated = true;
                        return;
                    }
                    deg_x++;
                    theta--;
                }
                else
                {
                    if (deg_x <= 0)
                    {
                        rotated = false;
                        phase = 3;
                        return;
                    }
                    deg_x--;
                    theta--;
                }
            }
            if (phase == 3)
            {              
                if (!rotated)
                {
                    if (deg_y >= 45)
                    {
                        rotated = true;
                        return;
                    }
                    deg_y++;
                    phi++;
                }
                else
                {
                    if (deg_y <= 0)
                    {
                        if(theta >= basetheta && phi <= basephi) {
                            rotated = false;
                            phase = 1;
                            return;
                        }
                        if (theta < basetheta) 
                            theta++;
                        if (phi > basephi)
                            phi--;                      
                    } else
                    {
                        deg_y--;
                        phi++;
                    }
                    
                }
            }
            Refresh();
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw Text
            RenderParameters(e);

            
            // Draw axes
            x_axis.Draw(e.Graphics, AxesBuilder(x_axis.vertexbuffer));
            y_axis.Draw(e.Graphics, AxesBuilder(y_axis.vertexbuffer));
            z_axis.Draw(e.Graphics, AxesBuilder(z_axis.vertexbuffer));

            // Draw cube
            cube.Draw(e.Graphics, VertexBuilder(cube.vertexbuffer));
        }

        private void RenderParameters(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, StringBuilder(), this.Font,
                new Point(0, 0), SystemColors.ControlText);
        }

        private string StringBuilder()
        {
            parameters = 
             "Scale:        " + scale + "\n" +
             "TranslateX:   " + TVector.x + "\n" +
             "TranslateY:   " + TVector.y + "\n" +
             "TranslateZ:   " + TVector.z + "\n" +
             "RotateX:      " + deg_x + "\n" +
             "RotateY:      " + deg_y + "\n" +
             "RotateZ:      " + deg_z + "\n" +
             "\n" +
             "r:      " + r + "\n" +
             "d:      " + depth + "\n" +
             "phi:    " + phi + "\n" +
             "theta:  " + theta + "\n" +
             "\n" +
             "phase:    " + phase + "\n";

            return parameters;
        }

        private void InitializeVariables()
        {
            theta = basetheta;
            phi = basephi;
            r = 10;
            depth = 800;
            scale = 1;
            TVector = new Vector(0, 0, 0);
            parameters = "";
            deg_x = 0;
            deg_y = 0;
            deg_z = 0;
            phase = 0;
        }

        private List<Vector> AxesBuilder(List<Vector> vb)
        {
            List<Vector> placeholder = new List<Vector>();
            placeholder.AddRange(vb);

            for (int i = 0; i < x_axis.vertexbuffer.Count; i++)
            {
                placeholder[i] = Matrix.ViewMatrix(theta, phi, r) * placeholder[i];
                placeholder[i] = Matrix.ProjectionMatrix(depth, placeholder[i]) * placeholder[i];
            }
            placeholder.ForEach((v) => v.y = -v.y);
            placeholder.ForEach((v) => v.x += 0.5f * WIDTH);
            placeholder.ForEach((v) => v.y += 0.5f * HEIGHT);
            

            return placeholder;
        }
        private List<Vector> VertexBuilder(List<Vector> vb)
        {
            List<Vector> placeholder = new List<Vector>();
            placeholder.AddRange(vb);
            for (int i = 0; i < placeholder.Count; i++)
            {
                placeholder[i] = Matrix.ScaleMatrix((float)scale) * placeholder[i];
            //}
            //for (int i = 0; i < placeholder.Count; i++)
            //{
                placeholder[i] = Matrix.RotateMatrixX(deg_x) * placeholder[i];
            //}
            //for (int i = 0; i < placeholder.Count; i++)
            //{
                placeholder[i] = Matrix.RotateMatrixY(deg_y) * placeholder[i];
            //}
            //for (int i = 0; i < placeholder.Count; i++)
            //{
                placeholder[i] = Matrix.RotateMatrixZ(deg_z) * placeholder[i];
            //}
            //for (int i = 0; i < placeholder.Count; i++)
            //{
                placeholder[i] = Matrix.TranslationMatrix(TVector) * placeholder[i];
            //}
            //for (int i = 0; i < placeholder.Count; i++)
            //{
                placeholder[i] = Matrix.ViewMatrix(theta, phi, r) * placeholder[i];
            //}
            //for (int i = 0; i < placeholder.Count; i++)
            //{
                placeholder[i] = Matrix.ProjectionMatrix(depth, placeholder[i]) * placeholder[i];
            }
            placeholder.ForEach((v) => v.y = -v.y);
            placeholder.ForEach((v) => v.x += 0.5f * WIDTH);
            placeholder.ForEach((v) => v.y += 0.5f * HEIGHT);
            
            return placeholder;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Left)
                TVector.x--;
            if (e.KeyCode == Keys.Right)
                TVector.x++;
            if (e.KeyCode == Keys.Down)
                TVector.y--;
            if (e.KeyCode == Keys.Up)
                TVector.y++;
            if (e.KeyCode == Keys.PageDown)
                TVector.z--;
            if (e.KeyCode == Keys.PageUp)
                TVector.z++;
            if (e.KeyCode == Keys.S)
                if (e.Shift)
                    scale += 0.1;
                else
                {
                    scale -= 0.1;
                    if(scale < 0.1)
                    {
                        scale = 0.1;
                    }
                }
            if (e.KeyCode == Keys.X)
                if (e.Shift)
                    deg_x++;
                else
                {
                    deg_x--;
                }
            if (e.KeyCode == Keys.Y)
                if (e.Shift)
                    deg_y++;
                else
                {
                    deg_y--;
                }
            if (e.KeyCode == Keys.Z)
                if (e.Shift)
                    deg_z++;
                else
                {
                    deg_z--;
                }
            if (e.KeyCode == Keys.R)
                if (e.Shift)
                    r++;
                else
                {
                    r--;
                }
            if (e.KeyCode == Keys.D)
                if (e.Shift)
                    depth++;
                else
                {
                    depth--;
                }
            if (e.KeyCode == Keys.P)
                if (e.Shift)
                    phi++;
                else
                {
                    phi--;
                }
            if (e.KeyCode == Keys.T)
                if (e.Shift)
                    theta++;
                else
                {
                    theta--;
                }
            if (e.KeyCode == Keys.C)
            {
                InitializeVariables();
                phase = 0;
            }
            if (e.KeyCode == Keys.A)
            {
                animationTimer.Start();
                phase = 1;
            }

            Refresh();
        }
    }
}
