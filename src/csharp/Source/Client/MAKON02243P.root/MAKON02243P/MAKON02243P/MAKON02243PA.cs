//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入確認表
// プログラム概要   : 仕入確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 作 成 日  2008/07/16  修正内容 : データ項目の追加/修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/12/02  修正内容 : ソート条件に仕入SEQ番号を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津 銀次郎
// 修 正 日  2008/12/02  修正内容 : 印刷の伝票モード時、伝票番号ソートを選んでもSEQ番号ソートされていた障害を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13157(フッタ情報の取得処理を追加)
//----------------------------------------------------------------------------//
#define CHG20060329
#define CHG20060410
#define CHG20060418
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/06 不具合対応[5654]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller; // ADD 2009/04/07


namespace Broadleaf.Drawing.Printing
{
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・データ項目の追加/修正</br>
    /// <br>Programmer	: 30415 柴田 倫幸</br>
    /// <br>Date		: 2008/07/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・ソート条件に仕入SEQ番号を追加</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2008/12/02</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・印刷の伝票モード時、伝票番号ソートを選んでもSEQ番号ソートされていた障害を修正</br>
    /// <br>Programmer	: 30365 宮津 銀次郎</br>
    /// <br>Date		: 2008/12/02</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・障害対応13157(フッタ情報の取得処理を追加)</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------
	public class MAKON02243PA
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public MAKON02243PA()
		{
		}
		/// <summary>
		public MAKON02243PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._csStockConfPara = this._printInfo.jyoken as ExtrInfo_MAKON02247E;

            this.SelectTableName();

        }
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "　　　　　";

		#endregion
		
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// 帳票系共通部品
        private ExtrInfo_MAKON02247E _csStockConfPara = null;
        #endregion

        /// <summary>表示順位</summary>
        private string CT_Sort1_Odr = "SectionCodeRF, StockDateRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        //private string CT_Sort2_Odr = "SectionCodeRF, SupplierCd, StockDateRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // DEL 2008/12/02
        private string CT_Sort2_Odr = "SectionCodeRF, SupplierCd, StockDateRF, PartySaleSlipNumRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // ADD 2008/12/02
        private string CT_Sort3_Odr = "SectionCodeRF, InputDayRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        //private string CT_Sort4_Odr = "SectionCodeRF, SupplierCd, InputDayRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // DEL 2008/12/02
        private string CT_Sort4_Odr = "SectionCodeRF, SupplierCd, InputDayRF, PartySaleSlipNumRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // ADD 2008/12/02
        private string CT_Sort5_Odr = "SectionCodeRF, SupplierCd, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";                

        private string CT_Sort6_Odr = "SectionCodeRF, SupplierCd, StockDateRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        private string CT_Sort7_Odr = "SectionCodeRF, SupplierCd, InputDayRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        private string CT_Sort8_Odr = "SectionCodeRF, SupplierCd, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";

        // >>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu DEL
        //private string CT_Sort_Den_Odr = "SectionCodeRF, SupplierCd, StockDateRF, SupplierSlipNoRF";

        // >>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
        private string CT_Sort1_Den_Odr = "SectionCodeRF, SupplierCd, StockDateRF, SupplierSlipNoRF";
        private string CT_Sort2_Den_Odr = "SectionCodeRF, SupplierCd, InputDayRF, SupplierSlipNoRF";
        private string CT_Sort3_Den_Odr = "SectionCodeRF, SupplierCd, StockDateRF, PartySaleSlipNumRF";
        private string CT_Sort4_Den_Odr = "SectionCodeRF, SupplierCd, InputDayRF, PartySaleSlipNumRF";
        // <<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD

		// 伝票形式
		private string CT_Sort1_OdrStr = "仕入日→伝票番号";
		private string CT_Sort2_OdrStr = "仕入先→仕入日→伝票番号";
		private string CT_Sort3_OdrStr = "入力日→伝票番号";
		private string CT_Sort4_OdrStr = "仕入先→入力日→伝票番号";
		private string CT_Sort5_OdrStr = "仕入先→伝票番号";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        private string CT_Sort6_OdrStr = "仕入先→仕入日→仕入SEQ番号";
        private string CT_Sort7_OdrStr = "仕入先→入力日→仕入SEQ番号";
        private string CT_Sort8_OdrStr = "仕入先→仕入SEQ番号";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        // データ取得元テーブル名
        private string ct_TableName;

		//================================================================================
		//  外部提供プロパティ
		//================================================================================
		#region public property
		#region IPrintProcの実装部(プロパティ) 
		/// <summary>印刷データ</summary>
		/// <value>印刷するデータを取得または設定します。</value>
		public SFCMN06002C Printinfo
		{
			get { return _printInfo; }
			set { _printInfo = value; }
		}
		#endregion
		#endregion
	
		// ===============================================================================
		// 例外クラス
		// ===============================================================================
		#region 例外クラス
		private class DemandPrintException: ApplicationException
		{
			private int _status;

			#region constructor
			public DemandPrintException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region public property
			public int Status
			{
				get{return this._status;}
			}
			#endregion
		}
		#endregion
		
		//================================================================================
		//  IPrintProcの実装部　印刷メイン処理
		//================================================================================
		#region IPrintProcの実装部
		/// <summary>
		/// 印刷開始処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷の開始処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion

		//================================================================================
		// 内部関数
		//================================================================================
		#region Private Methods
		#region ◆　印刷メイン処理
		/// <summary>
		/// 印刷メイン処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷のメイン処理を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			try
			{
				// 印刷フォームクラスインスタンス作成
				DataDynamics.ActiveReports.ActiveReport3 prtRpt;

				// レポートインスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;

				// 印刷データ取得
				DataSet ds = (DataSet)this._printInfo.rdData;
				DataView dv = new DataView();
                dv.Table = ds.Tables[ct_TableName];
				
				// ソート順設定
				dv.Sort = this.GetPrintOderQuerry();
				
				// データソース設定
				prtRpt.DataSource = dv;

				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

				// プレビュー有無				
				int prevkbn = this._printInfo.prevkbn;
               
                // 出力モードがＰＤＦの場合、無条件でプレビュー無
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}
				switch(prevkbn)
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
						case 1:		// プリンタ
							break;
						case 2:		// ＰＤＦ
						case 3:		// 両方(プリンタ + ＰＤＦ)
						{
							// ＰＤＦ表示フラグON
							this._printInfo.pdfopen = true;
							
							// 両方印刷時のみ履歴保存
							if (this._printInfo.printmode == 3)
							{
                                // ----- iitani c ---------- start 2007.05.26
                                //// 出力履歴管理に追加
                                //this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "仕入確認表", this._printInfo.prpnm,
                                //    this._printInfo.pdftemppath);
                                // 出力履歴管理に追加
                                Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                    this._printInfo.pdftemppath);
                                // ----- iitani c ---------- end 2007.05.26
                            }
							break;
						}
					}
				}

			}
			catch(DemandPrintException ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, ex.Status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			catch(Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			return status;
		}

        /// <summary>
        /// 仕様テーブル名設定処理
        /// </summary>
        private void SelectTableName()
        {
			if (_printInfo.frycd == 3)
			{
				ct_TableName = MAKON02249EB.CT_StockConfSlipTtlDataTable;
			}
			else
			{
				ct_TableName = MAKON02249EA.CT_StockConfDataTable;
			}
        }

		#endregion
	
		#region ◆　ActiveReport帳票インスタンス作成関連
		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}

		/// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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
				throw new DemandPrintException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new DemandPrintException(er.Message, -1);
			}
			return obj;
		}
		#endregion
	
		#region ◆　AvtiveReportに各種プロパティを設定します
		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // --- ADD 2009/04/07 -------------------------------->>>>>
            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            StockConfAcs _stockConfAcs = new StockConfAcs();
            int st = _stockConfAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // --- ADD 2009/04/07 --------------------------------<<<<<

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // ソート順
            string wrkstr = "";
            string target = "";

            #region [--2008/12/02 G.Miyatsu DEL--]
            //伝票形式
            //if (_printInfo.frycd == 3)
            //{
            //    wrkstr = CT_Sort1_Den_OdrStr;
            //}
            
            //明細形式 詳細形式
            // DEL 2008/10/08 不具合対応[5664]↓
            //else
            //{
            #endregion
            switch (this._csStockConfPara.SortOrder)
            {
                case 0:
                    {
                        wrkstr = CT_Sort1_OdrStr;
                        break;
                    }
                case 1:
                    {
                        wrkstr = CT_Sort2_OdrStr;
                        break;
                    }
                case 2:
                    {
                        wrkstr = CT_Sort3_OdrStr;
                        break;
                    }
                case 3:
                    {
                        wrkstr = CT_Sort4_OdrStr;
                        break;
                    }
                case 4:
                    {
                        wrkstr = CT_Sort5_OdrStr;
                        break;
                    }
                case 5:
                    {
                        // 仕入先→仕入日付→仕入SEQ番号
                        wrkstr = CT_Sort6_OdrStr;
                        break;
                    }
                case 6:
                    {
                        // 仕入先→入力日付→仕入SEQ番号
                        wrkstr = CT_Sort7_OdrStr;
                        break;
                    }
                case 7:
                    {
                        // 仕入先→仕入SEQ番号
                        wrkstr = CT_Sort8_OdrStr;
                        break;
                    }
            }
            // DEL 2008/10/08 不具合対応[5664]↓
            //}

            target = "ソート順：[" + wrkstr + "] 順";
            instance.PageHeaderSortOderTitle = target;
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
		}
		#endregion
	
		#region ◆　抽出条件ヘッダー作成処理
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
			// 抽出条件ヘッダー項目
			extraConditions = new StringCollection();
			
			// 伝票日付
			string target = "";
			string stTarget = "";
			string edTarget = "";
            string wrkstr = "";
            wrkstr = "";

			if ((this._csStockConfPara.StockDateSt != 0) || (this._csStockConfPara.StockDateEd != 0))
			{
				// 開始
				if (this._csStockConfPara.StockDateSt != 0)
					stTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.StockDateSt);
				else
					stTarget = ct_Extr_Top;

				// 終了
				if (this._csStockConfPara.StockDateEd != 0)
					edTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.StockDateEd);
				else
					edTarget = ct_Extr_End;

				target = "仕入日： " + stTarget + "  ～　" + edTarget;
				this.EditCondition(ref extraConditions, target);
			}

			// 入力日付
			target = "";
			stTarget = "";
			edTarget = "";
			wrkstr = "";
			wrkstr = "";

			if ((this._csStockConfPara.InputDaySt != 0) || (this._csStockConfPara.InputDayEd != 0))
			{
				// 開始
				if (this._csStockConfPara.InputDaySt != 0)
					stTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.InputDaySt);
				else
					stTarget = ct_Extr_Top;

				// 終了
				if (this._csStockConfPara.InputDayEd != 0)
					edTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.InputDayEd);
				else
					edTarget = ct_Extr_End;

				target = "入力日： " + stTarget + "  ～　" + edTarget;
				this.EditCondition(ref extraConditions, target);
			}

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //// ソート順
            //wrkstr = "";
            //target = "";

            ////伝票形式
            //if (_printInfo.frycd == 3)
            //{
            //    wrkstr = CT_Sort_Den_OdrStr;
            //}
            ////明細形式 詳細形式
            //else
            //{

            //    switch (this._csStockConfPara.SortOrder)
            //    {
            //        case 0:
            //            {
            //                wrkstr = CT_Sort1_OdrStr;
            //                break;
            //            }
            //        case 1:
            //            {
            //                wrkstr = CT_Sort2_OdrStr;
            //                break;
            //            }
            //        case 2:
            //            {
            //                wrkstr = CT_Sort3_OdrStr;
            //                break;
            //            }
            //        case 3:
            //            {
            //                wrkstr = CT_Sort4_OdrStr;
            //                break;
            //            }
            //        case 4:
            //            {
            //                wrkstr = CT_Sort5_OdrStr;
            //                break;
            //            }
            //    }
            //}
            //target = "ソート順：" + wrkstr + " 順";
            //this.EditCondition(ref extraConditions, target);
            // --- DEL 2008/07/16 --------------------------------<<<<< 



            // 担当者
            if ((this._csStockConfPara.StockAgentCodeSt != "") || (this._csStockConfPara.StockAgentCodeEd != ""))
            {
                this.EditCondition(ref extraConditions,
                    GetConditionRange("担当者：{0} ～ {1}", this._csStockConfPara.StockAgentCodeSt, this._csStockConfPara.StockAgentCodeEd));
            }

            // DEL 2008/10/06 不具合対応[5654]---------->>>>>
            //// --- ADD 2008/07/16 -------------------------------->>>>>
            //// 地区
            //if ((this._csStockConfPara.SalesAreaCodeSt != 0) || (this._csStockConfPara.SalesAreaCodeEd != 0))
            //{
            //    this.EditCondition(ref extraConditions,
            //        GetConditionRange("地区：{0} ～ {1}", this._csStockConfPara.SalesAreaCodeSt, this._csStockConfPara.SalesAreaCodeEd,"d4"));
            //}
            //// --- ADD 2008/07/16 --------------------------------<<<<<
            // DEL 2008/10/06 不具合対応[5654]----------<<<<<
            // ADD 2008/10/06 不具合対応[5654]---------->>>>>
            int convertedSalesAreaCodeEd = (this._csStockConfPara.SalesAreaCodeEd.Equals(0) ? RangeUtil.SalesAreaCode.MAX + 1 : this._csStockConfPara.SalesAreaCodeEd);
            if (!RangeUtil.SalesAreaCode.IsAllRange(
                this._csStockConfPara.SalesAreaCodeSt,
                convertedSalesAreaCodeEd
            ))
            {
                string start= RangeUtil.SalesAreaCode.GetStartString(this._csStockConfPara.SalesAreaCodeSt);
                string end  = RangeUtil.SalesAreaCode.GetEndString(convertedSalesAreaCodeEd);

                EditCondition(
                    ref extraConditions,
                    string.Format("地区" + ct_RangeConst, start, end)
                );
            }
            // ADD 2008/10/06 不具合対応[5654]----------<<<<<

            // 仕入先
            //if ((this._csStockConfPara.CustomerCodeSt != 0) || (this._csStockConfPara.CustomerCodeEd != 0))  // DEL 2008/07/16
            if ((this._csStockConfPara.SupplierCdSt != 0) || (this._csStockConfPara.SupplierCdEd != 0))        // ADD 2008/07/16
            {
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //this.EditCondition(ref extraConditions,
                //    GetConditionRange("仕入先コード:{0} ～ {1}", this._csStockConfPara.CustomerCodeSt, this._csStockConfPara.CustomerCodeEd, "d9"));
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                this.EditCondition(ref extraConditions,
                    GetConditionRange("仕入先:{0} ～ {1}", this._csStockConfPara.SupplierCdSt, this._csStockConfPara.SupplierCdEd, "d6"));
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }

            // 仕入SEQ番号
            if ((this._csStockConfPara.SupplierSlipNoSt != 0) || (this._csStockConfPara.SupplierSlipNoEd != 0))
            {
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //this.EditCondition(ref extraConditions,
                //    GetConditionRange("伝票番号:{0} ～ {1}", this._csStockConfPara.SupplierSlipNoSt, this._csStockConfPara.SupplierSlipNoEd, "d9"));
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                this.EditCondition(ref extraConditions,
                    GetConditionRange("仕入SEQ番号:{0} ～ {1}", this._csStockConfPara.SupplierSlipNoSt, this._csStockConfPara.SupplierSlipNoEd, "d9"));
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }

			// 伝票番号
			if ((this._csStockConfPara.PartySaleSlipNumSt != "") || (this._csStockConfPara.PartySaleSlipNumEd != ""))
			{
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //this.EditCondition(ref extraConditions,
                //    GetConditionRange("相手先伝票番号:{0} ～ {1}", this._csStockConfPara.PartySaleSlipNumSt, this._csStockConfPara.PartySaleSlipNumEd));
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                this.EditCondition(ref extraConditions,
                    GetConditionRange("伝票番号:{0} ～ {1}", this._csStockConfPara.PartySaleSlipNumSt, this._csStockConfPara.PartySaleSlipNumEd));
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }

            // ADD 2008/10/06 不具合対応[5654]---------->>>>>
            // 伝票区分
            string supplierSlipCdLabel = string.Empty;
            switch (this._csStockConfPara.SupplierSlipCd)   // 場合分けの数値は画面（コンボボックスのアイテム値）より
            {
                case 0: // 全て
                    {
                        supplierSlipCdLabel = "全て";    // LITERAL:
                        break;
                    }
                case 10:// 仕入
                    {
                        supplierSlipCdLabel = "仕入";    // LITERAL:   
                        break;
                    }
                case 20:// 返品
                    {
                        supplierSlipCdLabel = "返品";    // LITERAL:
                        break;
                    }
                // 2009.02.20 30413 犬飼 "返品＋行値引"を追加 >>>>>>START
                case 30:// 返品+行値引
                    {
                        supplierSlipCdLabel = "返品＋行値引";    // LITERAL:
                        break;
                    }
                // 2009.02.20 30413 犬飼 "返品＋行値引"を追加 <<<<<<END
                default:
                    {
                        supplierSlipCdLabel = "全て";    // LITERAL:
                        break;
                    }
            }
            EditCondition(ref extraConditions, "伝票区分：" + supplierSlipCdLabel + " ");   // LITERAL:

            // 赤伝区分
            string debitNoteDivLabel = string.Empty;
            switch (this._csStockConfPara.DebitNoteDiv + 1) // 場合分けの数値は画面（コンボボックスのアイテム値）より
            {
                case 0: // 全て
                    {
                        debitNoteDivLabel = "全て";    // LITERAL:
                        break;
                    }
                case 1: // 黒伝
                    {
                        debitNoteDivLabel = "黒伝";    // LITERAL:   
                        break;
                    }
                case 2: // 赤伝
                    {
                        debitNoteDivLabel = "赤伝";    // LITERAL:
                        break;
                    }
                case 3: // 元黒
                    {
                        debitNoteDivLabel = "元黒";    // LITERAL:
                        break;
                    }
                default:
                    {
                        debitNoteDivLabel = "全て";    // LITERAL:
                        break;
                    }

            }
            EditCondition(ref extraConditions, "赤伝区分：" + debitNoteDivLabel + " ");   // LITERAL:
            // ADD 2008/10/06 不具合対応[5654]----------<<<<<

            // 発行タイプ
            wrkstr = "";
            target = "";
            switch (this._csStockConfPara.PrintType)
            {
                case 0:
                    {
                        wrkstr = "通常";
                        break;
                    }
                case 1:
                    {
                        wrkstr = "訂正";
                        break;
                    }
                case 2:
                    {
                        wrkstr = "削除";
                        break;
                    }
                case 3:
                    {
                        wrkstr = "訂正＋削除";
                        break;
                    }
            }

            target = "発行タイプ：";
            target = "発行タイプ：" + wrkstr + " ";
            this.EditCondition(ref extraConditions, target);

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 出力指定
            wrkstr = "";
            target = "";
            switch (this._csStockConfPara.OutputDesignated)
            {
                case 0:
                    {
                        wrkstr = "全て";
                        break;
                    }
                case 1:
                    {
                        wrkstr = "仕入入力";
                        break;
                    }
                case 2:
                    {
                        wrkstr = "UOE分";
                        break;
                    }
                case 3:
                    {
                        wrkstr = "同時入力分";
                        break;
                    }
                case 4:
                    {
                        wrkstr = "UOEアンマッチ";
                        break;
                    }
            }
            target = "出力指定：" + wrkstr + " ";
            this.EditCondition(ref extraConditions, target);

            // 在取指定
            wrkstr = "";
            target = "";
            switch (this._csStockConfPara.StockOrderDivCd)
            {
                case -1:
                    {
                        wrkstr = "全て";
                        break;
                    }
                case 0:
                    {
                        wrkstr = "取寄せ";
                        break;
                    }
                case 1:
                    {
                        wrkstr = "在庫";
                        break;
                    }
            }
            target = "在庫取寄指定：" + wrkstr + " ";   // MOD 2008/10/06 不具合対応[5654] "在取指定："→"在庫取寄指定："
            this.EditCondition(ref extraConditions, target);
            // --- ADD 2008/07/16 --------------------------------<<<<< 
		}

		#region ◎ 抽出範囲文字列作成
        // --- DEL 2008/07/16 -------------------------------->>>>>
        //private const string ct_Extr_Top = "ＴＯＰ";
        //private const string ct_Extr_End = "ＥＮＤ";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/10/06 不具合対応[5654] "最初から"→RangeUtil.FROM_BEGIN
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/10/06 不具合対応[5654] "最後まで"→RangeUtil.TO_END
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		private const string ct_RangeConst = "：{0} ～ {1}";

		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange(string title, string startString, string endString)
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end = ct_Extr_End;
				if (startString != "") start = startString;
				if (endString != "") end = endString;
				//result = String.Format(title + ct_RangeConst, start, end);  // DEL 2008/07/16
                result = String.Format(title, start, end);                    // ADD 2008/07/16
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
                //result = String.Format(title + ct_RangeConst, start, end);  // DEL 2008/07/16
                result = String.Format(title, start, end);                    // ADD 2008/07/16
			}
			return result;
		}
		#endregion

		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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

				if ((areaByte + targetByte + 2) <= 186)
				{
					isEdit = true;

					// 全角スペースを挿入
					if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;
					
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
		
		#region ◆　共通プレビュー部品パラメータ設定
		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// 印刷件数
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[ct_TableName].Rows.Count;
			
			// 印刷モード
			commonInfo.PrintMode   = this._printInfo.printmode;
			
			// 余白設定
			// 桁位置
			commonInfo.MarginsLeft = this._printInfo.px;
			
			// 行位置
			commonInfo.MarginsTop  = this._printInfo.py;

			// PDF出力フルパス
			string pdfPath = "";
			string pdfName = "";
			this._sfcmn00331C.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			
			string pdfFileName     = System.IO.Path.Combine(pdfPath,pdfName);
			commonInfo.PdfFullPath = pdfFileName;
			
			this._printInfo.pdftemppath = pdfFileName;
		}
		#endregion
		
		#region ◆　印刷順クエリ作成関数
		/// <summary>
		/// 印字順クエリ作成処理
		/// </summary>
		/// <returns>作成したクエリ</returns>
		/// <remarks>
		/// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.06</br>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
            string oderQuerry = "";

			//伝票形式
			if (_printInfo.frycd == 3)
			{
                // >>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
                switch (this._csStockConfPara.SortOrder)
                {
                    case 1:
                        {
                            oderQuerry = CT_Sort3_Den_Odr;
                            break;
                        }
                    case 3:
                        {
                            oderQuerry = CT_Sort4_Den_Odr;
                            break;
                        }
                    case 5:
                        {
                            oderQuerry = CT_Sort1_Den_Odr;
                            break;
                        }
                    case 6:
                        {
                            oderQuerry = CT_Sort2_Den_Odr;
                            break;
                        }
                    default:
                        {
                            oderQuerry = CT_Sort1_Den_Odr;
                            break;
                        }
                }
                // <<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD

                //>>>> 2008/12/02 G.Miyatsu DEL
                //oderQuerry = CT_Sort_Den_Odr;
			}
			//明細形式 詳細形式
			else
			{
				switch (this._csStockConfPara.SortOrder)
				{
					case 0:
						{
							oderQuerry = CT_Sort1_Odr;
							break;
						}
					case 1:
						{
							oderQuerry = CT_Sort2_Odr;
							break;
						}
					case 2:
						{
							oderQuerry = CT_Sort3_Odr;
							break;
						}
					case 3:
						{
							oderQuerry = CT_Sort4_Odr;
							break;
						}
					case 4:
						{
							oderQuerry = CT_Sort5_Odr;
							break;
						}
                    case 5:
                        {
                            oderQuerry = CT_Sort6_Odr;
                            break;
                        }
                    case 6:
                        {
                            oderQuerry = CT_Sort7_Odr;
                            break;
                        }
                    case 7:
                        {
                            oderQuerry = CT_Sort8_Odr;
                            break;
                        }
				}
			}
			
			return oderQuerry;
		}
		#endregion
		
		#region ◆　メッセージ表示処理
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
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAKON02243P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}
