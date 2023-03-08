using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mono.Nat;

namespace openPort_al_
{
    public class openPort
    {
        private bool deviceFound;
        INatDevice device;

        public openPort()
        {
            NatUtility.DeviceFound += DeviceFound;
            NatUtility.DeviceLost += DeviceLost;
            NatUtility.StartDiscovery();
        }

        //Gets called when Device has been found
        private void DeviceFound(object sender, DeviceEventArgs args)
        {
            this.device = args.Device;
            deviceFound = true;
        }

        //Gets called when Device has been lost
        private void DeviceLost(object sender, DeviceEventArgs args)
        {
            INatDevice device = args.Device;
            deviceFound = false;
        }

        //Waits until device has been found
        private async Task<INatDevice> waitForDevice()
        {
            while (!deviceFound) await Task.Delay(25);
            return device;
        }

        //Opens given Port
        public async Task portOpen(int port, Mono.Nat.Protocol protocol)
        {
            await waitForDevice();
            device.CreatePortMap(new Mapping(protocol, port, port));
            Console.WriteLine("Opened Port " + port);
        }

        //Closes given Port
        public async Task portClose(int port, Mono.Nat.Protocol protocol)
        {
            await waitForDevice();
            device.DeletePortMap(new Mapping(protocol, port, port));
            Console.WriteLine("Closed Port " + port);
        }

    }
}
