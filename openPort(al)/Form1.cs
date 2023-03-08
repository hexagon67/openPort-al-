using System.Drawing;
using System.Linq;

namespace openPort_al_
{
    public partial class Form1 : Form
    {
        bool portsValidated = false;
        int[] tcpPorts;
        int[] udpPorts;
        openPort openPortClass = new openPort();
        List<int> portRowIndex = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_submit_Click(object sender, EventArgs e)
        {
            b_close_Click(sender, e);
            portsValidated = false;
            ep.Clear();
            portRowIndex.Clear();
            dgw_ports.Rows.Clear();
            //Validate Input
            try
            {
                tcpPorts = Program.stringToPorts(tb_tcp.Text);
            }
            catch (ArgumentException ex)
            {
                ep.SetError(tb_tcp, ex.Message);
                return;
            }
            try
            {
                udpPorts = Program.stringToPorts(tb_udp.Text);
            }
            catch (ArgumentException ex)
            {
                ep.SetError(tb_udp, ex.Message);
                return;
            }
            //Make sure that TCP and UDP Ports aren't opened simultaneously
            foreach (int portT in tcpPorts)
            {
                foreach (int portU in udpPorts)
                {
                    if (portT == portU)
                    {
                        ep.SetError(bt_submit, "Ports can't be opened with UDP and TCP simultaneously");
                        return;
                    }
                }
            }
            if (tcpPorts.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                ep.SetError(tb_tcp, "Please remove dublicates");
                return;
            }
            if (udpPorts.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                ep.SetError(tb_udp, "Please remove dublicates");
                return;
            }
            portsValidated = true;

            //Show in Grid
            int rowIndex = 0;

            foreach (int portT in tcpPorts)
            {
                object[] temp = { portT.ToString(), "TCP" };
                portRowIndex.Add(portT);
                rowIndex++;
                dgw_ports.Rows.Add(temp);
                portOpenedCallback(portT, false);
            }
            foreach (int portU in udpPorts)
            {
                object[] temp = { portU.ToString(), "UDP" };
                portRowIndex.Add(portU);
                rowIndex++;
                dgw_ports.Rows.Add(temp);
                portOpenedCallback(portU, false);
            }
        }

        public void portOpenedCallback(int port, bool opened)
        {
            int index = -1;
            for (int i = 0; i < portRowIndex.Count; i++)
            {
                if (portRowIndex[i] == port) index = i;
            }

            Console.Write(port.ToString());
            Console.Write(", ");
            Console.WriteLine(index.ToString());

            if (index >= 0)
            {
                if (opened)
                {
                    dgw_ports.Rows[index].Cells[2].Value = Properties.Resources.statusGreen;
                    dgw_ports.Rows[index].Cells[2].ToolTipText = "opened";
                    dgw_ports.Rows[index].Cells[3].Value = "close";
                }
                else
                {
                    dgw_ports.Rows[index].Cells[2].Value = Properties.Resources.statusRead;
                    dgw_ports.Rows[index].Cells[2].ToolTipText = "closed";
                    dgw_ports.Rows[index].Cells[3].Value = "open";
                }
            }
        }

        private void b_open_Click(object sender, EventArgs e)
        {
            if (portsValidated)
            {
                //open Ports
                Task[] tcpTasks = Program.openPorts(tcpPorts, Mono.Nat.Protocol.Tcp, openPortClass, this);
                Task[] udpTasks = Program.openPorts(udpPorts, Mono.Nat.Protocol.Udp, openPortClass, this);
            }
        }

        private void b_close_Click(object sender, EventArgs e)
        {
            if (tcpPorts != null && udpPorts != null)
            {
                //close Ports
                Task[] tcpTasks = Program.closePorts(tcpPorts, Mono.Nat.Protocol.Tcp, openPortClass, this);
                Task[] udpTasks = Program.closePorts(udpPorts, Mono.Nat.Protocol.Udp, openPortClass, this);
            }

        }

        private void dgw_b_changeState(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int rowIndex = e.RowIndex;
                int[] port = {int.Parse(dgw_ports[0, rowIndex].Value.ToString())};
                Mono.Nat.Protocol protocol;
                if (dgw_ports[1, rowIndex].Value.ToString() == "TCP")
                {
                    protocol = Mono.Nat.Protocol.Tcp;
                } else
                {
                    protocol = Mono.Nat.Protocol.Udp;
                }

                if (dgw_ports[3, rowIndex].Value.ToString() == "open")
                {
                    Program.openPorts(port, protocol, openPortClass, this);
                } else
                {
                    Program.closePorts(port, protocol, openPortClass, this);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            b_close_Click(sender, e);
        }

    }
}