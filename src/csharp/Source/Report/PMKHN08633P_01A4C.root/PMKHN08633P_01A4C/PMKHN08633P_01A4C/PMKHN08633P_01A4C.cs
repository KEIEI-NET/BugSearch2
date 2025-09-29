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
	/// 売上目標設定マスタ（印刷）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 売上目標設定マスタ（印刷）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN08633P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 売上目標設定マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 売上目標設定マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08633P_01A4C()
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

        private SalesTargetPrintWork _salesTargetPrintWork;                   // 抽出条件クラス
        
		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label label1;
        private TextBox sectioncode;
        private TextBox sectionguidesnm;
        private Line line2;
        private Line line3;
        private Label lbl_Name;
        private Label lbl_Month1;
        private TextBox salestargetmoney1;
        private TextBox subsectioncode;
        private TextBox subsectionname;
        private TextBox salestargetmoney2;
        private TextBox salestargetmoney3;
        private TextBox salestargetmoney4;
        private TextBox salestargetmoney5;
        private TextBox salestargetmoney6;
        private TextBox salestargetmoney7;
        private TextBox salestargetmoney8;
        private TextBox salestargetmoney9;
        private TextBox salestargetmoney10;
        private TextBox salestargetmoney11;
        private TextBox salestargetmoney12;
        private TextBox salestargetmoneyall;
        private Label lbl_Month2;
        private Label lbl_Month3;
        private Label lbl_Month4;
        private Label lbl_Month5;
        private Label lbl_Month6;
        private Label lbl_Month7;
        private Label lbl_Month8;
        private Label lbl_Month9;
        private Line line4;
        private TextBox salestargetprofit1;
        private TextBox salestargetprofit2;
        private TextBox salestargetprofit3;
        private TextBox salestargetprofit4;
        private TextBox salestargetprofit5;
        private TextBox salestargetprofit6;
        private TextBox salestargetprofit7;
        private TextBox salestargetprofit8;
        private TextBox salestargetprofit9;
        private TextBox salestargetprofit10;
        private TextBox salestargetprofit11;
        private TextBox salestargetprofit12;
        private TextBox salestargetprofitall;
        private Label lbl_Month10;
        private Label lbl_Month11;
        private Label lbl_Month12;
        private Label label4;
        private TextBox salesemployeecd;
        private TextBox salesemployeenm;
        private TextBox frontemployeecd;
        private TextBox frontemployeenm;
        private TextBox salesinputcode;
        private TextBox salesinputname;
        private TextBox salescode;
        private TextBox salescodename;
        private TextBox enterpriseganrecode;
        private TextBox enterpriseganrecodename;
        private TextBox customercode;
        private TextBox customersnm;
        private TextBox businesstypecode;
        private TextBox businesstypecodename;
        private TextBox salesareacode;
        private TextBox salesareacodename;

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
                this._salesTargetPrintWork = (SalesTargetPrintWork)this._printInfo.jyoken;
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
				// TODO:  PMKHN08633P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08633P_01A4C.WatermarkMode setter 実装を追加します。
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
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            #region 売上・粗利表示設定
            switch  ((int)this._salesTargetPrintWork.PrintDiv)
            {
                case 0:
                    this.line3.Visible = true;
                    this.line4.Visible = false;

                    this.salestargetmoney1.Visible = true;
                    this.salestargetmoney2.Visible = true;
                    this.salestargetmoney3.Visible = true;
                    this.salestargetmoney4.Visible = true;
                    this.salestargetmoney5.Visible = true;
                    this.salestargetmoney6.Visible = true;
                    this.salestargetmoney7.Visible = true;
                    this.salestargetmoney8.Visible = true;
                    this.salestargetmoney9.Visible = true;
                    this.salestargetmoney10.Visible = true;
                    this.salestargetmoney11.Visible = true;
                    this.salestargetmoney12.Visible = true;
                    this.salestargetmoneyall.Visible = true;

                    this.salestargetprofit1.Visible = false;
                    this.salestargetprofit2.Visible = false;
                    this.salestargetprofit3.Visible = false;
                    this.salestargetprofit4.Visible = false;
                    this.salestargetprofit5.Visible = false;
                    this.salestargetprofit6.Visible = false;
                    this.salestargetprofit7.Visible = false;
                    this.salestargetprofit8.Visible = false;
                    this.salestargetprofit9.Visible = false;
                    this.salestargetprofit10.Visible = false;
                    this.salestargetprofit11.Visible = false;
                    this.salestargetprofit12.Visible = false;
                    this.salestargetprofitall.Visible = false;

                    break;
                case 1:
                    this.line3.Visible = true;
                    this.line4.Visible = false;
                    this.salestargetprofit1.Top = this.sectioncode.Top;
                    this.salestargetprofit2.Top = this.sectioncode.Top;
                    this.salestargetprofit3.Top = this.sectioncode.Top;
                    this.salestargetprofit4.Top = this.sectioncode.Top;
                    this.salestargetprofit5.Top = this.sectioncode.Top;
                    this.salestargetprofit6.Top = this.sectioncode.Top;
                    this.salestargetprofit7.Top = this.sectioncode.Top;
                    this.salestargetprofit8.Top = this.sectioncode.Top;
                    this.salestargetprofit9.Top = this.sectioncode.Top;
                    this.salestargetprofit10.Top = this.sectioncode.Top;
                    this.salestargetprofit11.Top = this.sectioncode.Top;
                    this.salestargetprofit12.Top = this.sectioncode.Top;
                    this.salestargetprofitall.Top = this.sectioncode.Top;


                    this.salestargetmoney1.Visible = false;
                    this.salestargetmoney2.Visible = false;
                    this.salestargetmoney3.Visible = false;
                    this.salestargetmoney4.Visible = false;
                    this.salestargetmoney5.Visible = false;
                    this.salestargetmoney6.Visible = false;
                    this.salestargetmoney7.Visible = false;
                    this.salestargetmoney8.Visible = false;
                    this.salestargetmoney9.Visible = false;
                    this.salestargetmoney10.Visible = false;
                    this.salestargetmoney11.Visible = false;
                    this.salestargetmoney12.Visible = false;
                    this.salestargetmoneyall.Visible = false;

                    this.salestargetprofit1.Visible = true;
                    this.salestargetprofit2.Visible = true;
                    this.salestargetprofit3.Visible = true;
                    this.salestargetprofit4.Visible = true;
                    this.salestargetprofit5.Visible = true;
                    this.salestargetprofit6.Visible = true;
                    this.salestargetprofit7.Visible = true;
                    this.salestargetprofit8.Visible = true;
                    this.salestargetprofit9.Visible = true;
                    this.salestargetprofit10.Visible = true;
                    this.salestargetprofit11.Visible = true;
                    this.salestargetprofit12.Visible = true;
                    this.salestargetprofitall.Visible = true;
                    break;
                case 2:
                    this.line3.Visible = false;
                    this.line4.Visible = true;

                    this.salestargetmoney1.Visible = true;
                    this.salestargetmoney2.Visible = true;
                    this.salestargetmoney3.Visible = true;
                    this.salestargetmoney4.Visible = true;
                    this.salestargetmoney5.Visible = true;
                    this.salestargetmoney6.Visible = true;
                    this.salestargetmoney7.Visible = true;
                    this.salestargetmoney8.Visible = true;
                    this.salestargetmoney9.Visible = true;
                    this.salestargetmoney10.Visible = true;
                    this.salestargetmoney11.Visible = true;
                    this.salestargetmoney12.Visible = true;
                    this.salestargetmoneyall.Visible = true;

                    this.salestargetprofit1.Visible = true;
                    this.salestargetprofit2.Visible = true;
                    this.salestargetprofit3.Visible = true;
                    this.salestargetprofit4.Visible = true;
                    this.salestargetprofit5.Visible = true;
                    this.salestargetprofit6.Visible = true;
                    this.salestargetprofit7.Visible = true;
                    this.salestargetprofit8.Visible = true;
                    this.salestargetprofit9.Visible = true;
                    this.salestargetprofit10.Visible = true;
                    this.salestargetprofit11.Visible = true;
                    this.salestargetprofit12.Visible = true;
                    this.salestargetprofitall.Visible = true;
                    break;
            }
            #endregion

            #region サブ名称設定
            switch ((int)this._salesTargetPrintWork.PrintType)
            {
                case 0: //拠点 
                    this.lbl_Name.Visible = false;
                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 1: //拠点-部門
                    this.lbl_Name.Text = "部門"; 
                    this.lbl_Name.Visible = true;
                    this.subsectioncode.Visible = true;
                    this.subsectionname.Visible = true;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 2: //拠点-担当者 
                    this.lbl_Name.Text = "担当者"; 
                    this.lbl_Name.Visible = true;
                    this.salesemployeecd.Top = this.sectioncode.Top;
                    this.salesemployeenm.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = true;
                    this.salesemployeenm.Visible = true;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 3: //拠点-受注者 
                    this.lbl_Name.Text = "受注者";
                    this.lbl_Name.Visible = true;
                    this.frontemployeecd.Top = this.sectioncode.Top;
                    this.frontemployeenm.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = true;
                    this.frontemployeenm.Visible = true;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 4: //拠点-発行者 
                    this.lbl_Name.Text = "発行者";
                    this.lbl_Name.Visible = true;
                    this.salesinputcode.Top = this.sectioncode.Top;
                    this.salesinputname.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = true;
                    this.salesinputname.Visible = true;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 5: //拠点-販売区分 
                    this.lbl_Name.Text = "販売区分";
                    this.lbl_Name.Visible = true;
                    this.salescode.Top = this.sectioncode.Top;
                    this.salescodename.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = true;
                    this.salescodename.Visible = true;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 6: //拠点-商品区分 
                    this.lbl_Name.Text = "商品区分";
                    this.lbl_Name.Visible = true;
                    this.enterpriseganrecode.Top = this.sectioncode.Top;
                    this.enterpriseganrecodename.Top = this.sectioncode.Top;

                    // ADD 2008/12/02 不具合対応[8535] ---------->>>>>
                    this.label1.Visible = false;
                    this.sectioncode.Visible = false;
                    this.sectionguidesnm.Visible = false;

                    this.lbl_Name.Left = this.label1.Left;
                    this.enterpriseganrecode.Left = this.sectioncode.Left;
                    this.enterpriseganrecodename.Left = this.sectionguidesnm.Left;
                    // ADD 2008/12/02 不具合対応[8535] ----------<<<<<

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = true;
                    this.enterpriseganrecodename.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 7: //拠点-得意先 
                    this.lbl_Name.Text = "得意先";
                    this.lbl_Name.Visible = true;
                    this.customercode.Top = this.sectioncode.Top;
                    this.customersnm.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = true;
                    this.customersnm.Visible = true;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 8: //拠点-業種  
                    this.lbl_Name.Text = "業種";
                    this.lbl_Name.Visible = true;
                    this.businesstypecode.Top = this.sectioncode.Top;
                    this.businesstypecodename.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = true;
                    this.businesstypecodename.Visible = true;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    break;
                case 9: //拠点-地区 
                    this.lbl_Name.Text = "地区";
                    this.lbl_Name.Visible = true;
                    this.salesareacode.Top = this.sectioncode.Top;
                    this.salesareacodename.Top = this.sectioncode.Top;

                    this.subsectioncode.Visible = false;
                    this.subsectionname.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    this.enterpriseganrecode.Visible = false;
                    this.enterpriseganrecodename.Visible = false;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypecodename.Visible = false;
                    this.salesareacode.Visible = true;
                    this.salesareacodename.Visible = true;
                    break;
            }
            #endregion

            #region 年月設定
            DateTime startMonth = DateTime.Parse(this._salesTargetPrintWork.TargetDivideCodeSt.ToString().Substring(0, 4) + "/" +
                                                 this._salesTargetPrintWork.TargetDivideCodeSt.ToString().Substring(4, 2) + "/01");
            DateTime endMonth = DateTime.Parse(this._salesTargetPrintWork.TargetDivideCodeEd.ToString().Substring(0, 4) + "/" +
                                               this._salesTargetPrintWork.TargetDivideCodeEd.ToString().Substring(4, 2) + "/01");

            this.lbl_Month1.Text = startMonth.Month + "月";
            if (startMonth.AddMonths(1) <= endMonth)
            {
                this.lbl_Month2.Text = startMonth.AddMonths(1).Month + "月";
            }
            else
            {
                this.lbl_Month2.Visible = false;
                this.lbl_Month3.Visible = false;
                this.lbl_Month4.Visible = false;
                this.lbl_Month5.Visible = false;
                this.lbl_Month6.Visible = false;
                this.lbl_Month7.Visible = false;
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney2.Visible = false;
                this.salestargetmoney3.Visible = false;
                this.salestargetmoney4.Visible = false;
                this.salestargetmoney5.Visible = false;
                this.salestargetmoney6.Visible = false;
                this.salestargetmoney7.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit2.Visible = false;
                this.salestargetprofit3.Visible = false;
                this.salestargetprofit4.Visible = false;
                this.salestargetprofit5.Visible = false;
                this.salestargetprofit6.Visible = false;
                this.salestargetprofit7.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
                if (startMonth.AddMonths(2) <= endMonth)
            {
                this.lbl_Month3.Text = startMonth.AddMonths(2).Month + "月";
            }
            else
            {
                this.lbl_Month3.Visible = false;
                this.lbl_Month4.Visible = false;
                this.lbl_Month5.Visible = false;
                this.lbl_Month6.Visible = false;
                this.lbl_Month7.Visible = false;
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney3.Visible = false;
                this.salestargetmoney4.Visible = false;
                this.salestargetmoney5.Visible = false;
                this.salestargetmoney6.Visible = false;
                this.salestargetmoney7.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit3.Visible = false;
                this.salestargetprofit4.Visible = false;
                this.salestargetprofit5.Visible = false;
                this.salestargetprofit6.Visible = false;
                this.salestargetprofit7.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(3) <= endMonth)
            {
                this.lbl_Month4.Text = startMonth.AddMonths(3).Month + "月";
            }
            else
            {
                this.lbl_Month4.Visible = false;
                this.lbl_Month5.Visible = false;
                this.lbl_Month6.Visible = false;
                this.lbl_Month7.Visible = false;
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney4.Visible = false;
                this.salestargetmoney5.Visible = false;
                this.salestargetmoney6.Visible = false;
                this.salestargetmoney7.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit4.Visible = false;
                this.salestargetprofit5.Visible = false;
                this.salestargetprofit6.Visible = false;
                this.salestargetprofit7.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(4) <= endMonth)
            {
                this.lbl_Month5.Text = startMonth.AddMonths(4).Month + "月";
            }
            else
            {
                this.lbl_Month5.Visible = false;
                this.lbl_Month6.Visible = false;
                this.lbl_Month7.Visible = false;
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney5.Visible = false;
                this.salestargetmoney6.Visible = false;
                this.salestargetmoney7.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit5.Visible = false;
                this.salestargetprofit6.Visible = false;
                this.salestargetprofit7.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(5) <= endMonth)
            {
                this.lbl_Month6.Text = startMonth.AddMonths(5).Month + "月";
            }
            else
            {
                this.lbl_Month6.Visible = false;
                this.lbl_Month7.Visible = false;
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney6.Visible = false;
                this.salestargetmoney7.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit6.Visible = false;
                this.salestargetprofit7.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(6) <= endMonth)
            {
                this.lbl_Month7.Text = startMonth.AddMonths(6).Month + "月";
            }
            else
            {
                this.lbl_Month7.Visible = false;
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney7.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit7.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(7) <= endMonth)
            {
                this.lbl_Month8.Text = startMonth.AddMonths(7).Month + "月";
            }
            else
            {
                this.lbl_Month8.Visible = false;
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney8.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit8.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(8) <= endMonth)
            {
                this.lbl_Month9.Text = startMonth.AddMonths(8).Month + "月";
            }
            else
            {
                this.lbl_Month9.Visible = false;
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney9.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit9.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(9) <= endMonth)
            {
                this.lbl_Month10.Text = startMonth.AddMonths(9).Month + "月";
            }
            else
            {
                this.lbl_Month10.Visible = false;
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney10.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit10.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(10) <= endMonth)
            {
                this.lbl_Month11.Text = startMonth.AddMonths(10).Month + "月";
            }
            else
            {
                this.lbl_Month11.Visible = false;
                this.lbl_Month12.Visible = false;
                this.salestargetmoney11.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit11.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            if (startMonth.AddMonths(11) <= endMonth)
            {
                this.lbl_Month12.Text = startMonth.AddMonths(11).Month + "月";
            }
            else
            {
                this.lbl_Month12.Visible = false;
                this.salestargetmoney12.Visible = false;
                this.salestargetprofit12.Visible = false;
            }
            #endregion
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

		#region ◎ PMKHN08633P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08633P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08633P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08633P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08633P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08633P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08633P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08633P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.sectioncode = new DataDynamics.ActiveReports.TextBox();
            this.sectionguidesnm = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.salestargetmoney1 = new DataDynamics.ActiveReports.TextBox();
            this.subsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.subsectionname = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney2 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney3 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney4 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney5 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney6 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney7 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney8 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney9 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney10 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney11 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoney12 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetmoneyall = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.salestargetprofit1 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit2 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit3 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit4 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit5 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit6 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit7 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit8 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit9 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit10 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit11 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofit12 = new DataDynamics.ActiveReports.TextBox();
            this.salestargetprofitall = new DataDynamics.ActiveReports.TextBox();
            this.salesemployeecd = new DataDynamics.ActiveReports.TextBox();
            this.salesemployeenm = new DataDynamics.ActiveReports.TextBox();
            this.frontemployeecd = new DataDynamics.ActiveReports.TextBox();
            this.frontemployeenm = new DataDynamics.ActiveReports.TextBox();
            this.salesinputcode = new DataDynamics.ActiveReports.TextBox();
            this.salesinputname = new DataDynamics.ActiveReports.TextBox();
            this.salescode = new DataDynamics.ActiveReports.TextBox();
            this.salescodename = new DataDynamics.ActiveReports.TextBox();
            this.enterpriseganrecode = new DataDynamics.ActiveReports.TextBox();
            this.enterpriseganrecodename = new DataDynamics.ActiveReports.TextBox();
            this.customercode = new DataDynamics.ActiveReports.TextBox();
            this.customersnm = new DataDynamics.ActiveReports.TextBox();
            this.businesstypecode = new DataDynamics.ActiveReports.TextBox();
            this.businesstypecodename = new DataDynamics.ActiveReports.TextBox();
            this.salesareacode = new DataDynamics.ActiveReports.TextBox();
            this.salesareacodename = new DataDynamics.ActiveReports.TextBox();
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
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.lbl_Name = new DataDynamics.ActiveReports.Label();
            this.lbl_Month1 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month2 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month3 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month4 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month5 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month6 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month7 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month8 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month9 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month10 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month11 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month12 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.sectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidesnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsectionname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoneyall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofitall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesemployeecd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesemployeenm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontemployeecd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontemployeenm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesinputcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesinputname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salescode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salescodename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecodename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customercode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypecodename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareacode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareacodename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.sectioncode,
            this.sectionguidesnm,
            this.line3,
            this.salestargetmoney1,
            this.subsectioncode,
            this.subsectionname,
            this.salestargetmoney2,
            this.salestargetmoney3,
            this.salestargetmoney4,
            this.salestargetmoney5,
            this.salestargetmoney6,
            this.salestargetmoney7,
            this.salestargetmoney8,
            this.salestargetmoney9,
            this.salestargetmoney10,
            this.salestargetmoney11,
            this.salestargetmoney12,
            this.salestargetmoneyall,
            this.line4,
            this.salestargetprofit1,
            this.salestargetprofit2,
            this.salestargetprofit3,
            this.salestargetprofit4,
            this.salestargetprofit5,
            this.salestargetprofit6,
            this.salestargetprofit7,
            this.salestargetprofit8,
            this.salestargetprofit9,
            this.salestargetprofit10,
            this.salestargetprofit11,
            this.salestargetprofit12,
            this.salestargetprofitall,
            this.salesemployeecd,
            this.salesemployeenm,
            this.frontemployeecd,
            this.frontemployeenm,
            this.salesinputcode,
            this.salesinputname,
            this.salescode,
            this.salescodename,
            this.enterpriseganrecode,
            this.enterpriseganrecodename,
            this.customercode,
            this.customersnm,
            this.businesstypecode,
            this.businesstypecodename,
            this.salesareacode,
            this.salesareacodename});
            this.Detail.Height = 1.870833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // sectioncode
            // 
            this.sectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.sectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.sectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.sectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.sectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.DataField = "sectioncode";
            this.sectioncode.Height = 0.15F;
            this.sectioncode.Left = 0F;
            this.sectioncode.MultiLine = false;
            this.sectioncode.Name = "sectioncode";
            this.sectioncode.OutputFormat = resources.GetString("sectioncode.OutputFormat");
            this.sectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.sectioncode.Text = "1234";
            this.sectioncode.Top = 0.02083333F;
            this.sectioncode.Width = 0.3125F;
            // 
            // sectionguidesnm
            // 
            this.sectionguidesnm.Border.BottomColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.Border.LeftColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.Border.RightColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.Border.TopColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.DataField = "sectionguidesnm";
            this.sectionguidesnm.Height = 0.15F;
            this.sectionguidesnm.Left = 0.3125F;
            this.sectionguidesnm.MultiLine = false;
            this.sectionguidesnm.Name = "sectionguidesnm";
            this.sectionguidesnm.OutputFormat = resources.GetString("sectionguidesnm.OutputFormat");
            this.sectionguidesnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sectionguidesnm.Text = "あいうえおかきくけこ";
            this.sectionguidesnm.Top = 0.02083333F;
            this.sectionguidesnm.Width = 1.1875F;
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
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.1875F;
            this.line3.Y2 = 0.1875F;
            // 
            // salestargetmoney1
            // 
            this.salestargetmoney1.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney1.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney1.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney1.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney1.DataField = "salestargetmoney1";
            this.salestargetmoney1.Height = 0.15F;
            this.salestargetmoney1.Left = 3.197917F;
            this.salestargetmoney1.MultiLine = false;
            this.salestargetmoney1.Name = "salestargetmoney1";
            this.salestargetmoney1.OutputFormat = resources.GetString("salestargetmoney1.OutputFormat");
            this.salestargetmoney1.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney1.Text = "123,456,789";
            this.salestargetmoney1.Top = 0.02083333F;
            this.salestargetmoney1.Width = 0.5625F;
            // 
            // subsectioncode
            // 
            this.subsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.subsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.subsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.subsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.subsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectioncode.DataField = "subsectioncode";
            this.subsectioncode.Height = 0.15F;
            this.subsectioncode.Left = 1.5F;
            this.subsectioncode.MultiLine = false;
            this.subsectioncode.Name = "subsectioncode";
            this.subsectioncode.OutputFormat = resources.GetString("subsectioncode.OutputFormat");
            this.subsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.subsectioncode.Text = "12345678";
            this.subsectioncode.Top = 0.02083333F;
            this.subsectioncode.Width = 0.5F;
            // 
            // subsectionname
            // 
            this.subsectionname.Border.BottomColor = System.Drawing.Color.Black;
            this.subsectionname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.Border.LeftColor = System.Drawing.Color.Black;
            this.subsectionname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.Border.RightColor = System.Drawing.Color.Black;
            this.subsectionname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.Border.TopColor = System.Drawing.Color.Black;
            this.subsectionname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.DataField = "subsectionname";
            this.subsectionname.Height = 0.15F;
            this.subsectionname.Left = 2F;
            this.subsectionname.MultiLine = false;
            this.subsectionname.Name = "subsectionname";
            this.subsectionname.OutputFormat = resources.GetString("subsectionname.OutputFormat");
            this.subsectionname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.subsectionname.Text = "あいうえおかきくけこ";
            this.subsectionname.Top = 0.02083333F;
            this.subsectionname.Width = 1.1875F;
            // 
            // salestargetmoney2
            // 
            this.salestargetmoney2.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney2.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney2.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney2.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney2.DataField = "salestargetmoney2";
            this.salestargetmoney2.Height = 0.15F;
            this.salestargetmoney2.Left = 3.765152F;
            this.salestargetmoney2.MultiLine = false;
            this.salestargetmoney2.Name = "salestargetmoney2";
            this.salestargetmoney2.OutputFormat = resources.GetString("salestargetmoney2.OutputFormat");
            this.salestargetmoney2.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney2.Text = "123,456,789";
            this.salestargetmoney2.Top = 0.02083333F;
            this.salestargetmoney2.Width = 0.5625F;
            // 
            // salestargetmoney3
            // 
            this.salestargetmoney3.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney3.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney3.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney3.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney3.DataField = "salestargetmoney3";
            this.salestargetmoney3.Height = 0.15F;
            this.salestargetmoney3.Left = 4.332386F;
            this.salestargetmoney3.MultiLine = false;
            this.salestargetmoney3.Name = "salestargetmoney3";
            this.salestargetmoney3.OutputFormat = resources.GetString("salestargetmoney3.OutputFormat");
            this.salestargetmoney3.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney3.Text = "123,456,789";
            this.salestargetmoney3.Top = 0.02083333F;
            this.salestargetmoney3.Width = 0.5625F;
            // 
            // salestargetmoney4
            // 
            this.salestargetmoney4.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney4.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney4.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney4.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney4.DataField = "salestargetmoney4";
            this.salestargetmoney4.Height = 0.15F;
            this.salestargetmoney4.Left = 4.899621F;
            this.salestargetmoney4.MultiLine = false;
            this.salestargetmoney4.Name = "salestargetmoney4";
            this.salestargetmoney4.OutputFormat = resources.GetString("salestargetmoney4.OutputFormat");
            this.salestargetmoney4.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney4.Text = "123,456,789";
            this.salestargetmoney4.Top = 0.02083333F;
            this.salestargetmoney4.Width = 0.5625F;
            // 
            // salestargetmoney5
            // 
            this.salestargetmoney5.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney5.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney5.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney5.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney5.DataField = "salestargetmoney5";
            this.salestargetmoney5.Height = 0.15F;
            this.salestargetmoney5.Left = 5.466856F;
            this.salestargetmoney5.MultiLine = false;
            this.salestargetmoney5.Name = "salestargetmoney5";
            this.salestargetmoney5.OutputFormat = resources.GetString("salestargetmoney5.OutputFormat");
            this.salestargetmoney5.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney5.Text = "123,456,789";
            this.salestargetmoney5.Top = 0.02083333F;
            this.salestargetmoney5.Width = 0.5625F;
            // 
            // salestargetmoney6
            // 
            this.salestargetmoney6.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney6.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney6.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney6.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney6.DataField = "salestargetmoney6";
            this.salestargetmoney6.Height = 0.15F;
            this.salestargetmoney6.Left = 6.034091F;
            this.salestargetmoney6.MultiLine = false;
            this.salestargetmoney6.Name = "salestargetmoney6";
            this.salestargetmoney6.OutputFormat = resources.GetString("salestargetmoney6.OutputFormat");
            this.salestargetmoney6.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney6.Text = "123,456,789";
            this.salestargetmoney6.Top = 0.02083333F;
            this.salestargetmoney6.Width = 0.5625F;
            // 
            // salestargetmoney7
            // 
            this.salestargetmoney7.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney7.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney7.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney7.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney7.DataField = "salestargetmoney7";
            this.salestargetmoney7.Height = 0.15F;
            this.salestargetmoney7.Left = 6.601326F;
            this.salestargetmoney7.MultiLine = false;
            this.salestargetmoney7.Name = "salestargetmoney7";
            this.salestargetmoney7.OutputFormat = resources.GetString("salestargetmoney7.OutputFormat");
            this.salestargetmoney7.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney7.Text = "123,456,789";
            this.salestargetmoney7.Top = 0.02083333F;
            this.salestargetmoney7.Width = 0.5625F;
            // 
            // salestargetmoney8
            // 
            this.salestargetmoney8.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney8.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney8.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney8.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney8.DataField = "salestargetmoney8";
            this.salestargetmoney8.Height = 0.15F;
            this.salestargetmoney8.Left = 7.168561F;
            this.salestargetmoney8.MultiLine = false;
            this.salestargetmoney8.Name = "salestargetmoney8";
            this.salestargetmoney8.OutputFormat = resources.GetString("salestargetmoney8.OutputFormat");
            this.salestargetmoney8.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney8.Text = "123,456,789";
            this.salestargetmoney8.Top = 0.02083333F;
            this.salestargetmoney8.Width = 0.5625F;
            // 
            // salestargetmoney9
            // 
            this.salestargetmoney9.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney9.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney9.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney9.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney9.DataField = "salestargetmoney9";
            this.salestargetmoney9.Height = 0.15F;
            this.salestargetmoney9.Left = 7.735796F;
            this.salestargetmoney9.MultiLine = false;
            this.salestargetmoney9.Name = "salestargetmoney9";
            this.salestargetmoney9.OutputFormat = resources.GetString("salestargetmoney9.OutputFormat");
            this.salestargetmoney9.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney9.Text = "123,456,789";
            this.salestargetmoney9.Top = 0.02083333F;
            this.salestargetmoney9.Width = 0.5625F;
            // 
            // salestargetmoney10
            // 
            this.salestargetmoney10.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney10.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney10.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney10.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney10.DataField = "salestargetmoney10";
            this.salestargetmoney10.Height = 0.15F;
            this.salestargetmoney10.Left = 8.303031F;
            this.salestargetmoney10.MultiLine = false;
            this.salestargetmoney10.Name = "salestargetmoney10";
            this.salestargetmoney10.OutputFormat = resources.GetString("salestargetmoney10.OutputFormat");
            this.salestargetmoney10.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney10.Text = "123,456,789";
            this.salestargetmoney10.Top = 0.02083333F;
            this.salestargetmoney10.Width = 0.5625F;
            // 
            // salestargetmoney11
            // 
            this.salestargetmoney11.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney11.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney11.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney11.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney11.DataField = "salestargetmoney11";
            this.salestargetmoney11.Height = 0.15F;
            this.salestargetmoney11.Left = 8.870266F;
            this.salestargetmoney11.MultiLine = false;
            this.salestargetmoney11.Name = "salestargetmoney11";
            this.salestargetmoney11.OutputFormat = resources.GetString("salestargetmoney11.OutputFormat");
            this.salestargetmoney11.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney11.Text = "123,456,789";
            this.salestargetmoney11.Top = 0.02083333F;
            this.salestargetmoney11.Width = 0.5625F;
            // 
            // salestargetmoney12
            // 
            this.salestargetmoney12.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoney12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney12.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoney12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney12.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoney12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney12.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoney12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoney12.DataField = "salestargetmoney12";
            this.salestargetmoney12.Height = 0.15F;
            this.salestargetmoney12.Left = 9.4375F;
            this.salestargetmoney12.MultiLine = false;
            this.salestargetmoney12.Name = "salestargetmoney12";
            this.salestargetmoney12.OutputFormat = resources.GetString("salestargetmoney12.OutputFormat");
            this.salestargetmoney12.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoney12.Text = "123,456,789";
            this.salestargetmoney12.Top = 0.02083333F;
            this.salestargetmoney12.Width = 0.5625F;
            // 
            // salestargetmoneyall
            // 
            this.salestargetmoneyall.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetmoneyall.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoneyall.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetmoneyall.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoneyall.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetmoneyall.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoneyall.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetmoneyall.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetmoneyall.DataField = "salestargetmoneyall";
            this.salestargetmoneyall.Height = 0.15F;
            this.salestargetmoneyall.Left = 10F;
            this.salestargetmoneyall.MultiLine = false;
            this.salestargetmoneyall.Name = "salestargetmoneyall";
            this.salestargetmoneyall.OutputFormat = resources.GetString("salestargetmoneyall.OutputFormat");
            this.salestargetmoneyall.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetmoneyall.Text = "12,123,456,789";
            this.salestargetmoneyall.Top = 0.02083333F;
            this.salestargetmoneyall.Width = 0.75F;
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
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0.3958333F;
            this.line4.Y2 = 0.3958333F;
            // 
            // salestargetprofit1
            // 
            this.salestargetprofit1.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit1.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit1.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit1.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit1.DataField = "salestargetprofit1";
            this.salestargetprofit1.Height = 0.15F;
            this.salestargetprofit1.Left = 3.197917F;
            this.salestargetprofit1.MultiLine = false;
            this.salestargetprofit1.Name = "salestargetprofit1";
            this.salestargetprofit1.OutputFormat = resources.GetString("salestargetprofit1.OutputFormat");
            this.salestargetprofit1.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit1.Text = "123,456,789";
            this.salestargetprofit1.Top = 0.2083334F;
            this.salestargetprofit1.Width = 0.5625F;
            // 
            // salestargetprofit2
            // 
            this.salestargetprofit2.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit2.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit2.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit2.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit2.DataField = "salestargetprofit2";
            this.salestargetprofit2.Height = 0.15F;
            this.salestargetprofit2.Left = 3.765152F;
            this.salestargetprofit2.MultiLine = false;
            this.salestargetprofit2.Name = "salestargetprofit2";
            this.salestargetprofit2.OutputFormat = resources.GetString("salestargetprofit2.OutputFormat");
            this.salestargetprofit2.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit2.Text = "123,456,789";
            this.salestargetprofit2.Top = 0.2083334F;
            this.salestargetprofit2.Width = 0.5625F;
            // 
            // salestargetprofit3
            // 
            this.salestargetprofit3.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit3.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit3.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit3.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit3.DataField = "salestargetprofit3";
            this.salestargetprofit3.Height = 0.15F;
            this.salestargetprofit3.Left = 4.332386F;
            this.salestargetprofit3.MultiLine = false;
            this.salestargetprofit3.Name = "salestargetprofit3";
            this.salestargetprofit3.OutputFormat = resources.GetString("salestargetprofit3.OutputFormat");
            this.salestargetprofit3.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit3.Text = "123,456,789";
            this.salestargetprofit3.Top = 0.2083334F;
            this.salestargetprofit3.Width = 0.5625F;
            // 
            // salestargetprofit4
            // 
            this.salestargetprofit4.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit4.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit4.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit4.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit4.DataField = "salestargetprofit4";
            this.salestargetprofit4.Height = 0.15F;
            this.salestargetprofit4.Left = 4.899621F;
            this.salestargetprofit4.MultiLine = false;
            this.salestargetprofit4.Name = "salestargetprofit4";
            this.salestargetprofit4.OutputFormat = resources.GetString("salestargetprofit4.OutputFormat");
            this.salestargetprofit4.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit4.Text = "123,456,789";
            this.salestargetprofit4.Top = 0.2083334F;
            this.salestargetprofit4.Width = 0.5625F;
            // 
            // salestargetprofit5
            // 
            this.salestargetprofit5.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit5.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit5.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit5.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit5.DataField = "salestargetprofit5";
            this.salestargetprofit5.Height = 0.15F;
            this.salestargetprofit5.Left = 5.466856F;
            this.salestargetprofit5.MultiLine = false;
            this.salestargetprofit5.Name = "salestargetprofit5";
            this.salestargetprofit5.OutputFormat = resources.GetString("salestargetprofit5.OutputFormat");
            this.salestargetprofit5.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit5.Text = "123,456,789";
            this.salestargetprofit5.Top = 0.2083334F;
            this.salestargetprofit5.Width = 0.5625F;
            // 
            // salestargetprofit6
            // 
            this.salestargetprofit6.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit6.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit6.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit6.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit6.DataField = "salestargetprofit6";
            this.salestargetprofit6.Height = 0.15F;
            this.salestargetprofit6.Left = 6.034091F;
            this.salestargetprofit6.MultiLine = false;
            this.salestargetprofit6.Name = "salestargetprofit6";
            this.salestargetprofit6.OutputFormat = resources.GetString("salestargetprofit6.OutputFormat");
            this.salestargetprofit6.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit6.Text = "123,456,789";
            this.salestargetprofit6.Top = 0.2083334F;
            this.salestargetprofit6.Width = 0.5625F;
            // 
            // salestargetprofit7
            // 
            this.salestargetprofit7.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit7.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit7.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit7.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit7.DataField = "salestargetprofit7";
            this.salestargetprofit7.Height = 0.15F;
            this.salestargetprofit7.Left = 6.601326F;
            this.salestargetprofit7.MultiLine = false;
            this.salestargetprofit7.Name = "salestargetprofit7";
            this.salestargetprofit7.OutputFormat = resources.GetString("salestargetprofit7.OutputFormat");
            this.salestargetprofit7.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit7.Text = "123,456,789";
            this.salestargetprofit7.Top = 0.2083334F;
            this.salestargetprofit7.Width = 0.5625F;
            // 
            // salestargetprofit8
            // 
            this.salestargetprofit8.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit8.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit8.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit8.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit8.DataField = "salestargetprofit8";
            this.salestargetprofit8.Height = 0.15F;
            this.salestargetprofit8.Left = 7.168561F;
            this.salestargetprofit8.MultiLine = false;
            this.salestargetprofit8.Name = "salestargetprofit8";
            this.salestargetprofit8.OutputFormat = resources.GetString("salestargetprofit8.OutputFormat");
            this.salestargetprofit8.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit8.Text = "123,456,789";
            this.salestargetprofit8.Top = 0.2083334F;
            this.salestargetprofit8.Width = 0.5625F;
            // 
            // salestargetprofit9
            // 
            this.salestargetprofit9.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit9.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit9.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit9.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit9.DataField = "salestargetprofit9";
            this.salestargetprofit9.Height = 0.15F;
            this.salestargetprofit9.Left = 7.735796F;
            this.salestargetprofit9.MultiLine = false;
            this.salestargetprofit9.Name = "salestargetprofit9";
            this.salestargetprofit9.OutputFormat = resources.GetString("salestargetprofit9.OutputFormat");
            this.salestargetprofit9.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit9.Text = "123,456,789";
            this.salestargetprofit9.Top = 0.2083334F;
            this.salestargetprofit9.Width = 0.5625F;
            // 
            // salestargetprofit10
            // 
            this.salestargetprofit10.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit10.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit10.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit10.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit10.DataField = "salestargetprofit10";
            this.salestargetprofit10.Height = 0.15F;
            this.salestargetprofit10.Left = 8.303031F;
            this.salestargetprofit10.MultiLine = false;
            this.salestargetprofit10.Name = "salestargetprofit10";
            this.salestargetprofit10.OutputFormat = resources.GetString("salestargetprofit10.OutputFormat");
            this.salestargetprofit10.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit10.Text = "123,456,789";
            this.salestargetprofit10.Top = 0.2083334F;
            this.salestargetprofit10.Width = 0.5625F;
            // 
            // salestargetprofit11
            // 
            this.salestargetprofit11.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit11.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit11.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit11.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit11.DataField = "salestargetprofit11";
            this.salestargetprofit11.Height = 0.15F;
            this.salestargetprofit11.Left = 8.870266F;
            this.salestargetprofit11.MultiLine = false;
            this.salestargetprofit11.Name = "salestargetprofit11";
            this.salestargetprofit11.OutputFormat = resources.GetString("salestargetprofit11.OutputFormat");
            this.salestargetprofit11.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit11.Text = "123,456,789";
            this.salestargetprofit11.Top = 0.2083334F;
            this.salestargetprofit11.Width = 0.5625F;
            // 
            // salestargetprofit12
            // 
            this.salestargetprofit12.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofit12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit12.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofit12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit12.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofit12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit12.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofit12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofit12.DataField = "salestargetprofit12";
            this.salestargetprofit12.Height = 0.15F;
            this.salestargetprofit12.Left = 9.4375F;
            this.salestargetprofit12.MultiLine = false;
            this.salestargetprofit12.Name = "salestargetprofit12";
            this.salestargetprofit12.OutputFormat = resources.GetString("salestargetprofit12.OutputFormat");
            this.salestargetprofit12.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofit12.Text = "123,456,789";
            this.salestargetprofit12.Top = 0.2083334F;
            this.salestargetprofit12.Width = 0.5625F;
            // 
            // salestargetprofitall
            // 
            this.salestargetprofitall.Border.BottomColor = System.Drawing.Color.Black;
            this.salestargetprofitall.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofitall.Border.LeftColor = System.Drawing.Color.Black;
            this.salestargetprofitall.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofitall.Border.RightColor = System.Drawing.Color.Black;
            this.salestargetprofitall.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofitall.Border.TopColor = System.Drawing.Color.Black;
            this.salestargetprofitall.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salestargetprofitall.DataField = "salestargetprofitall";
            this.salestargetprofitall.Height = 0.15F;
            this.salestargetprofitall.Left = 10F;
            this.salestargetprofitall.MultiLine = false;
            this.salestargetprofitall.Name = "salestargetprofitall";
            this.salestargetprofitall.OutputFormat = resources.GetString("salestargetprofitall.OutputFormat");
            this.salestargetprofitall.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.salestargetprofitall.Text = "12,123,456,789";
            this.salestargetprofitall.Top = 0.2083334F;
            this.salestargetprofitall.Width = 0.75F;
            // 
            // salesemployeecd
            // 
            this.salesemployeecd.Border.BottomColor = System.Drawing.Color.Black;
            this.salesemployeecd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeecd.Border.LeftColor = System.Drawing.Color.Black;
            this.salesemployeecd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeecd.Border.RightColor = System.Drawing.Color.Black;
            this.salesemployeecd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeecd.Border.TopColor = System.Drawing.Color.Black;
            this.salesemployeecd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeecd.DataField = "salesemployeecd";
            this.salesemployeecd.Height = 0.15F;
            this.salesemployeecd.Left = 1.5F;
            this.salesemployeecd.MultiLine = false;
            this.salesemployeecd.Name = "salesemployeecd";
            this.salesemployeecd.OutputFormat = resources.GetString("salesemployeecd.OutputFormat");
            this.salesemployeecd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.salesemployeecd.Text = "12345678";
            this.salesemployeecd.Top = 0.2333333F;
            this.salesemployeecd.Width = 0.5F;
            // 
            // salesemployeenm
            // 
            this.salesemployeenm.Border.BottomColor = System.Drawing.Color.Black;
            this.salesemployeenm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeenm.Border.LeftColor = System.Drawing.Color.Black;
            this.salesemployeenm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeenm.Border.RightColor = System.Drawing.Color.Black;
            this.salesemployeenm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeenm.Border.TopColor = System.Drawing.Color.Black;
            this.salesemployeenm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesemployeenm.DataField = "salesemployeenm";
            this.salesemployeenm.Height = 0.15F;
            this.salesemployeenm.Left = 2F;
            this.salesemployeenm.MultiLine = false;
            this.salesemployeenm.Name = "salesemployeenm";
            this.salesemployeenm.OutputFormat = resources.GetString("salesemployeenm.OutputFormat");
            this.salesemployeenm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.salesemployeenm.Text = "あいうえおかきくけこ";
            this.salesemployeenm.Top = 0.2333333F;
            this.salesemployeenm.Width = 1.1875F;
            // 
            // frontemployeecd
            // 
            this.frontemployeecd.Border.BottomColor = System.Drawing.Color.Black;
            this.frontemployeecd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeecd.Border.LeftColor = System.Drawing.Color.Black;
            this.frontemployeecd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeecd.Border.RightColor = System.Drawing.Color.Black;
            this.frontemployeecd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeecd.Border.TopColor = System.Drawing.Color.Black;
            this.frontemployeecd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeecd.DataField = "frontemployeecd";
            this.frontemployeecd.Height = 0.15F;
            this.frontemployeecd.Left = 1.5F;
            this.frontemployeecd.MultiLine = false;
            this.frontemployeecd.Name = "frontemployeecd";
            this.frontemployeecd.OutputFormat = resources.GetString("frontemployeecd.OutputFormat");
            this.frontemployeecd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.frontemployeecd.Text = "12345678";
            this.frontemployeecd.Top = 0.4458333F;
            this.frontemployeecd.Width = 0.5F;
            // 
            // frontemployeenm
            // 
            this.frontemployeenm.Border.BottomColor = System.Drawing.Color.Black;
            this.frontemployeenm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeenm.Border.LeftColor = System.Drawing.Color.Black;
            this.frontemployeenm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeenm.Border.RightColor = System.Drawing.Color.Black;
            this.frontemployeenm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeenm.Border.TopColor = System.Drawing.Color.Black;
            this.frontemployeenm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.frontemployeenm.DataField = "frontemployeenm";
            this.frontemployeenm.Height = 0.15F;
            this.frontemployeenm.Left = 2F;
            this.frontemployeenm.MultiLine = false;
            this.frontemployeenm.Name = "frontemployeenm";
            this.frontemployeenm.OutputFormat = resources.GetString("frontemployeenm.OutputFormat");
            this.frontemployeenm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.frontemployeenm.Text = "あいうえおかきくけこ";
            this.frontemployeenm.Top = 0.4375F;
            this.frontemployeenm.Width = 1.1875F;
            // 
            // salesinputcode
            // 
            this.salesinputcode.Border.BottomColor = System.Drawing.Color.Black;
            this.salesinputcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputcode.Border.LeftColor = System.Drawing.Color.Black;
            this.salesinputcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputcode.Border.RightColor = System.Drawing.Color.Black;
            this.salesinputcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputcode.Border.TopColor = System.Drawing.Color.Black;
            this.salesinputcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputcode.DataField = "salesinputcode";
            this.salesinputcode.Height = 0.15F;
            this.salesinputcode.Left = 1.5F;
            this.salesinputcode.MultiLine = false;
            this.salesinputcode.Name = "salesinputcode";
            this.salesinputcode.OutputFormat = resources.GetString("salesinputcode.OutputFormat");
            this.salesinputcode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.salesinputcode.Text = "12345678";
            this.salesinputcode.Top = 0.6583333F;
            this.salesinputcode.Width = 0.5F;
            // 
            // salesinputname
            // 
            this.salesinputname.Border.BottomColor = System.Drawing.Color.Black;
            this.salesinputname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputname.Border.LeftColor = System.Drawing.Color.Black;
            this.salesinputname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputname.Border.RightColor = System.Drawing.Color.Black;
            this.salesinputname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputname.Border.TopColor = System.Drawing.Color.Black;
            this.salesinputname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesinputname.DataField = "salesinputname";
            this.salesinputname.Height = 0.15F;
            this.salesinputname.Left = 2F;
            this.salesinputname.MultiLine = false;
            this.salesinputname.Name = "salesinputname";
            this.salesinputname.OutputFormat = resources.GetString("salesinputname.OutputFormat");
            this.salesinputname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.salesinputname.Text = "あいうえおかきくけこ";
            this.salesinputname.Top = 0.6583333F;
            this.salesinputname.Width = 1.1875F;
            // 
            // salescode
            // 
            this.salescode.Border.BottomColor = System.Drawing.Color.Black;
            this.salescode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescode.Border.LeftColor = System.Drawing.Color.Black;
            this.salescode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescode.Border.RightColor = System.Drawing.Color.Black;
            this.salescode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescode.Border.TopColor = System.Drawing.Color.Black;
            this.salescode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescode.DataField = "salescode";
            this.salescode.Height = 0.15F;
            this.salescode.Left = 1.5F;
            this.salescode.MultiLine = false;
            this.salescode.Name = "salescode";
            this.salescode.OutputFormat = resources.GetString("salescode.OutputFormat");
            this.salescode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.salescode.Text = "12345678";
            this.salescode.Top = 0.8708333F;
            this.salescode.Width = 0.5F;
            // 
            // salescodename
            // 
            this.salescodename.Border.BottomColor = System.Drawing.Color.Black;
            this.salescodename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescodename.Border.LeftColor = System.Drawing.Color.Black;
            this.salescodename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescodename.Border.RightColor = System.Drawing.Color.Black;
            this.salescodename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescodename.Border.TopColor = System.Drawing.Color.Black;
            this.salescodename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salescodename.DataField = "salescodename";
            this.salescodename.Height = 0.15F;
            this.salescodename.Left = 2F;
            this.salescodename.MultiLine = false;
            this.salescodename.Name = "salescodename";
            this.salescodename.OutputFormat = resources.GetString("salescodename.OutputFormat");
            this.salescodename.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.salescodename.Text = "あいうえおかきくけこ";
            this.salescodename.Top = 0.8708333F;
            this.salescodename.Width = 1.1875F;
            // 
            // enterpriseganrecode
            // 
            this.enterpriseganrecode.Border.BottomColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.Border.LeftColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.Border.RightColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.Border.TopColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.DataField = "enterpriseganrecode";
            this.enterpriseganrecode.Height = 0.15F;
            this.enterpriseganrecode.Left = 1.5F;
            this.enterpriseganrecode.MultiLine = false;
            this.enterpriseganrecode.Name = "enterpriseganrecode";
            this.enterpriseganrecode.OutputFormat = resources.GetString("enterpriseganrecode.OutputFormat");
            this.enterpriseganrecode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.enterpriseganrecode.Text = "12345678";
            this.enterpriseganrecode.Top = 1.083333F;
            this.enterpriseganrecode.Width = 0.5F;
            // 
            // enterpriseganrecodename
            // 
            this.enterpriseganrecodename.Border.BottomColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.Border.LeftColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.Border.RightColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.Border.TopColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.DataField = "enterpriseganrecodename";
            this.enterpriseganrecodename.Height = 0.15F;
            this.enterpriseganrecodename.Left = 2F;
            this.enterpriseganrecodename.MultiLine = false;
            this.enterpriseganrecodename.Name = "enterpriseganrecodename";
            this.enterpriseganrecodename.OutputFormat = resources.GetString("enterpriseganrecodename.OutputFormat");
            this.enterpriseganrecodename.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.enterpriseganrecodename.Text = "あいうえおかきくけこ";
            this.enterpriseganrecodename.Top = 1.083333F;
            this.enterpriseganrecodename.Width = 1.1875F;
            // 
            // customercode
            // 
            this.customercode.Border.BottomColor = System.Drawing.Color.Black;
            this.customercode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode.Border.LeftColor = System.Drawing.Color.Black;
            this.customercode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode.Border.RightColor = System.Drawing.Color.Black;
            this.customercode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode.Border.TopColor = System.Drawing.Color.Black;
            this.customercode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode.DataField = "customercode";
            this.customercode.Height = 0.15F;
            this.customercode.Left = 1.5F;
            this.customercode.MultiLine = false;
            this.customercode.Name = "customercode";
            this.customercode.OutputFormat = resources.GetString("customercode.OutputFormat");
            this.customercode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.customercode.Text = "12345678";
            this.customercode.Top = 1.295833F;
            this.customercode.Width = 0.5F;
            // 
            // customersnm
            // 
            this.customersnm.Border.BottomColor = System.Drawing.Color.Black;
            this.customersnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customersnm.Border.LeftColor = System.Drawing.Color.Black;
            this.customersnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customersnm.Border.RightColor = System.Drawing.Color.Black;
            this.customersnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customersnm.Border.TopColor = System.Drawing.Color.Black;
            this.customersnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customersnm.DataField = "customersnm";
            this.customersnm.Height = 0.15F;
            this.customersnm.Left = 2F;
            this.customersnm.MultiLine = false;
            this.customersnm.Name = "customersnm";
            this.customersnm.OutputFormat = resources.GetString("customersnm.OutputFormat");
            this.customersnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.customersnm.Text = "あいうえおかきくけこ";
            this.customersnm.Top = 1.295833F;
            this.customersnm.Width = 1.1875F;
            // 
            // businesstypecode
            // 
            this.businesstypecode.Border.BottomColor = System.Drawing.Color.Black;
            this.businesstypecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecode.Border.LeftColor = System.Drawing.Color.Black;
            this.businesstypecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecode.Border.RightColor = System.Drawing.Color.Black;
            this.businesstypecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecode.Border.TopColor = System.Drawing.Color.Black;
            this.businesstypecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecode.DataField = "businesstypecode";
            this.businesstypecode.Height = 0.15F;
            this.businesstypecode.Left = 1.5F;
            this.businesstypecode.MultiLine = false;
            this.businesstypecode.Name = "businesstypecode";
            this.businesstypecode.OutputFormat = resources.GetString("businesstypecode.OutputFormat");
            this.businesstypecode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.businesstypecode.Text = "12345678";
            this.businesstypecode.Top = 1.508333F;
            this.businesstypecode.Width = 0.5F;
            // 
            // businesstypecodename
            // 
            this.businesstypecodename.Border.BottomColor = System.Drawing.Color.Black;
            this.businesstypecodename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecodename.Border.LeftColor = System.Drawing.Color.Black;
            this.businesstypecodename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecodename.Border.RightColor = System.Drawing.Color.Black;
            this.businesstypecodename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecodename.Border.TopColor = System.Drawing.Color.Black;
            this.businesstypecodename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypecodename.DataField = "businesstypecodename";
            this.businesstypecodename.Height = 0.15F;
            this.businesstypecodename.Left = 2F;
            this.businesstypecodename.MultiLine = false;
            this.businesstypecodename.Name = "businesstypecodename";
            this.businesstypecodename.OutputFormat = resources.GetString("businesstypecodename.OutputFormat");
            this.businesstypecodename.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.businesstypecodename.Text = "あいうえおかきくけこ";
            this.businesstypecodename.Top = 1.508333F;
            this.businesstypecodename.Width = 1.1875F;
            // 
            // salesareacode
            // 
            this.salesareacode.Border.BottomColor = System.Drawing.Color.Black;
            this.salesareacode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacode.Border.LeftColor = System.Drawing.Color.Black;
            this.salesareacode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacode.Border.RightColor = System.Drawing.Color.Black;
            this.salesareacode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacode.Border.TopColor = System.Drawing.Color.Black;
            this.salesareacode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacode.DataField = "salesareacode";
            this.salesareacode.Height = 0.15F;
            this.salesareacode.Left = 1.5F;
            this.salesareacode.MultiLine = false;
            this.salesareacode.Name = "salesareacode";
            this.salesareacode.OutputFormat = resources.GetString("salesareacode.OutputFormat");
            this.salesareacode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.salesareacode.Text = "12345678";
            this.salesareacode.Top = 1.720833F;
            this.salesareacode.Width = 0.5F;
            // 
            // salesareacodename
            // 
            this.salesareacodename.Border.BottomColor = System.Drawing.Color.Black;
            this.salesareacodename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacodename.Border.LeftColor = System.Drawing.Color.Black;
            this.salesareacodename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacodename.Border.RightColor = System.Drawing.Color.Black;
            this.salesareacodename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacodename.Border.TopColor = System.Drawing.Color.Black;
            this.salesareacodename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareacodename.DataField = "salesareacodename";
            this.salesareacodename.Height = 0.15F;
            this.salesareacodename.Left = 2F;
            this.salesareacodename.MultiLine = false;
            this.salesareacodename.Name = "salesareacodename";
            this.salesareacodename.OutputFormat = resources.GetString("salesareacodename.OutputFormat");
            this.salesareacodename.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.salesareacodename.Text = "あいうえおかきくけこ";
            this.salesareacodename.Top = 1.720833F;
            this.salesareacodename.Width = 1.1875F;
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
            this.tb_ReportTitle.Text = "売上目標設定マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2604167F;
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
            this.line2,
            this.lbl_Name,
            this.lbl_Month1,
            this.lbl_Month2,
            this.lbl_Month3,
            this.lbl_Month4,
            this.lbl_Month5,
            this.lbl_Month6,
            this.lbl_Month7,
            this.lbl_Month8,
            this.lbl_Month9,
            this.lbl_Month10,
            this.lbl_Month11,
            this.lbl_Month12,
            this.label4});
            this.TitleHeader.Height = 0.425F;
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
            this.label1.Text = "拠点";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.3125F;
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
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.2291667F;
            this.line2.Y2 = 0.2291667F;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Name.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Name.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Name.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Name.Height = 0.15F;
            this.lbl_Name.HyperLink = "";
            this.lbl_Name.Left = 1.5F;
            this.lbl_Name.MultiLine = false;
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Name.Text = "名称２";
            this.lbl_Name.Top = 0.0625F;
            this.lbl_Name.Width = 1.5625F;
            // 
            // lbl_Month1
            // 
            this.lbl_Month1.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Height = 0.15F;
            this.lbl_Month1.HyperLink = "";
            this.lbl_Month1.Left = 3.197917F;
            this.lbl_Month1.MultiLine = false;
            this.lbl_Month1.Name = "lbl_Month1";
            this.lbl_Month1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month1.Text = "郵便番号";
            this.lbl_Month1.Top = 0.0625F;
            this.lbl_Month1.Width = 0.5625F;
            // 
            // lbl_Month2
            // 
            this.lbl_Month2.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Height = 0.15F;
            this.lbl_Month2.HyperLink = "";
            this.lbl_Month2.Left = 3.75F;
            this.lbl_Month2.MultiLine = false;
            this.lbl_Month2.Name = "lbl_Month2";
            this.lbl_Month2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month2.Text = "郵便番号";
            this.lbl_Month2.Top = 0.0625F;
            this.lbl_Month2.Width = 0.5625F;
            // 
            // lbl_Month3
            // 
            this.lbl_Month3.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Height = 0.15F;
            this.lbl_Month3.HyperLink = "";
            this.lbl_Month3.Left = 4.3125F;
            this.lbl_Month3.MultiLine = false;
            this.lbl_Month3.Name = "lbl_Month3";
            this.lbl_Month3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month3.Text = "郵便番号";
            this.lbl_Month3.Top = 0.0625F;
            this.lbl_Month3.Width = 0.5625F;
            // 
            // lbl_Month4
            // 
            this.lbl_Month4.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Height = 0.15F;
            this.lbl_Month4.HyperLink = "";
            this.lbl_Month4.Left = 4.875F;
            this.lbl_Month4.MultiLine = false;
            this.lbl_Month4.Name = "lbl_Month4";
            this.lbl_Month4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month4.Text = "郵便番号";
            this.lbl_Month4.Top = 0.0625F;
            this.lbl_Month4.Width = 0.5625F;
            // 
            // lbl_Month5
            // 
            this.lbl_Month5.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Height = 0.15F;
            this.lbl_Month5.HyperLink = "";
            this.lbl_Month5.Left = 5.4375F;
            this.lbl_Month5.MultiLine = false;
            this.lbl_Month5.Name = "lbl_Month5";
            this.lbl_Month5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month5.Text = "郵便番号";
            this.lbl_Month5.Top = 0.0625F;
            this.lbl_Month5.Width = 0.5625F;
            // 
            // lbl_Month6
            // 
            this.lbl_Month6.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Height = 0.15F;
            this.lbl_Month6.HyperLink = "";
            this.lbl_Month6.Left = 6F;
            this.lbl_Month6.MultiLine = false;
            this.lbl_Month6.Name = "lbl_Month6";
            this.lbl_Month6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month6.Text = "郵便番号";
            this.lbl_Month6.Top = 0.0625F;
            this.lbl_Month6.Width = 0.5625F;
            // 
            // lbl_Month7
            // 
            this.lbl_Month7.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Height = 0.15F;
            this.lbl_Month7.HyperLink = "";
            this.lbl_Month7.Left = 6.5625F;
            this.lbl_Month7.MultiLine = false;
            this.lbl_Month7.Name = "lbl_Month7";
            this.lbl_Month7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month7.Text = "郵便番号";
            this.lbl_Month7.Top = 0.0625F;
            this.lbl_Month7.Width = 0.5625F;
            // 
            // lbl_Month8
            // 
            this.lbl_Month8.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Height = 0.15F;
            this.lbl_Month8.HyperLink = "";
            this.lbl_Month8.Left = 7.125F;
            this.lbl_Month8.MultiLine = false;
            this.lbl_Month8.Name = "lbl_Month8";
            this.lbl_Month8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month8.Text = "郵便番号";
            this.lbl_Month8.Top = 0.0625F;
            this.lbl_Month8.Width = 0.5625F;
            // 
            // lbl_Month9
            // 
            this.lbl_Month9.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Height = 0.15F;
            this.lbl_Month9.HyperLink = "";
            this.lbl_Month9.Left = 7.6875F;
            this.lbl_Month9.MultiLine = false;
            this.lbl_Month9.Name = "lbl_Month9";
            this.lbl_Month9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month9.Text = "郵便番号";
            this.lbl_Month9.Top = 0.0625F;
            this.lbl_Month9.Width = 0.5625F;
            // 
            // lbl_Month10
            // 
            this.lbl_Month10.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Height = 0.15F;
            this.lbl_Month10.HyperLink = "";
            this.lbl_Month10.Left = 8.25F;
            this.lbl_Month10.MultiLine = false;
            this.lbl_Month10.Name = "lbl_Month10";
            this.lbl_Month10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month10.Text = "郵便番号";
            this.lbl_Month10.Top = 0.0625F;
            this.lbl_Month10.Width = 0.5625F;
            // 
            // lbl_Month11
            // 
            this.lbl_Month11.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Height = 0.15F;
            this.lbl_Month11.HyperLink = "";
            this.lbl_Month11.Left = 8.8125F;
            this.lbl_Month11.MultiLine = false;
            this.lbl_Month11.Name = "lbl_Month11";
            this.lbl_Month11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month11.Text = "郵便番号";
            this.lbl_Month11.Top = 0.0625F;
            this.lbl_Month11.Width = 0.5625F;
            // 
            // lbl_Month12
            // 
            this.lbl_Month12.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Height = 0.15F;
            this.lbl_Month12.HyperLink = "";
            this.lbl_Month12.Left = 9.375F;
            this.lbl_Month12.MultiLine = false;
            this.lbl_Month12.Name = "lbl_Month12";
            this.lbl_Month12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Month12.Text = "郵便番号";
            this.lbl_Month12.Top = 0.0625F;
            this.lbl_Month12.Width = 0.5625F;
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
            this.label4.Left = 10F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "合計";
            this.label4.Top = 0.0625F;
            this.label4.Width = 0.75F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0.01041667F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08633P_01A4C
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
            this.PageEnd += new System.EventHandler(this.PMKHN08633P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08633P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.sectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidesnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsectionname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoney12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetmoneyall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestargetprofitall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesemployeecd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesemployeenm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontemployeecd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontemployeenm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesinputcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesinputname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salescode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salescodename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecodename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customercode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypecodename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareacode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareacodename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
