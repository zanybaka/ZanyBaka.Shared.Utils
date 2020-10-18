using System;

namespace ZanyBaka.Shared.Utils.Lib.Entities.If
{
    public class Iif<TResult>
    {
        private readonly Lazy<TResult> _lazyValue;

        public Iif(Func<bool> condition, TResult trueResult, TResult falseResult)
        {
            if (condition == null || trueResult == null || falseResult == null)
            {
                throw new ArgumentNullException();
            }

            _lazyValue = new Lazy<TResult>(() => condition() ? trueResult : falseResult);
        }

        public static implicit operator TResult(Iif<TResult> obj)
        {
            return obj.GetValue();
        }

        public TResult GetValue()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return GetValue().ToString();
        }
    }
}