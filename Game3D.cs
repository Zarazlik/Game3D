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

        public float ViewDirection = 0;

        public Tile?[,] World = new Tile?[10, 7]
        {
            { null, new Tile(Color.Orange), new Tile(Color.Orange),new Tile(Color.Orange), new Tile(Color.Orange), new Tile(Color.Orange), null},
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, new Tile(Color.Blue), null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null }
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
