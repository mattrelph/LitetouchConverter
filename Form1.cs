/* LitewareConverter 0.1
 * C# - .Net Framework - Windows Forms
 * Converts Old Liteware files into JSON files. The output will be used on a future project.
 * 
 * Accepts Liteware 3  *.lwd (Jet DB SQL) and Liteware 4/5/6 (XML) files and converts them into a plain text JSON object file.
 * 
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LitetouchConverter
{
    public partial class MainWindow : Form
    {
        private Boolean debugFlag = false;

        public MainWindow()
        {
            InitializeComponent();
            if (debugFlag)
            {
                this.sourceFileTextBox.Text = "C:\\Users\\myuser\\Documents\\test.lwd";
                this.destinationFileTextBox.Text = "C:\\Users\\myuser\\Documents\\test.json";

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void sourceFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.sourceFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.sourceFileTextBox.Text = sourceFileDialog.FileName;
            }
        }

        private void destinationFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.destinationFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.destinationFileTextBox.Text = destinationFileDialog.FileName;
            }
        }

        private void sourceFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((this.sourceFileTextBox.TextLength != 0) && (this.destinationFileTextBox.TextLength != 0))
            {
                this.infoTextBox.Text = "Source and Destination entered: Ready to Convert\r\n";
                this.convertButton.Enabled = true;
            }
            else
            {
                this.infoTextBox.Text = "Need Source and Destination to Convert\r\n";
                this.convertButton.Enabled = false;
            }
        }

        private void destinationFileTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((this.sourceFileTextBox.TextLength != 0) && (this.destinationFileTextBox.TextLength != 0))
            {
                this.infoTextBox.Text = "Source and Destination entered: Ready to Convert\r\n";
                this.convertButton.Enabled = true;
            }
            else
            {
                this.infoTextBox.Text = "Need Source and Destination to Convert\r\n";
                this.convertButton.Enabled = false;
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            this.infoTextBox.Text=("Starting Conversion...\r\n");
            //Let's check if the source file exists.
            string message = "";
            string caption = "";
            MessageBoxButtons buttons;
            DialogResult result;
            string sourceFileName = sourceFileTextBox.Text;
            string destinationFileName = destinationFileTextBox.Text;
            try
            {
                if (System.IO.File.Exists(sourceFileName))
                {
                    if (debugFlag)
                    {
                        this.infoTextBox.AppendText("Source file " + sourceFileName + " does exist.\r\n");

                    }
                    // Now we check if the destination file is okay
                    try
                    {
                        if (System.IO.File.Exists(destinationFileName))
                        {
                            if (debugFlag)
                            {
                                this.infoTextBox.AppendText("Destination file " + destinationFileName + " does exist.\r\n");

                            }
                            this.infoTextBox.AppendText("Writing over destionation file " + destinationFileName + ".\r\n");
                            try
                            {
                                //Delete existing file
                                System.IO.File.Delete(destinationFileName);
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error.ToString());
                                this.infoTextBox.Text = "Error clearing destination file.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                                message = "Error clearing destination file.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                                caption = "Error clearing destination file.";
                                buttons = MessageBoxButtons.OK;
                                result = MessageBox.Show(message, caption, buttons);
                                this.infoTextBox.AppendText("Error clearing destination file: " + result.ToString() + "\r\n");
                                return;
                            }
                        }
                        else if (debugFlag)
                        {
                            this.infoTextBox.AppendText("Destination file " + destinationFileName + " does not exist.\r\n");
                        }
                    }
                    catch (Exception error)

                    {
                        Console.WriteLine(error.ToString());
                        this.infoTextBox.Text = "Error checking destination file.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                        message = "Error checking destination file.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                        caption = "Error checking destination file.";
                        buttons = MessageBoxButtons.OK;
                        result = MessageBox.Show(message, caption, buttons);
                        this.infoTextBox.AppendText("Error checking destination file: " + result.ToString() + "\r\n");
                        return;
                    }




                    //Now we should determine if this is a Liteware 3 file, or Liteware 4 file
                    //The only filetype check we are going to do for now, is to test the extension of the file. If you botch this, you'll get errors.
                    //Don't ruin this for me, man

                    if (sourceFileName.EndsWith(".lwd"))
                    {
                        this.infoTextBox.AppendText("Liteware 3 (Access / Jet DB SQL) file detected.\r\n");
                        
                        if (convertJetDB(sourceFileName, destinationFileName))
                        {
                            this.infoTextBox.AppendText("Conversion Complete.\r\n");
                        }
                        else
                        {
                            this.infoTextBox.AppendText("Conversion Failed.\r\n");
                        }
                    }
                    else if (sourceFileName.EndsWith(".lw4"))
                    {
                        this.infoTextBox.AppendText("Liteware 4/5/6 (XML) file detected.\r\n");
                        if (convertXML(sourceFileName, destinationFileName))
                        {
                            this.infoTextBox.AppendText("Conversion Complete.\r\n");
                        }
                        else
                        {
                            this.infoTextBox.AppendText("Conversion Failed.\r\n");
                        }
                    }
                    else
                    {
                        this.infoTextBox.AppendText("File not recognized.\r\nCannot Continue\r\nConversion Failed.\r\n");
                    }





                }
                else
                {
                    this.infoTextBox.Text = "Source file does not exist.\r\n" + sourceFileTextBox.Text + "\r\nCannot continue.\r\n";
                    message = "Source file does not exist.\r\n" + sourceFileTextBox.Text + "\r\nCannot continue.\r\n";
                    caption = "Source file does not exist";
                    buttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(message, caption, buttons);
                    this.infoTextBox.AppendText("Error reading source file: " + result.ToString() + "\r\n");
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                this.infoTextBox.Text = "Error reading source file.\r\n" + error.ToString()+ "\r\nCannot continue.\r\n";
                message = "Error reading source file.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                caption = "Error reading source file.";
                buttons = MessageBoxButtons.OK;
                result = MessageBox.Show(message, caption, buttons);
                this.infoTextBox.AppendText("Error reading source file: " + result.ToString() + "\r\n");
                return;

            }



        }
        private Boolean convertXML(string sourceFileName, string destinationFileName)
        {
            try
            {
                //Read in the raw XML file
                string rawText = File.ReadAllText(sourceFileName);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(rawText);
                //Finally, we convert the dataset into a JSON string and save it into the output file.
                string json = JsonConvert.SerializeXmlNode(xml, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(destinationFileName, json);
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                this.infoTextBox.Text = "Error on conversion.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                string message = "Error on conversion.\r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                string caption = "Error on conversion.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                this.infoTextBox.AppendText("Error reading source file: " + result.ToString() + "\r\n");
                return false;
            }
            
        }
        private Boolean convertJetDB(string sourceFileName, string destinationFileName)
        {
            Boolean success = false;
            this.infoTextBox.AppendText("Opening JetDB Database...\r\n");
            string message;
            string caption;
            MessageBoxButtons buttons;
            DialogResult result;

            //Open JetDB SQL Database
            System.Data.OleDb.OleDbConnection conn = new
            System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data source= " + sourceFileName;

            try
            {
                conn.Open();
                this.infoTextBox.AppendText("JetDB Database Opened.\r\n");
                // Insert code to process data.
                //Get a list of all tables in DB
                DataTable userTables = conn.GetSchema("Tables");
                List<string> tablesList = new List<string>();
                for (int i = 0; i < userTables.Rows.Count; i++)
                {
                    tablesList.Add(userTables.Rows[i][2].ToString());
                }                
                string[] tableArray = tablesList.ToArray();
                DataSet dataSet = new DataSet();

                //Now we retrieve data from each table with a select statement and add that data into the dataset object
                foreach (string table in tableArray)
                {
                    if (debugFlag)
                    {
                        this.infoTextBox.AppendText("Processing Table: " + table + "\r\n");
                    }

                    if ((table != "MSysACEs") && (table != "MSysObjects") && (table != "MSysQueries") && (table != "MSysRelationships")) //These tables give us read errors
                    {
                        DataTable dataTable = dataSet.Tables.Add(table);
                        using (OleDbCommand readRows = new OleDbCommand("SELECT * from " + table, conn))        //Use select command to get all data
                        {
                            OleDbDataAdapter adapter = new OleDbDataAdapter(readRows);
                            adapter.Fill(dataTable);
                        }
                    }
                }

                //Finally, we convert the dataset into a JSON string and save it into the output file.
                string json = string.Empty;
                json = JsonConvert.SerializeObject(dataSet, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(destinationFileName, json);

                success = true;
            }
            catch (Exception error)
            {
                this.infoTextBox.AppendText("Failed to connect to data source. Error reading source file: \r\n" + error.ToString() + "\r\nCannot continue.\r\n");
                message = "Failed to connect to data source. Error reading source file: \r\n" + error.ToString() + "\r\nCannot continue.\r\n";
                caption = "Failed to connect to data source.";
                buttons = MessageBoxButtons.OK;
                result = MessageBox.Show(message, caption, buttons);
                this.infoTextBox.AppendText("Error reading source file: " + result.ToString() + "\r\n");
                success =  false;
            }
            finally
            {
                conn.Close();
                this.infoTextBox.AppendText("JetDB Database Closed.\r\n");
            }
            return success;
        }
    }
}
