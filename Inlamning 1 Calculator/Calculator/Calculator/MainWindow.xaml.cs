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
                {"", "", "", "C" },
                {"7", "8", "9", "+"},
                {"4", "5", "6", "-"},
                {"1", "2", "3", "*"},
                {".", "0", "=", "/"}
            };

            //Debug.WriteLine(buttons.GetLength(0));

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
            List<string> operators = new List<string>();
            operators.Add("*");
            operators.Add("/");
            operators.Add("+");
            operators.Add("-");

            string input = textBox.Text;
            int result = 0;

            List<string> outputQueue = new List<string>();
            List<char> operatorStack = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {

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
                        Debug.WriteLine(numLength + ", coocol , " + num);

                        i += numLength - 1;

                        outputQueue.Add(num);
                    }
                }

                if (operators.Contains(input[i].ToString()))
                {
                    int topOpI = operators.IndexOf(operatorStack[operatorStack.Count - 1].ToString());
                    int curOpI = operators.IndexOf(input[i].ToString());
                    //TODO: finish implementing shunting yard
                    //TODO: fininsh operator class or something to solve predencence
                    //https://en.wikipedia.org/wiki/Shunting-yard_algorithm#A_simple_conversion
                    //du är här på wikipedia sidan: or (the operator at the top of the operator stack has equal precedence and the token is left associative))
                    while (operatorStack.Count > 0 && (topOpI>curOpI || ()))
                    {

                    }
                }
                

            }
        }
    }
}
