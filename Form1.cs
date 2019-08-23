using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileCopy
{
    public partial class Form1 : Form
    {
        OpenFileDialog openImg = new OpenFileDialog();
        string name = "";
        string path = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openImg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openImg.FileName);
                name = openImg.SafeFileName;
                label1.Text = name;
                path = openImg.FileName;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string destiPath = "Pics";
                if (!string.IsNullOrEmpty(path))
                {
                    string sourcePath = path;
                    if (!Directory.Exists(destiPath))
                    {
                        Directory.CreateDirectory(destiPath);

                    }

                    File.Copy(sourcePath, Path.Combine(destiPath,name));
                    MessageBox.Show("Success");
                    clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }

        private void clear()
        {
            this.pictureBox1.Image = null;

        }
    }
}
