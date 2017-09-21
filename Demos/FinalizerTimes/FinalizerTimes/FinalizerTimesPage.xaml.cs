using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace FinalizerTimes
{
    public class Dummy
    {
        int value;

        ~Dummy()
        {
            
        }
    }

    public partial class FinalizerTimesPage : ContentPage
    {
        public FinalizerTimesPage ()
        {
            InitializeComponent ();
        }

        void OnAllocObjects(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew ();
            for (int i = 0; i < 1000000; i++) {
                var d = new Dummy ();
                GC.SuppressFinalize (d);
            }
            sw.Stop ();
            TotalTimeLabel.Text = sw.Elapsed.ToString();
        }
    }
}

