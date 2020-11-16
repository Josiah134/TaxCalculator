using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxCalculator
{
	public partial class TaxCalculator : Form
	{
		public TaxCalculator()
		{
			InitializeComponent();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(checkBox1.Checked)
			{
				string externalip = new WebClient().DownloadString("http://icanhazip.com");
				var web = new WebClient();
				var url = $"http://ip-api.com/line/" + externalip;
				var responseString = web.DownloadString(url);
				String[] rsplit = responseString.Split('\n');
				comboBox1.SelectedItem = rsplit[4];
				string state = comboBox1.SelectedItem.ToString();
				int counter = 0;
				string line;

				System.IO.StreamReader file = new System.IO.StreamReader(@"Taxes.txt");
				while ((line = file.ReadLine()) != null)
				{
					String[] split = line.Split(':');
					if (split[0] == state)
					{
						decimal output = decimal.Parse(textBox1.Text) * decimal.Parse(split[1]) / 100;
						textBox2.Text = output.ToString();
						break;
					}
					counter++;
				}

			}
			else
			{
				string state = comboBox1.SelectedItem.ToString();
				int counter = 0;
				string line;

				System.IO.StreamReader file = new System.IO.StreamReader(@"Taxes.txt");
				while ((line = file.ReadLine()) != null)
				{
					String[] split = line.Split(':');
					if (split[0] == state)
					{
						decimal output = decimal.Parse(textBox1.Text) * decimal.Parse(split[1]) / 100;
						textBox2.Text = output.ToString();
						break;
					}
					counter++;
				}
			}
		}
	}
}
