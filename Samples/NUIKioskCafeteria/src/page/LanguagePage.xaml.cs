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
using Tizen.NUI.Components;

namespace NUIKioskCafeteria
{
    public partial class LanguagePage : ContentControlPage, INextPage
    {
        private MenuSelectPage nextPage;
        public LanguagePage()
        {
            InitializeComponent();
            nextPage = new MenuSelectPage();
        }

        public ContentPage NextPage()
        {
            return nextPage;
        }

        protected override void NextPageClicked(object sender, ClickedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "American":
                    case "Korean":
                    case "Chinese":
                        base.NextPageClicked(sender, e);
                        break;
                }
            }
        }
    }
}
