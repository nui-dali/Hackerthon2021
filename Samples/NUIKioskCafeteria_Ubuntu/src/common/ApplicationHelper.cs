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

using System.Collections.Generic;
using Tizen.Applications;
using Tizen.NUI;

namespace NUIKioskCafeteria
{
    public static class ApplicationHelper
    {

        public static readonly string ResoucePath = Application.Current.DirectoryInfo.Resource;

        public static GaussianBlurView MainGaussianBlurView = null;

        public static List<MenuItem> OrderList = new List<MenuItem>();

        public static bool IsEmulator()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/system/model_name", out value);
            return (result && value.Equals("Emulator"));
        }

        public static void ActivateBlur()
        {
//            if (!IsEmulator())
            {
                MainGaussianBlurView?.Activate();
            }
        }

        public static void DeactivateBlur()
        {
//            if (!IsEmulator())
            {
                MainGaussianBlurView?.Deactivate();
            }
        }

        public static float GetPortraitWidth()
        {
            var width = 0.0f;
            if (Window.Instance.Size.Width < Window.Instance.Size.Height)
            {
                width = Window.Instance.Size.Width;

            }
            else
            {
                width = Window.Instance.Size.Height;
            }
            return width;
        }
    }
}
