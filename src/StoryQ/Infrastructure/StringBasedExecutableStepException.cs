using System;
using System.Text.RegularExpressions;

namespace StoryQ.Infrastructure
{
    /// <summary>
    /// Thrown from a string based executable step
    /// </summary>
    public class StringBasedExecutableStepException : NotImplementedException
    {
        private readonly string stepText;

        /// <summary>
        /// Creates a StringBasedExecutableStepException
        /// </summary>
        public StringBasedExecutableStepException(string stepText)
        {
            this.stepText = stepText;
        }

        /// <summary>
        /// Gives you the correct
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            const string Template = @"(string used for executable step)

You can choose to implement this '{0}' step with:


{2}
public void {1}()
{{
	throw new NotImplementedException();
}}


";

            string safeStepText = Regex.Replace(stepText, "[^a-zA-Z0-9_ ]", "");
            string attribute = safeStepText == stepText ? "" : "[OverrideMethodFormat("+stepText+")]";
            return string.Format(Template, stepText, safeStepText.Camel(), attribute);
        }
    }
}