//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払確認表
// プログラム概要   : 支払確認表の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/08/05  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/03/27  修正内容 : 障害対応11468
//                       修正内容 : 障害対応11468(帳票ヘッダの抽出条件の改行を削除)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/04/03  修正内容 : 障害対応13090
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/28  修正内容 : MANTIS【13225】支払金種が全ての場合、「入金金種：」→「支払金種：」に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI今野 利裕
// 作 成 日  2012/10/03  修正内容 : 仕入先総括対応
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
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/03 不具合対応[5866]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 支払確認表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 支払確認表の印刷を行う。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.09.10</br>
    /// <br>UpdateNote : 2008/08/05 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br>   
    /// <br>UpdateNote : 2009/03/27 30452 上野 俊治</br>
    /// <br>            ・障害対応11468</br>
    /// <br>UpdateNote : 2009/03/27 30452 上野 俊治</br>
    /// <br>            ・障害対応11468(帳票ヘッダの抽出条件の改行を削除)</br>
    /// <br>Update Note: 2009/04/03 30452 上野 俊治</br>
    /// <br>            ・障害対応13090</br>
    /// </remarks>
	class DCKAK02523PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 支払確認表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払確認表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02523PA()
		{
		}

		/// <summary>
		/// 支払確認表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 支払確認表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02523PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._paymentMainCndtn = this._printInfo.jyoken as PaymentMainCndtn;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space	= "　";
        private const string ct_Extr_Top= RangeUtil.FROM_BEGIN; // MOD 2008/10/03 不具合対応[5866] "最初から"→RangeUtil.FROM_BEGIN
        private const string ct_Extr_End= RangeUtil.TO_END;     // MOD 2008/10/03 不具合対応[5866] "最後まで"→RangeUtil.TO_END
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
        private PaymentMainCndtn _paymentMainCndtn;		// 抽出条件クラス
		#endregion ■ Private Member

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class PaymentMainException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public PaymentMainException(string message, int status): base(message)
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
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
				prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataMember = DCKAK02525EA.Col_Tbl_PaymentMain;
				
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
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
				throw new PaymentMainException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new PaymentMainException(er.Message, -1);
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            PaymentMainCndtn extraInfo = (PaymentMainCndtn)this._printInfo.jyoken;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = GetSortOrderName( extraInfo );
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
            int st = PaymentMainAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new PaymentMainException(message, status);
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
			//instance.PageHeaderSubtitle = this._paymentMainCndtn.PrintDivName;  // DEL 2008/08/05

			// その他データ
			ArrayList otherDataList = new ArrayList();

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //otherDataList.Add(this._paymentMainCndtn.SumDivPrintName);			// 小計タイトル
            //otherDataList.Add(this._paymentMainCndtn.EmployeeKindDivName);		// 担当者タイトル名称
            //otherDataList.Add(string.Empty );
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2008/08/05 金種名称取得 -------------------------------->>>>>
            Dictionary<int, string> dicKindName = new Dictionary<int, string>();
            PaymentMainAcs paymentMainAcs = new PaymentMainAcs();
            status = paymentMainAcs.SearchKindName(out dicKindName);
            if (status == 0)
            {
                otherDataList.Add(dicKindName);
            }
            // --- ADD 2008/08/05 金種名称取得 --------------------------------<<<<< 

			instance.OtherDataList = otherDataList;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region ◎ ソート順名称取得
		/// <summary>
		/// ソート順名称取得
		/// </summary>
		/// <param name="paymentMainCndtn">抽出条件</param>
		/// <returns>ソート順名称</returns>
		/// <remarks>
		/// <br>Note       : ソート順名称を取得する。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private string GetSortOrderName(PaymentMainCndtn paymentMainCndtn)
		{
			string sortOrderName = string.Empty;
			//const string ct_SortFomat = "[{0}{1}]";  // DEL 2008/08/05
            const string ct_SortFomat = "ソート順:[{0}]";  // ADD 2008/08/05
			switch ( paymentMainCndtn.PrintDiv )
			{
                // --- DEL 2008/08/05 -------------------------------->>>>>
                //case (int)PaymentMainCndtn.PrintDivState.GrandTotal:			// 総合計
                //    sortOrderName = string.Empty;
                //    break;
                //case (int)PaymentMainCndtn.PrintDivState.Details:		        // 詳細
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                case (int)PaymentMainCndtn.PrintDivState.KindTotal:		        // 金種別計
                case (int)PaymentMainCndtn.PrintDivState.Simple:    			// 簡易日計

                // --- ADD 2012/10/03 ---------------------------->>>>>
                case (int)PaymentMainCndtn.PrintDivState.Simple_SupplSec:		// 簡易日計(仕入先-拠点順)
                case (int)PaymentMainCndtn.PrintDivState.KindTotal_SupplSec:    // 金種別計(仕入先-拠点順)
                // --- ADD 2012/10/03 ----------------------------<<<<<

                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    // 小計区分が支払番号か
                    //if (paymentMainCndtn.SumDiv == PaymentMainCndtn.SumDivState.PaymentSlipNo)
                    //    sortOrderName = string.Format( ct_SortFomat, string.Empty, paymentMainCndtn.SumDivPrintName + "毎" );
                    //else
                    //    sortOrderName = string.Format( ct_SortFomat, paymentMainCndtn.SortOrderDivName, ct_Space + paymentMainCndtn.SumDivPrintName + "毎" );
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    sortOrderName = string.Format(ct_SortFomat, paymentMainCndtn.SortOrderDivName);  // ADD 2008/08/05

                    break;
				default:
					sortOrderName = string.Empty;
					break;
			}
			return sortOrderName;
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
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "：{0} ～ {1}";
			extraConditions = new StringCollection();

			// 抽出日付 ----------------------------------------------------------------------------------------------------
            // 支払日
			string st_AddUpADate = string.Empty;
			string ed_AddUpADate = string.Empty;
            if ((this._paymentMainCndtn.St_AddUpADate != DateTime.MinValue) || (this._paymentMainCndtn.Ed_AddupADate != DateTime.MinValue))  // ADD 2009/04/03
            {
                // 開始
                if (this._paymentMainCndtn.St_AddUpADate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 不具合対応[5866]↓
                    //st_AddUpADate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.St_AddUpADate);
                    st_AddUpADate = this._paymentMainCndtn.St_AddUpADate.ToString(RangeUtil.DATE_FORMAT);   // ADD 2008/10/03 不具合対応[5866]
                }
                else
                {
                    st_AddUpADate = ct_Extr_Top;
                }
                // 終了
                if (this._paymentMainCndtn.Ed_AddupADate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 不具合対応[5866]↓
                    //ed_AddUpADate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.Ed_AddupADate);
                    ed_AddUpADate = this._paymentMainCndtn.Ed_AddupADate.ToString(RangeUtil.DATE_FORMAT);   // ADD 2008/10/03 不具合対応[5866]
                }
                else
                {
                    ed_AddUpADate = ct_Extr_End;
                }
                //this.EditCondition(ref extraConditions, string.Format( "支払計上日　" + ct_RangeConst, st_AddUpADate, ed_AddUpADate ) );  // DEL 2008/08/05
                this.EditCondition(ref extraConditions, string.Format("支払日" + ct_RangeConst, st_AddUpADate, ed_AddUpADate));           // ADD 2008/08/05
            }

            // 入力日
            string st_InputDate = string.Empty;
            string ed_InputDate = string.Empty;
            if ((this._paymentMainCndtn.St_InputDate != DateTime.MinValue) || (this._paymentMainCndtn.Ed_InputDate != DateTime.MinValue))  // ADD 2008/08/05
            {
                // 開始
                if (this._paymentMainCndtn.St_InputDate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 不具合対応[5866]↓
                    //st_InputDate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.St_InputDate);
                    st_InputDate = this._paymentMainCndtn.St_InputDate.ToString(RangeUtil.DATE_FORMAT); // ADD 2008/10/03 不具合対応[5866]
                }
                else
                {
                    st_InputDate = ct_Extr_Top;
                }
                // 終了
                if (this._paymentMainCndtn.Ed_InputDate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 不具合対応[5866]↓
                    //ed_InputDate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.Ed_InputDate);
                    ed_InputDate = this._paymentMainCndtn.Ed_InputDate.ToString(RangeUtil.DATE_FORMAT); // ADD 2008/10/03 不具合対応[5866]
                }
                else
                {
                    ed_InputDate = ct_Extr_End;
                }
                //this.EditCondition(ref extraConditions, string.Format("支払入力日　" + ct_RangeConst, st_InputDate, ed_InputDate));  // DEL 2008/08/05
                this.EditCondition(ref extraConditions, string.Format("入力日" + ct_RangeConst, st_InputDate, ed_InputDate));    // ADD 2008/08/05
            }

            //StringCollection addConditions = new StringCollection(); // DEL 2009/03/30

			// 支払先コード ----------------------------------------------------------------------------------------------------
            if ((this._paymentMainCndtn.St_PayeeCode != 0) || (this._paymentMainCndtn.Ed_PayeeCode != 0))
            {
                string st_PayeeCode_Top = string.Empty;
                string ed_PayeeCode_End = string.Empty;

                if (this._paymentMainCndtn.St_PayeeCode == 0)
                {
                    st_PayeeCode_Top = ct_Extr_Top;
                }
                else
                {
                    st_PayeeCode_Top = string.Format("{0:000000}", this._paymentMainCndtn.St_PayeeCode);    // MOD 2008/10/03 不具合対応[5866] "0:000000000"→"0:000000"
                }

                if (this._paymentMainCndtn.Ed_PayeeCode == 0)
                {
                    ed_PayeeCode_End = ct_Extr_End;
                }
                else
                {
                    ed_PayeeCode_End = string.Format("{0:000000}", this._paymentMainCndtn.Ed_PayeeCode);    // MOD 2008/10/03 不具合対応[5866] "0:000000000"→"0:000000"
                }

                //this.EditCondition(ref addConditions, // DEL 2009/03/30
                this.EditCondition(ref extraConditions, // ADD 2009/03/30
                    string.Format("支払先" + ct_RangeConst, st_PayeeCode_Top, ed_PayeeCode_End));   // MOD 2008/10/03 不具合対応[5866] "支払先：{0} ～ {1}"→"支払先" + ct_RangeConst
            }

			// 支払先カナ ----------------------------------------------------------------------------------------------------
            if ((this._paymentMainCndtn.St_PayeeKana != string.Empty) || (this._paymentMainCndtn.Ed_PayeeKana != string.Empty))
            {
                //this.EditCondition( ref addConditions,  // DEL 2009/03/30
                this.EditCondition(ref extraConditions, // ADD 2009/03/30
                    GetConditionRange("支払先カナ", this._paymentMainCndtn.St_PayeeKana, this._paymentMainCndtn.Ed_PayeeKana));
            }

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //// 担当者コード ----------------------------------------------------------------------------------------------------
            //if ( ( this._paymentMainCndtn.St_EmployeeCode != string.Empty ) || ( this._paymentMainCndtn.Ed_EmployeeCode != string.Empty ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        GetConditionRange( this._paymentMainCndtn.EmployeeKindDivName + "者コード", this._paymentMainCndtn.St_EmployeeCode, this._paymentMainCndtn.Ed_EmployeeCode ) );
            //}
            // --- DEL 2008/08/05 --------------------------------<<<<< 

			// 支払番号 ----------------------------------------------------------------------------------------------------
            string st_PaymentSlipNo = string.Empty;
            string ed_PaymentSlipNo = string.Empty;
            
            if ( ( this._paymentMainCndtn.St_PaymentSlipNo != 0 ) || ( this._paymentMainCndtn.Ed_PaymentSlipNo != 0 ) )
			{
                if (this._paymentMainCndtn.St_PaymentSlipNo != 0 )
                {
                    st_PaymentSlipNo = String.Format( "{0:D9}", this._paymentMainCndtn.St_PaymentSlipNo );
                }
                else
                {
                    st_PaymentSlipNo = ct_Extr_Top;
                }

                if (this._paymentMainCndtn.Ed_PaymentSlipNo != 0)
                {
                    ed_PaymentSlipNo = String.Format( "{0:D9}", this._paymentMainCndtn.Ed_PaymentSlipNo );
                }
                else
                {
                    ed_PaymentSlipNo = ct_Extr_End;
                }

                //this.EditCondition( ref addConditions, // DEL 2009/03/30
                this.EditCondition(ref extraConditions, // ADD 2009/03/30
					string.Format( "支払番号：{0} ～ {1}", st_PaymentSlipNo, ed_PaymentSlipNo)
				);
			}

			// 支払金種 ----------------------------------------------------------------------------------------------------
            if (!this._paymentMainCndtn.PaymentKind.ContainsKey(PaymentMainCndtn.ct_All_Code))
            {
                //this.EditCondition(ref addConditions, "支払金種：" + GetPaymentKindName()); // DEL 2009/03/30
                this.EditCondition(ref extraConditions, "支払金種：" + GetPaymentKindName()); // ADD 2009/03/30
            }
            // --- ADD 2009/03/27 -------------------------------->>>>>
            else
            {
                // 「全て」の場合は全て表示
                Dictionary<int, string> dicKindName = new Dictionary<int, string>();
                PaymentMainAcs paymentMainAcs = new PaymentMainAcs();
                int status = paymentMainAcs.SearchKindName(out dicKindName);
                if (status == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    //sb.Append("入金金種：");      // DEL 2009/04/28
                    sb.Append("支払金種：");        // ADD 2009/04/28

                    for (int i = 0; i < dicKindName.Count && i < 8; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append("、");
                        }

                        sb.Append(dicKindName[i]);
                    }

                    //this.EditCondition(ref addConditions, sb.ToString()); // DEL 2009/03/30
                    this.EditCondition(ref extraConditions, sb.ToString()); // ADD 2009/03/30
                }
            }
            // --- ADD 2009/03/27 --------------------------------<<<<<

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //foreach ( string exCondStr in addConditions )
            //{
            //    extraConditions.Add( exCondStr );
            //}
            // --- DEL 2009/03/30 --------------------------------<<<<<
		}
		#endregion

		#region ◎ 支払金種名称文字列作成
		/// <summary>
		/// 支払金種名称文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private string GetPaymentKindName()
		{
			StringBuilder result = new StringBuilder();

			foreach ( string corpName in this._paymentMainCndtn.PaymentKind.Values )
			{
				if ( result.ToString().CompareTo( string.Empty ) != 0 )
				{
					result.Append("、");
				}
				result.Append( corpName );
			}

			return result.ToString();
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAK02523P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
