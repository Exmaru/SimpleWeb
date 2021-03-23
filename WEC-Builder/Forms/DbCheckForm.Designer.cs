
namespace WEC_Builder.Forms
{
    partial class DbCheckForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.LB_Status = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Conn = new System.Windows.Forms.TextBox();
            this.TB_App = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Container = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Btn_Save);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LB_Status);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TB_Conn);
            this.groupBox1.Controls.Add(this.TB_App);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TB_Password);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_ID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_Path);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_Container);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "접속정보";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "앱 명칭 : ";
            // 
            // LB_Status
            // 
            this.LB_Status.AutoSize = true;
            this.LB_Status.Location = new System.Drawing.Point(68, 204);
            this.LB_Status.Name = "LB_Status";
            this.LB_Status.Size = new System.Drawing.Size(189, 12);
            this.LB_Status.TabIndex = 14;
            this.LB_Status.Text = "현재 접속이 불가능한 상태입니다.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(482, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "접속문자열 : ";
            // 
            // TB_Conn
            // 
            this.TB_Conn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Conn.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Conn.Location = new System.Drawing.Point(484, 68);
            this.TB_Conn.MaxLength = 300;
            this.TB_Conn.Multiline = true;
            this.TB_Conn.Name = "TB_Conn";
            this.TB_Conn.ReadOnly = true;
            this.TB_Conn.Size = new System.Drawing.Size(249, 108);
            this.TB_Conn.TabIndex = 12;
            // 
            // TB_App
            // 
            this.TB_App.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_App.Location = new System.Drawing.Point(142, 153);
            this.TB_App.MaxLength = 300;
            this.TB_App.Name = "TB_App";
            this.TB_App.Size = new System.Drawing.Size(306, 23);
            this.TB_App.TabIndex = 11;
            this.TB_App.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Container_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "상태 : ";
            // 
            // TB_Password
            // 
            this.TB_Password.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Password.Location = new System.Drawing.Point(142, 124);
            this.TB_Password.MaxLength = 300;
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(306, 23);
            this.TB_Password.TabIndex = 9;
            this.TB_Password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Container_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "패스워드 : ";
            // 
            // TB_ID
            // 
            this.TB_ID.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_ID.Location = new System.Drawing.Point(142, 95);
            this.TB_ID.MaxLength = 300;
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(306, 23);
            this.TB_ID.TabIndex = 7;
            this.TB_ID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Container_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "아이디 : ";
            // 
            // TB_Path
            // 
            this.TB_Path.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Path.Location = new System.Drawing.Point(142, 66);
            this.TB_Path.MaxLength = 300;
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.Size = new System.Drawing.Size(306, 23);
            this.TB_Path.TabIndex = 5;
            this.TB_Path.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Container_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "접근경로 : ";
            // 
            // TB_Container
            // 
            this.TB_Container.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Container.Location = new System.Drawing.Point(142, 37);
            this.TB_Container.MaxLength = 300;
            this.TB_Container.Name = "TB_Container";
            this.TB_Container.Size = new System.Drawing.Size(306, 23);
            this.TB_Container.TabIndex = 3;
            this.TB_Container.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Container_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "데이터베이스 명칭 : ";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Save.Location = new System.Drawing.Point(625, 193);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(108, 34);
            this.Btn_Save.TabIndex = 16;
            this.Btn_Save.Text = "저장";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // DbCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 268);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "DbCheckForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DbCheckForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_Conn;
        private System.Windows.Forms.TextBox TB_App;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Container;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_Save;
    }
}