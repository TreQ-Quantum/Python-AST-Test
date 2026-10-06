using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TreQ.PythonAst.Expressions;

public enum BinaryOperators
{
    // Arithmetic
    [Precedence(12), Associativity(OperatorAssociativity.Left)]
    [Display(Name = "*")]
    Multiply,
    [Precedence(12), Associativity(OperatorAssociativity.Left)]
    [Display(Name = "/")]
    Divide,
    [Precedence(11), Associativity(OperatorAssociativity.Left)]
    [Display(Name = "+")]
    Add,
    [Precedence(11), Associativity(OperatorAssociativity.Left)]
    [Display(Name = "-")]
    Subtract,

    // Comparison
    [Precedence(6), Associativity(OperatorAssociativity.Right)]
    [Display(Name = "==")]
    Equals,
    [Precedence(6), Associativity(OperatorAssociativity.Right)]
    [Display(Name = "!=")]
    NotEquals,
    [Precedence(6), Associativity(OperatorAssociativity.Right)]
    [Display(Name = "<")]
    LessThan,
    [Precedence(6), Associativity(OperatorAssociativity.Right)]
    [Display(Name = "<=")]
    LessThanOrEqual,
    [Precedence(6), Associativity(OperatorAssociativity.Right)]
    [Display(Name = ">")]
    GreaterThan,
    [Precedence(6), Associativity(OperatorAssociativity.Right)]
    [Display(Name = ">=")]
    GreaterThanOrEqual,
}

public static class OperatorExtensions
{
    /// <summary>
    /// Get the precedence and associativity of an operator.
    /// </summary>
    /// <param name="op">The operator for which to get the precedence and associativity.</param>
    /// <returns>A tuple containing the precedence and associativity of an operator.</returns>
    /// <exception cref="ArgumentException">Thrown if the operator is not a valid enumeration value or it does not have an associativity attribute.</exception>
    public static (int precedence, OperatorAssociativity assoc) GetFixity(this BinaryOperators op)
    {
        FieldInfo? fieldInfo = op.GetType().GetField(op.ToString());
        return (
            fieldInfo?.GetCustomAttribute<PrecedenceAttribute>(false)?.Precedence
                ?? throw new ArgumentException($"Operator '{op}' does not have a precedence", nameof(op)),
            fieldInfo?.GetCustomAttribute<AssociativityAttribute>(false)?.Associativity
                ?? throw new ArgumentException($"Operator '{op}' does not have an associativity", nameof(op))
        );
    }

    /// <summary>
    /// Get the Name property from the Display attribute of the enum value.
    /// </summary>
    /// <param name="value">The enum value to check for the name property.</param>
    /// <returns>The Name property from the Display attribute.</returns>
    public static string GetName(this Enum value) =>
        value
            .GetType()
            .GetField(value.ToString())
            ?.GetCustomAttribute<DisplayAttribute>(false)
            ?.Name
            ?? value.ToString();
}
