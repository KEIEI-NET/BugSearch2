using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 支払確認表(金種別)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払確認表(金種別)のフォームクラスです。</br>
	/// <br>Programmer	: 20081　疋田　勇人</br>
	/// <br>Date		: 2007.09.10</br>
    /// <br>UpdateNote  : 2008/08/05 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br> 	
    /// <br>UpdateNote　: 2009/03/27 30452 上野 俊治</br>
    /// <br>            ・障害対応11467,11468</br>
    /// <br>Update Note : 2014/09/15 zhangll</br>
    /// <br>              ㈱陸整自動車用品 罫線印字区分、改頁区分の追加</br>
    /// </remarks>
	public class DCKAK02523P_04A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 支払確認表(金種別)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 支払確認表(金種別)フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 20081　疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
		/// </remarks>
		public DCKAK02523P_04A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			 _otherDataList;				// その他データ

		private	PaymentMainCndtn	 _paymentMainCndtn;				// 抽出条件クラス

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //// その他データ格納項目
        //private string				 _sumTitle;						// 小計タイトル
        //private string				 _agentKindTitle;				// 担当者タイトル
        //private string				 _detailAddupSecNameTtl;		// 明細拠点名称タイトル
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		private int					 _printCount;					// ページ数カウント用

		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
		ListCommon_PageFooter _rptPageFooter	= null;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Label label10;
        private TextBox tb_AddUpSecName;
        private TextBox tb_AddUpSecCode;
        private Line Line43;
        private Line Line45;

		// Disposeチェック用フラグ
		bool disposed = false;
        private Label PaymentKind04_Title;
        private Label FeePayment_Title;
        private Label DiscountPayment_Title;
        private Label Label108;
        private Label PaymentKind07_Title;
        private Label PaymentKind02_Title;
        private Label PaymentKind03_Title;
        private Label PaymentKind05_Title;
        private Label PaymentKind06_Title;
        private Label PaymentKind01_Title;
        private Label PaymentKind08_Title;
        private Label Label104;
        private TextBox PaymentKind02;
        private TextBox DiscountPayment;
        private TextBox PaymentTotal;
        private TextBox PayeeCode;
        private TextBox PayeeSnm;
        private TextBox PaymentKind01;
        private TextBox FeePayment;
        private TextBox PaymentKind04;
        private TextBox PaymentKind03;
        private TextBox PaymentKind05;
        private TextBox PaymentKind06;
        private TextBox PaymentKind07;
        private TextBox PaymentKind08;
        private TextBox Section_PaymentKind02;
        private TextBox Section_DiscountPayment;
        private TextBox Section_PaymentTotal;
        private TextBox Section_PaymentKind03;
        private TextBox Section_FeePayment;
        private TextBox Section_PaymentKind04;
        private TextBox Section_PaymentKind06;
        private TextBox Section_PaymentKind05;
        private TextBox Section_PaymentKind01;
        private TextBox Section_PaymentKind07;
        private TextBox Section_PaymentKind08;
        private TextBox Total_PaymentKind05;
        private TextBox Total_DiscountPayment;
        private TextBox Total_PaymentTotal;
        private TextBox Total_PaymentKind03;
        private TextBox Total_PaymentKind02;
        private TextBox Total_PaymentKind04;
        private TextBox Total_PaymentKind06;
        private TextBox Total_FeePayment;
        private TextBox Total_PaymentKind01;
        private TextBox Total_PaymentKind07;
        private TextBox Total_PaymentKind08;
        private Line line2;
        private Line line3;
        private Line TitleHeader_Line2;
        private Label label15;
        private Line line4;

        // --- ADD 2008/08/05 -------------------------------->>>>>
        private Dictionary<int, string> _dicKindName;
        // --- ADD 2008/08/05 --------------------------------<<<<< 

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
		#endregion

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
				this._printInfo = value;
				this._paymentMainCndtn = (PaymentMainCndtn)this._printInfo.jyoken;
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
				if (this._otherDataList != null)
				{
					if ( this._otherDataList.Count > 0 )
					{
                        // --- DEL 2008/08/05 -------------------------------->>>>>
                        //this._sumTitle				= this._otherDataList[0].ToString();
                        //this._agentKindTitle		= this._otherDataList[1].ToString();
                        //this._detailAddupSecNameTtl = this._otherDataList[2].ToString();
                        // --- DEL 2008/08/05 --------------------------------<<<<< 

                        this._dicKindName = (Dictionary<int, string>)this._otherDataList[0];  // 金種名称  // ADD 2008/08/05
					}
				}
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
				// TODO:  MAHNB02012P_03A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAHNB02012P_03A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
            // 印字設定 --------------------------------------------------------------------------------------
            // 拠点計を出力するかしないかを選択する
            // 拠点有無を判断
            // --- DEL 2008/08/05 -------------------------------->>>>>
            //if (this._paymentMainCndtn.IsOptSection)
            //{
            //    // 全社がチェックされていない時で拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ((this._paymentMainCndtn.PaymentAddupSecCodeList.Length < 2) && (this._paymentMainCndtn.IsSelectAllSection == false))
            //    {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else
            //    {
            // --- DEL 2008/08/05 --------------------------------<<<<< 

                    SectionHeader.DataField = DCKAK02525EA.Col_AddUpSecCode;
                    SectionHeader.Visible = true;
                    SectionFooter.Visible = true;

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //    }
            //}
            //else
            //{
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}		
            // --- DEL 2008/08/05 --------------------------------<<<<< 

			// 項目の名称をセット
			//tb_ReportTitle.Text			= this._pageHeaderSubtitle;			// サブタイトル  // DEL 2008/08/05
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;		// ソート条件

            // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 ----->>>>>
            //罫線印字区分
            if (this._paymentMainCndtn.LineMaSqOfChDiv == 0)
            {
                //罫線印字する
                this.Line43.Visible = true;
                this.Line45.Visible = true;
                this.line2.Visible = true;
                this.TitleHeader_Line2.Visible = true;
                this.line4.Visible = false;
            }
            else
            {
                //罫線印字しない
                this.Line43.Visible = false;
                this.Line45.Visible = false;
                this.line2.Visible = false;
                this.TitleHeader_Line2.Visible = false;
                this.line4.Visible = true;
            }

            //改頁
            if (this._paymentMainCndtn.NewPageType == 0)
            {
                //拠点
                SectionHeader.NewPage = NewPage.Before;
                SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                //改頁しない
                SectionHeader.NewPage = NewPage.None;
                SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 -----<<<<<
		}
		#endregion
		#endregion

        /// <summary>
        /// 金種コードの印刷設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レポートの金種コードの印刷設定</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date	   : 2008/08/05</br>
        /// </remarks>
        public void SettingKindName()
        {
            //for (int index = 0; index < 10; index++) // DEL 2009/03/27
            for (int index = 0; index < 8; index++) // ADD 2009/03/27
            {
                if (index < this._dicKindName.Count)
                {
                    switch (index)
                    {
                        case 0:  // 金種１
                            {
                                // 金種１タイトル表示
                                this.PaymentKind01_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 1:  // 金種２
                            {
                                // 金種２タイトル表示
                                this.PaymentKind02_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 2:  // 金種３
                            {
                                // 金種３タイトル表示
                                this.PaymentKind03_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 3:  // 金種４
                            {
                                // 金種４タイトル表示
                                this.PaymentKind04_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 4:  // 金種５
                            {
                                // 金種５タイトル表示
                                this.PaymentKind05_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 5:  // 金種６
                            {
                                // 金種６タイトル表示
                                this.PaymentKind06_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 6:  // 金種７
                            {
                                // 金種７タイトル表示
                                this.PaymentKind07_Title.Text = this._dicKindName[index];
                                break;
                            }
                        case 7:  // 金種８
                            {
                                // 金種８タイトル表示
                                this.PaymentKind08_Title.Text = this._dicKindName[index];
                                //this.TitleHeader_Line1.Visible = false; // DEL 2009/03/27
                                //this.TitleHeader_Line2.Visible = true; // DEL 2009/03/27
                                break;
                            }
                        // --- DEL 2009/03/27 -------------------------------->>>>>
                        //case 8:  // 金種９
                        //    {
                        //        // 金種９タイトル表示
                        //        this.PaymentKind09_Title.Text = this._dicKindName[index];
                        //        break;
                        //    }
                        //case 9:  // 金種１０
                        //    {
                        //        // 金種１０タイトル表示
                        //        this.PaymentKind10_Title.Text = this._dicKindName[index];
                        //        break;
                        //    }
                        // --- DEL 2009/03/27 --------------------------------<<<<<
                    }
                }
                else
                {
                    switch (index)
                    {
                        case 0:  // 金種１
                            {
                                // 金種１のコントロールを非表示にする
                                this.PaymentKind01_Title.Visible = false;
                                this.PaymentKind01.Visible = false;
                                this.Section_PaymentKind01.Visible = false;
                                this.Total_PaymentKind01.Visible = false;
                                break;
                            }
                        case 1:  // 金種２
                            {
                                // 金種２のコントロールを非表示にする
                                this.PaymentKind02_Title.Visible = false;
                                this.PaymentKind02.Visible = false;
                                this.Section_PaymentKind02.Visible = false;
                                this.Total_PaymentKind02.Visible = false;
                                break;
                            }
                        case 2:  // 金種３
                            {
                                // 金種３のコントロールを非表示にする
                                this.PaymentKind03_Title.Visible = false;
                                this.PaymentKind03.Visible = false;
                                this.Section_PaymentKind03.Visible = false;
                                this.Total_PaymentKind03.Visible = false;
                                break;
                            }
                        case 3:  // 金種４
                            {
                                // 金種４のコントロールを非表示にする
                                this.PaymentKind04_Title.Visible = false;
                                this.PaymentKind04.Visible = false;
                                this.Section_PaymentKind04.Visible = false;
                                this.Total_PaymentKind04.Visible = false;
                                break;
                            }
                        case 4:  // 金種５
                            {
                                // 金種５のコントロールを非表示にする
                                this.PaymentKind05_Title.Visible = false;
                                this.PaymentKind05.Visible = false;
                                this.Section_PaymentKind05.Visible = false;
                                this.Total_PaymentKind05.Visible = false;
                                break;
                            }
                        case 5:  // 金種６
                            {
                                // 金種６のコントロールを非表示にする
                                this.PaymentKind06_Title.Visible = false;
                                this.PaymentKind06.Visible = false;
                                this.Section_PaymentKind06.Visible = false;
                                this.Total_PaymentKind06.Visible = false;
                                break;
                            }
                        case 6:  // 金種７
                            {
                                // 金種７のコントロールを非表示にする
                                this.PaymentKind07_Title.Visible = false;
                                this.PaymentKind07.Visible = false;
                                this.Section_PaymentKind07.Visible = false;
                                this.Total_PaymentKind07.Visible = false;
                                break;
                            }
                        case 7:  // 金種８
                            {
                                // 金種８のコントロールを非表示にする
                                this.PaymentKind08_Title.Visible = false;
                                this.PaymentKind08.Visible = false;
                                this.Section_PaymentKind08.Visible = false;
                                this.Total_PaymentKind08.Visible = false;
                                //this.TitleHeader_Line1.Visible = true; // DEL 2009/03/27
                                //this.TitleHeader_Line2.Visible = false; // DEL 2009/03/27
                                break;
                            }
                        // --- DEL 2009/03/27 -------------------------------->>>>>
                        //case 8:  // 金種９
                        //    {
                        //        // 金種９のコントロールを非表示にする
                        //        this.PaymentKind09_Title.Visible = false;
                        //        this.PaymentKind09.Visible = false;
                        //        this.Section_PaymentKind09.Visible = false;
                        //        this.Total_PaymentKind09.Visible = false;
                        //        break;
                        //    }
                        //case 9:  // 金種１０
                        //    {
                        //        // 金種１０のコントロールを非表示にする
                        //        this.PaymentKind10_Title.Visible = false;
                        //        this.PaymentKind10.Visible = false;
                        //        this.Section_PaymentKind10.Visible = false;
                        //        this.Total_PaymentKind10.Visible = false;
                        //        break;
                        //    }
                        // --- DEL 2009/03/27 --------------------------------<<<<<
                    }
                }
            }

            // --- ADD 2009/03/27 -------------------------------->>>>>
            // 手数料、値引の設定
            switch (this._dicKindName.Count)
            {
                case 0:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind01_Title.Location;
                        this.FeePayment.Location = this.PaymentKind01.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind01.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind01.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind02_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind02.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind02.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind02.Location;

                        break;
                    }
                case 1:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind02_Title.Location;
                        this.FeePayment.Location = this.PaymentKind02.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind02.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind02.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind03_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind03.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind03.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind03.Location;

                        break;
                    }
                case 2:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind03_Title.Location;
                        this.FeePayment.Location = this.PaymentKind03.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind03.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind03.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind04_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind04.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind04.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind04.Location;

                        break;
                    }
                case 3:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind04_Title.Location;
                        this.FeePayment.Location = this.PaymentKind04.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind04.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind04.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind05_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind05.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind05.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind05.Location;

                        break;
                    }
                case 4:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind05_Title.Location;
                        this.FeePayment.Location = this.PaymentKind05.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind05.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind05.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind06_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind06.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind06.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind06.Location;

                        break;
                    }
                case 5:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind06_Title.Location;
                        this.FeePayment.Location = this.PaymentKind06.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind06.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind06.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind07_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind07.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind07.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind07.Location;

                        break;
                    }
                case 6:
                    {
                        this.FeePayment_Title.Location = this.PaymentKind07_Title.Location;
                        this.FeePayment.Location = this.PaymentKind07.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind07.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind07.Location;

                        this.DiscountPayment_Title.Location = this.PaymentKind08_Title.Location;
                        this.DiscountPayment.Location = this.PaymentKind08.Location;
                        this.Section_DiscountPayment.Location = this.Section_PaymentKind08.Location;
                        this.Total_DiscountPayment.Location = this.Total_PaymentKind08.Location;

                        break;
                    }
                case 7:
                    {
                        // 手数料の場所を使用するので、先に値引を設定
                        this.DiscountPayment_Title.Location = this.FeePayment_Title.Location;
                        this.DiscountPayment.Location = this.FeePayment.Location;
                        this.Section_DiscountPayment.Location = this.Section_FeePayment.Location;
                        this.Total_DiscountPayment.Location = this.Total_FeePayment.Location;

                        this.FeePayment_Title.Location = this.PaymentKind08_Title.Location;
                        this.FeePayment.Location = this.PaymentKind08.Location;
                        this.Section_FeePayment.Location = this.Section_PaymentKind08.Location;
                        this.Total_FeePayment.Location = this.Total_PaymentKind08.Location;
                        
                        break;
                    }
                case 8:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            // --- ADD 2009/03/27 --------------------------------<<<<<
        }

		#region ■ Control Event
        #region ◆ DCKAK02523P_04A4C_ReportStart Event
        /// <summary>
        /// DCKAK02523P_04A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : レポートの設定をするイベントです。</br>
		/// <br>Programmer  : 20081 疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
		/// </remarks>
        private void DCKAK02523P_04A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // レポート要素出力設定
            SetOfReportMembersOutput();

            SettingKindName();
        }

        #endregion ◆ DCKAK02523P_04A4C_ReportStart Event

        #region ◆ PageHeader_Format Event
        /// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( PaymentMainCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
		}
		#endregion ◆ PageHeader_Format Event

		#region ◆ ExtraHeader_Format Event
		/// <summary>
		/// ExtraHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ExtraHeaderグループの初期化イベントです。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
		/// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 抽出条件設定
            // --- DEL 2009/03/27 -------------------------------->>>>>
            //// ヘッダ出力制御
            //if (this._extraCondHeadOutDiv == 0)
            //{
            //    // 毎ページ出力
            //    this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //} 
            //else 
            //{
            //    // 先頭ページのみ
            //    this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            //}
            // --- DEL 2009/03/27 -------------------------------->>>>>
			
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

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //// 拠点オプション有無判定
            //if (this._paymentMainCndtn.IsOptSection)
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "計上拠点：" + this.tb_AddUpSecCode.Text + " " + this.tb_AddUpSecName.Text;
            //}
            //else
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // --- DEL 2008/08/05 --------------------------------<<<<< 

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion ◆ ExtraHeader_Format Event

		#region ◆ Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date	   : 2007.09.10</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

		}
		#endregion ◆ Detail_BeforePrint Event

		#region ◆ Detail_AfterPrint Event
		/// <summary>
		/// Detail_AfterPrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 20081 疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
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
		#endregion ◆ Detail_AfterPrint Event

		#region ◆ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : PageFooter_Formatグループの初期化イベントです。</br>
		/// <br>Programmer  : 20081 疋田　勇人</br>
		/// <br>Date		: 2007.09.10</br>
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
		#endregion ◆ PageFooter_Format Event
		#endregion ■ Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_SortOrderName;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Label Label109;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// InitializeComponent
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKAK02523P_04A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PaymentKind02 = new DataDynamics.ActiveReports.TextBox();
            this.DiscountPayment = new DataDynamics.ActiveReports.TextBox();
            this.PaymentTotal = new DataDynamics.ActiveReports.TextBox();
            this.PayeeCode = new DataDynamics.ActiveReports.TextBox();
            this.PayeeSnm = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind01 = new DataDynamics.ActiveReports.TextBox();
            this.FeePayment = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind04 = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind03 = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind05 = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind06 = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind07 = new DataDynamics.ActiveReports.TextBox();
            this.PaymentKind08 = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.PaymentKind04_Title = new DataDynamics.ActiveReports.Label();
            this.FeePayment_Title = new DataDynamics.ActiveReports.Label();
            this.DiscountPayment_Title = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.PaymentKind07_Title = new DataDynamics.ActiveReports.Label();
            this.PaymentKind02_Title = new DataDynamics.ActiveReports.Label();
            this.PaymentKind03_Title = new DataDynamics.ActiveReports.Label();
            this.PaymentKind05_Title = new DataDynamics.ActiveReports.Label();
            this.PaymentKind06_Title = new DataDynamics.ActiveReports.Label();
            this.PaymentKind01_Title = new DataDynamics.ActiveReports.Label();
            this.PaymentKind08_Title = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Total_PaymentKind05 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DiscountPayment = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentTotal = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind03 = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind02 = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind04 = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind06 = new DataDynamics.ActiveReports.TextBox();
            this.Total_FeePayment = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Total_PaymentKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.tb_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.TitleHeader_Line2 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.Section_PaymentKind02 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DiscountPayment = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentTotal = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind03 = new DataDynamics.ActiveReports.TextBox();
            this.Section_FeePayment = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind04 = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind06 = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind05 = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind04_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeePayment_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountPayment_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind07_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind02_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind03_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind05_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind06_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind01_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind08_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DiscountPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_FeePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DiscountPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_FeePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PaymentKind02,
            this.DiscountPayment,
            this.PaymentTotal,
            this.PayeeCode,
            this.PayeeSnm,
            this.PaymentKind01,
            this.FeePayment,
            this.PaymentKind04,
            this.PaymentKind03,
            this.PaymentKind05,
            this.PaymentKind06,
            this.PaymentKind07,
            this.PaymentKind08,
            this.line2});
            this.Detail.Height = 0.4166667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // PaymentKind02
            // 
            this.PaymentKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02.DataField = "PaymentKind_No2";
            this.PaymentKind02.Height = 0.125F;
            this.PaymentKind02.Left = 4.335F;
            this.PaymentKind02.MultiLine = false;
            this.PaymentKind02.Name = "PaymentKind02";
            this.PaymentKind02.OutputFormat = resources.GetString("PaymentKind02.OutputFormat");
            this.PaymentKind02.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind02.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind02.Top = 0.1875F;
            this.PaymentKind02.Width = 0.71F;
            // 
            // DiscountPayment
            // 
            this.DiscountPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.DiscountPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.DiscountPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment.Border.RightColor = System.Drawing.Color.Black;
            this.DiscountPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment.Border.TopColor = System.Drawing.Color.Black;
            this.DiscountPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment.DataField = "DiscountPayment";
            this.DiscountPayment.Height = 0.125F;
            this.DiscountPayment.Left = 10.015F;
            this.DiscountPayment.MultiLine = false;
            this.DiscountPayment.Name = "DiscountPayment";
            this.DiscountPayment.OutputFormat = resources.GetString("DiscountPayment.OutputFormat");
            this.DiscountPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DiscountPayment.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.DiscountPayment.Top = 0.1875F;
            this.DiscountPayment.Width = 0.71F;
            // 
            // PaymentTotal
            // 
            this.PaymentTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentTotal.DataField = "PaymentTotal";
            this.PaymentTotal.Height = 0.125F;
            this.PaymentTotal.Left = 3.625F;
            this.PaymentTotal.MultiLine = false;
            this.PaymentTotal.Name = "PaymentTotal";
            this.PaymentTotal.OutputFormat = resources.GetString("PaymentTotal.OutputFormat");
            this.PaymentTotal.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentTotal.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentTotal.Top = 0.0625F;
            this.PaymentTotal.Width = 0.71F;
            // 
            // PayeeCode
            // 
            this.PayeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.DataField = "PayeeCode";
            this.PayeeCode.Height = 0.125F;
            this.PayeeCode.Left = 0F;
            this.PayeeCode.MultiLine = false;
            this.PayeeCode.Name = "PayeeCode";
            this.PayeeCode.OutputFormat = resources.GetString("PayeeCode.OutputFormat");
            this.PayeeCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.PayeeCode.Text = "123456";
            this.PayeeCode.Top = 0.0625F;
            this.PayeeCode.Width = 0.4F;
            // 
            // PayeeSnm
            // 
            this.PayeeSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.DataField = "PayeeSnm";
            this.PayeeSnm.Height = 0.125F;
            this.PayeeSnm.Left = 0.375F;
            this.PayeeSnm.MultiLine = false;
            this.PayeeSnm.Name = "PayeeSnm";
            this.PayeeSnm.OutputFormat = resources.GetString("PayeeSnm.OutputFormat");
            this.PayeeSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.PayeeSnm.Text = "あいうえおかきくけこさしすせそ";
            this.PayeeSnm.Top = 0.0625F;
            this.PayeeSnm.Width = 1.75F;
            // 
            // PaymentKind01
            // 
            this.PaymentKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01.DataField = "PaymentKind_No1";
            this.PaymentKind01.Height = 0.125F;
            this.PaymentKind01.Left = 3.625F;
            this.PaymentKind01.MultiLine = false;
            this.PaymentKind01.Name = "PaymentKind01";
            this.PaymentKind01.OutputFormat = resources.GetString("PaymentKind01.OutputFormat");
            this.PaymentKind01.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind01.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind01.Top = 0.1875F;
            this.PaymentKind01.Width = 0.71F;
            // 
            // FeePayment
            // 
            this.FeePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.FeePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.FeePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment.Border.RightColor = System.Drawing.Color.Black;
            this.FeePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment.Border.TopColor = System.Drawing.Color.Black;
            this.FeePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment.DataField = "FeePayment";
            this.FeePayment.Height = 0.125F;
            this.FeePayment.Left = 9.305F;
            this.FeePayment.MultiLine = false;
            this.FeePayment.Name = "FeePayment";
            this.FeePayment.OutputFormat = resources.GetString("FeePayment.OutputFormat");
            this.FeePayment.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.FeePayment.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.FeePayment.Top = 0.1875F;
            this.FeePayment.Width = 0.71F;
            // 
            // PaymentKind04
            // 
            this.PaymentKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04.DataField = "PaymentKind_No4";
            this.PaymentKind04.Height = 0.125F;
            this.PaymentKind04.Left = 5.755F;
            this.PaymentKind04.MultiLine = false;
            this.PaymentKind04.Name = "PaymentKind04";
            this.PaymentKind04.OutputFormat = resources.GetString("PaymentKind04.OutputFormat");
            this.PaymentKind04.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind04.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind04.Top = 0.1875F;
            this.PaymentKind04.Width = 0.71F;
            // 
            // PaymentKind03
            // 
            this.PaymentKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03.DataField = "PaymentKind_No3";
            this.PaymentKind03.Height = 0.125F;
            this.PaymentKind03.Left = 5.045F;
            this.PaymentKind03.MultiLine = false;
            this.PaymentKind03.Name = "PaymentKind03";
            this.PaymentKind03.OutputFormat = resources.GetString("PaymentKind03.OutputFormat");
            this.PaymentKind03.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind03.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind03.Top = 0.1875F;
            this.PaymentKind03.Width = 0.71F;
            // 
            // PaymentKind05
            // 
            this.PaymentKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05.DataField = "PaymentKind_No5";
            this.PaymentKind05.Height = 0.125F;
            this.PaymentKind05.Left = 6.465F;
            this.PaymentKind05.MultiLine = false;
            this.PaymentKind05.Name = "PaymentKind05";
            this.PaymentKind05.OutputFormat = resources.GetString("PaymentKind05.OutputFormat");
            this.PaymentKind05.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind05.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind05.Top = 0.1875F;
            this.PaymentKind05.Width = 0.71F;
            // 
            // PaymentKind06
            // 
            this.PaymentKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06.DataField = "PaymentKind_No6";
            this.PaymentKind06.Height = 0.125F;
            this.PaymentKind06.Left = 7.175F;
            this.PaymentKind06.MultiLine = false;
            this.PaymentKind06.Name = "PaymentKind06";
            this.PaymentKind06.OutputFormat = resources.GetString("PaymentKind06.OutputFormat");
            this.PaymentKind06.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind06.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind06.Top = 0.1875F;
            this.PaymentKind06.Width = 0.71F;
            // 
            // PaymentKind07
            // 
            this.PaymentKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07.DataField = "PaymentKind_No7";
            this.PaymentKind07.Height = 0.125F;
            this.PaymentKind07.Left = 7.885F;
            this.PaymentKind07.MultiLine = false;
            this.PaymentKind07.Name = "PaymentKind07";
            this.PaymentKind07.OutputFormat = resources.GetString("PaymentKind07.OutputFormat");
            this.PaymentKind07.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind07.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind07.Top = 0.1875F;
            this.PaymentKind07.Width = 0.71F;
            // 
            // PaymentKind08
            // 
            this.PaymentKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08.DataField = "PaymentKind_No8";
            this.PaymentKind08.Height = 0.125F;
            this.PaymentKind08.Left = 8.595F;
            this.PaymentKind08.MultiLine = false;
            this.PaymentKind08.Name = "PaymentKind08";
            this.PaymentKind08.OutputFormat = resources.GetString("PaymentKind08.OutputFormat");
            this.PaymentKind08.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PaymentKind08.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.PaymentKind08.Top = 0.1875F;
            this.PaymentKind08.Width = 0.71F;
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
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.tb_SortOrderName,
            this.Label1,
            this.tb_PrintDate,
            this.Label4,
            this.tb_PrintPage,
            this.tb_PrintTime});
            this.PageHeader.Height = 0.6354167F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.tb_ReportTitle.Text = "支払確認表(集計表)";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.tb_SortOrderName.Left = 3.063F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.063F;
            this.tb_SortOrderName.Width = 2.1875F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.15625F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 7.9375F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label1.Text = "作成日付：";
            this.Label1.Top = 0.0625F;
            this.Label1.Width = 0.625F;
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
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.15625F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 9.9375F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label4.Text = "ページ：";
            this.Label4.Top = 0.0625F;
            this.Label4.Width = 0.5F;
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
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
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
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PaymentKind04_Title,
            this.FeePayment_Title,
            this.DiscountPayment_Title,
            this.Label108,
            this.PaymentKind07_Title,
            this.PaymentKind02_Title,
            this.PaymentKind03_Title,
            this.PaymentKind05_Title,
            this.PaymentKind06_Title,
            this.PaymentKind01_Title,
            this.PaymentKind08_Title,
            this.Label104,
            this.line3,
            this.line4});
            this.TitleHeader.Height = 0.5729167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // PaymentKind04_Title
            // 
            this.PaymentKind04_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind04_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind04_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind04_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind04_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind04_Title.Height = 0.125F;
            this.PaymentKind04_Title.HyperLink = "";
            this.PaymentKind04_Title.Left = 5.755F;
            this.PaymentKind04_Title.MultiLine = false;
            this.PaymentKind04_Title.Name = "PaymentKind04_Title";
            this.PaymentKind04_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind04_Title.Text = "相殺";
            this.PaymentKind04_Title.Top = 0.1875F;
            this.PaymentKind04_Title.Width = 0.71F;
            // 
            // FeePayment_Title
            // 
            this.FeePayment_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.FeePayment_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.FeePayment_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment_Title.Border.RightColor = System.Drawing.Color.Black;
            this.FeePayment_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment_Title.Border.TopColor = System.Drawing.Color.Black;
            this.FeePayment_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeePayment_Title.Height = 0.125F;
            this.FeePayment_Title.HyperLink = "";
            this.FeePayment_Title.Left = 9.305F;
            this.FeePayment_Title.MultiLine = false;
            this.FeePayment_Title.Name = "FeePayment_Title";
            this.FeePayment_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.FeePayment_Title.Text = "手数料";
            this.FeePayment_Title.Top = 0.1875F;
            this.FeePayment_Title.Width = 0.71F;
            // 
            // DiscountPayment_Title
            // 
            this.DiscountPayment_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DiscountPayment_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DiscountPayment_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DiscountPayment_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DiscountPayment_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountPayment_Title.Height = 0.125F;
            this.DiscountPayment_Title.HyperLink = "";
            this.DiscountPayment_Title.Left = 10.015F;
            this.DiscountPayment_Title.MultiLine = false;
            this.DiscountPayment_Title.Name = "DiscountPayment_Title";
            this.DiscountPayment_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DiscountPayment_Title.Text = "値引";
            this.DiscountPayment_Title.Top = 0.1875F;
            this.DiscountPayment_Title.Width = 0.71F;
            // 
            // Label108
            // 
            this.Label108.Border.BottomColor = System.Drawing.Color.Black;
            this.Label108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.LeftColor = System.Drawing.Color.Black;
            this.Label108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.RightColor = System.Drawing.Color.Black;
            this.Label108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.TopColor = System.Drawing.Color.Black;
            this.Label108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Height = 0.125F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 3.625F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label108.Text = "合計金額";
            this.Label108.Top = 0.0625F;
            this.Label108.Width = 0.71F;
            // 
            // PaymentKind07_Title
            // 
            this.PaymentKind07_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind07_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind07_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind07_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind07_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind07_Title.Height = 0.125F;
            this.PaymentKind07_Title.HyperLink = "";
            this.PaymentKind07_Title.Left = 7.885F;
            this.PaymentKind07_Title.MultiLine = false;
            this.PaymentKind07_Title.Name = "PaymentKind07_Title";
            this.PaymentKind07_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind07_Title.Text = "口座振替";
            this.PaymentKind07_Title.Top = 0.1875F;
            this.PaymentKind07_Title.Width = 0.71F;
            // 
            // PaymentKind02_Title
            // 
            this.PaymentKind02_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind02_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind02_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind02_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind02_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind02_Title.Height = 0.125F;
            this.PaymentKind02_Title.HyperLink = "";
            this.PaymentKind02_Title.Left = 4.335F;
            this.PaymentKind02_Title.MultiLine = false;
            this.PaymentKind02_Title.Name = "PaymentKind02_Title";
            this.PaymentKind02_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind02_Title.Text = "振込";
            this.PaymentKind02_Title.Top = 0.1875F;
            this.PaymentKind02_Title.Width = 0.71F;
            // 
            // PaymentKind03_Title
            // 
            this.PaymentKind03_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind03_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind03_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind03_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind03_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind03_Title.Height = 0.125F;
            this.PaymentKind03_Title.HyperLink = "";
            this.PaymentKind03_Title.Left = 5.045F;
            this.PaymentKind03_Title.MultiLine = false;
            this.PaymentKind03_Title.Name = "PaymentKind03_Title";
            this.PaymentKind03_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind03_Title.Text = "手形";
            this.PaymentKind03_Title.Top = 0.1875F;
            this.PaymentKind03_Title.Width = 0.71F;
            // 
            // PaymentKind05_Title
            // 
            this.PaymentKind05_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind05_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind05_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind05_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind05_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind05_Title.Height = 0.125F;
            this.PaymentKind05_Title.HyperLink = "";
            this.PaymentKind05_Title.Left = 6.465F;
            this.PaymentKind05_Title.MultiLine = false;
            this.PaymentKind05_Title.Name = "PaymentKind05_Title";
            this.PaymentKind05_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind05_Title.Text = "小切手";
            this.PaymentKind05_Title.Top = 0.1875F;
            this.PaymentKind05_Title.Width = 0.71F;
            // 
            // PaymentKind06_Title
            // 
            this.PaymentKind06_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind06_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind06_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind06_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind06_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind06_Title.Height = 0.125F;
            this.PaymentKind06_Title.HyperLink = "";
            this.PaymentKind06_Title.Left = 7.175F;
            this.PaymentKind06_Title.MultiLine = false;
            this.PaymentKind06_Title.Name = "PaymentKind06_Title";
            this.PaymentKind06_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind06_Title.Text = "その他";
            this.PaymentKind06_Title.Top = 0.1875F;
            this.PaymentKind06_Title.Width = 0.71F;
            // 
            // PaymentKind01_Title
            // 
            this.PaymentKind01_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind01_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind01_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind01_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind01_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind01_Title.Height = 0.125F;
            this.PaymentKind01_Title.HyperLink = "";
            this.PaymentKind01_Title.Left = 3.625F;
            this.PaymentKind01_Title.MultiLine = false;
            this.PaymentKind01_Title.Name = "PaymentKind01_Title";
            this.PaymentKind01_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind01_Title.Text = "現金";
            this.PaymentKind01_Title.Top = 0.1875F;
            this.PaymentKind01_Title.Width = 0.71F;
            // 
            // PaymentKind08_Title
            // 
            this.PaymentKind08_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentKind08_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentKind08_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentKind08_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentKind08_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentKind08_Title.Height = 0.125F;
            this.PaymentKind08_Title.HyperLink = "";
            this.PaymentKind08_Title.Left = 8.595F;
            this.PaymentKind08_Title.MultiLine = false;
            this.PaymentKind08_Title.Name = "PaymentKind08_Title";
            this.PaymentKind08_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.PaymentKind08_Title.Text = "金種コード８";
            this.PaymentKind08_Title.Top = 0.1875F;
            this.PaymentKind08_Title.Width = 0.71F;
            // 
            // Label104
            // 
            this.Label104.Border.BottomColor = System.Drawing.Color.Black;
            this.Label104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.LeftColor = System.Drawing.Color.Black;
            this.Label104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.RightColor = System.Drawing.Color.Black;
            this.Label104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.TopColor = System.Drawing.Color.Black;
            this.Label104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Height = 0.125F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Label104.Text = "仕入先";
            this.Label104.Top = 0.0625F;
            this.Label104.Width = 0.5625F;
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
            this.line4.Top = 0.3125F;
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0.3125F;
            this.line4.Y2 = 0.3125F;
            // 
            // TitleFooter
            // 
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
            this.Label109,
            this.Total_PaymentKind05,
            this.Total_DiscountPayment,
            this.Total_PaymentTotal,
            this.Total_PaymentKind03,
            this.Total_PaymentKind02,
            this.Total_PaymentKind04,
            this.Total_PaymentKind06,
            this.Total_FeePayment,
            this.Total_PaymentKind01,
            this.Total_PaymentKind07,
            this.Total_PaymentKind08,
            this.Line43});
            this.GrandTotalFooter.Height = 0.3958333F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // Label109
            // 
            this.Label109.Border.BottomColor = System.Drawing.Color.Black;
            this.Label109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.LeftColor = System.Drawing.Color.Black;
            this.Label109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.RightColor = System.Drawing.Color.Black;
            this.Label109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.TopColor = System.Drawing.Color.Black;
            this.Label109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Height = 0.1875F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 3F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label109.Text = "総合計";
            this.Label109.Top = 0.0625F;
            this.Label109.Width = 0.5625F;
            // 
            // Total_PaymentKind05
            // 
            this.Total_PaymentKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind05.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind05.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind05.DataField = "PaymentKind_No5";
            this.Total_PaymentKind05.Height = 0.125F;
            this.Total_PaymentKind05.Left = 6.465F;
            this.Total_PaymentKind05.MultiLine = false;
            this.Total_PaymentKind05.Name = "Total_PaymentKind05";
            this.Total_PaymentKind05.OutputFormat = resources.GetString("Total_PaymentKind05.OutputFormat");
            this.Total_PaymentKind05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind05.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind05.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind05.Top = 0.1875F;
            this.Total_PaymentKind05.Width = 0.71F;
            // 
            // Total_DiscountPayment
            // 
            this.Total_DiscountPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DiscountPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DiscountPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DiscountPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DiscountPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DiscountPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DiscountPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DiscountPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DiscountPayment.DataField = "DiscountPayment";
            this.Total_DiscountPayment.Height = 0.125F;
            this.Total_DiscountPayment.Left = 10.015F;
            this.Total_DiscountPayment.MultiLine = false;
            this.Total_DiscountPayment.Name = "Total_DiscountPayment";
            this.Total_DiscountPayment.OutputFormat = resources.GetString("Total_DiscountPayment.OutputFormat");
            this.Total_DiscountPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_DiscountPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_DiscountPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_DiscountPayment.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_DiscountPayment.Top = 0.1875F;
            this.Total_DiscountPayment.Width = 0.71F;
            // 
            // Total_PaymentTotal
            // 
            this.Total_PaymentTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentTotal.DataField = "PaymentTotal";
            this.Total_PaymentTotal.Height = 0.125F;
            this.Total_PaymentTotal.Left = 3.625F;
            this.Total_PaymentTotal.MultiLine = false;
            this.Total_PaymentTotal.Name = "Total_PaymentTotal";
            this.Total_PaymentTotal.OutputFormat = resources.GetString("Total_PaymentTotal.OutputFormat");
            this.Total_PaymentTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_PaymentTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_PaymentTotal.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentTotal.Top = 0.0625F;
            this.Total_PaymentTotal.Width = 0.71F;
            // 
            // Total_PaymentKind03
            // 
            this.Total_PaymentKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind03.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind03.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind03.DataField = "PaymentKind_No3";
            this.Total_PaymentKind03.Height = 0.125F;
            this.Total_PaymentKind03.Left = 5.045F;
            this.Total_PaymentKind03.MultiLine = false;
            this.Total_PaymentKind03.Name = "Total_PaymentKind03";
            this.Total_PaymentKind03.OutputFormat = resources.GetString("Total_PaymentKind03.OutputFormat");
            this.Total_PaymentKind03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind03.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind03.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind03.Top = 0.1875F;
            this.Total_PaymentKind03.Width = 0.71F;
            // 
            // Total_PaymentKind02
            // 
            this.Total_PaymentKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind02.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind02.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind02.DataField = "PaymentKind_No2";
            this.Total_PaymentKind02.Height = 0.125F;
            this.Total_PaymentKind02.Left = 4.335F;
            this.Total_PaymentKind02.MultiLine = false;
            this.Total_PaymentKind02.Name = "Total_PaymentKind02";
            this.Total_PaymentKind02.OutputFormat = resources.GetString("Total_PaymentKind02.OutputFormat");
            this.Total_PaymentKind02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind02.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind02.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind02.Top = 0.1875F;
            this.Total_PaymentKind02.Width = 0.71F;
            // 
            // Total_PaymentKind04
            // 
            this.Total_PaymentKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind04.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind04.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind04.DataField = "PaymentKind_No4";
            this.Total_PaymentKind04.Height = 0.125F;
            this.Total_PaymentKind04.Left = 5.755F;
            this.Total_PaymentKind04.MultiLine = false;
            this.Total_PaymentKind04.Name = "Total_PaymentKind04";
            this.Total_PaymentKind04.OutputFormat = resources.GetString("Total_PaymentKind04.OutputFormat");
            this.Total_PaymentKind04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind04.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind04.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind04.Top = 0.1875F;
            this.Total_PaymentKind04.Width = 0.71F;
            // 
            // Total_PaymentKind06
            // 
            this.Total_PaymentKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind06.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind06.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind06.DataField = "PaymentKind_No6";
            this.Total_PaymentKind06.Height = 0.125F;
            this.Total_PaymentKind06.Left = 7.175F;
            this.Total_PaymentKind06.MultiLine = false;
            this.Total_PaymentKind06.Name = "Total_PaymentKind06";
            this.Total_PaymentKind06.OutputFormat = resources.GetString("Total_PaymentKind06.OutputFormat");
            this.Total_PaymentKind06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind06.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind06.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind06.Top = 0.1875F;
            this.Total_PaymentKind06.Width = 0.71F;
            // 
            // Total_FeePayment
            // 
            this.Total_FeePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_FeePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_FeePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_FeePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_FeePayment.Border.RightColor = System.Drawing.Color.Black;
            this.Total_FeePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_FeePayment.Border.TopColor = System.Drawing.Color.Black;
            this.Total_FeePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_FeePayment.DataField = "FeePayment";
            this.Total_FeePayment.Height = 0.125F;
            this.Total_FeePayment.Left = 9.305F;
            this.Total_FeePayment.MultiLine = false;
            this.Total_FeePayment.Name = "Total_FeePayment";
            this.Total_FeePayment.OutputFormat = resources.GetString("Total_FeePayment.OutputFormat");
            this.Total_FeePayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_FeePayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_FeePayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_FeePayment.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_FeePayment.Top = 0.1875F;
            this.Total_FeePayment.Width = 0.71F;
            // 
            // Total_PaymentKind01
            // 
            this.Total_PaymentKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind01.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind01.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind01.DataField = "PaymentKind_No1";
            this.Total_PaymentKind01.Height = 0.125F;
            this.Total_PaymentKind01.Left = 3.625F;
            this.Total_PaymentKind01.MultiLine = false;
            this.Total_PaymentKind01.Name = "Total_PaymentKind01";
            this.Total_PaymentKind01.OutputFormat = resources.GetString("Total_PaymentKind01.OutputFormat");
            this.Total_PaymentKind01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind01.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind01.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind01.Top = 0.1875F;
            this.Total_PaymentKind01.Width = 0.71F;
            // 
            // Total_PaymentKind07
            // 
            this.Total_PaymentKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind07.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind07.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind07.DataField = "PaymentKind_No7";
            this.Total_PaymentKind07.Height = 0.125F;
            this.Total_PaymentKind07.Left = 7.885F;
            this.Total_PaymentKind07.MultiLine = false;
            this.Total_PaymentKind07.Name = "Total_PaymentKind07";
            this.Total_PaymentKind07.OutputFormat = resources.GetString("Total_PaymentKind07.OutputFormat");
            this.Total_PaymentKind07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind07.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind07.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind07.Top = 0.1875F;
            this.Total_PaymentKind07.Width = 0.71F;
            // 
            // Total_PaymentKind08
            // 
            this.Total_PaymentKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind08.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind08.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentKind08.DataField = "PaymentKind_No8";
            this.Total_PaymentKind08.Height = 0.125F;
            this.Total_PaymentKind08.Left = 8.595F;
            this.Total_PaymentKind08.MultiLine = false;
            this.Total_PaymentKind08.Name = "Total_PaymentKind08";
            this.Total_PaymentKind08.OutputFormat = resources.GetString("Total_PaymentKind08.OutputFormat");
            this.Total_PaymentKind08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentKind08.SummaryGroup = "GrandTotalHeader";
            this.Total_PaymentKind08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_PaymentKind08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_PaymentKind08.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Total_PaymentKind08.Top = 0.1875F;
            this.Total_PaymentKind08.Width = 0.71F;
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
            this.Line43.Width = 10.8125F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.8125F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_AddUpSecName,
            this.tb_AddUpSecCode,
            this.label15,
            this.TitleHeader_Line2});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.2708333F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // tb_AddUpSecName
            // 
            this.tb_AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.CanShrink = true;
            this.tb_AddUpSecName.DataField = "AddUpSecName";
            this.tb_AddUpSecName.Height = 0.125F;
            this.tb_AddUpSecName.Left = 0.5005F;
            this.tb_AddUpSecName.MultiLine = false;
            this.tb_AddUpSecName.Name = "tb_AddUpSecName";
            this.tb_AddUpSecName.Style = "ddo-char-set: 128; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_AddUpSecName.Text = "あいうえおかきくけこ";
            this.tb_AddUpSecName.Top = 0.0625F;
            this.tb_AddUpSecName.Width = 1.4375F;
            // 
            // tb_AddUpSecCode
            // 
            this.tb_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.DataField = "AddUpSecCode";
            this.tb_AddUpSecCode.Height = 0.125F;
            this.tb_AddUpSecCode.Left = 0.3125F;
            this.tb_AddUpSecCode.MultiLine = false;
            this.tb_AddUpSecCode.Name = "tb_AddUpSecCode";
            this.tb_AddUpSecCode.OutputFormat = resources.GetString("tb_AddUpSecCode.OutputFormat");
            this.tb_AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.tb_AddUpSecCode.Text = "12";
            this.tb_AddUpSecCode.Top = 0.0625F;
            this.tb_AddUpSecCode.Width = 0.188F;
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
            this.label15.Left = 0F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label15.Text = "拠点";
            this.label15.Top = 0.0625F;
            this.label15.Width = 0.3125F;
            // 
            // TitleHeader_Line2
            // 
            this.TitleHeader_Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Border.RightColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Border.TopColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Height = 0F;
            this.TitleHeader_Line2.Left = 0F;
            this.TitleHeader_Line2.LineWeight = 2F;
            this.TitleHeader_Line2.Name = "TitleHeader_Line2";
            this.TitleHeader_Line2.Top = 0F;
            this.TitleHeader_Line2.Width = 10.8125F;
            this.TitleHeader_Line2.X1 = 0F;
            this.TitleHeader_Line2.X2 = 10.8125F;
            this.TitleHeader_Line2.Y1 = 0F;
            this.TitleHeader_Line2.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label10,
            this.Section_PaymentKind02,
            this.Section_DiscountPayment,
            this.Section_PaymentTotal,
            this.Section_PaymentKind03,
            this.Section_FeePayment,
            this.Section_PaymentKind04,
            this.Section_PaymentKind06,
            this.Section_PaymentKind05,
            this.Section_PaymentKind01,
            this.Section_PaymentKind07,
            this.Section_PaymentKind08,
            this.Line45});
            this.SectionFooter.Height = 0.375F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
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
            this.label10.Left = 3F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "拠点計";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.5625F;
            // 
            // Section_PaymentKind02
            // 
            this.Section_PaymentKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind02.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind02.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind02.DataField = "PaymentKind_No2";
            this.Section_PaymentKind02.Height = 0.125F;
            this.Section_PaymentKind02.Left = 4.335F;
            this.Section_PaymentKind02.MultiLine = false;
            this.Section_PaymentKind02.Name = "Section_PaymentKind02";
            this.Section_PaymentKind02.OutputFormat = resources.GetString("Section_PaymentKind02.OutputFormat");
            this.Section_PaymentKind02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind02.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind02.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind02.Top = 0.1875F;
            this.Section_PaymentKind02.Width = 0.71F;
            // 
            // Section_DiscountPayment
            // 
            this.Section_DiscountPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DiscountPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DiscountPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DiscountPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DiscountPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DiscountPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DiscountPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DiscountPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DiscountPayment.DataField = "DiscountPayment";
            this.Section_DiscountPayment.Height = 0.125F;
            this.Section_DiscountPayment.Left = 10.015F;
            this.Section_DiscountPayment.MultiLine = false;
            this.Section_DiscountPayment.Name = "Section_DiscountPayment";
            this.Section_DiscountPayment.OutputFormat = resources.GetString("Section_DiscountPayment.OutputFormat");
            this.Section_DiscountPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_DiscountPayment.SummaryGroup = "SectionHeader";
            this.Section_DiscountPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DiscountPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DiscountPayment.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_DiscountPayment.Top = 0.1875F;
            this.Section_DiscountPayment.Width = 0.71F;
            // 
            // Section_PaymentTotal
            // 
            this.Section_PaymentTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentTotal.DataField = "PaymentTotal";
            this.Section_PaymentTotal.Height = 0.125F;
            this.Section_PaymentTotal.Left = 3.625F;
            this.Section_PaymentTotal.MultiLine = false;
            this.Section_PaymentTotal.Name = "Section_PaymentTotal";
            this.Section_PaymentTotal.OutputFormat = resources.GetString("Section_PaymentTotal.OutputFormat");
            this.Section_PaymentTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentTotal.SummaryGroup = "SectionHeader";
            this.Section_PaymentTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentTotal.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentTotal.Top = 0.0625F;
            this.Section_PaymentTotal.Width = 0.71F;
            // 
            // Section_PaymentKind03
            // 
            this.Section_PaymentKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind03.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind03.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind03.DataField = "PaymentKind_No3";
            this.Section_PaymentKind03.Height = 0.125F;
            this.Section_PaymentKind03.Left = 5.045F;
            this.Section_PaymentKind03.MultiLine = false;
            this.Section_PaymentKind03.Name = "Section_PaymentKind03";
            this.Section_PaymentKind03.OutputFormat = resources.GetString("Section_PaymentKind03.OutputFormat");
            this.Section_PaymentKind03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind03.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind03.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind03.Top = 0.1875F;
            this.Section_PaymentKind03.Width = 0.71F;
            // 
            // Section_FeePayment
            // 
            this.Section_FeePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_FeePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_FeePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_FeePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_FeePayment.Border.RightColor = System.Drawing.Color.Black;
            this.Section_FeePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_FeePayment.Border.TopColor = System.Drawing.Color.Black;
            this.Section_FeePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_FeePayment.DataField = "FeePayment";
            this.Section_FeePayment.Height = 0.125F;
            this.Section_FeePayment.Left = 9.305F;
            this.Section_FeePayment.MultiLine = false;
            this.Section_FeePayment.Name = "Section_FeePayment";
            this.Section_FeePayment.OutputFormat = resources.GetString("Section_FeePayment.OutputFormat");
            this.Section_FeePayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_FeePayment.SummaryGroup = "SectionHeader";
            this.Section_FeePayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_FeePayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_FeePayment.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_FeePayment.Top = 0.1875F;
            this.Section_FeePayment.Width = 0.71F;
            // 
            // Section_PaymentKind04
            // 
            this.Section_PaymentKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind04.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind04.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind04.DataField = "PaymentKind_No4";
            this.Section_PaymentKind04.Height = 0.125F;
            this.Section_PaymentKind04.Left = 5.755F;
            this.Section_PaymentKind04.MultiLine = false;
            this.Section_PaymentKind04.Name = "Section_PaymentKind04";
            this.Section_PaymentKind04.OutputFormat = resources.GetString("Section_PaymentKind04.OutputFormat");
            this.Section_PaymentKind04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind04.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind04.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind04.Top = 0.1875F;
            this.Section_PaymentKind04.Width = 0.71F;
            // 
            // Section_PaymentKind06
            // 
            this.Section_PaymentKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind06.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind06.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind06.DataField = "PaymentKind_No6";
            this.Section_PaymentKind06.Height = 0.125F;
            this.Section_PaymentKind06.Left = 7.175F;
            this.Section_PaymentKind06.MultiLine = false;
            this.Section_PaymentKind06.Name = "Section_PaymentKind06";
            this.Section_PaymentKind06.OutputFormat = resources.GetString("Section_PaymentKind06.OutputFormat");
            this.Section_PaymentKind06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind06.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind06.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind06.Top = 0.1875F;
            this.Section_PaymentKind06.Width = 0.71F;
            // 
            // Section_PaymentKind05
            // 
            this.Section_PaymentKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind05.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind05.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind05.DataField = "PaymentKind_No5";
            this.Section_PaymentKind05.Height = 0.125F;
            this.Section_PaymentKind05.Left = 6.465F;
            this.Section_PaymentKind05.MultiLine = false;
            this.Section_PaymentKind05.Name = "Section_PaymentKind05";
            this.Section_PaymentKind05.OutputFormat = resources.GetString("Section_PaymentKind05.OutputFormat");
            this.Section_PaymentKind05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind05.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind05.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind05.Top = 0.1875F;
            this.Section_PaymentKind05.Width = 0.71F;
            // 
            // Section_PaymentKind01
            // 
            this.Section_PaymentKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind01.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind01.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind01.DataField = "PaymentKind_No1";
            this.Section_PaymentKind01.Height = 0.125F;
            this.Section_PaymentKind01.Left = 3.625F;
            this.Section_PaymentKind01.MultiLine = false;
            this.Section_PaymentKind01.Name = "Section_PaymentKind01";
            this.Section_PaymentKind01.OutputFormat = resources.GetString("Section_PaymentKind01.OutputFormat");
            this.Section_PaymentKind01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind01.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind01.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind01.Top = 0.1875F;
            this.Section_PaymentKind01.Width = 0.71F;
            // 
            // Section_PaymentKind07
            // 
            this.Section_PaymentKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind07.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind07.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind07.DataField = "PaymentKind_No7";
            this.Section_PaymentKind07.Height = 0.125F;
            this.Section_PaymentKind07.Left = 7.885F;
            this.Section_PaymentKind07.MultiLine = false;
            this.Section_PaymentKind07.Name = "Section_PaymentKind07";
            this.Section_PaymentKind07.OutputFormat = resources.GetString("Section_PaymentKind07.OutputFormat");
            this.Section_PaymentKind07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind07.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind07.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind07.Top = 0.1875F;
            this.Section_PaymentKind07.Width = 0.71F;
            // 
            // Section_PaymentKind08
            // 
            this.Section_PaymentKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind08.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind08.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentKind08.DataField = "PaymentKind_No8";
            this.Section_PaymentKind08.Height = 0.125F;
            this.Section_PaymentKind08.Left = 8.595F;
            this.Section_PaymentKind08.MultiLine = false;
            this.Section_PaymentKind08.Name = "Section_PaymentKind08";
            this.Section_PaymentKind08.OutputFormat = resources.GetString("Section_PaymentKind08.OutputFormat");
            this.Section_PaymentKind08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentKind08.SummaryGroup = "SectionHeader";
            this.Section_PaymentKind08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentKind08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentKind08.Text = "ZZZ,ZZZ,ZZZ,ZZ9";
            this.Section_PaymentKind08.Top = 0.1875F;
            this.Section_PaymentKind08.Width = 0.71F;
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
            // DCKAK02523P_04A4C
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
            this.Sections.Add(this.Detail);
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
            this.ReportStart += new System.EventHandler(this.DCKAK02523P_04A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind04_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeePayment_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountPayment_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind07_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind02_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind03_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind05_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind06_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind01_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentKind08_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DiscountPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_FeePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DiscountPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_FeePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
