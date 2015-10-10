using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Firstuwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public bool sentinela { get; set; } = true;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void PiscarLed(int port)
        {
            var con = Windows.Devices.Gpio.GpioController.GetDefault();
            var pin = con.OpenPin(port);
            pin.SetDriveMode(Windows.Devices.Gpio.GpioPinDriveMode.Output);

            while (sentinela)
            {
                // System.Threading.Tasks.Task.Delay(1000); 
                pin.Write(Windows.Devices.Gpio.GpioPinValue.High);
                System.Threading.Tasks.Task.Delay(1000).Wait();
                pin.Write(Windows.Devices.Gpio.GpioPinValue.Low);
                System.Threading.Tasks.Task.Delay(1000).Wait();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int port = 26;
            Int32.TryParse(this.textBox.Text, out port);
            Task.Run(() => PiscarLed(port));
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.sentinela = false;
        }
    }
}
