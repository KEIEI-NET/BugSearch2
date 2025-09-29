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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 前年対比表印刷クラス
	/// </summary>
	public class DCTOK02092PA
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// コンストラクター
		/// </summary>
		public DCTOK02092PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._prYearCpPara = this._printInfo.jyoken as ExtrInfo_DCTOK02093E;

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
		private ExtrInfo_DCTOK02093E _prYearCpPara = null;
        #endregion
               
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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

						// TODO 11.30プログレスバーUPイベント追加
						if (prtRpt is IPrintActiveReportTypeCommon)
						{
                            // ADD 2009/01/28 不具合対応[9829] ---------->>>>>
                            ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent += new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            // ADD 2008/01/28 不具合対応[9829] ----------<<<<<
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
			ct_TableName = DCTOK02094EA.CT_PrevYearCpDataTable;
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 2009.03.17 30413 犬飼 フッター部の印字変更 >>>>>>START
            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;

            int st = PrevYearComparison.ReadPrtOutSet(out prtOutSet, out message);

            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }
            // 2009.03.17 30413 犬飼 フッター部の印字変更 <<<<<<END
            
            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

			// ソート順の出力
			string sortTitle = "";
			this.SORTTITLE(out sortTitle);

			instance.PageHeaderSortOderTitle = sortTitle;

			// SUBTITLEの出力
			string subTitle = "";
			this.SUBTITLE(out subTitle);

			instance.PageHeaderSubtitle = subTitle;

            // 2009.03.17 30413 犬飼 フッター部の印字変更 >>>>>>START
            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // 2009.03.17 30413 犬飼 フッター部の印字変更 <<<<<<END
            
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
			switch (this._prYearCpPara.ListType)
			{
                case 0:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                            case 4:
                                wrkstr = "得意先";
                                break;
                            case 1:
                            case 2:
                                wrkstr = "拠点";
                                break;                            
                        }
                        break;
                    }
                case 1:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "担当者";
                                break;
                            case 1:
                                wrkstr = "得意先";
                                break;
                            case 2:
                                wrkstr = "拠点";
                                break;
                        }
                        break;
                    }
                case 2:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "受注者";
                                break;
                            case 1:
                                wrkstr = "得意先";
                                break;
                            case 2:
                                wrkstr = "拠点";
                                break;
                        }
                        break;
                    }
                case 3:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "地区";
                                break;
                            case 1:
                                wrkstr = "得意先";
                                break;
                            case 2:
                                wrkstr = "拠点";
                                break;
                        }
                        break;
                    }
                case 4:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "業種";
                                break;
                            case 1:
                                wrkstr = "得意先";
                                break;
                            case 2:
                                wrkstr = "拠点";
                                break;
                        }
                        break;
                    }
                case 5:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                wrkstr = "グループコード";
                                break;
                            case 1:
                                wrkstr = "商品中分類";
                                break;
                            case 2:
                                wrkstr = "商品大分類";
                                break;
                        }
                        break;
                    }
                case 6:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                wrkstr = "ＢＬコード";
                                break;
                            case 1:
                                wrkstr = "得意先";
                                break;
                            case 2:
                                wrkstr = "担当者";
                                break;
                        }
                        break;
                    }

			}

			sorttitle = wrkstr;

		}
		#endregion

		#region ◆　SUBTITLE出力
		/// <summary>
		/// SUBTITLE出力
		/// </summary>
		/// <param name="subtitle">SUBTITLE出力</param>
		/// <remarks>
		/// <br> SUBTITLEの出力を作成します。</br>
		/// </remarks>
		private void SUBTITLE(out string subtitle)
		{
			// SUBTITLE出力
			string substr = "";
			subtitle = "";
			switch (this._prYearCpPara.ListType)
			{
				case 0:
					{
                        substr = "（得意先別）";
						break;
					}
				case 1:
					{
                        substr = "（担当者別）";
						break;
					}
				case 2:
					{
						substr = "（受注者別）";
						break;
					}
				case 3:
					{
						substr = "（地区別）";
						break;
					}
				case 4:
					{
						substr = "（業種別）";
						break;
					}
				case 5:
					{
						substr = "（グループコード別）";
						break;
                    }
                case 6:
                    {
                        substr = "（ＢＬコード別）";
                        break;
                    }
			}

			subtitle = substr;

		}
				#endregion	
	
		#region ◆　抽出条件ヘッダー作成処理
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
			// 抽出条件ヘッダー項目
			extraConditions = new StringCollection();
			
			// 対象期間
			string target = "";
			string stTarget = "";
			string edTarget = "";
			string stmonth = "";
			string edmonth = "";

			// 対象年月
            if ((this._prYearCpPara.St_AddUpYearMonth != 0) ||
               (this._prYearCpPara.Ed_AddUpYearMonth != 0))
            {

				stmonth = this._prYearCpPara.St_AddUpYearMonth.ToString() + "01";
				DateTime dt_stMonth = DateTime.ParseExact(stmonth, "yyyyMMdd", null);
                //stTarget = "対象年月: " + dt_stMonth.ToString("Y");       // DEL 2008.12.18 [9355]
                stTarget = "対象年月: " + dt_stMonth.ToString("yyyy/MM");   // ADD 2008.12.18 [9355]

				edmonth = this._prYearCpPara.Ed_AddUpYearMonth.ToString() + "01";
				DateTime dt_edMonth = DateTime.ParseExact(edmonth, "yyyyMMdd", null);
                //edTarget = " ～ " + dt_edMonth.ToString("Y");             // DEL 2008.12.18 [9355]
                edTarget = " ～ " + dt_edMonth.ToString("yyyy/MM");         // ADD 2008.12.18 [9355]


                target = stTarget + edTarget;

                this.EditCondition(ref extraConditions, target);
            }

            // 集計方法
			target = "集計方法: ";
            if (this._prYearCpPara.TotalWay == 0)
            {
                target += "全社";
            }
            else
            {
                target += "拠点毎";
            }
            this.EditCondition(ref extraConditions, target);

			// 印刷タイプ
			target = "印刷タイプ: ";
			switch (this._prYearCpPara.PrintType)
			{
				case 0:
					target += "売上";
					break;

				case 1:
					target += "粗利";
					break;

				case 2:
					target += "売上＆粗利";
					break;
			}
			this.EditCondition(ref extraConditions, target);

			// 金額単位
			target = "金額単位: ";
			switch (this._prYearCpPara.MoneyUnit)
			{
				case 0:
					target += "円";
					break;

				case 1:
					target += "千円";
					break;
			}
			this.EditCondition(ref extraConditions, target);


            switch (this._prYearCpPara.ListType)
            {
                case 0:
                    if (this._prYearCpPara.NewPage)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "得意先別";
                            break;
                        case 1:
                            target += "拠点別";
                            break;
                        case 2:
                            target += "得意先別拠点別";
                            break;
                        case 3:
                            target += "管理拠点別";
                            break;
                        case 4:
                            target += "請求先別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 1:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 担当者単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位／担当者単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "担当者別";
                            break;
                        case 1:
                            target += "得意先別";
                            break;
                        case 2:
                            target += "担当者別拠点別";
                            break;
                        case 3:
                            target += "管理拠点別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);

                    break;
                case 2:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 受注者単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位／受注者単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "受注者別";
                            break;
                        case 1:
                            target += "得意先別";
                            break;
                        case 2:
                            target += "受注者別拠点別";
                            break;
                        case 3:
                            target += "管理拠点別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 3:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 地区単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位／地区単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "地区別";
                            break;
                        case 1:
                            target += "得意先別";
                            break;
                        case 2:
                            target += "地区別拠点別";
                            break;
                        case 3:
                            target += "管理拠点別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 4:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 業種単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位／業種単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "業種別";
                            break;
                        case 1:
                            target += "得意先別";
                            break;
                        case 2:
                            target += "業種別拠点別";
                            break;
                        case 3:
                            target += "管理拠点別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 5:
                    if (this._prYearCpPara.NewPage)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "グループコード別";
                            break;
                        case 1:
                            target += "商品中分類別";
                            break;
                        case 2:
                            target += "商品大分類別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 6:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: ＢＬコード単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "改頁: 拠点単位／ＢＬコード単位";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "発行タイプ: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "ＢＬコード別";
                            break;
                        case 1:
                            target += "ＢＬコード別得意先別";
                            break;
                        case 2:
                            target += "ＢＬコード別担当者別";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
            }

            target = "当月純売上: ";
            if (this._prYearCpPara.St_MonthSalesRatio_ck == true &&
                this._prYearCpPara.Ed_MonthSalesRatio_ck == true)
            {                
                target += this._prYearCpPara.St_MonthSalesRatio.ToString() + "％ ～ ";
                target += this._prYearCpPara.Ed_MonthSalesRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthSalesRatio_ck == true &&
                this._prYearCpPara.Ed_MonthSalesRatio_ck == false)
            {
                target += this._prYearCpPara.St_MonthSalesRatio.ToString() + "％ ～ ";
                target += "最後まで";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthSalesRatio_ck == false &&
                   this._prYearCpPara.Ed_MonthSalesRatio_ck == true)
            {
                target += "最初から ～ ";
                target += this._prYearCpPara.Ed_MonthSalesRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }

            target = "当年純売上: ";
            if (this._prYearCpPara.St_YearSalesRatio_ck == true &&
                this._prYearCpPara.Ed_YearSalesRatio_ck == true)
            {
                target += this._prYearCpPara.St_YearSalesRatio.ToString() + "％ ～ ";
                target += this._prYearCpPara.Ed_YearSalesRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearSalesRatio_ck == true &&
                     this._prYearCpPara.Ed_YearSalesRatio_ck == false)
            {
                target += this._prYearCpPara.St_YearSalesRatio.ToString() + "％ ～ ";
                target += "最後まで";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearSalesRatio_ck == false &&
                     this._prYearCpPara.Ed_YearSalesRatio_ck == true)
            {
                target += "最初から ～ ";
                target += this._prYearCpPara.Ed_YearSalesRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }

            target = "当月粗利: ";
            if (this._prYearCpPara.St_MonthGrossRatio_ck == true &&
                this._prYearCpPara.Ed_MonthGrossRatio_ck == true)
            {
                target += this._prYearCpPara.St_MonthGrossRatio.ToString() + "％ ～ ";
                target += this._prYearCpPara.Ed_MonthGrossRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthGrossRatio_ck == true &&
                     this._prYearCpPara.Ed_MonthGrossRatio_ck == false)
            {
                target += this._prYearCpPara.St_MonthGrossRatio.ToString() + "％ ～ ";
                target += "最後まで";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthGrossRatio_ck == false &&
                     this._prYearCpPara.Ed_MonthGrossRatio_ck == true)
            {
                target += "最初から ～ ";
                target += this._prYearCpPara.Ed_MonthGrossRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }

            target = "当年粗利: ";
            if (this._prYearCpPara.St_YearGrossRatio_ck == true &&
                this._prYearCpPara.Ed_YearGrossRatio_ck == true)
            {
                target += this._prYearCpPara.St_YearGrossRatio.ToString() + "％ ～ ";
                target += this._prYearCpPara.Ed_YearGrossRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearGrossRatio_ck == true &&
                     this._prYearCpPara.Ed_YearGrossRatio_ck == false)
            {
                target += this._prYearCpPara.St_YearGrossRatio.ToString() + "％ ～ ";
                target += "最後まで";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearGrossRatio_ck == false &&
           this._prYearCpPara.Ed_YearGrossRatio_ck == true)
            {
                target += "最初から ～ ";
                target += this._prYearCpPara.Ed_YearGrossRatio.ToString() + "％";
                this.EditCondition(ref extraConditions, target);
            }

            switch (this._prYearCpPara.ListType)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 6:
                    target = "得意先: ";
                    if (this._prYearCpPara.St_CustomerCode != 0 &&
                        this._prYearCpPara.Ed_CustomerCode != 0)
                    {
                        target += this._prYearCpPara.St_CustomerCode + " ～ ";
                        target += this._prYearCpPara.Ed_CustomerCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_CustomerCode == 0 &&
                             this._prYearCpPara.Ed_CustomerCode != 0)
                    {
                        target += "最初から ～ ";
                        target += this._prYearCpPara.Ed_CustomerCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_CustomerCode != 0 &&
                             this._prYearCpPara.Ed_CustomerCode == 0)
                    {
                        target += this._prYearCpPara.St_CustomerCode + " ～ ";
                        target += "最後まで";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.ListType == 1 ||
                        this._prYearCpPara.ListType == 2 ||
                        this._prYearCpPara.ListType == 6)
                    {
                        if (this._prYearCpPara.ListType == 1 ||
                            this._prYearCpPara.ListType == 6)
                        {
                            target = "担当者: ";
                        }
                        else
                        {
                            target = "受注者: ";
                        }
                        if (!this._prYearCpPara.St_EmployeeCode.Trim().PadLeft(4,'0').Equals("0000") &&
                            !this._prYearCpPara.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
                        {
                            target += this._prYearCpPara.St_EmployeeCode + " ～ ";
                            target += this._prYearCpPara.Ed_EmployeeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000") &&
                                 !this._prYearCpPara.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
                        {
                            target += "最初から ～ ";
                            target += this._prYearCpPara.Ed_EmployeeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (!this._prYearCpPara.St_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000") &&
                                 this._prYearCpPara.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
                        {
                            target += this._prYearCpPara.St_EmployeeCode + " ～ ";
                            target += "最後まで";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }

                    if (this._prYearCpPara.ListType == 3)
                    {
                        target = "地区: ";
                        if (this._prYearCpPara.St_SalesAreaCode != 0 &&
                            this._prYearCpPara.Ed_SalesAreaCode != 0)
                        {
                            target += this._prYearCpPara.St_SalesAreaCode + " ～ ";
                            target += this._prYearCpPara.Ed_SalesAreaCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_SalesAreaCode == 0 &&
                                 this._prYearCpPara.Ed_SalesAreaCode != 0)
                        {
                            target += "最初から ～ ";
                            target += this._prYearCpPara.Ed_SalesAreaCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_SalesAreaCode != 0 &&
                               this._prYearCpPara.Ed_SalesAreaCode == 0)
                        {
                            target += this._prYearCpPara.St_SalesAreaCode + " ～ ";
                            target += "最後まで";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }
                    if (this._prYearCpPara.ListType == 4)
                    {
                        target = "業種: ";
                        if (this._prYearCpPara.St_BusinessTypeCode != 0 &&
                            this._prYearCpPara.Ed_BusinessTypeCode != 0)
                        {
                            target += this._prYearCpPara.St_BusinessTypeCode + " ～ ";
                            target += this._prYearCpPara.Ed_BusinessTypeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BusinessTypeCode == 0 &&
                                 this._prYearCpPara.Ed_BusinessTypeCode != 0)
                        {
                            target += "最初から ～ ";
                            target += this._prYearCpPara.Ed_BusinessTypeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BusinessTypeCode != 0 &&
                                 this._prYearCpPara.Ed_BusinessTypeCode == 0)
                        {
                            target += this._prYearCpPara.St_BusinessTypeCode + " ～ ";
                            target += "最後まで";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }
                    if (this._prYearCpPara.ListType == 6)
                    {
                        target = "ＢＬコード: ";
                        if (this._prYearCpPara.St_BLGoodsCode != 0 &&
                            this._prYearCpPara.Ed_BLGoodsCode != 0)
                        {
                            target += this._prYearCpPara.St_BLGoodsCode + " ～ ";
                            target += this._prYearCpPara.Ed_BLGoodsCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BLGoodsCode == 0 &&
                                 this._prYearCpPara.Ed_BLGoodsCode != 0)
                        {
                            target += "最初から ～ ";
                            target += this._prYearCpPara.Ed_BusinessTypeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BLGoodsCode != 0 &&
                                 this._prYearCpPara.Ed_BLGoodsCode == 0)
                        {
                            target += this._prYearCpPara.St_BLGoodsCode + " ～ ";
                            target += "最後まで";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }
                    break;
                case 5:
                    target = "商品大分類: ";
                    if (this._prYearCpPara.St_GoodsLGroup != 0 &&
                        this._prYearCpPara.Ed_GoodsLGroup != 0)
                    {
                        target += this._prYearCpPara.St_GoodsLGroup + " ～ ";
                        target += this._prYearCpPara.Ed_GoodsLGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsLGroup == 0 &&
                             this._prYearCpPara.Ed_GoodsLGroup != 0)
                    {
                        target += "最初から ～ ";
                        target += this._prYearCpPara.Ed_GoodsLGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsLGroup != 0 &&
                             this._prYearCpPara.Ed_GoodsLGroup == 0)
                    {
                        target += this._prYearCpPara.St_GoodsLGroup + " ～ ";
                        target += "最後まで";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "商品中分類: ";
                    if (this._prYearCpPara.St_GoodsMGroup != 0 &&
                        this._prYearCpPara.Ed_GoodsMGroup != 0)
                    {
                        target += this._prYearCpPara.St_GoodsMGroup + " ～ ";
                        target += this._prYearCpPara.Ed_GoodsMGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsMGroup == 0 &&
                             this._prYearCpPara.Ed_GoodsMGroup != 0)
                    {
                        target += "最初から ～ ";
                        target += this._prYearCpPara.Ed_GoodsMGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsMGroup != 0 &&
                             this._prYearCpPara.Ed_GoodsMGroup == 0)
                    {
                        target += this._prYearCpPara.St_GoodsMGroup + " ～ ";
                        target += "最後まで";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "グループコード: ";
                    if (this._prYearCpPara.St_BLGroupCode != 0 &&
                        this._prYearCpPara.Ed_BLGroupCode != 0)
                    {
                        target += this._prYearCpPara.St_BLGroupCode + " ～ ";
                        target += this._prYearCpPara.Ed_BLGroupCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_BLGroupCode == 0 &&
                             this._prYearCpPara.Ed_BLGroupCode != 0)
                    {
                        target += "最初から ～ ";
                        target += this._prYearCpPara.Ed_BLGroupCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_BLGroupCode != 0 &&
                             this._prYearCpPara.Ed_BLGroupCode == 0)
                    {
                        target += this._prYearCpPara.St_BLGroupCode + " ～ ";
                        target += "最後まで";
                        this.EditCondition(ref extraConditions, target);
                    }
                    break;
            }
		}
		
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
            string oderQuerry = "";

            //switch (this._prYearCpPara.PrintType)         //DEL 2009/01/30 不具合対応[9841]
            switch (this._prYearCpPara.ListType)            //ADD 2009/01/30 不具合対応[9841]
            {
                case 0:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                            case 4:
                                oderQuerry = "AddUpSecCode,CustomerCode";   // 拠点→得意先
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode";                // 拠点
                                break;
                            case 2:
                                oderQuerry = "CustomerCode,AddUpSecCode";   // 得意先／拠点
                                break;
                        }
                        break;
                    }
                case 1:
                case 2:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                oderQuerry = "AddUpSecCode,EmployeeCode";               // 拠点→担当者
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,EmployeeCode,CustomerCode";  // 拠点→担当者→得意先
                                break;
                            case 2:
                                oderQuerry = "EmployeeCode,AddUpSecCode";               // 担当者→拠点
                                break;
                        }
                        break;
                    }
                case 3:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                oderQuerry = "AddUpSecCode,SalesAreaCode";              // 拠点→地区
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,SalesAreaCode,CustomerCode"; // 拠点→地区→得意先
                                break;
                            case 2:
                                oderQuerry = "SalesAreaCode,AddUpSecCode";              // 地区→拠点
                                break;
                        }
                        break;
                    }
                case 4:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                oderQuerry = "AddUpSecCode,BusinessTypeCode";              // 拠点→業種
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,BusinessTypeCode,CustomerCode"; // 拠点→業種→得意先
                                break;
                            case 2:
                                oderQuerry = "BusinessTypeCode,AddUpSecCode";              // 業種→拠点
                                break;
                        }
                        break;
                    }
                case 5:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                oderQuerry = "AddUpSecCode,BLGroupCode";        // 拠点→グループコード
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,GoodsMGroup";        // 拠点→商品中分類
                                break;
                            case 2:
                                oderQuerry = "AddUpSecCode,GoodsLGroup";        // 拠点→商品大分類
                                break;
                        }
                        break;
                    }
                case 6:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                oderQuerry = "AddUpSecCode,BLGoodsCode";                // 拠点→ＢＬコード
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,BLGoodsCode,CustomerCode";   // 拠点→ＢＬコード→得意先
                                break;
                            case 2:
                                oderQuerry = "AddUpSecCode,BLGoodsCode,EmployeeCode";   // 拠点→ＢＬコード→担当者
                                break;
                        }
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
		/// <br>Note       : 出力件数の設定を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02092P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}
