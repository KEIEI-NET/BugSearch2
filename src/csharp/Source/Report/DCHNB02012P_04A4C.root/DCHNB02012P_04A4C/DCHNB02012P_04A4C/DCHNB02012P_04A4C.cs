//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 受注・貸出確認表
// プログラム概要   : 受注・貸出確認表の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/08/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 980035 金沢 貞義
// 作 成 日  2008/10/08  修正内容 : 帳票レイアウトのみ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2008/10/31  修正内容 : 合計金額追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/01/30  修正内容 : 受注残数追加、数量を受注数に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/03/30  修正内容 : 障害対応10230、10231、12395、12397
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/28  修正内容 : MANTIS【13221】明細タイトル「受注残数」→「貸出残数」
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/07  修正内容 : MANTIS【13229】改頁時の拠点出力不具合を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caohh
// 作 成 日  2011/08/11  修正内容 : Redmine#23472対応：「消費税」を削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 作 成 日  2011/12/02  修正内容 : Redmine#8316対応：貸出確認表/金額の算出方法の変更
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 出荷確認表（明細タイプ）帳票クラス
	/// </summary>
    /// <br>Programer  : 980035 金沢 貞義</br>
    /// <br>Date       : 2008.10.08 帳票レイアウトのみ変更</br>
    /// <br>UpdateNote : 2008/10/31 照田 貴志　合計金額追加</br>
    /// <br>UpdateNote : 2009/01/30 上野 俊治　受注残数追加、数量を受注数に修正</br>
    /// <br>UpdateNote : 2009/03/30 上野 俊治　障害対応10230、10231、12395、12397</br>
    /// <br>UpdateNote : 2011/08/11 caohh　#23472対応：「消費税」を削除</br>
    /// <br>UpdateNote : 2011/12/02 陳建明　#8316対応： 貸出確認表/金額の算出方法の変更</br>
    public class DCHNB02012P_04A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList	
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// コンストラクター
		/// </summary>
		public DCHNB02012P_04A4C()
		{
			InitializeComponent();
		}
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		// 拠点表示有無
		private bool _isSection;
		
		// 抽出条件ヘッダ出力区分
		private int _extraCondHeadOutDiv;

		// ソート順タイトル
		private string _pageHeaderSortOderTitle;

		//粗利率チェックマーク（説明部）

		private string _grossMarginCheckExpra;
		
		// 抽出条件印字項目
		private StringCollection _extraConditions;

		//// 粗利範囲該当チェック
		//private StringCollection _makegrossmargin;
		
		// フッター出力有無
		private int _pageFooterOutCode;
		
		// フッタメッセージ1
		private StringCollection _pageFooters;
		
		// 印刷情報
		private SFCMN06002C _printInfo;

        // 印刷条件
        private ExtrInfo_DCHNB02013E _extraInfo;

		// 関連データオブジェクト
		private ArrayList _otherDataList;

		// 出力用DataSet
		DataSet outputDs;
		


		#region  背景透かしモード(無し)
		private int _watermarkMode = 0;
		private DataDynamics.ActiveReports.TextBox DATE;
		private DataDynamics.ActiveReports.TextBox TIME;
		private DataDynamics.ActiveReports.Label lblTitle;
		private DataDynamics.ActiveReports.Label lblPage;
        private DataDynamics.ActiveReports.TextBox txtPageNo;
        private Line line1;
		private DataDynamics.ActiveReports.Label label2;
		private DataDynamics.ActiveReports.Label label6;
		private DataDynamics.ActiveReports.TextBox Extraction;
		private DataDynamics.ActiveReports.TextBox Extraction2;
		private DataDynamics.ActiveReports.TextBox SORTTITLE;
		private DataDynamics.ActiveReports.TextBox textBox27;
		private DataDynamics.ActiveReports.TextBox textBox28;
		private DataDynamics.ActiveReports.TextBox textBox29;
        private DataDynamics.ActiveReports.TextBox textBox30;
		private GroupHeader TitleHeader1;
        private GroupFooter TitleFooter1;
		private Line line28;
		private ReportHeader reportHeader1;
		private ReportFooter reportFooter1;
        private Line line46;
		private DataDynamics.ActiveReports.Label label40;
#endregion

        private SubReport Footer_SubReport;
		private Line line6;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label Label9;
        private DataDynamics.ActiveReports.Label Label13;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Label label19;
        private DataDynamics.ActiveReports.Label label23;
        private DataDynamics.ActiveReports.Label label14;
        private DataDynamics.ActiveReports.Label label15;
        private DataDynamics.ActiveReports.Label label16;
        private DataDynamics.ActiveReports.Label label17;
        private DataDynamics.ActiveReports.Label label18;
        private DataDynamics.ActiveReports.Label Label_GrossProfitDtl;
        private DataDynamics.ActiveReports.Label label38;
        private DataDynamics.ActiveReports.Label label20;
        private DataDynamics.ActiveReports.Label label21;
        private DataDynamics.ActiveReports.Label label22;
        private DataDynamics.ActiveReports.Label label24;
        private DataDynamics.ActiveReports.Label label39;
        private DataDynamics.ActiveReports.Label label41;
        private DataDynamics.ActiveReports.Label label42;
        private DataDynamics.ActiveReports.Label label43;
        private DataDynamics.ActiveReports.Label Label_CostTitle;
        private DataDynamics.ActiveReports.Label label46;
        private Line line14;
        private DataDynamics.ActiveReports.Label label44;
        private DataDynamics.ActiveReports.Label label45;
        private DataDynamics.ActiveReports.Label label47;
        private DataDynamics.ActiveReports.Label label49;
        private DataDynamics.ActiveReports.Label Label_GrossMarginRateDtl;
        private DataDynamics.ActiveReports.Label label51;
        private GroupHeader GlandTotalHeader;
        private GroupFooter GlandTotalFooter;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private GroupHeader Header1;
        private GroupFooter Footer1;
        private GroupHeader Header2;
        private GroupFooter Footer2;
        private DataDynamics.ActiveReports.TextBox SalesInputName;
        private DataDynamics.ActiveReports.TextBox SalesSlipName;
        private DataDynamics.ActiveReports.TextBox SalesSlipNum;
        private DataDynamics.ActiveReports.TextBox CustomerCode;
        private DataDynamics.ActiveReports.TextBox CustomerSnm;
        private DataDynamics.ActiveReports.TextBox ShipmentDay;
        private DataDynamics.ActiveReports.TextBox SalesEmployeeNm;
        private DataDynamics.ActiveReports.TextBox FrontEmployeeNm;
        private DataDynamics.ActiveReports.TextBox SearchSlipDate;
        private DataDynamics.ActiveReports.TextBox BusinessTypeName;
        private DataDynamics.ActiveReports.TextBox PartySaleSlipNum;
        private DataDynamics.ActiveReports.TextBox ModelFullName;
        private DataDynamics.ActiveReports.TextBox CategoryDtl;
        private DataDynamics.ActiveReports.TextBox SalesCode;
        private DataDynamics.ActiveReports.TextBox FullModel;
        private DataDynamics.ActiveReports.TextBox CarMngCode;
        private DataDynamics.ActiveReports.TextBox BLGoodsCode;
        private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox SalesOrderDivName;
        private DataDynamics.ActiveReports.TextBox GoodsName;
        private DataDynamics.ActiveReports.TextBox ListPriceTaxExcFl;
        private DataDynamics.ActiveReports.TextBox AcceptAnOrderCntPlusAdjustCnt;
        private DataDynamics.ActiveReports.TextBox SalesUnitCost;
        private DataDynamics.ActiveReports.TextBox SalesUnPrcTaxExcFl;
        private DataDynamics.ActiveReports.TextBox Cost;
        private DataDynamics.ActiveReports.TextBox SalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox SupplierCd;
        private DataDynamics.ActiveReports.TextBox SupplierSlipNo;
        private DataDynamics.ActiveReports.TextBox WarehouseName;
        private DataDynamics.ActiveReports.TextBox FirstEntryDate;
        private DataDynamics.ActiveReports.TextBox GrossProfitDtl;
        private DataDynamics.ActiveReports.TextBox GrossMarginMarkDtl;
        private DataDynamics.ActiveReports.TextBox GrossMarginRateDtl;
        private DataDynamics.ActiveReports.Label Label_Percentage;
        private DataDynamics.ActiveReports.TextBox SlipNote;
        private DataDynamics.ActiveReports.TextBox SlipNote2;
        private DataDynamics.ActiveReports.TextBox AddUpADate;
        private Line line9;
        private Line line4;
        private DataDynamics.ActiveReports.TextBox TextBox37;
        private DataDynamics.ActiveReports.Label label26;
        private DataDynamics.ActiveReports.TextBox textBox9;
        private DataDynamics.ActiveReports.TextBox Section_TotalCostDtl;
        private DataDynamics.ActiveReports.TextBox Section_SalesMoneyDtl;
        private DataDynamics.ActiveReports.TextBox Section_SalesGrossProfitDtl;
        private DataDynamics.ActiveReports.TextBox Section_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.TextBox Section_SalesGrossMarginMark;
        private DataDynamics.ActiveReports.Label Section_SalesPercentage;
        private Line line3;
        private DataDynamics.ActiveReports.TextBox Footer1Field;
        private DataDynamics.ActiveReports.TextBox f1_CntSalesDtl;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesMoneyDtl;
        private DataDynamics.ActiveReports.TextBox Footer1_TotalCostDtl;
        private DataDynamics.ActiveReports.Label f1_SalesLbl;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesGrossProfitDtl;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesGrossMarginMark;
        private DataDynamics.ActiveReports.Label Footer1_SalesPercentage;
        private DataDynamics.ActiveReports.TextBox Footer2Field;
        private DataDynamics.ActiveReports.TextBox f2_CntSalesDtl;
        private DataDynamics.ActiveReports.TextBox Footer2_SalesMoneyDtl;
        private DataDynamics.ActiveReports.TextBox Footer2_TotalCostDtl;
        private DataDynamics.ActiveReports.Label f2_SalesLbl;
        private DataDynamics.ActiveReports.TextBox Footer2_SalesGrossProfitDtl;
        private DataDynamics.ActiveReports.TextBox Footer2_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.TextBox Footer2_SalesGrossMarginMark;
        private DataDynamics.ActiveReports.Label Footer2_SalesPercentage;
        private Line line2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.Label label27;
        private DataDynamics.ActiveReports.TextBox Grand_TotalCostDtl;
        private DataDynamics.ActiveReports.TextBox Grand_SalesMoneyDtl;
        private DataDynamics.ActiveReports.TextBox Grand_SalesGrossProfitDtl;
        private DataDynamics.ActiveReports.TextBox Grand_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.TextBox Grand_SalesGrossMarginMark;
        private DataDynamics.ActiveReports.Label Grand_SalesPercentage;
        private GroupHeader Header3;
        private GroupFooter Footer3;
        private Line line7;
        private DataDynamics.ActiveReports.TextBox Tax;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.TextBox ConsTaxLayMethod;
        private DataDynamics.ActiveReports.TextBox TaxationDivCd;
        private DataDynamics.ActiveReports.TextBox SalesSlipCdDtl;
        private DataDynamics.ActiveReports.Label label25;
        private DataDynamics.ActiveReports.TextBox SlipNote3;
        private GroupHeader DateHeader;
        private GroupFooter DateFooter;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox8;
        private DataDynamics.ActiveReports.TextBox Date_SalesMoneyDtl;
        private DataDynamics.ActiveReports.TextBox Date_TotalCostDtl;
        private DataDynamics.ActiveReports.Label label29;
        private DataDynamics.ActiveReports.TextBox Date_SalesGrossProfitDtl;
        private DataDynamics.ActiveReports.TextBox Date_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.TextBox Date_SalesGrossMarginMark;
        private DataDynamics.ActiveReports.Label Date_SalesPercentage;
        private Line line8;
        private DataDynamics.ActiveReports.TextBox Footer2_SalesDtlTax;
        private DataDynamics.ActiveReports.TextBox Date_SalesDtlTax;
        private DataDynamics.ActiveReports.TextBox Grand_SalesDtlTax;
        private DataDynamics.ActiveReports.TextBox Section_SalesDtlTax;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesDtlTax;
        private DataDynamics.ActiveReports.TextBox AcptAnOdrRemainCnt;
        private DataDynamics.ActiveReports.Label label31;
        private DataDynamics.ActiveReports.TextBox Footer2_ConsTaxLayMethod;

		//TODO 2:TODO1関連
		//印刷件数
		private int _printCount = 1;

		#endregion


		//================================================================================
		//  プロパティ
		//================================================================================
		#region public property
		#region IPrintActiveReportTypeList メンバ
		/// <summary>
		/// ページヘッダソート順タイトル項目
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set
			{
				this._pageHeaderSortOderTitle = value;
			}
		}

		/// <summary>
		/// 粗利粗利率チェックマーク（説明部）項目
		/// </summary>
		public string PageHeaderSubtitle
		{
			set
			{
				this._grossMarginCheckExpra = value;
			}
		}
		

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{this._extraCondHeadOutDiv = value;}
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set
			{
				this._extraConditions = value;
			}
		}

		
		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set
			{
				this._pageFooterOutCode = value;
			}
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set
			{
				this._pageFooters = value;
			}
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo = value;
				this.outputDs = (DataSet)this._printInfo.rdData;
			}
		}

		/// <summary>
		/// その他データ
		/// </summary>
		public ArrayList OtherDataList
		{
			set
			{
				this._otherDataList = value;
				if (this._otherDataList != null)
				{
					if (this._otherDataList.Count > 0)
					{
						this._isSection = (bool)this._otherDataList[0];
					}
				}
			}
		}
				
		#endregion
		
		#region IPrintActiveReportTypeCommon メンバ
		//TODO 4:TODO1関連
		/// <summary>プログレスバーカウントアップイベント</summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;

		/// <summary>背景透かしモード</summary>
		/// <value>0：背景透かし無し, 1:背景透かし有り</value>
		public int WatermarkMode
		{
			set{}
			get{return this._watermarkMode;}
		}
		#endregion
		#endregion

		//================================================================================
		//  イベント
		//================================================================================
		#region event
		/// <summary>
		/// レポートスタートイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
		/// </remarks>
		private void DCHNB02012P_04A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
            // 条件取得
            this._extraInfo = (ExtrInfo_DCHNB02013E)this._printInfo.jyoken;

			//TODO 3:TODO1関連
			// 印刷件数初期化
			this._printCount = 0;
			
			// 罫線表示・非表示制御
			foreach (Section section in this.Sections)
			{
				Section targetSection = section; 
				//this.SetVisibleRuledLine(ref targetSection);
			}

            // グループ順制御
            this.ChangeGroupOrder();

            // 原価・粗利出力制御
            this.ChangeCostPrt(); // ADD 2009/03/30

            // 小計印字制御
            this.ChangeSumRec();

            //保留。TODO参照
			// 原価・粗利出力制御
			//this.ChangeCostPrt();

            // 2008.11.28 30413 犬飼 改頁制御の変更 >>>>>>START
            // 2008.07.29 30413 犬飼 改頁制御の追加 >>>>>>START
            // 改頁設定
            if (this._extraInfo.NewPageType == 0)
            {
                // 拠点毎
                this.SectionHeader.NewPage = NewPage.Before;

                this.Header1.NewPage = NewPage.None;
                this.Header2.NewPage = NewPage.None;
            }
            else if (this._extraInfo.NewPageType == 1)
            {
                // 小計毎
                //this.SectionHeader.NewPage = NewPage.None;
                //this.SectionFooter.NewPage = NewPage.After;

                //this.Header1.NewPage = NewPage.Before;
                //this.Header2.NewPage = NewPage.Before;

                switch (this._extraInfo.SortOrder)
                {
                    case 0:  // 受注日+伝票番号
                    case 1:  // 伝票番号
                        {
                            this.SectionHeader.NewPage = NewPage.None;

                            this.Header1.NewPage = NewPage.None;
                            this.Header2.NewPage = NewPage.None;
                            break;
                        }
                    case 2:  // 得意先+伝票番号
                    case 3:  // 担当者+伝票番号
                        {
                            this.SectionHeader.NewPage = NewPage.Before;

                            this.Header1.NewPage = NewPage.Before;
                            this.Header2.NewPage = NewPage.None;
                            break;
                        }
                }
            }
            else
            {
                // 改ページしない
                this.SectionHeader.NewPage = NewPage.None;

                this.Header1.NewPage = NewPage.None;
                this.Header2.NewPage = NewPage.None;
            }
            // 2008.07.29 30413 犬飼 改頁制御の追加 <<<<<<END
            // 2008.11.28 30413 犬飼 改頁制御の変更 <<<<<<END
            
        }

		/// <summary>
		/// ページヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// ソート順
			this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

			//粗利率マーク（説明部）
			this.Extraction2.Text = this._grossMarginCheckExpra;

			// 作成日付
			DateTime now = DateTime.Now;
    		this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
			
			// 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);

			// 『抽出条件』
			for (int i = 0; i < this._extraConditions.Count; i++)
			{
				this.Extraction.Text = this._extraConditions[i];
			}

		}

        ///// <summary>
        ///// 拠点ヘッダフォーマットイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="eArgs">イベントハンドラ</param>
        ///// <remarks>
        ///// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2005.11.09</br>
        ///// </remarks>
        //private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        //{
        //    // ヘッダ出力制御
        //    if (this._extraCondHeadOutDiv == 0)
        //    {
        //        // >>>>> 2006.08.21 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        //        // 毎ページ出力
        //        this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
        //        //// 毎ページ出力
        //        //this.ExtraHeader.RepeatStyle = RepeatStyle.OnPage;
        //        // <<<<< 2006.08.21 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        //    } 
        //    else 
        //    {
        //        // 先頭ページのみ
        //        this.ExtraHeader.RepeatStyle = RepeatStyle.None;
        //    }
			
        //    // ヘッダーサブレポート作成
        //    ListCommon_ExtraHeader rpt   = new ListCommon_ExtraHeader();

        //    //// 抽出条件印字項目設定
        //    rpt.ExtraConditions         = this._extraConditions;
			
        //    //this.Header_SubReport.Report = rpt;
			
        //}

		/// <summary>
		/// タイトルヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void TitleHeader_Format(object sender, System.EventArgs eArgs)
		{
		}

		/// <summary>
		/// ページフッタフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// フッターレポート作成
				ListCommon_PageFooter rpt = new ListCommon_PageFooter();

				// フッター印字項目設定
				if (this._pageFooters[0] != null)
				{
					rpt.PrintFooter1 = this._pageFooters[0];
				}
				if (this._pageFooters[1] != null)
				{
					rpt.PrintFooter2 = this._pageFooters[1];
				}

				this.Footer_SubReport.Report = rpt;
			}
		}
		
		/// <summary>
		/// 明細アフタープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.15</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//TODO 1：Debugの時だけエラーが出る
			// 印刷件数カウントアップ
			this._printCount++;

			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this._printCount);
			}
		}
		#endregion
		
		// ===============================================================================
		// ActiveReportsデザイナで生成されたコード
		// ===============================================================================

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ExtraFooter_Format(object sender, System.EventArgs eArgs)
		{
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		/// <summary>
		/// InitializeComponent
		/// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHNB02012P_04A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SalesCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.SalesOrderDivName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.ListPriceTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCntPlusAdjustCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.Cost = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitDtl = new DataDynamics.ActiveReports.TextBox();
            this.GrossMarginMarkDtl = new DataDynamics.ActiveReports.TextBox();
            this.GrossMarginRateDtl = new DataDynamics.ActiveReports.TextBox();
            this.Label_Percentage = new DataDynamics.ActiveReports.Label();
            this.AddUpADate = new DataDynamics.ActiveReports.TextBox();
            this.Tax = new DataDynamics.ActiveReports.TextBox();
            this.ConsTaxLayMethod = new DataDynamics.ActiveReports.TextBox();
            this.TaxationDivCd = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipCdDtl = new DataDynamics.ActiveReports.TextBox();
            this.AcptAnOdrRemainCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesInputName = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipName = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentDay = new DataDynamics.ActiveReports.TextBox();
            this.SalesEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.FrontEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SearchSlipDate = new DataDynamics.ActiveReports.TextBox();
            this.BusinessTypeName = new DataDynamics.ActiveReports.TextBox();
            this.PartySaleSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.ModelFullName = new DataDynamics.ActiveReports.TextBox();
            this.CategoryDtl = new DataDynamics.ActiveReports.TextBox();
            this.FullModel = new DataDynamics.ActiveReports.TextBox();
            this.CarMngCode = new DataDynamics.ActiveReports.TextBox();
            this.FirstEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote = new DataDynamics.ActiveReports.TextBox();
            this.SlipNote2 = new DataDynamics.ActiveReports.TextBox();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.lblPage = new DataDynamics.ActiveReports.Label();
            this.txtPageNo = new DataDynamics.ActiveReports.TextBox();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.line28 = new DataDynamics.ActiveReports.Line();
            this.line46 = new DataDynamics.ActiveReports.Line();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.Extraction = new DataDynamics.ActiveReports.TextBox();
            this.Extraction2 = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.Label_GrossProfitDtl = new DataDynamics.ActiveReports.Label();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label39 = new DataDynamics.ActiveReports.Label();
            this.label41 = new DataDynamics.ActiveReports.Label();
            this.label42 = new DataDynamics.ActiveReports.Label();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.Label_CostTitle = new DataDynamics.ActiveReports.Label();
            this.label46 = new DataDynamics.ActiveReports.Label();
            this.label44 = new DataDynamics.ActiveReports.Label();
            this.label45 = new DataDynamics.ActiveReports.Label();
            this.label47 = new DataDynamics.ActiveReports.Label();
            this.label49 = new DataDynamics.ActiveReports.Label();
            this.Label_GrossMarginRateDtl = new DataDynamics.ActiveReports.Label();
            this.label51 = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.GlandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GlandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.Grand_TotalCostDtl = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesMoneyDtl = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesGrossProfitDtl = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Grand_SalesDtlTax = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.Section_TotalCostDtl = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesMoneyDtl = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesGrossProfitDtl = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Section_SalesDtlTax = new DataDynamics.ActiveReports.TextBox();
            this.Header1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Footer1 = new DataDynamics.ActiveReports.GroupFooter();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Footer1Field = new DataDynamics.ActiveReports.TextBox();
            this.f1_CntSalesDtl = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesMoneyDtl = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_TotalCostDtl = new DataDynamics.ActiveReports.TextBox();
            this.f1_SalesLbl = new DataDynamics.ActiveReports.Label();
            this.Footer1_SalesGrossProfitDtl = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Footer1_SalesDtlTax = new DataDynamics.ActiveReports.TextBox();
            this.Header2 = new DataDynamics.ActiveReports.GroupHeader();
            this.Footer2 = new DataDynamics.ActiveReports.GroupFooter();
            this.Footer2Field = new DataDynamics.ActiveReports.TextBox();
            this.f2_CntSalesDtl = new DataDynamics.ActiveReports.TextBox();
            this.Footer2_SalesMoneyDtl = new DataDynamics.ActiveReports.TextBox();
            this.Footer2_TotalCostDtl = new DataDynamics.ActiveReports.TextBox();
            this.f2_SalesLbl = new DataDynamics.ActiveReports.Label();
            this.Footer2_SalesGrossProfitDtl = new DataDynamics.ActiveReports.TextBox();
            this.Footer2_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Footer2_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.Footer2_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Footer2_SalesDtlTax = new DataDynamics.ActiveReports.TextBox();
            this.Footer2_ConsTaxLayMethod = new DataDynamics.ActiveReports.TextBox();
            this.Header3 = new DataDynamics.ActiveReports.GroupHeader();
            this.SlipNote3 = new DataDynamics.ActiveReports.TextBox();
            this.Footer3 = new DataDynamics.ActiveReports.GroupFooter();
            this.DateHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DateFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesMoneyDtl = new DataDynamics.ActiveReports.TextBox();
            this.Date_TotalCostDtl = new DataDynamics.ActiveReports.TextBox();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.Date_SalesGrossProfitDtl = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.Date_SalesDtlTax = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderDivName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCntPlusAdjustCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMarkDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginRateDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Percentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpADate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxationDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCdDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcptAnOdrRemainCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInputName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSlipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessTypeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarMngCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CostTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossMarginRateDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_TotalCostDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesMoneyDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesDtlTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalCostDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesMoneyDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesDtlTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CntSalesDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesMoneyDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_TotalCostDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_SalesLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesDtlTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CntSalesDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesMoneyDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_TotalCostDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_SalesLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesGrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesDtlTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_ConsTaxLayMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesMoneyDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_TotalCostDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossProfitDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesDtlTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SalesCode,
            this.BLGoodsCode,
            this.GoodsNo,
            this.SalesOrderDivName,
            this.GoodsName,
            this.ListPriceTaxExcFl,
            this.AcceptAnOrderCntPlusAdjustCnt,
            this.SalesUnitCost,
            this.SalesUnPrcTaxExcFl,
            this.Cost,
            this.SalesMoneyTaxExc,
            this.SupplierCd,
            this.SupplierSlipNo,
            this.WarehouseName,
            this.GrossProfitDtl,
            this.GrossMarginMarkDtl,
            this.GrossMarginRateDtl,
            this.Label_Percentage,
            this.AddUpADate,
            this.Tax,
            this.ConsTaxLayMethod,
            this.TaxationDivCd,
            this.SalesSlipCdDtl,
            this.AcptAnOdrRemainCnt});
            this.Detail.Height = 0.46875F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            // 
            // SalesCode
            // 
            this.SalesCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCode.CanGrow = false;
            this.SalesCode.DataField = "SalesCode";
            this.SalesCode.Height = 0.156F;
            this.SalesCode.Left = 3.5625F;
            this.SalesCode.Name = "SalesCode";
            this.SalesCode.OutputFormat = resources.GetString("SalesCode.OutputFormat");
            this.SalesCode.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesCode.Text = "1234";
            this.SalesCode.Top = 0.0625F;
            this.SalesCode.Width = 0.3125F;
            // 
            // BLGoodsCode
            // 
            this.BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.CanGrow = false;
            this.BLGoodsCode.DataField = "BLGoodsCode";
            this.BLGoodsCode.Height = 0.156F;
            this.BLGoodsCode.Left = 0.125F;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.BLGoodsCode.Text = "99999";
            this.BLGoodsCode.Top = 0.0625F;
            this.BLGoodsCode.Width = 0.375F;
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.CanGrow = false;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.156F;
            this.GoodsNo.Left = 0.5625F;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.375F;
            // 
            // SalesOrderDivName
            // 
            this.SalesOrderDivName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesOrderDivName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderDivName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesOrderDivName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderDivName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesOrderDivName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderDivName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesOrderDivName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderDivName.CanGrow = false;
            this.SalesOrderDivName.DataField = "SalesOrderDivName";
            this.SalesOrderDivName.Height = 0.156F;
            this.SalesOrderDivName.Left = 3.1875F;
            this.SalesOrderDivName.MultiLine = false;
            this.SalesOrderDivName.Name = "SalesOrderDivName";
            this.SalesOrderDivName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SalesOrderDivName.Text = "ぜん";
            this.SalesOrderDivName.Top = 0.0625F;
            this.SalesOrderDivName.Width = 0.3125F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.CanGrow = false;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.156F;
            this.GoodsName.Left = 2F;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.125F;
            // 
            // ListPriceTaxExcFl
            // 
            this.ListPriceTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.CanGrow = false;
            this.ListPriceTaxExcFl.DataField = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.Height = 0.156F;
            this.ListPriceTaxExcFl.Left = 3.9375F;
            this.ListPriceTaxExcFl.Name = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.OutputFormat = resources.GetString("ListPriceTaxExcFl.OutputFormat");
            this.ListPriceTaxExcFl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.ListPriceTaxExcFl.Text = "123,456,789";
            this.ListPriceTaxExcFl.Top = 0.0625F;
            this.ListPriceTaxExcFl.Width = 0.6875F;
            // 
            // AcceptAnOrderCntPlusAdjustCnt
            // 
            this.AcceptAnOrderCntPlusAdjustCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCntPlusAdjustCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCntPlusAdjustCnt.CanGrow = false;
            this.AcceptAnOrderCntPlusAdjustCnt.DataField = "AcceptAnOrderCntPlusAdjustCnt";
            this.AcceptAnOrderCntPlusAdjustCnt.Height = 0.156F;
            this.AcceptAnOrderCntPlusAdjustCnt.Left = 4.6875F;
            this.AcceptAnOrderCntPlusAdjustCnt.Name = "AcceptAnOrderCntPlusAdjustCnt";
            this.AcceptAnOrderCntPlusAdjustCnt.OutputFormat = resources.GetString("AcceptAnOrderCntPlusAdjustCnt.OutputFormat");
            this.AcceptAnOrderCntPlusAdjustCnt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.AcceptAnOrderCntPlusAdjustCnt.Text = "123,456.00";
            this.AcceptAnOrderCntPlusAdjustCnt.Top = 0.0625F;
            this.AcceptAnOrderCntPlusAdjustCnt.Width = 0.625F;
            // 
            // SalesUnitCost
            // 
            this.SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.CanGrow = false;
            this.SalesUnitCost.DataField = "SalesUnitCost";
            this.SalesUnitCost.Height = 0.156F;
            this.SalesUnitCost.Left = 5.375F;
            this.SalesUnitCost.Name = "SalesUnitCost";
            this.SalesUnitCost.OutputFormat = resources.GetString("SalesUnitCost.OutputFormat");
            this.SalesUnitCost.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesUnitCost.Text = "1,234,567.00";
            this.SalesUnitCost.Top = 0.0625F;
            this.SalesUnitCost.Width = 0.75F;
            // 
            // SalesUnPrcTaxExcFl
            // 
            this.SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.CanGrow = false;
            this.SalesUnPrcTaxExcFl.DataField = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.Height = 0.156F;
            this.SalesUnPrcTaxExcFl.Left = 6.1875F;
            this.SalesUnPrcTaxExcFl.Name = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.OutputFormat = resources.GetString("SalesUnPrcTaxExcFl.OutputFormat");
            this.SalesUnPrcTaxExcFl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesUnPrcTaxExcFl.Text = "1,234,567.00";
            this.SalesUnPrcTaxExcFl.Top = 0.0625F;
            this.SalesUnPrcTaxExcFl.Width = 0.75F;
            // 
            // Cost
            // 
            this.Cost.Border.BottomColor = System.Drawing.Color.Black;
            this.Cost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cost.Border.LeftColor = System.Drawing.Color.Black;
            this.Cost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cost.Border.RightColor = System.Drawing.Color.Black;
            this.Cost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cost.Border.TopColor = System.Drawing.Color.Black;
            this.Cost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cost.CanGrow = false;
            this.Cost.DataField = "Cost";
            this.Cost.Height = 0.156F;
            this.Cost.Left = 7.0625F;
            this.Cost.Name = "Cost";
            this.Cost.OutputFormat = resources.GetString("Cost.OutputFormat");
            this.Cost.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Cost.Text = "123,456,789";
            this.Cost.Top = 0.0625F;
            this.Cost.Width = 0.6875F;
            // 
            // SalesMoneyTaxExc
            // 
            this.SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.CanGrow = false;
            this.SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.Height = 0.156F;
            this.SalesMoneyTaxExc.Left = 7.875F;
            this.SalesMoneyTaxExc.Name = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.OutputFormat = resources.GetString("SalesMoneyTaxExc.OutputFormat");
            this.SalesMoneyTaxExc.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesMoneyTaxExc.Text = "123,456,789";
            this.SalesMoneyTaxExc.Top = 0.0625F;
            this.SalesMoneyTaxExc.Width = 0.6875F;
            // 
            // SupplierCd
            // 
            this.SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.CanGrow = false;
            this.SupplierCd.DataField = "SupplierCd";
            this.SupplierCd.Height = 0.156F;
            this.SupplierCd.Left = 0.125F;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SupplierCd.Text = "999999";
            this.SupplierCd.Top = 0.2185F;
            this.SupplierCd.Width = 0.4375F;
            // 
            // SupplierSlipNo
            // 
            this.SupplierSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNo.CanGrow = false;
            this.SupplierSlipNo.DataField = "SupplierSlipNo";
            this.SupplierSlipNo.Height = 0.156F;
            this.SupplierSlipNo.Left = 0.5625F;
            this.SupplierSlipNo.Name = "SupplierSlipNo";
            this.SupplierSlipNo.OutputFormat = resources.GetString("SupplierSlipNo.OutputFormat");
            this.SupplierSlipNo.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SupplierSlipNo.Text = "1234567890123456789";
            this.SupplierSlipNo.Top = 0.2185F;
            this.SupplierSlipNo.Width = 1.125F;
            // 
            // WarehouseName
            // 
            this.WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.CanGrow = false;
            this.WarehouseName.DataField = "WarehouseName";
            this.WarehouseName.Height = 0.156F;
            this.WarehouseName.Left = 2F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.WarehouseName.Text = "ぜんかくぜんかくぜん";
            this.WarehouseName.Top = 0.2185F;
            this.WarehouseName.Width = 1.1875F;
            // 
            // GrossProfitDtl
            // 
            this.GrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitDtl.CanGrow = false;
            this.GrossProfitDtl.DataField = "GrossProfitDtl";
            this.GrossProfitDtl.Height = 0.156F;
            this.GrossProfitDtl.Left = 9.3125F;
            this.GrossProfitDtl.Name = "GrossProfitDtl";
            this.GrossProfitDtl.OutputFormat = resources.GetString("GrossProfitDtl.OutputFormat");
            this.GrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.GrossProfitDtl.Text = "123,456,789";
            this.GrossProfitDtl.Top = 0.0625F;
            this.GrossProfitDtl.Width = 0.6875F;
            // 
            // GrossMarginMarkDtl
            // 
            this.GrossMarginMarkDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMarginMarkDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMarginMarkDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkDtl.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMarginMarkDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkDtl.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMarginMarkDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkDtl.CanGrow = false;
            this.GrossMarginMarkDtl.DataField = "GrossMarginMarkDtl";
            this.GrossMarginMarkDtl.Height = 0.156F;
            this.GrossMarginMarkDtl.Left = 10.625F;
            this.GrossMarginMarkDtl.Name = "GrossMarginMarkDtl";
            this.GrossMarginMarkDtl.OutputFormat = resources.GetString("GrossMarginMarkDtl.OutputFormat");
            this.GrossMarginMarkDtl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.GrossMarginMarkDtl.Text = "●";
            this.GrossMarginMarkDtl.Top = 0.0625F;
            this.GrossMarginMarkDtl.Width = 0.1875F;
            // 
            // GrossMarginRateDtl
            // 
            this.GrossMarginRateDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMarginRateDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRateDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMarginRateDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRateDtl.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMarginRateDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRateDtl.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMarginRateDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRateDtl.CanGrow = false;
            this.GrossMarginRateDtl.DataField = "GrossMarginRateDtl";
            this.GrossMarginRateDtl.Height = 0.156F;
            this.GrossMarginRateDtl.Left = 10.0625F;
            this.GrossMarginRateDtl.Name = "GrossMarginRateDtl";
            this.GrossMarginRateDtl.OutputFormat = resources.GetString("GrossMarginRateDtl.OutputFormat");
            this.GrossMarginRateDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ" +
                " ゴシック; white-space: nowrap; vertical-align: top; ";
            this.GrossMarginRateDtl.Text = "-100.00";
            this.GrossMarginRateDtl.Top = 0.0625F;
            this.GrossMarginRateDtl.Width = 0.4375F;
            // 
            // Label_Percentage
            // 
            this.Label_Percentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Height = 0.156F;
            this.Label_Percentage.HyperLink = "";
            this.Label_Percentage.Left = 10.5F;
            this.Label_Percentage.Name = "Label_Percentage";
            this.Label_Percentage.Style = "color: Black; ddo-char-set: 128; text-align: left; font-weight: normal; font-size" +
                ": 8pt; white-space: nowrap; vertical-align: top; ";
            this.Label_Percentage.Text = "％";
            this.Label_Percentage.Top = 0.0625F;
            this.Label_Percentage.Width = 0.125F;
            // 
            // AddUpADate
            // 
            this.AddUpADate.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpADate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpADate.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpADate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpADate.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpADate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpADate.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpADate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpADate.CanGrow = false;
            this.AddUpADate.DataField = "AddUpADate";
            this.AddUpADate.Height = 0.156F;
            this.AddUpADate.Left = 3.1875F;
            this.AddUpADate.Name = "AddUpADate";
            this.AddUpADate.OutputFormat = resources.GetString("AddUpADate.OutputFormat");
            this.AddUpADate.Style = "color: Black; ddo-char-set: 128; text-align: left; font-weight: normal; font-size" +
                ": 8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.AddUpADate.Text = "9999/99/99";
            this.AddUpADate.Top = 0.2185F;
            this.AddUpADate.Width = 0.625F;
            // 
            // Tax
            // 
            this.Tax.Border.BottomColor = System.Drawing.Color.Black;
            this.Tax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.Border.LeftColor = System.Drawing.Color.Black;
            this.Tax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.Border.RightColor = System.Drawing.Color.Black;
            this.Tax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.Border.TopColor = System.Drawing.Color.Black;
            this.Tax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.CanGrow = false;
            this.Tax.DataField = "Tax";
            this.Tax.Height = 0.156F;
            this.Tax.Left = 8.6875F;
            this.Tax.Name = "Tax";
            this.Tax.OutputFormat = resources.GetString("Tax.OutputFormat");
            this.Tax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Tax.Text = "1,234,567";
            this.Tax.Top = 0.0625F;
            this.Tax.Visible = false;
            this.Tax.Width = 0.5625F;
            // 
            // ConsTaxLayMethod
            // 
            this.ConsTaxLayMethod.Border.BottomColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.Border.LeftColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.Border.RightColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.Border.TopColor = System.Drawing.Color.Black;
            this.ConsTaxLayMethod.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxLayMethod.CanGrow = false;
            this.ConsTaxLayMethod.DataField = "ConsTaxLayMethod";
            this.ConsTaxLayMethod.Height = 0.156F;
            this.ConsTaxLayMethod.Left = 7.8125F;
            this.ConsTaxLayMethod.Name = "ConsTaxLayMethod";
            this.ConsTaxLayMethod.OutputFormat = resources.GetString("ConsTaxLayMethod.OutputFormat");
            this.ConsTaxLayMethod.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.ConsTaxLayMethod.Text = null;
            this.ConsTaxLayMethod.Top = 0.2185F;
            this.ConsTaxLayMethod.Visible = false;
            this.ConsTaxLayMethod.Width = 0.6875F;
            // 
            // TaxationDivCd
            // 
            this.TaxationDivCd.Border.BottomColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.Border.LeftColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.Border.RightColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.Border.TopColor = System.Drawing.Color.Black;
            this.TaxationDivCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxationDivCd.CanGrow = false;
            this.TaxationDivCd.DataField = "TaxationDivCd";
            this.TaxationDivCd.Height = 0.156F;
            this.TaxationDivCd.Left = 8.5F;
            this.TaxationDivCd.Name = "TaxationDivCd";
            this.TaxationDivCd.OutputFormat = resources.GetString("TaxationDivCd.OutputFormat");
            this.TaxationDivCd.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.TaxationDivCd.Text = null;
            this.TaxationDivCd.Top = 0.2185F;
            this.TaxationDivCd.Visible = false;
            this.TaxationDivCd.Width = 0.6875F;
            // 
            // SalesSlipCdDtl
            // 
            this.SalesSlipCdDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipCdDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdDtl.CanGrow = false;
            this.SalesSlipCdDtl.DataField = "SalesSlipCdDtl";
            this.SalesSlipCdDtl.Height = 0.156F;
            this.SalesSlipCdDtl.Left = 7.375F;
            this.SalesSlipCdDtl.Name = "SalesSlipCdDtl";
            this.SalesSlipCdDtl.OutputFormat = resources.GetString("SalesSlipCdDtl.OutputFormat");
            this.SalesSlipCdDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesSlipCdDtl.Text = "区分";
            this.SalesSlipCdDtl.Top = 0.2185F;
            this.SalesSlipCdDtl.Visible = false;
            this.SalesSlipCdDtl.Width = 0.375F;
            // 
            // AcptAnOdrRemainCnt
            // 
            this.AcptAnOdrRemainCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AcptAnOdrRemainCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcptAnOdrRemainCnt.CanGrow = false;
            this.AcptAnOdrRemainCnt.DataField = "AcptAnOdrRemainCnt";
            this.AcptAnOdrRemainCnt.Height = 0.156F;
            this.AcptAnOdrRemainCnt.Left = 4.6875F;
            this.AcptAnOdrRemainCnt.Name = "AcptAnOdrRemainCnt";
            this.AcptAnOdrRemainCnt.OutputFormat = resources.GetString("AcptAnOdrRemainCnt.OutputFormat");
            this.AcptAnOdrRemainCnt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.AcptAnOdrRemainCnt.Text = "123,456.00";
            this.AcptAnOdrRemainCnt.Top = 0.2185F;
            this.AcptAnOdrRemainCnt.Width = 0.625F;
            // 
            // SalesInputName
            // 
            this.SalesInputName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.CanGrow = false;
            this.SalesInputName.DataField = "SalesInputName";
            this.SalesInputName.Height = 0.156F;
            this.SalesInputName.Left = 6F;
            this.SalesInputName.MultiLine = false;
            this.SalesInputName.Name = "SalesInputName";
            this.SalesInputName.OutputFormat = resources.GetString("SalesInputName.OutputFormat");
            this.SalesInputName.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: inherit; vertical-align: top; ";
            this.SalesInputName.Text = "売上入力";
            this.SalesInputName.Top = 0.0625F;
            this.SalesInputName.Width = 0.5F;
            // 
            // SalesSlipName
            // 
            this.SalesSlipName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.CanGrow = false;
            this.SalesSlipName.DataField = "SalesSlipName";
            this.SalesSlipName.Height = 0.156F;
            this.SalesSlipName.Left = 4.3125F;
            this.SalesSlipName.MultiLine = false;
            this.SalesSlipName.Name = "SalesSlipName";
            this.SalesSlipName.OutputFormat = resources.GetString("SalesSlipName.OutputFormat");
            this.SalesSlipName.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: inherit; vertical-align: top; ";
            this.SalesSlipName.Text = "伝票区分";
            this.SalesSlipName.Top = 0.0625F;
            this.SalesSlipName.Width = 0.5F;
            // 
            // SalesSlipNum
            // 
            this.SalesSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.CanGrow = false;
            this.SalesSlipNum.DataField = "SalesSlipNum";
            this.SalesSlipNum.Height = 0.156F;
            this.SalesSlipNum.Left = 3.6875F;
            this.SalesSlipNum.Name = "SalesSlipNum";
            this.SalesSlipNum.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.SalesSlipNum.Text = "999999999";
            this.SalesSlipNum.Top = 0.0625F;
            this.SalesSlipNum.Width = 0.5625F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.CanGrow = false;
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.156F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.CustomerCode.Text = "99999999";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.5F;
            // 
            // CustomerSnm
            // 
            this.CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.CanGrow = false;
            this.CustomerSnm.DataField = "CustomerSnm";
            this.CustomerSnm.Height = 0.156F;
            this.CustomerSnm.Left = 0.5625F;
            this.CustomerSnm.MultiLine = false;
            this.CustomerSnm.Name = "CustomerSnm";
            this.CustomerSnm.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.CustomerSnm.Text = "ぜんかくぜんかくぜんかくぜんか";
            this.CustomerSnm.Top = 0.0625F;
            this.CustomerSnm.Width = 1.75F;
            // 
            // ShipmentDay
            // 
            this.ShipmentDay.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentDay.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentDay.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentDay.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentDay.CanGrow = false;
            this.ShipmentDay.DataField = "ShipmentDay";
            this.ShipmentDay.Height = 0.156F;
            this.ShipmentDay.Left = 2.3125F;
            this.ShipmentDay.Name = "ShipmentDay";
            this.ShipmentDay.OutputFormat = resources.GetString("ShipmentDay.OutputFormat");
            this.ShipmentDay.Style = "color: Black; ddo-char-set: 128; text-align: left; font-weight: normal; font-size" +
                ": 8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.ShipmentDay.Text = "9999/99/99";
            this.ShipmentDay.Top = 0.0625F;
            this.ShipmentDay.Width = 0.625F;
            // 
            // SalesEmployeeNm
            // 
            this.SalesEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.CanGrow = false;
            this.SalesEmployeeNm.DataField = "SalesEmployeeNm";
            this.SalesEmployeeNm.Height = 0.156F;
            this.SalesEmployeeNm.Left = 4.875F;
            this.SalesEmployeeNm.MultiLine = false;
            this.SalesEmployeeNm.Name = "SalesEmployeeNm";
            this.SalesEmployeeNm.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; white-space: " +
                "inherit; vertical-align: top; ";
            this.SalesEmployeeNm.Text = "販売従業";
            this.SalesEmployeeNm.Top = 0.0625F;
            this.SalesEmployeeNm.Width = 0.5F;
            // 
            // FrontEmployeeNm
            // 
            this.FrontEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.CanGrow = false;
            this.FrontEmployeeNm.DataField = "FrontEmployeeNm";
            this.FrontEmployeeNm.Height = 0.156F;
            this.FrontEmployeeNm.Left = 5.4375F;
            this.FrontEmployeeNm.MultiLine = false;
            this.FrontEmployeeNm.Name = "FrontEmployeeNm";
            this.FrontEmployeeNm.OutputFormat = resources.GetString("FrontEmployeeNm.OutputFormat");
            this.FrontEmployeeNm.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: inherit; vertical-align: top; ";
            this.FrontEmployeeNm.Text = "受付従業";
            this.FrontEmployeeNm.Top = 0.0625F;
            this.FrontEmployeeNm.Width = 0.5F;
            // 
            // SearchSlipDate
            // 
            this.SearchSlipDate.Border.BottomColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.LeftColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.RightColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.TopColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.CanGrow = false;
            this.SearchSlipDate.DataField = "SearchSlipDate";
            this.SearchSlipDate.Height = 0.156F;
            this.SearchSlipDate.Left = 3F;
            this.SearchSlipDate.Name = "SearchSlipDate";
            this.SearchSlipDate.OutputFormat = resources.GetString("SearchSlipDate.OutputFormat");
            this.SearchSlipDate.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.SearchSlipDate.Text = "9999/99/99";
            this.SearchSlipDate.Top = 0.0625F;
            this.SearchSlipDate.Width = 0.625F;
            // 
            // BusinessTypeName
            // 
            this.BusinessTypeName.Border.BottomColor = System.Drawing.Color.Black;
            this.BusinessTypeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessTypeName.Border.LeftColor = System.Drawing.Color.Black;
            this.BusinessTypeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessTypeName.Border.RightColor = System.Drawing.Color.Black;
            this.BusinessTypeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessTypeName.Border.TopColor = System.Drawing.Color.Black;
            this.BusinessTypeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessTypeName.CanGrow = false;
            this.BusinessTypeName.DataField = "BusinessTypeName";
            this.BusinessTypeName.Height = 0.156F;
            this.BusinessTypeName.Left = 6.5625F;
            this.BusinessTypeName.MultiLine = false;
            this.BusinessTypeName.Name = "BusinessTypeName";
            this.BusinessTypeName.OutputFormat = resources.GetString("BusinessTypeName.OutputFormat");
            this.BusinessTypeName.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: inherit; vertical-align: top; ";
            this.BusinessTypeName.Text = "業種１２";
            this.BusinessTypeName.Top = 0.0625F;
            this.BusinessTypeName.Width = 0.5F;
            // 
            // PartySaleSlipNum
            // 
            this.PartySaleSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.CanGrow = false;
            this.PartySaleSlipNum.DataField = "PartySaleSlipNum";
            this.PartySaleSlipNum.Height = 0.156F;
            this.PartySaleSlipNum.Left = 9.4375F;
            this.PartySaleSlipNum.Name = "PartySaleSlipNum";
            this.PartySaleSlipNum.OutputFormat = resources.GetString("PartySaleSlipNum.OutputFormat");
            this.PartySaleSlipNum.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.PartySaleSlipNum.Text = "01234567890123456789";
            this.PartySaleSlipNum.Top = 0.0625F;
            this.PartySaleSlipNum.Width = 1.1875F;
            // 
            // ModelFullName
            // 
            this.ModelFullName.Border.BottomColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.LeftColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.RightColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.TopColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.CanGrow = false;
            this.ModelFullName.DataField = "ModelFullName";
            this.ModelFullName.Height = 0.156F;
            this.ModelFullName.Left = 0.625F;
            this.ModelFullName.MultiLine = false;
            this.ModelFullName.Name = "ModelFullName";
            this.ModelFullName.OutputFormat = resources.GetString("ModelFullName.OutputFormat");
            this.ModelFullName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.ModelFullName.Text = "1234567890";
            this.ModelFullName.Top = 0.2185F;
            this.ModelFullName.Width = 0.625F;
            // 
            // CategoryDtl
            // 
            this.CategoryDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.Border.RightColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.Border.TopColor = System.Drawing.Color.Black;
            this.CategoryDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryDtl.CanGrow = false;
            this.CategoryDtl.DataField = "CategoryDtl";
            this.CategoryDtl.Height = 0.156F;
            this.CategoryDtl.Left = 0F;
            this.CategoryDtl.MultiLine = false;
            this.CategoryDtl.Name = "CategoryDtl";
            this.CategoryDtl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.CategoryDtl.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.CategoryDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.CategoryDtl.Text = "00000-0000";
            this.CategoryDtl.Top = 0.2185F;
            this.CategoryDtl.Width = 0.625F;
            // 
            // FullModel
            // 
            this.FullModel.Border.BottomColor = System.Drawing.Color.Black;
            this.FullModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.LeftColor = System.Drawing.Color.Black;
            this.FullModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.RightColor = System.Drawing.Color.Black;
            this.FullModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.TopColor = System.Drawing.Color.Black;
            this.FullModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.CanGrow = false;
            this.FullModel.DataField = "FullModel";
            this.FullModel.Height = 0.156F;
            this.FullModel.Left = 1.25F;
            this.FullModel.MultiLine = false;
            this.FullModel.Name = "FullModel";
            this.FullModel.OutputFormat = resources.GetString("FullModel.OutputFormat");
            this.FullModel.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.FullModel.Text = "123456789012345678901234567890123456";
            this.FullModel.Top = 0.2185F;
            this.FullModel.Width = 2.0625F;
            // 
            // CarMngCode
            // 
            this.CarMngCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.RightColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.TopColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.CanGrow = false;
            this.CarMngCode.DataField = "CarMngCode";
            this.CarMngCode.Height = 0.156F;
            this.CarMngCode.Left = 3.375F;
            this.CarMngCode.MultiLine = false;
            this.CarMngCode.Name = "CarMngCode";
            this.CarMngCode.OutputFormat = resources.GetString("CarMngCode.OutputFormat");
            this.CarMngCode.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.CarMngCode.Text = "123456789012345678";
            this.CarMngCode.Top = 0.2185F;
            this.CarMngCode.Width = 1.0625F;
            // 
            // FirstEntryDate
            // 
            this.FirstEntryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.RightColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.TopColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.CanGrow = false;
            this.FirstEntryDate.DataField = "FirstEntryDate";
            this.FirstEntryDate.Height = 0.156F;
            this.FirstEntryDate.Left = 4.5F;
            this.FirstEntryDate.Name = "FirstEntryDate";
            this.FirstEntryDate.OutputFormat = resources.GetString("FirstEntryDate.OutputFormat");
            this.FirstEntryDate.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.FirstEntryDate.Text = "9999/99";
            this.FirstEntryDate.Top = 0.2185F;
            this.FirstEntryDate.Width = 0.4375F;
            // 
            // SlipNote
            // 
            this.SlipNote.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.CanGrow = false;
            this.SlipNote.DataField = "SlipNote";
            this.SlipNote.Height = 0.156F;
            this.SlipNote.Left = 7.125F;
            this.SlipNote.MultiLine = false;
            this.SlipNote.Name = "SlipNote";
            this.SlipNote.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SlipNote.Text = "ぜんかくぜんかくぜんかくぜんかくぜんかく";
            this.SlipNote.Top = 0.0625F;
            this.SlipNote.Width = 2.25F;
            // 
            // SlipNote2
            // 
            this.SlipNote2.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote2.CanGrow = false;
            this.SlipNote2.DataField = "SlipNote2";
            this.SlipNote2.Height = 0.156F;
            this.SlipNote2.Left = 5F;
            this.SlipNote2.MultiLine = false;
            this.SlipNote2.Name = "SlipNote2";
            this.SlipNote2.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SlipNote2.Text = "ぜんかくぜんかくぜんかくぜんかくぜんかく";
            this.SlipNote2.Top = 0.2185F;
            this.SlipNote2.Width = 2.25F;
            // 
            // line14
            // 
            this.line14.Border.BottomColor = System.Drawing.Color.Black;
            this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.LeftColor = System.Drawing.Color.Black;
            this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.RightColor = System.Drawing.Color.Black;
            this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.TopColor = System.Drawing.Color.Black;
            this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Height = 0F;
            this.line14.Left = 0F;
            this.line14.LineWeight = 2F;
            this.line14.Name = "line14";
            this.line14.Top = 0F;
            this.line14.Width = 10.8125F;
            this.line14.X1 = 0F;
            this.line14.X2 = 10.8125F;
            this.line14.Y1 = 0F;
            this.line14.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DATE,
            this.TIME,
            this.lblTitle,
            this.lblPage,
            this.txtPageNo,
            this.label40,
            this.line28,
            this.line46,
            this.SORTTITLE});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // DATE
            // 
            this.DATE.Border.BottomColor = System.Drawing.Color.Black;
            this.DATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.LeftColor = System.Drawing.Color.Black;
            this.DATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.RightColor = System.Drawing.Color.Black;
            this.DATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.TopColor = System.Drawing.Color.Black;
            this.DATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Height = 0.156F;
            this.DATE.Left = 8.5F;
            this.DATE.Name = "DATE";
            this.DATE.OutputFormat = resources.GetString("DATE.OutputFormat");
            this.DATE.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.063F;
            this.DATE.Width = 0.938F;
            // 
            // TIME
            // 
            this.TIME.Border.BottomColor = System.Drawing.Color.Black;
            this.TIME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.LeftColor = System.Drawing.Color.Black;
            this.TIME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.RightColor = System.Drawing.Color.Black;
            this.TIME.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.TopColor = System.Drawing.Color.Black;
            this.TIME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Height = 0.125F;
            this.TIME.Left = 9.438F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.063F;
            this.TIME.Width = 0.5F;
            // 
            // lblTitle
            // 
            this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Height = 0.25F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0.25F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: Black; ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: " +
                "14.25pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.lblTitle.Text = "貸出確認表（明細タイプ）";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 2.563F;
            // 
            // lblPage
            // 
            this.lblPage.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.RightColor = System.Drawing.Color.Black;
            this.lblPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.TopColor = System.Drawing.Color.Black;
            this.lblPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Height = 0.156F;
            this.lblPage.HyperLink = null;
            this.lblPage.Left = 9.938F;
            this.lblPage.Name = "lblPage";
            this.lblPage.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.lblPage.Text = "ページ：";
            this.lblPage.Top = 0.063F;
            this.lblPage.Width = 0.5F;
            // 
            // txtPageNo
            // 
            this.txtPageNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Height = 0.156F;
            this.txtPageNo.Left = 10.438F;
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.txtPageNo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtPageNo.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtPageNo.Text = null;
            this.txtPageNo.Top = 0.063F;
            this.txtPageNo.Width = 0.281F;
            // 
            // label40
            // 
            this.label40.Border.BottomColor = System.Drawing.Color.Black;
            this.label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.LeftColor = System.Drawing.Color.Black;
            this.label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.RightColor = System.Drawing.Color.Black;
            this.label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.TopColor = System.Drawing.Color.Black;
            this.label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Height = 0.156F;
            this.label40.HyperLink = null;
            this.label40.Left = 7.938F;
            this.label40.Name = "label40";
            this.label40.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.label40.Text = "作成日付：";
            this.label40.Top = 0.063F;
            this.label40.Width = 0.625F;
            // 
            // line28
            // 
            this.line28.Border.BottomColor = System.Drawing.Color.Black;
            this.line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.LeftColor = System.Drawing.Color.Black;
            this.line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.RightColor = System.Drawing.Color.Black;
            this.line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.TopColor = System.Drawing.Color.Black;
            this.line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Height = 0F;
            this.line28.Left = 0F;
            this.line28.LineColor = System.Drawing.Color.LimeGreen;
            this.line28.LineWeight = 2F;
            this.line28.Name = "line28";
            this.line28.Top = 0.3125F;
            this.line28.Width = 11.25F;
            this.line28.X1 = 0F;
            this.line28.X2 = 11.25F;
            this.line28.Y1 = 0.3125F;
            this.line28.Y2 = 0.3125F;
            // 
            // line46
            // 
            this.line46.Border.BottomColor = System.Drawing.Color.Black;
            this.line46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.LeftColor = System.Drawing.Color.Black;
            this.line46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.RightColor = System.Drawing.Color.Black;
            this.line46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.TopColor = System.Drawing.Color.Black;
            this.line46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Height = 0F;
            this.line46.Left = 0F;
            this.line46.LineWeight = 3F;
            this.line46.Name = "line46";
            this.line46.Top = 0.22F;
            this.line46.Width = 10.8F;
            this.line46.X1 = 0F;
            this.line46.X2 = 10.8F;
            this.line46.Y1 = 0.22F;
            this.line46.Y2 = 0.22F;
            // 
            // SORTTITLE
            // 
            this.SORTTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Height = 0.188F;
            this.SORTTITLE.Left = 3.125F;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.SORTTITLE.Text = null;
            this.SORTTITLE.Top = 0.063F;
            this.SORTTITLE.Width = 2.688F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Footer_SubReport
            // 
            this.Footer_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.CloseBorder = false;
            this.Footer_SubReport.Height = 0.188F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.81F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label2,
            this.Extraction,
            this.Extraction2,
            this.line1});
            this.ExtraHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.ExtraHeader.Height = 0.3645833F;
            this.ExtraHeader.KeepTogether = true;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.125F;
            this.label2.HyperLink = null;
            this.label2.Left = 0F;
            this.label2.Name = "label2";
            this.label2.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.label2.Text = "粗利チェックリスト範囲";
            this.label2.Top = 0.1875F;
            this.label2.Width = 1.375F;
            // 
            // Extraction
            // 
            this.Extraction.Border.BottomColor = System.Drawing.Color.Black;
            this.Extraction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.LeftColor = System.Drawing.Color.Black;
            this.Extraction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.RightColor = System.Drawing.Color.Black;
            this.Extraction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.TopColor = System.Drawing.Color.Black;
            this.Extraction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Height = 0.125F;
            this.Extraction.Left = 0F;
            this.Extraction.Name = "Extraction";
            this.Extraction.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.Extraction.Text = null;
            this.Extraction.Top = 0F;
            this.Extraction.Width = 10.75F;
            // 
            // Extraction2
            // 
            this.Extraction2.Border.BottomColor = System.Drawing.Color.Black;
            this.Extraction2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Border.LeftColor = System.Drawing.Color.Black;
            this.Extraction2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Border.RightColor = System.Drawing.Color.Black;
            this.Extraction2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Border.TopColor = System.Drawing.Color.Black;
            this.Extraction2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Height = 0.125F;
            this.Extraction2.Left = 1.4375F;
            this.Extraction2.Name = "Extraction2";
            this.Extraction2.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.Extraction2.Text = null;
            this.Extraction2.Top = 0.1875F;
            this.Extraction2.Width = 9.3125F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 2F;
            this.line1.Name = "line1";
            this.line1.Top = 0.16F;
            this.line1.Width = 10.8F;
            this.line1.X1 = 0F;
            this.line1.X2 = 10.8F;
            this.line1.Y1 = 0.16F;
            this.line1.Y2 = 0.16F;
            // 
            // textBox28
            // 
            this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.RightColor = System.Drawing.Color.Black;
            this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.TopColor = System.Drawing.Color.Black;
            this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.DataField = "SectionGuideNm";
            this.textBox28.Height = 0.156F;
            this.textBox28.Left = 0.5F;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "font-size: 8pt; vertical-align: top; ";
            this.textBox28.Text = null;
            this.textBox28.Top = 0.0625F;
            this.textBox28.Width = 1.1875F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.156F;
            this.label6.HyperLink = null;
            this.label6.Left = 0F;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; vertical-align" +
                ": top; ";
            this.label6.Text = "拠点";
            this.label6.Top = 0.0625F;
            this.label6.Width = 0.3125F;
            // 
            // textBox29
            // 
            this.textBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.RightColor = System.Drawing.Color.Black;
            this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.TopColor = System.Drawing.Color.Black;
            this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Height = 0.156F;
            this.textBox29.Left = 2F;
            this.textBox29.Name = "textBox29";
            this.textBox29.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.textBox29.Text = null;
            this.textBox29.Top = 0.0625F;
            this.textBox29.Width = 0.375F;
            // 
            // textBox30
            // 
            this.textBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.RightColor = System.Drawing.Color.Black;
            this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.TopColor = System.Drawing.Color.Black;
            this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Height = 0.156F;
            this.textBox30.Left = 2.375F;
            this.textBox30.Name = "textBox30";
            this.textBox30.Style = "font-size: 8pt; vertical-align: top; ";
            this.textBox30.Text = null;
            this.textBox30.Top = 0.0625F;
            this.textBox30.Width = 2.25F;
            // 
            // textBox27
            // 
            this.textBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.RightColor = System.Drawing.Color.Black;
            this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.TopColor = System.Drawing.Color.Black;
            this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.DataField = "SectionCode";
            this.textBox27.Height = 0.156F;
            this.textBox27.Left = 0.3125F;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox27.Text = "01";
            this.textBox27.Top = 0.0625F;
            this.textBox27.Width = 0.1875F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Format += new System.EventHandler(this.ExtraFooter_Format);
            // 
            // TitleHeader1
            // 
            this.TitleHeader1.CanShrink = true;
            this.TitleHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label11,
            this.label8,
            this.label3,
            this.label7,
            this.Label9,
            this.Label13,
            this.label10,
            this.label12,
            this.label19,
            this.label23,
            this.label14,
            this.label15,
            this.label16,
            this.label17,
            this.label18,
            this.Label_GrossProfitDtl,
            this.label38,
            this.label20,
            this.label21,
            this.label22,
            this.label24,
            this.label39,
            this.label41,
            this.label42,
            this.label43,
            this.Label_CostTitle,
            this.label46,
            this.label44,
            this.label45,
            this.label47,
            this.label49,
            this.Label_GrossMarginRateDtl,
            this.label51,
            this.line6,
            this.label4,
            this.label5,
            this.label25,
            this.label31});
            this.TitleHeader1.Height = 0.7916667F;
            this.TitleHeader1.Name = "TitleHeader1";
            this.TitleHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.156F;
            this.label11.HyperLink = "";
            this.label11.Left = 6.5625F;
            this.label11.Name = "label11";
            this.label11.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label11.Text = "業種";
            this.label11.Top = 0.0625F;
            this.label11.Width = 0.5F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.156F;
            this.label8.HyperLink = "";
            this.label8.Left = 6F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label8.Text = "発行者";
            this.label8.Top = 0.0625F;
            this.label8.Width = 0.5F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.156F;
            this.label3.HyperLink = "";
            this.label3.Left = 0.625F;
            this.label3.Name = "label3";
            this.label3.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label3.Text = "車種";
            this.label3.Top = 0.2185F;
            this.label3.Width = 0.5625F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.156F;
            this.label7.HyperLink = "";
            this.label7.Left = 0F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label7.Text = "類別";
            this.label7.Top = 0.2185F;
            this.label7.Width = 0.625F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.156F;
            this.Label9.HyperLink = "";
            this.Label9.Left = 0.5625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label9.Text = "品番";
            this.Label9.Top = 0.3745F;
            this.Label9.Width = 0.375F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.156F;
            this.Label13.HyperLink = "";
            this.Label13.Left = 0.125F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Label13.Text = "仕入先";
            this.Label13.Top = 0.5305F;
            this.Label13.Width = 0.4375F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.156F;
            this.label10.HyperLink = "";
            this.label10.Left = 4.6875F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label10.Text = "数量";
            this.label10.Top = 0.3745F;
            this.label10.Width = 0.625F;
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.156F;
            this.label12.HyperLink = "";
            this.label12.Left = 3.5625F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label12.Text = "販区";
            this.label12.Top = 0.3745F;
            this.label12.Width = 0.3125F;
            // 
            // label19
            // 
            this.label19.Border.BottomColor = System.Drawing.Color.Black;
            this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.LeftColor = System.Drawing.Color.Black;
            this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.RightColor = System.Drawing.Color.Black;
            this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.TopColor = System.Drawing.Color.Black;
            this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Height = 0.156F;
            this.label19.HyperLink = "";
            this.label19.Left = 3.6875F;
            this.label19.Name = "label19";
            this.label19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label19.Text = "伝票番号";
            this.label19.Top = 0.0625F;
            this.label19.Width = 0.5625F;
            // 
            // label23
            // 
            this.label23.Border.BottomColor = System.Drawing.Color.Black;
            this.label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.LeftColor = System.Drawing.Color.Black;
            this.label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.RightColor = System.Drawing.Color.Black;
            this.label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.TopColor = System.Drawing.Color.Black;
            this.label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Height = 0.156F;
            this.label23.HyperLink = "";
            this.label23.Left = 0F;
            this.label23.Name = "label23";
            this.label23.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label23.Text = "得意先";
            this.label23.Top = 0.0625F;
            this.label23.Width = 0.5625F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.156F;
            this.label14.HyperLink = "";
            this.label14.Left = 2.3125F;
            this.label14.Name = "label14";
            this.label14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label14.Text = "貸出日";
            this.label14.Top = 0.0625F;
            this.label14.Width = 0.625F;
            // 
            // label15
            // 
            this.label15.Border.BottomColor = System.Drawing.Color.Black;
            this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.LeftColor = System.Drawing.Color.Black;
            this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.RightColor = System.Drawing.Color.Black;
            this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.TopColor = System.Drawing.Color.Black;
            this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Height = 0.156F;
            this.label15.HyperLink = "";
            this.label15.Left = 2F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label15.Text = "倉庫";
            this.label15.Top = 0.5305F;
            this.label15.Width = 0.5F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.156F;
            this.label16.HyperLink = "";
            this.label16.Left = 4.875F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label16.Text = "担当者";
            this.label16.Top = 0.0625F;
            this.label16.Width = 0.5F;
            // 
            // label17
            // 
            this.label17.Border.BottomColor = System.Drawing.Color.Black;
            this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.LeftColor = System.Drawing.Color.Black;
            this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.RightColor = System.Drawing.Color.Black;
            this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.TopColor = System.Drawing.Color.Black;
            this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Height = 0.156F;
            this.label17.HyperLink = "";
            this.label17.Left = 5.4375F;
            this.label17.Name = "label17";
            this.label17.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label17.Text = "受注者";
            this.label17.Top = 0.0625F;
            this.label17.Width = 0.5F;
            // 
            // label18
            // 
            this.label18.Border.BottomColor = System.Drawing.Color.Black;
            this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.LeftColor = System.Drawing.Color.Black;
            this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.RightColor = System.Drawing.Color.Black;
            this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.TopColor = System.Drawing.Color.Black;
            this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Height = 0.156F;
            this.label18.HyperLink = "";
            this.label18.Left = 7.875F;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label18.Text = "金額";
            this.label18.Top = 0.3745F;
            this.label18.Width = 0.6875F;
            // 
            // Label_GrossProfitDtl
            // 
            this.Label_GrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_GrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_GrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Label_GrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Label_GrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossProfitDtl.Height = 0.156F;
            this.Label_GrossProfitDtl.HyperLink = "";
            this.Label_GrossProfitDtl.Left = 9.3125F;
            this.Label_GrossProfitDtl.Name = "Label_GrossProfitDtl";
            this.Label_GrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.Label_GrossProfitDtl.Text = "粗利";
            this.Label_GrossProfitDtl.Top = 0.3745F;
            this.Label_GrossProfitDtl.Width = 0.6875F;
            // 
            // label38
            // 
            this.label38.Border.BottomColor = System.Drawing.Color.Black;
            this.label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.LeftColor = System.Drawing.Color.Black;
            this.label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.RightColor = System.Drawing.Color.Black;
            this.label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Border.TopColor = System.Drawing.Color.Black;
            this.label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label38.Height = 0.156F;
            this.label38.HyperLink = "";
            this.label38.Left = 3F;
            this.label38.Name = "label38";
            this.label38.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label38.Text = "入力日";
            this.label38.Top = 0.0625F;
            this.label38.Width = 0.625F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Height = 0.156F;
            this.label20.HyperLink = "";
            this.label20.Left = 1.25F;
            this.label20.Name = "label20";
            this.label20.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label20.Text = "型式";
            this.label20.Top = 0.2185F;
            this.label20.Width = 0.5625F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Height = 0.156F;
            this.label21.HyperLink = "";
            this.label21.Left = 3.375F;
            this.label21.Name = "label21";
            this.label21.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label21.Text = "管理番号";
            this.label21.Top = 0.2185F;
            this.label21.Width = 0.5625F;
            // 
            // label22
            // 
            this.label22.Border.BottomColor = System.Drawing.Color.Black;
            this.label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.LeftColor = System.Drawing.Color.Black;
            this.label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.RightColor = System.Drawing.Color.Black;
            this.label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.TopColor = System.Drawing.Color.Black;
            this.label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Height = 0.156F;
            this.label22.HyperLink = "";
            this.label22.Left = 0.125F;
            this.label22.Name = "label22";
            this.label22.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label22.Text = "BLｺｰﾄﾞ";
            this.label22.Top = 0.3745F;
            this.label22.Width = 0.4375F;
            // 
            // label24
            // 
            this.label24.Border.BottomColor = System.Drawing.Color.Black;
            this.label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.LeftColor = System.Drawing.Color.Black;
            this.label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.RightColor = System.Drawing.Color.Black;
            this.label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.TopColor = System.Drawing.Color.Black;
            this.label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Height = 0.156F;
            this.label24.HyperLink = "";
            this.label24.Left = 3.1875F;
            this.label24.Name = "label24";
            this.label24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label24.Text = "在取";
            this.label24.Top = 0.3745F;
            this.label24.Width = 0.3125F;
            // 
            // label39
            // 
            this.label39.Border.BottomColor = System.Drawing.Color.Black;
            this.label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.LeftColor = System.Drawing.Color.Black;
            this.label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.RightColor = System.Drawing.Color.Black;
            this.label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Border.TopColor = System.Drawing.Color.Black;
            this.label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label39.Height = 0.156F;
            this.label39.HyperLink = "";
            this.label39.Left = 2F;
            this.label39.Name = "label39";
            this.label39.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label39.Text = "品名";
            this.label39.Top = 0.3745F;
            this.label39.Width = 0.375F;
            // 
            // label41
            // 
            this.label41.Border.BottomColor = System.Drawing.Color.Black;
            this.label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.LeftColor = System.Drawing.Color.Black;
            this.label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.RightColor = System.Drawing.Color.Black;
            this.label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Border.TopColor = System.Drawing.Color.Black;
            this.label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label41.Height = 0.156F;
            this.label41.HyperLink = "";
            this.label41.Left = 3.9375F;
            this.label41.Name = "label41";
            this.label41.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label41.Text = "標準価格";
            this.label41.Top = 0.3745F;
            this.label41.Width = 0.6875F;
            // 
            // label42
            // 
            this.label42.Border.BottomColor = System.Drawing.Color.Black;
            this.label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.LeftColor = System.Drawing.Color.Black;
            this.label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.RightColor = System.Drawing.Color.Black;
            this.label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Border.TopColor = System.Drawing.Color.Black;
            this.label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label42.Height = 0.156F;
            this.label42.HyperLink = "";
            this.label42.Left = 5.375F;
            this.label42.Name = "label42";
            this.label42.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label42.Text = "原単価";
            this.label42.Top = 0.3745F;
            this.label42.Width = 0.75F;
            // 
            // label43
            // 
            this.label43.Border.BottomColor = System.Drawing.Color.Black;
            this.label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Border.LeftColor = System.Drawing.Color.Black;
            this.label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Border.RightColor = System.Drawing.Color.Black;
            this.label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Border.TopColor = System.Drawing.Color.Black;
            this.label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label43.Height = 0.156F;
            this.label43.HyperLink = "";
            this.label43.Left = 6.1875F;
            this.label43.Name = "label43";
            this.label43.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label43.Text = "売単価";
            this.label43.Top = 0.3745F;
            this.label43.Width = 0.75F;
            // 
            // Label_CostTitle
            // 
            this.Label_CostTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_CostTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CostTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_CostTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CostTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Label_CostTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CostTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Label_CostTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CostTitle.Height = 0.156F;
            this.Label_CostTitle.HyperLink = "";
            this.Label_CostTitle.Left = 7.0625F;
            this.Label_CostTitle.Name = "Label_CostTitle";
            this.Label_CostTitle.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; vertical-align: top; ";
            this.Label_CostTitle.Text = "原価";
            this.Label_CostTitle.Top = 0.3745F;
            this.Label_CostTitle.Width = 0.6875F;
            // 
            // label46
            // 
            this.label46.Border.BottomColor = System.Drawing.Color.Black;
            this.label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.LeftColor = System.Drawing.Color.Black;
            this.label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.RightColor = System.Drawing.Color.Black;
            this.label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.TopColor = System.Drawing.Color.Black;
            this.label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Height = 0.156F;
            this.label46.HyperLink = "";
            this.label46.Left = 3.1875F;
            this.label46.Name = "label46";
            this.label46.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label46.Text = "計上日";
            this.label46.Top = 0.5305F;
            this.label46.Width = 0.625F;
            // 
            // label44
            // 
            this.label44.Border.BottomColor = System.Drawing.Color.Black;
            this.label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Border.LeftColor = System.Drawing.Color.Black;
            this.label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Border.RightColor = System.Drawing.Color.Black;
            this.label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Border.TopColor = System.Drawing.Color.Black;
            this.label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label44.Height = 0.156F;
            this.label44.HyperLink = "";
            this.label44.Left = 4.5F;
            this.label44.Name = "label44";
            this.label44.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label44.Text = "年式";
            this.label44.Top = 0.2185F;
            this.label44.Width = 0.4375F;
            // 
            // label45
            // 
            this.label45.Border.BottomColor = System.Drawing.Color.Black;
            this.label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Border.LeftColor = System.Drawing.Color.Black;
            this.label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Border.RightColor = System.Drawing.Color.Black;
            this.label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Border.TopColor = System.Drawing.Color.Black;
            this.label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label45.Height = 0.156F;
            this.label45.HyperLink = "";
            this.label45.Left = 9.4375F;
            this.label45.Name = "label45";
            this.label45.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label45.Text = "仮伝番号";
            this.label45.Top = 0.0625F;
            this.label45.Width = 1.1875F;
            // 
            // label47
            // 
            this.label47.Border.BottomColor = System.Drawing.Color.Black;
            this.label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Border.LeftColor = System.Drawing.Color.Black;
            this.label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Border.RightColor = System.Drawing.Color.Black;
            this.label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Border.TopColor = System.Drawing.Color.Black;
            this.label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label47.Height = 0.156F;
            this.label47.HyperLink = "";
            this.label47.Left = 7.125F;
            this.label47.Name = "label47";
            this.label47.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label47.Text = "備考１";
            this.label47.Top = 0.0625F;
            this.label47.Width = 0.4375F;
            // 
            // label49
            // 
            this.label49.Border.BottomColor = System.Drawing.Color.Black;
            this.label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Border.LeftColor = System.Drawing.Color.Black;
            this.label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Border.RightColor = System.Drawing.Color.Black;
            this.label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Border.TopColor = System.Drawing.Color.Black;
            this.label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label49.Height = 0.156F;
            this.label49.HyperLink = "";
            this.label49.Left = 5F;
            this.label49.Name = "label49";
            this.label49.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label49.Text = "備考２";
            this.label49.Top = 0.2185F;
            this.label49.Width = 0.4375F;
            // 
            // Label_GrossMarginRateDtl
            // 
            this.Label_GrossMarginRateDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRateDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRateDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRateDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRateDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRateDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRateDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRateDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRateDtl.Height = 0.156F;
            this.Label_GrossMarginRateDtl.HyperLink = "";
            this.Label_GrossMarginRateDtl.Left = 10.0625F;
            this.Label_GrossMarginRateDtl.Name = "Label_GrossMarginRateDtl";
            this.Label_GrossMarginRateDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.Label_GrossMarginRateDtl.Text = "粗利率";
            this.Label_GrossMarginRateDtl.Top = 0.3745F;
            this.Label_GrossMarginRateDtl.Width = 0.4375F;
            // 
            // label51
            // 
            this.label51.Border.BottomColor = System.Drawing.Color.Black;
            this.label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.LeftColor = System.Drawing.Color.Black;
            this.label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.RightColor = System.Drawing.Color.Black;
            this.label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.TopColor = System.Drawing.Color.Black;
            this.label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Height = 0.156F;
            this.label51.HyperLink = "";
            this.label51.Left = 0.5625F;
            this.label51.Name = "label51";
            this.label51.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label51.Text = "仕入伝票番号";
            this.label51.Top = 0.5305F;
            this.label51.Width = 0.9375F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.156F;
            this.label4.HyperLink = "";
            this.label4.Left = 8.6875F;
            this.label4.Name = "label4";
            this.label4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label4.Text = "消費税";
            this.label4.Top = 0.3745F;
            this.label4.Visible = false;
            this.label4.Width = 0.5625F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.156F;
            this.label5.HyperLink = "";
            this.label5.Left = 4.3125F;
            this.label5.Name = "label5";
            this.label5.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label5.Text = "伝票区分";
            this.label5.Top = 0.0625F;
            this.label5.Width = 0.5F;
            // 
            // label25
            // 
            this.label25.Border.BottomColor = System.Drawing.Color.Black;
            this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.LeftColor = System.Drawing.Color.Black;
            this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.RightColor = System.Drawing.Color.Black;
            this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.TopColor = System.Drawing.Color.Black;
            this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Height = 0.156F;
            this.label25.HyperLink = "";
            this.label25.Left = 7.3125F;
            this.label25.Name = "label25";
            this.label25.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label25.Text = "備考３";
            this.label25.Top = 0.2185F;
            this.label25.Width = 0.4375F;
            // 
            // label31
            // 
            this.label31.Border.BottomColor = System.Drawing.Color.Black;
            this.label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.LeftColor = System.Drawing.Color.Black;
            this.label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.RightColor = System.Drawing.Color.Black;
            this.label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.TopColor = System.Drawing.Color.Black;
            this.label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Height = 0.156F;
            this.label31.HyperLink = "";
            this.label31.Left = 4.6875F;
            this.label31.Name = "label31";
            this.label31.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label31.Text = "貸出残数";
            this.label31.Top = 0.5305F;
            this.label31.Width = 0.625F;
            // 
            // TitleFooter1
            // 
            this.TitleFooter1.CanShrink = true;
            this.TitleFooter1.Height = 0F;
            this.TitleFooter1.KeepTogether = true;
            this.TitleFooter1.Name = "TitleFooter1";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Visible = false;
            // 
            // reportFooter1
            // 
            this.reportFooter1.CanShrink = true;
            this.reportFooter1.Height = 0F;
            this.reportFooter1.KeepTogether = true;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // GlandTotalHeader
            // 
            this.GlandTotalHeader.CanShrink = true;
            this.GlandTotalHeader.Height = 0F;
            this.GlandTotalHeader.Name = "GlandTotalHeader";
            this.GlandTotalHeader.Visible = false;
            // 
            // GlandTotalFooter
            // 
            this.GlandTotalFooter.CanShrink = true;
            this.GlandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line9,
            this.textBox3,
            this.textBox5,
            this.label27,
            this.Grand_TotalCostDtl,
            this.Grand_SalesMoneyDtl,
            this.Grand_SalesGrossProfitDtl,
            this.Grand_SalesGrossMarginRate,
            this.Grand_SalesGrossMarginMark,
            this.Grand_SalesPercentage,
            this.Grand_SalesDtlTax});
            this.GlandTotalFooter.Height = 0.34375F;
            this.GlandTotalFooter.KeepTogether = true;
            this.GlandTotalFooter.Name = "GlandTotalFooter";
            this.GlandTotalFooter.Format += new System.EventHandler(this.GlandTotalFooter_Format);
            this.GlandTotalFooter.BeforePrint += new System.EventHandler(this.GlandTotalFooter_BeforePrint);
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0F;
            this.line9.Left = 0F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0F;
            this.line9.Width = 10.8F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.8F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Height = 0.1875F;
            this.textBox3.Left = 4.5F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.textBox3.Text = "総合計";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.9375F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "CntSalesDtl";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 6.1875F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox5.SummaryGroup = "GlandTotalHeader";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "0";
            this.textBox5.Top = 0.0625F;
            this.textBox5.Width = 0.25F;
            // 
            // label27
            // 
            this.label27.Border.BottomColor = System.Drawing.Color.Black;
            this.label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.LeftColor = System.Drawing.Color.Black;
            this.label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.RightColor = System.Drawing.Color.Black;
            this.label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.TopColor = System.Drawing.Color.Black;
            this.label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Height = 0.125F;
            this.label27.HyperLink = "";
            this.label27.Left = 6.5625F;
            this.label27.Name = "label27";
            this.label27.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label27.Text = "枚";
            this.label27.Top = 0.0625F;
            this.label27.Width = 0.1875F;
            // 
            // Grand_TotalCostDtl
            // 
            this.Grand_TotalCostDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_TotalCostDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_TotalCostDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_TotalCostDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_TotalCostDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostDtl.DataField = "TotalCostDtl";
            this.Grand_TotalCostDtl.Height = 0.125F;
            this.Grand_TotalCostDtl.Left = 6.9375F;
            this.Grand_TotalCostDtl.MultiLine = false;
            this.Grand_TotalCostDtl.Name = "Grand_TotalCostDtl";
            this.Grand_TotalCostDtl.OutputFormat = resources.GetString("Grand_TotalCostDtl.OutputFormat");
            this.Grand_TotalCostDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Grand_TotalCostDtl.SummaryGroup = "GlandTotalHeader";
            this.Grand_TotalCostDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_TotalCostDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_TotalCostDtl.Text = "-12345678945";
            this.Grand_TotalCostDtl.Top = 0.0625F;
            this.Grand_TotalCostDtl.Width = 0.813F;
            // 
            // Grand_SalesMoneyDtl
            // 
            this.Grand_SalesMoneyDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesMoneyDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoneyDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesMoneyDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoneyDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesMoneyDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoneyDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesMoneyDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoneyDtl.DataField = "SalesMoneyDtl";
            this.Grand_SalesMoneyDtl.Height = 0.125F;
            this.Grand_SalesMoneyDtl.Left = 7.8125F;
            this.Grand_SalesMoneyDtl.MultiLine = false;
            this.Grand_SalesMoneyDtl.Name = "Grand_SalesMoneyDtl";
            this.Grand_SalesMoneyDtl.OutputFormat = resources.GetString("Grand_SalesMoneyDtl.OutputFormat");
            this.Grand_SalesMoneyDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesMoneyDtl.SummaryGroup = "GlandTotalHeader";
            this.Grand_SalesMoneyDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesMoneyDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesMoneyDtl.Text = "963258741258";
            this.Grand_SalesMoneyDtl.Top = 0.0625F;
            this.Grand_SalesMoneyDtl.Width = 0.75F;
            // 
            // Grand_SalesGrossProfitDtl
            // 
            this.Grand_SalesGrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfitDtl.DataField = "SalesGrossProfitDtl";
            this.Grand_SalesGrossProfitDtl.Height = 0.125F;
            this.Grand_SalesGrossProfitDtl.Left = 9.25F;
            this.Grand_SalesGrossProfitDtl.MultiLine = false;
            this.Grand_SalesGrossProfitDtl.Name = "Grand_SalesGrossProfitDtl";
            this.Grand_SalesGrossProfitDtl.OutputFormat = resources.GetString("Grand_SalesGrossProfitDtl.OutputFormat");
            this.Grand_SalesGrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesGrossProfitDtl.SummaryGroup = "GlandTotalHeader";
            this.Grand_SalesGrossProfitDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesGrossProfitDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesGrossProfitDtl.Text = "-12345678945";
            this.Grand_SalesGrossProfitDtl.Top = 0.0625F;
            this.Grand_SalesGrossProfitDtl.Width = 0.75F;
            // 
            // Grand_SalesGrossMarginRate
            // 
            this.Grand_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.CanGrow = false;
            this.Grand_SalesGrossMarginRate.Height = 0.125F;
            this.Grand_SalesGrossMarginRate.Left = 10.0625F;
            this.Grand_SalesGrossMarginRate.MultiLine = false;
            this.Grand_SalesGrossMarginRate.Name = "Grand_SalesGrossMarginRate";
            this.Grand_SalesGrossMarginRate.OutputFormat = resources.GetString("Grand_SalesGrossMarginRate.OutputFormat");
            this.Grand_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesGrossMarginRate.Text = "-100.00";
            this.Grand_SalesGrossMarginRate.Top = 0.0625F;
            this.Grand_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Grand_SalesGrossMarginMark
            // 
            this.Grand_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.CanGrow = false;
            this.Grand_SalesGrossMarginMark.Height = 0.125F;
            this.Grand_SalesGrossMarginMark.Left = 10.625F;
            this.Grand_SalesGrossMarginMark.Name = "Grand_SalesGrossMarginMark";
            this.Grand_SalesGrossMarginMark.OutputFormat = resources.GetString("Grand_SalesGrossMarginMark.OutputFormat");
            this.Grand_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Grand_SalesGrossMarginMark.Text = "●";
            this.Grand_SalesGrossMarginMark.Top = 0.0625F;
            this.Grand_SalesGrossMarginMark.Width = 0.1875F;
            // 
            // Grand_SalesPercentage
            // 
            this.Grand_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Height = 0.125F;
            this.Grand_SalesPercentage.HyperLink = "";
            this.Grand_SalesPercentage.Left = 10.5F;
            this.Grand_SalesPercentage.Name = "Grand_SalesPercentage";
            this.Grand_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesPercentage.Text = "％";
            this.Grand_SalesPercentage.Top = 0.0625F;
            this.Grand_SalesPercentage.Width = 0.125F;
            // 
            // Grand_SalesDtlTax
            // 
            this.Grand_SalesDtlTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesDtlTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesDtlTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesDtlTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesDtlTax.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesDtlTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesDtlTax.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesDtlTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesDtlTax.DataField = "SalesDtlTax";
            this.Grand_SalesDtlTax.Height = 0.125F;
            this.Grand_SalesDtlTax.Left = 8.6875F;
            this.Grand_SalesDtlTax.MultiLine = false;
            this.Grand_SalesDtlTax.Name = "Grand_SalesDtlTax";
            this.Grand_SalesDtlTax.OutputFormat = resources.GetString("Grand_SalesDtlTax.OutputFormat");
            this.Grand_SalesDtlTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesDtlTax.SummaryGroup = "GlandTotalHeader";
            this.Grand_SalesDtlTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesDtlTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesDtlTax.Text = "1,234,567";
            this.Grand_SalesDtlTax.Top = 0.0625F;
            this.Grand_SalesDtlTax.Visible = false;
            this.Grand_SalesDtlTax.Width = 0.5625F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line7,
            this.label6,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.25F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0F;
            this.line7.Left = 0F;
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line4,
            this.TextBox37,
            this.label26,
            this.textBox9,
            this.Section_TotalCostDtl,
            this.Section_SalesMoneyDtl,
            this.Section_SalesGrossProfitDtl,
            this.Section_SalesGrossMarginRate,
            this.Section_SalesGrossMarginMark,
            this.Section_SalesPercentage,
            this.Section_SalesDtlTax});
            this.SectionFooter.Height = 0.3020833F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format_1);
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 2F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // TextBox37
            // 
            this.TextBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox37.Height = 0.1875F;
            this.TextBox37.Left = 4.5F;
            this.TextBox37.MultiLine = false;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.OutputFormat = resources.GetString("TextBox37.OutputFormat");
            this.TextBox37.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.TextBox37.Text = "拠点計";
            this.TextBox37.Top = 0.0625F;
            this.TextBox37.Width = 0.9375F;
            // 
            // label26
            // 
            this.label26.Border.BottomColor = System.Drawing.Color.Black;
            this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.LeftColor = System.Drawing.Color.Black;
            this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.RightColor = System.Drawing.Color.Black;
            this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.TopColor = System.Drawing.Color.Black;
            this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Height = 0.125F;
            this.label26.HyperLink = "";
            this.label26.Left = 6.5625F;
            this.label26.Name = "label26";
            this.label26.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label26.Text = "枚";
            this.label26.Top = 0.0625F;
            this.label26.Width = 0.1875F;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.DataField = "CntSalesDtl";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 6.1875F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox9.SummaryGroup = "SectionHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox9.Text = "0";
            this.textBox9.Top = 0.0625F;
            this.textBox9.Width = 0.25F;
            // 
            // Section_TotalCostDtl
            // 
            this.Section_TotalCostDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_TotalCostDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_TotalCostDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Section_TotalCostDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Section_TotalCostDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostDtl.DataField = "TotalCostDtl";
            this.Section_TotalCostDtl.Height = 0.125F;
            this.Section_TotalCostDtl.Left = 6.9375F;
            this.Section_TotalCostDtl.MultiLine = false;
            this.Section_TotalCostDtl.Name = "Section_TotalCostDtl";
            this.Section_TotalCostDtl.OutputFormat = resources.GetString("Section_TotalCostDtl.OutputFormat");
            this.Section_TotalCostDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Section_TotalCostDtl.SummaryGroup = "SectionHeader";
            this.Section_TotalCostDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_TotalCostDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_TotalCostDtl.Text = "-12345678945";
            this.Section_TotalCostDtl.Top = 0.0625F;
            this.Section_TotalCostDtl.Width = 0.813F;
            // 
            // Section_SalesMoneyDtl
            // 
            this.Section_SalesMoneyDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesMoneyDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoneyDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesMoneyDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoneyDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesMoneyDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoneyDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesMoneyDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoneyDtl.DataField = "SalesMoneyDtl";
            this.Section_SalesMoneyDtl.Height = 0.125F;
            this.Section_SalesMoneyDtl.Left = 7.8125F;
            this.Section_SalesMoneyDtl.MultiLine = false;
            this.Section_SalesMoneyDtl.Name = "Section_SalesMoneyDtl";
            this.Section_SalesMoneyDtl.OutputFormat = resources.GetString("Section_SalesMoneyDtl.OutputFormat");
            this.Section_SalesMoneyDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesMoneyDtl.SummaryGroup = "SectionHeader";
            this.Section_SalesMoneyDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesMoneyDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesMoneyDtl.Text = "963258741258";
            this.Section_SalesMoneyDtl.Top = 0.0625F;
            this.Section_SalesMoneyDtl.Width = 0.75F;
            // 
            // Section_SalesGrossProfitDtl
            // 
            this.Section_SalesGrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfitDtl.DataField = "SalesGrossProfitDtl";
            this.Section_SalesGrossProfitDtl.Height = 0.125F;
            this.Section_SalesGrossProfitDtl.Left = 9.25F;
            this.Section_SalesGrossProfitDtl.MultiLine = false;
            this.Section_SalesGrossProfitDtl.Name = "Section_SalesGrossProfitDtl";
            this.Section_SalesGrossProfitDtl.OutputFormat = resources.GetString("Section_SalesGrossProfitDtl.OutputFormat");
            this.Section_SalesGrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesGrossProfitDtl.SummaryGroup = "SectionHeader";
            this.Section_SalesGrossProfitDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesGrossProfitDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesGrossProfitDtl.Text = "-12345678945";
            this.Section_SalesGrossProfitDtl.Top = 0.0625F;
            this.Section_SalesGrossProfitDtl.Width = 0.75F;
            // 
            // Section_SalesGrossMarginRate
            // 
            this.Section_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.CanGrow = false;
            this.Section_SalesGrossMarginRate.Height = 0.125F;
            this.Section_SalesGrossMarginRate.Left = 10.0625F;
            this.Section_SalesGrossMarginRate.MultiLine = false;
            this.Section_SalesGrossMarginRate.Name = "Section_SalesGrossMarginRate";
            this.Section_SalesGrossMarginRate.OutputFormat = resources.GetString("Section_SalesGrossMarginRate.OutputFormat");
            this.Section_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesGrossMarginRate.Text = "-100.00";
            this.Section_SalesGrossMarginRate.Top = 0.0625F;
            this.Section_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Section_SalesGrossMarginMark
            // 
            this.Section_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.CanGrow = false;
            this.Section_SalesGrossMarginMark.Height = 0.125F;
            this.Section_SalesGrossMarginMark.Left = 10.625F;
            this.Section_SalesGrossMarginMark.Name = "Section_SalesGrossMarginMark";
            this.Section_SalesGrossMarginMark.OutputFormat = resources.GetString("Section_SalesGrossMarginMark.OutputFormat");
            this.Section_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Section_SalesGrossMarginMark.Text = "●";
            this.Section_SalesGrossMarginMark.Top = 0.0625F;
            this.Section_SalesGrossMarginMark.Width = 0.1875F;
            // 
            // Section_SalesPercentage
            // 
            this.Section_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Height = 0.125F;
            this.Section_SalesPercentage.HyperLink = "";
            this.Section_SalesPercentage.Left = 10.5F;
            this.Section_SalesPercentage.Name = "Section_SalesPercentage";
            this.Section_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesPercentage.Text = "％";
            this.Section_SalesPercentage.Top = 0.0625F;
            this.Section_SalesPercentage.Width = 0.125F;
            // 
            // Section_SalesDtlTax
            // 
            this.Section_SalesDtlTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesDtlTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesDtlTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesDtlTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesDtlTax.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesDtlTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesDtlTax.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesDtlTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesDtlTax.DataField = "SalesDtlTax";
            this.Section_SalesDtlTax.Height = 0.125F;
            this.Section_SalesDtlTax.Left = 8.6875F;
            this.Section_SalesDtlTax.MultiLine = false;
            this.Section_SalesDtlTax.Name = "Section_SalesDtlTax";
            this.Section_SalesDtlTax.OutputFormat = resources.GetString("Section_SalesDtlTax.OutputFormat");
            this.Section_SalesDtlTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesDtlTax.SummaryGroup = "SectionHeader";
            this.Section_SalesDtlTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesDtlTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesDtlTax.Text = "1,234,567";
            this.Section_SalesDtlTax.Top = 0.0625F;
            this.Section_SalesDtlTax.Visible = false;
            this.Section_SalesDtlTax.Width = 0.5625F;
            // 
            // Header1
            // 
            this.Header1.CanShrink = true;
            this.Header1.Height = 0F;
            this.Header1.Name = "Header1";
            this.Header1.Visible = false;
            // 
            // Footer1
            // 
            this.Footer1.CanShrink = true;
            this.Footer1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.Footer1Field,
            this.f1_CntSalesDtl,
            this.Footer1_SalesMoneyDtl,
            this.Footer1_TotalCostDtl,
            this.f1_SalesLbl,
            this.Footer1_SalesGrossProfitDtl,
            this.Footer1_SalesGrossMarginRate,
            this.Footer1_SalesGrossMarginMark,
            this.Footer1_SalesPercentage,
            this.Footer1_SalesDtlTax});
            this.Footer1.Height = 0.3229167F;
            this.Footer1.KeepTogether = true;
            this.Footer1.Name = "Footer1";
            this.Footer1.Format += new System.EventHandler(this.Footer1_Format);
            this.Footer1.BeforePrint += new System.EventHandler(this.Footer1_BeforePrint);
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // Footer1Field
            // 
            this.Footer1Field.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Height = 0.1875F;
            this.Footer1Field.Left = 4.5F;
            this.Footer1Field.MultiLine = false;
            this.Footer1Field.Name = "Footer1Field";
            this.Footer1Field.OutputFormat = resources.GetString("Footer1Field.OutputFormat");
            this.Footer1Field.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.Footer1Field.Text = "計";
            this.Footer1Field.Top = 0.0625F;
            this.Footer1Field.Width = 0.9375F;
            // 
            // f1_CntSalesDtl
            // 
            this.f1_CntSalesDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_CntSalesDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CntSalesDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_CntSalesDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CntSalesDtl.Border.RightColor = System.Drawing.Color.Black;
            this.f1_CntSalesDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CntSalesDtl.Border.TopColor = System.Drawing.Color.Black;
            this.f1_CntSalesDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CntSalesDtl.DataField = "CntSalesDtl";
            this.f1_CntSalesDtl.Height = 0.125F;
            this.f1_CntSalesDtl.Left = 6.1875F;
            this.f1_CntSalesDtl.MultiLine = false;
            this.f1_CntSalesDtl.Name = "f1_CntSalesDtl";
            this.f1_CntSalesDtl.OutputFormat = resources.GetString("f1_CntSalesDtl.OutputFormat");
            this.f1_CntSalesDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.f1_CntSalesDtl.SummaryGroup = "Header1";
            this.f1_CntSalesDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_CntSalesDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_CntSalesDtl.Text = "0";
            this.f1_CntSalesDtl.Top = 0.0625F;
            this.f1_CntSalesDtl.Width = 0.25F;
            // 
            // Footer1_SalesMoneyDtl
            // 
            this.Footer1_SalesMoneyDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoneyDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoneyDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoneyDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoneyDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoneyDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoneyDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoneyDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoneyDtl.DataField = "SalesMoneyDtl";
            this.Footer1_SalesMoneyDtl.Height = 0.125F;
            this.Footer1_SalesMoneyDtl.Left = 7.8125F;
            this.Footer1_SalesMoneyDtl.MultiLine = false;
            this.Footer1_SalesMoneyDtl.Name = "Footer1_SalesMoneyDtl";
            this.Footer1_SalesMoneyDtl.OutputFormat = resources.GetString("Footer1_SalesMoneyDtl.OutputFormat");
            this.Footer1_SalesMoneyDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesMoneyDtl.SummaryGroup = "Header1";
            this.Footer1_SalesMoneyDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesMoneyDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesMoneyDtl.Text = "963258741258";
            this.Footer1_SalesMoneyDtl.Top = 0.0625F;
            this.Footer1_SalesMoneyDtl.Width = 0.75F;
            // 
            // Footer1_TotalCostDtl
            // 
            this.Footer1_TotalCostDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostDtl.DataField = "TotalCostDtl";
            this.Footer1_TotalCostDtl.Height = 0.125F;
            this.Footer1_TotalCostDtl.Left = 6.9375F;
            this.Footer1_TotalCostDtl.MultiLine = false;
            this.Footer1_TotalCostDtl.Name = "Footer1_TotalCostDtl";
            this.Footer1_TotalCostDtl.OutputFormat = resources.GetString("Footer1_TotalCostDtl.OutputFormat");
            this.Footer1_TotalCostDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer1_TotalCostDtl.SummaryGroup = "Header1";
            this.Footer1_TotalCostDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_TotalCostDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_TotalCostDtl.Text = "-12345678945";
            this.Footer1_TotalCostDtl.Top = 0.0625F;
            this.Footer1_TotalCostDtl.Width = 0.813F;
            // 
            // f1_SalesLbl
            // 
            this.f1_SalesLbl.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_SalesLbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_SalesLbl.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_SalesLbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_SalesLbl.Border.RightColor = System.Drawing.Color.Black;
            this.f1_SalesLbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_SalesLbl.Border.TopColor = System.Drawing.Color.Black;
            this.f1_SalesLbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_SalesLbl.Height = 0.125F;
            this.f1_SalesLbl.HyperLink = "";
            this.f1_SalesLbl.Left = 6.5625F;
            this.f1_SalesLbl.Name = "f1_SalesLbl";
            this.f1_SalesLbl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.f1_SalesLbl.Text = "枚";
            this.f1_SalesLbl.Top = 0.0625F;
            this.f1_SalesLbl.Width = 0.1875F;
            // 
            // Footer1_SalesGrossProfitDtl
            // 
            this.Footer1_SalesGrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfitDtl.DataField = "SalesGrossProfitDtl";
            this.Footer1_SalesGrossProfitDtl.Height = 0.125F;
            this.Footer1_SalesGrossProfitDtl.Left = 9.25F;
            this.Footer1_SalesGrossProfitDtl.MultiLine = false;
            this.Footer1_SalesGrossProfitDtl.Name = "Footer1_SalesGrossProfitDtl";
            this.Footer1_SalesGrossProfitDtl.OutputFormat = resources.GetString("Footer1_SalesGrossProfitDtl.OutputFormat");
            this.Footer1_SalesGrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesGrossProfitDtl.SummaryGroup = "Header1";
            this.Footer1_SalesGrossProfitDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesGrossProfitDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesGrossProfitDtl.Text = "-12345678945";
            this.Footer1_SalesGrossProfitDtl.Top = 0.0625F;
            this.Footer1_SalesGrossProfitDtl.Width = 0.75F;
            // 
            // Footer1_SalesGrossMarginRate
            // 
            this.Footer1_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.CanGrow = false;
            this.Footer1_SalesGrossMarginRate.Height = 0.125F;
            this.Footer1_SalesGrossMarginRate.Left = 10.0625F;
            this.Footer1_SalesGrossMarginRate.MultiLine = false;
            this.Footer1_SalesGrossMarginRate.Name = "Footer1_SalesGrossMarginRate";
            this.Footer1_SalesGrossMarginRate.OutputFormat = resources.GetString("Footer1_SalesGrossMarginRate.OutputFormat");
            this.Footer1_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesGrossMarginRate.Text = "-100.00";
            this.Footer1_SalesGrossMarginRate.Top = 0.0625F;
            this.Footer1_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Footer1_SalesGrossMarginMark
            // 
            this.Footer1_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.CanGrow = false;
            this.Footer1_SalesGrossMarginMark.Height = 0.125F;
            this.Footer1_SalesGrossMarginMark.Left = 10.625F;
            this.Footer1_SalesGrossMarginMark.Name = "Footer1_SalesGrossMarginMark";
            this.Footer1_SalesGrossMarginMark.OutputFormat = resources.GetString("Footer1_SalesGrossMarginMark.OutputFormat");
            this.Footer1_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Footer1_SalesGrossMarginMark.Text = "●";
            this.Footer1_SalesGrossMarginMark.Top = 0.0625F;
            this.Footer1_SalesGrossMarginMark.Width = 0.1875F;
            // 
            // Footer1_SalesPercentage
            // 
            this.Footer1_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Height = 0.125F;
            this.Footer1_SalesPercentage.HyperLink = "";
            this.Footer1_SalesPercentage.Left = 10.5F;
            this.Footer1_SalesPercentage.Name = "Footer1_SalesPercentage";
            this.Footer1_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesPercentage.Text = "％";
            this.Footer1_SalesPercentage.Top = 0.0625F;
            this.Footer1_SalesPercentage.Width = 0.125F;
            // 
            // Footer1_SalesDtlTax
            // 
            this.Footer1_SalesDtlTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesDtlTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesDtlTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesDtlTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesDtlTax.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesDtlTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesDtlTax.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesDtlTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesDtlTax.DataField = "SalesDtlTax";
            this.Footer1_SalesDtlTax.Height = 0.125F;
            this.Footer1_SalesDtlTax.Left = 8.6875F;
            this.Footer1_SalesDtlTax.MultiLine = false;
            this.Footer1_SalesDtlTax.Name = "Footer1_SalesDtlTax";
            this.Footer1_SalesDtlTax.OutputFormat = resources.GetString("Footer1_SalesDtlTax.OutputFormat");
            this.Footer1_SalesDtlTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesDtlTax.SummaryGroup = "Header1";
            this.Footer1_SalesDtlTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesDtlTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesDtlTax.Text = "1,234,567";
            this.Footer1_SalesDtlTax.Top = 0.0625F;
            this.Footer1_SalesDtlTax.Visible = false;
            this.Footer1_SalesDtlTax.Width = 0.5625F;
            // 
            // Header2
            // 
            this.Header2.CanShrink = true;
            this.Header2.Height = 0F;
            this.Header2.Name = "Header2";
            this.Header2.Visible = false;
            // 
            // Footer2
            // 
            this.Footer2.CanShrink = true;
            this.Footer2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer2Field,
            this.f2_CntSalesDtl,
            this.Footer2_SalesMoneyDtl,
            this.Footer2_TotalCostDtl,
            this.f2_SalesLbl,
            this.Footer2_SalesGrossProfitDtl,
            this.Footer2_SalesGrossMarginRate,
            this.Footer2_SalesGrossMarginMark,
            this.Footer2_SalesPercentage,
            this.line2,
            this.Footer2_SalesDtlTax,
            this.Footer2_ConsTaxLayMethod});
            this.Footer2.Height = 0.5416667F;
            this.Footer2.KeepTogether = true;
            this.Footer2.Name = "Footer2";
            this.Footer2.Format += new System.EventHandler(this.Footer2_Format);
            this.Footer2.BeforePrint += new System.EventHandler(this.Footer2_BeforePrint);
            // 
            // Footer2Field
            // 
            this.Footer2Field.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2Field.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2Field.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2Field.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2Field.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2Field.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2Field.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2Field.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2Field.Height = 0.1875F;
            this.Footer2Field.Left = 4.5F;
            this.Footer2Field.MultiLine = false;
            this.Footer2Field.Name = "Footer2Field";
            this.Footer2Field.OutputFormat = resources.GetString("Footer2Field.OutputFormat");
            this.Footer2Field.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.Footer2Field.Text = "計";
            this.Footer2Field.Top = 0.0625F;
            this.Footer2Field.Width = 0.9375F;
            // 
            // f2_CntSalesDtl
            // 
            this.f2_CntSalesDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_CntSalesDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CntSalesDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_CntSalesDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CntSalesDtl.Border.RightColor = System.Drawing.Color.Black;
            this.f2_CntSalesDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CntSalesDtl.Border.TopColor = System.Drawing.Color.Black;
            this.f2_CntSalesDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CntSalesDtl.DataField = "CntSalesDtl";
            this.f2_CntSalesDtl.Height = 0.125F;
            this.f2_CntSalesDtl.Left = 6.1875F;
            this.f2_CntSalesDtl.MultiLine = false;
            this.f2_CntSalesDtl.Name = "f2_CntSalesDtl";
            this.f2_CntSalesDtl.OutputFormat = resources.GetString("f2_CntSalesDtl.OutputFormat");
            this.f2_CntSalesDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.f2_CntSalesDtl.SummaryGroup = "Header2";
            this.f2_CntSalesDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_CntSalesDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_CntSalesDtl.Text = "0";
            this.f2_CntSalesDtl.Top = 0.0625F;
            this.f2_CntSalesDtl.Width = 0.25F;
            // 
            // Footer2_SalesMoneyDtl
            // 
            this.Footer2_SalesMoneyDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_SalesMoneyDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesMoneyDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_SalesMoneyDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesMoneyDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_SalesMoneyDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesMoneyDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_SalesMoneyDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesMoneyDtl.DataField = "SalesMoneyDtl";
            this.Footer2_SalesMoneyDtl.Height = 0.125F;
            this.Footer2_SalesMoneyDtl.Left = 7.8125F;
            this.Footer2_SalesMoneyDtl.MultiLine = false;
            this.Footer2_SalesMoneyDtl.Name = "Footer2_SalesMoneyDtl";
            this.Footer2_SalesMoneyDtl.OutputFormat = resources.GetString("Footer2_SalesMoneyDtl.OutputFormat");
            this.Footer2_SalesMoneyDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer2_SalesMoneyDtl.SummaryGroup = "Header2";
            this.Footer2_SalesMoneyDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer2_SalesMoneyDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer2_SalesMoneyDtl.Text = "963258741258";
            this.Footer2_SalesMoneyDtl.Top = 0.0625F;
            this.Footer2_SalesMoneyDtl.Width = 0.75F;
            // 
            // Footer2_TotalCostDtl
            // 
            this.Footer2_TotalCostDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_TotalCostDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_TotalCostDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_TotalCostDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_TotalCostDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_TotalCostDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_TotalCostDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_TotalCostDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_TotalCostDtl.DataField = "TotalCostDtl";
            this.Footer2_TotalCostDtl.Height = 0.125F;
            this.Footer2_TotalCostDtl.Left = 6.9375F;
            this.Footer2_TotalCostDtl.MultiLine = false;
            this.Footer2_TotalCostDtl.Name = "Footer2_TotalCostDtl";
            this.Footer2_TotalCostDtl.OutputFormat = resources.GetString("Footer2_TotalCostDtl.OutputFormat");
            this.Footer2_TotalCostDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer2_TotalCostDtl.SummaryGroup = "Header2";
            this.Footer2_TotalCostDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer2_TotalCostDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer2_TotalCostDtl.Text = "-12345678945";
            this.Footer2_TotalCostDtl.Top = 0.0625F;
            this.Footer2_TotalCostDtl.Width = 0.813F;
            // 
            // f2_SalesLbl
            // 
            this.f2_SalesLbl.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_SalesLbl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_SalesLbl.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_SalesLbl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_SalesLbl.Border.RightColor = System.Drawing.Color.Black;
            this.f2_SalesLbl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_SalesLbl.Border.TopColor = System.Drawing.Color.Black;
            this.f2_SalesLbl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_SalesLbl.Height = 0.125F;
            this.f2_SalesLbl.HyperLink = "";
            this.f2_SalesLbl.Left = 6.5625F;
            this.f2_SalesLbl.Name = "f2_SalesLbl";
            this.f2_SalesLbl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.f2_SalesLbl.Text = "枚";
            this.f2_SalesLbl.Top = 0.0625F;
            this.f2_SalesLbl.Width = 0.1875F;
            // 
            // Footer2_SalesGrossProfitDtl
            // 
            this.Footer2_SalesGrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossProfitDtl.DataField = "SalesGrossProfitDtl";
            this.Footer2_SalesGrossProfitDtl.Height = 0.125F;
            this.Footer2_SalesGrossProfitDtl.Left = 9.25F;
            this.Footer2_SalesGrossProfitDtl.MultiLine = false;
            this.Footer2_SalesGrossProfitDtl.Name = "Footer2_SalesGrossProfitDtl";
            this.Footer2_SalesGrossProfitDtl.OutputFormat = resources.GetString("Footer2_SalesGrossProfitDtl.OutputFormat");
            this.Footer2_SalesGrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer2_SalesGrossProfitDtl.SummaryGroup = "Header2";
            this.Footer2_SalesGrossProfitDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer2_SalesGrossProfitDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer2_SalesGrossProfitDtl.Text = "-12345678945";
            this.Footer2_SalesGrossProfitDtl.Top = 0.0625F;
            this.Footer2_SalesGrossProfitDtl.Width = 0.75F;
            // 
            // Footer2_SalesGrossMarginRate
            // 
            this.Footer2_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginRate.CanGrow = false;
            this.Footer2_SalesGrossMarginRate.Height = 0.125F;
            this.Footer2_SalesGrossMarginRate.Left = 10.0625F;
            this.Footer2_SalesGrossMarginRate.MultiLine = false;
            this.Footer2_SalesGrossMarginRate.Name = "Footer2_SalesGrossMarginRate";
            this.Footer2_SalesGrossMarginRate.OutputFormat = resources.GetString("Footer2_SalesGrossMarginRate.OutputFormat");
            this.Footer2_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer2_SalesGrossMarginRate.Text = "-100.00";
            this.Footer2_SalesGrossMarginRate.Top = 0.0625F;
            this.Footer2_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Footer2_SalesGrossMarginMark
            // 
            this.Footer2_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesGrossMarginMark.CanGrow = false;
            this.Footer2_SalesGrossMarginMark.Height = 0.125F;
            this.Footer2_SalesGrossMarginMark.Left = 10.625F;
            this.Footer2_SalesGrossMarginMark.Name = "Footer2_SalesGrossMarginMark";
            this.Footer2_SalesGrossMarginMark.OutputFormat = resources.GetString("Footer2_SalesGrossMarginMark.OutputFormat");
            this.Footer2_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Footer2_SalesGrossMarginMark.Text = "●";
            this.Footer2_SalesGrossMarginMark.Top = 0.0625F;
            this.Footer2_SalesGrossMarginMark.Width = 0.1875F;
            // 
            // Footer2_SalesPercentage
            // 
            this.Footer2_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesPercentage.Height = 0.125F;
            this.Footer2_SalesPercentage.HyperLink = "";
            this.Footer2_SalesPercentage.Left = 10.5F;
            this.Footer2_SalesPercentage.Name = "Footer2_SalesPercentage";
            this.Footer2_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Footer2_SalesPercentage.Text = "％";
            this.Footer2_SalesPercentage.Top = 0.0625F;
            this.Footer2_SalesPercentage.Width = 0.125F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // Footer2_SalesDtlTax
            // 
            this.Footer2_SalesDtlTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_SalesDtlTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesDtlTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_SalesDtlTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesDtlTax.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_SalesDtlTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesDtlTax.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_SalesDtlTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_SalesDtlTax.DataField = "SalesDtlTax";
            this.Footer2_SalesDtlTax.Height = 0.125F;
            this.Footer2_SalesDtlTax.Left = 8.6875F;
            this.Footer2_SalesDtlTax.MultiLine = false;
            this.Footer2_SalesDtlTax.Name = "Footer2_SalesDtlTax";
            this.Footer2_SalesDtlTax.OutputFormat = resources.GetString("Footer2_SalesDtlTax.OutputFormat");
            this.Footer2_SalesDtlTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer2_SalesDtlTax.SummaryGroup = "Header2";
            this.Footer2_SalesDtlTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer2_SalesDtlTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer2_SalesDtlTax.Text = "1,234,567";
            this.Footer2_SalesDtlTax.Top = 0.0625F;
            this.Footer2_SalesDtlTax.Visible = false;
            this.Footer2_SalesDtlTax.Width = 0.5625F;
            // 
            // Footer2_ConsTaxLayMethod
            // 
            this.Footer2_ConsTaxLayMethod.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer2_ConsTaxLayMethod.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_ConsTaxLayMethod.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer2_ConsTaxLayMethod.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_ConsTaxLayMethod.Border.RightColor = System.Drawing.Color.Black;
            this.Footer2_ConsTaxLayMethod.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_ConsTaxLayMethod.Border.TopColor = System.Drawing.Color.Black;
            this.Footer2_ConsTaxLayMethod.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer2_ConsTaxLayMethod.CanGrow = false;
            this.Footer2_ConsTaxLayMethod.DataField = "ConsTaxLayMethod";
            this.Footer2_ConsTaxLayMethod.Height = 0.156F;
            this.Footer2_ConsTaxLayMethod.Left = 4.5F;
            this.Footer2_ConsTaxLayMethod.Name = "Footer2_ConsTaxLayMethod";
            this.Footer2_ConsTaxLayMethod.OutputFormat = resources.GetString("Footer2_ConsTaxLayMethod.OutputFormat");
            this.Footer2_ConsTaxLayMethod.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Footer2_ConsTaxLayMethod.Text = null;
            this.Footer2_ConsTaxLayMethod.Top = 0.3125F;
            this.Footer2_ConsTaxLayMethod.Visible = false;
            this.Footer2_ConsTaxLayMethod.Width = 0.6875F;
            // 
            // Header3
            // 
            this.Header3.CanShrink = true;
            this.Header3.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CustomerCode,
            this.SalesSlipName,
            this.SalesSlipNum,
            this.SalesInputName,
            this.CustomerSnm,
            this.ShipmentDay,
            this.SalesEmployeeNm,
            this.FrontEmployeeNm,
            this.SearchSlipDate,
            this.BusinessTypeName,
            this.PartySaleSlipNum,
            this.ModelFullName,
            this.CategoryDtl,
            this.FullModel,
            this.CarMngCode,
            this.FirstEntryDate,
            this.SlipNote,
            this.SlipNote2,
            this.line14,
            this.SlipNote3});
            this.Header3.DataField = "SalesSlipNum";
            this.Header3.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.Header3.Height = 0.5104167F;
            this.Header3.KeepTogether = true;
            this.Header3.Name = "Header3";
            this.Header3.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SlipNote3
            // 
            this.SlipNote3.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote3.CanGrow = false;
            this.SlipNote3.DataField = "SlipNote3";
            this.SlipNote3.Height = 0.156F;
            this.SlipNote3.Left = 7.3125F;
            this.SlipNote3.MultiLine = false;
            this.SlipNote3.Name = "SlipNote3";
            this.SlipNote3.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; white-space: inherit; vertical-align: top; ";
            this.SlipNote3.Text = "ぜんかくぜんかくぜんかくぜんかくぜんかく";
            this.SlipNote3.Top = 0.2185F;
            this.SlipNote3.Width = 2.25F;
            // 
            // Footer3
            // 
            this.Footer3.CanShrink = true;
            this.Footer3.Height = 0F;
            this.Footer3.KeepTogether = true;
            this.Footer3.Name = "Footer3";
            // 
            // DateHeader
            // 
            this.DateHeader.CanShrink = true;
            this.DateHeader.DataField = "ShipmentDay";
            this.DateHeader.Height = 0F;
            this.DateHeader.KeepTogether = true;
            this.DateHeader.Name = "DateHeader";
            // 
            // DateFooter
            // 
            this.DateFooter.CanShrink = true;
            this.DateFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox8,
            this.Date_SalesMoneyDtl,
            this.Date_TotalCostDtl,
            this.label29,
            this.Date_SalesGrossProfitDtl,
            this.Date_SalesGrossMarginRate,
            this.Date_SalesGrossMarginMark,
            this.Date_SalesPercentage,
            this.line8,
            this.Date_SalesDtlTax});
            this.DateFooter.Height = 0.3333333F;
            this.DateFooter.KeepTogether = true;
            this.DateFooter.Name = "DateFooter";
            this.DateFooter.Format += new System.EventHandler(this.DateFooter_Format);
            this.DateFooter.BeforePrint += new System.EventHandler(this.DateFooter_BeforePrint);
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 4.5F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.textBox1.Text = "貸出日計";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.9375F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.DataField = "CntSalesDtl";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 6.1875F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox8.SummaryGroup = "DateHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "0";
            this.textBox8.Top = 0.0625F;
            this.textBox8.Width = 0.25F;
            // 
            // Date_SalesMoneyDtl
            // 
            this.Date_SalesMoneyDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesMoneyDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoneyDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesMoneyDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoneyDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesMoneyDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoneyDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesMoneyDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoneyDtl.DataField = "SalesMoneyDtl";
            this.Date_SalesMoneyDtl.Height = 0.125F;
            this.Date_SalesMoneyDtl.Left = 7.8125F;
            this.Date_SalesMoneyDtl.MultiLine = false;
            this.Date_SalesMoneyDtl.Name = "Date_SalesMoneyDtl";
            this.Date_SalesMoneyDtl.OutputFormat = resources.GetString("Date_SalesMoneyDtl.OutputFormat");
            this.Date_SalesMoneyDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesMoneyDtl.SummaryGroup = "DateHeader";
            this.Date_SalesMoneyDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesMoneyDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesMoneyDtl.Text = "963258741258";
            this.Date_SalesMoneyDtl.Top = 0.0625F;
            this.Date_SalesMoneyDtl.Width = 0.75F;
            // 
            // Date_TotalCostDtl
            // 
            this.Date_TotalCostDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_TotalCostDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_TotalCostDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Date_TotalCostDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Date_TotalCostDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostDtl.DataField = "TotalCostDtl";
            this.Date_TotalCostDtl.Height = 0.125F;
            this.Date_TotalCostDtl.Left = 6.9375F;
            this.Date_TotalCostDtl.MultiLine = false;
            this.Date_TotalCostDtl.Name = "Date_TotalCostDtl";
            this.Date_TotalCostDtl.OutputFormat = resources.GetString("Date_TotalCostDtl.OutputFormat");
            this.Date_TotalCostDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Date_TotalCostDtl.SummaryGroup = "DateHeader";
            this.Date_TotalCostDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_TotalCostDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_TotalCostDtl.Text = "-12345678945";
            this.Date_TotalCostDtl.Top = 0.0625F;
            this.Date_TotalCostDtl.Width = 0.813F;
            // 
            // label29
            // 
            this.label29.Border.BottomColor = System.Drawing.Color.Black;
            this.label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.LeftColor = System.Drawing.Color.Black;
            this.label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.RightColor = System.Drawing.Color.Black;
            this.label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.TopColor = System.Drawing.Color.Black;
            this.label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Height = 0.125F;
            this.label29.HyperLink = "";
            this.label29.Left = 6.5625F;
            this.label29.Name = "label29";
            this.label29.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label29.Text = "枚";
            this.label29.Top = 0.0625F;
            this.label29.Width = 0.1875F;
            // 
            // Date_SalesGrossProfitDtl
            // 
            this.Date_SalesGrossProfitDtl.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfitDtl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfitDtl.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfitDtl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfitDtl.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfitDtl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfitDtl.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfitDtl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfitDtl.DataField = "SalesGrossProfitDtl";
            this.Date_SalesGrossProfitDtl.Height = 0.125F;
            this.Date_SalesGrossProfitDtl.Left = 9.25F;
            this.Date_SalesGrossProfitDtl.MultiLine = false;
            this.Date_SalesGrossProfitDtl.Name = "Date_SalesGrossProfitDtl";
            this.Date_SalesGrossProfitDtl.OutputFormat = resources.GetString("Date_SalesGrossProfitDtl.OutputFormat");
            this.Date_SalesGrossProfitDtl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesGrossProfitDtl.SummaryGroup = "DateHeader";
            this.Date_SalesGrossProfitDtl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesGrossProfitDtl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesGrossProfitDtl.Text = "-12345678945";
            this.Date_SalesGrossProfitDtl.Top = 0.0625F;
            this.Date_SalesGrossProfitDtl.Width = 0.75F;
            // 
            // Date_SalesGrossMarginRate
            // 
            this.Date_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.CanGrow = false;
            this.Date_SalesGrossMarginRate.Height = 0.125F;
            this.Date_SalesGrossMarginRate.Left = 10.0625F;
            this.Date_SalesGrossMarginRate.Name = "Date_SalesGrossMarginRate";
            this.Date_SalesGrossMarginRate.OutputFormat = resources.GetString("Date_SalesGrossMarginRate.OutputFormat");
            this.Date_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesGrossMarginRate.Text = "-100.00";
            this.Date_SalesGrossMarginRate.Top = 0.0625F;
            this.Date_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Date_SalesGrossMarginMark
            // 
            this.Date_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.CanGrow = false;
            this.Date_SalesGrossMarginMark.Height = 0.125F;
            this.Date_SalesGrossMarginMark.Left = 10.625F;
            this.Date_SalesGrossMarginMark.Name = "Date_SalesGrossMarginMark";
            this.Date_SalesGrossMarginMark.OutputFormat = resources.GetString("Date_SalesGrossMarginMark.OutputFormat");
            this.Date_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.Date_SalesGrossMarginMark.Text = "●";
            this.Date_SalesGrossMarginMark.Top = 0.0625F;
            this.Date_SalesGrossMarginMark.Width = 0.1875F;
            // 
            // Date_SalesPercentage
            // 
            this.Date_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Height = 0.125F;
            this.Date_SalesPercentage.HyperLink = "";
            this.Date_SalesPercentage.Left = 10.5F;
            this.Date_SalesPercentage.Name = "Date_SalesPercentage";
            this.Date_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesPercentage.Text = "％";
            this.Date_SalesPercentage.Top = 0.0625F;
            this.Date_SalesPercentage.Width = 0.125F;
            // 
            // line8
            // 
            this.line8.Border.BottomColor = System.Drawing.Color.Black;
            this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.LeftColor = System.Drawing.Color.Black;
            this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.RightColor = System.Drawing.Color.Black;
            this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.TopColor = System.Drawing.Color.Black;
            this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Height = 0F;
            this.line8.Left = 0F;
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0F;
            this.line8.Width = 10.8F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // Date_SalesDtlTax
            // 
            this.Date_SalesDtlTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesDtlTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesDtlTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesDtlTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesDtlTax.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesDtlTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesDtlTax.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesDtlTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesDtlTax.DataField = "SalesDtlTax";
            this.Date_SalesDtlTax.Height = 0.125F;
            this.Date_SalesDtlTax.Left = 8.6875F;
            this.Date_SalesDtlTax.MultiLine = false;
            this.Date_SalesDtlTax.Name = "Date_SalesDtlTax";
            this.Date_SalesDtlTax.OutputFormat = resources.GetString("Date_SalesDtlTax.OutputFormat");
            this.Date_SalesDtlTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesDtlTax.SummaryGroup = "DateHeader";
            this.Date_SalesDtlTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesDtlTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesDtlTax.Text = "1,234,567";
            this.Date_SalesDtlTax.Top = 0.0625F;
            this.Date_SalesDtlTax.Visible = false;
            this.Date_SalesDtlTax.Width = 0.5625F;
            // 
            // DCHNB02012P_04A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.83125F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader1);
            this.Sections.Add(this.GlandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Header1);
            this.Sections.Add(this.DateHeader);
            this.Sections.Add(this.Header2);
            this.Sections.Add(this.Header3);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.Footer3);
            this.Sections.Add(this.Footer2);
            this.Sections.Add(this.DateFooter);
            this.Sections.Add(this.Footer1);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GlandTotalFooter);
            this.Sections.Add(this.TitleFooter1);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet1"), "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: italic; font-variant: inherit; font-weight: bold; font-size-adjust: i" +
                        "nherit; font-stretch: inherit; font-family: \"ＭＳ Ｐ明朝\"; font-size: 10pt; text-alig" +
                        "n: right; ddo-char-set: 128; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet2"), "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.DCHNB02012P_04A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderDivName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCntPlusAdjustCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMarkDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginRateDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Percentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpADate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxationDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCdDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcptAnOdrRemainCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInputName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSlipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessTypeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarMngCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CostTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossMarginRateDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_TotalCostDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesMoneyDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesDtlTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalCostDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesMoneyDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesDtlTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CntSalesDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesMoneyDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_TotalCostDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_SalesLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesDtlTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CntSalesDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesMoneyDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_TotalCostDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_SalesLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesGrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_SalesDtlTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer2_ConsTaxLayMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesMoneyDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_TotalCostDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossProfitDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesDtlTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

		// ===============================================================================
		// 内部使用関数
		// ===============================================================================
		#region private methods


		/// <summary>
		/// 罫線表示非表示制御処理
		/// </summary>
		/// <param name="sections">対象オブジェクト</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// </remarks>
        private void SetVisibleRuledLine(ref Section sections)
        {
            // 罫線有無判定
            bool isRuledLine = (this._printInfo.frycd == 1);


            for (int i = 0; i < sections.Controls.Count; i++)
            {
                if (sections.Controls[i] is Line)
                {
                    Line line = (Line)sections.Controls[i];

                    // 表示非表示対象の罫線か
                    if (line.Name.IndexOf("RuledLine") != -1)
                    {
                        line.Visible = isRuledLine;
                    }
                }
            }
        }

        /// <summary>
        /// 小計印字のDataField設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: ソート順の小計についてDataFieldを設定します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.29</br>
        /// </remarks>
        private void ChangeGroupOrder()
        {
            // 2008.12.09 30413 犬飼 貸出日計を追加のため、印字設定を変更 >>>>>>START
            switch (this._extraInfo.SortOrder)
            {
                case 0:  // 貸出日+伝票番号
                    {
                        //this.Header1.DataField = "SalesSlipNum";
                        //// 2008.10.08 980035 金沢 貞義 修正 >>>>>>START
                        ////this.Footer1Field.Text = "【伝票計】";
                        //this.Footer1Field.Text = "伝票計";
                        //// 2008.10.08 980035 金沢 貞義 修正 <<<<<<END

                        //this.Header2.DataField = "";
                        //this.Footer2Field.Text = "";

                        this.Header1.DataField = "";
                        this.Footer1Field.Text = "";

                        this.Header2.DataField = "SalesSlipNum";
                        this.Footer2Field.Text = "伝票計";

                        break;
                    }

                case 1:  // 伝票番号
                    {
                        //this.Header1.DataField = "SalesSlipNum";
                        //// 2008.10.08 980035 金沢 貞義 修正 >>>>>>START
                        ////this.Footer1Field.Text = "【伝票計】";
                        //this.Footer1Field.Text = "伝票計";
                        //// 2008.10.08 980035 金沢 貞義 修正 <<<<<<END

                        //this.Header2.DataField = "";
                        //this.Footer2Field.Text = "";

                        this.Header1.DataField = "";
                        this.Footer1Field.Text = "";

                        this.Header2.DataField = "SalesSlipNum";
                        this.Footer2Field.Text = "伝票計";

                        break;
                    }
                case 2:  // 得意先+伝票番号
                    {
                        this.Header1.DataField = "CustomerCode";
                        // 2008.10.08 980035 金沢 貞義 修正 >>>>>>START
                        //this.Footer1Field.Text = "【得意先計】";
                        this.Footer1Field.Text = "得意先計";
                        // 2008.10.08 980035 金沢 貞義 修正 <<<<<<END

                        this.Header2.DataField = "SalesSlipNum";
                        // 2008.10.08 980035 金沢 貞義 修正 >>>>>>START
                        //this.Footer2Field.Text = "【伝票計】";
                        this.Footer2Field.Text = "伝票計";
                        // 2008.10.08 980035 金沢 貞義 修正 <<<<<<END

                        break;
                    }
                case 3:  // 担当者+伝票番号
                    {
                        this.Header1.DataField = "SalesEmployeeNm";
                        // 2008.10.08 980035 金沢 貞義 修正 >>>>>>START
                        //this.Footer1Field.Text = "【担当者計】";
                        this.Footer1Field.Text = "担当者計";
                        // 2008.10.08 980035 金沢 貞義 修正 <<<<<<END

                        this.Header2.DataField = "SalesSlipNum";
                        // 2008.10.08 980035 金沢 貞義 修正 >>>>>>START
                        //this.Footer2Field.Text = "【伝票計】";
                        this.Footer2Field.Text = "伝票計";
                        // 2008.10.08 980035 金沢 貞義 修正 <<<<<<END

                        break;
                    }
            }
            // 2008.12.09 30413 犬飼 貸出日計を追加のため、印字設定を変更 <<<<<<END
        }

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>
        /// 原価・粗利印字制御処理
        /// </summary>
        private void ChangeCostPrt()
        {
            switch (this._extraInfo.CostOut)
            {
                case 0:  // 印字しない
                    {
                        // ↓↓タイトル部
                        // 原価金額
                        this.Label_CostTitle.Visible = false;
                        // 粗利(明細)
                        this.Label_GrossProfitDtl.Visible = false;
                        // 粗利率(明細)
                        this.Label_GrossMarginRateDtl.Visible = false;


                        // ↓↓明細部
                        // 原価金額
                        this.Cost.Visible = false;
                        // 粗利(明細)
                        this.GrossProfitDtl.Visible = false;
                        // 粗利率(明細)
                        this.GrossMarginRateDtl.Visible = false;
                        // パーセント(ラベル表示)
                        this.Label_Percentage.Visible = false;
                        // 粗利率のマーク
                        this.GrossMarginMarkDtl.Visible = false;

                        // ↓↓小計部(Footer2)
                        this.Footer2_TotalCostDtl.Visible = false;
                        this.Footer2_SalesGrossProfitDtl.Visible = false;
                        this.Footer2_SalesGrossMarginRate.Visible = false;
                        this.Footer2_SalesPercentage.Visible = false;
                        this.Footer2_SalesGrossMarginMark.Visible = false;

                        // ↓↓受注日計部(Date)
                        this.Date_TotalCostDtl.Visible = false;
                        this.Date_SalesGrossProfitDtl.Visible = false;
                        this.Date_SalesGrossMarginRate.Visible = false;
                        this.Date_SalesPercentage.Visible = false;
                        this.Date_SalesGrossMarginMark.Visible = false;

                        // ↓↓小計部(Footer1)
                        this.Footer1_TotalCostDtl.Visible = false;
                        this.Footer1_SalesGrossProfitDtl.Visible = false;
                        this.Footer1_SalesGrossMarginRate.Visible = false;
                        this.Footer1_SalesPercentage.Visible = false;
                        this.Footer1_SalesGrossMarginMark.Visible = false;

                        // ↓↓拠点計部
                        this.Section_TotalCostDtl.Visible = false;
                        this.Section_SalesGrossProfitDtl.Visible = false;
                        this.Section_SalesGrossMarginRate.Visible = false;
                        this.Section_SalesPercentage.Visible = false;
                        this.Section_SalesGrossMarginMark.Visible = false;

                        // ↓↓総合計部
                        this.Grand_TotalCostDtl.Visible = false;
                        this.Grand_SalesGrossProfitDtl.Visible = false;
                        this.Grand_SalesGrossMarginRate.Visible = false;
                        this.Grand_SalesPercentage.Visible = false;
                        this.Grand_SalesGrossMarginMark.Visible = false;

                        break;
                    }

                case 1:  // 印字する
                    {
                        // ↓↓タイトル部
                        // 原価金額
                        this.Label_CostTitle.Visible = true;
                        // 粗利(明細)
                        this.Label_GrossProfitDtl.Visible = true;
                        // 粗利率(明細)
                        this.Label_GrossMarginRateDtl.Visible = true;


                        // ↓↓明細部
                        // 原価金額
                        this.Cost.Visible = true;
                        // 粗利(明細)
                        this.GrossProfitDtl.Visible = true;
                        // 粗利率(明細)
                        this.GrossMarginRateDtl.Visible = true;
                        // パーセント(ラベル表示)
                        this.Label_Percentage.Visible = true;
                        // 粗利率のマーク
                        this.GrossMarginMarkDtl.Visible = true;

                        // ↓↓小計部(Footer2)
                        this.Footer2_TotalCostDtl.Visible = true;
                        this.Footer2_SalesGrossProfitDtl.Visible = true;
                        this.Footer2_SalesGrossMarginRate.Visible = true;
                        this.Footer2_SalesPercentage.Visible = true;
                        this.Footer2_SalesGrossMarginMark.Visible = true;

                        // ↓↓受注部(Date)
                        this.Date_TotalCostDtl.Visible = true;
                        this.Date_SalesGrossProfitDtl.Visible = true;
                        this.Date_SalesGrossMarginRate.Visible = true;
                        this.Date_SalesPercentage.Visible = true;
                        this.Date_SalesGrossMarginMark.Visible = true;

                        // ↓↓小計部(Footer1)
                        this.Footer1_TotalCostDtl.Visible = true;
                        this.Footer1_SalesGrossProfitDtl.Visible = true;
                        this.Footer1_SalesGrossMarginRate.Visible = true;
                        this.Footer1_SalesPercentage.Visible = true;
                        this.Footer1_SalesGrossMarginMark.Visible = true;

                        // ↓↓拠点計部
                        this.Section_TotalCostDtl.Visible = true;
                        this.Section_SalesGrossProfitDtl.Visible = true;
                        this.Section_SalesGrossMarginRate.Visible = true;
                        this.Section_SalesPercentage.Visible = true;
                        this.Section_SalesGrossMarginMark.Visible = true;

                        // ↓↓総合計部
                        this.Grand_TotalCostDtl.Visible = true;
                        this.Grand_SalesGrossProfitDtl.Visible = true;
                        this.Grand_SalesGrossMarginRate.Visible = true;
                        this.Grand_SalesPercentage.Visible = true;
                        this.Grand_SalesGrossMarginMark.Visible = true;

                        break;
                    }
            }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<

        /// <summary>
        /// 小計印字制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: ソート順の小計について印字を設定します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.29</br>
        /// </remarks>
        private void ChangeSumRec()
        {
            // 2008.12.09 30413 犬飼 貸出日計を追加のため、印字設定を変更 >>>>>>START
            switch (this._extraInfo.SortOrder)
            {
                case 0:  // 貸出日+伝票番号
                    {
                        //this.Header1.Visible = true;
                        //this.Footer1.Visible = true;   // 伝票計

                        //this.Header2.Visible = false;
                        //this.Footer2.Visible = false;  // 

                        this.Header1.Visible = false;
                        this.Footer1.Visible = false;   // 

                        this.Header2.Visible = true;
                        this.Footer2.Visible = true;    // 伝票計

                        break;
                    }

                case 1:  // 伝票番号
                    {
                        //this.Header1.Visible = true;
                        //this.Footer1.Visible = true;   // 伝票計

                        //this.Header2.Visible = false;
                        //this.Footer2.Visible = false;  // 

                        this.Header1.Visible = false;
                        this.Footer1.Visible = false;   // 

                        this.Header2.Visible = true;
                        this.Footer2.Visible = true;    // 伝票計

                        break;
                    }
                case 2:  // 得意先+伝票番号
                    {
                        this.Header1.Visible = true;
                        this.Footer1.Visible = true;   // 得意先

                        this.Header2.Visible = true;
                        this.Footer2.Visible = true;   // 伝票計

                        break;
                    }
                case 3:  // 担当者+伝票番号
                    {
                        this.Header1.Visible = true;
                        this.Footer1.Visible = true;   // 担当者計

                        this.Header2.Visible = true;
                        this.Footer2.Visible = true;   // 伝票計

                        break;
                    }
            }
            // 2008.12.09 30413 犬飼 貸出日計を追加のため、印字設定を変更 <<<<<<END

            // --- ADD 2009/03/30 -------------------------------->>>>>
            // 受注日計の印字制御
            if (this._extraInfo.PrintDailyFooter == 0)
            {
                this.DateFooter.Visible = false;
            }
            else
            {
                this.DateFooter.Visible = true;
            }
            // --- ADD 2009/03/30 --------------------------------<<<<<
            
            if (this.Footer1Field.Text == "伝票計")
            {
                // 伝票計は純売上のみ印字
                //f1_SalesTtl.Visible = false; // DEL 2009/03/30
                f1_CntSalesDtl.Visible = false;
                f1_SalesLbl.Visible = false;
                Footer1_TotalCostDtl.DataField = "Cost";
                Footer1_SalesMoneyDtl.DataField = "SalesMoneyTaxExc";
                Footer1_SalesGrossProfitDtl.DataField = "GrossProfitDtl";
                Footer1_SalesDtlTax.DataField = "Tax";

                // --- DEL 2009/03/30 -------------------------------->>>>>
                //f1_ReturnTtl.Visible = false;
                //f1_CntReturnDtl.Visible = false;
                //f1_ReturnLbl.Visible = false;
                //Footer1_TotalCostRtnDtl.Visible = false;
                //Footer1_SalesMoneyRtnDtl.Visible = false;
                //Footer1_ReturnGrossProfitDtl.Visible = false;
                //Footer1_ReturnGrossMarginRate.Visible = false;
                //Footer1_ReturnPercentage.Visible = false;
                //Footer1_ReturnGrossMarginMark.Visible = false;
                //Footer1_ReturnDtlTax.Visible = false;

                //f1_DistTtl.Visible = false;
                //Footer1_DistDtlCost.Visible = false;
                //Footer1_SalesDisTtlTaxExcDtl.Visible = false;
                //Footer1_DistGrossProfitDtl.Visible = false;
                //Footer1_DistGrossMarginRate.Visible = false;
                //Footer1_DistPercentage.Visible = false;
                //Footer1_DistGrossMarginMark.Visible = false;
                //Footer1_DistDtlTax.Visible = false;

                //f1_PureSalesTtl.Visible = false;
                //Footer1_Cost.Visible = false;
                //Footer1_SalesMoneyTaxExc.Visible = false;
                //Footer1_GrossProfitDtl.Visible = false;
                //Footer1_TotalGrossMarginRate.Visible = false;
                //Footer1_TotalPercentage.Visible = false;
                //Footer1_TotalGrossMarginMark.Visible = false;
                //Footer1_TotalTax.Visible = false;
                // --- DEL 2009/03/30 --------------------------------<<<<<
            }
            else if (this.Footer2Field.Text == "伝票計")
            {
                // 伝票計は純売上のみ印字
                //f2_SalesTtl.Visible = false; // DEL 2009/03/30
                f2_CntSalesDtl.Visible = false;
                f2_SalesLbl.Visible = false;
                Footer2_TotalCostDtl.DataField = "Cost";
                Footer2_SalesMoneyDtl.DataField = "SalesMoneyTaxExc";
                Footer2_SalesGrossProfitDtl.DataField = "GrossProfitDtl";
                Footer2_SalesDtlTax.DataField = "Tax";

                // --- DEL 2009/03/30 -------------------------------->>>>>
                //f2_ReturnTtl.Visible = false;
                //f2_CntReturnDtl.Visible = false;
                //f2_ReturnLbl.Visible = false;
                //Footer2_TotalCostRtnDtl.Visible = false;
                //Footer2_SalesMoneyRtnDtl.Visible = false;
                //Footer2_ReturnGrossProfitDtl.Visible = false;
                //Footer2_ReturnGrossMarginRate.Visible = false;
                //Footer2_ReturnPercentage.Visible = false;
                //Footer2_ReturnGrossMarginMark.Visible = false;
                //Footer2_ReturnDtlTax.Visible = false;

                //f2_DistTtl.Visible = false;
                //Footer2_DistDtlCost.Visible = false;
                //Footer2_SalesDisTtlTaxExcDtl.Visible = false;
                //Footer2_DistGrossProfitDtl.Visible = false;
                //Footer2_DistGrossMarginRate.Visible = false;
                //Footer2_DistPercentage.Visible = false;
                //Footer2_DistGrossMarginMark.Visible = false;
                //Footer2_DistDtlTax.Visible = false;

                //f2_PureSalesTtl.Visible = false;
                //Footer2_Cost.Visible = false;
                //Footer2_SalesMoneyTaxExc.Visible = false;
                //Footer2_GrossProfitDtl.Visible = false;
                //Footer2_TotalGrossMarginRate.Visible = false;
                //Footer2_TotalPercentage.Visible = false;
                //Footer2_TotalGrossMarginMark.Visible = false;
                //Footer2_TotalTax.Visible = false;
                // --- DEL 2009/03/30 --------------------------------<<<<<
            }
        }
		
		#endregion

        
		#region

        #region 総合計の粗利率を出力
        /// <summary>
        /// 総合計の粗利率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 総合計の各粗利率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void GlandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // 売上の粗利率を設定
            grossMarginRate = this.Grand_SalesGrossMarginRate.Text;
            grossMarginMark = this.Grand_SalesGrossMarginMark.Text;
            // 粗利率設定
            SetGrossMargin(this.Grand_SalesMoneyDtl.Text, this.Grand_TotalCostDtl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Grand_SalesGrossMarginRate.Text = grossMarginRate;
            this.Grand_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// 返品の粗利率を設定
            //grossMarginRate = this.Grand_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Grand_ReturnGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Grand_SalesMoneyRtnDtl.Text, this.Grand_TotalCostRtnDtl.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Grand_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Grand_ReturnGrossMarginMark.Text = grossMarginMark;

            //// 値引きの粗利率を設定
            //grossMarginRate = this.Grand_DistGrossMarginRate.Text;
            //grossMarginMark = this.Grand_DistGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Grand_SalesDisTtlTaxExcDtl.Text, this.Grand_DistDtlCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Grand_DistGrossMarginRate.Text = grossMarginRate;
            //this.Grand_DistGrossMarginMark.Text = grossMarginMark;

            //// 純売上の粗利率を設定
            //grossMarginRate = this.Grand_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Grand_TotalGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Grand_SalesMoneyTaxExc.Text, this.Grand_Cost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Grand_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Grand_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        #region 拠点計の粗利率を出力
        /// <summary>
        /// 拠点計の粗利率を出力する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点計の各粗利率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // 売上の粗利率を設定
            grossMarginRate = this.Section_SalesGrossMarginRate.Text;
            grossMarginMark = this.Section_SalesGrossMarginMark.Text;
            // 粗利率設定
            SetGrossMargin(this.Section_SalesMoneyDtl.Text, this.Section_TotalCostDtl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Section_SalesGrossMarginRate.Text = grossMarginRate;
            this.Section_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// 返品の粗利率を設定
            //grossMarginRate = this.Section_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Section_ReturnGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Section_SalesMoneyRtnDtl.Text, this.Section_TotalCostRtnDtl.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Section_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Section_ReturnGrossMarginMark.Text = grossMarginMark;

            //// 値引きの粗利率を設定
            //grossMarginRate = this.Section_DistGrossMarginRate.Text;
            //grossMarginMark = this.Section_DistGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Section_SalesDisTtlTaxExcDtl.Text, this.Section_DistDtlCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Section_DistGrossMarginRate.Text = grossMarginRate;
            //this.Section_DistGrossMarginMark.Text = grossMarginMark;

            //// 純売上の粗利率を設定
            //grossMarginRate = this.Section_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Section_TotalGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Section_SalesMoneyTaxExc.Text, this.Section_Cost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Section_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Section_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        #region Footer2の粗利率を出力
        /// <summary>
        /// Footer2の粗利率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: Footer2の各粗利率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void Footer2_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // 売上の粗利率を設定
            grossMarginRate = this.Footer2_SalesGrossMarginRate.Text;
            grossMarginMark = this.Footer2_SalesGrossMarginMark.Text;
            // 粗利率設定
            SetGrossMargin(this.Footer2_SalesMoneyDtl.Text, this.Footer2_TotalCostDtl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Footer2_SalesGrossMarginRate.Text = grossMarginRate;
            this.Footer2_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// 返品の粗利率を設定
            //grossMarginRate = this.Footer2_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Footer2_ReturnGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Footer2_SalesMoneyRtnDtl.Text, this.Footer2_TotalCostRtnDtl.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer2_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Footer2_ReturnGrossMarginMark.Text = grossMarginMark;

            //// 値引きの粗利率を設定
            //grossMarginRate = this.Footer2_DistGrossMarginRate.Text;
            //grossMarginMark = this.Footer2_DistGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Footer2_SalesDisTtlTaxExcDtl.Text, this.Footer2_DistDtlCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer2_DistGrossMarginRate.Text = grossMarginRate;
            //this.Footer2_DistGrossMarginMark.Text = grossMarginMark;

            //// 純売上の粗利率を設定
            //grossMarginRate = this.Footer2_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Footer2_TotalGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Footer2_SalesMoneyTaxExc.Text, this.Footer2_Cost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer2_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Footer2_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<

            // --- ADD 2009/03/30 -------------------------------->>>>>
            // 消費税印字制御
            if (this.Footer2_ConsTaxLayMethod.Value.ToString().TrimEnd() != "0"
                    && this.Footer2_ConsTaxLayMethod.Value.ToString().TrimEnd() != "1")
            {
                this.Footer2_SalesDtlTax.Text = "";
            }
            // --- ADD 2009/03/30 --------------------------------<<<<<
        }
        #endregion


        #region Footer1の粗利率を出力
        /// <summary>
        /// Footer1の粗利率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: Footer1の各粗利率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void Footer1_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // 売上の粗利率を設定
            grossMarginRate = this.Footer1_SalesGrossMarginRate.Text;
            grossMarginMark = this.Footer1_SalesGrossMarginMark.Text;
            // 粗利率設定
            SetGrossMargin(this.Footer1_SalesMoneyDtl.Text, this.Footer1_TotalCostDtl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Footer1_SalesGrossMarginRate.Text = grossMarginRate;
            this.Footer1_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// 返品の粗利率を設定
            //grossMarginRate = this.Footer1_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Footer1_ReturnGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Footer1_SalesMoneyRtnDtl.Text, this.Footer1_TotalCostRtnDtl.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer1_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Footer1_ReturnGrossMarginMark.Text = grossMarginMark;

            //// 値引きの粗利率を設定
            //grossMarginRate = this.Footer1_DistGrossMarginRate.Text;
            //grossMarginMark = this.Footer1_DistGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Footer1_SalesDisTtlTaxExcDtl.Text, this.Footer1_DistDtlCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer1_DistGrossMarginRate.Text = grossMarginRate;
            //this.Footer1_DistGrossMarginMark.Text = grossMarginMark;

            //// 純売上の粗利率を設定
            //grossMarginRate = this.Footer1_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Footer1_TotalGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Footer1_SalesMoneyTaxExc.Text, this.Footer1_Cost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer1_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Footer1_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        #region DateFooterの粗利率を出力
        /// <summary>
        /// DateFooterの粗利率を出力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: DateFooterの各粗利率を出力します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.09</br>
        /// </remarks>
        private void DateFooter_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // 売上の粗利率を設定
            grossMarginRate = this.Date_SalesGrossMarginRate.Text;
            grossMarginMark = this.Date_SalesGrossMarginMark.Text;
            // 粗利率設定
            SetGrossMargin(this.Date_SalesMoneyDtl.Text, this.Date_TotalCostDtl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Date_SalesGrossMarginRate.Text = grossMarginRate;
            this.Date_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// 返品の粗利率を設定
            //grossMarginRate = this.Date_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Date_ReturnGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Date_SalesMoneyRtnDtl.Text, this.Date_TotalCostRtnDtl.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Date_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Date_ReturnGrossMarginMark.Text = grossMarginMark;

            //// 値引きの粗利率を設定
            //grossMarginRate = this.Date_DistGrossMarginRate.Text;
            //grossMarginMark = this.Date_DistGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Date_SalesDisTtlTaxExcDtl.Text, this.Date_DistDtlCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Date_DistGrossMarginRate.Text = grossMarginRate;
            //this.Date_DistGrossMarginMark.Text = grossMarginMark;

            //// 純売上の粗利率を設定
            //grossMarginRate = this.Date_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Date_TotalGrossMarginMark.Text;
            //// 粗利率設定
            //SetGrossMargin(this.Date_SalesMoneyTaxExc.Text, this.Date_Cost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Date_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Date_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        /// <summary>
        /// 粗利率の設定処理
        /// </summary>
        /// <param name="money">金額</param>
        /// <param name="cost">原価</param>
        /// <param name="grossMarginRate">粗利率</param>
        /// <param name="grossMarginMark">粗利チェックマーク</param>
        /// <remarks>
        /// <br>Note		: 金額と原価から粗利率を設定します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void SetGrossMargin(string money, string cost, ref string grossMarginRate, ref string grossMarginMark)
        {
            double rate = new double();

            // 文字列初期化
            grossMarginRate = "";
            grossMarginMark = "";

            // カンマの除去
            money = money.Replace(",", "");         // 金額
            cost = cost.Replace(",", "");           // 原価

            // 金額と原価が"0"の場合、粗利率は"0.00"を返す
            if ((money == "0") && (cost == "0"))
            {
                rate = 0.00;
                grossMarginRate = "0.00";
            }
            // 金額が"0"、原価が0以上の場合、粗利率は"0.00"を返す
            else if ((money == "0") && (Int64.Parse(cost) >= 0))
            {
                rate = 0.00;
                grossMarginRate = "0.00";
            }
            // 上記以外の場合、粗利率を計算する
            else
            {
                rate = ((double.Parse(money) - double.Parse(cost)) / double.Parse(money) * 100);
                grossMarginRate = String.Format("{0:F2}", rate);
            }

            // 粗利マークの設定
            if (rate < this._extraInfo.GrsProfitCheckLower)
            {
                grossMarginMark = this._extraInfo.GrossMargin1Mark;
            }
            else if (rate < this._extraInfo.GrsProfitCheckBest)//add 2011/12/02 陳建明 Redmine #8316
            //else if ((rate >= this._extraInfo.GrsProfitCheckLower) && (rate <= this._extraInfo.GrossMarginBest2))//del 2011/12/02 陳建明 Redmine #8316
            {
                grossMarginMark = this._extraInfo.GrossMargin2Mark;
            }
            else if (rate < this._extraInfo.GrsProfitCheckUpper)//add 2011/12/02 陳建明 Redmine #8316
            //else if ((rate >= this._extraInfo.GrsProfitCheckBest) && (rate <= this._extraInfo.GrossMarginUpper2))//del 2011/12/02 陳建明 Redmine #8316
            {
                grossMarginMark = this._extraInfo.GrossMargin3Mark;
            }
            else
            {
                grossMarginMark = this._extraInfo.GrossMargin4Mark;
            }
        }

        // --- ADD 2008/10/31 --------------------------------------------------------->>>>>
        /// <summary>
        /// Detail書式設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_Format(object sender, EventArgs e)
        {
            /*------ DEL caohh 2011/08/11 ------->>>>>
            // 消費税転嫁方式　0：伝票単位
            if (this.ConsTaxLayMethod.Value.ToString().TrimEnd() == "0")
            {
                this.Tax.Visible = false;
            }
            // 消費税転嫁方式　1：明細単位
            else if (this.ConsTaxLayMethod.Value.ToString().TrimEnd() == "1")
            {
                // 課税区分　0：課税、2：内税
                if ((this.TaxationDivCd.Value.ToString().TrimEnd() == "0") ||
                    (this.TaxationDivCd.Value.ToString().TrimEnd() == "2"))
                {
                    this.Tax.Visible = true;
                }
                // 課税区分　1：非課税
                else
                {
                    this.Tax.Visible = false;
                }
            }
            // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
            else
            {
                // 課税区分　2：内税
                if (this.TaxationDivCd.Value.ToString().TrimEnd() == "2")
                {
                    this.Tax.Visible = true;
                }
                // 課税区分　0：課税、1：非課税
                else
                {
                    this.Tax.Visible = false;
                }
            }
            ------ DEL caohh 2011/08/11 -------<<<<<*/

            // 2008.11.25 30413 犬飼 売上伝票区分(明細)で印字項目を制御 >>>>>>START
            string salesSlipCdDtl = this.SalesSlipCdDtl.Value.ToString().TrimEnd();
            // 2008.12.18 30413 犬飼 商品値引は通常明細と同様の印字を行うように修正
            string goodNo = this.GoodsNo.Value.ToString();
            //if ((salesSlipCdDtl == "2") || (salesSlipCdDtl == "3"))
            if (((goodNo == "") && (salesSlipCdDtl == "2")) || (salesSlipCdDtl == "3"))
            {
                // 売上伝票区分(明細)が行値引または注釈
                SalesOrderDivName.Visible = false;              // 在取
                ListPriceTaxExcFl.Visible = false;              // 標準価格
                AcceptAnOrderCntPlusAdjustCnt.Visible = false;  // 受注数
                SalesUnitCost.Visible = false;                  // 原単価
                SalesUnPrcTaxExcFl.Visible = false;             // 売単価
                Cost.Visible = false;                           // 原価
                GrossMarginRateDtl.Visible = false;             // 粗利率
                Label_Percentage.Visible = false;               // パーセント(ラベル表示)
                GrossMarginMarkDtl.Visible = false;             // 粗利率のマーク
                AcptAnOdrRemainCnt.Visible = false;             // 受注残数  // ADD 2009/01/30

                if (salesSlipCdDtl == "3")
                {
                    // 注釈は以下も項目を非印字
                    SalesMoneyTaxExc.Visible = false;           // 金額
                    //Tax.Visible = false;                        // 消費税   // DEL caohh 2011/08/11
                    GrossProfitDtl.Visible = false;             // 粗利
                }
                // 2009.01.27 30413 犬飼 行値引の印字制御を追加 >>>>>>START
                else
                {
                    // 行値引き
                    SalesMoneyTaxExc.Visible = true;            // 金額
                    //GrossProfitDtl.Visible = true;              // 粗利 // DEL 2009/03/30
                }
                // 2009.01.27 30413 犬飼 行値引の印字制御を追加 <<<<<<END
            }
            else
            {
                // 上記以外
                SalesOrderDivName.Visible = true;               // 在取
                ListPriceTaxExcFl.Visible = true;               // 標準価格
                AcceptAnOrderCntPlusAdjustCnt.Visible = true;   // 受注数
                SalesUnitCost.Visible = true;                   // 原単価
                AcptAnOdrRemainCnt.Visible = true;             // 受注残数  // ADD 2009/01/30

                string salesUnPrcTaxExcFl = this.SalesUnPrcTaxExcFl.Value.ToString().TrimEnd();
                if (salesUnPrcTaxExcFl == "0")
                {
                    // 売単価が"0"の場合は非印字
                    SalesUnPrcTaxExcFl.Visible = false;
                }
                else
                {
                    // 上記以外の場合は印字
                    SalesUnPrcTaxExcFl.Visible = true;
                }

                //Cost.Visible = true;                            // 原価金額 // DEL 2009/03/30
                SalesMoneyTaxExc.Visible = true;                // 金額
                //Tax.Visible = false;                            // 消費税
                //GrossProfitDtl.Visible = true;                  // 粗利 // DEL 2009/03/30
                //GrossMarginRateDtl.Visible = true;              // 粗利率(明細) // DEL 2009/03/30
                //Label_Percentage.Visible = true;                // パーセント(ラベル表示) // DEL 2009/03/30
                //GrossMarginMarkDtl.Visible = true;              // 粗利率のマーク // DEL 2009/03/30
            }
            // 2008.11.25 30413 犬飼 売上伝票区分(明細)で印字項目を制御 <<<<<<END
        }

        /// <summary>
        /// Footer2書式設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Footer2_Format(object sender, EventArgs e)
        {
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 >>>>>>START
            //// 消費税0は印字しない
            //if (this.Footer2_TotalTax.Text == "0")
            //{
            //    this.Footer2_TotalTax.Visible = false;
            //}
            //else
            //{
            //    this.Footer2_TotalTax.Visible = true;
            //}
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 <<<<<<END
        }

        /// <summary>
        /// Footer1書式設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Footer1_Format(object sender, EventArgs e)
        {
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 >>>>>>START
            //// 消費税0は印字しない
            //if (this.Footer1_TotalTax.Text == "0")
            //{
            //    this.Footer1_TotalTax.Visible = false;
            //}
            //else
            //{
            //    this.Footer1_TotalTax.Visible = true;
            //}
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 <<<<<<END
        }

        /// <summary>
        /// SectionFooter書式設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_Format_1(object sender, EventArgs e)
        {
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 >>>>>>START
            //// 消費税0は印字しない
            //if (this.Section_TotalTax.Text == "0")
            //{
            //    this.Section_TotalTax.Visible = false;
            //}
            //else
            //{
            //    this.Section_TotalTax.Visible = true;
            //}
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 <<<<<<END
        }

        /// <summary>
        /// GlandTotalFooter書式設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlandTotalFooter_Format(object sender, EventArgs e)
        {
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 >>>>>>START
            //// 消費税0は印字しない
            //if (this.Grand_TotalTax.Text == "0")
            //{
            //    this.Grand_TotalTax.Visible = false;
            //}
            //else
            //{
            //    this.Grand_TotalTax.Visible = true;
            //}
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 <<<<<<END
        }

        // --- ADD 2008/10/31 ---------------------------------------------------------<<<<<

        /// <summary>
        /// DateFooter書式設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateFooter_Format(object sender, EventArgs e)
        {
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 >>>>>>START
            //// 消費税0は印字しない
            //if (this.Date_TotalTax.Text == "0")
            //{
            //    this.Date_TotalTax.Visible = false;
            //}
            //else
            //{
            //    this.Date_TotalTax.Visible = true;
            //}
            // 2009.01.27 30413 犬飼 消費税をゼロ印字に修正 <<<<<<END
        }
        
		//TODO：10/31
		// 抽出条件中以下項目が選択されていた時だけ印字という処理。
		//もともと受注出荷表Ｕクラスに以下の抽出条件は無いためこのままの設定だと印字されない。
		//マスタ設定の方で抽出条件に使用される可能性があるので、とりあえず以下のメソッドは保留。
 #if false
		/// <summary>
        /// 原価・粗利印字制御処理
		/// </summary>
        private void ChangeCostPrt()
        {
            switch (this._extraInfo.CostOut)
            {

                case 0:  // 印字しない
                    {
						//『原価金額』
						this.label13.Visible = false;
						//『粗利率』(伝票)
						this.lblGrossMarginRate.Visible = false;

						//粗利率(伝票)
						this.GrossMarginRate.Visible = false;
						//粗利率チェック記号(伝票)
						this.GrossMarginMarkSlip.Visible = false;

						//原価金額
						this.CostRF.Visible = false;
					
                        break;
                    }

				case 1:  // 印字する
                    {
						//『原価金額』
						this.label13.Visible = true;
                        //『粗利率』(伝票)
						this.lblGrossMarginRate.Visible = true;
                        
                        //粗利率(伝票)
                        this.GrossMarginRate.Visible = true;
                        //粗利率チェック記号(伝票)
                        this.GrossMarginMarkSlip.Visible = true;
                        //原価金額
                        this.CostRF.Visible = true;

						this.ALLSUMCOST.Visible = true;
                        

                        break;
                    }
            }

        }
#endif
		#endregion
	}
}
