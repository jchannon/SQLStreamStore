﻿namespace SqlStreamStore.V1
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using SqlStreamStore.V1.Streams;
    using Xunit;

    public partial class AcceptanceTests
    {
        [Fact]
        public async Task Time_to_take_to_read_1000_read_head_positions()
        {
            await store.AppendToStream("stream-1", ExpectedVersion.NoStream, CreateNewStreamMessages(1, 2, 3));

            var stopwatch = Stopwatch.StartNew();

            for(int i = 0; i < 1000; i++)
            {
                await store.ReadHeadPosition();
            }


            TestOutputHelper.WriteLine(stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}