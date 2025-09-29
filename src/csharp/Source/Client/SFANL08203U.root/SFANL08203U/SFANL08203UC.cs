using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing.Printing;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ActiveReport共通関数部品クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ActiveReport共通関数部品クラス(SFANL08203UC)の自由帳票版　本当は継承したかった・・・</br>
    /// <br>Programmer : 22011 Kashihara Yorihito</br>
    /// <br>Date       : 2007.06.15</br>
    /// <br>           : </br>
    /// </remarks>
    public class SFANL08203UC
    {
        //================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// ActiveReport関数部品クラスコンストラクタ
		/// </summary>
        public SFANL08203UC()
		{
		}
		#endregion

        #region private member
        private XmlDocument doc = new XmlDocument();			// 設定ファイル読込用ドキュメント
        #endregion

        #region public methods

        #region 画面設定ファイル読込処理
        /// <summary>
        /// 画面設定ファイル読込処理
        /// </summary>
        /// <param name="fileName">設定ファイル名</param>
        public bool ReadSettingFile(string fileName)
        {
            bool result = false;
            try
            {
                // ファイルの存在確認
                if (System.IO.File.Exists(fileName))
                {
                    doc.Load(fileName);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08203UC", "画面設定ファイル読込処理に失敗しました。\r\n詳細：" + ex.Message, 0, MessageBoxButtons.OK);
            }
            return result;
        }
        #endregion

        #region セクション読込処理
        /// <summary>
        /// セクション読込処理
        /// </summary>
        /// <param name="sectionName">セクション名</param>
        /// <param name="key">キー</param>
        /// <returns></returns>
        public object ReadSection(string sectionName, string key)
        {
            object retObj = null;

            try
            {
                if (doc != null)
                {
                    //セクションとKEYから設定情報を取得
                    // XMLファイルの検索
                    XmlNode xmlNode = doc.SelectSingleNode("/Sections/Section/" + sectionName + "/" + key);
                    string retStr = xmlNode.FirstChild.InnerText;

                    retObj = retStr;
                }
            }
            catch (Exception)
            {
            }
            return retObj;
        }
        #endregion

        #region プリンター情報設定処理
        /// <summary>
        /// プリンター情報設定処理
        /// </summary>
        /// <param name="rpt">対象ActiveReportクラス</param>
        /// <param name="commonInfo">共通パラメータ情報</param>
        /// <param name="message">エラーメッセージ</param>
        public int SetPrinterInfo(ref DataDynamics.ActiveReports.ActiveReport3 rpt, SFANL08203UD commonInfo, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                // 印刷ドキュメント名
                rpt.Document.Name = commonInfo.PrintName;

                // 上下左右余白設定
                float marginsTop = rpt.PageSettings.Margins.Top;
                float marginsBottom = rpt.PageSettings.Margins.Bottom;
                float marginsLeft = rpt.PageSettings.Margins.Left;
                float marginsRight = rpt.PageSettings.Margins.Right;

                marginsTop += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsTop / 100);
                if (marginsTop < 0) marginsTop = (float)0;

                marginsBottom += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsBottom / 100);
                if (marginsBottom < 0) marginsBottom = (float)0;

                marginsLeft += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsLeft / 100);
                if (marginsLeft < 0) marginsLeft = (float)0;

                marginsRight += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsRight / 100);
                if (marginsRight < 0) marginsRight = (float)0;

                rpt.PageSettings.Margins.Top = marginsTop;
                rpt.PageSettings.Margins.Bottom = marginsBottom;
                rpt.PageSettings.Margins.Left = marginsLeft;
                rpt.PageSettings.Margins.Right = marginsRight;

                // 印刷範囲を指定
                // 全ページ
                if (commonInfo.PrintRange == 0)
                {
                    rpt.Document.Printer.PrinterSettings.PrintRange = PrintRange.AllPages;
                }

                    // ページ範囲指定
                else
                {
                    rpt.Document.Printer.PrinterSettings.PrintRange = PrintRange.SomePages;
                    rpt.Document.Printer.PrinterSettings.FromPage = commonInfo.PrintTopPage;
                    rpt.Document.Printer.PrinterSettings.ToPage = commonInfo.PrintEndPage;
                }

                rpt.Document.Printer.PrinterSettings.PrintRange = PrintRange.AllPages;

                // 使用プリンターの設定
                foreach (string wkStr in PrinterSettings.InstalledPrinters)
                {
                    if (wkStr.Equals(commonInfo.PrinterName))
                    {
                        rpt.Document.Printer.PrinterSettings.PrinterName = commonInfo.PrinterName;
                        break;
                    }
                }

                // 使用プリンタの有効有無
                if (!rpt.Document.Printer.PrinterSettings.IsValid)
                {
                    rpt.Document.Printer.PrinterSettings.PrinterName = "";
                }

                // 用紙サイズ取得フラグ[T:サポート,F:サポートなし]
                bool isPaperKind = false;

                // 印字方向変更フラグ[T:変更,F:変更無]
                bool isChangeOrientation = false;

                // サポートされている用紙サイズかチェックする
                isPaperKind = CheckSupportPaperKind(rpt.PageSettings.PaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes);

                // もしサポートされてなかったら…
                if (!isPaperKind)
                {
                    // 印刷する用紙サイズ
                    switch (rpt.PageSettings.PaperKind)
                    {
                        case (PaperKind)PaperKind.A3Rotated:
                            {	// A3横
                                rpt.PageSettings.PaperKind = PaperKind.A3;
                                isChangeOrientation = true;
                                break;
                            }
                        case (PaperKind)PaperKind.A4Rotated:
                            {	// A4横 
                                rpt.PageSettings.PaperKind = PaperKind.A4;
                                isChangeOrientation = true;
                                break;
                            }
                        case (PaperKind)PaperKind.A5Rotated:
                            {	// A5横　　　　　　
                                rpt.PageSettings.PaperKind = PaperKind.A5;
                                isChangeOrientation = true;
                                break;
                            }
                        case (PaperKind)PaperKind.A6Rotated:
                            {	// A6横　　　　　　
                                rpt.PageSettings.PaperKind = PaperKind.A6;
                                isChangeOrientation = true;
                                break;
                            }
                        case (PaperKind)PaperKind.B4JisRotated:
                            {	// B4横　　　　　　
                                rpt.PageSettings.PaperKind = PaperKind.B4;
                                isChangeOrientation = true;
                                break;
                            }
                        case (PaperKind)PaperKind.B5JisRotated:
                            {	// B5横　　　　　　
                                rpt.PageSettings.PaperKind = PaperKind.B5;
                                isChangeOrientation = true;
                                break;
                            }
                        case (PaperKind)PaperKind.B6JisRotated:
                            {	// B6横　　　　　　
                                rpt.PageSettings.PaperKind = PaperKind.B6Jis;
                                isChangeOrientation = true;
                                break;
                            }
                        default:  // あえて取得しない↓下で取得する
                            //rpt.PageSettings.PaperKind = rpt.Document.Printer.PrinterSettings.DefaultPageSettings.PaperSize.Kind;
                            break;
                    }

                    // サポートされている用紙サイズかチェックする
                    // isPaperKind = CheckSupportPaperKind(rpt.PageSettings.PaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes);

                    // もしサポートされてなかったら、そのプリンタに設定されている情報を取得する
                    if (!isPaperKind)
                    {
                        // プリンタの用紙のサイズを取得
                        rpt.PageSettings.PaperKind = rpt.Document.Printer.PrinterSettings.DefaultPageSettings.PaperSize.Kind;

                        // プリンタの印刷方向を取得
                        // ページを横向きで印刷する場合は true。それ以外の場合は false
                        if (rpt.Document.Printer.PrinterSettings.DefaultPageSettings.Landscape)
                        {
                            rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
                        }
                        else
                        {
                            rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
                        }

                        // 印刷方向の変更は、これ以上しない
                        isChangeOrientation = false;
                    }

                    // 例：A4横→A4に変更になった場合には、印刷方向の変更を行う
                    if (isChangeOrientation)
                    {
                        // 用紙方向例：A４横→A４等で取得できたなら、縦横を反転する
                        switch (rpt.PageSettings.Orientation)
                        {
                            case ((PageOrientation)PageOrientation.Landscape):
                                rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
                                break;
                            case ((PageOrientation)PageOrientation.Portrait):
                                rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
                                break;
                        }
                    }
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                message = "プリンター情報セット処理処理にて例外が発生しました。"
                    + "\n\r" + ex.Message;
                throw new ActiveReportPrintException(message, status);
            }
            return status;
        }
        #endregion

        #region 用紙サポートチェック
        /// <summary>
        /// 用紙サポートチェック
        /// </summary>
        /// <param name="paperKind">用紙サイズ</param>
        /// <param name="paperSizeCollection">該当プリンタの用紙サイズコレクション</param>
        /// <returns>[T:サポート,F:非サポート]</returns>
        internal bool CheckSupportPaperKind(PaperKind paperKind, PrinterSettings.PaperSizeCollection paperSizeCollection)
        {
            foreach (PaperSize paperSize in paperSizeCollection)
            {
                if (paperKind.Equals(paperSize.Kind)) return true;
            }
            return false;
        }
        #endregion

        #region メッセージ表示
        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        public DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "SFANL08203U", iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        #endregion
    }
}
