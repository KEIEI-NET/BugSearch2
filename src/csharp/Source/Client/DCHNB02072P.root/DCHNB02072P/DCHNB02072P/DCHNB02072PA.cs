using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 売上月報年報印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月報年報の印刷を行なうクラスです。</br>
    /// <br>Programer  : 980035　金沢　貞義</br>
    /// <br>Date       : 2007.12.07</br>
    /// <br>Update Note: 2008.03.05 980035 金沢 貞義</br>
    /// <br>			 ・不具合修正（DC.NS対応）</br>
    /// <br>Update Note: 2008.09.08 30452 上野 俊治</br>
    /// <br>			 ・PM.NS対応</br>
    /// <br>Update Note: 2009.01.23 30452 上野 俊治</br>
    /// <br>			 ・障害対応8832（帳票フッタ実装）</br>
    /// <br>Update Note: 2009.02.06 30452 上野 俊治</br>
    /// <br>			 ・障害対応10925,10984（ソートの修正）</br>
    /// </remarks>
    public class DCHNB02072PA
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 売上月報年報印刷クラスコンストラクタ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 売上月報年報印刷クラスの新しいインスタンスを生成します</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        public DCHNB02072PA()
        {
        }

        /// <summary>
        /// 売上月報年報印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 売上月報年報印刷クラスの新しいインスタンスを生成します</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        public DCHNB02072PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;

            this._pdfHistoryControl = new PdfHistoryControl();
            this._sfcmn00331C = new SFCMN00331C();

            this._salesMonthYearReportPara = this._printInfo.jyoken as SalesMonthYearReportCndtn;

            this.SelectTableName();

        }
        #endregion

        //================================================================================
        //  内部定数
        //================================================================================
        #region private constant
        private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
        private const string CT_ITEM_INTERVAL = "　　　　　";

        //--- DEL 2008.08.14 ---------->>>>>
        // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 開始 抽出範囲初期値(印刷用) </summary>
        //private const string ct_Extr_Top = "ＴＯＰ";
        ///// <summary> 終了 抽出範囲初期値(印刷用) </summary>
        //private const string ct_Extr_End = "ＥＮＤ";
        // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008.08.14 ----------<<<<<
        //--- ADD 2008.08.14 ---------->>>>>
        /// <summary> 開始 抽出範囲初期値(印刷用) </summary>
        private const string ct_Extr_Top = "最初から";
        /// <summary> 終了 抽出範囲初期値(印刷用) </summary>
        private const string ct_Extr_End = "最後まで";
        //--- ADD 2008.08.14 ----------<<<<<
        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;
        private PdfHistoryControl _pdfHistoryControl = null;
        private SFCMN00331C _sfcmn00331C = null;			// 帳票系共通部品
        private SalesMonthYearReportCndtn _salesMonthYearReportPara = null;
        #endregion

        // /// <summary>表示順位</summary>
        //private string CT_Sort1_Odr = "SectionCodes, CustomerCode";
        //private string CT_Sort2_Odr = "SectionCodes, SalesAreaCode, CustomerCode";
        //private string CT_Sort3_Odr = "SectionCodes, BusinessTypeCode, CustomerCode";
        /* --- DEL 2008/09/08 -------------------------------->>>>>
        //--- ADD 2008.08.14 ---------->>>>>
        /// <summary>拠点-順位-得意先コード</summary>
        private string CT_Sort1_Odr = "SectionCode, Order, CustomerCode asc";
        /// <summary>拠点-得意先コード</summary>
        private string CT_Sort2_Odr = "SectionCode, CustomerCode asc";
        /// <summary>拠点-順位</summary>
        private string CT_Sort3_Odr = "SectionCode, Order asc";
        /// <summary></summary>
        private string CT_Sort4_Odr = "SectionCode, CustomerCode asc";
        private string CT_Sort5_Odr = "Order, CustomerCode, SectionCode asc";
        private string CT_Sort6_Odr = "CustomerCode, SectionCode asc";
        //--- ADD 2008.08.14 ----------<<<<<
        --- DEL 2008/09/08 -------------------------------->>>>> */

        // --- ADD 2008/09/08 -------------------------------->>>>>
        private string CT_Sort1_OdrStr = "得意先";
        private string CT_Sort2_OdrStr = "管理拠点";

        private string CT_Sort3_OdrStr = "拠点";
        private string CT_Sort4_OdrStr = "得意先－拠点";
        private string CT_Sort5_OdrStr = "請求先";

        private string CT_Sort6_OdrStr = "担当者";
        private string CT_Sort7_OdrStr = "担当者－拠点";

        private string CT_Sort8_OdrStr = "受注者";
        private string CT_Sort9_OdrStr = "受注者－拠点";

        private string CT_Sort10_OdrStr = "発行者";
        private string CT_Sort11_OdrStr = "発行者－拠点";

        private string CT_Sort12_OdrStr = "地区";
        private string CT_Sort13_OdrStr = "地区－拠点";

        private string CT_Sort14_OdrStr = "業種";
        private string CT_Sort15_OdrStr = "業種－拠点";
        // --- ADD 2008/09/08 --------------------------------<<<<<

        //--- DEL 2008.08.14 ---------->>>>>
        //private string CT_Sort2_OdrStr = "地区→得意先";
        //private string CT_Sort3_OdrStr = "業種→得意先";
        //// 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
        //private string CT_Sort4_OdrStr = "地区";
        //private string CT_Sort5_OdrStr = "業種";
        //private string CT_Sort6_OdrStr = "担当者";
        //private string CT_Sort7_OdrStr = "部署→課";
        //private string CT_Sort8_OdrStr = "メーカー";
        //private string CT_Sort9_OdrStr = "得意先→メーカー";
        //private string CT_Sort7b_OdrStr= "部署";
        //// 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008.08.14 ----------<<<<<

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
        /// <br>Date       : 2007.12.07</br>
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
        /// <br>Date       : 2007.12.07</br>
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

        /// <summary>
        /// 仕様テーブル名設定処理
        /// </summary>
        private void SelectTableName()
        {
            // 売上月報年報名称
            ct_TableName = DCHNB02074EA.ct_Tbl_SalesMonthYearReportDtl;
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
        /// <br>Date       : 2007.12.07</br>
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
        /// <br>Date       : 2007.12.07</br>
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
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
            // ソート順名称設定
            instance.PageHeaderSortOderTitle = GetSortOrderName(this._salesMonthYearReportPara);
            // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<

            // 抽出条件ヘッダ作成(項目値設定)
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // --- ADD 2009/01/23 -------------------------------->>>>>
            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = SalesTableAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }

            // 抽出条件ヘッダ出力区分
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // --- ADD 2009/01/23 --------------------------------<<<<<

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion

        // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
        #region ◆　ソート順名称取得
        /// <summary>
		/// ソート順名称取得
		/// </summary>
        /// <param name="reportCndtn">抽出条件</param>
		/// <returns>ソート順名称</returns>
		/// <remarks>
		/// <br>Note       : ソート順名称を取得する。</br>
		/// <br>Programmer : 980035 金沢 貞義</br>
		/// <br>Date       : 2009.03.05</br>
		/// </remarks>
        private string GetSortOrderName(SalesMonthYearReportCndtn reportCndtn)
        {
            string sortOrderName = string.Empty;
            const string ct_SortFomat = "[{0}{1}]";

            #region 削除
            //--- DEL 2008.08.14 ---------->>>>>
            //switch (reportCndtn.TotalType)
            //{
            //    case 0: // 0:拠点
            //        {
            //            break;
            //        }
            //    case 1: // 1:得意先別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort1_OdrStr + " 順");
            //            break;
            //        }
            //    case 2: // 2:地区別得意先別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort2_OdrStr + " 順");
            //            break;
            //        }
            //    case 3: // 3:業種別得意先別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort3_OdrStr + " 順");
            //            break;
            //        }
            //    case 4: // 4:地区別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort4_OdrStr + " 順");
            //            break;
            //        }
            //    case 5: // 5:業種別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort5_OdrStr + " 順");
            //            break;
            //        }
            //    case 6: // 6:担当者別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort6_OdrStr + " 順");
            //            break;
            //        }
            //    case 7: // 7:部署別
            //        {
            //            if (reportCndtn.SectionDiv == 2)
            //            {
            //                sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort7_OdrStr + " 順");
            //            }
            //            else
            //            {
            //                sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort7b_OdrStr + " 順");
            //            }
            //            break;
            //        }
            //    case 8: // 8:メーカー別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort8_OdrStr + " 順");
            //            break;
            //        }
            //    case 9: // 9:得意先別メーカー別
            //        {
            //            sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort9_OdrStr + " 順");
            //            break;
            //        }
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            // sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort1_OdrStr + " 順");
            // --- DEL 2008/09/08 --------------------------------<<<<<
            #endregion
            // --- ADD 2008/09/08 -------------------------------->>>>>

            if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer) //得意先別
            {
                if (reportCndtn.OutType == 0)
                {
                    // 得意先
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort1_OdrStr + "順");
                }
                else if (reportCndtn.OutType == 1)
                {
                    // 拠点
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort3_OdrStr + "順");
                }
                else if (reportCndtn.OutType == 2)
                {
                    // 得意先－拠点
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort4_OdrStr + "順");
                }
                else if (reportCndtn.OutType == 3)
                {
                    // 管理拠点
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort2_OdrStr + "順");
                }
                else if (reportCndtn.OutType == 4)
                {
                    // 請求先
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort5_OdrStr + "順");
                }
            }
            else if (reportCndtn.TotalType != (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision) // 販売区分別以外 
            {
                if (reportCndtn.OutType == 0)
                {
                    if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee) // 担当者
                    {
                        // 担当者
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort6_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee) // 受注者
                    {
                        // 受注先
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort8_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput) // 発行者
                    {
                        // 発行者
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort10_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area) // 地区
                    {
                        // 地区
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort12_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType) // 業種
                    {
                        // 業種
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort14_OdrStr + "順");
                    }
                }
                else if (reportCndtn.OutType == 1)
                {
                    // 得意先
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort1_OdrStr + "順");
                }
                else if (reportCndtn.OutType == 2)
                {
                    if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee) // 担当者
                    {
                        // 担当者－拠点
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort7_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee) // 受注者
                    {
                        // 受注先－拠点
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort9_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput) // 発行者
                    {
                        // 発行者－拠点
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort11_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area) // 地区
                    {
                        // 地区－拠点
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort13_OdrStr + "順");
                    }
                    else if (reportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType) // 業種
                    {
                        // 業種－拠点
                        sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort15_OdrStr + "順");
                    }
                }
                else if (reportCndtn.OutType == 3)
                {
                    // 管理拠点
                    sortOrderName = string.Format(ct_SortFomat, string.Empty, CT_Sort2_OdrStr + "順");
                }
            }
            // --- ADD 2008/09/08 --------------------------------<<<<<

            return sortOrderName;
        }
        #endregion
        // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<

        #region ◆　抽出条件ヘッダー作成処理
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            string target = "";
            string stTarget = "";
            string edTarget = "";
            string wrkstr = "";

            const string stNoInput = "最初から";
            const string edNoInput = "最後まで";

            #region < 対象年月 >
            if (this._salesMonthYearReportPara.AddUpYearMonthSt != DateTime.MinValue
                || this._salesMonthYearReportPara.AddUpYearMonthEd != DateTime.MinValue) // ADD 2008/10/02
            {
                stTarget = "対象年月： " + TDateTime.DateTimeToString("YYYY/MM", this._salesMonthYearReportPara.AddUpYearMonthSt);
                edTarget = "  ～　" + TDateTime.DateTimeToString("YYYY/MM", this._salesMonthYearReportPara.AddUpYearMonthEd);

                target = stTarget + edTarget;

                this.EditCondition(ref extraConditions, target);
            }
            #endregion

            #region < 集計方法 >
            target = "集計方法：" + this._salesMonthYearReportPara.TtlTypeName;
            this.EditCondition(ref extraConditions, target);
            #endregion

            #region < 集計単位 >
            // 2008.03.05 削除 >>>>>>>>>>>>>>>>>>>>
            //target = "集計単位：" + this._salesMonthYearReportPara.TotalTypeName;
            //this.EditCondition(ref extraConditions, target);
            // 2008.03.05 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion

            #region < 印刷タイプ >
            wrkstr = "";
            if (this._salesMonthYearReportPara.PrintType == 2)
            {
                wrkstr = "上段・当月／下段・当期";
            }
            else
            {
                wrkstr = this._salesMonthYearReportPara.PrintTypeName;
            }

            target = "印刷タイプ：" + wrkstr;
            this.EditCondition(ref extraConditions, target);
            #endregion

            #region < 構成比単位 >
            target = "構成比単位：" + this._salesMonthYearReportPara.ConstUnitName;
            this.EditCondition(ref extraConditions, target);
            #endregion

            #region < 金額単位 >
            target = "金額単位：" + this._salesMonthYearReportPara.MoneyUnitName;
            this.EditCondition(ref extraConditions, target);
            #endregion

            #region < 改頁 >
            if (this._salesMonthYearReportPara.CrMode1 || this._salesMonthYearReportPara.CrMode2)
            {
                target = "改頁：";

                if (this._salesMonthYearReportPara.CrMode1)
                {
                    target += "拠点単位";
                }

                if (this._salesMonthYearReportPara.CrMode2)
                {
                    switch (this._salesMonthYearReportPara.TotalType)
                    {
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                            {
                                target += " 得意先単位 ";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                            {
                                target += " 担当者単位 ";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                            {
                                target += " 受注者単位 ";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                            {
                                target += " 発行者単位 ";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                            {
                                target += " 地区単位 ";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                            {
                                target += " 業種単位 ";
                                break;
                            }
                    }
                }

                this.EditCondition(ref extraConditions, target);
            }
            #endregion

            #region < ソート順 >
            // 2008.03.05 削除 >>>>>>>>>>>>>>>>>>>>
            //wrkstr = "";
            //target = "";
            //if ((this._salesMonthYearReportPara.TotalType > 0) && (this._salesMonthYearReportPara.TotalType < 4))
            //{
            //    switch (this._salesMonthYearReportPara.TotalType)
            //    {
            //        case 1:
            //            {
            //                wrkstr = CT_Sort1_OdrStr;
            //                break;
            //            }
            //        case 2:
            //            {
            //                wrkstr = CT_Sort2_OdrStr;
            //                break;
            //            }
            //        case 3:
            //            {
            //                wrkstr = CT_Sort3_OdrStr;
            //                break;
            //            }
            //    }
            //    target = "ソート順：" + wrkstr + " 順";
            //    this.EditCondition(ref extraConditions, target);
            //}
            // 2008.03.05 削除 <<<<<<<<<<<<<<<<<<<<
            #endregion

            // 2008.03.05 追加 >>>>>>>>>>>>>>>>>>>>
            StringCollection addConditions = new StringCollection();

            //--- DEL 2008.08.14 ---------->>>>>
            #region < 担当者 >
            //if (this._salesMonthYearReportPara.TotalType == 6)
            //{
            //    if ((this._salesMonthYearReportPara.SalesEmployeeCdSt != string.Empty) || (this._salesMonthYearReportPara.SalesEmployeeCdEd != string.Empty))
            //    {
            //        this.EditCondition(ref addConditions,
            //            this.GetConditionRange("担当者コード", this._salesMonthYearReportPara.SalesEmployeeCdSt, this._salesMonthYearReportPara.SalesEmployeeCdEd));
            //    }
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < 地区 >
            //if ((this._salesMonthYearReportPara.TotalType == 2) ||
            //    (this._salesMonthYearReportPara.TotalType == 4))
            //{
            //    if ((this._salesMonthYearReportPara.SalesAreaCodeSt != 0) || (this._salesMonthYearReportPara.SalesAreaCodeEd != 0))
            //    {
            //        int ed_Code = this._salesMonthYearReportPara.SalesAreaCodeEd;
            //        if (ed_Code == 0) ed_Code = 9999;

            //        this.EditCondition(ref addConditions,
            //            string.Format("地区コード：{0} ～ {1}",
            //            String.Format("{0:D}", this._salesMonthYearReportPara.SalesAreaCodeSt),
            //            String.Format("{0:D}", ed_Code)
            //            )
            //        );
            //    }
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < 業種 >
            //if ((this._salesMonthYearReportPara.TotalType == 3) ||
            //    (this._salesMonthYearReportPara.TotalType == 5))
            //{
            //    if ((this._salesMonthYearReportPara.BusinessTypeCodeSt != 0) || (this._salesMonthYearReportPara.BusinessTypeCodeEd != 0))
            //    {
            //        int ed_Code = this._salesMonthYearReportPara.BusinessTypeCodeEd;
            //        if (ed_Code == 0) ed_Code = 9999;

            //        this.EditCondition(ref addConditions,
            //            string.Format("業種コード：{0} ～ {1}",
            //            String.Format("{0:D}", this._salesMonthYearReportPara.BusinessTypeCodeSt),
            //            String.Format("{0:D}", ed_Code)
            //            )
            //        );
            //    }
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            #region < 印刷順 >
            this.EditCondition(ref addConditions,
                string.Format("印刷順：{0}", this._salesMonthYearReportPara.PrintOrderTitle)
            );
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<

            // --- ADD 2008/09/08 -------------------------------->>>>>
            #region < 条件2 >
            if (this._salesMonthYearReportPara.TotalType != 0)
            {
                if (this._salesMonthYearReportPara.SearchCodeSt != string.Empty || this._salesMonthYearReportPara.SearchCodeEd != string.Empty)
                {
                    string search_str = "";
                    string stName;
                    string edName;

                    switch (this._salesMonthYearReportPara.TotalType)
                    {
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                            {
                                search_str = "担当者";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                            {
                                search_str = "受注者";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                            {
                                search_str = "発行者";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                            {
                                search_str = "地区";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                            {
                                search_str = "業種";
                                break;
                            }
                        case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                            {
                                search_str = "販売区分";
                                break;
                            }
                    }

                    if (this._salesMonthYearReportPara.SearchCodeSt == string.Empty)
                    {
                        stName = stNoInput;
                    }
                    else
                    {
                        stName = this._salesMonthYearReportPara.SearchCodeSt.PadLeft(4, '0');
                    }

                    //if (this._salesMonthYearReportPara.SearchCodeEd == "9999") // DEL 2008/10/24
                    if (this._salesMonthYearReportPara.SearchCodeEd == string.Empty) // ADD 2008/10/24
                    {
                        edName = edNoInput;
                    }
                    else
                    {
                        edName = this._salesMonthYearReportPara.SearchCodeEd.PadLeft(4, '0');
                    }

                    this.EditCondition(ref addConditions,
                        string.Format(search_str + "：{0} ～ {1}", stName, edName));
                    // --- DEL 2008/10/02 -------------------------------->>>>>
                    //this.EditCondition(ref addConditions,
                    //    string.Format(search_str + "：{0} ～ {1}",
                    //    this._salesMonthYearReportPara.SearchCodeSt.PadLeft(4, '0'),
                    //    this._salesMonthYearReportPara.SearchCodeEd.PadLeft(4, '0')
                    //    )
                    //);
                    // --- DEL 2008/10/02 --------------------------------<<<<<
                }
            }
            #endregion
            // --- ADD 2008/09/08 --------------------------------<<<<<

            #region < 得意先 >
            //--- DEL 2008.08.14 ---------->>>>>
            //if ((this._salesMonthYearReportPara.TotalType == 1) ||
            //    (this._salesMonthYearReportPara.TotalType == 2) ||
            //    (this._salesMonthYearReportPara.TotalType == 3) ||
            //    (this._salesMonthYearReportPara.TotalType == 4) ||
            //    (this._salesMonthYearReportPara.TotalType == 5) ||
            //    (this._salesMonthYearReportPara.TotalType == 6) ||
            //    (this._salesMonthYearReportPara.TotalType == 9))
            //{
            //    if ((this._salesMonthYearReportPara.CustomerCodeSt != 0) || (this._salesMonthYearReportPara.CustomerCodeEd != 0))
            //    {
            //        int ed_Code = this._salesMonthYearReportPara.CustomerCodeEd;
            //        if (ed_Code == 0) ed_Code = 999999999;

            //        this.EditCondition(ref addConditions,
            //            //string.Format("得意先コード：{0} ～ {1}",     // DEL 2008.08.14
            //            string.Format("得意先：{0} ～ {1}",             // ADD 2008.08.14
            //            String.Format("{0:D}", this._salesMonthYearReportPara.CustomerCodeSt),
            //            String.Format("{0:D}", ed_Code)
            //            )
            //        );
            //    }
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            //if ((this._salesMonthYearReportPara.CustomerCodeSt != 0) || (this._salesMonthYearReportPara.CustomerCodeEd != 99999999)) // DEL 2008/10/24
            if ((this._salesMonthYearReportPara.CustomerCodeSt != 0) || (this._salesMonthYearReportPara.CustomerCodeEd != 0)) // ADD 2008/10/24
            {
                // --- ADD 2008/10/02 -------------------------------->>>>>
                string stName;
                string edName;

                if (this._salesMonthYearReportPara.CustomerCodeSt == 0)
                {
                    stName = stNoInput;
                }
                else
                {
                    stName = String.Format("{0:D8}", this._salesMonthYearReportPara.CustomerCodeSt);
                }

                //if (this._salesMonthYearReportPara.CustomerCodeEd == 99999999) // DEL 2008/10/24
                if (this._salesMonthYearReportPara.CustomerCodeEd == 0) // ADD 2008/10/24
                {
                    edName = edNoInput;
                }
                else
                {
                    edName = String.Format("{0:D8}", this._salesMonthYearReportPara.CustomerCodeEd);
                }

                int ed_Code = this._salesMonthYearReportPara.CustomerCodeEd;
                if (ed_Code == 0) ed_Code = 999999999;

                this.EditCondition(ref addConditions,
                    string.Format("得意先：{0} ～ {1}", stName, edName));
                // --- ADD 2008/10/02 --------------------------------<<<<<

                // --- DEL 2008/10/02 -------------------------------->>>>>
                //// --- DEL 2008/09/08 -------------------------------->>>>>
                ////this.EditCondition(ref addConditions,
                ////    //string.Format("得意先コード：{0} ～ {1}",     // DEL 2008.08.14
                ////    string.Format("得意先：{0} ～ {1}",             // ADD 2008.08.14
                ////    String.Format("{0:D}", this._salesMonthYearReportPara.CustomerCodeSt),
                ////    String.Format("{0:D}", ed_Code)
                ////    )
                ////);
                //// --- DEL 2008/09/08 --------------------------------<<<<<
                //// --- ADD 2008/09/08 -------------------------------->>>>>
                //this.EditCondition(ref addConditions,
                //    //string.Format("得意先コード：{0} ～ {1}",     // DEL 2008.08.14
                //    string.Format("得意先：{0} ～ {1}",             // ADD 2008.08.14
                //    String.Format("{0:D8}", this._salesMonthYearReportPara.CustomerCodeSt),
                //    String.Format("{0:D8}", ed_Code)
                //    )
                //);
                //// --- ADD 2008/09/08 --------------------------------<<<<<
                // --- DEL 2008/10/02 --------------------------------<<<<<
            }
            //--- ADD 2008.08.14 ----------<<<<<
            #endregion

            //--- DEL 2008.08.14 ---------->>>>>
            #region < メーカー >
            //if ((this._salesMonthYearReportPara.TotalType == 8) ||
            //    (this._salesMonthYearReportPara.TotalType == 9))
            //{
            //    if ((this._salesMonthYearReportPara.GoodsMakerCdSt != 0) || (this._salesMonthYearReportPara.GoodsMakerCdEd != 0))
            //    {
            //        int ed_Code = this._salesMonthYearReportPara.GoodsMakerCdEd;
            //        if (ed_Code == 0) ed_Code = 999999;

            //        this.EditCondition(ref addConditions,
            //            string.Format("メーカーコード：{0} ～ {1}",
            //            String.Format("{0:D}", this._salesMonthYearReportPara.GoodsMakerCdSt),
            //            String.Format("{0:D}", ed_Code)
            //            )
            //        );
            //    }
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            #region < 順位付け >
            this.EditCondition(ref addConditions,
                string.Format("順位付け：{0}で　{1}{2}位まで", this._salesMonthYearReportPara.OrderUnitTitle, this._salesMonthYearReportPara.OrderMethodTitle, this._salesMonthYearReportPara.OrderRange));
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            #region < 順位指定 >
            this.EditCondition(ref addConditions,
                string.Format("順位指定：{0}", this._salesMonthYearReportPara.OrderAppointmentTitle)
            );
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
            // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<
        }

        // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<
        /// <summary>
        /// 抽出範囲文字列作成
        /// </summary>
        /// <returns>作成文字列</returns>
        /// <remarks>
        /// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2008.03.05</br>
        /// </remarks>
        private string GetConditionRange(string title, string startString, string endString)
        {
            string result = "";
            if ((startString != "") || (endString != ""))
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if (startString != "") start = startString;
                if (endString != "") end = endString;
                result = String.Format(title + "： {0} ～ {1}", start, end);
            }
            return result;
        }
        // 2008.03.05 追加 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
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
        /// <br>Date       : 2007.12.07</br>
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
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";
            /*
            //switch (this._salesMonthYearReportPara.SortOrder)
            switch (this._salesMonthYearReportPara.TotalType)
            {
                case 1:
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case 2:
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 3:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
            }
            */

            // --- ADD 2008/09/08 -------------------------------->>>>>
            //--- ADD 2008.08.14 ---------->>>>>
            switch (this._salesMonthYearReportPara.TotalType) // 集計単位
            {
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                    {
                        switch (_salesMonthYearReportPara.OutType) // 出力順
                        {
                            case 0: // 得意先
                            case 3: // 管理拠点
                            case 4: // 請求先
                                {
                                    if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order) // 印刷順 順位
                                    {
                                        oderQuerry = "SectionCode, Order, CustomerCode asc";
                                    }
                                    else // コード
                                    {
                                        oderQuerry = "SectionCode, CustomerCode asc";
                                    }
                                    break;
                                }
                            case 1: // 拠点
                                {
                                    if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        oderQuerry = "Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        oderQuerry = "SectionCode asc";
                                    }
                                    break;
                                }
                            case 2: // 得意先－拠点
                                {
                                    if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        oderQuerry = "CustomerCode, Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        oderQuerry = "CustomerCode, SectionCode asc";
                                    }
                                    break;
                                }
                        }

                        break;
                    }

                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area:
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType:
                    {
                        switch (_salesMonthYearReportPara.OutType) // 出力順
                        {
                            case 0: // 検索条件名 (担当者 等)
                            case 3: // 管理拠点
                                {
                                    if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order) // 印刷順 順位
                                    {
                                        oderQuerry = "SectionCode, Order, Code asc";
                                    }
                                    else // コード
                                    {
                                        oderQuerry = "SectionCode, Code asc";
                                    }
                                    break;
                                }
                            case 1: // 得意先
                                {
                                    if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        oderQuerry = "SectionCode, Code, Order, CustomerCode asc";
                                    }
                                    else
                                    {
                                        oderQuerry = "SectionCode, Code, CustomerCode asc";
                                    }
                                    break;
                                }
                            case 2: // 検索条件-拠点
                                {
                                    if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                                    {
                                        oderQuerry = "Code, Order, SectionCode asc";
                                    }
                                    else
                                    {
                                        oderQuerry = "Code, SectionCode asc";
                                    }
                                    break;
                                }
                        }

                        break;
                    }

                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision:
                    {
                        if (_salesMonthYearReportPara.PrintOrder == SalesMonthYearReportCndtn.PrintOrderDivState.Order)
                        {
                            //oderQuerry = "SectionCode, Order asc"; // DEL 2009/02/06
                            oderQuerry = "SectionCode, Order, Code asc"; // ADD 2009/02/06
                        }
                        else
                        {
                            //oderQuerry = "SectionCode asc"; // DEL 2009/02/06
                            oderQuerry = "SectionCode, Code asc"; // ADD 2009/02/06
                        }
                        break;
                    }

            }
            //--- ADD 2008.08.14 ----------<<<<<
            // --- ADD 2008/09/08 --------------------------------<<<<<

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
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "DCHNB02072P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion
    }
}
