using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace stockMaster
{
    public partial class frmExport : Form
    {
        public frmExport(DataTable dt)
        {
            InitializeComponent();

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
