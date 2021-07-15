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
    public partial class ProcessingPage : ContentControlPage, INextPage
    {
        private Timer NextPageTimer;
        public ProcessingPage()
        {
            InitializeComponent();
            loadingView.Play();

            NextPageTimer = new Timer(3000);
            NextPageTimer.Tick += Timer_Tick;
            NextPageTimer.Start();
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            Navigator.Push(NextPage());
            return false;
        }

        public ContentPage NextPage()
        {
            return new FinishPage();
        }
    }
}
