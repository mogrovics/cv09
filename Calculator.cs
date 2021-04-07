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

        private enum Operation
        {
            Addition,
            Subtraction,
            Mulitplication,
            Division
        };

        private State _state;
        private Operation _operation;

        public string Display { get; set; }

        public void Buttons(string btn)
        {
            var number = "";

            switch (btn)
            {
                // numbers
                case "0":
                    number += "0";
                    break;
                case "1":
                    number += "1";
                    break;
                case "2":
                    number += "2";
                    break;
                case "3":
                    number += "3";
                    break;
                case "4":
                    number += "4";
                    break;
                case "5":
                    number += "5";
                    break;
                case "6":
                    number += "6";
                    break;
                case "7":
                    number += "7";
                    break;
                case "8":
                    number += "8";
                    break;
                case "9":
                    number += "9";
                    break;
                
                // operations
                case "+":
                    _state = State.Operation;
                    _operation = Operation.Addition; 
                    break;
                case "-":
                    _state = State.Operation;
                    _operation = Operation.Subtraction;
                    break;
                case "*":
                    _state = State.Operation;
                    _operation = Operation.Mulitplication;
                    break;
                case "/":
                    _state = State.Operation;
                    _operation = Operation.Division;
                    break;
                case "=":
                    _state = State.Result;
                    break;
            }
        }
    }
}
