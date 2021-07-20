using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace KioskPosterTutorial
{
    public partial class MyPopup : View
    {
        public MyPopup()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            (this.GetParent().Children[0] as GaussianBlurView).Deactivate();
            this.Unparent();
        }
    }
}
