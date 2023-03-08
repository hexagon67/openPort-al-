namespace openPort_al_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            label3 = new Label();
            bt_submit = new Button();
            tb_udp = new TextBox();
            label2 = new Label();
            tb_tcp = new TextBox();
            label1 = new Label();
            openPortBindingSource = new BindingSource(components);
            openPortBindingSource1 = new BindingSource(components);
            ep = new ErrorProvider(components);
            b_open = new Button();
            b_close = new Button();
            dgw_ports = new DataGridView();
            port = new DataGridViewTextBoxColumn();
            protocol = new DataGridViewTextBoxColumn();
            status = new DataGridViewImageColumn();
            changeState = new DataGridViewButtonColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)openPortBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)openPortBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgw_ports).BeginInit();
            this.Icon = Properties.Resources.logo;
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(bt_submit);
            groupBox1.Controls.Add(tb_udp);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tb_tcp);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(22, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(299, 119);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input ports here:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 92);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 5;
            label3.Text = "e.g. Ports '3-5, 8'";
            // 
            // bt_submit
            // 
            bt_submit.Location = new Point(200, 88);
            bt_submit.Name = "bt_submit";
            bt_submit.Size = new Size(75, 23);
            bt_submit.TabIndex = 4;
            bt_submit.Text = "submit";
            bt_submit.UseVisualStyleBackColor = true;
            bt_submit.Click += bt_submit_Click;
            // 
            // tb_udp
            // 
            tb_udp.Location = new Point(78, 59);
            tb_udp.Name = "tb_udp";
            tb_udp.Size = new Size(197, 23);
            tb_udp.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "UDP Ports:";
            // 
            // tb_tcp
            // 
            tb_tcp.Location = new Point(78, 30);
            tb_tcp.Name = "tb_tcp";
            tb_tcp.Size = new Size(197, 23);
            tb_tcp.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "TCP Ports:";
            // 
            // openPortBindingSource
            // 
            openPortBindingSource.DataSource = typeof(openPort);
            // 
            // openPortBindingSource1
            // 
            openPortBindingSource1.DataSource = typeof(openPort);
            // 
            // ep
            // 
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.ContainerControl = this;
            // 
            // b_open
            // 
            b_open.Location = new Point(237, 441);
            b_open.Name = "b_open";
            b_open.Size = new Size(75, 23);
            b_open.TabIndex = 2;
            b_open.Text = "open ports";
            b_open.UseVisualStyleBackColor = true;
            b_open.Click += b_open_Click;
            // 
            // b_close
            // 
            b_close.Location = new Point(156, 441);
            b_close.Name = "b_close";
            b_close.Size = new Size(75, 23);
            b_close.TabIndex = 3;
            b_close.Text = "close ports";
            b_close.UseVisualStyleBackColor = true;
            b_close.Click += b_close_Click;
            // 
            // dgw_ports
            // 
            dgw_ports.AllowUserToAddRows = false;
            dgw_ports.AllowUserToDeleteRows = false;
            dgw_ports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgw_ports.Columns.AddRange(new DataGridViewColumn[] { port, protocol, status, changeState });
            dgw_ports.Location = new Point(32, 156);
            dgw_ports.Name = "dgw_ports";
            dgw_ports.ReadOnly = true;
            dgw_ports.RowHeadersVisible = false;
            dgw_ports.RowTemplate.Height = 25;
            dgw_ports.ScrollBars = ScrollBars.Vertical;
            dgw_ports.Size = new Size(280, 277);
            dgw_ports.TabIndex = 1;
            dgw_ports.CellContentClick += dgw_b_changeState;
            // 
            // port
            // 
            port.HeaderText = "Port";
            port.Name = "port";
            port.ReadOnly = true;
            port.Width = 93;
            // 
            // protocol
            // 
            protocol.HeaderText = "protocol";
            protocol.Name = "protocol";
            protocol.ReadOnly = true;
            protocol.Width = 70;
            // 
            // status
            // 
            status.HeaderText = "";
            status.Name = "status";
            status.ReadOnly = true;
            status.ToolTipText = "\"\"";
            status.Width = 15;
            // 
            // changeState
            // 
            changeState.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            changeState.HeaderText = "open/close";
            changeState.Name = "changeState";
            changeState.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 476);
            Controls.Add(b_close);
            Controls.Add(b_open);
            Controls.Add(dgw_ports);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "openPort(al)";
            FormClosed += Form1_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)openPortBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)openPortBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgw_ports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox tb_udp;
        private Label label2;
        private TextBox tb_tcp;
        private Button bt_submit;
        private BindingSource openPortBindingSource;
        private BindingSource openPortBindingSource1;
        private ErrorProvider ep;
        private Button b_close;
        private Button b_open;
        private Label label3;
        private DataGridView dgw_ports;
        private DataGridViewTextBoxColumn port;
        private DataGridViewTextBoxColumn protocol;
        private DataGridViewImageColumn status;
        private DataGridViewButtonColumn changeState;
    }
}