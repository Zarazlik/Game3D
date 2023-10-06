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
        float VisionAngle = 80;

        Point Resolution = new Point(800, 600);
        const float Step = 0.1f;

        int LineWhidh;
        float LineHigtStep;
        float AngleBetweenRays;

        public TileCamera3D(PictureBox pictureBox, Point position, Game3D game3D)
        {
            PictureBox = pictureBox;
            Position = position;
            Game3D = game3D;

            LineWhidh = Resolution.X / RayCount;
            LineHigtStep = Resolution.Y / (maxDistance / Step);
            AngleBetweenRays = RayCount / VisionAngle;
        }

        public void MakeFrame()
        {
            Bitmap bitmap = new Bitmap(Resolution.X, Resolution.Y);

            float StartAngel = Game3D.ViewDirection - (AngleBetweenRays * RayCount / 2);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < RayCount; i++)
                {
                    (bool, Color, float) rayData = Ray(StartAngel + (AngleBetweenRays * i));

                    if (rayData.Item1)
                    {
                        int ColumSize = GetColumSize(rayData.Item3);
                        int columGap = (Resolution.X - ColumSize) / 2;

                        graphics.DrawLine(new Pen(rayData.Item2, LineWhidh), new Point((LineWhidh * i) + (LineWhidh/ 2) , columGap), new Point((LineWhidh * i) + (LineWhidh / 2), Resolution.Y - columGap));
                    }
                }
            }

            PictureBox.Image = bitmap;
            Game3D.CoreForm.label1.Text = Game3D.ViewDirection.ToString();


            int GetColumSize(float dictace)
            {
                return (int)(Resolution.X - (dictace * 20));
            }
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
                float angleInRadians = (float)(angleInDegrees * (Math.PI / 180));
                float cosTheta = (float)Math.Cos(angleInRadians);
                float sinTheta = (float)Math.Sin(angleInRadians);
                rayLocation.X += (cosTheta * Step);
                rayLocation.Y += (sinTheta * Step);

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
        }


    }
}
