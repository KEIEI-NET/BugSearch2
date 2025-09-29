//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上確認表
// プログラム概要   : 売上確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/07/08  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/12  修正内容 : 障害対応13453
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
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 売上確認表 印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上確認表の印刷クラスです</br>
    /// <br>Programer  : 30413 犬飼</br>
    /// <br>Date       : 2008.07.08</br>
    /// </remarks>
    public class MAHNB02343PA
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
        /// <summary>
        /// 売上確認表 印刷クラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクター</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        public MAHNB02343PA()
		{
		}
        /// <summary>
        /// 売上確認表 印刷クラス静的コンストラクター
        /// </summary>
        /// <param name="printInfo">印刷情報</param>
        /// <remarks>
        /// <br>Note       : コンストラクター</br>
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        public MAHNB02343PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._csSaleOrderPara = this._printInfo.jyoken as ExtrInfo_MAHNB02347E;

            this.SelectTableName();

         }
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "　";

		#endregion
		
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// 帳票系共通部品
        private ExtrInfo_MAHNB02347E _csSaleOrderPara = null;
        #endregion

        // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>表示順位</summary>
        //private string CT_Sort1_Odr = "SectionCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                               // 売上日→伝票番号
        //private string CT_Sort2_Odr = "SectionCodeRF, SalesDateRF, CustomerCodeRF, SalesFormCodeRF, GoodsCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF"; // 売上日→得意先→販売形態→商品→伝票番号
        //private string CT_Sort3_Odr = "SectionCodeRF, SalesDateRF, CustomerCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                               // 売上日→得意先→伝票番号
        //private string CT_Sort4_Odr = "SectionCodeRF, SalesFormCodeRF, CustomerCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";              // 販売形態→得意先→売上日→伝票番号
        //private string CT_Sort5_Odr = "SectionCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                                            // 伝票番号

        //private string CT_Sort1_OdrStr = "売上日→伝票番号";
        //private string CT_Sort2_OdrStr = "売上日→得意先→販売形態→商品→伝票番号";
        //private string CT_Sort3_OdrStr = "売上日→得意先→伝票番号";
        //private string CT_Sort4_OdrStr = "販売形態→得意先→売上日→伝票番号";
        //private string CT_Sort5_OdrStr = "伝票番号";
        // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 2008.07.08 30413 犬飼 出力順のプロパティ変更 >>>>>>START
        // ↓ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private string CT_Sort1_Odr = "SectionCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF";                                 // 売上日+伝票番号
        //private string CT_Sort2_Odr = "SectionCodeRF, CustomerCodeRF, SalesDateRF, SalesSlipNumRF"; 　                            // 得意先+売上日+伝票番号
        //private string CT_Sort3_Odr = "SectionCodeRF, SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";                            // 入力日+伝票番号
        //private string CT_Sort4_Odr = "SectionCodeRF, CustomerCodeRF, SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";            // 得意先+入力日+伝票番号
        //private string CT_Sort5_Odr = "SectionCodeRF, SalesEmployeeNmRF, SalesSlipNumRF, SalesRowNoRF";                           // 担当者+伝票番号
        //private string CT_Sort6_Odr = "SectionCodeRF, SalesAreaCodeRF, SalesSlipNumRF, SalesRowNoRF";                             // 地区+伝票番号

        //private string CT_Sort1_OdrStr = "売上日+伝票番号";
        //private string CT_Sort2_OdrStr = "得意先+売上日+伝票番号";
        //private string CT_Sort3_OdrStr = "入力日+伝票番号";
        //private string CT_Sort4_OdrStr = "得意先+入力日+伝票番号";
        //private string CT_Sort5_OdrStr = "担当者+伝票番号";
        //private string CT_Sort6_OdrStr = "販売エリア+伝票番号";
        // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private string CT_Sort1_Odr = "SectionCode, SalesDate, SalesSlipNum, SalesRowNo";                               // 拠点+売上日+伝票番号+伝票行番号
        private string CT_Sort2_Odr = "SectionCode, CustomerCode, SalesDate, SalesSlipNum, SalesRowNo"; 　              // 拠点+得意先+売上日+伝票番号+伝票行番号
        private string CT_Sort3_Odr = "SectionCode, SearchSlipDate, SalesSlipNum, SalesRowNo";                          // 拠点+入力日+伝票番号+伝票行番号
        private string CT_Sort4_Odr = "SectionCode, CustomerCode, SearchSlipDate, SalesSlipNum, SalesRowNo";            // 拠点+得意先+入力日+伝票番号+伝票行番号
        // 2009.01.26 30413 犬飼 担当者名→担当者コードに修正 >>>>>>START
        //private string CT_Sort5_Odr = "SectionCode, SalesEmployeeNm, SalesSlipNum, SalesRowNo";                         // 拠点+担当者+伝票番号+伝票行番号
        private string CT_Sort5_Odr = "SectionCode, SalesEmployeeCd, SalesSlipNum, SalesRowNo";                         // 拠点+担当者+伝票番号+伝票行番号
        // 2009.01.26 30413 犬飼 担当者名→担当者コードに修正 <<<<<<END
        private string CT_Sort6_Odr = "SectionCode, SalesAreaCode, SalesSlipNum, SalesRowNo";                           // 拠点+地区(販売エリア)+伝票番号+伝票行番号
        private string CT_Sort7_Odr = "SectionCode, BusinessTypeCode, SalesSlipNum, SalesRowNo";                        // 拠点+業種+伝票番号+伝票行番号
        // ADD 2009/06/12 ------>>>
        private string CT_Sort8_Odr = "SectionCode, SalesSlipNum, SalesRowNo";                                          // 拠点+伝票番号+伝票行番号
        // ADD 2009/06/12 ------<<<
        
        private string CT_Sort1_OdrStr = "売上日+伝票番号";
        private string CT_Sort2_OdrStr = "得意先+売上日+伝票番号";
        private string CT_Sort3_OdrStr = "入力日+伝票番号";
        private string CT_Sort4_OdrStr = "得意先+入力日+伝票番号";
        private string CT_Sort5_OdrStr = "担当者+伝票番号";
        private string CT_Sort6_OdrStr = "地区+伝票番号";
        private string CT_Sort7_OdrStr = "業種+伝票番号";
        // ADD 2009/06/12 ------>>>
        private string CT_Sort8_OdrStr = "伝票番号";
        // ADD 2009/06/12 ------<<<
        // 2008.07.08 30413 犬飼 出力順を追加 <<<<<<END
        
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
                                // 2007.05.23 modified by T-Kidate : PDF履歴管理部品の初期化処理の追加
                                //// 出力履歴管理に追加
                                //this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "売上確認表", this._printInfo.prpnm,
                                //    this._printInfo.pdftemppath);

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
            //if(this._csSaleOrderPara.IsDetails == true)
            //{
                // 明細単位
                ct_TableName = MAHNB02349EA.CT_SalesConfDataTable;
            //}
            //else
            //{
            //    // 拠点別
            //    ct_TableName = MAHNB02349EB.CT_SalesOrderSectionDataTable;
            //}

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


            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;

            int st = SaleConfAcs.ReadPrtOutSet(out prtOutSet, out message);

            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // ↓ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////
            // 粗利チェック範囲(コントロールに値がある場合に出力)
            if ((this._csSaleOrderPara.GrsProfitCheckLower != 0) && (this._csSaleOrderPara.GrsProfitCheckBest != 0))
            {
                if (this._csSaleOrderPara.GrsProfitCheckUpper != 0)
                {
                    string makegrossmargin = "";
                    this.MakeGrossMargin(out makegrossmargin);

                    instance.PageHeaderSubtitle = makegrossmargin;
                }
            }

            // 出力順
            string target = "";
            this.SortTilte(out target);

            instance.PageHeaderSortOderTitle = target;
            // ↑ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////

            // ↓ 2008.03.04 Keigo Yata Add ///////////////////////////////////////////////////
            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // ↑ 2008.03.04 Keigo Yata Add ///////////////////////////////////////////////////

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
		}
		#endregion

        // ↓ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////
        // 粗利率の値を入力するコントロールを6つ入力できるところを3つに変更
        #region ◆　粗利チェックリスト範囲作成処理
        /// <summary>
        /// 粗利チェックリスト範囲情報作成
        /// 下記のComentoutはすべてのコントロールが入力可能な時の粗利範囲を出力するコード
        /// </summary>
        /// <param name="makeGrossMargin">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成します。</br>
        /// <br>Programmer : 矢田 敬吾</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private void MakeGrossMargin(out string makeGrossMargin)
        {
            makeGrossMargin  = "";
            string stTarget  = "";
            string stTarget1 = "";
            string stTarget2 = "";

            string edTarget  = "";
            string edTarget1 = "";
            string edTarget2 = "";

            string markTarget  = "";
            string markTarget1 = "";
            string markTarget2 = "";
            string markTarget3 = "";


            //if(this._csSaleOrderPara.GrossMarginSt != 0)
            //{
            //    stTarget  = this._csSaleOrderPara.GrossMarginSt + " ％ 未満";
            //    markTarget = this._csSaleOrderPara.GrossMargin1Mark;
            //    makeGrossMargin = stTarget+":"+markTarget;
            //}


            //if ((this._csSaleOrderPara.GrossMarginSt != 0) && (this._csSaleOrderPara.GrsProfitCheckLower != 0))
            //{
            //    stTarget  = this._csSaleOrderPara.GrossMarginSt + " ％ 未満";
            //    markTarget = this._csSaleOrderPara.GrossMargin1Mark;
                
            //    stTarget1   = this._csSaleOrderPara.GrsProfitCheckLower + " ％ 以上～ ";
            //    edTarget    = this._csSaleOrderPara.GrossMargin2Ed + " ％ 未満 ";
            //    markTarget1 = this._csSaleOrderPara.GrossMargin2Mark;

            //    makeGrossMargin = stTarget + ":" + markTarget + "  " + stTarget1 + edTarget + ":"+ markTarget1;

            //}

            
            //if ((this._csSaleOrderPara.GrsProfitCheckLower != 0) && (this._csSaleOrderPara.GrsProfitCheckBest != 0))
            //{
            //    stTarget    = this._csSaleOrderPara.GrossMarginSt + " ％ 未満";
            //    markTarget  = this._csSaleOrderPara.GrossMargin1Mark;

            //    stTarget1   = this._csSaleOrderPara.GrsProfitCheckLower + " ％ 以上～ ";
            //    edTarget    = this._csSaleOrderPara.GrossMargin2Ed + " ％ 未満 ";
            //    markTarget1 = this._csSaleOrderPara.GrossMargin2Mark;

            //    stTarget2   = this._csSaleOrderPara.GrsProfitCheckBest + " ％ 以上～ ";
            //    edTarget1   = this._csSaleOrderPara.GrossMargin3Ed     + " ％ 未満 ";
            //    markTarget2 = this._csSaleOrderPara.GrossMargin3Mark;

            //    makeGrossMargin = stTarget + ":" + markTarget + "  " + stTarget1 + edTarget + ":" + markTarget1
            //                      + "   " + stTarget2 + edTarget1 + ":" + markTarget2;

            //}

            if(this._csSaleOrderPara.GrsProfitCheckLower != 0)
            {
                if((this._csSaleOrderPara.GrsProfitCheckBest!= 0) && (this._csSaleOrderPara.GrsProfitCheckUpper != 0))
                {
                    stTarget   = this._csSaleOrderPara.GrossMarginSt + " ％ 未満";
                    markTarget = this._csSaleOrderPara.GrossMargin1Mark;
                    
                    stTarget1   = this._csSaleOrderPara.GrsProfitCheckLower + " ％ 以上  ～ ";
                    edTarget = this._csSaleOrderPara.GrossMargin2Ed + " ％ 未満 ";
                    markTarget1 = this._csSaleOrderPara.GrossMargin2Mark;

                    stTarget2   = this._csSaleOrderPara.GrsProfitCheckBest + " ％ 以上  ～ ";
                    edTarget1   = this._csSaleOrderPara.GrossMargin3Ed     + " ％ 未満 ";
                    markTarget2 = this._csSaleOrderPara.GrossMargin3Mark;
                    
                    edTarget2   = this._csSaleOrderPara.GrossMargin3Ed + " ％ 以上 ";
                    markTarget3 = this._csSaleOrderPara.GrossMargin4Mark;
                    
                    makeGrossMargin = stTarget + ":" + markTarget + "  " + stTarget1 + edTarget + ":" + markTarget1
                                  + "   " + stTarget2 + edTarget1 + ":" + markTarget2 + "   " + edTarget2 + ":"
                                  + markTarget3;
                }

            }

            //if ((this._csSaleOrderPara.GrsProfitCheckUpper != 0) && (this._csSaleOrderPara.GrsProfitCheckBest == 0))
            //{
            //    if ((this._csSaleOrderPara.GrossMarginSt == 0) && (this._csSaleOrderPara.GrsProfitCheckLower == 0))
            //    {
            //        stTarget = this._csSaleOrderPara.GrsProfitCheckUpper + " ％ 以上";
            //        markTarget = this._csSaleOrderPara.GrossMargin4Mark;

            //        makeGrossMargin = stTarget + ":" + markTarget;
            //    }
            //}



            //if ((this._csSaleOrderPara.GrossMarginSt == 0) && (this._csSaleOrderPara.GrsProfitCheckBest == 0))
            //{
            //    if ((this._csSaleOrderPara.GrsProfitCheckUpper == 0))
            //    {
            //        stTarget = this._csSaleOrderPara.GrsProfitCheckLower + " ％ 以上 ";
            //        edTarget = this._csSaleOrderPara.GrossMargin2Ed + " ％ 未満 ";
            //        markTarget = this._csSaleOrderPara.GrossMargin2Mark;

            //        makeGrossMargin = stTarget + edTarget + ":" + markTarget;
            //    }
            //}




            //if ((this._csSaleOrderPara.GrossMarginSt == 0) && (this._csSaleOrderPara.GrsProfitCheckUpper == 0))
            //{
            //    if ((this._csSaleOrderPara.GrsProfitCheckLower != 0) && (this._csSaleOrderPara.GrsProfitCheckBest != 0))
            //    {
            //        stTarget = this._csSaleOrderPara.GrsProfitCheckLower + " ％ 以上～ ";
            //        edTarget = this._csSaleOrderPara.GrossMargin2Ed + " ％ 未満 ";
            //        markTarget = this._csSaleOrderPara.GrossMargin2Mark;

            //        stTarget1 = this._csSaleOrderPara.GrsProfitCheckBest + " ％ 以上～ ";
            //        edTarget1 = this._csSaleOrderPara.GrossMargin3Ed + " ％ 未満 ";
            //        markTarget1 = this._csSaleOrderPara.GrossMargin3Mark;

            //        makeGrossMargin = stTarget + edTarget + ":" + markTarget + "    " + stTarget1 + edTarget1 + ":" + markTarget1;
            //    }
            //}



        }

        #endregion

        #region ◆　出力順の作成
        /// <summary>
        /// 出力順の作成
        /// </summary>
        /// <param name="target">出力順の文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する文字列を作成します。</br>
        /// <br>Programmer : 矢田 敬吾</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private void SortTilte(out string target)
        {
       
            string wrkstr = "";

            switch (this._csSaleOrderPara.SortOrder)
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
                        wrkstr = CT_Sort6_OdrStr;
                        break;
                    }
                // 2008.07.08 30413 犬飼 出力順を追加 >>>>>>START
                case 6:
                    {
                        wrkstr = CT_Sort7_OdrStr;
                        break;
                    }
                // 2008.07.08 30413 犬飼 出力順を追加 <<<<<<END
                // ADD 2009/06/12 ------>>>
                case 7:
                    {
                        wrkstr = CT_Sort8_OdrStr;
                        break;
                    }
                // ADD 2009/06/12 ------<<<
            }

            target = "[ソート順：" + wrkstr + "]";
            

        }

        #endregion
        // ↑ 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////

        #region ◆　抽出条件ヘッダー作成処理

        // 2008.07.17 30413 犬飼 コメント化 >>>>>>START
        #region 抽出条件出力情報作成
        ///// <summary>
        ///// 抽出条件出力情報作成
        ///// </summary>
        ///// <param name="extraConditions">作成後抽出条件コレクション</param>
        ///// <remarks>
        ///// <br>Note       : 出力する抽出条件文字列を作成します。</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2005.11.15</br>
        ///// </remarks>
        //private void MakeExtarCondition(out StringCollection extraConditions)
        //{
        //    // 抽出条件ヘッダー項目
        //    extraConditions = new StringCollection();
			
        //    // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////
        //    //// 対象期間
        //    //string target = "";
        //    //string stTarget = "";
        //    //string edTarget = "";
        //    //string wrkstr = "";
        //    //wrkstr = "";

        //    //stTarget = "対象期間： " + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SalesDateSt);
        //    //edTarget = "  ～　" + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SalesDateEd);

        //    //target = stTarget + edTarget;

        //    //this.EditCondition(ref extraConditions, target);
        //    // ↑ 2007.11.08 Keigo Yata Delete //////////////////////////////////////////////////////////////////////////////



        //    // ↓ 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////
        //    // 入力日

        //    string target = "";
        //    //string stTarget = "";
        //    //string edTarget = "";
        //    string wrkstr = "";
        //    wrkstr = "";


        //    //if ((this._csSaleOrderPara.SearchSlipDataSt != 0) && (this._csSaleOrderPara.SearchSlipDataEd != 0))
        //    //{
        //    //    stTarget = "入力日  " + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SearchSlipDataSt);
        //    //    edTarget = "  ～　" + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SearchSlipDataEd);
        //    //    target = stTarget + edTarget;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}
        //    // ↑ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////////////


        //    // ↓ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////
        //    // 出力単位
        //    //target = "出力単位：";
        //    //if (this._csSaleOrderPara.IsDetails == true)
        //    //{
        //    //    target += "伝票明細単位";
        //    //}
        //    //else
        //    //{
        //    //    target += "製造番号単位";
        //    //}
        //    //this.EditCondition(ref extraConditions, target);

        //    // キャリア
        //    //target = "";
        //    //foreach (string s in this._csSaleOrderPara.CarrierNameList)
        //    //{
        //    //    if (wrkstr != "") wrkstr += "・" + s;
        //    //    else wrkstr = s;
        //    //}
        //    //target = "キャリア：" + wrkstr;
        //    //this.EditCondition(ref extraConditions, target);

        //    // 売上形式
        //    //wrkstr = "";
        //    //target = "";
        //    //foreach (string s in this._csSaleOrderPara.SalesFormalList)
        //    //{
        //    //    if (wrkstr != "") wrkstr += "・" + s;
        //    //    else wrkstr = s;
        //    //}
        //    //target = "売上形式：" + wrkstr;
        //    //this.EditCondition(ref extraConditions, target);

        //    // 販売形態
        //    //wrkstr = "";
        //    //target = "";
        //    //foreach (string s in this._csSaleOrderPara.SalesFormList)
        //    //{
        //    //    if (wrkstr != "") wrkstr += "・" + s;
        //    //    else wrkstr = s;
        //    //}
        //    //target = "販売形態：" + wrkstr;
        //    //this.EditCondition(ref extraConditions, target);

        //    // ソート順
        //    //wrkstr = "";
        //    //target = "";
        //    //switch (this._csSaleOrderPara.SortOrder)
        //    //{
        //    //    case 0:
        //    //        {
        //    //            wrkstr = CT_Sort1_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 1:
        //    //        {
        //    //            wrkstr = CT_Sort2_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 2:
        //    //        {
        //    //            wrkstr = CT_Sort3_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 3:
        //    //        {
        //    //            wrkstr = CT_Sort4_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 4:
        //    //        {
        //    //            wrkstr = CT_Sort5_OdrStr;
        //    //            break;
        //    //        }
        //    //}
        //    // ↑ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////

        //    // ↓ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////////////
        //    // ソート順
        //    wrkstr = "";
        //    target = "";
        //    switch (this._csSaleOrderPara.SortOrder)
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
        //        case 5:
        //            {
        //                wrkstr = CT_Sort6_OdrStr;
        //                break;
        //            }
        //    }
        //    // ↑ 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////////////

        //    //target = "ソート順：" + wrkstr + " 順";
        //    //this.EditCondition(ref extraConditions, target);

        //    // ↓ 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////////////////////////////
        //    //// 商品区分グループ
        //    //if (this._csSaleOrderPara.LargeGoodsGanreCdSt != "")
        //    //{
        //    //    target = "商品区分グループ: " + this._csSaleOrderPara.LargeGoodsGanreCdSt + " ～ " + this._csSaleOrderPara.LargeGoodsGanreCdEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}

        //    //// 商品区分
        //    //if (this._csSaleOrderPara.MediumGoodsGanreCdEd != "")
        //    //{
        //    //    target = "商品区分: " + this._csSaleOrderPara.MediumGoodsGanreCdSt + " ～ " + this._csSaleOrderPara.MediumGoodsGanreCdEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}

        //    //// 機種コード
        //    //if (this._csSaleOrderPara.CellphoneModelCodeEd != "")
        //    //{
        //    //    target = "機種コード: " + this._csSaleOrderPara.CellphoneModelCodeSt + " ～ " + this._csSaleOrderPara.CellphoneModelCodeEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}
        //    // ↑ 2007.11.08 Keigo Yata Delete //////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // ↓ 2007.11.08 Keigo Yata Change /////////////////////////////////////////////////////////////////////////////////////////////////////
        //    // 商品コード
        //    //if (this._csSaleOrderPara.GoodsCodeEd != "")
        //    //{
        //    //    target = "商品コード: " + this._csSaleOrderPara.GoodsCodeSt + " ～ " + this._csSaleOrderPara.GoodsCodeEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}
        //    // ↑ 2007.11.08 Keigo Yata Change /////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // ↓ 2007.11.15 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // 得意先--------------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.CustomerCodeSt == 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
        //    {
        //        target = "得意先: " + "最初から" + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString();
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd == 0))
        //    {
        //        target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ " + "最後まで";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
        //    {
        //        target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString();
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------

        //    // 伝票区分------------------------------------------------------------------------------------------------------------------------------
        //    switch (this._csSaleOrderPara.SalesSlipCd)
        //    {
        //        case -1:
        //            {
        //                target = "伝票区分： 全て";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 0:
        //            {
        //                target = "伝票区分： 売上";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 1:
        //            {
        //                target = "伝票区分： 返品";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //    }

        //    switch (this._csSaleOrderPara.DebitNoteDiv)
        //    {
        //        case -1:
        //            {
        //                target = "赤伝区分： 全て";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 0:
        //            {
        //                target = "赤伝区分： 黒伝";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 1:
        //            {
        //                target = "赤伝区分： 赤伝";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 2:
        //            {
        //                target = "赤伝区分： 元黒";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------
        //    // ↑ 2007.11.15 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // ↓ 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // 入力者コード--------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.SalesInputCodeSt == "") && (this._csSaleOrderPara.SalesInputCodeEd != ""))
        //    {
        //        target = "入力者コード: " + "最初から" + " ～ " + this._csSaleOrderPara.SalesInputCodeEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
            
        //    if ((this._csSaleOrderPara.SalesInputCodeSt != "")&&(this._csSaleOrderPara.SalesInputCodeEd == ""))
        //    {
        //        target = "入力者コード: " + this._csSaleOrderPara.SalesInputCodeSt + " ～ " + "最後まで";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesInputCodeSt != "")&&(this._csSaleOrderPara.SalesInputCodeEd != ""))
        //    {
        //        target = "入力者コード: " + this._csSaleOrderPara.SalesInputCodeSt + " ～ " + this._csSaleOrderPara.SalesInputCodeEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------
        //    // ↑ 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////

            
        //    // 担当者コード--------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd == ""))
        //    {
        //        target = "担当者コード: " + this._csSaleOrderPara.SalesEmployeeCdSt + " ～ " + "最後まで";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesEmployeeCdSt == "")&&(this._csSaleOrderPara.SalesEmployeeCdEd != ""))
        //    {
        //        target = "担当者コード: " + "最初から" + " ～ " + this._csSaleOrderPara.SalesEmployeeCdEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
        //    {
        //        target = "担当者コード: " + this._csSaleOrderPara.SalesEmployeeCdSt + " ～ " + this._csSaleOrderPara.SalesEmployeeCdEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------

        //    // 伝票番号------------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.SalesSlipNumSt != "")&&(this._csSaleOrderPara.SalesSlipNumEd == ""))
        //    {
        //        target = "伝票番号: " + this._csSaleOrderPara.SalesSlipNumSt + " ～ "  + "最後まで";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesSlipNumSt == "") && (this._csSaleOrderPara.SalesSlipNumEd != ""))
        //    {
        //        target = "伝票番号: " + "最初から" + " ～ " + this._csSaleOrderPara.SalesSlipNumEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesSlipNumSt != "")&&(this._csSaleOrderPara.SalesSlipNumEd != ""))
        //    {
        //        target = "伝票番号: " + this._csSaleOrderPara.SalesSlipNumSt + " ～ " + this._csSaleOrderPara.SalesSlipNumEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------

        //}
        #endregion
        // 2008.07.17 30413 犬飼 コメント化 <<<<<<END

        #region 抽出条件出力情報作成
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            // 抽出条件ヘッダー項目
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            
            const string ct_RangeConst = "：{0} ～ {1}";
            const string ct_DateFormat = "YYYY/MM/DD";
            const string ct_Extr_Top = "最初から";
            const string ct_Extr_End = "最後まで";

            string target = "";

            // 売上日
            if ((this._csSaleOrderPara.SalesDateSt != 0) || (this._csSaleOrderPara.SalesDateEd != 0))
            {
                string st_SalesDate = string.Empty;
                string ed_SalesDate = string.Empty;
                // 開始
                if (this._csSaleOrderPara.SalesDateSt != 0)
                    st_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SalesDateSt);
                else
                    st_SalesDate = ct_Extr_Top;
                // 終了
                if (this._csSaleOrderPara.SalesDateEd != 0)
                    ed_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SalesDateEd);
                else
                    ed_SalesDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("売上日　" + ct_RangeConst, st_SalesDate, ed_SalesDate));
            }

            // 入力日
            if ((this._csSaleOrderPara.SearchSlipDateSt != 0) || (this._csSaleOrderPara.SearchSlipDateEd != 0))
            {
                string st_SalesDate = string.Empty;
                string ed_SalesDate = string.Empty;
                // 開始
                if (this._csSaleOrderPara.SearchSlipDateSt != 0)
                    st_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SearchSlipDateSt);
                else
                    st_SalesDate = ct_Extr_Top;
                // 終了
                if (this._csSaleOrderPara.SearchSlipDateEd != 0)
                    ed_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SearchSlipDateEd);
                else
                    ed_SalesDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("入力日　" + ct_RangeConst, st_SalesDate, ed_SalesDate));
            }

            // 発行者
            if ((this._csSaleOrderPara.SalesInputCodeSt == "") && (this._csSaleOrderPara.SalesInputCodeEd != ""))
            {
                target = "発行者: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.SalesInputCodeEd;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesInputCodeSt != "") && (this._csSaleOrderPara.SalesInputCodeEd == ""))
            {
                target = "発行者: " + this._csSaleOrderPara.SalesInputCodeSt + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesInputCodeSt != "") && (this._csSaleOrderPara.SalesInputCodeEd != ""))
            {
                target = "発行者: " + this._csSaleOrderPara.SalesInputCodeSt + " ～ " + this._csSaleOrderPara.SalesInputCodeEd;
                this.EditCondition(ref addConditions, target);
            }

            // 担当者
            if ((this._csSaleOrderPara.SalesEmployeeCdSt == "") && (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
            {
                target = "担当者: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.SalesEmployeeCdEd.ToString();
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd == ""))
            {
                target = "担当者: " + this._csSaleOrderPara.SalesEmployeeCdSt.ToString() + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
            {
                target = "担当者: " + this._csSaleOrderPara.SalesEmployeeCdSt + " ～ " + this._csSaleOrderPara.SalesEmployeeCdEd;
                this.EditCondition(ref addConditions, target);
            }

            // 地区
            if ((this._csSaleOrderPara.SalesAreaCodeSt == 0) && (this._csSaleOrderPara.SalesAreaCodeEd != 0))
            {
                target = "地区: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesAreaCodeSt > 0) && (this._csSaleOrderPara.SalesAreaCodeEd == 0))
            {
                target = "地区: " + this._csSaleOrderPara.SalesAreaCodeSt.ToString("d04") + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesAreaCodeSt > 0) && (this._csSaleOrderPara.SalesAreaCodeEd != 0))
            {
                target = "地区: " + this._csSaleOrderPara.SalesAreaCodeSt.ToString("d04") + " ～ " + this._csSaleOrderPara.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // 業種
            if ((this._csSaleOrderPara.BusinessTypeCodeSt == 0) && (this._csSaleOrderPara.BusinessTypeCodeEd != 0))
            {
                target = "業種: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.BusinessTypeCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.BusinessTypeCodeSt > 0) && (this._csSaleOrderPara.BusinessTypeCodeEd == 0))
            {
                target = "業種: " + this._csSaleOrderPara.BusinessTypeCodeSt.ToString("d04") + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.BusinessTypeCodeSt > 0) && (this._csSaleOrderPara.BusinessTypeCodeEd != 0))
            {
                target = "業種: " + this._csSaleOrderPara.BusinessTypeCodeSt.ToString("d04") + " ～ " + this._csSaleOrderPara.BusinessTypeCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // 得意先
            if ((this._csSaleOrderPara.CustomerCodeSt == 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = "得意先: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd == 0))
            {
                target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString("d08") + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString("d08") + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, target);
            }

            // 仕入先
            if ((this._csSaleOrderPara.SupplierCdSt == 0) && (this._csSaleOrderPara.SupplierCdEd != 0))
            {
                target = "仕入先: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.SupplierCdEd.ToString("d06");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SupplierCdSt > 0) && (this._csSaleOrderPara.SupplierCdEd == 0))
            {
                target = "仕入先: " + this._csSaleOrderPara.SupplierCdSt.ToString("d06") + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SupplierCdSt > 0) && (this._csSaleOrderPara.SupplierCdEd != 0))
            {
                target = "仕入先: " + this._csSaleOrderPara.SupplierCdSt.ToString("d06") + " ～ " + this._csSaleOrderPara.SupplierCdEd.ToString("d06");
                this.EditCondition(ref addConditions, target);
            }

            // 伝票番号
            if ((this._csSaleOrderPara.SalesSlipNumSt != "") && (this._csSaleOrderPara.SalesSlipNumEd == ""))
            {
                target = "伝票番号: " + this._csSaleOrderPara.SalesSlipNumSt + " ～ " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesSlipNumSt == "") && (this._csSaleOrderPara.SalesSlipNumEd != ""))
            {
                target = "伝票番号: " + ct_Extr_Top + " ～ " + this._csSaleOrderPara.SalesSlipNumEd;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesSlipNumSt != "") && (this._csSaleOrderPara.SalesSlipNumEd != ""))
            {
                target = "伝票番号: " + this._csSaleOrderPara.SalesSlipNumSt + " ～ " + this._csSaleOrderPara.SalesSlipNumEd;
                this.EditCondition(ref addConditions, target);
            }

            // 伝票区分
            switch (this._csSaleOrderPara.SalesSlipCd)
            {
                case -1:
                    {
                        target = "伝票区分： 全て";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "伝票区分： 売上";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 1:
                    {
                        target = "伝票区分： 返品";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 2:
                    {
                        target = "伝票区分： 返品+値引き";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }

            // 赤伝区分
            switch (this._csSaleOrderPara.DebitNoteDiv)
            {
                case -1:
                    {
                        target = "赤伝区分： 全て";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "赤伝区分： 黒伝";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 1:
                    {
                        target = "赤伝区分： 赤伝";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 2:
                    {
                        target = "赤伝区分： 元黒";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }

            // 発行タイプ
            if ((this._csSaleOrderPara.SalesSlipUpdateCd == -1) && (this._csSaleOrderPara.LogicalDeleteCode == 0))
            {
                target = "発行タイプ： 通常";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesSlipUpdateCd == 1) && (this._csSaleOrderPara.LogicalDeleteCode == 0))
            {
                target = "発行タイプ： 訂正";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesSlipUpdateCd == -1) && (this._csSaleOrderPara.LogicalDeleteCode == 1))
            {
                target = "発行タイプ： 削除";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesSlipUpdateCd == 1) && (this._csSaleOrderPara.LogicalDeleteCode == 1))
            {
                target = "発行タイプ： 訂正＋削除";
                this.EditCondition(ref addConditions, target);
            }

            // 出力指定
            if ((this._csSaleOrderPara.SalesOrderDivCd == -1) && (this._csSaleOrderPara.WayToOrder == -1))
            {
                target = "出力指定： 全て";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesOrderDivCd == 1) && (this._csSaleOrderPara.WayToOrder == -1))
            {
                target = "出力指定： 在庫";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesOrderDivCd == 0) && (this._csSaleOrderPara.WayToOrder == -1))
            {
                target = "出力指定： 取寄";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesOrderDivCd == -1) && (this._csSaleOrderPara.WayToOrder == 2))
            {
                target = "出力指定： UOE";
                this.EditCondition(ref addConditions, target);
            }

            // 指定条件のみ印刷
            // 売価ゼロ
            if (this._csSaleOrderPara.ZeroSalesPrint == 1)
            {
                target = "売価ゼロのみ印字";
                this.EditCondition(ref addConditions, target);
            }
            // 原価ゼロ
            if (this._csSaleOrderPara.ZeroCostPrint == 1)
            {
                target = "原価ゼロのみ印字";
                this.EditCondition(ref addConditions, target);
            }
            // 粗利ゼロ
            if (this._csSaleOrderPara.ZeroGrsProfitPrint == 1)
            {
                target = "粗利ゼロのみ印字";
                this.EditCondition(ref addConditions, target);
            }
            // 粗利ゼロ以下
            if (this._csSaleOrderPara.ZeroUdrGrsProfitPrint == 1)
            {
                target = "粗利ゼロ以下のみ印字";
                this.EditCondition(ref addConditions, target);
            }
            // 粗利率
            if (this._csSaleOrderPara.GrsProfitRatePrint == 1)
            {
                if (this._csSaleOrderPara.GrsProfitRatePrintDiv == 0)
                {
                    target = "粗利率： " + this._csSaleOrderPara.GrsProfitRatePrintVal.ToString() + "％以下";
                }
                else
                {
                    target = "粗利率： " + this._csSaleOrderPara.GrsProfitRatePrintVal.ToString() + "％以上";
                }
                this.EditCondition(ref addConditions, target);
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
            
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

            // 2008.09.17 30413 犬飼 抽出条件を適宜改行するように修正 >>>>>>START
            // 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS(target);
			
            //for (int i = 0; i < editArea.Count; i++)
            //{
            //    int areaByte = 0;
				
				
            //    // 格納エリアのバイト数算出
            //    if (editArea[i] != null)
            //    {
            //        areaByte = TStrConv.SizeCountSJIS(editArea[i]);
            //    }

            //    if ((areaByte + targetByte + 2) <= 220)
            //    {
            //        isEdit = true;

            //        // 全角スペースを挿入
            //        if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;
					
            //        editArea[i]  += target;
            //        break;
            //    }
            //}

            int index = 0;
            int areaByte = 0;
            
            // 追加するエリアのインデックスを取得
            if (editArea.Count != 0)
            {
                index = editArea.Count - 1;

                // 格納エリアのバイト数算出
                if (editArea[index] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[index]);
                }

                if ((areaByte + targetByte + 2) >= 140)
                {
                    // 改行
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[index] != null) editArea[index] += CT_ITEM_INTERVAL;

                    editArea[index] += target;
                }
            }
            // 2008.09.17 30413 犬飼 抽出条件を適宜改行するように修正 <<<<<<END
            
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
            commonInfo.PrintName = this._printInfo.prpnm;

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
		

		// ↓ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////
        #region ◆　印刷順クエリ作成関数
        ///// <summary>
        ///// 印字順クエリ作成処理
        ///// </summary>
        ///// <returns>作成したクエリ</returns>
        ///// <remarks>
        ///// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2005.12.06</br>
        ///// </remarks>
        //private string GetPrintOderQuerry()
        //{
        //    string oderQuerry = "";

        //    switch (this._csSaleOrderPara.SortOrder)
        //    {
        //        case 0:
        //            {
        //                oderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 1:
        //            {
        //                oderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
        //                oderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
        //                oderQuerry = CT_Sort4_Odr;
        //                break;
        //            }
        //        case 4:
        //            {
        //                oderQuerry = CT_Sort5_Odr;
        //                break;
        //            }

        //    }
			
        //    return oderQuerry;
        //}
        #endregion
        // ↑ 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////

        // ↓ 2007.11.08 Keigo Yata Add //////////////////////////////////////////////////////////////////
        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 矢田 敬吾</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._csSaleOrderPara.SortOrder)
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
                // 2008.07.08 30413 犬飼 出力順を追加 >>>>>>START
                case 6:
                    {
                        oderQuerry = CT_Sort7_Odr;
                        break;
                    }
                // 2008.07.08 30413 犬飼 出力順を追加 <<<<<<END
                // ADD 2009/06/12 ------>>>
                case 7:
                    {
                        oderQuerry = CT_Sort8_Odr;
                        break;
                    }
                // ADD 2009/06/12 ------<<<
            }

            return oderQuerry;
        }
        // ↑ 2007.11.08 Keigo Yata Add //////////////////////////////////////////////////////////////////
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
			return TMsgDisp.Show(iLevel, "MAHNB02343P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}
