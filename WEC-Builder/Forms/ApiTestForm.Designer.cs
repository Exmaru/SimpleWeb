
namespace WEC_Builder.Forms
{
    partial class ApiTestForm
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
            this.CB_Type = new System.Windows.Forms.ComboBox();
            this.TB_URL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Layer_Parameters = new System.Windows.Forms.Panel();
            this.Btn_Add_Params = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_Result = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.CB_MediaType = new System.Windows.Forms.ComboBox();
            this.Chk_Serialize = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Chk_Serialize);
            this.groupBox1.Controls.Add(this.CB_MediaType);
            this.groupBox1.Controls.Add(this.CB_Type);
            this.groupBox1.Controls.Add(this.TB_URL);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request API";
            // 
            // CB_Type
            // 
            this.CB_Type.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_Type.FormattingEnabled = true;
            this.CB_Type.Items.AddRange(new object[] {
            "POST",
            "GET",
            "POST-Basic"});
            this.CB_Type.Location = new System.Drawing.Point(25, 23);
            this.CB_Type.Name = "CB_Type";
            this.CB_Type.Size = new System.Drawing.Size(121, 23);
            this.CB_Type.TabIndex = 2;
            // 
            // TB_URL
            // 
            this.TB_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_URL.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_URL.Location = new System.Drawing.Point(279, 23);
            this.TB_URL.Name = "TB_URL";
            this.TB_URL.Size = new System.Drawing.Size(471, 22);
            this.TB_URL.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.Layer_Parameters);
            this.groupBox2.Controls.Add(this.Btn_Add_Params);
            this.groupBox2.Location = new System.Drawing.Point(13, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 336);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // Layer_Parameters
            // 
            this.Layer_Parameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Layer_Parameters.Location = new System.Drawing.Point(7, 62);
            this.Layer_Parameters.Name = "Layer_Parameters";
            this.Layer_Parameters.Size = new System.Drawing.Size(246, 268);
            this.Layer_Parameters.TabIndex = 1;
            // 
            // Btn_Add_Params
            // 
            this.Btn_Add_Params.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Add_Params.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Add_Params.Location = new System.Drawing.Point(7, 21);
            this.Btn_Add_Params.Name = "Btn_Add_Params";
            this.Btn_Add_Params.Size = new System.Drawing.Size(246, 34);
            this.Btn_Add_Params.TabIndex = 0;
            this.Btn_Add_Params.Text = "파라미터 추가";
            this.Btn_Add_Params.UseVisualStyleBackColor = true;
            this.Btn_Add_Params.Click += new System.EventHandler(this.Btn_Add_Params_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TB_Result);
            this.groupBox3.Location = new System.Drawing.Point(278, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 263);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // TB_Result
            // 
            this.TB_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Result.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Result.Location = new System.Drawing.Point(7, 21);
            this.TB_Result.MaxLength = 999999999;
            this.TB_Result.Multiline = true;
            this.TB_Result.Name = "TB_Result";
            this.TB_Result.ReadOnly = true;
            this.TB_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Result.Size = new System.Drawing.Size(497, 236);
            this.TB_Result.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.Btn_Send);
            this.groupBox4.Location = new System.Drawing.Point(278, 371);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 67);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Functions";
            // 
            // Btn_Send
            // 
            this.Btn_Send.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Send.Location = new System.Drawing.Point(14, 20);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(121, 36);
            this.Btn_Send.TabIndex = 0;
            this.Btn_Send.Text = "Send Request";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // CB_MediaType
            // 
            this.CB_MediaType.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_MediaType.FormattingEnabled = true;
            this.CB_MediaType.Items.AddRange(new object[] {
            "JSON",
            "XML"});
            this.CB_MediaType.Location = new System.Drawing.Point(152, 23);
            this.CB_MediaType.Name = "CB_MediaType";
            this.CB_MediaType.Size = new System.Drawing.Size(121, 23);
            this.CB_MediaType.TabIndex = 3;
            // 
            // Chk_Serialize
            // 
            this.Chk_Serialize.AutoSize = true;
            this.Chk_Serialize.Location = new System.Drawing.Point(26, 55);
            this.Chk_Serialize.Name = "Chk_Serialize";
            this.Chk_Serialize.Size = new System.Drawing.Size(104, 16);
            this.Chk_Serialize.TabIndex = 4;
            this.Chk_Serialize.Text = "Json Serialize";
            this.Chk_Serialize.UseVisualStyleBackColor = true;
            // 
            // ApiTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ApiTestForm";
            this.Text = "ApiTestForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_Type;
        private System.Windows.Forms.TextBox TB_URL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Add_Params;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TB_Result;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel Layer_Parameters;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.ComboBox CB_MediaType;
        private System.Windows.Forms.CheckBox Chk_Serialize;
    }
}