//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理印刷クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 発注点設定処理印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定処理の印刷を行う。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date	   : 2009.04.13</br>
    /// <br></br>
    /// </remarks>
    public class PMHAT09104PA : IPrintProc
    {
        #region ■ Constructor
        /// <summary>
        /// 発注点設定処理印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定処理印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        public PMHAT09104PA()
        {
        }

        /// <summary>
        /// 発注点設定処理印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 発注点設定処理印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        public PMHAT09104PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._paramWork = this._printInfo.jyoken as ExtrInfo_OrderPointStSimulationWorkTbl;
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_PGID_1 = "PMHAT09104P_01A4C";   // 品番順
        private const string ct_PGID_2 = "PMHAT09104P_02A4C";   // 棚番順
        private const string ct_PGID_3 = "PMHAT09104P_03A4C";   // メーカー・品番順
        private const string ct_PGID_4 = "PMHAT09104P_04A4C";   // メーカー・棚番順
        private const string ct_Space = "　";
        private const string ct_RangeConst = "{0} ～ {1}";
        private const string ct_DateFormat = "YYYY年MM月DD日";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					        // 印刷情報クラス
        private ExtrInfo_OrderPointStSimulationWorkTbl _paramWork;	            // 抽出条件クラス
        #endregion ■ Private Member

        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class OrderPointStSimulationException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public OrderPointStSimulationException(string message, int status)
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 印刷フォームクラスインスタンス作成
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
            try
            {
                // 帳票のプログラムIDの設定
                this.SetReportID(ref this._printInfo.prpid);

                // レポートインスタンス作成
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // 印刷データ取得
                DataSet printDataSet = (DataSet)this._printInfo.rdData;

                // フィルタ条件
                StringBuilder filter = new StringBuilder();

                DataTable data = printDataSet.Tables[OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation];
                // ソート順
                StringBuilder sort = new StringBuilder();
                sort.Append(OrderPointStSimulationTbl.Col_WarehouseCode);
                sort.Append(" ASC,");

                // 印刷条件取得
                ExtrInfo_OrderPointStSimulationWorkTbl extraInfo = (ExtrInfo_OrderPointStSimulationWorkTbl)this._printInfo.jyoken;

                switch (extraInfo.OutPutDiv)
                {
                    case 0:
                        // 品番順
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMGroup).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGroupCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGoodsCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsNo).Append(" ASC");
                        break;
                    case 1:
                        // 棚番順
                        sort.Append(OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMGroup).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGroupCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGoodsCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsNo).Append(" ASC");
                        break;
                    case 2:
                        // メーカー・品番順
                        sort.Append(OrderPointStSimulationTbl.Col_WarehouseCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsNo).Append(" ASC");
                        break;
                    case 3:
                        // メーカー・棚番順
                        sort.Append(OrderPointStSimulationTbl.Col_WarehouseCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC");
                        break;
                }
                DataView dv = new DataView(data, filter.ToString(), sort.ToString(), DataViewRowState.CurrentRows);

                OrderPointStSimulationAcs acs = new OrderPointStSimulationAcs();
                DataTable filterData = dv.ToTable();
                string lastWarehouseCode = string.Empty;
                string lastSupplierCd = string.Empty;
                string lastGoodsMakerCd = string.Empty;
                string lastWarehouseShelfNo = string.Empty;
                for (int i = 0; i < filterData.Rows.Count; i++)
                {
                    DataRow dr = filterData.Rows[i];
                    if (i == 0)
                    {
                        lastWarehouseCode = dr[OrderPointStSimulationTbl.Col_WarehouseCode].ToString().TrimEnd();
                        lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                        lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        lastWarehouseShelfNo = dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].ToString();
                    }
                    else
                    {
                        DataRow lastDr = filterData.Rows[i - 1];
                        bool isSame = false;
                        acs.DataFilter(extraInfo.OutPutDiv, extraInfo.FractionProcCd, ref dr, ref lastDr, out isSame, ref lastWarehouseCode, ref lastSupplierCd, ref lastWarehouseShelfNo, ref lastGoodsMakerCd);
                        if (isSame)
                        {
                            filterData.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
                dv = new DataView(filterData, filter.ToString(), sort.ToString(), DataViewRowState.CurrentRows);

                // データセットの変換
                DataTable dtTemp = dv.Table.Clone();
                dtTemp.TableName = OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation;
                foreach (DataRowView drv in dv)
                {
                    dtTemp.ImportRow(drv.Row);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dtTemp);
                this._printInfo.rdData = ds;
                
                // データソース設定
                prtRpt.DataSource = dv;

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
        #region ◎ 帳票IDの設定
        /// <summary>
        /// 帳票IDの設定
        /// </summary>
        /// <param name="pgId">プログラムID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 出力順により、帳票IDの設定を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private void SetReportID(ref string pgId)
        {
            pgId = string.Empty;

            // 印刷条件取得
            ExtrInfo_OrderPointStSimulationWorkTbl extraInfo = (ExtrInfo_OrderPointStSimulationWorkTbl)this._printInfo.jyoken;

            switch (extraInfo.OutPutDiv)
            {
                case 0: // 品番順
                    pgId = ct_PGID_1;
                    break;
                case 1: // 棚番順
                    pgId = ct_PGID_2;
                    break;
                case 2: // メーカー・品番順
                    pgId = ct_PGID_3;
                    break;
                case 3: // メーカー・棚番順
                    pgId = ct_PGID_4;
                    break;
            }
        }
        #endregion

        #region ◎ 各種ActiveReport帳票インスタンス作成
        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
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
                throw new OrderPointStSimulationException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new OrderPointStSimulationException(er.Message, -1);
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            ExtrInfo_OrderPointStSimulationWorkTbl extraInfo = (ExtrInfo_OrderPointStSimulationWorkTbl)this._printInfo.jyoken;

            // ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = GetSortOrderName(extraInfo);

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = OrderPointStSimulationAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new OrderPointStSimulationException(message, status);
            }

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations, extraInfo);
            instance.ExtraConditions = extraInfomations;

            // 抽出条件ヘッダ出力区分
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            // その他データ
            ArrayList otherDataList = new ArrayList();
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region ◎ 抽出条件出力情報作成
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <param name="rateUnMatchCndtn">抽出条件</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions, ExtrInfo_OrderPointStSimulationWorkTbl rateUnMatchCndtn)
        {
            extraConditions = new StringCollection();

            string target = string.Empty;

            // 設定コード
            this.EditCondition(ref extraConditions, string.Format("設定コード：{0}", rateUnMatchCndtn.SettingCode.ToString("d03")));

            // 倉庫コード
            if (!string.IsNullOrEmpty(rateUnMatchCndtn.St_WarehouseCode) || !string.IsNullOrEmpty(rateUnMatchCndtn.Ed_WarehouseCode))
            {
                string st_WarehouseCode = string.Empty;
                string ed_WarehouseCode = string.Empty;
                // 開始
                if (!string.IsNullOrEmpty(rateUnMatchCndtn.St_WarehouseCode))
                    st_WarehouseCode = rateUnMatchCndtn.St_WarehouseCode.PadLeft(4, '0');
                else
                    st_WarehouseCode = ct_Extr_Top;
                // 終了
                if (!string.IsNullOrEmpty(rateUnMatchCndtn.Ed_WarehouseCode))
                    ed_WarehouseCode = rateUnMatchCndtn.Ed_WarehouseCode.PadLeft(4, '0');
                else
                    ed_WarehouseCode = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("倉庫：" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
            }

            //仕入先
            if ((rateUnMatchCndtn.St_SupplierCd == 0) && (rateUnMatchCndtn.Ed_SupplierCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("仕入先：" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_SupplierCd.ToString("d06")));
            }

            if ((rateUnMatchCndtn.St_SupplierCd > 0) && (rateUnMatchCndtn.Ed_SupplierCd == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("仕入先：" + ct_RangeConst, rateUnMatchCndtn.St_SupplierCd.ToString("d06"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_SupplierCd > 0) && (rateUnMatchCndtn.Ed_SupplierCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("仕入先：" + ct_RangeConst, rateUnMatchCndtn.St_SupplierCd.ToString("d06"), rateUnMatchCndtn.Ed_SupplierCd.ToString("d06")));
            }

            //メーカー
            if ((rateUnMatchCndtn.St_GoodsMakerCd == 0) && (rateUnMatchCndtn.Ed_GoodsMakerCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("ﾒｰｶｰ：" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_GoodsMakerCd.ToString("d04")));
            }

            if ((rateUnMatchCndtn.St_GoodsMakerCd > 0) && (rateUnMatchCndtn.Ed_GoodsMakerCd == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("ﾒｰｶｰ：" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMakerCd.ToString("d04"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_GoodsMakerCd > 0) && (rateUnMatchCndtn.Ed_GoodsMakerCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("ﾒｰｶｰ：" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMakerCd.ToString("d04"), rateUnMatchCndtn.Ed_GoodsMakerCd.ToString("d04")));
            }

            // 中分類
            if ((rateUnMatchCndtn.St_GoodsMGroup == 0) && (rateUnMatchCndtn.Ed_GoodsMGroup != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("中分類：" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_GoodsMGroup.ToString("d04")));
            }

            if ((rateUnMatchCndtn.St_GoodsMGroup > 0) && (rateUnMatchCndtn.Ed_GoodsMGroup == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("中分類：" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMGroup.ToString("d04"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_GoodsMGroup > 0) && (rateUnMatchCndtn.Ed_GoodsMGroup != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("中分類：" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMGroup.ToString("d04"), rateUnMatchCndtn.Ed_GoodsMGroup.ToString("d04")));
            }

            // グループ
            if ((rateUnMatchCndtn.St_BLGroupCode == 0) && (rateUnMatchCndtn.Ed_BLGroupCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("ｸﾞﾙｰﾌﾟ：" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_BLGroupCode.ToString("d05")));
            }

            if ((rateUnMatchCndtn.St_BLGroupCode > 0) && (rateUnMatchCndtn.Ed_BLGroupCode == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("ｸﾞﾙｰﾌﾟ：" + ct_RangeConst, rateUnMatchCndtn.St_BLGroupCode.ToString("d05"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_BLGroupCode > 0) && (rateUnMatchCndtn.Ed_BLGroupCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("ｸﾞﾙｰﾌﾟ：" + ct_RangeConst, rateUnMatchCndtn.St_BLGroupCode.ToString("d05"), rateUnMatchCndtn.Ed_BLGroupCode.ToString("d05")));
            }

            // BLコード
            if ((rateUnMatchCndtn.St_BLGoodsCode == 0) && (rateUnMatchCndtn.Ed_BLGoodsCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("BLｺｰﾄﾞ：" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_BLGoodsCode.ToString("d05")));
            }

            if ((rateUnMatchCndtn.St_BLGoodsCode > 0) && (rateUnMatchCndtn.Ed_BLGoodsCode == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("BLｺｰﾄﾞ：" + ct_RangeConst, rateUnMatchCndtn.St_BLGoodsCode.ToString("d05"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_BLGoodsCode > 0) && (rateUnMatchCndtn.Ed_BLGoodsCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("BLｺｰﾄﾞ：" + ct_RangeConst, rateUnMatchCndtn.St_BLGoodsCode.ToString("d05"), rateUnMatchCndtn.Ed_BLGoodsCode.ToString("d05")));
            }

            // 管理区分１
            if (rateUnMatchCndtn.ManagementDivide1.Length > 0)
            {
                this.EditCondition(ref extraConditions, string.Format("管理区分１：{0}", GetManagerDiv(rateUnMatchCndtn.ManagementDivide1)));
            }

            // 管理区分２
            if (rateUnMatchCndtn.ManagementDivide2.Length > 0)
            {
                this.EditCondition(ref extraConditions, string.Format("管理区分２：{0}", GetManagerDiv(rateUnMatchCndtn.ManagementDivide2)));
            }

            // 集計方法
            this.EditCondition(ref extraConditions, string.Format("集計方法：{0}", rateUnMatchCndtn.SumMethodNm));

            // 出荷対象期間
            if (rateUnMatchCndtn.StckShipMonthSt != 0 || rateUnMatchCndtn.StckShipMonthEd != 0)
            {
                string st_StckShipMonth = string.Empty;
                string ed_StckShipMonth = string.Empty;
                // 開始
                if (rateUnMatchCndtn.StckShipMonthSt != 0)
                    st_StckShipMonth = TDateTime.LongDateToString(ct_DateFormat, rateUnMatchCndtn.StckShipMonthSt);
                else
                    st_StckShipMonth = ct_Extr_Top;
                // 終了
                if (rateUnMatchCndtn.StckShipMonthEd != 0)
                    ed_StckShipMonth = TDateTime.LongDateToString(ct_DateFormat, rateUnMatchCndtn.StckShipMonthEd);
                else
                    ed_StckShipMonth = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("出荷対象期間：" + ct_RangeConst, st_StckShipMonth, ed_StckShipMonth));
            }

            // 在庫登録日付
            this.EditCondition(ref extraConditions, string.Format("在庫登録日付：{0}{1}", TDateTime.LongDateToString(ct_DateFormat, rateUnMatchCndtn.StockCreateDate), "以前"));
        }
        #endregion

        #region 管理区分の出力設定
        /// <summary>
        /// 管理区分の出力設定
        /// </summary>
        /// <param name="value">設定値</param>
        /// <returns>string</returns>
        /// <remarks>
        /// <br>Note       : 管理区分出力設定を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private string GetManagerDiv(string[] value)
        {
            string ret;
            if (value == null || value.Length == 0)
            {
                ret = string.Empty;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string str in value)
                {
                    sb.Append(str);
                }
                ret = sb.ToString();
            }

            return ret;
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
        /// <br>Programmer : 劉学智</br>
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

        #region ◎ ソート順名称取得
        /// <summary>
        /// ソート順名称取得
        /// </summary>
        /// <param name="rateUnMatchCndtn">抽出条件</param>
        /// <returns>ソート順名称</returns>
        /// <remarks>
        /// <br>Note       : ソート順名称を取得する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private string GetSortOrderName(ExtrInfo_OrderPointStSimulationWorkTbl rateUnMatchCndtn)
        {
            string strOrder = string.Empty;
            switch (rateUnMatchCndtn.OutPutDiv)
            {
                case 0:
                    strOrder = "品番順";
                    break;
                case 1:
                    strOrder = "棚番順";
                    break;
                case 2:
                    strOrder = "メーカー・品番順";
                    break;
                case 3:
                    strOrder = "メーカー・棚番順";
                    break;
            }
            return strOrder;
        }
        #endregion
        #endregion ◆ レポートフォーム設定関連

        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            return string.Empty;
        }
        #endregion

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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHAT09104P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
