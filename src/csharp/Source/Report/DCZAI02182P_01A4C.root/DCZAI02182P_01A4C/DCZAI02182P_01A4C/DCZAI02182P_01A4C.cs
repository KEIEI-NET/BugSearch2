//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 過剰在庫一覧表
// プログラム概要   : 過剰在庫一覧表のフォームクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 作 成 日  2007.11.13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長沼 賢二
// 修 正 日  2008.07.15  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/03  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/25  修正内容 : 不具合対応[11771]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/27  修正内容 : 不具合対応[12031]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/23  修正内容 : 不具合対応[12778]
//----------------------------------------------------------------------------//
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

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 在庫過剰一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 在庫過剰一覧表のフォームクラスです。</br>
	/// <br>Programmer   : 20081 疋田 勇人</br>
	/// <br>Date         : 2007.11.13</br>
	/// <br></br>
    /// <br>UpdateNote   : 2008.07.15 30416 長沼 賢二</br>
    /// <br>             :</br>
    /// <br>UpdateNote   : 2008/10/03 30462 行澤 仁美　バグ修正</br>
    /// <br>             : 2009/02/25       照田 貴志　不具合対応[11771]</br>
    /// <br>             : 2009/02/27       上野 俊治　不具合対応[12031]</br>
    /// <br>             : 2009/04/23       照田 貴志　不具合対応[12778]</br>
    /// </remarks>
	public class DCZAI02182P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫過剰一覧表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : 在庫過剰一覧表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer   : 20081　疋田 勇人</br>
		/// <br>Date         : 2007.11.13</br>
		/// </remarks>
		public DCZAI02182P_01A4C()
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
        // ---ADD 2009/04/23 不具合対応[12778] --------------------------------------------------->>>>>
        // グループサプレス用キー
        private string _beforeCustomerCd;
        private string _beforeGoodsMakerCd;
        private string _beforeWarehouseShelfNo;
        // ---ADD 2009/04/23 不具合対応[12778] ---------------------------------------------------<<<<<

        private StockOverListCndtn _stockOverListCndtn;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;
        private TextBox textBox1;
        private TextBox ShipmentCnt;
        private TextBox StockOverCount;
        private Label label1;
        private TextBox tb_SortOrderName;
        private TextBox BLGoodsCode;
        private TextBox DuplicationShelfNo2;
        private TextBox DuplicationShelfNo1;
        private TextBox DuplicationShelfNo1_Dm;
        private TextBox DuplicationShelfNo2_Dm;
        private TextBox BLGoodsCode_Dm;
        private Label Lb_DuplicationShelfNo1;
        private Label Lb_DuplicationShelfNo2;
        private Label Lb_BLGoodsCode;
        private Label Lb_DuplicationShelfNo1_Dm;
        private Label Lb_DuplicationShelfNo2_Dm;
        private Label Lb_BLGoodsCode_Dm;
        private Line line3;
        private Line line6;
        private Line line8;
        private TextBox textBox28;
        private TextBox textBox29;
        private TextBox textBox30;
        private TextBox textBox31;
        private TextBox textBox32;
        private TextBox textBox33;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox21;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textBox36;
        private Label label4;
        private Label label5;

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
                this._stockOverListCndtn = (StockOverListCndtn)this._printInfo.jyoken;
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
				// TODO:  DCZAI02182P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  DCZAI02182P_01A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            #region ＜＜　合計行の印字有無制御　＞＞
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._stockOverListCndtn.IsOptSection ) {
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._stockOverListCndtn.SectionCodes.Length < 2 ) ||
            //        this._stockOverListCndtn.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCZAI02184EA.ct_Col_Sort_SectionCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else {
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}

            // ---DEL 2009/04/23 不具合対応[12778] ----------------------------------------------->>>>>
            //SectionHeader.DataField = DCZAI02184EA.ct_Col_Sort_SectionCode;
            //SectionHeader.Visible = true;
            //SectionFooter.Visible = true;
            // ---DEL 2009/04/23 不具合対応[12778] -----------------------------------------------<<<<<

            // 仕入先順・棚番順の選択　及び　小計印字区分の選択　により印字する合計行を選択
            GroupHeader activeHeader = null;
            GroupFooter activeFooter = null;

            // 初期化
            CustomerHeader.Visible = false;
            CustomerFooter.Visible = false;
            WarehouseShelfNoHeader.Visible = false;
            WarehouseShelfNoFooter.Visible = false;

            if (this._stockOverListCndtn.SummalyPrintDiv == StockOverListCndtn.SummalyPrintDivState.Print)
            {
                // 小計あり
                if (this._stockOverListCndtn.PrintSortDiv == StockOverListCndtn.PrintSortDivState.ByCustomer)
                {
                    CustomerHeader.DataField = "Sort_CustomerCode";     //--- ADD 2008/10/03 不具合対応[6065]
                    // 仕入先順
                    activeHeader = CustomerHeader;
                    activeFooter = CustomerFooter;
                }
                else {
                    WarehouseShelfNoHeader.DataField = "Sort_WarehouseShelfNoBreak";     //--- ADD 2008/10/03 不具合対応[6065]
                    // 棚番順
                    activeHeader = WarehouseShelfNoHeader;
                    activeFooter = WarehouseShelfNoFooter;
                }
            }

            if (activeHeader != null) {
                activeHeader.Visible = true;

                // 改ページ区分
                if (this._stockOverListCndtn.NewPageDiv == StockOverListCndtn.NewPageDivState.EachSummaly)
                {
                    // 小計毎改ページする
                    activeHeader.NewPage = NewPage.Before;
                }
                else {
                    // 小計毎改ページしない
                    activeHeader.NewPage = NewPage.None;
                }
            }
            if (activeFooter != null) {
                activeFooter.Visible = true;
            }

            tb_SortOrderName.Text = this._pageHeaderSortOderTitle;   // ソート条件

            #endregion ＜＜　合計行の印字有無制御　＞＞

            #region ＜＜　仕入先別・棚番別レイアウト制御　＞＞
            //------------------------------------------------------------------------
            // 作成時のデフォルトの配置は仕入先別のレイアウトになっています。
            // 「棚番順」が選択されている場合は、棚番別レイアウトに動的に組み替えます。
            // (ex. WarehouseShelfNo.Left ← WarehouseShelfNo_Dm.Leftをセット)
            //------------------------------------------------------------------------

            if (this._stockOverListCndtn.PrintSortDiv == StockOverListCndtn.PrintSortDivState.ByWarehouseShelfNo)
            {
                // タイトル項目
                Lb_WarehouseShelfNo.Left = Lb_WarehouseShelfNo_Dm.Left;
                Lb_GoodsNo.Left = Lb_GoodsNo_Dm.Left;
                Lb_GoodsName.Left = Lb_GoodsName_Dm.Left;
                Lb_Customer.Left = Lb_Customer_Dm.Left;
                Lb_GoodsMaker.Left = Lb_GoodsMaker_Dm.Left;
                //--- ADD 2008/07/15 ---------->>>>>
                Lb_BLGoodsCode.Left = Lb_BLGoodsCode_Dm.Left;
                Lb_DuplicationShelfNo1.Left = Lb_DuplicationShelfNo1_Dm.Left;
                Lb_DuplicationShelfNo2.Left = Lb_DuplicationShelfNo2_Dm.Left;
                //--- ADD 2008/07/15 ---------->>>>>

                // 明細項目
                WarehouseShelfNo.Left = WarehouseShelfNo_Dm.Left;
                GoodsNo.Left = GoodsNo_Dm.Left;
                GoodsName.Left = GoodsName_Dm.Left;
                CustomerCode.Left = CustomerCode_Dm.Left;
                CustomerName.Left = CustomerName_Dm.Left;
                GoodsMakerCd.Left = GoodsMakerCd_Dm.Left;
                MakerName.Left = MakerName_Dm.Left;
                //--- ADD 2008/07/15 ---------->>>>>
                BLGoodsCode.Left = BLGoodsCode_Dm.Left;
                DuplicationShelfNo1.Left = DuplicationShelfNo1_Dm.Left;
                DuplicationShelfNo2.Left = DuplicationShelfNo2_Dm.Left;
                //--- ADD 2008/07/15 ---------->>>>>
            }
            #endregion ＜＜　仕入先別・棚番別レイアウト制御　＞＞

        }
        /// <summary>
        /// 範囲月数の取得処理
        /// </summary>
        /// <returns>範囲月数（ex.４月～６月ならば３）</returns>
        private int GetMonthRange(DateTime stYearMonth, DateTime edYearMonth)
        {
            int stMonth = stYearMonth.Month;
            int edMonth = edYearMonth.Month;

            if (edYearMonth.Year > stYearMonth.Year) {
                edMonth += 12;
            }

            return (edMonth - stMonth + 1);
        }
        /// <summary>
        /// 月タイトル取得
        /// </summary>
        /// <param name="stYearMonth"></param>
        /// <param name="index"></param>
        /// <returns>月タイトル(ex.１月,２月…)</returns>
        private string GetMonthTitle(DateTime stYearMonth, int index) 
        {
            int month = stYearMonth.Month + index;
            
            if (month > 12) month -= 12;

            return (month.ToString() + "月");
        }
		#endregion ◆ レポート要素出力設定


		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。

            // ---ADD 2009/04/23 不具合対応[12778] ------------------------------------------------->>>>>
            if (this._stockOverListCndtn.PrintSortDiv == StockOverListCndtn.PrintSortDivState.ByCustomer)
            {
                // 仕入先順
                string customerCd = this.CustomerCode.Value.ToString();
                string goodsMakerCd = this.GoodsMakerCd.Value.ToString();
                if (customerCd.Equals(this._beforeCustomerCd))
                {
                    if (goodsMakerCd.Equals(this._beforeGoodsMakerCd))
                    {
                        this.CustomerCode.Visible = false;
                        this.CustomerName.Visible = false;
                        this.GoodsMakerCd.Visible = false;
                        this.MakerName.Visible = false;
                    }
                    else
                    {
                        this.CustomerCode.Visible = false;
                        this.CustomerName.Visible = false;
                        this.GoodsMakerCd.Visible = true;
                        this.MakerName.Visible = true;
                    }                    
                }
                else
                {
                    this.CustomerCode.Visible = true;
                    this.CustomerName.Visible = true;
                    this.GoodsMakerCd.Visible = true;
                    this.MakerName.Visible = true;
                }
                this._beforeCustomerCd = customerCd;
                this._beforeGoodsMakerCd = goodsMakerCd;
            }
            else
            {
                // 棚番順
                string warehouseShelfNo = this.WarehouseShelfNo.Value.ToString().Trim();
                if (warehouseShelfNo.Equals(this._beforeWarehouseShelfNo))
                {
                    this.WarehouseShelfNo.Visible = false;
                }
                else
                {
                    this.WarehouseShelfNo.Visible = true;
                }
                this._beforeWarehouseShelfNo = warehouseShelfNo;
            }
            // ---ADD 2009/04/23 不具合対応[12778] -------------------------------------------------<<<<<
        }
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

		#region ◎ DCZAI02163P_01A4C_ReportStart Event
		/// <summary>
		/// DCZAI02163P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

        #region ◎ DCZAI02163P_01A4C_PageEnd Event
        /// <summary>
		/// DCZAI02163P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DCZAI02163P_01A4C_PageEnd Event</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）

            // グループサプレス用変数初期化
            this._beforeCustomerCd = string.Empty;
            this._beforeGoodsMakerCd = string.Empty;
            this._beforeWarehouseShelfNo = string.Empty;
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString(StockOverListCndtn.ct_DateFomat, DateTime.Now);
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 拠点オプション有無判定
            //string sectionTitle = string.Format( "{0}拠点：", this._stockOverListCndtn.MainExtractTitle );
            //if ( this._stockOverListCndtn.IsOptSection )
            //{
            //    if ( this._stockOverListCndtn.IsSelectAllSection )
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
            //    }
            //    else
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    }

            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion

        // --- ADD 2009/02/27 -------------------------------->>>>>
        #region ◎ WarehouseHeader_BeforePrint Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader_BeforePrint(object sender, EventArgs e)
        {
            // ---DEL 2009/04/23 不具合対応[12778] ----------------------------->>>>>
            //// ゼロ値を表示しない
            //if (string.IsNullOrEmpty(this.Wh_SectionCode.Text)
            //    || this.Wh_SectionCode.Text.PadLeft(2, '0') == "00")
            //{
            //    this.Wh_SectionCode.Text = "";
            //    this.Wh_SectionGuideNm.Text = "";
            //}

            //if (string.IsNullOrEmpty(this.Wh_WarehouseCode.Text)
            //    || this.Wh_WarehouseCode.Text.PadLeft(4, '0') == "0000")
            //{
            //    this.Wh_WarehouseCode.Text = "";
            //    this.Wh_WarehouseName.Text = "";
            //}
            // ---DEL 2009/04/23 不具合対応[12778] -----------------------------<<<<<

            // グループサプレス用変数初期化
            this._beforeCustomerCd = string.Empty;
            this._beforeGoodsMakerCd = string.Empty;
            this._beforeWarehouseShelfNo = string.Empty;
        }
        #endregion
        // --- ADD 2009/02/27 --------------------------------<<<<<

        #region ◎ Detail_Format Event
        /// <summary>
		/// Detail_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: Detailグループのフォーマットイベント。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{

            // --- DEL 2009/04/23 不具合対応[12778] ---------------------->>>>>
            ////--- ADD 2008/10/06 不具合対応[6060] ---------->>>>>
            //if (this.CustomerCode.Value.Equals(0))
            //{
            //    this.CustomerCode.Value = "";
            //}
            ////--- ADD 2008/10/06 不具合対応[6060] ----------<<<<<
            //// --- ADD 2009/02/27 -------------------------------->>>>>
            //if (this.GoodsMakerCd.Value.Equals(0))
            //{
            //    this.GoodsMakerCd.Value = "";
            //}

            //if (this.BLGoodsCode.Value.Equals(0))
            //{
            //    this.BLGoodsCode.Value = "";
            //}
            //// --- ADD 2009/02/27 --------------------------------<<<<<
            // --- DEL 2009/04/23 不具合対応[12778] ----------------------<<<<<
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
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
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行KEY退避をクリア（次明細はサプレス解除）
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.11.13</br>
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

		#endregion ■ Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Label Lb_GoodsNo;
		private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_WarehouseShelfNo;
		private DataDynamics.ActiveReports.Label Lb_Customer;
		private DataDynamics.ActiveReports.Label Lb_Warehouse;
        private DataDynamics.ActiveReports.Label Lb_GoodsMaker;
		private DataDynamics.ActiveReports.Label Lb_MinimumStockCnt;
		private DataDynamics.ActiveReports.Label Lb_MaximumStockCnt;
        private DataDynamics.ActiveReports.Label Lb_StockTotal;
        private DataDynamics.ActiveReports.Label Lb_StockMashinePrice;
		private DataDynamics.ActiveReports.Label Lb_LastSalesDate;
		private DataDynamics.ActiveReports.Label Lb_GoodsNo_Dm;
		private DataDynamics.ActiveReports.Label Lb_GoodsName_Dm;
		private DataDynamics.ActiveReports.Label Lb_WarehouseShelfNo_Dm;
		private DataDynamics.ActiveReports.Label Lb_Customer_Dm;
        private DataDynamics.ActiveReports.Label Lb_GoodsMaker_Dm;
		private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
		private DataDynamics.ActiveReports.TextBox Wh_WarehouseCode;
		private DataDynamics.ActiveReports.TextBox Wh_WarehouseName;
		private DataDynamics.ActiveReports.Line Line7;
		private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
		private DataDynamics.ActiveReports.GroupHeader WarehouseShelfNoHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox GoodsNo;
		private DataDynamics.ActiveReports.TextBox GoodsName;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo;
		private DataDynamics.ActiveReports.TextBox MinimumStockCnt;
		private DataDynamics.ActiveReports.TextBox MaximumStockCnt;
		private DataDynamics.ActiveReports.TextBox CustomerCode;
		private DataDynamics.ActiveReports.TextBox CustomerName;
		private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
        private DataDynamics.ActiveReports.TextBox MakerName;
		private DataDynamics.ActiveReports.TextBox ShipmentPosCnt;
		private DataDynamics.ActiveReports.TextBox SalesOrderCount;
		private DataDynamics.ActiveReports.TextBox StockPrice;
		private DataDynamics.ActiveReports.TextBox LastStockDate;
		private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_Dm;
		private DataDynamics.ActiveReports.TextBox GoodsNo_Dm;
		private DataDynamics.ActiveReports.TextBox GoodsName_Dm;
		private DataDynamics.ActiveReports.TextBox CustomerCode_Dm;
		private DataDynamics.ActiveReports.TextBox CustomerName_Dm;
		private DataDynamics.ActiveReports.TextBox GoodsMakerCd_Dm;
        private DataDynamics.ActiveReports.TextBox MakerName_Dm;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt_L;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt_R;
		private DataDynamics.ActiveReports.GroupFooter WarehouseShelfNoFooter;
		private DataDynamics.ActiveReports.Line Line4;
		private DataDynamics.ActiveReports.TextBox TextBox20;
		private DataDynamics.ActiveReports.TextBox Ws_ShipmentPosCnt;
		private DataDynamics.ActiveReports.TextBox Ws_StockPrice;
		private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox Cus_StockPrice;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentPosCnt;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Wh_StockPrice;
        private DataDynamics.ActiveReports.TextBox Wh_ShipmentPosCnt;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Ttl_StockPrice;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentPosCnt;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCZAI02182P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesOrderCount = new DataDynamics.ActiveReports.TextBox();
            this.StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.LastStockDate = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_Dm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo_Dm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd_Dm = new DataDynamics.ActiveReports.TextBox();
            this.MakerName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt_L = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt_R = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.StockOverCount = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.DuplicationShelfNo2 = new DataDynamics.ActiveReports.TextBox();
            this.DuplicationShelfNo1 = new DataDynamics.ActiveReports.TextBox();
            this.DuplicationShelfNo1_Dm = new DataDynamics.ActiveReports.TextBox();
            this.DuplicationShelfNo2_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_GoodsNo_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_Customer_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMaker_Dm = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Lb_DuplicationShelfNo1_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_DuplicationShelfNo2_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_Warehouse = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.Lb_Customer = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMaker = new DataDynamics.ActiveReports.Label();
            this.Lb_DuplicationShelfNo1 = new DataDynamics.ActiveReports.Label();
            this.Lb_DuplicationShelfNo2 = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo = new DataDynamics.ActiveReports.Label();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.Lb_StockMashinePrice = new DataDynamics.ActiveReports.Label();
            this.Lb_LastSalesDate = new DataDynamics.ActiveReports.Label();
            this.Lb_StockTotal = new DataDynamics.ActiveReports.Label();
            this.Lb_MaximumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MinimumStockCnt = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Wh_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.Wh_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Wh_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Cus_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNoHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseShelfNoFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.Ws_ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ws_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastStockDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockOverCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo1_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo2_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo1_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo2_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LastSalesDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ShipmentCnt,
            this.GoodsNo,
            this.GoodsName,
            this.WarehouseShelfNo,
            this.MinimumStockCnt,
            this.MaximumStockCnt,
            this.CustomerCode,
            this.CustomerName,
            this.GoodsMakerCd,
            this.MakerName,
            this.ShipmentPosCnt,
            this.SalesOrderCount,
            this.StockPrice,
            this.LastStockDate,
            this.GoodsNo_Dm,
            this.CustomerCode_Dm,
            this.CustomerName_Dm,
            this.GoodsMakerCd_Dm,
            this.MakerName_Dm,
            this.ShipmentCnt_L,
            this.ShipmentCnt_R,
            this.textBox1,
            this.StockOverCount,
            this.BLGoodsCode,
            this.DuplicationShelfNo2,
            this.DuplicationShelfNo1,
            this.DuplicationShelfNo1_Dm,
            this.DuplicationShelfNo2_Dm,
            this.line8,
            this.WarehouseShelfNo_Dm,
            this.BLGoodsCode_Dm,
            this.GoodsName_Dm});
            this.Detail.Height = 0.4583333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // ShipmentCnt
            // 
            this.ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.DataField = "ShipmentCnt";
            this.ShipmentCnt.Height = 0.15625F;
            this.ShipmentCnt.Left = 8.1875F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.ShipmentCnt.Text = "123,456";
            this.ShipmentCnt.Top = 0.0625F;
            this.ShipmentCnt.Width = 0.4375F;
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
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.15625F;
            this.GoodsNo.Left = 2.8125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.375F;
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
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.15625F;
            this.GoodsName.Left = 4.1875F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.1875F;
            // 
            // WarehouseShelfNo
            // 
            this.WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo.Height = 0.15625F;
            this.WarehouseShelfNo.Left = 5.375F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0.0625F;
            this.WarehouseShelfNo.Width = 0.5F;
            // 
            // MinimumStockCnt
            // 
            this.MinimumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.DataField = "MinimumStockCnt";
            this.MinimumStockCnt.Height = 0.15625F;
            this.MinimumStockCnt.Left = 5.875F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.MinimumStockCnt.Text = "123,456";
            this.MinimumStockCnt.Top = 0.0625F;
            this.MinimumStockCnt.Width = 0.5F;
            // 
            // MaximumStockCnt
            // 
            this.MaximumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.DataField = "MaximumStockCnt";
            this.MaximumStockCnt.Height = 0.15625F;
            this.MaximumStockCnt.Left = 6.375F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.MaximumStockCnt.Text = "123,456";
            this.MaximumStockCnt.Top = 0.0625F;
            this.MaximumStockCnt.Width = 0.5F;
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
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.15625F;
            this.CustomerCode.Left = 0.0625F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CustomerCode.Text = "123456";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.375F;
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
            this.CustomerName.DataField = "CustomerName";
            this.CustomerName.Height = 0.15625F;
            this.CustomerName.Left = 0.4375F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OutputFormat = resources.GetString("CustomerName.OutputFormat");
            this.CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerName.Text = "あいうえおかきく";
            this.CustomerName.Top = 0.0625F;
            this.CustomerName.Width = 0.9375F;
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.15625F;
            this.GoodsMakerCd.Left = 1.375F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.0625F;
            this.GoodsMakerCd.Width = 0.25F;
            // 
            // MakerName
            // 
            this.MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.DataField = "MakerName";
            this.MakerName.Height = 0.15625F;
            this.MakerName.Left = 1.625F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえお";
            this.MakerName.Top = 0.0625F;
            this.MakerName.Width = 0.625F;
            // 
            // ShipmentPosCnt
            // 
            this.ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.ShipmentPosCnt.Height = 0.15625F;
            this.ShipmentPosCnt.Left = 6.875F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.ShipmentPosCnt.Text = "1,234,567";
            this.ShipmentPosCnt.Top = 0.0625F;
            this.ShipmentPosCnt.Width = 0.625F;
            // 
            // SalesOrderCount
            // 
            this.SalesOrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.DataField = "SalesOrderCount";
            this.SalesOrderCount.Height = 0.15625F;
            this.SalesOrderCount.Left = 7.625F;
            this.SalesOrderCount.MultiLine = false;
            this.SalesOrderCount.Name = "SalesOrderCount";
            this.SalesOrderCount.OutputFormat = resources.GetString("SalesOrderCount.OutputFormat");
            this.SalesOrderCount.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.SalesOrderCount.Text = "123,456";
            this.SalesOrderCount.Top = 0.0625F;
            this.SalesOrderCount.Width = 0.4375F;
            // 
            // StockPrice
            // 
            this.StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.DataField = "StockPrice";
            this.StockPrice.Height = 0.15625F;
            this.StockPrice.Left = 9.3125F;
            this.StockPrice.MultiLine = false;
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.OutputFormat = resources.GetString("StockPrice.OutputFormat");
            this.StockPrice.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.StockPrice.Text = "1,234,567,890";
            this.StockPrice.Top = 0.0625F;
            this.StockPrice.Width = 0.8125F;
            // 
            // LastStockDate
            // 
            this.LastStockDate.Border.BottomColor = System.Drawing.Color.Black;
            this.LastStockDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastStockDate.Border.LeftColor = System.Drawing.Color.Black;
            this.LastStockDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastStockDate.Border.RightColor = System.Drawing.Color.Black;
            this.LastStockDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastStockDate.Border.TopColor = System.Drawing.Color.Black;
            this.LastStockDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastStockDate.DataField = "LastStockDate";
            this.LastStockDate.Height = 0.15625F;
            this.LastStockDate.Left = 10.125F;
            this.LastStockDate.MultiLine = false;
            this.LastStockDate.Name = "LastStockDate";
            this.LastStockDate.OutputFormat = resources.GetString("LastStockDate.OutputFormat");
            this.LastStockDate.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.LastStockDate.Text = "99/99/99";
            this.LastStockDate.Top = 0.0625F;
            this.LastStockDate.Width = 0.625F;
            // 
            // WarehouseShelfNo_Dm
            // 
            this.WarehouseShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Dm.DataField = "Sort_WarehouseShelfNoBreak";
            this.WarehouseShelfNo_Dm.DistinctField = "Sort_WarehouseShelfNo";
            this.WarehouseShelfNo_Dm.Height = 0.156F;
            this.WarehouseShelfNo_Dm.Left = 0.0625F;
            this.WarehouseShelfNo_Dm.MultiLine = false;
            this.WarehouseShelfNo_Dm.Name = "WarehouseShelfNo_Dm";
            this.WarehouseShelfNo_Dm.OutputFormat = resources.GetString("WarehouseShelfNo_Dm.OutputFormat");
            this.WarehouseShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseShelfNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.WarehouseShelfNo_Dm.Text = "12345678";
            this.WarehouseShelfNo_Dm.Top = 0.25F;
            this.WarehouseShelfNo_Dm.Visible = false;
            this.WarehouseShelfNo_Dm.Width = 0.5F;
            // 
            // GoodsNo_Dm
            // 
            this.GoodsNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Dm.DataField = "GoodsNo";
            this.GoodsNo_Dm.Height = 0.15625F;
            this.GoodsNo_Dm.Left = 1.125F;
            this.GoodsNo_Dm.MultiLine = false;
            this.GoodsNo_Dm.Name = "GoodsNo_Dm";
            this.GoodsNo_Dm.OutputFormat = resources.GetString("GoodsNo_Dm.OutputFormat");
            this.GoodsNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.GoodsNo_Dm.Text = "123456789012345678901234";
            this.GoodsNo_Dm.Top = 0.25F;
            this.GoodsNo_Dm.Visible = false;
            this.GoodsNo_Dm.Width = 1.375F;
            // 
            // GoodsName_Dm
            // 
            this.GoodsName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Dm.DataField = "GoodsName";
            this.GoodsName_Dm.Height = 0.15625F;
            this.GoodsName_Dm.Left = 2.5F;
            this.GoodsName_Dm.MultiLine = false;
            this.GoodsName_Dm.Name = "GoodsName_Dm";
            this.GoodsName_Dm.OutputFormat = resources.GetString("GoodsName_Dm.OutputFormat");
            this.GoodsName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.GoodsName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.GoodsName_Dm.Text = "12345678901234567890";
            this.GoodsName_Dm.Top = 0.25F;
            this.GoodsName_Dm.Visible = false;
            this.GoodsName_Dm.Width = 1.1875F;
            // 
            // CustomerCode_Dm
            // 
            this.CustomerCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode_Dm.DataField = "CustomerCode";
            this.CustomerCode_Dm.Height = 0.15625F;
            this.CustomerCode_Dm.Left = 3.6875F;
            this.CustomerCode_Dm.MultiLine = false;
            this.CustomerCode_Dm.Name = "CustomerCode_Dm";
            this.CustomerCode_Dm.OutputFormat = resources.GetString("CustomerCode_Dm.OutputFormat");
            this.CustomerCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family:" +
                " ＭＳ 明朝; vertical-align: top; ";
            this.CustomerCode_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.CustomerCode_Dm.Text = "123456";
            this.CustomerCode_Dm.Top = 0.25F;
            this.CustomerCode_Dm.Visible = false;
            this.CustomerCode_Dm.Width = 0.375F;
            // 
            // CustomerName_Dm
            // 
            this.CustomerName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName_Dm.DataField = "CustomerName";
            this.CustomerName_Dm.Height = 0.15625F;
            this.CustomerName_Dm.Left = 4.0625F;
            this.CustomerName_Dm.MultiLine = false;
            this.CustomerName_Dm.Name = "CustomerName_Dm";
            this.CustomerName_Dm.OutputFormat = resources.GetString("CustomerName_Dm.OutputFormat");
            this.CustomerName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.CustomerName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.CustomerName_Dm.Text = "あいうえおかきく";
            this.CustomerName_Dm.Top = 0.25F;
            this.CustomerName_Dm.Visible = false;
            this.CustomerName_Dm.Width = 0.9375F;
            // 
            // GoodsMakerCd_Dm
            // 
            this.GoodsMakerCd_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Dm.DataField = "GoodsMakerCd";
            this.GoodsMakerCd_Dm.Height = 0.15625F;
            this.GoodsMakerCd_Dm.Left = 5F;
            this.GoodsMakerCd_Dm.MultiLine = false;
            this.GoodsMakerCd_Dm.Name = "GoodsMakerCd_Dm";
            this.GoodsMakerCd_Dm.OutputFormat = resources.GetString("GoodsMakerCd_Dm.OutputFormat");
            this.GoodsMakerCd_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family:" +
                " ＭＳ 明朝; vertical-align: top; ";
            this.GoodsMakerCd_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.GoodsMakerCd_Dm.Text = "1234";
            this.GoodsMakerCd_Dm.Top = 0.25F;
            this.GoodsMakerCd_Dm.Visible = false;
            this.GoodsMakerCd_Dm.Width = 0.25F;
            // 
            // MakerName_Dm
            // 
            this.MakerName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Dm.DataField = "MakerName";
            this.MakerName_Dm.Height = 0.15625F;
            this.MakerName_Dm.Left = 5.25F;
            this.MakerName_Dm.MultiLine = false;
            this.MakerName_Dm.Name = "MakerName_Dm";
            this.MakerName_Dm.OutputFormat = resources.GetString("MakerName_Dm.OutputFormat");
            this.MakerName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.MakerName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.MakerName_Dm.Text = "あいうえお";
            this.MakerName_Dm.Top = 0.25F;
            this.MakerName_Dm.Visible = false;
            this.MakerName_Dm.Width = 0.625F;
            // 
            // ShipmentCnt_L
            // 
            this.ShipmentCnt_L.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt_L.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_L.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt_L.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_L.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt_L.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_L.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt_L.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_L.Height = 0.15625F;
            this.ShipmentCnt_L.Left = 7.5F;
            this.ShipmentCnt_L.MultiLine = false;
            this.ShipmentCnt_L.Name = "ShipmentCnt_L";
            this.ShipmentCnt_L.OutputFormat = resources.GetString("ShipmentCnt_L.OutputFormat");
            this.ShipmentCnt_L.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.ShipmentCnt_L.Text = "(";
            this.ShipmentCnt_L.Top = 0.0625F;
            this.ShipmentCnt_L.Width = 0.125F;
            // 
            // ShipmentCnt_R
            // 
            this.ShipmentCnt_R.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt_R.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_R.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt_R.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_R.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt_R.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_R.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt_R.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt_R.Height = 0.15625F;
            this.ShipmentCnt_R.Left = 8.625F;
            this.ShipmentCnt_R.MultiLine = false;
            this.ShipmentCnt_R.Name = "ShipmentCnt_R";
            this.ShipmentCnt_R.OutputFormat = resources.GetString("ShipmentCnt_R.OutputFormat");
            this.ShipmentCnt_R.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ShipmentCnt_R.Text = ")";
            this.ShipmentCnt_R.Top = 0.0625F;
            this.ShipmentCnt_R.Width = 0.125F;
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
            this.textBox1.Height = 0.15625F;
            this.textBox1.Left = 8.0625F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox1.Text = "：";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.125F;
            // 
            // StockOverCount
            // 
            this.StockOverCount.Border.BottomColor = System.Drawing.Color.Black;
            this.StockOverCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockOverCount.Border.LeftColor = System.Drawing.Color.Black;
            this.StockOverCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockOverCount.Border.RightColor = System.Drawing.Color.Black;
            this.StockOverCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockOverCount.Border.TopColor = System.Drawing.Color.Black;
            this.StockOverCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockOverCount.DataField = "StockOverCount";
            this.StockOverCount.Height = 0.15625F;
            this.StockOverCount.Left = 8.75F;
            this.StockOverCount.MultiLine = false;
            this.StockOverCount.Name = "StockOverCount";
            this.StockOverCount.OutputFormat = resources.GetString("StockOverCount.OutputFormat");
            this.StockOverCount.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.StockOverCount.Text = "1,234,567";
            this.StockOverCount.Top = 0.0625F;
            this.StockOverCount.Width = 0.5625F;
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
            this.BLGoodsCode.DataField = "BLGoodsCode";
            this.BLGoodsCode.Height = 0.15625F;
            this.BLGoodsCode.Left = 2.5F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0.0625F;
            this.BLGoodsCode.Width = 0.3125F;
            // 
            // DuplicationShelfNo2
            // 
            this.DuplicationShelfNo2.Border.BottomColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2.Border.LeftColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2.Border.RightColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2.Border.TopColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2.DataField = "PartsManagementDivide2";
            this.DuplicationShelfNo2.Height = 0.15625F;
            this.DuplicationShelfNo2.Left = 2.375F;
            this.DuplicationShelfNo2.MultiLine = false;
            this.DuplicationShelfNo2.Name = "DuplicationShelfNo2";
            this.DuplicationShelfNo2.OutputFormat = resources.GetString("DuplicationShelfNo2.OutputFormat");
            this.DuplicationShelfNo2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DuplicationShelfNo2.Text = "1";
            this.DuplicationShelfNo2.Top = 0.0625F;
            this.DuplicationShelfNo2.Width = 0.125F;
            // 
            // DuplicationShelfNo1
            // 
            this.DuplicationShelfNo1.Border.BottomColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1.Border.LeftColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1.Border.RightColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1.Border.TopColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1.DataField = "PartsManagementDivide1";
            this.DuplicationShelfNo1.Height = 0.15625F;
            this.DuplicationShelfNo1.Left = 2.25F;
            this.DuplicationShelfNo1.MultiLine = false;
            this.DuplicationShelfNo1.Name = "DuplicationShelfNo1";
            this.DuplicationShelfNo1.OutputFormat = resources.GetString("DuplicationShelfNo1.OutputFormat");
            this.DuplicationShelfNo1.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DuplicationShelfNo1.Text = "1";
            this.DuplicationShelfNo1.Top = 0.0625F;
            this.DuplicationShelfNo1.Width = 0.125F;
            // 
            // DuplicationShelfNo1_Dm
            // 
            this.DuplicationShelfNo1_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo1_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo1_Dm.DataField = "GoodsNo";
            this.DuplicationShelfNo1_Dm.Height = 0.156F;
            this.DuplicationShelfNo1_Dm.Left = 0.5625F;
            this.DuplicationShelfNo1_Dm.MultiLine = false;
            this.DuplicationShelfNo1_Dm.Name = "DuplicationShelfNo1_Dm";
            this.DuplicationShelfNo1_Dm.OutputFormat = resources.GetString("DuplicationShelfNo1_Dm.OutputFormat");
            this.DuplicationShelfNo1_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.DuplicationShelfNo1_Dm.Text = "1";
            this.DuplicationShelfNo1_Dm.Top = 0.25F;
            this.DuplicationShelfNo1_Dm.Visible = false;
            this.DuplicationShelfNo1_Dm.Width = 0.125F;
            // 
            // DuplicationShelfNo2_Dm
            // 
            this.DuplicationShelfNo2_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.DuplicationShelfNo2_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DuplicationShelfNo2_Dm.DataField = "GoodsNo";
            this.DuplicationShelfNo2_Dm.Height = 0.156F;
            this.DuplicationShelfNo2_Dm.Left = 0.6875F;
            this.DuplicationShelfNo2_Dm.MultiLine = false;
            this.DuplicationShelfNo2_Dm.Name = "DuplicationShelfNo2_Dm";
            this.DuplicationShelfNo2_Dm.OutputFormat = resources.GetString("DuplicationShelfNo2_Dm.OutputFormat");
            this.DuplicationShelfNo2_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.DuplicationShelfNo2_Dm.Text = "1";
            this.DuplicationShelfNo2_Dm.Top = 0.25F;
            this.DuplicationShelfNo2_Dm.Visible = false;
            this.DuplicationShelfNo2_Dm.Width = 0.125F;
            // 
            // BLGoodsCode_Dm
            // 
            this.BLGoodsCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Dm.DataField = "GoodsNo";
            this.BLGoodsCode_Dm.Height = 0.156F;
            this.BLGoodsCode_Dm.Left = 0.8125F;
            this.BLGoodsCode_Dm.MultiLine = false;
            this.BLGoodsCode_Dm.Name = "BLGoodsCode_Dm";
            this.BLGoodsCode_Dm.OutputFormat = resources.GetString("BLGoodsCode_Dm.OutputFormat");
            this.BLGoodsCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BLGoodsCode_Dm.Text = "12345";
            this.BLGoodsCode_Dm.Top = 0.25F;
            this.BLGoodsCode_Dm.Visible = false;
            this.BLGoodsCode_Dm.Width = 0.3125F;
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
            this.label4.Height = 0.15625F;
            this.label4.HyperLink = "";
            this.label4.Left = 7.625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "発残";
            this.label4.Top = 0.25F;
            this.label4.Width = 0.4375F;
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
            this.label5.Left = 8.1875F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "貸出";
            this.label5.Top = 0.25F;
            this.label5.Width = 0.4375F;
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
            this.label1.Left = 8.75F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "過剰数";
            this.label1.Top = 0.25F;
            this.label1.Width = 0.5625F;
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
            this.textBox35.Height = 0.15625F;
            this.textBox35.Left = 7.5F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.textBox35.Text = "(";
            this.textBox35.Top = 0.25F;
            this.textBox35.Width = 0.125F;
            // 
            // textBox36
            // 
            this.textBox36.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.RightColor = System.Drawing.Color.Black;
            this.textBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.TopColor = System.Drawing.Color.Black;
            this.textBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Height = 0.15625F;
            this.textBox36.Left = 8.0625F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.textBox36.Text = "：";
            this.textBox36.Top = 0.25F;
            this.textBox36.Width = 0.125F;
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
            this.tb_SortOrderName});
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
            this.tb_ReportTitle.Text = "在庫過剰一覧表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.40625F;
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
            this.tb_SortOrderName.Left = 3.354167F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.0625F;
            this.tb_SortOrderName.Width = 2.0625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2388889F;
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
            this.ExtraHeader.Height = 0.5520833F;
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
            this.Lb_GoodsNo_Dm,
            this.Lb_GoodsName_Dm,
            this.Lb_WarehouseShelfNo_Dm,
            this.Lb_Customer_Dm,
            this.Lb_GoodsMaker_Dm,
            this.Line5,
            this.Lb_DuplicationShelfNo1_Dm,
            this.Lb_DuplicationShelfNo2_Dm,
            this.Lb_BLGoodsCode_Dm,
            this.Lb_Warehouse,
            this.line6,
            this.Lb_GoodsMaker,
            this.Lb_DuplicationShelfNo1,
            this.Lb_DuplicationShelfNo2,
            this.Lb_BLGoodsCode,
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.Lb_WarehouseShelfNo,
            this.Lb_StockMashinePrice,
            this.Lb_LastSalesDate,
            this.Lb_StockTotal,
            this.Lb_MaximumStockCnt,
            this.Lb_MinimumStockCnt,
            this.Lb_Customer,
            this.label1,
            this.label5,
            this.label4,
            this.textBox35,
            this.textBox36,
            this.textBox34});
            this.TitleHeader.Height = 0.6354167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_GoodsNo_Dm
            // 
            this.Lb_GoodsNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo_Dm.Height = 0.15625F;
            this.Lb_GoodsNo_Dm.HyperLink = "";
            this.Lb_GoodsNo_Dm.Left = 1.125F;
            this.Lb_GoodsNo_Dm.MultiLine = false;
            this.Lb_GoodsNo_Dm.Name = "Lb_GoodsNo_Dm";
            this.Lb_GoodsNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_GoodsNo_Dm.Text = "品番";
            this.Lb_GoodsNo_Dm.Top = 0.4375F;
            this.Lb_GoodsNo_Dm.Visible = false;
            this.Lb_GoodsNo_Dm.Width = 1.375F;
            // 
            // Lb_GoodsName_Dm
            // 
            this.Lb_GoodsName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName_Dm.Height = 0.15625F;
            this.Lb_GoodsName_Dm.HyperLink = "";
            this.Lb_GoodsName_Dm.Left = 2.5F;
            this.Lb_GoodsName_Dm.MultiLine = false;
            this.Lb_GoodsName_Dm.Name = "Lb_GoodsName_Dm";
            this.Lb_GoodsName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_GoodsName_Dm.Text = "品名";
            this.Lb_GoodsName_Dm.Top = 0.4375F;
            this.Lb_GoodsName_Dm.Visible = false;
            this.Lb_GoodsName_Dm.Width = 1.1875F;
            // 
            // Lb_WarehouseShelfNo_Dm
            // 
            this.Lb_WarehouseShelfNo_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo_Dm.Height = 0.15625F;
            this.Lb_WarehouseShelfNo_Dm.HyperLink = "";
            this.Lb_WarehouseShelfNo_Dm.Left = 0.0625F;
            this.Lb_WarehouseShelfNo_Dm.MultiLine = false;
            this.Lb_WarehouseShelfNo_Dm.Name = "Lb_WarehouseShelfNo_Dm";
            this.Lb_WarehouseShelfNo_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_WarehouseShelfNo_Dm.Text = "棚番";
            this.Lb_WarehouseShelfNo_Dm.Top = 0.4375F;
            this.Lb_WarehouseShelfNo_Dm.Visible = false;
            this.Lb_WarehouseShelfNo_Dm.Width = 0.5F;
            // 
            // Lb_Customer_Dm
            // 
            this.Lb_Customer_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer_Dm.Height = 0.15625F;
            this.Lb_Customer_Dm.HyperLink = "";
            this.Lb_Customer_Dm.Left = 3.6875F;
            this.Lb_Customer_Dm.MultiLine = false;
            this.Lb_Customer_Dm.Name = "Lb_Customer_Dm";
            this.Lb_Customer_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_Customer_Dm.Text = "仕入先";
            this.Lb_Customer_Dm.Top = 0.4375F;
            this.Lb_Customer_Dm.Visible = false;
            this.Lb_Customer_Dm.Width = 1.3125F;
            // 
            // Lb_GoodsMaker_Dm
            // 
            this.Lb_GoodsMaker_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker_Dm.Height = 0.15625F;
            this.Lb_GoodsMaker_Dm.HyperLink = "";
            this.Lb_GoodsMaker_Dm.Left = 5F;
            this.Lb_GoodsMaker_Dm.MultiLine = false;
            this.Lb_GoodsMaker_Dm.Name = "Lb_GoodsMaker_Dm";
            this.Lb_GoodsMaker_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMaker_Dm.Tag = "※レイアウト配置の為のダミーです。";
            this.Lb_GoodsMaker_Dm.Text = "メーカー";
            this.Lb_GoodsMaker_Dm.Top = 0.4375F;
            this.Lb_GoodsMaker_Dm.Visible = false;
            this.Lb_GoodsMaker_Dm.Width = 0.875F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 2F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 10.8F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // Lb_DuplicationShelfNo1_Dm
            // 
            this.Lb_DuplicationShelfNo1_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1_Dm.Height = 0.15625F;
            this.Lb_DuplicationShelfNo1_Dm.HyperLink = "";
            this.Lb_DuplicationShelfNo1_Dm.Left = 0.5625F;
            this.Lb_DuplicationShelfNo1_Dm.MultiLine = false;
            this.Lb_DuplicationShelfNo1_Dm.Name = "Lb_DuplicationShelfNo1_Dm";
            this.Lb_DuplicationShelfNo1_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DuplicationShelfNo1_Dm.Text = "１";
            this.Lb_DuplicationShelfNo1_Dm.Top = 0.4375F;
            this.Lb_DuplicationShelfNo1_Dm.Visible = false;
            this.Lb_DuplicationShelfNo1_Dm.Width = 0.125F;
            // 
            // Lb_DuplicationShelfNo2_Dm
            // 
            this.Lb_DuplicationShelfNo2_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2_Dm.Height = 0.15625F;
            this.Lb_DuplicationShelfNo2_Dm.HyperLink = "";
            this.Lb_DuplicationShelfNo2_Dm.Left = 0.6875F;
            this.Lb_DuplicationShelfNo2_Dm.MultiLine = false;
            this.Lb_DuplicationShelfNo2_Dm.Name = "Lb_DuplicationShelfNo2_Dm";
            this.Lb_DuplicationShelfNo2_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DuplicationShelfNo2_Dm.Text = "２";
            this.Lb_DuplicationShelfNo2_Dm.Top = 0.4375F;
            this.Lb_DuplicationShelfNo2_Dm.Visible = false;
            this.Lb_DuplicationShelfNo2_Dm.Width = 0.125F;
            // 
            // Lb_BLGoodsCode_Dm
            // 
            this.Lb_BLGoodsCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode_Dm.Height = 0.15625F;
            this.Lb_BLGoodsCode_Dm.HyperLink = "";
            this.Lb_BLGoodsCode_Dm.Left = 0.8125F;
            this.Lb_BLGoodsCode_Dm.MultiLine = false;
            this.Lb_BLGoodsCode_Dm.Name = "Lb_BLGoodsCode_Dm";
            this.Lb_BLGoodsCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode_Dm.Text = "BLCD";
            this.Lb_BLGoodsCode_Dm.Top = 0.4375F;
            this.Lb_BLGoodsCode_Dm.Visible = false;
            this.Lb_BLGoodsCode_Dm.Width = 0.3125F;
            // 
            // Lb_Warehouse
            // 
            this.Lb_Warehouse.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Height = 0.1875F;
            this.Lb_Warehouse.HyperLink = "";
            this.Lb_Warehouse.Left = 0F;
            this.Lb_Warehouse.MultiLine = false;
            this.Lb_Warehouse.Name = "Lb_Warehouse";
            this.Lb_Warehouse.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Warehouse.Text = "倉庫";
            this.Lb_Warehouse.Top = 0.0625F;
            this.Lb_Warehouse.Width = 1.5F;
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
            this.line6.Top = 0.21F;
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0.21F;
            this.line6.Y2 = 0.21F;
            // 
            // Lb_Customer
            // 
            this.Lb_Customer.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Height = 0.15625F;
            this.Lb_Customer.HyperLink = "";
            this.Lb_Customer.Left = 0.0625F;
            this.Lb_Customer.MultiLine = false;
            this.Lb_Customer.Name = "Lb_Customer";
            this.Lb_Customer.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer.Text = "仕入先";
            this.Lb_Customer.Top = 0.25F;
            this.Lb_Customer.Width = 1.3125F;
            // 
            // Lb_GoodsMaker
            // 
            this.Lb_GoodsMaker.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Height = 0.15625F;
            this.Lb_GoodsMaker.HyperLink = "";
            this.Lb_GoodsMaker.Left = 1.375F;
            this.Lb_GoodsMaker.MultiLine = false;
            this.Lb_GoodsMaker.Name = "Lb_GoodsMaker";
            this.Lb_GoodsMaker.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMaker.Text = "メーカー";
            this.Lb_GoodsMaker.Top = 0.25F;
            this.Lb_GoodsMaker.Width = 0.875F;
            // 
            // Lb_DuplicationShelfNo1
            // 
            this.Lb_DuplicationShelfNo1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo1.Height = 0.15625F;
            this.Lb_DuplicationShelfNo1.HyperLink = "";
            this.Lb_DuplicationShelfNo1.Left = 2.25F;
            this.Lb_DuplicationShelfNo1.MultiLine = false;
            this.Lb_DuplicationShelfNo1.Name = "Lb_DuplicationShelfNo1";
            this.Lb_DuplicationShelfNo1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DuplicationShelfNo1.Text = "１";
            this.Lb_DuplicationShelfNo1.Top = 0.25F;
            this.Lb_DuplicationShelfNo1.Width = 0.125F;
            // 
            // Lb_DuplicationShelfNo2
            // 
            this.Lb_DuplicationShelfNo2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DuplicationShelfNo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DuplicationShelfNo2.Height = 0.15625F;
            this.Lb_DuplicationShelfNo2.HyperLink = "";
            this.Lb_DuplicationShelfNo2.Left = 2.375F;
            this.Lb_DuplicationShelfNo2.MultiLine = false;
            this.Lb_DuplicationShelfNo2.Name = "Lb_DuplicationShelfNo2";
            this.Lb_DuplicationShelfNo2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DuplicationShelfNo2.Text = "２";
            this.Lb_DuplicationShelfNo2.Top = 0.25F;
            this.Lb_DuplicationShelfNo2.Width = 0.125F;
            // 
            // Lb_BLGoodsCode
            // 
            this.Lb_BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Height = 0.15625F;
            this.Lb_BLGoodsCode.HyperLink = "";
            this.Lb_BLGoodsCode.Left = 2.5F;
            this.Lb_BLGoodsCode.MultiLine = false;
            this.Lb_BLGoodsCode.Name = "Lb_BLGoodsCode";
            this.Lb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode.Text = "BLCD";
            this.Lb_BLGoodsCode.Top = 0.25F;
            this.Lb_BLGoodsCode.Width = 0.3125F;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 2.8125F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.25F;
            this.Lb_GoodsNo.Width = 1.375F;
            // 
            // Lb_GoodsName
            // 
            this.Lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Height = 0.15625F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 4.1875F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.25F;
            this.Lb_GoodsName.Width = 1.1875F;
            // 
            // Lb_WarehouseShelfNo
            // 
            this.Lb_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Height = 0.15625F;
            this.Lb_WarehouseShelfNo.HyperLink = "";
            this.Lb_WarehouseShelfNo.Left = 5.375F;
            this.Lb_WarehouseShelfNo.MultiLine = false;
            this.Lb_WarehouseShelfNo.Name = "Lb_WarehouseShelfNo";
            this.Lb_WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo.Text = "棚番";
            this.Lb_WarehouseShelfNo.Top = 0.25F;
            this.Lb_WarehouseShelfNo.Width = 0.5F;
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
            this.textBox34.Height = 0.15625F;
            this.textBox34.Left = 8.625F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox34.Text = ")";
            this.textBox34.Top = 0.25F;
            this.textBox34.Width = 0.125F;
            // 
            // Lb_StockMashinePrice
            // 
            this.Lb_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Height = 0.15625F;
            this.Lb_StockMashinePrice.HyperLink = "";
            this.Lb_StockMashinePrice.Left = 9.3125F;
            this.Lb_StockMashinePrice.MultiLine = false;
            this.Lb_StockMashinePrice.Name = "Lb_StockMashinePrice";
            this.Lb_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockMashinePrice.Text = "在庫金額";
            this.Lb_StockMashinePrice.Top = 0.25F;
            this.Lb_StockMashinePrice.Width = 0.8125F;
            // 
            // Lb_LastSalesDate
            // 
            this.Lb_LastSalesDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_LastSalesDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LastSalesDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_LastSalesDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LastSalesDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_LastSalesDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LastSalesDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_LastSalesDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LastSalesDate.Height = 0.15625F;
            this.Lb_LastSalesDate.HyperLink = "";
            this.Lb_LastSalesDate.Left = 10.125F;
            this.Lb_LastSalesDate.MultiLine = false;
            this.Lb_LastSalesDate.Name = "Lb_LastSalesDate";
            this.Lb_LastSalesDate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_LastSalesDate.Text = "最終仕入日";
            this.Lb_LastSalesDate.Top = 0.25F;
            this.Lb_LastSalesDate.Width = 0.625F;
            // 
            // Lb_StockTotal
            // 
            this.Lb_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Height = 0.15625F;
            this.Lb_StockTotal.HyperLink = "";
            this.Lb_StockTotal.Left = 6.875F;
            this.Lb_StockTotal.MultiLine = false;
            this.Lb_StockTotal.Name = "Lb_StockTotal";
            this.Lb_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockTotal.Text = "現在庫";
            this.Lb_StockTotal.Top = 0.25F;
            this.Lb_StockTotal.Width = 0.625F;
            // 
            // Lb_MaximumStockCnt
            // 
            this.Lb_MaximumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Height = 0.15625F;
            this.Lb_MaximumStockCnt.HyperLink = "";
            this.Lb_MaximumStockCnt.Left = 6.375F;
            this.Lb_MaximumStockCnt.MultiLine = false;
            this.Lb_MaximumStockCnt.Name = "Lb_MaximumStockCnt";
            this.Lb_MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MaximumStockCnt.Text = "最高数";
            this.Lb_MaximumStockCnt.Top = 0.25F;
            this.Lb_MaximumStockCnt.Width = 0.5F;
            // 
            // Lb_MinimumStockCnt
            // 
            this.Lb_MinimumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Height = 0.15625F;
            this.Lb_MinimumStockCnt.HyperLink = "";
            this.Lb_MinimumStockCnt.Left = 5.875F;
            this.Lb_MinimumStockCnt.MultiLine = false;
            this.Lb_MinimumStockCnt.Name = "Lb_MinimumStockCnt";
            this.Lb_MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MinimumStockCnt.Text = "最低数";
            this.Lb_MinimumStockCnt.Top = 0.25F;
            this.Lb_MinimumStockCnt.Width = 0.5F;
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
            this.Ttl_StockPrice,
            this.Ttl_ShipmentPosCnt,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox33});
            this.GrandTotalFooter.Height = 0.25F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.ALLTOTALTITLE.Left = 5.375F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.031F;
            this.ALLTOTALTITLE.Width = 1F;
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
            // Ttl_StockPrice
            // 
            this.Ttl_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPrice.DataField = "StockPrice";
            this.Ttl_StockPrice.Height = 0.1565F;
            this.Ttl_StockPrice.Left = 9.3125F;
            this.Ttl_StockPrice.MultiLine = false;
            this.Ttl_StockPrice.Name = "Ttl_StockPrice";
            this.Ttl_StockPrice.OutputFormat = resources.GetString("Ttl_StockPrice.OutputFormat");
            this.Ttl_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_StockPrice.Text = "1,234,567,890";
            this.Ttl_StockPrice.Top = 0.0625F;
            this.Ttl_StockPrice.Width = 0.8125F;
            // 
            // Ttl_ShipmentPosCnt
            // 
            this.Ttl_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Ttl_ShipmentPosCnt.Height = 0.156F;
            this.Ttl_ShipmentPosCnt.Left = 6.875F;
            this.Ttl_ShipmentPosCnt.MultiLine = false;
            this.Ttl_ShipmentPosCnt.Name = "Ttl_ShipmentPosCnt";
            this.Ttl_ShipmentPosCnt.OutputFormat = resources.GetString("Ttl_ShipmentPosCnt.OutputFormat");
            this.Ttl_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentPosCnt.Text = "1,234,567";
            this.Ttl_ShipmentPosCnt.Top = 0.0625F;
            this.Ttl_ShipmentPosCnt.Width = 0.625F;
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
            this.textBox28.Height = 0.15625F;
            this.textBox28.Left = 7.5F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.textBox28.Text = "(";
            this.textBox28.Top = 0.0625F;
            this.textBox28.Width = 0.125F;
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
            this.textBox29.DataField = "SalesOrderCount";
            this.textBox29.Height = 0.15625F;
            this.textBox29.Left = 7.625F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox29.Text = "123,456";
            this.textBox29.Top = 0.0625F;
            this.textBox29.Width = 0.4375F;
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
            this.textBox30.Height = 0.15625F;
            this.textBox30.Left = 8.0625F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox30.Text = "：";
            this.textBox30.Top = 0.0625F;
            this.textBox30.Width = 0.125F;
            // 
            // textBox31
            // 
            this.textBox31.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.RightColor = System.Drawing.Color.Black;
            this.textBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.TopColor = System.Drawing.Color.Black;
            this.textBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.DataField = "ShipmentCnt";
            this.textBox31.Height = 0.15625F;
            this.textBox31.Left = 8.1875F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox31.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox31.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox31.Text = "123,456";
            this.textBox31.Top = 0.0625F;
            this.textBox31.Width = 0.4375F;
            // 
            // textBox32
            // 
            this.textBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.RightColor = System.Drawing.Color.Black;
            this.textBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.TopColor = System.Drawing.Color.Black;
            this.textBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Height = 0.15625F;
            this.textBox32.Left = 8.625F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox32.Text = ")";
            this.textBox32.Top = 0.0625F;
            this.textBox32.Width = 0.125F;
            // 
            // textBox33
            // 
            this.textBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.RightColor = System.Drawing.Color.Black;
            this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.TopColor = System.Drawing.Color.Black;
            this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.DataField = "StockOverCount";
            this.textBox33.Height = 0.15625F;
            this.textBox33.Left = 8.75F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox33.Text = "1,234,567";
            this.textBox33.Top = 0.0625F;
            this.textBox33.Width = 0.5625F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Wh_WarehouseCode,
            this.Wh_WarehouseName,
            this.Line7,
            this.line3});
            this.WarehouseHeader.DataField = "Sort_WarehouseCode";
            this.WarehouseHeader.Height = 0.1979167F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.WarehouseHeader.BeforePrint += new System.EventHandler(this.WarehouseHeader_BeforePrint);
            // 
            // Wh_WarehouseCode
            // 
            this.Wh_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.DataField = "WarehouseCode";
            this.Wh_WarehouseCode.Height = 0.156F;
            this.Wh_WarehouseCode.Left = 0F;
            this.Wh_WarehouseCode.MultiLine = false;
            this.Wh_WarehouseCode.Name = "Wh_WarehouseCode";
            this.Wh_WarehouseCode.OutputFormat = resources.GetString("Wh_WarehouseCode.OutputFormat");
            this.Wh_WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Wh_WarehouseCode.Text = "1234";
            this.Wh_WarehouseCode.Top = 0.03F;
            this.Wh_WarehouseCode.Width = 0.3125F;
            // 
            // Wh_WarehouseName
            // 
            this.Wh_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.DataField = "WarehouseName";
            this.Wh_WarehouseName.Height = 0.156F;
            this.Wh_WarehouseName.Left = 0.3125F;
            this.Wh_WarehouseName.MultiLine = false;
            this.Wh_WarehouseName.Name = "Wh_WarehouseName";
            this.Wh_WarehouseName.OutputFormat = resources.GetString("Wh_WarehouseName.OutputFormat");
            this.Wh_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Wh_WarehouseName.Text = "あいうえおかきくけこ";
            this.Wh_WarehouseName.Top = 0.03F;
            this.Wh_WarehouseName.Width = 1.1875F;
            // 
            // Line7
            // 
            this.Line7.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.RightColor = System.Drawing.Color.Black;
            this.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.TopColor = System.Drawing.Color.Black;
            this.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Height = 0F;
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 2F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 10.8F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 10.8F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0F;
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
            this.line3.Top = 0.19F;
            this.line3.Visible = false;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.19F;
            this.line3.Y2 = 0.19F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.Wh_StockPrice,
            this.Wh_ShipmentPosCnt,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox21});
            this.WarehouseFooter.Height = 0.25F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
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
            this.SECTOTALTITLE.Height = 0.219F;
            this.SECTOTALTITLE.Left = 5.375F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "倉庫計";
            this.SECTOTALTITLE.Top = 0.031F;
            this.SECTOTALTITLE.Width = 1F;
            // 
            // Wh_StockPrice
            // 
            this.Wh_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPrice.DataField = "StockPrice";
            this.Wh_StockPrice.Height = 0.1565F;
            this.Wh_StockPrice.Left = 9.3125F;
            this.Wh_StockPrice.MultiLine = false;
            this.Wh_StockPrice.Name = "Wh_StockPrice";
            this.Wh_StockPrice.OutputFormat = resources.GetString("Wh_StockPrice.OutputFormat");
            this.Wh_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_StockPrice.SummaryGroup = "WarehouseHeader";
            this.Wh_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_StockPrice.Text = "1,234,567,890";
            this.Wh_StockPrice.Top = 0.0625F;
            this.Wh_StockPrice.Width = 0.8125F;
            // 
            // Wh_ShipmentPosCnt
            // 
            this.Wh_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Wh_ShipmentPosCnt.Height = 0.156F;
            this.Wh_ShipmentPosCnt.Left = 6.875F;
            this.Wh_ShipmentPosCnt.MultiLine = false;
            this.Wh_ShipmentPosCnt.Name = "Wh_ShipmentPosCnt";
            this.Wh_ShipmentPosCnt.OutputFormat = resources.GetString("Wh_ShipmentPosCnt.OutputFormat");
            this.Wh_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentPosCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentPosCnt.Text = "1,234,567";
            this.Wh_ShipmentPosCnt.Top = 0.0625F;
            this.Wh_ShipmentPosCnt.Width = 0.625F;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightColor = System.Drawing.Color.Black;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopColor = System.Drawing.Color.Black;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Height = 0.15625F;
            this.textBox15.Left = 7.5F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.textBox15.Text = "(";
            this.textBox15.Top = 0.0625F;
            this.textBox15.Width = 0.125F;
            // 
            // textBox16
            // 
            this.textBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.RightColor = System.Drawing.Color.Black;
            this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.TopColor = System.Drawing.Color.Black;
            this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.DataField = "SalesOrderCount";
            this.textBox16.Height = 0.15625F;
            this.textBox16.Left = 7.625F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox16.SummaryGroup = "WarehouseHeader";
            this.textBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox16.Text = "123,456";
            this.textBox16.Top = 0.0625F;
            this.textBox16.Width = 0.4375F;
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
            this.textBox17.Height = 0.15625F;
            this.textBox17.Left = 8.0625F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox17.Text = "：";
            this.textBox17.Top = 0.0625F;
            this.textBox17.Width = 0.125F;
            // 
            // textBox18
            // 
            this.textBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.RightColor = System.Drawing.Color.Black;
            this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.TopColor = System.Drawing.Color.Black;
            this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.DataField = "ShipmentCnt";
            this.textBox18.Height = 0.15625F;
            this.textBox18.Left = 8.1875F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox18.SummaryGroup = "WarehouseHeader";
            this.textBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox18.Text = "123,456";
            this.textBox18.Top = 0.0625F;
            this.textBox18.Width = 0.4375F;
            // 
            // textBox19
            // 
            this.textBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.RightColor = System.Drawing.Color.Black;
            this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.TopColor = System.Drawing.Color.Black;
            this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Height = 0.15625F;
            this.textBox19.Left = 8.625F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox19.Text = ")";
            this.textBox19.Top = 0.0625F;
            this.textBox19.Width = 0.125F;
            // 
            // textBox21
            // 
            this.textBox21.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.RightColor = System.Drawing.Color.Black;
            this.textBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.TopColor = System.Drawing.Color.Black;
            this.textBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.DataField = "StockOverCount";
            this.textBox21.Height = 0.15625F;
            this.textBox21.Left = 8.75F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox21.SummaryGroup = "WarehouseHeader";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox21.Text = "1,234,567";
            this.textBox21.Top = 0.0625F;
            this.textBox21.Width = 0.5625F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Height = 0F;
            this.CustomerHeader.Name = "CustomerHeader";
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox3,
            this.Line,
            this.Cus_StockPrice,
            this.Cus_ShipmentPosCnt,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14});
            this.CustomerFooter.Height = 0.25F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
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
            this.TextBox3.Left = 5.375F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox3.Text = "仕入先計";
            this.TextBox3.Top = 0.031F;
            this.TextBox3.Width = 1F;
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
            this.Line.Width = 10.8F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.8F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // Cus_StockPrice
            // 
            this.Cus_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_StockPrice.DataField = "StockPrice";
            this.Cus_StockPrice.Height = 0.1565F;
            this.Cus_StockPrice.Left = 9.3125F;
            this.Cus_StockPrice.MultiLine = false;
            this.Cus_StockPrice.Name = "Cus_StockPrice";
            this.Cus_StockPrice.OutputFormat = resources.GetString("Cus_StockPrice.OutputFormat");
            this.Cus_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_StockPrice.SummaryGroup = "CustomerHeader";
            this.Cus_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_StockPrice.Text = "1,234,567,890";
            this.Cus_StockPrice.Top = 0.0625F;
            this.Cus_StockPrice.Width = 0.8125F;
            // 
            // Cus_ShipmentPosCnt
            // 
            this.Cus_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Cus_ShipmentPosCnt.Height = 0.156F;
            this.Cus_ShipmentPosCnt.Left = 6.875F;
            this.Cus_ShipmentPosCnt.MultiLine = false;
            this.Cus_ShipmentPosCnt.Name = "Cus_ShipmentPosCnt";
            this.Cus_ShipmentPosCnt.OutputFormat = resources.GetString("Cus_ShipmentPosCnt.OutputFormat");
            this.Cus_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentPosCnt.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentPosCnt.Text = "1,234,567";
            this.Cus_ShipmentPosCnt.Top = 0.0625F;
            this.Cus_ShipmentPosCnt.Width = 0.625F;
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
            this.textBox9.Height = 0.15625F;
            this.textBox9.Left = 7.5F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.textBox9.Text = "(";
            this.textBox9.Top = 0.0625F;
            this.textBox9.Width = 0.125F;
            // 
            // textBox10
            // 
            this.textBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.RightColor = System.Drawing.Color.Black;
            this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.TopColor = System.Drawing.Color.Black;
            this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.DataField = "SalesOrderCount";
            this.textBox10.Height = 0.15625F;
            this.textBox10.Left = 7.625F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox10.SummaryGroup = "CustomerHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "123,456";
            this.textBox10.Top = 0.0625F;
            this.textBox10.Width = 0.4375F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Height = 0.15625F;
            this.textBox11.Left = 8.0625F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox11.Text = "：";
            this.textBox11.Top = 0.0625F;
            this.textBox11.Width = 0.125F;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightColor = System.Drawing.Color.Black;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopColor = System.Drawing.Color.Black;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.DataField = "ShipmentCnt";
            this.textBox12.Height = 0.15625F;
            this.textBox12.Left = 8.1875F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox12.SummaryGroup = "CustomerHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "123,456";
            this.textBox12.Top = 0.0625F;
            this.textBox12.Width = 0.4375F;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightColor = System.Drawing.Color.Black;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopColor = System.Drawing.Color.Black;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Height = 0.15625F;
            this.textBox13.Left = 8.625F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox13.Text = ")";
            this.textBox13.Top = 0.0625F;
            this.textBox13.Width = 0.125F;
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightColor = System.Drawing.Color.Black;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopColor = System.Drawing.Color.Black;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DataField = "StockOverCount";
            this.textBox14.Height = 0.15625F;
            this.textBox14.Left = 8.75F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox14.SummaryGroup = "CustomerHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "1,234,567";
            this.textBox14.Top = 0.0625F;
            this.textBox14.Width = 0.5625F;
            // 
            // WarehouseShelfNoHeader
            // 
            this.WarehouseShelfNoHeader.CanShrink = true;
            this.WarehouseShelfNoHeader.Height = 0F;
            this.WarehouseShelfNoHeader.KeepTogether = true;
            this.WarehouseShelfNoHeader.Name = "WarehouseShelfNoHeader";
            this.WarehouseShelfNoHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // WarehouseShelfNoFooter
            // 
            this.WarehouseShelfNoFooter.CanShrink = true;
            this.WarehouseShelfNoFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line4,
            this.TextBox20,
            this.Ws_ShipmentPosCnt,
            this.Ws_StockPrice,
            this.textBox2,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8});
            this.WarehouseShelfNoFooter.Height = 0.25F;
            this.WarehouseShelfNoFooter.KeepTogether = true;
            this.WarehouseShelfNoFooter.Name = "WarehouseShelfNoFooter";
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0F;
            this.Line4.Left = 0F;
            this.Line4.LineWeight = 2F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 10.8F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 10.8F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0F;
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
            this.TextBox20.Height = 0.219F;
            this.TextBox20.Left = 5.375F;
            this.TextBox20.MultiLine = false;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox20.Text = "棚番計";
            this.TextBox20.Top = 0.031F;
            this.TextBox20.Width = 1F;
            // 
            // Ws_ShipmentPosCnt
            // 
            this.Ws_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.Ws_ShipmentPosCnt.Height = 0.156F;
            this.Ws_ShipmentPosCnt.Left = 6.875F;
            this.Ws_ShipmentPosCnt.MultiLine = false;
            this.Ws_ShipmentPosCnt.Name = "Ws_ShipmentPosCnt";
            this.Ws_ShipmentPosCnt.OutputFormat = resources.GetString("Ws_ShipmentPosCnt.OutputFormat");
            this.Ws_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_ShipmentPosCnt.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_ShipmentPosCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_ShipmentPosCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_ShipmentPosCnt.Text = "1,234,567";
            this.Ws_ShipmentPosCnt.Top = 0.0625F;
            this.Ws_ShipmentPosCnt.Width = 0.625F;
            // 
            // Ws_StockPrice
            // 
            this.Ws_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ws_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ws_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ws_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ws_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ws_StockPrice.DataField = "StockPrice";
            this.Ws_StockPrice.Height = 0.1565F;
            this.Ws_StockPrice.Left = 9.3125F;
            this.Ws_StockPrice.MultiLine = false;
            this.Ws_StockPrice.Name = "Ws_StockPrice";
            this.Ws_StockPrice.OutputFormat = resources.GetString("Ws_StockPrice.OutputFormat");
            this.Ws_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ws_StockPrice.SummaryGroup = "WarehouseShelfNoHeader";
            this.Ws_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Ws_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Ws_StockPrice.Text = "1,234,567,890";
            this.Ws_StockPrice.Top = 0.0625F;
            this.Ws_StockPrice.Width = 0.8125F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Height = 0.15625F;
            this.textBox2.Left = 7.5F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.textBox2.Text = "(";
            this.textBox2.Top = 0.0625F;
            this.textBox2.Width = 0.125F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "SalesOrderCount";
            this.textBox4.Height = 0.15625F;
            this.textBox4.Left = 7.625F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox4.SummaryGroup = "WarehouseShelfNoHeader";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "123,456";
            this.textBox4.Top = 0.0625F;
            this.textBox4.Width = 0.4375F;
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
            this.textBox5.Height = 0.15625F;
            this.textBox5.Left = 8.0625F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox5.Text = "：";
            this.textBox5.Top = 0.0625F;
            this.textBox5.Width = 0.125F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DataField = "ShipmentCnt";
            this.textBox6.Height = 0.15625F;
            this.textBox6.Left = 8.1875F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.SummaryGroup = "WarehouseShelfNoHeader";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "123,456";
            this.textBox6.Top = 0.0625F;
            this.textBox6.Width = 0.4375F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Height = 0.15625F;
            this.textBox7.Left = 8.625F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox7.Text = ")";
            this.textBox7.Top = 0.0625F;
            this.textBox7.Width = 0.125F;
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
            this.textBox8.DataField = "StockOverCount";
            this.textBox8.Height = 0.15625F;
            this.textBox8.Left = 8.75F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.SummaryGroup = "WarehouseShelfNoHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "1,234,567";
            this.textBox8.Top = 0.0625F;
            this.textBox8.Width = 0.5625F;
            // 
            // DCZAI02182P_01A4C
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
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.WarehouseShelfNoHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.WarehouseShelfNoFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.WarehouseFooter);
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
            this.PageEnd += new System.EventHandler(this.DCZAI02163P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCZAI02163P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastStockDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockOverCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo1_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicationShelfNo2_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo1_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo2_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DuplicationShelfNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LastSalesDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ws_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
     }
}
