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
    /// 売上推移表印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上推移表の印刷を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>Update Note: 2008.10.16 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>UpdateNote : 2008/10/30 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote : 2009/02/24 96186 立花裕輔　メモリーエラー対応</br>
    /// <br>Update Note: 2009/04/15 張莉莉</br>
    /// <br>            ・売上推移表（仕入先別）の追加</br>
    /// <br>Update Note: 2014/12/16 劉超</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           :・明治産業様Seiken品番変更</br>
    /// </remarks>
    class DCTOK02132PA : IPrintProc
    {
        #region ■ Constructor
        /// <summary>
        /// 売上推移表印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上推移表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public DCTOK02132PA()
        {
        }

        /// <summary>
        /// 売上推移表印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 売上推移表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public DCTOK02132PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._salesTransListCndtn = this._printInfo.jyoken as SalesTransListCndtn;
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        //private const string ct_Extr_Top = "ＴＯＰ"; // DEL 2008/10/16
        //private const string ct_Extr_End = "ＥＮＤ"; // DEL 2008/10/16
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        private const string ct_RangeConst = "：{0} ～ {1}";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private SalesTransListCndtn _salesTransListCndtn;		// 抽出条件クラス
        #endregion ■ Private Member

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
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
                prtRpt.DataMember = DCTOK02134EA.ct_Tbl_SalesTransList;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //this.SetPrintCommonInfo( out commonInfo );

                this.SetPrintCommonInfo(ref prtRpt, out commonInfo);
                // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
                    // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    prtRpt.Document.Dispose();
                    // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
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
        #endregion

        #region ◎ 印刷画面共通情報設定

        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="rptObj"></param>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)

        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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

            // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            SalesTransListCndtn extraInfo = (SalesTransListCndtn)this._printInfo.jyoken;

            // ソート順プロパティ設定
            //instance.PageHeaderSortOderTitle = "";
            instance.PageHeaderSortOderTitle = "[" + extraInfo.DetailDataValueName + "順]"; // ADD 2008/10/16

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = SalesTransListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            instance.PageHeaderSubtitle = string.Format("{0}", this._printInfo.prpnm);

            // その他データ
            // Todo:移動元とか渡す？抽出条件渡るからいいか？
            instance.OtherDataList = null;

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            string stCode;
            string edCode;

            //------------------------------------------------------------------------------------------------------------
            // 対象年月
            this.EditCondition(ref addConditions, string.Format("対象年月" + ct_RangeConst,
                                                                    this._salesTransListCndtn.St_ThisYearMonth.ToString("yyyy/MM"),
                                                                    this._salesTransListCndtn.Ed_ThisYearMonth.ToString("yyyy/MM")));

            // 集計方法
            //this.EditCondition( ref addConditions, string.Format( "集計方法：{0}", this._salesTransListCndtn.GroupBySectionDivName ) ); // DEL 2008/10/16
            this.EditCondition(ref addConditions, string.Format("集計方法：{0}", this._salesTransListCndtn.TtlTypeName)); // ADD 2008/10/16

            // 出荷数指定
            //this.EditCondition( ref addConditions, string.Format( "出荷数指定" + ct_RangeConst,
            //                                                        this._salesTransListCndtn.St_ShipmentCnt,
            //                                                        this._salesTransListCndtn.Ed_ShipmentCnt ) ); // DEL 2008/10/16

            // DEL 2008/10/31 不具合対応[7298] ---------->>>>>
            // --- ADD 2008/10/16 -------------------------------->>>>>
            //if (this._salesTransListCndtn.St_ShipmentCnt != 0 || this._salesTransListCndtn.Ed_ShipmentCnt != 999999999)
            //{
            //    stCode = ct_Extr_Top;
            //    edCode = ct_Extr_End;

            //    if (this._salesTransListCndtn.St_ShipmentCnt != 0)
            //    {
            //        stCode = this._salesTransListCndtn.St_ShipmentCnt.ToString("000000000");
            //    }

            //    if (this._salesTransListCndtn.Ed_ShipmentCnt != 999999999)
            //    {
            //        edCode = this._salesTransListCndtn.Ed_ShipmentCnt.ToString("000000000");
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("出荷数指定" + ct_RangeConst, stCode, edCode));
            //}
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // DEL 2008/10/31 不具合対応[7298] ----------<<<<<
            // --- DEL 2009/02/10 -------------------------------->>>>>
            //// ADD 2008/10/31 不具合対応[7298] ---------->>>>>
            //this.EditCondition( ref addConditions, string.Format( "出荷数指定" + ct_RangeConst,
            //                                                        this._salesTransListCndtn.St_ShipmentCnt,
            //                                                        this._salesTransListCndtn.Ed_ShipmentCnt));
            //// ADD 2008/10/31 不具合対応[7298] ----------<<<<<
            // --- DEL 2009/02/10 --------------------------------<<<<<
            // --- ADD 2009/02/10 -------------------------------->>>>>
            if (!this._salesTransListCndtn.St_ShipmentCntNoInputFlg || !this._salesTransListCndtn.Ed_ShipmentCntNoInputFlg)
            {
                stCode = ct_Extr_Top;
                edCode = ct_Extr_End;

                if (!this._salesTransListCndtn.St_ShipmentCntNoInputFlg)
                {
                    stCode = this._salesTransListCndtn.St_ShipmentCnt.ToString();
                }

                if (!this._salesTransListCndtn.Ed_ShipmentCntNoInputFlg)
                {
                    edCode = this._salesTransListCndtn.Ed_ShipmentCnt.ToString();
                }

                this.EditCondition(ref addConditions,
                    string.Format("出荷数指定" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2009/02/10 --------------------------------<<<<<
            // 印刷タイプ
            this.EditCondition(ref addConditions, string.Format("印刷タイプ：{0}",
                                                                    this._salesTransListCndtn.PrintTypeDivName));

            // 金額単位
            this.EditCondition(ref addConditions, string.Format("金額単位：{0}",
                                                                    this._salesTransListCndtn.PriceUnitDivName));

            // 在庫取寄指定
            //this.EditCondition( ref addConditions, string.Format( "在庫取寄指定：{0}",
            //                                                        this._salesTransListCndtn.StockOrderDivName ) ); // DEL 2008/10/16
            this.EditCondition(ref addConditions, string.Format("在取指定：{0}",
                                                                    this._salesTransListCndtn.StockOrderDivName)); // ADD 2008/10/16

            // --- ADD 2008/10/16 -------------------------------->>>>>
            // メーカー別印刷
            this.EditCondition(ref addConditions, string.Format("メーカー別印刷：{0}",
                                                                    this._salesTransListCndtn.MakerPrintDivName));

            // 改頁
            if (this._salesTransListCndtn.NewPageDiv != SalesTransListCndtn.NewPageDivState.None)
            {
                this.EditCondition(ref addConditions, string.Format("改頁：{0}",
                                                                this._salesTransListCndtn.NewPageDivName));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods)
            {
                // 明細単位が「品番」時
                if (this._salesTransListCndtn.Detail == 0)
                {
                    // 品番表示区分
                    this.EditCondition(ref addConditions, string.Format("品番集計区分：{0}",
                                                                            this._salesTransListCndtn.GoodsNoTtlDivName));
                    // 品番表示区分が「合算」時
                    if (this._salesTransListCndtn.GoodsNoTtlDiv == SalesTransListCndtn.GoodsNoTtlDivState.Together)
                    {
                        // 品番選択区分
                        this.EditCondition(ref addConditions, string.Format("品番表示区分：{0}",
                                                                                this._salesTransListCndtn.GoodsNoShowDivName));
                    }
                }
            }
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

            //------------------------------------------------------------------------------------------------------------
            // 得意先
            if ((this._salesTransListCndtn.St_CustomerCode != 0) ||
                (this._salesTransListCndtn.Ed_CustomerCode != 99999999))
            {
                stCode = this._salesTransListCndtn.St_CustomerCode.ToString("00000000");
                edCode = this._salesTransListCndtn.Ed_CustomerCode.ToString("00000000");
                if (this._salesTransListCndtn.St_CustomerCode == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_CustomerCode == 99999999) edCode = ct_Extr_End;  // DEL 2008/10/30 不具合対応[7203]
                if (this._salesTransListCndtn.Ed_CustomerCode == 99999999 &&
                    this._salesTransListCndtn.Set_CustomerCode == false) edCode = ct_Extr_End;      // ADD 2008/10/30 不具合対応[7203]

                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_CustomerCode)
            {
                stCode = this._salesTransListCndtn.St_CustomerCode.ToString("00000000");
                edCode = this._salesTransListCndtn.Ed_CustomerCode.ToString("00000000");
                if (this._salesTransListCndtn.St_CustomerCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ----------<<<<<
            // ----ADD 2009/04/15 ----------------------------------------->>>>>
            // 仕入先
            if ((this._salesTransListCndtn.St_SupplierCode != 0) ||
               (this._salesTransListCndtn.Ed_SupplierCode != 999999))
            {
                stCode = this._salesTransListCndtn.St_SupplierCode.ToString("000000");
                edCode = this._salesTransListCndtn.Ed_SupplierCode.ToString("000000");
                if (this._salesTransListCndtn.St_SupplierCode == 0) stCode = ct_Extr_Top;
                if (this._salesTransListCndtn.Ed_SupplierCode == 999999 &&
                    this._salesTransListCndtn.Set_SupplierCode == false) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("仕入先" + ct_RangeConst, stCode, edCode));
            }
            else if (this._salesTransListCndtn.Set_SupplierCode)
            {
                stCode = this._salesTransListCndtn.St_SupplierCode.ToString("000000");
                edCode = this._salesTransListCndtn.Ed_SupplierCode.ToString("000000");
                if (this._salesTransListCndtn.St_SupplierCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("仕入先" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2009/04/15 -------------------------------------------<<<<<
            // 担当者
            //if ( ( this._salesTransListCndtn.St_EmployeeCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() != string.Empty ) )
            //if ((this._salesTransListCndtn.St_EmployeeCode.TrimEnd() != "0000") ||
            ////(this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() != "9999")) // DEL 2008/12/16
            if (!string.IsNullOrEmpty(this._salesTransListCndtn.St_EmployeeCode)
                || !string.IsNullOrEmpty(this._salesTransListCndtn.Ed_EmployeeCode)) // ADD 2008/12/16
            {
                stCode = this._salesTransListCndtn.St_EmployeeCode.TrimEnd().PadLeft(4, '0');
                edCode = this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd().PadLeft(4, '0');
                if (string.IsNullOrEmpty(this._salesTransListCndtn.St_EmployeeCode)) stCode = ct_Extr_Top; // ADD 2008/12/16
                //if (this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() == "9999") edCode = ct_Extr_End;    // DEL 2008/10/30 不具合対応[7203]
                //if (this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() == "9999" &&
                //    this._salesTransListCndtn.Set_EmployeeCode == false) edCode = ct_Extr_End;    // ADD 2008/10/30 不具合対応[7203] // DEL 2008/12/16
                if (string.IsNullOrEmpty(this._salesTransListCndtn.Ed_EmployeeCode)) edCode = ct_Extr_End; // ADD 2008/12/16

                this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stCode, edCode));
            }
            // --- DEL 2008/12/09 -------------------------------->>>>>
            //// ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            //else if (this._salesTransListCndtn.Set_EmployeeCode)
            //{
            //    stCode = this._salesTransListCndtn.St_EmployeeCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd();
            //    if (this._salesTransListCndtn.St_EmployeeCode.TrimEnd() == "0000") stCode = ct_Extr_Top;
            //    if (this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() == "0000") edCode = ct_Extr_End;

            //    this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stCode, edCode));
            //}
            //// ADD 2008/10/30 不具合対応[7203] ----------<<<<<
            // --- DEL 2008/12/09 --------------------------------<<<<<

            // メーカー
            if ((this._salesTransListCndtn.St_GoodsMakerCd != 0) ||
                (this._salesTransListCndtn.Ed_GoodsMakerCd != 9999))
            {
                stCode = this._salesTransListCndtn.St_GoodsMakerCd.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMakerCd.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_GoodsMakerCd == 9999) edCode = ct_Extr_End;  // DEL 2008/10/30 不具合対応[7203]
                if (this._salesTransListCndtn.Ed_GoodsMakerCd == 9999 &&
                    this._salesTransListCndtn.Set_GoodsMakerCd == false) edCode = ct_Extr_End;  // ADD 2008/10/30 不具合対応[7203]

                this.EditCondition(ref addConditions, string.Format("メーカー" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_GoodsMakerCd)
            {
                stCode = this._salesTransListCndtn.St_GoodsMakerCd.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMakerCd.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("メーカー" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ----------<<<<<

            // --- DEL 2008/10/16 -------------------------------->>>>>
            // 商品区分グループ
            //if ( ( this._salesTransListCndtn.St_LargeGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_LargeGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesTransListCndtn.St_LargeGoodsGanreCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_LargeGoodsGanreCode.TrimEnd();
            //    if ( this._salesTransListCndtn.St_LargeGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_LargeGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "商品区分グループ" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // 商品大分類
            if ((this._salesTransListCndtn.St_GoodsLGroup != 0) ||
                (this._salesTransListCndtn.Ed_GoodsLGroup != 9999))
            {
                stCode = this._salesTransListCndtn.St_GoodsLGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsLGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsLGroup == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_GoodsLGroup == 9999) edCode = ct_Extr_End; // DEL 2008/10/30 不具合対応[7203]
                if (this._salesTransListCndtn.Ed_GoodsLGroup == 9999 &&
                    this._salesTransListCndtn.Set_GoodsLGroup == false) edCode = ct_Extr_End; // ADD 2008/10/30 不具合対応[7203]

                this.EditCondition(ref addConditions, string.Format("商品大分類" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_GoodsLGroup)
            {
                stCode = this._salesTransListCndtn.St_GoodsLGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsLGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsLGroup == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("商品大分類" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ----------<<<<<



            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// 商品区分
            //if ( ( this._salesTransListCndtn.St_MediumGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_MediumGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesTransListCndtn.St_MediumGoodsGanreCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_MediumGoodsGanreCode.TrimEnd();
            //    if ( this._salesTransListCndtn.St_MediumGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_MediumGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "商品区分" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 -------------------------------->>>>>
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // 商品中分類
            if ((this._salesTransListCndtn.St_GoodsMGroup != 0) ||
                (this._salesTransListCndtn.Ed_GoodsMGroup != 9999))
            {
                stCode = this._salesTransListCndtn.St_GoodsMGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMGroup == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_GoodsMGroup == 9999) edCode = ct_Extr_End; // DEL 2008/10/30 不具合対応[7203]
                if (this._salesTransListCndtn.Ed_GoodsMGroup == 9999 &&
                    this._salesTransListCndtn.Set_GoodsMGroup == false) edCode = ct_Extr_End; // ADD 2008/10/30 不具合対応[7203]

                this.EditCondition(ref addConditions, string.Format("商品中分類" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_GoodsMGroup)
            {
                stCode = this._salesTransListCndtn.St_GoodsMGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMGroup == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("商品中分類" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ----------<<<<<

            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// 商品区分詳細
            //if ( ( this._salesTransListCndtn.St_DetailGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_DetailGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesTransListCndtn.St_DetailGoodsGanreCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_DetailGoodsGanreCode.TrimEnd();
            //    if ( this._salesTransListCndtn.St_DetailGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_DetailGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "商品区分詳細" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // グループコード
            if ((this._salesTransListCndtn.St_BLGroupCode != 0) ||
                (this._salesTransListCndtn.Ed_BLGroupCode != 99999))
            {
                stCode = this._salesTransListCndtn.St_BLGroupCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGroupCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGroupCode == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_BLGroupCode == 99999) edCode = ct_Extr_End;    // DEL 2008/10/30 不具合対応[7203]
                if (this._salesTransListCndtn.Ed_BLGroupCode == 99999 &&
                    this._salesTransListCndtn.Set_BLGloupCode == false) edCode = ct_Extr_End;    // ADD 2008/10/30 不具合対応[7203]

                this.EditCondition(ref addConditions, string.Format("グループコード" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_BLGloupCode)
            {
                stCode = this._salesTransListCndtn.St_BLGroupCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGroupCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGroupCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("グループコード" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ----------<<<<<

            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// 自社分類コード
            //if ( (this._salesTransListCndtn.St_EnterpriseGanreCode != 0) ||
            //    (this._salesTransListCndtn.Ed_EnterpriseGanreCode != 9999) )
            //{
            //    stCode = this._salesTransListCndtn.St_EnterpriseGanreCode.ToString();
            //    edCode = this._salesTransListCndtn.Ed_EnterpriseGanreCode.ToString();
            //    if ( this._salesTransListCndtn.St_EnterpriseGanreCode == 0 ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_EnterpriseGanreCode == 9999 ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "自社分類コード" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<

            // ＢＬ商品コード
            if ((this._salesTransListCndtn.St_BLGoodsCode != 0) ||
                (this._salesTransListCndtn.Ed_BLGoodsCode != 99999))
            {
                stCode = this._salesTransListCndtn.St_BLGoodsCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGoodsCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGoodsCode == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_BLGoodsCode == 99999) edCode = ct_Extr_End;  // DEL 2008/10/30 不具合対応[7203]
                if (this._salesTransListCndtn.Ed_BLGoodsCode == 99999 &&
                    this._salesTransListCndtn.Set_BLGoodsCode == false) edCode = ct_Extr_End;  // ADD 2008/10/30 不具合対応[7203]

                this.EditCondition(ref addConditions, string.Format("ＢＬコード" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_BLGoodsCode)
            {
                stCode = this._salesTransListCndtn.St_BLGoodsCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGoodsCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGoodsCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("ＢＬコード" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 不具合対応[7203] ----------<<<<<

            // 商品番号
            if ((this._salesTransListCndtn.St_GoodsNo.TrimEnd() != string.Empty) ||
                (this._salesTransListCndtn.Ed_GoodsNo.TrimEnd() != string.Empty))
            {
                stCode = this._salesTransListCndtn.St_GoodsNo.TrimEnd();
                edCode = this._salesTransListCndtn.Ed_GoodsNo.TrimEnd();
                if (this._salesTransListCndtn.St_GoodsNo.TrimEnd() == string.Empty) stCode = ct_Extr_Top;
                if (this._salesTransListCndtn.Ed_GoodsNo.TrimEnd() == string.Empty) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("品番" + ct_RangeConst, stCode, edCode));
            }

            // 追加
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region ◎ 抽出範囲文字列作成
        /// <summary>
        /// 抽出範囲文字列作成
        /// </summary>
        /// <returns>作成文字列</returns>
        /// <remarks>
        /// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
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
                result = String.Format(title + ct_RangeConst, start, end);
            }
            return result;
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
