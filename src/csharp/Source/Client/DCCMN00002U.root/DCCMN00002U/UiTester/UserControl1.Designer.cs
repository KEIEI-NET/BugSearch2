namespace Broadleaf.Library.Windows.Forms
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput( this.components );
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl( this.components );
            this.SuspendLayout();
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControl1";
            this.VisibleChanged += new System.EventHandler( this.UserControl1_VisibleChanged );
            this.ResumeLayout( false );

        }

        #endregion

        private UiMemInput uiMemInput1;
        private UiSetControl uiSetControl1;
    }
}
