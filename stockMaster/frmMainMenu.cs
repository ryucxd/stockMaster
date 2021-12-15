using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stockMaster
{
    public partial class frmMainMenu : Form
    {
        public DataTable _backupDT { get; set; }
        public int csvCount { get; set; }
        public int stock_take_type { get; set; }//--1 = full, 2 = incremental, 3 = partial
        public int stock_take_location { get; set; } //1 = tradiitonal, 2 = slimline
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //prompt user to confirm that this current selections are what they want, enable buttons and lock radio buttons

            string prompt = "Are you sure you want to do a ";
            if (chkFull.Checked == true)
            {
                prompt = prompt + "FULL ";
                stock_take_type = 1;
            }
            else if (chkPartial.Checked == true)
            {
                prompt = prompt + "PARTIAL ";
                stock_take_type = 2;
            }
            else
            {
                prompt = prompt + "INCREMENTAL ";
                stock_take_type = 3;
            }

            prompt = prompt + "stock take for ";
            if (chkTraditional.Checked == true)
            {
                prompt = prompt + "TRADITIONAL";
                stock_take_location = 1;
            }
            else
            {
                prompt = prompt + "SLIMLINE";
                stock_take_location = 2;
            }
            prompt = prompt + "? ";

            DialogResult result = MessageBox.Show(prompt, "Are you sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                btnAttachCSV.Enabled = true;
                grpArea.Enabled = false;
                grpType.Enabled = false;
                btnConfirm.Enabled = false;
            }
        }

        private void btnAttachCSV_Click(object sender, EventArgs e)
        {
            btnSnapShot.Enabled = false;
            btnBypass.Enabled = false;
            //if csv has already been entered messagebox to inform the new one will be appended 
            string csvPath = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    insertCSV(openFile.FileName);
                }
                catch
                {
                    MessageBox.Show("There was an error loading this file.");
                    prog.Value = 0;
                    try
                    {
                        dataGridView1.DataSource = _backupDT;
                        dataGridView1.ClearSelection();
                        format();
                    }
                    catch
                    { }
                    return;
                }
            }
            dataGridView1.ClearSelection();
        }

        private void insertCSV(string file)
        {
            string textLine = string.Empty;
            string[] splitLine;
            string sql = "";
            _backupDT = null;
            var dt = new DataTable();
            dt.Columns.AddRange(new[]
                {
                new DataColumn ("Stock Code"),
                new DataColumn ("Item Name"),
                new DataColumn ("QTY"),
                new DataColumn ("UoM"),
                new DataColumn ("Location"),
                new DataColumn ("Time Stamp")});
            dt.Rows.Clear();
            if (csvCount == 0)
            {
                //check if the file exists - read it and insert into datatable
                if (System.IO.File.Exists(file))
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(file);
                    var contents = reader.ReadToEnd();
                    var strReader = new System.IO.StringReader(contents);
                    strReader.ReadLine();
                    do
                    {
                        textLine = strReader.ReadLine();
                        if (textLine != string.Empty)
                        {
                            splitLine = textLine.Split(';');
                            if (splitLine[0] != string.Empty || splitLine[1] != string.Empty) ;
                            dt.Rows.Add(splitLine);
                        }
                    } while (strReader.Peek() != -1);
                }

                //get item name for each stock (looks like its empty by default most of the time
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    prog.Maximum = dt.Rows.Count;
                    prog.Value = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sql = "select [description] from dbo.stock where stock_code = '" + dt.Rows[i][0].ToString() + "'";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            if (dt.Rows[i][1].ToString() == "")
                                dt.Rows[i][1] = Convert.ToString(cmd.ExecuteScalar());
                            prog.Value++;
                        }
                    }
                    conn.Close();
                    prog.Value = dt.Rows.Count - 1;
                }


                dataGridView1.DataSource = dt;
                format();
                prog.Value = 0;
                csvCount++;
                //MessageBox.Show(csvCount.ToString());
            } //if csvcount = 0
            else
            {
                //we need to append to the dgv here
                //loop through current dgv then do the split line stuffs
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //MessageBox.Show(row.Cells[0].Value.ToString());
                    //MessageBox.Show(row.Cells[1].Value.ToString());
                    //MessageBox.Show(row.Cells[2].Value.ToString());
                    //MessageBox.Show(row.Cells[3].Value.ToString());
                    //MessageBox.Show(row.Cells[4].Value.ToString());
                    //MessageBox.Show(row.Cells[5].Value.ToString());
                    DataRow dr = dt.NewRow();
                    dr[0] = row.Cells[0].Value;
                    dr[1] = row.Cells[1].Value;
                    dr[2] = row.Cells[2].Value;
                    dr[3] = row.Cells[3].Value;
                    dr[4] = row.Cells[4].Value;
                    dr[5] = row.Cells[5].Value;
                    dt.Rows.Add(dr);
                }
                _backupDT = dt;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                if (System.IO.File.Exists(file))
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(file);
                    var contents = reader.ReadToEnd();
                    var strReader = new System.IO.StringReader(contents);
                    strReader.ReadLine();
                    do
                    {
                        textLine = strReader.ReadLine();
                        if (textLine != string.Empty)
                        {
                            splitLine = textLine.Split(';');
                            if (splitLine[0] != string.Empty || splitLine[1] != string.Empty) ;
                            dt.Rows.Add(splitLine);
                        }
                    } while (strReader.Peek() != -1);
                }

                //get item name for each stock (looks like its empty by default most of the time
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    prog.Maximum = dt.Rows.Count;
                    prog.Value = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sql = "select [description] from dbo.stock where stock_code = '" + dt.Rows[i][0].ToString() + "'";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            if (dt.Rows[i][1].ToString() == "")
                                dt.Rows[i][1] = Convert.ToString(cmd.ExecuteScalar());
                            prog.Value++;
                        }
                    }
                    conn.Close();
                    prog.Value = dt.Rows.Count - 1;
                }
                dataGridView1.DataSource = dt;
                format();
                prog.Value = 0;
                csvCount++;
            }
            //can make the next button available now
            btnCheckCSV.Enabled = true;
        }

        private void format()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCheckCSV_Click(object sender, EventArgs e) //blue is null  // red is too much quantity //yellow is cost
        {
            //reset label visibility incase its second time checking
            lblQuantity1.Visible = false;
            lblQuantity2.Visible = false;
            lblPrice1.Visible = false;
            lblPrice2.Visible = false;
            lblNull1.Visible = false;
            lblNull2.Visible = false;
            lblBypass1.Visible = false;
            lblBypass2.Visible = false;
            lblInvalid1.Visible = false;
            lblInvalid2.Visible = false;
            lblStockCode1.Visible = false;
            lblStockCode2.Visible = false;
            btnDeleteStockCodes.Visible = false;

            //here we go through all the rows and check if the price or quantity is over a certain limit OR 
            //stock code/quantity are null // blank row etc
            int overQuantity = 0, overPrice = 0, isNull = 0, isBypassed = 0, noStockCode = 0, invalidStockCode = 0;
            double quantity = 0;
            prog.Maximum = dataGridView1.Rows.Count;
            prog.Value = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.DarkSeaGreen)
                {
                    isBypassed++;
                    continue;
                }

                try //try catch for null entries
                {
                    quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);

                    if (quantity > 5000)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        overQuantity++;
                    }
                    else
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Empty;

                    //catch invalid stockcodes

                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        string sql = "select id from dbo.stock where stock_code =  '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            conn.Open();
                            var getdata = cmd.ExecuteScalar();
                            if (getdata == null)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                invalidStockCode++;
                            }
                            conn.Close();

                        }
                    }


                    //check value of this item * quantity
                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        conn.Open();
                        string sql = "SELECT COALESCE([cost_price],0) from dbo.[stock] where [stock_code] =  '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            double price = Convert.ToDouble(cmd.ExecuteScalar());
                            if (quantity * price > 5000)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Goldenrod;
                                overPrice++;
                            }

                        }
                        conn.Close();
                    }
                }
                catch
                {
                    //quantity is prob 0 so we need to mark this row too
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    isNull++;
                }


                //catch for rows with NO stock code (causes big problems
                if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    noStockCode++;
                }


                prog.Value++;
            }
            prog.Value = dataGridView1.Rows.Count - 1;
            //if anything has been coloured we need to first correct/ignore them
            if (isNull > 0 || overPrice > 0 || overQuantity > 0 || noStockCode > 0 || invalidStockCode > 0)
            {
                //build a message to inform how many errord of each kind we have
                btnSnapShot.Enabled = false;
                btnBypass.Enabled = true;
                string message = "Before you can continue with the stock take, you must fix or bypass the warnings found within thethe csv file." + Environment.NewLine;
                if (isNull > 0)
                {
                    message = message + Environment.NewLine + isNull.ToString() + " Null quantity entries.";
                    lblNull1.Visible = true;
                    lblNull2.Visible = true;
                }
                if (overPrice > 0)
                {
                    message = message + Environment.NewLine + overPrice.ToString() + " rows over the price threshold.";
                    lblPrice1.Visible = true;
                    lblPrice2.Visible = true;
                }
                if (overQuantity > 0)
                {
                    message = message + Environment.NewLine + overQuantity.ToString() + " rows over the quantity threshold.";
                    lblQuantity1.Visible = true;
                    lblQuantity2.Visible = true;
                }
                if (isBypassed > 0)
                {
                    message = message + Environment.NewLine + isBypassed.ToString() + " rows bypassed.";
                    lblBypass1.Visible = true;
                    lblBypass2.Visible = true;
                }
                if (noStockCode > 0)
                {
                    message = message + Environment.NewLine + noStockCode.ToString() + " rows without a no stock code entered - these must be fixed in the CSV/data grid view.";
                    lblStockCode1.Visible = true;
                    lblStockCode2.Visible = true;
                    btnDeleteStockCodes.Visible = true;
                }
                if (invalidStockCode > 0)
                {
                    message = message + Environment.NewLine + invalidStockCode.ToString() + " rows with an invalid stock code - these must be fixed in the CSV/data grid view.";
                    lblInvalid1.Visible = true;
                    lblInvalid2.Visible = true;
                }

                prog.Value = prog.Maximum;
                MessageBox.Show(message);
            }
            else
            {
                if (isBypassed > 0)
                {
                    lblBypass1.Visible = true;
                    lblBypass2.Visible = true;
                    prog.Value = prog.Maximum;
                    MessageBox.Show(isBypassed.ToString() + " rows bypassed.");
                }
                btnBypass.Enabled = false;
                btnSnapShot.Enabled = true;
            }
            prog.Value = 0;
            dataGridView1.ClearSelection();
        }

        private void btnBypass_Click(object sender, EventArgs e)
        {
            //run csvcheck before doing this (in the event they have edited the dgv since...
            btnCheckCSV.PerformClick();
            //prompt user for password - open form to edit/bypass all coloured rows.
            frmPassword frm = new frmPassword();
            frm.ShowDialog();

            if (CONNECT.isAdmin == true)
            {
                prog.Value = 0;
                prog.Maximum = dataGridView1.Rows.Count;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.PaleVioletRed || dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.Goldenrod || dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.CornflowerBlue)
                    {
                        var dt = new DataTable();
                        dt.Columns.AddRange(new[]{
                        new DataColumn ("Stock Code"),
                        new DataColumn ("Item Name"),
                        new DataColumn ("QTY"),
                        new DataColumn ("UoM"),
                        new DataColumn ("Location"),
                        new DataColumn ("Time Stamp")});

                        DataRow dr = dt.NewRow();
                        dr[0] = dataGridView1.Rows[i].Cells[0].Value;
                        dr[1] = dataGridView1.Rows[i].Cells[1].Value;
                        dr[2] = dataGridView1.Rows[i].Cells[2].Value;
                        dr[3] = dataGridView1.Rows[i].Cells[3].Value;
                        dr[4] = dataGridView1.Rows[i].Cells[4].Value;
                        dr[5] = dataGridView1.Rows[i].Cells[5].Value;
                        dt.Rows.Add(dr);

                        frmAmendRow frmAm = new frmAmendRow(dt);
                        frmAm.ShowDialog();
                        if (CONNECT.bypass == true)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                            CONNECT.bypass = false;
                        }
                        if (CONNECT.changeQuantity == true)
                        {
                            dataGridView1.Rows[i].Cells[2].Value = CONNECT.newQuantity;
                            CONNECT.changeQuantity = false;
                            CONNECT.newQuantity = 0;
                        }
                    }
                    prog.Value++;
                }
                btnCheckCSV.PerformClick();
            }
            else
            {
                prog.Value = prog.Maximum;
                MessageBox.Show("Aborted!", "Missing/Wrong Password", MessageBoxButtons.OK);
            }
            prog.Value = 0;
            dataGridView1.ClearSelection();
        }

        private void btnSnapShot_Click(object sender, EventArgs e)
        {
            //final csv check --- incase they got past 
            //loop through each of the rows and upload to 
            btnSnapShot.Enabled = false;
            btnCheckCSV.Enabled = false;
            btnAttachCSV.Enabled = false;
            prog.Value = 0;
            prog.Maximum = dataGridView1.Rows.Count;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    using (var command = new SqlCommand("usp_stock_master_snapshot", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add("@stock_take_type", SqlDbType.Int).Value = stock_take_type;
                        command.Parameters.Add("@stock_code", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value;
                        command.Parameters.Add("@quantity", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[2].Value;
                        command.ExecuteNonQuery();
                    }
                    prog.Value++;
                }
                //after upload of stock we need to send an email of it.
                prog.Value = prog.Maximum;
                //--usp_stock_master_snapshot_email
                using (var command = new SqlCommand("usp_stock_master_snapshot_email ", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add("@stock_take_location", SqlDbType.VarChar).Value = stock_take_location;
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            MessageBox.Show("The stock snapshot has been uploaded!", "Upload complete", MessageBoxButtons.OK);
            btnSnapShot.Enabled = false;
            btnUpload.Enabled = true;
            prog.Value = 0;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //to keep this cleaning im thinking private void for each type rather than a huge if - should be better readability for the future unlike the last one
            DialogResult result = MessageBox.Show("Are you sure you want to upload this stock take?", "Stock Upload", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) //all references to dbo.stock in this upload segment are prefixed with [order_database_booking_in_test] - the usp for adding location is commented out (worked in the last stock take program)
            {
                if (stock_take_type == 1)
                    full_stock_take();
                if (stock_take_type == 2)
                    partial_stock_take();
                if (stock_take_type == 3)
                    incremental_stock_take();
                btnUpload.Enabled = false;
                prog.Value = prog.Maximum;
                MessageBox.Show("Upload complete!", "Stock Upload", MessageBoxButtons.OK);
                prog.Value = 0;
                dataGridView1.ClearSelection();
            }
        }

        private void full_stock_take()
        {
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                if (stock_take_location == 1)//traditional
                {
                    //wipe ALL of the traditional stock aside from paint/laser 
                    sql = " update [order_database].dbo.[stock] set amount_in_stock = 0, [location] = '' where (slimline_stock_yn = 0 or slimline_stock_yn is null) AND(paint_identifier = 0 or paint_identifier is null) AND(laser_material_identifier = 0 or laser_material_identifier is null)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                    prog.Value = 0;
                    prog.Maximum = dataGridView1.Rows.Count;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update new quantity
                    {
                        sql = "update [order_database].dbo.[stock] SET amount_in_stock = amount_in_stock + " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " where stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' AND (slimline_stock_yn = 0 or slimline_stock_yn is null) AND (paint_identifier = 0 or paint_identifier is null) AND (laser_material_identifier = 0 or laser_material_identifier is null)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update location ? 
                    {
                        using (var command = new SqlCommand("usp_stock_master_location", conn) //new name but is exactly same as before, nothing rewritten here
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        })
                        {
                            command.Parameters.Add("@datarow_stock", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].ToString();
                            command.Parameters.Add("@datarow_location", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[4].ToString();
                            command.Parameters.Add("@if_number", SqlDbType.VarChar).Value = '2'; //traditional full
                            //command.ExecuteNonQuery();  //no need to test this cause its old code but this does affect live stock so dont run it
                        }
                        prog.Value++;
                    }
                    prog.Value = 0;
                }
                else //slimline
                {
                    //wipe ALL of the slimline stock
                    sql = " update [order_database_booking_in_test].dbo.[stock] set amount_in_stock = 0, [location] = '' where slimline_stock_yn = -1";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                    prog.Value = 0;
                    prog.Maximum = dataGridView1.Rows.Count;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update new quantity
                    {
                        sql = "update [order_database].dbo.[stock] SET amount_in_stock = amount_in_stock + " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " where stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' AND slimline_stock_yn = -1";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update location ? 
                    {
                        using (var command = new SqlCommand("usp_stock_master_location", conn) //new name but is exactly same as before, nothing rewritten here
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        })
                        {
                            command.Parameters.Add("@datarow_stock", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].ToString();
                            command.Parameters.Add("@datarow_location", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[4].ToString();
                            command.Parameters.Add("@if_number", SqlDbType.VarChar).Value = '1'; //slimline full
                            //command.ExecuteNonQuery();  //no need to test this cause its old code but this does affect live stock so dont run it
                        }
                        prog.Value++;
                    }
                    prog.Value = 0;
                }
                conn.Close();
            }
            dataGridView1.ClearSelection();
        }
        private void partial_stock_take() //checking this one
        {
            string sql = "";
            //partial = wipe all the items in the dgv to 0 and then upload new value
            prog.Value = 0;
            prog.Maximum = dataGridView1.Rows.Count;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                if (stock_take_location == 1) //traditional
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {//set all of the live items to 0 that appear in this csv

                        sql = "UPDATE [order_database].dbo.stock SET amount_in_stock = 0, [location] = '' WHERE stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'  AND(slimline_stock_yn = 0 or slimline_stock_yn is null) AND(paint_identifier = 0 or paint_identifier is null) AND(laser_material_identifier = 0 or laser_material_identifier is null)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sql = "UPDATE [order_database].dbo.stock SET amount_in_stock = amount_in_stock + " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " WHERE stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'  AND (slimline_stock_yn = 0 or slimline_stock_yn is null) AND (paint_identifier = 0 or paint_identifier is null) AND (laser_material_identifier = 0 or laser_material_identifier is null)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update location ? 
                    {
                        using (var command = new SqlCommand("usp_stock_master_location", conn) //new name but is exactly same as before, nothing rewritten here
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        })
                        {
                            command.Parameters.Add("@datarow_stock", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            command.Parameters.Add("@datarow_location", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            command.Parameters.Add("@if_number", SqlDbType.VarChar).Value = '4'; //traditional partial
                            //command.ExecuteNonQuery();  //no need to test this cause its old code but this does affect live stock so dont run it
                        }
                        prog.Value++;
                    }
                    prog.Value = 0;
                }
                if (stock_take_location == 2)//slimline
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {//set all of the live items to 0 that appear in this csv

                        sql = "UPDATE [order_database].dbo.stock SET amount_in_stock = 0, [location] = '' WHERE stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'  AND slimline_stock_yn = -1 ";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sql = "UPDATE [order_database].dbo.stock SET amount_in_stock = amount_in_stock + " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " WHERE stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'  AND slimline_stock_yn = -1 ";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update location ? 
                    {
                        using (var command = new SqlCommand("usp_stock_master_location", conn) //new name but is exactly same as before, nothing rewritten here
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        })
                        {
                            command.Parameters.Add("@datarow_stock", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            command.Parameters.Add("@datarow_location", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            command.Parameters.Add("@if_number", SqlDbType.VarChar).Value = '3'; //slimline partial
                            //command.ExecuteNonQuery();  //no need to test this cause its old code but this does affect live stock so dont run it
                        }
                        prog.Value++;
                    }
                    prog.Value = 0;
                }
                conn.Close();
            }
        }
        private void incremental_stock_take()
        {
            string sql = "";
            //only adds to the current value (does not wipe anything to 0)
            prog.Value = 0;
            prog.Maximum = dataGridView1.Rows.Count;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                if (stock_take_location == 1) //traditional
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sql = "update [order_database].dbo.[stock] SET amount_in_stock = amount_in_stock + " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " WHERE stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' AND (slimline_stock_yn = 0 or slimline_stock_yn is null) AND (paint_identifier = 0 or paint_identifier is null) AND (laser_material_identifier = 0 or laser_material_identifier is null)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update location ? 
                    {
                        using (var command = new SqlCommand("usp_stock_master_location", conn) //new name but is exactly same as before, nothing rewritten here
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        })
                        {
                            command.Parameters.Add("@datarow_stock", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            command.Parameters.Add("@datarow_location", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            command.Parameters.Add("@if_number", SqlDbType.VarChar).Value = '6'; //traditional incremental
                            //command.ExecuteNonQuery();  //no need to test this cause its old code but this does affect live stock so dont run it
                        }
                        prog.Value++;
                    }
                    prog.Value = 0;
                }
                if (stock_take_location == 2)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sql = "update [order_database].dbo.[stock] SET amount_in_stock = amount_in_stock + " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " WHERE stock_code = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' AND slimline_stock_yn = -1";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                        prog.Value++;
                    }
                    prog.Value = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) //go through each row and update location ? 
                    {
                        using (var command = new SqlCommand("usp_stock_master_location", conn) //new name but is exactly same as before, nothing rewritten here
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        })
                        {
                            command.Parameters.Add("@datarow_stock", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            command.Parameters.Add("@datarow_location", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            command.Parameters.Add("@if_number", SqlDbType.VarChar).Value = '5'; //traditional incremental
                            //command.ExecuteNonQuery();  //no need to test this cause its old code but this does affect live stock so dont run it
                        }
                        prog.Value++;
                    }
                    prog.Value = 0;
                }
                conn.Close();
            }
        }

        private void btnDeleteStockCodes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will remove all rows with a red back colour. Are you sure you want to do this?", "Remove no stock code entries", MessageBoxButtons.YesNo);
            int count = dataGridView1.Rows.Count;
            int removed = 0;
            prog.Maximum = count;
            prog.Value = 0;
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < count; i++)
                {
                    if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                    {
                        DataGridViewRow delete = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(delete);
                        removed++;
                        i--;
                        count--;
                        prog.Value++;
                    }
                }
                prog.Value = prog.Maximum;
                MessageBox.Show(removed.ToString() + " rows with no stock code have been removed!");
                btnCheckCSV.PerformClick();
            }
        }
    }
}
