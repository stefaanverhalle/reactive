﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerable<TValue> Empty<TValue>()
        {
            return new EmptyAsyncIterator<TValue>();
        }

        private sealed class EmptyAsyncIterator<TValue> : AsyncIterator<TValue>, IAsyncIListProvider<TValue>
        {
            public override AsyncIterator<TValue> Clone() => new EmptyAsyncIterator<TValue>();

            public Task<int> GetCountAsync(bool onlyIfCheap, CancellationToken cancellationToken) => Task.FromResult(0);

            public Task<TValue[]> ToArrayAsync(CancellationToken cancellationToken) => Task.FromResult(Array.Empty<TValue>());

            public Task<List<TValue>> ToListAsync(CancellationToken cancellationToken) => Task.FromResult(new List<TValue>());

            protected override Task<bool> MoveNextCore() => TaskExt.False;
        }
    }
}
