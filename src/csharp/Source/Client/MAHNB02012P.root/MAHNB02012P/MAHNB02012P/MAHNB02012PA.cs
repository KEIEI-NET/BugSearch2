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
	/// 入金一覧表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 入金一覧表の印刷を行う。</br>
	/// <br>Programmer : 22013 久保 将太</br>
	/// <br>Date       : 2007.03.08</br>
    /// <br>UpdateNote : 2007.11.14 980035 金沢 貞義</br>
    ///                :    ・DC.NS対応（「入金一覧表」⇒「入金確認表」に変更）
    /// <br>UpdateNote : 2008.03.07 980035 金沢 貞義</br>
    /// <br>                ・DC.NS対応（日付表示修正）</br>
    /// <br>UpdateNote : 2008.07.10 30413 犬飼</br>
    /// <br>                ・PM.NS対応</br>
    /// <br>UpdateNote : 2008/10/10 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote : 2009/01/07 30413 犬飼</br>
    /// <br>                ・障害ID:9649対応</br>
    /// </remarks>
	class MAHNB02012PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 入金一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public MAHNB02012PA()
		{
		}

		/// <summary>
		/// 入金一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 入金一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public MAHNB02012PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._depositMainCndtn = this._printInfo.jyoken as DepositMainCndtn;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        // 2008.07.11 30413 犬飼 【TOP/END】を【最初から/最後まで】に変更 >>>>>>START
        //private const string ct_Extr_Top		= "ＴＯＰ";
        //private const string ct_Extr_End		= "ＥＮＤ";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        // 2008.07.11 30413 犬飼 【TOP/END】を【最初から/最後まで】に変更 <<<<<<END
        #endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private DepositMainCndtn _depositMainCndtn;		// 抽出条件クラス
		#endregion ■ Private Member

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class DepositMainException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public DepositMainException(string message, int status): base(message)
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
                // 2008.01.31 修正 >>>>>>>>>>>>>>>>>>>>
                prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                //// 印刷データ取得
                //DataSet ds = (DataSet)this._printInfo.rdData;
                //DataView dv = new DataView();
                //dv.Table = ds.Tables[MAHNB02014EA.ct_Tbl_DepositMain];

                //// ソート順設定
                //dv.Sort = this.GetPrintOderQuerry();

                //// データソース設定
                //prtRpt.DataSource = dv;
                // 2008.01.31 修正 <<<<<<<<<<<<<<<<<<<<
                prtRpt.DataMember = MAHNB02014EA.ct_Tbl_DepositMain;

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
				throw new DepositMainException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new DepositMainException(er.Message, -1);
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
            // --- CHG 2009/01/07 障害ID:9649対応------------------------------------------------------>>>>>
            //commonInfo.PrintMax    = 0;
            DataSet ds = (DataSet)this._printInfo.rdData;
            DataView dv = new DataView();
            dv.Table = ds.Tables[MAHNB02014EA.ct_Tbl_DepositMain];
            commonInfo.PrintMax = dv.Count;
            // --- CHG 2009/01/07 障害ID:9649対応------------------------------------------------------<<<<<
			
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
            DepositMainCndtn extraInfo = (DepositMainCndtn)this._printInfo.jyoken;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = GetSortOrderName( extraInfo );
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = DepositMainAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new DepositMainException(message, status);
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
			instance.PageHeaderSubtitle = this._depositMainCndtn.PrintDivName;

			// その他データ
			ArrayList otherDataList = new ArrayList();

            // 2008.07.23 30413 犬飼 小計タイトルと担当者タイトルの削除 >>>>>>START
            //otherDataList.Add(this._depositMainCndtn.SumDivPrintName);			// 小計タイトル
            //otherDataList.Add(this._depositMainCndtn.EmployeeKindDivName);		// 担当者タイトル名称
            // 2008.07.23 30413 犬飼 小計タイトルと担当者タイトルの削除 <<<<<<END
            
			// 全社が選択されていたら明細に拠点名称を出す。
			if ( this._depositMainCndtn.IsSelectAllSection )
			{
				otherDataList.Add("入金計上拠点");		// 明細拠点名称タイトル
			}
			else
			{
				otherDataList.Add( string.Empty );		// 明細拠点名称タイトル
			}
            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            otherDataList.Add(this._depositMainCndtn.DepositKindCode);          // 入金金種プロパティ
            otherDataList.Add(this._depositMainCndtn.DepositKindName);          // 入金金種プロパティ
            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<


            // 2008.07.11 30413 犬飼 金種名称を取得 >>>>>>START
            Dictionary<int, string> dicKindName = new Dictionary<int,string>();
            DepositMainAcs depositMainAcs = new DepositMainAcs();
            status = depositMainAcs.SearchKindName(out dicKindName);
            if (status == 0)
            {
                otherDataList.Add(dicKindName);
            }
            // 2008.07.11 30413 犬飼 金種名称を取得 <<<<<<END
            
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region ◎ ソート順名称取得
		/// <summary>
		/// ソート順名称取得
		/// </summary>
		/// <param name="depositMainCndtn">抽出条件</param>
		/// <returns>ソート順名称</returns>
		/// <remarks>
		/// <br>Note       : ソート順名称を取得する。</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetSortOrderName ( DepositMainCndtn depositMainCndtn )
		{
			string sortOrderName = string.Empty;
            // 2008.07.22 30413 犬飼 ソート順文字列の変更 >>>>>>START
            //const string ct_SortFomat = "[{0}{1}]";
            const string ct_SortFomat = "[ソート順：{0}]";
            // 2008.07.22 30413 犬飼 ソート順文字列の変更 <<<<<<END
            switch (depositMainCndtn.PrintDiv)
			{
                // 2008.07.10 30413 犬飼 帳票種別の変更 >>>>>>START
                //case (int)DepositMainCndtn.PrintDivState.GrandTotal:			// 総合計
                //// 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                //case (int)DepositMainCndtn.PrintDivState.DepositKind:           // 金種別集計
                //// 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
                //    sortOrderName = string.Empty;
                //    break;
                //// 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
                ////case (int)DepositMainCndtn.PrintDivState.Details_HaveDraw:	// 詳細引当有
                //// 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
                //case (int)DepositMainCndtn.PrintDivState.Details_NotDraw:		// 詳細引当無
                //case (int)DepositMainCndtn.PrintDivState.Simple:			    // 簡易日計
                //    // 小計区分が入金番号か
                //    if ( depositMainCndtn.SumDiv == DepositMainCndtn.SumDivState.DepositSlipNo )
                //        sortOrderName = string.Format( ct_SortFomat, string.Empty, depositMainCndtn.SumDivPrintName + "毎" );
                //    else
                //        sortOrderName = string.Format( ct_SortFomat, depositMainCndtn.SortOrderDivName, ct_Space + depositMainCndtn.SumDivPrintName + "毎" );
                //    break;
                case (int)DepositMainCndtn.PrintDivState.DepsitMainList:             // 入金確認表
                case (int)DepositMainCndtn.PrintDivState.DepositMainList_Sum:             // 入金確認表(集計表)
                    sortOrderName = string.Format(ct_SortFomat, depositMainCndtn.SortOrderDivName);
                    break;
                // 2008.07.10 30413 犬飼 帳票種別の変更 <<<<<<END
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
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "：{0} ～ {1}";
			extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // 2008.07.14 30413 犬飼 変数追加 >>>>>>START
            string target = "";
            // 2008.07.14 30413 犬飼 変数追加 <<<<<<END
            
			// 抽出日付 ----------------------------------------------------------------------------------------------------
            // 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
            //string st_AddUpADate = string.Empty;
            //string ed_AddUpADate = string.Empty;
            //// 開始
            //if ( this._depositMainCndtn.St_AddUpADate != DateTime.MinValue )
            //    st_AddUpADate = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_AddUpADate );
            //else
            //    st_AddUpADate = ct_Extr_Top;
            //// 終了
            //if ( this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue )
            //    ed_AddUpADate = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_AddupADate );
            //else
            //    ed_AddUpADate = ct_Extr_End;

            //this.EditCondition(ref extraConditions, string.Format( "入金計上日　" + ct_RangeConst, st_AddUpADate, ed_AddUpADate ) );
            // 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.07.23 30413 犬飼 抽出条件の入金日の印字順を変更 >>>>>>START
            if ((this._depositMainCndtn.St_AddUpADate != DateTime.MinValue) ||
                ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue)))
            {
                string st_AddUpADate = string.Empty;
                string ed_AddUpADate = string.Empty;
                // 開始
                if (this._depositMainCndtn.St_AddUpADate != DateTime.MinValue)
                    st_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_AddUpADate);
                else
                    st_AddUpADate = ct_Extr_Top;
                // 終了
                if ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue))
                    ed_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_AddupADate);
                else
                    ed_AddUpADate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("入金日　" + ct_RangeConst, st_AddUpADate, ed_AddUpADate));
            }// 2008.07.23 30413 犬飼 抽出条件の入金日の印字順を変更 <<<<<<END

            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            if ((this._depositMainCndtn.St_CreateDate != DateTime.MinValue) || (this._depositMainCndtn.Ed_CreateDate != DateTime.MinValue))
            {
                string st_CreateDate = string.Empty;
                string ed_CreateDate = string.Empty;
                // 開始
                if (this._depositMainCndtn.St_CreateDate != DateTime.MinValue)
                    st_CreateDate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_CreateDate);
                else
                    st_CreateDate = ct_Extr_Top;
                // 終了
                if (this._depositMainCndtn.Ed_CreateDate != DateTime.MinValue)
                    ed_CreateDate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_CreateDate);
                else
                    ed_CreateDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("入力日　" + ct_RangeConst, st_CreateDate, ed_CreateDate));
            }
            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.07.23 30413 犬飼 抽出条件の入金日の印字順を変更 >>>>>>START
            //// 2008.03.07 修正 >>>>>>>>>>>>>>>>>>>>
            //if ( (this._depositMainCndtn.St_AddUpADate != DateTime.MinValue) ||
            //    ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue)))
            //{
            //    string st_AddUpADate = string.Empty;
            //    string ed_AddUpADate = string.Empty;
            //    // 開始
            //    if (this._depositMainCndtn.St_AddUpADate != DateTime.MinValue)
            //        st_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_AddUpADate);
            //    else
            //        st_AddUpADate = ct_Extr_Top;
            //    // 終了
            //    if ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue))
            //        ed_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_AddupADate);
            //    else
            //        ed_AddUpADate = ct_Extr_End;

            //    this.EditCondition(ref extraConditions, string.Format("入金計上日　" + ct_RangeConst, st_AddUpADate, ed_AddUpADate));
            //}
            //// 2008.03.07 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.07.23 30413 犬飼 抽出条件の入金日の印字順を変更 <<<<<<END

            //StringCollection addConditions = new StringCollection();
            
            // 2008.07.14 30413 犬飼 最初から～最後までに変更 >>>>>>START
            // 得意先コード ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_CustomerCode != 0) || (this._depositMainCndtn.Ed_CustomerCode != 999999999))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("得意先コード：{0} ～ {1}", this._depositMainCndtn.St_CustomerCode, this._depositMainCndtn.Ed_CustomerCode)
            //    );
            //}
            if ((this._depositMainCndtn.St_CustomerCode == 0) && (this._depositMainCndtn.Ed_CustomerCode != 0))
            {
                // DEL 2008/10/10 不具合対応[6362] ↓
                //target = "得意先コード: " + ct_Extr_Top + " ～ " + this._depositMainCndtn.Ed_CustomerCode.ToString();
                target = "得意先コード: " + ct_Extr_Top + " ～ " + this._depositMainCndtn.Ed_CustomerCode.ToString().PadLeft(8,'0');    // ADD 2008/10/10 不具合対応[6362]
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_CustomerCode > 0) && (this._depositMainCndtn.Ed_CustomerCode == 0))
            {
                // DEL 2008/10/10 不具合対応[6362] ↓
                //target = "得意先コード: " + this._depositMainCndtn.St_CustomerCode.ToString() + " ～ " + ct_Extr_End;
                target = "得意先コード: " + this._depositMainCndtn.St_CustomerCode.ToString().PadLeft(8, '0') + " ～ " + ct_Extr_End;    // ADD 2008/10/10 不具合対応[6362]
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_CustomerCode > 0) && (this._depositMainCndtn.Ed_CustomerCode != 0))
            {
                // DEL 2008/10/10 不具合対応[6362] ↓
                //target = "得意先コード: " + this._depositMainCndtn.St_CustomerCode.ToString() + " ～ " + this._depositMainCndtn.Ed_CustomerCode.ToString();
                target = "得意先コード: " + this._depositMainCndtn.St_CustomerCode.ToString().PadLeft(8,'0') + " ～ " + this._depositMainCndtn.Ed_CustomerCode.ToString().PadLeft(8,'0');    // ADD 2008/10/10 不具合対応[6362]
                this.EditCondition(ref addConditions, target);
            }
            // 2008.07.14 30413 犬飼 最初から～最後までに変更 >>>>>>END

            // 2008.07.23 30413 犬飼 得意先カナと担当者コードの削除 >>>>>>START
            //// 得意先カナ ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_CustomerKana != string.Empty) || (this._depositMainCndtn.Ed_CustomerKana != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("得意先カナ", this._depositMainCndtn.St_CustomerKana, this._depositMainCndtn.Ed_CustomerKana));
            //}

            //// 担当者コード ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_EmployeeCode != string.Empty) || (this._depositMainCndtn.Ed_EmployeeCode != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        // 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
            //        //GetConditionRange(this._depositMainCndtn.EmployeeKindDivName + "者コード", this._depositMainCndtn.St_EmployeeCode, this._depositMainCndtn.Ed_EmployeeCode));
            //        GetConditionRange(this._depositMainCndtn.EmployeeKindDivName + "コード", this._depositMainCndtn.St_EmployeeCode, this._depositMainCndtn.Ed_EmployeeCode));
            //        // 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<
            //}
            // 2008.07.23 30413 犬飼 得意先カナと担当者コードの削除 <<<<<<END
            
            // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 個人法人区分 ----------------------------------------------------------------------------------------------------
			//if ( ( this._depositMainCndtn.CorporateDivCode.Count > 0 ) && ( this._depositMainCndtn.CorporateDivCode.Count < 5 ) )
			//{
			//	this.EditCondition( ref addConditions, "法人区分：" + GetCorporateDivCodeName() );
			//}
            // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 入金区分 ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, "入金区分：" + this._depositMainCndtn.DepositNm);
            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.07.14 30413 犬飼 最初から～最後までに変更 >>>>>>START
            // 入金番号 ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_DepositSlipNo != 0) || (this._depositMainCndtn.Ed_DepositSlipNo != 999999999))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("入金番号：{0} ～ {1}",
            //            String.Format("{0:D9}", this._depositMainCndtn.St_DepositSlipNo),
            //            String.Format("{0:D9}", this._depositMainCndtn.Ed_DepositSlipNo)
            //        )
            //    );
            //}
            if ((this._depositMainCndtn.St_DepositSlipNo == 0) && (this._depositMainCndtn.Ed_DepositSlipNo != 0))
            {
                target = "入金番号: " + ct_Extr_Top + " ～ " + this._depositMainCndtn.Ed_DepositSlipNo.ToString();
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_DepositSlipNo > 0) && (this._depositMainCndtn.Ed_DepositSlipNo == 0))
            {
                target = "入金番号: " + this._depositMainCndtn.St_DepositSlipNo.ToString() + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_DepositSlipNo > 0) && (this._depositMainCndtn.Ed_DepositSlipNo != 0))
            {
                target = "入金番号: " + this._depositMainCndtn.St_DepositSlipNo.ToString() + " ～ " + this._depositMainCndtn.Ed_DepositSlipNo.ToString();
                this.EditCondition(ref addConditions, target);
            }
            // 2008.07.14 30413 犬飼 最初から～最後までに変更 >>>>>>END
            
            // 入金金種 ----------------------------------------------------------------------------------------------------
            // 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
            if (!this._depositMainCndtn.DepositKind.ContainsKey(DepositMainCndtn.ct_All_Code))
            {
                this.EditCondition(ref addConditions, "入金金種：" + GetDepositKindName());
            }
            // --- ADD 2009/03/27 -------------------------------->>>>>
            else
            {
                // 「全て」の場合は全て表示
                Dictionary<int, string> dicKindName = new Dictionary<int, string>();
                DepositMainAcs depositMainAcs = new DepositMainAcs();
                int status = depositMainAcs.SearchKindName(out dicKindName);
                if (status == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("入金金種：");

                    for (int i = 0; i < dicKindName.Count && i < 8; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append("、");
                        }

                        sb.Append(dicKindName[i]);
                    }

                    this.EditCondition(ref addConditions, sb.ToString());
                }
            }
            // --- ADD 2009/03/27 --------------------------------<<<<<
            //this.EditCondition(ref addConditions, "入金金種：" + GetDepositKindName());
            // 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 引当区分 ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, "引当区分：" + this._depositMainCndtn.AllowanceDivName);
            // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// クレジットローン区分 ----------------------------------------------------------------------------------------------------
			//if ( this._depositMainCndtn.CreditOrLoanCd != DepositMainCndtn.CreditOrLoanCdState.All )
			//{
			//	this.EditCondition( ref addConditions, "クレジット/ローン：" + this._depositMainCndtn.CreditOrLoanNm );
			//}
            //
			//// 引当状態 ----------------------------------------------------------------------------------------------------
			//// 引当状態は詳細引当有のときのみ有効
			//if ( this._depositMainCndtn.PrintDiv == (int)DepositMainCndtn.PrintDivState.Details_HaveDraw )
			//{
			//	if ( this._depositMainCndtn.AllowanceDiv != DepositMainCndtn.AllowanceDivState.All )
			//	{
			//		this.EditCondition( ref addConditions, "引当状態：" + this._depositMainCndtn.CreditOrLoanNm );
			//	}
			//}
            // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

			foreach ( string exCondStr in addConditions )
			{
				extraConditions.Add( exCondStr );
			}

		}
		#endregion

		#region ◎ 入金金種名称文字列作成
		/// <summary>
		/// 入金金種名称文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetDepositKindName()
		{
			StringBuilder result = new StringBuilder();

			foreach ( string corpName in this._depositMainCndtn.DepositKind.Values )
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

        // 2008.07.14 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 個人法人区分名称文字列作成
        ///// <summary>
        ///// 個人法人区分名称文字列作成
        ///// </summary>
        ///// <returns>作成文字列</returns>
        ///// <remarks>
        ///// <br>Note       : 抽出範囲文字列を作成します</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.08</br>
        ///// </remarks>
        //private string GetCorporateDivCodeName()
        //{
        //    StringBuilder result = new StringBuilder();

        //    foreach ( string corpName in this._depositMainCndtn.CorporateDivCode.Values )
        //    {
        //        if ( result.ToString().CompareTo( string.Empty ) != 0 )
        //        {
        //            result.Append("・");
        //        }
        //        result.Append( corpName );
        //    }

        //    return result.ToString();
        //}
		#endregion
        // 2008.07.14 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
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

        // 2008.07.23 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◆　印刷順クエリ作成関数
        ///// <summary>
        ///// 印字順クエリ作成処理
        ///// </summary>
        ///// <returns>作成したクエリ</returns>
        ///// <remarks>
        ///// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        ///// <br>Programmer : 980035 金沢 貞義</br>
        ///// <br>Date       : 2008.01.31</br>
        ///// </remarks>
        //private string GetPrintOderQuerry()
        //{
        //    string orderQuerry = "";

        //    orderQuerry = MAHNB02014EA.ct_Col_AddUpSecCode;
        //    // 小計区分を選択
        //    switch (this._depositMainCndtn.SumDiv)
        //    {
        //        case DepositMainCndtn.SumDivState.Day:				// 日計
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_AddUpADate;
        //                break;
        //            }
        //        case DepositMainCndtn.SumDivState.Customer:			// 得意先計
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_CustomerCode;
        //                break;
        //            }
        //        case DepositMainCndtn.SumDivState.DepositKind:		// 金種計
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_DepositKindCode;
        //                break;
        //            }
        //        case DepositMainCndtn.SumDivState.DepositSlipNo:	// 入金番号
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_DepositSlipNo;
        //                break;
        //            }
        //    }
        //    // 並び順条件を選択
        //    switch (this._depositMainCndtn.SortOrderDiv)
        //    {
        //        case DepositMainCndtn.SortOrderDivState.CustomerCode:	// 得意先コード順
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_CustomerCode;
        //                break;
        //            }
        //        case DepositMainCndtn.SortOrderDivState.CustomerKane:	// 得意先カナ順
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_Kana;
        //                break;
        //            }
        //        case DepositMainCndtn.SortOrderDivState.EmployeeCode:	// 担当者コード順
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_AgentCode;
        //                break;
        //            }
        //    }

        //    return orderQuerry;
        //}
        #endregion
        // 2008.07.23 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
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
			return TMsgDisp.Show(iLevel, "MAHNB02012P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
