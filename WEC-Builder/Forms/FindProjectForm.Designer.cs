
namespace WEC_Builder.Forms
{
    partial class FindProjectForm
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
            this.Btn_Search_Path = new System.Windows.Forms.Button();
            this.TB_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.TB_Location = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Conn = new System.Windows.Forms.TextBox();
            this.TB_App = new System.Windows.Forms.TextBox();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Container = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grp_func = new System.Windows.Forms.GroupBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.Btn_Get_Target_Db = new System.Windows.Forms.Button();
            this.btn_db_copy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_func.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Btn_Search_Path);
            this.groupBox1.Controls.Add(this.TB_Path);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Btn_Search);
            this.groupBox1.Controls.Add(this.TB_Location);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "프로젝트 복사";
            // 
            // Btn_Search_Path
            // 
            this.Btn_Search_Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Search_Path.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Search_Path.Location = new System.Drawing.Point(630, 60);
            this.Btn_Search_Path.Name = "Btn_Search_Path";
            this.Btn_Search_Path.Size = new System.Drawing.Size(118, 23);
            this.Btn_Search_Path.TabIndex = 5;
            this.Btn_Search_Path.Text = "찾아보기";
            this.Btn_Search_Path.UseVisualStyleBackColor = true;
            this.Btn_Search_Path.Click += new System.EventHandler(this.Btn_Search_Path_Click);
            // 
            // TB_Path
            // 
            this.TB_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Path.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Path.Location = new System.Drawing.Point(139, 61);
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.Size = new System.Drawing.Size(485, 22);
            this.TB_Path.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(21, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "새 프로젝트 :";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Search.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Search.Location = new System.Drawing.Point(630, 28);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(118, 23);
            this.Btn_Search.TabIndex = 2;
            this.Btn_Search.Text = "찾아보기";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // TB_Location
            // 
            this.TB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Location.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Location.Location = new System.Drawing.Point(139, 29);
            this.TB_Location.Name = "TB_Location";
            this.TB_Location.Size = new System.Drawing.Size(485, 22);
            this.TB_Location.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "대상 프로젝트 :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TB_Conn);
            this.groupBox2.Controls.Add(this.TB_App);
            this.groupBox2.Controls.Add(this.TB_Password);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TB_ID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TB_IP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TB_Container);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(13, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database 설정";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "앱 명칭 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(492, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "접속문자열 : ";
            // 
            // TB_Conn
            // 
            this.TB_Conn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Conn.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Conn.Location = new System.Drawing.Point(494, 56);
            this.TB_Conn.MaxLength = 300;
            this.TB_Conn.Multiline = true;
            this.TB_Conn.Name = "TB_Conn";
            this.TB_Conn.ReadOnly = true;
            this.TB_Conn.Size = new System.Drawing.Size(249, 108);
            this.TB_Conn.TabIndex = 25;
            // 
            // TB_App
            // 
            this.TB_App.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_App.Location = new System.Drawing.Point(152, 141);
            this.TB_App.MaxLength = 300;
            this.TB_App.Name = "TB_App";
            this.TB_App.Size = new System.Drawing.Size(306, 23);
            this.TB_App.TabIndex = 24;
            this.TB_App.TextChanged += new System.EventHandler(this.TB_SQL_TextChanged);
            // 
            // TB_Password
            // 
            this.TB_Password.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Password.Location = new System.Drawing.Point(152, 112);
            this.TB_Password.MaxLength = 300;
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(306, 23);
            this.TB_Password.TabIndex = 23;
            this.TB_Password.TextChanged += new System.EventHandler(this.TB_SQL_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "패스워드 : ";
            // 
            // TB_ID
            // 
            this.TB_ID.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_ID.Location = new System.Drawing.Point(152, 83);
            this.TB_ID.MaxLength = 300;
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(306, 23);
            this.TB_ID.TabIndex = 21;
            this.TB_ID.TextChanged += new System.EventHandler(this.TB_SQL_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "아이디 : ";
            // 
            // TB_IP
            // 
            this.TB_IP.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_IP.Location = new System.Drawing.Point(152, 54);
            this.TB_IP.MaxLength = 300;
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(306, 23);
            this.TB_IP.TabIndex = 19;
            this.TB_IP.TextChanged += new System.EventHandler(this.TB_SQL_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "접근경로 : ";
            // 
            // TB_Container
            // 
            this.TB_Container.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Container.Location = new System.Drawing.Point(152, 25);
            this.TB_Container.MaxLength = 300;
            this.TB_Container.Name = "TB_Container";
            this.TB_Container.Size = new System.Drawing.Size(306, 23);
            this.TB_Container.TabIndex = 17;
            this.TB_Container.TextChanged += new System.EventHandler(this.TB_SQL_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "데이터베이스 명칭 : ";
            // 
            // grp_func
            // 
            this.grp_func.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_func.Controls.Add(this.btn_db_copy);
            this.grp_func.Controls.Add(this.btn_copy);
            this.grp_func.Controls.Add(this.Btn_Get_Target_Db);
            this.grp_func.Location = new System.Drawing.Point(13, 321);
            this.grp_func.Name = "grp_func";
            this.grp_func.Size = new System.Drawing.Size(775, 117);
            this.grp_func.TabIndex = 2;
            this.grp_func.TabStop = false;
            this.grp_func.Text = "기능";
            // 
            // btn_copy
            // 
            this.btn_copy.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_copy.Location = new System.Drawing.Point(273, 33);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(151, 66);
            this.btn_copy.TabIndex = 1;
            this.btn_copy.Text = "소스복사하기";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // Btn_Get_Target_Db
            // 
            this.Btn_Get_Target_Db.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Get_Target_Db.Location = new System.Drawing.Point(24, 33);
            this.Btn_Get_Target_Db.Name = "Btn_Get_Target_Db";
            this.Btn_Get_Target_Db.Size = new System.Drawing.Size(243, 66);
            this.Btn_Get_Target_Db.TabIndex = 0;
            this.Btn_Get_Target_Db.Text = "대상에서 접속정보 가져오기";
            this.Btn_Get_Target_Db.UseVisualStyleBackColor = true;
            this.Btn_Get_Target_Db.Click += new System.EventHandler(this.Btn_Get_Target_Db_Click);
            // 
            // btn_db_copy
            // 
            this.btn_db_copy.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_db_copy.Location = new System.Drawing.Point(430, 33);
            this.btn_db_copy.Name = "btn_db_copy";
            this.btn_db_copy.Size = new System.Drawing.Size(151, 66);
            this.btn_db_copy.TabIndex = 2;
            this.btn_db_copy.Text = "DB복사하기";
            this.btn_db_copy.UseVisualStyleBackColor = true;
            this.btn_db_copy.Click += new System.EventHandler(this.btn_db_copy_Click);
            // 
            // FindProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp_func);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FindProjectForm";
            this.Text = "FindProjectForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_func.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.TextBox TB_Location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Search_Path;
        private System.Windows.Forms.TextBox TB_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_Conn;
        private System.Windows.Forms.TextBox TB_App;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Container;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grp_func;
        private System.Windows.Forms.Button Btn_Get_Target_Db;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_db_copy;
    }
}