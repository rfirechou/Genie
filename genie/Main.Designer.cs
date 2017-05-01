namespace genie
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.readStat = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.read = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "商品";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.product_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "統計";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // readStat
            // 
            this.readStat.Location = new System.Drawing.Point(665, 412);
            this.readStat.Name = "readStat";
            this.readStat.Size = new System.Drawing.Size(84, 28);
            this.readStat.TabIndex = 2;
            this.readStat.Text = "讀取統計";
            this.readStat.UseVisualStyleBackColor = true;
            this.readStat.Click += new System.EventHandler(this.read_stat_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(665, 220);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(84, 28);
            this.save.TabIndex = 3;
            this.save.Text = "保存資料";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // read
            // 
            this.read.Location = new System.Drawing.Point(665, 186);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(84, 28);
            this.read.TabIndex = 4;
            this.read.Text = "讀取資料";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 452);
            this.Controls.Add(this.read);
            this.Controls.Add(this.save);
            this.Controls.Add(this.readStat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Genie 代購統計程式 Beta開發版";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button readStat;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button read;
    }
}

