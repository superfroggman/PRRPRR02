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

        DispatcherTimer Timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            gotchis.Add(new Dog("cool"));
            gotchis.Add(new Fishy("cat"));

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
            
        }
    }
}
