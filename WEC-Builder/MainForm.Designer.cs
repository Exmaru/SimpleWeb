
namespace WEC_Builder
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새프로젝트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로젝트불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.데이터베이스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.연결정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sP만들기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.웹코드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.목록코드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상세코드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.처리코드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모듈설치ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aDMSETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardSETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.게시판관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.데이터베이스ToolStripMenuItem,
            this.웹코드ToolStripMenuItem,
            this.모듈설치ToolStripMenuItem,
            this.게시판관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새프로젝트ToolStripMenuItem,
            this.프로젝트불러오기ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripSeparator4,
            this.종료ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.fileToolStripMenuItem.Text = "프로젝트";
            // 
            // 새프로젝트ToolStripMenuItem
            // 
            this.새프로젝트ToolStripMenuItem.Name = "새프로젝트ToolStripMenuItem";
            this.새프로젝트ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.새프로젝트ToolStripMenuItem.Text = "새 프로젝트";
            this.새프로젝트ToolStripMenuItem.Click += new System.EventHandler(this.새프로젝트ToolStripMenuItem_Click);
            // 
            // 프로젝트불러오기ToolStripMenuItem
            // 
            this.프로젝트불러오기ToolStripMenuItem.Name = "프로젝트불러오기ToolStripMenuItem";
            this.프로젝트불러오기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.프로젝트불러오기ToolStripMenuItem.Text = "프로젝트불러오기";
            this.프로젝트불러오기ToolStripMenuItem.Click += new System.EventHandler(this.프로젝트불러오기ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 데이터베이스ToolStripMenuItem
            // 
            this.데이터베이스ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.연결정보ToolStripMenuItem,
            this.toolStripSeparator2,
            this.sP만들기ToolStripMenuItem,
            this.toolStripSeparator3,
            this.aDMSETToolStripMenuItem,
            this.boardSETToolStripMenuItem});
            this.데이터베이스ToolStripMenuItem.Name = "데이터베이스ToolStripMenuItem";
            this.데이터베이스ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.데이터베이스ToolStripMenuItem.Text = "데이터베이스";
            // 
            // 연결정보ToolStripMenuItem
            // 
            this.연결정보ToolStripMenuItem.Name = "연결정보ToolStripMenuItem";
            this.연결정보ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.연결정보ToolStripMenuItem.Text = "연결정보";
            this.연결정보ToolStripMenuItem.Click += new System.EventHandler(this.연결정보ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // sP만들기ToolStripMenuItem
            // 
            this.sP만들기ToolStripMenuItem.Name = "sP만들기ToolStripMenuItem";
            this.sP만들기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sP만들기ToolStripMenuItem.Text = "SP만들기";
            this.sP만들기ToolStripMenuItem.Click += new System.EventHandler(this.sP만들기ToolStripMenuItem_Click);
            // 
            // 웹코드ToolStripMenuItem
            // 
            this.웹코드ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.목록코드ToolStripMenuItem,
            this.상세코드ToolStripMenuItem,
            this.처리코드ToolStripMenuItem});
            this.웹코드ToolStripMenuItem.Name = "웹코드ToolStripMenuItem";
            this.웹코드ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.웹코드ToolStripMenuItem.Text = "웹코드";
            // 
            // 목록코드ToolStripMenuItem
            // 
            this.목록코드ToolStripMenuItem.Name = "목록코드ToolStripMenuItem";
            this.목록코드ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.목록코드ToolStripMenuItem.Text = "목록코드";
            this.목록코드ToolStripMenuItem.Click += new System.EventHandler(this.목록코드ToolStripMenuItem_Click);
            // 
            // 상세코드ToolStripMenuItem
            // 
            this.상세코드ToolStripMenuItem.Name = "상세코드ToolStripMenuItem";
            this.상세코드ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.상세코드ToolStripMenuItem.Text = "상세코드";
            this.상세코드ToolStripMenuItem.Click += new System.EventHandler(this.상세코드ToolStripMenuItem_Click);
            // 
            // 처리코드ToolStripMenuItem
            // 
            this.처리코드ToolStripMenuItem.Name = "처리코드ToolStripMenuItem";
            this.처리코드ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.처리코드ToolStripMenuItem.Text = "처리코드";
            this.처리코드ToolStripMenuItem.Click += new System.EventHandler(this.처리코드ToolStripMenuItem_Click);
            // 
            // 모듈설치ToolStripMenuItem
            // 
            this.모듈설치ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDMToolStripMenuItem});
            this.모듈설치ToolStripMenuItem.Name = "모듈설치ToolStripMenuItem";
            this.모듈설치ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.모듈설치ToolStripMenuItem.Text = "모듈설치";
            // 
            // aDMToolStripMenuItem
            // 
            this.aDMToolStripMenuItem.Name = "aDMToolStripMenuItem";
            this.aDMToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.aDMToolStripMenuItem.Text = "ADM";
            this.aDMToolStripMenuItem.Click += new System.EventHandler(this.aDMToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel1.Text = "WEC-Builder v1.0";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // aDMSETToolStripMenuItem
            // 
            this.aDMSETToolStripMenuItem.Name = "aDMSETToolStripMenuItem";
            this.aDMSETToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aDMSETToolStripMenuItem.Text = "ADM SET";
            // 
            // boardSETToolStripMenuItem
            // 
            this.boardSETToolStripMenuItem.Name = "boardSETToolStripMenuItem";
            this.boardSETToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boardSETToolStripMenuItem.Text = "Board SET";
            // 
            // 게시판관리ToolStripMenuItem
            // 
            this.게시판관리ToolStripMenuItem.Name = "게시판관리ToolStripMenuItem";
            this.게시판관리ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.게시판관리ToolStripMenuItem.Text = "게시판관리";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "프로젝트 재설정";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "WEC-Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새프로젝트ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프로젝트불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 데이터베이스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 연결정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sP만들기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 웹코드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 목록코드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상세코드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 처리코드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모듈설치ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aDMSETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boardSETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 게시판관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

