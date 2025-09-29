using System;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 回線エラーリスト印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 回線エラーリストの印刷を行う。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/04</br>
    /// </remarks>
    class PMUOE02012PA : IPrintProc
    {
        #region ■定数、変数、構造体
        // 定数
        private const string REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        private const string PG_ID = "PMUOE02012P";

        // 変数
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        #endregion

        #region ■クラス
        /// <summary> 例外クラス </summary>
        private class CircuitErrorException : ApplicationException
        {
            private int _status;

            /// <summary> ステータスプロパティ </summary>
            public int Status
            {
                get { return this._status; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public CircuitErrorException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
        }
        #endregion

        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : インスタンスの作成を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        public PMUOE02012PA ()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : インスタンスの作成を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        public PMUOE02012PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
        }
        #endregion ■Constructor - end

        #region ■Public
        #region ▼IPrintProcインターフェイス用プロパティ
        /// <summary> 印刷情報取得プロパティ </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion

        #region ▼StartPrint(印刷処理開始)
        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷を開始する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
        #endregion
        #endregion ■Public - end

        #region ■Private
        #region ▼PrintMain(印刷処理)
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 印刷フォームクラスインスタンス作成
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                // レポートインスタンス作成
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null)
                {
                    return status;
                }

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0)
                {
                    return status;
                }

                // データソース設定
                prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = PMUOE02013EA.ct_Tbl_CircuitErrorList;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                // プレビュー有無				
                int mode = this._printInfo.prevkbn;

                // 出力モードがＰＤＦの場合、無条件でプレビューなし
                if (this._printInfo.printmode == 2)
                {
                    mode = 0;
                }

                switch (mode)
                {
                    case 0:		// プレビューなし
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
                    case 1:		// プレビューあり
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
                                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm, this._printInfo.pdftemppath);
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PG_ID, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
        #endregion

        #region ▼CreateReport(各種ActiveReport帳票インスタンス作成)
        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            string assemblyName = prpid.Trim();                                 // アセンブリ名称
            string className = REPORTFORM_NAMESPACE + "." + assemblyName;       // クラス名称
            Type type = typeof(DataDynamics.ActiveReports.ActiveReport3);       // 実装するクラス型

            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(assemblyName);
                Type objType = asm.GetType(className);
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
                throw new CircuitErrorException(assemblyName + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new CircuitErrorException(er.Message, -1);
            }

            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)obj;
        }
        #endregion

        #region ▼SettingProperty(各種プロパティ設定)
        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion

        #region ▼SetPrintCommonInfo(印刷画面共通情報設定)
        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
            commonInfo.PrinterName = this._printInfo.prinm;                     // プリンタ名
            commonInfo.PrintName = this._printInfo.prpnm;                       // 帳票名
            commonInfo.PrintMode = this.Printinfo.printmode;                    // 印刷モード
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;   // 印刷件数
            commonInfo.MarginsTop = this._printInfo.py;                         // 上余白
            commonInfo.MarginsLeft = this._printInfo.px;                        // 左余白

            // PDFパス取得
            SFCMN00331C cmnCommon = new SFCMN00331C();      // 帳票チャート共通部品クラス
            string pdfPath = "";
            string pdfName = "";
            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);

            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;
        }

        #endregion
        #endregion ■Private - end
    }
}
