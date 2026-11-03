using System.Text;
using TreQ.PythonAst.Expressions;
using TreQ.PythonAst.Visitors;

namespace TreQ.PythonAst.Tests;

public class ComparisonAssociativity
{
    [Fact]
    public void PrettyPrint_LeftAssociativeLessThanChain_IsParenthesized()
    {
        Expression expression = new BinaryOperation(
            new BinaryOperation(1L, BinaryOperators.LessThan, 2L),
            BinaryOperators.LessThan,
            2L);

        StringBuilder output = expression.Accept(new PrettyPrintExpressionVisitor(new StringBuilder()));

        Assert.Equal("(1 < 2) < 2", output.ToString());
    }

    [Fact]
    public void PrettyPrint_RightAssociativeLessThanChain_IsNotParenthesized()
    {
        Expression expression = new BinaryOperation(
            1L,
            BinaryOperators.LessThan,
            new BinaryOperation(2L, BinaryOperators.LessThan, 2L));

        StringBuilder output = expression.Accept(new PrettyPrintExpressionVisitor(new StringBuilder()));

        Assert.Equal("1 < 2 < 2", output.ToString());
    }
}
