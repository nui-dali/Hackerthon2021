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
using System.Globalization;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace NUIKioskPoster
{
    public class ExtentsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Extents extents)
            {
                var widthRatio = (Window.Instance.Size.Width / 1080.0f);
                var heightRatio = (Window.Instance.Size.Height / 1920.0f);
                var start = (ushort)(extents.Start * widthRatio);
                var end = (ushort)(extents.End * widthRatio);
                var top = (ushort)(extents.Top * heightRatio);
                var bottom = (ushort)(extents.Bottom * heightRatio);

                return new Extents(start, end, top, bottom);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
