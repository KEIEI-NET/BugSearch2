namespace Broadleaf.Application.Common
{
    /// <summary>
    /// NewActiveReport1 の概要の説明です。
    /// </summary>
    partial class QRReport
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
            }
            base.Dispose( disposing );
        }

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( QRReport ) );
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.barcode1 = new DataDynamics.ActiveReports.Barcode();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.CanGrow = false;
            this.pageHeader.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.barcode1} );
            this.pageHeader.Height = 1F;
            this.pageHeader.Name = "pageHeader";
            // 
            // barcode1
            // 
            this.barcode1.BarWidth = 4F;
            this.barcode1.Border.BottomColor = System.Drawing.Color.Black;
            this.barcode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.Border.LeftColor = System.Drawing.Color.Black;
            this.barcode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.Border.RightColor = System.Drawing.Color.Black;
            this.barcode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.Border.TopColor = System.Drawing.Color.Black;
            this.barcode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.barcode1.CheckSumEnabled = false;
            this.barcode1.DataField = "QRDATA";
            this.barcode1.Font = new System.Drawing.Font( "Courier New", 8F );
            this.barcode1.Height = 0.899F;
            this.barcode1.Left = 0.05F;
            this.barcode1.Name = "barcode1";
            this.barcode1.QRCode.ErrorLevel = DataDynamics.ActiveReports.Options.QRCodeErrorLevel.M;
            this.barcode1.QRCode.Mask = DataDynamics.ActiveReports.Options.QRCodeMask.Mask101;
            this.barcode1.QRCode.Version = 6;
            this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode;
            this.barcode1.Text = "^001003OQ9hMH1DRpI7Ud/BCulbzfyo2JNcrLI5kkq88NfIm6ZpKKHanr3ijB9XZxQe+KMyTcvcJc0V8W" +
                "PbQEnt57vWsQVKY+oD7Kx5";
            this.barcode1.Top = 0.05F;
            this.barcode1.Width = 0.899F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // QRReport
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 1F;
            this.Sections.Add( this.pageHeader );
            this.Sections.Add( this.detail );
            this.Sections.Add( this.pageFooter );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 16pt; font-weight: bold; ", "Heading1", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 14pt; font-weight: bold; ", "Heading2", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 13pt; font-weight: bold; ", "Heading3", "Normal" ) );
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Barcode barcode1;

    }
}
