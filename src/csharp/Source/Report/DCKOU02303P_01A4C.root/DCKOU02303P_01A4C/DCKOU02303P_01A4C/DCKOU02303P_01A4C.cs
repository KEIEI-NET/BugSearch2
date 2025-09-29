//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入荷一覧表
// プログラム概要   : 入荷一覧表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢　貞義
// 作 成 日  2007/10/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13158
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応9803、11150、11153、12398
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応11153
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/08  修正内容 : MANTIS【13233】改頁時の拠点出力不具合を修正
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 入荷一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 入荷一覧表のフォームクラスです。</br>
    /// <br>Programmer  : 980035 金沢　貞義</br>
    /// <br>Date	    : 2007.10.19</br>
    /// <br>Update Note : 2009/04/07 30452 上野 俊治</br>
    /// <br>             ・障害対応13158</br>
    /// <br>Update Note : 2009/04/08 30452 上野 俊治</br>
    /// <br>             ・障害対応9803、11150、11153、12398</br>
    /// <br>Update Note : 2009/04/28 30452 上野 俊治</br>
    /// <br>             ・障害対応11153</br>
    /// </remarks>
	public class DCKOU02303P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		/// <summary>
        /// 入荷一覧表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 入荷一覧表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.10.19</br>
        /// <br>Update      : 2008/09/26 照田 貴志 バグ修正、仕様変更対応</br>
        /// </remarks>
		public DCKOU02303P_01A4C()
		{
			InitializeComponent();       
		}

		//================================================================================
		//  内部変数
		//================================================================================
		#region Private Member
		private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件印字項目
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			 _otherDataList;				// その他データ

		private ExtrInfo_DCKOU02304E _extrInfo;					    // 抽出条件クラス

		// その他データ格納項目		
		private int					 _printCount;					// ページ数カウント用

		private int slipRowNoStk_Sc = 0;								// 仕入伝票明細行数　拠点計用
		private int slipRowNoRtn_Sc = 0;								// 返品伝票明細行数　拠点計用

		private int slipRowNoStk_Ttl = 0;								// 仕入伝票明細行数　総合計用
		private int slipRowNoRtn_Ttl = 0;								// 返品伝票明細行数　総合計用

		// ヘッダーサブレポート作成
		//ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
        ListCommon_PageFooter _rptPageFooter = null;    // ADD 2009/01/19 不具合対応[9668]
        private Label label12;
		private Label label5;
		private Label label7;
        private Label label16;
		private Label label22;
        private Label label24;
		private Label label14;
		private Label label17;
        private Label label18;
        private Label label20;
		private Line line7;
        private TextBox textBox28;
        private TextBox textBox27;
		private Line line8;
		private TextBox textBox23;
		private TextBox CustomerName;
		private TextBox textBox34;
		private TextBox TransactionNameRF;
        private TextBox textBox33;
        private TextBox textBox24;
		private TextBox textBox9;
		private TextBox textBox16;
        private TextBox textBox17;
		private TextBox textBox19;
        private TextBox textBox20;
        private Label label26;
        private TextBox textBox8;
		private TextBox txtSort1_Title;
        private TextBox textBox46;
		private TextBox txtSort2_Title;
        private TextBox textBox52;
		private TextBox textBox35;
        private TextBox textBox58;
		private ReportHeader reportHeader1;
        private ReportFooter reportFooter1;
		private GroupHeader SectionHeader;
		private GroupFooter SectionFooter;
		private Line Line45;
		private TextBox textBox39;
        private TextBox textBox64;
		private Label label43;
		private Label label44;
		private Label label45;
		private TextBox txtCntArrivalSl_Sc;
		private TextBox txtCntReturnSl_Sc;
		private Label label46;
		private Label label47;
		private TextBox txtCntTotal_Sc;
		private Label label56;
		private Line Line41;
		private Line line13;
		private Line line11;
        private Line line10;
		private Line line17;
        private TextBox textBox3;
        private Label label38;
        private Label label58;
        private Label label59;
        private TextBox txtCntArrivalSl_Ttl;
        private TextBox txtCntReturnSl_Ttl;
        private Label label60;
        private Label label61;
        private TextBox textBox25;
        private TextBox txtCntTotal_Ttl;
        private Label label62;
        private Line line2;
        private SubReport Footer_SubReport;
        private Line line3;
        private Line line6;
        private Label label1;
        private Line line4;
        private Label label6;
        private TextBox textBox10;
        private Label label13;
        private TextBox textBox14;
        private Label label15;
        private TextBox StockAddUpADate;
        private TextBox textBox18;
        private Label label19;
        private Label label10;
        private TextBox textBox29;
        private Label label23;
        private TextBox textBox30;
        private TextBox textBox31;
        private Label label27;
        private TextBox textBox32;
        private TextBox textBox37;
        private TextBox StockPriceConsTax;
        private Label label28;
        private Label label29;
        private Label label30;
        private TextBox textBox2;
        private TextBox TitFt_StockPriceConsTax;
        private TextBox textBox6;
        private TextBox textBox13;
        private TextBox textBox22;
        private TextBox textBox40;
        private TextBox textBox44;
        private TextBox Detail_SuppCTaxLayCd;
        private TextBox Detail_TaxationCode;
        private TextBox TitFt_SuppCTaxLayCd;
        private TextBox TitFt_TaxationCode;
        private SubReport subReport1;

		// Disposeチェック用フラグ
		//bool disposed = false;  // DEL 2008/06/30

		#endregion PrivateMembers

		#region 2008.01.30 A.Mabuchi Delete START--------------------------------
		/*
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
		*/
		#endregion	2008.01.30 A.Mabuchi Delete END--------------------------------

		//================================================================================
		//  プロパティ
		//================================================================================
		#region Public Property
		#region IPrintActiveReportTypeList メンバ
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
				this._extrInfo = (ExtrInfo_DCKOU02304E)this._printInfo.jyoken;
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
		///	印刷件数カウントアップイベント
		/// </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;        
		#endregion
		#region IPrintActiveReportTypeCommon メンバ

		/// <summary>背景透かしモード</summary>
		/// <value>0：背景透かし無し, 1:背景透かし有り</value>
		public int WatermarkMode
		{
			get{return 0;}
			set{}
		}

		#endregion
		#endregion

		// ===============================================================================
		// 内部使用関数
		// ===============================================================================
		#region Private Method
		/// <summary>
		/// レポート要素出力設定
		/// </summary>
 		/// <remarks>
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{

            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////拠点オプションチェック
	        //if (this._extrInfo.IsOptSection)
			//{              
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if (this._extrInfo.DepositStockSecCodeList.Length <= 1)					
			//	{                
			//		SectionHeader.DataField = "";
            //        SectionHeader.Height = 0F;
            //        SectionFooter.Height = 0F;
			//		SectionHeader.Visible = false;
			//		SectionFooter.Visible = false;
			//	}
			//	else
			//	{					
            //        SectionHeader.DataField = DCHNB04154EA.ctCol_SectionCode;
            //        SectionHeader.Visible = true;
			//		SectionFooter.Visible = true;
			//	}
            //
			//}
			//else
			//{
			//	// 拠点無
			//	SectionHeader.DataField = "";
			//	SectionHeader.Visible = false;
			//	SectionFooter.Visible = false;          
			//}
			#region  2008.02.01 A.Mabuchi Delete START /////////////////////////////////////////////
			// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
			//if (this._extrInfo.DepositStockSecCodeList.Length <= 1)
			//{
			//    SectionHeader.DataField = "";
			//    SectionHeader.Height = 0F;
			//    SectionFooter.Height = 0F;
			//    SectionHeader.Visible = false;
			//    SectionFooter.Visible = false;
			//}
			//else
			//{
			//    SectionHeader.DataField = DCHNB04154EA.ct_Col_SectionCode;
			//    SectionHeader.Visible = true;
			//    SectionFooter.Visible = true;
			//}
			// 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
			#endregion  2008.02.01 A.Mabuchi END///////////////////////////////////////////////

			#region  2008.01.28 A.Mabuchi Delete START /////////////////////////////////////////////
			/*	2008.01.28 A.Mabuchi Delete START
			//全社選択されている場合は拠点名称をを表示
			if (this._extrInfo.DepositStockSecCodeList.Length == 0)
            {
				this.SectionName_Title.Visible = true;
				this.SectionName_TextBox.Visible = true;
            }
            else
            {
				this.SectionName_Title.Visible = false;
				this.SectionName_TextBox.Visible = false;
            }

            //ソート順が商品大分類・中分類別の時
            //if (this._extrInfo.ChangePageDiv == (int)StockListCndtn.PageChangeDiv.Sort_LargeMediumGoodsGanreCode)
            if (this._extrInfo.SortOrder == 1)
            {
                //ソート順１のヘッダ・フッタを表示
                this.SortDiv1Header.Visible = true;
                this.SortDiv1Header.DataField = DCHNB04154EA.ct_Col_ArrivalGoodsDay;
                this.SortDiv1Footer.Visible = true;
                //ソート順２のヘッダ・フッタを表示
                this.SortDiv2Header.Visible = true;
                this.SortDiv2Header.DataField = DCHNB04154EA.ct_Col_CustomerCode;
                this.SortDiv2Footer.Visible = true;
                //ソート順３のヘッダ・フッタを表示
                this.SortDiv3Header.Visible = true;
                this.SortDiv3Header.DataField = DCHNB04154EA.ct_Col_StockAgentCode;
                this.SortDiv3Footer.Visible = true;

				//this.Sort3Total_Title.Visible = true;
//                this.Sort1Total_Title.Text = ShipmentListCndtn.GetSortTotalName((int)ShipmentListCndtn.PageChangeDivTitle.Sort_DetailGoodsGanreTitle);
//                this.Sort2Total_Title.Text = ShipmentListCndtn.GetSortTotalName((int)ShipmentListCndtn.PageChangeDivTitle.Sort_MediumGoodsGanreTitle);
//                this.Sort3Total_Title.Text = ShipmentListCndtn.GetSortTotalName((int)ShipmentListCndtn.PageChangeDivTitle.Sort_LargeGoodsGanreTitle);
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            }
            //ソート順が出荷可能数の場合
            else
            {
                //ソート順１のヘッダ・フッタを表示
                this.SortDiv1Header.Visible = true;
                this.SortDiv1Header.DataField = DCHNB04154EA.ct_Col_ArrivalGoodsDay;
                this.SortDiv1Footer.Visible = true;
                //ソート順２のヘッダ・フッタを表示
                this.SortDiv2Header.Visible = true;
                this.SortDiv2Header.DataField = DCHNB04154EA.ct_Col_CustomerCode;
                this.SortDiv2Footer.Visible = true;
                //ソート順３を非表示
                this.SortDiv3Header.Visible = false;
                this.SortDiv3Header.DataField = "";
                this.SortDiv3Footer.Visible = false;

//                this.Sort1Total_Title.Text = ShipmentListCndtn.GetSortTotalName((int)ShipmentListCndtn.PageChangeDivTitle.Sort_DetailGoodsGanreTitle);
//                this.Sort2Total_Title.Text = ShipmentListCndtn.GetSortTotalName((int)ShipmentListCndtn.PageChangeDivTitle.Sort_MediumGoodsGanreTitle);
			}
			2008.01.28 A.Mabuchi Delete END	*/ 
			#endregion  2008.01.28 A.Mabuchi END///////////////////////////////////////////////
			
		}

		/// <summary>
        /// グループ順制御
        /// </summary>
		/// <remarks>
		/// <br>Note       : グループの出力順を設定します</br>
        /// <br>Programmer : 30191 馬淵 愛</br>
        /// <br>Date	   : 2008.02.05</br>
        /// </remarks>
		private void ChangeGroupOrder()
		{
			switch (this._extrInfo.SortOrder)
			{
				case 0:	//仕入先→入荷日→伝票番号
					//SortDiv1Footerで入荷日計を出力させる
					this.SortDiv1Header.DataField = "ArrivalGoodsDay";
                    //txtSort1_Title.Text = "【入荷日計】"; // DEL 2009/04/28
                    txtSort1_Title.Text = "入荷日計"; // ADD 2009/04/28

					//SortDiv2Footerで仕入先計を出力させる
                    this.SortDiv2Header.DataField = "SupplierCd";
                    //txtSort2_Title.Text = "【仕入先計】"; // DEL 2009/04/28
                    txtSort2_Title.Text = "仕入先計"; // ADD 2009/04/28

					break;

				case 1:	//入荷日→仕入先→伝票番号
					//SortDiv1Footerで仕入先計を出力させる
					//SortDiv2Footerで仕入先計を出力させる
                    this.SortDiv1Header.DataField = "SupplierCd";
                    //txtSort1_Title.Text = "【仕入先計】"; // DEL 2009/04/28
                    txtSort1_Title.Text = "仕入先計"; // ADD 2009/04/28

					this.SortDiv2Header.DataField = "ArrivalGoodsDay";
                    //txtSort2_Title.Text = "【入荷日計】"; // DEL 2009/04/28
                    txtSort2_Title.Text = "入荷日計"; // ADD 2009/04/28

					break;

				case 2:	//担当者→仕入先→入荷日→伝票番号
					//全て表示。

					//SortDiv1Footerで入荷日計を出力させる
					this.SortDiv1Header.DataField = "ArrivalGoodsDay";
                    //txtSort1_Title.Text = "【入荷日計】"; // DEL 2009/04/28
                    txtSort1_Title.Text = "入荷日計"; // ADD 2009/04/28

					//SortDiv2Footerで仕入先計を出力させる
                    this.SortDiv2Header.DataField = "SupplierCd";
                    //txtSort2_Title.Text = "【仕入先計】"; // DEL 2009/04/28
                    txtSort2_Title.Text = "仕入先計"; // ADD 2009/04/28

					break;

				case 3:	//入荷日→伝票番号
					//SortDiv1Footerで入荷日計を出力させる
					this.SortDiv1Header.DataField = "ArrivalGoodsDay";
                    //txtSort1_Title.Text = "【入荷日計】"; // DEL 2009/04/28
                    txtSort1_Title.Text = "入荷日計"; // ADD 2009/04/28

					break;

				case 4:	//伝票番号

					break;
			}
		}

		/// <summary>
        /// 小計印字制御処理
        /// </summary>
		/// <remarks>
		/// <br>Note       : 小計の印字処理を制御します。</br>
		/// <br>Programmer : 30191 馬淵 愛</br>
		/// <br>Date	   : 2008.02.05</br>
		/// </remarks>
		private void ChangeSumRec()
		{
			//注：SortDiv3Footer は case 2 を除き常にFalse。
			switch (this._extrInfo.SortOrder)
			{
				case 0:	//仕入先→入荷日→伝票番号

                    // --- ADD 2009/04/08 -------------------------------->>>>>
                    // 日計印字制御
                    if (this._extrInfo.PrintDailyFooter == 0)
                    {
                        this.SortDiv1Footer.Visible = false;
                    }
                    // --- ADD 2009/04/08 --------------------------------<<<<<

					break;

				case 1:	//入荷日→仕入先→伝票番号

                    // --- ADD 2009/04/08 -------------------------------->>>>>
                    // 日計印字制御
                    if (this._extrInfo.PrintDailyFooter == 0)
                    {
                        this.SortDiv2Footer.Visible = false;
                    }
                    // --- ADD 2009/04/08 --------------------------------<<<<<

					break;

				case 2:	//担当者→仕入先→入荷日→伝票番号
					//全て表示。

                    // --- ADD 2009/04/08 -------------------------------->>>>>
                    // 日計印字制御
                    if (this._extrInfo.PrintDailyFooter == 0)
                    {
                        this.SortDiv1Footer.Visible = false;
                    }
                    // --- ADD 2009/04/08 --------------------------------<<<<<

					//担当者計表示
					this.SortDiv3Footer.Visible = true;

					break;

				case 3:	//入荷日→伝票番号

                    // --- ADD 2009/04/08 -------------------------------->>>>>
                    // 日計印字制御
                    if (this._extrInfo.PrintDailyFooter == 0)
                    {
                        this.SortDiv1Footer.Visible = false;
                    }
                    // --- ADD 2009/04/08 --------------------------------<<<<<

					//SortDiv2Footer非表示
					this.SortDiv2Footer.Visible = false;

					break;

				case 4:	//伝票番号
					this.SortDiv1Footer.Visible = false;
					this.SortDiv2Footer.Visible = false;
					this.SortDiv3Footer.Visible = false;

					break;
			}
		}
		
		#endregion
		//================================================================================
		//  イベント
		//================================================================================
		#region event
		/// <summary>
		/// DCKOU02303P_01A4C_ReportStartイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : DCKOU02303P_01A4C_ReportStartの初期化イベントです。</br>
		/// <br>Programmer : 980035 金沢　貞義</br>
		/// <br>Date	   : 2007.10.19</br>
		/// </remarks>
		private void DCKOU02303P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();

			// グループ順制御
			this.ChangeGroupOrder();

			// 小計印字制御
			this.ChangeSumRec();

            // --- ADD 2009/04/08 -------------------------------->>>>>
            // 改頁制御
            if (this._extrInfo.NewPageDiv == 0)
            {
                // 拠点毎
                this.SectionHeader.NewPage = NewPage.Before;
            }
            else if (this._extrInfo.NewPageDiv == 1)
            {
                // 仕入先毎
                if (this._extrInfo.SortOrder == 0
                    || this._extrInfo.SortOrder == 2)
                {
                    this.SortDiv2Header.NewPage = NewPage.Before;
                }
                else if (this._extrInfo.SortOrder == 1)
                {
                    this.SortDiv1Header.NewPage = NewPage.Before;
                }
            }
            // --- ADD 2009/04/08 --------------------------------<<<<<

            // --- DEL 2009/04/08 -------------------------------->>>>>
            //// --- ADD 2008/09/26 --------->>>>>
            //// 不要項目非表示
            //this.label9.Visible = false;        // No.項目　ヘッダー部
            //this.textBox22.Visible = false;     // No.項目　データ部
            //this.line16.Visible = false;        // 点線の罫線　ヘッダー部
            //this.line51.Visible = false;        // 点線の罫線　データ部
            //// 桁数変更
            //this.textBox24.OutputFormat = "000000";     // 仕入先8→6
            //this.textBox2.OutputFormat = "000000";      // 支払先8→6
            //// --- ADD 2008/09/26 ---------<<<<<
            // --- DEL 2009/04/08 --------------------------------<<<<<
		}

		/// <summary>
		/// PageHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer : 980035 金沢　貞義</br>
		/// <br>Date	   : 2007.10.19</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// ソート順
			this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

			// 作成日付           
			//現在の時刻を取得
			DateTime now = DateTime.Now;
			//作成日(西暦で表示)
			this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
			// 作成時間
			this.PrintTime.Text = now.ToString("HH:mm");

		}

		/// <summary>
		/// ExtraHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{			
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

            /* --- DEL 2008/09/26 途中で切れる為 -------------------------------->>>>>
            // 『抽出条件』
            for (int i = 0; i < this._extraConditions.Count; i++)
            {
                this.Extraction.Text = this._extraConditions[i];
            }
               --- DEL 2008/09/26 -----------------------------------------------<<<<< */
            // --- ADD 2008/09/26 ----------------------------------------------->>>>>
            ListCommon_ExtraHeader rptExtraHeader = new ListCommon_ExtraHeader();
            rptExtraHeader.ExtraConditions = this._extraConditions;
            this.subReport1.Report = rptExtraHeader;
            // --- ADD 2008/09/26 -----------------------------------------------<<<<<

            /* --- DEL 2008/09/26 赤伝区分は表示しない為 ----------------------------------------------->>>>>
			//抽出条件の『赤伝区分』が 3:全て だった場合に、「赤伝区分名称」を表示する。
			if (_extrInfo.DebitNoteDiv == 3)
			{
				this.lblDebitNote.Visible = true;
			}
			else
			{
				this.lblDebitNote.Visible = false;
			}
               --- DEL 2008/09/26 ----------------------------------------------------------------------<<<<< */
            //this.lblDebitNote.Visible = false;          //ADD 2008/09/26 // DEL 2009/04/08

            //08.01.30 A.Mabuchi START---------------------------------------------------------------------
			//if (this._rptExtraHeader == null)
			//{
			//    this._rptExtraHeader = new ListCommon_ExtraHeader();
			//}
			//else
			//{
			//    this._rptExtraHeader.DataSource = null;
			//}

            //全社選択のときは、固定で「全社」と設定する
			//if (this._extrInfo.DepositStockSecCodeList.Length == 0)
			//{
			//    this._rptExtraHeader.SectionCondition.Text = "在庫拠点： 全社";
			//}
			//else
			//{
			//    this._rptExtraHeader.SectionCondition.Text = "在庫拠点： " + this.StockSectionName.Text;
			//}

			// 抽出条件印字項目設定
			//this._rptExtraHeader.ExtraConditions         = this._extraConditions;
			//----------------------------------------------------------------------------------------------

            // --- DEL 2009/04/08 -------------------------------->>>>>
            //// 2009.02.06 30413 犬飼 拠点コードの改頁と総合計印字制御 >>>>>>START
            //this.textBox10.Text = this.textBox27.Text.Trim();
            //this.textBox14.Text = this.textBox28.Text.Trim();
            //// 2009.02.06 30413 犬飼 拠点コードの改頁と総合計印字制御 <<<<<<END
            // --- DEL 2009/04/08 --------------------------------<<<<<
        }

		/// <summary>
		/// TitleHeader_Formatイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : 合計伝票枚数を計算します。</br>
		/// <br>Programmer  : 30191 馬淵 愛</br>
		/// <br>Date		: 2008.01.31</br>
		/// </remarks>
		private void TitleHeader_Format(object sender, EventArgs e)
		{
            /* --- DEL 2008/09/26 赤伝区分は表示しない為 ----------------------------------------------->>>>>
			//抽出条件の『赤伝区分』が 3:全て だった場合に、明細に赤伝区分名称を表示する。
			if (_extrInfo.DebitNoteDiv == 3)
			{
				this.txtDebitNoteDivNameDtl.Visible = true;
			}
			else
			{
				this.txtDebitNoteDivNameDtl.Visible = false;
			}
               --- DEL 2008/09/26 赤伝区分は表示しない為 -----------------------------------------------<<<<< */
            //this.txtDebitNoteDivNameDtl.Visible = false;        //ADD 2008/09/26 // DEL 2009/04/08

            // 2009.02.06 30413 犬飼 伝票区分は"入荷"と"返品" >>>>>>START
            switch (this.TransactionNameRF.Value.ToString())
			{
                //case "掛仕入":
                case "入荷":
			
			        this.slipRowNoStk_Sc += 1;
			        this.slipRowNoStk_Ttl += 1;
			        break;

                //case "掛返品":
                case "返品":

			        this.slipRowNoRtn_Sc += 1;
			        this.slipRowNoRtn_Ttl += 1;
			        break;
			
			}
            // 2009.02.06 30413 犬飼 伝票区分は"入荷"と"返品" <<<<<<END

            // --- ADD 2009/04/08 -------------------------------->>>>>
            // 計上日の印字制御
            if (this.StockAddUpADate.Text == "0001/01/01")
            {
                this.StockAddUpADate.Text = string.Empty;
            }
            // --- ADD 2009/04/08 --------------------------------<<<<<
		}

		/// <summary>
		/// Detail_BeforePrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 980035 金沢　貞義</br>
		/// <br>Date	   : 2007.10.19</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

		}
		
		/// <summary>
		/// PageFooter_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // ADD 2009/01/19 不具合対応[9668] ---------->>>>>
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// インスタンスが作成されていなければ作成
				if ( this._rptPageFooter == null)
				{
					this._rptPageFooter = new ListCommon_PageFooter();
				}
				else
				{
					// インスタンスが作成されていれば、データソースを初期化する
					// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
					this._rptPageFooter.DataSource = null;
				}

				// フッター印字項目設定
				if (this._pageFooters[0] != null)
				{
					this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
				}
				if (this._pageFooters[1] != null)
				{
					this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
				}
			
				this.Footer_SubReport.Report = this._rptPageFooter;				
			}
            // ADD 2008/01/19 不具合対応[9668] ----------<<<<<
		}


		/// <summary>
		/// 明細アフタープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date	    : 2007.10.19</br>
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

        /// <summary>
        /// Detail_Formatイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 2009.02.13 30413 犬飼 単価の印字制御 >>>>>>START
            double stockUnitPriceFl;
            if (double.TryParse(textBox17.Value.ToString(), out stockUnitPriceFl))
            {
                if (stockUnitPriceFl == 0)
                {
                    // ゼロの場合は非印字
                    textBox17.Visible = false;
                }
                else
                {
                    // 上記以外の場合は印字
                    textBox17.Visible = true;
                }
            }
            else
            {
                // 取得不可なら非印字
                textBox17.Visible = false;
            }
            // 2009.02.13 30413 犬飼 単価の印字制御 <<<<<<END

            // --- ADD 2009/04/08 -------------------------------->>>>>
            // 消費税の表示制御
            if (this.Detail_SuppCTaxLayCd.Value.ToString() == "0")
            {
                // 消費税転嫁方式　0:伝票
                this.StockPriceConsTax.Visible= false;
            }
            else if (this.Detail_SuppCTaxLayCd.Value.ToString() == "1")
            {
                // 消費税転嫁方式　1:明細単位

                if ((this.Detail_TaxationCode.Value.ToString() == "0") ||
                    (this.Detail_TaxationCode.Value.ToString() == "2"))
                {
                    // 課税区分　0：課税、2：内税
                    this.StockPriceConsTax.Visible = true;
                }
                else
                {
                    // 課税区分　1：非課税
                    this.StockPriceConsTax.Visible = false;
                }
            }
            else
            {
                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                if (this.Detail_TaxationCode.Value.ToString().TrimEnd() == "2")
                {
                    // 課税区分　2：内税
                    this.StockPriceConsTax.Visible = true;
                }
                else
                {
                    // 課税区分　0：課税、1：非課税
                    this.StockPriceConsTax.Visible = false;
                }
            }
            // --- ADD 2009/04/08 --------------------------------<<<<<
        }

        // --- ADD 2009/04/08 -------------------------------->>>>>
        /// <summary>
        /// TitleFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleFooter_BeforePrint(object sender, EventArgs e)
        {
            // 消費税の印字制御
            if (this.TitFt_SuppCTaxLayCd.Value.ToString() != "0"
                && this.TitFt_SuppCTaxLayCd.Value.ToString() != "1")
            {
                this.TitFt_StockPriceConsTax.Text = "";
            }
        }
        // --- ADD 2009/04/08 --------------------------------<<<<<

		/// <summary>
		/// SectionFooter_Formatイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : 合計伝票枚数を計算します。</br>
		/// <br>Programmer  : 30191 馬淵 愛</br>
		/// <br>Date		: 2008.01.30</br>
		/// </remarks>
		private void SectionFooter_Format(object sender, EventArgs e)
		{
			this.txtCntArrivalSl_Sc.Value = this.slipRowNoStk_Sc;
			this.txtCntReturnSl_Sc.Value = this.slipRowNoRtn_Sc;

			this.txtCntTotal_Sc.Value = this.slipRowNoStk_Sc + this.slipRowNoRtn_Sc;

			//伝票枚数初期化
			this.slipRowNoStk_Sc = 0;
			this.slipRowNoRtn_Sc = 0;

		}

		/// <summary>
		/// GrandTotalFooter_Formatイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : 合計伝票枚数を計算します。</br>
		/// <br>Programmer  : 30191 馬淵 愛</br>
		/// <br>Date		: 2008.01.30</br>
		/// </remarks>
		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
			this.txtCntArrivalSl_Ttl.Value = this.slipRowNoStk_Ttl;
			this.txtCntReturnSl_Ttl.Value = this.slipRowNoRtn_Ttl;

			this.txtCntTotal_Ttl.Value = this.slipRowNoStk_Ttl + this.slipRowNoRtn_Ttl; 

		}

		#endregion

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label ListTitle_Title;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox PRINTPAGE;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox SORTTITLE;
		private DataDynamics.ActiveReports.TextBox PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.GroupHeader SortDiv3Header;
		private DataDynamics.ActiveReports.GroupHeader SortDiv2Header;
		private DataDynamics.ActiveReports.GroupHeader SortDiv1Header;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.GroupFooter SortDiv1Footer;
		private DataDynamics.ActiveReports.GroupFooter SortDiv2Footer;
		private DataDynamics.ActiveReports.GroupFooter SortDiv3Footer;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKOU02303P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.Detail_SuppCTaxLayCd = new DataDynamics.ActiveReports.TextBox();
            this.Detail_TaxationCode = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.ListTitle_Title = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PRINTPAGE = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.label58 = new DataDynamics.ActiveReports.Label();
            this.label59 = new DataDynamics.ActiveReports.Label();
            this.txtCntArrivalSl_Ttl = new DataDynamics.ActiveReports.TextBox();
            this.txtCntReturnSl_Ttl = new DataDynamics.ActiveReports.TextBox();
            this.label60 = new DataDynamics.ActiveReports.Label();
            this.label61 = new DataDynamics.ActiveReports.Label();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.txtCntTotal_Ttl = new DataDynamics.ActiveReports.TextBox();
            this.label62 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.TransactionNameRF = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.StockAddUpADate = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TitFt_StockPriceConsTax = new DataDynamics.ActiveReports.TextBox();
            this.TitFt_SuppCTaxLayCd = new DataDynamics.ActiveReports.TextBox();
            this.TitFt_TaxationCode = new DataDynamics.ActiveReports.TextBox();
            this.SortDiv3Header = new DataDynamics.ActiveReports.GroupHeader();
            this.SortDiv3Footer = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.SortDiv2Header = new DataDynamics.ActiveReports.GroupHeader();
            this.SortDiv2Footer = new DataDynamics.ActiveReports.GroupFooter();
            this.txtSort2_Title = new DataDynamics.ActiveReports.TextBox();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.SortDiv1Header = new DataDynamics.ActiveReports.GroupHeader();
            this.SortDiv1Footer = new DataDynamics.ActiveReports.GroupFooter();
            this.txtSort1_Title = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.label44 = new DataDynamics.ActiveReports.Label();
            this.label45 = new DataDynamics.ActiveReports.Label();
            this.txtCntArrivalSl_Sc = new DataDynamics.ActiveReports.TextBox();
            this.txtCntReturnSl_Sc = new DataDynamics.ActiveReports.TextBox();
            this.label46 = new DataDynamics.ActiveReports.Label();
            this.label47 = new DataDynamics.ActiveReports.Label();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.txtCntTotal_Sc = new DataDynamics.ActiveReports.TextBox();
            this.label56 = new DataDynamics.ActiveReports.Label();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_SuppCTaxLayCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_TaxationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTitle_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntArrivalSl_Ttl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntReturnSl_Ttl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntTotal_Ttl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionNameRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAddUpADate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitFt_StockPriceConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitFt_SuppCTaxLayCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitFt_TaxationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort2_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntArrivalSl_Sc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntReturnSl_Sc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntTotal_Sc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox9,
            this.textBox16,
            this.textBox17,
            this.textBox19,
            this.textBox20,
            this.line3,
            this.textBox18,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox37,
            this.StockPriceConsTax,
            this.Detail_SuppCTaxLayCd,
            this.Detail_TaxationCode});
            this.Detail.Height = 0.6666667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.textBox9.DataField = "StockPriceTaxExc";
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 7.0625F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.textBox9.Text = "12,123,456,789";
            this.textBox9.Top = 0.0625F;
            this.textBox9.Width = 1F;
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
            this.textBox16.DataField = "StockCount";
            this.textBox16.Height = 0.1875F;
            this.textBox16.Left = 5.6125F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.textBox16.Text = "123,456.00";
            this.textBox16.Top = 0.0625F;
            this.textBox16.Width = 0.75F;
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
            this.textBox17.DataField = "StockUnitPriceFl";
            this.textBox17.Height = 0.188F;
            this.textBox17.Left = 6.3625F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox17.Text = "123,456,789";
            this.textBox17.Top = 0.0625F;
            this.textBox17.Width = 0.7F;
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
            this.textBox19.DataField = "GoodsName";
            this.textBox19.Height = 0.1875F;
            this.textBox19.Left = 2.56F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; vertical-align: top; ";
            this.textBox19.Text = "12345678901234567890";
            this.textBox19.Top = 0.0625F;
            this.textBox19.Width = 1.0625F;
            // 
            // textBox20
            // 
            this.textBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.RightColor = System.Drawing.Color.Black;
            this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.TopColor = System.Drawing.Color.Black;
            this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.DataField = "GoodsNo";
            this.textBox20.Height = 0.188F;
            this.textBox20.Left = 0.56F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox20.Text = "1234567890123456789012345678901234567890";
            this.textBox20.Top = 0.0625F;
            this.textBox20.Width = 2F;
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
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
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
            this.textBox18.DataField = "BLGoodsCode";
            this.textBox18.Height = 0.188F;
            this.textBox18.Left = 0.063F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox18.Text = "00000";
            this.textBox18.Top = 0.063F;
            this.textBox18.Width = 0.3F;
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
            this.textBox29.DataField = "GoodsMakerCd";
            this.textBox29.Height = 0.1875F;
            this.textBox29.Left = 3.685F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox29.Text = "0000";
            this.textBox29.Top = 0.0625F;
            this.textBox29.Width = 0.5F;
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
            this.textBox30.DataField = "StockOrderDivName";
            this.textBox30.Height = 0.1875F;
            this.textBox30.Left = 4.2475F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; vertical-align: top; ";
            this.textBox30.Text = "取寄";
            this.textBox30.Top = 0.0625F;
            this.textBox30.Width = 0.3F;
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
            this.textBox31.DataField = "WarehouseName";
            this.textBox31.Height = 0.1875F;
            this.textBox31.Left = 4.55F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; vertical-align: top; ";
            this.textBox31.Text = "あいうえおかきくけこ";
            this.textBox31.Top = 0.0625F;
            this.textBox31.Width = 1.0625F;
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
            this.textBox32.DataField = "ArrivalRemainCnt";
            this.textBox32.Height = 0.188F;
            this.textBox32.Left = 8.0625F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox32.Text = "1,234,567.00";
            this.textBox32.Top = 0.0625F;
            this.textBox32.Width = 0.75F;
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
            this.textBox37.DataField = "ArrivalRemainPrice";
            this.textBox37.Height = 0.188F;
            this.textBox37.Left = 8.8125F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox37.Text = "12,345,678,901";
            this.textBox37.Top = 0.0625F;
            this.textBox37.Width = 0.8F;
            // 
            // StockPriceConsTax
            // 
            this.StockPriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceConsTax.DataField = "StockPriceConsTax";
            this.StockPriceConsTax.Height = 0.188F;
            this.StockPriceConsTax.Left = 9.6125F;
            this.StockPriceConsTax.MultiLine = false;
            this.StockPriceConsTax.Name = "StockPriceConsTax";
            this.StockPriceConsTax.OutputFormat = resources.GetString("StockPriceConsTax.OutputFormat");
            this.StockPriceConsTax.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.StockPriceConsTax.Text = "123,456,789,012";
            this.StockPriceConsTax.Top = 0.0625F;
            this.StockPriceConsTax.Width = 0.8F;
            // 
            // Detail_SuppCTaxLayCd
            // 
            this.Detail_SuppCTaxLayCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.Border.RightColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.Border.TopColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.DataField = "SuppCTaxLayCd";
            this.Detail_SuppCTaxLayCd.Height = 0.1875F;
            this.Detail_SuppCTaxLayCd.Left = 6.875F;
            this.Detail_SuppCTaxLayCd.MultiLine = false;
            this.Detail_SuppCTaxLayCd.Name = "Detail_SuppCTaxLayCd";
            this.Detail_SuppCTaxLayCd.OutputFormat = resources.GetString("Detail_SuppCTaxLayCd.OutputFormat");
            this.Detail_SuppCTaxLayCd.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.Detail_SuppCTaxLayCd.Text = null;
            this.Detail_SuppCTaxLayCd.Top = 0.3125F;
            this.Detail_SuppCTaxLayCd.Visible = false;
            this.Detail_SuppCTaxLayCd.Width = 0.75F;
            // 
            // Detail_TaxationCode
            // 
            this.Detail_TaxationCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.Border.RightColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.Border.TopColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.DataField = "TaxationCode";
            this.Detail_TaxationCode.Height = 0.1875F;
            this.Detail_TaxationCode.Left = 7.625F;
            this.Detail_TaxationCode.MultiLine = false;
            this.Detail_TaxationCode.Name = "Detail_TaxationCode";
            this.Detail_TaxationCode.OutputFormat = resources.GetString("Detail_TaxationCode.OutputFormat");
            this.Detail_TaxationCode.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.Detail_TaxationCode.Text = null;
            this.Detail_TaxationCode.Top = 0.3125F;
            this.Detail_TaxationCode.Visible = false;
            this.Detail_TaxationCode.Width = 0.75F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ListTitle_Title,
            this.Label3,
            this.PrintDate,
            this.Label2,
            this.PRINTPAGE,
            this.Line1,
            this.SORTTITLE,
            this.PrintTime});
            this.PageHeader.Height = 0.2604167F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // ListTitle_Title
            // 
            this.ListTitle_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.DataField = "ListTitle";
            this.ListTitle_Title.Height = 0.21875F;
            this.ListTitle_Title.HyperLink = "";
            this.ListTitle_Title.Left = 0.25F;
            this.ListTitle_Title.MultiLine = false;
            this.ListTitle_Title.Name = "ListTitle_Title";
            this.ListTitle_Title.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.ListTitle_Title.Text = "入荷確認表";
            this.ListTitle_Title.Top = 0F;
            this.ListTitle_Title.Width = 2.09375F;
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
            // PrintDate
            // 
            this.PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.CanShrink = true;
            this.PrintDate.Height = 0.15625F;
            this.PrintDate.Left = 8.5F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate.Text = "平成17年11月 5日";
            this.PrintDate.Top = 0.0625F;
            this.PrintDate.Width = 0.9375F;
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
            // PRINTPAGE
            // 
            this.PRINTPAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.CanShrink = true;
            this.PRINTPAGE.Height = 0.15625F;
            this.PRINTPAGE.Left = 10.4375F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.0625F;
            this.PRINTPAGE.Width = 0.28125F;
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
            this.Line1.Top = 0.22F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.22F;
            this.Line1.Y2 = 0.22F;
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
            this.SORTTITLE.CanShrink = true;
            this.SORTTITLE.Height = 0.188F;
            this.SORTTITLE.Left = 3.125F;
            this.SORTTITLE.MultiLine = false;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SORTTITLE.Text = null;
            this.SORTTITLE.Top = 0.063F;
            this.SORTTITLE.Width = 2.688F;
            // 
            // PrintTime
            // 
            this.PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Height = 0.125F;
            this.PrintTime.Left = 9.4375F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11時20分";
            this.PrintTime.Top = 0.0625F;
            this.PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line17,
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3229167F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // line17
            // 
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0F;
            this.line17.Left = 0F;
            this.line17.LineWeight = 2F;
            this.line17.Name = "line17";
            this.line17.Top = 0F;
            this.line17.Visible = false;
            this.line17.Width = 10.8125F;
            this.line17.X1 = 0F;
            this.line17.X2 = 10.8125F;
            this.line17.Y1 = 0F;
            this.line17.Y2 = 0F;
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
            this.Footer_SubReport.Height = 0.25F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 11.3125F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.label12,
            this.label5,
            this.label7,
            this.label16,
            this.label22,
            this.label14,
            this.label17,
            this.label18,
            this.label20,
            this.line7,
            this.line8,
            this.label24,
            this.label6,
            this.label13,
            this.label15,
            this.label19,
            this.label10,
            this.label23,
            this.label27,
            this.label28,
            this.label29,
            this.label30});
            this.ExtraHeader.Height = 0.875F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // subReport1
            // 
            this.subReport1.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.RightColor = System.Drawing.Color.Black;
            this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.TopColor = System.Drawing.Color.Black;
            this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 0.375F;
            this.subReport1.Left = 0F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0F;
            this.subReport1.Width = 10.8125F;
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
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = null;
            this.label12.Left = 6.56F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label12.Text = "仕入SEQ番号";
            this.label12.Top = 0.45F;
            this.label12.Width = 0.6875F;
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
            this.label5.Height = 0.1875F;
            this.label5.HyperLink = null;
            this.label5.Left = 0F;
            this.label5.Name = "label5";
            this.label5.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label5.Text = "仕入先";
            this.label5.Top = 0.45F;
            this.label5.Width = 0.5625F;
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
            this.label7.Height = 0.1875F;
            this.label7.HyperLink = null;
            this.label7.Left = 3.1225F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label7.Text = "入力日";
            this.label7.Top = 0.45F;
            this.label7.Width = 0.5625F;
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
            this.label16.Height = 0.1875F;
            this.label16.HyperLink = null;
            this.label16.Left = 6.06F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label16.Text = "区分";
            this.label16.Top = 0.45F;
            this.label16.Width = 0.5F;
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
            this.label22.Height = 0.188F;
            this.label22.HyperLink = null;
            this.label22.Left = 7.0625F;
            this.label22.Name = "label22";
            this.label22.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label22.Text = "金額";
            this.label22.Top = 0.6375F;
            this.label22.Width = 1F;
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
            this.label14.Height = 0.188F;
            this.label14.HyperLink = null;
            this.label14.Left = 0.56F;
            this.label14.Name = "label14";
            this.label14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label14.Text = "品番";
            this.label14.Top = 0.6375F;
            this.label14.Width = 2F;
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
            this.label17.Height = 0.188F;
            this.label17.HyperLink = null;
            this.label17.Left = 2.56F;
            this.label17.Name = "label17";
            this.label17.Style = "color: Black; text-align: left; font-weight: bold; font-size: 7pt; vertical-align" +
                ": top; ";
            this.label17.Text = "品名";
            this.label17.Top = 0.6375F;
            this.label17.Width = 1.06F;
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
            this.label18.Height = 0.188F;
            this.label18.HyperLink = null;
            this.label18.Left = 5.6125F;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label18.Text = "数量";
            this.label18.Top = 0.6375F;
            this.label18.Width = 0.75F;
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
            this.label20.Height = 0.188F;
            this.label20.HyperLink = null;
            this.label20.Left = 6.3625F;
            this.label20.Name = "label20";
            this.label20.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label20.Text = "単価";
            this.label20.Top = 0.6375F;
            this.label20.Width = 0.7F;
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
            this.line7.Top = 0.375F;
            this.line7.Width = 10.8125F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8125F;
            this.line7.Y1 = 0.375F;
            this.line7.Y2 = 0.375F;
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
            this.line8.Top = 0.375F;
            this.line8.Width = 10.8125F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8125F;
            this.line8.Y1 = 0.375F;
            this.line8.Y2 = 0.375F;
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
            this.label24.Height = 0.1875F;
            this.label24.HyperLink = null;
            this.label24.Left = 2.56F;
            this.label24.Name = "label24";
            this.label24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label24.Text = "入荷日";
            this.label24.Top = 0.45F;
            this.label24.Width = 0.5625F;
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
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = null;
            this.label6.Left = 4.2475F;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label6.Text = "伝票番号";
            this.label6.Top = 0.45F;
            this.label6.Width = 1.8125F;
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
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = null;
            this.label13.Left = 7.2475F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label13.Text = "備考";
            this.label13.Top = 0.45F;
            this.label13.Width = 0.6875F;
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
            this.label15.Height = 0.1875F;
            this.label15.HyperLink = null;
            this.label15.Left = 3.685F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label15.Text = "計上日";
            this.label15.Top = 0.45F;
            this.label15.Width = 0.5625F;
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
            this.label19.Height = 0.188F;
            this.label19.HyperLink = null;
            this.label19.Left = 0.0625F;
            this.label19.Name = "label19";
            this.label19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label19.Text = "BLコード";
            this.label19.Top = 0.6375F;
            this.label19.Width = 0.5F;
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
            this.label10.Height = 0.1875F;
            this.label10.HyperLink = null;
            this.label10.Left = 3.685F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; text-align: left; font-weight: bold; font-size: 7pt; vertical-align" +
                ": top; ";
            this.label10.Text = "メーカー";
            this.label10.Top = 0.6375F;
            this.label10.Width = 0.5F;
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
            this.label23.Height = 0.1875F;
            this.label23.HyperLink = null;
            this.label23.Left = 4.2475F;
            this.label23.Name = "label23";
            this.label23.Style = "color: Black; text-align: left; font-weight: bold; font-size: 7pt; vertical-align" +
                ": top; ";
            this.label23.Text = "在取";
            this.label23.Top = 0.6375F;
            this.label23.Width = 0.3F;
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
            this.label27.Height = 0.1875F;
            this.label27.HyperLink = null;
            this.label27.Left = 4.55F;
            this.label27.Name = "label27";
            this.label27.Style = "color: Black; text-align: left; font-weight: bold; font-size: 7pt; vertical-align" +
                ": top; ";
            this.label27.Text = "倉庫";
            this.label27.Top = 0.6375F;
            this.label27.Width = 1.0625F;
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
            this.label28.Height = 0.188F;
            this.label28.HyperLink = null;
            this.label28.Left = 8.0625F;
            this.label28.Name = "label28";
            this.label28.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label28.Text = "入荷残数";
            this.label28.Top = 0.6375F;
            this.label28.Width = 0.75F;
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
            this.label29.Height = 0.188F;
            this.label29.HyperLink = null;
            this.label29.Left = 8.8125F;
            this.label29.Name = "label29";
            this.label29.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label29.Text = "入荷残金額";
            this.label29.Top = 0.6375F;
            this.label29.Width = 0.8F;
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
            this.label30.Height = 0.188F;
            this.label30.HyperLink = null;
            this.label30.Left = 9.6125F;
            this.label30.Name = "label30";
            this.label30.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label30.Text = "消費税";
            this.label30.Top = 0.6375F;
            this.label30.Width = 0.8F;
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
            this.textBox28.Height = 0.188F;
            this.textBox28.Left = 0.5F;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "font-size: 8pt; vertical-align: top; ";
            this.textBox28.Text = "あいうえおかきくけこ";
            this.textBox28.Top = 0.0625F;
            this.textBox28.Width = 1.5F;
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
            this.textBox27.Height = 0.188F;
            this.textBox27.Left = 0.3F;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.textBox27.Text = "99";
            this.textBox27.Top = 0.0625F;
            this.textBox27.Width = 0.2F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox3,
            this.label38,
            this.label58,
            this.label59,
            this.txtCntArrivalSl_Ttl,
            this.txtCntReturnSl_Ttl,
            this.label60,
            this.label61,
            this.textBox25,
            this.txtCntTotal_Ttl,
            this.label62,
            this.line2,
            this.textBox44});
            this.ExtraFooter.Height = 0.71875F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
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
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 4.875F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.textBox3.Text = "総合計";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.7F;
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
            this.label38.Height = 0.125F;
            this.label38.HyperLink = null;
            this.label38.Left = 5.625F;
            this.label38.MultiLine = false;
            this.label38.Name = "label38";
            this.label38.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label38.Text = "入　荷";
            this.label38.Top = 0.0625F;
            this.label38.Width = 0.563F;
            // 
            // label58
            // 
            this.label58.Border.BottomColor = System.Drawing.Color.Black;
            this.label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.LeftColor = System.Drawing.Color.Black;
            this.label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.RightColor = System.Drawing.Color.Black;
            this.label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.TopColor = System.Drawing.Color.Black;
            this.label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Height = 0.188F;
            this.label58.HyperLink = null;
            this.label58.Left = 5.625F;
            this.label58.MultiLine = false;
            this.label58.Name = "label58";
            this.label58.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label58.Text = "合　計";
            this.label58.Top = 0.4375F;
            this.label58.Width = 0.563F;
            // 
            // label59
            // 
            this.label59.Border.BottomColor = System.Drawing.Color.Black;
            this.label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.LeftColor = System.Drawing.Color.Black;
            this.label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.RightColor = System.Drawing.Color.Black;
            this.label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.TopColor = System.Drawing.Color.Black;
            this.label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Height = 0.125F;
            this.label59.HyperLink = null;
            this.label59.Left = 5.625F;
            this.label59.MultiLine = false;
            this.label59.Name = "label59";
            this.label59.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label59.Text = "返　品";
            this.label59.Top = 0.25F;
            this.label59.Width = 0.563F;
            // 
            // txtCntArrivalSl_Ttl
            // 
            this.txtCntArrivalSl_Ttl.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Ttl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Ttl.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Ttl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Ttl.Border.RightColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Ttl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Ttl.Border.TopColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Ttl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Ttl.Height = 0.125F;
            this.txtCntArrivalSl_Ttl.Left = 6.25F;
            this.txtCntArrivalSl_Ttl.MultiLine = false;
            this.txtCntArrivalSl_Ttl.Name = "txtCntArrivalSl_Ttl";
            this.txtCntArrivalSl_Ttl.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtCntArrivalSl_Ttl.SummaryGroup = "GrandTotalHeader";
            this.txtCntArrivalSl_Ttl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtCntArrivalSl_Ttl.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtCntArrivalSl_Ttl.Text = "123";
            this.txtCntArrivalSl_Ttl.Top = 0.0625F;
            this.txtCntArrivalSl_Ttl.Width = 0.213F;
            // 
            // txtCntReturnSl_Ttl
            // 
            this.txtCntReturnSl_Ttl.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Ttl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Ttl.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Ttl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Ttl.Border.RightColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Ttl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Ttl.Border.TopColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Ttl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Ttl.Height = 0.125F;
            this.txtCntReturnSl_Ttl.Left = 6.25F;
            this.txtCntReturnSl_Ttl.MultiLine = false;
            this.txtCntReturnSl_Ttl.Name = "txtCntReturnSl_Ttl";
            this.txtCntReturnSl_Ttl.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtCntReturnSl_Ttl.SummaryGroup = "GrandTotalHeader";
            this.txtCntReturnSl_Ttl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtCntReturnSl_Ttl.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtCntReturnSl_Ttl.Text = "123";
            this.txtCntReturnSl_Ttl.Top = 0.25F;
            this.txtCntReturnSl_Ttl.Width = 0.213F;
            // 
            // label60
            // 
            this.label60.Border.BottomColor = System.Drawing.Color.Black;
            this.label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.LeftColor = System.Drawing.Color.Black;
            this.label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.RightColor = System.Drawing.Color.Black;
            this.label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.TopColor = System.Drawing.Color.Black;
            this.label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Height = 0.125F;
            this.label60.HyperLink = null;
            this.label60.Left = 6.5F;
            this.label60.MultiLine = false;
            this.label60.Name = "label60";
            this.label60.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label60.Text = "枚";
            this.label60.Top = 0.0625F;
            this.label60.Width = 0.25F;
            // 
            // label61
            // 
            this.label61.Border.BottomColor = System.Drawing.Color.Black;
            this.label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.LeftColor = System.Drawing.Color.Black;
            this.label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.RightColor = System.Drawing.Color.Black;
            this.label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.TopColor = System.Drawing.Color.Black;
            this.label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Height = 0.125F;
            this.label61.HyperLink = null;
            this.label61.Left = 6.5F;
            this.label61.MultiLine = false;
            this.label61.Name = "label61";
            this.label61.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label61.Text = "枚";
            this.label61.Top = 0.25F;
            this.label61.Width = 0.25F;
            // 
            // textBox25
            // 
            this.textBox25.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.RightColor = System.Drawing.Color.Black;
            this.textBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.TopColor = System.Drawing.Color.Black;
            this.textBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.DataField = "StockPriceTaxExc";
            this.textBox25.Height = 0.188F;
            this.textBox25.Left = 7.0625F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox25.SummaryGroup = "ExtraHeader";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox25.Text = "123,456,123,456,789";
            this.textBox25.Top = 0.0625F;
            this.textBox25.Width = 1F;
            // 
            // txtCntTotal_Ttl
            // 
            this.txtCntTotal_Ttl.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCntTotal_Ttl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Ttl.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCntTotal_Ttl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Ttl.Border.RightColor = System.Drawing.Color.Black;
            this.txtCntTotal_Ttl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Ttl.Border.TopColor = System.Drawing.Color.Black;
            this.txtCntTotal_Ttl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Ttl.Height = 0.125F;
            this.txtCntTotal_Ttl.Left = 6.25F;
            this.txtCntTotal_Ttl.MultiLine = false;
            this.txtCntTotal_Ttl.Name = "txtCntTotal_Ttl";
            this.txtCntTotal_Ttl.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtCntTotal_Ttl.SummaryGroup = "GrandTotalHeader";
            this.txtCntTotal_Ttl.Text = "123";
            this.txtCntTotal_Ttl.Top = 0.4375F;
            this.txtCntTotal_Ttl.Width = 0.213F;
            // 
            // label62
            // 
            this.label62.Border.BottomColor = System.Drawing.Color.Black;
            this.label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.LeftColor = System.Drawing.Color.Black;
            this.label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.RightColor = System.Drawing.Color.Black;
            this.label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.TopColor = System.Drawing.Color.Black;
            this.label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Height = 0.125F;
            this.label62.HyperLink = null;
            this.label62.Left = 6.5F;
            this.label62.MultiLine = false;
            this.label62.Name = "label62";
            this.label62.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label62.Text = "枚";
            this.label62.Top = 0.4375F;
            this.label62.Width = 0.25F;
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
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // textBox44
            // 
            this.textBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.RightColor = System.Drawing.Color.Black;
            this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.TopColor = System.Drawing.Color.Black;
            this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.DataField = "ArrivalRemainPrice";
            this.textBox44.Height = 0.188F;
            this.textBox44.Left = 8.8125F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.SummaryGroup = "ExtraHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox44.Text = "12,345,678,901";
            this.textBox44.Top = 0.0625F;
            this.textBox44.Width = 0.8F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox23,
            this.CustomerName,
            this.textBox34,
            this.TransactionNameRF,
            this.textBox33,
            this.textBox24,
            this.line6,
            this.textBox10,
            this.textBox14,
            this.StockAddUpADate});
            this.TitleHeader.DataField = "SupplierSlipNo";
            this.TitleHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.TitleHeader.Height = 0.375F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // textBox23
            // 
            this.textBox23.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.RightColor = System.Drawing.Color.Black;
            this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.TopColor = System.Drawing.Color.Black;
            this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.DataField = "SupplierSlipNo";
            this.textBox23.Height = 0.1875F;
            this.textBox23.Left = 6.56F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "ゴシック; vertical-align: top; ";
            this.textBox23.Text = "999999999";
            this.textBox23.Top = 0.0625F;
            this.textBox23.Width = 0.6875F;
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
            this.CustomerName.Height = 0.188F;
            this.CustomerName.Left = 0.56F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Style = "color: Black; ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.CustomerName.Text = null;
            this.CustomerName.Top = 0.0625F;
            this.CustomerName.Width = 2F;
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
            this.textBox34.DataField = "ArrivalGoodsDay";
            this.textBox34.Height = 0.188F;
            this.textBox34.Left = 2.56F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox34.Text = "2008/01/01";
            this.textBox34.Top = 0.0625F;
            this.textBox34.Width = 0.563F;
            // 
            // TransactionNameRF
            // 
            this.TransactionNameRF.Border.BottomColor = System.Drawing.Color.Black;
            this.TransactionNameRF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransactionNameRF.Border.LeftColor = System.Drawing.Color.Black;
            this.TransactionNameRF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransactionNameRF.Border.RightColor = System.Drawing.Color.Black;
            this.TransactionNameRF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransactionNameRF.Border.TopColor = System.Drawing.Color.Black;
            this.TransactionNameRF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransactionNameRF.DataField = "TransactionsDivName";
            this.TransactionNameRF.Height = 0.188F;
            this.TransactionNameRF.Left = 6.06F;
            this.TransactionNameRF.MultiLine = false;
            this.TransactionNameRF.Name = "TransactionNameRF";
            this.TransactionNameRF.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.TransactionNameRF.Text = null;
            this.TransactionNameRF.Top = 0.0625F;
            this.TransactionNameRF.Width = 0.5F;
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
            this.textBox33.DataField = "InputDay";
            this.textBox33.Height = 0.188F;
            this.textBox33.Left = 3.123F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox33.Text = "2008/11/05";
            this.textBox33.Top = 0.0625F;
            this.textBox33.Width = 0.563F;
            // 
            // textBox24
            // 
            this.textBox24.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.RightColor = System.Drawing.Color.Black;
            this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.TopColor = System.Drawing.Color.Black;
            this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.DataField = "SupplierCd";
            this.textBox24.Height = 0.188F;
            this.textBox24.Left = 0F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "ゴシック; vertical-align: top; ";
            this.textBox24.Text = "123456";
            this.textBox24.Top = 0.0625F;
            this.textBox24.Width = 0.56F;
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
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.textBox10.DataField = "PartySaleSlipNum";
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 4.2475F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox10.Text = null;
            this.textBox10.Top = 0.0625F;
            this.textBox10.Width = 1.8125F;
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
            this.textBox14.DataField = "SupplierSlipNote1";
            this.textBox14.Height = 0.188F;
            this.textBox14.Left = 7.2475F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox14.Text = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほ";
            this.textBox14.Top = 0.0625F;
            this.textBox14.Width = 3.2F;
            // 
            // StockAddUpADate
            // 
            this.StockAddUpADate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.RightColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.TopColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.DataField = "StockAddUpADate";
            this.StockAddUpADate.Height = 0.188F;
            this.StockAddUpADate.Left = 3.685F;
            this.StockAddUpADate.MultiLine = false;
            this.StockAddUpADate.Name = "StockAddUpADate";
            this.StockAddUpADate.OutputFormat = resources.GetString("StockAddUpADate.OutputFormat");
            this.StockAddUpADate.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.StockAddUpADate.Text = "2008/11/05";
            this.StockAddUpADate.Top = 0.0625F;
            this.StockAddUpADate.Width = 0.563F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label26,
            this.textBox8,
            this.Line41,
            this.textBox2,
            this.TitFt_StockPriceConsTax,
            this.TitFt_SuppCTaxLayCd,
            this.TitFt_TaxationCode});
            this.TitleFooter.Height = 0.6354167F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.BeforePrint += new System.EventHandler(this.TitleFooter_BeforePrint);
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
            this.label26.Height = 0.188F;
            this.label26.HyperLink = null;
            this.label26.Left = 4.875F;
            this.label26.Name = "label26";
            this.label26.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label26.Text = "伝票計";
            this.label26.Top = 0.063F;
            this.label26.Width = 0.7F;
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
            this.textBox8.DataField = "StockPriceTaxExc";
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 7.0625F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.SummaryGroup = "TitleHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "123,456,123,456,789";
            this.textBox8.Top = 0.063F;
            this.textBox8.Width = 1F;
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
            this.textBox2.DataField = "ArrivalRemainPrice";
            this.textBox2.Height = 0.188F;
            this.textBox2.Left = 8.8125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryGroup = "TitleHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "12,345,678,901";
            this.textBox2.Top = 0.063F;
            this.textBox2.Width = 0.8F;
            // 
            // TitFt_StockPriceConsTax
            // 
            this.TitFt_StockPriceConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.TitFt_StockPriceConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_StockPriceConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.TitFt_StockPriceConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_StockPriceConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.TitFt_StockPriceConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_StockPriceConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.TitFt_StockPriceConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_StockPriceConsTax.DataField = "StockPriceConsTax";
            this.TitFt_StockPriceConsTax.Height = 0.188F;
            this.TitFt_StockPriceConsTax.Left = 9.6125F;
            this.TitFt_StockPriceConsTax.MultiLine = false;
            this.TitFt_StockPriceConsTax.Name = "TitFt_StockPriceConsTax";
            this.TitFt_StockPriceConsTax.OutputFormat = resources.GetString("TitFt_StockPriceConsTax.OutputFormat");
            this.TitFt_StockPriceConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.TitFt_StockPriceConsTax.SummaryGroup = "TitleHeader";
            this.TitFt_StockPriceConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TitFt_StockPriceConsTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TitFt_StockPriceConsTax.Text = "123,456,789,012";
            this.TitFt_StockPriceConsTax.Top = 0.063F;
            this.TitFt_StockPriceConsTax.Width = 0.8F;
            // 
            // TitFt_SuppCTaxLayCd
            // 
            this.TitFt_SuppCTaxLayCd.Border.BottomColor = System.Drawing.Color.Black;
            this.TitFt_SuppCTaxLayCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_SuppCTaxLayCd.Border.LeftColor = System.Drawing.Color.Black;
            this.TitFt_SuppCTaxLayCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_SuppCTaxLayCd.Border.RightColor = System.Drawing.Color.Black;
            this.TitFt_SuppCTaxLayCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_SuppCTaxLayCd.Border.TopColor = System.Drawing.Color.Black;
            this.TitFt_SuppCTaxLayCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_SuppCTaxLayCd.DataField = "SuppCTaxLayCd";
            this.TitFt_SuppCTaxLayCd.Height = 0.1875F;
            this.TitFt_SuppCTaxLayCd.Left = 6.875F;
            this.TitFt_SuppCTaxLayCd.MultiLine = false;
            this.TitFt_SuppCTaxLayCd.Name = "TitFt_SuppCTaxLayCd";
            this.TitFt_SuppCTaxLayCd.OutputFormat = resources.GetString("TitFt_SuppCTaxLayCd.OutputFormat");
            this.TitFt_SuppCTaxLayCd.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.TitFt_SuppCTaxLayCd.Text = null;
            this.TitFt_SuppCTaxLayCd.Top = 0.3125F;
            this.TitFt_SuppCTaxLayCd.Visible = false;
            this.TitFt_SuppCTaxLayCd.Width = 0.75F;
            // 
            // TitFt_TaxationCode
            // 
            this.TitFt_TaxationCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TitFt_TaxationCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_TaxationCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TitFt_TaxationCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_TaxationCode.Border.RightColor = System.Drawing.Color.Black;
            this.TitFt_TaxationCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_TaxationCode.Border.TopColor = System.Drawing.Color.Black;
            this.TitFt_TaxationCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitFt_TaxationCode.DataField = "TaxationCode";
            this.TitFt_TaxationCode.Height = 0.1875F;
            this.TitFt_TaxationCode.Left = 7.625F;
            this.TitFt_TaxationCode.MultiLine = false;
            this.TitFt_TaxationCode.Name = "TitFt_TaxationCode";
            this.TitFt_TaxationCode.OutputFormat = resources.GetString("TitFt_TaxationCode.OutputFormat");
            this.TitFt_TaxationCode.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.TitFt_TaxationCode.Text = null;
            this.TitFt_TaxationCode.Top = 0.3125F;
            this.TitFt_TaxationCode.Visible = false;
            this.TitFt_TaxationCode.Width = 0.75F;
            // 
            // SortDiv3Header
            // 
            this.SortDiv3Header.CanShrink = true;
            this.SortDiv3Header.DataField = "StockAgentCode";
            this.SortDiv3Header.Height = 0F;
            this.SortDiv3Header.Name = "SortDiv3Header";
            // 
            // SortDiv3Footer
            // 
            this.SortDiv3Footer.CanShrink = true;
            this.SortDiv3Footer.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox35,
            this.line13,
            this.textBox58,
            this.textBox22});
            this.SortDiv3Footer.Height = 0.2916667F;
            this.SortDiv3Footer.KeepTogether = true;
            this.SortDiv3Footer.Name = "SortDiv3Footer";
            this.SortDiv3Footer.Visible = false;
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
            this.textBox35.Height = 0.188F;
            this.textBox35.Left = 4.875F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.textBox35.Text = "担当者計";
            this.textBox35.Top = 0.063F;
            this.textBox35.Width = 0.7F;
            // 
            // line13
            // 
            this.line13.Border.BottomColor = System.Drawing.Color.Black;
            this.line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.LeftColor = System.Drawing.Color.Black;
            this.line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.RightColor = System.Drawing.Color.Black;
            this.line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.TopColor = System.Drawing.Color.Black;
            this.line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Height = 0F;
            this.line13.Left = 0F;
            this.line13.LineWeight = 2F;
            this.line13.Name = "line13";
            this.line13.Top = 0F;
            this.line13.Width = 10.8125F;
            this.line13.X1 = 0F;
            this.line13.X2 = 10.8125F;
            this.line13.Y1 = 0F;
            this.line13.Y2 = 0F;
            // 
            // textBox58
            // 
            this.textBox58.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.RightColor = System.Drawing.Color.Black;
            this.textBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.TopColor = System.Drawing.Color.Black;
            this.textBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.DataField = "StockPriceTaxExc";
            this.textBox58.Height = 0.188F;
            this.textBox58.Left = 7.0625F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox58.SummaryGroup = "SortDiv3Header";
            this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox58.Text = "123,456,123,456,789";
            this.textBox58.Top = 0.063F;
            this.textBox58.Width = 1F;
            // 
            // textBox22
            // 
            this.textBox22.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.RightColor = System.Drawing.Color.Black;
            this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.TopColor = System.Drawing.Color.Black;
            this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.DataField = "ArrivalRemainPrice";
            this.textBox22.Height = 0.188F;
            this.textBox22.Left = 8.8125F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox22.SummaryGroup = "SortDiv3Header";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox22.Text = "12,345,678,901";
            this.textBox22.Top = 0.0625F;
            this.textBox22.Width = 0.8F;
            // 
            // SortDiv2Header
            // 
            this.SortDiv2Header.CanShrink = true;
            this.SortDiv2Header.Height = 0F;
            this.SortDiv2Header.Name = "SortDiv2Header";
            // 
            // SortDiv2Footer
            // 
            this.SortDiv2Footer.CanShrink = true;
            this.SortDiv2Footer.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSort2_Title,
            this.line11,
            this.textBox52,
            this.textBox13});
            this.SortDiv2Footer.Height = 0.3125F;
            this.SortDiv2Footer.KeepTogether = true;
            this.SortDiv2Footer.Name = "SortDiv2Footer";
            // 
            // txtSort2_Title
            // 
            this.txtSort2_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSort2_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort2_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSort2_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort2_Title.Border.RightColor = System.Drawing.Color.Black;
            this.txtSort2_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort2_Title.Border.TopColor = System.Drawing.Color.Black;
            this.txtSort2_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort2_Title.Height = 0.188F;
            this.txtSort2_Title.Left = 4.875F;
            this.txtSort2_Title.MultiLine = false;
            this.txtSort2_Title.Name = "txtSort2_Title";
            this.txtSort2_Title.OutputFormat = resources.GetString("txtSort2_Title.OutputFormat");
            this.txtSort2_Title.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.txtSort2_Title.Text = null;
            this.txtSort2_Title.Top = 0.063F;
            this.txtSort2_Title.Width = 0.7F;
            // 
            // line11
            // 
            this.line11.Border.BottomColor = System.Drawing.Color.Black;
            this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.LeftColor = System.Drawing.Color.Black;
            this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.RightColor = System.Drawing.Color.Black;
            this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.TopColor = System.Drawing.Color.Black;
            this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Height = 0F;
            this.line11.Left = 0F;
            this.line11.LineWeight = 2F;
            this.line11.Name = "line11";
            this.line11.Top = 0F;
            this.line11.Width = 10.8125F;
            this.line11.X1 = 0F;
            this.line11.X2 = 10.8125F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0F;
            // 
            // textBox52
            // 
            this.textBox52.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.RightColor = System.Drawing.Color.Black;
            this.textBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.TopColor = System.Drawing.Color.Black;
            this.textBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.DataField = "StockPriceTaxExc";
            this.textBox52.Height = 0.188F;
            this.textBox52.Left = 7.0625F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox52.SummaryGroup = "SortDiv2Header";
            this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox52.Text = "123,456,123,456,789";
            this.textBox52.Top = 0.063F;
            this.textBox52.Width = 1F;
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
            this.textBox13.DataField = "ArrivalRemainPrice";
            this.textBox13.Height = 0.188F;
            this.textBox13.Left = 8.8125F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.SummaryGroup = "SortDiv2Header";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "12,345,678,901";
            this.textBox13.Top = 0.0625F;
            this.textBox13.Width = 0.8F;
            // 
            // SortDiv1Header
            // 
            this.SortDiv1Header.CanShrink = true;
            this.SortDiv1Header.Height = 0F;
            this.SortDiv1Header.Name = "SortDiv1Header";
            // 
            // SortDiv1Footer
            // 
            this.SortDiv1Footer.CanShrink = true;
            this.SortDiv1Footer.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSort1_Title,
            this.line10,
            this.textBox46,
            this.textBox6});
            this.SortDiv1Footer.Height = 0.2916667F;
            this.SortDiv1Footer.KeepTogether = true;
            this.SortDiv1Footer.Name = "SortDiv1Footer";
            // 
            // txtSort1_Title
            // 
            this.txtSort1_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Border.RightColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Border.TopColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Height = 0.188F;
            this.txtSort1_Title.Left = 4.875F;
            this.txtSort1_Title.MultiLine = false;
            this.txtSort1_Title.Name = "txtSort1_Title";
            this.txtSort1_Title.OutputFormat = resources.GetString("txtSort1_Title.OutputFormat");
            this.txtSort1_Title.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.txtSort1_Title.Text = null;
            this.txtSort1_Title.Top = 0.063F;
            this.txtSort1_Title.Width = 0.7F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0F;
            this.line10.Left = 0F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 10.8125F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.8125F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
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
            this.textBox46.DataField = "StockPriceTaxExc";
            this.textBox46.Height = 0.188F;
            this.textBox46.Left = 7.0625F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryGroup = "SortDiv1Header";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "123,456,123,456,789";
            this.textBox46.Top = 0.063F;
            this.textBox46.Width = 1F;
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
            this.textBox6.DataField = "ArrivalRemainPrice";
            this.textBox6.Height = 0.188F;
            this.textBox6.Left = 8.8125F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.SummaryGroup = "SortDiv1Header";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "12,345,678,901";
            this.textBox6.Top = 0.0625F;
            this.textBox6.Width = 0.8F;
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
            this.reportFooter1.Visible = false;
            this.reportFooter1.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox27,
            this.textBox28,
            this.label1,
            this.line4});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.3020833F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.label1.Height = 0.188F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label1.Text = "拠点";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.3F;
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
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.textBox39,
            this.label43,
            this.label44,
            this.label45,
            this.txtCntArrivalSl_Sc,
            this.txtCntReturnSl_Sc,
            this.label46,
            this.label47,
            this.textBox64,
            this.txtCntTotal_Sc,
            this.label56,
            this.textBox40});
            this.SectionFooter.Height = 0.6979167F;
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
            this.Line45.Width = 10.8125F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8125F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
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
            this.textBox39.Height = 0.188F;
            this.textBox39.Left = 4.875F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.textBox39.Text = "拠点計";
            this.textBox39.Top = 0.0625F;
            this.textBox39.Width = 0.7F;
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
            this.label43.Height = 0.125F;
            this.label43.HyperLink = null;
            this.label43.Left = 5.625F;
            this.label43.MultiLine = false;
            this.label43.Name = "label43";
            this.label43.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label43.Text = "入　荷";
            this.label43.Top = 0.0625F;
            this.label43.Width = 0.563F;
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
            this.label44.Height = 0.188F;
            this.label44.HyperLink = null;
            this.label44.Left = 5.625F;
            this.label44.MultiLine = false;
            this.label44.Name = "label44";
            this.label44.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label44.Text = "合　計";
            this.label44.Top = 0.4375F;
            this.label44.Width = 0.563F;
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
            this.label45.Height = 0.125F;
            this.label45.HyperLink = null;
            this.label45.Left = 5.625F;
            this.label45.MultiLine = false;
            this.label45.Name = "label45";
            this.label45.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label45.Text = "返　品";
            this.label45.Top = 0.25F;
            this.label45.Width = 0.563F;
            // 
            // txtCntArrivalSl_Sc
            // 
            this.txtCntArrivalSl_Sc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Sc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Sc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Sc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Sc.Border.RightColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Sc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Sc.Border.TopColor = System.Drawing.Color.Black;
            this.txtCntArrivalSl_Sc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntArrivalSl_Sc.Height = 0.125F;
            this.txtCntArrivalSl_Sc.Left = 6.25F;
            this.txtCntArrivalSl_Sc.MultiLine = false;
            this.txtCntArrivalSl_Sc.Name = "txtCntArrivalSl_Sc";
            this.txtCntArrivalSl_Sc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtCntArrivalSl_Sc.SummaryGroup = "SectionHeader";
            this.txtCntArrivalSl_Sc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtCntArrivalSl_Sc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtCntArrivalSl_Sc.Text = "123";
            this.txtCntArrivalSl_Sc.Top = 0.0625F;
            this.txtCntArrivalSl_Sc.Width = 0.213F;
            // 
            // txtCntReturnSl_Sc
            // 
            this.txtCntReturnSl_Sc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Sc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Sc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Sc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Sc.Border.RightColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Sc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Sc.Border.TopColor = System.Drawing.Color.Black;
            this.txtCntReturnSl_Sc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntReturnSl_Sc.Height = 0.125F;
            this.txtCntReturnSl_Sc.Left = 6.25F;
            this.txtCntReturnSl_Sc.MultiLine = false;
            this.txtCntReturnSl_Sc.Name = "txtCntReturnSl_Sc";
            this.txtCntReturnSl_Sc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtCntReturnSl_Sc.SummaryGroup = "SectionHeader";
            this.txtCntReturnSl_Sc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtCntReturnSl_Sc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtCntReturnSl_Sc.Text = "123";
            this.txtCntReturnSl_Sc.Top = 0.25F;
            this.txtCntReturnSl_Sc.Width = 0.213F;
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
            this.label46.Height = 0.125F;
            this.label46.HyperLink = null;
            this.label46.Left = 6.5F;
            this.label46.MultiLine = false;
            this.label46.Name = "label46";
            this.label46.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label46.Text = "枚";
            this.label46.Top = 0.0625F;
            this.label46.Width = 0.25F;
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
            this.label47.Height = 0.125F;
            this.label47.HyperLink = null;
            this.label47.Left = 6.5F;
            this.label47.MultiLine = false;
            this.label47.Name = "label47";
            this.label47.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label47.Text = "枚";
            this.label47.Top = 0.25F;
            this.label47.Width = 0.25F;
            // 
            // textBox64
            // 
            this.textBox64.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.RightColor = System.Drawing.Color.Black;
            this.textBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.TopColor = System.Drawing.Color.Black;
            this.textBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.DataField = "StockPriceTaxExc";
            this.textBox64.Height = 0.188F;
            this.textBox64.Left = 7.0625F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.SummaryGroup = "SectionHeader";
            this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox64.Text = "123,456,123,456,789";
            this.textBox64.Top = 0.0625F;
            this.textBox64.Width = 1F;
            // 
            // txtCntTotal_Sc
            // 
            this.txtCntTotal_Sc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCntTotal_Sc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Sc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCntTotal_Sc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Sc.Border.RightColor = System.Drawing.Color.Black;
            this.txtCntTotal_Sc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Sc.Border.TopColor = System.Drawing.Color.Black;
            this.txtCntTotal_Sc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCntTotal_Sc.Height = 0.125F;
            this.txtCntTotal_Sc.Left = 6.25F;
            this.txtCntTotal_Sc.MultiLine = false;
            this.txtCntTotal_Sc.Name = "txtCntTotal_Sc";
            this.txtCntTotal_Sc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtCntTotal_Sc.SummaryGroup = "SectionHeader";
            this.txtCntTotal_Sc.Text = "123";
            this.txtCntTotal_Sc.Top = 0.4375F;
            this.txtCntTotal_Sc.Width = 0.213F;
            // 
            // label56
            // 
            this.label56.Border.BottomColor = System.Drawing.Color.Black;
            this.label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.LeftColor = System.Drawing.Color.Black;
            this.label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.RightColor = System.Drawing.Color.Black;
            this.label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.TopColor = System.Drawing.Color.Black;
            this.label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Height = 0.125F;
            this.label56.HyperLink = null;
            this.label56.Left = 6.5F;
            this.label56.MultiLine = false;
            this.label56.Name = "label56";
            this.label56.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label56.Text = "枚";
            this.label56.Top = 0.4375F;
            this.label56.Width = 0.25F;
            // 
            // textBox40
            // 
            this.textBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.RightColor = System.Drawing.Color.Black;
            this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.TopColor = System.Drawing.Color.Black;
            this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.DataField = "ArrivalRemainPrice";
            this.textBox40.Height = 0.188F;
            this.textBox40.Left = 8.8125F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.SummaryGroup = "SectionHeader";
            this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox40.Text = "12,345,678,901";
            this.textBox40.Top = 0.0625F;
            this.textBox40.Width = 0.8F;
            // 
            // DCKOU02303P_01A4C
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
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SortDiv3Header);
            this.Sections.Add(this.SortDiv2Header);
            this.Sections.Add(this.SortDiv1Header);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.SortDiv1Footer);
            this.Sections.Add(this.SortDiv2Footer);
            this.Sections.Add(this.SortDiv3Footer);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.DCKOU02303P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_SuppCTaxLayCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_TaxationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTitle_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntArrivalSl_Ttl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntReturnSl_Ttl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntTotal_Ttl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionNameRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAddUpADate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitFt_StockPriceConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitFt_SuppCTaxLayCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitFt_TaxationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort2_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntArrivalSl_Sc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntReturnSl_Sc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCntTotal_Sc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
