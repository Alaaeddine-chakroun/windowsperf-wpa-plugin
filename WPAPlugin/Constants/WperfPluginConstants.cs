﻿// BSD 3-Clause License
//
// Copyright (c) 2024, Arm Limited
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

using Microsoft.Performance.SDK.Extensibility;

namespace WPAPlugin.Constants
{
    public static class WperfPluginConstants
    {
        // Event Identifiers used by Data cookers
        public const string PerformanceCounterEventKey = "PerformanceCounterEvent";
        public const string PerformanceCounterTimelineEventKey = "PerformanceCounterTimelineEvent";
        public const string TelemetryEventKey = "TelemetryEvent";

        // Parser ID (There should be no reason to have multiple parsers as of now)
        public const string ParserId = "WperfSourceParser";

        // Cooker IDs
        public const string TimelineCookerId = "WperfDataCooker";
        public const string CountCookerId = "WperfCountDataCooker";
        public const string TelemetryCookerId = "WperfTelemetryCooker";

        public static readonly string[] WperfPresetMetrics = { "MPKI", "per TLB access", "per branch", "per cache access", "per cycle", "percent of cycles", "percent of operations", "percent of slots" };

        // Cooker Paths
        public static readonly DataCookerPath CookerPath = DataCookerPath.ForSource(
            ParserId,
            TimelineCookerId
        );

        public static readonly DataCookerPath CountCookerPath = DataCookerPath.ForSource(
            ParserId,
            CountCookerId
        );

        public static readonly DataCookerPath TelemetryCookerPath = DataCookerPath.ForSource(
            ParserId,
            TelemetryCookerId
        );
    }
}
