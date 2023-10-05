namespace Game3D
{
    public partial class Form1 : GrammyDevStudio.WinForms_GameCore.CoreForm
    {
        public Form1()
        {
            InitializeComponent();

            GameLogic = new Game3D(this);

            GameLogic.LoadGame();
        }
    }
}