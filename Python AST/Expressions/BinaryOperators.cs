using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TreQ.PythonAst.Expressions;

public enum BinaryOperators
{
    // Arithmetic
    [Precedence(12)]
    [Display(Name = "*")]
    Multiply,
    [Precedence(12)]
    [Display(Name = "/")]
    Divide,
    [Precedence(11)]
    [Display(Name = "+")]
    Add,
    [Precedence(11)]
    [Display(Name = "-")]
    Subtract,

    // Comparison
    [Precedence(6)]
    [Display(Name = "==")]
    Equals,
    [Precedence(6)]
    [Display(Name = "!=")]
    NotEquals,
    [Precedence(6)]
    [Display(Name = "<")]
    LessThan,
    [Precedence(6)]
    [Display(Name = "<=")]
    LessThanOrEqual,
    [Precedence(6)]
    [Display(Name = ">")]
    GreaterThan,
    [Precedence(6)]
    [Display(Name = ">=")]
    GreaterThanOrEqual,
}

public static class OperatorExtensions
{
    /// <summary>
    /// Get the precedence of an operator.
    /// </summary>
    /// <param name="op">The operator for which to get the precedence.</param>
    /// <returns>The precedence of an operator.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If </exception>
    public static int GetPrecedence(this Enum op) =>
        op.GetType().GetField(op.ToString())?.GetCustomAttribute<PrecedenceAttribute>(false)?.Precedence
            ?? throw new ArgumentException($"Operator '{op}' does not have a precedence", nameof(op));

    /// <summary>
    /// Get the Name property from the Display attribute of the enum value.
    /// </summary>
    /// <param name="value">The enum value to check for the name property.</param>
    /// <returns>The Name property from the Display attribute.</returns>
    public static string GetName(this Enum value) =>
        value.GetType().GetField(value.ToString())?.GetCustomAttribute<DisplayAttribute>(false)?.Name
            ?? value.ToString();
}
