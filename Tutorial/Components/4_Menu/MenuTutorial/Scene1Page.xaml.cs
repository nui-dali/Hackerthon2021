using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace MenuTutorial
{
    public partial class Scene1Page : View
    {
        MenuItem menuItem1;
        MenuItem menuItem2;
        MenuItem menuItem3;
        MenuItem menuItem4;
        MenuItem menuItem5;

        public Scene1Page()
        {
            InitializeComponent();

            // TODO : Make more simple
            menuItem1 = new MenuItem();
            menuItem1.Text = "Menu1";
            menuItem1.Clicked += OnItemClicked;

            menuItem2 = new MenuItem();
            menuItem2.Text = "Menu2";
            menuItem2.Clicked += OnItemClicked;

            menuItem3 = new MenuItem();
            menuItem3.Text = "Menu3";
            menuItem3.Clicked += OnItemClicked;

            menuItem4 = new MenuItem();
            menuItem4.Text = "Menu4";
            menuItem4.Clicked += OnItemClicked;

            menuItem5 = new MenuItem();
            menuItem5.Text = "Menu5";
            menuItem5.Clicked += OnItemClicked;
        }

        private void OnClicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            var menu = new Menu()
            {
                Anchor = moreButton,
                HorizontalPositionToAnchor = Menu.RelativePosition.Center,
                VerticalPositionToAnchor = Menu.RelativePosition.End,
                Items = new MenuItem[] { menuItem1, menuItem2, menuItem3, menuItem4, menuItem5 }
            };

            menu.Post();
        }

        private void OnItemClicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                OutputText.Text += $"\n{menuItem.Text} is clicked!";
            }
        }
    }
}
