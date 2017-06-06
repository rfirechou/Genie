﻿namespace genie
{
    partial class InputBox
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputName = new System.Windows.Forms.TextBox();
            this.inputPrice = new System.Windows.Forms.TextBox();
            this.inputCost = new System.Windows.Forms.TextBox();
            this.inputRemarks = new System.Windows.Forms.TextBox();
            this.rate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(173, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(173, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "商品";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "單價";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "成本";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "備註";
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(53, 37);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(100, 22);
            this.inputName.TabIndex = 0;
            this.inputName.TextChanged += new System.EventHandler(this.inputName_TextChanged);
            // 
            // inputPrice
            // 
            this.inputPrice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inputPrice.Location = new System.Drawing.Point(53, 67);
            this.inputPrice.Name = "inputPrice";
            this.inputPrice.Size = new System.Drawing.Size(100, 22);
            this.inputPrice.TabIndex = 1;
            this.inputPrice.TextChanged += new System.EventHandler(this.inputPrice_TextChanged);
            // 
            // inputCost
            // 
            this.inputCost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inputCost.Location = new System.Drawing.Point(53, 97);
            this.inputCost.Name = "inputCost";
            this.inputCost.Size = new System.Drawing.Size(100, 22);
            this.inputCost.TabIndex = 2;
            this.inputCost.TextChanged += new System.EventHandler(this.inputCost_TextChanged);
            // 
            // inputRemarks
            // 
            this.inputRemarks.Location = new System.Drawing.Point(53, 127);
            this.inputRemarks.Name = "inputRemarks";
            this.inputRemarks.Size = new System.Drawing.Size(100, 22);
            this.inputRemarks.TabIndex = 3;
            this.inputRemarks.TextChanged += new System.EventHandler(this.inputRemarks_TextChanged);
            // 
            // rate
            // 
            this.rate.Location = new System.Drawing.Point(174, 97);
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(52, 22);
            this.rate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 9F);
            this.label5.Location = new System.Drawing.Point(158, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "匯率";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 183);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.inputRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "InputBox";
            this.Text = "商品";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputCost;
        private System.Windows.Forms.TextBox inputRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}