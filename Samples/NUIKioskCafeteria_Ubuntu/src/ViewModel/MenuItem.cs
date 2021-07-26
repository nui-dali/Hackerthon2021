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

using System.ComponentModel;
using static NUIKioskCafeteria.Resources;

namespace NUIKioskCafeteria
{
    public class MenuItem : INotifyPropertyChanged
    {
        private int index;
        private string name;
        private string resource;
        private string price;
        private string description;
        private MenuType menuType;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MenuItem(MenuType type, int galleryIndex, string galleryName, string res, string pri, string des)
        {
            menuType = type;
            index = galleryIndex;
            name = galleryName;
            resource = res;
            price = pri;
            description = des;
        }

        public int Index => index;


        public string NameLabel
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyyChanged("NameLabel");
            }
        }

        public string ImageUrl
        {
            get
            {
                return ApplicationHelper.ResoucePath + "/images/menu/" + resource;
            }
            set
            {
                resource = value;
                OnPropertyyChanged("ImageUrl");
            }
        }

        public string PriceLabel
        {
            get
            {
                return $"${price}";
            }
            set
            {
                price = value;
                OnPropertyyChanged("PriceLabel");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyyChanged("Description");
            }
        }

        public MenuType MenuType
        {
            get
            {
                return menuType;
            }
            set
            {
                menuType = value;
                OnPropertyyChanged("MenuType");
            }
        }
    }
}
