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
    public class DefaultOrdertem : RecyclerViewItem
    {
        private Button btn;
        private ImageView image;
        private TextLabel label_name;
        private TextLabel label_price;
        private Animation deleteAnimation;
        private int index;
        public DefaultOrdertem()
        {
            BackgroundColor = Color.Transparent;
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = 190;
            Margin = new Extents(0, 0, 10, 0);
            deleteAnimation = new Animation(500);

            btn = new Button()
            {
                StyleName = "SecondaryIconButton",
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
                WidthSpecification = 140,
                HeightSpecification = 140,
                Position = new Position(50, 0),
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
            };
            Add(image);

            View bottomLayoutView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            Add(bottomLayoutView);
            PropertyMap map = new PropertyMap();
            map.Add("weight", new PropertyValue("bold"));
            label_name = new TextLabel()
            {
                PixelSize = 25,
                Position = new Position(200, 50),
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Ellipsis = false,
                MultiLine = true,
                TextColor = new Tizen.NUI.Color("#7474FF"),
                FontStyle = map,
            };

            label_price = new TextLabel()
            {
                PixelSize = 20,
                Position = new Position(-70, 53),
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                TextColor = new Tizen.NUI.Color("#7474FF"),
                PivotPoint = Tizen.NUI.PivotPoint.TopRight,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopRight,
                PositionUsesPivotPoint = true,
            };

            PropertyMap underlineMap = new PropertyMap();
            underlineMap.Add("enable", new PropertyValue("true"));

            TextLabel edit = new TextLabel()
            {
                Text="Delete",
                PixelSize=16,
                Position = new Position(-70, -50),
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                TextColor = new Color("#7474FF"),
                PivotPoint = Tizen.NUI.PivotPoint.BottomRight,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomRight,
                PositionUsesPivotPoint = true,
                Underline = underlineMap,
            };
            edit.TouchEvent += Edit_TouchEvent;

            bottomLayoutView.Add(label_name);
            bottomLayoutView.Add(label_price);
            bottomLayoutView.Add(edit);
        }

        private bool Edit_TouchEvent(object source, TouchEventArgs e)
        {
            if(e.Touch.GetState(0) == PointStateType.Up)
            {
                deleteAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine);
                deleteAnimation.AnimateBy(this, "PositionX", -800);
                deleteAnimation.Play();
                deleteAnimation.Finished += DeleteAnimation_Finished;
            }
            return false;
        }

        private void DeleteAnimation_Finished(object sender, EventArgs e)
        {
            OrderManager.Instance.GallerySource.Remove(BindingContext as Gallery);
        }

        public Animation DeleteAnimation => deleteAnimation;

        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            var btnTag = "OrderButtonTag" + label_name.Text + (BindingContext as Gallery).Index;
            var imgTag = "OrderImageTag" + label_name.Text + (BindingContext as Gallery).Index;

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
