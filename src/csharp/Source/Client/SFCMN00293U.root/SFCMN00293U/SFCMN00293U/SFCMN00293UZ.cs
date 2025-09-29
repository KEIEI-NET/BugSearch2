using System;
using System.Xml;
using System.Windows.Forms;
using System.Drawing.Printing;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Drawing.Printing;
using DataDynamics.ActiveReports.Document;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using DataDynamics.ActiveReports;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ActiveReport共通関数部品クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveReport共通関数部品クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.18</br>
	/// <br>Update Note: 2006.11.28 Y.Sasaki</br>
	/// <br>           : １.印刷する用紙サイズがサポートされていない場合の対応</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.22 鈴木 正臣</br>
    /// <br>           : PM.NS向け対応。ドットプリンタ印刷に対応するため用紙サイズ設定を微調整する。</br>
    /// <br>Update Note: 2012/05/17 yangmj</br>
    /// <br>           : 指定ページ印刷の追加</br>
    /// <br></br>
	/// </remarks>
	public class SFCMN00293UZ
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// ActiveReport共通関数部品クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public SFCMN00293UZ()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
            _prtManageList = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD
		}
		#endregion
	
		#region private member
		private XmlDocument doc                   = new XmlDocument();			// 設定ファイル読込用ドキュメント
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        private ActiveReport3 _report; // 対象レポート
        private bool _cancel; // 対象レポート通常印刷キャンセルフラグ
        private ArrayList _prtManageList; // プリンタ設定リスト
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

        //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加----->>>>>
        private ArrayList _pageList;
        //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加-----<<<<<
		#endregion
		
		/// <summary>
		/// プリンター情報設定処理
		/// </summary>
		/// <param name="rpt">対象ActiveReportクラス</param>
		/// <param name="commonInfo">共通パラメータ情報</param>
		/// <param name="message">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note       : プリンタ情報の設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		internal int SetPrinterInfo(ref DataDynamics.ActiveReports.ActiveReport3 rpt, SFCMN00293UC commonInfo, out string message)
		{
			message = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			try
			{
				// 印刷ドキュメント名
				rpt.Document.Name = commonInfo.PrintName;
				
				// 上下左右余白設定
				float marginsTop    = rpt.PageSettings.Margins.Top; 
				float marginsBottom = rpt.PageSettings.Margins.Bottom; 
				float marginsLeft   = rpt.PageSettings.Margins.Left; 
				float marginsRight  = rpt.PageSettings.Margins.Right; 
				
				marginsTop += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsTop / 100);
				if (marginsTop < 0) marginsTop = (float)0;
				
				marginsBottom += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsBottom / 100);
				if (marginsBottom < 0) marginsBottom = (float)0;
				
				marginsLeft += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsLeft / 100);
				if (marginsLeft < 0) marginsLeft = (float)0;
				
				marginsRight += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsRight / 100);
				if (marginsRight < 0) marginsRight = (float)0;

				rpt.PageSettings.Margins.Top    = marginsTop; 
				rpt.PageSettings.Margins.Bottom = marginsBottom;
				rpt.PageSettings.Margins.Left   = marginsLeft;
				rpt.PageSettings.Margins.Right  = marginsRight; 
				
				// 印刷範囲を指定
				// 全ページ
				if (commonInfo.PrintRange == 0)
				{
					rpt.Document.Printer.PrinterSettings.PrintRange	= PrintRange.AllPages;
				} 

					// ページ範囲指定
				else 
				{
					rpt.Document.Printer.PrinterSettings.PrintRange	= PrintRange.SomePages;
					rpt.Document.Printer.PrinterSettings.FromPage	  = commonInfo.PrintTopPage;
					rpt.Document.Printer.PrinterSettings.ToPage		  = commonInfo.PrintEndPage;
				}
				
				rpt.Document.Printer.PrinterSettings.PrintRange	= PrintRange.AllPages;
				
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

				// >>>>> 2006.11.28 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				
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
					isPaperKind = CheckSupportPaperKind(rpt.PageSettings.PaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes);
    
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
				// <<<<< 2006.11.28 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                SettingPaperKind( ref rpt, PaperKind.A3, PaperKind.A3Rotated );
                SettingPaperKind( ref rpt, PaperKind.A4, PaperKind.A4Rotated );
                SettingPaperKind( ref rpt, PaperKind.A5, PaperKind.A5Rotated );
                SettingPaperKind( ref rpt, PaperKind.A6, PaperKind.A6Rotated );
                SettingPaperKind( ref rpt, PaperKind.B4, PaperKind.B4JisRotated );
                SettingPaperKind( ref rpt, PaperKind.B5, PaperKind.B5JisRotated );
                SettingPaperKind( ref rpt, PaperKind.B6Jis, PaperKind.B6JisRotated );
                // 入庫予定表がLetterで作成されていた為対応。
                SettingPaperKind( ref rpt, PaperKind.Letter, PaperKind.A4Rotated );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        /// <summary>
        /// 用紙種別設定処理（A4縦/縦横反転→A4横/通常）
        /// </summary>
        /// <param name="rpt"></param>
        /// <param name="orgPaperKind"></param>
        /// <param name="newPaperKind"></param>
        private void SettingPaperKind( ref DataDynamics.ActiveReports.ActiveReport3 rpt, PaperKind orgPaperKind, PaperKind newPaperKind )
        {
            if ( rpt.PageSettings.PaperKind == orgPaperKind && rpt.PageSettings.Orientation == PageOrientation.Landscape )
            {
                if ( CheckSupportPaperKind( newPaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes ) )
                {
                    rpt.PageSettings.PaperKind = newPaperKind;
                    rpt.PageSettings.Orientation = PageOrientation.Portrait;
                }
            }        
        }
        /// <summary>
        /// ドットプリンタ選択処理（プリンタ設定の中からドットプリンタを１つ選択します）
        /// </summary>
        /// <param name="commonInfo"></param>
        internal void SelectDotPrinter( ref SFCMN00293UC commonInfo )
        {
            PrtManage prtManage = null;

            int status;
            ArrayList retList = _prtManageList;
            if ( retList == null )
            {
                PrtManageAcs prtManageAcs = new Broadleaf.Application.Controller.PrtManageAcs();
                status = prtManageAcs.SearchAll( out retList, LoginInfoAcquisition.EnterpriseCode.Trim() );
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                List<PrtManage> prtManageList = new List<PrtManage>( (PrtManage[])retList.ToArray( typeof( PrtManage ) ) );
                if ( prtManageList != null )
                {
                    prtManage = prtManageList.Find(
                                    delegate( PrtManage prt )
                                    {
                                        // 1:ドットプリンタ
                                        return (prt.PrinterKind == 1);
                                    } );
                }
            }

            // 該当があればプリンタ名を差し替える
            if ( prtManage != null )
            {
                commonInfo.PrinterName = prtManage.PrinterName;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

		/// <summary>
		/// 用紙サポートチェック
		/// </summary>
		/// <param name="paperKind">用紙サイズ</param>
		/// <param name="paperSizeCollection">該当プリンタの用紙サイズコレクション</param>
		/// <returns>[T:サポート,F:非サポート]</returns>
		/// <remarks>
		/// <br>Note       : 該当用紙サイズのサポート有無チェックを行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.11.28</br>
		/// </remarks>
		internal bool CheckSupportPaperKind(PaperKind paperKind, PrinterSettings.PaperSizeCollection paperSizeCollection)
		{
			foreach (PaperSize paperSize in paperSizeCollection)
			{
				if (paperKind.Equals(paperSize.Kind))	return true;
			}
			return false;
		}
		
		/// <summary>
		/// 印字位置調整
		/// </summary>
		/// <param name="positionAdjLib">印字位置調整部品オブジェクト</param>
		/// <param name="rpt">対象レポートオブジェクト</param>
		/// <param name="commonInfo">共通パラメータ情報</param>
		/// <param name="isBackGroundPicture">背景画像作成有無</param>
		/// <remarks>
		/// <br>Note       : 印字位置調整部品による印字位置調整を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.06</br>
		/// </remarks>
		internal void AdjustPrintPosition(ref SFCMN00294CA positionAdjLib, ref DataDynamics.ActiveReports.ActiveReport3 rpt,SFCMN00293UC commonInfo,bool isBackGroundPicture)
		{
			// 印字位置調整する
			if (commonInfo.PrintPositionAdjust == 1)
			{
				// 印字位置調整実行
				positionAdjLib.XmlRead_OutputPrtItemInfoSet(
					commonInfo.OutputFormID,
					rpt,
					isBackGroundPicture);
			}
		}

		/// <summary>
		/// 設定ファイル読込処理
		/// </summary>
		/// <param name="fileName">設定ファイル名</param>
		/// <remarks>
		/// <br>Note       : 共通設定画面の設ファイルを読込ます。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.09</br>
		/// </remarks>
		internal bool ReadSettingFile(string fileName)
		{
			bool result = false;
			try
			{
				// ファイルの存在確認
				if(System.IO.File.Exists(fileName))
				{
					doc.Load(fileName);
					result = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return result;
		}
		
		/// <summary>
		/// セクション読込処理
		/// </summary>
		/// <param name="sectionName">セクション名</param>
		/// <param name="key">キー</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : セクション、キー情報より設定値を取得します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.09</br>
		/// </remarks>
		internal object ReadSection(string sectionName, string key)
		{
			object retObj = null;

			try
			{
				if (doc != null)
				{
					//セクションとKEYから設定情報を取得
					// XMLファイルの検索
					XmlNode xmlNode = doc.SelectSingleNode("/Sections/Section/"+sectionName+"/"+key);			
					string retStr = xmlNode.FirstChild.InnerText;

					retObj = retStr;
				}
			}
			catch (Exception)
			{
			}
			return retObj;
		}
		
		/// <summary>
		/// メッセージ表示
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">エラーメッセージ</param>
		/// <param name="iSt">ステータス</param>
		/// <param name="iButton">表示ボタン</param>
		/// <param name="iDefButton">デフォルトフォーカスボタン</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : 出力件数の設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		internal DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "SFCMN00293U", iMsg, iSt, iButton, iDefButton);
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        /// <summary>
        /// プリンタ設定取得処理
        /// </summary>
        /// <param name="enterpriseName"></param>
        /// <param name="printerName"></param>
        /// <returns></returns>
        internal PrtManage GetPrtManage( string enterpriseName, string printerName )
        {
            PrtManage prtManage = null;

            int status;
            ArrayList retList = _prtManageList;
            if ( retList == null )
            {
                PrtManageAcs prtManageAcs = new Broadleaf.Application.Controller.PrtManageAcs();
                status = prtManageAcs.SearchAll( out retList, enterpriseName );
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                List<PrtManage> prtManageList = new List<PrtManage>( (PrtManage[])retList.ToArray( typeof( PrtManage ) ) );
                if ( prtManageList != null )
                {
                    prtManage = prtManageList.Find( 
                                    delegate( PrtManage prt )
                                    {
                                        return (prt.PrinterName.Trim() == printerName.Trim());
                                    } );
                }
            }
            return prtManage;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        /// <summary>
        /// ドキュメント印刷処理
        /// </summary>
        /// <param name="showDialog"></param>
        /// <param name="report"></param>
        /// <param name="printerName"></param>
        /// <returns></returns>
        /// <br>Update Note: 2012/05/17 yangmj</br>
        /// <br>           : 指定ページ印刷の追加</br>
        internal bool PrintDocument( bool showDialog, DataDynamics.ActiveReports.ActiveReport3 report, string printerName )
        {
            // レポートを退避
            _report = report;
            //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加----->>>>>
            if (_pageList != null && _pageList.Count > 0)
            {
                for (int i = _report.Document.Pages.Count - 1; i >= 0; i--)
                {
                    if (!_pageList.Contains(i))
                    {
                        _report.Document.Pages.RemoveAt(i);
                    }
                }
            }
            //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加-----<<<<<

            // キャンセルフラグ初期化
            _cancel = false;
            // イベント登録
            report.Document.Printer.BeginPrint += new PrintEventHandler( Printer_BeginPrint );
            
            // 印刷（開始時にPrinter_BeginPrintがコールされる）
            //report.Document.Print( showDialog, false, false );
            report.Document.Print( false, false, false );

            return _cancel;
        }
        //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加----->>>>>
        /// <summary>
        /// 選択されたページの設定
        /// </summary>
        /// <param name="pageList"></param>
        /// <returns></returns>
        /// <br>Note       : 選択されたページを設定する。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// <br></br>
        internal void setPageRange(ArrayList pageList)
        {
            _pageList = pageList;
        }
        //--- ADD 2012/05/17 yangmj 指定ページ印刷の追加-----<<<<<

        /// <summary>
        /// 印刷開始処理（通常処理・カスタム印刷処理を切り替える）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Printer_BeginPrint( object sender, PrintEventArgs e )
        {
            try
            {
                // プリンタ名取得→プリンタ設定取得
                string printerName = _report.Document.Printer.PrinterSettings.PrinterName.Trim();
                PrtManage prtManage = GetPrtManage( LoginInfoAcquisition.EnterpriseCode.Trim(), printerName );

                // 該当なし、0:レーザー、用紙サイズ=Customならば通常の処理
                if ( prtManage == null || prtManage.PrinterKind == 0 || _report.PageSettings.PaperKind == PaperKind.Custom )
                {
                    //-----------------------------------------------
                    // .NS標準の印刷処理（レーザープリンタ）
                    //-----------------------------------------------
                    e.Cancel = false;
                }
                else
                {
                    //-----------------------------------------------
                    // 用紙拡大する（ドットプリンタ対応）
                    //-----------------------------------------------
                    e.Cancel = true;

                    // 通常処理をキャンセルして以下の処理で差し替える
                    PrintDocusmentControl printDocusmentControl = new PrintDocusmentControl();
                    printDocusmentControl.Report = _report;
                    printDocusmentControl.PrinterName = printerName;
                    printDocusmentControl.Print();
                }
                _cancel = e.Cancel;
            }
            catch
            {
            }
        }

        # region [ドキュメント印刷制御クラス]
        /// <summary>
        /// ドキュメント印刷制御クラス
        /// </summary>
        internal class PrintDocusmentControl
        {
            private DataDynamics.ActiveReports.Document.Document ardoc;
            private int arPages;
            private DataDynamics.ActiveReports.ActiveReport3 _report;
            private string _printerName;

            /// <summary>
            /// プリンタ名
            /// </summary>
            public string PrinterName
            {
                get { return _printerName; }
                set { _printerName = value; }
            }

            /// <summary>
            /// レポート
            /// </summary>
            public DataDynamics.ActiveReports.ActiveReport3 Report
            {
                get { return _report; }
                set { _report = value; }
            }

            /// <summary>
            /// ページ印刷イベント処理
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void PrintPage( object sender, System.Drawing.Printing.PrintPageEventArgs e )
            {
                if ( _report.Document.Printer.PrinterSettings.PrintRange == PrintRange.AllPages ||
                     (_report.Document.Printer.PrinterSettings.FromPage <= arPages &&
                      arPages <= _report.Document.Printer.PrinterSettings.ToPage) )
                {
                    // PrintDocumetの座標単位は1/100インチなので、以降、インチで扱うためにここで変換します。
                    float width = e.PageBounds.Width / 100.0f;
                    float height = e.PageBounds.Height / 100.0f;

                    //RectangleF boundsInch = new RectangleF( 0, 0, width, height );
                    RectangleF boundsInch = new RectangleF( -0.2f, 0, width - 0.5f, height );

                    // PrintDocumentに描画するActiveReportsページを取得します。
                    DataDynamics.ActiveReports.Document.Page page = ardoc.Pages[arPages];

                    // 拡大縮小比の計算
                    float scaleX = boundsInch.Width / page.Width;
                    float scaleY = boundsInch.Height / page.Height;

                    // レポートのアスペクト比を維持するために、scaleXとscaleYを
                    // 同じ値にセットします。
                    // ※元のアスペクト比が維持されない場合、印刷時にフォントが崩れるなど弊害が発生します。
                    if ( scaleX > scaleY ) scaleX = scaleY;
                    else scaleY = scaleX;

                    // ページを描画します。
                    page.Draw( e.Graphics, boundsInch, scaleX, scaleY, true );
                }
                else
                {
                    // 対象外
                }

                arPages++;

                // 全ページ印刷したら終了します。
                if ( arPages < ardoc.Pages.Count )
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
            /// <summary>
            /// 印刷実行
            /// </summary>
            public void Print()
            {
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                // ドキュメント名
                pd.DocumentName = _report.Document.Name;
                // プリンタ名
                pd.PrinterSettings.PrinterName = _printerName;
                // 用紙サイズ
                // 　→ストックフォームに合わせる（15.00[inch]×11.00[inch]）
                pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize( "ARCustomForm", 1500, 1100 );

                // 用紙方向
                pd.DefaultPageSettings.Landscape = (_report.PageSettings.Orientation == PageOrientation.Landscape);

                // 印刷中ダイアログを出さない
                pd.PrintController = new StandardPrintController();

                // 頁印刷イベント処理の登録
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler( PrintPage );
                ardoc = _report.Document;
                arPages = 0;

                pd.Print();
            }
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
	}

	/// <summary>
	/// ActiveReport共通部品例外クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveReport共通部品例外クラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.18</br>
	/// <br></br>
	/// </remarks>
	public class ActiveReportPrintException: ApplicationException
	{
		private int _status;

		/// <summary>
		/// ActiveReport共通部品例外クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public ActiveReportPrintException(string message, int status): base(message)
		{
			this._status = status;
		}
	
		/// <summary>
		/// エラーステータス
		/// </summary>
		public int Status
		{
			get{return this._status;}
		}
	}

}
