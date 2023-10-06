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

        public TileCamera3D(PictureBox pictureBox, Point position, Game3D game3D)
        {
            PictureBox = pictureBox;
            Position = position;
            Game3D = game3D;
        }

        public void MakeFrame()
        {
            PictureBox.BackColor = Ray(Game3D.Angel);
            Game3D.CoreForm.label1.Text = Game3D.Angel.ToString();
        }

        public void Resize()
        {

        }

        Color Ray(double angleInDegrees)
        {
            PointF rayLocation = Position;
            const float maxDistance = 20;
            const float Step = 0.1f;
            float nowDistace = 0;

            do
            {
                // Отправка Луча
                double angleInRadians = angleInDegrees * (Math.PI / 180);
                double cosTheta = Math.Cos(angleInRadians);
                double sinTheta = Math.Sin(angleInRadians);
                rayLocation.X += (float)(cosTheta * Step);
                rayLocation.Y += (float)(sinTheta * Step);

                // Проверка столкновения
                Point NowTile = new Point((int)Math.Floor(rayLocation.X), (int)Math.Floor(rayLocation.Y));
                if (Game3D.World[NowTile.X, NowTile.Y] != null)
                {
                    return Game3D.World[NowTile.X, NowTile.Y].Value.Color;
                }

            } 
            while (RayNotFinishDictace() && RayOnMap());

            return Color.Black;


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
                if (nowDistace < 10)
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
