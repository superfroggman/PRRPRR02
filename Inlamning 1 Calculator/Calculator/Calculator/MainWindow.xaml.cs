using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int gridWidth = 5;
        int gridHeight = 5;

        public MainWindow()
        {
            InitializeComponent();

            //Set grid to correct size
            for (int i = 0; i < gridWidth; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < gridHeight; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }

            string[,] buttons = new string[,] {
                {"", "", "", "C", "("},
                {"7", "8", "9", "+", ")"},
                {"4", "5", "6", "-", ""},
                {"1", "2", "3", "*", ""},
                {".", "0", "=", "/", ""}
            };

            int buttonOffsetX = 0;
            int buttonOffsetY = 0;

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j] == "") continue;

                    var button = new Button();
                    button.SetValue(Grid.ColumnProperty, j + buttonOffsetX);
                    button.SetValue(Grid.RowProperty, i + buttonOffsetY);
                    button.SetValue(ContentProperty, buttons[i, j]);
                    button.Click += new RoutedEventHandler(Button_Click);
                    mainGrid.Children.Add(button);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                if (button.Content == "=")
                {
                    Calculate();
                    return;
                }
                else if (button.Content == "C")
                {
                    textBox.Text = "";
                    return;
                }
                Debug.WriteLine(button.Content);
                textBox.Text += button.Content;
            }

        }



        private void Calculate()
        {
            //Auto generera detta sen
            List<Operator> operators = new List<Operator>();
            operators.Add(new Operator('*', 0));
            operators.Add(new Operator('/', 0));
            operators.Add(new Operator('+', 1));
            operators.Add(new Operator('-', 1));

            string input = textBox.Text;

            List<string> outputQueue = DoTheShuntingYard(input, operators);

            Debug.WriteLine("Final queue: " + ListToString(outputQueue));

            //TODO: skriv egen uträkning
            Debug.WriteLine("ANSWER!: " + CalculateRPN(ListToString(outputQueue)));
            textBox.Text = CalculateRPN(ListToString(outputQueue)).ToString();
        }


        private List<string> DoTheShuntingYard(string input, List<Operator> operators)
        {
            List<string> outputQueue = new List<string>();
            Stack<char> operatorStack = new Stack<char>();

            char topOp;
            int topOpI;

            //while there are tokens to be read:
            for (int i = 0; i < input.Length; i++)
            {
                //read a token.

                //if the token is a number, then:
                if (Char.IsNumber(input[i]) || input[i] == '.')
                {
                    int numLength = 0;
                    while (i + numLength < input.Length)
                    {
                        Char c = input[i + numLength];
                        if (Char.IsNumber(c) || c == '.')
                        {
                            numLength += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (numLength != 0)
                    {
                        string num = input.Substring(i, numLength);

                        i += numLength - 1;

                        //push it to the output queue.
                        outputQueue.Add(num);
                    }
                }

                bool isOperator = false;

                int curOpI = 0;

                topOp = '+';
                topOpI = 0;

                foreach (Operator op in operators)
                {
                    if (op._op == input[i])
                    {
                        isOperator = true;
                        curOpI = operators.IndexOf(op);
                    }

                    if (operatorStack.Count > 0 && op._op == operatorStack.Peek())
                    {
                        topOp = op._op;
                        topOpI = operators.IndexOf(op);
                    }
                }

                //else if the token is an operator then:
                if (isOperator)
                {
                    Debug.WriteLine("IS OPERATOR: " + operators[curOpI]._op);
                    //while ((there is an operator at the top of the operator stack)
                    //  and ((the operator at the top of the operator stack has greater precedence)
                    //      or(the operator at the top of the operator stack has equal precedence and the token is left associative))
                    //  and(the operator at the top of the operator stack is not a left parenthesis)):
                    while (operatorStack.Count > 0 && (topOpI < curOpI || topOp == operators[curOpI]._op) && topOp != '(')
                    {
                        //pop operators from the operator stack onto the output queue.
                        outputQueue.Add(topOp.ToString());
                        operatorStack.Pop();

                        if (operatorStack.Count > 0)
                        {
                            topOp = operatorStack.Peek();
                            topOpI = GetTopOpI(operators, operatorStack);
                        }
                    }

                    //push it onto the operator stack.
                    operatorStack.Push(input[i]);
                }

                //else if the token is a left parenthesis (i.e. "("), then:
                else if (input[i] == '(')
                {
                    //push it onto the operator stack.
                    operatorStack.Push('(');
                }
                //else if the token is a right parenthesis(i.e. ")"), then:
                else if (input[i] == ')')
                {
                    //while the operator at the top of the operator stack is not a left parenthesis:
                    while (topOp != '(')
                    {
                        //pop the operator from the operator stack onto the output queue.
                        outputQueue.Add(topOp.ToString());
                        operatorStack.Pop();

                        topOp = operatorStack.Peek();
                    }

                    //if there is a left parenthesis at the top of the operator stack, then:
                    if (topOp == '(')
                    {
                        //pop the operator from the operator stack and discard it
                        operatorStack.Pop();

                    }
                }
                Debug.WriteLine("Out" + i + ": " + ListToString(outputQueue));
                Debug.WriteLine("OpS" + i + ": " + charStackToString(operatorStack));
            }

            //if there are no more tokens to read then:
            //while there are still operator tokens on the stack:
            while (operatorStack.Count > 0)
            {
                //pop the operator from the operator stack onto the output queue.
                topOp = operatorStack.Peek();

                outputQueue.Add(topOp.ToString());
                operatorStack.Pop();
            }

            return outputQueue;
        }

        private int GetTopOpI(List<Operator> operators, Stack<char> operatorStack)
        {
            int topOpI = 0;


            foreach (Operator op in operators)
            {
                if (op._op == operatorStack.Peek())
                {
                    topOpI = operators.IndexOf(op);
                }
            }

            return topOpI;
        }

        //FROM ROSETTA CODE
        static decimal CalculateRPN(string rpn)
        {
            string[] rpnTokens = rpn.Split(' ');
            Stack<decimal> stack = new Stack<decimal>();
            decimal number = decimal.Zero;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "^":
                        case "pow":
                            {
                                number = stack.Pop();
                                stack.Push((decimal)Math.Pow((double)stack.Pop(), (double)number));
                                break;
                            }
                        case "ln":
                            {
                                stack.Push((decimal)Math.Log((double)stack.Pop(), Math.E));
                                break;
                            }
                        case "sqrt":
                            {
                                stack.Push((decimal)Math.Sqrt((double)stack.Pop()));
                                break;
                            }
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }
                        default:
                            Console.WriteLine("Error in CalculateRPN(string) Method!");
                            break;
                    }
                }
                PrintState(stack);
            }

            return stack.Pop();
        }

        static void PrintState(Stack<decimal> stack)
        {
            decimal[] arr = stack.ToArray();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write("{0,-8:F3}", arr[i]);
            }

            Console.WriteLine();
        }

        private string ListToString(List<string> list)
        {
            string[] outputArray = list.ToArray();

            string res = "";

            foreach (string str in outputArray)
            {
                res += str + " ";
            }

            return res;
        }

        private string stackToString(Stack<string> stack)
        {
            string[] outputArray = stack.ToArray();

            string res = "";

            foreach (string str in outputArray)
            {
                res += str + " ; ";
            }

            return res;
        }

        private string charStackToString(Stack<char> stack)
        {
            char[] outputArray = stack.ToArray();

            string res = "";

            foreach (char str in outputArray)
            {
                res += str + " ; ";
            }

            return res;
        }
    }
}
