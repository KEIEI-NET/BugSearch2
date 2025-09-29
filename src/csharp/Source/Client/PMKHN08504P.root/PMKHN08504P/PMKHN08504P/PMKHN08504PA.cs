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
	/// マスタエクスポートインポート（基本用）クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : マスタエクスポートインポート（基本用）の印刷を行う。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.30</br>
    /// </remarks>
	class PMKHN08504PA: IPrintProc
	{

		#region ■ Constructor
		/// <summary>
        /// マスタエクスポートインポート（基本用）クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : マスタエクスポートインポート（基本用）クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public PMKHN08504PA()
		{
		}

		/// <summary>
        /// マスタエクスポートインポート（基本用）クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
        /// <br>Note       : マスタエクスポートインポート（基本用）クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
        public PMKHN08504PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    this._warehousePrintWork = (WarehousePrintWork)this._printInfo.jyoken;
                    break;
                case USERGD_PGID:
                    this._userGdPrintWork = (UserGdPrintWork)this._printInfo.jyoken;
                    break;
                case NOTEGUID_PGID:
                    this._noteGuidPrintWork = (NoteGuidPrintWork)this._printInfo.jyoken;
                    break;
                case BLGOODSCD_PGID:
                    this._bLGoodsCdPrintWork = (BLGoodsCdPrintWork)this._printInfo.jyoken;
                    break;
                case MAKER_PGID:
                    this._makerPrintWork = (MakerPrintWork)this._printInfo.jyoken;
                    break;
                case GOODSGROUP_PGID:
                    this._goodsGroupPrintWork = (GoodsGroupPrintWork)this._printInfo.jyoken;
                    break;
                case BLGROUP_PGID:
                    this._bLGroupPrintWork = (BLGroupPrintWork)this._printInfo.jyoken;
                    break;
                case ISOLISLANDPRC_PGID:
                    this._isolIslandPrcPrintWork = (IsolIslandPrcPrintWork)this._printInfo.jyoken;
                    break;
                case JOINPARTS_PGID:
                    this._joinPartsPrintWork = (JoinPartsPrintWork)this._printInfo.jyoken;
                    break;
                case PARTSSUBST_PGID:
                    this._partsSubstPrintWork = (PartsSubstPrintWork)this._printInfo.jyoken;
                    break;
                case GOODSSET_PGID:
                    this._goodsSetPrintWork = (GoodsSetPrintWork)this._printInfo.jyoken;
                    break;
                case MODELNAME_PGID:
                    this._modelNamePrintWork = (ModelNamePrintWork)this._printInfo.jyoken;
                    break;
                case PARTSPOSCODE_PGID:
                    this._partsPosCodePrintWork = (PartsPosCodePrintWork)this._printInfo.jyoken;
                    break;
            }

		}
		#endregion ■ Constructor

		#region ■ Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "　";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        private const string ct_RangeConst = "：{0} ～ {1}";

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
		#endregion ■ Pricate Const

		#region ■ Private Member
		private SFCMN06002C _printInfo;					                // 印刷情報クラス

        #region 抽出条件クラスの定義
        private WarehousePrintWork _warehousePrintWork;                 // 倉庫マスタ
        private UserGdPrintWork _userGdPrintWork;                       // ユーザガイド
        private NoteGuidPrintWork _noteGuidPrintWork;                   // 備考ガイド
        private BLGoodsCdPrintWork _bLGoodsCdPrintWork;                 // ＢＬコード
        private MakerPrintWork _makerPrintWork;                         // メーカー
        private GoodsGroupPrintWork _goodsGroupPrintWork;               // 商品中分類
        private BLGroupPrintWork _bLGroupPrintWork;                     // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
        private IsolIslandPrcPrintWork _isolIslandPrcPrintWork;         // 離島価格
        private JoinPartsPrintWork _joinPartsPrintWork;                 // 結合
        private PartsSubstPrintWork _partsSubstPrintWork;               // 代替
        private GoodsSetPrintWork _goodsSetPrintWork;                   // セット
        private ModelNamePrintWork _modelNamePrintWork;                 // 車種
        private PartsPosCodePrintWork _partsPosCodePrintWork;           // 部位        
        #endregion

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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
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
                //prtRpt.DataMember = PMKHN02019EA.ct_Tbl_Rate;
				
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
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
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷画面共通条件の設定を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
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
			commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// 上余白
			commonInfo.MarginsTop  = this._printInfo.py;
			// 左余白
			commonInfo.MarginsLeft = this._printInfo.px;
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReportインターフェースにキャスト
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;
			
			// 帳票出力設定情報取得 
			PrtOutSet prtOutSet = null;
            string message = "";
            int st = 0;
            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    st = WarehousePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case USERGD_PGID:
                    st = UserGdPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case NOTEGUID_PGID:
                    st = NoteGuidPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case BLGOODSCD_PGID:
                    st = BLGoodsCdPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case MAKER_PGID:
                    st = MakerPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case GOODSGROUP_PGID:
                    st = GoodsGroupPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case BLGROUP_PGID:
                    st = BLGroupPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case ISOLISLANDPRC_PGID:
                    st = IsolIslandPrcPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case JOINPARTS_PGID:
                    st = JoinPartsPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case PARTSSUBST_PGID:
                    st = PartsSubstPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case GOODSSET_PGID:
                    st = GoodsSetPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case MODELNAME_PGID:
                    st = ModelNamePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case PARTSPOSCODE_PGID:
                    st = PartsPosCodePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
            }
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
            if (this._printInfo.kidopgid.Equals(USERGD_PGID))
            {
                instance.PageHeaderSubtitle = this._printInfo.prpnm+"(" + this._userGdPrintWork.UserGuideDivName +")";
            }
            else
            {
                instance.PageHeaderSubtitle = this._printInfo.prpnm;
            }

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
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            const string dateFormat = "YYYY/MM/DD";
            string stTarget = "";
            string edTarget = "";

            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    // 削除情報
                    if (this._warehousePrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._warehousePrintWork.DeleteDateTimeSt != 0) || (this._warehousePrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._warehousePrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._warehousePrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._warehousePrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._warehousePrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }

                    // 倉庫コード
                    if (this._warehousePrintWork.WarehouseCodeSt != string.Empty || this._warehousePrintWork.WarehouseCodeEd != string.Empty)
                    {
                        stTarget = this._warehousePrintWork.WarehouseCodeSt;
                        edTarget = this._warehousePrintWork.WarehouseCodeEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("倉庫" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case USERGD_PGID:
                    // 削除情報
                    if (this._userGdPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._userGdPrintWork.DeleteDateTimeSt != 0) || (this._userGdPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._userGdPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._userGdPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._userGdPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._userGdPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ユーザコード
                    if (this._userGdPrintWork.GuideCodeSt != 0 || this._userGdPrintWork.GuideCodeEd != 0)
                    {
                        if (this._userGdPrintWork.UserGuideDivCd == 72 ||
                            this._userGdPrintWork.UserGuideDivCd == 73)
                        {
                            stTarget = this._userGdPrintWork.GuideCodeSt.ToString();
                            edTarget = this._userGdPrintWork.GuideCodeEd.ToString();
                        }
                        else
                        {
                            stTarget = this._userGdPrintWork.GuideCodeSt.ToString("0000");
                            edTarget = this._userGdPrintWork.GuideCodeEd.ToString("0000");
                        }
                        if (this._userGdPrintWork.GuideCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._userGdPrintWork.GuideCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format(this._userGdPrintWork.UserGuideDivName + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case NOTEGUID_PGID:
                    // 削除情報
                    if (this._noteGuidPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._noteGuidPrintWork.DeleteDateTimeSt != 0) || (this._noteGuidPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._noteGuidPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._noteGuidPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._noteGuidPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._noteGuidPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // 備考ガイド区分
                    if (this._noteGuidPrintWork.NoteGuideDivCodeSt != 0 || this._noteGuidPrintWork.NoteGuideDivCodeEd != 0)
                    {

                        stTarget = this._noteGuidPrintWork.NoteGuideDivCodeSt.ToString("0000");
                        edTarget = this._noteGuidPrintWork.NoteGuideDivCodeEd.ToString("0000");
                        if (this._noteGuidPrintWork.NoteGuideDivCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._noteGuidPrintWork.NoteGuideDivCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("備考ガイド区分" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case BLGOODSCD_PGID:
                    // 削除情報
                    if (this._bLGoodsCdPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._bLGoodsCdPrintWork.DeleteDateTimeSt != 0) || (this._bLGoodsCdPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._bLGoodsCdPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._bLGoodsCdPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._bLGoodsCdPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._bLGoodsCdPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // BLｺｰﾄﾞ
                    if (this._bLGoodsCdPrintWork.BLGoodsCodeSt != 0 || this._bLGoodsCdPrintWork.BLGoodsCodeEd != 0)
                    {

                        stTarget = this._bLGoodsCdPrintWork.BLGoodsCodeSt.ToString("00000");
                        edTarget = this._bLGoodsCdPrintWork.BLGoodsCodeEd.ToString("00000");
                        if (this._bLGoodsCdPrintWork.BLGoodsCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._bLGoodsCdPrintWork.BLGoodsCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("ＢＬコード" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case MAKER_PGID:
                    // 削除情報
                    if (this._makerPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._makerPrintWork.DeleteDateTimeSt != 0) || (this._makerPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._makerPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._makerPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._makerPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._makerPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // メーカーコード
                    if (this._makerPrintWork.GoodsMakerCdSt != 0 || this._makerPrintWork.GoodsMakerCdEd != 0)
                    {

                        stTarget = this._makerPrintWork.GoodsMakerCdSt.ToString("0000");
                        edTarget = this._makerPrintWork.GoodsMakerCdEd.ToString("0000");
                        if (this._makerPrintWork.GoodsMakerCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._makerPrintWork.GoodsMakerCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("メーカー" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case GOODSGROUP_PGID:
                    // 削除情報
                    if (this._goodsGroupPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._goodsGroupPrintWork.DeleteDateTimeSt != 0) || (this._goodsGroupPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._goodsGroupPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._goodsGroupPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._goodsGroupPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._goodsGroupPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }

                    // 商品中分類
                    if (this._goodsGroupPrintWork.GoodsMGroupSt != 0 || this._goodsGroupPrintWork.GoodsMGroupEd != 0)
                    {

                        stTarget = this._goodsGroupPrintWork.GoodsMGroupSt.ToString("0000");
                        edTarget = this._goodsGroupPrintWork.GoodsMGroupEd.ToString("0000");
                        if (this._goodsGroupPrintWork.GoodsMGroupSt == 0) stTarget = ct_Extr_Top;
                        if (this._goodsGroupPrintWork.GoodsMGroupEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("商品中分類" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case BLGROUP_PGID:
                    // 削除情報
                    if (this._bLGroupPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._bLGroupPrintWork.DeleteDateTimeSt != 0) || (this._bLGroupPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._bLGroupPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._bLGroupPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._bLGroupPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._bLGroupPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ｸﾞﾙｰﾌﾟコード
                    if (this._bLGroupPrintWork.BLGroupCodeSt != 0 || this._bLGroupPrintWork.BLGroupCodeEd != 0)
                    {

                        stTarget = this._bLGroupPrintWork.BLGroupCodeSt.ToString("00000");
                        edTarget = this._bLGroupPrintWork.BLGroupCodeEd.ToString("00000");
                        if (this._bLGroupPrintWork.BLGroupCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._bLGroupPrintWork.BLGroupCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("グループコード" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case ISOLISLANDPRC_PGID:
                    // 削除情報
                    if (this._isolIslandPrcPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._isolIslandPrcPrintWork.DeleteDateTimeSt != 0) || (this._isolIslandPrcPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._isolIslandPrcPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._isolIslandPrcPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._isolIslandPrcPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._isolIslandPrcPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // 拠点コード
                    if (this._isolIslandPrcPrintWork.SectionCodeSt != string.Empty || this._isolIslandPrcPrintWork.SectionCodeEd != string.Empty)
                    {
                        stTarget = this._isolIslandPrcPrintWork.SectionCodeSt;
                        edTarget = this._isolIslandPrcPrintWork.SectionCodeEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("拠点" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case JOINPARTS_PGID:
                    // 削除情報
                    if (this._joinPartsPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._joinPartsPrintWork.DeleteDateTimeSt != 0) || (this._joinPartsPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._joinPartsPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._joinPartsPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._joinPartsPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._joinPartsPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // メーカー
                    if (this._joinPartsPrintWork.JoinSourceMakerCodeSt != 0 || this._joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
                    {

                        stTarget = this._joinPartsPrintWork.JoinSourceMakerCodeSt.ToString("0000");
                        edTarget = this._joinPartsPrintWork.JoinSourceMakerCodeEd.ToString("0000");
                        if (this._joinPartsPrintWork.JoinSourceMakerCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._joinPartsPrintWork.JoinSourceMakerCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("メーカーコード" + ct_RangeConst, stTarget, edTarget));
                    }
                    // 品番
                    if (this._joinPartsPrintWork.JoinSourPartsNoWithHSt != string.Empty || this._joinPartsPrintWork.JoinSourPartsNoWithHEd != string.Empty)
                    {
                        stTarget = this._joinPartsPrintWork.JoinSourPartsNoWithHSt;
                        edTarget = this._joinPartsPrintWork.JoinSourPartsNoWithHEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("品番" + ct_RangeConst, stTarget, edTarget));

                    }
                    // 順位
                    if (this._joinPartsPrintWork.JoinDispOrderSt != 0 || this._joinPartsPrintWork.JoinDispOrderEd != 0)
                    {

                        stTarget = this._joinPartsPrintWork.JoinDispOrderSt.ToString();
                        edTarget = this._joinPartsPrintWork.JoinDispOrderEd.ToString();
                        if (this._joinPartsPrintWork.JoinDispOrderSt == 0) stTarget = ct_Extr_Top;
                        if (this._joinPartsPrintWork.JoinDispOrderEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("順位" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case PARTSSUBST_PGID:
                    // 削除情報
                    if (this._partsSubstPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._partsSubstPrintWork.DeleteDateTimeSt != 0) || (this._partsSubstPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._partsSubstPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._partsSubstPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._partsSubstPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._partsSubstPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // メーカー
                    if (this._partsSubstPrintWork.ChgSrcMakerCdSt != 0 || this._partsSubstPrintWork.ChgSrcMakerCdEd != 0)
                    {

                        stTarget = this._partsSubstPrintWork.ChgSrcMakerCdSt.ToString("0000");
                        edTarget = this._partsSubstPrintWork.ChgSrcMakerCdEd.ToString("0000");
                        if (this._partsSubstPrintWork.ChgSrcMakerCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._partsSubstPrintWork.ChgSrcMakerCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("メーカーコード" + ct_RangeConst, stTarget, edTarget));
                    }
                    // 品番
                    if (this._partsSubstPrintWork.ChgSrcGoodsNoSt != string.Empty || this._partsSubstPrintWork.ChgSrcGoodsNoEd != string.Empty)
                    {
                        stTarget = this._partsSubstPrintWork.ChgSrcGoodsNoSt;
                        edTarget = this._partsSubstPrintWork.ChgSrcGoodsNoEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("品番" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case GOODSSET_PGID:
                    // 削除情報
                    if (this._goodsSetPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._goodsSetPrintWork.DeleteDateTimeSt != 0) || (this._goodsSetPrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._goodsSetPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._goodsSetPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._goodsSetPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._goodsSetPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // メーカー
                    if (this._goodsSetPrintWork.ParentGoodsMakerCdSt != 0 || this._goodsSetPrintWork.ParentGoodsMakerCdEd != 0)
                    {

                        stTarget = this._goodsSetPrintWork.ParentGoodsMakerCdSt.ToString("0000");
                        edTarget = this._goodsSetPrintWork.ParentGoodsMakerCdEd.ToString("0000");
                        if (this._goodsSetPrintWork.ParentGoodsMakerCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._goodsSetPrintWork.ParentGoodsMakerCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("メーカーコード" + ct_RangeConst, stTarget, edTarget));
                    }
                    // 品番
                    if (this._goodsSetPrintWork.ParentGoodsNoSt != string.Empty || this._goodsSetPrintWork.ParentGoodsNoEd != string.Empty)
                    {
                        stTarget = this._goodsSetPrintWork.ParentGoodsNoSt;
                        edTarget = this._goodsSetPrintWork.ParentGoodsNoEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("品番" + ct_RangeConst, stTarget, edTarget));

                    }
                    this._goodsSetPrintWork = (GoodsSetPrintWork)this._printInfo.jyoken;
                    break;
                case MODELNAME_PGID:
                    // 削除情報
                    if (this._modelNamePrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._modelNamePrintWork.DeleteDateTimeSt != 0) || (this._modelNamePrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._modelNamePrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._modelNamePrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._modelNamePrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._modelNamePrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // メーカー
                    if (this._modelNamePrintWork.MakerCodeSt != 0 || this._modelNamePrintWork.MakerCodeEd != 0)
                    {

                        stTarget = this._modelNamePrintWork.MakerCodeSt.ToString("000") + "-" + this._modelNamePrintWork.ModelCodeSt.ToString("000") + "-" + this._modelNamePrintWork.ModelSubCodeSt.ToString("000");
                        edTarget = this._modelNamePrintWork.MakerCodeEd.ToString("999") + "-" + this._modelNamePrintWork.ModelCodeEd.ToString("999") + "-" + this._modelNamePrintWork.ModelSubCodeEd.ToString("999");
                        if ((this._modelNamePrintWork.MakerCodeSt + this._modelNamePrintWork.ModelCodeSt + this._modelNamePrintWork.ModelSubCodeSt) == 0) stTarget = ct_Extr_Top;
                        if ((this._modelNamePrintWork.MakerCodeEd + this._modelNamePrintWork.ModelCodeEd + this._modelNamePrintWork.ModelSubCodeEd) == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("車種" + ct_RangeConst, stTarget, edTarget));
                    }
                    this._modelNamePrintWork = (ModelNamePrintWork)this._printInfo.jyoken;
                    break;
                case PARTSPOSCODE_PGID:
                    // 削除情報
                    if (this._partsPosCodePrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._partsPosCodePrintWork.DeleteDateTimeSt != 0) || (this._partsPosCodePrintWork.DeleteDateTimeEd != 0))
                        {
                            // 開始
                            if (this._partsPosCodePrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._partsPosCodePrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // 終了
                            if (this._partsPosCodePrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._partsPosCodePrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("削除日付" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // 得意先
                    if (this._partsPosCodePrintWork.CustomerCodeSt != 0 || this._partsPosCodePrintWork.CustomerCodeEd != 0)
                    {

                        stTarget = this._partsPosCodePrintWork.CustomerCodeSt.ToString("00000000");
                        edTarget = this._partsPosCodePrintWork.CustomerCodeEd.ToString("00000000");
                        if (this._partsPosCodePrintWork.CustomerCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._partsPosCodePrintWork.CustomerCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));
                    }
                    // 部位
                    if (this._partsPosCodePrintWork.SearchPartsPosCodeSt != 0 || this._partsPosCodePrintWork.SearchPartsPosCodeEd != 0)
                    {

                        stTarget = this._partsPosCodePrintWork.SearchPartsPosCodeSt.ToString("00");
                        edTarget = this._partsPosCodePrintWork.SearchPartsPosCodeEd.ToString("00");
                        if (this._partsPosCodePrintWork.SearchPartsPosCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._partsPosCodePrintWork.SearchPartsPosCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("部位" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
            }

            // 追加
            foreach ( string exCondStr in addConditions ) {
                extraConditions.Add(exCondStr);
            }
        }
		#endregion

        #region ◎ 抽出範囲日付作成
        /// <summary>
        /// 日付の範囲条件文字列生成
        /// </summary>
        /// <param name="dateTitle">日付タイトル</param>
        /// <param name="stDate">開始日付</param>
        /// <param name="edDate">終了日付</param>
        /// <returns></returns>
        private string GetExtarConditionOfDates(string dateTitle, DateTime stDate, DateTime edDate)
        {
            string wkStDate = string.Empty;
            string wkEdDate = string.Empty;

            string resultString = string.Empty;

            // 開始･終了のいずれかが入力されていれば印字
            if ((stDate != DateTime.MinValue) || (edDate != DateTime.MinValue))
            {
                // 開始
                if (stDate != DateTime.MinValue)
                {
                    wkStDate = stDate.ToString("yyyy/MM/dd");
                }
                else
                {
                    wkStDate = ct_Extr_Top;
                }

                // 終了
                if (edDate != DateTime.MinValue)
                {
                    wkEdDate = edDate.ToString("yyyy/MM/dd");
                }
                else
                {
                    wkEdDate = ct_Extr_End;
                }

                resultString = string.Format(dateTitle + ct_RangeConst, wkStDate, wkEdDate);
            }

            return resultString;
        }
        #endregion ◎ 抽出範囲日付作成

        #region ◎ 抽出範囲文字列作成
        /// <summary>
		/// 抽出範囲文字列作成
		/// </summary>
		/// <returns>作成文字列</returns>
		/// <remarks>
		/// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.30</br>
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
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.30</br>
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
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMKHN08504P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
