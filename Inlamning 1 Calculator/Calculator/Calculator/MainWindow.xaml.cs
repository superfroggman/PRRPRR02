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
                    button.SetValue(Grid.ColumnProperty, j+buttonOffsetX);
                    button.SetValue(Grid.RowProperty, i+buttonOffsetY);
                    button.SetValue(ContentProperty, buttons[i,j]);
                    button.Click += new RoutedEventHandler(Button_Click);
                    mainGrid.Children.Add(button);
                }
            }


            //Create buttons 1-9
            /*
            for (int i = 1; i <= 9; i++)
            {
                var button = new Button();
                button.SetValue(Grid.ColumnProperty, (i-1)%3);
                button.SetValue(Grid.RowProperty, (i-1)/3);
                button.SetValue(ContentProperty, i);
                mainGrid.Children.Add(button);
            }*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is Button button)
            {
                if(button.Content == "=")
                {
                    Calculate();
                    return;
                } else if(button.Content == "C")
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
            string value = new DataTable().Compute(textBox.Text, null).ToString(); //Tydligen får jag inte använda detta så lös nåt annat
            Debug.WriteLine(value);

            textBox.Text = value;
        }
    }
}
