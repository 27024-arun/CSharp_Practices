using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemo
{
    /// <summary>
    /// MathUtils handles mathematical operations.
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Adds two numbers and returns their result.
        /// </summary>
        /// <param name="firstNumber">First number to be added.</param>
        /// <param name="secondNumber">Second number to be added.</param>
        /// <returns>Returns the addition result.</returns>
        public int AddNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Subtracts two numbers and returns their result.
        /// </summary>
        /// <param name="firstNumber">Minuend of the subtraction.</param>
        /// <param name="secondNumber">Subtrahend of the subtraction.</param>
        /// <returns>Returns the subtraction result.</returns>
        public int SubtracNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Multiplies two numbers and returns their result.
        /// </summary>
        /// <param name="firstNumber">First Number to be multiplied.</param>
        /// <param name="secondNumber">Second Number to be multiplied.</param>
        /// <returns>Returns the multiplication result.</returns>
        public int MultipleNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Divides two numbers and returns their result.
        /// </summary>
        /// <param name="dividend">Dividend of the division.</param>
        /// <param name="divisor">Divisor of the division.</param>
        /// <returns>Returns the division result.</returns>
        public int DivideNumbers(int dividend, int divisor)
        {
            return dividend / divisor;
        }
    }
}
