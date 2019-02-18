using StandartClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private DemoClass demoClass;

		public Form1()
		{
			InitializeComponent();
			demoClass = new DemoClass();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(demoClass.GetString(textBox1.Text));
		}
	}
}
