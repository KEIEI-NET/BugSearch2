//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.Collections.Specialized;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using System.Globalization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 仕入売上実績表印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入売上実績表印刷クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public class PMKOU02063PA
    {

        #region ■ Constructor
        /// <summary>
        /// 仕入売上実績表印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02063PA()
        {
        }

        /// <summary>
        /// 仕入売上実績表印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02063PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._stockSalesResultInfoMainCndtn = this._printInfo.jyoken as StockSalesResultInfoMainCndtn;
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Zero = "0";
        private const string ct_All = "00";
        private const string FILENAME_YYYYMMDD = "YYYYMMDD";
        private const string FILENAME_HHMMSSFF = "HHMMSSFF";
        private const string ct_Month = "月度";
        const string ct_RangeConst = "：{0} ～ {1}";
        const string ct_DateFormat = "YYYY/MM/DD";
        const string ct_Extr_Top = "最初から";
        const string ct_Extr_End = "最後まで";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					    // 印刷情報クラス
        private StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn;

        #endregion ■ Private Member

        #region ■ Exception Class
        /// <summary>
        /// 例外クラス
        /// </summary>
        /// <remarks>
        /// <br>Note		: 例外クラスの作成を行う。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private class SalesStockInfoMainException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            /// <remarks>
            /// <br>Note		: 例外クラスコンストラクタの作成を行う。</br>
            /// <br>Programmer	: 汪千来</br>
            /// <br>Date		: 2009.05.13</br>
            /// </remarks>
            public SalesStockInfoMainException(string message, int status)
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
        /// <summary>  印刷情報プロパティ</summary>
        /// <value>Printinfo</value>               
        /// <remarks> 印刷情報取得又はセットプロパティ </remarks> 
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion ◆ Public Property

        # region Interface Member



        # endregion

        #region ◆ Public Method
        #region ◎ 印刷処理開始
        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷を開始する。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
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
                status = 0;
                if (status != 0) return status;


                //拠点－仕入先－仕入先伝票番号(相手先伝票番号)－区分(仕入→売上)－仕入日付－仕入SEQ番号(仕入伝票番号)－行番号(仕入行番号)　順
                // フィルタ条件
                string filter = string.Empty;
                // ソート順
                string sort = PMKOU02065EA.Col_SectionCode + " ASC,"
                           + PMKOU02065EA.Col_SupplierCdForSort + " ASC,"
                           + PMKOU02065EA.Col_PartySaleSlipNumForSort + " ASC,"
                           + PMKOU02065EA.Col_KuBec + " ASC,"
                           + PMKOU02065EA.Col_StockDateForSort + " ASC,"
                           + PMKOU02065EA.Col_SupplierSlipNo + " ASC,"
                           + PMKOU02065EA.Col_StockRowNo + " ASC";
                DataTable data = ((DataSet)this._printInfo.rdData).Tables[PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain];

                DataView dr = new DataView(data, filter, sort, DataViewRowState.CurrentRows);

                // データソース設定
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;

                prtRpt.DataSource = dr;


                prtRpt.DataMember = PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain;

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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
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
                throw new SalesStockInfoMainException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new SalesStockInfoMainException(er.Message, -1);
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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
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
            commonInfo.PrintMax = ds.Tables[0].Rows.Count;
            // SAVE PATH
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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = string.Empty;
            // 印刷条件取得
            StockSalesResultInfoMainCndtn extraInfo = (StockSalesResultInfoMainCndtn)this._printInfo.jyoken;

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = SalesStockResultInfoMainAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new SalesStockInfoMainException(message, status);
            }

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;



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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            string target = string.Empty;

            //仕入日
            if (_stockSalesResultInfoMainCndtn.StStockDate != 0 || _stockSalesResultInfoMainCndtn.EdStockDate != 0)
            {

                string st_StockDate = string.Empty;
                string ed_StockDate = string.Empty;
                // 開始
                if (this._stockSalesResultInfoMainCndtn.StStockDate != 0)
                    st_StockDate = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.StStockDate);
                else
                    st_StockDate = ct_Extr_Top;
                // 終了
                if (this._stockSalesResultInfoMainCndtn.EdStockDate != 0)
                    ed_StockDate = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.EdStockDate);
                else
                    ed_StockDate = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("仕入日" + ct_RangeConst, st_StockDate, ed_StockDate));

            }

            //入力日
            if ((this._stockSalesResultInfoMainCndtn.StInputDay != 0) || (this._stockSalesResultInfoMainCndtn.EdInputDay != 0))
            {
                string st_InputDay = string.Empty;
                string ed_InputDay = string.Empty;
                // 開始
                if (this._stockSalesResultInfoMainCndtn.StInputDay != 0)
                    st_InputDay = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.StInputDay);
                else
                    st_InputDay = ct_Extr_Top;
                // 終了
                if (this._stockSalesResultInfoMainCndtn.EdInputDay != 0)
                    ed_InputDay = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.EdInputDay);
                else
                    ed_InputDay = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("入力日" + ct_RangeConst, st_InputDay, ed_InputDay));
            }


            //仕入先
            if ((this._stockSalesResultInfoMainCndtn.StSupplierCd == 0) && (this._stockSalesResultInfoMainCndtn.EdSupplierCd != 0))
            {
                //target = "仕入先 :" + ct_Extr_Top + " ～ " + this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06");
                //this.EditCondition(ref extraConditions, target);
                this.EditCondition(ref extraConditions, string.Format("仕入先" + ct_RangeConst, ct_Extr_Top, this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06")));
            }

            if ((this._stockSalesResultInfoMainCndtn.StSupplierCd > 0) && (this._stockSalesResultInfoMainCndtn.EdSupplierCd == 0))
            {
                //target = "仕入先 :" + this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06") + " ～ " + ct_Extr_End;
                //this.EditCondition(ref extraConditions, target);
                this.EditCondition(ref extraConditions, string.Format("仕入先" + ct_RangeConst, this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06"), ct_Extr_End));
            }

            if ((this._stockSalesResultInfoMainCndtn.StSupplierCd > 0) && (this._stockSalesResultInfoMainCndtn.EdSupplierCd != 0))
            {
                //target = "仕入先 :" + this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06") + " ～ " + this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06");
                //this.EditCondition(ref extraConditions, target);
                this.EditCondition(ref extraConditions, string.Format("仕入先" + ct_RangeConst, this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06"), this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06")));
            }

            //出力指定
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.WayToOrderTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("出力指定：{0}", _stockSalesResultInfoMainCndtn.WayToOrderTypeName));

            }

            //在庫取寄指定
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.StockOrderDivCdTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("在庫取寄指定：{0}", _stockSalesResultInfoMainCndtn.StockOrderDivCdTypeName));

            }

            //売上伝票指定
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.SalesTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("売上伝票指定：{0}", _stockSalesResultInfoMainCndtn.SalesTypeName));

            }

            //原価指定
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.StockUnitChngDivTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("原価指定：{0}", _stockSalesResultInfoMainCndtn.StockUnitChngDivTypeName));

            }

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
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKOU02063P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion

    }
}
