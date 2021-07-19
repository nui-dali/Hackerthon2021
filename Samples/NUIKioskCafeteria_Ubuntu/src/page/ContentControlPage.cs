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
using Tizen.NUI.Components;

namespace NUIKioskCafeteria
{
    public class ContentControlPage : ContentPage
    {
        protected INextPage CurrentIPage;

        public ContentControlPage()
        {
            AppearingTransition = new Fade
            {
                TimePeriod = new TimePeriod(400),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine),
            };
            DisappearingTransition = new Fade
            {
                TimePeriod = new TimePeriod(400),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine),
            };

            CurrentIPage = this as INextPage;
        }

        protected virtual void NextPageClicked(object sender, ClickedEventArgs e)
        {
            if (CurrentIPage == null)
            {
                Tizen.Log.Error("NUI", "Push error, CurrentIPage is null");
                return;
            }
            Navigator.Push(CurrentIPage.NextPage());
        }

        protected virtual void PrevPageClicked(object sender, ClickedEventArgs e)
        {
            Navigator.Pop();
        }

        protected virtual bool PrevPageTouched(object sender, TouchEventArgs e)
        {
            if(e.Touch.GetState(0) == Tizen.NUI.PointStateType.Up)
            {
                Navigator.Pop();
            }
            return false;
        }
    }
}
