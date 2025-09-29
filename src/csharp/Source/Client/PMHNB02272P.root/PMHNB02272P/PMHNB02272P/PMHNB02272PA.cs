//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売掛残高一覧表(総括)
// プログラム概要   : 売掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : 新規作成
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
    /// 売掛残高一覧表(総括)印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売掛残高一覧表(総括)の印刷を行う。</br>
	/// <br></br>
    /// </remarks>
	class PMHNB02272PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表(総括)印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)印刷クラスのインスタンスの作成を行う。</br>
        /// <br></br>
        /// </remarks>
		public PMHNB02272PA()
		{
		}

		/// <summary>
        /// 売掛残高一覧表(総括)印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)印刷クラスのインスタンスの作成を行う。</br>
        /// <br></br>
        /// </remarks>
		public PMHNB02272PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._sumExtrInfo_BillBalance = this._printInfo.jyoken as SumExtrInfo_BillBalance;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					            // 印刷情報クラス
        private SumExtrInfo_BillBalance _sumExtrInfo_BillBalance;	// 抽出条件クラス
		#endregion ■ Private Member

        private string CT_Sort1_Odr = "AddUpSecCode, ClaimCode";                        // 拠点+得意先
        private string CT_Sort2_Odr = "AddUpSecCode, AgentCd, ClaimCode"; 　            // 拠点+担当者+得意先
        private string CT_Sort3_Odr = "AddUpSecCode, SalesAreaCode, ClaimCode";         // 拠点+地区+得意先

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class SumBillBalanceException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public SumBillBalanceException(string message, int status): base(message)
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
        /// <br></br>
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
        /// <br></br>
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
							
				// 印刷データ取得
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = ds.Tables[PMHNB02274EA.Col_Tbl_SumBillBalance];

                // ソート順設定
                dv.Sort = this.GetPrintOderQuerry();

                // データソース設定
                prtRpt.DataSource = dv;
                
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
        /// <br></br>
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
        /// <br></br>
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
				throw new SumBillBalanceException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new SumBillBalanceException(er.Message, -1);
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
        /// <br></br>
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
            int maxCount = 0;
            foreach (object obj in (this._printInfo.rdData as DataSet).Tables)
            {
                if (obj is DataTable && (obj as DataTable).TableName == PMHNB02274EA.Col_Tbl_SumBillBalance)
                {
                    maxCount = (obj as DataTable).Rows.Count;
                    break;
                }
            }
            commonInfo.PrintMax = maxCount;
            
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
        /// <br></br>
        /// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            SumExtrInfo_BillBalance extraInfo = (SumExtrInfo_BillBalance)this._printInfo.jyoken;

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
            int st = SumBillBalanceAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new SumBillBalanceException(message, status);
            }
			
			// 抽出条件ヘッダ出力区分
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// 抽出条件編集処理
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );

			instance.ExtraConditions = extraInfomations;

            // ソート順の出力
            string sortTitle = "";
            this.SORTTITLE(out sortTitle);

            instance.PageHeaderSortOderTitle = sortTitle;
            
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
			instance.PageHeaderSubtitle = this._sumExtrInfo_BillBalance.PrintDivName;

			// その他データ
			ArrayList otherDataList = new ArrayList();

			// 全社が選択されていたら明細に拠点名称を出す。
			if ( this._sumExtrInfo_BillBalance.IsSelectAllSection )
			{
				otherDataList.Add("計上拠点");		    // 明細拠点名称タイトル
			}
			else
			{
				otherDataList.Add( string.Empty );		// 明細拠点名称タイトル
			}
			instance.OtherDataList = otherDataList;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

        #region ◆　ソート順出力
        /// <summary>
        /// ソート順出力
        /// </summary>
        /// <param name="sorttitle">ソート順出力</param>
        /// <remarks>
        /// <br> ソート順の出力を作成します。</br>
        /// </remarks>
        private void SORTTITLE(out string sorttitle)
        {
            // ソート順
            sorttitle = "[" + this._sumExtrInfo_BillBalance.SortOrderDivName + "]";
        }
        #endregion

		#region ◎ 抽出条件出力情報作成
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成する。</br>
		/// <br></br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			extraConditions = new StringCollection();

			// 処理月 -----------------------------------------------------------------------------------------------------------
            string year = string.Empty;
            string month = string.Empty;
            string yearMonth = string.Empty;

            StringCollection addConditions = new StringCollection();
            if (this._sumExtrInfo_BillBalance.AddUpYearMonth != DateTime.MinValue)
            {
                // 開始
                if (this._sumExtrInfo_BillBalance.AddUpYearMonth != DateTime.MinValue)
                {
                    yearMonth = TDateTime.DateTimeToString("YYYY/MM", this._sumExtrInfo_BillBalance.AddUpYearMonth);
                }
            }

            this.EditCondition(ref addConditions, string.Format("処理月：{0}", yearMonth));

            // 担当者
            if ((this._sumExtrInfo_BillBalance.St_EmployeeCode == "") && (this._sumExtrInfo_BillBalance.Ed_EmployeeCode != ""))
            {
                this.EditCondition(ref addConditions, string.Format("担当者：{0} ～ {1}", ct_Extr_Top, this._sumExtrInfo_BillBalance.Ed_EmployeeCode));
            }

            if ((this._sumExtrInfo_BillBalance.St_EmployeeCode != "") && (this._sumExtrInfo_BillBalance.Ed_EmployeeCode == ""))
            {
                this.EditCondition(ref addConditions, string.Format("担当者：{0} ～ {1}", this._sumExtrInfo_BillBalance.St_EmployeeCode, ct_Extr_End));
            }

            if ((this._sumExtrInfo_BillBalance.St_EmployeeCode != "") && (this._sumExtrInfo_BillBalance.Ed_EmployeeCode != ""))
            {
                this.EditCondition(ref addConditions, string.Format("担当者：{0} ～ {1}", this._sumExtrInfo_BillBalance.St_EmployeeCode, this._sumExtrInfo_BillBalance.Ed_EmployeeCode));
            }

            // 地区
            if ((this._sumExtrInfo_BillBalance.St_SalesAreaCode == 0) && (this._sumExtrInfo_BillBalance.Ed_SalesAreaCode != 0))
            {
                this.EditCondition(ref addConditions, string.Format("地区：{0} ～ {1}", ct_Extr_Top, this._sumExtrInfo_BillBalance.Ed_SalesAreaCode.ToString("d04")));
            }

            if ((this._sumExtrInfo_BillBalance.St_SalesAreaCode > 0) && (this._sumExtrInfo_BillBalance.Ed_SalesAreaCode == 0))
            {
                this.EditCondition(ref addConditions, string.Format("地区：{0} ～ {1}", this._sumExtrInfo_BillBalance.St_SalesAreaCode.ToString("d04"), ct_Extr_End));
            }

            if ((this._sumExtrInfo_BillBalance.St_SalesAreaCode > 0) && (this._sumExtrInfo_BillBalance.Ed_SalesAreaCode != 0))
            {
                this.EditCondition(ref addConditions, string.Format("地区：{0} ～ {1}", this._sumExtrInfo_BillBalance.St_SalesAreaCode.ToString("d04"), this._sumExtrInfo_BillBalance.Ed_SalesAreaCode.ToString("d04")));
            }

            // 得意先コード ----------------------------------------------------------------------------------------------------
            if ((this._sumExtrInfo_BillBalance.St_ClaimCode != 0) || (this._sumExtrInfo_BillBalance.Ed_ClaimCode != 0))
            {
                string st_ClaimCode_Top = string.Empty;
                string ed_ClaimCode_End = string.Empty;

                if (this._sumExtrInfo_BillBalance.St_ClaimCode == 0)
                {
                    st_ClaimCode_Top = ct_Extr_Top;
                }
                else
                {
                    st_ClaimCode_Top = this._sumExtrInfo_BillBalance.St_ClaimCode.ToString("d08");
                }

                if (this._sumExtrInfo_BillBalance.Ed_ClaimCode == 0)
                {
                    ed_ClaimCode_End = ct_Extr_End;
                }
                else
                {
                    ed_ClaimCode_End = this._sumExtrInfo_BillBalance.Ed_ClaimCode.ToString("d08");
                }

                this.EditCondition(ref addConditions, string.Format("得意先：{0} ～ {1}", st_ClaimCode_Top, ed_ClaimCode_End));
            }
            
            // 出力金額区分
            string sOutMoneyDivName = string.Empty;

            switch ((SumExtrInfo_BillBalance.OutMoneyDivState)this._sumExtrInfo_BillBalance.OutMoneyDiv)
            {
                case SumExtrInfo_BillBalance.OutMoneyDivState.All:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_All;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.Minus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_Minus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.Plus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_Plus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.PlusMinus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_PlusMinus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.Zero:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_Zero;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.ZeroMinus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_ZeroMinus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.ZeroPlus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_ZeroPlus;
                    break;
                default:
                    sOutMoneyDivName = string.Empty;
                    break;
            }
            this.EditCondition(ref addConditions,
                string.Format("出力金額区分：{0}", sOutMoneyDivName));

            // 入金内訳
            if (this._sumExtrInfo_BillBalance.DepoDtlDiv == 0)
            {
                this.EditCondition(ref addConditions, "入金内訳：印字する");
            }
            else
            {
                this.EditCondition(ref addConditions, "入金内訳：印字しない");
            }
            
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
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
        /// <br></br>
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
				result = String.Format(title + "： {0} ～ {1}", start, end);
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
        /// <br></br>
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

        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br></br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch ((SumExtrInfo_BillBalance.SortOrderDivState)this._sumExtrInfo_BillBalance.SortOrderDiv)
            {
                case SumExtrInfo_BillBalance.SortOrderDivState.CustomerCode:
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case SumExtrInfo_BillBalance.SortOrderDivState.EmployeeCode:
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case SumExtrInfo_BillBalance.SortOrderDivState.SalesAreaCode:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }                
            }

            return oderQuerry;
        }
        #endregion

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
        /// <br></br>
        /// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMHNB02272P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
