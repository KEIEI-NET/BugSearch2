using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入日報月報(簡易)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 仕入日報月報(簡易)のフォームクラスです。</br>
	/// <br>Programmer	: 96186 立花 裕輔</br>
	/// <br>Date		: 2007.09.03</br>
    /// <br>Update Note : 2008/11/28 30462 行澤仁美　バグ修正[8484]罫線の追加</br>
    /// <br>Update Note : 2009.02.10 30452 上野 俊治</br>
    /// <br>             ・障害対応11222(ヘッダ部のレイアウト調整)</br>
    /// <br>Update Note : 2014/10/30 周洋</br>
    /// <br>              仕掛一覧№2581 Redmine#43869</br>
    /// <br>              小計、合計部分が桁数が多くなる為、隣の項目と近過ぎて見づらい要望の対応</br>
    /// <br>              （レイアウト変更）</br>
    /// <br>Update Note : 2014/10/31 劉超</br>
    /// <br>              仕掛一覧№2526 Redmine#43867</br>
    /// <br>              拠点計が改頁後の先頭に印刷される場合、拠点名が印刷されない障害の対応</br>
	/// <br>Update Note : 2014/12/04 周洋</br>
	/// <br>              仕掛一覧№2591 Redmine#43991</br>
	/// <br>              金額桁数が10億と100億まで印刷されないの対応</br>
    /// <br>Update Note : 2014/12/09 周洋</br>
    /// <br>              仕掛一覧№2591 Redmine#43991の#43</br>
    /// <br>              1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
    /// <br>Update Note : 2014/12/09 周洋</br>
    /// <br>              仕掛一覧№2591 Redmine#43991の#46</br>
    /// <br>              ドットプリンタ印字不正の対応</br>
	/// </remarks>
	public class DCKOU02103P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 仕入日報月報(簡易)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 仕入日報月報フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 96186　立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		public DCKOU02103P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									// 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderTitle;				// フォームタイトル
		private string				_pageHeaderSortOderTitle;		// ソート順

		private	StockDayMonthReport		_stockDayMonthReport;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

        // ADD 2008/10/16 不具合対応[5788]---------->>>>>
        /// <summary>現在のページ番号</summary>
        private int _currentPageNumber = 1;
        /// <summary>
        /// 現在のページ番号のアクセサ
        /// </summary>
        /// <value>現在のページ番号</value>
        private int CurrentPageNumber
        {
            get { return _currentPageNumber; }
            set { _currentPageNumber = value; }
        }
        // ADD 2008/10/16 不具合対応[5788]----------<<<<<

		// Disposeチェック用フラグ
		bool disposed = false;
        private TextBox DetailLine;
        private Label Lb_ToriyoseHeader;
        private Label label5;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label Lb_GoukeiHeader;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label29;
        private TextBox RetGdsDayTotalZai;
        private TextBox DisDayTotalZai;
        private TextBox NetStcPrcDayTotalZai;
        private TextBox StckPriceDayTotalTori;
        private TextBox RetGdsDayTotalTori;
        private TextBox DisDayTotalTori;
        private TextBox NetStcPrcDayTotalTori;
        private TextBox StckPriceDayTotalGou;
        private TextBox RetGdsDayTotalGou;
        private TextBox DisDayTotalGou;
        private TextBox NetStcPrcDayTotalGou;
        private TextBox StckZaiRatioDayTotalGou;
        private Label label21;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label22;
        private Label label23;
        private TextBox StckPriceMonthTotalGou;
        private TextBox RetGdsMonthTotalGou;
        private TextBox DisDayMonthTotalGou;
        private TextBox NetStcPrcMonthTotalGou;
        private TextBox StckPriceMonthTotalTori;
        private TextBox RetGdsMonthTotalTori;
        private TextBox DisDayMonthTotalTori;
        private TextBox NetStcPrcMonthTotalTori;
        private TextBox StckPriceMonthTotalZai;
        private TextBox RetGdsMonthTotalZai;
        private TextBox DisDayMonthTotalZai;
        private TextBox NetStcPrcMonthTotalZai;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textDayTotalStockZai;
        private TextBox textBox37;
        private TextBox textBox38;
        private TextBox textBox39;
        private TextBox textMonthTotalStockZai;
        private TextBox textBox41;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox textDayTotalStockTori;
        private TextBox textBox45;
        private TextBox textBox46;
        private TextBox textBox47;
        private TextBox textMonthTotalStockTori;
        private TextBox textBox49;
        private TextBox textBox50;
        private TextBox textBox51;
        private TextBox textDayTotalStockGou;
        private TextBox textBox53;
        private TextBox textBox54;
        private TextBox textBox55;
        private TextBox textMonthTotalStockGou;
        private TextBox textDayGoukeiZaiRate;
        private TextBox textMonthGoukeiZaiRate;
        private Label label25;
        private Label label24;
        private Label label26;
        private Label label27;
        private TextBox textBox59;
        private TextBox textDaySectionStockZai;
        private TextBox textBox61;
        private TextBox textBox62;
        private TextBox textBox63;
        private TextBox textDaySectionStockTori;
        private TextBox textBox65;
        private TextBox textBox66;
        private TextBox textBox67;
        private TextBox textDaySectionStockGou;
        private TextBox textBox69;
        private TextBox textDaySectionZaiRate;
        private TextBox textBox71;
        private TextBox textBox72;
        private TextBox textMonthSectionStockZai;
        private TextBox textBox74;
        private TextBox textBox75;
        private TextBox textBox76;
        private TextBox textMonthSectionStockTori;
        private TextBox textBox78;
        private TextBox textBox79;
        private TextBox textBox80;
        private TextBox textMonthSectionStockGou;
        private TextBox textBox82;
        private TextBox textMonthSectionZaiRate;
        private Label label28;
        private Label label30;
        private Label label31;
        private Label label32;
        private TextBox textBox84;
        private TextBox textBox85;
        private TextBox textDaySupplierStockZai;
        private TextBox textBox87;
        private TextBox textBox88;
        private TextBox textBox89;
        private TextBox textMonthSupplierStockZai;
        private TextBox textBox91;
        private TextBox textBox92;
        private TextBox textBox93;
        private TextBox textDaySupplierStockTori;
        private TextBox textBox95;
        private TextBox textBox96;
        private TextBox textBox97;
        private TextBox textMonthSupplierStockTori;
        private TextBox textBox99;
        private TextBox textBox100;
        private TextBox textBox101;
        private TextBox textDaySupplierStockGou;
        private TextBox textBox103;
        private TextBox textBox104;
        private TextBox textBox105;
        private TextBox textMonthSupplierStockGou;
        private TextBox textDaySupplierZaiRate;
        private TextBox textMonthSupplierZaiRate;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private TextBox StckToriRatioDayTotalGou;
        private Label label37;
        private TextBox StckZaiRatioMonthTotalGou;
        private TextBox StckToriRatioMonthTotalGou;
        private Label label38;
        private TextBox textDaySupplierToriRate;
        private TextBox textMonthSupplierToriRate;
        private Label label39;
        private Label label40;
        private TextBox textDaySectionToriRate;
        private TextBox textMonthSectionToriRate;
        private Label label41;
        private Label label42;
        private TextBox textDayGoukeiToriRate;
        private TextBox textMonthGoukeiToriRate;
        private Label label43;
        private Label label44;
        private Label label1;
        private Line line2;
        private Line line5;
        private Line line4;
        private Label Lb_KindTitle2;
        // ----- ADD START 2014/10/31 劉超 FOR Redmine#43867 №2526の対応 ----->>>>>>
        private TextBox PageFooter1;
        private TextBox PageFooter2;
        private Line line7;
        // ----- ADD END 2014/10/31 劉超 FOR Redmine#43867 №2526の対応 -----<<<<<<
		// サプレスバッファ
		//string _sectionCodeSuppresBuf = "";
		//string _stockAgentCodeSuppresBuf = "";
		private Line line3;
		//string _customerCodeSuppresBuf = "";

#if False
		string _slipSuppresBuf = "";

		// 2007.09.03 立花 裕輔 add ---------------->
		// メーカー情報サプレスバッファ
		string _makerSuppresBuf = "";
		// 商品情報サプレスバッファ
		string _goodsSuppresBuf = "";
		// 2007.09.03 立花 裕輔 add <----------------
#endif
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
				this._stockDayMonthReport	= (StockDayMonthReport)this._printInfo.jyoken;
			}
		}

		/// <summary>
		/// その他データ
		/// </summary>
		public ArrayList OtherDataList
		{
			set	{ }
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderTitle = value;}
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
				// TODO:  MAZAI02032P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAZAI02032P_01A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			NewPage SetNewPage = NewPage.Before;
			// 印字設定 --------------------------------------------------------------------------------------
			// 拠点計を出力するかしないかを選択する
			// 拠点有無を判断
			//if ( this._stockDayMonthReport.IsOptSection )
			//{
			//	// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
			//	if ((this._stockDayMonthReport.SectionCode.Length < 2) || 
			//		this._stockDayMonthReport.IsSelectAllSection )
			//	{
			//		SectionHeader.DataField = "";
			//		SectionHeader.Visible = false;
			//		SectionFooter.Visible = false;
			//	}
			//	else
			//	{
			//		// 移動先と移動元を変える
			//		SectionHeader.DataField = DCKOU02105EA.ct_Col_MainSectionCode;
			//		SectionHeader.Visible = true;
			//		SectionFooter.Visible = true;
			//	}
			//}
			//else
			//{
			//	// 拠点無
			//	SectionHeader.DataField = "";
			//	SectionHeader.Visible = false;
			//	SectionFooter.Visible = false;
			//}		

			// 項目の名称をセット
			SortTitle.Text = this._pageHeaderSortOderTitle;	// ソート条件 

            // --- DEL 2008/08/08 -------------------------------->>>>>
            ////改頁なし
            //if((this._stockDayMonthReport.PageType == 0) || (this._stockDayMonthReport.PrintType == 0))
            //{
            //    SetNewPage = NewPage.None;
            //}
            ////改頁あり
            //else
            //{
            //    SetNewPage = NewPage.Before;
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            //改頁なし
            if ((this._stockDayMonthReport.PageType == 1) || (this._stockDayMonthReport.PrintType == 0))
            {
                SetNewPage = NewPage.None;
            }
            //改頁あり
            else
            {
                SetNewPage = NewPage.Before;
            }
            // --- ADD 2008/08/08 --------------------------------<<<<<

			// 帳票種別(1:拠点別 2:仕入先別)
			if (this._stockDayMonthReport.PrintType == 1)
			{
				// タイトル項目の名称をセット
				tb_ReportTitle.Text = this._pageHeaderTitle + "（拠点別）";

				// 仕入先計
				SupplierHeader.DataField = "";
				SupplierHeader.Visible = false;
				SupplierFooter.Visible = false;

				//拠点計
				SectionHeader.NewPage = SetNewPage;

                // --- DEL 2008/08/08 -------------------------------->>>>>
				//SectionHeader.DataField = "";
                //SectionHeader.Visible = false;
                //SectionFooter.Visible = false;
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                SectionHeader.DataField = "SectionCode"; 
				SectionHeader.Visible = true;
				SectionFooter.Visible = true;

                SupplierHeader.NewPage = NewPage.None;
                SupplierHeader.DataField = "";
                // --- ADD 2008/08/08 --------------------------------<<<<<

				//SectionHeaderの拠点コード 拠点名
				SectionCode.Visible = true;
				SectionGuideNm.Visible = true;

				//タイトル
				Lb_KindTitle.Visible = true;
				Lb_KindTitle.Text = "仕入先";
                Lb_KindTitle2.Text = "拠点"; // ADD 2009/02/10

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //Lb_CustomerCode.Visible = false;
                //Lb_CustomerCode.Text = "";
                // --- DEL 2008/08/08 --------------------------------<<<<<

				//仕入先コード印字項目
				CustomerCode.Visible = false;
				CustomerCode.DataField = "";
				CustomerName.Visible = false;
				CustomerName.DataField = "";
			}
            // --- DEL 2008/08/08 -------------------------------->>>>>
            //else if (this._stockDayMonthReport.PrintType == 1)
            //{
            //    // タイトル項目の名称をセット
            //    tb_ReportTitle.Text = this._pageHeaderTitle + "（担当者別）";

            //    //担当計
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;

            //    //拠点計
            //    SectionHeader.NewPage = SetNewPage;
            //    SectionHeader.DataField = "SectionCode";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = true;

            //    //SectionHeaderの拠点コード 拠点名
            //    SectionCode.Visible = true;
            //    SectionGuideNm.Visible = true;

            //    //タイトル
            //    Lb_SectionCode.Visible = true;
            //    Lb_SectionCode.Text = "拠点";

            //    // --- ADD 2008/08/08 -------------------------------->>>>>
            //    //Lb_CustomerCode.Visible = false;
            //    //Lb_CustomerCode.Text = "";
            //    // --- ADD 2008/08/08 --------------------------------<<<<<

            //    Lb_StockAgentCode.Text = "担当者";

            //    //仕入先コード印字項目
            //    CustomerCode.Visible = false;
            //    CustomerCode.DataField = "";
            //    CustomerName.Visible = false;
            //    CustomerName.DataField = "";
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 
			else if (this._stockDayMonthReport.PrintType == 2)
			{
				// タイトル項目の名称をセット
				tb_ReportTitle.Text = this._pageHeaderTitle + "（仕入先別）";

				// 仕入先計
				SupplierHeader.DataField = "";
				SupplierHeader.Visible = true;
				SupplierFooter.Visible = true;

				//拠点計
                // --- DEL 2008/08/08 -------------------------------->>>>>
                //SectionHeader.NewPage = SetNewPage;
                //SectionHeader.DataField = "SectionCode";
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                // --- ADD 2008/08/08 -------------------------------->>>>>
                SectionHeader.NewPage = NewPage.None;
                SectionHeader.DataField = "";

                SectionHeader.Visible = false;
                SectionFooter.Visible = false;

                SupplierHeader.NewPage = SetNewPage;
                SupplierHeader.DataField = "SupplierCode";

                CustomerCode.Visible = true;
                CustomerName.Visible = true;
                // --- ADD 2008/08/08 --------------------------------<<<<<

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //SectionHeader.Visible = true;
                //SectionFooter.Visible = true;
                // --- DEL 2008/08/08 --------------------------------<<<<< 

				//SectionHeaderの拠点コード 拠点名
				//SectionCode.Visible = true;
				//SectionGuideNm.Visible = true;

				//タイトル
				Lb_KindTitle.Visible = true;
				Lb_KindTitle.Text = "拠点";
                Lb_KindTitle2.Text = "仕入先"; // ADD 2009/02/10

                // --- DEL 2008/08/08 -------------------------------->>>>>
                //Lb_CustomerCode.Visible = false;
                //Lb_CustomerCode.Text = "";
                // --- DEL 2008/08/08 --------------------------------<<<<< 

                ////仕入先コード印字項目
                //CustomerCode.Visible = false;
                //CustomerCode.DataField = "";
                //CustomerName.Visible = false;
                //CustomerName.DataField = "";

                this.DetailLine.OutputFormat = "00";    // ADD 2008/10/07 不具合対応[6207]
			}
            // --- DEL 2008/08/08 -------------------------------->>>>>
            //else if (this._stockDayMonthReport.PrintType == 3)
            //{
            //    // タイトル項目の名称をセット
            //    tb_ReportTitle.Text = this._pageHeaderTitle + "（担当者仕入先別）";

            //    //担当計
            //    WareHouseHeader.DataField = "StockAgentCode";
            //    WareHouseHeader.Visible = true;
            //    WareHouseFooter.Visible = true;

            //    //拠点計
            //    SectionHeader.NewPage = SetNewPage;
            //    SectionHeader.DataField = "SectionCode";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = true;

            //    //SectionHeaderの拠点コード 拠点名
            //    SectionCode.Visible = true;
            //    SectionGuideNm.Visible = true;

            //    //タイトル
            //    Lb_SectionCode.Visible = true;
            //    Lb_SectionCode.Text = "拠点";

            //    // --- ADD 2008/08/08 -------------------------------->>>>>
            //    //Lb_CustomerCode.Visible = true;
            //    //Lb_CustomerCode.Text = "担当者";
            //    // --- ADD 2008/08/08 --------------------------------<<<<<

            //    Lb_StockAgentCode.Text = "仕入先";

            //    //仕入先コード印字項目
            //    CustomerCode.Visible = true;
            //    CustomerCode.DataField = "StockAgentCode";
            //    CustomerName.Visible = true;
            //    CustomerName.DataField = "StockAgentName";

            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

		}
		#endregion ◆ レポート要素出力設定

		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{

			//this._sectionCodeSuppresBuf = this.SectionCode.Text.Trim();
			//this._stockAgentCodeSuppresBuf = this.StockAgentCode.Text.Trim();
			//this._customerCodeSuppresBuf = this.CustomerCode.Text.Trim();

#if False
			// 前回出力した拠点コードが同じ場合は出力しない
			if (this.SectionCode.Text.Trim().CompareTo(this._sectionCodeSuppresBuf) == 0)
			{
				SectionCode.Visible = false;

				// 前回出力した担当者コードが同じ場合は出力しない
				if (this.StockAgentCode.Text.Trim().CompareTo(this._stockAgentCodeSuppresBuf) == 0)
				{
					StockAgentCode.Visible = false;

					// 前回出力した仕入コードが同じ場合は出力しない
					if (this.CustomerCode.Text.Trim().CompareTo(this._customerCodeSuppresBuf) == 0)
					{
						CustomerCode.Visible = false;
					}
					else
					{
					}
				}
				else
				{
				}
			}
			else
			{
				SectionCode.Visible = true;
			}
#endif
			//グループサプレス項目値の保存
			//this._sectionCodeSuppresBuf = this.SectionCode.Text.Trim();
			//this._stockAgentCodeSuppresBuf = this.StockAgentCode.Text.Trim();
			//this._customerCodeSuppresBuf = this.CustomerCode.Text.Trim();


#if False
			#region // 2007.09.03 立花 裕輔 del
			// 主拠点、主倉庫、抽出日付、絞込み拠点、絞込み倉庫は1つの伝票で同じなのでサプレスのキーは伝票番号のみとし、
			// 伝票番号の変更により表示を切り替える

			// 前回出力した伝票ヘッダ情報とバッファの値が同じなら出力しない。
			if ( this.StockMoveSlipNo.Text.Trim().CompareTo(this._slipSuppresBuf) == 0 )
			{
			    // 非表示
			    StockMoveSlipNo.Visible = false;		// 移動伝票番号
			    MainSectionName.Visible = false;		// 主拠点名称
			    MainWhareHouseName.Visible = false;		// 主倉庫名称
			    ExtractDate.Visible = false;			// 抽出日付
			    ExtractSectionName.Visible = false;		// 抽出拠点名称(在庫移動でも倉庫移動でもとにかくfalse)
			    ExtractWhareHouseName.Visible = false;	// 抽出倉庫名称

				#region // 2007.09.03 立花 裕輔 del
				//if ( this.StockMoveRowNo.Text.Trim().CompareTo(this._stockMoveRowNo) == 0 )
				//{
				//    MakerName.Visible = false;			// メーカー名称	
				//    GoodsCode.Visible = false;			// 商品コード
				//    GoodsName.Visible = false;			// 商品名称
				//}
				//else
				//{
				//    MakerName.Visible = true;			// メーカー名称	
				//    GoodsCode.Visible = true;			// 商品コード
				//    GoodsName.Visible = true;			// 商品名称
				//}
				#endregion
				// 2007.09.03 立花 裕輔 add ---------------->
				// メーカー、商品のサプレス判断(メーカー、商品が同じときだけサプレス) 
				if ( ( this.MakerCode.Text.Trim().CompareTo( this._makerSuppresBuf ) == 0 ) &&
					( this.GoodsCode.Text.Trim().CompareTo( this._goodsSuppresBuf ) == 0 ) )
				{
					// 製番が無かったら有無を言わさず出力
					if ( this.ProductNumber.Text.Trim().CompareTo("") == 0 )
					{
						MakerName.Visible = true;			// メーカー名称	
						GoodsCode.Visible = true;			// 商品コード
						GoodsName.Visible = true;			// 商品名称
					}
					else
					{
						MakerName.Visible = false;			// メーカー名称	
						GoodsCode.Visible = false;			// 商品コード
						GoodsName.Visible = false;			// 商品名称
					}
				}
				else
				{
					MakerName.Visible = true;			// メーカー名称	
					GoodsCode.Visible = true;			// 商品コード
					GoodsName.Visible = true;			// 商品名称
				}
				// 2007.09.03 立花 裕輔 add <----------------

			}
			else
			{
			    // 表示 伝票が変わったら全ての情報を表示
			    StockMoveSlipNo.Visible = true;		// 移動伝票番号
			    MainSectionName.Visible = true;		// 主拠点名称
			    MainWhareHouseName.Visible = true;	// 主倉庫名称
			    ExtractDate.Visible = true;			// 抽出日付
			    if ( this._stockDayMonthReport.StockMoveFormalDiv == StockDayMonthReport.StockMoveFormalDivState.StockMove )
			    {
			        ExtractSectionName.Visible = true;		// 抽出拠点名称(在庫移動のときだけtrueに。)
			    }
			    ExtractWhareHouseName.Visible = true;	// 抽出倉庫名称
			    MakerName.Visible = true;				// メーカー名称	
			    GoodsCode.Visible = true;				// 商品コード
			    GoodsName.Visible = true;				// 商品名称

			}





			this._slipSuppresBuf = this.StockMoveSlipNo.Text.Trim();
			// 2007.09.03 立花 裕輔 add ------------------------------------->
			this._makerSuppresBuf	= this.MakerCode.Text.Trim();
			this._goodsSuppresBuf	= this.GoodsCode.Text.Trim();
			// 2007.09.03 立花 裕輔 add <-------------------------------------
 
			#endregion
#endif
		}
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

		#region ◎ MAZAI02032P_01A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ MAZAI02032P_01A4C_PageEnd Event
		/// <summary>
		/// MAZAI02032P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: MAZAI02032P_01A4C_PageEnd Event</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
			//this._sectionCodeSuppresBuf = "";
			//this._stockAgentCodeSuppresBuf = "";
			//this._customerCodeSuppresBuf = "";
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			//現在の時刻を取得
			DateTime now = DateTime.Now;
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
			// 作成時間
			this.tb_PrintTime.Text   = now.ToString("HH:mm");
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
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

#if False
			// 拠点オプション有無判定
			string sectionTitle = "拠点：";
			if (this._stockDayMonthReport.SectionCode.GetLength(0) == 0)
			{
				this._rptExtraHeader.SectionCondition.Text = string.Format("{0}{1}", sectionTitle, "全社");
			}
			else
			{
				this._rptExtraHeader.SectionCondition.Text = string.Format("{0}{1}", sectionTitle, this.tb_MainSectionName.Text);
			}
#endif

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion

		#region ◎ Detail_Format Event
		/// <summary>
		/// Detail_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: Detailグループのフォーマットイベント。</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// <br>Update Note : 2014/12/04 周洋</br>
		/// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#46 ドットプリンタ印字不正の対応</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
			TextBox[] arrDetail = new TextBox[] { StckPriceDayTotalZai, StckPriceMonthTotalZai, NetStcPrcDayTotalZai, NetStcPrcMonthTotalZai, StckPriceDayTotalTori, StckPriceMonthTotalTori,
			  NetStcPrcDayTotalTori, NetStcPrcMonthTotalTori, StckPriceDayTotalGou, StckPriceMonthTotalGou, NetStcPrcDayTotalGou, NetStcPrcMonthTotalGou};
			foreach (TextBox i in arrDetail)
			{
				if (i.Text.Length == 13)
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.35pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.3pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
				else
				{
					i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
				}
			}
			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
            // ADD 2008/10/16 不具合対応[5788]---------->>>>>
            // TODO:自身の印字のタイミングで現在のページ番号が変化したときの処理
            int currentPageNumber = int.Parse(this.tb_PrintPage.Text.Trim());
            if (!CurrentPageNumber.Equals(currentPageNumber))
            {
                CurrentPageNumber = currentPageNumber;
            }
            // ADD 2008/10/16 不具合対応[5788]----------<<<<<

			// グループサプレスの判断
			this.CheckGroupSuppression();
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);
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
		/// <br>Programmer  : 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
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

		#region ◎ DailyFooter_Format Event
		/// <summary>
		/// DailyFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DailyFooter_Format Event</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
		{
			// 日計が出た後はバッファをクリアして、明細に出力する。
			//this._sectionCodeSuppresBuf = "";
			//this._stockAgentCodeSuppresBuf = "";
			//this._customerCodeSuppresBuf = "";
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
        /// <br>Update Note : 2014/10/31 劉超</br>
        /// <br>              Redmine#43867 №2526 拠点計が改頁後に先頭に印刷される場合、拠点名が印刷されないの修正対応</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            /* ----- DEL START 2014/10/31 劉超 FOR Redmine#43867 №2526の対応 ----->>>>>>
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
            // ----- DEL END 2014/10/31 劉超 FOR Redmine#43867 №2526の対応 ----->>>>>> */
            // ----- ADD START 2014/10/31 劉超 FOR Redmine#43867 №2526の対応 ----->>>>>>
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッター印字項目設定
                this.line7.Visible = true;
                if (this._pageFooters[0] != null)
                {
                    this.PageFooter1.Text = this._pageFooters[0];
                }
                else
                {
                    this.PageFooter1.Text = string.Empty;
                }
                if (this._pageFooters[1] != null)
                {
                    this.PageFooter2.Text = this._pageFooters[1];
                }
                else
                {
                    this.PageFooter2.Text = string.Empty;
                }
            }
            else
            {
                this.line7.Visible = false;
                this.PageFooter1.Text = string.Empty;
                this.PageFooter2.Text = string.Empty;
            }
            // ----- ADD END 2014/10/31 劉超 FOR Redmine#43867 №2526の対応 -----<<<<<<
        }
		#endregion

		#endregion ■ Control Event

        // --- DEL 2008/08/08 -------------------------------->>>>>
        //private void WareHouseFooter_Format(object sender, System.EventArgs eArgs)
        //{
            ////返品率＜日計＞
            //if (double.Parse(this.w_StckPriceDayTotal.Value.ToString()) == 0)
            //{
            //    w_RetGdsDayRate.Value = 0;
            //}
            //else
            //{
            //    w_RetGdsDayRate.Value = Math.Abs(double.Parse(this.w_RetGdsDayTotal.Value.ToString()) * 100 / double.Parse(this.w_StckPriceDayTotal.Value.ToString()));
            //}
            ////返品率＜累計＞
            //if (double.Parse(this.w_StckPriceMonthTotal.Value.ToString()) == 0)
            //{
            //    w_RetGdsMonthRate.Value = 0;
            //}
            //else
            //{
            //    w_RetGdsMonthRate.Value = Math.Abs(double.Parse(this.w_RetGdsMonthTotal.Value.ToString()) * 100 / double.Parse(this.w_StckPriceMonthTotal.Value.ToString()));
            //}
            ////値引率＜日計＞
            //if (double.Parse(this.w_StckPriceDayTotal.Value.ToString()) == 0)
            //{
            //    w_DisDayRate.Value = 0;
            //}
            //else
            //{
            //    w_DisDayRate.Value = Math.Abs(double.Parse(this.w_RetGdsDayTotal.Value.ToString()) * 100 / double.Parse(this.w_StckPriceDayTotal.Value.ToString()));
            //}
            ////値引率＜累計＞
            //if (double.Parse(this.w_StckPriceMonthTotal.Value.ToString()) == 0)
            //{
            //    w_DisDayMonthRate.Value = 0;
            //}
            //else
            //{
            //    w_DisDayMonthRate.Value = Math.Abs(double.Parse(this.w_DisDayMonthTotal.Value.ToString()) * 100 / double.Parse(this.w_StckPriceMonthTotal.Value.ToString()));
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 
		//}
        // --- DEL 2008/08/08 --------------------------------<<<<< 

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
            // --- DEL 2008/08/08 -------------------------------->>>>>
            ////返品率＜日計＞
            //if (double.Parse(this.s_StckPriceDayTotal.Value.ToString()) == 0)
            //{
            //    s_RetGdsDayRate.Value = 0;
            //}
            //else
            //{
            //    s_RetGdsDayRate.Value = Math.Abs(double.Parse(this.s_RetGdsDayTotal.Value.ToString()) * 100 / double.Parse(this.s_StckPriceDayTotal.Value.ToString()));
            //}
            ////返品率＜累計＞
            //if (double.Parse(this.s_StckPriceMonthTotal.Value.ToString()) == 0)
            //{
            //    s_RetGdsMonthRate.Value = 0;
            //}
            //else
            //{
            //    s_RetGdsMonthRate.Value = Math.Abs(double.Parse(this.s_RetGdsMonthTotal.Value.ToString()) * 100 / double.Parse(this.s_StckPriceMonthTotal.Value.ToString()));
            //}
            ////値引率＜日計＞
            //if (double.Parse(this.s_StckPriceDayTotal.Value.ToString()) == 0)
            //{
            //    s_DisDayRate.Value = 0;
            //}
            //else
            //{
            //    s_DisDayRate.Value = Math.Abs(double.Parse(this.s_RetGdsDayTotal.Value.ToString()) * 100 / double.Parse(this.s_StckPriceDayTotal.Value.ToString()));
            //}
            ////値引率＜累計＞
            //if (double.Parse(this.s_StckPriceMonthTotal.Value.ToString()) == 0)
            //{
            //    s_DisDayMonthRate.Value = 0;
            //}
            //else
            //{
            //    s_DisDayMonthRate.Value = Math.Abs(double.Parse(this.s_DisDayMonthTotal.Value.ToString()) * 100 / double.Parse(this.s_StckPriceMonthTotal.Value.ToString()));
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            // 比率計算
            double rateWork;

            if ((double)textDaySectionStockGou.Value != 0)
            {
                // 在庫比率計算(日計)
                rateWork = (double)textDaySectionStockZai.Value / (double)textDaySectionStockGou.Value * 100;
                textDaySectionZaiRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textDaySectionZaiRate.Value = 0;
            }

            if ((double)textDaySectionStockGou.Value != 0)
            {
                // 取寄比率計算(日計)
                rateWork = (double)textDaySectionStockTori.Value / (double)textDaySectionStockGou.Value * 100;
                textDaySectionToriRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textDaySectionToriRate.Value = 0;
            }

            if ((double)textMonthSectionStockGou.Value != 0)
            {
                // 在庫比率計算(月計)
                rateWork = (double)textMonthSectionStockZai.Value / (double)textMonthSectionStockGou.Value * 100;
                textMonthSectionZaiRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textMonthSectionZaiRate.Value = 0;
            }

            if ((double)textMonthSectionStockGou.Value != 0)
            {
                // 取寄比率計算(月計)
                rateWork = (double)textMonthSectionStockTori.Value / (double)textMonthSectionStockGou.Value * 100;
                textMonthSectionToriRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textMonthSectionToriRate.Value = 0;
            }
            // --- ADD 2008/08/08 --------------------------------<<<<<

			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
			TextBox[] arrSection = new TextBox[] { textBox59, textBox72, textDaySectionStockZai, textMonthSectionStockZai, textBox63, textBox76, 
				textDaySectionStockTori, textMonthSectionStockTori, textBox67, textBox80, textDaySectionStockGou, textMonthSectionStockGou };
			foreach (TextBox i in arrSection)
			{
				if (i.Text.Length == 13)
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.35pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.3pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
				else
				{
					i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
				}
			}
			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
		}

		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
            // --- DEL 2008/08/08 -------------------------------->>>>>
            ////返品率＜日計＞
            //if (double.Parse(this.g_StckPriceDayTotal.Value.ToString()) == 0)
            //{
            //    g_RetGdsDayRate.Value = 0;
            //}
            //else
            //{
            //    g_RetGdsDayRate.Value = Math.Abs(double.Parse(this.g_RetGdsDayTotal.Value.ToString()) * 100 / double.Parse(this.g_StckPriceDayTotal.Value.ToString()));
            //}
            ////返品率＜累計＞
            //if (double.Parse(this.g_StckPriceMonthTotal.Value.ToString()) == 0)
            //{
            //    g_RetGdsMonthRate.Value = 0;
            //}
            //else
            //{
            //    g_RetGdsMonthRate.Value = Math.Abs(double.Parse(this.g_RetGdsMonthTotal.Value.ToString()) * 100 / double.Parse(this.g_StckPriceMonthTotal.Value.ToString()));
            //}
            ////値引率＜日計＞
            //if (double.Parse(this.g_StckPriceDayTotal.Value.ToString()) == 0)
            //{
            //    g_DisDayRate.Value = 0;
            //}
            //else
            //{
            //    g_DisDayRate.Value = Math.Abs(double.Parse(this.g_RetGdsDayTotal.Value.ToString()) * 100 / double.Parse(this.g_StckPriceDayTotal.Value.ToString()));
            //}
            ////値引率＜累計＞
            //if (double.Parse(this.g_StckPriceMonthTotal.Value.ToString()) == 0)
            //{
            //    g_DisDayMonthRate.Value = 0;
            //}
            //else
            //{
            //    g_DisDayMonthRate.Value = Math.Abs(double.Parse(this.g_DisDayMonthTotal.Value.ToString()) * 100 / double.Parse(this.g_StckPriceMonthTotal.Value.ToString()));
            //}
            // --- DEL 2008/08/08 --------------------------------<<<<< 

            // --- ADD 2008/08/08 -------------------------------->>>>>
            // 比率計算
            double rateWork;

            if ((double)textDayTotalStockGou.Value != 0)
            {
                // 在庫比率計算(日計)
                rateWork = (double)textDayTotalStockZai.Value / (double)textDayTotalStockGou.Value * 100;
                textDayGoukeiZaiRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textDayGoukeiZaiRate.Value = 0;
            }

            if ((double)textDayTotalStockGou.Value != 0)
            {
                // 取寄比率計算(日計)
                rateWork = (double)textDayTotalStockTori.Value / (double)textDayTotalStockGou.Value * 100;
                textDayGoukeiToriRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textDayGoukeiToriRate.Value = 0;
            }

            if ((double)textMonthTotalStockGou.Value != 0)
            {
                // 在庫比率計算(月計)
                rateWork = (double)textMonthTotalStockZai.Value / (double)textMonthTotalStockGou.Value * 100;
                textMonthGoukeiZaiRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textMonthGoukeiZaiRate.Value = 0;
            }

            if ((double)textMonthTotalStockGou.Value != 0)
            {
                // 取寄比率計算(月計)
                rateWork = (double)textMonthTotalStockTori.Value / (double)textMonthTotalStockGou.Value * 100;
                textMonthGoukeiToriRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textMonthGoukeiToriRate.Value = 0;
            }
            // --- ADD 2008/08/08 --------------------------------<<<<<

			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
			TextBox[] arrTotal = new TextBox[] { g_StckPriceDayTotal, textBox37, textDayTotalStockZai, textMonthTotalStockZai, textBox41, textBox45, 
				textDayTotalStockTori, textMonthTotalStockTori, textBox49, textBox53, textDayTotalStockGou, textMonthTotalStockGou };
            foreach (TextBox i in arrTotal)
			{
				if (i.Text.Length == 13)
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.35pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.3pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
				else
				{
					i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
				}
			}
			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
		}

        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 比率(在庫・取寄)を計算する。</br>
        /// <br>Programmer	: 30415 柴田 倫幸</br>
        /// <br>Date		: 2008/08/08</br>
		/// <br>Update Note : 2014/12/04 周洋</br>
		/// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#46 ドットプリンタ印字不正の対応</br>
        /// </remarks>
        private void SupplierFooter_Format(object sender, EventArgs e)
        {
            double rateWork;

            if ((double)textDaySupplierStockGou.Value != 0)
            {
                // 在庫比率計算(日計)
                rateWork = (double)textDaySupplierStockZai.Value / (double)textDaySupplierStockGou.Value * 100;
                textDaySupplierZaiRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textDaySupplierZaiRate.Value = 0;
            }

            if ((double)textDaySupplierStockGou.Value != 0)
            {
                // 取寄比率計算(日計)
                rateWork = (double)textDaySupplierStockTori.Value / (double)textDaySupplierStockGou.Value * 100;
                textDaySupplierToriRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textDaySupplierToriRate.Value = 0;
            }

            if ((double)textMonthSupplierStockGou.Value != 0)
            {
                // 在庫比率計算(月計)
                rateWork = (double)textMonthSupplierStockZai.Value / (double)textMonthSupplierStockGou.Value * 100;
                textMonthSupplierZaiRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textMonthSupplierZaiRate.Value = 0;
            }

            if ((double)textMonthSupplierStockGou.Value != 0)
            {
                // 取寄比率計算(月計)
                rateWork = (double)textMonthSupplierStockTori.Value / (double)textMonthSupplierStockGou.Value * 100;
                textMonthSupplierToriRate.Value = Math.Round(rateWork, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                textMonthSupplierToriRate.Value = 0;
            }

			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
			TextBox[] arrSupplier = new TextBox[] { w_StckPriceDayTotal, textBox87, textDaySupplierStockZai, textMonthSupplierStockZai, textBox91, textBox95, 
				textDaySupplierStockTori, textMonthSupplierStockTori, textBox99, textBox103, textDaySupplierStockGou, textMonthSupplierStockGou};
			foreach (TextBox i in arrSupplier)
			{
				if (i.Text.Length == 13)
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.9pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
                //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
                else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
				{
                    //i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.35pt; font-family: ＭＳ ゴシック; vertical-align: top; ";    //DEL 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.3pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";    //ADD 周洋 2014/12/09 for Redmine43991の#46 ドットプリンタ印字不正の対応
				}
				else
				{
					i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
				}
			}
			// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
        }

        // ADD 2008/10/16 不具合対応[5788]---------->>>>>
        #region ■自身の印字のタイミングで現在のページ番号が変化したときの処理

        /// <summary>
        /// 現在のページ番号が変化したとき罫線を隠します。
        /// </summary>
        /// <param name="line">罫線</param>
        private void HideLineIfCurrentPageNumberWasChanged(Line line)
        {
            int printingPageNumber = int.Parse(this.tb_PrintPage.Text.Trim());
            if (!CurrentPageNumber.Equals(printingPageNumber))
            {
                line.Visible = false;
                CurrentPageNumber = printingPageNumber;
            }
            else
            {
                line.Visible = true;
            }
        }

        /// <summary>
        /// 仕入先小計フッターのBeforePrintイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SupplierFooter_BeforePrint(object sender, EventArgs e)
        {
            //HideLineIfCurrentPageNumberWasChanged(this.Line); // DEL 2014/10/31 劉超 FOR Redmine#43867 №2526の対応
        }

        /// <summary>
        /// 拠点小計フッターのBeforePrintイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            //HideLineIfCurrentPageNumberWasChanged(this.Line45); // DEL 2014/10/31 劉超 FOR Redmine#43867 №2526の対応
        }

        /// <summary>
        /// 総合計フッターのBeforePrintイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            //HideLineIfCurrentPageNumberWasChanged(this.Line43); // DEL 2014/10/31 劉超 FOR Redmine#43867 №2526の対応
        }

        #endregion  // 自身の印字のタイミングで現在のページ番号が変化したときの処理
        // ADD 2008/10/16 不具合対応[5788]----------<<<<<

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.TextBox SortTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Label Lb_KindTitle;
		private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_ZaikoHeader;
        private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label7;
        private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.TextBox tb_MainSectionName;
		private DataDynamics.ActiveReports.GroupHeader SupplierHeader;
		private DataDynamics.ActiveReports.GroupHeader DailyHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox SectionGuideNm;
		private DataDynamics.ActiveReports.TextBox SectionCode;
		private DataDynamics.ActiveReports.TextBox CustomerName;
        private DataDynamics.ActiveReports.TextBox CustomerCode;
		private DataDynamics.ActiveReports.TextBox DetailLineName;
		private DataDynamics.ActiveReports.TextBox TextBox;
		private DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.TextBox StckPriceDayTotalZai;
		private DataDynamics.ActiveReports.GroupFooter DailyFooter;
		private DataDynamics.ActiveReports.GroupFooter SupplierFooter;
        private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox TextBox15;
		private DataDynamics.ActiveReports.TextBox TextBox16;
        private DataDynamics.ActiveReports.TextBox w_StckPriceDayTotal;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox TextBox17;
		private DataDynamics.ActiveReports.TextBox TextBox18;
        private DataDynamics.ActiveReports.TextBox s_StckPriceDayTotal;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
        private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox TextBox19;
		private DataDynamics.ActiveReports.TextBox TextBox20;
        private DataDynamics.ActiveReports.TextBox g_StckPriceDayTotal;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKOU02103P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.DetailLineName = new DataDynamics.ActiveReports.TextBox();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceDayTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.DetailLine = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsDayTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.DisDayTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcDayTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceDayTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsDayTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.DisDayTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcDayTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceDayTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsDayTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.DisDayTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcDayTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.StckPriceMonthTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsMonthTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.DisDayMonthTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcMonthTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceMonthTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsMonthTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.DisDayMonthTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcMonthTotalTori = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceMonthTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsMonthTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.DisDayMonthTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcMonthTotalZai = new DataDynamics.ActiveReports.TextBox();
            this.StckToriRatioMonthTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.StckZaiRatioMonthTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.StckZaiRatioDayTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.StckToriRatioDayTotalGou = new DataDynamics.ActiveReports.TextBox();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.label37 = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.PageFooter1 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter2 = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_KindTitle = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_ZaikoHeader = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Lb_ToriyoseHeader = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.Lb_GoukeiHeader = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.Lb_KindTitle2 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.g_StckPriceDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textDayTotalStockZai = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthTotalStockZai = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textDayTotalStockTori = new DataDynamics.ActiveReports.TextBox();
            this.textBox45 = new DataDynamics.ActiveReports.TextBox();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.textBox47 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthTotalStockTori = new DataDynamics.ActiveReports.TextBox();
            this.textBox49 = new DataDynamics.ActiveReports.TextBox();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox51 = new DataDynamics.ActiveReports.TextBox();
            this.textDayTotalStockGou = new DataDynamics.ActiveReports.TextBox();
            this.textBox53 = new DataDynamics.ActiveReports.TextBox();
            this.textBox54 = new DataDynamics.ActiveReports.TextBox();
            this.textBox55 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthTotalStockGou = new DataDynamics.ActiveReports.TextBox();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.textDayGoukeiToriRate = new DataDynamics.ActiveReports.TextBox();
            this.textDayGoukeiZaiRate = new DataDynamics.ActiveReports.TextBox();
            this.textMonthGoukeiZaiRate = new DataDynamics.ActiveReports.TextBox();
            this.textMonthGoukeiToriRate = new DataDynamics.ActiveReports.TextBox();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.label44 = new DataDynamics.ActiveReports.Label();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_MainSectionName = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.s_StckPriceDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.textDaySectionStockZai = new DataDynamics.ActiveReports.TextBox();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.textDaySectionStockTori = new DataDynamics.ActiveReports.TextBox();
            this.textBox65 = new DataDynamics.ActiveReports.TextBox();
            this.textBox66 = new DataDynamics.ActiveReports.TextBox();
            this.textBox67 = new DataDynamics.ActiveReports.TextBox();
            this.textDaySectionStockGou = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.textBox71 = new DataDynamics.ActiveReports.TextBox();
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSectionStockZai = new DataDynamics.ActiveReports.TextBox();
            this.textBox74 = new DataDynamics.ActiveReports.TextBox();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.textBox76 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSectionStockTori = new DataDynamics.ActiveReports.TextBox();
            this.textBox78 = new DataDynamics.ActiveReports.TextBox();
            this.textBox79 = new DataDynamics.ActiveReports.TextBox();
            this.textBox80 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSectionStockGou = new DataDynamics.ActiveReports.TextBox();
            this.textBox82 = new DataDynamics.ActiveReports.TextBox();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.textDaySectionToriRate = new DataDynamics.ActiveReports.TextBox();
            this.textDaySectionZaiRate = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSectionZaiRate = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSectionToriRate = new DataDynamics.ActiveReports.TextBox();
            this.label41 = new DataDynamics.ActiveReports.Label();
            this.label42 = new DataDynamics.ActiveReports.Label();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.w_StckPriceDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.textBox84 = new DataDynamics.ActiveReports.TextBox();
            this.textBox85 = new DataDynamics.ActiveReports.TextBox();
            this.textDaySupplierStockZai = new DataDynamics.ActiveReports.TextBox();
            this.textBox87 = new DataDynamics.ActiveReports.TextBox();
            this.textBox88 = new DataDynamics.ActiveReports.TextBox();
            this.textBox89 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSupplierStockZai = new DataDynamics.ActiveReports.TextBox();
            this.textBox91 = new DataDynamics.ActiveReports.TextBox();
            this.textBox92 = new DataDynamics.ActiveReports.TextBox();
            this.textBox93 = new DataDynamics.ActiveReports.TextBox();
            this.textDaySupplierStockTori = new DataDynamics.ActiveReports.TextBox();
            this.textBox95 = new DataDynamics.ActiveReports.TextBox();
            this.textBox96 = new DataDynamics.ActiveReports.TextBox();
            this.textBox97 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSupplierStockTori = new DataDynamics.ActiveReports.TextBox();
            this.textBox99 = new DataDynamics.ActiveReports.TextBox();
            this.textBox100 = new DataDynamics.ActiveReports.TextBox();
            this.textBox101 = new DataDynamics.ActiveReports.TextBox();
            this.textDaySupplierStockGou = new DataDynamics.ActiveReports.TextBox();
            this.textBox103 = new DataDynamics.ActiveReports.TextBox();
            this.textBox104 = new DataDynamics.ActiveReports.TextBox();
            this.textBox105 = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSupplierStockGou = new DataDynamics.ActiveReports.TextBox();
            this.label33 = new DataDynamics.ActiveReports.Label();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.textDaySupplierToriRate = new DataDynamics.ActiveReports.TextBox();
            this.textDaySupplierZaiRate = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSupplierZaiRate = new DataDynamics.ActiveReports.TextBox();
            this.textMonthSupplierToriRate = new DataDynamics.ActiveReports.TextBox();
            this.label39 = new DataDynamics.ActiveReports.Label();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.DailyHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DailyFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotalTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotalZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckToriRatioMonthTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckZaiRatioMonthTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckZaiRatioDayTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckToriRatioDayTotalGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_KindTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ZaikoHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ToriyoseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoukeiHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_KindTitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StckPriceDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayTotalStockZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthTotalStockZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayTotalStockTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthTotalStockTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayTotalStockGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthTotalStockGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayGoukeiToriRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayGoukeiZaiRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthGoukeiZaiRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthGoukeiToriRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MainSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StckPriceDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionStockZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionStockTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionStockGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionStockZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionStockTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionStockGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionToriRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionZaiRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionZaiRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionToriRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_StckPriceDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierStockZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierStockZai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierStockTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierStockTori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierStockGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierStockGou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierToriRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierZaiRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierZaiRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierToriRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DetailLineName,
            this.TextBox,
            this.TextBox1,
            this.StckPriceDayTotalZai,
            this.DetailLine,
            this.RetGdsDayTotalZai,
            this.DisDayTotalZai,
            this.NetStcPrcDayTotalZai,
            this.StckPriceDayTotalTori,
            this.RetGdsDayTotalTori,
            this.DisDayTotalTori,
            this.NetStcPrcDayTotalTori,
            this.StckPriceDayTotalGou,
            this.RetGdsDayTotalGou,
            this.DisDayTotalGou,
            this.NetStcPrcDayTotalGou,
            this.label21,
            this.label22,
            this.label23,
            this.label16,
            this.StckPriceMonthTotalGou,
            this.RetGdsMonthTotalGou,
            this.DisDayMonthTotalGou,
            this.NetStcPrcMonthTotalGou,
            this.StckPriceMonthTotalTori,
            this.RetGdsMonthTotalTori,
            this.DisDayMonthTotalTori,
            this.NetStcPrcMonthTotalTori,
            this.StckPriceMonthTotalZai,
            this.RetGdsMonthTotalZai,
            this.DisDayMonthTotalZai,
            this.NetStcPrcMonthTotalZai,
            this.StckToriRatioMonthTotalGou,
            this.StckZaiRatioMonthTotalGou,
            this.StckZaiRatioDayTotalGou,
            this.StckToriRatioDayTotalGou,
            this.label38,
            this.label37,
            this.line5});
            this.Detail.Height = 0.375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // DetailLineName
            // 
            this.DetailLineName.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.Border.RightColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.Border.TopColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.DataField = "DetailLineName";
            this.DetailLineName.Height = 0.16F;
            this.DetailLineName.Left = 0.42F;
            this.DetailLineName.MultiLine = false;
            this.DetailLineName.Name = "DetailLineName";
            this.DetailLineName.OutputFormat = resources.GetString("DetailLineName.OutputFormat");
            this.DetailLineName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.DetailLineName.Text = "１２３４５６７８９０";
            this.DetailLineName.Top = 0F;
            this.DetailLineName.Width = 1.15F;
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Height = 0.1574803F;
            this.TextBox.Left = 1.58F;
            this.TextBox.MultiLine = false;
            this.TextBox.Name = "TextBox";
            this.TextBox.OutputFormat = resources.GetString("TextBox.OutputFormat");
            this.TextBox.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox.Text = "日計";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.25F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Height = 0.1574803F;
            this.TextBox1.Left = 1.58F;
            this.TextBox1.MultiLine = false;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox1.Text = "累計";
            this.TextBox1.Top = 0.1875F;
            this.TextBox1.Width = 0.25F;
            // 
            // StckPriceDayTotalZai
            // 
            this.StckPriceDayTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalZai.DataField = "StckPriceDayTotalZai";
            this.StckPriceDayTotalZai.Height = 0.16F;
            this.StckPriceDayTotalZai.Left = 1.84F;
            this.StckPriceDayTotalZai.MultiLine = false;
            this.StckPriceDayTotalZai.Name = "StckPriceDayTotalZai";
            this.StckPriceDayTotalZai.OutputFormat = resources.GetString("StckPriceDayTotalZai.OutputFormat");
            this.StckPriceDayTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceDayTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.StckPriceDayTotalZai.Top = 0F;
            this.StckPriceDayTotalZai.Width = 0.66F;
            // 
            // DetailLine
            // 
            this.DetailLine.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailLine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailLine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.Border.RightColor = System.Drawing.Color.Black;
            this.DetailLine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.Border.TopColor = System.Drawing.Color.Black;
            this.DetailLine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.DataField = "DetailLine";
            this.DetailLine.Height = 0.156F;
            this.DetailLine.Left = 0.02F;
            this.DetailLine.MultiLine = false;
            this.DetailLine.Name = "DetailLine";
            this.DetailLine.OutputFormat = resources.GetString("DetailLine.OutputFormat");
            this.DetailLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.DetailLine.Text = "123456";
            this.DetailLine.Top = 0F;
            this.DetailLine.Width = 0.375F;
            // 
            // RetGdsDayTotalZai
            // 
            this.RetGdsDayTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalZai.DataField = "RetGdsDayTotalZai";
            this.RetGdsDayTotalZai.Height = 0.16F;
            this.RetGdsDayTotalZai.Left = 2.53F;
            this.RetGdsDayTotalZai.MultiLine = false;
            this.RetGdsDayTotalZai.Name = "RetGdsDayTotalZai";
            this.RetGdsDayTotalZai.OutputFormat = resources.GetString("RetGdsDayTotalZai.OutputFormat");
            this.RetGdsDayTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsDayTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.RetGdsDayTotalZai.Top = 0F;
            this.RetGdsDayTotalZai.Width = 0.66F;
            // 
            // DisDayTotalZai
            // 
            this.DisDayTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalZai.DataField = "DisDayTotalZai";
            this.DisDayTotalZai.Height = 0.16F;
            this.DisDayTotalZai.Left = 3.22F;
            this.DisDayTotalZai.MultiLine = false;
            this.DisDayTotalZai.Name = "DisDayTotalZai";
            this.DisDayTotalZai.OutputFormat = resources.GetString("DisDayTotalZai.OutputFormat");
            this.DisDayTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayTotalZai.Top = 0F;
            this.DisDayTotalZai.Width = 0.66F;
            // 
            // NetStcPrcDayTotalZai
            // 
            this.NetStcPrcDayTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalZai.DataField = "NetStcPrcDayTotalZai";
            this.NetStcPrcDayTotalZai.Height = 0.16F;
            this.NetStcPrcDayTotalZai.Left = 3.91F;
            this.NetStcPrcDayTotalZai.MultiLine = false;
            this.NetStcPrcDayTotalZai.Name = "NetStcPrcDayTotalZai";
            this.NetStcPrcDayTotalZai.OutputFormat = resources.GetString("NetStcPrcDayTotalZai.OutputFormat");
            this.NetStcPrcDayTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.NetStcPrcDayTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.NetStcPrcDayTotalZai.Top = 0F;
            this.NetStcPrcDayTotalZai.Width = 0.66F;
            // 
            // StckPriceDayTotalTori
            // 
            this.StckPriceDayTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalTori.DataField = "StckPriceDayTotalTori";
            this.StckPriceDayTotalTori.Height = 0.16F;
            this.StckPriceDayTotalTori.Left = 4.63F;
            this.StckPriceDayTotalTori.MultiLine = false;
            this.StckPriceDayTotalTori.Name = "StckPriceDayTotalTori";
            this.StckPriceDayTotalTori.OutputFormat = resources.GetString("StckPriceDayTotalTori.OutputFormat");
            this.StckPriceDayTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceDayTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.StckPriceDayTotalTori.Top = 0F;
            this.StckPriceDayTotalTori.Width = 0.66F;
            // 
            // RetGdsDayTotalTori
            // 
            this.RetGdsDayTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalTori.DataField = "RetGdsDayTotalTori";
            this.RetGdsDayTotalTori.Height = 0.16F;
            this.RetGdsDayTotalTori.Left = 5.32F;
            this.RetGdsDayTotalTori.MultiLine = false;
            this.RetGdsDayTotalTori.Name = "RetGdsDayTotalTori";
            this.RetGdsDayTotalTori.OutputFormat = resources.GetString("RetGdsDayTotalTori.OutputFormat");
            this.RetGdsDayTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsDayTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.RetGdsDayTotalTori.Top = 0F;
            this.RetGdsDayTotalTori.Width = 0.66F;
            // 
            // DisDayTotalTori
            // 
            this.DisDayTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalTori.DataField = "DisDayTotalTori";
            this.DisDayTotalTori.Height = 0.16F;
            this.DisDayTotalTori.Left = 6.01F;
            this.DisDayTotalTori.MultiLine = false;
            this.DisDayTotalTori.Name = "DisDayTotalTori";
            this.DisDayTotalTori.OutputFormat = resources.GetString("DisDayTotalTori.OutputFormat");
            this.DisDayTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayTotalTori.Top = 0F;
            this.DisDayTotalTori.Width = 0.66F;
            // 
            // NetStcPrcDayTotalTori
            // 
            this.NetStcPrcDayTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalTori.DataField = "NetStcPrcDayTotalTori";
            this.NetStcPrcDayTotalTori.Height = 0.16F;
            this.NetStcPrcDayTotalTori.Left = 6.7F;
            this.NetStcPrcDayTotalTori.MultiLine = false;
            this.NetStcPrcDayTotalTori.Name = "NetStcPrcDayTotalTori";
            this.NetStcPrcDayTotalTori.OutputFormat = resources.GetString("NetStcPrcDayTotalTori.OutputFormat");
            this.NetStcPrcDayTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.NetStcPrcDayTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.NetStcPrcDayTotalTori.Top = 0F;
            this.NetStcPrcDayTotalTori.Width = 0.66F;
            // 
            // StckPriceDayTotalGou
            // 
            this.StckPriceDayTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceDayTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotalGou.DataField = "StckPriceDayTotalGou";
            this.StckPriceDayTotalGou.Height = 0.16F;
            this.StckPriceDayTotalGou.Left = 7.43F;
            this.StckPriceDayTotalGou.MultiLine = false;
            this.StckPriceDayTotalGou.Name = "StckPriceDayTotalGou";
            this.StckPriceDayTotalGou.OutputFormat = resources.GetString("StckPriceDayTotalGou.OutputFormat");
            this.StckPriceDayTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceDayTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.StckPriceDayTotalGou.Top = 0F;
            this.StckPriceDayTotalGou.Width = 0.66F;
            // 
            // RetGdsDayTotalGou
            // 
            this.RetGdsDayTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsDayTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotalGou.DataField = "RetGdsDayTotalGou";
            this.RetGdsDayTotalGou.Height = 0.16F;
            this.RetGdsDayTotalGou.Left = 8.12F;
            this.RetGdsDayTotalGou.MultiLine = false;
            this.RetGdsDayTotalGou.Name = "RetGdsDayTotalGou";
            this.RetGdsDayTotalGou.OutputFormat = resources.GetString("RetGdsDayTotalGou.OutputFormat");
            this.RetGdsDayTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsDayTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.RetGdsDayTotalGou.Top = 0F;
            this.RetGdsDayTotalGou.Width = 0.66F;
            // 
            // DisDayTotalGou
            // 
            this.DisDayTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotalGou.DataField = "DisDayTotalGou";
            this.DisDayTotalGou.Height = 0.16F;
            this.DisDayTotalGou.Left = 8.81F;
            this.DisDayTotalGou.MultiLine = false;
            this.DisDayTotalGou.Name = "DisDayTotalGou";
            this.DisDayTotalGou.OutputFormat = resources.GetString("DisDayTotalGou.OutputFormat");
            this.DisDayTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayTotalGou.Top = 0F;
            this.DisDayTotalGou.Width = 0.66F;
            // 
            // NetStcPrcDayTotalGou
            // 
            this.NetStcPrcDayTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotalGou.DataField = "NetStcPrcDayTotalGou";
            this.NetStcPrcDayTotalGou.Height = 0.16F;
            this.NetStcPrcDayTotalGou.Left = 9.5F;
            this.NetStcPrcDayTotalGou.MultiLine = false;
            this.NetStcPrcDayTotalGou.Name = "NetStcPrcDayTotalGou";
            this.NetStcPrcDayTotalGou.OutputFormat = resources.GetString("NetStcPrcDayTotalGou.OutputFormat");
            this.NetStcPrcDayTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.NetStcPrcDayTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.NetStcPrcDayTotalGou.Top = 0F;
            this.NetStcPrcDayTotalGou.Width = 0.66F;
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
            this.label21.Height = 0.16F;
            this.label21.HyperLink = "";
            this.label21.Left = 4.56F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label21.Text = "|";
            this.label21.Top = 0F;
            this.label21.Width = 0.07F;
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
            this.label22.Height = 0.16F;
            this.label22.HyperLink = "";
            this.label22.Left = 4.56F;
            this.label22.MultiLine = false;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label22.Text = "|";
            this.label22.Top = 0.1875F;
            this.label22.Width = 0.07F;
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
            this.label23.Height = 0.16F;
            this.label23.HyperLink = "";
            this.label23.Left = 7.36F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label23.Text = "|";
            this.label23.Top = 0F;
            this.label23.Width = 0.07F;
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
            this.label16.Height = 0.16F;
            this.label16.HyperLink = "";
            this.label16.Left = 7.36F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "|";
            this.label16.Top = 0.1875F;
            this.label16.Width = 0.07F;
            // 
            // StckPriceMonthTotalGou
            // 
            this.StckPriceMonthTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalGou.DataField = "StckPriceMonthTotalGou";
            this.StckPriceMonthTotalGou.Height = 0.16F;
            this.StckPriceMonthTotalGou.Left = 7.43F;
            this.StckPriceMonthTotalGou.MultiLine = false;
            this.StckPriceMonthTotalGou.Name = "StckPriceMonthTotalGou";
            this.StckPriceMonthTotalGou.OutputFormat = resources.GetString("StckPriceMonthTotalGou.OutputFormat");
            this.StckPriceMonthTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceMonthTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.StckPriceMonthTotalGou.Top = 0.1875F;
            this.StckPriceMonthTotalGou.Width = 0.66F;
            // 
            // RetGdsMonthTotalGou
            // 
            this.RetGdsMonthTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalGou.DataField = "RetGdsMonthTotalGou";
            this.RetGdsMonthTotalGou.Height = 0.16F;
            this.RetGdsMonthTotalGou.Left = 8.12F;
            this.RetGdsMonthTotalGou.MultiLine = false;
            this.RetGdsMonthTotalGou.Name = "RetGdsMonthTotalGou";
            this.RetGdsMonthTotalGou.OutputFormat = resources.GetString("RetGdsMonthTotalGou.OutputFormat");
            this.RetGdsMonthTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsMonthTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.RetGdsMonthTotalGou.Top = 0.1875F;
            this.RetGdsMonthTotalGou.Width = 0.66F;
            // 
            // DisDayMonthTotalGou
            // 
            this.DisDayMonthTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalGou.DataField = "DisDayMonthTotalGou";
            this.DisDayMonthTotalGou.Height = 0.16F;
            this.DisDayMonthTotalGou.Left = 8.81F;
            this.DisDayMonthTotalGou.MultiLine = false;
            this.DisDayMonthTotalGou.Name = "DisDayMonthTotalGou";
            this.DisDayMonthTotalGou.OutputFormat = resources.GetString("DisDayMonthTotalGou.OutputFormat");
            this.DisDayMonthTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayMonthTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayMonthTotalGou.Top = 0.1875F;
            this.DisDayMonthTotalGou.Width = 0.66F;
            // 
            // NetStcPrcMonthTotalGou
            // 
            this.NetStcPrcMonthTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalGou.DataField = "NetStcPrcMonthTotalGou";
            this.NetStcPrcMonthTotalGou.Height = 0.16F;
            this.NetStcPrcMonthTotalGou.Left = 9.5F;
            this.NetStcPrcMonthTotalGou.MultiLine = false;
            this.NetStcPrcMonthTotalGou.Name = "NetStcPrcMonthTotalGou";
            this.NetStcPrcMonthTotalGou.OutputFormat = resources.GetString("NetStcPrcMonthTotalGou.OutputFormat");
            this.NetStcPrcMonthTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.NetStcPrcMonthTotalGou.Text = "ZZZ,ZZZ,ZZ9";
            this.NetStcPrcMonthTotalGou.Top = 0.1875F;
            this.NetStcPrcMonthTotalGou.Width = 0.66F;
            // 
            // StckPriceMonthTotalTori
            // 
            this.StckPriceMonthTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalTori.DataField = "StckPriceMonthTotalTori";
            this.StckPriceMonthTotalTori.Height = 0.16F;
            this.StckPriceMonthTotalTori.Left = 4.63F;
            this.StckPriceMonthTotalTori.MultiLine = false;
            this.StckPriceMonthTotalTori.Name = "StckPriceMonthTotalTori";
            this.StckPriceMonthTotalTori.OutputFormat = resources.GetString("StckPriceMonthTotalTori.OutputFormat");
            this.StckPriceMonthTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceMonthTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.StckPriceMonthTotalTori.Top = 0.1875F;
            this.StckPriceMonthTotalTori.Width = 0.66F;
            // 
            // RetGdsMonthTotalTori
            // 
            this.RetGdsMonthTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalTori.DataField = "RetGdsMonthTotalTori";
            this.RetGdsMonthTotalTori.Height = 0.16F;
            this.RetGdsMonthTotalTori.Left = 5.32F;
            this.RetGdsMonthTotalTori.MultiLine = false;
            this.RetGdsMonthTotalTori.Name = "RetGdsMonthTotalTori";
            this.RetGdsMonthTotalTori.OutputFormat = resources.GetString("RetGdsMonthTotalTori.OutputFormat");
            this.RetGdsMonthTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsMonthTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.RetGdsMonthTotalTori.Top = 0.1875F;
            this.RetGdsMonthTotalTori.Width = 0.66F;
            // 
            // DisDayMonthTotalTori
            // 
            this.DisDayMonthTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalTori.DataField = "DisDayMonthTotalTori";
            this.DisDayMonthTotalTori.Height = 0.16F;
            this.DisDayMonthTotalTori.Left = 6.01F;
            this.DisDayMonthTotalTori.MultiLine = false;
            this.DisDayMonthTotalTori.Name = "DisDayMonthTotalTori";
            this.DisDayMonthTotalTori.OutputFormat = resources.GetString("DisDayMonthTotalTori.OutputFormat");
            this.DisDayMonthTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayMonthTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayMonthTotalTori.Top = 0.1875F;
            this.DisDayMonthTotalTori.Width = 0.66F;
            // 
            // NetStcPrcMonthTotalTori
            // 
            this.NetStcPrcMonthTotalTori.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalTori.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalTori.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalTori.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalTori.DataField = "NetStcPrcMonthTotalTori";
            this.NetStcPrcMonthTotalTori.Height = 0.16F;
            this.NetStcPrcMonthTotalTori.Left = 6.7F;
            this.NetStcPrcMonthTotalTori.MultiLine = false;
            this.NetStcPrcMonthTotalTori.Name = "NetStcPrcMonthTotalTori";
            this.NetStcPrcMonthTotalTori.OutputFormat = resources.GetString("NetStcPrcMonthTotalTori.OutputFormat");
            this.NetStcPrcMonthTotalTori.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.NetStcPrcMonthTotalTori.Text = "ZZZ,ZZZ,ZZ9";
            this.NetStcPrcMonthTotalTori.Top = 0.1875F;
            this.NetStcPrcMonthTotalTori.Width = 0.66F;
            // 
            // StckPriceMonthTotalZai
            // 
            this.StckPriceMonthTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotalZai.DataField = "StckPriceMonthTotalZai";
            this.StckPriceMonthTotalZai.Height = 0.16F;
            this.StckPriceMonthTotalZai.Left = 1.84F;
            this.StckPriceMonthTotalZai.MultiLine = false;
            this.StckPriceMonthTotalZai.Name = "StckPriceMonthTotalZai";
            this.StckPriceMonthTotalZai.OutputFormat = resources.GetString("StckPriceMonthTotalZai.OutputFormat");
            this.StckPriceMonthTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceMonthTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.StckPriceMonthTotalZai.Top = 0.1875F;
            this.StckPriceMonthTotalZai.Width = 0.66F;
            // 
            // RetGdsMonthTotalZai
            // 
            this.RetGdsMonthTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotalZai.DataField = "RetGdsMonthTotalZai";
            this.RetGdsMonthTotalZai.Height = 0.16F;
            this.RetGdsMonthTotalZai.Left = 2.53F;
            this.RetGdsMonthTotalZai.MultiLine = false;
            this.RetGdsMonthTotalZai.Name = "RetGdsMonthTotalZai";
            this.RetGdsMonthTotalZai.OutputFormat = resources.GetString("RetGdsMonthTotalZai.OutputFormat");
            this.RetGdsMonthTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsMonthTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.RetGdsMonthTotalZai.Top = 0.1875F;
            this.RetGdsMonthTotalZai.Width = 0.66F;
            // 
            // DisDayMonthTotalZai
            // 
            this.DisDayMonthTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayMonthTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotalZai.DataField = "DisDayMonthTotalZai";
            this.DisDayMonthTotalZai.Height = 0.16F;
            this.DisDayMonthTotalZai.Left = 3.22F;
            this.DisDayMonthTotalZai.MultiLine = false;
            this.DisDayMonthTotalZai.Name = "DisDayMonthTotalZai";
            this.DisDayMonthTotalZai.OutputFormat = resources.GetString("DisDayMonthTotalZai.OutputFormat");
            this.DisDayMonthTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayMonthTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayMonthTotalZai.Top = 0.1875F;
            this.DisDayMonthTotalZai.Width = 0.66F;
            // 
            // NetStcPrcMonthTotalZai
            // 
            this.NetStcPrcMonthTotalZai.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalZai.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalZai.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalZai.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotalZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotalZai.DataField = "NetStcPrcMonthTotalZai";
            this.NetStcPrcMonthTotalZai.Height = 0.16F;
            this.NetStcPrcMonthTotalZai.Left = 3.91F;
            this.NetStcPrcMonthTotalZai.MultiLine = false;
            this.NetStcPrcMonthTotalZai.Name = "NetStcPrcMonthTotalZai";
            this.NetStcPrcMonthTotalZai.OutputFormat = resources.GetString("NetStcPrcMonthTotalZai.OutputFormat");
            this.NetStcPrcMonthTotalZai.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.NetStcPrcMonthTotalZai.Text = "ZZZ,ZZZ,ZZ9";
            this.NetStcPrcMonthTotalZai.Top = 0.1875F;
            this.NetStcPrcMonthTotalZai.Width = 0.66F;
            // 
            // StckToriRatioMonthTotalGou
            // 
            this.StckToriRatioMonthTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.StckToriRatioMonthTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioMonthTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.StckToriRatioMonthTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioMonthTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.StckToriRatioMonthTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioMonthTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.StckToriRatioMonthTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioMonthTotalGou.DataField = "StckToriRatioMonthTotalGou";
            this.StckToriRatioMonthTotalGou.Height = 0.16F;
            this.StckToriRatioMonthTotalGou.Left = 10.62F;
            this.StckToriRatioMonthTotalGou.MultiLine = false;
            this.StckToriRatioMonthTotalGou.Name = "StckToriRatioMonthTotalGou";
            this.StckToriRatioMonthTotalGou.OutputFormat = resources.GetString("StckToriRatioMonthTotalGou.OutputFormat");
            this.StckToriRatioMonthTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckToriRatioMonthTotalGou.Text = "100.00";
            this.StckToriRatioMonthTotalGou.Top = 0.1875F;
            this.StckToriRatioMonthTotalGou.Width = 0.37F;
            // 
            // StckZaiRatioMonthTotalGou
            // 
            this.StckZaiRatioMonthTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.StckZaiRatioMonthTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioMonthTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.StckZaiRatioMonthTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioMonthTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.StckZaiRatioMonthTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioMonthTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.StckZaiRatioMonthTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioMonthTotalGou.DataField = "StckZaiRatioMonthTotalGou";
            this.StckZaiRatioMonthTotalGou.Height = 0.16F;
            this.StckZaiRatioMonthTotalGou.Left = 10.19F;
            this.StckZaiRatioMonthTotalGou.MultiLine = false;
            this.StckZaiRatioMonthTotalGou.Name = "StckZaiRatioMonthTotalGou";
            this.StckZaiRatioMonthTotalGou.OutputFormat = resources.GetString("StckZaiRatioMonthTotalGou.OutputFormat");
            this.StckZaiRatioMonthTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckZaiRatioMonthTotalGou.Text = "100.00";
            this.StckZaiRatioMonthTotalGou.Top = 0.1875F;
            this.StckZaiRatioMonthTotalGou.Width = 0.37F;
            // 
            // StckZaiRatioDayTotalGou
            // 
            this.StckZaiRatioDayTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.StckZaiRatioDayTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioDayTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.StckZaiRatioDayTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioDayTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.StckZaiRatioDayTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioDayTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.StckZaiRatioDayTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckZaiRatioDayTotalGou.DataField = "StckZaiRatioDayTotalGou";
            this.StckZaiRatioDayTotalGou.Height = 0.16F;
            this.StckZaiRatioDayTotalGou.Left = 10.19F;
            this.StckZaiRatioDayTotalGou.MultiLine = false;
            this.StckZaiRatioDayTotalGou.Name = "StckZaiRatioDayTotalGou";
            this.StckZaiRatioDayTotalGou.OutputFormat = resources.GetString("StckZaiRatioDayTotalGou.OutputFormat");
            this.StckZaiRatioDayTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckZaiRatioDayTotalGou.Text = "100.00";
            this.StckZaiRatioDayTotalGou.Top = 0F;
            this.StckZaiRatioDayTotalGou.Width = 0.37F;
            // 
            // StckToriRatioDayTotalGou
            // 
            this.StckToriRatioDayTotalGou.Border.BottomColor = System.Drawing.Color.Black;
            this.StckToriRatioDayTotalGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioDayTotalGou.Border.LeftColor = System.Drawing.Color.Black;
            this.StckToriRatioDayTotalGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioDayTotalGou.Border.RightColor = System.Drawing.Color.Black;
            this.StckToriRatioDayTotalGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioDayTotalGou.Border.TopColor = System.Drawing.Color.Black;
            this.StckToriRatioDayTotalGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckToriRatioDayTotalGou.DataField = "StckToriRatioDayTotalGou";
            this.StckToriRatioDayTotalGou.Height = 0.16F;
            this.StckToriRatioDayTotalGou.Left = 10.62F;
            this.StckToriRatioDayTotalGou.MultiLine = false;
            this.StckToriRatioDayTotalGou.Name = "StckToriRatioDayTotalGou";
            this.StckToriRatioDayTotalGou.OutputFormat = resources.GetString("StckToriRatioDayTotalGou.OutputFormat");
            this.StckToriRatioDayTotalGou.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckToriRatioDayTotalGou.Text = "100.00";
            this.StckToriRatioDayTotalGou.Top = 0F;
            this.StckToriRatioDayTotalGou.Width = 0.37F;
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
            this.label38.Height = 0.16F;
            this.label38.HyperLink = "";
            this.label38.Left = 10.56F;
            this.label38.MultiLine = false;
            this.label38.Name = "label38";
            this.label38.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label38.Text = ":";
            this.label38.Top = 0.1875F;
            this.label38.Width = 0.06F;
            // 
            // label37
            // 
            this.label37.Border.BottomColor = System.Drawing.Color.Black;
            this.label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.LeftColor = System.Drawing.Color.Black;
            this.label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.RightColor = System.Drawing.Color.Black;
            this.label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.TopColor = System.Drawing.Color.Black;
            this.label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Height = 0.16F;
            this.label37.HyperLink = "";
            this.label37.Left = 10.56F;
            this.label37.MultiLine = false;
            this.label37.Name = "label37";
            this.label37.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label37.Text = ":";
            this.label37.Top = 0F;
            this.label37.Width = 0.06F;
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
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.99F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.99F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // SectionGuideNm
            // 
            this.SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm.DataField = "SectionGuideNm";
            this.SectionGuideNm.Height = 0.15625F;
            this.SectionGuideNm.Left = 0.40625F;
            this.SectionGuideNm.MultiLine = false;
            this.SectionGuideNm.Name = "SectionGuideNm";
            this.SectionGuideNm.OutputFormat = resources.GetString("SectionGuideNm.OutputFormat");
            this.SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionGuideNm.Text = "123456789012";
            this.SectionGuideNm.Top = 0F;
            this.SectionGuideNm.Width = 0.71875F;
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.15625F;
            this.SectionCode.Left = 0F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SectionCode.Text = "12";
            this.SectionCode.Top = 0F;
            this.SectionCode.Width = 0.375F;
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
            this.CustomerName.DataField = "SupplierSnm";
            this.CustomerName.Height = 0.15625F;
            this.CustomerName.Left = 0.5625F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OutputFormat = resources.GetString("CustomerName.OutputFormat");
            this.CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerName.Text = "12345678901234567890123456789012";
            this.CustomerName.Top = 0F;
            this.CustomerName.Width = 2.145833F;
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
            this.CustomerCode.DataField = "SupplierCode";
            this.CustomerCode.Height = 0.15625F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CustomerCode.Text = "123456";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Visible = false;
            this.CustomerCode.Width = 0.5416667F;
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
            this.tb_ReportTitle,
            this.SortTitle});
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
            this.Line1.Width = 10.99F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.99F;
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
            this.tb_ReportTitle.Text = "仕入日報月報（拠点別）";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // SortTitle
            // 
            this.SortTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SortTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SortTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SortTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SortTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Height = 0.125F;
            this.SortTitle.Left = 4.75F;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "font-size: 8pt; vertical-align: top; ";
            this.SortTitle.Text = "[拠点 コード順/カナ順]";
            this.SortTitle.Top = 0.06299213F;
            this.SortTitle.Width = 1.722F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport,
            this.PageFooter1,
            this.PageFooter2,
            this.line7});
            this.PageFooter.Height = 0.229F;
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
            this.Footer_SubReport.Width = 10.9375F;
            // 
            // PageFooter1
            // 
            this.PageFooter1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Height = 0.1875F;
            this.PageFooter1.Left = 0F;
            this.PageFooter1.MultiLine = false;
            this.PageFooter1.Name = "PageFooter1";
            this.PageFooter1.OutputFormat = "";
            this.PageFooter1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PageFooter1.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.PageFooter1.Top = 0.01041667F;
            this.PageFooter1.Width = 4F;
            // 
            // PageFooter2
            // 
            this.PageFooter2.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Height = 0.1875F;
            this.PageFooter2.Left = 6.924F;
            this.PageFooter2.MultiLine = false;
            this.PageFooter2.Name = "PageFooter2";
            this.PageFooter2.OutputFormat = "";
            this.PageFooter2.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.PageFooter2.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.PageFooter2.Top = 0.01041667F;
            this.PageFooter2.Width = 4F;
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
            this.line7.Width = 10.93F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.93F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
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
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Lb_KindTitle,
            this.Line42,
            this.Lb_ZaikoHeader,
            this.Label4,
            this.Label7,
            this.Label8,
            this.line3,
            this.Lb_ToriyoseHeader,
            this.label5,
            this.label6,
            this.label9,
            this.label10,
            this.Lb_GoukeiHeader,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.label17,
            this.label18,
            this.label19,
            this.label20,
            this.label1,
            this.label29,
            this.Lb_KindTitle2});
            this.TitleHeader.Height = 0.447F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_KindTitle
            // 
            this.Lb_KindTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_KindTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_KindTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_KindTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_KindTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle.Height = 0.156F;
            this.Lb_KindTitle.HyperLink = "";
            this.Lb_KindTitle.Left = 0.02F;
            this.Lb_KindTitle.MultiLine = false;
            this.Lb_KindTitle.Name = "Lb_KindTitle";
            this.Lb_KindTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_KindTitle.Text = "仕入先";
            this.Lb_KindTitle.Top = 0.25F;
            this.Lb_KindTitle.Width = 0.438F;
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
            this.Line42.Width = 10.99F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.99F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // Lb_ZaikoHeader
            // 
            this.Lb_ZaikoHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ZaikoHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ZaikoHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ZaikoHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ZaikoHeader.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ZaikoHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ZaikoHeader.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ZaikoHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ZaikoHeader.Height = 0.1875F;
            this.Lb_ZaikoHeader.HyperLink = "";
            this.Lb_ZaikoHeader.Left = 1.83F;
            this.Lb_ZaikoHeader.MultiLine = false;
            this.Lb_ZaikoHeader.Name = "Lb_ZaikoHeader";
            this.Lb_ZaikoHeader.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ZaikoHeader.Text = "<==============　　在　　庫　　==============>";
            this.Lb_ZaikoHeader.Top = 0.0625F;
            this.Lb_ZaikoHeader.Width = 2.73F;
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
            this.Label4.Left = 3.91F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label4.Text = "純仕入";
            this.Label4.Top = 0.25F;
            this.Label4.Width = 0.66F;
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
            this.Label7.Height = 0.15625F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 1.84F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label7.Text = "仕入";
            this.Label7.Top = 0.25F;
            this.Label7.Width = 0.66F;
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
            this.Label8.Height = 0.15625F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 2.53F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label8.Text = "返品";
            this.Label8.Top = 0.25F;
            this.Label8.Width = 0.66F;
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
            this.line3.Top = 0.4375F;
            this.line3.Visible = false;
            this.line3.Width = 10.99F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.99F;
            this.line3.Y1 = 0.4375F;
            this.line3.Y2 = 0.4375F;
            // 
            // Lb_ToriyoseHeader
            // 
            this.Lb_ToriyoseHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ToriyoseHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ToriyoseHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ToriyoseHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ToriyoseHeader.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ToriyoseHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ToriyoseHeader.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ToriyoseHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ToriyoseHeader.Height = 0.1875F;
            this.Lb_ToriyoseHeader.HyperLink = "";
            this.Lb_ToriyoseHeader.Left = 4.63F;
            this.Lb_ToriyoseHeader.MultiLine = false;
            this.Lb_ToriyoseHeader.Name = "Lb_ToriyoseHeader";
            this.Lb_ToriyoseHeader.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ToriyoseHeader.Text = "<==============　　取　　寄　　==============>";
            this.Lb_ToriyoseHeader.Top = 0.0625F;
            this.Lb_ToriyoseHeader.Width = 2.73F;
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
            this.label5.Height = 0.15625F;
            this.label5.HyperLink = "";
            this.label5.Left = 6.7F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "純仕入";
            this.label5.Top = 0.25F;
            this.label5.Width = 0.66F;
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
            this.label6.Height = 0.15625F;
            this.label6.HyperLink = "";
            this.label6.Left = 6.01F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "値引";
            this.label6.Top = 0.25F;
            this.label6.Width = 0.66F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.15625F;
            this.label9.HyperLink = "";
            this.label9.Left = 4.63F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "仕入";
            this.label9.Top = 0.25F;
            this.label9.Width = 0.66F;
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
            this.label10.Height = 0.15625F;
            this.label10.HyperLink = "";
            this.label10.Left = 5.32F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "返品";
            this.label10.Top = 0.25F;
            this.label10.Width = 0.66F;
            // 
            // Lb_GoukeiHeader
            // 
            this.Lb_GoukeiHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoukeiHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoukeiHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoukeiHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoukeiHeader.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoukeiHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoukeiHeader.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoukeiHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoukeiHeader.Height = 0.1875F;
            this.Lb_GoukeiHeader.HyperLink = "";
            this.Lb_GoukeiHeader.Left = 7.43F;
            this.Lb_GoukeiHeader.MultiLine = false;
            this.Lb_GoukeiHeader.Name = "Lb_GoukeiHeader";
            this.Lb_GoukeiHeader.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoukeiHeader.Text = "<=====================　　合　　計　　=====================>";
            this.Lb_GoukeiHeader.Top = 0.0625F;
            this.Lb_GoukeiHeader.Width = 3.56F;
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
            this.label12.Height = 0.15625F;
            this.label12.HyperLink = "";
            this.label12.Left = 9.5F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "純仕入";
            this.label12.Top = 0.25F;
            this.label12.Width = 0.66F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.15625F;
            this.label13.HyperLink = "";
            this.label13.Left = 8.81F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "値引";
            this.label13.Top = 0.25F;
            this.label13.Width = 0.66F;
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
            this.label14.Height = 0.15625F;
            this.label14.HyperLink = "";
            this.label14.Left = 7.43F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "仕入";
            this.label14.Top = 0.25F;
            this.label14.Width = 0.66F;
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
            this.label15.Height = 0.15625F;
            this.label15.HyperLink = "";
            this.label15.Left = 8.12F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "返品";
            this.label15.Top = 0.25F;
            this.label15.Width = 0.66F;
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
            this.label17.Height = 0.16F;
            this.label17.HyperLink = "";
            this.label17.Left = 4.56F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "|";
            this.label17.Top = 0.0625F;
            this.label17.Width = 0.07F;
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
            this.label18.Height = 0.16F;
            this.label18.HyperLink = "";
            this.label18.Left = 4.56F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "|";
            this.label18.Top = 0.25F;
            this.label18.Width = 0.07F;
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
            this.label19.Height = 0.16F;
            this.label19.HyperLink = "";
            this.label19.Left = 7.36F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "|";
            this.label19.Top = 0.0625F;
            this.label19.Width = 0.07F;
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
            this.label20.Height = 0.16F;
            this.label20.HyperLink = "";
            this.label20.Left = 7.36F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label20.Text = "|";
            this.label20.Top = 0.25F;
            this.label20.Width = 0.07F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.15625F;
            this.label1.HyperLink = "";
            this.label1.Left = 3.22F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "値引";
            this.label1.Top = 0.25F;
            this.label1.Width = 0.66F;
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
            this.label29.Height = 0.15625F;
            this.label29.HyperLink = "";
            this.label29.Left = 10.19F;
            this.label29.MultiLine = false;
            this.label29.Name = "label29";
            this.label29.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label29.Text = "在取比率";
            this.label29.Top = 0.25F;
            this.label29.Width = 0.8F;
            // 
            // Lb_KindTitle2
            // 
            this.Lb_KindTitle2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_KindTitle2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_KindTitle2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_KindTitle2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_KindTitle2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_KindTitle2.Height = 0.156F;
            this.Lb_KindTitle2.HyperLink = "";
            this.Lb_KindTitle2.Left = 0F;
            this.Lb_KindTitle2.MultiLine = false;
            this.Lb_KindTitle2.Name = "Lb_KindTitle2";
            this.Lb_KindTitle2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_KindTitle2.Text = "拠点";
            this.Lb_KindTitle2.Top = 0.0625F;
            this.Lb_KindTitle2.Width = 0.438F;
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
            this.Line43,
            this.TextBox19,
            this.TextBox20,
            this.g_StckPriceDayTotal,
            this.textBox34,
            this.textBox35,
            this.textDayTotalStockZai,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textMonthTotalStockZai,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textDayTotalStockTori,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textMonthTotalStockTori,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textDayTotalStockGou,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textMonthTotalStockGou,
            this.label25,
            this.label26,
            this.label27,
            this.label24,
            this.textDayGoukeiToriRate,
            this.textDayGoukeiZaiRate,
            this.textMonthGoukeiZaiRate,
            this.textMonthGoukeiToriRate,
            this.label43,
            this.label44});
            this.GrandTotalFooter.Height = 0.4159722F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.ALLTOTALTITLE.Height = 0.219F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 0.875F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03125F;
            this.ALLTOTALTITLE.Width = 0.65F;
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
            this.Line43.Width = 10.99F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.99F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // TextBox19
            // 
            this.TextBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Height = 0.1574803F;
            this.TextBox19.Left = 1.58F;
            this.TextBox19.MultiLine = false;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox19.Text = "日計";
            this.TextBox19.Top = 0.03125F;
            this.TextBox19.Width = 0.26F;
            // 
            // TextBox20
            // 
            this.TextBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Height = 0.1574803F;
            this.TextBox20.Left = 1.58F;
            this.TextBox20.MultiLine = false;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox20.Text = "累計";
            this.TextBox20.Top = 0.21875F;
            this.TextBox20.Width = 0.26F;
            // 
            // g_StckPriceDayTotal
            // 
            this.g_StckPriceDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StckPriceDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StckPriceDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StckPriceDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StckPriceDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.g_StckPriceDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StckPriceDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.g_StckPriceDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StckPriceDayTotal.DataField = "StckPriceDayTotalZai";
            this.g_StckPriceDayTotal.Height = 0.1574803F;
            this.g_StckPriceDayTotal.Left = 1.84F;
            this.g_StckPriceDayTotal.MultiLine = false;
            this.g_StckPriceDayTotal.Name = "g_StckPriceDayTotal";
            this.g_StckPriceDayTotal.OutputFormat = resources.GetString("g_StckPriceDayTotal.OutputFormat");
            this.g_StckPriceDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StckPriceDayTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StckPriceDayTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StckPriceDayTotal.Text = "ZZZ,ZZZ,ZZ9";
            this.g_StckPriceDayTotal.Top = 0.03125F;
            this.g_StckPriceDayTotal.Width = 0.66F;
            // 
            // textBox34
            // 
            this.textBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.RightColor = System.Drawing.Color.Black;
            this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.TopColor = System.Drawing.Color.Black;
            this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.DataField = "RetGdsDayTotalZai";
            this.textBox34.Height = 0.1574803F;
            this.textBox34.Left = 2.53F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox34.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox34.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox34.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox34.Top = 0.03125F;
            this.textBox34.Width = 0.66F;
            // 
            // textBox35
            // 
            this.textBox35.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.RightColor = System.Drawing.Color.Black;
            this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.TopColor = System.Drawing.Color.Black;
            this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.DataField = "DisDayTotalZai";
            this.textBox35.Height = 0.1574803F;
            this.textBox35.Left = 3.22F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox35.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox35.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox35.Top = 0.03125F;
            this.textBox35.Width = 0.66F;
            // 
            // textDayTotalStockZai
            // 
            this.textDayTotalStockZai.Border.BottomColor = System.Drawing.Color.Black;
            this.textDayTotalStockZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockZai.Border.LeftColor = System.Drawing.Color.Black;
            this.textDayTotalStockZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockZai.Border.RightColor = System.Drawing.Color.Black;
            this.textDayTotalStockZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockZai.Border.TopColor = System.Drawing.Color.Black;
            this.textDayTotalStockZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockZai.DataField = "NetStcPrcDayTotalZai";
            this.textDayTotalStockZai.Height = 0.1574803F;
            this.textDayTotalStockZai.Left = 3.91F;
            this.textDayTotalStockZai.MultiLine = false;
            this.textDayTotalStockZai.Name = "textDayTotalStockZai";
            this.textDayTotalStockZai.OutputFormat = resources.GetString("textDayTotalStockZai.OutputFormat");
            this.textDayTotalStockZai.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDayTotalStockZai.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textDayTotalStockZai.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textDayTotalStockZai.Text = "ZZZ,ZZZ,ZZ9";
            this.textDayTotalStockZai.Top = 0.03125F;
            this.textDayTotalStockZai.Width = 0.66F;
            // 
            // textBox37
            // 
            this.textBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.RightColor = System.Drawing.Color.Black;
            this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.TopColor = System.Drawing.Color.Black;
            this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.DataField = "StckPriceMonthTotalZai";
            this.textBox37.Height = 0.1574803F;
            this.textBox37.Left = 1.84F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox37.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox37.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox37.Top = 0.21875F;
            this.textBox37.Width = 0.66F;
            // 
            // textBox38
            // 
            this.textBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.RightColor = System.Drawing.Color.Black;
            this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.TopColor = System.Drawing.Color.Black;
            this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.DataField = "RetGdsMonthTotalZai";
            this.textBox38.Height = 0.1574803F;
            this.textBox38.Left = 2.53F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox38.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox38.Top = 0.21875F;
            this.textBox38.Width = 0.66F;
            // 
            // textBox39
            // 
            this.textBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.RightColor = System.Drawing.Color.Black;
            this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.TopColor = System.Drawing.Color.Black;
            this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.DataField = "DisDayMonthTotalZai";
            this.textBox39.Height = 0.1574803F;
            this.textBox39.Left = 3.22F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox39.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox39.Top = 0.21875F;
            this.textBox39.Width = 0.66F;
            // 
            // textMonthTotalStockZai
            // 
            this.textMonthTotalStockZai.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthTotalStockZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockZai.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthTotalStockZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockZai.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthTotalStockZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockZai.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthTotalStockZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockZai.DataField = "NetStcPrcMonthTotalZai";
            this.textMonthTotalStockZai.Height = 0.1574803F;
            this.textMonthTotalStockZai.Left = 3.91F;
            this.textMonthTotalStockZai.MultiLine = false;
            this.textMonthTotalStockZai.Name = "textMonthTotalStockZai";
            this.textMonthTotalStockZai.OutputFormat = resources.GetString("textMonthTotalStockZai.OutputFormat");
            this.textMonthTotalStockZai.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthTotalStockZai.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textMonthTotalStockZai.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textMonthTotalStockZai.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthTotalStockZai.Top = 0.21875F;
            this.textMonthTotalStockZai.Width = 0.66F;
            // 
            // textBox41
            // 
            this.textBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.RightColor = System.Drawing.Color.Black;
            this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.TopColor = System.Drawing.Color.Black;
            this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.DataField = "StckPriceDayTotalTori";
            this.textBox41.Height = 0.1574803F;
            this.textBox41.Left = 4.63F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox41.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox41.Top = 0.03125F;
            this.textBox41.Width = 0.66F;
            // 
            // textBox42
            // 
            this.textBox42.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.RightColor = System.Drawing.Color.Black;
            this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.TopColor = System.Drawing.Color.Black;
            this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.DataField = "RetGdsDayTotalTori";
            this.textBox42.Height = 0.1574803F;
            this.textBox42.Left = 5.32F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox42.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox42.Top = 0.03125F;
            this.textBox42.Width = 0.66F;
            // 
            // textBox43
            // 
            this.textBox43.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.RightColor = System.Drawing.Color.Black;
            this.textBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.TopColor = System.Drawing.Color.Black;
            this.textBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.DataField = "DisDayTotalTori";
            this.textBox43.Height = 0.1574803F;
            this.textBox43.Left = 6.01F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox43.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox43.Top = 0.03125F;
            this.textBox43.Width = 0.66F;
            // 
            // textDayTotalStockTori
            // 
            this.textDayTotalStockTori.Border.BottomColor = System.Drawing.Color.Black;
            this.textDayTotalStockTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockTori.Border.LeftColor = System.Drawing.Color.Black;
            this.textDayTotalStockTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockTori.Border.RightColor = System.Drawing.Color.Black;
            this.textDayTotalStockTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockTori.Border.TopColor = System.Drawing.Color.Black;
            this.textDayTotalStockTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockTori.DataField = "NetStcPrcDayTotalTori";
            this.textDayTotalStockTori.Height = 0.1574803F;
            this.textDayTotalStockTori.Left = 6.7F;
            this.textDayTotalStockTori.MultiLine = false;
            this.textDayTotalStockTori.Name = "textDayTotalStockTori";
            this.textDayTotalStockTori.OutputFormat = resources.GetString("textDayTotalStockTori.OutputFormat");
            this.textDayTotalStockTori.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDayTotalStockTori.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textDayTotalStockTori.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textDayTotalStockTori.Text = "ZZZ,ZZZ,ZZ9";
            this.textDayTotalStockTori.Top = 0.03125F;
            this.textDayTotalStockTori.Width = 0.66F;
            // 
            // textBox45
            // 
            this.textBox45.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.Border.RightColor = System.Drawing.Color.Black;
            this.textBox45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.Border.TopColor = System.Drawing.Color.Black;
            this.textBox45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.DataField = "StckPriceMonthTotalTori";
            this.textBox45.Height = 0.1574803F;
            this.textBox45.Left = 4.63F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox45.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox45.Top = 0.21875F;
            this.textBox45.Width = 0.66F;
            // 
            // textBox46
            // 
            this.textBox46.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.RightColor = System.Drawing.Color.Black;
            this.textBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.TopColor = System.Drawing.Color.Black;
            this.textBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.DataField = "RetGdsMonthTotalTori";
            this.textBox46.Height = 0.1574803F;
            this.textBox46.Left = 5.32F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox46.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox46.Top = 0.21875F;
            this.textBox46.Width = 0.66F;
            // 
            // textBox47
            // 
            this.textBox47.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.Border.RightColor = System.Drawing.Color.Black;
            this.textBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.Border.TopColor = System.Drawing.Color.Black;
            this.textBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.DataField = "DisDayMonthTotalTori";
            this.textBox47.Height = 0.1574803F;
            this.textBox47.Left = 6.01F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox47.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox47.Top = 0.21875F;
            this.textBox47.Width = 0.66F;
            // 
            // textMonthTotalStockTori
            // 
            this.textMonthTotalStockTori.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthTotalStockTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockTori.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthTotalStockTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockTori.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthTotalStockTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockTori.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthTotalStockTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockTori.DataField = "NetStcPrcMonthTotalTori";
            this.textMonthTotalStockTori.Height = 0.1574803F;
            this.textMonthTotalStockTori.Left = 6.7F;
            this.textMonthTotalStockTori.MultiLine = false;
            this.textMonthTotalStockTori.Name = "textMonthTotalStockTori";
            this.textMonthTotalStockTori.OutputFormat = resources.GetString("textMonthTotalStockTori.OutputFormat");
            this.textMonthTotalStockTori.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthTotalStockTori.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textMonthTotalStockTori.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textMonthTotalStockTori.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthTotalStockTori.Top = 0.21875F;
            this.textMonthTotalStockTori.Width = 0.66F;
            // 
            // textBox49
            // 
            this.textBox49.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.Border.RightColor = System.Drawing.Color.Black;
            this.textBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.Border.TopColor = System.Drawing.Color.Black;
            this.textBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.DataField = "StckPriceDayTotalGou";
            this.textBox49.Height = 0.1574803F;
            this.textBox49.Left = 7.43F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox49.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox49.Top = 0.031F;
            this.textBox49.Width = 0.66F;
            // 
            // textBox50
            // 
            this.textBox50.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.Border.RightColor = System.Drawing.Color.Black;
            this.textBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.Border.TopColor = System.Drawing.Color.Black;
            this.textBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.DataField = "RetGdsDayTotalGou";
            this.textBox50.Height = 0.1574803F;
            this.textBox50.Left = 8.12F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox50.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox50.Top = 0.031F;
            this.textBox50.Width = 0.66F;
            // 
            // textBox51
            // 
            this.textBox51.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.Border.RightColor = System.Drawing.Color.Black;
            this.textBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.Border.TopColor = System.Drawing.Color.Black;
            this.textBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.DataField = "DisDayTotalGou";
            this.textBox51.Height = 0.1574803F;
            this.textBox51.Left = 8.81F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox51.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox51.Top = 0.031F;
            this.textBox51.Width = 0.66F;
            // 
            // textDayTotalStockGou
            // 
            this.textDayTotalStockGou.Border.BottomColor = System.Drawing.Color.Black;
            this.textDayTotalStockGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockGou.Border.LeftColor = System.Drawing.Color.Black;
            this.textDayTotalStockGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockGou.Border.RightColor = System.Drawing.Color.Black;
            this.textDayTotalStockGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockGou.Border.TopColor = System.Drawing.Color.Black;
            this.textDayTotalStockGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayTotalStockGou.DataField = "NetStcPrcDayTotalGou";
            this.textDayTotalStockGou.Height = 0.1574803F;
            this.textDayTotalStockGou.Left = 9.5F;
            this.textDayTotalStockGou.MultiLine = false;
            this.textDayTotalStockGou.Name = "textDayTotalStockGou";
            this.textDayTotalStockGou.OutputFormat = resources.GetString("textDayTotalStockGou.OutputFormat");
            this.textDayTotalStockGou.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDayTotalStockGou.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textDayTotalStockGou.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textDayTotalStockGou.Text = "ZZZ,ZZZ,ZZ9";
            this.textDayTotalStockGou.Top = 0.031F;
            this.textDayTotalStockGou.Width = 0.66F;
            // 
            // textBox53
            // 
            this.textBox53.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.Border.RightColor = System.Drawing.Color.Black;
            this.textBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.Border.TopColor = System.Drawing.Color.Black;
            this.textBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.DataField = "StckPriceMonthTotalGou";
            this.textBox53.Height = 0.1574803F;
            this.textBox53.Left = 7.43F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox53.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox53.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox53.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox53.Top = 0.219F;
            this.textBox53.Width = 0.66F;
            // 
            // textBox54
            // 
            this.textBox54.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.RightColor = System.Drawing.Color.Black;
            this.textBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.TopColor = System.Drawing.Color.Black;
            this.textBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.DataField = "RetGdsMonthTotalGou";
            this.textBox54.Height = 0.1574803F;
            this.textBox54.Left = 8.12F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox54.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox54.Top = 0.219F;
            this.textBox54.Width = 0.66F;
            // 
            // textBox55
            // 
            this.textBox55.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.Border.RightColor = System.Drawing.Color.Black;
            this.textBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.Border.TopColor = System.Drawing.Color.Black;
            this.textBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.DataField = "DisDayMonthTotalGou";
            this.textBox55.Height = 0.1574803F;
            this.textBox55.Left = 8.81F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox55.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox55.Top = 0.219F;
            this.textBox55.Width = 0.66F;
            // 
            // textMonthTotalStockGou
            // 
            this.textMonthTotalStockGou.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthTotalStockGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockGou.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthTotalStockGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockGou.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthTotalStockGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockGou.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthTotalStockGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthTotalStockGou.DataField = "NetStcPrcMonthTotalGou";
            this.textMonthTotalStockGou.Height = 0.1574803F;
            this.textMonthTotalStockGou.Left = 9.5F;
            this.textMonthTotalStockGou.MultiLine = false;
            this.textMonthTotalStockGou.Name = "textMonthTotalStockGou";
            this.textMonthTotalStockGou.OutputFormat = resources.GetString("textMonthTotalStockGou.OutputFormat");
            this.textMonthTotalStockGou.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthTotalStockGou.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textMonthTotalStockGou.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textMonthTotalStockGou.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthTotalStockGou.Top = 0.219F;
            this.textMonthTotalStockGou.Width = 0.66F;
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
            this.label25.Height = 0.16F;
            this.label25.HyperLink = "";
            this.label25.Left = 4.56F;
            this.label25.MultiLine = false;
            this.label25.Name = "label25";
            this.label25.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label25.Text = "|";
            this.label25.Top = 0.03125F;
            this.label25.Width = 0.06F;
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
            this.label26.Height = 0.16F;
            this.label26.HyperLink = "";
            this.label26.Left = 4.56F;
            this.label26.MultiLine = false;
            this.label26.Name = "label26";
            this.label26.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label26.Text = "|";
            this.label26.Top = 0.21875F;
            this.label26.Width = 0.06F;
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
            this.label27.Height = 0.16F;
            this.label27.HyperLink = "";
            this.label27.Left = 7.36F;
            this.label27.MultiLine = false;
            this.label27.Name = "label27";
            this.label27.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label27.Text = "|";
            this.label27.Top = 0.03125F;
            this.label27.Width = 0.06F;
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
            this.label24.Height = 0.16F;
            this.label24.HyperLink = "";
            this.label24.Left = 7.36F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label24.Text = "|";
            this.label24.Top = 0.21875F;
            this.label24.Width = 0.06F;
            // 
            // textDayGoukeiToriRate
            // 
            this.textDayGoukeiToriRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textDayGoukeiToriRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiToriRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textDayGoukeiToriRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiToriRate.Border.RightColor = System.Drawing.Color.Black;
            this.textDayGoukeiToriRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiToriRate.Border.TopColor = System.Drawing.Color.Black;
            this.textDayGoukeiToriRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiToriRate.DataField = "StckToriRatioDayTotalGou";
            this.textDayGoukeiToriRate.Height = 0.1574803F;
            this.textDayGoukeiToriRate.Left = 10.62F;
            this.textDayGoukeiToriRate.MultiLine = false;
            this.textDayGoukeiToriRate.Name = "textDayGoukeiToriRate";
            this.textDayGoukeiToriRate.OutputFormat = resources.GetString("textDayGoukeiToriRate.OutputFormat");
            this.textDayGoukeiToriRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDayGoukeiToriRate.Text = "100.00";
            this.textDayGoukeiToriRate.Top = 0.031F;
            this.textDayGoukeiToriRate.Width = 0.37F;
            // 
            // textDayGoukeiZaiRate
            // 
            this.textDayGoukeiZaiRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textDayGoukeiZaiRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiZaiRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textDayGoukeiZaiRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiZaiRate.Border.RightColor = System.Drawing.Color.Black;
            this.textDayGoukeiZaiRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiZaiRate.Border.TopColor = System.Drawing.Color.Black;
            this.textDayGoukeiZaiRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDayGoukeiZaiRate.DataField = "StckZaiRatioDayTotalGou";
            this.textDayGoukeiZaiRate.Height = 0.1574803F;
            this.textDayGoukeiZaiRate.Left = 10.19F;
            this.textDayGoukeiZaiRate.MultiLine = false;
            this.textDayGoukeiZaiRate.Name = "textDayGoukeiZaiRate";
            this.textDayGoukeiZaiRate.OutputFormat = resources.GetString("textDayGoukeiZaiRate.OutputFormat");
            this.textDayGoukeiZaiRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDayGoukeiZaiRate.Text = "100.00";
            this.textDayGoukeiZaiRate.Top = 0.031F;
            this.textDayGoukeiZaiRate.Width = 0.37F;
            // 
            // textMonthGoukeiZaiRate
            // 
            this.textMonthGoukeiZaiRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthGoukeiZaiRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiZaiRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthGoukeiZaiRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiZaiRate.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthGoukeiZaiRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiZaiRate.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthGoukeiZaiRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiZaiRate.DataField = "StckZaiRatioMonthTotalGou";
            this.textMonthGoukeiZaiRate.Height = 0.1574803F;
            this.textMonthGoukeiZaiRate.Left = 10.19F;
            this.textMonthGoukeiZaiRate.MultiLine = false;
            this.textMonthGoukeiZaiRate.Name = "textMonthGoukeiZaiRate";
            this.textMonthGoukeiZaiRate.OutputFormat = resources.GetString("textMonthGoukeiZaiRate.OutputFormat");
            this.textMonthGoukeiZaiRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthGoukeiZaiRate.Text = "100.00";
            this.textMonthGoukeiZaiRate.Top = 0.219F;
            this.textMonthGoukeiZaiRate.Width = 0.37F;
            // 
            // textMonthGoukeiToriRate
            // 
            this.textMonthGoukeiToriRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthGoukeiToriRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiToriRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthGoukeiToriRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiToriRate.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthGoukeiToriRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiToriRate.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthGoukeiToriRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthGoukeiToriRate.DataField = "StckToriRatioMonthTotalGou";
            this.textMonthGoukeiToriRate.Height = 0.1574803F;
            this.textMonthGoukeiToriRate.Left = 10.62F;
            this.textMonthGoukeiToriRate.MultiLine = false;
            this.textMonthGoukeiToriRate.Name = "textMonthGoukeiToriRate";
            this.textMonthGoukeiToriRate.OutputFormat = resources.GetString("textMonthGoukeiToriRate.OutputFormat");
            this.textMonthGoukeiToriRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthGoukeiToriRate.Text = "100.00";
            this.textMonthGoukeiToriRate.Top = 0.219F;
            this.textMonthGoukeiToriRate.Width = 0.37F;
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
            this.label43.Height = 0.16F;
            this.label43.HyperLink = "";
            this.label43.Left = 10.56F;
            this.label43.MultiLine = false;
            this.label43.Name = "label43";
            this.label43.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label43.Text = ":";
            this.label43.Top = 0.219F;
            this.label43.Width = 0.06F;
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
            this.label44.Height = 0.16F;
            this.label44.HyperLink = "";
            this.label44.Left = 10.56F;
            this.label44.MultiLine = false;
            this.label44.Name = "label44";
            this.label44.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label44.Text = ":";
            this.label44.Top = 0.031F;
            this.label44.Width = 0.06F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_MainSectionName,
            this.SectionGuideNm,
            this.SectionCode,
            this.line2});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.1666667F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // tb_MainSectionName
            // 
            this.tb_MainSectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_MainSectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MainSectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_MainSectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MainSectionName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_MainSectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MainSectionName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_MainSectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_MainSectionName.CanShrink = true;
            this.tb_MainSectionName.DataField = "MainSectionName";
            this.tb_MainSectionName.Height = 0.15F;
            this.tb_MainSectionName.Left = 1.197917F;
            this.tb_MainSectionName.MultiLine = false;
            this.tb_MainSectionName.Name = "tb_MainSectionName";
            this.tb_MainSectionName.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_MainSectionName.Text = null;
            this.tb_MainSectionName.Top = 0F;
            this.tb_MainSectionName.Visible = false;
            this.tb_MainSectionName.Width = 0.75F;
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
            this.line2.Width = 10.99F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.99F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.TextBox17,
            this.TextBox18,
            this.s_StckPriceDayTotal,
            this.textBox59,
            this.textDaySectionStockZai,
            this.textBox61,
            this.textBox62,
            this.textBox63,
            this.textDaySectionStockTori,
            this.textBox65,
            this.textBox66,
            this.textBox67,
            this.textDaySectionStockGou,
            this.textBox69,
            this.textBox71,
            this.textBox72,
            this.textMonthSectionStockZai,
            this.textBox74,
            this.textBox75,
            this.textBox76,
            this.textMonthSectionStockTori,
            this.textBox78,
            this.textBox79,
            this.textBox80,
            this.textMonthSectionStockGou,
            this.textBox82,
            this.label28,
            this.label30,
            this.label31,
            this.label32,
            this.textDaySectionToriRate,
            this.textDaySectionZaiRate,
            this.textMonthSectionZaiRate,
            this.textMonthSectionToriRate,
            this.label41,
            this.label42});
            this.SectionFooter.Height = 0.4074803F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
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
            this.Line45.Width = 10.99F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.99F;
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
            this.SECTOTALTITLE.Height = 0.219F;
            this.SECTOTALTITLE.Left = 0.875F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "拠点計";
            this.SECTOTALTITLE.Top = 0.03125F;
            this.SECTOTALTITLE.Width = 0.65F;
            // 
            // TextBox17
            // 
            this.TextBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Height = 0.1574803F;
            this.TextBox17.Left = 1.58F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox17.Text = "日計";
            this.TextBox17.Top = 0.03125F;
            this.TextBox17.Width = 0.26F;
            // 
            // TextBox18
            // 
            this.TextBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Height = 0.1574803F;
            this.TextBox18.Left = 1.58F;
            this.TextBox18.MultiLine = false;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox18.Text = "累計";
            this.TextBox18.Top = 0.21875F;
            this.TextBox18.Width = 0.26F;
            // 
            // s_StckPriceDayTotal
            // 
            this.s_StckPriceDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StckPriceDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StckPriceDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StckPriceDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StckPriceDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.s_StckPriceDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StckPriceDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.s_StckPriceDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StckPriceDayTotal.DataField = "RetGdsDayTotalZai";
            this.s_StckPriceDayTotal.Height = 0.1574803F;
            this.s_StckPriceDayTotal.Left = 2.53F;
            this.s_StckPriceDayTotal.MultiLine = false;
            this.s_StckPriceDayTotal.Name = "s_StckPriceDayTotal";
            this.s_StckPriceDayTotal.OutputFormat = resources.GetString("s_StckPriceDayTotal.OutputFormat");
            this.s_StckPriceDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StckPriceDayTotal.SummaryGroup = "SectionHeader";
            this.s_StckPriceDayTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StckPriceDayTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StckPriceDayTotal.Text = "ZZZ,ZZZ,ZZ9";
            this.s_StckPriceDayTotal.Top = 0.03125F;
            this.s_StckPriceDayTotal.Width = 0.66F;
            // 
            // textBox59
            // 
            this.textBox59.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.RightColor = System.Drawing.Color.Black;
            this.textBox59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.TopColor = System.Drawing.Color.Black;
            this.textBox59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.DataField = "StckPriceDayTotalZai";
            this.textBox59.Height = 0.1574803F;
            this.textBox59.Left = 1.84F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox59.SummaryGroup = "SectionHeader";
            this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox59.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox59.Top = 0.03125F;
            this.textBox59.Width = 0.66F;
            // 
            // textDaySectionStockZai
            // 
            this.textDaySectionStockZai.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySectionStockZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockZai.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySectionStockZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockZai.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySectionStockZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockZai.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySectionStockZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockZai.DataField = "NetStcPrcDayTotalZai";
            this.textDaySectionStockZai.Height = 0.1574803F;
            this.textDaySectionStockZai.Left = 3.91F;
            this.textDaySectionStockZai.MultiLine = false;
            this.textDaySectionStockZai.Name = "textDaySectionStockZai";
            this.textDaySectionStockZai.OutputFormat = resources.GetString("textDaySectionStockZai.OutputFormat");
            this.textDaySectionStockZai.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySectionStockZai.SummaryGroup = "SectionHeader";
            this.textDaySectionStockZai.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textDaySectionStockZai.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textDaySectionStockZai.Text = "ZZZ,ZZZ,ZZ9";
            this.textDaySectionStockZai.Top = 0.03125F;
            this.textDaySectionStockZai.Width = 0.66F;
            // 
            // textBox61
            // 
            this.textBox61.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.RightColor = System.Drawing.Color.Black;
            this.textBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.TopColor = System.Drawing.Color.Black;
            this.textBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.DataField = "DisDayTotalZai";
            this.textBox61.Height = 0.1574803F;
            this.textBox61.Left = 3.22F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox61.SummaryGroup = "SectionHeader";
            this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox61.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox61.Top = 0.03125F;
            this.textBox61.Width = 0.66F;
            // 
            // textBox62
            // 
            this.textBox62.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.RightColor = System.Drawing.Color.Black;
            this.textBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.TopColor = System.Drawing.Color.Black;
            this.textBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.DataField = "RetGdsDayTotalTori";
            this.textBox62.Height = 0.1574803F;
            this.textBox62.Left = 5.32F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox62.SummaryGroup = "SectionHeader";
            this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox62.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox62.Top = 0.03125F;
            this.textBox62.Width = 0.66F;
            // 
            // textBox63
            // 
            this.textBox63.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.RightColor = System.Drawing.Color.Black;
            this.textBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.TopColor = System.Drawing.Color.Black;
            this.textBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.DataField = "StckPriceDayTotalTori";
            this.textBox63.Height = 0.1574803F;
            this.textBox63.Left = 4.63F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox63.SummaryGroup = "SectionHeader";
            this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox63.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox63.Top = 0.03125F;
            this.textBox63.Width = 0.66F;
            // 
            // textDaySectionStockTori
            // 
            this.textDaySectionStockTori.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySectionStockTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockTori.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySectionStockTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockTori.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySectionStockTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockTori.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySectionStockTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockTori.DataField = "NetStcPrcDayTotalTori";
            this.textDaySectionStockTori.Height = 0.1574803F;
            this.textDaySectionStockTori.Left = 6.7F;
            this.textDaySectionStockTori.MultiLine = false;
            this.textDaySectionStockTori.Name = "textDaySectionStockTori";
            this.textDaySectionStockTori.OutputFormat = resources.GetString("textDaySectionStockTori.OutputFormat");
            this.textDaySectionStockTori.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySectionStockTori.SummaryGroup = "SectionHeader";
            this.textDaySectionStockTori.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textDaySectionStockTori.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textDaySectionStockTori.Text = "ZZZ,ZZZ,ZZ9";
            this.textDaySectionStockTori.Top = 0.03125F;
            this.textDaySectionStockTori.Width = 0.66F;
            // 
            // textBox65
            // 
            this.textBox65.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.Border.RightColor = System.Drawing.Color.Black;
            this.textBox65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.Border.TopColor = System.Drawing.Color.Black;
            this.textBox65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.DataField = "DisDayTotalTori";
            this.textBox65.Height = 0.1574803F;
            this.textBox65.Left = 6.01F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
            this.textBox65.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox65.SummaryGroup = "SectionHeader";
            this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox65.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox65.Top = 0.03125F;
            this.textBox65.Width = 0.66F;
            // 
            // textBox66
            // 
            this.textBox66.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.Border.RightColor = System.Drawing.Color.Black;
            this.textBox66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.Border.TopColor = System.Drawing.Color.Black;
            this.textBox66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.DataField = "RetGdsDayTotalGou";
            this.textBox66.Height = 0.1574803F;
            this.textBox66.Left = 8.12F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
            this.textBox66.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox66.SummaryGroup = "SectionHeader";
            this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox66.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox66.Top = 0.031F;
            this.textBox66.Width = 0.66F;
            // 
            // textBox67
            // 
            this.textBox67.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.Border.RightColor = System.Drawing.Color.Black;
            this.textBox67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.Border.TopColor = System.Drawing.Color.Black;
            this.textBox67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.DataField = "StckPriceDayTotalGou";
            this.textBox67.Height = 0.1574803F;
            this.textBox67.Left = 7.43F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
            this.textBox67.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox67.SummaryGroup = "SectionHeader";
            this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox67.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox67.Top = 0.031F;
            this.textBox67.Width = 0.66F;
            // 
            // textDaySectionStockGou
            // 
            this.textDaySectionStockGou.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySectionStockGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockGou.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySectionStockGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockGou.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySectionStockGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockGou.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySectionStockGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionStockGou.DataField = "NetStcPrcDayTotalGou";
            this.textDaySectionStockGou.Height = 0.1574803F;
            this.textDaySectionStockGou.Left = 9.5F;
            this.textDaySectionStockGou.MultiLine = false;
            this.textDaySectionStockGou.Name = "textDaySectionStockGou";
            this.textDaySectionStockGou.OutputFormat = resources.GetString("textDaySectionStockGou.OutputFormat");
            this.textDaySectionStockGou.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySectionStockGou.SummaryGroup = "SectionHeader";
            this.textDaySectionStockGou.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textDaySectionStockGou.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textDaySectionStockGou.Text = "ZZZ,ZZZ,ZZ9";
            this.textDaySectionStockGou.Top = 0.031F;
            this.textDaySectionStockGou.Width = 0.66F;
            // 
            // textBox69
            // 
            this.textBox69.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.RightColor = System.Drawing.Color.Black;
            this.textBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.TopColor = System.Drawing.Color.Black;
            this.textBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.DataField = "DisDayTotalGou";
            this.textBox69.Height = 0.1574803F;
            this.textBox69.Left = 8.81F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox69.SummaryGroup = "SectionHeader";
            this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox69.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox69.Top = 0.031F;
            this.textBox69.Width = 0.66F;
            // 
            // textBox71
            // 
            this.textBox71.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.Border.RightColor = System.Drawing.Color.Black;
            this.textBox71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.Border.TopColor = System.Drawing.Color.Black;
            this.textBox71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.DataField = "RetGdsMonthTotalZai";
            this.textBox71.Height = 0.1574803F;
            this.textBox71.Left = 2.53F;
            this.textBox71.MultiLine = false;
            this.textBox71.Name = "textBox71";
            this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
            this.textBox71.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox71.SummaryGroup = "SectionHeader";
            this.textBox71.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox71.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox71.Top = 0.21875F;
            this.textBox71.Width = 0.66F;
            // 
            // textBox72
            // 
            this.textBox72.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.RightColor = System.Drawing.Color.Black;
            this.textBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.TopColor = System.Drawing.Color.Black;
            this.textBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.DataField = "StckPriceMonthTotalZai";
            this.textBox72.Height = 0.1574803F;
            this.textBox72.Left = 1.84F;
            this.textBox72.MultiLine = false;
            this.textBox72.Name = "textBox72";
            this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
            this.textBox72.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox72.SummaryGroup = "SectionHeader";
            this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox72.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox72.Top = 0.21875F;
            this.textBox72.Width = 0.66F;
            // 
            // textMonthSectionStockZai
            // 
            this.textMonthSectionStockZai.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSectionStockZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockZai.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSectionStockZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockZai.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSectionStockZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockZai.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSectionStockZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockZai.DataField = "NetStcPrcMonthTotalZai";
            this.textMonthSectionStockZai.Height = 0.1574803F;
            this.textMonthSectionStockZai.Left = 3.91F;
            this.textMonthSectionStockZai.MultiLine = false;
            this.textMonthSectionStockZai.Name = "textMonthSectionStockZai";
            this.textMonthSectionStockZai.OutputFormat = resources.GetString("textMonthSectionStockZai.OutputFormat");
            this.textMonthSectionStockZai.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSectionStockZai.SummaryGroup = "SectionHeader";
            this.textMonthSectionStockZai.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textMonthSectionStockZai.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textMonthSectionStockZai.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthSectionStockZai.Top = 0.21875F;
            this.textMonthSectionStockZai.Width = 0.66F;
            // 
            // textBox74
            // 
            this.textBox74.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.Border.RightColor = System.Drawing.Color.Black;
            this.textBox74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.Border.TopColor = System.Drawing.Color.Black;
            this.textBox74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.DataField = "DisDayMonthTotalZai";
            this.textBox74.Height = 0.1574803F;
            this.textBox74.Left = 3.22F;
            this.textBox74.MultiLine = false;
            this.textBox74.Name = "textBox74";
            this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
            this.textBox74.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox74.SummaryGroup = "SectionHeader";
            this.textBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox74.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox74.Top = 0.21875F;
            this.textBox74.Width = 0.66F;
            // 
            // textBox75
            // 
            this.textBox75.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.RightColor = System.Drawing.Color.Black;
            this.textBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.TopColor = System.Drawing.Color.Black;
            this.textBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.DataField = "RetGdsMonthTotalTori";
            this.textBox75.Height = 0.1574803F;
            this.textBox75.Left = 5.32F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
            this.textBox75.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox75.SummaryGroup = "SectionHeader";
            this.textBox75.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox75.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox75.Top = 0.21875F;
            this.textBox75.Width = 0.66F;
            // 
            // textBox76
            // 
            this.textBox76.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.Border.RightColor = System.Drawing.Color.Black;
            this.textBox76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.Border.TopColor = System.Drawing.Color.Black;
            this.textBox76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox76.DataField = "StckPriceMonthTotalTori";
            this.textBox76.Height = 0.1574803F;
            this.textBox76.Left = 4.63F;
            this.textBox76.MultiLine = false;
            this.textBox76.Name = "textBox76";
            this.textBox76.OutputFormat = resources.GetString("textBox76.OutputFormat");
            this.textBox76.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox76.SummaryGroup = "SectionHeader";
            this.textBox76.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox76.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox76.Top = 0.21875F;
            this.textBox76.Width = 0.66F;
            // 
            // textMonthSectionStockTori
            // 
            this.textMonthSectionStockTori.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSectionStockTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockTori.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSectionStockTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockTori.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSectionStockTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockTori.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSectionStockTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockTori.DataField = "NetStcPrcMonthTotalTori";
            this.textMonthSectionStockTori.Height = 0.1574803F;
            this.textMonthSectionStockTori.Left = 6.7F;
            this.textMonthSectionStockTori.MultiLine = false;
            this.textMonthSectionStockTori.Name = "textMonthSectionStockTori";
            this.textMonthSectionStockTori.OutputFormat = resources.GetString("textMonthSectionStockTori.OutputFormat");
            this.textMonthSectionStockTori.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSectionStockTori.SummaryGroup = "SectionHeader";
            this.textMonthSectionStockTori.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textMonthSectionStockTori.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textMonthSectionStockTori.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthSectionStockTori.Top = 0.21875F;
            this.textMonthSectionStockTori.Width = 0.66F;
            // 
            // textBox78
            // 
            this.textBox78.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.Border.RightColor = System.Drawing.Color.Black;
            this.textBox78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.Border.TopColor = System.Drawing.Color.Black;
            this.textBox78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox78.DataField = "DisDayMonthTotalTori";
            this.textBox78.Height = 0.1574803F;
            this.textBox78.Left = 6.01F;
            this.textBox78.MultiLine = false;
            this.textBox78.Name = "textBox78";
            this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
            this.textBox78.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox78.SummaryGroup = "SectionHeader";
            this.textBox78.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox78.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox78.Top = 0.21875F;
            this.textBox78.Width = 0.66F;
            // 
            // textBox79
            // 
            this.textBox79.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.Border.RightColor = System.Drawing.Color.Black;
            this.textBox79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.Border.TopColor = System.Drawing.Color.Black;
            this.textBox79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox79.DataField = "RetGdsMonthTotalGou";
            this.textBox79.Height = 0.1574803F;
            this.textBox79.Left = 8.12F;
            this.textBox79.MultiLine = false;
            this.textBox79.Name = "textBox79";
            this.textBox79.OutputFormat = resources.GetString("textBox79.OutputFormat");
            this.textBox79.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox79.SummaryGroup = "SectionHeader";
            this.textBox79.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox79.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox79.Top = 0.219F;
            this.textBox79.Width = 0.66F;
            // 
            // textBox80
            // 
            this.textBox80.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.RightColor = System.Drawing.Color.Black;
            this.textBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.TopColor = System.Drawing.Color.Black;
            this.textBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.DataField = "StckPriceMonthTotalGou";
            this.textBox80.Height = 0.1574803F;
            this.textBox80.Left = 7.43F;
            this.textBox80.MultiLine = false;
            this.textBox80.Name = "textBox80";
            this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
            this.textBox80.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox80.SummaryGroup = "SectionHeader";
            this.textBox80.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox80.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox80.Top = 0.219F;
            this.textBox80.Width = 0.66F;
            // 
            // textMonthSectionStockGou
            // 
            this.textMonthSectionStockGou.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSectionStockGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockGou.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSectionStockGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockGou.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSectionStockGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockGou.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSectionStockGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionStockGou.DataField = "NetStcPrcMonthTotalGou";
            this.textMonthSectionStockGou.Height = 0.1574803F;
            this.textMonthSectionStockGou.Left = 9.5F;
            this.textMonthSectionStockGou.MultiLine = false;
            this.textMonthSectionStockGou.Name = "textMonthSectionStockGou";
            this.textMonthSectionStockGou.OutputFormat = resources.GetString("textMonthSectionStockGou.OutputFormat");
            this.textMonthSectionStockGou.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSectionStockGou.SummaryGroup = "SectionHeader";
            this.textMonthSectionStockGou.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textMonthSectionStockGou.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textMonthSectionStockGou.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthSectionStockGou.Top = 0.219F;
            this.textMonthSectionStockGou.Width = 0.66F;
            // 
            // textBox82
            // 
            this.textBox82.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.Border.RightColor = System.Drawing.Color.Black;
            this.textBox82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.Border.TopColor = System.Drawing.Color.Black;
            this.textBox82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox82.DataField = "DisDayMonthTotalGou";
            this.textBox82.Height = 0.1574803F;
            this.textBox82.Left = 8.81F;
            this.textBox82.MultiLine = false;
            this.textBox82.Name = "textBox82";
            this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
            this.textBox82.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox82.SummaryGroup = "SectionHeader";
            this.textBox82.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox82.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox82.Top = 0.219F;
            this.textBox82.Width = 0.66F;
            // 
            // label28
            // 
            this.label28.Border.BottomColor = System.Drawing.Color.Black;
            this.label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.LeftColor = System.Drawing.Color.Black;
            this.label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.RightColor = System.Drawing.Color.Black;
            this.label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.TopColor = System.Drawing.Color.Black;
            this.label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Height = 0.16F;
            this.label28.HyperLink = "";
            this.label28.Left = 7.36F;
            this.label28.MultiLine = false;
            this.label28.Name = "label28";
            this.label28.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label28.Text = "|";
            this.label28.Top = 0.21875F;
            this.label28.Width = 0.06F;
            // 
            // label30
            // 
            this.label30.Border.BottomColor = System.Drawing.Color.Black;
            this.label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.LeftColor = System.Drawing.Color.Black;
            this.label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.RightColor = System.Drawing.Color.Black;
            this.label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.TopColor = System.Drawing.Color.Black;
            this.label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Height = 0.16F;
            this.label30.HyperLink = "";
            this.label30.Left = 4.56F;
            this.label30.MultiLine = false;
            this.label30.Name = "label30";
            this.label30.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label30.Text = "|";
            this.label30.Top = 0.03125F;
            this.label30.Width = 0.06F;
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
            this.label31.Height = 0.16F;
            this.label31.HyperLink = "";
            this.label31.Left = 4.56F;
            this.label31.MultiLine = false;
            this.label31.Name = "label31";
            this.label31.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label31.Text = "|";
            this.label31.Top = 0.21875F;
            this.label31.Width = 0.06F;
            // 
            // label32
            // 
            this.label32.Border.BottomColor = System.Drawing.Color.Black;
            this.label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.LeftColor = System.Drawing.Color.Black;
            this.label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.RightColor = System.Drawing.Color.Black;
            this.label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.TopColor = System.Drawing.Color.Black;
            this.label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Height = 0.16F;
            this.label32.HyperLink = "";
            this.label32.Left = 7.36F;
            this.label32.MultiLine = false;
            this.label32.Name = "label32";
            this.label32.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label32.Text = "|";
            this.label32.Top = 0.03125F;
            this.label32.Width = 0.06F;
            // 
            // textDaySectionToriRate
            // 
            this.textDaySectionToriRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySectionToriRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionToriRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySectionToriRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionToriRate.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySectionToriRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionToriRate.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySectionToriRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionToriRate.DataField = "StckToriRatioDayTotalGou";
            this.textDaySectionToriRate.Height = 0.1574803F;
            this.textDaySectionToriRate.Left = 10.62F;
            this.textDaySectionToriRate.MultiLine = false;
            this.textDaySectionToriRate.Name = "textDaySectionToriRate";
            this.textDaySectionToriRate.OutputFormat = resources.GetString("textDaySectionToriRate.OutputFormat");
            this.textDaySectionToriRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySectionToriRate.SummaryGroup = "SectionHeader";
            this.textDaySectionToriRate.Text = "100.00";
            this.textDaySectionToriRate.Top = 0.031F;
            this.textDaySectionToriRate.Width = 0.37F;
            // 
            // textDaySectionZaiRate
            // 
            this.textDaySectionZaiRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySectionZaiRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionZaiRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySectionZaiRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionZaiRate.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySectionZaiRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionZaiRate.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySectionZaiRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySectionZaiRate.DataField = "StckZaiRatioDayTotalGou";
            this.textDaySectionZaiRate.Height = 0.1574803F;
            this.textDaySectionZaiRate.Left = 10.19F;
            this.textDaySectionZaiRate.MultiLine = false;
            this.textDaySectionZaiRate.Name = "textDaySectionZaiRate";
            this.textDaySectionZaiRate.OutputFormat = resources.GetString("textDaySectionZaiRate.OutputFormat");
            this.textDaySectionZaiRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySectionZaiRate.SummaryGroup = "SectionHeader";
            this.textDaySectionZaiRate.Text = "100.00";
            this.textDaySectionZaiRate.Top = 0.031F;
            this.textDaySectionZaiRate.Width = 0.37F;
            // 
            // textMonthSectionZaiRate
            // 
            this.textMonthSectionZaiRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSectionZaiRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionZaiRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSectionZaiRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionZaiRate.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSectionZaiRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionZaiRate.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSectionZaiRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionZaiRate.DataField = "StckZaiRatioMonthTotalGou";
            this.textMonthSectionZaiRate.Height = 0.1574803F;
            this.textMonthSectionZaiRate.Left = 10.19F;
            this.textMonthSectionZaiRate.MultiLine = false;
            this.textMonthSectionZaiRate.Name = "textMonthSectionZaiRate";
            this.textMonthSectionZaiRate.OutputFormat = resources.GetString("textMonthSectionZaiRate.OutputFormat");
            this.textMonthSectionZaiRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSectionZaiRate.SummaryGroup = "SectionHeader";
            this.textMonthSectionZaiRate.Text = "100.00";
            this.textMonthSectionZaiRate.Top = 0.219F;
            this.textMonthSectionZaiRate.Width = 0.37F;
            // 
            // textMonthSectionToriRate
            // 
            this.textMonthSectionToriRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSectionToriRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionToriRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSectionToriRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionToriRate.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSectionToriRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionToriRate.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSectionToriRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSectionToriRate.DataField = "StckToriRatioMonthTotalGou";
            this.textMonthSectionToriRate.Height = 0.1574803F;
            this.textMonthSectionToriRate.Left = 10.62F;
            this.textMonthSectionToriRate.MultiLine = false;
            this.textMonthSectionToriRate.Name = "textMonthSectionToriRate";
            this.textMonthSectionToriRate.OutputFormat = resources.GetString("textMonthSectionToriRate.OutputFormat");
            this.textMonthSectionToriRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSectionToriRate.SummaryGroup = "SectionHeader";
            this.textMonthSectionToriRate.Text = "100.00";
            this.textMonthSectionToriRate.Top = 0.219F;
            this.textMonthSectionToriRate.Width = 0.37F;
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
            this.label41.Height = 0.16F;
            this.label41.HyperLink = "";
            this.label41.Left = 10.56F;
            this.label41.MultiLine = false;
            this.label41.Name = "label41";
            this.label41.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label41.Text = ":";
            this.label41.Top = 0.219F;
            this.label41.Width = 0.06F;
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
            this.label42.Height = 0.16F;
            this.label42.HyperLink = "";
            this.label42.Left = 10.56F;
            this.label42.MultiLine = false;
            this.label42.Name = "label42";
            this.label42.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label42.Text = ":";
            this.label42.Top = 0.031F;
            this.label42.Width = 0.06F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.CanShrink = true;
            this.SupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CustomerCode,
            this.CustomerName,
            this.line4});
            this.SupplierHeader.DataField = "SupplierCode";
            this.SupplierHeader.Height = 0.1666667F;
            this.SupplierHeader.Name = "SupplierHeader";
            this.SupplierHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.line4.Width = 10.99F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.99F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox3,
            this.Line,
            this.TextBox15,
            this.TextBox16,
            this.w_StckPriceDayTotal,
            this.textBox84,
            this.textBox85,
            this.textDaySupplierStockZai,
            this.textBox87,
            this.textBox88,
            this.textBox89,
            this.textMonthSupplierStockZai,
            this.textBox91,
            this.textBox92,
            this.textBox93,
            this.textDaySupplierStockTori,
            this.textBox95,
            this.textBox96,
            this.textBox97,
            this.textMonthSupplierStockTori,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textDaySupplierStockGou,
            this.textBox103,
            this.textBox104,
            this.textBox105,
            this.textMonthSupplierStockGou,
            this.label33,
            this.label34,
            this.label35,
            this.label36,
            this.textDaySupplierToriRate,
            this.textDaySupplierZaiRate,
            this.textMonthSupplierZaiRate,
            this.textMonthSupplierToriRate,
            this.label39,
            this.label40});
            this.SupplierFooter.Height = 0.41F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            this.SupplierFooter.Format += new System.EventHandler(this.SupplierFooter_Format);
            this.SupplierFooter.BeforePrint += new System.EventHandler(this.SupplierFooter_BeforePrint);
            // 
            // TextBox3
            // 
            this.TextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Height = 0.219F;
            this.TextBox3.Left = 0.875F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox3.Text = "仕入先計";
            this.TextBox3.Top = 0.03125F;
            this.TextBox3.Width = 0.65F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 10.99F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.99F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // TextBox15
            // 
            this.TextBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Height = 0.1574803F;
            this.TextBox15.Left = 1.58F;
            this.TextBox15.MultiLine = false;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox15.Text = "日計";
            this.TextBox15.Top = 0.03125F;
            this.TextBox15.Width = 0.26F;
            // 
            // TextBox16
            // 
            this.TextBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Height = 0.1574803F;
            this.TextBox16.Left = 1.58F;
            this.TextBox16.MultiLine = false;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox16.Text = "累計";
            this.TextBox16.Top = 0.21875F;
            this.TextBox16.Width = 0.26F;
            // 
            // w_StckPriceDayTotal
            // 
            this.w_StckPriceDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.w_StckPriceDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_StckPriceDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.w_StckPriceDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_StckPriceDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.w_StckPriceDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_StckPriceDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.w_StckPriceDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_StckPriceDayTotal.DataField = "StckPriceDayTotalZai";
            this.w_StckPriceDayTotal.Height = 0.1574803F;
            this.w_StckPriceDayTotal.Left = 1.84F;
            this.w_StckPriceDayTotal.MultiLine = false;
            this.w_StckPriceDayTotal.Name = "w_StckPriceDayTotal";
            this.w_StckPriceDayTotal.OutputFormat = resources.GetString("w_StckPriceDayTotal.OutputFormat");
            this.w_StckPriceDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.w_StckPriceDayTotal.SummaryGroup = "SupplierHeader";
            this.w_StckPriceDayTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_StckPriceDayTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_StckPriceDayTotal.Text = "ZZZ,ZZZ,ZZ9";
            this.w_StckPriceDayTotal.Top = 0.03125F;
            this.w_StckPriceDayTotal.Width = 0.66F;
            // 
            // textBox84
            // 
            this.textBox84.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.Border.RightColor = System.Drawing.Color.Black;
            this.textBox84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.Border.TopColor = System.Drawing.Color.Black;
            this.textBox84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox84.DataField = "RetGdsDayTotalZai";
            this.textBox84.Height = 0.1574803F;
            this.textBox84.Left = 2.53F;
            this.textBox84.MultiLine = false;
            this.textBox84.Name = "textBox84";
            this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
            this.textBox84.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox84.SummaryGroup = "SupplierHeader";
            this.textBox84.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox84.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox84.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox84.Top = 0.03125F;
            this.textBox84.Width = 0.66F;
            // 
            // textBox85
            // 
            this.textBox85.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.RightColor = System.Drawing.Color.Black;
            this.textBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.TopColor = System.Drawing.Color.Black;
            this.textBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.DataField = "DisDayTotalZai";
            this.textBox85.Height = 0.1574803F;
            this.textBox85.Left = 3.22F;
            this.textBox85.MultiLine = false;
            this.textBox85.Name = "textBox85";
            this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
            this.textBox85.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox85.SummaryGroup = "SupplierHeader";
            this.textBox85.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox85.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox85.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox85.Top = 0.03125F;
            this.textBox85.Width = 0.66F;
            // 
            // textDaySupplierStockZai
            // 
            this.textDaySupplierStockZai.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySupplierStockZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockZai.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySupplierStockZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockZai.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySupplierStockZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockZai.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySupplierStockZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockZai.DataField = "NetStcPrcDayTotalZai";
            this.textDaySupplierStockZai.Height = 0.1574803F;
            this.textDaySupplierStockZai.Left = 3.91F;
            this.textDaySupplierStockZai.MultiLine = false;
            this.textDaySupplierStockZai.Name = "textDaySupplierStockZai";
            this.textDaySupplierStockZai.OutputFormat = resources.GetString("textDaySupplierStockZai.OutputFormat");
            this.textDaySupplierStockZai.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySupplierStockZai.SummaryGroup = "SupplierHeader";
            this.textDaySupplierStockZai.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textDaySupplierStockZai.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textDaySupplierStockZai.Text = "ZZZ,ZZZ,ZZ9";
            this.textDaySupplierStockZai.Top = 0.03125F;
            this.textDaySupplierStockZai.Width = 0.66F;
            // 
            // textBox87
            // 
            this.textBox87.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.Border.RightColor = System.Drawing.Color.Black;
            this.textBox87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.Border.TopColor = System.Drawing.Color.Black;
            this.textBox87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox87.DataField = "StckPriceMonthTotalZai";
            this.textBox87.Height = 0.1574803F;
            this.textBox87.Left = 1.84F;
            this.textBox87.MultiLine = false;
            this.textBox87.Name = "textBox87";
            this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
            this.textBox87.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox87.SummaryGroup = "SupplierHeader";
            this.textBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox87.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox87.Top = 0.21875F;
            this.textBox87.Width = 0.66F;
            // 
            // textBox88
            // 
            this.textBox88.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.RightColor = System.Drawing.Color.Black;
            this.textBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.TopColor = System.Drawing.Color.Black;
            this.textBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.DataField = "RetGdsMonthTotalZai";
            this.textBox88.Height = 0.1574803F;
            this.textBox88.Left = 2.53F;
            this.textBox88.MultiLine = false;
            this.textBox88.Name = "textBox88";
            this.textBox88.OutputFormat = resources.GetString("textBox88.OutputFormat");
            this.textBox88.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox88.SummaryGroup = "SupplierHeader";
            this.textBox88.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox88.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox88.Top = 0.21875F;
            this.textBox88.Width = 0.66F;
            // 
            // textBox89
            // 
            this.textBox89.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.RightColor = System.Drawing.Color.Black;
            this.textBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.TopColor = System.Drawing.Color.Black;
            this.textBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.DataField = "DisDayMonthTotalZai";
            this.textBox89.Height = 0.1574803F;
            this.textBox89.Left = 3.22F;
            this.textBox89.MultiLine = false;
            this.textBox89.Name = "textBox89";
            this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
            this.textBox89.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox89.SummaryGroup = "SupplierHeader";
            this.textBox89.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox89.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox89.Top = 0.21875F;
            this.textBox89.Width = 0.66F;
            // 
            // textMonthSupplierStockZai
            // 
            this.textMonthSupplierStockZai.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockZai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockZai.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockZai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockZai.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockZai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockZai.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockZai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockZai.DataField = "NetStcPrcMonthTotalZai";
            this.textMonthSupplierStockZai.Height = 0.1574803F;
            this.textMonthSupplierStockZai.Left = 3.91F;
            this.textMonthSupplierStockZai.MultiLine = false;
            this.textMonthSupplierStockZai.Name = "textMonthSupplierStockZai";
            this.textMonthSupplierStockZai.OutputFormat = resources.GetString("textMonthSupplierStockZai.OutputFormat");
            this.textMonthSupplierStockZai.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSupplierStockZai.SummaryGroup = "SupplierHeader";
            this.textMonthSupplierStockZai.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textMonthSupplierStockZai.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textMonthSupplierStockZai.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthSupplierStockZai.Top = 0.21875F;
            this.textMonthSupplierStockZai.Width = 0.66F;
            // 
            // textBox91
            // 
            this.textBox91.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.RightColor = System.Drawing.Color.Black;
            this.textBox91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.TopColor = System.Drawing.Color.Black;
            this.textBox91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.DataField = "StckPriceDayTotalTori";
            this.textBox91.Height = 0.1574803F;
            this.textBox91.Left = 4.63F;
            this.textBox91.MultiLine = false;
            this.textBox91.Name = "textBox91";
            this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
            this.textBox91.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox91.SummaryGroup = "SupplierHeader";
            this.textBox91.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox91.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox91.Top = 0.03125F;
            this.textBox91.Width = 0.66F;
            // 
            // textBox92
            // 
            this.textBox92.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.Border.RightColor = System.Drawing.Color.Black;
            this.textBox92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.Border.TopColor = System.Drawing.Color.Black;
            this.textBox92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox92.DataField = "RetGdsDayTotalTori";
            this.textBox92.Height = 0.1574803F;
            this.textBox92.Left = 5.32F;
            this.textBox92.MultiLine = false;
            this.textBox92.Name = "textBox92";
            this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
            this.textBox92.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox92.SummaryGroup = "SupplierHeader";
            this.textBox92.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox92.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox92.Top = 0.03125F;
            this.textBox92.Width = 0.66F;
            // 
            // textBox93
            // 
            this.textBox93.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox93.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox93.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.Border.RightColor = System.Drawing.Color.Black;
            this.textBox93.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.Border.TopColor = System.Drawing.Color.Black;
            this.textBox93.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox93.DataField = "DisDayTotalTori";
            this.textBox93.Height = 0.1574803F;
            this.textBox93.Left = 6.01F;
            this.textBox93.MultiLine = false;
            this.textBox93.Name = "textBox93";
            this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
            this.textBox93.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox93.SummaryGroup = "SupplierHeader";
            this.textBox93.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox93.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox93.Top = 0.03125F;
            this.textBox93.Width = 0.66F;
            // 
            // textDaySupplierStockTori
            // 
            this.textDaySupplierStockTori.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySupplierStockTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockTori.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySupplierStockTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockTori.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySupplierStockTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockTori.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySupplierStockTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockTori.DataField = "NetStcPrcDayTotalTori";
            this.textDaySupplierStockTori.Height = 0.1574803F;
            this.textDaySupplierStockTori.Left = 6.7F;
            this.textDaySupplierStockTori.MultiLine = false;
            this.textDaySupplierStockTori.Name = "textDaySupplierStockTori";
            this.textDaySupplierStockTori.OutputFormat = resources.GetString("textDaySupplierStockTori.OutputFormat");
            this.textDaySupplierStockTori.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySupplierStockTori.SummaryGroup = "SupplierHeader";
            this.textDaySupplierStockTori.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textDaySupplierStockTori.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textDaySupplierStockTori.Text = "ZZZ,ZZZ,ZZ9";
            this.textDaySupplierStockTori.Top = 0.03125F;
            this.textDaySupplierStockTori.Width = 0.66F;
            // 
            // textBox95
            // 
            this.textBox95.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.Border.RightColor = System.Drawing.Color.Black;
            this.textBox95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.Border.TopColor = System.Drawing.Color.Black;
            this.textBox95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox95.DataField = "StckPriceMonthTotalTori";
            this.textBox95.Height = 0.1574803F;
            this.textBox95.Left = 4.63F;
            this.textBox95.MultiLine = false;
            this.textBox95.Name = "textBox95";
            this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
            this.textBox95.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox95.SummaryGroup = "SupplierHeader";
            this.textBox95.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox95.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox95.Top = 0.21875F;
            this.textBox95.Width = 0.66F;
            // 
            // textBox96
            // 
            this.textBox96.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.Border.RightColor = System.Drawing.Color.Black;
            this.textBox96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.Border.TopColor = System.Drawing.Color.Black;
            this.textBox96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox96.DataField = "RetGdsMonthTotalTori";
            this.textBox96.Height = 0.1574803F;
            this.textBox96.Left = 5.32F;
            this.textBox96.MultiLine = false;
            this.textBox96.Name = "textBox96";
            this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
            this.textBox96.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox96.SummaryGroup = "SupplierHeader";
            this.textBox96.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox96.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox96.Top = 0.21875F;
            this.textBox96.Width = 0.66F;
            // 
            // textBox97
            // 
            this.textBox97.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.Border.RightColor = System.Drawing.Color.Black;
            this.textBox97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.Border.TopColor = System.Drawing.Color.Black;
            this.textBox97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox97.DataField = "DisDayMonthTotalTori";
            this.textBox97.Height = 0.1574803F;
            this.textBox97.Left = 6.01F;
            this.textBox97.MultiLine = false;
            this.textBox97.Name = "textBox97";
            this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
            this.textBox97.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox97.SummaryGroup = "SupplierHeader";
            this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox97.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox97.Top = 0.21875F;
            this.textBox97.Width = 0.66F;
            // 
            // textMonthSupplierStockTori
            // 
            this.textMonthSupplierStockTori.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockTori.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockTori.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockTori.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockTori.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockTori.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockTori.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockTori.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockTori.DataField = "NetStcPrcMonthTotalTori";
            this.textMonthSupplierStockTori.Height = 0.1574803F;
            this.textMonthSupplierStockTori.Left = 6.7F;
            this.textMonthSupplierStockTori.MultiLine = false;
            this.textMonthSupplierStockTori.Name = "textMonthSupplierStockTori";
            this.textMonthSupplierStockTori.OutputFormat = resources.GetString("textMonthSupplierStockTori.OutputFormat");
            this.textMonthSupplierStockTori.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSupplierStockTori.SummaryGroup = "SupplierHeader";
            this.textMonthSupplierStockTori.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textMonthSupplierStockTori.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textMonthSupplierStockTori.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthSupplierStockTori.Top = 0.21875F;
            this.textMonthSupplierStockTori.Width = 0.66F;
            // 
            // textBox99
            // 
            this.textBox99.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.Border.RightColor = System.Drawing.Color.Black;
            this.textBox99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.Border.TopColor = System.Drawing.Color.Black;
            this.textBox99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox99.DataField = "StckPriceDayTotalGou";
            this.textBox99.Height = 0.1574803F;
            this.textBox99.Left = 7.43F;
            this.textBox99.MultiLine = false;
            this.textBox99.Name = "textBox99";
            this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
            this.textBox99.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox99.SummaryGroup = "SupplierHeader";
            this.textBox99.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox99.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox99.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox99.Top = 0.031F;
            this.textBox99.Width = 0.66F;
            // 
            // textBox100
            // 
            this.textBox100.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.RightColor = System.Drawing.Color.Black;
            this.textBox100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.TopColor = System.Drawing.Color.Black;
            this.textBox100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.DataField = "RetGdsDayTotalGou";
            this.textBox100.Height = 0.1574803F;
            this.textBox100.Left = 8.12F;
            this.textBox100.MultiLine = false;
            this.textBox100.Name = "textBox100";
            this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
            this.textBox100.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox100.SummaryGroup = "SupplierHeader";
            this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox100.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox100.Top = 0.031F;
            this.textBox100.Width = 0.66F;
            // 
            // textBox101
            // 
            this.textBox101.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.Border.RightColor = System.Drawing.Color.Black;
            this.textBox101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.Border.TopColor = System.Drawing.Color.Black;
            this.textBox101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox101.DataField = "DisDayTotalGou";
            this.textBox101.Height = 0.1574803F;
            this.textBox101.Left = 8.81F;
            this.textBox101.MultiLine = false;
            this.textBox101.Name = "textBox101";
            this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
            this.textBox101.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox101.SummaryGroup = "SupplierHeader";
            this.textBox101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox101.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox101.Top = 0.031F;
            this.textBox101.Width = 0.66F;
            // 
            // textDaySupplierStockGou
            // 
            this.textDaySupplierStockGou.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySupplierStockGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockGou.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySupplierStockGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockGou.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySupplierStockGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockGou.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySupplierStockGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierStockGou.DataField = "NetStcPrcDayTotalGou";
            this.textDaySupplierStockGou.Height = 0.1574803F;
            this.textDaySupplierStockGou.Left = 9.5F;
            this.textDaySupplierStockGou.MultiLine = false;
            this.textDaySupplierStockGou.Name = "textDaySupplierStockGou";
            this.textDaySupplierStockGou.OutputFormat = resources.GetString("textDaySupplierStockGou.OutputFormat");
            this.textDaySupplierStockGou.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySupplierStockGou.SummaryGroup = "SupplierHeader";
            this.textDaySupplierStockGou.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textDaySupplierStockGou.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textDaySupplierStockGou.Text = "ZZZ,ZZZ,ZZ9";
            this.textDaySupplierStockGou.Top = 0.031F;
            this.textDaySupplierStockGou.Width = 0.66F;
            // 
            // textBox103
            // 
            this.textBox103.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.RightColor = System.Drawing.Color.Black;
            this.textBox103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.TopColor = System.Drawing.Color.Black;
            this.textBox103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.DataField = "StckPriceMonthTotalGou";
            this.textBox103.Height = 0.1574803F;
            this.textBox103.Left = 7.43F;
            this.textBox103.MultiLine = false;
            this.textBox103.Name = "textBox103";
            this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
            this.textBox103.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox103.SummaryGroup = "SupplierHeader";
            this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox103.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox103.Top = 0.219F;
            this.textBox103.Width = 0.66F;
            // 
            // textBox104
            // 
            this.textBox104.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.Border.RightColor = System.Drawing.Color.Black;
            this.textBox104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.Border.TopColor = System.Drawing.Color.Black;
            this.textBox104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox104.DataField = "RetGdsMonthTotalGou";
            this.textBox104.Height = 0.1574803F;
            this.textBox104.Left = 8.12F;
            this.textBox104.MultiLine = false;
            this.textBox104.Name = "textBox104";
            this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
            this.textBox104.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox104.SummaryGroup = "SupplierHeader";
            this.textBox104.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox104.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox104.Top = 0.219F;
            this.textBox104.Width = 0.66F;
            // 
            // textBox105
            // 
            this.textBox105.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.Border.RightColor = System.Drawing.Color.Black;
            this.textBox105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.Border.TopColor = System.Drawing.Color.Black;
            this.textBox105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox105.DataField = "DisDayMonthTotalGou";
            this.textBox105.Height = 0.1574803F;
            this.textBox105.Left = 8.81F;
            this.textBox105.MultiLine = false;
            this.textBox105.Name = "textBox105";
            this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
            this.textBox105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox105.SummaryGroup = "SupplierHeader";
            this.textBox105.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox105.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox105.Text = "ZZZ,ZZZ,ZZ9";
            this.textBox105.Top = 0.219F;
            this.textBox105.Width = 0.66F;
            // 
            // textMonthSupplierStockGou
            // 
            this.textMonthSupplierStockGou.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockGou.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockGou.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockGou.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockGou.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockGou.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockGou.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSupplierStockGou.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierStockGou.DataField = "NetStcPrcMonthTotalGou";
            this.textMonthSupplierStockGou.Height = 0.1574803F;
            this.textMonthSupplierStockGou.Left = 9.5F;
            this.textMonthSupplierStockGou.MultiLine = false;
            this.textMonthSupplierStockGou.Name = "textMonthSupplierStockGou";
            this.textMonthSupplierStockGou.OutputFormat = resources.GetString("textMonthSupplierStockGou.OutputFormat");
            this.textMonthSupplierStockGou.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSupplierStockGou.SummaryGroup = "SupplierHeader";
            this.textMonthSupplierStockGou.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textMonthSupplierStockGou.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textMonthSupplierStockGou.Text = "ZZZ,ZZZ,ZZ9";
            this.textMonthSupplierStockGou.Top = 0.219F;
            this.textMonthSupplierStockGou.Width = 0.66F;
            // 
            // label33
            // 
            this.label33.Border.BottomColor = System.Drawing.Color.Black;
            this.label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.LeftColor = System.Drawing.Color.Black;
            this.label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.RightColor = System.Drawing.Color.Black;
            this.label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.TopColor = System.Drawing.Color.Black;
            this.label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Height = 0.16F;
            this.label33.HyperLink = "";
            this.label33.Left = 7.36F;
            this.label33.MultiLine = false;
            this.label33.Name = "label33";
            this.label33.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label33.Text = "|";
            this.label33.Top = 0.21875F;
            this.label33.Width = 0.06F;
            // 
            // label34
            // 
            this.label34.Border.BottomColor = System.Drawing.Color.Black;
            this.label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.LeftColor = System.Drawing.Color.Black;
            this.label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.RightColor = System.Drawing.Color.Black;
            this.label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.TopColor = System.Drawing.Color.Black;
            this.label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Height = 0.16F;
            this.label34.HyperLink = "";
            this.label34.Left = 4.56F;
            this.label34.MultiLine = false;
            this.label34.Name = "label34";
            this.label34.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label34.Text = "|";
            this.label34.Top = 0.03125F;
            this.label34.Width = 0.06F;
            // 
            // label35
            // 
            this.label35.Border.BottomColor = System.Drawing.Color.Black;
            this.label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.LeftColor = System.Drawing.Color.Black;
            this.label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.RightColor = System.Drawing.Color.Black;
            this.label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.TopColor = System.Drawing.Color.Black;
            this.label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Height = 0.16F;
            this.label35.HyperLink = "";
            this.label35.Left = 4.56F;
            this.label35.MultiLine = false;
            this.label35.Name = "label35";
            this.label35.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label35.Text = "|";
            this.label35.Top = 0.21875F;
            this.label35.Width = 0.06F;
            // 
            // label36
            // 
            this.label36.Border.BottomColor = System.Drawing.Color.Black;
            this.label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.LeftColor = System.Drawing.Color.Black;
            this.label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.RightColor = System.Drawing.Color.Black;
            this.label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.TopColor = System.Drawing.Color.Black;
            this.label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Height = 0.16F;
            this.label36.HyperLink = "";
            this.label36.Left = 7.36F;
            this.label36.MultiLine = false;
            this.label36.Name = "label36";
            this.label36.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label36.Text = "|";
            this.label36.Top = 0.03125F;
            this.label36.Width = 0.06F;
            // 
            // textDaySupplierToriRate
            // 
            this.textDaySupplierToriRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySupplierToriRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierToriRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySupplierToriRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierToriRate.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySupplierToriRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierToriRate.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySupplierToriRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierToriRate.DataField = "StckToriRatioDayTotalGou";
            this.textDaySupplierToriRate.Height = 0.1574803F;
            this.textDaySupplierToriRate.Left = 10.62F;
            this.textDaySupplierToriRate.MultiLine = false;
            this.textDaySupplierToriRate.Name = "textDaySupplierToriRate";
            this.textDaySupplierToriRate.OutputFormat = resources.GetString("textDaySupplierToriRate.OutputFormat");
            this.textDaySupplierToriRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySupplierToriRate.SummaryGroup = "SupplierHeader";
            this.textDaySupplierToriRate.Text = "100.00";
            this.textDaySupplierToriRate.Top = 0.031F;
            this.textDaySupplierToriRate.Width = 0.37F;
            // 
            // textDaySupplierZaiRate
            // 
            this.textDaySupplierZaiRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textDaySupplierZaiRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierZaiRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textDaySupplierZaiRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierZaiRate.Border.RightColor = System.Drawing.Color.Black;
            this.textDaySupplierZaiRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierZaiRate.Border.TopColor = System.Drawing.Color.Black;
            this.textDaySupplierZaiRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textDaySupplierZaiRate.DataField = "StckZaiRatioDayTotalGou";
            this.textDaySupplierZaiRate.Height = 0.1574803F;
            this.textDaySupplierZaiRate.Left = 10.19F;
            this.textDaySupplierZaiRate.MultiLine = false;
            this.textDaySupplierZaiRate.Name = "textDaySupplierZaiRate";
            this.textDaySupplierZaiRate.OutputFormat = resources.GetString("textDaySupplierZaiRate.OutputFormat");
            this.textDaySupplierZaiRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textDaySupplierZaiRate.SummaryGroup = "SupplierHeader";
            this.textDaySupplierZaiRate.Text = "100.00";
            this.textDaySupplierZaiRate.Top = 0.031F;
            this.textDaySupplierZaiRate.Width = 0.37F;
            // 
            // textMonthSupplierZaiRate
            // 
            this.textMonthSupplierZaiRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSupplierZaiRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierZaiRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSupplierZaiRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierZaiRate.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSupplierZaiRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierZaiRate.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSupplierZaiRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierZaiRate.DataField = "StckZaiRatioMonthTotalGou";
            this.textMonthSupplierZaiRate.Height = 0.1574803F;
            this.textMonthSupplierZaiRate.Left = 10.19F;
            this.textMonthSupplierZaiRate.MultiLine = false;
            this.textMonthSupplierZaiRate.Name = "textMonthSupplierZaiRate";
            this.textMonthSupplierZaiRate.OutputFormat = resources.GetString("textMonthSupplierZaiRate.OutputFormat");
            this.textMonthSupplierZaiRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSupplierZaiRate.SummaryGroup = "SupplierHeader";
            this.textMonthSupplierZaiRate.Text = "100.00";
            this.textMonthSupplierZaiRate.Top = 0.219F;
            this.textMonthSupplierZaiRate.Width = 0.37F;
            // 
            // textMonthSupplierToriRate
            // 
            this.textMonthSupplierToriRate.Border.BottomColor = System.Drawing.Color.Black;
            this.textMonthSupplierToriRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierToriRate.Border.LeftColor = System.Drawing.Color.Black;
            this.textMonthSupplierToriRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierToriRate.Border.RightColor = System.Drawing.Color.Black;
            this.textMonthSupplierToriRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierToriRate.Border.TopColor = System.Drawing.Color.Black;
            this.textMonthSupplierToriRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textMonthSupplierToriRate.DataField = "StckToriRatioMonthTotalGou";
            this.textMonthSupplierToriRate.Height = 0.1574803F;
            this.textMonthSupplierToriRate.Left = 10.62F;
            this.textMonthSupplierToriRate.MultiLine = false;
            this.textMonthSupplierToriRate.Name = "textMonthSupplierToriRate";
            this.textMonthSupplierToriRate.OutputFormat = resources.GetString("textMonthSupplierToriRate.OutputFormat");
            this.textMonthSupplierToriRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textMonthSupplierToriRate.SummaryGroup = "SupplierHeader";
            this.textMonthSupplierToriRate.Text = "100.00";
            this.textMonthSupplierToriRate.Top = 0.219F;
            this.textMonthSupplierToriRate.Width = 0.37F;
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
            this.label39.Height = 0.16F;
            this.label39.HyperLink = "";
            this.label39.Left = 10.56F;
            this.label39.MultiLine = false;
            this.label39.Name = "label39";
            this.label39.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label39.Text = ":";
            this.label39.Top = 0.219F;
            this.label39.Width = 0.06F;
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
            this.label40.Height = 0.16F;
            this.label40.HyperLink = "";
            this.label40.Left = 10.56F;
            this.label40.MultiLine = false;
            this.label40.Name = "label40";
            this.label40.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label40.Text = ":";
            this.label40.Top = 0.031F;
            this.label40.Width = 0.06F;
            // 
            // DailyHeader
            // 
            this.DailyHeader.CanShrink = true;
            this.DailyHeader.Height = 0F;
            this.DailyHeader.Name = "DailyHeader";
            this.DailyHeader.Visible = false;
            // 
            // DailyFooter
            // 
            this.DailyFooter.CanShrink = true;
            this.DailyFooter.Height = 0F;
            this.DailyFooter.KeepTogether = true;
            this.DailyFooter.Name = "DailyFooter";
            this.DailyFooter.Visible = false;
            this.DailyFooter.Format += new System.EventHandler(this.DailyFooter_Format);
            // 
            // DCKOU02103P_01A4C
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
            this.PrintWidth = 10.99F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.DailyHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.DailyFooter);
            this.Sections.Add(this.SupplierFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02032P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotalTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotalZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckToriRatioMonthTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckZaiRatioMonthTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckZaiRatioDayTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckToriRatioDayTotalGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_KindTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ZaikoHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ToriyoseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoukeiHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_KindTitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StckPriceDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayTotalStockZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthTotalStockZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayTotalStockTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthTotalStockTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayTotalStockGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthTotalStockGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayGoukeiToriRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDayGoukeiZaiRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthGoukeiZaiRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthGoukeiToriRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MainSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StckPriceDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionStockZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionStockTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionStockGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionStockZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionStockTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionStockGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionToriRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySectionZaiRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionZaiRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSectionToriRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_StckPriceDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierStockZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierStockZai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierStockTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierStockTori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierStockGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierStockGou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierToriRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDaySupplierZaiRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierZaiRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMonthSupplierToriRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
