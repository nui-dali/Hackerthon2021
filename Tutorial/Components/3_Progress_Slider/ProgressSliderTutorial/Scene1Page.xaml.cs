using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ProgressSliderTutorial
{
    public partial class Scene1Page : View
    {
        Timer progressTimer;
        public Scene1Page()
        {
            InitializeComponent();

            progressTimer = new Timer(300);
            progressTimer.Tick += OnTick;
            progressTimer.Start();
        }

        private bool OnTick(object source, Timer.TickEventArgs e)
        {
            Progress1.CurrentValue++;

            TimerText.Text = "Processing..." + Progress1.CurrentValue + "%";

            return true;
        }

        private void OnValueChanged(object sender, Tizen.NUI.Components.SliderValueChangedEventArgs e)
        {
            ValueText.Text = "value : " + e.CurrentValue;
        }
    }
}
