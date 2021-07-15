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

namespace NUIKioskPoster
{
    class CustomFocusLinearLayout : LayoutGroup
    {
        private float itemTotalSize = 0;
        public bool IsAnimating = false;

        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            if(IsAnimating)
            {
                return;
            }

            var itemWidth = new LayoutLength(0);
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                if (childLayout != null)
                {
                    MeasureChild(childLayout, widthMeasureSpec, heightMeasureSpec);
                    itemWidth += (childLayout.MeasuredWidth.Size + childLayout.Margin.Start + childLayout.Margin.End);
                }
            }
            itemTotalSize = itemWidth.AsDecimal();
            // Finally, call this method to set the dimensions we would like
            SetMeasuredDimensions(new MeasuredSize(widthMeasureSpec.GetSize(), MeasuredSize.StateType.MeasuredSizeOK),
                                  new MeasuredSize(heightMeasureSpec.GetSize(), MeasuredSize.StateType.MeasuredSizeOK));
        }

        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            if (IsAnimating)
            {
                return;
            }

            var item = LayoutChildren[0].Owner;
            int margin = item.Margin.Start + item.Margin.End;
            float centerX = (itemTotalSize - item.SizeWidth - margin) / 2;
            float positionX = 0;

            LayoutItem prevItem = null;
            foreach (LayoutItem childLayout in LayoutChildren)
            {
                LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                int marginSize = childLayout.Margin.Start + childLayout.Margin.End;
                if (prevItem != null)
                {
                    float prevSize = prevItem.MeasuredWidth.Size.AsDecimal() / 2;
                    float currentSize = childLayout.MeasuredWidth.Size.AsDecimal() / 2;
                    positionX = positionX + prevSize + currentSize + marginSize;
                }

                LayoutLength childLeft = new LayoutLength(positionX - centerX);
                LayoutLength childTop = new LayoutLength(0);

                childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                prevItem = childLayout;
                var owner = childLayout.Owner as SummaryView;
            }
        }
    }
}
