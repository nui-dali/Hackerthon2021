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
using Tizen.NUI.BaseComponents;

namespace NUIKioskPoster
{
    public partial class CarouselView : View
    {
        //Fixed Item count is 5
        private int ITEM_COUNT = 5;

        private ImageController controller = new ImageController();

        public CarouselView()
        {
            InitializeComponent();
            InitializeItems();

            //C# code - Use GradientVisual
            //BackgroundVisual = CreateGradientBackground();
            //BackgroundVisual = new GradientTemplateVisual();
        }

        private GradientVisual CreateGradientBackground()
        {
            var visual = new GradientVisual()
            {
                StartPosition = new Vector2(-0.5f, 0.0f),
                EndPosition = new Vector2(0.5f, 0.0f),
                SpreadMethod = 0,
            };

            PropertyArray stopPosition = new PropertyArray();
            stopPosition.Add(new PropertyValue(0.0f));
            stopPosition.Add(new PropertyValue(0.25f));
            stopPosition.Add(new PropertyValue(0.5f));
            stopPosition.Add(new PropertyValue(0.75f));
            stopPosition.Add(new PropertyValue(1.0f));
            visual.StopOffset = stopPosition;

            PropertyArray colorArray = new PropertyArray();
            colorArray.Add(new PropertyValue(new Color("#21203F")));
            colorArray.Add(new PropertyValue(new Color("#362950")));
            colorArray.Add(new PropertyValue(new Color("#3A379C")));
            colorArray.Add(new PropertyValue(new Color("#362950")));
            colorArray.Add(new PropertyValue(new Color("#21203F")));
            visual.StopColor = colorArray;

            return visual;
        }

        private void InitializeItems()
        {
            controller.CarouselView = this;

            for (int i = 0; i < ITEM_COUNT; i++)
            {
                container.Add(new CarouselItem($"item-{i}"));
            }
        }

        public void NextPage()
        {
            controller.MovePage(ImageController.PageDirection.Right);

        }
        public void PrevPage()
        {
            controller.MovePage(ImageController.PageDirection.Left);
        }

        public VisualMap BackgroundVisual
        {
            set
            {
                gradientBG.AddVisual("Linear_Gradient", value);
            }
        }

        public int CurrentIndex => controller?.CurrentIndex ?? 0;

        public int TotalPage => controller?.ItemList?.Count ?? 0;

        public List<ItemModel> ItemList
        {
            set
            {
                controller.ItemList = value;
            }
        }
    }
}
