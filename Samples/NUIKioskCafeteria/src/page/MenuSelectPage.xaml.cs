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
using static NUIKioskCafeteria.Resources;

namespace NUIKioskCafeteria
{
    public partial class MenuSelectPage : ContentControlPage, INextPage
    {
        private ContentPage nextPage;
        private MenuPage nextPage_1;
        private MenuPage nextPage_2;

        public MenuSelectPage()
        {
            InitializeComponent();
            var width = ApplicationHelper.GetPortraitWidth();
            foreach (var item in bottomView.Children)
            {
                item.Size = new Tizen.NUI.Size(width * 0.3f, width * 0.3f);
            }

            //Create Drink Menu Page
            Resources.SelectIndexArray.Clear();
            Resources.SelectIndexArray.Add(Resources.MenuType.HOT_DRINK);
            Resources.SelectIndexArray.Add(Resources.MenuType.COLD_DRINK);
            nextPage_1 = new MenuPage();

            //Create Desserts Menu Page
            Resources.SelectIndexArray.Clear();
            Resources.SelectIndexArray.Add(Resources.MenuType.DESSERTS);
            Resources.SelectIndexArray.Add(Resources.MenuType.CAKES);
            nextPage_2 = new MenuPage();

            //Create instance of ItemPopup
            _ = ItemPopup.Instance;
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
                    case "Drink":
                        nextPage = nextPage_1;
                        break;
                    case "Desserts":
                        nextPage = nextPage_2;
                        break;
                }
            }
            base.NextPageClicked(sender, e);
        }

        private void MenuItemView_ItemClicked(object sender, ClickedEventArgs e)
        {
            if (sender is MenuItemView item)
            {
                (MenuType type, string name, string res, string price) = GetMenu(item.NameLabel);

                ItemPopup.Instance.BindingContext = (new Gallery(type, -1, name, res, price, "This is a short description of product. This is a short description of product. "));
                ItemPopup.Instance.SetItemTag(item.ButtonTag, item.ImageTag);
                ItemPopup.Instance.ShowPopup();
            }
            ///ItemPopup.Instance.SetItemContent(ButtonTag, ImageTag, ItemImageUrl);
        }

        private (MenuType type, string name, string res, string price) GetMenu(string label)
        {
            MenuType _type = 0;
            string _name = "";
            string _res = "";
            string _price = "";

            switch (label)
            {
                case "Nougat Tarlet":
                    _type = MenuType.DESSERTS;
                    (_name, _res, _price) = Resources.dessertsPool[3];
                    break;
                case "Cherry":
                    _type = MenuType.DESSERTS;
                    (_name, _res, _price) = Resources.dessertsPool[4];
                    break;
                case "Espresso":
                    _type = MenuType.HOT_DRINK;
                    (_name, _res, _price) = Resources.hotDrinkPool[0];
                    break;

            }
            return (_type, _name, _res, _price);

        }

        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            if (CurrentIPage == null)
            {
                Tizen.Log.Error("NUI", "Push error, CurrentIPage is null");
                return;
            }

            if (OrderManager.Instance.GallerySource.Count > 0)
            {
                Navigator.Push(new OrderPage());
            }
            else
            {
                Navigator.Push(new EmptyOrderPage());
            }
        }

    }
}
