namespace openPort_al_;
using Mono.Nat;
using System.Collections;
using System.Linq;


internal class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }

    public static Task[] openPorts(int[] ports, Mono.Nat.Protocol protocol, openPort portClass, Form1 form)
    {
        var taskArray = new ArrayList();
        foreach (var port in ports)
        {
            Task openPortTask = portClass.portOpen(port, protocol);
            openPortTask.ContinueWith(task => { form.portOpenedCallback(port, true); });
            taskArray.Add(openPortTask);
        }
        return (Task[]) taskArray.ToArray(typeof(Task));
    }

    public static Task[] closePorts(int[] ports, Mono.Nat.Protocol protocol, openPort portClass, Form1 form)
    {
        var taskArray = new ArrayList();
        foreach (var port in ports)
        {
            Task openPortTask = portClass.portClose(port, protocol);
            openPortTask.ContinueWith(task => { form.portOpenedCallback(port, false); });
            taskArray.Add(openPortTask);
        }
        return (Task[])taskArray.ToArray(typeof(Task));
    }

    //Converts String of ports to Array of Ports
    public static int[] stringToPorts(string portsString)
    {
        if (!string.IsNullOrEmpty(portsString))
        {
            var portsString_ = portsString.Replace(" ", String.Empty);
            Console.WriteLine(portsString_);
            string[] portsWithoutComma = portsString_.Split(",");

            var portList = new ArrayList();
            foreach (var port in portsWithoutComma)
            {
                string[] portRange = port.Split("-");
                foreach (var obj in portRange)
                {
                    if (string.IsNullOrEmpty(obj)) throw new ArgumentException("Please input a number", port);
                    if (!obj.All(char.IsDigit)) throw new ArgumentException("Not a Number", port);
                }
                
                if (portRange.Length == 2)
                {
                    if (int.Parse(portRange[0]) > int.Parse(portRange[1])) throw new ArgumentException("Range is the wrong way around", port);
                    for (int i = int.Parse(portRange[0]); i <= int.Parse(portRange[1]); i++)
                    {
                        portList.Add(i);
                        Console.WriteLine(i);
                    }
                }
                else if (portRange.Length == 1)
                {
                    portList.Add(int.Parse(portRange[0]));
                    Console.WriteLine(portRange[0]);
                }
                else
                {
                    throw new ArgumentException("Ports not listed as descibed", port);
                }
            }
            return (int[])portList.ToArray(typeof(int));
        }
        return new int[0];
    }
}

//Task openPortsTask = portClass.openPorts(21, Protocol.Udp);
