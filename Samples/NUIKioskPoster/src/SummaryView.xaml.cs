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
using Tizen.NUI.Components;

namespace NUIKioskPoster
{
    public partial class SummaryView : View
    {
        public SummaryView()
        {
            InitializeComponent();
        }

        private void MoreInfoBtn_Clicked(object sender, ClickedEventArgs e)
        {
            summaryContainer.Hide();

            var popup = new InfoPopup();
            popup.ContentViewModel = ViewModel;
            popup.DeletedPopup += Popup_DeletedPopup;
            var parent = (GetParent() as View);
            var popupSize = (ApplicationHelper.IsLandscape() ? new Tizen.NUI.Size(Window.Instance.WindowSize.Width * 0.8f, parent.SizeHeight) : parent.Size);
            popup.ShowPopup(popupSize);
        }

        private void VideoBtn_Clicked(object sender, ClickedEventArgs e)
        {
            var popup = new VideoPopup();
            popup.DeletedPopup += Popup_DeletedPopup;
            popup.ShowPopup((GetParent() as View).Size);
        }

        private void Popup_DeletedPopup(object sender, System.EventArgs e)
        {
            summaryContainer.Show();
        }

        public void SetViewModel(ItemModel model)
        {
            ViewModel.SetModel(model);
        }
    }
}
