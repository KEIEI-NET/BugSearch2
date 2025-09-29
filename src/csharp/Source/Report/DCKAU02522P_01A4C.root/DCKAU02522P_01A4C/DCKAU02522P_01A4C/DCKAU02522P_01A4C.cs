using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 回収予定表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 回収予定表のフォームクラスです。</br>
	/// <br>Programmer	: 20081 疋田　勇人</br>
	/// <br>Date		: 2007.10.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : PM.NS対応</br>
    /// <br>Programmer  : 30413 犬飼</br>
    /// <br>Date	    : 2008.11.11</br>
    /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
    /// <br>Programmer  : 鄧潘ハン</br>
    /// <br>Date	    : 2011/03/14</br>
    /// <br>UpdateNote  : readmine20051の修正</br>
    /// <br>Programmer  : yangmj</br>
    /// <br>Date	    : 2011/03/22</br>
    /// <br>UpdateNote  : 見出し行の印字仕様を変更する（PM7相違点)</br>
    /// <br>Programmer  : 鄧潘ハン</br>
    /// <br>Date	    : 2011/03/30</br>
    /// <br></br>
    /// <br>UpdateNote : 2011/04/11  22018 鈴木 正臣</br>
    /// <br>           : フォントサイズを大きくする。印字位置微調整。</br>
    /// <br>UpdateNote : 2014/04/09  鄧潘ハン</br>
    /// <br>           : Redmine42445、回収予定表で集金区分計の金額不正の対応</br>
    /// <br>           : 画面属性修正のみ</br>
    /// <br></br>
    /// </remarks>
	public class DCKAU02522P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 回収予定表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 回収予定表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 20081　疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		public DCKAU02522P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									// 印刷件数用カウンタ

		private string				_pageHeaderSortOderTitle;		// ソート順
		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			_otherDataList;					// その他データ
        private RsltInfo_CollectPlan _rsltInfo_CollectPlan;		    // 抽出条件クラス
		// その他データ格納項目
		private string				_agentKindTitle;				// 担当者タイトル

        // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 >>>>>>START
        //private DataSet				_outputDs;						// 印刷用DataSet
        private DataView _outputDv;						// 印刷用DataView
        // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 <<<<<<END
        
        private const string ct_CollectTable = DCKAU02524EA.Col_Tbl_RsltInfo_CollectPlan;    // 回収予定表テーブル名称

        // グループ印字
        private string _sectionCd = "";
        private string _sectionCd2 = "";
        private string _calcCollectDay = "";

        // ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;
        private TextBox Total_CollectRate;
        private TextBox Section_CollectRate;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private TextBox CollectMark;
        private TextBox Em_Name;
        private TextBox Em_Code;
        private TextBox g_CalcCollectDay;
        private TextBox AddUpSecCode;
        private TextBox AddUpSecName;
        private TextBox g1_TotalTitle;
        private TextBox f1_AcpOdrTtl3TmBfBlDmd;
        private TextBox f1_AcpOdrTtl2TmBfBlDmd;
        private TextBox f1_LastTimeDemand;
        private TextBox f1_CalcThisTimeSales;
        private TextBox f1_ThisTimeDmdNrml;
        private TextBox f1_TotalAdjust;
        private TextBox f1_CalcObjPric;
        private TextBox f1_AfterCloseDemand;
        private TextBox f1_TotalExpct;
        private TextBox f1_CollectRate;
        private GroupHeader groupHeader2;
        private GroupFooter groupFooter2;
        private TextBox g_CollectCondName;
        private TextBox textBox17;
        private TextBox f2_AcpOdrTtl3TmBfBlDmd;
        private TextBox f2_AcpOdrTtl2TmBfBlDmd;
        private TextBox f2_LastTimeDemand;
        private TextBox f2_CalcThisTimeSales;
        private TextBox f2_ThisTimeDmdNrml;
        private TextBox f2_TotalAdjust;
        private TextBox f2_CalcObjPric;
        private TextBox f2_AfterCloseDemand;
        private TextBox f2_TotalExpct;
        private TextBox f2_CollectRate;
        private Line line3;
        private Line line2;
        private TextBox g_AddUpSecName;
        private TextBox g_AddUpSecCode;
        private Line line5;
        private Line line4;
        private TextBox g1_CalcCollectDay;
        private TextBox SumTitle;
        private Label SumTitle2;
        private TextBox textBox_sec;
        private TextBox textBox_emp;
        private TextBox textBox_cmd;
        private Line line6;
        private TextBox textBox_null_line;

		// Disposeチェック用フラグ
		bool disposed = false;
		#endregion ■ Private Member

		#region ■ Dispose(override)
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						// ヘッダ用サブレポート後処理実行
						if (this._rptExtraHeader != null)
						{
							this._rptExtraHeader.Dispose();
						}

						// フッタ用サブレポート後処理実行
						if (this._rptPageFooter != null)
						{
							this._rptPageFooter.Dispose();
						}
					}

					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		} 
		#endregion ■ Dispose(override)

		#region ■ IPrintActiveReportTypeList メンバ
		#region ◆ Public Property
		/// <summary>
		/// ページヘッダソート順タイトル項目
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set{ _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ _extraCondHeadOutDiv = value; }
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set{ this._extraConditions = value; }
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set{ this._pageFooterOutCode = value; }
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set{ this._pageFooters = value; }
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo			= value;
                this._rsltInfo_CollectPlan = (RsltInfo_CollectPlan)this._printInfo.jyoken;
                // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 >>>>>>START
                //this._outputDs			= (DataSet)this._printInfo.rdData;
                this._outputDv = (DataView)this._printInfo.rdData;
                // 2008.12.16 30413 犬飼 フィルター追加のため、データビューに変更 <<<<<<END
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
					if ( this._otherDataList.Count > 0 )
					{
						this._agentKindTitle		= this._otherDataList[0].ToString();
					}
				}
			}
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderSubtitle = value;}
		}

		/// <summary>
		/// 印刷件数カウントアップイベント
		/// </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;        
		#endregion ◆ Public Property
		#endregion ■ IPrintActiveReportTypeList メンバ
	
		#region ■ IPrintActiveReportTypeCommon メンバ
		#region ◆ Public Property
		/// <summary>
		/// 背景透過設定値プロパティ
		/// </summary>
		public int WatermarkMode
		{
			get
			{
				// TODO:  MAHNB02012P_02A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAHNB02012P_02A4C.WatermarkMode setter 実装を追加します。
			}
		}
		#endregion ◆ Public Property
		#endregion ■ IPrintActiveReportTypeCommon メンバ
		
		#region ■ Private Method
		#region ◆ レポート要素出力設定
		/// <summary>
		/// レポート要素出力設定
		/// </summary>
		/// <remarks>
		/// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
        /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/14</br>
        /// <br>UpdateNote  : readmine20051の修正</br>
        /// <br>Programmer  : yangmj</br>
        /// <br>Date	    : 2011/03/22</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;


            // 2008.11.14 30413 犬飼 削除項目 >>>>>>START
            //// 印字設定 --------------------------------------------------------------------------------------
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._rsltInfo_CollectPlan.IsOptSection )
            //{
            //    // 全社がチェックされていない時で拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ((this._rsltInfo_CollectPlan.CollectAddupSecCodeList.Length < 2) && (this._rsltInfo_CollectPlan.IsSelectAllSection == false))
            //    {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else
            //    {
            //        SectionHeader.DataField = DCKAU02524EA.Col_AddUpSecCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else
            //{
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}
            // 2008.11.14 30413 犬飼 削除項目 <<<<<<END
            
			// 項目の名称をセット
			tb_ReportTitle.Text			= this._pageHeaderSubtitle;		   // サブタイトル
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;   // ソート条件
            //tb_EmployeeTitle.Text		= this._agentKindTitle;			   // 担当者タイトル


            // 2008.11.14 30413 犬飼 改頁の制御 >>>>>>START
            if (this._rsltInfo_CollectPlan.NewPageDiv == 2)
            {
                // しない
                SectionHeader.NewPage = NewPage.None;
                groupHeader1.NewPage = NewPage.None;
                groupHeader2.NewPage = NewPage.None;
            }
            else
            {                
                if (this._rsltInfo_CollectPlan.NewPageDiv == 0)
                {
                    // 拠点
                    groupHeader1.NewPage = NewPage.None;
                    groupHeader2.NewPage = NewPage.None;
                }
            }
            // 2008.11.14 30413 犬飼 改頁の制御 <<<<<<END

            // 2008.11.14 30413 犬飼 出力順の制御 >>>>>>START
            switch (this._rsltInfo_CollectPlan.SortOrderDiv)
            {
                case RsltInfo_CollectPlan.SortOrderDivState.CustomerCode:   // 得意先順
                    {
                        groupFooter1.Visible = false;
                        groupHeader2.Visible = false;
                        groupFooter2.Visible = false;

                        SumTitle.Visible = false;
                        SumTitle2.Visible = false;
                        g_Em_Code.Visible = false;
                        g_Em_Name.Visible = false;
                        g_CalcCollectDay.Visible = false;
                        Em_Code.Visible = false;
                        Em_Name.Visible = false;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCode:   // 担当者順
                case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCollect:    // 担当者別回収日順
                    {
                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // 得意先担当者
                            groupHeader1.DataField = DCKAU02524EA.Col_CustomerAgentCd;

                            g_Em_Code.DataField = DCKAU02524EA.Col_CustomerAgentCd;
                            g_Em_Name.DataField = DCKAU02524EA.Col_CustomerAgentNm;
                        }
                        else
                        {
                            // 集金担当者
                            groupHeader1.DataField = DCKAU02524EA.Col_BillCollecterCd;

                            g_Em_Code.DataField = DCKAU02524EA.Col_BillCollecterCd;
                            g_Em_Name.DataField = DCKAU02524EA.Col_BillCollecterNm;
                        }

                        groupHeader2.Visible = false;
                        groupFooter2.Visible = false;
                        SumTitle2.Visible = false;
                        g_CalcCollectDay.Visible = false;
                        Em_Code.Visible = false;
                        Em_Name.Visible = false;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCode:  // 地区順
                case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCollect:   // 地区別回収日順
                    {
                        SumTitle.Text = "地区";
                        
                        groupHeader1.DataField = DCKAU02524EA.Col_SalesAreaCode;
                        g1_TotalTitle.Text = "地区計";

                        g_Em_Code.DataField = DCKAU02524EA.Col_SalesAreaCodePrint;
                        g_Em_Name.DataField = DCKAU02524EA.Col_SalesAreaName;

                        groupHeader2.Visible = false;
                        groupFooter2.Visible = false;
                        SumTitle2.Visible = false;
                        g_CalcCollectDay.Visible = false;
                        Em_Code.Visible = false;
                        Em_Name.Visible = false;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDay:    // 集金日順
                    {
                        SumTitle.Text = "集金日";
                        Label86.Text = "担当者";

                        groupHeader1.DataField = DCKAU02524EA.Col_CalcCollectDay;
                        g1_TotalTitle.Text = "集金日計";

                        // 集金日
                        g1_CalcCollectDay.Visible = true;
                        g1_CalcCollectDay.Top = 0.00F;

                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // 得意先担当者
                            Em_Code.DataField = DCKAU02524EA.Col_CustomerAgentCd;
                            Em_Name.DataField = DCKAU02524EA.Col_CustomerAgentNm;

                            Em_Code.Top = 0.00F;
                            Em_Name.Top = 0.00F;
                        }
                        else
                        {
                            // 集金担当者
                            Em_Code.DataField = DCKAU02524EA.Col_BillCollecterCd;
                            Em_Name.DataField = DCKAU02524EA.Col_BillCollecterNm;

                            Em_Code.Top = 0.00F;
                            Em_Name.Top = 0.00F;
                        }

                        groupHeader2.Visible = false;
                        groupFooter2.Visible = false;
                        SumTitle2.Visible = false;
                        g_Em_Code.Visible = false;
                        g_Em_Name.Visible = false;
                        CalcCollectDay.Visible = false;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond:    // 集金日別回収条件順
                    {
                        SumTitle.Text = "集金日";
                        Label86.Text = "担当者";

                        groupHeader1.DataField = DCKAU02524EA.Col_CalcCollectDay;
                        groupHeader2.DataField = DCKAU02524EA.Col_CollectCond;
                        g1_TotalTitle.Text = "集金日計";

                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // 得意先担当者
                            Em_Code.DataField = DCKAU02524EA.Col_CustomerAgentCd;
                            Em_Name.DataField = DCKAU02524EA.Col_CustomerAgentNm;

                            Em_Code.Top = 0.00F;
                            Em_Name.Top = 0.00F;
                        }
                        else
                        {
                            // 集金担当者
                            Em_Code.DataField = DCKAU02524EA.Col_BillCollecterCd;
                            Em_Name.DataField = DCKAU02524EA.Col_BillCollecterNm;

                            Em_Code.Top = 0.00F;
                            Em_Name.Top = 0.00F;
                        }

                        AddUpSecCode.Visible = false;
                        AddUpSecName.Visible = false;
                        g_Em_Code.Visible = false;
                        g_Em_Name.Visible = false;
                        CalcCollectDay.Visible = false;
                        CollectCondName.Visible = false;
                        break;
                    }
            }
            //---ADD 2011/03/14----------------------------------------------->>>>>
            //空白行印字『印字しない』罫線印字『印字する』の場合
            if (_rsltInfo_CollectPlan.PrintBlLiDiv == 1 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 0)
            {
                this.line6.Visible = false;
                //-----DEL 2011/03/22----->>>>>
                //this.textBox_groupHeader2.Visible = false;
                //this.textBox_groupHeader1.Visible = false;
                //-----DEL 2011/03/22-----<<<<<
            }
            //空白行印字『印字しない』罫線印字『印字しない』の場合
            else if (_rsltInfo_CollectPlan.PrintBlLiDiv == 1 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 1)
            {
                //-----DEL 2011/03/22----->>>>>
                //this.textBox_groupHeader2.Visible = false;
                //this.textBox_groupHeader1.Visible = false;
                //-----DEL 2011/03/22-----<<<<<
                this.line2.Visible = false;
                this.line3.Visible = false;
                this.line4.Visible = false;
                this.line5.Visible = false;
                this.Line37.Visible = false;
                this.Line13.Visible = false;
                this.Line43.Visible = false;
                this.Line45.Visible = false;
   

            }
            //空白行『印字する』罫線印字『印字しない』の場合
            else if (_rsltInfo_CollectPlan.PrintBlLiDiv == 0 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 1)
            {
                this.line2.Visible = false;
                this.line3.Visible = false;
                this.line4.Visible = false;
                this.line5.Visible = false;
                this.Line37.Visible = false;
                this.Line13.Visible = false;
                this.Line43.Visible = false;
                this.Line45.Visible = false;
                //-----DEL 2011/03/22----->>>>>
                //if (this._rsltInfo_CollectPlan.SortOrderDiv == RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond)
                //{
                //    this.textBox_groupHeader1.Visible = false;
                //}
                //-----DEL 2011/03/22-----<<<<<
            }
            else
            {
                //空白行『印字する』罫線印字『印字する』の場合
                if (_rsltInfo_CollectPlan.PrintBlLiDiv == 0 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 0)
                {
                    this.line6.Visible = false;
                    //-----DEL 2011/03/22----->>>>>
                    //if (this._rsltInfo_CollectPlan.SortOrderDiv == RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond)
                    //{
                    //    this.textBox_groupHeader1.Visible = false;
                    //}
                    //-----DEL 2011/03/22-----<<<<<
                }
            }
            //---ADD 2011/03/14-----------------------------------------------<<<<<
            // 2008.11.14 30413 犬飼 出力順の制御 <<<<<<END
        }
		#endregion ◆ レポート要素出力設定

		#endregion
	
		#region ■ Control Event

        #region ◎ DCKAU02522P_01A4C_ReportStart Event
        /// <summary>
        /// DCKAU02522P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
        /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/14</br>
        /// <br>UpdateNote  : readmine20051の修正</br>
        /// <br>Programmer  : yangmj</br>
        /// <br>Date	    : 2011/03/22</br>
        /// </remarks>
        private void DCKAU02522P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
            //---ADD 2011/03/14----------------------------------------------->>>>>
            if ((_rsltInfo_CollectPlan.PrintBlLiDiv == 1 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 0) || (_rsltInfo_CollectPlan.PrintBlLiDiv == 1 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 1))
            {
                if (this._printCount == 0 && this._outputDv.Count > 1)
                {
                    switch (this._rsltInfo_CollectPlan.SortOrderDiv)
                    {
                        case RsltInfo_CollectPlan.SortOrderDivState.CustomerCode:   // 得意先順
                            {
                                if (this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_AddUpSecCode]))
                                {
                                    this.textBox_null_line.CanShrink = true;
                                }
                                else
                                {
                                    this.textBox_null_line.CanShrink = false;
                                }
                                break;
                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCode:   // 担当者順
                        case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCollect:    // 担当者別回収日順
                            {
                                if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                                {
                                    if (this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CustomerAgentCd].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_CustomerAgentCd])
                                        && this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_AddUpSecCode]))
                                    {
                                        this.textBox_null_line.CanShrink = true;
                                    }
                                    else
                                    {
                                        this.textBox_null_line.CanShrink = false;
                                    }
                                    break;
                                }
                                else
                                {
                                    if (this._outputDv[this._printCount + 1][DCKAU02524EA.Col_BillCollecterCd].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_BillCollecterCd])
                                        && this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_AddUpSecCode]))
                                    {
                                        this.textBox_null_line.CanShrink = true;
                                    }
                                    else
                                    {
                                        this.textBox_null_line.CanShrink = false;
                                    }
                                    break;
                                }

                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCode:  // 地区順
                        case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCollect:   // 地区別回収日順
                            {
                                if (this._outputDv[this._printCount + 1][DCKAU02524EA.Col_SalesAreaCodePrint].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_SalesAreaCodePrint])
                                    && this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_AddUpSecCode]))
                                {
                                    this.textBox_null_line.CanShrink = true;
                                }
                                else
                                {
                                    this.textBox_null_line.CanShrink = false;
                                }

                                break;
                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDay:    // 集金日順
                            {
                                //-----DEL 2011/03/22----->>>>>
                                //if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                                //{
                                //-----DEL 2011/03/22-----<<<<<
                                    if (this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CalcCollectDay].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_CalcCollectDay])
                                        && this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_AddUpSecCode]))
                                    {
                                        this.textBox_null_line.CanShrink = true;
                                    }
                                    else
                                    {
                                        this.textBox_null_line.CanShrink = false;
                                    }
                                //}//DEL 2011/03/22


                                break;
                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond:    // 集金日別回収条件順
                            {


                                if (this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CalcCollectDay].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_CalcCollectDay])
                                    && this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_AddUpSecCode])
                                    && this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CollectCond].Equals(this._outputDv[this._printCount][DCKAU02524EA.Col_CollectCond]))
                                {
                                    this.textBox_null_line.CanShrink = true;
                                }
                                else
                                {
                                    this.textBox_null_line.CanShrink = false;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    this.textBox_null_line.CanShrink = false;
                }
            }
            //---ADD 2011/03/14-----------------------------------------------<<<<<
        }
		#endregion

		#region ◎ PageHeader_Format Event
		/// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString(RsltInfo_CollectPlan.ct_DateFomat, DateTime.Now);
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
		}
		#endregion

		#region ◎ ExtraHeader_Format Event
		/// <summary>
		/// ExtraHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ExtraHeaderグループのフォーマットイベント。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 抽出条件設定
			// ヘッダ出力制御
			if (this._extraCondHeadOutDiv == 0)
			{
				// 毎ページ出力
				this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
			} 
			else 
			{
				// 先頭ページのみ
				this.ExtraHeader.RepeatStyle = RepeatStyle.None;
			}
			
			// インスタンスが作成されていなければ作成
			if ( this._rptExtraHeader == null)
			{
				this._rptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				// インスタンスが作成されていれば、データソースを初期化する
				// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
				this._rptExtraHeader.DataSource = null;
			}

            // 2008.11.14 30413 犬飼 抽出条件の印字エリアに拠点を印字しない >>>>>>START
            //// 拠点オプション有無判定
            //if ( this._rsltInfo_CollectPlan.IsOptSection )
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "計上拠点：" + this.tb_AddUpSecCode.Text + " " + this.tb_AddUpSecName.Text;
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // 2008.11.14 30413 犬飼 抽出条件の印字エリアに拠点を印字しない <<<<<<END
            
			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion

		#region ◎ Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションがページに描画される前に発生する。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
        /// <br>UpdateNote  : 空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/14</br>
        /// <br>UpdateNote  : readmine20051の修正</br>
        /// <br>Programmer  : yangmj</br>
        /// <br>Date	    : 2011/03/22</br>
        /// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            // --- DEL m.suzuki 2011/04/11 ---------->>>>>
            //PrintCommonLibrary.ConvertReportString(this.Detail);
            // --- DEL m.suzuki 2011/04/11 ----------<<<<<
            //---ADD 2011/03/14----------------------------------------------->>>>>
            if ((_rsltInfo_CollectPlan.PrintBlLiDiv == 1 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 0) || (_rsltInfo_CollectPlan.PrintBlLiDiv == 1 && _rsltInfo_CollectPlan.LineMaSqOfChDiv == 1))
            {
                if (this._printCount < this._outputDv.Count - 2)
                {
                    switch (this._rsltInfo_CollectPlan.SortOrderDiv)
                    {
                        case RsltInfo_CollectPlan.SortOrderDivState.CustomerCode:   // 得意先順
                            {
                                if (this._outputDv[this._printCount + 2][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode]))
                                {
                                    this.textBox_null_line.CanShrink = true;
                                }
                                else
                                {
                                    this.textBox_null_line.CanShrink = false;
                                }
                                break;
                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCode:   // 担当者順
                        case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCollect:    // 担当者別回収日順
                            {
                                if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                                {
                                    if (this._outputDv[this._printCount + 2][DCKAU02524EA.Col_CustomerAgentCd].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CustomerAgentCd])
                                        && this._outputDv[this._printCount + 2][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode]))
                                    {
                                        this.textBox_null_line.CanShrink = true;
                                    }
                                    else
                                    {
                                        this.textBox_null_line.CanShrink = false;
                                    }
                                    break;
                                }
                                else
                                {
                                    if (this._outputDv[this._printCount + 2][DCKAU02524EA.Col_BillCollecterCd].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_BillCollecterCd])
                                        && this._outputDv[this._printCount + 2][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode]))
                                    {
                                        this.textBox_null_line.CanShrink = true;
                                    }
                                    else
                                    {
                                        this.textBox_null_line.CanShrink = false;
                                    }
                                    break;
                                }

                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCode:  // 地区順
                        case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCollect:   // 地区別回収日順
                            {
                                if (this._outputDv[this._printCount + 2][DCKAU02524EA.Col_SalesAreaCodePrint].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_SalesAreaCodePrint])
                                    && this._outputDv[this._printCount + 2][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode]))
                                {
                                    this.textBox_null_line.CanShrink = true;
                                }
                                else
                                {
                                    this.textBox_null_line.CanShrink = false;
                                }

                                break;
                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDay:    // 集金日順
                            {
                                //-----DEL 2011/03/22----->>>>>
                                //if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                                //{
                                //-----DEL 2011/03/22-----<<<<<
                                    if (this._outputDv[this._printCount + 2][DCKAU02524EA.Col_CalcCollectDay].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CalcCollectDay])
                                        && this._outputDv[this._printCount + 2][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode]))
                                    {
                                        this.textBox_null_line.CanShrink = true;
                                    }
                                    else
                                    {
                                        this.textBox_null_line.CanShrink = false;
                                    }
                                //}//DEL 2011/03/22

                                break;
                            }
                        case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond:    // 集金日別回収条件順
                            {


                                if (this._outputDv[this._printCount + 2][DCKAU02524EA.Col_CalcCollectDay].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CalcCollectDay])
                                    && this._outputDv[this._printCount + 2][DCKAU02524EA.Col_AddUpSecCode].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_AddUpSecCode])
                                    && this._outputDv[this._printCount + 2][DCKAU02524EA.Col_CollectCond].Equals(this._outputDv[this._printCount + 1][DCKAU02524EA.Col_CollectCond]))
                                {
                                    this.textBox_null_line.CanShrink = true;
                                }
                                else
                                {
                                    this.textBox_null_line.CanShrink = false;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    this.textBox_null_line.CanShrink = false;
                }
            }
            //---ADD 2011/03/14-----------------------------------------------<<<<<
		}
		#endregion

		#region ◎ Detail_AfterPrint Event
		/// <summary>
		/// Detail_AfterPrint Event
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			this._printCount++;
			
			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this._printCount);
			}

		}
		#endregion

		#region ◎ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PageFooterグループのフォーマットイベント。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// インスタンスが作成されていなければ作成
				if ( _rptPageFooter == null)
				{
					_rptPageFooter = new ListCommon_PageFooter();
				}
				else
				{
					// インスタンスが作成されていれば、データソースを初期化する
					// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
					_rptPageFooter.DataSource = null;
				}
		
				// フッター印字項目設定
				if (this._pageFooters[0] != null)
				{
					_rptPageFooter.PrintFooter1 = this._pageFooters[0];
				}
				if (this._pageFooters[1] != null)
				{
					_rptPageFooter.PrintFooter2 = this._pageFooters[1];
				}
			
				this.Footer_SubReport.Report = _rptPageFooter;
			}
		}
		#endregion

        /// <summary>
        /// groupFooter2_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: groupFooter2グループのフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.20</br>
        /// </remarks>
        private void groupFooter2_Format(object sender, EventArgs e)
        {
            // 回収率
            double afterCloseDemand = double.Parse(this.f2_AfterCloseDemand.Value.ToString());
            double calcObjPric = double.Parse(this.f2_CalcObjPric.Value.ToString());
            if ((afterCloseDemand == 0) || (calcObjPric == 0))
            {
                f2_CollectRate.Value = 0;
            }
            else
            {
                // OutputFormatが"0.00%"の場合は、率計算が自動なので100倍しない
                //f2_CollectRate.Value = afterCloseDemand / calcObjPric * 100.0;
                f2_CollectRate.Value = afterCloseDemand / calcObjPric;
            }
        }

        /// <summary>
        /// groupFooter1_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: groupFooter1グループのフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.20</br>
        /// </remarks>
        private void groupFooter1_Format(object sender, EventArgs e)
        {
            // 回収率
            double afterCloseDemand = double.Parse(this.f1_AfterCloseDemand.Value.ToString());
            double calcObjPric = double.Parse(this.f1_CalcObjPric.Value.ToString());
            if ((afterCloseDemand == 0) || (calcObjPric == 0))
            {
                f1_CollectRate.Value = 0;
            }
            else
            {
                // OutputFormatが"0.00%"の場合は、率計算が自動なので100倍しない
                //f1_CollectRate.Value = afterCloseDemand / calcObjPric * 100.0;
                f1_CollectRate.Value = afterCloseDemand / calcObjPric;
            }
        }

        /// <summary>
        /// SectionFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: SectionFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.20</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {
            // 回収率
            double afterCloseDemand = double.Parse(this.Section_AfterCloseDemand.Value.ToString());
            double calcObjPric = double.Parse(this.Section_CalcObjPric.Value.ToString());
            if ((afterCloseDemand == 0) || (calcObjPric == 0))
            {
                Section_CollectRate.Value = 0;
            }
            else
            {
                // OutputFormatが"0.00%"の場合は、率計算が自動なので100倍しない
                //Section_CollectRate.Value = afterCloseDemand / calcObjPric * 100.0;
                Section_CollectRate.Value = afterCloseDemand / calcObjPric;
            }
        }

        /// <summary>
        /// GrandTotalFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: GrandTotalFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.20</br>
        /// </remarks>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            // 回収率
            double afterCloseDemand = double.Parse(this.Total_AfterCloseDemand.Value.ToString());
            double calcObjPric = double.Parse(this.Total_CalcObjPric.Value.ToString());
            if ((afterCloseDemand == 0) || (calcObjPric == 0))
            {
                Total_CollectRate.Value = 0;
            }
            else
            {
                // OutputFormatが"0.00%"の場合は、率計算が自動なので100倍しない
                //Total_CollectRate.Value = afterCloseDemand / calcObjPric * 100.0;
                Total_CollectRate.Value = afterCloseDemand / calcObjPric;
            }
        }

        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Detailのフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.20</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 回収率
            double afterCloseDemand = double.Parse(this.AfterCloseDemand.Value.ToString());
            double calcObjPric = double.Parse(this.CalcObjPric.Value.ToString());
            if ((afterCloseDemand == 0) || (calcObjPric == 0))
            {
                CollectRate.Value = 0;
            }
            else
            {
                // OutputFormatが"0.00%"の場合は、率計算が自動なので100倍しない
                //CollectRate.Value = afterCloseDemand / calcObjPric * 100.0;
                CollectRate.Value = afterCloseDemand / calcObjPric;
            }

            // サイト
            if (CollectSight.Value.ToString() == "0")
            {
                // ゼロは非印字
                CollectSight.Visible = false;
            }
            else
            {
                // ゼロ以外は印字
                CollectSight.Visible = true;
            }
        }

        /// <summary>
        /// groupHeader1_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		:groupHeader1のフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>UpdateNote  : 見出し行の印字仕様を変更する（PM7相違点)</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/30</br>
        /// </remarks>
        private void groupHeader1_Format(object sender, EventArgs e)
        {
            if (this._rsltInfo_CollectPlan.SortOrderDiv == RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond)
            {
                // 集金日別回収条件順の場合はskip
                return;
            }

            if (this._sectionCd == AddUpSecCode.Text.Trim())
            {
                // 同じ場合は拠点を非印字
                //---DEL 2011/03/30----------------------------------------------->>>>>
                //AddUpSecCode.Visible = false;
                //AddUpSecName.Visible = false;
                //---DEL 2011/03/30-----------------------------------------------<<<<<
                //---ADD 2011/03/30----------------------------------------------->>>>>
                AddUpSecCode.Visible = true;
                AddUpSecName.Visible = true;
                //---ADD 2011/03/30-----------------------------------------------<<<<<
            }
            else
            {
                // 違う場合は印字
                AddUpSecCode.Visible = true;
                AddUpSecName.Visible = true;
                this._sectionCd = AddUpSecCode.Text.Trim();
            }
        }

        /// <summary>
        /// groupHeader2_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		:groupHeader2のフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>UpdateNote  : 見出し行の印字仕様を変更する（PM7相違点)</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date	    : 2011/03/30</br>
        /// </remarks>
        private void groupHeader2_Format(object sender, EventArgs e)
        {
            if (this._sectionCd2 == AddUpSecCode.Text.Trim())
            {
                // 同じ場合は拠点を非印字
                //---DEL 2011/03/30----------------------------------------------->>>>>
                //g_AddUpSecCode.Visible = false;
                //g_AddUpSecName.Visible = false;
                //---DEL 2011/03/30-----------------------------------------------<<<<<
                //---ADD 2011/03/30----------------------------------------------->>>>>
                g_AddUpSecCode.Visible = true;
                g_AddUpSecName.Visible = true;
                //---ADD 2011/03/30-----------------------------------------------<<<<<
            }
            else
            {
                // 違う場合は印字
                g_AddUpSecCode.Visible = true;
                g_AddUpSecName.Visible = true;
                this._sectionCd2 = g_AddUpSecCode.Text.Trim();
            }

            if (this._calcCollectDay == g_CalcCollectDay.Text.Trim())
            {
                // 同じ場合は集金日を非印字
                //g_CalcCollectDay.Visible = false;// DEL 2011/03/30
                g_CalcCollectDay.Visible = true;// ADD 2011/03/30
            }
            else
            {
                // 違う場合は印字
                g_CalcCollectDay.Visible = true;
                this._calcCollectDay = g_CalcCollectDay.Text.Trim();
            }
        }

		#endregion ■ Control Event


		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.TextBox tb_SortOrderName;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Label Label86;
		private DataDynamics.ActiveReports.Label Label104;
		private DataDynamics.ActiveReports.Label Label105;
		private DataDynamics.ActiveReports.Label Label106;
		private DataDynamics.ActiveReports.Label Label107;
		private DataDynamics.ActiveReports.Label Label108;
		private DataDynamics.ActiveReports.TextBox tb_SectionTitle;
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label Label;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label AfterCloseDemand_Label;
		private DataDynamics.ActiveReports.Label Label6;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox LastTimeDemand;
		private DataDynamics.ActiveReports.Line Line13;
		private DataDynamics.ActiveReports.TextBox CalcThisTimeSales;
		private DataDynamics.ActiveReports.TextBox AcpOdrTtl3TmBfBlDmd;
		private DataDynamics.ActiveReports.TextBox AcpOdrTtl2TmBfBlDmd;
		private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.TextBox CalcCollectDay;
		private DataDynamics.ActiveReports.TextBox CollectCondName;
		private DataDynamics.ActiveReports.TextBox ClaimCode;
		private DataDynamics.ActiveReports.TextBox ClaimSnm;
		private DataDynamics.ActiveReports.TextBox g_Em_Code;
        private DataDynamics.ActiveReports.TextBox g_Em_Name;
		private DataDynamics.ActiveReports.TextBox ThisTimeDmdNrml;
		private DataDynamics.ActiveReports.TextBox TotalAdjust;
		private DataDynamics.ActiveReports.TextBox CalcObjPric;
		private DataDynamics.ActiveReports.TextBox TotalExpct;
		private DataDynamics.ActiveReports.TextBox CollectSight;
		private DataDynamics.ActiveReports.TextBox AfterCloseDemand;
        private DataDynamics.ActiveReports.TextBox CollectRate;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Section_AcpOdrTtl3;
		private DataDynamics.ActiveReports.TextBox Section_AcpOdrTtl2;
		private DataDynamics.ActiveReports.TextBox Section_LastTimeDemand;
		private DataDynamics.ActiveReports.TextBox Section_CalcThisTimeSales;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimeDmd;
		private DataDynamics.ActiveReports.TextBox Section_TotalAdjust;
		private DataDynamics.ActiveReports.TextBox Section_CalcObjPric;
		private DataDynamics.ActiveReports.TextBox Section_AfterCloseDemand;
		private DataDynamics.ActiveReports.TextBox Section_TotalExpct;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Total_AcpOdrTtl3;
		private DataDynamics.ActiveReports.TextBox Total_AcpOdrTtl2;
		private DataDynamics.ActiveReports.TextBox Total_LastTimeDemand;
		private DataDynamics.ActiveReports.TextBox Total_CalcThisTimeSales;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimeDmd;
		private DataDynamics.ActiveReports.TextBox Total_TotalAdjust;
		private DataDynamics.ActiveReports.TextBox Total_CalcObjPric;
		private DataDynamics.ActiveReports.TextBox Total_AfterCloseDemand;
		private DataDynamics.ActiveReports.TextBox Total_TotalExpct;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKAU02522P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.CalcThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.CalcCollectDay = new DataDynamics.ActiveReports.TextBox();
            this.CollectCondName = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.TotalAdjust = new DataDynamics.ActiveReports.TextBox();
            this.CalcObjPric = new DataDynamics.ActiveReports.TextBox();
            this.TotalExpct = new DataDynamics.ActiveReports.TextBox();
            this.CollectSight = new DataDynamics.ActiveReports.TextBox();
            this.AfterCloseDemand = new DataDynamics.ActiveReports.TextBox();
            this.CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.CollectMark = new DataDynamics.ActiveReports.TextBox();
            this.Em_Name = new DataDynamics.ActiveReports.TextBox();
            this.Em_Code = new DataDynamics.ActiveReports.TextBox();
            this.textBox_null_line = new DataDynamics.ActiveReports.TextBox();
            this.ClaimCode = new DataDynamics.ActiveReports.TextBox();
            this.ClaimSnm = new DataDynamics.ActiveReports.TextBox();
            this.g_Em_Code = new DataDynamics.ActiveReports.TextBox();
            this.g_Em_Name = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label86 = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.tb_SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.AfterCloseDemand_Label = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.SumTitle2 = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Total_AcpOdrTtl3 = new DataDynamics.ActiveReports.TextBox();
            this.Total_AcpOdrTtl2 = new DataDynamics.ActiveReports.TextBox();
            this.Total_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.Total_CalcThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Total_ThisTimeDmd = new DataDynamics.ActiveReports.TextBox();
            this.Total_TotalAdjust = new DataDynamics.ActiveReports.TextBox();
            this.Total_CalcObjPric = new DataDynamics.ActiveReports.TextBox();
            this.Total_AfterCloseDemand = new DataDynamics.ActiveReports.TextBox();
            this.Total_TotalExpct = new DataDynamics.ActiveReports.TextBox();
            this.Total_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Section_AcpOdrTtl3 = new DataDynamics.ActiveReports.TextBox();
            this.Section_AcpOdrTtl2 = new DataDynamics.ActiveReports.TextBox();
            this.Section_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.Section_CalcThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimeDmd = new DataDynamics.ActiveReports.TextBox();
            this.Section_TotalAdjust = new DataDynamics.ActiveReports.TextBox();
            this.Section_CalcObjPric = new DataDynamics.ActiveReports.TextBox();
            this.Section_AfterCloseDemand = new DataDynamics.ActiveReports.TextBox();
            this.Section_TotalExpct = new DataDynamics.ActiveReports.TextBox();
            this.Section_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox_sec = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.g1_CalcCollectDay = new DataDynamics.ActiveReports.TextBox();
            this.g_CalcCollectDay = new DataDynamics.ActiveReports.TextBox();
            this.g_CollectCondName = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.g1_TotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.f1_AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.f1_AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.f1_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.f1_CalcThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.f1_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.f1_TotalAdjust = new DataDynamics.ActiveReports.TextBox();
            this.f1_CalcObjPric = new DataDynamics.ActiveReports.TextBox();
            this.f1_AfterCloseDemand = new DataDynamics.ActiveReports.TextBox();
            this.f1_TotalExpct = new DataDynamics.ActiveReports.TextBox();
            this.f1_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.textBox_emp = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.g_AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.g_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.f2_AcpOdrTtl3TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.f2_AcpOdrTtl2TmBfBlDmd = new DataDynamics.ActiveReports.TextBox();
            this.f2_LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.f2_CalcThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.f2_ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.f2_TotalAdjust = new DataDynamics.ActiveReports.TextBox();
            this.f2_CalcObjPric = new DataDynamics.ActiveReports.TextBox();
            this.f2_AfterCloseDemand = new DataDynamics.ActiveReports.TextBox();
            this.f2_TotalExpct = new DataDynamics.ActiveReports.TextBox();
            this.f2_CollectRate = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox_cmd = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcCollectDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectCondName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcObjPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalExpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectSight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterCloseDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_null_line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Em_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Em_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterCloseDemand_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumTitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AcpOdrTtl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AcpOdrTtl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_CalcThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_TotalAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_CalcObjPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AfterCloseDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_TotalExpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AcpOdrTtl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AcpOdrTtl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_CalcThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_CalcObjPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AfterCloseDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalExpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_sec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1_CalcCollectDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CalcCollectDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectCondName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1_TotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CalcThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_TotalAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CalcObjPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_AfterCloseDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_TotalExpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_emp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_AcpOdrTtl3TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_AcpOdrTtl2TmBfBlDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CalcThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_TotalAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CalcObjPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_AfterCloseDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_TotalExpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CollectRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_cmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.LastTimeDemand,
            this.Line13,
            this.CalcThisTimeSales,
            this.AcpOdrTtl3TmBfBlDmd,
            this.AcpOdrTtl2TmBfBlDmd,
            this.Line37,
            this.CalcCollectDay,
            this.CollectCondName,
            this.ThisTimeDmdNrml,
            this.TotalAdjust,
            this.CalcObjPric,
            this.TotalExpct,
            this.CollectSight,
            this.AfterCloseDemand,
            this.CollectRate,
            this.CollectMark,
            this.Em_Name,
            this.Em_Code,
            this.textBox_null_line,
            this.ClaimCode,
            this.ClaimSnm});
            this.Detail.Height = 0.5104167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // LastTimeDemand
            // 
            this.LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.DataField = "LastTimeDemand";
            this.LastTimeDemand.Height = 0.125F;
            this.LastTimeDemand.Left = 4.572914F;
            this.LastTimeDemand.MultiLine = false;
            this.LastTimeDemand.Name = "LastTimeDemand";
            this.LastTimeDemand.OutputFormat = resources.GetString("LastTimeDemand.OutputFormat");
            this.LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.LastTimeDemand.Text = "1,234,567,890";
            this.LastTimeDemand.Top = 0F;
            this.LastTimeDemand.Width = 0.701F;
            // 
            // Line13
            // 
            this.Line13.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.RightColor = System.Drawing.Color.Black;
            this.Line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.TopColor = System.Drawing.Color.Black;
            this.Line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Height = 0F;
            this.Line13.Left = 0F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 10.875F;
            this.Line13.X1 = 0F;
            this.Line13.X2 = 10.875F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0F;
            // 
            // CalcThisTimeSales
            // 
            this.CalcThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.CalcThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.CalcThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.CalcThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.CalcThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcThisTimeSales.DataField = "CalcThisTimeSales";
            this.CalcThisTimeSales.Height = 0.125F;
            this.CalcThisTimeSales.Left = 5.260414F;
            this.CalcThisTimeSales.MultiLine = false;
            this.CalcThisTimeSales.Name = "CalcThisTimeSales";
            this.CalcThisTimeSales.OutputFormat = resources.GetString("CalcThisTimeSales.OutputFormat");
            this.CalcThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.CalcThisTimeSales.Text = "1,234,567,890";
            this.CalcThisTimeSales.Top = 0F;
            this.CalcThisTimeSales.Width = 0.701F;
            // 
            // AcpOdrTtl3TmBfBlDmd
            // 
            this.AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.AcpOdrTtl3TmBfBlDmd.Left = 3.192306F;
            this.AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.AcpOdrTtl3TmBfBlDmd.Name = "AcpOdrTtl3TmBfBlDmd";
            this.AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.AcpOdrTtl3TmBfBlDmd.Text = "1234,567,890";
            this.AcpOdrTtl3TmBfBlDmd.Top = 0F;
            this.AcpOdrTtl3TmBfBlDmd.Width = 0.7010257F;
            // 
            // AcpOdrTtl2TmBfBlDmd
            // 
            this.AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.AcpOdrTtl2TmBfBlDmd.Left = 3.885414F;
            this.AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.AcpOdrTtl2TmBfBlDmd.Name = "AcpOdrTtl2TmBfBlDmd";
            this.AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.AcpOdrTtl2TmBfBlDmd.Text = "1,234,567,890";
            this.AcpOdrTtl2TmBfBlDmd.Top = 0F;
            this.AcpOdrTtl2TmBfBlDmd.Width = 0.701F;
            // 
            // Line37
            // 
            this.Line37.Border.BottomColor = System.Drawing.Color.Black;
            this.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.LeftColor = System.Drawing.Color.Black;
            this.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.RightColor = System.Drawing.Color.Black;
            this.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.TopColor = System.Drawing.Color.Black;
            this.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Height = 0F;
            this.Line37.Left = 0F;
            this.Line37.LineWeight = 1F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 0F;
            this.Line37.Width = 10.8F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // CalcCollectDay
            // 
            this.CalcCollectDay.Border.BottomColor = System.Drawing.Color.Black;
            this.CalcCollectDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcCollectDay.Border.LeftColor = System.Drawing.Color.Black;
            this.CalcCollectDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcCollectDay.Border.RightColor = System.Drawing.Color.Black;
            this.CalcCollectDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcCollectDay.Border.TopColor = System.Drawing.Color.Black;
            this.CalcCollectDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcCollectDay.DataField = "CalcCollectDay";
            this.CalcCollectDay.Height = 0.125F;
            this.CalcCollectDay.Left = 2.536858F;
            this.CalcCollectDay.MultiLine = false;
            this.CalcCollectDay.Name = "CalcCollectDay";
            this.CalcCollectDay.OutputFormat = resources.GetString("CalcCollectDay.OutputFormat");
            this.CalcCollectDay.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.CalcCollectDay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.CalcCollectDay.Text = "99/99/99";
            this.CalcCollectDay.Top = 0F;
            this.CalcCollectDay.Width = 0.4809028F;
            // 
            // CollectCondName
            // 
            this.CollectCondName.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectCondName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectCondName.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectCondName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectCondName.Border.RightColor = System.Drawing.Color.Black;
            this.CollectCondName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectCondName.Border.TopColor = System.Drawing.Color.Black;
            this.CollectCondName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectCondName.DataField = "CollectCondName";
            this.CollectCondName.Height = 0.125F;
            this.CollectCondName.Left = 9.895838F;
            this.CollectCondName.MultiLine = false;
            this.CollectCondName.Name = "CollectCondName";
            this.CollectCondName.OutputFormat = resources.GetString("CollectCondName.OutputFormat");
            this.CollectCondName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.CollectCondName.Text = "ＮＮＮＮ";
            this.CollectCondName.Top = 0F;
            this.CollectCondName.Width = 0.5069444F;
            // 
            // ThisTimeDmdNrml
            // 
            this.ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.Height = 0.125F;
            this.ThisTimeDmdNrml.Left = 5.958333F;
            this.ThisTimeDmdNrml.MultiLine = false;
            this.ThisTimeDmdNrml.Name = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.OutputFormat = resources.GetString("ThisTimeDmdNrml.OutputFormat");
            this.ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.ThisTimeDmdNrml.Text = "1,234,567,890";
            this.ThisTimeDmdNrml.Top = 0F;
            this.ThisTimeDmdNrml.Width = 0.701F;
            // 
            // TotalAdjust
            // 
            this.TotalAdjust.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalAdjust.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalAdjust.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalAdjust.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalAdjust.Border.RightColor = System.Drawing.Color.Black;
            this.TotalAdjust.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalAdjust.Border.TopColor = System.Drawing.Color.Black;
            this.TotalAdjust.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalAdjust.DataField = "TotalAdjust";
            this.TotalAdjust.Height = 0.125F;
            this.TotalAdjust.Left = 6.666673F;
            this.TotalAdjust.MultiLine = false;
            this.TotalAdjust.Name = "TotalAdjust";
            this.TotalAdjust.OutputFormat = resources.GetString("TotalAdjust.OutputFormat");
            this.TotalAdjust.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.TotalAdjust.Text = "1,234,567,890";
            this.TotalAdjust.Top = 0F;
            this.TotalAdjust.Width = 0.701F;
            // 
            // CalcObjPric
            // 
            this.CalcObjPric.Border.BottomColor = System.Drawing.Color.Black;
            this.CalcObjPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcObjPric.Border.LeftColor = System.Drawing.Color.Black;
            this.CalcObjPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcObjPric.Border.RightColor = System.Drawing.Color.Black;
            this.CalcObjPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcObjPric.Border.TopColor = System.Drawing.Color.Black;
            this.CalcObjPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CalcObjPric.DataField = "CalcObjPric";
            this.CalcObjPric.Height = 0.125F;
            this.CalcObjPric.Left = 7.354171F;
            this.CalcObjPric.MultiLine = false;
            this.CalcObjPric.Name = "CalcObjPric";
            this.CalcObjPric.OutputFormat = resources.GetString("CalcObjPric.OutputFormat");
            this.CalcObjPric.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.CalcObjPric.Text = "1,234,567,890";
            this.CalcObjPric.Top = 0F;
            this.CalcObjPric.Width = 0.701F;
            // 
            // TotalExpct
            // 
            this.TotalExpct.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalExpct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalExpct.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalExpct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalExpct.Border.RightColor = System.Drawing.Color.Black;
            this.TotalExpct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalExpct.Border.TopColor = System.Drawing.Color.Black;
            this.TotalExpct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalExpct.DataField = "TotalExpct";
            this.TotalExpct.Height = 0.125F;
            this.TotalExpct.Left = 8.750006F;
            this.TotalExpct.MultiLine = false;
            this.TotalExpct.Name = "TotalExpct";
            this.TotalExpct.OutputFormat = resources.GetString("TotalExpct.OutputFormat");
            this.TotalExpct.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.TotalExpct.Text = "1,234,567,890";
            this.TotalExpct.Top = 0F;
            this.TotalExpct.Width = 0.701F;
            // 
            // CollectSight
            // 
            this.CollectSight.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectSight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectSight.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectSight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectSight.Border.RightColor = System.Drawing.Color.Black;
            this.CollectSight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectSight.Border.TopColor = System.Drawing.Color.Black;
            this.CollectSight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectSight.DataField = "CollectSight";
            this.CollectSight.Height = 0.125F;
            this.CollectSight.Left = 10.39931F;
            this.CollectSight.MultiLine = false;
            this.CollectSight.Name = "CollectSight";
            this.CollectSight.OutputFormat = resources.GetString("CollectSight.OutputFormat");
            this.CollectSight.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.CollectSight.Text = "123";
            this.CollectSight.Top = 0F;
            this.CollectSight.Width = 0.2048611F;
            // 
            // AfterCloseDemand
            // 
            this.AfterCloseDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.AfterCloseDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.AfterCloseDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand.Border.RightColor = System.Drawing.Color.Black;
            this.AfterCloseDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand.Border.TopColor = System.Drawing.Color.Black;
            this.AfterCloseDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand.DataField = "AfterCloseDemand";
            this.AfterCloseDemand.Height = 0.125F;
            this.AfterCloseDemand.Left = 8.041668F;
            this.AfterCloseDemand.MultiLine = false;
            this.AfterCloseDemand.Name = "AfterCloseDemand";
            this.AfterCloseDemand.OutputFormat = resources.GetString("AfterCloseDemand.OutputFormat");
            this.AfterCloseDemand.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.AfterCloseDemand.Text = "1,234,567,890";
            this.AfterCloseDemand.Top = 0F;
            this.AfterCloseDemand.Width = 0.701F;
            // 
            // CollectRate
            // 
            this.CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectRate.Height = 0.125F;
            this.CollectRate.Left = 9.427088F;
            this.CollectRate.MultiLine = false;
            this.CollectRate.Name = "CollectRate";
            this.CollectRate.OutputFormat = resources.GetString("CollectRate.OutputFormat");
            this.CollectRate.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.CollectRate.Text = "123.00%";
            this.CollectRate.Top = 0F;
            this.CollectRate.Width = 0.4375F;
            // 
            // CollectMark
            // 
            this.CollectMark.Border.BottomColor = System.Drawing.Color.Black;
            this.CollectMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMark.Border.LeftColor = System.Drawing.Color.Black;
            this.CollectMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMark.Border.RightColor = System.Drawing.Color.Black;
            this.CollectMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMark.Border.TopColor = System.Drawing.Color.Black;
            this.CollectMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CollectMark.DataField = "CollectMark";
            this.CollectMark.Height = 0.125F;
            this.CollectMark.Left = 10.60417F;
            this.CollectMark.MultiLine = false;
            this.CollectMark.Name = "CollectMark";
            this.CollectMark.OutputFormat = resources.GetString("CollectMark.OutputFormat");
            this.CollectMark.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.CollectMark.Text = "*";
            this.CollectMark.Top = 0F;
            this.CollectMark.Width = 0.125F;
            // 
            // Em_Name
            // 
            this.Em_Name.Border.BottomColor = System.Drawing.Color.Black;
            this.Em_Name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Border.LeftColor = System.Drawing.Color.Black;
            this.Em_Name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Border.RightColor = System.Drawing.Color.Black;
            this.Em_Name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.Border.TopColor = System.Drawing.Color.Black;
            this.Em_Name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Name.DataField = "CustomerAgentNm";
            this.Em_Name.Height = 0.125F;
            this.Em_Name.Left = 2.760416F;
            this.Em_Name.MultiLine = false;
            this.Em_Name.Name = "Em_Name";
            this.Em_Name.OutputFormat = resources.GetString("Em_Name.OutputFormat");
            this.Em_Name.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Em_Name.Text = "ＮＮＮＮＮ";
            this.Em_Name.Top = 0.125F;
            this.Em_Name.Width = 0.4553572F;
            // 
            // Em_Code
            // 
            this.Em_Code.Border.BottomColor = System.Drawing.Color.Black;
            this.Em_Code.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Border.LeftColor = System.Drawing.Color.Black;
            this.Em_Code.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Border.RightColor = System.Drawing.Color.Black;
            this.Em_Code.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.Border.TopColor = System.Drawing.Color.Black;
            this.Em_Code.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Em_Code.DataField = "CustomerAgentCd";
            this.Em_Code.Height = 0.125F;
            this.Em_Code.Left = 2.541665F;
            this.Em_Code.MultiLine = false;
            this.Em_Code.Name = "Em_Code";
            this.Em_Code.OutputFormat = resources.GetString("Em_Code.OutputFormat");
            this.Em_Code.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 7.5pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.Em_Code.Text = "1234";
            this.Em_Code.Top = 0.125F;
            this.Em_Code.Width = 0.25F;
            // 
            // textBox_null_line
            // 
            this.textBox_null_line.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_null_line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null_line.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_null_line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null_line.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_null_line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null_line.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_null_line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_null_line.Height = 0.125F;
            this.textBox_null_line.Left = 0.75F;
            this.textBox_null_line.MultiLine = false;
            this.textBox_null_line.Name = "textBox_null_line";
            this.textBox_null_line.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7.5pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.textBox_null_line.Text = null;
            this.textBox_null_line.Top = 0.125F;
            this.textBox_null_line.Width = 0.625F;
            // 
            // ClaimCode
            // 
            this.ClaimCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.DataField = "ClaimCode";
            this.ClaimCode.Height = 0.125F;
            this.ClaimCode.Left = 0F;
            this.ClaimCode.MultiLine = false;
            this.ClaimCode.Name = "ClaimCode";
            this.ClaimCode.OutputFormat = resources.GetString("ClaimCode.OutputFormat");
            this.ClaimCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.ClaimCode.Text = "12345678";
            this.ClaimCode.Top = 0F;
            this.ClaimCode.Width = 0.4722222F;
            // 
            // ClaimSnm
            // 
            this.ClaimSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.DataField = "ClaimSnm";
            this.ClaimSnm.Height = 0.125F;
            this.ClaimSnm.Left = 0.4374999F;
            this.ClaimSnm.MultiLine = false;
            this.ClaimSnm.Name = "ClaimSnm";
            this.ClaimSnm.OutputFormat = resources.GetString("ClaimSnm.OutputFormat");
            this.ClaimSnm.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ClaimSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.ClaimSnm.Top = 0F;
            this.ClaimSnm.Width = 2.116987F;
            // 
            // g_Em_Code
            // 
            this.g_Em_Code.Border.BottomColor = System.Drawing.Color.Black;
            this.g_Em_Code.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Code.Border.LeftColor = System.Drawing.Color.Black;
            this.g_Em_Code.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Code.Border.RightColor = System.Drawing.Color.Black;
            this.g_Em_Code.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Code.Border.TopColor = System.Drawing.Color.Black;
            this.g_Em_Code.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Code.Height = 0.125F;
            this.g_Em_Code.Left = 1.625F;
            this.g_Em_Code.MultiLine = false;
            this.g_Em_Code.Name = "g_Em_Code";
            this.g_Em_Code.OutputFormat = resources.GetString("g_Em_Code.OutputFormat");
            this.g_Em_Code.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 7.5pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_Em_Code.Text = "1234";
            this.g_Em_Code.Top = 0F;
            this.g_Em_Code.Width = 0.25F;
            // 
            // g_Em_Name
            // 
            this.g_Em_Name.Border.BottomColor = System.Drawing.Color.Black;
            this.g_Em_Name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Name.Border.LeftColor = System.Drawing.Color.Black;
            this.g_Em_Name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Name.Border.RightColor = System.Drawing.Color.Black;
            this.g_Em_Name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Name.Border.TopColor = System.Drawing.Color.Black;
            this.g_Em_Name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Em_Name.Height = 0.125F;
            this.g_Em_Name.Left = 1.885417F;
            this.g_Em_Name.MultiLine = false;
            this.g_Em_Name.Name = "g_Em_Name";
            this.g_Em_Name.OutputFormat = resources.GetString("g_Em_Name.OutputFormat");
            this.g_Em_Name.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.g_Em_Name.Text = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほ";
            this.g_Em_Name.Top = 0F;
            this.g_Em_Name.Width = 3.2F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_SortOrderName,
            this.tb_ReportTitle});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // tb_PrintDate
            // 
            this.tb_PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.CanShrink = true;
            this.tb_PrintDate.Height = 0.15625F;
            this.tb_PrintDate.Left = 8.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.9375F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // tb_PrintPage
            // 
            this.tb_PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.CanShrink = true;
            this.tb_PrintPage.Height = 0.15625F;
            this.tb_PrintPage.Left = 10.4375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.2085F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
            // 
            // tb_PrintTime
            // 
            this.tb_PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Height = 0.125F;
            this.tb_PrintTime.Left = 9.4375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // tb_SortOrderName
            // 
            this.tb_SortOrderName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.CanShrink = true;
            this.tb_SortOrderName.Height = 0.15625F;
            this.tb_SortOrderName.Left = 3.0625F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.0625F;
            this.tb_SortOrderName.Width = 2.0625F;
            // 
            // tb_ReportTitle
            // 
            this.tb_ReportTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "回収予定表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.Footer_SubReport.Height = 0.239F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.2083333F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.1875F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8125F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label86,
            this.Label104,
            this.Label105,
            this.Label106,
            this.Label107,
            this.Label108,
            this.tb_SectionTitle,
            this.Line42,
            this.Label,
            this.Label1,
            this.Label4,
            this.AfterCloseDemand_Label,
            this.Label6,
            this.Label7,
            this.Label8,
            this.Label9,
            this.SumTitle,
            this.SumTitle2,
            this.line6});
            this.TitleHeader.Height = 0.4375F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Label86
            // 
            this.Label86.Border.BottomColor = System.Drawing.Color.Black;
            this.Label86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.LeftColor = System.Drawing.Color.Black;
            this.Label86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.RightColor = System.Drawing.Color.Black;
            this.Label86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.TopColor = System.Drawing.Color.Black;
            this.Label86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Height = 0.125F;
            this.Label86.HyperLink = "";
            this.Label86.Left = 2.541665F;
            this.Label86.MultiLine = false;
            this.Label86.Name = "Label86";
            this.Label86.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Label86.Text = "集金日";
            this.Label86.Top = 0.125F;
            this.Label86.Width = 0.4375F;
            // 
            // Label104
            // 
            this.Label104.Border.BottomColor = System.Drawing.Color.Black;
            this.Label104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.LeftColor = System.Drawing.Color.Black;
            this.Label104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.RightColor = System.Drawing.Color.Black;
            this.Label104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.TopColor = System.Drawing.Color.Black;
            this.Label104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Height = 0.125F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Label104.Text = "得意先";
            this.Label104.Top = 0.125F;
            this.Label104.Width = 0.5625F;
            // 
            // Label105
            // 
            this.Label105.Border.BottomColor = System.Drawing.Color.Black;
            this.Label105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.LeftColor = System.Drawing.Color.Black;
            this.Label105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.RightColor = System.Drawing.Color.Black;
            this.Label105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.TopColor = System.Drawing.Color.Black;
            this.Label105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Height = 0.125F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 3.218747F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label105.Text = "前々々回残高";
            this.Label105.Top = 0.125F;
            this.Label105.Width = 0.6875F;
            // 
            // Label106
            // 
            this.Label106.Border.BottomColor = System.Drawing.Color.Black;
            this.Label106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.LeftColor = System.Drawing.Color.Black;
            this.Label106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.RightColor = System.Drawing.Color.Black;
            this.Label106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.TopColor = System.Drawing.Color.Black;
            this.Label106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Height = 0.125F;
            this.Label106.HyperLink = "";
            this.Label106.Left = 3.906248F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label106.Text = "前々回残高";
            this.Label106.Top = 0.125F;
            this.Label106.Width = 0.6875F;
            // 
            // Label107
            // 
            this.Label107.Border.BottomColor = System.Drawing.Color.Black;
            this.Label107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.LeftColor = System.Drawing.Color.Black;
            this.Label107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.RightColor = System.Drawing.Color.Black;
            this.Label107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.TopColor = System.Drawing.Color.Black;
            this.Label107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Height = 0.125F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 4.593747F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label107.Text = "前回残高";
            this.Label107.Top = 0.125F;
            this.Label107.Width = 0.6875F;
            // 
            // Label108
            // 
            this.Label108.Border.BottomColor = System.Drawing.Color.Black;
            this.Label108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.LeftColor = System.Drawing.Color.Black;
            this.Label108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.RightColor = System.Drawing.Color.Black;
            this.Label108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.TopColor = System.Drawing.Color.Black;
            this.Label108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Height = 0.125F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 5.281248F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label108.Text = "今回売上額";
            this.Label108.Top = 0.125F;
            this.Label108.Width = 0.6875F;
            // 
            // tb_SectionTitle
            // 
            this.tb_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionTitle.Height = 0.125F;
            this.tb_SectionTitle.Left = 0F;
            this.tb_SectionTitle.MultiLine = false;
            this.tb_SectionTitle.Name = "tb_SectionTitle";
            this.tb_SectionTitle.OutputFormat = resources.GetString("tb_SectionTitle.OutputFormat");
            this.tb_SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.tb_SectionTitle.Text = "拠点";
            this.tb_SectionTitle.Top = 0F;
            this.tb_SectionTitle.Width = 0.5625F;
            // 
            // Line42
            // 
            this.Line42.Border.BottomColor = System.Drawing.Color.Black;
            this.Line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.LeftColor = System.Drawing.Color.Black;
            this.Line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.RightColor = System.Drawing.Color.Black;
            this.Line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.TopColor = System.Drawing.Color.Black;
            this.Line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Height = 0F;
            this.Line42.Left = 0F;
            this.Line42.LineWeight = 2F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0F;
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.125F;
            this.Label.HyperLink = "";
            this.Label.Left = 5.979166F;
            this.Label.MultiLine = false;
            this.Label.Name = "Label";
            this.Label.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label.Text = "今回入金額";
            this.Label.Top = 0.125F;
            this.Label.Width = 0.6875F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.125F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 6.687506F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label1.Text = "残高合計";
            this.Label1.Top = 0.125F;
            this.Label1.Width = 0.6875F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.125F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 7.375005F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label4.Text = "対象額";
            this.Label4.Top = 0.125F;
            this.Label4.Width = 0.6875F;
            // 
            // AfterCloseDemand_Label
            // 
            this.AfterCloseDemand_Label.Border.BottomColor = System.Drawing.Color.Black;
            this.AfterCloseDemand_Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand_Label.Border.LeftColor = System.Drawing.Color.Black;
            this.AfterCloseDemand_Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand_Label.Border.RightColor = System.Drawing.Color.Black;
            this.AfterCloseDemand_Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand_Label.Border.TopColor = System.Drawing.Color.Black;
            this.AfterCloseDemand_Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfterCloseDemand_Label.Height = 0.125F;
            this.AfterCloseDemand_Label.HyperLink = "";
            this.AfterCloseDemand_Label.Left = 8.062502F;
            this.AfterCloseDemand_Label.MultiLine = false;
            this.AfterCloseDemand_Label.Name = "AfterCloseDemand_Label";
            this.AfterCloseDemand_Label.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.AfterCloseDemand_Label.Text = "締後入金額";
            this.AfterCloseDemand_Label.Top = 0.125F;
            this.AfterCloseDemand_Label.Width = 0.6875F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.125F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 8.77084F;
            this.Label6.MultiLine = false;
            this.Label6.Name = "Label6";
            this.Label6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label6.Text = "予定額";
            this.Label6.Top = 0.125F;
            this.Label6.Width = 0.6875F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.125F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 9.427088F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Label7.Text = "回収率";
            this.Label7.Top = 0.125F;
            this.Label7.Width = 0.4375F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.125F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 9.895838F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Label8.Text = "集金区分";
            this.Label8.Top = 0.125F;
            this.Label8.Width = 0.5F;
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
            this.Label9.Height = 0.125F;
            this.Label9.HyperLink = "";
            this.Label9.Left = 10.375F;
            this.Label9.MultiLine = false;
            this.Label9.Name = "Label9";
            this.Label9.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Label9.Text = "サイト";
            this.Label9.Top = 0.125F;
            this.Label9.Width = 0.375F;
            // 
            // SumTitle
            // 
            this.SumTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SumTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SumTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SumTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SumTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Height = 0.125F;
            this.SumTitle.Left = 1.625F;
            this.SumTitle.MultiLine = false;
            this.SumTitle.Name = "SumTitle";
            this.SumTitle.OutputFormat = resources.GetString("SumTitle.OutputFormat");
            this.SumTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SumTitle.Text = "担当者";
            this.SumTitle.Top = 0F;
            this.SumTitle.Width = 0.5F;
            // 
            // SumTitle2
            // 
            this.SumTitle2.Border.BottomColor = System.Drawing.Color.Black;
            this.SumTitle2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle2.Border.LeftColor = System.Drawing.Color.Black;
            this.SumTitle2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle2.Border.RightColor = System.Drawing.Color.Black;
            this.SumTitle2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle2.Border.TopColor = System.Drawing.Color.Black;
            this.SumTitle2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle2.Height = 0.125F;
            this.SumTitle2.HyperLink = "";
            this.SumTitle2.Left = 2.541665F;
            this.SumTitle2.MultiLine = false;
            this.SumTitle2.Name = "SumTitle2";
            this.SumTitle2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SumTitle2.Text = "集金区分";
            this.SumTitle2.Top = 0F;
            this.SumTitle2.Width = 0.5F;
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
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.25F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0.25F;
            this.line6.Y2 = 0.25F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // Line41
            // 
            this.Line41.Border.BottomColor = System.Drawing.Color.Black;
            this.Line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.LeftColor = System.Drawing.Color.Black;
            this.Line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.RightColor = System.Drawing.Color.Black;
            this.Line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.TopColor = System.Drawing.Color.Black;
            this.Line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Height = 0F;
            this.Line41.Left = 0F;
            this.Line41.LineWeight = 2F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 10.8F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 10.8F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ALLTOTALTITLE,
            this.Total_AcpOdrTtl3,
            this.Total_AcpOdrTtl2,
            this.Total_LastTimeDemand,
            this.Total_CalcThisTimeSales,
            this.Line43,
            this.Total_ThisTimeDmd,
            this.Total_TotalAdjust,
            this.Total_CalcObjPric,
            this.Total_AfterCloseDemand,
            this.Total_TotalExpct,
            this.Total_CollectRate});
            this.GrandTotalFooter.Height = 0.28125F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            // 
            // ALLTOTALTITLE
            // 
            this.ALLTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Height = 0.125F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 1.5F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0F;
            this.ALLTOTALTITLE.Width = 0.5F;
            // 
            // Total_AcpOdrTtl3
            // 
            this.Total_AcpOdrTtl3.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl3.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl3.Border.RightColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl3.Border.TopColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl3.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.Total_AcpOdrTtl3.Height = 0.125F;
            this.Total_AcpOdrTtl3.Left = 3.187498F;
            this.Total_AcpOdrTtl3.MultiLine = false;
            this.Total_AcpOdrTtl3.Name = "Total_AcpOdrTtl3";
            this.Total_AcpOdrTtl3.OutputFormat = resources.GetString("Total_AcpOdrTtl3.OutputFormat");
            this.Total_AcpOdrTtl3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_AcpOdrTtl3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_AcpOdrTtl3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_AcpOdrTtl3.Text = "1234,567,890";
            this.Total_AcpOdrTtl3.Top = 0F;
            this.Total_AcpOdrTtl3.Width = 0.71F;
            // 
            // Total_AcpOdrTtl2
            // 
            this.Total_AcpOdrTtl2.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl2.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl2.Border.RightColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl2.Border.TopColor = System.Drawing.Color.Black;
            this.Total_AcpOdrTtl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AcpOdrTtl2.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.Total_AcpOdrTtl2.Height = 0.125F;
            this.Total_AcpOdrTtl2.Left = 3.874997F;
            this.Total_AcpOdrTtl2.MultiLine = false;
            this.Total_AcpOdrTtl2.Name = "Total_AcpOdrTtl2";
            this.Total_AcpOdrTtl2.OutputFormat = resources.GetString("Total_AcpOdrTtl2.OutputFormat");
            this.Total_AcpOdrTtl2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_AcpOdrTtl2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_AcpOdrTtl2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_AcpOdrTtl2.Text = "1,234,567,890";
            this.Total_AcpOdrTtl2.Top = 0F;
            this.Total_AcpOdrTtl2.Width = 0.71F;
            // 
            // Total_LastTimeDemand
            // 
            this.Total_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.Total_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.Total_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeDemand.DataField = "LastTimeDemand";
            this.Total_LastTimeDemand.Height = 0.125F;
            this.Total_LastTimeDemand.Left = 4.562497F;
            this.Total_LastTimeDemand.MultiLine = false;
            this.Total_LastTimeDemand.Name = "Total_LastTimeDemand";
            this.Total_LastTimeDemand.OutputFormat = resources.GetString("Total_LastTimeDemand.OutputFormat");
            this.Total_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_LastTimeDemand.Text = "1,234,567,890";
            this.Total_LastTimeDemand.Top = 0F;
            this.Total_LastTimeDemand.Width = 0.71F;
            // 
            // Total_CalcThisTimeSales
            // 
            this.Total_CalcThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_CalcThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_CalcThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.Total_CalcThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.Total_CalcThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcThisTimeSales.DataField = "CalcThisTimeSales";
            this.Total_CalcThisTimeSales.Height = 0.125F;
            this.Total_CalcThisTimeSales.Left = 5.249997F;
            this.Total_CalcThisTimeSales.MultiLine = false;
            this.Total_CalcThisTimeSales.Name = "Total_CalcThisTimeSales";
            this.Total_CalcThisTimeSales.OutputFormat = resources.GetString("Total_CalcThisTimeSales.OutputFormat");
            this.Total_CalcThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_CalcThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_CalcThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_CalcThisTimeSales.Text = "1,234,567,890";
            this.Total_CalcThisTimeSales.Top = 0F;
            this.Total_CalcThisTimeSales.Width = 0.71F;
            // 
            // Line43
            // 
            this.Line43.Border.BottomColor = System.Drawing.Color.Black;
            this.Line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.LeftColor = System.Drawing.Color.Black;
            this.Line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.RightColor = System.Drawing.Color.Black;
            this.Line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.TopColor = System.Drawing.Color.Black;
            this.Line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Height = 0F;
            this.Line43.Left = 0F;
            this.Line43.LineWeight = 2F;
            this.Line43.Name = "Line43";
            this.Line43.Top = 0F;
            this.Line43.Width = 10.8F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.8F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // Total_ThisTimeDmd
            // 
            this.Total_ThisTimeDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmd.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmd.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimeDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeDmd.DataField = "ThisTimeDmdNrml";
            this.Total_ThisTimeDmd.Height = 0.125F;
            this.Total_ThisTimeDmd.Left = 5.947916F;
            this.Total_ThisTimeDmd.MultiLine = false;
            this.Total_ThisTimeDmd.Name = "Total_ThisTimeDmd";
            this.Total_ThisTimeDmd.OutputFormat = resources.GetString("Total_ThisTimeDmd.OutputFormat");
            this.Total_ThisTimeDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimeDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimeDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimeDmd.Text = "1,234,567,890";
            this.Total_ThisTimeDmd.Top = 0F;
            this.Total_ThisTimeDmd.Width = 0.71F;
            // 
            // Total_TotalAdjust
            // 
            this.Total_TotalAdjust.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_TotalAdjust.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalAdjust.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_TotalAdjust.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalAdjust.Border.RightColor = System.Drawing.Color.Black;
            this.Total_TotalAdjust.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalAdjust.Border.TopColor = System.Drawing.Color.Black;
            this.Total_TotalAdjust.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalAdjust.DataField = "TotalAdjust";
            this.Total_TotalAdjust.Height = 0.125F;
            this.Total_TotalAdjust.Left = 6.656256F;
            this.Total_TotalAdjust.MultiLine = false;
            this.Total_TotalAdjust.Name = "Total_TotalAdjust";
            this.Total_TotalAdjust.OutputFormat = resources.GetString("Total_TotalAdjust.OutputFormat");
            this.Total_TotalAdjust.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_TotalAdjust.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_TotalAdjust.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_TotalAdjust.Text = "1,234,567,890";
            this.Total_TotalAdjust.Top = 0F;
            this.Total_TotalAdjust.Width = 0.71F;
            // 
            // Total_CalcObjPric
            // 
            this.Total_CalcObjPric.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_CalcObjPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcObjPric.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_CalcObjPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcObjPric.Border.RightColor = System.Drawing.Color.Black;
            this.Total_CalcObjPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcObjPric.Border.TopColor = System.Drawing.Color.Black;
            this.Total_CalcObjPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CalcObjPric.DataField = "CalcObjPric";
            this.Total_CalcObjPric.Height = 0.125F;
            this.Total_CalcObjPric.Left = 7.343754F;
            this.Total_CalcObjPric.MultiLine = false;
            this.Total_CalcObjPric.Name = "Total_CalcObjPric";
            this.Total_CalcObjPric.OutputFormat = resources.GetString("Total_CalcObjPric.OutputFormat");
            this.Total_CalcObjPric.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_CalcObjPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_CalcObjPric.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_CalcObjPric.Text = "1,234,567,890";
            this.Total_CalcObjPric.Top = 0F;
            this.Total_CalcObjPric.Width = 0.71F;
            // 
            // Total_AfterCloseDemand
            // 
            this.Total_AfterCloseDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_AfterCloseDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfterCloseDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_AfterCloseDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfterCloseDemand.Border.RightColor = System.Drawing.Color.Black;
            this.Total_AfterCloseDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfterCloseDemand.Border.TopColor = System.Drawing.Color.Black;
            this.Total_AfterCloseDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_AfterCloseDemand.DataField = "AfterCloseDemand";
            this.Total_AfterCloseDemand.Height = 0.125F;
            this.Total_AfterCloseDemand.Left = 8.031251F;
            this.Total_AfterCloseDemand.MultiLine = false;
            this.Total_AfterCloseDemand.Name = "Total_AfterCloseDemand";
            this.Total_AfterCloseDemand.OutputFormat = resources.GetString("Total_AfterCloseDemand.OutputFormat");
            this.Total_AfterCloseDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_AfterCloseDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_AfterCloseDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_AfterCloseDemand.Text = "1,234,567,890";
            this.Total_AfterCloseDemand.Top = 0F;
            this.Total_AfterCloseDemand.Width = 0.71F;
            // 
            // Total_TotalExpct
            // 
            this.Total_TotalExpct.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_TotalExpct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalExpct.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_TotalExpct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalExpct.Border.RightColor = System.Drawing.Color.Black;
            this.Total_TotalExpct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalExpct.Border.TopColor = System.Drawing.Color.Black;
            this.Total_TotalExpct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_TotalExpct.DataField = "TotalExpct";
            this.Total_TotalExpct.Height = 0.125F;
            this.Total_TotalExpct.Left = 8.735F;
            this.Total_TotalExpct.MultiLine = false;
            this.Total_TotalExpct.Name = "Total_TotalExpct";
            this.Total_TotalExpct.OutputFormat = resources.GetString("Total_TotalExpct.OutputFormat");
            this.Total_TotalExpct.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_TotalExpct.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_TotalExpct.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_TotalExpct.Text = "1,234,567,890";
            this.Total_TotalExpct.Top = 0F;
            this.Total_TotalExpct.Width = 0.71F;
            // 
            // Total_CollectRate
            // 
            this.Total_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.Total_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.Total_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_CollectRate.Height = 0.125F;
            this.Total_CollectRate.Left = 9.427088F;
            this.Total_CollectRate.MultiLine = false;
            this.Total_CollectRate.Name = "Total_CollectRate";
            this.Total_CollectRate.OutputFormat = resources.GetString("Total_CollectRate.OutputFormat");
            this.Total_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_CollectRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_CollectRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_CollectRate.Text = "123.00%";
            this.Total_CollectRate.Top = 0F;
            this.Total_CollectRate.Width = 0.4375F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.Section_AcpOdrTtl3,
            this.Section_AcpOdrTtl2,
            this.Section_LastTimeDemand,
            this.Section_CalcThisTimeSales,
            this.Section_ThisTimeDmd,
            this.Section_TotalAdjust,
            this.Section_CalcObjPric,
            this.Section_AfterCloseDemand,
            this.Section_TotalExpct,
            this.Section_CollectRate,
            this.textBox_sec});
            this.SectionFooter.Height = 0.28125F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            // 
            // Line45
            // 
            this.Line45.Border.BottomColor = System.Drawing.Color.Black;
            this.Line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.LeftColor = System.Drawing.Color.Black;
            this.Line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.RightColor = System.Drawing.Color.Black;
            this.Line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.TopColor = System.Drawing.Color.Black;
            this.Line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Height = 0F;
            this.Line45.Left = 0F;
            this.Line45.LineWeight = 2F;
            this.Line45.Name = "Line45";
            this.Line45.Top = 0F;
            this.Line45.Width = 10.8F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // SECTOTALTITLE
            // 
            this.SECTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Height = 0.125F;
            this.SECTOTALTITLE.Left = 1.5F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "拠点計";
            this.SECTOTALTITLE.Top = 0F;
            this.SECTOTALTITLE.Width = 0.5F;
            // 
            // Section_AcpOdrTtl3
            // 
            this.Section_AcpOdrTtl3.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl3.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl3.Border.RightColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl3.Border.TopColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl3.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.Section_AcpOdrTtl3.Height = 0.125F;
            this.Section_AcpOdrTtl3.Left = 3.187083F;
            this.Section_AcpOdrTtl3.MultiLine = false;
            this.Section_AcpOdrTtl3.Name = "Section_AcpOdrTtl3";
            this.Section_AcpOdrTtl3.OutputFormat = resources.GetString("Section_AcpOdrTtl3.OutputFormat");
            this.Section_AcpOdrTtl3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_AcpOdrTtl3.SummaryGroup = "SectionHeader";
            this.Section_AcpOdrTtl3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_AcpOdrTtl3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_AcpOdrTtl3.Text = "1234,567,890";
            this.Section_AcpOdrTtl3.Top = 0F;
            this.Section_AcpOdrTtl3.Width = 0.71F;
            // 
            // Section_AcpOdrTtl2
            // 
            this.Section_AcpOdrTtl2.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl2.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl2.Border.RightColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl2.Border.TopColor = System.Drawing.Color.Black;
            this.Section_AcpOdrTtl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AcpOdrTtl2.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.Section_AcpOdrTtl2.Height = 0.125F;
            this.Section_AcpOdrTtl2.Left = 3.874997F;
            this.Section_AcpOdrTtl2.MultiLine = false;
            this.Section_AcpOdrTtl2.Name = "Section_AcpOdrTtl2";
            this.Section_AcpOdrTtl2.OutputFormat = resources.GetString("Section_AcpOdrTtl2.OutputFormat");
            this.Section_AcpOdrTtl2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_AcpOdrTtl2.SummaryGroup = "SectionHeader";
            this.Section_AcpOdrTtl2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_AcpOdrTtl2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_AcpOdrTtl2.Text = "1,234,567,890";
            this.Section_AcpOdrTtl2.Top = 0F;
            this.Section_AcpOdrTtl2.Width = 0.71F;
            // 
            // Section_LastTimeDemand
            // 
            this.Section_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.Section_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.Section_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeDemand.DataField = "LastTimeDemand";
            this.Section_LastTimeDemand.Height = 0.125F;
            this.Section_LastTimeDemand.Left = 4.562497F;
            this.Section_LastTimeDemand.MultiLine = false;
            this.Section_LastTimeDemand.Name = "Section_LastTimeDemand";
            this.Section_LastTimeDemand.OutputFormat = resources.GetString("Section_LastTimeDemand.OutputFormat");
            this.Section_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_LastTimeDemand.SummaryGroup = "SectionHeader";
            this.Section_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_LastTimeDemand.Text = "1,234,567,890";
            this.Section_LastTimeDemand.Top = 0F;
            this.Section_LastTimeDemand.Width = 0.71F;
            // 
            // Section_CalcThisTimeSales
            // 
            this.Section_CalcThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_CalcThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_CalcThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.Section_CalcThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.Section_CalcThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcThisTimeSales.DataField = "CalcThisTimeSales";
            this.Section_CalcThisTimeSales.Height = 0.125F;
            this.Section_CalcThisTimeSales.Left = 5.249997F;
            this.Section_CalcThisTimeSales.MultiLine = false;
            this.Section_CalcThisTimeSales.Name = "Section_CalcThisTimeSales";
            this.Section_CalcThisTimeSales.OutputFormat = resources.GetString("Section_CalcThisTimeSales.OutputFormat");
            this.Section_CalcThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_CalcThisTimeSales.SummaryGroup = "SectionHeader";
            this.Section_CalcThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_CalcThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_CalcThisTimeSales.Text = "1,234,567,890";
            this.Section_CalcThisTimeSales.Top = 0F;
            this.Section_CalcThisTimeSales.Width = 0.71F;
            // 
            // Section_ThisTimeDmd
            // 
            this.Section_ThisTimeDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmd.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmd.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimeDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeDmd.DataField = "ThisTimeDmdNrml";
            this.Section_ThisTimeDmd.Height = 0.125F;
            this.Section_ThisTimeDmd.Left = 5.947916F;
            this.Section_ThisTimeDmd.MultiLine = false;
            this.Section_ThisTimeDmd.Name = "Section_ThisTimeDmd";
            this.Section_ThisTimeDmd.OutputFormat = resources.GetString("Section_ThisTimeDmd.OutputFormat");
            this.Section_ThisTimeDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimeDmd.SummaryGroup = "SectionHeader";
            this.Section_ThisTimeDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimeDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimeDmd.Text = "1,234,567,890";
            this.Section_ThisTimeDmd.Top = 0F;
            this.Section_ThisTimeDmd.Width = 0.71F;
            // 
            // Section_TotalAdjust
            // 
            this.Section_TotalAdjust.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_TotalAdjust.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalAdjust.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_TotalAdjust.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalAdjust.Border.RightColor = System.Drawing.Color.Black;
            this.Section_TotalAdjust.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalAdjust.Border.TopColor = System.Drawing.Color.Black;
            this.Section_TotalAdjust.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalAdjust.DataField = "TotalAdjust";
            this.Section_TotalAdjust.Height = 0.125F;
            this.Section_TotalAdjust.Left = 6.656256F;
            this.Section_TotalAdjust.MultiLine = false;
            this.Section_TotalAdjust.Name = "Section_TotalAdjust";
            this.Section_TotalAdjust.OutputFormat = resources.GetString("Section_TotalAdjust.OutputFormat");
            this.Section_TotalAdjust.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_TotalAdjust.SummaryGroup = "SectionHeader";
            this.Section_TotalAdjust.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_TotalAdjust.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_TotalAdjust.Text = "1,234,567,890";
            this.Section_TotalAdjust.Top = 0F;
            this.Section_TotalAdjust.Width = 0.71F;
            // 
            // Section_CalcObjPric
            // 
            this.Section_CalcObjPric.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_CalcObjPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcObjPric.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_CalcObjPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcObjPric.Border.RightColor = System.Drawing.Color.Black;
            this.Section_CalcObjPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcObjPric.Border.TopColor = System.Drawing.Color.Black;
            this.Section_CalcObjPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CalcObjPric.DataField = "CalcObjPric";
            this.Section_CalcObjPric.Height = 0.125F;
            this.Section_CalcObjPric.Left = 7.343754F;
            this.Section_CalcObjPric.MultiLine = false;
            this.Section_CalcObjPric.Name = "Section_CalcObjPric";
            this.Section_CalcObjPric.OutputFormat = resources.GetString("Section_CalcObjPric.OutputFormat");
            this.Section_CalcObjPric.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_CalcObjPric.SummaryGroup = "SectionHeader";
            this.Section_CalcObjPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_CalcObjPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_CalcObjPric.Text = "1,234,567,890";
            this.Section_CalcObjPric.Top = 0F;
            this.Section_CalcObjPric.Width = 0.71F;
            // 
            // Section_AfterCloseDemand
            // 
            this.Section_AfterCloseDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_AfterCloseDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfterCloseDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_AfterCloseDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfterCloseDemand.Border.RightColor = System.Drawing.Color.Black;
            this.Section_AfterCloseDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfterCloseDemand.Border.TopColor = System.Drawing.Color.Black;
            this.Section_AfterCloseDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_AfterCloseDemand.DataField = "AfterCloseDemand";
            this.Section_AfterCloseDemand.Height = 0.125F;
            this.Section_AfterCloseDemand.Left = 8.031251F;
            this.Section_AfterCloseDemand.MultiLine = false;
            this.Section_AfterCloseDemand.Name = "Section_AfterCloseDemand";
            this.Section_AfterCloseDemand.OutputFormat = resources.GetString("Section_AfterCloseDemand.OutputFormat");
            this.Section_AfterCloseDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_AfterCloseDemand.SummaryGroup = "SectionHeader";
            this.Section_AfterCloseDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_AfterCloseDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_AfterCloseDemand.Text = "1,234,567,890";
            this.Section_AfterCloseDemand.Top = 0F;
            this.Section_AfterCloseDemand.Width = 0.71F;
            // 
            // Section_TotalExpct
            // 
            this.Section_TotalExpct.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_TotalExpct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalExpct.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_TotalExpct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalExpct.Border.RightColor = System.Drawing.Color.Black;
            this.Section_TotalExpct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalExpct.Border.TopColor = System.Drawing.Color.Black;
            this.Section_TotalExpct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalExpct.DataField = "TotalExpct";
            this.Section_TotalExpct.Height = 0.125F;
            this.Section_TotalExpct.Left = 8.735F;
            this.Section_TotalExpct.MultiLine = false;
            this.Section_TotalExpct.Name = "Section_TotalExpct";
            this.Section_TotalExpct.OutputFormat = resources.GetString("Section_TotalExpct.OutputFormat");
            this.Section_TotalExpct.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_TotalExpct.SummaryGroup = "SectionHeader";
            this.Section_TotalExpct.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_TotalExpct.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_TotalExpct.Text = "1,234,567,890";
            this.Section_TotalExpct.Top = 0F;
            this.Section_TotalExpct.Width = 0.71F;
            // 
            // Section_CollectRate
            // 
            this.Section_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.Section_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.Section_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_CollectRate.Height = 0.125F;
            this.Section_CollectRate.Left = 9.427088F;
            this.Section_CollectRate.MultiLine = false;
            this.Section_CollectRate.Name = "Section_CollectRate";
            this.Section_CollectRate.OutputFormat = resources.GetString("Section_CollectRate.OutputFormat");
            this.Section_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_CollectRate.SummaryGroup = "SectionHeader";
            this.Section_CollectRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_CollectRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_CollectRate.Text = "123.00%";
            this.Section_CollectRate.Top = 0F;
            this.Section_CollectRate.Width = 0.4375F;
            // 
            // textBox_sec
            // 
            this.textBox_sec.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_sec.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_sec.Height = 0.125F;
            this.textBox_sec.Left = 3.177082F;
            this.textBox_sec.MultiLine = false;
            this.textBox_sec.Name = "textBox_sec";
            this.textBox_sec.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7.5pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.textBox_sec.Text = null;
            this.textBox_sec.Top = 0.125F;
            this.textBox_sec.Width = 0.625F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.CanShrink = true;
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.g_Em_Code,
            this.g_Em_Name,
            this.AddUpSecCode,
            this.AddUpSecName,
            this.line5,
            this.g1_CalcCollectDay});
            this.groupHeader1.Height = 0.375F;
            this.groupHeader1.KeepTogether = true;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.groupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.DataField = "AddUpSecCode";
            this.AddUpSecCode.Height = 0.125F;
            this.AddUpSecCode.Left = 0F;
            this.AddUpSecCode.MultiLine = false;
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.OutputFormat = resources.GetString("AddUpSecCode.OutputFormat");
            this.AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.AddUpSecCode.Text = "00";
            this.AddUpSecCode.Top = 0F;
            this.AddUpSecCode.Width = 0.15F;
            // 
            // AddUpSecName
            // 
            this.AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.DataField = "AddUpSecName";
            this.AddUpSecName.Height = 0.125F;
            this.AddUpSecName.Left = 0.1354167F;
            this.AddUpSecName.MultiLine = false;
            this.AddUpSecName.Name = "AddUpSecName";
            this.AddUpSecName.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; vertical-align: top; ";
            this.AddUpSecName.Text = "拠点３４５６７８９０";
            this.AddUpSecName.Top = 0F;
            this.AddUpSecName.Width = 1.1F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // g1_CalcCollectDay
            // 
            this.g1_CalcCollectDay.Border.BottomColor = System.Drawing.Color.Black;
            this.g1_CalcCollectDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_CalcCollectDay.Border.LeftColor = System.Drawing.Color.Black;
            this.g1_CalcCollectDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_CalcCollectDay.Border.RightColor = System.Drawing.Color.Black;
            this.g1_CalcCollectDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_CalcCollectDay.Border.TopColor = System.Drawing.Color.Black;
            this.g1_CalcCollectDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_CalcCollectDay.DataField = "CalcCollectDay";
            this.g1_CalcCollectDay.Height = 0.125F;
            this.g1_CalcCollectDay.Left = 1.625F;
            this.g1_CalcCollectDay.MultiLine = false;
            this.g1_CalcCollectDay.Name = "g1_CalcCollectDay";
            this.g1_CalcCollectDay.OutputFormat = resources.GetString("g1_CalcCollectDay.OutputFormat");
            this.g1_CalcCollectDay.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.g1_CalcCollectDay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g1_CalcCollectDay.Text = "99/99/99";
            this.g1_CalcCollectDay.Top = 0.125F;
            this.g1_CalcCollectDay.Visible = false;
            this.g1_CalcCollectDay.Width = 0.45F;
            // 
            // g_CalcCollectDay
            // 
            this.g_CalcCollectDay.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CalcCollectDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcCollectDay.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CalcCollectDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcCollectDay.Border.RightColor = System.Drawing.Color.Black;
            this.g_CalcCollectDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcCollectDay.Border.TopColor = System.Drawing.Color.Black;
            this.g_CalcCollectDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CalcCollectDay.DataField = "CalcCollectDay";
            this.g_CalcCollectDay.Height = 0.125F;
            this.g_CalcCollectDay.Left = 1.625F;
            this.g_CalcCollectDay.MultiLine = false;
            this.g_CalcCollectDay.Name = "g_CalcCollectDay";
            this.g_CalcCollectDay.OutputFormat = resources.GetString("g_CalcCollectDay.OutputFormat");
            this.g_CalcCollectDay.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.g_CalcCollectDay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CalcCollectDay.Text = "99/99/99";
            this.g_CalcCollectDay.Top = 0F;
            this.g_CalcCollectDay.Width = 0.45F;
            // 
            // g_CollectCondName
            // 
            this.g_CollectCondName.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CollectCondName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectCondName.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CollectCondName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectCondName.Border.RightColor = System.Drawing.Color.Black;
            this.g_CollectCondName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectCondName.Border.TopColor = System.Drawing.Color.Black;
            this.g_CollectCondName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CollectCondName.DataField = "CollectCondName";
            this.g_CollectCondName.Height = 0.125F;
            this.g_CollectCondName.Left = 2.541665F;
            this.g_CollectCondName.MultiLine = false;
            this.g_CollectCondName.Name = "g_CollectCondName";
            this.g_CollectCondName.OutputFormat = resources.GetString("g_CollectCondName.OutputFormat");
            this.g_CollectCondName.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.g_CollectCondName.Text = "ＮＮＮＮ";
            this.g_CollectCondName.Top = 0F;
            this.g_CollectCondName.Width = 0.45F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.CanShrink = true;
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.g1_TotalTitle,
            this.f1_AcpOdrTtl3TmBfBlDmd,
            this.f1_AcpOdrTtl2TmBfBlDmd,
            this.f1_LastTimeDemand,
            this.f1_CalcThisTimeSales,
            this.f1_ThisTimeDmdNrml,
            this.f1_TotalAdjust,
            this.f1_CalcObjPric,
            this.f1_AfterCloseDemand,
            this.f1_TotalExpct,
            this.f1_CollectRate,
            this.line3,
            this.textBox_emp});
            this.groupFooter1.Height = 0.25F;
            this.groupFooter1.KeepTogether = true;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
            // 
            // g1_TotalTitle
            // 
            this.g1_TotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.g1_TotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_TotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.g1_TotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_TotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.g1_TotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_TotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.g1_TotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g1_TotalTitle.Height = 0.125F;
            this.g1_TotalTitle.Left = 1.5F;
            this.g1_TotalTitle.MultiLine = false;
            this.g1_TotalTitle.Name = "g1_TotalTitle";
            this.g1_TotalTitle.OutputFormat = resources.GetString("g1_TotalTitle.OutputFormat");
            this.g1_TotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.g1_TotalTitle.Text = "担当者計";
            this.g1_TotalTitle.Top = 0F;
            this.g1_TotalTitle.Width = 0.5F;
            // 
            // f1_AcpOdrTtl3TmBfBlDmd
            // 
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.f1_AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.f1_AcpOdrTtl3TmBfBlDmd.Left = 3.187083F;
            this.f1_AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.f1_AcpOdrTtl3TmBfBlDmd.Name = "f1_AcpOdrTtl3TmBfBlDmd";
            this.f1_AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("f1_AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.f1_AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_AcpOdrTtl3TmBfBlDmd.SummaryGroup = "groupHeader1";
            this.f1_AcpOdrTtl3TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_AcpOdrTtl3TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_AcpOdrTtl3TmBfBlDmd.Text = "1234,567,890";
            this.f1_AcpOdrTtl3TmBfBlDmd.Top = 0F;
            this.f1_AcpOdrTtl3TmBfBlDmd.Width = 0.71F;
            // 
            // f1_AcpOdrTtl2TmBfBlDmd
            // 
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.f1_AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.f1_AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.f1_AcpOdrTtl2TmBfBlDmd.Left = 3.874997F;
            this.f1_AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.f1_AcpOdrTtl2TmBfBlDmd.Name = "f1_AcpOdrTtl2TmBfBlDmd";
            this.f1_AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("f1_AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.f1_AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_AcpOdrTtl2TmBfBlDmd.SummaryGroup = "groupHeader1";
            this.f1_AcpOdrTtl2TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_AcpOdrTtl2TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_AcpOdrTtl2TmBfBlDmd.Text = "1,234,567,890";
            this.f1_AcpOdrTtl2TmBfBlDmd.Top = 0F;
            this.f1_AcpOdrTtl2TmBfBlDmd.Width = 0.71F;
            // 
            // f1_LastTimeDemand
            // 
            this.f1_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.f1_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.f1_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_LastTimeDemand.DataField = "LastTimeDemand";
            this.f1_LastTimeDemand.Height = 0.125F;
            this.f1_LastTimeDemand.Left = 4.562497F;
            this.f1_LastTimeDemand.MultiLine = false;
            this.f1_LastTimeDemand.Name = "f1_LastTimeDemand";
            this.f1_LastTimeDemand.OutputFormat = resources.GetString("f1_LastTimeDemand.OutputFormat");
            this.f1_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_LastTimeDemand.SummaryGroup = "groupHeader1";
            this.f1_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_LastTimeDemand.Text = "1,234,567,890";
            this.f1_LastTimeDemand.Top = 0F;
            this.f1_LastTimeDemand.Width = 0.71F;
            // 
            // f1_CalcThisTimeSales
            // 
            this.f1_CalcThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_CalcThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_CalcThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.f1_CalcThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.f1_CalcThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcThisTimeSales.DataField = "CalcThisTimeSales";
            this.f1_CalcThisTimeSales.Height = 0.125F;
            this.f1_CalcThisTimeSales.Left = 5.249997F;
            this.f1_CalcThisTimeSales.MultiLine = false;
            this.f1_CalcThisTimeSales.Name = "f1_CalcThisTimeSales";
            this.f1_CalcThisTimeSales.OutputFormat = resources.GetString("f1_CalcThisTimeSales.OutputFormat");
            this.f1_CalcThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_CalcThisTimeSales.SummaryGroup = "groupHeader1";
            this.f1_CalcThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_CalcThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_CalcThisTimeSales.Text = "1,234,567,890";
            this.f1_CalcThisTimeSales.Top = 0F;
            this.f1_CalcThisTimeSales.Width = 0.71F;
            // 
            // f1_ThisTimeDmdNrml
            // 
            this.f1_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.f1_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.f1_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.f1_ThisTimeDmdNrml.Height = 0.125F;
            this.f1_ThisTimeDmdNrml.Left = 5.947916F;
            this.f1_ThisTimeDmdNrml.MultiLine = false;
            this.f1_ThisTimeDmdNrml.Name = "f1_ThisTimeDmdNrml";
            this.f1_ThisTimeDmdNrml.OutputFormat = resources.GetString("f1_ThisTimeDmdNrml.OutputFormat");
            this.f1_ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_ThisTimeDmdNrml.SummaryGroup = "groupHeader1";
            this.f1_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_ThisTimeDmdNrml.Text = "1,234,567,890";
            this.f1_ThisTimeDmdNrml.Top = 0F;
            this.f1_ThisTimeDmdNrml.Width = 0.71F;
            // 
            // f1_TotalAdjust
            // 
            this.f1_TotalAdjust.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_TotalAdjust.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalAdjust.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_TotalAdjust.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalAdjust.Border.RightColor = System.Drawing.Color.Black;
            this.f1_TotalAdjust.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalAdjust.Border.TopColor = System.Drawing.Color.Black;
            this.f1_TotalAdjust.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalAdjust.DataField = "TotalAdjust";
            this.f1_TotalAdjust.Height = 0.125F;
            this.f1_TotalAdjust.Left = 6.656256F;
            this.f1_TotalAdjust.MultiLine = false;
            this.f1_TotalAdjust.Name = "f1_TotalAdjust";
            this.f1_TotalAdjust.OutputFormat = resources.GetString("f1_TotalAdjust.OutputFormat");
            this.f1_TotalAdjust.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_TotalAdjust.SummaryGroup = "groupHeader1";
            this.f1_TotalAdjust.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_TotalAdjust.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_TotalAdjust.Text = "1,234,567,890";
            this.f1_TotalAdjust.Top = 0F;
            this.f1_TotalAdjust.Width = 0.71F;
            // 
            // f1_CalcObjPric
            // 
            this.f1_CalcObjPric.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_CalcObjPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcObjPric.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_CalcObjPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcObjPric.Border.RightColor = System.Drawing.Color.Black;
            this.f1_CalcObjPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcObjPric.Border.TopColor = System.Drawing.Color.Black;
            this.f1_CalcObjPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CalcObjPric.DataField = "CalcObjPric";
            this.f1_CalcObjPric.Height = 0.125F;
            this.f1_CalcObjPric.Left = 7.343754F;
            this.f1_CalcObjPric.MultiLine = false;
            this.f1_CalcObjPric.Name = "f1_CalcObjPric";
            this.f1_CalcObjPric.OutputFormat = resources.GetString("f1_CalcObjPric.OutputFormat");
            this.f1_CalcObjPric.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_CalcObjPric.SummaryGroup = "groupHeader1";
            this.f1_CalcObjPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_CalcObjPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_CalcObjPric.Text = "1,234,567,890";
            this.f1_CalcObjPric.Top = 0F;
            this.f1_CalcObjPric.Width = 0.71F;
            // 
            // f1_AfterCloseDemand
            // 
            this.f1_AfterCloseDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_AfterCloseDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AfterCloseDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_AfterCloseDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AfterCloseDemand.Border.RightColor = System.Drawing.Color.Black;
            this.f1_AfterCloseDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AfterCloseDemand.Border.TopColor = System.Drawing.Color.Black;
            this.f1_AfterCloseDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_AfterCloseDemand.DataField = "AfterCloseDemand";
            this.f1_AfterCloseDemand.Height = 0.125F;
            this.f1_AfterCloseDemand.Left = 8.031251F;
            this.f1_AfterCloseDemand.MultiLine = false;
            this.f1_AfterCloseDemand.Name = "f1_AfterCloseDemand";
            this.f1_AfterCloseDemand.OutputFormat = resources.GetString("f1_AfterCloseDemand.OutputFormat");
            this.f1_AfterCloseDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_AfterCloseDemand.SummaryGroup = "groupHeader1";
            this.f1_AfterCloseDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_AfterCloseDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_AfterCloseDemand.Text = "1,234,567,890";
            this.f1_AfterCloseDemand.Top = 0F;
            this.f1_AfterCloseDemand.Width = 0.71F;
            // 
            // f1_TotalExpct
            // 
            this.f1_TotalExpct.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_TotalExpct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalExpct.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_TotalExpct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalExpct.Border.RightColor = System.Drawing.Color.Black;
            this.f1_TotalExpct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalExpct.Border.TopColor = System.Drawing.Color.Black;
            this.f1_TotalExpct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_TotalExpct.DataField = "TotalExpct";
            this.f1_TotalExpct.Height = 0.125F;
            this.f1_TotalExpct.Left = 8.735F;
            this.f1_TotalExpct.MultiLine = false;
            this.f1_TotalExpct.Name = "f1_TotalExpct";
            this.f1_TotalExpct.OutputFormat = resources.GetString("f1_TotalExpct.OutputFormat");
            this.f1_TotalExpct.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_TotalExpct.SummaryGroup = "groupHeader1";
            this.f1_TotalExpct.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_TotalExpct.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_TotalExpct.Text = "1,234,567,890";
            this.f1_TotalExpct.Top = 0F;
            this.f1_TotalExpct.Width = 0.71F;
            // 
            // f1_CollectRate
            // 
            this.f1_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.f1_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.f1_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.f1_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.f1_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f1_CollectRate.Height = 0.125F;
            this.f1_CollectRate.Left = 9.427088F;
            this.f1_CollectRate.MultiLine = false;
            this.f1_CollectRate.Name = "f1_CollectRate";
            this.f1_CollectRate.OutputFormat = resources.GetString("f1_CollectRate.OutputFormat");
            this.f1_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f1_CollectRate.SummaryGroup = "groupHeader1";
            this.f1_CollectRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f1_CollectRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f1_CollectRate.Text = "123.00%";
            this.f1_CollectRate.Top = 0F;
            this.f1_CollectRate.Width = 0.4375F;
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
            // textBox_emp
            // 
            this.textBox_emp.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_emp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_emp.Height = 0.125F;
            this.textBox_emp.Left = 3.177082F;
            this.textBox_emp.MultiLine = false;
            this.textBox_emp.Name = "textBox_emp";
            this.textBox_emp.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7.5pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.textBox_emp.Text = null;
            this.textBox_emp.Top = 0.125F;
            this.textBox_emp.Width = 0.625F;
            // 
            // groupHeader2
            // 
            this.groupHeader2.CanShrink = true;
            this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.g_CalcCollectDay,
            this.g_CollectCondName,
            this.g_AddUpSecName,
            this.g_AddUpSecCode,
            this.line4});
            this.groupHeader2.Height = 0.25F;
            this.groupHeader2.KeepTogether = true;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.groupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.groupHeader2.Format += new System.EventHandler(this.groupHeader2_Format);
            // 
            // g_AddUpSecName
            // 
            this.g_AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.g_AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.g_AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecName.DataField = "AddUpSecName";
            this.g_AddUpSecName.Height = 0.125F;
            this.g_AddUpSecName.Left = 0.1354167F;
            this.g_AddUpSecName.MultiLine = false;
            this.g_AddUpSecName.Name = "g_AddUpSecName";
            this.g_AddUpSecName.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; vertical-align: top; ";
            this.g_AddUpSecName.Text = "拠点３４５６７８９０";
            this.g_AddUpSecName.Top = 0F;
            this.g_AddUpSecName.Width = 1.1F;
            // 
            // g_AddUpSecCode
            // 
            this.g_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.g_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.g_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.g_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.g_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_AddUpSecCode.DataField = "AddUpSecCode";
            this.g_AddUpSecCode.Height = 0.125F;
            this.g_AddUpSecCode.Left = 0F;
            this.g_AddUpSecCode.MultiLine = false;
            this.g_AddUpSecCode.Name = "g_AddUpSecCode";
            this.g_AddUpSecCode.OutputFormat = resources.GetString("g_AddUpSecCode.OutputFormat");
            this.g_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7.5pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.g_AddUpSecCode.Text = "00";
            this.g_AddUpSecCode.Top = 0F;
            this.g_AddUpSecCode.Width = 0.15F;
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
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // groupFooter2
            // 
            this.groupFooter2.CanShrink = true;
            this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox17,
            this.f2_AcpOdrTtl3TmBfBlDmd,
            this.f2_AcpOdrTtl2TmBfBlDmd,
            this.f2_LastTimeDemand,
            this.f2_CalcThisTimeSales,
            this.f2_ThisTimeDmdNrml,
            this.f2_TotalAdjust,
            this.f2_CalcObjPric,
            this.f2_AfterCloseDemand,
            this.f2_TotalExpct,
            this.f2_CollectRate,
            this.line2,
            this.textBox_cmd});
            this.groupFooter2.Height = 0.25F;
            this.groupFooter2.KeepTogether = true;
            this.groupFooter2.Name = "groupFooter2";
            this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
            // 
            // textBox17
            // 
            this.textBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.RightColor = System.Drawing.Color.Black;
            this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.TopColor = System.Drawing.Color.Black;
            this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 1.5F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox17.Text = "集金区分計";
            this.textBox17.Top = 0F;
            this.textBox17.Width = 0.625F;
            // 
            // f2_AcpOdrTtl3TmBfBlDmd
            // 
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl3TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl3TmBfBlDmd.DataField = "AcpOdrTtl3TmBfBlDmd";
            this.f2_AcpOdrTtl3TmBfBlDmd.Height = 0.125F;
            this.f2_AcpOdrTtl3TmBfBlDmd.Left = 3.187083F;
            this.f2_AcpOdrTtl3TmBfBlDmd.MultiLine = false;
            this.f2_AcpOdrTtl3TmBfBlDmd.Name = "f2_AcpOdrTtl3TmBfBlDmd";
            this.f2_AcpOdrTtl3TmBfBlDmd.OutputFormat = resources.GetString("f2_AcpOdrTtl3TmBfBlDmd.OutputFormat");
            this.f2_AcpOdrTtl3TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_AcpOdrTtl3TmBfBlDmd.SummaryGroup = "groupHeader2";
            this.f2_AcpOdrTtl3TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_AcpOdrTtl3TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_AcpOdrTtl3TmBfBlDmd.Text = "1234,567,890";
            this.f2_AcpOdrTtl3TmBfBlDmd.Top = 0F;
            this.f2_AcpOdrTtl3TmBfBlDmd.Width = 0.71F;
            // 
            // f2_AcpOdrTtl2TmBfBlDmd
            // 
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.RightColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.TopColor = System.Drawing.Color.Black;
            this.f2_AcpOdrTtl2TmBfBlDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AcpOdrTtl2TmBfBlDmd.DataField = "AcpOdrTtl2TmBfBlDmd";
            this.f2_AcpOdrTtl2TmBfBlDmd.Height = 0.125F;
            this.f2_AcpOdrTtl2TmBfBlDmd.Left = 3.874997F;
            this.f2_AcpOdrTtl2TmBfBlDmd.MultiLine = false;
            this.f2_AcpOdrTtl2TmBfBlDmd.Name = "f2_AcpOdrTtl2TmBfBlDmd";
            this.f2_AcpOdrTtl2TmBfBlDmd.OutputFormat = resources.GetString("f2_AcpOdrTtl2TmBfBlDmd.OutputFormat");
            this.f2_AcpOdrTtl2TmBfBlDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_AcpOdrTtl2TmBfBlDmd.SummaryGroup = "groupHeader2";
            this.f2_AcpOdrTtl2TmBfBlDmd.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_AcpOdrTtl2TmBfBlDmd.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_AcpOdrTtl2TmBfBlDmd.Text = "1,234,567,890";
            this.f2_AcpOdrTtl2TmBfBlDmd.Top = 0F;
            this.f2_AcpOdrTtl2TmBfBlDmd.Width = 0.71F;
            // 
            // f2_LastTimeDemand
            // 
            this.f2_LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.f2_LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.f2_LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_LastTimeDemand.DataField = "LastTimeDemand";
            this.f2_LastTimeDemand.Height = 0.125F;
            this.f2_LastTimeDemand.Left = 4.562497F;
            this.f2_LastTimeDemand.MultiLine = false;
            this.f2_LastTimeDemand.Name = "f2_LastTimeDemand";
            this.f2_LastTimeDemand.OutputFormat = resources.GetString("f2_LastTimeDemand.OutputFormat");
            this.f2_LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_LastTimeDemand.SummaryGroup = "groupHeader2";
            this.f2_LastTimeDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_LastTimeDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_LastTimeDemand.Text = "1,234,567,890";
            this.f2_LastTimeDemand.Top = 0F;
            this.f2_LastTimeDemand.Width = 0.71F;
            // 
            // f2_CalcThisTimeSales
            // 
            this.f2_CalcThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_CalcThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_CalcThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.f2_CalcThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.f2_CalcThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcThisTimeSales.DataField = "CalcThisTimeSales";
            this.f2_CalcThisTimeSales.Height = 0.125F;
            this.f2_CalcThisTimeSales.Left = 5.249997F;
            this.f2_CalcThisTimeSales.MultiLine = false;
            this.f2_CalcThisTimeSales.Name = "f2_CalcThisTimeSales";
            this.f2_CalcThisTimeSales.OutputFormat = resources.GetString("f2_CalcThisTimeSales.OutputFormat");
            this.f2_CalcThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_CalcThisTimeSales.SummaryGroup = "groupHeader2";
            this.f2_CalcThisTimeSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_CalcThisTimeSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_CalcThisTimeSales.Text = "1,234,567,890";
            this.f2_CalcThisTimeSales.Top = 0F;
            this.f2_CalcThisTimeSales.Width = 0.71F;
            // 
            // f2_ThisTimeDmdNrml
            // 
            this.f2_ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.f2_ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.f2_ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.f2_ThisTimeDmdNrml.Height = 0.125F;
            this.f2_ThisTimeDmdNrml.Left = 5.947916F;
            this.f2_ThisTimeDmdNrml.MultiLine = false;
            this.f2_ThisTimeDmdNrml.Name = "f2_ThisTimeDmdNrml";
            this.f2_ThisTimeDmdNrml.OutputFormat = resources.GetString("f2_ThisTimeDmdNrml.OutputFormat");
            this.f2_ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_ThisTimeDmdNrml.SummaryGroup = "groupHeader2";
            this.f2_ThisTimeDmdNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_ThisTimeDmdNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_ThisTimeDmdNrml.Text = "1,234,567,890";
            this.f2_ThisTimeDmdNrml.Top = 0F;
            this.f2_ThisTimeDmdNrml.Width = 0.71F;
            // 
            // f2_TotalAdjust
            // 
            this.f2_TotalAdjust.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_TotalAdjust.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalAdjust.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_TotalAdjust.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalAdjust.Border.RightColor = System.Drawing.Color.Black;
            this.f2_TotalAdjust.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalAdjust.Border.TopColor = System.Drawing.Color.Black;
            this.f2_TotalAdjust.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalAdjust.DataField = "TotalAdjust";
            this.f2_TotalAdjust.Height = 0.125F;
            this.f2_TotalAdjust.Left = 6.656256F;
            this.f2_TotalAdjust.MultiLine = false;
            this.f2_TotalAdjust.Name = "f2_TotalAdjust";
            this.f2_TotalAdjust.OutputFormat = resources.GetString("f2_TotalAdjust.OutputFormat");
            this.f2_TotalAdjust.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_TotalAdjust.SummaryGroup = "groupHeader2";
            this.f2_TotalAdjust.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_TotalAdjust.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_TotalAdjust.Text = "1,234,567,890";
            this.f2_TotalAdjust.Top = 0F;
            this.f2_TotalAdjust.Width = 0.71F;
            // 
            // f2_CalcObjPric
            // 
            this.f2_CalcObjPric.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_CalcObjPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcObjPric.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_CalcObjPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcObjPric.Border.RightColor = System.Drawing.Color.Black;
            this.f2_CalcObjPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcObjPric.Border.TopColor = System.Drawing.Color.Black;
            this.f2_CalcObjPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CalcObjPric.DataField = "CalcObjPric";
            this.f2_CalcObjPric.Height = 0.125F;
            this.f2_CalcObjPric.Left = 7.343754F;
            this.f2_CalcObjPric.MultiLine = false;
            this.f2_CalcObjPric.Name = "f2_CalcObjPric";
            this.f2_CalcObjPric.OutputFormat = resources.GetString("f2_CalcObjPric.OutputFormat");
            this.f2_CalcObjPric.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_CalcObjPric.SummaryGroup = "groupHeader2";
            this.f2_CalcObjPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_CalcObjPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_CalcObjPric.Text = "1,234,567,890";
            this.f2_CalcObjPric.Top = 0F;
            this.f2_CalcObjPric.Width = 0.71F;
            // 
            // f2_AfterCloseDemand
            // 
            this.f2_AfterCloseDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_AfterCloseDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AfterCloseDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_AfterCloseDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AfterCloseDemand.Border.RightColor = System.Drawing.Color.Black;
            this.f2_AfterCloseDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AfterCloseDemand.Border.TopColor = System.Drawing.Color.Black;
            this.f2_AfterCloseDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_AfterCloseDemand.DataField = "AfterCloseDemand";
            this.f2_AfterCloseDemand.Height = 0.125F;
            this.f2_AfterCloseDemand.Left = 8.031251F;
            this.f2_AfterCloseDemand.MultiLine = false;
            this.f2_AfterCloseDemand.Name = "f2_AfterCloseDemand";
            this.f2_AfterCloseDemand.OutputFormat = resources.GetString("f2_AfterCloseDemand.OutputFormat");
            this.f2_AfterCloseDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_AfterCloseDemand.SummaryGroup = "groupHeader2";
            this.f2_AfterCloseDemand.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_AfterCloseDemand.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_AfterCloseDemand.Text = "1,234,567,890";
            this.f2_AfterCloseDemand.Top = 0F;
            this.f2_AfterCloseDemand.Width = 0.71F;
            // 
            // f2_TotalExpct
            // 
            this.f2_TotalExpct.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_TotalExpct.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalExpct.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_TotalExpct.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalExpct.Border.RightColor = System.Drawing.Color.Black;
            this.f2_TotalExpct.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalExpct.Border.TopColor = System.Drawing.Color.Black;
            this.f2_TotalExpct.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_TotalExpct.DataField = "TotalExpct";
            this.f2_TotalExpct.Height = 0.125F;
            this.f2_TotalExpct.Left = 8.735F;
            this.f2_TotalExpct.MultiLine = false;
            this.f2_TotalExpct.Name = "f2_TotalExpct";
            this.f2_TotalExpct.OutputFormat = resources.GetString("f2_TotalExpct.OutputFormat");
            this.f2_TotalExpct.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_TotalExpct.SummaryGroup = "groupHeader2";
            this.f2_TotalExpct.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_TotalExpct.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_TotalExpct.Text = "1,234,567,890";
            this.f2_TotalExpct.Top = 0F;
            this.f2_TotalExpct.Width = 0.71F;
            // 
            // f2_CollectRate
            // 
            this.f2_CollectRate.Border.BottomColor = System.Drawing.Color.Black;
            this.f2_CollectRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CollectRate.Border.LeftColor = System.Drawing.Color.Black;
            this.f2_CollectRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CollectRate.Border.RightColor = System.Drawing.Color.Black;
            this.f2_CollectRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CollectRate.Border.TopColor = System.Drawing.Color.Black;
            this.f2_CollectRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f2_CollectRate.Height = 0.125F;
            this.f2_CollectRate.Left = 9.427088F;
            this.f2_CollectRate.MultiLine = false;
            this.f2_CollectRate.Name = "f2_CollectRate";
            this.f2_CollectRate.OutputFormat = resources.GetString("f2_CollectRate.OutputFormat");
            this.f2_CollectRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.f2_CollectRate.SummaryGroup = "groupHeader2";
            this.f2_CollectRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.f2_CollectRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f2_CollectRate.Text = "123.00%";
            this.f2_CollectRate.Top = 0F;
            this.f2_CollectRate.Width = 0.4375F;
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
            // textBox_cmd
            // 
            this.textBox_cmd.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_cmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_cmd.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_cmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_cmd.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_cmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_cmd.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_cmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_cmd.Height = 0.125F;
            this.textBox_cmd.Left = 3.177082F;
            this.textBox_cmd.MultiLine = false;
            this.textBox_cmd.Name = "textBox_cmd";
            this.textBox_cmd.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7.5pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.textBox_cmd.Text = null;
            this.textBox_cmd.Top = 0.125F;
            this.textBox_cmd.Width = 0.625F;
            // 
            // DCKAU02522P_01A4C
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
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.DCKAU02522P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcCollectDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectCondName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcObjPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalExpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectSight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterCloseDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Em_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_null_line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Em_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Em_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterCloseDemand_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumTitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AcpOdrTtl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AcpOdrTtl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_CalcThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_TotalAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_CalcObjPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_AfterCloseDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_TotalExpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AcpOdrTtl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AcpOdrTtl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_CalcThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_CalcObjPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_AfterCloseDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalExpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_sec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1_CalcCollectDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CalcCollectDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CollectCondName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1_TotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CalcThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_TotalAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CalcObjPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_AfterCloseDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_TotalExpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_emp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_AcpOdrTtl3TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_AcpOdrTtl2TmBfBlDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CalcThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_TotalAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CalcObjPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_AfterCloseDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_TotalExpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2_CollectRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_cmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
