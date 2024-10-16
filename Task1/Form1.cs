using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        string currentTool = "None";
        Point point1 = Point.Empty;
        Point point2 = Point.Empty;
        bool isFirstClick = true;
        List<Tuple<Point, Point>> lines = new List<Tuple<Point, Point>>();
        List<Point> circles = new List<Point>();
        List<Point> squares = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Black, 2))
            {
                foreach (var line in lines)
                {
                    e.Graphics.DrawLine(p, line.Item1, line.Item2);
                }

                foreach (var circleCenter in circles)
                {
                    e.Graphics.DrawEllipse(p, circleCenter.X - 20, circleCenter.Y - 20, 40, 40); 
                }

                foreach (var square in squares)
                {
                    e.Graphics.DrawRectangle(p, square.X - 30, square.Y - 30, 60, 60);
                }

                if (currentTool == "Line" && point1 != Point.Empty && point2 != Point.Empty)
                {
                    e.Graphics.DrawLine(p, point1, point2);
                }
                if (currentTool == "Circle" && point1 != Point.Empty)
                {
                    e.Graphics.DrawEllipse(p, point1.X, point1.Y, 40, 40);
                }
                if (currentTool == "Square" && point1 != Point.Empty)
                {
                    e.Graphics.DrawRectangle(p, point1.X, point1.Y, 60, 60);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            currentTool = "Line";
        }


        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (currentTool == "Line")
            {
                if (isFirstClick)
                {
                    point1 = e.Location;
                    isFirstClick = false;
                }
                else
                {
                    point2 = e.Location;
                    lines.Add(new Tuple<Point, Point>(point1, point2));
                    point1 = Point.Empty;
                    point2 = Point.Empty;
                    isFirstClick = true;
                    panel1.Invalidate();
                }
            }
            if (currentTool == "Circle")
            {
                point1 = e.Location;
                circles.Add(point1);
                panel1.Invalidate();
                point1 = Point.Empty;
                point2 = Point.Empty;
            }
            if (currentTool == "Square")
            {
                point1 = e.Location;
                squares.Add(point1);
                panel1.Invalidate();
                point1 = Point.Empty;
                point2 = Point.Empty;
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            currentTool = "Circle";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            currentTool = "Square";
        }
    }
}
