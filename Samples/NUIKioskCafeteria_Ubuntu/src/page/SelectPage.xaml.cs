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
using Tizen.NUI.Components;

namespace NUIKioskCafeteria
{
    public partial class SelectPage : ContentControlPage
    {
        private LanguagePage nextPage;
        public SelectPage()
        {
            InitializeComponent();
            nextPage = new LanguagePage();
            selectNavigator.Push(nextPage);
            RemovedFromWindow += SelectPage_RemovedFromWindow;

            ApplicationHelper.MainGaussianBlurView = contentView;
        }

        private void SelectPage_RemovedFromWindow(object sender, System.EventArgs e)
        {
            ResetPage();
        }

        public void ResetPage()
        {
            int cnt = selectNavigator.PageCount;
            if (cnt > 1)
            {
                for (int i = 0; i < cnt - 1; i++)
                {
                    selectNavigator.RemoveAt(1);
                }
            }
        }

        private bool StartButtonTouchEvent(object source, TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Navigator.Pop();
            }
            return false;
        }
    }
}
