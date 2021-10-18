// See Vasil Kosturski article on his blog (vkontech.com) :
// https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/

namespace DoubleDispatch.MathExpressions.PureOOP
{
    interface IExpression
    {
        IValue Eval();

        string Stringify();
    }
}
