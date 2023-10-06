using GrammyDevStudio.WinForms_GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3D
{
    public class Game3D : GameLogic
    {
        public Form1 CoreForm;

        public double Angel = 0;

        public Tile?[,] World = new Tile?[7, 7]
        {
            { null, new Tile(Color.Orange), new Tile(Color.Orange),new Tile(Color.Orange), new Tile(Color.Orange), new Tile(Color.Orange), null},
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
        };

        public Game3D(CoreForm coreForm) : base(coreForm) 
        { 
            this.CoreForm = coreForm as Form1;
            
        }

        public override void LoadGame()
        {
            Camera.MakeFrame();
        }
    }
}
