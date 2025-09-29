using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Data;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 在庫調整確認表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 在庫調整確認表のフォームクラスです。</br>
	/// <br>Programmer	: 97036 amami</br>
	/// <br>Date		: 2007.03.15</br>
    /// <br>UpdateNote  : 2007.10.04 980035 金沢 貞義</br>
    /// <br>              ・ DC.NS対応</br>
    /// <br>            : 2009/03/10        照田 貴志　不具合対応[12263]</br>
    /// <br>Update Note : 2010/11/15 tianjw</br>
    /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
    /// <br>Update Note : 2011/11/15 xupz</br>
    /// <br>            ・redmine#7762 在庫仕入確認表／担当者の出力について</br>
    /// </remarks>
	public class MAZAI02052P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
    {
        # region Constructor
        /// <summary>
		/// 在庫調整確認表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 在庫調整確認表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		public MAZAI02052P_02A4C()
		{
			InitializeComponent();
        }
        # endregion

        # region Dispose
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
						if (this._hedrpt != null)
						{
							this._hedrpt.Dispose();
						}
						if (this._fotrpt != null)
						{
							this._fotrpt.Dispose();
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
        # endregion

        # region Private Member
        private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private ArrayList			 _otherDataList;				// その他データ
		private ConfirmStockAdjustListCndtn _extrInfo;				// 抽出条件クラス

		// その他データ格納項目
		private int					 _printCount;					// ページ数カウント用
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル

        //--- ADD 2008.07.07 ---------->>>>>
        private string               _beforeSectionCode;
        private string               _beforeWarehouseCode;
        //--- ADD 2008.07.07 ----------<<<<<

		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _hedrpt   = null;
		// フッターレポート作成
		ListCommon_PageFooter _fotrpt = null;
		//Dispose判定フラグ
		Boolean disposed = false;

        // サプレス用バッファ(調整日付)
		private string _adjustDateBuff = ""; 
        // サプレス用バッファ(調整伝票番号)
        private string _stockAdjustSlipNoBuff = "";
        private GroupHeader WarehouseHeader;
        private GroupFooter WarehouseFooter;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private Line line6;
        private TextBox BfStockUnitPrice_TextBox;
        private Label BfStockUnitPrice_Title;
        private TextBox ListPrice_TextBox;
        private Label ListPrice_Title;
        private Line line7;
        private Label label1;
        private Line line4;
        private TextBox SectionCode_TextBox;
        private TextBox SectionGuideNm;
        private TextBox WarehouseCode_TextBox;
        private TextBox StockAdjustSlipNo_TextBox;
        private TextBox AdjustDate_TextBox;
        private TextBox InputAgenNm_TextBox;
        private TextBox MakerName_TextBox;
        private TextBox WarehouseName_TextBox;
        private TextBox MakerCode_TextBox;
        private TextBox InputAgenCd_TextBox;
        private Line Line2;
        private Label InputDay_Title;
        private TextBox InputDay_TextBox;
        private Line line8;
        private Label AcPaySlipCd_Title;
        private TextBox AcPaySlipCd_TextBox;
        // --- ADD 2010/11/15 ------------->>>>>
        private TextBox WarehouseCode_TextBox2;
        private TextBox WarehouseName_TextBox2;
        private TextBox WarehouseShelfNo_TextBox2;
        private TextBox SectionCode_TextBox2;
        private TextBox SectionGuideNm2;
        private Line line5;
        private Label OutputSort;
        // --- ADD 2010/11/15 -------------<<<<<
        // サプレス用バッファ(入力担当者)
		private string _inputAgenNmBuff = "";
        // サプレス用バッファ(メーカー)
//        private string _makerBuff = "";
        // サプレス用バッファ(商品コード)
//        private string _goodsCodeBuff = "";
        // サプレス用バッファ(商品名)
//        private string _GoodsNameBuff = "";
		# endregion

		# region IPrintActiveReportTypeList インターフェース
		/// <summary>
		/// ページヘッダソート順タイトル項目
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set { _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set { _extraCondHeadOutDiv = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set { this._extraConditions = value; }
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set { this._pageFooterOutCode = value; }
		}

		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set { this._pageFooters = value; }
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo = value;
				this._extrInfo = (ConfirmStockAdjustListCndtn)this._printInfo.jyoken;
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
			set { this._pageHeaderSubtitle = value; }
		}

		/// <summary>
		/// 印刷件数カウントアップイベント
		/// </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;
		# endregion

		# region IPrintActiveReportTypeCommon インターフェース
		/// <summary>
		/// 背景透過設定値プロパティ
		/// </summary>
		public int WatermarkMode
		{
			get{return 0;}
			set{}
		}
		# endregion

		#region Private Method
        # region レポート要素出力設定
		/// <summary>
		/// レポート要素出力設定
		/// </summary>
 		/// <remarks>
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
            /* --- DEL 2008/10/07 全社かどうかに関わらず拠点、拠点計を印字 --------------------------------------->>>>>
            // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
            //// 拠点オプションチェック
	        //if (this._extrInfo.IsOptSection)
			//{
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._extrInfo.SecCodeList.Length < 2 ) || (this._extrInfo.IsSelectAllSection ))					
            //	{                
            //		SectionHeader.DataField = "";
            //		SectionHeader.Visible = false;
            //		SectionFooter.Visible = false;
            //	}
            //	else
            //	{					
            //        SectionHeader.DataField = MAZAI02054EA.ct_Col_SectionCode;
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

            // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            if ((this._extrInfo.SectionCodeList.Length < 2) || (this._extrInfo.IsSelectAllSection))
            {
                SectionHeader.DataField = "";
                //SectionHeader.Visible = false;
                SectionFooter.Visible = false;
            }
            else
            {
                SectionHeader.DataField = MAZAI02054EA.ct_Col_SectionCode;
                SectionHeader.Visible = true;
                SectionFooter.Visible = true;
            }
            // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
            --- DEL 2008/10/07 --------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/07 ----------------------------------------------------------------------------->>>>>
            SectionHeader.DataField = MAZAI02054EA.ct_Col_SectionCode;
            SectionHeader.Visible = true;
            SectionFooter.Visible = true;
            // --- ADD 2008/10/07 -----------------------------------------------------------------------------<<<<<

            //--- DEL 2008/07/04 ---------->>>>>
            // 全社選択されている場合は拠点名称をを表示
            //if (this._extrInfo.IsSelectAllSection)
            //{
            //    this.SectionGuideName_Title.Visible = true;
            //    this.SectionGuideNm_TextBox.Visible = true;
            //}
            //else
            //{
            //    this.SectionGuideName_Title.Visible = false;
            //    this.SectionGuideNm_TextBox.Visible = false;
            //}
            //--- DEL 2008/07/04 ----------<<<<<

			// 調整伝票番号ヘッダー
			StockAdjustSlipNoHeader.DataField = MAZAI02054EA.ct_Col_StockAdjustSlipNo;

            WarehouseHeader.DataField = MAZAI02054EA.ct_Col_WarehouseName;

            // ---------- ADD 2010/11/15 -------------------->>>>>
            // 棚番順の場合
            if (this._extrInfo.OutputSort == 1)
            {
                // TitleHeader
                // 拠点
                this.label1.Left = 1.0F;
                this.label1.Top = 0.2291667F;

                // 倉庫
                this.WarehouseCode_Title.Top = 0.04166668F;

                // 棚番 
                this.WarehouseShelfNo_Title.Left = 0F;
                this.WarehouseShelfNo_Title.Top = 0.2291667F;

                // 明細備考
                this.SlipNote_Title.Left = 8.25F;


                SectionHeader.Visible = false;
                SectionHeader.DataField = "";
                WarehouseHeader.Visible = true;

                // 拠点
                this.SectionCode_TextBox2.Left = 1.0F;
                this.SectionCode_TextBox2.Top = 0.031F;
                this.SectionGuideNm2.Left = 1.344F;
                this.SectionGuideNm2.Top = 0.031F;

                // 倉庫
                this.WarehouseCode_TextBox.Visible = false;
                this.WarehouseName_TextBox.Visible = false;

                // 棚番 
                this.WarehouseShelfNo_TextBox2.Left = 0.031F;
                this.WarehouseShelfNo_TextBox2.Top = 0.031F;

                this.WarehouseShelfNo_TextBox.Visible = false;

                // 明細備考
                this.DtlNote_TextBox.Left = 8.25F;

                // 伝票計
                this.StockAdjustSlipNoFooter.Visible = false;

                // 拠点計
                this.SectionFooter.Visible = false;

                // 改頁(しない)
                if (this._extrInfo.ChangePage == 1)
                {
                    this.WarehouseHeader.NewPage = NewPage.None;
                }
            }
            // 仕入日順の場合
            else
            {
                WarehouseHeader.Visible = false;

                // 拠点
                this.SectionCode_TextBox2.Visible = false;
                this.SectionGuideNm2.Visible = false;

                // 棚番
                this.WarehouseShelfNo_TextBox2.Visible = false;
            }
            // ---------- ADD 2010/11/15 --------------------<<<<<

			// サブタイトル
            //SubTitle.Text = "( " + this._pageHeaderSubtitle + " )";           // DEL 2008.07.08
        }
        # endregion

        # region グループサプレス処理
        /// <summary>
        /// グループサプレス処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス処理を行います</br>
        /// <br>Programer : 97036 amami</br>
        /// <br>Date      : 2007.03.15</br>
        /// </remarks>    
        private void SetOfGroupSuppres()
        {
			try
			{
                this.AdjustDate_TextBox.Visible = true;
				this.StockAdjustSlipNo_TextBox.Visible = true;
				this.InputAgenNm_TextBox.Visible = true;
//				this.MakerName_TextBox.Visible = true;
//				this.GoodsCode_TextBox.Visible = true;
//				this.GoodsName_TextBox.Visible = true;

                //--- DEL 2008/07/08 ---------->>>>>
                //// グループサプレス処理(調整日付)
                //if ((this.AdjustDate_TextBox.Text == null) ||
                //    (this.AdjustDate_TextBox.Text.CompareTo(this._adjustDateBuff) == 0))
                //{
                //    this.AdjustDate_TextBox.Visible = false;
                //}
                //else
                //{
                //    return;
                //}
                //// グループサプレス処理(調整伝票番号)
                //if ((this.StockAdjustSlipNo_TextBox.Text == null) ||
                //    (this.StockAdjustSlipNo_TextBox.Text.CompareTo(this._stockAdjustSlipNoBuff) == 0))
                //{
                //    this.StockAdjustSlipNo_TextBox.Visible = false;
                //}
                //else
                //{
                //    return;
                //}
                //// グループサプレス処理(入力担当者)
                //if ((this.InputAgenNm_TextBox.Text == null) ||
                //    (this.InputAgenNm_TextBox.Text.CompareTo(this._inputAgenNmBuff) == 0))
                //{
                //    this.InputAgenNm_TextBox.Visible = false;
                //}
                //else
                //{
                //    return;
                //}
                //--- DEL 2008/07/08 ---------->>>>>
/*
                                // グループサプレス処理(メーカー)
                                if ((this.MakerName_TextBox.Text == null) ||
                                    (this.MakerName_TextBox.Text.CompareTo(this._makerBuff) == 0))
                                {
                                    this.MakerName_TextBox.Visible = false;
                                }
                                else
                                {
                                    return;
                                }
                                // グループサプレス処理(商品コード)
                                if ((this.GoodsCode_TextBox.Text == null) ||
                                    (this.GoodsCode_TextBox.Text.CompareTo(this._goodsCodeBuff) == 0))
                                {
                                    this.GoodsCode_TextBox.Visible = false;
                                }
                                else
                                {
                                    return;
                                }
                                // グループサプレス処理(商品名称)
                                if ((this.GoodsName_TextBox.Text == null) ||
                                    (this.GoodsName_TextBox.Text.CompareTo(this._GoodsNameBuff) == 0))
                                {
                                    this.GoodsName_TextBox.Visible = false;
                                }
                                else
                                {
                                    return;
                                }
                */
			}
			finally
			{
                this._adjustDateBuff = AdjustDate_TextBox.Text;
				this._stockAdjustSlipNoBuff = StockAdjustSlipNo_TextBox.Text;
				this._inputAgenNmBuff = InputAgenNm_TextBox.Text;
//				this._makerBuff = MakerName_TextBox.Text;
//				this._goodsCodeBuff = GoodsCode_TextBox.Text;
//				this._GoodsNameBuff = GoodsName_TextBox.Text;

				// 調整伝票番号が非表示の時(1行目ではない時)は伝票備考、拠点を空にする
				// ※同一伝票内は伝票備考、拠点は全て同一の為
				if (this.StockAdjustSlipNo_TextBox.Visible == false)
				{
                    //--- DEL 2008/07/04 ---------->>>>>
                    //this.SlipNote_TextBox.Text = string.Empty;
                    //this.SectionGuideNm_TextBox.Text = string.Empty;
                    //--- DEL 2008/07/04 ----------<<<<<
                }
			}
		}
        # endregion

		# region 明細項目移動処理
		/// <summary>
        /// 明細項目移動処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : 明細項目の移動処理を行います</br>
        /// <br>Programer : 97036 amami</br>
        /// <br>Date      : 2007.03.15</br>
        /// </remarks>    
        private void MoveDetailItem()
        {
            //--- DEL 2008/07/04 ---------->>>>>
            //// 伝票番号が前回番号と違い、伝票備考が入力されている時
            //if ((this.StockAdjustSlipNo_TextBox.Text.CompareTo(this._stockAdjustSlipNoBuff) != 0) &&
            //    (this.SlipNote_TextBox.Text != string.Empty))
            //{
            //    this.SlipNote_TextBox.Visible = true;
            //}
            //else
            //{
            //    this.SlipNote_TextBox.Visible = false;
            //}
            //--- DEL 2008/07/04 ----------<<<<<
        }
		# endregion

		# region バッファクリア処理
		/// <summary>
        /// サプレス用バッファクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス用のバッファを初期化します</br>
        /// <br>Programer : 97036 amami</br>
        /// <br>Date      : 2007.03.15</br>
        /// </remarks>
        private void BufferClear()
        {
            // サプレス用バッファ(調整日付)
			this._adjustDateBuff = ""; 
		    // サプレス用バッファ(調整伝票番号)
			this._stockAdjustSlipNoBuff = ""; 
	        // サプレス用バッファ(入力担当者)
			this._inputAgenNmBuff = "";
			// サプレス用バッファ(メーカー)
//			this._makerBuff = "";
		    // サプレス用バッファ(商品コード)
//			this._goodsCodeBuff = "";
	        // サプレス用バッファ(商品名)
//			this._GoodsNameBuff = "";
        }
        # endregion
        # endregion

        # region Control Event
        #region PageHeader_Formatイベント
        /// <summary>
		/// PageHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
            // ---------- ADD 2010/11/15 --------------->>>>>
            if (this._extrInfo.OutputSort == 0)
            {
                this.OutputSort.Text = "[仕入日順]";
            }
            else
            {
                this.OutputSort.Text = "[棚番順]";
            }
            // ---------- ADD 2010/11/15 ---------------<<<<<

			// 作成日付           
            // 現在の時刻を取得
			DateTime now = DateTime.Now;
            // 作成日(西暦で表示)
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);			
			// 作成時間
			this.PrintTime.Text   = now.ToString("HH:mm");
        }
        #endregion

        # region ExtraHeader_Formatイベント
        /// <summary>
		/// ExtraHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
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
			
			// ヘッダーサブレポート作成
			if(_hedrpt == null)
            {
				this._hedrpt   = new ListCommon_ExtraHeader();
            }
            else
			{
				this._hedrpt.DataSource = null;
			}

            // 拠点オプション有無判定
            // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
            //if (this._extrInfo.IsOptSection)
			//{
            // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                // 全社選択のときは、固定で「全社」と設定する
                if (this._extrInfo.IsSelectAllSection)
				{
                    //this._hedrpt.SectionCondition.Text = "調整拠点  ：全社"; // DEL 2008/09/26
                    this._hedrpt.SectionCondition.Text = "拠点  ：全社";
				}
				else
				{
                    //this._hedrpt.SectionCondition.Text = "調整拠点  ：" + this.SectionGuideNm.Text; // DEL 2008/09/26
                    this._hedrpt.SectionCondition.Text = "拠点  ：" + this.SectionGuideNm.Text;
				}
            // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
            //} 
			//else 
			//{
			//	this._hedrpt.SectionCondition.Text = "";
			//}
            // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
			
			// 抽出条件印字項目設定
			this._hedrpt.ExtraConditions         = this._extraConditions;
			
			this.Header_SubReport.Report = this._hedrpt;
		}
        # endregion

        # region PageFooter_Formatイベント
        /// <summary>
		/// PageFooter_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッターレポート作成
                if (this._fotrpt == null)
                    this._fotrpt = new ListCommon_PageFooter();

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    this._fotrpt.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this._fotrpt.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = this._fotrpt;
            }
        }
        # endregion

        # region ReportStartイベント
        /// <summary>
		/// MAZAI02052P_01A4C_ReportStartイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : レポートの設定をするイベントです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void MAZAI02052P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			this.SetOfReportMembersOutput();
        }
        # endregion

        # region Detail_AfterPrintイベント
        /// <summary>
		/// Detail_AfterPrintイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2007.03.15</br>
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
        # endregion

        # region Detail_BeforePrintイベント
        /// <summary>
		/// Detail_BeforePrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// グループサプレス処理
			this.SetOfGroupSuppres();
			
			// レポート用文字列編集処理（連帳帳票用）
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        # endregion

        # region Detail_Formatイベント
        /// <summary>
		/// Detail_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			// 明細項目移動処理
			this.MoveDetailItem();
		}
        # endregion

        # region PageEndイベント
        /// <summary>
		/// PageEndイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページが終わる時に発生するイベントです。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void MAZAI02052P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
			// サプレス用バッファクリア処理
			this.BufferClear();
		}

        # endregion
        # endregion

        #region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label PrintDate_Title;
		private DataDynamics.ActiveReports.TextBox PrintDate;
		private DataDynamics.ActiveReports.Label PrintPage_Title;
		private DataDynamics.ActiveReports.TextBox PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox PrintTime;
        private DataDynamics.ActiveReports.Label FormName;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label StockAdjustSlipNo_Title;
		private DataDynamics.ActiveReports.Label InputAgenNm_Title;
		private DataDynamics.ActiveReports.Label GoodsCode_Title;
		private DataDynamics.ActiveReports.Label GoodsName_Title;
		private DataDynamics.ActiveReports.Label StockUnitPrice_Title;
		private DataDynamics.ActiveReports.Label TotalStockUnitPrice_Title;
		private DataDynamics.ActiveReports.Label AdjustDate_Title;
        private DataDynamics.ActiveReports.Label SlipNote_Title;
        private DataDynamics.ActiveReports.Label MakerName_Title;
		private DataDynamics.ActiveReports.Label WarehouseCode_Title;
		private DataDynamics.ActiveReports.Label AdjustCount_Title;
        private DataDynamics.ActiveReports.Label WarehouseShelfNo_Title;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.GroupHeader StockAdjustSlipNoHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox TotalStockUnitPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsName_TextBox;
        private DataDynamics.ActiveReports.TextBox GoodsCode_TextBox;
		private DataDynamics.ActiveReports.TextBox DtlNote_TextBox;
        private DataDynamics.ActiveReports.TextBox StockUnitPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox AdjustCount_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_TextBox;
		private DataDynamics.ActiveReports.TextBox TotalStockUnitMinus_TextBox;
		private DataDynamics.ActiveReports.TextBox AdjustCountMinus_TextBox;
		private DataDynamics.ActiveReports.TextBox TotalStockUnitPlus_TextBox;
        private DataDynamics.ActiveReports.TextBox AdjustCountPlus_TextBox;
		private DataDynamics.ActiveReports.GroupFooter StockAdjustSlipNoFooter;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox tb_SumTitle;
		private DataDynamics.ActiveReports.TextBox Sum_AdjustCountPlus;
		private DataDynamics.ActiveReports.TextBox Sum_TotalStockUnitPricePlus;
		private DataDynamics.ActiveReports.TextBox Sum_AdjustCountMinus;
		private DataDynamics.ActiveReports.TextBox Sum_TotalStockUnitPriceMinus;
		private DataDynamics.ActiveReports.TextBox TextBox1;
		private DataDynamics.ActiveReports.TextBox TextBox2;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line3;
		private DataDynamics.ActiveReports.TextBox TextBox;
		private DataDynamics.ActiveReports.TextBox SecSum_AdjustCountPlus;
		private DataDynamics.ActiveReports.TextBox SecSum_TotalStockUnitPricePlus;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.TextBox TextBox4;
		private DataDynamics.ActiveReports.TextBox SecSum_AdjustCountMinus;
		private DataDynamics.ActiveReports.TextBox SecSum_TotalStockUnitPriceMinus;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox TotalSum_AdjustCountPlus;
		private DataDynamics.ActiveReports.TextBox TotalSum_TotalStockUnitPricePlus;
		private DataDynamics.ActiveReports.TextBox TextBox5;
		private DataDynamics.ActiveReports.TextBox TextBox6;
		private DataDynamics.ActiveReports.TextBox TotalSum_AdjustCountMinus;
        private DataDynamics.ActiveReports.TextBox TotalSum_TotalStockUnitPriceMinus;
		private DataDynamics.ActiveReports.TextBox TotalSum_AdjustCount;
		private DataDynamics.ActiveReports.TextBox TotalSum_TotalStockUnitPrice;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02052P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TotalStockUnitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.DtlNote_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AdjustCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TotalStockUnitMinus_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AdjustCountMinus_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TotalStockUnitPlus_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AdjustCountPlus_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BfStockUnitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PrintDate_Title = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.PrintPage_Title = new DataDynamics.ActiveReports.Label();
            this.PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.FormName = new DataDynamics.ActiveReports.Label();
            this.OutputSort = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.StockAdjustSlipNo_Title = new DataDynamics.ActiveReports.Label();
            this.InputAgenNm_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsCode_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.StockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.TotalStockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.AdjustDate_Title = new DataDynamics.ActiveReports.Label();
            this.SlipNote_Title = new DataDynamics.ActiveReports.Label();
            this.MakerName_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseCode_Title = new DataDynamics.ActiveReports.Label();
            this.AdjustCount_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.BfStockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.ListPrice_Title = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.InputDay_Title = new DataDynamics.ActiveReports.Label();
            this.AcPaySlipCd_Title = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.TotalSum_AdjustCountPlus = new DataDynamics.ActiveReports.TextBox();
            this.TotalSum_TotalStockUnitPricePlus = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.TotalSum_AdjustCountMinus = new DataDynamics.ActiveReports.TextBox();
            this.TotalSum_TotalStockUnitPriceMinus = new DataDynamics.ActiveReports.TextBox();
            this.TotalSum_AdjustCount = new DataDynamics.ActiveReports.TextBox();
            this.TotalSum_TotalStockUnitPrice = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SectionCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SecSum_AdjustCountPlus = new DataDynamics.ActiveReports.TextBox();
            this.SecSum_TotalStockUnitPricePlus = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.SecSum_AdjustCountMinus = new DataDynamics.ActiveReports.TextBox();
            this.SecSum_TotalStockUnitPriceMinus = new DataDynamics.ActiveReports.TextBox();
            this.StockAdjustSlipNoHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockAdjustSlipNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AdjustDate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InputAgenNm_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InputAgenCd_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.InputDay_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AcPaySlipCd_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.SectionCode_TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideNm2 = new DataDynamics.ActiveReports.TextBox();
            this.StockAdjustSlipNoFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.tb_SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.Sum_AdjustCountPlus = new DataDynamics.ActiveReports.TextBox();
            this.Sum_TotalStockUnitPricePlus = new DataDynamics.ActiveReports.TextBox();
            this.Sum_AdjustCountMinus = new DataDynamics.ActiveReports.TextBox();
            this.Sum_TotalStockUnitPriceMinus = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseCode_TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName_TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlNote_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitMinus_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCountMinus_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitPlus_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCountPlus_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfStockUnitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAdjustSlipNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAgenNm_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfStockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDay_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_AdjustCountPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_TotalStockUnitPricePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_AdjustCountMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_TotalStockUnitPriceMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_AdjustCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_TotalStockUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_AdjustCountPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_TotalStockUnitPricePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_AdjustCountMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_TotalStockUnitPriceMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAdjustSlipNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustDate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAgenNm_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAgenCd_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDay_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipCd_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_AdjustCountPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_TotalStockUnitPricePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_AdjustCountMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_TotalStockUnitPriceMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName_TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TotalStockUnitPrice_TextBox,
            this.GoodsName_TextBox,
            this.GoodsCode_TextBox,
            this.DtlNote_TextBox,
            this.StockUnitPrice_TextBox,
            this.AdjustCount_TextBox,
            this.WarehouseShelfNo_TextBox,
            this.TotalStockUnitMinus_TextBox,
            this.AdjustCountMinus_TextBox,
            this.TotalStockUnitPlus_TextBox,
            this.AdjustCountPlus_TextBox,
            this.BfStockUnitPrice_TextBox,
            this.ListPrice_TextBox,
            this.MakerName_TextBox,
            this.MakerCode_TextBox});
            this.Detail.Height = 0.59375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // TotalStockUnitPrice_TextBox
            // 
            this.TotalStockUnitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_TextBox.DataField = "TotalStockUnitPrice";
            this.TotalStockUnitPrice_TextBox.Height = 0.125F;
            this.TotalStockUnitPrice_TextBox.Left = 7.5F;
            this.TotalStockUnitPrice_TextBox.MultiLine = false;
            this.TotalStockUnitPrice_TextBox.Name = "TotalStockUnitPrice_TextBox";
            this.TotalStockUnitPrice_TextBox.OutputFormat = resources.GetString("TotalStockUnitPrice_TextBox.OutputFormat");
            this.TotalStockUnitPrice_TextBox.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.TotalStockUnitPrice_TextBox.Text = "-12,345,678";
            this.TotalStockUnitPrice_TextBox.Top = 0.042F;
            this.TotalStockUnitPrice_TextBox.Width = 0.625F;
            // 
            // GoodsName_TextBox
            // 
            this.GoodsName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.DataField = "GoodsName";
            this.GoodsName_TextBox.Height = 0.125F;
            this.GoodsName_TextBox.Left = 1.5F;
            this.GoodsName_TextBox.MultiLine = false;
            this.GoodsName_TextBox.Name = "GoodsName_TextBox";
            this.GoodsName_TextBox.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.GoodsName_TextBox.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.GoodsName_TextBox.Top = 0.042F;
            this.GoodsName_TextBox.Width = 2F;
            // 
            // GoodsCode_TextBox
            // 
            this.GoodsCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_TextBox.DataField = "GoodsCode";
            this.GoodsCode_TextBox.Height = 0.125F;
            this.GoodsCode_TextBox.Left = 0.25F;
            this.GoodsCode_TextBox.MultiLine = false;
            this.GoodsCode_TextBox.Name = "GoodsCode_TextBox";
            this.GoodsCode_TextBox.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.GoodsCode_TextBox.Text = "123456789012345678901234";
            this.GoodsCode_TextBox.Top = 0.042F;
            this.GoodsCode_TextBox.Width = 1.25F;
            // 
            // DtlNote_TextBox
            // 
            this.DtlNote_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.DtlNote_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DtlNote_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.DtlNote_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DtlNote_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.DtlNote_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DtlNote_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.DtlNote_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DtlNote_TextBox.DataField = "DtlNote";
            this.DtlNote_TextBox.Height = 0.125F;
            this.DtlNote_TextBox.Left = 8.75F;
            this.DtlNote_TextBox.MultiLine = false;
            this.DtlNote_TextBox.Name = "DtlNote_TextBox";
            this.DtlNote_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.DtlNote_TextBox.Text = "ｘｘｘｘｘｘｘｘｘｘｘｘｘｘｘｘｘｘｘｘ";
            this.DtlNote_TextBox.Top = 0.042F;
            this.DtlNote_TextBox.Width = 2F;
            // 
            // StockUnitPrice_TextBox
            // 
            this.StockUnitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.DataField = "StockUnitPrice";
            this.StockUnitPrice_TextBox.Height = 0.125F;
            this.StockUnitPrice_TextBox.Left = 6.8125F;
            this.StockUnitPrice_TextBox.MultiLine = false;
            this.StockUnitPrice_TextBox.Name = "StockUnitPrice_TextBox";
            this.StockUnitPrice_TextBox.OutputFormat = resources.GetString("StockUnitPrice_TextBox.OutputFormat");
            this.StockUnitPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.StockUnitPrice_TextBox.Text = "1,234,567.89";
            this.StockUnitPrice_TextBox.Top = 0.042F;
            this.StockUnitPrice_TextBox.Width = 0.6875F;
            // 
            // AdjustCount_TextBox
            // 
            this.AdjustCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AdjustCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AdjustCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AdjustCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AdjustCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_TextBox.DataField = "AdjustCount";
            this.AdjustCount_TextBox.Height = 0.125F;
            this.AdjustCount_TextBox.Left = 4.8125F;
            this.AdjustCount_TextBox.MultiLine = false;
            this.AdjustCount_TextBox.Name = "AdjustCount_TextBox";
            this.AdjustCount_TextBox.OutputFormat = resources.GetString("AdjustCount_TextBox.OutputFormat");
            this.AdjustCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.AdjustCount_TextBox.Text = "123,456.78";
            this.AdjustCount_TextBox.Top = 0.042F;
            this.AdjustCount_TextBox.Width = 0.625F;
            // 
            // WarehouseShelfNo_TextBox
            // 
            this.WarehouseShelfNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo_TextBox.Height = 0.125F;
            this.WarehouseShelfNo_TextBox.Left = 8.25F;
            this.WarehouseShelfNo_TextBox.MultiLine = false;
            this.WarehouseShelfNo_TextBox.Name = "WarehouseShelfNo_TextBox";
            this.WarehouseShelfNo_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.WarehouseShelfNo_TextBox.Text = "12345678";
            this.WarehouseShelfNo_TextBox.Top = 0.042F;
            this.WarehouseShelfNo_TextBox.Width = 0.4375F;
            // 
            // TotalStockUnitMinus_TextBox
            // 
            this.TotalStockUnitMinus_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockUnitMinus_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitMinus_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockUnitMinus_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitMinus_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockUnitMinus_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitMinus_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockUnitMinus_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitMinus_TextBox.DataField = "TotalStockUnitPriceMinus";
            this.TotalStockUnitMinus_TextBox.Height = 0.125F;
            this.TotalStockUnitMinus_TextBox.Left = 7.4375F;
            this.TotalStockUnitMinus_TextBox.MultiLine = false;
            this.TotalStockUnitMinus_TextBox.Name = "TotalStockUnitMinus_TextBox";
            this.TotalStockUnitMinus_TextBox.OutputFormat = resources.GetString("TotalStockUnitMinus_TextBox.OutputFormat");
            this.TotalStockUnitMinus_TextBox.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.TotalStockUnitMinus_TextBox.Text = "-12,345,678";
            this.TotalStockUnitMinus_TextBox.Top = 0.417F;
            this.TotalStockUnitMinus_TextBox.Visible = false;
            this.TotalStockUnitMinus_TextBox.Width = 0.6875F;
            // 
            // AdjustCountMinus_TextBox
            // 
            this.AdjustCountMinus_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AdjustCountMinus_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountMinus_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AdjustCountMinus_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountMinus_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AdjustCountMinus_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountMinus_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AdjustCountMinus_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountMinus_TextBox.DataField = "AdjustCountMinus";
            this.AdjustCountMinus_TextBox.Height = 0.125F;
            this.AdjustCountMinus_TextBox.Left = 4.875F;
            this.AdjustCountMinus_TextBox.MultiLine = false;
            this.AdjustCountMinus_TextBox.Name = "AdjustCountMinus_TextBox";
            this.AdjustCountMinus_TextBox.OutputFormat = resources.GetString("AdjustCountMinus_TextBox.OutputFormat");
            this.AdjustCountMinus_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.AdjustCountMinus_TextBox.Text = "1234";
            this.AdjustCountMinus_TextBox.Top = 0.417F;
            this.AdjustCountMinus_TextBox.Visible = false;
            this.AdjustCountMinus_TextBox.Width = 0.5625F;
            // 
            // TotalStockUnitPlus_TextBox
            // 
            this.TotalStockUnitPlus_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockUnitPlus_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPlus_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockUnitPlus_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPlus_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockUnitPlus_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPlus_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockUnitPlus_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPlus_TextBox.DataField = "TotalStockUnitPricePlus";
            this.TotalStockUnitPlus_TextBox.Height = 0.125F;
            this.TotalStockUnitPlus_TextBox.Left = 7.4375F;
            this.TotalStockUnitPlus_TextBox.MultiLine = false;
            this.TotalStockUnitPlus_TextBox.Name = "TotalStockUnitPlus_TextBox";
            this.TotalStockUnitPlus_TextBox.OutputFormat = resources.GetString("TotalStockUnitPlus_TextBox.OutputFormat");
            this.TotalStockUnitPlus_TextBox.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.TotalStockUnitPlus_TextBox.Text = "-12,345,678";
            this.TotalStockUnitPlus_TextBox.Top = 0.229F;
            this.TotalStockUnitPlus_TextBox.Visible = false;
            this.TotalStockUnitPlus_TextBox.Width = 0.6875F;
            // 
            // AdjustCountPlus_TextBox
            // 
            this.AdjustCountPlus_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AdjustCountPlus_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountPlus_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AdjustCountPlus_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountPlus_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AdjustCountPlus_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountPlus_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AdjustCountPlus_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCountPlus_TextBox.DataField = "AdjustCountPlus";
            this.AdjustCountPlus_TextBox.Height = 0.125F;
            this.AdjustCountPlus_TextBox.Left = 4.875F;
            this.AdjustCountPlus_TextBox.MultiLine = false;
            this.AdjustCountPlus_TextBox.Name = "AdjustCountPlus_TextBox";
            this.AdjustCountPlus_TextBox.OutputFormat = resources.GetString("AdjustCountPlus_TextBox.OutputFormat");
            this.AdjustCountPlus_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.AdjustCountPlus_TextBox.Text = "1234";
            this.AdjustCountPlus_TextBox.Top = 0.229F;
            this.AdjustCountPlus_TextBox.Visible = false;
            this.AdjustCountPlus_TextBox.Width = 0.5625F;
            // 
            // BfStockUnitPrice_TextBox
            // 
            this.BfStockUnitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_TextBox.DataField = "BfStockUnitPrice";
            this.BfStockUnitPrice_TextBox.Height = 0.125F;
            this.BfStockUnitPrice_TextBox.Left = 6.125F;
            this.BfStockUnitPrice_TextBox.MultiLine = false;
            this.BfStockUnitPrice_TextBox.Name = "BfStockUnitPrice_TextBox";
            this.BfStockUnitPrice_TextBox.OutputFormat = resources.GetString("BfStockUnitPrice_TextBox.OutputFormat");
            this.BfStockUnitPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.BfStockUnitPrice_TextBox.Text = "1,234,567.89";
            this.BfStockUnitPrice_TextBox.Top = 0.042F;
            this.BfStockUnitPrice_TextBox.Width = 0.6875F;
            // 
            // ListPrice_TextBox
            // 
            this.ListPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.DataField = "ListPrice";
            this.ListPrice_TextBox.Height = 0.125F;
            this.ListPrice_TextBox.Left = 5.4375F;
            this.ListPrice_TextBox.MultiLine = false;
            this.ListPrice_TextBox.Name = "ListPrice_TextBox";
            this.ListPrice_TextBox.OutputFormat = resources.GetString("ListPrice_TextBox.OutputFormat");
            this.ListPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.ListPrice_TextBox.Text = "1,234,567.89";
            this.ListPrice_TextBox.Top = 0.042F;
            this.ListPrice_TextBox.Width = 0.6875F;
            // 
            // MakerName_TextBox
            // 
            this.MakerName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_TextBox.DataField = "MakerName";
            this.MakerName_TextBox.Height = 0.125F;
            this.MakerName_TextBox.Left = 3.8125F;
            this.MakerName_TextBox.MultiLine = false;
            this.MakerName_TextBox.Name = "MakerName_TextBox";
            this.MakerName_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.MakerName_TextBox.Text = "あいうえおかきくけこ";
            this.MakerName_TextBox.Top = 0.042F;
            this.MakerName_TextBox.Width = 1F;
            // 
            // MakerCode_TextBox
            // 
            this.MakerCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.DataField = "MakerCode";
            this.MakerCode_TextBox.Height = 0.125F;
            this.MakerCode_TextBox.Left = 3.5625F;
            this.MakerCode_TextBox.MultiLine = false;
            this.MakerCode_TextBox.Name = "MakerCode_TextBox";
            this.MakerCode_TextBox.OutputFormat = resources.GetString("MakerCode_TextBox.OutputFormat");
            this.MakerCode_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.MakerCode_TextBox.Text = "1234";
            this.MakerCode_TextBox.Top = 0.042F;
            this.MakerCode_TextBox.Width = 0.25F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PrintDate_Title,
            this.PrintDate,
            this.PrintPage_Title,
            this.PrintPage,
            this.Line1,
            this.PrintTime,
            this.FormName,
            this.OutputSort});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // PrintDate_Title
            // 
            this.PrintDate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Height = 0.15625F;
            this.PrintDate_Title.HyperLink = "";
            this.PrintDate_Title.Left = 7.9375F;
            this.PrintDate_Title.MultiLine = false;
            this.PrintDate_Title.Name = "PrintDate_Title";
            this.PrintDate_Title.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate_Title.Text = "作成日付：";
            this.PrintDate_Title.Top = 0.0625F;
            this.PrintDate_Title.Width = 0.625F;
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
            // PrintPage_Title
            // 
            this.PrintPage_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Height = 0.15625F;
            this.PrintPage_Title.HyperLink = "";
            this.PrintPage_Title.Left = 9.9375F;
            this.PrintPage_Title.MultiLine = false;
            this.PrintPage_Title.Name = "PrintPage_Title";
            this.PrintPage_Title.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintPage_Title.Text = "ページ：";
            this.PrintPage_Title.Top = 0.0625F;
            this.PrintPage_Title.Width = 0.5F;
            // 
            // PrintPage
            // 
            this.PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.CanShrink = true;
            this.PrintPage.Height = 0.15625F;
            this.PrintPage.Left = 10.4375F;
            this.PrintPage.MultiLine = false;
            this.PrintPage.Name = "PrintPage";
            this.PrintPage.OutputFormat = resources.GetString("PrintPage.OutputFormat");
            this.PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PrintPage.Text = "123";
            this.PrintPage.Top = 0.0625F;
            this.PrintPage.Width = 0.28125F;
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
            this.Line1.Top = 0.21875F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.21875F;
            this.Line1.Y2 = 0.21875F;
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
            // FormName
            // 
            this.FormName.Border.BottomColor = System.Drawing.Color.Black;
            this.FormName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Border.LeftColor = System.Drawing.Color.Black;
            this.FormName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Border.RightColor = System.Drawing.Color.Black;
            this.FormName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Border.TopColor = System.Drawing.Color.Black;
            this.FormName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Height = 0.21875F;
            this.FormName.HyperLink = "";
            this.FormName.Left = 0.21875F;
            this.FormName.MultiLine = false;
            this.FormName.Name = "FormName";
            this.FormName.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.FormName.Text = "在庫仕入確認表";
            this.FormName.Top = 0F;
            this.FormName.Width = 1.795F;
            // 
            // OutputSort
            // 
            this.OutputSort.Border.BottomColor = System.Drawing.Color.Black;
            this.OutputSort.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OutputSort.Border.LeftColor = System.Drawing.Color.Black;
            this.OutputSort.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OutputSort.Border.RightColor = System.Drawing.Color.Black;
            this.OutputSort.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OutputSort.Border.TopColor = System.Drawing.Color.Black;
            this.OutputSort.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OutputSort.Height = 0.15625F;
            this.OutputSort.HyperLink = "";
            this.OutputSort.Left = 2.5F;
            this.OutputSort.MultiLine = false;
            this.OutputSort.Name = "OutputSort";
            this.OutputSort.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.OutputSort.Text = "あいう";
            this.OutputSort.Top = 0.0625F;
            this.OutputSort.Width = 0.625F;
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
            this.ExtraHeader.Height = 0.5104167F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
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
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line42,
            this.StockAdjustSlipNo_Title,
            this.InputAgenNm_Title,
            this.GoodsCode_Title,
            this.GoodsName_Title,
            this.StockUnitPrice_Title,
            this.TotalStockUnitPrice_Title,
            this.AdjustDate_Title,
            this.SlipNote_Title,
            this.MakerName_Title,
            this.WarehouseCode_Title,
            this.AdjustCount_Title,
            this.WarehouseShelfNo_Title,
            this.BfStockUnitPrice_Title,
            this.ListPrice_Title,
            this.line7,
            this.label1,
            this.InputDay_Title,
            this.AcPaySlipCd_Title});
            this.TitleHeader.Height = 0.6045F;
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
            this.Line42.Top = 1.490116E-08F;
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 1.490116E-08F;
            this.Line42.Y2 = 1.490116E-08F;
            // 
            // StockAdjustSlipNo_Title
            // 
            this.StockAdjustSlipNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_Title.Height = 0.135F;
            this.StockAdjustSlipNo_Title.HyperLink = "";
            this.StockAdjustSlipNo_Title.Left = 3.96F;
            this.StockAdjustSlipNo_Title.MultiLine = false;
            this.StockAdjustSlipNo_Title.Name = "StockAdjustSlipNo_Title";
            this.StockAdjustSlipNo_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.StockAdjustSlipNo_Title.Text = "伝票番号";
            this.StockAdjustSlipNo_Title.Top = 0.229F;
            this.StockAdjustSlipNo_Title.Width = 0.5F;
            // 
            // InputAgenNm_Title
            // 
            this.InputAgenNm_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.InputAgenNm_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.InputAgenNm_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_Title.Border.RightColor = System.Drawing.Color.Black;
            this.InputAgenNm_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_Title.Border.TopColor = System.Drawing.Color.Black;
            this.InputAgenNm_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_Title.Height = 0.135F;
            this.InputAgenNm_Title.HyperLink = "";
            this.InputAgenNm_Title.Left = 5.375F;
            this.InputAgenNm_Title.MultiLine = false;
            this.InputAgenNm_Title.Name = "InputAgenNm_Title";
            this.InputAgenNm_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            //this.InputAgenNm_Title.Text = "入力担当者"; //DEL 2011/11/15 xupz
            this.InputAgenNm_Title.Text = "仕入担当者"; // ADD 2011/11/15 xupz
            this.InputAgenNm_Title.Top = 0.229F;
            this.InputAgenNm_Title.Width = 0.625F;
            // 
            // GoodsCode_Title
            // 
            this.GoodsCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsCode_Title.Height = 0.157F;
            this.GoodsCode_Title.HyperLink = "";
            this.GoodsCode_Title.Left = 0.25F;
            this.GoodsCode_Title.MultiLine = false;
            this.GoodsCode_Title.Name = "GoodsCode_Title";
            this.GoodsCode_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.GoodsCode_Title.Text = "品番";
            this.GoodsCode_Title.Top = 0.4270833F;
            this.GoodsCode_Title.Width = 0.59F;
            // 
            // GoodsName_Title
            // 
            this.GoodsName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Height = 0.1574803F;
            this.GoodsName_Title.HyperLink = "";
            this.GoodsName_Title.Left = 1.5F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.GoodsName_Title.Text = "品名";
            this.GoodsName_Title.Top = 0.4375F;
            this.GoodsName_Title.Width = 1.075F;
            // 
            // StockUnitPrice_Title
            // 
            this.StockUnitPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Height = 0.1875F;
            this.StockUnitPrice_Title.HyperLink = "";
            this.StockUnitPrice_Title.Left = 7.125F;
            this.StockUnitPrice_Title.MultiLine = false;
            this.StockUnitPrice_Title.Name = "StockUnitPrice_Title";
            this.StockUnitPrice_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.StockUnitPrice_Title.Text = "原単価";
            this.StockUnitPrice_Title.Top = 0.417F;
            this.StockUnitPrice_Title.Width = 0.4F;
            // 
            // TotalStockUnitPrice_Title
            // 
            this.TotalStockUnitPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockUnitPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockUnitPrice_Title.Height = 0.157F;
            this.TotalStockUnitPrice_Title.HyperLink = "";
            this.TotalStockUnitPrice_Title.Left = 7.5625F;
            this.TotalStockUnitPrice_Title.MultiLine = false;
            this.TotalStockUnitPrice_Title.Name = "TotalStockUnitPrice_Title";
            this.TotalStockUnitPrice_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.TotalStockUnitPrice_Title.Text = "調整合計";
            this.TotalStockUnitPrice_Title.Top = 0.417F;
            this.TotalStockUnitPrice_Title.Width = 0.5625F;
            // 
            // AdjustDate_Title
            // 
            this.AdjustDate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AdjustDate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AdjustDate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AdjustDate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AdjustDate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_Title.Height = 0.135F;
            this.AdjustDate_Title.HyperLink = "";
            this.AdjustDate_Title.Left = 3.335F;
            this.AdjustDate_Title.MultiLine = false;
            this.AdjustDate_Title.Name = "AdjustDate_Title";
            this.AdjustDate_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.AdjustDate_Title.Text = "仕入日付";
            this.AdjustDate_Title.Top = 0.229F;
            this.AdjustDate_Title.Width = 0.5F;
            // 
            // SlipNote_Title
            // 
            this.SlipNote_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote_Title.Height = 0.157F;
            this.SlipNote_Title.HyperLink = "";
            this.SlipNote_Title.Left = 8.75F;
            this.SlipNote_Title.MultiLine = false;
            this.SlipNote_Title.Name = "SlipNote_Title";
            this.SlipNote_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.SlipNote_Title.Text = "明細備考";
            this.SlipNote_Title.Top = 0.417F;
            this.SlipNote_Title.Width = 0.4800005F;
            // 
            // MakerName_Title
            // 
            this.MakerName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName_Title.Height = 0.125F;
            this.MakerName_Title.HyperLink = "";
            this.MakerName_Title.Left = 3.5625F;
            this.MakerName_Title.MultiLine = false;
            this.MakerName_Title.Name = "MakerName_Title";
            this.MakerName_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.MakerName_Title.Text = "メーカー";
            this.MakerName_Title.Top = 0.417F;
            this.MakerName_Title.Width = 0.8125F;
            // 
            // WarehouseCode_Title
            // 
            this.WarehouseCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Height = 0.135F;
            this.WarehouseCode_Title.HyperLink = "";
            this.WarehouseCode_Title.Left = 0F;
            this.WarehouseCode_Title.MultiLine = false;
            this.WarehouseCode_Title.Name = "WarehouseCode_Title";
            this.WarehouseCode_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.WarehouseCode_Title.Text = "倉庫";
            this.WarehouseCode_Title.Top = 0.2291667F;
            this.WarehouseCode_Title.Width = 0.8125F;
            // 
            // AdjustCount_Title
            // 
            this.AdjustCount_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AdjustCount_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AdjustCount_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AdjustCount_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AdjustCount_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustCount_Title.Height = 0.1875F;
            this.AdjustCount_Title.HyperLink = "";
            this.AdjustCount_Title.Left = 4.875F;
            this.AdjustCount_Title.MultiLine = false;
            this.AdjustCount_Title.Name = "AdjustCount_Title";
            this.AdjustCount_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.AdjustCount_Title.Text = "調整数";
            this.AdjustCount_Title.Top = 0.417F;
            this.AdjustCount_Title.Width = 0.5625F;
            // 
            // WarehouseShelfNo_Title
            // 
            this.WarehouseShelfNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Height = 0.1574803F;
            this.WarehouseShelfNo_Title.HyperLink = "";
            this.WarehouseShelfNo_Title.Left = 8.25F;
            this.WarehouseShelfNo_Title.MultiLine = false;
            this.WarehouseShelfNo_Title.Name = "WarehouseShelfNo_Title";
            this.WarehouseShelfNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.WarehouseShelfNo_Title.Text = "棚番";
            this.WarehouseShelfNo_Title.Top = 0.417F;
            this.WarehouseShelfNo_Title.Width = 0.3575001F;
            // 
            // BfStockUnitPrice_Title
            // 
            this.BfStockUnitPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BfStockUnitPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BfStockUnitPrice_Title.Height = 0.25F;
            this.BfStockUnitPrice_Title.HyperLink = "";
            this.BfStockUnitPrice_Title.Left = 6.385F;
            this.BfStockUnitPrice_Title.Name = "BfStockUnitPrice_Title";
            this.BfStockUnitPrice_Title.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.BfStockUnitPrice_Title.Text = "(変更前)原単価";
            this.BfStockUnitPrice_Title.Top = 0.311F;
            this.BfStockUnitPrice_Title.Width = 0.5F;
            // 
            // ListPrice_Title
            // 
            this.ListPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Height = 0.1875F;
            this.ListPrice_Title.HyperLink = "";
            this.ListPrice_Title.Left = 5.625F;
            this.ListPrice_Title.MultiLine = false;
            this.ListPrice_Title.Name = "ListPrice_Title";
            this.ListPrice_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; ";
            this.ListPrice_Title.Text = "標準価格";
            this.ListPrice_Title.Top = 0.417F;
            this.ListPrice_Title.Width = 0.515F;
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
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0.1875F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0.1875F;
            this.line7.Y2 = 0.1875F;
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
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = "";
            this.label1.Left = 0F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.label1.Text = "拠点";
            this.label1.Top = 0.04166668F;
            this.label1.Width = 0.8125F;
            // 
            // InputDay_Title
            // 
            this.InputDay_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.InputDay_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.InputDay_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_Title.Border.RightColor = System.Drawing.Color.Black;
            this.InputDay_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_Title.Border.TopColor = System.Drawing.Color.Black;
            this.InputDay_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_Title.Height = 0.135F;
            this.InputDay_Title.HyperLink = "";
            this.InputDay_Title.Left = 2.719F;
            this.InputDay_Title.MultiLine = false;
            this.InputDay_Title.Name = "InputDay_Title";
            this.InputDay_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.InputDay_Title.Text = "入力日";
            this.InputDay_Title.Top = 0.229F;
            this.InputDay_Title.Width = 0.5F;
            // 
            // AcPaySlipCd_Title
            // 
            this.AcPaySlipCd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_Title.Height = 0.135F;
            this.AcPaySlipCd_Title.HyperLink = "";
            this.AcPaySlipCd_Title.Left = 4.5625F;
            this.AcPaySlipCd_Title.MultiLine = false;
            this.AcPaySlipCd_Title.Name = "AcPaySlipCd_Title";
            this.AcPaySlipCd_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.AcPaySlipCd_Title.Text = "伝票区分";
            this.AcPaySlipCd_Title.Top = 0.229F;
            this.AcPaySlipCd_Title.Width = 0.625F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
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
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ALLTOTALTITLE,
            this.Line43,
            this.TotalSum_AdjustCountPlus,
            this.TotalSum_TotalStockUnitPricePlus,
            this.TextBox5,
            this.TextBox6,
            this.TotalSum_AdjustCountMinus,
            this.TotalSum_TotalStockUnitPriceMinus,
            this.TotalSum_AdjustCount,
            this.TotalSum_TotalStockUnitPrice,
            this.line8});
            this.GrandTotalFooter.Height = 0.65625F;
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
            this.ALLTOTALTITLE.Left = 3.625F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.125F;
            this.ALLTOTALTITLE.Width = 0.5625F;
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
            // TotalSum_AdjustCountPlus
            // 
            this.TotalSum_AdjustCountPlus.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountPlus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountPlus.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountPlus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountPlus.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountPlus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountPlus.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountPlus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountPlus.DataField = "AdjustCountPlus";
            this.TotalSum_AdjustCountPlus.Height = 0.125F;
            this.TotalSum_AdjustCountPlus.Left = 4.8125F;
            this.TotalSum_AdjustCountPlus.MultiLine = false;
            this.TotalSum_AdjustCountPlus.Name = "TotalSum_AdjustCountPlus";
            this.TotalSum_AdjustCountPlus.OutputFormat = resources.GetString("TotalSum_AdjustCountPlus.OutputFormat");
            this.TotalSum_AdjustCountPlus.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.TotalSum_AdjustCountPlus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TotalSum_AdjustCountPlus.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalSum_AdjustCountPlus.Text = "12345";
            this.TotalSum_AdjustCountPlus.Top = 0.0625F;
            this.TotalSum_AdjustCountPlus.Width = 0.625F;
            // 
            // TotalSum_TotalStockUnitPricePlus
            // 
            this.TotalSum_TotalStockUnitPricePlus.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPricePlus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPricePlus.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPricePlus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPricePlus.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPricePlus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPricePlus.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPricePlus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPricePlus.DataField = "TotalStockUnitPricePlus";
            this.TotalSum_TotalStockUnitPricePlus.Height = 0.125F;
            this.TotalSum_TotalStockUnitPricePlus.Left = 7.3125F;
            this.TotalSum_TotalStockUnitPricePlus.MultiLine = false;
            this.TotalSum_TotalStockUnitPricePlus.Name = "TotalSum_TotalStockUnitPricePlus";
            this.TotalSum_TotalStockUnitPricePlus.OutputFormat = resources.GetString("TotalSum_TotalStockUnitPricePlus.OutputFormat");
            this.TotalSum_TotalStockUnitPricePlus.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.TotalSum_TotalStockUnitPricePlus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TotalSum_TotalStockUnitPricePlus.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalSum_TotalStockUnitPricePlus.Text = "-12,345,678";
            this.TotalSum_TotalStockUnitPricePlus.Top = 0.0625F;
            this.TotalSum_TotalStockUnitPricePlus.Width = 0.8125F;
            // 
            // TextBox5
            // 
            this.TextBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Height = 0.125F;
            this.TextBox5.Left = 4.3125F;
            this.TextBox5.MultiLine = false;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox5.Text = "【 + 】";
            this.TextBox5.Top = 0.0625F;
            this.TextBox5.Width = 0.5F;
            // 
            // TextBox6
            // 
            this.TextBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Height = 0.125F;
            this.TextBox6.Left = 4.3125F;
            this.TextBox6.MultiLine = false;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox6.Text = "【 - 】";
            this.TextBox6.Top = 0.25F;
            this.TextBox6.Width = 0.5F;
            // 
            // TotalSum_AdjustCountMinus
            // 
            this.TotalSum_AdjustCountMinus.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountMinus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountMinus.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountMinus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountMinus.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountMinus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountMinus.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCountMinus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCountMinus.DataField = "AdjustCountMinus";
            this.TotalSum_AdjustCountMinus.Height = 0.125F;
            this.TotalSum_AdjustCountMinus.Left = 4.8125F;
            this.TotalSum_AdjustCountMinus.MultiLine = false;
            this.TotalSum_AdjustCountMinus.Name = "TotalSum_AdjustCountMinus";
            this.TotalSum_AdjustCountMinus.OutputFormat = resources.GetString("TotalSum_AdjustCountMinus.OutputFormat");
            this.TotalSum_AdjustCountMinus.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.TotalSum_AdjustCountMinus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TotalSum_AdjustCountMinus.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalSum_AdjustCountMinus.Text = "12345";
            this.TotalSum_AdjustCountMinus.Top = 0.25F;
            this.TotalSum_AdjustCountMinus.Width = 0.625F;
            // 
            // TotalSum_TotalStockUnitPriceMinus
            // 
            this.TotalSum_TotalStockUnitPriceMinus.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPriceMinus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPriceMinus.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPriceMinus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPriceMinus.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPriceMinus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPriceMinus.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPriceMinus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPriceMinus.DataField = "TotalStockUnitPriceMinus";
            this.TotalSum_TotalStockUnitPriceMinus.Height = 0.125F;
            this.TotalSum_TotalStockUnitPriceMinus.Left = 7.3125F;
            this.TotalSum_TotalStockUnitPriceMinus.MultiLine = false;
            this.TotalSum_TotalStockUnitPriceMinus.Name = "TotalSum_TotalStockUnitPriceMinus";
            this.TotalSum_TotalStockUnitPriceMinus.OutputFormat = resources.GetString("TotalSum_TotalStockUnitPriceMinus.OutputFormat");
            this.TotalSum_TotalStockUnitPriceMinus.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.TotalSum_TotalStockUnitPriceMinus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TotalSum_TotalStockUnitPriceMinus.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalSum_TotalStockUnitPriceMinus.Text = "-12,345,678";
            this.TotalSum_TotalStockUnitPriceMinus.Top = 0.25F;
            this.TotalSum_TotalStockUnitPriceMinus.Width = 0.8125F;
            // 
            // TotalSum_AdjustCount
            // 
            this.TotalSum_AdjustCount.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCount.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCount.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCount.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSum_AdjustCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_AdjustCount.DataField = "AdjustCount";
            this.TotalSum_AdjustCount.Height = 0.125F;
            this.TotalSum_AdjustCount.Left = 4.8125F;
            this.TotalSum_AdjustCount.MultiLine = false;
            this.TotalSum_AdjustCount.Name = "TotalSum_AdjustCount";
            this.TotalSum_AdjustCount.OutputFormat = resources.GetString("TotalSum_AdjustCount.OutputFormat");
            this.TotalSum_AdjustCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.TotalSum_AdjustCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TotalSum_AdjustCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalSum_AdjustCount.Text = "12345";
            this.TotalSum_AdjustCount.Top = 0.4375F;
            this.TotalSum_AdjustCount.Width = 0.625F;
            // 
            // TotalSum_TotalStockUnitPrice
            // 
            this.TotalSum_TotalStockUnitPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPrice.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPrice.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSum_TotalStockUnitPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSum_TotalStockUnitPrice.DataField = "TotalStockUnitPrice";
            this.TotalSum_TotalStockUnitPrice.Height = 0.125F;
            this.TotalSum_TotalStockUnitPrice.Left = 7.3125F;
            this.TotalSum_TotalStockUnitPrice.MultiLine = false;
            this.TotalSum_TotalStockUnitPrice.Name = "TotalSum_TotalStockUnitPrice";
            this.TotalSum_TotalStockUnitPrice.OutputFormat = resources.GetString("TotalSum_TotalStockUnitPrice.OutputFormat");
            this.TotalSum_TotalStockUnitPrice.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.TotalSum_TotalStockUnitPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TotalSum_TotalStockUnitPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalSum_TotalStockUnitPrice.Text = "-12,345,678";
            this.TotalSum_TotalStockUnitPrice.Top = 0.4375F;
            this.TotalSum_TotalStockUnitPrice.Width = 0.8125F;
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
            this.line8.Top = 0.4F;
            this.line8.Width = 10.8F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8F;
            this.line8.Y1 = 0.4F;
            this.line8.Y2 = 0.4F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line4,
            this.SectionCode_TextBox,
            this.SectionGuideNm});
            this.SectionHeader.Height = 0.21875F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Format += new System.EventHandler(this.SectionHeader_Format);
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
            // SectionCode_TextBox
            // 
            this.SectionCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox.DataField = "SectionCode";
            this.SectionCode_TextBox.Height = 0.156F;
            this.SectionCode_TextBox.Left = 0.031F;
            this.SectionCode_TextBox.MultiLine = false;
            this.SectionCode_TextBox.Name = "SectionCode_TextBox";
            this.SectionCode_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.SectionCode_TextBox.Text = "12";
            this.SectionCode_TextBox.Top = 0.0331F;
            this.SectionCode_TextBox.Width = 0.2F;
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
            this.SectionGuideNm.Height = 0.125F;
            this.SectionGuideNm.Left = 0.375F;
            this.SectionGuideNm.MultiLine = false;
            this.SectionGuideNm.Name = "SectionGuideNm";
            this.SectionGuideNm.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SectionGuideNm.Top = 0.031F;
            this.SectionGuideNm.Width = 1.25F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line3,
            this.TextBox,
            this.SecSum_AdjustCountPlus,
            this.SecSum_TotalStockUnitPricePlus,
            this.TextBox3,
            this.TextBox4,
            this.SecSum_AdjustCountMinus,
            this.SecSum_TotalStockUnitPriceMinus});
            this.SectionFooter.Height = 0.43125F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0F;
            this.Line3.Left = 0F;
            this.Line3.LineWeight = 2F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 10.8F;
            this.Line3.X1 = 0F;
            this.Line3.X2 = 10.8F;
            this.Line3.Y1 = 0F;
            this.Line3.Y2 = 0F;
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
            this.TextBox.Height = 0.219F;
            this.TextBox.Left = 3.625F;
            this.TextBox.MultiLine = false;
            this.TextBox.Name = "TextBox";
            this.TextBox.OutputFormat = resources.GetString("TextBox.OutputFormat");
            this.TextBox.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox.Text = "拠点計";
            this.TextBox.Top = 0.125F;
            this.TextBox.Width = 0.6875F;
            // 
            // SecSum_AdjustCountPlus
            // 
            this.SecSum_AdjustCountPlus.Border.BottomColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountPlus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountPlus.Border.LeftColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountPlus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountPlus.Border.RightColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountPlus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountPlus.Border.TopColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountPlus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountPlus.DataField = "AdjustCountPlus";
            this.SecSum_AdjustCountPlus.Height = 0.125F;
            this.SecSum_AdjustCountPlus.Left = 4.8125F;
            this.SecSum_AdjustCountPlus.MultiLine = false;
            this.SecSum_AdjustCountPlus.Name = "SecSum_AdjustCountPlus";
            this.SecSum_AdjustCountPlus.OutputFormat = resources.GetString("SecSum_AdjustCountPlus.OutputFormat");
            this.SecSum_AdjustCountPlus.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.SecSum_AdjustCountPlus.SummaryGroup = "SectionHeader";
            this.SecSum_AdjustCountPlus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecSum_AdjustCountPlus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecSum_AdjustCountPlus.Text = "12345";
            this.SecSum_AdjustCountPlus.Top = 0.0625F;
            this.SecSum_AdjustCountPlus.Width = 0.625F;
            // 
            // SecSum_TotalStockUnitPricePlus
            // 
            this.SecSum_TotalStockUnitPricePlus.Border.BottomColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPricePlus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPricePlus.Border.LeftColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPricePlus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPricePlus.Border.RightColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPricePlus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPricePlus.Border.TopColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPricePlus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPricePlus.DataField = "TotalStockUnitPricePlus";
            this.SecSum_TotalStockUnitPricePlus.Height = 0.125F;
            this.SecSum_TotalStockUnitPricePlus.Left = 7.3125F;
            this.SecSum_TotalStockUnitPricePlus.MultiLine = false;
            this.SecSum_TotalStockUnitPricePlus.Name = "SecSum_TotalStockUnitPricePlus";
            this.SecSum_TotalStockUnitPricePlus.OutputFormat = resources.GetString("SecSum_TotalStockUnitPricePlus.OutputFormat");
            this.SecSum_TotalStockUnitPricePlus.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.SecSum_TotalStockUnitPricePlus.SummaryGroup = "SectionHeader";
            this.SecSum_TotalStockUnitPricePlus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecSum_TotalStockUnitPricePlus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecSum_TotalStockUnitPricePlus.Text = "-12,345,678";
            this.SecSum_TotalStockUnitPricePlus.Top = 0.0625F;
            this.SecSum_TotalStockUnitPricePlus.Width = 0.8125F;
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
            this.TextBox3.Height = 0.125F;
            this.TextBox3.Left = 4.3125F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox3.Text = "【 + 】";
            this.TextBox3.Top = 0.0625F;
            this.TextBox3.Width = 0.5F;
            // 
            // TextBox4
            // 
            this.TextBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Height = 0.125F;
            this.TextBox4.Left = 4.3125F;
            this.TextBox4.MultiLine = false;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox4.Text = "【 - 】";
            this.TextBox4.Top = 0.25F;
            this.TextBox4.Width = 0.5F;
            // 
            // SecSum_AdjustCountMinus
            // 
            this.SecSum_AdjustCountMinus.Border.BottomColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountMinus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountMinus.Border.LeftColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountMinus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountMinus.Border.RightColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountMinus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountMinus.Border.TopColor = System.Drawing.Color.Black;
            this.SecSum_AdjustCountMinus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_AdjustCountMinus.DataField = "AdjustCountMinus";
            this.SecSum_AdjustCountMinus.Height = 0.125F;
            this.SecSum_AdjustCountMinus.Left = 4.8125F;
            this.SecSum_AdjustCountMinus.MultiLine = false;
            this.SecSum_AdjustCountMinus.Name = "SecSum_AdjustCountMinus";
            this.SecSum_AdjustCountMinus.OutputFormat = resources.GetString("SecSum_AdjustCountMinus.OutputFormat");
            this.SecSum_AdjustCountMinus.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.SecSum_AdjustCountMinus.SummaryGroup = "SectionHeader";
            this.SecSum_AdjustCountMinus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecSum_AdjustCountMinus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecSum_AdjustCountMinus.Text = "12345";
            this.SecSum_AdjustCountMinus.Top = 0.25F;
            this.SecSum_AdjustCountMinus.Width = 0.625F;
            // 
            // SecSum_TotalStockUnitPriceMinus
            // 
            this.SecSum_TotalStockUnitPriceMinus.Border.BottomColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPriceMinus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPriceMinus.Border.LeftColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPriceMinus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPriceMinus.Border.RightColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPriceMinus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPriceMinus.Border.TopColor = System.Drawing.Color.Black;
            this.SecSum_TotalStockUnitPriceMinus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecSum_TotalStockUnitPriceMinus.DataField = "TotalStockUnitPriceMinus";
            this.SecSum_TotalStockUnitPriceMinus.Height = 0.125F;
            this.SecSum_TotalStockUnitPriceMinus.Left = 7.3125F;
            this.SecSum_TotalStockUnitPriceMinus.MultiLine = false;
            this.SecSum_TotalStockUnitPriceMinus.Name = "SecSum_TotalStockUnitPriceMinus";
            this.SecSum_TotalStockUnitPriceMinus.OutputFormat = resources.GetString("SecSum_TotalStockUnitPriceMinus.OutputFormat");
            this.SecSum_TotalStockUnitPriceMinus.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.SecSum_TotalStockUnitPriceMinus.SummaryGroup = "SectionHeader";
            this.SecSum_TotalStockUnitPriceMinus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecSum_TotalStockUnitPriceMinus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecSum_TotalStockUnitPriceMinus.Text = "-12,345,678";
            this.SecSum_TotalStockUnitPriceMinus.Top = 0.25F;
            this.SecSum_TotalStockUnitPriceMinus.Width = 0.8125F;
            // 
            // StockAdjustSlipNoHeader
            // 
            this.StockAdjustSlipNoHeader.CanShrink = true;
            this.StockAdjustSlipNoHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseCode_TextBox,
            this.StockAdjustSlipNo_TextBox,
            this.AdjustDate_TextBox,
            this.InputAgenNm_TextBox,
            this.WarehouseName_TextBox,
            this.InputAgenCd_TextBox,
            this.Line2,
            this.InputDay_TextBox,
            this.AcPaySlipCd_TextBox,
            this.WarehouseShelfNo_TextBox2,
            this.SectionCode_TextBox2,
            this.SectionGuideNm2});
            this.StockAdjustSlipNoHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.StockAdjustSlipNoHeader.Height = 0.22F;
            this.StockAdjustSlipNoHeader.KeepTogether = true;
            this.StockAdjustSlipNoHeader.Name = "StockAdjustSlipNoHeader";
            this.StockAdjustSlipNoHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.StockAdjustSlipNoHeader.Format += new System.EventHandler(this.StockAdjustSlipNoHeader_Format);
            // 
            // WarehouseCode_TextBox
            // 
            this.WarehouseCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.DataField = "WarehouseCode";
            this.WarehouseCode_TextBox.Height = 0.15F;
            this.WarehouseCode_TextBox.Left = 0.031F;
            this.WarehouseCode_TextBox.MultiLine = false;
            this.WarehouseCode_TextBox.Name = "WarehouseCode_TextBox";
            this.WarehouseCode_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.WarehouseCode_TextBox.Text = "1234";
            this.WarehouseCode_TextBox.Top = 0.031F;
            this.WarehouseCode_TextBox.Width = 0.3F;
            // 
            // StockAdjustSlipNo_TextBox
            // 
            this.StockAdjustSlipNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockAdjustSlipNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAdjustSlipNo_TextBox.DataField = "StockAdjustSlipNo";
            this.StockAdjustSlipNo_TextBox.Height = 0.125F;
            this.StockAdjustSlipNo_TextBox.Left = 3.96F;
            this.StockAdjustSlipNo_TextBox.MultiLine = false;
            this.StockAdjustSlipNo_TextBox.Name = "StockAdjustSlipNo_TextBox";
            this.StockAdjustSlipNo_TextBox.OutputFormat = resources.GetString("StockAdjustSlipNo_TextBox.OutputFormat");
            this.StockAdjustSlipNo_TextBox.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.StockAdjustSlipNo_TextBox.Text = "123456789";
            this.StockAdjustSlipNo_TextBox.Top = 0.031F;
            this.StockAdjustSlipNo_TextBox.Width = 0.55F;
            // 
            // AdjustDate_TextBox
            // 
            this.AdjustDate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AdjustDate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AdjustDate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AdjustDate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AdjustDate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AdjustDate_TextBox.DataField = "AdjustDate";
            this.AdjustDate_TextBox.Height = 0.125F;
            this.AdjustDate_TextBox.Left = 3.335F;
            this.AdjustDate_TextBox.MultiLine = false;
            this.AdjustDate_TextBox.Name = "AdjustDate_TextBox";
            this.AdjustDate_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.AdjustDate_TextBox.Text = "2007/01/01";
            this.AdjustDate_TextBox.Top = 0.031F;
            this.AdjustDate_TextBox.Width = 0.59F;
            // 
            // InputAgenNm_TextBox
            // 
            this.InputAgenNm_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InputAgenNm_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InputAgenNm_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InputAgenNm_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenNm_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InputAgenNm_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            //this.InputAgenNm_TextBox.DataField = "InputAgenNm"; // DEL 2011/11/15 xupz
            this.InputAgenNm_TextBox.DataField = "StockAgenNm"; // ADD 2011/11/15 xupz
            this.InputAgenNm_TextBox.Height = 0.15F;
            this.InputAgenNm_TextBox.Left = 5.6875F;
            this.InputAgenNm_TextBox.MultiLine = false;
            this.InputAgenNm_TextBox.Name = "InputAgenNm_TextBox";
            this.InputAgenNm_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.InputAgenNm_TextBox.Text = "あいうえおかきくけこ";
            this.InputAgenNm_TextBox.Top = 0.031F;
            this.InputAgenNm_TextBox.Width = 1.15F;
            // 
            // WarehouseName_TextBox
            // 
            this.WarehouseName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox.DataField = "WarehouseName";
            this.WarehouseName_TextBox.Height = 0.125F;
            this.WarehouseName_TextBox.Left = 0.344F;
            this.WarehouseName_TextBox.MultiLine = false;
            this.WarehouseName_TextBox.Name = "WarehouseName_TextBox";
            this.WarehouseName_TextBox.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.WarehouseName_TextBox.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.WarehouseName_TextBox.Top = 0.031F;
            this.WarehouseName_TextBox.Width = 2.3125F;
            // 
            // InputAgenCd_TextBox
            // 
            this.InputAgenCd_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InputAgenCd_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenCd_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InputAgenCd_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenCd_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InputAgenCd_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputAgenCd_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InputAgenCd_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            //this.InputAgenCd_TextBox.DataField = "InputAgenCd"; // DEL 2011/11/15 xupz
            this.InputAgenCd_TextBox.DataField = "StockAgenCd"; // ADD 2011/11/15 xupz
            this.InputAgenCd_TextBox.Height = 0.15F;
            this.InputAgenCd_TextBox.Left = 5.375F;
            this.InputAgenCd_TextBox.MultiLine = false;
            this.InputAgenCd_TextBox.Name = "InputAgenCd_TextBox";
            this.InputAgenCd_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.InputAgenCd_TextBox.Text = "1234";
            this.InputAgenCd_TextBox.Top = 0.031F;
            this.InputAgenCd_TextBox.Width = 0.28F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 10.8F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.8F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
            // 
            // InputDay_TextBox
            // 
            this.InputDay_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InputDay_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InputDay_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InputDay_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InputDay_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InputDay_TextBox.DataField = "InputDay";
            this.InputDay_TextBox.Height = 0.125F;
            this.InputDay_TextBox.Left = 2.719F;
            this.InputDay_TextBox.MultiLine = false;
            this.InputDay_TextBox.Name = "InputDay_TextBox";
            this.InputDay_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.InputDay_TextBox.Text = "2007/01/01";
            this.InputDay_TextBox.Top = 0.031F;
            this.InputDay_TextBox.Width = 0.59F;
            // 
            // AcPaySlipCd_TextBox
            // 
            this.AcPaySlipCd_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AcPaySlipCd_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd_TextBox.DataField = "AcPaySlipCd";
            this.AcPaySlipCd_TextBox.Height = 0.125F;
            this.AcPaySlipCd_TextBox.Left = 4.5625F;
            this.AcPaySlipCd_TextBox.MultiLine = false;
            this.AcPaySlipCd_TextBox.Name = "AcPaySlipCd_TextBox";
            this.AcPaySlipCd_TextBox.OutputFormat = resources.GetString("AcPaySlipCd_TextBox.OutputFormat");
            this.AcPaySlipCd_TextBox.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.AcPaySlipCd_TextBox.Text = "あいうえおか";
            this.AcPaySlipCd_TextBox.Top = 0.031F;
            this.AcPaySlipCd_TextBox.Width = 0.75F;
            // 
            // WarehouseShelfNo_TextBox2
            // 
            this.WarehouseShelfNo_TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox2.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo_TextBox2.Height = 0.125F;
            this.WarehouseShelfNo_TextBox2.Left = 7.125F;
            this.WarehouseShelfNo_TextBox2.MultiLine = false;
            this.WarehouseShelfNo_TextBox2.Name = "WarehouseShelfNo_TextBox2";
            this.WarehouseShelfNo_TextBox2.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.WarehouseShelfNo_TextBox2.Text = "12345678";
            this.WarehouseShelfNo_TextBox2.Top = 0.0625F;
            this.WarehouseShelfNo_TextBox2.Width = 0.4375F;
            // 
            // SectionCode_TextBox2
            // 
            this.SectionCode_TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode_TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode_TextBox2.DataField = "SectionCode";
            this.SectionCode_TextBox2.Height = 0.156F;
            this.SectionCode_TextBox2.Left = 7.75F;
            this.SectionCode_TextBox2.MultiLine = false;
            this.SectionCode_TextBox2.Name = "SectionCode_TextBox2";
            this.SectionCode_TextBox2.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.SectionCode_TextBox2.Text = "12";
            this.SectionCode_TextBox2.Top = 0.0625F;
            this.SectionCode_TextBox2.Width = 0.2F;
            // 
            // SectionGuideNm2
            // 
            this.SectionGuideNm2.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideNm2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm2.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideNm2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm2.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideNm2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm2.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideNm2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm2.DataField = "SectionGuideNm";
            this.SectionGuideNm2.Height = 0.125F;
            this.SectionGuideNm2.Left = 8.125F;
            this.SectionGuideNm2.MultiLine = false;
            this.SectionGuideNm2.Name = "SectionGuideNm2";
            this.SectionGuideNm2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.SectionGuideNm2.Text = "あいうえおかきくけこ";
            this.SectionGuideNm2.Top = 0.0625F;
            this.SectionGuideNm2.Width = 1.25F;
            // 
            // StockAdjustSlipNoFooter
            // 
            this.StockAdjustSlipNoFooter.CanShrink = true;
            this.StockAdjustSlipNoFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line,
            this.tb_SumTitle,
            this.Sum_AdjustCountPlus,
            this.Sum_TotalStockUnitPricePlus,
            this.Sum_AdjustCountMinus,
            this.Sum_TotalStockUnitPriceMinus,
            this.TextBox1,
            this.TextBox2});
            this.StockAdjustSlipNoFooter.Height = 0.4270833F;
            this.StockAdjustSlipNoFooter.KeepTogether = true;
            this.StockAdjustSlipNoFooter.Name = "StockAdjustSlipNoFooter";
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
            // tb_SumTitle
            // 
            this.tb_SumTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Height = 0.219F;
            this.tb_SumTitle.Left = 3.625F;
            this.tb_SumTitle.MultiLine = false;
            this.tb_SumTitle.Name = "tb_SumTitle";
            this.tb_SumTitle.OutputFormat = resources.GetString("tb_SumTitle.OutputFormat");
            this.tb_SumTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SumTitle.Text = "伝票計";
            this.tb_SumTitle.Top = 0.125F;
            this.tb_SumTitle.Width = 0.6875F;
            // 
            // Sum_AdjustCountPlus
            // 
            this.Sum_AdjustCountPlus.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountPlus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountPlus.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountPlus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountPlus.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountPlus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountPlus.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountPlus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountPlus.DataField = "AdjustCountPlus";
            this.Sum_AdjustCountPlus.Height = 0.125F;
            this.Sum_AdjustCountPlus.Left = 4.8125F;
            this.Sum_AdjustCountPlus.MultiLine = false;
            this.Sum_AdjustCountPlus.Name = "Sum_AdjustCountPlus";
            this.Sum_AdjustCountPlus.OutputFormat = resources.GetString("Sum_AdjustCountPlus.OutputFormat");
            this.Sum_AdjustCountPlus.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.Sum_AdjustCountPlus.SummaryGroup = "StockAdjustSlipNoHeader";
            this.Sum_AdjustCountPlus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_AdjustCountPlus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_AdjustCountPlus.Text = "12345";
            this.Sum_AdjustCountPlus.Top = 0.0625F;
            this.Sum_AdjustCountPlus.Width = 0.625F;
            // 
            // Sum_TotalStockUnitPricePlus
            // 
            this.Sum_TotalStockUnitPricePlus.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPricePlus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPricePlus.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPricePlus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPricePlus.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPricePlus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPricePlus.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPricePlus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPricePlus.DataField = "TotalStockUnitPricePlus";
            this.Sum_TotalStockUnitPricePlus.Height = 0.125F;
            this.Sum_TotalStockUnitPricePlus.Left = 7.3125F;
            this.Sum_TotalStockUnitPricePlus.MultiLine = false;
            this.Sum_TotalStockUnitPricePlus.Name = "Sum_TotalStockUnitPricePlus";
            this.Sum_TotalStockUnitPricePlus.OutputFormat = resources.GetString("Sum_TotalStockUnitPricePlus.OutputFormat");
            this.Sum_TotalStockUnitPricePlus.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.Sum_TotalStockUnitPricePlus.SummaryGroup = "StockAdjustSlipNoHeader";
            this.Sum_TotalStockUnitPricePlus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_TotalStockUnitPricePlus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_TotalStockUnitPricePlus.Text = "1,012,345,678";
            this.Sum_TotalStockUnitPricePlus.Top = 0.0625F;
            this.Sum_TotalStockUnitPricePlus.Width = 0.8125F;
            // 
            // Sum_AdjustCountMinus
            // 
            this.Sum_AdjustCountMinus.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountMinus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountMinus.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountMinus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountMinus.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountMinus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountMinus.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_AdjustCountMinus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_AdjustCountMinus.DataField = "AdjustCountMinus";
            this.Sum_AdjustCountMinus.Height = 0.125F;
            this.Sum_AdjustCountMinus.Left = 4.8125F;
            this.Sum_AdjustCountMinus.MultiLine = false;
            this.Sum_AdjustCountMinus.Name = "Sum_AdjustCountMinus";
            this.Sum_AdjustCountMinus.OutputFormat = resources.GetString("Sum_AdjustCountMinus.OutputFormat");
            this.Sum_AdjustCountMinus.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.Sum_AdjustCountMinus.SummaryGroup = "StockAdjustSlipNoHeader";
            this.Sum_AdjustCountMinus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_AdjustCountMinus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_AdjustCountMinus.Text = "12345";
            this.Sum_AdjustCountMinus.Top = 0.25F;
            this.Sum_AdjustCountMinus.Width = 0.625F;
            // 
            // Sum_TotalStockUnitPriceMinus
            // 
            this.Sum_TotalStockUnitPriceMinus.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPriceMinus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPriceMinus.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPriceMinus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPriceMinus.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPriceMinus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPriceMinus.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_TotalStockUnitPriceMinus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_TotalStockUnitPriceMinus.DataField = "TotalStockUnitPriceMinus";
            this.Sum_TotalStockUnitPriceMinus.Height = 0.125F;
            this.Sum_TotalStockUnitPriceMinus.Left = 7.3125F;
            this.Sum_TotalStockUnitPriceMinus.MultiLine = false;
            this.Sum_TotalStockUnitPriceMinus.Name = "Sum_TotalStockUnitPriceMinus";
            this.Sum_TotalStockUnitPriceMinus.OutputFormat = resources.GetString("Sum_TotalStockUnitPriceMinus.OutputFormat");
            this.Sum_TotalStockUnitPriceMinus.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.Sum_TotalStockUnitPriceMinus.SummaryGroup = "StockAdjustSlipNoHeader";
            this.Sum_TotalStockUnitPriceMinus.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_TotalStockUnitPriceMinus.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_TotalStockUnitPriceMinus.Text = "-12,345,678";
            this.Sum_TotalStockUnitPriceMinus.Top = 0.25F;
            this.Sum_TotalStockUnitPriceMinus.Width = 0.8125F;
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
            this.TextBox1.Height = 0.125F;
            this.TextBox1.Left = 4.3125F;
            this.TextBox1.MultiLine = false;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox1.Text = "【 + 】";
            this.TextBox1.Top = 0.0625F;
            this.TextBox1.Width = 0.5F;
            // 
            // TextBox2
            // 
            this.TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Height = 0.125F;
            this.TextBox2.Left = 4.3125F;
            this.TextBox2.MultiLine = false;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox2.Text = "【 - 】";
            this.TextBox2.Top = 0.25F;
            this.TextBox2.Width = 0.5F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseCode_TextBox2,
            this.WarehouseName_TextBox2,
            this.line5});
            this.WarehouseHeader.Height = 0.2395833F;
            this.WarehouseHeader.KeepTogether = true;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // WarehouseCode_TextBox2
            // 
            this.WarehouseCode_TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox2.DataField = "WarehouseCode";
            this.WarehouseCode_TextBox2.Height = 0.15F;
            this.WarehouseCode_TextBox2.Left = 0.031F;
            this.WarehouseCode_TextBox2.MultiLine = false;
            this.WarehouseCode_TextBox2.Name = "WarehouseCode_TextBox2";
            this.WarehouseCode_TextBox2.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.WarehouseCode_TextBox2.Text = "1234";
            this.WarehouseCode_TextBox2.Top = 0.0625F;
            this.WarehouseCode_TextBox2.Width = 0.3F;
            // 
            // WarehouseName_TextBox2
            // 
            this.WarehouseName_TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName_TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName_TextBox2.DataField = "WarehouseName";
            this.WarehouseName_TextBox2.Height = 0.125F;
            this.WarehouseName_TextBox2.Left = 0.344F;
            this.WarehouseName_TextBox2.MultiLine = false;
            this.WarehouseName_TextBox2.Name = "WarehouseName_TextBox2";
            this.WarehouseName_TextBox2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.WarehouseName_TextBox2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.WarehouseName_TextBox2.Top = 0.0625F;
            this.WarehouseName_TextBox2.Width = 2.3125F;
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
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.line6});
            this.WarehouseFooter.Height = 0.431F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
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
            this.textBox7.DataField = "TotalStockUnitPriceMinus";
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 7.3125F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.textBox7.SummaryGroup = "WarehouseHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "-12,345,678";
            this.textBox7.Top = 0.25F;
            this.textBox7.Width = 0.8125F;
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
            this.textBox8.DataField = "AdjustCountPlus";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 4.8125F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.textBox8.SummaryGroup = "WarehouseHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "12345";
            this.textBox8.Top = 0.0625F;
            this.textBox8.Width = 0.625F;
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
            this.textBox9.DataField = "TotalStockUnitPricePlus";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 7.3125F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; ";
            this.textBox9.SummaryGroup = "WarehouseHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox9.Text = "-12,345,678";
            this.textBox9.Top = 0.0625F;
            this.textBox9.Width = 0.8125F;
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
            this.textBox10.Height = 0.125F;
            this.textBox10.Left = 4.3125F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox10.Text = "【 + 】";
            this.textBox10.Top = 0.0625F;
            this.textBox10.Width = 0.5F;
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
            this.textBox11.Height = 0.125F;
            this.textBox11.Left = 4.3125F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox11.Text = "【 - 】";
            this.textBox11.Top = 0.25F;
            this.textBox11.Width = 0.5F;
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
            this.textBox12.DataField = "AdjustCountMinus";
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 4.8125F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; ";
            this.textBox12.SummaryGroup = "WarehouseHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "12345";
            this.textBox12.Top = 0.25F;
            this.textBox12.Width = 0.625F;
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
            this.textBox13.Height = 0.219F;
            this.textBox13.Left = 3.625F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox13.Text = "倉庫計";
            this.textBox13.Top = 0.125F;
            this.textBox13.Width = 0.6875F;
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
            // MAZAI02052P_02A4C
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
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.StockAdjustSlipNoHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.StockAdjustSlipNoFooter);
            this.Sections.Add(this.WarehouseFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02052P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02052P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlNote_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitMinus_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCountMinus_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitPlus_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCountPlus_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfStockUnitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAdjustSlipNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAgenNm_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BfStockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDay_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_AdjustCountPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_TotalStockUnitPricePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_AdjustCountMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_TotalStockUnitPriceMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_AdjustCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSum_TotalStockUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_AdjustCountPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_TotalStockUnitPricePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_AdjustCountMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecSum_TotalStockUnitPriceMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAdjustSlipNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdjustDate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAgenNm_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAgenCd_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputDay_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipCd_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_AdjustCountPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_TotalStockUnitPricePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_AdjustCountMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_TotalStockUnitPriceMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName_TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        //--- ADD 2008/07/07 ---------->>>>>
        /// <summary>
        /// SectionHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : SectionHeader_Format時の処理</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.07</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
        /// </remarks>
        private void SectionHeader_Format(object sender, EventArgs e)
        {
            // ------- UPD 2010/11/15 ------------------>>>>>
            // 仕入日順の場合
            if (this._extrInfo.OutputSort == 0)
            {
                // 改頁(拠点)
                if (this._extrInfo.ChangePage == 0)
                {
                    this.SectionHeader.NewPage = NewPage.Before;
                }
                // 改頁(倉庫)
                else if (this._extrInfo.ChangePage == 1)
                {
                    this.SectionHeader.NewPage = NewPage.Before;
                }
                // 改頁(しない)
                else if (this._extrInfo.ChangePage == 2)
                {
                    this.SectionHeader.NewPage = NewPage.None;
                }
            }
            // 棚番順の場合
            else
            {
                // なし
            }
            //// 改頁(拠点)
            //if (this._extrInfo.ChangePage == 0)
            //{
            //    this.SectionHeader.NewPage = NewPage.Before;
            //}
            //// 改頁(倉庫)
            //else if (this._extrInfo.ChangePage == 1)
            //{
            //    this.SectionHeader.NewPage = NewPage.Before;
            //}
            //// 改頁(しない)
            //else if (this._extrInfo.ChangePage == 2)
            //{
            //    this.SectionHeader.NewPage = NewPage.None;
            //}
            // ------- UPD 2010/11/15 ------------------<<<<<

            // 改頁、拠点変更のタイミングで必ず拠点情報を印字
            this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;     //ADD 2008/10/07
        }

        /// <summary>
        /// StockAdjustSlipNoHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : StockAdjustSlipNoHeader_Format時の処理</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.07</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
        /// </remarks>
        private void StockAdjustSlipNoHeader_Format(object sender, EventArgs e)
        {
            // ------- UPD 2010/11/15 ------------------>>>>>
            // 仕入日順の場合
            if (this._extrInfo.OutputSort == 0)
            {
                // 改頁(拠点)
                if (this._extrInfo.ChangePage == 0)
                {
                    this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
                }
                // 改頁(倉庫)
                else if (this._extrInfo.ChangePage == 1)
                {
                    if (this._beforeWarehouseCode == null)
                    {
                        this._beforeWarehouseCode = this.WarehouseCode_TextBox.Text;
                        this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
                    }
                    else if (this._beforeWarehouseCode == this.WarehouseCode_TextBox.Text)
                    {
                        this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
                    }
                    else if (this._beforeSectionCode == this.SectionCode_TextBox.Text)
                    {
                        this._beforeWarehouseCode = this.WarehouseCode_TextBox.Text;
                        this.StockAdjustSlipNoHeader.NewPage = NewPage.Before;
                    }
                    else
                    {
                        this._beforeWarehouseCode = this.WarehouseCode_TextBox.Text;
                        this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
                    }
                }
                // 改頁(しない)
                else if (this._extrInfo.ChangePage == 2)
                {
                    this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
                }
            }
            // 棚番順の場合
            else
            {
                // なし
            }
            //// 改頁(拠点)
            //if (this._extrInfo.ChangePage == 0)
            //{
            //    this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
            //}
            //// 改頁(倉庫)
            //else if (this._extrInfo.ChangePage == 1)
            //{
            //    if (this._beforeWarehouseCode == null)
            //    {
            //        this._beforeWarehouseCode = this.WarehouseCode_TextBox.Text;
            //        this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
            //    }
            //    else if (this._beforeWarehouseCode == this.WarehouseCode_TextBox.Text)
            //    {
            //        this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
            //    }
            //    else if (this._beforeSectionCode == this.SectionCode_TextBox.Text)
            //    {
            //        this._beforeWarehouseCode = this.WarehouseCode_TextBox.Text;
            //        this.StockAdjustSlipNoHeader.NewPage = NewPage.Before;
            //    }
            //    else
            //    {
            //        this._beforeWarehouseCode = this.WarehouseCode_TextBox.Text;
            //        this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
            //    }
            //}
            //// 改頁(しない)
            //else if (this._extrInfo.ChangePage == 2)
            //{
            //    this.StockAdjustSlipNoHeader.NewPage = NewPage.None;
            //}
            // ------- UPD 2010/11/15 ------------------<<<<<

            this._beforeSectionCode = this.SectionCode_TextBox.Text;

            // ---ADD 2009/03/10 不具合対応[12263] ----------------------------------->>>>>
            //13:在庫仕入、42:マスタメンテ、50:棚卸、60：組立、61：分解、70：補充入庫、71：補充出庫
            if ((int)AcPaySlipCd_TextBox.Value == 13)
            {
                AcPaySlipCd_TextBox.Text = "在庫仕入";
            }
            else if ((int)AcPaySlipCd_TextBox.Value == 42)
            {
                AcPaySlipCd_TextBox.Text = "マスタメンテ";
            }
            else if ((int)AcPaySlipCd_TextBox.Value == 50)
            {
                AcPaySlipCd_TextBox.Text = "棚卸";
            }
            else if ((int)AcPaySlipCd_TextBox.Value == 60)
            {
                AcPaySlipCd_TextBox.Text = "組立";
            }
            else if ((int)AcPaySlipCd_TextBox.Value == 61)
            {
                AcPaySlipCd_TextBox.Text = "分解";
            }
            else if ((int)AcPaySlipCd_TextBox.Value == 70)
            {
                AcPaySlipCd_TextBox.Text = "補充入庫";
            }
            else if ((int)AcPaySlipCd_TextBox.Value == 71)
            {
                AcPaySlipCd_TextBox.Text = "補充出庫";
            }
            else
            {
                AcPaySlipCd_TextBox.Text = "";
            }
            // ---ADD 2009/03/10 不具合対応[12263] -----------------------------------<<<<<
        }
        //--- ADD 2008/07/07 ----------<<<<<
    }
}
