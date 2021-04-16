
namespace WEC_Builder.Models
{
    partial class ApiTestParameters
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.TB_Value = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TB_ID
            // 
            this.TB_ID.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_ID.Location = new System.Drawing.Point(4, 4);
            this.TB_ID.MaxLength = 100;
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(85, 22);
            this.TB_ID.TabIndex = 0;
            // 
            // TB_Value
            // 
            this.TB_Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Value.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Value.Location = new System.Drawing.Point(95, 3);
            this.TB_Value.MaxLength = 1000;
            this.TB_Value.Name = "TB_Value";
            this.TB_Value.Size = new System.Drawing.Size(129, 22);
            this.TB_Value.TabIndex = 1;
            // 
            // ApiTestParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TB_Value);
            this.Controls.Add(this.TB_ID);
            this.Name = "ApiTestParameters";
            this.Size = new System.Drawing.Size(227, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.TextBox TB_Value;
    }
}
