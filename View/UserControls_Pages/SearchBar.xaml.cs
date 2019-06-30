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

namespace QLK_Dn.UserControls_Pages
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {
        private static TextBox gl_search;

        public static TextBox Gl_search
        {
            get { return SearchBar.gl_search; }
            set { SearchBar.gl_search = value;}
        }

        public SearchBar()
        {
            InitializeComponent();

            Gl_search = tb_Search;
        }
       
    }
}
