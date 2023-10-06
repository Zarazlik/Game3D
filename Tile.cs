using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3D
{
    public struct Tile
    {
        public Color Color {  get; set; }

        public Tile(Color color)
        {
            Color = color;
        }
    }
}
