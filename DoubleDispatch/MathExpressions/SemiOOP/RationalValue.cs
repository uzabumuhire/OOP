// See Vasil Kosturski article on his blog (vkontech.com) :
// https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/

namespace DoubleDispatch.MathExpressions.SemiOOP
{
    using System;

    // Adding the new Rational type means adding a new variant,
    // or row, to our Operations Matrix
    class RationalValue : IValue
    {
        public RationalValue(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get;}

        public int Denominator { get;}

        public IValue AddValue(IValue operand)
        {
            switch (operand)
            {
                case IntValue op:
                    return new IntValue(this.Denominator * op.Value + this.Numerator);
                case RationalValue op:
                    return new RationalValue(
                        this.Numerator * op.Denominator + op.Numerator * this.Denominator,
                        this.Denominator * op.Denominator);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operand));
            }
        }

        public IValue Eval() => this;

        public string Stringify() => $"{Numerator}/{Denominator}";
    }
}
