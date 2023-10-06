using GrammyDevStudio.WinForms_GameCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game3D
{
    public class TileCamera3D : ICamera
    {
        public PictureBox PictureBox { get; set; }

        PointF Position;
        Game3D Game3D;

        const float maxDistance = 20;
        const int RayCount = 40;
        const float AngleBetweenRays = 1;
        Point Resolution = new Point(800, 600);
        const float Step = 0.1f;

        int LineWhidh;
        float LineHigtStep;

        public TileCamera3D(PictureBox pictureBox, Point position, Game3D game3D)
        {
            PictureBox = pictureBox;
            Position = position;
            Game3D = game3D;

            LineWhidh = Resolution.X / RayCount;
            LineHigtStep = Resolution.Y / (maxDistance / Step);
        }

        public void MakeFrame()
        {
            Bitmap bitmap = new Bitmap(Resolution.X, Resolution.Y);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                (bool, Color, float) rayData = Ray(Game3D.Angel);

                
                if (rayData.Item1)
                {
                    int ColumSize = GetColumSize(rayData.Item3);
                    int columGap = (800 - ColumSize) / 2;

                    graphics.DrawLine(new Pen(rayData.Item2, 600), new Point(400,  columGap), new Point(400,  600 - columGap));
                }
            }

            PictureBox.Image = bitmap;
            Game3D.CoreForm.label1.Text = Game3D.Angel.ToString();
        }

        public void Resize()
        {

        }

        (bool, Color, float) Ray(double angleInDegrees)
        {
            PointF rayLocation = Position;
            
            float nowDistace = 0;

            while (RayNotFinishDictace() && RayOnMap())
            {
                // Отправка Луча
                double angleInRadians = angleInDegrees * (Math.PI / 180);
                double cosTheta = Math.Cos(angleInRadians);
                double sinTheta = Math.Sin(angleInRadians);
                rayLocation.X += (float)(cosTheta * Step);
                rayLocation.Y += (float)(sinTheta * Step);

                nowDistace += Step;

                // Проверка столкновения
                Point NowTile = new Point((int)Math.Floor(rayLocation.X), (int)Math.Floor(rayLocation.Y));
                // Корректировка отрицательного значения
                if(NowTile.X < 0) 
                { 
                    NowTile.X = 0;
                }
                if (NowTile.Y < 0)
                {
                    NowTile.Y = 0;
                }

                if (Game3D.World[NowTile.X, NowTile.Y] != null)
                {
                    return (true, Game3D.World[NowTile.X, NowTile.Y].Value.Color, nowDistace);
                }

            } 
            

            return (false, Color.Black, 0);


            bool RayOnMap()
            {
                if (rayLocation.X > 0 && rayLocation.X < Game3D.World.GetLength(0) - 1 && rayLocation.Y > 0 && rayLocation.Y < Game3D.World.GetLength(1) - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool RayNotFinishDictace()
            {
                if (nowDistace < maxDistance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }


        int GetColumSize(float dictace) 
        {
            return (int)(800 - (dictace * 20));
        }
    }
}
