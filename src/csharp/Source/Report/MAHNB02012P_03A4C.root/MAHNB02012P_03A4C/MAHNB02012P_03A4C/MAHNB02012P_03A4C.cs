using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 入金一覧表(日計・伝票番号)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 入金一覧表(日計・伝票番号)のフォームクラスです。</br>
	/// <br>Programmer	: 22013　久保　将太</br>
	/// <br>Date		: 2007.03.10</br>
    /// <br>UpdateNote	: 2007.11.14 980035 金沢 貞義</br>
    ///					:   DC.NS対応（インセンティブの削除）
    /// <br>UpdateNote  : 2008.01.30 980035 金沢 貞義</br>
    /// <br>                DC.NS対応（不具合修正）</br>
    /// <br>UpdateNote  : 2008.07.09 30413 犬飼</br>
    /// <br>                PM.NS対応</br>
    /// <br>UpdateNote  : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>                [6363]適用のフォーマットを削除</br>
    /// <br>                [6362]得意先のフォーマットを追加</br>
    /// <br>UpdateNote  : 2009/01/07 30413 犬飼</br>
    /// <br>                障害ID:9653対応</br>
    /// <br>Update Note : 2009/03/26 30452 上野 俊治</br>
    /// <br>             ・障害対応11523,11661,11735</br>
    /// <br>Update Note : 2009/11/20 30517 夏野 駿希</br>
    /// <br>             ・1行印字対応</br>
    /// <br>Update Note : 2010/05/26 22018 鈴木 正臣</br>
    /// <br>             ・入金値引項目の削除によりindexの扱いが不正になっている為修正。</br>
    /// <br>Update Note : 2012/11/14 李亜博</br>
    ///	<br>			  2013/01/16配信分、Redmine#33271 印字制御の区分の追加</br> 
    /// <br>Update Note : 2012/12/14 董桂鈺</br>
    ///	<br>			  2013/01/16配信分、Redmine#33271 印字制御の区分の修正</br> 
    /// <br>UpdateNote  : 2013/01/05 zhuhh</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>            : redmine #33796 改頁制御を追加する</br>
    /// </remarks>
	public class MAHNB02012P_03A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 入金一覧表(日計・伝票番号)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入金一覧表(日計・伝票番号)フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		public MAHNB02012P_03A4C()
		{
			InitializeComponent();
//			this._strDateBuffer			= "";
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			 _otherDataList;				// その他データ

		private	DepositMainCndtn	 _depositMainCndtn;				// 抽出条件クラス

		// その他データ格納項目
        // 2008.07.23 30413 犬飼 未使用プロパティの削除 >>>>>>START
        //private string _sumTitle;						// 小計タイトル
        //private string				 _agentKindTitle;				// 担当者タイトル
        // 2008.07.23 30413 犬飼 未使用プロパティの削除 <<<<<<END
        
        private string _detailAddupSecNameTtl;		// 明細拠点名称タイトル

        // 2008.07.11 30413 犬飼 金種名称を取得 >>>>>>START
        private Dictionary<int, string> _dicKindName;
        // 2008.07.11 30413 犬飼 金種名称を取得 <<<<<<END

		private int					 _printCount;					// ページ数カウント用
//		private string				 _strDateBuffer;				// グループサプレス用バッファ
	
		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
		ListCommon_PageFooter _rptPageFooter	= null;
        private TextBox tb_AddUpSecCode;

        private Label Label86;
        private Label Label102;
        private Label Label104;
        private Label Label105;
        private Label DepositKind08_Title;
        private Label DepositKind10_Title;
        private Label label2;
        private Label DepositKind01_Title;
        private Label label3;
        private Label DepositKind02_Title;
        private Label DepositKind04_Title;
        private Label DepositKind03_Title;
        private Label DepositKind05_Title;
        private Label DepositKind09_Title;
        private Label DepositKind06_Title;
        private Label DepositKind07_Title;
        private TextBox Deposit;
        private TextBox DepositKind08;
        private TextBox AddUpADate;
        private TextBox DepositSlipNo;
        private TextBox CustomerCode;
        private TextBox CustomerName;
        private TextBox textBox1;
        private TextBox DepositKind01;
        private TextBox Outline;
        private TextBox DepositKind02;
        private TextBox DepositKind04;
        private TextBox DepositKind03;
        private TextBox DepositKind05;
        private TextBox DepositKind09;
        private TextBox DepositKind06;
        private TextBox DepositKind07;
        private TextBox Section_DepositKind01;
        private TextBox Section_Deposit;
        private TextBox Section_DepositKind02;
        private TextBox Section_DepositKind04;
        private TextBox Section_DepositKind03;
        private TextBox Section_DepositKind05;
        private TextBox Section_DepositKind09;
        private TextBox Section_DepositKind06;
        private TextBox MONEYKINDNAME13;
        private TextBox Section_DepositKind07;
        private TextBox Section_DepositKind08;
        private TextBox Total_DepositKind01;
        private TextBox Total_Deposit;
        private TextBox Total_DepositKind02;
        private TextBox Total_DepositKind04;
        private TextBox Total_DepositKind03;
        private TextBox Total_DepositKind05;
        private TextBox Total_DepositKind09;
        private TextBox Total_DepositKind06;
        private Label Label109;
        private TextBox Total_DepositKind07;
        private TextBox Total_DepositKind08;
        private Label label15;
        private Line TitleHeader_Line1;        
        private Line line2;        

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
		#endregion

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
				this._printInfo = value;
				this._depositMainCndtn = (DepositMainCndtn)this._printInfo.jyoken;
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
                        // 2008.07.23 30413 犬飼 その他データの取得を変更 >>>>>>START
                        //this._sumTitle = this._otherDataList[0].ToString();
                        //this._agentKindTitle		= this._otherDataList[1].ToString();
                        //this._detailAddupSecNameTtl = this._otherDataList[2].ToString();
                        this._detailAddupSecNameTtl = this._otherDataList[0].ToString();

                        this._dicKindName = (Dictionary<int, string>)this._otherDataList[3];        // 金種名称
                        // 2008.07.23 30413 犬飼 その他データの取得を変更 <<<<<<END
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
				// TODO:  MAHNB02012P_03A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAHNB02012P_03A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
        /// <br>Update Note: 2012/11/14 李亜博</br>
        ///	<br>			 Redmine#33271 印字制御の区分の追加</br>
        /// <br>UpdateNote  : 2013/01/05 zhuhh</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : redmine #33796 改頁制御を追加する</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			// 印字設定 --------------------------------------------------------------------------------------
            // --- DEL 2009/03/27 -------------------------------->>>>>
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._depositMainCndtn.IsOptSection )
            //{
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
            //    //if ((this._depositMainCndtn.DepositAddupSecCodeList.Length < 2) || 
            //    //	this._depositMainCndtn.IsSelectAllSection )
            //    if ((this._depositMainCndtn.DepositAddupSecCodeList.Length < 2) &&
            //        (this._depositMainCndtn.IsSelectAllSection == false))
            //    // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
            //    {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else
            //    {
            //        SectionHeader.DataField = MAHNB02014EA.ct_Col_AddUpSecCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }

            //    // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
            //    // 全社がチェックされていているときは、拠点名称（明細)は出力する
            //    //if (this._depositMainCndtn.IsSelectAllSection)
            //    //{
            //    //    tb_AddUpSecName_Detail.Visible = true;
            //    //}
            //    //else
            //    //{
            //    //    tb_AddUpSecName_Detail.Visible = false;
            //    //}
            //    // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
            //}
            //else
            //{
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //    // 2008.07.11 30413 犬飼 項目削除 >>>>>>START
            //    //tb_AddUpSecName_Title.Visible = false;
            //    //tb_AddUpSecName_Detail.Visible = false;
            //    // 2008.07.11 30413 犬飼 項目削除 <<<<<<END
            //}
            // --- DEL 2009/03/27 --------------------------------<<<<<

            // 2008.07.23 30413 犬飼 小計の出力を削除 >>>>>>START
            //// 小計の出力判断
            //// 簡易 - 伝票番号が選択されたときは小計を消す。
            //if ( this._depositMainCndtn.SumDiv == DepositMainCndtn.SumDivState.DepositSlipNo )
            //{
            //    DailyFooter.Visible = false;
            //}
            //else
            //{
            //    DailyFooter.Visible = true;
            //}

            //// 小計毎改ページ区分でヘッダのDataFieldを変更する
            //if ( this._depositMainCndtn.IsChangePageDiv )
            //{
            //    // 改ページする
            //    ChangeSumHeader.Visible = true;
            //    DailyHeader.Visible = false;
            //}
            //else
            //{
            //    // 改ページしない
            //    DailyHeader.Visible = true;
            //    ChangeSumHeader.Visible = false;
            //}

            //// 項目の名称をセット
            //tb_SumTitle.Text			= this._sumTitle;				// 小計タイトル
            // 2008.07.23 30413 犬飼 小計の出力を削除 >>>>>>START
                
			tb_ReportTitle.Text			= this._pageHeaderSubtitle;				// サブタイトル
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;		// ソート条件
            // 2008.07.11 30413 犬飼 項目削除 >>>>>>START
            //tb_EmployeeTitle.Text = this._agentKindTitle;					// 担当者タイトル
            //tb_AddUpSecName_Title.Text	= this._detailAddupSecNameTtl;			// 明細拠点名称タイトル
            // 2008.07.11 30413 犬飼 項目削除 <<<<<<END
            // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
            //罫線印字区分
            if (this._depositMainCndtn.LineMaSqOfChDiv == 0)
            {
                //罫線印字する
                this.Line37.Visible = true;
                this.Line13.Visible = true;
                this.Line43.Visible = true;
                this.Line45.Visible = true;
                // --- ADD 董桂鈺 2012/12/14 for Redmine#33271---------->>>>>
                this.TitleHeader_Line1.Visible = true;
                this.line2.Visible = false;
                // --- ADD 董桂鈺 2012/12/14 for Redmine#33271----------<<<<<
            }
            else
            {
                //罫線印字しない
                this.Line37.Visible = false;
                this.Line13.Visible = false;
                this.Line43.Visible = false;
                this.Line45.Visible = false;
                // --- ADD 董桂鈺 2012/12/14 for Redmine#33271---------->>>>>
                this.TitleHeader_Line1.Visible = false;
                this.line2.Visible = true;
                // --- ADD 董桂鈺 2012/12/14 for Redmine#33271----------<<<<<
            }
            // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

            // ----- ADD zhuhh 2013/01/05 for Redmine #33796 ----->>>>>
            if (this._depositMainCndtn.NewPageType == 0)
            {
                //拠点
                SectionHeader.NewPage = NewPage.Before;
                SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else 
            {
                //改頁しない
                SectionHeader.NewPage = NewPage.None;
                SectionHeader.RepeatStyle = RepeatStyle.None;
            }
            // ----- ADD zhuhh 2013/01/05 for Redmine #33796 -----<<<<<
        }
		#endregion

        #region ◆ 金種コードの印刷設定
        /// <summary>
        /// 金種コードの印刷設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : レポートの金種コードの印刷設定</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date		: 2008.07.11</br>
        /// </remarks>
        public void SettingKindName()
        {
            // --- ADD 2009/03/25 -------------------------------->>>>>
            string CT_FeeTitle = "手数料";
            string CT_FeeDataField = "FeeDeposit";
            // --- DEL m.suzuki 2010/05/26 ---------->>>>>
            //string CT_DiscountTitle = "値引";
            //string CT_DiscountDataField = "DiscountDeposit";
            // --- DEL m.suzuki 2010/05/26 ----------<<<<<

            string CT_DepositKind_No = "DepositKind_No";

            ArrayList depositKindCodeList = (ArrayList)this._otherDataList[1];

            // 作業用リスト作成
            #region 作業用リスト作成
            List<Label> titleList = new List<Label>();
            titleList.AddRange(new Label[] { 
                                                DepositKind01_Title,
                                                DepositKind02_Title,
                                                DepositKind03_Title,
                                                DepositKind04_Title,
                                                DepositKind05_Title,
                                                DepositKind06_Title,
                                                DepositKind07_Title,
                                                DepositKind08_Title,
                                                // --- UPD m.suzuki 2010/05/26 ---------->>>>>
                                                //DepositKind09_Title,
                                                //DepositKind10_Title
                                                DepositKind09_Title
                                                // --- UPD m.suzuki 2010/05/26 ----------<<<<<
                                            });

            List<TextBox> detailList = new List<TextBox>();
            detailList.AddRange(new TextBox[] { 
                                                DepositKind01,
                                                DepositKind02,
                                                DepositKind03,
                                                DepositKind04,
                                                DepositKind05,
                                                DepositKind06,
                                                DepositKind07,
                                                DepositKind08,
                                                // 2009/11/20 >>>
                                                // 値引はその他と合算の為削除
                                                //DepositKind09,
                                                //DepositKind10
                                                DepositKind09
                                                // 2009/11/20 <<<
                                             });

            List<TextBox> sectionList = new List<TextBox>();
            sectionList.AddRange(new TextBox[] {
                                                Section_DepositKind01,
                                                Section_DepositKind02,
                                                Section_DepositKind03,
                                                Section_DepositKind04,
                                                Section_DepositKind05,
                                                Section_DepositKind06,
                                                Section_DepositKind07,
                                                Section_DepositKind08,
                                                // 2009/11/20 >>>
                                                // 値引はその他と合算の為削除
                                                //Section_DepositKind09,
                                                //Section_DepositKind10
                                                Section_DepositKind09
                                                // 2009/11/20 <<<
                                             });

            List<TextBox> totalList = new List<TextBox>();
            totalList.AddRange(new TextBox[] {
                                                Total_DepositKind01,
                                                Total_DepositKind02,
                                                Total_DepositKind03,
                                                Total_DepositKind04,
                                                Total_DepositKind05,
                                                Total_DepositKind06,
                                                Total_DepositKind07,
                                                Total_DepositKind08,
                                                // 2009/11/20 >>>
                                                // 値引はその他と合算の為削除
                                                //Total_DepositKind09,
                                                //Total_DepositKind10
                                                Total_DepositKind09
                                                // 2009/11/20 <<<
                                             });
            #endregion

            int setColIndex = 0;

            // --- UPD m.suzuki 2010/05/26 ---------->>>>>
            //for (int index = 0; index <= 8; index++)
            for ( int index = 0; index < titleList.Count; index++ )
            // --- UPD m.suzuki 2010/05/26 ----------<<<<<
            {
                if ( index >= depositKindCodeList.Count )
                {
                    // 手数料、値引の設定
                    if ( index == depositKindCodeList.Count )
                    {
                        // 手数料
                        titleList[setColIndex].Text = CT_FeeTitle;
                        detailList[setColIndex].DataField = CT_FeeDataField;
                        sectionList[setColIndex].DataField = CT_FeeDataField;
                        totalList[setColIndex].DataField = CT_FeeDataField;
                        // 値引
                        // 2009/11/20 Del >>>
                        // 値引はその他と合算の為削除
                        //titleList[setColIndex + 1].Text = CT_DiscountTitle;
                        //detailList[setColIndex + 1].DataField = CT_DiscountDataField;
                        //sectionList[setColIndex + 1].DataField = CT_DiscountDataField;
                        //totalList[setColIndex + 1].DataField = CT_DiscountDataField;
                        // 2009/11/20 Del <<<
                    }
                }
                else
                {
                    if ((int)depositKindCodeList[index] != -1)
                    {
                        int dataFieldIndex = index + 1;

                        titleList[setColIndex].Text = this._dicKindName[index];
                        detailList[setColIndex].DataField = CT_DepositKind_No + dataFieldIndex.ToString();
                        sectionList[setColIndex].DataField = CT_DepositKind_No + dataFieldIndex.ToString();
                        totalList[setColIndex].DataField = CT_DepositKind_No + dataFieldIndex.ToString();

                        setColIndex++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            // --- UPD m.suzuki 2010/05/26 ---------->>>>>
            //for ( int i = 7; i > 0; i-- )
            //{
            //    if ( setColIndex <= i )
            //    {
            //        titleList[i + 2].Visible = false;
            //        detailList[i + 2].Visible = false;
            //        sectionList[i + 2].Visible = false;
            //        totalList[i + 2].Visible = false;
            //    }
            //}

            // 印字対象外項目を非表示に
            for ( int i = setColIndex + 1; i < titleList.Count; i++ )
            {
                titleList[i].Visible = false;
                detailList[i].Visible = false;
                sectionList[i].Visible = false;
                totalList[i].Visible = false;
            }
            // --- UPD m.suzuki 2010/05/26 ----------<<<<<


            // --- ADD 2009/03/25 --------------------------------<<<<<

            #region 削除
            // --- DEL 2009/03/25 -------------------------------->>>>>
            //for (int index = 0; index < 10; index++)
            //{
            //    if (index < this._dicKindName.Count)
            //    {
            //        switch (index)
            //        {
            //            case 0:
            //                {
            //                    this.DepositKind01_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 1:
            //                {
            //                    this.DepositKind02_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 2:
            //                {
            //                    this.DepositKind03_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 3:
            //                {
            //                    this.DepositKind04_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 4:
            //                {
            //                    this.DepositKind05_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 5:
            //                {
            //                    this.DepositKind06_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 6:
            //                {
            //                    this.DepositKind07_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 7:
            //                {
            //                    this.DepositKind08_Title.Text = this._dicKindName[index];
            //                    this.TitleHeader_Line1.Visible = false;
            //                    this.TitleHeader_Line2.Visible = true;
            //                    break;
            //                }
            //            case 8:
            //                {
            //                    this.DepositKind09_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 9:
            //                {
            //                    this.DepositKind10_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //        }
            //    }
            //    else
            //    {
            //        switch (index)
            //        {
            //            case 0:
            //                {
            //                    this.DepositKind01_Title.Visible = false;
            //                    this.DepositKind01.Visible = false;
            //                    this.Section_DepositKind01.Visible = false;
            //                    this.Total_DepositKind01.Visible = false;
            //                    break;
            //                }
            //            case 1:
            //                {
            //                    this.DepositKind02_Title.Visible = false;
            //                    this.DepositKind02.Visible = false;
            //                    this.Section_DepositKind02.Visible = false;
            //                    this.Total_DepositKind02.Visible = false;
            //                    break;
            //                }
            //            case 2:
            //                {
            //                    this.DepositKind03_Title.Visible = false;
            //                    this.DepositKind03.Visible = false;
            //                    this.Section_DepositKind03.Visible = false;
            //                    this.Total_DepositKind03.Visible = false;
            //                    break;
            //                }
            //            case 3:
            //                {
            //                    this.DepositKind04_Title.Visible = false;
            //                    this.DepositKind04.Visible = false;
            //                    this.Section_DepositKind04.Visible = false;
            //                    this.Total_DepositKind04.Visible = false;
            //                    this.TitleHeader_Line1.Visible = true;
            //                    this.TitleHeader_Line2.Visible = false;
            //                    break;
            //                }
            //            case 4:
            //                {
            //                    this.DepositKind05_Title.Visible = false;
            //                    this.DepositKind05.Visible = false;
            //                    this.Section_DepositKind05.Visible = false;
            //                    this.Total_DepositKind05.Visible = false;
            //                    break;
            //                }
            //            case 5:
            //                {
            //                    this.DepositKind06_Title.Visible = false;
            //                    this.DepositKind06.Visible = false;
            //                    this.Section_DepositKind06.Visible = false;
            //                    this.Total_DepositKind06.Visible = false;
            //                    break;
            //                }
            //            case 6:
            //                {
            //                    this.DepositKind07_Title.Visible = false;
            //                    this.DepositKind07.Visible = false;
            //                    this.Section_DepositKind07.Visible = false;
            //                    this.Total_DepositKind07.Visible = false;
            //                    break;
            //                }
            //            case 7:
            //                {
            //                    this.DepositKind08_Title.Visible = false;
            //                    this.DepositKind08.Visible = false;
            //                    this.Section_DepositKind08.Visible = false;
            //                    this.Total_DepositKind08.Visible = false;
            //                    this.TitleHeader_Line1.Visible = true;
            //                    this.TitleHeader_Line2.Visible = false;
            //                    break;
            //                }
            //            case 8:
            //                {
            //                    this.DepositKind09_Title.Visible = false;
            //                    this.DepositKind09.Visible = false;
            //                    this.Section_DepositKind09.Visible = false;
            //                    this.Total_DepositKind09.Visible = false;
            //                    break;
            //                }
            //            case 9:
            //                {
            //                    this.DepositKind10_Title.Visible = false;
            //                    this.DepositKind10.Visible = false;
            //                    this.Section_DepositKind10.Visible = false;
            //                    this.Total_DepositKind10.Visible = false;
            //                    break;
            //                }
            //        }
            //    }
            //}
            // --- DEL 2009/03/25 --------------------------------<<<<<
            #endregion
        }
        #endregion
        #endregion

        #region ■ Control Event
        #region ◆ MAHNB02012P_03A4C_ReportStart Event
        /// <summary>
		/// MAHNB02012P_03A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : レポートの設定をするイベントです。</br>
		/// <br>Programmer  : 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		private void MAHNB02012P_03A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();

            // 金種コードの印刷設定
            SettingKindName();
		}
		#endregion ◆ MAHNB02012P_03A4C_ReportStart Event

		#region ◆ PageHeader_Format Event
		/// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
		}
		#endregion ◆ PageHeader_Format Event

		#region ◆ ExtraHeader_Format Event
		/// <summary>
		/// ExtraHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ExtraHeaderグループの初期化イベントです。</br>
		/// <br>Programmer	: 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 抽出条件設定
            // --- DEL 2009/03/27 -------------------------------->>>>>
            //// ヘッダ出力制御
            //if (this._extraCondHeadOutDiv == 0)
            //{
            //    // 毎ページ出力
            //    this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //} 
            //else 
            //{
            //    // 先頭ページのみ
            //    this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            //}
            // --- DEL 2009/03/27 --------------------------------<<<<<
			
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

			// 拠点オプション有無判定
			// 2008.10.10 30413 犬飼 入金計上拠点から拠点に変更 >>>>>>START
            //if ( this._depositMainCndtn.IsOptSection )
            //{
            //    // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
            //    //this._rptExtraHeader.SectionCondition.Text = "入金計上拠点：" + this.tb_AddUpSecName.Text;
            //    this._rptExtraHeader.SectionCondition.Text = "入金計上拠点：" + this.tb_AddUpSecCode.Value + " " + this.tb_AddUpSecName.Text;
            //    // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            //this._rptExtraHeader.SectionCondition.Text = "拠点：" + this.tb_AddUpSecCode.Value + " " + this.tb_AddUpSecName.Text; // DEL 2009/03/27
            // 2008.10.10 30413 犬飼 入金計上拠点から拠点に変更 <<<<<<END
                
			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion ◆ ExtraHeader_Format Event

		#region ◆ Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

		}
		#endregion ◆ Detail_BeforePrint Event

		#region ◆ Detail_AfterPrint Event
		/// <summary>
		/// Detail_AfterPrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			this._printCount++;
			
# if DEBUG
# else
			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this._printCount);
			}
# endif
		}
		#endregion ◆ Detail_AfterPrint Event

		#region ◆ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : PageFooter_Formatグループの初期化イベントです。</br>
		/// <br>Programmer  : 22013 久保　将太</br>
		/// <br>Date		: 2007.03.10</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // インスタンスが作成されていなければ作成
                if (_rptPageFooter == null)
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
		#endregion ◆ PageFooter_Format Event

		#endregion ■ Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_SortOrderName;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.TextBox tb_AddUpSecName;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.Line Line13;
        private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MAHNB02012P_03A4C ) );
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Deposit = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind08 = new DataDynamics.ActiveReports.TextBox();
            this.AddUpADate = new DataDynamics.ActiveReports.TextBox();
            this.DepositSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Outline = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind02 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind04 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind03 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind05 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind09 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind06 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label86 = new DataDynamics.ActiveReports.Label();
            this.Label102 = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.DepositKind08_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind10_Title = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.DepositKind01_Title = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.DepositKind02_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind04_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind03_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind05_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind09_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind06_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind07_Title = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Total_DepositKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Total_Deposit = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind02 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind04 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind03 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind05 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind09 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind06 = new DataDynamics.ActiveReports.TextBox();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Total_DepositKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.tb_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.TitleHeader_Line1 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Section_DepositKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Section_Deposit = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind02 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind04 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind03 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind05 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind09 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind06 = new DataDynamics.ActiveReports.TextBox();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpADate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Outline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind10_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Line13,
            this.Deposit,
            this.DepositKind08,
            this.AddUpADate,
            this.DepositSlipNo,
            this.CustomerCode,
            this.CustomerName,
            this.textBox1,
            this.DepositKind01,
            this.Outline,
            this.DepositKind02,
            this.DepositKind04,
            this.DepositKind03,
            this.DepositKind05,
            this.DepositKind09,
            this.DepositKind06,
            this.DepositKind07,
            this.Line37} );
            this.Detail.Height = 0.25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler( this.Detail_AfterPrint );
            this.Detail.BeforePrint += new System.EventHandler( this.Detail_BeforePrint );
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
            // Deposit
            // 
            this.Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.DataField = "DepositTotal";
            this.Deposit.Height = 0.125F;
            this.Deposit.Left = 3F;
            this.Deposit.MultiLine = false;
            this.Deposit.Name = "Deposit";
            this.Deposit.OutputFormat = resources.GetString( "Deposit.OutputFormat" );
            this.Deposit.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Deposit.Text = "1,234,567,890";
            this.Deposit.Top = 0.0625F;
            this.Deposit.Width = 0.68F;
            // 
            // DepositKind08
            // 
            this.DepositKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Height = 0.125F;
            this.DepositKind08.Left = 8.4375F;
            this.DepositKind08.MultiLine = false;
            this.DepositKind08.Name = "DepositKind08";
            this.DepositKind08.OutputFormat = resources.GetString( "DepositKind08.OutputFormat" );
            this.DepositKind08.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind08.Text = "1,234,567,890";
            this.DepositKind08.Top = 0.0625F;
            this.DepositKind08.Width = 0.68F;
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
            this.AddUpADate.DataField = "AddUpADate";
            this.AddUpADate.Height = 0.125F;
            this.AddUpADate.Left = 0F;
            this.AddUpADate.MultiLine = false;
            this.AddUpADate.Name = "AddUpADate";
            this.AddUpADate.OutputFormat = resources.GetString( "AddUpADate.OutputFormat" );
            this.AddUpADate.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AddUpADate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.AddUpADate.Text = "09/07/01";
            this.AddUpADate.Top = 0.0625F;
            this.AddUpADate.Width = 0.4375F;
            // 
            // DepositSlipNo
            // 
            this.DepositSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.DepositSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.DepositSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNo.DataField = "DepositSlipNo";
            this.DepositSlipNo.Height = 0.125F;
            this.DepositSlipNo.Left = 0.4375F;
            this.DepositSlipNo.MultiLine = false;
            this.DepositSlipNo.Name = "DepositSlipNo";
            this.DepositSlipNo.OutputFormat = resources.GetString( "DepositSlipNo.OutputFormat" );
            this.DepositSlipNo.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DepositSlipNo.Text = "123456789";
            this.DepositSlipNo.Top = 0.0625F;
            this.DepositSlipNo.Width = 0.5F;
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
            this.CustomerCode.DataField = "ClaimCode";
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 1.0625F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString( "CustomerCode.OutputFormat" );
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CustomerCode.Text = "12345678";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.45F;
            // 
            // CustomerName
            // 
            this.CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.DataField = "ClaimSnm";
            this.CustomerName.Height = 0.125F;
            this.CustomerName.Left = 1.5F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OutputFormat = resources.GetString( "CustomerName.OutputFormat" );
            this.CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerName.Text = "あいうえおかきくけこさしすせそ";
            this.CustomerName.Top = 0.0625F;
            this.CustomerName.Width = 1F;
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
            this.textBox1.DataField = "ValidityTerm";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 2.525F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString( "textBox1.OutputFormat" );
            this.textBox1.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox1.Text = "09/12/31";
            this.textBox1.Top = 0.063F;
            this.textBox1.Width = 0.45F;
            // 
            // DepositKind01
            // 
            this.DepositKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Height = 0.125F;
            this.DepositKind01.Left = 3.68F;
            this.DepositKind01.MultiLine = false;
            this.DepositKind01.Name = "DepositKind01";
            this.DepositKind01.OutputFormat = resources.GetString( "DepositKind01.OutputFormat" );
            this.DepositKind01.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind01.Text = "1,234,567,890";
            this.DepositKind01.Top = 0.063F;
            this.DepositKind01.Width = 0.68F;
            // 
            // Outline
            // 
            this.Outline.Border.BottomColor = System.Drawing.Color.Black;
            this.Outline.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Outline.Border.LeftColor = System.Drawing.Color.Black;
            this.Outline.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Outline.Border.RightColor = System.Drawing.Color.Black;
            this.Outline.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Outline.Border.TopColor = System.Drawing.Color.Black;
            this.Outline.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Outline.DataField = "Outline";
            this.Outline.Height = 0.125F;
            this.Outline.Left = 9.8125F;
            this.Outline.MultiLine = false;
            this.Outline.Name = "Outline";
            this.Outline.OutputFormat = resources.GetString( "Outline.OutputFormat" );
            this.Outline.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Outline.Text = "摘要摘要摘要１２３４５６７８９０１２";
            this.Outline.Top = 0.0625F;
            this.Outline.Width = 1F;
            // 
            // DepositKind02
            // 
            this.DepositKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Height = 0.125F;
            this.DepositKind02.Left = 4.36F;
            this.DepositKind02.MultiLine = false;
            this.DepositKind02.Name = "DepositKind02";
            this.DepositKind02.OutputFormat = resources.GetString( "DepositKind02.OutputFormat" );
            this.DepositKind02.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind02.Text = "1,234,567,890";
            this.DepositKind02.Top = 0.063F;
            this.DepositKind02.Width = 0.68F;
            // 
            // DepositKind04
            // 
            this.DepositKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Height = 0.125F;
            this.DepositKind04.Left = 5.72F;
            this.DepositKind04.MultiLine = false;
            this.DepositKind04.Name = "DepositKind04";
            this.DepositKind04.OutputFormat = resources.GetString( "DepositKind04.OutputFormat" );
            this.DepositKind04.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind04.Text = "1,234,567,890";
            this.DepositKind04.Top = 0.063F;
            this.DepositKind04.Width = 0.68F;
            // 
            // DepositKind03
            // 
            this.DepositKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Height = 0.125F;
            this.DepositKind03.Left = 5.04F;
            this.DepositKind03.MultiLine = false;
            this.DepositKind03.Name = "DepositKind03";
            this.DepositKind03.OutputFormat = resources.GetString( "DepositKind03.OutputFormat" );
            this.DepositKind03.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind03.Text = "1,234,567,890";
            this.DepositKind03.Top = 0.063F;
            this.DepositKind03.Width = 0.68F;
            // 
            // DepositKind05
            // 
            this.DepositKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Height = 0.125F;
            this.DepositKind05.Left = 6.4F;
            this.DepositKind05.MultiLine = false;
            this.DepositKind05.Name = "DepositKind05";
            this.DepositKind05.OutputFormat = resources.GetString( "DepositKind05.OutputFormat" );
            this.DepositKind05.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind05.Text = "1,234,567,890";
            this.DepositKind05.Top = 0.063F;
            this.DepositKind05.Width = 0.68F;
            // 
            // DepositKind09
            // 
            this.DepositKind09.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Height = 0.125F;
            this.DepositKind09.Left = 9.125F;
            this.DepositKind09.MultiLine = false;
            this.DepositKind09.Name = "DepositKind09";
            this.DepositKind09.OutputFormat = resources.GetString( "DepositKind09.OutputFormat" );
            this.DepositKind09.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind09.Text = "1,234,567,890";
            this.DepositKind09.Top = 0.0625F;
            this.DepositKind09.Width = 0.68F;
            // 
            // DepositKind06
            // 
            this.DepositKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Height = 0.125F;
            this.DepositKind06.Left = 7.0625F;
            this.DepositKind06.MultiLine = false;
            this.DepositKind06.Name = "DepositKind06";
            this.DepositKind06.OutputFormat = resources.GetString( "DepositKind06.OutputFormat" );
            this.DepositKind06.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind06.Text = "1,234,567,890";
            this.DepositKind06.Top = 0.0625F;
            this.DepositKind06.Width = 0.68F;
            // 
            // DepositKind07
            // 
            this.DepositKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Height = 0.125F;
            this.DepositKind07.Left = 7.75F;
            this.DepositKind07.MultiLine = false;
            this.DepositKind07.Name = "DepositKind07";
            this.DepositKind07.OutputFormat = resources.GetString( "DepositKind07.OutputFormat" );
            this.DepositKind07.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DepositKind07.Text = "1,234,567,890";
            this.DepositKind07.Top = 0.0625F;
            this.DepositKind07.Width = 0.68F;
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
            this.Line37.Width = 10.8125F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8125F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.tb_SortOrderName,
            this.Label1,
            this.tb_PrintDate,
            this.Label4,
            this.tb_PrintPage,
            this.tb_PrintTime} );
            this.PageHeader.Height = 0.6354167F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler( this.PageHeader_Format );
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
            this.tb_ReportTitle.Text = "入金確認表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.tb_SortOrderName.Left = 3.063F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.063F;
            this.tb_SortOrderName.Width = 2.1875F;
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
            this.Label1.Height = 0.15625F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 7.9375F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label1.Text = "作成日付：";
            this.Label1.Top = 0.0625F;
            this.Label1.Width = 0.625F;
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
            this.tb_PrintDate.OutputFormat = resources.GetString( "tb_PrintDate.OutputFormat" );
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.9375F;
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
            this.Label4.Height = 0.15625F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 9.9375F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label4.Text = "ページ：";
            this.Label4.Top = 0.0625F;
            this.Label4.Width = 0.5F;
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
            this.tb_PrintPage.OutputFormat = resources.GetString( "tb_PrintPage.OutputFormat" );
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
            this.tb_PrintPage.Width = 0.28125F;
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
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport} );
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler( this.PageFooter_Format );
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
            this.ExtraHeader.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport} );
            this.ExtraHeader.Height = 0.5F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler( this.ExtraHeader_Format );
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
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Label86,
            this.Label102,
            this.Label104,
            this.Label105,
            this.DepositKind08_Title,
            this.DepositKind10_Title,
            this.label2,
            this.DepositKind01_Title,
            this.label3,
            this.DepositKind02_Title,
            this.DepositKind04_Title,
            this.DepositKind03_Title,
            this.DepositKind05_Title,
            this.DepositKind09_Title,
            this.DepositKind06_Title,
            this.DepositKind07_Title,
            this.Line42,
            this.line2});
            this.TitleHeader.Height = 0.2395833F;
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
            this.Label86.Left = 0F;
            this.Label86.MultiLine = false;
            this.Label86.Name = "Label86";
            this.Label86.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Label86.Text = "入金日";
            this.Label86.Top = 0.0625F;
            this.Label86.Width = 0.375F;
            // 
            // Label102
            // 
            this.Label102.Border.BottomColor = System.Drawing.Color.Black;
            this.Label102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Border.LeftColor = System.Drawing.Color.Black;
            this.Label102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Border.RightColor = System.Drawing.Color.Black;
            this.Label102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Border.TopColor = System.Drawing.Color.Black;
            this.Label102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label102.Height = 0.14F;
            this.Label102.HyperLink = "";
            this.Label102.Left = 0.4375F;
            this.Label102.MultiLine = false;
            this.Label102.Name = "Label102";
            this.Label102.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Label102.Text = "入金伝票番号";
            this.Label102.Top = 0.0625F;
            this.Label102.Width = 0.65F;
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
            this.Label104.Height = 0.14F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 1.0625F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Label104.Text = "得意先";
            this.Label104.Top = 0.0625F;
            this.Label104.Width = 0.563F;
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
            this.Label105.Left = 2.97F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label105.Text = "合計金額";
            this.Label105.Top = 0.063F;
            this.Label105.Width = 0.71F;
            // 
            // DepositKind08_Title
            // 
            this.DepositKind08_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Height = 0.125F;
            this.DepositKind08_Title.HyperLink = "";
            this.DepositKind08_Title.Left = 8.408F;
            this.DepositKind08_Title.MultiLine = false;
            this.DepositKind08_Title.Name = "DepositKind08_Title";
            this.DepositKind08_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind08_Title.Text = "手数料";
            this.DepositKind08_Title.Top = 0.063F;
            this.DepositKind08_Title.Width = 0.71F;
            // 
            // DepositKind10_Title
            // 
            this.DepositKind10_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Height = 0.125F;
            this.DepositKind10_Title.HyperLink = "";
            this.DepositKind10_Title.Left = 9.565F;
            this.DepositKind10_Title.MultiLine = false;
            this.DepositKind10_Title.Name = "DepositKind10_Title";
            this.DepositKind10_Title.Style = "color: #E0E0E0; ddo-char-set: 128; text-align: right; font-weight: bold; font-siz" +
                "e: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind10_Title.Text = "値引";
            this.DepositKind10_Title.Top = 0.063F;
            this.DepositKind10_Title.Visible = false;
            this.DepositKind10_Title.Width = 0.24F;
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
            this.label2.HyperLink = "";
            this.label2.Left = 2.525F;
            this.label2.MultiLine = false;
            this.label2.Name = "label2";
            this.label2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label2.Text = "手形期日";
            this.label2.Top = 0.063F;
            this.label2.Width = 0.45F;
            // 
            // DepositKind01_Title
            // 
            this.DepositKind01_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Height = 0.125F;
            this.DepositKind01_Title.HyperLink = "";
            this.DepositKind01_Title.Left = 3.65F;
            this.DepositKind01_Title.MultiLine = false;
            this.DepositKind01_Title.Name = "DepositKind01_Title";
            this.DepositKind01_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind01_Title.Text = "現金";
            this.DepositKind01_Title.Top = 0.063F;
            this.DepositKind01_Title.Width = 0.71F;
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
            this.label3.Height = 0.125F;
            this.label3.HyperLink = "";
            this.label3.Left = 9.813F;
            this.label3.MultiLine = false;
            this.label3.Name = "label3";
            this.label3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label3.Text = "摘要";
            this.label3.Top = 0.063F;
            this.label3.Width = 0.71F;
            // 
            // DepositKind02_Title
            // 
            this.DepositKind02_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Height = 0.125F;
            this.DepositKind02_Title.HyperLink = "";
            this.DepositKind02_Title.Left = 4.33F;
            this.DepositKind02_Title.MultiLine = false;
            this.DepositKind02_Title.Name = "DepositKind02_Title";
            this.DepositKind02_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind02_Title.Text = "振込";
            this.DepositKind02_Title.Top = 0.063F;
            this.DepositKind02_Title.Width = 0.71F;
            // 
            // DepositKind04_Title
            // 
            this.DepositKind04_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Height = 0.125F;
            this.DepositKind04_Title.HyperLink = "";
            this.DepositKind04_Title.Left = 5.69F;
            this.DepositKind04_Title.MultiLine = false;
            this.DepositKind04_Title.Name = "DepositKind04_Title";
            this.DepositKind04_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind04_Title.Text = "相殺";
            this.DepositKind04_Title.Top = 0.063F;
            this.DepositKind04_Title.Width = 0.71F;
            // 
            // DepositKind03_Title
            // 
            this.DepositKind03_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Height = 0.125F;
            this.DepositKind03_Title.HyperLink = "";
            this.DepositKind03_Title.Left = 5.01F;
            this.DepositKind03_Title.MultiLine = false;
            this.DepositKind03_Title.Name = "DepositKind03_Title";
            this.DepositKind03_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind03_Title.Text = "手形";
            this.DepositKind03_Title.Top = 0.063F;
            this.DepositKind03_Title.Width = 0.71F;
            // 
            // DepositKind05_Title
            // 
            this.DepositKind05_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Height = 0.125F;
            this.DepositKind05_Title.HyperLink = "";
            this.DepositKind05_Title.Left = 6.37F;
            this.DepositKind05_Title.MultiLine = false;
            this.DepositKind05_Title.Name = "DepositKind05_Title";
            this.DepositKind05_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind05_Title.Text = "小切手";
            this.DepositKind05_Title.Top = 0.063F;
            this.DepositKind05_Title.Width = 0.71F;
            // 
            // DepositKind09_Title
            // 
            this.DepositKind09_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Height = 0.125F;
            this.DepositKind09_Title.HyperLink = "";
            this.DepositKind09_Title.Left = 9.114583F;
            this.DepositKind09_Title.MultiLine = false;
            this.DepositKind09_Title.Name = "DepositKind09_Title";
            this.DepositKind09_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind09_Title.Text = "その他";
            this.DepositKind09_Title.Top = 0.0625F;
            this.DepositKind09_Title.Width = 0.71F;
            // 
            // DepositKind06_Title
            // 
            this.DepositKind06_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Height = 0.125F;
            this.DepositKind06_Title.HyperLink = "";
            this.DepositKind06_Title.Left = 7.033F;
            this.DepositKind06_Title.MultiLine = false;
            this.DepositKind06_Title.Name = "DepositKind06_Title";
            this.DepositKind06_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind06_Title.Text = "口座振替";
            this.DepositKind06_Title.Top = 0.063F;
            this.DepositKind06_Title.Width = 0.71F;
            // 
            // DepositKind07_Title
            // 
            this.DepositKind07_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Height = 0.125F;
            this.DepositKind07_Title.HyperLink = "";
            this.DepositKind07_Title.Left = 7.72F;
            this.DepositKind07_Title.MultiLine = false;
            this.DepositKind07_Title.Name = "DepositKind07_Title";
            this.DepositKind07_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DepositKind07_Title.Text = "ファクタリング";
            this.DepositKind07_Title.Top = 0.063F;
            this.DepositKind07_Title.Width = 0.71F;
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
            this.line2.Top = 0.2F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.2F;
            this.line2.Y2 = 0.2F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Line41} );
            this.TitleFooter.Height = 0F;
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
            this.GrandTotalFooter.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Total_DepositKind01,
            this.Total_Deposit,
            this.Total_DepositKind02,
            this.Total_DepositKind04,
            this.Total_DepositKind03,
            this.Total_DepositKind05,
            this.Total_DepositKind09,
            this.Total_DepositKind06,
            this.Label109,
            this.Total_DepositKind07,
            this.Total_DepositKind08,
            this.Line43} );
            this.GrandTotalFooter.Height = 0.2291667F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // Total_DepositKind01
            // 
            this.Total_DepositKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Height = 0.125F;
            this.Total_DepositKind01.Left = 3.68F;
            this.Total_DepositKind01.MultiLine = false;
            this.Total_DepositKind01.Name = "Total_DepositKind01";
            this.Total_DepositKind01.OutputFormat = resources.GetString( "Total_DepositKind01.OutputFormat" );
            this.Total_DepositKind01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind01.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind01.Text = "1,234,567,890";
            this.Total_DepositKind01.Top = 0.063F;
            this.Total_DepositKind01.Width = 0.68F;
            // 
            // Total_Deposit
            // 
            this.Total_Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.DataField = "DepositTotal";
            this.Total_Deposit.Height = 0.125F;
            this.Total_Deposit.Left = 2.93F;
            this.Total_Deposit.MultiLine = false;
            this.Total_Deposit.Name = "Total_Deposit";
            this.Total_Deposit.OutputFormat = resources.GetString( "Total_Deposit.OutputFormat" );
            this.Total_Deposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_Deposit.SummaryGroup = "GrandTotalHeader";
            this.Total_Deposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_Deposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_Deposit.Text = "1,234,567,890";
            this.Total_Deposit.Top = 0.063F;
            this.Total_Deposit.Width = 0.75F;
            // 
            // Total_DepositKind02
            // 
            this.Total_DepositKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Height = 0.125F;
            this.Total_DepositKind02.Left = 4.36F;
            this.Total_DepositKind02.MultiLine = false;
            this.Total_DepositKind02.Name = "Total_DepositKind02";
            this.Total_DepositKind02.OutputFormat = resources.GetString( "Total_DepositKind02.OutputFormat" );
            this.Total_DepositKind02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind02.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind02.Text = "1,234,567,890";
            this.Total_DepositKind02.Top = 0.063F;
            this.Total_DepositKind02.Width = 0.68F;
            // 
            // Total_DepositKind04
            // 
            this.Total_DepositKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Height = 0.125F;
            this.Total_DepositKind04.Left = 5.72F;
            this.Total_DepositKind04.MultiLine = false;
            this.Total_DepositKind04.Name = "Total_DepositKind04";
            this.Total_DepositKind04.OutputFormat = resources.GetString( "Total_DepositKind04.OutputFormat" );
            this.Total_DepositKind04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind04.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind04.Text = "1,234,567,890";
            this.Total_DepositKind04.Top = 0.063F;
            this.Total_DepositKind04.Width = 0.68F;
            // 
            // Total_DepositKind03
            // 
            this.Total_DepositKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Height = 0.125F;
            this.Total_DepositKind03.Left = 5.04F;
            this.Total_DepositKind03.MultiLine = false;
            this.Total_DepositKind03.Name = "Total_DepositKind03";
            this.Total_DepositKind03.OutputFormat = resources.GetString( "Total_DepositKind03.OutputFormat" );
            this.Total_DepositKind03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind03.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind03.Text = "1,234,567,890";
            this.Total_DepositKind03.Top = 0.063F;
            this.Total_DepositKind03.Width = 0.68F;
            // 
            // Total_DepositKind05
            // 
            this.Total_DepositKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Height = 0.125F;
            this.Total_DepositKind05.Left = 6.4F;
            this.Total_DepositKind05.MultiLine = false;
            this.Total_DepositKind05.Name = "Total_DepositKind05";
            this.Total_DepositKind05.OutputFormat = resources.GetString( "Total_DepositKind05.OutputFormat" );
            this.Total_DepositKind05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind05.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind05.Text = "1,234,567,890";
            this.Total_DepositKind05.Top = 0.063F;
            this.Total_DepositKind05.Width = 0.68F;
            // 
            // Total_DepositKind09
            // 
            this.Total_DepositKind09.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Height = 0.125F;
            this.Total_DepositKind09.Left = 9.125F;
            this.Total_DepositKind09.MultiLine = false;
            this.Total_DepositKind09.Name = "Total_DepositKind09";
            this.Total_DepositKind09.OutputFormat = resources.GetString( "Total_DepositKind09.OutputFormat" );
            this.Total_DepositKind09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind09.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind09.Text = "1,234,567,890";
            this.Total_DepositKind09.Top = 0.0625F;
            this.Total_DepositKind09.Width = 0.68F;
            // 
            // Total_DepositKind06
            // 
            this.Total_DepositKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Height = 0.125F;
            this.Total_DepositKind06.Left = 7.0625F;
            this.Total_DepositKind06.MultiLine = false;
            this.Total_DepositKind06.Name = "Total_DepositKind06";
            this.Total_DepositKind06.OutputFormat = resources.GetString( "Total_DepositKind06.OutputFormat" );
            this.Total_DepositKind06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind06.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind06.Text = "1,234,567,890";
            this.Total_DepositKind06.Top = 0.0625F;
            this.Total_DepositKind06.Width = 0.68F;
            // 
            // Label109
            // 
            this.Label109.Border.BottomColor = System.Drawing.Color.Black;
            this.Label109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.LeftColor = System.Drawing.Color.Black;
            this.Label109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.RightColor = System.Drawing.Color.Black;
            this.Label109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.TopColor = System.Drawing.Color.Black;
            this.Label109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Height = 0.1875F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 2.3125F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label109.Text = "総合計";
            this.Label109.Top = 0.0625F;
            this.Label109.Width = 0.5625F;
            // 
            // Total_DepositKind07
            // 
            this.Total_DepositKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Height = 0.125F;
            this.Total_DepositKind07.Left = 7.75F;
            this.Total_DepositKind07.MultiLine = false;
            this.Total_DepositKind07.Name = "Total_DepositKind07";
            this.Total_DepositKind07.OutputFormat = resources.GetString( "Total_DepositKind07.OutputFormat" );
            this.Total_DepositKind07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind07.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind07.Text = "1,234,567,890";
            this.Total_DepositKind07.Top = 0.0625F;
            this.Total_DepositKind07.Width = 0.68F;
            // 
            // Total_DepositKind08
            // 
            this.Total_DepositKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Height = 0.125F;
            this.Total_DepositKind08.Left = 8.4375F;
            this.Total_DepositKind08.MultiLine = false;
            this.Total_DepositKind08.Name = "Total_DepositKind08";
            this.Total_DepositKind08.OutputFormat = resources.GetString( "Total_DepositKind08.OutputFormat" );
            this.Total_DepositKind08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DepositKind08.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind08.Text = "1,234,567,890";
            this.Total_DepositKind08.Top = 0.0625F;
            this.Total_DepositKind08.Width = 0.68F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.tb_AddUpSecName,
            this.tb_AddUpSecCode,
            this.label15,
            this.TitleHeader_Line1} );
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0.2708333F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // tb_AddUpSecName
            // 
            this.tb_AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.DataField = "AddUpSecName";
            this.tb_AddUpSecName.Height = 0.125F;
            this.tb_AddUpSecName.Left = 0.5005F;
            this.tb_AddUpSecName.MultiLine = false;
            this.tb_AddUpSecName.Name = "tb_AddUpSecName";
            this.tb_AddUpSecName.Style = "ddo-char-set: 128; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_AddUpSecName.Text = "あいうえおかきくけこ";
            this.tb_AddUpSecName.Top = 0.0625F;
            this.tb_AddUpSecName.Width = 1.19F;
            // 
            // tb_AddUpSecCode
            // 
            this.tb_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.DataField = "AddUpSecCode";
            this.tb_AddUpSecCode.Height = 0.125F;
            this.tb_AddUpSecCode.Left = 0.3125F;
            this.tb_AddUpSecCode.MultiLine = false;
            this.tb_AddUpSecCode.Name = "tb_AddUpSecCode";
            this.tb_AddUpSecCode.Style = "ddo-char-set: 128; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.tb_AddUpSecCode.Text = "99";
            this.tb_AddUpSecCode.Top = 0.0625F;
            this.tb_AddUpSecCode.Width = 0.188F;
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
            this.label15.Height = 0.125F;
            this.label15.HyperLink = "";
            this.label15.Left = 0F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label15.Text = "拠点";
            this.label15.Top = 0.0625F;
            this.label15.Width = 0.3125F;
            // 
            // TitleHeader_Line1
            // 
            this.TitleHeader_Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Border.RightColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Border.TopColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Height = 0F;
            this.TitleHeader_Line1.Left = 0F;
            this.TitleHeader_Line1.LineWeight = 2F;
            this.TitleHeader_Line1.Name = "TitleHeader_Line1";
            this.TitleHeader_Line1.Top = 0F;
            this.TitleHeader_Line1.Width = 10.8125F;
            this.TitleHeader_Line1.X1 = 0F;
            this.TitleHeader_Line1.X2 = 10.8125F;
            this.TitleHeader_Line1.Y1 = 0F;
            this.TitleHeader_Line1.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.Section_DepositKind01,
            this.Section_Deposit,
            this.Section_DepositKind02,
            this.Section_DepositKind04,
            this.Section_DepositKind03,
            this.Section_DepositKind05,
            this.Section_DepositKind09,
            this.Section_DepositKind06,
            this.MONEYKINDNAME13,
            this.Section_DepositKind07,
            this.Section_DepositKind08,
            this.Line45} );
            this.SectionFooter.Height = 0.25F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // Section_DepositKind01
            // 
            this.Section_DepositKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Height = 0.125F;
            this.Section_DepositKind01.Left = 3.68F;
            this.Section_DepositKind01.MultiLine = false;
            this.Section_DepositKind01.Name = "Section_DepositKind01";
            this.Section_DepositKind01.OutputFormat = resources.GetString( "Section_DepositKind01.OutputFormat" );
            this.Section_DepositKind01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind01.SummaryGroup = "SectionHeader";
            this.Section_DepositKind01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind01.Text = "1,234,567,890";
            this.Section_DepositKind01.Top = 0.063F;
            this.Section_DepositKind01.Width = 0.68F;
            // 
            // Section_Deposit
            // 
            this.Section_Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.DataField = "DepositTotal";
            this.Section_Deposit.Height = 0.125F;
            this.Section_Deposit.Left = 2.93F;
            this.Section_Deposit.MultiLine = false;
            this.Section_Deposit.Name = "Section_Deposit";
            this.Section_Deposit.OutputFormat = resources.GetString( "Section_Deposit.OutputFormat" );
            this.Section_Deposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_Deposit.SummaryGroup = "SectionHeader";
            this.Section_Deposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_Deposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_Deposit.Text = "1,234,567,890";
            this.Section_Deposit.Top = 0.063F;
            this.Section_Deposit.Width = 0.75F;
            // 
            // Section_DepositKind02
            // 
            this.Section_DepositKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Height = 0.125F;
            this.Section_DepositKind02.Left = 4.36F;
            this.Section_DepositKind02.MultiLine = false;
            this.Section_DepositKind02.Name = "Section_DepositKind02";
            this.Section_DepositKind02.OutputFormat = resources.GetString( "Section_DepositKind02.OutputFormat" );
            this.Section_DepositKind02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind02.SummaryGroup = "SectionHeader";
            this.Section_DepositKind02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind02.Text = "1,234,567,890";
            this.Section_DepositKind02.Top = 0.063F;
            this.Section_DepositKind02.Width = 0.68F;
            // 
            // Section_DepositKind04
            // 
            this.Section_DepositKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Height = 0.125F;
            this.Section_DepositKind04.Left = 5.72F;
            this.Section_DepositKind04.MultiLine = false;
            this.Section_DepositKind04.Name = "Section_DepositKind04";
            this.Section_DepositKind04.OutputFormat = resources.GetString( "Section_DepositKind04.OutputFormat" );
            this.Section_DepositKind04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind04.SummaryGroup = "SectionHeader";
            this.Section_DepositKind04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind04.Text = "1,234,567,890";
            this.Section_DepositKind04.Top = 0.063F;
            this.Section_DepositKind04.Width = 0.68F;
            // 
            // Section_DepositKind03
            // 
            this.Section_DepositKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Height = 0.125F;
            this.Section_DepositKind03.Left = 5.04F;
            this.Section_DepositKind03.MultiLine = false;
            this.Section_DepositKind03.Name = "Section_DepositKind03";
            this.Section_DepositKind03.OutputFormat = resources.GetString( "Section_DepositKind03.OutputFormat" );
            this.Section_DepositKind03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind03.SummaryGroup = "SectionHeader";
            this.Section_DepositKind03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind03.Text = "1,234,567,890";
            this.Section_DepositKind03.Top = 0.063F;
            this.Section_DepositKind03.Width = 0.68F;
            // 
            // Section_DepositKind05
            // 
            this.Section_DepositKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Height = 0.125F;
            this.Section_DepositKind05.Left = 6.4F;
            this.Section_DepositKind05.MultiLine = false;
            this.Section_DepositKind05.Name = "Section_DepositKind05";
            this.Section_DepositKind05.OutputFormat = resources.GetString( "Section_DepositKind05.OutputFormat" );
            this.Section_DepositKind05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind05.SummaryGroup = "SectionHeader";
            this.Section_DepositKind05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind05.Text = "1,234,567,890";
            this.Section_DepositKind05.Top = 0.063F;
            this.Section_DepositKind05.Width = 0.68F;
            // 
            // Section_DepositKind09
            // 
            this.Section_DepositKind09.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Height = 0.125F;
            this.Section_DepositKind09.Left = 9.125F;
            this.Section_DepositKind09.MultiLine = false;
            this.Section_DepositKind09.Name = "Section_DepositKind09";
            this.Section_DepositKind09.OutputFormat = resources.GetString( "Section_DepositKind09.OutputFormat" );
            this.Section_DepositKind09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind09.SummaryGroup = "SectionHeader";
            this.Section_DepositKind09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind09.Text = "1,234,567,890";
            this.Section_DepositKind09.Top = 0.0625F;
            this.Section_DepositKind09.Width = 0.68F;
            // 
            // Section_DepositKind06
            // 
            this.Section_DepositKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Height = 0.125F;
            this.Section_DepositKind06.Left = 7.0625F;
            this.Section_DepositKind06.MultiLine = false;
            this.Section_DepositKind06.Name = "Section_DepositKind06";
            this.Section_DepositKind06.OutputFormat = resources.GetString( "Section_DepositKind06.OutputFormat" );
            this.Section_DepositKind06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind06.SummaryGroup = "SectionHeader";
            this.Section_DepositKind06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind06.Text = "1,234,567,890";
            this.Section_DepositKind06.Top = 0.0625F;
            this.Section_DepositKind06.Width = 0.68F;
            // 
            // MONEYKINDNAME13
            // 
            this.MONEYKINDNAME13.Border.BottomColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.LeftColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.RightColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.TopColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.DataField = "MONEYKINDNAME";
            this.MONEYKINDNAME13.Height = 0.18F;
            this.MONEYKINDNAME13.Left = 2.3125F;
            this.MONEYKINDNAME13.MultiLine = false;
            this.MONEYKINDNAME13.Name = "MONEYKINDNAME13";
            this.MONEYKINDNAME13.OutputFormat = resources.GetString( "MONEYKINDNAME13.OutputFormat" );
            this.MONEYKINDNAME13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.MONEYKINDNAME13.Text = "拠点計";
            this.MONEYKINDNAME13.Top = 0.0625F;
            this.MONEYKINDNAME13.Width = 0.5625F;
            // 
            // Section_DepositKind07
            // 
            this.Section_DepositKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Height = 0.125F;
            this.Section_DepositKind07.Left = 7.75F;
            this.Section_DepositKind07.MultiLine = false;
            this.Section_DepositKind07.Name = "Section_DepositKind07";
            this.Section_DepositKind07.OutputFormat = resources.GetString( "Section_DepositKind07.OutputFormat" );
            this.Section_DepositKind07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind07.SummaryGroup = "SectionHeader";
            this.Section_DepositKind07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind07.Text = "1,234,567,890";
            this.Section_DepositKind07.Top = 0.0625F;
            this.Section_DepositKind07.Width = 0.68F;
            // 
            // Section_DepositKind08
            // 
            this.Section_DepositKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Height = 0.125F;
            this.Section_DepositKind08.Left = 8.4375F;
            this.Section_DepositKind08.MultiLine = false;
            this.Section_DepositKind08.Name = "Section_DepositKind08";
            this.Section_DepositKind08.OutputFormat = resources.GetString( "Section_DepositKind08.OutputFormat" );
            this.Section_DepositKind08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DepositKind08.SummaryGroup = "SectionHeader";
            this.Section_DepositKind08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind08.Text = "1,234,567,890";
            this.Section_DepositKind08.Top = 0.0625F;
            this.Section_DepositKind08.Width = 0.68F;
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
            // MAHNB02012P_03A4C
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
            this.Sections.Add( this.PageHeader );
            this.Sections.Add( this.ExtraHeader );
            this.Sections.Add( this.TitleHeader );
            this.Sections.Add( this.GrandTotalHeader );
            this.Sections.Add( this.SectionHeader );
            this.Sections.Add( this.Detail );
            this.Sections.Add( this.SectionFooter );
            this.Sections.Add( this.GrandTotalFooter );
            this.Sections.Add( this.TitleFooter );
            this.Sections.Add( this.ExtraFooter );
            this.Sections.Add( this.PageFooter );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( resources.GetString( "$this.StyleSheet" ), "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal" ) );
            this.ReportStart += new System.EventHandler( this.MAHNB02012P_03A4C_ReportStart );
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpADate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Outline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind10_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

    }
}
