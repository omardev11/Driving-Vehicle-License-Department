namespace DVLDDesltopFrontLayer.Controles
{
    partial class CTRLFilterUserBy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFiltiringValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBFiltiringBy = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // txtFiltiringValue
            // 
            this.txtFiltiringValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltiringValue.Location = new System.Drawing.Point(375, 28);
            this.txtFiltiringValue.Name = "txtFiltiringValue";
            this.txtFiltiringValue.Size = new System.Drawing.Size(243, 27);
            this.txtFiltiringValue.TabIndex = 8;
            this.txtFiltiringValue.TextChanged += new System.EventHandler(this.txtFiltiringValue_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter By";
            // 
            // CBFiltiringBy
            // 
            this.CBFiltiringBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltiringBy.FormattingEnabled = true;
            this.CBFiltiringBy.Items.AddRange(new object[] {
            "NationalNO",
            "PersonID"});
            this.CBFiltiringBy.Location = new System.Drawing.Point(124, 28);
            this.CBFiltiringBy.Name = "CBFiltiringBy";
            this.CBFiltiringBy.Size = new System.Drawing.Size(221, 24);
            this.CBFiltiringBy.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Image = global::DVLDDesltopFrontLayer.Properties.Resources.SearchPerson;
            this.button1.Location = new System.Drawing.Point(651, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 50);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLDDesltopFrontLayer.Properties.Resources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(724, 18);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(47, 50);
            this.btnAddPerson.TabIndex = 10;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1107, 398);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Information";
            // 
            // CTRLFilterUserBy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFiltiringValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBFiltiringBy);
            this.Name = "CTRLFilterUserBy";
            this.Size = new System.Drawing.Size(1140, 489);
            this.Load += new System.EventHandler(this.CTRLFilterUserBy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltiringValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBFiltiringBy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
