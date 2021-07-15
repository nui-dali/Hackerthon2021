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
using Tizen.NUI;
using Tizen.NUI.Components;
using System.IO;

namespace NUIKioskPoster
{
    public partial class MainView : GaussianBlurView
    {
        public MainView() : base(20, 8.0f, PixelFormat.RGBA8888, 1.0f, 1.0f, false)
        {
            InitializeComponent();
            LoadAllResources();
            InitializePagination();

            if (ApplicationHelper.IsLandscape())
            {
                carouselView.SizeWidth = Window.Instance.WindowSize.Width * 0.3f;
            }
        }

        private void LoadAllResources()
        {
            int idx = 0;
            List<ItemModel> itemList = new List<ItemModel>();
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo($"{ApplicationHelper.ResoucePath}/images/poster/");

            foreach (System.IO.FileInfo File in directoryInfo.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".png") == 0)
                {
                    itemList.Add(new ItemModel(File.FullName, Resources.DATE_TIME[idx].title, Resources.DATE_TIME[idx].date, $"{Resources.DATE_TIME[idx].time} Minutes"));
                    idx++;
                }
            }
            carouselView.ItemList = itemList;
        }

        private void InitializePagination()
        {
            //Binding is not support yet.
            pagination.IndicatorCount = carouselView.TotalPage;
            pagination.SelectedIndex = carouselView.CurrentIndex;
        }

        private void LeftBtn_Clicked(object sender, ClickedEventArgs e)
        {
            carouselView.PrevPage();
            pagination.SelectedIndex = carouselView.CurrentIndex;
        }

        private void RightBtn_Clicked(object sender, ClickedEventArgs e)
        {
            carouselView.NextPage();
            pagination.SelectedIndex = carouselView.CurrentIndex;
        }
    }
}
