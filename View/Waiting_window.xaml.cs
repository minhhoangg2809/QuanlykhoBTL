using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QLK_Dn.View
{
    /// <summary>
    /// Interaction logic for Waiting_window.xaml
    /// </summary>
    public partial class Waiting_window : Window
    {
        private Thread thread;

        public Waiting_window()
        {
            InitializeComponent();
            Loaded += Waiting_window_Loaded;
            StartCloseTimer();
        }

        private void Waiting_window_Loaded(object sender, RoutedEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }

            thread = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    slider.Dispatcher.Invoke(() => slider.Value = i);
                }

            }));

            thread.IsBackground = true;
            thread.Start();
        }

        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(6d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }
    }
}

