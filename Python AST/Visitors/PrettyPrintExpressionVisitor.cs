using System.Text;
using TreQ.PythonAst.Expressions;

namespace TreQ.PythonAst.Visitors;

public class PrettyPrintExpressionVisitor(StringBuilder sb)
    : IExpressionVisitor<StringBuilder>
{
    private readonly PrecedenceVisitor precedenceVisitor = new();

    public StringBuilder Visit(BinaryOperation binaryExpression)
    {
        int myPrecedence = GetPrecedence(binaryExpression);
        VisitSubExpression(binaryExpression.Left, myPrecedence)
            .Append(' ').Append(binaryExpression.Operator.GetName()).Append(' ');
        return VisitSubExpression(binaryExpression.Right, myPrecedence);
    }

    public StringBuilder Visit(Value value)
    {
        switch (value.Data)
        {
        case bool b:
            sb.Append(b ? "True" : "False");
            break;
        case null:
            sb.Append("None");
            break;
        case float f:
            sb.Append(f.ToString().ToLowerInvariant());
            break;
        case double d:
            sb.Append(d.ToString().ToLowerInvariant());
            break;
        default:
            sb.Append(value.Data.ToString());
            break;
        }
        return sb;
    }

    private int GetPrecedence(Expression expr) =>
        expr.Accept(precedenceVisitor);

    private StringBuilder VisitSubExpression(Expression expr, int parentPrec)
    {
        if (GetPrecedence(expr) < parentPrec)
        {
            sb.Append('(');
            expr.Accept(this);
            sb.Append(')');
        }
        else
        {
            expr.Accept(this);
        }
        return sb;
    }
}
