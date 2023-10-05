using GrammyDevStudio.WinForms_GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3D
{
    public class TileCamera3D : ICamera
    {
        public PictureBox PictureBox { get; set; }

        Point Position;
        Game3D Game3D;

        TileCamera3D(PictureBox pictureBox, Point position, Game3D game3D)
        {
            PictureBox = pictureBox;
            Position = position;
            Game3D = game3D;
        }

        public void MakeFrame()
        {
            Point point = new Point(0, 0);
            double angleInDegrees = 0;
            double distance = 10;
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            point.Offset((int)(cosTheta * distance), (int)(sinTheta * distance));
        }

        public void Resize()
        {

        }
    }
}
