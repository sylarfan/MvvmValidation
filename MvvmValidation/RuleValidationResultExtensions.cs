using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MvvmValidation
{
	/// <summary>
	/// Contains helper extension methods for working with <see cref="RuleValidationResult"/>.
	/// </summary>
	public static class RuleValidationResultExtensions
	{
		/// <summary>
		/// Merges <paramref name="firstRuleResult"/> with given <paramref name="secondRuleResult"/> and returns a new instance of <see cref="ValidationResult"/>
		/// that represents the merged result (the result that contains errors from both results whithout duplicates).
		/// </summary>
		/// <param name="firstRuleResult">The first validation result to merge.</param>
		/// <param name="secondRuleResult">The second validation result to merge.</param>
		/// <returns>A new instance of <see cref="RuleValidationResult"/> that represents the merged result (the result that contains errors from both results whithout duplicates).</returns>
		public static RuleValidationResult Combine(this RuleValidationResult firstRuleResult,
												   RuleValidationResult secondRuleResult)
		{
			Contract.Requires(firstRuleResult != null);
			Contract.Requires(secondRuleResult != null);

			var result = new RuleValidationResult();

			foreach (string error in firstRuleResult.Errors)
			{
				result.AddError(error);
			}

			foreach (string error in secondRuleResult.Errors)
			{
				if (!result.Errors.Contains(error))
				{
					result.AddError(error);
				}
			}

			return result;
		}
	}
}