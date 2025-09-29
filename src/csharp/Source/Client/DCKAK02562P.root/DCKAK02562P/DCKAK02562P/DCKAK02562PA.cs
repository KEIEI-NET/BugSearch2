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
	/// 支払残高元帳印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 支払残高元帳の印刷を行う。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.10.03</br>
    /// <br>Update Note: 2008/12/10 30414 忍 幸史 Partsman用に変更</br>
	/// </remarks>
	class DCKAK02562PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
        /// 支払残高元帳印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払残高元帳印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		public DCKAK02562PA()
		{
		}

		/// <summary>
        /// 支払残高元帳印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 支払残高元帳印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		public DCKAK02562PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extrInfo_PaymentBalance = this._printInfo.jyoken as ExtrInfo_PaymentBalance;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
		private const string ct_Extr_Top		= "最初から";
		private const string ct_Extr_End		= "最後まで";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					            // 印刷情報クラス
        private ExtrInfo_PaymentBalance _extrInfo_PaymentBalance;	// 抽出条件クラス
		#endregion ■ Private Member

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class PaymentBalanceException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public PaymentBalanceException(string message, int status): base(message)
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
                // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataSource = (DataView)this._printInfo.rdData;
                // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                prtRpt.DataMember = DCKAK02564EA.Col_Tbl_PaymentBalance;
				
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
				throw new PaymentBalanceException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new PaymentBalanceException(er.Message, -1);
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
            // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
            //commonInfo.PrintMax = 0;
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;
            // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
			
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            ExtrInfo_PaymentBalance extraInfo = (ExtrInfo_PaymentBalance)this._printInfo.jyoken;

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
            int st = PaymentBalanceAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new PaymentBalanceException(message, status);
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

            /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
			// ヘッダーサブタイトル
			instance.PageHeaderSubtitle = this._extrInfo_PaymentBalance.PrintDivName;
               --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
            
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            const string ct_RangeConst = "：{0} ～ {1}";
            //extraConditions = new StringCollection();

            //// 対象年月 -----------------------------------------------------------------------------------------------------------
            //string st_Year = string.Empty;
            //string ed_Year = string.Empty;
            //string st_Month = string.Empty;
            //string ed_Month = string.Empty;
            //string st_YearMonth = string.Empty;
            //string ed_YearMonth = string.Empty;

            //if (this._extrInfo_PaymentBalance.St_AddUpYearMonth != 0)
            //{
            //    st_Year = Convert.ToString(this._extrInfo_PaymentBalance.St_AddUpYearMonth / 100);
            //    st_Month = Convert.ToString(this._extrInfo_PaymentBalance.St_AddUpYearMonth % 100);
            //    st_YearMonth = st_Year + "/" + st_Month;

            //}
            //else
            //{
            //    st_YearMonth = ct_Extr_Top;
            //}

            //if (this._extrInfo_PaymentBalance.Ed_AddUpYearMonth != 0)
            //{
            //    ed_Year = Convert.ToString(this._extrInfo_PaymentBalance.Ed_AddUpYearMonth / 100);
            //    ed_Month = Convert.ToString(this._extrInfo_PaymentBalance.Ed_AddUpYearMonth % 100);
            //    ed_YearMonth = ed_Year + "/" + ed_Month;
            //}
            //else
            //{
            //    ed_YearMonth = ct_Extr_End;
            //}

            //// --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
            ////this.EditCondition(ref extraConditions, string.Format("対象期間  " + ct_RangeConst, st_YearMonth, ed_YearMonth));
            //this.EditCondition(ref extraConditions, string.Format("締日  " + ct_RangeConst, st_YearMonth, ed_YearMonth));
            //// --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<

            //StringCollection addConditions = new StringCollection();

            //// 支払先コード ----------------------------------------------------------------------------------------------------
            //if ((this._extrInfo_PaymentBalance.St_PayeeCode != 0) || (this._extrInfo_PaymentBalance.Ed_PayeeCode != 0))
            //{
            //    string st_PayeeCode_Top = string.Empty;
            //    string ed_PayeeCode_End = string.Empty;

            //    if (this._extrInfo_PaymentBalance.St_PayeeCode == 0)
            //    {
            //        st_PayeeCode_Top = ct_Extr_Top;
            //    }
            //    else
            //    {
            //        // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
            //        //st_PayeeCode_Top = string.Format("{0:000000000}", this._extrInfo_PaymentBalance.St_PayeeCode);
            //        st_PayeeCode_Top = string.Format("{0:000000}", this._extrInfo_PaymentBalance.St_PayeeCode);
            //        // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
            //    }

            //    if (this._extrInfo_PaymentBalance.Ed_PayeeCode == 0)
            //    {
            //        ed_PayeeCode_End = ct_Extr_End;
            //    }
            //    else
            //    {
            //        // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
            //        //ed_PayeeCode_End = string.Format("{0:000000000}", this._extrInfo_PaymentBalance.Ed_PayeeCode);
            //        ed_PayeeCode_End = string.Format("{0:000000}", this._extrInfo_PaymentBalance.Ed_PayeeCode);
            //        // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("支払先コード：{0} ～ {1}", st_PayeeCode_Top, ed_PayeeCode_End));
            //}

            ///* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
            //// 出力金額区分
            //string sOutMoneyDivName = string.Empty; 

            //switch (this._extrInfo_PaymentBalance.OutMoneyDiv)
            //{
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.All:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_All;
            //        break;
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.Minus:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_Minus;
            //        break;
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.Plus:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_Plus;
            //        break;
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.PlusMinus:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_PlusMinus;
            //        break;
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.Zero:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_Zero;
            //        break;
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.ZeroMinus:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_ZeroMinus;
            //        break;
            //    case ExtrInfo_PaymentBalance.OutMoneyDivState.ZeroPlus:
            //        sOutMoneyDivName = ExtrInfo_PaymentBalance.ct_OutMoneyDiv_ZeroPlus;
            //        break;
            //    default:
            //        sOutMoneyDivName = string.Empty;
            //        break;
            //}
            //this.EditCondition(ref addConditions,
            //    string.Format("出力金額区分：{0}", sOutMoneyDivName));
            //   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
            //foreach (string exCondStr in addConditions)
            //{
            //    extraConditions.Add(exCondStr);
            //}

            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // 対象年月 -----------------------------------------------------------------------------------------------------------
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;
            string st_Year = string.Empty;
            string ed_Year = string.Empty;
            string st_Month = string.Empty;
            string ed_Month = string.Empty;
            string st_YearMonth = string.Empty;
            string ed_YearMonth = string.Empty;

            // 開始･終了のいずれかが入力されていれば印字
            if ((this._extrInfo_PaymentBalance.St_AddUpYearMonth != 0) || (this._extrInfo_PaymentBalance.Ed_AddUpYearMonth != 0))
            {
                // 開始
                if (this._extrInfo_PaymentBalance.St_AddUpYearMonth != 0)
                {
                    st_Year = Convert.ToString(this._extrInfo_PaymentBalance.St_AddUpYearMonth / 100);
                    st_Month = Convert.ToString(this._extrInfo_PaymentBalance.St_AddUpYearMonth % 100);
                    // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                    //st_YearMonth = st_Year + "年" + st_Month.PadLeft(2, '0');
                    st_YearMonth = st_Year + "/" + st_Month.PadLeft(2, '0');
                    // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                }
                else
                {
                    st_ShipArrivalDate = ct_Extr_Top;
                }
                // 終了
                if (this._extrInfo_PaymentBalance.Ed_AddUpYearMonth != 0)
                {
                    ed_Year = Convert.ToString(this._extrInfo_PaymentBalance.Ed_AddUpYearMonth / 100);
                    ed_Month = Convert.ToString(this._extrInfo_PaymentBalance.Ed_AddUpYearMonth % 100);
                    // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                    //ed_YearMonth = ed_Year + "年" + ed_Month.PadLeft(2, '0');
                    ed_YearMonth = ed_Year + "/" + ed_Month.PadLeft(2, '0');
                    // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
                }
                else
                {
                    ed_ShipArrivalDate = ct_Extr_End;
                }

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        "締日" + ct_RangeConst,
                        st_YearMonth,
                        ed_YearMonth));
            }

            // 支払コード ----------------------------------------------------------------------------------------------------
            if ((this._extrInfo_PaymentBalance.St_PayeeCode != 0) || (this._extrInfo_PaymentBalance.Ed_PayeeCode != 0))
            {
                string st_CustomerCode_Top = string.Empty;
                string ed_CustomerCode_End = string.Empty;

                if (this._extrInfo_PaymentBalance.St_PayeeCode == 0)
                {
                    st_CustomerCode_Top = ct_Extr_Top;
                }
                else
                {
                    st_CustomerCode_Top = string.Format("{0:000000}", this._extrInfo_PaymentBalance.St_PayeeCode);
                }

                if (this._extrInfo_PaymentBalance.Ed_PayeeCode == 0)
                {
                    ed_CustomerCode_End = ct_Extr_End;
                }
                else
                {
                    ed_CustomerCode_End = string.Format("{0:000000}", this._extrInfo_PaymentBalance.Ed_PayeeCode);
                }

                this.EditCondition(ref addConditions,
                    string.Format("仕入先：{0} ～ {1}", st_CustomerCode_Top, ed_CustomerCode_End));
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAK02562P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
