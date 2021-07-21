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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIKioskCafeteria
{
    public partial class MenuItemView : View
    {
        public MenuItemView()
        {
            InitializeComponent();
        }

        public string ButtonTag
        { 
            get
            {
                return MainButton.TransitionOptions?.TransitionTag ?? "";
            }
            set
            {
                MainButton.TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = value
                };
            }
        }

        public string ImageTag
        {
            get
            {
                return MainButton.Icon.TransitionOptions?.TransitionTag ?? "";
            }
            set
            {
                MainButton.Icon.TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = value
                };
            }
        }


        public string NameLabel
        {
            get
            {
                return NameTextLabel.Text;
            }
            set
            {
                NameTextLabel.Text = value;
            }
        }
        public string PriceLabel
        {
            get
            {
                return PriceTextLabel.Text;
            }
            set
            {
                PriceTextLabel.Text = value;
            }
        }

        public string ItemImageUrl
        {
            get
            {
                return MainButton.IconURL;
            }
            set
            {
                MainButton.IconURL = value;
            }
        }

        public event EventHandler<ClickedEventArgs> ItemClicked;

        private void MainButton_Clicked(object sender, ClickedEventArgs e)
        {
            ItemClicked?.Invoke(this, e);
        }

        public void SetSmallItem()
        {
            NameTextLabel.Position = new Position(20, 0);
            PriceTextLabel.Position = new Position(20, 15);
            PriceTextLabel.PivotPoint = Tizen.NUI.PivotPoint.BottomLeft;
            PriceTextLabel.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
        }
    }
}
