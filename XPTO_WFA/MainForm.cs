using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTO;

namespace XPTO_WFA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "TXT|*.txt";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var tuple = FileReader.OpenFile(openFileDialog.FileName);
                BindingDbSet(tuple);
            }
        }


        private void BindingDbSet(Tuple<XPTOContext, bool> tuple)
        {
            if (tuple.Item2)
            {
                List<Pessoa> pessoas = tuple.Item1.Pessoas.Local.ToList();
                dataGridView1.DataSource = tuple.Item1.Pessoas.Local.ToBindingList();
            }
            else
            {
                dataGridView1.DataSource = tuple.Item1.Produtos.Local.ToBindingList();
            }
        }
    }
}
