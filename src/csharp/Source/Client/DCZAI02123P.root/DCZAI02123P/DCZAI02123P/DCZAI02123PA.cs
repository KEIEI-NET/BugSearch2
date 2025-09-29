using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/01 不具合対応[5683]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 在庫入出荷一覧表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫入出荷一覧表の印刷を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
    /// <br>Update Note: 2009/03/17 30452 上野 俊治</br>
    /// <br>            ・障害対応12705</br>
	/// </remarks>
	class DCZAI02123PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 在庫入出荷一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫入出荷一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02123PA()
		{
		}

		/// <summary>
		/// 在庫入出荷一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 在庫入出荷一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02123PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockShipArrivalListCndtn = this._printInfo.jyoken as StockShipArrivalListCndtn;
		}
		#endregion ■ Constructor

		#region ■ Private Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        //--- DEL 2008/07/16 ---------->>>>>
        //private const string ct_Extr_Top		= "ＴＯＰ";
        //private const string ct_Extr_End		= "ＥＮＤ";
        //--- DEL 2008/07/16 ----------<<<<<
        //--- ADD 2008/07/16 ---------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/10/01 不具合対応[5683] "最初から"→RangeUtil.FROM_BEGIN;
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/10/01 不具合対応[5683] "最後まで"→RangeUtil.TO_END;
        //--- ADD 2008/07/16 ----------<<<<<
        private const string ct_RangeConst = "：{0} ～ {1}";
        
        private const string YYYY_MM_FORMAT = "yyyy/MM";    // ADD 2008/10/01 不具合対応[6008]
        private const string DATE_FORMAT = "yyyy/MM/dd";    // ADD 2008/10/01 不具合対応[6008]

		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					                    // 印刷情報クラス
		private StockShipArrivalListCndtn _stockShipArrivalListCndtn;		// 抽出条件クラス
		#endregion ■ Private Member

       

		#region ■ Exception Class
		/// <summary> 例外クラス </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region ◆ Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public StockMoveException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region ◆ Public Property
			/// <summary> ステータスプロパティ </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion ■ Exception Class

		#region ■ IPrintProc メンバ
		#region ◆ Public Property
		/// <summary>
		/// 印刷情報取得プロパティ
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 印刷処理開始
		/// <summary>
		/// 印刷処理開始
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷を開始する。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion ◆ Public Method
		#endregion ■ IPrintProc メンバ

		#region ■ Private Member
		#region ◆ 印刷処理
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// 印刷フォームクラスインスタンス作成
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// レポートインスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// データソース設定
				prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCZAI02125EA.ct_Tbl_StockShipArrival;
				
				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

			    // プレビュー有無				
			    int mode = this._printInfo.prevkbn;
				
			    // 出力モードがＰＤＦの場合、無条件でプレビュー無
			    if (this._printInfo.printmode == 2)
			    {
			        mode = 0;
			    }
				
			    switch(mode)
			    {
			        case 0:		// プレビュ無
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();
						
			            // 共通条件設定
			            processForm.CommonInfo = commonInfo;

			            // プログレスバーUPイベント追加
			            if (prtRpt is IPrintActiveReportTypeCommon)
			            {
			                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
			                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
			            }

			            // 印刷実行
			            status = processForm.Run(prtRpt);

			            // 戻り値設定
			            this._printInfo.status = status;

			            break;
			        }
			        case 1:		// プレビュ有
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

			            // 共通条件設定
			            viewForm.CommonInfo   = commonInfo;

			            // プレビュー実行
			            status = viewForm.Run(prtRpt); 

			            // 戻り値設定
			            this._printInfo.status = status;
						
			            break;
			        }
			    }

			    // ＰＤＦ出力の場合
			    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			    {
			        switch (this._printInfo.printmode)
			        {
			            case 1:  // プリンタ
			                break;
			            case 2:  // ＰＤＦ
			            case 3:  // 両方(プリンタ + ＰＤＦ)
			            {
			                // ＰＤＦ表示フラグON
			                this._printInfo.pdfopen = true;
   
			                // 両方印刷時のみ履歴保存
			                if (this._printInfo.printmode == 3)
			                {
			                    // 出力履歴管理に追加
			                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
			                        this._printInfo.pdftemppath);
			                }
			                break;
			            }
			        }
			    }
			}
			catch(Exception ex)
			{
			    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			        ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
			    if ( prtRpt != null )
			    {
			        prtRpt.Dispose();
			    }
			}
			return status;
		}
		#endregion ◆ 印刷処理

		#region ◆ レポートフォーム設定関連
		#region ◎ 各種ActiveReport帳票インスタンス作成
		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

		#region ◎ レポートアセンブリインスタンス化
		/// <summary>
		/// レポートアセンブリインスタンス化
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new StockMoveException(asmname + "が存在しません。",-1);
			}
			catch(System.Exception er)
			{
				throw new StockMoveException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region ◎ 印刷画面共通情報設定

		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
        /// <param name="rptObj"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // DEL 2009/03/17
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
			
			// 帳票チャート共通部品クラス
			SFCMN00331C cmnCommon = new SFCMN00331C(); 

			// PDFパス取得
			string pdfPath = "";
			string pdfName = "";
		
			// プリンタ名
			commonInfo.PrinterName = this._printInfo.prinm;
			// 帳票名
			commonInfo.PrintName   = this._printInfo.prpnm;				
			// 印刷モード
			commonInfo.PrintMode   = this.Printinfo.printmode;
			// 印刷件数
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// 上余白
			commonInfo.MarginsTop  = this._printInfo.py;
			// 左余白
			commonInfo.MarginsLeft = this._printInfo.px;

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<<
		}

		#endregion
		
		#region ◎ 各種プロパティ設定
		
		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            StockShipArrivalListCndtn extraInfo = (StockShipArrivalListCndtn)this._printInfo.jyoken;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = "";
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = StockShipArrivalListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
            }

           
			
			// 抽出条件ヘッダ出力区分
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// 抽出条件編集処理
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );

			instance.ExtraConditions = extraInfomations; 
			
			// フッタ出力区分
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// フッタ出力メッセージ
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// 印刷情報オブジェクト
			instance.PrintInfo = this._printInfo;

			// ヘッダーサブタイトル
            object[] titleObj = new object[]{"在庫入出荷一覧表"};
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// その他データ
			// Todo:移動元とか渡す？抽出条件渡るからいいか？
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region ◎ 抽出条件出力情報作成
		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成する。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // DEL 2008/09/25 不具合対応[5616]---------->>>>>
            //// 出力条件 ----------------------------------------------------------------------------------------------------
            //string st_ShipArrivalCnt = string.Empty;
            //string ed_ShipArrivalCnt = string.Empty;
            
            //st_ShipArrivalCnt = string.Format("{0}個以上",this._stockShipArrivalListCndtn.St_ShipArrivalCnt);
            //ed_ShipArrivalCnt = string.Format("{0}個以下",this._stockShipArrivalListCndtn.Ed_ShipArrivalCnt);

            //this.EditCondition(ref addConditions, String.Format("出力条件：{0}　{1}{2}", 
            //                                                        this._stockShipArrivalListCndtn.ShipArrivalCntDivTitle,
            //                                                        st_ShipArrivalCnt,
            //                                                        ed_ShipArrivalCnt));

            //// 印刷タイプ --------------------------------------------------------------------------------------------------
            //string shipArrivalPrintDivTitleExp = string.Empty;
            //if (this._stockShipArrivalListCndtn.ShipArrivalPrintDiv == StockShipArrivalListCndtn.ShipArrivalPrintDivState.ShipArrival) {
            //    shipArrivalPrintDivTitleExp = "上段：出荷　下段：入荷";
            //}
            //this.EditCondition( ref addConditions, String.Format("印刷タイプ：{0}　{1}",
            //                                                        this._stockShipArrivalListCndtn.ShipArrivalPrintDivTitle,
            //                                                        shipArrivalPrintDivTitleExp) );

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            
            //// 在庫登録日 ----------------------------------------------------------------------------------------------------
            //this.EditCondition( ref addConditions,
            //    string.Format( "在庫登録日：{0} {1}",
            //    this._stockShipArrivalListCndtn.StockCreateDate.ToString( "yyyy年MM月dd日 " ), 
            //    this._stockShipArrivalListCndtn.StockCreateDateDivTitle) );
            // DEL 2008/09/25 不具合対応[5616]----------<<<<<

            // 出力条件 ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, "出力条件：");    // ADD 2008/09/25 不具合対応[5616]

            // 対象年月 ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;
            //string ShipArrivalDateFormat = "yyyy年MM月";

            // 開始･終了のいずれかが入力されていれば印字
            if ( (this._stockShipArrivalListCndtn.St_AddUpYearMonth != DateTime.MinValue) || (this._stockShipArrivalListCndtn.Ed_AddUpYearMonth != DateTime.MinValue) )
            {
                // 開始
                if (this._stockShipArrivalListCndtn.St_AddUpYearMonth != DateTime.MinValue)
                {
                    // MOD 2008/10/01 不具合対応[6008]↓ "yyyy年MM月"→YYYY_MM_FORMAT
                    st_ShipArrivalDate = this._stockShipArrivalListCndtn.St_AddUpYearMonth.ToString(YYYY_MM_FORMAT);//TDateTime.DateTimeToString(ShipArrivalDateFormat, this._stockShipArrivalListCndtn.St_AddUpYearMonth);
                }
                else
                {
                    st_ShipArrivalDate = ct_Extr_Top;
                }
                // 終了
                // MOD 2008/09/24 不具合対応[5614]↓ DateTime.MinValue→DateTime.MaxValue
                if (this._stockShipArrivalListCndtn.Ed_AddUpYearMonth != DateTime.MaxValue)
                {
                    // MOD 2008/10/01 不具合対応[6008]↓ "yyyy年MM月"→YYYY_MM_FORMAT
                    ed_ShipArrivalDate = this._stockShipArrivalListCndtn.Ed_AddUpYearMonth.ToString(YYYY_MM_FORMAT);//TDateTime.DateTimeToString(ShipArrivalDateFormat, this._stockShipArrivalListCndtn.Ed_AddUpYearMonth);
                }
                else
                {
                    ed_ShipArrivalDate = ct_Extr_End;
                }

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        "対象年月" + ct_RangeConst, // MOD 2008/10/01 不具合対応[5683] "処理月"→"対象年月日"
                        st_ShipArrivalDate,
                        ed_ShipArrivalDate ) );
            }

            // ADD 2008/09/25 不具合対応[5616]---------->>>>>
            // 在庫登録日 ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions,
                string.Format("在庫登録日：{0} {1}",
                this._stockShipArrivalListCndtn.StockCreateDate.ToString(DATE_FORMAT + " "),    // MOD 2008/10/01 不具合対応[6008]↓ "yyyy年MM月dd日 "→DATE_FORMAT + " "
                this._stockShipArrivalListCndtn.StockCreateDateDivTitle));

            // 個数指定 ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalCnt = string.Empty;
            string ed_ShipArrivalCnt = string.Empty;

            st_ShipArrivalCnt = string.Format("{0}個以上", this._stockShipArrivalListCndtn.St_ShipArrivalCnt);
            ed_ShipArrivalCnt = string.Format("{0}個以下", this._stockShipArrivalListCndtn.Ed_ShipArrivalCnt);

            this.EditCondition(ref addConditions, String.Format("個数指定：{0}　{1}{2}",
                                                                    this._stockShipArrivalListCndtn.ShipArrivalCntDivTitle,
                                                                    st_ShipArrivalCnt,
                                                                    ed_ShipArrivalCnt));

            // 印刷タイプ --------------------------------------------------------------------------------------------------
            string shipArrivalPrintDivTitleExp = string.Empty;
            if (this._stockShipArrivalListCndtn.ShipArrivalPrintDiv == StockShipArrivalListCndtn.ShipArrivalPrintDivState.ShipArrival)
            {
                shipArrivalPrintDivTitleExp = "上段：出荷　下段：入荷";
            }
            this.EditCondition(ref addConditions, String.Format("印刷タイプ：{0}　{1}",
                                                                    this._stockShipArrivalListCndtn.ShipArrivalPrintDivTitle,
                                                                    shipArrivalPrintDivTitleExp));
            // ADD 2008/09/25 不具合対応[5616]----------<<<<<



            // 倉庫 ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    this.GetConditionRange( "倉庫", this._stockShipArrivalListCndtn.St_WarehouseCode, this._stockShipArrivalListCndtn.Ed_WarehouseCode )
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.WarehouseCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_WarehouseCode,
                this._stockShipArrivalListCndtn.Ed_WarehouseCode
            ))
            {
                string start= RangeUtil.WarehouseCode.GetStartString(this._stockShipArrivalListCndtn.St_WarehouseCode);
                string end  = RangeUtil.WarehouseCode.GetEndString(this._stockShipArrivalListCndtn.Ed_WarehouseCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("倉庫", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // 仕入先 ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    this.GetConditionRange("仕入先", this._stockShipArrivalListCndtn.St_CustomerCode, this._stockShipArrivalListCndtn.Ed_CustomerCode, 999999)  // MOD 2008/09/24 不具合対応[5614] 999999999→999999   
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.SupplierCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_CustomerCode,
                this._stockShipArrivalListCndtn.Ed_CustomerCode
            ))
            {
                string start= RangeUtil.SupplierCode.GetStartString(this._stockShipArrivalListCndtn.St_CustomerCode);
                string end  = RangeUtil.SupplierCode.GetEndString(this._stockShipArrivalListCndtn.Ed_CustomerCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("仕入先", start, end)   
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // メーカー ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    this.GetConditionRange("メーカー", this._stockShipArrivalListCndtn.St_GoodsMakerCd, this._stockShipArrivalListCndtn.Ed_GoodsMakerCd, 9999)  // MOD 2008/09/24 不具合対応[5614] 999999→9999
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.GoodsMakerCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_GoodsMakerCd,
                this._stockShipArrivalListCndtn.Ed_GoodsMakerCd
            ))
            {
                string start= RangeUtil.GoodsMakerCode.GetStartString(this._stockShipArrivalListCndtn.St_GoodsMakerCd);
                string end  = RangeUtil.GoodsMakerCode.GetEndString(this._stockShipArrivalListCndtn.Ed_GoodsMakerCd);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("メーカー", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // 商品区分グループ ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("商品区分グループ", this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode)    // DEL 2008.07.16
            //    this.GetConditionRange( "商品大分類", this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode )          // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.GoodsLGroupCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode,
                this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode
            ))
            {
                string start= RangeUtil.GoodsLGroupCode.GetStartString(this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode);
                string end  = RangeUtil.GoodsLGroupCode.GetEndString(this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("商品大分類", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // 商品区分 ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("商品区分", this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode)          // DEL 2008.07.16
            //    this.GetConditionRange( "商品中分類", this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode )        // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.GoodsMGroupCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode,
                this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode
            ))
            {
                string start= RangeUtil.GoodsMGroupCode.GetStartString(this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode);
                string end  = RangeUtil.GoodsMGroupCode.GetEndString(this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("商品中分類", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // 商品詳細 ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange( "商品区分詳細", this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode )    // DEL 2008.07.16
            //    this.GetConditionRange( "グループコード", this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode )    // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.BLGroupCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode,
                this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode
            ))
            {
                string start= RangeUtil.BLGroupCode.GetStartString(this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode);
                string end  = RangeUtil.BLGroupCode.GetEndString(this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("グループコード", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // 自社分類 ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("自社分類", this._stockShipArrivalListCndtn.St_EnterpriseGanreCode, this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode, 9999)      // DEL 2008.07.16
            //    this.GetConditionRange( "商品区分", this._stockShipArrivalListCndtn.St_EnterpriseGanreCode, this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode, 9999 )      // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.EnterpriseGanreCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_EnterpriseGanreCode,
                this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode
            ))
            {
                string start= RangeUtil.EnterpriseGanreCode.GetStartString(this._stockShipArrivalListCndtn.St_EnterpriseGanreCode);
                string end  = RangeUtil.EnterpriseGanreCode.GetEndString(this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("商品区分", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // ＢＬ商品コード ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 不具合対応[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("ＢＬ商品コード", this._stockShipArrivalListCndtn.St_BLGoodsCode, this._stockShipArrivalListCndtn.Ed_BLGoodsCode, 99999999)// DEL 2008.07.16
            //    this.GetConditionRange( "ＢＬコード", this._stockShipArrivalListCndtn.St_BLGoodsCode, this._stockShipArrivalListCndtn.Ed_BLGoodsCode, 99999 )       // ADD 2008.07.16
            //                                                                                                                                                        // MOD 2008/09/24 不具合対応[5614] 99999999→99999
            //    );
            // DEL 2008/10/01 不具合対応[5683]----------<<<<<
            // ADD 2008/10/01 不具合対応[5683]---------->>>>>
            if (!RangeUtil.BLGoodsCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_BLGoodsCode,
                this._stockShipArrivalListCndtn.Ed_BLGoodsCode
            ))
            {
                string start= RangeUtil.BLGoodsCode.GetStartString(this._stockShipArrivalListCndtn.St_BLGoodsCode);
                string end  = RangeUtil.BLGoodsCode.GetEndString(this._stockShipArrivalListCndtn.Ed_BLGoodsCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("ＢＬコード", start, end)
                );
            }
            // ADD 2008/10/01 不具合対応[5683]----------<<<<<

            // 商品番号 ----------------------------------------------------------------------------------------------------
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "商品番号", this._stockShipArrivalListCndtn.St_GoodsNo, this._stockShipArrivalListCndtn.Ed_GoodsNo )                                  // DEL 2008.07.16
                this.GetConditionRange( "品番", this._stockShipArrivalListCndtn.St_GoodsNo, this._stockShipArrivalListCndtn.Ed_GoodsNo )                                        // ADD 2008.07.16
                );

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 追加
            foreach ( string exCondStr in addConditions ) {
                extraConditions.Add(exCondStr);
            }
        }
		#endregion

		#region ◎ 抽出範囲文字列作成
		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private string GetConditionRange( string title, string startString, string endString )
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end	 = ct_Extr_End;
				if (startString	!= "")	start	= startString;
				if (endString	!= "")	end		= endString;
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 抽出範囲文字列作成（数値用）
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startCode"></param>
        /// <param name="endCode"></param>
        /// <param name="endMax"></param>
        /// <returns>作成文字列</returns>
        private string GetConditionRange( string title, int startCode, int endCode, int endMax )
        {
            string result = "";
            if ((startCode >= 0) || (endCode != endMax)) // MOD 2008/09/24 不具合対応[5614] != 0 → >= 0
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startCode != 0 )
                    start = startCode.ToString().TrimEnd();
                if ( endCode != endMax )
                    end = endCode.ToString().TrimEnd();
                result = String.Format( title + ct_RangeConst, start, end );

                if (start.Equals(ct_Extr_Top) && end.Equals(ct_Extr_End)) result = string.Empty;    // ADD 2008/09/24 不具合対応[5614]
            }
            return result;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

		#region ◎ 抽出条件文字列編集
		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// 編集対象文字バイト数算出
			int targetByte = TStrConv.SizeCountSJIS(target);
			
			for (int i = 0; i < editArea.Count; i++)
			{
				int areaByte = 0;
				
				// 格納エリアのバイト数算出
				if (editArea[i] != null)
				{
					areaByte = TStrConv.SizeCountSJIS(editArea[i]);
				}

				if ((areaByte + targetByte + 2) <= 190)
				{
					isEdit = true;

					// 全角スペースを挿入
					if (editArea[i] != null) editArea[i] += ct_Space;
					
					editArea[i]  += target;
					break;
				}
			}
			// 新規編集エリア作成
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		#endregion ◆ レポートフォーム設定関連

		#region ◎ メッセージ表示

		/// <summary>
		/// メッセージ表示
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">エラーメッセージ</param>
		/// <param name="iSt">ステータス</param>
		/// <param name="iButton">表示ボタン</param>
		/// <param name="iDefButton">デフォルトフォーカスボタン</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : 出力件数の設定を行います。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCZAI02123P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
    }
}
