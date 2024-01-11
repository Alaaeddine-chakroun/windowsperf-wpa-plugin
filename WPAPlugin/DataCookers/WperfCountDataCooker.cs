﻿// BSD 3-Clause License
//
// Copyright (c) 2022, Arm Limited
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//
// 3. Neither the name of the copyright holder nor the names of its
//    contributors may be used to endorse or promote products derived from
//    this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using Microsoft.Performance.SDK;
using Microsoft.Performance.SDK.Extensibility;
using Microsoft.Performance.SDK.Extensibility.DataCooking;
using Microsoft.Performance.SDK.Extensibility.DataCooking.SourceDataCooking;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using WPAPlugin.Constants;
using WPAPlugin.Events;

namespace WPAPlugin.DataCookers
{
    public class WperfCountDataCooker : SourceDataCooker<WperfEvent, WperfSourceParser, string>
    {
        private readonly List<WperfEvent> wperfEvents;

        [DataOutput]
        public IReadOnlyList<WperfEvent> WperfEvents { get; }

        public WperfCountDataCooker()
            : base(WperfPluginConstants.CountCookerPath)
        {
            wperfEvents = new List<WperfEvent>();
            WperfEvents = new ReadOnlyCollection<WperfEvent>(wperfEvents);
        }

        public override string Description => "Passes on the counting data as is";

        public override ReadOnlyHashSet<string> DataKeys =>
            new ReadOnlyHashSet<string>(
                new HashSet<string>
                {
                    WperfPluginConstants.PerformanceCounterEventKey,
                    WperfPluginConstants.PerformanceCounterTimelineEventKey
                }
            );

        public override DataProcessingResult CookDataElement(
            WperfEvent data,
            WperfSourceParser context,
            CancellationToken cancellationToken
        )
        {
            wperfEvents.Add(data);

            return DataProcessingResult.Processed;
        }
    }
}