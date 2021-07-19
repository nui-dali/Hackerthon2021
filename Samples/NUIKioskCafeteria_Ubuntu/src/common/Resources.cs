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
using System.Collections.ObjectModel;

namespace NUIKioskCafeteria
{
    static public class Resources
    {
        public static (string name, string res, string price)[] hotDrinkPool = {
            ("Espresso", "espresso.png", "1.50"),
            ("Americano", "americano.png", "1.90"),
            ("Flat white", "flat_white.png", "2.50"),
            ("Cappuccino", "cappuccino.png", "3.20"),
            ("CaffeLatte", "llatte.png", "4.00"),
            ("Black tea", "black_tea.png", "3.00"),
            ("English breakfast", "english_breakfast.png", "3.00"),
            ("Yasmine Green Tea", "green_tea.png", "3.00"),
            ("Roiboos", "roibos_tea.png", "3.00")
        };
        public static (string name, string res, string price)[] coldDrinkPool = {
            ("Still water", "still_water.png", "1.20"),
            ("Sparkling water", "sparkling.png", "1.20"),
            ("Lemonade", "lemonade.png", "2.20"),
            ("Watermelon lemonade", "watermelon_lemonade.png", "2.50"),
            ("Mango lemonade", "mango_lemonade_black.png", "2.50"),
            ("Coke", "coke.png", "2.50"),
            ("Cold brew", "coldbrew.png", "3.80"),
            ("Iced coffee with milk", "coldwithmilk.png", "4.20"),
            ("Espresso tonic", "espressotonic.png", "4.20")
        };
        public static (string name, string res, string price)[] dessertsPool = {
            ("Macarones", "macarons.png", "1.90"),
            ("Cinnamon Bun", "cinnabon_bun.png", "1.90"),
            ("Mango Tarlet", "sweet_tropical.png", "2.50"),
            ("Nougat Tartler", "nougat_tarlet.png", "4.00"),
            ("Cherry chocolate", "cherry.png", "3.20"),
        };
        public static (string name, string res, string price)[] cakePool = {
            ("Carrot cake", "carrot.png", "3.80"),
            ("Cheesecake", "cheesecake.png", "4.20"),
            ("Carrot cake", "carrot.png", "3.80"),
            ("Cheesecake", "cheesecake.png", "4.20"),
        };

        public static (string groupName, (string name, string res, string price)[] menu)[] GroupPool = {
            ("Hot drinks", hotDrinkPool),
            ("Cold drinks", coldDrinkPool),
            ("Desserts", dessertsPool),
            ("Cakes", cakePool),
        };

        public static ObservableCollection<Album> CreateData(this ObservableCollection<Album> result, MenuType menuType)
        {
            var selectIndex = (int)menuType;
            var cur = new Album(selectIndex, GroupPool[selectIndex].groupName);
            for (int j = 0; j < GroupPool[selectIndex].menu.Length; j++)
            {
                var name = GroupPool[selectIndex].menu[j].name;
                var res = GroupPool[selectIndex].menu[j].res;
                var price = GroupPool[selectIndex].menu[j].price;
                cur.Add(new Gallery(menuType, j, name, res, price, "This is a short description of product. This is a short description of product. "));
            }
            result.Add(cur);
            return result;
        }

        static public List<MenuType> SelectIndexArray = new List<MenuType>();

        public enum MenuType
        {
            HOT_DRINK = 0,
            COLD_DRINK = 1,
            DESSERTS = 2,
            CAKES = 3,
        }
    }
}
