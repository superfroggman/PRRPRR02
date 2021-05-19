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
        bool debug = false; //Enable to prevent gotchis dying

        List<IGotchi> gotchis = new List<IGotchi>();
        int selectedIndex = 0;

        DispatcherTimer Timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            //Add gotchis and buttons
            gotchis.Add(new Dog("dog"));

            gotchis.Add(new Fish("fish"));

            AddGotchiButtons();
            AddStatusButtons();

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
                    if (debug)
                    {
                        gotchis[i].UpdateStatuses(-5);
                    }
                    else
                    {
                        HandleDeath(i);
                    }

                    i--;//Otherwise when removing it will skip one gotchi
                    continue;
                }
            }

            UpdateGUI();
        }

        private void HandleDeath(int index)
        {
            gotchis.RemoveAt(index);

            if (selectedIndex > gotchis.Count - 1)
            {
                selectedIndex = gotchis.Count - 1;
            }

            UpdateGUI();
            AddGotchiButtons();
            AddStatusButtons();
        }



        //Updating User Interface
        private void UpdateGUI()
        {
            statusBarGrid.Children.Clear();
            currentGotchiImage.Source = null;

            if (gotchis.Count == 0) return;

            //Add correct and updated progress bars
            for (int i = 0; i < gotchis[selectedIndex].GetStatuses().Count; i++)
            {
                ProgressBar bar = new ProgressBar();
                bar.SetValue(Grid.RowProperty, i);
                bar.Value = ((double)gotchis[selectedIndex].GetStatuses()[i] / (double)gotchis[selectedIndex].maxStatus) * 100;

                statusBarGrid.Children.Add(bar);
            }

            //Update gotchi image
            currentGotchiImage.Source = CreateImageSource(gotchis[selectedIndex].iconLocation);
        }
        private void AddStatusButtons()
        {
            statusButtonGrid.Children.Clear();

            if (gotchis.Count == 0) return;

            //Add relevant status buttons
            List<int> statuses = gotchis[selectedIndex].GetStatuses();
            for (int i = 0; i < statuses.Count; i++)
            {
                var button = new Button();

                button.SetValue(Grid.RowProperty, i);
                button.Click += new RoutedEventHandler(OnStatusButtonClicked);

                statusButtonGrid.Children.Add(button);
            }
        }
        private void AddGotchiButtons()
        {
            gotchiButtonGrid.Children.Clear();

            if (gotchis.Count == 0) return;

            for (int i = 0; i < gotchis.Count; i++)
            {
                var gotchi = gotchis[i];
                var button = new Button();

                button.SetValue(Grid.ColumnProperty, i);
                button.Click += new RoutedEventHandler(OnGotchiButtonClicked);

                Image myImage = new Image();
                myImage.Source = CreateImageSource(gotchis[i].iconLocation);
                button.Content = myImage;

                gotchiButtonGrid.Children.Add(button);
            }
        }



        //Button events
        private void OnGotchiButtonClicked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                int index = (int)button.GetValue(Grid.ColumnProperty);

                selectedIndex = index;

                AddStatusButtons();
            }
        }
        private void OnStatusButtonClicked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                int index = (int)button.GetValue(Grid.RowProperty);

                gotchis[selectedIndex].UpdateStatus(-20, index);
            }
        }



        //Utils
        private BitmapImage CreateImageSource(string uri)
        {
            //Don't ask me why I do this. 
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.image.source?view=net-5.0
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(uri, UriKind.Relative);
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
