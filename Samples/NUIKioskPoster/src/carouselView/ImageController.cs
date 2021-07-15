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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace NUIKioskPoster
{
    public class ImageController
    {
        private Size currentSize;
        private Animation controlAnimation;
        private CarouselView carouselView;
        private View currentView;
        private PageDirection currentDirection;
        private ImageSizeModel imageSizeModel;

        private int currentIndex = 0;

        private List<ItemModel> itemList;

        public ImageController()
        {
        }


        public void InitImages()
        {
            var container = carouselView.container;
            imageSizeModel = carouselView.ImageSizeModel;

            for (int i = 0; i < container.ChildCount; i++)
            {
                var child = container.Children[i] as ImageView;
                child.BindingContext = imageSizeModel;
                child.SetBinding(ImageView.SizeProperty, "UnSelectedSize");
                child.ResourceUrl = ItemList[i].ResourceUrl;
            }

            currentIndex = container.Children.Count / 2;
            currentView = container.Children[currentIndex] as ImageView;
            currentView.SetBinding(ImageView.SizeProperty, "SelectedSize");

            carouselView.popupInfoView.SetViewModel(ItemList[CurrentItemIndex]);
        }

        private void DestroyAndCreateAnimation(int milliSeconds = 1000)
        {
            if (controlAnimation)
            {
                controlAnimation.Stop();
                controlAnimation.Dispose();
                controlAnimation = null;
            }
            controlAnimation = new Animation(milliSeconds);
            controlAnimation.EndAction = Animation.EndActions.StopFinal;
            controlAnimation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut);
        }

        private void MovingAnimationFinished(object sender, EventArgs e)
        {
            DestroyAndCreateAnimation(200);
            controlAnimation.AnimateTo(carouselView.popupInfoView, "Opacity", 1.0f);
            controlAnimation.Play();
            carouselView.popupInfoView.SetViewModel(ItemList[CurrentItemIndex]);
            (carouselView.container.Layout as CustomFocusLinearLayout).IsAnimating = true;

            ImageView item;
            var container = carouselView.container;
            int reloadItem = currentIndex;
            switch (currentDirection)
            {
                case PageDirection.Right:
                    reloadItem += 2;
                    if (reloadItem >= ItemList.Count)
                    {
                        reloadItem = reloadItem % ItemList.Count;
                    }
                    item = container.Children[container.Children.Count - 1] as ImageView;
                    item.ResourceUrl = ItemList[reloadItem].ResourceUrl;
                    //item.Size = imageSizeModel.UnSelectedSize;
                    break;
                case PageDirection.Left:
                    reloadItem -= 2;
                    if (reloadItem < 0)
                    {
                        reloadItem = ItemList.Count + reloadItem;
                    }
                    item = (container.Children[0] as ImageView);
                    item.ResourceUrl = ItemList[reloadItem].ResourceUrl;
                    //item.Size = imageSizeModel.UnSelectedSize;
                    break;
            }

            //Temporary fix - size issue after animating
            foreach(var child in container.Children)
            {
                child.Size = imageSizeModel.UnSelectedSize;
            }
            currentView.Size = imageSizeModel.SelectedSize;
        }

        public void MovePage(PageDirection direction)
        {
            var container = carouselView.container;

            var centerIndex = container.Children.Count / 2;
            var centerItem = container.Children[centerIndex];

            var startView = container.Children[0];
            var lastView = container.Children[container.Children.Count - 1];

            currentDirection = direction;
            carouselView.popupInfoView.Opacity = 0.0f;

            DestroyAndCreateAnimation();
            controlAnimation.AnimateTo(centerItem, "Size", imageSizeModel.UnSelectedSize);

            switch (direction)
            {
                case PageDirection.Right:
                    RightMove(container, startView, lastView);
                    RightBGMove(carouselView.gradientBG);
                    CurrentItemIndex++;
                    break;

                case PageDirection.Left:
                    LeftMove(container, startView, lastView);
                    LeftBGMove(carouselView.gradientBG);
                    CurrentItemIndex--;
                    break;
            }

            currentView = container.Children[centerIndex];

            controlAnimation.AnimateTo(currentView, "Size", imageSizeModel.SelectedSize);
            controlAnimation.Finished += MovingAnimationFinished;
            controlAnimation.Play();
        }

        private void RightMove(View container, View startView, View lastView)
        {
            var prePosition = startView.Position;
            startView.Position = lastView.Position;
            for (int i = 1; i < container.Children.Count; i++)
            {
                controlAnimation.AnimateTo(container.Children[i], "Position", prePosition);
                prePosition = container.Children[i].Position;
            }

            container.Children.RemoveAt(0);
            container.Children.Add(startView);
        }

        private void LeftMove(View container, View startView, View lastView)
        {
            var prePosition = lastView.Position;
            lastView.Position = startView.Position;

            for (int i = container.Children.Count - 2; i >= 0; i--)
            {
                controlAnimation.AnimateTo(container.Children[i], "Position", prePosition);
                prePosition = container.Children[i].Position;
            }
            container.Children.RemoveAt(container.Children.Count - 1);
            container.Children.Insert(0, lastView);

        }

        private void RightBGMove(View gradientVisual)
        {
            if(ApplicationHelper.IsLandscape())
            {
                return;
            }
            if (gradientVisual.PositionX - (currentSize.Width / 2) >= -currentSize.Width)
            {
                controlAnimation.AnimateBy(gradientVisual, "PositionX", -currentSize.Width);
            }
            else
            {
                gradientVisual.PositionX = 0;
            }
        }

        private void LeftBGMove(View gradientVisual)
        {
            if (ApplicationHelper.IsLandscape())
            {
                return;
            }
            if (gradientVisual.PositionX + (currentSize.Width / 2) >= currentSize.Width)
            {
                controlAnimation.AnimateBy(gradientVisual, "PositionX", currentSize.Width / 2);
            }
            else
            {
                gradientVisual.PositionX = -currentSize.Width;
            }
        }

        public int CurrentIndex => currentIndex;

        public List<ItemModel> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
                InitImages();
            }
        }

        public CarouselView CarouselView
        {
            set
            {
                carouselView = value;
                carouselView.Relayout += CarouselView_Relayout;
            }
        }

        private void CarouselView_Relayout(object sender, EventArgs e)
        {
            currentSize = carouselView.Size;
            imageSizeModel.CalcuateSize(carouselView.Size);
        }

        public int CurrentItemIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                if (value < 0)
                {
                    value = ItemList.Count - 1;
                }
                else if (value > ItemList.Count - 1)
                {
                    value = 0;
                }
                currentIndex = value;
            }
        }

        public enum PageDirection
        {
            Right,
            Left
        }
    }
}
