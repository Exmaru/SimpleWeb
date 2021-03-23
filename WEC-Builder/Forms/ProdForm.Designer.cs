
namespace WEC_Builder.Forms
{
    partial class ProdForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_Content = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IsAdmin = new System.Windows.Forms.CheckBox();
            this.CB_TYPE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.LB_SP = new System.Windows.Forms.ListBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btn_Save);
            this.groupBox4.Controls.Add(this.btn_copy);
            this.groupBox4.Controls.Add(this.btn_output);
            this.groupBox4.Location = new System.Drawing.Point(218, 372);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(570, 66);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "명령";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(244, 20);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(96, 35);
            this.btn_Save.TabIndex = 12;
            this.btn_Save.Text = "파일저장";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(131, 20);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(107, 35);
            this.btn_copy.TabIndex = 11;
            this.btn_copy.Text = "내용복사";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(18, 20);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(107, 35);
            this.btn_output.TabIndex = 10;
            this.btn_output.Text = "미리보기";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TB_Content);
            this.groupBox3.Location = new System.Drawing.Point(218, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 239);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "내용";
            // 
            // TB_Content
            // 
            this.TB_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Content.BackColor = System.Drawing.Color.Black;
            this.TB_Content.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Content.ForeColor = System.Drawing.Color.Chartreuse;
            this.TB_Content.Location = new System.Drawing.Point(6, 20);
            this.TB_Content.MaxLength = 999999999;
            this.TB_Content.Multiline = true;
            this.TB_Content.Name = "TB_Content";
            this.TB_Content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Content.Size = new System.Drawing.Size(558, 213);
            this.TB_Content.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.IsAdmin);
            this.groupBox2.Controls.Add(this.CB_TYPE);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 109);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "옵션";
            // 
            // IsAdmin
            // 
            this.IsAdmin.AutoSize = true;
            this.IsAdmin.Location = new System.Drawing.Point(21, 29);
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.Size = new System.Drawing.Size(88, 16);
            this.IsAdmin.TabIndex = 5;
            this.IsAdmin.Text = "관리자 코드";
            this.IsAdmin.UseVisualStyleBackColor = true;
            // 
            // CB_TYPE
            // 
            this.CB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TYPE.FormattingEnabled = true;
            this.CB_TYPE.Items.AddRange(new object[] {
            "ReturnValue",
            "Select"});
            this.CB_TYPE.Location = new System.Drawing.Point(89, 53);
            this.CB_TYPE.Name = "CB_TYPE";
            this.CB_TYPE.Size = new System.Drawing.Size(189, 20);
            this.CB_TYPE.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "조건유형 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Controls.Add(this.TB_Search);
            this.groupBox1.Controls.Add(this.LB_SP);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 426);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "테이블목록";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(6, 25);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(187, 30);
            this.btn_load.TabIndex = 5;
            this.btn_load.Text = "LOAD";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // TB_Search
            // 
            this.TB_Search.Location = new System.Drawing.Point(5, 59);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(188, 21);
            this.TB_Search.TabIndex = 4;
            // 
            // LB_SP
            // 
            this.LB_SP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_SP.FormattingEnabled = true;
            this.LB_SP.ItemHeight = 12;
            this.LB_SP.Location = new System.Drawing.Point(6, 84);
            this.LB_SP.Name = "LB_SP";
            this.LB_SP.Size = new System.Drawing.Size(188, 328);
            this.LB_SP.TabIndex = 3;
            // 
            // ProdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProdForm";
            this.Text = "ProdForm";
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TB_Content;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox IsAdmin;
        private System.Windows.Forms.ComboBox CB_TYPE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.ListBox LB_SP;
    }
}