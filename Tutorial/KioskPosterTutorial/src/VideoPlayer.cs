using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace KioskPosterTutorial
{
    public class VideoPlayer : Tizen.Multimedia.Player
    {
        public VideoPlayer() : base()
        {
            Initialize();
        }

        public VideoPlayer(IntPtr ptr) : base(ptr, null)
        {
            Initialize();
        }

        public VideoPlayer(VideoView videoView) : base((new SafeNativePlayerHandle(videoView)).DangerousGetHandle(), null)
        {
            Initialize();
        }
    }
}
