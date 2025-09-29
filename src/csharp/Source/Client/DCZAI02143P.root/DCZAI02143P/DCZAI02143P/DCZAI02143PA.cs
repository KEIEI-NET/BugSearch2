//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫分析順位表
// プログラム概要   : 在庫分析順位表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/30  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/17  修正内容 : 障害対応12707
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12783]
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
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
    /// <br>Update     : 2008/09/30 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009/03/17 30452 上野 俊治</br>
    /// <br>            ・障害対応12707</br>
    /// <br>           : 2009/03/27 照田 貴志　不具合対応[12783]</br>
	/// </remarks>
	class DCZAI02143PA: IPrintProc
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
		public DCZAI02143PA()
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
		public DCZAI02143PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockAnalysisOrderListCndtn = this._printInfo.jyoken as StockAnalysisOrderListCndtn;
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
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        //--- ADD 2008/07/17 ----------<<<<<
        private const string ct_RangeConst = "：{0} ～ {1}";
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					// 印刷情報クラス
		private StockAnalysisOrderListCndtn _stockAnalysisOrderListCndtn;		// 抽出条件クラス
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
                prtRpt.DataMember = DCZAI02145EA.ct_Tbl_StockAnalysisOrder;
				

				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt ,out commonInfo); // ADD 2009/03/17

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
            StockAnalysisOrderListCndtn extraInfo = (StockAnalysisOrderListCndtn)this._printInfo.jyoken;

			// ソート順プロパティ設定
			instance.PageHeaderSortOderTitle = this._stockAnalysisOrderListCndtn.OrderPrintTypeStateTitle;
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = StockAnalysisOrderListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            object[] titleObj = new object[]{"在庫分析順位表"};
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

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

           
            // 対象年月 ----------------------------------------------------------------------------------------------------
            string st_AnalysisOrderDate = string.Empty;
            string ed_AnalysisOrderDate = string.Empty;
            //string dateFormat = "yyyy年MM月";         //DEL 2008/09/30 書式変更
            string dateFormat = "yyyy/MM";              //ADD 2008/09/30

            // 開始･終了のいずれかが入力されていれば印字
            if ( ( this._stockAnalysisOrderListCndtn.St_AddUpYearMonth != DateTime.MinValue ) || ( this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth != DateTime.MinValue ) ) {
                // 開始
                if ( this._stockAnalysisOrderListCndtn.St_AddUpYearMonth != DateTime.MinValue )
                    st_AnalysisOrderDate = this._stockAnalysisOrderListCndtn.St_AddUpYearMonth.ToString(dateFormat);
                else
                    st_AnalysisOrderDate = ct_Extr_Top;
                // 終了
                if ( this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth != DateTime.MinValue )
                    ed_AnalysisOrderDate = this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth.ToString(dateFormat);
                else
                    ed_AnalysisOrderDate = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        //"処理月" + ct_RangeConst,         //DEL 2008/09/30 名称変更
                        "対象月" + ct_RangeConst,           //ADD 2008/09/30
                        st_AnalysisOrderDate,
                        ed_AnalysisOrderDate));
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 印刷タイプ --------------------------------------------------------------------------------------------------
            //this.EditCondition( ref addConditions, String.Format( "印刷順：{0}", this._stockAnalysisOrderListCndtn.OrderPrintTypeStateTitle ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 出力順位 ----------------------------------------------------------------------------------------------------
            if ( this._stockAnalysisOrderListCndtn.StockOrderMax != 0 && this._stockAnalysisOrderListCndtn.StockOrderMax != 999999999 )
            {
                this.EditCondition( ref addConditions, String.Format( "出力順位：{0} {1}位まで",
                                                                        this._stockAnalysisOrderListCndtn.StockOrderDivStateTitle,
                                                                        this._stockAnalysisOrderListCndtn.StockOrderMax.ToString() ) );
            }

            // 出力条件 ----------------------------------------------------------------------------------------------------
            //if ( this._stockAnalysisOrderListCndtn.St_ShipmentCnt != 0 || this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999 )                 //DEL 2008/09/30 Int→Double、マイナス可の為
            if ( this._stockAnalysisOrderListCndtn.St_ShipmentCnt != -999999999.99 || this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999.99 )    //ADD 2008/09/30
            {
                string shipmentCntCndtnText = "出力条件：";
                //if ( this._stockAnalysisOrderListCndtn.St_ShipmentCnt != 0 )                  //DEL 2008/09/30 Int→Double、マイナス可の為
                if (this._stockAnalysisOrderListCndtn.St_ShipmentCnt != -999999999.99)          //ADD 2008/09/30
                {
                    shipmentCntCndtnText += string.Format( "{0}個以上 ", this._stockAnalysisOrderListCndtn.St_ShipmentCnt );
                }
                //if ( this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999 )          //DEL 2008/09/30 Int→Double、マイナス可の為
                if (this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999.99)           //ADD 2008/09/30
                {
                    shipmentCntCndtnText += string.Format( "{0}個以下 ", this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt );
                }

                this.EditCondition( ref addConditions, shipmentCntCndtnText );
            }

            // 単位 --------------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, String.Format("単位：{0}", this._stockAnalysisOrderListCndtn.MoneyUnitStateTitle));


            // ---ADD 2009/03/27 不具合対応[12783] ---------------------------------------------->>>>>
            if (this._stockAnalysisOrderListCndtn.PrintTypeDiv == StockAnalysisOrderListCndtn.PrintTypeDivState.Total)
            {
                this.EditCondition(ref addConditions, "印刷タイプ：全社計");
            }
            else
            {
                this.EditCondition(ref addConditions, "印刷タイプ：倉庫別");
            }
            // ---ADD 2009/03/27 不具合対応[12783] ----------------------------------------------<<<<<

            // ADD 2008/09/30 ----------------------------------------------------------------------------------------->>>>>
            // 管理区分1
            if ((this._stockAnalysisOrderListCndtn.PartsManagementDivide1 != null) &&
                (this._stockAnalysisOrderListCndtn.PartsManagementDivide1.Length > 0))
            {
                StringBuilder partsMngDiv1 = new StringBuilder("管理区分1：");  // LITERAL:
                Array.Sort<string>(this._stockAnalysisOrderListCndtn.PartsManagementDivide1);
                foreach (string partsMngDiv1Item in this._stockAnalysisOrderListCndtn.PartsManagementDivide1)
                {
                    partsMngDiv1.Append(partsMngDiv1Item);
                }

                EditCondition(ref addConditions, partsMngDiv1.ToString());
            }

            // 管理区分2
            if ((this._stockAnalysisOrderListCndtn.PartsManagementDivide2 != null) &&
                (this._stockAnalysisOrderListCndtn.PartsManagementDivide2.Length > 0))
            {
                StringBuilder partsMngDiv2 = new StringBuilder("管理区分2：");  // LITERAL:
                Array.Sort<string>(this._stockAnalysisOrderListCndtn.PartsManagementDivide2);
                foreach (string partsMngDiv2Item in this._stockAnalysisOrderListCndtn.PartsManagementDivide2)
                {
                    partsMngDiv2.Append(partsMngDiv2Item);
                }

                EditCondition(ref addConditions, partsMngDiv2.ToString());
            }
            // ADD 2008/09/30 -----------------------------------------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 倉庫
            this.EditCondition( ref addConditions,
                this.GetConditionRange( "倉庫", this._stockAnalysisOrderListCndtn.St_WarehouseCode, this._stockAnalysisOrderListCndtn.Ed_WarehouseCode )
                );
            
            // 仕入先
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "仕入先", this._stockAnalysisOrderListCndtn.St_CustomerCode, this._stockAnalysisOrderListCndtn.Ed_CustomerCode, 999999999 )   //DEL 2008/09/30 桁数変更
                this.GetConditionRange( "仕入先", this._stockAnalysisOrderListCndtn.St_CustomerCode, this._stockAnalysisOrderListCndtn.Ed_CustomerCode, 999999 )        //ADD 2008/09/30 
                );

            // メーカー
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "メーカー", this._stockAnalysisOrderListCndtn.St_GoodsMakerCd, this._stockAnalysisOrderListCndtn.Ed_GoodsMakerCd, 999999 )    //DEL 2008/09/30 桁数変更
                this.GetConditionRange( "メーカー", this._stockAnalysisOrderListCndtn.St_GoodsMakerCd, this._stockAnalysisOrderListCndtn.Ed_GoodsMakerCd, 9999 )       //ADD 2008/09/30
                );

            // 商品区分グループ
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "商品区分グループ", this._stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode )  // DEL 2008.07.24
                this.GetConditionRange( "商品大分類", this._stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode )          // ADD 2008.07.24
                );

            // 商品区分
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("商品区分", this._stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode)          // DEL 2008.07.24
                this.GetConditionRange( "商品中分類", this._stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode )        // ADD 2008.07.24
                );
            
            // 商品詳細
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("商品区分詳細", this._stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode)      // DEL 2008.07.24
                this.GetConditionRange( "グループコード", this._stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode )    // ADD 2008.07.24
                );

            // ＢＬ商品コード
            this.EditCondition( ref addConditions,
                /* --- DEL 2008/09/30 桁数変更 ------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                //this.GetConditionRange("ＢＬ商品コード", this._stockAnalysisOrderListCndtn.St_BLGoodsCode, this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode, 99999999)            // DEL 2008.07.24
                this.GetConditionRange( "ＢＬコード", this._stockAnalysisOrderListCndtn.St_BLGoodsCode, this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode, 99999999 )                // ADD 2008.07.24
                   --- DEL 2008/09/30 ----------------------------------------------------------------------------------------------------------------------------------------------------------<<<<< */
                this.GetConditionRange("ＢＬコード", this._stockAnalysisOrderListCndtn.St_BLGoodsCode, this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode, 99999)                    // ADD 2008/09/30
                );

            // 倉庫棚番
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("倉庫棚番", this._stockAnalysisOrderListCndtn.St_WarehouseShelfNo, this._stockAnalysisOrderListCndtn.Ed_WarehouseShelfNo)                  // DEL 2008.07.24
                this.GetConditionRange( "棚番", this._stockAnalysisOrderListCndtn.St_WarehouseShelfNo, this._stockAnalysisOrderListCndtn.Ed_WarehouseShelfNo )                      // ADD 2008.07.24
                );

            // 商品番号
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("商品番号", this._stockAnalysisOrderListCndtn.St_GoodsNo, this._stockAnalysisOrderListCndtn.Ed_GoodsNo)    // DEL 2008.07.24
                this.GetConditionRange( "品番", this._stockAnalysisOrderListCndtn.St_GoodsNo, this._stockAnalysisOrderListCndtn.Ed_GoodsNo )        // ADD 2008.07.24
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
            if ( (startCode != 0) || (endCode != endMax) )
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startCode != 0 )
                    //start = startCode.ToString().TrimEnd();                                       //DEL 2008/09/30 ゼロ詰めの為
                    start = startCode.ToString().TrimEnd().PadLeft(endMax.ToString().Length,'0');   //ADD 2008/09/30
                if (endCode != endMax)
                    //end = endCode.ToString().TrimEnd();                                           //DEL 2008/09/30 ゼロ詰めの為
                    end = endCode.ToString().TrimEnd().PadLeft(endMax.ToString().Length,'0');       //ADD 2008/09/30
                result = String.Format(title + ct_RangeConst, start, end);
            }

            // --- ADD 2008/09/30 ------------------------------------------------------->>>>>
            // "最初から ～ 最後まで"となる場合、出力しない
            if ((startCode.Equals(ct_Extr_Top)) && (endCode.Equals(ct_Extr_End)))
            {
                result = string.Empty;
            }
            // --- ADD 2008/09/30 -------------------------------------------------------<<<<<

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
			return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
