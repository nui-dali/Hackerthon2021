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

namespace NUIKioskPoster
{
    public partial class VideoCustomSlider : View
    {
        private PanGestureDetector panGestureDetector;
        private bool isSelectedHandler = false;
        private float currentValue;

        public VideoCustomSlider()
        {
            InitializeComponent();

            var borderVisualMap1 = new BorderVisual();
            borderVisualMap1.Color = new Color("#546EE5");
            borderVisualMap1.BorderSize = 1.0f;
            mainVisual.AddVisual("borderVisual", borderVisualMap1);


            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(sliderHandler);
            panGestureDetector.Detected += OnPanGestureDetected;

            this.TouchEvent += VideoCustomSlider_TouchEvent;
        }
        private bool VideoCustomSlider_TouchEvent(object source, TouchEventArgs e)
        {
            if (!IsSelectedHandler && e.Touch.GetState(0) == PointStateType.Up)
            {
                if (Type == CustomSliderType.Horizontal)
                {
                    CurrentValue = e.Touch.GetLocalPosition(0).X / this.SizeWidth;
                }
                else
                {
                    CurrentValue = Math.Abs(e.Touch.GetLocalPosition(0).Y / this.SizeHeight);
                }
            }
            return false;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                IsSelectedHandler = true;

            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (IsSelectedHandler)
                {
                    if (Type == CustomSliderType.Horizontal)
                    {
                        var moveX = sliderHandler.PositionX + e.PanGesture.Displacement.X;

                        if (sliderHandler.PositionX != moveX)
                        {
                            CurrentValue = moveX / this.SizeWidth;
                        }
                    }
                    else
                    {
                        var moveY = sliderHandler.PositionY + e.PanGesture.Displacement.Y;

                        if (sliderHandler.PositionY != moveY)
                        {
                            CurrentValue = Math.Abs(moveY / this.SizeHeight);
                        }
                    }

                }
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                IsSelectedHandler = false;
                ValueChangeFinishedEvent?.Invoke(this, CurrentValue);
            }
        }

        public bool IsSelectedHandler
        {
            get
            {
                return isSelectedHandler;
            }
            set
            {
                sliderHandler.BackgroundColor = value ? new Color("#2A3C91") : new Color("#546EE5");
                isSelectedHandler = value;
            }
        }

        public float CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                if (currentValue != value)
                {
                    value = (value < 0) ? 0 : ((value > 1) ? 1 : value);
                    if (Type == CustomSliderType.Horizontal)
                    {

                        sliderHandler.PositionX = this.SizeWidth * value;
                        controlVisual.SizeWidth = this.SizeWidth * value;
                    }
                    else
                    {
                        sliderHandler.PositionY = this.SizeHeight * value * -1;
                        controlVisual.SizeHeight = this.SizeHeight * value;

                    }
                    currentValue = (float)Math.Round(value, 2);
                    ValueChangedEvent?.Invoke(this, currentValue);
                }
            }
        }

        public delegate void ValueChangedEventHandler(object sender, float value);
        public event ValueChangedEventHandler ValueChangedEvent;
        public event ValueChangedEventHandler ValueChangeFinishedEvent;

        private CustomSliderType type = CustomSliderType.Horizontal;
        public CustomSliderType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (type == value)
                {
                    return;
                }

                if (value == CustomSliderType.Horizontal)
                {
                    sliderHandler.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    controlVisual.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                    controlVisual.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
                    controlVisual.PositionUsesPivotPoint = true;
                    controlVisual.WidthSpecification = 0;
                    controlVisual.HeightSpecification = -1;
                }
                else
                {
                    sliderHandler.ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter;
                    controlVisual.ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter;
                    controlVisual.PivotPoint = Tizen.NUI.PivotPoint.BottomCenter;
                    controlVisual.PositionUsesPivotPoint = true;
                    controlVisual.WidthSpecification = -1;
                    controlVisual.HeightSpecification = 0;

                }
                type = value;
            }
        }

        public enum CustomSliderType
        {
            Horizontal = 0,
            Vertical = 1,
        }
    }
}
