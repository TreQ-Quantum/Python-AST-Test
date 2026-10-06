using TreQ.PythonAst.Visitors;

namespace TreQ.PythonAst.Expressions;

public interface IExpression
{
    TReturn Accept<TReturn>(IExpressionVisitor<TReturn> visitor);
}

/// <summary>
/// Base for all expression nodes (e.g., Value, BinaryExpression, Call, etc.)
/// </summary>
public abstract partial record Expression : IExpression
{
    public abstract TReturn Accept<TReturn>(IExpressionVisitor<TReturn> visitor);

    public static implicit operator Expression(bool value) => new Value(value);
    public static implicit operator Expression(long value) => new Value(value);
    public static implicit operator Expression(double value) => new Value(value);
}
