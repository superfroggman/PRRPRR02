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
using System.Windows.Threading;
using System.Diagnostics;

namespace Slutprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<IGotchi> gotchis = new List<IGotchi>();
        List<GotchiButton> gotchiButtons = new List<GotchiButton>();
        int selectedIndex = 0;

        DispatcherTimer Timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            gotchis.Add(new Dog("dog"));
            gotchiButtons.Add(new GotchiButton("dog1"));

            gotchis.Add(new Fishy("fish"));
            gotchiButtons.Add(new GotchiButton("fish1"));

            //TODO: add images to buttons
            for(int i = 0; i<gotchiButtons.Count; i++)
            {
                var gotchiButton = gotchiButtons[i];
                var button = new Button();

                button.Content = gotchiButton.iconLocation;
                button.SetValue(Grid.ColumnProperty, i);
                button.Click += new RoutedEventHandler(OnGotchiButtonClicked);

                gotchiButtonGrid.Children.Add(button);
            }

            //https://www.c-sharpcorner.com/blogs/digital-clock-in-wpf1
            Timer.Tick += new EventHandler(OnTimeStep);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer.Start();
        }

        private void OnTimeStep(object sender, EventArgs e)
        {
            for (int i = 0; i < gotchis.Count; i++)
            {
                if (gotchis[i].UpdateStatuses(1))
                {
                    gotchis.RemoveAt(i);
                    i--;//Otherwise when removing it will skip one gotchi
                    Debug.WriteLine("ded");
                    continue;
                }
            }

            UpdateGUI();
        }

        private void UpdateGUI()
        {
            //Update gotchi text
            currentGotchiText.Text = gotchis[selectedIndex].name;

            //Add relevant status buttons
            statusButtonGrid.Children.Clear();
            List<int> statuses = gotchis[selectedIndex].GetStatuses();
            for (int i = 0; i < statuses.Count; i++)
            {
                var button = new Button();

                button.Content = statuses[i];
                button.SetValue(Grid.RowProperty, i);
                button.Click += new RoutedEventHandler(OnStatusButtonClicked);

                statusButtonGrid.Children.Add(button);
            }

            //Add correct and updated progress bars
            statusBarGrid.Children.Clear();
            for (int i = 0; i < gotchis[selectedIndex].GetStatuses().Count; i++)
            {
                ProgressBar bar = new ProgressBar();
                bar.SetValue(Grid.RowProperty, i);
                bar.Value = gotchis[i].GetStatuses()[i];

                statusBarGrid.Children.Add(bar);
            }
        }

        private void OnGotchiButtonClicked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                int index = (int)button.GetValue(Grid.ColumnProperty); //TODO: make better way of finding out index

                selectedIndex = index;
            }
        }

        private void OnStatusButtonClicked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                int index = (int)button.GetValue(Grid.ColumnProperty); //TODO: make better way of finding out index
                Debug.WriteLine(index);
                gotchis[selectedIndex].UpdateStatuses(-20);
            }
        }
    }
}
