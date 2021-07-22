using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace KioskCafeteriaTutorial
{
    public class ItemView : RecyclerViewItem
    {
        private Button btn;
        private TextLabel label;
        public ItemView()
        {
            float sizeW = Window.Instance.WindowSize.Width * 0.3f;
            Size = new Size(sizeW, sizeW);

            btn = new Button()
            {
                StyleName = "GalleryButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,

            };
            btn.Icon.WidthSpecification = (int)(sizeW * 0.7f);
            btn.Icon.HeightSpecification = (int)(sizeW * 0.7f);
            btn.Icon.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
            Add(btn);
            label = new TextLabel()
            {
                PointSize = 20,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
            };
            Add(label);

            label.SetBinding(TextLabel.TextProperty, "NameLabel");
            btn.Clicked += Btn_Clicked;
        }

        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            var tag1 = $"{Index}-Button";
            var tag2 = $"{Index}-Icon";
            btn.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = tag1,
            };

            btn.Icon.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = tag2,
            };

            ItemPopup.Instance.BindingContext = this.BindingContext;
            ItemPopup.Instance.SetTag(tag1, tag2);
            ItemPopup.Instance.ShowPopup();
        }
    }
}
