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

namespace Lab6_Wpf
{      class WeatherControl:DependencyObject
    {
        private int windspeed;
        private string winddirection;

        public string WindDirection
        {
            get => winddirection;
            set => winddirection = value;
        }

        public int WindSpeed
        {  get
            {
                return windspeed;
            }
        set { if (value>0 && value<70)
                { windspeed = value; }
            else { windspeed = 0; }
            }
        }
        public WeatherControl(string WindDirection, int WindSpeed, int Temperature)
        { this.WindDirection = winddirection;
            this.WindSpeed = windspeed;           
        }
        enum Precipitation
        { Sunny=0,
        Cloudy=1,
        Rain=2,
        Snow=3 }
        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
            
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
               nameof(Temperature),
               typeof(int),
               typeof(WeatherControl),
               new FrameworkPropertyMetadata(
                   0,
                   FrameworkPropertyMetadataOptions.AffectsMeasure |
                   FrameworkPropertyMetadataOptions.AffectsRender,
                   null,
                   new CoerceValueCallback(CoerceTemperature)),
               new ValidateValueCallback(ValidateTemperature));
            }

        private static bool ValidateTemperature(object value)
        {
            int t = (int) value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int) baseValue;
            if (t >= -50 && t <= 50)
                return t;
            else
                return 0;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
