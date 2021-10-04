using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace stockMaster
{
    public partial class frmAmendRow : Form
    {
        public double cost_price { get; set; }
        public frmAmendRow(DataTable currentRow)
        {
            InitializeComponent();
            dataGridView1.DataSource = currentRow;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ReadOnly = true;

        }

        private void frmAmendRow_Shown(object sender, EventArgs e)
        {
            //work out if its quantity/price/null

            string stringQuantity = "";
            double  quantity = 0;
            cost_price = 0;

            stringQuantity = dataGridView1.Rows[0].Cells[2].Value.ToString();
            if (string.IsNullOrEmpty(stringQuantity))
            {
                //is null
                lblInfo.Text = "This row has returned a null error, this cannot be bypassed as it will cause errors during the upload.";
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                btnBypass.Enabled = false;
            }
            else
                quantity = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);

            //get total cost_price of the stock update 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COALESCE([cost_price],0) from dbo.[stock] where [stock_code] =  '" + dataGridView1.Rows[0].Cells[0].Value.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cost_price = Convert.ToDouble(cmd.ExecuteScalar());
                }
                conn.Close();
            }

            if (quantity > 5000)
            {
                lblInfo.Text = "This row has a quantity over 5000" + Environment.NewLine + "Please amend the quantity or bypass this row.";
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                //check if its also OVER price
                if ((quantity * cost_price) > 5000)
                {
                    //it is both over the quantity and cost price
                    lblInfo.Text = "This row has a quantity over 5000 and a total value of over £5000." + Environment.NewLine + "Please amend the quantity or bypass this row.";
                    dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Goldenrod;
                }
            }
            else if ((quantity * cost_price) > 5000)
            {
                //it is both over the quantity and cost price
                lblInfo.Text = "This row has a quantity over 5000 and a total value of over £5000" + Environment.NewLine + "Please amend the quantity or bypass this row.";
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Goldenrod;
            }
            txtQuantity.Focus();
            dataGridView1.ClearSelection();
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            CONNECT.changeQuantity = false;
            if (txtQuantity.Text.Length < 1)
                return;
            //if new qty < 5000 AND the new price is also less than £5000 then we can close form and go next
            //if new qty < 5000 and the new price is more than £5000 then we need to prompt for bypass button
            //if new qty > 5000 also prompt for bypass button
            int valid = 0, bypass = 0;
            double quantity = Convert.ToDouble(txtQuantity.Text);
            if (quantity < 5000 && (quantity * cost_price) < 5000)
            {
                CONNECT.newQuantity = quantity;
                DialogResult result = MessageBox.Show("Are you sure you want to amend the quantiy from: " + dataGridView1.Rows[0].Cells[2].Value.ToString() + " to: " + quantity + "?", "Amend Quantity", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CONNECT.changeQuantity = true;
                    this.Close();
                }
                else
                {
                    CONNECT.changeQuantity = false;
                }
            }
            else if (quantity < 5000 && (quantity * cost_price) > 5000)
            {
                CONNECT.changeQuantity = true;
                CONNECT.newQuantity = quantity;
                //we cant exit out straight away here becasue we need the user to hit bypass (will still edit the quantity)
                MessageBox.Show("The quantity has been amended to a value less then the warning limit however the total cost is currently over the limit (£" + (quantity * cost_price).ToString() + ")." + Environment.NewLine + "If this value is correct then please hit bypass to amend the quantity and ignore the new cost.");
            }
            else if (quantity > 5000 && (quantity * cost_price) < 5000)
            {
                CONNECT.changeQuantity = true;
                CONNECT.newQuantity = quantity;
                //we cant exit out straight away here becasue we need the user to hit bypass (will still edit the quantity)
                MessageBox.Show("The quantity has been amended to a value over the warning limit." + Environment.NewLine + "If this value is correct then please hit bypass to amend the quantity and ignore the warning.");
            }
            else if (quantity > 5000 && (quantity * cost_price) > 5000)
            {
                CONNECT.changeQuantity = true;
                CONNECT.newQuantity = quantity;
                //we cant exit out straight away here becasue we need the user to hit bypass (will still edit the quantity)
                MessageBox.Show("The quantity has been amended to a value over the warning limit, this has also put the total cost over the warning limit (£" + (quantity * cost_price).ToString() + ")." + Environment.NewLine + "If these value are correct then please hit bypass to amend the quantity and ignore the new quantity and cost.");
            }
            else
            {
                //should never be here 
                MessageBox.Show("ERROR");
            }



        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnBypass_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to bypass this row?", "Bypass", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CONNECT.bypass = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.bypass = false;
            CONNECT.changeQuantity = false;
            CONNECT.newQuantity = 0;
            this.Close();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAmend.PerformClick();
        }
    }
}
