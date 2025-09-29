//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表印刷クラス
// プログラム概要   : 入荷差異表印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Collections.Specialized;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 入荷差異表印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷差異表の印刷を行う。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class PMKOU02353PA : IPrintProc
    {
        #region ■ Constructor
		/// <summary>
        /// 入荷差異表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入荷差異表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
		public PMKOU02353PA()
		{
		}

		/// <summary>
        /// 入荷差異表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 入荷差異表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public PMKOU02353PA(object printInfo)
		{
			this.PrintIf = printInfo as SFCMN06002C;
            ArrGoodsDiffCndtn = this.PrintIf.jyoken as ArrGoodsDiffCndtnWork;
            this.ArrGoodsDiffAccess = new ArrGoodsDiffAcs();
        }
		#endregion ■ Constructor

        #region ■ Pricate Const
        private const string ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string Space = "　";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C PrintIf;                               // 印刷情報クラス
        private ArrGoodsDiffCndtnWork ArrGoodsDiffCndtn;   // 抽出条件クラス
        /// <summary> アクセスクラス </summary>
        private ArrGoodsDiffAcs ArrGoodsDiffAccess;
        #endregion ■ Private Member

        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        /// <remarks>
        /// <br>Note       : 入荷差異表の例外クラス</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks> 
        private class ArrGoodsDiffException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            /// <remarks>
            /// <br>Note       : なし</br>
            /// <br>Programmer : 譚洪</br>
            /// <br>Date       : K2019/08/14</br>
            /// </remarks>
            public ArrGoodsDiffException(string message, int status)
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
        #endregion ■ Exception Class

        #region ■ IPrintProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// 印刷情報取得プロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this.PrintIf; }
            set { this.PrintIf = value; }
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public int StartPrint()
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 印刷フォームクラスインスタンス作成
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                // レポートインスタンス作成
                this.CreateReport(out prtRpt, this.PrintIf.prpid);
                if (prtRpt == null) return status;

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // データソース設定
                string filter = string.Empty;
                // ソート順
                string sort = string.Empty;

                DataTable data = ((DataSet)this.PrintIf.rdData).Tables[PMKOU02354EA.ct_Tbl_ArrGoodsDiffReportData];

                DataView dr = new DataView(data, filter, sort, DataViewRowState.CurrentRows);
                prtRpt.DataSource = dr;

                prtRpt.DataMember = PMKOU02354EA.ct_Tbl_ArrGoodsDiffReportData;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                // プレビュー有無				
                int mode = this.PrintIf.prevkbn;

                // 出力モードがＰＤＦの場合、無条件でプレビュー無
                if (this.PrintIf.printmode == 2)
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

                            // 印刷実行
                            status = processForm.Run(prtRpt);

                            // 戻り値設定
                            this.PrintIf.status = status;

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
                            this.PrintIf.status = status;

                            break;
                        }
                }

                // ＰＤＦ出力の場合
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (this.PrintIf.printmode)
                    {
                        case 1:		// プリンタ
                            break;
                        case 2:		// ＰＤＦ
                        case 3:		// 両方(プリンタ + ＰＤＦ)
                            {
                                // ＰＤＦ表示フラグON
                                this.PrintIf.pdfopen = true;

                                // 両方印刷時のみ履歴保存
                                if (this.PrintIf.printmode == 3)
                                {
                                    // 出力履歴管理に追加
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo(this.PrintIf.key, this.PrintIf.prpnm, this.PrintIf.prpnm,
                                        this.PrintIf.pdftemppath);
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
        #endregion ◆ 印刷処理

        #region ■ 抽出条件出力情報作成処理
        /// <summary>
        /// 抽出条件出力情報作成処理
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 譚洪</br>                                   
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            StringCollection addConditions = new StringCollection();

            // 検品日
            this.EditCondition(ref addConditions, string.Format("検品日:{0}", this.ArrGoodsDiffCndtn.InspectDate.ToString("yyyy/MM/dd")));

            // 発注先コード
            if (this.ArrGoodsDiffCndtn.UOESupplierCd != 0)
            {
                this.EditCondition(ref addConditions, string.Format("発注先:{0} {1}", this.ArrGoodsDiffCndtn.UOESupplierCd.ToString("D6"), this.ArrGoodsDiffCndtn.UOESupplierNm));
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }

        }
        #endregion


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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ReportForm_NameSpace + "." + prpid.Trim(),
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
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
                throw new ArrGoodsDiffException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new ArrGoodsDiffException(er.Message, -1);
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDFパス取得
            string pdfPath = string.Empty;
            string pdfName = string.Empty;

            // プリンタ名
            commonInfo.PrinterName = this.PrintIf.prinm;
            // 帳票名
            commonInfo.PrintName = this.PrintIf.prpnm;
            // 印刷モード
            commonInfo.PrintMode = this.Printinfo.printmode;
            // 印刷件数
            DataSet ds = (DataSet)this.PrintIf.rdData;
            commonInfo.PrintMax = ds.Tables[PMKOU02354EA.ct_Tbl_ArrGoodsDiffReportData].Rows.Count;

            status = cmnCommon.GetPdfSavePathName(this.PrintIf.prpnm, ref pdfPath, ref pdfName);
            this.PrintIf.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this.PrintIf.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = this.PrintIf.py;
            // 左余白
            commonInfo.MarginsLeft = this.PrintIf.px;
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            ArrGoodsDiffCndtnWork tegataConfirmReport = (ArrGoodsDiffCndtnWork)this.PrintIf.jyoken;

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet = new PrtOutSet();
            string message;
            int st = this.ArrGoodsDiffAccess.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new ArrGoodsDiffException(message, status);
            }

            // 抽出条件ヘッダ出力区分
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;
            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);
            instance.ExtraConditions = extraInfomations;

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;

            // 印刷情報オブジェクト
            instance.PrintInfo = this.PrintIf;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region ■ 抽出条件文字列編集処理
        /// <summary>
        /// 抽出条件文字列編集処理
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 譚洪</br>                                   
        /// <br>Date       : K2019/08/14</br>
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
                    if (editArea[i] != null) editArea[i] += Space;

                    editArea[i] += target;
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
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKOU02353P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
