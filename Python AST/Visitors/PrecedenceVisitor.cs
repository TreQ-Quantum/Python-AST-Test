using TreQ.PythonAst.Expressions;

namespace TreQ.PythonAst.Visitors;

internal class PrecedenceVisitor : IExpressionVisitor<int>
{
    public int Visit(BinaryOperation binaryExpression) =>
        binaryExpression.Operator.GetFixity().precedence;
    public int Visit(Value value) => 18;
}
