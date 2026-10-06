using TreQ.PythonAst.Visitors;

namespace TreQ.PythonAst.Expressions;

public record BinaryOperation(Expression Left, BinaryOperators Operator, Expression Right)
    : Expression
{
    public override TReturn Accept<TReturn>(IExpressionVisitor<TReturn> visitor) =>
        visitor.Visit(this);
}
