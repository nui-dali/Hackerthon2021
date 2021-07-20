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

using System.Collections.ObjectModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace NUIKioskCafeteria
{
    public partial class MenuPage : ContentControlPage, INextPage
    {
        private ContentPage nextEmptyPage;
        private CollectionView colView;

        public MenuPage()
        {
            InitializeComponent();
            InitializeCollectionList();
            nextEmptyPage = new EmptyOrderPage();
        }


        public void InitializeCollectionList()
        {
            ObservableCollection<Album> albumSource = new ObservableCollection<Album>();
            foreach(var i in Resources.SelectIndexArray)
            {
                Tizen.Log.Error("MYLOG", "i : " + i);
                albumSource.CreateData(i);
            }

            colView = new CollectionView()
            {
                HideScrollbar = false,

                ItemsSource = albumSource,
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    var item = new DefaultMenuItem();
                    item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                    item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                    item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    return item;
                }),
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    DefaultTitleItem group = new DefaultTitleItem();
                    group.BackgroundColor = Tizen.NUI.Color.Transparent;
                    group.WidthSpecification = LayoutParamPolicies.MatchParent;

                    group.Label.TextColor = new Tizen.NUI.Color("#7474FF");
                    group.Label.PixelSize = 20;
                    group.Label.SetBinding(TextLabel.TextProperty, "Title");
                    group.Label.HeightSpecification = 60;
                    group.Label.HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin;

                    return group;
                }),
                IsGrouped = true,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                SelectionMode = ItemSelectionMode.Single,
                Weight = 0.9f,
            };
            contentView.Add(colView);
        }

        public ContentPage NextPage()
        {
            if (OrderManager.Instance.GallerySource.Count > 0)
            {
                return new OrderPage();
            }
            else
            {
                return nextEmptyPage;
            }
        }
    }
}
