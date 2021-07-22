using System.Collections.ObjectModel;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace KioskCafeteriaTutorial
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            ItemPopup.Instance.BlurView = contentView;
            ObservableCollection<MenuItemGroup> albumSource = new ObservableCollection<MenuItemGroup>();
            Resources.SelectIndexArray.Add(0);
            Resources.SelectIndexArray.Add(1);
            foreach (var i in Resources.SelectIndexArray)
            {
                albumSource.CreateData(i);
            }

            CollectionView colView = new CollectionView()
            {
                HideScrollbar = false,

                ItemsSource = albumSource,
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    return new ItemView();
                }),
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    DefaultTitleItem group = new DefaultTitleItem();
                    group.BackgroundColor = Tizen.NUI.Color.Transparent;
                    group.WidthSpecification = LayoutParamPolicies.MatchParent;

                    group.Label.TextColor = new Tizen.NUI.Color("#7474FF");
                    group.Label.PixelSize = 20;
                    group.Label.SetBinding(TextLabel.TextProperty, "Title");
                    group.Label.HeightSpecification = 60;
                    group.Label.HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin;

                    return group;
                }),
                IsGrouped = true,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                SelectionMode = ItemSelectionMode.Single,
                Weight = 0.9f,
            };
            container.Add(colView);
        }


        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            Navigator.Pop();
        }
    }
}
