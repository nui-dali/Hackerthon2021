using System.Collections.Generic;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace KioskPosterTutorial
{
    public partial class Scene1Page : GaussianBlurView
    {
        private int totalCount = 0;
        private int index = 0;
        public Scene1Page() : base(20, 8.0f, PixelFormat.RGBA8888, 1.0f, 1.0f, false)
        {
            InitializeComponent();
            gradientBG.AddVisual("Linear_Gradient", new MyGradientVisual());
            LoadAllResources();
        }

        private void LoadAllResources()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo($"{Application.Current.DirectoryInfo.Resource}/images/poster/");

            foreach (System.IO.FileInfo File in directoryInfo.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".png") == 0)
                {
                    ImageView imgView = new ImageView()
                    {
                        ResourceUrl = File.FullName,
                        Size = new Size(600, 900),
                    };
                    myScroll.Add(imgView);
                    totalCount++;
                }
                pagination.IndicatorCount = totalCount;
            }
        }

        private void LeftButton_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            if (index - 1 >= 0)
            {
                index--;

                myScroll.ScrollToIndex(index);
                pagination.SelectedIndex = index;
            }

        }

        private void RightButton_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            if (index + 1 < totalCount)
            {
                index++;
                myScroll.ScrollToIndex(index);
                pagination.SelectedIndex = index;
            }
        }

        private void myScroll_ScrollAnimationEnded(object sender, Tizen.NUI.Components.ScrollEventArgs e)
        {
            Animation ani = new Animation(600);
            ani.AnimateTo(bottomView, "Opacity", 0.7f);
            ani.Play();
        }

        private void myScroll_ScrollAnimationStarted(object sender, Tizen.NUI.Components.ScrollEventArgs e)
        {
            bottomView.Opacity = 0.0f;
        }

        private void Button_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            Window.Instance.GetDefaultLayer().Add(new MyPopup());
            this.Activate();
        }
    }
}
