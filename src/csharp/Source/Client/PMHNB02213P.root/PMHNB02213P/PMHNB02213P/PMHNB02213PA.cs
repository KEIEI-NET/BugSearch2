//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表印刷クラス
// プログラム概要   : 返品理由一覧表印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Collections.Specialized;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 返品理由一覧表印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品理由一覧表の印刷を行う。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class PMHNB02213PA : IPrintProc
    {
        #region ■ Constructor
		/// <summary>
        /// 返品理由一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 返品理由一覧表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
		public PMHNB02213PA()
		{
		}

		/// <summary>
        /// 返品理由一覧表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 返品理由一覧表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public PMHNB02213PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            _henbiRiyuListReport = this._printInfo.jyoken as HenbiRiyuListReport;
        }
		#endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string STR_TOP = "最初から";
        private const string STR_END = "最後まで";
        private const string ct_Month = "月度";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private HenbiRiyuListReport _henbiRiyuListReport;		// 抽出条件クラス
        #endregion ■ Private Member

        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        /// <remarks>
        /// <br>Note       : 返品理由一覧表の例外クラス</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks> 
        private class HenbiRiyuListReportException : ApplicationException
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
            /// <br>Programmer : 呉元嘯</br>
            /// <br>Date       : 2009.05.12</br>
            /// </remarks>
            public HenbiRiyuListReportException(string message, int status)
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
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
                if (prtRpt == null) return status;

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // データソース設定
                prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData;

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
        #endregion ◆ 印刷処理

        #region ■ 抽出条件出力情報作成処理
        /// <summary>
        /// 抽出条件出力情報作成処理
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            // 対象年月
            string salesDate = this._henbiRiyuListReport.SalesDate.ToString("yyyy/MM");
            this.EditCondition(ref extraConditions, string.Format("対象年月：{0} {1}", salesDate, ct_Month));

            // 改頁
            string changePage = SetChangePage();
            if (!string.IsNullOrEmpty(changePage))
            {
                this.EditCondition(ref extraConditions, string.Format("改頁：{0}", changePage));
            }
            

            // 伝票種別
            string slipKind = string.Empty;
            if (0 == _henbiRiyuListReport.SlipKindCd)
            {
                slipKind = "売上";
            }
            if (1 == _henbiRiyuListReport.SlipKindCd)
            {
                slipKind = "貸出含む";
            }
            this.EditCondition(ref extraConditions, string.Format("伝票種別：{0}", slipKind));

            // 得意先
            string customerCodeSt = string.Empty;
            string customerCodeEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.CustomerCodeSt))
            {
                customerCodeSt = STR_TOP;
            }
            else
            {
                customerCodeSt = this._henbiRiyuListReport.CustomerCodeSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.CustomerCodeEd))
            {
                customerCodeEd = STR_END;
            }
            else
            {
                customerCodeEd = this._henbiRiyuListReport.CustomerCodeEd;
            }

            if (!STR_TOP.Equals(customerCodeSt) || !STR_END.Equals(customerCodeEd))
            {
                this.EditCondition(ref extraConditions, string.Format("得意先：{0} ～ {1}", customerCodeSt, customerCodeEd));
            }

            // 担当者
            string salesEmployeeCdRFSt = string.Empty;
            string salesEmployeeCdRFEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesEmployeeCdRFSt))
            {
                salesEmployeeCdRFSt = STR_TOP;
            }
            else
            {
                salesEmployeeCdRFSt = this._henbiRiyuListReport.SalesEmployeeCdRFSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesEmployeeCdRFEd))
            {
                salesEmployeeCdRFEd = STR_END;
            }
            else
            {
                salesEmployeeCdRFEd = this._henbiRiyuListReport.SalesEmployeeCdRFEd;
            }

            if (!STR_TOP.Equals(salesEmployeeCdRFSt) || !STR_END.Equals(salesEmployeeCdRFEd))
            {
                this.EditCondition(ref extraConditions, string.Format("担当者：{0} ～ {1}", salesEmployeeCdRFSt,salesEmployeeCdRFEd));
            }

            // 受注者
            string frontEmployeeCdRFSt = string.Empty;
            string frontEmployeeCdRFEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.FrontEmployeeCdRFSt))
            {
                frontEmployeeCdRFSt = STR_TOP;
            }
            else
            {
                frontEmployeeCdRFSt = this._henbiRiyuListReport.FrontEmployeeCdRFSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.FrontEmployeeCdRFEd))
            {
                frontEmployeeCdRFEd = STR_END;
            }
            else
            {
                frontEmployeeCdRFEd = this._henbiRiyuListReport.FrontEmployeeCdRFEd;
            }

            if (!STR_TOP.Equals(frontEmployeeCdRFSt) || !STR_END.Equals(frontEmployeeCdRFEd))
            {
                this.EditCondition(ref extraConditions, string.Format("受注者：{0} ～ {1}", frontEmployeeCdRFSt, frontEmployeeCdRFEd));
            }

            // 発行者
            string salesInputCdRFSt = string.Empty;
            string salesInputCdRFEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesInputCdRFSt))
            {
                salesInputCdRFSt = STR_TOP;
            }
            else
            {
                salesInputCdRFSt = this._henbiRiyuListReport.SalesInputCdRFSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesInputCdRFEd))
            {
                salesInputCdRFEd = STR_END;
            }
            else
            {
                salesInputCdRFEd = this._henbiRiyuListReport.SalesInputCdRFEd;
            }

            if (!STR_TOP.Equals(salesInputCdRFSt) || !STR_END.Equals(salesInputCdRFEd))
            {
                this.EditCondition(ref extraConditions, string.Format("発行者：{0} ～ {1}", salesInputCdRFSt, salesInputCdRFEd));
            }

            // 返品理由
            string retGoodsReasonDivSt = string.Empty;
            string retGoodsReasonDivEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.RetGoodsReasonDivSt))
            {
                retGoodsReasonDivSt = STR_TOP;
            }
            else
            {
                retGoodsReasonDivSt = this._henbiRiyuListReport.RetGoodsReasonDivSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.RetGoodsReasonDivEd))
            {
                retGoodsReasonDivEd = STR_END;
            }
            else
            {
                retGoodsReasonDivEd = this._henbiRiyuListReport.RetGoodsReasonDivEd;
            }

            if (!STR_TOP.Equals(retGoodsReasonDivSt) || !STR_END.Equals(retGoodsReasonDivEd))
            {
                this.EditCondition(ref extraConditions, string.Format("返品理由：{0} ～ {1}", retGoodsReasonDivSt, retGoodsReasonDivEd));
            }
        }

        /// <summary>
        /// 改頁を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string SetChangePage()
       {
           int changePageDiv = _henbiRiyuListReport.ChangePageDiv;
           int printType = _henbiRiyuListReport.PrintType;
           string changePage = string.Empty;
           // 拠点
           if (0 == changePageDiv)
           {
               changePage = "拠点";
           }
           // 小計
           else if (1 == changePageDiv)
           {
               changePage = "小計";
           }
           // しない
           else if (2 == changePageDiv)
           {

           }
           return changePage;
           
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
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
                throw new HenbiRiyuListReportException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new HenbiRiyuListReportException(er.Message, -1);
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
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
            commonInfo.PrinterName = this._printInfo.prinm;
            // 帳票名
            commonInfo.PrintName = this._printInfo.prpnm;
            // 印刷モード
            commonInfo.PrintMode = this.Printinfo.printmode;
            // 印刷件数
            DataSet ds = (DataSet)this._printInfo.rdData;
            commonInfo.PrintMax = ds.Tables[PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData].Rows.Count;

            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = this._printInfo.py;
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            HenbiRiyuListReport henbiRiyuListReport= (HenbiRiyuListReport)this._printInfo.jyoken;

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);
            instance.ExtraConditions = extraInfomations;

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

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
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2008.05.11</br>
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHNB02213P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
