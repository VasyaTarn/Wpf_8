using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Wpf_8
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isDragging = false;
        private Point clickPosition;

        private double x;
        private double y;

        public double X
        {
            get { return Math.Round(x, 0); }
            set { x = value; NotifyPropertyChanged(); }
        }

        public double Y
        {
            get { return Math.Round(y, 0); }
            set { y = value; NotifyPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Cube_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            clickPosition = e.GetPosition(canvas);
            ((FrameworkElement)sender).CaptureMouse();
        }

        private void Cube_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            ((FrameworkElement)sender).ReleaseMouseCapture();
        }

        private void Cube_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var currentPosition = e.GetPosition(canvas);
                var offset = currentPosition - clickPosition;

                X += offset.X;
                Y += offset.Y;

                clickPosition = currentPosition;
            }
        }

    }
}
