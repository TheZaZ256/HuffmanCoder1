namespace HuffmanCoder
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btncoding = new System.Windows.Forms.Button();
            this.rbDecode = new System.Windows.Forms.RadioButton();
            this.rbEncode = new System.Windows.Forms.RadioButton();
            this.btnLoadText = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadBinary = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(0, 86);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(788, 352);
            this.txtInput.TabIndex = 0;
            // 
            // btncoding
            // 
            this.btncoding.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btncoding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncoding.Dock = System.Windows.Forms.DockStyle.Left;
            this.btncoding.Image = ((System.Drawing.Image)(resources.GetObject("btncoding.Image")));
            this.btncoding.Location = new System.Drawing.Point(359, 3);
            this.btncoding.Name = "btncoding";
            this.tableLayoutPanel1.SetRowSpan(this.btncoding, 3);
            this.btncoding.Size = new System.Drawing.Size(124, 74);
            this.btncoding.TabIndex = 1;
            this.btncoding.UseVisualStyleBackColor = true;
            this.btncoding.Click += new System.EventHandler(this.Coding_Click);
            // 
            // rbDecode
            // 
            this.rbDecode.AutoSize = true;
            this.rbDecode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbDecode.Location = new System.Drawing.Point(246, 51);
            this.rbDecode.Name = "rbDecode";
            this.rbDecode.Size = new System.Drawing.Size(107, 26);
            this.rbDecode.TabIndex = 2;
            this.rbDecode.TabStop = true;
            this.rbDecode.Text = "Раскодировать";
            this.rbDecode.UseVisualStyleBackColor = true;
            // 
            // rbEncode
            // 
            this.rbEncode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbEncode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbEncode.Location = new System.Drawing.Point(246, 20);
            this.rbEncode.Name = "rbEncode";
            this.rbEncode.Size = new System.Drawing.Size(107, 25);
            this.rbEncode.TabIndex = 3;
            this.rbEncode.TabStop = true;
            this.rbEncode.Text = "Закодировать";
            this.rbEncode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbEncode.UseVisualStyleBackColor = true;
            // 
            // btnLoadText
            // 
            this.btnLoadText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadText.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLoadText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadText.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadText.Image")));
            this.btnLoadText.Location = new System.Drawing.Point(3, 20);
            this.btnLoadText.Name = "btnLoadText";
            this.tableLayoutPanel1.SetRowSpan(this.btnLoadText, 2);
            this.btnLoadText.Size = new System.Drawing.Size(90, 57);
            this.btnLoadText.TabIndex = 6;
            this.btnLoadText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoadText.UseVisualStyleBackColor = false;
            this.btnLoadText.Click += new System.EventHandler(this.BtnLoadText_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Загрузить текст";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(99, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Загрузить бинарный файл";
            // 
            // btnLoadBinary
            // 
            this.btnLoadBinary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadBinary.Image = global::HuffmanCoder.Properties.Resources.binary_code;
            this.btnLoadBinary.Location = new System.Drawing.Point(99, 20);
            this.btnLoadBinary.Name = "btnLoadBinary";
            this.tableLayoutPanel1.SetRowSpan(this.btnLoadBinary, 2);
            this.btnLoadBinary.Size = new System.Drawing.Size(141, 57);
            this.btnLoadBinary.TabIndex = 10;
            this.btnLoadBinary.UseVisualStyleBackColor = true;
            this.btnLoadBinary.Click += new System.EventHandler(this.BtnLoadBinary_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Controls.Add(this.btncoding, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadBinary, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbDecode, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbEncode, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.41667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.58334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 80);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtInput);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Сжатие текста (Хаффман)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btncoding;
        private System.Windows.Forms.RadioButton rbDecode;
        private System.Windows.Forms.RadioButton rbEncode;
        private System.Windows.Forms.Button btnLoadText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadBinary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox txtInput;
    }
}

