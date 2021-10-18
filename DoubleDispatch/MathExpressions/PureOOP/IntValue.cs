// See Vasil Kosturski article on his blog (vkontech.com) :
// https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/

namespace DoubleDispatch.MathExpressions.PureOOP
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

            // In the context of the IntValue class, we don’t know the type of operand.
            // But we do know the type of the current object(the type of this) – it’s
            // IntValue. Which means, we know the type of one of the Addition operands.

            // We need to dispatch the execution to a context where the types of both
            // operands are known. 

            // - We know that the type of 'this' is IntValue.
            // - We still don’t know the type of operand, but we do know that it can add
            //   an IntValue instance to itself.

            // Just call the AddInt method on operand and pass this to it. Based on the
            // exact type of operand, we’ll execute the AddInt implementation either in
            // IntValue or RationalValue. This is the second dispatch.

            // In summary, we used two polymorphic calls on the IValue interface – first
            // AddValue and then AddInt. Hence the name of the technique – Double Dispatch.

            // Note that we didn’t have to check for types anywhere. Instead, we solved
            // the issue with pure OOP idioms.

            return operand.AddInt(this);
        }

        public IValue AddInt(IntValue operand) => new IntValue(this.Value + operand.Value);

        public IValue AddRational(RationalValue operand) => new RationalValue(
            operand.Denominator * this.Value + operand.Numerator,
            operand.Denominator);

        public IValue Eval() => this;

        public string Stringify() => Value.ToString();
    }
}
