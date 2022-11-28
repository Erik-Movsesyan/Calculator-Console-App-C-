using System;


namespace Calculator_Project {
    public abstract class BasicCalculator {
        protected double FirstNum;
        protected double SecondNum;

        protected BasicCalculator(double first_num, double second_num) {
            FirstNum = first_num;
            SecondNum = second_num;
        }

        public abstract double Add();
        public abstract double Subtract();
        public abstract double Multiply();
        public abstract double Divide();

        protected static bool HasTooManyDigitsAfterDot(string Number) {
            string NumberAfterDot = "";
            bool Control = false;
            for (int i = 0; i < Number.Length; i++) {
                if (Control)
                    NumberAfterDot += Number[i];
                if (Number[i] == '.')
                    Control = true;
            }
            return NumberAfterDot.Length > 5;
        }

        protected static bool TheSumOfDigitCountOfFirstAndSecondNumsLessThan10(string a, string b) {
            string sum = a + b;
            return HasDot(sum) ? sum.Length <= 11 : sum.Length <= 10;
        }

        private static bool HasDot(string number) {
            bool HasDot = false;
            foreach (char j in number) {
                if (j == '.')
                    HasDot = true;
            }
            return HasDot;
        }

        protected static double RoundUp(double Result, int digits) {
            return Math.Round(Result, digits);
        }

        private static protected bool IsInteger(double Number) {
            return Number % 1 == 0;
        }

        private static protected bool GreaterThanOrEqualZero(double Number) {
            return Number >= 0;
        }

    }

    public class MidCalculator : BasicCalculator {
        public MidCalculator(double first_num, double second_num) : base(first_num, second_num) { }

        public override double Add() {
            double result = FirstNum + SecondNum;
            if (HasTooManyDigitsAfterDot(result.ToString()))
                result = RoundUp(result, 5);
            return result;
        }

        public override double Subtract() {
            double result = FirstNum - SecondNum;
            if (HasTooManyDigitsAfterDot(result.ToString()))
                result = RoundUp(result, 5);
            return result;
        }

        public override double Multiply() {
            double result = FirstNum * SecondNum;
            if (HasTooManyDigitsAfterDot(result.ToString()))
                result = RoundUp(result, 5);
            return result;
        }

        public override double Divide() {
            if (SecondNum == 0) {
                throw new CustomArithmeticException("Can not divide by zero");
            }
            double result = FirstNum / SecondNum;
            if (HasTooManyDigitsAfterDot(result.ToString()))
                result = RoundUp(result, 5);
            return result;
        }

        public double Percentage() {
            if (SecondNum > 0) {
                double result = FirstNum * SecondNum / 100;
                if (HasTooManyDigitsAfterDot(result.ToString()))
                    result = RoundUp(result, 5);
                return result;
            }
            else
                throw new CustomArithmeticException($"{SecondNum} is an invalid percentage");
        }

        public double PercentageAddition() {
            if (SecondNum > 0) {
                double result = FirstNum + Percentage();
                if (HasTooManyDigitsAfterDot(result.ToString()))
                    result = RoundUp(result, 5);
                return result;
            }
            else
                throw new CustomArithmeticException($"{SecondNum} is an invalid percentage");
        }

        public double PercentageSubtraction() {
            if (SecondNum > 0) {
                double result = FirstNum - Percentage();
                if (HasTooManyDigitsAfterDot(result.ToString()))
                    result = RoundUp(result, 5);
                return result;
            }
            else
                throw new CustomArithmeticException($"{SecondNum} is an invalid percentage");
        }

        public double PercentageMultiplication() {
            if (SecondNum > 0) {
                double result = FirstNum * Percentage();
                if (HasTooManyDigitsAfterDot(result.ToString()))
                    result = RoundUp(result, 5);
                return result;
            }
            else
                throw new CustomArithmeticException($"{SecondNum} is an invalid percentage");
        }

        public double PercentageDivision() {
            if (FirstNum == 0) {
                if(SecondNum>0)
                    throw new CustomArithmeticException($"Will not be able to devide by 0");
                if (SecondNum < 0)
                    throw new CustomArithmeticException($"Will not be able to devide by 0 and " +
                                                        $"{SecondNum} is an invalid percentage");
            }
            if (SecondNum > 0) {
                double result = FirstNum / Percentage();
                if (HasTooManyDigitsAfterDot(result.ToString()))
                    result = RoundUp(result, 5);
                return result;
            }
            else
                throw new CustomArithmeticException($"{SecondNum} is an invalid percentage");
        }

        public double Factorial() {
            double result = FirstNum;
            if (IsInteger(result) && GreaterThanOrEqualZero(result)) {
                if (result > 170)
                    throw new CustomArithmeticException("Factorials of numbers past 170 are considered " +
                                                        "to being equal to infinity");

                if (result == 0)
                    return 1;
                int iterator = (int)result - 1;
                while (iterator != 0) {
                    result *= iterator;
                    iterator--;
                }
                return result;
            }
            else {
                throw new CustomArithmeticException($"Can not calculate the factorial of {FirstNum}" +
                                                    $" Since the format is invalid");
            }
        }

        public double ToThePowerOf() {
            if (IsInteger(SecondNum)) {
                if(!TheSumOfDigitCountOfFirstAndSecondNumsLessThan10(FirstNum.ToString(),SecondNum.ToString()))
                    throw new CustomArithmeticException($"Try smaller numbers");

                if (SecondNum == 0)
                    return 1;
                else {
                    double Number = SecondNum < 0 ? -SecondNum : SecondNum;
                    double result = FirstNum;
                    for (int i = (int)Number; i > 1; i--) {
                        result *= FirstNum;
                    }
                    result = SecondNum < 0 ? (1 / result) : result;
                    if (HasTooManyDigitsAfterDot(result.ToString()))
                        result = RoundUp(result, 10);
                    return result;
                }
            }
            else if (SecondNum == 0.5 && GreaterThanOrEqualZero(FirstNum))
                return Math.Sqrt(FirstNum);
            else {
                throw new CustomArithmeticException($"Can not Calculate the {SecondNum} power of a number");
            }

        }

        public double SquareRoot() {
            double result = FirstNum;
            if (result >= 0) {
                result = Math.Sqrt(result);
                if (HasTooManyDigitsAfterDot(result.ToString()))
                    result = RoundUp(result, 5);
                return result;
            }
            else
                throw new CustomArithmeticException($"{FirstNum} is not equal or greater than 0");
        }

        public double Trigonometry(string j) {
            double result = FirstNum;
            if (j == "sin")
                result = Math.Sin(result);
            else if (j == "cos")
                result = Math.Cos(result);
            else if (j == "tan")
                result = Math.Tan(result);
            else if (j == "cot")
                result = 1 / Math.Tan(result);

            if (HasTooManyDigitsAfterDot(result.ToString()))
                result = RoundUp(result, 5);
            return result;
        }

        public double Logarithm(string j) {
            if (FirstNum >= 0) {
                double result = FirstNum;
                if (j == "log10")
                    result = Math.Log10(result);
                if (j == "loge")
                    result = Math.Log(result);
                if (j == "log2")
                    result = Math.Log2(result);

                return result;
            }
            else
                throw new CustomArithmeticException("The Argument has to be greater or equal to 0");
        }

    }
}
