
namespace Calculator_Project {
    public static class Operators {
        public static string[] AllOperators { get; } = { "+","-","*","/","%","+%","-%","*%","/%",
                                                    "!","^","sqrt","sin","cos","tan","cot",
                                                    "log10","loge","log2"};

        public static string[] OneNumOperators { get; } = { "!", "sqrt", "sin", "cos", "tan", "cot",
                                                        "log10","loge","log2"};

        public static string[] TextualOperators { get; } = { "sqrt", "sin", "cos", "tan", "cot",
                                                        "log10","loge","log2"};

        //check if the input operator does not exists in one of the lists of operators
        public static bool CheckOperator(string Operator, string[] List) {
            Operator = TruncateOperator(Operator);
            bool Control = true;
            foreach (string j in List) {
                if (Operator == j)
                    Control = false;
            }
            return Control;
        }

        public static bool IsTextualOperator(string Operator) {
            bool Control = false;
            foreach (string j in TextualOperators) {
                if (Operator == j)
                    Control = true;
            }
            return Control;
        }

        //If the user input on the operator has unnecessary spaces on either sides,
        //remove them(e.g. <   sin >) but if there are spaces inside the text(e.g. <s in>),
        //those will not be removed
        public static string TruncateOperator(string Operator) {
            Operator = Operator.ToLower();

            string Inter = "", result = "";
            if (Operator != " " && Operator.Length != 0) {
                int i, c;
                for (i = 0; Operator[i] == ' '; i++) { }
                for (int j = i; j < Operator.Length; j++) {
                    Inter += Operator[j];
                }
                for (c = Inter.Length - 1; Inter[c] == ' '; c--) { }
                for (int e = 0, r = c + 1; r != 0; r--, e++) {
                    result += Inter[e];
                }
                return result;
            }
            else {
                return Operator;
            }

        }
    }
}
