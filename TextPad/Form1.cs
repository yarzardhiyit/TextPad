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

namespace TextPad
{
    public partial class Form1 : Form
    {
        StreamReader sr;
        StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "";

            openFileDialog1.Filter = "Text File (*.txt) | *.txt| All File (*.*) | *.*";
            openFileDialog1.InitialDirectory = @"Documents";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.SafeFileName + " - TextPad"; 
                //1. "this" refer to this form.
                //2. "openFileDialog2.SafeFileName" to display only filename
                sr = new StreamReader(openFileDialog1.FileName.ToString()); 
                text = sr.ReadToEnd();
                txtArea.Text = text;
                sr.Close();
            }
        }

        public void saveTxtFile()
        {
            string text = "";

            saveFileDialog1.Filter = "Text File (*.txt) | *.txt| All File (*.*) | *.*";
            saveFileDialog1.InitialDirectory = @"Documents";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog1.FileName);
                text = txtArea.Text.ToString();
                sw.Write(text);
                sw.Close();
            }

            //To Display Only Saved File Name
            string fi = Path.GetFileName(saveFileDialog1.FileName + " - TextPad");
            this.Text = fi;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTxtFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtArea.Text.ToString() == "")
            {
                txtArea.Clear();
            }
            else
            {
                if (MessageBox.Show("Do you want to Save?","",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    saveTxtFile();
                    txtArea.Clear();
                }
                else
                {
                    txtArea.Clear();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTxtFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                this.txtArea.Font = font;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("App: TextPad \nVersion: 1.0.0.4 \nDeveloped By: yarzardhiyit");
        }
    }
}
