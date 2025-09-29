//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　印刷クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/07/11  修正内容 : Redmine 仕様変更 #22915 の対応
//----------------------------------------------------------------------------//
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
    /// キャンペーン実績表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : キャンペーン実績表の印刷を行う。</br>
	/// <br>Programmer : 田建委</br>
	/// <br>Date       : 2011/05/19</br>
    /// </remarks>
	class PMKHN02052PA: IPrintProc
	{
		#region ■ Constructor
		/// <summary>
		/// キャンペーン実績表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : キャンペーン実績表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public PMKHN02052PA()
		{
		}

		/// <summary>
		/// キャンペーン実績表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : キャンペーン実績表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public PMKHN02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._campaignRsltList = this._printInfo.jyoken as CampaignRsltList;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        private const string ct_Extr_Top        = "最初から";
        private const string ct_Extr_End        = "最後まで";
        private	const string ct_RangeConst		= "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
        private CampaignRsltList _campaignRsltList;		            // 抽出条件クラス
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
        /// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// 印刷フォームクラスインスタンス作成
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// レポートインスタンス作成
                string prpid = string.Empty;
                this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                // カンマ編集を行い
                if (_campaignRsltList.PrintType == 1)
                {
                    PMCMN02000CA reportCtrl = PMCMN02000CA.GetInstance();
                    reportCtrl.SetReportProps(ref prtRpt, PMCMN02000CA.SetReportPropsKind.NormalList);
                }

				// データソース設定
				prtRpt.DataSource = this._printInfo.rdData;
				prtRpt.DataMember = PMKHN02054EA.ct_Tbl_CampaignData;
				
				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo);
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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
        /// <param name="rptObj"></param>
        /// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
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
            
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            _campaignRsltList = (CampaignRsltList)this._printInfo.jyoken;            
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = CampaignRsltListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
			//0:商品別 1:得意先別 2:担当者別
			string ttlTypeString = "";
            ttlTypeString = "（" + this._campaignRsltList.TotalTypeName + "）";

			instance.PageHeaderSubtitle = "キャンペーン実績表" + ttlTypeString;

			// その他データ
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			string swName = string.Empty;
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();

            //印刷タイプ：
            switch (this._campaignRsltList.PrintType)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：当月"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：期間"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("印刷タイプ：日付"));
                    break;
            }

			//対象日付:
			string st_ShipArrivalDate = string.Empty;
			string ed_ShipArrivalDate = string.Empty;
            string format = string.Empty;
            // 当月・期間
			// 開始･終了のいずれかが入力されていれば印字
            if (this._campaignRsltList.PrintType != 2)
            {
                format = "YYYY/MM";
                if ((this._campaignRsltList.AddUpYearMonthSt != DateTime.MinValue) || (this._campaignRsltList.AddUpYearMonthEd != DateTime.MinValue))
                {
                    // 開始
                    if (this._campaignRsltList.AddUpYearMonthSt != DateTime.MinValue)
                    {
                        st_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthSt);
                    }
                    else
                    {
                        st_ShipArrivalDate = ct_Extr_Top;
                    }
                    // 終了
                    if (this._campaignRsltList.AddUpYearMonthEd != DateTime.MinValue)
                    {
                        ed_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthEd);
                    }
                    else
                    {
                        ed_ShipArrivalDate = ct_Extr_End;
                    }

                    this.EditCondition(ref addConditions, string.Format("対象日付" + ct_RangeConst, st_ShipArrivalDate, ed_ShipArrivalDate));
                }
            }
            // 日付
            else
            {
                format = "YYYY/MM/DD";
                // 開始･終了のいずれかが入力されていれば印字
                if ((this._campaignRsltList.AddUpYearMonthDaySt != DateTime.MinValue) || (this._campaignRsltList.AddUpYearMonthDayEd != DateTime.MinValue))
                {
                    // 開始
                    if (this._campaignRsltList.AddUpYearMonthDaySt != DateTime.MinValue)
                    {
                        st_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthDaySt);
                    }
                    else
                    {
                        st_ShipArrivalDate = ct_Extr_Top;
                    }
                    // 終了
                    if (this._campaignRsltList.AddUpYearMonthDayEd != DateTime.MinValue)
                    {
                        ed_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthDayEd);
                    }
                    else
                    {
                        ed_ShipArrivalDate = ct_Extr_End;
                    }

                    this.EditCondition(ref addConditions, string.Format("対象日付" + ct_RangeConst, st_ShipArrivalDate, ed_ShipArrivalDate));
                }
            }
            
            //明細単位：
            switch (this._campaignRsltList.Detail)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("明細単位：品番"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("明細単位：BLｺｰﾄﾞ"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ"));
                    break;
            }

            //小計単位：
            if (this._campaignRsltList.Detail == 0)
            {
                switch (this._campaignRsltList.Total)
                {
                    case 0:
                        this.EditCondition(ref addConditions, string.Format("小計単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ"));
                        break;
                    case 1:
                        this.EditCondition(ref addConditions, string.Format("小計単位：BLｺｰﾄﾞ"));
                        break;
                }
            }

            //出力順：
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    break;

                case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("出力順：得意先"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("出力順：拠点"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("出力順：得意先-拠点"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("出力順：管理拠点"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                    
                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("出力順：担当者"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("出力順：得意先"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("出力順：担当者－拠点"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("出力順：管理拠点"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("出力順：受注者"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("出力順：得意先"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("出力順：受注者－拠点"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("出力順：管理拠点"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachPrinter: // 発行者別

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("出力順：発行者"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("出力順：得意先"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("出力順：発行者－拠点"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("出力順：管理拠点"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachArea: // 地区別

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("出力順：地区"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("出力順：得意先"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("出力順：地区－拠点"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("出力順：管理拠点"));
                            break;
                    }
                    break;

                default:
                    break;
            }

            //印刷順：
            if (this._campaignRsltList.Detail == 0 && this._campaignRsltList.PrintType != 1) // 印刷タイプ：当月/日付
            {
                switch (this._campaignRsltList.PrintSort)
                {
                    case 0:
                        this.EditCondition(ref addConditions, string.Format("印刷順：品番＋メーカー"));
                        break;
                    case 1:
                        this.EditCondition(ref addConditions, string.Format("印刷順：メーカー＋品番"));
                        break;
                }
            }

            // 抽出条件
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // 商品別
                    {
                        // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                        if (this._campaignRsltList.BLGroupCodeSt != 0 ||
                            this._campaignRsltList.BLGroupCodeEd != 0)
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.BLGroupCodeSt != 0)
                            {
                                stName = this._campaignRsltList.BLGroupCodeSt.ToString("d5");
                            }
                            if (this._campaignRsltList.BLGroupCodeEd != 0)
                            {
                                edName = this._campaignRsltList.BLGroupCodeEd.ToString("d5");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("ｸﾞﾙｰﾌﾟ" + ct_RangeConst, stName, edName)
                            );
                        }

                        // BLｺｰﾄﾞ
                        if (this._campaignRsltList.BLGoodsCodeSt != 0 ||
                            this._campaignRsltList.BLGoodsCodeEd != 0)
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.BLGoodsCodeSt != 0)
                            {
                                stName = this._campaignRsltList.BLGoodsCodeSt.ToString("d5");
                            }
                            if (this._campaignRsltList.BLGoodsCodeEd != 0)
                            {
                                edName = this._campaignRsltList.BLGoodsCodeEd.ToString("d5");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("BLｺｰﾄﾞ" + ct_RangeConst, stName, edName)
                            );
                        }

                        // ----- ADD 2011/07/11 ----- >>>>>
                        //得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                        // ----- ADD 2011/07/11 ----- <<<<<
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachCustomer: // 得意先別
                    {
                        //得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachEmployee: // 担当者別
                    {
                        //担当者コード
                        if (!string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeSt.ToString()) ||
                            !string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeEd.ToString()))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            //担当者コード
                            if (!string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeSt.ToString()))
                            {
                                stName = this._campaignRsltList.EmployeeCodeSt;
                            }
                            if (!string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeEd.ToString()))
                            {
                                edName = this._campaignRsltList.EmployeeCodeEd;
                            }
                            this.EditCondition(ref addConditions,
                                string.Format("担当者" + ct_RangeConst, stName, edName)
                            );
                        }

                        //得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // 受注者別
                    {
                        // 受注者コード
                        if (!string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeSt) 
                            || !string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeEd))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            // 受注者コード
                            if ((string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeSt) == false) ||
                                (string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeEd) == false))
                            {
                                if (string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeSt) == false)
                                {
                                    stName = this._campaignRsltList.AcceptOdrCodeSt;
                                }
                                if (string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeEd) == false)
                                {
                                    edName = this._campaignRsltList.AcceptOdrCodeEd;
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("受注者" + ct_RangeConst, stName, edName)
                                );
                            }
                        }

                        // 得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if ((this._campaignRsltList.CustomerCodeEd != 0))
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachPrinter: //発行者別
                    {
                        // 発行者コード
                        if (!string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeSt)
                            || !string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeEd))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            // 発行者コード
                            if ((string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeSt) == false) ||
                                (string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeEd) == false))
                            {
                                if (string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeSt) == false)
                                {
                                    stName = this._campaignRsltList.PrinterCodeSt;
                                }
                                if (string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeEd) == false)
                                {
                                    edName = this._campaignRsltList.PrinterCodeEd;
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("発行者" + ct_RangeConst, stName, edName)
                                );
                            }
                        }

                        // 得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if ((this._campaignRsltList.CustomerCodeEd != 0))
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachArea: // 地区別
                    {
                        //地区コード
                        if ((this._campaignRsltList.AreaCodeSt != 0) ||
                            (this._campaignRsltList.AreaCodeEd != 0))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            //地区コード
                            if ((this._campaignRsltList.AreaCodeSt != 0) || this._campaignRsltList.AreaCodeEd != 0)
                            {
                                if (this._campaignRsltList.AreaCodeSt != 0)
                                {
                                    stName = this._campaignRsltList.AreaCodeSt.ToString("d4");
                                }
                                if (this._campaignRsltList.AreaCodeEd != 0)
                                {
                                    edName = this._campaignRsltList.AreaCodeEd.ToString("d4");
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("地区" + ct_RangeConst, stName, edName)
                                );
                            }
                        }

                        //得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachSales:
                    {
                        //販売区分コード
                        if ((this._campaignRsltList.SalesCodeSt != 0) ||
                            ((this._campaignRsltList.SalesCodeEd != 0)))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            //販売区分コード
                            if ((this._campaignRsltList.SalesCodeSt != 0) ||
                                (this._campaignRsltList.SalesCodeEd != 0))
                            {
                                if (this._campaignRsltList.SalesCodeSt != 0)
                                {
                                    stName = this._campaignRsltList.SalesCodeSt.ToString("d4");
                                }
                                if (this._campaignRsltList.SalesCodeEd != 0)
                                {
                                    edName = this._campaignRsltList.SalesCodeEd.ToString("d4");
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("販売区分" + ct_RangeConst, stName, edName)
                                );
                            }
                        }
                        //得意先コード
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if ((this._campaignRsltList.CustomerCodeEd != 0))
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("得意先" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;
                default:
                    break;
            }
			
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : 田建委</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02152P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
