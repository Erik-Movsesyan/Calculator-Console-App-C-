using System;


namespace Calculator_Project {
    public class CustomArithmeticException : Exception {
        internal CustomArithmeticException(string message) : base(message) { }
        internal CustomArithmeticException() : base() { }
    }

    public class OperatorExcpetion : Exception {
        public OperatorExcpetion(string message) : base(message) { }
        public OperatorExcpetion() : base() { }
    }
}
