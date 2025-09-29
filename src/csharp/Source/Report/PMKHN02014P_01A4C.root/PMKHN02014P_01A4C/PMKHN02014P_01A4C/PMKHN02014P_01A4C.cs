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
	/// 掛率マスタ印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 掛率マスタのフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.16</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote   : 2008/10/29 30462 行澤 仁美　バグ修正</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote   : 2009/02/13 30414 忍 幸史　バグ修正[11464]</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote   : 2009/03/09 30452 上野 俊治　フォーマット修正</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote   : 2010/02/04 30434 工藤 恵優　MANTIS対応[14970]：得意先コードおよび仕入先コードも印字</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote   : 2011/07/22 李占川　NSユーザー改良要望一覧の連番898の対応：価格の印字項目を追加する</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN02014P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 掛率マスタフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 掛率マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.16</br>
		/// </remarks>
		public PMKHN02014P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									    // 印刷件数用カウンタ
        private int _printCountp;									    // ページ内印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				    // 抽出条件
		private int					_pageFooterOutCode;				    // フッター出力区分
		private StringCollection	_pageFooters;					    // フッターメッセージ
		private	SFCMN06002C			_printInfo;						    // 印刷情報クラス
		private string				_pageHeaderTitle;				    // フォームタイトル
		private string				_pageHeaderSortOderTitle;		    // ソート順

        private RatePrtReqCndtn     _ratePrtReqCndtn;                   // 抽出条件クラス

        private string _beforeRateSettingDivide = string.Empty;                      // 前回値(グループサプレス用)
        private string _beforeLogicalDeleteCode = string.Empty;
        private string _beforeCustRateGrpCode = string.Empty;
        //private string _beforeCustomerSnm = string.Empty; // DEL 2009/03/12
        //private string _beforeSupplierSnm = string.Empty; // DEL 2009/03/12
        private string _beforeCustomerCode = string.Empty; // ADD 2009/03/12
        private string _beforeSupplierCd = string.Empty; // ADD 2009/03/12
        private string _beforeGoodsMakerCd = string.Empty;
        private string _beforeGoodsRateRank = string.Empty;
        private string _beforeGoodsRateGrpCode = string.Empty;
        private string _beforeBLGroupCode = string.Empty;
        private string _beforeBLGoodsCode = string.Empty;
        private string _beforeGoodsNo = string.Empty;

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox RateSettingDivide;
        private TextBox LogicalDeleteCode;
        private TextBox CustomerSnm;
        private TextBox SupplierSnm;
        private TextBox GoodsMakerCd;
        private TextBox MakerShortName;
        private TextBox GoodsRateGrpCode;
        private TextBox GoodsRateRank;
        private TextBox BLGroupCode;
        private TextBox BLGroupKanaName;
        private TextBox BLGoodsCode;
        private TextBox BLGoodsHalfName;
        private TextBox GoodsNo;
        private TextBox GoodsNameKana;
        private TextBox LotCount;
        private TextBox SalRateVal;
        private TextBox SalPriceFl;
        private TextBox SalUpRate;
        private TextBox UnPrcFracProcUnit;
        private TextBox UnPrcFracProcDiv;
        private TextBox CustRateGrpCode;
        private Line line2;
        private Label Lb_SalRateVal;
        private Label label17;
        private Label Lb_SalPriceFl;
        private Label Lb_SalUpRate;
        private Label Lb_GrsProfitSecureRate;
        private Label Lb_UnPrcFracProcUnit;
        private Label label22;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private TextBox tb_SectionGuideSnm;
        public TextBox CstRateVal;
        private TextBox CstPriceFl;
        private Label Lb_CstRateVal;
        private Label Lb_CstPriceFl;
        private TextBox PrcPriceFl;
        private TextBox PrcUpRate;
        private Label Lb_PrcPriceFl;
        private Label Lb_PrcUpRate;
        private TextBox RateVal_L;
        private TextBox UpRate_L;
        private TextBox GrsProfitSecureRate_L;
        private TextBox GrsProfitSecureRate;
        private Line line3;
        private TextBox SupplierCd;
        private TextBox CustomerCode;
        private Label lblCustomerCode;
        private Label lblSupplierCd;
        // --- ADD 2011/07/22 ---------->>>>>
        private TextBox Price;
        private Label Lb_Price;
        // --- ADD 2011/07/22  ----------<<<<<

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
                this._ratePrtReqCndtn = (RatePrtReqCndtn)this._printInfo.jyoken;
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
				// TODO:  DCZAI02163P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  DCZAI02163P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
        /// <br>Update Note : 2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
        /// <br>              価格の印字項目を追加する</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
            this._printCountp = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            // グループ対象の項目指定        

            if (this._ratePrtReqCndtn.UnitPriceKind.Equals(1))
            {
                // 売価設定選択時

                #region ヘッダ部
                // 売価設定
                this.Lb_SalRateVal.Visible = true;
                this.Lb_SalPriceFl.Visible = true;
                this.Lb_SalUpRate.Visible = true;
                this.Lb_GrsProfitSecureRate.Visible = true;

                // 原価設定
                this.Lb_CstRateVal.Visible = false;
                this.Lb_CstPriceFl.Visible = false;

                // 価格設定
                this.Lb_PrcPriceFl.Visible = false;
                this.Lb_PrcUpRate.Visible = false;
                this.Lb_Price.Visible = false; // ADD 2011/07/22

                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------>>>>>
                this.Lb_UnPrcFracProcUnit.Visible = false;
                this.label22.Visible = false;
                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------<<<<<
                #endregion

                #region 詳細部
                // 売価設定
                // DEL 2008/10/29 不具合対応[7167] ---------->>>>>
                //this.SalRateVal.Visible = true;
                //this.RateVal_L.Visible = true;
                //this.SalPriceFl.Visible = true;
                //this.SalUpRate.Visible = true;
                //this.UpRate_L.Visible = true;
                //this.GrsProfitSecureRate.Visible = true;
                //this.GrsProfitSecureRate_L.Visible = true;
                // DEL 2008/10/29 不具合対応[7167] ----------<<<<<
                // ADD 2008/10/29 不具合対応[7167] ---------->>>>>
                if (this._ratePrtReqCndtn.RateMngGoodsCdKind.Equals(1))
                {
                    // グループ設定
                    this.SalRateVal.Visible = true;
                    this.RateVal_L.Visible = true;
                    this.SalPriceFl.Visible = false;        // グループ設定の場合空白
                    this.SalUpRate.Visible = true;
                    this.UpRate_L.Visible = true;
                    this.GrsProfitSecureRate.Visible = true;
                    this.GrsProfitSecureRate_L.Visible = true;
                }
                else
                {
                    // 単品設定
                    this.SalRateVal.Visible = true;
                    this.RateVal_L.Visible = true;
                    this.SalPriceFl.Visible = true;
                    this.SalUpRate.Visible = true;
                    this.UpRate_L.Visible = true;
                    this.GrsProfitSecureRate.Visible = true;
                    this.GrsProfitSecureRate_L.Visible = true;
                }
                // ADD 2008/10/29 不具合対応[7167] ----------<<<<<

                // 原価設定
                this.CstRateVal.Visible = false;
                this.CstPriceFl.Visible = false;

                // 価格設定
                this.PrcPriceFl.Visible = false;
                this.PrcUpRate.Visible = false;
                this.Price.Visible = false; // ADD 2011/07/22

                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------>>>>>
                this.UnPrcFracProcUnit.Visible = false;
                this.UnPrcFracProcDiv.Visible = false;
                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------<<<<<
                #endregion

            }
            else if (this._ratePrtReqCndtn.UnitPriceKind.Equals(2))
            {
                // 原価設定選択時

                #region ヘッダ部
                // 売価設定
                this.Lb_SalRateVal.Visible = false;
                this.Lb_SalPriceFl.Visible = false;
                this.Lb_SalUpRate.Visible = false;
                this.Lb_GrsProfitSecureRate.Visible = false;

                // 原価設定
                this.Lb_CstRateVal.Top = this.Lb_SalRateVal.Top;
                this.Lb_CstPriceFl.Top = this.Lb_SalRateVal.Top;
                this.Lb_CstRateVal.Visible = true;
                this.Lb_CstPriceFl.Visible = true;

                // 価格設定
                this.Lb_PrcPriceFl.Visible = false;
                this.Lb_PrcUpRate.Visible = false;
                this.Lb_Price.Visible = false;  // ADD 2011/07/22

                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------>>>>>
                this.Lb_UnPrcFracProcUnit.Visible = false;
                this.label22.Visible = false;
                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------<<<<<
                #endregion

                #region 詳細部
                // 売価設定
                this.SalRateVal.Visible = false;
                this.SalPriceFl.Visible = false;
                this.SalUpRate.Visible = false;
                this.UpRate_L.Visible = false;
                this.GrsProfitSecureRate.Visible = false;
                this.GrsProfitSecureRate_L.Visible = false;

                // 原価設定
                this.CstRateVal.Top = this.RateVal_L.Top;
                this.CstPriceFl.Top = this.RateVal_L.Top;
                // DEL 2008/10/29 不具合対応[7167] ---------->>>>>
                //this.CstRateVal.Visible = true;
                //this.RateVal_L.Visible = true;
                //this.CstPriceFl.Visible = true;
                // DEL 2008/10/29 不具合対応[7167] ----------<<<<<
                // ADD 2008/10/29 不具合対応[7167] ---------->>>>>
                if (this._ratePrtReqCndtn.RateMngGoodsCdKind.Equals(1))
                {
                    // グループ設定
                    this.CstRateVal.Visible = true;
                    this.RateVal_L.Visible = true;
                    this.CstPriceFl.Visible = false;        // グループ設定の場合空白
                }
                else
                {
                    // 単品設定
                    this.CstRateVal.Visible = true;
                    this.RateVal_L.Visible = true;
                    this.CstPriceFl.Visible = true;
                }
                // ADD 2008/10/29 不具合対応[7167] ----------<<<<<                

                // 価格設定
                this.PrcPriceFl.Visible = false;
                this.PrcUpRate.Visible = false;
                this.Price.Visible = false; // ADD 2011/07/22

                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------>>>>>
                this.UnPrcFracProcUnit.Visible = false;
                this.UnPrcFracProcDiv.Visible = false;
                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------<<<<<
                #endregion
            }
            else if (this._ratePrtReqCndtn.UnitPriceKind.Equals(3))
            {
                // 価格設定選択時

                #region ヘッダ部
                // 売価設定
                this.Lb_SalRateVal.Visible = false;
                this.Lb_SalPriceFl.Visible = false;
                this.Lb_SalUpRate.Visible = false;
                this.Lb_GrsProfitSecureRate.Visible = false;

                // 原価設定                
                this.Lb_CstRateVal.Visible = false;
                this.Lb_CstPriceFl.Visible = false;

                // 価格設定
                this.Lb_PrcPriceFl.Top = this.Lb_SalRateVal.Top;
                this.Lb_PrcUpRate.Top = this.Lb_SalRateVal.Top;
                this.Lb_PrcPriceFl.Visible = true;
                this.Lb_PrcUpRate.Visible = true;
                // --- ADD 2011/07/22 ---------->>>>>
                this.Lb_Price.Visible = true;
                this.Lb_Price.Top = this.Lb_SalRateVal.Top;
                // --- ADD 2011/07/22  ----------<<<<<

                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------>>>>>
                this.Lb_UnPrcFracProcUnit.Visible = true;
                this.label22.Visible = true;
                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------<<<<<

                #endregion

                #region 詳細部
                // 売価設定
                this.SalRateVal.Visible = false;
                this.RateVal_L.Visible = false;
                this.SalPriceFl.Visible = false;
                this.SalUpRate.Visible = false;
                this.GrsProfitSecureRate.Visible = false;
                this.GrsProfitSecureRate_L.Visible = false;

                // 原価設定
                this.CstRateVal.Visible = false;
                this.CstPriceFl.Visible = false;

                // 価格設定
                this.PrcPriceFl.Top = this.UpRate_L.Top;
                this.PrcUpRate.Top = this.UpRate_L.Top;
                this.Price.Top = this.UpRate_L.Top; // ADD 2011/07/22
                // DEL 2008/10/29 不具合対応[7167] ---------->>>>>
                //this.PrcPriceFl.Visible = true;
                //this.PrcUpRate.Visible = true;
                //this.UpRate_L.Visible = true;
                // DEL 2008/10/29 不具合対応[7167] ----------<<<<<
                // ADD 2008/10/29 不具合対応[7167] ---------->>>>>
                if (this._ratePrtReqCndtn.RateMngGoodsCdKind.Equals(1))
                {
                    // グループ設定
                    this.PrcPriceFl.Visible = false;        // グループ設定の場合空白
                    this.PrcUpRate.Visible = true;
                    this.UpRate_L.Visible = true;
                    this.Price.Visible = false; // ADD 2011/07/22
                }
                else
                {
                    // 単品設定
                    this.PrcPriceFl.Visible = true;
                    this.PrcUpRate.Visible = true;
                    this.UpRate_L.Visible = true;
                    this.Price.Visible = true; // ADD 2011/07/22
                }
                // ADD 2008/10/29 不具合対応[7167] ----------<<<<<

                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------>>>>>
                this.UnPrcFracProcUnit.Visible = true;
                this.UnPrcFracProcDiv.Visible = true;
                // --- ADD 2009/02/13 障害ID:11464対応------------------------------------------------------<<<<<
                #endregion
            }
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.16</br>
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.16</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.16</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.16</br>
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

            this._rptExtraHeader.SectionCondition.Text = "拠点：" + this.tb_SectionGuideSnm.Value;
            
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.16</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // 削除区分
            if (this.LogicalDeleteCode.Value.Equals(1))
            {
                this.LogicalDeleteCode.Value = "削除";
            }
            else
            {
                this.LogicalDeleteCode.Value = "";
            }

            // ADD 2010/02/04 MANTIS対応[14970]：得意先コードおよび仕入先コードも印字 ---------->>>>>
            // 得意先コード
            if (this.CustomerCode.Value.Equals(0))
            {
                this.CustomerCode.Value = string.Empty;
            }

            // 仕入先コード
            if (this.SupplierCd.Value.Equals(0))
            {
                this.SupplierCd.Value = string.Empty;
            }
            // ADD 2010/02/04 MANTIS対応[14970]：得意先コードおよび仕入先コードも印字 ----------<<<<<

            // 得意先掛率グループ表示設定
            if (this.CustRateGrpCode.Value.Equals(0))
            {
                this.CustRateGrpCode.Value = "";
            }

            // ﾒｰｶｰｺｰﾄﾞ
            if (this.GoodsMakerCd.Value.Equals(0))
            {
                this.GoodsMakerCd.Value = "";
            }

            // 商Gｺｰﾄﾞ
            if (this.GoodsRateGrpCode.Value.Equals(0))
            {
                this.GoodsRateGrpCode.Value = "";
            }

            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            if (this.BLGroupCode.Value.Equals(0))
            {
                this.BLGroupCode.Value = "";
            }

            // BLｺｰﾄﾞ
            if (this.BLGoodsCode.Value.Equals(0))
            {
                this.BLGoodsCode.Value = "";
            }

            // 端数処理区分
            if (this.UnPrcFracProcDiv.Value.Equals(1))
            {
                //this.UnPrcFracProcDiv.Value = "切捨";   // DEL 2008/10/29 不具合対応[7165]
                this.UnPrcFracProcDiv.Value = "切捨て";   // ADD 2008/10/29 不具合対応[7165]
            }
            else if (this.UnPrcFracProcDiv.Value.Equals(2))
            {
                this.UnPrcFracProcDiv.Value = "四捨五入";
            }
            else if (this.UnPrcFracProcDiv.Value.Equals(3))
            {
                this.UnPrcFracProcDiv.Value = "切上げ";
            }
            else
            {
                this.UnPrcFracProcDiv.Value = "";
            }

            // グループ化処理
            if (this.RateSettingDivide.Text == this._beforeRateSettingDivide &&
                this.LogicalDeleteCode.Text == this._beforeLogicalDeleteCode &&
                this.CustRateGrpCode.Text == this._beforeCustRateGrpCode &&
                //this.CustomerSnm.Text == this._beforeCustomerSnm && // DEL 2009/03/12
                //this.SupplierSnm.Text == this._beforeSupplierSnm && // DEL 2009/03/12
                this.CustomerCode.Text == this._beforeCustomerCode && // ADD 2009/03/12
                this.SupplierCd.Text == this._beforeSupplierCd && // ADD 2009/03/12
                this.GoodsMakerCd.Text == this._beforeGoodsMakerCd &&
                this.GoodsRateRank.Text == this._beforeGoodsRateRank &&
                this.GoodsRateGrpCode.Text == this._beforeGoodsRateGrpCode &&
                this.BLGroupCode.Text == this._beforeBLGroupCode &&
                this.BLGoodsCode.Text == this._beforeBLGoodsCode &&
                this.GoodsNo.Text == this._beforeGoodsNo)
            {
                this.RateSettingDivide.Visible = false;
                this.LogicalDeleteCode.Visible = false;
                // ADD 2010/02/04 MANTIS対応[14970]：得意先コードおよび仕入先コードも印字 ---------->>>>>
                this.CustomerCode.Visible = false;
                this.SupplierCd.Visible = false;
                // ADD 2010/02/04 MANTIS対応[14970]：得意先コードおよび仕入先コードも印字 ----------<<<<<
                this.CustRateGrpCode.Visible = false;
                this.CustomerSnm.Visible = false;
                this.SupplierSnm.Visible=false;
                this.GoodsMakerCd.Visible=false;
                this.MakerShortName.Visible=false;
                this.GoodsRateRank.Visible=false;
                this.GoodsRateGrpCode.Visible = false;
                this.BLGroupCode.Visible=false;
                this.BLGroupKanaName.Visible = false;
                this.BLGoodsCode.Visible = false;
                this.BLGoodsHalfName.Visible = false;
                this.GoodsNo.Visible = false;
                this.GoodsNameKana.Visible = false;
            }
            else
            {
                this.RateSettingDivide.Visible = true;
                this.LogicalDeleteCode.Visible = true;
                this.CustRateGrpCode.Visible = true;
                // ADD 2010/02/04 MANTIS対応[14970]：得意先コードおよび仕入先コードも印字 ---------->>>>>
                this.CustomerCode.Visible = true;
                this.SupplierCd.Visible = true;
                // ADD 2010/02/04 MANTIS対応[14970]：得意先コードおよび仕入先コードも印字 ----------<<<<<
                this.CustomerSnm.Visible = true;
                this.SupplierSnm.Visible = true;
                this.GoodsMakerCd.Visible = true;
                this.MakerShortName.Visible = true;
                this.GoodsRateRank.Visible = true;
                this.GoodsRateGrpCode.Visible = true;
                this.BLGroupCode.Visible = true;
                this.BLGroupKanaName.Visible = true;
                this.BLGoodsCode.Visible = true;
                this.BLGoodsHalfName.Visible = true;
                this.GoodsNo.Visible = true;
                this.GoodsNameKana.Visible = true;
            }


            this._beforeRateSettingDivide = this.RateSettingDivide.Text;
            this._beforeLogicalDeleteCode = this.LogicalDeleteCode.Text;
            this._beforeCustRateGrpCode = this.CustRateGrpCode.Text;
            //this._beforeCustomerSnm = this.CustomerSnm.Text; // DEL 2009/03/12
            //this._beforeSupplierSnm = this.SupplierSnm.Text; // DEL 2009/03/12
            this._beforeCustomerCode = this.CustomerCode.Text; // ADD 2009/03/12
            this._beforeSupplierCd = this.SupplierCd.Text; // ADD 2009/03/12
            this._beforeGoodsMakerCd = this.GoodsMakerCd.Text;
            this._beforeGoodsRateRank = this.GoodsRateRank.Text;
            this._beforeGoodsRateGrpCode = this.GoodsRateGrpCode.Text;
            this._beforeBLGroupCode = this.BLGroupCode.Text;
            this._beforeBLGoodsCode = this.BLGoodsCode.Text;
            this._beforeGoodsNo = this.GoodsNo.Text;


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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
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
		/// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }

            this._printCountp++;
            // 19明細で改ページするため
            if (this._printCountp == 19)
            {
                this._printCountp = 0;

                // 前回値をクリア
                _beforeRateSettingDivide = string.Empty;
                _beforeLogicalDeleteCode = string.Empty;
                _beforeCustRateGrpCode = string.Empty;
                //_beforeCustomerSnm = string.Empty; // DEL 2009/03/12
                //_beforeSupplierSnm = string.Empty; // DEL 2009/03/12
                _beforeCustomerCode = string.Empty; // ADD 2009/03/12
                _beforeSupplierCd = string.Empty; // ADD 2009/03/12
                _beforeGoodsMakerCd = string.Empty;
                _beforeGoodsRateRank = string.Empty;
                _beforeGoodsRateGrpCode = string.Empty;
                _beforeBLGroupCode = string.Empty;
                _beforeBLGoodsCode = string.Empty;
                _beforeGoodsNo = string.Empty;
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
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

        #region ◎ SectionHeader_AfterPrint Event
        /// <summary>
        /// SectionHeader_AfterPrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
        /// </remarks>
        private void SectionHeader_AfterPrint(object sender, EventArgs e)
        {
            // 前回値をクリア
            _beforeRateSettingDivide = string.Empty;
            _beforeLogicalDeleteCode = string.Empty;
            _beforeCustRateGrpCode = string.Empty;
            //_beforeCustomerSnm = string.Empty; // DEL 2009/03/12
            //_beforeSupplierSnm = string.Empty; // DEL 2009/03/12
            _beforeCustomerCode = string.Empty; // ADD 2009/03/12
            _beforeSupplierCd = string.Empty; // ADD 2009/03/12
            _beforeGoodsMakerCd = string.Empty;
            _beforeGoodsRateRank = string.Empty;
            _beforeGoodsRateGrpCode = string.Empty;
            _beforeBLGroupCode = string.Empty;
            _beforeBLGoodsCode = string.Empty;
            _beforeGoodsNo = string.Empty;
        }
        #endregion

        #region ◎ PageFooter_AfterPrint Event
        /// <summary>
        /// PageFooter_AfterPrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.16</br>
        /// </remarks>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
                this._printCountp = 0;
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
        private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Detail Detail;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN02014P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.RateSettingDivide = new DataDynamics.ActiveReports.TextBox();
            this.LogicalDeleteCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerShortName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsRateGrpCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsRateRank = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupKanaName = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana = new DataDynamics.ActiveReports.TextBox();
            this.LotCount = new DataDynamics.ActiveReports.TextBox();
            this.SalRateVal = new DataDynamics.ActiveReports.TextBox();
            this.SalPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.SalUpRate = new DataDynamics.ActiveReports.TextBox();
            this.UnPrcFracProcUnit = new DataDynamics.ActiveReports.TextBox();
            this.UnPrcFracProcDiv = new DataDynamics.ActiveReports.TextBox();
            this.CustRateGrpCode = new DataDynamics.ActiveReports.TextBox();
            this.CstRateVal = new DataDynamics.ActiveReports.TextBox();
            this.CstPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.PrcPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.PrcUpRate = new DataDynamics.ActiveReports.TextBox();
            this.RateVal_L = new DataDynamics.ActiveReports.TextBox();
            this.UpRate_L = new DataDynamics.ActiveReports.TextBox();
            this.GrsProfitSecureRate_L = new DataDynamics.ActiveReports.TextBox();
            this.GrsProfitSecureRate = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.Price = new DataDynamics.ActiveReports.TextBox();
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
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_SalRateVal = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.Lb_SalPriceFl = new DataDynamics.ActiveReports.Label();
            this.Lb_SalUpRate = new DataDynamics.ActiveReports.Label();
            this.Lb_GrsProfitSecureRate = new DataDynamics.ActiveReports.Label();
            this.Lb_UnPrcFracProcUnit = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.Lb_CstRateVal = new DataDynamics.ActiveReports.Label();
            this.Lb_CstPriceFl = new DataDynamics.ActiveReports.Label();
            this.Lb_PrcPriceFl = new DataDynamics.ActiveReports.Label();
            this.Lb_PrcUpRate = new DataDynamics.ActiveReports.Label();
            this.lblCustomerCode = new DataDynamics.ActiveReports.Label();
            this.lblSupplierCd = new DataDynamics.ActiveReports.Label();
            this.Lb_Price = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogicalDeleteCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupKanaName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LotCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalRateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalUpRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnPrcFracProcUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnPrcFracProcDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CstRateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CstPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrcPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrcUpRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateVal_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpRate_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitSecureRate_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitSecureRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalRateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalUpRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrsProfitSecureRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UnPrcFracProcUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CstRateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CstPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PrcPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PrcUpRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.RateSettingDivide,
            this.LogicalDeleteCode,
            this.CustomerSnm,
            this.SupplierSnm,
            this.GoodsMakerCd,
            this.MakerShortName,
            this.GoodsRateGrpCode,
            this.GoodsRateRank,
            this.BLGroupCode,
            this.BLGroupKanaName,
            this.BLGoodsCode,
            this.BLGoodsHalfName,
            this.GoodsNo,
            this.GoodsNameKana,
            this.LotCount,
            this.SalRateVal,
            this.SalPriceFl,
            this.SalUpRate,
            this.UnPrcFracProcUnit,
            this.UnPrcFracProcDiv,
            this.CustRateGrpCode,
            this.CstRateVal,
            this.CstPriceFl,
            this.PrcPriceFl,
            this.PrcUpRate,
            this.RateVal_L,
            this.UpRate_L,
            this.GrsProfitSecureRate_L,
            this.GrsProfitSecureRate,
            this.line3,
            this.SupplierCd,
            this.CustomerCode,
            this.Price});
            this.Detail.Height = 0.8125F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // RateSettingDivide
            // 
            this.RateSettingDivide.Border.BottomColor = System.Drawing.Color.Black;
            this.RateSettingDivide.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateSettingDivide.Border.LeftColor = System.Drawing.Color.Black;
            this.RateSettingDivide.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateSettingDivide.Border.RightColor = System.Drawing.Color.Black;
            this.RateSettingDivide.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateSettingDivide.Border.TopColor = System.Drawing.Color.Black;
            this.RateSettingDivide.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateSettingDivide.DataField = "RateSettingDivide";
            this.RateSettingDivide.Height = 0.15F;
            this.RateSettingDivide.Left = 0F;
            this.RateSettingDivide.MultiLine = false;
            this.RateSettingDivide.Name = "RateSettingDivide";
            this.RateSettingDivide.OutputFormat = resources.GetString("RateSettingDivide.OutputFormat");
            this.RateSettingDivide.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.RateSettingDivide.Text = "1234";
            this.RateSettingDivide.Top = 0.02083333F;
            this.RateSettingDivide.Width = 0.3125F;
            // 
            // LogicalDeleteCode
            // 
            this.LogicalDeleteCode.Border.BottomColor = System.Drawing.Color.Black;
            this.LogicalDeleteCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDeleteCode.Border.LeftColor = System.Drawing.Color.Black;
            this.LogicalDeleteCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDeleteCode.Border.RightColor = System.Drawing.Color.Black;
            this.LogicalDeleteCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDeleteCode.Border.TopColor = System.Drawing.Color.Black;
            this.LogicalDeleteCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDeleteCode.DataField = "LogicalDeleteCode";
            this.LogicalDeleteCode.Height = 0.15F;
            this.LogicalDeleteCode.Left = 0F;
            this.LogicalDeleteCode.MultiLine = false;
            this.LogicalDeleteCode.Name = "LogicalDeleteCode";
            this.LogicalDeleteCode.OutputFormat = resources.GetString("LogicalDeleteCode.OutputFormat");
            this.LogicalDeleteCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.LogicalDeleteCode.Text = "1234";
            this.LogicalDeleteCode.Top = 0.1875F;
            this.LogicalDeleteCode.Width = 0.3125F;
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
            this.CustomerSnm.DataField = "CustomerSnm";
            this.CustomerSnm.Height = 0.15F;
            this.CustomerSnm.Left = 0.8125F;
            this.CustomerSnm.MultiLine = false;
            this.CustomerSnm.Name = "CustomerSnm";
            this.CustomerSnm.OutputFormat = resources.GetString("CustomerSnm.OutputFormat");
            this.CustomerSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerSnm.Text = "あいうえおかきくけこ";
            this.CustomerSnm.Top = 0F;
            this.CustomerSnm.Width = 1.1875F;
            // 
            // SupplierSnm
            // 
            this.SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.DataField = "SupplierSnm";
            this.SupplierSnm.Height = 0.15F;
            this.SupplierSnm.Left = 0.8125F;
            this.SupplierSnm.MultiLine = false;
            this.SupplierSnm.Name = "SupplierSnm";
            this.SupplierSnm.OutputFormat = resources.GetString("SupplierSnm.OutputFormat");
            this.SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SupplierSnm.Text = "あいうえおかきくけこ";
            this.SupplierSnm.Top = 0.1875F;
            this.SupplierSnm.Width = 1.1875F;
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
            this.GoodsMakerCd.Height = 0.15F;
            this.GoodsMakerCd.Left = 2F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "12345";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.4374999F;
            // 
            // MakerShortName
            // 
            this.MakerShortName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.DataField = "MakerShortName";
            this.MakerShortName.Height = 0.15F;
            this.MakerShortName.Left = 2F;
            this.MakerShortName.MultiLine = false;
            this.MakerShortName.Name = "MakerShortName";
            this.MakerShortName.OutputFormat = resources.GetString("MakerShortName.OutputFormat");
            this.MakerShortName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerShortName.Text = "あいうえおかきくけこ";
            this.MakerShortName.Top = 0.1875F;
            this.MakerShortName.Width = 1.1875F;
            // 
            // GoodsRateGrpCode
            // 
            this.GoodsRateGrpCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.DataField = "GoodsRateGrpCode";
            this.GoodsRateGrpCode.Height = 0.15F;
            this.GoodsRateGrpCode.Left = 3.1875F;
            this.GoodsRateGrpCode.MultiLine = false;
            this.GoodsRateGrpCode.Name = "GoodsRateGrpCode";
            this.GoodsRateGrpCode.OutputFormat = resources.GetString("GoodsRateGrpCode.OutputFormat");
            this.GoodsRateGrpCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsRateGrpCode.Text = "1234";
            this.GoodsRateGrpCode.Top = 0.1875F;
            this.GoodsRateGrpCode.Width = 0.3125F;
            // 
            // GoodsRateRank
            // 
            this.GoodsRateRank.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.DataField = "GoodsRateRank";
            this.GoodsRateRank.Height = 0.15F;
            this.GoodsRateRank.Left = 3.1875F;
            this.GoodsRateRank.MultiLine = false;
            this.GoodsRateRank.Name = "GoodsRateRank";
            this.GoodsRateRank.OutputFormat = resources.GetString("GoodsRateRank.OutputFormat");
            this.GoodsRateRank.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsRateRank.Text = "XX";
            this.GoodsRateRank.Top = 0F;
            this.GoodsRateRank.Width = 0.2500001F;
            // 
            // BLGroupCode
            // 
            this.BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.DataField = "BLGroupCode";
            this.BLGroupCode.Height = 0.15F;
            this.BLGroupCode.Left = 3.5F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0F;
            this.BLGroupCode.Width = 0.4374999F;
            // 
            // BLGroupKanaName
            // 
            this.BLGroupKanaName.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupKanaName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupKanaName.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupKanaName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupKanaName.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupKanaName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupKanaName.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupKanaName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupKanaName.DataField = "BLGroupKanaName";
            this.BLGroupKanaName.Height = 0.15F;
            this.BLGroupKanaName.Left = 3.5F;
            this.BLGroupKanaName.MultiLine = false;
            this.BLGroupKanaName.Name = "BLGroupKanaName";
            this.BLGroupKanaName.OutputFormat = resources.GetString("BLGroupKanaName.OutputFormat");
            this.BLGroupKanaName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BLGroupKanaName.Text = "XXXXXXXXXX";
            this.BLGroupKanaName.Top = 0.1875F;
            this.BLGroupKanaName.Width = 0.6F;
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
            this.BLGoodsCode.Height = 0.15F;
            this.BLGoodsCode.Left = 4.1875F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0F;
            this.BLGoodsCode.Width = 0.4374999F;
            // 
            // BLGoodsHalfName
            // 
            this.BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.DataField = "BLGoodsHalfName";
            this.BLGoodsHalfName.Height = 0.15F;
            this.BLGoodsHalfName.Left = 4.1875F;
            this.BLGoodsHalfName.MultiLine = false;
            this.BLGoodsHalfName.Name = "BLGoodsHalfName";
            this.BLGoodsHalfName.OutputFormat = resources.GetString("BLGoodsHalfName.OutputFormat");
            this.BLGoodsHalfName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BLGoodsHalfName.Text = "XXXXXXXXXX";
            this.BLGoodsHalfName.Top = 0.1875F;
            this.BLGoodsHalfName.Width = 0.6249999F;
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
            this.GoodsNo.Height = 0.15F;
            this.GoodsNo.Left = 4.8125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "XXXXXXXXXXXXXXXXXXXX1234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.375F;
            // 
            // GoodsNameKana
            // 
            this.GoodsNameKana.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.DataField = "GoodsNameKana";
            this.GoodsNameKana.Height = 0.15F;
            this.GoodsNameKana.Left = 4.8125F;
            this.GoodsNameKana.MultiLine = false;
            this.GoodsNameKana.Name = "GoodsNameKana";
            this.GoodsNameKana.OutputFormat = resources.GetString("GoodsNameKana.OutputFormat");
            this.GoodsNameKana.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNameKana.Text = "XXXXXXXXXXXXXXXXXXXX1234567890";
            this.GoodsNameKana.Top = 0.1875F;
            this.GoodsNameKana.Width = 1.75F;
            // 
            // LotCount
            // 
            this.LotCount.Border.BottomColor = System.Drawing.Color.Black;
            this.LotCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LotCount.Border.LeftColor = System.Drawing.Color.Black;
            this.LotCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LotCount.Border.RightColor = System.Drawing.Color.Black;
            this.LotCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LotCount.Border.TopColor = System.Drawing.Color.Black;
            this.LotCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LotCount.DataField = "LotCount";
            this.LotCount.Height = 0.15F;
            this.LotCount.Left = 6.5F;
            this.LotCount.MultiLine = false;
            this.LotCount.Name = "LotCount";
            this.LotCount.OutputFormat = resources.GetString("LotCount.OutputFormat");
            this.LotCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.LotCount.Text = "9,999,999.99";
            this.LotCount.Top = 0.1875F;
            this.LotCount.Width = 0.7499998F;
            // 
            // SalRateVal
            // 
            this.SalRateVal.Border.BottomColor = System.Drawing.Color.Black;
            this.SalRateVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalRateVal.Border.LeftColor = System.Drawing.Color.Black;
            this.SalRateVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalRateVal.Border.RightColor = System.Drawing.Color.Black;
            this.SalRateVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalRateVal.Border.TopColor = System.Drawing.Color.Black;
            this.SalRateVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalRateVal.DataField = "SalRateVal";
            this.SalRateVal.Height = 0.15F;
            this.SalRateVal.Left = 7.25F;
            this.SalRateVal.MultiLine = false;
            this.SalRateVal.Name = "SalRateVal";
            this.SalRateVal.OutputFormat = resources.GetString("SalRateVal.OutputFormat");
            this.SalRateVal.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalRateVal.Text = "999.99";
            this.SalRateVal.Top = 0.1875F;
            this.SalRateVal.Width = 0.3750001F;
            // 
            // SalPriceFl
            // 
            this.SalPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.SalPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.SalPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalPriceFl.DataField = "SalPriceFl";
            this.SalPriceFl.Height = 0.15F;
            this.SalPriceFl.Left = 7.6875F;
            this.SalPriceFl.MultiLine = false;
            this.SalPriceFl.Name = "SalPriceFl";
            this.SalPriceFl.OutputFormat = resources.GetString("SalPriceFl.OutputFormat");
            this.SalPriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalPriceFl.Text = "999,999,999.99";
            this.SalPriceFl.Top = 0.1875F;
            this.SalPriceFl.Width = 0.8124999F;
            // 
            // SalUpRate
            // 
            this.SalUpRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalUpRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalUpRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalUpRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalUpRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalUpRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalUpRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalUpRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalUpRate.DataField = "SalUpRate";
            this.SalUpRate.Height = 0.15F;
            this.SalUpRate.Left = 8.5625F;
            this.SalUpRate.MultiLine = false;
            this.SalUpRate.Name = "SalUpRate";
            this.SalUpRate.OutputFormat = resources.GetString("SalUpRate.OutputFormat");
            this.SalUpRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalUpRate.Text = "999.99";
            this.SalUpRate.Top = 0.1875F;
            this.SalUpRate.Width = 0.3750001F;
            // 
            // UnPrcFracProcUnit
            // 
            this.UnPrcFracProcUnit.Border.BottomColor = System.Drawing.Color.Black;
            this.UnPrcFracProcUnit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcUnit.Border.LeftColor = System.Drawing.Color.Black;
            this.UnPrcFracProcUnit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcUnit.Border.RightColor = System.Drawing.Color.Black;
            this.UnPrcFracProcUnit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcUnit.Border.TopColor = System.Drawing.Color.Black;
            this.UnPrcFracProcUnit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcUnit.DataField = "UnPrcFracProcUnit";
            this.UnPrcFracProcUnit.Height = 0.15F;
            this.UnPrcFracProcUnit.Left = 9.4375F;
            this.UnPrcFracProcUnit.MultiLine = false;
            this.UnPrcFracProcUnit.Name = "UnPrcFracProcUnit";
            this.UnPrcFracProcUnit.OutputFormat = resources.GetString("UnPrcFracProcUnit.OutputFormat");
            this.UnPrcFracProcUnit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.UnPrcFracProcUnit.Text = "9,999,999.99";
            this.UnPrcFracProcUnit.Top = 0.1875F;
            this.UnPrcFracProcUnit.Width = 0.7499998F;
            // 
            // UnPrcFracProcDiv
            // 
            this.UnPrcFracProcDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.UnPrcFracProcDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.UnPrcFracProcDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcDiv.Border.RightColor = System.Drawing.Color.Black;
            this.UnPrcFracProcDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcDiv.Border.TopColor = System.Drawing.Color.Black;
            this.UnPrcFracProcDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UnPrcFracProcDiv.DataField = "UnPrcFracProcDiv";
            this.UnPrcFracProcDiv.Height = 0.15F;
            this.UnPrcFracProcDiv.Left = 10.25F;
            this.UnPrcFracProcDiv.MultiLine = false;
            this.UnPrcFracProcDiv.Name = "UnPrcFracProcDiv";
            this.UnPrcFracProcDiv.OutputFormat = resources.GetString("UnPrcFracProcDiv.OutputFormat");
            this.UnPrcFracProcDiv.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UnPrcFracProcDiv.Text = "あいうえ";
            this.UnPrcFracProcDiv.Top = 0.1875F;
            this.UnPrcFracProcDiv.Width = 0.4999999F;
            // 
            // CustRateGrpCode
            // 
            this.CustRateGrpCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.DataField = "CustRateGrpCode";
            this.CustRateGrpCode.Height = 0.15F;
            this.CustRateGrpCode.Left = 0.8125F;
            this.CustRateGrpCode.MultiLine = false;
            this.CustRateGrpCode.Name = "CustRateGrpCode";
            this.CustRateGrpCode.OutputFormat = resources.GetString("CustRateGrpCode.OutputFormat");
            this.CustRateGrpCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustRateGrpCode.Text = "あいうえおかきくけこ";
            this.CustRateGrpCode.Top = 0F;
            this.CustRateGrpCode.Width = 1.1875F;
            // 
            // CstRateVal
            // 
            this.CstRateVal.Border.BottomColor = System.Drawing.Color.Black;
            this.CstRateVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstRateVal.Border.LeftColor = System.Drawing.Color.Black;
            this.CstRateVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstRateVal.Border.RightColor = System.Drawing.Color.Black;
            this.CstRateVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstRateVal.Border.TopColor = System.Drawing.Color.Black;
            this.CstRateVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstRateVal.DataField = "CstRateVal";
            this.CstRateVal.Height = 0.15F;
            this.CstRateVal.Left = 7.25F;
            this.CstRateVal.MultiLine = false;
            this.CstRateVal.Name = "CstRateVal";
            this.CstRateVal.OutputFormat = resources.GetString("CstRateVal.OutputFormat");
            this.CstRateVal.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CstRateVal.Text = "999.99";
            this.CstRateVal.Top = 0.375F;
            this.CstRateVal.Visible = false;
            this.CstRateVal.Width = 0.3750001F;
            // 
            // CstPriceFl
            // 
            this.CstPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.CstPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.CstPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.CstPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.CstPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CstPriceFl.DataField = "CstPriceFl";
            this.CstPriceFl.Height = 0.15F;
            this.CstPriceFl.Left = 7.6875F;
            this.CstPriceFl.MultiLine = false;
            this.CstPriceFl.Name = "CstPriceFl";
            this.CstPriceFl.OutputFormat = resources.GetString("CstPriceFl.OutputFormat");
            this.CstPriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CstPriceFl.Text = "999,999,999.99";
            this.CstPriceFl.Top = 0.375F;
            this.CstPriceFl.Visible = false;
            this.CstPriceFl.Width = 0.8124999F;
            // 
            // PrcPriceFl
            // 
            this.PrcPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.PrcPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.PrcPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.PrcPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.PrcPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcPriceFl.DataField = "PrcPriceFl";
            this.PrcPriceFl.Height = 0.15F;
            this.PrcPriceFl.Left = 7.6875F;
            this.PrcPriceFl.MultiLine = false;
            this.PrcPriceFl.Name = "PrcPriceFl";
            this.PrcPriceFl.OutputFormat = resources.GetString("PrcPriceFl.OutputFormat");
            this.PrcPriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PrcPriceFl.Text = "999,999,999";
            this.PrcPriceFl.Top = 0.625F;
            this.PrcPriceFl.Visible = false;
            this.PrcPriceFl.Width = 0.8124999F;
            // 
            // PrcUpRate
            // 
            this.PrcUpRate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrcUpRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcUpRate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrcUpRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcUpRate.Border.RightColor = System.Drawing.Color.Black;
            this.PrcUpRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcUpRate.Border.TopColor = System.Drawing.Color.Black;
            this.PrcUpRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrcUpRate.DataField = "PrcUpRate";
            this.PrcUpRate.Height = 0.15F;
            this.PrcUpRate.Left = 8.5625F;
            this.PrcUpRate.MultiLine = false;
            this.PrcUpRate.Name = "PrcUpRate";
            this.PrcUpRate.OutputFormat = resources.GetString("PrcUpRate.OutputFormat");
            this.PrcUpRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PrcUpRate.Text = "999.99";
            this.PrcUpRate.Top = 0.625F;
            this.PrcUpRate.Visible = false;
            this.PrcUpRate.Width = 0.3750001F;
            // 
            // RateVal_L
            // 
            this.RateVal_L.Border.BottomColor = System.Drawing.Color.Black;
            this.RateVal_L.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateVal_L.Border.LeftColor = System.Drawing.Color.Black;
            this.RateVal_L.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateVal_L.Border.RightColor = System.Drawing.Color.Black;
            this.RateVal_L.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateVal_L.Border.TopColor = System.Drawing.Color.Black;
            this.RateVal_L.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RateVal_L.Height = 0.15F;
            this.RateVal_L.Left = 7.5625F;
            this.RateVal_L.MultiLine = false;
            this.RateVal_L.Name = "RateVal_L";
            this.RateVal_L.OutputFormat = resources.GetString("RateVal_L.OutputFormat");
            this.RateVal_L.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.RateVal_L.Text = "%";
            this.RateVal_L.Top = 0.1875F;
            this.RateVal_L.Width = 0.125F;
            // 
            // UpRate_L
            // 
            this.UpRate_L.Border.BottomColor = System.Drawing.Color.Black;
            this.UpRate_L.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UpRate_L.Border.LeftColor = System.Drawing.Color.Black;
            this.UpRate_L.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UpRate_L.Border.RightColor = System.Drawing.Color.Black;
            this.UpRate_L.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UpRate_L.Border.TopColor = System.Drawing.Color.Black;
            this.UpRate_L.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UpRate_L.Height = 0.15F;
            this.UpRate_L.Left = 8.875F;
            this.UpRate_L.MultiLine = false;
            this.UpRate_L.Name = "UpRate_L";
            this.UpRate_L.OutputFormat = resources.GetString("UpRate_L.OutputFormat");
            this.UpRate_L.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.UpRate_L.Text = "%";
            this.UpRate_L.Top = 0.1875F;
            this.UpRate_L.Width = 0.125F;
            // 
            // GrsProfitSecureRate_L
            // 
            this.GrsProfitSecureRate_L.Border.BottomColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate_L.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate_L.Border.LeftColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate_L.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate_L.Border.RightColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate_L.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate_L.Border.TopColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate_L.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate_L.Height = 0.15F;
            this.GrsProfitSecureRate_L.Left = 9.3125F;
            this.GrsProfitSecureRate_L.MultiLine = false;
            this.GrsProfitSecureRate_L.Name = "GrsProfitSecureRate_L";
            this.GrsProfitSecureRate_L.OutputFormat = resources.GetString("GrsProfitSecureRate_L.OutputFormat");
            this.GrsProfitSecureRate_L.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrsProfitSecureRate_L.Text = "%";
            this.GrsProfitSecureRate_L.Top = 0.1875F;
            this.GrsProfitSecureRate_L.Width = 0.125F;
            // 
            // GrsProfitSecureRate
            // 
            this.GrsProfitSecureRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrsProfitSecureRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrsProfitSecureRate.DataField = "GrsProfitSecureRate";
            this.GrsProfitSecureRate.Height = 0.15F;
            this.GrsProfitSecureRate.Left = 9F;
            this.GrsProfitSecureRate.MultiLine = false;
            this.GrsProfitSecureRate.Name = "GrsProfitSecureRate";
            this.GrsProfitSecureRate.OutputFormat = resources.GetString("GrsProfitSecureRate.OutputFormat");
            this.GrsProfitSecureRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrsProfitSecureRate.Text = "999.99";
            this.GrsProfitSecureRate.Top = 0.1875F;
            this.GrsProfitSecureRate.Width = 0.3750001F;
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
            this.line3.Top = 0.375F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.375F;
            this.line3.Y2 = 0.375F;
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
            this.SupplierCd.DataField = "SupplierCd";
            this.SupplierCd.Height = 0.15F;
            this.SupplierCd.Left = 0.3125F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0.1875F;
            this.SupplierCd.Width = 0.4374999F;
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
            this.CustomerCode.Height = 0.15F;
            this.CustomerCode.Left = 0.3125F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CustomerCode.Text = "12345678";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Width = 0.5F;
            // 
            // Price
            // 
            this.Price.Border.BottomColor = System.Drawing.Color.Black;
            this.Price.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Price.Border.LeftColor = System.Drawing.Color.Black;
            this.Price.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Price.Border.RightColor = System.Drawing.Color.Black;
            this.Price.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Price.Border.TopColor = System.Drawing.Color.Black;
            this.Price.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Price.DataField = "Price";
            this.Price.Height = 0.15F;
            this.Price.Left = 7.25F;
            this.Price.MultiLine = false;
            this.Price.Name = "Price";
            this.Price.OutputFormat = "#,##0";
            this.Price.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Price.Text = "9,999,999";
            this.Price.Top = 0.625F;
            this.Price.Visible = false;
            this.Price.Width = 0.575F;
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
            this.tb_ReportTitle.Text = "掛率マスタ印刷";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.03205128F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.PageFooter.AfterPrint += new System.EventHandler(this.PageFooter_AfterPrint);
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
            this.Line5,
            this.label1,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.line2,
            this.Lb_SalRateVal,
            this.label17,
            this.Lb_SalPriceFl,
            this.Lb_SalUpRate,
            this.Lb_GrsProfitSecureRate,
            this.Lb_UnPrcFracProcUnit,
            this.label22,
            this.Lb_CstRateVal,
            this.Lb_CstPriceFl,
            this.Lb_PrcPriceFl,
            this.Lb_PrcUpRate,
            this.lblCustomerCode,
            this.lblSupplierCd,
            this.Lb_Price});
            this.TitleHeader.Height = 0.8375F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.label1.Height = 0.15F;
            this.label1.HyperLink = "";
            this.label1.Left = 0F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "区分";
            this.label1.Top = 0.2395834F;
            this.label1.Width = 0.3125F;
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
            this.label4.Height = 0.15F;
            this.label4.HyperLink = "";
            this.label4.Left = 0.8125F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "得意先名/掛率ｸﾞﾙｰﾌﾟ";
            this.label4.Top = 0.0625F;
            this.label4.Width = 1.1875F;
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
            this.label5.Height = 0.15F;
            this.label5.HyperLink = "";
            this.label5.Left = 0.8125F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "仕入先名";
            this.label5.Top = 0.25F;
            this.label5.Width = 1.1875F;
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
            this.label6.Height = 0.15F;
            this.label6.HyperLink = "";
            this.label6.Left = 2F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "ﾒｰｶｰ";
            this.label6.Top = 0.0625F;
            this.label6.Width = 1.1875F;
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
            this.label7.Height = 0.15F;
            this.label7.HyperLink = "";
            this.label7.Left = 2F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "ﾒｰｶｰ名";
            this.label7.Top = 0.25F;
            this.label7.Width = 1.1875F;
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
            this.label8.Height = 0.15F;
            this.label8.HyperLink = "";
            this.label8.Left = 3.1875F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "層別";
            this.label8.Top = 0.0625F;
            this.label8.Width = 0.3125F;
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
            this.label9.Height = 0.15F;
            this.label9.HyperLink = "";
            this.label9.Left = 3.1875F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "商G";
            this.label9.Top = 0.25F;
            this.label9.Width = 0.3125F;
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
            this.label10.Height = 0.15F;
            this.label10.HyperLink = "";
            this.label10.Left = 3.5F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "ｸﾞﾙｰﾌﾟCD";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.7500001F;
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
            this.label11.Height = 0.15F;
            this.label11.HyperLink = "";
            this.label11.Left = 3.5F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "ｸﾞﾙｰﾌﾟCD名";
            this.label11.Top = 0.25F;
            this.label11.Width = 0.7500001F;
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
            this.label12.Height = 0.15F;
            this.label12.HyperLink = "";
            this.label12.Left = 4.1875F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "BL CD";
            this.label12.Top = 0.0625F;
            this.label12.Width = 0.6249999F;
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
            this.label13.Height = 0.15F;
            this.label13.HyperLink = "";
            this.label13.Left = 4.1875F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "BL CD名";
            this.label13.Top = 0.25F;
            this.label13.Width = 0.6249999F;
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
            this.label14.Height = 0.15F;
            this.label14.HyperLink = "";
            this.label14.Left = 4.8125F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "品名";
            this.label14.Top = 0.25F;
            this.label14.Width = 1.75F;
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
            this.label15.Height = 0.15F;
            this.label15.HyperLink = "";
            this.label15.Left = 4.8125F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "品番";
            this.label15.Top = 0.0625F;
            this.label15.Width = 1.75F;
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
            this.line2.Top = 0.4375F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.4375F;
            this.line2.Y2 = 0.4375F;
            // 
            // Lb_SalRateVal
            // 
            this.Lb_SalRateVal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalRateVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalRateVal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalRateVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalRateVal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalRateVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalRateVal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalRateVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalRateVal.Height = 0.15F;
            this.Lb_SalRateVal.HyperLink = "";
            this.Lb_SalRateVal.Left = 7.25F;
            this.Lb_SalRateVal.MultiLine = false;
            this.Lb_SalRateVal.Name = "Lb_SalRateVal";
            this.Lb_SalRateVal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalRateVal.Text = "売価率";
            this.Lb_SalRateVal.Top = 0.25F;
            this.Lb_SalRateVal.Width = 0.4375002F;
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
            this.label17.Height = 0.15F;
            this.label17.HyperLink = "";
            this.label17.Left = 6.5F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "上限";
            this.label17.Top = 0.25F;
            this.label17.Width = 0.7499998F;
            // 
            // Lb_SalPriceFl
            // 
            this.Lb_SalPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalPriceFl.Height = 0.15F;
            this.Lb_SalPriceFl.HyperLink = "";
            this.Lb_SalPriceFl.Left = 7.6875F;
            this.Lb_SalPriceFl.MultiLine = false;
            this.Lb_SalPriceFl.Name = "Lb_SalPriceFl";
            this.Lb_SalPriceFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalPriceFl.Text = "売価額";
            this.Lb_SalPriceFl.Top = 0.25F;
            this.Lb_SalPriceFl.Width = 0.8124999F;
            // 
            // Lb_SalUpRate
            // 
            this.Lb_SalUpRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalUpRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalUpRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalUpRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalUpRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalUpRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalUpRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalUpRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalUpRate.Height = 0.15F;
            this.Lb_SalUpRate.HyperLink = "";
            this.Lb_SalUpRate.Left = 8.5625F;
            this.Lb_SalUpRate.MultiLine = false;
            this.Lb_SalUpRate.Name = "Lb_SalUpRate";
            this.Lb_SalUpRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalUpRate.Text = "原価UP率";
            this.Lb_SalUpRate.Top = 0.25F;
            this.Lb_SalUpRate.Width = 0.5000002F;
            // 
            // Lb_GrsProfitSecureRate
            // 
            this.Lb_GrsProfitSecureRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GrsProfitSecureRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrsProfitSecureRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GrsProfitSecureRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrsProfitSecureRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GrsProfitSecureRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrsProfitSecureRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GrsProfitSecureRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrsProfitSecureRate.Height = 0.3F;
            this.Lb_GrsProfitSecureRate.HyperLink = "";
            this.Lb_GrsProfitSecureRate.Left = 9.0625F;
            this.Lb_GrsProfitSecureRate.Name = "Lb_GrsProfitSecureRate";
            this.Lb_GrsProfitSecureRate.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrsProfitSecureRate.Text = "粗利　確保率";
            this.Lb_GrsProfitSecureRate.Top = 0.1875F;
            this.Lb_GrsProfitSecureRate.Width = 0.4F;
            // 
            // Lb_UnPrcFracProcUnit
            // 
            this.Lb_UnPrcFracProcUnit.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UnPrcFracProcUnit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UnPrcFracProcUnit.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UnPrcFracProcUnit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UnPrcFracProcUnit.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UnPrcFracProcUnit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UnPrcFracProcUnit.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UnPrcFracProcUnit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UnPrcFracProcUnit.Height = 0.3F;
            this.Lb_UnPrcFracProcUnit.HyperLink = "";
            this.Lb_UnPrcFracProcUnit.Left = 9.5625F;
            this.Lb_UnPrcFracProcUnit.Name = "Lb_UnPrcFracProcUnit";
            this.Lb_UnPrcFracProcUnit.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UnPrcFracProcUnit.Text = "端数処理単位";
            this.Lb_UnPrcFracProcUnit.Top = 0.1875F;
            this.Lb_UnPrcFracProcUnit.Width = 0.5F;
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
            this.label22.Height = 0.3F;
            this.label22.HyperLink = "";
            this.label22.Left = 10.25F;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label22.Text = "端数処理区分";
            this.label22.Top = 0.1875F;
            this.label22.Width = 0.5F;
            // 
            // Lb_CstRateVal
            // 
            this.Lb_CstRateVal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CstRateVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstRateVal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CstRateVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstRateVal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CstRateVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstRateVal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CstRateVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstRateVal.Height = 0.15F;
            this.Lb_CstRateVal.HyperLink = "";
            this.Lb_CstRateVal.Left = 7.25F;
            this.Lb_CstRateVal.MultiLine = false;
            this.Lb_CstRateVal.Name = "Lb_CstRateVal";
            this.Lb_CstRateVal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CstRateVal.Text = "仕入率";
            this.Lb_CstRateVal.Top = 0.4375F;
            this.Lb_CstRateVal.Visible = false;
            this.Lb_CstRateVal.Width = 0.4375002F;
            // 
            // Lb_CstPriceFl
            // 
            this.Lb_CstPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CstPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CstPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CstPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CstPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CstPriceFl.Height = 0.15F;
            this.Lb_CstPriceFl.HyperLink = "";
            this.Lb_CstPriceFl.Left = 7.6875F;
            this.Lb_CstPriceFl.MultiLine = false;
            this.Lb_CstPriceFl.Name = "Lb_CstPriceFl";
            this.Lb_CstPriceFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CstPriceFl.Text = "仕入原価";
            this.Lb_CstPriceFl.Top = 0.4375F;
            this.Lb_CstPriceFl.Visible = false;
            this.Lb_CstPriceFl.Width = 0.8124999F;
            // 
            // Lb_PrcPriceFl
            // 
            this.Lb_PrcPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PrcPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PrcPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PrcPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PrcPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcPriceFl.Height = 0.15F;
            this.Lb_PrcPriceFl.HyperLink = "";
            this.Lb_PrcPriceFl.Left = 7.6875F;
            this.Lb_PrcPriceFl.MultiLine = false;
            this.Lb_PrcPriceFl.Name = "Lb_PrcPriceFl";
            this.Lb_PrcPriceFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PrcPriceFl.Text = "ﾕｰｻﾞｰ価格";
            this.Lb_PrcPriceFl.Top = 0.6875F;
            this.Lb_PrcPriceFl.Visible = false;
            this.Lb_PrcPriceFl.Width = 0.8124999F;
            // 
            // Lb_PrcUpRate
            // 
            this.Lb_PrcUpRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PrcUpRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcUpRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PrcUpRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcUpRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PrcUpRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcUpRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PrcUpRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PrcUpRate.Height = 0.15F;
            this.Lb_PrcUpRate.HyperLink = "";
            this.Lb_PrcUpRate.Left = 8.5F;
            this.Lb_PrcUpRate.MultiLine = false;
            this.Lb_PrcUpRate.Name = "Lb_PrcUpRate";
            this.Lb_PrcUpRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PrcUpRate.Text = "価格UP率";
            this.Lb_PrcUpRate.Top = 0.6875F;
            this.Lb_PrcUpRate.Visible = false;
            this.Lb_PrcUpRate.Width = 0.5000002F;
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerCode.Height = 0.15F;
            this.lblCustomerCode.HyperLink = "";
            this.lblCustomerCode.Left = 0.3125F;
            this.lblCustomerCode.MultiLine = false;
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblCustomerCode.Text = "得意先";
            this.lblCustomerCode.Top = 0.0625F;
            this.lblCustomerCode.Width = 0.5F;
            // 
            // lblSupplierCd
            // 
            this.lblSupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.lblSupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.lblSupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.lblSupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.lblSupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblSupplierCd.Height = 0.15F;
            this.lblSupplierCd.HyperLink = "";
            this.lblSupplierCd.Left = 0.3125F;
            this.lblSupplierCd.MultiLine = false;
            this.lblSupplierCd.Name = "lblSupplierCd";
            this.lblSupplierCd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblSupplierCd.Text = "仕入先";
            this.lblSupplierCd.Top = 0.25F;
            this.lblSupplierCd.Width = 0.5F;
            // 
            // Lb_Price
            // 
            this.Lb_Price.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Price.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Price.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Price.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Price.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Price.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Price.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Price.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Price.Height = 0.15F;
            this.Lb_Price.HyperLink = "";
            this.Lb_Price.Left = 7.25F;
            this.Lb_Price.MultiLine = false;
            this.Lb_Price.Name = "Lb_Price";
            this.Lb_Price.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Price.Text = "価格";
            this.Lb_Price.Top = 0.688F;
            this.Lb_Price.Visible = false;
            this.Lb_Price.Width = 0.575F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_SectionGuideSnm});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.AfterPrint += new System.EventHandler(this.SectionHeader_AfterPrint);
            // 
            // tb_SectionGuideSnm
            // 
            this.tb_SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.CanShrink = true;
            this.tb_SectionGuideSnm.DataField = "SectionGuideSnm";
            this.tb_SectionGuideSnm.Height = 0.15F;
            this.tb_SectionGuideSnm.Left = 0F;
            this.tb_SectionGuideSnm.MultiLine = false;
            this.tb_SectionGuideSnm.Name = "tb_SectionGuideSnm";
            this.tb_SectionGuideSnm.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SectionGuideSnm.Text = null;
            this.tb_SectionGuideSnm.Top = 0F;
            this.tb_SectionGuideSnm.Visible = false;
            this.tb_SectionGuideSnm.Width = 0.75F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // PMKHN02014P_01A4C
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
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionFooter);
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
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogicalDeleteCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupKanaName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LotCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalRateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalUpRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnPrcFracProcUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnPrcFracProcDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CstRateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CstPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrcPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrcUpRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateVal_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpRate_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitSecureRate_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitSecureRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalRateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalUpRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrsProfitSecureRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UnPrcFracProcUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CstRateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CstPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PrcPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PrcUpRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        
	}
}
