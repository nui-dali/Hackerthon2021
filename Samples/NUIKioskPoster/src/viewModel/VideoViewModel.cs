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
using System.ComponentModel;

namespace NUIKioskPoster
{
    public class VideoViewModel : INotifyPropertyChanged
    {
        private TimeSpan totalDuration;
        private TimeSpan playPosition;
        private string scrollTime;


        public VideoViewModel()
        {

        }

        public TimeSpan TotalDuration
        {
            get
            {
                return totalDuration;
            }
            set
            {
                totalDuration = value;
                ScrollTime = $"{playPosition.Minutes}:{playPosition.Seconds} / {totalDuration.Minutes}:{totalDuration.Seconds}";
            }
        }

        public TimeSpan PlayPosition
        {
            get
            {
                return playPosition;
            }
            set
            {
                playPosition = value;
                ScrollTime = $"{playPosition.Minutes}:{playPosition.Seconds} / {totalDuration.Minutes}:{totalDuration.Seconds}";
            }
        }

        public string ScrollTime
        {
            get
            {
                return scrollTime;
            }
            set
            {
                scrollTime = value;
                OnPropertyChanged(nameof(ScrollTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
