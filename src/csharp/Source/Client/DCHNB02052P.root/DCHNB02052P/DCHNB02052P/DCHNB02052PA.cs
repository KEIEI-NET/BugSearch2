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
	/// 売上順位表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上順位表の印刷を行う。</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2007.03.08</br>
    /// <br>Update Note: 2008.09.24 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>           : 2008/10/27       照田 貴志</br>
    /// <br>            ・バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2008.12.11 30452 上野 俊治</br>
    /// <br>            ・仕様変更対応</br>
    /// <br>            　グループコードの単体指定をヘッダ印字するよう修正</br>
    /// <br>Update Note: 2009/03/17 30452 上野 俊治</br>
    /// <br>            ・障害対応12699</br>
    /// <br>Update Note: 2011/11/28 凌小青</br>
    /// <br>            ・障害対応Redmine#7739</br>
    /// <br>Update Note: 2014/12/16 劉超</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           :・明治産業様Seiken品番変更</br>
    /// <br>Update Note: 2015/03/27 時シン</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#44209の#423品番集計区分の名称変更</br>
    /// </remarks>
	class DCHNB02052PA: IPrintProc
	{
		#region ■ Constructor
		/// <summary>
		/// 売上順位表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上順位表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCHNB02052PA()
		{
		}

		/// <summary>
		/// 売上順位表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 売上順位表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCHNB02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._shipmGoodsOdrReport = this._printInfo.jyoken as ShipmGoodsOdrReport;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        ///private const string ct_Extr_Top       = "ＴＯＰ"; // DEL 2008/09/24
        //private const string ct_Extr_End        = "ＥＮＤ"; // DEL 2008/09/24
        private const string ct_Extr_Top        = "最初から"; // ADD 2008/09/24
        private const string ct_Extr_End        = "最後まで"; // ADD 2008/09/24
        private	const string ct_RangeConst		= "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private ShipmGoodsOdrReport _shipmGoodsOdrReport;		// 抽出条件クラス
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
    
			#region ◆ Public Propertyf
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
		/// <br>Programmer : 96186 立花裕輔</br>
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
		/// <br>Programmer : 96186 立花裕輔</br>
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
				prtRpt.DataMember = DCHNB02054EA.ct_Tbl_ShipmGoodsOdrReportData;
				
				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

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
		/// <br>Programmer : 96186 立花裕輔</br>
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
		/// <br>Programmer : 96186 立花裕輔</br>
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
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // DEL 2009/03/17
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
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

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<<
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
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
			_shipmGoodsOdrReport = (ShipmGoodsOdrReport)this._printInfo.jyoken;

            if (_shipmGoodsOdrReport.TotalType == 0)
            {
                // ソート順プロパティ設定
                //0:仕入先＋メーカー＋商品中分類＋ＢＬコード＋品番
                //1:メーカー＋商品中分類＋ＢＬコード＋品番
                //2:仕入先＋メーカー＋品番
                //3:メーカー＋品番
                //4:メーカー＋商品中分類＋品番
                //5:品番 //ADD BY 凌小青 on 2011/11/28 for Redmine#7739 
                switch (_shipmGoodsOdrReport.Detail)
                {
                    case 0: instance.PageHeaderSortOderTitle = "[仕入先＋メーカー＋商品中分類＋ＢＬコード＋品番順]"; break;
                    case 1: instance.PageHeaderSortOderTitle = "[メーカー＋商品中分類＋ＢＬコード＋品番順]"; break;
                    case 2: instance.PageHeaderSortOderTitle = "[仕入先＋メーカー＋品番順]"; break;
                    case 3: instance.PageHeaderSortOderTitle = "[メーカー＋品番順]"; break;
                    case 4: instance.PageHeaderSortOderTitle = "[メーカー＋商品中分類＋品番順]"; break;
                    case 5: instance.PageHeaderSortOderTitle = "[品番順]"; break;//ADD BY 凌小青 on 2011/11/28 for Redmine#7739 
                }
            }
            else if (_shipmGoodsOdrReport.TotalType == 2)
            {
                switch (_shipmGoodsOdrReport.Detail)
                {
                    case 0: instance.PageHeaderSortOderTitle = "[品番順]"; break;
                    case 1: instance.PageHeaderSortOderTitle = "[グループコード順]"; break;
                }
            }
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = ShipmGoodsOdrReportAcs.ReadPrtOutSet(out prtOutSet, out message);
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
			//0:商品別 2:得意先別 3:担当者別
			string ttlTypeString = "";
			switch (_shipmGoodsOdrReport.TotalType)
			{
				case 0: ttlTypeString = "（商品別）"; break;
                case 1: ttlTypeString = "（ＢＬコード別）"; break; // ADD 2008/09/24
				case 2: ttlTypeString = "（得意先別）"; break;
				case 3: ttlTypeString = "（担当者別）"; break;
			}
			instance.PageHeaderSubtitle = "売上順位表" + ttlTypeString;

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
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			string swName = string.Empty;		// 拠点･倉庫タイトル
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();

			//対象年月
			string st_ShipArrivalDate = string.Empty;
			string ed_ShipArrivalDate = string.Empty;
			// 開始･終了のいずれかが入力されていれば印字
			if ((this._shipmGoodsOdrReport.SalesDateSt != DateTime.MinValue) || (this._shipmGoodsOdrReport.SalesDateEd != DateTime.MinValue))
			{
				// 開始
				if (this._shipmGoodsOdrReport.SalesDateSt != DateTime.MinValue)
					st_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM", this._shipmGoodsOdrReport.PrnSalesDateSt);
				else
					st_ShipArrivalDate = ct_Extr_Top;
				// 終了
				if (this._shipmGoodsOdrReport.SalesDateSt != DateTime.MinValue)
					ed_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM", this._shipmGoodsOdrReport.PrnSalesDateEd);
				else
					ed_ShipArrivalDate = ct_Extr_End;

				this.EditCondition(
					ref addConditions,
					string.Format(
						//this._shipmGoodsOdrReport.ExtractDateTitle.PadRight(7, '　') + 
						"対象年月" +
						ct_RangeConst,
						st_ShipArrivalDate,
						ed_ShipArrivalDate));
			}

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 集計方法
            if (this._shipmGoodsOdrReport.TtlType == 0)
            {
                this.EditCondition(ref addConditions, string.Format("集計方法：全社"));
            }
            else
            {
                this.EditCondition(ref addConditions, string.Format("集計方法：拠点"));
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

            //売上在庫取寄せ区分
            //0:合計 1:在庫, 2:取寄せ
            switch (this._shipmGoodsOdrReport.SalesOrderDivCd)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("在取指定：合計"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("在取指定：在庫"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("在取指定：取寄"));
                    break;
            }

            //金額単位
            //0:円 1:千円
            if (_shipmGoodsOdrReport.MoneyUnit == 0)
            {
                this.EditCondition(ref addConditions, string.Format("金額単位：円"));
            }
            else
            {
                this.EditCondition(ref addConditions, string.Format("金額単位：千円"));
            }

            // --- ADD 2008/09/24 -------------------------------->>>>>
            //改頁
            //0:なし 1:拠点 2:得意先 3:担当者 4:仕入先
            switch (_shipmGoodsOdrReport.CrMode)
            {
                case 0:
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("改頁：拠点単位"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("改頁：得意先単位"));
                    break;
                case 3:
                    this.EditCondition(ref addConditions, string.Format("改頁：担当者単位"));
                    break;
                case 4:
                    this.EditCondition(ref addConditions, string.Format("改頁：仕入先単位"));
                    break;
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

            //順位設定：
            string order0 = "";
            string order1 = "";
            string order2 = "";

            //0:売上数量 1:売上回数 2:売上金額 3:粗利金額 4:順位なし
            switch (this._shipmGoodsOdrReport.SortItem)
            {
                case 0:
                    order0 = "数量順";
                    break;
                case 1:
                    order0 = "回数順";
                    break;
                case 2:
                    order0 = "売上金額順";
                    break;
                case 3:
                    order0 = "粗利金額順";
                    break;
                case 4:
                    order0 = "";
                    break;
            }

            //0:全体 1:拠点単位
            switch (this._shipmGoodsOdrReport.Order1)
            {
                case 0:
                    order1 = "全体";
                    break;
                case 1:
                    order1 = "拠点";
                    break;
            }

            //0:上位 1:下位
            switch (this._shipmGoodsOdrReport.Order2)
            {
                case 0:
                    order2 = "上位";
                    break;
                case 1:
                    order2 = "下位";
                    break;
            }

            this.EditCondition(ref addConditions,
                string.Format("順位設定：{0} {1} {2} {3}位まで", order0, order1, order2, this._shipmGoodsOdrReport.Order3)
            );

            // --- DEL 2009/02/10 -------------------------------->>>>>
            ////印刷範囲指定（数量）
            ////if ((this._shipmGoodsOdrReport.PrintRangeSt != 0) || (this._shipmGoodsOdrReport.PrintRangeEd != 999999999))       //DEL 2008/10/27 画面の入力値をそのまま印字の為
            //// --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //if ((this._shipmGoodsOdrReport.PrintRangeSt != 0) ||
            //    ((this._shipmGoodsOdrReport.PrintRangeEd != 0) &&
            //     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.PrintRangeEd.ToString()) == false)))
            //// --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //{
            //    string stName = ct_Extr_Top;
            //    string edName = ct_Extr_End;

            //    if (this._shipmGoodsOdrReport.PrintRangeSt != 0)
            //    {
            //        //stName = this._shipmGoodsOdrReport.PrintRangeSt.ToString("000000000");    //DEL 2008/10/27 0詰めはしない
            //        stName = this._shipmGoodsOdrReport.PrintRangeSt.ToString("");               //ADD 2008/10/27
            //    }

            //    //if (this._shipmGoodsOdrReport.PrintRangeEd != 999999999)      //DEL 2008/10/27 画面の入力値をそのまま印字の為
            //    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //    if ((this._shipmGoodsOdrReport.PrintRangeEd != 0) &&
            //        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.PrintRangeEd.ToString()) == false))
            //    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //    {
            //        //edName = this._shipmGoodsOdrReport.PrintRangeEd.ToString("000000000");    //DEL 2008/10/27 0詰めはしない
            //        edName = this._shipmGoodsOdrReport.PrintRangeEd.ToString("");               //ADD 2008/10/27
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("印刷範囲指定（数量）：{0} ～ {1}", stName, edName)
            //    );
            //}
            // --- DEL 2009/02/10 -------------------------------->>>>>
            // --- ADD 2009/02/10 -------------------------------->>>>>
            //印刷範囲指定（数量）
            if (!this._shipmGoodsOdrReport.PrintRangeStNoInput || !this._shipmGoodsOdrReport.PrintRangeEdNoInput)
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (!this._shipmGoodsOdrReport.PrintRangeStNoInput)
                {
                    stName = this._shipmGoodsOdrReport.PrintRangeSt.ToString();
                }

                if (!this._shipmGoodsOdrReport.PrintRangeEdNoInput)
                {
                    edName = this._shipmGoodsOdrReport.PrintRangeEd.ToString();
                }

                    this.EditCondition(ref addConditions,
                        string.Format("印刷範囲指定（数量）：{0} ～ {1}", stName, edName));
            }

            // --- ADD 2009/02/10 --------------------------------<<<<<

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 構成比単位
            if (this._shipmGoodsOdrReport.TotalType == 1)
            {
                if (this._shipmGoodsOdrReport.ConstUnit == 0) // 0:総合計
                {
                    this.EditCondition(ref addConditions, string.Format("構成比単位：総合計"));
                }
                else // 1:拠点計
                {
                    this.EditCondition(ref addConditions, string.Format("構成比単位：拠点計"));
                }
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<
            
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (this._shipmGoodsOdrReport.TotalType == 0)
            {
                // 品番集計区分
                // 0:別々 1:合算
                switch (this._shipmGoodsOdrReport.GoodsNoTtlDiv)
                {
                    case 0:
                        //this.EditCondition(ref addConditions, string.Format("品番集計区分：別々"));// DEL 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
                        this.EditCondition(ref addConditions, string.Format("品番集計区分：通常"));// ADD 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
                        break;
                    case 1:
                        this.EditCondition(ref addConditions, string.Format("品番集計区分：合算"));
                        break;
                }

                if (this._shipmGoodsOdrReport.GoodsNoTtlDiv == 1)
                {
                    // 品番表示区分
                    // 0:新品番 1:旧品番
                    switch (this._shipmGoodsOdrReport.GoodsNoShowDiv)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("品番表示区分：新品番"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("品番表示区分：旧品番"));
                            break;
                    }
                }
            }
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

            //印刷タイプ：
            //0:数量,1:回数,2:金額,3:金額＆数量,4:金額＆回数,5:数量＆回数
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：数量"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：回数"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：金額"));
                    break;
                case 3:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：上段・金額／下段・数量"));
                    break;
                case 4:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：上段・金額／下段・回数"));
                    break;
                case 5:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：上段・数量／下段・回数"));
                    break;
            }

            // --- ADD 2008/09/24 -------------------------------->>>>>
            if (_shipmGoodsOdrReport.TotalType == 0
                || _shipmGoodsOdrReport.TotalType == 1)
            {
                // 仕入先
                //if ((this._shipmGoodsOdrReport.SupplierCdSt != 0) || (this._shipmGoodsOdrReport.SupplierCdEd != 999999))      //DEL 2008/10/27 画面の入力値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.SupplierCdSt != 0) ||
                    ((this._shipmGoodsOdrReport.SupplierCdEd != 0) &&
                     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.SupplierCdEd.ToString()) == false)))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    string stName = ct_Extr_Top;
                    string edName = ct_Extr_End;

                    if (this._shipmGoodsOdrReport.SupplierCdSt != 0)
                    {
                        stName = this._shipmGoodsOdrReport.SupplierCdSt.ToString("d6");
                    }
                    //if (this._shipmGoodsOdrReport.SupplierCdEd != 999999)     //DEL 2008/10/27 画面の値をそのまま印字の為
                    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                    if ((this._shipmGoodsOdrReport.SupplierCdEd != 0) &&
                        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.SupplierCdEd.ToString()) == false))
                    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                    {
                        edName = this._shipmGoodsOdrReport.SupplierCdEd.ToString("d6");
                    }

                    this.EditCondition(ref addConditions,
                        string.Format("仕入先：{0} ～ {1}", stName, edName)
                    );
                }
            }
            else if (_shipmGoodsOdrReport.TotalType == 2)
            {
                //得意先コード
                //if ((this._shipmGoodsOdrReport.CustomerCodeSt != 0) || (this._shipmGoodsOdrReport.CustomerCodeEd != 99999999))    //DEL 2008/10/27 画面の入力値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.CustomerCodeSt != 0) ||
                    ((this._shipmGoodsOdrReport.CustomerCodeEd != 0) &&
                     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.CustomerCodeEd.ToString()) == false)))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    string stName = ct_Extr_Top;
                    string edName = ct_Extr_End;

                    if (this._shipmGoodsOdrReport.CustomerCodeSt != 0)
                    {
                        stName = this._shipmGoodsOdrReport.CustomerCodeSt.ToString("d8");
                    }
                    //if (this._shipmGoodsOdrReport.CustomerCodeEd != 99999999)     //DEL 2008/10/27 画面の値をそのまま印字の為
                    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                    if ((this._shipmGoodsOdrReport.CustomerCodeEd != 0) &&
                        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.CustomerCodeEd.ToString()) == false))
                    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                    {
                        edName = this._shipmGoodsOdrReport.CustomerCodeEd.ToString("d8");
                    }

                    this.EditCondition(ref addConditions,
                        string.Format("得意先：{0} ～ {1}", stName, edName)
                    );
                }
            }
            else if (_shipmGoodsOdrReport.TotalType == 3)
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                //担当者コード
                //if ((this._shipmGoodsOdrReport.EmployeeCodeSt != "0000") || (this._shipmGoodsOdrReport.EmployeeCodeEd != "9999"))     //DEL 2008/10/27 画面の値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.EmployeeCodeSt != "0000") ||
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.EmployeeCodeEd) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    if (this._shipmGoodsOdrReport.EmployeeCodeSt != "0000")
                    {
                        stName = this._shipmGoodsOdrReport.EmployeeCodeSt;
                    }
                    //if (this._shipmGoodsOdrReport.EmployeeCodeEd != "9999")                           //DEL 2008/10/27 画面の値をそのまま印字の為
                    if (string.IsNullOrEmpty(this._shipmGoodsOdrReport.EmployeeCodeEd) == false)        //ADD 2008/10/27
                    {
                        edName = this._shipmGoodsOdrReport.EmployeeCodeEd;
                    }
                    this.EditCondition(ref addConditions,
                        string.Format("担当者：{0} ～ {1}", stName, edName)
                    );
                }
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

			//メーカーコード
            //if ((this._shipmGoodsOdrReport.GoodsMakerCdSt != 0) || (this._shipmGoodsOdrReport.GoodsMakerCdEd != 9999))        //DEL 2008/10/27 画面の値をそのまま印字の為
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.GoodsMakerCdSt != 0) ||
                ((this._shipmGoodsOdrReport.GoodsMakerCdEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMakerCdEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
				string stName = ct_Extr_Top;
				string edName = ct_Extr_End;

				if (this._shipmGoodsOdrReport.GoodsMakerCdSt != 0)
				{
					stName = this._shipmGoodsOdrReport.GoodsMakerCdSt.ToString("d4");
				}
                //if (this._shipmGoodsOdrReport.GoodsMakerCdEd != 9999)     //DEL 2008/10/27 画面の値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.GoodsMakerCdEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMakerCdEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
					edName = this._shipmGoodsOdrReport.GoodsMakerCdEd.ToString("d4");
				}

				this.EditCondition(ref addConditions,
					string.Format("メーカー：{0} ～ {1}", stName, edName)
				);
			}

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 商品大分類
            //if ((this._shipmGoodsOdrReport.GoodsLGroupSt != 0) || (this._shipmGoodsOdrReport.GoodsLGroupEd != 9999))      //DEL 2008/10/27 画面の値をそのまま印字の為
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.GoodsLGroupSt != 0) ||
                ((this._shipmGoodsOdrReport.GoodsLGroupEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsLGroupEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.GoodsLGroupSt != 0)
                {
                    stName = this._shipmGoodsOdrReport.GoodsLGroupSt.ToString("d4");
                }
                //if (this._shipmGoodsOdrReport.GoodsLGroupEd != 9999)      //DEL 2008/10/27 画面の値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.GoodsLGroupEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsLGroupEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    edName = this._shipmGoodsOdrReport.GoodsLGroupEd.ToString("d4");
                }

                this.EditCondition(ref addConditions,
                    string.Format("商品大分類：{0} ～ {1}", stName, edName)
                );
            }

            // 商品中分類
            //if ((this._shipmGoodsOdrReport.GoodsMGroupSt != 0) || (this._shipmGoodsOdrReport.GoodsMGroupEd != 9999))      //DEL 2008/10/27 画面の値をそのまま印字の為
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.GoodsMGroupSt != 0) ||
                ((this._shipmGoodsOdrReport.GoodsMGroupEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMGroupEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.GoodsMGroupSt != 0)
                {
                    stName = this._shipmGoodsOdrReport.GoodsMGroupSt.ToString("d4");
                }
                //if (this._shipmGoodsOdrReport.GoodsMGroupEd != 9999)      //DEL 2008/10/27 画面の値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.GoodsMGroupEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMGroupEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    edName = this._shipmGoodsOdrReport.GoodsMGroupEd.ToString("d4");
                }

                this.EditCondition(ref addConditions,
                    string.Format("商品中分類：{0} ～ {1}", stName, edName)
                );
            }

            // --- DEL 2008/12/11 -------------------------------->>>>>
            // グループコード
            //if ((this._shipmGoodsOdrReport.BLGroupCodeSt != 0) || (this._shipmGoodsOdrReport.BLGroupCodeEd != 99999))     //DEL 2008/10/27 画面の値をそのまま印字の為
            //// --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //if ((this._shipmGoodsOdrReport.BLGroupCodeSt != 0) ||
            //    ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
            //     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false)))
            //// --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //{
            //    string stName = ct_Extr_Top;
            //    string edName = ct_Extr_End;

            //    if (this._shipmGoodsOdrReport.BLGroupCodeSt != 0)
            //    {
            //        stName = this._shipmGoodsOdrReport.BLGroupCodeSt.ToString("d5");
            //    }
            //    //if (this._shipmGoodsOdrReport.BLGroupCodeEd != 99999)     //DEL 2008/10/27 画面の値をそのまま印字の為
            //    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //    if ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
            //        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false))
            //    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //    {
            //        edName = this._shipmGoodsOdrReport.BLGroupCodeEd.ToString("d5");
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("グループコード：{0} ～ {1}", stName, edName)
            //    );

            //    setGroupCodeFlg = true; // ADD 2008/12/09
            //}
            // --- DEL 2008/12/11 --------------------------------<<<<<

            // --- ADD 2008/09/24 --------------------------------<<<<<

            // --- ADD 2008/12/11 -------------------------------->>>>>
            // グループコード
            StringBuilder groupCodeStr = new StringBuilder();
            bool setGroupCodeFlg = false; // ADD 2008/12/09

            // 範囲指定
            if ((this._shipmGoodsOdrReport.BLGroupCodeSt != 0) ||
                ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false)))
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.BLGroupCodeSt != 0)
                {
                    stName = this._shipmGoodsOdrReport.BLGroupCodeSt.ToString("d5");
                }

                if ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false))
                {
                    edName = this._shipmGoodsOdrReport.BLGroupCodeEd.ToString("d5");
                }

                groupCodeStr.Append(
                    string.Format("グループコード：{0} ～ {1}", stName, edName));

                setGroupCodeFlg = true; // ADD 2008/12/09
            }

            if (this._shipmGoodsOdrReport.BLGroupCodeAry.Length != 0)
            {


                if (!setGroupCodeFlg)
                {
                    groupCodeStr.Append("グループコード：");
                }
                else
                {
                    groupCodeStr.Append(" ");
                }

                foreach (int groupCode in this._shipmGoodsOdrReport.BLGroupCodeAry)
                {
                    groupCodeStr.Append(groupCode.ToString("d5"));
                    groupCodeStr.Append(" ");
                }

                // 余分な空白を除去
                groupCodeStr.Remove(groupCodeStr.Length - 1, 1);

                this.EditCondition(ref addConditions, groupCodeStr.ToString());

            }
            else
            {
                if (setGroupCodeFlg)
                {
                    this.EditCondition(ref addConditions, groupCodeStr.ToString());
                }
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<

            // --- DEL 2008/09/24 -------------------------------->>>>>
            ////商品区分グループコード
            //if ((this._shipmGoodsOdrReport.LargeGoodsGanreCodeSt != "") || (this._shipmGoodsOdrReport.LargeGoodsGanreCodeEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("商品区分グループコード：{0} ～ {1}", this._shipmGoodsOdrReport.LargeGoodsGanreCodeSt, this._shipmGoodsOdrReport.LargeGoodsGanreCodeEd)
            //    );
            //}
            ////商品区分コード
            //if ((this._shipmGoodsOdrReport.MediumGoodsGanreCodeSt != "") || (this._shipmGoodsOdrReport.MediumGoodsGanreCodeEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("商品区分コード：{0} ～ {1}", this._shipmGoodsOdrReport.MediumGoodsGanreCodeSt, this._shipmGoodsOdrReport.MediumGoodsGanreCodeEd)
            //    );
            //}
            ////商品区分詳細コード
            //if ((this._shipmGoodsOdrReport.DetailGoodsGanreCodeSt != "") || (this._shipmGoodsOdrReport.DetailGoodsGanreCodeEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("商品区分詳細コード：{0} ～ {1}", this._shipmGoodsOdrReport.DetailGoodsGanreCodeSt, this._shipmGoodsOdrReport.DetailGoodsGanreCodeEd)
            //    );
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<

			//BLコード
            //if ((this._shipmGoodsOdrReport.BLGoodsCodeSt != 0) || (this._shipmGoodsOdrReport.BLGoodsCodeEd != 99999))     //DEL 2008/10/27 画面の値をそのまま印字の為
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.BLGoodsCodeSt != 0) ||
                ((this._shipmGoodsOdrReport.BLGoodsCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGoodsCodeEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
				string stName = ct_Extr_Top;
				string edName = ct_Extr_End;

				if (this._shipmGoodsOdrReport.BLGoodsCodeSt != 0)
				{
					stName = this._shipmGoodsOdrReport.BLGoodsCodeSt.ToString("d5");
				}
                //if (this._shipmGoodsOdrReport.BLGoodsCodeEd != 99999)     //DEL 2008/10/27 画面の値をそのまま印字の為
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.BLGoodsCodeEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGoodsCodeEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
					edName = this._shipmGoodsOdrReport.BLGoodsCodeEd.ToString("d5");
				}

				this.EditCondition(ref addConditions,
					string.Format("BLコード：{0} ～ {1}", stName, edName)
				);
			}
			//品番
			if ((this._shipmGoodsOdrReport.GoodsNoSt != "") || (this._shipmGoodsOdrReport.GoodsNoEd != ""))
			{
                string stName = ct_Extr_Top;
				string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.GoodsNoSt != "")
                {
                    stName = this._shipmGoodsOdrReport.GoodsNoSt;
                }
                if (this._shipmGoodsOdrReport.GoodsNoEd != "")
                {
                    edName = this._shipmGoodsOdrReport.GoodsNoEd;
                }

				this.EditCondition(ref addConditions,
                    string.Format("品番：{0} ～ {1}", stName, edName)
				);
			}

			//販売従業員コード
            // --- DEL 2008/09/24 -------------------------------->>>>>
            //if ((this._shipmGoodsOdrReport.SalesEmployeeCdSt != "") || (this._shipmGoodsOdrReport.SalesEmployeeCdEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("販売従業員コード：{0} ～ {1}", this._shipmGoodsOdrReport.SalesEmployeeCdSt, this._shipmGoodsOdrReport.SalesEmployeeCdEd)
            //    );
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<
			
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
		/// <br>Programmer : 96186 立花裕輔</br>
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
		#endregion

		#region ◎ 抽出条件文字列編集
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           :・明治産業様Seiken品番変更</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS(target);
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            int newindex = 0;
            if (editArea.Count == 0)
            {
                newindex = 0;
            }
            else
            {
                newindex = editArea.Count - 1;
            }
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

            //for (int i = 0; i < editArea.Count; i++) // DEL 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
            for (int i = newindex; i < editArea.Count; i++) // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
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
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02152P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
