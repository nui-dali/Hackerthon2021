using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace KioskCafeteriaTutorial
{
    public partial class Scene1Page : ContentPage
    {
        public Scene1Page()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            Navigator.Push(new MenuPage());
        }
    }
}
