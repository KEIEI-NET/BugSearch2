namespace Broadleaf.Windows.Forms
{
    partial class PMUOE01600UA
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMUOE01600UA ) );
            this.SuspendLayout();
            // 
            // PMUOE01600UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "PMUOE01600UA";
            this.Text = "ホンダe-parts伝票番号引当処理";
            this.Load += new System.EventHandler( this.PMUOE01600UA_Load );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.PMUOE01600UA_FormClosed );
            this.ResumeLayout( false );

        }

        #endregion
    }
}

