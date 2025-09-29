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
	/// 得意先マスタ（印刷）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 得意先マスタ（印刷）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN08555P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 得意先マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 得意先マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08555P_01A4C()
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

        private CustomerPrintWork _customerPrintWork;                   // 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label Lb_customercode;
        private Label Lb_kana;
        private TextBox customercode;
        private TextBox customersnm;
        private Line line2;
        private Line line3;
        private TextBox kana;
        private Label Lb_postno;
        private Label Lb_officetelno;
        private Label Lb_totalday;
        private Label Lb_collectmoneynameday;
        private Label Lb_businesstypecode;
        private Label Lb_claimsectioncode;
        private Label Lb_addressall;
        private TextBox officetelno;
        private Label Lb_customeragentcd;
        private Label Lb_mngsectioncode;
        private Label Lb_salesareacode;
        private Label Lb_billcollectercd;
        private TextBox portabletelno;
        private TextBox officefaxno;
        private TextBox totalday;
        private TextBox collectmoneynameday;
        private TextBox customeragentcd;
        private TextBox customeragentname;
        private TextBox salesareacode;
        private TextBox salesareaname;
        private TextBox businesstypecode;
        private TextBox businesstypename;
        private TextBox claimsectioncode;
        private TextBox claimcode;
        private TextBox billcollectercd;
        private TextBox postno;
        private TextBox addressall;
        private TextBox mngsectioncode;
        private TextBox sectionguidesnm;
        private TextBox custwarehousecd;
        private Label Lb_portabletelno;
        private Label Lb_officefaxno;
        private Label Lb_custwarehousecd;
        private TextBox name;
        private TextBox name2;
        private Label Lb_name;
        private Label Lb_name2;
        private TextBox officetelno2;
        private TextBox portabletelno2;
        private TextBox officefaxno2;
        private TextBox customeragentcd2;
        private TextBox customeragentname2;
        private TextBox address4;
        private TextBox address1;
        private TextBox address3;
        private TextBox customercode2;
        private TextBox kana2;
        private TextBox postno2;
        private Label Lb_customercode2;
        private Label Lb_kana2;
        private Label Lb_postno2;
        private Label Lb_address1;
        private Label Lb_address3;
        private Label Lb_address4;
        private Label Lb_officetelno2;
        private Label Lb_portabletelno2;
        private Label Lb_officefaxno2;
        private Label Lb_customeragentcd2;
        private TextBox custrategrpcode11;
        private TextBox custrategrpcode12;
        private TextBox custrategrpcode13;
        private TextBox custrategrpcode14;
        private TextBox custrategrpcode15;
        private TextBox custrategrpcode20;
        private TextBox custrategrpcode19;
        private TextBox custrategrpcode18;
        private TextBox custrategrpcode17;
        private TextBox custrategrpcode16;
        private TextBox custrategrpcode25;
        private TextBox custrategrpcode24;
        private TextBox custrategrpcode23;
        private TextBox custrategrpcode22;
        private TextBox custrategrpcode21;
        private TextBox custrategrpcode10;
        private TextBox custrategrpcode09;
        private TextBox custrategrpcode08;
        private TextBox custrategrpcode07;
        private TextBox custrategrpcode06;
        private TextBox custrategrpcode05;
        private TextBox custrategrpcode04;
        private TextBox custrategrpcode03;
        private TextBox custrategrpcode02;
        private TextBox custrategrpcode01;
        private TextBox custrategrpcodeALL;
        private TextBox custrategrpcode00;
        private Label Lb_custrategrpcodeALL;
        private Label Lb_custrategrpcode00;
        private Label Lb_custrategrpcode01;
        private Label Lb_custrategrpcode02;
        private Label Lb_custrategrpcode03;
        private Label Lb_custrategrpcode04;
        private Label Lb_custrategrpcode05;
        private Label Lb_custrategrpcode06;
        private Label Lb_custrategrpcode07;
        private Label Lb_custrategrpcode08;
        private Label Lb_custrategrpcode09;
        private Label Lb_custrategrpcode10;
        private Label Lb_custrategrpcode11;
        private Label Lb_custrategrpcode12;
        private Label Lb_custrategrpcode13;
        private Label Lb_custrategrpcode14;
        private Label Lb_custrategrpcode15;
        private Label Lb_custrategrpcode16;
        private Label Lb_custrategrpcode17;
        private Label Lb_custrategrpcode18;
        private Label Lb_custrategrpcode19;
        private Label Lb_custrategrpcode20;
        private Label Lb_custrategrpcode21;
        private Label Lb_custrategrpcode22;
        private Label Lb_custrategrpcode23;
        private Label Lb_custrategrpcode24;
        private Label Lb_custrategrpcode25;
        private Label Lb_custrategrpcode01_2;
        private Label Lb_custrategrpcode02_2;
        private Label Lb_custrategrpcode03_2;
        private Label Lb_custrategrpcode04_2;
        private Label Lb_custrategrpcode05_2;
        private Label Lb_custrategrpcode06_2;
        private Label Lb_custrategrpcode07_2;
        private Label Lb_custrategrpcode08_2;
        private Label Lb_custrategrpcode09_2;
        private Label Lb_custrategrpcode10_2;
        private Label Lb_custrategrpcode11_2;
        private Label Lb_custrategrpcode12_2;
        private Label Lb_custrategrpcode13_2;
        private Label Lb_custrategrpcode14_2;
        private Label Lb_custrategrpcode15_2;
        private Label Lb_custrategrpcode16_2;
        private Label Lb_custrategrpcode17_2;
        private Label Lb_custrategrpcode18_2;
        private Label Lb_custrategrpcode19_2;
        private Label Lb_custrategrpcode20_2;
        private Label Lb_custrategrpcode21_2;
        private Label Lb_custrategrpcode22_2;
        private Label Lb_custrategrpcode23_2;
        private Label Lb_custrategrpcode24_2;
        private Label Lb_custrategrpcode25_2;
        private Label Lb_custrategrpcode00_2;
        private TextBox SORTTITLE;

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
                this._customerPrintWork = (CustomerPrintWork)this._printInfo.jyoken;
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
				// TODO:  PMKHN08555P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08555P_01A4C.WatermarkMode setter 実装を追加します。
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

            switch (this._customerPrintWork.PrintType)
            {
                case 0:
                    #region 得意先一覧
                    this.Lb_customercode.Visible = true;
                    this.Lb_officetelno.Visible = true;
                    this.Lb_portabletelno.Visible = true;
                    this.Lb_officefaxno.Visible = true;
                    this.Lb_totalday.Visible = true;
                    this.Lb_collectmoneynameday.Visible = true;
                    this.Lb_customeragentcd.Visible = true;
                    this.Lb_salesareacode.Visible = true;
                    this.Lb_businesstypecode.Visible = true;
                    this.Lb_claimsectioncode.Visible = true;
                    this.Lb_billcollectercd.Visible = true;
                    this.Lb_kana.Visible = true;
                    this.Lb_postno.Visible = true;
                    this.Lb_addressall.Visible = true;
                    this.Lb_mngsectioncode.Visible = true;
                    this.Lb_custwarehousecd.Visible = true;

                    this.customercode.Visible = true;
                    this.customersnm.Visible = true;
                    this.officetelno.Visible = true;
                    this.portabletelno.Visible = true;
                    this.officefaxno.Visible = true;
                    this.totalday.Visible = true;
                    this.collectmoneynameday.Visible = true;
                    this.customeragentcd.Visible = true;
                    this.customeragentname.Visible = true;
                    this.salesareacode.Visible = true;
                    this.salesareaname.Visible = true;
                    this.businesstypecode.Visible = true;
                    this.businesstypename.Visible = true;
                    this.claimsectioncode.Visible = true;
                    this.claimcode.Visible = true;
                    this.billcollectercd.Visible = true;
                    this.kana.Visible = true;
                    this.postno.Visible = true;
                    this.addressall.Visible = true;
                    this.mngsectioncode.Visible = true;
                    this.sectionguidesnm.Visible = true;
                    this.custwarehousecd.Visible = true;
                    #endregion  得意先一覧

                    #region 得意先住所録
                    this.Lb_customercode2.Visible = false;
                    this.Lb_kana2.Visible = false;
                    this.Lb_postno2.Visible = false;
                    this.Lb_address1.Visible = false;
                    this.Lb_address3.Visible = false;
                    this.Lb_address4.Visible = false;
                    this.Lb_officetelno2.Visible = false;
                    this.Lb_portabletelno2.Visible = false;
                    this.Lb_officefaxno2.Visible = false;
                    this.Lb_customeragentcd2.Visible = false;
                    this.Lb_name.Visible = false;
                    this.Lb_name2.Visible = false;
                    this.customercode2.Visible = false;
                    this.kana2.Visible = false;
                    this.postno2.Visible = false;
                    this.address1.Visible = false;
                    this.address3.Visible = false;
                    this.address4.Visible = false;
                    this.name.Visible = false;
                    this.name2.Visible = false;
                    this.officetelno2.Visible = false;
                    this.portabletelno2.Visible = false;
                    this.officefaxno2.Visible = false;
                    this.customeragentcd2.Visible = false;
                    this.customeragentname2.Visible = false;
                    #endregion 得意先住所録

                    #region 掛率グループ一覧
                    this.Lb_custrategrpcodeALL.Visible = false;
                    this.Lb_custrategrpcode00.Visible = false;
                    this.Lb_custrategrpcode01.Visible = false;
                    this.Lb_custrategrpcode02.Visible = false;
                    this.Lb_custrategrpcode03.Visible = false;
                    this.Lb_custrategrpcode04.Visible = false;
                    this.Lb_custrategrpcode05.Visible = false;
                    this.Lb_custrategrpcode06.Visible = false;
                    this.Lb_custrategrpcode07.Visible = false;
                    this.Lb_custrategrpcode08.Visible = false;
                    this.Lb_custrategrpcode09.Visible = false;
                    this.Lb_custrategrpcode10.Visible = false;
                    this.Lb_custrategrpcode11.Visible = false;
                    this.Lb_custrategrpcode12.Visible = false;
                    this.Lb_custrategrpcode13.Visible = false;
                    this.Lb_custrategrpcode14.Visible = false;
                    this.Lb_custrategrpcode15.Visible = false;
                    this.Lb_custrategrpcode16.Visible = false;
                    this.Lb_custrategrpcode17.Visible = false;
                    this.Lb_custrategrpcode18.Visible = false;
                    this.Lb_custrategrpcode19.Visible = false;
                    this.Lb_custrategrpcode20.Visible = false;
                    this.Lb_custrategrpcode21.Visible = false;
                    this.Lb_custrategrpcode22.Visible = false;
                    this.Lb_custrategrpcode23.Visible = false;
                    this.Lb_custrategrpcode24.Visible = false;
                    this.Lb_custrategrpcode25.Visible = false;
                    this.Lb_custrategrpcode00_2.Visible = false;
                    this.Lb_custrategrpcode01_2.Visible = false;
                    this.Lb_custrategrpcode02_2.Visible = false;
                    this.Lb_custrategrpcode03_2.Visible = false;
                    this.Lb_custrategrpcode04_2.Visible = false;
                    this.Lb_custrategrpcode05_2.Visible = false;
                    this.Lb_custrategrpcode06_2.Visible = false;
                    this.Lb_custrategrpcode07_2.Visible = false;
                    this.Lb_custrategrpcode08_2.Visible = false;
                    this.Lb_custrategrpcode09_2.Visible = false;
                    this.Lb_custrategrpcode10_2.Visible = false;
                    this.Lb_custrategrpcode11_2.Visible = false;
                    this.Lb_custrategrpcode12_2.Visible = false;
                    this.Lb_custrategrpcode13_2.Visible = false;
                    this.Lb_custrategrpcode14_2.Visible = false;
                    this.Lb_custrategrpcode15_2.Visible = false;
                    this.Lb_custrategrpcode16_2.Visible = false;
                    this.Lb_custrategrpcode17_2.Visible = false;
                    this.Lb_custrategrpcode18_2.Visible = false;
                    this.Lb_custrategrpcode19_2.Visible = false;
                    this.Lb_custrategrpcode20_2.Visible = false;
                    this.Lb_custrategrpcode21_2.Visible = false;
                    this.Lb_custrategrpcode22_2.Visible = false;
                    this.Lb_custrategrpcode23_2.Visible = false;
                    this.Lb_custrategrpcode24_2.Visible = false;
                    this.Lb_custrategrpcode25_2.Visible = false;

                    this.custrategrpcodeALL.Visible = false;
                    this.custrategrpcode00.Visible = false;
                    this.custrategrpcode01.Visible = false;
                    this.custrategrpcode02.Visible = false;
                    this.custrategrpcode03.Visible = false;
                    this.custrategrpcode04.Visible = false;
                    this.custrategrpcode05.Visible = false;
                    this.custrategrpcode06.Visible = false;
                    this.custrategrpcode07.Visible = false;
                    this.custrategrpcode08.Visible = false;
                    this.custrategrpcode09.Visible = false;
                    this.custrategrpcode10.Visible = false;
                    this.custrategrpcode11.Visible = false;
                    this.custrategrpcode12.Visible = false;
                    this.custrategrpcode13.Visible = false;
                    this.custrategrpcode14.Visible = false;
                    this.custrategrpcode15.Visible = false;
                    this.custrategrpcode16.Visible = false;
                    this.custrategrpcode17.Visible = false;
                    this.custrategrpcode18.Visible = false;
                    this.custrategrpcode19.Visible = false;
                    this.custrategrpcode20.Visible = false;
                    this.custrategrpcode21.Visible = false;
                    this.custrategrpcode22.Visible = false;
                    this.custrategrpcode23.Visible = false;
                    this.custrategrpcode24.Visible = false;
                    this.custrategrpcode25.Visible = false;
                    #endregion 掛率グループ一覧
                    break;
                case 1:
                    #region 得意先一覧
                    this.Lb_customercode.Visible = false;
                    this.Lb_officetelno.Visible = false;
                    this.Lb_portabletelno.Visible = false;
                    this.Lb_officefaxno.Visible = false;
                    this.Lb_totalday.Visible = false;
                    this.Lb_collectmoneynameday.Visible = false;
                    this.Lb_customeragentcd.Visible = false;
                    this.Lb_salesareacode.Visible = false;
                    this.Lb_businesstypecode.Visible = false;
                    this.Lb_claimsectioncode.Visible = false;
                    this.Lb_billcollectercd.Visible = false;
                    this.Lb_kana.Visible = false;
                    this.Lb_postno.Visible = false;
                    this.Lb_addressall.Visible = false;
                    this.Lb_mngsectioncode.Visible = false;
                    this.Lb_custwarehousecd.Visible = false;

                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.officetelno.Visible = false;
                    this.portabletelno.Visible = false;
                    this.officefaxno.Visible = false;
                    this.totalday.Visible = false;
                    this.collectmoneynameday.Visible = false;
                    this.customeragentcd.Visible = false;
                    this.customeragentname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareaname.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypename.Visible = false;
                    this.claimsectioncode.Visible = false;
                    this.claimcode.Visible = false;
                    this.billcollectercd.Visible = false;
                    this.kana.Visible = false;
                    this.postno.Visible = false;
                    this.addressall.Visible = false;
                    this.mngsectioncode.Visible = false;
                    this.sectionguidesnm.Visible = false;
                    this.custwarehousecd.Visible = false;
                    #endregion  得意先一覧

                    #region 得意先住所録
                    this.Lb_customercode2.Visible = true;
                    this.Lb_kana2.Visible = true;
                    this.Lb_postno2.Visible = true;
                    this.Lb_address1.Visible = true;
                    this.Lb_address3.Visible = true;
                    this.Lb_address4.Visible = true;
                    this.Lb_officetelno2.Visible = true;
                    this.Lb_portabletelno2.Visible = true;
                    this.Lb_officefaxno2.Visible = true;
                    this.Lb_customeragentcd2.Visible = true;
                    this.Lb_name.Visible = true;
                    this.Lb_name2.Visible = true;
                    this.customercode2.Visible = true;
                    this.kana2.Visible = true;
                    this.postno2.Visible = true;
                    this.address1.Visible = true;
                    this.address3.Visible = true;
                    this.address4.Visible = true;
                    this.name.Visible = true;
                    this.name2.Visible = true;
                    this.officetelno2.Visible = true;
                    this.portabletelno2.Visible = true;
                    this.officefaxno2.Visible = true;
                    this.customeragentcd2.Visible = true;
                    this.customeragentname2.Visible = true;

                    this.Lb_customercode2.Top = this.Lb_customercode.Top;
                    this.Lb_name.Top = this.Lb_customercode.Top;
                    this.Lb_name2.Top = this.Lb_customercode.Top;
                    this.Lb_officetelno2.Top = this.Lb_customercode.Top;
                    this.Lb_portabletelno2.Top = this.Lb_customercode.Top;
                    this.Lb_officefaxno2.Top = this.Lb_customercode.Top;
                    this.Lb_customeragentcd2.Top = this.Lb_customercode.Top;
                    this.Lb_kana2.Top = this.Lb_kana.Top;
                    this.Lb_postno2.Top = this.Lb_kana.Top;
                    this.Lb_address1.Top = this.Lb_kana.Top;
                    this.Lb_address3.Top = this.Lb_kana.Top;
                    this.Lb_address4.Top = this.Lb_kana.Top;
                    this.customercode2.Top = this.customercode.Top;
                    this.name.Top = this.customercode.Top;
                    this.name2.Top = this.customercode.Top;
                    this.officetelno2.Top = this.customercode.Top;
                    this.portabletelno2.Top = this.customercode.Top;
                    this.officefaxno2.Top = this.customercode.Top;
                    this.customeragentcd2.Top = this.customercode.Top;
                    this.customeragentname2.Top = this.customercode.Top;
                    this.kana2.Top = this.kana.Top;
                    this.postno2.Top = this.kana.Top;
                    this.address1.Top = this.kana.Top;
                    this.address3.Top = this.kana.Top;
                    this.address4.Top = this.kana.Top;
                    #endregion 得意先住所録

                    #region 掛率グループ一覧
                    this.Lb_custrategrpcodeALL.Visible = false;
                    this.Lb_custrategrpcode00.Visible = false;
                    this.Lb_custrategrpcode01.Visible = false;
                    this.Lb_custrategrpcode02.Visible = false;
                    this.Lb_custrategrpcode03.Visible = false;
                    this.Lb_custrategrpcode04.Visible = false;
                    this.Lb_custrategrpcode05.Visible = false;
                    this.Lb_custrategrpcode06.Visible = false;
                    this.Lb_custrategrpcode07.Visible = false;
                    this.Lb_custrategrpcode08.Visible = false;
                    this.Lb_custrategrpcode09.Visible = false;
                    this.Lb_custrategrpcode10.Visible = false;
                    this.Lb_custrategrpcode11.Visible = false;
                    this.Lb_custrategrpcode12.Visible = false;
                    this.Lb_custrategrpcode13.Visible = false;
                    this.Lb_custrategrpcode14.Visible = false;
                    this.Lb_custrategrpcode15.Visible = false;
                    this.Lb_custrategrpcode16.Visible = false;
                    this.Lb_custrategrpcode17.Visible = false;
                    this.Lb_custrategrpcode18.Visible = false;
                    this.Lb_custrategrpcode19.Visible = false;
                    this.Lb_custrategrpcode20.Visible = false;
                    this.Lb_custrategrpcode21.Visible = false;
                    this.Lb_custrategrpcode22.Visible = false;
                    this.Lb_custrategrpcode23.Visible = false;
                    this.Lb_custrategrpcode24.Visible = false;
                    this.Lb_custrategrpcode25.Visible = false;
                    this.Lb_custrategrpcode00_2.Visible = false;
                    this.Lb_custrategrpcode01_2.Visible = false;
                    this.Lb_custrategrpcode02_2.Visible = false;
                    this.Lb_custrategrpcode03_2.Visible = false;
                    this.Lb_custrategrpcode04_2.Visible = false;
                    this.Lb_custrategrpcode05_2.Visible = false;
                    this.Lb_custrategrpcode06_2.Visible = false;
                    this.Lb_custrategrpcode07_2.Visible = false;
                    this.Lb_custrategrpcode08_2.Visible = false;
                    this.Lb_custrategrpcode09_2.Visible = false;
                    this.Lb_custrategrpcode10_2.Visible = false;
                    this.Lb_custrategrpcode11_2.Visible = false;
                    this.Lb_custrategrpcode12_2.Visible = false;
                    this.Lb_custrategrpcode13_2.Visible = false;
                    this.Lb_custrategrpcode14_2.Visible = false;
                    this.Lb_custrategrpcode15_2.Visible = false;
                    this.Lb_custrategrpcode16_2.Visible = false;
                    this.Lb_custrategrpcode17_2.Visible = false;
                    this.Lb_custrategrpcode18_2.Visible = false;
                    this.Lb_custrategrpcode19_2.Visible = false;
                    this.Lb_custrategrpcode20_2.Visible = false;
                    this.Lb_custrategrpcode21_2.Visible = false;
                    this.Lb_custrategrpcode22_2.Visible = false;
                    this.Lb_custrategrpcode23_2.Visible = false;
                    this.Lb_custrategrpcode24_2.Visible = false;
                    this.Lb_custrategrpcode25_2.Visible = false;

                    this.custrategrpcodeALL.Visible = false;
                    this.custrategrpcode00.Visible = false;
                    this.custrategrpcode01.Visible = false;
                    this.custrategrpcode02.Visible = false;
                    this.custrategrpcode03.Visible = false;
                    this.custrategrpcode04.Visible = false;
                    this.custrategrpcode05.Visible = false;
                    this.custrategrpcode06.Visible = false;
                    this.custrategrpcode07.Visible = false;
                    this.custrategrpcode08.Visible = false;
                    this.custrategrpcode09.Visible = false;
                    this.custrategrpcode10.Visible = false;
                    this.custrategrpcode11.Visible = false;
                    this.custrategrpcode12.Visible = false;
                    this.custrategrpcode13.Visible = false;
                    this.custrategrpcode14.Visible = false;
                    this.custrategrpcode15.Visible = false;
                    this.custrategrpcode16.Visible = false;
                    this.custrategrpcode17.Visible = false;
                    this.custrategrpcode18.Visible = false;
                    this.custrategrpcode19.Visible = false;
                    this.custrategrpcode20.Visible = false;
                    this.custrategrpcode21.Visible = false;
                    this.custrategrpcode22.Visible = false;
                    this.custrategrpcode23.Visible = false;
                    this.custrategrpcode24.Visible = false;
                    this.custrategrpcode25.Visible = false;
                    #endregion 掛率グループ一覧
                    break;
                case 2:

                    #region 得意先一覧
                    this.Lb_customercode.Visible = false;
                    this.Lb_officetelno.Visible = false;
                    this.Lb_portabletelno.Visible = false;
                    this.Lb_officefaxno.Visible = false;
                    this.Lb_totalday.Visible = false;
                    this.Lb_collectmoneynameday.Visible = false;
                    this.Lb_customeragentcd.Visible = false;
                    this.Lb_salesareacode.Visible = false;
                    this.Lb_businesstypecode.Visible = false;
                    this.Lb_claimsectioncode.Visible = false;
                    this.Lb_billcollectercd.Visible = false;
                    this.Lb_kana.Visible = false;
                    this.Lb_postno.Visible = false;
                    this.Lb_addressall.Visible = false;
                    this.Lb_mngsectioncode.Visible = false;
                    this.Lb_custwarehousecd.Visible = false;

                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.officetelno.Visible = false;
                    this.portabletelno.Visible = false;
                    this.officefaxno.Visible = false;
                    this.totalday.Visible = false;
                    this.collectmoneynameday.Visible = false;
                    this.customeragentcd.Visible = false;
                    this.customeragentname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareaname.Visible = false;
                    this.businesstypecode.Visible = false;
                    this.businesstypename.Visible = false;
                    this.claimsectioncode.Visible = false;
                    this.claimcode.Visible = false;
                    this.billcollectercd.Visible = false;
                    this.kana.Visible = false;
                    this.postno.Visible = false;
                    this.addressall.Visible = false;
                    this.mngsectioncode.Visible = false;
                    this.sectionguidesnm.Visible = false;
                    this.custwarehousecd.Visible = false;
                    #endregion  得意先一覧

                    #region 得意先住所録
                    this.Lb_customercode2.Visible = false;
                    this.Lb_kana2.Visible = false;
                    this.Lb_postno2.Visible = false;
                    this.Lb_address1.Visible = false;
                    this.Lb_address3.Visible = false;
                    this.Lb_address4.Visible = false;
                    this.Lb_officetelno2.Visible = false;
                    this.Lb_portabletelno2.Visible = false;
                    this.Lb_officefaxno2.Visible = false;
                    this.Lb_customeragentcd2.Visible = false;
                    this.Lb_name.Visible = false;
                    this.Lb_name2.Visible = false;
                    this.customercode2.Visible = false;
                    this.kana2.Visible = false;
                    this.postno2.Visible = false;
                    this.address1.Visible = false;
                    this.address3.Visible = false;
                    this.address4.Visible = false;
                    this.name.Visible = false;
                    this.name2.Visible = false;
                    this.officetelno2.Visible = false;
                    this.portabletelno2.Visible = false;
                    this.officefaxno2.Visible = false;
                    this.customeragentcd2.Visible = false;
                    this.customeragentname2.Visible = false;
                    #endregion 得意先住所録


                    #region 掛率グループ一覧
                    this.Lb_customercode.Visible = true;
                    this.customercode.Visible = true;
                    this.customersnm.Visible = true;

                    this.Lb_custrategrpcodeALL.Visible = true;
                    this.Lb_custrategrpcode00.Visible = true;
                    this.Lb_custrategrpcode01.Visible = true;
                    this.Lb_custrategrpcode02.Visible = true;
                    this.Lb_custrategrpcode03.Visible = true;
                    this.Lb_custrategrpcode04.Visible = true;
                    this.Lb_custrategrpcode05.Visible = true;
                    this.Lb_custrategrpcode06.Visible = true;
                    this.Lb_custrategrpcode07.Visible = true;
                    this.Lb_custrategrpcode08.Visible = true;
                    this.Lb_custrategrpcode09.Visible = true;
                    this.Lb_custrategrpcode10.Visible = true;
                    this.Lb_custrategrpcode11.Visible = true;
                    this.Lb_custrategrpcode12.Visible = true;
                    this.Lb_custrategrpcode13.Visible = true;
                    this.Lb_custrategrpcode14.Visible = true;
                    this.Lb_custrategrpcode15.Visible = true;
                    this.Lb_custrategrpcode16.Visible = true;
                    this.Lb_custrategrpcode17.Visible = true;
                    this.Lb_custrategrpcode18.Visible = true;
                    this.Lb_custrategrpcode19.Visible = true;
                    this.Lb_custrategrpcode20.Visible = true;
                    this.Lb_custrategrpcode21.Visible = true;
                    this.Lb_custrategrpcode22.Visible = true;
                    this.Lb_custrategrpcode23.Visible = true;
                    this.Lb_custrategrpcode24.Visible = true;
                    this.Lb_custrategrpcode25.Visible = true;
                    this.Lb_custrategrpcode00_2.Visible = true;
                    this.Lb_custrategrpcode01_2.Visible = true;
                    this.Lb_custrategrpcode02_2.Visible = true;
                    this.Lb_custrategrpcode03_2.Visible = true;
                    this.Lb_custrategrpcode04_2.Visible = true;
                    this.Lb_custrategrpcode05_2.Visible = true;
                    this.Lb_custrategrpcode06_2.Visible = true;
                    this.Lb_custrategrpcode07_2.Visible = true;
                    this.Lb_custrategrpcode08_2.Visible = true;
                    this.Lb_custrategrpcode09_2.Visible = true;
                    this.Lb_custrategrpcode10_2.Visible = true;
                    this.Lb_custrategrpcode11_2.Visible = true;
                    this.Lb_custrategrpcode12_2.Visible = true;
                    this.Lb_custrategrpcode13_2.Visible = true;
                    this.Lb_custrategrpcode14_2.Visible = true;
                    this.Lb_custrategrpcode15_2.Visible = true;
                    this.Lb_custrategrpcode16_2.Visible = true;
                    this.Lb_custrategrpcode17_2.Visible = true;
                    this.Lb_custrategrpcode18_2.Visible = true;
                    this.Lb_custrategrpcode19_2.Visible = true;
                    this.Lb_custrategrpcode20_2.Visible = true;
                    this.Lb_custrategrpcode21_2.Visible = true;
                    this.Lb_custrategrpcode22_2.Visible = true;
                    this.Lb_custrategrpcode23_2.Visible = true;
                    this.Lb_custrategrpcode24_2.Visible = true;
                    this.Lb_custrategrpcode25_2.Visible = true;

                    this.custrategrpcodeALL.Visible = true;
                    this.custrategrpcode00.Visible = true;
                    this.custrategrpcode01.Visible = true;
                    this.custrategrpcode02.Visible = true;
                    this.custrategrpcode03.Visible = true;
                    this.custrategrpcode04.Visible = true;
                    this.custrategrpcode05.Visible = true;
                    this.custrategrpcode06.Visible = true;
                    this.custrategrpcode07.Visible = true;
                    this.custrategrpcode08.Visible = true;
                    this.custrategrpcode09.Visible = true;
                    this.custrategrpcode10.Visible = true;
                    this.custrategrpcode11.Visible = true;
                    this.custrategrpcode12.Visible = true;
                    this.custrategrpcode13.Visible = true;
                    this.custrategrpcode14.Visible = true;
                    this.custrategrpcode15.Visible = true;
                    this.custrategrpcode16.Visible = true;
                    this.custrategrpcode17.Visible = true;
                    this.custrategrpcode18.Visible = true;
                    this.custrategrpcode19.Visible = true;
                    this.custrategrpcode20.Visible = true;
                    this.custrategrpcode21.Visible = true;
                    this.custrategrpcode22.Visible = true;
                    this.custrategrpcode23.Visible = true;
                    this.custrategrpcode24.Visible = true;
                    this.custrategrpcode25.Visible = true;

                    this.Lb_custrategrpcodeALL.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode00.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode01.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode02.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode03.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode04.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode05.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode06.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode07.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode08.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode09.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode10.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode11.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode12.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode13.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode14.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode15.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode16.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode17.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode18.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode19.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode20.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode21.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode22.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode23.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode24.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode25.Top = this.Lb_customercode.Top;
                    this.Lb_custrategrpcode00_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode01_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode02_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode03_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode04_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode05_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode06_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode07_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode08_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode09_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode10_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode11_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode12_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode13_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode14_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode15_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode16_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode17_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode18_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode19_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode20_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode21_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode22_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode23_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode24_2.Top = this.Lb_customercode.Top + (float)0.15;
                    this.Lb_custrategrpcode25_2.Top = this.Lb_customercode.Top + (float)0.15;

                    this.custrategrpcodeALL.Top = this.customercode.Top;
                    this.custrategrpcode00.Top = this.customercode.Top;
                    this.custrategrpcode01.Top = this.customercode.Top;
                    this.custrategrpcode02.Top = this.customercode.Top;
                    this.custrategrpcode03.Top = this.customercode.Top;
                    this.custrategrpcode04.Top = this.customercode.Top;
                    this.custrategrpcode05.Top = this.customercode.Top;
                    this.custrategrpcode06.Top = this.customercode.Top;
                    this.custrategrpcode07.Top = this.customercode.Top;
                    this.custrategrpcode08.Top = this.customercode.Top;
                    this.custrategrpcode09.Top = this.customercode.Top;
                    this.custrategrpcode10.Top = this.customercode.Top;
                    this.custrategrpcode11.Top = this.customercode.Top;
                    this.custrategrpcode12.Top = this.customercode.Top;
                    this.custrategrpcode13.Top = this.customercode.Top;
                    this.custrategrpcode14.Top = this.customercode.Top;
                    this.custrategrpcode15.Top = this.customercode.Top;
                    this.custrategrpcode16.Top = this.customercode.Top;
                    this.custrategrpcode17.Top = this.customercode.Top;
                    this.custrategrpcode18.Top = this.customercode.Top;
                    this.custrategrpcode19.Top = this.customercode.Top;
                    this.custrategrpcode20.Top = this.customercode.Top;
                    this.custrategrpcode21.Top = this.customercode.Top;
                    this.custrategrpcode22.Top = this.customercode.Top;
                    this.custrategrpcode23.Top = this.customercode.Top;
                    this.custrategrpcode24.Top = this.customercode.Top;
                    this.custrategrpcode25.Top = this.customercode.Top;

                    this.Lb_custrategrpcode01_2.Text = this._customerPrintWork.CustRateGrpName01;
                    this.Lb_custrategrpcode02_2.Text = this._customerPrintWork.CustRateGrpName02;
                    this.Lb_custrategrpcode03_2.Text = this._customerPrintWork.CustRateGrpName03;
                    this.Lb_custrategrpcode04_2.Text = this._customerPrintWork.CustRateGrpName04;
                    this.Lb_custrategrpcode05_2.Text = this._customerPrintWork.CustRateGrpName05;
                    this.Lb_custrategrpcode06_2.Text = this._customerPrintWork.CustRateGrpName06;
                    this.Lb_custrategrpcode07_2.Text = this._customerPrintWork.CustRateGrpName07;
                    this.Lb_custrategrpcode08_2.Text = this._customerPrintWork.CustRateGrpName08;
                    this.Lb_custrategrpcode09_2.Text = this._customerPrintWork.CustRateGrpName09;
                    this.Lb_custrategrpcode10_2.Text = this._customerPrintWork.CustRateGrpName10;
                    this.Lb_custrategrpcode11_2.Text = this._customerPrintWork.CustRateGrpName11;
                    this.Lb_custrategrpcode12_2.Text = this._customerPrintWork.CustRateGrpName12;
                    this.Lb_custrategrpcode13_2.Text = this._customerPrintWork.CustRateGrpName13;
                    this.Lb_custrategrpcode14_2.Text = this._customerPrintWork.CustRateGrpName14;
                    this.Lb_custrategrpcode15_2.Text = this._customerPrintWork.CustRateGrpName15;
                    this.Lb_custrategrpcode16_2.Text = this._customerPrintWork.CustRateGrpName16;
                    this.Lb_custrategrpcode17_2.Text = this._customerPrintWork.CustRateGrpName17;
                    this.Lb_custrategrpcode18_2.Text = this._customerPrintWork.CustRateGrpName18;
                    this.Lb_custrategrpcode19_2.Text = this._customerPrintWork.CustRateGrpName19;
                    this.Lb_custrategrpcode20_2.Text = this._customerPrintWork.CustRateGrpName20;
                    this.Lb_custrategrpcode21_2.Text = this._customerPrintWork.CustRateGrpName21;
                    this.Lb_custrategrpcode22_2.Text = this._customerPrintWork.CustRateGrpName22;
                    this.Lb_custrategrpcode23_2.Text = this._customerPrintWork.CustRateGrpName23;
                    this.Lb_custrategrpcode24_2.Text = this._customerPrintWork.CustRateGrpName24;
                    this.Lb_custrategrpcode25_2.Text = this._customerPrintWork.CustRateGrpName25;
                    #endregion 掛率グループ一覧
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

		#region ◎ PMKHN08555P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08555P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08555P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08555P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08555P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08555P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08555P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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

            string str_sort="";
            switch (this._customerPrintWork.Sort)
            {
                case 0:
                    str_sort = "コード順";
                    break;
                case 1:
                    str_sort = "カナ順";
                    break;
                case 2:
                    str_sort = "拠点順";
                    break;
                case 3:
                    str_sort = "担当者順";
                    break;
                case 4:
                    str_sort = "地区順";
                    break;
                case 5:
                    str_sort = "業種順";
                    break;
            }
            this.SORTTITLE.Text = str_sort;
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
            switch (this._customerPrintWork.PrintType)
            {
                case 0:
                    if (this.totalday.Value != null)
                    {
                        if ((int)this.totalday.Value != 0)
                        {
                            this.totalday.Text = this.totalday.Value + "日";
                        }
                    }
                    if (this.collectmoneynameday.Text != null)
                    {
                        if (!this.collectmoneynameday.Text.Trim().Equals(string.Empty))
                        {
                            this.collectmoneynameday.Text = this.collectmoneynameday.Text + "日";
                        }
                    }
                    break;
            }
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08555P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.kana = new DataDynamics.ActiveReports.TextBox();
            this.customercode = new DataDynamics.ActiveReports.TextBox();
            this.customersnm = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.officetelno = new DataDynamics.ActiveReports.TextBox();
            this.portabletelno = new DataDynamics.ActiveReports.TextBox();
            this.officefaxno = new DataDynamics.ActiveReports.TextBox();
            this.totalday = new DataDynamics.ActiveReports.TextBox();
            this.collectmoneynameday = new DataDynamics.ActiveReports.TextBox();
            this.customeragentcd = new DataDynamics.ActiveReports.TextBox();
            this.customeragentname = new DataDynamics.ActiveReports.TextBox();
            this.salesareacode = new DataDynamics.ActiveReports.TextBox();
            this.salesareaname = new DataDynamics.ActiveReports.TextBox();
            this.businesstypecode = new DataDynamics.ActiveReports.TextBox();
            this.businesstypename = new DataDynamics.ActiveReports.TextBox();
            this.claimsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.claimcode = new DataDynamics.ActiveReports.TextBox();
            this.billcollectercd = new DataDynamics.ActiveReports.TextBox();
            this.postno = new DataDynamics.ActiveReports.TextBox();
            this.addressall = new DataDynamics.ActiveReports.TextBox();
            this.mngsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.sectionguidesnm = new DataDynamics.ActiveReports.TextBox();
            this.custwarehousecd = new DataDynamics.ActiveReports.TextBox();
            this.name = new DataDynamics.ActiveReports.TextBox();
            this.name2 = new DataDynamics.ActiveReports.TextBox();
            this.officetelno2 = new DataDynamics.ActiveReports.TextBox();
            this.portabletelno2 = new DataDynamics.ActiveReports.TextBox();
            this.officefaxno2 = new DataDynamics.ActiveReports.TextBox();
            this.customeragentcd2 = new DataDynamics.ActiveReports.TextBox();
            this.customeragentname2 = new DataDynamics.ActiveReports.TextBox();
            this.address4 = new DataDynamics.ActiveReports.TextBox();
            this.address1 = new DataDynamics.ActiveReports.TextBox();
            this.address3 = new DataDynamics.ActiveReports.TextBox();
            this.customercode2 = new DataDynamics.ActiveReports.TextBox();
            this.kana2 = new DataDynamics.ActiveReports.TextBox();
            this.postno2 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode11 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode12 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode13 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode14 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode15 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode20 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode19 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode18 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode17 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode16 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode25 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode24 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode23 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode22 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode21 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode10 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode09 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode08 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode07 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode06 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode05 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode04 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode03 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode02 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode01 = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcodeALL = new DataDynamics.ActiveReports.TextBox();
            this.custrategrpcode00 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Lb_customercode = new DataDynamics.ActiveReports.Label();
            this.Lb_kana = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_postno = new DataDynamics.ActiveReports.Label();
            this.Lb_officetelno = new DataDynamics.ActiveReports.Label();
            this.Lb_totalday = new DataDynamics.ActiveReports.Label();
            this.Lb_collectmoneynameday = new DataDynamics.ActiveReports.Label();
            this.Lb_businesstypecode = new DataDynamics.ActiveReports.Label();
            this.Lb_claimsectioncode = new DataDynamics.ActiveReports.Label();
            this.Lb_addressall = new DataDynamics.ActiveReports.Label();
            this.Lb_customeragentcd = new DataDynamics.ActiveReports.Label();
            this.Lb_mngsectioncode = new DataDynamics.ActiveReports.Label();
            this.Lb_salesareacode = new DataDynamics.ActiveReports.Label();
            this.Lb_billcollectercd = new DataDynamics.ActiveReports.Label();
            this.Lb_portabletelno = new DataDynamics.ActiveReports.Label();
            this.Lb_officefaxno = new DataDynamics.ActiveReports.Label();
            this.Lb_custwarehousecd = new DataDynamics.ActiveReports.Label();
            this.Lb_name = new DataDynamics.ActiveReports.Label();
            this.Lb_name2 = new DataDynamics.ActiveReports.Label();
            this.Lb_customercode2 = new DataDynamics.ActiveReports.Label();
            this.Lb_kana2 = new DataDynamics.ActiveReports.Label();
            this.Lb_postno2 = new DataDynamics.ActiveReports.Label();
            this.Lb_address1 = new DataDynamics.ActiveReports.Label();
            this.Lb_address3 = new DataDynamics.ActiveReports.Label();
            this.Lb_address4 = new DataDynamics.ActiveReports.Label();
            this.Lb_officetelno2 = new DataDynamics.ActiveReports.Label();
            this.Lb_portabletelno2 = new DataDynamics.ActiveReports.Label();
            this.Lb_officefaxno2 = new DataDynamics.ActiveReports.Label();
            this.Lb_customeragentcd2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcodeALL = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode00 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode01 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode02 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode03 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode04 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode05 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode06 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode07 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode08 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode09 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode10 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode11 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode12 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode13 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode14 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode15 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode16 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode17 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode18 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode19 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode20 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode21 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode22 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode23 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode24 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode25 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode01_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode02_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode03_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode04_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode05_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode06_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode07_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode08_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode09_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode10_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode11_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode12_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode13_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode14_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode15_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode16_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode17_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode18_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode19_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode20_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode21_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode22_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode23_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode24_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode25_2 = new DataDynamics.ActiveReports.Label();
            this.Lb_custrategrpcode00_2 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.kana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customercode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officetelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portabletelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officefaxno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectmoneynameday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentcd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareacode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareaname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claimsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claimcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billcollectercd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidesnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custwarehousecd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.name2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officetelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portabletelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officefaxno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentcd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentname2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customercode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kana2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcodeALL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customercode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_kana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_postno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officetelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_totalday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_collectmoneynameday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_businesstypecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_claimsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_addressall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customeragentcd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_mngsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_salesareacode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_billcollectercd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_portabletelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officefaxno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custwarehousecd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_name2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customercode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_kana2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_postno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_address1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_address3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_address4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officetelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_portabletelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officefaxno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customeragentcd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcodeALL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode01_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode02_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode03_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode04_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode05_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode06_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode07_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode08_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode09_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode10_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode11_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode12_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode13_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode14_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode15_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode16_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode17_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode18_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode19_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode20_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode21_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode22_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode23_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode24_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode25_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode00_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.kana,
            this.customercode,
            this.customersnm,
            this.line3,
            this.officetelno,
            this.portabletelno,
            this.officefaxno,
            this.totalday,
            this.collectmoneynameday,
            this.customeragentcd,
            this.customeragentname,
            this.salesareacode,
            this.salesareaname,
            this.businesstypecode,
            this.businesstypename,
            this.claimsectioncode,
            this.claimcode,
            this.billcollectercd,
            this.postno,
            this.addressall,
            this.mngsectioncode,
            this.sectionguidesnm,
            this.custwarehousecd,
            this.name,
            this.name2,
            this.officetelno2,
            this.portabletelno2,
            this.officefaxno2,
            this.customeragentcd2,
            this.customeragentname2,
            this.address4,
            this.address1,
            this.address3,
            this.customercode2,
            this.kana2,
            this.postno2,
            this.custrategrpcode11,
            this.custrategrpcode12,
            this.custrategrpcode13,
            this.custrategrpcode14,
            this.custrategrpcode15,
            this.custrategrpcode20,
            this.custrategrpcode19,
            this.custrategrpcode18,
            this.custrategrpcode17,
            this.custrategrpcode16,
            this.custrategrpcode25,
            this.custrategrpcode24,
            this.custrategrpcode23,
            this.custrategrpcode22,
            this.custrategrpcode21,
            this.custrategrpcode10,
            this.custrategrpcode09,
            this.custrategrpcode08,
            this.custrategrpcode07,
            this.custrategrpcode06,
            this.custrategrpcode05,
            this.custrategrpcode04,
            this.custrategrpcode03,
            this.custrategrpcode02,
            this.custrategrpcode01,
            this.custrategrpcodeALL,
            this.custrategrpcode00});
            this.Detail.Height = 1.175F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // kana
            // 
            this.kana.Border.BottomColor = System.Drawing.Color.Black;
            this.kana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.Border.LeftColor = System.Drawing.Color.Black;
            this.kana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.Border.RightColor = System.Drawing.Color.Black;
            this.kana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.Border.TopColor = System.Drawing.Color.Black;
            this.kana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.DataField = "kana";
            this.kana.Height = 0.15F;
            this.kana.Left = 0.4999996F;
            this.kana.MultiLine = false;
            this.kana.Name = "kana";
            this.kana.OutputFormat = resources.GetString("kana.OutputFormat");
            this.kana.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.kana.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.kana.Top = 0.1916666F;
            this.kana.Width = 1.7F;
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
            this.customercode.Left = 0F;
            this.customercode.MultiLine = false;
            this.customercode.Name = "customercode";
            this.customercode.OutputFormat = resources.GetString("customercode.OutputFormat");
            this.customercode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.customercode.Text = "12345678";
            this.customercode.Top = 0.02083333F;
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
            this.customersnm.Left = 0.4999996F;
            this.customersnm.MultiLine = false;
            this.customersnm.Name = "customersnm";
            this.customersnm.OutputFormat = resources.GetString("customersnm.OutputFormat");
            this.customersnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.customersnm.Text = "あいうえおかきくけこあいうえお";
            this.customersnm.Top = 0.02083333F;
            this.customersnm.Width = 1.75F;
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
            this.line3.Top = 0.3541667F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.3541667F;
            this.line3.Y2 = 0.3541667F;
            // 
            // officetelno
            // 
            this.officetelno.Border.BottomColor = System.Drawing.Color.Black;
            this.officetelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno.Border.LeftColor = System.Drawing.Color.Black;
            this.officetelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno.Border.RightColor = System.Drawing.Color.Black;
            this.officetelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno.Border.TopColor = System.Drawing.Color.Black;
            this.officetelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno.DataField = "officetelno";
            this.officetelno.Height = 0.15F;
            this.officetelno.Left = 2.251964F;
            this.officetelno.MultiLine = false;
            this.officetelno.Name = "officetelno";
            this.officetelno.OutputFormat = resources.GetString("officetelno.OutputFormat");
            this.officetelno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.officetelno.Text = "1234567890123456";
            this.officetelno.Top = 0.02083333F;
            this.officetelno.Width = 0.92F;
            // 
            // portabletelno
            // 
            this.portabletelno.Border.BottomColor = System.Drawing.Color.Black;
            this.portabletelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.Border.LeftColor = System.Drawing.Color.Black;
            this.portabletelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.Border.RightColor = System.Drawing.Color.Black;
            this.portabletelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.Border.TopColor = System.Drawing.Color.Black;
            this.portabletelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.DataField = "portabletelno";
            this.portabletelno.Height = 0.15F;
            this.portabletelno.Left = 3.223928F;
            this.portabletelno.MultiLine = false;
            this.portabletelno.Name = "portabletelno";
            this.portabletelno.OutputFormat = resources.GetString("portabletelno.OutputFormat");
            this.portabletelno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.portabletelno.Text = "1234567890123456";
            this.portabletelno.Top = 0.02083333F;
            this.portabletelno.Width = 0.92F;
            // 
            // officefaxno
            // 
            this.officefaxno.Border.BottomColor = System.Drawing.Color.Black;
            this.officefaxno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno.Border.LeftColor = System.Drawing.Color.Black;
            this.officefaxno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno.Border.RightColor = System.Drawing.Color.Black;
            this.officefaxno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno.Border.TopColor = System.Drawing.Color.Black;
            this.officefaxno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno.DataField = "officefaxno";
            this.officefaxno.Height = 0.15F;
            this.officefaxno.Left = 4.195893F;
            this.officefaxno.MultiLine = false;
            this.officefaxno.Name = "officefaxno";
            this.officefaxno.OutputFormat = resources.GetString("officefaxno.OutputFormat");
            this.officefaxno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.officefaxno.Text = "1234567890123456";
            this.officefaxno.Top = 0.02083333F;
            this.officefaxno.Width = 0.92F;
            // 
            // totalday
            // 
            this.totalday.Border.BottomColor = System.Drawing.Color.Black;
            this.totalday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.totalday.Border.LeftColor = System.Drawing.Color.Black;
            this.totalday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.totalday.Border.RightColor = System.Drawing.Color.Black;
            this.totalday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.totalday.Border.TopColor = System.Drawing.Color.Black;
            this.totalday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.totalday.DataField = "totalday";
            this.totalday.Height = 0.15F;
            this.totalday.Left = 5.167857F;
            this.totalday.MultiLine = false;
            this.totalday.Name = "totalday";
            this.totalday.OutputFormat = resources.GetString("totalday.OutputFormat");
            this.totalday.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.totalday.Text = "99日";
            this.totalday.Top = 0.02083333F;
            this.totalday.Width = 0.27F;
            // 
            // collectmoneynameday
            // 
            this.collectmoneynameday.Border.BottomColor = System.Drawing.Color.Black;
            this.collectmoneynameday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.collectmoneynameday.Border.LeftColor = System.Drawing.Color.Black;
            this.collectmoneynameday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.collectmoneynameday.Border.RightColor = System.Drawing.Color.Black;
            this.collectmoneynameday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.collectmoneynameday.Border.TopColor = System.Drawing.Color.Black;
            this.collectmoneynameday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.collectmoneynameday.DataField = "collectmoneynameday";
            this.collectmoneynameday.Height = 0.15F;
            this.collectmoneynameday.Left = 5.489821F;
            this.collectmoneynameday.MultiLine = false;
            this.collectmoneynameday.Name = "collectmoneynameday";
            this.collectmoneynameday.OutputFormat = resources.GetString("collectmoneynameday.OutputFormat");
            this.collectmoneynameday.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.collectmoneynameday.Text = "あいう99日";
            this.collectmoneynameday.Top = 0.02083333F;
            this.collectmoneynameday.Width = 0.59F;
            // 
            // customeragentcd
            // 
            this.customeragentcd.Border.BottomColor = System.Drawing.Color.Black;
            this.customeragentcd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd.Border.LeftColor = System.Drawing.Color.Black;
            this.customeragentcd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd.Border.RightColor = System.Drawing.Color.Black;
            this.customeragentcd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd.Border.TopColor = System.Drawing.Color.Black;
            this.customeragentcd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd.DataField = "customeragentcd";
            this.customeragentcd.Height = 0.15F;
            this.customeragentcd.Left = 6.131786F;
            this.customeragentcd.MultiLine = false;
            this.customeragentcd.Name = "customeragentcd";
            this.customeragentcd.OutputFormat = resources.GetString("customeragentcd.OutputFormat");
            this.customeragentcd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.customeragentcd.Text = "1234";
            this.customeragentcd.Top = 0.02083333F;
            this.customeragentcd.Width = 0.25F;
            // 
            // customeragentname
            // 
            this.customeragentname.Border.BottomColor = System.Drawing.Color.Black;
            this.customeragentname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname.Border.LeftColor = System.Drawing.Color.Black;
            this.customeragentname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname.Border.RightColor = System.Drawing.Color.Black;
            this.customeragentname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname.Border.TopColor = System.Drawing.Color.Black;
            this.customeragentname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname.DataField = "customeragentname";
            this.customeragentname.Height = 0.15F;
            this.customeragentname.Left = 6.43375F;
            this.customeragentname.MultiLine = false;
            this.customeragentname.Name = "customeragentname";
            this.customeragentname.OutputFormat = resources.GetString("customeragentname.OutputFormat");
            this.customeragentname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.customeragentname.Text = "あいうえおかき";
            this.customeragentname.Top = 0.02083333F;
            this.customeragentname.Width = 0.8124996F;
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
            this.salesareacode.Left = 7.298214F;
            this.salesareacode.MultiLine = false;
            this.salesareacode.Name = "salesareacode";
            this.salesareacode.OutputFormat = resources.GetString("salesareacode.OutputFormat");
            this.salesareacode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.salesareacode.Text = "1234";
            this.salesareacode.Top = 0.02083333F;
            this.salesareacode.Width = 0.25F;
            // 
            // salesareaname
            // 
            this.salesareaname.Border.BottomColor = System.Drawing.Color.Black;
            this.salesareaname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareaname.Border.LeftColor = System.Drawing.Color.Black;
            this.salesareaname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareaname.Border.RightColor = System.Drawing.Color.Black;
            this.salesareaname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareaname.Border.TopColor = System.Drawing.Color.Black;
            this.salesareaname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesareaname.DataField = "salesareaname";
            this.salesareaname.Height = 0.15F;
            this.salesareaname.Left = 7.600178F;
            this.salesareaname.MultiLine = false;
            this.salesareaname.Name = "salesareaname";
            this.salesareaname.OutputFormat = resources.GetString("salesareaname.OutputFormat");
            this.salesareaname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.salesareaname.Text = "あいうえおかき";
            this.salesareaname.Top = 0.02083333F;
            this.salesareaname.Width = 0.8124996F;
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
            this.businesstypecode.Left = 8.464643F;
            this.businesstypecode.MultiLine = false;
            this.businesstypecode.Name = "businesstypecode";
            this.businesstypecode.OutputFormat = resources.GetString("businesstypecode.OutputFormat");
            this.businesstypecode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.businesstypecode.Text = "1234";
            this.businesstypecode.Top = 0.02083333F;
            this.businesstypecode.Width = 0.25F;
            // 
            // businesstypename
            // 
            this.businesstypename.Border.BottomColor = System.Drawing.Color.Black;
            this.businesstypename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypename.Border.LeftColor = System.Drawing.Color.Black;
            this.businesstypename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypename.Border.RightColor = System.Drawing.Color.Black;
            this.businesstypename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypename.Border.TopColor = System.Drawing.Color.Black;
            this.businesstypename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.businesstypename.DataField = "businesstypename";
            this.businesstypename.Height = 0.15F;
            this.businesstypename.Left = 8.766607F;
            this.businesstypename.MultiLine = false;
            this.businesstypename.Name = "businesstypename";
            this.businesstypename.OutputFormat = resources.GetString("businesstypename.OutputFormat");
            this.businesstypename.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.businesstypename.Text = "あいうえおかき";
            this.businesstypename.Top = 0.02083333F;
            this.businesstypename.Width = 0.8124996F;
            // 
            // claimsectioncode
            // 
            this.claimsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.claimsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.claimsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.claimsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.claimsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimsectioncode.DataField = "claimsectioncode";
            this.claimsectioncode.Height = 0.15F;
            this.claimsectioncode.Left = 9.631071F;
            this.claimsectioncode.MultiLine = false;
            this.claimsectioncode.Name = "claimsectioncode";
            this.claimsectioncode.OutputFormat = resources.GetString("claimsectioncode.OutputFormat");
            this.claimsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.claimsectioncode.Text = "12";
            this.claimsectioncode.Top = 0.02083333F;
            this.claimsectioncode.Width = 0.14F;
            // 
            // claimcode
            // 
            this.claimcode.Border.BottomColor = System.Drawing.Color.Black;
            this.claimcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimcode.Border.LeftColor = System.Drawing.Color.Black;
            this.claimcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimcode.Border.RightColor = System.Drawing.Color.Black;
            this.claimcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimcode.Border.TopColor = System.Drawing.Color.Black;
            this.claimcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.claimcode.DataField = "claimcode";
            this.claimcode.Height = 0.15F;
            this.claimcode.Left = 9.823035F;
            this.claimcode.MultiLine = false;
            this.claimcode.Name = "claimcode";
            this.claimcode.OutputFormat = resources.GetString("claimcode.OutputFormat");
            this.claimcode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.claimcode.Text = "12345678";
            this.claimcode.Top = 0.02083333F;
            this.claimcode.Width = 0.5F;
            // 
            // billcollectercd
            // 
            this.billcollectercd.Border.BottomColor = System.Drawing.Color.Black;
            this.billcollectercd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.billcollectercd.Border.LeftColor = System.Drawing.Color.Black;
            this.billcollectercd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.billcollectercd.Border.RightColor = System.Drawing.Color.Black;
            this.billcollectercd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.billcollectercd.Border.TopColor = System.Drawing.Color.Black;
            this.billcollectercd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.billcollectercd.DataField = "billcollectercd";
            this.billcollectercd.Height = 0.15F;
            this.billcollectercd.Left = 10.42708F;
            this.billcollectercd.MultiLine = false;
            this.billcollectercd.Name = "billcollectercd";
            this.billcollectercd.OutputFormat = resources.GetString("billcollectercd.OutputFormat");
            this.billcollectercd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.billcollectercd.Text = "1234";
            this.billcollectercd.Top = 0.02083333F;
            this.billcollectercd.Width = 0.25F;
            // 
            // postno
            // 
            this.postno.Border.BottomColor = System.Drawing.Color.Black;
            this.postno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.Border.LeftColor = System.Drawing.Color.Black;
            this.postno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.Border.RightColor = System.Drawing.Color.Black;
            this.postno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.Border.TopColor = System.Drawing.Color.Black;
            this.postno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.DataField = "postno";
            this.postno.Height = 0.15F;
            this.postno.Left = 2.25F;
            this.postno.MultiLine = false;
            this.postno.Name = "postno";
            this.postno.OutputFormat = resources.GetString("postno.OutputFormat");
            this.postno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.postno.Text = "1234567890";
            this.postno.Top = 0.1916666F;
            this.postno.Width = 0.6F;
            // 
            // addressall
            // 
            this.addressall.Border.BottomColor = System.Drawing.Color.Black;
            this.addressall.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.addressall.Border.LeftColor = System.Drawing.Color.Black;
            this.addressall.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.addressall.Border.RightColor = System.Drawing.Color.Black;
            this.addressall.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.addressall.Border.TopColor = System.Drawing.Color.Black;
            this.addressall.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.addressall.DataField = "addressall";
            this.addressall.Height = 0.15F;
            this.addressall.Left = 2.875F;
            this.addressall.MultiLine = false;
            this.addressall.Name = "addressall";
            this.addressall.OutputFormat = resources.GetString("addressall.OutputFormat");
            this.addressall.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.addressall.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.addressall.Top = 0.1916666F;
            this.addressall.Width = 6.2F;
            // 
            // mngsectioncode
            // 
            this.mngsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.DataField = "mngsectioncode";
            this.mngsectioncode.Height = 0.15F;
            this.mngsectioncode.Left = 9.062499F;
            this.mngsectioncode.MultiLine = false;
            this.mngsectioncode.Name = "mngsectioncode";
            this.mngsectioncode.OutputFormat = resources.GetString("mngsectioncode.OutputFormat");
            this.mngsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.mngsectioncode.Text = "1234";
            this.mngsectioncode.Top = 0.1916666F;
            this.mngsectioncode.Width = 0.17F;
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
            this.sectionguidesnm.Left = 9.25F;
            this.sectionguidesnm.MultiLine = false;
            this.sectionguidesnm.Name = "sectionguidesnm";
            this.sectionguidesnm.OutputFormat = resources.GetString("sectionguidesnm.OutputFormat");
            this.sectionguidesnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sectionguidesnm.Text = "あいうえおかきくけこ";
            this.sectionguidesnm.Top = 0.1916666F;
            this.sectionguidesnm.Width = 1.15F;
            // 
            // custwarehousecd
            // 
            this.custwarehousecd.Border.BottomColor = System.Drawing.Color.Black;
            this.custwarehousecd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custwarehousecd.Border.LeftColor = System.Drawing.Color.Black;
            this.custwarehousecd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custwarehousecd.Border.RightColor = System.Drawing.Color.Black;
            this.custwarehousecd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custwarehousecd.Border.TopColor = System.Drawing.Color.Black;
            this.custwarehousecd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custwarehousecd.DataField = "custwarehousecd";
            this.custwarehousecd.Height = 0.15F;
            this.custwarehousecd.Left = 10.42708F;
            this.custwarehousecd.MultiLine = false;
            this.custwarehousecd.Name = "custwarehousecd";
            this.custwarehousecd.OutputFormat = resources.GetString("custwarehousecd.OutputFormat");
            this.custwarehousecd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.custwarehousecd.Text = "1234";
            this.custwarehousecd.Top = 0.1916666F;
            this.custwarehousecd.Width = 0.25F;
            // 
            // name
            // 
            this.name.Border.BottomColor = System.Drawing.Color.Black;
            this.name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.Border.LeftColor = System.Drawing.Color.Black;
            this.name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.Border.RightColor = System.Drawing.Color.Black;
            this.name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.Border.TopColor = System.Drawing.Color.Black;
            this.name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.DataField = "name";
            this.name.Height = 0.15F;
            this.name.Left = 0.5F;
            this.name.MultiLine = false;
            this.name.Name = "name";
            this.name.OutputFormat = resources.GetString("name.OutputFormat");
            this.name.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.name.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.name.Top = 0.375F;
            this.name.Width = 3F;
            // 
            // name2
            // 
            this.name2.Border.BottomColor = System.Drawing.Color.Black;
            this.name2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name2.Border.LeftColor = System.Drawing.Color.Black;
            this.name2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name2.Border.RightColor = System.Drawing.Color.Black;
            this.name2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name2.Border.TopColor = System.Drawing.Color.Black;
            this.name2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name2.DataField = "name2";
            this.name2.Height = 0.15F;
            this.name2.Left = 3.499999F;
            this.name2.MultiLine = false;
            this.name2.Name = "name2";
            this.name2.OutputFormat = resources.GetString("name2.OutputFormat");
            this.name2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.name2.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.name2.Top = 0.375F;
            this.name2.Width = 3F;
            // 
            // officetelno2
            // 
            this.officetelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.officetelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.officetelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno2.Border.RightColor = System.Drawing.Color.Black;
            this.officetelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno2.Border.TopColor = System.Drawing.Color.Black;
            this.officetelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officetelno2.DataField = "officetelno";
            this.officetelno2.Height = 0.15F;
            this.officetelno2.Left = 6.541667F;
            this.officetelno2.MultiLine = false;
            this.officetelno2.Name = "officetelno2";
            this.officetelno2.OutputFormat = resources.GetString("officetelno2.OutputFormat");
            this.officetelno2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.officetelno2.Text = "1234567890123456";
            this.officetelno2.Top = 0.375F;
            this.officetelno2.Width = 0.92F;
            // 
            // portabletelno2
            // 
            this.portabletelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.portabletelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.portabletelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno2.Border.RightColor = System.Drawing.Color.Black;
            this.portabletelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno2.Border.TopColor = System.Drawing.Color.Black;
            this.portabletelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno2.DataField = "portabletelno";
            this.portabletelno2.Height = 0.15F;
            this.portabletelno2.Left = 7.479168F;
            this.portabletelno2.MultiLine = false;
            this.portabletelno2.Name = "portabletelno2";
            this.portabletelno2.OutputFormat = resources.GetString("portabletelno2.OutputFormat");
            this.portabletelno2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.portabletelno2.Text = "1234567890123456";
            this.portabletelno2.Top = 0.375F;
            this.portabletelno2.Width = 0.92F;
            // 
            // officefaxno2
            // 
            this.officefaxno2.Border.BottomColor = System.Drawing.Color.Black;
            this.officefaxno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno2.Border.LeftColor = System.Drawing.Color.Black;
            this.officefaxno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno2.Border.RightColor = System.Drawing.Color.Black;
            this.officefaxno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno2.Border.TopColor = System.Drawing.Color.Black;
            this.officefaxno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.officefaxno2.DataField = "officefaxno";
            this.officefaxno2.Height = 0.15F;
            this.officefaxno2.Left = 8.416668F;
            this.officefaxno2.MultiLine = false;
            this.officefaxno2.Name = "officefaxno2";
            this.officefaxno2.OutputFormat = resources.GetString("officefaxno2.OutputFormat");
            this.officefaxno2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.officefaxno2.Text = "1234567890123456";
            this.officefaxno2.Top = 0.375F;
            this.officefaxno2.Width = 0.92F;
            // 
            // customeragentcd2
            // 
            this.customeragentcd2.Border.BottomColor = System.Drawing.Color.Black;
            this.customeragentcd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd2.Border.LeftColor = System.Drawing.Color.Black;
            this.customeragentcd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd2.Border.RightColor = System.Drawing.Color.Black;
            this.customeragentcd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd2.Border.TopColor = System.Drawing.Color.Black;
            this.customeragentcd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentcd2.DataField = "customeragentcd";
            this.customeragentcd2.Height = 0.15F;
            this.customeragentcd2.Left = 9.4375F;
            this.customeragentcd2.MultiLine = false;
            this.customeragentcd2.Name = "customeragentcd2";
            this.customeragentcd2.OutputFormat = resources.GetString("customeragentcd2.OutputFormat");
            this.customeragentcd2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.customeragentcd2.Text = "1234";
            this.customeragentcd2.Top = 0.375F;
            this.customeragentcd2.Width = 0.25F;
            // 
            // customeragentname2
            // 
            this.customeragentname2.Border.BottomColor = System.Drawing.Color.Black;
            this.customeragentname2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname2.Border.LeftColor = System.Drawing.Color.Black;
            this.customeragentname2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname2.Border.RightColor = System.Drawing.Color.Black;
            this.customeragentname2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname2.Border.TopColor = System.Drawing.Color.Black;
            this.customeragentname2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customeragentname2.DataField = "customeragentname";
            this.customeragentname2.Height = 0.15F;
            this.customeragentname2.Left = 9.75F;
            this.customeragentname2.MultiLine = false;
            this.customeragentname2.Name = "customeragentname2";
            this.customeragentname2.OutputFormat = resources.GetString("customeragentname2.OutputFormat");
            this.customeragentname2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.customeragentname2.Text = "あいうえおかきくけこ";
            this.customeragentname2.Top = 0.375F;
            this.customeragentname2.Width = 0.9999996F;
            // 
            // address4
            // 
            this.address4.Border.BottomColor = System.Drawing.Color.Black;
            this.address4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.Border.LeftColor = System.Drawing.Color.Black;
            this.address4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.Border.RightColor = System.Drawing.Color.Black;
            this.address4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.Border.TopColor = System.Drawing.Color.Black;
            this.address4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.DataField = "address4";
            this.address4.Height = 0.15F;
            this.address4.Left = 7.5625F;
            this.address4.MultiLine = false;
            this.address4.Name = "address4";
            this.address4.OutputFormat = resources.GetString("address4.OutputFormat");
            this.address4.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.address4.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.address4.Top = 0.5625F;
            this.address4.Width = 3F;
            // 
            // address1
            // 
            this.address1.Border.BottomColor = System.Drawing.Color.Black;
            this.address1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.Border.LeftColor = System.Drawing.Color.Black;
            this.address1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.Border.RightColor = System.Drawing.Color.Black;
            this.address1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.Border.TopColor = System.Drawing.Color.Black;
            this.address1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.DataField = "address1";
            this.address1.Height = 0.15F;
            this.address1.Left = 2.25F;
            this.address1.MultiLine = false;
            this.address1.Name = "address1";
            this.address1.OutputFormat = resources.GetString("address1.OutputFormat");
            this.address1.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.address1.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.address1.Top = 0.5625F;
            this.address1.Width = 3F;
            // 
            // address3
            // 
            this.address3.Border.BottomColor = System.Drawing.Color.Black;
            this.address3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.Border.LeftColor = System.Drawing.Color.Black;
            this.address3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.Border.RightColor = System.Drawing.Color.Black;
            this.address3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.Border.TopColor = System.Drawing.Color.Black;
            this.address3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.DataField = "address3";
            this.address3.Height = 0.15F;
            this.address3.Left = 5.3125F;
            this.address3.MultiLine = false;
            this.address3.Name = "address3";
            this.address3.OutputFormat = resources.GetString("address3.OutputFormat");
            this.address3.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.address3.Text = "あいうえおかきくけこあいうえおかきくけこあい";
            this.address3.Top = 0.5625F;
            this.address3.Width = 2.1875F;
            // 
            // customercode2
            // 
            this.customercode2.Border.BottomColor = System.Drawing.Color.Black;
            this.customercode2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode2.Border.LeftColor = System.Drawing.Color.Black;
            this.customercode2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode2.Border.RightColor = System.Drawing.Color.Black;
            this.customercode2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode2.Border.TopColor = System.Drawing.Color.Black;
            this.customercode2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customercode2.DataField = "customercode";
            this.customercode2.Height = 0.15F;
            this.customercode2.Left = 0F;
            this.customercode2.MultiLine = false;
            this.customercode2.Name = "customercode2";
            this.customercode2.OutputFormat = resources.GetString("customercode2.OutputFormat");
            this.customercode2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.customercode2.Text = "12345678";
            this.customercode2.Top = 0.375F;
            this.customercode2.Width = 0.5F;
            // 
            // kana2
            // 
            this.kana2.Border.BottomColor = System.Drawing.Color.Black;
            this.kana2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana2.Border.LeftColor = System.Drawing.Color.Black;
            this.kana2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana2.Border.RightColor = System.Drawing.Color.Black;
            this.kana2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana2.Border.TopColor = System.Drawing.Color.Black;
            this.kana2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana2.DataField = "kana";
            this.kana2.Height = 0.15F;
            this.kana2.Left = 0.5F;
            this.kana2.MultiLine = false;
            this.kana2.Name = "kana2";
            this.kana2.OutputFormat = resources.GetString("kana2.OutputFormat");
            this.kana2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.kana2.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.kana2.Top = 0.5625F;
            this.kana2.Width = 1.0625F;
            // 
            // postno2
            // 
            this.postno2.Border.BottomColor = System.Drawing.Color.Black;
            this.postno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno2.Border.LeftColor = System.Drawing.Color.Black;
            this.postno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno2.Border.RightColor = System.Drawing.Color.Black;
            this.postno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno2.Border.TopColor = System.Drawing.Color.Black;
            this.postno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno2.DataField = "postno";
            this.postno2.Height = 0.15F;
            this.postno2.Left = 1.625F;
            this.postno2.MultiLine = false;
            this.postno2.Name = "postno2";
            this.postno2.OutputFormat = resources.GetString("postno2.OutputFormat");
            this.postno2.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.postno2.Text = "1234567890";
            this.postno2.Top = 0.5625F;
            this.postno2.Width = 0.5624999F;
            // 
            // custrategrpcode11
            // 
            this.custrategrpcode11.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode11.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode11.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode11.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode11.DataField = "custrategrpcode11";
            this.custrategrpcode11.Height = 0.15F;
            this.custrategrpcode11.Left = 6F;
            this.custrategrpcode11.MultiLine = false;
            this.custrategrpcode11.Name = "custrategrpcode11";
            this.custrategrpcode11.OutputFormat = resources.GetString("custrategrpcode11.OutputFormat");
            this.custrategrpcode11.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode11.Text = "1234";
            this.custrategrpcode11.Top = 0.75F;
            this.custrategrpcode11.Width = 0.3F;
            // 
            // custrategrpcode12
            // 
            this.custrategrpcode12.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode12.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode12.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode12.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode12.DataField = "custrategrpcode12";
            this.custrategrpcode12.Height = 0.15F;
            this.custrategrpcode12.Left = 6.3125F;
            this.custrategrpcode12.MultiLine = false;
            this.custrategrpcode12.Name = "custrategrpcode12";
            this.custrategrpcode12.OutputFormat = resources.GetString("custrategrpcode12.OutputFormat");
            this.custrategrpcode12.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode12.Text = "1234";
            this.custrategrpcode12.Top = 0.75F;
            this.custrategrpcode12.Width = 0.3F;
            // 
            // custrategrpcode13
            // 
            this.custrategrpcode13.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode13.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode13.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode13.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode13.DataField = "custrategrpcode13";
            this.custrategrpcode13.Height = 0.15F;
            this.custrategrpcode13.Left = 6.625F;
            this.custrategrpcode13.MultiLine = false;
            this.custrategrpcode13.Name = "custrategrpcode13";
            this.custrategrpcode13.OutputFormat = resources.GetString("custrategrpcode13.OutputFormat");
            this.custrategrpcode13.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode13.Text = "1234";
            this.custrategrpcode13.Top = 0.75F;
            this.custrategrpcode13.Width = 0.3F;
            // 
            // custrategrpcode14
            // 
            this.custrategrpcode14.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode14.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode14.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode14.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode14.DataField = "custrategrpcode14";
            this.custrategrpcode14.Height = 0.15F;
            this.custrategrpcode14.Left = 6.9375F;
            this.custrategrpcode14.MultiLine = false;
            this.custrategrpcode14.Name = "custrategrpcode14";
            this.custrategrpcode14.OutputFormat = resources.GetString("custrategrpcode14.OutputFormat");
            this.custrategrpcode14.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode14.Text = "1234";
            this.custrategrpcode14.Top = 0.75F;
            this.custrategrpcode14.Width = 0.3F;
            // 
            // custrategrpcode15
            // 
            this.custrategrpcode15.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode15.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode15.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode15.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode15.DataField = "custrategrpcode15";
            this.custrategrpcode15.Height = 0.15F;
            this.custrategrpcode15.Left = 7.3125F;
            this.custrategrpcode15.MultiLine = false;
            this.custrategrpcode15.Name = "custrategrpcode15";
            this.custrategrpcode15.OutputFormat = resources.GetString("custrategrpcode15.OutputFormat");
            this.custrategrpcode15.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode15.Text = "1234";
            this.custrategrpcode15.Top = 0.75F;
            this.custrategrpcode15.Width = 0.3F;
            // 
            // custrategrpcode20
            // 
            this.custrategrpcode20.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode20.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode20.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode20.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode20.DataField = "custrategrpcode20";
            this.custrategrpcode20.Height = 0.15F;
            this.custrategrpcode20.Left = 8.854568F;
            this.custrategrpcode20.MultiLine = false;
            this.custrategrpcode20.Name = "custrategrpcode20";
            this.custrategrpcode20.OutputFormat = resources.GetString("custrategrpcode20.OutputFormat");
            this.custrategrpcode20.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode20.Text = "1234";
            this.custrategrpcode20.Top = 0.7499999F;
            this.custrategrpcode20.Width = 0.3F;
            // 
            // custrategrpcode19
            // 
            this.custrategrpcode19.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode19.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode19.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode19.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode19.DataField = "custrategrpcode19";
            this.custrategrpcode19.Height = 0.15F;
            this.custrategrpcode19.Left = 8.5625F;
            this.custrategrpcode19.MultiLine = false;
            this.custrategrpcode19.Name = "custrategrpcode19";
            this.custrategrpcode19.OutputFormat = resources.GetString("custrategrpcode19.OutputFormat");
            this.custrategrpcode19.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode19.Text = "1234";
            this.custrategrpcode19.Top = 0.75F;
            this.custrategrpcode19.Width = 0.3F;
            // 
            // custrategrpcode18
            // 
            this.custrategrpcode18.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode18.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode18.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode18.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode18.DataField = "custrategrpcode18";
            this.custrategrpcode18.Height = 0.15F;
            this.custrategrpcode18.Left = 8.25F;
            this.custrategrpcode18.MultiLine = false;
            this.custrategrpcode18.Name = "custrategrpcode18";
            this.custrategrpcode18.OutputFormat = resources.GetString("custrategrpcode18.OutputFormat");
            this.custrategrpcode18.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode18.Text = "1234";
            this.custrategrpcode18.Top = 0.75F;
            this.custrategrpcode18.Width = 0.3F;
            // 
            // custrategrpcode17
            // 
            this.custrategrpcode17.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode17.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode17.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode17.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode17.DataField = "custrategrpcode17";
            this.custrategrpcode17.Height = 0.15F;
            this.custrategrpcode17.Left = 7.9375F;
            this.custrategrpcode17.MultiLine = false;
            this.custrategrpcode17.Name = "custrategrpcode17";
            this.custrategrpcode17.OutputFormat = resources.GetString("custrategrpcode17.OutputFormat");
            this.custrategrpcode17.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode17.Text = "1234";
            this.custrategrpcode17.Top = 0.75F;
            this.custrategrpcode17.Width = 0.3F;
            // 
            // custrategrpcode16
            // 
            this.custrategrpcode16.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode16.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode16.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode16.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode16.DataField = "custrategrpcode16";
            this.custrategrpcode16.Height = 0.15F;
            this.custrategrpcode16.Left = 7.625F;
            this.custrategrpcode16.MultiLine = false;
            this.custrategrpcode16.Name = "custrategrpcode16";
            this.custrategrpcode16.OutputFormat = resources.GetString("custrategrpcode16.OutputFormat");
            this.custrategrpcode16.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode16.Text = "1234";
            this.custrategrpcode16.Top = 0.75F;
            this.custrategrpcode16.Width = 0.3F;
            // 
            // custrategrpcode25
            // 
            this.custrategrpcode25.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode25.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode25.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode25.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode25.DataField = "custrategrpcode25";
            this.custrategrpcode25.Height = 0.15F;
            this.custrategrpcode25.Left = 10.42708F;
            this.custrategrpcode25.MultiLine = false;
            this.custrategrpcode25.Name = "custrategrpcode25";
            this.custrategrpcode25.OutputFormat = resources.GetString("custrategrpcode25.OutputFormat");
            this.custrategrpcode25.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode25.Text = "1234";
            this.custrategrpcode25.Top = 0.7499999F;
            this.custrategrpcode25.Width = 0.3F;
            // 
            // custrategrpcode24
            // 
            this.custrategrpcode24.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode24.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode24.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode24.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode24.DataField = "custrategrpcode24";
            this.custrategrpcode24.Height = 0.15F;
            this.custrategrpcode24.Left = 10.11258F;
            this.custrategrpcode24.MultiLine = false;
            this.custrategrpcode24.Name = "custrategrpcode24";
            this.custrategrpcode24.OutputFormat = resources.GetString("custrategrpcode24.OutputFormat");
            this.custrategrpcode24.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode24.Text = "1234";
            this.custrategrpcode24.Top = 0.7499999F;
            this.custrategrpcode24.Width = 0.3F;
            // 
            // custrategrpcode23
            // 
            this.custrategrpcode23.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode23.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode23.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode23.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode23.DataField = "custrategrpcode23";
            this.custrategrpcode23.Height = 0.15F;
            this.custrategrpcode23.Left = 9.798079F;
            this.custrategrpcode23.MultiLine = false;
            this.custrategrpcode23.Name = "custrategrpcode23";
            this.custrategrpcode23.OutputFormat = resources.GetString("custrategrpcode23.OutputFormat");
            this.custrategrpcode23.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode23.Text = "1234";
            this.custrategrpcode23.Top = 0.7499999F;
            this.custrategrpcode23.Width = 0.3F;
            // 
            // custrategrpcode22
            // 
            this.custrategrpcode22.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode22.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode22.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode22.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode22.DataField = "custrategrpcode22";
            this.custrategrpcode22.Height = 0.15F;
            this.custrategrpcode22.Left = 9.483576F;
            this.custrategrpcode22.MultiLine = false;
            this.custrategrpcode22.Name = "custrategrpcode22";
            this.custrategrpcode22.OutputFormat = resources.GetString("custrategrpcode22.OutputFormat");
            this.custrategrpcode22.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode22.Text = "1234";
            this.custrategrpcode22.Top = 0.7499999F;
            this.custrategrpcode22.Width = 0.3F;
            // 
            // custrategrpcode21
            // 
            this.custrategrpcode21.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode21.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode21.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode21.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode21.DataField = "custrategrpcode21";
            this.custrategrpcode21.Height = 0.15F;
            this.custrategrpcode21.Left = 9.169072F;
            this.custrategrpcode21.MultiLine = false;
            this.custrategrpcode21.Name = "custrategrpcode21";
            this.custrategrpcode21.OutputFormat = resources.GetString("custrategrpcode21.OutputFormat");
            this.custrategrpcode21.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode21.Text = "1234";
            this.custrategrpcode21.Top = 0.7499999F;
            this.custrategrpcode21.Width = 0.3F;
            // 
            // custrategrpcode10
            // 
            this.custrategrpcode10.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode10.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode10.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode10.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode10.DataField = "custrategrpcode10";
            this.custrategrpcode10.Height = 0.15F;
            this.custrategrpcode10.Left = 5.6875F;
            this.custrategrpcode10.MultiLine = false;
            this.custrategrpcode10.Name = "custrategrpcode10";
            this.custrategrpcode10.OutputFormat = resources.GetString("custrategrpcode10.OutputFormat");
            this.custrategrpcode10.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode10.Text = "1234";
            this.custrategrpcode10.Top = 0.75F;
            this.custrategrpcode10.Width = 0.3F;
            // 
            // custrategrpcode09
            // 
            this.custrategrpcode09.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode09.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode09.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode09.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode09.DataField = "custrategrpcode09";
            this.custrategrpcode09.Height = 0.15F;
            this.custrategrpcode09.Left = 5.375F;
            this.custrategrpcode09.MultiLine = false;
            this.custrategrpcode09.Name = "custrategrpcode09";
            this.custrategrpcode09.OutputFormat = resources.GetString("custrategrpcode09.OutputFormat");
            this.custrategrpcode09.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode09.Text = "1234";
            this.custrategrpcode09.Top = 0.75F;
            this.custrategrpcode09.Width = 0.3F;
            // 
            // custrategrpcode08
            // 
            this.custrategrpcode08.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode08.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode08.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode08.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode08.DataField = "custrategrpcode08";
            this.custrategrpcode08.Height = 0.15F;
            this.custrategrpcode08.Left = 5.0625F;
            this.custrategrpcode08.MultiLine = false;
            this.custrategrpcode08.Name = "custrategrpcode08";
            this.custrategrpcode08.OutputFormat = resources.GetString("custrategrpcode08.OutputFormat");
            this.custrategrpcode08.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode08.Text = "1234";
            this.custrategrpcode08.Top = 0.75F;
            this.custrategrpcode08.Width = 0.3F;
            // 
            // custrategrpcode07
            // 
            this.custrategrpcode07.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode07.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode07.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode07.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode07.DataField = "custrategrpcode07";
            this.custrategrpcode07.Height = 0.15F;
            this.custrategrpcode07.Left = 4.75F;
            this.custrategrpcode07.MultiLine = false;
            this.custrategrpcode07.Name = "custrategrpcode07";
            this.custrategrpcode07.OutputFormat = resources.GetString("custrategrpcode07.OutputFormat");
            this.custrategrpcode07.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode07.Text = "1234";
            this.custrategrpcode07.Top = 0.75F;
            this.custrategrpcode07.Width = 0.3F;
            // 
            // custrategrpcode06
            // 
            this.custrategrpcode06.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode06.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode06.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode06.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode06.DataField = "custrategrpcode06";
            this.custrategrpcode06.Height = 0.15F;
            this.custrategrpcode06.Left = 4.4375F;
            this.custrategrpcode06.MultiLine = false;
            this.custrategrpcode06.Name = "custrategrpcode06";
            this.custrategrpcode06.OutputFormat = resources.GetString("custrategrpcode06.OutputFormat");
            this.custrategrpcode06.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode06.Text = "1234";
            this.custrategrpcode06.Top = 0.75F;
            this.custrategrpcode06.Width = 0.3F;
            // 
            // custrategrpcode05
            // 
            this.custrategrpcode05.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode05.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode05.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode05.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode05.DataField = "custrategrpcode05";
            this.custrategrpcode05.Height = 0.15F;
            this.custrategrpcode05.Left = 4.125F;
            this.custrategrpcode05.MultiLine = false;
            this.custrategrpcode05.Name = "custrategrpcode05";
            this.custrategrpcode05.OutputFormat = resources.GetString("custrategrpcode05.OutputFormat");
            this.custrategrpcode05.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode05.Text = "1234";
            this.custrategrpcode05.Top = 0.75F;
            this.custrategrpcode05.Width = 0.3F;
            // 
            // custrategrpcode04
            // 
            this.custrategrpcode04.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode04.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode04.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode04.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode04.DataField = "custrategrpcode04";
            this.custrategrpcode04.Height = 0.15F;
            this.custrategrpcode04.Left = 3.8125F;
            this.custrategrpcode04.MultiLine = false;
            this.custrategrpcode04.Name = "custrategrpcode04";
            this.custrategrpcode04.OutputFormat = resources.GetString("custrategrpcode04.OutputFormat");
            this.custrategrpcode04.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode04.Text = "1234";
            this.custrategrpcode04.Top = 0.75F;
            this.custrategrpcode04.Width = 0.3F;
            // 
            // custrategrpcode03
            // 
            this.custrategrpcode03.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode03.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode03.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode03.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode03.DataField = "custrategrpcode03";
            this.custrategrpcode03.Height = 0.15F;
            this.custrategrpcode03.Left = 3.5F;
            this.custrategrpcode03.MultiLine = false;
            this.custrategrpcode03.Name = "custrategrpcode03";
            this.custrategrpcode03.OutputFormat = resources.GetString("custrategrpcode03.OutputFormat");
            this.custrategrpcode03.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode03.Text = "1234";
            this.custrategrpcode03.Top = 0.75F;
            this.custrategrpcode03.Width = 0.3F;
            // 
            // custrategrpcode02
            // 
            this.custrategrpcode02.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode02.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode02.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode02.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode02.DataField = "custrategrpcode02";
            this.custrategrpcode02.Height = 0.15F;
            this.custrategrpcode02.Left = 3.1875F;
            this.custrategrpcode02.MultiLine = false;
            this.custrategrpcode02.Name = "custrategrpcode02";
            this.custrategrpcode02.OutputFormat = resources.GetString("custrategrpcode02.OutputFormat");
            this.custrategrpcode02.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode02.Text = "1234";
            this.custrategrpcode02.Top = 0.75F;
            this.custrategrpcode02.Width = 0.3F;
            // 
            // custrategrpcode01
            // 
            this.custrategrpcode01.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode01.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode01.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode01.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode01.DataField = "custrategrpcode01";
            this.custrategrpcode01.Height = 0.15F;
            this.custrategrpcode01.Left = 2.875F;
            this.custrategrpcode01.MultiLine = false;
            this.custrategrpcode01.Name = "custrategrpcode01";
            this.custrategrpcode01.OutputFormat = resources.GetString("custrategrpcode01.OutputFormat");
            this.custrategrpcode01.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode01.Text = "1234";
            this.custrategrpcode01.Top = 0.75F;
            this.custrategrpcode01.Width = 0.3F;
            // 
            // custrategrpcodeALL
            // 
            this.custrategrpcodeALL.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcodeALL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcodeALL.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcodeALL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcodeALL.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcodeALL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcodeALL.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcodeALL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcodeALL.DataField = "custrategrpcodeALL";
            this.custrategrpcodeALL.Height = 0.15F;
            this.custrategrpcodeALL.Left = 2.25F;
            this.custrategrpcodeALL.MultiLine = false;
            this.custrategrpcodeALL.Name = "custrategrpcodeALL";
            this.custrategrpcodeALL.OutputFormat = resources.GetString("custrategrpcodeALL.OutputFormat");
            this.custrategrpcodeALL.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcodeALL.Text = "未設定";
            this.custrategrpcodeALL.Top = 0.75F;
            this.custrategrpcodeALL.Width = 0.3F;
            // 
            // custrategrpcode00
            // 
            this.custrategrpcode00.Border.BottomColor = System.Drawing.Color.Black;
            this.custrategrpcode00.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode00.Border.LeftColor = System.Drawing.Color.Black;
            this.custrategrpcode00.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode00.Border.RightColor = System.Drawing.Color.Black;
            this.custrategrpcode00.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode00.Border.TopColor = System.Drawing.Color.Black;
            this.custrategrpcode00.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.custrategrpcode00.DataField = "custrategrpcode00";
            this.custrategrpcode00.Height = 0.15F;
            this.custrategrpcode00.Left = 2.5625F;
            this.custrategrpcode00.MultiLine = false;
            this.custrategrpcode00.Name = "custrategrpcode00";
            this.custrategrpcode00.OutputFormat = resources.GetString("custrategrpcode00.OutputFormat");
            this.custrategrpcode00.Style = "ddo-char-set: 128; text-align: left; font-size: 6pt; font-family: MS UI Gothic; v" +
                "ertical-align: top; ";
            this.custrategrpcode00.Text = "1234";
            this.custrategrpcode00.Top = 0.75F;
            this.custrategrpcode00.Width = 0.3F;
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
            this.SORTTITLE});
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
            this.tb_ReportTitle.Text = "得意先マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.SORTTITLE.Height = 0.125F;
            this.SORTTITLE.Left = 3.625F;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "color: Black; font-size: 8pt; vertical-align: top; ";
            this.SORTTITLE.Text = null;
            this.SORTTITLE.Top = 0.0625F;
            this.SORTTITLE.Width = 2F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2916667F;
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
            this.Lb_customercode,
            this.Lb_kana,
            this.line2,
            this.Lb_postno,
            this.Lb_officetelno,
            this.Lb_totalday,
            this.Lb_collectmoneynameday,
            this.Lb_businesstypecode,
            this.Lb_claimsectioncode,
            this.Lb_addressall,
            this.Lb_customeragentcd,
            this.Lb_mngsectioncode,
            this.Lb_salesareacode,
            this.Lb_billcollectercd,
            this.Lb_portabletelno,
            this.Lb_officefaxno,
            this.Lb_custwarehousecd,
            this.Lb_name,
            this.Lb_name2,
            this.Lb_customercode2,
            this.Lb_kana2,
            this.Lb_postno2,
            this.Lb_address1,
            this.Lb_address3,
            this.Lb_address4,
            this.Lb_officetelno2,
            this.Lb_portabletelno2,
            this.Lb_officefaxno2,
            this.Lb_customeragentcd2,
            this.Lb_custrategrpcodeALL,
            this.Lb_custrategrpcode00,
            this.Lb_custrategrpcode01,
            this.Lb_custrategrpcode02,
            this.Lb_custrategrpcode03,
            this.Lb_custrategrpcode04,
            this.Lb_custrategrpcode05,
            this.Lb_custrategrpcode06,
            this.Lb_custrategrpcode07,
            this.Lb_custrategrpcode08,
            this.Lb_custrategrpcode09,
            this.Lb_custrategrpcode10,
            this.Lb_custrategrpcode11,
            this.Lb_custrategrpcode12,
            this.Lb_custrategrpcode13,
            this.Lb_custrategrpcode14,
            this.Lb_custrategrpcode15,
            this.Lb_custrategrpcode16,
            this.Lb_custrategrpcode17,
            this.Lb_custrategrpcode18,
            this.Lb_custrategrpcode19,
            this.Lb_custrategrpcode20,
            this.Lb_custrategrpcode21,
            this.Lb_custrategrpcode22,
            this.Lb_custrategrpcode23,
            this.Lb_custrategrpcode24,
            this.Lb_custrategrpcode25,
            this.Lb_custrategrpcode01_2,
            this.Lb_custrategrpcode02_2,
            this.Lb_custrategrpcode03_2,
            this.Lb_custrategrpcode04_2,
            this.Lb_custrategrpcode05_2,
            this.Lb_custrategrpcode06_2,
            this.Lb_custrategrpcode07_2,
            this.Lb_custrategrpcode08_2,
            this.Lb_custrategrpcode09_2,
            this.Lb_custrategrpcode10_2,
            this.Lb_custrategrpcode11_2,
            this.Lb_custrategrpcode12_2,
            this.Lb_custrategrpcode13_2,
            this.Lb_custrategrpcode14_2,
            this.Lb_custrategrpcode15_2,
            this.Lb_custrategrpcode16_2,
            this.Lb_custrategrpcode17_2,
            this.Lb_custrategrpcode18_2,
            this.Lb_custrategrpcode19_2,
            this.Lb_custrategrpcode20_2,
            this.Lb_custrategrpcode21_2,
            this.Lb_custrategrpcode22_2,
            this.Lb_custrategrpcode23_2,
            this.Lb_custrategrpcode24_2,
            this.Lb_custrategrpcode25_2,
            this.Lb_custrategrpcode00_2});
            this.TitleHeader.Height = 1.3625F;
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
            // Lb_customercode
            // 
            this.Lb_customercode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_customercode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_customercode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_customercode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_customercode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode.Height = 0.15F;
            this.Lb_customercode.HyperLink = "";
            this.Lb_customercode.Left = 0F;
            this.Lb_customercode.MultiLine = false;
            this.Lb_customercode.Name = "Lb_customercode";
            this.Lb_customercode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_customercode.Text = "得意先";
            this.Lb_customercode.Top = 0.0625F;
            this.Lb_customercode.Width = 0.5F;
            // 
            // Lb_kana
            // 
            this.Lb_kana.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_kana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_kana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_kana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_kana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana.Height = 0.15F;
            this.Lb_kana.HyperLink = "";
            this.Lb_kana.Left = 0.4999996F;
            this.Lb_kana.MultiLine = false;
            this.Lb_kana.Name = "Lb_kana";
            this.Lb_kana.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_kana.Text = "ｶﾅ";
            this.Lb_kana.Top = 0.2395834F;
            this.Lb_kana.Width = 1.7F;
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
            this.line2.Top = 0.40625F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.40625F;
            this.line2.Y2 = 0.40625F;
            // 
            // Lb_postno
            // 
            this.Lb_postno.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_postno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_postno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_postno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_postno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno.Height = 0.15F;
            this.Lb_postno.HyperLink = "";
            this.Lb_postno.Left = 2.251964F;
            this.Lb_postno.MultiLine = false;
            this.Lb_postno.Name = "Lb_postno";
            this.Lb_postno.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_postno.Text = "郵便番号";
            this.Lb_postno.Top = 0.2395834F;
            this.Lb_postno.Width = 0.6F;
            // 
            // Lb_officetelno
            // 
            this.Lb_officetelno.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_officetelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_officetelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_officetelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_officetelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno.Height = 0.15F;
            this.Lb_officetelno.HyperLink = "";
            this.Lb_officetelno.Left = 2.251964F;
            this.Lb_officetelno.MultiLine = false;
            this.Lb_officetelno.Name = "Lb_officetelno";
            this.Lb_officetelno.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_officetelno.Text = "電話番号１";
            this.Lb_officetelno.Top = 0.0625F;
            this.Lb_officetelno.Width = 0.92F;
            // 
            // Lb_totalday
            // 
            this.Lb_totalday.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_totalday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_totalday.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_totalday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_totalday.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_totalday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_totalday.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_totalday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_totalday.Height = 0.15F;
            this.Lb_totalday.HyperLink = "";
            this.Lb_totalday.Left = 5.167857F;
            this.Lb_totalday.MultiLine = false;
            this.Lb_totalday.Name = "Lb_totalday";
            this.Lb_totalday.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_totalday.Text = "締日";
            this.Lb_totalday.Top = 0.0625F;
            this.Lb_totalday.Width = 0.27F;
            // 
            // Lb_collectmoneynameday
            // 
            this.Lb_collectmoneynameday.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_collectmoneynameday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_collectmoneynameday.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_collectmoneynameday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_collectmoneynameday.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_collectmoneynameday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_collectmoneynameday.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_collectmoneynameday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_collectmoneynameday.Height = 0.15F;
            this.Lb_collectmoneynameday.HyperLink = "";
            this.Lb_collectmoneynameday.Left = 5.489821F;
            this.Lb_collectmoneynameday.MultiLine = false;
            this.Lb_collectmoneynameday.Name = "Lb_collectmoneynameday";
            this.Lb_collectmoneynameday.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_collectmoneynameday.Text = "回収月日";
            this.Lb_collectmoneynameday.Top = 0.0625F;
            this.Lb_collectmoneynameday.Width = 0.59F;
            // 
            // Lb_businesstypecode
            // 
            this.Lb_businesstypecode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_businesstypecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_businesstypecode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_businesstypecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_businesstypecode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_businesstypecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_businesstypecode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_businesstypecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_businesstypecode.Height = 0.15F;
            this.Lb_businesstypecode.HyperLink = "";
            this.Lb_businesstypecode.Left = 8.464643F;
            this.Lb_businesstypecode.MultiLine = false;
            this.Lb_businesstypecode.Name = "Lb_businesstypecode";
            this.Lb_businesstypecode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_businesstypecode.Text = "業種";
            this.Lb_businesstypecode.Top = 0.0625F;
            this.Lb_businesstypecode.Width = 1F;
            // 
            // Lb_claimsectioncode
            // 
            this.Lb_claimsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_claimsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_claimsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_claimsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_claimsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_claimsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_claimsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_claimsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_claimsectioncode.Height = 0.15F;
            this.Lb_claimsectioncode.HyperLink = "";
            this.Lb_claimsectioncode.Left = 9.631071F;
            this.Lb_claimsectioncode.MultiLine = false;
            this.Lb_claimsectioncode.Name = "Lb_claimsectioncode";
            this.Lb_claimsectioncode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_claimsectioncode.Text = "請求先";
            this.Lb_claimsectioncode.Top = 0.0625F;
            this.Lb_claimsectioncode.Width = 0.5F;
            // 
            // Lb_addressall
            // 
            this.Lb_addressall.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_addressall.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_addressall.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_addressall.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_addressall.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_addressall.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_addressall.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_addressall.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_addressall.Height = 0.15F;
            this.Lb_addressall.HyperLink = "";
            this.Lb_addressall.Left = 2.875F;
            this.Lb_addressall.MultiLine = false;
            this.Lb_addressall.Name = "Lb_addressall";
            this.Lb_addressall.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_addressall.Text = "住所";
            this.Lb_addressall.Top = 0.2395834F;
            this.Lb_addressall.Width = 1.14F;
            // 
            // Lb_customeragentcd
            // 
            this.Lb_customeragentcd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd.Height = 0.15F;
            this.Lb_customeragentcd.HyperLink = "";
            this.Lb_customeragentcd.Left = 6.131786F;
            this.Lb_customeragentcd.MultiLine = false;
            this.Lb_customeragentcd.Name = "Lb_customeragentcd";
            this.Lb_customeragentcd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_customeragentcd.Text = "担当者";
            this.Lb_customeragentcd.Top = 0.0625F;
            this.Lb_customeragentcd.Width = 0.95F;
            // 
            // Lb_mngsectioncode
            // 
            this.Lb_mngsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_mngsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_mngsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_mngsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_mngsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_mngsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_mngsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_mngsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_mngsectioncode.Height = 0.15F;
            this.Lb_mngsectioncode.HyperLink = "";
            this.Lb_mngsectioncode.Left = 9.062499F;
            this.Lb_mngsectioncode.MultiLine = false;
            this.Lb_mngsectioncode.Name = "Lb_mngsectioncode";
            this.Lb_mngsectioncode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_mngsectioncode.Text = "拠点";
            this.Lb_mngsectioncode.Top = 0.2395834F;
            this.Lb_mngsectioncode.Width = 0.95F;
            // 
            // Lb_salesareacode
            // 
            this.Lb_salesareacode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_salesareacode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_salesareacode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_salesareacode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_salesareacode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_salesareacode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_salesareacode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_salesareacode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_salesareacode.Height = 0.15F;
            this.Lb_salesareacode.HyperLink = "";
            this.Lb_salesareacode.Left = 7.298214F;
            this.Lb_salesareacode.MultiLine = false;
            this.Lb_salesareacode.Name = "Lb_salesareacode";
            this.Lb_salesareacode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_salesareacode.Text = "地区";
            this.Lb_salesareacode.Top = 0.0625F;
            this.Lb_salesareacode.Width = 0.6F;
            // 
            // Lb_billcollectercd
            // 
            this.Lb_billcollectercd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_billcollectercd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_billcollectercd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_billcollectercd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_billcollectercd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_billcollectercd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_billcollectercd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_billcollectercd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_billcollectercd.Height = 0.15F;
            this.Lb_billcollectercd.HyperLink = "";
            this.Lb_billcollectercd.Left = 10.17708F;
            this.Lb_billcollectercd.MultiLine = false;
            this.Lb_billcollectercd.Name = "Lb_billcollectercd";
            this.Lb_billcollectercd.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_billcollectercd.Text = "回収担当";
            this.Lb_billcollectercd.Top = 0.0625F;
            this.Lb_billcollectercd.Width = 0.5000001F;
            // 
            // Lb_portabletelno
            // 
            this.Lb_portabletelno.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_portabletelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_portabletelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_portabletelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_portabletelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno.Height = 0.15F;
            this.Lb_portabletelno.HyperLink = "";
            this.Lb_portabletelno.Left = 3.223928F;
            this.Lb_portabletelno.MultiLine = false;
            this.Lb_portabletelno.Name = "Lb_portabletelno";
            this.Lb_portabletelno.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_portabletelno.Text = "電話番号２";
            this.Lb_portabletelno.Top = 0.0625F;
            this.Lb_portabletelno.Width = 0.92F;
            // 
            // Lb_officefaxno
            // 
            this.Lb_officefaxno.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_officefaxno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_officefaxno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_officefaxno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_officefaxno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno.Height = 0.15F;
            this.Lb_officefaxno.HyperLink = "";
            this.Lb_officefaxno.Left = 4.195893F;
            this.Lb_officefaxno.MultiLine = false;
            this.Lb_officefaxno.Name = "Lb_officefaxno";
            this.Lb_officefaxno.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_officefaxno.Text = "ＦＡＸ";
            this.Lb_officefaxno.Top = 0.0625F;
            this.Lb_officefaxno.Width = 0.92F;
            // 
            // Lb_custwarehousecd
            // 
            this.Lb_custwarehousecd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custwarehousecd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custwarehousecd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custwarehousecd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custwarehousecd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custwarehousecd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custwarehousecd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custwarehousecd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custwarehousecd.Height = 0.15F;
            this.Lb_custwarehousecd.HyperLink = "";
            this.Lb_custwarehousecd.Left = 10.42708F;
            this.Lb_custwarehousecd.MultiLine = false;
            this.Lb_custwarehousecd.Name = "Lb_custwarehousecd";
            this.Lb_custwarehousecd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custwarehousecd.Text = "倉庫";
            this.Lb_custwarehousecd.Top = 0.2395834F;
            this.Lb_custwarehousecd.Width = 0.3F;
            // 
            // Lb_name
            // 
            this.Lb_name.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name.Height = 0.15F;
            this.Lb_name.HyperLink = "";
            this.Lb_name.Left = 0.4999996F;
            this.Lb_name.MultiLine = false;
            this.Lb_name.Name = "Lb_name";
            this.Lb_name.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_name.Text = "名称１";
            this.Lb_name.Top = 0.4520834F;
            this.Lb_name.Width = 1.7F;
            // 
            // Lb_name2
            // 
            this.Lb_name2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_name2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_name2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_name2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_name2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_name2.Height = 0.15F;
            this.Lb_name2.HyperLink = "";
            this.Lb_name2.Left = 3.499999F;
            this.Lb_name2.MultiLine = false;
            this.Lb_name2.Name = "Lb_name2";
            this.Lb_name2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_name2.Text = "名称２";
            this.Lb_name2.Top = 0.4520834F;
            this.Lb_name2.Width = 1.7F;
            // 
            // Lb_customercode2
            // 
            this.Lb_customercode2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_customercode2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_customercode2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_customercode2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_customercode2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customercode2.Height = 0.15F;
            this.Lb_customercode2.HyperLink = "";
            this.Lb_customercode2.Left = 0F;
            this.Lb_customercode2.MultiLine = false;
            this.Lb_customercode2.Name = "Lb_customercode2";
            this.Lb_customercode2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_customercode2.Text = "得意先";
            this.Lb_customercode2.Top = 0.4520834F;
            this.Lb_customercode2.Width = 0.5F;
            // 
            // Lb_kana2
            // 
            this.Lb_kana2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_kana2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_kana2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_kana2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_kana2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_kana2.Height = 0.15F;
            this.Lb_kana2.HyperLink = "";
            this.Lb_kana2.Left = 0.4999996F;
            this.Lb_kana2.MultiLine = false;
            this.Lb_kana2.Name = "Lb_kana2";
            this.Lb_kana2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_kana2.Text = "ｶﾅ";
            this.Lb_kana2.Top = 0.6291668F;
            this.Lb_kana2.Width = 1.0625F;
            // 
            // Lb_postno2
            // 
            this.Lb_postno2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_postno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_postno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_postno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_postno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_postno2.Height = 0.15F;
            this.Lb_postno2.HyperLink = "";
            this.Lb_postno2.Left = 1.625F;
            this.Lb_postno2.MultiLine = false;
            this.Lb_postno2.Name = "Lb_postno2";
            this.Lb_postno2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_postno2.Text = "郵便番号";
            this.Lb_postno2.Top = 0.6291668F;
            this.Lb_postno2.Width = 0.6F;
            // 
            // Lb_address1
            // 
            this.Lb_address1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_address1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_address1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_address1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_address1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address1.Height = 0.15F;
            this.Lb_address1.HyperLink = "";
            this.Lb_address1.Left = 2.25F;
            this.Lb_address1.MultiLine = false;
            this.Lb_address1.Name = "Lb_address1";
            this.Lb_address1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_address1.Text = "住所１";
            this.Lb_address1.Top = 0.6291668F;
            this.Lb_address1.Width = 1.14F;
            // 
            // Lb_address3
            // 
            this.Lb_address3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_address3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_address3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_address3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_address3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address3.Height = 0.15F;
            this.Lb_address3.HyperLink = "";
            this.Lb_address3.Left = 5.3125F;
            this.Lb_address3.MultiLine = false;
            this.Lb_address3.Name = "Lb_address3";
            this.Lb_address3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_address3.Text = "住所２";
            this.Lb_address3.Top = 0.6291668F;
            this.Lb_address3.Width = 1.14F;
            // 
            // Lb_address4
            // 
            this.Lb_address4.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_address4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address4.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_address4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address4.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_address4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address4.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_address4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_address4.Height = 0.15F;
            this.Lb_address4.HyperLink = "";
            this.Lb_address4.Left = 7.5625F;
            this.Lb_address4.MultiLine = false;
            this.Lb_address4.Name = "Lb_address4";
            this.Lb_address4.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_address4.Text = "住所３";
            this.Lb_address4.Top = 0.6291668F;
            this.Lb_address4.Width = 1.14F;
            // 
            // Lb_officetelno2
            // 
            this.Lb_officetelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_officetelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_officetelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_officetelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_officetelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officetelno2.Height = 0.15F;
            this.Lb_officetelno2.HyperLink = "";
            this.Lb_officetelno2.Left = 6.541667F;
            this.Lb_officetelno2.MultiLine = false;
            this.Lb_officetelno2.Name = "Lb_officetelno2";
            this.Lb_officetelno2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_officetelno2.Text = "電話番号１";
            this.Lb_officetelno2.Top = 0.4520834F;
            this.Lb_officetelno2.Width = 0.92F;
            // 
            // Lb_portabletelno2
            // 
            this.Lb_portabletelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_portabletelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_portabletelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_portabletelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_portabletelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_portabletelno2.Height = 0.15F;
            this.Lb_portabletelno2.HyperLink = "";
            this.Lb_portabletelno2.Left = 7.479168F;
            this.Lb_portabletelno2.MultiLine = false;
            this.Lb_portabletelno2.Name = "Lb_portabletelno2";
            this.Lb_portabletelno2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_portabletelno2.Text = "電話番号２";
            this.Lb_portabletelno2.Top = 0.4520834F;
            this.Lb_portabletelno2.Width = 0.92F;
            // 
            // Lb_officefaxno2
            // 
            this.Lb_officefaxno2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_officefaxno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_officefaxno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_officefaxno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_officefaxno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_officefaxno2.Height = 0.15F;
            this.Lb_officefaxno2.HyperLink = "";
            this.Lb_officefaxno2.Left = 8.416668F;
            this.Lb_officefaxno2.MultiLine = false;
            this.Lb_officefaxno2.Name = "Lb_officefaxno2";
            this.Lb_officefaxno2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_officefaxno2.Text = "ＦＡＸ";
            this.Lb_officefaxno2.Top = 0.4520834F;
            this.Lb_officefaxno2.Width = 0.92F;
            // 
            // Lb_customeragentcd2
            // 
            this.Lb_customeragentcd2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_customeragentcd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_customeragentcd2.Height = 0.15F;
            this.Lb_customeragentcd2.HyperLink = "";
            this.Lb_customeragentcd2.Left = 9.4375F;
            this.Lb_customeragentcd2.MultiLine = false;
            this.Lb_customeragentcd2.Name = "Lb_customeragentcd2";
            this.Lb_customeragentcd2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_customeragentcd2.Text = "担当者";
            this.Lb_customeragentcd2.Top = 0.4520834F;
            this.Lb_customeragentcd2.Width = 0.92F;
            // 
            // Lb_custrategrpcodeALL
            // 
            this.Lb_custrategrpcodeALL.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcodeALL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcodeALL.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcodeALL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcodeALL.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcodeALL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcodeALL.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcodeALL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcodeALL.Height = 0.15F;
            this.Lb_custrategrpcodeALL.HyperLink = "";
            this.Lb_custrategrpcodeALL.Left = 2.25F;
            this.Lb_custrategrpcodeALL.MultiLine = false;
            this.Lb_custrategrpcodeALL.Name = "Lb_custrategrpcodeALL";
            this.Lb_custrategrpcodeALL.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcodeALL.Text = "純優";
            this.Lb_custrategrpcodeALL.Top = 0.8125F;
            this.Lb_custrategrpcodeALL.Width = 0.27F;
            // 
            // Lb_custrategrpcode00
            // 
            this.Lb_custrategrpcode00.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00.Height = 0.15F;
            this.Lb_custrategrpcode00.HyperLink = "";
            this.Lb_custrategrpcode00.Left = 2.564503F;
            this.Lb_custrategrpcode00.MultiLine = false;
            this.Lb_custrategrpcode00.Name = "Lb_custrategrpcode00";
            this.Lb_custrategrpcode00.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode00.Text = "純正";
            this.Lb_custrategrpcode00.Top = 0.8125F;
            this.Lb_custrategrpcode00.Width = 0.27F;
            // 
            // Lb_custrategrpcode01
            // 
            this.Lb_custrategrpcode01.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01.Height = 0.15F;
            this.Lb_custrategrpcode01.HyperLink = "";
            this.Lb_custrategrpcode01.Left = 2.879006F;
            this.Lb_custrategrpcode01.MultiLine = false;
            this.Lb_custrategrpcode01.Name = "Lb_custrategrpcode01";
            this.Lb_custrategrpcode01.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode01.Text = "01";
            this.Lb_custrategrpcode01.Top = 0.8125F;
            this.Lb_custrategrpcode01.Width = 0.25F;
            // 
            // Lb_custrategrpcode02
            // 
            this.Lb_custrategrpcode02.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02.Height = 0.15F;
            this.Lb_custrategrpcode02.HyperLink = "";
            this.Lb_custrategrpcode02.Left = 3.19351F;
            this.Lb_custrategrpcode02.MultiLine = false;
            this.Lb_custrategrpcode02.Name = "Lb_custrategrpcode02";
            this.Lb_custrategrpcode02.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode02.Text = "02";
            this.Lb_custrategrpcode02.Top = 0.8125F;
            this.Lb_custrategrpcode02.Width = 0.25F;
            // 
            // Lb_custrategrpcode03
            // 
            this.Lb_custrategrpcode03.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03.Height = 0.15F;
            this.Lb_custrategrpcode03.HyperLink = "";
            this.Lb_custrategrpcode03.Left = 3.508013F;
            this.Lb_custrategrpcode03.MultiLine = false;
            this.Lb_custrategrpcode03.Name = "Lb_custrategrpcode03";
            this.Lb_custrategrpcode03.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode03.Text = "03";
            this.Lb_custrategrpcode03.Top = 0.8125F;
            this.Lb_custrategrpcode03.Width = 0.25F;
            // 
            // Lb_custrategrpcode04
            // 
            this.Lb_custrategrpcode04.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04.Height = 0.15F;
            this.Lb_custrategrpcode04.HyperLink = "";
            this.Lb_custrategrpcode04.Left = 3.822516F;
            this.Lb_custrategrpcode04.MultiLine = false;
            this.Lb_custrategrpcode04.Name = "Lb_custrategrpcode04";
            this.Lb_custrategrpcode04.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode04.Text = "04";
            this.Lb_custrategrpcode04.Top = 0.8125F;
            this.Lb_custrategrpcode04.Width = 0.25F;
            // 
            // Lb_custrategrpcode05
            // 
            this.Lb_custrategrpcode05.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05.Height = 0.15F;
            this.Lb_custrategrpcode05.HyperLink = "";
            this.Lb_custrategrpcode05.Left = 4.137019F;
            this.Lb_custrategrpcode05.MultiLine = false;
            this.Lb_custrategrpcode05.Name = "Lb_custrategrpcode05";
            this.Lb_custrategrpcode05.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode05.Text = "05";
            this.Lb_custrategrpcode05.Top = 0.8125F;
            this.Lb_custrategrpcode05.Width = 0.25F;
            // 
            // Lb_custrategrpcode06
            // 
            this.Lb_custrategrpcode06.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06.Height = 0.15F;
            this.Lb_custrategrpcode06.HyperLink = "";
            this.Lb_custrategrpcode06.Left = 4.451522F;
            this.Lb_custrategrpcode06.MultiLine = false;
            this.Lb_custrategrpcode06.Name = "Lb_custrategrpcode06";
            this.Lb_custrategrpcode06.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode06.Text = "06";
            this.Lb_custrategrpcode06.Top = 0.8125F;
            this.Lb_custrategrpcode06.Width = 0.25F;
            // 
            // Lb_custrategrpcode07
            // 
            this.Lb_custrategrpcode07.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07.Height = 0.15F;
            this.Lb_custrategrpcode07.HyperLink = "";
            this.Lb_custrategrpcode07.Left = 4.766026F;
            this.Lb_custrategrpcode07.MultiLine = false;
            this.Lb_custrategrpcode07.Name = "Lb_custrategrpcode07";
            this.Lb_custrategrpcode07.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode07.Text = "07";
            this.Lb_custrategrpcode07.Top = 0.8125F;
            this.Lb_custrategrpcode07.Width = 0.25F;
            // 
            // Lb_custrategrpcode08
            // 
            this.Lb_custrategrpcode08.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08.Height = 0.15F;
            this.Lb_custrategrpcode08.HyperLink = "";
            this.Lb_custrategrpcode08.Left = 5.080529F;
            this.Lb_custrategrpcode08.MultiLine = false;
            this.Lb_custrategrpcode08.Name = "Lb_custrategrpcode08";
            this.Lb_custrategrpcode08.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode08.Text = "08";
            this.Lb_custrategrpcode08.Top = 0.8125F;
            this.Lb_custrategrpcode08.Width = 0.25F;
            // 
            // Lb_custrategrpcode09
            // 
            this.Lb_custrategrpcode09.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09.Height = 0.15F;
            this.Lb_custrategrpcode09.HyperLink = "";
            this.Lb_custrategrpcode09.Left = 5.395032F;
            this.Lb_custrategrpcode09.MultiLine = false;
            this.Lb_custrategrpcode09.Name = "Lb_custrategrpcode09";
            this.Lb_custrategrpcode09.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode09.Text = "09";
            this.Lb_custrategrpcode09.Top = 0.8125F;
            this.Lb_custrategrpcode09.Width = 0.25F;
            // 
            // Lb_custrategrpcode10
            // 
            this.Lb_custrategrpcode10.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10.Height = 0.15F;
            this.Lb_custrategrpcode10.HyperLink = "";
            this.Lb_custrategrpcode10.Left = 5.709535F;
            this.Lb_custrategrpcode10.MultiLine = false;
            this.Lb_custrategrpcode10.Name = "Lb_custrategrpcode10";
            this.Lb_custrategrpcode10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode10.Text = "10";
            this.Lb_custrategrpcode10.Top = 0.8125F;
            this.Lb_custrategrpcode10.Width = 0.25F;
            // 
            // Lb_custrategrpcode11
            // 
            this.Lb_custrategrpcode11.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11.Height = 0.15F;
            this.Lb_custrategrpcode11.HyperLink = "";
            this.Lb_custrategrpcode11.Left = 6.024038F;
            this.Lb_custrategrpcode11.MultiLine = false;
            this.Lb_custrategrpcode11.Name = "Lb_custrategrpcode11";
            this.Lb_custrategrpcode11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode11.Text = "11";
            this.Lb_custrategrpcode11.Top = 0.8125F;
            this.Lb_custrategrpcode11.Width = 0.25F;
            // 
            // Lb_custrategrpcode12
            // 
            this.Lb_custrategrpcode12.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12.Height = 0.15F;
            this.Lb_custrategrpcode12.HyperLink = "";
            this.Lb_custrategrpcode12.Left = 6.338542F;
            this.Lb_custrategrpcode12.MultiLine = false;
            this.Lb_custrategrpcode12.Name = "Lb_custrategrpcode12";
            this.Lb_custrategrpcode12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode12.Text = "12";
            this.Lb_custrategrpcode12.Top = 0.8125F;
            this.Lb_custrategrpcode12.Width = 0.25F;
            // 
            // Lb_custrategrpcode13
            // 
            this.Lb_custrategrpcode13.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13.Height = 0.15F;
            this.Lb_custrategrpcode13.HyperLink = "";
            this.Lb_custrategrpcode13.Left = 6.653045F;
            this.Lb_custrategrpcode13.MultiLine = false;
            this.Lb_custrategrpcode13.Name = "Lb_custrategrpcode13";
            this.Lb_custrategrpcode13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode13.Text = "13";
            this.Lb_custrategrpcode13.Top = 0.8125F;
            this.Lb_custrategrpcode13.Width = 0.25F;
            // 
            // Lb_custrategrpcode14
            // 
            this.Lb_custrategrpcode14.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14.Height = 0.15F;
            this.Lb_custrategrpcode14.HyperLink = "";
            this.Lb_custrategrpcode14.Left = 6.967548F;
            this.Lb_custrategrpcode14.MultiLine = false;
            this.Lb_custrategrpcode14.Name = "Lb_custrategrpcode14";
            this.Lb_custrategrpcode14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode14.Text = "14";
            this.Lb_custrategrpcode14.Top = 0.8125F;
            this.Lb_custrategrpcode14.Width = 0.25F;
            // 
            // Lb_custrategrpcode15
            // 
            this.Lb_custrategrpcode15.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15.Height = 0.15F;
            this.Lb_custrategrpcode15.HyperLink = "";
            this.Lb_custrategrpcode15.Left = 7.282051F;
            this.Lb_custrategrpcode15.MultiLine = false;
            this.Lb_custrategrpcode15.Name = "Lb_custrategrpcode15";
            this.Lb_custrategrpcode15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode15.Text = "15";
            this.Lb_custrategrpcode15.Top = 0.8125F;
            this.Lb_custrategrpcode15.Width = 0.25F;
            // 
            // Lb_custrategrpcode16
            // 
            this.Lb_custrategrpcode16.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16.Height = 0.15F;
            this.Lb_custrategrpcode16.HyperLink = "";
            this.Lb_custrategrpcode16.Left = 7.596554F;
            this.Lb_custrategrpcode16.MultiLine = false;
            this.Lb_custrategrpcode16.Name = "Lb_custrategrpcode16";
            this.Lb_custrategrpcode16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode16.Text = "16";
            this.Lb_custrategrpcode16.Top = 0.8125F;
            this.Lb_custrategrpcode16.Width = 0.25F;
            // 
            // Lb_custrategrpcode17
            // 
            this.Lb_custrategrpcode17.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17.Height = 0.15F;
            this.Lb_custrategrpcode17.HyperLink = "";
            this.Lb_custrategrpcode17.Left = 7.911057F;
            this.Lb_custrategrpcode17.MultiLine = false;
            this.Lb_custrategrpcode17.Name = "Lb_custrategrpcode17";
            this.Lb_custrategrpcode17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode17.Text = "17";
            this.Lb_custrategrpcode17.Top = 0.8125F;
            this.Lb_custrategrpcode17.Width = 0.25F;
            // 
            // Lb_custrategrpcode18
            // 
            this.Lb_custrategrpcode18.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18.Height = 0.15F;
            this.Lb_custrategrpcode18.HyperLink = "";
            this.Lb_custrategrpcode18.Left = 8.225561F;
            this.Lb_custrategrpcode18.MultiLine = false;
            this.Lb_custrategrpcode18.Name = "Lb_custrategrpcode18";
            this.Lb_custrategrpcode18.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode18.Text = "18";
            this.Lb_custrategrpcode18.Top = 0.8125F;
            this.Lb_custrategrpcode18.Width = 0.25F;
            // 
            // Lb_custrategrpcode19
            // 
            this.Lb_custrategrpcode19.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19.Height = 0.15F;
            this.Lb_custrategrpcode19.HyperLink = "";
            this.Lb_custrategrpcode19.Left = 8.540065F;
            this.Lb_custrategrpcode19.MultiLine = false;
            this.Lb_custrategrpcode19.Name = "Lb_custrategrpcode19";
            this.Lb_custrategrpcode19.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode19.Text = "19";
            this.Lb_custrategrpcode19.Top = 0.8125F;
            this.Lb_custrategrpcode19.Width = 0.25F;
            // 
            // Lb_custrategrpcode20
            // 
            this.Lb_custrategrpcode20.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20.Height = 0.15F;
            this.Lb_custrategrpcode20.HyperLink = "";
            this.Lb_custrategrpcode20.Left = 8.854568F;
            this.Lb_custrategrpcode20.MultiLine = false;
            this.Lb_custrategrpcode20.Name = "Lb_custrategrpcode20";
            this.Lb_custrategrpcode20.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode20.Text = "20";
            this.Lb_custrategrpcode20.Top = 0.8125F;
            this.Lb_custrategrpcode20.Width = 0.25F;
            // 
            // Lb_custrategrpcode21
            // 
            this.Lb_custrategrpcode21.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21.Height = 0.15F;
            this.Lb_custrategrpcode21.HyperLink = "";
            this.Lb_custrategrpcode21.Left = 9.169072F;
            this.Lb_custrategrpcode21.MultiLine = false;
            this.Lb_custrategrpcode21.Name = "Lb_custrategrpcode21";
            this.Lb_custrategrpcode21.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode21.Text = "21";
            this.Lb_custrategrpcode21.Top = 0.8125F;
            this.Lb_custrategrpcode21.Width = 0.25F;
            // 
            // Lb_custrategrpcode22
            // 
            this.Lb_custrategrpcode22.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22.Height = 0.15F;
            this.Lb_custrategrpcode22.HyperLink = "";
            this.Lb_custrategrpcode22.Left = 9.483576F;
            this.Lb_custrategrpcode22.MultiLine = false;
            this.Lb_custrategrpcode22.Name = "Lb_custrategrpcode22";
            this.Lb_custrategrpcode22.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode22.Text = "22";
            this.Lb_custrategrpcode22.Top = 0.8125F;
            this.Lb_custrategrpcode22.Width = 0.25F;
            // 
            // Lb_custrategrpcode23
            // 
            this.Lb_custrategrpcode23.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23.Height = 0.15F;
            this.Lb_custrategrpcode23.HyperLink = "";
            this.Lb_custrategrpcode23.Left = 9.798079F;
            this.Lb_custrategrpcode23.MultiLine = false;
            this.Lb_custrategrpcode23.Name = "Lb_custrategrpcode23";
            this.Lb_custrategrpcode23.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode23.Text = "23";
            this.Lb_custrategrpcode23.Top = 0.8125F;
            this.Lb_custrategrpcode23.Width = 0.25F;
            // 
            // Lb_custrategrpcode24
            // 
            this.Lb_custrategrpcode24.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24.Height = 0.15F;
            this.Lb_custrategrpcode24.HyperLink = "";
            this.Lb_custrategrpcode24.Left = 10.11258F;
            this.Lb_custrategrpcode24.MultiLine = false;
            this.Lb_custrategrpcode24.Name = "Lb_custrategrpcode24";
            this.Lb_custrategrpcode24.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode24.Text = "24";
            this.Lb_custrategrpcode24.Top = 0.8125F;
            this.Lb_custrategrpcode24.Width = 0.25F;
            // 
            // Lb_custrategrpcode25
            // 
            this.Lb_custrategrpcode25.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25.Height = 0.15F;
            this.Lb_custrategrpcode25.HyperLink = "";
            this.Lb_custrategrpcode25.Left = 10.42708F;
            this.Lb_custrategrpcode25.MultiLine = false;
            this.Lb_custrategrpcode25.Name = "Lb_custrategrpcode25";
            this.Lb_custrategrpcode25.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.Lb_custrategrpcode25.Text = "25";
            this.Lb_custrategrpcode25.Top = 0.8125F;
            this.Lb_custrategrpcode25.Width = 0.25F;
            // 
            // Lb_custrategrpcode01_2
            // 
            this.Lb_custrategrpcode01_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode01_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode01_2.Height = 0.15F;
            this.Lb_custrategrpcode01_2.HyperLink = "";
            this.Lb_custrategrpcode01_2.Left = 2.875F;
            this.Lb_custrategrpcode01_2.MultiLine = false;
            this.Lb_custrategrpcode01_2.Name = "Lb_custrategrpcode01_2";
            this.Lb_custrategrpcode01_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode01_2.Text = "XXXX";
            this.Lb_custrategrpcode01_2.Top = 0.9583333F;
            this.Lb_custrategrpcode01_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode02_2
            // 
            this.Lb_custrategrpcode02_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode02_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode02_2.Height = 0.15F;
            this.Lb_custrategrpcode02_2.HyperLink = "";
            this.Lb_custrategrpcode02_2.Left = 3.19351F;
            this.Lb_custrategrpcode02_2.MultiLine = false;
            this.Lb_custrategrpcode02_2.Name = "Lb_custrategrpcode02_2";
            this.Lb_custrategrpcode02_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode02_2.Text = "XXXX";
            this.Lb_custrategrpcode02_2.Top = 0.9583333F;
            this.Lb_custrategrpcode02_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode03_2
            // 
            this.Lb_custrategrpcode03_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode03_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode03_2.Height = 0.15F;
            this.Lb_custrategrpcode03_2.HyperLink = "";
            this.Lb_custrategrpcode03_2.Left = 3.508013F;
            this.Lb_custrategrpcode03_2.MultiLine = false;
            this.Lb_custrategrpcode03_2.Name = "Lb_custrategrpcode03_2";
            this.Lb_custrategrpcode03_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode03_2.Text = "XXXX";
            this.Lb_custrategrpcode03_2.Top = 0.9583333F;
            this.Lb_custrategrpcode03_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode04_2
            // 
            this.Lb_custrategrpcode04_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode04_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode04_2.Height = 0.15F;
            this.Lb_custrategrpcode04_2.HyperLink = "";
            this.Lb_custrategrpcode04_2.Left = 3.822516F;
            this.Lb_custrategrpcode04_2.MultiLine = false;
            this.Lb_custrategrpcode04_2.Name = "Lb_custrategrpcode04_2";
            this.Lb_custrategrpcode04_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode04_2.Text = "XXXX";
            this.Lb_custrategrpcode04_2.Top = 0.9583333F;
            this.Lb_custrategrpcode04_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode05_2
            // 
            this.Lb_custrategrpcode05_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode05_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode05_2.Height = 0.15F;
            this.Lb_custrategrpcode05_2.HyperLink = "";
            this.Lb_custrategrpcode05_2.Left = 4.137019F;
            this.Lb_custrategrpcode05_2.MultiLine = false;
            this.Lb_custrategrpcode05_2.Name = "Lb_custrategrpcode05_2";
            this.Lb_custrategrpcode05_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode05_2.Text = "XXXX";
            this.Lb_custrategrpcode05_2.Top = 0.9583333F;
            this.Lb_custrategrpcode05_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode06_2
            // 
            this.Lb_custrategrpcode06_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode06_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode06_2.Height = 0.15F;
            this.Lb_custrategrpcode06_2.HyperLink = "";
            this.Lb_custrategrpcode06_2.Left = 4.451522F;
            this.Lb_custrategrpcode06_2.MultiLine = false;
            this.Lb_custrategrpcode06_2.Name = "Lb_custrategrpcode06_2";
            this.Lb_custrategrpcode06_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode06_2.Text = "XXXX";
            this.Lb_custrategrpcode06_2.Top = 0.9583333F;
            this.Lb_custrategrpcode06_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode07_2
            // 
            this.Lb_custrategrpcode07_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode07_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode07_2.Height = 0.15F;
            this.Lb_custrategrpcode07_2.HyperLink = "";
            this.Lb_custrategrpcode07_2.Left = 4.766026F;
            this.Lb_custrategrpcode07_2.MultiLine = false;
            this.Lb_custrategrpcode07_2.Name = "Lb_custrategrpcode07_2";
            this.Lb_custrategrpcode07_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode07_2.Text = "XXXX";
            this.Lb_custrategrpcode07_2.Top = 0.9583333F;
            this.Lb_custrategrpcode07_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode08_2
            // 
            this.Lb_custrategrpcode08_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode08_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode08_2.Height = 0.15F;
            this.Lb_custrategrpcode08_2.HyperLink = "";
            this.Lb_custrategrpcode08_2.Left = 5.080529F;
            this.Lb_custrategrpcode08_2.MultiLine = false;
            this.Lb_custrategrpcode08_2.Name = "Lb_custrategrpcode08_2";
            this.Lb_custrategrpcode08_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode08_2.Text = "XXXX";
            this.Lb_custrategrpcode08_2.Top = 0.9583333F;
            this.Lb_custrategrpcode08_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode09_2
            // 
            this.Lb_custrategrpcode09_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode09_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode09_2.Height = 0.15F;
            this.Lb_custrategrpcode09_2.HyperLink = "";
            this.Lb_custrategrpcode09_2.Left = 5.395032F;
            this.Lb_custrategrpcode09_2.MultiLine = false;
            this.Lb_custrategrpcode09_2.Name = "Lb_custrategrpcode09_2";
            this.Lb_custrategrpcode09_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode09_2.Text = "XXXX";
            this.Lb_custrategrpcode09_2.Top = 0.9583333F;
            this.Lb_custrategrpcode09_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode10_2
            // 
            this.Lb_custrategrpcode10_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode10_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode10_2.Height = 0.15F;
            this.Lb_custrategrpcode10_2.HyperLink = "";
            this.Lb_custrategrpcode10_2.Left = 5.709535F;
            this.Lb_custrategrpcode10_2.MultiLine = false;
            this.Lb_custrategrpcode10_2.Name = "Lb_custrategrpcode10_2";
            this.Lb_custrategrpcode10_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode10_2.Text = "XXXX";
            this.Lb_custrategrpcode10_2.Top = 0.9583333F;
            this.Lb_custrategrpcode10_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode11_2
            // 
            this.Lb_custrategrpcode11_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode11_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode11_2.Height = 0.15F;
            this.Lb_custrategrpcode11_2.HyperLink = "";
            this.Lb_custrategrpcode11_2.Left = 6.024038F;
            this.Lb_custrategrpcode11_2.MultiLine = false;
            this.Lb_custrategrpcode11_2.Name = "Lb_custrategrpcode11_2";
            this.Lb_custrategrpcode11_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode11_2.Text = "XXXX";
            this.Lb_custrategrpcode11_2.Top = 0.9583333F;
            this.Lb_custrategrpcode11_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode12_2
            // 
            this.Lb_custrategrpcode12_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode12_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode12_2.Height = 0.15F;
            this.Lb_custrategrpcode12_2.HyperLink = "";
            this.Lb_custrategrpcode12_2.Left = 6.338542F;
            this.Lb_custrategrpcode12_2.MultiLine = false;
            this.Lb_custrategrpcode12_2.Name = "Lb_custrategrpcode12_2";
            this.Lb_custrategrpcode12_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode12_2.Text = "XXXX";
            this.Lb_custrategrpcode12_2.Top = 0.9583333F;
            this.Lb_custrategrpcode12_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode13_2
            // 
            this.Lb_custrategrpcode13_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode13_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode13_2.Height = 0.15F;
            this.Lb_custrategrpcode13_2.HyperLink = "";
            this.Lb_custrategrpcode13_2.Left = 6.653045F;
            this.Lb_custrategrpcode13_2.MultiLine = false;
            this.Lb_custrategrpcode13_2.Name = "Lb_custrategrpcode13_2";
            this.Lb_custrategrpcode13_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode13_2.Text = "XXXX";
            this.Lb_custrategrpcode13_2.Top = 0.9583333F;
            this.Lb_custrategrpcode13_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode14_2
            // 
            this.Lb_custrategrpcode14_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode14_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode14_2.Height = 0.15F;
            this.Lb_custrategrpcode14_2.HyperLink = "";
            this.Lb_custrategrpcode14_2.Left = 6.967548F;
            this.Lb_custrategrpcode14_2.MultiLine = false;
            this.Lb_custrategrpcode14_2.Name = "Lb_custrategrpcode14_2";
            this.Lb_custrategrpcode14_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode14_2.Text = "XXXX";
            this.Lb_custrategrpcode14_2.Top = 0.9583333F;
            this.Lb_custrategrpcode14_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode15_2
            // 
            this.Lb_custrategrpcode15_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode15_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode15_2.Height = 0.15F;
            this.Lb_custrategrpcode15_2.HyperLink = "";
            this.Lb_custrategrpcode15_2.Left = 7.282051F;
            this.Lb_custrategrpcode15_2.MultiLine = false;
            this.Lb_custrategrpcode15_2.Name = "Lb_custrategrpcode15_2";
            this.Lb_custrategrpcode15_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode15_2.Text = "XXXX";
            this.Lb_custrategrpcode15_2.Top = 0.9583333F;
            this.Lb_custrategrpcode15_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode16_2
            // 
            this.Lb_custrategrpcode16_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode16_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode16_2.Height = 0.15F;
            this.Lb_custrategrpcode16_2.HyperLink = "";
            this.Lb_custrategrpcode16_2.Left = 7.596554F;
            this.Lb_custrategrpcode16_2.MultiLine = false;
            this.Lb_custrategrpcode16_2.Name = "Lb_custrategrpcode16_2";
            this.Lb_custrategrpcode16_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode16_2.Text = "XXXX";
            this.Lb_custrategrpcode16_2.Top = 0.9583333F;
            this.Lb_custrategrpcode16_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode17_2
            // 
            this.Lb_custrategrpcode17_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode17_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode17_2.Height = 0.15F;
            this.Lb_custrategrpcode17_2.HyperLink = "";
            this.Lb_custrategrpcode17_2.Left = 7.911057F;
            this.Lb_custrategrpcode17_2.MultiLine = false;
            this.Lb_custrategrpcode17_2.Name = "Lb_custrategrpcode17_2";
            this.Lb_custrategrpcode17_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode17_2.Text = "XXXX";
            this.Lb_custrategrpcode17_2.Top = 0.9583333F;
            this.Lb_custrategrpcode17_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode18_2
            // 
            this.Lb_custrategrpcode18_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode18_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode18_2.Height = 0.15F;
            this.Lb_custrategrpcode18_2.HyperLink = "";
            this.Lb_custrategrpcode18_2.Left = 8.225561F;
            this.Lb_custrategrpcode18_2.MultiLine = false;
            this.Lb_custrategrpcode18_2.Name = "Lb_custrategrpcode18_2";
            this.Lb_custrategrpcode18_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode18_2.Text = "XXXX";
            this.Lb_custrategrpcode18_2.Top = 0.9583333F;
            this.Lb_custrategrpcode18_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode19_2
            // 
            this.Lb_custrategrpcode19_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode19_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode19_2.Height = 0.15F;
            this.Lb_custrategrpcode19_2.HyperLink = "";
            this.Lb_custrategrpcode19_2.Left = 8.540065F;
            this.Lb_custrategrpcode19_2.MultiLine = false;
            this.Lb_custrategrpcode19_2.Name = "Lb_custrategrpcode19_2";
            this.Lb_custrategrpcode19_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode19_2.Text = "XXXX";
            this.Lb_custrategrpcode19_2.Top = 0.9583333F;
            this.Lb_custrategrpcode19_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode20_2
            // 
            this.Lb_custrategrpcode20_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode20_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode20_2.Height = 0.15F;
            this.Lb_custrategrpcode20_2.HyperLink = "";
            this.Lb_custrategrpcode20_2.Left = 8.854568F;
            this.Lb_custrategrpcode20_2.MultiLine = false;
            this.Lb_custrategrpcode20_2.Name = "Lb_custrategrpcode20_2";
            this.Lb_custrategrpcode20_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode20_2.Text = "XXXX";
            this.Lb_custrategrpcode20_2.Top = 0.9583333F;
            this.Lb_custrategrpcode20_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode21_2
            // 
            this.Lb_custrategrpcode21_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode21_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode21_2.Height = 0.15F;
            this.Lb_custrategrpcode21_2.HyperLink = "";
            this.Lb_custrategrpcode21_2.Left = 9.169072F;
            this.Lb_custrategrpcode21_2.MultiLine = false;
            this.Lb_custrategrpcode21_2.Name = "Lb_custrategrpcode21_2";
            this.Lb_custrategrpcode21_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode21_2.Text = "XXXX";
            this.Lb_custrategrpcode21_2.Top = 0.9583333F;
            this.Lb_custrategrpcode21_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode22_2
            // 
            this.Lb_custrategrpcode22_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode22_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode22_2.Height = 0.15F;
            this.Lb_custrategrpcode22_2.HyperLink = "";
            this.Lb_custrategrpcode22_2.Left = 9.483576F;
            this.Lb_custrategrpcode22_2.MultiLine = false;
            this.Lb_custrategrpcode22_2.Name = "Lb_custrategrpcode22_2";
            this.Lb_custrategrpcode22_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode22_2.Text = "XXXX";
            this.Lb_custrategrpcode22_2.Top = 0.9583333F;
            this.Lb_custrategrpcode22_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode23_2
            // 
            this.Lb_custrategrpcode23_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode23_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode23_2.Height = 0.15F;
            this.Lb_custrategrpcode23_2.HyperLink = "";
            this.Lb_custrategrpcode23_2.Left = 9.798079F;
            this.Lb_custrategrpcode23_2.MultiLine = false;
            this.Lb_custrategrpcode23_2.Name = "Lb_custrategrpcode23_2";
            this.Lb_custrategrpcode23_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode23_2.Text = "XXXX";
            this.Lb_custrategrpcode23_2.Top = 0.9583333F;
            this.Lb_custrategrpcode23_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode24_2
            // 
            this.Lb_custrategrpcode24_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode24_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode24_2.Height = 0.15F;
            this.Lb_custrategrpcode24_2.HyperLink = "";
            this.Lb_custrategrpcode24_2.Left = 10.11258F;
            this.Lb_custrategrpcode24_2.MultiLine = false;
            this.Lb_custrategrpcode24_2.Name = "Lb_custrategrpcode24_2";
            this.Lb_custrategrpcode24_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode24_2.Text = "XXXX";
            this.Lb_custrategrpcode24_2.Top = 0.9583333F;
            this.Lb_custrategrpcode24_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode25_2
            // 
            this.Lb_custrategrpcode25_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode25_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode25_2.Height = 0.15F;
            this.Lb_custrategrpcode25_2.HyperLink = "";
            this.Lb_custrategrpcode25_2.Left = 10.42708F;
            this.Lb_custrategrpcode25_2.MultiLine = false;
            this.Lb_custrategrpcode25_2.Name = "Lb_custrategrpcode25_2";
            this.Lb_custrategrpcode25_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode25_2.Text = "XXXX";
            this.Lb_custrategrpcode25_2.Top = 0.9583333F;
            this.Lb_custrategrpcode25_2.Width = 0.3F;
            // 
            // Lb_custrategrpcode00_2
            // 
            this.Lb_custrategrpcode00_2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00_2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00_2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00_2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00_2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00_2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00_2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_custrategrpcode00_2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_custrategrpcode00_2.Height = 0.15F;
            this.Lb_custrategrpcode00_2.HyperLink = "";
            this.Lb_custrategrpcode00_2.Left = 2.5625F;
            this.Lb_custrategrpcode00_2.MultiLine = false;
            this.Lb_custrategrpcode00_2.Name = "Lb_custrategrpcode00_2";
            this.Lb_custrategrpcode00_2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_custrategrpcode00_2.Text = "ALL";
            this.Lb_custrategrpcode00_2.Top = 0.9583333F;
            this.Lb_custrategrpcode00_2.Width = 0.3F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0.005787037F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08555P_01A4C
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
            this.PageEnd += new System.EventHandler(this.PMKHN08555P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08555P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.kana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customercode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officetelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portabletelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officefaxno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectmoneynameday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentcd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareacode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesareaname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businesstypename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claimsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claimcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billcollectercd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidesnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custwarehousecd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.name2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officetelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portabletelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officefaxno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentcd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customeragentname2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customercode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kana2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcodeALL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custrategrpcode00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customercode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_kana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_postno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officetelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_totalday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_collectmoneynameday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_businesstypecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_claimsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_addressall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customeragentcd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_mngsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_salesareacode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_billcollectercd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_portabletelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officefaxno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custwarehousecd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_name2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customercode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_kana2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_postno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_address1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_address3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_address4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officetelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_portabletelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_officefaxno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_customeragentcd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcodeALL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode01_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode02_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode03_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode04_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode05_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode06_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode07_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode08_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode09_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode10_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode11_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode12_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode13_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode14_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode15_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode16_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode17_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode18_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode19_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode20_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode21_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode22_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode23_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode24_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode25_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_custrategrpcode00_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
