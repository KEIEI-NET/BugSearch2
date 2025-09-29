//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上順位表
// プログラム概要   : 売上順位表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 立花 裕輔
// 作 成 日  2007/09/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/09/24  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/10/30  修正内容 : レイアウト変更に伴う修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13155
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【8788】残案件No.19 端数処理
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 許培珠
// 修 正 日  2012/04/26  修正内容 : 2012/05/24配信分　redmine#29619 BLコード計の数量の印字位置が不正
//                                  帳票の項目を改修のみ、本体ソース改修無し
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Drawing;
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
	/// 出荷商品順位表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 出荷商品順位表のフォームクラスです。</br>
	/// <br>Programmer	: 96186 立花 裕輔</br>
	/// <br>Date		: 2007.09.03</br>
    /// <br>Update Note : 2008.09.24 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>Update Note : 2008.10.30 30452 上野 俊治</br>
    /// <br>            ・レイアウト変更に伴う修正</br>
    /// <br>Update Note : 2009/04/07 30452 上野 俊治</br>
    /// <br>            ・障害対応13155</br>
	/// <br></br>
	/// </remarks>
	public class DCHNB02052P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 出荷商品順位表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 出荷商品順位表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 96186　立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		public DCHNB02052P_01A4C()
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

		private ShipmGoodsOdrReport _shipmGoodsOdrReport;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        // 明細開始ライン印字要否
        //private bool Line_DetailHead_Visible = true; // DEL 2009/04/07

        #region サプレスバッファ
        private Label Lb_Month01;
		private Label Lb_Month07;
		private Label Lb_Month09;
		private Label Lb_Month10;
		private TextBox uMonth03;
		private TextBox dMonth03;
		private TextBox to_uMonth03;
		private TextBox to_dMonth03;
		private TextBox se_dMonth04;
		private TextBox uMonth09;
		private TextBox dMonth08;
		private TextBox se_uMonth09;
		private TextBox se_dMonth09;
		private TextBox to_uMonth09;
		private TextBox to_dMonth09;
		private TextBox dMonth09;
		private TextBox to_dMonth10;
		private TextBox se_dMonth10;
		private TextBox dMonthAve;
		private TextBox to_dMonthTotal;
        private TextBox se_uMonth03;
		private Label Lb_Month12;
		private Label Lb_MonthTotal;
		private Label Lb_MonthAve;
		private Label Lb_BLGoodsCode;
		private TextBox uMonth08;
		private TextBox uMonth10;
		private TextBox uMonth11;
		private TextBox uMonthTotal;
		private TextBox uMonthAve;
		private TextBox dMonth11;
		private TextBox dMonth12;
        private TextBox dMonthTotal;
		private TextBox to_uMonthAve;
		private TextBox to_uMonth04;
		private TextBox to_dMonth04;
		private TextBox to_uMonth10;
		private TextBox to_uMonth11;
		private TextBox to_dMonth11;
		private TextBox to_uMonthTotal;
		private TextBox se_uMonth04;
		private TextBox se_dMonth03;
		private TextBox se_uMonth10;
		private TextBox se_uMonth11;
		private TextBox se_dMonth11;
		private TextBox se_uMonthTotal;
		private TextBox se_dMonthTotal;
		private TextBox se_uMonthAve;
        private TextBox se_dMonthAve;
        private TextBox to_dMonthAve;
		private Label Lb_Month05;
		private Label Lb_Month06;
		private Label Lb_Month08;
		private TextBox OrderNo;
		private Label label16;
		private GroupHeader BLGoodsHeader;
		private GroupFooter BLGoodsFooter;
        private TextBox textBox11;
		private Line line2;
        private TextBox textBox10;
		private TextBox mk_uMonth12;
		private TextBox mk_uMonth05;
		private TextBox mk_dMonth05;
		private TextBox mk_uMonth06;
		private TextBox mk_uMonth08;
		private TextBox mk_dMonth06;
		private TextBox mk_dMonth08;
		private TextBox mk_dMonth12;
		private TextBox mk_uMonth03;
		private TextBox mk_dMonth04;
		private TextBox mk_uMonth09;
		private TextBox mk_dMonth09;
		private TextBox mk_dMonth10;
		private TextBox mk_dMonthTotal;
		private TextBox mk_uMonth04;
		private TextBox mk_dMonth03;
		private TextBox mk_uMonth10;
		private TextBox mk_uMonth11;
		private TextBox mk_dMonth11;
		private TextBox mk_uMonthTotal;
		private TextBox mk_uMonthAve;
		private TextBox mk_dMonthAve;
		private TextBox mk_uMonth07;
		private TextBox mk_dMonth07;
		private TextBox mk_uMonth02;
		private TextBox mk_dMonth02;
		private TextBox mk_uMonth01;
		private TextBox mk_dMonth01;
		private TextBox bl_uMonth12;
		private TextBox bl_uMonth05;
		private TextBox bl_dMonth05;
		private TextBox bl_uMonth06;
		private TextBox bl_uMonth08;
		private TextBox bl_dMonth06;
		private TextBox bl_dMonth08;
		private TextBox bl_dMonth12;
		private TextBox bl_uMonth03;
		private TextBox bl_dMonth04;
		private TextBox bl_uMonth09;
		private TextBox bl_dMonth09;
		private TextBox bl_dMonth10;
		private TextBox bl_dMonthTotal;
		private TextBox bl_uMonth04;
		private TextBox bl_dMonth03;
		private TextBox bl_uMonth10;
		private TextBox bl_uMonth11;
		private TextBox bl_dMonth11;
		private TextBox bl_uMonthTotal;
		private TextBox bl_uMonthAve;
		private TextBox bl_dMonthAve;
		private TextBox bl_uMonth07;
		private TextBox bl_dMonth07;
		private TextBox bl_uMonth02;
		private TextBox bl_dMonth02;
		private TextBox bl_uMonth01;
		private TextBox bl_dMonth01;
		private TextBox uMonth07;
		private TextBox dMonth07;
		private TextBox to_uMonth02;
		private TextBox to_dMonth02;
		private TextBox to_uMonth01;
		private TextBox to_dMonth01;
		private TextBox to_uMonth07;
		private TextBox to_dMonth07;
		private TextBox se_uMonth02;
		private TextBox se_dMonth02;
		private TextBox se_uMonth01;
		private TextBox se_dMonth01;
		private TextBox se_uMonth07;
		private TextBox se_dMonth07;
		private TextBox uMonth02;
		private TextBox dMonth02;
		private TextBox uMonth01;
		private TextBox dMonth01;
		private Line line3;
		private GroupHeader CustomerHeader;
		private GroupFooter CustomerFooter;
		private TextBox textBox98;
		private Line line5;
		private GroupHeader SalesEmployeeHeader;
		private GroupFooter SalesEmployeeFooter;
		private TextBox textBox99;
		private Line line6;
		private TextBox cu_uMonth12;
		private TextBox cu_uMonth05;
		private TextBox cu_dMonth05;
		private TextBox cu_uMonth06;
		private TextBox cu_uMonth08;
		private TextBox cu_dMonth06;
		private TextBox cu_dMonth08;
		private TextBox cu_dMonth12;
		private TextBox cu_uMonth03;
		private TextBox cu_dMonth04;
		private TextBox cu_uMonth09;
		private TextBox cu_dMonth09;
		private TextBox cu_dMonth10;
		private TextBox cu_dMonthTotal;
		private TextBox cu_uMonth04;
		private TextBox cu_dMonth03;
		private TextBox cu_uMonth10;
		private TextBox cu_uMonth11;
		private TextBox cu_dMonth11;
		private TextBox cu_uMonthTotal;
		private TextBox cu_uMonthAve;
		private TextBox cu_dMonthAve;
		private TextBox cu_uMonth07;
		private TextBox cu_dMonth07;
		private TextBox cu_uMonth02;
		private TextBox cu_dMonth02;
		private TextBox cu_uMonth01;
		private TextBox cu_dMonth01;
		private TextBox em_uMonth12;
		private TextBox em_uMonth05;
		private TextBox em_dMonth05;
		private TextBox em_uMonth06;
		private TextBox em_uMonth08;
		private TextBox em_dMonth06;
		private TextBox em_dMonth08;
		private TextBox em_dMonth12;
		private TextBox em_uMonth03;
		private TextBox em_dMonth04;
		private TextBox em_uMonth09;
		private TextBox em_dMonth09;
		private TextBox em_dMonth10;
		private TextBox em_dMonthTotal;
		private TextBox em_uMonth04;
		private TextBox em_dMonth03;
		private TextBox em_uMonth10;
		private TextBox em_uMonth11;
		private TextBox em_dMonth11;
		private TextBox em_uMonthTotal;
		private TextBox em_uMonthAve;
		private TextBox em_dMonthAve;
		private TextBox em_uMonth07;
		private TextBox em_dMonth07;
		private TextBox em_uMonth02;
		private TextBox em_dMonth02;
		private TextBox em_uMonth01;
		private TextBox em_dMonth01;
		private TextBox BLGoodsHalfName;
		private TextBox subTotalBLGoodsCode_textBox;
		private TextBox subTotalBLGoodsHalfName_textBox;
		private TextBox subTotalMaker_GoodsMakerCd;
        private TextBox subTotalMaker_MakerShortName;
        private Label Lb_BLGoodsHalfName;
        private GroupHeader GoodsMGroupHeader;
        private GroupFooter GoodsMGroupFooter;
        private TextBox textBox7;
        private TextBox subTotalGoodsMGroup_textBox;
        private TextBox subTotalGoodsMGroupName_textBox;
        private TextBox mg_dMonth01;
        private TextBox mg_uMonth01;
        private TextBox mg_uMonth02;
        private TextBox mg_dMonth02;
        private TextBox mg_uMonth03;
        private TextBox mg_dMonth03;
        private TextBox mg_uMonth04;
        private TextBox mg_dMonth04;
        private TextBox mg_uMonth05;
        private TextBox mg_dMonth05;
        private TextBox mg_dMonth06;
        private TextBox mg_uMonth06;
        private TextBox mg_uMonth07;
        private TextBox mg_dMonth07;
        private TextBox mg_uMonth08;
        private TextBox mg_dMonth08;
        private TextBox mg_uMonth09;
        private TextBox mg_dMonth09;
        private TextBox mg_uMonth10;
        private TextBox mg_dMonth10;
        private TextBox mg_uMonth11;
        private TextBox mg_dMonth11;
        private TextBox mg_uMonth12;
        private TextBox mg_dMonth12;
        private TextBox mg_uMonthTotal;
        private TextBox mg_dMonthTotal;
        private TextBox mg_uMonthAve;
        private TextBox mg_dMonthAve;
        private GroupHeader SuplierHeader;
        private GroupFooter SuplierFooter;
        private TextBox textBox13;
        private TextBox su_dMonth01;
        private TextBox su_uMonth01;
        private TextBox su_uMonth02;
        private TextBox su_dMonth02;
        private TextBox su_uMonth03;
        private TextBox su_dMonth03;
        private TextBox su_uMonth04;
        private TextBox su_dMonth04;
        private TextBox su_uMonth05;
        private TextBox su_dMonth05;
        private TextBox su_dMonth06;
        private TextBox su_uMonth06;
        private TextBox su_uMonth07;
        private TextBox su_dMonth07;
        private TextBox su_uMonth08;
        private TextBox su_dMonth08;
        private TextBox su_uMonth09;
        private TextBox su_dMonth09;
        private TextBox su_uMonth10;
        private TextBox su_dMonth10;
        private TextBox su_uMonth11;
        private TextBox su_dMonth11;
        private TextBox su_uMonth12;
        private TextBox su_dMonth12;
        private TextBox su_uMonthTotal;
        private TextBox su_dMonthTotal;
        private TextBox su_uMonthAve;
        private TextBox su_dMonthAve;
        private GroupHeader BLGroupHeader;
        private GroupFooter BLGroupFooter;
        private TextBox textBox21;
        private TextBox subTotalBLGroupCode_textbox;
        private TextBox subTotalBLGroupKanaName_textBox;
        private TextBox gr_dMonth01;
        private TextBox gr_uMonth01;
        private TextBox gr_uMonth02;
        private TextBox gr_dMonth02;
        private TextBox gr_uMonth03;
        private TextBox gr_dMonth03;
        private TextBox gr_uMonth04;
        private TextBox gr_dMonth04;
        private TextBox gr_uMonth05;
        private TextBox gr_dMonth05;
        private TextBox gr_dMonth06;
        private TextBox gr_uMonth06;
        private TextBox gr_uMonth07;
        private TextBox gr_dMonth07;
        private TextBox gr_uMonth08;
        private TextBox gr_dMonth08;
        private TextBox gr_uMonth09;
        private TextBox gr_dMonth09;
        private TextBox gr_uMonth10;
        private TextBox gr_dMonth10;
        private TextBox gr_uMonth11;
        private TextBox gr_dMonth11;
        private TextBox gr_uMonth12;
        private TextBox gr_dMonth12;
        private TextBox gr_uMonthTotal;
        private TextBox gr_dMonthTotal;
        private TextBox gr_uMonthAve;
        private TextBox gr_dMonthAve;
        private Line line7;
        private Line line8;
        private Line line10;
        private SubReport Footer_SubReport;
        private Label CusHd_SectionTitle;
        private TextBox CusHd_SectionCode;
        private TextBox CusHd_SectionName;
        private Label CusHd_CustomerTitle;
        private TextBox CusHd_CustomerCode;
        private TextBox CusHd_CustomerName;
        private Label EmpHd_EmployeeTitle;
        private TextBox EmpHd_EmployeeCode;
        private TextBox EmpHd_EmployeeName;
        private TextBox GoodsMakerCd;
        private TextBox BLGroupCode;
        private Label Lb_MakerName;
        private Label Lb_BLGroupCode;
        private TextBox MakerName;
        private Label EmpHd_SectionTitle;
        private TextBox EmpHd_SectionCode;
        private TextBox EmpHd_SectionName;
        private Label SupHd_SupplierTitle;
        private TextBox SupHd_SupplierCode;
        private TextBox SupHd_SupplierName;
        private TextBox SupHd_SectionName;
        private Label SupHd_SectionTitle;
        private TextBox SupHd_SectionCode;
        private Line Line_DetailHead;
        private Line line9;
        private Line line11;
        private Line line4;
        private TextBox BLGroupKanaName;
        #endregion

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
				this._shipmGoodsOdrReport	= (ShipmGoodsOdrReport)this._printInfo.jyoken;
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
            // 印字設定 --------------------------------------------------------------------------------------
            // 拠点計を出力するかしないかを選択する
            // 拠点有無を判断
            //if ( this._shipmGoodsOdrReport.IsOptSection )
            //{
            //	// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //	if ((this._shipmGoodsOdrReport.SectionCode.Length < 2) || 
            //		this._shipmGoodsOdrReport.IsSelectAllSection )
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
            SortTitle.Text = this._pageHeaderSortOderTitle;

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //全社 拠点単位の判定
            //bool TtlTypeBool = true;


            //-------------------------------------------------------
            // 月範囲の適用（抽出された範囲内で処理する）
            //-------------------------------------------------------
            #region [月範囲の適用]
            // 作業用にリスト生成
            #region [作業用リスト生成]
            ArrayList[] ctrlList = new ArrayList[12];

            // 月01
            ctrlList[0] = new ArrayList();
            ctrlList[0].AddRange(new object[] { Lb_Month01 });
            //ctrlList[0].AddRange(new object[] { to_uMonth01, uMonth01, bl_uMonth01, mk_uMonth01, em_uMonth01, cu_uMonth01, se_uMonth01 }); // DEL 2008/09/24
            //ctrlList[0].AddRange(new object[] { to_dMonth01, dMonth01, bl_dMonth01, mk_dMonth01, em_dMonth01, cu_dMonth01, se_dMonth01 }); // DEL 2008/09/24
            ctrlList[0].AddRange(new object[] { to_uMonth01, uMonth01, bl_uMonth01, mk_uMonth01, em_uMonth01, cu_uMonth01, se_uMonth01, su_uMonth01, mg_uMonth01, gr_uMonth01 }); // ADD 2008/09/24
            ctrlList[0].AddRange(new object[] { to_dMonth01, dMonth01, bl_dMonth01, mk_dMonth01, em_dMonth01, cu_dMonth01, se_dMonth01, su_dMonth01, mg_dMonth01, gr_dMonth01 }); // ADD 2008/09/24

            // 月02
            ctrlList[1] = new ArrayList();
            ctrlList[1].AddRange(new object[] { Lb_Month02 });
            //ctrlList[1].AddRange(new object[] { to_uMonth02, uMonth02, bl_uMonth02, mk_uMonth02, em_uMonth02, cu_uMonth02, se_uMonth02 }); // DEL 2008/09/24
            //ctrlList[1].AddRange(new object[] { to_dMonth02, dMonth02, bl_dMonth02, mk_dMonth02, em_dMonth02, cu_dMonth02, se_dMonth02 }); // DEL 2008/09/24
            ctrlList[1].AddRange(new object[] { to_uMonth02, uMonth02, bl_uMonth02, mk_uMonth02, em_uMonth02, cu_uMonth02, se_uMonth02, su_uMonth02, mg_uMonth02, gr_uMonth02 }); // ADD 2008/09/24
            ctrlList[1].AddRange(new object[] { to_dMonth02, dMonth02, bl_dMonth02, mk_dMonth02, em_dMonth02, cu_dMonth02, se_dMonth02, su_dMonth02, mg_dMonth02, gr_dMonth02 }); // ADD 2008/09/24

            // 月03
            ctrlList[2] = new ArrayList();
            ctrlList[2].AddRange(new object[] { Lb_Month03 });
            //ctrlList[2].AddRange(new object[] { to_uMonth03, uMonth03, bl_uMonth03, mk_uMonth03, em_uMonth03, cu_uMonth03, se_uMonth03 }); // DEL 2008/09/24
            //ctrlList[2].AddRange(new object[] { to_dMonth03, dMonth03, bl_dMonth03, mk_dMonth03, em_dMonth03, cu_dMonth03, se_dMonth03 }); // DEL 2008/09/24
            ctrlList[2].AddRange(new object[] { to_uMonth03, uMonth03, bl_uMonth03, mk_uMonth03, em_uMonth03, cu_uMonth03, se_uMonth03, su_uMonth03, mg_uMonth03, gr_uMonth03 }); // ADD 2008/09/24
            ctrlList[2].AddRange(new object[] { to_dMonth03, dMonth03, bl_dMonth03, mk_dMonth03, em_dMonth03, cu_dMonth03, se_dMonth03, su_dMonth03, mg_dMonth03, gr_dMonth03 }); // ADD 2008/09/24

            // 月04
            ctrlList[3] = new ArrayList();
            ctrlList[3].AddRange(new object[] { Lb_Month04 });
            //ctrlList[3].AddRange(new object[] { to_uMonth04, uMonth04, bl_uMonth04, mk_uMonth04, em_uMonth04, cu_uMonth04, se_uMonth04 }); // DEL 2008/09/24
            //ctrlList[3].AddRange(new object[] { to_dMonth04, dMonth04, bl_dMonth04, mk_dMonth04, em_dMonth04, cu_dMonth04, se_dMonth04 }); // DEL 2008/09/24
            ctrlList[3].AddRange(new object[] { to_uMonth04, uMonth04, bl_uMonth04, mk_uMonth04, em_uMonth04, cu_uMonth04, se_uMonth04, su_uMonth04, mg_uMonth04, gr_uMonth04 }); // ADD 2008/09/24
            ctrlList[3].AddRange(new object[] { to_dMonth04, dMonth04, bl_dMonth04, mk_dMonth04, em_dMonth04, cu_dMonth04, se_dMonth04, su_dMonth04, mg_dMonth04, gr_dMonth04 }); // ADD 2008/09/24

            // 月05
            ctrlList[4] = new ArrayList();
            ctrlList[4].AddRange(new object[] { Lb_Month05 });
            //ctrlList[4].AddRange(new object[] { to_uMonth05, uMonth05, bl_uMonth05, mk_uMonth05, em_uMonth05, cu_uMonth05, se_uMonth05 }); // DEL 2008/09/24
            //ctrlList[4].AddRange(new object[] { to_dMonth05, dMonth05, bl_dMonth05, mk_dMonth05, em_dMonth05, cu_dMonth05, se_dMonth05 }); // DEL 2008/09/24
            ctrlList[4].AddRange(new object[] { to_uMonth05, uMonth05, bl_uMonth05, mk_uMonth05, em_uMonth05, cu_uMonth05, se_uMonth05, su_uMonth05, mg_uMonth05, gr_uMonth05 }); // ADD 2008/09/24
            ctrlList[4].AddRange(new object[] { to_dMonth05, dMonth05, bl_dMonth05, mk_dMonth05, em_dMonth05, cu_dMonth05, se_dMonth05, su_dMonth05, mg_dMonth05, gr_dMonth05 }); // ADD 2008/09/24

            // 月06
            ctrlList[5] = new ArrayList();
            ctrlList[5].AddRange(new object[] { Lb_Month06 });
            //ctrlList[5].AddRange(new object[] { to_uMonth06, uMonth06, bl_uMonth06, mk_uMonth06, em_uMonth06, cu_uMonth06, se_uMonth06 }); // DEL 2008/09/24
            //ctrlList[5].AddRange(new object[] { to_dMonth06, dMonth06, bl_dMonth06, mk_dMonth06, em_dMonth06, cu_dMonth06, se_dMonth06 }); // DEL 2008/09/24
            ctrlList[5].AddRange(new object[] { to_uMonth06, uMonth06, bl_uMonth06, mk_uMonth06, em_uMonth06, cu_uMonth06, se_uMonth06, su_uMonth06, mg_uMonth06, gr_uMonth06 }); // ADD 2008/09/24
            ctrlList[5].AddRange(new object[] { to_dMonth06, dMonth06, bl_dMonth06, mk_dMonth06, em_dMonth06, cu_dMonth06, se_dMonth06, su_dMonth06, mg_dMonth06, gr_dMonth06 }); // ADD 2008/09/24

            // 月07
            ctrlList[6] = new ArrayList();
            ctrlList[6].AddRange(new object[] { Lb_Month07 });
            //ctrlList[6].AddRange(new object[] { to_uMonth07, uMonth07, bl_uMonth07, mk_uMonth07, em_uMonth07, cu_uMonth07, se_uMonth07 }); // DEL 2008/09/24
            //ctrlList[6].AddRange(new object[] { to_dMonth07, dMonth07, bl_dMonth07, mk_dMonth07, em_dMonth07, cu_dMonth07, se_dMonth07 }); // DEL 2008/09/24
            ctrlList[6].AddRange(new object[] { to_uMonth07, uMonth07, bl_uMonth07, mk_uMonth07, em_uMonth07, cu_uMonth07, se_uMonth07, su_uMonth07, mg_uMonth07, gr_uMonth07 }); // ADD 2008/09/24
            ctrlList[6].AddRange(new object[] { to_dMonth07, dMonth07, bl_dMonth07, mk_dMonth07, em_dMonth07, cu_dMonth07, se_dMonth07, su_dMonth07, mg_dMonth07, gr_dMonth07 }); // ADD 2008/09/24

            // 月08
            ctrlList[7] = new ArrayList();
            ctrlList[7].AddRange(new object[] { Lb_Month08 });
            //ctrlList[7].AddRange(new object[] { to_uMonth08, uMonth08, bl_uMonth08, mk_uMonth08, em_uMonth08, cu_uMonth08, se_uMonth08 }); // DEL 2008/09/24
            //ctrlList[7].AddRange(new object[] { to_dMonth08, dMonth08, bl_dMonth08, mk_dMonth08, em_dMonth08, cu_dMonth08, se_dMonth08 }); // DEL 2008/09/24
            ctrlList[7].AddRange(new object[] { to_uMonth08, uMonth08, bl_uMonth08, mk_uMonth08, em_uMonth08, cu_uMonth08, se_uMonth08, su_uMonth08, mg_uMonth08, gr_uMonth08 }); // ADD 2008/09/24
            ctrlList[7].AddRange(new object[] { to_dMonth08, dMonth08, bl_dMonth08, mk_dMonth08, em_dMonth08, cu_dMonth08, se_dMonth08, su_dMonth08, mg_dMonth08, gr_dMonth08 }); // ADD 2008/09/24

            // 月09
            ctrlList[8] = new ArrayList();
            ctrlList[8].AddRange(new object[] { Lb_Month09 });
            //ctrlList[8].AddRange(new object[] { to_uMonth09, uMonth09, bl_uMonth09, mk_uMonth09, em_uMonth09, cu_uMonth09, se_uMonth09 }); // DEL 2008/09/24
            //ctrlList[8].AddRange(new object[] { to_dMonth09, dMonth09, bl_dMonth09, mk_dMonth09, em_dMonth09, cu_dMonth09, se_dMonth09 }); // DEL 2008/09/24
            ctrlList[8].AddRange(new object[] { to_uMonth09, uMonth09, bl_uMonth09, mk_uMonth09, em_uMonth09, cu_uMonth09, se_uMonth09, su_uMonth09, mg_uMonth09, gr_uMonth09 }); // ADD 2008/09/24
            ctrlList[8].AddRange(new object[] { to_dMonth09, dMonth09, bl_dMonth09, mk_dMonth09, em_dMonth09, cu_dMonth09, se_dMonth09, su_dMonth09, mg_dMonth09, gr_dMonth09 }); // ADD 2008/09/24

            // 月10
            ctrlList[9] = new ArrayList();
            ctrlList[9].AddRange(new object[] { Lb_Month10 });
            //ctrlList[9].AddRange(new object[] { to_uMonth10, uMonth10, bl_uMonth10, mk_uMonth10, em_uMonth10, cu_uMonth10, se_uMonth10 }); // DEL 2008/09/24
            //ctrlList[9].AddRange(new object[] { to_dMonth10, dMonth10, bl_dMonth10, mk_dMonth10, em_dMonth10, cu_dMonth10, se_dMonth10 }); // DEL 2008/09/24
            ctrlList[9].AddRange(new object[] { to_uMonth10, uMonth10, bl_uMonth10, mk_uMonth10, em_uMonth10, cu_uMonth10, se_uMonth10, su_uMonth10, mg_uMonth10, gr_uMonth10 }); // ADD 2008/09/24
            ctrlList[9].AddRange(new object[] { to_dMonth10, dMonth10, bl_dMonth10, mk_dMonth10, em_dMonth10, cu_dMonth10, se_dMonth10, su_dMonth10, mg_dMonth10, gr_dMonth10 }); // ADD 2008/09/24

            // 月11
            ctrlList[10] = new ArrayList();
            ctrlList[10].AddRange(new object[] { Lb_Month11 });
            //ctrlList[10].AddRange(new object[] { to_uMonth11, uMonth11, bl_uMonth11, mk_uMonth11, em_uMonth11, cu_uMonth11, se_uMonth11 }); // DEL 2008/09/24
            //ctrlList[10].AddRange(new object[] { to_dMonth11, dMonth11, bl_dMonth11, mk_dMonth11, em_dMonth11, cu_dMonth11, se_dMonth11 }); // DEL 2008/09/24
            ctrlList[10].AddRange(new object[] { to_uMonth11, uMonth11, bl_uMonth11, mk_uMonth11, em_uMonth11, cu_uMonth11, se_uMonth11, su_uMonth11, mg_uMonth11, gr_uMonth11 }); // ADD 2008/09/24
            ctrlList[10].AddRange(new object[] { to_dMonth11, dMonth11, bl_dMonth11, mk_dMonth11, em_dMonth11, cu_dMonth11, se_dMonth11, su_dMonth11, mg_dMonth11, gr_dMonth11 }); // ADD 2008/09/24

            // 月12
            ctrlList[11] = new ArrayList();
            ctrlList[11].AddRange(new object[] { Lb_Month12 });
            //ctrlList[11].AddRange(new object[] { to_uMonth12, uMonth12, bl_uMonth12, mk_uMonth12, em_uMonth12, cu_uMonth12, se_uMonth12 }); // DEL 2008/09/24
            //ctrlList[11].AddRange(new object[] { to_dMonth12, dMonth12, bl_dMonth12, mk_dMonth12, em_dMonth12, cu_dMonth12, se_dMonth12 }); // DEL 2008/09/24
            ctrlList[11].AddRange(new object[] { to_uMonth12, uMonth12, bl_uMonth12, mk_uMonth12, em_uMonth12, cu_uMonth12, se_uMonth12, su_uMonth12, mg_uMonth12, gr_uMonth12 }); // ADD 2008/09/24
            ctrlList[11].AddRange(new object[] { to_dMonth12, dMonth12, bl_dMonth12, mk_dMonth12, em_dMonth12, cu_dMonth12, se_dMonth12, su_dMonth12, mg_dMonth12, gr_dMonth12 }); // ADD 2008/09/24

            // 月タイトルリスト
            // (※注意：月タイトルラベルはこのリストにも、上記の月毎コントロールリストにも格納されます)
            List<Label> monthTitleList = new List<Label>();
            monthTitleList.AddRange(new Label[] { Lb_Month01, Lb_Month02, Lb_Month03, Lb_Month04, Lb_Month05, Lb_Month06, Lb_Month07, Lb_Month08, Lb_Month09, Lb_Month10, Lb_Month11, Lb_Month12 });

            #endregion

            // 月数の取得
            int monthRange = GetMonthRange(this._shipmGoodsOdrReport.SalesDateSt, this._shipmGoodsOdrReport.SalesDateEd);


            if ((monthRange > 12) || (monthRange <= 0))
            {
                monthRange = 12;
            }

            // 印字有無を設定
            for (int index = 0; index < ctrlList.Length; index++)
            {
                // 月タイトル設定
                if (index < monthTitleList.Count)
                {
                    monthTitleList[index].Text = GetMonthTitle(this._shipmGoodsOdrReport.SalesDateSt, index);
                }

                // 印字有無設定
                foreach (object ctrl in ctrlList[index])
                {
                    if (ctrl is TextBox)
                    {
                        (ctrl as TextBox).Visible = (index < monthRange);   // 範囲内のみtrue
                    }
                    else if (ctrl is Label)
                    {
                        (ctrl as Label).Visible = (index < monthRange);     // 範囲内のみtrue
                    }
                }
            }
            #endregion

            //-------------------------------------------------------
            // 印字タイプ（上段・下段）の適用
            //-------------------------------------------------------
            #region [印字タイプ（上段・下段）の適用]
            //0:数量,1:回数,2:金額,3:金額＆数量,4:金額＆回数,5:数量＆回数
            #region [作業用のリストを生成]
            // 上段項目リスト
            List<TextBox> uList = new List<TextBox>();
            uList.AddRange(new TextBox[] { uMonth01, uMonth02, uMonth03, uMonth04, uMonth05, uMonth06, uMonth07, uMonth08, uMonth09, uMonth10, uMonth11, uMonth12, uMonthTotal, uMonthAve });

            List<TextBox> bl_uList = new List<TextBox>();
            bl_uList.AddRange(new TextBox[] { bl_uMonth01, bl_uMonth02, bl_uMonth03, bl_uMonth04, bl_uMonth05, bl_uMonth06, bl_uMonth07, bl_uMonth08, bl_uMonth09, bl_uMonth10, bl_uMonth11, bl_uMonth12, bl_uMonthTotal, bl_uMonthAve });

            // --- DEL 2008/09/24 -------------------------------->>>>>
            //List<TextBox> go_uList = new List<TextBox>();
            //go_uList.AddRange(new TextBox[] { go_uMonth01, go_uMonth02, go_uMonth03, go_uMonth04, go_uMonth05, go_uMonth06, go_uMonth07, go_uMonth08, go_uMonth09, go_uMonth10, go_uMonth11, go_uMonth12, go_uMonthTotal, go_uMonthAve });
            // --- DEL 2008/09/24 --------------------------------<<<<<
            List<TextBox> mk_uList = new List<TextBox>();
            mk_uList.AddRange(new TextBox[] { mk_uMonth01, mk_uMonth02, mk_uMonth03, mk_uMonth04, mk_uMonth05, mk_uMonth06, mk_uMonth07, mk_uMonth08, mk_uMonth09, mk_uMonth10, mk_uMonth11, mk_uMonth12, mk_uMonthTotal, mk_uMonthAve });

            List<TextBox> em_uList = new List<TextBox>();
            em_uList.AddRange(new TextBox[] { em_uMonth01, em_uMonth02, em_uMonth03, em_uMonth04, em_uMonth05, em_uMonth06, em_uMonth07, em_uMonth08, em_uMonth09, em_uMonth10, em_uMonth11, em_uMonth12, em_uMonthTotal, em_uMonthAve });

            List<TextBox> cu_uList = new List<TextBox>();
            cu_uList.AddRange(new TextBox[] { cu_uMonth01, cu_uMonth02, cu_uMonth03, cu_uMonth04, cu_uMonth05, cu_uMonth06, cu_uMonth07, cu_uMonth08, cu_uMonth09, cu_uMonth10, cu_uMonth11, cu_uMonth12, cu_uMonthTotal, cu_uMonthAve });

            List<TextBox> se_uList = new List<TextBox>();
            se_uList.AddRange(new TextBox[] { se_uMonth01, se_uMonth02, se_uMonth03, se_uMonth04, se_uMonth05, se_uMonth06, se_uMonth07, se_uMonth08, se_uMonth09, se_uMonth10, se_uMonth11, se_uMonth12, se_uMonthTotal, se_uMonthAve });

            List<TextBox> to_uList = new List<TextBox>();
            to_uList.AddRange(new TextBox[] { to_uMonth01, to_uMonth02, to_uMonth03, to_uMonth04, to_uMonth05, to_uMonth06, to_uMonth07, to_uMonth08, to_uMonth09, to_uMonth10, to_uMonth11, to_uMonth12, to_uMonthTotal, to_uMonthAve });

            // --- ADD 2008/09/24 -------------------------------->>>>>
            List<TextBox> su_uList = new List<TextBox>();
            su_uList.AddRange(new TextBox[] { su_uMonth01, su_uMonth02, su_uMonth03, su_uMonth04, su_uMonth05, su_uMonth06, su_uMonth07, su_uMonth08, su_uMonth09, su_uMonth10, su_uMonth11, su_uMonth12, su_uMonthTotal, su_uMonthAve });

            List<TextBox> mg_uList = new List<TextBox>();
            mg_uList.AddRange(new TextBox[] { mg_uMonth01, mg_uMonth02, mg_uMonth03, mg_uMonth04, mg_uMonth05, mg_uMonth06, mg_uMonth07, mg_uMonth08, mg_uMonth09, mg_uMonth10, mg_uMonth11, mg_uMonth12, mg_uMonthTotal, mg_uMonthAve });

            List<TextBox> gr_uList = new List<TextBox>();
            gr_uList.AddRange(new TextBox[] { gr_uMonth01, gr_uMonth02, gr_uMonth03, gr_uMonth04, gr_uMonth05, gr_uMonth06, gr_uMonth07, gr_uMonth08, gr_uMonth09, gr_uMonth10, gr_uMonth11, gr_uMonth12, gr_uMonthTotal, gr_uMonthAve });
            // --- ADD 2008/09/24 --------------------------------<<<<<

            // 下段項目リスト
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { dMonth01, dMonth02, dMonth03, dMonth04, dMonth05, dMonth06, dMonth07, dMonth08, dMonth09, dMonth10, dMonth11, dMonth12, dMonthTotal, dMonthAve });

            List<TextBox> bl_dList = new List<TextBox>();
            bl_dList.AddRange(new TextBox[] { bl_dMonth01, bl_dMonth02, bl_dMonth03, bl_dMonth04, bl_dMonth05, bl_dMonth06, bl_dMonth07, bl_dMonth08, bl_dMonth09, bl_dMonth10, bl_dMonth11, bl_dMonth12, bl_dMonthTotal, bl_dMonthAve });

            // --- DEL 2008/09/24 -------------------------------->>>>>
            //List<TextBox> go_dList = new List<TextBox>();
            //go_dList.AddRange(new TextBox[] { go_dMonth01, go_dMonth02, go_dMonth03, go_dMonth04, go_dMonth05, go_dMonth06, go_dMonth07, go_dMonth08, go_dMonth09, go_dMonth10, go_dMonth11, go_dMonth12, go_dMonthTotal, go_dMonthAve });
            // --- DEL 2008/09/24 --------------------------------<<<<<

            List<TextBox> mk_dList = new List<TextBox>();
            mk_dList.AddRange(new TextBox[] { mk_dMonth01, mk_dMonth02, mk_dMonth03, mk_dMonth04, mk_dMonth05, mk_dMonth06, mk_dMonth07, mk_dMonth08, mk_dMonth09, mk_dMonth10, mk_dMonth11, mk_dMonth12, mk_dMonthTotal, mk_dMonthAve });

            List<TextBox> em_dList = new List<TextBox>();
            em_dList.AddRange(new TextBox[] { em_dMonth01, em_dMonth02, em_dMonth03, em_dMonth04, em_dMonth05, em_dMonth06, em_dMonth07, em_dMonth08, em_dMonth09, em_dMonth10, em_dMonth11, em_dMonth12, em_dMonthTotal, em_dMonthAve });

            List<TextBox> cu_dList = new List<TextBox>();
            cu_dList.AddRange(new TextBox[] { cu_dMonth01, cu_dMonth02, cu_dMonth03, cu_dMonth04, cu_dMonth05, cu_dMonth06, cu_dMonth07, cu_dMonth08, cu_dMonth09, cu_dMonth10, cu_dMonth11, cu_dMonth12, cu_dMonthTotal, cu_dMonthAve });

            List<TextBox> se_dList = new List<TextBox>();
            se_dList.AddRange(new TextBox[] { se_dMonth01, se_dMonth02, se_dMonth03, se_dMonth04, se_dMonth05, se_dMonth06, se_dMonth07, se_dMonth08, se_dMonth09, se_dMonth10, se_dMonth11, se_dMonth12, se_dMonthTotal, se_dMonthAve });

            List<TextBox> to_dList = new List<TextBox>();
            to_dList.AddRange(new TextBox[] { to_dMonth01, to_dMonth02, to_dMonth03, to_dMonth04, to_dMonth05, to_dMonth06, to_dMonth07, to_dMonth08, to_dMonth09, to_dMonth10, to_dMonth11, to_dMonth12, to_dMonthTotal, to_dMonthAve });

            // --- ADD 2008/09/24 -------------------------------->>>>>
            List<TextBox> su_dList = new List<TextBox>();
            su_dList.AddRange(new TextBox[] { su_dMonth01, su_dMonth02, su_dMonth03, su_dMonth04, su_dMonth05, su_dMonth06, su_dMonth07, su_dMonth08, su_dMonth09, su_dMonth10, su_dMonth11, su_dMonth12, su_dMonthTotal, su_dMonthAve });

            List<TextBox> mg_dList = new List<TextBox>();
            mg_dList.AddRange(new TextBox[] { mg_dMonth01, mg_dMonth02, mg_dMonth03, mg_dMonth04, mg_dMonth05, mg_dMonth06, mg_dMonth07, mg_dMonth08, mg_dMonth09, mg_dMonth10, mg_dMonth11, mg_dMonth12, mg_dMonthTotal, mg_dMonthAve });

            List<TextBox> gr_dList = new List<TextBox>();
            gr_dList.AddRange(new TextBox[] { gr_dMonth01, gr_dMonth02, gr_dMonth03, gr_dMonth04, gr_dMonth05, gr_dMonth06, gr_dMonth07, gr_dMonth08, gr_dMonth09, gr_dMonth10, gr_dMonth11, gr_dMonth12, gr_dMonthTotal, gr_dMonthAve });
            // --- ADD 2008/09/24 --------------------------------<<<<<

            #endregion

            // visible設定
            if ((this._shipmGoodsOdrReport.PrintType == 0)
            || (this._shipmGoodsOdrReport.PrintType == 1)
            || (this._shipmGoodsOdrReport.PrintType == 2))
            //|| (this._shipmGoodsOdrReport.PrintType == 6)) // DEL 2008/09/24
            {
                // 上段のみ　→　全ての下段を非印字にする
                for (int index = 0; index < dList.Count; index++)
                {
                    // 数量非印字
                    dList[index].Visible = false;
                    bl_dList[index].Visible = false;
                    //go_dList[index].Visible = false; // DEL 2008/09/24
                    mk_dList[index].Visible = false;
                    em_dList[index].Visible = false;
                    cu_dList[index].Visible = false;
                    se_dList[index].Visible = false;
                    to_dList[index].Visible = false;
                    su_dList[index].Visible = false; // ADD 2008/09/24
                    mg_dList[index].Visible = false; // ADD 2008/09/24
                    gr_dList[index].Visible = false; // ADD 2008/09/24
                }
            }
            else if ((this._shipmGoodsOdrReport.PrintType == 3)
            || (this._shipmGoodsOdrReport.PrintType == 4)
            || (this._shipmGoodsOdrReport.PrintType == 5))
            {
            }
            #endregion

            //-------------------------------------------------------
            // 印字Fieldの適用
            //-------------------------------------------------------
            #region [印字Fieldの適用]
            //0:数量,1:回数,2:金額,3:金額＆数量,4:金額＆回数,5:数量＆回数
            #region [作業用のリストを生成]
            //売上数計1(出荷数)
            List<string> TotalSalesCountList = new List<string>();
            TotalSalesCountList.AddRange(new string[] { "TotalSalesCount1", "TotalSalesCount2", "TotalSalesCount3", "TotalSalesCount4", "TotalSalesCount5", "TotalSalesCount6", "TotalSalesCount7", "TotalSalesCount8", "TotalSalesCount9", "TotalSalesCount10", "TotalSalesCount11", "TotalSalesCount12", "TotalSalesCountSum", "TotalSalesCountAve" });

            //売上回数1(出荷回数)
            List<string> SalesTimesList = new List<string>();
            SalesTimesList.AddRange(new string[] { "SalesTimes1", "SalesTimes2", "SalesTimes3", "SalesTimes4", "SalesTimes5", "SalesTimes6", "SalesTimes7", "SalesTimes8", "SalesTimes9", "SalesTimes10", "SalesTimes11", "SalesTimes12", "SalesTimesSum", "SalesTimesAve" });

            // --- ADD 2008/09/24 -------------------------------->>>>>
            //純売上合計1（税抜き）
            List<string> TotalProceedsList = new List<string>();
            TotalProceedsList.AddRange(new string[] { "SalesMoney1", "SalesMoney2", "SalesMoney3", "SalesMoney4", "SalesMoney5", "SalesMoney6", "SalesMoney7", "SalesMoney8", "SalesMoney9", "SalesMoney10", "SalesMoney11", "SalesMoney12", "SalesMoneySum", "SalesMoneyAve" });
            // --- ADD 2008/09/24 --------------------------------<<<<<

            // --- DEL 2008/09/24 -------------------------------->>>>>
            ////純売上合計1（税抜き）
            //List<string> TotalProceedsList = new List<string>();
            //TotalProceedsList.AddRange(new string[] {"TotalProceeds1","TotalProceeds2","TotalProceeds3","TotalProceeds4","TotalProceeds5","TotalProceeds6","TotalProceeds7","TotalProceeds8","TotalProceeds9","TotalProceeds10","TotalProceeds11","TotalProceeds12","TotalProceedsTotal","TotalProceedsAve" });

            ////粗利金額1
            //List<string> GrossProfitList = new List<string>();
            //GrossProfitList.AddRange(new string[] {"GrossProfit1","GrossProfit2","GrossProfit3","GrossProfit4","GrossProfit5","GrossProfit6","GrossProfit7","GrossProfit8","GrossProfit9","GrossProfit10","GrossProfit11","GrossProfit12","GrossProfitTotal","GrossProfitAve"});

            ////出荷平均ロット
            //List<string> AveLotList = new List<string>();
            //GrossProfitList.AddRange(new string[] {"AveLot1","AveLot2","AveLot3","AveLot4","AveLot5","AveLot6","AveLot7","AveLot8","AveLot9","AveLot10","AveLot11","AveLot12","AveLotTotal","AveLotAve"	});
            // --- DEL 2008/09/24 -------------------------------->>>>>

            #endregion

            switch (_shipmGoodsOdrReport.PrintType)
            {
                //0:数量
                case 0:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = TotalSalesCountList[index];
                        bl_uList[index].DataField = TotalSalesCountList[index];
                        //go_uList[index].DataField = TotalSalesCountList[index]; // DEL 2008/09/24
                        mk_uList[index].DataField = TotalSalesCountList[index];
                        em_uList[index].DataField = TotalSalesCountList[index];
                        cu_uList[index].DataField = TotalSalesCountList[index];
                        se_uList[index].DataField = TotalSalesCountList[index];
                        to_uList[index].DataField = TotalSalesCountList[index];
                        su_uList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                        mg_uList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                        gr_uList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = "";
                        bl_dList[index].DataField = "";
                        //go_dList[index].DataField = ""; // DEL 2008/09/24
                        mk_dList[index].DataField = "";
                        em_dList[index].DataField = "";
                        cu_dList[index].DataField = "";
                        se_dList[index].DataField = "";
                        to_dList[index].DataField = "";
                        su_dList[index].DataField = ""; // ADD 2008/09/24
                        mg_dList[index].DataField = ""; // ADD 2008/09/24
                        gr_dList[index].DataField = ""; // ADD 2008/09/24
                    }
                    break;
                //1:回数
                case 1:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = SalesTimesList[index];
                        bl_uList[index].DataField = SalesTimesList[index];
                        //go_uList[index].DataField = SalesTimesList[index]; // DEL 2008/09/24
                        mk_uList[index].DataField = SalesTimesList[index];
                        em_uList[index].DataField = SalesTimesList[index];
                        cu_uList[index].DataField = SalesTimesList[index];
                        se_uList[index].DataField = SalesTimesList[index];
                        to_uList[index].DataField = SalesTimesList[index];
                        su_uList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                        mg_uList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                        gr_uList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = "";
                        bl_dList[index].DataField = "";
                        //go_dList[index].DataField = ""; // DEL 2008/09/24
                        mk_dList[index].DataField = "";
                        em_dList[index].DataField = "";
                        cu_dList[index].DataField = "";
                        se_dList[index].DataField = "";
                        to_dList[index].DataField = "";
                        su_dList[index].DataField = ""; // ADD 2008/09/24
                        mg_dList[index].DataField = ""; // ADD 2008/09/24
                        gr_dList[index].DataField = ""; // ADD 2008/09/24
                    }
                    break;
                //2:金額
                case 2:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = TotalProceedsList[index];
                        bl_uList[index].DataField = TotalProceedsList[index];
                        //go_uList[index].DataField = TotalProceedsList[index]; // DEL 2008/09/24
                        mk_uList[index].DataField = TotalProceedsList[index];
                        em_uList[index].DataField = TotalProceedsList[index];
                        cu_uList[index].DataField = TotalProceedsList[index];
                        se_uList[index].DataField = TotalProceedsList[index];
                        to_uList[index].DataField = TotalProceedsList[index];
                        su_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                        mg_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                        gr_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = "";
                        bl_dList[index].DataField = "";
                        //go_dList[index].DataField = ""; // DEL 2008/09/24
                        mk_dList[index].DataField = "";
                        em_dList[index].DataField = "";
                        cu_dList[index].DataField = "";
                        se_dList[index].DataField = "";
                        to_dList[index].DataField = "";
                        su_dList[index].DataField = ""; // ADD 2008/09/24
                        mg_dList[index].DataField = ""; // ADD 2008/09/24
                        gr_dList[index].DataField = ""; // ADD 2008/09/24
                    }
                    break;
                //3:金額＆数量
                case 3:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = TotalProceedsList[index];
                        bl_uList[index].DataField = TotalProceedsList[index];
                        //go_uList[index].DataField = TotalProceedsList[index]; // DEL 2008/09/24
                        mk_uList[index].DataField = TotalProceedsList[index];
                        em_uList[index].DataField = TotalProceedsList[index];
                        cu_uList[index].DataField = TotalProceedsList[index];
                        se_uList[index].DataField = TotalProceedsList[index];
                        to_uList[index].DataField = TotalProceedsList[index];
                        su_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                        mg_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                        gr_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = TotalSalesCountList[index];
                        bl_dList[index].DataField = TotalSalesCountList[index];
                        //go_dList[index].DataField = TotalSalesCountList[index]; // DEL 2008/09/24
                        mk_dList[index].DataField = TotalSalesCountList[index];
                        em_dList[index].DataField = TotalSalesCountList[index];
                        cu_dList[index].DataField = TotalSalesCountList[index];
                        se_dList[index].DataField = TotalSalesCountList[index];
                        to_dList[index].DataField = TotalSalesCountList[index];
                        su_dList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                        mg_dList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                        gr_dList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                    }
                    break;
                //4:金額＆回数
                case 4:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = TotalProceedsList[index];
                        bl_uList[index].DataField = TotalProceedsList[index];
                        //go_uList[index].DataField = TotalProceedsList[index]; // DEL 2008/09/24
                        mk_uList[index].DataField = TotalProceedsList[index];
                        em_uList[index].DataField = TotalProceedsList[index];
                        cu_uList[index].DataField = TotalProceedsList[index];
                        se_uList[index].DataField = TotalProceedsList[index];
                        to_uList[index].DataField = TotalProceedsList[index];
                        su_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                        mg_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                        gr_uList[index].DataField = TotalProceedsList[index]; // ADD 2008/09/24
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = SalesTimesList[index];
                        bl_dList[index].DataField = SalesTimesList[index];
                        //go_dList[index].DataField = SalesTimesList[index]; // DEL 2008/09/24
                        mk_dList[index].DataField = SalesTimesList[index];
                        em_dList[index].DataField = SalesTimesList[index];
                        cu_dList[index].DataField = SalesTimesList[index];
                        se_dList[index].DataField = SalesTimesList[index];
                        to_dList[index].DataField = SalesTimesList[index];
                        su_dList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                        mg_dList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                        gr_dList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                    }
                    break;
                //5:数量＆回数
                case 5:
                    //上段
                    for (int index = 0; index < uList.Count; index++)
                    {
                        uList[index].DataField = TotalSalesCountList[index];
                        bl_uList[index].DataField = TotalSalesCountList[index];
                        //go_uList[index].DataField = TotalSalesCountList[index]; // DEL 2008/09/24
                        mk_uList[index].DataField = TotalSalesCountList[index];
                        em_uList[index].DataField = TotalSalesCountList[index];
                        cu_uList[index].DataField = TotalSalesCountList[index];
                        se_uList[index].DataField = TotalSalesCountList[index];
                        to_uList[index].DataField = TotalSalesCountList[index];
                        su_uList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                        mg_uList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                        gr_uList[index].DataField = TotalSalesCountList[index]; // ADD 2008/09/24
                    }
                    //下段
                    for (int index = 0; index < dList.Count; index++)
                    {
                        dList[index].DataField = SalesTimesList[index];
                        bl_dList[index].DataField = SalesTimesList[index];
                        //go_dList[index].DataField = SalesTimesList[index]; // DEL 2008/09/24
                        mk_dList[index].DataField = SalesTimesList[index];
                        em_dList[index].DataField = SalesTimesList[index];
                        cu_dList[index].DataField = SalesTimesList[index];
                        se_dList[index].DataField = SalesTimesList[index];
                        to_dList[index].DataField = SalesTimesList[index];
                        su_dList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                        mg_dList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                        gr_dList[index].DataField = SalesTimesList[index]; // ADD 2008/09/24
                    }
                    break;
                // --- DEL 2008/09/24 -------------------------------->>>>>
                ////6:出荷平均ロット
                //case 6:
                //    //上段
                //    for (int index = 0; index < uList.Count; index++)
                //    {
                //        uList[index].DataField = GrossProfitList[index];
                //        bl_uList[index].DataField = GrossProfitList[index];
                //        go_uList[index].DataField = GrossProfitList[index];
                //        mk_uList[index].DataField = GrossProfitList[index];
                //        em_uList[index].DataField = GrossProfitList[index];
                //        cu_uList[index].DataField = GrossProfitList[index];
                //        se_uList[index].DataField = GrossProfitList[index];
                //        to_uList[index].DataField = GrossProfitList[index];
                //    }
                //    //下段
                //    for (int index = 0; index < dList.Count; index++)
                //    {
                //        dList[index].DataField = "";
                //        bl_dList[index].DataField = "";
                //        go_dList[index].DataField = "";
                //        mk_dList[index].DataField = "";
                //        em_dList[index].DataField = "";
                //        cu_dList[index].DataField = "";
                //        se_dList[index].DataField = "";
                //        to_dList[index].DataField = "";
                //    }
                //    break;
                // --- DEL 2008/09/24 -------------------------------->>>>>
            }

            #endregion

            //-------------------------------------------------------
            // 印字商品名の設定
            //-------------------------------------------------------
            #region [印字商品名の設定]
            //印字商品名の設定
            //0:商品別 2:得意先別 3:担当者別
            if (_shipmGoodsOdrReport.TotalType == 0)
            //(_shipmGoodsOdrReport.TotalType == 2) && _shipmGoodsOdrReport.Detail == 0) // DEL 2008/10/30
            {
                //商品
                //Lb_BLGoodsCode.Text = "商品コード"; // DEL 2008/09/24
                //Lb_BLGoodsHalfName.Text = "商品名"; // DEL 2008/09/24
                Lb_BLGoodsCode.Text = "品番"; // ADD 2008/09/24
                Lb_BLGoodsHalfName.Text = "品名"; // ADD 2008/09/24
                BLGoodsCode.DataField = "GoodsNo";
                BLGoodsHalfName.DataField = "GoodsName";

                Lb_BLGroupCode.Text = "BLｺｰﾄﾞ"; // ADD 2008/10/30
                BLGroupCode.DataField = "BLGoodsCode"; // ADD 2008/10/30
                BLGroupCode.OutputFormat = "00000"; // ADD 2008/10/30
            }
            // --- ADD 2008/10/30 -------------------------------->>>>>
            else if (_shipmGoodsOdrReport.TotalType == 2
                && _shipmGoodsOdrReport.Detail == 0)
            {
                // 得意先別、品番
                Lb_BLGoodsCode.Text = "品番"; // ADD 2008/09/24
                Lb_BLGoodsHalfName.Text = "品名"; // ADD 2008/09/24
                BLGoodsCode.DataField = "GoodsNo";
                BLGoodsHalfName.DataField = "GoodsName";

                Lb_BLGroupCode.Text = "ｸﾞﾙｰﾌﾟ"; // ADD 2008/10/30
                BLGroupCode.DataField = "BLGroupCode"; // ADD 2008/10/30
                BLGroupCode.OutputFormat = "00000"; // ADD 2008/10/30
            }
            // --- ADD 2008/10/30 --------------------------------<<<<<
            else if (_shipmGoodsOdrReport.TotalType == 2
                && _shipmGoodsOdrReport.Detail == 1)
            {
                // --- DEL 2008/10/30 -------------------------------->>>>>
                //Lb_BLGoodsCode.Text = "グループコード"; // ADD 2008/09/24
                //Lb_BLGoodsHalfName.Text = "グループコード名称"; // ADD 2008/09/24
                //BLGoodsCode.DataField = "BLGroupCode";
                //BLGoodsCode.OutputFormat = "00000";
                //BLGoodsHalfName.DataField = "BLGroupKanaName";
                // --- DEL 2008/10/30 --------------------------------<<<<<
                // --- ADD 2008/10/30 -------------------------------->>>>>
                // 項目ヘッダ部
                Lb_BLGoodsCode.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                Lb_BLGoodsHalfName.Visible = false;
                Lb_BLGroupCode.Visible = false;
                Lb_MakerName.Location = new PointF(1.875F, 0.01F);

                BLGoodsCode.Visible = false;
                BLGoodsHalfName.Visible = false;
                BLGroupKanaName.Visible = true;
                MakerName.Visible = true;

                // 明細部
                PointF point = BLGoodsCode.Location;
                BLGroupCode.Location = point;

                point.X += BLGroupCode.Width;
                BLGroupKanaName.Location = point;

                GoodsMakerCd.Location = new PointF(1.875F, 0.063F);
                point.X = GoodsMakerCd.Location.X + GoodsMakerCd.Width;

                MakerName.Location = point;

                BLGroupCode.DataField = "BLGroupCode";
                BLGroupCode.OutputFormat = "00000";
                BLGroupKanaName.DataField = "BLGroupKanaName";

                // フッタ
                subTotalMaker_GoodsMakerCd.Visible = false;
                subTotalMaker_MakerShortName.Visible = false;
                // --- ADD 2008/10/30 --------------------------------<<<<<
            }
            else
            {
                // 担当者別
                //BL商品
                //Lb_BLGoodsCode.Text = "BL商品"; // DEL 2008/09/24
                //Lb_BLGoodsHalfName.Text = "BL商品名"; // DEL 2008/09/24
                // --- DEL 2008/10/30 -------------------------------->>>>>
                //Lb_BLGoodsCode.Text = "BLコード"; // ADD 2008/09/24
                //Lb_BLGoodsHalfName.Text = "BLコード名称"; // ADD 2008/09/24

                //BLGoodsCode.DataField = "BLGoodsCode";
                //BLGoodsCode.OutputFormat = "00000";
                //BLGoodsHalfName.DataField = "BLGoodsHalfName";
                // --- DEL 2008/10/30 --------------------------------<<<<<
                // --- ADD 2008/10/30 -------------------------------->>>>>
                Lb_BLGoodsCode.Text = "BLｺｰﾄﾞ";
                Lb_BLGoodsHalfName.Visible = false;
                Lb_BLGroupCode.Visible = false;
                Lb_MakerName.Location = new PointF(1.875F, 0.01F);

                BLGoodsCode.Visible = false;
                BLGoodsHalfName.Visible = false;
                BLGroupKanaName.Visible = true;
                MakerName.Visible = true;

                // 明細部
                PointF point = BLGoodsCode.Location;
                BLGroupCode.Location = point;

                point.X += BLGroupCode.Width;
                BLGroupKanaName.Location = point;

                GoodsMakerCd.Location = new PointF(1.875F, 0.063F);
                point.X = GoodsMakerCd.Location.X + GoodsMakerCd.Width;

                MakerName.Location = point;

                BLGroupCode.DataField = "BLGoodsCode";
                BLGroupCode.OutputFormat = "00000";
                BLGroupKanaName.DataField = "BLGoodsHalfName";

                // フッタ
                subTotalMaker_GoodsMakerCd.Visible = false;
                subTotalMaker_MakerShortName.Visible = false;
                // --- ADD 2008/10/30 --------------------------------<<<<<
            }
            #endregion

            //-------------------------------------------------------
            // 小計印刷設定
            //-------------------------------------------------------
            #region [小計印刷設定]
            //小計印刷
            //小計印刷(拠点)
            // --- DEL 2008/09/24 -------------------------------->>>>>
            //if (_shipmGoodsOdrReport.SubtotalSection != 0)
            //{
            //    //Heder
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    // 改頁
            //    if (_shipmGoodsOdrReport.CrMode == 1)
            //    {
            //        SectionHeader.NewPage = NewPage.Before;
            //    }
            //    else
            //    {
            //        SectionHeader.NewPage = NewPage.None;
            //    }

            //    //Footer
            //    SectionFooter.Visible = true;
            //}
            //else
            //{
            //    //Heder
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionHeader.NewPage = NewPage.None;
            //    //Footer
            //    SectionFooter.Visible = false;
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<

            //小計印刷(拠点)
            // Header
            SectionHeader.DataField = "SectionHeaderField";
            SectionHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalSection != 0)
            {
                SectionFooter.Visible = true;
            }
            else
            {
                SectionFooter.Visible = false;
            }
            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 小計印刷(仕入先)
            // Header
            SuplierHeader.DataField = "SuplierField";
            SuplierHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalSupplier != 0)
            {
                SuplierFooter.Visible = true;
            }
            else
            {
                SuplierFooter.Visible = false;
            }
            
            // --- ADD 2008/09/24 --------------------------------<<<<<
            // --- DEL 2008/09/24 -------------------------------->>>>>
            //小計印刷(メーカー)
            //if (_shipmGoodsOdrReport.SubtotalMaker != 0)
            //{
            //    //Heder
            //    MakerHeader.DataField = "MakerField";
            //    MakerHeader.Visible = true;
            //    MakerHeader.NewPage = NewPage.None;

            //    //Footer
            //    MakerFooter.Visible = true;
            //}
            //else
            //{
            //    //Heder
            //    MakerHeader.DataField = "";
            //    MakerHeader.Visible = false;
            //    MakerHeader.NewPage = NewPage.None;
            //    //Footer
            //    MakerFooter.Visible = false;
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<
            //小計印刷(メーカー)
            // Header
            MakerHeader.DataField = "MakerField";
            MakerHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalMaker != 0)
            {
                MakerFooter.Visible = true;
            }
            else
            {
                MakerFooter.Visible = false;
            }

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 小計印刷(商品中分類)
            // Header
            GoodsMGroupHeader.DataField = "GoodsMGroupField";
            GoodsMGroupHeader.Visible = true;

            if (_shipmGoodsOdrReport.SubtotalGoodsMGroup != 0)
            {
                GoodsMGroupFooter.Visible = true;
            }
            else
            {
                GoodsMGroupFooter.Visible = false;
            }

            // 小計印刷(グループコード)
            // Heder
            BLGroupHeader.DataField = "BLGroupField";
            BLGroupHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalGroupCode != 0)
            {
                BLGroupFooter.Visible = true;
            }
            else
            {
                BLGroupFooter.Visible = false;
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

            // --- DEL 2008/09/24 -------------------------------->>>>>
            ////小計印刷(商品区分)
            //if (_shipmGoodsOdrReport.SubtotalGoods != 0)
            //{
            //    //Heder
            //    DailyHeader.DataField = "GoodsField";
            //    DailyHeader.Visible = true;
            //    DailyHeader.NewPage = NewPage.None;
            //    //Footer
            //    DailyFooter.Visible = true;
            //}
            //else
            //{
            //    //Heder
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyHeader.NewPage = NewPage.None;
            //    //Footer
            //    DailyFooter.Visible = false;
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<

            // 小計印刷(BLコード)
            // Header
            BLGoodsHeader.DataField = "BLGoodsField";
            BLGoodsHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalBl != 0)
            {
                BLGoodsFooter.Visible = true;
            }
            else
            {
                BLGoodsFooter.Visible = false;
            }

            // 小計印刷(得意先)
            // Header
            CustomerHeader.DataField = "CustomerField";
            CustomerHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalCustomer != 0)
            {
                CustomerFooter.Visible = true;
            }
            else
            {
                CustomerFooter.Visible = false;
            }
            
            // 小計印刷(担当者)
            // Header
            SalesEmployeeHeader.DataField = "SalesEmployeeField";
            SalesEmployeeHeader.Visible = true;

            // Footer
            if (_shipmGoodsOdrReport.SubtotalSalesEmployee != 0)
            {
                //Footer
                SalesEmployeeFooter.Visible = true;
            }
            else
            {
                SalesEmployeeFooter.Visible = false;
            }
            #endregion

            //-------------------------------------------------------
            // 改頁設定
            // 0:なし 1:拠点 2:得意先 3:担当者 4:仕入先
            //-------------------------------------------------------
            #region [改頁設定]
            switch (_shipmGoodsOdrReport.CrMode)
            {
                case 1:
                    {
                        SectionHeader.NewPage = NewPage.Before;
                        break;
                    }
                case 2:
                    {
                        CustomerHeader.NewPage = NewPage.Before;
                        break;
                    }
                case 3:
                    {
                        SalesEmployeeHeader.NewPage = NewPage.Before;
                        break;
                    }
                case 4:
                    {
                        SuplierHeader.NewPage = NewPage.Before;
                        break;
                    }
            }
            #endregion

            // --- ADD 2008/09/24 -------------------------------->>>>>
            //-------------------------------------------------------
            // 明細ヘッダ
            //-------------------------------------------------------
            #region [明細ヘッダ設定]
            // --- DEL 2008/10/30 -------------------------------->>>>>
            //// 位置設定
            //this.CustomerCode_textBox.Location = this.SupplierCd_textbox.Location;
            //this.CustomerSnm_textBox.Location = this.SupplierNm_textBox.Location;
            //this.EmployeeCode_textBox.Location = this.SupplierCd_textbox.Location;
            //this.EmployeeName_textBox.Location = this.SupplierNm_textBox.Location;

            //this.BLGroupCode_textBox.Location = this.GoodsMGroup_textBox.Location;

            //if (_shipmGoodsOdrReport.TotalType == 0)
            //{
            //    switch (_shipmGoodsOdrReport.Detail)
            //    {
            //        //case 1: // メーカー＋商品中分類＋ＢＬコード＋品番
            //        //    {
            //        //        // 仕入先を非表示
            //        //        this.suplier_label.Visible = false;
            //        //        this.SupplierCd_textbox = false;
            //        //        this.SupplierNm_textBox = false;

            //        //        // 位置調整
            //        //        this.BLGoodsCode_label.Location = this.goodsMGroup_label.Location;
            //        //        this.BLGoodsCode_textBox.Location = this.GoodsMGroup_textBox.Location;

            //        //        this.goodsMGroup_label.Location = this.maker_label.Location;
            //        //        this.GoodsMGroup_textBox.Location = this.MakerCd_textBox.Location;

            //        //        this.maker_label.Location = this.suplier_label.Location;
            //        //        this.MakerCd_textBox.Location = this.SupplierCd_textbox.Location;
            //        //        this.MakerName_textBox.Location = this.SupplierNm_textBox.Location;

            //        //        break;
            //        //    }
            //        case 2: // 仕入先＋メーカー＋品番
            //        case 3: // メーカー＋品番
            //            {
            //                // メーカー以下は誤表示となるため、商品中分類、ＢＬコードを非表示
            //                this.goodsMGroup_label.Visible = false;
            //                this.GoodsMGroup_textBox.Visible = false;

            //                this.BLGoodsCode_label.Visible = false;
            //                this.BLGoodsCode_textBox.Visible = false;

            //                break;
            //            }
            //            //{
            //            //    // 仕入先、商品中分類、ＢＬコードを非表示
            //            //    //this.suplier_label.Visible = false;
            //            //    //this.SupplierCd_textbox = false;
            //            //    //this.SupplierNm_textBox = false;

            //            //    this.goodsMGroup_label.Visible = false;
            //            //    this.GoodsMGroup_textBox.Visible = false;

            //            //    this.BLGoodsCode_label.Visible = false;
            //            //    this.BLGoodsCode_textBox.Visible = false;

            //            //    // 位置調整
            //            //    this.maker_label.Location = this.suplier_label.Location;
            //            //    this.MakerCd_textBox.Location = this.SupplierCd_textbox.Location;
            //            //    this.MakerName_textBox.Location = this.SupplierNm_textBox.Location;

            //            //    break;
            //            //}
            //        case 4: // メーカー＋商品中分類＋品番
            //            {
            //                // 仕入先、ＢＬコードを非表示
            //                //this.suplier_label.Visible = false;
            //                //this.SupplierCd_textbox = false;
            //                //this.SupplierNm_textBox = false;

            //                this.BLGoodsCode_label.Visible = false;
            //                this.BLGoodsCode_textBox.Visible = false;

            //                //// 位置調整
            //                //this.BLGoodsCode_label.Location = this.maker_label.Location;
            //                //this.BLGoodsCode_textBox.Location = this.MakerCd_textBox.Location;

            //                //this.maker_label.Location = this.suplier_label.Location;
            //                //this.MakerCd_textBox.Location = this.SupplierCd_textbox.Location;
            //                //this.MakerName_textBox.Location = this.SupplierNm_textBox.Location;

            //                break;
            //            }

            //    }
            //}
            //else if (_shipmGoodsOdrReport.TotalType == 2)
            //{
            //    // 得意先別
            //    // 得意先コードを表示
            //    this.SupplierCd_textbox.Visible = false;
            //    this.SupplierNm_textBox.Visible = false;
            //    this.CustomerCode_textBox.Visible = true;
            //    this.CustomerSnm_textBox.Visible = true;
            //    this.suplier_label.Text = "得意先";

            //    // グループコードを表示
            //    this.GoodsMGroup_textBox.Visible = false;

            //    if (_shipmGoodsOdrReport.Detail == 0) // 明細単位 品番
            //    {
            //        this.BLGroupCode_textBox.Visible = true;

            //        this.goodsMGroup_label.Text = "グループコード";
            //    }
            //    else
            //    {
            //        this.goodsMGroup_label.Visible = false;
            //    }

            //    this.BLGoodsCode_label.Visible = false;
            //    this.BLGoodsCode_textBox.Visible = false;
            //}
            //else if (_shipmGoodsOdrReport.TotalType == 3)
            //{
            //    // 担当者別
            //    // 担当者コードを表示
            //    this.SupplierCd_textbox.Visible = false;
            //    this.SupplierNm_textBox.Visible = false;
            //    this.EmployeeCode_textBox.Visible = true;
            //    this.EmployeeName_textBox.Visible = true;
            //    this.suplier_label.Text = "担当者";

            //    this.goodsMGroup_label.Visible = false;
            //    this.GoodsMGroup_textBox.Visible = false;

            //    this.BLGoodsCode_label.Visible = false;
            //    this.BLGoodsCode_textBox.Visible = false;
            //}
            // --- DEL 2008/10/30 --------------------------------<<<<<
            // --- ADD 2008/10/30 -------------------------------->>>>>
            //0:商品別 2:得意先別 3:担当者別
            if (_shipmGoodsOdrReport.TotalType == 0)
            {
                this.CustomerHeader.Visible = false;
                this.SalesEmployeeHeader.Visible = false;
            }
            else if (_shipmGoodsOdrReport.TotalType == 2)
            {
                this.SuplierHeader.Visible = false;
                this.SalesEmployeeHeader.Visible = false;
            }
            else if (_shipmGoodsOdrReport.TotalType == 3)
            {
                this.SuplierHeader.Visible = false;
                this.CustomerHeader.Visible = false;
            }
            // --- ADD 2008/10/30 --------------------------------<<<<<
            // --- ADD 2008/12/11 -------------------------------->>>>>
            // 集計方法による明細ヘッダ表示制御
            if (this._shipmGoodsOdrReport.TtlType == 0) // 全社
            {
                PointF point = new PointF();

                // Supplierヘッダ
                this.SupHd_SectionTitle.Visible = false;
                this.SupHd_SectionCode.Visible = false;
                this.SupHd_SectionName.Visible = false;

                this.SupHd_SupplierTitle.Location = this.SupHd_SectionTitle.Location;
                point = this.SupHd_SupplierTitle.Location;

                point.X += this.SupHd_SupplierTitle.Width + 0.05F;
                this.SupHd_SupplierCode.Location = point;

                point.X += this.SupHd_SupplierCode.Width;
                this.SupHd_SupplierName.Location = point;

                // Customerヘッダ
                this.CusHd_SectionTitle.Visible = false;
                this.CusHd_SectionCode.Visible = false;
                this.CusHd_SectionName.Visible = false;

                this.CusHd_CustomerTitle.Location = this.CusHd_SectionTitle.Location;
                point = this.CusHd_CustomerTitle.Location;

                point.X += this.CusHd_CustomerTitle.Width + 0.05F;
                this.CusHd_CustomerCode.Location = point;

                point.X += this.CusHd_CustomerCode.Width;
                this.CusHd_CustomerName.Location = point;

                // SalesEmployeeヘッダ
                this.EmpHd_SectionTitle.Visible = false;
                this.EmpHd_SectionCode.Visible = false;
                this.EmpHd_SectionName.Visible = false;

                this.EmpHd_EmployeeTitle.Location = this.EmpHd_SectionTitle.Location;
                point = this.EmpHd_EmployeeTitle.Location;

                point.X += this.EmpHd_EmployeeTitle.Width + 0.05F;
                this.EmpHd_EmployeeCode.Location = point;

                point.X += this.EmpHd_EmployeeCode.Width;
                this.EmpHd_EmployeeName.Location = point;

            }
            // --- ADD 2008/12/11 --------------------------------<<<<<
            #endregion
            // --- ADD 2008/09/24 --------------------------------<<<<<

            //-------------------------------------------------------
            // 集計単位設定
            //-------------------------------------------------------
            // 明細単位での制御は必要ないので削除
            //（明細単位で"選択できる小計印刷"を制御している）
            #region [集計単位設定]
            /* --- DEL 2008/09/24 -------------------------------->>>>>
			//0:商品別 2:得意先別 3:担当者別
			switch (this._shipmGoodsOdrReport.TotalType)
			{
				//0:商品別
				case 0:
					//明細単位
					switch (_shipmGoodsOdrReport.Detail)
					{
						//0:メーカーコード＋商品中分類＋ＢＬコード＋品番
						case 0:
                            //仕入先計
                            //Heder
                            SuplierHeader.DataField = "SuplierField";
                            SuplierHeader.Visible = true;
                            SuplierHeader.NewPage = NewPage.None;

							//メーカー計
							//Heder
							MakerHeader.DataField = "MakerField";
							MakerHeader.Visible = true;
							MakerHeader.NewPage = NewPage.None;

                            // --- DEL 2008/09/24 -------------------------------->>>>>
                            ////商品区分計
                            ////Heder
                            //DailyHeader.DataField = "GoodsField";
                            //DailyHeader.Visible = true;
                            //DailyHeader.NewPage = NewPage.None;
                            // --- DEL 2008/09/24 --------------------------------<<<<<

                            // 商品中分類計
                            GoodsMGroupHeader.DataField = "GoodsMGroupField";
                            GoodsMGroupHeader.Visible = true;
                            GoodsMGroupHeader.NewPage = NewPage.None;

							//ＢＬコード計
							//Heder
                            BLGoodsHeader.DataField = "BLGoodsField";
							BLGoodsHeader.Visible = true;
							BLGoodsHeader.NewPage = NewPage.None;
							break;
						//1:メーカー＋商品中分類＋ＢＬコード＋商品コード
						case 1:
                            //仕入先計
                            //Heder
                            SuplierHeader.DataField = "";
                            SuplierHeader.Visible = false;
                            SuplierHeader.NewPage = NewPage.None;
                            SuplierFooter.Visible = false;

                            //メーカー計
                            //Heder
                            MakerHeader.DataField = "MakerField";
                            MakerHeader.Visible = true;
                            MakerHeader.NewPage = NewPage.None;
							//メーカー計
							//Heder
							MakerHeader.DataField = "";
							MakerHeader.Visible = false;
							MakerHeader.NewPage = NewPage.None;
							MakerFooter.Visible = false;

                            // --- DEL 2008/09/24 -------------------------------->>>>>
                            ////商品区分計
                            ////Heder
                            //DailyHeader.DataField = "GoodsField";
                            //DailyHeader.Visible = true;
                            //DailyHeader.NewPage = NewPage.None;
                            // --- DEL 2008/09/24 --------------------------------<<<<<

							//ＢＬコード計
							//Heder
							BLGoodsHeader.DataField = "BlField";
							BLGoodsHeader.Visible = true;
							BLGoodsHeader.NewPage = NewPage.None;
							break;
						//2:メーカーコード＋商品コード
						case 2:
							//メーカー計
							//Heder
							MakerHeader.DataField = "MakerField";
							MakerHeader.Visible = true;
							MakerHeader.NewPage = NewPage.None;

                            // --- DEL 2008/09/24 -------------------------------->>>>>
                            ////商品区分計
                            ////Heder
                            //DailyHeader.DataField = "";
                            //DailyHeader.Visible = false;
                            //DailyHeader.NewPage = NewPage.None;
                            ////Footer
                            //DailyFooter.Visible = false;
                            // --- DEL 2008/09/24 --------------------------------<<<<<

							//ＢＬコード計
							//Heder
							BLGoodsHeader.DataField = "";
							BLGoodsHeader.Visible = false;
							BLGoodsHeader.NewPage = NewPage.None;
							//Footer
							BLGoodsFooter.Visible = false;
							break;
						//3:商品区分コード＋商品コード
						case 3:
							//メーカー計
							//Heder
							MakerHeader.DataField = "";
							MakerHeader.Visible = false;
							MakerHeader.NewPage = NewPage.None;
							MakerFooter.Visible = false;

                            // --- DEL 2008/09/24 -------------------------------->>>>>
                            ////商品区分計
                            ////Heder
                            //DailyHeader.DataField = "GoodsField";
                            //DailyHeader.Visible = true;
                            //DailyHeader.NewPage = NewPage.None;
                            // --- DEL 2008/09/24 --------------------------------<<<<<

							//ＢＬコード計
							//Heder
							BLGoodsHeader.DataField = "";
							BLGoodsHeader.Visible = false;
							BLGoodsHeader.NewPage = NewPage.None;
							//Footer
							BLGoodsFooter.Visible = false;
							break;
						//4:商品コード
						case 4:
							//メーカー計
							//Heder
							MakerHeader.DataField = "";
							MakerHeader.Visible = false;
							MakerHeader.NewPage = NewPage.None;
							MakerFooter.Visible = false;

                            // --- DEL 2008/09/24 -------------------------------->>>>>
                            ////商品区分計
                            ////Heder
                            //DailyHeader.DataField = "";
                            //DailyHeader.Visible = false;
                            //DailyHeader.NewPage = NewPage.None;
                            ////Footer
                            //DailyFooter.Visible = false;
                            // --- DEL 2008/09/24 -------------------------------->>>>>

							//ＢＬコード計
							//Heder
							BLGoodsHeader.DataField = "";
							BLGoodsHeader.Visible = false;
							BLGoodsHeader.NewPage = NewPage.None;
							//Footer
							BLGoodsFooter.Visible = false;
							break;
					}

					//得意先計
					//Heder
					CustomerHeader.DataField = "";
					CustomerHeader.Visible = false;
					CustomerHeader.NewPage = NewPage.None;
					//Footer
					CustomerFooter.Visible = false;

					//担当者計
					//Heder
					SalesEmployeeHeader.DataField = "";
					SalesEmployeeHeader.Visible = false;
					SalesEmployeeHeader.NewPage = NewPage.None;
					//Footer
					SalesEmployeeFooter.Visible = false;

					break;
				//1:得意先別
				case 1:
					//得意先計
					//Heder
					CustomerHeader.DataField = "CustomerField";
					CustomerHeader.Visible = true;
					CustomerHeader.NewPage = NewPage.None;

					//メーカー計
					//Heder
					MakerHeader.DataField = "MakerField";
					//MakerHeader.Visible = true;
					MakerHeader.NewPage = NewPage.None;

                    // --- DEL 2008/09/24 -------------------------------->>>>>
                    ////商品区分計
                    ////Heder
                    //DailyHeader.DataField = "";
                    //DailyHeader.Visible = false;
                    //DailyHeader.NewPage = NewPage.None;
                    ////Footer
                    //DailyFooter.Visible = false;
                    // --- DEL 2008/09/24 --------------------------------<<<<<

					//ＢＬコード計
					//Heder
					BLGoodsHeader.DataField = "";
					BLGoodsHeader.Visible = false;
					BLGoodsHeader.NewPage = NewPage.None;
					//Footer
					BLGoodsFooter.Visible = false;

					//担当者計
					//Heder
					SalesEmployeeHeader.DataField = "";
					SalesEmployeeHeader.Visible = false;
					SalesEmployeeHeader.NewPage = NewPage.None;
					//Footer
					SalesEmployeeFooter.Visible = false;
					break;
				//2:担当者別
				case 2:
					//担当者計
					//Heder
					SalesEmployeeHeader.DataField = "SalesEmployeeField";
					SalesEmployeeHeader.Visible = true;
					SalesEmployeeHeader.NewPage = NewPage.None;

					//メーカー計
					//Heder
					MakerHeader.DataField = "MakerField";
					//MakerHeader.Visible = true;
					MakerHeader.NewPage = NewPage.None;

                    // --- DEL 2008/09/24 -------------------------------->>>>>
                    ////商品区分計
                    ////Heder
                    //DailyHeader.DataField = "";
                    //DailyHeader.Visible = false;
                    //DailyHeader.NewPage = NewPage.None;
                    ////Footer
                    //DailyFooter.Visible = false;
                    // --- DEL 2008/09/24 --------------------------------<<<<<

					//ＢＬコード計
					//Heder
					BLGoodsHeader.DataField = "";
					BLGoodsHeader.Visible = false;
					BLGoodsHeader.NewPage = NewPage.None;
					//Footer
					BLGoodsFooter.Visible = false;

					//得意先計
					//Heder
					CustomerHeader.DataField = "";
					CustomerHeader.Visible = false;
					CustomerHeader.NewPage = NewPage.None;
					//Footer
					CustomerFooter.Visible = false;
					break;
			}
            --- DEL 2008/09/24 -------------------------------->>>>> */
            #endregion

            //-------------------------------------------------------
            // 集計方法設定
            //-------------------------------------------------------
            // --- DEL 2008/09/24 -------------------------------->>>>>
            #region [集計方法設定]
            ////集計方法（0:全社・1:拠点）
            //if (_shipmGoodsOdrReport.TtlType == 0)
            //{
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;

            //    //SectionHeaderの明細印字項目
            //    SectionHeaderLine.DataField = "";
            //    SectionHeaderLine.Visible = false;
            //}
            //else
            //{
            //    SectionHeader.DataField = "SectionHeaderField";

            //    //SectionHeaderの明細印字項目
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.DataField = "SectionGuideNm"; // ADD 2008/09/24
            //    SectionHeaderLine.Visible = true;
            //}
            #endregion
            // --- DEL 2008/09/24 --------------------------------<<<<<
        }


		/// <summary>
		/// 範囲月数の取得処理
		/// </summary>
		/// <returns>範囲月数（ex.４月～６月ならば３）</returns>
		private int GetMonthRange(DateTime stYearMonth, DateTime edYearMonth)
		{
			int stMonth = stYearMonth.Month;
			int edMonth = edYearMonth.Month;

			if (edYearMonth.Year > stYearMonth.Year)
			{
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
			    if ( this._shipmGoodsOdrReport.StockMoveFormalDiv == ShipmGoodsOdrReport.StockMoveFormalDivState.StockMove )
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
			string sectionTitle = "";
			//string sectionTitle = string.Format("{0}拠点：", this._shipmGoodsOdrReport.MainExtractTitle);
			//if ( this._shipmGoodsOdrReport.IsOptSection )
			//{
				if ( this._shipmGoodsOdrReport.IsSelectAllSection )
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
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> uList = new List<TextBox>();
                        uList.AddRange(new TextBox[] { uMonth01, uMonth02, uMonth03, uMonth04, uMonth05, uMonth06, uMonth07, uMonth08, uMonth09, uMonth10, uMonth11, uMonth12, uMonthTotal, uMonthAve });
                        PriceUnitCalc(uList);
                        break;
                    }
            }
            // ADD 2009/04/13 ------<<<

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 0:順位無の場合 100000000:最大順位を超えた場合
            if (this.OrderNo.Text == "0" || this.OrderNo.Text == "100000000")
            {
                this.OrderNo.Text = "";
            }

            //各コード値がゼロ値の場合、表示しない
            if (Convert.ToInt32(this.GoodsMakerCd.Text) == 0)
            {
                this.GoodsMakerCd.Text = "";
            }

            if (Convert.ToInt32(this.BLGroupCode.Text) == 0)
            {
                this.BLGroupCode.Text = "";
            }

            // --- DEL 2008/10/30 -------------------------------->>>>>
            //// 各コード値がゼロ値の場合、表示しない
            //// 品番は桁が大きいので別途確認
            //if (_shipmGoodsOdrReport.TotalType == 0 ||
            //    (_shipmGoodsOdrReport.TotalType == 2) && _shipmGoodsOdrReport.Detail == 0)
            //{
            //    // 品番
            //    if (this.BLGoodsCode.Text == null
            //        || this.BLGoodsCode.Text.PadLeft(24, '0') == "000000000000000000000000")
            //    {
            //        this.BLGoodsCode.Text = "";
            //        this.BLGoodsHalfName.Text = "";
            //    }
            //}
            //else
            //{
            //    if (Convert.ToInt32(this.BLGoodsCode.Text) == 0)
            //    {
            //        this.BLGoodsCode.Text = "";
            //        this.BLGoodsHalfName.Text = "";
            //    }
            //}
            // --- DEL 2008/10/30 --------------------------------<<<<<
            // --- ADD 2008/09/24 --------------------------------<<<<<
            // --- ADD 2008/10/30 -------------------------------->>>>>
            //Line_DetailHead.Visible = Line_DetailHead_Visible; // DEL 2009/04/07
            // --- ADD 2008/10/30 --------------------------------<<<<<
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

            // --- ADD 2008/10/30 -------------------------------->>>>>
            // 明細罫線は1行目のみ
            //this.Line_DetailHead_Visible = false; // DEL 2009/04/07
            // --- ADD 2008/10/30 --------------------------------<<<<<
			
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
#if False
			//月間粗利率
			if (double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				d_TermProfitRate.Value = 0;
			}
			else
			{
				d_TermProfitRate.Value = double.Parse(this.d_TermProfit.Value.ToString()) / double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				d_MonthProfitRate.Value = 0;
			}
			else
			{
				d_MonthProfitRate.Value = double.Parse(this.d_MonthProfit.Value.ToString()) / double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString());
			}
#endif
		}

		private void MakerFooter_Format(object sender, EventArgs e)
		{

		}

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
#if False
			//月間粗利率
			if (double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				s_TermProfitRate.Value = 0;
			}
			else
			{
				s_TermProfitRate.Value = double.Parse(this.s_TermProfit.Value.ToString()) / double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.s_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				s_MonthProfitRate.Value = 0;
			}
			else
			{
				s_MonthProfitRate.Value = double.Parse(this.s_MonthProfit.Value.ToString()) / double.Parse(this.s_MonthSalesTotalTaxExc.Value.ToString());
			}
#endif
		}

		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
#if False
			//月間粗利率
			if (double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				g_TermProfitRate.Value = 0;
			}
			else
			{
				g_TermProfitRate.Value = double.Parse(this.g_TermProfit.Value.ToString()) / double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				g_MonthProfitRate.Value = 0;
			}
			else
			{
				g_MonthProfitRate.Value = double.Parse(this.g_MonthProfit.Value.ToString()) / double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString());
			}
#endif
		}

		//private void MakerFooter_Format(object sender, System.EventArgs eArgs)
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
            // 2009.03.17 30413 犬飼 フッター部の印字修正 >>>>>>START
            // --- DEL 2008/09/24 -------------------------------->>>>>
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
            // --- DEL 2008/09/24 --------------------------------<<<<<
            // 2009.03.17 30413 犬飼 フッター部の印字修正 <<<<<<END
        }
		#endregion

        private void BLGroupHeader_BeforePrint(object sender, EventArgs e)
        {
            // --- DEL 2008/10/30 -------------------------------->>>>>
            //// 各コード値がゼロ値の場合、表示しない
            //if (Convert.ToInt32(this.SupplierCd_textbox.Text) == 0)
            //{
            //    this.SupplierCd_textbox.Text = "";
            //    this.SupplierNm_textBox.Text = "";
            //}

            //if (Convert.ToInt32(this.CustomerCode_textBox.Text) == 0)
            //{
            //    this.CustomerCode_textBox.Text = "";
            //    this.CustomerSnm_textBox.Text = "";
            //}

            //if (this.EmployeeCode_textBox.Text == null
            //    || this.EmployeeCode_textBox.Text.PadLeft(4, '0') == "0000") 
            //{
            //    this.EmployeeCode_textBox.Text = "";
            //    this.EmployeeName_textBox.Text = "";
            //}

            //if (Convert.ToInt32(this.MakerCd_textBox.Text) == 0)
            //{
            //    this.MakerCd_textBox.Text = "";
            //    this.MakerName_textBox.Text = "";
            //}

            //if (Convert.ToInt32(this.GoodsMGroup_textBox.Text) == 0)
            //{
            //    this.GoodsMGroup_textBox.Text = "";
            //}

            //if (Convert.ToInt32(this.BLGoodsCode_textBox.Text) == 0)
            //{
            //    this.BLGoodsCode_textBox.Text = "";
            //}

            //if (Convert.ToInt32(this.BLGroupCode_textBox.Text) == 0)
            //{
            //    this.BLGroupCode_textBox.Text = "";
            //}
            // --- DEL 2008/10/30 --------------------------------<<<<<
        }

        /// <summary>
        /// BLGroupFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // 各コード値がゼロ値の場合、表示しない
            if (Convert.ToInt32(this.subTotalBLGroupCode_textbox.Text) == 0)
            {
                this.subTotalBLGroupCode_textbox.Text = "";
                this.subTotalBLGroupKanaName_textBox.Text = "";
            }

            // ADD 2009/04/13 ------>>>
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> gr_uList = new List<TextBox>();
                        gr_uList.AddRange(new TextBox[] { gr_uMonth01, gr_uMonth02, gr_uMonth03, gr_uMonth04, gr_uMonth05, gr_uMonth06, gr_uMonth07, gr_uMonth08, gr_uMonth09, gr_uMonth10, gr_uMonth11, gr_uMonth12, gr_uMonthTotal, gr_uMonthAve });
                        PriceUnitCalc(gr_uList);
                        break;
                    }
            }
            // ADD 2009/04/13 ------<<<

            // --- ADD 2008/10/30 -------------------------------->>>>>
            // 明細ヘッダ表示をしない計の後は、明細行の上に罫線を設置
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // --- ADD 2008/10/30 --------------------------------<<<<<
        }

        /// <summary>
        /// BLGoodsFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGoodsFooter_BeforePrint(object sender, EventArgs e)
        {
            // 各コード値がゼロ値の場合、表示しない
            if (Convert.ToInt32(this.subTotalBLGoodsCode_textBox.Text) == 0)
            {
                this.subTotalBLGoodsCode_textBox.Text = "";
                this.subTotalBLGoodsHalfName_textBox.Text = "";
            }

            // ADD 2009/04/13 ------>>>
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> bl_uList = new List<TextBox>();
                        bl_uList.AddRange(new TextBox[] { bl_uMonth01, bl_uMonth02, bl_uMonth03, bl_uMonth04, bl_uMonth05, bl_uMonth06, bl_uMonth07, bl_uMonth08, bl_uMonth09, bl_uMonth10, bl_uMonth11, bl_uMonth12, bl_uMonthTotal, bl_uMonthAve });
                        PriceUnitCalc(bl_uList);
                        break;
                    }
            }
            // ADD 2009/04/13 ------<<<

            // --- ADD 2008/10/30 -------------------------------->>>>>
            // 明細ヘッダ表示をしない計の後は、明細行の上に罫線を設置
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // --- ADD 2008/10/30 --------------------------------<<<<<
        }

        /// <summary>
        /// GoodsMGroupFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // 各コード値がゼロ値の場合、表示しない
            if (Convert.ToInt32(this.subTotalGoodsMGroup_textBox.Text) == 0)
            {
                this.subTotalGoodsMGroup_textBox.Text = "";
                this.subTotalGoodsMGroupName_textBox.Text = "";
            }

            // ADD 2009/04/13 ------>>>
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> mg_uList = new List<TextBox>();
                        mg_uList.AddRange(new TextBox[] { mg_uMonth01, mg_uMonth02, mg_uMonth03, mg_uMonth04, mg_uMonth05, mg_uMonth06, mg_uMonth07, mg_uMonth08, mg_uMonth09, mg_uMonth10, mg_uMonth11, mg_uMonth12, mg_uMonthTotal, mg_uMonthAve });
                        PriceUnitCalc(mg_uList);
                        break;
                    }
            }
            // ADD 2009/04/13 ------<<<

            // --- ADD 2008/10/30 -------------------------------->>>>>
            // 明細ヘッダ表示をしない計の後は、明細行の上に罫線を設置
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // --- ADD 2008/10/30 --------------------------------<<<<<
        }

        // --- ADD 2008/10/30 -------------------------------->>>>>
        /// <summary>
        /// MakerFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerFooter_BeforePrint(object sender, EventArgs e)
        {
            // --- ADD 2008/10/30 -------------------------------->>>>>
            // 各コード値がゼロ値の場合、表示しない
            if (Convert.ToInt32(this.subTotalMaker_GoodsMakerCd.Text) == 0)
            {
                this.subTotalMaker_GoodsMakerCd.Text = "";
                this.subTotalMaker_MakerShortName.Text = "";
            }

            // ADD 2009/04/13 ------>>>
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> mk_uList = new List<TextBox>();
                        mk_uList.AddRange(new TextBox[] { mk_uMonth01, mk_uMonth02, mk_uMonth03, mk_uMonth04, mk_uMonth05, mk_uMonth06, mk_uMonth07, mk_uMonth08, mk_uMonth09, mk_uMonth10, mk_uMonth11, mk_uMonth12, mk_uMonthTotal, mk_uMonthAve });
                        PriceUnitCalc(mk_uList);
                        break;
                    }
            }
            // ADD 2009/04/13 ------<<<

            // 明細ヘッダ表示をしない計の後は、明細行の上に罫線を設置
            //Line_DetailHead_Visible = true; // DEL 2009/04/07
            // --- ADD 2008/10/30 --------------------------------<<<<<
        }


        /// <summary>
        /// SuplierHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuplierHeader_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値は印字しない
            if (string.IsNullOrEmpty(this.SupHd_SectionCode.Text)
                || this.SupHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SupHd_SectionCode.Text = string.Empty;
                this.SupHd_SectionName.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.SupHd_SupplierCode.Text)
                || this.SupHd_SupplierCode.Text.PadLeft(6, '0') == "000000")
            {
                this.SupHd_SupplierCode.Text = string.Empty;
                this.SupHd_SupplierName.Text = string.Empty;
            }

            // 明細途中で改頁された場合に罫線表示
            //Line_DetailHead_Visible = true; // ADD 2008/10/30 // DEL 2009/04/07
        }

        /// <summary>
        /// CustomerHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerHeader_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値は印字しない
            if (string.IsNullOrEmpty(this.CusHd_SectionCode.Text)
                || this.CusHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.CusHd_SectionCode.Text = string.Empty;
                this.CusHd_SectionName.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.CusHd_CustomerCode.Text)
                || this.CusHd_CustomerCode.Text.PadLeft(8, '0') == "00000000")
            {
                this.CusHd_CustomerCode.Text = string.Empty;
                this.CusHd_CustomerName.Text = string.Empty;
            }

            // 明細途中で改頁された場合に罫線表示
            //Line_DetailHead_Visible = true; // ADD 2008/10/30 // DEL 2009/04/07
        }

        /// <summary>
        /// SalesEmployeeHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesEmployeeHeader_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値は印字しない
            if (string.IsNullOrEmpty(this.EmpHd_SectionCode.Text)
                || this.EmpHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.EmpHd_SectionCode.Text = string.Empty;
                this.EmpHd_SectionName.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.EmpHd_EmployeeCode.Text)
                || this.EmpHd_EmployeeCode.Text.PadLeft(4, '0') == "0000")
            {
                this.EmpHd_EmployeeCode.Text = string.Empty;
                this.EmpHd_EmployeeName.Text = string.Empty;
            }

            // 明細途中で改頁された場合に罫線表示
            //Line_DetailHead_Visible = true; // ADD 2008/10/30 // DEL 2009/04/07
        }

        // --- ADD 2008/10/30 --------------------------------<<<<<

        // ADD 2009/04/13 ------>>>
        /// <summary>
        /// SalesEmployeeFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesEmployeeFooter_BeforePrint(object sender, EventArgs e)
        {
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> em_uList = new List<TextBox>();
                        em_uList.AddRange(new TextBox[] { em_uMonth01, em_uMonth02, em_uMonth03, em_uMonth04, em_uMonth05, em_uMonth06, em_uMonth07, em_uMonth08, em_uMonth09, em_uMonth10, em_uMonth11, em_uMonth12, em_uMonthTotal, em_uMonthAve });
                        PriceUnitCalc(em_uList);
                        break;
                    }
            }
        }

        /// <summary>
        /// CustomerFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerFooter_BeforePrint(object sender, EventArgs e)
        {
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> cu_uList = new List<TextBox>();
                        cu_uList.AddRange(new TextBox[] { cu_uMonth01, cu_uMonth02, cu_uMonth03, cu_uMonth04, cu_uMonth05, cu_uMonth06, cu_uMonth07, cu_uMonth08, cu_uMonth09, cu_uMonth10, cu_uMonth11, cu_uMonth12, cu_uMonthTotal, cu_uMonthAve });
                        PriceUnitCalc(cu_uList);
                        break;
                    }
            }
        }

        /// <summary>
        /// SuplierFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuplierFooter_BeforePrint(object sender, EventArgs e)
        {
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> su_uList = new List<TextBox>();
                        su_uList.AddRange(new TextBox[] { su_uMonth01, su_uMonth02, su_uMonth03, su_uMonth04, su_uMonth05, su_uMonth06, su_uMonth07, su_uMonth08, su_uMonth09, su_uMonth10, su_uMonth11, su_uMonth12, su_uMonthTotal, su_uMonthAve });
                        PriceUnitCalc(su_uList);
                        break;
                    }
            }
        }

        /// <summary>
        /// SectionFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> se_uList = new List<TextBox>();
                        se_uList.AddRange(new TextBox[] { se_uMonth01, se_uMonth02, se_uMonth03, se_uMonth04, se_uMonth05, se_uMonth06, se_uMonth07, se_uMonth08, se_uMonth09, se_uMonth10, se_uMonth11, se_uMonth12, se_uMonthTotal, se_uMonthAve });
                        PriceUnitCalc(se_uList);
                        break;
                    }
            }
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 円単位計算
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 2:     // 2:金額
                case 3:     // 3:金額＆数量
                case 4:     // 4:金額＆回数
                    {
                        List<TextBox> to_uList = new List<TextBox>();
                        to_uList.AddRange(new TextBox[] { to_uMonth01, to_uMonth02, to_uMonth03, to_uMonth04, to_uMonth05, to_uMonth06, to_uMonth07, to_uMonth08, to_uMonth09, to_uMonth10, to_uMonth11, to_uMonth12, to_uMonthTotal, to_uMonthAve });
                        PriceUnitCalc(to_uList);
                        break;
                    }
            }
        }
        // ADD 2009/04/13 ------<<<
        
		#endregion ■ Control Event

        // ADD 2009/04/13 ------>>>
        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._shipmGoodsOdrReport.MoneyUnit == 1)
            {
                int priceUnit = 1000;

                for (int index = 0; index < calcList.Count; index++)
                {
                    if (!calcList[index].Visible)
                    {
                        continue;
                    }

                    decimal unitCalc = 0;
                    if (calcList[index].Value is long)
                    {
                        unitCalc = (decimal)((long)calcList[index].Value / (decimal)priceUnit);
                    }
                    else if (calcList[index].Value is double)
                    {
                        unitCalc = (decimal)((double)calcList[index].Value / (double)priceUnit);
                    }
                    else
                    {
                        continue;
                    }
                    calcList[index].Value = unitCalc;
                }
            }
        }
        // ADD 2009/04/13 ------<<<

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
		private DataDynamics.ActiveReports.Label Lb_Month11;
		private DataDynamics.ActiveReports.Label Lb_Month04;
		private DataDynamics.ActiveReports.Label Lb_Month02;
		private DataDynamics.ActiveReports.Label Lb_Month03;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader MakerHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox BLGoodsCode;
		private DataDynamics.ActiveReports.TextBox uMonth12;
		private DataDynamics.ActiveReports.TextBox uMonth04;
		private DataDynamics.ActiveReports.TextBox uMonth05;
		private DataDynamics.ActiveReports.TextBox uMonth06;
		private DataDynamics.ActiveReports.TextBox dMonth04;
		private DataDynamics.ActiveReports.TextBox dMonth05;
		private DataDynamics.ActiveReports.TextBox dMonth06;
        private DataDynamics.ActiveReports.TextBox dMonth10;
		private DataDynamics.ActiveReports.GroupFooter MakerFooter;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SectionTitle;
		private DataDynamics.ActiveReports.TextBox se_uMonth12;
		private DataDynamics.ActiveReports.TextBox se_uMonth05;
		private DataDynamics.ActiveReports.TextBox se_uMonth06;
		private DataDynamics.ActiveReports.TextBox se_dMonth05;
		private DataDynamics.ActiveReports.TextBox se_dMonth06;
		private DataDynamics.ActiveReports.TextBox se_uMonth08;
		private DataDynamics.ActiveReports.TextBox se_dMonth08;
		private DataDynamics.ActiveReports.TextBox se_dMonth12;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotalTitle;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox to_uMonth12;
		private DataDynamics.ActiveReports.TextBox to_uMonth05;
		private DataDynamics.ActiveReports.TextBox to_dMonth05;
		private DataDynamics.ActiveReports.TextBox to_uMonth06;
		private DataDynamics.ActiveReports.TextBox to_dMonth06;
		private DataDynamics.ActiveReports.TextBox to_uMonth08;
		private DataDynamics.ActiveReports.TextBox to_dMonth08;
		private DataDynamics.ActiveReports.TextBox to_dMonth12;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHNB02052P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.OrderNo = new DataDynamics.ActiveReports.TextBox();
            this.uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupKanaName = new DataDynamics.ActiveReports.TextBox();
            this.Line_DetailHead = new DataDynamics.ActiveReports.Line();
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
            this.Lb_Month11 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month04 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month02 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month03 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month01 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month07 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month09 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month10 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month12 = new DataDynamics.ActiveReports.Label();
            this.Lb_MonthTotal = new DataDynamics.ActiveReports.Label();
            this.Lb_MonthAve = new DataDynamics.ActiveReports.Label();
            this.Lb_Month05 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month06 = new DataDynamics.ActiveReports.Label();
            this.Lb_Month08 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsHalfName = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGroupCode = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.to_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.to_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.to_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.se_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.se_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.mk_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.mk_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.subTotalMaker_GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.subTotalMaker_MakerShortName = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGoodsFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.bl_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.bl_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.subTotalBLGoodsCode_textBox = new DataDynamics.ActiveReports.TextBox();
            this.subTotalBLGoodsHalfName_textBox = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CusHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.CusHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerTitle = new DataDynamics.ActiveReports.Label();
            this.CusHd_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CusHd_CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.cu_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.cu_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.cu_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.SalesEmployeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.EmpHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.EmpHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeTitle = new DataDynamics.ActiveReports.Label();
            this.EmpHd_EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.EmpHd_EmployeeName = new DataDynamics.ActiveReports.TextBox();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.SalesEmployeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox99 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.em_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.em_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.em_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.subTotalGoodsMGroup_textBox = new DataDynamics.ActiveReports.TextBox();
            this.subTotalGoodsMGroupName_textBox = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.mg_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.mg_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.SuplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupHd_SupplierTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_SupplierCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierName = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SuplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.su_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.su_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.BLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.subTotalBLGroupCode_textbox = new DataDynamics.ActiveReports.TextBox();
            this.subTotalBLGroupKanaName_textBox = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth01 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth02 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth03 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth04 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth05 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth06 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth07 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth08 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth09 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth10 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth11 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonth12 = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.gr_uMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.gr_dMonthAve = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupKanaName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalMaker_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalMaker_MakerShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGoodsCode_textBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGoodsHalfName_textBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalGoodsMGroup_textBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalGoodsMGroupName_textBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupCode_textbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupKanaName_textBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonthAve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.BLGoodsCode,
            this.uMonth12,
            this.uMonth04,
            this.uMonth05,
            this.uMonth06,
            this.dMonth04,
            this.dMonth05,
            this.dMonth06,
            this.dMonth10,
            this.uMonth03,
            this.dMonth03,
            this.uMonth09,
            this.dMonth08,
            this.dMonth09,
            this.dMonthAve,
            this.uMonth08,
            this.uMonth10,
            this.uMonth11,
            this.uMonthTotal,
            this.uMonthAve,
            this.dMonth11,
            this.dMonth12,
            this.dMonthTotal,
            this.OrderNo,
            this.uMonth07,
            this.dMonth07,
            this.uMonth02,
            this.dMonth02,
            this.uMonth01,
            this.dMonth01,
            this.BLGoodsHalfName,
            this.GoodsMakerCd,
            this.BLGroupCode,
            this.MakerName,
            this.BLGroupKanaName,
            this.Line_DetailHead});
            this.Detail.Height = 0.46875F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.BLGoodsCode.DataField = "GoodsNo";
            this.BLGoodsCode.Height = 0.156F;
            this.BLGoodsCode.Left = 0.5F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BLGoodsCode.Text = "123456789012345678901234";
            this.BLGoodsCode.Top = 0.0625F;
            this.BLGoodsCode.Width = 1.25F;
            // 
            // uMonth12
            // 
            this.uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth12.DataField = "TermSalesComp";
            this.uMonth12.Height = 0.156F;
            this.uMonth12.Left = 9.047502F;
            this.uMonth12.MultiLine = false;
            this.uMonth12.Name = "uMonth12";
            this.uMonth12.OutputFormat = resources.GetString("uMonth12.OutputFormat");
            this.uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth12.Text = "12,345,678";
            this.uMonth12.Top = 0.0625F;
            this.uMonth12.Width = 0.51F;
            // 
            // uMonth04
            // 
            this.uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth04.DataField = "OrderSalesMoney";
            this.uMonth04.Height = 0.156F;
            this.uMonth04.Left = 4.9675F;
            this.uMonth04.MultiLine = false;
            this.uMonth04.Name = "uMonth04";
            this.uMonth04.OutputFormat = resources.GetString("uMonth04.OutputFormat");
            this.uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth04.Text = "12,345,678";
            this.uMonth04.Top = 0.0625F;
            this.uMonth04.Width = 0.51F;
            // 
            // uMonth05
            // 
            this.uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth05.DataField = "StockSalesMoney";
            this.uMonth05.Height = 0.156F;
            this.uMonth05.Left = 5.4775F;
            this.uMonth05.MultiLine = false;
            this.uMonth05.Name = "uMonth05";
            this.uMonth05.OutputFormat = resources.GetString("uMonth05.OutputFormat");
            this.uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth05.Text = "12,345,678";
            this.uMonth05.Top = 0.0625F;
            this.uMonth05.Width = 0.51F;
            // 
            // uMonth06
            // 
            this.uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth06.DataField = "GrossMoney";
            this.uMonth06.Height = 0.156F;
            this.uMonth06.Left = 5.9875F;
            this.uMonth06.MultiLine = false;
            this.uMonth06.Name = "uMonth06";
            this.uMonth06.OutputFormat = resources.GetString("uMonth06.OutputFormat");
            this.uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth06.Text = "12,345,678";
            this.uMonth06.Top = 0.0625F;
            this.uMonth06.Width = 0.51F;
            // 
            // dMonth04
            // 
            this.dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth04.DataField = "TotalOrderSalesMoney";
            this.dMonth04.Height = 0.156F;
            this.dMonth04.Left = 4.9675F;
            this.dMonth04.MultiLine = false;
            this.dMonth04.Name = "dMonth04";
            this.dMonth04.OutputFormat = resources.GetString("dMonth04.OutputFormat");
            this.dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth04.Text = "12,345,678";
            this.dMonth04.Top = 0.25F;
            this.dMonth04.Width = 0.51F;
            // 
            // dMonth05
            // 
            this.dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth05.DataField = "TotalStockSalesMoney";
            this.dMonth05.Height = 0.156F;
            this.dMonth05.Left = 5.4775F;
            this.dMonth05.MultiLine = false;
            this.dMonth05.Name = "dMonth05";
            this.dMonth05.OutputFormat = resources.GetString("dMonth05.OutputFormat");
            this.dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth05.Text = "12,345,678";
            this.dMonth05.Top = 0.25F;
            this.dMonth05.Width = 0.51F;
            // 
            // dMonth06
            // 
            this.dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth06.DataField = "TotalGrossMoney";
            this.dMonth06.Height = 0.156F;
            this.dMonth06.Left = 5.9875F;
            this.dMonth06.MultiLine = false;
            this.dMonth06.Name = "dMonth06";
            this.dMonth06.OutputFormat = resources.GetString("dMonth06.OutputFormat");
            this.dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth06.Text = "12,345,678";
            this.dMonth06.Top = 0.25F;
            this.dMonth06.Width = 0.51F;
            // 
            // dMonth10
            // 
            this.dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth10.DataField = "TotalOrderStockMoney";
            this.dMonth10.Height = 0.156F;
            this.dMonth10.Left = 8.027501F;
            this.dMonth10.MultiLine = false;
            this.dMonth10.Name = "dMonth10";
            this.dMonth10.OutputFormat = resources.GetString("dMonth10.OutputFormat");
            this.dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth10.Text = "12,345,678";
            this.dMonth10.Top = 0.25F;
            this.dMonth10.Width = 0.51F;
            // 
            // uMonth03
            // 
            this.uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth03.DataField = "SalesMoney";
            this.uMonth03.Height = 0.156F;
            this.uMonth03.Left = 4.4575F;
            this.uMonth03.MultiLine = false;
            this.uMonth03.Name = "uMonth03";
            this.uMonth03.OutputFormat = resources.GetString("uMonth03.OutputFormat");
            this.uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth03.Text = "12,345,678";
            this.uMonth03.Top = 0.0625F;
            this.uMonth03.Width = 0.51F;
            // 
            // dMonth03
            // 
            this.dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth03.DataField = "TotalSalesMoney";
            this.dMonth03.Height = 0.156F;
            this.dMonth03.Left = 4.4575F;
            this.dMonth03.MultiLine = false;
            this.dMonth03.Name = "dMonth03";
            this.dMonth03.OutputFormat = resources.GetString("dMonth03.OutputFormat");
            this.dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth03.Text = "12,345,678";
            this.dMonth03.Top = 0.25F;
            this.dMonth03.Width = 0.51F;
            // 
            // uMonth09
            // 
            this.uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth09.DataField = "StockMoney";
            this.uMonth09.Height = 0.156F;
            this.uMonth09.Left = 7.517501F;
            this.uMonth09.MultiLine = false;
            this.uMonth09.Name = "uMonth09";
            this.uMonth09.OutputFormat = resources.GetString("uMonth09.OutputFormat");
            this.uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth09.Text = "12,345,678";
            this.uMonth09.Top = 0.0625F;
            this.uMonth09.Width = 0.51F;
            // 
            // dMonth08
            // 
            this.dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth08.DataField = "TotalCostMoney";
            this.dMonth08.Height = 0.156F;
            this.dMonth08.Left = 7.007501F;
            this.dMonth08.MultiLine = false;
            this.dMonth08.Name = "dMonth08";
            this.dMonth08.OutputFormat = resources.GetString("dMonth08.OutputFormat");
            this.dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth08.Text = "12,345,678";
            this.dMonth08.Top = 0.25F;
            this.dMonth08.Width = 0.51F;
            // 
            // dMonth09
            // 
            this.dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth09.DataField = "TotalStockMoney";
            this.dMonth09.Height = 0.156F;
            this.dMonth09.Left = 7.517501F;
            this.dMonth09.MultiLine = false;
            this.dMonth09.Name = "dMonth09";
            this.dMonth09.OutputFormat = resources.GetString("dMonth09.OutputFormat");
            this.dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth09.Text = "12,345,678";
            this.dMonth09.Top = 0.25F;
            this.dMonth09.Width = 0.51F;
            // 
            // dMonthAve
            // 
            this.dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthAve.DataField = "TotalDifference";
            this.dMonthAve.Height = 0.156F;
            this.dMonthAve.Left = 10.2575F;
            this.dMonthAve.MultiLine = false;
            this.dMonthAve.Name = "dMonthAve";
            this.dMonthAve.OutputFormat = resources.GetString("dMonthAve.OutputFormat");
            this.dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonthAve.Text = "12,345,678";
            this.dMonthAve.Top = 0.25F;
            this.dMonthAve.Width = 0.51F;
            // 
            // uMonth08
            // 
            this.uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth08.DataField = "CostMoney";
            this.uMonth08.Height = 0.156F;
            this.uMonth08.Left = 7.007501F;
            this.uMonth08.MultiLine = false;
            this.uMonth08.Name = "uMonth08";
            this.uMonth08.OutputFormat = resources.GetString("uMonth08.OutputFormat");
            this.uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth08.Text = "12,345,678";
            this.uMonth08.Top = 0.0625F;
            this.uMonth08.Width = 0.51F;
            // 
            // uMonth10
            // 
            this.uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth10.DataField = "OrderStockMoney";
            this.uMonth10.DistinctField = "TermProfit";
            this.uMonth10.Height = 0.156F;
            this.uMonth10.Left = 8.027501F;
            this.uMonth10.MultiLine = false;
            this.uMonth10.Name = "uMonth10";
            this.uMonth10.OutputFormat = resources.GetString("uMonth10.OutputFormat");
            this.uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth10.Text = "12,345,678";
            this.uMonth10.Top = 0.0625F;
            this.uMonth10.Width = 0.51F;
            // 
            // uMonth11
            // 
            this.uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth11.DataField = "StockStockMoney";
            this.uMonth11.DistinctField = "TermProfit";
            this.uMonth11.Height = 0.156F;
            this.uMonth11.Left = 8.537501F;
            this.uMonth11.MultiLine = false;
            this.uMonth11.Name = "uMonth11";
            this.uMonth11.OutputFormat = resources.GetString("uMonth11.OutputFormat");
            this.uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth11.Text = "12,345,678";
            this.uMonth11.Top = 0.0625F;
            this.uMonth11.Width = 0.51F;
            // 
            // uMonthTotal
            // 
            this.uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthTotal.DataField = "TermStockComp";
            this.uMonthTotal.Height = 0.156F;
            this.uMonthTotal.Left = 9.557502F;
            this.uMonthTotal.MultiLine = false;
            this.uMonthTotal.Name = "uMonthTotal";
            this.uMonthTotal.OutputFormat = resources.GetString("uMonthTotal.OutputFormat");
            this.uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonthTotal.Text = "1,234,567,890";
            this.uMonthTotal.Top = 0.0625F;
            this.uMonthTotal.Width = 0.7F;
            // 
            // uMonthAve
            // 
            this.uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonthAve.DataField = "Difference";
            this.uMonthAve.DistinctField = "TermProfit";
            this.uMonthAve.Height = 0.156F;
            this.uMonthAve.Left = 10.2575F;
            this.uMonthAve.MultiLine = false;
            this.uMonthAve.Name = "uMonthAve";
            this.uMonthAve.OutputFormat = resources.GetString("uMonthAve.OutputFormat");
            this.uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonthAve.Text = "12,345,678";
            this.uMonthAve.Top = 0.0625F;
            this.uMonthAve.Width = 0.51F;
            // 
            // dMonth11
            // 
            this.dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth11.DataField = "TotalStockStockMoney";
            this.dMonth11.Height = 0.156F;
            this.dMonth11.Left = 8.537501F;
            this.dMonth11.MultiLine = false;
            this.dMonth11.Name = "dMonth11";
            this.dMonth11.OutputFormat = resources.GetString("dMonth11.OutputFormat");
            this.dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth11.Text = "12,345,678";
            this.dMonth11.Top = 0.25F;
            this.dMonth11.Width = 0.51F;
            // 
            // dMonth12
            // 
            this.dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth12.DataField = "MonthSalesComp";
            this.dMonth12.Height = 0.156F;
            this.dMonth12.Left = 9.047502F;
            this.dMonth12.MultiLine = false;
            this.dMonth12.Name = "dMonth12";
            this.dMonth12.OutputFormat = resources.GetString("dMonth12.OutputFormat");
            this.dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth12.Text = "12,345,678";
            this.dMonth12.Top = 0.25F;
            this.dMonth12.Width = 0.51F;
            // 
            // dMonthTotal
            // 
            this.dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonthTotal.DataField = "MonthStockComp";
            this.dMonthTotal.Height = 0.156F;
            this.dMonthTotal.Left = 9.557502F;
            this.dMonthTotal.MultiLine = false;
            this.dMonthTotal.Name = "dMonthTotal";
            this.dMonthTotal.OutputFormat = resources.GetString("dMonthTotal.OutputFormat");
            this.dMonthTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonthTotal.Text = "1,234,567,890";
            this.dMonthTotal.Top = 0.25F;
            this.dMonthTotal.Width = 0.7F;
            // 
            // OrderNo
            // 
            this.OrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.OrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.OrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.DataField = "OrderNo";
            this.OrderNo.Height = 0.156F;
            this.OrderNo.Left = 0F;
            this.OrderNo.MultiLine = false;
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.OutputFormat = resources.GetString("OrderNo.OutputFormat");
            this.OrderNo.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 7pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.OrderNo.Text = "12345678";
            this.OrderNo.Top = 0.0625F;
            this.OrderNo.Width = 0.4375F;
            // 
            // uMonth07
            // 
            this.uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth07.DataField = "GrossMoney";
            this.uMonth07.Height = 0.156F;
            this.uMonth07.Left = 6.4975F;
            this.uMonth07.MultiLine = false;
            this.uMonth07.Name = "uMonth07";
            this.uMonth07.OutputFormat = resources.GetString("uMonth07.OutputFormat");
            this.uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth07.Text = "12,345,678";
            this.uMonth07.Top = 0.0625F;
            this.uMonth07.Width = 0.51F;
            // 
            // dMonth07
            // 
            this.dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth07.DataField = "GrossMoney";
            this.dMonth07.Height = 0.156F;
            this.dMonth07.Left = 6.4975F;
            this.dMonth07.MultiLine = false;
            this.dMonth07.Name = "dMonth07";
            this.dMonth07.OutputFormat = resources.GetString("dMonth07.OutputFormat");
            this.dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth07.Text = "12,345,678";
            this.dMonth07.Top = 0.25F;
            this.dMonth07.Width = 0.51F;
            // 
            // uMonth02
            // 
            this.uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth02.DataField = "SalesMoney";
            this.uMonth02.Height = 0.156F;
            this.uMonth02.Left = 3.9475F;
            this.uMonth02.MultiLine = false;
            this.uMonth02.Name = "uMonth02";
            this.uMonth02.OutputFormat = resources.GetString("uMonth02.OutputFormat");
            this.uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth02.Text = "12,345,678";
            this.uMonth02.Top = 0.0625F;
            this.uMonth02.Width = 0.51F;
            // 
            // dMonth02
            // 
            this.dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth02.DataField = "SalesMoney";
            this.dMonth02.Height = 0.156F;
            this.dMonth02.Left = 3.9475F;
            this.dMonth02.MultiLine = false;
            this.dMonth02.Name = "dMonth02";
            this.dMonth02.OutputFormat = resources.GetString("dMonth02.OutputFormat");
            this.dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth02.Text = "12,345,678";
            this.dMonth02.Top = 0.25F;
            this.dMonth02.Width = 0.51F;
            // 
            // uMonth01
            // 
            this.uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uMonth01.DataField = "SalesMoney";
            this.uMonth01.Height = 0.156F;
            this.uMonth01.Left = 3.4375F;
            this.uMonth01.MultiLine = false;
            this.uMonth01.Name = "uMonth01";
            this.uMonth01.OutputFormat = resources.GetString("uMonth01.OutputFormat");
            this.uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.uMonth01.Text = "12,345,678";
            this.uMonth01.Top = 0.0625F;
            this.uMonth01.Width = 0.51F;
            // 
            // dMonth01
            // 
            this.dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dMonth01.DataField = "SalesMoney";
            this.dMonth01.Height = 0.156F;
            this.dMonth01.Left = 3.4375F;
            this.dMonth01.MultiLine = false;
            this.dMonth01.Name = "dMonth01";
            this.dMonth01.OutputFormat = resources.GetString("dMonth01.OutputFormat");
            this.dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 6.5pt; font" +
                "-family: ＭＳ ゴシック; vertical-align: top; ";
            this.dMonth01.Text = "12,345,678";
            this.dMonth01.Top = 0.25F;
            this.dMonth01.Width = 0.51F;
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
            this.BLGoodsHalfName.DataField = "GoodsName";
            this.BLGoodsHalfName.Height = 0.156F;
            this.BLGoodsHalfName.Left = 1.75F;
            this.BLGoodsHalfName.MultiLine = false;
            this.BLGoodsHalfName.Name = "BLGoodsHalfName";
            this.BLGoodsHalfName.OutputFormat = resources.GetString("BLGoodsHalfName.OutputFormat");
            this.BLGoodsHalfName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BLGoodsHalfName.Text = "12345678901234567890";
            this.BLGoodsHalfName.Top = 0.0625F;
            this.BLGoodsHalfName.Width = 1F;
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
            this.GoodsMakerCd.Height = 0.16F;
            this.GoodsMakerCd.Left = 2.78F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.063F;
            this.GoodsMakerCd.Width = 0.3F;
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
            this.BLGroupCode.Height = 0.16F;
            this.BLGroupCode.Left = 3.08F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0.0625F;
            this.BLGroupCode.Width = 0.313F;
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
            this.MakerName.DataField = "MakerShortName";
            this.MakerName.Height = 0.156F;
            this.MakerName.Left = 1.875F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこ";
            this.MakerName.Top = 0.25F;
            this.MakerName.Visible = false;
            this.MakerName.Width = 1F;
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
            this.BLGroupKanaName.Height = 0.156F;
            this.BLGroupKanaName.Left = 0.8125F;
            this.BLGroupKanaName.MultiLine = false;
            this.BLGroupKanaName.Name = "BLGroupKanaName";
            this.BLGroupKanaName.OutputFormat = resources.GetString("BLGroupKanaName.OutputFormat");
            this.BLGroupKanaName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BLGroupKanaName.Text = "12345678901234567890";
            this.BLGroupKanaName.Top = 0.25F;
            this.BLGroupKanaName.Visible = false;
            this.BLGroupKanaName.Width = 1F;
            // 
            // Line_DetailHead
            // 
            this.Line_DetailHead.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.RightColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.TopColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Height = 0F;
            this.Line_DetailHead.Left = 0F;
            this.Line_DetailHead.LineWeight = 2F;
            this.Line_DetailHead.Name = "Line_DetailHead";
            this.Line_DetailHead.Top = 0F;
            this.Line_DetailHead.Width = 10.8F;
            this.Line_DetailHead.X1 = 0F;
            this.Line_DetailHead.X2 = 10.8F;
            this.Line_DetailHead.Y1 = 0F;
            this.Line_DetailHead.Y2 = 0F;
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
            this.tb_ReportTitle.Text = "売上順位表（担当者別）";
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
            this.SortTitle.Width = 3.15F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2291667F;
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
            this.Lb_Month11,
            this.Lb_Month04,
            this.Lb_Month02,
            this.Lb_Month03,
            this.Lb_Month01,
            this.Lb_Month07,
            this.Lb_Month09,
            this.Lb_Month10,
            this.Lb_Month12,
            this.Lb_MonthTotal,
            this.Lb_MonthAve,
            this.Lb_Month05,
            this.Lb_Month06,
            this.Lb_Month08,
            this.label16,
            this.Lb_BLGoodsCode,
            this.Lb_BLGoodsHalfName,
            this.Lb_MakerName,
            this.Lb_BLGroupCode});
            this.TitleHeader.Height = 0.21875F;
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
            // Lb_Month11
            // 
            this.Lb_Month11.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month11.Height = 0.156F;
            this.Lb_Month11.HyperLink = "";
            this.Lb_Month11.Left = 8.530001F;
            this.Lb_Month11.MultiLine = false;
            this.Lb_Month11.Name = "Lb_Month11";
            this.Lb_Month11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month11.Text = "11月";
            this.Lb_Month11.Top = 0.01F;
            this.Lb_Month11.Width = 0.51F;
            // 
            // Lb_Month04
            // 
            this.Lb_Month04.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month04.Height = 0.156F;
            this.Lb_Month04.HyperLink = "";
            this.Lb_Month04.Left = 4.959999F;
            this.Lb_Month04.MultiLine = false;
            this.Lb_Month04.Name = "Lb_Month04";
            this.Lb_Month04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month04.Text = "4月";
            this.Lb_Month04.Top = 0.01F;
            this.Lb_Month04.Width = 0.51F;
            // 
            // Lb_Month02
            // 
            this.Lb_Month02.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month02.Height = 0.156F;
            this.Lb_Month02.HyperLink = "";
            this.Lb_Month02.Left = 3.939999F;
            this.Lb_Month02.MultiLine = false;
            this.Lb_Month02.Name = "Lb_Month02";
            this.Lb_Month02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month02.Text = "2月";
            this.Lb_Month02.Top = 0.01F;
            this.Lb_Month02.Width = 0.51F;
            // 
            // Lb_Month03
            // 
            this.Lb_Month03.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month03.Height = 0.156F;
            this.Lb_Month03.HyperLink = "";
            this.Lb_Month03.Left = 4.449999F;
            this.Lb_Month03.MultiLine = false;
            this.Lb_Month03.Name = "Lb_Month03";
            this.Lb_Month03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month03.Text = "3月";
            this.Lb_Month03.Top = 0.01F;
            this.Lb_Month03.Width = 0.51F;
            // 
            // Lb_Month01
            // 
            this.Lb_Month01.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month01.Height = 0.156F;
            this.Lb_Month01.HyperLink = "";
            this.Lb_Month01.Left = 3.489998F;
            this.Lb_Month01.MultiLine = false;
            this.Lb_Month01.Name = "Lb_Month01";
            this.Lb_Month01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month01.Text = "1月";
            this.Lb_Month01.Top = 0.01F;
            this.Lb_Month01.Width = 0.45F;
            // 
            // Lb_Month07
            // 
            this.Lb_Month07.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month07.Height = 0.156F;
            this.Lb_Month07.HyperLink = "";
            this.Lb_Month07.Left = 6.49F;
            this.Lb_Month07.MultiLine = false;
            this.Lb_Month07.Name = "Lb_Month07";
            this.Lb_Month07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month07.Text = "7月";
            this.Lb_Month07.Top = 0.01F;
            this.Lb_Month07.Width = 0.51F;
            // 
            // Lb_Month09
            // 
            this.Lb_Month09.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month09.Height = 0.156F;
            this.Lb_Month09.HyperLink = "";
            this.Lb_Month09.Left = 7.51F;
            this.Lb_Month09.MultiLine = false;
            this.Lb_Month09.Name = "Lb_Month09";
            this.Lb_Month09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month09.Text = "9月";
            this.Lb_Month09.Top = 0.01F;
            this.Lb_Month09.Width = 0.51F;
            // 
            // Lb_Month10
            // 
            this.Lb_Month10.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month10.Height = 0.156F;
            this.Lb_Month10.HyperLink = "";
            this.Lb_Month10.Left = 8.02F;
            this.Lb_Month10.MultiLine = false;
            this.Lb_Month10.Name = "Lb_Month10";
            this.Lb_Month10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month10.Text = "10月";
            this.Lb_Month10.Top = 0.01F;
            this.Lb_Month10.Width = 0.51F;
            // 
            // Lb_Month12
            // 
            this.Lb_Month12.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month12.Height = 0.156F;
            this.Lb_Month12.HyperLink = "";
            this.Lb_Month12.Left = 9.040001F;
            this.Lb_Month12.MultiLine = false;
            this.Lb_Month12.Name = "Lb_Month12";
            this.Lb_Month12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month12.Text = "12月";
            this.Lb_Month12.Top = 0.01F;
            this.Lb_Month12.Width = 0.51F;
            // 
            // Lb_MonthTotal
            // 
            this.Lb_MonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthTotal.Height = 0.156F;
            this.Lb_MonthTotal.HyperLink = "";
            this.Lb_MonthTotal.Left = 9.55F;
            this.Lb_MonthTotal.MultiLine = false;
            this.Lb_MonthTotal.Name = "Lb_MonthTotal";
            this.Lb_MonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MonthTotal.Text = "合計";
            this.Lb_MonthTotal.Top = 0.01F;
            this.Lb_MonthTotal.Width = 0.7F;
            // 
            // Lb_MonthAve
            // 
            this.Lb_MonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MonthAve.Height = 0.156F;
            this.Lb_MonthAve.HyperLink = "";
            this.Lb_MonthAve.Left = 10.25F;
            this.Lb_MonthAve.MultiLine = false;
            this.Lb_MonthAve.Name = "Lb_MonthAve";
            this.Lb_MonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MonthAve.Text = "平均";
            this.Lb_MonthAve.Top = 0.01F;
            this.Lb_MonthAve.Width = 0.51F;
            // 
            // Lb_Month05
            // 
            this.Lb_Month05.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month05.Height = 0.156F;
            this.Lb_Month05.HyperLink = "";
            this.Lb_Month05.Left = 5.469999F;
            this.Lb_Month05.MultiLine = false;
            this.Lb_Month05.Name = "Lb_Month05";
            this.Lb_Month05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month05.Text = "5月";
            this.Lb_Month05.Top = 0.01F;
            this.Lb_Month05.Width = 0.51F;
            // 
            // Lb_Month06
            // 
            this.Lb_Month06.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month06.Height = 0.156F;
            this.Lb_Month06.HyperLink = "";
            this.Lb_Month06.Left = 5.98F;
            this.Lb_Month06.MultiLine = false;
            this.Lb_Month06.Name = "Lb_Month06";
            this.Lb_Month06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month06.Text = "6月";
            this.Lb_Month06.Top = 0.01F;
            this.Lb_Month06.Width = 0.51F;
            // 
            // Lb_Month08
            // 
            this.Lb_Month08.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Month08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Month08.Height = 0.156F;
            this.Lb_Month08.HyperLink = "";
            this.Lb_Month08.Left = 7F;
            this.Lb_Month08.MultiLine = false;
            this.Lb_Month08.Name = "Lb_Month08";
            this.Lb_Month08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Month08.Text = "8月";
            this.Lb_Month08.Top = 0.01F;
            this.Lb_Month08.Width = 0.51F;
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
            this.label16.Left = 0F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "順位";
            this.label16.Top = 0.01F;
            this.label16.Width = 0.4375F;
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
            this.Lb_BLGoodsCode.Height = 0.156F;
            this.Lb_BLGoodsCode.HyperLink = "";
            this.Lb_BLGoodsCode.Left = 0.4375F;
            this.Lb_BLGoodsCode.MultiLine = false;
            this.Lb_BLGoodsCode.Name = "Lb_BLGoodsCode";
            this.Lb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode.Text = "品番";
            this.Lb_BLGoodsCode.Top = 0.01F;
            this.Lb_BLGoodsCode.Width = 1.25F;
            // 
            // Lb_BLGoodsHalfName
            // 
            this.Lb_BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Height = 0.156F;
            this.Lb_BLGoodsHalfName.HyperLink = "";
            this.Lb_BLGoodsHalfName.Left = 1.75F;
            this.Lb_BLGoodsHalfName.MultiLine = false;
            this.Lb_BLGoodsHalfName.Name = "Lb_BLGoodsHalfName";
            this.Lb_BLGoodsHalfName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsHalfName.Text = "品名";
            this.Lb_BLGoodsHalfName.Top = 0.01F;
            this.Lb_BLGoodsHalfName.Width = 1F;
            // 
            // Lb_MakerName
            // 
            this.Lb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Height = 0.16F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 2.78F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MakerName.Text = "ﾒｰｶｰ";
            this.Lb_MakerName.Top = 0.01F;
            this.Lb_MakerName.Width = 0.3F;
            // 
            // Lb_BLGroupCode
            // 
            this.Lb_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Height = 0.16F;
            this.Lb_BLGroupCode.HyperLink = "";
            this.Lb_BLGroupCode.Left = 3.08F;
            this.Lb_BLGroupCode.MultiLine = false;
            this.Lb_BLGroupCode.Name = "Lb_BLGroupCode";
            this.Lb_BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGroupCode.Text = "BLｺｰﾄﾞ";
            this.Lb_BLGroupCode.Top = 0.01F;
            this.Lb_BLGroupCode.Width = 0.4F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
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
            this.GrandTotalTitle,
            this.Line43,
            this.to_uMonth12,
            this.to_uMonth05,
            this.to_dMonth05,
            this.to_uMonth06,
            this.to_dMonth06,
            this.to_uMonth08,
            this.to_dMonth08,
            this.to_dMonth12,
            this.to_uMonth03,
            this.to_dMonth03,
            this.to_uMonth09,
            this.to_dMonth09,
            this.to_dMonth10,
            this.to_dMonthTotal,
            this.to_uMonth04,
            this.to_dMonth04,
            this.to_uMonth10,
            this.to_uMonth11,
            this.to_dMonth11,
            this.to_uMonthTotal,
            this.to_uMonthAve,
            this.to_dMonthAve,
            this.to_uMonth02,
            this.to_dMonth02,
            this.to_uMonth01,
            this.to_dMonth01,
            this.to_uMonth07,
            this.to_dMonth07});
            this.GrandTotalFooter.Height = 0.4444444F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.GrandTotalTitle.Height = 0.16F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 1.1375F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.0625F;
            this.GrandTotalTitle.Width = 0.7F;
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
            // to_uMonth12
            // 
            this.to_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth12.DataField = "TermSalesComp";
            this.to_uMonth12.Height = 0.156F;
            this.to_uMonth12.Left = 9.047502F;
            this.to_uMonth12.MultiLine = false;
            this.to_uMonth12.Name = "to_uMonth12";
            this.to_uMonth12.OutputFormat = resources.GetString("to_uMonth12.OutputFormat");
            this.to_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth12.Text = "12,345,678";
            this.to_uMonth12.Top = 0.0625F;
            this.to_uMonth12.Width = 0.51F;
            // 
            // to_uMonth05
            // 
            this.to_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth05.DataField = "StockSalesMoney";
            this.to_uMonth05.Height = 0.156F;
            this.to_uMonth05.Left = 5.4775F;
            this.to_uMonth05.MultiLine = false;
            this.to_uMonth05.Name = "to_uMonth05";
            this.to_uMonth05.OutputFormat = resources.GetString("to_uMonth05.OutputFormat");
            this.to_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth05.Text = "12,345,678";
            this.to_uMonth05.Top = 0.0625F;
            this.to_uMonth05.Width = 0.51F;
            // 
            // to_dMonth05
            // 
            this.to_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth05.DataField = "TotalStockSalesMoney";
            this.to_dMonth05.Height = 0.156F;
            this.to_dMonth05.Left = 5.4775F;
            this.to_dMonth05.MultiLine = false;
            this.to_dMonth05.Name = "to_dMonth05";
            this.to_dMonth05.OutputFormat = resources.GetString("to_dMonth05.OutputFormat");
            this.to_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth05.Text = "12,345,678";
            this.to_dMonth05.Top = 0.25F;
            this.to_dMonth05.Width = 0.51F;
            // 
            // to_uMonth06
            // 
            this.to_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth06.DataField = "GrossMoney";
            this.to_uMonth06.Height = 0.156F;
            this.to_uMonth06.Left = 5.9875F;
            this.to_uMonth06.MultiLine = false;
            this.to_uMonth06.Name = "to_uMonth06";
            this.to_uMonth06.OutputFormat = resources.GetString("to_uMonth06.OutputFormat");
            this.to_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth06.Text = "12,345,678";
            this.to_uMonth06.Top = 0.0625F;
            this.to_uMonth06.Width = 0.51F;
            // 
            // to_dMonth06
            // 
            this.to_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth06.DataField = "TotalGrossMoney";
            this.to_dMonth06.Height = 0.156F;
            this.to_dMonth06.Left = 5.9875F;
            this.to_dMonth06.MultiLine = false;
            this.to_dMonth06.Name = "to_dMonth06";
            this.to_dMonth06.OutputFormat = resources.GetString("to_dMonth06.OutputFormat");
            this.to_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth06.Text = "12,345,678";
            this.to_dMonth06.Top = 0.25F;
            this.to_dMonth06.Width = 0.51F;
            // 
            // to_uMonth08
            // 
            this.to_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth08.DataField = "CostMoney";
            this.to_uMonth08.Height = 0.156F;
            this.to_uMonth08.Left = 7.007501F;
            this.to_uMonth08.MultiLine = false;
            this.to_uMonth08.Name = "to_uMonth08";
            this.to_uMonth08.OutputFormat = resources.GetString("to_uMonth08.OutputFormat");
            this.to_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth08.Text = "12,345,678";
            this.to_uMonth08.Top = 0.0625F;
            this.to_uMonth08.Width = 0.51F;
            // 
            // to_dMonth08
            // 
            this.to_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth08.DataField = "TotalCostMoney";
            this.to_dMonth08.Height = 0.156F;
            this.to_dMonth08.Left = 7.007501F;
            this.to_dMonth08.MultiLine = false;
            this.to_dMonth08.Name = "to_dMonth08";
            this.to_dMonth08.OutputFormat = resources.GetString("to_dMonth08.OutputFormat");
            this.to_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth08.Text = "12,345,678";
            this.to_dMonth08.Top = 0.25F;
            this.to_dMonth08.Width = 0.51F;
            // 
            // to_dMonth12
            // 
            this.to_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth12.DataField = "MonthSalesComp";
            this.to_dMonth12.Height = 0.156F;
            this.to_dMonth12.Left = 9.047502F;
            this.to_dMonth12.MultiLine = false;
            this.to_dMonth12.Name = "to_dMonth12";
            this.to_dMonth12.OutputFormat = resources.GetString("to_dMonth12.OutputFormat");
            this.to_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth12.Text = "12,345,678";
            this.to_dMonth12.Top = 0.25F;
            this.to_dMonth12.Width = 0.51F;
            // 
            // to_uMonth03
            // 
            this.to_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth03.DataField = "SalesMoney";
            this.to_uMonth03.Height = 0.156F;
            this.to_uMonth03.Left = 4.4575F;
            this.to_uMonth03.MultiLine = false;
            this.to_uMonth03.Name = "to_uMonth03";
            this.to_uMonth03.OutputFormat = resources.GetString("to_uMonth03.OutputFormat");
            this.to_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth03.Text = "12,345,678";
            this.to_uMonth03.Top = 0.0625F;
            this.to_uMonth03.Width = 0.51F;
            // 
            // to_dMonth03
            // 
            this.to_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth03.DataField = "TotalSalesMoney";
            this.to_dMonth03.Height = 0.156F;
            this.to_dMonth03.Left = 4.4575F;
            this.to_dMonth03.MultiLine = false;
            this.to_dMonth03.Name = "to_dMonth03";
            this.to_dMonth03.OutputFormat = resources.GetString("to_dMonth03.OutputFormat");
            this.to_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth03.Text = "12,345,678";
            this.to_dMonth03.Top = 0.25F;
            this.to_dMonth03.Width = 0.51F;
            // 
            // to_uMonth09
            // 
            this.to_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth09.DataField = "StockMoney";
            this.to_uMonth09.Height = 0.156F;
            this.to_uMonth09.Left = 7.517501F;
            this.to_uMonth09.MultiLine = false;
            this.to_uMonth09.Name = "to_uMonth09";
            this.to_uMonth09.OutputFormat = resources.GetString("to_uMonth09.OutputFormat");
            this.to_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth09.Text = "12,345,678";
            this.to_uMonth09.Top = 0.0625F;
            this.to_uMonth09.Width = 0.51F;
            // 
            // to_dMonth09
            // 
            this.to_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth09.DataField = "TotalStockMoney";
            this.to_dMonth09.Height = 0.156F;
            this.to_dMonth09.Left = 7.517501F;
            this.to_dMonth09.MultiLine = false;
            this.to_dMonth09.Name = "to_dMonth09";
            this.to_dMonth09.OutputFormat = resources.GetString("to_dMonth09.OutputFormat");
            this.to_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth09.Text = "12,345,678";
            this.to_dMonth09.Top = 0.25F;
            this.to_dMonth09.Width = 0.51F;
            // 
            // to_dMonth10
            // 
            this.to_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth10.DataField = "TotalOrderStockMoney";
            this.to_dMonth10.Height = 0.156F;
            this.to_dMonth10.Left = 8.027501F;
            this.to_dMonth10.MultiLine = false;
            this.to_dMonth10.Name = "to_dMonth10";
            this.to_dMonth10.OutputFormat = resources.GetString("to_dMonth10.OutputFormat");
            this.to_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth10.Text = "12,345,678";
            this.to_dMonth10.Top = 0.25F;
            this.to_dMonth10.Width = 0.51F;
            // 
            // to_dMonthTotal
            // 
            this.to_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthTotal.DataField = "MonthStockComp";
            this.to_dMonthTotal.Height = 0.156F;
            this.to_dMonthTotal.Left = 9.557502F;
            this.to_dMonthTotal.MultiLine = false;
            this.to_dMonthTotal.Name = "to_dMonthTotal";
            this.to_dMonthTotal.OutputFormat = resources.GetString("to_dMonthTotal.OutputFormat");
            this.to_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonthTotal.Text = "1,234,567,890";
            this.to_dMonthTotal.Top = 0.25F;
            this.to_dMonthTotal.Width = 0.7F;
            // 
            // to_uMonth04
            // 
            this.to_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth04.DataField = "OrderSalesMoney";
            this.to_uMonth04.Height = 0.156F;
            this.to_uMonth04.Left = 4.9675F;
            this.to_uMonth04.MultiLine = false;
            this.to_uMonth04.Name = "to_uMonth04";
            this.to_uMonth04.OutputFormat = resources.GetString("to_uMonth04.OutputFormat");
            this.to_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth04.Text = "12,345,678";
            this.to_uMonth04.Top = 0.0625F;
            this.to_uMonth04.Width = 0.51F;
            // 
            // to_dMonth04
            // 
            this.to_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth04.DataField = "TotalOrderSalesMoney";
            this.to_dMonth04.Height = 0.156F;
            this.to_dMonth04.Left = 4.9675F;
            this.to_dMonth04.MultiLine = false;
            this.to_dMonth04.Name = "to_dMonth04";
            this.to_dMonth04.OutputFormat = resources.GetString("to_dMonth04.OutputFormat");
            this.to_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth04.Text = "12,345,678";
            this.to_dMonth04.Top = 0.25F;
            this.to_dMonth04.Width = 0.51F;
            // 
            // to_uMonth10
            // 
            this.to_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth10.DataField = "OrderStockMoney";
            this.to_uMonth10.Height = 0.156F;
            this.to_uMonth10.Left = 8.027501F;
            this.to_uMonth10.MultiLine = false;
            this.to_uMonth10.Name = "to_uMonth10";
            this.to_uMonth10.OutputFormat = resources.GetString("to_uMonth10.OutputFormat");
            this.to_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth10.Text = "12,345,678";
            this.to_uMonth10.Top = 0.0625F;
            this.to_uMonth10.Width = 0.51F;
            // 
            // to_uMonth11
            // 
            this.to_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth11.DataField = "StockStockMoney";
            this.to_uMonth11.Height = 0.156F;
            this.to_uMonth11.Left = 8.537501F;
            this.to_uMonth11.MultiLine = false;
            this.to_uMonth11.Name = "to_uMonth11";
            this.to_uMonth11.OutputFormat = resources.GetString("to_uMonth11.OutputFormat");
            this.to_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth11.Text = "12,345,678";
            this.to_uMonth11.Top = 0.0625F;
            this.to_uMonth11.Width = 0.51F;
            // 
            // to_dMonth11
            // 
            this.to_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth11.DataField = "TotalStockStockMoney";
            this.to_dMonth11.Height = 0.156F;
            this.to_dMonth11.Left = 8.537501F;
            this.to_dMonth11.MultiLine = false;
            this.to_dMonth11.Name = "to_dMonth11";
            this.to_dMonth11.OutputFormat = resources.GetString("to_dMonth11.OutputFormat");
            this.to_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth11.Text = "12,345,678";
            this.to_dMonth11.Top = 0.25F;
            this.to_dMonth11.Width = 0.51F;
            // 
            // to_uMonthTotal
            // 
            this.to_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthTotal.DataField = "TermStockComp";
            this.to_uMonthTotal.Height = 0.156F;
            this.to_uMonthTotal.Left = 9.557502F;
            this.to_uMonthTotal.MultiLine = false;
            this.to_uMonthTotal.Name = "to_uMonthTotal";
            this.to_uMonthTotal.OutputFormat = resources.GetString("to_uMonthTotal.OutputFormat");
            this.to_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonthTotal.Text = "1,234,567,890";
            this.to_uMonthTotal.Top = 0.0625F;
            this.to_uMonthTotal.Width = 0.7F;
            // 
            // to_uMonthAve
            // 
            this.to_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonthAve.DataField = "Difference";
            this.to_uMonthAve.Height = 0.156F;
            this.to_uMonthAve.Left = 10.2575F;
            this.to_uMonthAve.MultiLine = false;
            this.to_uMonthAve.Name = "to_uMonthAve";
            this.to_uMonthAve.OutputFormat = resources.GetString("to_uMonthAve.OutputFormat");
            this.to_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonthAve.Text = "12,345,678";
            this.to_uMonthAve.Top = 0.0625F;
            this.to_uMonthAve.Width = 0.51F;
            // 
            // to_dMonthAve
            // 
            this.to_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonthAve.DataField = "TotalDifference";
            this.to_dMonthAve.Height = 0.156F;
            this.to_dMonthAve.Left = 10.2575F;
            this.to_dMonthAve.MultiLine = false;
            this.to_dMonthAve.Name = "to_dMonthAve";
            this.to_dMonthAve.OutputFormat = resources.GetString("to_dMonthAve.OutputFormat");
            this.to_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonthAve.Text = "12,345,678";
            this.to_dMonthAve.Top = 0.25F;
            this.to_dMonthAve.Width = 0.51F;
            // 
            // to_uMonth02
            // 
            this.to_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth02.DataField = "SalesMoney";
            this.to_uMonth02.Height = 0.156F;
            this.to_uMonth02.Left = 3.9475F;
            this.to_uMonth02.MultiLine = false;
            this.to_uMonth02.Name = "to_uMonth02";
            this.to_uMonth02.OutputFormat = resources.GetString("to_uMonth02.OutputFormat");
            this.to_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth02.Text = "12,345,678";
            this.to_uMonth02.Top = 0.0625F;
            this.to_uMonth02.Width = 0.51F;
            // 
            // to_dMonth02
            // 
            this.to_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth02.DataField = "SalesMoney";
            this.to_dMonth02.Height = 0.156F;
            this.to_dMonth02.Left = 3.9475F;
            this.to_dMonth02.MultiLine = false;
            this.to_dMonth02.Name = "to_dMonth02";
            this.to_dMonth02.OutputFormat = resources.GetString("to_dMonth02.OutputFormat");
            this.to_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth02.Text = "12,345,678";
            this.to_dMonth02.Top = 0.25F;
            this.to_dMonth02.Width = 0.51F;
            // 
            // to_uMonth01
            // 
            this.to_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth01.DataField = "SalesMoney";
            this.to_uMonth01.Height = 0.156F;
            this.to_uMonth01.Left = 3.4375F;
            this.to_uMonth01.MultiLine = false;
            this.to_uMonth01.Name = "to_uMonth01";
            this.to_uMonth01.OutputFormat = resources.GetString("to_uMonth01.OutputFormat");
            this.to_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth01.Text = "12,345,678";
            this.to_uMonth01.Top = 0.0625F;
            this.to_uMonth01.Width = 0.51F;
            // 
            // to_dMonth01
            // 
            this.to_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth01.DataField = "SalesMoney";
            this.to_dMonth01.Height = 0.156F;
            this.to_dMonth01.Left = 3.4375F;
            this.to_dMonth01.MultiLine = false;
            this.to_dMonth01.Name = "to_dMonth01";
            this.to_dMonth01.OutputFormat = resources.GetString("to_dMonth01.OutputFormat");
            this.to_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth01.Text = "12,345,678";
            this.to_dMonth01.Top = 0.25F;
            this.to_dMonth01.Width = 0.51F;
            // 
            // to_uMonth07
            // 
            this.to_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.to_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.to_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.to_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.to_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_uMonth07.DataField = "SalesMoney";
            this.to_uMonth07.Height = 0.156F;
            this.to_uMonth07.Left = 6.4975F;
            this.to_uMonth07.MultiLine = false;
            this.to_uMonth07.Name = "to_uMonth07";
            this.to_uMonth07.OutputFormat = resources.GetString("to_uMonth07.OutputFormat");
            this.to_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_uMonth07.Text = "12,345,678";
            this.to_uMonth07.Top = 0.0625F;
            this.to_uMonth07.Width = 0.51F;
            // 
            // to_dMonth07
            // 
            this.to_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.to_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.to_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.to_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.to_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.to_dMonth07.DataField = "SalesMoney";
            this.to_dMonth07.Height = 0.156F;
            this.to_dMonth07.Left = 6.4975F;
            this.to_dMonth07.MultiLine = false;
            this.to_dMonth07.Name = "to_dMonth07";
            this.to_dMonth07.OutputFormat = resources.GetString("to_dMonth07.OutputFormat");
            this.to_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.to_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.to_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.to_dMonth07.Text = "12,345,678";
            this.to_dMonth07.Top = 0.25F;
            this.to_dMonth07.Width = 0.51F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.DataField = "SectionHeaderField";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Visible = false;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SectionTitle,
            this.se_uMonth12,
            this.se_uMonth05,
            this.se_uMonth06,
            this.se_dMonth05,
            this.se_dMonth06,
            this.se_uMonth08,
            this.se_dMonth08,
            this.se_dMonth12,
            this.se_dMonth04,
            this.se_uMonth09,
            this.se_dMonth09,
            this.se_dMonth10,
            this.se_uMonth04,
            this.se_dMonth03,
            this.se_uMonth10,
            this.se_uMonth11,
            this.se_dMonth11,
            this.se_uMonthTotal,
            this.se_dMonthTotal,
            this.se_uMonthAve,
            this.se_dMonthAve,
            this.se_uMonth03,
            this.se_uMonth02,
            this.se_dMonth02,
            this.se_uMonth01,
            this.se_dMonth01,
            this.se_uMonth07,
            this.se_dMonth07});
            this.SectionFooter.Height = 0.4444444F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
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
            this.SectionTitle.Height = 0.16F;
            this.SectionTitle.Left = 1.1375F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0.0625F;
            this.SectionTitle.Width = 0.7F;
            // 
            // se_uMonth12
            // 
            this.se_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth12.DataField = "TermSalesComp";
            this.se_uMonth12.Height = 0.156F;
            this.se_uMonth12.Left = 9.047502F;
            this.se_uMonth12.MultiLine = false;
            this.se_uMonth12.Name = "se_uMonth12";
            this.se_uMonth12.OutputFormat = resources.GetString("se_uMonth12.OutputFormat");
            this.se_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth12.SummaryGroup = "SectionHeader";
            this.se_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth12.Text = "12,345,678";
            this.se_uMonth12.Top = 0.0625F;
            this.se_uMonth12.Width = 0.51F;
            // 
            // se_uMonth05
            // 
            this.se_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth05.DataField = "StockSalesMoney";
            this.se_uMonth05.Height = 0.156F;
            this.se_uMonth05.Left = 5.4775F;
            this.se_uMonth05.MultiLine = false;
            this.se_uMonth05.Name = "se_uMonth05";
            this.se_uMonth05.OutputFormat = resources.GetString("se_uMonth05.OutputFormat");
            this.se_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth05.SummaryGroup = "SectionHeader";
            this.se_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth05.Text = "12,345,678";
            this.se_uMonth05.Top = 0.0625F;
            this.se_uMonth05.Width = 0.51F;
            // 
            // se_uMonth06
            // 
            this.se_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth06.DataField = "GrossMoney";
            this.se_uMonth06.Height = 0.156F;
            this.se_uMonth06.Left = 5.9875F;
            this.se_uMonth06.MultiLine = false;
            this.se_uMonth06.Name = "se_uMonth06";
            this.se_uMonth06.OutputFormat = resources.GetString("se_uMonth06.OutputFormat");
            this.se_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth06.SummaryGroup = "SectionHeader";
            this.se_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth06.Text = "12,345,678";
            this.se_uMonth06.Top = 0.0625F;
            this.se_uMonth06.Width = 0.51F;
            // 
            // se_dMonth05
            // 
            this.se_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth05.DataField = "TotalStockSalesMoney";
            this.se_dMonth05.Height = 0.156F;
            this.se_dMonth05.Left = 5.4775F;
            this.se_dMonth05.MultiLine = false;
            this.se_dMonth05.Name = "se_dMonth05";
            this.se_dMonth05.OutputFormat = resources.GetString("se_dMonth05.OutputFormat");
            this.se_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth05.SummaryGroup = "SectionHeader";
            this.se_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth05.Text = "12,345,678";
            this.se_dMonth05.Top = 0.25F;
            this.se_dMonth05.Width = 0.51F;
            // 
            // se_dMonth06
            // 
            this.se_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth06.DataField = "TotalGrossMoney";
            this.se_dMonth06.Height = 0.156F;
            this.se_dMonth06.Left = 5.9875F;
            this.se_dMonth06.MultiLine = false;
            this.se_dMonth06.Name = "se_dMonth06";
            this.se_dMonth06.OutputFormat = resources.GetString("se_dMonth06.OutputFormat");
            this.se_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth06.SummaryGroup = "SectionHeader";
            this.se_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth06.Text = "12,345,678";
            this.se_dMonth06.Top = 0.25F;
            this.se_dMonth06.Width = 0.51F;
            // 
            // se_uMonth08
            // 
            this.se_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth08.DataField = "CostMoney";
            this.se_uMonth08.Height = 0.156F;
            this.se_uMonth08.Left = 7.007501F;
            this.se_uMonth08.MultiLine = false;
            this.se_uMonth08.Name = "se_uMonth08";
            this.se_uMonth08.OutputFormat = resources.GetString("se_uMonth08.OutputFormat");
            this.se_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth08.SummaryGroup = "SectionHeader";
            this.se_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth08.Text = "12,345,678";
            this.se_uMonth08.Top = 0.0625F;
            this.se_uMonth08.Width = 0.51F;
            // 
            // se_dMonth08
            // 
            this.se_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth08.DataField = "TotalCostMoney";
            this.se_dMonth08.Height = 0.156F;
            this.se_dMonth08.Left = 7.007501F;
            this.se_dMonth08.MultiLine = false;
            this.se_dMonth08.Name = "se_dMonth08";
            this.se_dMonth08.OutputFormat = resources.GetString("se_dMonth08.OutputFormat");
            this.se_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth08.SummaryGroup = "SectionHeader";
            this.se_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth08.Text = "12,345,678";
            this.se_dMonth08.Top = 0.25F;
            this.se_dMonth08.Width = 0.51F;
            // 
            // se_dMonth12
            // 
            this.se_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth12.DataField = "MonthSalesComp";
            this.se_dMonth12.Height = 0.156F;
            this.se_dMonth12.Left = 9.047502F;
            this.se_dMonth12.MultiLine = false;
            this.se_dMonth12.Name = "se_dMonth12";
            this.se_dMonth12.OutputFormat = resources.GetString("se_dMonth12.OutputFormat");
            this.se_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth12.SummaryGroup = "SectionHeader";
            this.se_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth12.Text = "12,345,678";
            this.se_dMonth12.Top = 0.25F;
            this.se_dMonth12.Width = 0.51F;
            // 
            // se_dMonth04
            // 
            this.se_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth04.DataField = "TotalOrderSalesMoney";
            this.se_dMonth04.Height = 0.156F;
            this.se_dMonth04.Left = 4.9675F;
            this.se_dMonth04.MultiLine = false;
            this.se_dMonth04.Name = "se_dMonth04";
            this.se_dMonth04.OutputFormat = resources.GetString("se_dMonth04.OutputFormat");
            this.se_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth04.SummaryGroup = "SectionHeader";
            this.se_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth04.Text = "12,345,678";
            this.se_dMonth04.Top = 0.25F;
            this.se_dMonth04.Width = 0.51F;
            // 
            // se_uMonth09
            // 
            this.se_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth09.DataField = "StockMoney";
            this.se_uMonth09.Height = 0.156F;
            this.se_uMonth09.Left = 7.517501F;
            this.se_uMonth09.MultiLine = false;
            this.se_uMonth09.Name = "se_uMonth09";
            this.se_uMonth09.OutputFormat = resources.GetString("se_uMonth09.OutputFormat");
            this.se_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth09.SummaryGroup = "SectionHeader";
            this.se_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth09.Text = "12,345,678";
            this.se_uMonth09.Top = 0.0625F;
            this.se_uMonth09.Width = 0.51F;
            // 
            // se_dMonth09
            // 
            this.se_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth09.DataField = "TotalStockMoney";
            this.se_dMonth09.Height = 0.156F;
            this.se_dMonth09.Left = 7.517501F;
            this.se_dMonth09.MultiLine = false;
            this.se_dMonth09.Name = "se_dMonth09";
            this.se_dMonth09.OutputFormat = resources.GetString("se_dMonth09.OutputFormat");
            this.se_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth09.SummaryGroup = "SectionHeader";
            this.se_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth09.Text = "12,345,678";
            this.se_dMonth09.Top = 0.25F;
            this.se_dMonth09.Width = 0.51F;
            // 
            // se_dMonth10
            // 
            this.se_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth10.DataField = "TotalOrderStockMoney";
            this.se_dMonth10.Height = 0.156F;
            this.se_dMonth10.Left = 8.027501F;
            this.se_dMonth10.MultiLine = false;
            this.se_dMonth10.Name = "se_dMonth10";
            this.se_dMonth10.OutputFormat = resources.GetString("se_dMonth10.OutputFormat");
            this.se_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth10.SummaryGroup = "SectionHeader";
            this.se_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth10.Text = "12,345,678";
            this.se_dMonth10.Top = 0.25F;
            this.se_dMonth10.Width = 0.51F;
            // 
            // se_uMonth04
            // 
            this.se_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth04.DataField = "OrderSalesMoney";
            this.se_uMonth04.Height = 0.156F;
            this.se_uMonth04.Left = 4.9675F;
            this.se_uMonth04.MultiLine = false;
            this.se_uMonth04.Name = "se_uMonth04";
            this.se_uMonth04.OutputFormat = resources.GetString("se_uMonth04.OutputFormat");
            this.se_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth04.SummaryGroup = "SectionHeader";
            this.se_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth04.Text = "12,345,678";
            this.se_uMonth04.Top = 0.0625F;
            this.se_uMonth04.Width = 0.51F;
            // 
            // se_dMonth03
            // 
            this.se_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth03.DataField = "TotalSalesMoney";
            this.se_dMonth03.Height = 0.156F;
            this.se_dMonth03.Left = 4.4575F;
            this.se_dMonth03.MultiLine = false;
            this.se_dMonth03.Name = "se_dMonth03";
            this.se_dMonth03.OutputFormat = resources.GetString("se_dMonth03.OutputFormat");
            this.se_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth03.SummaryGroup = "SectionHeader";
            this.se_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth03.Text = "12,345,678";
            this.se_dMonth03.Top = 0.25F;
            this.se_dMonth03.Width = 0.51F;
            // 
            // se_uMonth10
            // 
            this.se_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth10.DataField = "OrderStockMoney";
            this.se_uMonth10.Height = 0.156F;
            this.se_uMonth10.Left = 8.027501F;
            this.se_uMonth10.MultiLine = false;
            this.se_uMonth10.Name = "se_uMonth10";
            this.se_uMonth10.OutputFormat = resources.GetString("se_uMonth10.OutputFormat");
            this.se_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth10.SummaryGroup = "SectionHeader";
            this.se_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth10.Text = "12,345,678";
            this.se_uMonth10.Top = 0.0625F;
            this.se_uMonth10.Width = 0.51F;
            // 
            // se_uMonth11
            // 
            this.se_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth11.DataField = "StockStockMoney";
            this.se_uMonth11.Height = 0.156F;
            this.se_uMonth11.Left = 8.537501F;
            this.se_uMonth11.MultiLine = false;
            this.se_uMonth11.Name = "se_uMonth11";
            this.se_uMonth11.OutputFormat = resources.GetString("se_uMonth11.OutputFormat");
            this.se_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth11.SummaryGroup = "SectionHeader";
            this.se_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth11.Text = "12,345,678";
            this.se_uMonth11.Top = 0.0625F;
            this.se_uMonth11.Width = 0.51F;
            // 
            // se_dMonth11
            // 
            this.se_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth11.DataField = "TotalStockStockMoney";
            this.se_dMonth11.Height = 0.156F;
            this.se_dMonth11.Left = 8.537501F;
            this.se_dMonth11.MultiLine = false;
            this.se_dMonth11.Name = "se_dMonth11";
            this.se_dMonth11.OutputFormat = resources.GetString("se_dMonth11.OutputFormat");
            this.se_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth11.SummaryGroup = "SectionHeader";
            this.se_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth11.Text = "12,345,678";
            this.se_dMonth11.Top = 0.25F;
            this.se_dMonth11.Width = 0.51F;
            // 
            // se_uMonthTotal
            // 
            this.se_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthTotal.DataField = "TermStockComp";
            this.se_uMonthTotal.Height = 0.156F;
            this.se_uMonthTotal.Left = 9.557502F;
            this.se_uMonthTotal.MultiLine = false;
            this.se_uMonthTotal.Name = "se_uMonthTotal";
            this.se_uMonthTotal.OutputFormat = resources.GetString("se_uMonthTotal.OutputFormat");
            this.se_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonthTotal.SummaryGroup = "SectionHeader";
            this.se_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonthTotal.Text = "1,234,567,890";
            this.se_uMonthTotal.Top = 0.0625F;
            this.se_uMonthTotal.Width = 0.7F;
            // 
            // se_dMonthTotal
            // 
            this.se_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthTotal.DataField = "MonthStockComp";
            this.se_dMonthTotal.Height = 0.156F;
            this.se_dMonthTotal.Left = 9.557502F;
            this.se_dMonthTotal.MultiLine = false;
            this.se_dMonthTotal.Name = "se_dMonthTotal";
            this.se_dMonthTotal.OutputFormat = resources.GetString("se_dMonthTotal.OutputFormat");
            this.se_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonthTotal.SummaryGroup = "SectionHeader";
            this.se_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonthTotal.Text = "1,234,567,890";
            this.se_dMonthTotal.Top = 0.25F;
            this.se_dMonthTotal.Width = 0.7F;
            // 
            // se_uMonthAve
            // 
            this.se_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonthAve.DataField = "Difference";
            this.se_uMonthAve.Height = 0.156F;
            this.se_uMonthAve.Left = 10.2575F;
            this.se_uMonthAve.MultiLine = false;
            this.se_uMonthAve.Name = "se_uMonthAve";
            this.se_uMonthAve.OutputFormat = resources.GetString("se_uMonthAve.OutputFormat");
            this.se_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonthAve.SummaryGroup = "SectionHeader";
            this.se_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonthAve.Text = "12,345,678";
            this.se_uMonthAve.Top = 0.0625F;
            this.se_uMonthAve.Width = 0.51F;
            // 
            // se_dMonthAve
            // 
            this.se_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonthAve.DataField = "TotalDifference";
            this.se_dMonthAve.Height = 0.156F;
            this.se_dMonthAve.Left = 10.2575F;
            this.se_dMonthAve.MultiLine = false;
            this.se_dMonthAve.Name = "se_dMonthAve";
            this.se_dMonthAve.OutputFormat = resources.GetString("se_dMonthAve.OutputFormat");
            this.se_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonthAve.SummaryGroup = "SectionHeader";
            this.se_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonthAve.Text = "12,345,678";
            this.se_dMonthAve.Top = 0.25F;
            this.se_dMonthAve.Width = 0.51F;
            // 
            // se_uMonth03
            // 
            this.se_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth03.DataField = "SalesMoney";
            this.se_uMonth03.Height = 0.156F;
            this.se_uMonth03.Left = 4.4575F;
            this.se_uMonth03.MultiLine = false;
            this.se_uMonth03.Name = "se_uMonth03";
            this.se_uMonth03.OutputFormat = resources.GetString("se_uMonth03.OutputFormat");
            this.se_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth03.SummaryGroup = "SectionHeader";
            this.se_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth03.Text = "12,345,678";
            this.se_uMonth03.Top = 0.0625F;
            this.se_uMonth03.Width = 0.51F;
            // 
            // se_uMonth02
            // 
            this.se_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth02.DataField = "SalesMoney";
            this.se_uMonth02.Height = 0.156F;
            this.se_uMonth02.Left = 3.9475F;
            this.se_uMonth02.MultiLine = false;
            this.se_uMonth02.Name = "se_uMonth02";
            this.se_uMonth02.OutputFormat = resources.GetString("se_uMonth02.OutputFormat");
            this.se_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth02.SummaryGroup = "SectionHeader";
            this.se_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth02.Text = "12,345,678";
            this.se_uMonth02.Top = 0.0625F;
            this.se_uMonth02.Width = 0.51F;
            // 
            // se_dMonth02
            // 
            this.se_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth02.DataField = "SalesMoney";
            this.se_dMonth02.Height = 0.156F;
            this.se_dMonth02.Left = 3.9475F;
            this.se_dMonth02.MultiLine = false;
            this.se_dMonth02.Name = "se_dMonth02";
            this.se_dMonth02.OutputFormat = resources.GetString("se_dMonth02.OutputFormat");
            this.se_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth02.SummaryGroup = "SectionHeader";
            this.se_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth02.Text = "12,345,678";
            this.se_dMonth02.Top = 0.25F;
            this.se_dMonth02.Width = 0.51F;
            // 
            // se_uMonth01
            // 
            this.se_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth01.DataField = "SalesMoney";
            this.se_uMonth01.Height = 0.156F;
            this.se_uMonth01.Left = 3.4375F;
            this.se_uMonth01.MultiLine = false;
            this.se_uMonth01.Name = "se_uMonth01";
            this.se_uMonth01.OutputFormat = resources.GetString("se_uMonth01.OutputFormat");
            this.se_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth01.SummaryGroup = "SectionHeader";
            this.se_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth01.Text = "12,345,678";
            this.se_uMonth01.Top = 0.0625F;
            this.se_uMonth01.Width = 0.51F;
            // 
            // se_dMonth01
            // 
            this.se_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth01.DataField = "SalesMoney";
            this.se_dMonth01.Height = 0.156F;
            this.se_dMonth01.Left = 3.4375F;
            this.se_dMonth01.MultiLine = false;
            this.se_dMonth01.Name = "se_dMonth01";
            this.se_dMonth01.OutputFormat = resources.GetString("se_dMonth01.OutputFormat");
            this.se_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth01.SummaryGroup = "SectionHeader";
            this.se_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth01.Text = "12,345,678";
            this.se_dMonth01.Top = 0.25F;
            this.se_dMonth01.Width = 0.51F;
            // 
            // se_uMonth07
            // 
            this.se_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.se_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.se_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.se_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.se_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_uMonth07.DataField = "SalesMoney";
            this.se_uMonth07.Height = 0.156F;
            this.se_uMonth07.Left = 6.4975F;
            this.se_uMonth07.MultiLine = false;
            this.se_uMonth07.Name = "se_uMonth07";
            this.se_uMonth07.OutputFormat = resources.GetString("se_uMonth07.OutputFormat");
            this.se_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_uMonth07.SummaryGroup = "SectionHeader";
            this.se_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_uMonth07.Text = "12,345,678";
            this.se_uMonth07.Top = 0.0625F;
            this.se_uMonth07.Width = 0.51F;
            // 
            // se_dMonth07
            // 
            this.se_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.se_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.se_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.se_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.se_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.se_dMonth07.DataField = "SalesMoney";
            this.se_dMonth07.Height = 0.156F;
            this.se_dMonth07.Left = 6.4975F;
            this.se_dMonth07.MultiLine = false;
            this.se_dMonth07.Name = "se_dMonth07";
            this.se_dMonth07.OutputFormat = resources.GetString("se_dMonth07.OutputFormat");
            this.se_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.se_dMonth07.SummaryGroup = "SectionHeader";
            this.se_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.se_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.se_dMonth07.Text = "12,345,678";
            this.se_dMonth07.Top = 0.25F;
            this.se_dMonth07.Width = 0.51F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.CanShrink = true;
            this.MakerHeader.DataField = "MakerField";
            this.MakerHeader.Height = 0F;
            this.MakerHeader.KeepTogether = true;
            this.MakerHeader.Name = "MakerHeader";
            this.MakerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.MakerHeader.Visible = false;
            // 
            // MakerFooter
            // 
            this.MakerFooter.CanShrink = true;
            this.MakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11,
            this.mk_uMonth12,
            this.mk_uMonth05,
            this.mk_dMonth05,
            this.mk_uMonth06,
            this.mk_uMonth08,
            this.mk_dMonth06,
            this.mk_dMonth08,
            this.mk_dMonth12,
            this.mk_uMonth03,
            this.mk_dMonth04,
            this.mk_uMonth09,
            this.mk_dMonth09,
            this.mk_dMonth10,
            this.mk_dMonthTotal,
            this.mk_uMonth04,
            this.mk_dMonth03,
            this.mk_uMonth10,
            this.mk_uMonth11,
            this.mk_dMonth11,
            this.mk_uMonthTotal,
            this.mk_uMonthAve,
            this.mk_dMonthAve,
            this.mk_uMonth07,
            this.mk_dMonth07,
            this.mk_uMonth02,
            this.mk_dMonth02,
            this.mk_uMonth01,
            this.mk_dMonth01,
            this.line3,
            this.subTotalMaker_GoodsMakerCd,
            this.subTotalMaker_MakerShortName});
            this.MakerFooter.Height = 0.4375F;
            this.MakerFooter.KeepTogether = true;
            this.MakerFooter.Name = "MakerFooter";
            this.MakerFooter.Visible = false;
            this.MakerFooter.Format += new System.EventHandler(this.MakerFooter_Format);
            this.MakerFooter.BeforePrint += new System.EventHandler(this.MakerFooter_BeforePrint);
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
            this.textBox11.Height = 0.16F;
            this.textBox11.Left = 1.1375F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox11.Text = "メーカー計";
            this.textBox11.Top = 0.0625F;
            this.textBox11.Width = 0.7F;
            // 
            // mk_uMonth12
            // 
            this.mk_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth12.DataField = "TermSalesComp";
            this.mk_uMonth12.Height = 0.156F;
            this.mk_uMonth12.Left = 9.047502F;
            this.mk_uMonth12.MultiLine = false;
            this.mk_uMonth12.Name = "mk_uMonth12";
            this.mk_uMonth12.OutputFormat = resources.GetString("mk_uMonth12.OutputFormat");
            this.mk_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth12.SummaryGroup = "MakerHeader";
            this.mk_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth12.Text = "12,345,678";
            this.mk_uMonth12.Top = 0.0625F;
            this.mk_uMonth12.Width = 0.51F;
            // 
            // mk_uMonth05
            // 
            this.mk_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth05.DataField = "StockSalesMoney";
            this.mk_uMonth05.Height = 0.156F;
            this.mk_uMonth05.Left = 5.4775F;
            this.mk_uMonth05.MultiLine = false;
            this.mk_uMonth05.Name = "mk_uMonth05";
            this.mk_uMonth05.OutputFormat = resources.GetString("mk_uMonth05.OutputFormat");
            this.mk_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth05.SummaryGroup = "MakerHeader";
            this.mk_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth05.Text = "12,345,678";
            this.mk_uMonth05.Top = 0.0625F;
            this.mk_uMonth05.Width = 0.51F;
            // 
            // mk_dMonth05
            // 
            this.mk_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth05.DataField = "TotalStockSalesMoney";
            this.mk_dMonth05.Height = 0.156F;
            this.mk_dMonth05.Left = 5.4775F;
            this.mk_dMonth05.MultiLine = false;
            this.mk_dMonth05.Name = "mk_dMonth05";
            this.mk_dMonth05.OutputFormat = resources.GetString("mk_dMonth05.OutputFormat");
            this.mk_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth05.SummaryGroup = "MakerHeader";
            this.mk_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth05.Text = "12,345,678";
            this.mk_dMonth05.Top = 0.25F;
            this.mk_dMonth05.Width = 0.51F;
            // 
            // mk_uMonth06
            // 
            this.mk_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth06.DataField = "GrossMoney";
            this.mk_uMonth06.Height = 0.156F;
            this.mk_uMonth06.Left = 5.9875F;
            this.mk_uMonth06.MultiLine = false;
            this.mk_uMonth06.Name = "mk_uMonth06";
            this.mk_uMonth06.OutputFormat = resources.GetString("mk_uMonth06.OutputFormat");
            this.mk_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth06.SummaryGroup = "MakerHeader";
            this.mk_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth06.Text = "12,345,678";
            this.mk_uMonth06.Top = 0.0625F;
            this.mk_uMonth06.Width = 0.51F;
            // 
            // mk_uMonth08
            // 
            this.mk_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth08.DataField = "CostMoney";
            this.mk_uMonth08.Height = 0.156F;
            this.mk_uMonth08.Left = 7.007501F;
            this.mk_uMonth08.MultiLine = false;
            this.mk_uMonth08.Name = "mk_uMonth08";
            this.mk_uMonth08.OutputFormat = resources.GetString("mk_uMonth08.OutputFormat");
            this.mk_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth08.SummaryGroup = "MakerHeader";
            this.mk_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth08.Text = "12,345,678";
            this.mk_uMonth08.Top = 0.0625F;
            this.mk_uMonth08.Width = 0.51F;
            // 
            // mk_dMonth06
            // 
            this.mk_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth06.DataField = "TotalGrossMoney";
            this.mk_dMonth06.Height = 0.156F;
            this.mk_dMonth06.Left = 5.9875F;
            this.mk_dMonth06.MultiLine = false;
            this.mk_dMonth06.Name = "mk_dMonth06";
            this.mk_dMonth06.OutputFormat = resources.GetString("mk_dMonth06.OutputFormat");
            this.mk_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth06.SummaryGroup = "MakerHeader";
            this.mk_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth06.Text = "12,345,678";
            this.mk_dMonth06.Top = 0.25F;
            this.mk_dMonth06.Width = 0.51F;
            // 
            // mk_dMonth08
            // 
            this.mk_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth08.DataField = "TotalCostMoney";
            this.mk_dMonth08.Height = 0.156F;
            this.mk_dMonth08.Left = 7.007501F;
            this.mk_dMonth08.MultiLine = false;
            this.mk_dMonth08.Name = "mk_dMonth08";
            this.mk_dMonth08.OutputFormat = resources.GetString("mk_dMonth08.OutputFormat");
            this.mk_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth08.SummaryGroup = "MakerHeader";
            this.mk_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth08.Text = "12,345,678";
            this.mk_dMonth08.Top = 0.25F;
            this.mk_dMonth08.Width = 0.51F;
            // 
            // mk_dMonth12
            // 
            this.mk_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth12.DataField = "MonthSalesComp";
            this.mk_dMonth12.Height = 0.156F;
            this.mk_dMonth12.Left = 9.047502F;
            this.mk_dMonth12.MultiLine = false;
            this.mk_dMonth12.Name = "mk_dMonth12";
            this.mk_dMonth12.OutputFormat = resources.GetString("mk_dMonth12.OutputFormat");
            this.mk_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth12.SummaryGroup = "MakerHeader";
            this.mk_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth12.Text = "12,345,678";
            this.mk_dMonth12.Top = 0.25F;
            this.mk_dMonth12.Width = 0.51F;
            // 
            // mk_uMonth03
            // 
            this.mk_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth03.DataField = "SalesMoney";
            this.mk_uMonth03.Height = 0.156F;
            this.mk_uMonth03.Left = 4.4575F;
            this.mk_uMonth03.MultiLine = false;
            this.mk_uMonth03.Name = "mk_uMonth03";
            this.mk_uMonth03.OutputFormat = resources.GetString("mk_uMonth03.OutputFormat");
            this.mk_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth03.SummaryGroup = "MakerHeader";
            this.mk_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth03.Text = "12,345,678";
            this.mk_uMonth03.Top = 0.0625F;
            this.mk_uMonth03.Width = 0.51F;
            // 
            // mk_dMonth04
            // 
            this.mk_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth04.DataField = "TotalOrderSalesMoney";
            this.mk_dMonth04.Height = 0.156F;
            this.mk_dMonth04.Left = 4.9675F;
            this.mk_dMonth04.MultiLine = false;
            this.mk_dMonth04.Name = "mk_dMonth04";
            this.mk_dMonth04.OutputFormat = resources.GetString("mk_dMonth04.OutputFormat");
            this.mk_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth04.SummaryGroup = "MakerHeader";
            this.mk_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth04.Text = "12,345,678";
            this.mk_dMonth04.Top = 0.25F;
            this.mk_dMonth04.Width = 0.51F;
            // 
            // mk_uMonth09
            // 
            this.mk_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth09.DataField = "StockMoney";
            this.mk_uMonth09.Height = 0.156F;
            this.mk_uMonth09.Left = 7.517501F;
            this.mk_uMonth09.MultiLine = false;
            this.mk_uMonth09.Name = "mk_uMonth09";
            this.mk_uMonth09.OutputFormat = resources.GetString("mk_uMonth09.OutputFormat");
            this.mk_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth09.SummaryGroup = "MakerHeader";
            this.mk_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth09.Text = "12,345,678";
            this.mk_uMonth09.Top = 0.0625F;
            this.mk_uMonth09.Width = 0.51F;
            // 
            // mk_dMonth09
            // 
            this.mk_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth09.DataField = "TotalStockMoney";
            this.mk_dMonth09.Height = 0.156F;
            this.mk_dMonth09.Left = 7.517501F;
            this.mk_dMonth09.MultiLine = false;
            this.mk_dMonth09.Name = "mk_dMonth09";
            this.mk_dMonth09.OutputFormat = resources.GetString("mk_dMonth09.OutputFormat");
            this.mk_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth09.SummaryGroup = "MakerHeader";
            this.mk_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth09.Text = "12,345,678";
            this.mk_dMonth09.Top = 0.25F;
            this.mk_dMonth09.Width = 0.51F;
            // 
            // mk_dMonth10
            // 
            this.mk_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth10.DataField = "TotalOrderStockMoney";
            this.mk_dMonth10.Height = 0.156F;
            this.mk_dMonth10.Left = 8.027501F;
            this.mk_dMonth10.MultiLine = false;
            this.mk_dMonth10.Name = "mk_dMonth10";
            this.mk_dMonth10.OutputFormat = resources.GetString("mk_dMonth10.OutputFormat");
            this.mk_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth10.SummaryGroup = "MakerHeader";
            this.mk_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth10.Text = "12,345,678";
            this.mk_dMonth10.Top = 0.25F;
            this.mk_dMonth10.Width = 0.51F;
            // 
            // mk_dMonthTotal
            // 
            this.mk_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthTotal.DataField = "MonthStockComp";
            this.mk_dMonthTotal.Height = 0.156F;
            this.mk_dMonthTotal.Left = 9.557502F;
            this.mk_dMonthTotal.MultiLine = false;
            this.mk_dMonthTotal.Name = "mk_dMonthTotal";
            this.mk_dMonthTotal.OutputFormat = resources.GetString("mk_dMonthTotal.OutputFormat");
            this.mk_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonthTotal.SummaryGroup = "MakerHeader";
            this.mk_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonthTotal.Text = "1,234,567,890";
            this.mk_dMonthTotal.Top = 0.25F;
            this.mk_dMonthTotal.Width = 0.7F;
            // 
            // mk_uMonth04
            // 
            this.mk_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth04.DataField = "OrderSalesMoney";
            this.mk_uMonth04.Height = 0.156F;
            this.mk_uMonth04.Left = 4.9675F;
            this.mk_uMonth04.MultiLine = false;
            this.mk_uMonth04.Name = "mk_uMonth04";
            this.mk_uMonth04.OutputFormat = resources.GetString("mk_uMonth04.OutputFormat");
            this.mk_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth04.SummaryGroup = "MakerHeader";
            this.mk_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth04.Text = "12,345,678";
            this.mk_uMonth04.Top = 0.0625F;
            this.mk_uMonth04.Width = 0.51F;
            // 
            // mk_dMonth03
            // 
            this.mk_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth03.DataField = "TotalSalesMoney";
            this.mk_dMonth03.Height = 0.156F;
            this.mk_dMonth03.Left = 4.4575F;
            this.mk_dMonth03.MultiLine = false;
            this.mk_dMonth03.Name = "mk_dMonth03";
            this.mk_dMonth03.OutputFormat = resources.GetString("mk_dMonth03.OutputFormat");
            this.mk_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth03.SummaryGroup = "MakerHeader";
            this.mk_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth03.Text = "12,345,678";
            this.mk_dMonth03.Top = 0.25F;
            this.mk_dMonth03.Width = 0.51F;
            // 
            // mk_uMonth10
            // 
            this.mk_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth10.DataField = "OrderStockMoney";
            this.mk_uMonth10.Height = 0.156F;
            this.mk_uMonth10.Left = 8.027501F;
            this.mk_uMonth10.MultiLine = false;
            this.mk_uMonth10.Name = "mk_uMonth10";
            this.mk_uMonth10.OutputFormat = resources.GetString("mk_uMonth10.OutputFormat");
            this.mk_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth10.SummaryGroup = "MakerHeader";
            this.mk_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth10.Text = "12,345,678";
            this.mk_uMonth10.Top = 0.0625F;
            this.mk_uMonth10.Width = 0.51F;
            // 
            // mk_uMonth11
            // 
            this.mk_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth11.DataField = "StockStockMoney";
            this.mk_uMonth11.Height = 0.156F;
            this.mk_uMonth11.Left = 8.537501F;
            this.mk_uMonth11.MultiLine = false;
            this.mk_uMonth11.Name = "mk_uMonth11";
            this.mk_uMonth11.OutputFormat = resources.GetString("mk_uMonth11.OutputFormat");
            this.mk_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth11.SummaryGroup = "MakerHeader";
            this.mk_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth11.Text = "12,345,678";
            this.mk_uMonth11.Top = 0.0625F;
            this.mk_uMonth11.Width = 0.51F;
            // 
            // mk_dMonth11
            // 
            this.mk_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth11.DataField = "TotalStockStockMoney";
            this.mk_dMonth11.Height = 0.156F;
            this.mk_dMonth11.Left = 8.537501F;
            this.mk_dMonth11.MultiLine = false;
            this.mk_dMonth11.Name = "mk_dMonth11";
            this.mk_dMonth11.OutputFormat = resources.GetString("mk_dMonth11.OutputFormat");
            this.mk_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth11.SummaryGroup = "MakerHeader";
            this.mk_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth11.Text = "12,345,678";
            this.mk_dMonth11.Top = 0.25F;
            this.mk_dMonth11.Width = 0.51F;
            // 
            // mk_uMonthTotal
            // 
            this.mk_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthTotal.DataField = "TermStockComp";
            this.mk_uMonthTotal.Height = 0.156F;
            this.mk_uMonthTotal.Left = 9.557502F;
            this.mk_uMonthTotal.MultiLine = false;
            this.mk_uMonthTotal.Name = "mk_uMonthTotal";
            this.mk_uMonthTotal.OutputFormat = resources.GetString("mk_uMonthTotal.OutputFormat");
            this.mk_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonthTotal.SummaryGroup = "MakerHeader";
            this.mk_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonthTotal.Text = "1,234,567,890";
            this.mk_uMonthTotal.Top = 0.0625F;
            this.mk_uMonthTotal.Width = 0.7F;
            // 
            // mk_uMonthAve
            // 
            this.mk_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonthAve.DataField = "Difference";
            this.mk_uMonthAve.Height = 0.156F;
            this.mk_uMonthAve.Left = 10.2575F;
            this.mk_uMonthAve.MultiLine = false;
            this.mk_uMonthAve.Name = "mk_uMonthAve";
            this.mk_uMonthAve.OutputFormat = resources.GetString("mk_uMonthAve.OutputFormat");
            this.mk_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonthAve.SummaryGroup = "MakerHeader";
            this.mk_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonthAve.Text = "12,345,678";
            this.mk_uMonthAve.Top = 0.0625F;
            this.mk_uMonthAve.Width = 0.51F;
            // 
            // mk_dMonthAve
            // 
            this.mk_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonthAve.DataField = "TotalDifference";
            this.mk_dMonthAve.Height = 0.156F;
            this.mk_dMonthAve.Left = 10.2575F;
            this.mk_dMonthAve.MultiLine = false;
            this.mk_dMonthAve.Name = "mk_dMonthAve";
            this.mk_dMonthAve.OutputFormat = resources.GetString("mk_dMonthAve.OutputFormat");
            this.mk_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonthAve.SummaryGroup = "MakerHeader";
            this.mk_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonthAve.Text = "12,345,678";
            this.mk_dMonthAve.Top = 0.25F;
            this.mk_dMonthAve.Width = 0.51F;
            // 
            // mk_uMonth07
            // 
            this.mk_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth07.DataField = "GrossMoney";
            this.mk_uMonth07.Height = 0.156F;
            this.mk_uMonth07.Left = 6.4975F;
            this.mk_uMonth07.MultiLine = false;
            this.mk_uMonth07.Name = "mk_uMonth07";
            this.mk_uMonth07.OutputFormat = resources.GetString("mk_uMonth07.OutputFormat");
            this.mk_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth07.SummaryGroup = "MakerHeader";
            this.mk_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth07.Text = "12,345,678";
            this.mk_uMonth07.Top = 0.0625F;
            this.mk_uMonth07.Width = 0.51F;
            // 
            // mk_dMonth07
            // 
            this.mk_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth07.DataField = "GrossMoney";
            this.mk_dMonth07.Height = 0.156F;
            this.mk_dMonth07.Left = 6.4975F;
            this.mk_dMonth07.MultiLine = false;
            this.mk_dMonth07.Name = "mk_dMonth07";
            this.mk_dMonth07.OutputFormat = resources.GetString("mk_dMonth07.OutputFormat");
            this.mk_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth07.SummaryGroup = "MakerHeader";
            this.mk_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth07.Text = "12,345,678";
            this.mk_dMonth07.Top = 0.25F;
            this.mk_dMonth07.Width = 0.51F;
            // 
            // mk_uMonth02
            // 
            this.mk_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth02.DataField = "SalesMoney";
            this.mk_uMonth02.Height = 0.156F;
            this.mk_uMonth02.Left = 3.9475F;
            this.mk_uMonth02.MultiLine = false;
            this.mk_uMonth02.Name = "mk_uMonth02";
            this.mk_uMonth02.OutputFormat = resources.GetString("mk_uMonth02.OutputFormat");
            this.mk_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth02.SummaryGroup = "MakerHeader";
            this.mk_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth02.Text = "12,345,678";
            this.mk_uMonth02.Top = 0.0625F;
            this.mk_uMonth02.Width = 0.51F;
            // 
            // mk_dMonth02
            // 
            this.mk_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth02.DataField = "SalesMoney";
            this.mk_dMonth02.Height = 0.156F;
            this.mk_dMonth02.Left = 3.9475F;
            this.mk_dMonth02.MultiLine = false;
            this.mk_dMonth02.Name = "mk_dMonth02";
            this.mk_dMonth02.OutputFormat = resources.GetString("mk_dMonth02.OutputFormat");
            this.mk_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth02.SummaryGroup = "MakerHeader";
            this.mk_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth02.Text = "12,345,678";
            this.mk_dMonth02.Top = 0.25F;
            this.mk_dMonth02.Width = 0.51F;
            // 
            // mk_uMonth01
            // 
            this.mk_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.mk_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.mk_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_uMonth01.DataField = "SalesMoney";
            this.mk_uMonth01.Height = 0.156F;
            this.mk_uMonth01.Left = 3.4375F;
            this.mk_uMonth01.MultiLine = false;
            this.mk_uMonth01.Name = "mk_uMonth01";
            this.mk_uMonth01.OutputFormat = resources.GetString("mk_uMonth01.OutputFormat");
            this.mk_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_uMonth01.SummaryGroup = "MakerHeader";
            this.mk_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_uMonth01.Text = "12,345,678";
            this.mk_uMonth01.Top = 0.0625F;
            this.mk_uMonth01.Width = 0.51F;
            // 
            // mk_dMonth01
            // 
            this.mk_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.mk_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.mk_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.mk_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.mk_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mk_dMonth01.DataField = "SalesMoney";
            this.mk_dMonth01.Height = 0.156F;
            this.mk_dMonth01.Left = 3.4375F;
            this.mk_dMonth01.MultiLine = false;
            this.mk_dMonth01.Name = "mk_dMonth01";
            this.mk_dMonth01.OutputFormat = resources.GetString("mk_dMonth01.OutputFormat");
            this.mk_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mk_dMonth01.SummaryGroup = "MakerHeader";
            this.mk_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mk_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mk_dMonth01.Text = "12,345,678";
            this.mk_dMonth01.Top = 0.25F;
            this.mk_dMonth01.Width = 0.51F;
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
            // subTotalMaker_GoodsMakerCd
            // 
            this.subTotalMaker_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalMaker_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalMaker_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalMaker_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalMaker_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_GoodsMakerCd.DataField = "GoodsMakerCd";
            this.subTotalMaker_GoodsMakerCd.Height = 0.156F;
            this.subTotalMaker_GoodsMakerCd.Left = 1.8375F;
            this.subTotalMaker_GoodsMakerCd.MultiLine = false;
            this.subTotalMaker_GoodsMakerCd.Name = "subTotalMaker_GoodsMakerCd";
            this.subTotalMaker_GoodsMakerCd.OutputFormat = resources.GetString("subTotalMaker_GoodsMakerCd.OutputFormat");
            this.subTotalMaker_GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.subTotalMaker_GoodsMakerCd.Text = "1234";
            this.subTotalMaker_GoodsMakerCd.Top = 0.063F;
            this.subTotalMaker_GoodsMakerCd.Width = 0.35F;
            // 
            // subTotalMaker_MakerShortName
            // 
            this.subTotalMaker_MakerShortName.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalMaker_MakerShortName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_MakerShortName.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalMaker_MakerShortName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_MakerShortName.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalMaker_MakerShortName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_MakerShortName.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalMaker_MakerShortName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalMaker_MakerShortName.DataField = "MakerShortName";
            this.subTotalMaker_MakerShortName.Height = 0.16F;
            this.subTotalMaker_MakerShortName.Left = 2.1875F;
            this.subTotalMaker_MakerShortName.MultiLine = false;
            this.subTotalMaker_MakerShortName.Name = "subTotalMaker_MakerShortName";
            this.subTotalMaker_MakerShortName.OutputFormat = resources.GetString("subTotalMaker_MakerShortName.OutputFormat");
            this.subTotalMaker_MakerShortName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.subTotalMaker_MakerShortName.Text = "12345678901234567890";
            this.subTotalMaker_MakerShortName.Top = 0.0625F;
            this.subTotalMaker_MakerShortName.Width = 1.2F;
            // 
            // BLGoodsHeader
            // 
            this.BLGoodsHeader.CanShrink = true;
            this.BLGoodsHeader.DataField = "BLGoodsField";
            this.BLGoodsHeader.Height = 0F;
            this.BLGoodsHeader.KeepTogether = true;
            this.BLGoodsHeader.Name = "BLGoodsHeader";
            this.BLGoodsHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.BLGoodsHeader.Visible = false;
            // 
            // BLGoodsFooter
            // 
            this.BLGoodsFooter.CanShrink = true;
            this.BLGoodsFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.textBox10,
            this.bl_uMonth12,
            this.bl_uMonth05,
            this.bl_dMonth05,
            this.bl_uMonth06,
            this.bl_uMonth08,
            this.bl_dMonth06,
            this.bl_dMonth08,
            this.bl_dMonth12,
            this.bl_uMonth03,
            this.bl_dMonth04,
            this.bl_uMonth09,
            this.bl_dMonth09,
            this.bl_dMonth10,
            this.bl_dMonthTotal,
            this.bl_uMonth04,
            this.bl_dMonth03,
            this.bl_uMonth10,
            this.bl_uMonth11,
            this.bl_dMonth11,
            this.bl_uMonthTotal,
            this.bl_uMonthAve,
            this.bl_dMonthAve,
            this.bl_uMonth07,
            this.bl_dMonth07,
            this.bl_uMonth02,
            this.bl_dMonth02,
            this.bl_uMonth01,
            this.bl_dMonth01,
            this.subTotalBLGoodsCode_textBox,
            this.subTotalBLGoodsHalfName_textBox});
            this.BLGoodsFooter.Height = 0.467F;
            this.BLGoodsFooter.Name = "BLGoodsFooter";
            this.BLGoodsFooter.Visible = false;
            this.BLGoodsFooter.BeforePrint += new System.EventHandler(this.BLGoodsFooter_BeforePrint);
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
            this.textBox10.Height = 0.16F;
            this.textBox10.Left = 1.1375F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox10.Text = "ＢＬコード計";
            this.textBox10.Top = 0.063F;
            this.textBox10.Width = 0.7F;
            // 
            // bl_uMonth12
            // 
            this.bl_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth12.DataField = "TermSalesComp";
            this.bl_uMonth12.Height = 0.156F;
            this.bl_uMonth12.Left = 9.047502F;
            this.bl_uMonth12.MultiLine = false;
            this.bl_uMonth12.Name = "bl_uMonth12";
            this.bl_uMonth12.OutputFormat = resources.GetString("bl_uMonth12.OutputFormat");
            this.bl_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth12.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth12.Text = "12,345,678";
            this.bl_uMonth12.Top = 0.0625F;
            this.bl_uMonth12.Width = 0.51F;
            // 
            // bl_uMonth05
            // 
            this.bl_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth05.DataField = "StockSalesMoney";
            this.bl_uMonth05.Height = 0.156F;
            this.bl_uMonth05.Left = 5.4775F;
            this.bl_uMonth05.MultiLine = false;
            this.bl_uMonth05.Name = "bl_uMonth05";
            this.bl_uMonth05.OutputFormat = resources.GetString("bl_uMonth05.OutputFormat");
            this.bl_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth05.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth05.Text = "12,345,678";
            this.bl_uMonth05.Top = 0.0625F;
            this.bl_uMonth05.Width = 0.51F;
            // 
            // bl_dMonth05
            // 
            this.bl_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth05.DataField = "TotalStockSalesMoney";
            this.bl_dMonth05.Height = 0.156F;
            this.bl_dMonth05.Left = 5.4775F;
            this.bl_dMonth05.MultiLine = false;
            this.bl_dMonth05.Name = "bl_dMonth05";
            this.bl_dMonth05.OutputFormat = resources.GetString("bl_dMonth05.OutputFormat");
            this.bl_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth05.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth05.Text = "12,345,678";
            this.bl_dMonth05.Top = 0.25F;
            this.bl_dMonth05.Width = 0.51F;
            // 
            // bl_uMonth06
            // 
            this.bl_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth06.DataField = "GrossMoney";
            this.bl_uMonth06.Height = 0.156F;
            this.bl_uMonth06.Left = 5.9875F;
            this.bl_uMonth06.MultiLine = false;
            this.bl_uMonth06.Name = "bl_uMonth06";
            this.bl_uMonth06.OutputFormat = resources.GetString("bl_uMonth06.OutputFormat");
            this.bl_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth06.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth06.Text = "12,345,678";
            this.bl_uMonth06.Top = 0.0625F;
            this.bl_uMonth06.Width = 0.51F;
            // 
            // bl_uMonth08
            // 
            this.bl_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth08.DataField = "CostMoney";
            this.bl_uMonth08.Height = 0.156F;
            this.bl_uMonth08.Left = 7.007501F;
            this.bl_uMonth08.MultiLine = false;
            this.bl_uMonth08.Name = "bl_uMonth08";
            this.bl_uMonth08.OutputFormat = resources.GetString("bl_uMonth08.OutputFormat");
            this.bl_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth08.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth08.Text = "12,345,678";
            this.bl_uMonth08.Top = 0.0625F;
            this.bl_uMonth08.Width = 0.51F;
            // 
            // bl_dMonth06
            // 
            this.bl_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth06.DataField = "TotalGrossMoney";
            this.bl_dMonth06.Height = 0.156F;
            this.bl_dMonth06.Left = 5.9875F;
            this.bl_dMonth06.MultiLine = false;
            this.bl_dMonth06.Name = "bl_dMonth06";
            this.bl_dMonth06.OutputFormat = resources.GetString("bl_dMonth06.OutputFormat");
            this.bl_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth06.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth06.Text = "12,345,678";
            this.bl_dMonth06.Top = 0.25F;
            this.bl_dMonth06.Width = 0.51F;
            // 
            // bl_dMonth08
            // 
            this.bl_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth08.DataField = "TotalCostMoney";
            this.bl_dMonth08.Height = 0.156F;
            this.bl_dMonth08.Left = 7.007501F;
            this.bl_dMonth08.MultiLine = false;
            this.bl_dMonth08.Name = "bl_dMonth08";
            this.bl_dMonth08.OutputFormat = resources.GetString("bl_dMonth08.OutputFormat");
            this.bl_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth08.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth08.Text = "12,345,678";
            this.bl_dMonth08.Top = 0.25F;
            this.bl_dMonth08.Width = 0.51F;
            // 
            // bl_dMonth12
            // 
            this.bl_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth12.DataField = "MonthSalesComp";
            this.bl_dMonth12.Height = 0.156F;
            this.bl_dMonth12.Left = 9.047502F;
            this.bl_dMonth12.MultiLine = false;
            this.bl_dMonth12.Name = "bl_dMonth12";
            this.bl_dMonth12.OutputFormat = resources.GetString("bl_dMonth12.OutputFormat");
            this.bl_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth12.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth12.Text = "12,345,678";
            this.bl_dMonth12.Top = 0.25F;
            this.bl_dMonth12.Width = 0.51F;
            // 
            // bl_uMonth03
            // 
            this.bl_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth03.DataField = "SalesMoney";
            this.bl_uMonth03.Height = 0.156F;
            this.bl_uMonth03.Left = 4.4575F;
            this.bl_uMonth03.MultiLine = false;
            this.bl_uMonth03.Name = "bl_uMonth03";
            this.bl_uMonth03.OutputFormat = resources.GetString("bl_uMonth03.OutputFormat");
            this.bl_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth03.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth03.Text = "12,345,678";
            this.bl_uMonth03.Top = 0.0625F;
            this.bl_uMonth03.Width = 0.51F;
            // 
            // bl_dMonth04
            // 
            this.bl_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth04.DataField = "TotalOrderSalesMoney";
            this.bl_dMonth04.Height = 0.156F;
            this.bl_dMonth04.Left = 4.9675F;
            this.bl_dMonth04.MultiLine = false;
            this.bl_dMonth04.Name = "bl_dMonth04";
            this.bl_dMonth04.OutputFormat = resources.GetString("bl_dMonth04.OutputFormat");
            this.bl_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth04.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth04.Text = "12,345,678";
            this.bl_dMonth04.Top = 0.25F;
            this.bl_dMonth04.Width = 0.51F;
            // 
            // bl_uMonth09
            // 
            this.bl_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth09.DataField = "StockMoney";
            this.bl_uMonth09.Height = 0.156F;
            this.bl_uMonth09.Left = 7.517501F;
            this.bl_uMonth09.MultiLine = false;
            this.bl_uMonth09.Name = "bl_uMonth09";
            this.bl_uMonth09.OutputFormat = resources.GetString("bl_uMonth09.OutputFormat");
            this.bl_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth09.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth09.Text = "12,345,678";
            this.bl_uMonth09.Top = 0.0625F;
            this.bl_uMonth09.Width = 0.51F;
            // 
            // bl_dMonth09
            // 
            this.bl_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth09.DataField = "TotalStockMoney";
            this.bl_dMonth09.Height = 0.156F;
            this.bl_dMonth09.Left = 7.517501F;
            this.bl_dMonth09.MultiLine = false;
            this.bl_dMonth09.Name = "bl_dMonth09";
            this.bl_dMonth09.OutputFormat = resources.GetString("bl_dMonth09.OutputFormat");
            this.bl_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth09.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth09.Text = "12,345,678";
            this.bl_dMonth09.Top = 0.25F;
            this.bl_dMonth09.Width = 0.51F;
            // 
            // bl_dMonth10
            // 
            this.bl_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth10.DataField = "TotalOrderStockMoney";
            this.bl_dMonth10.Height = 0.156F;
            this.bl_dMonth10.Left = 8.027501F;
            this.bl_dMonth10.MultiLine = false;
            this.bl_dMonth10.Name = "bl_dMonth10";
            this.bl_dMonth10.OutputFormat = resources.GetString("bl_dMonth10.OutputFormat");
            this.bl_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth10.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth10.Text = "12,345,678";
            this.bl_dMonth10.Top = 0.25F;
            this.bl_dMonth10.Width = 0.51F;
            // 
            // bl_dMonthTotal
            // 
            this.bl_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthTotal.DataField = "MonthStockComp";
            this.bl_dMonthTotal.Height = 0.156F;
            this.bl_dMonthTotal.Left = 9.557502F;
            this.bl_dMonthTotal.MultiLine = false;
            this.bl_dMonthTotal.Name = "bl_dMonthTotal";
            this.bl_dMonthTotal.OutputFormat = resources.GetString("bl_dMonthTotal.OutputFormat");
            this.bl_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonthTotal.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonthTotal.Text = "1,234,567,890";
            this.bl_dMonthTotal.Top = 0.25F;
            this.bl_dMonthTotal.Width = 0.7F;
            // 
            // bl_uMonth04
            // 
            this.bl_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth04.DataField = "OrderSalesMoney";
            this.bl_uMonth04.Height = 0.156F;
            this.bl_uMonth04.Left = 4.9675F;
            this.bl_uMonth04.MultiLine = false;
            this.bl_uMonth04.Name = "bl_uMonth04";
            this.bl_uMonth04.OutputFormat = resources.GetString("bl_uMonth04.OutputFormat");
            this.bl_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth04.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth04.Text = "12,345,678";
            this.bl_uMonth04.Top = 0.0625F;
            this.bl_uMonth04.Width = 0.51F;
            // 
            // bl_dMonth03
            // 
            this.bl_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth03.DataField = "TotalSalesMoney";
            this.bl_dMonth03.Height = 0.156F;
            this.bl_dMonth03.Left = 4.4575F;
            this.bl_dMonth03.MultiLine = false;
            this.bl_dMonth03.Name = "bl_dMonth03";
            this.bl_dMonth03.OutputFormat = resources.GetString("bl_dMonth03.OutputFormat");
            this.bl_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth03.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth03.Text = "12,345,678";
            this.bl_dMonth03.Top = 0.25F;
            this.bl_dMonth03.Width = 0.51F;
            // 
            // bl_uMonth10
            // 
            this.bl_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth10.DataField = "OrderStockMoney";
            this.bl_uMonth10.Height = 0.156F;
            this.bl_uMonth10.Left = 8.027501F;
            this.bl_uMonth10.MultiLine = false;
            this.bl_uMonth10.Name = "bl_uMonth10";
            this.bl_uMonth10.OutputFormat = resources.GetString("bl_uMonth10.OutputFormat");
            this.bl_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth10.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth10.Text = "12,345,678";
            this.bl_uMonth10.Top = 0.0625F;
            this.bl_uMonth10.Width = 0.51F;
            // 
            // bl_uMonth11
            // 
            this.bl_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth11.DataField = "StockStockMoney";
            this.bl_uMonth11.Height = 0.156F;
            this.bl_uMonth11.Left = 8.537501F;
            this.bl_uMonth11.MultiLine = false;
            this.bl_uMonth11.Name = "bl_uMonth11";
            this.bl_uMonth11.OutputFormat = resources.GetString("bl_uMonth11.OutputFormat");
            this.bl_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth11.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth11.Text = "12,345,678";
            this.bl_uMonth11.Top = 0.0625F;
            this.bl_uMonth11.Width = 0.51F;
            // 
            // bl_dMonth11
            // 
            this.bl_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth11.DataField = "TotalStockStockMoney";
            this.bl_dMonth11.Height = 0.156F;
            this.bl_dMonth11.Left = 8.537501F;
            this.bl_dMonth11.MultiLine = false;
            this.bl_dMonth11.Name = "bl_dMonth11";
            this.bl_dMonth11.OutputFormat = resources.GetString("bl_dMonth11.OutputFormat");
            this.bl_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth11.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth11.Text = "12,345,678";
            this.bl_dMonth11.Top = 0.25F;
            this.bl_dMonth11.Width = 0.51F;
            // 
            // bl_uMonthTotal
            // 
            this.bl_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthTotal.DataField = "TermStockComp";
            this.bl_uMonthTotal.Height = 0.156F;
            this.bl_uMonthTotal.Left = 9.557502F;
            this.bl_uMonthTotal.MultiLine = false;
            this.bl_uMonthTotal.Name = "bl_uMonthTotal";
            this.bl_uMonthTotal.OutputFormat = resources.GetString("bl_uMonthTotal.OutputFormat");
            this.bl_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonthTotal.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonthTotal.Text = "1,234,567,890";
            this.bl_uMonthTotal.Top = 0.0625F;
            this.bl_uMonthTotal.Width = 0.7F;
            // 
            // bl_uMonthAve
            // 
            this.bl_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonthAve.DataField = "Difference";
            this.bl_uMonthAve.Height = 0.156F;
            this.bl_uMonthAve.Left = 10.2575F;
            this.bl_uMonthAve.MultiLine = false;
            this.bl_uMonthAve.Name = "bl_uMonthAve";
            this.bl_uMonthAve.OutputFormat = resources.GetString("bl_uMonthAve.OutputFormat");
            this.bl_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonthAve.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonthAve.Text = "12,345,678";
            this.bl_uMonthAve.Top = 0.0625F;
            this.bl_uMonthAve.Width = 0.51F;
            // 
            // bl_dMonthAve
            // 
            this.bl_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonthAve.DataField = "TotalDifference";
            this.bl_dMonthAve.Height = 0.156F;
            this.bl_dMonthAve.Left = 10.2575F;
            this.bl_dMonthAve.MultiLine = false;
            this.bl_dMonthAve.Name = "bl_dMonthAve";
            this.bl_dMonthAve.OutputFormat = resources.GetString("bl_dMonthAve.OutputFormat");
            this.bl_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonthAve.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonthAve.Text = "12,345,678";
            this.bl_dMonthAve.Top = 0.25F;
            this.bl_dMonthAve.Width = 0.51F;
            // 
            // bl_uMonth07
            // 
            this.bl_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth07.DataField = "GrossMoney";
            this.bl_uMonth07.Height = 0.156F;
            this.bl_uMonth07.Left = 6.4975F;
            this.bl_uMonth07.MultiLine = false;
            this.bl_uMonth07.Name = "bl_uMonth07";
            this.bl_uMonth07.OutputFormat = resources.GetString("bl_uMonth07.OutputFormat");
            this.bl_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth07.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth07.Text = "12,345,678";
            this.bl_uMonth07.Top = 0.0625F;
            this.bl_uMonth07.Width = 0.51F;
            // 
            // bl_dMonth07
            // 
            this.bl_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth07.DataField = "GrossMoney";
            this.bl_dMonth07.Height = 0.156F;
            this.bl_dMonth07.Left = 6.4975F;
            this.bl_dMonth07.MultiLine = false;
            this.bl_dMonth07.Name = "bl_dMonth07";
            this.bl_dMonth07.OutputFormat = resources.GetString("bl_dMonth07.OutputFormat");
            this.bl_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth07.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth07.Text = "12,345,678";
            this.bl_dMonth07.Top = 0.25F;
            this.bl_dMonth07.Width = 0.51F;
            // 
            // bl_uMonth02
            // 
            this.bl_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth02.DataField = "SalesMoney";
            this.bl_uMonth02.Height = 0.156F;
            this.bl_uMonth02.Left = 3.9475F;
            this.bl_uMonth02.MultiLine = false;
            this.bl_uMonth02.Name = "bl_uMonth02";
            this.bl_uMonth02.OutputFormat = resources.GetString("bl_uMonth02.OutputFormat");
            this.bl_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth02.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth02.Text = "12,345,678";
            this.bl_uMonth02.Top = 0.0625F;
            this.bl_uMonth02.Width = 0.51F;
            // 
            // bl_dMonth02
            // 
            this.bl_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth02.DataField = "SalesMoney";
            this.bl_dMonth02.Height = 0.156F;
            this.bl_dMonth02.Left = 3.9475F;
            this.bl_dMonth02.MultiLine = false;
            this.bl_dMonth02.Name = "bl_dMonth02";
            this.bl_dMonth02.OutputFormat = resources.GetString("bl_dMonth02.OutputFormat");
            this.bl_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth02.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth02.Text = "12,345,678";
            this.bl_dMonth02.Top = 0.25F;
            this.bl_dMonth02.Width = 0.51F;
            // 
            // bl_uMonth01
            // 
            this.bl_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.bl_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.bl_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_uMonth01.DataField = "SalesMoney";
            this.bl_uMonth01.Height = 0.156F;
            this.bl_uMonth01.Left = 3.4375F;
            this.bl_uMonth01.MultiLine = false;
            this.bl_uMonth01.Name = "bl_uMonth01";
            this.bl_uMonth01.OutputFormat = resources.GetString("bl_uMonth01.OutputFormat");
            this.bl_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_uMonth01.SummaryGroup = "BLGoodsHeader";
            this.bl_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_uMonth01.Text = "12,345,678";
            this.bl_uMonth01.Top = 0.0625F;
            this.bl_uMonth01.Width = 0.51F;
            // 
            // bl_dMonth01
            // 
            this.bl_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.bl_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.bl_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.bl_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.bl_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bl_dMonth01.DataField = "SalesMoney";
            this.bl_dMonth01.Height = 0.156F;
            this.bl_dMonth01.Left = 3.4375F;
            this.bl_dMonth01.MultiLine = false;
            this.bl_dMonth01.Name = "bl_dMonth01";
            this.bl_dMonth01.OutputFormat = resources.GetString("bl_dMonth01.OutputFormat");
            this.bl_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.bl_dMonth01.SummaryGroup = "BLGoodsHeader";
            this.bl_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.bl_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.bl_dMonth01.Text = "12,345,678";
            this.bl_dMonth01.Top = 0.25F;
            this.bl_dMonth01.Width = 0.51F;
            // 
            // subTotalBLGoodsCode_textBox
            // 
            this.subTotalBLGoodsCode_textBox.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsCode_textBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsCode_textBox.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsCode_textBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsCode_textBox.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsCode_textBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsCode_textBox.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsCode_textBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsCode_textBox.DataField = "BLGoodsCode";
            this.subTotalBLGoodsCode_textBox.Height = 0.156F;
            this.subTotalBLGoodsCode_textBox.Left = 1.8375F;
            this.subTotalBLGoodsCode_textBox.MultiLine = false;
            this.subTotalBLGoodsCode_textBox.Name = "subTotalBLGoodsCode_textBox";
            this.subTotalBLGoodsCode_textBox.OutputFormat = resources.GetString("subTotalBLGoodsCode_textBox.OutputFormat");
            this.subTotalBLGoodsCode_textBox.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.subTotalBLGoodsCode_textBox.Text = "12345";
            this.subTotalBLGoodsCode_textBox.Top = 0.063F;
            this.subTotalBLGoodsCode_textBox.Width = 0.35F;
            // 
            // subTotalBLGoodsHalfName_textBox
            // 
            this.subTotalBLGoodsHalfName_textBox.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsHalfName_textBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsHalfName_textBox.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsHalfName_textBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsHalfName_textBox.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsHalfName_textBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsHalfName_textBox.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalBLGoodsHalfName_textBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGoodsHalfName_textBox.DataField = "BLGoodsHalfName";
            this.subTotalBLGoodsHalfName_textBox.Height = 0.16F;
            this.subTotalBLGoodsHalfName_textBox.Left = 2.1875F;
            this.subTotalBLGoodsHalfName_textBox.MultiLine = false;
            this.subTotalBLGoodsHalfName_textBox.Name = "subTotalBLGoodsHalfName_textBox";
            this.subTotalBLGoodsHalfName_textBox.OutputFormat = resources.GetString("subTotalBLGoodsHalfName_textBox.OutputFormat");
            this.subTotalBLGoodsHalfName_textBox.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.subTotalBLGoodsHalfName_textBox.Text = "12345678901234567890";
            this.subTotalBLGoodsHalfName_textBox.Top = 0.0625F;
            this.subTotalBLGoodsHalfName_textBox.Width = 1.2F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CusHd_SectionTitle,
            this.CusHd_SectionCode,
            this.CusHd_SectionName,
            this.CusHd_CustomerTitle,
            this.CusHd_CustomerCode,
            this.CusHd_CustomerName,
            this.line9});
            this.CustomerHeader.DataField = "CustomerField";
            this.CustomerHeader.Height = 0.21875F;
            this.CustomerHeader.KeepTogether = true;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.CustomerHeader.Visible = false;
            this.CustomerHeader.BeforePrint += new System.EventHandler(this.CustomerHeader_BeforePrint);
            // 
            // CusHd_SectionTitle
            // 
            this.CusHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionTitle.Height = 0.16F;
            this.CusHd_SectionTitle.HyperLink = "";
            this.CusHd_SectionTitle.Left = 0F;
            this.CusHd_SectionTitle.MultiLine = false;
            this.CusHd_SectionTitle.Name = "CusHd_SectionTitle";
            this.CusHd_SectionTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_SectionTitle.Text = "拠点";
            this.CusHd_SectionTitle.Top = 0F;
            this.CusHd_SectionTitle.Width = 0.55F;
            // 
            // CusHd_SectionCode
            // 
            this.CusHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionCode.DataField = "AddUpSecCode";
            this.CusHd_SectionCode.Height = 0.16F;
            this.CusHd_SectionCode.Left = 0.625F;
            this.CusHd_SectionCode.MultiLine = false;
            this.CusHd_SectionCode.Name = "CusHd_SectionCode";
            this.CusHd_SectionCode.OutputFormat = resources.GetString("CusHd_SectionCode.OutputFormat");
            this.CusHd_SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CusHd_SectionCode.Text = "12";
            this.CusHd_SectionCode.Top = 0F;
            this.CusHd_SectionCode.Width = 0.2F;
            // 
            // CusHd_SectionName
            // 
            this.CusHd_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_SectionName.DataField = "SectionGuideNm";
            this.CusHd_SectionName.Height = 0.16F;
            this.CusHd_SectionName.Left = 0.875F;
            this.CusHd_SectionName.MultiLine = false;
            this.CusHd_SectionName.Name = "CusHd_SectionName";
            this.CusHd_SectionName.OutputFormat = resources.GetString("CusHd_SectionName.OutputFormat");
            this.CusHd_SectionName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.CusHd_SectionName.Text = "あいうえおかきくけこ";
            this.CusHd_SectionName.Top = 0F;
            this.CusHd_SectionName.Width = 1.2F;
            // 
            // CusHd_CustomerTitle
            // 
            this.CusHd_CustomerTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerTitle.Height = 0.16F;
            this.CusHd_CustomerTitle.HyperLink = "";
            this.CusHd_CustomerTitle.Left = 2.125F;
            this.CusHd_CustomerTitle.MultiLine = false;
            this.CusHd_CustomerTitle.Name = "CusHd_CustomerTitle";
            this.CusHd_CustomerTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.CusHd_CustomerTitle.Text = "得意先";
            this.CusHd_CustomerTitle.Top = 0F;
            this.CusHd_CustomerTitle.Width = 0.625F;
            // 
            // CusHd_CustomerCode
            // 
            this.CusHd_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerCode.DataField = "CustomerCode";
            this.CusHd_CustomerCode.Height = 0.16F;
            this.CusHd_CustomerCode.Left = 2.75F;
            this.CusHd_CustomerCode.MultiLine = false;
            this.CusHd_CustomerCode.Name = "CusHd_CustomerCode";
            this.CusHd_CustomerCode.OutputFormat = resources.GetString("CusHd_CustomerCode.OutputFormat");
            this.CusHd_CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CusHd_CustomerCode.Text = "12345678";
            this.CusHd_CustomerCode.Top = 0F;
            this.CusHd_CustomerCode.Width = 0.54F;
            // 
            // CusHd_CustomerName
            // 
            this.CusHd_CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CusHd_CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CusHd_CustomerName.DataField = "CustomerSnm";
            this.CusHd_CustomerName.Height = 0.16F;
            this.CusHd_CustomerName.Left = 3.3125F;
            this.CusHd_CustomerName.MultiLine = false;
            this.CusHd_CustomerName.Name = "CusHd_CustomerName";
            this.CusHd_CustomerName.OutputFormat = resources.GetString("CusHd_CustomerName.OutputFormat");
            this.CusHd_CustomerName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.CusHd_CustomerName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CusHd_CustomerName.Top = 0F;
            this.CusHd_CustomerName.Width = 2.3F;
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
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox98,
            this.line5,
            this.cu_uMonth12,
            this.cu_uMonth05,
            this.cu_dMonth05,
            this.cu_uMonth06,
            this.cu_uMonth08,
            this.cu_dMonth06,
            this.cu_dMonth08,
            this.cu_dMonth12,
            this.cu_uMonth03,
            this.cu_dMonth04,
            this.cu_uMonth09,
            this.cu_dMonth09,
            this.cu_dMonth10,
            this.cu_dMonthTotal,
            this.cu_uMonth04,
            this.cu_dMonth03,
            this.cu_uMonth10,
            this.cu_uMonth11,
            this.cu_dMonth11,
            this.cu_uMonthTotal,
            this.cu_uMonthAve,
            this.cu_dMonthAve,
            this.cu_uMonth07,
            this.cu_dMonth07,
            this.cu_uMonth02,
            this.cu_dMonth02,
            this.cu_uMonth01,
            this.cu_dMonth01});
            this.CustomerFooter.Height = 0.467F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
            this.CustomerFooter.Visible = false;
            this.CustomerFooter.BeforePrint += new System.EventHandler(this.CustomerFooter_BeforePrint);
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
            this.textBox98.Height = 0.16F;
            this.textBox98.Left = 1.1375F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox98.Text = "得意先計";
            this.textBox98.Top = 0.0625F;
            this.textBox98.Width = 0.7F;
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
            // cu_uMonth12
            // 
            this.cu_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth12.DataField = "TermSalesComp";
            this.cu_uMonth12.Height = 0.156F;
            this.cu_uMonth12.Left = 9.047502F;
            this.cu_uMonth12.MultiLine = false;
            this.cu_uMonth12.Name = "cu_uMonth12";
            this.cu_uMonth12.OutputFormat = resources.GetString("cu_uMonth12.OutputFormat");
            this.cu_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth12.SummaryGroup = "CustomerHeader";
            this.cu_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth12.Text = "12,345,678";
            this.cu_uMonth12.Top = 0.0625F;
            this.cu_uMonth12.Width = 0.51F;
            // 
            // cu_uMonth05
            // 
            this.cu_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth05.DataField = "StockSalesMoney";
            this.cu_uMonth05.Height = 0.156F;
            this.cu_uMonth05.Left = 5.4775F;
            this.cu_uMonth05.MultiLine = false;
            this.cu_uMonth05.Name = "cu_uMonth05";
            this.cu_uMonth05.OutputFormat = resources.GetString("cu_uMonth05.OutputFormat");
            this.cu_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth05.SummaryGroup = "CustomerHeader";
            this.cu_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth05.Text = "12,345,678";
            this.cu_uMonth05.Top = 0.0625F;
            this.cu_uMonth05.Width = 0.51F;
            // 
            // cu_dMonth05
            // 
            this.cu_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth05.DataField = "TotalStockSalesMoney";
            this.cu_dMonth05.Height = 0.156F;
            this.cu_dMonth05.Left = 5.4775F;
            this.cu_dMonth05.MultiLine = false;
            this.cu_dMonth05.Name = "cu_dMonth05";
            this.cu_dMonth05.OutputFormat = resources.GetString("cu_dMonth05.OutputFormat");
            this.cu_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth05.SummaryGroup = "CustomerHeader";
            this.cu_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth05.Text = "12,345,678";
            this.cu_dMonth05.Top = 0.25F;
            this.cu_dMonth05.Width = 0.51F;
            // 
            // cu_uMonth06
            // 
            this.cu_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth06.DataField = "GrossMoney";
            this.cu_uMonth06.Height = 0.156F;
            this.cu_uMonth06.Left = 5.9875F;
            this.cu_uMonth06.MultiLine = false;
            this.cu_uMonth06.Name = "cu_uMonth06";
            this.cu_uMonth06.OutputFormat = resources.GetString("cu_uMonth06.OutputFormat");
            this.cu_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth06.SummaryGroup = "CustomerHeader";
            this.cu_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth06.Text = "12,345,678";
            this.cu_uMonth06.Top = 0.0625F;
            this.cu_uMonth06.Width = 0.51F;
            // 
            // cu_uMonth08
            // 
            this.cu_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth08.DataField = "CostMoney";
            this.cu_uMonth08.Height = 0.156F;
            this.cu_uMonth08.Left = 7.007501F;
            this.cu_uMonth08.MultiLine = false;
            this.cu_uMonth08.Name = "cu_uMonth08";
            this.cu_uMonth08.OutputFormat = resources.GetString("cu_uMonth08.OutputFormat");
            this.cu_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth08.SummaryGroup = "CustomerHeader";
            this.cu_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth08.Text = "12,345,678";
            this.cu_uMonth08.Top = 0.0625F;
            this.cu_uMonth08.Width = 0.51F;
            // 
            // cu_dMonth06
            // 
            this.cu_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth06.DataField = "TotalGrossMoney";
            this.cu_dMonth06.Height = 0.156F;
            this.cu_dMonth06.Left = 5.9875F;
            this.cu_dMonth06.MultiLine = false;
            this.cu_dMonth06.Name = "cu_dMonth06";
            this.cu_dMonth06.OutputFormat = resources.GetString("cu_dMonth06.OutputFormat");
            this.cu_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth06.SummaryGroup = "CustomerHeader";
            this.cu_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth06.Text = "12,345,678";
            this.cu_dMonth06.Top = 0.25F;
            this.cu_dMonth06.Width = 0.51F;
            // 
            // cu_dMonth08
            // 
            this.cu_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth08.DataField = "TotalCostMoney";
            this.cu_dMonth08.Height = 0.156F;
            this.cu_dMonth08.Left = 7.007501F;
            this.cu_dMonth08.MultiLine = false;
            this.cu_dMonth08.Name = "cu_dMonth08";
            this.cu_dMonth08.OutputFormat = resources.GetString("cu_dMonth08.OutputFormat");
            this.cu_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth08.SummaryGroup = "CustomerHeader";
            this.cu_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth08.Text = "12,345,678";
            this.cu_dMonth08.Top = 0.25F;
            this.cu_dMonth08.Width = 0.51F;
            // 
            // cu_dMonth12
            // 
            this.cu_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth12.DataField = "MonthSalesComp";
            this.cu_dMonth12.Height = 0.156F;
            this.cu_dMonth12.Left = 9.047502F;
            this.cu_dMonth12.MultiLine = false;
            this.cu_dMonth12.Name = "cu_dMonth12";
            this.cu_dMonth12.OutputFormat = resources.GetString("cu_dMonth12.OutputFormat");
            this.cu_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth12.SummaryGroup = "CustomerHeader";
            this.cu_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth12.Text = "12,345,678";
            this.cu_dMonth12.Top = 0.25F;
            this.cu_dMonth12.Width = 0.51F;
            // 
            // cu_uMonth03
            // 
            this.cu_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth03.DataField = "SalesMoney";
            this.cu_uMonth03.Height = 0.156F;
            this.cu_uMonth03.Left = 4.4575F;
            this.cu_uMonth03.MultiLine = false;
            this.cu_uMonth03.Name = "cu_uMonth03";
            this.cu_uMonth03.OutputFormat = resources.GetString("cu_uMonth03.OutputFormat");
            this.cu_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth03.SummaryGroup = "CustomerHeader";
            this.cu_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth03.Text = "12,345,678";
            this.cu_uMonth03.Top = 0.0625F;
            this.cu_uMonth03.Width = 0.51F;
            // 
            // cu_dMonth04
            // 
            this.cu_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth04.DataField = "TotalOrderSalesMoney";
            this.cu_dMonth04.Height = 0.156F;
            this.cu_dMonth04.Left = 4.9675F;
            this.cu_dMonth04.MultiLine = false;
            this.cu_dMonth04.Name = "cu_dMonth04";
            this.cu_dMonth04.OutputFormat = resources.GetString("cu_dMonth04.OutputFormat");
            this.cu_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth04.SummaryGroup = "CustomerHeader";
            this.cu_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth04.Text = "12,345,678";
            this.cu_dMonth04.Top = 0.25F;
            this.cu_dMonth04.Width = 0.51F;
            // 
            // cu_uMonth09
            // 
            this.cu_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth09.DataField = "StockMoney";
            this.cu_uMonth09.Height = 0.156F;
            this.cu_uMonth09.Left = 7.517501F;
            this.cu_uMonth09.MultiLine = false;
            this.cu_uMonth09.Name = "cu_uMonth09";
            this.cu_uMonth09.OutputFormat = resources.GetString("cu_uMonth09.OutputFormat");
            this.cu_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth09.SummaryGroup = "CustomerHeader";
            this.cu_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth09.Text = "12,345,678";
            this.cu_uMonth09.Top = 0.0625F;
            this.cu_uMonth09.Width = 0.51F;
            // 
            // cu_dMonth09
            // 
            this.cu_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth09.DataField = "TotalStockMoney";
            this.cu_dMonth09.Height = 0.156F;
            this.cu_dMonth09.Left = 7.517501F;
            this.cu_dMonth09.MultiLine = false;
            this.cu_dMonth09.Name = "cu_dMonth09";
            this.cu_dMonth09.OutputFormat = resources.GetString("cu_dMonth09.OutputFormat");
            this.cu_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth09.SummaryGroup = "CustomerHeader";
            this.cu_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth09.Text = "12,345,678";
            this.cu_dMonth09.Top = 0.25F;
            this.cu_dMonth09.Width = 0.51F;
            // 
            // cu_dMonth10
            // 
            this.cu_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth10.DataField = "TotalOrderStockMoney";
            this.cu_dMonth10.Height = 0.156F;
            this.cu_dMonth10.Left = 8.027501F;
            this.cu_dMonth10.MultiLine = false;
            this.cu_dMonth10.Name = "cu_dMonth10";
            this.cu_dMonth10.OutputFormat = resources.GetString("cu_dMonth10.OutputFormat");
            this.cu_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth10.SummaryGroup = "CustomerHeader";
            this.cu_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth10.Text = "12,345,678";
            this.cu_dMonth10.Top = 0.25F;
            this.cu_dMonth10.Width = 0.51F;
            // 
            // cu_dMonthTotal
            // 
            this.cu_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthTotal.DataField = "MonthStockComp";
            this.cu_dMonthTotal.Height = 0.156F;
            this.cu_dMonthTotal.Left = 9.557502F;
            this.cu_dMonthTotal.MultiLine = false;
            this.cu_dMonthTotal.Name = "cu_dMonthTotal";
            this.cu_dMonthTotal.OutputFormat = resources.GetString("cu_dMonthTotal.OutputFormat");
            this.cu_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonthTotal.SummaryGroup = "CustomerHeader";
            this.cu_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonthTotal.Text = "1,234,567,890";
            this.cu_dMonthTotal.Top = 0.25F;
            this.cu_dMonthTotal.Width = 0.7F;
            // 
            // cu_uMonth04
            // 
            this.cu_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth04.DataField = "OrderSalesMoney";
            this.cu_uMonth04.Height = 0.156F;
            this.cu_uMonth04.Left = 4.9675F;
            this.cu_uMonth04.MultiLine = false;
            this.cu_uMonth04.Name = "cu_uMonth04";
            this.cu_uMonth04.OutputFormat = resources.GetString("cu_uMonth04.OutputFormat");
            this.cu_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth04.SummaryGroup = "CustomerHeader";
            this.cu_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth04.Text = "12,345,678";
            this.cu_uMonth04.Top = 0.0625F;
            this.cu_uMonth04.Width = 0.51F;
            // 
            // cu_dMonth03
            // 
            this.cu_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth03.DataField = "TotalSalesMoney";
            this.cu_dMonth03.Height = 0.156F;
            this.cu_dMonth03.Left = 4.4575F;
            this.cu_dMonth03.MultiLine = false;
            this.cu_dMonth03.Name = "cu_dMonth03";
            this.cu_dMonth03.OutputFormat = resources.GetString("cu_dMonth03.OutputFormat");
            this.cu_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth03.SummaryGroup = "CustomerHeader";
            this.cu_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth03.Text = "12,345,678";
            this.cu_dMonth03.Top = 0.25F;
            this.cu_dMonth03.Width = 0.51F;
            // 
            // cu_uMonth10
            // 
            this.cu_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth10.DataField = "OrderStockMoney";
            this.cu_uMonth10.Height = 0.156F;
            this.cu_uMonth10.Left = 8.027501F;
            this.cu_uMonth10.MultiLine = false;
            this.cu_uMonth10.Name = "cu_uMonth10";
            this.cu_uMonth10.OutputFormat = resources.GetString("cu_uMonth10.OutputFormat");
            this.cu_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth10.SummaryGroup = "CustomerHeader";
            this.cu_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth10.Text = "12,345,678";
            this.cu_uMonth10.Top = 0.0625F;
            this.cu_uMonth10.Width = 0.51F;
            // 
            // cu_uMonth11
            // 
            this.cu_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth11.DataField = "StockStockMoney";
            this.cu_uMonth11.Height = 0.156F;
            this.cu_uMonth11.Left = 8.537501F;
            this.cu_uMonth11.MultiLine = false;
            this.cu_uMonth11.Name = "cu_uMonth11";
            this.cu_uMonth11.OutputFormat = resources.GetString("cu_uMonth11.OutputFormat");
            this.cu_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth11.SummaryGroup = "CustomerHeader";
            this.cu_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth11.Text = "12,345,678";
            this.cu_uMonth11.Top = 0.0625F;
            this.cu_uMonth11.Width = 0.51F;
            // 
            // cu_dMonth11
            // 
            this.cu_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth11.DataField = "TotalStockStockMoney";
            this.cu_dMonth11.Height = 0.156F;
            this.cu_dMonth11.Left = 8.537501F;
            this.cu_dMonth11.MultiLine = false;
            this.cu_dMonth11.Name = "cu_dMonth11";
            this.cu_dMonth11.OutputFormat = resources.GetString("cu_dMonth11.OutputFormat");
            this.cu_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth11.SummaryGroup = "CustomerHeader";
            this.cu_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth11.Text = "12,345,678";
            this.cu_dMonth11.Top = 0.25F;
            this.cu_dMonth11.Width = 0.51F;
            // 
            // cu_uMonthTotal
            // 
            this.cu_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthTotal.DataField = "TermStockComp";
            this.cu_uMonthTotal.Height = 0.156F;
            this.cu_uMonthTotal.Left = 9.557502F;
            this.cu_uMonthTotal.MultiLine = false;
            this.cu_uMonthTotal.Name = "cu_uMonthTotal";
            this.cu_uMonthTotal.OutputFormat = resources.GetString("cu_uMonthTotal.OutputFormat");
            this.cu_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonthTotal.SummaryGroup = "CustomerHeader";
            this.cu_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonthTotal.Text = "1,234,567,890";
            this.cu_uMonthTotal.Top = 0.0625F;
            this.cu_uMonthTotal.Width = 0.7F;
            // 
            // cu_uMonthAve
            // 
            this.cu_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonthAve.DataField = "Difference";
            this.cu_uMonthAve.Height = 0.156F;
            this.cu_uMonthAve.Left = 10.2575F;
            this.cu_uMonthAve.MultiLine = false;
            this.cu_uMonthAve.Name = "cu_uMonthAve";
            this.cu_uMonthAve.OutputFormat = resources.GetString("cu_uMonthAve.OutputFormat");
            this.cu_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonthAve.SummaryGroup = "CustomerHeader";
            this.cu_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonthAve.Text = "12,345,678";
            this.cu_uMonthAve.Top = 0.0625F;
            this.cu_uMonthAve.Width = 0.51F;
            // 
            // cu_dMonthAve
            // 
            this.cu_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonthAve.DataField = "TotalDifference";
            this.cu_dMonthAve.Height = 0.156F;
            this.cu_dMonthAve.Left = 10.2575F;
            this.cu_dMonthAve.MultiLine = false;
            this.cu_dMonthAve.Name = "cu_dMonthAve";
            this.cu_dMonthAve.OutputFormat = resources.GetString("cu_dMonthAve.OutputFormat");
            this.cu_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonthAve.SummaryGroup = "CustomerHeader";
            this.cu_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonthAve.Text = "12,345,678";
            this.cu_dMonthAve.Top = 0.25F;
            this.cu_dMonthAve.Width = 0.51F;
            // 
            // cu_uMonth07
            // 
            this.cu_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth07.DataField = "GrossMoney";
            this.cu_uMonth07.Height = 0.156F;
            this.cu_uMonth07.Left = 6.4975F;
            this.cu_uMonth07.MultiLine = false;
            this.cu_uMonth07.Name = "cu_uMonth07";
            this.cu_uMonth07.OutputFormat = resources.GetString("cu_uMonth07.OutputFormat");
            this.cu_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth07.SummaryGroup = "CustomerHeader";
            this.cu_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth07.Text = "12,345,678";
            this.cu_uMonth07.Top = 0.0625F;
            this.cu_uMonth07.Width = 0.51F;
            // 
            // cu_dMonth07
            // 
            this.cu_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth07.DataField = "GrossMoney";
            this.cu_dMonth07.Height = 0.156F;
            this.cu_dMonth07.Left = 6.4975F;
            this.cu_dMonth07.MultiLine = false;
            this.cu_dMonth07.Name = "cu_dMonth07";
            this.cu_dMonth07.OutputFormat = resources.GetString("cu_dMonth07.OutputFormat");
            this.cu_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth07.SummaryGroup = "CustomerHeader";
            this.cu_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth07.Text = "12,345,678";
            this.cu_dMonth07.Top = 0.25F;
            this.cu_dMonth07.Width = 0.51F;
            // 
            // cu_uMonth02
            // 
            this.cu_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth02.DataField = "SalesMoney";
            this.cu_uMonth02.Height = 0.156F;
            this.cu_uMonth02.Left = 3.9475F;
            this.cu_uMonth02.MultiLine = false;
            this.cu_uMonth02.Name = "cu_uMonth02";
            this.cu_uMonth02.OutputFormat = resources.GetString("cu_uMonth02.OutputFormat");
            this.cu_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth02.SummaryGroup = "CustomerHeader";
            this.cu_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth02.Text = "12,345,678";
            this.cu_uMonth02.Top = 0.0625F;
            this.cu_uMonth02.Width = 0.51F;
            // 
            // cu_dMonth02
            // 
            this.cu_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth02.DataField = "SalesMoney";
            this.cu_dMonth02.Height = 0.156F;
            this.cu_dMonth02.Left = 3.9475F;
            this.cu_dMonth02.MultiLine = false;
            this.cu_dMonth02.Name = "cu_dMonth02";
            this.cu_dMonth02.OutputFormat = resources.GetString("cu_dMonth02.OutputFormat");
            this.cu_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth02.SummaryGroup = "CustomerHeader";
            this.cu_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth02.Text = "12,345,678";
            this.cu_dMonth02.Top = 0.25F;
            this.cu_dMonth02.Width = 0.51F;
            // 
            // cu_uMonth01
            // 
            this.cu_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.cu_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.cu_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_uMonth01.DataField = "SalesMoney";
            this.cu_uMonth01.Height = 0.156F;
            this.cu_uMonth01.Left = 3.4375F;
            this.cu_uMonth01.MultiLine = false;
            this.cu_uMonth01.Name = "cu_uMonth01";
            this.cu_uMonth01.OutputFormat = resources.GetString("cu_uMonth01.OutputFormat");
            this.cu_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_uMonth01.SummaryGroup = "CustomerHeader";
            this.cu_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_uMonth01.Text = "12,345,678";
            this.cu_uMonth01.Top = 0.0625F;
            this.cu_uMonth01.Width = 0.51F;
            // 
            // cu_dMonth01
            // 
            this.cu_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.cu_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.cu_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.cu_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.cu_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.cu_dMonth01.DataField = "SalesMoney";
            this.cu_dMonth01.Height = 0.156F;
            this.cu_dMonth01.Left = 3.4375F;
            this.cu_dMonth01.MultiLine = false;
            this.cu_dMonth01.Name = "cu_dMonth01";
            this.cu_dMonth01.OutputFormat = resources.GetString("cu_dMonth01.OutputFormat");
            this.cu_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.cu_dMonth01.SummaryGroup = "CustomerHeader";
            this.cu_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.cu_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.cu_dMonth01.Text = "12,345,678";
            this.cu_dMonth01.Top = 0.25F;
            this.cu_dMonth01.Width = 0.51F;
            // 
            // SalesEmployeeHeader
            // 
            this.SalesEmployeeHeader.CanShrink = true;
            this.SalesEmployeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.EmpHd_SectionTitle,
            this.EmpHd_SectionCode,
            this.EmpHd_SectionName,
            this.EmpHd_EmployeeTitle,
            this.EmpHd_EmployeeCode,
            this.EmpHd_EmployeeName,
            this.line11});
            this.SalesEmployeeHeader.DataField = "SalesEmployeeField";
            this.SalesEmployeeHeader.Height = 0.25F;
            this.SalesEmployeeHeader.KeepTogether = true;
            this.SalesEmployeeHeader.Name = "SalesEmployeeHeader";
            this.SalesEmployeeHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SalesEmployeeHeader.Visible = false;
            this.SalesEmployeeHeader.BeforePrint += new System.EventHandler(this.SalesEmployeeHeader_BeforePrint);
            // 
            // EmpHd_SectionTitle
            // 
            this.EmpHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionTitle.Height = 0.16F;
            this.EmpHd_SectionTitle.HyperLink = "";
            this.EmpHd_SectionTitle.Left = 0F;
            this.EmpHd_SectionTitle.MultiLine = false;
            this.EmpHd_SectionTitle.Name = "EmpHd_SectionTitle";
            this.EmpHd_SectionTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.EmpHd_SectionTitle.Text = "拠点";
            this.EmpHd_SectionTitle.Top = 0F;
            this.EmpHd_SectionTitle.Width = 0.55F;
            // 
            // EmpHd_SectionCode
            // 
            this.EmpHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionCode.DataField = "AddUpSecCode";
            this.EmpHd_SectionCode.Height = 0.16F;
            this.EmpHd_SectionCode.Left = 0.625F;
            this.EmpHd_SectionCode.MultiLine = false;
            this.EmpHd_SectionCode.Name = "EmpHd_SectionCode";
            this.EmpHd_SectionCode.OutputFormat = resources.GetString("EmpHd_SectionCode.OutputFormat");
            this.EmpHd_SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.EmpHd_SectionCode.Text = "12";
            this.EmpHd_SectionCode.Top = 0F;
            this.EmpHd_SectionCode.Width = 0.2F;
            // 
            // EmpHd_SectionName
            // 
            this.EmpHd_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_SectionName.DataField = "SectionGuideNm";
            this.EmpHd_SectionName.Height = 0.16F;
            this.EmpHd_SectionName.Left = 0.875F;
            this.EmpHd_SectionName.MultiLine = false;
            this.EmpHd_SectionName.Name = "EmpHd_SectionName";
            this.EmpHd_SectionName.OutputFormat = resources.GetString("EmpHd_SectionName.OutputFormat");
            this.EmpHd_SectionName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.EmpHd_SectionName.Text = "あいうえおかきくけこ";
            this.EmpHd_SectionName.Top = 0F;
            this.EmpHd_SectionName.Width = 1.2F;
            // 
            // EmpHd_EmployeeTitle
            // 
            this.EmpHd_EmployeeTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeTitle.Height = 0.16F;
            this.EmpHd_EmployeeTitle.HyperLink = "";
            this.EmpHd_EmployeeTitle.Left = 2.125F;
            this.EmpHd_EmployeeTitle.MultiLine = false;
            this.EmpHd_EmployeeTitle.Name = "EmpHd_EmployeeTitle";
            this.EmpHd_EmployeeTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.EmpHd_EmployeeTitle.Text = "担当者";
            this.EmpHd_EmployeeTitle.Top = 0F;
            this.EmpHd_EmployeeTitle.Width = 0.625F;
            // 
            // EmpHd_EmployeeCode
            // 
            this.EmpHd_EmployeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeCode.DataField = "EmployeeCode";
            this.EmpHd_EmployeeCode.Height = 0.16F;
            this.EmpHd_EmployeeCode.Left = 2.75F;
            this.EmpHd_EmployeeCode.MultiLine = false;
            this.EmpHd_EmployeeCode.Name = "EmpHd_EmployeeCode";
            this.EmpHd_EmployeeCode.OutputFormat = resources.GetString("EmpHd_EmployeeCode.OutputFormat");
            this.EmpHd_EmployeeCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.EmpHd_EmployeeCode.Text = "1234";
            this.EmpHd_EmployeeCode.Top = 0F;
            this.EmpHd_EmployeeCode.Width = 0.54F;
            // 
            // EmpHd_EmployeeName
            // 
            this.EmpHd_EmployeeName.Border.BottomColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.Border.LeftColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.Border.RightColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.Border.TopColor = System.Drawing.Color.Black;
            this.EmpHd_EmployeeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmpHd_EmployeeName.DataField = "EmployeeName";
            this.EmpHd_EmployeeName.Height = 0.16F;
            this.EmpHd_EmployeeName.Left = 3.3125F;
            this.EmpHd_EmployeeName.MultiLine = false;
            this.EmpHd_EmployeeName.Name = "EmpHd_EmployeeName";
            this.EmpHd_EmployeeName.OutputFormat = resources.GetString("EmpHd_EmployeeName.OutputFormat");
            this.EmpHd_EmployeeName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.EmpHd_EmployeeName.Text = "あいうえおかきくけこ";
            this.EmpHd_EmployeeName.Top = 0F;
            this.EmpHd_EmployeeName.Width = 2.3F;
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
            this.line11.Width = 10.8F;
            this.line11.X1 = 0F;
            this.line11.X2 = 10.8F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0F;
            // 
            // SalesEmployeeFooter
            // 
            this.SalesEmployeeFooter.CanShrink = true;
            this.SalesEmployeeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox99,
            this.line6,
            this.em_uMonth12,
            this.em_uMonth05,
            this.em_dMonth05,
            this.em_uMonth06,
            this.em_uMonth08,
            this.em_dMonth06,
            this.em_dMonth08,
            this.em_dMonth12,
            this.em_uMonth03,
            this.em_dMonth04,
            this.em_uMonth09,
            this.em_dMonth09,
            this.em_dMonth10,
            this.em_dMonthTotal,
            this.em_uMonth04,
            this.em_dMonth03,
            this.em_uMonth10,
            this.em_uMonth11,
            this.em_dMonth11,
            this.em_uMonthTotal,
            this.em_uMonthAve,
            this.em_dMonthAve,
            this.em_uMonth07,
            this.em_dMonth07,
            this.em_uMonth02,
            this.em_dMonth02,
            this.em_uMonth01,
            this.em_dMonth01});
            this.SalesEmployeeFooter.Height = 0.467F;
            this.SalesEmployeeFooter.KeepTogether = true;
            this.SalesEmployeeFooter.Name = "SalesEmployeeFooter";
            this.SalesEmployeeFooter.Visible = false;
            this.SalesEmployeeFooter.BeforePrint += new System.EventHandler(this.SalesEmployeeFooter_BeforePrint);
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
            this.textBox99.Height = 0.16F;
            this.textBox99.Left = 1.1375F;
            this.textBox99.MultiLine = false;
            this.textBox99.Name = "textBox99";
            this.textBox99.OutputFormat = resources.GetString("textBox99.OutputFormat");
            this.textBox99.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox99.Text = "担当者計";
            this.textBox99.Top = 0.0625F;
            this.textBox99.Width = 0.7F;
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
            // em_uMonth12
            // 
            this.em_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth12.DataField = "TermSalesComp";
            this.em_uMonth12.Height = 0.156F;
            this.em_uMonth12.Left = 9.047502F;
            this.em_uMonth12.MultiLine = false;
            this.em_uMonth12.Name = "em_uMonth12";
            this.em_uMonth12.OutputFormat = resources.GetString("em_uMonth12.OutputFormat");
            this.em_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth12.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth12.Text = "12,345,678";
            this.em_uMonth12.Top = 0.0625F;
            this.em_uMonth12.Width = 0.51F;
            // 
            // em_uMonth05
            // 
            this.em_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth05.DataField = "StockSalesMoney";
            this.em_uMonth05.Height = 0.156F;
            this.em_uMonth05.Left = 5.4775F;
            this.em_uMonth05.MultiLine = false;
            this.em_uMonth05.Name = "em_uMonth05";
            this.em_uMonth05.OutputFormat = resources.GetString("em_uMonth05.OutputFormat");
            this.em_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth05.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth05.Text = "12,345,678";
            this.em_uMonth05.Top = 0.0625F;
            this.em_uMonth05.Width = 0.51F;
            // 
            // em_dMonth05
            // 
            this.em_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth05.DataField = "TotalStockSalesMoney";
            this.em_dMonth05.Height = 0.156F;
            this.em_dMonth05.Left = 5.4775F;
            this.em_dMonth05.MultiLine = false;
            this.em_dMonth05.Name = "em_dMonth05";
            this.em_dMonth05.OutputFormat = resources.GetString("em_dMonth05.OutputFormat");
            this.em_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth05.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth05.Text = "12,345,678";
            this.em_dMonth05.Top = 0.25F;
            this.em_dMonth05.Width = 0.51F;
            // 
            // em_uMonth06
            // 
            this.em_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth06.DataField = "GrossMoney";
            this.em_uMonth06.Height = 0.156F;
            this.em_uMonth06.Left = 5.9875F;
            this.em_uMonth06.MultiLine = false;
            this.em_uMonth06.Name = "em_uMonth06";
            this.em_uMonth06.OutputFormat = resources.GetString("em_uMonth06.OutputFormat");
            this.em_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth06.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth06.Text = "12,345,678";
            this.em_uMonth06.Top = 0.0625F;
            this.em_uMonth06.Width = 0.51F;
            // 
            // em_uMonth08
            // 
            this.em_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth08.DataField = "CostMoney";
            this.em_uMonth08.Height = 0.156F;
            this.em_uMonth08.Left = 7.007501F;
            this.em_uMonth08.MultiLine = false;
            this.em_uMonth08.Name = "em_uMonth08";
            this.em_uMonth08.OutputFormat = resources.GetString("em_uMonth08.OutputFormat");
            this.em_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth08.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth08.Text = "12,345,678";
            this.em_uMonth08.Top = 0.0625F;
            this.em_uMonth08.Width = 0.51F;
            // 
            // em_dMonth06
            // 
            this.em_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth06.DataField = "TotalGrossMoney";
            this.em_dMonth06.Height = 0.156F;
            this.em_dMonth06.Left = 5.9875F;
            this.em_dMonth06.MultiLine = false;
            this.em_dMonth06.Name = "em_dMonth06";
            this.em_dMonth06.OutputFormat = resources.GetString("em_dMonth06.OutputFormat");
            this.em_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth06.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth06.Text = "12,345,678";
            this.em_dMonth06.Top = 0.25F;
            this.em_dMonth06.Width = 0.51F;
            // 
            // em_dMonth08
            // 
            this.em_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth08.DataField = "TotalCostMoney";
            this.em_dMonth08.Height = 0.156F;
            this.em_dMonth08.Left = 7.007501F;
            this.em_dMonth08.MultiLine = false;
            this.em_dMonth08.Name = "em_dMonth08";
            this.em_dMonth08.OutputFormat = resources.GetString("em_dMonth08.OutputFormat");
            this.em_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth08.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth08.Text = "12,345,678";
            this.em_dMonth08.Top = 0.25F;
            this.em_dMonth08.Width = 0.51F;
            // 
            // em_dMonth12
            // 
            this.em_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth12.DataField = "MonthSalesComp";
            this.em_dMonth12.Height = 0.156F;
            this.em_dMonth12.Left = 9.047502F;
            this.em_dMonth12.MultiLine = false;
            this.em_dMonth12.Name = "em_dMonth12";
            this.em_dMonth12.OutputFormat = resources.GetString("em_dMonth12.OutputFormat");
            this.em_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth12.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth12.Text = "12,345,678";
            this.em_dMonth12.Top = 0.25F;
            this.em_dMonth12.Width = 0.51F;
            // 
            // em_uMonth03
            // 
            this.em_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth03.DataField = "SalesMoney";
            this.em_uMonth03.Height = 0.156F;
            this.em_uMonth03.Left = 4.4575F;
            this.em_uMonth03.MultiLine = false;
            this.em_uMonth03.Name = "em_uMonth03";
            this.em_uMonth03.OutputFormat = resources.GetString("em_uMonth03.OutputFormat");
            this.em_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth03.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth03.Text = "12,345,678";
            this.em_uMonth03.Top = 0.0625F;
            this.em_uMonth03.Width = 0.51F;
            // 
            // em_dMonth04
            // 
            this.em_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth04.DataField = "TotalOrderSalesMoney";
            this.em_dMonth04.Height = 0.156F;
            this.em_dMonth04.Left = 4.9675F;
            this.em_dMonth04.MultiLine = false;
            this.em_dMonth04.Name = "em_dMonth04";
            this.em_dMonth04.OutputFormat = resources.GetString("em_dMonth04.OutputFormat");
            this.em_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth04.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth04.Text = "12,345,678";
            this.em_dMonth04.Top = 0.25F;
            this.em_dMonth04.Width = 0.51F;
            // 
            // em_uMonth09
            // 
            this.em_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth09.DataField = "StockMoney";
            this.em_uMonth09.Height = 0.156F;
            this.em_uMonth09.Left = 7.517501F;
            this.em_uMonth09.MultiLine = false;
            this.em_uMonth09.Name = "em_uMonth09";
            this.em_uMonth09.OutputFormat = resources.GetString("em_uMonth09.OutputFormat");
            this.em_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth09.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth09.Text = "12,345,678";
            this.em_uMonth09.Top = 0.0625F;
            this.em_uMonth09.Width = 0.51F;
            // 
            // em_dMonth09
            // 
            this.em_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth09.DataField = "TotalStockMoney";
            this.em_dMonth09.Height = 0.156F;
            this.em_dMonth09.Left = 7.517501F;
            this.em_dMonth09.MultiLine = false;
            this.em_dMonth09.Name = "em_dMonth09";
            this.em_dMonth09.OutputFormat = resources.GetString("em_dMonth09.OutputFormat");
            this.em_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth09.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth09.Text = "12,345,678";
            this.em_dMonth09.Top = 0.25F;
            this.em_dMonth09.Width = 0.51F;
            // 
            // em_dMonth10
            // 
            this.em_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth10.DataField = "TotalOrderStockMoney";
            this.em_dMonth10.Height = 0.156F;
            this.em_dMonth10.Left = 8.027501F;
            this.em_dMonth10.MultiLine = false;
            this.em_dMonth10.Name = "em_dMonth10";
            this.em_dMonth10.OutputFormat = resources.GetString("em_dMonth10.OutputFormat");
            this.em_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth10.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth10.Text = "12,345,678";
            this.em_dMonth10.Top = 0.25F;
            this.em_dMonth10.Width = 0.51F;
            // 
            // em_dMonthTotal
            // 
            this.em_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthTotal.DataField = "MonthStockComp";
            this.em_dMonthTotal.Height = 0.156F;
            this.em_dMonthTotal.Left = 9.557502F;
            this.em_dMonthTotal.MultiLine = false;
            this.em_dMonthTotal.Name = "em_dMonthTotal";
            this.em_dMonthTotal.OutputFormat = resources.GetString("em_dMonthTotal.OutputFormat");
            this.em_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonthTotal.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonthTotal.Text = "1,234,567,890";
            this.em_dMonthTotal.Top = 0.25F;
            this.em_dMonthTotal.Width = 0.7F;
            // 
            // em_uMonth04
            // 
            this.em_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth04.DataField = "OrderSalesMoney";
            this.em_uMonth04.Height = 0.156F;
            this.em_uMonth04.Left = 4.9675F;
            this.em_uMonth04.MultiLine = false;
            this.em_uMonth04.Name = "em_uMonth04";
            this.em_uMonth04.OutputFormat = resources.GetString("em_uMonth04.OutputFormat");
            this.em_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth04.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth04.Text = "12,345,678";
            this.em_uMonth04.Top = 0.0625F;
            this.em_uMonth04.Width = 0.51F;
            // 
            // em_dMonth03
            // 
            this.em_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth03.DataField = "TotalSalesMoney";
            this.em_dMonth03.Height = 0.156F;
            this.em_dMonth03.Left = 4.4575F;
            this.em_dMonth03.MultiLine = false;
            this.em_dMonth03.Name = "em_dMonth03";
            this.em_dMonth03.OutputFormat = resources.GetString("em_dMonth03.OutputFormat");
            this.em_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth03.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth03.Text = "12,345,678";
            this.em_dMonth03.Top = 0.25F;
            this.em_dMonth03.Width = 0.51F;
            // 
            // em_uMonth10
            // 
            this.em_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth10.DataField = "OrderStockMoney";
            this.em_uMonth10.Height = 0.156F;
            this.em_uMonth10.Left = 8.027501F;
            this.em_uMonth10.MultiLine = false;
            this.em_uMonth10.Name = "em_uMonth10";
            this.em_uMonth10.OutputFormat = resources.GetString("em_uMonth10.OutputFormat");
            this.em_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth10.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth10.Text = "12,345,678";
            this.em_uMonth10.Top = 0.0625F;
            this.em_uMonth10.Width = 0.51F;
            // 
            // em_uMonth11
            // 
            this.em_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth11.DataField = "StockStockMoney";
            this.em_uMonth11.Height = 0.156F;
            this.em_uMonth11.Left = 8.537501F;
            this.em_uMonth11.MultiLine = false;
            this.em_uMonth11.Name = "em_uMonth11";
            this.em_uMonth11.OutputFormat = resources.GetString("em_uMonth11.OutputFormat");
            this.em_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth11.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth11.Text = "12,345,678";
            this.em_uMonth11.Top = 0.0625F;
            this.em_uMonth11.Width = 0.51F;
            // 
            // em_dMonth11
            // 
            this.em_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth11.DataField = "TotalStockStockMoney";
            this.em_dMonth11.Height = 0.156F;
            this.em_dMonth11.Left = 8.537501F;
            this.em_dMonth11.MultiLine = false;
            this.em_dMonth11.Name = "em_dMonth11";
            this.em_dMonth11.OutputFormat = resources.GetString("em_dMonth11.OutputFormat");
            this.em_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth11.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth11.Text = "12,345,678";
            this.em_dMonth11.Top = 0.25F;
            this.em_dMonth11.Width = 0.51F;
            // 
            // em_uMonthTotal
            // 
            this.em_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthTotal.DataField = "TermStockComp";
            this.em_uMonthTotal.Height = 0.156F;
            this.em_uMonthTotal.Left = 9.557502F;
            this.em_uMonthTotal.MultiLine = false;
            this.em_uMonthTotal.Name = "em_uMonthTotal";
            this.em_uMonthTotal.OutputFormat = resources.GetString("em_uMonthTotal.OutputFormat");
            this.em_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonthTotal.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonthTotal.Text = "1,234,567,890";
            this.em_uMonthTotal.Top = 0.0625F;
            this.em_uMonthTotal.Width = 0.7F;
            // 
            // em_uMonthAve
            // 
            this.em_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonthAve.DataField = "Difference";
            this.em_uMonthAve.Height = 0.156F;
            this.em_uMonthAve.Left = 10.2575F;
            this.em_uMonthAve.MultiLine = false;
            this.em_uMonthAve.Name = "em_uMonthAve";
            this.em_uMonthAve.OutputFormat = resources.GetString("em_uMonthAve.OutputFormat");
            this.em_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonthAve.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonthAve.Text = "12,345,678";
            this.em_uMonthAve.Top = 0.0625F;
            this.em_uMonthAve.Width = 0.51F;
            // 
            // em_dMonthAve
            // 
            this.em_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonthAve.DataField = "TotalDifference";
            this.em_dMonthAve.Height = 0.156F;
            this.em_dMonthAve.Left = 10.2575F;
            this.em_dMonthAve.MultiLine = false;
            this.em_dMonthAve.Name = "em_dMonthAve";
            this.em_dMonthAve.OutputFormat = resources.GetString("em_dMonthAve.OutputFormat");
            this.em_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonthAve.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonthAve.Text = "12,345,678";
            this.em_dMonthAve.Top = 0.25F;
            this.em_dMonthAve.Width = 0.51F;
            // 
            // em_uMonth07
            // 
            this.em_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth07.DataField = "GrossMoney";
            this.em_uMonth07.Height = 0.156F;
            this.em_uMonth07.Left = 6.4975F;
            this.em_uMonth07.MultiLine = false;
            this.em_uMonth07.Name = "em_uMonth07";
            this.em_uMonth07.OutputFormat = resources.GetString("em_uMonth07.OutputFormat");
            this.em_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth07.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth07.Text = "12,345,678";
            this.em_uMonth07.Top = 0.0625F;
            this.em_uMonth07.Width = 0.51F;
            // 
            // em_dMonth07
            // 
            this.em_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth07.DataField = "GrossMoney";
            this.em_dMonth07.Height = 0.156F;
            this.em_dMonth07.Left = 6.4975F;
            this.em_dMonth07.MultiLine = false;
            this.em_dMonth07.Name = "em_dMonth07";
            this.em_dMonth07.OutputFormat = resources.GetString("em_dMonth07.OutputFormat");
            this.em_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth07.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth07.Text = "12,345,678";
            this.em_dMonth07.Top = 0.25F;
            this.em_dMonth07.Width = 0.51F;
            // 
            // em_uMonth02
            // 
            this.em_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth02.DataField = "SalesMoney";
            this.em_uMonth02.Height = 0.156F;
            this.em_uMonth02.Left = 3.9475F;
            this.em_uMonth02.MultiLine = false;
            this.em_uMonth02.Name = "em_uMonth02";
            this.em_uMonth02.OutputFormat = resources.GetString("em_uMonth02.OutputFormat");
            this.em_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth02.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth02.Text = "12,345,678";
            this.em_uMonth02.Top = 0.0625F;
            this.em_uMonth02.Width = 0.51F;
            // 
            // em_dMonth02
            // 
            this.em_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth02.DataField = "SalesMoney";
            this.em_dMonth02.Height = 0.156F;
            this.em_dMonth02.Left = 3.9475F;
            this.em_dMonth02.MultiLine = false;
            this.em_dMonth02.Name = "em_dMonth02";
            this.em_dMonth02.OutputFormat = resources.GetString("em_dMonth02.OutputFormat");
            this.em_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth02.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth02.Text = "12,345,678";
            this.em_dMonth02.Top = 0.25F;
            this.em_dMonth02.Width = 0.51F;
            // 
            // em_uMonth01
            // 
            this.em_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.em_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.em_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.em_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.em_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_uMonth01.DataField = "SalesMoney";
            this.em_uMonth01.Height = 0.156F;
            this.em_uMonth01.Left = 3.4375F;
            this.em_uMonth01.MultiLine = false;
            this.em_uMonth01.Name = "em_uMonth01";
            this.em_uMonth01.OutputFormat = resources.GetString("em_uMonth01.OutputFormat");
            this.em_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_uMonth01.SummaryGroup = "SalesEmployeeHeader";
            this.em_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_uMonth01.Text = "12,345,678";
            this.em_uMonth01.Top = 0.0625F;
            this.em_uMonth01.Width = 0.51F;
            // 
            // em_dMonth01
            // 
            this.em_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.em_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.em_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.em_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.em_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.em_dMonth01.DataField = "SalesMoney";
            this.em_dMonth01.Height = 0.156F;
            this.em_dMonth01.Left = 3.4375F;
            this.em_dMonth01.MultiLine = false;
            this.em_dMonth01.Name = "em_dMonth01";
            this.em_dMonth01.OutputFormat = resources.GetString("em_dMonth01.OutputFormat");
            this.em_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.em_dMonth01.SummaryGroup = "SalesEmployeeHeader";
            this.em_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.em_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.em_dMonth01.Text = "12,345,678";
            this.em_dMonth01.Top = 0.25F;
            this.em_dMonth01.Width = 0.51F;
            // 
            // GoodsMGroupHeader
            // 
            this.GoodsMGroupHeader.CanShrink = true;
            this.GoodsMGroupHeader.DataField = "GoodsMGroupField";
            this.GoodsMGroupHeader.Height = 0F;
            this.GoodsMGroupHeader.KeepTogether = true;
            this.GoodsMGroupHeader.Name = "GoodsMGroupHeader";
            this.GoodsMGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.GoodsMGroupHeader.Visible = false;
            // 
            // GoodsMGroupFooter
            // 
            this.GoodsMGroupFooter.CanShrink = true;
            this.GoodsMGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.subTotalGoodsMGroup_textBox,
            this.subTotalGoodsMGroupName_textBox,
            this.mg_dMonth01,
            this.mg_uMonth01,
            this.mg_uMonth02,
            this.mg_dMonth02,
            this.mg_uMonth03,
            this.mg_dMonth03,
            this.mg_uMonth04,
            this.mg_dMonth04,
            this.mg_uMonth05,
            this.mg_dMonth05,
            this.mg_dMonth06,
            this.mg_uMonth06,
            this.mg_uMonth07,
            this.mg_dMonth07,
            this.mg_uMonth08,
            this.mg_dMonth08,
            this.mg_uMonth09,
            this.mg_dMonth09,
            this.mg_uMonth10,
            this.mg_dMonth10,
            this.mg_uMonth11,
            this.mg_dMonth11,
            this.mg_uMonth12,
            this.mg_dMonth12,
            this.mg_uMonthTotal,
            this.mg_dMonthTotal,
            this.mg_uMonthAve,
            this.mg_dMonthAve,
            this.line7});
            this.GoodsMGroupFooter.Height = 0.467F;
            this.GoodsMGroupFooter.KeepTogether = true;
            this.GoodsMGroupFooter.Name = "GoodsMGroupFooter";
            this.GoodsMGroupFooter.Visible = false;
            this.GoodsMGroupFooter.BeforePrint += new System.EventHandler(this.GoodsMGroupFooter_BeforePrint);
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
            this.textBox7.Height = 0.16F;
            this.textBox7.Left = 1.1375F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox7.Text = "商品中分類計";
            this.textBox7.Top = 0.0625F;
            this.textBox7.Width = 0.7F;
            // 
            // subTotalGoodsMGroup_textBox
            // 
            this.subTotalGoodsMGroup_textBox.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroup_textBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroup_textBox.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroup_textBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroup_textBox.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroup_textBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroup_textBox.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroup_textBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroup_textBox.DataField = "GoodsMGroup";
            this.subTotalGoodsMGroup_textBox.Height = 0.156F;
            this.subTotalGoodsMGroup_textBox.Left = 1.8375F;
            this.subTotalGoodsMGroup_textBox.MultiLine = false;
            this.subTotalGoodsMGroup_textBox.Name = "subTotalGoodsMGroup_textBox";
            this.subTotalGoodsMGroup_textBox.OutputFormat = resources.GetString("subTotalGoodsMGroup_textBox.OutputFormat");
            this.subTotalGoodsMGroup_textBox.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.subTotalGoodsMGroup_textBox.Text = "1234";
            this.subTotalGoodsMGroup_textBox.Top = 0.063F;
            this.subTotalGoodsMGroup_textBox.Width = 0.35F;
            // 
            // subTotalGoodsMGroupName_textBox
            // 
            this.subTotalGoodsMGroupName_textBox.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroupName_textBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroupName_textBox.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroupName_textBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroupName_textBox.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroupName_textBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroupName_textBox.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalGoodsMGroupName_textBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalGoodsMGroupName_textBox.DataField = "GoodsMGroupName";
            this.subTotalGoodsMGroupName_textBox.Height = 0.16F;
            this.subTotalGoodsMGroupName_textBox.Left = 2.1875F;
            this.subTotalGoodsMGroupName_textBox.MultiLine = false;
            this.subTotalGoodsMGroupName_textBox.Name = "subTotalGoodsMGroupName_textBox";
            this.subTotalGoodsMGroupName_textBox.OutputFormat = resources.GetString("subTotalGoodsMGroupName_textBox.OutputFormat");
            this.subTotalGoodsMGroupName_textBox.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.subTotalGoodsMGroupName_textBox.Text = "あいうえおかきくけこ";
            this.subTotalGoodsMGroupName_textBox.Top = 0.063F;
            this.subTotalGoodsMGroupName_textBox.Width = 1.2F;
            // 
            // mg_dMonth01
            // 
            this.mg_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth01.DataField = "SalesMoney";
            this.mg_dMonth01.Height = 0.156F;
            this.mg_dMonth01.Left = 3.4375F;
            this.mg_dMonth01.MultiLine = false;
            this.mg_dMonth01.Name = "mg_dMonth01";
            this.mg_dMonth01.OutputFormat = resources.GetString("mg_dMonth01.OutputFormat");
            this.mg_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth01.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth01.Text = "12,345,678";
            this.mg_dMonth01.Top = 0.25F;
            this.mg_dMonth01.Width = 0.51F;
            // 
            // mg_uMonth01
            // 
            this.mg_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth01.DataField = "SalesMoney";
            this.mg_uMonth01.Height = 0.156F;
            this.mg_uMonth01.Left = 3.4375F;
            this.mg_uMonth01.MultiLine = false;
            this.mg_uMonth01.Name = "mg_uMonth01";
            this.mg_uMonth01.OutputFormat = resources.GetString("mg_uMonth01.OutputFormat");
            this.mg_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth01.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth01.Text = "12,345,678";
            this.mg_uMonth01.Top = 0.0625F;
            this.mg_uMonth01.Width = 0.51F;
            // 
            // mg_uMonth02
            // 
            this.mg_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth02.DataField = "SalesMoney";
            this.mg_uMonth02.Height = 0.156F;
            this.mg_uMonth02.Left = 3.9475F;
            this.mg_uMonth02.MultiLine = false;
            this.mg_uMonth02.Name = "mg_uMonth02";
            this.mg_uMonth02.OutputFormat = resources.GetString("mg_uMonth02.OutputFormat");
            this.mg_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth02.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth02.Text = "12,345,678";
            this.mg_uMonth02.Top = 0.0625F;
            this.mg_uMonth02.Width = 0.51F;
            // 
            // mg_dMonth02
            // 
            this.mg_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth02.DataField = "SalesMoney";
            this.mg_dMonth02.Height = 0.156F;
            this.mg_dMonth02.Left = 3.9475F;
            this.mg_dMonth02.MultiLine = false;
            this.mg_dMonth02.Name = "mg_dMonth02";
            this.mg_dMonth02.OutputFormat = resources.GetString("mg_dMonth02.OutputFormat");
            this.mg_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth02.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth02.Text = "12,345,678";
            this.mg_dMonth02.Top = 0.25F;
            this.mg_dMonth02.Width = 0.51F;
            // 
            // mg_uMonth03
            // 
            this.mg_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth03.DataField = "SalesMoney";
            this.mg_uMonth03.Height = 0.156F;
            this.mg_uMonth03.Left = 4.4575F;
            this.mg_uMonth03.MultiLine = false;
            this.mg_uMonth03.Name = "mg_uMonth03";
            this.mg_uMonth03.OutputFormat = resources.GetString("mg_uMonth03.OutputFormat");
            this.mg_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth03.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth03.Text = "12,345,678";
            this.mg_uMonth03.Top = 0.0625F;
            this.mg_uMonth03.Width = 0.51F;
            // 
            // mg_dMonth03
            // 
            this.mg_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth03.DataField = "TotalSalesMoney";
            this.mg_dMonth03.Height = 0.156F;
            this.mg_dMonth03.Left = 4.4575F;
            this.mg_dMonth03.MultiLine = false;
            this.mg_dMonth03.Name = "mg_dMonth03";
            this.mg_dMonth03.OutputFormat = resources.GetString("mg_dMonth03.OutputFormat");
            this.mg_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth03.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth03.Text = "12,345,678";
            this.mg_dMonth03.Top = 0.25F;
            this.mg_dMonth03.Width = 0.51F;
            // 
            // mg_uMonth04
            // 
            this.mg_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth04.DataField = "OrderSalesMoney";
            this.mg_uMonth04.Height = 0.156F;
            this.mg_uMonth04.Left = 4.9675F;
            this.mg_uMonth04.MultiLine = false;
            this.mg_uMonth04.Name = "mg_uMonth04";
            this.mg_uMonth04.OutputFormat = resources.GetString("mg_uMonth04.OutputFormat");
            this.mg_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth04.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth04.Text = "12,345,678";
            this.mg_uMonth04.Top = 0.0625F;
            this.mg_uMonth04.Width = 0.51F;
            // 
            // mg_dMonth04
            // 
            this.mg_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth04.DataField = "TotalOrderSalesMoney";
            this.mg_dMonth04.Height = 0.156F;
            this.mg_dMonth04.Left = 4.9675F;
            this.mg_dMonth04.MultiLine = false;
            this.mg_dMonth04.Name = "mg_dMonth04";
            this.mg_dMonth04.OutputFormat = resources.GetString("mg_dMonth04.OutputFormat");
            this.mg_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth04.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth04.Text = "12,345,678";
            this.mg_dMonth04.Top = 0.25F;
            this.mg_dMonth04.Width = 0.51F;
            // 
            // mg_uMonth05
            // 
            this.mg_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth05.DataField = "StockSalesMoney";
            this.mg_uMonth05.Height = 0.156F;
            this.mg_uMonth05.Left = 5.4775F;
            this.mg_uMonth05.MultiLine = false;
            this.mg_uMonth05.Name = "mg_uMonth05";
            this.mg_uMonth05.OutputFormat = resources.GetString("mg_uMonth05.OutputFormat");
            this.mg_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth05.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth05.Text = "12,345,678";
            this.mg_uMonth05.Top = 0.0625F;
            this.mg_uMonth05.Width = 0.51F;
            // 
            // mg_dMonth05
            // 
            this.mg_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth05.DataField = "TotalStockSalesMoney";
            this.mg_dMonth05.Height = 0.156F;
            this.mg_dMonth05.Left = 5.4775F;
            this.mg_dMonth05.MultiLine = false;
            this.mg_dMonth05.Name = "mg_dMonth05";
            this.mg_dMonth05.OutputFormat = resources.GetString("mg_dMonth05.OutputFormat");
            this.mg_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth05.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth05.Text = "12,345,678";
            this.mg_dMonth05.Top = 0.25F;
            this.mg_dMonth05.Width = 0.51F;
            // 
            // mg_dMonth06
            // 
            this.mg_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth06.DataField = "TotalGrossMoney";
            this.mg_dMonth06.Height = 0.156F;
            this.mg_dMonth06.Left = 5.9875F;
            this.mg_dMonth06.MultiLine = false;
            this.mg_dMonth06.Name = "mg_dMonth06";
            this.mg_dMonth06.OutputFormat = resources.GetString("mg_dMonth06.OutputFormat");
            this.mg_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth06.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth06.Text = "12,345,678";
            this.mg_dMonth06.Top = 0.25F;
            this.mg_dMonth06.Width = 0.51F;
            // 
            // mg_uMonth06
            // 
            this.mg_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth06.DataField = "GrossMoney";
            this.mg_uMonth06.Height = 0.156F;
            this.mg_uMonth06.Left = 5.9875F;
            this.mg_uMonth06.MultiLine = false;
            this.mg_uMonth06.Name = "mg_uMonth06";
            this.mg_uMonth06.OutputFormat = resources.GetString("mg_uMonth06.OutputFormat");
            this.mg_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth06.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth06.Text = "12,345,678";
            this.mg_uMonth06.Top = 0.0625F;
            this.mg_uMonth06.Width = 0.51F;
            // 
            // mg_uMonth07
            // 
            this.mg_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth07.DataField = "GrossMoney";
            this.mg_uMonth07.Height = 0.156F;
            this.mg_uMonth07.Left = 6.4975F;
            this.mg_uMonth07.MultiLine = false;
            this.mg_uMonth07.Name = "mg_uMonth07";
            this.mg_uMonth07.OutputFormat = resources.GetString("mg_uMonth07.OutputFormat");
            this.mg_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth07.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth07.Text = "12,345,678";
            this.mg_uMonth07.Top = 0.0625F;
            this.mg_uMonth07.Width = 0.51F;
            // 
            // mg_dMonth07
            // 
            this.mg_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth07.DataField = "GrossMoney";
            this.mg_dMonth07.Height = 0.156F;
            this.mg_dMonth07.Left = 6.4975F;
            this.mg_dMonth07.MultiLine = false;
            this.mg_dMonth07.Name = "mg_dMonth07";
            this.mg_dMonth07.OutputFormat = resources.GetString("mg_dMonth07.OutputFormat");
            this.mg_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth07.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth07.Text = "12,345,678";
            this.mg_dMonth07.Top = 0.25F;
            this.mg_dMonth07.Width = 0.51F;
            // 
            // mg_uMonth08
            // 
            this.mg_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth08.DataField = "CostMoney";
            this.mg_uMonth08.Height = 0.156F;
            this.mg_uMonth08.Left = 7.007501F;
            this.mg_uMonth08.MultiLine = false;
            this.mg_uMonth08.Name = "mg_uMonth08";
            this.mg_uMonth08.OutputFormat = resources.GetString("mg_uMonth08.OutputFormat");
            this.mg_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth08.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth08.Text = "12,345,678";
            this.mg_uMonth08.Top = 0.0625F;
            this.mg_uMonth08.Width = 0.51F;
            // 
            // mg_dMonth08
            // 
            this.mg_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth08.DataField = "TotalCostMoney";
            this.mg_dMonth08.Height = 0.156F;
            this.mg_dMonth08.Left = 7.007501F;
            this.mg_dMonth08.MultiLine = false;
            this.mg_dMonth08.Name = "mg_dMonth08";
            this.mg_dMonth08.OutputFormat = resources.GetString("mg_dMonth08.OutputFormat");
            this.mg_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth08.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth08.Text = "12,345,678";
            this.mg_dMonth08.Top = 0.25F;
            this.mg_dMonth08.Width = 0.51F;
            // 
            // mg_uMonth09
            // 
            this.mg_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth09.DataField = "StockMoney";
            this.mg_uMonth09.Height = 0.156F;
            this.mg_uMonth09.Left = 7.517501F;
            this.mg_uMonth09.MultiLine = false;
            this.mg_uMonth09.Name = "mg_uMonth09";
            this.mg_uMonth09.OutputFormat = resources.GetString("mg_uMonth09.OutputFormat");
            this.mg_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth09.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth09.Text = "12,345,678";
            this.mg_uMonth09.Top = 0.0625F;
            this.mg_uMonth09.Width = 0.51F;
            // 
            // mg_dMonth09
            // 
            this.mg_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth09.DataField = "TotalStockMoney";
            this.mg_dMonth09.Height = 0.156F;
            this.mg_dMonth09.Left = 7.517501F;
            this.mg_dMonth09.MultiLine = false;
            this.mg_dMonth09.Name = "mg_dMonth09";
            this.mg_dMonth09.OutputFormat = resources.GetString("mg_dMonth09.OutputFormat");
            this.mg_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth09.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth09.Text = "12,345,678";
            this.mg_dMonth09.Top = 0.25F;
            this.mg_dMonth09.Width = 0.51F;
            // 
            // mg_uMonth10
            // 
            this.mg_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth10.DataField = "OrderStockMoney";
            this.mg_uMonth10.Height = 0.156F;
            this.mg_uMonth10.Left = 8.027501F;
            this.mg_uMonth10.MultiLine = false;
            this.mg_uMonth10.Name = "mg_uMonth10";
            this.mg_uMonth10.OutputFormat = resources.GetString("mg_uMonth10.OutputFormat");
            this.mg_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth10.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth10.Text = "12,345,678";
            this.mg_uMonth10.Top = 0.0625F;
            this.mg_uMonth10.Width = 0.51F;
            // 
            // mg_dMonth10
            // 
            this.mg_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth10.DataField = "TotalOrderStockMoney";
            this.mg_dMonth10.Height = 0.156F;
            this.mg_dMonth10.Left = 8.027501F;
            this.mg_dMonth10.MultiLine = false;
            this.mg_dMonth10.Name = "mg_dMonth10";
            this.mg_dMonth10.OutputFormat = resources.GetString("mg_dMonth10.OutputFormat");
            this.mg_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth10.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth10.Text = "12,345,678";
            this.mg_dMonth10.Top = 0.25F;
            this.mg_dMonth10.Width = 0.51F;
            // 
            // mg_uMonth11
            // 
            this.mg_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth11.DataField = "StockStockMoney";
            this.mg_uMonth11.Height = 0.156F;
            this.mg_uMonth11.Left = 8.537501F;
            this.mg_uMonth11.MultiLine = false;
            this.mg_uMonth11.Name = "mg_uMonth11";
            this.mg_uMonth11.OutputFormat = resources.GetString("mg_uMonth11.OutputFormat");
            this.mg_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth11.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth11.Text = "12,345,678";
            this.mg_uMonth11.Top = 0.0625F;
            this.mg_uMonth11.Width = 0.51F;
            // 
            // mg_dMonth11
            // 
            this.mg_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth11.DataField = "TotalStockStockMoney";
            this.mg_dMonth11.Height = 0.156F;
            this.mg_dMonth11.Left = 8.537501F;
            this.mg_dMonth11.MultiLine = false;
            this.mg_dMonth11.Name = "mg_dMonth11";
            this.mg_dMonth11.OutputFormat = resources.GetString("mg_dMonth11.OutputFormat");
            this.mg_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth11.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth11.Text = "12,345,678";
            this.mg_dMonth11.Top = 0.25F;
            this.mg_dMonth11.Width = 0.51F;
            // 
            // mg_uMonth12
            // 
            this.mg_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonth12.DataField = "TermSalesComp";
            this.mg_uMonth12.Height = 0.156F;
            this.mg_uMonth12.Left = 9.047502F;
            this.mg_uMonth12.MultiLine = false;
            this.mg_uMonth12.Name = "mg_uMonth12";
            this.mg_uMonth12.OutputFormat = resources.GetString("mg_uMonth12.OutputFormat");
            this.mg_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonth12.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonth12.Text = "12,345,678";
            this.mg_uMonth12.Top = 0.0625F;
            this.mg_uMonth12.Width = 0.51F;
            // 
            // mg_dMonth12
            // 
            this.mg_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonth12.DataField = "MonthSalesComp";
            this.mg_dMonth12.Height = 0.156F;
            this.mg_dMonth12.Left = 9.047502F;
            this.mg_dMonth12.MultiLine = false;
            this.mg_dMonth12.Name = "mg_dMonth12";
            this.mg_dMonth12.OutputFormat = resources.GetString("mg_dMonth12.OutputFormat");
            this.mg_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonth12.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonth12.Text = "12,345,678";
            this.mg_dMonth12.Top = 0.25F;
            this.mg_dMonth12.Width = 0.51F;
            // 
            // mg_uMonthTotal
            // 
            this.mg_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthTotal.DataField = "TermStockComp";
            this.mg_uMonthTotal.Height = 0.156F;
            this.mg_uMonthTotal.Left = 9.557502F;
            this.mg_uMonthTotal.MultiLine = false;
            this.mg_uMonthTotal.Name = "mg_uMonthTotal";
            this.mg_uMonthTotal.OutputFormat = resources.GetString("mg_uMonthTotal.OutputFormat");
            this.mg_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonthTotal.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonthTotal.Text = "1,234,567,890";
            this.mg_uMonthTotal.Top = 0.0625F;
            this.mg_uMonthTotal.Width = 0.7F;
            // 
            // mg_dMonthTotal
            // 
            this.mg_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthTotal.DataField = "MonthStockComp";
            this.mg_dMonthTotal.Height = 0.156F;
            this.mg_dMonthTotal.Left = 9.557502F;
            this.mg_dMonthTotal.MultiLine = false;
            this.mg_dMonthTotal.Name = "mg_dMonthTotal";
            this.mg_dMonthTotal.OutputFormat = resources.GetString("mg_dMonthTotal.OutputFormat");
            this.mg_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonthTotal.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonthTotal.Text = "1,234,567,890";
            this.mg_dMonthTotal.Top = 0.25F;
            this.mg_dMonthTotal.Width = 0.7F;
            // 
            // mg_uMonthAve
            // 
            this.mg_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.mg_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.mg_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_uMonthAve.DataField = "Difference";
            this.mg_uMonthAve.Height = 0.156F;
            this.mg_uMonthAve.Left = 10.2575F;
            this.mg_uMonthAve.MultiLine = false;
            this.mg_uMonthAve.Name = "mg_uMonthAve";
            this.mg_uMonthAve.OutputFormat = resources.GetString("mg_uMonthAve.OutputFormat");
            this.mg_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_uMonthAve.SummaryGroup = "GoodsMGroupHeader";
            this.mg_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_uMonthAve.Text = "12,345,678";
            this.mg_uMonthAve.Top = 0.0625F;
            this.mg_uMonthAve.Width = 0.51F;
            // 
            // mg_dMonthAve
            // 
            this.mg_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.mg_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.mg_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.mg_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.mg_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mg_dMonthAve.DataField = "TotalDifference";
            this.mg_dMonthAve.Height = 0.156F;
            this.mg_dMonthAve.Left = 10.2575F;
            this.mg_dMonthAve.MultiLine = false;
            this.mg_dMonthAve.Name = "mg_dMonthAve";
            this.mg_dMonthAve.OutputFormat = resources.GetString("mg_dMonthAve.OutputFormat");
            this.mg_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.mg_dMonthAve.SummaryGroup = "GoodsMGroupHeader";
            this.mg_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mg_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mg_dMonthAve.Text = "12,345,678";
            this.mg_dMonthAve.Top = 0.25F;
            this.mg_dMonthAve.Width = 0.51F;
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
            // SuplierHeader
            // 
            this.SuplierHeader.CanShrink = true;
            this.SuplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupHd_SupplierTitle,
            this.SupHd_SupplierCode,
            this.SupHd_SupplierName,
            this.SupHd_SectionName,
            this.SupHd_SectionTitle,
            this.SupHd_SectionCode,
            this.line4});
            this.SuplierHeader.DataField = "SuplierField";
            this.SuplierHeader.Height = 0.2395833F;
            this.SuplierHeader.KeepTogether = true;
            this.SuplierHeader.Name = "SuplierHeader";
            this.SuplierHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SuplierHeader.Visible = false;
            this.SuplierHeader.BeforePrint += new System.EventHandler(this.SuplierHeader_BeforePrint);
            // 
            // SupHd_SupplierTitle
            // 
            this.SupHd_SupplierTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Height = 0.16F;
            this.SupHd_SupplierTitle.HyperLink = "";
            this.SupHd_SupplierTitle.Left = 2.125F;
            this.SupHd_SupplierTitle.MultiLine = false;
            this.SupHd_SupplierTitle.Name = "SupHd_SupplierTitle";
            this.SupHd_SupplierTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SupplierTitle.Text = "仕入先";
            this.SupHd_SupplierTitle.Top = 0F;
            this.SupHd_SupplierTitle.Width = 0.625F;
            // 
            // SupHd_SupplierCode
            // 
            this.SupHd_SupplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCode.DataField = "SupplierCd";
            this.SupHd_SupplierCode.Height = 0.16F;
            this.SupHd_SupplierCode.Left = 2.75F;
            this.SupHd_SupplierCode.MultiLine = false;
            this.SupHd_SupplierCode.Name = "SupHd_SupplierCode";
            this.SupHd_SupplierCode.OutputFormat = resources.GetString("SupHd_SupplierCode.OutputFormat");
            this.SupHd_SupplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_SupplierCode.Text = "123456";
            this.SupHd_SupplierCode.Top = 0F;
            this.SupHd_SupplierCode.Width = 0.54F;
            // 
            // SupHd_SupplierName
            // 
            this.SupHd_SupplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierName.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierName.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierName.DataField = "SupplierNm";
            this.SupHd_SupplierName.Height = 0.16F;
            this.SupHd_SupplierName.Left = 3.3125F;
            this.SupHd_SupplierName.MultiLine = false;
            this.SupHd_SupplierName.Name = "SupHd_SupplierName";
            this.SupHd_SupplierName.OutputFormat = resources.GetString("SupHd_SupplierName.OutputFormat");
            this.SupHd_SupplierName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SupHd_SupplierName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupHd_SupplierName.Top = 0F;
            this.SupHd_SupplierName.Width = 2.3F;
            // 
            // SupHd_SectionName
            // 
            this.SupHd_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionName.DataField = "SectionGuideNm";
            this.SupHd_SectionName.Height = 0.16F;
            this.SupHd_SectionName.Left = 0.875F;
            this.SupHd_SectionName.MultiLine = false;
            this.SupHd_SectionName.Name = "SupHd_SectionName";
            this.SupHd_SectionName.OutputFormat = resources.GetString("SupHd_SectionName.OutputFormat");
            this.SupHd_SectionName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SupHd_SectionName.Text = "あいうえおかきくけこ";
            this.SupHd_SectionName.Top = 0F;
            this.SupHd_SectionName.Width = 1.2F;
            // 
            // SupHd_SectionTitle
            // 
            this.SupHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Height = 0.16F;
            this.SupHd_SectionTitle.HyperLink = "";
            this.SupHd_SectionTitle.Left = 0F;
            this.SupHd_SectionTitle.MultiLine = false;
            this.SupHd_SectionTitle.Name = "SupHd_SectionTitle";
            this.SupHd_SectionTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SectionTitle.Text = "拠点";
            this.SupHd_SectionTitle.Top = 0F;
            this.SupHd_SectionTitle.Width = 0.55F;
            // 
            // SupHd_SectionCode
            // 
            this.SupHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionCode.DataField = "AddUpSecCode";
            this.SupHd_SectionCode.Height = 0.16F;
            this.SupHd_SectionCode.Left = 0.625F;
            this.SupHd_SectionCode.MultiLine = false;
            this.SupHd_SectionCode.Name = "SupHd_SectionCode";
            this.SupHd_SectionCode.OutputFormat = resources.GetString("SupHd_SectionCode.OutputFormat");
            this.SupHd_SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_SectionCode.Text = "12";
            this.SupHd_SectionCode.Top = 0F;
            this.SupHd_SectionCode.Width = 0.2F;
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
            // SuplierFooter
            // 
            this.SuplierFooter.CanShrink = true;
            this.SuplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox13,
            this.su_dMonth01,
            this.su_uMonth01,
            this.su_uMonth02,
            this.su_dMonth02,
            this.su_uMonth03,
            this.su_dMonth03,
            this.su_uMonth04,
            this.su_dMonth04,
            this.su_uMonth05,
            this.su_dMonth05,
            this.su_dMonth06,
            this.su_uMonth06,
            this.su_uMonth07,
            this.su_dMonth07,
            this.su_uMonth08,
            this.su_dMonth08,
            this.su_uMonth09,
            this.su_dMonth09,
            this.su_uMonth10,
            this.su_dMonth10,
            this.su_uMonth11,
            this.su_dMonth11,
            this.su_uMonth12,
            this.su_dMonth12,
            this.su_uMonthTotal,
            this.su_dMonthTotal,
            this.su_uMonthAve,
            this.su_dMonthAve,
            this.line10});
            this.SuplierFooter.Height = 0.467F;
            this.SuplierFooter.KeepTogether = true;
            this.SuplierFooter.Name = "SuplierFooter";
            this.SuplierFooter.Visible = false;
            this.SuplierFooter.BeforePrint += new System.EventHandler(this.SuplierFooter_BeforePrint);
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
            this.textBox13.Height = 0.16F;
            this.textBox13.Left = 1.1375F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox13.Text = "仕入先計";
            this.textBox13.Top = 0.0625F;
            this.textBox13.Width = 0.7F;
            // 
            // su_dMonth01
            // 
            this.su_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth01.DataField = "SalesMoney";
            this.su_dMonth01.Height = 0.156F;
            this.su_dMonth01.Left = 3.4375F;
            this.su_dMonth01.MultiLine = false;
            this.su_dMonth01.Name = "su_dMonth01";
            this.su_dMonth01.OutputFormat = resources.GetString("su_dMonth01.OutputFormat");
            this.su_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth01.SummaryGroup = "SuplierHeader";
            this.su_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth01.Text = "12,345,678";
            this.su_dMonth01.Top = 0.25F;
            this.su_dMonth01.Width = 0.51F;
            // 
            // su_uMonth01
            // 
            this.su_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth01.DataField = "SalesMoney";
            this.su_uMonth01.Height = 0.156F;
            this.su_uMonth01.Left = 3.4375F;
            this.su_uMonth01.MultiLine = false;
            this.su_uMonth01.Name = "su_uMonth01";
            this.su_uMonth01.OutputFormat = resources.GetString("su_uMonth01.OutputFormat");
            this.su_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth01.SummaryGroup = "SuplierHeader";
            this.su_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth01.Text = "12,345,678";
            this.su_uMonth01.Top = 0.0625F;
            this.su_uMonth01.Width = 0.51F;
            // 
            // su_uMonth02
            // 
            this.su_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth02.DataField = "SalesMoney";
            this.su_uMonth02.Height = 0.156F;
            this.su_uMonth02.Left = 3.9475F;
            this.su_uMonth02.MultiLine = false;
            this.su_uMonth02.Name = "su_uMonth02";
            this.su_uMonth02.OutputFormat = resources.GetString("su_uMonth02.OutputFormat");
            this.su_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth02.SummaryGroup = "SuplierHeader";
            this.su_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth02.Text = "12,345,678";
            this.su_uMonth02.Top = 0.0625F;
            this.su_uMonth02.Width = 0.51F;
            // 
            // su_dMonth02
            // 
            this.su_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth02.DataField = "SalesMoney";
            this.su_dMonth02.Height = 0.156F;
            this.su_dMonth02.Left = 3.9475F;
            this.su_dMonth02.MultiLine = false;
            this.su_dMonth02.Name = "su_dMonth02";
            this.su_dMonth02.OutputFormat = resources.GetString("su_dMonth02.OutputFormat");
            this.su_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth02.SummaryGroup = "SuplierHeader";
            this.su_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth02.Text = "12,345,678";
            this.su_dMonth02.Top = 0.25F;
            this.su_dMonth02.Width = 0.51F;
            // 
            // su_uMonth03
            // 
            this.su_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth03.DataField = "SalesMoney";
            this.su_uMonth03.Height = 0.156F;
            this.su_uMonth03.Left = 4.4575F;
            this.su_uMonth03.MultiLine = false;
            this.su_uMonth03.Name = "su_uMonth03";
            this.su_uMonth03.OutputFormat = resources.GetString("su_uMonth03.OutputFormat");
            this.su_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth03.SummaryGroup = "SuplierHeader";
            this.su_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth03.Text = "12,345,678";
            this.su_uMonth03.Top = 0.0625F;
            this.su_uMonth03.Width = 0.51F;
            // 
            // su_dMonth03
            // 
            this.su_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth03.DataField = "TotalSalesMoney";
            this.su_dMonth03.Height = 0.156F;
            this.su_dMonth03.Left = 4.4575F;
            this.su_dMonth03.MultiLine = false;
            this.su_dMonth03.Name = "su_dMonth03";
            this.su_dMonth03.OutputFormat = resources.GetString("su_dMonth03.OutputFormat");
            this.su_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth03.SummaryGroup = "SuplierHeader";
            this.su_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth03.Text = "12,345,678";
            this.su_dMonth03.Top = 0.25F;
            this.su_dMonth03.Width = 0.51F;
            // 
            // su_uMonth04
            // 
            this.su_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth04.DataField = "OrderSalesMoney";
            this.su_uMonth04.Height = 0.156F;
            this.su_uMonth04.Left = 4.9675F;
            this.su_uMonth04.MultiLine = false;
            this.su_uMonth04.Name = "su_uMonth04";
            this.su_uMonth04.OutputFormat = resources.GetString("su_uMonth04.OutputFormat");
            this.su_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth04.SummaryGroup = "SuplierHeader";
            this.su_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth04.Text = "12,345,678";
            this.su_uMonth04.Top = 0.0625F;
            this.su_uMonth04.Width = 0.51F;
            // 
            // su_dMonth04
            // 
            this.su_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth04.DataField = "TotalOrderSalesMoney";
            this.su_dMonth04.Height = 0.156F;
            this.su_dMonth04.Left = 4.9675F;
            this.su_dMonth04.MultiLine = false;
            this.su_dMonth04.Name = "su_dMonth04";
            this.su_dMonth04.OutputFormat = resources.GetString("su_dMonth04.OutputFormat");
            this.su_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth04.SummaryGroup = "SuplierHeader";
            this.su_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth04.Text = "12,345,678";
            this.su_dMonth04.Top = 0.25F;
            this.su_dMonth04.Width = 0.51F;
            // 
            // su_uMonth05
            // 
            this.su_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth05.DataField = "StockSalesMoney";
            this.su_uMonth05.Height = 0.156F;
            this.su_uMonth05.Left = 5.4775F;
            this.su_uMonth05.MultiLine = false;
            this.su_uMonth05.Name = "su_uMonth05";
            this.su_uMonth05.OutputFormat = resources.GetString("su_uMonth05.OutputFormat");
            this.su_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth05.SummaryGroup = "SuplierHeader";
            this.su_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth05.Text = "12,345,678";
            this.su_uMonth05.Top = 0.0625F;
            this.su_uMonth05.Width = 0.51F;
            // 
            // su_dMonth05
            // 
            this.su_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth05.DataField = "TotalStockSalesMoney";
            this.su_dMonth05.Height = 0.156F;
            this.su_dMonth05.Left = 5.4775F;
            this.su_dMonth05.MultiLine = false;
            this.su_dMonth05.Name = "su_dMonth05";
            this.su_dMonth05.OutputFormat = resources.GetString("su_dMonth05.OutputFormat");
            this.su_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth05.SummaryGroup = "SuplierHeader";
            this.su_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth05.Text = "12,345,678";
            this.su_dMonth05.Top = 0.25F;
            this.su_dMonth05.Width = 0.51F;
            // 
            // su_dMonth06
            // 
            this.su_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth06.DataField = "TotalGrossMoney";
            this.su_dMonth06.Height = 0.156F;
            this.su_dMonth06.Left = 5.9875F;
            this.su_dMonth06.MultiLine = false;
            this.su_dMonth06.Name = "su_dMonth06";
            this.su_dMonth06.OutputFormat = resources.GetString("su_dMonth06.OutputFormat");
            this.su_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth06.SummaryGroup = "SuplierHeader";
            this.su_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth06.Text = "12,345,678";
            this.su_dMonth06.Top = 0.25F;
            this.su_dMonth06.Width = 0.51F;
            // 
            // su_uMonth06
            // 
            this.su_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth06.DataField = "GrossMoney";
            this.su_uMonth06.Height = 0.156F;
            this.su_uMonth06.Left = 5.9875F;
            this.su_uMonth06.MultiLine = false;
            this.su_uMonth06.Name = "su_uMonth06";
            this.su_uMonth06.OutputFormat = resources.GetString("su_uMonth06.OutputFormat");
            this.su_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth06.SummaryGroup = "SuplierHeader";
            this.su_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth06.Text = "12,345,678";
            this.su_uMonth06.Top = 0.0625F;
            this.su_uMonth06.Width = 0.51F;
            // 
            // su_uMonth07
            // 
            this.su_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth07.DataField = "GrossMoney";
            this.su_uMonth07.Height = 0.156F;
            this.su_uMonth07.Left = 6.4975F;
            this.su_uMonth07.MultiLine = false;
            this.su_uMonth07.Name = "su_uMonth07";
            this.su_uMonth07.OutputFormat = resources.GetString("su_uMonth07.OutputFormat");
            this.su_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth07.SummaryGroup = "SuplierHeader";
            this.su_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth07.Text = "12,345,678";
            this.su_uMonth07.Top = 0.0625F;
            this.su_uMonth07.Width = 0.51F;
            // 
            // su_dMonth07
            // 
            this.su_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth07.DataField = "GrossMoney";
            this.su_dMonth07.Height = 0.156F;
            this.su_dMonth07.Left = 6.4975F;
            this.su_dMonth07.MultiLine = false;
            this.su_dMonth07.Name = "su_dMonth07";
            this.su_dMonth07.OutputFormat = resources.GetString("su_dMonth07.OutputFormat");
            this.su_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth07.SummaryGroup = "SuplierHeader";
            this.su_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth07.Text = "12,345,678";
            this.su_dMonth07.Top = 0.25F;
            this.su_dMonth07.Width = 0.51F;
            // 
            // su_uMonth08
            // 
            this.su_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth08.DataField = "CostMoney";
            this.su_uMonth08.Height = 0.156F;
            this.su_uMonth08.Left = 7.007501F;
            this.su_uMonth08.MultiLine = false;
            this.su_uMonth08.Name = "su_uMonth08";
            this.su_uMonth08.OutputFormat = resources.GetString("su_uMonth08.OutputFormat");
            this.su_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth08.SummaryGroup = "SuplierHeader";
            this.su_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth08.Text = "12,345,678";
            this.su_uMonth08.Top = 0.0625F;
            this.su_uMonth08.Width = 0.51F;
            // 
            // su_dMonth08
            // 
            this.su_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth08.DataField = "TotalCostMoney";
            this.su_dMonth08.Height = 0.156F;
            this.su_dMonth08.Left = 7.007501F;
            this.su_dMonth08.MultiLine = false;
            this.su_dMonth08.Name = "su_dMonth08";
            this.su_dMonth08.OutputFormat = resources.GetString("su_dMonth08.OutputFormat");
            this.su_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth08.SummaryGroup = "SuplierHeader";
            this.su_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth08.Text = "12,345,678";
            this.su_dMonth08.Top = 0.25F;
            this.su_dMonth08.Width = 0.51F;
            // 
            // su_uMonth09
            // 
            this.su_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth09.DataField = "StockMoney";
            this.su_uMonth09.Height = 0.156F;
            this.su_uMonth09.Left = 7.517501F;
            this.su_uMonth09.MultiLine = false;
            this.su_uMonth09.Name = "su_uMonth09";
            this.su_uMonth09.OutputFormat = resources.GetString("su_uMonth09.OutputFormat");
            this.su_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth09.SummaryGroup = "SuplierHeader";
            this.su_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth09.Text = "12,345,678";
            this.su_uMonth09.Top = 0.0625F;
            this.su_uMonth09.Width = 0.51F;
            // 
            // su_dMonth09
            // 
            this.su_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth09.DataField = "TotalStockMoney";
            this.su_dMonth09.Height = 0.156F;
            this.su_dMonth09.Left = 7.517501F;
            this.su_dMonth09.MultiLine = false;
            this.su_dMonth09.Name = "su_dMonth09";
            this.su_dMonth09.OutputFormat = resources.GetString("su_dMonth09.OutputFormat");
            this.su_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth09.SummaryGroup = "SuplierHeader";
            this.su_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth09.Text = "12,345,678";
            this.su_dMonth09.Top = 0.25F;
            this.su_dMonth09.Width = 0.51F;
            // 
            // su_uMonth10
            // 
            this.su_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth10.DataField = "OrderStockMoney";
            this.su_uMonth10.Height = 0.156F;
            this.su_uMonth10.Left = 8.027501F;
            this.su_uMonth10.MultiLine = false;
            this.su_uMonth10.Name = "su_uMonth10";
            this.su_uMonth10.OutputFormat = resources.GetString("su_uMonth10.OutputFormat");
            this.su_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth10.SummaryGroup = "SuplierHeader";
            this.su_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth10.Text = "12,345,678";
            this.su_uMonth10.Top = 0.0625F;
            this.su_uMonth10.Width = 0.51F;
            // 
            // su_dMonth10
            // 
            this.su_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth10.DataField = "TotalOrderStockMoney";
            this.su_dMonth10.Height = 0.156F;
            this.su_dMonth10.Left = 8.027501F;
            this.su_dMonth10.MultiLine = false;
            this.su_dMonth10.Name = "su_dMonth10";
            this.su_dMonth10.OutputFormat = resources.GetString("su_dMonth10.OutputFormat");
            this.su_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth10.SummaryGroup = "SuplierHeader";
            this.su_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth10.Text = "12,345,678";
            this.su_dMonth10.Top = 0.25F;
            this.su_dMonth10.Width = 0.51F;
            // 
            // su_uMonth11
            // 
            this.su_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth11.DataField = "StockStockMoney";
            this.su_uMonth11.Height = 0.156F;
            this.su_uMonth11.Left = 8.537501F;
            this.su_uMonth11.MultiLine = false;
            this.su_uMonth11.Name = "su_uMonth11";
            this.su_uMonth11.OutputFormat = resources.GetString("su_uMonth11.OutputFormat");
            this.su_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth11.SummaryGroup = "SuplierHeader";
            this.su_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth11.Text = "12,345,678";
            this.su_uMonth11.Top = 0.0625F;
            this.su_uMonth11.Width = 0.51F;
            // 
            // su_dMonth11
            // 
            this.su_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth11.DataField = "TotalStockStockMoney";
            this.su_dMonth11.Height = 0.156F;
            this.su_dMonth11.Left = 8.537501F;
            this.su_dMonth11.MultiLine = false;
            this.su_dMonth11.Name = "su_dMonth11";
            this.su_dMonth11.OutputFormat = resources.GetString("su_dMonth11.OutputFormat");
            this.su_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth11.SummaryGroup = "SuplierHeader";
            this.su_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth11.Text = "12,345,678";
            this.su_dMonth11.Top = 0.25F;
            this.su_dMonth11.Width = 0.51F;
            // 
            // su_uMonth12
            // 
            this.su_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonth12.DataField = "TermSalesComp";
            this.su_uMonth12.Height = 0.156F;
            this.su_uMonth12.Left = 9.047502F;
            this.su_uMonth12.MultiLine = false;
            this.su_uMonth12.Name = "su_uMonth12";
            this.su_uMonth12.OutputFormat = resources.GetString("su_uMonth12.OutputFormat");
            this.su_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonth12.SummaryGroup = "SuplierHeader";
            this.su_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonth12.Text = "12,345,678";
            this.su_uMonth12.Top = 0.0625F;
            this.su_uMonth12.Width = 0.51F;
            // 
            // su_dMonth12
            // 
            this.su_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonth12.DataField = "MonthSalesComp";
            this.su_dMonth12.Height = 0.156F;
            this.su_dMonth12.Left = 9.047502F;
            this.su_dMonth12.MultiLine = false;
            this.su_dMonth12.Name = "su_dMonth12";
            this.su_dMonth12.OutputFormat = resources.GetString("su_dMonth12.OutputFormat");
            this.su_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonth12.SummaryGroup = "SuplierHeader";
            this.su_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonth12.Text = "12,345,678";
            this.su_dMonth12.Top = 0.25F;
            this.su_dMonth12.Width = 0.51F;
            // 
            // su_uMonthTotal
            // 
            this.su_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthTotal.DataField = "TermStockComp";
            this.su_uMonthTotal.Height = 0.156F;
            this.su_uMonthTotal.Left = 9.557502F;
            this.su_uMonthTotal.MultiLine = false;
            this.su_uMonthTotal.Name = "su_uMonthTotal";
            this.su_uMonthTotal.OutputFormat = resources.GetString("su_uMonthTotal.OutputFormat");
            this.su_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonthTotal.SummaryGroup = "SuplierHeader";
            this.su_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonthTotal.Text = "1,234,567,890";
            this.su_uMonthTotal.Top = 0.0625F;
            this.su_uMonthTotal.Width = 0.7F;
            // 
            // su_dMonthTotal
            // 
            this.su_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthTotal.DataField = "MonthStockComp";
            this.su_dMonthTotal.Height = 0.156F;
            this.su_dMonthTotal.Left = 9.557502F;
            this.su_dMonthTotal.MultiLine = false;
            this.su_dMonthTotal.Name = "su_dMonthTotal";
            this.su_dMonthTotal.OutputFormat = resources.GetString("su_dMonthTotal.OutputFormat");
            this.su_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonthTotal.SummaryGroup = "SuplierHeader";
            this.su_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonthTotal.Text = "1,234,567,890";
            this.su_dMonthTotal.Top = 0.25F;
            this.su_dMonthTotal.Width = 0.7F;
            // 
            // su_uMonthAve
            // 
            this.su_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.su_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.su_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.su_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.su_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_uMonthAve.DataField = "Difference";
            this.su_uMonthAve.Height = 0.156F;
            this.su_uMonthAve.Left = 10.2575F;
            this.su_uMonthAve.MultiLine = false;
            this.su_uMonthAve.Name = "su_uMonthAve";
            this.su_uMonthAve.OutputFormat = resources.GetString("su_uMonthAve.OutputFormat");
            this.su_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_uMonthAve.SummaryGroup = "SuplierHeader";
            this.su_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_uMonthAve.Text = "12,345,678";
            this.su_uMonthAve.Top = 0.0625F;
            this.su_uMonthAve.Width = 0.51F;
            // 
            // su_dMonthAve
            // 
            this.su_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.su_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.su_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.su_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.su_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.su_dMonthAve.DataField = "TotalDifference";
            this.su_dMonthAve.Height = 0.156F;
            this.su_dMonthAve.Left = 10.2575F;
            this.su_dMonthAve.MultiLine = false;
            this.su_dMonthAve.Name = "su_dMonthAve";
            this.su_dMonthAve.OutputFormat = resources.GetString("su_dMonthAve.OutputFormat");
            this.su_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.su_dMonthAve.SummaryGroup = "SuplierHeader";
            this.su_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.su_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.su_dMonthAve.Text = "12,345,678";
            this.su_dMonthAve.Top = 0.25F;
            this.su_dMonthAve.Width = 0.51F;
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
            // BLGroupHeader
            // 
            this.BLGroupHeader.CanShrink = true;
            this.BLGroupHeader.DataField = "BLGroupField";
            this.BLGroupHeader.Height = 0F;
            this.BLGroupHeader.KeepTogether = true;
            this.BLGroupHeader.Name = "BLGroupHeader";
            this.BLGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.BLGroupHeader.Visible = false;
            this.BLGroupHeader.BeforePrint += new System.EventHandler(this.BLGroupHeader_BeforePrint);
            // 
            // BLGroupFooter
            // 
            this.BLGroupFooter.CanShrink = true;
            this.BLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox21,
            this.subTotalBLGroupCode_textbox,
            this.subTotalBLGroupKanaName_textBox,
            this.gr_dMonth01,
            this.gr_uMonth01,
            this.gr_uMonth02,
            this.gr_dMonth02,
            this.gr_uMonth03,
            this.gr_dMonth03,
            this.gr_uMonth04,
            this.gr_dMonth04,
            this.gr_uMonth05,
            this.gr_dMonth05,
            this.gr_dMonth06,
            this.gr_uMonth06,
            this.gr_uMonth07,
            this.gr_dMonth07,
            this.gr_uMonth08,
            this.gr_dMonth08,
            this.gr_uMonth09,
            this.gr_dMonth09,
            this.gr_uMonth10,
            this.gr_dMonth10,
            this.gr_uMonth11,
            this.gr_dMonth11,
            this.gr_uMonth12,
            this.gr_dMonth12,
            this.gr_uMonthTotal,
            this.gr_dMonthTotal,
            this.gr_uMonthAve,
            this.gr_dMonthAve,
            this.line8});
            this.BLGroupFooter.Height = 0.467F;
            this.BLGroupFooter.Name = "BLGroupFooter";
            this.BLGroupFooter.Visible = false;
            this.BLGroupFooter.BeforePrint += new System.EventHandler(this.BLGroupFooter_BeforePrint);
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
            this.textBox21.Height = 0.16F;
            this.textBox21.Left = 1.1375F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox21.Text = "グループ計";
            this.textBox21.Top = 0.063F;
            this.textBox21.Width = 0.7F;
            // 
            // subTotalBLGroupCode_textbox
            // 
            this.subTotalBLGroupCode_textbox.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode_textbox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode_textbox.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode_textbox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode_textbox.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode_textbox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode_textbox.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode_textbox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode_textbox.DataField = "BLGroupCode";
            this.subTotalBLGroupCode_textbox.Height = 0.156F;
            this.subTotalBLGroupCode_textbox.Left = 1.8375F;
            this.subTotalBLGroupCode_textbox.MultiLine = false;
            this.subTotalBLGroupCode_textbox.Name = "subTotalBLGroupCode_textbox";
            this.subTotalBLGroupCode_textbox.OutputFormat = resources.GetString("subTotalBLGroupCode_textbox.OutputFormat");
            this.subTotalBLGroupCode_textbox.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.subTotalBLGroupCode_textbox.Text = "12345";
            this.subTotalBLGroupCode_textbox.Top = 0.063F;
            this.subTotalBLGroupCode_textbox.Width = 0.35F;
            // 
            // subTotalBLGroupKanaName_textBox
            // 
            this.subTotalBLGroupKanaName_textBox.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName_textBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName_textBox.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName_textBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName_textBox.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName_textBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName_textBox.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName_textBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName_textBox.DataField = "BLGroupKanaName";
            this.subTotalBLGroupKanaName_textBox.Height = 0.156F;
            this.subTotalBLGroupKanaName_textBox.Left = 2.1875F;
            this.subTotalBLGroupKanaName_textBox.MultiLine = false;
            this.subTotalBLGroupKanaName_textBox.Name = "subTotalBLGroupKanaName_textBox";
            this.subTotalBLGroupKanaName_textBox.OutputFormat = resources.GetString("subTotalBLGroupKanaName_textBox.OutputFormat");
            this.subTotalBLGroupKanaName_textBox.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; white-space: nowrap; vertical-align: top; ";
            this.subTotalBLGroupKanaName_textBox.Text = "12345678901234567890";
            this.subTotalBLGroupKanaName_textBox.Top = 0.0625F;
            this.subTotalBLGroupKanaName_textBox.Width = 1.2F;
            // 
            // gr_dMonth01
            // 
            this.gr_dMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth01.DataField = "SalesMoney";
            this.gr_dMonth01.Height = 0.156F;
            this.gr_dMonth01.Left = 3.4375F;
            this.gr_dMonth01.MultiLine = false;
            this.gr_dMonth01.Name = "gr_dMonth01";
            this.gr_dMonth01.OutputFormat = resources.GetString("gr_dMonth01.OutputFormat");
            this.gr_dMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth01.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth01.Text = "12,345,678";
            this.gr_dMonth01.Top = 0.25F;
            this.gr_dMonth01.Width = 0.51F;
            // 
            // gr_uMonth01
            // 
            this.gr_uMonth01.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth01.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth01.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth01.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth01.DataField = "SalesMoney";
            this.gr_uMonth01.Height = 0.156F;
            this.gr_uMonth01.Left = 3.4375F;
            this.gr_uMonth01.MultiLine = false;
            this.gr_uMonth01.Name = "gr_uMonth01";
            this.gr_uMonth01.OutputFormat = resources.GetString("gr_uMonth01.OutputFormat");
            this.gr_uMonth01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth01.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth01.Text = "12,345,678";
            this.gr_uMonth01.Top = 0.0625F;
            this.gr_uMonth01.Width = 0.51F;
            // 
            // gr_uMonth02
            // 
            this.gr_uMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth02.DataField = "SalesMoney";
            this.gr_uMonth02.Height = 0.156F;
            this.gr_uMonth02.Left = 3.9475F;
            this.gr_uMonth02.MultiLine = false;
            this.gr_uMonth02.Name = "gr_uMonth02";
            this.gr_uMonth02.OutputFormat = resources.GetString("gr_uMonth02.OutputFormat");
            this.gr_uMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth02.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth02.Text = "12,345,678";
            this.gr_uMonth02.Top = 0.0625F;
            this.gr_uMonth02.Width = 0.51F;
            // 
            // gr_dMonth02
            // 
            this.gr_dMonth02.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth02.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth02.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth02.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth02.DataField = "SalesMoney";
            this.gr_dMonth02.Height = 0.156F;
            this.gr_dMonth02.Left = 3.9475F;
            this.gr_dMonth02.MultiLine = false;
            this.gr_dMonth02.Name = "gr_dMonth02";
            this.gr_dMonth02.OutputFormat = resources.GetString("gr_dMonth02.OutputFormat");
            this.gr_dMonth02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth02.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth02.Text = "12,345,678";
            this.gr_dMonth02.Top = 0.25F;
            this.gr_dMonth02.Width = 0.51F;
            // 
            // gr_uMonth03
            // 
            this.gr_uMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth03.DataField = "SalesMoney";
            this.gr_uMonth03.Height = 0.156F;
            this.gr_uMonth03.Left = 4.4575F;
            this.gr_uMonth03.MultiLine = false;
            this.gr_uMonth03.Name = "gr_uMonth03";
            this.gr_uMonth03.OutputFormat = resources.GetString("gr_uMonth03.OutputFormat");
            this.gr_uMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth03.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth03.Text = "12,345,678";
            this.gr_uMonth03.Top = 0.0625F;
            this.gr_uMonth03.Width = 0.51F;
            // 
            // gr_dMonth03
            // 
            this.gr_dMonth03.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth03.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth03.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth03.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth03.DataField = "TotalSalesMoney";
            this.gr_dMonth03.Height = 0.156F;
            this.gr_dMonth03.Left = 4.4575F;
            this.gr_dMonth03.MultiLine = false;
            this.gr_dMonth03.Name = "gr_dMonth03";
            this.gr_dMonth03.OutputFormat = resources.GetString("gr_dMonth03.OutputFormat");
            this.gr_dMonth03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth03.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth03.Text = "12,345,678";
            this.gr_dMonth03.Top = 0.25F;
            this.gr_dMonth03.Width = 0.51F;
            // 
            // gr_uMonth04
            // 
            this.gr_uMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth04.DataField = "OrderSalesMoney";
            this.gr_uMonth04.Height = 0.156F;
            this.gr_uMonth04.Left = 4.9675F;
            this.gr_uMonth04.MultiLine = false;
            this.gr_uMonth04.Name = "gr_uMonth04";
            this.gr_uMonth04.OutputFormat = resources.GetString("gr_uMonth04.OutputFormat");
            this.gr_uMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth04.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth04.Text = "12,345,678";
            this.gr_uMonth04.Top = 0.0625F;
            this.gr_uMonth04.Width = 0.51F;
            // 
            // gr_dMonth04
            // 
            this.gr_dMonth04.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth04.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth04.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth04.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth04.DataField = "TotalOrderSalesMoney";
            this.gr_dMonth04.Height = 0.156F;
            this.gr_dMonth04.Left = 4.9675F;
            this.gr_dMonth04.MultiLine = false;
            this.gr_dMonth04.Name = "gr_dMonth04";
            this.gr_dMonth04.OutputFormat = resources.GetString("gr_dMonth04.OutputFormat");
            this.gr_dMonth04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth04.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth04.Text = "12,345,678";
            this.gr_dMonth04.Top = 0.25F;
            this.gr_dMonth04.Width = 0.51F;
            // 
            // gr_uMonth05
            // 
            this.gr_uMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth05.DataField = "StockSalesMoney";
            this.gr_uMonth05.Height = 0.156F;
            this.gr_uMonth05.Left = 5.4775F;
            this.gr_uMonth05.MultiLine = false;
            this.gr_uMonth05.Name = "gr_uMonth05";
            this.gr_uMonth05.OutputFormat = resources.GetString("gr_uMonth05.OutputFormat");
            this.gr_uMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth05.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth05.Text = "12,345,678";
            this.gr_uMonth05.Top = 0.0625F;
            this.gr_uMonth05.Width = 0.51F;
            // 
            // gr_dMonth05
            // 
            this.gr_dMonth05.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth05.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth05.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth05.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth05.DataField = "TotalStockSalesMoney";
            this.gr_dMonth05.Height = 0.156F;
            this.gr_dMonth05.Left = 5.4775F;
            this.gr_dMonth05.MultiLine = false;
            this.gr_dMonth05.Name = "gr_dMonth05";
            this.gr_dMonth05.OutputFormat = resources.GetString("gr_dMonth05.OutputFormat");
            this.gr_dMonth05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth05.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth05.Text = "12,345,678";
            this.gr_dMonth05.Top = 0.25F;
            this.gr_dMonth05.Width = 0.51F;
            // 
            // gr_dMonth06
            // 
            this.gr_dMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth06.DataField = "TotalGrossMoney";
            this.gr_dMonth06.Height = 0.156F;
            this.gr_dMonth06.Left = 5.9875F;
            this.gr_dMonth06.MultiLine = false;
            this.gr_dMonth06.Name = "gr_dMonth06";
            this.gr_dMonth06.OutputFormat = resources.GetString("gr_dMonth06.OutputFormat");
            this.gr_dMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth06.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth06.Text = "12,345,678";
            this.gr_dMonth06.Top = 0.25F;
            this.gr_dMonth06.Width = 0.51F;
            // 
            // gr_uMonth06
            // 
            this.gr_uMonth06.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth06.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth06.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth06.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth06.DataField = "GrossMoney";
            this.gr_uMonth06.Height = 0.156F;
            this.gr_uMonth06.Left = 5.9875F;
            this.gr_uMonth06.MultiLine = false;
            this.gr_uMonth06.Name = "gr_uMonth06";
            this.gr_uMonth06.OutputFormat = resources.GetString("gr_uMonth06.OutputFormat");
            this.gr_uMonth06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth06.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth06.Text = "12,345,678";
            this.gr_uMonth06.Top = 0.0625F;
            this.gr_uMonth06.Width = 0.51F;
            // 
            // gr_uMonth07
            // 
            this.gr_uMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth07.DataField = "GrossMoney";
            this.gr_uMonth07.Height = 0.156F;
            this.gr_uMonth07.Left = 6.4975F;
            this.gr_uMonth07.MultiLine = false;
            this.gr_uMonth07.Name = "gr_uMonth07";
            this.gr_uMonth07.OutputFormat = resources.GetString("gr_uMonth07.OutputFormat");
            this.gr_uMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth07.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth07.Text = "12,345,678";
            this.gr_uMonth07.Top = 0.0625F;
            this.gr_uMonth07.Width = 0.51F;
            // 
            // gr_dMonth07
            // 
            this.gr_dMonth07.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth07.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth07.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth07.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth07.DataField = "GrossMoney";
            this.gr_dMonth07.Height = 0.156F;
            this.gr_dMonth07.Left = 6.4975F;
            this.gr_dMonth07.MultiLine = false;
            this.gr_dMonth07.Name = "gr_dMonth07";
            this.gr_dMonth07.OutputFormat = resources.GetString("gr_dMonth07.OutputFormat");
            this.gr_dMonth07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth07.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth07.Text = "12,345,678";
            this.gr_dMonth07.Top = 0.25F;
            this.gr_dMonth07.Width = 0.51F;
            // 
            // gr_uMonth08
            // 
            this.gr_uMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth08.DataField = "CostMoney";
            this.gr_uMonth08.Height = 0.156F;
            this.gr_uMonth08.Left = 7.007501F;
            this.gr_uMonth08.MultiLine = false;
            this.gr_uMonth08.Name = "gr_uMonth08";
            this.gr_uMonth08.OutputFormat = resources.GetString("gr_uMonth08.OutputFormat");
            this.gr_uMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth08.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth08.Text = "12,345,678";
            this.gr_uMonth08.Top = 0.0625F;
            this.gr_uMonth08.Width = 0.51F;
            // 
            // gr_dMonth08
            // 
            this.gr_dMonth08.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth08.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth08.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth08.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth08.DataField = "TotalCostMoney";
            this.gr_dMonth08.Height = 0.156F;
            this.gr_dMonth08.Left = 7.007501F;
            this.gr_dMonth08.MultiLine = false;
            this.gr_dMonth08.Name = "gr_dMonth08";
            this.gr_dMonth08.OutputFormat = resources.GetString("gr_dMonth08.OutputFormat");
            this.gr_dMonth08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth08.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth08.Text = "12,345,678";
            this.gr_dMonth08.Top = 0.25F;
            this.gr_dMonth08.Width = 0.51F;
            // 
            // gr_uMonth09
            // 
            this.gr_uMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth09.DataField = "StockMoney";
            this.gr_uMonth09.Height = 0.156F;
            this.gr_uMonth09.Left = 7.517501F;
            this.gr_uMonth09.MultiLine = false;
            this.gr_uMonth09.Name = "gr_uMonth09";
            this.gr_uMonth09.OutputFormat = resources.GetString("gr_uMonth09.OutputFormat");
            this.gr_uMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth09.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth09.Text = "12,345,678";
            this.gr_uMonth09.Top = 0.0625F;
            this.gr_uMonth09.Width = 0.51F;
            // 
            // gr_dMonth09
            // 
            this.gr_dMonth09.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth09.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth09.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth09.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth09.DataField = "TotalStockMoney";
            this.gr_dMonth09.Height = 0.156F;
            this.gr_dMonth09.Left = 7.517501F;
            this.gr_dMonth09.MultiLine = false;
            this.gr_dMonth09.Name = "gr_dMonth09";
            this.gr_dMonth09.OutputFormat = resources.GetString("gr_dMonth09.OutputFormat");
            this.gr_dMonth09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth09.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth09.Text = "12,345,678";
            this.gr_dMonth09.Top = 0.25F;
            this.gr_dMonth09.Width = 0.51F;
            // 
            // gr_uMonth10
            // 
            this.gr_uMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth10.DataField = "OrderStockMoney";
            this.gr_uMonth10.Height = 0.156F;
            this.gr_uMonth10.Left = 8.027501F;
            this.gr_uMonth10.MultiLine = false;
            this.gr_uMonth10.Name = "gr_uMonth10";
            this.gr_uMonth10.OutputFormat = resources.GetString("gr_uMonth10.OutputFormat");
            this.gr_uMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth10.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth10.Text = "12,345,678";
            this.gr_uMonth10.Top = 0.0625F;
            this.gr_uMonth10.Width = 0.51F;
            // 
            // gr_dMonth10
            // 
            this.gr_dMonth10.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth10.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth10.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth10.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth10.DataField = "TotalOrderStockMoney";
            this.gr_dMonth10.Height = 0.156F;
            this.gr_dMonth10.Left = 8.027501F;
            this.gr_dMonth10.MultiLine = false;
            this.gr_dMonth10.Name = "gr_dMonth10";
            this.gr_dMonth10.OutputFormat = resources.GetString("gr_dMonth10.OutputFormat");
            this.gr_dMonth10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth10.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth10.Text = "12,345,678";
            this.gr_dMonth10.Top = 0.25F;
            this.gr_dMonth10.Width = 0.51F;
            // 
            // gr_uMonth11
            // 
            this.gr_uMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth11.DataField = "StockStockMoney";
            this.gr_uMonth11.Height = 0.156F;
            this.gr_uMonth11.Left = 8.537501F;
            this.gr_uMonth11.MultiLine = false;
            this.gr_uMonth11.Name = "gr_uMonth11";
            this.gr_uMonth11.OutputFormat = resources.GetString("gr_uMonth11.OutputFormat");
            this.gr_uMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth11.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth11.Text = "12,345,678";
            this.gr_uMonth11.Top = 0.0625F;
            this.gr_uMonth11.Width = 0.51F;
            // 
            // gr_dMonth11
            // 
            this.gr_dMonth11.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth11.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth11.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth11.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth11.DataField = "TotalStockStockMoney";
            this.gr_dMonth11.Height = 0.156F;
            this.gr_dMonth11.Left = 8.537501F;
            this.gr_dMonth11.MultiLine = false;
            this.gr_dMonth11.Name = "gr_dMonth11";
            this.gr_dMonth11.OutputFormat = resources.GetString("gr_dMonth11.OutputFormat");
            this.gr_dMonth11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth11.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth11.Text = "12,345,678";
            this.gr_dMonth11.Top = 0.25F;
            this.gr_dMonth11.Width = 0.51F;
            // 
            // gr_uMonth12
            // 
            this.gr_uMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonth12.DataField = "TermSalesComp";
            this.gr_uMonth12.Height = 0.156F;
            this.gr_uMonth12.Left = 9.047502F;
            this.gr_uMonth12.MultiLine = false;
            this.gr_uMonth12.Name = "gr_uMonth12";
            this.gr_uMonth12.OutputFormat = resources.GetString("gr_uMonth12.OutputFormat");
            this.gr_uMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonth12.SummaryGroup = "BLGroupHeader";
            this.gr_uMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonth12.Text = "12,345,678";
            this.gr_uMonth12.Top = 0.0625F;
            this.gr_uMonth12.Width = 0.51F;
            // 
            // gr_dMonth12
            // 
            this.gr_dMonth12.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonth12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth12.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonth12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth12.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonth12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth12.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonth12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonth12.DataField = "MonthSalesComp";
            this.gr_dMonth12.Height = 0.156F;
            this.gr_dMonth12.Left = 9.047502F;
            this.gr_dMonth12.MultiLine = false;
            this.gr_dMonth12.Name = "gr_dMonth12";
            this.gr_dMonth12.OutputFormat = resources.GetString("gr_dMonth12.OutputFormat");
            this.gr_dMonth12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonth12.SummaryGroup = "BLGroupHeader";
            this.gr_dMonth12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonth12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonth12.Text = "12,345,678";
            this.gr_dMonth12.Top = 0.25F;
            this.gr_dMonth12.Width = 0.51F;
            // 
            // gr_uMonthTotal
            // 
            this.gr_uMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthTotal.DataField = "TermStockComp";
            this.gr_uMonthTotal.Height = 0.156F;
            this.gr_uMonthTotal.Left = 9.557502F;
            this.gr_uMonthTotal.MultiLine = false;
            this.gr_uMonthTotal.Name = "gr_uMonthTotal";
            this.gr_uMonthTotal.OutputFormat = resources.GetString("gr_uMonthTotal.OutputFormat");
            this.gr_uMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonthTotal.SummaryGroup = "BLGroupHeader";
            this.gr_uMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonthTotal.Text = "1,234,567,890";
            this.gr_uMonthTotal.Top = 0.0625F;
            this.gr_uMonthTotal.Width = 0.7F;
            // 
            // gr_dMonthTotal
            // 
            this.gr_dMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthTotal.DataField = "MonthStockComp";
            this.gr_dMonthTotal.Height = 0.156F;
            this.gr_dMonthTotal.Left = 9.557502F;
            this.gr_dMonthTotal.MultiLine = false;
            this.gr_dMonthTotal.Name = "gr_dMonthTotal";
            this.gr_dMonthTotal.OutputFormat = resources.GetString("gr_dMonthTotal.OutputFormat");
            this.gr_dMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonthTotal.SummaryGroup = "BLGroupHeader";
            this.gr_dMonthTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonthTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonthTotal.Text = "1,234,567,890";
            this.gr_dMonthTotal.Top = 0.25F;
            this.gr_dMonthTotal.Width = 0.7F;
            // 
            // gr_uMonthAve
            // 
            this.gr_uMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_uMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_uMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.gr_uMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.gr_uMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_uMonthAve.DataField = "Difference";
            this.gr_uMonthAve.Height = 0.156F;
            this.gr_uMonthAve.Left = 10.2575F;
            this.gr_uMonthAve.MultiLine = false;
            this.gr_uMonthAve.Name = "gr_uMonthAve";
            this.gr_uMonthAve.OutputFormat = resources.GetString("gr_uMonthAve.OutputFormat");
            this.gr_uMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_uMonthAve.SummaryGroup = "BLGroupHeader";
            this.gr_uMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_uMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_uMonthAve.Text = "12,345,678";
            this.gr_uMonthAve.Top = 0.0625F;
            this.gr_uMonthAve.Width = 0.51F;
            // 
            // gr_dMonthAve
            // 
            this.gr_dMonthAve.Border.BottomColor = System.Drawing.Color.Black;
            this.gr_dMonthAve.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthAve.Border.LeftColor = System.Drawing.Color.Black;
            this.gr_dMonthAve.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthAve.Border.RightColor = System.Drawing.Color.Black;
            this.gr_dMonthAve.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthAve.Border.TopColor = System.Drawing.Color.Black;
            this.gr_dMonthAve.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.gr_dMonthAve.DataField = "TotalDifference";
            this.gr_dMonthAve.Height = 0.156F;
            this.gr_dMonthAve.Left = 10.2575F;
            this.gr_dMonthAve.MultiLine = false;
            this.gr_dMonthAve.Name = "gr_dMonthAve";
            this.gr_dMonthAve.OutputFormat = resources.GetString("gr_dMonthAve.OutputFormat");
            this.gr_dMonthAve.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.gr_dMonthAve.SummaryGroup = "BLGroupHeader";
            this.gr_dMonthAve.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.gr_dMonthAve.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.gr_dMonthAve.Text = "12,345,678";
            this.gr_dMonthAve.Top = 0.25F;
            this.gr_dMonthAve.Width = 0.51F;
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
            this.line8.Width = 10.8125F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8125F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // DCHNB02052P_01A4C
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
            this.PrintWidth = 10.875F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SuplierHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.SalesEmployeeHeader);
            this.Sections.Add(this.MakerHeader);
            this.Sections.Add(this.GoodsMGroupHeader);
            this.Sections.Add(this.BLGoodsHeader);
            this.Sections.Add(this.BLGroupHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.BLGroupFooter);
            this.Sections.Add(this.BLGoodsFooter);
            this.Sections.Add(this.GoodsMGroupFooter);
            this.Sections.Add(this.MakerFooter);
            this.Sections.Add(this.SalesEmployeeFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.SuplierFooter);
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
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupKanaName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Month08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.to_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mk_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalMaker_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalMaker_MakerShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGoodsCode_textBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGoodsHalfName_textBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusHd_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cu_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpHd_EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.em_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalGoodsMGroup_textBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalGoodsMGroupName_textBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mg_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.su_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupCode_textbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupKanaName_textBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonth12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_uMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_dMonthAve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion       

	}
}
