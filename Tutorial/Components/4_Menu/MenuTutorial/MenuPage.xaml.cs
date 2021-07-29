using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace MenuTutorial
{
    public partial class MenuPage : Menu
    {
        public MenuPage()
        {
            InitializeComponent();

            // TODO : There might be an issue on Clicked event of MenuItem when using it in xaml.
            menuItem1.Clicked += OnItemClicked;
            menuItem2.Clicked += OnItemClicked;
            menuItem3.Clicked += OnItemClicked;
            menuItem4.Clicked += OnItemClicked;
            menuItem5.Clicked += OnItemClicked;
        }

        private void OnItemClicked(object sender, ClickedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                Scene1Page page = new Scene1Page();
                page.OutputText.Text += $"\n{menuItem.Text} is clicked!";
            }
        }
    }
}
