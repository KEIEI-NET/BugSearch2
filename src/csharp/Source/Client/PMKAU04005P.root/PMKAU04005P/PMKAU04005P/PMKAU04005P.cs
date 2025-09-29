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
//using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 得意先電子元帳印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳の印刷を行う。</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// </remarks>
    class PMKAU04005P : IPrintProc
    {

        #region プライベート変数

        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "ＴＯＰ";
        private const string ct_Extr_End = "ＥＮＤ";
        private const string ct_RangeConst = "：{0} ～ {1}";

        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private PrintCndtn _localPrintCondition;        // 印刷ヘッダ受け渡しクラス
        private PrtOutSet   _prtOutSet;                 // 帳票出力設定データクラス
        private PrtOutSetAcs _prtOutSetAcs;	            // 帳票出力設定アクセスクラス
        private Employee _employee;                     // ログイン拠点情報取得用

        #endregion // プライベート変数

        #region プロパティ

        /// <summary> 印刷情報取得プロパティ </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        #endregion // プロパティ

        #region コンストラクタ

        /// <summary>
		/// コンストラクタ
		/// </summary>
		public PMKAU04005P()
		{
            // ログイン拠点取得
            //_employee = null;
            //Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            //if (loginEmployee != null)
            //{
            //    _employee = loginEmployee.Clone();
            //}

            //this._localPrintCondition = this.Printinfo.jyoken as PrintCndtn;     // ヘッダ情報
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
        public PMKAU04005P(object printInfo)
		{
            //// ログイン拠点取得
            //_employee = null;
            //Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            //if (loginEmployee != null)
            //{
            //    _employee = loginEmployee.Clone();
            //}

           
			this._printInfo = printInfo as SFCMN06002C;                             // 印刷情報格納オブジェクト
            this._localPrintCondition = this.Printinfo.jyoken as PrintCndtn;     // ヘッダ情報
        }

        #endregion // コンストラクタ

        #region パブリックメソッド

        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns></returns>
        public int StartPrint()
        {
            return PrintMain();
        }

        #endregion // パブリックメソッド

        #region プライベートメソッド

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>Status</returns>
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
                //prtRpt.DataMember = DCHAT02104EA.ct_Tbl_OrderList;

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
                    case 0:
                        {
                            // プレビュー無c
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // 共通条件設定
                            processForm.CommonInfo = commonInfo;

# if DEBUG
# else
                            // プログレスバーUPイベント追加
                            if (prtRpt is IPrintActiveReportTypeCommon)
                            {
                                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            }
# endif

                            // 印刷実行
                            status = processForm.Run(prtRpt);

                            // 戻り値設定
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		
                        {
                            // プレビュー有
                            Broadleaf.Windows.Forms.SFCMN00293UA previewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // 共通条件設定
                            previewForm.CommonInfo = commonInfo;

                            // プレビュー実行
                            status = previewForm.Run(prtRpt);

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

        #region ActiveReport帳票インスタンス作成

        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 reportObj, string printFormId)
        {
            // 印刷フォームクラスインスタンス作成
            reportObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                printFormId.Trim(), ct_ReportForm_NameSpace + "." + printFormId.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        #endregion // ActiveReport帳票インスタンス作成

        #region レポートアセンブリインスタンス化

        /// <summary>
        /// レポートアセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
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
                throw new AssemblyErrorException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception ex)
            {
                throw new AssemblyErrorException(ex.Message, -1);
            }
            return obj;
        }

        #endregion // レポートアセンブリインスタンス化

        #region 印刷画面共通情報設定

        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();

            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
            commonInfo.PrinterName = this._printInfo.prinm;                     // プリンタ名
            commonInfo.PrintName = this._printInfo.prpnm;		                // 帳票名
            commonInfo.PrintMode = this.Printinfo.printmode;                   // 印刷モード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            //commonInfo.PrintMax = (this._printInfo.rdData as DataTable).Rows.Count;   // 印刷件数
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            if ( this._printInfo.rdData is DataView )
            {
                commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;   // 印刷件数
            }
            else if ( this._printInfo.rdData is DataTable )
            {
                commonInfo.PrintMax = (this._printInfo.rdData as DataTable).Rows.Count;   // 印刷件数
            }
            else
            {
                commonInfo.PrintMax = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
            commonInfo.MarginsTop = this._printInfo.py;                         // 上余白
            commonInfo.MarginsLeft = this._printInfo.px;                        // 左余白

            // PDFパス取得
            string pdfPath = "";
            string pdfName = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);

            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;               // PDFパス
        }

        #endregion

        #region 各種プロパティ設定

        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            //PrintCndtn extraInfo = (PrintCndtn)this._localPrintCondition;
            this._printInfo.jyoken = (object)this._localPrintCondition;

            // ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = string.Empty;

            // 帳票出力設定情報取得
            // ログイン拠点取得
            _employee = null;
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                _employee = loginEmployee.Clone();
            }

            _prtOutSetAcs = new PrtOutSetAcs();
            status = _prtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, _employee.BelongSectionCode);
            string msg;
            if (status != 0)
            {
                msg = "帳票出力設定情報取得に失敗しました。";
                throw new AssemblyErrorException(msg, status);
            }

            // 抽出条件ヘッダ出力区分
            instance.ExtraCondHeadOutDiv = _prtOutSet.ExtraCondHeadOutDiv;
            //instance.ExtraCondHeadOutDiv = 0;

            // ヘッダ受け渡し情報編集
            //StringCollection extraInfomations;
            //this.MakeExtarCondition(out extraInfomations);
            //instance.ExtraConditions = extraInfomations;
            //StringCollection extraInfomations = null;
            //instance.ExtraConditions = extraInfomations;

            

            // フッタ出力区分
            instance.PageFooterOutCode = _prtOutSet.FooterPrintOutCode;
            //instance.PageFooterOutCode = 0;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(_prtOutSet.PrintFooter1);
            footers.Add(_prtOutSet.PrintFooter2);
            instance.PageFooters = footers;

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            // ヘッダータイトル
            object[] titleObj = new object[] { _printInfo.prpnm };
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

            // その他データ
            instance.OtherDataList = null;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion // 各種プロパティ設定

        #region 抽出条件出力情報作成

        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            //// 拠点コード
            //this.EditCondition(ref addConditions, String.Format("拠点コード：{0}", this._localPrintCondition.SectionCd));
            //// 拠点名
            //this.EditCondition(ref addConditions, String.Format("拠点名：{0}", this._localPrintCondition.SectionName));
            //// 得意先コード
            //this.EditCondition(ref addConditions, String.Format("得意先コード：{0}", this._localPrintCondition.CustomerCd));
            //// 得意先名
            //this.EditCondition(ref addConditions, String.Format("得意先名：{0}", this._localPrintCondition.CustomerName));
            //// 開始日
            //this.EditCondition(ref addConditions, String.Format("開始日：{0}", this._localPrintCondition.StartDt.ToString("yyyy年MM月dd日")));
            //// 終了日
            //this.EditCondition(ref addConditions, String.Format("終了日：{0}", this._localPrintCondition.EndDt.ToString("yyyy年MM月dd日")));
            //// 締め日
            //this.EditCondition(ref addConditions, String.Format("締め日：{0}", this._localPrintCondition.TotalDt.ToString("dd")));

            //// 前回請求残高
            //this.EditCondition(ref addConditions, String.Format("前回請求残高：{0}", this._localPrintCondition.LastTimeDemand.ToString()));
            //// 入金額
            //this.EditCondition(ref addConditions, String.Format("入金額：{0}", this._localPrintCondition.ThisTimeDmdNrml.ToString()));
            //// 繰越金額
            //this.EditCondition(ref addConditions, String.Format("繰越金額：{0}", this._localPrintCondition.ForwardedAmount.ToString()));
            //// 今回売上額
            //this.EditCondition(ref addConditions, String.Format("今回売上額：{0}", this._localPrintCondition.ThisSalesPriceTotal.ToString()));
            //// 消費税
            //this.EditCondition(ref addConditions, String.Format("消費税：{0}", this._localPrintCondition.OfsThisSalesTax.ToString()));
            //// 税込金額
            //this.EditCondition(ref addConditions, String.Format("税込金額：{0}", this._localPrintCondition.TotalAmount.ToString()));
            //// 請求残高
            //this.EditCondition(ref addConditions, String.Format("請求残高：{0}", this._localPrintCondition.AfCalBlc.ToString()));
            //// 伝票枚数
            //this.EditCondition(ref addConditions, String.Format("伝票枚数：{0}", this._localPrintCondition.SlipCount.ToString()));

            //// 追加
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }

        #region 抽出条件文字列編集

        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
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

        #endregion // 抽出条件文字列編集

        #region 日付の範囲条件文字列生成

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

        #endregion // 日付の範囲条件文字列生成

        #endregion // 抽出条件出力情報作成

        #region メッセージ表示

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        private DialogResult MsgDispProc(emErrorLevel errorLevel, string msg, int status, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            return TMsgDisp.Show(errorLevel, "PMKAU04005P", msg, status, buttons, defaultButton);
        }

        #endregion // メッセージ表示

        #endregion // プライベートメソッド

        #region 例外クラス

        /// <summary>
        /// 例外クラス
        /// </summary>
        private class AssemblyErrorException : ApplicationException
        {
            #region プライベート変数

            private int _status;

            #endregion // プライベート変数

            #region コンストラクタ

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public AssemblyErrorException(string message, int status)
                : base(message)
            {
                this._status = status;
            }

            #endregion

            #region プロパティ

            /// <summary> 
            /// ステータス
            /// </summary>
            public int Status
            {
                get { return this._status; }
            }

            #endregion // プロパティ
        }

        #endregion 例外クラス

    }
}
