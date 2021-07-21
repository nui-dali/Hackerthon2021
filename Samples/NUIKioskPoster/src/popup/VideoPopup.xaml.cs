/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUIKioskPoster
{
    public partial class VideoPopup : RelativeContainer
    {
        private bool isShowController = false;
        private bool isPlaying = false;
        private Timer soundBarTimer;
        private Timer playerTimer;

        private VideoPlayer videoPlayer;
        public VideoPopup()
        {
            InitializeComponent();

            bottomController.Hide();
            soundBarPopup.Hide();
            playerView.Underlay = false;
            isPlaying = true;

            videoPlayer = new VideoPlayer(playerView);
            if (videoPlayer != null)
            {
                SetAsyncSourceAndPlay();
            }
        }

        public async void SetAsyncSourceAndPlay()
        {
            videoPlayer.SetSource(new Tizen.Multimedia.MediaUriSource(ApplicationHelper.ResoucePath + "/video/sample.3gp"));
            await videoPlayer.PrepareAsync();
            ViewModel.TotalDuration = new TimeSpan(0, 0, 0, 0, videoPlayer.StreamInfo.GetDuration());

            ViewModel.PlayPosition = new TimeSpan(0, 0, 0, 0, videoPlayer.GetPlayPosition());

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
            ViewModel.PlayPosition = new TimeSpan(0, 0, 0, 0, videoPlayer.GetPlayPosition());
            VideoSlider.CurrentValue = cVal;
            return true;
        }

        private bool BlockTouchEvent(object source, TouchEventArgs e)
        {
            return false;
        }

        private bool Player_TouchEvent(object source, TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                if (isShowController)
                {
                    isShowController = false;
                    DestroyTimer();
                    soundBarPopup.Hide();
                    bottomController.Hide();
                }
                else
                {
                    isShowController = true;
                    bottomController.Show();
                }
            }
            return false;
        }

        private void PlayBtn_Clicked(object sender, ClickedEventArgs e)
        {
            if (isPlaying)
            {
                playBtn.StyleName = "PlayButton";
                playerView.Pause();
            }
            else
            {
                playBtn.StyleName = "PauseButton";
                playerView.Play();
            }
            isPlaying = !isPlaying;
        }

        private void BackwardBtn_Clicked(object sender, ClickedEventArgs e)
        {
            playerView.Backward(1000);
        }

        private void ForwardBtn_Clicked(object sender, ClickedEventArgs e)
        {
            playerView.Forward(1000);
        }

        private void SoundBtn_Clicked(object sender, ClickedEventArgs e)
        {
            soundBarPopup.Show();
            StartTimer();
        }

        private void VideoSlider_ValueFinishedEvent(object sender, float value)
        {
            float changePosition = videoPlayer.StreamInfo.GetDuration() * value;
            //playerView.Stop();
            playerTimer.Stop();
            videoPlayer.SetPlayPositionAsync((int)changePosition, true);
            ViewModel.PlayPosition = new TimeSpan(0, 0, 0, 0, videoPlayer.GetPlayPosition());
            VideoSlider.CurrentValue = changePosition;
            playerTimer.Start();
        }

        private void VideoSlider_SoundValueChangedEvent(object sender, float value)
        {
            DestroyTimer();

            if (!playerView.Muted && value == 0.0)
            {
                playerView.Muted = true;
                soundBtn.StyleName = "MutedSoundButton";
                soundPopupBtn.StyleName = "MutedSoundButton";
            }
            else
            {
                if (playerView.Muted)
                {
                    playerView.Muted = false;
                    soundBtn.StyleName = "UnmutedSoundButton";
                    soundPopupBtn.StyleName = "UnmutedSoundButton";
                }
            }
        }
        private void VideoSlider_ValueChangeFinishedEvent(object sender, float value)
        {
            DestroyTimer();
            StartTimer();
        }

        private bool SoundBarTimer_Tick(object source, Timer.TickEventArgs e)
        {
            soundBarPopup.Hide();
            return false;
        }

        private void StartTimer()
        {
            soundBarTimer = new Timer(2000);
            soundBarTimer.Tick += SoundBarTimer_Tick;
            soundBarTimer.Start();
        }

        private void DestroyTimer()
        {
            if (soundBarTimer != null)
            {
                soundBarTimer.Stop();
                soundBarTimer.Dispose();
                soundBarTimer = null;
            }
        }

        private void Close_Clicked(object sender, ClickedEventArgs e)
        {
            playerView.Stop();
            playerView.Dispose();
            playerView = null;

            Unparent();
            Dispose();
            ApplicationHelper.DeactivateBlur();
            DeletedPopup?.Invoke(null, null);
        }
        public event EventHandler DeletedPopup;
    }
}
