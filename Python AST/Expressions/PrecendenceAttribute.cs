namespace TreQ.PythonAst.Expressions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class PrecedenceAttribute(int precedence) : Attribute
{
    public int Precedence { get; } = precedence;
}
