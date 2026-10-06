namespace TreQ.PythonAst.Expressions;

public enum OperatorAssociativity
{
    Left,
    Right,
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class AssociativityAttribute(OperatorAssociativity associativity) : Attribute
{
    public OperatorAssociativity Associativity { get; } = associativity;
}
