//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入確認表
// プログラム概要   : 仕入確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 立花 裕輔
// 作 成 日  2007/09/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/07/16  修正内容 : データ項目の追加/修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/09/24  修正内容 : 帳票レイアウトのみ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/13  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13157
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 障害対応12394,12396,12401
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 消費税転嫁方式[伝票][明細]以外は非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/08  修正内容 : MANTIS【13232】改頁時の拠点出力不具合を修正
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : cheq
// 修 正 日  2012/12/26  修正内容 :2013/03/13配信分
//                                 Redmine#34098 罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/21  修正内容 :2013/03/13配信分
//                                 Redmine#34098 罫線印字制御の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 作成担当 : wangf
// 修 正 日  2013/06/21  修正内容 : PM1300A（配信日なし分）、Redmine#36826の対応
//                                : 帳票印字する時に、伝票枚数の表示桁数を変更し、デザインファイルの修正
//---------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 尹安
// 作 成 日  2020/02/27  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11800255-00 作成担当 : 陳艶丹
// 作 成 日  2022/09/28  修正内容 : インボイス対応（税率別合計金額不具合修正）
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
	/// 仕入確認表（明細タイプ）印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 仕入確認表（明細タイプ）のフォームクラスです。</br>
	/// <br>Programmer	: 96186 立花 裕輔</br>
	/// <br>Date		: 2007.09.03</br>
    /// <br>Programmer	: 30415 柴田 倫幸</br>
    /// <br>Date		: 2008/07/16 データ項目の追加/修正</br>
    /// <br>Programmer	: 980035 金沢 貞義</br>
    /// <br>Date		: 2008/09/24 帳票レイアウトのみ変更</br>
    /// <br>UpdateNote  : 2008/11/13 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Update Note : 2009/04/07 30452 上野 俊治</br>
    /// <br>            ・障害対応13157</br>
    /// <br>Update Note : 2009/04/14 30452 上野 俊治</br>
    /// <br>            ・障害対応12394,12396,12401</br>
    /// <br>Update Note : 2009/04/14 30452 上野 俊治</br>
    /// <br>            ・消費税転嫁方式[伝票][明細]以外は非表示に修正</br>
    /// <br>Update Note : 2012/12/26 cheq</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// <br>Update Note : 2013/02/21 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// <br>Update Note : 2013/06/21 wangf </br>
    /// <br>管理番号    : 10802197-00 PM1300A（配信日なし分）</br>
    /// <br>            : Redmine#36826の対応</br>
    /// <br>            : 帳票印字する時に、伝票枚数の表示桁数を変更し、デザインファイルの修正。</br>
    /// <br>UpdateNote  : 2020/02/27 3H 尹安</br>
    /// <br>管理番号    : 11570208-00 軽減税率対応</br>
    /// <br></br>
	/// </remarks>
	public class MAKON02243P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 仕入確認表（明細タイプ）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 仕入確認表（明細タイプ）フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 96186　立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		public MAKON02243P_01A4C()
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

		private ExtrInfo_MAKON02247E _extraInfo;

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

		// サプレスバッファ
		private Label label6;
		private Label label10;
		private TextBox groupFooter1Title;
		private TextBox SectionHeaderLine;
		private Label Lb_TitleHeaderSub;
		private TextBox textBox8;
		private Line upline_SectionHeader;
		private Line bottomline_TitleHeader;
		private Label label13;
		private Label label17;
		private TextBox textBox12;
		private Label label14;
		private TextBox textBox23;
		private Label label20;
		private TextBox textBox5;
        private TextBox g_SalesGrsProfit;
		private TextBox textBox1;
		private TextBox textBox2;
		private Label label1;
		private Label label4;
		private TextBox textBox21;
		private TextBox textBox22;
		private Label label5;
		private Label label7;
		private Label label8;
        private Label label9;
		private Label label16;
		private TextBox textBox24;
		private Label label18;
		private Label label19;
		private TextBox textBox25;
		private TextBox textBox26;
        private TextBox textBox27;
		private TextBox textBox29;
		private TextBox textBox30;
		private TextBox textBox31;
		private TextBox textBox32;
		private GroupHeader groupHeader1;
		private GroupFooter groupFooter1;
		private GroupHeader groupHeader2;
		private GroupFooter groupFooter2;
        private TextBox textBox6;
		private Line line3;
        private TextBox textBox3;
		private TextBox groupFooter2Title;
		private Line line2;
		private TextBox DailyFooterTitle;
		private TextBox textBox10;
		private TextBox DailyFooter_TaxRF;
		private Line line4;
        private Label label21;
        private TextBox textBox9;
        private TextBox textBox11;
        private Label label22;
        private Label label11;
        private Label label24;
        private Label label25;
        private Label label26;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private GroupHeader groupHeader3;
        private GroupFooter groupFooter3;
        private TextBox tg_SalesGrsProfit;
        private Label GrandTotalTitle;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox28;
        private TextBox textBox33;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox38;
        private TextBox textBox40;
        private TextBox textBox42;
        private TextBox textBox44;
        private TextBox textBox46;
        private TextBox textBox48;
        private TextBox textBox50;
        private TextBox textBox51;
        private TextBox textBox52;
        private TextBox textBox53;
        private TextBox textBox54;
        private TextBox textBox55;
        private TextBox textBox56;
        private TextBox textBox57;
        private TextBox textBox58;
        private TextBox textBox59;
        private TextBox textBox60;
        private TextBox textBox61;
        private TextBox textBox62;
        private TextBox textBox63;
        private TextBox textBox64;
        private TextBox textBox65;
        private TextBox textBox66;
        private TextBox textBox67;
        private Label label15;
        private Label label27;
        private Label label12;
        private Label label29;
        private Label label30;
        private Line line6;
        private TextBox textBox68;
        private TextBox textBox69;
        private TextBox textBox70;
        private TextBox textBox71;
        private TextBox textBox72;
        private TextBox textBox73;
        private TextBox textBox74;
        private TextBox textBox75;
        private TextBox textBox76;
        private TextBox textBox77;
        private TextBox textBox79;
        private TextBox suppTtlAmntDspWayCdRFTextBox;
        private TextBox suppCTaxLayCdRFTextBox;
        private TextBox taxationCodeTextBox;
        private TextBox textBox81;
        private TextBox textBox82;
        private TextBox textBox85;
        private TextBox textBox86;
        private TextBox textBox84;
        private TextBox textBox87;
        private TextBox textBox90;
        private TextBox textBox91;
        private Line line5;
        private TextBox DailyFooter_suppCTaxLayCdRFTextBox;
        private TextBox SupplierConsTaxRate;
        private Label label28;
        private GroupHeader TitleHeader2;
        private GroupFooter TitleFooter2;
        private GroupHeader SectionHeader2;
        private GroupFooter SectionFooter2;
        private GroupHeader groupHeader1_2;
        private GroupFooter groupFooter1_2;
        private GroupHeader groupHeader2_2;
        private GroupFooter groupFooter2_2;
        private TextBox textBox13;
        private TextBox groupFooter2Title_2;
        private TextBox textBox41;
        private TextBox textBox43;
        private TextBox textBox45;
        private TextBox textBox47;
        private TextBox textBox49;
        private TextBox textBox78;
        private TextBox textBox80;
        private TextBox textBox83;
        private TextBox textBox88;
        private TextBox textBox89;
        private TextBox textBox92;
        private TextBox textBox93;
        private TextBox textBox94;
        private TextBox textBox95;
        private TextBox textBox96;
        private TextBox textBox97;
        private TextBox textBox98;
        private TextBox textBox99;
        private TextBox textBox100;
        private TextBox textBox101;
        private TextBox textBox102;
        private TextBox textBox103;
        private Label label31;
        private Label label32;
        private Label label33;
        private TextBox textBox104;
        private TextBox textBox105;
        private TextBox textBox106;
        private TextBox textBox107;
        private TextBox textBox108;
        private TextBox textBox109;
        private TextBox textBox110;
        private TextBox textBox111;
        private TextBox textBox112;
        private Label label34;
        private Label label35;
        private Label label36;
        private TextBox textBox113;
        private TextBox groupFooter1Title_2;
        private TextBox textBox115;
        private TextBox textBox116;
        private TextBox textBox117;
        private TextBox textBox118;
        private TextBox textBox119;
        private TextBox textBox120;
        private TextBox textBox121;
        private TextBox textBox122;
        private TextBox textBox123;
        private TextBox textBox124;
        private TextBox textBox125;
        private TextBox textBox126;
        private TextBox textBox127;
        private TextBox textBox128;
        private TextBox textBox129;
        private TextBox textBox130;
        private TextBox textBox131;
        private TextBox textBox132;
        private TextBox textBox133;
        private TextBox textBox134;
        private TextBox textBox135;
        private TextBox textBox136;
        private Label label37;
        private Label label38;
        private Label label39;
        private TextBox textBox137;
        private TextBox textBox138;
        private TextBox textBox139;
        private TextBox textBox140;
        private TextBox textBox141;
        private TextBox textBox142;
        private TextBox textBox143;
        private TextBox textBox144;
        private TextBox textBox145;
        private Label label40;
        private Label label41;
        private Label label42;
        private TextBox textBox146;
        private TextBox textBox148;
        private TextBox textBox149;
        private TextBox textBox150;
        private TextBox textBox151;
        private TextBox textBox152;
        private TextBox textBox153;
        private TextBox textBox154;
        private TextBox textBox155;
        private TextBox textBox156;
        private TextBox textBox157;
        private TextBox textBox158;
        private TextBox textBox159;
        private TextBox textBox160;
        private TextBox textBox161;
        private TextBox textBox162;
        private TextBox textBox163;
        private TextBox textBox164;
        private TextBox textBox165;
        private TextBox textBox166;
        private TextBox textBox167;
        private TextBox textBox168;
        private TextBox textBox169;
        private Label label43;
        private Label label44;
        private Label label45;
        private TextBox textBox170;
        private TextBox textBox171;
        private TextBox textBox172;
        private TextBox textBox173;
        private TextBox textBox174;
        private TextBox textBox175;
        private TextBox textBox176;
        private TextBox textBox177;
        private TextBox textBox178;
        private Label label46;
        private Label label47;
        private TextBox SectionTitle_2;
        private TextBox textBox147;
        private TextBox textBox180;
        private TextBox textBox181;
        private TextBox textBox182;
        private TextBox textBox183;
        private TextBox textBox184;
        private TextBox textBox185;
        private TextBox textBox186;
        private TextBox textBox187;
        private TextBox textBox188;
        private TextBox textBox189;
        private TextBox textBox190;
        private TextBox textBox191;
        private TextBox textBox192;
        private TextBox textBox193;
        private TextBox textBox194;
        private TextBox textBox195;
        private TextBox textBox196;
        private TextBox textBox197;
        private TextBox textBox198;
        private TextBox textBox199;
        private TextBox textBox200;
        private TextBox textBox201;
        private Label label49;
        private Label label50;
        private Label label51;
        private TextBox textBox202;
        private TextBox textBox203;
        private TextBox textBox204;
        private TextBox textBox205;
        private TextBox textBox206;
        private TextBox textBox207;
        private TextBox textBox208;
        private TextBox textBox209;
        private TextBox textBox210;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label GrandTotalTitle_2;
        private Line line7;
        private Line line8;
        private Line line10;
        private Line line9;
        private TextBox textBox4;
        private TextBox textBox7;
        private Label label55;
        private TextBox textBox39;
        private TextBox textBox114;
        private TextBox textBox179;
        private Label label56;
        private TextBox textBox211;
        private TextBox textBox212;
        private TextBox textBox213;
        private Label label57;
        private TextBox textBox214;
        private TextBox textBox215;
        private Label label58;
        private TextBox textBox216;
        private TextBox textBox217;
        private TextBox textBox218;
        private TextBox textBox219;
        private Label label59;
        private TextBox textBox220;
        private Label label60;
        private TextBox textBox224;
        private TextBox textBox225;
        private Label label61;
        private TextBox textBox226;
        private TextBox textBox221;
        private TextBox textBox222;
        private Label label48;
        private TextBox textBox223;
        private TextBox textBox227;
        private TextBox textBox228;
        private Label label62;
        private TextBox textBox229;
		private Label label23;

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
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2013/02/21 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
        /// <br>Update Note : 2020/02/27 尹安</br>
        /// <br>管理番号    : 11570208-00 軽減税率対応</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;

			// 条件取得
			this._extraInfo = (ExtrInfo_MAKON02247E)this._printInfo.jyoken;

			// 印字設定 --------------------------------------------------------------------------------------
			// 拠点計を出力するかしないかを選択する
			// 拠点有無を判断
			//if ( this._stockSalesRsltExtract.IsOptSection )
			//{
			//	// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
			//	if ((this._stockSalesRsltExtract.SectionCode.Length < 2) || 
			//		this._stockSalesRsltExtract.IsSelectAllSection )
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
			// ソート条件     
			//SortTitle.Text = this._pageHeaderSortOderTitle;     

			// タイトル項目の名称をセット
			//tb_ReportTitle.Text = this._pageHeaderTitle;


			//仕入先→伝票日付→伝票番号
			//if(this._extraInfo.SortOrder == 1)  // DEL 2008/07/16
            if ((this._extraInfo.SortOrder == 1) || (this._extraInfo.SortOrder == 5))  // ADD 2008/07/16
			{
				//groupHeader2
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                if (this._extraInfo.TaxPrintDiv == 1)
                {
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    groupHeader2.Visible = true;
                    groupHeader2.DataField = "groupHeader2DataField";
                    groupFooter2.Visible = true;
                    groupFooter2Title.Text = "仕入日計";
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>

                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;

                    TitleFooter2.Visible = false;
                    SectionFooter2.Visible = false;
                    groupFooter1_2.Visible = false;
                    groupFooter2_2.Visible = false;
                }
                else
                {
                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;
                    TitleFooter.Visible = false;
                    SectionFooter.Visible = false;
                    groupFooter1.Visible = false;
                    groupFooter2.Visible = false;

                    TitleFooter2.Visible = true;
                    SectionFooter2.Visible = true;
                    groupFooter1_2.Visible = true;
                    groupHeader2.Visible = true;
                    groupHeader2.DataField = "groupHeader2DataField";
                    groupFooter2_2.Visible = true;
                    groupFooter2Title_2.Text = "仕入日計";

                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
			//仕入先→入力日付→伝票番号
            //else if (this._extraInfo.SortOrder == 3)  // DEL 2008/07/16
            else if ((this._extraInfo.SortOrder == 3) || (this._extraInfo.SortOrder == 6))  // ADD 2008/07/16
			{
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                if (this._extraInfo.TaxPrintDiv == 1)
                {
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    //groupHeader2
                    groupHeader2.Visible = true;
                    groupHeader2.DataField = "groupHeader2DataField";
                    groupFooter2.Visible = true;
                    groupFooter2Title.Text = "入力日計";
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>

                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;

                    TitleFooter2.Visible = false;
                    SectionFooter2.Visible = false;
                    groupFooter1_2.Visible = false;
                    groupFooter2_2.Visible = false;
                }
                else
                {
                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;

                    TitleFooter.Visible = false;
                    SectionFooter.Visible = false;
                    groupFooter1.Visible = false;
                    groupFooter2.Visible = false;

                    TitleFooter2.Visible = true;
                    SectionFooter2.Visible = true;
                    groupFooter1_2.Visible = true;
                    groupHeader2.Visible = true;
                    groupHeader2.DataField = "groupHeader2DataField";
                    groupFooter2_2.Visible = true;
                    groupFooter2Title_2.Text = "入力日計";
                }

                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
			//仕入先→伝票番号
			else 
			{
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                if (this._extraInfo.TaxPrintDiv == 1)
                {
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    //Daily
                    groupHeader2.Visible = false;
                    groupHeader2.DataField = "";
                    groupFooter2.Visible = false;
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>

                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;

                    TitleFooter2.Visible = false;
                    SectionFooter2.Visible = false;
                    groupFooter1_2.Visible = false;
                    groupFooter2_2.Visible = false;
                }
                else
                {
                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;
                    TitleFooter.Visible = false;
                    SectionFooter.Visible = false;
                    groupFooter1.Visible = false;
                    groupFooter2.Visible = false;

                    TitleFooter2.Visible = true;
                    SectionFooter2.Visible = true;
                    groupFooter1_2.Visible = true;
                    groupHeader2.Visible = false;
                    groupHeader2.DataField = "";
                    groupFooter2_2.Visible = true;
                }

                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
			}

            // --- ADD 2009/04/14 -------------------------------->>>>>
            // 日計印字制御
            if (this._extraInfo.PrintDailyFooter == 0)
            {
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                if (this._extraInfo.TaxPrintDiv == 1)
                {
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    groupFooter2.Visible = false;
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>

                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;

                    TitleFooter2.Visible = false;
                    SectionFooter2.Visible = false;
                    groupFooter1_2.Visible = false;
                    groupFooter2_2.Visible = false;
                }
                else
                {
                    TitleHeader2.Visible = false;
                    SectionHeader2.Visible = false;
                    groupHeader1_2.Visible = false;
                    groupHeader2_2.Visible = false;

                    TitleFooter.Visible = false;
                    SectionFooter.Visible = false;
                    groupFooter1.Visible = false;
                    groupFooter2.Visible = false;
                    groupFooter2_2.Visible = false;

                    groupFooter1_2.Visible = true;
                    TitleFooter2.Visible = true;
                    SectionFooter2.Visible = true;
                }

                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            // --- ADD 2009/04/14 --------------------------------<<<<<
            
            // --- ADD 2008/07/16 -------------------------------->>>>>
            if (this._extraInfo.NewPageKind == 0)
            {
                this.SectionHeader.DataField = "SectionCodeRF";
                this.SectionHeader.NewPage = NewPage.Before;
                //this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;                  // DEL 2009/05/08
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;     // ADD 2009/05/08

                this.groupHeader3.DataField = "";
                this.groupHeader3.NewPage = NewPage.None;
                this.groupHeader3.RepeatStyle = RepeatStyle.None;
            }
            else if (this._extraInfo.NewPageKind == 1)
            {
                this.SectionHeader.DataField = "SectionCodeRF";
                this.SectionHeader.NewPage = NewPage.Before;
                //this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;                  // DEL 2009/05/08
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;     // ADD 2009/05/08

                this.groupHeader3.DataField = "SupplierCd";
                this.groupHeader3.NewPage = NewPage.Before;
                this.groupHeader3.RepeatStyle = RepeatStyle.OnPage;
            }
            else if (this._extraInfo.NewPageKind == 2)
            {
                this.SectionHeader.DataField = "SectionCodeRF";
                this.SectionHeader.NewPage = NewPage.None;
                //this.SectionHeader.RepeatStyle = RepeatStyle.None;                    // DEL 2009/05/08
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;     // ADD 2009/05/08

                this.groupHeader3.DataField = "";
                this.groupHeader3.NewPage = NewPage.None;
                this.groupHeader3.RepeatStyle = RepeatStyle.None;
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>> 
            //罫線印字『印字する』の場合
            if (_extraInfo.LinePrintDiv == 0)
            {
                //this.bottomline_TitleHeader.Visible = false;// DEL 2013/02/21 王君 Redmine#34098
                this.bottomline_TitleHeader.Visible = true;// ADD 2013/02/21 王君 Redmine#34098
                this.upline_SectionHeader.Visible = true;
                this.line6.Visible = true;
                this.line5.Visible = true;
                this.line4.Visible = true;
                this.line2.Visible = true;
                this.line3.Visible = true;
                this.Line45.Visible = true;
                this.Line41.Visible = true;
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                this.line7.Visible = true;
                this.line8.Visible = true;
                this.line9.Visible = true;
                this.line10.Visible = true;
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            // 罫線印字『印字しない』の場合
            else 
            {
                this.bottomline_TitleHeader.Visible = true;
                //this.upline_SectionHeader.Visible = false;// DEL 2013/02/21 王君 Redmine#34098
                this.upline_SectionHeader.Visible = true;// ADD 2013/02/21 王君 Redmine#34098
                this.line6.Visible = false;
                this.line5.Visible = false;
                this.line4.Visible = false;
                this.line2.Visible = false;
                this.line3.Visible = false;
                this.Line45.Visible = false;
                this.Line41.Visible = false;
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                this.line7.Visible = false;
                this.line8.Visible = false;
                this.line9.Visible = false;
                this.line10.Visible = false;
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            if (this._extraInfo.TaxPrintDiv == 1)
            {
                this.label28.Visible = false;
            }else
            {
                this.label28.Visible = true;
            }

            // --- ADD END 3H 尹安 2020/02/27 ----->>>>>
#if False
			//全社 拠点単位の判定
			bool TtlTypeBool = true;

			//帳票種別 0:拠点別 1:仕入先別
			//帳票種別 0:拠点別
			if (this._stockSalesRsltExtract.PrintType == 0)
			{
				//Daily
				DailyHeader.DataField = "";
				DailyHeader.Visible = false;
				DailyFooter.Visible = false;
				DailyTitle.Visible = false;
				DailyTitle.Text = "";

				//WareHouse
				WareHouseHeader.DataField = "";
				WareHouseHeader.Visible = false;
				WareHouseFooter.Visible = false;

				//Section
				SectionHeader.NewPage = NewPage.None;
				SectionHeader.DataField = "";
				SectionHeader.Visible = false;
				SectionFooter.Visible = false;
				SectionTitle.Visible = false;
				SectionTitle.Text = "";
				SectionHeaderLine.DataField = "";
				SectionHeaderLine.Visible = false;

				//Title
				Lb_TitleHeader.Text = "";
				Lb_TitleHeader.Visible = false;
				Lb_TitleHeaderSub.Text = "拠点";
				Lb_TitleHeader.Visible = true;
				upline_SectionHeader.Visible = false;
				bottomline_TitleHeader.Visible = true;
			}
			//帳票種別 1:仕入先別
			else if (this._stockSalesRsltExtract.PrintType == 1)
			{
				//Daily
				DailyHeader.DataField = "";
				DailyHeader.Visible = false;
				DailyFooter.Visible = false;
				DailyTitle.Visible = false;
				DailyTitle.Text = "仕入先計";

				//WareHouse
				WareHouseHeader.DataField = "";
				WareHouseHeader.Visible = false;
				WareHouseFooter.Visible = false;

				//Section
				SectionHeader.NewPage = (NewPage)_stockSalesRsltExtract.CrMode;
				SectionHeader.DataField = "SectionHeaderField";
				SectionHeader.Visible = true;
				SectionFooter.Visible = TtlTypeBool;
				SectionTitle.Visible = TtlTypeBool;
				SectionTitle.Text = "拠点計";
				SectionHeaderLine.DataField = "SectionHeaderLine";
				SectionHeaderLine.Visible = TtlTypeBool;

				//Title
				Lb_TitleHeader.Text = "拠点";
				Lb_TitleHeader.Visible = true;
				Lb_TitleHeaderSub.Text = "仕入先";
				Lb_TitleHeader.Visible = true;

				upline_SectionHeader.Visible = true;
				bottomline_TitleHeader.Visible = false;
			}
#endif
		}
		#endregion ◆ レポート要素出力設定

		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{

#if False
			this._sectionCodeSuppresBuf = this.SectionCode.Text.Trim();
			this._stockAgentCodeSuppresBuf = this.DetailLine.Text.Trim();
			this._customerCodeSuppresBuf = this.CustomerCode.Text.Trim();
#endif

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

#if False
			//グループサプレス項目値の保存
			this._sectionCodeSuppresBuf = this.SectionCode.Text.Trim();
			this._stockAgentCodeSuppresBuf = this.DetailLine.Text.Trim();
			this._customerCodeSuppresBuf = this.CustomerCode.Text.Trim();
#endif


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
			    if ( this._stockSalesRsltExtract.StockMoveFormalDiv == StockSalesRsltExtract.StockMoveFormalDivState.StockMove )
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

        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
        /// <summary>
        /// 値が0ならテキストボックスを隠します。
        /// </summary>
        /// <param name="numberOftextBox">テキストボックス</param>
        /// <returns>
        /// <c>true</c> :隠しました。<br/>
        /// <c>false</c>:隠しませんでした。
        /// </returns>
        public static bool HideTextBoxIfNumberIsZero(TextBox numberOftextBox)
        {
            int number = 0;
            if (int.TryParse(numberOftextBox.Text, out number))
            {
                if (number.Equals(0))
                {
                    numberOftextBox.Visible = false;
                }
                else
                {
                    numberOftextBox.Visible = true;
                }
            }
            else
            {
                numberOftextBox.Visible = true;
            }

            return !numberOftextBox.Visible;
        }
        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

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
			// ソート順
			this.SortTitle.Text = this._pageHeaderSortOderTitle;

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
			string sectionTitle = "";
			//string sectionTitle = string.Format("{0}拠点：", this._stockSalesRsltExtract.MainExtractTitle);
			//if ( this._stockSalesRsltExtract.IsOptSection )
			//{
				if ( this._stockSalesRsltExtract.IsSelectAllSection )
				{
					this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
				}
				else
				{
					this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
				}

			//} 
			//else 
			//{
			//	this._rptExtraHeader.SectionCondition.Text = "";
			//}
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
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
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
		/// <br>Update Note : 11570208-00 軽減税率対応</br>
		/// <br>Programmer	: 3H 尹安</br>
		/// <br>Date		: 2020/02/27</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
			// グループサプレスの判断
			this.CheckGroupSuppression();
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>]
            // 2009.01.13 30413 犬飼 売上確認表と同様に消費税転嫁方式で印字制御を行う >>>>>>START
            // TODO:消費税の印字
            // 消費税が\0の場合、印字しない
            //if (HideTextBoxIfNumberIsZero(this.RetGdsDayTotal))
            //{
            //    return;
            //}
            if (this.DisDayMonthTotal.Value == DBNull.Value)
            {
                // 金額がNullの場合はゼロを設定
                this.DisDayMonthTotal.Value = 0;
            }
            if (this.RetGdsDayTotal.Value == DBNull.Value)
            {
                // 消費税がNullの場合はゼロを設定
                this.RetGdsDayTotal.Value = 0;
            }
            // 2009.01.13 30413 犬飼 売上確認表と同様に消費税転嫁方式で印字制御を行う <<<<<<END
            
            int suppCTaxLayCd       = int.Parse(this.suppCTaxLayCdRFTextBox.Text);          // 転嫁方式
            int suppTtlAmntDspWayCd = int.Parse(this.suppTtlAmntDspWayCdRFTextBox.Text);    // 総額表示
            int taxationCode        = int.Parse(this.taxationCodeTextBox.Text);             // 課税区分
            // 転嫁方式：伝票単位の時
            if (suppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip))
            {
                //this.RetGdsDayTotal.Visible = false;    // 消費税を印字しない DEL 3H 尹安 2020/02/27 
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                if (HideTextBoxIfNumberIsZero(this.RetGdsDayTotal))
                {
                    this.RetGdsDayTotal.Visible = false;    // 消費税を印字しない
                    this.SupplierConsTaxRate.Visible = false;
                }else
                {
                    this.RetGdsDayTotal.Visible = true;    // 消費税を印字する
                    this.SupplierConsTaxRate.Visible = true;
                }

                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            // 転嫁方式：明細単位、総額表示ありの時
            /* --- DEL 2008/11/13 「仕入先消費税転嫁方式コード」が「1：明細単位」で「仕入先総額表示方法区分」が「0：総額表示しない」は
             * 　　　　　　　　　　ありえない為、「仕入先消費税転嫁方式コード」だけで判定を行う -------------------------------------------->>>>>
            else if (
                suppCTaxLayCd.Equals((int)SuppCTaxLayCd.ByDetails)
                    &&
                suppTtlAmntDspWayCd.Equals((int)SuppTtlAmntDspWayCd.Shown)
            )
               --- DEL 2008/11/13 ----------------------------------------------------------------------------------------------------------<<<<< */
            else if (suppCTaxLayCd.Equals((int)SuppCTaxLayCd.ByDetails))            //ADD 2008/11/13
            {
                // 課税区分が非課税以外なら消費税を印字
                if (!taxationCode.Equals((int)TaxationCode.TaxExemption))
                {
                    //this.RetGdsDayTotal.Visible = true;//  DEL 3H 尹安 2020/02/27 
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    if (HideTextBoxIfNumberIsZero(this.RetGdsDayTotal))
                    {
                        this.RetGdsDayTotal.Visible = false;    // 消費税を印字しない
                        this.SupplierConsTaxRate.Visible = false;
                    }
                    else
                    {
                        this.RetGdsDayTotal.Visible = true;    // 消費税を印字する
                        this.SupplierConsTaxRate.Visible = true;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
                else
                {
                    this.RetGdsDayTotal.Visible = false;
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    this.SupplierConsTaxRate.Visible = false;
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
            }
            // 転嫁方式：請求親・請求子・非課税の時
            else
            {
                // --- DEL 2009/04/14 -------------------------------->>>>>
                //// 課税区分が内税なら消費税を印字
                //if (taxationCode.Equals((int)TaxationCode.TaxIncluded))
                //{
                //    this.RetGdsDayTotal.Visible = true;
                //}
                //else
                //{
                //    this.RetGdsDayTotal.Visible = false;
                //}
                // --- DEL 2009/04/14 --------------------------------<<<<<
                this.RetGdsDayTotal.Visible = false;
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                this.SupplierConsTaxRate.Visible = false;
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<
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
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 >>>>>>START
            //// ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
            //// TODO:伝票計
            //HideTextBoxIfNumberIsZero(this.textBox13);
            //// ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 <<<<<<END
        }

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 >>>>>>START
            //// ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
            //// TODO:拠点計
            //HideTextBoxIfNumberIsZero(this.textBox45);
            //HideTextBoxIfNumberIsZero(this.textBox43);
            //HideTextBoxIfNumberIsZero(this.g_Cost);
            //// ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 >>>>>>START
            //HideTextBoxIfNumberIsZero(this.textBox83);
            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 <<<<<<END
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 <<<<<<END
        }

		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
		}

		//private void WareHouseFooter_Format(object sender, System.EventArgs eArgs)
		//{
		//}
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

                //#if False // DEL 2009/04/07
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
                //#endif // DEL 2009/04/07
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
		private DataDynamics.ActiveReports.TextBox SortTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_TitleHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.GroupHeader DailyHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox DetailLine;
		private DataDynamics.ActiveReports.TextBox NetStcPrcDayTotal;
		private DataDynamics.ActiveReports.TextBox RetGdsDayTotal;
		private DataDynamics.ActiveReports.TextBox StckPriceMonthTotal;
		private DataDynamics.ActiveReports.TextBox DisDayMonthTotal;
		private DataDynamics.ActiveReports.GroupFooter DailyFooter;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.TextBox SectionTitle;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKON02243P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.RetGdsDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.DisDayMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.suppTtlAmntDspWayCdRFTextBox = new DataDynamics.ActiveReports.TextBox();
            this.suppCTaxLayCdRFTextBox = new DataDynamics.ActiveReports.TextBox();
            this.taxationCodeTextBox = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.SupplierConsTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.DetailLine = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
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
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.Lb_TitleHeaderSub = new DataDynamics.ActiveReports.Label();
            this.bottomline_TitleHeader = new DataDynamics.ActiveReports.Line();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.Lb_TitleHeader = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.tg_SalesGrsProfit = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.textBox48 = new DataDynamics.ActiveReports.TextBox();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.textBox65 = new DataDynamics.ActiveReports.TextBox();
            this.textBox66 = new DataDynamics.ActiveReports.TextBox();
            this.textBox67 = new DataDynamics.ActiveReports.TextBox();
            this.textBox90 = new DataDynamics.ActiveReports.TextBox();
            this.textBox91 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionHeaderLine = new DataDynamics.ActiveReports.TextBox();
            this.upline_SectionHeader = new DataDynamics.ActiveReports.Line();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.g_SalesGrsProfit = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox56 = new DataDynamics.ActiveReports.TextBox();
            this.textBox57 = new DataDynamics.ActiveReports.TextBox();
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.textBox81 = new DataDynamics.ActiveReports.TextBox();
            this.textBox82 = new DataDynamics.ActiveReports.TextBox();
            this.DailyHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.DailyFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.DailyFooter_TaxRF = new DataDynamics.ActiveReports.TextBox();
            this.DailyFooterTitle = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.DailyFooter_suppCTaxLayCdRFTextBox = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1Title = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox51 = new DataDynamics.ActiveReports.TextBox();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.textBox53 = new DataDynamics.ActiveReports.TextBox();
            this.textBox54 = new DataDynamics.ActiveReports.TextBox();
            this.textBox55 = new DataDynamics.ActiveReports.TextBox();
            this.textBox85 = new DataDynamics.ActiveReports.TextBox();
            this.textBox86 = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter2Title = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox68 = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.textBox70 = new DataDynamics.ActiveReports.TextBox();
            this.textBox71 = new DataDynamics.ActiveReports.TextBox();
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.textBox73 = new DataDynamics.ActiveReports.TextBox();
            this.textBox74 = new DataDynamics.ActiveReports.TextBox();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.textBox76 = new DataDynamics.ActiveReports.TextBox();
            this.textBox77 = new DataDynamics.ActiveReports.TextBox();
            this.textBox79 = new DataDynamics.ActiveReports.TextBox();
            this.textBox84 = new DataDynamics.ActiveReports.TextBox();
            this.textBox87 = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader3 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter3 = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.TitleFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox147 = new DataDynamics.ActiveReports.TextBox();
            this.textBox180 = new DataDynamics.ActiveReports.TextBox();
            this.textBox181 = new DataDynamics.ActiveReports.TextBox();
            this.textBox182 = new DataDynamics.ActiveReports.TextBox();
            this.textBox183 = new DataDynamics.ActiveReports.TextBox();
            this.textBox184 = new DataDynamics.ActiveReports.TextBox();
            this.textBox185 = new DataDynamics.ActiveReports.TextBox();
            this.textBox186 = new DataDynamics.ActiveReports.TextBox();
            this.textBox187 = new DataDynamics.ActiveReports.TextBox();
            this.textBox188 = new DataDynamics.ActiveReports.TextBox();
            this.textBox189 = new DataDynamics.ActiveReports.TextBox();
            this.textBox190 = new DataDynamics.ActiveReports.TextBox();
            this.textBox191 = new DataDynamics.ActiveReports.TextBox();
            this.textBox192 = new DataDynamics.ActiveReports.TextBox();
            this.textBox193 = new DataDynamics.ActiveReports.TextBox();
            this.textBox194 = new DataDynamics.ActiveReports.TextBox();
            this.textBox195 = new DataDynamics.ActiveReports.TextBox();
            this.textBox196 = new DataDynamics.ActiveReports.TextBox();
            this.textBox197 = new DataDynamics.ActiveReports.TextBox();
            this.textBox198 = new DataDynamics.ActiveReports.TextBox();
            this.textBox199 = new DataDynamics.ActiveReports.TextBox();
            this.textBox200 = new DataDynamics.ActiveReports.TextBox();
            this.textBox201 = new DataDynamics.ActiveReports.TextBox();
            this.label49 = new DataDynamics.ActiveReports.Label();
            this.label50 = new DataDynamics.ActiveReports.Label();
            this.label51 = new DataDynamics.ActiveReports.Label();
            this.textBox202 = new DataDynamics.ActiveReports.TextBox();
            this.textBox203 = new DataDynamics.ActiveReports.TextBox();
            this.textBox204 = new DataDynamics.ActiveReports.TextBox();
            this.textBox205 = new DataDynamics.ActiveReports.TextBox();
            this.textBox206 = new DataDynamics.ActiveReports.TextBox();
            this.textBox207 = new DataDynamics.ActiveReports.TextBox();
            this.textBox208 = new DataDynamics.ActiveReports.TextBox();
            this.textBox209 = new DataDynamics.ActiveReports.TextBox();
            this.textBox210 = new DataDynamics.ActiveReports.TextBox();
            this.label52 = new DataDynamics.ActiveReports.Label();
            this.label53 = new DataDynamics.ActiveReports.Label();
            this.label54 = new DataDynamics.ActiveReports.Label();
            this.GrandTotalTitle_2 = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox146 = new DataDynamics.ActiveReports.TextBox();
            this.textBox148 = new DataDynamics.ActiveReports.TextBox();
            this.textBox149 = new DataDynamics.ActiveReports.TextBox();
            this.textBox150 = new DataDynamics.ActiveReports.TextBox();
            this.textBox151 = new DataDynamics.ActiveReports.TextBox();
            this.textBox152 = new DataDynamics.ActiveReports.TextBox();
            this.textBox153 = new DataDynamics.ActiveReports.TextBox();
            this.textBox154 = new DataDynamics.ActiveReports.TextBox();
            this.textBox155 = new DataDynamics.ActiveReports.TextBox();
            this.textBox156 = new DataDynamics.ActiveReports.TextBox();
            this.textBox157 = new DataDynamics.ActiveReports.TextBox();
            this.textBox158 = new DataDynamics.ActiveReports.TextBox();
            this.textBox159 = new DataDynamics.ActiveReports.TextBox();
            this.textBox160 = new DataDynamics.ActiveReports.TextBox();
            this.textBox161 = new DataDynamics.ActiveReports.TextBox();
            this.textBox162 = new DataDynamics.ActiveReports.TextBox();
            this.textBox163 = new DataDynamics.ActiveReports.TextBox();
            this.textBox164 = new DataDynamics.ActiveReports.TextBox();
            this.textBox165 = new DataDynamics.ActiveReports.TextBox();
            this.textBox166 = new DataDynamics.ActiveReports.TextBox();
            this.textBox167 = new DataDynamics.ActiveReports.TextBox();
            this.textBox168 = new DataDynamics.ActiveReports.TextBox();
            this.textBox169 = new DataDynamics.ActiveReports.TextBox();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.label44 = new DataDynamics.ActiveReports.Label();
            this.label45 = new DataDynamics.ActiveReports.Label();
            this.textBox170 = new DataDynamics.ActiveReports.TextBox();
            this.textBox171 = new DataDynamics.ActiveReports.TextBox();
            this.textBox172 = new DataDynamics.ActiveReports.TextBox();
            this.textBox173 = new DataDynamics.ActiveReports.TextBox();
            this.textBox174 = new DataDynamics.ActiveReports.TextBox();
            this.textBox175 = new DataDynamics.ActiveReports.TextBox();
            this.textBox176 = new DataDynamics.ActiveReports.TextBox();
            this.textBox177 = new DataDynamics.ActiveReports.TextBox();
            this.textBox178 = new DataDynamics.ActiveReports.TextBox();
            this.label46 = new DataDynamics.ActiveReports.Label();
            this.label47 = new DataDynamics.ActiveReports.Label();
            this.SectionTitle_2 = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.groupHeader1_2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1_2 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox113 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1Title_2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox115 = new DataDynamics.ActiveReports.TextBox();
            this.textBox116 = new DataDynamics.ActiveReports.TextBox();
            this.textBox117 = new DataDynamics.ActiveReports.TextBox();
            this.textBox118 = new DataDynamics.ActiveReports.TextBox();
            this.textBox119 = new DataDynamics.ActiveReports.TextBox();
            this.textBox120 = new DataDynamics.ActiveReports.TextBox();
            this.textBox121 = new DataDynamics.ActiveReports.TextBox();
            this.textBox122 = new DataDynamics.ActiveReports.TextBox();
            this.textBox123 = new DataDynamics.ActiveReports.TextBox();
            this.textBox124 = new DataDynamics.ActiveReports.TextBox();
            this.textBox125 = new DataDynamics.ActiveReports.TextBox();
            this.textBox126 = new DataDynamics.ActiveReports.TextBox();
            this.textBox127 = new DataDynamics.ActiveReports.TextBox();
            this.textBox128 = new DataDynamics.ActiveReports.TextBox();
            this.textBox129 = new DataDynamics.ActiveReports.TextBox();
            this.textBox130 = new DataDynamics.ActiveReports.TextBox();
            this.textBox131 = new DataDynamics.ActiveReports.TextBox();
            this.textBox132 = new DataDynamics.ActiveReports.TextBox();
            this.textBox133 = new DataDynamics.ActiveReports.TextBox();
            this.textBox134 = new DataDynamics.ActiveReports.TextBox();
            this.textBox135 = new DataDynamics.ActiveReports.TextBox();
            this.textBox136 = new DataDynamics.ActiveReports.TextBox();
            this.label37 = new DataDynamics.ActiveReports.Label();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.label39 = new DataDynamics.ActiveReports.Label();
            this.textBox137 = new DataDynamics.ActiveReports.TextBox();
            this.textBox138 = new DataDynamics.ActiveReports.TextBox();
            this.textBox139 = new DataDynamics.ActiveReports.TextBox();
            this.textBox140 = new DataDynamics.ActiveReports.TextBox();
            this.textBox141 = new DataDynamics.ActiveReports.TextBox();
            this.textBox142 = new DataDynamics.ActiveReports.TextBox();
            this.textBox143 = new DataDynamics.ActiveReports.TextBox();
            this.textBox144 = new DataDynamics.ActiveReports.TextBox();
            this.textBox145 = new DataDynamics.ActiveReports.TextBox();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.label41 = new DataDynamics.ActiveReports.Label();
            this.label42 = new DataDynamics.ActiveReports.Label();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.groupHeader2_2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2_2 = new DataDynamics.ActiveReports.GroupFooter();
            this.label33 = new DataDynamics.ActiveReports.Label();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter2Title_2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox45 = new DataDynamics.ActiveReports.TextBox();
            this.textBox47 = new DataDynamics.ActiveReports.TextBox();
            this.textBox49 = new DataDynamics.ActiveReports.TextBox();
            this.textBox78 = new DataDynamics.ActiveReports.TextBox();
            this.textBox80 = new DataDynamics.ActiveReports.TextBox();
            this.textBox83 = new DataDynamics.ActiveReports.TextBox();
            this.textBox88 = new DataDynamics.ActiveReports.TextBox();
            this.textBox89 = new DataDynamics.ActiveReports.TextBox();
            this.textBox92 = new DataDynamics.ActiveReports.TextBox();
            this.textBox93 = new DataDynamics.ActiveReports.TextBox();
            this.textBox94 = new DataDynamics.ActiveReports.TextBox();
            this.textBox95 = new DataDynamics.ActiveReports.TextBox();
            this.textBox96 = new DataDynamics.ActiveReports.TextBox();
            this.textBox97 = new DataDynamics.ActiveReports.TextBox();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.textBox99 = new DataDynamics.ActiveReports.TextBox();
            this.textBox100 = new DataDynamics.ActiveReports.TextBox();
            this.textBox101 = new DataDynamics.ActiveReports.TextBox();
            this.textBox102 = new DataDynamics.ActiveReports.TextBox();
            this.textBox103 = new DataDynamics.ActiveReports.TextBox();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.textBox104 = new DataDynamics.ActiveReports.TextBox();
            this.textBox105 = new DataDynamics.ActiveReports.TextBox();
            this.textBox106 = new DataDynamics.ActiveReports.TextBox();
            this.textBox107 = new DataDynamics.ActiveReports.TextBox();
            this.textBox108 = new DataDynamics.ActiveReports.TextBox();
            this.textBox109 = new DataDynamics.ActiveReports.TextBox();
            this.textBox110 = new DataDynamics.ActiveReports.TextBox();
            this.textBox111 = new DataDynamics.ActiveReports.TextBox();
            this.textBox112 = new DataDynamics.ActiveReports.TextBox();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.label55 = new DataDynamics.ActiveReports.Label();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox114 = new DataDynamics.ActiveReports.TextBox();
            this.textBox179 = new DataDynamics.ActiveReports.TextBox();
            this.label56 = new DataDynamics.ActiveReports.Label();
            this.textBox211 = new DataDynamics.ActiveReports.TextBox();
            this.textBox212 = new DataDynamics.ActiveReports.TextBox();
            this.textBox213 = new DataDynamics.ActiveReports.TextBox();
            this.label57 = new DataDynamics.ActiveReports.Label();
            this.textBox214 = new DataDynamics.ActiveReports.TextBox();
            this.textBox215 = new DataDynamics.ActiveReports.TextBox();
            this.label58 = new DataDynamics.ActiveReports.Label();
            this.textBox216 = new DataDynamics.ActiveReports.TextBox();
            this.textBox217 = new DataDynamics.ActiveReports.TextBox();
            this.textBox218 = new DataDynamics.ActiveReports.TextBox();
            this.textBox219 = new DataDynamics.ActiveReports.TextBox();
            this.label59 = new DataDynamics.ActiveReports.Label();
            this.textBox220 = new DataDynamics.ActiveReports.TextBox();
            this.label60 = new DataDynamics.ActiveReports.Label();
            this.textBox224 = new DataDynamics.ActiveReports.TextBox();
            this.textBox225 = new DataDynamics.ActiveReports.TextBox();
            this.label61 = new DataDynamics.ActiveReports.Label();
            this.textBox226 = new DataDynamics.ActiveReports.TextBox();
            this.textBox221 = new DataDynamics.ActiveReports.TextBox();
            this.textBox222 = new DataDynamics.ActiveReports.TextBox();
            this.label48 = new DataDynamics.ActiveReports.Label();
            this.textBox223 = new DataDynamics.ActiveReports.TextBox();
            this.textBox227 = new DataDynamics.ActiveReports.TextBox();
            this.textBox228 = new DataDynamics.ActiveReports.TextBox();
            this.label62 = new DataDynamics.ActiveReports.Label();
            this.textBox229 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppTtlAmntDspWayCdRFTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppCTaxLayCdRFTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxationCodeTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierConsTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeaderSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tg_SalesGrsProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesGrsProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyFooter_TaxRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyFooterTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyFooter_suppCTaxLayCdRFTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter1Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter2Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox180)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox181)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox182)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox183)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox184)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox185)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox186)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox187)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox188)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox189)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox190)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox191)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox192)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox193)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox194)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox195)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox196)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox197)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox198)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox199)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox200)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox201)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox202)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox203)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox204)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox205)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox206)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox207)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox208)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox209)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox210)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox146)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox148)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox149)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox152)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox155)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox156)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox157)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox158)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox159)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox160)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox161)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox163)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox166)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox167)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox169)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox170)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox171)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox172)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox173)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox174)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox175)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox176)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox177)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox178)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter1Title_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox115)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox121)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox124)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox125)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox127)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox128)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox129)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox130)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox135)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox136)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox138)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox142)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox143)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox144)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox145)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter2Title_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox112)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox114)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox179)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox211)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox212)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox213)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox214)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox215)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox216)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox217)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox218)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox219)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox220)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox224)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox225)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox226)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox221)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox222)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox223)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox227)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox228)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox229)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.RetGdsDayTotal,
            this.StckPriceMonthTotal,
            this.DisDayMonthTotal,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox9,
            this.textBox11,
            this.textBox14,
            this.textBox15,
            this.label15,
            this.label27,
            this.label12,
            this.label29,
            this.label30,
            this.suppTtlAmntDspWayCdRFTextBox,
            this.suppCTaxLayCdRFTextBox,
            this.taxationCodeTextBox,
            this.line5,
            this.SupplierConsTaxRate});
            this.Detail.Height = 0.4375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // RetGdsDayTotal
            // 
            this.RetGdsDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.DataField = "TaxRF";
            this.RetGdsDayTotal.Height = 0.125F;
            this.RetGdsDayTotal.Left = 9.9375F;
            this.RetGdsDayTotal.MultiLine = false;
            this.RetGdsDayTotal.Name = "RetGdsDayTotal";
            this.RetGdsDayTotal.OutputFormat = resources.GetString("RetGdsDayTotal.OutputFormat");
            this.RetGdsDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.RetGdsDayTotal.Text = "ZZ,ZZZ,ZZ9";
            this.RetGdsDayTotal.Top = 0F;
            this.RetGdsDayTotal.Width = 0.65F;
            // 
            // StckPriceMonthTotal
            // 
            this.StckPriceMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.DataField = "StockUnitPriceRF";
            this.StckPriceMonthTotal.Height = 0.125F;
            this.StckPriceMonthTotal.Left = 8.625F;
            this.StckPriceMonthTotal.MultiLine = false;
            this.StckPriceMonthTotal.Name = "StckPriceMonthTotal";
            this.StckPriceMonthTotal.OutputFormat = resources.GetString("StckPriceMonthTotal.OutputFormat");
            this.StckPriceMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StckPriceMonthTotal.Text = "ZZZ,ZZ9.00";
            this.StckPriceMonthTotal.Top = 0F;
            this.StckPriceMonthTotal.Width = 0.625F;
            // 
            // DisDayMonthTotal
            // 
            this.DisDayMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.DataField = "StockPriceTaxExcRF";
            this.DisDayMonthTotal.Height = 0.125F;
            this.DisDayMonthTotal.Left = 9.3125F;
            this.DisDayMonthTotal.MultiLine = false;
            this.DisDayMonthTotal.Name = "DisDayMonthTotal";
            this.DisDayMonthTotal.OutputFormat = resources.GetString("DisDayMonthTotal.OutputFormat");
            this.DisDayMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DisDayMonthTotal.Text = "ZZZ,ZZZ,ZZ9";
            this.DisDayMonthTotal.Top = 0F;
            this.DisDayMonthTotal.Width = 0.6875F;
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
            this.textBox24.DataField = "GoodsCodeRF";
            this.textBox24.Height = 0.125F;
            this.textBox24.Left = 0.5F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox24.Text = "123456789012345678901234";
            this.textBox24.Top = 0F;
            this.textBox24.Width = 1.4375F;
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
            this.textBox25.DataField = "GoodsNameRF";
            this.textBox25.Height = 0.125F;
            this.textBox25.Left = 1.9375F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox25.Text = "12345678901234567890";
            this.textBox25.Top = 0F;
            this.textBox25.Width = 1.1875F;
            // 
            // textBox26
            // 
            this.textBox26.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.RightColor = System.Drawing.Color.Black;
            this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.TopColor = System.Drawing.Color.Black;
            this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.DataField = "GoodsMakerCdRF";
            this.textBox26.Height = 0.125F;
            this.textBox26.Left = 3.125F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox26.Text = "1234";
            this.textBox26.Top = 0F;
            this.textBox26.Width = 0.3F;
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
            this.textBox27.DataField = "StockCountRF";
            this.textBox27.Height = 0.125F;
            this.textBox27.Left = 5.9375F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox27.Text = "123,456,00";
            this.textBox27.Top = 0F;
            this.textBox27.Width = 0.625F;
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
            this.textBox29.DataField = "ListPriceFlRF";
            this.textBox29.Height = 0.125F;
            this.textBox29.Left = 7.25F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.Text = "ZZZ,ZZ9";
            this.textBox29.Top = 0F;
            this.textBox29.Width = 0.48F;
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
            this.textBox30.DataField = "BLGoodsCodeRF";
            this.textBox30.Height = 0.125F;
            this.textBox30.Left = 0.125F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox30.Text = "12345";
            this.textBox30.Top = 0F;
            this.textBox30.Width = 0.3125F;
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
            this.textBox31.DataField = "StockOrderDivNmRF";
            this.textBox31.Height = 0.125F;
            this.textBox31.Left = 3.45F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox31.Text = "１２";
            this.textBox31.Top = 0F;
            this.textBox31.Width = 0.25F;
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
            this.textBox32.DataField = "WarehouseNameRF";
            this.textBox32.Height = 0.125F;
            this.textBox32.Left = 3.6875F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox32.Text = "12345678901234567890";
            this.textBox32.Top = 0F;
            this.textBox32.Width = 1.1875F;
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
            this.textBox9.DataField = "BfListPriceRF";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 6.6875F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox9.Text = "ZZZ,ZZ9";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.4375F;
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
            this.textBox11.DataField = "BfStockUnitPriceFlRF";
            this.textBox11.Height = 0.125F;
            this.textBox11.Left = 7.875F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox11.Text = "ZZZ,ZZ9.00";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.625F;
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
            this.textBox14.DataField = "SalesSlipNum";
            this.textBox14.Height = 0.125F;
            this.textBox14.Left = 4.875F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox14.Text = "123456789";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.5625F;
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
            this.textBox15.DataField = "CustomerCodeRF";
            this.textBox15.Height = 0.125F;
            this.textBox15.Left = 5.4375F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox15.Text = "12345678";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.5F;
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
            this.label15.Left = 8.5F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "/";
            this.label15.Top = 0F;
            this.label15.Width = 0.125F;
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
            this.label27.Left = 9.25F;
            this.label27.MultiLine = false;
            this.label27.Name = "label27";
            this.label27.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label27.Text = ")";
            this.label27.Top = 0F;
            this.label27.Width = 0.125F;
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
            this.label12.Height = 0.125F;
            this.label12.HyperLink = "";
            this.label12.Left = 7.6875F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = ")(";
            this.label12.Top = 0F;
            this.label12.Width = 0.1875F;
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
            this.label29.MultiLine = false;
            this.label29.Name = "label29";
            this.label29.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label29.Text = "(";
            this.label29.Top = 0F;
            this.label29.Width = 0.125F;
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
            this.label30.Height = 0.125F;
            this.label30.HyperLink = "";
            this.label30.Left = 7.125F;
            this.label30.MultiLine = false;
            this.label30.Name = "label30";
            this.label30.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.label30.Text = "/";
            this.label30.Top = 0F;
            this.label30.Width = 0.125F;
            // 
            // suppTtlAmntDspWayCdRFTextBox
            // 
            this.suppTtlAmntDspWayCdRFTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.suppTtlAmntDspWayCdRFTextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppTtlAmntDspWayCdRFTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.suppTtlAmntDspWayCdRFTextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppTtlAmntDspWayCdRFTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.suppTtlAmntDspWayCdRFTextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppTtlAmntDspWayCdRFTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.suppTtlAmntDspWayCdRFTextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppTtlAmntDspWayCdRFTextBox.DataField = "SuppTtlAmntDspWayCd";
            this.suppTtlAmntDspWayCdRFTextBox.Height = 0.125F;
            this.suppTtlAmntDspWayCdRFTextBox.Left = 9.75F;
            this.suppTtlAmntDspWayCdRFTextBox.MultiLine = false;
            this.suppTtlAmntDspWayCdRFTextBox.Name = "suppTtlAmntDspWayCdRFTextBox";
            this.suppTtlAmntDspWayCdRFTextBox.OutputFormat = resources.GetString("suppTtlAmntDspWayCdRFTextBox.OutputFormat");
            this.suppTtlAmntDspWayCdRFTextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.suppTtlAmntDspWayCdRFTextBox.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Var;
            this.suppTtlAmntDspWayCdRFTextBox.Text = "-1";
            this.suppTtlAmntDspWayCdRFTextBox.Top = 0.25F;
            this.suppTtlAmntDspWayCdRFTextBox.Visible = false;
            this.suppTtlAmntDspWayCdRFTextBox.Width = 0.3F;
            // 
            // suppCTaxLayCdRFTextBox
            // 
            this.suppCTaxLayCdRFTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.suppCTaxLayCdRFTextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppCTaxLayCdRFTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.suppCTaxLayCdRFTextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppCTaxLayCdRFTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.suppCTaxLayCdRFTextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppCTaxLayCdRFTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.suppCTaxLayCdRFTextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppCTaxLayCdRFTextBox.DataField = "SuppCTaxLayCd";
            this.suppCTaxLayCdRFTextBox.Height = 0.125F;
            this.suppCTaxLayCdRFTextBox.Left = 9.1875F;
            this.suppCTaxLayCdRFTextBox.MultiLine = false;
            this.suppCTaxLayCdRFTextBox.Name = "suppCTaxLayCdRFTextBox";
            this.suppCTaxLayCdRFTextBox.OutputFormat = resources.GetString("suppCTaxLayCdRFTextBox.OutputFormat");
            this.suppCTaxLayCdRFTextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.suppCTaxLayCdRFTextBox.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Var;
            this.suppCTaxLayCdRFTextBox.Text = "-1";
            this.suppCTaxLayCdRFTextBox.Top = 0.25F;
            this.suppCTaxLayCdRFTextBox.Visible = false;
            this.suppCTaxLayCdRFTextBox.Width = 0.3F;
            // 
            // taxationCodeTextBox
            // 
            this.taxationCodeTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.taxationCodeTextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationCodeTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.taxationCodeTextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationCodeTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.taxationCodeTextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationCodeTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.taxationCodeTextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationCodeTextBox.DataField = "TaxationCode";
            this.taxationCodeTextBox.Height = 0.125F;
            this.taxationCodeTextBox.Left = 10.25F;
            this.taxationCodeTextBox.MultiLine = false;
            this.taxationCodeTextBox.Name = "taxationCodeTextBox";
            this.taxationCodeTextBox.OutputFormat = resources.GetString("taxationCodeTextBox.OutputFormat");
            this.taxationCodeTextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.taxationCodeTextBox.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Var;
            this.taxationCodeTextBox.Text = "-1";
            this.taxationCodeTextBox.Top = 0.25F;
            this.taxationCodeTextBox.Visible = false;
            this.taxationCodeTextBox.Width = 0.3F;
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
            // SupplierConsTaxRate
            // 
            this.SupplierConsTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierConsTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierConsTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierConsTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierConsTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierConsTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierConsTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierConsTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierConsTaxRate.DataField = "SupplierConsTaxRate";
            this.SupplierConsTaxRate.Height = 0.125F;
            this.SupplierConsTaxRate.Left = 10.5F;
            this.SupplierConsTaxRate.MultiLine = false;
            this.SupplierConsTaxRate.Name = "SupplierConsTaxRate";
            this.SupplierConsTaxRate.OutputFormat = resources.GetString("SupplierConsTaxRate.OutputFormat");
            this.SupplierConsTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupplierConsTaxRate.Text = "10%";
            this.SupplierConsTaxRate.Top = 0F;
            this.SupplierConsTaxRate.Width = 0.3F;
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
            this.textBox16.DataField = "UoeRemark1";
            this.textBox16.Height = 0.125F;
            this.textBox16.Left = 8.9375F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox16.Text = "12345678901234567890";
            this.textBox16.Top = 0F;
            this.textBox16.Width = 1.1875F;
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
            this.textBox17.DataField = "UoeRemark2";
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 10.125F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox17.Text = "1234567890";
            this.textBox17.Top = 0F;
            this.textBox17.Width = 0.625F;
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
            this.DetailLine.DataField = "SupplierSnm";
            this.DetailLine.Height = 0.125F;
            this.DetailLine.Left = 0.4375F;
            this.DetailLine.MultiLine = false;
            this.DetailLine.Name = "DetailLine";
            this.DetailLine.OutputFormat = resources.GetString("DetailLine.OutputFormat");
            this.DetailLine.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.DetailLine.Text = "１２３４５６７８９０１２３４５６７８９０";
            this.DetailLine.Top = 0F;
            this.DetailLine.Width = 1.75F;
            // 
            // NetStcPrcDayTotal
            // 
            this.NetStcPrcDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.DataField = "PartySaleSlipNumRF";
            this.NetStcPrcDayTotal.DistinctField = "TermProfit";
            this.NetStcPrcDayTotal.Height = 0.125F;
            this.NetStcPrcDayTotal.Left = 4.3125F;
            this.NetStcPrcDayTotal.MultiLine = false;
            this.NetStcPrcDayTotal.Name = "NetStcPrcDayTotal";
            this.NetStcPrcDayTotal.OutputFormat = resources.GetString("NetStcPrcDayTotal.OutputFormat");
            this.NetStcPrcDayTotal.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.NetStcPrcDayTotal.Text = "1234567890123456789";
            this.NetStcPrcDayTotal.Top = 0F;
            this.NetStcPrcDayTotal.Width = 1.125F;
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
            this.textBox8.DataField = "SupplierSlipNoRF";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 5.8125F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.Text = "123456789";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.75F;
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
            this.textBox23.DataField = "SupplierSlipNmRF";
            this.textBox23.Height = 0.125F;
            this.textBox23.Left = 5.4375F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox23.Text = "１２３";
            this.textBox23.Top = 0F;
            this.textBox23.Width = 0.375F;
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
            this.textBox12.DataField = "InputDayStringRF";
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 2.9375F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox12.Text = "YYYY/MM/DD";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.625F;
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
            this.textBox1.DataField = "StockDateStringRF";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 2.25F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox1.Text = "YYYY/MM/DD";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.625F;
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
            this.textBox2.DataField = "SupplierCd";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 0F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.Text = "123456";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.375F;
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
            this.tb_ReportTitle.Text = "仕入確認表（明細タイプ）";
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
            this.SortTitle.Top = 0.0625F;
            this.SortTitle.Width = 2.6875F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.21875F;
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
            this.label6,
            this.label10,
            this.Lb_TitleHeaderSub,
            this.bottomline_TitleHeader,
            this.label13,
            this.label17,
            this.label14,
            this.label20,
            this.label23,
            this.label1,
            this.label4,
            this.label5,
            this.label7,
            this.label8,
            this.label9,
            this.label16,
            this.label18,
            this.label19,
            this.label21,
            this.label22,
            this.label11,
            this.label24,
            this.label25,
            this.label26,
            this.label28});
            this.TitleHeader.Height = 0.46875F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
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
            this.label6.HyperLink = "";
            this.label6.Left = 9.9375F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label6.Text = "消費税";
            this.label6.Top = 0.1875F;
            this.label6.Width = 0.625F;
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
            this.label10.HyperLink = "";
            this.label10.Left = 9.3125F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label10.Text = "金額";
            this.label10.Top = 0.1875F;
            this.label10.Width = 0.6875F;
            // 
            // Lb_TitleHeaderSub
            // 
            this.Lb_TitleHeaderSub.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Height = 0.1875F;
            this.Lb_TitleHeaderSub.HyperLink = "";
            this.Lb_TitleHeaderSub.Left = 0F;
            this.Lb_TitleHeaderSub.MultiLine = false;
            this.Lb_TitleHeaderSub.Name = "Lb_TitleHeaderSub";
            this.Lb_TitleHeaderSub.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_TitleHeaderSub.Text = "仕入先";
            this.Lb_TitleHeaderSub.Top = 0F;
            this.Lb_TitleHeaderSub.Width = 0.375F;
            // 
            // bottomline_TitleHeader
            // 
            this.bottomline_TitleHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Border.RightColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Border.TopColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Height = 0F;
            this.bottomline_TitleHeader.Left = 0F;
            this.bottomline_TitleHeader.LineWeight = 2F;
            this.bottomline_TitleHeader.Name = "bottomline_TitleHeader";
            this.bottomline_TitleHeader.Top = 0.375F;
            this.bottomline_TitleHeader.Width = 10.8F;
            this.bottomline_TitleHeader.X1 = 0F;
            this.bottomline_TitleHeader.X2 = 10.8F;
            this.bottomline_TitleHeader.Y1 = 0.375F;
            this.bottomline_TitleHeader.Y2 = 0.375F;
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
            this.label13.HyperLink = "";
            this.label13.Left = 2.9375F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label13.Text = "入力日";
            this.label13.Top = 0F;
            this.label13.Width = 0.625F;
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
            this.label17.Height = 0.1875F;
            this.label17.HyperLink = "";
            this.label17.Left = 5.8125F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label17.Text = "仕入SEQ番号";
            this.label17.Top = 0F;
            this.label17.Width = 0.75F;
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
            this.label14.Height = 0.1875F;
            this.label14.HyperLink = "";
            this.label14.Left = 5.4375F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label14.Text = "区分";
            this.label14.Top = 0F;
            this.label14.Width = 0.375F;
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
            this.label20.Height = 0.1875F;
            this.label20.HyperLink = "";
            this.label20.Left = 4.3125F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label20.Text = "伝票番号";
            this.label20.Top = 0F;
            this.label20.Width = 1.125F;
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
            this.label23.HyperLink = "";
            this.label23.Left = 2.25F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label23.Text = "仕入日";
            this.label23.Top = 0F;
            this.label23.Width = 0.625F;
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
            this.label1.Left = 3.625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label1.Text = "計上日";
            this.label1.Top = 0F;
            this.label1.Width = 0.625F;
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
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = "";
            this.label4.Left = 6.625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label4.Text = "備考";
            this.label4.Top = 0F;
            this.label4.Width = 2.25F;
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
            this.label5.HyperLink = "";
            this.label5.Left = 0.5F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label5.Text = "品番";
            this.label5.Top = 0.1875F;
            this.label5.Width = 1.375F;
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
            this.label7.HyperLink = "";
            this.label7.Left = 1.9375F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label7.Text = "品名";
            this.label7.Top = 0.1875F;
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
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 3.125F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label8.Text = "ﾒｰｶｰ";
            this.label8.Top = 0.1875F;
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
            this.label9.Height = 0.1875F;
            this.label9.HyperLink = "";
            this.label9.Left = 5.9375F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label9.Text = "数量";
            this.label9.Top = 0.1875F;
            this.label9.Width = 0.625F;
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
            this.label16.HyperLink = "";
            this.label16.Left = 0.125F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label16.Text = "BLｺｰﾄﾞ";
            this.label16.Top = 0.1875F;
            this.label16.Width = 0.375F;
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
            this.label18.Height = 0.1875F;
            this.label18.HyperLink = "";
            this.label18.Left = 3.4375F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label18.Text = "在取";
            this.label18.Top = 0.1875F;
            this.label18.Width = 0.3125F;
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
            this.label19.Height = 0.1875F;
            this.label19.HyperLink = "";
            this.label19.Left = 3.6875F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label19.Text = "倉庫";
            this.label19.Top = 0.1875F;
            this.label19.Width = 1.1875F;
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
            this.label21.Height = 0.1875F;
            this.label21.HyperLink = "";
            this.label21.Left = 6.5625F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; white-space: inherit; vertical-align: middle; ";
            this.label21.Text = "価格( 変更前/変更後 )";
            this.label21.Top = 0.1875F;
            this.label21.Width = 1.25F;
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
            this.label22.Height = 0.1875F;
            this.label22.HyperLink = "";
            this.label22.Left = 8F;
            this.label22.MultiLine = false;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.label22.Text = "単価( 変更前/変更後 )";
            this.label22.Top = 0.1875F;
            this.label22.Width = 1.375F;
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
            this.label11.Height = 0.1875F;
            this.label11.HyperLink = "";
            this.label11.Left = 4.875F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label11.Text = "売伝番号";
            this.label11.Top = 0.1875F;
            this.label11.Width = 0.5625F;
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
            this.label24.HyperLink = "";
            this.label24.Left = 5.4375F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label24.Text = "得意先";
            this.label24.Top = 0.1875F;
            this.label24.Width = 0.5F;
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
            this.label25.Height = 0.1875F;
            this.label25.HyperLink = "";
            this.label25.Left = 8.9375F;
            this.label25.MultiLine = false;
            this.label25.Name = "label25";
            this.label25.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label25.Text = "リマーク１";
            this.label25.Top = 0F;
            this.label25.Width = 1.1875F;
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
            this.label26.Height = 0.1875F;
            this.label26.HyperLink = "";
            this.label26.Left = 10.125F;
            this.label26.MultiLine = false;
            this.label26.Name = "label26";
            this.label26.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label26.Text = "リマーク２";
            this.label26.Top = 0F;
            this.label26.Width = 0.625F;
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
            this.label28.Height = 0.1875F;
            this.label28.HyperLink = "";
            this.label28.Left = 10.5F;
            this.label28.MultiLine = false;
            this.label28.Name = "label28";
            this.label28.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label28.Text = "税率";
            this.label28.Top = 0.1875F;
            this.label28.Width = 0.3F;
            // 
            // Lb_TitleHeader
            // 
            this.Lb_TitleHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Height = 0.125F;
            this.Lb_TitleHeader.HyperLink = "";
            this.Lb_TitleHeader.Left = 0F;
            this.Lb_TitleHeader.MultiLine = false;
            this.Lb_TitleHeader.Name = "Lb_TitleHeader";
            this.Lb_TitleHeader.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TitleHeader.Text = "拠点";
            this.Lb_TitleHeader.Top = 0F;
            this.Lb_TitleHeader.Width = 0.3125F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41,
            this.GrandTotalTitle,
            this.tg_SalesGrsProfit,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox46,
            this.textBox48,
            this.textBox62,
            this.textBox63,
            this.textBox64,
            this.textBox65,
            this.textBox66,
            this.textBox67,
            this.textBox90,
            this.textBox91});
            this.TitleFooter.Height = 0.875F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Format += new System.EventHandler(this.TitleFooter_Format);
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
            // GrandTotalTitle
            // 
            this.GrandTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Height = 0.18F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 6.89F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.063F;
            this.GrandTotalTitle.Width = 0.65F;
            // 
            // tg_SalesGrsProfit
            // 
            this.tg_SalesGrsProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.tg_SalesGrsProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tg_SalesGrsProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.tg_SalesGrsProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tg_SalesGrsProfit.Border.RightColor = System.Drawing.Color.Black;
            this.tg_SalesGrsProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tg_SalesGrsProfit.Border.TopColor = System.Drawing.Color.Black;
            this.tg_SalesGrsProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tg_SalesGrsProfit.DataField = "StockPriceTaxExcRF";
            this.tg_SalesGrsProfit.Height = 0.16F;
            this.tg_SalesGrsProfit.Left = 9.06F;
            this.tg_SalesGrsProfit.MultiLine = false;
            this.tg_SalesGrsProfit.Name = "tg_SalesGrsProfit";
            this.tg_SalesGrsProfit.OutputFormat = resources.GetString("tg_SalesGrsProfit.OutputFormat");
            this.tg_SalesGrsProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.tg_SalesGrsProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tg_SalesGrsProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.tg_SalesGrsProfit.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.tg_SalesGrsProfit.Top = 0.625F;
            this.tg_SalesGrsProfit.Width = 0.938F;
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
            this.textBox35.Height = 0.156F;
            this.textBox35.Left = 7.638F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox35.Text = "仕入";
            this.textBox35.Top = 0.063F;
            this.textBox35.Width = 0.3F;
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
            this.textBox36.Height = 0.156F;
            this.textBox36.Left = 7.638F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox36.Text = "返品";
            this.textBox36.Top = 0.25F;
            this.textBox36.Width = 0.3F;
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
            this.textBox37.Height = 0.156F;
            this.textBox37.Left = 7.638F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox37.Text = "合計";
            this.textBox37.Top = 0.625F;
            this.textBox37.Width = 0.3F;
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
            this.textBox46.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox46.Height = 0.16F;
            this.textBox46.Left = 9.06F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox46.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox46.Top = 0.25F;
            this.textBox46.Width = 0.938F;
            // 
            // textBox48
            // 
            this.textBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.RightColor = System.Drawing.Color.Black;
            this.textBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.TopColor = System.Drawing.Color.Black;
            this.textBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.DataField = "SalStockPricTaxExcRF";
            this.textBox48.Height = 0.16F;
            this.textBox48.Left = 9.06F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox48.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox48.Top = 0.0625F;
            this.textBox48.Width = 0.938F;
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
            this.textBox62.DataField = "SalCntRF";
            this.textBox62.Height = 0.16F;
            this.textBox62.Left = 7.938F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox62.Text = "123,456";
            this.textBox62.Top = 0.0625F;
            this.textBox62.Width = 0.5125F;
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
            this.textBox63.Height = 0.156F;
            this.textBox63.Left = 8.51F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox63.Text = "枚";
            this.textBox63.Top = 0.0625F;
            this.textBox63.Width = 0.15F;
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
            this.textBox64.DataField = "DisCntRF";
            this.textBox64.Height = 0.156F;
            this.textBox64.Left = 7.938F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox64.Text = "123,456";
            this.textBox64.Top = 0.25F;
            this.textBox64.Width = 0.51F;
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
            this.textBox65.Height = 0.156F;
            this.textBox65.Left = 8.51F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
            this.textBox65.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox65.Text = "枚";
            this.textBox65.Top = 0.25F;
            this.textBox65.Width = 0.15F;
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
            this.textBox66.Height = 0.156F;
            this.textBox66.Left = 8.51F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
            this.textBox66.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox66.Text = "枚";
            this.textBox66.Top = 0.625F;
            this.textBox66.Width = 0.15F;
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
            this.textBox67.DataField = "TotleCntRF";
            this.textBox67.Height = 0.156F;
            this.textBox67.Left = 7.938F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
            this.textBox67.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox67.Text = "123,456";
            this.textBox67.Top = 0.625F;
            this.textBox67.Width = 0.51F;
            // 
            // textBox90
            // 
            this.textBox90.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Border.RightColor = System.Drawing.Color.Black;
            this.textBox90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Border.TopColor = System.Drawing.Color.Black;
            this.textBox90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox90.Height = 0.156F;
            this.textBox90.Left = 7.638F;
            this.textBox90.MultiLine = false;
            this.textBox90.Name = "textBox90";
            this.textBox90.OutputFormat = resources.GetString("textBox90.OutputFormat");
            this.textBox90.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox90.Text = "値引";
            this.textBox90.Top = 0.438F;
            this.textBox90.Width = 0.3F;
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
            this.textBox91.DataField = "DisStockPricTaxExcRF";
            this.textBox91.Height = 0.16F;
            this.textBox91.Left = 9.06F;
            this.textBox91.MultiLine = false;
            this.textBox91.Name = "textBox91";
            this.textBox91.OutputFormat = resources.GetString("textBox91.OutputFormat");
            this.textBox91.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox91.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox91.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox91.Top = 0.4375F;
            this.textBox91.Width = 0.938F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionHeaderLine,
            this.upline_SectionHeader,
            this.textBox5,
            this.Lb_TitleHeader});
            this.SectionHeader.DataField = "SectionCodeRF";
            this.SectionHeader.Height = 0.1979167F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // SectionHeaderLine
            // 
            this.SectionHeaderLine.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.Border.RightColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.Border.TopColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.DataField = "SectionCodeRF";
            this.SectionHeaderLine.Height = 0.125F;
            this.SectionHeaderLine.Left = 0.3125F;
            this.SectionHeaderLine.MultiLine = false;
            this.SectionHeaderLine.Name = "SectionHeaderLine";
            this.SectionHeaderLine.OutputFormat = resources.GetString("SectionHeaderLine.OutputFormat");
            this.SectionHeaderLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SectionHeaderLine.Text = "12";
            this.SectionHeaderLine.Top = 0F;
            this.SectionHeaderLine.Width = 0.1875F;
            // 
            // upline_SectionHeader
            // 
            this.upline_SectionHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Border.RightColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Border.TopColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Height = 0F;
            this.upline_SectionHeader.Left = 0F;
            this.upline_SectionHeader.LineWeight = 2F;
            this.upline_SectionHeader.Name = "upline_SectionHeader";
            this.upline_SectionHeader.Top = 0F;
            this.upline_SectionHeader.Width = 10.8F;
            this.upline_SectionHeader.X1 = 0F;
            this.upline_SectionHeader.X2 = 10.8F;
            this.upline_SectionHeader.Y1 = 0F;
            this.upline_SectionHeader.Y2 = 0F;
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
            this.textBox5.DataField = "SectionGuideNmRF";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 0.5F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox5.Text = "12345678901234567890";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 1.1875F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SectionTitle,
            this.g_SalesGrsProfit,
            this.textBox28,
            this.textBox33,
            this.textBox34,
            this.textBox42,
            this.textBox44,
            this.textBox56,
            this.textBox57,
            this.textBox58,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox81,
            this.textBox82});
            this.SectionFooter.Height = 0.78125F;
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
            this.Line45.Width = 10.8F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // SectionTitle
            // 
            this.SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Height = 0.18F;
            this.SectionTitle.Left = 6.89F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0F;
            this.SectionTitle.Width = 0.65F;
            // 
            // g_SalesGrsProfit
            // 
            this.g_SalesGrsProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SalesGrsProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesGrsProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SalesGrsProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesGrsProfit.Border.RightColor = System.Drawing.Color.Black;
            this.g_SalesGrsProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesGrsProfit.Border.TopColor = System.Drawing.Color.Black;
            this.g_SalesGrsProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesGrsProfit.DataField = "StockPriceTaxExcRF";
            this.g_SalesGrsProfit.Height = 0.16F;
            this.g_SalesGrsProfit.Left = 9.06F;
            this.g_SalesGrsProfit.MultiLine = false;
            this.g_SalesGrsProfit.Name = "g_SalesGrsProfit";
            this.g_SalesGrsProfit.OutputFormat = resources.GetString("g_SalesGrsProfit.OutputFormat");
            this.g_SalesGrsProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_SalesGrsProfit.SummaryGroup = "SectionHeader";
            this.g_SalesGrsProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.g_SalesGrsProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.g_SalesGrsProfit.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.g_SalesGrsProfit.Top = 0.5625F;
            this.g_SalesGrsProfit.Width = 0.938F;
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
            this.textBox28.Height = 0.156F;
            this.textBox28.Left = 7.638F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox28.Text = "仕入";
            this.textBox28.Top = 0F;
            this.textBox28.Width = 0.3F;
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
            this.textBox33.Height = 0.156F;
            this.textBox33.Left = 7.638F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox33.Text = "返品";
            this.textBox33.Top = 0.188F;
            this.textBox33.Width = 0.3F;
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
            this.textBox34.Height = 0.156F;
            this.textBox34.Left = 7.638F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox34.Text = "合計";
            this.textBox34.Top = 0.563F;
            this.textBox34.Width = 0.3F;
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
            this.textBox42.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox42.Height = 0.16F;
            this.textBox42.Left = 9.06F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox42.SummaryGroup = "SectionHeader";
            this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox42.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox42.Top = 0.1875F;
            this.textBox42.Width = 0.938F;
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
            this.textBox44.DataField = "SalStockPricTaxExcRF";
            this.textBox44.Height = 0.16F;
            this.textBox44.Left = 9.06F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.SummaryGroup = "SectionHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox44.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox44.Top = 0F;
            this.textBox44.Width = 0.938F;
            // 
            // textBox56
            // 
            this.textBox56.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.Border.RightColor = System.Drawing.Color.Black;
            this.textBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.Border.TopColor = System.Drawing.Color.Black;
            this.textBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.DataField = "SalCntRF";
            this.textBox56.Height = 0.16F;
            this.textBox56.Left = 7.938F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox56.SummaryGroup = "SectionHeader";
            this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox56.Text = "123,456";
            this.textBox56.Top = 0F;
            this.textBox56.Width = 0.5125F;
            // 
            // textBox57
            // 
            this.textBox57.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.RightColor = System.Drawing.Color.Black;
            this.textBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.TopColor = System.Drawing.Color.Black;
            this.textBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Height = 0.156F;
            this.textBox57.Left = 8.51F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox57.Text = "枚";
            this.textBox57.Top = 0F;
            this.textBox57.Width = 0.15F;
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
            this.textBox58.Height = 0.156F;
            this.textBox58.Left = 8.51F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox58.Text = "枚";
            this.textBox58.Top = 0.1875F;
            this.textBox58.Width = 0.15F;
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
            this.textBox59.DataField = "DisCntRF";
            this.textBox59.Height = 0.156F;
            this.textBox59.Left = 7.938F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox59.SummaryGroup = "SectionHeader";
            this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox59.Text = "123,456";
            this.textBox59.Top = 0.1875F;
            this.textBox59.Width = 0.51F;
            // 
            // textBox60
            // 
            this.textBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.RightColor = System.Drawing.Color.Black;
            this.textBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.TopColor = System.Drawing.Color.Black;
            this.textBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.DataField = "TotleCntRF";
            this.textBox60.Height = 0.156F;
            this.textBox60.Left = 7.938F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox60.SummaryGroup = "SectionHeader";
            this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox60.Text = "123,456";
            this.textBox60.Top = 0.5625F;
            this.textBox60.Width = 0.51F;
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
            this.textBox61.Height = 0.156F;
            this.textBox61.Left = 8.51F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox61.Text = "枚";
            this.textBox61.Top = 0.5625F;
            this.textBox61.Width = 0.15F;
            // 
            // textBox81
            // 
            this.textBox81.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Border.RightColor = System.Drawing.Color.Black;
            this.textBox81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Border.TopColor = System.Drawing.Color.Black;
            this.textBox81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox81.Height = 0.156F;
            this.textBox81.Left = 7.638F;
            this.textBox81.MultiLine = false;
            this.textBox81.Name = "textBox81";
            this.textBox81.OutputFormat = resources.GetString("textBox81.OutputFormat");
            this.textBox81.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox81.Text = "値引";
            this.textBox81.Top = 0.375F;
            this.textBox81.Width = 0.3F;
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
            this.textBox82.DataField = "DisStockPricTaxExcRF";
            this.textBox82.Height = 0.16F;
            this.textBox82.Left = 9.06F;
            this.textBox82.MultiLine = false;
            this.textBox82.Name = "textBox82";
            this.textBox82.OutputFormat = resources.GetString("textBox82.OutputFormat");
            this.textBox82.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox82.SummaryGroup = "SectionHeader";
            this.textBox82.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox82.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox82.Top = 0.375F;
            this.textBox82.Width = 0.938F;
            // 
            // DailyHeader
            // 
            this.DailyHeader.CanShrink = true;
            this.DailyHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.DetailLine,
            this.textBox12,
            this.textBox1,
            this.textBox8,
            this.textBox23,
            this.NetStcPrcDayTotal,
            this.textBox21,
            this.textBox22,
            this.textBox16,
            this.textBox17,
            this.line6});
            this.DailyHeader.DataField = "DailyHeaderDataField";
            this.DailyHeader.Height = 0.3333333F;
            this.DailyHeader.Name = "DailyHeader";
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
            this.textBox21.DataField = "StockAddUpADateStringRF";
            this.textBox21.Height = 0.125F;
            this.textBox21.Left = 3.625F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox21.Text = "YYYY/MM/DD";
            this.textBox21.Top = 0F;
            this.textBox21.Width = 0.625F;
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
            this.textBox22.DataField = "SupplierSlipNote1RF";
            this.textBox22.Height = 0.125F;
            this.textBox22.Left = 6.625F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox22.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.textBox22.Top = 0F;
            this.textBox22.Width = 2.25F;
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
            // DailyFooter
            // 
            this.DailyFooter.CanShrink = true;
            this.DailyFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DailyFooter_TaxRF,
            this.DailyFooterTitle,
            this.textBox10,
            this.line4,
            this.DailyFooter_suppCTaxLayCdRFTextBox});
            this.DailyFooter.Height = 0.3854167F;
            this.DailyFooter.KeepTogether = true;
            this.DailyFooter.Name = "DailyFooter";
            this.DailyFooter.Format += new System.EventHandler(this.DailyFooter_Format);
            this.DailyFooter.BeforePrint += new System.EventHandler(this.DailyFooter_BeforePrint);
            // 
            // DailyFooter_TaxRF
            // 
            this.DailyFooter_TaxRF.Border.BottomColor = System.Drawing.Color.Black;
            this.DailyFooter_TaxRF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_TaxRF.Border.LeftColor = System.Drawing.Color.Black;
            this.DailyFooter_TaxRF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_TaxRF.Border.RightColor = System.Drawing.Color.Black;
            this.DailyFooter_TaxRF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_TaxRF.Border.TopColor = System.Drawing.Color.Black;
            this.DailyFooter_TaxRF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_TaxRF.DataField = "TaxRF";
            this.DailyFooter_TaxRF.Height = 0.125F;
            this.DailyFooter_TaxRF.Left = 9.938F;
            this.DailyFooter_TaxRF.MultiLine = false;
            this.DailyFooter_TaxRF.Name = "DailyFooter_TaxRF";
            this.DailyFooter_TaxRF.OutputFormat = resources.GetString("DailyFooter_TaxRF.OutputFormat");
            this.DailyFooter_TaxRF.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DailyFooter_TaxRF.SummaryGroup = "DailyHeader";
            this.DailyFooter_TaxRF.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.DailyFooter_TaxRF.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DailyFooter_TaxRF.Text = "ZZ,ZZZ,ZZ9";
            this.DailyFooter_TaxRF.Top = 0F;
            this.DailyFooter_TaxRF.Width = 0.65F;
            // 
            // DailyFooterTitle
            // 
            this.DailyFooterTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.DailyFooterTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooterTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.DailyFooterTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooterTitle.Border.RightColor = System.Drawing.Color.Black;
            this.DailyFooterTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooterTitle.Border.TopColor = System.Drawing.Color.Black;
            this.DailyFooterTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooterTitle.Height = 0.18F;
            this.DailyFooterTitle.Left = 6.888F;
            this.DailyFooterTitle.MultiLine = false;
            this.DailyFooterTitle.Name = "DailyFooterTitle";
            this.DailyFooterTitle.OutputFormat = resources.GetString("DailyFooterTitle.OutputFormat");
            this.DailyFooterTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DailyFooterTitle.Text = "伝票計";
            this.DailyFooterTitle.Top = 0F;
            this.DailyFooterTitle.Width = 0.65F;
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
            this.textBox10.DataField = "StockPriceTaxExcRF";
            this.textBox10.Height = 0.125F;
            this.textBox10.Left = 9.062F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox10.SummaryGroup = "DailyHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.9375F;
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
            // DailyFooter_suppCTaxLayCdRFTextBox
            // 
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyFooter_suppCTaxLayCdRFTextBox.DataField = "SuppCTaxLayCd";
            this.DailyFooter_suppCTaxLayCdRFTextBox.Height = 0.125F;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Left = 9.1875F;
            this.DailyFooter_suppCTaxLayCdRFTextBox.MultiLine = false;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Name = "DailyFooter_suppCTaxLayCdRFTextBox";
            this.DailyFooter_suppCTaxLayCdRFTextBox.OutputFormat = resources.GetString("DailyFooter_suppCTaxLayCdRFTextBox.OutputFormat");
            this.DailyFooter_suppCTaxLayCdRFTextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.DailyFooter_suppCTaxLayCdRFTextBox.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Var;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Text = "-1";
            this.DailyFooter_suppCTaxLayCdRFTextBox.Top = 0.1875F;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Visible = false;
            this.DailyFooter_suppCTaxLayCdRFTextBox.Width = 0.3F;
            // 
            // groupFooter1Title
            // 
            this.groupFooter1Title.Border.BottomColor = System.Drawing.Color.Black;
            this.groupFooter1Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title.Border.LeftColor = System.Drawing.Color.Black;
            this.groupFooter1Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title.Border.RightColor = System.Drawing.Color.Black;
            this.groupFooter1Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title.Border.TopColor = System.Drawing.Color.Black;
            this.groupFooter1Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title.Height = 0.18F;
            this.groupFooter1Title.Left = 6.89F;
            this.groupFooter1Title.MultiLine = false;
            this.groupFooter1Title.Name = "groupFooter1Title";
            this.groupFooter1Title.OutputFormat = resources.GetString("groupFooter1Title.OutputFormat");
            this.groupFooter1Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.groupFooter1Title.Text = "仕入先計";
            this.groupFooter1Title.Top = 0F;
            this.groupFooter1Title.Width = 0.65F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.CanShrink = true;
            this.groupHeader1.DataField = "groupHeader1DataField";
            this.groupHeader1.Height = 0F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.CanShrink = true;
            this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox6,
            this.groupFooter1Title,
            this.line3,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox38,
            this.textBox40,
            this.textBox50,
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox85,
            this.textBox86});
            this.groupFooter1.Height = 0.7708333F;
            this.groupFooter1.KeepTogether = true;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Format += new System.EventHandler(this.groupFooter1_Format);
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
            this.textBox6.DataField = "StockPriceTaxExcRF";
            this.textBox6.Height = 0.16F;
            this.textBox6.Left = 9.06F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.SummaryGroup = "groupHeader1";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox6.Top = 0.5625F;
            this.textBox6.Width = 0.938F;
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
            this.textBox18.Height = 0.156F;
            this.textBox18.Left = 7.638F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox18.Text = "返品";
            this.textBox18.Top = 0.188F;
            this.textBox18.Width = 0.3F;
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
            this.textBox19.Height = 0.156F;
            this.textBox19.Left = 7.638F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox19.Text = "仕入";
            this.textBox19.Top = 0F;
            this.textBox19.Width = 0.3F;
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
            this.textBox20.Height = 0.156F;
            this.textBox20.Left = 7.638F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox20.Text = "合計";
            this.textBox20.Top = 0.563F;
            this.textBox20.Width = 0.3F;
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
            this.textBox38.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox38.Height = 0.16F;
            this.textBox38.Left = 9.06F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox38.SummaryGroup = "groupHeader1";
            this.textBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox38.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox38.Top = 0.1875F;
            this.textBox38.Width = 0.938F;
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
            this.textBox40.DataField = "SalStockPricTaxExcRF";
            this.textBox40.Height = 0.16F;
            this.textBox40.Left = 9.06F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.SummaryGroup = "groupHeader1";
            this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox40.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox40.Top = 0F;
            this.textBox40.Width = 0.938F;
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
            this.textBox50.DataField = "SalCntRF";
            this.textBox50.Height = 0.16F;
            this.textBox50.Left = 7.938F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox50.SummaryGroup = "groupHeader1";
            this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox50.Text = "123,456";
            this.textBox50.Top = 0F;
            this.textBox50.Width = 0.5125F;
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
            this.textBox51.Height = 0.156F;
            this.textBox51.Left = 8.51F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox51.Text = "枚";
            this.textBox51.Top = 0F;
            this.textBox51.Width = 0.15F;
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
            this.textBox52.DataField = "DisCntRF";
            this.textBox52.Height = 0.156F;
            this.textBox52.Left = 7.938F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox52.SummaryGroup = "groupHeader1";
            this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox52.Text = "123,456";
            this.textBox52.Top = 0.1875F;
            this.textBox52.Width = 0.51F;
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
            this.textBox53.Height = 0.156F;
            this.textBox53.Left = 8.51F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox53.Text = "枚";
            this.textBox53.Top = 0.1875F;
            this.textBox53.Width = 0.15F;
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
            this.textBox54.DataField = "TotleCntRF";
            this.textBox54.Height = 0.156F;
            this.textBox54.Left = 7.938F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.SummaryGroup = "groupHeader1";
            this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox54.Text = "123,456";
            this.textBox54.Top = 0.5625F;
            this.textBox54.Width = 0.51F;
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
            this.textBox55.Height = 0.156F;
            this.textBox55.Left = 8.51F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox55.Text = "枚";
            this.textBox55.Top = 0.5625F;
            this.textBox55.Width = 0.15F;
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
            this.textBox85.Height = 0.156F;
            this.textBox85.Left = 7.638F;
            this.textBox85.MultiLine = false;
            this.textBox85.Name = "textBox85";
            this.textBox85.OutputFormat = resources.GetString("textBox85.OutputFormat");
            this.textBox85.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox85.Text = "値引";
            this.textBox85.Top = 0.375F;
            this.textBox85.Width = 0.3F;
            // 
            // textBox86
            // 
            this.textBox86.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.RightColor = System.Drawing.Color.Black;
            this.textBox86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.TopColor = System.Drawing.Color.Black;
            this.textBox86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.DataField = "DisStockPricTaxExcRF";
            this.textBox86.Height = 0.16F;
            this.textBox86.Left = 9.06F;
            this.textBox86.MultiLine = false;
            this.textBox86.Name = "textBox86";
            this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
            this.textBox86.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox86.SummaryGroup = "groupHeader1";
            this.textBox86.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox86.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox86.Top = 0.375F;
            this.textBox86.Width = 0.938F;
            // 
            // groupHeader2
            // 
            this.groupHeader2.CanShrink = true;
            this.groupHeader2.DataField = "StockDateStringRF";
            this.groupHeader2.Height = 0F;
            this.groupHeader2.Name = "groupHeader2";
            // 
            // groupFooter2
            // 
            this.groupFooter2.CanShrink = true;
            this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox3,
            this.groupFooter2Title,
            this.line2,
            this.textBox68,
            this.textBox69,
            this.textBox70,
            this.textBox71,
            this.textBox72,
            this.textBox73,
            this.textBox74,
            this.textBox75,
            this.textBox76,
            this.textBox77,
            this.textBox79,
            this.textBox84,
            this.textBox87});
            this.groupFooter2.Height = 0.78125F;
            this.groupFooter2.KeepTogether = true;
            this.groupFooter2.Name = "groupFooter2";
            this.groupFooter2.Format += new System.EventHandler(this.groupFooter2_Format);
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
            this.textBox3.DataField = "SalStockPricTaxExcRF";
            this.textBox3.Height = 0.16F;
            this.textBox3.Left = 9.06F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox3.SummaryGroup = "groupHeader2";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.938F;
            // 
            // groupFooter2Title
            // 
            this.groupFooter2Title.Border.BottomColor = System.Drawing.Color.Black;
            this.groupFooter2Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title.Border.LeftColor = System.Drawing.Color.Black;
            this.groupFooter2Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title.Border.RightColor = System.Drawing.Color.Black;
            this.groupFooter2Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title.Border.TopColor = System.Drawing.Color.Black;
            this.groupFooter2Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title.Height = 0.18F;
            this.groupFooter2Title.Left = 6.89F;
            this.groupFooter2Title.MultiLine = false;
            this.groupFooter2Title.Name = "groupFooter2Title";
            this.groupFooter2Title.OutputFormat = resources.GetString("groupFooter2Title.OutputFormat");
            this.groupFooter2Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.groupFooter2Title.Text = "仕入日計";
            this.groupFooter2Title.Top = 0F;
            this.groupFooter2Title.Width = 0.65F;
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
            // textBox68
            // 
            this.textBox68.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.RightColor = System.Drawing.Color.Black;
            this.textBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.TopColor = System.Drawing.Color.Black;
            this.textBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Height = 0.156F;
            this.textBox68.Left = 7.638F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
            this.textBox68.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox68.Text = "返品";
            this.textBox68.Top = 0.188F;
            this.textBox68.Width = 0.3F;
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
            this.textBox69.Height = 0.156F;
            this.textBox69.Left = 7.638F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox69.Text = "仕入";
            this.textBox69.Top = 0F;
            this.textBox69.Width = 0.3F;
            // 
            // textBox70
            // 
            this.textBox70.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Border.RightColor = System.Drawing.Color.Black;
            this.textBox70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Border.TopColor = System.Drawing.Color.Black;
            this.textBox70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Height = 0.156F;
            this.textBox70.Left = 7.638F;
            this.textBox70.MultiLine = false;
            this.textBox70.Name = "textBox70";
            this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
            this.textBox70.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox70.Text = "合計";
            this.textBox70.Top = 0.563F;
            this.textBox70.Width = 0.3F;
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
            this.textBox71.Height = 0.156F;
            this.textBox71.Left = 8.51F;
            this.textBox71.MultiLine = false;
            this.textBox71.Name = "textBox71";
            this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
            this.textBox71.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox71.Text = "枚";
            this.textBox71.Top = 0F;
            this.textBox71.Width = 0.15F;
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
            this.textBox72.Height = 0.156F;
            this.textBox72.Left = 8.51F;
            this.textBox72.MultiLine = false;
            this.textBox72.Name = "textBox72";
            this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
            this.textBox72.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox72.Text = "枚";
            this.textBox72.Top = 0.1875F;
            this.textBox72.Width = 0.15F;
            // 
            // textBox73
            // 
            this.textBox73.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.RightColor = System.Drawing.Color.Black;
            this.textBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.TopColor = System.Drawing.Color.Black;
            this.textBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Height = 0.156F;
            this.textBox73.Left = 8.51F;
            this.textBox73.MultiLine = false;
            this.textBox73.Name = "textBox73";
            this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
            this.textBox73.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox73.Text = "枚";
            this.textBox73.Top = 0.5625F;
            this.textBox73.Width = 0.15F;
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
            this.textBox74.DataField = "SalCntRF";
            this.textBox74.Height = 0.16F;
            this.textBox74.Left = 7.938F;
            this.textBox74.MultiLine = false;
            this.textBox74.Name = "textBox74";
            this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
            this.textBox74.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox74.SummaryGroup = "groupHeader2";
            this.textBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox74.Text = "123,456";
            this.textBox74.Top = 0F;
            this.textBox74.Width = 0.5125F;
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
            this.textBox75.DataField = "DisCntRF";
            this.textBox75.Height = 0.156F;
            this.textBox75.Left = 7.938F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
            this.textBox75.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox75.SummaryGroup = "groupHeader2";
            this.textBox75.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox75.Text = "123,456";
            this.textBox75.Top = 0.1875F;
            this.textBox75.Width = 0.51F;
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
            this.textBox76.DataField = "TotleCntRF";
            this.textBox76.Height = 0.156F;
            this.textBox76.Left = 7.938F;
            this.textBox76.MultiLine = false;
            this.textBox76.Name = "textBox76";
            this.textBox76.OutputFormat = resources.GetString("textBox76.OutputFormat");
            this.textBox76.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox76.SummaryGroup = "groupHeader2";
            this.textBox76.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox76.Text = "123,456";
            this.textBox76.Top = 0.5625F;
            this.textBox76.Width = 0.51F;
            // 
            // textBox77
            // 
            this.textBox77.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.RightColor = System.Drawing.Color.Black;
            this.textBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.TopColor = System.Drawing.Color.Black;
            this.textBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox77.Height = 0.16F;
            this.textBox77.Left = 9.06F;
            this.textBox77.MultiLine = false;
            this.textBox77.Name = "textBox77";
            this.textBox77.OutputFormat = resources.GetString("textBox77.OutputFormat");
            this.textBox77.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox77.SummaryGroup = "groupHeader2";
            this.textBox77.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox77.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox77.Top = 0.1875F;
            this.textBox77.Width = 0.938F;
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
            this.textBox79.DataField = "StockPriceTaxExcRF";
            this.textBox79.Height = 0.16F;
            this.textBox79.Left = 9.06F;
            this.textBox79.MultiLine = false;
            this.textBox79.Name = "textBox79";
            this.textBox79.OutputFormat = resources.GetString("textBox79.OutputFormat");
            this.textBox79.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox79.SummaryGroup = "groupHeader2";
            this.textBox79.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox79.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox79.Top = 0.5625F;
            this.textBox79.Width = 0.938F;
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
            this.textBox84.Height = 0.156F;
            this.textBox84.Left = 7.638F;
            this.textBox84.MultiLine = false;
            this.textBox84.Name = "textBox84";
            this.textBox84.OutputFormat = resources.GetString("textBox84.OutputFormat");
            this.textBox84.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox84.Text = "値引";
            this.textBox84.Top = 0.375F;
            this.textBox84.Width = 0.3F;
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
            this.textBox87.DataField = "DisStockPricTaxExcRF";
            this.textBox87.Height = 0.16F;
            this.textBox87.Left = 9.06F;
            this.textBox87.MultiLine = false;
            this.textBox87.Name = "textBox87";
            this.textBox87.OutputFormat = resources.GetString("textBox87.OutputFormat");
            this.textBox87.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox87.SummaryGroup = "groupHeader2";
            this.textBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox87.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox87.Top = 0.375F;
            this.textBox87.Width = 0.938F;
            // 
            // groupHeader3
            // 
            this.groupHeader3.CanShrink = true;
            this.groupHeader3.Height = 0F;
            this.groupHeader3.Name = "groupHeader3";
            this.groupHeader3.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // groupFooter3
            // 
            this.groupFooter3.Height = 0.01041667F;
            this.groupFooter3.KeepTogether = true;
            this.groupFooter3.Name = "groupFooter3";
            // 
            // TitleHeader2
            // 
            this.TitleHeader2.CanShrink = true;
            this.TitleHeader2.Height = 0F;
            this.TitleHeader2.Name = "TitleHeader2";
            this.TitleHeader2.Visible = false;
            // 
            // TitleFooter2
            // 
            this.TitleFooter2.CanShrink = true;
            this.TitleFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox147,
            this.textBox180,
            this.textBox181,
            this.textBox182,
            this.textBox183,
            this.textBox184,
            this.textBox185,
            this.textBox186,
            this.textBox187,
            this.textBox188,
            this.textBox189,
            this.textBox190,
            this.textBox191,
            this.textBox192,
            this.textBox193,
            this.textBox194,
            this.textBox195,
            this.textBox196,
            this.textBox197,
            this.textBox198,
            this.textBox199,
            this.textBox200,
            this.textBox201,
            this.label49,
            this.label50,
            this.label51,
            this.textBox202,
            this.textBox203,
            this.textBox204,
            this.textBox205,
            this.textBox206,
            this.textBox207,
            this.textBox208,
            this.textBox209,
            this.textBox210,
            this.label52,
            this.label53,
            this.label54,
            this.GrandTotalTitle_2,
            this.line7,
            this.textBox221,
            this.textBox222,
            this.label48,
            this.textBox223,
            this.textBox227,
            this.textBox228,
            this.label62,
            this.textBox229});
            this.TitleFooter2.Height = 2.541667F;
            this.TitleFooter2.KeepTogether = true;
            this.TitleFooter2.Name = "TitleFooter2";
            this.TitleFooter2.Visible = false;
            // 
            // textBox147
            // 
            this.textBox147.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.RightColor = System.Drawing.Color.Black;
            this.textBox147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.TopColor = System.Drawing.Color.Black;
            this.textBox147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.DataField = "StockPriceTaxExcRF";
            this.textBox147.Height = 0.16F;
            this.textBox147.Left = 9.0625F;
            this.textBox147.MultiLine = false;
            this.textBox147.Name = "textBox147";
            this.textBox147.OutputFormat = resources.GetString("textBox147.OutputFormat");
            this.textBox147.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox147.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox147.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox147.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox147.Top = 2.125F;
            this.textBox147.Width = 0.938F;
            // 
            // textBox180
            // 
            this.textBox180.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox180.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox180.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox180.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox180.Border.RightColor = System.Drawing.Color.Black;
            this.textBox180.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox180.Border.TopColor = System.Drawing.Color.Black;
            this.textBox180.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox180.Height = 0.156F;
            this.textBox180.Left = 7.625F;
            this.textBox180.MultiLine = false;
            this.textBox180.Name = "textBox180";
            this.textBox180.OutputFormat = resources.GetString("textBox180.OutputFormat");
            this.textBox180.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox180.Text = "返品";
            this.textBox180.Top = 1F;
            this.textBox180.Width = 0.3F;
            // 
            // textBox181
            // 
            this.textBox181.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox181.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox181.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Border.RightColor = System.Drawing.Color.Black;
            this.textBox181.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Border.TopColor = System.Drawing.Color.Black;
            this.textBox181.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Height = 0.156F;
            this.textBox181.Left = 7.638F;
            this.textBox181.MultiLine = false;
            this.textBox181.Name = "textBox181";
            this.textBox181.OutputFormat = resources.GetString("textBox181.OutputFormat");
            this.textBox181.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox181.Text = "仕入";
            this.textBox181.Top = 0.063F;
            this.textBox181.Width = 0.3F;
            // 
            // textBox182
            // 
            this.textBox182.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox182.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox182.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox182.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox182.Border.RightColor = System.Drawing.Color.Black;
            this.textBox182.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox182.Border.TopColor = System.Drawing.Color.Black;
            this.textBox182.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox182.Height = 0.156F;
            this.textBox182.Left = 7.625F;
            this.textBox182.MultiLine = false;
            this.textBox182.Name = "textBox182";
            this.textBox182.OutputFormat = resources.GetString("textBox182.OutputFormat");
            this.textBox182.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox182.Text = "合計";
            this.textBox182.Top = 2.125F;
            this.textBox182.Width = 0.3F;
            // 
            // textBox183
            // 
            this.textBox183.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox183.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox183.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox183.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox183.Border.RightColor = System.Drawing.Color.Black;
            this.textBox183.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox183.Border.TopColor = System.Drawing.Color.Black;
            this.textBox183.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox183.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox183.Height = 0.16F;
            this.textBox183.Left = 9.0625F;
            this.textBox183.MultiLine = false;
            this.textBox183.Name = "textBox183";
            this.textBox183.OutputFormat = resources.GetString("textBox183.OutputFormat");
            this.textBox183.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox183.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox183.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox183.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox183.Top = 1F;
            this.textBox183.Width = 0.938F;
            // 
            // textBox184
            // 
            this.textBox184.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox184.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox184.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Border.RightColor = System.Drawing.Color.Black;
            this.textBox184.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Border.TopColor = System.Drawing.Color.Black;
            this.textBox184.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.DataField = "SalStockPricTaxExcRF";
            this.textBox184.Height = 0.16F;
            this.textBox184.Left = 9.06F;
            this.textBox184.MultiLine = false;
            this.textBox184.Name = "textBox184";
            this.textBox184.OutputFormat = resources.GetString("textBox184.OutputFormat");
            this.textBox184.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox184.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox184.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox184.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox184.Top = 0.0625F;
            this.textBox184.Width = 0.938F;
            // 
            // textBox185
            // 
            this.textBox185.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox185.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox185.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox185.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox185.Border.RightColor = System.Drawing.Color.Black;
            this.textBox185.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox185.Border.TopColor = System.Drawing.Color.Black;
            this.textBox185.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox185.DataField = "SalCntRF";
            this.textBox185.Height = 0.16F;
            this.textBox185.Left = 7.938F;
            this.textBox185.MultiLine = false;
            this.textBox185.Name = "textBox185";
            this.textBox185.OutputFormat = resources.GetString("textBox185.OutputFormat");
            this.textBox185.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox185.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox185.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox185.Text = "123,456";
            this.textBox185.Top = 0.0625F;
            this.textBox185.Width = 0.5125F;
            // 
            // textBox186
            // 
            this.textBox186.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox186.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox186.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox186.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox186.Border.RightColor = System.Drawing.Color.Black;
            this.textBox186.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox186.Border.TopColor = System.Drawing.Color.Black;
            this.textBox186.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox186.Height = 0.156F;
            this.textBox186.Left = 8.51F;
            this.textBox186.MultiLine = false;
            this.textBox186.Name = "textBox186";
            this.textBox186.OutputFormat = resources.GetString("textBox186.OutputFormat");
            this.textBox186.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox186.Text = "枚";
            this.textBox186.Top = 0.0625F;
            this.textBox186.Width = 0.15F;
            // 
            // textBox187
            // 
            this.textBox187.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox187.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox187.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox187.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox187.Border.RightColor = System.Drawing.Color.Black;
            this.textBox187.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox187.Border.TopColor = System.Drawing.Color.Black;
            this.textBox187.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox187.DataField = "DisCntRF";
            this.textBox187.Height = 0.156F;
            this.textBox187.Left = 7.9375F;
            this.textBox187.MultiLine = false;
            this.textBox187.Name = "textBox187";
            this.textBox187.OutputFormat = resources.GetString("textBox187.OutputFormat");
            this.textBox187.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox187.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox187.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox187.Text = "123,456";
            this.textBox187.Top = 1F;
            this.textBox187.Width = 0.51F;
            // 
            // textBox188
            // 
            this.textBox188.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox188.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox188.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox188.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox188.Border.RightColor = System.Drawing.Color.Black;
            this.textBox188.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox188.Border.TopColor = System.Drawing.Color.Black;
            this.textBox188.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox188.Height = 0.156F;
            this.textBox188.Left = 8.51F;
            this.textBox188.MultiLine = false;
            this.textBox188.Name = "textBox188";
            this.textBox188.OutputFormat = resources.GetString("textBox188.OutputFormat");
            this.textBox188.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox188.Text = "枚";
            this.textBox188.Top = 1F;
            this.textBox188.Width = 0.15F;
            // 
            // textBox189
            // 
            this.textBox189.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox189.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox189.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox189.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox189.Border.RightColor = System.Drawing.Color.Black;
            this.textBox189.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox189.Border.TopColor = System.Drawing.Color.Black;
            this.textBox189.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox189.DataField = "TotleCntRF";
            this.textBox189.Height = 0.156F;
            this.textBox189.Left = 7.9375F;
            this.textBox189.MultiLine = false;
            this.textBox189.Name = "textBox189";
            this.textBox189.OutputFormat = resources.GetString("textBox189.OutputFormat");
            this.textBox189.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox189.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox189.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox189.Text = "123,456";
            this.textBox189.Top = 2.125F;
            this.textBox189.Width = 0.51F;
            // 
            // textBox190
            // 
            this.textBox190.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox190.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox190.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox190.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox190.Border.RightColor = System.Drawing.Color.Black;
            this.textBox190.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox190.Border.TopColor = System.Drawing.Color.Black;
            this.textBox190.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox190.Height = 0.156F;
            this.textBox190.Left = 8.5F;
            this.textBox190.MultiLine = false;
            this.textBox190.Name = "textBox190";
            this.textBox190.OutputFormat = resources.GetString("textBox190.OutputFormat");
            this.textBox190.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox190.Text = "枚";
            this.textBox190.Top = 2.125F;
            this.textBox190.Width = 0.15F;
            // 
            // textBox191
            // 
            this.textBox191.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox191.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox191.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox191.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox191.Border.RightColor = System.Drawing.Color.Black;
            this.textBox191.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox191.Border.TopColor = System.Drawing.Color.Black;
            this.textBox191.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox191.Height = 0.156F;
            this.textBox191.Left = 7.625F;
            this.textBox191.MultiLine = false;
            this.textBox191.Name = "textBox191";
            this.textBox191.OutputFormat = resources.GetString("textBox191.OutputFormat");
            this.textBox191.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox191.Text = "値引";
            this.textBox191.Top = 1.9375F;
            this.textBox191.Width = 0.3F;
            // 
            // textBox192
            // 
            this.textBox192.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox192.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox192.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox192.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox192.Border.RightColor = System.Drawing.Color.Black;
            this.textBox192.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox192.Border.TopColor = System.Drawing.Color.Black;
            this.textBox192.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox192.DataField = "DisStockPricTaxExcRF";
            this.textBox192.Height = 0.16F;
            this.textBox192.Left = 9.0625F;
            this.textBox192.MultiLine = false;
            this.textBox192.Name = "textBox192";
            this.textBox192.OutputFormat = resources.GetString("textBox192.OutputFormat");
            this.textBox192.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox192.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox192.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox192.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox192.Top = 1.9375F;
            this.textBox192.Width = 0.938F;
            // 
            // textBox193
            // 
            this.textBox193.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox193.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox193.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox193.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox193.Border.RightColor = System.Drawing.Color.Black;
            this.textBox193.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox193.Border.TopColor = System.Drawing.Color.Black;
            this.textBox193.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox193.DataField = "TaxRate1StockTtlPricTaxExcRF";
            this.textBox193.Height = 0.16F;
            this.textBox193.Left = 9.06F;
            this.textBox193.MultiLine = false;
            this.textBox193.Name = "textBox193";
            this.textBox193.OutputFormat = resources.GetString("textBox193.OutputFormat");
            this.textBox193.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox193.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox193.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox193.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox193.Top = 0.25F;
            this.textBox193.Width = 0.938F;
            // 
            // textBox194
            // 
            this.textBox194.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox194.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox194.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox194.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox194.Border.RightColor = System.Drawing.Color.Black;
            this.textBox194.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox194.Border.TopColor = System.Drawing.Color.Black;
            this.textBox194.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox194.Height = 0.156F;
            this.textBox194.Left = 8.51F;
            this.textBox194.MultiLine = false;
            this.textBox194.Name = "textBox194";
            this.textBox194.OutputFormat = resources.GetString("textBox194.OutputFormat");
            this.textBox194.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox194.Text = "枚";
            this.textBox194.Top = 0.25F;
            this.textBox194.Width = 0.15F;
            // 
            // textBox195
            // 
            this.textBox195.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox195.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox195.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox195.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox195.Border.RightColor = System.Drawing.Color.Black;
            this.textBox195.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox195.Border.TopColor = System.Drawing.Color.Black;
            this.textBox195.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox195.DataField = "TaxRate1SalSlipCntRF";
            this.textBox195.Height = 0.16F;
            this.textBox195.Left = 7.938F;
            this.textBox195.MultiLine = false;
            this.textBox195.Name = "textBox195";
            this.textBox195.OutputFormat = resources.GetString("textBox195.OutputFormat");
            this.textBox195.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox195.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox195.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox195.Text = "123,456";
            this.textBox195.Top = 0.25F;
            this.textBox195.Width = 0.5125F;
            // 
            // textBox196
            // 
            this.textBox196.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox196.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox196.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox196.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox196.Border.RightColor = System.Drawing.Color.Black;
            this.textBox196.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox196.Border.TopColor = System.Drawing.Color.Black;
            this.textBox196.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox196.DataField = "TaxRate2StockTtlPricTaxExcRF";
            this.textBox196.Height = 0.16F;
            this.textBox196.Left = 9.06F;
            this.textBox196.MultiLine = false;
            this.textBox196.Name = "textBox196";
            this.textBox196.OutputFormat = resources.GetString("textBox196.OutputFormat");
            this.textBox196.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox196.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox196.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox196.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox196.Top = 0.4375F;
            this.textBox196.Width = 0.938F;
            // 
            // textBox197
            // 
            this.textBox197.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox197.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox197.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox197.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox197.Border.RightColor = System.Drawing.Color.Black;
            this.textBox197.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox197.Border.TopColor = System.Drawing.Color.Black;
            this.textBox197.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox197.Height = 0.156F;
            this.textBox197.Left = 8.51F;
            this.textBox197.MultiLine = false;
            this.textBox197.Name = "textBox197";
            this.textBox197.OutputFormat = resources.GetString("textBox197.OutputFormat");
            this.textBox197.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox197.Text = "枚";
            this.textBox197.Top = 0.4375F;
            this.textBox197.Width = 0.15F;
            // 
            // textBox198
            // 
            this.textBox198.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox198.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox198.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox198.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox198.Border.RightColor = System.Drawing.Color.Black;
            this.textBox198.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox198.Border.TopColor = System.Drawing.Color.Black;
            this.textBox198.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox198.DataField = "TaxRate2SalSlipCntRF";
            this.textBox198.Height = 0.16F;
            this.textBox198.Left = 7.938F;
            this.textBox198.MultiLine = false;
            this.textBox198.Name = "textBox198";
            this.textBox198.OutputFormat = resources.GetString("textBox198.OutputFormat");
            this.textBox198.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox198.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox198.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox198.Text = "123,456";
            this.textBox198.Top = 0.4375F;
            this.textBox198.Width = 0.5125F;
            // 
            // textBox199
            // 
            this.textBox199.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox199.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox199.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox199.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox199.Border.RightColor = System.Drawing.Color.Black;
            this.textBox199.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox199.Border.TopColor = System.Drawing.Color.Black;
            this.textBox199.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox199.DataField = "OtherStockTtlPricTaxExcRF";
            this.textBox199.Height = 0.16F;
            this.textBox199.Left = 9.06F;
            this.textBox199.MultiLine = false;
            this.textBox199.Name = "textBox199";
            this.textBox199.OutputFormat = resources.GetString("textBox199.OutputFormat");
            this.textBox199.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox199.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox199.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox199.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox199.Top = 0.625F;
            this.textBox199.Width = 0.938F;
            // 
            // textBox200
            // 
            this.textBox200.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox200.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox200.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox200.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox200.Border.RightColor = System.Drawing.Color.Black;
            this.textBox200.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox200.Border.TopColor = System.Drawing.Color.Black;
            this.textBox200.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox200.Height = 0.156F;
            this.textBox200.Left = 8.51F;
            this.textBox200.MultiLine = false;
            this.textBox200.Name = "textBox200";
            this.textBox200.OutputFormat = resources.GetString("textBox200.OutputFormat");
            this.textBox200.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox200.Text = "枚";
            this.textBox200.Top = 0.625F;
            this.textBox200.Width = 0.15F;
            // 
            // textBox201
            // 
            this.textBox201.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox201.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox201.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox201.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox201.Border.RightColor = System.Drawing.Color.Black;
            this.textBox201.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox201.Border.TopColor = System.Drawing.Color.Black;
            this.textBox201.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox201.DataField = "OtherSalSlipCntRF";
            this.textBox201.Height = 0.16F;
            this.textBox201.Left = 7.938F;
            this.textBox201.MultiLine = false;
            this.textBox201.Name = "textBox201";
            this.textBox201.OutputFormat = resources.GetString("textBox201.OutputFormat");
            this.textBox201.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox201.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox201.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox201.Text = "123,456";
            this.textBox201.Top = 0.625F;
            this.textBox201.Width = 0.5125F;
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
            this.label49.DataField = "TaxRate1Title";
            this.label49.Height = 0.16F;
            this.label49.HyperLink = null;
            this.label49.Left = 8.7F;
            this.label49.Name = "label49";
            this.label49.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label49.Text = "税率１";
            this.label49.Top = 0.25F;
            this.label49.Width = 0.5F;
            // 
            // label50
            // 
            this.label50.Border.BottomColor = System.Drawing.Color.Black;
            this.label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.LeftColor = System.Drawing.Color.Black;
            this.label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.RightColor = System.Drawing.Color.Black;
            this.label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.TopColor = System.Drawing.Color.Black;
            this.label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.DataField = "TaxRate2Title";
            this.label50.Height = 0.16F;
            this.label50.HyperLink = null;
            this.label50.Left = 8.7F;
            this.label50.Name = "label50";
            this.label50.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label50.Text = "税率２";
            this.label50.Top = 0.4375F;
            this.label50.Width = 0.5F;
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
            this.label51.DataField = "OtherTitle";
            this.label51.Height = 0.16F;
            this.label51.HyperLink = null;
            this.label51.Left = 8.7F;
            this.label51.Name = "label51";
            this.label51.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label51.Text = "その他";
            this.label51.Top = 0.625F;
            this.label51.Width = 0.5F;
            // 
            // textBox202
            // 
            this.textBox202.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox202.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox202.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox202.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox202.Border.RightColor = System.Drawing.Color.Black;
            this.textBox202.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox202.Border.TopColor = System.Drawing.Color.Black;
            this.textBox202.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox202.DataField = "TaxRate1RetGdsStockTtlPricTaxExcRF";
            this.textBox202.Height = 0.16F;
            this.textBox202.Left = 9.0625F;
            this.textBox202.MultiLine = false;
            this.textBox202.Name = "textBox202";
            this.textBox202.OutputFormat = resources.GetString("textBox202.OutputFormat");
            this.textBox202.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox202.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox202.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox202.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox202.Top = 1.1875F;
            this.textBox202.Width = 0.938F;
            // 
            // textBox203
            // 
            this.textBox203.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox203.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox203.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox203.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox203.Border.RightColor = System.Drawing.Color.Black;
            this.textBox203.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox203.Border.TopColor = System.Drawing.Color.Black;
            this.textBox203.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox203.Height = 0.156F;
            this.textBox203.Left = 8.51F;
            this.textBox203.MultiLine = false;
            this.textBox203.Name = "textBox203";
            this.textBox203.OutputFormat = resources.GetString("textBox203.OutputFormat");
            this.textBox203.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox203.Text = "枚";
            this.textBox203.Top = 1.188F;
            this.textBox203.Width = 0.15F;
            // 
            // textBox204
            // 
            this.textBox204.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox204.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox204.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox204.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox204.Border.RightColor = System.Drawing.Color.Black;
            this.textBox204.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox204.Border.TopColor = System.Drawing.Color.Black;
            this.textBox204.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox204.DataField = "TaxRate1DisSlipCntRF";
            this.textBox204.Height = 0.16F;
            this.textBox204.Left = 7.9375F;
            this.textBox204.MultiLine = false;
            this.textBox204.Name = "textBox204";
            this.textBox204.OutputFormat = resources.GetString("textBox204.OutputFormat");
            this.textBox204.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox204.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox204.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox204.Text = "123,456";
            this.textBox204.Top = 1.1875F;
            this.textBox204.Width = 0.5125F;
            // 
            // textBox205
            // 
            this.textBox205.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox205.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox205.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox205.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox205.Border.RightColor = System.Drawing.Color.Black;
            this.textBox205.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox205.Border.TopColor = System.Drawing.Color.Black;
            this.textBox205.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox205.DataField = "TaxRate2RetGdsStockTtlPricTaxExcRF";
            this.textBox205.Height = 0.16F;
            this.textBox205.Left = 9.0625F;
            this.textBox205.MultiLine = false;
            this.textBox205.Name = "textBox205";
            this.textBox205.OutputFormat = resources.GetString("textBox205.OutputFormat");
            this.textBox205.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox205.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox205.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox205.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox205.Top = 1.375F;
            this.textBox205.Width = 0.938F;
            // 
            // textBox206
            // 
            this.textBox206.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox206.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox206.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox206.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox206.Border.RightColor = System.Drawing.Color.Black;
            this.textBox206.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox206.Border.TopColor = System.Drawing.Color.Black;
            this.textBox206.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox206.Height = 0.156F;
            this.textBox206.Left = 8.51F;
            this.textBox206.MultiLine = false;
            this.textBox206.Name = "textBox206";
            this.textBox206.OutputFormat = resources.GetString("textBox206.OutputFormat");
            this.textBox206.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox206.Text = "枚";
            this.textBox206.Top = 1.375F;
            this.textBox206.Width = 0.15F;
            // 
            // textBox207
            // 
            this.textBox207.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox207.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox207.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox207.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox207.Border.RightColor = System.Drawing.Color.Black;
            this.textBox207.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox207.Border.TopColor = System.Drawing.Color.Black;
            this.textBox207.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox207.DataField = "TaxRate2DisSlipCntRF";
            this.textBox207.Height = 0.16F;
            this.textBox207.Left = 7.9375F;
            this.textBox207.MultiLine = false;
            this.textBox207.Name = "textBox207";
            this.textBox207.OutputFormat = resources.GetString("textBox207.OutputFormat");
            this.textBox207.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox207.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox207.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox207.Text = "123,456";
            this.textBox207.Top = 1.375F;
            this.textBox207.Width = 0.5125F;
            // 
            // textBox208
            // 
            this.textBox208.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox208.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox208.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox208.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox208.Border.RightColor = System.Drawing.Color.Black;
            this.textBox208.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox208.Border.TopColor = System.Drawing.Color.Black;
            this.textBox208.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox208.DataField = "OtherRetGdsStockTtlPricTaxExcRF";
            this.textBox208.Height = 0.16F;
            this.textBox208.Left = 9.0625F;
            this.textBox208.MultiLine = false;
            this.textBox208.Name = "textBox208";
            this.textBox208.OutputFormat = resources.GetString("textBox208.OutputFormat");
            this.textBox208.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox208.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox208.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox208.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox208.Top = 1.5625F;
            this.textBox208.Width = 0.938F;
            // 
            // textBox209
            // 
            this.textBox209.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox209.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox209.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox209.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox209.Border.RightColor = System.Drawing.Color.Black;
            this.textBox209.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox209.Border.TopColor = System.Drawing.Color.Black;
            this.textBox209.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox209.Height = 0.156F;
            this.textBox209.Left = 8.51F;
            this.textBox209.MultiLine = false;
            this.textBox209.Name = "textBox209";
            this.textBox209.OutputFormat = resources.GetString("textBox209.OutputFormat");
            this.textBox209.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox209.Text = "枚";
            this.textBox209.Top = 1.563F;
            this.textBox209.Width = 0.15F;
            // 
            // textBox210
            // 
            this.textBox210.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox210.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox210.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox210.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox210.Border.RightColor = System.Drawing.Color.Black;
            this.textBox210.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox210.Border.TopColor = System.Drawing.Color.Black;
            this.textBox210.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox210.DataField = "OtherDisSlipCntRF";
            this.textBox210.Height = 0.16F;
            this.textBox210.Left = 7.9375F;
            this.textBox210.MultiLine = false;
            this.textBox210.Name = "textBox210";
            this.textBox210.OutputFormat = resources.GetString("textBox210.OutputFormat");
            this.textBox210.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox210.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox210.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox210.Text = "123,456";
            this.textBox210.Top = 1.5625F;
            this.textBox210.Width = 0.5125F;
            // 
            // label52
            // 
            this.label52.Border.BottomColor = System.Drawing.Color.Black;
            this.label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.LeftColor = System.Drawing.Color.Black;
            this.label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.RightColor = System.Drawing.Color.Black;
            this.label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.TopColor = System.Drawing.Color.Black;
            this.label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.DataField = "TaxRate1RetTitle";
            this.label52.Height = 0.16F;
            this.label52.HyperLink = null;
            this.label52.Left = 8.7F;
            this.label52.Name = "label52";
            this.label52.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label52.Text = "税率１";
            this.label52.Top = 1.188F;
            this.label52.Width = 0.5F;
            // 
            // label53
            // 
            this.label53.Border.BottomColor = System.Drawing.Color.Black;
            this.label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.LeftColor = System.Drawing.Color.Black;
            this.label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.RightColor = System.Drawing.Color.Black;
            this.label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.TopColor = System.Drawing.Color.Black;
            this.label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.DataField = "TaxRate2RetTitle";
            this.label53.Height = 0.16F;
            this.label53.HyperLink = null;
            this.label53.Left = 8.7F;
            this.label53.Name = "label53";
            this.label53.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label53.Text = "税率２";
            this.label53.Top = 1.375F;
            this.label53.Width = 0.5F;
            // 
            // label54
            // 
            this.label54.Border.BottomColor = System.Drawing.Color.Black;
            this.label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.LeftColor = System.Drawing.Color.Black;
            this.label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.RightColor = System.Drawing.Color.Black;
            this.label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.TopColor = System.Drawing.Color.Black;
            this.label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.DataField = "OtherRetTitle";
            this.label54.Height = 0.16F;
            this.label54.HyperLink = null;
            this.label54.Left = 8.7F;
            this.label54.Name = "label54";
            this.label54.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label54.Text = "その他";
            this.label54.Top = 1.563F;
            this.label54.Width = 0.5F;
            // 
            // GrandTotalTitle_2
            // 
            this.GrandTotalTitle_2.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotalTitle_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle_2.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotalTitle_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle_2.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotalTitle_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle_2.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotalTitle_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle_2.Height = 0.18F;
            this.GrandTotalTitle_2.HyperLink = "";
            this.GrandTotalTitle_2.Left = 6.89F;
            this.GrandTotalTitle_2.MultiLine = false;
            this.GrandTotalTitle_2.Name = "GrandTotalTitle_2";
            this.GrandTotalTitle_2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle_2.Text = "総合計";
            this.GrandTotalTitle_2.Top = 0.0625F;
            this.GrandTotalTitle_2.Width = 0.65F;
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
            // SectionHeader2
            // 
            this.SectionHeader2.Height = 0F;
            this.SectionHeader2.Name = "SectionHeader2";
            this.SectionHeader2.Visible = false;
            // 
            // SectionFooter2
            // 
            this.SectionFooter2.CanShrink = true;
            this.SectionFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox146,
            this.textBox148,
            this.textBox149,
            this.textBox150,
            this.textBox151,
            this.textBox152,
            this.textBox153,
            this.textBox154,
            this.textBox155,
            this.textBox156,
            this.textBox157,
            this.textBox158,
            this.textBox159,
            this.textBox160,
            this.textBox161,
            this.textBox162,
            this.textBox163,
            this.textBox164,
            this.textBox165,
            this.textBox166,
            this.textBox167,
            this.textBox168,
            this.textBox169,
            this.label43,
            this.label44,
            this.label45,
            this.textBox170,
            this.textBox171,
            this.textBox172,
            this.textBox173,
            this.textBox174,
            this.textBox175,
            this.textBox176,
            this.textBox177,
            this.textBox178,
            this.label46,
            this.label47,
            this.SectionTitle_2,
            this.line8,
            this.textBox218,
            this.textBox219,
            this.label59,
            this.textBox220,
            this.label60,
            this.textBox224,
            this.textBox225,
            this.label61,
            this.textBox226});
            this.SectionFooter2.Height = 2.260417F;
            this.SectionFooter2.KeepTogether = true;
            this.SectionFooter2.Name = "SectionFooter2";
            this.SectionFooter2.Visible = false;
            // 
            // textBox146
            // 
            this.textBox146.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.Border.RightColor = System.Drawing.Color.Black;
            this.textBox146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.Border.TopColor = System.Drawing.Color.Black;
            this.textBox146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox146.DataField = "StockPriceTaxExcRF";
            this.textBox146.Height = 0.16F;
            this.textBox146.Left = 9.0625F;
            this.textBox146.MultiLine = false;
            this.textBox146.Name = "textBox146";
            this.textBox146.OutputFormat = resources.GetString("textBox146.OutputFormat");
            this.textBox146.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox146.SummaryGroup = "SectionHeader";
            this.textBox146.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox146.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox146.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox146.Top = 2.0625F;
            this.textBox146.Width = 0.938F;
            // 
            // textBox148
            // 
            this.textBox148.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Border.RightColor = System.Drawing.Color.Black;
            this.textBox148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Border.TopColor = System.Drawing.Color.Black;
            this.textBox148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox148.Height = 0.156F;
            this.textBox148.Left = 7.625F;
            this.textBox148.MultiLine = false;
            this.textBox148.Name = "textBox148";
            this.textBox148.OutputFormat = resources.GetString("textBox148.OutputFormat");
            this.textBox148.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox148.Text = "返品";
            this.textBox148.Top = 0.9375F;
            this.textBox148.Width = 0.3F;
            // 
            // textBox149
            // 
            this.textBox149.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Border.RightColor = System.Drawing.Color.Black;
            this.textBox149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Border.TopColor = System.Drawing.Color.Black;
            this.textBox149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox149.Height = 0.156F;
            this.textBox149.Left = 7.638F;
            this.textBox149.MultiLine = false;
            this.textBox149.Name = "textBox149";
            this.textBox149.OutputFormat = resources.GetString("textBox149.OutputFormat");
            this.textBox149.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox149.Text = "仕入";
            this.textBox149.Top = 0F;
            this.textBox149.Width = 0.3F;
            // 
            // textBox150
            // 
            this.textBox150.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.RightColor = System.Drawing.Color.Black;
            this.textBox150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.TopColor = System.Drawing.Color.Black;
            this.textBox150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Height = 0.156F;
            this.textBox150.Left = 7.625F;
            this.textBox150.MultiLine = false;
            this.textBox150.Name = "textBox150";
            this.textBox150.OutputFormat = resources.GetString("textBox150.OutputFormat");
            this.textBox150.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox150.Text = "合計";
            this.textBox150.Top = 2.0625F;
            this.textBox150.Width = 0.3F;
            // 
            // textBox151
            // 
            this.textBox151.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.Border.RightColor = System.Drawing.Color.Black;
            this.textBox151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.Border.TopColor = System.Drawing.Color.Black;
            this.textBox151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox151.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox151.Height = 0.16F;
            this.textBox151.Left = 9.0625F;
            this.textBox151.MultiLine = false;
            this.textBox151.Name = "textBox151";
            this.textBox151.OutputFormat = resources.GetString("textBox151.OutputFormat");
            this.textBox151.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox151.SummaryGroup = "SectionHeader";
            this.textBox151.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox151.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox151.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox151.Top = 0.9375F;
            this.textBox151.Width = 0.938F;
            // 
            // textBox152
            // 
            this.textBox152.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.Border.RightColor = System.Drawing.Color.Black;
            this.textBox152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.Border.TopColor = System.Drawing.Color.Black;
            this.textBox152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox152.DataField = "SalStockPricTaxExcRF";
            this.textBox152.Height = 0.16F;
            this.textBox152.Left = 9.06F;
            this.textBox152.MultiLine = false;
            this.textBox152.Name = "textBox152";
            this.textBox152.OutputFormat = resources.GetString("textBox152.OutputFormat");
            this.textBox152.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox152.SummaryGroup = "SectionHeader";
            this.textBox152.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox152.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox152.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox152.Top = 0F;
            this.textBox152.Width = 0.938F;
            // 
            // textBox153
            // 
            this.textBox153.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.RightColor = System.Drawing.Color.Black;
            this.textBox153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.TopColor = System.Drawing.Color.Black;
            this.textBox153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.DataField = "SalCntRF";
            this.textBox153.Height = 0.16F;
            this.textBox153.Left = 7.938F;
            this.textBox153.MultiLine = false;
            this.textBox153.Name = "textBox153";
            this.textBox153.OutputFormat = resources.GetString("textBox153.OutputFormat");
            this.textBox153.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox153.SummaryGroup = "SectionHeader";
            this.textBox153.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox153.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox153.Text = "123,456";
            this.textBox153.Top = 0F;
            this.textBox153.Width = 0.5125F;
            // 
            // textBox154
            // 
            this.textBox154.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Border.RightColor = System.Drawing.Color.Black;
            this.textBox154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Border.TopColor = System.Drawing.Color.Black;
            this.textBox154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox154.Height = 0.156F;
            this.textBox154.Left = 8.51F;
            this.textBox154.MultiLine = false;
            this.textBox154.Name = "textBox154";
            this.textBox154.OutputFormat = resources.GetString("textBox154.OutputFormat");
            this.textBox154.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox154.Text = "枚";
            this.textBox154.Top = 0F;
            this.textBox154.Width = 0.15F;
            // 
            // textBox155
            // 
            this.textBox155.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.Border.RightColor = System.Drawing.Color.Black;
            this.textBox155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.Border.TopColor = System.Drawing.Color.Black;
            this.textBox155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox155.DataField = "DisCntRF";
            this.textBox155.Height = 0.156F;
            this.textBox155.Left = 7.9375F;
            this.textBox155.MultiLine = false;
            this.textBox155.Name = "textBox155";
            this.textBox155.OutputFormat = resources.GetString("textBox155.OutputFormat");
            this.textBox155.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox155.SummaryGroup = "SectionHeader";
            this.textBox155.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox155.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox155.Text = "123,456";
            this.textBox155.Top = 0.9375F;
            this.textBox155.Width = 0.51F;
            // 
            // textBox156
            // 
            this.textBox156.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Border.RightColor = System.Drawing.Color.Black;
            this.textBox156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Border.TopColor = System.Drawing.Color.Black;
            this.textBox156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox156.Height = 0.156F;
            this.textBox156.Left = 8.51F;
            this.textBox156.MultiLine = false;
            this.textBox156.Name = "textBox156";
            this.textBox156.OutputFormat = resources.GetString("textBox156.OutputFormat");
            this.textBox156.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox156.Text = "枚";
            this.textBox156.Top = 0.938F;
            this.textBox156.Width = 0.15F;
            // 
            // textBox157
            // 
            this.textBox157.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.Border.RightColor = System.Drawing.Color.Black;
            this.textBox157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.Border.TopColor = System.Drawing.Color.Black;
            this.textBox157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox157.DataField = "TotleCntRF";
            this.textBox157.Height = 0.156F;
            this.textBox157.Left = 7.9375F;
            this.textBox157.MultiLine = false;
            this.textBox157.Name = "textBox157";
            this.textBox157.OutputFormat = resources.GetString("textBox157.OutputFormat");
            this.textBox157.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox157.SummaryGroup = "SectionHeader";
            this.textBox157.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox157.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox157.Text = "123,456";
            this.textBox157.Top = 2.0625F;
            this.textBox157.Width = 0.51F;
            // 
            // textBox158
            // 
            this.textBox158.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Border.RightColor = System.Drawing.Color.Black;
            this.textBox158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Border.TopColor = System.Drawing.Color.Black;
            this.textBox158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox158.Height = 0.156F;
            this.textBox158.Left = 8.5F;
            this.textBox158.MultiLine = false;
            this.textBox158.Name = "textBox158";
            this.textBox158.OutputFormat = resources.GetString("textBox158.OutputFormat");
            this.textBox158.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox158.Text = "枚";
            this.textBox158.Top = 2.0625F;
            this.textBox158.Width = 0.15F;
            // 
            // textBox159
            // 
            this.textBox159.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox159.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox159.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox159.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox159.Border.RightColor = System.Drawing.Color.Black;
            this.textBox159.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox159.Border.TopColor = System.Drawing.Color.Black;
            this.textBox159.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox159.Height = 0.156F;
            this.textBox159.Left = 7.625F;
            this.textBox159.MultiLine = false;
            this.textBox159.Name = "textBox159";
            this.textBox159.OutputFormat = resources.GetString("textBox159.OutputFormat");
            this.textBox159.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox159.Text = "値引";
            this.textBox159.Top = 1.875F;
            this.textBox159.Width = 0.3F;
            // 
            // textBox160
            // 
            this.textBox160.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox160.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox160.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox160.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox160.Border.RightColor = System.Drawing.Color.Black;
            this.textBox160.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox160.Border.TopColor = System.Drawing.Color.Black;
            this.textBox160.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox160.DataField = "DisStockPricTaxExcRF";
            this.textBox160.Height = 0.16F;
            this.textBox160.Left = 9.0625F;
            this.textBox160.MultiLine = false;
            this.textBox160.Name = "textBox160";
            this.textBox160.OutputFormat = resources.GetString("textBox160.OutputFormat");
            this.textBox160.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox160.SummaryGroup = "SectionHeader";
            this.textBox160.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox160.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox160.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox160.Top = 1.875F;
            this.textBox160.Width = 0.938F;
            // 
            // textBox161
            // 
            this.textBox161.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox161.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox161.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox161.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox161.Border.RightColor = System.Drawing.Color.Black;
            this.textBox161.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox161.Border.TopColor = System.Drawing.Color.Black;
            this.textBox161.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox161.DataField = "TaxRate1StockTtlPricTaxExcRF";
            this.textBox161.Height = 0.16F;
            this.textBox161.Left = 9.06F;
            this.textBox161.MultiLine = false;
            this.textBox161.Name = "textBox161";
            this.textBox161.OutputFormat = resources.GetString("textBox161.OutputFormat");
            this.textBox161.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox161.SummaryGroup = "SectionHeader";
            this.textBox161.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox161.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox161.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox161.Top = 0.1875F;
            this.textBox161.Width = 0.938F;
            // 
            // textBox162
            // 
            this.textBox162.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox162.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox162.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Border.RightColor = System.Drawing.Color.Black;
            this.textBox162.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Border.TopColor = System.Drawing.Color.Black;
            this.textBox162.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Height = 0.156F;
            this.textBox162.Left = 8.51F;
            this.textBox162.MultiLine = false;
            this.textBox162.Name = "textBox162";
            this.textBox162.OutputFormat = resources.GetString("textBox162.OutputFormat");
            this.textBox162.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox162.Text = "枚";
            this.textBox162.Top = 0.1875F;
            this.textBox162.Width = 0.15F;
            // 
            // textBox163
            // 
            this.textBox163.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox163.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox163.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox163.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox163.Border.RightColor = System.Drawing.Color.Black;
            this.textBox163.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox163.Border.TopColor = System.Drawing.Color.Black;
            this.textBox163.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox163.DataField = "TaxRate1SalSlipCntRF";
            this.textBox163.Height = 0.16F;
            this.textBox163.Left = 7.938F;
            this.textBox163.MultiLine = false;
            this.textBox163.Name = "textBox163";
            this.textBox163.OutputFormat = resources.GetString("textBox163.OutputFormat");
            this.textBox163.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox163.SummaryGroup = "SectionHeader";
            this.textBox163.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox163.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox163.Text = "123,456";
            this.textBox163.Top = 0.1875F;
            this.textBox163.Width = 0.5125F;
            // 
            // textBox164
            // 
            this.textBox164.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox164.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox164.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox164.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox164.Border.RightColor = System.Drawing.Color.Black;
            this.textBox164.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox164.Border.TopColor = System.Drawing.Color.Black;
            this.textBox164.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox164.DataField = "TaxRate2StockTtlPricTaxExcRF";
            this.textBox164.Height = 0.16F;
            this.textBox164.Left = 9.06F;
            this.textBox164.MultiLine = false;
            this.textBox164.Name = "textBox164";
            this.textBox164.OutputFormat = resources.GetString("textBox164.OutputFormat");
            this.textBox164.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox164.SummaryGroup = "SectionHeader";
            this.textBox164.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox164.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox164.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox164.Top = 0.375F;
            this.textBox164.Width = 0.938F;
            // 
            // textBox165
            // 
            this.textBox165.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox165.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox165.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Border.RightColor = System.Drawing.Color.Black;
            this.textBox165.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Border.TopColor = System.Drawing.Color.Black;
            this.textBox165.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Height = 0.156F;
            this.textBox165.Left = 8.51F;
            this.textBox165.MultiLine = false;
            this.textBox165.Name = "textBox165";
            this.textBox165.OutputFormat = resources.GetString("textBox165.OutputFormat");
            this.textBox165.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox165.Text = "枚";
            this.textBox165.Top = 0.375F;
            this.textBox165.Width = 0.15F;
            // 
            // textBox166
            // 
            this.textBox166.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox166.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox166.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox166.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox166.Border.RightColor = System.Drawing.Color.Black;
            this.textBox166.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox166.Border.TopColor = System.Drawing.Color.Black;
            this.textBox166.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox166.DataField = "TaxRate2SalSlipCntRF";
            this.textBox166.Height = 0.16F;
            this.textBox166.Left = 7.938F;
            this.textBox166.MultiLine = false;
            this.textBox166.Name = "textBox166";
            this.textBox166.OutputFormat = resources.GetString("textBox166.OutputFormat");
            this.textBox166.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox166.SummaryGroup = "SectionHeader";
            this.textBox166.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox166.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox166.Text = "123,456";
            this.textBox166.Top = 0.375F;
            this.textBox166.Width = 0.5125F;
            // 
            // textBox167
            // 
            this.textBox167.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox167.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox167.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox167.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox167.Border.RightColor = System.Drawing.Color.Black;
            this.textBox167.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox167.Border.TopColor = System.Drawing.Color.Black;
            this.textBox167.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox167.DataField = "OtherStockTtlPricTaxExcRF";
            this.textBox167.Height = 0.16F;
            this.textBox167.Left = 9.06F;
            this.textBox167.MultiLine = false;
            this.textBox167.Name = "textBox167";
            this.textBox167.OutputFormat = resources.GetString("textBox167.OutputFormat");
            this.textBox167.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox167.SummaryGroup = "SectionHeader";
            this.textBox167.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox167.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox167.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox167.Top = 0.5625F;
            this.textBox167.Width = 0.938F;
            // 
            // textBox168
            // 
            this.textBox168.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox168.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox168.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Border.RightColor = System.Drawing.Color.Black;
            this.textBox168.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Border.TopColor = System.Drawing.Color.Black;
            this.textBox168.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Height = 0.156F;
            this.textBox168.Left = 8.51F;
            this.textBox168.MultiLine = false;
            this.textBox168.Name = "textBox168";
            this.textBox168.OutputFormat = resources.GetString("textBox168.OutputFormat");
            this.textBox168.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox168.Text = "枚";
            this.textBox168.Top = 0.5625F;
            this.textBox168.Width = 0.15F;
            // 
            // textBox169
            // 
            this.textBox169.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox169.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox169.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox169.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox169.Border.RightColor = System.Drawing.Color.Black;
            this.textBox169.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox169.Border.TopColor = System.Drawing.Color.Black;
            this.textBox169.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox169.DataField = "OtherSalSlipCntRF";
            this.textBox169.Height = 0.16F;
            this.textBox169.Left = 7.938F;
            this.textBox169.MultiLine = false;
            this.textBox169.Name = "textBox169";
            this.textBox169.OutputFormat = resources.GetString("textBox169.OutputFormat");
            this.textBox169.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox169.SummaryGroup = "SectionHeader";
            this.textBox169.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox169.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox169.Text = "123,456";
            this.textBox169.Top = 0.5625F;
            this.textBox169.Width = 0.5125F;
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
            this.label43.DataField = "TaxRate1Title";
            this.label43.Height = 0.16F;
            this.label43.HyperLink = null;
            this.label43.Left = 8.7F;
            this.label43.Name = "label43";
            this.label43.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label43.Text = "税率１";
            this.label43.Top = 0.1875F;
            this.label43.Width = 0.5F;
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
            this.label44.DataField = "TaxRate2Title";
            this.label44.Height = 0.16F;
            this.label44.HyperLink = null;
            this.label44.Left = 8.7F;
            this.label44.Name = "label44";
            this.label44.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label44.Text = "税率２";
            this.label44.Top = 0.375F;
            this.label44.Width = 0.5F;
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
            this.label45.DataField = "OtherTitle";
            this.label45.Height = 0.16F;
            this.label45.HyperLink = null;
            this.label45.Left = 8.7F;
            this.label45.Name = "label45";
            this.label45.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label45.Text = "その他";
            this.label45.Top = 0.5625F;
            this.label45.Width = 0.5F;
            // 
            // textBox170
            // 
            this.textBox170.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox170.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox170.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox170.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox170.Border.RightColor = System.Drawing.Color.Black;
            this.textBox170.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox170.Border.TopColor = System.Drawing.Color.Black;
            this.textBox170.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox170.DataField = "TaxRate1RetGdsStockTtlPricTaxExcRF";
            this.textBox170.Height = 0.16F;
            this.textBox170.Left = 9.0625F;
            this.textBox170.MultiLine = false;
            this.textBox170.Name = "textBox170";
            this.textBox170.OutputFormat = resources.GetString("textBox170.OutputFormat");
            this.textBox170.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox170.SummaryGroup = "SectionHeader";
            this.textBox170.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox170.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox170.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox170.Top = 1.125F;
            this.textBox170.Width = 0.938F;
            // 
            // textBox171
            // 
            this.textBox171.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox171.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox171.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox171.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox171.Border.RightColor = System.Drawing.Color.Black;
            this.textBox171.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox171.Border.TopColor = System.Drawing.Color.Black;
            this.textBox171.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox171.Height = 0.156F;
            this.textBox171.Left = 8.51F;
            this.textBox171.MultiLine = false;
            this.textBox171.Name = "textBox171";
            this.textBox171.OutputFormat = resources.GetString("textBox171.OutputFormat");
            this.textBox171.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox171.Text = "枚";
            this.textBox171.Top = 1.125F;
            this.textBox171.Width = 0.15F;
            // 
            // textBox172
            // 
            this.textBox172.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox172.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox172.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox172.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox172.Border.RightColor = System.Drawing.Color.Black;
            this.textBox172.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox172.Border.TopColor = System.Drawing.Color.Black;
            this.textBox172.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox172.DataField = "TaxRate1DisSlipCntRF";
            this.textBox172.Height = 0.16F;
            this.textBox172.Left = 7.9375F;
            this.textBox172.MultiLine = false;
            this.textBox172.Name = "textBox172";
            this.textBox172.OutputFormat = resources.GetString("textBox172.OutputFormat");
            this.textBox172.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox172.SummaryGroup = "SectionHeader";
            this.textBox172.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox172.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox172.Text = "123,456";
            this.textBox172.Top = 1.125F;
            this.textBox172.Width = 0.5125F;
            // 
            // textBox173
            // 
            this.textBox173.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox173.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox173.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox173.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox173.Border.RightColor = System.Drawing.Color.Black;
            this.textBox173.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox173.Border.TopColor = System.Drawing.Color.Black;
            this.textBox173.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox173.DataField = "TaxRate2RetGdsStockTtlPricTaxExcRF";
            this.textBox173.Height = 0.16F;
            this.textBox173.Left = 9.0625F;
            this.textBox173.MultiLine = false;
            this.textBox173.Name = "textBox173";
            this.textBox173.OutputFormat = resources.GetString("textBox173.OutputFormat");
            this.textBox173.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox173.SummaryGroup = "SectionHeader";
            this.textBox173.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox173.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox173.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox173.Top = 1.3125F;
            this.textBox173.Width = 0.938F;
            // 
            // textBox174
            // 
            this.textBox174.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox174.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox174.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox174.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox174.Border.RightColor = System.Drawing.Color.Black;
            this.textBox174.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox174.Border.TopColor = System.Drawing.Color.Black;
            this.textBox174.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox174.Height = 0.156F;
            this.textBox174.Left = 8.51F;
            this.textBox174.MultiLine = false;
            this.textBox174.Name = "textBox174";
            this.textBox174.OutputFormat = resources.GetString("textBox174.OutputFormat");
            this.textBox174.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox174.Text = "枚";
            this.textBox174.Top = 1.313F;
            this.textBox174.Width = 0.15F;
            // 
            // textBox175
            // 
            this.textBox175.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox175.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox175.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox175.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox175.Border.RightColor = System.Drawing.Color.Black;
            this.textBox175.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox175.Border.TopColor = System.Drawing.Color.Black;
            this.textBox175.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox175.DataField = "TaxRate2DisSlipCntRF";
            this.textBox175.Height = 0.16F;
            this.textBox175.Left = 7.9375F;
            this.textBox175.MultiLine = false;
            this.textBox175.Name = "textBox175";
            this.textBox175.OutputFormat = resources.GetString("textBox175.OutputFormat");
            this.textBox175.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox175.SummaryGroup = "SectionHeader";
            this.textBox175.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox175.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox175.Text = "123,456";
            this.textBox175.Top = 1.3125F;
            this.textBox175.Width = 0.5125F;
            // 
            // textBox176
            // 
            this.textBox176.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox176.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox176.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox176.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox176.Border.RightColor = System.Drawing.Color.Black;
            this.textBox176.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox176.Border.TopColor = System.Drawing.Color.Black;
            this.textBox176.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox176.DataField = "OtherRetGdsStockTtlPricTaxExcRF";
            this.textBox176.Height = 0.16F;
            this.textBox176.Left = 9.0625F;
            this.textBox176.MultiLine = false;
            this.textBox176.Name = "textBox176";
            this.textBox176.OutputFormat = resources.GetString("textBox176.OutputFormat");
            this.textBox176.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox176.SummaryGroup = "SectionHeader";
            this.textBox176.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox176.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox176.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox176.Top = 1.5F;
            this.textBox176.Width = 0.938F;
            // 
            // textBox177
            // 
            this.textBox177.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox177.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox177.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox177.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox177.Border.RightColor = System.Drawing.Color.Black;
            this.textBox177.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox177.Border.TopColor = System.Drawing.Color.Black;
            this.textBox177.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox177.Height = 0.156F;
            this.textBox177.Left = 8.51F;
            this.textBox177.MultiLine = false;
            this.textBox177.Name = "textBox177";
            this.textBox177.OutputFormat = resources.GetString("textBox177.OutputFormat");
            this.textBox177.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox177.Text = "枚";
            this.textBox177.Top = 1.5F;
            this.textBox177.Width = 0.15F;
            // 
            // textBox178
            // 
            this.textBox178.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox178.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox178.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Border.RightColor = System.Drawing.Color.Black;
            this.textBox178.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Border.TopColor = System.Drawing.Color.Black;
            this.textBox178.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.DataField = "OtherDisSlipCntRF";
            this.textBox178.Height = 0.16F;
            this.textBox178.Left = 7.9375F;
            this.textBox178.MultiLine = false;
            this.textBox178.Name = "textBox178";
            this.textBox178.OutputFormat = resources.GetString("textBox178.OutputFormat");
            this.textBox178.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox178.SummaryGroup = "SectionHeader";
            this.textBox178.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox178.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox178.Text = "123,456";
            this.textBox178.Top = 1.5F;
            this.textBox178.Width = 0.5125F;
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
            this.label46.DataField = "TaxRate1RetTitle";
            this.label46.Height = 0.16F;
            this.label46.HyperLink = null;
            this.label46.Left = 8.7F;
            this.label46.Name = "label46";
            this.label46.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label46.Text = "税率１";
            this.label46.Top = 1.125F;
            this.label46.Width = 0.5F;
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
            this.label47.DataField = "TaxRate2RetTitle";
            this.label47.Height = 0.16F;
            this.label47.HyperLink = null;
            this.label47.Left = 8.7F;
            this.label47.Name = "label47";
            this.label47.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label47.Text = "税率２";
            this.label47.Top = 1.313F;
            this.label47.Width = 0.5F;
            // 
            // SectionTitle_2
            // 
            this.SectionTitle_2.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTitle_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle_2.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTitle_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle_2.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTitle_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle_2.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTitle_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle_2.Height = 0.18F;
            this.SectionTitle_2.Left = 6.89F;
            this.SectionTitle_2.MultiLine = false;
            this.SectionTitle_2.Name = "SectionTitle_2";
            this.SectionTitle_2.OutputFormat = resources.GetString("SectionTitle_2.OutputFormat");
            this.SectionTitle_2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle_2.Text = "拠点計";
            this.SectionTitle_2.Top = 0F;
            this.SectionTitle_2.Width = 0.65F;
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
            // groupHeader1_2
            // 
            this.groupHeader1_2.CanShrink = true;
            this.groupHeader1_2.Height = 0F;
            this.groupHeader1_2.Name = "groupHeader1_2";
            this.groupHeader1_2.Visible = false;
            // 
            // groupFooter1_2
            // 
            this.groupFooter1_2.CanShrink = true;
            this.groupFooter1_2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox113,
            this.groupFooter1Title_2,
            this.textBox115,
            this.textBox116,
            this.textBox117,
            this.textBox118,
            this.textBox119,
            this.textBox120,
            this.textBox121,
            this.textBox122,
            this.textBox123,
            this.textBox124,
            this.textBox125,
            this.textBox126,
            this.textBox127,
            this.textBox128,
            this.textBox129,
            this.textBox130,
            this.textBox131,
            this.textBox132,
            this.textBox133,
            this.textBox134,
            this.textBox135,
            this.textBox136,
            this.label37,
            this.label38,
            this.label39,
            this.textBox137,
            this.textBox138,
            this.textBox139,
            this.textBox140,
            this.textBox141,
            this.textBox142,
            this.textBox143,
            this.textBox144,
            this.textBox145,
            this.label40,
            this.label41,
            this.label42,
            this.line10,
            this.textBox212,
            this.textBox213,
            this.label57,
            this.textBox214,
            this.textBox215,
            this.label58,
            this.textBox216,
            this.textBox217});
            this.groupFooter1_2.Height = 2.25F;
            this.groupFooter1_2.KeepTogether = true;
            this.groupFooter1_2.Name = "groupFooter1_2";
            this.groupFooter1_2.Visible = false;
            // 
            // textBox113
            // 
            this.textBox113.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox113.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox113.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.Border.RightColor = System.Drawing.Color.Black;
            this.textBox113.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.Border.TopColor = System.Drawing.Color.Black;
            this.textBox113.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox113.DataField = "StockPriceTaxExcRF";
            this.textBox113.Height = 0.16F;
            this.textBox113.Left = 9.0625F;
            this.textBox113.MultiLine = false;
            this.textBox113.Name = "textBox113";
            this.textBox113.OutputFormat = resources.GetString("textBox113.OutputFormat");
            this.textBox113.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox113.SummaryGroup = "groupHeader1";
            this.textBox113.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox113.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox113.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox113.Top = 2.0625F;
            this.textBox113.Width = 0.938F;
            // 
            // groupFooter1Title_2
            // 
            this.groupFooter1Title_2.Border.BottomColor = System.Drawing.Color.Black;
            this.groupFooter1Title_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title_2.Border.LeftColor = System.Drawing.Color.Black;
            this.groupFooter1Title_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title_2.Border.RightColor = System.Drawing.Color.Black;
            this.groupFooter1Title_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title_2.Border.TopColor = System.Drawing.Color.Black;
            this.groupFooter1Title_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter1Title_2.Height = 0.18F;
            this.groupFooter1Title_2.Left = 6.89F;
            this.groupFooter1Title_2.MultiLine = false;
            this.groupFooter1Title_2.Name = "groupFooter1Title_2";
            this.groupFooter1Title_2.OutputFormat = resources.GetString("groupFooter1Title_2.OutputFormat");
            this.groupFooter1Title_2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.groupFooter1Title_2.Text = "仕入先計";
            this.groupFooter1Title_2.Top = 0F;
            this.groupFooter1Title_2.Width = 0.65F;
            // 
            // textBox115
            // 
            this.textBox115.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox115.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox115.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Border.RightColor = System.Drawing.Color.Black;
            this.textBox115.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Border.TopColor = System.Drawing.Color.Black;
            this.textBox115.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox115.Height = 0.156F;
            this.textBox115.Left = 7.625F;
            this.textBox115.MultiLine = false;
            this.textBox115.Name = "textBox115";
            this.textBox115.OutputFormat = resources.GetString("textBox115.OutputFormat");
            this.textBox115.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox115.Text = "返品";
            this.textBox115.Top = 0.9375F;
            this.textBox115.Width = 0.3F;
            // 
            // textBox116
            // 
            this.textBox116.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.RightColor = System.Drawing.Color.Black;
            this.textBox116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.TopColor = System.Drawing.Color.Black;
            this.textBox116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Height = 0.156F;
            this.textBox116.Left = 7.638F;
            this.textBox116.MultiLine = false;
            this.textBox116.Name = "textBox116";
            this.textBox116.OutputFormat = resources.GetString("textBox116.OutputFormat");
            this.textBox116.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox116.Text = "仕入";
            this.textBox116.Top = 0F;
            this.textBox116.Width = 0.3F;
            // 
            // textBox117
            // 
            this.textBox117.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox117.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox117.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Border.RightColor = System.Drawing.Color.Black;
            this.textBox117.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Border.TopColor = System.Drawing.Color.Black;
            this.textBox117.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox117.Height = 0.156F;
            this.textBox117.Left = 7.625F;
            this.textBox117.MultiLine = false;
            this.textBox117.Name = "textBox117";
            this.textBox117.OutputFormat = resources.GetString("textBox117.OutputFormat");
            this.textBox117.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox117.Text = "合計";
            this.textBox117.Top = 2.0625F;
            this.textBox117.Width = 0.3F;
            // 
            // textBox118
            // 
            this.textBox118.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox118.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox118.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.Border.RightColor = System.Drawing.Color.Black;
            this.textBox118.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.Border.TopColor = System.Drawing.Color.Black;
            this.textBox118.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox118.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox118.Height = 0.16F;
            this.textBox118.Left = 9.0625F;
            this.textBox118.MultiLine = false;
            this.textBox118.Name = "textBox118";
            this.textBox118.OutputFormat = resources.GetString("textBox118.OutputFormat");
            this.textBox118.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox118.SummaryGroup = "groupHeader1";
            this.textBox118.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox118.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox118.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox118.Top = 0.9375F;
            this.textBox118.Width = 0.938F;
            // 
            // textBox119
            // 
            this.textBox119.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.RightColor = System.Drawing.Color.Black;
            this.textBox119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.TopColor = System.Drawing.Color.Black;
            this.textBox119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.DataField = "SalStockPricTaxExcRF";
            this.textBox119.Height = 0.16F;
            this.textBox119.Left = 9.06F;
            this.textBox119.MultiLine = false;
            this.textBox119.Name = "textBox119";
            this.textBox119.OutputFormat = resources.GetString("textBox119.OutputFormat");
            this.textBox119.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox119.SummaryGroup = "groupHeader1";
            this.textBox119.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox119.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox119.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox119.Top = 0F;
            this.textBox119.Width = 0.938F;
            // 
            // textBox120
            // 
            this.textBox120.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.RightColor = System.Drawing.Color.Black;
            this.textBox120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.TopColor = System.Drawing.Color.Black;
            this.textBox120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.DataField = "SalCntRF";
            this.textBox120.Height = 0.16F;
            this.textBox120.Left = 7.938F;
            this.textBox120.MultiLine = false;
            this.textBox120.Name = "textBox120";
            this.textBox120.OutputFormat = resources.GetString("textBox120.OutputFormat");
            this.textBox120.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox120.SummaryGroup = "groupHeader1";
            this.textBox120.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox120.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox120.Text = "123,456";
            this.textBox120.Top = 0F;
            this.textBox120.Width = 0.5125F;
            // 
            // textBox121
            // 
            this.textBox121.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Border.RightColor = System.Drawing.Color.Black;
            this.textBox121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Border.TopColor = System.Drawing.Color.Black;
            this.textBox121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox121.Height = 0.156F;
            this.textBox121.Left = 8.51F;
            this.textBox121.MultiLine = false;
            this.textBox121.Name = "textBox121";
            this.textBox121.OutputFormat = resources.GetString("textBox121.OutputFormat");
            this.textBox121.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox121.Text = "枚";
            this.textBox121.Top = 0F;
            this.textBox121.Width = 0.15F;
            // 
            // textBox122
            // 
            this.textBox122.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.RightColor = System.Drawing.Color.Black;
            this.textBox122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.TopColor = System.Drawing.Color.Black;
            this.textBox122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.DataField = "DisCntRF";
            this.textBox122.Height = 0.156F;
            this.textBox122.Left = 7.9375F;
            this.textBox122.MultiLine = false;
            this.textBox122.Name = "textBox122";
            this.textBox122.OutputFormat = resources.GetString("textBox122.OutputFormat");
            this.textBox122.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox122.SummaryGroup = "groupHeader1";
            this.textBox122.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox122.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox122.Text = "123,456";
            this.textBox122.Top = 0.9375F;
            this.textBox122.Width = 0.51F;
            // 
            // textBox123
            // 
            this.textBox123.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox123.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox123.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Border.RightColor = System.Drawing.Color.Black;
            this.textBox123.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Border.TopColor = System.Drawing.Color.Black;
            this.textBox123.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox123.Height = 0.156F;
            this.textBox123.Left = 8.51F;
            this.textBox123.MultiLine = false;
            this.textBox123.Name = "textBox123";
            this.textBox123.OutputFormat = resources.GetString("textBox123.OutputFormat");
            this.textBox123.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox123.Text = "枚";
            this.textBox123.Top = 0.938F;
            this.textBox123.Width = 0.15F;
            // 
            // textBox124
            // 
            this.textBox124.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox124.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox124.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.Border.RightColor = System.Drawing.Color.Black;
            this.textBox124.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.Border.TopColor = System.Drawing.Color.Black;
            this.textBox124.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox124.DataField = "TotleCntRF";
            this.textBox124.Height = 0.156F;
            this.textBox124.Left = 7.9375F;
            this.textBox124.MultiLine = false;
            this.textBox124.Name = "textBox124";
            this.textBox124.OutputFormat = resources.GetString("textBox124.OutputFormat");
            this.textBox124.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox124.SummaryGroup = "groupHeader1";
            this.textBox124.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox124.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox124.Text = "123,456";
            this.textBox124.Top = 2.0625F;
            this.textBox124.Width = 0.51F;
            // 
            // textBox125
            // 
            this.textBox125.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox125.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox125.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Border.RightColor = System.Drawing.Color.Black;
            this.textBox125.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Border.TopColor = System.Drawing.Color.Black;
            this.textBox125.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox125.Height = 0.156F;
            this.textBox125.Left = 8.51F;
            this.textBox125.MultiLine = false;
            this.textBox125.Name = "textBox125";
            this.textBox125.OutputFormat = resources.GetString("textBox125.OutputFormat");
            this.textBox125.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox125.Text = "枚";
            this.textBox125.Top = 2.063F;
            this.textBox125.Width = 0.15F;
            // 
            // textBox126
            // 
            this.textBox126.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox126.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox126.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Border.RightColor = System.Drawing.Color.Black;
            this.textBox126.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Border.TopColor = System.Drawing.Color.Black;
            this.textBox126.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox126.Height = 0.156F;
            this.textBox126.Left = 7.625F;
            this.textBox126.MultiLine = false;
            this.textBox126.Name = "textBox126";
            this.textBox126.OutputFormat = resources.GetString("textBox126.OutputFormat");
            this.textBox126.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox126.Text = "値引";
            this.textBox126.Top = 1.875F;
            this.textBox126.Width = 0.3F;
            // 
            // textBox127
            // 
            this.textBox127.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox127.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox127.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.Border.RightColor = System.Drawing.Color.Black;
            this.textBox127.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.Border.TopColor = System.Drawing.Color.Black;
            this.textBox127.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox127.DataField = "DisStockPricTaxExcRF";
            this.textBox127.Height = 0.16F;
            this.textBox127.Left = 9.0625F;
            this.textBox127.MultiLine = false;
            this.textBox127.Name = "textBox127";
            this.textBox127.OutputFormat = resources.GetString("textBox127.OutputFormat");
            this.textBox127.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox127.SummaryGroup = "groupHeader1";
            this.textBox127.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox127.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox127.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox127.Top = 1.875F;
            this.textBox127.Width = 0.938F;
            // 
            // textBox128
            // 
            this.textBox128.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox128.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox128.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.Border.RightColor = System.Drawing.Color.Black;
            this.textBox128.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.Border.TopColor = System.Drawing.Color.Black;
            this.textBox128.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox128.DataField = "TaxRate1StockTtlPricTaxExcRF";
            this.textBox128.Height = 0.16F;
            this.textBox128.Left = 9.06F;
            this.textBox128.MultiLine = false;
            this.textBox128.Name = "textBox128";
            this.textBox128.OutputFormat = resources.GetString("textBox128.OutputFormat");
            this.textBox128.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox128.SummaryGroup = "groupHeader1";
            this.textBox128.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox128.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox128.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox128.Top = 0.1875F;
            this.textBox128.Width = 0.938F;
            // 
            // textBox129
            // 
            this.textBox129.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox129.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox129.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Border.RightColor = System.Drawing.Color.Black;
            this.textBox129.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Border.TopColor = System.Drawing.Color.Black;
            this.textBox129.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox129.Height = 0.156F;
            this.textBox129.Left = 8.51F;
            this.textBox129.MultiLine = false;
            this.textBox129.Name = "textBox129";
            this.textBox129.OutputFormat = resources.GetString("textBox129.OutputFormat");
            this.textBox129.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox129.Text = "枚";
            this.textBox129.Top = 0.1875F;
            this.textBox129.Width = 0.15F;
            // 
            // textBox130
            // 
            this.textBox130.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.Border.RightColor = System.Drawing.Color.Black;
            this.textBox130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.Border.TopColor = System.Drawing.Color.Black;
            this.textBox130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox130.DataField = "TaxRate1SalSlipCntRF";
            this.textBox130.Height = 0.16F;
            this.textBox130.Left = 7.938F;
            this.textBox130.MultiLine = false;
            this.textBox130.Name = "textBox130";
            this.textBox130.OutputFormat = resources.GetString("textBox130.OutputFormat");
            this.textBox130.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox130.SummaryGroup = "groupHeader1";
            this.textBox130.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox130.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox130.Text = "123,456";
            this.textBox130.Top = 0.1875F;
            this.textBox130.Width = 0.5125F;
            // 
            // textBox131
            // 
            this.textBox131.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.RightColor = System.Drawing.Color.Black;
            this.textBox131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.TopColor = System.Drawing.Color.Black;
            this.textBox131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.DataField = "TaxRate2StockTtlPricTaxExcRF";
            this.textBox131.Height = 0.16F;
            this.textBox131.Left = 9.06F;
            this.textBox131.MultiLine = false;
            this.textBox131.Name = "textBox131";
            this.textBox131.OutputFormat = resources.GetString("textBox131.OutputFormat");
            this.textBox131.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox131.SummaryGroup = "groupHeader1";
            this.textBox131.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox131.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox131.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox131.Top = 0.375F;
            this.textBox131.Width = 0.938F;
            // 
            // textBox132
            // 
            this.textBox132.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Border.RightColor = System.Drawing.Color.Black;
            this.textBox132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Border.TopColor = System.Drawing.Color.Black;
            this.textBox132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox132.Height = 0.156F;
            this.textBox132.Left = 8.51F;
            this.textBox132.MultiLine = false;
            this.textBox132.Name = "textBox132";
            this.textBox132.OutputFormat = resources.GetString("textBox132.OutputFormat");
            this.textBox132.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox132.Text = "枚";
            this.textBox132.Top = 0.375F;
            this.textBox132.Width = 0.15F;
            // 
            // textBox133
            // 
            this.textBox133.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox133.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox133.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.Border.RightColor = System.Drawing.Color.Black;
            this.textBox133.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.Border.TopColor = System.Drawing.Color.Black;
            this.textBox133.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox133.DataField = "TaxRate2SalSlipCntRF";
            this.textBox133.Height = 0.16F;
            this.textBox133.Left = 7.938F;
            this.textBox133.MultiLine = false;
            this.textBox133.Name = "textBox133";
            this.textBox133.OutputFormat = resources.GetString("textBox133.OutputFormat");
            this.textBox133.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox133.SummaryGroup = "groupHeader1";
            this.textBox133.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox133.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox133.Text = "123,456";
            this.textBox133.Top = 0.375F;
            this.textBox133.Width = 0.5125F;
            // 
            // textBox134
            // 
            this.textBox134.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.RightColor = System.Drawing.Color.Black;
            this.textBox134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.TopColor = System.Drawing.Color.Black;
            this.textBox134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.DataField = "OtherStockTtlPricTaxExcRF";
            this.textBox134.Height = 0.16F;
            this.textBox134.Left = 9.06F;
            this.textBox134.MultiLine = false;
            this.textBox134.Name = "textBox134";
            this.textBox134.OutputFormat = resources.GetString("textBox134.OutputFormat");
            this.textBox134.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox134.SummaryGroup = "groupHeader1";
            this.textBox134.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox134.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox134.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox134.Top = 0.5625F;
            this.textBox134.Width = 0.938F;
            // 
            // textBox135
            // 
            this.textBox135.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox135.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox135.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Border.RightColor = System.Drawing.Color.Black;
            this.textBox135.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Border.TopColor = System.Drawing.Color.Black;
            this.textBox135.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox135.Height = 0.156F;
            this.textBox135.Left = 8.51F;
            this.textBox135.MultiLine = false;
            this.textBox135.Name = "textBox135";
            this.textBox135.OutputFormat = resources.GetString("textBox135.OutputFormat");
            this.textBox135.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox135.Text = "枚";
            this.textBox135.Top = 0.5625F;
            this.textBox135.Width = 0.15F;
            // 
            // textBox136
            // 
            this.textBox136.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.Border.RightColor = System.Drawing.Color.Black;
            this.textBox136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.Border.TopColor = System.Drawing.Color.Black;
            this.textBox136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox136.DataField = "OtherSalSlipCntRF";
            this.textBox136.Height = 0.16F;
            this.textBox136.Left = 7.938F;
            this.textBox136.MultiLine = false;
            this.textBox136.Name = "textBox136";
            this.textBox136.OutputFormat = resources.GetString("textBox136.OutputFormat");
            this.textBox136.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox136.SummaryGroup = "groupHeader1";
            this.textBox136.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox136.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox136.Text = "123,456";
            this.textBox136.Top = 0.5625F;
            this.textBox136.Width = 0.5125F;
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
            this.label37.DataField = "TaxRate1Title";
            this.label37.Height = 0.16F;
            this.label37.HyperLink = null;
            this.label37.Left = 8.7F;
            this.label37.Name = "label37";
            this.label37.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label37.Text = "税率１";
            this.label37.Top = 0.1875F;
            this.label37.Width = 0.5F;
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
            this.label38.DataField = "TaxRate2Title";
            this.label38.Height = 0.16F;
            this.label38.HyperLink = null;
            this.label38.Left = 8.7F;
            this.label38.Name = "label38";
            this.label38.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label38.Text = "税率２";
            this.label38.Top = 0.375F;
            this.label38.Width = 0.5F;
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
            this.label39.DataField = "OtherTitle";
            this.label39.Height = 0.16F;
            this.label39.HyperLink = null;
            this.label39.Left = 8.7F;
            this.label39.Name = "label39";
            this.label39.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label39.Text = "その他";
            this.label39.Top = 0.5625F;
            this.label39.Width = 0.5F;
            // 
            // textBox137
            // 
            this.textBox137.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.RightColor = System.Drawing.Color.Black;
            this.textBox137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.TopColor = System.Drawing.Color.Black;
            this.textBox137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.DataField = "TaxRate1RetGdsStockTtlPricTaxExcRF";
            this.textBox137.Height = 0.16F;
            this.textBox137.Left = 9.0625F;
            this.textBox137.MultiLine = false;
            this.textBox137.Name = "textBox137";
            this.textBox137.OutputFormat = resources.GetString("textBox137.OutputFormat");
            this.textBox137.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox137.SummaryGroup = "groupHeader1";
            this.textBox137.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox137.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox137.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox137.Top = 1.125F;
            this.textBox137.Width = 0.938F;
            // 
            // textBox138
            // 
            this.textBox138.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Border.RightColor = System.Drawing.Color.Black;
            this.textBox138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Border.TopColor = System.Drawing.Color.Black;
            this.textBox138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox138.Height = 0.156F;
            this.textBox138.Left = 8.51F;
            this.textBox138.MultiLine = false;
            this.textBox138.Name = "textBox138";
            this.textBox138.OutputFormat = resources.GetString("textBox138.OutputFormat");
            this.textBox138.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox138.Text = "枚";
            this.textBox138.Top = 1.125F;
            this.textBox138.Width = 0.15F;
            // 
            // textBox139
            // 
            this.textBox139.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox139.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox139.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.Border.RightColor = System.Drawing.Color.Black;
            this.textBox139.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.Border.TopColor = System.Drawing.Color.Black;
            this.textBox139.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox139.DataField = "TaxRate1DisSlipCntRF";
            this.textBox139.Height = 0.16F;
            this.textBox139.Left = 7.9375F;
            this.textBox139.MultiLine = false;
            this.textBox139.Name = "textBox139";
            this.textBox139.OutputFormat = resources.GetString("textBox139.OutputFormat");
            this.textBox139.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox139.SummaryGroup = "groupHeader1";
            this.textBox139.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox139.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox139.Text = "123,456";
            this.textBox139.Top = 1.125F;
            this.textBox139.Width = 0.5125F;
            // 
            // textBox140
            // 
            this.textBox140.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.Border.RightColor = System.Drawing.Color.Black;
            this.textBox140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.Border.TopColor = System.Drawing.Color.Black;
            this.textBox140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox140.DataField = "TaxRate2RetGdsStockTtlPricTaxExcRF";
            this.textBox140.Height = 0.16F;
            this.textBox140.Left = 9.0625F;
            this.textBox140.MultiLine = false;
            this.textBox140.Name = "textBox140";
            this.textBox140.OutputFormat = resources.GetString("textBox140.OutputFormat");
            this.textBox140.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox140.SummaryGroup = "groupHeader1";
            this.textBox140.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox140.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox140.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox140.Top = 1.3125F;
            this.textBox140.Width = 0.938F;
            // 
            // textBox141
            // 
            this.textBox141.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Border.RightColor = System.Drawing.Color.Black;
            this.textBox141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Border.TopColor = System.Drawing.Color.Black;
            this.textBox141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox141.Height = 0.156F;
            this.textBox141.Left = 8.51F;
            this.textBox141.MultiLine = false;
            this.textBox141.Name = "textBox141";
            this.textBox141.OutputFormat = resources.GetString("textBox141.OutputFormat");
            this.textBox141.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox141.Text = "枚";
            this.textBox141.Top = 1.313F;
            this.textBox141.Width = 0.15F;
            // 
            // textBox142
            // 
            this.textBox142.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.Border.RightColor = System.Drawing.Color.Black;
            this.textBox142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.Border.TopColor = System.Drawing.Color.Black;
            this.textBox142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox142.DataField = "TaxRate2DisSlipCntRF";
            this.textBox142.Height = 0.16F;
            this.textBox142.Left = 7.9375F;
            this.textBox142.MultiLine = false;
            this.textBox142.Name = "textBox142";
            this.textBox142.OutputFormat = resources.GetString("textBox142.OutputFormat");
            this.textBox142.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox142.SummaryGroup = "groupHeader1";
            this.textBox142.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox142.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox142.Text = "123,456";
            this.textBox142.Top = 1.3125F;
            this.textBox142.Width = 0.5125F;
            // 
            // textBox143
            // 
            this.textBox143.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.Border.RightColor = System.Drawing.Color.Black;
            this.textBox143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.Border.TopColor = System.Drawing.Color.Black;
            this.textBox143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox143.DataField = "OtherRetGdsStockTtlPricTaxExcRF";
            this.textBox143.Height = 0.16F;
            this.textBox143.Left = 9.0625F;
            this.textBox143.MultiLine = false;
            this.textBox143.Name = "textBox143";
            this.textBox143.OutputFormat = resources.GetString("textBox143.OutputFormat");
            this.textBox143.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox143.SummaryGroup = "groupHeader1";
            this.textBox143.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox143.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox143.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox143.Top = 1.5F;
            this.textBox143.Width = 0.938F;
            // 
            // textBox144
            // 
            this.textBox144.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Border.RightColor = System.Drawing.Color.Black;
            this.textBox144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Border.TopColor = System.Drawing.Color.Black;
            this.textBox144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox144.Height = 0.156F;
            this.textBox144.Left = 8.51F;
            this.textBox144.MultiLine = false;
            this.textBox144.Name = "textBox144";
            this.textBox144.OutputFormat = resources.GetString("textBox144.OutputFormat");
            this.textBox144.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox144.Text = "枚";
            this.textBox144.Top = 1.5F;
            this.textBox144.Width = 0.15F;
            // 
            // textBox145
            // 
            this.textBox145.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.Border.RightColor = System.Drawing.Color.Black;
            this.textBox145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.Border.TopColor = System.Drawing.Color.Black;
            this.textBox145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox145.DataField = "OtherDisSlipCntRF";
            this.textBox145.Height = 0.16F;
            this.textBox145.Left = 7.9375F;
            this.textBox145.MultiLine = false;
            this.textBox145.Name = "textBox145";
            this.textBox145.OutputFormat = resources.GetString("textBox145.OutputFormat");
            this.textBox145.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox145.SummaryGroup = "groupHeader1";
            this.textBox145.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox145.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox145.Text = "123,456";
            this.textBox145.Top = 1.5F;
            this.textBox145.Width = 0.5125F;
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
            this.label40.DataField = "TaxRate1RetTitle";
            this.label40.Height = 0.16F;
            this.label40.HyperLink = null;
            this.label40.Left = 8.7F;
            this.label40.Name = "label40";
            this.label40.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label40.Text = "税率１";
            this.label40.Top = 1.125F;
            this.label40.Width = 0.5F;
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
            this.label41.DataField = "TaxRate2RetTitle";
            this.label41.Height = 0.16F;
            this.label41.HyperLink = null;
            this.label41.Left = 8.7F;
            this.label41.Name = "label41";
            this.label41.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label41.Text = "税率２";
            this.label41.Top = 1.313F;
            this.label41.Width = 0.5F;
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
            this.label42.DataField = "OtherRetTitle";
            this.label42.Height = 0.16F;
            this.label42.HyperLink = null;
            this.label42.Left = 8.7F;
            this.label42.Name = "label42";
            this.label42.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label42.Text = "その他";
            this.label42.Top = 1.5F;
            this.label42.Width = 0.5F;
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
            this.line10.Width = 10.8F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.8F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
            // 
            // groupHeader2_2
            // 
            this.groupHeader2_2.CanShrink = true;
            this.groupHeader2_2.Height = 0F;
            this.groupHeader2_2.Name = "groupHeader2_2";
            this.groupHeader2_2.Visible = false;
            // 
            // groupFooter2_2
            // 
            this.groupFooter2_2.CanShrink = true;
            this.groupFooter2_2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label33,
            this.textBox13,
            this.groupFooter2Title_2,
            this.textBox41,
            this.textBox43,
            this.textBox45,
            this.textBox47,
            this.textBox49,
            this.textBox78,
            this.textBox80,
            this.textBox83,
            this.textBox88,
            this.textBox89,
            this.textBox92,
            this.textBox93,
            this.textBox94,
            this.textBox95,
            this.textBox96,
            this.textBox97,
            this.textBox98,
            this.textBox99,
            this.textBox100,
            this.textBox101,
            this.textBox102,
            this.textBox103,
            this.label31,
            this.label32,
            this.textBox104,
            this.textBox105,
            this.textBox106,
            this.textBox107,
            this.textBox108,
            this.textBox109,
            this.textBox110,
            this.textBox111,
            this.textBox112,
            this.label34,
            this.label35,
            this.label36,
            this.line9,
            this.textBox4,
            this.textBox7,
            this.label55,
            this.textBox39,
            this.textBox114,
            this.textBox179,
            this.label56,
            this.textBox211});
            this.groupFooter2_2.Height = 2.25F;
            this.groupFooter2_2.KeepTogether = true;
            this.groupFooter2_2.Name = "groupFooter2_2";
            this.groupFooter2_2.Visible = false;
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
            this.label33.DataField = "OtherTitle";
            this.label33.Height = 0.16F;
            this.label33.HyperLink = null;
            this.label33.Left = 8.7F;
            this.label33.Name = "label33";
            this.label33.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label33.Text = "その他";
            this.label33.Top = 0.563F;
            this.label33.Width = 0.5F;
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
            this.textBox13.DataField = "SalStockPricTaxExcRF";
            this.textBox13.Height = 0.16F;
            this.textBox13.Left = 9.06F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.SummaryGroup = "groupHeader2";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.938F;
            // 
            // groupFooter2Title_2
            // 
            this.groupFooter2Title_2.Border.BottomColor = System.Drawing.Color.Black;
            this.groupFooter2Title_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title_2.Border.LeftColor = System.Drawing.Color.Black;
            this.groupFooter2Title_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title_2.Border.RightColor = System.Drawing.Color.Black;
            this.groupFooter2Title_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title_2.Border.TopColor = System.Drawing.Color.Black;
            this.groupFooter2Title_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.groupFooter2Title_2.Height = 0.18F;
            this.groupFooter2Title_2.Left = 6.888F;
            this.groupFooter2Title_2.MultiLine = false;
            this.groupFooter2Title_2.Name = "groupFooter2Title_2";
            this.groupFooter2Title_2.OutputFormat = resources.GetString("groupFooter2Title_2.OutputFormat");
            this.groupFooter2Title_2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.groupFooter2Title_2.Text = "仕入日計";
            this.groupFooter2Title_2.Top = 0F;
            this.groupFooter2Title_2.Width = 0.65F;
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
            this.textBox41.Height = 0.156F;
            this.textBox41.Left = 7.625F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox41.Text = "返品";
            this.textBox41.Top = 0.9375F;
            this.textBox41.Width = 0.3F;
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
            this.textBox43.Height = 0.156F;
            this.textBox43.Left = 7.638F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox43.Text = "仕入";
            this.textBox43.Top = 0F;
            this.textBox43.Width = 0.3F;
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
            this.textBox45.Height = 0.156F;
            this.textBox45.Left = 7.625F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox45.Text = "合計";
            this.textBox45.Top = 2.0625F;
            this.textBox45.Width = 0.3F;
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
            this.textBox47.Height = 0.156F;
            this.textBox47.Left = 8.51F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox47.Text = "枚";
            this.textBox47.Top = 0F;
            this.textBox47.Width = 0.15F;
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
            this.textBox49.Height = 0.156F;
            this.textBox49.Left = 8.513F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox49.Text = "枚";
            this.textBox49.Top = 0.938F;
            this.textBox49.Width = 0.15F;
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
            this.textBox78.Height = 0.156F;
            this.textBox78.Left = 8.5F;
            this.textBox78.MultiLine = false;
            this.textBox78.Name = "textBox78";
            this.textBox78.OutputFormat = resources.GetString("textBox78.OutputFormat");
            this.textBox78.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox78.Text = "枚";
            this.textBox78.Top = 2.0625F;
            this.textBox78.Width = 0.15F;
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
            this.textBox80.DataField = "SalCntRF";
            this.textBox80.Height = 0.16F;
            this.textBox80.Left = 7.938F;
            this.textBox80.MultiLine = false;
            this.textBox80.Name = "textBox80";
            this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
            this.textBox80.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox80.SummaryGroup = "groupHeader2";
            this.textBox80.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox80.Text = "123,456";
            this.textBox80.Top = 0F;
            this.textBox80.Width = 0.5125F;
            // 
            // textBox83
            // 
            this.textBox83.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.RightColor = System.Drawing.Color.Black;
            this.textBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.TopColor = System.Drawing.Color.Black;
            this.textBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.DataField = "DisCntRF";
            this.textBox83.Height = 0.156F;
            this.textBox83.Left = 7.9375F;
            this.textBox83.MultiLine = false;
            this.textBox83.Name = "textBox83";
            this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
            this.textBox83.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox83.SummaryGroup = "groupHeader2";
            this.textBox83.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox83.Text = "123,456";
            this.textBox83.Top = 0.9375F;
            this.textBox83.Width = 0.51F;
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
            this.textBox88.DataField = "TotleCntRF";
            this.textBox88.Height = 0.156F;
            this.textBox88.Left = 7.9375F;
            this.textBox88.MultiLine = false;
            this.textBox88.Name = "textBox88";
            this.textBox88.OutputFormat = resources.GetString("textBox88.OutputFormat");
            this.textBox88.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox88.SummaryGroup = "groupHeader2";
            this.textBox88.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox88.Text = "123,456";
            this.textBox88.Top = 2.0625F;
            this.textBox88.Width = 0.51F;
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
            this.textBox89.DataField = "RetGdsStockPricTaxExcRF";
            this.textBox89.Height = 0.16F;
            this.textBox89.Left = 9.0625F;
            this.textBox89.MultiLine = false;
            this.textBox89.Name = "textBox89";
            this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
            this.textBox89.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox89.SummaryGroup = "groupHeader2";
            this.textBox89.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox89.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox89.Top = 0.9375F;
            this.textBox89.Width = 0.938F;
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
            this.textBox92.DataField = "StockPriceTaxExcRF";
            this.textBox92.Height = 0.16F;
            this.textBox92.Left = 9.0625F;
            this.textBox92.MultiLine = false;
            this.textBox92.Name = "textBox92";
            this.textBox92.OutputFormat = resources.GetString("textBox92.OutputFormat");
            this.textBox92.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox92.SummaryGroup = "groupHeader2";
            this.textBox92.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox92.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox92.Top = 2.0625F;
            this.textBox92.Width = 0.938F;
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
            this.textBox93.Height = 0.156F;
            this.textBox93.Left = 7.625F;
            this.textBox93.MultiLine = false;
            this.textBox93.Name = "textBox93";
            this.textBox93.OutputFormat = resources.GetString("textBox93.OutputFormat");
            this.textBox93.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox93.Text = "値引";
            this.textBox93.Top = 1.875F;
            this.textBox93.Width = 0.3F;
            // 
            // textBox94
            // 
            this.textBox94.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.Border.RightColor = System.Drawing.Color.Black;
            this.textBox94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.Border.TopColor = System.Drawing.Color.Black;
            this.textBox94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox94.DataField = "DisStockPricTaxExcRF";
            this.textBox94.Height = 0.16F;
            this.textBox94.Left = 9.0625F;
            this.textBox94.MultiLine = false;
            this.textBox94.Name = "textBox94";
            this.textBox94.OutputFormat = resources.GetString("textBox94.OutputFormat");
            this.textBox94.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox94.SummaryGroup = "groupHeader2";
            this.textBox94.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox94.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox94.Top = 1.875F;
            this.textBox94.Width = 0.938F;
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
            this.textBox95.DataField = "TaxRate1StockTtlPricTaxExcRF";
            this.textBox95.Height = 0.16F;
            this.textBox95.Left = 9.06F;
            this.textBox95.MultiLine = false;
            this.textBox95.Name = "textBox95";
            this.textBox95.OutputFormat = resources.GetString("textBox95.OutputFormat");
            this.textBox95.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox95.SummaryGroup = "groupHeader2";
            this.textBox95.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox95.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox95.Top = 0.1875F;
            this.textBox95.Width = 0.938F;
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
            this.textBox96.Height = 0.156F;
            this.textBox96.Left = 8.51F;
            this.textBox96.MultiLine = false;
            this.textBox96.Name = "textBox96";
            this.textBox96.OutputFormat = resources.GetString("textBox96.OutputFormat");
            this.textBox96.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox96.Text = "枚";
            this.textBox96.Top = 0.1875F;
            this.textBox96.Width = 0.15F;
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
            this.textBox97.DataField = "TaxRate1SalSlipCntRF";
            this.textBox97.Height = 0.16F;
            this.textBox97.Left = 7.938F;
            this.textBox97.MultiLine = false;
            this.textBox97.Name = "textBox97";
            this.textBox97.OutputFormat = resources.GetString("textBox97.OutputFormat");
            this.textBox97.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox97.SummaryGroup = "groupHeader2";
            this.textBox97.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox97.Text = "123,456";
            this.textBox97.Top = 0.1875F;
            this.textBox97.Width = 0.5125F;
            // 
            // textBox98
            // 
            this.textBox98.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.RightColor = System.Drawing.Color.Black;
            this.textBox98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.TopColor = System.Drawing.Color.Black;
            this.textBox98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.DataField = "TaxRate2StockTtlPricTaxExcRF";
            this.textBox98.Height = 0.16F;
            this.textBox98.Left = 9.06F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox98.SummaryGroup = "groupHeader2";
            this.textBox98.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox98.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox98.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox98.Top = 0.375F;
            this.textBox98.Width = 0.938F;
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
            this.textBox99.Height = 0.156F;
            this.textBox99.Left = 8.51F;
            this.textBox99.MultiLine = false;
            this.textBox99.Name = "textBox99";
            this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
            this.textBox99.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox99.Text = "枚";
            this.textBox99.Top = 0.375F;
            this.textBox99.Width = 0.15F;
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
            this.textBox100.DataField = "TaxRate2SalSlipCntRF";
            this.textBox100.Height = 0.16F;
            this.textBox100.Left = 7.938F;
            this.textBox100.MultiLine = false;
            this.textBox100.Name = "textBox100";
            this.textBox100.OutputFormat = resources.GetString("textBox100.OutputFormat");
            this.textBox100.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox100.SummaryGroup = "groupHeader2";
            this.textBox100.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox100.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox100.Text = "123,456";
            this.textBox100.Top = 0.375F;
            this.textBox100.Width = 0.5125F;
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
            this.textBox101.DataField = "OtherStockTtlPricTaxExcRF";
            this.textBox101.Height = 0.16F;
            this.textBox101.Left = 9.062F;
            this.textBox101.MultiLine = false;
            this.textBox101.Name = "textBox101";
            this.textBox101.OutputFormat = resources.GetString("textBox101.OutputFormat");
            this.textBox101.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox101.SummaryGroup = "groupHeader2";
            this.textBox101.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox101.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox101.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox101.Top = 0.563F;
            this.textBox101.Width = 0.938F;
            // 
            // textBox102
            // 
            this.textBox102.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Border.RightColor = System.Drawing.Color.Black;
            this.textBox102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Border.TopColor = System.Drawing.Color.Black;
            this.textBox102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox102.Height = 0.156F;
            this.textBox102.Left = 8.513F;
            this.textBox102.MultiLine = false;
            this.textBox102.Name = "textBox102";
            this.textBox102.OutputFormat = resources.GetString("textBox102.OutputFormat");
            this.textBox102.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox102.Text = "枚";
            this.textBox102.Top = 0.563F;
            this.textBox102.Width = 0.15F;
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
            this.textBox103.DataField = "OtherSalSlipCntRF";
            this.textBox103.Height = 0.16F;
            this.textBox103.Left = 7.937008F;
            this.textBox103.MultiLine = false;
            this.textBox103.Name = "textBox103";
            this.textBox103.OutputFormat = resources.GetString("textBox103.OutputFormat");
            this.textBox103.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox103.SummaryGroup = "groupHeader2";
            this.textBox103.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox103.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox103.Text = "123,456";
            this.textBox103.Top = 0.563F;
            this.textBox103.Width = 0.5125F;
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
            this.label31.DataField = "TaxRate1Title";
            this.label31.Height = 0.16F;
            this.label31.HyperLink = null;
            this.label31.Left = 8.7F;
            this.label31.Name = "label31";
            this.label31.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label31.Text = "税率１";
            this.label31.Top = 0.1875F;
            this.label31.Width = 0.5F;
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
            this.label32.DataField = "TaxRate2Title";
            this.label32.Height = 0.16F;
            this.label32.HyperLink = null;
            this.label32.Left = 8.7F;
            this.label32.Name = "label32";
            this.label32.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label32.Text = "税率２";
            this.label32.Top = 0.375F;
            this.label32.Width = 0.5F;
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
            this.textBox104.DataField = "TaxRate1RetGdsStockTtlPricTaxExcRF";
            this.textBox104.Height = 0.16F;
            this.textBox104.Left = 9.0625F;
            this.textBox104.MultiLine = false;
            this.textBox104.Name = "textBox104";
            this.textBox104.OutputFormat = resources.GetString("textBox104.OutputFormat");
            this.textBox104.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox104.SummaryGroup = "groupHeader2";
            this.textBox104.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox104.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox104.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox104.Top = 1.125F;
            this.textBox104.Width = 0.938F;
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
            this.textBox105.Height = 0.156F;
            this.textBox105.Left = 8.513F;
            this.textBox105.MultiLine = false;
            this.textBox105.Name = "textBox105";
            this.textBox105.OutputFormat = resources.GetString("textBox105.OutputFormat");
            this.textBox105.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox105.Text = "枚";
            this.textBox105.Top = 1.125F;
            this.textBox105.Width = 0.15F;
            // 
            // textBox106
            // 
            this.textBox106.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.RightColor = System.Drawing.Color.Black;
            this.textBox106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.TopColor = System.Drawing.Color.Black;
            this.textBox106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.DataField = "TaxRate1DisSlipCntRF";
            this.textBox106.Height = 0.16F;
            this.textBox106.Left = 7.9375F;
            this.textBox106.MultiLine = false;
            this.textBox106.Name = "textBox106";
            this.textBox106.OutputFormat = resources.GetString("textBox106.OutputFormat");
            this.textBox106.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox106.SummaryGroup = "groupHeader2";
            this.textBox106.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox106.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox106.Text = "123,456";
            this.textBox106.Top = 1.125F;
            this.textBox106.Width = 0.5125F;
            // 
            // textBox107
            // 
            this.textBox107.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.Border.RightColor = System.Drawing.Color.Black;
            this.textBox107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.Border.TopColor = System.Drawing.Color.Black;
            this.textBox107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox107.DataField = "TaxRate2RetGdsStockTtlPricTaxExcRF";
            this.textBox107.Height = 0.16F;
            this.textBox107.Left = 9.0625F;
            this.textBox107.MultiLine = false;
            this.textBox107.Name = "textBox107";
            this.textBox107.OutputFormat = resources.GetString("textBox107.OutputFormat");
            this.textBox107.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox107.SummaryGroup = "groupHeader2";
            this.textBox107.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox107.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox107.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox107.Top = 1.3125F;
            this.textBox107.Width = 0.938F;
            // 
            // textBox108
            // 
            this.textBox108.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Border.RightColor = System.Drawing.Color.Black;
            this.textBox108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Border.TopColor = System.Drawing.Color.Black;
            this.textBox108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox108.Height = 0.156F;
            this.textBox108.Left = 8.513F;
            this.textBox108.MultiLine = false;
            this.textBox108.Name = "textBox108";
            this.textBox108.OutputFormat = resources.GetString("textBox108.OutputFormat");
            this.textBox108.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox108.Text = "枚";
            this.textBox108.Top = 1.313F;
            this.textBox108.Width = 0.15F;
            // 
            // textBox109
            // 
            this.textBox109.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.Border.RightColor = System.Drawing.Color.Black;
            this.textBox109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.Border.TopColor = System.Drawing.Color.Black;
            this.textBox109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox109.DataField = "TaxRate2DisSlipCntRF";
            this.textBox109.Height = 0.16F;
            this.textBox109.Left = 7.9375F;
            this.textBox109.MultiLine = false;
            this.textBox109.Name = "textBox109";
            this.textBox109.OutputFormat = resources.GetString("textBox109.OutputFormat");
            this.textBox109.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox109.SummaryGroup = "groupHeader2";
            this.textBox109.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox109.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox109.Text = "123,456";
            this.textBox109.Top = 1.3125F;
            this.textBox109.Width = 0.5125F;
            // 
            // textBox110
            // 
            this.textBox110.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox110.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox110.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.Border.RightColor = System.Drawing.Color.Black;
            this.textBox110.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.Border.TopColor = System.Drawing.Color.Black;
            this.textBox110.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox110.DataField = "OtherRetGdsStockTtlPricTaxExcRF";
            this.textBox110.Height = 0.16F;
            this.textBox110.Left = 9.0625F;
            this.textBox110.MultiLine = false;
            this.textBox110.Name = "textBox110";
            this.textBox110.OutputFormat = resources.GetString("textBox110.OutputFormat");
            this.textBox110.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox110.SummaryGroup = "groupHeader2";
            this.textBox110.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox110.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox110.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox110.Top = 1.5F;
            this.textBox110.Width = 0.938F;
            // 
            // textBox111
            // 
            this.textBox111.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox111.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox111.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Border.RightColor = System.Drawing.Color.Black;
            this.textBox111.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Border.TopColor = System.Drawing.Color.Black;
            this.textBox111.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox111.Height = 0.156F;
            this.textBox111.Left = 8.513F;
            this.textBox111.MultiLine = false;
            this.textBox111.Name = "textBox111";
            this.textBox111.OutputFormat = resources.GetString("textBox111.OutputFormat");
            this.textBox111.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox111.Text = "枚";
            this.textBox111.Top = 1.5F;
            this.textBox111.Width = 0.15F;
            // 
            // textBox112
            // 
            this.textBox112.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox112.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox112.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.Border.RightColor = System.Drawing.Color.Black;
            this.textBox112.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.Border.TopColor = System.Drawing.Color.Black;
            this.textBox112.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox112.DataField = "OtherDisSlipCntRF";
            this.textBox112.Height = 0.16F;
            this.textBox112.Left = 7.9375F;
            this.textBox112.MultiLine = false;
            this.textBox112.Name = "textBox112";
            this.textBox112.OutputFormat = resources.GetString("textBox112.OutputFormat");
            this.textBox112.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox112.SummaryGroup = "groupHeader2";
            this.textBox112.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox112.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox112.Text = "123,456";
            this.textBox112.Top = 1.5F;
            this.textBox112.Width = 0.5125F;
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
            this.label34.DataField = "TaxRate1RetTitle";
            this.label34.Height = 0.16F;
            this.label34.HyperLink = null;
            this.label34.Left = 8.7F;
            this.label34.Name = "label34";
            this.label34.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label34.Text = "税率１";
            this.label34.Top = 1.125F;
            this.label34.Width = 0.5F;
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
            this.label35.DataField = "TaxRate2RetTitle";
            this.label35.Height = 0.16F;
            this.label35.HyperLink = null;
            this.label35.Left = 8.7F;
            this.label35.Name = "label35";
            this.label35.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label35.Text = "税率２";
            this.label35.Top = 1.313F;
            this.label35.Width = 0.5F;
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
            this.label36.HyperLink = null;
            this.label36.Left = 8.7F;
            this.label36.Name = "label36";
            this.label36.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label36.Text = "その他";
            this.label36.Top = 1.5F;
            this.label36.Width = 0.5F;
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
            this.textBox4.DataField = "TaxFreeSalSlipCntRF";
            this.textBox4.Height = 0.16F;
            this.textBox4.Left = 7.9375F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox4.SummaryGroup = "groupHeader2";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "123,456";
            this.textBox4.Top = 0.75F;
            this.textBox4.Width = 0.5125F;
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
            this.textBox7.Height = 0.156F;
            this.textBox7.Left = 8.513F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox7.Text = "枚";
            this.textBox7.Top = 0.75F;
            this.textBox7.Width = 0.15F;
            // 
            // label55
            // 
            this.label55.Border.BottomColor = System.Drawing.Color.Black;
            this.label55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.LeftColor = System.Drawing.Color.Black;
            this.label55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.RightColor = System.Drawing.Color.Black;
            this.label55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.TopColor = System.Drawing.Color.Black;
            this.label55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.DataField = "TaxFreeTitle";
            this.label55.Height = 0.16F;
            this.label55.HyperLink = null;
            this.label55.Left = 8.7F;
            this.label55.Name = "label55";
            this.label55.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label55.Text = "非課税";
            this.label55.Top = 0.75F;
            this.label55.Width = 0.5F;
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
            this.textBox39.DataField = "TaxFreeStockTtlPricTaxExcRF";
            this.textBox39.Height = 0.16F;
            this.textBox39.Left = 9.0625F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox39.SummaryGroup = "groupHeader2";
            this.textBox39.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox39.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox39.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox39.Top = 0.75F;
            this.textBox39.Width = 0.938F;
            // 
            // textBox114
            // 
            this.textBox114.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.Border.RightColor = System.Drawing.Color.Black;
            this.textBox114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.Border.TopColor = System.Drawing.Color.Black;
            this.textBox114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox114.DataField = "TaxFreeDisSlipCntRF";
            this.textBox114.Height = 0.16F;
            this.textBox114.Left = 7.9375F;
            this.textBox114.MultiLine = false;
            this.textBox114.Name = "textBox114";
            this.textBox114.OutputFormat = resources.GetString("textBox114.OutputFormat");
            this.textBox114.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox114.SummaryGroup = "groupHeader2";
            this.textBox114.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox114.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox114.Text = "123,456";
            this.textBox114.Top = 1.6875F;
            this.textBox114.Width = 0.5125F;
            // 
            // textBox179
            // 
            this.textBox179.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox179.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox179.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox179.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox179.Border.RightColor = System.Drawing.Color.Black;
            this.textBox179.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox179.Border.TopColor = System.Drawing.Color.Black;
            this.textBox179.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox179.Height = 0.156F;
            this.textBox179.Left = 8.513F;
            this.textBox179.MultiLine = false;
            this.textBox179.Name = "textBox179";
            this.textBox179.OutputFormat = resources.GetString("textBox179.OutputFormat");
            this.textBox179.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox179.Text = "枚";
            this.textBox179.Top = 1.688F;
            this.textBox179.Width = 0.15F;
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
            this.label56.Height = 0.16F;
            this.label56.HyperLink = null;
            this.label56.Left = 8.7F;
            this.label56.Name = "label56";
            this.label56.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label56.Text = "非課税";
            this.label56.Top = 1.688F;
            this.label56.Width = 0.5F;
            // 
            // textBox211
            // 
            this.textBox211.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox211.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox211.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox211.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox211.Border.RightColor = System.Drawing.Color.Black;
            this.textBox211.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox211.Border.TopColor = System.Drawing.Color.Black;
            this.textBox211.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox211.DataField = "TaxFreeRetGdsStockTtlPricTaxExcRF";
            this.textBox211.Height = 0.16F;
            this.textBox211.Left = 9.0625F;
            this.textBox211.MultiLine = false;
            this.textBox211.Name = "textBox211";
            this.textBox211.OutputFormat = resources.GetString("textBox211.OutputFormat");
            this.textBox211.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox211.SummaryGroup = "groupHeader2";
            this.textBox211.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox211.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox211.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox211.Top = 1.6875F;
            this.textBox211.Width = 0.938F;
            // 
            // textBox212
            // 
            this.textBox212.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox212.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox212.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox212.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox212.Border.RightColor = System.Drawing.Color.Black;
            this.textBox212.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox212.Border.TopColor = System.Drawing.Color.Black;
            this.textBox212.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox212.DataField = "TaxFreeSalSlipCntRF";
            this.textBox212.Height = 0.16F;
            this.textBox212.Left = 7.9375F;
            this.textBox212.MultiLine = false;
            this.textBox212.Name = "textBox212";
            this.textBox212.OutputFormat = resources.GetString("textBox212.OutputFormat");
            this.textBox212.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox212.SummaryGroup = "groupHeader1";
            this.textBox212.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox212.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox212.Text = "123,456";
            this.textBox212.Top = 0.75F;
            this.textBox212.Width = 0.5125F;
            // 
            // textBox213
            // 
            this.textBox213.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox213.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox213.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox213.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox213.Border.RightColor = System.Drawing.Color.Black;
            this.textBox213.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox213.Border.TopColor = System.Drawing.Color.Black;
            this.textBox213.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox213.Height = 0.156F;
            this.textBox213.Left = 8.51F;
            this.textBox213.MultiLine = false;
            this.textBox213.Name = "textBox213";
            this.textBox213.OutputFormat = resources.GetString("textBox213.OutputFormat");
            this.textBox213.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox213.Text = "枚";
            this.textBox213.Top = 0.75F;
            this.textBox213.Width = 0.15F;
            // 
            // label57
            // 
            this.label57.Border.BottomColor = System.Drawing.Color.Black;
            this.label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.LeftColor = System.Drawing.Color.Black;
            this.label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.RightColor = System.Drawing.Color.Black;
            this.label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.TopColor = System.Drawing.Color.Black;
            this.label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.DataField = "TaxFreeTitle";
            this.label57.Height = 0.16F;
            this.label57.HyperLink = null;
            this.label57.Left = 8.7F;
            this.label57.Name = "label57";
            this.label57.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label57.Text = "非課税";
            this.label57.Top = 0.75F;
            this.label57.Width = 0.5F;
            // 
            // textBox214
            // 
            this.textBox214.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox214.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox214.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox214.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox214.Border.RightColor = System.Drawing.Color.Black;
            this.textBox214.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox214.Border.TopColor = System.Drawing.Color.Black;
            this.textBox214.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox214.DataField = "TaxFreeStockTtlPricTaxExcRF";
            this.textBox214.Height = 0.16F;
            this.textBox214.Left = 9.0625F;
            this.textBox214.MultiLine = false;
            this.textBox214.Name = "textBox214";
            this.textBox214.OutputFormat = resources.GetString("textBox214.OutputFormat");
            this.textBox214.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox214.SummaryGroup = "groupHeader1";
            this.textBox214.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox214.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox214.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox214.Top = 0.75F;
            this.textBox214.Width = 0.938F;
            // 
            // textBox215
            // 
            this.textBox215.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox215.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox215.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox215.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox215.Border.RightColor = System.Drawing.Color.Black;
            this.textBox215.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox215.Border.TopColor = System.Drawing.Color.Black;
            this.textBox215.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox215.DataField = "TaxFreeDisSlipCntRF";
            this.textBox215.Height = 0.16F;
            this.textBox215.Left = 7.9375F;
            this.textBox215.MultiLine = false;
            this.textBox215.Name = "textBox215";
            this.textBox215.OutputFormat = resources.GetString("textBox215.OutputFormat");
            this.textBox215.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox215.SummaryGroup = "groupHeader1";
            this.textBox215.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox215.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox215.Text = "123,456";
            this.textBox215.Top = 1.6875F;
            this.textBox215.Width = 0.5125F;
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
            this.label58.DataField = "TaxFreeRetTitle";
            this.label58.Height = 0.16F;
            this.label58.HyperLink = null;
            this.label58.Left = 8.7F;
            this.label58.Name = "label58";
            this.label58.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label58.Text = "非課税";
            this.label58.Top = 1.688F;
            this.label58.Width = 0.5F;
            // 
            // textBox216
            // 
            this.textBox216.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox216.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox216.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox216.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox216.Border.RightColor = System.Drawing.Color.Black;
            this.textBox216.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox216.Border.TopColor = System.Drawing.Color.Black;
            this.textBox216.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox216.Height = 0.156F;
            this.textBox216.Left = 8.51F;
            this.textBox216.MultiLine = false;
            this.textBox216.Name = "textBox216";
            this.textBox216.OutputFormat = resources.GetString("textBox216.OutputFormat");
            this.textBox216.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox216.Text = "枚";
            this.textBox216.Top = 1.688F;
            this.textBox216.Width = 0.15F;
            // 
            // textBox217
            // 
            this.textBox217.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox217.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox217.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox217.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox217.Border.RightColor = System.Drawing.Color.Black;
            this.textBox217.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox217.Border.TopColor = System.Drawing.Color.Black;
            this.textBox217.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox217.DataField = "TaxFreeRetGdsStockTtlPricTaxExcRF";
            this.textBox217.Height = 0.16F;
            this.textBox217.Left = 9.0625F;
            this.textBox217.MultiLine = false;
            this.textBox217.Name = "textBox217";
            this.textBox217.OutputFormat = resources.GetString("textBox217.OutputFormat");
            this.textBox217.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox217.SummaryGroup = "groupHeader1";
            this.textBox217.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox217.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox217.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox217.Top = 1.6875F;
            this.textBox217.Width = 0.938F;
            // 
            // textBox218
            // 
            this.textBox218.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox218.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox218.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox218.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox218.Border.RightColor = System.Drawing.Color.Black;
            this.textBox218.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox218.Border.TopColor = System.Drawing.Color.Black;
            this.textBox218.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox218.DataField = "TaxFreeSalSlipCntRF";
            this.textBox218.Height = 0.16F;
            this.textBox218.Left = 7.9375F;
            this.textBox218.MultiLine = false;
            this.textBox218.Name = "textBox218";
            this.textBox218.OutputFormat = resources.GetString("textBox218.OutputFormat");
            this.textBox218.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox218.SummaryGroup = "SectionHeader";
            this.textBox218.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox218.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox218.Text = "123,456";
            this.textBox218.Top = 0.75F;
            this.textBox218.Width = 0.5125F;
            // 
            // textBox219
            // 
            this.textBox219.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox219.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox219.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox219.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox219.Border.RightColor = System.Drawing.Color.Black;
            this.textBox219.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox219.Border.TopColor = System.Drawing.Color.Black;
            this.textBox219.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox219.Height = 0.156F;
            this.textBox219.Left = 8.51F;
            this.textBox219.MultiLine = false;
            this.textBox219.Name = "textBox219";
            this.textBox219.OutputFormat = resources.GetString("textBox219.OutputFormat");
            this.textBox219.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox219.Text = "枚";
            this.textBox219.Top = 0.75F;
            this.textBox219.Width = 0.15F;
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
            this.label59.DataField = "TaxFreeTitle";
            this.label59.Height = 0.16F;
            this.label59.HyperLink = null;
            this.label59.Left = 8.7F;
            this.label59.Name = "label59";
            this.label59.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label59.Text = "非課税";
            this.label59.Top = 0.75F;
            this.label59.Width = 0.5F;
            // 
            // textBox220
            // 
            this.textBox220.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox220.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox220.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox220.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox220.Border.RightColor = System.Drawing.Color.Black;
            this.textBox220.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox220.Border.TopColor = System.Drawing.Color.Black;
            this.textBox220.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox220.DataField = "TaxFreeStockTtlPricTaxExcRF";
            this.textBox220.Height = 0.16F;
            this.textBox220.Left = 9.0625F;
            this.textBox220.MultiLine = false;
            this.textBox220.Name = "textBox220";
            this.textBox220.OutputFormat = resources.GetString("textBox220.OutputFormat");
            this.textBox220.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox220.SummaryGroup = "SectionHeader";
            this.textBox220.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox220.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox220.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox220.Top = 0.75F;
            this.textBox220.Width = 0.938F;
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
            this.label60.DataField = "OtherRetTitle";
            this.label60.Height = 0.16F;
            this.label60.HyperLink = null;
            this.label60.Left = 8.7F;
            this.label60.Name = "label60";
            this.label60.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label60.Text = "その他";
            this.label60.Top = 1.5F;
            this.label60.Width = 0.5F;
            // 
            // textBox224
            // 
            this.textBox224.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox224.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox224.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox224.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox224.Border.RightColor = System.Drawing.Color.Black;
            this.textBox224.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox224.Border.TopColor = System.Drawing.Color.Black;
            this.textBox224.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox224.DataField = "TaxFreeDisSlipCntRF";
            this.textBox224.Height = 0.16F;
            this.textBox224.Left = 7.9375F;
            this.textBox224.MultiLine = false;
            this.textBox224.Name = "textBox224";
            this.textBox224.OutputFormat = resources.GetString("textBox224.OutputFormat");
            this.textBox224.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox224.SummaryGroup = "SectionHeader";
            this.textBox224.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox224.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox224.Text = "123,456";
            this.textBox224.Top = 1.6875F;
            this.textBox224.Width = 0.5125F;
            // 
            // textBox225
            // 
            this.textBox225.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox225.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox225.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox225.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox225.Border.RightColor = System.Drawing.Color.Black;
            this.textBox225.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox225.Border.TopColor = System.Drawing.Color.Black;
            this.textBox225.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox225.Height = 0.156F;
            this.textBox225.Left = 8.51F;
            this.textBox225.MultiLine = false;
            this.textBox225.Name = "textBox225";
            this.textBox225.OutputFormat = resources.GetString("textBox225.OutputFormat");
            this.textBox225.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox225.Text = "枚";
            this.textBox225.Top = 1.688F;
            this.textBox225.Width = 0.15F;
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
            this.label61.DataField = "TaxFreeRetTitle";
            this.label61.Height = 0.16F;
            this.label61.HyperLink = null;
            this.label61.Left = 8.7F;
            this.label61.Name = "label61";
            this.label61.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label61.Text = "非課税";
            this.label61.Top = 1.688F;
            this.label61.Width = 0.5F;
            // 
            // textBox226
            // 
            this.textBox226.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox226.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox226.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox226.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox226.Border.RightColor = System.Drawing.Color.Black;
            this.textBox226.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox226.Border.TopColor = System.Drawing.Color.Black;
            this.textBox226.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox226.DataField = "TaxFreeRetGdsStockTtlPricTaxExcRF";
            this.textBox226.Height = 0.16F;
            this.textBox226.Left = 9.0625F;
            this.textBox226.MultiLine = false;
            this.textBox226.Name = "textBox226";
            this.textBox226.OutputFormat = resources.GetString("textBox226.OutputFormat");
            this.textBox226.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox226.SummaryGroup = "SectionHeader";
            this.textBox226.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox226.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox226.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox226.Top = 1.6875F;
            this.textBox226.Width = 0.938F;
            // 
            // textBox221
            // 
            this.textBox221.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox221.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox221.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox221.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox221.Border.RightColor = System.Drawing.Color.Black;
            this.textBox221.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox221.Border.TopColor = System.Drawing.Color.Black;
            this.textBox221.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox221.DataField = "TaxFreeSalSlipCntRF";
            this.textBox221.Height = 0.16F;
            this.textBox221.Left = 7.9375F;
            this.textBox221.MultiLine = false;
            this.textBox221.Name = "textBox221";
            this.textBox221.OutputFormat = resources.GetString("textBox221.OutputFormat");
            this.textBox221.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox221.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox221.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox221.Text = "123,456";
            this.textBox221.Top = 0.8125F;
            this.textBox221.Width = 0.5125F;
            // 
            // textBox222
            // 
            this.textBox222.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox222.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox222.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox222.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox222.Border.RightColor = System.Drawing.Color.Black;
            this.textBox222.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox222.Border.TopColor = System.Drawing.Color.Black;
            this.textBox222.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox222.Height = 0.156F;
            this.textBox222.Left = 8.51F;
            this.textBox222.MultiLine = false;
            this.textBox222.Name = "textBox222";
            this.textBox222.OutputFormat = resources.GetString("textBox222.OutputFormat");
            this.textBox222.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox222.Text = "枚";
            this.textBox222.Top = 0.813F;
            this.textBox222.Width = 0.15F;
            // 
            // label48
            // 
            this.label48.Border.BottomColor = System.Drawing.Color.Black;
            this.label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.LeftColor = System.Drawing.Color.Black;
            this.label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.RightColor = System.Drawing.Color.Black;
            this.label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.TopColor = System.Drawing.Color.Black;
            this.label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.DataField = "TaxFreeTitle";
            this.label48.Height = 0.16F;
            this.label48.HyperLink = null;
            this.label48.Left = 8.7F;
            this.label48.Name = "label48";
            this.label48.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label48.Text = "非課税";
            this.label48.Top = 0.813F;
            this.label48.Width = 0.5F;
            // 
            // textBox223
            // 
            this.textBox223.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox223.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox223.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox223.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox223.Border.RightColor = System.Drawing.Color.Black;
            this.textBox223.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox223.Border.TopColor = System.Drawing.Color.Black;
            this.textBox223.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox223.DataField = "TaxFreeStockTtlPricTaxExcRF";
            this.textBox223.Height = 0.16F;
            this.textBox223.Left = 9.0625F;
            this.textBox223.MultiLine = false;
            this.textBox223.Name = "textBox223";
            this.textBox223.OutputFormat = resources.GetString("textBox223.OutputFormat");
            this.textBox223.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox223.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox223.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox223.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox223.Top = 0.8125F;
            this.textBox223.Width = 0.938F;
            // 
            // textBox227
            // 
            this.textBox227.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox227.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox227.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox227.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox227.Border.RightColor = System.Drawing.Color.Black;
            this.textBox227.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox227.Border.TopColor = System.Drawing.Color.Black;
            this.textBox227.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox227.DataField = "TaxFreeDisSlipCntRF";
            this.textBox227.Height = 0.16F;
            this.textBox227.Left = 7.9375F;
            this.textBox227.MultiLine = false;
            this.textBox227.Name = "textBox227";
            this.textBox227.OutputFormat = resources.GetString("textBox227.OutputFormat");
            this.textBox227.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox227.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox227.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox227.Text = "123,456";
            this.textBox227.Top = 1.75F;
            this.textBox227.Width = 0.5125F;
            // 
            // textBox228
            // 
            this.textBox228.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox228.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox228.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox228.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox228.Border.RightColor = System.Drawing.Color.Black;
            this.textBox228.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox228.Border.TopColor = System.Drawing.Color.Black;
            this.textBox228.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox228.Height = 0.156F;
            this.textBox228.Left = 8.51F;
            this.textBox228.MultiLine = false;
            this.textBox228.Name = "textBox228";
            this.textBox228.OutputFormat = resources.GetString("textBox228.OutputFormat");
            this.textBox228.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox228.Text = "枚";
            this.textBox228.Top = 1.75F;
            this.textBox228.Width = 0.15F;
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
            this.label62.DataField = "TaxFreeRetTitle";
            this.label62.Height = 0.16F;
            this.label62.HyperLink = null;
            this.label62.Left = 8.7F;
            this.label62.Name = "label62";
            this.label62.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label62.Text = "非課税";
            this.label62.Top = 1.75F;
            this.label62.Width = 0.5F;
            // 
            // textBox229
            // 
            this.textBox229.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox229.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox229.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox229.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox229.Border.RightColor = System.Drawing.Color.Black;
            this.textBox229.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox229.Border.TopColor = System.Drawing.Color.Black;
            this.textBox229.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox229.DataField = "TaxFreeRetGdsStockTtlPricTaxExcRF";
            this.textBox229.Height = 0.16F;
            this.textBox229.Left = 9.0625F;
            this.textBox229.MultiLine = false;
            this.textBox229.Name = "textBox229";
            this.textBox229.OutputFormat = resources.GetString("textBox229.OutputFormat");
            this.textBox229.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox229.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox229.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox229.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.textBox229.Top = 1.75F;
            this.textBox229.Width = 0.938F;
            // 
            // MAKON02243P_01A4C
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
            this.Sections.Add(this.TitleHeader2);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SectionHeader2);
            this.Sections.Add(this.groupHeader3);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.groupHeader1_2);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.groupHeader2_2);
            this.Sections.Add(this.DailyHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.DailyFooter);
            this.Sections.Add(this.groupFooter2_2);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1_2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.groupFooter3);
            this.Sections.Add(this.SectionFooter2);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.TitleFooter2);
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
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppTtlAmntDspWayCdRFTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppCTaxLayCdRFTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxationCodeTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierConsTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeaderSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tg_SalesGrsProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesGrsProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyFooter_TaxRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyFooterTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyFooter_suppCTaxLayCdRFTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter1Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter2Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox180)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox181)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox182)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox183)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox184)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox185)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox186)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox187)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox188)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox189)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox190)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox191)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox192)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox193)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox194)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox195)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox196)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox197)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox198)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox199)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox200)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox201)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox202)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox203)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox204)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox205)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox206)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox207)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox208)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox209)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox210)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox146)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox148)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox149)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox152)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox155)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox156)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox157)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox158)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox159)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox160)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox161)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox163)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox166)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox167)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox169)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox170)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox171)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox172)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox173)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox174)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox175)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox176)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox177)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox178)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter1Title_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox115)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox121)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox124)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox125)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox127)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox128)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox129)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox130)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox135)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox136)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox138)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox142)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox143)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox144)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox145)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupFooter2Title_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox112)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox114)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox179)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox211)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox212)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox213)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox214)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox215)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox216)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox217)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox218)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox219)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox220)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox224)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox225)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox226)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox221)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox222)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox223)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox227)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox228)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox229)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            string aaa;

            aaa = SectionHeaderLine.Text;


        }

        private void TitleHeader_Format(object sender, EventArgs e)
        {

        }

        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
        /// <summary>
        /// 仕入日計フッターのFormatイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void groupFooter2_Format(object sender, EventArgs e)
        {
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 >>>>>>START
            //// TODO:仕入日計
            //HideTextBoxIfNumberIsZero(this.textBox4);
            //HideTextBoxIfNumberIsZero(this.textBox78);
            //HideTextBoxIfNumberIsZero(this.textBox80);

            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 >>>>>>START
            //HideTextBoxIfNumberIsZero(this.textBox88);
            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 <<<<<<END
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 <<<<<<END
        }

        /// <summary>
        /// 仕入先計フッターのFormaイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void groupFooter1_Format(object sender, EventArgs e)
        {
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 >>>>>>START
            //// TODO:仕入先計
            //HideTextBoxIfNumberIsZero(this.textBox41);
            //HideTextBoxIfNumberIsZero(this.textBox39);
            //HideTextBoxIfNumberIsZero(this.textBox7);

            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 >>>>>>START
            //HideTextBoxIfNumberIsZero(this.textBox89);
            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 <<<<<<END
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 <<<<<<END
        }

        /// <summary>
        /// 総合計フッターのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void TitleFooter_Format(object sender, EventArgs e)
        {
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 >>>>>>START
            //// TODO:総合計
            //HideTextBoxIfNumberIsZero(this.textBox49);
            //HideTextBoxIfNumberIsZero(this.textBox47);
            //HideTextBoxIfNumberIsZero(this.tg_Cost);

            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 >>>>>>START
            //HideTextBoxIfNumberIsZero(this.textBox92);
            //// 2009.01.09 30413 犬飼 値引の消費税印字仕様を追加 <<<<<<END
            // 2009.01.29 30413 犬飼 合計部の消費税はゼロ印字に修正 <<<<<<END
        }
        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

        // --- ADD 2009/04/14 -------------------------------->>>>>
        /// <summary>
        /// DailyFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DailyFooter_BeforePrint(object sender, EventArgs e)
        {
            if (this.DailyFooter_suppCTaxLayCdRFTextBox.Value.ToString().TrimEnd() != "0"
                    && this.DailyFooter_suppCTaxLayCdRFTextBox.Value.ToString().TrimEnd() != "1")
            {
                this.DailyFooter_TaxRF.Text = "";
            }
        }
        // --- ADD 2009/04/14 -------------------------------->>>>>
	}
}
