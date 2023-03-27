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

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(canvas);
            var selectedShape = lstBox.SelectedItem as Shape;

            if (selectedShape == null) return;
            var shape = Activator.CreateInstance(selectedShape.GetType()) as Shape;

            if (shape == null) return;
            shape.Width = selectedShape.Width;
            shape.Height = selectedShape.Height;
            shape.Stroke = selectedShape.Stroke;

            var size = new Size(selectedShape.Width, selectedShape.Height);
            shape.Measure(size);
            shape.Arrange(new Rect(size));
            shape.UpdateLayout();

            Canvas.SetLeft(shape, position.X);
            Canvas.SetTop(shape, position.Y);

            canvas.Children.Add(shape);
            vm.Publish(shape, position.X, position.Y);
        }
    }
}
