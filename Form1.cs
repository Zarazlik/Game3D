namespace Game3D
{
    public partial class Form1 : GrammyDevStudio.WinForms_GameCore.CoreForm
    {
        Game3D Game;
        public Form1()
        {
            InitializeComponent();

            Game = new Game3D(this);
            GameLogic = Game;
            GameLogic.Camera = new TileCamera3D(MainDisplay, new Point(8, 4), Game);

            GameLogic.LoadGame();
            //StartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.ViewDirection -= 5;
            Game.Camera.MakeFrame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game.ViewDirection += 5;
            Game.Camera.MakeFrame();
        }
    }
}