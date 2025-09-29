using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/02 不具合対応[5781]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入日報月報印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入日報月報の印刷を行う。</br>
	/// <br>Programmer : 22013 久保 将太</br>
	/// <br>Date       : 2007.03.08</br>
	/// </remarks>
	class DCKOU02103PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 仕入日報月報印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入日報月報印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCKOU02103PA()
		{
		}

		/// <summary>
		/// 仕入日報月報印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 仕入日報月報印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCKOU02103PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockDayMonthReport = this._printInfo.jyoken as StockDayMonthReport;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";

        // --- DEL 2008/08/08 -------------------------------->>>>>
        //private const string ct_Extr_Top		= "ＴＯＰ";
        //private const string ct_Extr_End		= "ＥＮＤ";
        // --- DEL 2008/08/08 --------------------------------<<<<< 

        // --- ADD 2008/08/08 -------------------------------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/10/02 不具合対応[5781] "最初から"→RangeUtil.FROM_BEGIN
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/10/02 不具合対応[5781] "最後まで"→RangeUtil.TO_END
        // --- ADD 2008/08/08 --------------------------------<<<<< 

		private	const string ct_RangeConst		= "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private StockDayMonthReport _stockDayMonthReport;		// 抽出条件クラス
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
                prtRpt.DataMember = DCKOU02105EA.ct_Tbl_StockDayMonthReportData;
				
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
            StockDayMonthReport extraInfo = (StockDayMonthReport)this._printInfo.jyoken;

            // --- DEL 2008/08/08 -------------------------------->>>>>
            //// ソート順プロパティ設定
            //if (extraInfo.SortOrder == 0)
            //{
            //    instance.PageHeaderSortOderTitle = "[コード順]";
            //}
            //else
            //{
            //    instance.PageHeaderSortOderTitle = "[カナ順]";
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = StockMoveAcs.ReadPrtOutSet(out prtOutSet, out message);
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

			// ヘッダーサブタイトル
			instance.PageHeaderSubtitle = "仕入日報月報";

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
			string target = "";
			string stTarget = "";
			string edTarget = "";
			
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();

            // --- DEL 2008/08/08 -------------------------------->>>>>
            ////仕入日
            //stTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._stockDayMonthReport.StockDateSt);
            //edTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._stockDayMonthReport.StockDateEd);
            //target = "仕入日：" + stTarget + "  ～　" + edTarget;
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            // 対象日付
            // DEL 2008/10/02 不具合対応[5781]---------->>>>>
            //stTarget = TDateTime.DateTimeToString("YYYY/MM/DD", this._stockDayMonthReport.DayStockDateSt);
            //edTarget = TDateTime.DateTimeToString("YYYY/MM/DD", this._stockDayMonthReport.DayStockDateEd);
            // DEL 2008/10/02 不具合対応[5781]----------<<<<<
            stTarget = this._stockDayMonthReport.DayStockDateSt.ToString(RangeUtil.DATE_FORMAT);
            edTarget = this._stockDayMonthReport.DayStockDateEd.ToString(RangeUtil.DATE_FORMAT);
            target = "対象日：" + stTarget + "  ～　" + edTarget; // MOD 2008/10/02 不具合対応[5781] "対象日付："→"対象日："
            // --- ADD 2008/08/08 --------------------------------<<<<<

			this.EditCondition(ref addConditions, target);

            // --- ADD 2008/08/08 -------------------------------->>>>>
            //改頁
            if (_stockDayMonthReport.PageType == 0)
            {
                this.EditCondition(ref addConditions, "改頁：する");
            }
            else
            {
                this.EditCondition(ref addConditions, "改頁：しない");
            }
            // --- ADD 2008/08/08 --------------------------------<<<<<

            // --- DEL 2008/08/08 -------------------------------->>>>>
            ////担当者コード
            //if ((this._stockDayMonthReport.StockAgentCodeSt != string.Empty) || (this._stockDayMonthReport.StockAgentCodeEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("担当者コード：", this._stockDayMonthReport.StockAgentCodeSt, this._stockDayMonthReport.StockAgentCodeEd));
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

			//仕入先コード
			//if ((this._stockDayMonthReport.CustomerCodeSt != 0) || (this._stockDayMonthReport.CustomerCodeEd != 0))  // DEL 2008/08/08
            // DEL 2008/10/02 不具合対応[5781]↓
            //if ((this._stockDayMonthReport.SupplierCodeSt != 0) || (this._stockDayMonthReport.SupplierCodeEd != 999999999))    // ADD 2008/08/08
            // ADD 2008/10/02 不具合対応[5781]---------->>>>>
            if (!RangeUtil.SupplierCode.IsAllRange(
                this._stockDayMonthReport.SupplierCodeSt,
                this._stockDayMonthReport.SupplierCodeEd
            ))
            {
                // DEL 2008/10/02 不具合対応[5781]---------->>>>>
                //string stName = ct_Extr_Top;
                //string edName = ct_Extr_End;

                //// --- DEL 2008/08/08 -------------------------------->>>>>
                ////if (this._stockDayMonthReport.CustomerCodeSt != 0)
                ////{
                ////    stName = this._stockDayMonthReport.CustomerCodeSt.ToString("d9");
                ////}
                ////if (this._stockDayMonthReport.CustomerCodeEd != 0)
                ////{
                ////    edName = this._stockDayMonthReport.CustomerCodeEd.ToString("d9");
                ////}
                //// --- DEL 2008/08/08 --------------------------------<<<<< 

                //// --- ADD 2008/08/08 -------------------------------->>>>>
                //if (this._stockDayMonthReport.SupplierCodeSt != 0)
                //{
                //    stName = this._stockDayMonthReport.SupplierCodeSt.ToString("d9");
                //}
                //if (this._stockDayMonthReport.SupplierCodeEd != 999999999)
                //{
                //    edName = this._stockDayMonthReport.SupplierCodeEd.ToString("d9");
                //}
                //// --- ADD 2008/08/08 --------------------------------<<<<< 

                //this.EditCondition(ref addConditions,
                //    string.Format("仕入先コード：{0} ～ {1}", stName, edName)
                //);
                // DEL 2008/10/02 不具合対応[5781]----------<<<<<

                string start= RangeUtil.SupplierCode.GetStartString(this._stockDayMonthReport.SupplierCodeSt);
                string end  = RangeUtil.SupplierCode.GetEndString(this._stockDayMonthReport.SupplierCodeEd);

                EditCondition(
                    ref addConditions,
                    string.Format("仕入先" + ct_RangeConst, start, end)
                );
			}
            // ADD 2008/10/02 不具合対応[5781]----------<<<<<

            // --- DEL 2008/08/08 -------------------------------->>>>>
            ////改頁
            //if (_stockDayMonthReport.PageType == 1)
            //{
            //    this.EditCondition(ref addConditions, "改頁：拠点単位");
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<<

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

		private string GetConditionRange(string title, int startInt, int endInt)
		{
			string result = "";
			if ((startInt != 0) || (endInt != 0))
			{
				string start = ct_Extr_Top;
				string end = ct_Extr_End;
				if (startInt != 0) start = startInt.ToString();
				if (endInt != 0) end = endInt.ToString();
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
			return TMsgDisp.Show(iLevel, "DCKOU02103P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
