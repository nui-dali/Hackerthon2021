using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using static Tizen.NUI.BaseComponents.View;

namespace KioskCafeteriaTutorial
{
    public partial class ItemPopup : DialogPage
    {
        private static ItemPopup instance;
        public GaussianBlurView BlurView { get; set; }
        public ItemPopup()
        {
            InitializeComponent();
            image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
        }

        public static ItemPopup Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ItemPopup();
                }
                return instance;
            }
        }

        public void ShowPopup()
        {
            BlurView?.Activate();

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().PushWithTransition(this);
        }

        public void SetTag(string tag1, string tag2)
        {
            contentView.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = tag1,
            };
            image.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = tag2,
            };

        }

        private bool View_TouchEvent(object source, TouchEventArgs e)
        {
            BlurView?.Deactivate();

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().PopWithTransition();
            return true;
        }
    }
}
