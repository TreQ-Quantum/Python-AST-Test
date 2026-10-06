using TreQ.PythonAst.Expressions;

namespace TreQ.PythonAst.Visitors;

public interface IExpressionVisitor<TReturn>
{
    TReturn Visit(BinaryOperation binaryExpression);
    TReturn Visit(Value value);
}
