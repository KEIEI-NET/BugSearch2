using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 在庫看板印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫看板印刷の印刷を行う。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>Update Note: 2009.01.08 30452 上野 俊治</br>
    /// <br>            障害対応9615</br>
    /// </remarks>
    public class PMZAI02053PA : IPrintProc
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMZAI02053PA()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="printInfo"></param>
        public PMZAI02053PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._stockSignOrderCndtn = this._printInfo.jyoken as StockSignOrderCndtn;
        }
        #endregion

        #region ■ Private定数
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        #endregion

        #region ■ Private変数
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private StockSignOrderCndtn _stockSignOrderCndtn;		// 抽出条件クラス
        #endregion

        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public StockMoveException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region ◆ Public Property
            /// <summary> ステータスプロパティ </summary>
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion

        #region ■ IPrintProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// 印刷情報取得プロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
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
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IPrintProc メンバ

        #region ■ privateメソッド
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 印刷フォームクラスインスタンス作成
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null; // レーザーまたはドットの1ページ目用
            DataDynamics.ActiveReports.ActiveReport3 prtRptSub = null; // ドットの2ページ目以降用

            try
            {
                #region 1ページ目用 帳票インスタンス作成
                // レポートインスタンス作成
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                if (this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine
                    || this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine)
                {
                    // ドット
                    DataTable firstPageDataTable = ((DataView)this._printInfo.rdData).Table.Clone();

                    for (int i = 0; i < ((DataView)this._printInfo.rdData).Table.Rows.Count && i < 8; i++)
                    {
                        // 空行を含め、8行目までは1頁目の帳票に設定
                        DataRow dr = ((DataView)this._printInfo.rdData).Table.Rows[i];

                        firstPageDataTable.ImportRow(dr);
                    }

                    // データソース設定
                    prtRpt.DataSource = new DataView(firstPageDataTable, "", "", DataViewRowState.CurrentRows);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/27 ADD
                    //---------------------------------------------
                    // 用紙高さ補正
                    //---------------------------------------------
                    try
                    {
                        // 1頁内に収める=true
                        (prtRpt.Sections["detail"] as DataDynamics.ActiveReports.Detail).KeepTogether = true;

                        // ヘッダ余白調整（マスタ設定値をcmに変換してから、Inch単位にする）
                        float adjustY = DataDynamics.ActiveReports.ActiveReport3.CmToInch( ((float)_printInfo.py / 100f) );
                        prtRpt.Sections["reportHeader1"].Height = CalculateFruction( prtRpt.Sections["reportHeader1"].Height + adjustY );

                        // 高さを再計算する（ヘッダ×１＋明細×８）
                        float totalHeight = prtRpt.Sections["reportHeader1"].Height + prtRpt.Sections["detail"].Height * 8.0f;
                        prtRpt.PageSettings.PaperHeight = CalculateFruction( totalHeight );

                        // 上記処理の代わりに、通常の余白制御を無くす
                        _printInfo.py = 0;
                    }
                    catch
                    {
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/27 ADD
                }
                else
                {
                    // レーザー
                    prtRpt.DataSource = this._printInfo.rdData;
                }
                prtRpt.DataMember = PMZAI02059EA.ct_Tbl_StockSignResult;
                #endregion

                #region 2ページ目以降用 帳票インスタンス作成
                if (this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine
                    || this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine)
                {
                    if (((DataView)this._printInfo.rdData).Table.Rows.Count > 8)
                    {
                        // レポートインスタンス作成
                        this.CreateSubReport(out prtRptSub, this._printInfo.prpid);
                        if (prtRptSub == null) return status;

                        // 各種プロパティ設定
                        status = this.SettingProperty(ref prtRptSub);
                        if (status != 0) return status;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/27 ADD
                        try
                        {
                            // 1頁内に収める=true
                            (prtRptSub.Sections["detail"] as DataDynamics.ActiveReports.Detail).KeepTogether = true;

                            // 高さを再計算する（明細×９）
                            float totalHeight = prtRptSub.Sections["detail"].Height * 9.0f;
                            prtRptSub.PageSettings.PaperHeight = CalculateFruction( totalHeight );
                        }
                        catch
                        {
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/27 ADD

                        DataTable secondPageDataTable = ((DataView)this._printInfo.rdData).Table.Clone();

                        for (int i = 8; i < ((DataView)this._printInfo.rdData).Table.Rows.Count; i++)
                        {
                            // 9行目以降を帳票に設定
                            DataRow dr = ((DataView)this._printInfo.rdData).Table.Rows[i];

                            secondPageDataTable.ImportRow(dr);
                        }

                        // データソース設定
                        prtRptSub.DataSource = new DataView(secondPageDataTable, "", "", DataViewRowState.CurrentRows);
                        prtRptSub.DataMember = PMZAI02059EA.ct_Tbl_StockSignResult;
                    }
                }
                #endregion

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

                switch (mode)
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

                            // --- ADD 2009/01/08 -------------------------------->>>>>
                            if (prtRptSub != null)
                            {
                                // プログレスバーUPイベント追加
                                if (prtRpt is IPrintActiveReportTypeCommon)
                                {
                                    ((IPrintActiveReportTypeCommon)prtRptSub).ProgressBarUpEvent +=
                                        new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                                }
                            }
                            // --- ADD 2009/01/08 --------------------------------<<<<<

                            ArrayList prtList = new ArrayList();

                            prtList.Add(prtRpt);
                            if (prtRptSub != null)
                            {
                                prtList.Add(prtRptSub);
                            }

                            // 印刷実行
                            status = processForm.Run(prtList, true);

                            // 戻り値設定
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		// プレビュ有
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // 共通条件設定
                            viewForm.CommonInfo = commonInfo;

                            ArrayList prtList = new ArrayList();

                            prtList.Add(prtRpt);
                            if (prtRptSub != null)
                            {
                                prtList.Add(prtRptSub);
                            }

                            // プレビュー実行
                            status = viewForm.Run(prtList);

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
            catch (Exception ex)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (prtRpt != null)
                {
                    prtRpt.Dispose();
                }
            }
            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/27 ADD
        /// <summary>
        /// レポート用紙サイズ端数処理
        /// </summary>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        private float CalculateFruction( float targetValue )
        {
            // 小数２桁まで有効、切り上げ
            // (10.22625 → 10.23)

            decimal val = (decimal)targetValue;

            val = Math.Ceiling( val * 100m ) / 100m;
            return (float)val;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/27 ADD

        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>           : １ページ目用の帳票インスタンスを作成します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>           : ２ページ目以降用の帳票インスタンスを作成します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private void CreateSubReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim() + "_Sub",
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
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
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
                throw new StockMoveException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new StockMoveException(er.Message, -1);
            }
            return obj;
        }

        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            StockSignOrderCndtn extraInfo = (StockSignOrderCndtn)this._printInfo.jyoken;

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = StockSignPrintAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new StockMoveException(message, status);
            }

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
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
            commonInfo.PrintName = this._printInfo.prpnm;
            // 印刷モード
            commonInfo.PrintMode = this.Printinfo.printmode;
            // 印刷件数
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;

            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = this._printInfo.py;
            // 左余白
            commonInfo.MarginsLeft = this._printInfo.px;
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
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMZAI02053P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
    }
}
