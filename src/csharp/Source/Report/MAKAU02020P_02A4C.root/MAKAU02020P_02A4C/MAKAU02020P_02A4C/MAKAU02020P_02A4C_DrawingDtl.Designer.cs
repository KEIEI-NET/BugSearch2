namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// DrawingDetail の概要の説明です。
    /// </summary>
    partial class DrawingDetail
    {
        private DataDynamics.ActiveReports.Detail Detail;

        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( DrawingDetail ) );
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.ResultsSectCd = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox_null = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_null)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.textBox3,
            this.ResultsSectCd,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox_null} );
            this.Detail.Height = 0.34375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.BeforePrint += new System.EventHandler( this.Detail_BeforePrint );
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "CustomerSnm";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 0.8125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "ddo-char-set: 1; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.textBox2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 2.131945F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "CustomerCode";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 0.25F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString( "textBox3.OutputFormat" );
            this.textBox3.Style = "ddo-char-set: 1; text-align: right; font-size: 7.5pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.textBox3.Text = "12345678";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.5F;
            // 
            // ResultsSectCd
            // 
            this.ResultsSectCd.Border.BottomColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.LeftColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.RightColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.TopColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.DataField = "ResultsSectCd";
            this.ResultsSectCd.Height = 0.125F;
            this.ResultsSectCd.Left = 0F;
            this.ResultsSectCd.MultiLine = false;
            this.ResultsSectCd.Name = "ResultsSectCd";
            this.ResultsSectCd.OutputFormat = resources.GetString( "ResultsSectCd.OutputFormat" );
            this.ResultsSectCd.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.ResultsSectCd.Text = "99";
            this.ResultsSectCd.Top = 0F;
            this.ResultsSectCd.Width = 0.1875F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "ThisTimeSales";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 4.03125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString( "textBox4.OutputFormat" );
            this.textBox4.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.textBox4.Text = "2,345,678,901";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.695F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "ThisSalesPricRgdsDis";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 4.713F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString( "textBox5.OutputFormat" );
            this.textBox5.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.textBox5.Text = "2,345,678,901";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.695F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DataField = "NetSales";
            this.textBox6.Height = 0.125F;
            this.textBox6.Left = 5.40625F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString( "textBox6.OutputFormat" );
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-s" +
                "pace: nowrap; vertical-align: top; ";
            this.textBox6.Text = "2,345,678,901";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.695F;
            // 
            // textBox_null
            // 
            this.textBox_null.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_null.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_null.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_null.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_null.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null.Height = 0.125F;
            this.textBox_null.Left = 0F;
            this.textBox_null.Name = "textBox_null";
            this.textBox_null.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox_null.Text = null;
            this.textBox_null.Top = 0.125F;
            this.textBox_null.Visible = false;
            this.textBox_null.Width = 0.375F;
            // 
            // DrawingDetail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.541667F;
            this.Sections.Add( this.Detail );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 16pt; font-weight: bold; ", "Heading1", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 14pt; font-weight: bold; ", "Heading2", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 13pt; font-weight: bold; ", "Heading3", "Normal" ) );
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_null)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox ResultsSectCd;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox6;
        private DataDynamics.ActiveReports.TextBox textBox_null;
    }
}
