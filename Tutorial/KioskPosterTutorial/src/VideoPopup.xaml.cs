using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace KioskPosterTutorial
{
    public partial class VideoPopup : View
    {
        private VideoPlayer videoPlayer;
        private Timer playerTimer;
        public VideoPopup()
        {
            InitializeComponent();

            playerView.Underlay = false;

            videoPlayer = new VideoPlayer(playerView);
            if (videoPlayer != null)
            {
                SetAsyncSourceAndPlay();
            }


        }
        public async void SetAsyncSourceAndPlay()
        {
            videoPlayer.SetSource(new Tizen.Multimedia.MediaUriSource(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/video/sample.3gp"));
            await videoPlayer.PrepareAsync();
            await videoPlayer.SetPlayPositionAsync(9000, true);

            playerView.Play();

            playerTimer = new Timer(100);
            playerTimer.Tick += Timer_Tick;
            playerTimer.Start();
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            float pos = videoPlayer.GetPlayPosition();
            float total = videoPlayer.StreamInfo.GetDuration();
            float cVal = (float)(pos / total);

            Tizen.Log.Error("MYLOG", $"pos : {pos}, total : {total}, cVal {cVal}");
            return true;
        }

        private bool playerView_TouchEvent(object source, TouchEventArgs e)
        {
            if(e.Touch.GetState(0) == PointStateType.Up)
            {
                (this.GetParent().Children[0] as GaussianBlurView).Deactivate();
                this.Unparent();
            }
            return false;
        }
    }
}
