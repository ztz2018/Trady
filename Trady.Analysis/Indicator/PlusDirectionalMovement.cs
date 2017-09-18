﻿using System;
using System.Collections.Generic;
using Trady.Analysis.Infrastructure;
using Trady.Core;

namespace Trady.Analysis.Indicator
{
    public class PlusDirectionalMovement<TInput, TOutput> : NumericAnalyzableBase<TInput, decimal, TOutput>
    {
        public PlusDirectionalMovement(IEnumerable<TInput> inputs, Func<TInput, decimal> inputMapper) : base(inputs, inputMapper)
        {
        }

        protected override decimal? ComputeByIndexImpl(IReadOnlyList<decimal> mappedInputs, int index)
            => index > 0 ? mappedInputs[index] - mappedInputs[index - 1] : (decimal?)null;
    }

    public class PlusDirectionalMovementByTuple : PlusDirectionalMovement<decimal, decimal?>
    {
        public PlusDirectionalMovementByTuple(IEnumerable<decimal> inputs)
            : base(inputs, i => i)
        {
        }
    }

    public class PlusDirectionalMovement : PlusDirectionalMovement<Candle, AnalyzableTick<decimal?>>
    {
        public PlusDirectionalMovement(IEnumerable<Candle> inputs)
            : base(inputs, i => i.High)
        {
        }
    }
}