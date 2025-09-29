//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動確認表
// プログラム概要   : 在庫移動確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30416 長沼　賢二
// 修 正 日  2008/08/12  修正内容 : Partman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 修 正 日  2008/10/30  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/10  修正内容 : 不具合対応[12213]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/11  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2012/11/21  修正内容 : 仕様変更対応
//                                  ※発行タイプ「出庫」追加
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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
    /// 在庫移動確認表(集計)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 在庫移動確認表(集計)のフォームクラスです。</br>
	/// <br>Programmer	: 30416 長沼　賢二</br>
	/// <br>Date		: 2008.08.12</br>
    /// <br></br>
    /// <br>UpdateNote  : 2008/10/30 30462 行澤 仁美　バグ修正</br>
	/// <br>            : 2009/03/10       照田 貴志　不具合対応[12213]</br>
	/// </remarks>
	public class MAZAI02032P_05A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 在庫移動確認表(集計)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 在庫移動確認表(集計)フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 30416　長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
		/// </remarks>
		public MAZAI02032P_05A4C()
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

		private	StockMoveCndtn		_stockMoveCndtn;				// 抽出条件クラス

        private string _groupKey = string.Empty;

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        private TextBox Sec_MainSectionCode;
        private Label Lb_BfSection;
        private Label Lb_BfEnterWareh;
        private Label Lb_AfSection;
        private Label Lb_AfEnterWareh;
        private Label Lb_MoveCount;
        private Label Lb_MovePrice;
        private TextBox BfSectionCode;
        private TextBox BfSectionGuideSnm;
        private TextBox BfEnterWarehName;
        private TextBox AfSectionCode;
        private TextBox AfSectionGuideSnm;
        private TextBox AfEnterWarehName;
        private TextBox MoveCount;
        private TextBox MovePrice;
        private Label Lb_AfSection_Dm;
        private Label Lb_AfEnterWareh_Dm;
        private Label Lb_BfSection_Dm;
        private Label Lb_BfEnterWareh_Dm;
        private TextBox BfSectionCode_Dm;
        private TextBox BfSectionGuideSnm_Dm;
        private TextBox BfEnterWarehName_Dm;
        private TextBox AfSectionGuideSnm_Dm;
        private TextBox AfSectionCode_Dm;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox BfEnterWarehCode;
        private TextBox AfEnterWarehCode;
        private TextBox AfEnterWarehCode_Dm;
        private TextBox BfEnterWarehCode_Dm;
        private TextBox AfEnterWarehName_Dm;
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
				this._stockMoveCndtn	= (StockMoveCndtn)this._printInfo.jyoken;
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
        /// <br>Programmer	: 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;

            SectionHeader.DataField = MAZAI02034EA.ct_Col_MainSectionCode;
            SectionHeader.Visible = true;
            SectionFooter.Visible = true;
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // ADD 2008/10/30 不具合対応[7239] ---------->>>>>
            //this.SectionHeader.DataField = "BfSectionCode";           //DEL 2009/03/10 不具合対応[12213]
            //this.WareHouseHeader.DataField = "BfEnterWarehName";      //DEL 2009/03/10 不具合対応[12213]
            // ---ADD 2009/03/10 不具合対応[12213] ------------------------------>>>>>
            //if (this._stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeBf)   // DEL 2009/06/11
            // --- UPD 2012/11/21 Y.Wakita ---------->>>>>
            //// ADD 2009/06/11 ------>>>
            //if ((this._stockMoveCndtn.PrintType == 0) ||
            //    (this._stockMoveCndtn.PrintType == -1))
            //// ADD 2009/06/11 ------<<<
            if ((this._stockMoveCndtn.PrintType == 0) ||
                (this._stockMoveCndtn.PrintType == -1) ||
                (this._stockMoveCndtn.PrintType == 2))
            // --- UPD 2012/11/21 Y.Wakita ----------<<<<<
            {
                this.WareHouseHeader.DataField = "BfEnterWarehCode";        //倉庫計
                this.SectionHeader.DataField = "BfSectionCode";             //拠点計
            }
            else
            {
                this.WareHouseHeader.DataField = "AfEnterWarehCode";        //倉庫計
                this.SectionHeader.DataField = "AfSectionCode";             //拠点計
            }
            // ---ADD 2009/03/10 不具合対応[12213] ------------------------------<<<<<


            // 改頁：拠点
            if (this._stockMoveCndtn.NewPage == StockMoveCndtn.NewPageDivState.Section)
            {
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.WareHouseHeader.NewPage = NewPage.None;
                this.WareHouseHeader.RepeatStyle = RepeatStyle.None;
            }
            // 改頁：倉庫
            else if (this._stockMoveCndtn.NewPage == StockMoveCndtn.NewPageDivState.Warehouse)
            {
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.WareHouseHeader.NewPage = NewPage.Before;
                this.WareHouseHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            // 改頁：しない
            else
            {
                this.SectionHeader.NewPage = NewPage.None;
                this.SectionHeader.RepeatStyle = RepeatStyle.None;
                this.WareHouseHeader.NewPage = NewPage.None;
                this.WareHouseHeader.RepeatStyle = RepeatStyle.None;
            }
            // ADD 2008/10/30 不具合対応[7239] ----------<<<<<

            #region ＜＜　出庫・入庫別レイアウト制御　＞＞
            //------------------------------------------------------------------------
            // 作成時のデフォルトの配置は出庫のレイアウトになっています。
            // 「入庫」が選択されている場合は、入庫レイアウトに動的に組み替えます。
            // (ex. WarehouseShelfNo.Left ← WarehouseShelfNo_Dm.Leftをセット)
            //------------------------------------------------------------------------

            //if (this._stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeAf)   // DEL 2009/06/11
            if (this._stockMoveCndtn.PrintType == 1)    // ADD 2009/06/11
            {
                // タイトル項目
                Lb_BfSection.Left = Lb_BfSection_Dm.Left;
                Lb_BfEnterWareh.Left = Lb_BfEnterWareh_Dm.Left;
                Lb_AfSection.Left = Lb_AfSection_Dm.Left;
                Lb_AfEnterWareh.Left = Lb_AfEnterWareh_Dm.Left;

                // 明細項目
                BfSectionCode.Left = BfSectionCode_Dm.Left;
                BfSectionGuideSnm.Left = BfSectionGuideSnm_Dm.Left;
                BfEnterWarehName.Left = BfEnterWarehName_Dm.Left;
                AfSectionCode.Left = AfSectionCode_Dm.Left;
                AfSectionGuideSnm.Left = AfSectionGuideSnm_Dm.Left;
                AfEnterWarehName.Left = AfEnterWarehName_Dm.Left;

                // ---ADD 2009/03/10 不具合対応[12213] --------------------------->>>>>
                BfEnterWarehCode.Left = BfEnterWarehCode_Dm.Left;
                AfEnterWarehCode.Left = AfEnterWarehCode_Dm.Left;
                // ---ADD 2009/03/10 不具合対応[12213] ---------------------------<<<<<
            }
            #endregion ＜＜　出庫・入庫別レイアウト制御　＞＞

            #region ＜＜　金額指定レイアウト制御　＞＞
            switch (this._stockMoveCndtn.PriceDesignat)
            {
                case StockMoveCndtn.PriceDesignatDivState.StockUnitPriceAndMovePrice:
                    // タイトル項目
                    Lb_MovePrice.Visible = true;
                    // 明細項目
                    MovePrice.Visible = true;
                    Wh_StockPrice.Visible = true;
                    Sec_StockPrice.Visible = true;
                    GrandTtl_StockPrice.Visible = true;
                    break;
                case StockMoveCndtn.PriceDesignatDivState.StockUnitPrice:
                    // タイトル項目
                    Lb_MovePrice.Visible = false;
                    // 明細項目
                    MovePrice.Visible = false;
                    Wh_StockPrice.Visible = false;
                    Sec_StockPrice.Visible = false;
                    GrandTtl_StockPrice.Visible = false;
                    break;
                case StockMoveCndtn.PriceDesignatDivState.MovePrice:
                    // タイトル項目
                    Lb_MovePrice.Visible = true;
                    // 明細項目
                    MovePrice.Visible = true;
                    Wh_StockPrice.Visible = true;
                    Sec_StockPrice.Visible = true;
                    GrandTtl_StockPrice.Visible = true;
                    break;
                case StockMoveCndtn.PriceDesignatDivState.None:
                    // タイトル項目
                    Lb_MovePrice.Visible = false;
                    // 明細項目
                    MovePrice.Visible = false;
                    Wh_StockPrice.Visible = false;
                    Sec_StockPrice.Visible = false;
                    GrandTtl_StockPrice.Visible = false;
                    break;
            }
            #endregion ＜＜　金額指定レイアウト制御　＞＞

		}
		#endregion ◆ レポート要素出力設定

		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{
            // ---ADD 2009/03/10 不具合対応[12213] --------------------------------------------------->>>>>
            string key = string.Empty;

            // --- UPD 2012/11/21 Y.Wakita ---------->>>>>
            ////if (this._stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeBf)   // DEL 2009/06/11
            //// ADD 2009/06/11 ------>>>
            //if ((this._stockMoveCndtn.PrintType == 0) ||
            //    (this._stockMoveCndtn.PrintType == -1))
            //// ADD 2009/06/11 ------<<<
            if ((this._stockMoveCndtn.PrintType == 0) ||
                (this._stockMoveCndtn.PrintType == -1) ||
                (this._stockMoveCndtn.PrintType == 2))
            // --- UPD 2012/11/21 Y.Wakita ----------<<<<<
            {
                key = BfSectionCode.Text.Trim().PadLeft(2,'0') + BfEnterWarehCode.Text.Trim().PadLeft(4,'0');
                if (key == this._groupKey)
                {
                    BfSectionCode.Visible = false;
                    BfSectionGuideSnm.Visible = false;
                    BfEnterWarehCode.Visible = false;
                    BfEnterWarehName.Visible = false;
                }
                else
                {
                    BfSectionCode.Visible = true;
                    BfSectionGuideSnm.Visible = true;
                    BfEnterWarehCode.Visible = true;
                    BfEnterWarehName.Visible = true;
                }
            }
            else
            {
                key = AfSectionCode.Text.Trim().PadLeft(2, '0') + AfEnterWarehCode.Text.Trim().PadLeft(4, '0');
                if (key == this._groupKey)
                {
                    AfSectionCode.Visible = false;
                    AfSectionGuideSnm.Visible = false;
                    AfEnterWarehCode.Visible = false;
                    AfEnterWarehName.Visible = false;
                }
                else
                {
                    AfSectionCode.Visible = true;
                    AfSectionGuideSnm.Visible = true;
                    AfEnterWarehCode.Visible = true;
                    AfEnterWarehName.Visible = true;
                }
            }
            this._groupKey = key;
            // ---ADD 2009/03/10 不具合対応[12213] ---------------------------------------------------<<<<<
        }
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

		#region ◎ MAZAI02032P_05A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_05A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
		/// </remarks>
		private void MAZAI02032P_05A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
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
        /// <br>Programmer	: 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");

            this._groupKey = string.Empty;          //ADD 2009/03/10 不具合対応[12213]
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
        /// <br>Programmer	: 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
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

			// 拠点オプション有無判定
            //string sectionTitle = string.Format( "{0}拠点：", this._stockMoveCndtn.MainExtractTitle );
            //if ( this._stockMoveCndtn.IsOptSection )
            //{
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //if ( this._stockMoveCndtn.IsSelectAllSection )
            //    //{
            //    //    this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
            //    //}
            //    //else
            //    //{
            //    //    this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    //}
            //    this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}

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
        /// <br>Programmer	: 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
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
        /// <br>Programmer  : 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
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
        /// <br>Programmer	: 30416 長沼　賢二</br>
        /// <br>Date		: 2008.08.12</br>
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
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.TextBox tb_MainSectionName;
        private DataDynamics.ActiveReports.GroupHeader WareHouseHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.GroupFooter WareHouseFooter;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.TextBox Wh_MovingTotalStock;
		private DataDynamics.ActiveReports.TextBox Wh_StockPrice;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Sec_MovingTotalStock;
		private DataDynamics.ActiveReports.TextBox Sec_StockPrice;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox GrandTtl_MovingTotalStock;
		private DataDynamics.ActiveReports.TextBox GrandTtl_StockPrice;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02032P_05A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.BfSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.BfSectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.BfEnterWarehName = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.AfEnterWarehName = new DataDynamics.ActiveReports.TextBox();
            this.MoveCount = new DataDynamics.ActiveReports.TextBox();
            this.MovePrice = new DataDynamics.ActiveReports.TextBox();
            this.BfSectionCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BfSectionGuideSnm_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BfEnterWarehName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionGuideSnm_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfSectionCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.AfEnterWarehName_Dm = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.BfEnterWarehCode = new DataDynamics.ActiveReports.TextBox();
            this.AfEnterWarehCode = new DataDynamics.ActiveReports.TextBox();
            this.AfEnterWarehCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.BfEnterWarehCode_Dm = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_BfSection = new DataDynamics.ActiveReports.Label();
            this.Lb_AfSection = new DataDynamics.ActiveReports.Label();
            this.Lb_AfEnterWareh = new DataDynamics.ActiveReports.Label();
            this.Lb_MoveCount = new DataDynamics.ActiveReports.Label();
            this.Lb_AfSection_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_AfEnterWareh_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BfSection_Dm = new DataDynamics.ActiveReports.Label();
            this.Lb_BfEnterWareh_Dm = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Lb_BfEnterWareh = new DataDynamics.ActiveReports.Label();
            this.Lb_MovePrice = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.GrandTtl_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.GrandTtl_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_MainSectionName = new DataDynamics.ActiveReports.TextBox();
            this.Sec_MainSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Sec_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.Sec_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WareHouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_MovingTotalStock = new DataDynamics.ActiveReports.TextBox();
            this.Wh_StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehCode_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh_Dm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MovePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MainSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_MainSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MovingTotalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line37,
            this.BfSectionCode,
            this.BfSectionGuideSnm,
            this.BfEnterWarehName,
            this.AfSectionCode,
            this.AfSectionGuideSnm,
            this.AfEnterWarehName,
            this.MoveCount,
            this.MovePrice,
            this.BfSectionCode_Dm,
            this.BfSectionGuideSnm_Dm,
            this.BfEnterWarehName_Dm,
            this.AfSectionGuideSnm_Dm,
            this.AfSectionCode_Dm,
            this.AfEnterWarehName_Dm,
            this.textBox1,
            this.BfEnterWarehCode,
            this.AfEnterWarehCode,
            this.AfEnterWarehCode_Dm,
            this.BfEnterWarehCode_Dm});
            this.Detail.Height = 0.5833333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            // BfSectionCode
            // 
            this.BfSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode.DataField = "BfSectionCode";
            this.BfSectionCode.Height = 0.156F;
            this.BfSectionCode.Left = 0F;
            this.BfSectionCode.MultiLine = false;
            this.BfSectionCode.Name = "BfSectionCode";
            this.BfSectionCode.OutputFormat = resources.GetString("BfSectionCode.OutputFormat");
            this.BfSectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BfSectionCode.Text = "12";
            this.BfSectionCode.Top = 0.01F;
            this.BfSectionCode.Width = 0.1875F;
            // 
            // BfSectionGuideSnm
            // 
            this.BfSectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm.DataField = "BfSectionGuideSnm";
            this.BfSectionGuideSnm.Height = 0.156F;
            this.BfSectionGuideSnm.Left = 0.1875F;
            this.BfSectionGuideSnm.MultiLine = false;
            this.BfSectionGuideSnm.Name = "BfSectionGuideSnm";
            this.BfSectionGuideSnm.OutputFormat = resources.GetString("BfSectionGuideSnm.OutputFormat");
            this.BfSectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BfSectionGuideSnm.Text = "あいうえおかきくけこ";
            this.BfSectionGuideSnm.Top = 0.01F;
            this.BfSectionGuideSnm.Width = 1.1875F;
            // 
            // BfEnterWarehName
            // 
            this.BfEnterWarehName.Border.BottomColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.Border.LeftColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.Border.RightColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.Border.TopColor = System.Drawing.Color.Black;
            this.BfEnterWarehName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName.DataField = "BfEnterWarehName";
            this.BfEnterWarehName.Height = 0.156F;
            this.BfEnterWarehName.Left = 1.75F;
            this.BfEnterWarehName.MultiLine = false;
            this.BfEnterWarehName.Name = "BfEnterWarehName";
            this.BfEnterWarehName.OutputFormat = resources.GetString("BfEnterWarehName.OutputFormat");
            this.BfEnterWarehName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BfEnterWarehName.Text = "あいうえおかきくけこ";
            this.BfEnterWarehName.Top = 0.01F;
            this.BfEnterWarehName.Width = 1.1875F;
            // 
            // AfSectionCode
            // 
            this.AfSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode.DataField = "AfSectionCode";
            this.AfSectionCode.Height = 0.156F;
            this.AfSectionCode.Left = 3F;
            this.AfSectionCode.MultiLine = false;
            this.AfSectionCode.Name = "AfSectionCode";
            this.AfSectionCode.OutputFormat = resources.GetString("AfSectionCode.OutputFormat");
            this.AfSectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.AfSectionCode.Text = "12";
            this.AfSectionCode.Top = 0.01F;
            this.AfSectionCode.Width = 0.1875F;
            // 
            // AfSectionGuideSnm
            // 
            this.AfSectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm.DataField = "AfSectionGuideSnm";
            this.AfSectionGuideSnm.Height = 0.156F;
            this.AfSectionGuideSnm.Left = 3.1875F;
            this.AfSectionGuideSnm.MultiLine = false;
            this.AfSectionGuideSnm.Name = "AfSectionGuideSnm";
            this.AfSectionGuideSnm.OutputFormat = resources.GetString("AfSectionGuideSnm.OutputFormat");
            this.AfSectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AfSectionGuideSnm.Text = "あいうえおかきくけこ";
            this.AfSectionGuideSnm.Top = 0.01F;
            this.AfSectionGuideSnm.Width = 1.1875F;
            // 
            // AfEnterWarehName
            // 
            this.AfEnterWarehName.Border.BottomColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.Border.LeftColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.Border.RightColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.Border.TopColor = System.Drawing.Color.Black;
            this.AfEnterWarehName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName.DataField = "AfEnterWarehName";
            this.AfEnterWarehName.Height = 0.156F;
            this.AfEnterWarehName.Left = 4.75F;
            this.AfEnterWarehName.MultiLine = false;
            this.AfEnterWarehName.Name = "AfEnterWarehName";
            this.AfEnterWarehName.OutputFormat = resources.GetString("AfEnterWarehName.OutputFormat");
            this.AfEnterWarehName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.AfEnterWarehName.Text = "あいうえおかきくけこ";
            this.AfEnterWarehName.Top = 0.01F;
            this.AfEnterWarehName.Width = 1.1875F;
            // 
            // MoveCount
            // 
            this.MoveCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.Border.RightColor = System.Drawing.Color.Black;
            this.MoveCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.Border.TopColor = System.Drawing.Color.Black;
            this.MoveCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveCount.DataField = "MoveCount";
            this.MoveCount.Height = 0.156F;
            this.MoveCount.Left = 6.6875F;
            this.MoveCount.MultiLine = false;
            this.MoveCount.Name = "MoveCount";
            this.MoveCount.OutputFormat = resources.GetString("MoveCount.OutputFormat");
            this.MoveCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MoveCount.Text = "123456789";
            this.MoveCount.Top = 0.01F;
            this.MoveCount.Width = 0.75F;
            // 
            // MovePrice
            // 
            this.MovePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MovePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MovePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.Border.RightColor = System.Drawing.Color.Black;
            this.MovePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.Border.TopColor = System.Drawing.Color.Black;
            this.MovePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MovePrice.DataField = "StockPrice";
            this.MovePrice.Height = 0.156F;
            this.MovePrice.Left = 7.4375F;
            this.MovePrice.MultiLine = false;
            this.MovePrice.Name = "MovePrice";
            this.MovePrice.OutputFormat = resources.GetString("MovePrice.OutputFormat");
            this.MovePrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MovePrice.Text = "12345678";
            this.MovePrice.Top = 0.01F;
            this.MovePrice.Width = 0.9375F;
            // 
            // BfSectionCode_Dm
            // 
            this.BfSectionCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionCode_Dm.DataField = "MainSectionName";
            this.BfSectionCode_Dm.Height = 0.156F;
            this.BfSectionCode_Dm.Left = 3F;
            this.BfSectionCode_Dm.MultiLine = false;
            this.BfSectionCode_Dm.Name = "BfSectionCode_Dm";
            this.BfSectionCode_Dm.OutputFormat = resources.GetString("BfSectionCode_Dm.OutputFormat");
            this.BfSectionCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfSectionCode_Dm.Text = "12";
            this.BfSectionCode_Dm.Top = 0.375F;
            this.BfSectionCode_Dm.Visible = false;
            this.BfSectionCode_Dm.Width = 0.1875F;
            // 
            // BfSectionGuideSnm_Dm
            // 
            this.BfSectionGuideSnm_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfSectionGuideSnm_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfSectionGuideSnm_Dm.DataField = "MainSectionName";
            this.BfSectionGuideSnm_Dm.Height = 0.156F;
            this.BfSectionGuideSnm_Dm.Left = 3.1875F;
            this.BfSectionGuideSnm_Dm.MultiLine = false;
            this.BfSectionGuideSnm_Dm.Name = "BfSectionGuideSnm_Dm";
            this.BfSectionGuideSnm_Dm.OutputFormat = resources.GetString("BfSectionGuideSnm_Dm.OutputFormat");
            this.BfSectionGuideSnm_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfSectionGuideSnm_Dm.Text = "あいうえおかきくけこ";
            this.BfSectionGuideSnm_Dm.Top = 0.375F;
            this.BfSectionGuideSnm_Dm.Visible = false;
            this.BfSectionGuideSnm_Dm.Width = 1.1875F;
            // 
            // BfEnterWarehName_Dm
            // 
            this.BfEnterWarehName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfEnterWarehName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehName_Dm.DataField = "MainSectionName";
            this.BfEnterWarehName_Dm.Height = 0.156F;
            this.BfEnterWarehName_Dm.Left = 4.75F;
            this.BfEnterWarehName_Dm.MultiLine = false;
            this.BfEnterWarehName_Dm.Name = "BfEnterWarehName_Dm";
            this.BfEnterWarehName_Dm.OutputFormat = resources.GetString("BfEnterWarehName_Dm.OutputFormat");
            this.BfEnterWarehName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfEnterWarehName_Dm.Text = "あいうえおかきくけこ";
            this.BfEnterWarehName_Dm.Top = 0.375F;
            this.BfEnterWarehName_Dm.Visible = false;
            this.BfEnterWarehName_Dm.Width = 1.1875F;
            // 
            // AfSectionGuideSnm_Dm
            // 
            this.AfSectionGuideSnm_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionGuideSnm_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionGuideSnm_Dm.DataField = "MainSectionName";
            this.AfSectionGuideSnm_Dm.Height = 0.156F;
            this.AfSectionGuideSnm_Dm.Left = 0.1875F;
            this.AfSectionGuideSnm_Dm.MultiLine = false;
            this.AfSectionGuideSnm_Dm.Name = "AfSectionGuideSnm_Dm";
            this.AfSectionGuideSnm_Dm.OutputFormat = resources.GetString("AfSectionGuideSnm_Dm.OutputFormat");
            this.AfSectionGuideSnm_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfSectionGuideSnm_Dm.Text = "あいうえおかきくけこ";
            this.AfSectionGuideSnm_Dm.Top = 0.375F;
            this.AfSectionGuideSnm_Dm.Visible = false;
            this.AfSectionGuideSnm_Dm.Width = 1.1875F;
            // 
            // AfSectionCode_Dm
            // 
            this.AfSectionCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfSectionCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfSectionCode_Dm.DataField = "MainSectionName";
            this.AfSectionCode_Dm.Height = 0.156F;
            this.AfSectionCode_Dm.Left = 0F;
            this.AfSectionCode_Dm.MultiLine = false;
            this.AfSectionCode_Dm.Name = "AfSectionCode_Dm";
            this.AfSectionCode_Dm.OutputFormat = resources.GetString("AfSectionCode_Dm.OutputFormat");
            this.AfSectionCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfSectionCode_Dm.Text = "12";
            this.AfSectionCode_Dm.Top = 0.375F;
            this.AfSectionCode_Dm.Visible = false;
            this.AfSectionCode_Dm.Width = 0.1875F;
            // 
            // AfEnterWarehName_Dm
            // 
            this.AfEnterWarehName_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfEnterWarehName_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehName_Dm.DataField = "MainSectionName";
            this.AfEnterWarehName_Dm.Height = 0.156F;
            this.AfEnterWarehName_Dm.Left = 1.75F;
            this.AfEnterWarehName_Dm.MultiLine = false;
            this.AfEnterWarehName_Dm.Name = "AfEnterWarehName_Dm";
            this.AfEnterWarehName_Dm.OutputFormat = resources.GetString("AfEnterWarehName_Dm.OutputFormat");
            this.AfEnterWarehName_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfEnterWarehName_Dm.Text = "あいうえおかきくけこ";
            this.AfEnterWarehName_Dm.Top = 0.375F;
            this.AfEnterWarehName_Dm.Visible = false;
            this.AfEnterWarehName_Dm.Width = 1.1875F;
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
            this.textBox1.DataField = "StockMoveSlipCnt";
            this.textBox1.Height = 0.156F;
            this.textBox1.Left = 5.9375F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.textBox1.Text = "123456789";
            this.textBox1.Top = 0.01F;
            this.textBox1.Width = 0.75F;
            // 
            // BfEnterWarehCode
            // 
            this.BfEnterWarehCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode.Border.RightColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode.Border.TopColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode.DataField = "BfEnterWarehCode";
            this.BfEnterWarehCode.Height = 0.156F;
            this.BfEnterWarehCode.Left = 1.4375F;
            this.BfEnterWarehCode.MultiLine = false;
            this.BfEnterWarehCode.Name = "BfEnterWarehCode";
            this.BfEnterWarehCode.OutputFormat = resources.GetString("BfEnterWarehCode.OutputFormat");
            this.BfEnterWarehCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BfEnterWarehCode.Text = "1234";
            this.BfEnterWarehCode.Top = 0.01F;
            this.BfEnterWarehCode.Width = 0.3125F;
            // 
            // AfEnterWarehCode
            // 
            this.AfEnterWarehCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode.Border.RightColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode.Border.TopColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode.DataField = "AfEnterWarehCode";
            this.AfEnterWarehCode.Height = 0.156F;
            this.AfEnterWarehCode.Left = 4.4375F;
            this.AfEnterWarehCode.MultiLine = false;
            this.AfEnterWarehCode.Name = "AfEnterWarehCode";
            this.AfEnterWarehCode.OutputFormat = resources.GetString("AfEnterWarehCode.OutputFormat");
            this.AfEnterWarehCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.AfEnterWarehCode.Text = "1234";
            this.AfEnterWarehCode.Top = 0.01F;
            this.AfEnterWarehCode.Width = 0.3125F;
            // 
            // AfEnterWarehCode_Dm
            // 
            this.AfEnterWarehCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.AfEnterWarehCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfEnterWarehCode_Dm.DataField = "MainSectionName";
            this.AfEnterWarehCode_Dm.Height = 0.156F;
            this.AfEnterWarehCode_Dm.Left = 1.4375F;
            this.AfEnterWarehCode_Dm.MultiLine = false;
            this.AfEnterWarehCode_Dm.Name = "AfEnterWarehCode_Dm";
            this.AfEnterWarehCode_Dm.OutputFormat = resources.GetString("AfEnterWarehCode_Dm.OutputFormat");
            this.AfEnterWarehCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.AfEnterWarehCode_Dm.Text = "1234";
            this.AfEnterWarehCode_Dm.Top = 0.375F;
            this.AfEnterWarehCode_Dm.Visible = false;
            this.AfEnterWarehCode_Dm.Width = 0.3125F;
            // 
            // BfEnterWarehCode_Dm
            // 
            this.BfEnterWarehCode_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.BfEnterWarehCode_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfEnterWarehCode_Dm.DataField = "MainSectionName";
            this.BfEnterWarehCode_Dm.Height = 0.156F;
            this.BfEnterWarehCode_Dm.Left = 4.4375F;
            this.BfEnterWarehCode_Dm.MultiLine = false;
            this.BfEnterWarehCode_Dm.Name = "BfEnterWarehCode_Dm";
            this.BfEnterWarehCode_Dm.OutputFormat = resources.GetString("BfEnterWarehCode_Dm.OutputFormat");
            this.BfEnterWarehCode_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: " +
                "ＭＳ 明朝; vertical-align: top; ";
            this.BfEnterWarehCode_Dm.Text = "1234";
            this.BfEnterWarehCode_Dm.Top = 0.375F;
            this.BfEnterWarehCode_Dm.Visible = false;
            this.BfEnterWarehCode_Dm.Width = 0.3125F;
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
            this.tb_ReportTitle.Text = "在庫移動確認表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.40625F;
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
            this.Line42,
            this.Lb_BfSection,
            this.Lb_AfSection,
            this.Lb_AfEnterWareh,
            this.Lb_MoveCount,
            this.Lb_AfSection_Dm,
            this.Lb_AfEnterWareh_Dm,
            this.Lb_BfSection_Dm,
            this.Lb_BfEnterWareh_Dm,
            this.label1,
            this.Lb_BfEnterWareh,
            this.Lb_MovePrice});
            this.TitleHeader.Height = 0.5416667F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            // Lb_BfSection
            // 
            this.Lb_BfSection.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfSection.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection.Height = 0.156F;
            this.Lb_BfSection.HyperLink = "";
            this.Lb_BfSection.Left = 0F;
            this.Lb_BfSection.MultiLine = false;
            this.Lb_BfSection.Name = "Lb_BfSection";
            this.Lb_BfSection.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfSection.Text = "出庫拠点";
            this.Lb_BfSection.Top = 0.01F;
            this.Lb_BfSection.Width = 1.375F;
            // 
            // Lb_AfSection
            // 
            this.Lb_AfSection.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfSection.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection.Height = 0.156F;
            this.Lb_AfSection.HyperLink = "";
            this.Lb_AfSection.Left = 3F;
            this.Lb_AfSection.MultiLine = false;
            this.Lb_AfSection.Name = "Lb_AfSection";
            this.Lb_AfSection.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfSection.Text = "入庫拠点";
            this.Lb_AfSection.Top = 0.01F;
            this.Lb_AfSection.Width = 1.375F;
            // 
            // Lb_AfEnterWareh
            // 
            this.Lb_AfEnterWareh.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh.Height = 0.156F;
            this.Lb_AfEnterWareh.HyperLink = "";
            this.Lb_AfEnterWareh.Left = 4.4375F;
            this.Lb_AfEnterWareh.MultiLine = false;
            this.Lb_AfEnterWareh.Name = "Lb_AfEnterWareh";
            this.Lb_AfEnterWareh.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfEnterWareh.Text = "入庫倉庫";
            this.Lb_AfEnterWareh.Top = 0.01F;
            this.Lb_AfEnterWareh.Width = 1.5F;
            // 
            // Lb_MoveCount
            // 
            this.Lb_MoveCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MoveCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveCount.Height = 0.15625F;
            this.Lb_MoveCount.HyperLink = "";
            this.Lb_MoveCount.Left = 6.6875F;
            this.Lb_MoveCount.MultiLine = false;
            this.Lb_MoveCount.Name = "Lb_MoveCount";
            this.Lb_MoveCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MoveCount.Text = "移動点数";
            this.Lb_MoveCount.Top = 0.01F;
            this.Lb_MoveCount.Width = 0.75F;
            // 
            // Lb_AfSection_Dm
            // 
            this.Lb_AfSection_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfSection_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfSection_Dm.Height = 0.156F;
            this.Lb_AfSection_Dm.HyperLink = "";
            this.Lb_AfSection_Dm.Left = 0F;
            this.Lb_AfSection_Dm.MultiLine = false;
            this.Lb_AfSection_Dm.Name = "Lb_AfSection_Dm";
            this.Lb_AfSection_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfSection_Dm.Text = "入庫拠点";
            this.Lb_AfSection_Dm.Top = 0.375F;
            this.Lb_AfSection_Dm.Visible = false;
            this.Lb_AfSection_Dm.Width = 1.375F;
            // 
            // Lb_AfEnterWareh_Dm
            // 
            this.Lb_AfEnterWareh_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AfEnterWareh_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AfEnterWareh_Dm.Height = 0.156F;
            this.Lb_AfEnterWareh_Dm.HyperLink = "";
            this.Lb_AfEnterWareh_Dm.Left = 1.4375F;
            this.Lb_AfEnterWareh_Dm.MultiLine = false;
            this.Lb_AfEnterWareh_Dm.Name = "Lb_AfEnterWareh_Dm";
            this.Lb_AfEnterWareh_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AfEnterWareh_Dm.Text = "入庫倉庫";
            this.Lb_AfEnterWareh_Dm.Top = 0.375F;
            this.Lb_AfEnterWareh_Dm.Visible = false;
            this.Lb_AfEnterWareh_Dm.Width = 1.5F;
            // 
            // Lb_BfSection_Dm
            // 
            this.Lb_BfSection_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfSection_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfSection_Dm.Height = 0.156F;
            this.Lb_BfSection_Dm.HyperLink = "";
            this.Lb_BfSection_Dm.Left = 3F;
            this.Lb_BfSection_Dm.MultiLine = false;
            this.Lb_BfSection_Dm.Name = "Lb_BfSection_Dm";
            this.Lb_BfSection_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfSection_Dm.Text = "出庫拠点";
            this.Lb_BfSection_Dm.Top = 0.375F;
            this.Lb_BfSection_Dm.Visible = false;
            this.Lb_BfSection_Dm.Width = 1.375F;
            // 
            // Lb_BfEnterWareh_Dm
            // 
            this.Lb_BfEnterWareh_Dm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh_Dm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh_Dm.Height = 0.156F;
            this.Lb_BfEnterWareh_Dm.HyperLink = "";
            this.Lb_BfEnterWareh_Dm.Left = 4.4375F;
            this.Lb_BfEnterWareh_Dm.MultiLine = false;
            this.Lb_BfEnterWareh_Dm.Name = "Lb_BfEnterWareh_Dm";
            this.Lb_BfEnterWareh_Dm.Style = "color: Silver; ddo-char-set: 128; text-align: left; font-weight: bold; font-size:" +
                " 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfEnterWareh_Dm.Text = "出庫倉庫";
            this.Lb_BfEnterWareh_Dm.Top = 0.375F;
            this.Lb_BfEnterWareh_Dm.Visible = false;
            this.Lb_BfEnterWareh_Dm.Width = 1.5F;
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
            this.label1.Left = 5.9375F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "移動枚数";
            this.label1.Top = 0.01F;
            this.label1.Width = 0.75F;
            // 
            // Lb_BfEnterWareh
            // 
            this.Lb_BfEnterWareh.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BfEnterWareh.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BfEnterWareh.Height = 0.156F;
            this.Lb_BfEnterWareh.HyperLink = "";
            this.Lb_BfEnterWareh.Left = 1.4375F;
            this.Lb_BfEnterWareh.MultiLine = false;
            this.Lb_BfEnterWareh.Name = "Lb_BfEnterWareh";
            this.Lb_BfEnterWareh.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BfEnterWareh.Text = "出庫倉庫";
            this.Lb_BfEnterWareh.Top = 0.01F;
            this.Lb_BfEnterWareh.Width = 1.5F;
            // 
            // Lb_MovePrice
            // 
            this.Lb_MovePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MovePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MovePrice.Height = 0.156F;
            this.Lb_MovePrice.HyperLink = "";
            this.Lb_MovePrice.Left = 7.4375F;
            this.Lb_MovePrice.MultiLine = false;
            this.Lb_MovePrice.Name = "Lb_MovePrice";
            this.Lb_MovePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MovePrice.Text = "移動金額";
            this.Lb_MovePrice.Top = 0.01F;
            this.Lb_MovePrice.Width = 0.9375F;
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
            this.GrandTtl_MovingTotalStock,
            this.GrandTtl_StockPrice,
            this.textBox5});
            this.GrandTotalFooter.Height = 0.25025F;
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
            this.ALLTOTALTITLE.Left = 4.94F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03125F;
            this.ALLTOTALTITLE.Width = 0.688F;
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
            // GrandTtl_MovingTotalStock
            // 
            this.GrandTtl_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTtl_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_MovingTotalStock.DataField = "MoveCount";
            this.GrandTtl_MovingTotalStock.Height = 0.219F;
            this.GrandTtl_MovingTotalStock.Left = 6.688F;
            this.GrandTtl_MovingTotalStock.MultiLine = false;
            this.GrandTtl_MovingTotalStock.Name = "GrandTtl_MovingTotalStock";
            this.GrandTtl_MovingTotalStock.OutputFormat = resources.GetString("GrandTtl_MovingTotalStock.OutputFormat");
            this.GrandTtl_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTtl_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTtl_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTtl_MovingTotalStock.Text = "123456789";
            this.GrandTtl_MovingTotalStock.Top = 0.03125F;
            this.GrandTtl_MovingTotalStock.Width = 0.75F;
            // 
            // GrandTtl_StockPrice
            // 
            this.GrandTtl_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTtl_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTtl_StockPrice.DataField = "StockPrice";
            this.GrandTtl_StockPrice.Height = 0.219F;
            this.GrandTtl_StockPrice.Left = 7.438F;
            this.GrandTtl_StockPrice.MultiLine = false;
            this.GrandTtl_StockPrice.Name = "GrandTtl_StockPrice";
            this.GrandTtl_StockPrice.OutputFormat = resources.GetString("GrandTtl_StockPrice.OutputFormat");
            this.GrandTtl_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrandTtl_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTtl_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTtl_StockPrice.Text = "1,234,567,890";
            this.GrandTtl_StockPrice.Top = 0.03125F;
            this.GrandTtl_StockPrice.Width = 0.938F;
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
            this.textBox5.DataField = "StockMoveSlipCnt";
            this.textBox5.Height = 0.219F;
            this.textBox5.Left = 5.938F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox5.Text = "123456789";
            this.textBox5.Top = 0.031F;
            this.textBox5.Width = 0.75F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_MainSectionName,
            this.Sec_MainSectionCode});
            this.SectionHeader.Height = 0.15625F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
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
            this.tb_MainSectionName.Left = 0.4375F;
            this.tb_MainSectionName.MultiLine = false;
            this.tb_MainSectionName.Name = "tb_MainSectionName";
            this.tb_MainSectionName.Style = "color: Silver; ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-al" +
                "ign: top; ";
            this.tb_MainSectionName.Text = "あいうえおか";
            this.tb_MainSectionName.Top = 0F;
            this.tb_MainSectionName.Visible = false;
            this.tb_MainSectionName.Width = 0.75F;
            // 
            // Sec_MainSectionCode
            // 
            this.Sec_MainSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_MainSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MainSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_MainSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MainSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_MainSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MainSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_MainSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MainSectionCode.CanShrink = true;
            this.Sec_MainSectionCode.DataField = "MainSectionCode";
            this.Sec_MainSectionCode.Height = 0.15625F;
            this.Sec_MainSectionCode.Left = 0.03125F;
            this.Sec_MainSectionCode.MultiLine = false;
            this.Sec_MainSectionCode.Name = "Sec_MainSectionCode";
            this.Sec_MainSectionCode.Style = "color: Silver; ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-" +
                "align: top; ";
            this.Sec_MainSectionCode.Text = "123456";
            this.Sec_MainSectionCode.Top = 0F;
            this.Sec_MainSectionCode.Visible = false;
            this.Sec_MainSectionCode.Width = 0.40625F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.Sec_MovingTotalStock,
            this.Sec_StockPrice,
            this.textBox4});
            this.SectionFooter.Height = 0.26F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
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
            this.SECTOTALTITLE.Left = 4.94F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "拠点計";
            this.SECTOTALTITLE.Top = 0.03125F;
            this.SECTOTALTITLE.Width = 0.688F;
            // 
            // Sec_MovingTotalStock
            // 
            this.Sec_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_MovingTotalStock.DataField = "MoveCount";
            this.Sec_MovingTotalStock.Height = 0.219F;
            this.Sec_MovingTotalStock.Left = 6.688F;
            this.Sec_MovingTotalStock.MultiLine = false;
            this.Sec_MovingTotalStock.Name = "Sec_MovingTotalStock";
            this.Sec_MovingTotalStock.OutputFormat = resources.GetString("Sec_MovingTotalStock.OutputFormat");
            this.Sec_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_MovingTotalStock.SummaryGroup = "SectionHeader";
            this.Sec_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_MovingTotalStock.Text = "123456789";
            this.Sec_MovingTotalStock.Top = 0.03125F;
            this.Sec_MovingTotalStock.Width = 0.75F;
            // 
            // Sec_StockPrice
            // 
            this.Sec_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockPrice.DataField = "StockPrice";
            this.Sec_StockPrice.Height = 0.219F;
            this.Sec_StockPrice.Left = 7.438F;
            this.Sec_StockPrice.MultiLine = false;
            this.Sec_StockPrice.Name = "Sec_StockPrice";
            this.Sec_StockPrice.OutputFormat = resources.GetString("Sec_StockPrice.OutputFormat");
            this.Sec_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_StockPrice.SummaryGroup = "SectionHeader";
            this.Sec_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_StockPrice.Text = "1,234,567,890";
            this.Sec_StockPrice.Top = 0.03125F;
            this.Sec_StockPrice.Width = 0.938F;
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
            this.textBox4.DataField = "StockMoveSlipCnt";
            this.textBox4.Height = 0.219F;
            this.textBox4.Left = 5.938F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox4.SummaryGroup = "SectionHeader";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "123456789";
            this.textBox4.Top = 0.03125F;
            this.textBox4.Width = 0.75F;
            // 
            // WareHouseHeader
            // 
            this.WareHouseHeader.CanShrink = true;
            this.WareHouseHeader.DataField = "MainWhareHouseCode";
            this.WareHouseHeader.Height = 0F;
            this.WareHouseHeader.Name = "WareHouseHeader";
            // 
            // WareHouseFooter
            // 
            this.WareHouseFooter.CanShrink = true;
            this.WareHouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox3,
            this.Wh_MovingTotalStock,
            this.Wh_StockPrice,
            this.Line,
            this.textBox2});
            this.WareHouseFooter.Height = 0.26F;
            this.WareHouseFooter.KeepTogether = true;
            this.WareHouseFooter.Name = "WareHouseFooter";
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
            this.TextBox3.Left = 4.9375F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox3.Text = "倉庫計";
            this.TextBox3.Top = 0.031F;
            this.TextBox3.Width = 0.6875F;
            // 
            // Wh_MovingTotalStock
            // 
            this.Wh_MovingTotalStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_MovingTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MovingTotalStock.DataField = "MoveCount";
            this.Wh_MovingTotalStock.Height = 0.219F;
            this.Wh_MovingTotalStock.Left = 6.688F;
            this.Wh_MovingTotalStock.MultiLine = false;
            this.Wh_MovingTotalStock.Name = "Wh_MovingTotalStock";
            this.Wh_MovingTotalStock.OutputFormat = resources.GetString("Wh_MovingTotalStock.OutputFormat");
            this.Wh_MovingTotalStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_MovingTotalStock.SummaryGroup = "WareHouseHeader";
            this.Wh_MovingTotalStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_MovingTotalStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_MovingTotalStock.Text = "123456789";
            this.Wh_MovingTotalStock.Top = 0.03125F;
            this.Wh_MovingTotalStock.Width = 0.75F;
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
            this.Wh_StockPrice.Height = 0.219F;
            this.Wh_StockPrice.Left = 7.4375F;
            this.Wh_StockPrice.MultiLine = false;
            this.Wh_StockPrice.Name = "Wh_StockPrice";
            this.Wh_StockPrice.OutputFormat = resources.GetString("Wh_StockPrice.OutputFormat");
            this.Wh_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_StockPrice.SummaryGroup = "WareHouseHeader";
            this.Wh_StockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_StockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_StockPrice.Text = "1,234,567,890";
            this.Wh_StockPrice.Top = 0.031F;
            this.Wh_StockPrice.Width = 0.938F;
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
            this.textBox2.DataField = "StockMoveSlipCnt";
            this.textBox2.Height = 0.219F;
            this.textBox2.Left = 5.938F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryGroup = "WareHouseHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "123456789";
            this.textBox2.Top = 0.031F;
            this.textBox2.Width = 0.75F;
            // 
            // MAZAI02032P_05A4C
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
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WareHouseHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.WareHouseFooter);
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
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_05A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfSectionGuideSnm_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionGuideSnm_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfSectionCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehName_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfEnterWarehCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfEnterWarehCode_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfSection_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AfEnterWareh_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfSection_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh_Dm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BfEnterWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MovePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTtl_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MainSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_MainSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MovingTotalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
