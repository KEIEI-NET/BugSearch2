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
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

using Broadleaf.Application.Remoting.ParamData;
using DataDynamics.ActiveReports;

namespace Broadleaf.Drawing.Printing
{
    /// public class name:   DCHNB02012PA
    /// <summary>
    ///                      受注・貸出確認表印刷クラス
    /// </summary>
    /// <remarks>
    /// 受注・貸出確認表印刷クラス
    /// </remarks>
    public class DCHNB02012PA
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
        /// <summary>
        /// 受注・貸出確認表印刷クラスコンストラクター
        /// </summary>
        public DCHNB02012PA()
		{
		}

        /// <summary>
        /// 受注・貸出確認表印刷クラスコンストラクター
        /// </summary>
        public DCHNB02012PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._csSaleOrderPara = this._printInfo.jyoken as ExtrInfo_DCHNB02013E;

            this.SelectTableName();

        }
		#endregion

		//================================================================================
		//  内部定数
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "　";

        // 2008.08.01 30413 犬飼 抽出条件の定数追加 >>>>>>START
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        private const string ct_RangeConst = "：{0} ～ {1}";
        // 2008.08.01 30413 犬飼 抽出条件の定数追加 <<<<<<END
        
		#endregion
		
		//================================================================================
		//  内部変数
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// 帳票系共通部品
        private ExtrInfo_DCHNB02013E _csSaleOrderPara = null;

        #endregion

		/// <summary>表示順位</summary>
	
		private string CT_Sort1_Odr01 = "SectionCode, SalesDate, SalesSlipNum, SalesRowNo ";	//（拠点）＋受注日＋伝票番号＋行番号
		private string CT_Sort1_Odr02 = "SectionCode, ShipmentDay, SalesSlipNum, SalesRowNo ";	//（拠点）＋貸出日＋伝票番号＋行番号
        // 2008.08.01 30413 犬飼 ソート順位の修正 >>>>>>START
        //private string CT_Sort2_Odr = "SectionCode,SalesSlipNum";									//（拠点）＋伝票番号
        //private string CT_Sort3_Odr = "SectionCode,CustomerCode, SalesSlipNum";					//（拠点）＋得意先＋伝票番号
        //private string CT_Sort4_Odr = "SectionCode,SalesEmployeeCd, SalesSlipNum";				//（拠点）＋販売従業員(担当者)コード＋伝票番号
        private string CT_Sort2_Odr = "SectionCode, SalesSlipNum, SearchSlipDate, SalesRowNo";						//（拠点）＋伝票番号＋伝票日付(入力日)＋行番号
        private string CT_Sort3_Odr = "SectionCode, CustomerCode, SalesSlipNum, SearchSlipDate, SalesRowNo";		//（拠点）＋得意先＋伝票番号＋伝票日付(入力日)＋行番号
        private string CT_Sort4_Odr = "SectionCode, SalesEmployeeCd, SalesSlipNum, SearchSlipDate, SalesRowNo";		//（拠点）＋販売従業員(担当者)コード＋伝票番号＋伝票日付(入力日)＋行番号
        // 2008.08.01 30413 犬飼 ソート順位の修正 <<<<<<END
        
		
		private string CT_Sort1_OdrStr01 = "[受注日＋伝票番号]";				//受注表の場合
        // 2008.08.01 30413 犬飼 出荷日→貸出日に修正 >>>>>>START
        //private string CT_Sort1_OdrStr02 = "[出荷日＋伝票番号＋行番号]";				//出荷表の場合
        private string CT_Sort1_OdrStr02 = "[貸出日＋伝票番号]";				//貸出表の場合
        // 2008.08.01 30413 犬飼 出荷日→貸出日に修正 <<<<<<END
        private string CT_Sort2_OdrStr = "[伝票番号]";
		private string CT_Sort3_OdrStr = "[得意先＋伝票番号]";
		private string CT_Sort4_OdrStr = "[担当者＋伝票番号]";


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

				// 印刷データ取得。ソートしたデータをDataViewに入れる。
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
			ct_TableName = DCHNB02014EA.CT_OrderConfDataTable;
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
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(	prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(), 
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
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				
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
		/// 各種プロパティを設定します。<br/>
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

			// ソート順の出力
			string sortTitle = "";
			this.SORTTITLE(out sortTitle);

			instance.PageHeaderSortOderTitle = sortTitle;

			//『粗利率チェックリスト範囲』の出力
			string marginMark = "";
			this.MARGINMARK(out marginMark);

			instance.PageHeaderSubtitle = marginMark;

			// フッタ出力区分
			instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

			// フッタ出力メッセージ（最下部罫線）
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);

			instance.PageFooters = footers;

			// 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

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
			string wrkstr = "";
			sorttitle = "";
			switch (this._csSaleOrderPara.SortOrder)
			{
				case 0:
					{
						if (this._csSaleOrderPara.AcptAnOdrStatus == 20)
						{
							wrkstr = CT_Sort1_OdrStr01;
						}
						else
						{
							wrkstr = CT_Sort1_OdrStr02;
						}
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
			}

			sorttitle = wrkstr;

		}
		#endregion
		#region ◆　『粗利率チェックリスト範囲』出力作成
		/// <summary>
		/// 『粗利率チェックリスト範囲』出力作成
		/// </summary>
		/// <param name="marginmark">『粗利率チェックリスト範囲』出力作成</param>
		/// <remarks>
		/// <br> 『粗利率チェックリスト範囲』を作成します。</br>
		/// </remarks>

		private void MARGINMARK(out string marginmark)
		{
			string mark1 = this._csSaleOrderPara.GrossMargin1Mark;
			string mark2 = this._csSaleOrderPara.GrossMargin2Mark;
			string mark3 = this._csSaleOrderPara.GrossMargin3Mark;
			string mark4 = this._csSaleOrderPara.GrossMargin4Mark;
			string grsLower = this._csSaleOrderPara.GrsProfitCheckLower.ToString();
			string grsBest = this._csSaleOrderPara.GrsProfitCheckBest.ToString();
			string grsUpper = this._csSaleOrderPara.GrsProfitCheckUpper.ToString();

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //string marginExpra1 = mark1 + "：" + grsLower + "％未満　　";
            //string marginExpra2 = mark2 + "：" + grsLower + "％以上  ～  " + grsBest + "％未満　　";
            //string marginExpra3 = mark3 + "：" + grsBest + "％以上  ～  " + grsUpper + "％未満　　";
            //string marginExpra4 = mark4 + "：" + grsUpper + "％以上";
            // --- DEL 2009/03/30 -------------------------------->>>>>
            // --- ADD 2009/03/30 -------------------------------->>>>>
            string marginExpra1 = grsLower + "％未満" + "：" + mark1 + "　　";
            string marginExpra2 = grsLower + "％以上  ～  " + grsBest + "％未満" + "：" + mark2 + "　　";
            string marginExpra3 = grsBest + "％以上  ～  " + grsUpper + "％未満" + "：" + mark3 + "　　";
            string marginExpra4 = grsUpper + "％以上" + "：" + mark4;
            // --- ADD 2009/03/30 --------------------------------<<<<<

			marginmark = marginExpra1 + marginExpra2 + marginExpra3 + marginExpra4;

		}
		#endregion

		#region ◆　抽出条件ヘッダー作成処理
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br> 出力する抽出条件文字列を作成します。</br>
		/// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
			// 抽出条件ヘッダー項目
			extraConditions = new StringCollection();

            // 2008.08.01 30413 犬飼 書式変更 >>>>>>START
            const string dateFormat = "YYYY/MM/DD";
            // 2008.08.01 30413 犬飼 書式変更 <<<<<<END

			// 対象期間
			string target = "";
			string stTarget = "";
			string edTarget = "";


            // 2008.08.01 30413 犬飼 既存の処理はコメント化 >>>>>>START
            //// 受注日（出荷日）
            //if ((this._csSaleOrderPara.SalesDateSt != 0) || (this._csSaleOrderPara.SalesDateEd != 0) ||
            //    (this._csSaleOrderPara.ShipmentDaySt != 0) || (this._csSaleOrderPara.ShipmentDayEd != 0))
            //{
            //    switch(this._csSaleOrderPara.AcptAnOdrStatus)
            //    {
            //        case 20:
						
            //            stTarget = "受注日: " + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SalesDateSt);
            //            edTarget = "  ～　" + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SalesDateEd);
            //            break;

            //        case 40:
						
            //            stTarget = "出荷日: " + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.ShipmentDaySt);
            //            edTarget = "  ～　" + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.ShipmentDayEd);
            //            break;

            //}			

            //    target = stTarget + edTarget;

            //    this.EditCondition(ref extraConditions, target);
            //}

            //// 入力日
            //if ((this._csSaleOrderPara.SearchSlipDateSt != 0) ||
            //   (this._csSaleOrderPara.SearchSlipDateEd != 0))
            //{
            //    stTarget = "入力日: " + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SearchSlipDateSt);
            //    edTarget = "  ～　" + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SearchSlipDateEd);

            //    target = stTarget + edTarget;

            //    this.EditCondition(ref extraConditions, target);
            //}

            //// 得意先
            //if (this._csSaleOrderPara.CustomerCodeSt != 0)
            //{
            //    if (this._csSaleOrderPara.CustomerCodeEd != 0)	//From To 両方印字
            //    {
            //        target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString();
            //    }
            //    else　											//From だけ印字
            //    {
            //        target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ ";
            //    }

            //    this.EditCondition(ref extraConditions, target);
            //}

            //else if (this._csSaleOrderPara.CustomerCodeEd != 0)	//Toだけ印字
            //{
            //    target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString();
            //    this.EditCondition(ref extraConditions, target);
            //}
            // 2008.08.01 30413 犬飼 既存の処理はコメント化 <<<<<<END
            
			
			//if (this._csSaleOrderPara.CustomerCodeSt >= 0)	
			//{
			//    if ((this._csSaleOrderPara.CustomerCodeSt == 0) || (this._csSaleOrderPara.CustomerCodeEd == 0))	// 出力しない
			//    {
			//        target = "";
			//    }
			//    else
			//    {
			//        target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ ";
			//    }

			//    this.EditCondition(ref extraConditions, target);
			//}
	

			//if ((this._csSaleOrderPara.CustomerCodeSt == 0) || (this._csSaleOrderPara.CustomerCodeEd == 0))
			//{
			//    target = "";
			//    this.EditCondition(ref extraConditions, target);
			//}
			//else if ((this._csSaleOrderPara.CustomerCodeEd != 0) || (this._csSaleOrderPara.CustomerCodeEd != 0))
			//{
			//    target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString();
			//    this.EditCondition(ref extraConditions, target);
			//}


			//if (this._csSaleOrderPara.CustomerCodeEd != 0)
			//{
			//    target = "得意先: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " ～ " + this._csSaleOrderPara.CustomerCodeEd.ToString();
			//    this.EditCondition(ref extraConditions, target);
			//}

            // 2008.08.01 30413 犬飼 既存の処理はコメント化 >>>>>>START
            //// 担当者コード
            //if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") ||
            //    (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
            //{
            //    target = "担当者コード: " + this._csSaleOrderPara.SalesEmployeeCdSt + " ～ " + this._csSaleOrderPara.SalesEmployeeCdEd;
            //    this.EditCondition(ref extraConditions, target);
            //}
            // 2008.08.01 30413 犬飼 既存の処理はコメント化 <<<<<<END
            
            // 2008.08.01 30413 犬飼 抽出条件文字列設定を変更 >>>>>>START
            // 受注日・貸出日
            switch (this._csSaleOrderPara.AcptAnOdrStatus)
            {
                case 20:
                    {
                        // 受注日
                        if ((this._csSaleOrderPara.SalesDateSt != 0) || (this._csSaleOrderPara.SalesDateEd != 0))
                        {
                            // 開始
                            if (this._csSaleOrderPara.SalesDateSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SalesDateSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._csSaleOrderPara.SalesDateEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SalesDateEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("受注日" + ct_RangeConst, stTarget, edTarget));
                        }
                        break;
                    }
                case 40:
                    {
                        // 貸出日
                        if ((this._csSaleOrderPara.ShipmentDaySt != 0) || (this._csSaleOrderPara.ShipmentDayEd != 0))
                        {
                            // 開始
                            if (this._csSaleOrderPara.ShipmentDaySt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.ShipmentDaySt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._csSaleOrderPara.ShipmentDayEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.ShipmentDayEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("貸出日" + ct_RangeConst, stTarget, edTarget));
                        }
                        break;
                    }
            }

            // 入力日
            if ((this._csSaleOrderPara.SearchSlipDateSt != 0) || (this._csSaleOrderPara.SearchSlipDateEd != 0))
            {
                // 開始
                if (this._csSaleOrderPara.SearchSlipDateSt != 0)
                {
                    stTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SearchSlipDateSt);
                }
                else
                {
                    stTarget = ct_Extr_Top;
                }
                // 終了
                if (this._csSaleOrderPara.SearchSlipDateEd != 0)
                {
                    edTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SearchSlipDateEd);
                }
                else
                {
                    edTarget = ct_Extr_End;
                }
                this.EditCondition(ref extraConditions, string.Format("入力日" + ct_RangeConst, stTarget, edTarget));
            }

            // 発行タイプ
            switch (this._csSaleOrderPara.PublicationType)
            {
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrder:
                    {
                        // 受注
                        target = "受注";
                        break;
                    }
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrderAddUp:
                    {
                        // 受注計上済
                        target = "受注計上済";
                        break;
                    }
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.Loan:
                    {
                        // 貸出
                        target = "貸出";
                        break;
                    }
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.LoanAddUp:
                    {
                        // 貸出計上済
                        target = "貸出計上済";
                        break;
                    }
            }
            this.EditCondition(ref extraConditions, "発行タイプ：" + target);

            // 改頁
            switch (this._csSaleOrderPara.NewPageType)
            {
                case 0:
                    {
                        // 拠点
                        target = "拠点";
                        break;
                    }
                case 1:
                    {
                        // 小計
                        target = "小計";
                        break;
                    }
                case 2:
                    {
                        // しない
                        target = "しない";
                        break;
                    }
            }
            this.EditCondition(ref extraConditions, "改頁：" + target);

            // 担当者 
            if (this._csSaleOrderPara.SalesEmployeeCdSt != string.Empty || this._csSaleOrderPara.SalesEmployeeCdEd != string.Empty)
            {
                stTarget = this._csSaleOrderPara.SalesEmployeeCdSt;
                edTarget = this._csSaleOrderPara.SalesEmployeeCdEd;
                if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                if (edTarget == string.Empty) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("担当者" + ct_RangeConst, stTarget, edTarget));
            }

            // 得意先
            target = "";
            if ((this._csSaleOrderPara.CustomerCodeSt == 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = string.Format("得意先" + ct_RangeConst, ct_Extr_Top, this._csSaleOrderPara.CustomerCodeEd.ToString("d08"));
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd == 0))
            {
                target = string.Format("得意先" + ct_RangeConst, this._csSaleOrderPara.CustomerCodeSt.ToString("d08"), ct_Extr_End);
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = string.Format("得意先" + ct_RangeConst, this._csSaleOrderPara.CustomerCodeSt.ToString("d08"), this._csSaleOrderPara.CustomerCodeEd.ToString("d08"));
            }
            this.EditCondition(ref extraConditions, target);
            // 2008.08.01 30413 犬飼 抽出条件文字列設定を変更 <<<<<<END
            
            
		}
		
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		///  出力する抽出条件文字列を編集します。<br/>
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

				if ((areaByte + targetByte + 2) <= 180)
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
		/// 印刷画面共通条件の設定を行います。<br/>
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
		/// DataViewに設定する印字順位のクエリを作成します。<br/>
        /// データをソートします。<br/>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
            string oderQuerry = "";

            switch (this._csSaleOrderPara.SortOrder)
            {
                case 0:
                    {
						if (this._csSaleOrderPara.AcptAnOdrStatus == 20)
						{
							oderQuerry = CT_Sort1_Odr01;
						}
						else
						{
							oderQuerry = CT_Sort1_Odr02;
						}
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
		///  出力件数の設定を行います。<br/>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCHNB02012P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}
