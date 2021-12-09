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

namespace WpfApp14
{
    public class DataModel
    {
        public string fileName { get; set; }
        public SolidColorBrush color { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Show();
        }

        private void Show()
        {
            const int TotalCount = 100;
            for (int i = 0; i < TotalCount; i++)
            {
                ContentControl cc = new ContentControl();
                cc.ContentTemplate = this.Resources["singleUnit"] as DataTemplate;
                DataModel dm = new DataModel();
                dm.fileName = "myfile" + i;
                dm.color = new SolidColorBrush(Colors.Blue);
                cc.Content = dm;
                MyListBox.Items.Add(cc);
            }

            MyListBox.ScrollIntoView(MyListBox.Items[TotalCount / 2]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Do something to change all fileName items' forground color to red.
            // For example if user changes the color theme, and we should just change some UI color
            // while not changing any other part, e.g. the position of scrollbar
        }
    }
}
