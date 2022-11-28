using System;


namespace Calculator_Project {

    class MainMethod {
        static void Main() {

            double FirstNum = 0;
            double SecondNum = 0;
            string? Operator = null;
            bool Continue = true;
            MidCalculator? Calc;

            string? FirstNumString = null, SecondNumString = null;
            try {
                Console.WriteLine("Input the first number!");
                FirstNumString = Console.In.ReadLine();
                FirstNum = Double.Parse(FirstNumString);
                if (FirstNumString.Length > 15)
                    throw new ArgumentException();

                Console.WriteLine("Input the operation's sign");
                Operator = Console.ReadLine();
                //check if operator is valid
                if (Operators.CheckOperator(Operator, Operators.AllOperators))
                    throw new OperatorExcpetion($"<{Operator}> is an invalid operator. Please try again");

                //check if the user needs to input two numbers based on the operation
                //that they want to do with the number(s)
                if (Operators.CheckOperator(Operator, Operators.OneNumOperators)) {
                    Console.WriteLine("Input the second number!");
                    SecondNumString = Console.In.ReadLine();
                    SecondNum = Double.Parse(SecondNumString);
                    if (FirstNumString.Length > 15)
                        throw new ArgumentException();
                }

            }
            catch (OperatorExcpetion exc) {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentException) {
                if (FirstNumString != null && SecondNumString == null)
                    Console.WriteLine($"\n<{FirstNumString}> is a too big number\n" +
                        "Please try again");
                else if (SecondNumString != null)
                    Console.WriteLine($"\n<{SecondNumString}> is a too big number\n" +
                            "Please try again");
            }
            catch (FormatException) {
                if (FirstNumString != null && SecondNumString == null)
                    Console.WriteLine($"\n<{FirstNumString}> is not a valid number\n" +
                        "Please try again");
                else if (SecondNumString != null)
                    Console.WriteLine($"\n<{SecondNumString}> is not a valid number\n" +
                    "Please try again");
                //Set to false so the next try catch block does not execute
                //since at that point there is either no opertor(it is null) or
                //the second number is invalid
                Continue = false;
            }
            catch (SystemException) {
                Console.WriteLine("Unknown Issue Occured");
            }


            Calc = new(FirstNum, SecondNum);
            if (Continue) {
                try {
                    if (Operators.TruncateOperator(Operator) == "+")
                        Console.WriteLine(Calc.Add());
                    else if (Operators.TruncateOperator(Operator) == "-")
                        Console.WriteLine(Calc.Subtract());
                    else if (Operators.TruncateOperator(Operator) == "*")
                        Console.WriteLine(Calc.Multiply());
                    else if (Operators.TruncateOperator(Operator) == "/")
                        Console.WriteLine(Calc.Divide());
                    else if (Operators.TruncateOperator(Operator) == "%")
                        Console.WriteLine(Calc.Percentage());
                    else if (Operators.TruncateOperator(Operator) == "+%" || Operators.TruncateOperator(Operator) == "%+")
                        Console.WriteLine(Calc.PercentageAddition());
                    else if (Operators.TruncateOperator(Operator) == "-%" || Operators.TruncateOperator(Operator) == "%-")
                        Console.WriteLine(Calc.PercentageSubtraction());
                    else if (Operators.TruncateOperator(Operator) == "*%" || Operators.TruncateOperator(Operator) == "%*")
                        Console.WriteLine(Calc.PercentageMultiplication());
                    else if (Operators.TruncateOperator(Operator) == "/%" || Operators.TruncateOperator(Operator) == "%/")
                        Console.WriteLine(Calc.PercentageDivision());
                    else if (Operators.TruncateOperator(Operator) == "!")
                        Console.WriteLine(Calc.Factorial());
                    else if (Operators.TruncateOperator(Operator) == "^")
                        Console.WriteLine(Calc.ToThePowerOf());
                    else if (Operators.TruncateOperator(Operator) == "sqrt")
                        Console.WriteLine(Calc.SquareRoot());
                    else if (Operators.TruncateOperator(Operator) == "sin")
                        Console.WriteLine(Calc.Trigonometry("sin"));
                    else if (Operators.TruncateOperator(Operator) == "cos")
                        Console.WriteLine(Calc.Trigonometry("cos"));
                    else if (Operators.TruncateOperator(Operator) == "tan")
                        Console.WriteLine(Calc.Trigonometry("tan"));
                    else if (Operators.TruncateOperator(Operator) == "cot")
                        Console.WriteLine(Calc.Trigonometry("cot"));
                    else if (Operators.TruncateOperator(Operator) == "log10")
                        Console.WriteLine(Calc.Logarithm("log10"));
                    else if (Operators.TruncateOperator(Operator) == "loge")
                        Console.WriteLine(Calc.Logarithm("loge"));
                    else if (Operators.TruncateOperator(Operator) == "log2")
                        Console.WriteLine(Calc.Logarithm("log2"));
                }
                catch (SystemException) {
                    Console.WriteLine("Unknown Issue Occured");
                }
                catch (Exception j) {
                    Console.WriteLine(j.Message);
                }

            }
        }

    }
}

