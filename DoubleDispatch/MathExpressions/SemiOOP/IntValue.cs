// See Vasil Kosturski article on his blog (vkontech.com) :
// https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/

namespace DoubleDispatch.MathExpressions.SemiOOP
{
    using System;
    class IntValue : IValue
    {
        public IntValue(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public IValue AddValue(IValue operand)
        {
            // The problem here is that operand can be either of type IntValue
            // or RationalValue. The implementation greatly depends on that.

            // If it’s an IntValue, we just take the underlying integer, add
            // it to the one in the current class and return a new IntValue instance
            // with the resulting int.

            // If it’s a RationalValue, we take the numerator and denominator and
            // do the appropriate arithmetics with the current integer. We then wrap
            // the result in a RationalValue object and return it.

            // Either way, we need to know the type of operand. One approach would
            // be just to check for it explicitly.

            // The issue with this approach is type checking

            switch(operand)
            {
                case IntValue op:
                    return new IntValue(this.Value + op.Value);
                case RationalValue op:
                    return new RationalValue(
                        this.Value * op.Denominator + op.Numerator,
                        op.Denominator);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operand));
            }
        }

        public IValue Eval() => this;

        public string Stringify() => Value.ToString();
    }
}
