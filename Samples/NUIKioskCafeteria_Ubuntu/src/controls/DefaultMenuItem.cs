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

namespace NUIKioskCafeteria
{
    public class DefaultMenuItem : RecyclerViewItem
    {
        private Button btn;
        private ImageView image;
        private TextLabel label_name;
        private TextLabel label_price;
        private int index;
        public DefaultMenuItem()
        {
            BackgroundColor = Color.Transparent;
            var sizeWidth = (int)(ApplicationHelper.GetPortraitWidth() * 0.3f);
            WidthSpecification = sizeWidth;
            HeightSpecification = sizeWidth;
            Margin = new Extents(10, 10, 30, 0);

            btn = new Button()
            {
                StyleName = "GalleryButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                PositionUsesPivotPoint = true,

            };
            btn.Clicked += Btn_Clicked;
            Add(btn);
            image = new ImageView()
            {
                WidthSpecification = (int)(sizeWidth * 0.73f),
                HeightSpecification = (int)(sizeWidth * 0.73f),
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            Add(image);

            View bottomLayoutView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
            };
            Add(bottomLayoutView);
            label_name = new TextLabel()
            {
                PixelSize = sizeWidth * 0.07f,
                SizeWidth = sizeWidth * 0.65f,
                Ellipsis = false,
                MultiLine = true,
                TextColor = new Color("#7474FF"),
                HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                PositionUsesPivotPoint = true,
                Padding = new Extents((ushort)(sizeWidth * 0.15f), 0, 0, 0),
            };

            label_price = new TextLabel()
            {
                PixelSize = sizeWidth * 0.07f,
                TextColor = new Color("#7474FF"),
                HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                PivotPoint = Tizen.NUI.PivotPoint.BottomRight,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomRight,
                PositionUsesPivotPoint = true,
                Padding = new Extents(0, (ushort)(sizeWidth * 0.15f), 0, 0),
            };
            bottomLayoutView.Add(label_name);
            bottomLayoutView.Add(label_price);
        }

        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            var btnTag = "ButtonTag" + label_name.Text + (BindingContext as MenuItem).Index;
            var imgTag = "ImageTag" + label_name.Text + (BindingContext as MenuItem).Index;

            btn.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = btnTag,
            };
            image.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = imgTag,
            };

            ItemPopup.Instance.BindingContext = this.BindingContext;
            ItemPopup.Instance.SetItemTag(btnTag, imgTag);
            ItemPopup.Instance.ShowPopup();
        }

        public ImageView Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public TextLabel NameLabel
        {
            get
            {
                return label_name;
            }
            set
            {
                label_name = value;
            }
        }

        public TextLabel PriceLabel
        {
            get
            {
                return label_price;
            }
            set
            {
                label_price = value;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
    }
}
