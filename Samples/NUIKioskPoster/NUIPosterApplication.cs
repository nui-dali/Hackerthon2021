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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIKioskPoster
{
    public class NUIPosterApplication : NUIApplication
    {
        override protected void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            ThemeManager.ApplyTheme(new Theme(ApplicationHelper.ResoucePath + "theme/Theme.xaml"));

            GetDefaultWindow().AddAvailableOrientation(Window.WindowOrientation.Portrait);
            GetDefaultWindow().SetPreferredOrientation(Window.WindowOrientation.Portrait);
            GetDefaultWindow().KeyEvent += Window_KeyEvent;

            GetDefaultWindow().Add(new MainView());
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            new NUIPosterApplication().Run(args);
        }
    }
}
