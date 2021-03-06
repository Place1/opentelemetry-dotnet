﻿// <copyright file="NoopDistributedContextBinarySerializer.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Context
{
    public class NoopDistributedContextBinarySerializer : DistributedContextBinarySerializerBase
    {
        internal static readonly DistributedContextBinarySerializerBase Instance = new NoopDistributedContextBinarySerializer();
        private static readonly byte[] EmptyByteArray = { };

        /// <inheritdoc/>
        public override byte[] ToByteArray(DistributedContext context)
        {
            if (context.CorrelationContext.Entries is null)
            {
                OpenTelemetrySdkEventSource.Log.FailedToInjectContext("entries are null");
            }

            return EmptyByteArray;
        }

        /// <inheritdoc/>
        public override DistributedContext FromByteArray(byte[] bytes)
        {
            if (bytes == null)
            {
                OpenTelemetrySdkEventSource.Log.FailedToExtractContext("null bytes");
            }

            return DistributedContext.Empty;
        }
    }
}
