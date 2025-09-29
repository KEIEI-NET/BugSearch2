//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入出荷一覧
// プログラム概要   : 在庫入出荷一覧の印刷フォーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木　正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田　貴志
// 修 正 日  2008/03/18  修正内容 : 不具合対応[12542]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田　貴志
// 修 正 日  2008/04/02  修正内容 : 不具合対応[12998]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/22  修正内容 : 不具合[12542]のフィードバック対応
//                                  ・改頁時、倉庫と仕入先を先頭行に印字
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田　貴志
// 修 正 日  2008/05/26  修正内容 : 不具合対応[13378]
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

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 在庫入出荷一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 在庫入出荷一覧表のフォームクラスです。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2007.09.19</br>
	/// <br></br>
	/// <br>UpdateNote   : 2009/03/18 照田 貴志　不具合対応[12542]</br>
    /// <br>             : 2009/04/02 照田 貴志　不具合対応[12998]</br>
    /// <br>             : 2009/04/22 照田 貴志　不具合[12542]のフィードバック対応</br>
    /// <br>             : 2009/05/26 照田 貴志　不具合対応[13378]</br>
    /// <br>             :</br>
	/// </remarks>
	public class DCZAI02123P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫入出荷一覧表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : 在庫入出荷一覧表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer   : 22018　鈴木　正臣</br>
		/// <br>Date         : 2007.09.19</br>
		/// </remarks>
		public DCZAI02123P_01A4C()
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

        private StockShipArrivalListCndtn _stockShipArrivalListCndtn;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;
        private GroupHeader LargeGoodsGanreHeader;
        private GroupFooter LargeGoodsGanreFooter;
        private TextBox textBox1;
        private TextBox Gl_ShipmentCnt1;
        private TextBox Gl_ShipmentCnt2;
        private TextBox Gl_ShipmentCnt3;
        private TextBox Gl_ShipmentCnt4;
        private TextBox Gl_ShipmentCnt5;
        private TextBox Gl_ShipmentCnt6;
        private TextBox Gl_ShipmentCnt7;
        private TextBox Gl_ShipmentCnt8;
        private TextBox Gl_ShipmentCnt9;
        private TextBox Gl_ShipmentCnt10;
        private TextBox Gl_ShipmentCnt11;
        private TextBox Gl_ShipmentCnt12;
        private TextBox Gl_Ave_ShipmentCnt;
        private TextBox Gl_Sum_ShipmentCnt;
        private TextBox Gl_ArrivalCnt1;
        private TextBox Gl_ArrivalCnt2;
        private TextBox Gl_ArrivalCnt3;
        private TextBox Gl_ArrivalCnt4;
        private TextBox Gl_ArrivalCnt5;
        private TextBox Gl_ArrivalCnt6;
        private TextBox Gl_ArrivalCnt7;
        private TextBox Gl_ArrivalCnt8;
        private TextBox Gl_ArrivalCnt9;
        private TextBox Gl_ArrivalCnt10;
        private TextBox Gl_ArrivalCnt11;
        private TextBox Gl_ArrivalCnt12;
        private TextBox Gl_Ave_ArrivalCnt;
        private TextBox Gl_Sum_ArrivalCnt;
        private GroupHeader MediumGoodsGanreHeader;
        private GroupFooter MediumGoodsGanreFooter;
        private TextBox textBox31;
        private TextBox Gm_ShipmentCnt1;
        private TextBox Gm_ShipmentCnt2;
        private TextBox Gm_ShipmentCnt3;
        private TextBox Gm_ShipmentCnt4;
        private TextBox Gm_ShipmentCnt5;
        private TextBox Gm_ShipmentCnt6;
        private TextBox Gm_ShipmentCnt7;
        private TextBox Gm_ShipmentCnt8;
        private TextBox Gm_ShipmentCnt9;
        private TextBox Gm_ShipmentCnt10;
        private TextBox Gm_ShipmentCnt11;
        private TextBox Gm_ShipmentCnt12;
        private TextBox Gm_Ave_ShipmentCnt;
        private TextBox Gm_Sum_ShipmentCnt;
        private TextBox Gm_ArrivalCnt1;
        private TextBox Gm_ArrivalCnt2;
        private TextBox Gm_ArrivalCnt3;
        private TextBox Gm_ArrivalCnt4;
        private TextBox Gm_ArrivalCnt5;
        private TextBox Gm_ArrivalCnt6;
        private TextBox Gm_ArrivalCnt7;
        private TextBox Gm_ArrivalCnt8;
        private TextBox Gm_ArrivalCnt9;
        private TextBox Gm_ArrivalCnt10;
        private TextBox Gm_ArrivalCnt11;
        private TextBox Gm_ArrivalCnt12;
        private TextBox Gm_Ave_ArrivalCnt;
        private TextBox Gm_Sum_ArrivalCnt;
        private GroupHeader DetailGoodsGanreHeader;
        private GroupFooter DetailGoodsGanreFooter;
        private TextBox textBox60;
        private TextBox Gd_ShipmentCnt1;
        private TextBox Gd_ShipmentCnt2;
        private TextBox Gd_ShipmentCnt3;
        private TextBox Gd_ShipmentCnt4;
        private TextBox Gd_ShipmentCnt5;
        private TextBox Gd_ShipmentCnt6;
        private TextBox Gd_ShipmentCnt7;
        private TextBox Gd_ShipmentCnt8;
        private TextBox Gd_ShipmentCnt9;
        private TextBox Gd_ShipmentCnt10;
        private TextBox Gd_ShipmentCnt11;
        private TextBox Gd_ShipmentCnt12;
        private TextBox Gd_Ave_ShipmentCnt;
        private TextBox Gd_ArrivalCnt1;
        private TextBox Gd_ArrivalCnt2;
        private TextBox Gd_ArrivalCnt3;
        private TextBox Gd_ArrivalCnt4;
        private TextBox Gd_ArrivalCnt5;
        private TextBox Gd_ArrivalCnt6;
        private TextBox Gd_ArrivalCnt7;
        private TextBox Gd_ArrivalCnt8;
        private TextBox Gd_ArrivalCnt9;
        private TextBox Gd_ArrivalCnt10;
        private TextBox Gd_ArrivalCnt11;
        private TextBox Gd_ArrivalCnt12;
        private TextBox Gd_Ave_ArrivalCnt;
        private TextBox Gd_Sum_ShipmentCnt;
        private TextBox Gd_Sum_ArrivalCnt;
        private Line line4;
        private Line line5;
        private Line line6;
        private Label Lb_Warehouse;
        private Label Lb_GoodsMaker;
        private Line line7;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox8;
        private TextBox textBox9;

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
				this._stockShipArrivalListCndtn	= (StockShipArrivalListCndtn)this._printInfo.jyoken;
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._stockShipArrivalListCndtn.IsOptSection ) {
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._stockShipArrivalListCndtn.SectionCodes.Length < 2 ) ||
            //        this._stockShipArrivalListCndtn.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCZAI02125EA.ct_Col_Sort_SectionCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else {
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}

            /* ---DEL 2009/04/02 不具合対応[12998] ------------------------------->>>>>
            SectionHeader.DataField = DCZAI02125EA.ct_Col_Sort_SectionCode;
            SectionHeader.Visible = true;
            SectionFooter.Visible = true;
               ---DEL 2009/04/02 不具合対応[12998] -------------------------------<<<<< */

            #region ＜＜　範囲指定月数で印字制御　＞＞
            // 指定した範囲内の月数を印字
            int month = this.GetMonthRange(this._stockShipArrivalListCndtn.St_AddUpYearMonth,this._stockShipArrivalListCndtn.Ed_AddUpYearMonth);

            List<ARControl[]> ctrlsList = new List<ARControl[]>();
            ARControl[] ctrls;
            /* ---DEL 2009/04/02 不具合対応[12998] --------------------------------------------------------------------------------->>>>>
            // １月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt1, 
            //                          ShipmentCnt1, ArrivalCnt1, Sum_ShipmentCnt1, Sum_ArrivalCnt1, 
            //                          Cus_ShipmentCnt1, Cus_ArrivalCnt1, Wh_ShipmentCnt1, Wh_ArrivalCnt1, 
            //                          Sec_ShipmentCnt1, Sec_ArrivalCnt1, Ttl_ShipmentCnt1, Ttl_ArrivalCnt1 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt1, 
                                      ShipmentCnt1, ArrivalCnt1, Sum_ShipmentCnt1, Sum_ArrivalCnt1, 
                                      Cus_ShipmentCnt1, Cus_ArrivalCnt1, Wh_ShipmentCnt1, Wh_ArrivalCnt1, 
                                      Gl_ShipmentCnt1, Gl_ArrivalCnt1, Gm_ShipmentCnt1, Gm_ArrivalCnt1 , Gd_ShipmentCnt1, Gd_ArrivalCnt1,
                                      Sec_ShipmentCnt1, Sec_ArrivalCnt1, Ttl_ShipmentCnt1, Ttl_ArrivalCnt1 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ２月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt2, 
            //                          ShipmentCnt2, ArrivalCnt2, Sum_ShipmentCnt2, Sum_ArrivalCnt2, 
            //                          Cus_ShipmentCnt2, Cus_ArrivalCnt2, Wh_ShipmentCnt2, Wh_ArrivalCnt2, 
            //                          Sec_ShipmentCnt2, Sec_ArrivalCnt2, Ttl_ShipmentCnt2, Ttl_ArrivalCnt2 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt2, 
                                      ShipmentCnt2, ArrivalCnt2, Sum_ShipmentCnt2, Sum_ArrivalCnt2, 
                                      Cus_ShipmentCnt2, Cus_ArrivalCnt2, Wh_ShipmentCnt2, Wh_ArrivalCnt2, 
                                      Gl_ShipmentCnt2, Gl_ArrivalCnt2, Gm_ShipmentCnt2, Gm_ArrivalCnt2 , Gd_ShipmentCnt2, Gd_ArrivalCnt2,
                                      Sec_ShipmentCnt2, Sec_ArrivalCnt2, Ttl_ShipmentCnt2, Ttl_ArrivalCnt2 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ３月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt3, 
            //                          ShipmentCnt3, ArrivalCnt3, Sum_ShipmentCnt3, Sum_ArrivalCnt3, 
            //                          Cus_ShipmentCnt3, Cus_ArrivalCnt3, Wh_ShipmentCnt3, Wh_ArrivalCnt3, 
            //                          Sec_ShipmentCnt3, Sec_ArrivalCnt3, Ttl_ShipmentCnt3, Ttl_ArrivalCnt3 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt3, 
                                      ShipmentCnt3, ArrivalCnt3, Sum_ShipmentCnt3, Sum_ArrivalCnt3, 
                                      Cus_ShipmentCnt3, Cus_ArrivalCnt3, Wh_ShipmentCnt3, Wh_ArrivalCnt3, 
                                      Gl_ShipmentCnt3, Gl_ArrivalCnt3, Gm_ShipmentCnt3, Gm_ArrivalCnt3 , Gd_ShipmentCnt3, Gd_ArrivalCnt3,
                                      Sec_ShipmentCnt3, Sec_ArrivalCnt3, Ttl_ShipmentCnt3, Ttl_ArrivalCnt3 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ４月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt4, 
            //                          ShipmentCnt4, ArrivalCnt4, Sum_ShipmentCnt4, Sum_ArrivalCnt4, 
            //                          Cus_ShipmentCnt4, Cus_ArrivalCnt4, Wh_ShipmentCnt4, Wh_ArrivalCnt4, 
            //                          Sec_ShipmentCnt4, Sec_ArrivalCnt4, Ttl_ShipmentCnt4, Ttl_ArrivalCnt4 };
            //--- DEL 2008/07/16 ----------<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt4, 
                                      ShipmentCnt4, ArrivalCnt4, Sum_ShipmentCnt4, Sum_ArrivalCnt4, 
                                      Cus_ShipmentCnt4, Cus_ArrivalCnt4, Wh_ShipmentCnt4, Wh_ArrivalCnt4, 
                                      Gl_ShipmentCnt4, Gl_ArrivalCnt4, Gm_ShipmentCnt4, Gm_ArrivalCnt4 , Gd_ShipmentCnt4, Gd_ArrivalCnt4,
                                      Sec_ShipmentCnt4, Sec_ArrivalCnt4, Ttl_ShipmentCnt4, Ttl_ArrivalCnt4 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ５月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt5, 
            //                          ShipmentCnt5, ArrivalCnt5, Sum_ShipmentCnt5, Sum_ArrivalCnt5, 
            //                          Cus_ShipmentCnt5, Cus_ArrivalCnt5, Wh_ShipmentCnt5, Wh_ArrivalCnt5, 
            //                          Sec_ShipmentCnt5, Sec_ArrivalCnt5, Ttl_ShipmentCnt5, Ttl_ArrivalCnt5 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt5, 
                                      ShipmentCnt5, ArrivalCnt5, Sum_ShipmentCnt5, Sum_ArrivalCnt5, 
                                      Cus_ShipmentCnt5, Cus_ArrivalCnt5, Wh_ShipmentCnt5, Wh_ArrivalCnt5, 
                                      Gl_ShipmentCnt5, Gl_ArrivalCnt5, Gm_ShipmentCnt5, Gm_ArrivalCnt5 , Gd_ShipmentCnt5, Gd_ArrivalCnt5,
                                      Sec_ShipmentCnt5, Sec_ArrivalCnt5, Ttl_ShipmentCnt5, Ttl_ArrivalCnt5 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ６月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt6, 
            //                          ShipmentCnt6, ArrivalCnt6, Sum_ShipmentCnt6, Sum_ArrivalCnt6, 
            //                          Cus_ShipmentCnt6, Cus_ArrivalCnt6, Wh_ShipmentCnt6, Wh_ArrivalCnt6, 
            //                          Sec_ShipmentCnt6, Sec_ArrivalCnt6, Ttl_ShipmentCnt6, Ttl_ArrivalCnt6 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt6, 
                                      ShipmentCnt6, ArrivalCnt6, Sum_ShipmentCnt6, Sum_ArrivalCnt6, 
                                      Cus_ShipmentCnt6, Cus_ArrivalCnt6, Wh_ShipmentCnt6, Wh_ArrivalCnt6, 
                                      Gl_ShipmentCnt6, Gl_ArrivalCnt6, Gm_ShipmentCnt6, Gm_ArrivalCnt6 , Gd_ShipmentCnt6, Gd_ArrivalCnt6,
                                      Sec_ShipmentCnt6, Sec_ArrivalCnt6, Ttl_ShipmentCnt6, Ttl_ArrivalCnt6 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ７月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt7, 
            //                          ShipmentCnt7, ArrivalCnt7, Sum_ShipmentCnt7, Sum_ArrivalCnt7, 
            //                          Cus_ShipmentCnt7, Cus_ArrivalCnt7, Wh_ShipmentCnt7, Wh_ArrivalCnt7, 
            //                          Sec_ShipmentCnt7, Sec_ArrivalCnt7, Ttl_ShipmentCnt7, Ttl_ArrivalCnt7 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt7, 
                                      ShipmentCnt7, ArrivalCnt7, Sum_ShipmentCnt7, Sum_ArrivalCnt7, 
                                      Cus_ShipmentCnt7, Cus_ArrivalCnt7, Wh_ShipmentCnt7, Wh_ArrivalCnt7, 
                                      Gl_ShipmentCnt7, Gl_ArrivalCnt7, Gm_ShipmentCnt7, Gm_ArrivalCnt7 , Gd_ShipmentCnt7, Gd_ArrivalCnt7,
                                      Sec_ShipmentCnt7, Sec_ArrivalCnt7, Ttl_ShipmentCnt7, Ttl_ArrivalCnt7 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ８月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt8, 
            //                          ShipmentCnt8, ArrivalCnt8, Sum_ShipmentCnt8, Sum_ArrivalCnt8, 
            //                          Cus_ShipmentCnt8, Cus_ArrivalCnt8, Wh_ShipmentCnt8, Wh_ArrivalCnt8, 
            //                          Sec_ShipmentCnt8, Sec_ArrivalCnt8, Ttl_ShipmentCnt8, Ttl_ArrivalCnt8 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt8, 
                                      ShipmentCnt8, ArrivalCnt8, Sum_ShipmentCnt8, Sum_ArrivalCnt8, 
                                      Cus_ShipmentCnt8, Cus_ArrivalCnt8, Wh_ShipmentCnt8, Wh_ArrivalCnt8, 
                                      Gl_ShipmentCnt8, Gl_ArrivalCnt8, Gm_ShipmentCnt8, Gm_ArrivalCnt8 , Gd_ShipmentCnt8, Gd_ArrivalCnt8,
                                      Sec_ShipmentCnt8, Sec_ArrivalCnt8, Ttl_ShipmentCnt8, Ttl_ArrivalCnt8 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // ９月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt9, 
            //                          ShipmentCnt9, ArrivalCnt9, Sum_ShipmentCnt9, Sum_ArrivalCnt9, 
            //                          Cus_ShipmentCnt9, Cus_ArrivalCnt9, Wh_ShipmentCnt9, Wh_ArrivalCnt9, 
            //                          Sec_ShipmentCnt9, Sec_ArrivalCnt9, Ttl_ShipmentCnt9, Ttl_ArrivalCnt9 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt9, 
                                      ShipmentCnt9, ArrivalCnt9, Sum_ShipmentCnt9, Sum_ArrivalCnt9, 
                                      Cus_ShipmentCnt9, Cus_ArrivalCnt9, Wh_ShipmentCnt9, Wh_ArrivalCnt9, 
                                      Gl_ShipmentCnt9, Gl_ArrivalCnt9, Gm_ShipmentCnt9, Gm_ArrivalCnt9 , Gd_ShipmentCnt9, Gd_ArrivalCnt9,
                                      Sec_ShipmentCnt9, Sec_ArrivalCnt9, Ttl_ShipmentCnt9, Ttl_ArrivalCnt9 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // １０月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt10, 
            //                          ShipmentCnt10, ArrivalCnt10, Sum_ShipmentCnt10, Sum_ArrivalCnt10, 
            //                          Cus_ShipmentCnt10, Cus_ArrivalCnt10, Wh_ShipmentCnt10, Wh_ArrivalCnt10, 
            //                          Sec_ShipmentCnt10, Sec_ArrivalCnt10, Ttl_ShipmentCnt10, Ttl_ArrivalCnt10 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt10, 
                                      ShipmentCnt10, ArrivalCnt10, Sum_ShipmentCnt10, Sum_ArrivalCnt10, 
                                      Cus_ShipmentCnt10, Cus_ArrivalCnt10, Wh_ShipmentCnt10, Wh_ArrivalCnt10, 
                                      Gl_ShipmentCnt10, Gl_ArrivalCnt10, Gm_ShipmentCnt10, Gm_ArrivalCnt10 , Gd_ShipmentCnt10, Gd_ArrivalCnt10,
                                      Sec_ShipmentCnt10, Sec_ArrivalCnt10, Ttl_ShipmentCnt10, Ttl_ArrivalCnt10 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // １１月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt11, 
            //                          ShipmentCnt11, ArrivalCnt11, Sum_ShipmentCnt11, Sum_ArrivalCnt11, 
            //                          Cus_ShipmentCnt11, Cus_ArrivalCnt11, Wh_ShipmentCnt11, Wh_ArrivalCnt11, 
            //                          Sec_ShipmentCnt11, Sec_ArrivalCnt11, Ttl_ShipmentCnt11, Ttl_ArrivalCnt11 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt11, 
                                      ShipmentCnt11, ArrivalCnt11, Sum_ShipmentCnt11, Sum_ArrivalCnt11, 
                                      Cus_ShipmentCnt11, Cus_ArrivalCnt11, Wh_ShipmentCnt11, Wh_ArrivalCnt11, 
                                      Gl_ShipmentCnt11, Gl_ArrivalCnt11, Gm_ShipmentCnt11, Gm_ArrivalCnt11 , Gd_ShipmentCnt11, Gd_ArrivalCnt11,
                                      Sec_ShipmentCnt11, Sec_ArrivalCnt11, Ttl_ShipmentCnt11, Ttl_ArrivalCnt11 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
            // １２月目
            //--- DEL 2008/07/16 ---------->>>>>
            //ctrls = new ARControl[] { Lb_ShipArrivalCnt12, 
            //                          ShipmentCnt12, ArrivalCnt12, Sum_ShipmentCnt12, Sum_ArrivalCnt12, 
            //                          Cus_ShipmentCnt12, Cus_ArrivalCnt12, Wh_ShipmentCnt12, Wh_ArrivalCnt12, 
            //                          Sec_ShipmentCnt12, Sec_ArrivalCnt12, Ttl_ShipmentCnt12, Ttl_ArrivalCnt12 };
            //--- DEL 2008/07/16 ----------<<<<<
            //--- ADD 2008/07/16 ---------->>>>>
            ctrls = new ARControl[] { Lb_ShipArrivalCnt12, 
                                      ShipmentCnt12, ArrivalCnt12, Sum_ShipmentCnt12, Sum_ArrivalCnt12, 
                                      Cus_ShipmentCnt12, Cus_ArrivalCnt12, Wh_ShipmentCnt12, Wh_ArrivalCnt12, 
                                      Gl_ShipmentCnt12, Gl_ArrivalCnt12, Gm_ShipmentCnt12, Gm_ArrivalCnt12 , Gd_ShipmentCnt12, Gd_ArrivalCnt12,
                                      Sec_ShipmentCnt12, Sec_ArrivalCnt12, Ttl_ShipmentCnt12, Ttl_ArrivalCnt12 };
            //--- ADD 2008/07/16 ----------<<<<<
            ctrlsList.Add(ctrls);
               ---DEL 2009/04/02 不具合対応[12998] ---------------------------------------------------------------------------------<<<<< */
            // ---ADD 2009/04/02 不具合対応[12998] --------------------------------------------------------------------------------->>>>>
            // １月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt1, 
                                      ShipmentCnt1, ArrivalCnt1, Sum_ShipmentCnt1, Sum_ArrivalCnt1, 
                                      Cus_ShipmentCnt1, Cus_ArrivalCnt1, Wh_ShipmentCnt1, Wh_ArrivalCnt1, 
                                      Gl_ShipmentCnt1, Gl_ArrivalCnt1, Gm_ShipmentCnt1, Gm_ArrivalCnt1 , Gd_ShipmentCnt1, Gd_ArrivalCnt1,
                                      Ttl_ShipmentCnt1, Ttl_ArrivalCnt1 };
            ctrlsList.Add(ctrls);
            // ２月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt2, 
                                      ShipmentCnt2, ArrivalCnt2, Sum_ShipmentCnt2, Sum_ArrivalCnt2, 
                                      Cus_ShipmentCnt2, Cus_ArrivalCnt2, Wh_ShipmentCnt2, Wh_ArrivalCnt2, 
                                      Gl_ShipmentCnt2, Gl_ArrivalCnt2, Gm_ShipmentCnt2, Gm_ArrivalCnt2 , Gd_ShipmentCnt2, Gd_ArrivalCnt2,
                                      Ttl_ShipmentCnt2, Ttl_ArrivalCnt2 };
            ctrlsList.Add(ctrls);
            // ３月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt3, 
                                      ShipmentCnt3, ArrivalCnt3, Sum_ShipmentCnt3, Sum_ArrivalCnt3, 
                                      Cus_ShipmentCnt3, Cus_ArrivalCnt3, Wh_ShipmentCnt3, Wh_ArrivalCnt3, 
                                      Gl_ShipmentCnt3, Gl_ArrivalCnt3, Gm_ShipmentCnt3, Gm_ArrivalCnt3 , Gd_ShipmentCnt3, Gd_ArrivalCnt3,
                                      Ttl_ShipmentCnt3, Ttl_ArrivalCnt3 };
            ctrlsList.Add(ctrls);
            // ４月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt4, 
                                      ShipmentCnt4, ArrivalCnt4, Sum_ShipmentCnt4, Sum_ArrivalCnt4, 
                                      Cus_ShipmentCnt4, Cus_ArrivalCnt4, Wh_ShipmentCnt4, Wh_ArrivalCnt4, 
                                      Gl_ShipmentCnt4, Gl_ArrivalCnt4, Gm_ShipmentCnt4, Gm_ArrivalCnt4 , Gd_ShipmentCnt4, Gd_ArrivalCnt4,
                                      Ttl_ShipmentCnt4, Ttl_ArrivalCnt4 };
            ctrlsList.Add(ctrls);
            // ５月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt5, 
                                      ShipmentCnt5, ArrivalCnt5, Sum_ShipmentCnt5, Sum_ArrivalCnt5, 
                                      Cus_ShipmentCnt5, Cus_ArrivalCnt5, Wh_ShipmentCnt5, Wh_ArrivalCnt5, 
                                      Gl_ShipmentCnt5, Gl_ArrivalCnt5, Gm_ShipmentCnt5, Gm_ArrivalCnt5 , Gd_ShipmentCnt5, Gd_ArrivalCnt5,
                                      Ttl_ShipmentCnt5, Ttl_ArrivalCnt5 };
            ctrlsList.Add(ctrls);
            // ６月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt6, 
                                      ShipmentCnt6, ArrivalCnt6, Sum_ShipmentCnt6, Sum_ArrivalCnt6, 
                                      Cus_ShipmentCnt6, Cus_ArrivalCnt6, Wh_ShipmentCnt6, Wh_ArrivalCnt6, 
                                      Gl_ShipmentCnt6, Gl_ArrivalCnt6, Gm_ShipmentCnt6, Gm_ArrivalCnt6 , Gd_ShipmentCnt6, Gd_ArrivalCnt6,
                                      Ttl_ShipmentCnt6, Ttl_ArrivalCnt6 };
            ctrlsList.Add(ctrls);
            // ７月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt7, 
                                      ShipmentCnt7, ArrivalCnt7, Sum_ShipmentCnt7, Sum_ArrivalCnt7, 
                                      Cus_ShipmentCnt7, Cus_ArrivalCnt7, Wh_ShipmentCnt7, Wh_ArrivalCnt7, 
                                      Gl_ShipmentCnt7, Gl_ArrivalCnt7, Gm_ShipmentCnt7, Gm_ArrivalCnt7 , Gd_ShipmentCnt7, Gd_ArrivalCnt7,
                                      Ttl_ShipmentCnt7, Ttl_ArrivalCnt7 };
            ctrlsList.Add(ctrls);
            // ８月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt8, 
                                      ShipmentCnt8, ArrivalCnt8, Sum_ShipmentCnt8, Sum_ArrivalCnt8, 
                                      Cus_ShipmentCnt8, Cus_ArrivalCnt8, Wh_ShipmentCnt8, Wh_ArrivalCnt8, 
                                      Gl_ShipmentCnt8, Gl_ArrivalCnt8, Gm_ShipmentCnt8, Gm_ArrivalCnt8 , Gd_ShipmentCnt8, Gd_ArrivalCnt8,
                                      Ttl_ShipmentCnt8, Ttl_ArrivalCnt8 };
            ctrlsList.Add(ctrls);
            // ９月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt9, 
                                      ShipmentCnt9, ArrivalCnt9, Sum_ShipmentCnt9, Sum_ArrivalCnt9, 
                                      Cus_ShipmentCnt9, Cus_ArrivalCnt9, Wh_ShipmentCnt9, Wh_ArrivalCnt9, 
                                      Gl_ShipmentCnt9, Gl_ArrivalCnt9, Gm_ShipmentCnt9, Gm_ArrivalCnt9 , Gd_ShipmentCnt9, Gd_ArrivalCnt9,
                                      Ttl_ShipmentCnt9, Ttl_ArrivalCnt9 };
            ctrlsList.Add(ctrls);
            // １０月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt10, 
                                      ShipmentCnt10, ArrivalCnt10, Sum_ShipmentCnt10, Sum_ArrivalCnt10, 
                                      Cus_ShipmentCnt10, Cus_ArrivalCnt10, Wh_ShipmentCnt10, Wh_ArrivalCnt10, 
                                      Gl_ShipmentCnt10, Gl_ArrivalCnt10, Gm_ShipmentCnt10, Gm_ArrivalCnt10 , Gd_ShipmentCnt10, Gd_ArrivalCnt10,
                                      Ttl_ShipmentCnt10, Ttl_ArrivalCnt10 };
            ctrlsList.Add(ctrls);
            // １１月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt11, 
                                      ShipmentCnt11, ArrivalCnt11, Sum_ShipmentCnt11, Sum_ArrivalCnt11, 
                                      Cus_ShipmentCnt11, Cus_ArrivalCnt11, Wh_ShipmentCnt11, Wh_ArrivalCnt11, 
                                      Gl_ShipmentCnt11, Gl_ArrivalCnt11, Gm_ShipmentCnt11, Gm_ArrivalCnt11 , Gd_ShipmentCnt11, Gd_ArrivalCnt11,
                                      Ttl_ShipmentCnt11, Ttl_ArrivalCnt11 };
            ctrlsList.Add(ctrls);
            // １２月目
            ctrls = new ARControl[] { Lb_ShipArrivalCnt12, 
                                      ShipmentCnt12, ArrivalCnt12, Sum_ShipmentCnt12, Sum_ArrivalCnt12, 
                                      Cus_ShipmentCnt12, Cus_ArrivalCnt12, Wh_ShipmentCnt12, Wh_ArrivalCnt12, 
                                      Gl_ShipmentCnt12, Gl_ArrivalCnt12, Gm_ShipmentCnt12, Gm_ArrivalCnt12 , Gd_ShipmentCnt12, Gd_ArrivalCnt12,
                                      Ttl_ShipmentCnt12, Ttl_ArrivalCnt12 };
            ctrlsList.Add(ctrls);
            // ---ADD 2009/04/02 不具合対応[12998] ---------------------------------------------------------------------------------<<<<<

            // 範囲指定月数以降は印字しない
            for ( int index = month; index < ctrlsList.Count; index++ ) {
                foreach( ARControl ctrl in ctrlsList[index] ) {
                    ctrl.Visible = false;
                }
            }

            #endregion　＜＜　範囲指定月数で印字制御　＞＞


            #region ＜＜　月のタイトルラベル設定（範囲内のみ）　＞＞
            // 月のタイトルラベル設定
            Label[] monthLabel = new Label[12];
            monthLabel[0] = this.Lb_ShipArrivalCnt1;
            monthLabel[1] = this.Lb_ShipArrivalCnt2;
            monthLabel[2] = this.Lb_ShipArrivalCnt3;
            monthLabel[3] = this.Lb_ShipArrivalCnt4;
            monthLabel[4] = this.Lb_ShipArrivalCnt5;
            monthLabel[5] = this.Lb_ShipArrivalCnt6;
            monthLabel[6] = this.Lb_ShipArrivalCnt7;
            monthLabel[7] = this.Lb_ShipArrivalCnt8;
            monthLabel[8] = this.Lb_ShipArrivalCnt9;
            monthLabel[9] = this.Lb_ShipArrivalCnt10;
            monthLabel[10] = this.Lb_ShipArrivalCnt11;
            monthLabel[11] = this.Lb_ShipArrivalCnt12;

            for ( int index = 0; index < month; index++ ) {
                monthLabel[index].Text = GetMonthTitle(this._stockShipArrivalListCndtn.St_AddUpYearMonth, index);
            }
            #endregion


            #region ＜＜　出荷／入荷の印字制御　＞＞
            // ---DEL 2009/05/26 不具合対応[13378] ----------->>>>>
            ////--- DEL 2008/07/16 ---------->>>>>
            ////TextBox[] tbShipment = new TextBox[14 * 6];
            ////--- DEL 2008/07/16 ----------<<<<<
            ////--- ADD 2008/07/16 ---------->>>>>
            //TextBox[] tbShipment = new TextBox[14 * 9];
            ////--- ADD 2008/07/16 ----------<<<<<
            // ---DEL 2009/05/26 不具合対応[13378] -----------<<<<<
            TextBox[] tbShipment = new TextBox[14 * 8];     //ADD 2009/05/26 不具合対応[13378]

            int tbIndex = 0;
            // (通常行)
            tbShipment[tbIndex++] = this.ShipmentCnt1;
            tbShipment[tbIndex++] = this.ShipmentCnt2;
            tbShipment[tbIndex++] = this.ShipmentCnt3;
            tbShipment[tbIndex++] = this.ShipmentCnt4;
            tbShipment[tbIndex++] = this.ShipmentCnt5;
            tbShipment[tbIndex++] = this.ShipmentCnt6;
            tbShipment[tbIndex++] = this.ShipmentCnt7;
            tbShipment[tbIndex++] = this.ShipmentCnt8;
            tbShipment[tbIndex++] = this.ShipmentCnt9;
            tbShipment[tbIndex++] = this.ShipmentCnt10;
            tbShipment[tbIndex++] = this.ShipmentCnt11;
            tbShipment[tbIndex++] = this.ShipmentCnt12;
            tbShipment[tbIndex++] = this.Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt;
            // (メーカー計)
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Sum_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Sum_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Sum_Sum_ShipmentCnt;
            // (仕入先計)
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Cus_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Cus_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Cus_Sum_ShipmentCnt;
            // (倉庫計)
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Wh_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Wh_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Wh_Sum_ShipmentCnt;
            /* ---DEL 2009/04/02 不具合対応[12998] --------------->>>>>
            // (拠点計)
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Sec_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Sec_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Sec_Sum_ShipmentCnt;
               ---DEL 2009/04/02 不具合対応[12998] ---------------<<<<< */
            // (総合計)
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Ttl_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Ttl_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Ttl_Sum_ShipmentCnt;
            //--- ADD 2008/07/16 ---------->>>>>
            // (商品大分類計)
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Gl_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Gl_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Gl_Sum_ShipmentCnt;
            // (商品中分類計)
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Gm_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Gm_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Gm_Sum_ShipmentCnt;
            // (グループ計)
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt1;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt2;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt3;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt4;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt5;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt6;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt7;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt8;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt9;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt10;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt11;
            tbShipment[tbIndex++] = this.Gd_ShipmentCnt12;
            tbShipment[tbIndex++] = this.Gd_Ave_ShipmentCnt;
            tbShipment[tbIndex++] = this.Gd_Sum_ShipmentCnt;
            //--- ADD 2008/07/16 ----------<<<<<

            // ---DEL 2009/05/26 不具合対応[13378] ----------->>>>>
            ////--- DEL 2008/07/16 ---------->>>>>
            ////TextBox[] tbArrival = new TextBox[14 * 6];
            ////--- DEL 2008/07/16 ----------<<<<<
            ////--- ADD 2008/07/16 ---------->>>>>
            //TextBox[] tbArrival = new TextBox[14 * 9];
            ////--- ADD 2008/07/16 ----------<<<<<
            // ---DEL 2009/05/26 不具合対応[13378] -----------<<<<<
            TextBox[] tbArrival = new TextBox[14 * 8];      //ADD 2009/05/26 不具合対応[13378]

            tbIndex = 0;
            // (通常行)
            tbArrival[tbIndex++] = this.ArrivalCnt1;
            tbArrival[tbIndex++] = this.ArrivalCnt2;
            tbArrival[tbIndex++] = this.ArrivalCnt3;
            tbArrival[tbIndex++] = this.ArrivalCnt4;
            tbArrival[tbIndex++] = this.ArrivalCnt5;
            tbArrival[tbIndex++] = this.ArrivalCnt6;
            tbArrival[tbIndex++] = this.ArrivalCnt7;
            tbArrival[tbIndex++] = this.ArrivalCnt8;
            tbArrival[tbIndex++] = this.ArrivalCnt9;
            tbArrival[tbIndex++] = this.ArrivalCnt10;
            tbArrival[tbIndex++] = this.ArrivalCnt11;
            tbArrival[tbIndex++] = this.ArrivalCnt12;
            tbArrival[tbIndex++] = this.Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt;
            // (メーカー計)
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Sum_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Sum_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Sum_Sum_ArrivalCnt;
            // (仕入先計)
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Cus_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Cus_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Cus_Sum_ArrivalCnt;
            // (倉庫計)
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Wh_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Wh_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Wh_Sum_ArrivalCnt;
            /* ---DEL 2009/04/02 不具合対応[12998] ---------------------->>>>>
            // (拠点計)
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Sec_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Sec_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Sec_Sum_ArrivalCnt;
               ---DEL 2009/04/02 不具合対応[12998] ----------------------<<<<< */
            // (総合計)
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Ttl_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Ttl_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Ttl_Sum_ArrivalCnt;
            //--- ADD 2008/07/16 ---------->>>>>
            // (商品大分類計)
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Gl_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Gl_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Gl_Sum_ArrivalCnt;
            // (商品中分類計)
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Gm_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Gm_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Gm_Sum_ArrivalCnt;
            // (グループ計)
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt1;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt2;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt3;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt4;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt5;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt6;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt7;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt8;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt9;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt10;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt11;
            tbArrival[tbIndex++] = this.Gd_ArrivalCnt12;
            tbArrival[tbIndex++] = this.Gd_Ave_ArrivalCnt;
            tbArrival[tbIndex++] = this.Gd_Sum_ArrivalCnt;
            //--- ADD 2008/07/16 ----------<<<<<

            // 出荷のみの場合（入荷数項目を消す）
            if (this._stockShipArrivalListCndtn.ShipArrivalPrintDiv == StockShipArrivalListCndtn.ShipArrivalPrintDivState.Shipment) {
                for ( int index = 0; index < tbArrival.Length; index++ ) {
                    tbArrival[index].Visible = false;
                }
                this.Detail.Height = ( float ) 0.203;
                this.GoodsMakerFooter.Height = ( float ) 0.239;
                this.CustomerFooter.Height = ( float ) 0.239;
                this.WarehouseFooter.Height = ( float ) 0.239;
                //this.SectionFooter.Height = ( float ) 0.239;          //DEL 2009/04/02 不具合対応[12998]
                this.GrandTotalFooter.Height = ( float ) 0.239;
                //--- ADD 2008/07/16 ---------->>>>>
                this.LargeGoodsGanreFooter.Height = ( float )0.239;
                this.MediumGoodsGanreFooter.Height = ( float )0.239;
                this.DetailGoodsGanreFooter.Height = ( float )0.239;
                //--- ADD 2008/07/16 ----------<<<<<
            }
            // 入荷のみの場合（出荷数項目を消して、入荷数項目の印刷位置を調整）
            else if (this._stockShipArrivalListCndtn.ShipArrivalPrintDiv == StockShipArrivalListCndtn.ShipArrivalPrintDivState.Arrival) {
                for (int index = 0; index < tbShipment.Length; index++) {
                    tbShipment[index].Visible = false;
                    tbArrival[index].Top = tbShipment[index].Top;
                }
                this.Detail.Height = ( float ) 0.203;
                this.GoodsMakerFooter.Height = ( float ) 0.239;
                this.CustomerFooter.Height = ( float ) 0.239;
                this.WarehouseFooter.Height = ( float ) 0.239;
                //this.SectionFooter.Height = ( float ) 0.239;          //DEL 2009/04/02 不具合対応[12998]
                this.GrandTotalFooter.Height = ( float ) 0.239;
                //--- ADD 2008/07/16 ---------->>>>>
                this.LargeGoodsGanreFooter.Height = ( float )0.239;
                this.MediumGoodsGanreFooter.Height = ( float )0.239;
                this.DetailGoodsGanreFooter.Height = ( float )0.239;
                //--- ADD 2008/07/16 ----------<<<<<
            }
            #endregion ＜＜　出荷／入荷の印字制御　＞＞

            // ---ADD 2009/03/18 不具合対応[12542] ---------------------------------------------->>>>>
            this.DetailGoodsGanreHeader.DataField = "Sort_DetailGoodsGanre";            //グループ
            this.MediumGoodsGanreHeader.DataField = "Sort_MediumGoodsGanre";            //商品中分類
            this.LargeGoodsGanreHeader.DataField = "Sort_LargeGoodsGanre";              //商品大分類
            this.GoodsMakerHeader.DataField = "GoodsMakerCd";                           //メーカー
            this.CustomerHeader.DataField = "Sort_CustomerCode";                        //仕入先
            this.WarehouseHeader.DataField = "Sort_WarehouseCode";                      //倉庫
            //this.SectionHeader.DataField = "SectionCode";                               //拠点            //DEL 2009/04/02 不具合対応[12998]
            // ---ADD 2009/03/18 不具合対応[12542] ----------------------------------------------<<<<<

            #region ＜＜　各合計の　印字有無制御　＞＞
            // 商品区分詳細計なし
            if (this._stockShipArrivalListCndtn.DetailGoodsGanreSummaryPrintDiv == StockShipArrivalListCndtn.SummaryPrintDivState.None)
            {
                this.DetailGoodsGanreHeader.Visible = false;
                this.DetailGoodsGanreFooter.Visible = false;
                this.DetailGoodsGanreHeader.DataField = "";         //ADD 2009/03/18 不具合対応[12542]
            }
            // 商品区分計なし
            if (this._stockShipArrivalListCndtn.MediumGoodsGanreSummaryPrintDiv == StockShipArrivalListCndtn.SummaryPrintDivState.None)
            {
                this.MediumGoodsGanreHeader.Visible = false;
                this.MediumGoodsGanreFooter.Visible = false;
                this.MediumGoodsGanreHeader.DataField = "";         //ADD 2009/03/18 不具合対応[12542]
            }
            // 商品区分グループ計なし
            if (this._stockShipArrivalListCndtn.LargeGoodsGanreSummaryPrintDiv == StockShipArrivalListCndtn.SummaryPrintDivState.None)
            {
                this.LargeGoodsGanreHeader.Visible = false;
                this.LargeGoodsGanreFooter.Visible = false;
                this.LargeGoodsGanreHeader.DataField = "";          //ADD 2009/03/18 不具合対応[12542]
            }
            // メーカー計なし
            if (this._stockShipArrivalListCndtn.GoodsMakerSummaryPrintDiv == StockShipArrivalListCndtn.SummaryPrintDivState.None)
            {
                this.GoodsMakerHeader.Visible = false;
                this.GoodsMakerFooter.Visible = false;
                this.GoodsMakerHeader.DataField = "";               //ADD 2009/03/18 不具合対応[12542]
            }
            // 仕入先計なし
            if (this._stockShipArrivalListCndtn.SupplierSummaryPrintDiv == StockShipArrivalListCndtn.SummaryPrintDivState.None)
            {
                //this.CustomerHeader.Visible = false;
                this.CustomerFooter.Visible = false;
            }
            // 倉庫計なし
            if (this._stockShipArrivalListCndtn.WarehouseSummaryPrintDiv == StockShipArrivalListCndtn.SummaryPrintDivState.None)
            {
                this.WarehouseHeader.Visible = false;
                this.WarehouseFooter.Visible = false;
            }
            #endregion

            // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------->>>>>
            #region ＜＜　改頁有無　＞＞
            // 改頁
            if (this._stockShipArrivalListCndtn.NewPageDiv == StockShipArrivalListCndtn.NewPageDivState.EachSummaly)
            {
                /* ---DEL 2009/04/02 不具合対応[12998] ------------------------------------------->>>>>
                // 拠点
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                   ---DEL 2009/04/02 不具合対応[12998] -------------------------------------------<<<<< */
                // 倉庫
                this.WarehouseHeader.NewPage = NewPage.Before;
                this.WarehouseHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.WarehouseHeader.Visible = true;
            }
            else
            {
                /* ---DEL 2009/04/02 不具合対応[12998] ------------------------------------------->>>>>
                // しない
                this.SectionHeader.NewPage = NewPage.None;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;
                   ---DEL 2009/04/02 不具合対応[12998] -------------------------------------------<<<<< */
                this.WarehouseHeader.NewPage = NewPage.None;
                this.WarehouseHeader.RepeatStyle = RepeatStyle.OnPage;
            }
            #endregion
            // ---ADD 2009/03/18 不具合対応[12542] -------------------------------------<<<<<

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
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( StockShipArrivalListCndtn.ct_DateFomat, DateTime.Now );
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 拠点オプション有無判定
            //string sectionTitle = string.Format( "{0}拠点：", this._stockShipArrivalListCndtn.MainExtractTitle );
            //if ( this._stockShipArrivalListCndtn.IsOptSection )
            //{
            //    if ( this._stockShipArrivalListCndtn.IsSelectAllSection )
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
            //    }
            //    else
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    }

            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer  : 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
			
		}

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
		private DataDynamics.ActiveReports.Label Lb_GoodsNo;
		private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label Lb_GoodsName;
		private DataDynamics.ActiveReports.Label Lb_WarehouseShelfNo;
		private DataDynamics.ActiveReports.Label Lb_StockCreateDate;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt1;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt2;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt3;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt4;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt5;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt6;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt7;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt8;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt9;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt10;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt11;
		private DataDynamics.ActiveReports.Label Lb_ShipArrivalCnt12;
		private DataDynamics.ActiveReports.Label Lb_Ave_ShipArrivalCnt;
		private DataDynamics.ActiveReports.Label Lb_Sum_ShipArrivalCnt;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
		private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
		private DataDynamics.ActiveReports.TextBox WarehouseCode;
		private DataDynamics.ActiveReports.TextBox WarehouseName;
		private DataDynamics.ActiveReports.TextBox MakerName;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
		private DataDynamics.ActiveReports.Line Line3;
		private DataDynamics.ActiveReports.GroupHeader GoodsMakerHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox GoodsNo;
		private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.TextBox GoodsName;
		private DataDynamics.ActiveReports.TextBox WarehouseShelfNo;
		private DataDynamics.ActiveReports.TextBox StockCreateDate;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt1;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt2;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt3;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt4;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt5;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt6;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt7;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt8;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt9;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt10;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt11;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt12;
		private DataDynamics.ActiveReports.TextBox Ave_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt1;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt2;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt3;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt4;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt5;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt6;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt7;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt8;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt9;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt10;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt11;
		private DataDynamics.ActiveReports.TextBox ArrivalCnt12;
		private DataDynamics.ActiveReports.TextBox Ave_ArrivalCnt;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt;
		private DataDynamics.ActiveReports.GroupFooter GoodsMakerFooter;
		private DataDynamics.ActiveReports.Line Line44;
		private DataDynamics.ActiveReports.TextBox tb_SumTitle;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt1;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt2;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt3;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt4;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt5;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt6;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt7;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt8;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt9;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt10;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt11;
		private DataDynamics.ActiveReports.TextBox Sum_ShipmentCnt12;
		private DataDynamics.ActiveReports.TextBox Sum_Ave_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Sum_Sum_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt1;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt2;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt3;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt4;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt5;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt6;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt7;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt8;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt9;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt10;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt11;
		private DataDynamics.ActiveReports.TextBox Sum_ArrivalCnt12;
		private DataDynamics.ActiveReports.TextBox Sum_Ave_ArrivalCnt;
		private DataDynamics.ActiveReports.TextBox Sum_Sum_ArrivalCnt;
		private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt1;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt2;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt3;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt4;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt5;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt6;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt7;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt8;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt9;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt10;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt11;
		private DataDynamics.ActiveReports.TextBox Cus_ShipmentCnt12;
		private DataDynamics.ActiveReports.TextBox Cus_Ave_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Cus_Sum_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt1;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt2;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt3;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt4;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt5;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt6;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt7;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt8;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt9;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt10;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt11;
		private DataDynamics.ActiveReports.TextBox Cus_ArrivalCnt12;
		private DataDynamics.ActiveReports.TextBox Cus_Ave_ArrivalCnt;
		private DataDynamics.ActiveReports.TextBox Cus_Sum_ArrivalCnt;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt1;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt2;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt3;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt4;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt5;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt6;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt7;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt8;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt9;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt10;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt11;
		private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt12;
		private DataDynamics.ActiveReports.TextBox Wh_Ave_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Wh_Sum_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt1;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt2;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt3;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt4;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt5;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt6;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt7;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt8;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt9;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt10;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt11;
		private DataDynamics.ActiveReports.TextBox Wh_ArrivalCnt12;
		private DataDynamics.ActiveReports.TextBox Wh_Ave_ArrivalCnt;
        private DataDynamics.ActiveReports.TextBox Wh_Sum_ArrivalCnt;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt1;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt2;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt3;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt4;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt5;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt6;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt7;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt8;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt9;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt10;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt11;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt12;
		private DataDynamics.ActiveReports.TextBox Ttl_Ave_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Ttl_Sum_ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt1;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt2;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt3;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt4;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt5;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt6;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt7;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt8;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt9;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt10;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt11;
		private DataDynamics.ActiveReports.TextBox Ttl_ArrivalCnt12;
		private DataDynamics.ActiveReports.TextBox Ttl_Ave_ArrivalCnt;
		private DataDynamics.ActiveReports.TextBox Ttl_Sum_ArrivalCnt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCZAI02123P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
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
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_StockCreateDate = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt1 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt2 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt3 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt4 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt5 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt6 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt7 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt8 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt9 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt10 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt11 = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipArrivalCnt12 = new DataDynamics.ActiveReports.Label();
            this.Lb_Ave_ShipArrivalCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_Sum_ShipArrivalCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_Warehouse = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMaker = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Wh_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Wh_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Wh_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Cus_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Cus_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Cus_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Cus_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.tb_SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sum_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Sum_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sum_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.LargeGoodsGanreHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.LargeGoodsGanreFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gl_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Gl_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gl_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.MediumGoodsGanreHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MediumGoodsGanreFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gm_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Gm_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gm_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.DetailGoodsGanreHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DetailGoodsGanreFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ShipmentCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_Ave_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt4 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt5 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt6 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt7 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt8 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt9 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt10 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt11 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_ArrivalCnt12 = new DataDynamics.ActiveReports.TextBox();
            this.Gd_Ave_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gd_Sum_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gd_Sum_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Ave_ShipArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Sum_ShipArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Ave_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Ave_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Sum_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Sum_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.Line37,
            this.GoodsName,
            this.WarehouseShelfNo,
            this.StockCreateDate,
            this.ShipmentCnt1,
            this.ShipmentCnt2,
            this.ShipmentCnt3,
            this.ShipmentCnt4,
            this.ShipmentCnt5,
            this.ShipmentCnt6,
            this.ShipmentCnt7,
            this.ShipmentCnt8,
            this.ShipmentCnt9,
            this.ShipmentCnt10,
            this.ShipmentCnt11,
            this.ShipmentCnt12,
            this.Ave_ShipmentCnt,
            this.Sum_ShipmentCnt,
            this.ArrivalCnt1,
            this.ArrivalCnt2,
            this.ArrivalCnt3,
            this.ArrivalCnt4,
            this.ArrivalCnt5,
            this.ArrivalCnt6,
            this.ArrivalCnt7,
            this.ArrivalCnt8,
            this.ArrivalCnt9,
            this.ArrivalCnt10,
            this.ArrivalCnt11,
            this.ArrivalCnt12,
            this.Ave_ArrivalCnt,
            this.Sum_ArrivalCnt});
            this.Detail.Height = 0.40625F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.GoodsNo.Height = 0.156F;
            this.GoodsNo.Left = 0F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.375F;
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
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.156F;
            this.GoodsName.Left = 1.375F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.1875F;
            // 
            // WarehouseShelfNo
            // 
            this.WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo.Height = 0.156F;
            this.WarehouseShelfNo.Left = 2.5625F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0.0625F;
            this.WarehouseShelfNo.Width = 0.5F;
            // 
            // StockCreateDate
            // 
            this.StockCreateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.RightColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.TopColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.DataField = "StockCreateDate";
            this.StockCreateDate.Height = 0.15625F;
            this.StockCreateDate.Left = 3.0625F;
            this.StockCreateDate.MultiLine = false;
            this.StockCreateDate.Name = "StockCreateDate";
            this.StockCreateDate.OutputFormat = resources.GetString("StockCreateDate.OutputFormat");
            this.StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.StockCreateDate.Text = "99/99/99";
            this.StockCreateDate.Top = 0.0625F;
            this.StockCreateDate.Width = 0.5F;
            // 
            // ShipmentCnt1
            // 
            this.ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt1.DataField = "ShipmentCnt1";
            this.ShipmentCnt1.Height = 0.156F;
            this.ShipmentCnt1.Left = 3.5625F;
            this.ShipmentCnt1.MultiLine = false;
            this.ShipmentCnt1.Name = "ShipmentCnt1";
            this.ShipmentCnt1.OutputFormat = resources.GetString("ShipmentCnt1.OutputFormat");
            this.ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt1.Text = "123,456";
            this.ShipmentCnt1.Top = 0.0625F;
            this.ShipmentCnt1.Width = 0.5F;
            // 
            // ShipmentCnt2
            // 
            this.ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt2.DataField = "ShipmentCnt2";
            this.ShipmentCnt2.Height = 0.156F;
            this.ShipmentCnt2.Left = 4.0625F;
            this.ShipmentCnt2.MultiLine = false;
            this.ShipmentCnt2.Name = "ShipmentCnt2";
            this.ShipmentCnt2.OutputFormat = resources.GetString("ShipmentCnt2.OutputFormat");
            this.ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt2.Text = "123,456";
            this.ShipmentCnt2.Top = 0.0625F;
            this.ShipmentCnt2.Width = 0.5F;
            // 
            // ShipmentCnt3
            // 
            this.ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt3.DataField = "ShipmentCnt3";
            this.ShipmentCnt3.Height = 0.156F;
            this.ShipmentCnt3.Left = 4.5625F;
            this.ShipmentCnt3.MultiLine = false;
            this.ShipmentCnt3.Name = "ShipmentCnt3";
            this.ShipmentCnt3.OutputFormat = resources.GetString("ShipmentCnt3.OutputFormat");
            this.ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt3.Text = "123,456";
            this.ShipmentCnt3.Top = 0.0625F;
            this.ShipmentCnt3.Width = 0.5F;
            // 
            // ShipmentCnt4
            // 
            this.ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt4.DataField = "ShipmentCnt4";
            this.ShipmentCnt4.Height = 0.156F;
            this.ShipmentCnt4.Left = 5.0625F;
            this.ShipmentCnt4.MultiLine = false;
            this.ShipmentCnt4.Name = "ShipmentCnt4";
            this.ShipmentCnt4.OutputFormat = resources.GetString("ShipmentCnt4.OutputFormat");
            this.ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt4.Text = "123,456";
            this.ShipmentCnt4.Top = 0.0625F;
            this.ShipmentCnt4.Width = 0.5F;
            // 
            // ShipmentCnt5
            // 
            this.ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt5.DataField = "ShipmentCnt5";
            this.ShipmentCnt5.Height = 0.156F;
            this.ShipmentCnt5.Left = 5.5625F;
            this.ShipmentCnt5.MultiLine = false;
            this.ShipmentCnt5.Name = "ShipmentCnt5";
            this.ShipmentCnt5.OutputFormat = resources.GetString("ShipmentCnt5.OutputFormat");
            this.ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt5.Text = "123,456";
            this.ShipmentCnt5.Top = 0.0625F;
            this.ShipmentCnt5.Width = 0.5F;
            // 
            // ShipmentCnt6
            // 
            this.ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt6.DataField = "ShipmentCnt6";
            this.ShipmentCnt6.Height = 0.156F;
            this.ShipmentCnt6.Left = 6.0625F;
            this.ShipmentCnt6.MultiLine = false;
            this.ShipmentCnt6.Name = "ShipmentCnt6";
            this.ShipmentCnt6.OutputFormat = resources.GetString("ShipmentCnt6.OutputFormat");
            this.ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt6.Text = "123,456";
            this.ShipmentCnt6.Top = 0.0625F;
            this.ShipmentCnt6.Width = 0.5F;
            // 
            // ShipmentCnt7
            // 
            this.ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt7.DataField = "ShipmentCnt7";
            this.ShipmentCnt7.Height = 0.156F;
            this.ShipmentCnt7.Left = 6.5625F;
            this.ShipmentCnt7.MultiLine = false;
            this.ShipmentCnt7.Name = "ShipmentCnt7";
            this.ShipmentCnt7.OutputFormat = resources.GetString("ShipmentCnt7.OutputFormat");
            this.ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt7.Text = "123,456";
            this.ShipmentCnt7.Top = 0.0625F;
            this.ShipmentCnt7.Width = 0.5F;
            // 
            // ShipmentCnt8
            // 
            this.ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt8.DataField = "ShipmentCnt8";
            this.ShipmentCnt8.Height = 0.156F;
            this.ShipmentCnt8.Left = 7.0625F;
            this.ShipmentCnt8.MultiLine = false;
            this.ShipmentCnt8.Name = "ShipmentCnt8";
            this.ShipmentCnt8.OutputFormat = resources.GetString("ShipmentCnt8.OutputFormat");
            this.ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt8.Text = "123,456";
            this.ShipmentCnt8.Top = 0.0625F;
            this.ShipmentCnt8.Width = 0.5F;
            // 
            // ShipmentCnt9
            // 
            this.ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt9.DataField = "ShipmentCnt9";
            this.ShipmentCnt9.Height = 0.156F;
            this.ShipmentCnt9.Left = 7.5625F;
            this.ShipmentCnt9.MultiLine = false;
            this.ShipmentCnt9.Name = "ShipmentCnt9";
            this.ShipmentCnt9.OutputFormat = resources.GetString("ShipmentCnt9.OutputFormat");
            this.ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt9.Text = "123,456";
            this.ShipmentCnt9.Top = 0.0625F;
            this.ShipmentCnt9.Width = 0.5F;
            // 
            // ShipmentCnt10
            // 
            this.ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt10.DataField = "ShipmentCnt10";
            this.ShipmentCnt10.Height = 0.156F;
            this.ShipmentCnt10.Left = 8.0625F;
            this.ShipmentCnt10.MultiLine = false;
            this.ShipmentCnt10.Name = "ShipmentCnt10";
            this.ShipmentCnt10.OutputFormat = resources.GetString("ShipmentCnt10.OutputFormat");
            this.ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt10.Text = "123,456";
            this.ShipmentCnt10.Top = 0.0625F;
            this.ShipmentCnt10.Width = 0.5F;
            // 
            // ShipmentCnt11
            // 
            this.ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt11.DataField = "ShipmentCnt11";
            this.ShipmentCnt11.Height = 0.156F;
            this.ShipmentCnt11.Left = 8.5625F;
            this.ShipmentCnt11.MultiLine = false;
            this.ShipmentCnt11.Name = "ShipmentCnt11";
            this.ShipmentCnt11.OutputFormat = resources.GetString("ShipmentCnt11.OutputFormat");
            this.ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt11.Text = "123,456";
            this.ShipmentCnt11.Top = 0.0625F;
            this.ShipmentCnt11.Width = 0.5F;
            // 
            // ShipmentCnt12
            // 
            this.ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt12.DataField = "ShipmentCnt12";
            this.ShipmentCnt12.Height = 0.156F;
            this.ShipmentCnt12.Left = 9.0625F;
            this.ShipmentCnt12.MultiLine = false;
            this.ShipmentCnt12.Name = "ShipmentCnt12";
            this.ShipmentCnt12.OutputFormat = resources.GetString("ShipmentCnt12.OutputFormat");
            this.ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt12.Text = "123,456";
            this.ShipmentCnt12.Top = 0.0625F;
            this.ShipmentCnt12.Width = 0.5F;
            // 
            // Ave_ShipmentCnt
            // 
            this.Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Ave_ShipmentCnt.Height = 0.156F;
            this.Ave_ShipmentCnt.Left = 9.5625F;
            this.Ave_ShipmentCnt.MultiLine = false;
            this.Ave_ShipmentCnt.Name = "Ave_ShipmentCnt";
            this.Ave_ShipmentCnt.OutputFormat = resources.GetString("Ave_ShipmentCnt.OutputFormat");
            this.Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Ave_ShipmentCnt.Text = "123,456";
            this.Ave_ShipmentCnt.Top = 0.0625F;
            this.Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Sum_ShipmentCnt
            // 
            this.Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Sum_ShipmentCnt.Height = 0.156F;
            this.Sum_ShipmentCnt.Left = 10.0625F;
            this.Sum_ShipmentCnt.MultiLine = false;
            this.Sum_ShipmentCnt.Name = "Sum_ShipmentCnt";
            this.Sum_ShipmentCnt.OutputFormat = resources.GetString("Sum_ShipmentCnt.OutputFormat");
            this.Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Sum_ShipmentCnt.Text = "123,456,789";
            this.Sum_ShipmentCnt.Top = 0.0625F;
            this.Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // ArrivalCnt1
            // 
            this.ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt1.DataField = "ArrivalCnt1";
            this.ArrivalCnt1.Height = 0.156F;
            this.ArrivalCnt1.Left = 3.5625F;
            this.ArrivalCnt1.MultiLine = false;
            this.ArrivalCnt1.Name = "ArrivalCnt1";
            this.ArrivalCnt1.OutputFormat = resources.GetString("ArrivalCnt1.OutputFormat");
            this.ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt1.Text = "123,456";
            this.ArrivalCnt1.Top = 0.25F;
            this.ArrivalCnt1.Width = 0.5F;
            // 
            // ArrivalCnt2
            // 
            this.ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt2.DataField = "ArrivalCnt2";
            this.ArrivalCnt2.Height = 0.156F;
            this.ArrivalCnt2.Left = 4.0625F;
            this.ArrivalCnt2.MultiLine = false;
            this.ArrivalCnt2.Name = "ArrivalCnt2";
            this.ArrivalCnt2.OutputFormat = resources.GetString("ArrivalCnt2.OutputFormat");
            this.ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt2.Text = "123,456";
            this.ArrivalCnt2.Top = 0.25F;
            this.ArrivalCnt2.Width = 0.5F;
            // 
            // ArrivalCnt3
            // 
            this.ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt3.DataField = "ArrivalCnt3";
            this.ArrivalCnt3.Height = 0.156F;
            this.ArrivalCnt3.Left = 4.5625F;
            this.ArrivalCnt3.MultiLine = false;
            this.ArrivalCnt3.Name = "ArrivalCnt3";
            this.ArrivalCnt3.OutputFormat = resources.GetString("ArrivalCnt3.OutputFormat");
            this.ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt3.Text = "123,456";
            this.ArrivalCnt3.Top = 0.25F;
            this.ArrivalCnt3.Width = 0.5F;
            // 
            // ArrivalCnt4
            // 
            this.ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt4.DataField = "ArrivalCnt4";
            this.ArrivalCnt4.Height = 0.156F;
            this.ArrivalCnt4.Left = 5.0625F;
            this.ArrivalCnt4.MultiLine = false;
            this.ArrivalCnt4.Name = "ArrivalCnt4";
            this.ArrivalCnt4.OutputFormat = resources.GetString("ArrivalCnt4.OutputFormat");
            this.ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt4.Text = "123,456";
            this.ArrivalCnt4.Top = 0.25F;
            this.ArrivalCnt4.Width = 0.5F;
            // 
            // ArrivalCnt5
            // 
            this.ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt5.DataField = "ArrivalCnt5";
            this.ArrivalCnt5.Height = 0.156F;
            this.ArrivalCnt5.Left = 5.5625F;
            this.ArrivalCnt5.MultiLine = false;
            this.ArrivalCnt5.Name = "ArrivalCnt5";
            this.ArrivalCnt5.OutputFormat = resources.GetString("ArrivalCnt5.OutputFormat");
            this.ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt5.Text = "123,456";
            this.ArrivalCnt5.Top = 0.25F;
            this.ArrivalCnt5.Width = 0.5F;
            // 
            // ArrivalCnt6
            // 
            this.ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt6.DataField = "ArrivalCnt6";
            this.ArrivalCnt6.Height = 0.156F;
            this.ArrivalCnt6.Left = 6.0625F;
            this.ArrivalCnt6.MultiLine = false;
            this.ArrivalCnt6.Name = "ArrivalCnt6";
            this.ArrivalCnt6.OutputFormat = resources.GetString("ArrivalCnt6.OutputFormat");
            this.ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt6.Text = "123,456";
            this.ArrivalCnt6.Top = 0.25F;
            this.ArrivalCnt6.Width = 0.5F;
            // 
            // ArrivalCnt7
            // 
            this.ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt7.DataField = "ArrivalCnt7";
            this.ArrivalCnt7.Height = 0.156F;
            this.ArrivalCnt7.Left = 6.5625F;
            this.ArrivalCnt7.MultiLine = false;
            this.ArrivalCnt7.Name = "ArrivalCnt7";
            this.ArrivalCnt7.OutputFormat = resources.GetString("ArrivalCnt7.OutputFormat");
            this.ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt7.Text = "123,456";
            this.ArrivalCnt7.Top = 0.25F;
            this.ArrivalCnt7.Width = 0.5F;
            // 
            // ArrivalCnt8
            // 
            this.ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt8.DataField = "ArrivalCnt8";
            this.ArrivalCnt8.Height = 0.156F;
            this.ArrivalCnt8.Left = 7.0625F;
            this.ArrivalCnt8.MultiLine = false;
            this.ArrivalCnt8.Name = "ArrivalCnt8";
            this.ArrivalCnt8.OutputFormat = resources.GetString("ArrivalCnt8.OutputFormat");
            this.ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt8.Text = "123,456";
            this.ArrivalCnt8.Top = 0.25F;
            this.ArrivalCnt8.Width = 0.5F;
            // 
            // ArrivalCnt9
            // 
            this.ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt9.DataField = "ArrivalCnt9";
            this.ArrivalCnt9.Height = 0.156F;
            this.ArrivalCnt9.Left = 7.5625F;
            this.ArrivalCnt9.MultiLine = false;
            this.ArrivalCnt9.Name = "ArrivalCnt9";
            this.ArrivalCnt9.OutputFormat = resources.GetString("ArrivalCnt9.OutputFormat");
            this.ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt9.Text = "123,456";
            this.ArrivalCnt9.Top = 0.25F;
            this.ArrivalCnt9.Width = 0.5F;
            // 
            // ArrivalCnt10
            // 
            this.ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt10.DataField = "ArrivalCnt10";
            this.ArrivalCnt10.Height = 0.156F;
            this.ArrivalCnt10.Left = 8.0625F;
            this.ArrivalCnt10.MultiLine = false;
            this.ArrivalCnt10.Name = "ArrivalCnt10";
            this.ArrivalCnt10.OutputFormat = resources.GetString("ArrivalCnt10.OutputFormat");
            this.ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt10.Text = "123,456";
            this.ArrivalCnt10.Top = 0.25F;
            this.ArrivalCnt10.Width = 0.5F;
            // 
            // ArrivalCnt11
            // 
            this.ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt11.DataField = "ArrivalCnt11";
            this.ArrivalCnt11.Height = 0.156F;
            this.ArrivalCnt11.Left = 8.5625F;
            this.ArrivalCnt11.MultiLine = false;
            this.ArrivalCnt11.Name = "ArrivalCnt11";
            this.ArrivalCnt11.OutputFormat = resources.GetString("ArrivalCnt11.OutputFormat");
            this.ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt11.Text = "123,456";
            this.ArrivalCnt11.Top = 0.25F;
            this.ArrivalCnt11.Width = 0.5F;
            // 
            // ArrivalCnt12
            // 
            this.ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt12.DataField = "ArrivalCnt12";
            this.ArrivalCnt12.Height = 0.156F;
            this.ArrivalCnt12.Left = 9.0625F;
            this.ArrivalCnt12.MultiLine = false;
            this.ArrivalCnt12.Name = "ArrivalCnt12";
            this.ArrivalCnt12.OutputFormat = resources.GetString("ArrivalCnt12.OutputFormat");
            this.ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ArrivalCnt12.Text = "123,456";
            this.ArrivalCnt12.Top = 0.25F;
            this.ArrivalCnt12.Width = 0.5F;
            // 
            // Ave_ArrivalCnt
            // 
            this.Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Ave_ArrivalCnt.Height = 0.156F;
            this.Ave_ArrivalCnt.Left = 9.5625F;
            this.Ave_ArrivalCnt.MultiLine = false;
            this.Ave_ArrivalCnt.Name = "Ave_ArrivalCnt";
            this.Ave_ArrivalCnt.OutputFormat = resources.GetString("Ave_ArrivalCnt.OutputFormat");
            this.Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Ave_ArrivalCnt.Text = "123,456";
            this.Ave_ArrivalCnt.Top = 0.25F;
            this.Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Sum_ArrivalCnt
            // 
            this.Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Sum_ArrivalCnt.Height = 0.15625F;
            this.Sum_ArrivalCnt.Left = 10.0625F;
            this.Sum_ArrivalCnt.MultiLine = false;
            this.Sum_ArrivalCnt.Name = "Sum_ArrivalCnt";
            this.Sum_ArrivalCnt.OutputFormat = resources.GetString("Sum_ArrivalCnt.OutputFormat");
            this.Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Sum_ArrivalCnt.Text = "123,456,789";
            this.Sum_ArrivalCnt.Top = 0.25F;
            this.Sum_ArrivalCnt.Width = 0.6875F;
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
            this.tb_ReportTitle.Text = "在庫入出荷一覧表";
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
            this.Lb_GoodsNo,
            this.Line42,
            this.Lb_GoodsName,
            this.Lb_WarehouseShelfNo,
            this.Lb_StockCreateDate,
            this.Lb_ShipArrivalCnt1,
            this.Lb_ShipArrivalCnt2,
            this.Lb_ShipArrivalCnt3,
            this.Lb_ShipArrivalCnt4,
            this.Lb_ShipArrivalCnt5,
            this.Lb_ShipArrivalCnt6,
            this.Lb_ShipArrivalCnt7,
            this.Lb_ShipArrivalCnt8,
            this.Lb_ShipArrivalCnt9,
            this.Lb_ShipArrivalCnt10,
            this.Lb_ShipArrivalCnt11,
            this.Lb_ShipArrivalCnt12,
            this.Lb_Ave_ShipArrivalCnt,
            this.Lb_Sum_ShipArrivalCnt,
            this.Lb_Warehouse,
            this.Lb_GoodsMaker,
            this.line7});
            this.TitleHeader.Height = 0.5729167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 0F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.3125F;
            this.Lb_GoodsNo.Width = 1.375F;
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
            // Lb_GoodsName
            // 
            this.Lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Height = 0.15625F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 1.375F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.3125F;
            this.Lb_GoodsName.Width = 1.1875F;
            // 
            // Lb_WarehouseShelfNo
            // 
            this.Lb_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Height = 0.15625F;
            this.Lb_WarehouseShelfNo.HyperLink = "";
            this.Lb_WarehouseShelfNo.Left = 2.5625F;
            this.Lb_WarehouseShelfNo.MultiLine = false;
            this.Lb_WarehouseShelfNo.Name = "Lb_WarehouseShelfNo";
            this.Lb_WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo.Text = "棚番";
            this.Lb_WarehouseShelfNo.Top = 0.3125F;
            this.Lb_WarehouseShelfNo.Width = 0.5F;
            // 
            // Lb_StockCreateDate
            // 
            this.Lb_StockCreateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Height = 0.15625F;
            this.Lb_StockCreateDate.HyperLink = "";
            this.Lb_StockCreateDate.Left = 3.0625F;
            this.Lb_StockCreateDate.MultiLine = false;
            this.Lb_StockCreateDate.Name = "Lb_StockCreateDate";
            this.Lb_StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockCreateDate.Text = "在庫登録日";
            this.Lb_StockCreateDate.Top = 0.3125F;
            this.Lb_StockCreateDate.Width = 0.625F;
            // 
            // Lb_ShipArrivalCnt1
            // 
            this.Lb_ShipArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt1.Height = 0.15625F;
            this.Lb_ShipArrivalCnt1.HyperLink = "";
            this.Lb_ShipArrivalCnt1.Left = 3.6875F;
            this.Lb_ShipArrivalCnt1.MultiLine = false;
            this.Lb_ShipArrivalCnt1.Name = "Lb_ShipArrivalCnt1";
            this.Lb_ShipArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt1.Text = "x1月";
            this.Lb_ShipArrivalCnt1.Top = 0.3125F;
            this.Lb_ShipArrivalCnt1.Width = 0.375F;
            // 
            // Lb_ShipArrivalCnt2
            // 
            this.Lb_ShipArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt2.Height = 0.15625F;
            this.Lb_ShipArrivalCnt2.HyperLink = "";
            this.Lb_ShipArrivalCnt2.Left = 4.0625F;
            this.Lb_ShipArrivalCnt2.MultiLine = false;
            this.Lb_ShipArrivalCnt2.Name = "Lb_ShipArrivalCnt2";
            this.Lb_ShipArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt2.Text = "x2月";
            this.Lb_ShipArrivalCnt2.Top = 0.3125F;
            this.Lb_ShipArrivalCnt2.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt3
            // 
            this.Lb_ShipArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt3.Height = 0.15625F;
            this.Lb_ShipArrivalCnt3.HyperLink = "";
            this.Lb_ShipArrivalCnt3.Left = 4.5625F;
            this.Lb_ShipArrivalCnt3.MultiLine = false;
            this.Lb_ShipArrivalCnt3.Name = "Lb_ShipArrivalCnt3";
            this.Lb_ShipArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt3.Text = "x3月";
            this.Lb_ShipArrivalCnt3.Top = 0.3125F;
            this.Lb_ShipArrivalCnt3.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt4
            // 
            this.Lb_ShipArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt4.Height = 0.15625F;
            this.Lb_ShipArrivalCnt4.HyperLink = "";
            this.Lb_ShipArrivalCnt4.Left = 5.0625F;
            this.Lb_ShipArrivalCnt4.MultiLine = false;
            this.Lb_ShipArrivalCnt4.Name = "Lb_ShipArrivalCnt4";
            this.Lb_ShipArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt4.Text = "x4月";
            this.Lb_ShipArrivalCnt4.Top = 0.3125F;
            this.Lb_ShipArrivalCnt4.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt5
            // 
            this.Lb_ShipArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt5.Height = 0.15625F;
            this.Lb_ShipArrivalCnt5.HyperLink = "";
            this.Lb_ShipArrivalCnt5.Left = 5.5625F;
            this.Lb_ShipArrivalCnt5.MultiLine = false;
            this.Lb_ShipArrivalCnt5.Name = "Lb_ShipArrivalCnt5";
            this.Lb_ShipArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt5.Text = "x5月";
            this.Lb_ShipArrivalCnt5.Top = 0.3125F;
            this.Lb_ShipArrivalCnt5.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt6
            // 
            this.Lb_ShipArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt6.Height = 0.15625F;
            this.Lb_ShipArrivalCnt6.HyperLink = "";
            this.Lb_ShipArrivalCnt6.Left = 6.0625F;
            this.Lb_ShipArrivalCnt6.MultiLine = false;
            this.Lb_ShipArrivalCnt6.Name = "Lb_ShipArrivalCnt6";
            this.Lb_ShipArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt6.Text = "x6月";
            this.Lb_ShipArrivalCnt6.Top = 0.3125F;
            this.Lb_ShipArrivalCnt6.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt7
            // 
            this.Lb_ShipArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt7.Height = 0.15625F;
            this.Lb_ShipArrivalCnt7.HyperLink = "";
            this.Lb_ShipArrivalCnt7.Left = 6.5625F;
            this.Lb_ShipArrivalCnt7.MultiLine = false;
            this.Lb_ShipArrivalCnt7.Name = "Lb_ShipArrivalCnt7";
            this.Lb_ShipArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt7.Text = "x7月";
            this.Lb_ShipArrivalCnt7.Top = 0.3125F;
            this.Lb_ShipArrivalCnt7.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt8
            // 
            this.Lb_ShipArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt8.Height = 0.15625F;
            this.Lb_ShipArrivalCnt8.HyperLink = "";
            this.Lb_ShipArrivalCnt8.Left = 7.0625F;
            this.Lb_ShipArrivalCnt8.MultiLine = false;
            this.Lb_ShipArrivalCnt8.Name = "Lb_ShipArrivalCnt8";
            this.Lb_ShipArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt8.Text = "x8月";
            this.Lb_ShipArrivalCnt8.Top = 0.3125F;
            this.Lb_ShipArrivalCnt8.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt9
            // 
            this.Lb_ShipArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt9.Height = 0.15625F;
            this.Lb_ShipArrivalCnt9.HyperLink = "";
            this.Lb_ShipArrivalCnt9.Left = 7.5625F;
            this.Lb_ShipArrivalCnt9.MultiLine = false;
            this.Lb_ShipArrivalCnt9.Name = "Lb_ShipArrivalCnt9";
            this.Lb_ShipArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt9.Text = "x9月";
            this.Lb_ShipArrivalCnt9.Top = 0.3125F;
            this.Lb_ShipArrivalCnt9.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt10
            // 
            this.Lb_ShipArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt10.Height = 0.15625F;
            this.Lb_ShipArrivalCnt10.HyperLink = "";
            this.Lb_ShipArrivalCnt10.Left = 8.0625F;
            this.Lb_ShipArrivalCnt10.MultiLine = false;
            this.Lb_ShipArrivalCnt10.Name = "Lb_ShipArrivalCnt10";
            this.Lb_ShipArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt10.Text = "10月";
            this.Lb_ShipArrivalCnt10.Top = 0.3125F;
            this.Lb_ShipArrivalCnt10.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt11
            // 
            this.Lb_ShipArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt11.Height = 0.15625F;
            this.Lb_ShipArrivalCnt11.HyperLink = "";
            this.Lb_ShipArrivalCnt11.Left = 8.5625F;
            this.Lb_ShipArrivalCnt11.MultiLine = false;
            this.Lb_ShipArrivalCnt11.Name = "Lb_ShipArrivalCnt11";
            this.Lb_ShipArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt11.Text = "11月";
            this.Lb_ShipArrivalCnt11.Top = 0.3125F;
            this.Lb_ShipArrivalCnt11.Width = 0.5F;
            // 
            // Lb_ShipArrivalCnt12
            // 
            this.Lb_ShipArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipArrivalCnt12.Height = 0.15625F;
            this.Lb_ShipArrivalCnt12.HyperLink = "";
            this.Lb_ShipArrivalCnt12.Left = 9.0625F;
            this.Lb_ShipArrivalCnt12.MultiLine = false;
            this.Lb_ShipArrivalCnt12.Name = "Lb_ShipArrivalCnt12";
            this.Lb_ShipArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipArrivalCnt12.Text = "12月";
            this.Lb_ShipArrivalCnt12.Top = 0.3125F;
            this.Lb_ShipArrivalCnt12.Width = 0.5F;
            // 
            // Lb_Ave_ShipArrivalCnt
            // 
            this.Lb_Ave_ShipArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Ave_ShipArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Ave_ShipArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Ave_ShipArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Ave_ShipArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Ave_ShipArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Ave_ShipArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Ave_ShipArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Ave_ShipArrivalCnt.Height = 0.15625F;
            this.Lb_Ave_ShipArrivalCnt.HyperLink = "";
            this.Lb_Ave_ShipArrivalCnt.Left = 9.5625F;
            this.Lb_Ave_ShipArrivalCnt.MultiLine = false;
            this.Lb_Ave_ShipArrivalCnt.Name = "Lb_Ave_ShipArrivalCnt";
            this.Lb_Ave_ShipArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Ave_ShipArrivalCnt.Text = "平均";
            this.Lb_Ave_ShipArrivalCnt.Top = 0.3125F;
            this.Lb_Ave_ShipArrivalCnt.Width = 0.5F;
            // 
            // Lb_Sum_ShipArrivalCnt
            // 
            this.Lb_Sum_ShipArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Sum_ShipArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Sum_ShipArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Sum_ShipArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Sum_ShipArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Sum_ShipArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Sum_ShipArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Sum_ShipArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Sum_ShipArrivalCnt.Height = 0.15625F;
            this.Lb_Sum_ShipArrivalCnt.HyperLink = "";
            this.Lb_Sum_ShipArrivalCnt.Left = 10.0625F;
            this.Lb_Sum_ShipArrivalCnt.MultiLine = false;
            this.Lb_Sum_ShipArrivalCnt.Name = "Lb_Sum_ShipArrivalCnt";
            this.Lb_Sum_ShipArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Sum_ShipArrivalCnt.Text = "合計";
            this.Lb_Sum_ShipArrivalCnt.Top = 0.3125F;
            this.Lb_Sum_ShipArrivalCnt.Width = 0.6875F;
            // 
            // Lb_Warehouse
            // 
            this.Lb_Warehouse.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Height = 0.15625F;
            this.Lb_Warehouse.HyperLink = "";
            this.Lb_Warehouse.Left = 0F;
            this.Lb_Warehouse.MultiLine = false;
            this.Lb_Warehouse.Name = "Lb_Warehouse";
            this.Lb_Warehouse.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Warehouse.Text = "倉庫";
            this.Lb_Warehouse.Top = 0.125F;
            this.Lb_Warehouse.Width = 1.5F;
            // 
            // Lb_GoodsMaker
            // 
            this.Lb_GoodsMaker.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Height = 0.15625F;
            this.Lb_GoodsMaker.HyperLink = "";
            this.Lb_GoodsMaker.Left = 1.5F;
            this.Lb_GoodsMaker.MultiLine = false;
            this.Lb_GoodsMaker.Name = "Lb_GoodsMaker";
            this.Lb_GoodsMaker.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMaker.Text = "仕入先";
            this.Lb_GoodsMaker.Top = 0.125F;
            this.Lb_GoodsMaker.Width = 3.8125F;
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
            this.line7.Top = 0.28F;
            this.line7.Width = 10.8125F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8125F;
            this.line7.Y1 = 0.28F;
            this.line7.Y2 = 0.28F;
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
            this.Ttl_ShipmentCnt1,
            this.Ttl_ShipmentCnt2,
            this.Ttl_ShipmentCnt3,
            this.Ttl_ShipmentCnt4,
            this.Ttl_ShipmentCnt5,
            this.Ttl_ShipmentCnt6,
            this.Ttl_ShipmentCnt7,
            this.Ttl_ShipmentCnt8,
            this.Ttl_ShipmentCnt9,
            this.Ttl_ShipmentCnt10,
            this.Ttl_ShipmentCnt11,
            this.Ttl_ShipmentCnt12,
            this.Ttl_Ave_ShipmentCnt,
            this.Ttl_Sum_ShipmentCnt,
            this.Ttl_ArrivalCnt1,
            this.Ttl_ArrivalCnt2,
            this.Ttl_ArrivalCnt3,
            this.Ttl_ArrivalCnt4,
            this.Ttl_ArrivalCnt5,
            this.Ttl_ArrivalCnt6,
            this.Ttl_ArrivalCnt7,
            this.Ttl_ArrivalCnt8,
            this.Ttl_ArrivalCnt9,
            this.Ttl_ArrivalCnt10,
            this.Ttl_ArrivalCnt11,
            this.Ttl_ArrivalCnt12,
            this.Ttl_Ave_ArrivalCnt,
            this.Ttl_Sum_ArrivalCnt});
            this.GrandTotalFooter.Height = 0.4777778F;
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
            this.ALLTOTALTITLE.Height = 0.25F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 0.9375F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03125F;
            this.ALLTOTALTITLE.Width = 1F;
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
            // Ttl_ShipmentCnt1
            // 
            this.Ttl_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Ttl_ShipmentCnt1.Height = 0.1565F;
            this.Ttl_ShipmentCnt1.Left = 3.5625F;
            this.Ttl_ShipmentCnt1.MultiLine = false;
            this.Ttl_ShipmentCnt1.Name = "Ttl_ShipmentCnt1";
            this.Ttl_ShipmentCnt1.OutputFormat = resources.GetString("Ttl_ShipmentCnt1.OutputFormat");
            this.Ttl_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt1.Text = "123,456";
            this.Ttl_ShipmentCnt1.Top = 0.0625F;
            this.Ttl_ShipmentCnt1.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt2
            // 
            this.Ttl_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Ttl_ShipmentCnt2.Height = 0.1565F;
            this.Ttl_ShipmentCnt2.Left = 4.0625F;
            this.Ttl_ShipmentCnt2.MultiLine = false;
            this.Ttl_ShipmentCnt2.Name = "Ttl_ShipmentCnt2";
            this.Ttl_ShipmentCnt2.OutputFormat = resources.GetString("Ttl_ShipmentCnt2.OutputFormat");
            this.Ttl_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt2.Text = "123,456";
            this.Ttl_ShipmentCnt2.Top = 0.0625F;
            this.Ttl_ShipmentCnt2.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt3
            // 
            this.Ttl_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Ttl_ShipmentCnt3.Height = 0.1565F;
            this.Ttl_ShipmentCnt3.Left = 4.5625F;
            this.Ttl_ShipmentCnt3.MultiLine = false;
            this.Ttl_ShipmentCnt3.Name = "Ttl_ShipmentCnt3";
            this.Ttl_ShipmentCnt3.OutputFormat = resources.GetString("Ttl_ShipmentCnt3.OutputFormat");
            this.Ttl_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt3.Text = "123,456";
            this.Ttl_ShipmentCnt3.Top = 0.0625F;
            this.Ttl_ShipmentCnt3.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt4
            // 
            this.Ttl_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Ttl_ShipmentCnt4.Height = 0.1565F;
            this.Ttl_ShipmentCnt4.Left = 5.0625F;
            this.Ttl_ShipmentCnt4.MultiLine = false;
            this.Ttl_ShipmentCnt4.Name = "Ttl_ShipmentCnt4";
            this.Ttl_ShipmentCnt4.OutputFormat = resources.GetString("Ttl_ShipmentCnt4.OutputFormat");
            this.Ttl_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt4.Text = "123,456";
            this.Ttl_ShipmentCnt4.Top = 0.0625F;
            this.Ttl_ShipmentCnt4.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt5
            // 
            this.Ttl_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Ttl_ShipmentCnt5.Height = 0.1565F;
            this.Ttl_ShipmentCnt5.Left = 5.5625F;
            this.Ttl_ShipmentCnt5.MultiLine = false;
            this.Ttl_ShipmentCnt5.Name = "Ttl_ShipmentCnt5";
            this.Ttl_ShipmentCnt5.OutputFormat = resources.GetString("Ttl_ShipmentCnt5.OutputFormat");
            this.Ttl_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt5.Text = "123,456";
            this.Ttl_ShipmentCnt5.Top = 0.0625F;
            this.Ttl_ShipmentCnt5.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt6
            // 
            this.Ttl_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Ttl_ShipmentCnt6.Height = 0.1565F;
            this.Ttl_ShipmentCnt6.Left = 6.0625F;
            this.Ttl_ShipmentCnt6.MultiLine = false;
            this.Ttl_ShipmentCnt6.Name = "Ttl_ShipmentCnt6";
            this.Ttl_ShipmentCnt6.OutputFormat = resources.GetString("Ttl_ShipmentCnt6.OutputFormat");
            this.Ttl_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt6.Text = "123,456";
            this.Ttl_ShipmentCnt6.Top = 0.0625F;
            this.Ttl_ShipmentCnt6.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt7
            // 
            this.Ttl_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Ttl_ShipmentCnt7.Height = 0.1565F;
            this.Ttl_ShipmentCnt7.Left = 6.5625F;
            this.Ttl_ShipmentCnt7.MultiLine = false;
            this.Ttl_ShipmentCnt7.Name = "Ttl_ShipmentCnt7";
            this.Ttl_ShipmentCnt7.OutputFormat = resources.GetString("Ttl_ShipmentCnt7.OutputFormat");
            this.Ttl_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt7.Text = "123,456";
            this.Ttl_ShipmentCnt7.Top = 0.0625F;
            this.Ttl_ShipmentCnt7.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt8
            // 
            this.Ttl_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Ttl_ShipmentCnt8.Height = 0.1565F;
            this.Ttl_ShipmentCnt8.Left = 7.0625F;
            this.Ttl_ShipmentCnt8.MultiLine = false;
            this.Ttl_ShipmentCnt8.Name = "Ttl_ShipmentCnt8";
            this.Ttl_ShipmentCnt8.OutputFormat = resources.GetString("Ttl_ShipmentCnt8.OutputFormat");
            this.Ttl_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt8.Text = "123,456";
            this.Ttl_ShipmentCnt8.Top = 0.0625F;
            this.Ttl_ShipmentCnt8.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt9
            // 
            this.Ttl_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Ttl_ShipmentCnt9.Height = 0.1565F;
            this.Ttl_ShipmentCnt9.Left = 7.5625F;
            this.Ttl_ShipmentCnt9.MultiLine = false;
            this.Ttl_ShipmentCnt9.Name = "Ttl_ShipmentCnt9";
            this.Ttl_ShipmentCnt9.OutputFormat = resources.GetString("Ttl_ShipmentCnt9.OutputFormat");
            this.Ttl_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt9.Text = "123,456";
            this.Ttl_ShipmentCnt9.Top = 0.0625F;
            this.Ttl_ShipmentCnt9.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt10
            // 
            this.Ttl_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Ttl_ShipmentCnt10.Height = 0.1565F;
            this.Ttl_ShipmentCnt10.Left = 8.0625F;
            this.Ttl_ShipmentCnt10.MultiLine = false;
            this.Ttl_ShipmentCnt10.Name = "Ttl_ShipmentCnt10";
            this.Ttl_ShipmentCnt10.OutputFormat = resources.GetString("Ttl_ShipmentCnt10.OutputFormat");
            this.Ttl_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt10.Text = "123,456";
            this.Ttl_ShipmentCnt10.Top = 0.0625F;
            this.Ttl_ShipmentCnt10.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt11
            // 
            this.Ttl_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Ttl_ShipmentCnt11.Height = 0.1565F;
            this.Ttl_ShipmentCnt11.Left = 8.5625F;
            this.Ttl_ShipmentCnt11.MultiLine = false;
            this.Ttl_ShipmentCnt11.Name = "Ttl_ShipmentCnt11";
            this.Ttl_ShipmentCnt11.OutputFormat = resources.GetString("Ttl_ShipmentCnt11.OutputFormat");
            this.Ttl_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt11.Text = "123,456";
            this.Ttl_ShipmentCnt11.Top = 0.0625F;
            this.Ttl_ShipmentCnt11.Width = 0.5F;
            // 
            // Ttl_ShipmentCnt12
            // 
            this.Ttl_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Ttl_ShipmentCnt12.Height = 0.1565F;
            this.Ttl_ShipmentCnt12.Left = 9.0625F;
            this.Ttl_ShipmentCnt12.MultiLine = false;
            this.Ttl_ShipmentCnt12.Name = "Ttl_ShipmentCnt12";
            this.Ttl_ShipmentCnt12.OutputFormat = resources.GetString("Ttl_ShipmentCnt12.OutputFormat");
            this.Ttl_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt12.Text = "123,456";
            this.Ttl_ShipmentCnt12.Top = 0.0625F;
            this.Ttl_ShipmentCnt12.Width = 0.5F;
            // 
            // Ttl_Ave_ShipmentCnt
            // 
            this.Ttl_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Ttl_Ave_ShipmentCnt.Height = 0.1565F;
            this.Ttl_Ave_ShipmentCnt.Left = 9.5625F;
            this.Ttl_Ave_ShipmentCnt.MultiLine = false;
            this.Ttl_Ave_ShipmentCnt.Name = "Ttl_Ave_ShipmentCnt";
            this.Ttl_Ave_ShipmentCnt.OutputFormat = resources.GetString("Ttl_Ave_ShipmentCnt.OutputFormat");
            this.Ttl_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_Ave_ShipmentCnt.Text = "123,456";
            this.Ttl_Ave_ShipmentCnt.Top = 0.0625F;
            this.Ttl_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Ttl_Sum_ShipmentCnt
            // 
            this.Ttl_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Ttl_Sum_ShipmentCnt.Height = 0.1565F;
            this.Ttl_Sum_ShipmentCnt.Left = 10.0625F;
            this.Ttl_Sum_ShipmentCnt.MultiLine = false;
            this.Ttl_Sum_ShipmentCnt.Name = "Ttl_Sum_ShipmentCnt";
            this.Ttl_Sum_ShipmentCnt.OutputFormat = resources.GetString("Ttl_Sum_ShipmentCnt.OutputFormat");
            this.Ttl_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_Sum_ShipmentCnt.Text = "123,456,789";
            this.Ttl_Sum_ShipmentCnt.Top = 0.0625F;
            this.Ttl_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Ttl_ArrivalCnt1
            // 
            this.Ttl_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Ttl_ArrivalCnt1.Height = 0.1565F;
            this.Ttl_ArrivalCnt1.Left = 3.5625F;
            this.Ttl_ArrivalCnt1.MultiLine = false;
            this.Ttl_ArrivalCnt1.Name = "Ttl_ArrivalCnt1";
            this.Ttl_ArrivalCnt1.OutputFormat = resources.GetString("Ttl_ArrivalCnt1.OutputFormat");
            this.Ttl_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt1.Text = "123,456";
            this.Ttl_ArrivalCnt1.Top = 0.25F;
            this.Ttl_ArrivalCnt1.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt2
            // 
            this.Ttl_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Ttl_ArrivalCnt2.Height = 0.1565F;
            this.Ttl_ArrivalCnt2.Left = 4.0625F;
            this.Ttl_ArrivalCnt2.MultiLine = false;
            this.Ttl_ArrivalCnt2.Name = "Ttl_ArrivalCnt2";
            this.Ttl_ArrivalCnt2.OutputFormat = resources.GetString("Ttl_ArrivalCnt2.OutputFormat");
            this.Ttl_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt2.Text = "123,456";
            this.Ttl_ArrivalCnt2.Top = 0.25F;
            this.Ttl_ArrivalCnt2.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt3
            // 
            this.Ttl_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Ttl_ArrivalCnt3.Height = 0.1565F;
            this.Ttl_ArrivalCnt3.Left = 4.5625F;
            this.Ttl_ArrivalCnt3.MultiLine = false;
            this.Ttl_ArrivalCnt3.Name = "Ttl_ArrivalCnt3";
            this.Ttl_ArrivalCnt3.OutputFormat = resources.GetString("Ttl_ArrivalCnt3.OutputFormat");
            this.Ttl_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt3.Text = "123,456";
            this.Ttl_ArrivalCnt3.Top = 0.25F;
            this.Ttl_ArrivalCnt3.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt4
            // 
            this.Ttl_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Ttl_ArrivalCnt4.Height = 0.1565F;
            this.Ttl_ArrivalCnt4.Left = 5.0625F;
            this.Ttl_ArrivalCnt4.MultiLine = false;
            this.Ttl_ArrivalCnt4.Name = "Ttl_ArrivalCnt4";
            this.Ttl_ArrivalCnt4.OutputFormat = resources.GetString("Ttl_ArrivalCnt4.OutputFormat");
            this.Ttl_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt4.Text = "123,456";
            this.Ttl_ArrivalCnt4.Top = 0.25F;
            this.Ttl_ArrivalCnt4.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt5
            // 
            this.Ttl_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Ttl_ArrivalCnt5.Height = 0.1565F;
            this.Ttl_ArrivalCnt5.Left = 5.5625F;
            this.Ttl_ArrivalCnt5.MultiLine = false;
            this.Ttl_ArrivalCnt5.Name = "Ttl_ArrivalCnt5";
            this.Ttl_ArrivalCnt5.OutputFormat = resources.GetString("Ttl_ArrivalCnt5.OutputFormat");
            this.Ttl_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt5.Text = "123,456";
            this.Ttl_ArrivalCnt5.Top = 0.25F;
            this.Ttl_ArrivalCnt5.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt6
            // 
            this.Ttl_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Ttl_ArrivalCnt6.Height = 0.1565F;
            this.Ttl_ArrivalCnt6.Left = 6.0625F;
            this.Ttl_ArrivalCnt6.MultiLine = false;
            this.Ttl_ArrivalCnt6.Name = "Ttl_ArrivalCnt6";
            this.Ttl_ArrivalCnt6.OutputFormat = resources.GetString("Ttl_ArrivalCnt6.OutputFormat");
            this.Ttl_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt6.Text = "123,456";
            this.Ttl_ArrivalCnt6.Top = 0.25F;
            this.Ttl_ArrivalCnt6.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt7
            // 
            this.Ttl_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Ttl_ArrivalCnt7.Height = 0.1565F;
            this.Ttl_ArrivalCnt7.Left = 6.5625F;
            this.Ttl_ArrivalCnt7.MultiLine = false;
            this.Ttl_ArrivalCnt7.Name = "Ttl_ArrivalCnt7";
            this.Ttl_ArrivalCnt7.OutputFormat = resources.GetString("Ttl_ArrivalCnt7.OutputFormat");
            this.Ttl_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt7.Text = "123,456";
            this.Ttl_ArrivalCnt7.Top = 0.25F;
            this.Ttl_ArrivalCnt7.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt8
            // 
            this.Ttl_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Ttl_ArrivalCnt8.Height = 0.1565F;
            this.Ttl_ArrivalCnt8.Left = 7.0625F;
            this.Ttl_ArrivalCnt8.MultiLine = false;
            this.Ttl_ArrivalCnt8.Name = "Ttl_ArrivalCnt8";
            this.Ttl_ArrivalCnt8.OutputFormat = resources.GetString("Ttl_ArrivalCnt8.OutputFormat");
            this.Ttl_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt8.Text = "123,456";
            this.Ttl_ArrivalCnt8.Top = 0.25F;
            this.Ttl_ArrivalCnt8.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt9
            // 
            this.Ttl_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Ttl_ArrivalCnt9.Height = 0.1565F;
            this.Ttl_ArrivalCnt9.Left = 7.5625F;
            this.Ttl_ArrivalCnt9.MultiLine = false;
            this.Ttl_ArrivalCnt9.Name = "Ttl_ArrivalCnt9";
            this.Ttl_ArrivalCnt9.OutputFormat = resources.GetString("Ttl_ArrivalCnt9.OutputFormat");
            this.Ttl_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt9.Text = "123,456";
            this.Ttl_ArrivalCnt9.Top = 0.25F;
            this.Ttl_ArrivalCnt9.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt10
            // 
            this.Ttl_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Ttl_ArrivalCnt10.Height = 0.1565F;
            this.Ttl_ArrivalCnt10.Left = 8.0625F;
            this.Ttl_ArrivalCnt10.MultiLine = false;
            this.Ttl_ArrivalCnt10.Name = "Ttl_ArrivalCnt10";
            this.Ttl_ArrivalCnt10.OutputFormat = resources.GetString("Ttl_ArrivalCnt10.OutputFormat");
            this.Ttl_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt10.Text = "123,456";
            this.Ttl_ArrivalCnt10.Top = 0.25F;
            this.Ttl_ArrivalCnt10.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt11
            // 
            this.Ttl_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Ttl_ArrivalCnt11.Height = 0.1565F;
            this.Ttl_ArrivalCnt11.Left = 8.5625F;
            this.Ttl_ArrivalCnt11.MultiLine = false;
            this.Ttl_ArrivalCnt11.Name = "Ttl_ArrivalCnt11";
            this.Ttl_ArrivalCnt11.OutputFormat = resources.GetString("Ttl_ArrivalCnt11.OutputFormat");
            this.Ttl_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt11.Text = "123,456";
            this.Ttl_ArrivalCnt11.Top = 0.25F;
            this.Ttl_ArrivalCnt11.Width = 0.5F;
            // 
            // Ttl_ArrivalCnt12
            // 
            this.Ttl_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Ttl_ArrivalCnt12.Height = 0.1565F;
            this.Ttl_ArrivalCnt12.Left = 9.0625F;
            this.Ttl_ArrivalCnt12.MultiLine = false;
            this.Ttl_ArrivalCnt12.Name = "Ttl_ArrivalCnt12";
            this.Ttl_ArrivalCnt12.OutputFormat = resources.GetString("Ttl_ArrivalCnt12.OutputFormat");
            this.Ttl_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ArrivalCnt12.Text = "123,456";
            this.Ttl_ArrivalCnt12.Top = 0.25F;
            this.Ttl_ArrivalCnt12.Width = 0.5F;
            // 
            // Ttl_Ave_ArrivalCnt
            // 
            this.Ttl_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Ttl_Ave_ArrivalCnt.Height = 0.1565F;
            this.Ttl_Ave_ArrivalCnt.Left = 9.5625F;
            this.Ttl_Ave_ArrivalCnt.MultiLine = false;
            this.Ttl_Ave_ArrivalCnt.Name = "Ttl_Ave_ArrivalCnt";
            this.Ttl_Ave_ArrivalCnt.OutputFormat = resources.GetString("Ttl_Ave_ArrivalCnt.OutputFormat");
            this.Ttl_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_Ave_ArrivalCnt.Text = "123,456";
            this.Ttl_Ave_ArrivalCnt.Top = 0.25F;
            this.Ttl_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Ttl_Sum_ArrivalCnt
            // 
            this.Ttl_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Ttl_Sum_ArrivalCnt.Height = 0.1565F;
            this.Ttl_Sum_ArrivalCnt.Left = 10.0625F;
            this.Ttl_Sum_ArrivalCnt.MultiLine = false;
            this.Ttl_Sum_ArrivalCnt.Name = "Ttl_Sum_ArrivalCnt";
            this.Ttl_Sum_ArrivalCnt.OutputFormat = resources.GetString("Ttl_Sum_ArrivalCnt.OutputFormat");
            this.Ttl_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_Sum_ArrivalCnt.Text = "123,456,789";
            this.Ttl_Sum_ArrivalCnt.Top = 0.25F;
            this.Ttl_Sum_ArrivalCnt.Width = 0.6875F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.DataField = "Sort_WarehouseCode";
            this.WarehouseHeader.Height = 0F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.Wh_ShipmentCnt1,
            this.Wh_ShipmentCnt2,
            this.Wh_ShipmentCnt3,
            this.Wh_ShipmentCnt4,
            this.Wh_ShipmentCnt5,
            this.Wh_ShipmentCnt6,
            this.Wh_ShipmentCnt7,
            this.Wh_ShipmentCnt8,
            this.Wh_ShipmentCnt9,
            this.Wh_ShipmentCnt10,
            this.Wh_ShipmentCnt11,
            this.Wh_ShipmentCnt12,
            this.Wh_Ave_ShipmentCnt,
            this.Wh_Sum_ShipmentCnt,
            this.Wh_ArrivalCnt1,
            this.Wh_ArrivalCnt2,
            this.Wh_ArrivalCnt3,
            this.Wh_ArrivalCnt4,
            this.Wh_ArrivalCnt5,
            this.Wh_ArrivalCnt6,
            this.Wh_ArrivalCnt7,
            this.Wh_ArrivalCnt8,
            this.Wh_ArrivalCnt9,
            this.Wh_ArrivalCnt10,
            this.Wh_ArrivalCnt11,
            this.Wh_ArrivalCnt12,
            this.Wh_Ave_ArrivalCnt,
            this.Wh_Sum_ArrivalCnt});
            this.WarehouseFooter.Height = 0.4784722F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
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
            this.SECTOTALTITLE.Height = 0.25F;
            this.SECTOTALTITLE.Left = 0.9375F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "倉庫計";
            this.SECTOTALTITLE.Top = 0.03125F;
            this.SECTOTALTITLE.Width = 1F;
            // 
            // Wh_ShipmentCnt1
            // 
            this.Wh_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Wh_ShipmentCnt1.Height = 0.1565F;
            this.Wh_ShipmentCnt1.Left = 3.5625F;
            this.Wh_ShipmentCnt1.MultiLine = false;
            this.Wh_ShipmentCnt1.Name = "Wh_ShipmentCnt1";
            this.Wh_ShipmentCnt1.OutputFormat = resources.GetString("Wh_ShipmentCnt1.OutputFormat");
            this.Wh_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt1.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt1.Text = "123,456";
            this.Wh_ShipmentCnt1.Top = 0.0625F;
            this.Wh_ShipmentCnt1.Width = 0.5F;
            // 
            // Wh_ShipmentCnt2
            // 
            this.Wh_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Wh_ShipmentCnt2.Height = 0.1565F;
            this.Wh_ShipmentCnt2.Left = 4.0625F;
            this.Wh_ShipmentCnt2.MultiLine = false;
            this.Wh_ShipmentCnt2.Name = "Wh_ShipmentCnt2";
            this.Wh_ShipmentCnt2.OutputFormat = resources.GetString("Wh_ShipmentCnt2.OutputFormat");
            this.Wh_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt2.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt2.Text = "123,456";
            this.Wh_ShipmentCnt2.Top = 0.0625F;
            this.Wh_ShipmentCnt2.Width = 0.5F;
            // 
            // Wh_ShipmentCnt3
            // 
            this.Wh_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Wh_ShipmentCnt3.Height = 0.1565F;
            this.Wh_ShipmentCnt3.Left = 4.5625F;
            this.Wh_ShipmentCnt3.MultiLine = false;
            this.Wh_ShipmentCnt3.Name = "Wh_ShipmentCnt3";
            this.Wh_ShipmentCnt3.OutputFormat = resources.GetString("Wh_ShipmentCnt3.OutputFormat");
            this.Wh_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt3.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt3.Text = "123,456";
            this.Wh_ShipmentCnt3.Top = 0.0625F;
            this.Wh_ShipmentCnt3.Width = 0.5F;
            // 
            // Wh_ShipmentCnt4
            // 
            this.Wh_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Wh_ShipmentCnt4.Height = 0.1565F;
            this.Wh_ShipmentCnt4.Left = 5.0625F;
            this.Wh_ShipmentCnt4.MultiLine = false;
            this.Wh_ShipmentCnt4.Name = "Wh_ShipmentCnt4";
            this.Wh_ShipmentCnt4.OutputFormat = resources.GetString("Wh_ShipmentCnt4.OutputFormat");
            this.Wh_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt4.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt4.Text = "123,456";
            this.Wh_ShipmentCnt4.Top = 0.0625F;
            this.Wh_ShipmentCnt4.Width = 0.5F;
            // 
            // Wh_ShipmentCnt5
            // 
            this.Wh_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Wh_ShipmentCnt5.Height = 0.1565F;
            this.Wh_ShipmentCnt5.Left = 5.5625F;
            this.Wh_ShipmentCnt5.MultiLine = false;
            this.Wh_ShipmentCnt5.Name = "Wh_ShipmentCnt5";
            this.Wh_ShipmentCnt5.OutputFormat = resources.GetString("Wh_ShipmentCnt5.OutputFormat");
            this.Wh_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt5.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt5.Text = "123,456";
            this.Wh_ShipmentCnt5.Top = 0.0625F;
            this.Wh_ShipmentCnt5.Width = 0.5F;
            // 
            // Wh_ShipmentCnt6
            // 
            this.Wh_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Wh_ShipmentCnt6.Height = 0.1565F;
            this.Wh_ShipmentCnt6.Left = 6.0625F;
            this.Wh_ShipmentCnt6.MultiLine = false;
            this.Wh_ShipmentCnt6.Name = "Wh_ShipmentCnt6";
            this.Wh_ShipmentCnt6.OutputFormat = resources.GetString("Wh_ShipmentCnt6.OutputFormat");
            this.Wh_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt6.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt6.Text = "123,456";
            this.Wh_ShipmentCnt6.Top = 0.0625F;
            this.Wh_ShipmentCnt6.Width = 0.5F;
            // 
            // Wh_ShipmentCnt7
            // 
            this.Wh_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Wh_ShipmentCnt7.Height = 0.1565F;
            this.Wh_ShipmentCnt7.Left = 6.5625F;
            this.Wh_ShipmentCnt7.MultiLine = false;
            this.Wh_ShipmentCnt7.Name = "Wh_ShipmentCnt7";
            this.Wh_ShipmentCnt7.OutputFormat = resources.GetString("Wh_ShipmentCnt7.OutputFormat");
            this.Wh_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt7.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt7.Text = "123,456";
            this.Wh_ShipmentCnt7.Top = 0.0625F;
            this.Wh_ShipmentCnt7.Width = 0.5F;
            // 
            // Wh_ShipmentCnt8
            // 
            this.Wh_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Wh_ShipmentCnt8.Height = 0.1565F;
            this.Wh_ShipmentCnt8.Left = 7.0625F;
            this.Wh_ShipmentCnt8.MultiLine = false;
            this.Wh_ShipmentCnt8.Name = "Wh_ShipmentCnt8";
            this.Wh_ShipmentCnt8.OutputFormat = resources.GetString("Wh_ShipmentCnt8.OutputFormat");
            this.Wh_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt8.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt8.Text = "123,456";
            this.Wh_ShipmentCnt8.Top = 0.0625F;
            this.Wh_ShipmentCnt8.Width = 0.5F;
            // 
            // Wh_ShipmentCnt9
            // 
            this.Wh_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Wh_ShipmentCnt9.Height = 0.1565F;
            this.Wh_ShipmentCnt9.Left = 7.5625F;
            this.Wh_ShipmentCnt9.MultiLine = false;
            this.Wh_ShipmentCnt9.Name = "Wh_ShipmentCnt9";
            this.Wh_ShipmentCnt9.OutputFormat = resources.GetString("Wh_ShipmentCnt9.OutputFormat");
            this.Wh_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt9.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt9.Text = "123,456";
            this.Wh_ShipmentCnt9.Top = 0.0625F;
            this.Wh_ShipmentCnt9.Width = 0.5F;
            // 
            // Wh_ShipmentCnt10
            // 
            this.Wh_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Wh_ShipmentCnt10.Height = 0.1565F;
            this.Wh_ShipmentCnt10.Left = 8.0625F;
            this.Wh_ShipmentCnt10.MultiLine = false;
            this.Wh_ShipmentCnt10.Name = "Wh_ShipmentCnt10";
            this.Wh_ShipmentCnt10.OutputFormat = resources.GetString("Wh_ShipmentCnt10.OutputFormat");
            this.Wh_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt10.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt10.Text = "123,456";
            this.Wh_ShipmentCnt10.Top = 0.0625F;
            this.Wh_ShipmentCnt10.Width = 0.5F;
            // 
            // Wh_ShipmentCnt11
            // 
            this.Wh_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Wh_ShipmentCnt11.Height = 0.1565F;
            this.Wh_ShipmentCnt11.Left = 8.5625F;
            this.Wh_ShipmentCnt11.MultiLine = false;
            this.Wh_ShipmentCnt11.Name = "Wh_ShipmentCnt11";
            this.Wh_ShipmentCnt11.OutputFormat = resources.GetString("Wh_ShipmentCnt11.OutputFormat");
            this.Wh_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt11.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt11.Text = "123,456";
            this.Wh_ShipmentCnt11.Top = 0.0625F;
            this.Wh_ShipmentCnt11.Width = 0.5F;
            // 
            // Wh_ShipmentCnt12
            // 
            this.Wh_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Wh_ShipmentCnt12.Height = 0.1565F;
            this.Wh_ShipmentCnt12.Left = 9.0625F;
            this.Wh_ShipmentCnt12.MultiLine = false;
            this.Wh_ShipmentCnt12.Name = "Wh_ShipmentCnt12";
            this.Wh_ShipmentCnt12.OutputFormat = resources.GetString("Wh_ShipmentCnt12.OutputFormat");
            this.Wh_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt12.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt12.Text = "123,456";
            this.Wh_ShipmentCnt12.Top = 0.0625F;
            this.Wh_ShipmentCnt12.Width = 0.5F;
            // 
            // Wh_Ave_ShipmentCnt
            // 
            this.Wh_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Wh_Ave_ShipmentCnt.Height = 0.1565F;
            this.Wh_Ave_ShipmentCnt.Left = 9.5625F;
            this.Wh_Ave_ShipmentCnt.MultiLine = false;
            this.Wh_Ave_ShipmentCnt.Name = "Wh_Ave_ShipmentCnt";
            this.Wh_Ave_ShipmentCnt.OutputFormat = resources.GetString("Wh_Ave_ShipmentCnt.OutputFormat");
            this.Wh_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_Ave_ShipmentCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_Ave_ShipmentCnt.Text = "123,456";
            this.Wh_Ave_ShipmentCnt.Top = 0.0625F;
            this.Wh_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Wh_Sum_ShipmentCnt
            // 
            this.Wh_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Wh_Sum_ShipmentCnt.Height = 0.1565F;
            this.Wh_Sum_ShipmentCnt.Left = 10.0625F;
            this.Wh_Sum_ShipmentCnt.MultiLine = false;
            this.Wh_Sum_ShipmentCnt.Name = "Wh_Sum_ShipmentCnt";
            this.Wh_Sum_ShipmentCnt.OutputFormat = resources.GetString("Wh_Sum_ShipmentCnt.OutputFormat");
            this.Wh_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_Sum_ShipmentCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_Sum_ShipmentCnt.Text = "123,456,789";
            this.Wh_Sum_ShipmentCnt.Top = 0.0625F;
            this.Wh_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Wh_ArrivalCnt1
            // 
            this.Wh_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Wh_ArrivalCnt1.Height = 0.1565F;
            this.Wh_ArrivalCnt1.Left = 3.5625F;
            this.Wh_ArrivalCnt1.MultiLine = false;
            this.Wh_ArrivalCnt1.Name = "Wh_ArrivalCnt1";
            this.Wh_ArrivalCnt1.OutputFormat = resources.GetString("Wh_ArrivalCnt1.OutputFormat");
            this.Wh_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt1.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt1.Text = "123,456";
            this.Wh_ArrivalCnt1.Top = 0.25F;
            this.Wh_ArrivalCnt1.Width = 0.5F;
            // 
            // Wh_ArrivalCnt2
            // 
            this.Wh_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Wh_ArrivalCnt2.Height = 0.1565F;
            this.Wh_ArrivalCnt2.Left = 4.0625F;
            this.Wh_ArrivalCnt2.MultiLine = false;
            this.Wh_ArrivalCnt2.Name = "Wh_ArrivalCnt2";
            this.Wh_ArrivalCnt2.OutputFormat = resources.GetString("Wh_ArrivalCnt2.OutputFormat");
            this.Wh_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt2.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt2.Text = "123,456";
            this.Wh_ArrivalCnt2.Top = 0.25F;
            this.Wh_ArrivalCnt2.Width = 0.5F;
            // 
            // Wh_ArrivalCnt3
            // 
            this.Wh_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Wh_ArrivalCnt3.Height = 0.1565F;
            this.Wh_ArrivalCnt3.Left = 4.5625F;
            this.Wh_ArrivalCnt3.MultiLine = false;
            this.Wh_ArrivalCnt3.Name = "Wh_ArrivalCnt3";
            this.Wh_ArrivalCnt3.OutputFormat = resources.GetString("Wh_ArrivalCnt3.OutputFormat");
            this.Wh_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt3.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt3.Text = "123,456";
            this.Wh_ArrivalCnt3.Top = 0.25F;
            this.Wh_ArrivalCnt3.Width = 0.5F;
            // 
            // Wh_ArrivalCnt4
            // 
            this.Wh_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Wh_ArrivalCnt4.Height = 0.1565F;
            this.Wh_ArrivalCnt4.Left = 5.0625F;
            this.Wh_ArrivalCnt4.MultiLine = false;
            this.Wh_ArrivalCnt4.Name = "Wh_ArrivalCnt4";
            this.Wh_ArrivalCnt4.OutputFormat = resources.GetString("Wh_ArrivalCnt4.OutputFormat");
            this.Wh_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt4.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt4.Text = "123,456";
            this.Wh_ArrivalCnt4.Top = 0.25F;
            this.Wh_ArrivalCnt4.Width = 0.5F;
            // 
            // Wh_ArrivalCnt5
            // 
            this.Wh_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Wh_ArrivalCnt5.Height = 0.1565F;
            this.Wh_ArrivalCnt5.Left = 5.5625F;
            this.Wh_ArrivalCnt5.MultiLine = false;
            this.Wh_ArrivalCnt5.Name = "Wh_ArrivalCnt5";
            this.Wh_ArrivalCnt5.OutputFormat = resources.GetString("Wh_ArrivalCnt5.OutputFormat");
            this.Wh_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt5.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt5.Text = "123,456";
            this.Wh_ArrivalCnt5.Top = 0.25F;
            this.Wh_ArrivalCnt5.Width = 0.5F;
            // 
            // Wh_ArrivalCnt6
            // 
            this.Wh_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Wh_ArrivalCnt6.Height = 0.1565F;
            this.Wh_ArrivalCnt6.Left = 6.0625F;
            this.Wh_ArrivalCnt6.MultiLine = false;
            this.Wh_ArrivalCnt6.Name = "Wh_ArrivalCnt6";
            this.Wh_ArrivalCnt6.OutputFormat = resources.GetString("Wh_ArrivalCnt6.OutputFormat");
            this.Wh_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt6.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt6.Text = "123,456";
            this.Wh_ArrivalCnt6.Top = 0.25F;
            this.Wh_ArrivalCnt6.Width = 0.5F;
            // 
            // Wh_ArrivalCnt7
            // 
            this.Wh_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Wh_ArrivalCnt7.Height = 0.1565F;
            this.Wh_ArrivalCnt7.Left = 6.5625F;
            this.Wh_ArrivalCnt7.MultiLine = false;
            this.Wh_ArrivalCnt7.Name = "Wh_ArrivalCnt7";
            this.Wh_ArrivalCnt7.OutputFormat = resources.GetString("Wh_ArrivalCnt7.OutputFormat");
            this.Wh_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt7.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt7.Text = "123,456";
            this.Wh_ArrivalCnt7.Top = 0.25F;
            this.Wh_ArrivalCnt7.Width = 0.5F;
            // 
            // Wh_ArrivalCnt8
            // 
            this.Wh_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Wh_ArrivalCnt8.Height = 0.1565F;
            this.Wh_ArrivalCnt8.Left = 7.0625F;
            this.Wh_ArrivalCnt8.MultiLine = false;
            this.Wh_ArrivalCnt8.Name = "Wh_ArrivalCnt8";
            this.Wh_ArrivalCnt8.OutputFormat = resources.GetString("Wh_ArrivalCnt8.OutputFormat");
            this.Wh_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt8.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt8.Text = "123,456";
            this.Wh_ArrivalCnt8.Top = 0.25F;
            this.Wh_ArrivalCnt8.Width = 0.5F;
            // 
            // Wh_ArrivalCnt9
            // 
            this.Wh_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Wh_ArrivalCnt9.Height = 0.1565F;
            this.Wh_ArrivalCnt9.Left = 7.5625F;
            this.Wh_ArrivalCnt9.MultiLine = false;
            this.Wh_ArrivalCnt9.Name = "Wh_ArrivalCnt9";
            this.Wh_ArrivalCnt9.OutputFormat = resources.GetString("Wh_ArrivalCnt9.OutputFormat");
            this.Wh_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt9.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt9.Text = "123,456";
            this.Wh_ArrivalCnt9.Top = 0.25F;
            this.Wh_ArrivalCnt9.Width = 0.5F;
            // 
            // Wh_ArrivalCnt10
            // 
            this.Wh_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Wh_ArrivalCnt10.Height = 0.1565F;
            this.Wh_ArrivalCnt10.Left = 8.0625F;
            this.Wh_ArrivalCnt10.MultiLine = false;
            this.Wh_ArrivalCnt10.Name = "Wh_ArrivalCnt10";
            this.Wh_ArrivalCnt10.OutputFormat = resources.GetString("Wh_ArrivalCnt10.OutputFormat");
            this.Wh_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt10.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt10.Text = "123,456";
            this.Wh_ArrivalCnt10.Top = 0.25F;
            this.Wh_ArrivalCnt10.Width = 0.5F;
            // 
            // Wh_ArrivalCnt11
            // 
            this.Wh_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Wh_ArrivalCnt11.Height = 0.1565F;
            this.Wh_ArrivalCnt11.Left = 8.5625F;
            this.Wh_ArrivalCnt11.MultiLine = false;
            this.Wh_ArrivalCnt11.Name = "Wh_ArrivalCnt11";
            this.Wh_ArrivalCnt11.OutputFormat = resources.GetString("Wh_ArrivalCnt11.OutputFormat");
            this.Wh_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt11.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt11.Text = "123,456";
            this.Wh_ArrivalCnt11.Top = 0.25F;
            this.Wh_ArrivalCnt11.Width = 0.5F;
            // 
            // Wh_ArrivalCnt12
            // 
            this.Wh_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Wh_ArrivalCnt12.Height = 0.1565F;
            this.Wh_ArrivalCnt12.Left = 9.0625F;
            this.Wh_ArrivalCnt12.MultiLine = false;
            this.Wh_ArrivalCnt12.Name = "Wh_ArrivalCnt12";
            this.Wh_ArrivalCnt12.OutputFormat = resources.GetString("Wh_ArrivalCnt12.OutputFormat");
            this.Wh_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ArrivalCnt12.SummaryGroup = "WarehouseHeader";
            this.Wh_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ArrivalCnt12.Text = "123,456";
            this.Wh_ArrivalCnt12.Top = 0.25F;
            this.Wh_ArrivalCnt12.Width = 0.5F;
            // 
            // Wh_Ave_ArrivalCnt
            // 
            this.Wh_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Wh_Ave_ArrivalCnt.Height = 0.1565F;
            this.Wh_Ave_ArrivalCnt.Left = 9.5625F;
            this.Wh_Ave_ArrivalCnt.MultiLine = false;
            this.Wh_Ave_ArrivalCnt.Name = "Wh_Ave_ArrivalCnt";
            this.Wh_Ave_ArrivalCnt.OutputFormat = resources.GetString("Wh_Ave_ArrivalCnt.OutputFormat");
            this.Wh_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_Ave_ArrivalCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_Ave_ArrivalCnt.Text = "123,456";
            this.Wh_Ave_ArrivalCnt.Top = 0.25F;
            this.Wh_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Wh_Sum_ArrivalCnt
            // 
            this.Wh_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Wh_Sum_ArrivalCnt.Height = 0.1565F;
            this.Wh_Sum_ArrivalCnt.Left = 10.0625F;
            this.Wh_Sum_ArrivalCnt.MultiLine = false;
            this.Wh_Sum_ArrivalCnt.Name = "Wh_Sum_ArrivalCnt";
            this.Wh_Sum_ArrivalCnt.OutputFormat = resources.GetString("Wh_Sum_ArrivalCnt.OutputFormat");
            this.Wh_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_Sum_ArrivalCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_Sum_ArrivalCnt.Text = "123,456,789";
            this.Wh_Sum_ArrivalCnt.Top = 0.25F;
            this.Wh_Sum_ArrivalCnt.Width = 0.6875F;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.CanShrink = true;
            this.CustomerHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseCode,
            this.WarehouseName,
            this.MakerName,
            this.GoodsMakerCd,
            this.Line3});
            this.CustomerHeader.DataField = "Sort_CustomerCode";
            this.CustomerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.CustomerHeader.Height = 0.25F;
            this.CustomerHeader.KeepTogether = true;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.CustomerHeader.Format += new System.EventHandler(this.CustomerHeader_Format);
            // 
            // WarehouseCode
            // 
            this.WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.DataField = "WarehouseCode";
            this.WarehouseCode.Height = 0.15625F;
            this.WarehouseCode.Left = 0F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.WarehouseCode.Text = "1234";
            this.WarehouseCode.Top = 0.0625F;
            this.WarehouseCode.Width = 0.3125F;
            // 
            // WarehouseName
            // 
            this.WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.DataField = "WarehouseName";
            this.WarehouseName.Height = 0.15625F;
            this.WarehouseName.Left = 0.3125F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OutputFormat = resources.GetString("WarehouseName.OutputFormat");
            this.WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseName.Text = "あいうえおかきくけこ";
            this.WarehouseName.Top = 0.0625F;
            this.WarehouseName.Width = 1.1875F;
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
            this.MakerName.DataField = "CustomerName";
            this.MakerName.Height = 0.15625F;
            this.MakerName.Left = 1.9375F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほ";
            this.MakerName.Top = 0.0625F;
            this.MakerName.Width = 3.375F;
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
            this.GoodsMakerCd.DataField = "CustomerCode";
            this.GoodsMakerCd.Height = 0.156F;
            this.GoodsMakerCd.Left = 1.5F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "123456";
            this.GoodsMakerCd.Top = 0.0625F;
            this.GoodsMakerCd.Width = 0.4375F;
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
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox3,
            this.Line,
            this.Cus_ShipmentCnt1,
            this.Cus_ShipmentCnt2,
            this.Cus_ShipmentCnt3,
            this.Cus_ShipmentCnt4,
            this.Cus_ShipmentCnt5,
            this.Cus_ShipmentCnt6,
            this.Cus_ShipmentCnt7,
            this.Cus_ShipmentCnt8,
            this.Cus_ShipmentCnt9,
            this.Cus_ShipmentCnt10,
            this.Cus_ShipmentCnt11,
            this.Cus_ShipmentCnt12,
            this.Cus_Ave_ShipmentCnt,
            this.Cus_Sum_ShipmentCnt,
            this.Cus_ArrivalCnt1,
            this.Cus_ArrivalCnt2,
            this.Cus_ArrivalCnt3,
            this.Cus_ArrivalCnt4,
            this.Cus_ArrivalCnt5,
            this.Cus_ArrivalCnt6,
            this.Cus_ArrivalCnt7,
            this.Cus_ArrivalCnt8,
            this.Cus_ArrivalCnt9,
            this.Cus_ArrivalCnt10,
            this.Cus_ArrivalCnt11,
            this.Cus_ArrivalCnt12,
            this.Cus_Ave_ArrivalCnt,
            this.Cus_Sum_ArrivalCnt});
            this.CustomerFooter.Height = 0.478F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
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
            this.TextBox3.Height = 0.25F;
            this.TextBox3.Left = 0.9375F;
            this.TextBox3.MultiLine = false;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox3.Text = "仕入先計";
            this.TextBox3.Top = 0.031F;
            this.TextBox3.Width = 1F;
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
            this.Line.Width = 10.8125F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.8125F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // Cus_ShipmentCnt1
            // 
            this.Cus_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Cus_ShipmentCnt1.Height = 0.1565F;
            this.Cus_ShipmentCnt1.Left = 3.5625F;
            this.Cus_ShipmentCnt1.MultiLine = false;
            this.Cus_ShipmentCnt1.Name = "Cus_ShipmentCnt1";
            this.Cus_ShipmentCnt1.OutputFormat = resources.GetString("Cus_ShipmentCnt1.OutputFormat");
            this.Cus_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt1.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt1.Text = "123,456";
            this.Cus_ShipmentCnt1.Top = 0.0625F;
            this.Cus_ShipmentCnt1.Width = 0.5F;
            // 
            // Cus_ShipmentCnt2
            // 
            this.Cus_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Cus_ShipmentCnt2.Height = 0.1565F;
            this.Cus_ShipmentCnt2.Left = 4.0625F;
            this.Cus_ShipmentCnt2.MultiLine = false;
            this.Cus_ShipmentCnt2.Name = "Cus_ShipmentCnt2";
            this.Cus_ShipmentCnt2.OutputFormat = resources.GetString("Cus_ShipmentCnt2.OutputFormat");
            this.Cus_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt2.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt2.Text = "123,456";
            this.Cus_ShipmentCnt2.Top = 0.0625F;
            this.Cus_ShipmentCnt2.Width = 0.5F;
            // 
            // Cus_ShipmentCnt3
            // 
            this.Cus_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Cus_ShipmentCnt3.Height = 0.1565F;
            this.Cus_ShipmentCnt3.Left = 4.5625F;
            this.Cus_ShipmentCnt3.MultiLine = false;
            this.Cus_ShipmentCnt3.Name = "Cus_ShipmentCnt3";
            this.Cus_ShipmentCnt3.OutputFormat = resources.GetString("Cus_ShipmentCnt3.OutputFormat");
            this.Cus_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt3.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt3.Text = "123,456";
            this.Cus_ShipmentCnt3.Top = 0.0625F;
            this.Cus_ShipmentCnt3.Width = 0.5F;
            // 
            // Cus_ShipmentCnt4
            // 
            this.Cus_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Cus_ShipmentCnt4.Height = 0.1565F;
            this.Cus_ShipmentCnt4.Left = 5.0625F;
            this.Cus_ShipmentCnt4.MultiLine = false;
            this.Cus_ShipmentCnt4.Name = "Cus_ShipmentCnt4";
            this.Cus_ShipmentCnt4.OutputFormat = resources.GetString("Cus_ShipmentCnt4.OutputFormat");
            this.Cus_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt4.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt4.Text = "123,456";
            this.Cus_ShipmentCnt4.Top = 0.0625F;
            this.Cus_ShipmentCnt4.Width = 0.5F;
            // 
            // Cus_ShipmentCnt5
            // 
            this.Cus_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Cus_ShipmentCnt5.Height = 0.1565F;
            this.Cus_ShipmentCnt5.Left = 5.5625F;
            this.Cus_ShipmentCnt5.MultiLine = false;
            this.Cus_ShipmentCnt5.Name = "Cus_ShipmentCnt5";
            this.Cus_ShipmentCnt5.OutputFormat = resources.GetString("Cus_ShipmentCnt5.OutputFormat");
            this.Cus_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt5.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt5.Text = "123,456";
            this.Cus_ShipmentCnt5.Top = 0.0625F;
            this.Cus_ShipmentCnt5.Width = 0.5F;
            // 
            // Cus_ShipmentCnt6
            // 
            this.Cus_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Cus_ShipmentCnt6.Height = 0.1565F;
            this.Cus_ShipmentCnt6.Left = 6.0625F;
            this.Cus_ShipmentCnt6.MultiLine = false;
            this.Cus_ShipmentCnt6.Name = "Cus_ShipmentCnt6";
            this.Cus_ShipmentCnt6.OutputFormat = resources.GetString("Cus_ShipmentCnt6.OutputFormat");
            this.Cus_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt6.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt6.Text = "123,456";
            this.Cus_ShipmentCnt6.Top = 0.0625F;
            this.Cus_ShipmentCnt6.Width = 0.5F;
            // 
            // Cus_ShipmentCnt7
            // 
            this.Cus_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Cus_ShipmentCnt7.Height = 0.1565F;
            this.Cus_ShipmentCnt7.Left = 6.5625F;
            this.Cus_ShipmentCnt7.MultiLine = false;
            this.Cus_ShipmentCnt7.Name = "Cus_ShipmentCnt7";
            this.Cus_ShipmentCnt7.OutputFormat = resources.GetString("Cus_ShipmentCnt7.OutputFormat");
            this.Cus_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt7.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt7.Text = "123,456";
            this.Cus_ShipmentCnt7.Top = 0.0625F;
            this.Cus_ShipmentCnt7.Width = 0.5F;
            // 
            // Cus_ShipmentCnt8
            // 
            this.Cus_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Cus_ShipmentCnt8.Height = 0.1565F;
            this.Cus_ShipmentCnt8.Left = 7.0625F;
            this.Cus_ShipmentCnt8.MultiLine = false;
            this.Cus_ShipmentCnt8.Name = "Cus_ShipmentCnt8";
            this.Cus_ShipmentCnt8.OutputFormat = resources.GetString("Cus_ShipmentCnt8.OutputFormat");
            this.Cus_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt8.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt8.Text = "123,456";
            this.Cus_ShipmentCnt8.Top = 0.0625F;
            this.Cus_ShipmentCnt8.Width = 0.5F;
            // 
            // Cus_ShipmentCnt9
            // 
            this.Cus_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Cus_ShipmentCnt9.Height = 0.1565F;
            this.Cus_ShipmentCnt9.Left = 7.5625F;
            this.Cus_ShipmentCnt9.MultiLine = false;
            this.Cus_ShipmentCnt9.Name = "Cus_ShipmentCnt9";
            this.Cus_ShipmentCnt9.OutputFormat = resources.GetString("Cus_ShipmentCnt9.OutputFormat");
            this.Cus_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt9.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt9.Text = "123,456";
            this.Cus_ShipmentCnt9.Top = 0.0625F;
            this.Cus_ShipmentCnt9.Width = 0.5F;
            // 
            // Cus_ShipmentCnt10
            // 
            this.Cus_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Cus_ShipmentCnt10.Height = 0.1565F;
            this.Cus_ShipmentCnt10.Left = 8.0625F;
            this.Cus_ShipmentCnt10.MultiLine = false;
            this.Cus_ShipmentCnt10.Name = "Cus_ShipmentCnt10";
            this.Cus_ShipmentCnt10.OutputFormat = resources.GetString("Cus_ShipmentCnt10.OutputFormat");
            this.Cus_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt10.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt10.Text = "123,456";
            this.Cus_ShipmentCnt10.Top = 0.0625F;
            this.Cus_ShipmentCnt10.Width = 0.5F;
            // 
            // Cus_ShipmentCnt11
            // 
            this.Cus_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Cus_ShipmentCnt11.Height = 0.1565F;
            this.Cus_ShipmentCnt11.Left = 8.5625F;
            this.Cus_ShipmentCnt11.MultiLine = false;
            this.Cus_ShipmentCnt11.Name = "Cus_ShipmentCnt11";
            this.Cus_ShipmentCnt11.OutputFormat = resources.GetString("Cus_ShipmentCnt11.OutputFormat");
            this.Cus_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt11.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt11.Text = "123,456";
            this.Cus_ShipmentCnt11.Top = 0.0625F;
            this.Cus_ShipmentCnt11.Width = 0.5F;
            // 
            // Cus_ShipmentCnt12
            // 
            this.Cus_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Cus_ShipmentCnt12.Height = 0.1565F;
            this.Cus_ShipmentCnt12.Left = 9.0625F;
            this.Cus_ShipmentCnt12.MultiLine = false;
            this.Cus_ShipmentCnt12.Name = "Cus_ShipmentCnt12";
            this.Cus_ShipmentCnt12.OutputFormat = resources.GetString("Cus_ShipmentCnt12.OutputFormat");
            this.Cus_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ShipmentCnt12.SummaryGroup = "CustomerHeader";
            this.Cus_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ShipmentCnt12.Text = "123,456";
            this.Cus_ShipmentCnt12.Top = 0.0625F;
            this.Cus_ShipmentCnt12.Width = 0.5F;
            // 
            // Cus_Ave_ShipmentCnt
            // 
            this.Cus_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Cus_Ave_ShipmentCnt.Height = 0.1565F;
            this.Cus_Ave_ShipmentCnt.Left = 9.5625F;
            this.Cus_Ave_ShipmentCnt.MultiLine = false;
            this.Cus_Ave_ShipmentCnt.Name = "Cus_Ave_ShipmentCnt";
            this.Cus_Ave_ShipmentCnt.OutputFormat = resources.GetString("Cus_Ave_ShipmentCnt.OutputFormat");
            this.Cus_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_Ave_ShipmentCnt.SummaryGroup = "CustomerHeader";
            this.Cus_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_Ave_ShipmentCnt.Text = "123,456";
            this.Cus_Ave_ShipmentCnt.Top = 0.0625F;
            this.Cus_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Cus_Sum_ShipmentCnt
            // 
            this.Cus_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Cus_Sum_ShipmentCnt.Height = 0.1565F;
            this.Cus_Sum_ShipmentCnt.Left = 10.0625F;
            this.Cus_Sum_ShipmentCnt.MultiLine = false;
            this.Cus_Sum_ShipmentCnt.Name = "Cus_Sum_ShipmentCnt";
            this.Cus_Sum_ShipmentCnt.OutputFormat = resources.GetString("Cus_Sum_ShipmentCnt.OutputFormat");
            this.Cus_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_Sum_ShipmentCnt.SummaryGroup = "CustomerHeader";
            this.Cus_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_Sum_ShipmentCnt.Text = "123,456,789";
            this.Cus_Sum_ShipmentCnt.Top = 0.0625F;
            this.Cus_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Cus_ArrivalCnt1
            // 
            this.Cus_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Cus_ArrivalCnt1.Height = 0.1565F;
            this.Cus_ArrivalCnt1.Left = 3.5625F;
            this.Cus_ArrivalCnt1.MultiLine = false;
            this.Cus_ArrivalCnt1.Name = "Cus_ArrivalCnt1";
            this.Cus_ArrivalCnt1.OutputFormat = resources.GetString("Cus_ArrivalCnt1.OutputFormat");
            this.Cus_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt1.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt1.Text = "123,456";
            this.Cus_ArrivalCnt1.Top = 0.25F;
            this.Cus_ArrivalCnt1.Width = 0.5F;
            // 
            // Cus_ArrivalCnt2
            // 
            this.Cus_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Cus_ArrivalCnt2.Height = 0.1565F;
            this.Cus_ArrivalCnt2.Left = 4.0625F;
            this.Cus_ArrivalCnt2.MultiLine = false;
            this.Cus_ArrivalCnt2.Name = "Cus_ArrivalCnt2";
            this.Cus_ArrivalCnt2.OutputFormat = resources.GetString("Cus_ArrivalCnt2.OutputFormat");
            this.Cus_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt2.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt2.Text = "123,456";
            this.Cus_ArrivalCnt2.Top = 0.25F;
            this.Cus_ArrivalCnt2.Width = 0.5F;
            // 
            // Cus_ArrivalCnt3
            // 
            this.Cus_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Cus_ArrivalCnt3.Height = 0.1565F;
            this.Cus_ArrivalCnt3.Left = 4.5625F;
            this.Cus_ArrivalCnt3.MultiLine = false;
            this.Cus_ArrivalCnt3.Name = "Cus_ArrivalCnt3";
            this.Cus_ArrivalCnt3.OutputFormat = resources.GetString("Cus_ArrivalCnt3.OutputFormat");
            this.Cus_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt3.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt3.Text = "123,456";
            this.Cus_ArrivalCnt3.Top = 0.25F;
            this.Cus_ArrivalCnt3.Width = 0.5F;
            // 
            // Cus_ArrivalCnt4
            // 
            this.Cus_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Cus_ArrivalCnt4.Height = 0.1565F;
            this.Cus_ArrivalCnt4.Left = 5.0625F;
            this.Cus_ArrivalCnt4.MultiLine = false;
            this.Cus_ArrivalCnt4.Name = "Cus_ArrivalCnt4";
            this.Cus_ArrivalCnt4.OutputFormat = resources.GetString("Cus_ArrivalCnt4.OutputFormat");
            this.Cus_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt4.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt4.Text = "123,456";
            this.Cus_ArrivalCnt4.Top = 0.25F;
            this.Cus_ArrivalCnt4.Width = 0.5F;
            // 
            // Cus_ArrivalCnt5
            // 
            this.Cus_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Cus_ArrivalCnt5.Height = 0.1565F;
            this.Cus_ArrivalCnt5.Left = 5.5625F;
            this.Cus_ArrivalCnt5.MultiLine = false;
            this.Cus_ArrivalCnt5.Name = "Cus_ArrivalCnt5";
            this.Cus_ArrivalCnt5.OutputFormat = resources.GetString("Cus_ArrivalCnt5.OutputFormat");
            this.Cus_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt5.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt5.Text = "123,456";
            this.Cus_ArrivalCnt5.Top = 0.25F;
            this.Cus_ArrivalCnt5.Width = 0.5F;
            // 
            // Cus_ArrivalCnt6
            // 
            this.Cus_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Cus_ArrivalCnt6.Height = 0.1565F;
            this.Cus_ArrivalCnt6.Left = 6.0625F;
            this.Cus_ArrivalCnt6.MultiLine = false;
            this.Cus_ArrivalCnt6.Name = "Cus_ArrivalCnt6";
            this.Cus_ArrivalCnt6.OutputFormat = resources.GetString("Cus_ArrivalCnt6.OutputFormat");
            this.Cus_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt6.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt6.Text = "123,456";
            this.Cus_ArrivalCnt6.Top = 0.25F;
            this.Cus_ArrivalCnt6.Width = 0.5F;
            // 
            // Cus_ArrivalCnt7
            // 
            this.Cus_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Cus_ArrivalCnt7.Height = 0.1565F;
            this.Cus_ArrivalCnt7.Left = 6.5625F;
            this.Cus_ArrivalCnt7.MultiLine = false;
            this.Cus_ArrivalCnt7.Name = "Cus_ArrivalCnt7";
            this.Cus_ArrivalCnt7.OutputFormat = resources.GetString("Cus_ArrivalCnt7.OutputFormat");
            this.Cus_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt7.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt7.Text = "123,456";
            this.Cus_ArrivalCnt7.Top = 0.25F;
            this.Cus_ArrivalCnt7.Width = 0.5F;
            // 
            // Cus_ArrivalCnt8
            // 
            this.Cus_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Cus_ArrivalCnt8.Height = 0.1565F;
            this.Cus_ArrivalCnt8.Left = 7.0625F;
            this.Cus_ArrivalCnt8.MultiLine = false;
            this.Cus_ArrivalCnt8.Name = "Cus_ArrivalCnt8";
            this.Cus_ArrivalCnt8.OutputFormat = resources.GetString("Cus_ArrivalCnt8.OutputFormat");
            this.Cus_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt8.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt8.Text = "123,456";
            this.Cus_ArrivalCnt8.Top = 0.25F;
            this.Cus_ArrivalCnt8.Width = 0.5F;
            // 
            // Cus_ArrivalCnt9
            // 
            this.Cus_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Cus_ArrivalCnt9.Height = 0.1565F;
            this.Cus_ArrivalCnt9.Left = 7.5625F;
            this.Cus_ArrivalCnt9.MultiLine = false;
            this.Cus_ArrivalCnt9.Name = "Cus_ArrivalCnt9";
            this.Cus_ArrivalCnt9.OutputFormat = resources.GetString("Cus_ArrivalCnt9.OutputFormat");
            this.Cus_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt9.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt9.Text = "123,456";
            this.Cus_ArrivalCnt9.Top = 0.25F;
            this.Cus_ArrivalCnt9.Width = 0.5F;
            // 
            // Cus_ArrivalCnt10
            // 
            this.Cus_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Cus_ArrivalCnt10.Height = 0.1565F;
            this.Cus_ArrivalCnt10.Left = 8.0625F;
            this.Cus_ArrivalCnt10.MultiLine = false;
            this.Cus_ArrivalCnt10.Name = "Cus_ArrivalCnt10";
            this.Cus_ArrivalCnt10.OutputFormat = resources.GetString("Cus_ArrivalCnt10.OutputFormat");
            this.Cus_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt10.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt10.Text = "123,456";
            this.Cus_ArrivalCnt10.Top = 0.25F;
            this.Cus_ArrivalCnt10.Width = 0.5F;
            // 
            // Cus_ArrivalCnt11
            // 
            this.Cus_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Cus_ArrivalCnt11.Height = 0.1565F;
            this.Cus_ArrivalCnt11.Left = 8.5625F;
            this.Cus_ArrivalCnt11.MultiLine = false;
            this.Cus_ArrivalCnt11.Name = "Cus_ArrivalCnt11";
            this.Cus_ArrivalCnt11.OutputFormat = resources.GetString("Cus_ArrivalCnt11.OutputFormat");
            this.Cus_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt11.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt11.Text = "123,456";
            this.Cus_ArrivalCnt11.Top = 0.25F;
            this.Cus_ArrivalCnt11.Width = 0.5F;
            // 
            // Cus_ArrivalCnt12
            // 
            this.Cus_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Cus_ArrivalCnt12.Height = 0.1565F;
            this.Cus_ArrivalCnt12.Left = 9.0625F;
            this.Cus_ArrivalCnt12.MultiLine = false;
            this.Cus_ArrivalCnt12.Name = "Cus_ArrivalCnt12";
            this.Cus_ArrivalCnt12.OutputFormat = resources.GetString("Cus_ArrivalCnt12.OutputFormat");
            this.Cus_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_ArrivalCnt12.SummaryGroup = "CustomerHeader";
            this.Cus_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_ArrivalCnt12.Text = "123,456";
            this.Cus_ArrivalCnt12.Top = 0.25F;
            this.Cus_ArrivalCnt12.Width = 0.5F;
            // 
            // Cus_Ave_ArrivalCnt
            // 
            this.Cus_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Cus_Ave_ArrivalCnt.Height = 0.1565F;
            this.Cus_Ave_ArrivalCnt.Left = 9.5625F;
            this.Cus_Ave_ArrivalCnt.MultiLine = false;
            this.Cus_Ave_ArrivalCnt.Name = "Cus_Ave_ArrivalCnt";
            this.Cus_Ave_ArrivalCnt.OutputFormat = resources.GetString("Cus_Ave_ArrivalCnt.OutputFormat");
            this.Cus_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_Ave_ArrivalCnt.SummaryGroup = "CustomerHeader";
            this.Cus_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_Ave_ArrivalCnt.Text = "123,456";
            this.Cus_Ave_ArrivalCnt.Top = 0.25F;
            this.Cus_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Cus_Sum_ArrivalCnt
            // 
            this.Cus_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Cus_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Cus_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Cus_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Cus_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Cus_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Cus_Sum_ArrivalCnt.Height = 0.1565F;
            this.Cus_Sum_ArrivalCnt.Left = 10.0625F;
            this.Cus_Sum_ArrivalCnt.MultiLine = false;
            this.Cus_Sum_ArrivalCnt.Name = "Cus_Sum_ArrivalCnt";
            this.Cus_Sum_ArrivalCnt.OutputFormat = resources.GetString("Cus_Sum_ArrivalCnt.OutputFormat");
            this.Cus_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Cus_Sum_ArrivalCnt.SummaryGroup = "CustomerHeader";
            this.Cus_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Cus_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Cus_Sum_ArrivalCnt.Text = "123,456,789";
            this.Cus_Sum_ArrivalCnt.Top = 0.25F;
            this.Cus_Sum_ArrivalCnt.Width = 0.6875F;
            // 
            // GoodsMakerHeader
            // 
            this.GoodsMakerHeader.CanShrink = true;
            this.GoodsMakerHeader.DataField = "GoodsMakerCd";
            this.GoodsMakerHeader.Height = 0F;
            this.GoodsMakerHeader.Name = "GoodsMakerHeader";
            // 
            // GoodsMakerFooter
            // 
            this.GoodsMakerFooter.CanShrink = true;
            this.GoodsMakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.tb_SumTitle,
            this.Sum_ShipmentCnt1,
            this.Sum_ShipmentCnt2,
            this.Sum_ShipmentCnt3,
            this.Sum_ShipmentCnt4,
            this.Sum_ShipmentCnt5,
            this.Sum_ShipmentCnt6,
            this.Sum_ShipmentCnt7,
            this.Sum_ShipmentCnt8,
            this.Sum_ShipmentCnt9,
            this.Sum_ShipmentCnt10,
            this.Sum_ShipmentCnt11,
            this.Sum_ShipmentCnt12,
            this.Sum_Ave_ShipmentCnt,
            this.Sum_Sum_ShipmentCnt,
            this.Sum_ArrivalCnt1,
            this.Sum_ArrivalCnt2,
            this.Sum_ArrivalCnt3,
            this.Sum_ArrivalCnt4,
            this.Sum_ArrivalCnt5,
            this.Sum_ArrivalCnt6,
            this.Sum_ArrivalCnt7,
            this.Sum_ArrivalCnt8,
            this.Sum_ArrivalCnt9,
            this.Sum_ArrivalCnt10,
            this.Sum_ArrivalCnt11,
            this.Sum_ArrivalCnt12,
            this.Sum_Ave_ArrivalCnt,
            this.Sum_Sum_ArrivalCnt,
            this.textBox10,
            this.textBox11});
            this.GoodsMakerFooter.Height = 0.4784722F;
            this.GoodsMakerFooter.KeepTogether = true;
            this.GoodsMakerFooter.Name = "GoodsMakerFooter";
            // 
            // Line44
            // 
            this.Line44.Border.BottomColor = System.Drawing.Color.Black;
            this.Line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.LeftColor = System.Drawing.Color.Black;
            this.Line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.RightColor = System.Drawing.Color.Black;
            this.Line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.TopColor = System.Drawing.Color.Black;
            this.Line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Height = 0F;
            this.Line44.Left = 0F;
            this.Line44.LineWeight = 2F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 0F;
            this.Line44.Width = 10.8F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 10.8F;
            this.Line44.Y1 = 0F;
            this.Line44.Y2 = 0F;
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
            this.tb_SumTitle.Height = 0.25F;
            this.tb_SumTitle.Left = 0.9375F;
            this.tb_SumTitle.MultiLine = false;
            this.tb_SumTitle.Name = "tb_SumTitle";
            this.tb_SumTitle.OutputFormat = resources.GetString("tb_SumTitle.OutputFormat");
            this.tb_SumTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SumTitle.Text = "メーカー計";
            this.tb_SumTitle.Top = 0.031125F;
            this.tb_SumTitle.Width = 1F;
            // 
            // Sum_ShipmentCnt1
            // 
            this.Sum_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Sum_ShipmentCnt1.Height = 0.1565F;
            this.Sum_ShipmentCnt1.Left = 3.5625F;
            this.Sum_ShipmentCnt1.MultiLine = false;
            this.Sum_ShipmentCnt1.Name = "Sum_ShipmentCnt1";
            this.Sum_ShipmentCnt1.OutputFormat = resources.GetString("Sum_ShipmentCnt1.OutputFormat");
            this.Sum_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt1.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt1.Text = "123,456";
            this.Sum_ShipmentCnt1.Top = 0.0625F;
            this.Sum_ShipmentCnt1.Width = 0.5F;
            // 
            // Sum_ShipmentCnt2
            // 
            this.Sum_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Sum_ShipmentCnt2.Height = 0.1565F;
            this.Sum_ShipmentCnt2.Left = 4.0625F;
            this.Sum_ShipmentCnt2.MultiLine = false;
            this.Sum_ShipmentCnt2.Name = "Sum_ShipmentCnt2";
            this.Sum_ShipmentCnt2.OutputFormat = resources.GetString("Sum_ShipmentCnt2.OutputFormat");
            this.Sum_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt2.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt2.Text = "123,456";
            this.Sum_ShipmentCnt2.Top = 0.0625F;
            this.Sum_ShipmentCnt2.Width = 0.5F;
            // 
            // Sum_ShipmentCnt3
            // 
            this.Sum_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Sum_ShipmentCnt3.Height = 0.1565F;
            this.Sum_ShipmentCnt3.Left = 4.5625F;
            this.Sum_ShipmentCnt3.MultiLine = false;
            this.Sum_ShipmentCnt3.Name = "Sum_ShipmentCnt3";
            this.Sum_ShipmentCnt3.OutputFormat = resources.GetString("Sum_ShipmentCnt3.OutputFormat");
            this.Sum_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt3.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt3.Text = "123,456";
            this.Sum_ShipmentCnt3.Top = 0.0625F;
            this.Sum_ShipmentCnt3.Width = 0.5F;
            // 
            // Sum_ShipmentCnt4
            // 
            this.Sum_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Sum_ShipmentCnt4.Height = 0.1565F;
            this.Sum_ShipmentCnt4.Left = 5.0625F;
            this.Sum_ShipmentCnt4.MultiLine = false;
            this.Sum_ShipmentCnt4.Name = "Sum_ShipmentCnt4";
            this.Sum_ShipmentCnt4.OutputFormat = resources.GetString("Sum_ShipmentCnt4.OutputFormat");
            this.Sum_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt4.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt4.Text = "123,456";
            this.Sum_ShipmentCnt4.Top = 0.0625F;
            this.Sum_ShipmentCnt4.Width = 0.5F;
            // 
            // Sum_ShipmentCnt5
            // 
            this.Sum_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Sum_ShipmentCnt5.Height = 0.1565F;
            this.Sum_ShipmentCnt5.Left = 5.5625F;
            this.Sum_ShipmentCnt5.MultiLine = false;
            this.Sum_ShipmentCnt5.Name = "Sum_ShipmentCnt5";
            this.Sum_ShipmentCnt5.OutputFormat = resources.GetString("Sum_ShipmentCnt5.OutputFormat");
            this.Sum_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt5.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt5.Text = "123,456";
            this.Sum_ShipmentCnt5.Top = 0.0625F;
            this.Sum_ShipmentCnt5.Width = 0.5F;
            // 
            // Sum_ShipmentCnt6
            // 
            this.Sum_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Sum_ShipmentCnt6.Height = 0.1565F;
            this.Sum_ShipmentCnt6.Left = 6.0625F;
            this.Sum_ShipmentCnt6.MultiLine = false;
            this.Sum_ShipmentCnt6.Name = "Sum_ShipmentCnt6";
            this.Sum_ShipmentCnt6.OutputFormat = resources.GetString("Sum_ShipmentCnt6.OutputFormat");
            this.Sum_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt6.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt6.Text = "123,456";
            this.Sum_ShipmentCnt6.Top = 0.0625F;
            this.Sum_ShipmentCnt6.Width = 0.5F;
            // 
            // Sum_ShipmentCnt7
            // 
            this.Sum_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Sum_ShipmentCnt7.Height = 0.1565F;
            this.Sum_ShipmentCnt7.Left = 6.5625F;
            this.Sum_ShipmentCnt7.MultiLine = false;
            this.Sum_ShipmentCnt7.Name = "Sum_ShipmentCnt7";
            this.Sum_ShipmentCnt7.OutputFormat = resources.GetString("Sum_ShipmentCnt7.OutputFormat");
            this.Sum_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt7.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt7.Text = "123,456";
            this.Sum_ShipmentCnt7.Top = 0.0625F;
            this.Sum_ShipmentCnt7.Width = 0.5F;
            // 
            // Sum_ShipmentCnt8
            // 
            this.Sum_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Sum_ShipmentCnt8.Height = 0.1565F;
            this.Sum_ShipmentCnt8.Left = 7.0625F;
            this.Sum_ShipmentCnt8.MultiLine = false;
            this.Sum_ShipmentCnt8.Name = "Sum_ShipmentCnt8";
            this.Sum_ShipmentCnt8.OutputFormat = resources.GetString("Sum_ShipmentCnt8.OutputFormat");
            this.Sum_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt8.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt8.Text = "123,456";
            this.Sum_ShipmentCnt8.Top = 0.0625F;
            this.Sum_ShipmentCnt8.Width = 0.5F;
            // 
            // Sum_ShipmentCnt9
            // 
            this.Sum_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Sum_ShipmentCnt9.Height = 0.1565F;
            this.Sum_ShipmentCnt9.Left = 7.5625F;
            this.Sum_ShipmentCnt9.MultiLine = false;
            this.Sum_ShipmentCnt9.Name = "Sum_ShipmentCnt9";
            this.Sum_ShipmentCnt9.OutputFormat = resources.GetString("Sum_ShipmentCnt9.OutputFormat");
            this.Sum_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt9.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt9.Text = "123,456";
            this.Sum_ShipmentCnt9.Top = 0.0625F;
            this.Sum_ShipmentCnt9.Width = 0.5F;
            // 
            // Sum_ShipmentCnt10
            // 
            this.Sum_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Sum_ShipmentCnt10.Height = 0.1565F;
            this.Sum_ShipmentCnt10.Left = 8.0625F;
            this.Sum_ShipmentCnt10.MultiLine = false;
            this.Sum_ShipmentCnt10.Name = "Sum_ShipmentCnt10";
            this.Sum_ShipmentCnt10.OutputFormat = resources.GetString("Sum_ShipmentCnt10.OutputFormat");
            this.Sum_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt10.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt10.Text = "123,456";
            this.Sum_ShipmentCnt10.Top = 0.0625F;
            this.Sum_ShipmentCnt10.Width = 0.5F;
            // 
            // Sum_ShipmentCnt11
            // 
            this.Sum_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Sum_ShipmentCnt11.Height = 0.1565F;
            this.Sum_ShipmentCnt11.Left = 8.5625F;
            this.Sum_ShipmentCnt11.MultiLine = false;
            this.Sum_ShipmentCnt11.Name = "Sum_ShipmentCnt11";
            this.Sum_ShipmentCnt11.OutputFormat = resources.GetString("Sum_ShipmentCnt11.OutputFormat");
            this.Sum_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt11.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt11.Text = "123,456";
            this.Sum_ShipmentCnt11.Top = 0.0625F;
            this.Sum_ShipmentCnt11.Width = 0.5F;
            // 
            // Sum_ShipmentCnt12
            // 
            this.Sum_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Sum_ShipmentCnt12.Height = 0.1565F;
            this.Sum_ShipmentCnt12.Left = 9.0625F;
            this.Sum_ShipmentCnt12.MultiLine = false;
            this.Sum_ShipmentCnt12.Name = "Sum_ShipmentCnt12";
            this.Sum_ShipmentCnt12.OutputFormat = resources.GetString("Sum_ShipmentCnt12.OutputFormat");
            this.Sum_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ShipmentCnt12.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ShipmentCnt12.Text = "123,456";
            this.Sum_ShipmentCnt12.Top = 0.0625F;
            this.Sum_ShipmentCnt12.Width = 0.5F;
            // 
            // Sum_Ave_ShipmentCnt
            // 
            this.Sum_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Sum_Ave_ShipmentCnt.Height = 0.1565F;
            this.Sum_Ave_ShipmentCnt.Left = 9.5625F;
            this.Sum_Ave_ShipmentCnt.MultiLine = false;
            this.Sum_Ave_ShipmentCnt.Name = "Sum_Ave_ShipmentCnt";
            this.Sum_Ave_ShipmentCnt.OutputFormat = resources.GetString("Sum_Ave_ShipmentCnt.OutputFormat");
            this.Sum_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_Ave_ShipmentCnt.SummaryGroup = "GoodsMakerHeader";
            this.Sum_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_Ave_ShipmentCnt.Text = "123,456";
            this.Sum_Ave_ShipmentCnt.Top = 0.0625F;
            this.Sum_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Sum_Sum_ShipmentCnt
            // 
            this.Sum_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Sum_Sum_ShipmentCnt.Height = 0.1565F;
            this.Sum_Sum_ShipmentCnt.Left = 10.0625F;
            this.Sum_Sum_ShipmentCnt.MultiLine = false;
            this.Sum_Sum_ShipmentCnt.Name = "Sum_Sum_ShipmentCnt";
            this.Sum_Sum_ShipmentCnt.OutputFormat = resources.GetString("Sum_Sum_ShipmentCnt.OutputFormat");
            this.Sum_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_Sum_ShipmentCnt.SummaryGroup = "GoodsMakerHeader";
            this.Sum_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_Sum_ShipmentCnt.Text = "123,456,789";
            this.Sum_Sum_ShipmentCnt.Top = 0.0625F;
            this.Sum_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Sum_ArrivalCnt1
            // 
            this.Sum_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Sum_ArrivalCnt1.Height = 0.1565F;
            this.Sum_ArrivalCnt1.Left = 3.5625F;
            this.Sum_ArrivalCnt1.MultiLine = false;
            this.Sum_ArrivalCnt1.Name = "Sum_ArrivalCnt1";
            this.Sum_ArrivalCnt1.OutputFormat = resources.GetString("Sum_ArrivalCnt1.OutputFormat");
            this.Sum_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt1.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt1.Text = "123,456";
            this.Sum_ArrivalCnt1.Top = 0.25F;
            this.Sum_ArrivalCnt1.Width = 0.5F;
            // 
            // Sum_ArrivalCnt2
            // 
            this.Sum_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Sum_ArrivalCnt2.Height = 0.1565F;
            this.Sum_ArrivalCnt2.Left = 4.0625F;
            this.Sum_ArrivalCnt2.MultiLine = false;
            this.Sum_ArrivalCnt2.Name = "Sum_ArrivalCnt2";
            this.Sum_ArrivalCnt2.OutputFormat = resources.GetString("Sum_ArrivalCnt2.OutputFormat");
            this.Sum_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt2.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt2.Text = "123,456";
            this.Sum_ArrivalCnt2.Top = 0.25F;
            this.Sum_ArrivalCnt2.Width = 0.5F;
            // 
            // Sum_ArrivalCnt3
            // 
            this.Sum_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Sum_ArrivalCnt3.Height = 0.1565F;
            this.Sum_ArrivalCnt3.Left = 4.5625F;
            this.Sum_ArrivalCnt3.MultiLine = false;
            this.Sum_ArrivalCnt3.Name = "Sum_ArrivalCnt3";
            this.Sum_ArrivalCnt3.OutputFormat = resources.GetString("Sum_ArrivalCnt3.OutputFormat");
            this.Sum_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt3.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt3.Text = "123,456";
            this.Sum_ArrivalCnt3.Top = 0.25F;
            this.Sum_ArrivalCnt3.Width = 0.5F;
            // 
            // Sum_ArrivalCnt4
            // 
            this.Sum_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Sum_ArrivalCnt4.Height = 0.1565F;
            this.Sum_ArrivalCnt4.Left = 5.0625F;
            this.Sum_ArrivalCnt4.MultiLine = false;
            this.Sum_ArrivalCnt4.Name = "Sum_ArrivalCnt4";
            this.Sum_ArrivalCnt4.OutputFormat = resources.GetString("Sum_ArrivalCnt4.OutputFormat");
            this.Sum_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt4.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt4.Text = "123,456";
            this.Sum_ArrivalCnt4.Top = 0.25F;
            this.Sum_ArrivalCnt4.Width = 0.5F;
            // 
            // Sum_ArrivalCnt5
            // 
            this.Sum_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Sum_ArrivalCnt5.Height = 0.1565F;
            this.Sum_ArrivalCnt5.Left = 5.5625F;
            this.Sum_ArrivalCnt5.MultiLine = false;
            this.Sum_ArrivalCnt5.Name = "Sum_ArrivalCnt5";
            this.Sum_ArrivalCnt5.OutputFormat = resources.GetString("Sum_ArrivalCnt5.OutputFormat");
            this.Sum_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt5.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt5.Text = "123,456";
            this.Sum_ArrivalCnt5.Top = 0.25F;
            this.Sum_ArrivalCnt5.Width = 0.5F;
            // 
            // Sum_ArrivalCnt6
            // 
            this.Sum_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Sum_ArrivalCnt6.Height = 0.1565F;
            this.Sum_ArrivalCnt6.Left = 6.0625F;
            this.Sum_ArrivalCnt6.MultiLine = false;
            this.Sum_ArrivalCnt6.Name = "Sum_ArrivalCnt6";
            this.Sum_ArrivalCnt6.OutputFormat = resources.GetString("Sum_ArrivalCnt6.OutputFormat");
            this.Sum_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt6.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt6.Text = "123,456";
            this.Sum_ArrivalCnt6.Top = 0.25F;
            this.Sum_ArrivalCnt6.Width = 0.5F;
            // 
            // Sum_ArrivalCnt7
            // 
            this.Sum_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Sum_ArrivalCnt7.Height = 0.1565F;
            this.Sum_ArrivalCnt7.Left = 6.5625F;
            this.Sum_ArrivalCnt7.MultiLine = false;
            this.Sum_ArrivalCnt7.Name = "Sum_ArrivalCnt7";
            this.Sum_ArrivalCnt7.OutputFormat = resources.GetString("Sum_ArrivalCnt7.OutputFormat");
            this.Sum_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt7.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt7.Text = "123,456";
            this.Sum_ArrivalCnt7.Top = 0.25F;
            this.Sum_ArrivalCnt7.Width = 0.5F;
            // 
            // Sum_ArrivalCnt8
            // 
            this.Sum_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Sum_ArrivalCnt8.Height = 0.1565F;
            this.Sum_ArrivalCnt8.Left = 7.0625F;
            this.Sum_ArrivalCnt8.MultiLine = false;
            this.Sum_ArrivalCnt8.Name = "Sum_ArrivalCnt8";
            this.Sum_ArrivalCnt8.OutputFormat = resources.GetString("Sum_ArrivalCnt8.OutputFormat");
            this.Sum_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt8.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt8.Text = "123,456";
            this.Sum_ArrivalCnt8.Top = 0.25F;
            this.Sum_ArrivalCnt8.Width = 0.5F;
            // 
            // Sum_ArrivalCnt9
            // 
            this.Sum_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Sum_ArrivalCnt9.Height = 0.1565F;
            this.Sum_ArrivalCnt9.Left = 7.5625F;
            this.Sum_ArrivalCnt9.MultiLine = false;
            this.Sum_ArrivalCnt9.Name = "Sum_ArrivalCnt9";
            this.Sum_ArrivalCnt9.OutputFormat = resources.GetString("Sum_ArrivalCnt9.OutputFormat");
            this.Sum_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt9.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt9.Text = "123,456";
            this.Sum_ArrivalCnt9.Top = 0.25F;
            this.Sum_ArrivalCnt9.Width = 0.5F;
            // 
            // Sum_ArrivalCnt10
            // 
            this.Sum_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Sum_ArrivalCnt10.Height = 0.1565F;
            this.Sum_ArrivalCnt10.Left = 8.0625F;
            this.Sum_ArrivalCnt10.MultiLine = false;
            this.Sum_ArrivalCnt10.Name = "Sum_ArrivalCnt10";
            this.Sum_ArrivalCnt10.OutputFormat = resources.GetString("Sum_ArrivalCnt10.OutputFormat");
            this.Sum_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt10.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt10.Text = "123,456";
            this.Sum_ArrivalCnt10.Top = 0.25F;
            this.Sum_ArrivalCnt10.Width = 0.5F;
            // 
            // Sum_ArrivalCnt11
            // 
            this.Sum_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Sum_ArrivalCnt11.Height = 0.1565F;
            this.Sum_ArrivalCnt11.Left = 8.5625F;
            this.Sum_ArrivalCnt11.MultiLine = false;
            this.Sum_ArrivalCnt11.Name = "Sum_ArrivalCnt11";
            this.Sum_ArrivalCnt11.OutputFormat = resources.GetString("Sum_ArrivalCnt11.OutputFormat");
            this.Sum_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt11.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt11.Text = "123,456";
            this.Sum_ArrivalCnt11.Top = 0.25F;
            this.Sum_ArrivalCnt11.Width = 0.5F;
            // 
            // Sum_ArrivalCnt12
            // 
            this.Sum_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Sum_ArrivalCnt12.Height = 0.1565F;
            this.Sum_ArrivalCnt12.Left = 9.0625F;
            this.Sum_ArrivalCnt12.MultiLine = false;
            this.Sum_ArrivalCnt12.Name = "Sum_ArrivalCnt12";
            this.Sum_ArrivalCnt12.OutputFormat = resources.GetString("Sum_ArrivalCnt12.OutputFormat");
            this.Sum_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_ArrivalCnt12.SummaryGroup = "GoodsMakerHeader";
            this.Sum_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ArrivalCnt12.Text = "123,456";
            this.Sum_ArrivalCnt12.Top = 0.25F;
            this.Sum_ArrivalCnt12.Width = 0.5F;
            // 
            // Sum_Ave_ArrivalCnt
            // 
            this.Sum_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Sum_Ave_ArrivalCnt.Height = 0.1565F;
            this.Sum_Ave_ArrivalCnt.Left = 9.5625F;
            this.Sum_Ave_ArrivalCnt.MultiLine = false;
            this.Sum_Ave_ArrivalCnt.Name = "Sum_Ave_ArrivalCnt";
            this.Sum_Ave_ArrivalCnt.OutputFormat = resources.GetString("Sum_Ave_ArrivalCnt.OutputFormat");
            this.Sum_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_Ave_ArrivalCnt.SummaryGroup = "GoodsMakerHeader";
            this.Sum_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_Ave_ArrivalCnt.Text = "123,456";
            this.Sum_Ave_ArrivalCnt.Top = 0.25F;
            this.Sum_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Sum_Sum_ArrivalCnt
            // 
            this.Sum_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Sum_Sum_ArrivalCnt.Height = 0.1565F;
            this.Sum_Sum_ArrivalCnt.Left = 10.0625F;
            this.Sum_Sum_ArrivalCnt.MultiLine = false;
            this.Sum_Sum_ArrivalCnt.Name = "Sum_Sum_ArrivalCnt";
            this.Sum_Sum_ArrivalCnt.OutputFormat = resources.GetString("Sum_Sum_ArrivalCnt.OutputFormat");
            this.Sum_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sum_Sum_ArrivalCnt.SummaryGroup = "GoodsMakerHeader";
            this.Sum_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_Sum_ArrivalCnt.Text = "123,456,789";
            this.Sum_Sum_ArrivalCnt.Top = 0.25F;
            this.Sum_Sum_ArrivalCnt.Width = 0.6875F;
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
            this.textBox10.DataField = "GoodsMakerCd";
            this.textBox10.Height = 0.1565F;
            this.textBox10.Left = 2F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.textBox10.Text = "1234";
            this.textBox10.Top = 0.0625F;
            this.textBox10.Width = 0.3125F;
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
            this.textBox11.DataField = "MakerName";
            this.textBox11.Height = 0.1565F;
            this.textBox11.Left = 2.3125F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox11.Text = "12345678901234567890";
            this.textBox11.Top = 0.0625F;
            this.textBox11.Width = 1.1875F;
            // 
            // LargeGoodsGanreHeader
            // 
            this.LargeGoodsGanreHeader.CanShrink = true;
            this.LargeGoodsGanreHeader.DataField = "Sort_LargeGoodsGanre";
            this.LargeGoodsGanreHeader.Height = 0F;
            this.LargeGoodsGanreHeader.Name = "LargeGoodsGanreHeader";
            // 
            // LargeGoodsGanreFooter
            // 
            this.LargeGoodsGanreFooter.CanShrink = true;
            this.LargeGoodsGanreFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.Gl_ShipmentCnt1,
            this.Gl_ShipmentCnt2,
            this.Gl_ShipmentCnt3,
            this.Gl_ShipmentCnt4,
            this.Gl_ShipmentCnt5,
            this.Gl_ShipmentCnt6,
            this.Gl_ShipmentCnt7,
            this.Gl_ShipmentCnt8,
            this.Gl_ShipmentCnt9,
            this.Gl_ShipmentCnt10,
            this.Gl_ShipmentCnt11,
            this.Gl_ShipmentCnt12,
            this.Gl_Ave_ShipmentCnt,
            this.Gl_Sum_ShipmentCnt,
            this.Gl_ArrivalCnt1,
            this.Gl_ArrivalCnt2,
            this.Gl_ArrivalCnt3,
            this.Gl_ArrivalCnt4,
            this.Gl_ArrivalCnt5,
            this.Gl_ArrivalCnt6,
            this.Gl_ArrivalCnt7,
            this.Gl_ArrivalCnt8,
            this.Gl_ArrivalCnt9,
            this.Gl_ArrivalCnt10,
            this.Gl_ArrivalCnt11,
            this.Gl_ArrivalCnt12,
            this.Gl_Ave_ArrivalCnt,
            this.Gl_Sum_ArrivalCnt,
            this.line4,
            this.textBox8,
            this.textBox9});
            this.LargeGoodsGanreFooter.Height = 0.478F;
            this.LargeGoodsGanreFooter.KeepTogether = true;
            this.LargeGoodsGanreFooter.Name = "LargeGoodsGanreFooter";
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
            this.textBox1.Height = 0.25F;
            this.textBox1.Left = 0.9375F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox1.Text = "商品大分類計";
            this.textBox1.Top = 0.031F;
            this.textBox1.Width = 1F;
            // 
            // Gl_ShipmentCnt1
            // 
            this.Gl_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Gl_ShipmentCnt1.Height = 0.1565F;
            this.Gl_ShipmentCnt1.Left = 3.5625F;
            this.Gl_ShipmentCnt1.MultiLine = false;
            this.Gl_ShipmentCnt1.Name = "Gl_ShipmentCnt1";
            this.Gl_ShipmentCnt1.OutputFormat = resources.GetString("Gl_ShipmentCnt1.OutputFormat");
            this.Gl_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt1.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt1.Text = "123,456";
            this.Gl_ShipmentCnt1.Top = 0.0625F;
            this.Gl_ShipmentCnt1.Width = 0.5F;
            // 
            // Gl_ShipmentCnt2
            // 
            this.Gl_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Gl_ShipmentCnt2.Height = 0.1565F;
            this.Gl_ShipmentCnt2.Left = 4.0625F;
            this.Gl_ShipmentCnt2.MultiLine = false;
            this.Gl_ShipmentCnt2.Name = "Gl_ShipmentCnt2";
            this.Gl_ShipmentCnt2.OutputFormat = resources.GetString("Gl_ShipmentCnt2.OutputFormat");
            this.Gl_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt2.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt2.Text = "123,456";
            this.Gl_ShipmentCnt2.Top = 0.0625F;
            this.Gl_ShipmentCnt2.Width = 0.5F;
            // 
            // Gl_ShipmentCnt3
            // 
            this.Gl_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Gl_ShipmentCnt3.Height = 0.1565F;
            this.Gl_ShipmentCnt3.Left = 4.5625F;
            this.Gl_ShipmentCnt3.MultiLine = false;
            this.Gl_ShipmentCnt3.Name = "Gl_ShipmentCnt3";
            this.Gl_ShipmentCnt3.OutputFormat = resources.GetString("Gl_ShipmentCnt3.OutputFormat");
            this.Gl_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt3.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt3.Text = "123,456";
            this.Gl_ShipmentCnt3.Top = 0.0625F;
            this.Gl_ShipmentCnt3.Width = 0.5F;
            // 
            // Gl_ShipmentCnt4
            // 
            this.Gl_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Gl_ShipmentCnt4.Height = 0.1565F;
            this.Gl_ShipmentCnt4.Left = 5.0625F;
            this.Gl_ShipmentCnt4.MultiLine = false;
            this.Gl_ShipmentCnt4.Name = "Gl_ShipmentCnt4";
            this.Gl_ShipmentCnt4.OutputFormat = resources.GetString("Gl_ShipmentCnt4.OutputFormat");
            this.Gl_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt4.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt4.Text = "123,456";
            this.Gl_ShipmentCnt4.Top = 0.0625F;
            this.Gl_ShipmentCnt4.Width = 0.5F;
            // 
            // Gl_ShipmentCnt5
            // 
            this.Gl_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Gl_ShipmentCnt5.Height = 0.1565F;
            this.Gl_ShipmentCnt5.Left = 5.5625F;
            this.Gl_ShipmentCnt5.MultiLine = false;
            this.Gl_ShipmentCnt5.Name = "Gl_ShipmentCnt5";
            this.Gl_ShipmentCnt5.OutputFormat = resources.GetString("Gl_ShipmentCnt5.OutputFormat");
            this.Gl_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt5.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt5.Text = "123,456";
            this.Gl_ShipmentCnt5.Top = 0.0625F;
            this.Gl_ShipmentCnt5.Width = 0.5F;
            // 
            // Gl_ShipmentCnt6
            // 
            this.Gl_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Gl_ShipmentCnt6.Height = 0.1565F;
            this.Gl_ShipmentCnt6.Left = 6.0625F;
            this.Gl_ShipmentCnt6.MultiLine = false;
            this.Gl_ShipmentCnt6.Name = "Gl_ShipmentCnt6";
            this.Gl_ShipmentCnt6.OutputFormat = resources.GetString("Gl_ShipmentCnt6.OutputFormat");
            this.Gl_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt6.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt6.Text = "123,456";
            this.Gl_ShipmentCnt6.Top = 0.0625F;
            this.Gl_ShipmentCnt6.Width = 0.5F;
            // 
            // Gl_ShipmentCnt7
            // 
            this.Gl_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Gl_ShipmentCnt7.Height = 0.1565F;
            this.Gl_ShipmentCnt7.Left = 6.5625F;
            this.Gl_ShipmentCnt7.MultiLine = false;
            this.Gl_ShipmentCnt7.Name = "Gl_ShipmentCnt7";
            this.Gl_ShipmentCnt7.OutputFormat = resources.GetString("Gl_ShipmentCnt7.OutputFormat");
            this.Gl_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt7.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt7.Text = "123,456";
            this.Gl_ShipmentCnt7.Top = 0.0625F;
            this.Gl_ShipmentCnt7.Width = 0.5F;
            // 
            // Gl_ShipmentCnt8
            // 
            this.Gl_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Gl_ShipmentCnt8.Height = 0.1565F;
            this.Gl_ShipmentCnt8.Left = 7.0625F;
            this.Gl_ShipmentCnt8.MultiLine = false;
            this.Gl_ShipmentCnt8.Name = "Gl_ShipmentCnt8";
            this.Gl_ShipmentCnt8.OutputFormat = resources.GetString("Gl_ShipmentCnt8.OutputFormat");
            this.Gl_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt8.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt8.Text = "123,456";
            this.Gl_ShipmentCnt8.Top = 0.0625F;
            this.Gl_ShipmentCnt8.Width = 0.5F;
            // 
            // Gl_ShipmentCnt9
            // 
            this.Gl_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Gl_ShipmentCnt9.Height = 0.1565F;
            this.Gl_ShipmentCnt9.Left = 7.5625F;
            this.Gl_ShipmentCnt9.MultiLine = false;
            this.Gl_ShipmentCnt9.Name = "Gl_ShipmentCnt9";
            this.Gl_ShipmentCnt9.OutputFormat = resources.GetString("Gl_ShipmentCnt9.OutputFormat");
            this.Gl_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt9.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt9.Text = "123,456";
            this.Gl_ShipmentCnt9.Top = 0.0625F;
            this.Gl_ShipmentCnt9.Width = 0.5F;
            // 
            // Gl_ShipmentCnt10
            // 
            this.Gl_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Gl_ShipmentCnt10.Height = 0.1565F;
            this.Gl_ShipmentCnt10.Left = 8.0625F;
            this.Gl_ShipmentCnt10.MultiLine = false;
            this.Gl_ShipmentCnt10.Name = "Gl_ShipmentCnt10";
            this.Gl_ShipmentCnt10.OutputFormat = resources.GetString("Gl_ShipmentCnt10.OutputFormat");
            this.Gl_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt10.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt10.Text = "123,456";
            this.Gl_ShipmentCnt10.Top = 0.0625F;
            this.Gl_ShipmentCnt10.Width = 0.5F;
            // 
            // Gl_ShipmentCnt11
            // 
            this.Gl_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Gl_ShipmentCnt11.Height = 0.1565F;
            this.Gl_ShipmentCnt11.Left = 8.5625F;
            this.Gl_ShipmentCnt11.MultiLine = false;
            this.Gl_ShipmentCnt11.Name = "Gl_ShipmentCnt11";
            this.Gl_ShipmentCnt11.OutputFormat = resources.GetString("Gl_ShipmentCnt11.OutputFormat");
            this.Gl_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt11.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt11.Text = "123,456";
            this.Gl_ShipmentCnt11.Top = 0.0625F;
            this.Gl_ShipmentCnt11.Width = 0.5F;
            // 
            // Gl_ShipmentCnt12
            // 
            this.Gl_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Gl_ShipmentCnt12.Height = 0.1565F;
            this.Gl_ShipmentCnt12.Left = 9.0625F;
            this.Gl_ShipmentCnt12.MultiLine = false;
            this.Gl_ShipmentCnt12.Name = "Gl_ShipmentCnt12";
            this.Gl_ShipmentCnt12.OutputFormat = resources.GetString("Gl_ShipmentCnt12.OutputFormat");
            this.Gl_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ShipmentCnt12.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ShipmentCnt12.Text = "123,456";
            this.Gl_ShipmentCnt12.Top = 0.0625F;
            this.Gl_ShipmentCnt12.Width = 0.5F;
            // 
            // Gl_Ave_ShipmentCnt
            // 
            this.Gl_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Gl_Ave_ShipmentCnt.Height = 0.1565F;
            this.Gl_Ave_ShipmentCnt.Left = 9.5625F;
            this.Gl_Ave_ShipmentCnt.MultiLine = false;
            this.Gl_Ave_ShipmentCnt.Name = "Gl_Ave_ShipmentCnt";
            this.Gl_Ave_ShipmentCnt.OutputFormat = resources.GetString("Gl_Ave_ShipmentCnt.OutputFormat");
            this.Gl_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_Ave_ShipmentCnt.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_Ave_ShipmentCnt.Text = "123,456";
            this.Gl_Ave_ShipmentCnt.Top = 0.0625F;
            this.Gl_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Gl_Sum_ShipmentCnt
            // 
            this.Gl_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Gl_Sum_ShipmentCnt.Height = 0.1565F;
            this.Gl_Sum_ShipmentCnt.Left = 10.0625F;
            this.Gl_Sum_ShipmentCnt.MultiLine = false;
            this.Gl_Sum_ShipmentCnt.Name = "Gl_Sum_ShipmentCnt";
            this.Gl_Sum_ShipmentCnt.OutputFormat = resources.GetString("Gl_Sum_ShipmentCnt.OutputFormat");
            this.Gl_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_Sum_ShipmentCnt.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_Sum_ShipmentCnt.Text = "123,456,789";
            this.Gl_Sum_ShipmentCnt.Top = 0.0625F;
            this.Gl_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Gl_ArrivalCnt1
            // 
            this.Gl_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Gl_ArrivalCnt1.Height = 0.1565F;
            this.Gl_ArrivalCnt1.Left = 3.5625F;
            this.Gl_ArrivalCnt1.MultiLine = false;
            this.Gl_ArrivalCnt1.Name = "Gl_ArrivalCnt1";
            this.Gl_ArrivalCnt1.OutputFormat = resources.GetString("Gl_ArrivalCnt1.OutputFormat");
            this.Gl_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt1.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt1.Text = "123,456";
            this.Gl_ArrivalCnt1.Top = 0.25F;
            this.Gl_ArrivalCnt1.Width = 0.5F;
            // 
            // Gl_ArrivalCnt2
            // 
            this.Gl_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Gl_ArrivalCnt2.Height = 0.1565F;
            this.Gl_ArrivalCnt2.Left = 4.0625F;
            this.Gl_ArrivalCnt2.MultiLine = false;
            this.Gl_ArrivalCnt2.Name = "Gl_ArrivalCnt2";
            this.Gl_ArrivalCnt2.OutputFormat = resources.GetString("Gl_ArrivalCnt2.OutputFormat");
            this.Gl_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt2.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt2.Text = "123,456";
            this.Gl_ArrivalCnt2.Top = 0.25F;
            this.Gl_ArrivalCnt2.Width = 0.5F;
            // 
            // Gl_ArrivalCnt3
            // 
            this.Gl_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Gl_ArrivalCnt3.Height = 0.1565F;
            this.Gl_ArrivalCnt3.Left = 4.5625F;
            this.Gl_ArrivalCnt3.MultiLine = false;
            this.Gl_ArrivalCnt3.Name = "Gl_ArrivalCnt3";
            this.Gl_ArrivalCnt3.OutputFormat = resources.GetString("Gl_ArrivalCnt3.OutputFormat");
            this.Gl_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt3.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt3.Text = "123,456";
            this.Gl_ArrivalCnt3.Top = 0.25F;
            this.Gl_ArrivalCnt3.Width = 0.5F;
            // 
            // Gl_ArrivalCnt4
            // 
            this.Gl_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Gl_ArrivalCnt4.Height = 0.1565F;
            this.Gl_ArrivalCnt4.Left = 5.0625F;
            this.Gl_ArrivalCnt4.MultiLine = false;
            this.Gl_ArrivalCnt4.Name = "Gl_ArrivalCnt4";
            this.Gl_ArrivalCnt4.OutputFormat = resources.GetString("Gl_ArrivalCnt4.OutputFormat");
            this.Gl_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt4.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt4.Text = "123,456";
            this.Gl_ArrivalCnt4.Top = 0.25F;
            this.Gl_ArrivalCnt4.Width = 0.5F;
            // 
            // Gl_ArrivalCnt5
            // 
            this.Gl_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Gl_ArrivalCnt5.Height = 0.1565F;
            this.Gl_ArrivalCnt5.Left = 5.5625F;
            this.Gl_ArrivalCnt5.MultiLine = false;
            this.Gl_ArrivalCnt5.Name = "Gl_ArrivalCnt5";
            this.Gl_ArrivalCnt5.OutputFormat = resources.GetString("Gl_ArrivalCnt5.OutputFormat");
            this.Gl_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt5.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt5.Text = "123,456";
            this.Gl_ArrivalCnt5.Top = 0.25F;
            this.Gl_ArrivalCnt5.Width = 0.5F;
            // 
            // Gl_ArrivalCnt6
            // 
            this.Gl_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Gl_ArrivalCnt6.Height = 0.1565F;
            this.Gl_ArrivalCnt6.Left = 6.0625F;
            this.Gl_ArrivalCnt6.MultiLine = false;
            this.Gl_ArrivalCnt6.Name = "Gl_ArrivalCnt6";
            this.Gl_ArrivalCnt6.OutputFormat = resources.GetString("Gl_ArrivalCnt6.OutputFormat");
            this.Gl_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt6.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt6.Text = "123,456";
            this.Gl_ArrivalCnt6.Top = 0.25F;
            this.Gl_ArrivalCnt6.Width = 0.5F;
            // 
            // Gl_ArrivalCnt7
            // 
            this.Gl_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Gl_ArrivalCnt7.Height = 0.1565F;
            this.Gl_ArrivalCnt7.Left = 6.5625F;
            this.Gl_ArrivalCnt7.MultiLine = false;
            this.Gl_ArrivalCnt7.Name = "Gl_ArrivalCnt7";
            this.Gl_ArrivalCnt7.OutputFormat = resources.GetString("Gl_ArrivalCnt7.OutputFormat");
            this.Gl_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt7.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt7.Text = "123,456";
            this.Gl_ArrivalCnt7.Top = 0.25F;
            this.Gl_ArrivalCnt7.Width = 0.5F;
            // 
            // Gl_ArrivalCnt8
            // 
            this.Gl_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Gl_ArrivalCnt8.Height = 0.1565F;
            this.Gl_ArrivalCnt8.Left = 7.0625F;
            this.Gl_ArrivalCnt8.MultiLine = false;
            this.Gl_ArrivalCnt8.Name = "Gl_ArrivalCnt8";
            this.Gl_ArrivalCnt8.OutputFormat = resources.GetString("Gl_ArrivalCnt8.OutputFormat");
            this.Gl_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt8.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt8.Text = "123,456";
            this.Gl_ArrivalCnt8.Top = 0.25F;
            this.Gl_ArrivalCnt8.Width = 0.5F;
            // 
            // Gl_ArrivalCnt9
            // 
            this.Gl_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Gl_ArrivalCnt9.Height = 0.1565F;
            this.Gl_ArrivalCnt9.Left = 7.5625F;
            this.Gl_ArrivalCnt9.MultiLine = false;
            this.Gl_ArrivalCnt9.Name = "Gl_ArrivalCnt9";
            this.Gl_ArrivalCnt9.OutputFormat = resources.GetString("Gl_ArrivalCnt9.OutputFormat");
            this.Gl_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt9.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt9.Text = "123,456";
            this.Gl_ArrivalCnt9.Top = 0.25F;
            this.Gl_ArrivalCnt9.Width = 0.5F;
            // 
            // Gl_ArrivalCnt10
            // 
            this.Gl_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Gl_ArrivalCnt10.Height = 0.1565F;
            this.Gl_ArrivalCnt10.Left = 8.0625F;
            this.Gl_ArrivalCnt10.MultiLine = false;
            this.Gl_ArrivalCnt10.Name = "Gl_ArrivalCnt10";
            this.Gl_ArrivalCnt10.OutputFormat = resources.GetString("Gl_ArrivalCnt10.OutputFormat");
            this.Gl_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt10.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt10.Text = "123,456";
            this.Gl_ArrivalCnt10.Top = 0.25F;
            this.Gl_ArrivalCnt10.Width = 0.5F;
            // 
            // Gl_ArrivalCnt11
            // 
            this.Gl_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Gl_ArrivalCnt11.Height = 0.1565F;
            this.Gl_ArrivalCnt11.Left = 8.5625F;
            this.Gl_ArrivalCnt11.MultiLine = false;
            this.Gl_ArrivalCnt11.Name = "Gl_ArrivalCnt11";
            this.Gl_ArrivalCnt11.OutputFormat = resources.GetString("Gl_ArrivalCnt11.OutputFormat");
            this.Gl_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt11.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt11.Text = "123,456";
            this.Gl_ArrivalCnt11.Top = 0.25F;
            this.Gl_ArrivalCnt11.Width = 0.5F;
            // 
            // Gl_ArrivalCnt12
            // 
            this.Gl_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Gl_ArrivalCnt12.Height = 0.1565F;
            this.Gl_ArrivalCnt12.Left = 9.0625F;
            this.Gl_ArrivalCnt12.MultiLine = false;
            this.Gl_ArrivalCnt12.Name = "Gl_ArrivalCnt12";
            this.Gl_ArrivalCnt12.OutputFormat = resources.GetString("Gl_ArrivalCnt12.OutputFormat");
            this.Gl_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_ArrivalCnt12.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_ArrivalCnt12.Text = "123,456";
            this.Gl_ArrivalCnt12.Top = 0.25F;
            this.Gl_ArrivalCnt12.Width = 0.5F;
            // 
            // Gl_Ave_ArrivalCnt
            // 
            this.Gl_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Gl_Ave_ArrivalCnt.Height = 0.1565F;
            this.Gl_Ave_ArrivalCnt.Left = 9.5625F;
            this.Gl_Ave_ArrivalCnt.MultiLine = false;
            this.Gl_Ave_ArrivalCnt.Name = "Gl_Ave_ArrivalCnt";
            this.Gl_Ave_ArrivalCnt.OutputFormat = resources.GetString("Gl_Ave_ArrivalCnt.OutputFormat");
            this.Gl_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_Ave_ArrivalCnt.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_Ave_ArrivalCnt.Text = "123,456";
            this.Gl_Ave_ArrivalCnt.Top = 0.25F;
            this.Gl_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Gl_Sum_ArrivalCnt
            // 
            this.Gl_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gl_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gl_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gl_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gl_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gl_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Gl_Sum_ArrivalCnt.Height = 0.1565F;
            this.Gl_Sum_ArrivalCnt.Left = 10.0625F;
            this.Gl_Sum_ArrivalCnt.MultiLine = false;
            this.Gl_Sum_ArrivalCnt.Name = "Gl_Sum_ArrivalCnt";
            this.Gl_Sum_ArrivalCnt.OutputFormat = resources.GetString("Gl_Sum_ArrivalCnt.OutputFormat");
            this.Gl_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gl_Sum_ArrivalCnt.SummaryGroup = "LargeGoodsGanreHeader";
            this.Gl_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gl_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gl_Sum_ArrivalCnt.Text = "123,456,789";
            this.Gl_Sum_ArrivalCnt.Top = 0.25F;
            this.Gl_Sum_ArrivalCnt.Width = 0.6875F;
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
            this.textBox8.DataField = "Sort_LargeGoodsGanre";
            this.textBox8.Height = 0.1565F;
            this.textBox8.Left = 2F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.textBox8.Text = "1234";
            this.textBox8.Top = 0.0625F;
            this.textBox8.Width = 0.3125F;
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
            this.textBox9.DataField = "LargeGoodsGanreName";
            this.textBox9.Height = 0.1565F;
            this.textBox9.Left = 2.3125F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox9.Text = "12345678901234567890";
            this.textBox9.Top = 0.0625F;
            this.textBox9.Width = 1.1875F;
            // 
            // MediumGoodsGanreHeader
            // 
            this.MediumGoodsGanreHeader.DataField = "Sort_MediumGoodsGanre";
            this.MediumGoodsGanreHeader.Height = 0F;
            this.MediumGoodsGanreHeader.Name = "MediumGoodsGanreHeader";
            // 
            // MediumGoodsGanreFooter
            // 
            this.MediumGoodsGanreFooter.CanShrink = true;
            this.MediumGoodsGanreFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox31,
            this.Gm_ShipmentCnt1,
            this.Gm_ShipmentCnt2,
            this.Gm_ShipmentCnt3,
            this.Gm_ShipmentCnt4,
            this.Gm_ShipmentCnt5,
            this.Gm_ShipmentCnt6,
            this.Gm_ShipmentCnt7,
            this.Gm_ShipmentCnt8,
            this.Gm_ShipmentCnt9,
            this.Gm_ShipmentCnt10,
            this.Gm_ShipmentCnt11,
            this.Gm_ShipmentCnt12,
            this.Gm_Ave_ShipmentCnt,
            this.Gm_Sum_ShipmentCnt,
            this.Gm_ArrivalCnt1,
            this.Gm_ArrivalCnt2,
            this.Gm_ArrivalCnt3,
            this.Gm_ArrivalCnt4,
            this.Gm_ArrivalCnt5,
            this.Gm_ArrivalCnt6,
            this.Gm_ArrivalCnt7,
            this.Gm_ArrivalCnt8,
            this.Gm_ArrivalCnt9,
            this.Gm_ArrivalCnt10,
            this.Gm_ArrivalCnt11,
            this.Gm_ArrivalCnt12,
            this.Gm_Ave_ArrivalCnt,
            this.Gm_Sum_ArrivalCnt,
            this.line5,
            this.textBox6,
            this.textBox7});
            this.MediumGoodsGanreFooter.Height = 0.478F;
            this.MediumGoodsGanreFooter.KeepTogether = true;
            this.MediumGoodsGanreFooter.Name = "MediumGoodsGanreFooter";
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
            this.textBox31.Height = 0.25F;
            this.textBox31.Left = 0.9375F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox31.Text = "商品中分類計";
            this.textBox31.Top = 0.031F;
            this.textBox31.Width = 1F;
            // 
            // Gm_ShipmentCnt1
            // 
            this.Gm_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Gm_ShipmentCnt1.Height = 0.1565F;
            this.Gm_ShipmentCnt1.Left = 3.5625F;
            this.Gm_ShipmentCnt1.MultiLine = false;
            this.Gm_ShipmentCnt1.Name = "Gm_ShipmentCnt1";
            this.Gm_ShipmentCnt1.OutputFormat = resources.GetString("Gm_ShipmentCnt1.OutputFormat");
            this.Gm_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt1.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt1.Text = "123,456";
            this.Gm_ShipmentCnt1.Top = 0.0625F;
            this.Gm_ShipmentCnt1.Width = 0.5F;
            // 
            // Gm_ShipmentCnt2
            // 
            this.Gm_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Gm_ShipmentCnt2.Height = 0.1565F;
            this.Gm_ShipmentCnt2.Left = 4.0625F;
            this.Gm_ShipmentCnt2.MultiLine = false;
            this.Gm_ShipmentCnt2.Name = "Gm_ShipmentCnt2";
            this.Gm_ShipmentCnt2.OutputFormat = resources.GetString("Gm_ShipmentCnt2.OutputFormat");
            this.Gm_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt2.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt2.Text = "123,456";
            this.Gm_ShipmentCnt2.Top = 0.0625F;
            this.Gm_ShipmentCnt2.Width = 0.5F;
            // 
            // Gm_ShipmentCnt3
            // 
            this.Gm_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Gm_ShipmentCnt3.Height = 0.1565F;
            this.Gm_ShipmentCnt3.Left = 4.5625F;
            this.Gm_ShipmentCnt3.MultiLine = false;
            this.Gm_ShipmentCnt3.Name = "Gm_ShipmentCnt3";
            this.Gm_ShipmentCnt3.OutputFormat = resources.GetString("Gm_ShipmentCnt3.OutputFormat");
            this.Gm_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt3.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt3.Text = "123,456";
            this.Gm_ShipmentCnt3.Top = 0.0625F;
            this.Gm_ShipmentCnt3.Width = 0.5F;
            // 
            // Gm_ShipmentCnt4
            // 
            this.Gm_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Gm_ShipmentCnt4.Height = 0.1565F;
            this.Gm_ShipmentCnt4.Left = 5.0625F;
            this.Gm_ShipmentCnt4.MultiLine = false;
            this.Gm_ShipmentCnt4.Name = "Gm_ShipmentCnt4";
            this.Gm_ShipmentCnt4.OutputFormat = resources.GetString("Gm_ShipmentCnt4.OutputFormat");
            this.Gm_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt4.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt4.Text = "123,456";
            this.Gm_ShipmentCnt4.Top = 0.0625F;
            this.Gm_ShipmentCnt4.Width = 0.5F;
            // 
            // Gm_ShipmentCnt5
            // 
            this.Gm_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Gm_ShipmentCnt5.Height = 0.1565F;
            this.Gm_ShipmentCnt5.Left = 5.5625F;
            this.Gm_ShipmentCnt5.MultiLine = false;
            this.Gm_ShipmentCnt5.Name = "Gm_ShipmentCnt5";
            this.Gm_ShipmentCnt5.OutputFormat = resources.GetString("Gm_ShipmentCnt5.OutputFormat");
            this.Gm_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt5.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt5.Text = "123,456";
            this.Gm_ShipmentCnt5.Top = 0.0625F;
            this.Gm_ShipmentCnt5.Width = 0.5F;
            // 
            // Gm_ShipmentCnt6
            // 
            this.Gm_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Gm_ShipmentCnt6.Height = 0.1565F;
            this.Gm_ShipmentCnt6.Left = 6.0625F;
            this.Gm_ShipmentCnt6.MultiLine = false;
            this.Gm_ShipmentCnt6.Name = "Gm_ShipmentCnt6";
            this.Gm_ShipmentCnt6.OutputFormat = resources.GetString("Gm_ShipmentCnt6.OutputFormat");
            this.Gm_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt6.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt6.Text = "123,456";
            this.Gm_ShipmentCnt6.Top = 0.0625F;
            this.Gm_ShipmentCnt6.Width = 0.5F;
            // 
            // Gm_ShipmentCnt7
            // 
            this.Gm_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Gm_ShipmentCnt7.Height = 0.1565F;
            this.Gm_ShipmentCnt7.Left = 6.5625F;
            this.Gm_ShipmentCnt7.MultiLine = false;
            this.Gm_ShipmentCnt7.Name = "Gm_ShipmentCnt7";
            this.Gm_ShipmentCnt7.OutputFormat = resources.GetString("Gm_ShipmentCnt7.OutputFormat");
            this.Gm_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt7.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt7.Text = "123,456";
            this.Gm_ShipmentCnt7.Top = 0.0625F;
            this.Gm_ShipmentCnt7.Width = 0.5F;
            // 
            // Gm_ShipmentCnt8
            // 
            this.Gm_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Gm_ShipmentCnt8.Height = 0.1565F;
            this.Gm_ShipmentCnt8.Left = 7.0625F;
            this.Gm_ShipmentCnt8.MultiLine = false;
            this.Gm_ShipmentCnt8.Name = "Gm_ShipmentCnt8";
            this.Gm_ShipmentCnt8.OutputFormat = resources.GetString("Gm_ShipmentCnt8.OutputFormat");
            this.Gm_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt8.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt8.Text = "123,456";
            this.Gm_ShipmentCnt8.Top = 0.0625F;
            this.Gm_ShipmentCnt8.Width = 0.5F;
            // 
            // Gm_ShipmentCnt9
            // 
            this.Gm_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Gm_ShipmentCnt9.Height = 0.1565F;
            this.Gm_ShipmentCnt9.Left = 7.5625F;
            this.Gm_ShipmentCnt9.MultiLine = false;
            this.Gm_ShipmentCnt9.Name = "Gm_ShipmentCnt9";
            this.Gm_ShipmentCnt9.OutputFormat = resources.GetString("Gm_ShipmentCnt9.OutputFormat");
            this.Gm_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt9.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt9.Text = "123,456";
            this.Gm_ShipmentCnt9.Top = 0.0625F;
            this.Gm_ShipmentCnt9.Width = 0.5F;
            // 
            // Gm_ShipmentCnt10
            // 
            this.Gm_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Gm_ShipmentCnt10.Height = 0.1565F;
            this.Gm_ShipmentCnt10.Left = 8.0625F;
            this.Gm_ShipmentCnt10.MultiLine = false;
            this.Gm_ShipmentCnt10.Name = "Gm_ShipmentCnt10";
            this.Gm_ShipmentCnt10.OutputFormat = resources.GetString("Gm_ShipmentCnt10.OutputFormat");
            this.Gm_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt10.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt10.Text = "123,456";
            this.Gm_ShipmentCnt10.Top = 0.0625F;
            this.Gm_ShipmentCnt10.Width = 0.5F;
            // 
            // Gm_ShipmentCnt11
            // 
            this.Gm_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Gm_ShipmentCnt11.Height = 0.1565F;
            this.Gm_ShipmentCnt11.Left = 8.5625F;
            this.Gm_ShipmentCnt11.MultiLine = false;
            this.Gm_ShipmentCnt11.Name = "Gm_ShipmentCnt11";
            this.Gm_ShipmentCnt11.OutputFormat = resources.GetString("Gm_ShipmentCnt11.OutputFormat");
            this.Gm_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt11.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt11.Text = "123,456";
            this.Gm_ShipmentCnt11.Top = 0.0625F;
            this.Gm_ShipmentCnt11.Width = 0.5F;
            // 
            // Gm_ShipmentCnt12
            // 
            this.Gm_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Gm_ShipmentCnt12.Height = 0.1565F;
            this.Gm_ShipmentCnt12.Left = 9.0625F;
            this.Gm_ShipmentCnt12.MultiLine = false;
            this.Gm_ShipmentCnt12.Name = "Gm_ShipmentCnt12";
            this.Gm_ShipmentCnt12.OutputFormat = resources.GetString("Gm_ShipmentCnt12.OutputFormat");
            this.Gm_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ShipmentCnt12.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ShipmentCnt12.Text = "123,456";
            this.Gm_ShipmentCnt12.Top = 0.0625F;
            this.Gm_ShipmentCnt12.Width = 0.5F;
            // 
            // Gm_Ave_ShipmentCnt
            // 
            this.Gm_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Gm_Ave_ShipmentCnt.Height = 0.1565F;
            this.Gm_Ave_ShipmentCnt.Left = 9.5625F;
            this.Gm_Ave_ShipmentCnt.MultiLine = false;
            this.Gm_Ave_ShipmentCnt.Name = "Gm_Ave_ShipmentCnt";
            this.Gm_Ave_ShipmentCnt.OutputFormat = resources.GetString("Gm_Ave_ShipmentCnt.OutputFormat");
            this.Gm_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_Ave_ShipmentCnt.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_Ave_ShipmentCnt.Text = "123,456";
            this.Gm_Ave_ShipmentCnt.Top = 0.0625F;
            this.Gm_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Gm_Sum_ShipmentCnt
            // 
            this.Gm_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Gm_Sum_ShipmentCnt.Height = 0.1565F;
            this.Gm_Sum_ShipmentCnt.Left = 10.0625F;
            this.Gm_Sum_ShipmentCnt.MultiLine = false;
            this.Gm_Sum_ShipmentCnt.Name = "Gm_Sum_ShipmentCnt";
            this.Gm_Sum_ShipmentCnt.OutputFormat = resources.GetString("Gm_Sum_ShipmentCnt.OutputFormat");
            this.Gm_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_Sum_ShipmentCnt.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_Sum_ShipmentCnt.Text = "123,456,789";
            this.Gm_Sum_ShipmentCnt.Top = 0.0625F;
            this.Gm_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Gm_ArrivalCnt1
            // 
            this.Gm_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Gm_ArrivalCnt1.Height = 0.1565F;
            this.Gm_ArrivalCnt1.Left = 3.5625F;
            this.Gm_ArrivalCnt1.MultiLine = false;
            this.Gm_ArrivalCnt1.Name = "Gm_ArrivalCnt1";
            this.Gm_ArrivalCnt1.OutputFormat = resources.GetString("Gm_ArrivalCnt1.OutputFormat");
            this.Gm_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt1.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt1.Text = "123,456";
            this.Gm_ArrivalCnt1.Top = 0.25F;
            this.Gm_ArrivalCnt1.Width = 0.5F;
            // 
            // Gm_ArrivalCnt2
            // 
            this.Gm_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Gm_ArrivalCnt2.Height = 0.1565F;
            this.Gm_ArrivalCnt2.Left = 4.0625F;
            this.Gm_ArrivalCnt2.MultiLine = false;
            this.Gm_ArrivalCnt2.Name = "Gm_ArrivalCnt2";
            this.Gm_ArrivalCnt2.OutputFormat = resources.GetString("Gm_ArrivalCnt2.OutputFormat");
            this.Gm_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt2.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt2.Text = "123,456";
            this.Gm_ArrivalCnt2.Top = 0.25F;
            this.Gm_ArrivalCnt2.Width = 0.5F;
            // 
            // Gm_ArrivalCnt3
            // 
            this.Gm_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Gm_ArrivalCnt3.Height = 0.1565F;
            this.Gm_ArrivalCnt3.Left = 4.5625F;
            this.Gm_ArrivalCnt3.MultiLine = false;
            this.Gm_ArrivalCnt3.Name = "Gm_ArrivalCnt3";
            this.Gm_ArrivalCnt3.OutputFormat = resources.GetString("Gm_ArrivalCnt3.OutputFormat");
            this.Gm_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt3.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt3.Text = "123,456";
            this.Gm_ArrivalCnt3.Top = 0.25F;
            this.Gm_ArrivalCnt3.Width = 0.5F;
            // 
            // Gm_ArrivalCnt4
            // 
            this.Gm_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Gm_ArrivalCnt4.Height = 0.1565F;
            this.Gm_ArrivalCnt4.Left = 5.0625F;
            this.Gm_ArrivalCnt4.MultiLine = false;
            this.Gm_ArrivalCnt4.Name = "Gm_ArrivalCnt4";
            this.Gm_ArrivalCnt4.OutputFormat = resources.GetString("Gm_ArrivalCnt4.OutputFormat");
            this.Gm_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt4.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt4.Text = "123,456";
            this.Gm_ArrivalCnt4.Top = 0.25F;
            this.Gm_ArrivalCnt4.Width = 0.5F;
            // 
            // Gm_ArrivalCnt5
            // 
            this.Gm_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Gm_ArrivalCnt5.Height = 0.1565F;
            this.Gm_ArrivalCnt5.Left = 5.5625F;
            this.Gm_ArrivalCnt5.MultiLine = false;
            this.Gm_ArrivalCnt5.Name = "Gm_ArrivalCnt5";
            this.Gm_ArrivalCnt5.OutputFormat = resources.GetString("Gm_ArrivalCnt5.OutputFormat");
            this.Gm_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt5.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt5.Text = "123,456";
            this.Gm_ArrivalCnt5.Top = 0.25F;
            this.Gm_ArrivalCnt5.Width = 0.5F;
            // 
            // Gm_ArrivalCnt6
            // 
            this.Gm_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Gm_ArrivalCnt6.Height = 0.1565F;
            this.Gm_ArrivalCnt6.Left = 6.0625F;
            this.Gm_ArrivalCnt6.MultiLine = false;
            this.Gm_ArrivalCnt6.Name = "Gm_ArrivalCnt6";
            this.Gm_ArrivalCnt6.OutputFormat = resources.GetString("Gm_ArrivalCnt6.OutputFormat");
            this.Gm_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt6.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt6.Text = "123,456";
            this.Gm_ArrivalCnt6.Top = 0.25F;
            this.Gm_ArrivalCnt6.Width = 0.5F;
            // 
            // Gm_ArrivalCnt7
            // 
            this.Gm_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Gm_ArrivalCnt7.Height = 0.1565F;
            this.Gm_ArrivalCnt7.Left = 6.5625F;
            this.Gm_ArrivalCnt7.MultiLine = false;
            this.Gm_ArrivalCnt7.Name = "Gm_ArrivalCnt7";
            this.Gm_ArrivalCnt7.OutputFormat = resources.GetString("Gm_ArrivalCnt7.OutputFormat");
            this.Gm_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt7.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt7.Text = "123,456";
            this.Gm_ArrivalCnt7.Top = 0.25F;
            this.Gm_ArrivalCnt7.Width = 0.5F;
            // 
            // Gm_ArrivalCnt8
            // 
            this.Gm_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Gm_ArrivalCnt8.Height = 0.1565F;
            this.Gm_ArrivalCnt8.Left = 7.0625F;
            this.Gm_ArrivalCnt8.MultiLine = false;
            this.Gm_ArrivalCnt8.Name = "Gm_ArrivalCnt8";
            this.Gm_ArrivalCnt8.OutputFormat = resources.GetString("Gm_ArrivalCnt8.OutputFormat");
            this.Gm_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt8.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt8.Text = "123,456";
            this.Gm_ArrivalCnt8.Top = 0.25F;
            this.Gm_ArrivalCnt8.Width = 0.5F;
            // 
            // Gm_ArrivalCnt9
            // 
            this.Gm_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Gm_ArrivalCnt9.Height = 0.1565F;
            this.Gm_ArrivalCnt9.Left = 7.5625F;
            this.Gm_ArrivalCnt9.MultiLine = false;
            this.Gm_ArrivalCnt9.Name = "Gm_ArrivalCnt9";
            this.Gm_ArrivalCnt9.OutputFormat = resources.GetString("Gm_ArrivalCnt9.OutputFormat");
            this.Gm_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt9.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt9.Text = "123,456";
            this.Gm_ArrivalCnt9.Top = 0.25F;
            this.Gm_ArrivalCnt9.Width = 0.5F;
            // 
            // Gm_ArrivalCnt10
            // 
            this.Gm_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Gm_ArrivalCnt10.Height = 0.1565F;
            this.Gm_ArrivalCnt10.Left = 8.0625F;
            this.Gm_ArrivalCnt10.MultiLine = false;
            this.Gm_ArrivalCnt10.Name = "Gm_ArrivalCnt10";
            this.Gm_ArrivalCnt10.OutputFormat = resources.GetString("Gm_ArrivalCnt10.OutputFormat");
            this.Gm_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt10.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt10.Text = "123,456";
            this.Gm_ArrivalCnt10.Top = 0.25F;
            this.Gm_ArrivalCnt10.Width = 0.5F;
            // 
            // Gm_ArrivalCnt11
            // 
            this.Gm_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Gm_ArrivalCnt11.Height = 0.1565F;
            this.Gm_ArrivalCnt11.Left = 8.5625F;
            this.Gm_ArrivalCnt11.MultiLine = false;
            this.Gm_ArrivalCnt11.Name = "Gm_ArrivalCnt11";
            this.Gm_ArrivalCnt11.OutputFormat = resources.GetString("Gm_ArrivalCnt11.OutputFormat");
            this.Gm_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt11.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt11.Text = "123,456";
            this.Gm_ArrivalCnt11.Top = 0.25F;
            this.Gm_ArrivalCnt11.Width = 0.5F;
            // 
            // Gm_ArrivalCnt12
            // 
            this.Gm_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Gm_ArrivalCnt12.Height = 0.1565F;
            this.Gm_ArrivalCnt12.Left = 9.0625F;
            this.Gm_ArrivalCnt12.MultiLine = false;
            this.Gm_ArrivalCnt12.Name = "Gm_ArrivalCnt12";
            this.Gm_ArrivalCnt12.OutputFormat = resources.GetString("Gm_ArrivalCnt12.OutputFormat");
            this.Gm_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_ArrivalCnt12.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_ArrivalCnt12.Text = "123,456";
            this.Gm_ArrivalCnt12.Top = 0.25F;
            this.Gm_ArrivalCnt12.Width = 0.5F;
            // 
            // Gm_Ave_ArrivalCnt
            // 
            this.Gm_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Gm_Ave_ArrivalCnt.Height = 0.1565F;
            this.Gm_Ave_ArrivalCnt.Left = 9.5625F;
            this.Gm_Ave_ArrivalCnt.MultiLine = false;
            this.Gm_Ave_ArrivalCnt.Name = "Gm_Ave_ArrivalCnt";
            this.Gm_Ave_ArrivalCnt.OutputFormat = resources.GetString("Gm_Ave_ArrivalCnt.OutputFormat");
            this.Gm_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_Ave_ArrivalCnt.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_Ave_ArrivalCnt.Text = "123,456";
            this.Gm_Ave_ArrivalCnt.Top = 0.25F;
            this.Gm_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Gm_Sum_ArrivalCnt
            // 
            this.Gm_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Gm_Sum_ArrivalCnt.Height = 0.1565F;
            this.Gm_Sum_ArrivalCnt.Left = 10.0625F;
            this.Gm_Sum_ArrivalCnt.MultiLine = false;
            this.Gm_Sum_ArrivalCnt.Name = "Gm_Sum_ArrivalCnt";
            this.Gm_Sum_ArrivalCnt.OutputFormat = resources.GetString("Gm_Sum_ArrivalCnt.OutputFormat");
            this.Gm_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_Sum_ArrivalCnt.SummaryGroup = "MediumGoodsGanreHeader";
            this.Gm_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_Sum_ArrivalCnt.Text = "123,456,789";
            this.Gm_Sum_ArrivalCnt.Top = 0.25F;
            this.Gm_Sum_ArrivalCnt.Width = 0.6875F;
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
            this.textBox6.DataField = "Sort_MediumGoodsGanre";
            this.textBox6.Height = 0.1565F;
            this.textBox6.Left = 2F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.textBox6.Text = "1234";
            this.textBox6.Top = 0.0625F;
            this.textBox6.Width = 0.3125F;
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
            this.textBox7.DataField = "MediumGoodsGanreName";
            this.textBox7.Height = 0.1565F;
            this.textBox7.Left = 2.3125F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox7.Text = "12345678901234567890";
            this.textBox7.Top = 0.0625F;
            this.textBox7.Width = 1.1875F;
            // 
            // DetailGoodsGanreHeader
            // 
            this.DetailGoodsGanreHeader.DataField = "Sort_DetailGoodsGanre";
            this.DetailGoodsGanreHeader.Height = 0.01041667F;
            this.DetailGoodsGanreHeader.Name = "DetailGoodsGanreHeader";
            // 
            // DetailGoodsGanreFooter
            // 
            this.DetailGoodsGanreFooter.CanShrink = true;
            this.DetailGoodsGanreFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox60,
            this.Gd_ShipmentCnt1,
            this.Gd_ShipmentCnt2,
            this.Gd_ShipmentCnt3,
            this.Gd_ShipmentCnt4,
            this.Gd_ShipmentCnt5,
            this.Gd_ShipmentCnt6,
            this.Gd_ShipmentCnt7,
            this.Gd_ShipmentCnt8,
            this.Gd_ShipmentCnt9,
            this.Gd_ShipmentCnt10,
            this.Gd_ShipmentCnt11,
            this.Gd_ShipmentCnt12,
            this.Gd_Ave_ShipmentCnt,
            this.Gd_ArrivalCnt1,
            this.Gd_ArrivalCnt2,
            this.Gd_ArrivalCnt3,
            this.Gd_ArrivalCnt4,
            this.Gd_ArrivalCnt5,
            this.Gd_ArrivalCnt6,
            this.Gd_ArrivalCnt7,
            this.Gd_ArrivalCnt8,
            this.Gd_ArrivalCnt9,
            this.Gd_ArrivalCnt10,
            this.Gd_ArrivalCnt11,
            this.Gd_ArrivalCnt12,
            this.Gd_Ave_ArrivalCnt,
            this.Gd_Sum_ShipmentCnt,
            this.Gd_Sum_ArrivalCnt,
            this.line6,
            this.textBox4,
            this.textBox5});
            this.DetailGoodsGanreFooter.Height = 0.478F;
            this.DetailGoodsGanreFooter.KeepTogether = true;
            this.DetailGoodsGanreFooter.Name = "DetailGoodsGanreFooter";
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
            this.textBox60.Height = 0.25F;
            this.textBox60.Left = 0.9375F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox60.Text = "グループ計";
            this.textBox60.Top = 0.031F;
            this.textBox60.Width = 1F;
            // 
            // Gd_ShipmentCnt1
            // 
            this.Gd_ShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt1.DataField = "ShipmentCnt1";
            this.Gd_ShipmentCnt1.Height = 0.1565F;
            this.Gd_ShipmentCnt1.Left = 3.5625F;
            this.Gd_ShipmentCnt1.MultiLine = false;
            this.Gd_ShipmentCnt1.Name = "Gd_ShipmentCnt1";
            this.Gd_ShipmentCnt1.OutputFormat = resources.GetString("Gd_ShipmentCnt1.OutputFormat");
            this.Gd_ShipmentCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt1.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt1.Text = "123,456";
            this.Gd_ShipmentCnt1.Top = 0.0625F;
            this.Gd_ShipmentCnt1.Width = 0.5F;
            // 
            // Gd_ShipmentCnt2
            // 
            this.Gd_ShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt2.DataField = "ShipmentCnt2";
            this.Gd_ShipmentCnt2.Height = 0.1565F;
            this.Gd_ShipmentCnt2.Left = 4.0625F;
            this.Gd_ShipmentCnt2.MultiLine = false;
            this.Gd_ShipmentCnt2.Name = "Gd_ShipmentCnt2";
            this.Gd_ShipmentCnt2.OutputFormat = resources.GetString("Gd_ShipmentCnt2.OutputFormat");
            this.Gd_ShipmentCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt2.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt2.Text = "123,456";
            this.Gd_ShipmentCnt2.Top = 0.0625F;
            this.Gd_ShipmentCnt2.Width = 0.5F;
            // 
            // Gd_ShipmentCnt3
            // 
            this.Gd_ShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt3.DataField = "ShipmentCnt3";
            this.Gd_ShipmentCnt3.Height = 0.1565F;
            this.Gd_ShipmentCnt3.Left = 4.5625F;
            this.Gd_ShipmentCnt3.MultiLine = false;
            this.Gd_ShipmentCnt3.Name = "Gd_ShipmentCnt3";
            this.Gd_ShipmentCnt3.OutputFormat = resources.GetString("Gd_ShipmentCnt3.OutputFormat");
            this.Gd_ShipmentCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt3.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt3.Text = "123,456";
            this.Gd_ShipmentCnt3.Top = 0.0625F;
            this.Gd_ShipmentCnt3.Width = 0.5F;
            // 
            // Gd_ShipmentCnt4
            // 
            this.Gd_ShipmentCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt4.DataField = "ShipmentCnt4";
            this.Gd_ShipmentCnt4.Height = 0.1565F;
            this.Gd_ShipmentCnt4.Left = 5.0625F;
            this.Gd_ShipmentCnt4.MultiLine = false;
            this.Gd_ShipmentCnt4.Name = "Gd_ShipmentCnt4";
            this.Gd_ShipmentCnt4.OutputFormat = resources.GetString("Gd_ShipmentCnt4.OutputFormat");
            this.Gd_ShipmentCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt4.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt4.Text = "123,456";
            this.Gd_ShipmentCnt4.Top = 0.0625F;
            this.Gd_ShipmentCnt4.Width = 0.5F;
            // 
            // Gd_ShipmentCnt5
            // 
            this.Gd_ShipmentCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt5.DataField = "ShipmentCnt5";
            this.Gd_ShipmentCnt5.Height = 0.1565F;
            this.Gd_ShipmentCnt5.Left = 5.5625F;
            this.Gd_ShipmentCnt5.MultiLine = false;
            this.Gd_ShipmentCnt5.Name = "Gd_ShipmentCnt5";
            this.Gd_ShipmentCnt5.OutputFormat = resources.GetString("Gd_ShipmentCnt5.OutputFormat");
            this.Gd_ShipmentCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt5.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt5.Text = "123,456";
            this.Gd_ShipmentCnt5.Top = 0.0625F;
            this.Gd_ShipmentCnt5.Width = 0.5F;
            // 
            // Gd_ShipmentCnt6
            // 
            this.Gd_ShipmentCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt6.DataField = "ShipmentCnt6";
            this.Gd_ShipmentCnt6.Height = 0.1565F;
            this.Gd_ShipmentCnt6.Left = 6.0625F;
            this.Gd_ShipmentCnt6.MultiLine = false;
            this.Gd_ShipmentCnt6.Name = "Gd_ShipmentCnt6";
            this.Gd_ShipmentCnt6.OutputFormat = resources.GetString("Gd_ShipmentCnt6.OutputFormat");
            this.Gd_ShipmentCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt6.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt6.Text = "123,456";
            this.Gd_ShipmentCnt6.Top = 0.0625F;
            this.Gd_ShipmentCnt6.Width = 0.5F;
            // 
            // Gd_ShipmentCnt7
            // 
            this.Gd_ShipmentCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt7.DataField = "ShipmentCnt7";
            this.Gd_ShipmentCnt7.Height = 0.1565F;
            this.Gd_ShipmentCnt7.Left = 6.5625F;
            this.Gd_ShipmentCnt7.MultiLine = false;
            this.Gd_ShipmentCnt7.Name = "Gd_ShipmentCnt7";
            this.Gd_ShipmentCnt7.OutputFormat = resources.GetString("Gd_ShipmentCnt7.OutputFormat");
            this.Gd_ShipmentCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt7.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt7.Text = "123,456";
            this.Gd_ShipmentCnt7.Top = 0.0625F;
            this.Gd_ShipmentCnt7.Width = 0.5F;
            // 
            // Gd_ShipmentCnt8
            // 
            this.Gd_ShipmentCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt8.DataField = "ShipmentCnt8";
            this.Gd_ShipmentCnt8.Height = 0.1565F;
            this.Gd_ShipmentCnt8.Left = 7.0625F;
            this.Gd_ShipmentCnt8.MultiLine = false;
            this.Gd_ShipmentCnt8.Name = "Gd_ShipmentCnt8";
            this.Gd_ShipmentCnt8.OutputFormat = resources.GetString("Gd_ShipmentCnt8.OutputFormat");
            this.Gd_ShipmentCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt8.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt8.Text = "123,456";
            this.Gd_ShipmentCnt8.Top = 0.0625F;
            this.Gd_ShipmentCnt8.Width = 0.5F;
            // 
            // Gd_ShipmentCnt9
            // 
            this.Gd_ShipmentCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt9.DataField = "ShipmentCnt9";
            this.Gd_ShipmentCnt9.Height = 0.1565F;
            this.Gd_ShipmentCnt9.Left = 7.5625F;
            this.Gd_ShipmentCnt9.MultiLine = false;
            this.Gd_ShipmentCnt9.Name = "Gd_ShipmentCnt9";
            this.Gd_ShipmentCnt9.OutputFormat = resources.GetString("Gd_ShipmentCnt9.OutputFormat");
            this.Gd_ShipmentCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt9.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt9.Text = "123,456";
            this.Gd_ShipmentCnt9.Top = 0.0625F;
            this.Gd_ShipmentCnt9.Width = 0.5F;
            // 
            // Gd_ShipmentCnt10
            // 
            this.Gd_ShipmentCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt10.DataField = "ShipmentCnt10";
            this.Gd_ShipmentCnt10.Height = 0.1565F;
            this.Gd_ShipmentCnt10.Left = 8.0625F;
            this.Gd_ShipmentCnt10.MultiLine = false;
            this.Gd_ShipmentCnt10.Name = "Gd_ShipmentCnt10";
            this.Gd_ShipmentCnt10.OutputFormat = resources.GetString("Gd_ShipmentCnt10.OutputFormat");
            this.Gd_ShipmentCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt10.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt10.Text = "123,456";
            this.Gd_ShipmentCnt10.Top = 0.0625F;
            this.Gd_ShipmentCnt10.Width = 0.5F;
            // 
            // Gd_ShipmentCnt11
            // 
            this.Gd_ShipmentCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt11.DataField = "ShipmentCnt11";
            this.Gd_ShipmentCnt11.Height = 0.1565F;
            this.Gd_ShipmentCnt11.Left = 8.5625F;
            this.Gd_ShipmentCnt11.MultiLine = false;
            this.Gd_ShipmentCnt11.Name = "Gd_ShipmentCnt11";
            this.Gd_ShipmentCnt11.OutputFormat = resources.GetString("Gd_ShipmentCnt11.OutputFormat");
            this.Gd_ShipmentCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt11.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt11.Text = "123,456";
            this.Gd_ShipmentCnt11.Top = 0.0625F;
            this.Gd_ShipmentCnt11.Width = 0.5F;
            // 
            // Gd_ShipmentCnt12
            // 
            this.Gd_ShipmentCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ShipmentCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ShipmentCnt12.DataField = "ShipmentCnt12";
            this.Gd_ShipmentCnt12.Height = 0.1565F;
            this.Gd_ShipmentCnt12.Left = 9.0625F;
            this.Gd_ShipmentCnt12.MultiLine = false;
            this.Gd_ShipmentCnt12.Name = "Gd_ShipmentCnt12";
            this.Gd_ShipmentCnt12.OutputFormat = resources.GetString("Gd_ShipmentCnt12.OutputFormat");
            this.Gd_ShipmentCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ShipmentCnt12.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ShipmentCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ShipmentCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ShipmentCnt12.Text = "123,456";
            this.Gd_ShipmentCnt12.Top = 0.0625F;
            this.Gd_ShipmentCnt12.Width = 0.5F;
            // 
            // Gd_Ave_ShipmentCnt
            // 
            this.Gd_Ave_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_Ave_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_Ave_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_Ave_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_Ave_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ShipmentCnt.DataField = "Avg_ShipmentCnt";
            this.Gd_Ave_ShipmentCnt.Height = 0.1565F;
            this.Gd_Ave_ShipmentCnt.Left = 9.5625F;
            this.Gd_Ave_ShipmentCnt.MultiLine = false;
            this.Gd_Ave_ShipmentCnt.Name = "Gd_Ave_ShipmentCnt";
            this.Gd_Ave_ShipmentCnt.OutputFormat = resources.GetString("Gd_Ave_ShipmentCnt.OutputFormat");
            this.Gd_Ave_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_Ave_ShipmentCnt.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_Ave_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_Ave_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_Ave_ShipmentCnt.Text = "123,456";
            this.Gd_Ave_ShipmentCnt.Top = 0.0625F;
            this.Gd_Ave_ShipmentCnt.Width = 0.5F;
            // 
            // Gd_ArrivalCnt1
            // 
            this.Gd_ArrivalCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt1.DataField = "ArrivalCnt1";
            this.Gd_ArrivalCnt1.Height = 0.1565F;
            this.Gd_ArrivalCnt1.Left = 3.5625F;
            this.Gd_ArrivalCnt1.MultiLine = false;
            this.Gd_ArrivalCnt1.Name = "Gd_ArrivalCnt1";
            this.Gd_ArrivalCnt1.OutputFormat = resources.GetString("Gd_ArrivalCnt1.OutputFormat");
            this.Gd_ArrivalCnt1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt1.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt1.Text = "123,456";
            this.Gd_ArrivalCnt1.Top = 0.25F;
            this.Gd_ArrivalCnt1.Width = 0.5F;
            // 
            // Gd_ArrivalCnt2
            // 
            this.Gd_ArrivalCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt2.DataField = "ArrivalCnt2";
            this.Gd_ArrivalCnt2.Height = 0.1565F;
            this.Gd_ArrivalCnt2.Left = 4.0625F;
            this.Gd_ArrivalCnt2.MultiLine = false;
            this.Gd_ArrivalCnt2.Name = "Gd_ArrivalCnt2";
            this.Gd_ArrivalCnt2.OutputFormat = resources.GetString("Gd_ArrivalCnt2.OutputFormat");
            this.Gd_ArrivalCnt2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt2.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt2.Text = "123,456";
            this.Gd_ArrivalCnt2.Top = 0.25F;
            this.Gd_ArrivalCnt2.Width = 0.5F;
            // 
            // Gd_ArrivalCnt3
            // 
            this.Gd_ArrivalCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt3.DataField = "ArrivalCnt3";
            this.Gd_ArrivalCnt3.Height = 0.1565F;
            this.Gd_ArrivalCnt3.Left = 4.5625F;
            this.Gd_ArrivalCnt3.MultiLine = false;
            this.Gd_ArrivalCnt3.Name = "Gd_ArrivalCnt3";
            this.Gd_ArrivalCnt3.OutputFormat = resources.GetString("Gd_ArrivalCnt3.OutputFormat");
            this.Gd_ArrivalCnt3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt3.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt3.Text = "123,456";
            this.Gd_ArrivalCnt3.Top = 0.25F;
            this.Gd_ArrivalCnt3.Width = 0.5F;
            // 
            // Gd_ArrivalCnt4
            // 
            this.Gd_ArrivalCnt4.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt4.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt4.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt4.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt4.DataField = "ArrivalCnt4";
            this.Gd_ArrivalCnt4.Height = 0.1565F;
            this.Gd_ArrivalCnt4.Left = 5.0625F;
            this.Gd_ArrivalCnt4.MultiLine = false;
            this.Gd_ArrivalCnt4.Name = "Gd_ArrivalCnt4";
            this.Gd_ArrivalCnt4.OutputFormat = resources.GetString("Gd_ArrivalCnt4.OutputFormat");
            this.Gd_ArrivalCnt4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt4.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt4.Text = "123,456";
            this.Gd_ArrivalCnt4.Top = 0.25F;
            this.Gd_ArrivalCnt4.Width = 0.5F;
            // 
            // Gd_ArrivalCnt5
            // 
            this.Gd_ArrivalCnt5.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt5.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt5.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt5.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt5.DataField = "ArrivalCnt5";
            this.Gd_ArrivalCnt5.Height = 0.1565F;
            this.Gd_ArrivalCnt5.Left = 5.5625F;
            this.Gd_ArrivalCnt5.MultiLine = false;
            this.Gd_ArrivalCnt5.Name = "Gd_ArrivalCnt5";
            this.Gd_ArrivalCnt5.OutputFormat = resources.GetString("Gd_ArrivalCnt5.OutputFormat");
            this.Gd_ArrivalCnt5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt5.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt5.Text = "123,456";
            this.Gd_ArrivalCnt5.Top = 0.25F;
            this.Gd_ArrivalCnt5.Width = 0.5F;
            // 
            // Gd_ArrivalCnt6
            // 
            this.Gd_ArrivalCnt6.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt6.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt6.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt6.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt6.DataField = "ArrivalCnt6";
            this.Gd_ArrivalCnt6.Height = 0.1565F;
            this.Gd_ArrivalCnt6.Left = 6.0625F;
            this.Gd_ArrivalCnt6.MultiLine = false;
            this.Gd_ArrivalCnt6.Name = "Gd_ArrivalCnt6";
            this.Gd_ArrivalCnt6.OutputFormat = resources.GetString("Gd_ArrivalCnt6.OutputFormat");
            this.Gd_ArrivalCnt6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt6.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt6.Text = "123,456";
            this.Gd_ArrivalCnt6.Top = 0.25F;
            this.Gd_ArrivalCnt6.Width = 0.5F;
            // 
            // Gd_ArrivalCnt7
            // 
            this.Gd_ArrivalCnt7.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt7.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt7.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt7.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt7.DataField = "ArrivalCnt7";
            this.Gd_ArrivalCnt7.Height = 0.1565F;
            this.Gd_ArrivalCnt7.Left = 6.5625F;
            this.Gd_ArrivalCnt7.MultiLine = false;
            this.Gd_ArrivalCnt7.Name = "Gd_ArrivalCnt7";
            this.Gd_ArrivalCnt7.OutputFormat = resources.GetString("Gd_ArrivalCnt7.OutputFormat");
            this.Gd_ArrivalCnt7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt7.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt7.Text = "123,456";
            this.Gd_ArrivalCnt7.Top = 0.25F;
            this.Gd_ArrivalCnt7.Width = 0.5F;
            // 
            // Gd_ArrivalCnt8
            // 
            this.Gd_ArrivalCnt8.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt8.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt8.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt8.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt8.DataField = "ArrivalCnt8";
            this.Gd_ArrivalCnt8.Height = 0.1565F;
            this.Gd_ArrivalCnt8.Left = 7.0625F;
            this.Gd_ArrivalCnt8.MultiLine = false;
            this.Gd_ArrivalCnt8.Name = "Gd_ArrivalCnt8";
            this.Gd_ArrivalCnt8.OutputFormat = resources.GetString("Gd_ArrivalCnt8.OutputFormat");
            this.Gd_ArrivalCnt8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt8.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt8.Text = "123,456";
            this.Gd_ArrivalCnt8.Top = 0.25F;
            this.Gd_ArrivalCnt8.Width = 0.5F;
            // 
            // Gd_ArrivalCnt9
            // 
            this.Gd_ArrivalCnt9.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt9.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt9.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt9.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt9.DataField = "ArrivalCnt9";
            this.Gd_ArrivalCnt9.Height = 0.1565F;
            this.Gd_ArrivalCnt9.Left = 7.5625F;
            this.Gd_ArrivalCnt9.MultiLine = false;
            this.Gd_ArrivalCnt9.Name = "Gd_ArrivalCnt9";
            this.Gd_ArrivalCnt9.OutputFormat = resources.GetString("Gd_ArrivalCnt9.OutputFormat");
            this.Gd_ArrivalCnt9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt9.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt9.Text = "123,456";
            this.Gd_ArrivalCnt9.Top = 0.25F;
            this.Gd_ArrivalCnt9.Width = 0.5F;
            // 
            // Gd_ArrivalCnt10
            // 
            this.Gd_ArrivalCnt10.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt10.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt10.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt10.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt10.DataField = "ArrivalCnt10";
            this.Gd_ArrivalCnt10.Height = 0.1565F;
            this.Gd_ArrivalCnt10.Left = 8.0625F;
            this.Gd_ArrivalCnt10.MultiLine = false;
            this.Gd_ArrivalCnt10.Name = "Gd_ArrivalCnt10";
            this.Gd_ArrivalCnt10.OutputFormat = resources.GetString("Gd_ArrivalCnt10.OutputFormat");
            this.Gd_ArrivalCnt10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt10.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt10.Text = "123,456";
            this.Gd_ArrivalCnt10.Top = 0.25F;
            this.Gd_ArrivalCnt10.Width = 0.5F;
            // 
            // Gd_ArrivalCnt11
            // 
            this.Gd_ArrivalCnt11.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt11.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt11.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt11.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt11.DataField = "ArrivalCnt11";
            this.Gd_ArrivalCnt11.Height = 0.1565F;
            this.Gd_ArrivalCnt11.Left = 8.5625F;
            this.Gd_ArrivalCnt11.MultiLine = false;
            this.Gd_ArrivalCnt11.Name = "Gd_ArrivalCnt11";
            this.Gd_ArrivalCnt11.OutputFormat = resources.GetString("Gd_ArrivalCnt11.OutputFormat");
            this.Gd_ArrivalCnt11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt11.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt11.Text = "123,456";
            this.Gd_ArrivalCnt11.Top = 0.25F;
            this.Gd_ArrivalCnt11.Width = 0.5F;
            // 
            // Gd_ArrivalCnt12
            // 
            this.Gd_ArrivalCnt12.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt12.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt12.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt12.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_ArrivalCnt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_ArrivalCnt12.DataField = "ArrivalCnt12";
            this.Gd_ArrivalCnt12.Height = 0.1565F;
            this.Gd_ArrivalCnt12.Left = 9.0625F;
            this.Gd_ArrivalCnt12.MultiLine = false;
            this.Gd_ArrivalCnt12.Name = "Gd_ArrivalCnt12";
            this.Gd_ArrivalCnt12.OutputFormat = resources.GetString("Gd_ArrivalCnt12.OutputFormat");
            this.Gd_ArrivalCnt12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_ArrivalCnt12.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_ArrivalCnt12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_ArrivalCnt12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_ArrivalCnt12.Text = "123,456";
            this.Gd_ArrivalCnt12.Top = 0.25F;
            this.Gd_ArrivalCnt12.Width = 0.5F;
            // 
            // Gd_Ave_ArrivalCnt
            // 
            this.Gd_Ave_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_Ave_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_Ave_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_Ave_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_Ave_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Ave_ArrivalCnt.DataField = "Avg_ArrivalCnt";
            this.Gd_Ave_ArrivalCnt.Height = 0.1565F;
            this.Gd_Ave_ArrivalCnt.Left = 9.5625F;
            this.Gd_Ave_ArrivalCnt.MultiLine = false;
            this.Gd_Ave_ArrivalCnt.Name = "Gd_Ave_ArrivalCnt";
            this.Gd_Ave_ArrivalCnt.OutputFormat = resources.GetString("Gd_Ave_ArrivalCnt.OutputFormat");
            this.Gd_Ave_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_Ave_ArrivalCnt.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_Ave_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_Ave_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_Ave_ArrivalCnt.Text = "123,456";
            this.Gd_Ave_ArrivalCnt.Top = 0.25F;
            this.Gd_Ave_ArrivalCnt.Width = 0.5F;
            // 
            // Gd_Sum_ShipmentCnt
            // 
            this.Gd_Sum_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_Sum_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_Sum_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_Sum_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_Sum_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ShipmentCnt.DataField = "Sum_ShipmentCnt";
            this.Gd_Sum_ShipmentCnt.Height = 0.1565F;
            this.Gd_Sum_ShipmentCnt.Left = 10.0625F;
            this.Gd_Sum_ShipmentCnt.MultiLine = false;
            this.Gd_Sum_ShipmentCnt.Name = "Gd_Sum_ShipmentCnt";
            this.Gd_Sum_ShipmentCnt.OutputFormat = resources.GetString("Gd_Sum_ShipmentCnt.OutputFormat");
            this.Gd_Sum_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_Sum_ShipmentCnt.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_Sum_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_Sum_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_Sum_ShipmentCnt.Text = "123,456,789";
            this.Gd_Sum_ShipmentCnt.Top = 0.0625F;
            this.Gd_Sum_ShipmentCnt.Width = 0.6875F;
            // 
            // Gd_Sum_ArrivalCnt
            // 
            this.Gd_Sum_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gd_Sum_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gd_Sum_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gd_Sum_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gd_Sum_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gd_Sum_ArrivalCnt.DataField = "Sum_ArrivalCnt";
            this.Gd_Sum_ArrivalCnt.Height = 0.1565F;
            this.Gd_Sum_ArrivalCnt.Left = 10.0625F;
            this.Gd_Sum_ArrivalCnt.MultiLine = false;
            this.Gd_Sum_ArrivalCnt.Name = "Gd_Sum_ArrivalCnt";
            this.Gd_Sum_ArrivalCnt.OutputFormat = resources.GetString("Gd_Sum_ArrivalCnt.OutputFormat");
            this.Gd_Sum_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gd_Sum_ArrivalCnt.SummaryGroup = "DetailGoodsGanreHeader";
            this.Gd_Sum_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gd_Sum_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gd_Sum_ArrivalCnt.Text = "123,456,789";
            this.Gd_Sum_ArrivalCnt.Top = 0.25F;
            this.Gd_Sum_ArrivalCnt.Width = 0.6875F;
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
            this.textBox4.DataField = "Sort_DetailGoodsGanre";
            this.textBox4.Height = 0.1565F;
            this.textBox4.Left = 2F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.textBox4.Text = "12345";
            this.textBox4.Top = 0.0625F;
            this.textBox4.Width = 0.3125F;
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
            this.textBox5.DataField = "DetailGoodsGanreName";
            this.textBox5.Height = 0.1565F;
            this.textBox5.Left = 2.3125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox5.Text = "12345678901234567890";
            this.textBox5.Top = 0.0625F;
            this.textBox5.Width = 1.1875F;
            // 
            // DCZAI02123P_01A4C
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
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.GoodsMakerHeader);
            this.Sections.Add(this.LargeGoodsGanreHeader);
            this.Sections.Add(this.MediumGoodsGanreHeader);
            this.Sections.Add(this.DetailGoodsGanreHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.DetailGoodsGanreFooter);
            this.Sections.Add(this.MediumGoodsGanreFooter);
            this.Sections.Add(this.LargeGoodsGanreFooter);
            this.Sections.Add(this.GoodsMakerFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.WarehouseFooter);
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
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Ave_ShipArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Sum_ShipArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cus_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gl_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ShipmentCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Ave_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_ArrivalCnt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Ave_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Sum_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gd_Sum_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void CustomerHeader_Format( object sender, EventArgs e )
        {
            /* ---DEL 2009/03/23 不具合対応[12542] ------------------------->>>>>
            if ( GetIntFromText( GoodsMakerCd.Text, -1 ) != 0 )
            {
                GoodsMakerCd.Visible = true;
                MakerName.Visible = true;
            }
            else
            {
                GoodsMakerCd.Visible = false;
                MakerName.Visible = false;
            }
               ---DEL 2009/03/23 不具合対応[12542] -------------------------<<<<< */
        }

        /// <summary>
        /// テキスト→数値変換
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private int GetIntFromText( string text, int defaultValue )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return defaultValue;
            }
        }
	}
}
