
namespace WEC_Builder.Forms
{
    partial class LoadForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Load = new System.Windows.Forms.Button();
            this.Btn_Path_Search = new System.Windows.Forms.Button();
            this.TB_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Load);
            this.groupBox1.Controls.Add(this.Btn_Path_Search);
            this.groupBox1.Controls.Add(this.TB_Path);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 336);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project";
            // 
            // btn_Load
            // 
            this.btn_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Load.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Load.Location = new System.Drawing.Point(201, 201);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(166, 55);
            this.btn_Load.TabIndex = 5;
            this.btn_Load.Text = "불러오기";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // Btn_Path_Search
            // 
            this.Btn_Path_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Path_Search.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Path_Search.Location = new System.Drawing.Point(399, 123);
            this.Btn_Path_Search.Name = "Btn_Path_Search";
            this.Btn_Path_Search.Size = new System.Drawing.Size(130, 28);
            this.Btn_Path_Search.TabIndex = 4;
            this.Btn_Path_Search.Text = "찾아보기";
            this.Btn_Path_Search.UseVisualStyleBackColor = true;
            this.Btn_Path_Search.Click += new System.EventHandler(this.Btn_Path_Search_Click);
            // 
            // TB_Path
            // 
            this.TB_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Path.Font = new System.Drawing.Font("나눔고딕코딩", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Path.Location = new System.Drawing.Point(30, 124);
            this.TB_Path.MaxLength = 100;
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.Size = new System.Drawing.Size(362, 26);
            this.TB_Path.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "프로젝트 경로 :";
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoadForm";
            this.Text = "불러오기";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button Btn_Path_Search;
        private System.Windows.Forms.TextBox TB_Path;
        private System.Windows.Forms.Label label2;
    }
}