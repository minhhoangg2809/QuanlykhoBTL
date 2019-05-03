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
using System.Windows.Shapes;

namespace QLK_Dn.View.View_Thukho
{
    /// <summary>
    /// Interaction logic for Thungrac.xaml
    /// </summary>
    public partial class Thungrac : Window
    {
        public Thungrac()
        {
            InitializeComponent();
            ButtonOpen.Click += ButtonOpen_Click;
            ButtonClose.Click += ButtonClose_Click;

            Main.Content = new Pages_Thungrac.Mathang_Deleted();
        }

        void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Hidden;
            ButtonOpen.Visibility = Visibility.Visible;

            GridMain.IsEnabled = true;
        }

        void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Visible;
            ButtonOpen.Visibility = Visibility.Hidden;

            GridMain.IsEnabled = false;
        }

        #region xu ly tabcontrol
        private void showunderline(Button btn, Rectangle rec)
        {
            if (btn.Uid == rec.Uid)
            {
                rec.Visibility = Visibility.Visible;
            }
            else
            {
                rec.Visibility = Visibility.Hidden;
            }
        }
        private void selecttab(Button btn, Frame fr)
        {
            string uid = btn.Uid.ToString();
            switch (uid)
            {
                case ("t1"):
                    {
                        fr.Content = new Pages_Thungrac.Mathang_Deleted(); break;
                    };
                case ("t2"):
                    {
                        fr.Content = new Pages_Thungrac.Loaimathang_Deleted(); break;
                    };
                case ("t3"):
                    {
                        fr.Content = new Pages_Thungrac.Donvi_Deleted(); break;
                    };
                case ("t4"):
                    {
                        fr.Content = new Pages_Thungrac.Xuathang_Deleted(); break;
                    };
                case ("t5"):
                    {
                        fr.Content = new Pages_Thungrac.Nhaphang_Deleted(); break;
                    };
                default: break;
            }
        }
        #endregion

        private void btn_tab_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            showunderline(btn, rec1);
            showunderline(btn, rec2);
            showunderline(btn, rec3);
            showunderline(btn, rec4);
            showunderline(btn, rec5);

            selecttab(btn, Main);
        }
    }
}
