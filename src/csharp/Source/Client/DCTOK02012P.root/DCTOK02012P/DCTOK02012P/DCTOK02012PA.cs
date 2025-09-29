using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 売上日報月報印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上日報月報の印刷を行う。</br>
	/// <br>Programmer : 22013 久保 将太</br>
	/// <br>Date       : 2007.03.08</br>
	/// </remarks>
	class DCTOK02012PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 売上日報月報印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上日報月報印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCTOK02012PA()
		{
		}

		/// <summary>
		/// 売上日報月報印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 売上日報月報印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCTOK02012PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._salesDayMonthReport = this._printInfo.jyoken as SalesDayMonthReport;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        // 2008.08.26 30413 犬飼 文言を変更 >>>>>>START
        //private const string ct_Extr_Top = "ＴＯＰ";
        //private const string ct_Extr_End		= "ＥＮＤ";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        // 2008.08.26 30413 犬飼 文言を変更 <<<<<<END
        private const string ct_RangeConst = "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private SalesDayMonthReport _salesDayMonthReport;		// 抽出条件クラス
		#endregion ■ Private Member

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public StockMoveException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region ◆ Public Property
			/// <summary> ステータスプロパティ </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion ■ Exception Class

		#region ■ IPrintProc メンバ
		#region ◆ Public Property
		/// <summary>
		/// 印刷情報取得プロパティ
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 印刷処理開始
		/// <summary>
		/// 印刷処理開始
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷を開始する。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion ◆ Public Method
		#endregion ■ IPrintProc メンバ

		#region ■ Private Member
		#region ◆ 印刷処理
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// 印刷フォームクラスインスタンス作成
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// レポートインスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// データソース設定
				prtRpt.DataSource = this._printInfo.rdData;
				prtRpt.DataMember = DCTOK02014EA.ct_Tbl_SalesDayMonthReportData;
				
				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
			    this.SetPrintCommonInfo(out commonInfo);

			    // プレビュー有無				
			    int mode = this._printInfo.prevkbn;
				
			    // 出力モードがＰＤＦの場合、無条件でプレビュー無
			    if (this._printInfo.printmode == 2)
			    {
			        mode = 0;
			    }
				
			    switch(mode)
			    {
			        case 0:		// プレビュ無
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();
						
			            // 共通条件設定
			            processForm.CommonInfo = commonInfo;

			            // プログレスバーUPイベント追加
			            if (prtRpt is IPrintActiveReportTypeCommon)
			            {
			                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
			                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
			            }

			            // 印刷実行
			            status = processForm.Run(prtRpt);

			            // 戻り値設定
			            this._printInfo.status = status;

			            break;
			        }
			        case 1:		// プレビュ有
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

			            // 共通条件設定
			            viewForm.CommonInfo   = commonInfo;

			            // プレビュー実行
			            status = viewForm.Run(prtRpt); 

			            // 戻り値設定
			            this._printInfo.status = status;
						
			            break;
			        }
			    }

			    // ＰＤＦ出力の場合
			    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			    {
			        switch (this._printInfo.printmode)
			        {
			            case 1:  // プリンタ
			                break;
			            case 2:  // ＰＤＦ
			            case 3:  // 両方(プリンタ + ＰＤＦ)
			            {
			                // ＰＤＦ表示フラグON
			                this._printInfo.pdfopen = true;
   
			                // 両方印刷時のみ履歴保存
			                if (this._printInfo.printmode == 3)
			                {
			                    // 出力履歴管理に追加
			                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
			                        this._printInfo.pdftemppath);
			                }
			                break;
			            }
			        }
			    }
			}
			catch(Exception ex)
			{
			    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			        ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
			    if ( prtRpt != null )
			    {
			        prtRpt.Dispose();
			    }
			}
			return status;
		}
		#endregion ◆ 印刷処理

		#region ◆ レポートフォーム設定関連
		#region ◎ 各種ActiveReport帳票インスタンス作成
		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

		#region ◎ レポートアセンブリインスタンス化
		/// <summary>
		/// レポートアセンブリインスタンス化
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new StockMoveException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new StockMoveException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region ◎ 印刷画面共通情報設定

		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
			
			// 帳票チャート共通部品クラス
			SFCMN00331C cmnCommon = new SFCMN00331C(); 

			// PDFパス取得
			string pdfPath = "";
			string pdfName = "";
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
			// 印刷モード
			commonInfo.PrintMode   = this.Printinfo.printmode;
			// 印刷件数
			commonInfo.PrintMax    = 0;
			DataView dv = (DataView)this._printInfo.rdData;
			commonInfo.PrintMax = dv.Count;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// 上余白
			commonInfo.MarginsTop  = this._printInfo.py;
			// 左余白
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		#endregion
		
		#region ◎ 各種プロパティ設定
		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
			_salesDayMonthReport = (SalesDayMonthReport)this._printInfo.jyoken;

			//集計タイプ 0:全社 1:拠点毎
			string ttlTypeString = "";
            // 2008.08.26 30413 犬飼 集計方法によるソート順プロパティ設定の変更は無し >>>>>>START
            //if (_salesDayMonthReport.TtlType == 0)
            //{
            //    ttlTypeString = "[拠点 ";
            //}
            //else
            //{
            //    ttlTypeString = "[";
            //}
            // 2008.08.26 30413 犬飼 集計方法によるソート順プロパティ設定の変更は無し <<<<<<END
            
			// ソート順プロパティ設定
            // 2008.08.26 30413 犬飼 集計単位別のソート順プロパティを変更 >>>>>>START
            //0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
            //switch (_salesDayMonthReport.TotalType)
            //{
            //    case 0: instance.PageHeaderSortOderTitle = "[拠点順]"; break;
            //    case 1: instance.PageHeaderSortOderTitle = ttlTypeString + "部署順]"; break;
            //    case 2: instance.PageHeaderSortOderTitle = ttlTypeString + "部署 課順]"; break;
            //    case 3: instance.PageHeaderSortOderTitle = ttlTypeString + "地区順]"; break;
            //    case 4: instance.PageHeaderSortOderTitle = ttlTypeString + "業種順]"; break;
            //    case 5: instance.PageHeaderSortOderTitle = ttlTypeString + "担当者順]"; break;
            //    case 6: instance.PageHeaderSortOderTitle = ttlTypeString + "受注者順]"; break;
            //    case 7: instance.PageHeaderSortOderTitle = ttlTypeString + "発行者順]"; break;
            //    case 8: instance.PageHeaderSortOderTitle = ttlTypeString + "得意先順]"; break;
            //    case 9: instance.PageHeaderSortOderTitle = ttlTypeString + "地区 得意先順]"; break;
            //    case 10: instance.PageHeaderSortOderTitle = ttlTypeString + "業種 得意先順]"; break;
            //    case 11: instance.PageHeaderSortOderTitle = ttlTypeString + "担当者 得意先順]"; break;
            //}
            //0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業者別 6:販売区分別
            switch (_salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[得意先順]"; break;
                            case 1: ttlTypeString = "[拠点順]"; break;
                            case 2: ttlTypeString = "[得意先－拠点順]"; break;
                            case 3: ttlTypeString = "[管理拠点順]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[担当者順]"; break;
                            case 1: ttlTypeString = "[得意先順]"; break;
                            case 2: ttlTypeString = "[担当者－拠点順]"; break;
                            case 3: ttlTypeString = "[管理拠点順]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[受注者順]"; break;
                            case 1: ttlTypeString = "[得意先順]"; break;
                            case 2: ttlTypeString = "[受注者－拠点順]"; break;
                            case 3: ttlTypeString = "[管理拠点順]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[発行者順]"; break;
                            case 1: ttlTypeString = "[得意先順]"; break;
                            case 2: ttlTypeString = "[発行者－拠点順]"; break;
                            case 3: ttlTypeString = "[管理拠点順]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[地区順]"; break;
                            case 1: ttlTypeString = "[得意先順]"; break;
                            case 2: ttlTypeString = "[地区－拠点順]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[業種順]"; break;
                            case 1: ttlTypeString = "[得意先順]"; break;
                            case 2: ttlTypeString = "[業種－拠点順]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                    {
                        ttlTypeString = "";
                        break;
                    }
            }
            instance.PageHeaderSortOderTitle = ttlTypeString;
            // 2008.08.26 30413 犬飼 集計単位別のソート順プロパティを変更 <<<<<<END
            
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = SalesDayMonthReportAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
            }
			
			// 抽出条件ヘッダ出力区分
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// 抽出条件編集処理
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );
			instance.ExtraConditions = extraInfomations; 
			
			// フッタ出力区分
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// フッタ出力メッセージ
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// 印刷情報オブジェクト
			instance.PrintInfo = this._printInfo;

            // 2008.08.26 30413 犬飼 集計単位別のサブタイトル名称を変更 >>>>>>START
            // ヘッダーサブタイトル
            ////0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
            //switch (_salesDayMonthReport.TotalType)
            //{
            //    case 0: ttlTypeString = "（拠点別）"; break;
            //    case 1: ttlTypeString = "（部署別）"; break;
            //    case 2: ttlTypeString = "（課別）"; break;
            //    case 3: ttlTypeString = "（地区別）"; break;
            //    case 4: ttlTypeString = "（業種別）"; break;
            //    case 5: ttlTypeString = "（担当者別）"; break;
            //    case 6: ttlTypeString = "（受注者別）"; break;
            //    case 7: ttlTypeString = "（発行者別）"; break;
            //    case 8: ttlTypeString = "（得意先別）"; break;
            //    case 9: ttlTypeString = "（地区別得意先別）"; break;
            //    case 10: ttlTypeString = "（業種別得意先別）"; break;
            //    case 11: ttlTypeString = "（担当者別得意先別）"; break;
            //}
            //0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業者別 6:販売区分別
            switch (_salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // 得意先別
                    {
                        ttlTypeString = "（得意先別）";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    {
                        ttlTypeString = "（担当者別）";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                    {
                        ttlTypeString = "（受注者別）";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    {
                        ttlTypeString = "（発行者別）";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    {
                        ttlTypeString = "（地区別）";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    {
                        ttlTypeString = "（業種別）";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                    {
                        ttlTypeString = "（販売区分別）";
                        break;
                    }
            }
            // 2008.08.26 30413 犬飼 集計単位別のサブタイトル名称を変更 <<<<<<END
            instance.PageHeaderSubtitle = " 売上日報月報" + ttlTypeString;

			// その他データ
			// Todo:移動元とか渡す？抽出条件渡るからいいか？
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region ◎ 抽出条件出力情報作成
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成する。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			string swName = string.Empty;		// 拠点･倉庫タイトル
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();
            string stTarget = "";
            string edTarget = "";
            
			//対象日付
			string st_ShipArrivalDate = string.Empty;
			string ed_ShipArrivalDate = string.Empty;
			// 開始･終了のいずれかが入力されていれば印字
			if ((this._salesDayMonthReport.SalesDateSt != DateTime.MinValue) || (this._salesDayMonthReport.SalesDateEd != DateTime.MinValue))
			{
				// 開始
				if (this._salesDayMonthReport.SalesDateSt != DateTime.MinValue)
					st_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM/DD", this._salesDayMonthReport.SalesDateSt);
				else
					st_ShipArrivalDate = ct_Extr_Top;
				// 終了
				if (this._salesDayMonthReport.SalesDateEd != DateTime.MinValue)
					ed_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM/DD", this._salesDayMonthReport.SalesDateEd);
				else
					ed_ShipArrivalDate = ct_Extr_End;

				this.EditCondition(
					ref addConditions,
					string.Format(
						//this._salesDayMonthReport.ExtractDateTitle.PadRight(7, '　') + 
						"対象日" + 
						ct_RangeConst,
						st_ShipArrivalDate,
						ed_ShipArrivalDate));
			}

            // 2008.08.19 30413 犬飼 得意先の抽出条件印字処理を↓に移動 >>>>>>START
            ////得意先コード
            //if ((this._salesDayMonthReport.CustomerCodeSt != 0) || (this._salesDayMonthReport.CustomerCodeEd != 0))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("得意先コード：", this._salesDayMonthReport.CustomerCodeSt, this._salesDayMonthReport.CustomerCodeEd, "d9")
            //    );
            //}
            // 2008.08.19 30413 犬飼 得意先の抽出条件印字処理を↓に移動 <<<<<<END
            
            // 2008.08.19 30413 犬飼 出力単位別に抽出条件出力を変更 >>>>>>START
            ////担当者コード
            //if ((this._salesDayMonthReport.SalesEmployeeCdSt != string.Empty) || (this._salesDayMonthReport.SalesEmployeeCdEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("担当者コード：", this._salesDayMonthReport.SalesEmployeeCdSt, this._salesDayMonthReport.SalesEmployeeCdEd));
            //}
            ////受注者コード
            //if ((this._salesDayMonthReport.FrontEmployeeCdSt != string.Empty) || (this._salesDayMonthReport.FrontEmployeeCdEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("受注者コード：", this._salesDayMonthReport.FrontEmployeeCdSt, this._salesDayMonthReport.FrontEmployeeCdEd));
            //}
            ////発行者コード
            //if ((this._salesDayMonthReport.SalesInputCodeSt != string.Empty) || (this._salesDayMonthReport.SalesInputCodeEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("発行者コード：", this._salesDayMonthReport.SalesInputCodeSt, this._salesDayMonthReport.SalesInputCodeEd));
            //}
            ////地区コード
            //if ((this._salesDayMonthReport.SalesAreaCodeSt != 0) || (this._salesDayMonthReport.SalesAreaCodeEd != 0))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("地区コード：", this._salesDayMonthReport.SalesAreaCodeSt, this._salesDayMonthReport.SalesAreaCodeEd, "d2")
            //    );
            //}
            ////業種コード
            //if ((this._salesDayMonthReport.BusinessTypeCodeSt != 0) || (this._salesDayMonthReport.BusinessTypeCodeEd != 0))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("業種コード：", this._salesDayMonthReport.BusinessTypeCodeSt, this._salesDayMonthReport.BusinessTypeCodeEd, "d2")
            //    );
            //}

            
            //// 集計単位
            //if (this._salesDayMonthReport.SrchCodeSt != string.Empty || this._salesDayMonthReport.SrchCodeEd != string.Empty)
            //{
            //    string stTarget = this._salesDayMonthReport.SrchCodeSt;
            //    string edTarget = this._salesDayMonthReport.SrchCodeEd;
            //    if (stTarget == string.Empty) stTarget = ct_Extr_Top;
            //    if (edTarget == string.Empty) edTarget = ct_Extr_End;

            //    switch (_salesDayMonthReport.TotalType)
            //    {
            //        case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
            //            {
            //                this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
            //            {
            //                this.EditCondition(ref addConditions, string.Format("受注者" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
            //            {
            //                this.EditCondition(ref addConditions, string.Format("発行者" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
            //            {
            //                this.EditCondition(ref addConditions, string.Format("地区" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
            //            {
            //                this.EditCondition(ref addConditions, string.Format("業種" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
            //            {
            //                this.EditCondition(ref addConditions, string.Format("販売区分" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //    }
            //}

            //// 得意先
            //if (this._salesDayMonthReport.CustomerCodeSt != 0 || (this._salesDayMonthReport.CustomerCodeEd != 0 && this._salesDayMonthReport.CustomerCodeEd == 999999999))
            //{
            //    string stTarget = this._salesDayMonthReport.CustomerCodeSt.ToString("d09");
            //    string edTarget = this._salesDayMonthReport.CustomerCodeEd.ToString("d09");
            //    if (stTarget == string.Empty) stTarget = ct_Extr_Top;
            //    if (edTarget == string.Empty) edTarget = ct_Extr_End;

            //    this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));
            //}
            // 2008.08.19 30413 犬飼 出力単位別に抽出条件出力を変更 <<<<<<END

            // 2008.09.24 30413 犬飼 抽出条件の出力制御を変更 >>>>>>START
            // 集計単位
            string outType = "";
            switch (_salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // 担当者別
                    {
                        outType = "担当者";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // 受注者別
                    {
                        outType = "受注者";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // 発行者別
                    {
                        outType = "発行者";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // 地区別
                    {
                        outType = "地区";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // 業種別
                    {
                        outType = "業種";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // 販売区分
                    {
                        outType = "販売区分";
                        break;
                    }
            }

            if ((this._salesDayMonthReport.SrchCodeSt == "") && (this._salesDayMonthReport.SrchCodeEd != ""))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._salesDayMonthReport.SrchCodeEd;
                this.EditCondition(ref addConditions, string.Format(outType + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._salesDayMonthReport.SrchCodeSt != "") && (this._salesDayMonthReport.SrchCodeEd == ""))
            {
                stTarget = this._salesDayMonthReport.SrchCodeSt;
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format(outType + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._salesDayMonthReport.SrchCodeSt != "") && (this._salesDayMonthReport.SrchCodeEd != ""))
            {
                stTarget = this._salesDayMonthReport.SrchCodeSt;
                edTarget = this._salesDayMonthReport.SrchCodeEd;
                this.EditCondition(ref addConditions, string.Format(outType + ct_RangeConst, stTarget, edTarget));
            }

            // 得意先
            if ((this._salesDayMonthReport.CustomerCodeSt == 0) && (this._salesDayMonthReport.CustomerCodeEd != 0))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._salesDayMonthReport.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));                
            }
            else if ((this._salesDayMonthReport.CustomerCodeSt > 0) && (this._salesDayMonthReport.CustomerCodeEd == 0))
            {
                stTarget = this._salesDayMonthReport.CustomerCodeSt.ToString("d08");
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));                
            }
            else if ((this._salesDayMonthReport.CustomerCodeSt > 0) && (this._salesDayMonthReport.CustomerCodeEd != 0))
            {
                stTarget = this._salesDayMonthReport.CustomerCodeSt.ToString("d08");
                edTarget = this._salesDayMonthReport.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));                
            }
            // 2008.09.24 30413 犬飼 抽出条件の出力制御を変更 <<<<<<END

			//集計方法
			if(_salesDayMonthReport.TtlType == 0)
			{
				this.EditCondition(ref addConditions, string.Format("集計方法：全社"));
			}
			else
			{
				this.EditCondition(ref addConditions, string.Format("集計方法：拠点毎"));
			}

			//金額単位
			if(_salesDayMonthReport.MoneyUnit == 0)
			{
				this.EditCondition(ref addConditions, string.Format("金額単位：円"));
			}
			else
			{
				this.EditCondition(ref addConditions, string.Format("金額単位：千円"));
			}

            // 2008.08.26 30413 犬飼 日計無し印刷の追加 >>>>>>START
            // 日計無し印刷
            if (_salesDayMonthReport.TotalType != 6)
            {
                // 集計単位が「販売区分」以外
                if (_salesDayMonthReport.DaySumPrtDiv == 0)
                {
                    this.EditCondition(ref addConditions, string.Format("日計無し印刷：する"));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("日計無し印刷：しない"));
                }
            }
            // 2008.08.26 30413 犬飼 日計無し印刷の追加 <<<<<<END

            // 2008.08.26 30413 犬飼 改頁の削除 >>>>>>START
			//改頁
            //if(_salesDayMonthReport.CrMode == 1)
            //{
            //    this.EditCondition(ref addConditions, string.Format("改頁：拠点毎"));
            //}
            // 2008.08.26 30413 犬飼 改頁の削除 <<<<<<END
			
			foreach ( string exCondStr in addConditions )
			{
				extraConditions.Add( exCondStr );
			}
		}
		#endregion

		#region ◎ 抽出範囲文字列作成
		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange( string title, string startString, string endString )
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end	 = ct_Extr_End;
				if (startString	!= "")	start	= startString;
				if (endString	!= "")	end		= endString;
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}

		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange(string title, int startString, int endString, string kt)
		{
			string result = "";
			if ((startString != 0) || (endString != 0))
			{
				string start = ct_Extr_Top;
				string end = ct_Extr_End;
				if (startString != 0) start = startString.ToString(kt);
				if (endString != 0) end = endString.ToString(kt);
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}
		#endregion

		#region ◎ 抽出条件文字列編集
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS(target);
			
			for (int i = 0; i < editArea.Count; i++)
			{
				int areaByte = 0;
				
				// 格納エリアのバイト数算出
				if (editArea[i] != null)
				{
					areaByte = TStrConv.SizeCountSJIS(editArea[i]);
				}

				if ((areaByte + targetByte + 2) <= 190)
				{
					isEdit = true;

					// 全角スペースを挿入
					if (editArea[i] != null) editArea[i] += ct_Space;
					
					editArea[i]  += target;
					break;
				}
			}
			// 新規編集エリア作成
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		#endregion ◆ レポートフォーム設定関連

		#region ◎ メッセージ表示

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
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02012P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
