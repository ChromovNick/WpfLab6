using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLab6
{
    enum Precipitation
    {
        sunny = 0,
        cloudy = 1,
        rainy = 2,
        snowy = 3
    }
    class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        private string windDirection;
        private int windSpeed;

        public string WindDiretion { get; set; }
        public int WindSpeed { get; set; }

        public WeatherControl(string winddirection, int windspeed, Precipitation precipitation)
        {
            this.WindDiretion = winddirection;
            this.WindSpeed = windspeed;
            this.precipitation = precipitation;
        }

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
            int v = (int)value;
            if (v>=-50 && v<=50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object basevalue)
        {
            int v = (int)basevalue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }
    }
}
