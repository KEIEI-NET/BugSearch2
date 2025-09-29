using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// マスタエクスポートインポート（基本用）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : マスタエクスポートインポート（基本用）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN08504P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// マスタエクスポートインポート（基本用）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : マスタエクスポートインポート（基本用）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08504P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									    // 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				    // 抽出条件
		private int					_pageFooterOutCode;				    // フッター出力区分
		private StringCollection	_pageFooters;					    // フッターメッセージ
		private	SFCMN06002C			_printInfo;						    // 印刷情報クラス
		private string				_pageHeaderTitle;				    // フォームタイトル
		private string				_pageHeaderSortOderTitle;		    // ソート順

        private const string WAREHOUSE_PGID = "PMKHN08510U";            // 倉庫マスタ
        private const string USERGD_PGID = "PMKHN08530U";               // ユーザガイド         
        private const string NOTEGUID_PGID = "PMKHN08540U";             // 備考ガイド
        private const string BLGOODSCD_PGID = "PMKHN08570U";            // ＢＬコード
        private const string MAKER_PGID = "PMKHN08580U";                // メーカー
        private const string GOODSGROUP_PGID = "PMKHN08590U";           // 商品中分類
        private const string BLGROUP_PGID = "PMKHN08600U";              // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
        private const string ISOLISLANDPRC_PGID = "PMKHN08620U";        // 離島価格
        private const string JOINPARTS_PGID = "PMKHN08640U";            // 結合
        private const string PARTSSUBST_PGID = "PMKHN08650U";           // 代替
        private const string GOODSSET_PGID = "PMKHN08660U";             // セット
        private const string MODELNAME_PGID = "PMKHN08670U";            // 車種
        private const string PARTSPOSCODE_PGID = "PMKHN08680U";         // 部位

        // ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label PMKHN08590U_lbl1;
        private Label PMKHN08590U_lbl2;
        private TextBox PMKHN08590U_txt1;
        private TextBox PMKHN08590U_txt2;
        private Line line4;
        private Line line6;
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
				// TODO:  PMKHN08504P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08504P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Date		: 2008.10.30</br>
		/// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。
            bool bl_visible = false;
            float titleTop = this.PMKHN08510U_lbl1.Top;
            float dataTop = this.PMKHN08510U_txt1.Top;

            this.line2.Visible = true;
            this.line6.Visible = false;
            this.line3.Visible = true;
            this.line4.Visible = false;

            #region すべての項目を非表示
            this.PMKHN08510U_lbl1.Visible = bl_visible;
            this.PMKHN08510U_lbl2.Visible = bl_visible;
            this.PMKHN08510U_lbl3.Visible = bl_visible;
            this.PMKHN08510U_lbl4.Visible = bl_visible;
            this.PMKHN08510U_lbl5.Visible = bl_visible;
            this.PMKHN08510U_lbl6.Visible = bl_visible;
            this.PMKHN08510U_txt1.Visible = bl_visible;
            this.PMKHN08510U_txt2.Visible = bl_visible;
            this.PMKHN08510U_txt3.Visible = bl_visible;
            this.PMKHN08510U_txt4.Visible = bl_visible;
            this.PMKHN08510U_txt5.Visible = bl_visible;
            this.PMKHN08510U_txt6.Visible = bl_visible;
            this.PMKHN08510U_txt7.Visible = bl_visible;
            this.PMKHN08510U_txt8.Visible = bl_visible;
            this.PMKHN08510U_txt9.Visible = bl_visible;
            this.PMKHN08530U_lbl1.Visible = bl_visible;
            this.PMKHN08530U_lbl2.Visible = bl_visible;
            this.PMKHN08530U_txt1.Visible = bl_visible;
            this.PMKHN08530U_txt2.Visible = bl_visible;
            this.PMKHN08540U_lbl1.Visible = bl_visible;
            this.PMKHN08540U_lbl2.Visible = bl_visible;
            this.PMKHN08540U_lbl3.Visible = bl_visible;
            this.PMKHN08540U_txt1.Visible = bl_visible;
            this.PMKHN08540U_txt2.Visible = bl_visible;
            this.PMKHN08540U_txt3.Visible = bl_visible;
            this.PMKHN08540U_txt4.Visible = bl_visible; 
            this.PMKHN08570U_lbl1.Visible = bl_visible;
            this.PMKHN08570U_lbl2.Visible = bl_visible;
            this.PMKHN08570U_lbl3.Visible = bl_visible;
            this.PMKHN08570U_lbl4.Visible = bl_visible;
            this.PMKHN08570U_lbl5.Visible = bl_visible;
            this.PMKHN08570U_lbl6.Visible = bl_visible;
            this.PMKHN08570U_txt1.Visible = bl_visible;
            this.PMKHN08570U_txt2.Visible = bl_visible;
            this.PMKHN08570U_txt3.Visible = bl_visible;
            this.PMKHN08570U_txt4.Visible = bl_visible;
            this.PMKHN08570U_txt5.Visible = bl_visible;
            this.PMKHN08570U_txt6.Visible = bl_visible;
            this.PMKHN08570U_txt7.Visible = bl_visible;
            this.PMKHN08570U_txt8.Visible = bl_visible;
            this.PMKHN08570U_txt9.Visible = bl_visible;
            this.PMKHN08580U_lbl1.Visible = bl_visible;
            this.PMKHN08580U_lbl2.Visible = bl_visible;
            this.PMKHN08580U_lbl3.Visible = bl_visible;
            this.PMKHN08580U_lbl4.Visible = bl_visible;
            this.PMKHN08580U_lbl5.Visible = bl_visible;
            this.PMKHN08580U_txt1.Visible = bl_visible;
            this.PMKHN08580U_txt2.Visible = bl_visible;
            this.PMKHN08580U_txt3.Visible = bl_visible;
            this.PMKHN08580U_txt4.Visible = bl_visible;
            this.PMKHN08580U_txt5.Visible = bl_visible;
            this.PMKHN08590U_lbl1.Visible = bl_visible;
            this.PMKHN08590U_lbl2.Visible = bl_visible;
            this.PMKHN08590U_txt1.Visible = bl_visible;
            this.PMKHN08590U_txt2.Visible = bl_visible;
            this.PMKHN08600U_lbl1.Visible = bl_visible;
            this.PMKHN08600U_lbl2.Visible = bl_visible;
            this.PMKHN08600U_lbl3.Visible = bl_visible;
            this.PMKHN08600U_lbl4.Visible = bl_visible;
            this.PMKHN08600U_lbl5.Visible = bl_visible;
            this.PMKHN08600U_lbl6.Visible = bl_visible;
            this.PMKHN08600U_txt1.Visible = bl_visible;
            this.PMKHN08600U_txt2.Visible = bl_visible;
            this.PMKHN08600U_txt3.Visible = bl_visible;
            this.PMKHN08600U_txt4.Visible = bl_visible;
            this.PMKHN08600U_txt5.Visible = bl_visible;
            this.PMKHN08600U_txt6.Visible = bl_visible;
            this.PMKHN08600U_txt7.Visible = bl_visible;
            this.PMKHN08600U_txt8.Visible = bl_visible;
            this.PMKHN08600U_txt9.Visible = bl_visible;
            this.PMKHN08620U_lbl1.Visible = bl_visible;
            this.PMKHN08620U_lbl2.Visible = bl_visible;
            this.PMKHN08620U_lbl3.Visible = bl_visible;
            this.PMKHN08620U_lbl4.Visible = bl_visible;
            this.PMKHN08620U_lbl5.Visible = bl_visible;
            this.PMKHN08620U_lbl6.Visible = bl_visible;
            this.PMKHN08620U_lbl7.Visible = bl_visible;
            this.PMKHN08620U_txt1.Visible = bl_visible;
            this.PMKHN08620U_txt2.Visible = bl_visible;
            this.PMKHN08620U_txt3.Visible = bl_visible;
            this.PMKHN08620U_txt4.Visible = bl_visible;
            this.PMKHN08620U_txt5.Visible = bl_visible;
            this.PMKHN08620U_txt6.Visible = bl_visible;
            this.PMKHN08620U_txt7.Visible = bl_visible;
            this.PMKHN08620U_txt8.Visible = bl_visible;
            this.PMKHN08650U_lbl1.Visible = bl_visible;
            this.PMKHN08650U_lbl2.Visible = bl_visible;
            this.PMKHN08650U_lbl3.Visible = bl_visible;
            this.PMKHN08650U_lbl4.Visible = bl_visible;
            this.PMKHN08650U_lbl5.Visible = bl_visible;
            this.PMKHN08650U_lbl6.Visible = bl_visible;
            this.PMKHN08650U_lbl7.Visible = bl_visible;
            this.PMKHN08650U_txt1.Visible = bl_visible;
            this.PMKHN08650U_txt2.Visible = bl_visible;
            this.PMKHN08650U_txt3.Visible = bl_visible;
            this.PMKHN08650U_txt4.Visible = bl_visible;
            this.PMKHN08650U_txt5.Visible = bl_visible;
            this.PMKHN08650U_txt6.Visible = bl_visible;
            this.PMKHN08650U_txt7.Visible = bl_visible;
            this.PMKHN08650U_txt8.Visible = bl_visible;
            this.PMKHN08640U_lbl1.Visible = bl_visible;
            this.PMKHN08640U_lbl2.Visible = bl_visible;
            this.PMKHN08640U_lbl3.Visible = bl_visible;
            this.PMKHN08640U_lbl4.Visible = bl_visible;
            this.PMKHN08640U_lbl5.Visible = bl_visible;
            this.PMKHN08640U_lbl6.Visible = bl_visible;
            this.PMKHN08640U_lbl7.Visible = bl_visible;
            this.PMKHN08640U_lbl8.Visible = bl_visible;
            this.PMKHN08640U_txt1.Visible = bl_visible;
            this.PMKHN08640U_txt2.Visible = bl_visible;
            this.PMKHN08640U_txt3.Visible = bl_visible;
            this.PMKHN08640U_txt4.Visible = bl_visible;
            this.PMKHN08640U_txt5.Visible = bl_visible;
            this.PMKHN08640U_txt6.Visible = bl_visible;
            this.PMKHN08640U_txt7.Visible = bl_visible;
            this.PMKHN08640U_txt8.Visible = bl_visible;
            this.PMKHN08640U_txt9.Visible = bl_visible;
            this.PMKHN08660U_lbl1.Visible = bl_visible;
            this.PMKHN08660U_lbl2.Visible = bl_visible;
            this.PMKHN08660U_lbl3.Visible = bl_visible;
            this.PMKHN08660U_lbl4.Visible = bl_visible;
            this.PMKHN08660U_lbl5.Visible = bl_visible;
            this.PMKHN08660U_lbl6.Visible = bl_visible;
            this.PMKHN08660U_lbl7.Visible = bl_visible;
            this.PMKHN08660U_lbl8.Visible = bl_visible;
            this.PMKHN08660U_lbl9.Visible = bl_visible;
            this.PMKHN08660U_txt1.Visible = bl_visible;
            this.PMKHN08660U_txt2.Visible = bl_visible;
            this.PMKHN08660U_txt3.Visible = bl_visible;
            this.PMKHN08660U_txt4.Visible = bl_visible;
            this.PMKHN08660U_txt5.Visible = bl_visible;
            this.PMKHN08660U_txt6.Visible = bl_visible;
            this.PMKHN08660U_txt7.Visible = bl_visible;
            this.PMKHN08660U_txt8.Visible = bl_visible;
            this.PMKHN08660U_txt9.Visible = bl_visible;
            this.PMKHN08660U_txt10.Visible = bl_visible;
            this.PMKHN08670U_lbl1.Visible = bl_visible;
            this.PMKHN08670U_lbl2.Visible = bl_visible;
            this.PMKHN08670U_lbl3.Visible = bl_visible;
            this.PMKHN08670U_lbl4.Visible = bl_visible;
            this.PMKHN08670U_txt1.Visible = bl_visible;
            this.PMKHN08670U_txt2.Visible = bl_visible;
            this.PMKHN08670U_txt3.Visible = bl_visible;
            this.PMKHN08670U_txt4.Visible = bl_visible;
            this.PMKHN08680U_lbl1.Visible = bl_visible;
            this.PMKHN08680U_lbl2.Visible = bl_visible;
            this.PMKHN08680U_lbl3.Visible = bl_visible;
            this.PMKHN08680U_lbl4.Visible = bl_visible;
            this.PMKHN08680U_lbl5.Visible = bl_visible;
            this.PMKHN08680U_txt1.Visible = bl_visible;
            this.PMKHN08680U_txt2.Visible = bl_visible;
            this.PMKHN08680U_txt3.Visible = bl_visible;
            this.PMKHN08680U_txt4.Visible = bl_visible;
            this.PMKHN08680U_txt5.Visible = bl_visible;
            this.PMKHN08680U_txt6.Visible = bl_visible;
            this.PMKHN08680U_txt7.Visible = bl_visible;
            #endregion
            
            bl_visible = true;
            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    this.PMKHN08510U_lbl1.Visible = bl_visible;
                    this.PMKHN08510U_lbl2.Visible = bl_visible;
                    this.PMKHN08510U_lbl3.Visible = bl_visible;
                    this.PMKHN08510U_lbl4.Visible = bl_visible;
                    this.PMKHN08510U_lbl5.Visible = bl_visible;
                    this.PMKHN08510U_lbl6.Visible = bl_visible;
                    this.PMKHN08510U_txt1.Visible = bl_visible;
                    this.PMKHN08510U_txt2.Visible = bl_visible;
                    this.PMKHN08510U_txt3.Visible = bl_visible;
                    this.PMKHN08510U_txt4.Visible = bl_visible;
                    this.PMKHN08510U_txt5.Visible = bl_visible;
                    this.PMKHN08510U_txt6.Visible = bl_visible;
                    this.PMKHN08510U_txt7.Visible = bl_visible;
                    this.PMKHN08510U_txt8.Visible = bl_visible;
                    this.PMKHN08510U_txt9.Visible = bl_visible;
                    break;
                case USERGD_PGID:
                    this.PMKHN08530U_lbl1.Top = titleTop;
                    this.PMKHN08530U_lbl2.Top = titleTop;
                    this.PMKHN08530U_txt1.Top = dataTop;
                    this.PMKHN08530U_txt2.Top = dataTop;

                    this.PMKHN08530U_lbl1.Visible = bl_visible;
                    this.PMKHN08530U_lbl2.Visible = bl_visible;
                    this.PMKHN08530U_txt1.Visible = bl_visible;
                    this.PMKHN08530U_txt2.Visible = bl_visible;
                    break;
                case NOTEGUID_PGID:
                    this.PMKHN08540U_lbl1.Top = titleTop;
                    this.PMKHN08540U_lbl2.Top = titleTop;
                    this.PMKHN08540U_lbl3.Top = titleTop;
                    this.PMKHN08540U_txt1.Top = dataTop;
                    this.PMKHN08540U_txt2.Top = dataTop;
                    this.PMKHN08540U_txt3.Top = dataTop;
                    this.PMKHN08540U_txt4.Top = dataTop;

                    this.PMKHN08540U_lbl1.Visible = bl_visible;
                    this.PMKHN08540U_lbl2.Visible = bl_visible;
                    this.PMKHN08540U_lbl3.Visible = bl_visible;
                    this.PMKHN08540U_txt1.Visible = bl_visible;
                    this.PMKHN08540U_txt2.Visible = bl_visible;
                    this.PMKHN08540U_txt3.Visible = bl_visible;
                    this.PMKHN08540U_txt4.Visible = bl_visible;
                    break;
                case BLGOODSCD_PGID:
                    this.PMKHN08570U_lbl1.Top = titleTop;
                    this.PMKHN08570U_lbl2.Top = titleTop;
                    this.PMKHN08570U_lbl3.Top = titleTop;
                    this.PMKHN08570U_lbl4.Top = titleTop;
                    this.PMKHN08570U_lbl5.Top = titleTop;
                    this.PMKHN08570U_lbl6.Top = titleTop;
                    this.PMKHN08570U_txt1.Top = dataTop;
                    this.PMKHN08570U_txt2.Top = dataTop;
                    this.PMKHN08570U_txt3.Top = dataTop;
                    this.PMKHN08570U_txt4.Top = dataTop;
                    this.PMKHN08570U_txt5.Top = dataTop;
                    this.PMKHN08570U_txt6.Top = dataTop;
                    this.PMKHN08570U_txt7.Top = dataTop;
                    this.PMKHN08570U_txt8.Top = dataTop;
                    this.PMKHN08570U_txt9.Top = dataTop;

                    this.PMKHN08570U_lbl1.Visible = bl_visible;
                    this.PMKHN08570U_lbl2.Visible = bl_visible;
                    this.PMKHN08570U_lbl3.Visible = bl_visible;
                    this.PMKHN08570U_lbl4.Visible = bl_visible;
                    this.PMKHN08570U_lbl5.Visible = bl_visible;
                    this.PMKHN08570U_lbl6.Visible = bl_visible;
                    this.PMKHN08570U_txt1.Visible = bl_visible;
                    this.PMKHN08570U_txt2.Visible = bl_visible;
                    this.PMKHN08570U_txt3.Visible = bl_visible;
                    this.PMKHN08570U_txt4.Visible = bl_visible;
                    this.PMKHN08570U_txt5.Visible = bl_visible;
                    this.PMKHN08570U_txt6.Visible = bl_visible;
                    this.PMKHN08570U_txt7.Visible = bl_visible;
                    this.PMKHN08570U_txt8.Visible = bl_visible;
                    this.PMKHN08570U_txt9.Visible = bl_visible;
                    break;
                case MAKER_PGID:
                    this.PMKHN08580U_lbl1.Top = titleTop;
                    this.PMKHN08580U_lbl2.Top = titleTop;
                    this.PMKHN08580U_lbl3.Top = titleTop;
                    this.PMKHN08580U_lbl4.Top = titleTop;
                    this.PMKHN08580U_lbl5.Top = titleTop;
                    this.PMKHN08580U_txt1.Top = dataTop;
                    this.PMKHN08580U_txt2.Top = dataTop;
                    this.PMKHN08580U_txt3.Top = dataTop;
                    this.PMKHN08580U_txt4.Top = dataTop;
                    this.PMKHN08580U_txt5.Top = dataTop;

                    this.PMKHN08580U_lbl1.Visible = bl_visible;
                    this.PMKHN08580U_lbl2.Visible = bl_visible;
                    this.PMKHN08580U_lbl3.Visible = bl_visible;
                    this.PMKHN08580U_lbl4.Visible = bl_visible;
                    this.PMKHN08580U_lbl5.Visible = bl_visible;
                    this.PMKHN08580U_txt1.Visible = bl_visible;
                    this.PMKHN08580U_txt2.Visible = bl_visible;
                    this.PMKHN08580U_txt3.Visible = bl_visible;
                    this.PMKHN08580U_txt4.Visible = bl_visible;
                    this.PMKHN08580U_txt5.Visible = bl_visible;
                    break;
                case GOODSGROUP_PGID:
                    this.PMKHN08590U_lbl1.Top = titleTop;
                    this.PMKHN08590U_lbl2.Top = titleTop;
                    this.PMKHN08590U_txt1.Top = dataTop;
                    this.PMKHN08590U_txt2.Top = dataTop;

                    this.PMKHN08590U_lbl1.Visible = bl_visible;
                    this.PMKHN08590U_lbl2.Visible = bl_visible;
                    this.PMKHN08590U_txt1.Visible = bl_visible;
                    this.PMKHN08590U_txt2.Visible = bl_visible;
                    break;
                case BLGROUP_PGID:
                    this.PMKHN08600U_lbl1.Top = titleTop;
                    this.PMKHN08600U_lbl2.Top = titleTop;
                    this.PMKHN08600U_lbl3.Top = titleTop;
                    this.PMKHN08600U_lbl4.Top = titleTop;
                    this.PMKHN08600U_lbl5.Top = titleTop;
                    this.PMKHN08600U_lbl6.Top = titleTop;
                    this.PMKHN08600U_txt1.Top = dataTop;
                    this.PMKHN08600U_txt2.Top = dataTop;
                    this.PMKHN08600U_txt3.Top = dataTop;
                    this.PMKHN08600U_txt4.Top = dataTop;
                    this.PMKHN08600U_txt5.Top = dataTop;
                    this.PMKHN08600U_txt6.Top = dataTop;
                    this.PMKHN08600U_txt7.Top = dataTop;
                    this.PMKHN08600U_txt8.Top = dataTop;
                    this.PMKHN08600U_txt9.Top = dataTop;

                    this.PMKHN08600U_lbl1.Visible = bl_visible;
                    this.PMKHN08600U_lbl2.Visible = bl_visible;
                    this.PMKHN08600U_lbl3.Visible = bl_visible;
                    this.PMKHN08600U_lbl4.Visible = bl_visible;
                    this.PMKHN08600U_lbl5.Visible = bl_visible;
                    this.PMKHN08600U_lbl6.Visible = bl_visible;
                    this.PMKHN08600U_txt1.Visible = bl_visible;
                    this.PMKHN08600U_txt2.Visible = bl_visible;
                    this.PMKHN08600U_txt3.Visible = bl_visible;
                    this.PMKHN08600U_txt4.Visible = bl_visible;
                    this.PMKHN08600U_txt5.Visible = bl_visible;
                    this.PMKHN08600U_txt6.Visible = bl_visible;
                    this.PMKHN08600U_txt7.Visible = bl_visible;
                    this.PMKHN08600U_txt8.Visible = bl_visible;
                    this.PMKHN08600U_txt9.Visible = bl_visible;
                    break;
                case ISOLISLANDPRC_PGID:
                    this.PMKHN08620U_lbl1.Top = titleTop;
                    this.PMKHN08620U_lbl2.Top = titleTop;
                    this.PMKHN08620U_lbl3.Top = titleTop;
                    this.PMKHN08620U_lbl4.Top = titleTop;
                    this.PMKHN08620U_lbl5.Top = titleTop;
                    this.PMKHN08620U_lbl6.Top = titleTop;
                    this.PMKHN08620U_lbl7.Top = titleTop;
                    this.PMKHN08620U_txt1.Top = dataTop;
                    this.PMKHN08620U_txt2.Top = dataTop;
                    this.PMKHN08620U_txt3.Top = dataTop;
                    this.PMKHN08620U_txt4.Top = dataTop;
                    this.PMKHN08620U_txt5.Top = dataTop;
                    this.PMKHN08620U_txt6.Top = dataTop;
                    this.PMKHN08620U_txt7.Top = dataTop;
                    this.PMKHN08620U_txt8.Top = dataTop;

                    this.PMKHN08620U_lbl1.Visible = bl_visible;
                    this.PMKHN08620U_lbl2.Visible = bl_visible;
                    this.PMKHN08620U_lbl3.Visible = bl_visible;
                    this.PMKHN08620U_lbl4.Visible = bl_visible;
                    this.PMKHN08620U_lbl5.Visible = bl_visible;
                    this.PMKHN08620U_lbl6.Visible = bl_visible;
                    this.PMKHN08620U_lbl7.Visible = bl_visible;
                    this.PMKHN08620U_txt1.Visible = bl_visible;
                    this.PMKHN08620U_txt2.Visible = bl_visible;
                    this.PMKHN08620U_txt3.Visible = bl_visible;
                    this.PMKHN08620U_txt4.Visible = bl_visible;
                    this.PMKHN08620U_txt5.Visible = bl_visible;
                    this.PMKHN08620U_txt6.Visible = bl_visible;
                    this.PMKHN08620U_txt7.Visible = bl_visible;
                    this.PMKHN08620U_txt8.Visible = bl_visible;
                    break;
                case JOINPARTS_PGID:
                    this.PMKHN08640U_lbl1.Top = titleTop;
                    this.PMKHN08640U_lbl2.Top = titleTop;
                    this.PMKHN08640U_lbl3.Top = titleTop;
                    this.PMKHN08640U_lbl4.Top = titleTop;
                    this.PMKHN08640U_lbl5.Top = titleTop;
                    this.PMKHN08640U_lbl6.Top = titleTop;
                    this.PMKHN08640U_lbl7.Top = titleTop;
                    this.PMKHN08640U_lbl8.Top = titleTop;
                    this.PMKHN08640U_txt1.Top = titleTop;
                    this.PMKHN08640U_txt2.Top = titleTop;
                    this.PMKHN08640U_txt3.Top = titleTop;
                    this.PMKHN08640U_txt4.Top = titleTop;
                    this.PMKHN08640U_txt5.Top = titleTop;
                    this.PMKHN08640U_txt6.Top = titleTop;
                    this.PMKHN08640U_txt7.Top = titleTop;
                    this.PMKHN08640U_txt8.Top = titleTop;
                    this.PMKHN08640U_txt9.Top = titleTop;

                    this.PMKHN08640U_lbl1.Visible = bl_visible;
                    this.PMKHN08640U_lbl2.Visible = bl_visible;
                    this.PMKHN08640U_lbl3.Visible = bl_visible;
                    this.PMKHN08640U_lbl4.Visible = bl_visible;
                    this.PMKHN08640U_lbl5.Visible = bl_visible;
                    this.PMKHN08640U_lbl6.Visible = bl_visible;
                    this.PMKHN08640U_lbl7.Visible = bl_visible;
                    this.PMKHN08640U_lbl8.Visible = bl_visible;
                    this.PMKHN08640U_txt1.Visible = bl_visible;
                    this.PMKHN08640U_txt2.Visible = bl_visible;
                    this.PMKHN08640U_txt3.Visible = bl_visible;
                    this.PMKHN08640U_txt4.Visible = bl_visible;
                    this.PMKHN08640U_txt5.Visible = bl_visible;
                    this.PMKHN08640U_txt6.Visible = bl_visible;
                    this.PMKHN08640U_txt7.Visible = bl_visible;
                    this.PMKHN08640U_txt8.Visible = bl_visible;
                    this.PMKHN08640U_txt9.Visible = bl_visible;
                    break;
                case PARTSSUBST_PGID:
                    this.PMKHN08650U_lbl1.Top = titleTop;
                    this.PMKHN08650U_lbl2.Top = titleTop;
                    this.PMKHN08650U_lbl3.Top = titleTop;
                    this.PMKHN08650U_lbl4.Top = titleTop;
                    this.PMKHN08650U_lbl5.Top = titleTop;
                    this.PMKHN08650U_lbl6.Top = titleTop;
                    this.PMKHN08650U_lbl7.Top = titleTop;
                    this.PMKHN08650U_txt1.Top = dataTop;
                    this.PMKHN08650U_txt2.Top = dataTop;
                    this.PMKHN08650U_txt3.Top = dataTop;
                    this.PMKHN08650U_txt4.Top = dataTop;
                    this.PMKHN08650U_txt5.Top = dataTop;
                    this.PMKHN08650U_txt6.Top = dataTop;
                    this.PMKHN08650U_txt7.Top = dataTop;
                    this.PMKHN08650U_txt8.Top = dataTop;

                    this.PMKHN08650U_lbl1.Visible = bl_visible;
                    this.PMKHN08650U_lbl2.Visible = bl_visible;
                    this.PMKHN08650U_lbl3.Visible = bl_visible;
                    this.PMKHN08650U_lbl4.Visible = bl_visible;
                    this.PMKHN08650U_lbl5.Visible = bl_visible;
                    this.PMKHN08650U_lbl6.Visible = bl_visible;
                    this.PMKHN08650U_lbl7.Visible = bl_visible;
                    this.PMKHN08650U_txt1.Visible = bl_visible;
                    this.PMKHN08650U_txt2.Visible = bl_visible;
                    this.PMKHN08650U_txt3.Visible = bl_visible;
                    this.PMKHN08650U_txt4.Visible = bl_visible;
                    this.PMKHN08650U_txt5.Visible = bl_visible;
                    this.PMKHN08650U_txt6.Visible = bl_visible;
                    this.PMKHN08650U_txt7.Visible = bl_visible;
                    this.PMKHN08650U_txt8.Visible = bl_visible;
                    break;
                case GOODSSET_PGID:
                    this.line2.Visible = false;
                    this.line6.Visible = true;
                    this.line3.Visible = false;
                    this.line4.Visible = true;
                    this.PMKHN08660U_lbl1.Top = titleTop;
                    this.PMKHN08660U_lbl2.Top = titleTop;
                    this.PMKHN08660U_lbl3.Top = titleTop;
                    this.PMKHN08660U_lbl4.Top = titleTop;
                    this.PMKHN08660U_lbl5.Top = titleTop;
                    this.PMKHN08660U_lbl6.Top = titleTop;
                    this.PMKHN08660U_lbl7.Top = titleTop;
                    this.PMKHN08660U_lbl8.Top = titleTop;
                    this.PMKHN08660U_lbl9.Top = (float)0.265;
                    this.PMKHN08660U_txt1.Top = dataTop;
                    this.PMKHN08660U_txt2.Top = dataTop;
                    this.PMKHN08660U_txt3.Top = dataTop;
                    this.PMKHN08660U_txt4.Top = dataTop;
                    this.PMKHN08660U_txt5.Top = dataTop;
                    this.PMKHN08660U_txt6.Top = dataTop;
                    this.PMKHN08660U_txt7.Top = dataTop;
                    this.PMKHN08660U_txt8.Top = dataTop;
                    this.PMKHN08660U_txt9.Top = dataTop;
                    this.PMKHN08660U_txt10.Top = (float)0.233;

                    this.PMKHN08660U_lbl1.Visible = bl_visible;
                    this.PMKHN08660U_lbl2.Visible = bl_visible;
                    this.PMKHN08660U_lbl3.Visible = bl_visible;
                    this.PMKHN08660U_lbl4.Visible = bl_visible;
                    this.PMKHN08660U_lbl5.Visible = bl_visible;
                    this.PMKHN08660U_lbl6.Visible = bl_visible;
                    this.PMKHN08660U_lbl7.Visible = bl_visible;
                    this.PMKHN08660U_lbl8.Visible = bl_visible;
                    this.PMKHN08660U_lbl9.Visible = bl_visible;
                    this.PMKHN08660U_txt1.Visible = bl_visible;
                    this.PMKHN08660U_txt2.Visible = bl_visible;
                    this.PMKHN08660U_txt3.Visible = bl_visible;
                    this.PMKHN08660U_txt4.Visible = bl_visible;
                    this.PMKHN08660U_txt5.Visible = bl_visible;
                    this.PMKHN08660U_txt6.Visible = bl_visible;
                    this.PMKHN08660U_txt7.Visible = bl_visible;
                    this.PMKHN08660U_txt8.Visible = bl_visible;
                    this.PMKHN08660U_txt9.Visible = bl_visible;
                    this.PMKHN08660U_txt10.Visible = bl_visible;
                    break;
                case MODELNAME_PGID:
                    this.PMKHN08670U_lbl1.Top = titleTop;
                    this.PMKHN08670U_lbl2.Top = titleTop;
                    this.PMKHN08670U_lbl3.Top = titleTop;
                    this.PMKHN08670U_lbl4.Top = titleTop;
                    this.PMKHN08670U_txt1.Top = dataTop;
                    this.PMKHN08670U_txt2.Top = dataTop;
                    this.PMKHN08670U_txt3.Top = dataTop;
                    this.PMKHN08670U_txt4.Top = dataTop;

                    this.PMKHN08670U_lbl1.Visible = bl_visible;
                    this.PMKHN08670U_lbl2.Visible = bl_visible;
                    this.PMKHN08670U_lbl3.Visible = bl_visible;
                    this.PMKHN08670U_lbl4.Visible = bl_visible;
                    this.PMKHN08670U_txt1.Visible = bl_visible;
                    this.PMKHN08670U_txt2.Visible = bl_visible;
                    this.PMKHN08670U_txt3.Visible = bl_visible;
                    this.PMKHN08670U_txt4.Visible = bl_visible;
                    break;
                case PARTSPOSCODE_PGID:
                    this.PMKHN08680U_lbl1.Top = titleTop;
                    this.PMKHN08680U_lbl2.Top = titleTop;
                    this.PMKHN08680U_lbl3.Top = titleTop;
                    this.PMKHN08680U_lbl4.Top = titleTop;
                    this.PMKHN08680U_lbl5.Top = titleTop;
                    this.PMKHN08680U_txt1.Top = dataTop;
                    this.PMKHN08680U_txt2.Top = dataTop;
                    this.PMKHN08680U_txt3.Top = dataTop;
                    this.PMKHN08680U_txt4.Top = dataTop;
                    this.PMKHN08680U_txt5.Top = dataTop;
                    this.PMKHN08680U_txt6.Top = dataTop;
                    this.PMKHN08680U_txt7.Top = dataTop;

                    this.PMKHN08680U_lbl1.Visible = bl_visible;
                    this.PMKHN08680U_lbl2.Visible = bl_visible;
                    this.PMKHN08680U_lbl3.Visible = bl_visible;
                    this.PMKHN08680U_lbl4.Visible = bl_visible;
                    this.PMKHN08680U_lbl5.Visible = bl_visible;
                    this.PMKHN08680U_txt1.Visible = bl_visible;
                    this.PMKHN08680U_txt2.Visible = bl_visible;
                    this.PMKHN08680U_txt3.Visible = bl_visible;
                    this.PMKHN08680U_txt4.Visible = bl_visible;
                    this.PMKHN08680U_txt5.Visible = bl_visible;
                    this.PMKHN08680U_txt6.Visible = bl_visible;
                    this.PMKHN08680U_txt7.Visible = bl_visible;
                    break;
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

		#region ◎ PMKHN08504P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08504P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08504P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08504P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08504P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08504P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08504P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
		/// <br>Date		: 2008.10.30</br>
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
		/// <br>Date		: 2008.10.30</br>
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
		/// <br>Date		: 2008.10.30</br>
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
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
        /// <br>Date		: 2008.10.30</br>
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
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
        /// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.03.18 30413 犬飼 フッター部の印刷設定 >>>>>>START
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
            // 2009.03.18 30413 犬飼 フッター部の印刷設定 <<<<<<END
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
        /// <br>Date		: 2008.10.30</br>
        /// </remarks>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
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
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        private Label PMKHN08510U_lbl1;
        private Label PMKHN08510U_lbl2;
        private TextBox PMKHN08510U_txt1;
        private TextBox PMKHN08510U_txt2;
        private Line line2;
        private Line line3;
        private TextBox PMKHN08510U_txt4;
        private Label PMKHN08510U_lbl3;
        private Label PMKHN08510U_lbl4;
        private Label PMKHN08510U_lbl5;
        private TextBox PMKHN08510U_txt3;
        private TextBox PMKHN08510U_txt5;
        private TextBox PMKHN08510U_txt6;
        private TextBox PMKHN08510U_txt7;
        private TextBox PMKHN08510U_txt8;
        private TextBox PMKHN08510U_txt9;
        private Label PMKHN08510U_lbl6;
        private TextBox PMKHN08530U_txt1;
        private TextBox PMKHN08530U_txt2;
        private Label PMKHN08530U_lbl1;
        private Label PMKHN08530U_lbl2;
        private TextBox PMKHN08540U_txt1;
        private TextBox PMKHN08540U_txt2;
        private TextBox PMKHN08540U_txt3;
        private TextBox PMKHN08540U_txt4;
        private Label PMKHN08540U_lbl1;
        private Label PMKHN08540U_lbl2;
        private Label PMKHN08540U_lbl3;
        private TextBox PMKHN08570U_txt1;
        private TextBox PMKHN08570U_txt2;
        private TextBox PMKHN08570U_txt3;
        private TextBox PMKHN08570U_txt4;
        private TextBox PMKHN08570U_txt5;
        private TextBox PMKHN08570U_txt6;
        private TextBox PMKHN08570U_txt7;
        private TextBox PMKHN08570U_txt8;
        private TextBox PMKHN08570U_txt9;
        private Label PMKHN08570U_lbl1;
        private Label PMKHN08570U_lbl2;
        private Label PMKHN08570U_lbl3;
        private Label PMKHN08570U_lbl4;
        private Label PMKHN08570U_lbl5;
        private Label PMKHN08570U_lbl6;
        private TextBox PMKHN08580U_txt1;
        private TextBox PMKHN08580U_txt2;
        private TextBox PMKHN08580U_txt3;
        private TextBox PMKHN08580U_txt4;
        private TextBox PMKHN08580U_txt5;
        private Label PMKHN08580U_lbl1;
        private Label PMKHN08580U_lbl2;
        private Label PMKHN08580U_lbl3;
        private Label PMKHN08580U_lbl4;
        private Label PMKHN08580U_lbl5;
        private TextBox PMKHN08600U_txt1;
        private TextBox PMKHN08600U_txt2;
        private TextBox PMKHN08600U_txt3;
        private TextBox PMKHN08600U_txt4;
        private TextBox PMKHN08600U_txt5;
        private TextBox PMKHN08600U_txt6;
        private TextBox PMKHN08600U_txt7;
        private TextBox PMKHN08600U_txt8;
        private TextBox PMKHN08600U_txt9;
        private Label PMKHN08600U_lbl1;
        private Label PMKHN08600U_lbl2;
        private Label PMKHN08600U_lbl3;
        private Label PMKHN08600U_lbl4;
        private Label PMKHN08600U_lbl5;
        private Label PMKHN08600U_lbl6;
        private TextBox PMKHN08620U_txt1;
        private TextBox PMKHN08620U_txt2;
        private TextBox PMKHN08620U_txt3;
        private TextBox PMKHN08620U_txt4;
        private TextBox PMKHN08620U_txt5;
        private TextBox PMKHN08620U_txt6;
        private TextBox PMKHN08620U_txt7;
        private TextBox PMKHN08620U_txt8;
        private Label PMKHN08620U_lbl1;
        private Label PMKHN08620U_lbl2;
        private Label PMKHN08620U_lbl3;
        private Label PMKHN08620U_lbl4;
        private Label PMKHN08620U_lbl5;
        private Label PMKHN08620U_lbl6;
        private Label PMKHN08620U_lbl7;
        private TextBox PMKHN08650U_txt1;
        private TextBox PMKHN08650U_txt2;
        private TextBox PMKHN08650U_txt3;
        private TextBox PMKHN08650U_txt4;
        private TextBox PMKHN08650U_txt5;
        private TextBox PMKHN08650U_txt7;
        private TextBox PMKHN08650U_txt8;
        private TextBox PMKHN08650U_txt6;
        private Label PMKHN08650U_lbl1;
        private Label PMKHN08650U_lbl2;
        private Label PMKHN08650U_lbl3;
        private Label PMKHN08650U_lbl4;
        private Label PMKHN08650U_lbl5;
        private Label PMKHN08650U_lbl6;
        private Label PMKHN08650U_lbl7;
        private TextBox PMKHN08640U_txt2;
        private TextBox PMKHN08640U_txt1;
        private TextBox PMKHN08640U_txt3;
        private TextBox PMKHN08640U_txt4;
        private TextBox PMKHN08640U_txt6;
        private TextBox PMKHN08640U_txt7;
        private TextBox PMKHN08640U_txt8;
        private TextBox PMKHN08640U_txt9;
        private TextBox PMKHN08640U_txt5;
        private Label PMKHN08640U_lbl1;
        private Label PMKHN08640U_lbl2;
        private Label PMKHN08640U_lbl3;
        private Label PMKHN08640U_lbl4;
        private Label PMKHN08640U_lbl5;
        private Label PMKHN08640U_lbl6;
        private Label PMKHN08640U_lbl7;
        private Label PMKHN08640U_lbl8;
        private TextBox PMKHN08660U_txt1;
        private TextBox PMKHN08660U_txt2;
        private TextBox PMKHN08660U_txt3;
        private TextBox PMKHN08660U_txt4;
        private TextBox PMKHN08660U_txt5;
        private TextBox PMKHN08660U_txt6;
        private TextBox PMKHN08660U_txt7;
        private TextBox PMKHN08660U_txt8;
        private TextBox PMKHN08660U_txt9;
        private TextBox PMKHN08660U_txt10;
        private Label PMKHN08660U_lbl1;
        private Label PMKHN08660U_lbl2;
        private Label PMKHN08660U_lbl3;
        private Label PMKHN08660U_lbl4;
        private Label PMKHN08660U_lbl5;
        private Label PMKHN08660U_lbl6;
        private Label PMKHN08660U_lbl7;
        private Label PMKHN08660U_lbl8;
        private Label PMKHN08660U_lbl9;
        private TextBox PMKHN08670U_txt1;
        private TextBox PMKHN08670U_txt2;
        private TextBox PMKHN08670U_txt3;
        private TextBox PMKHN08670U_txt4;
        private Label PMKHN08670U_lbl2;
        private Label PMKHN08670U_lbl1;
        private Label PMKHN08670U_lbl3;
        private Label PMKHN08670U_lbl4;
        private TextBox PMKHN08680U_txt1;
        private TextBox PMKHN08680U_txt2;
        private TextBox PMKHN08680U_txt5;
        private TextBox PMKHN08680U_txt6;
        private TextBox PMKHN08680U_txt7;
        private TextBox PMKHN08680U_txt3;
        private TextBox PMKHN08680U_txt4;
        private Label PMKHN08680U_lbl1;
        private Label PMKHN08680U_lbl2;
        private Label PMKHN08680U_lbl3;
        private Label PMKHN08680U_lbl4;
        private Label PMKHN08680U_lbl5;    


        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08504P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PMKHN08510U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.PMKHN08510U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08510U_txt9 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08530U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08530U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08540U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08540U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08540U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08540U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08570U_txt9 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08580U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08580U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08580U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08580U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08580U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08600U_txt9 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08620U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08650U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt9 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08640U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt8 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt9 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08660U_txt10 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08670U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08670U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08670U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08670U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt5 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt6 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt7 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt3 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08680U_txt4 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08590U_txt1 = new DataDynamics.ActiveReports.TextBox();
            this.PMKHN08590U_txt2 = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
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
            this.PMKHN08510U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08510U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.PMKHN08510U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08510U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08510U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08510U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08530U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08530U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08540U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08540U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08540U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08570U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08570U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08570U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08570U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08570U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08570U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08580U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08580U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08580U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08580U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08580U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08600U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08600U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08600U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08600U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08600U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08600U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08620U_lbl7 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08650U_lbl7 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl7 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08640U_lbl8 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl6 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl7 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl8 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08660U_lbl9 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08670U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08670U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08670U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08670U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08680U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08680U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08680U_lbl3 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08680U_lbl4 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08680U_lbl5 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08590U_lbl1 = new DataDynamics.ActiveReports.Label();
            this.PMKHN08590U_lbl2 = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PMKHN08510U_txt1,
            this.PMKHN08510U_txt2,
            this.line3,
            this.PMKHN08510U_txt4,
            this.PMKHN08510U_txt3,
            this.PMKHN08510U_txt5,
            this.PMKHN08510U_txt6,
            this.PMKHN08510U_txt7,
            this.PMKHN08510U_txt8,
            this.PMKHN08510U_txt9,
            this.PMKHN08530U_txt1,
            this.PMKHN08530U_txt2,
            this.PMKHN08540U_txt1,
            this.PMKHN08540U_txt2,
            this.PMKHN08540U_txt3,
            this.PMKHN08540U_txt4,
            this.PMKHN08570U_txt1,
            this.PMKHN08570U_txt2,
            this.PMKHN08570U_txt3,
            this.PMKHN08570U_txt4,
            this.PMKHN08570U_txt5,
            this.PMKHN08570U_txt6,
            this.PMKHN08570U_txt7,
            this.PMKHN08570U_txt8,
            this.PMKHN08570U_txt9,
            this.PMKHN08580U_txt1,
            this.PMKHN08580U_txt2,
            this.PMKHN08580U_txt3,
            this.PMKHN08580U_txt4,
            this.PMKHN08580U_txt5,
            this.PMKHN08600U_txt1,
            this.PMKHN08600U_txt2,
            this.PMKHN08600U_txt3,
            this.PMKHN08600U_txt4,
            this.PMKHN08600U_txt5,
            this.PMKHN08600U_txt6,
            this.PMKHN08600U_txt7,
            this.PMKHN08600U_txt8,
            this.PMKHN08600U_txt9,
            this.PMKHN08620U_txt1,
            this.PMKHN08620U_txt2,
            this.PMKHN08620U_txt3,
            this.PMKHN08620U_txt4,
            this.PMKHN08620U_txt5,
            this.PMKHN08620U_txt6,
            this.PMKHN08620U_txt7,
            this.PMKHN08620U_txt8,
            this.PMKHN08650U_txt1,
            this.PMKHN08650U_txt2,
            this.PMKHN08650U_txt3,
            this.PMKHN08650U_txt4,
            this.PMKHN08650U_txt5,
            this.PMKHN08650U_txt7,
            this.PMKHN08650U_txt8,
            this.PMKHN08650U_txt6,
            this.PMKHN08640U_txt2,
            this.PMKHN08640U_txt1,
            this.PMKHN08640U_txt3,
            this.PMKHN08640U_txt4,
            this.PMKHN08640U_txt6,
            this.PMKHN08640U_txt7,
            this.PMKHN08640U_txt8,
            this.PMKHN08640U_txt9,
            this.PMKHN08640U_txt5,
            this.PMKHN08660U_txt1,
            this.PMKHN08660U_txt2,
            this.PMKHN08660U_txt3,
            this.PMKHN08660U_txt4,
            this.PMKHN08660U_txt5,
            this.PMKHN08660U_txt6,
            this.PMKHN08660U_txt7,
            this.PMKHN08660U_txt8,
            this.PMKHN08660U_txt9,
            this.PMKHN08660U_txt10,
            this.PMKHN08670U_txt1,
            this.PMKHN08670U_txt2,
            this.PMKHN08670U_txt3,
            this.PMKHN08670U_txt4,
            this.PMKHN08680U_txt1,
            this.PMKHN08680U_txt2,
            this.PMKHN08680U_txt5,
            this.PMKHN08680U_txt6,
            this.PMKHN08680U_txt7,
            this.PMKHN08680U_txt3,
            this.PMKHN08680U_txt4,
            this.PMKHN08590U_txt1,
            this.PMKHN08590U_txt2,
            this.line4});
            this.Detail.Height = 2.97526F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // PMKHN08510U_txt1
            // 
            this.PMKHN08510U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt1.DataField = "warehousecode";
            this.PMKHN08510U_txt1.Height = 0.15F;
            this.PMKHN08510U_txt1.Left = 0F;
            this.PMKHN08510U_txt1.MultiLine = false;
            this.PMKHN08510U_txt1.Name = "PMKHN08510U_txt1";
            this.PMKHN08510U_txt1.OutputFormat = resources.GetString("PMKHN08510U_txt1.OutputFormat");
            this.PMKHN08510U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08510U_txt1.Text = "1234";
            this.PMKHN08510U_txt1.Top = 0.02083333F;
            this.PMKHN08510U_txt1.Width = 0.3125F;
            // 
            // PMKHN08510U_txt2
            // 
            this.PMKHN08510U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt2.DataField = "warehousename";
            this.PMKHN08510U_txt2.Height = 0.15F;
            this.PMKHN08510U_txt2.Left = 0.3125F;
            this.PMKHN08510U_txt2.MultiLine = false;
            this.PMKHN08510U_txt2.Name = "PMKHN08510U_txt2";
            this.PMKHN08510U_txt2.OutputFormat = resources.GetString("PMKHN08510U_txt2.OutputFormat");
            this.PMKHN08510U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08510U_txt2.Text = "あいうえおかきくけこ";
            this.PMKHN08510U_txt2.Top = 0.02083333F;
            this.PMKHN08510U_txt2.Width = 1.1875F;
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
            this.line3.Top = 0.1875F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.1875F;
            this.line3.Y2 = 0.1875F;
            // 
            // PMKHN08510U_txt4
            // 
            this.PMKHN08510U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt4.DataField = "sectionguidenm";
            this.PMKHN08510U_txt4.Height = 0.15F;
            this.PMKHN08510U_txt4.Left = 2F;
            this.PMKHN08510U_txt4.MultiLine = false;
            this.PMKHN08510U_txt4.Name = "PMKHN08510U_txt4";
            this.PMKHN08510U_txt4.OutputFormat = resources.GetString("PMKHN08510U_txt4.OutputFormat");
            this.PMKHN08510U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08510U_txt4.Text = "あいうえおかきくけこ";
            this.PMKHN08510U_txt4.Top = 0.02083333F;
            this.PMKHN08510U_txt4.Width = 1.1875F;
            // 
            // PMKHN08510U_txt3
            // 
            this.PMKHN08510U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt3.DataField = "sectioncode";
            this.PMKHN08510U_txt3.Height = 0.15F;
            this.PMKHN08510U_txt3.Left = 1.640625F;
            this.PMKHN08510U_txt3.MultiLine = false;
            this.PMKHN08510U_txt3.Name = "PMKHN08510U_txt3";
            this.PMKHN08510U_txt3.OutputFormat = resources.GetString("PMKHN08510U_txt3.OutputFormat");
            this.PMKHN08510U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08510U_txt3.Text = "1234";
            this.PMKHN08510U_txt3.Top = 0.02083333F;
            this.PMKHN08510U_txt3.Width = 0.3125F;
            // 
            // PMKHN08510U_txt5
            // 
            this.PMKHN08510U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt5.DataField = "customercode";
            this.PMKHN08510U_txt5.Height = 0.15F;
            this.PMKHN08510U_txt5.Left = 3.375F;
            this.PMKHN08510U_txt5.MultiLine = false;
            this.PMKHN08510U_txt5.Name = "PMKHN08510U_txt5";
            this.PMKHN08510U_txt5.OutputFormat = resources.GetString("PMKHN08510U_txt5.OutputFormat");
            this.PMKHN08510U_txt5.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08510U_txt5.Text = "12345678";
            this.PMKHN08510U_txt5.Top = 0.02083333F;
            this.PMKHN08510U_txt5.Width = 0.5F;
            // 
            // PMKHN08510U_txt6
            // 
            this.PMKHN08510U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt6.DataField = "customersnm";
            this.PMKHN08510U_txt6.Height = 0.15F;
            this.PMKHN08510U_txt6.Left = 3.9375F;
            this.PMKHN08510U_txt6.MultiLine = false;
            this.PMKHN08510U_txt6.Name = "PMKHN08510U_txt6";
            this.PMKHN08510U_txt6.OutputFormat = resources.GetString("PMKHN08510U_txt6.OutputFormat");
            this.PMKHN08510U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08510U_txt6.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08510U_txt6.Top = 0.02083333F;
            this.PMKHN08510U_txt6.Width = 2.25F;
            // 
            // PMKHN08510U_txt7
            // 
            this.PMKHN08510U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt7.DataField = "mainmngwarehousecd";
            this.PMKHN08510U_txt7.Height = 0.15F;
            this.PMKHN08510U_txt7.Left = 6.359375F;
            this.PMKHN08510U_txt7.MultiLine = false;
            this.PMKHN08510U_txt7.Name = "PMKHN08510U_txt7";
            this.PMKHN08510U_txt7.OutputFormat = resources.GetString("PMKHN08510U_txt7.OutputFormat");
            this.PMKHN08510U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08510U_txt7.Text = "1234";
            this.PMKHN08510U_txt7.Top = 0.02083333F;
            this.PMKHN08510U_txt7.Width = 0.3125F;
            // 
            // PMKHN08510U_txt8
            // 
            this.PMKHN08510U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt8.DataField = "mainwarehousename";
            this.PMKHN08510U_txt8.Height = 0.15F;
            this.PMKHN08510U_txt8.Left = 6.75F;
            this.PMKHN08510U_txt8.MultiLine = false;
            this.PMKHN08510U_txt8.Name = "PMKHN08510U_txt8";
            this.PMKHN08510U_txt8.OutputFormat = resources.GetString("PMKHN08510U_txt8.OutputFormat");
            this.PMKHN08510U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08510U_txt8.Text = "あいうえおかきくけこ";
            this.PMKHN08510U_txt8.Top = 0.02083333F;
            this.PMKHN08510U_txt8.Width = 1.1875F;
            // 
            // PMKHN08510U_txt9
            // 
            this.PMKHN08510U_txt9.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt9.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt9.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt9.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_txt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_txt9.DataField = "stockblnktremark";
            this.PMKHN08510U_txt9.Height = 0.15F;
            this.PMKHN08510U_txt9.Left = 8.25F;
            this.PMKHN08510U_txt9.MultiLine = false;
            this.PMKHN08510U_txt9.Name = "PMKHN08510U_txt9";
            this.PMKHN08510U_txt9.OutputFormat = resources.GetString("PMKHN08510U_txt9.OutputFormat");
            this.PMKHN08510U_txt9.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08510U_txt9.Text = "あいうえおかきくけこ";
            this.PMKHN08510U_txt9.Top = 0.02083333F;
            this.PMKHN08510U_txt9.Width = 1.1875F;
            // 
            // PMKHN08530U_txt1
            // 
            this.PMKHN08530U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt1.DataField = "guidecode";
            this.PMKHN08530U_txt1.Height = 0.15F;
            this.PMKHN08530U_txt1.Left = 0F;
            this.PMKHN08530U_txt1.MultiLine = false;
            this.PMKHN08530U_txt1.Name = "PMKHN08530U_txt1";
            this.PMKHN08530U_txt1.OutputFormat = resources.GetString("PMKHN08530U_txt1.OutputFormat");
            this.PMKHN08530U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08530U_txt1.Text = "1234";
            this.PMKHN08530U_txt1.Top = 0.2333333F;
            this.PMKHN08530U_txt1.Width = 0.3125F;
            // 
            // PMKHN08530U_txt2
            // 
            this.PMKHN08530U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08530U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_txt2.DataField = "guidename";
            this.PMKHN08530U_txt2.Height = 0.15F;
            this.PMKHN08530U_txt2.Left = 0.3125F;
            this.PMKHN08530U_txt2.MultiLine = false;
            this.PMKHN08530U_txt2.Name = "PMKHN08530U_txt2";
            this.PMKHN08530U_txt2.OutputFormat = resources.GetString("PMKHN08530U_txt2.OutputFormat");
            this.PMKHN08530U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08530U_txt2.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08530U_txt2.Top = 0.2333333F;
            this.PMKHN08530U_txt2.Width = 3.375F;
            // 
            // PMKHN08540U_txt1
            // 
            this.PMKHN08540U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt1.DataField = "noteguidedivcode";
            this.PMKHN08540U_txt1.Height = 0.15F;
            this.PMKHN08540U_txt1.Left = 0F;
            this.PMKHN08540U_txt1.MultiLine = false;
            this.PMKHN08540U_txt1.Name = "PMKHN08540U_txt1";
            this.PMKHN08540U_txt1.OutputFormat = resources.GetString("PMKHN08540U_txt1.OutputFormat");
            this.PMKHN08540U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08540U_txt1.Text = "1234";
            this.PMKHN08540U_txt1.Top = 0.4458333F;
            this.PMKHN08540U_txt1.Width = 0.3125F;
            // 
            // PMKHN08540U_txt2
            // 
            this.PMKHN08540U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt2.DataField = "noteguidedivname";
            this.PMKHN08540U_txt2.Height = 0.15F;
            this.PMKHN08540U_txt2.Left = 0.3125F;
            this.PMKHN08540U_txt2.MultiLine = false;
            this.PMKHN08540U_txt2.Name = "PMKHN08540U_txt2";
            this.PMKHN08540U_txt2.OutputFormat = resources.GetString("PMKHN08540U_txt2.OutputFormat");
            this.PMKHN08540U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08540U_txt2.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08540U_txt2.Top = 0.4458333F;
            this.PMKHN08540U_txt2.Width = 3.375F;
            // 
            // PMKHN08540U_txt3
            // 
            this.PMKHN08540U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt3.DataField = "noteguidecode";
            this.PMKHN08540U_txt3.Height = 0.15F;
            this.PMKHN08540U_txt3.Left = 3.875F;
            this.PMKHN08540U_txt3.MultiLine = false;
            this.PMKHN08540U_txt3.Name = "PMKHN08540U_txt3";
            this.PMKHN08540U_txt3.OutputFormat = resources.GetString("PMKHN08540U_txt3.OutputFormat");
            this.PMKHN08540U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08540U_txt3.Text = "1234";
            this.PMKHN08540U_txt3.Top = 0.4458333F;
            this.PMKHN08540U_txt3.Width = 0.3125F;
            // 
            // PMKHN08540U_txt4
            // 
            this.PMKHN08540U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_txt4.DataField = "noteguidename";
            this.PMKHN08540U_txt4.Height = 0.15F;
            this.PMKHN08540U_txt4.Left = 4.1875F;
            this.PMKHN08540U_txt4.MultiLine = false;
            this.PMKHN08540U_txt4.Name = "PMKHN08540U_txt4";
            this.PMKHN08540U_txt4.OutputFormat = resources.GetString("PMKHN08540U_txt4.OutputFormat");
            this.PMKHN08540U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08540U_txt4.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08540U_txt4.Top = 0.4458333F;
            this.PMKHN08540U_txt4.Width = 3.375F;
            // 
            // PMKHN08570U_txt1
            // 
            this.PMKHN08570U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt1.DataField = "blgoodscode";
            this.PMKHN08570U_txt1.Height = 0.15F;
            this.PMKHN08570U_txt1.Left = 0F;
            this.PMKHN08570U_txt1.MultiLine = false;
            this.PMKHN08570U_txt1.Name = "PMKHN08570U_txt1";
            this.PMKHN08570U_txt1.OutputFormat = resources.GetString("PMKHN08570U_txt1.OutputFormat");
            this.PMKHN08570U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08570U_txt1.Text = "12345";
            this.PMKHN08570U_txt1.Top = 0.6583333F;
            this.PMKHN08570U_txt1.Width = 0.3125F;
            // 
            // PMKHN08570U_txt2
            // 
            this.PMKHN08570U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt2.DataField = "blgoodsfullname";
            this.PMKHN08570U_txt2.Height = 0.15F;
            this.PMKHN08570U_txt2.Left = 0.3125F;
            this.PMKHN08570U_txt2.MultiLine = false;
            this.PMKHN08570U_txt2.Name = "PMKHN08570U_txt2";
            this.PMKHN08570U_txt2.OutputFormat = resources.GetString("PMKHN08570U_txt2.OutputFormat");
            this.PMKHN08570U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08570U_txt2.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08570U_txt2.Top = 0.6583333F;
            this.PMKHN08570U_txt2.Width = 2F;
            // 
            // PMKHN08570U_txt3
            // 
            this.PMKHN08570U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt3.DataField = "blgoodshalfname";
            this.PMKHN08570U_txt3.Height = 0.15F;
            this.PMKHN08570U_txt3.Left = 2.375F;
            this.PMKHN08570U_txt3.MultiLine = false;
            this.PMKHN08570U_txt3.Name = "PMKHN08570U_txt3";
            this.PMKHN08570U_txt3.OutputFormat = resources.GetString("PMKHN08570U_txt3.OutputFormat");
            this.PMKHN08570U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08570U_txt3.Text = "ｱｲｳｴｵｶｷｸｹｺｱｲｳｴｵｶｷｸｹｺ";
            this.PMKHN08570U_txt3.Top = 0.6583333F;
            this.PMKHN08570U_txt3.Width = 1F;
            // 
            // PMKHN08570U_txt4
            // 
            this.PMKHN08570U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt4.DataField = "blgroupcode";
            this.PMKHN08570U_txt4.Height = 0.15F;
            this.PMKHN08570U_txt4.Left = 3.510413F;
            this.PMKHN08570U_txt4.MultiLine = false;
            this.PMKHN08570U_txt4.Name = "PMKHN08570U_txt4";
            this.PMKHN08570U_txt4.OutputFormat = resources.GetString("PMKHN08570U_txt4.OutputFormat");
            this.PMKHN08570U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08570U_txt4.Text = "12345";
            this.PMKHN08570U_txt4.Top = 0.6583333F;
            this.PMKHN08570U_txt4.Width = 0.3125F;
            // 
            // PMKHN08570U_txt5
            // 
            this.PMKHN08570U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt5.DataField = "blgroupkananame";
            this.PMKHN08570U_txt5.Height = 0.15F;
            this.PMKHN08570U_txt5.Left = 3.82291F;
            this.PMKHN08570U_txt5.MultiLine = false;
            this.PMKHN08570U_txt5.Name = "PMKHN08570U_txt5";
            this.PMKHN08570U_txt5.OutputFormat = resources.GetString("PMKHN08570U_txt5.OutputFormat");
            this.PMKHN08570U_txt5.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08570U_txt5.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08570U_txt5.Top = 0.6583333F;
            this.PMKHN08570U_txt5.Width = 2F;
            // 
            // PMKHN08570U_txt6
            // 
            this.PMKHN08570U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt6.DataField = "goodsrategrpcode";
            this.PMKHN08570U_txt6.Height = 0.15F;
            this.PMKHN08570U_txt6.Left = 5.895821F;
            this.PMKHN08570U_txt6.MultiLine = false;
            this.PMKHN08570U_txt6.Name = "PMKHN08570U_txt6";
            this.PMKHN08570U_txt6.OutputFormat = resources.GetString("PMKHN08570U_txt6.OutputFormat");
            this.PMKHN08570U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08570U_txt6.Text = "1234";
            this.PMKHN08570U_txt6.Top = 0.6583333F;
            this.PMKHN08570U_txt6.Width = 0.2499999F;
            // 
            // PMKHN08570U_txt7
            // 
            this.PMKHN08570U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt7.DataField = "goodsrategrpcodename";
            this.PMKHN08570U_txt7.Height = 0.15F;
            this.PMKHN08570U_txt7.Left = 6.145825F;
            this.PMKHN08570U_txt7.MultiLine = false;
            this.PMKHN08570U_txt7.Name = "PMKHN08570U_txt7";
            this.PMKHN08570U_txt7.OutputFormat = resources.GetString("PMKHN08570U_txt7.OutputFormat");
            this.PMKHN08570U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08570U_txt7.Text = "あいうえおかきくけこあいうえお";
            this.PMKHN08570U_txt7.Top = 0.6583333F;
            this.PMKHN08570U_txt7.Width = 1.5F;
            // 
            // PMKHN08570U_txt8
            // 
            this.PMKHN08570U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt8.DataField = "blgoodsgenrecode";
            this.PMKHN08570U_txt8.Height = 0.15F;
            this.PMKHN08570U_txt8.Left = 7.729169F;
            this.PMKHN08570U_txt8.MultiLine = false;
            this.PMKHN08570U_txt8.Name = "PMKHN08570U_txt8";
            this.PMKHN08570U_txt8.OutputFormat = resources.GetString("PMKHN08570U_txt8.OutputFormat");
            this.PMKHN08570U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08570U_txt8.Text = "1234";
            this.PMKHN08570U_txt8.Top = 0.6583333F;
            this.PMKHN08570U_txt8.Width = 0.2499999F;
            // 
            // PMKHN08570U_txt9
            // 
            this.PMKHN08570U_txt9.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt9.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt9.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt9.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_txt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_txt9.DataField = "blgoodsgenrecodename";
            this.PMKHN08570U_txt9.Height = 0.15F;
            this.PMKHN08570U_txt9.Left = 7.979169F;
            this.PMKHN08570U_txt9.MultiLine = false;
            this.PMKHN08570U_txt9.Name = "PMKHN08570U_txt9";
            this.PMKHN08570U_txt9.OutputFormat = resources.GetString("PMKHN08570U_txt9.OutputFormat");
            this.PMKHN08570U_txt9.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08570U_txt9.Text = "あいうえおかきくけこあいうえお";
            this.PMKHN08570U_txt9.Top = 0.6583333F;
            this.PMKHN08570U_txt9.Width = 1.5F;
            // 
            // PMKHN08580U_txt1
            // 
            this.PMKHN08580U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt1.DataField = "goodsmakercd";
            this.PMKHN08580U_txt1.Height = 0.15F;
            this.PMKHN08580U_txt1.Left = 0F;
            this.PMKHN08580U_txt1.MultiLine = false;
            this.PMKHN08580U_txt1.Name = "PMKHN08580U_txt1";
            this.PMKHN08580U_txt1.OutputFormat = resources.GetString("PMKHN08580U_txt1.OutputFormat");
            this.PMKHN08580U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08580U_txt1.Text = "1234";
            this.PMKHN08580U_txt1.Top = 0.866666F;
            this.PMKHN08580U_txt1.Width = 0.3125F;
            // 
            // PMKHN08580U_txt2
            // 
            this.PMKHN08580U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt2.DataField = "makername";
            this.PMKHN08580U_txt2.Height = 0.15F;
            this.PMKHN08580U_txt2.Left = 0.3125F;
            this.PMKHN08580U_txt2.MultiLine = false;
            this.PMKHN08580U_txt2.Name = "PMKHN08580U_txt2";
            this.PMKHN08580U_txt2.OutputFormat = resources.GetString("PMKHN08580U_txt2.OutputFormat");
            this.PMKHN08580U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08580U_txt2.Text = "あいうえおかきくけこあいうえお";
            this.PMKHN08580U_txt2.Top = 0.866666F;
            this.PMKHN08580U_txt2.Width = 1.75F;
            // 
            // PMKHN08580U_txt3
            // 
            this.PMKHN08580U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt3.DataField = "makershortname";
            this.PMKHN08580U_txt3.Height = 0.15F;
            this.PMKHN08580U_txt3.Left = 2.21875F;
            this.PMKHN08580U_txt3.MultiLine = false;
            this.PMKHN08580U_txt3.Name = "PMKHN08580U_txt3";
            this.PMKHN08580U_txt3.OutputFormat = resources.GetString("PMKHN08580U_txt3.OutputFormat");
            this.PMKHN08580U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08580U_txt3.Text = "あいうえおかきくけこ";
            this.PMKHN08580U_txt3.Top = 0.866666F;
            this.PMKHN08580U_txt3.Width = 1.1875F;
            // 
            // PMKHN08580U_txt4
            // 
            this.PMKHN08580U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt4.DataField = "makerkananame";
            this.PMKHN08580U_txt4.Height = 0.15F;
            this.PMKHN08580U_txt4.Left = 3.59375F;
            this.PMKHN08580U_txt4.MultiLine = false;
            this.PMKHN08580U_txt4.Name = "PMKHN08580U_txt4";
            this.PMKHN08580U_txt4.OutputFormat = resources.GetString("PMKHN08580U_txt4.OutputFormat");
            this.PMKHN08580U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08580U_txt4.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08580U_txt4.Top = 0.866666F;
            this.PMKHN08580U_txt4.Width = 3.375F;
            // 
            // PMKHN08580U_txt5
            // 
            this.PMKHN08580U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_txt5.DataField = "displayorder";
            this.PMKHN08580U_txt5.Height = 0.15F;
            this.PMKHN08580U_txt5.Left = 7.322922F;
            this.PMKHN08580U_txt5.MultiLine = false;
            this.PMKHN08580U_txt5.Name = "PMKHN08580U_txt5";
            this.PMKHN08580U_txt5.OutputFormat = resources.GetString("PMKHN08580U_txt5.OutputFormat");
            this.PMKHN08580U_txt5.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08580U_txt5.Text = "1234";
            this.PMKHN08580U_txt5.Top = 0.866666F;
            this.PMKHN08580U_txt5.Width = 0.2499999F;
            // 
            // PMKHN08600U_txt1
            // 
            this.PMKHN08600U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt1.DataField = "blgroupcode";
            this.PMKHN08600U_txt1.Height = 0.15F;
            this.PMKHN08600U_txt1.Left = 0F;
            this.PMKHN08600U_txt1.MultiLine = false;
            this.PMKHN08600U_txt1.Name = "PMKHN08600U_txt1";
            this.PMKHN08600U_txt1.OutputFormat = resources.GetString("PMKHN08600U_txt1.OutputFormat");
            this.PMKHN08600U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08600U_txt1.Text = "12345";
            this.PMKHN08600U_txt1.Top = 1.25F;
            this.PMKHN08600U_txt1.Width = 0.3125F;
            // 
            // PMKHN08600U_txt2
            // 
            this.PMKHN08600U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt2.DataField = "blgroupname";
            this.PMKHN08600U_txt2.Height = 0.15F;
            this.PMKHN08600U_txt2.Left = 0.3125F;
            this.PMKHN08600U_txt2.MultiLine = false;
            this.PMKHN08600U_txt2.Name = "PMKHN08600U_txt2";
            this.PMKHN08600U_txt2.OutputFormat = resources.GetString("PMKHN08600U_txt2.OutputFormat");
            this.PMKHN08600U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08600U_txt2.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08600U_txt2.Top = 1.25F;
            this.PMKHN08600U_txt2.Width = 2F;
            // 
            // PMKHN08600U_txt3
            // 
            this.PMKHN08600U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt3.DataField = "blgroupkananame";
            this.PMKHN08600U_txt3.Height = 0.15F;
            this.PMKHN08600U_txt3.Left = 2.375F;
            this.PMKHN08600U_txt3.MultiLine = false;
            this.PMKHN08600U_txt3.Name = "PMKHN08600U_txt3";
            this.PMKHN08600U_txt3.OutputFormat = resources.GetString("PMKHN08600U_txt3.OutputFormat");
            this.PMKHN08600U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08600U_txt3.Text = "ｱｲｳｴｵｶｷｸｹｺｱｲｳｴｵｶｷｸｹｺ";
            this.PMKHN08600U_txt3.Top = 1.25F;
            this.PMKHN08600U_txt3.Width = 1F;
            // 
            // PMKHN08600U_txt4
            // 
            this.PMKHN08600U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt4.DataField = "salescode";
            this.PMKHN08600U_txt4.Height = 0.15F;
            this.PMKHN08600U_txt4.Left = 3.510413F;
            this.PMKHN08600U_txt4.MultiLine = false;
            this.PMKHN08600U_txt4.Name = "PMKHN08600U_txt4";
            this.PMKHN08600U_txt4.OutputFormat = resources.GetString("PMKHN08600U_txt4.OutputFormat");
            this.PMKHN08600U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08600U_txt4.Text = "1234";
            this.PMKHN08600U_txt4.Top = 1.25F;
            this.PMKHN08600U_txt4.Width = 0.2499999F;
            // 
            // PMKHN08600U_txt5
            // 
            this.PMKHN08600U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt5.DataField = "salescodename";
            this.PMKHN08600U_txt5.Height = 0.15F;
            this.PMKHN08600U_txt5.Left = 3.760417F;
            this.PMKHN08600U_txt5.MultiLine = false;
            this.PMKHN08600U_txt5.Name = "PMKHN08600U_txt5";
            this.PMKHN08600U_txt5.OutputFormat = resources.GetString("PMKHN08600U_txt5.OutputFormat");
            this.PMKHN08600U_txt5.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08600U_txt5.Text = "あいうえおかきくけこあいうえお";
            this.PMKHN08600U_txt5.Top = 1.25F;
            this.PMKHN08600U_txt5.Width = 1.5F;
            // 
            // PMKHN08600U_txt6
            // 
            this.PMKHN08600U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt6.DataField = "goodslgroup";
            this.PMKHN08600U_txt6.Height = 0.15F;
            this.PMKHN08600U_txt6.Left = 5.375F;
            this.PMKHN08600U_txt6.MultiLine = false;
            this.PMKHN08600U_txt6.Name = "PMKHN08600U_txt6";
            this.PMKHN08600U_txt6.OutputFormat = resources.GetString("PMKHN08600U_txt6.OutputFormat");
            this.PMKHN08600U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08600U_txt6.Text = "1234";
            this.PMKHN08600U_txt6.Top = 1.25F;
            this.PMKHN08600U_txt6.Width = 0.2499999F;
            // 
            // PMKHN08600U_txt7
            // 
            this.PMKHN08600U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt7.DataField = "goodslgroupname";
            this.PMKHN08600U_txt7.Height = 0.15F;
            this.PMKHN08600U_txt7.Left = 5.625F;
            this.PMKHN08600U_txt7.MultiLine = false;
            this.PMKHN08600U_txt7.Name = "PMKHN08600U_txt7";
            this.PMKHN08600U_txt7.OutputFormat = resources.GetString("PMKHN08600U_txt7.OutputFormat");
            this.PMKHN08600U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08600U_txt7.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08600U_txt7.Top = 1.25F;
            this.PMKHN08600U_txt7.Width = 2F;
            // 
            // PMKHN08600U_txt8
            // 
            this.PMKHN08600U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt8.DataField = "goodsmgroup";
            this.PMKHN08600U_txt8.Height = 0.15F;
            this.PMKHN08600U_txt8.Left = 7.6875F;
            this.PMKHN08600U_txt8.MultiLine = false;
            this.PMKHN08600U_txt8.Name = "PMKHN08600U_txt8";
            this.PMKHN08600U_txt8.OutputFormat = resources.GetString("PMKHN08600U_txt8.OutputFormat");
            this.PMKHN08600U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08600U_txt8.Text = "1234";
            this.PMKHN08600U_txt8.Top = 1.25F;
            this.PMKHN08600U_txt8.Width = 0.2499999F;
            // 
            // PMKHN08600U_txt9
            // 
            this.PMKHN08600U_txt9.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt9.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt9.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt9.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_txt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_txt9.DataField = "goodsmgroupname";
            this.PMKHN08600U_txt9.Height = 0.15F;
            this.PMKHN08600U_txt9.Left = 7.9375F;
            this.PMKHN08600U_txt9.MultiLine = false;
            this.PMKHN08600U_txt9.Name = "PMKHN08600U_txt9";
            this.PMKHN08600U_txt9.OutputFormat = resources.GetString("PMKHN08600U_txt9.OutputFormat");
            this.PMKHN08600U_txt9.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08600U_txt9.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08600U_txt9.Top = 1.25F;
            this.PMKHN08600U_txt9.Width = 2F;
            // 
            // PMKHN08620U_txt1
            // 
            this.PMKHN08620U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt1.DataField = "sectioncode";
            this.PMKHN08620U_txt1.Height = 0.15F;
            this.PMKHN08620U_txt1.Left = 0F;
            this.PMKHN08620U_txt1.MultiLine = false;
            this.PMKHN08620U_txt1.Name = "PMKHN08620U_txt1";
            this.PMKHN08620U_txt1.OutputFormat = resources.GetString("PMKHN08620U_txt1.OutputFormat");
            this.PMKHN08620U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08620U_txt1.Text = "12";
            this.PMKHN08620U_txt1.Top = 1.5F;
            this.PMKHN08620U_txt1.Width = 0.3125F;
            // 
            // PMKHN08620U_txt2
            // 
            this.PMKHN08620U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt2.DataField = "sectionguidesnm";
            this.PMKHN08620U_txt2.Height = 0.15F;
            this.PMKHN08620U_txt2.Left = 0.3125F;
            this.PMKHN08620U_txt2.MultiLine = false;
            this.PMKHN08620U_txt2.Name = "PMKHN08620U_txt2";
            this.PMKHN08620U_txt2.OutputFormat = resources.GetString("PMKHN08620U_txt2.OutputFormat");
            this.PMKHN08620U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08620U_txt2.Text = "あいうえおかきくけこ";
            this.PMKHN08620U_txt2.Top = 1.5F;
            this.PMKHN08620U_txt2.Width = 1.1875F;
            // 
            // PMKHN08620U_txt3
            // 
            this.PMKHN08620U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt3.DataField = "makercode";
            this.PMKHN08620U_txt3.Height = 0.15F;
            this.PMKHN08620U_txt3.Left = 1.625F;
            this.PMKHN08620U_txt3.MultiLine = false;
            this.PMKHN08620U_txt3.Name = "PMKHN08620U_txt3";
            this.PMKHN08620U_txt3.OutputFormat = resources.GetString("PMKHN08620U_txt3.OutputFormat");
            this.PMKHN08620U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08620U_txt3.Text = "123";
            this.PMKHN08620U_txt3.Top = 1.5F;
            this.PMKHN08620U_txt3.Width = 0.3125F;
            // 
            // PMKHN08620U_txt4
            // 
            this.PMKHN08620U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt4.DataField = "makershortname";
            this.PMKHN08620U_txt4.Height = 0.15F;
            this.PMKHN08620U_txt4.Left = 1.9375F;
            this.PMKHN08620U_txt4.MultiLine = false;
            this.PMKHN08620U_txt4.Name = "PMKHN08620U_txt4";
            this.PMKHN08620U_txt4.OutputFormat = resources.GetString("PMKHN08620U_txt4.OutputFormat");
            this.PMKHN08620U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08620U_txt4.Text = "あいうえおかきくけこ";
            this.PMKHN08620U_txt4.Top = 1.5F;
            this.PMKHN08620U_txt4.Width = 1.1875F;
            // 
            // PMKHN08620U_txt5
            // 
            this.PMKHN08620U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt5.DataField = "upperlimitprice";
            this.PMKHN08620U_txt5.Height = 0.15F;
            this.PMKHN08620U_txt5.Left = 3.25F;
            this.PMKHN08620U_txt5.MultiLine = false;
            this.PMKHN08620U_txt5.Name = "PMKHN08620U_txt5";
            this.PMKHN08620U_txt5.OutputFormat = resources.GetString("PMKHN08620U_txt5.OutputFormat");
            this.PMKHN08620U_txt5.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08620U_txt5.Text = "123,456,789";
            this.PMKHN08620U_txt5.Top = 1.5F;
            this.PMKHN08620U_txt5.Width = 0.7499999F;
            // 
            // PMKHN08620U_txt6
            // 
            this.PMKHN08620U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt6.DataField = "uprate";
            this.PMKHN08620U_txt6.Height = 0.15F;
            this.PMKHN08620U_txt6.Left = 4.0625F;
            this.PMKHN08620U_txt6.MultiLine = false;
            this.PMKHN08620U_txt6.Name = "PMKHN08620U_txt6";
            this.PMKHN08620U_txt6.OutputFormat = resources.GetString("PMKHN08620U_txt6.OutputFormat");
            this.PMKHN08620U_txt6.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08620U_txt6.Text = "123.12";
            this.PMKHN08620U_txt6.Top = 1.5F;
            this.PMKHN08620U_txt6.Width = 0.5F;
            // 
            // PMKHN08620U_txt7
            // 
            this.PMKHN08620U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt7.DataField = "fractionprocunit";
            this.PMKHN08620U_txt7.Height = 0.15F;
            this.PMKHN08620U_txt7.Left = 4.625F;
            this.PMKHN08620U_txt7.MultiLine = false;
            this.PMKHN08620U_txt7.Name = "PMKHN08620U_txt7";
            this.PMKHN08620U_txt7.OutputFormat = resources.GetString("PMKHN08620U_txt7.OutputFormat");
            this.PMKHN08620U_txt7.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08620U_txt7.Text = "123,456,789";
            this.PMKHN08620U_txt7.Top = 1.5F;
            this.PMKHN08620U_txt7.Width = 0.7499999F;
            // 
            // PMKHN08620U_txt8
            // 
            this.PMKHN08620U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_txt8.DataField = "fractionproccd";
            this.PMKHN08620U_txt8.Height = 0.15F;
            this.PMKHN08620U_txt8.Left = 5.458333F;
            this.PMKHN08620U_txt8.MultiLine = false;
            this.PMKHN08620U_txt8.Name = "PMKHN08620U_txt8";
            this.PMKHN08620U_txt8.OutputFormat = resources.GetString("PMKHN08620U_txt8.OutputFormat");
            this.PMKHN08620U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08620U_txt8.Text = "あいうえおかきくけこ";
            this.PMKHN08620U_txt8.Top = 1.5F;
            this.PMKHN08620U_txt8.Width = 1.1875F;
            // 
            // PMKHN08650U_txt1
            // 
            this.PMKHN08650U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt1.DataField = "chgsrcmakercd";
            this.PMKHN08650U_txt1.Height = 0.15F;
            this.PMKHN08650U_txt1.Left = 0F;
            this.PMKHN08650U_txt1.MultiLine = false;
            this.PMKHN08650U_txt1.Name = "PMKHN08650U_txt1";
            this.PMKHN08650U_txt1.OutputFormat = resources.GetString("PMKHN08650U_txt1.OutputFormat");
            this.PMKHN08650U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08650U_txt1.Text = "1234";
            this.PMKHN08650U_txt1.Top = 1.9375F;
            this.PMKHN08650U_txt1.Width = 0.3125F;
            // 
            // PMKHN08650U_txt2
            // 
            this.PMKHN08650U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt2.DataField = "chgsrcmakername";
            this.PMKHN08650U_txt2.Height = 0.15F;
            this.PMKHN08650U_txt2.Left = 0.3125F;
            this.PMKHN08650U_txt2.MultiLine = false;
            this.PMKHN08650U_txt2.Name = "PMKHN08650U_txt2";
            this.PMKHN08650U_txt2.OutputFormat = resources.GetString("PMKHN08650U_txt2.OutputFormat");
            this.PMKHN08650U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08650U_txt2.Text = "あいうえおかきくけこ";
            this.PMKHN08650U_txt2.Top = 1.9375F;
            this.PMKHN08650U_txt2.Width = 1.1875F;
            // 
            // PMKHN08650U_txt3
            // 
            this.PMKHN08650U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt3.DataField = "chgsrcgoodsno";
            this.PMKHN08650U_txt3.Height = 0.15F;
            this.PMKHN08650U_txt3.Left = 1.625F;
            this.PMKHN08650U_txt3.MultiLine = false;
            this.PMKHN08650U_txt3.Name = "PMKHN08650U_txt3";
            this.PMKHN08650U_txt3.OutputFormat = resources.GetString("PMKHN08650U_txt3.OutputFormat");
            this.PMKHN08650U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08650U_txt3.Text = "123456789012345678901234";
            this.PMKHN08650U_txt3.Top = 1.9375F;
            this.PMKHN08650U_txt3.Width = 1.4375F;
            // 
            // PMKHN08650U_txt4
            // 
            this.PMKHN08650U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt4.DataField = "chgdestmakercd";
            this.PMKHN08650U_txt4.Height = 0.15F;
            this.PMKHN08650U_txt4.Left = 3.1875F;
            this.PMKHN08650U_txt4.MultiLine = false;
            this.PMKHN08650U_txt4.Name = "PMKHN08650U_txt4";
            this.PMKHN08650U_txt4.OutputFormat = resources.GetString("PMKHN08650U_txt4.OutputFormat");
            this.PMKHN08650U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08650U_txt4.Text = "1234";
            this.PMKHN08650U_txt4.Top = 1.9375F;
            this.PMKHN08650U_txt4.Width = 0.3125F;
            // 
            // PMKHN08650U_txt5
            // 
            this.PMKHN08650U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt5.DataField = "chgdestmakername";
            this.PMKHN08650U_txt5.Height = 0.15F;
            this.PMKHN08650U_txt5.Left = 3.5F;
            this.PMKHN08650U_txt5.MultiLine = false;
            this.PMKHN08650U_txt5.Name = "PMKHN08650U_txt5";
            this.PMKHN08650U_txt5.OutputFormat = resources.GetString("PMKHN08650U_txt5.OutputFormat");
            this.PMKHN08650U_txt5.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08650U_txt5.Text = "あいうえおかきくけこ";
            this.PMKHN08650U_txt5.Top = 1.9375F;
            this.PMKHN08650U_txt5.Width = 1.1875F;
            // 
            // PMKHN08650U_txt7
            // 
            this.PMKHN08650U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt7.DataField = "applystadate";
            this.PMKHN08650U_txt7.Height = 0.15F;
            this.PMKHN08650U_txt7.Left = 6.4375F;
            this.PMKHN08650U_txt7.MultiLine = false;
            this.PMKHN08650U_txt7.Name = "PMKHN08650U_txt7";
            this.PMKHN08650U_txt7.OutputFormat = resources.GetString("PMKHN08650U_txt7.OutputFormat");
            this.PMKHN08650U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08650U_txt7.Text = "yyyy/mm/dd";
            this.PMKHN08650U_txt7.Top = 1.9375F;
            this.PMKHN08650U_txt7.Width = 0.6875001F;
            // 
            // PMKHN08650U_txt8
            // 
            this.PMKHN08650U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt8.DataField = "applyenddate";
            this.PMKHN08650U_txt8.Height = 0.15F;
            this.PMKHN08650U_txt8.Left = 7.25F;
            this.PMKHN08650U_txt8.MultiLine = false;
            this.PMKHN08650U_txt8.Name = "PMKHN08650U_txt8";
            this.PMKHN08650U_txt8.OutputFormat = resources.GetString("PMKHN08650U_txt8.OutputFormat");
            this.PMKHN08650U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08650U_txt8.Text = "yyyy/mm/dd";
            this.PMKHN08650U_txt8.Top = 1.9375F;
            this.PMKHN08650U_txt8.Width = 0.6875001F;
            // 
            // PMKHN08650U_txt6
            // 
            this.PMKHN08650U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_txt6.DataField = "chgdestgoodsno";
            this.PMKHN08650U_txt6.Height = 0.15F;
            this.PMKHN08650U_txt6.Left = 4.8125F;
            this.PMKHN08650U_txt6.MultiLine = false;
            this.PMKHN08650U_txt6.Name = "PMKHN08650U_txt6";
            this.PMKHN08650U_txt6.OutputFormat = resources.GetString("PMKHN08650U_txt6.OutputFormat");
            this.PMKHN08650U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08650U_txt6.Text = "12345678901234567901234";
            this.PMKHN08650U_txt6.Top = 1.9375F;
            this.PMKHN08650U_txt6.Width = 1.4375F;
            // 
            // PMKHN08640U_txt2
            // 
            this.PMKHN08640U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt2.DataField = "joinsourcemakername";
            this.PMKHN08640U_txt2.Height = 0.15F;
            this.PMKHN08640U_txt2.Left = 0.3125F;
            this.PMKHN08640U_txt2.MultiLine = false;
            this.PMKHN08640U_txt2.Name = "PMKHN08640U_txt2";
            this.PMKHN08640U_txt2.OutputFormat = resources.GetString("PMKHN08640U_txt2.OutputFormat");
            this.PMKHN08640U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08640U_txt2.Text = "あいうえおかきくけこ";
            this.PMKHN08640U_txt2.Top = 1.6875F;
            this.PMKHN08640U_txt2.Width = 1.1875F;
            // 
            // PMKHN08640U_txt1
            // 
            this.PMKHN08640U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt1.DataField = "joinsourcemakercode";
            this.PMKHN08640U_txt1.Height = 0.15F;
            this.PMKHN08640U_txt1.Left = 0F;
            this.PMKHN08640U_txt1.MultiLine = false;
            this.PMKHN08640U_txt1.Name = "PMKHN08640U_txt1";
            this.PMKHN08640U_txt1.OutputFormat = resources.GetString("PMKHN08640U_txt1.OutputFormat");
            this.PMKHN08640U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08640U_txt1.Text = "1234";
            this.PMKHN08640U_txt1.Top = 1.6875F;
            this.PMKHN08640U_txt1.Width = 0.3125F;
            // 
            // PMKHN08640U_txt3
            // 
            this.PMKHN08640U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt3.DataField = "joinsourpartsnowithh";
            this.PMKHN08640U_txt3.Height = 0.15F;
            this.PMKHN08640U_txt3.Left = 1.625F;
            this.PMKHN08640U_txt3.MultiLine = false;
            this.PMKHN08640U_txt3.Name = "PMKHN08640U_txt3";
            this.PMKHN08640U_txt3.OutputFormat = resources.GetString("PMKHN08640U_txt3.OutputFormat");
            this.PMKHN08640U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08640U_txt3.Text = "123456789012345678901234";
            this.PMKHN08640U_txt3.Top = 1.6875F;
            this.PMKHN08640U_txt3.Width = 1.4375F;
            // 
            // PMKHN08640U_txt4
            // 
            this.PMKHN08640U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt4.DataField = "goodsnamekana";
            this.PMKHN08640U_txt4.Height = 0.15F;
            this.PMKHN08640U_txt4.Left = 3.1875F;
            this.PMKHN08640U_txt4.MultiLine = false;
            this.PMKHN08640U_txt4.Name = "PMKHN08640U_txt4";
            this.PMKHN08640U_txt4.OutputFormat = resources.GetString("PMKHN08640U_txt4.OutputFormat");
            this.PMKHN08640U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08640U_txt4.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08640U_txt4.Top = 1.6875F;
            this.PMKHN08640U_txt4.Width = 2.3125F;
            // 
            // PMKHN08640U_txt6
            // 
            this.PMKHN08640U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt6.DataField = "joindestpartsno";
            this.PMKHN08640U_txt6.Height = 0.15F;
            this.PMKHN08640U_txt6.Left = 6F;
            this.PMKHN08640U_txt6.MultiLine = false;
            this.PMKHN08640U_txt6.Name = "PMKHN08640U_txt6";
            this.PMKHN08640U_txt6.OutputFormat = resources.GetString("PMKHN08640U_txt6.OutputFormat");
            this.PMKHN08640U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08640U_txt6.Text = "12345679801234567901234";
            this.PMKHN08640U_txt6.Top = 1.6875F;
            this.PMKHN08640U_txt6.Width = 1.4375F;
            // 
            // PMKHN08640U_txt7
            // 
            this.PMKHN08640U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt7.DataField = "joindestmakercd";
            this.PMKHN08640U_txt7.Height = 0.15F;
            this.PMKHN08640U_txt7.Left = 7.5625F;
            this.PMKHN08640U_txt7.MultiLine = false;
            this.PMKHN08640U_txt7.Name = "PMKHN08640U_txt7";
            this.PMKHN08640U_txt7.OutputFormat = resources.GetString("PMKHN08640U_txt7.OutputFormat");
            this.PMKHN08640U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08640U_txt7.Text = "1234";
            this.PMKHN08640U_txt7.Top = 1.6875F;
            this.PMKHN08640U_txt7.Width = 0.3125F;
            // 
            // PMKHN08640U_txt8
            // 
            this.PMKHN08640U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt8.DataField = "joindestmakername";
            this.PMKHN08640U_txt8.Height = 0.15F;
            this.PMKHN08640U_txt8.Left = 7.875F;
            this.PMKHN08640U_txt8.MultiLine = false;
            this.PMKHN08640U_txt8.Name = "PMKHN08640U_txt8";
            this.PMKHN08640U_txt8.OutputFormat = resources.GetString("PMKHN08640U_txt8.OutputFormat");
            this.PMKHN08640U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08640U_txt8.Text = "あいうえおかきくけこ";
            this.PMKHN08640U_txt8.Top = 1.6875F;
            this.PMKHN08640U_txt8.Width = 1.1875F;
            // 
            // PMKHN08640U_txt9
            // 
            this.PMKHN08640U_txt9.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt9.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt9.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt9.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt9.DataField = "joinqty";
            this.PMKHN08640U_txt9.Height = 0.15F;
            this.PMKHN08640U_txt9.Left = 9.1875F;
            this.PMKHN08640U_txt9.MultiLine = false;
            this.PMKHN08640U_txt9.Name = "PMKHN08640U_txt9";
            this.PMKHN08640U_txt9.OutputFormat = resources.GetString("PMKHN08640U_txt9.OutputFormat");
            this.PMKHN08640U_txt9.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08640U_txt9.Text = "12345";
            this.PMKHN08640U_txt9.Top = 1.6875F;
            this.PMKHN08640U_txt9.Width = 0.38F;
            // 
            // PMKHN08640U_txt5
            // 
            this.PMKHN08640U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_txt5.DataField = "joindisporder";
            this.PMKHN08640U_txt5.Height = 0.15F;
            this.PMKHN08640U_txt5.Left = 5.625F;
            this.PMKHN08640U_txt5.MultiLine = false;
            this.PMKHN08640U_txt5.Name = "PMKHN08640U_txt5";
            this.PMKHN08640U_txt5.OutputFormat = resources.GetString("PMKHN08640U_txt5.OutputFormat");
            this.PMKHN08640U_txt5.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08640U_txt5.Text = "12345";
            this.PMKHN08640U_txt5.Top = 1.6875F;
            this.PMKHN08640U_txt5.Width = 0.3124997F;
            // 
            // PMKHN08660U_txt1
            // 
            this.PMKHN08660U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt1.DataField = "parentgoodsmakercd";
            this.PMKHN08660U_txt1.Height = 0.15F;
            this.PMKHN08660U_txt1.Left = 0F;
            this.PMKHN08660U_txt1.MultiLine = false;
            this.PMKHN08660U_txt1.Name = "PMKHN08660U_txt1";
            this.PMKHN08660U_txt1.OutputFormat = resources.GetString("PMKHN08660U_txt1.OutputFormat");
            this.PMKHN08660U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08660U_txt1.Text = "1234";
            this.PMKHN08660U_txt1.Top = 2.125F;
            this.PMKHN08660U_txt1.Width = 0.3125F;
            // 
            // PMKHN08660U_txt2
            // 
            this.PMKHN08660U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt2.DataField = "parentgoodsmakername";
            this.PMKHN08660U_txt2.Height = 0.15F;
            this.PMKHN08660U_txt2.Left = 0.3125F;
            this.PMKHN08660U_txt2.MultiLine = false;
            this.PMKHN08660U_txt2.Name = "PMKHN08660U_txt2";
            this.PMKHN08660U_txt2.OutputFormat = resources.GetString("PMKHN08660U_txt2.OutputFormat");
            this.PMKHN08660U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08660U_txt2.Text = "あいうえおかきくけこ";
            this.PMKHN08660U_txt2.Top = 2.125F;
            this.PMKHN08660U_txt2.Width = 1.1875F;
            // 
            // PMKHN08660U_txt3
            // 
            this.PMKHN08660U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt3.DataField = "parentgoodsno";
            this.PMKHN08660U_txt3.Height = 0.15F;
            this.PMKHN08660U_txt3.Left = 1.625F;
            this.PMKHN08660U_txt3.MultiLine = false;
            this.PMKHN08660U_txt3.Name = "PMKHN08660U_txt3";
            this.PMKHN08660U_txt3.OutputFormat = resources.GetString("PMKHN08660U_txt3.OutputFormat");
            this.PMKHN08660U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08660U_txt3.Text = "12345678901234";
            this.PMKHN08660U_txt3.Top = 2.125F;
            this.PMKHN08660U_txt3.Width = 1.4375F;
            // 
            // PMKHN08660U_txt4
            // 
            this.PMKHN08660U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt4.DataField = "displayorder";
            this.PMKHN08660U_txt4.Height = 0.15F;
            this.PMKHN08660U_txt4.Left = 3.1875F;
            this.PMKHN08660U_txt4.MultiLine = false;
            this.PMKHN08660U_txt4.Name = "PMKHN08660U_txt4";
            this.PMKHN08660U_txt4.OutputFormat = resources.GetString("PMKHN08660U_txt4.OutputFormat");
            this.PMKHN08660U_txt4.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08660U_txt4.Text = "1234";
            this.PMKHN08660U_txt4.Top = 2.125F;
            this.PMKHN08660U_txt4.Width = 0.3124997F;
            // 
            // PMKHN08660U_txt5
            // 
            this.PMKHN08660U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt5.DataField = "subgoodsno";
            this.PMKHN08660U_txt5.Height = 0.15F;
            this.PMKHN08660U_txt5.Left = 3.6875F;
            this.PMKHN08660U_txt5.MultiLine = false;
            this.PMKHN08660U_txt5.Name = "PMKHN08660U_txt5";
            this.PMKHN08660U_txt5.OutputFormat = resources.GetString("PMKHN08660U_txt5.OutputFormat");
            this.PMKHN08660U_txt5.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08660U_txt5.Text = "12345678901234";
            this.PMKHN08660U_txt5.Top = 2.125F;
            this.PMKHN08660U_txt5.Width = 1.4375F;
            // 
            // PMKHN08660U_txt6
            // 
            this.PMKHN08660U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt6.DataField = "goodsnamekana";
            this.PMKHN08660U_txt6.Height = 0.15F;
            this.PMKHN08660U_txt6.Left = 5.1875F;
            this.PMKHN08660U_txt6.MultiLine = false;
            this.PMKHN08660U_txt6.Name = "PMKHN08660U_txt6";
            this.PMKHN08660U_txt6.OutputFormat = resources.GetString("PMKHN08660U_txt6.OutputFormat");
            this.PMKHN08660U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08660U_txt6.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08660U_txt6.Top = 2.125F;
            this.PMKHN08660U_txt6.Width = 2.25F;
            // 
            // PMKHN08660U_txt7
            // 
            this.PMKHN08660U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt7.DataField = "subgoodsmakercd";
            this.PMKHN08660U_txt7.Height = 0.15F;
            this.PMKHN08660U_txt7.Left = 7.5625F;
            this.PMKHN08660U_txt7.MultiLine = false;
            this.PMKHN08660U_txt7.Name = "PMKHN08660U_txt7";
            this.PMKHN08660U_txt7.OutputFormat = resources.GetString("PMKHN08660U_txt7.OutputFormat");
            this.PMKHN08660U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08660U_txt7.Text = "1234";
            this.PMKHN08660U_txt7.Top = 2.125F;
            this.PMKHN08660U_txt7.Width = 0.3125F;
            // 
            // PMKHN08660U_txt8
            // 
            this.PMKHN08660U_txt8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt8.DataField = "subgoodsmakername";
            this.PMKHN08660U_txt8.Height = 0.15F;
            this.PMKHN08660U_txt8.Left = 7.875F;
            this.PMKHN08660U_txt8.MultiLine = false;
            this.PMKHN08660U_txt8.Name = "PMKHN08660U_txt8";
            this.PMKHN08660U_txt8.OutputFormat = resources.GetString("PMKHN08660U_txt8.OutputFormat");
            this.PMKHN08660U_txt8.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08660U_txt8.Text = "あいうえおかきくけこ";
            this.PMKHN08660U_txt8.Top = 2.125F;
            this.PMKHN08660U_txt8.Width = 1.1875F;
            // 
            // PMKHN08660U_txt9
            // 
            this.PMKHN08660U_txt9.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt9.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt9.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt9.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt9.DataField = "cntfl";
            this.PMKHN08660U_txt9.Height = 0.15F;
            this.PMKHN08660U_txt9.Left = 9.1875F;
            this.PMKHN08660U_txt9.MultiLine = false;
            this.PMKHN08660U_txt9.Name = "PMKHN08660U_txt9";
            this.PMKHN08660U_txt9.OutputFormat = resources.GetString("PMKHN08660U_txt9.OutputFormat");
            this.PMKHN08660U_txt9.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08660U_txt9.Text = "12,345,678";
            this.PMKHN08660U_txt9.Top = 2.125F;
            this.PMKHN08660U_txt9.Width = 0.38F;
            // 
            // PMKHN08660U_txt10
            // 
            this.PMKHN08660U_txt10.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt10.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt10.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt10.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_txt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_txt10.DataField = "setspecialnote";
            this.PMKHN08660U_txt10.Height = 0.15F;
            this.PMKHN08660U_txt10.Left = 0.3125F;
            this.PMKHN08660U_txt10.MultiLine = false;
            this.PMKHN08660U_txt10.Name = "PMKHN08660U_txt10";
            this.PMKHN08660U_txt10.OutputFormat = resources.GetString("PMKHN08660U_txt10.OutputFormat");
            this.PMKHN08660U_txt10.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08660U_txt10.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08660U_txt10.Top = 2.3125F;
            this.PMKHN08660U_txt10.Width = 3.9375F;
            // 
            // PMKHN08670U_txt1
            // 
            this.PMKHN08670U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt1.DataField = "code";
            this.PMKHN08670U_txt1.Height = 0.15F;
            this.PMKHN08670U_txt1.Left = 0F;
            this.PMKHN08670U_txt1.MultiLine = false;
            this.PMKHN08670U_txt1.Name = "PMKHN08670U_txt1";
            this.PMKHN08670U_txt1.OutputFormat = resources.GetString("PMKHN08670U_txt1.OutputFormat");
            this.PMKHN08670U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08670U_txt1.Text = "123-456-789";
            this.PMKHN08670U_txt1.Top = 2.5F;
            this.PMKHN08670U_txt1.Width = 0.6875F;
            // 
            // PMKHN08670U_txt2
            // 
            this.PMKHN08670U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt2.DataField = "modelfullname";
            this.PMKHN08670U_txt2.Height = 0.15F;
            this.PMKHN08670U_txt2.Left = 0.6875F;
            this.PMKHN08670U_txt2.MultiLine = false;
            this.PMKHN08670U_txt2.Name = "PMKHN08670U_txt2";
            this.PMKHN08670U_txt2.OutputFormat = resources.GetString("PMKHN08670U_txt2.OutputFormat");
            this.PMKHN08670U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08670U_txt2.Text = "あいうえおかきくけこあいうえお";
            this.PMKHN08670U_txt2.Top = 2.5F;
            this.PMKHN08670U_txt2.Width = 1.75F;
            // 
            // PMKHN08670U_txt3
            // 
            this.PMKHN08670U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt3.DataField = "modelhalfname";
            this.PMKHN08670U_txt3.Height = 0.15F;
            this.PMKHN08670U_txt3.Left = 2.5625F;
            this.PMKHN08670U_txt3.MultiLine = false;
            this.PMKHN08670U_txt3.Name = "PMKHN08670U_txt3";
            this.PMKHN08670U_txt3.OutputFormat = resources.GetString("PMKHN08670U_txt3.OutputFormat");
            this.PMKHN08670U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08670U_txt3.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08670U_txt3.Top = 2.5F;
            this.PMKHN08670U_txt3.Width = 3.375F;
            // 
            // PMKHN08670U_txt4
            // 
            this.PMKHN08670U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_txt4.DataField = "modelaliasname";
            this.PMKHN08670U_txt4.Height = 0.15F;
            this.PMKHN08670U_txt4.Left = 6.0625F;
            this.PMKHN08670U_txt4.MultiLine = false;
            this.PMKHN08670U_txt4.Name = "PMKHN08670U_txt4";
            this.PMKHN08670U_txt4.OutputFormat = resources.GetString("PMKHN08670U_txt4.OutputFormat");
            this.PMKHN08670U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08670U_txt4.Text = "あいうえおかきくけこあいうえお";
            this.PMKHN08670U_txt4.Top = 2.5F;
            this.PMKHN08670U_txt4.Width = 1.75F;
            // 
            // PMKHN08680U_txt1
            // 
            this.PMKHN08680U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt1.DataField = "customercode";
            this.PMKHN08680U_txt1.Height = 0.15F;
            this.PMKHN08680U_txt1.Left = 0F;
            this.PMKHN08680U_txt1.MultiLine = false;
            this.PMKHN08680U_txt1.Name = "PMKHN08680U_txt1";
            this.PMKHN08680U_txt1.OutputFormat = resources.GetString("PMKHN08680U_txt1.OutputFormat");
            this.PMKHN08680U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08680U_txt1.Text = "12345678";
            this.PMKHN08680U_txt1.Top = 2.75F;
            this.PMKHN08680U_txt1.Width = 0.5F;
            // 
            // PMKHN08680U_txt2
            // 
            this.PMKHN08680U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt2.DataField = "customersnm";
            this.PMKHN08680U_txt2.Height = 0.15F;
            this.PMKHN08680U_txt2.Left = 0.5625001F;
            this.PMKHN08680U_txt2.MultiLine = false;
            this.PMKHN08680U_txt2.Name = "PMKHN08680U_txt2";
            this.PMKHN08680U_txt2.OutputFormat = resources.GetString("PMKHN08680U_txt2.OutputFormat");
            this.PMKHN08680U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08680U_txt2.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08680U_txt2.Top = 2.75F;
            this.PMKHN08680U_txt2.Width = 3F;
            // 
            // PMKHN08680U_txt5
            // 
            this.PMKHN08680U_txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt5.DataField = "posdisporder";
            this.PMKHN08680U_txt5.Height = 0.15F;
            this.PMKHN08680U_txt5.Left = 7.0625F;
            this.PMKHN08680U_txt5.MultiLine = false;
            this.PMKHN08680U_txt5.Name = "PMKHN08680U_txt5";
            this.PMKHN08680U_txt5.OutputFormat = resources.GetString("PMKHN08680U_txt5.OutputFormat");
            this.PMKHN08680U_txt5.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PMKHN08680U_txt5.Text = "1234";
            this.PMKHN08680U_txt5.Top = 2.75F;
            this.PMKHN08680U_txt5.Width = 0.3124997F;
            // 
            // PMKHN08680U_txt6
            // 
            this.PMKHN08680U_txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt6.DataField = "tbspartscode";
            this.PMKHN08680U_txt6.Height = 0.15F;
            this.PMKHN08680U_txt6.Left = 7.4375F;
            this.PMKHN08680U_txt6.MultiLine = false;
            this.PMKHN08680U_txt6.Name = "PMKHN08680U_txt6";
            this.PMKHN08680U_txt6.OutputFormat = resources.GetString("PMKHN08680U_txt6.OutputFormat");
            this.PMKHN08680U_txt6.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08680U_txt6.Text = "12345";
            this.PMKHN08680U_txt6.Top = 2.75F;
            this.PMKHN08680U_txt6.Width = 0.3124997F;
            // 
            // PMKHN08680U_txt7
            // 
            this.PMKHN08680U_txt7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt7.DataField = "blgoodshalfname";
            this.PMKHN08680U_txt7.Height = 0.15F;
            this.PMKHN08680U_txt7.Left = 7.75F;
            this.PMKHN08680U_txt7.MultiLine = false;
            this.PMKHN08680U_txt7.Name = "PMKHN08680U_txt7";
            this.PMKHN08680U_txt7.OutputFormat = resources.GetString("PMKHN08680U_txt7.OutputFormat");
            this.PMKHN08680U_txt7.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08680U_txt7.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08680U_txt7.Top = 2.75F;
            this.PMKHN08680U_txt7.Width = 3F;
            // 
            // PMKHN08680U_txt3
            // 
            this.PMKHN08680U_txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt3.DataField = "searchpartsposcode";
            this.PMKHN08680U_txt3.Height = 0.15F;
            this.PMKHN08680U_txt3.Left = 3.625F;
            this.PMKHN08680U_txt3.MultiLine = false;
            this.PMKHN08680U_txt3.Name = "PMKHN08680U_txt3";
            this.PMKHN08680U_txt3.OutputFormat = resources.GetString("PMKHN08680U_txt3.OutputFormat");
            this.PMKHN08680U_txt3.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08680U_txt3.Text = "12";
            this.PMKHN08680U_txt3.Top = 2.75F;
            this.PMKHN08680U_txt3.Width = 0.3124997F;
            // 
            // PMKHN08680U_txt4
            // 
            this.PMKHN08680U_txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_txt4.DataField = "searchpartsposname";
            this.PMKHN08680U_txt4.Height = 0.15F;
            this.PMKHN08680U_txt4.Left = 3.937499F;
            this.PMKHN08680U_txt4.MultiLine = false;
            this.PMKHN08680U_txt4.Name = "PMKHN08680U_txt4";
            this.PMKHN08680U_txt4.OutputFormat = resources.GetString("PMKHN08680U_txt4.OutputFormat");
            this.PMKHN08680U_txt4.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08680U_txt4.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08680U_txt4.Top = 2.75F;
            this.PMKHN08680U_txt4.Width = 3F;
            // 
            // PMKHN08590U_txt1
            // 
            this.PMKHN08590U_txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt1.DataField = "goodsmgroup";
            this.PMKHN08590U_txt1.Height = 0.15F;
            this.PMKHN08590U_txt1.Left = 0F;
            this.PMKHN08590U_txt1.MultiLine = false;
            this.PMKHN08590U_txt1.Name = "PMKHN08590U_txt1";
            this.PMKHN08590U_txt1.OutputFormat = resources.GetString("PMKHN08590U_txt1.OutputFormat");
            this.PMKHN08590U_txt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PMKHN08590U_txt1.Text = "1234";
            this.PMKHN08590U_txt1.Top = 1.079166F;
            this.PMKHN08590U_txt1.Width = 0.3125F;
            // 
            // PMKHN08590U_txt2
            // 
            this.PMKHN08590U_txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08590U_txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_txt2.DataField = "goodsmgroupname";
            this.PMKHN08590U_txt2.Height = 0.15F;
            this.PMKHN08590U_txt2.Left = 0.3125F;
            this.PMKHN08590U_txt2.MultiLine = false;
            this.PMKHN08590U_txt2.Name = "PMKHN08590U_txt2";
            this.PMKHN08590U_txt2.OutputFormat = resources.GetString("PMKHN08590U_txt2.OutputFormat");
            this.PMKHN08590U_txt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PMKHN08590U_txt2.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.PMKHN08590U_txt2.Top = 1.079166F;
            this.PMKHN08590U_txt2.Width = 3.375F;
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
            this.line4.Top = 0.3958333F;
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0.3958333F;
            this.line4.Y2 = 0.3958333F;
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
            this.tb_ReportTitle.Height = 0.21F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.1875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "ＮＮＮＮＮＮＮＮＮ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 6.375F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3020833F;
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
            this.PMKHN08510U_lbl1,
            this.PMKHN08510U_lbl2,
            this.line2,
            this.PMKHN08510U_lbl3,
            this.PMKHN08510U_lbl4,
            this.PMKHN08510U_lbl5,
            this.PMKHN08510U_lbl6,
            this.PMKHN08530U_lbl1,
            this.PMKHN08530U_lbl2,
            this.PMKHN08540U_lbl1,
            this.PMKHN08540U_lbl2,
            this.PMKHN08540U_lbl3,
            this.PMKHN08570U_lbl1,
            this.PMKHN08570U_lbl2,
            this.PMKHN08570U_lbl3,
            this.PMKHN08570U_lbl4,
            this.PMKHN08570U_lbl5,
            this.PMKHN08570U_lbl6,
            this.PMKHN08580U_lbl1,
            this.PMKHN08580U_lbl2,
            this.PMKHN08580U_lbl3,
            this.PMKHN08580U_lbl4,
            this.PMKHN08580U_lbl5,
            this.PMKHN08600U_lbl1,
            this.PMKHN08600U_lbl2,
            this.PMKHN08600U_lbl3,
            this.PMKHN08600U_lbl4,
            this.PMKHN08600U_lbl5,
            this.PMKHN08600U_lbl6,
            this.PMKHN08620U_lbl1,
            this.PMKHN08620U_lbl2,
            this.PMKHN08620U_lbl3,
            this.PMKHN08620U_lbl4,
            this.PMKHN08620U_lbl5,
            this.PMKHN08620U_lbl6,
            this.PMKHN08620U_lbl7,
            this.PMKHN08650U_lbl1,
            this.PMKHN08650U_lbl2,
            this.PMKHN08650U_lbl3,
            this.PMKHN08650U_lbl4,
            this.PMKHN08650U_lbl5,
            this.PMKHN08650U_lbl6,
            this.PMKHN08650U_lbl7,
            this.PMKHN08640U_lbl1,
            this.PMKHN08640U_lbl2,
            this.PMKHN08640U_lbl3,
            this.PMKHN08640U_lbl4,
            this.PMKHN08640U_lbl5,
            this.PMKHN08640U_lbl6,
            this.PMKHN08640U_lbl7,
            this.PMKHN08640U_lbl8,
            this.PMKHN08660U_lbl1,
            this.PMKHN08660U_lbl2,
            this.PMKHN08660U_lbl3,
            this.PMKHN08660U_lbl4,
            this.PMKHN08660U_lbl5,
            this.PMKHN08660U_lbl6,
            this.PMKHN08660U_lbl7,
            this.PMKHN08660U_lbl8,
            this.PMKHN08660U_lbl9,
            this.PMKHN08670U_lbl2,
            this.PMKHN08670U_lbl1,
            this.PMKHN08670U_lbl3,
            this.PMKHN08670U_lbl4,
            this.PMKHN08680U_lbl1,
            this.PMKHN08680U_lbl2,
            this.PMKHN08680U_lbl3,
            this.PMKHN08680U_lbl4,
            this.PMKHN08680U_lbl5,
            this.PMKHN08590U_lbl1,
            this.PMKHN08590U_lbl2,
            this.line6});
            this.TitleHeader.Height = 3.260417F;
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
            // PMKHN08510U_lbl1
            // 
            this.PMKHN08510U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl1.Height = 0.15F;
            this.PMKHN08510U_lbl1.HyperLink = "";
            this.PMKHN08510U_lbl1.Left = 0F;
            this.PMKHN08510U_lbl1.MultiLine = false;
            this.PMKHN08510U_lbl1.Name = "PMKHN08510U_lbl1";
            this.PMKHN08510U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08510U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08510U_lbl1.Top = 0.0625F;
            this.PMKHN08510U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08510U_lbl2
            // 
            this.PMKHN08510U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl2.Height = 0.15F;
            this.PMKHN08510U_lbl2.HyperLink = "";
            this.PMKHN08510U_lbl2.Left = 0.3125F;
            this.PMKHN08510U_lbl2.MultiLine = false;
            this.PMKHN08510U_lbl2.Name = "PMKHN08510U_lbl2";
            this.PMKHN08510U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08510U_lbl2.Text = "倉庫名";
            this.PMKHN08510U_lbl2.Top = 0.0625F;
            this.PMKHN08510U_lbl2.Width = 1.1875F;
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
            this.line2.Top = 0.2291667F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.2291667F;
            this.line2.Y2 = 0.2291667F;
            // 
            // PMKHN08510U_lbl3
            // 
            this.PMKHN08510U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl3.Height = 0.15F;
            this.PMKHN08510U_lbl3.HyperLink = "";
            this.PMKHN08510U_lbl3.Left = 1.640625F;
            this.PMKHN08510U_lbl3.MultiLine = false;
            this.PMKHN08510U_lbl3.Name = "PMKHN08510U_lbl3";
            this.PMKHN08510U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08510U_lbl3.Text = "管理拠点";
            this.PMKHN08510U_lbl3.Top = 0.0625F;
            this.PMKHN08510U_lbl3.Width = 1.625F;
            // 
            // PMKHN08510U_lbl4
            // 
            this.PMKHN08510U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl4.Height = 0.15F;
            this.PMKHN08510U_lbl4.HyperLink = "";
            this.PMKHN08510U_lbl4.Left = 3.40625F;
            this.PMKHN08510U_lbl4.MultiLine = false;
            this.PMKHN08510U_lbl4.Name = "PMKHN08510U_lbl4";
            this.PMKHN08510U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08510U_lbl4.Text = "得意先";
            this.PMKHN08510U_lbl4.Top = 0.0625F;
            this.PMKHN08510U_lbl4.Width = 2.8125F;
            // 
            // PMKHN08510U_lbl5
            // 
            this.PMKHN08510U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl5.Height = 0.15F;
            this.PMKHN08510U_lbl5.HyperLink = "";
            this.PMKHN08510U_lbl5.Left = 6.359375F;
            this.PMKHN08510U_lbl5.MultiLine = false;
            this.PMKHN08510U_lbl5.Name = "PMKHN08510U_lbl5";
            this.PMKHN08510U_lbl5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08510U_lbl5.Text = "主管倉庫";
            this.PMKHN08510U_lbl5.Top = 0.0625F;
            this.PMKHN08510U_lbl5.Width = 1.75F;
            // 
            // PMKHN08510U_lbl6
            // 
            this.PMKHN08510U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08510U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08510U_lbl6.Height = 0.15F;
            this.PMKHN08510U_lbl6.HyperLink = "";
            this.PMKHN08510U_lbl6.Left = 8.25F;
            this.PMKHN08510U_lbl6.MultiLine = false;
            this.PMKHN08510U_lbl6.Name = "PMKHN08510U_lbl6";
            this.PMKHN08510U_lbl6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08510U_lbl6.Text = "リマーク";
            this.PMKHN08510U_lbl6.Top = 0.0625F;
            this.PMKHN08510U_lbl6.Width = 1.75F;
            // 
            // PMKHN08530U_lbl1
            // 
            this.PMKHN08530U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl1.Height = 0.15F;
            this.PMKHN08530U_lbl1.HyperLink = "";
            this.PMKHN08530U_lbl1.Left = 0F;
            this.PMKHN08530U_lbl1.MultiLine = false;
            this.PMKHN08530U_lbl1.Name = "PMKHN08530U_lbl1";
            this.PMKHN08530U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08530U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08530U_lbl1.Top = 0.2645833F;
            this.PMKHN08530U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08530U_lbl2
            // 
            this.PMKHN08530U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08530U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08530U_lbl2.Height = 0.15F;
            this.PMKHN08530U_lbl2.HyperLink = "";
            this.PMKHN08530U_lbl2.Left = 0.3125F;
            this.PMKHN08530U_lbl2.MultiLine = false;
            this.PMKHN08530U_lbl2.Name = "PMKHN08530U_lbl2";
            this.PMKHN08530U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08530U_lbl2.Text = "名称";
            this.PMKHN08530U_lbl2.Top = 0.2645833F;
            this.PMKHN08530U_lbl2.Width = 3.375F;
            // 
            // PMKHN08540U_lbl1
            // 
            this.PMKHN08540U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl1.Height = 0.15F;
            this.PMKHN08540U_lbl1.HyperLink = "";
            this.PMKHN08540U_lbl1.Left = 0F;
            this.PMKHN08540U_lbl1.MultiLine = false;
            this.PMKHN08540U_lbl1.Name = "PMKHN08540U_lbl1";
            this.PMKHN08540U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08540U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08540U_lbl1.Top = 0.4875F;
            this.PMKHN08540U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08540U_lbl2
            // 
            this.PMKHN08540U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl2.Height = 0.15F;
            this.PMKHN08540U_lbl2.HyperLink = "";
            this.PMKHN08540U_lbl2.Left = 0.3125F;
            this.PMKHN08540U_lbl2.MultiLine = false;
            this.PMKHN08540U_lbl2.Name = "PMKHN08540U_lbl2";
            this.PMKHN08540U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08540U_lbl2.Text = "名称";
            this.PMKHN08540U_lbl2.Top = 0.4875F;
            this.PMKHN08540U_lbl2.Width = 3.375F;
            // 
            // PMKHN08540U_lbl3
            // 
            this.PMKHN08540U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08540U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08540U_lbl3.Height = 0.15F;
            this.PMKHN08540U_lbl3.HyperLink = "";
            this.PMKHN08540U_lbl3.Left = 3.875F;
            this.PMKHN08540U_lbl3.MultiLine = false;
            this.PMKHN08540U_lbl3.Name = "PMKHN08540U_lbl3";
            this.PMKHN08540U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08540U_lbl3.Text = "備考ガイドコード";
            this.PMKHN08540U_lbl3.Top = 0.4875F;
            this.PMKHN08540U_lbl3.Width = 3.375F;
            // 
            // PMKHN08570U_lbl1
            // 
            this.PMKHN08570U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl1.Height = 0.15F;
            this.PMKHN08570U_lbl1.HyperLink = "";
            this.PMKHN08570U_lbl1.Left = 0F;
            this.PMKHN08570U_lbl1.MultiLine = false;
            this.PMKHN08570U_lbl1.Name = "PMKHN08570U_lbl1";
            this.PMKHN08570U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08570U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08570U_lbl1.Top = 0.7F;
            this.PMKHN08570U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08570U_lbl2
            // 
            this.PMKHN08570U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl2.Height = 0.15F;
            this.PMKHN08570U_lbl2.HyperLink = "";
            this.PMKHN08570U_lbl2.Left = 0.3125F;
            this.PMKHN08570U_lbl2.MultiLine = false;
            this.PMKHN08570U_lbl2.Name = "PMKHN08570U_lbl2";
            this.PMKHN08570U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08570U_lbl2.Text = "名称";
            this.PMKHN08570U_lbl2.Top = 0.7F;
            this.PMKHN08570U_lbl2.Width = 2F;
            // 
            // PMKHN08570U_lbl3
            // 
            this.PMKHN08570U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl3.Height = 0.15F;
            this.PMKHN08570U_lbl3.HyperLink = "";
            this.PMKHN08570U_lbl3.Left = 2.385417F;
            this.PMKHN08570U_lbl3.MultiLine = false;
            this.PMKHN08570U_lbl3.Name = "PMKHN08570U_lbl3";
            this.PMKHN08570U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08570U_lbl3.Text = "カナ";
            this.PMKHN08570U_lbl3.Top = 0.7F;
            this.PMKHN08570U_lbl3.Width = 1F;
            // 
            // PMKHN08570U_lbl4
            // 
            this.PMKHN08570U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl4.Height = 0.15F;
            this.PMKHN08570U_lbl4.HyperLink = "";
            this.PMKHN08570U_lbl4.Left = 3.510413F;
            this.PMKHN08570U_lbl4.MultiLine = false;
            this.PMKHN08570U_lbl4.Name = "PMKHN08570U_lbl4";
            this.PMKHN08570U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08570U_lbl4.Text = "グループコード";
            this.PMKHN08570U_lbl4.Top = 0.7F;
            this.PMKHN08570U_lbl4.Width = 2F;
            // 
            // PMKHN08570U_lbl5
            // 
            this.PMKHN08570U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl5.Height = 0.15F;
            this.PMKHN08570U_lbl5.HyperLink = "";
            this.PMKHN08570U_lbl5.Left = 5.895821F;
            this.PMKHN08570U_lbl5.MultiLine = false;
            this.PMKHN08570U_lbl5.Name = "PMKHN08570U_lbl5";
            this.PMKHN08570U_lbl5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08570U_lbl5.Text = "商品中分類";
            this.PMKHN08570U_lbl5.Top = 0.7F;
            this.PMKHN08570U_lbl5.Width = 1.5F;
            // 
            // PMKHN08570U_lbl6
            // 
            this.PMKHN08570U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08570U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08570U_lbl6.Height = 0.15F;
            this.PMKHN08570U_lbl6.HyperLink = "";
            this.PMKHN08570U_lbl6.Left = 7.729169F;
            this.PMKHN08570U_lbl6.MultiLine = false;
            this.PMKHN08570U_lbl6.Name = "PMKHN08570U_lbl6";
            this.PMKHN08570U_lbl6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08570U_lbl6.Text = "装備分類";
            this.PMKHN08570U_lbl6.Top = 0.7F;
            this.PMKHN08570U_lbl6.Width = 1.5F;
            // 
            // PMKHN08580U_lbl1
            // 
            this.PMKHN08580U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl1.Height = 0.15F;
            this.PMKHN08580U_lbl1.HyperLink = "";
            this.PMKHN08580U_lbl1.Left = 0F;
            this.PMKHN08580U_lbl1.MultiLine = false;
            this.PMKHN08580U_lbl1.Name = "PMKHN08580U_lbl1";
            this.PMKHN08580U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08580U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08580U_lbl1.Top = 0.9125F;
            this.PMKHN08580U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08580U_lbl2
            // 
            this.PMKHN08580U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl2.Height = 0.15F;
            this.PMKHN08580U_lbl2.HyperLink = "";
            this.PMKHN08580U_lbl2.Left = 0.3125F;
            this.PMKHN08580U_lbl2.MultiLine = false;
            this.PMKHN08580U_lbl2.Name = "PMKHN08580U_lbl2";
            this.PMKHN08580U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08580U_lbl2.Text = "名称";
            this.PMKHN08580U_lbl2.Top = 0.9125F;
            this.PMKHN08580U_lbl2.Width = 2F;
            // 
            // PMKHN08580U_lbl3
            // 
            this.PMKHN08580U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl3.Height = 0.15F;
            this.PMKHN08580U_lbl3.HyperLink = "";
            this.PMKHN08580U_lbl3.Left = 2.21875F;
            this.PMKHN08580U_lbl3.MultiLine = false;
            this.PMKHN08580U_lbl3.Name = "PMKHN08580U_lbl3";
            this.PMKHN08580U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08580U_lbl3.Text = "略称";
            this.PMKHN08580U_lbl3.Top = 0.9125F;
            this.PMKHN08580U_lbl3.Width = 1.1875F;
            // 
            // PMKHN08580U_lbl4
            // 
            this.PMKHN08580U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl4.Height = 0.15F;
            this.PMKHN08580U_lbl4.HyperLink = "";
            this.PMKHN08580U_lbl4.Left = 3.59375F;
            this.PMKHN08580U_lbl4.MultiLine = false;
            this.PMKHN08580U_lbl4.Name = "PMKHN08580U_lbl4";
            this.PMKHN08580U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08580U_lbl4.Text = "カナ";
            this.PMKHN08580U_lbl4.Top = 0.9125F;
            this.PMKHN08580U_lbl4.Width = 3.375F;
            // 
            // PMKHN08580U_lbl5
            // 
            this.PMKHN08580U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08580U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08580U_lbl5.Height = 0.15F;
            this.PMKHN08580U_lbl5.HyperLink = "";
            this.PMKHN08580U_lbl5.Left = 7.072922F;
            this.PMKHN08580U_lbl5.MultiLine = false;
            this.PMKHN08580U_lbl5.Name = "PMKHN08580U_lbl5";
            this.PMKHN08580U_lbl5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08580U_lbl5.Text = "表示順位";
            this.PMKHN08580U_lbl5.Top = 0.9125F;
            this.PMKHN08580U_lbl5.Width = 0.5F;
            // 
            // PMKHN08600U_lbl1
            // 
            this.PMKHN08600U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl1.Height = 0.15F;
            this.PMKHN08600U_lbl1.HyperLink = "";
            this.PMKHN08600U_lbl1.Left = 0F;
            this.PMKHN08600U_lbl1.MultiLine = false;
            this.PMKHN08600U_lbl1.Name = "PMKHN08600U_lbl1";
            this.PMKHN08600U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08600U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08600U_lbl1.Top = 1.3125F;
            this.PMKHN08600U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08600U_lbl2
            // 
            this.PMKHN08600U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl2.Height = 0.15F;
            this.PMKHN08600U_lbl2.HyperLink = "";
            this.PMKHN08600U_lbl2.Left = 0.3125F;
            this.PMKHN08600U_lbl2.MultiLine = false;
            this.PMKHN08600U_lbl2.Name = "PMKHN08600U_lbl2";
            this.PMKHN08600U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08600U_lbl2.Text = "名称";
            this.PMKHN08600U_lbl2.Top = 1.3125F;
            this.PMKHN08600U_lbl2.Width = 2F;
            // 
            // PMKHN08600U_lbl3
            // 
            this.PMKHN08600U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl3.Height = 0.15F;
            this.PMKHN08600U_lbl3.HyperLink = "";
            this.PMKHN08600U_lbl3.Left = 2.375F;
            this.PMKHN08600U_lbl3.MultiLine = false;
            this.PMKHN08600U_lbl3.Name = "PMKHN08600U_lbl3";
            this.PMKHN08600U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08600U_lbl3.Text = "カナ";
            this.PMKHN08600U_lbl3.Top = 1.3125F;
            this.PMKHN08600U_lbl3.Width = 1F;
            // 
            // PMKHN08600U_lbl4
            // 
            this.PMKHN08600U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl4.Height = 0.15F;
            this.PMKHN08600U_lbl4.HyperLink = "";
            this.PMKHN08600U_lbl4.Left = 3.510413F;
            this.PMKHN08600U_lbl4.MultiLine = false;
            this.PMKHN08600U_lbl4.Name = "PMKHN08600U_lbl4";
            this.PMKHN08600U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08600U_lbl4.Text = "販売区分";
            this.PMKHN08600U_lbl4.Top = 1.3125F;
            this.PMKHN08600U_lbl4.Width = 1.5F;
            // 
            // PMKHN08600U_lbl5
            // 
            this.PMKHN08600U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl5.Height = 0.15F;
            this.PMKHN08600U_lbl5.HyperLink = "";
            this.PMKHN08600U_lbl5.Left = 5.375F;
            this.PMKHN08600U_lbl5.MultiLine = false;
            this.PMKHN08600U_lbl5.Name = "PMKHN08600U_lbl5";
            this.PMKHN08600U_lbl5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08600U_lbl5.Text = "商品大分類";
            this.PMKHN08600U_lbl5.Top = 1.3125F;
            this.PMKHN08600U_lbl5.Width = 1.5F;
            // 
            // PMKHN08600U_lbl6
            // 
            this.PMKHN08600U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08600U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08600U_lbl6.Height = 0.15F;
            this.PMKHN08600U_lbl6.HyperLink = "";
            this.PMKHN08600U_lbl6.Left = 7.6875F;
            this.PMKHN08600U_lbl6.MultiLine = false;
            this.PMKHN08600U_lbl6.Name = "PMKHN08600U_lbl6";
            this.PMKHN08600U_lbl6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08600U_lbl6.Text = "商品中分類";
            this.PMKHN08600U_lbl6.Top = 1.3125F;
            this.PMKHN08600U_lbl6.Width = 1.5F;
            // 
            // PMKHN08620U_lbl1
            // 
            this.PMKHN08620U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl1.Height = 0.15F;
            this.PMKHN08620U_lbl1.HyperLink = "";
            this.PMKHN08620U_lbl1.Left = 0F;
            this.PMKHN08620U_lbl1.MultiLine = false;
            this.PMKHN08620U_lbl1.Name = "PMKHN08620U_lbl1";
            this.PMKHN08620U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08620U_lbl1.Top = 1.5F;
            this.PMKHN08620U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08620U_lbl2
            // 
            this.PMKHN08620U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl2.Height = 0.15F;
            this.PMKHN08620U_lbl2.HyperLink = "";
            this.PMKHN08620U_lbl2.Left = 0.3125F;
            this.PMKHN08620U_lbl2.MultiLine = false;
            this.PMKHN08620U_lbl2.Name = "PMKHN08620U_lbl2";
            this.PMKHN08620U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl2.Text = "名称";
            this.PMKHN08620U_lbl2.Top = 1.5F;
            this.PMKHN08620U_lbl2.Width = 1.1875F;
            // 
            // PMKHN08620U_lbl3
            // 
            this.PMKHN08620U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl3.Height = 0.15F;
            this.PMKHN08620U_lbl3.HyperLink = "";
            this.PMKHN08620U_lbl3.Left = 1.625F;
            this.PMKHN08620U_lbl3.MultiLine = false;
            this.PMKHN08620U_lbl3.Name = "PMKHN08620U_lbl3";
            this.PMKHN08620U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl3.Text = "メーカー";
            this.PMKHN08620U_lbl3.Top = 1.5F;
            this.PMKHN08620U_lbl3.Width = 1.1875F;
            // 
            // PMKHN08620U_lbl4
            // 
            this.PMKHN08620U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl4.Height = 0.15F;
            this.PMKHN08620U_lbl4.HyperLink = "";
            this.PMKHN08620U_lbl4.Left = 3.25F;
            this.PMKHN08620U_lbl4.MultiLine = false;
            this.PMKHN08620U_lbl4.Name = "PMKHN08620U_lbl4";
            this.PMKHN08620U_lbl4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl4.Text = "上限金額";
            this.PMKHN08620U_lbl4.Top = 1.5F;
            this.PMKHN08620U_lbl4.Width = 0.7499999F;
            // 
            // PMKHN08620U_lbl5
            // 
            this.PMKHN08620U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl5.Height = 0.15F;
            this.PMKHN08620U_lbl5.HyperLink = "";
            this.PMKHN08620U_lbl5.Left = 4.0625F;
            this.PMKHN08620U_lbl5.MultiLine = false;
            this.PMKHN08620U_lbl5.Name = "PMKHN08620U_lbl5";
            this.PMKHN08620U_lbl5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl5.Text = "UP率";
            this.PMKHN08620U_lbl5.Top = 1.5F;
            this.PMKHN08620U_lbl5.Width = 0.5F;
            // 
            // PMKHN08620U_lbl6
            // 
            this.PMKHN08620U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl6.Height = 0.15F;
            this.PMKHN08620U_lbl6.HyperLink = "";
            this.PMKHN08620U_lbl6.Left = 4.625F;
            this.PMKHN08620U_lbl6.MultiLine = false;
            this.PMKHN08620U_lbl6.Name = "PMKHN08620U_lbl6";
            this.PMKHN08620U_lbl6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl6.Text = "端数処理単位";
            this.PMKHN08620U_lbl6.Top = 1.5F;
            this.PMKHN08620U_lbl6.Width = 0.7499999F;
            // 
            // PMKHN08620U_lbl7
            // 
            this.PMKHN08620U_lbl7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08620U_lbl7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08620U_lbl7.Height = 0.15F;
            this.PMKHN08620U_lbl7.HyperLink = "";
            this.PMKHN08620U_lbl7.Left = 5.458333F;
            this.PMKHN08620U_lbl7.MultiLine = false;
            this.PMKHN08620U_lbl7.Name = "PMKHN08620U_lbl7";
            this.PMKHN08620U_lbl7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08620U_lbl7.Text = "端数処理区分";
            this.PMKHN08620U_lbl7.Top = 1.5F;
            this.PMKHN08620U_lbl7.Width = 1.1875F;
            // 
            // PMKHN08650U_lbl1
            // 
            this.PMKHN08650U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl1.Height = 0.15F;
            this.PMKHN08650U_lbl1.HyperLink = "";
            this.PMKHN08650U_lbl1.Left = 0F;
            this.PMKHN08650U_lbl1.MultiLine = false;
            this.PMKHN08650U_lbl1.Name = "PMKHN08650U_lbl1";
            this.PMKHN08650U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08650U_lbl1.Top = 1.9375F;
            this.PMKHN08650U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08650U_lbl2
            // 
            this.PMKHN08650U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl2.Height = 0.15F;
            this.PMKHN08650U_lbl2.HyperLink = "";
            this.PMKHN08650U_lbl2.Left = 0.3125F;
            this.PMKHN08650U_lbl2.MultiLine = false;
            this.PMKHN08650U_lbl2.Name = "PMKHN08650U_lbl2";
            this.PMKHN08650U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl2.Text = "名称";
            this.PMKHN08650U_lbl2.Top = 1.9375F;
            this.PMKHN08650U_lbl2.Width = 1.1875F;
            // 
            // PMKHN08650U_lbl3
            // 
            this.PMKHN08650U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl3.Height = 0.15F;
            this.PMKHN08650U_lbl3.HyperLink = "";
            this.PMKHN08650U_lbl3.Left = 1.625F;
            this.PMKHN08650U_lbl3.MultiLine = false;
            this.PMKHN08650U_lbl3.Name = "PMKHN08650U_lbl3";
            this.PMKHN08650U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl3.Text = "代替元品番";
            this.PMKHN08650U_lbl3.Top = 1.9375F;
            this.PMKHN08650U_lbl3.Width = 1.4375F;
            // 
            // PMKHN08650U_lbl4
            // 
            this.PMKHN08650U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl4.Height = 0.15F;
            this.PMKHN08650U_lbl4.HyperLink = "";
            this.PMKHN08650U_lbl4.Left = 3.1875F;
            this.PMKHN08650U_lbl4.MultiLine = false;
            this.PMKHN08650U_lbl4.Name = "PMKHN08650U_lbl4";
            this.PMKHN08650U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl4.Text = "代替先メーカー";
            this.PMKHN08650U_lbl4.Top = 1.9375F;
            this.PMKHN08650U_lbl4.Width = 1.1875F;
            // 
            // PMKHN08650U_lbl5
            // 
            this.PMKHN08650U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl5.Height = 0.15F;
            this.PMKHN08650U_lbl5.HyperLink = "";
            this.PMKHN08650U_lbl5.Left = 4.8125F;
            this.PMKHN08650U_lbl5.MultiLine = false;
            this.PMKHN08650U_lbl5.Name = "PMKHN08650U_lbl5";
            this.PMKHN08650U_lbl5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl5.Text = "代替先品番";
            this.PMKHN08650U_lbl5.Top = 1.9375F;
            this.PMKHN08650U_lbl5.Width = 1.4375F;
            // 
            // PMKHN08650U_lbl6
            // 
            this.PMKHN08650U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl6.Height = 0.15F;
            this.PMKHN08650U_lbl6.HyperLink = "";
            this.PMKHN08650U_lbl6.Left = 6.4375F;
            this.PMKHN08650U_lbl6.MultiLine = false;
            this.PMKHN08650U_lbl6.Name = "PMKHN08650U_lbl6";
            this.PMKHN08650U_lbl6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl6.Text = "適用開始日";
            this.PMKHN08650U_lbl6.Top = 1.9375F;
            this.PMKHN08650U_lbl6.Width = 0.6875001F;
            // 
            // PMKHN08650U_lbl7
            // 
            this.PMKHN08650U_lbl7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08650U_lbl7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08650U_lbl7.Height = 0.15F;
            this.PMKHN08650U_lbl7.HyperLink = "";
            this.PMKHN08650U_lbl7.Left = 7.25F;
            this.PMKHN08650U_lbl7.MultiLine = false;
            this.PMKHN08650U_lbl7.Name = "PMKHN08650U_lbl7";
            this.PMKHN08650U_lbl7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08650U_lbl7.Text = "適用終了日";
            this.PMKHN08650U_lbl7.Top = 1.9375F;
            this.PMKHN08650U_lbl7.Width = 0.6875001F;
            // 
            // PMKHN08640U_lbl1
            // 
            this.PMKHN08640U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl1.Height = 0.15F;
            this.PMKHN08640U_lbl1.HyperLink = "";
            this.PMKHN08640U_lbl1.Left = 0F;
            this.PMKHN08640U_lbl1.MultiLine = false;
            this.PMKHN08640U_lbl1.Name = "PMKHN08640U_lbl1";
            this.PMKHN08640U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08640U_lbl1.Top = 1.75F;
            this.PMKHN08640U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08640U_lbl2
            // 
            this.PMKHN08640U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl2.Height = 0.15F;
            this.PMKHN08640U_lbl2.HyperLink = "";
            this.PMKHN08640U_lbl2.Left = 0.3125F;
            this.PMKHN08640U_lbl2.MultiLine = false;
            this.PMKHN08640U_lbl2.Name = "PMKHN08640U_lbl2";
            this.PMKHN08640U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl2.Text = "名称";
            this.PMKHN08640U_lbl2.Top = 1.75F;
            this.PMKHN08640U_lbl2.Width = 1F;
            // 
            // PMKHN08640U_lbl3
            // 
            this.PMKHN08640U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl3.Height = 0.15F;
            this.PMKHN08640U_lbl3.HyperLink = "";
            this.PMKHN08640U_lbl3.Left = 1.625F;
            this.PMKHN08640U_lbl3.MultiLine = false;
            this.PMKHN08640U_lbl3.Name = "PMKHN08640U_lbl3";
            this.PMKHN08640U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl3.Text = "結合元品番";
            this.PMKHN08640U_lbl3.Top = 1.75F;
            this.PMKHN08640U_lbl3.Width = 1.4375F;
            // 
            // PMKHN08640U_lbl4
            // 
            this.PMKHN08640U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl4.Height = 0.15F;
            this.PMKHN08640U_lbl4.HyperLink = "";
            this.PMKHN08640U_lbl4.Left = 3.1875F;
            this.PMKHN08640U_lbl4.MultiLine = false;
            this.PMKHN08640U_lbl4.Name = "PMKHN08640U_lbl4";
            this.PMKHN08640U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl4.Text = "品名";
            this.PMKHN08640U_lbl4.Top = 1.75F;
            this.PMKHN08640U_lbl4.Width = 2F;
            // 
            // PMKHN08640U_lbl5
            // 
            this.PMKHN08640U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl5.Height = 0.15F;
            this.PMKHN08640U_lbl5.HyperLink = "";
            this.PMKHN08640U_lbl5.Left = 5.625F;
            this.PMKHN08640U_lbl5.MultiLine = false;
            this.PMKHN08640U_lbl5.Name = "PMKHN08640U_lbl5";
            this.PMKHN08640U_lbl5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl5.Text = "順位";
            this.PMKHN08640U_lbl5.Top = 1.75F;
            this.PMKHN08640U_lbl5.Width = 0.3124997F;
            // 
            // PMKHN08640U_lbl6
            // 
            this.PMKHN08640U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl6.Height = 0.15F;
            this.PMKHN08640U_lbl6.HyperLink = "";
            this.PMKHN08640U_lbl6.Left = 6F;
            this.PMKHN08640U_lbl6.MultiLine = false;
            this.PMKHN08640U_lbl6.Name = "PMKHN08640U_lbl6";
            this.PMKHN08640U_lbl6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl6.Text = "結合先品番";
            this.PMKHN08640U_lbl6.Top = 1.75F;
            this.PMKHN08640U_lbl6.Width = 1.4375F;
            // 
            // PMKHN08640U_lbl7
            // 
            this.PMKHN08640U_lbl7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl7.Height = 0.15F;
            this.PMKHN08640U_lbl7.HyperLink = "";
            this.PMKHN08640U_lbl7.Left = 7.5625F;
            this.PMKHN08640U_lbl7.MultiLine = false;
            this.PMKHN08640U_lbl7.Name = "PMKHN08640U_lbl7";
            this.PMKHN08640U_lbl7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl7.Text = "メーカー";
            this.PMKHN08640U_lbl7.Top = 1.75F;
            this.PMKHN08640U_lbl7.Width = 1F;
            // 
            // PMKHN08640U_lbl8
            // 
            this.PMKHN08640U_lbl8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08640U_lbl8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08640U_lbl8.Height = 0.15F;
            this.PMKHN08640U_lbl8.HyperLink = "";
            this.PMKHN08640U_lbl8.Left = 9.1875F;
            this.PMKHN08640U_lbl8.MultiLine = false;
            this.PMKHN08640U_lbl8.Name = "PMKHN08640U_lbl8";
            this.PMKHN08640U_lbl8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08640U_lbl8.Text = "QTY";
            this.PMKHN08640U_lbl8.Top = 1.75F;
            this.PMKHN08640U_lbl8.Width = 0.38F;
            // 
            // PMKHN08660U_lbl1
            // 
            this.PMKHN08660U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl1.Height = 0.15F;
            this.PMKHN08660U_lbl1.HyperLink = "";
            this.PMKHN08660U_lbl1.Left = 0F;
            this.PMKHN08660U_lbl1.MultiLine = false;
            this.PMKHN08660U_lbl1.Name = "PMKHN08660U_lbl1";
            this.PMKHN08660U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08660U_lbl1.Top = 2.1875F;
            this.PMKHN08660U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08660U_lbl2
            // 
            this.PMKHN08660U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl2.Height = 0.15F;
            this.PMKHN08660U_lbl2.HyperLink = "";
            this.PMKHN08660U_lbl2.Left = 0.3125F;
            this.PMKHN08660U_lbl2.MultiLine = false;
            this.PMKHN08660U_lbl2.Name = "PMKHN08660U_lbl2";
            this.PMKHN08660U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl2.Text = "名称";
            this.PMKHN08660U_lbl2.Top = 2.1875F;
            this.PMKHN08660U_lbl2.Width = 1.1875F;
            // 
            // PMKHN08660U_lbl3
            // 
            this.PMKHN08660U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl3.Height = 0.15F;
            this.PMKHN08660U_lbl3.HyperLink = "";
            this.PMKHN08660U_lbl3.Left = 1.625F;
            this.PMKHN08660U_lbl3.MultiLine = false;
            this.PMKHN08660U_lbl3.Name = "PMKHN08660U_lbl3";
            this.PMKHN08660U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl3.Text = "セット品番";
            this.PMKHN08660U_lbl3.Top = 2.1875F;
            this.PMKHN08660U_lbl3.Width = 0.8125001F;
            // 
            // PMKHN08660U_lbl4
            // 
            this.PMKHN08660U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl4.Height = 0.15F;
            this.PMKHN08660U_lbl4.HyperLink = "";
            this.PMKHN08660U_lbl4.Left = 3.1875F;
            this.PMKHN08660U_lbl4.MultiLine = false;
            this.PMKHN08660U_lbl4.Name = "PMKHN08660U_lbl4";
            this.PMKHN08660U_lbl4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl4.Text = "順位";
            this.PMKHN08660U_lbl4.Top = 2.1875F;
            this.PMKHN08660U_lbl4.Width = 0.3124997F;
            // 
            // PMKHN08660U_lbl5
            // 
            this.PMKHN08660U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl5.Height = 0.15F;
            this.PMKHN08660U_lbl5.HyperLink = "";
            this.PMKHN08660U_lbl5.Left = 3.6875F;
            this.PMKHN08660U_lbl5.MultiLine = false;
            this.PMKHN08660U_lbl5.Name = "PMKHN08660U_lbl5";
            this.PMKHN08660U_lbl5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl5.Text = "単品品番";
            this.PMKHN08660U_lbl5.Top = 2.1875F;
            this.PMKHN08660U_lbl5.Width = 0.8125001F;
            // 
            // PMKHN08660U_lbl6
            // 
            this.PMKHN08660U_lbl6.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl6.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl6.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl6.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl6.Height = 0.15F;
            this.PMKHN08660U_lbl6.HyperLink = "";
            this.PMKHN08660U_lbl6.Left = 5.1875F;
            this.PMKHN08660U_lbl6.MultiLine = false;
            this.PMKHN08660U_lbl6.Name = "PMKHN08660U_lbl6";
            this.PMKHN08660U_lbl6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl6.Text = "品名";
            this.PMKHN08660U_lbl6.Top = 2.1875F;
            this.PMKHN08660U_lbl6.Width = 2.25F;
            // 
            // PMKHN08660U_lbl7
            // 
            this.PMKHN08660U_lbl7.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl7.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl7.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl7.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl7.Height = 0.15F;
            this.PMKHN08660U_lbl7.HyperLink = "";
            this.PMKHN08660U_lbl7.Left = 7.5625F;
            this.PMKHN08660U_lbl7.MultiLine = false;
            this.PMKHN08660U_lbl7.Name = "PMKHN08660U_lbl7";
            this.PMKHN08660U_lbl7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl7.Text = "メーカー";
            this.PMKHN08660U_lbl7.Top = 2.1875F;
            this.PMKHN08660U_lbl7.Width = 1.1875F;
            // 
            // PMKHN08660U_lbl8
            // 
            this.PMKHN08660U_lbl8.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl8.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl8.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl8.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl8.Height = 0.15F;
            this.PMKHN08660U_lbl8.HyperLink = "";
            this.PMKHN08660U_lbl8.Left = 9.1875F;
            this.PMKHN08660U_lbl8.MultiLine = false;
            this.PMKHN08660U_lbl8.Name = "PMKHN08660U_lbl8";
            this.PMKHN08660U_lbl8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl8.Text = "QTY";
            this.PMKHN08660U_lbl8.Top = 2.1875F;
            this.PMKHN08660U_lbl8.Width = 0.38F;
            // 
            // PMKHN08660U_lbl9
            // 
            this.PMKHN08660U_lbl9.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl9.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl9.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl9.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08660U_lbl9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08660U_lbl9.Height = 0.15F;
            this.PMKHN08660U_lbl9.HyperLink = "";
            this.PMKHN08660U_lbl9.Left = 0.3125F;
            this.PMKHN08660U_lbl9.MultiLine = false;
            this.PMKHN08660U_lbl9.Name = "PMKHN08660U_lbl9";
            this.PMKHN08660U_lbl9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08660U_lbl9.Text = "規格・特記事項";
            this.PMKHN08660U_lbl9.Top = 2.375F;
            this.PMKHN08660U_lbl9.Width = 3.9375F;
            // 
            // PMKHN08670U_lbl2
            // 
            this.PMKHN08670U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl2.Height = 0.15F;
            this.PMKHN08670U_lbl2.HyperLink = "";
            this.PMKHN08670U_lbl2.Left = 0.6875F;
            this.PMKHN08670U_lbl2.MultiLine = false;
            this.PMKHN08670U_lbl2.Name = "PMKHN08670U_lbl2";
            this.PMKHN08670U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08670U_lbl2.Text = "名称";
            this.PMKHN08670U_lbl2.Top = 2.625F;
            this.PMKHN08670U_lbl2.Width = 1.75F;
            // 
            // PMKHN08670U_lbl1
            // 
            this.PMKHN08670U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl1.Height = 0.15F;
            this.PMKHN08670U_lbl1.HyperLink = "";
            this.PMKHN08670U_lbl1.Left = 0F;
            this.PMKHN08670U_lbl1.MultiLine = false;
            this.PMKHN08670U_lbl1.Name = "PMKHN08670U_lbl1";
            this.PMKHN08670U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08670U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08670U_lbl1.Top = 2.625F;
            this.PMKHN08670U_lbl1.Width = 0.6875F;
            // 
            // PMKHN08670U_lbl3
            // 
            this.PMKHN08670U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl3.Height = 0.15F;
            this.PMKHN08670U_lbl3.HyperLink = "";
            this.PMKHN08670U_lbl3.Left = 2.5625F;
            this.PMKHN08670U_lbl3.MultiLine = false;
            this.PMKHN08670U_lbl3.Name = "PMKHN08670U_lbl3";
            this.PMKHN08670U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08670U_lbl3.Text = "カナ";
            this.PMKHN08670U_lbl3.Top = 2.625F;
            this.PMKHN08670U_lbl3.Width = 3.375F;
            // 
            // PMKHN08670U_lbl4
            // 
            this.PMKHN08670U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08670U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08670U_lbl4.Height = 0.15F;
            this.PMKHN08670U_lbl4.HyperLink = "";
            this.PMKHN08670U_lbl4.Left = 6.0625F;
            this.PMKHN08670U_lbl4.MultiLine = false;
            this.PMKHN08670U_lbl4.Name = "PMKHN08670U_lbl4";
            this.PMKHN08670U_lbl4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08670U_lbl4.Text = "呼び名";
            this.PMKHN08670U_lbl4.Top = 2.625F;
            this.PMKHN08670U_lbl4.Width = 1.75F;
            // 
            // PMKHN08680U_lbl1
            // 
            this.PMKHN08680U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl1.Height = 0.15F;
            this.PMKHN08680U_lbl1.HyperLink = "";
            this.PMKHN08680U_lbl1.Left = 0F;
            this.PMKHN08680U_lbl1.MultiLine = false;
            this.PMKHN08680U_lbl1.Name = "PMKHN08680U_lbl1";
            this.PMKHN08680U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08680U_lbl1.Text = "得意先";
            this.PMKHN08680U_lbl1.Top = 2.8125F;
            this.PMKHN08680U_lbl1.Width = 3F;
            // 
            // PMKHN08680U_lbl2
            // 
            this.PMKHN08680U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl2.Height = 0.15F;
            this.PMKHN08680U_lbl2.HyperLink = "";
            this.PMKHN08680U_lbl2.Left = 3.625F;
            this.PMKHN08680U_lbl2.MultiLine = false;
            this.PMKHN08680U_lbl2.Name = "PMKHN08680U_lbl2";
            this.PMKHN08680U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08680U_lbl2.Text = "ｺｰﾄﾞ";
            this.PMKHN08680U_lbl2.Top = 2.8125F;
            this.PMKHN08680U_lbl2.Width = 0.3124997F;
            // 
            // PMKHN08680U_lbl3
            // 
            this.PMKHN08680U_lbl3.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl3.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl3.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl3.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl3.Height = 0.15F;
            this.PMKHN08680U_lbl3.HyperLink = "";
            this.PMKHN08680U_lbl3.Left = 3.937499F;
            this.PMKHN08680U_lbl3.MultiLine = false;
            this.PMKHN08680U_lbl3.Name = "PMKHN08680U_lbl3";
            this.PMKHN08680U_lbl3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08680U_lbl3.Text = "名称";
            this.PMKHN08680U_lbl3.Top = 2.8125F;
            this.PMKHN08680U_lbl3.Width = 3F;
            // 
            // PMKHN08680U_lbl4
            // 
            this.PMKHN08680U_lbl4.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl4.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl4.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl4.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl4.Height = 0.15F;
            this.PMKHN08680U_lbl4.HyperLink = "";
            this.PMKHN08680U_lbl4.Left = 6.925F;
            this.PMKHN08680U_lbl4.MultiLine = false;
            this.PMKHN08680U_lbl4.Name = "PMKHN08680U_lbl4";
            this.PMKHN08680U_lbl4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08680U_lbl4.Text = "表示順位";
            this.PMKHN08680U_lbl4.Top = 2.8125F;
            this.PMKHN08680U_lbl4.Width = 0.45F;
            // 
            // PMKHN08680U_lbl5
            // 
            this.PMKHN08680U_lbl5.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl5.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl5.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl5.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08680U_lbl5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08680U_lbl5.Height = 0.15F;
            this.PMKHN08680U_lbl5.HyperLink = "";
            this.PMKHN08680U_lbl5.Left = 7.4375F;
            this.PMKHN08680U_lbl5.MultiLine = false;
            this.PMKHN08680U_lbl5.Name = "PMKHN08680U_lbl5";
            this.PMKHN08680U_lbl5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08680U_lbl5.Text = "ＢＬコード";
            this.PMKHN08680U_lbl5.Top = 2.8125F;
            this.PMKHN08680U_lbl5.Width = 1F;
            // 
            // PMKHN08590U_lbl1
            // 
            this.PMKHN08590U_lbl1.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl1.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl1.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl1.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl1.Height = 0.15F;
            this.PMKHN08590U_lbl1.HyperLink = "";
            this.PMKHN08590U_lbl1.Left = 0F;
            this.PMKHN08590U_lbl1.MultiLine = false;
            this.PMKHN08590U_lbl1.Name = "PMKHN08590U_lbl1";
            this.PMKHN08590U_lbl1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08590U_lbl1.Text = "ｺｰﾄﾞ";
            this.PMKHN08590U_lbl1.Top = 1.125F;
            this.PMKHN08590U_lbl1.Width = 0.3125F;
            // 
            // PMKHN08590U_lbl2
            // 
            this.PMKHN08590U_lbl2.Border.BottomColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl2.Border.LeftColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl2.Border.RightColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl2.Border.TopColor = System.Drawing.Color.Black;
            this.PMKHN08590U_lbl2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PMKHN08590U_lbl2.Height = 0.15F;
            this.PMKHN08590U_lbl2.HyperLink = "";
            this.PMKHN08590U_lbl2.Left = 0.3125F;
            this.PMKHN08590U_lbl2.MultiLine = false;
            this.PMKHN08590U_lbl2.Name = "PMKHN08590U_lbl2";
            this.PMKHN08590U_lbl2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.PMKHN08590U_lbl2.Text = "名称";
            this.PMKHN08590U_lbl2.Top = 1.125F;
            this.PMKHN08590U_lbl2.Width = 3.375F;
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
            this.line6.Top = 0.4270833F;
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0.4270833F;
            this.line6.Y2 = 0.4270833F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0.006510417F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08504P_01A4C
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
            this.PrintWidth = 10.83654F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
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
            this.PageEnd += new System.EventHandler(this.PMKHN08504P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08504P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_txt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_txt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_txt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_txt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08510U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08530U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08540U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08570U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08580U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08600U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08620U_lbl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08650U_lbl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08640U_lbl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08660U_lbl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08670U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08680U_lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PMKHN08590U_lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
