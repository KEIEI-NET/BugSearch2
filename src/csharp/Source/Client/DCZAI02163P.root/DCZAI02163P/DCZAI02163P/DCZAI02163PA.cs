using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/30 不具合対応[5713],[5714]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 在庫未出荷一覧表印刷クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫未出荷一覧表の印刷を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.07.17 30416 長沼 賢二</br>
    /// <br>           : 2008/10/06       照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009/03/17 30452 上野 俊治</br>
    /// <br>            ・障害対応12706</br>
    /// </remarks>
	class DCZAI02163PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
		/// 在庫未出荷一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫未出荷一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02163PA()
		{
		}

		/// <summary>
		/// 在庫未出荷一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 在庫未出荷一覧表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02163PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockNoShipmentListCndtn = this._printInfo.jyoken as StockNoShipmentListCndtn;
		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        //--- DEL 2008/07/17 ---------->>>>>
        //private const string ct_Extr_Top		= "ＴＯＰ";
        //private const string ct_Extr_End		= "ＥＮＤ";
        //--- DEL 2008/07/17 ----------<<<<<
        //--- ADD 2008/07/17 ---------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/09/30 不具合対応[5713],[5714] "最初から"→RangeUtil.FROM_BEGIN
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/09/30 不具合対応[5713],[5714] "最後まで"→RangeUtil.TO_END
        //--- ADD 2008/07/17 ----------<<<<<
        private const string ct_RangeConst = "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private StockNoShipmentListCndtn _stockNoShipmentListCndtn;		// 抽出条件クラス
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
                prtRpt.DataMember = DCZAI02165EA.ct_Tbl_StockNoShipment;
				
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
        /// <param name="rptObj"></param>
		/// <param name="commonInfo"></param>
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
			commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
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
            StockNoShipmentListCndtn extraInfo = (StockNoShipmentListCndtn)this._printInfo.jyoken;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = this._stockNoShipmentListCndtn.PrintSortDivStateTitle;
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = StockNoShipmentListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            object[] titleObj = new object[] { this._stockNoShipmentListCndtn.ReportSubTitle, "在庫未出荷一覧表" };
            instance.PageHeaderSubtitle = string.Format("{0}{1}", titleObj);

			// その他データ
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

            // 対象年月 ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;

            // 開始･終了のいずれかが入力されていれば印字
            if ((this._stockNoShipmentListCndtn.St_AddUpYearMonth != DateTime.MinValue) || (this._stockNoShipmentListCndtn.Ed_AddUpYearMonth != DateTime.MinValue))
            {
                // 開始
                if (this._stockNoShipmentListCndtn.St_AddUpYearMonth != DateTime.MinValue)
                    //st_ShipArrivalDate = this._stockNoShipmentListCndtn.St_AddUpYearMonth.ToString("yyyy年MM月");     //DEL 2008/10/06 書式変更
                    st_ShipArrivalDate = this._stockNoShipmentListCndtn.St_AddUpYearMonth.ToString("yyyy/MM");          //ADD 2008/10/06
                else
                    st_ShipArrivalDate = ct_Extr_Top;
                // 終了
                if (this._stockNoShipmentListCndtn.Ed_AddUpYearMonth != DateTime.MinValue)
                    //ed_ShipArrivalDate = this._stockNoShipmentListCndtn.Ed_AddUpYearMonth.ToString("yyyy年MM月");     //DEL 2008/10/06 書式変更
                    ed_ShipArrivalDate = this._stockNoShipmentListCndtn.Ed_AddUpYearMonth.ToString("yyyy/MM");          //ADD 2008/10/06
                else
                    ed_ShipArrivalDate = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        "対象年月" + ct_RangeConst,   // MOD 2008/10/02 不具合対応[5711] "処理月："→"対象年月"
                        st_ShipArrivalDate,
                        ed_ShipArrivalDate));
            }

            // 在庫登録日 ----------------------------------------------------------------------------------------------------
            this.EditCondition( ref addConditions, String.Format( "在庫登録日：{0}{1}",
                                                                    //this._stockNoShipmentListCndtn.StockCreateDate.ToString( "yyyy年MM月dd日" ),      //DEL 2008/10/06 書式変更
                                                                    this._stockNoShipmentListCndtn.StockCreateDate.ToString("yyyy/MM/dd"),
                                                                    this._stockNoShipmentListCndtn.StockCreateDateDivStateTitle));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ソート順 ----------------------------------------------------------------------------------------------------
            //this.EditCondition(ref addConditions, String.Format("ソート順：{0}",
            //                                                        this._stockNoShipmentListCndtn.PrintSortDivStateTitle));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 倉庫
            // DEL 2008/09/30 不具合対応[5513],[5714]↓
            //if ( this._stockNoShipmentListCndtn.St_WarehouseCode != string.Empty || this._stockNoShipmentListCndtn.Ed_WarehouseCode != string.Empty )
            if (!RangeUtil.WarehouseCode.IsAllRange(this._stockNoShipmentListCndtn.St_WarehouseCode, this._stockNoShipmentListCndtn.Ed_WarehouseCode))  // ADD 2008/09/29 不具合対応[5713],[5714]
            {
                // DEL 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                //string st_WarehouseCode = this._stockNoShipmentListCndtn.St_WarehouseCode;
                //string ed_WarehouseCode = this._stockNoShipmentListCndtn.Ed_WarehouseCode;

                //if ( st_WarehouseCode == string.Empty )
                //    st_WarehouseCode = ct_Extr_Top;
                //if ( ed_WarehouseCode == string.Empty )
                //    ed_WarehouseCode = ct_Extr_End;

                //this.EditCondition(ref addConditions,
                //                    string.Format("倉庫" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
                // DEL 2008/09/30 不具合対応[5713],[5714]----------<<<<<

                // ADD 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                string start= RangeUtil.WarehouseCode.GetStartString(this._stockNoShipmentListCndtn.St_WarehouseCode);
                string end  = RangeUtil.WarehouseCode.GetEndString(this._stockNoShipmentListCndtn.Ed_WarehouseCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("倉庫" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 不具合対応[5713],[5714]----------<<<<<
            }

            // 仕入先
            // DEL 2008/09/30 不具合対応[5713],[5714]↓
            //if (this._stockNoShipmentListCndtn.St_CustomerCode != 0 || this._stockNoShipmentListCndtn.Ed_CustomerCode != 999999) 
            if (!RangeUtil.SupplierCode.IsAllRange(this._stockNoShipmentListCndtn.St_CustomerCode, this._stockNoShipmentListCndtn.Ed_CustomerCode)) // ADD 2008/09/29 不具合対応[5713],[5714]
            {
                // DEL 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                //this.EditCondition(
                //    ref addConditions,
                //    string.Format( "仕入先" + ct_RangeConst,
                //                    this._stockNoShipmentListCndtn.St_CustomerCode,
                //                    this._stockNoShipmentListCndtn.Ed_CustomerCode ) );
                // DEL 2008/09/30 不具合対応[5713],[5714]----------<<<<<

                // ADD 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                string start= RangeUtil.SupplierCode.GetStartString(this._stockNoShipmentListCndtn.St_CustomerCode);
                string end  = RangeUtil.SupplierCode.GetEndString(this._stockNoShipmentListCndtn.Ed_CustomerCode);

                EditCondition(
                    ref addConditions,
                    string.Format("仕入先" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 不具合対応[5713],[5714]----------<<<<<
            }

            // メーカー
            // DEL 2008/09/30 不具合対応[5713],[5714]↓
            //if ( this._stockNoShipmentListCndtn.St_GoodsMakerCd != 0 || this._stockNoShipmentListCndtn.Ed_GoodsMakerCd != 999999 )
            if (!RangeUtil.GoodsMakerCode.IsAllRange(this._stockNoShipmentListCndtn.St_GoodsMakerCd, this._stockNoShipmentListCndtn.Ed_GoodsMakerCd))   // ADD 2008/09/29 不具合対応[5713],[5714]
            {
                // DEL 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                
                //this.EditCondition(
                //    ref addConditions,
                //    string.Format( "メーカー" + ct_RangeConst,
                //                    this._stockNoShipmentListCndtn.St_GoodsMakerCd,
                //                    this._stockNoShipmentListCndtn.Ed_GoodsMakerCd ) );
                // DEL 2008/09/30 不具合対応[5713],[5714]----------<<<<<

                // ADD 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                string start= RangeUtil.GoodsMakerCode.GetStartString(this._stockNoShipmentListCndtn.St_GoodsMakerCd);
                string end  = RangeUtil.GoodsMakerCode.GetEndString(this._stockNoShipmentListCndtn.Ed_GoodsMakerCd);

                this.EditCondition(
                    ref addConditions,
                    string.Format("メーカー" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 不具合対応[5713],[5714]----------<<<<<

            }

            // 棚番
            if ( this._stockNoShipmentListCndtn.St_WarehouseShelfNo != string.Empty || this._stockNoShipmentListCndtn.Ed_WarehouseShelfNo != string.Empty )
            {
                string st_WarehouseShelfNo = this._stockNoShipmentListCndtn.St_WarehouseShelfNo;
                string ed_WarehouseShelfNo = this._stockNoShipmentListCndtn.Ed_WarehouseShelfNo;

                if ( st_WarehouseShelfNo == string.Empty )
                    st_WarehouseShelfNo = ct_Extr_Top;
                if ( ed_WarehouseShelfNo == string.Empty )
                    ed_WarehouseShelfNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    //string.Format("倉庫棚番" + ct_RangeConst, st_WarehouseShelfNo, ed_WarehouseShelfNo));     // DEL 2008.07.17
                    string.Format( "棚番" + ct_RangeConst, st_WarehouseShelfNo, ed_WarehouseShelfNo ) );        // ADD 2008.07.17
            }

            // ADD 2008/09/30 不具合対応[5712]---------->>>>>
            // 商品大分類
            if (!RangeUtil.GoodsLGroupCode.IsAllRange(this._stockNoShipmentListCndtn.St_LargeGoodsGanreCode, this._stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode))
            {
                string start= RangeUtil.GoodsLGroupCode.GetStartString(this._stockNoShipmentListCndtn.St_LargeGoodsGanreCode);
                string end  = RangeUtil.GoodsLGroupCode.GetEndString(this._stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("商品大分類" + ct_RangeConst, start, end)
                );
            }

            // 商品中分類
            if (!RangeUtil.GoodsMGroupCode.IsAllRange(this._stockNoShipmentListCndtn.St_MediumGoodsGanreCode, this._stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode))
            {
                string start= RangeUtil.GoodsMGroupCode.GetStartString(this._stockNoShipmentListCndtn.St_MediumGoodsGanreCode);
                string end  = RangeUtil.GoodsMGroupCode.GetEndString(this._stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("商品中分類" + ct_RangeConst, start, end)
                );
            }

            // グループコード
            if (!RangeUtil.BLGroupCode.IsAllRange(this._stockNoShipmentListCndtn.St_DetailGoodsGanreCode, this._stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode))
            {
                string start= RangeUtil.BLGroupCode.GetStartString(this._stockNoShipmentListCndtn.St_DetailGoodsGanreCode);
                string end  = RangeUtil.BLGroupCode.GetEndString(this._stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("グループコード" + ct_RangeConst, start, end)
                );
            }

            // 商品区分
            if (!RangeUtil.EnterpriseGanreCode.IsAllRange(this._stockNoShipmentListCndtn.St_EnterpriseGanreCode, this._stockNoShipmentListCndtn.Ed_EnterpriseGanreCode))
            {
                string start= RangeUtil.EnterpriseGanreCode.GetStartString(this._stockNoShipmentListCndtn.St_EnterpriseGanreCode);
                string end  = RangeUtil.EnterpriseGanreCode.GetEndString(this._stockNoShipmentListCndtn.Ed_EnterpriseGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("商品区分" + ct_RangeConst, start, end)
                );
            }

            // ADD 2008/09/30 不具合対応[5712]----------<<<<<

            // ＢＬコード
            // DEL 2008/09/30 不具合対応[5713],[5714]↓
            //if ( this._stockNoShipmentListCndtn.St_BLGoodsCode != 0 || this._stockNoShipmentListCndtn.Ed_BLGoodsCode != 99999999 )
            if (!RangeUtil.BLGoodsCode.IsAllRange(this._stockNoShipmentListCndtn.St_BLGoodsCode, this._stockNoShipmentListCndtn.Ed_BLGoodsCode))    // ADD 2008/09/29 不具合対応[5713],[5714]
            {
                // DEL 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                //this.EditCondition(
                //    ref addConditions,
                //    //string.Format("ＢＬ商品コード" + ct_RangeConst,       // DEL 2008.07.17
                //    string.Format( "ＢＬコード" + ct_RangeConst,            // ADD 2008.07.17
                //                    this._stockNoShipmentListCndtn.St_BLGoodsCode,
                //                    this._stockNoShipmentListCndtn.Ed_BLGoodsCode ) );
                // DEL 2008/09/30 不具合対応[5713],[5714]----------<<<<<

                // ADD 2008/09/30 不具合対応[5713],[5714]---------->>>>>
                string start= RangeUtil.BLGoodsCode.GetStartString(this._stockNoShipmentListCndtn.St_BLGoodsCode);
                string end  = RangeUtil.BLGoodsCode.GetEndString(this._stockNoShipmentListCndtn.Ed_BLGoodsCode);

                EditCondition(
                    ref addConditions,
                    string.Format("ＢＬコード" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 不具合対応[5713],[5714]----------<<<<<
            }

            // 品番
            if ( this._stockNoShipmentListCndtn.St_GoodsNo != string.Empty || this._stockNoShipmentListCndtn.Ed_GoodsNo != string.Empty )
            {
                string st_GoodsNo = this._stockNoShipmentListCndtn.St_GoodsNo;
                string ed_GoodsNo = this._stockNoShipmentListCndtn.Ed_GoodsNo;

                if ( st_GoodsNo == string.Empty )
                    st_GoodsNo = ct_Extr_Top;
                if ( ed_GoodsNo == string.Empty )
                    ed_GoodsNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    //string.Format("商品番号" + ct_RangeConst, st_GoodsNo, ed_GoodsNo));       // DEL 2008.07.17
                    string.Format( "品番" + ct_RangeConst, st_GoodsNo, ed_GoodsNo ) );          // ADD 2008.07.17
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2008/10/08 不具合対応[6289]---------->>>>>
            // 管理区分1
            if ((this._stockNoShipmentListCndtn.PartsManagementDivide1 != null)
                    &&
                (this._stockNoShipmentListCndtn.PartsManagementDivide1.Length > 0)
            )
            {
                StringBuilder partsMngDiv1 = new StringBuilder("管理区分1：");  // LITERAL:
                Array.Sort<string>(this._stockNoShipmentListCndtn.PartsManagementDivide1);
                foreach (string partsMngDiv1Item in this._stockNoShipmentListCndtn.PartsManagementDivide1)
                {
                    partsMngDiv1.Append(partsMngDiv1Item);
                }

                EditCondition(ref addConditions, partsMngDiv1.ToString());
            }

            // 管理区分2
            if ((this._stockNoShipmentListCndtn.PartsManagementDivide2 != null)
                    &&
                (this._stockNoShipmentListCndtn.PartsManagementDivide2.Length > 0)
            )
            {
                StringBuilder partsMngDiv2 = new StringBuilder("管理区分2：");  // LITERAL:
                Array.Sort<string>(this._stockNoShipmentListCndtn.PartsManagementDivide2);
                foreach (string partsMngDiv2Item in this._stockNoShipmentListCndtn.PartsManagementDivide2)
                {
                    partsMngDiv2.Append(partsMngDiv2Item);
                }

                EditCondition(ref addConditions, partsMngDiv2.ToString());
            }
            // ADD 2008/10/08 不具合対応[6289]----------<<<<<

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
			return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
