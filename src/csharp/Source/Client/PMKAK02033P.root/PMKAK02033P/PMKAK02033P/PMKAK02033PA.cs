//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 印刷クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
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
    /// 仕入返品予定一覧表印刷クラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 仕入返品予定一覧表の印刷を行なうクラスです。</br>
	/// <br>Programer  : FSI高橋 文彰</br>
	/// <br>Date       :  2013/01/28</br>
	/// </remarks>
    public class PMKAK02033PA
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 仕入返品予定一覧表印刷クラスコンストラクタ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入返品予定一覧表印刷クラスの新しいインスタンスを生成します</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02033PA()
        {
        }

        /// <summary>
        /// 仕入返品予定一覧表印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入返品予定一覧表印刷クラスの新しいインスタンスを生成します</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02033PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;

            this._pdfHistoryControl = new PdfHistoryControl();
            this._sfcmn00331C = new SFCMN00331C();

			this._extrInfo_PMKAK02034E = this._printInfo.jyoken as ExtrInfo_PMKAK02034E;

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
		private ExtrInfo_PMKAK02034E _extrInfo_PMKAK02034E = null;	// 抽出条件クラス
        #endregion

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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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
		#endregion ◆　ソート順出力

		/// <summary>
        /// 仕様テーブル名設定処理
        /// </summary>
        private void SelectTableName()
        {
            // 仕入返品予定一覧表名称
			ct_TableName = PMKAK02035EA.ct_Tbl_StockRetDtl;

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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet = null;
            string message = string.Empty;
            status = PMKAK02032A.ReadPrtOutSet(out prtOutSet, out message);
            if (!status.Equals(0))
            {
                throw new DemandPrintException(message, status);
            }

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);
            instance.PageFooters = footers;

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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
		/// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            string target = "";
            string stTarget = "";
            string edTarget = "";

            // 入力日：開始
            string fromInputDate = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_PMKAK02034E.InputDaySt);
            stTarget = "入力日: " + (string.IsNullOrEmpty(fromInputDate) ? "最初から" : fromInputDate);

            // 入力日：終了
            string toInputDate = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_PMKAK02034E.InputDayEd);
            edTarget = "  ～　" + (string.IsNullOrEmpty(toInputDate) ? "最後まで" : toInputDate);

            // "最初から ～ 最後まで"は印字しない
            if (!string.IsNullOrEmpty(fromInputDate + toInputDate))
            {
                target = stTarget + edTarget;
                this.EditCondition(ref extraConditions, target);
            }

            // 仕入先
            if (this._extrInfo_PMKAK02034E.SupplierCdSt != 0)
            {
                if (this._extrInfo_PMKAK02034E.SupplierCdEd != 0)	//From To 両方印字
                {
                    target = "仕入先: " + this._extrInfo_PMKAK02034E.SupplierCdSt.ToString("000000") + " ～ " + this._extrInfo_PMKAK02034E.SupplierCdEd.ToString("000000"); 
                }
                else　											//From だけ印字
                {
                    target = "仕入先: " + this._extrInfo_PMKAK02034E.SupplierCdSt.ToString("000000") + " ～ " + "最後まで";
                }
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._extrInfo_PMKAK02034E.SupplierCdEd != 0)	//Toだけ印字
            {
                target = "仕入先: " + "最初から ～ " + this._extrInfo_PMKAK02034E.SupplierCdEd.ToString("000000"); 
                this.EditCondition(ref extraConditions, target);
            }

            // 出力指定
            target = "出力指定：" + this._extrInfo_PMKAK02034E.SlipDivName;
            this.EditCondition(ref extraConditions, target);

            #region < 発行タイプ >
            target = "発行タイプ：" + this._extrInfo_PMKAK02034E.MakeShowDivName;
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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
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
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
			return TMsgDisp.Show(iLevel, "PMKAK02033P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
    }
}
