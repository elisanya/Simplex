using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Laba1_Object_
{
    public partial class Object : Form
    {
        private double dt;

        ObjectModel_MySystem_ model, model2;
        int x10ON = 0;
        private double maximum;
        public double Maximum
        {
            get
            {
                return maximum;
            }
            set
            {
                maximum = value > maximum ? value : maximum;
            }
        }

        public Object(double dt)
        {
            this.dt = dt;
            model = new ObjectModel_MySystem_(this.dt);
            model2 = new ObjectModel_MySystem_(this.dt);
            Simplex simplex = new Simplex();
            double[,] limits = new double[,] { { 0.0001, 0.0001, 0 }, { 10, 100, 1 } };
            model2.Regulator.RewriteConfig(simplex.Calc(model.Regulator.GetConfig(), limits));
            InitializeComponent();
            SecondRegConf_label.Text += string.Format("\nKp = {0}\nTi = {1}\nTd = {2}", model2.Regulator.Kp, model2.Regulator.Ti, model2.Regulator.Td);
            autoValue_textBox.Text = model.Zadanie.ToString();
            Kp_textBox.Text = model.Regulator.Kp.ToString();
            Ti_textBox.Text = model.Regulator.Ti.ToString();
            Td_textBox.Text = model.Regulator.Td.ToString();
            chSimulation.Series.Add(new Series());
            chSimulation.Series[0].ChartType = SeriesChartType.Line;
            chSimulation.Series[0].LegendText = "Level \n(before optimization)";
            chSimulation.Series[1].ChartType = SeriesChartType.Line;
            chSimulation.Series[1].LegendText = "Level \n(after optimization)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            model.Input1++;
            model2.Input1++;
            lblInput1.Text = model.Input1.ToString("F2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            model.Input1--;
            model2.Input1--;
            lblInput1.Text = model.Input1.ToString("F2");
        }
        private void tmSimulation_Tick(object sender, EventArgs e)
        {
            lblResult.Text = model.Output.ToString("F2");
            lblInput1.Text = model.Input1.ToString("F2");
            chSimulation.Series[0].Points.AddXY(model.Time, model.GetValue());
            chSimulation.Series[1].Points.AddXY(model.Time, model2.GetValue());
            if (model.Time > 100)
            {
                chSimulation.Series[0].Points.RemoveAt(0);
                chSimulation.Series[1].Points.RemoveAt(0);
            }
            chSimulation.ChartAreas[0].RecalculateAxesScale();
        }

        private void bSpeedUp_Click(object sender, EventArgs e)
        {
            switch (x10ON)
            {
                case 0:
                    tmSimulation.Interval = (int)(dt * 1000) / 10;
                    x10ON = 1;
                    break;
                case 1:
                    tmSimulation.Interval = (int)(dt * 1000);
                    x10ON = 0;
                    break;
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            tmSimulation.Interval = (int)(dt * 1000);
            tmSimulation.Start();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            tmSimulation.Stop();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            tmSimulation.Stop();
            chSimulation.Series[0].Points.Clear();
            chSimulation.Series[1].Points.Clear();
            model.Reset();
            model2.Reset();
            tmSimulation.Start();
        }

        private void isManual_checkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            model.IsManual = isManual_checkBox.Checked;
            model2.IsManual = isManual_checkBox.Checked;
            Xin1High_button4.Visible = isManual_checkBox.Checked;
            Xin1Low_button.Visible = isManual_checkBox.Checked;
            autoValue_textBox.Visible = !isManual_checkBox.Checked;
            Kp_textBox.Visible = !isManual_checkBox.Checked;
            Kp_label.Visible = !isManual_checkBox.Checked;
            Ti_textBox.Visible = !isManual_checkBox.Checked;
            Ti_label.Visible = !isManual_checkBox.Checked;
            Td_textBox.Visible = !isManual_checkBox.Checked;
            Td_label.Visible = !isManual_checkBox.Checked;
            Set_button.Visible = !isManual_checkBox.Checked;
            if (isManual_checkBox.Checked)
            {
                isManual_checkBox.Text = "Manual";
            }
            else
            {
                isManual_checkBox.Text = "Auto";
                autoValue_textBox.Text = model.Zadanie.ToString("F2");
            }
        }

        private void Set_button_Click(object sender, EventArgs e)
        {
            try
            {
                model.Zadanie = double.Parse(autoValue_textBox.Text);
                model2.Zadanie = double.Parse(autoValue_textBox.Text.Replace('.', ','));
            }
            catch
            {
                MessageBox.Show("Uncorrect value for Zadanie");
            }
            try
            {
                model.Regulator.Kp = double.Parse(Kp_textBox.Text.Replace('.', ','));
            }
            catch
            {
                MessageBox.Show("Uncorrect value for Kp");
            }
            try
            {
                model.Regulator.Ti = double.Parse(Ti_textBox.Text.Replace('.', ','));
            }
            catch
            {
                MessageBox.Show("Uncorrect value for Ti");
            }
            try
            {
                model.Regulator.Td = double.Parse(Td_textBox.Text.Replace('.', ','));
            }
            catch
            {
                MessageBox.Show("Uncorrect value for Td");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.Input2--;
            model2.Input2--;
            label1.Text = model.Input2.ToString("F2");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblInput1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            model.Input2++;
            model2.Input2++;
            label1.Text = model.Input2.ToString("F2");
        }
    }
}
