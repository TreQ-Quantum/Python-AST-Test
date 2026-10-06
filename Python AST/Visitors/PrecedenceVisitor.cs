using TreQ.PythonAst.Expressions;

namespace TreQ.PythonAst.Visitors;

internal class PrecedenceVisitor : IExpressionVisitor<int>
{
    public int Visit(BinaryOperation binaryExpression) => binaryExpression.Operator.GetPrecedence();
    public int Visit(Value value) => 18;
}

public static class PrecedenceExtensions
{
    public static int GetPrecedence(this Expression expr) =>
        expr.Accept(new PrecedenceVisitor());
}
