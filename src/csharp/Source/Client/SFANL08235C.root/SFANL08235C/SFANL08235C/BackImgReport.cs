using System;
using System.Drawing;
using System.Drawing.Printing;
using DataDynamics;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 背景画像オーバーレイ用レポートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 背景画像オーバーレイ用レポートクラス</br>
    /// <br>Programer  : 22011 柏原 頼人</br>
    /// <br>Date       : 2007.06.19</br>
    /// <br>Update Note:</br>
    /// </remarks>
	public class BackImgReport : DataDynamics.ActiveReports.ActiveReport3
	{
        /// <summary>
        /// 
        /// </summary>
		public BackImgReport()
		{
			InitializeComponent();
        }

        #region propaty
        /// public propaty name  :  PrintPprBgImageData
        /// <summary>帳票背景画像データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票背景画像データプロパティ</br>
        /// <br>Programer        :   22011 柏原 頼人</br>
        /// </remarks>
        public System.Drawing.Image BgImagePicture_Image
        {
            set { BgImagePicture.Image = value; }
        }
        #endregion

        #region public methods
        /// <summary>
        /// 背景画像用レポートのサイズを設定します
        /// </summary>
        /// <param name="dstRpt">(設定するパラメータ)DataDynamics.ActiveReports.PageSettings</param>
        /// <param name="prtPprBgImageRowPos">帳票背景画像縦位置</param>
        /// <param name="prtPprBgImageColPos">帳票背景画像横位置</param>
        public void SetRprSize(DataDynamics.ActiveReports.ActiveReport3 dstRpt, double prtPprBgImageRowPos, double prtPprBgImageColPos)
        {
            this.PageSettings.Orientation = dstRpt.PageSettings.Orientation;
            this.PageSettings.PaperKind = dstRpt.PageSettings.PaperKind;

            if (dstRpt.PageSettings.Orientation == PageOrientation.Landscape)
            {
                //横方向
                this.PrintWidth = dstRpt.PageSettings.PaperHeight;
                this.PageSettings.PaperWidth = dstRpt.PageSettings.PaperHeight;
                this.PageSettings.PaperHeight = dstRpt.PageSettings.PaperWidth;

                BgImagePicture.Size = new SizeF(
                    dstRpt.Document.Printer.PaperHeight - (ActiveReport3.CmToInch((float)prtPprBgImageColPos)),                    
                    dstRpt.Document.Printer.PaperWidth - (ActiveReport3.CmToInch((float)prtPprBgImageRowPos)));
            }
            else
            {
                //縦方向
                this.PrintWidth = dstRpt.PageSettings.PaperWidth;
                this.PageSettings.PaperWidth = dstRpt.PageSettings.PaperWidth;
                this.PageSettings.PaperHeight = dstRpt.PageSettings.PaperHeight;

                BgImagePicture.Size = new SizeF(
                    dstRpt.Document.Printer.PaperWidth - (ActiveReport3.CmToInch((float)prtPprBgImageRowPos)),
                    dstRpt.Document.Printer.PaperHeight - (ActiveReport3.CmToInch((float)prtPprBgImageColPos)));
            }

            BgImagePicture.Top = ActiveReport3.CmToInch((float)prtPprBgImageRowPos);
            BgImagePicture.Left = ActiveReport3.CmToInch((float)prtPprBgImageColPos);
        }
        #endregion

        #region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.Picture BgImagePicture;
		private DataDynamics.ActiveReports.PageFooter PageFooter;

        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackImgReport));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.BgImagePicture = new DataDynamics.ActiveReports.Picture();
            ((System.ComponentModel.ISupportInitialize)(this.BgImagePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.BgImagePicture});
            this.Detail.Height = 3.916667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Height = 0F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Visible = false;
            // 
            // PageFooter
            // 
            this.PageFooter.CanGrow = false;
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Visible = false;
            // 
            // BgImagePicture
            // 
            this.BgImagePicture.Border.BottomColor = System.Drawing.Color.Black;
            this.BgImagePicture.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BgImagePicture.Border.LeftColor = System.Drawing.Color.Black;
            this.BgImagePicture.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BgImagePicture.Border.RightColor = System.Drawing.Color.Black;
            this.BgImagePicture.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BgImagePicture.Border.TopColor = System.Drawing.Color.Black;
            this.BgImagePicture.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BgImagePicture.DataField = "pict";
            this.BgImagePicture.Height = 3.771326F;
            this.BgImagePicture.Image = null;
            this.BgImagePicture.ImageData = null;
            this.BgImagePicture.Left = 0F;
            this.BgImagePicture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BgImagePicture.LineWeight = 0F;
            this.BgImagePicture.Name = "BgImagePicture";
            this.BgImagePicture.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft;
            this.BgImagePicture.Top = 0F;
            this.BgImagePicture.Width = 9.308236F;
            // 
            // ActiveReport31
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 8.260417F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.BgImagePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion
    }
}
