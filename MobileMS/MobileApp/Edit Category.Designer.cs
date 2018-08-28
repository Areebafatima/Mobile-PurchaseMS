namespace MobileApp
{
    partial class Edit_Category
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
            this.EditBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrandCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // EditBTN
            // 
            this.EditBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBTN.Location = new System.Drawing.Point(221, 199);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(282, 62);
            this.EditBTN.TabIndex = 82;
            this.EditBTN.Text = "Edit";
            this.EditBTN.UseVisualStyleBackColor = true;
            this.EditBTN.Click += new System.EventHandler(this.EditBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(125, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 80;
            this.label1.Text = "Brand Name :";
            // 
            // BNameTB
            // 
            this.BNameTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNameTB.Location = new System.Drawing.Point(290, 108);
            this.BNameTB.Name = "BNameTB";
            this.BNameTB.Size = new System.Drawing.Size(244, 29);
            this.BNameTB.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label2.Location = new System.Drawing.Point(125, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 77;
            this.label2.Text = "Brand  No:";
            // 
            // BrandCombo
            // 
            this.BrandCombo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandCombo.FormattingEnabled = true;
            this.BrandCombo.Location = new System.Drawing.Point(290, 54);
            this.BrandCombo.Name = "BrandCombo";
            this.BrandCombo.Size = new System.Drawing.Size(244, 29);
            this.BrandCombo.TabIndex = 83;
            // 
            // Edit_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 273);
            this.Controls.Add(this.BrandCombo);
            this.Controls.Add(this.EditBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BNameTB);
            this.Controls.Add(this.label2);
            this.Name = "Edit_Category";
            this.Text = "Edit_Category";
            this.Load += new System.EventHandler(this.Edit_Category_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BrandCombo;
    }
}