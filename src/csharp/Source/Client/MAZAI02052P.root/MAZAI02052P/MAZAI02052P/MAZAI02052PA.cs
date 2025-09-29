//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫仕入確認表
// プログラム概要   : 在庫仕入確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : amami
// 作 成 日  2007/03/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/10/04  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/01/24  修正内容 : DC.NS対応（不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/07  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/23  修正内容 : 不具合対応[10420]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 不具合対応[13059]
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 楊善娟
// 修 正 日  2017/09/11 修正内容 : ハンディ対応（2次）在庫補充情報の印刷を可能対応
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
	/// 在庫調整確認表印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫調整確認表の印刷を行う。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.03.15</br>
    /// <br>UpdateNote : 2007.10.04 980035 金沢 貞義</br>
    /// <br>             ・ DC.NS対応</br>
    /// <br>UpdateNote : 2008.01.24 980035 金沢 貞義</br>
    /// <br>			 ・ DC.NS対応（不具合対応）</br>
    /// <br>UpdateNote : 2008/10/07        照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// <br>             2009/01/23        照田 貴志　不具合対応[10420]</br>
    /// <br>Update Note: 2009/04/07 30452 上野 俊治</br>
    /// <br>            ・障害対応13059</br>
    /// <br>Update Note: 2017/09/11 3H 楊善娟</br>
    /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
    /// <br>             在庫補充情報の印刷を可能対応</br>
    /// </remarks>
	class MAZAI02052PA: IPrintProc
	{

		# region Constructor
		/// <summary>
		/// 在庫調整確認表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public MAZAI02052PA()
		{
		}

		/// <summary>
		/// 在庫調整確認表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public MAZAI02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._confirmStockAdjustListCndtn = this._printInfo.jyoken as ConfirmStockAdjustListCndtn;
		}
		# endregion

		# region Pricate Const
		/// <summary> 印刷フォームネームスペース </summary>
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		/// <summary> スペース(印刷用) </summary>
		private const string ct_Space = "　";
		/// <summary> 開始 抽出範囲初期値(印刷用) </summary>
        //private const string ct_Extr_Top = "ＴＯＰ";          // DEL 2008.07.08
        private const string ct_Extr_Top = "最初から";          // ADD 2008.07.08
        /// <summary> 終了 抽出範囲初期値(印刷用) </summary>
        //private const string ct_Extr_End = "ＥＮＤ";          // DEL 2008.07.08
        private const string ct_Extr_End = "最後まで";          // ADD 2008.07.08
        # endregion

		# region Private Member
		/// <summary> 印刷情報クラス </summary>
		private SFCMN06002C _printInfo;
		/// <summary> 抽出条件クラス </summary>
		private ConfirmStockAdjustListCndtn _confirmStockAdjustListCndtn;
		# endregion

		# region Exception Class
		/// <summary> 例外クラス </summary>
        private class ConfirmStockAdjustException: ApplicationException
		{
			private int _status;
			# region Constructor
			/// <summary>
			/// 例外クラスコンストラクタ
			/// </summary>
			/// <param name="message">メッセージ</param>
			/// <param name="status">ステータス</param>
			public ConfirmStockAdjustException(string message, int status) : base(message)
			{
				this._status = status; 
			}
			# endregion
    
			# region Public Property
			/// <summary> ステータスプロパティ </summary>
			public int Status
			{
				get{ return this._status; }
			}
			# endregion
		}
		# endregion
		


		# region IPrintProc インターフェース
		# region Public Property
		/// <summary>
		/// 印刷情報取得プロパティ
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		# endregion

		# region Public Method
		/// <summary>
		/// 印刷処理開始
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷を開始する。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public int StartPrint()
		{
			// 印刷処理
			return PrintMain();
		}
		# endregion
		# endregion 

		# region Private Method
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行う。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// 印刷フォームクラスインスタンス作成
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// 各種ActiveReport帳票インスタンス作成
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// 各種プロパティ設定
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// データソース設定
				prtRpt.DataSource = (DataView)this._printInfo.rdData;
                prtRpt.DataMember = MAZAI02054EA.ct_Tbl_StockAdjustDtl;
				
				// 印刷共通情報プロパティ設定
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
			    this.SetPrintCommonInfo(out commonInfo);

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

		/// <summary>
		/// 各種ActiveReport帳票インスタンス作成
		/// </summary>
		/// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
		/// <param name="prpid">帳票フォームID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// 印刷フォームクラスインスタンス作成
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}

		/// <summary>
		/// レポートアセンブリインスタンス化
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
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
				throw new ConfirmStockAdjustException(asmname + "が存在しません。", -1);
			}
			catch(System.Exception er)
			{
				throw new ConfirmStockAdjustException(er.Message, -1);
			}
			return obj;
		}

		/// <summary>
		/// 印刷画面共通情報設定
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
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
			//commonInfo.PrintMax    = 0;                                           //DEL 2009/01/23 不具合対応[10420]
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;       //ADD 2009/01/23 不具合対応[10420]
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// 上余白
			commonInfo.MarginsTop  = this._printInfo.py;
			// 左余白
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		/// <summary>
		/// 各種プロパティ設定
		/// </summary>
		/// <param name="rpt">インスタンス化された帳票フォームクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 各種プロパティを設定します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// 印刷条件取得
            ConfirmStockAdjustListCndtn extraInfo = (ConfirmStockAdjustListCndtn)this._printInfo.jyoken;

			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet;
			string message;
			int st = StockAdjustListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new ConfirmStockAdjustException(message, status);
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
			instance.PageHeaderSubtitle = this._confirmStockAdjustListCndtn.PrintDivName;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		/// <summary>
		/// 抽出条件出力情報作成
		/// </summary>
		/// <param name="extraConditions">作成後抽出条件コレクション</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を作成する。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
        /// <br>Update Note: 2017/09/11 3H 楊善娟</br>
        /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
        /// <br>             在庫補充情報の印刷を可能対応</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "：{0} ～ {1}";
			extraConditions = new StringCollection();

			// --- 調整日付 --- //
			string st_AdjustDate = string.Empty;
			string ed_AdjustDate = string.Empty;
            
            //--- ADD 2008/07/08 ---------->>>>>
            // --- 入力日付 --- //
            string st_InputDay = string.Empty;
            string ed_InputDay = string.Empty;
            //--- ADD 2008/07/08 ----------<<<<<

            // 開始
			if (this._confirmStockAdjustListCndtn.St_AdjustDate != DateTime.MinValue)
				st_AdjustDate = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.St_AdjustDate);
			else
				st_AdjustDate = ct_Extr_Top;
			// 終了
			if (this._confirmStockAdjustListCndtn.Ed_AdjustDate != DateTime.MinValue)
				ed_AdjustDate = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.Ed_AdjustDate);
			else
				ed_AdjustDate = ct_Extr_End;
            /* --- DEL 2008/10/07 文言変更 ---------------------------------------------------------------------------------------------------->>>>>
            //this.EditCondition(ref extraConditions, string.Format("調整日付　" + ct_RangeConst, st_AdjustDate, ed_AdjustDate)); // DEL 2008/09/26
            this.EditCondition(ref extraConditions, string.Format("仕入日付　" + ct_RangeConst, st_AdjustDate, ed_AdjustDate));
               --- DEL 2008/10/07 -------------------------------------------------------------------------------------------------------------<<<<< */
            if (st_AdjustDate != ct_Extr_Top || ed_AdjustDate != ct_Extr_End) // ADD 2009/04/07
            {
                this.EditCondition(ref extraConditions, string.Format("仕入日　" + ct_RangeConst, st_AdjustDate, ed_AdjustDate));   //ADD 2008/10/07
            }
            //--- ADD 2008/07/08 ---------->>>>>
            // 開始
            if (this._confirmStockAdjustListCndtn.St_InputDay != DateTime.MinValue)
                st_InputDay = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.St_InputDay);
            else
                st_InputDay = ct_Extr_Top; // ADD 2009/04/07
            // 終了
            if (this._confirmStockAdjustListCndtn.Ed_InputDay != DateTime.MinValue)
                ed_InputDay = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.Ed_InputDay);
            else
                ed_InputDay = ct_Extr_End; // ADD 2009/04/07

            //if(st_InputDay != string.Empty && ed_InputDay != string.Empty) // DEL 2009/04/07
            if (st_InputDay != ct_Extr_Top || ed_InputDay != ct_Extr_End) // ADD 2009/04/07
                //this.EditCondition(ref extraConditions, string.Format("入力日付　" + ct_RangeConst, st_InputDay, ed_InputDay));   //DEL 2008/10/07 文言変更
                this.EditCondition(ref extraConditions, string.Format("入力日　" + ct_RangeConst, st_InputDay, ed_InputDay));       //ADD 2008/10/07
            //--- ADD 2008/07/08 ----------<<<<<

			StringCollection addConditions = new StringCollection();

            //--- DEL 2008/07/08 ---------->>>>>
			// --- 調整伝票番号 --- //
            //if ((this._confirmStockAdjustListCndtn.St_StockAdjustSlipNo != 0) || (this._confirmStockAdjustListCndtn.Ed_StockAdjustSlipNo != 999999999))
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "調整伝票番号：{0} ～ {1}",
            //            String.Format("{0:D9}", this._confirmStockAdjustListCndtn.St_StockAdjustSlipNo),
            //            String.Format("{0:D9}", this._confirmStockAdjustListCndtn.Ed_StockAdjustSlipNo) 
            //        )
            //    );
            //}
            //--- DEL 2008/07/08 ----------<<<<<

            //--- DEL 2008/07/08 ---------->>>>>
            //// --- メーカーコード --- //
            //// 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
            ////if ((this._confirmStockAdjustListCndtn.St_MakerCode != 0) || (this._confirmStockAdjustListCndtn.Ed_MakerCode != 999))
            //if ((this._confirmStockAdjustListCndtn.St_GoodsMakerCd != 0) || (this._confirmStockAdjustListCndtn.Ed_GoodsMakerCd != 999999))
            //// 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "メーカーコード：{0} ～ {1}",
            //            // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
            //            //String.Format("{0:D}", this._confirmStockAdjustListCndtn.St_MakerCode),
            //            //String.Format("{0:D}", this._confirmStockAdjustListCndtn.Ed_MakerCode)
            //            String.Format("{0:D}", this._confirmStockAdjustListCndtn.St_GoodsMakerCd),
            //            String.Format("{0:D}", this._confirmStockAdjustListCndtn.Ed_GoodsMakerCd)
            //            // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
            //        )
            //    );
            //}
            //--- DEL 2008/07/08 ----------<<<<<

			// --- 商品コード --- //
            // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
			//if ((this._confirmStockAdjustListCndtn.St_GoodsCode != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_GoodsCode != string.Empty))
			//{
			//	this.EditCondition( ref addConditions, 
			//		this.GetConditionRange( "商品コード", this._confirmStockAdjustListCndtn.St_GoodsCode, this._confirmStockAdjustListCndtn.Ed_GoodsCode));
			//}
            // 2009.02.16 30413 犬飼 商品コードは抽出条件に無いので削除 >>>>>>START
            //if ((this._confirmStockAdjustListCndtn.St_GoodsNo != string.Empty) || (this._confirmStockAdjustListCndtn.Ed_GoodsNo != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        this.GetConditionRange("商品コード", this._confirmStockAdjustListCndtn.St_GoodsNo, this._confirmStockAdjustListCndtn.Ed_GoodsNo));
            //}
            // 2009.02.16 30413 犬飼 商品コードは抽出条件に無いので削除 <<<<<<END
            // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
            //// --- 製造番号 --- //
            //if ((this._confirmStockAdjustListCndtn.St_ProductNumber != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_ProductNumber != string.Empty))
			//{
			//	this.EditCondition( ref addConditions, 
            //		this.GetConditionRange( "製造番号", this._confirmStockAdjustListCndtn.St_ProductNumber, this._confirmStockAdjustListCndtn.Ed_ProductNumber));
            //}
            //
            //// --- 電話番号 --- //
            //if ((this._confirmStockAdjustListCndtn.St_StockTelNo1 != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_StockTelNo1 != string.Empty))
            //{
            //	this.EditCondition( ref addConditions, 
            //		this.GetConditionRange( "電話番号", this._confirmStockAdjustListCndtn.St_StockTelNo1, this._confirmStockAdjustListCndtn.Ed_StockTelNo1));
            //}
            // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

            // 2009.02.16 30413 犬飼 倉庫、担当者、発行タイプの順に抽出条件を印字するように修正 >>>>>>START
            // 2008.01.24 修正 >>>>>>>>>>>>>>>>>>>>
            // --- 倉庫コード --- //
            if ((this._confirmStockAdjustListCndtn.St_WarehouseCode != string.Empty) || (this._confirmStockAdjustListCndtn.Ed_WarehouseCode != string.Empty))
            {
                this.EditCondition(ref addConditions,
                    //this.GetConditionRange("倉庫コード", this._confirmStockAdjustListCndtn.St_WarehouseCode, this._confirmStockAdjustListCndtn.Ed_WarehouseCode)); // DEL 2008/09/26
                    this.GetConditionRange("倉庫", this._confirmStockAdjustListCndtn.St_WarehouseCode, this._confirmStockAdjustListCndtn.Ed_WarehouseCode));

            }
            // 2008.01.24 修正 <<<<<<<<<<<<<<<<<<<<

			// --- 担当者コード --- //
			if ((this._confirmStockAdjustListCndtn.St_InputAgenCd != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_InputAgenCd != string.Empty))
			{
				this.EditCondition( ref addConditions,
                    //this.GetConditionRange( "入力担当者コード", this._confirmStockAdjustListCndtn.St_InputAgenCd, this._confirmStockAdjustListCndtn.Ed_InputAgenCd)); // DEL 2008/09/26
                    this.GetConditionRange( "入力担当者", this._confirmStockAdjustListCndtn.St_InputAgenCd, this._confirmStockAdjustListCndtn.Ed_InputAgenCd));
			}

            // --- 発行タイプ --- //
            if (this._confirmStockAdjustListCndtn.AcPaySlipCd == null)
            {
                // 全て
                this.EditCondition(ref addConditions, "発行タイプ：全て");
            }
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 13)
            {
                // 在庫仕入入力分
                this.EditCondition(ref addConditions, "発行タイプ：在庫仕入入力分");
            }
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 50)
            {
                // 棚卸調整分
                this.EditCondition(ref addConditions, "発行タイプ：棚卸調整分");
            }
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 42)
            {
                // マスメン調整分
                this.EditCondition(ref addConditions, "発行タイプ：マスメン調整分");
            }
            // 2009.02.16 30413 犬飼 倉庫、担当者、発行タイプの順に抽出条件を印字するように修正 <<<<<<END
            // --- ADD 3H 楊善娟 2017/09/11---------->>>>>
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 70)
            {
                // 委託在庫補充分
                this.EditCondition(ref addConditions, "発行タイプ：委託在庫補充分");
            }
            // --- ADD 3H 楊善娟 2017/09/11----------<<<<<
			foreach (string exCondStr in addConditions)
			{
				extraConditions.Add(exCondStr);
			}
		}

		/// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
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
				result = String.Format(title + "： {0} ～ {1}", start, end);
			}
			return result;
		}

		/// <summary>
		/// 抽出条件文字列編集
		/// </summary>
		/// <param name="editArea">格納エリア</param>
		/// <param name="target">対象文字列</param>
		/// <remarks>
		/// <br>Note       : 出力する抽出条件文字列を編集します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
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
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAHNB02012P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
	}
}
