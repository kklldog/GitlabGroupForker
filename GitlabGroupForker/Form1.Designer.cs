namespace GitlabGroupForker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFromId = new System.Windows.Forms.TextBox();
            this.btnQueryFrom = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFork = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToId = new System.Windows.Forms.TextBox();
            this.btnQueryTo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFromId
            // 
            this.txtFromId.Location = new System.Drawing.Point(122, 15);
            this.txtFromId.Name = "txtFromId";
            this.txtFromId.Size = new System.Drawing.Size(391, 23);
            this.txtFromId.TabIndex = 0;
            // 
            // btnQueryFrom
            // 
            this.btnQueryFrom.Location = new System.Drawing.Point(519, 14);
            this.btnQueryFrom.Name = "btnQueryFrom";
            this.btnQueryFrom.Size = new System.Drawing.Size(116, 27);
            this.btnQueryFrom.TabIndex = 1;
            this.btnQueryFrom.Text = "查看 group";
            this.btnQueryFrom.UseVisualStyleBackColor = true;
            this.btnQueryFrom.Click += new System.EventHandler(this.btnQueryFrom_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(12, 81);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(776, 357);
            this.txtLogs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "from group id:";
            // 
            // btnFork
            // 
            this.btnFork.Location = new System.Drawing.Point(664, 45);
            this.btnFork.Name = "btnFork";
            this.btnFork.Size = new System.Drawing.Size(124, 27);
            this.btnFork.TabIndex = 4;
            this.btnFork.Text = "fork group";
            this.btnFork.UseVisualStyleBackColor = true;
            this.btnFork.Click += new System.EventHandler(this.btnFork_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "to group id:";
            // 
            // txtToId
            // 
            this.txtToId.Location = new System.Drawing.Point(122, 46);
            this.txtToId.Name = "txtToId";
            this.txtToId.Size = new System.Drawing.Size(391, 23);
            this.txtToId.TabIndex = 5;
            // 
            // btnQueryTo
            // 
            this.btnQueryTo.Location = new System.Drawing.Point(519, 44);
            this.btnQueryTo.Name = "btnQueryTo";
            this.btnQueryTo.Size = new System.Drawing.Size(116, 27);
            this.btnQueryTo.TabIndex = 7;
            this.btnQueryTo.Text = "查看 group";
            this.btnQueryTo.UseVisualStyleBackColor = true;
            this.btnQueryTo.Click += new System.EventHandler(this.btnQueryTo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQueryTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToId);
            this.Controls.Add(this.btnFork);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.btnQueryFrom);
            this.Controls.Add(this.txtFromId);
            this.Name = "Form1";
            this.Text = "GitlabGroupForker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtFromId;
        private Button btnQueryFrom;
        private TextBox txtLogs;
        private Label label1;
        private Button btnFork;
        private Label label2;
        private TextBox txtToId;
        private Button btnQueryTo;
    }
}