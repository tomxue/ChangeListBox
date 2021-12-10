using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class ViewModelFile : INotifyPropertyChanged
    {
        private string filename;
        private SolidColorBrush solidColorBrush;
        public event PropertyChangedEventHandler PropertyChanged;

        public string FileName
        {
            get => filename;
            set
            {
                filename = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileName)));
            }
        }

        public SolidColorBrush Color
        {
            get => solidColorBrush;
            set
            {
                solidColorBrush = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int count = 0;

        public MainWindow()
        {
            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            const int TotalCount = 100;
            for (int i = 0; i < TotalCount; i++)
            {
                ViewModelFile vm = new ViewModelFile
                {
                    FileName = "myfile" + i,
                    Color = new SolidColorBrush(Colors.Blue)
                };
                MyListBox.Items.Add(vm);
            }
            MyListBox.ScrollIntoView(MyListBox.Items[TotalCount / 2]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count++;

            // Do something to change all fileName items' forground color to red.
            // For example if user changes the color theme, and we should just change some UI color
            // while not changing any other part, e.g. the position of scrollbar
            foreach (var item in MyListBox.Items)
            {
                if (count % 2 == 0)
                    ((ViewModelFile)item).Color = new SolidColorBrush(Colors.Red);
                else
                    ((ViewModelFile)item).Color = new SolidColorBrush(Colors.Blue);
            }
        }
    }
}
