using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public MainPage()
        {
            this.InitializeComponent();

            this.PiscarLed();
        }

        private void PiscarLed()
        {
            var con = Windows.Devices.Gpio.GpioController.GetDefault();
            var pin = con.OpenPin(26);
            pin.SetDriveMode(Windows.Devices.Gpio.GpioPinDriveMode.Output);
 

            while (true)
            {
               // System.Threading.Tasks.Task.Delay(1000); 
                pin.Write(Windows.Devices.Gpio.GpioPinValue.High);
                System.Threading.Tasks.Task.Delay(1000).Wait();
                pin.Write(Windows.Devices.Gpio.GpioPinValue.Low);
                System.Threading.Tasks.Task.Delay(1000).Wait();
            }





           
           
        }
    }
}
