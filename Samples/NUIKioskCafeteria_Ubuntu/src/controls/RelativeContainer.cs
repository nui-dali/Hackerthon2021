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

namespace NUIKioskCafeteria
{
    public class RelativeContainer : View
    {
        public RelativeContainer()
        {
            Layout = new RelativeLayout();
            Relayout += RelativeContainerRelayout;
        }

        private void RelativeContainerRelayout(object sender, EventArgs e)
        {
            foreach (var item in Children)
            {
                RelativeLayout.SetLeftTarget(item, RelativeLayout.GetLeftTarget(item) ?? this);
                RelativeLayout.SetRightTarget(item, RelativeLayout.GetRightTarget(item) ?? this);
                RelativeLayout.SetTopTarget(item, RelativeLayout.GetTopTarget(item) ?? this);
                RelativeLayout.SetBottomTarget(item, RelativeLayout.GetBottomTarget(item) ?? this);

                RelativeLayout.SetLeftRelativeOffset(item, RelativeLayout.GetLeftRelativeOffset(item));
                RelativeLayout.SetRightRelativeOffset(item, RelativeLayout.GetRightRelativeOffset(item));
                RelativeLayout.SetTopRelativeOffset(item, RelativeLayout.GetTopRelativeOffset(item));
                RelativeLayout.SetBottomRelativeOffset(item, RelativeLayout.GetBottomRelativeOffset(item));
            }
        }
    }
}
