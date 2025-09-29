using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 得意先別取引分布表 印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別取引分布表の印刷を行う。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>Update Note: 2008.12.16 30452 上野 俊治</br>
    /// <br>            ・「対象日付」を「対象日」に修正</br>
    /// </remarks>
    public class PMHNB02183PA : IPrintProc
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02183PA()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="printInfo"></param>
        public PMHNB02183PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._custSalesDistributionReportParam = this._printInfo.jyoken as CustSalesDistributionReportParam;
        }
        #endregion

        #region ■ Private定数
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        private const string ct_RangeConst = "：{0} ～ {1}";
        #endregion

        #region ■ Private変数
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private CustSalesDistributionReportParam _custSalesDistributionReportParam;		// 抽出条件クラス
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
        /// <br>Date       : 2008.11.21</br>
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
        /// 印刷メイン処理
        /// </summary>
        /// <returns></returns>
        private int PrintMain()
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
                prtRpt.DataMember = PMHNB02185EB.ct_Tbl_CustSalesDistributionReportForPrint;

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

        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
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
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
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
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
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
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            CustSalesDistributionReportParam extraInfo = (CustSalesDistributionReportParam)this._printInfo.jyoken;

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;

            int st = CustSalesDistributionReportAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new StockMoveException(message, status);
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
            instance.PrintInfo = this._printInfo;

            // ヘッダーサブタイトル
            instance.PageHeaderSubtitle = string.Format("取引分布表({0}別)", extraInfo.PrintTypeStateTitle);

            // その他データ
            // Todo:移動元とか渡す？抽出条件渡るからいいか？
            instance.OtherDataList = null;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            string stCode;
            string edCode;

            // 対象日
            this.EditCondition(ref addConditions, string.Format("対象日" + ct_RangeConst,
                                              this._custSalesDistributionReportParam.StSalesDate.ToString("0000/00/00"),
                                              this._custSalesDistributionReportParam.EdSalesDate.ToString("0000/00/00")));

            // 順位付設定
            this.EditCondition(ref addConditions,
                string.Format("順位付け設定：{0} {1} {2}位まで",
                this._custSalesDistributionReportParam.RankSectionStateTitle, this._custSalesDistributionReportParam.RankHighLowStateTitle, this._custSalesDistributionReportParam.RankOrderMax)
            );

            // 順位指定
            this.EditCondition(ref addConditions, string.Format("順位指定：{0}",
                                                this._custSalesDistributionReportParam.RankStandardStateTitle));

            // 印刷順
            this.EditCondition(ref addConditions, string.Format("印刷順：{0}",
                                                this._custSalesDistributionReportParam.PrintOrderStateTitle));

            // 改行
            this.EditConditionLetRight(ref addConditions, " ");

            // 担当者
            if (!(string.IsNullOrEmpty(this._custSalesDistributionReportParam.StSalesEmployeeCd))
                || !(string.IsNullOrEmpty(this._custSalesDistributionReportParam.EdSalesEmployeeCd)))
            {
                stCode = this._custSalesDistributionReportParam.StSalesEmployeeCd;
                edCode = this._custSalesDistributionReportParam.EdSalesEmployeeCd;
                if (string.IsNullOrEmpty(this._custSalesDistributionReportParam.StSalesEmployeeCd)) stCode = ct_Extr_Top;

                if (string.IsNullOrEmpty(this._custSalesDistributionReportParam.EdSalesEmployeeCd))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stCode, edCode));
            }

            // 地区
            if ((this._custSalesDistributionReportParam.StSalesAreaCode != 0) ||
                ((this._custSalesDistributionReportParam.EdSalesAreaCode != 0) &&
                 (!string.IsNullOrEmpty(this._custSalesDistributionReportParam.EdSalesAreaCode.ToString()))))
            {
                stCode = this._custSalesDistributionReportParam.StSalesAreaCode.ToString("0000");
                edCode = this._custSalesDistributionReportParam.EdSalesAreaCode.ToString("0000");
                if (this._custSalesDistributionReportParam.StSalesAreaCode == 0) stCode = ct_Extr_Top;

                if ((this._custSalesDistributionReportParam.EdSalesAreaCode == 0) ||
                    (string.IsNullOrEmpty(this._custSalesDistributionReportParam.EdSalesAreaCode.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("地区" + ct_RangeConst, stCode, edCode));
            }

            // 得意先
            if ((this._custSalesDistributionReportParam.StCustomerCode != 0) ||
                ((this._custSalesDistributionReportParam.EdCustomerCode != 0) &&
                 (!string.IsNullOrEmpty(this._custSalesDistributionReportParam.EdCustomerCode.ToString()))))
            {
                stCode = this._custSalesDistributionReportParam.StCustomerCode.ToString("00000000");
                edCode = this._custSalesDistributionReportParam.EdCustomerCode.ToString("00000000");
                if (this._custSalesDistributionReportParam.StCustomerCode == 0) stCode = ct_Extr_Top;

                if ((this._custSalesDistributionReportParam.EdCustomerCode == 0) ||
                    (string.IsNullOrEmpty(this._custSalesDistributionReportParam.EdCustomerCode.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stCode, edCode));
            }

            // 追加
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }

        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
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

        /// <summary>
        /// 格納エリアに文字列を右寄せで設定する
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を右寄せで編集します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private void EditConditionLetRight(ref StringCollection editArea, string target)
        {
            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);

            // 現在のStringCollectionのバイト数を取得
            int areaByte = TStrConv.SizeCountSJIS(editArea[editArea.Count - 1]);

            // 右寄せになるまで" "を追加
            while (areaByte + targetByte <= 190)
            {
                editArea[editArea.Count - 1] += " ";
                areaByte = TStrConv.SizeCountSJIS(editArea[editArea.Count - 1]);
            }

            editArea[editArea.Count - 1] += target;
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
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHNB02183P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
    }
}
