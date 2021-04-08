using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv09
{
    public class Calculator
    {
        private enum State 
        {
            First,
            Operation,
            Second,
            Result
        };

        private State _state;
        private string firstNumber;
        private string secondNumber;
        private string operation;

        public string Display
        {
            get 
            {
                switch (_state)
                {
                    case State.First:
                    case State.Operation:
                        return firstNumber;
                    case State.Second:
                        return secondNumber;
                    case State.Result:
                        if (secondNumber == "0")
                            return "Division by zero.";
                        else
                            return Calculate().ToString("#.##");
                    default:
                        return "";
                }
            }
        }

        public string Memory { get; set; }

        public void Buttons(string button)
        {
            // numbers
            if (button.Length == 1 && char.IsDigit(char.Parse(button)) || button == ",")
            {
                switch (_state)
                {
                    case State.First:
                        firstNumber += button;
                        break;
                    case State.Operation:
                        _state = State.Second;
                        secondNumber = button;
                        break;
                    case State.Second:
                        secondNumber += button;
                        break;
                    case State.Result:
                        _state = State.First;
                        firstNumber = button;
                        secondNumber = "";
                        break;
                }
            }

            // operations
            else if (button == "+" || button == "-" || button == "*" || button == "/")
            {
                operation = button;
                _state = State.Operation;
            }

            // polarity
            else if (button == "+/-")
            {
                switch (_state)
                {
                    case State.First:
                        firstNumber = Polarity(firstNumber);
                        break;
                    case State.Second:
                        secondNumber = Polarity(secondNumber);
                        break;
                    default:
                        break;
                }
            }

            // result
            else if (button == "=")
            {
                _state = State.Result;
            }

            // remove last digit
            else if (button == "<=")
            {
                switch (_state)
                {
                    case State.First:
                        firstNumber = firstNumber.Remove(firstNumber.Length - 1);
                        break;
                    case State.Second:
                        secondNumber = secondNumber.Remove(secondNumber.Length - 1);
                        break;
                    default:
                        break;
                }
            }

            // removes all numbers
            else if (button == "C")
            {
                RemoveNumbers();
            }

            // remove current number
            else if (button == "CE")
            {
                switch (_state)
                {
                    case State.First:
                        firstNumber = "";
                        break;
                    case State.Second:
                        secondNumber = "";
                        break;
                    case State.Result:
                        RemoveNumbers();
                        break;
                }
            }
        }

        public void RemoveNumbers()
        {
            _state = State.First;
            firstNumber = "";
            secondNumber = "";
        }
        public string Polarity(string number)
        {
            if (number[0] == '-')
            {
                return number.Remove(0);
            }
            else
                return "-" + number;
        }
        public double Calculate()
        {
            switch (operation)
            {
                case "+":
                    return Double.Parse(firstNumber) + Double.Parse(secondNumber);
                case "-":
                    return Double.Parse(firstNumber) - Double.Parse(secondNumber);
                case "*":
                    return Double.Parse(firstNumber) * Double.Parse(secondNumber);
                case "/":
                    return Double.Parse(firstNumber) / Double.Parse(secondNumber);
            }
            return 0;
        }
    }
}
