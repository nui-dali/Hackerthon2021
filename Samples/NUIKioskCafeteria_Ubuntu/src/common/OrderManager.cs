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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NUIKioskCafeteria
{
    public class OrderManager : INotifyPropertyChanged
    {
        public static OrderManager instance;
        private ObservableCollection<Gallery> gallerySource;
        private string totalPrice;
        public static OrderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderManager();
                }
                return instance;
            }
        }

        public OrderManager()
        {
            gallerySource = new ObservableCollection<Gallery>();
            GallerySource.CollectionChanged += GallerySource_CollectionChanged;
        }

        public void ResetOrder()
        {
            gallerySource.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GallerySource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            double sum = 0;
            foreach (var item in GallerySource)
            {
                float outValue = 0.0f;
                bool pass = float.TryParse(item.PriceLabel.Replace("$", ""), out outValue);
                sum += outValue;
            }
            sum = Math.Round(sum, 2);
            TotalPrice = $"{sum}";
        }

        public ObservableCollection<Gallery> GallerySource => gallerySource;

        public string TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = $"Total Price : $ {value}";
                OnPropertyyChanged("TotalPrice");
            }
        }
    }
}
