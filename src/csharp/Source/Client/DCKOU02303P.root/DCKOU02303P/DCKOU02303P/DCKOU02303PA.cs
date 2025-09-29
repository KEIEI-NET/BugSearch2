//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入荷確認表
// プログラム概要   : 入荷確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢　貞義
// 作 成 日  2007/10/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馬淵 愛
// 修 正 日  2008/02/05  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/06/26  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13160
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/09  修正内容 : 障害対応9803、11150、11153、12398
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13173】フッター文の印字制御
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 入荷一覧表印刷クラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 入荷一覧表の印刷を行なうクラスです。</br>
	/// <br>Programer  : 980035　金沢　貞義</br>
	/// <br>Date       : 2007.10.19</br>
	/// ------------------------------------------------------------------------
	/// <br>UpdateNote	: 仕様変更</br>
	/// <br>Programmer	: 30191 馬淵 愛</br>
	/// <br>Date		: 2008.02.05</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote	: 仕様変更</br>
    /// <br>Programmer	: 30415 柴田 倫幸</br>
    /// <br>Date		: 2008.06.26</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote	: 障害対応13160</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/07</br>
    /// ------------------------------------------------------------------------
    /// <br>UpdateNote	: 障害対応9803、11150、11153、12398</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/04/08</br>
	/// </remarks>
    public class DCKOU02303PA
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 入荷一覧表印刷クラスコンストラクタ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 入荷一覧表印刷クラスの新しいインスタンスを生成します</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public DCKOU02303PA()
        {
        }

        /// <summary>
        /// 入荷一覧表印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 入荷一覧表印刷クラスの新しいインスタンスを生成します</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public DCKOU02303PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;

            this._pdfHistoryControl = new PdfHistoryControl();
            this._sfcmn00331C = new SFCMN00331C();

			this._extrInfo_DCKOU02304E = this._printInfo.jyoken as ExtrInfo_DCKOU02304E;

            this.SelectTableName();

        }
        #endregion

        //================================================================================
        //  内部定数
        //================================================================================
        #region private constant
        private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
        private const string CT_ITEM_INTERVAL = "　　　　　";

        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;
        private PdfHistoryControl _pdfHistoryControl = null;
        private SFCMN00331C _sfcmn00331C = null;			// 帳票系共通部品
		private ExtrInfo_DCKOU02304E _extrInfo_DCKOU02304E = null;	// 抽出条件クラス
        #endregion

        /// <summary>表示順位</summary>
		//private string CT_Sort1_Odr = "CustomerCode, ArrivalGoodsDay";
		//private string CT_Sort2_Odr = "StockAgentCode, CustomerCode, ArrivalGoodsDay";

		//private string CT_Sort1_OdrStr = "得意先→入荷日付";
		//private string CT_Sort2_OdrStr = "担当者→得意先→入荷日付";

        /* --- DEL 2008/06/26 -------------------------------->>>>>
		private string CT_Sort1_Odr = "SectionCode, CustomerCode, ArrivalGoodsDay, SupplierSlipNo";
		private string CT_Sort2_Odr = "SectionCode, ArrivalGoodsDay, CustomerCode, SupplierSlipNo";
		private string CT_Sort3_Odr = "SectionCode, StockAgentCode, CustomerCode, ArrivalGoodsDay, SupplierSlipNo";
           --- DEL 2008/06/26 --------------------------------<<<<< */
        // --- ADD 2008/06/25 -------------------------------->>>>>
        private string CT_Sort1_Odr = "SectionCode, SupplierCd, ArrivalGoodsDay, SupplierSlipNo";
        private string CT_Sort2_Odr = "SectionCode, ArrivalGoodsDay, SupplierCd, SupplierSlipNo";
        private string CT_Sort3_Odr = "SectionCode, StockAgentCode, SupplierCd, ArrivalGoodsDay, SupplierSlipNo";
        // --- ADD 2008/06/25 --------------------------------<<<<< 
        private string CT_Sort4_Odr = "SectionCode, ArrivalGoodsDay, SupplierSlipNo";
		private string CT_Sort5_Odr = "SectionCode, SupplierSlipNo";

        /* ---DEL 2008/09/26 ---------------------------------------------->>>>>
		private string CT_Sort1_OdrStr = "仕入先→入荷日→伝票番号";
		private string CT_Sort2_OdrStr = "入荷日→仕入先→伝票番号";
		private string CT_Sort3_OdrStr = "担当者→仕入先→入荷日→伝票番号";
		private string CT_Sort4_OdrStr = "入荷日→伝票番号";
		private string CT_Sort5_OdrStr = "伝票番号";
           ---DEL 2008/09/26 ----------------------------------------------<<<<< */
        // ---ADD 2008/09/26 ---------------------------------------------->>>>>
        private string CT_Sort1_OdrStr = "仕入先→入荷日→仕入SEQ番号";
        private string CT_Sort2_OdrStr = "入荷日→仕入先→仕入SEQ番号";
        private string CT_Sort3_OdrStr = "担当者→仕入先→入荷日→仕入SEQ番号";
        private string CT_Sort4_OdrStr = "入荷日→仕入SEQ番号";
        private string CT_Sort5_OdrStr = "仕入SEQ番号";
        // ---ADD 2008/09/26 ----------------------------------------------<<<<<
        // データ取得元テーブル名
        private string ct_TableName;

        //================================================================================
        //  外部提供プロパティ
        //================================================================================
        #region public property
        #region IPrintProcの実装部(プロパティ)
        /// <summary>印刷データ</summary>
        /// <value>印刷するデータを取得または設定します。</value>
        public SFCMN06002C Printinfo
        {
            get { return _printInfo; }
            set { _printInfo = value; }
        }
        #endregion
        #endregion

        // ===============================================================================
        // 例外クラス
        // ===============================================================================
        #region 例外クラス
        private class DemandPrintException : ApplicationException
        {
            private int _status;

            #region constructor
            public DemandPrintException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region public property
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion

        //================================================================================
        //  IPrintProcの実装部　印刷メイン処理
        //================================================================================
        #region IPrintProcの実装部
        /// <summary>
        /// 印刷開始処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷の開始処理を行います。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int StartPrint()
        {
            return this.PrintMain();
        }
        #endregion

        //================================================================================
        // 内部関数
        //================================================================================
        #region Private Methods
        #region ◆　印刷メイン処理
        /// <summary>
        /// 印刷メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // 印刷フォームクラスインスタンス作成
                DataDynamics.ActiveReports.ActiveReport3 prtRpt;

                // レポートインスタンス作成
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // 印刷データ取得
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = ds.Tables[ct_TableName];

                // ソート順設定
                dv.Sort = this.GetPrintOderQuerry();
				
                // データソース設定
                prtRpt.DataSource = dv;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                // プレビュー有無				
                int prevkbn = this._printInfo.prevkbn;

                // 出力モードがＰＤＦの場合、無条件でプレビュー無
                if (this._printInfo.printmode == 2)
                {
                    prevkbn = 0;
                }
                switch (prevkbn)
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
                            viewForm.CommonInfo = commonInfo;

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
                        case 1:		// プリンタ
                            break;
                        case 2:		// ＰＤＦ
                        case 3:		// 両方(プリンタ + ＰＤＦ)
                            {
                                // ＰＤＦ表示フラグON
                                this._printInfo.pdfopen = true;

                                // 両方印刷時のみ履歴保存
                                if (this._printInfo.printmode == 3)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.26 T-Kidate START
                                    // 出力履歴管理に追加
                                    //this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "入荷一覧表", this._printInfo.prpnm,
                                    //    this._printInfo.pdftemppath);
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                        this._printInfo.pdftemppath);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.26 T-Kidate END
                                }
                                break;
                            }
                    }
                }

            }
            catch (DemandPrintException ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, ex.Status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return status;
        }

		#region ◆　ソート順印字出力
		/// <summary>
		/// ソート順印字出力
		/// </summary>
		/// <param name="sorttitle">ソート順印字出力</param>
		/// <remarks>
		/// <br> ソート順の出力を作成します。</br>
		/// </remarks>
		private void SORTTITLE(out string sorttitle)
		{
			// ソート順
			string wrkstr = "";
			sorttitle = "";

			switch (this._extrInfo_DCKOU02304E.SortOrder)
			{
				case 0:
					{
						wrkstr = CT_Sort1_OdrStr;
						break;
					}
				case 1:
					{
						wrkstr = CT_Sort2_OdrStr;
						break;
					}
				case 2:
					{
						wrkstr = CT_Sort3_OdrStr;
						break;
					}
				case 3:
					{
						wrkstr = CT_Sort4_OdrStr;
						break;
					}
				case 4:
					{
						wrkstr = CT_Sort5_OdrStr;
						break;
					}
			}
			//sorttitle = "ソート順：" + wrkstr + " 順";  // DEL 2008/06/26
            sorttitle = "ソート順：[" + wrkstr + "] 順";  // ADD 2008/06/26
		}
		#endregion ◆　ソート順出力

		/// <summary>
        /// 仕様テーブル名設定処理
        /// </summary>
        private void SelectTableName()
        {
            // 入荷一覧表名称
			ct_TableName = DCKOU02305EA.ct_Tbl_ArrivalDtl;

        }

        #endregion

        #region ◆　ActiveReport帳票インスタンス作成関連
        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private object LoadAssemblyReport(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new DemandPrintException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new DemandPrintException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region ◆　AvtiveReportに各種プロパティを設定します
        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

			// ソート順印字出力
			string sortTitle = "";
			this.SORTTITLE(out sortTitle);

			instance.PageHeaderSortOderTitle = sortTitle;

            // ADD 2009/01/19 不具合対応[9668] ---------->>>>>
            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet = null;
            string message = string.Empty;
            status = StockMoveAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (!status.Equals(0))
            {
                throw new DemandPrintException(message, status);
            }

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;      // ADD 2009/04/13

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);
            instance.PageFooters = footers;
            // ADD 2008/01/19 不具合対応[9668] ----------<<<<<

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion

        #region ◆　抽出条件ヘッダー作成処理
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
		/// ------------------------------------------------------------------------
		/// <br>UpdateNote	: 出力する抽出条件文字列を追加</br>
		/// <br>Programmer	: 30191 馬淵 愛</br>
		/// <br>Date		: 2008.01.28</br>
		/// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            string target = "";
            string stTarget = "";
            string edTarget = "";

            /* --- DEL 2008/09/29 順番入れ替えの為---------------->>>>>
			//入力日付
			if ((this._extrInfo_DCKOU02304E.InputDaySt != 0) ||
				(this._extrInfo_DCKOU02304E.InputDayEd != 0))
			{
				stTarget = "入力日: " + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.InputDaySt);
				edTarget = "  ～　" + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.InputDayEd);

				target = stTarget + edTarget;

				this.EditCondition(ref extraConditions, target);
			}

			//入荷日付
			if ((this._extrInfo_DCKOU02304E.ArrivalGoodsDaySt != 0) ||
				(this._extrInfo_DCKOU02304E.ArrivalGoodsDayEd != 0))
			{
				stTarget = "入荷日: " + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.ArrivalGoodsDaySt);
				edTarget = "  ～　" + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.ArrivalGoodsDayEd);

				target = stTarget + edTarget;

				this.EditCondition(ref extraConditions, target);
			}
               --- DEL 2008/09/29 --------------------------------<<<<< */
            // --- ADD 2008/09/29 -------------------------------->>>>>
            //入荷日付
            if ((this._extrInfo_DCKOU02304E.ArrivalGoodsDaySt != 0) ||
                (this._extrInfo_DCKOU02304E.ArrivalGoodsDayEd != 0))
            {
                // --- DEL 2009/04/07 -------------------------------->>>>>
                //stTarget = "入荷日: " + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.ArrivalGoodsDaySt);
                //edTarget = "  ～　" + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.ArrivalGoodsDayEd);
                // --- DEL 2009/04/07 --------------------------------<<<<<
                // --- ADD 2009/04/07 -------------------------------->>>>>
                // 出荷日：開始
                string fromArrivalGoodsDay = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.ArrivalGoodsDaySt);
                stTarget = "入荷日: " + (string.IsNullOrEmpty(fromArrivalGoodsDay) ? "最初から" : fromArrivalGoodsDay);

                // 出荷日：終了
                string toArrivalGoodsDay = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.ArrivalGoodsDayEd);
                edTarget = "  ～　" + (string.IsNullOrEmpty(toArrivalGoodsDay) ? "最後まで" : toArrivalGoodsDay);
                // --- ADD 2009/04/07 --------------------------------<<<<<
                target = stTarget + edTarget;

                this.EditCondition(ref extraConditions, target);
            }

            //入力日付
            // DEL 2008/01/15 不具合対応[9657] ---------->>>>>
            #region 削除コード
            //if ((this._extrInfo_DCKOU02304E.InputDaySt != 0) ||
            //    (this._extrInfo_DCKOU02304E.InputDayEd != 0))
            //{
            //stTarget = "入力日: " + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.InputDaySt);

            //edTarget = "  ～　" + TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.InputDayEd);

            //target = stTarget + edTarget;

            //this.EditCondition(ref extraConditions, target);
            //}
            #endregion
            // DEL 2008/01/15 不具合対応[9657] ----------<<<<<
            // ADD 2008/01/15 不具合対応[9657] ---------->>>>>
            {
                // 入力日：開始
                string fromInputDate = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.InputDaySt);
                stTarget = "入力日: " + (string.IsNullOrEmpty(fromInputDate) ? "最初から" : fromInputDate);

                // 入力日：終了
                string toInputDate = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_DCKOU02304E.InputDayEd);
                edTarget = "  ～　" + (string.IsNullOrEmpty(toInputDate) ? "最後まで" : toInputDate);

                // "最初から ～ 最後まで"は印字しない
                if (!string.IsNullOrEmpty(fromInputDate + toInputDate))
                {
                    target = stTarget + edTarget;

                    this.EditCondition(ref extraConditions, target);
                }
            }
            // ADD 2008/01/15 不具合対応[9657] ----------<<<<<

            // --- ADD 2008/09/29 --------------------------------<<<<<
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			// 仕入先
			if (this._extrInfo_DCKOU02304E.CustomerCodeSt != 0)
			{
				if (this._extrInfo_DCKOU02304E.CustomerCodeEd != 0)	//From To 両方印字
				{
					target = "仕入先: " + this._extrInfo_DCKOU02304E.CustomerCodeSt.ToString() + " ～ " + this._extrInfo_DCKOU02304E.CustomerCodeEd.ToString();
				}
				else　											//From だけ印字
				{
					target = "仕入先: " + this._extrInfo_DCKOU02304E.CustomerCodeSt.ToString() + " ～ ";
				}

				this.EditCondition(ref extraConditions, target);
			}

			else if (this._extrInfo_DCKOU02304E.CustomerCodeEd != 0)	//Toだけ印字
			{
				target = "仕入先: " + this._extrInfo_DCKOU02304E.CustomerCodeSt.ToString() + " ～ " + this._extrInfo_DCKOU02304E.CustomerCodeEd.ToString();
				this.EditCondition(ref extraConditions, target);
			}
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            // 仕入先
            if (this._extrInfo_DCKOU02304E.SupplierCdSt != 0)
            {
                if (this._extrInfo_DCKOU02304E.SupplierCdEd != 0)	//From To 両方印字
                {
                    //target = "仕入先: " + this._extrInfo_DCKOU02304E.SupplierCdSt.ToString() + " ～ " + this._extrInfo_DCKOU02304E.SupplierCdEd.ToString();                   //DEL 2008/09/26 ゼロ詰めの為
                    target = "仕入先: " + this._extrInfo_DCKOU02304E.SupplierCdSt.ToString("000000") + " ～ " + this._extrInfo_DCKOU02304E.SupplierCdEd.ToString("000000");     //ADD 2008/09/26     
                }
                else　											//From だけ印字
                {
                    //target = "仕入先: " + this._extrInfo_DCKOU02304E.SupplierCdSt.ToString() + " ～ " + "最後まで";               //DEL 2008/09/26 ゼロ詰めの為
                    target = "仕入先: " + this._extrInfo_DCKOU02304E.SupplierCdSt.ToString("000000") + " ～ " + "最後まで";         //ADD 2008/09/26
                }

                this.EditCondition(ref extraConditions, target);
            }
            else if (this._extrInfo_DCKOU02304E.SupplierCdEd != 0)	//Toだけ印字
            {
                //target = "仕入先: " + "最初から ～ " + this._extrInfo_DCKOU02304E.SupplierCdEd.ToString();            //DEL 2008/09/26 ゼロ詰めの為
                target = "仕入先: " + "最初から ～ " + this._extrInfo_DCKOU02304E.SupplierCdEd.ToString("000000");      //ADD 2008/09/26
                this.EditCondition(ref extraConditions, target);
            }
            // --- ADD 2008/06/25 --------------------------------<<<<< 

            // 担当者
            if ((this._extrInfo_DCKOU02304E.StockAgentCodeSt != "") ||
                (this._extrInfo_DCKOU02304E.StockAgentCodeEd != ""))
            {
                if ((this._extrInfo_DCKOU02304E.StockAgentCodeSt != "") &&
                    (this._extrInfo_DCKOU02304E.StockAgentCodeEd != ""))
                {
                    target = "担当者: " + this._extrInfo_DCKOU02304E.StockAgentCodeSt + " ～ " + this._extrInfo_DCKOU02304E.StockAgentCodeEd;
                }
                else if (this._extrInfo_DCKOU02304E.StockAgentCodeSt != "")
                {
                    target = "担当者: " + this._extrInfo_DCKOU02304E.StockAgentCodeSt + " ～ 最後まで";
                }
                else
                {
                    target = "担当者: 最初から ～ " + this._extrInfo_DCKOU02304E.StockAgentCodeEd;
                }

                this.EditCondition(ref extraConditions, target);
            }

            /* --- DEL 2008/06/25 -------------------------------->>>>>
			// 入力者
			if ((this._extrInfo_DCKOU02304E.StockInputCodeSt != "") ||
				(this._extrInfo_DCKOU02304E.StockInputCodeEd != ""))
			{
				target = "入力者: " + this._extrInfo_DCKOU02304E.StockInputCodeSt + " ～ " + this._extrInfo_DCKOU02304E.StockInputCodeEd;
				this.EditCondition(ref extraConditions, target);
			}
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // 仕入SEQ番号
            if ((this._extrInfo_DCKOU02304E.SupplierSlipNoSt != 0) ||
                (this._extrInfo_DCKOU02304E.SupplierSlipNoEd != 0))
            {
                if ((this._extrInfo_DCKOU02304E.SupplierSlipNoSt != 0) &&
                (this._extrInfo_DCKOU02304E.SupplierSlipNoEd != 0))
                {
                    //target = "伝票番号: " + this._extrInfo_DCKOU02304E.SupplierSlipNoSt + " ～ " + this._extrInfo_DCKOU02304E.SupplierSlipNoEd;       //DEL 2008/09/30 名称変更
                    target = "仕入SEQ番号: " + this._extrInfo_DCKOU02304E.SupplierSlipNoSt + " ～ " + this._extrInfo_DCKOU02304E.SupplierSlipNoEd;      //ADD 2008/09/30
                }
                else if (this._extrInfo_DCKOU02304E.SupplierSlipNoSt != 0)
                {
                    //target = "伝票番号: " + this._extrInfo_DCKOU02304E.SupplierSlipNoSt + " ～ 最後まで";         //DEL 2008/09/30 名称変更
                    target = "仕入SEQ番号: " + this._extrInfo_DCKOU02304E.SupplierSlipNoSt + " ～ 最後まで";        //ADD 2008/09/30
                }
                else
                {
                    //target = "伝票番号: 最初から ～ " + this._extrInfo_DCKOU02304E.SupplierSlipNoEd;              //DEL 2008/09/30 名称変更
                    target = "仕入SEQ番号: 最初から ～ " + this._extrInfo_DCKOU02304E.SupplierSlipNoEd;             //ADD 2008/09/30
                }

                this.EditCondition(ref extraConditions, target);
            }

            // --- ADD 2009/04/08 -------------------------------->>>>>
            // 伝票番号
            if (this._extrInfo_DCKOU02304E.PartySalesSlipNumSt != string.Empty
                || this._extrInfo_DCKOU02304E.PartySalesSlipNumEd != string.Empty)
            {
                if (this._extrInfo_DCKOU02304E.PartySalesSlipNumSt != string.Empty
                    && this._extrInfo_DCKOU02304E.PartySalesSlipNumEd != string.Empty)
                {
                    target = "伝票番号: " + this._extrInfo_DCKOU02304E.PartySalesSlipNumSt
                           + " ～ "
                           + this._extrInfo_DCKOU02304E.PartySalesSlipNumEd; 
                }
                else if (this._extrInfo_DCKOU02304E.PartySalesSlipNumSt != string.Empty)
                {
                    target = "伝票番号: " + this._extrInfo_DCKOU02304E.PartySalesSlipNumSt
                           + " ～ 最後まで";
                }
                else if (this._extrInfo_DCKOU02304E.PartySalesSlipNumEd != string.Empty)
                {
                    target = "伝票番号: 最初から ～ "
                           + this._extrInfo_DCKOU02304E.PartySalesSlipNumEd; 
                }

                this.EditCondition(ref extraConditions, target);
            }
            // --- ADD 2009/04/08 --------------------------------<<<<<

            // 伝票区分
            target = "伝票区分：" + this._extrInfo_DCKOU02304E.SlipDivName;
            this.EditCondition(ref extraConditions, target);

            /* --- DEL 2008/09/26 赤伝区分削除の為 ------------------------------->>>>>
			// 赤伝区分
			target = "赤伝区分：" + this._extrInfo_DCKOU02304E.DebitNoteDivName;
			this.EditCondition(ref extraConditions, target);
               --- DEL 2008/09/26 赤伝区分削除の為 -------------------------------<<<<< */

            #region < 作表区分 >
            target = "作表区分：" + this._extrInfo_DCKOU02304E.MakeShowDivName;
            this.EditCondition(ref extraConditions, target);
            #endregion

        }

        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programer  : 30191　馬淵　愛</br>
        /// <br>Date       : 2008.03.04</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            /* --- DEL 2008/09/26 途中で切れる為、大幅に修正 --------------------------------------------->>>>>
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

				//TODO 以下　'targetByte + 2) <= ●)'の●の数が少ないと、印字された時途中で途切れる。
                if ((areaByte + targetByte + 2) <= 350)
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;

                    editArea[i] += target;
                    break;
                }
            }
            // 新規編集エリア作成
            if (!isEdit)
            {
                editArea.Add(target);
            }
               --- DEL 2008/09/26 ------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/09/26 ------------------------------------------------------------------------>>>>>
            // 最初のデータ
            if (editArea.Count == 0)
            {
                editArea.Add(target + CT_ITEM_INTERVAL);
                return;
            }

            int areaIndex = editArea.Count - 1;
            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);
            // 格納エリアのバイト数算出
            int areaByte = TStrConv.SizeCountSJIS(editArea[areaIndex]);

            // 連結文字がMAXか
            if ((areaByte + targetByte) <= 164)
            {
                // 連結文字 + 空白がMAXか
                if ((areaByte + targetByte + TStrConv.SizeCountSJIS(CT_ITEM_INTERVAL)) <= 164)
                {
                    editArea[areaIndex] = editArea[areaIndex] + target + CT_ITEM_INTERVAL;
                }
                else
                {
                    editArea[areaIndex] = editArea[areaIndex] + target;
                }
            }
            else
            {
                // MAXとなる場合、次の行
                editArea.Add(target + CT_ITEM_INTERVAL);
            }
            // --- ADD 2008/09/26 ------------------------------------------------------------------------<<<<<
        }
        #endregion

        #region ◆　共通プレビュー部品パラメータ設定
        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // プリンタ名
            commonInfo.PrinterName = this._printInfo.prinm;

            // 帳票名
            commonInfo.PrintName = this._printInfo.prpnm;

            // 印刷件数
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[ct_TableName].Rows.Count;

            // 印刷モード
            commonInfo.PrintMode = this._printInfo.printmode;

            // 余白設定
            // 桁位置
            commonInfo.MarginsLeft = this._printInfo.px;

            // 行位置
            commonInfo.MarginsTop = this._printInfo.py;

            // PDF出力フルパス
            string pdfPath = "";
            string pdfName = "";
            this._sfcmn00331C.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);

            string pdfFileName = System.IO.Path.Combine(pdfPath, pdfName);
            commonInfo.PdfFullPath = pdfFileName;

            this._printInfo.pdftemppath = pdfFileName;
        }
        #endregion

        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
		/// ------------------------------------------------------------------------
		/// <br>UpdateNote	: 出力順を追加</br>
		/// <br>Programmer	: 30191 馬淵 愛</br>
		/// <br>Date		: 2008.01.28</br>
		/// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._extrInfo_DCKOU02304E.SortOrder)
            {
				case 0:
					{
						oderQuerry = CT_Sort1_Odr;
						break;
					}
				case 1:
					{
						oderQuerry = CT_Sort2_Odr;
						break;
					}
				case 2:
					{
						oderQuerry = CT_Sort3_Odr;
						break;
					}
				case 3:
					{
						oderQuerry = CT_Sort4_Odr;
						break;
					}
				case 4:
					{
						oderQuerry = CT_Sort5_Odr;
						break;
					}
			}

            return oderQuerry;
        }
        #endregion

        #region ◆　メッセージ表示処理
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
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
			return TMsgDisp.Show(iLevel, "DCKOU02303P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion
    }
}
