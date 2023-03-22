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
using Shapes_Publisher.View;
using Shapes_Publisher.ViewModel;

namespace Shapes_Publisher.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShapesView : Window
    {
        ShapeViewModel vm;
        public ShapesView()
        {
            InitializeComponent();
            DataContext = vm = new ShapeViewModel();
        }

    }
}
