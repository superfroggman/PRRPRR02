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
                {"7", "8", "9"},
                {"4", "5", "6"},
                {"1", "2", "3"},
                {"", "0", ""}
            };

            //Create buttons 1-9
            for (int i = 1; i <= 9; i++)
            {
                var button = new Button();
                button.SetValue(Grid.ColumnProperty, (i-1)%3);
                button.SetValue(Grid.RowProperty, (i-1)/3);
                button.SetValue(ContentProperty, i);
                mainGrid.Children.Add(button);
            }

        }
    }
}
