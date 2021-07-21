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

using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIKioskPoster
{
    public static class ApplicationHelper
    {
        public static HeightConverter HeightConverter => new HeightConverter();

        public static SizeConverter SizeConverter => new SizeConverter();

        public static ExtentsConverter ExtentsConverter => new ExtentsConverter();

        public static string ResoucePath = Application.Current.DirectoryInfo.Resource;

        public static void ShowPopup(this View view, Size size)
        {
            view.Size = size;
            NUIApplication.GetDefaultWindow().Add(view);
            ActivateBlur();
        }

        public static bool IsLandscape()
        {
            return (Window.Instance.GetPreferredOrientation() == Window.WindowOrientation.Landscape);
        }

        public static Size GetPortraitSize()
        {
            var width = 0.0f;
            var height = 0.0f;
            if (Window.Instance.Size.Width < Window.Instance.Size.Height)
            {
                width = Window.Instance.Size.Width;
                height = Window.Instance.Size.Height;

            }
            else
            {
                width = Window.Instance.Size.Height;
                height = Window.Instance.Size.Width;
            }
            return new Size(width, height);
        }

        public static (float wRatio, float hRatio) GetWindowRatio()
        {
            var wRatio = 0.0f;
            var hRatio = 0.0f;
            if (Window.Instance.Size.Width < Window.Instance.Size.Height)
            {
                wRatio = Window.Instance.Size.Width / 1080.0f;
                hRatio = Window.Instance.Size.Height / 1920.0f;

            }
            else
            {
                wRatio = Window.Instance.Size.Height / 1080.0f;
                hRatio = Window.Instance.Size.Width / 1920.0f;
            }
            return (wRatio, hRatio);
        }

        public static Size GetCalculateSize(this Size size)
        {
            (float wRatio, float hRatio) = GetWindowRatio();
            return new Size(size.Width * wRatio, size.Height * hRatio);
        }

        public static Size GetCalculateSquareSize(this Size size)
        {
            float wRatio = GetWindowRatio().wRatio;
            return new Size(size.Width * wRatio, size.Height * wRatio);
        }

        public static Extents GetCalculateExtents(this Extents value)
        {
            (float wRatio, float hRatio) = GetWindowRatio();
            ushort start = (ushort)(value.Start * wRatio);
            ushort end = (ushort)(value.End * wRatio);
            ushort top = (ushort)(value.Top * hRatio);
            ushort bottom = (ushort)(value.Bottom * hRatio);

            return new Extents(start, end, top, bottom);
        }

        public static bool IsEmulator()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/system/model_name", out value);
            return (result && value.Equals("Emulator"));
        }

        public static void ActivateBlur()
        {
            if (!IsEmulator())
            {
                (NUIApplication.GetDefaultWindow().GetDefaultLayer().Children[0] as GaussianBlurView).Activate();
            }
        }

        public static void DeactivateBlur()
        {
            if (!IsEmulator())
            {
                (NUIApplication.GetDefaultWindow().GetDefaultLayer().Children[0] as GaussianBlurView).Deactivate();
            }
        }
    }
}
