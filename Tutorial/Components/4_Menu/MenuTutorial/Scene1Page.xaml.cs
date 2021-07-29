using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace MenuTutorial
{
    public partial class Scene1Page : View
    {
        private MenuPage menu;

        public Scene1Page()
        {
            InitializeComponent();
        }

        private void OnClicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            menu = new MenuPage()
            {
                Anchor = moreButton,
                HorizontalPositionToAnchor = Menu.RelativePosition.Center,
                VerticalPositionToAnchor = Menu.RelativePosition.End
            };

            menu.Post();
        }
    }
}
