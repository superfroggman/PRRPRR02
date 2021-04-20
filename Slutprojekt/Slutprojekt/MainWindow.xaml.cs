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

            gotchis.Add(new Gotchi("cool"));
            gotchis.Add(new FIshy("cat"));

            //https://www.c-sharpcorner.com/blogs/digital-clock-in-wpf1
            Timer.Tick += new EventHandler(OnTimeStep);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer.Start();

        }

        private void OnTimeStep(object sender, EventArgs e)
        {
           

            for (int i = 0; i < gotchis.Count; i++)
            {
                //Debug.WriteLine(gotchis[i].name + " hej " + ((gotchis[i] as ITired)==null));
                if ((gotchis[i] as ITired) != null)
                {
                    if ((gotchis[i] as ITired).ChangeTiredness(1))
                    {
                        gotchis.RemoveAt(i);
                        Debug.WriteLine("ded");
                        continue; //TODO: gör så att detta inte skippar nästa gotchi
                    }
                    Debug.WriteLine((gotchis[i] as ITired).tiredness);
                }
            }
            
        }
    }
}
