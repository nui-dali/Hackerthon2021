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
using Tizen.NUI.BaseComponents;

namespace NUIKioskPoster
{
    public class VideoPlayer : Tizen.Multimedia.Player
    {
        public VideoPlayer() : base()
        {
            Initialize();
        }

        public VideoPlayer(IntPtr ptr) : base(ptr, null)
        {
            Initialize();
        }

        public VideoPlayer(VideoView videoView) : base((new SafeNativePlayerHandle(videoView)).DangerousGetHandle(), null)
        {
            Initialize();
        }
    }
}
