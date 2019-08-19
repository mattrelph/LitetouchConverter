namespace LitetouchConverter
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.explainLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.sourceFileTextBox = new System.Windows.Forms.TextBox();
            this.destinationFileTextBox = new System.Windows.Forms.TextBox();
            this.sourceFileButton = new System.Windows.Forms.Button();
            this.destinationFileButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.sourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.destinationFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // explainLabel
            // 
            this.explainLabel.AutoSize = true;
            this.explainLabel.Location = new System.Drawing.Point(13, 13);
            this.explainLabel.Name = "explainLabel";
            this.explainLabel.Size = new System.Drawing.Size(513, 13);
            this.explainLabel.TabIndex = 0;
            this.explainLabel.Text = "This program converts Liteware 3 (JetDB SQL) and Liteware 4/5/6 (XML) files into " +
    "JSON files for future use.";
            this.explainLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(16, 54);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(60, 13);
            this.sourceLabel.TabIndex = 1;
            this.sourceLabel.Text = "Source File";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(16, 94);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(79, 13);
            this.destinationLabel.TabIndex = 2;
            this.destinationLabel.Text = "Destination File";
            this.destinationLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // sourceFileTextBox
            // 
            this.sourceFileTextBox.Location = new System.Drawing.Point(19, 71);
            this.sourceFileTextBox.Name = "sourceFileTextBox";
            this.sourceFileTextBox.Size = new System.Drawing.Size(427, 20);
            this.sourceFileTextBox.TabIndex = 3;
            this.sourceFileTextBox.TextChanged += new System.EventHandler(this.sourceFileTextBox_TextChanged);
            // 
            // destinationFileTextBox
            // 
            this.destinationFileTextBox.Location = new System.Drawing.Point(19, 111);
            this.destinationFileTextBox.Name = "destinationFileTextBox";
            this.destinationFileTextBox.Size = new System.Drawing.Size(427, 20);
            this.destinationFileTextBox.TabIndex = 4;
            this.destinationFileTextBox.TextChanged += new System.EventHandler(this.destinationFileTextBox_TextChanged);
            // 
            // sourceFileButton
            // 
            this.sourceFileButton.Location = new System.Drawing.Point(465, 67);
            this.sourceFileButton.Name = "sourceFileButton";
            this.sourceFileButton.Size = new System.Drawing.Size(75, 23);
            this.sourceFileButton.TabIndex = 5;
            this.sourceFileButton.Text = "Browse...";
            this.sourceFileButton.UseVisualStyleBackColor = true;
            this.sourceFileButton.Click += new System.EventHandler(this.sourceFileButton_Click);
            // 
            // destinationFileButton
            // 
            this.destinationFileButton.Location = new System.Drawing.Point(465, 107);
            this.destinationFileButton.Name = "destinationFileButton";
            this.destinationFileButton.Size = new System.Drawing.Size(75, 23);
            this.destinationFileButton.TabIndex = 6;
            this.destinationFileButton.Text = "Browse...";
            this.destinationFileButton.UseVisualStyleBackColor = true;
            this.destinationFileButton.Click += new System.EventHandler(this.destinationFileButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Enabled = false;
            this.convertButton.Location = new System.Drawing.Point(19, 138);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(521, 23);
            this.convertButton.TabIndex = 7;
            this.convertButton.Text = "Convert!";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // sourceFileDialog
            // 
            this.sourceFileDialog.FileName = "openFileDialog1";
            this.sourceFileDialog.Filter = "Liteware Files (*.lwd, *.lw4)|*.lwd;*.lw4";
            // 
            // destinationFileDialog
            // 
            this.destinationFileDialog.CreatePrompt = true;
            this.destinationFileDialog.DefaultExt = "json";
            this.destinationFileDialog.Filter = "JSON Files (*.json)|*.json";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(19, 168);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(521, 326);
            this.infoTextBox.TabIndex = 8;
            this.infoTextBox.Text = "Idle";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 506);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.destinationFileButton);
            this.Controls.Add(this.sourceFileButton);
            this.Controls.Add(this.destinationFileTextBox);
            this.Controls.Add(this.sourceFileTextBox);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.explainLabel);
            this.Name = "MainWindow";
            this.Text = "Litetouch Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label explainLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.TextBox sourceFileTextBox;
        private System.Windows.Forms.TextBox destinationFileTextBox;
        private System.Windows.Forms.Button sourceFileButton;
        private System.Windows.Forms.Button destinationFileButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.OpenFileDialog sourceFileDialog;
        private System.Windows.Forms.SaveFileDialog destinationFileDialog;
        private System.Windows.Forms.TextBox infoTextBox;
    }
}

