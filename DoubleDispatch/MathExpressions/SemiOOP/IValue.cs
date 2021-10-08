// See Vasil Kosturski article on his blog (vkontech.com) :
// https://vkontech.com/clash-of-styles-part-5-double-dispatch-or-when-to-abandon-oop/

namespace DoubleDispatch.MathExpressions.SemiOOP
{
    // A marker interface that will be “implemented” by
    // the two value types – ints and rationals.
    interface IValue : IExpression
    {
        // OOP encourages us to define all the operations in terms
        // of the objects themselves. So if we want to add two IValue
        // objects together, this will be expressed as one of the objects
        // adding the other one to itself.
        IValue AddValue(IValue operand);
    }
}
