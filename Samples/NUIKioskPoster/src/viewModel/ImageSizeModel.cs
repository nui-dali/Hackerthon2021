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

using System.ComponentModel;
using Tizen.NUI;

namespace NUIKioskPoster
{
    public class ImageSizeModel : INotifyPropertyChanged
    {
        private Size unSelectedSize;
        private Size selectedSize;

        private Size gradientSize;
        private Size popupInfoSize;

        public ImageSizeModel()
        {
        }

        public void CalcuateSize(Size size)
        {
            var width = size.Width;
            var height = size.Height;

            GradientSize = new Size(width * 3, height);
            if (ApplicationHelper.IsLandscape())
            {
                //if application's mode is landscape, use Window Size
                GradientSize = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height);
            }
            SelectedSize = new Size(width * 0.74f, height * 0.62f);
            UnSelectedSize = new Size(width * 0.55f, height * 0.46f);

            PopupInfoSize = new Size(SelectedSize.Width, SelectedSize.Height * 0.32f);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Size GradientSize
        {
            get
            {
                return gradientSize;
            }
            set
            {
                gradientSize = value;
                OnPropertyChanged(nameof(GradientSize));
            }
        }

        public Size PopupInfoSize
        {
            get
            {
                return popupInfoSize;
            }
            set
            {
                popupInfoSize = value;
                OnPropertyChanged(nameof(PopupInfoSize));
            }
        }

        public Size UnSelectedSize
        {
            get
            {
                return unSelectedSize;
            }
            set
            {
                unSelectedSize = value;
                OnPropertyChanged(nameof(UnSelectedSize));
            }
        }

        public Size SelectedSize
        {
            get
            {
                return selectedSize;
            }
            set
            {
                selectedSize = value;
                OnPropertyChanged(nameof(SelectedSize));
            }
        }
    }
}
