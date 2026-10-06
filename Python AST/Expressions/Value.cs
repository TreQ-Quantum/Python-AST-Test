using TreQ.PythonAst.Visitors;

namespace TreQ.PythonAst.Expressions;

public record Value(object? Data) : Expression
{
    public override TReturn Accept<TReturn>(IExpressionVisitor<TReturn> visitor) =>
        visitor.Visit(this);
}
