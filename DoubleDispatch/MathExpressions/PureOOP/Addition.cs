// See Vasil Kosturski article on his blog (vkontech.com) :
// https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/

namespace DoubleDispatch.MathExpressions.PureOOP
{
    class Addition : IExpression
    {
        private readonly IExpression _operand1;
        private readonly IExpression _operand2;

        public Addition(IExpression operand1, IExpression operand2)
        {
            _operand1 = operand1;
            _operand2 = operand2;
        }

        // Based on the underlying IValue object, we will end up executing the AddValue
        // version of either IntValue or RationalValue class. This is the first dispatch.

        public IValue Eval() => _operand1.Eval().AddValue(_operand2.Eval());

        public string Stringify() => $"{_operand1.Stringify()} + {_operand2.Stringify()}";
    }
}
