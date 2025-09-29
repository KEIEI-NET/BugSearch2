//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/21  修正内容 : PCCUOEで発注した場合、PCC全体設定の売上伝票発行区分を参照することではなく、
//　　　　　　　　　　　　　　　　　PCCUOEでは、BLﾊﾟｰﾂｵｰﾀﾞｰ全体設定の売上伝票印刷区分を参照する。
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 陳艶丹
// 作 成 日  2022/05/26  修正内容 : PMKOBETSU-4208 電子帳簿対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller.Other
{
    using EstimateDefSetServer  = SingletonInstance<EstimateDefSetAgent>;   // 見積初期値設定マスタ
    using SalesTtlStServer      = SingletonInstance<SalesTtlStAgent>;       // 売上全体設定マスタ
    using AcptAnOdrTtlStServer  = SingletonInstance<AcptAnOdrTtlStAgent>;   // 受発注管理全体設定マスタ
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ 
    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>> 
    using System.IO;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Broadleaf.Application.Common;
    using Broadleaf.Drawing.Printing;
    using System.Text;
    using System.Windows.Forms;
    using Broadleaf.Library.Windows.Forms;
    using Broadleaf.Application.Resources;
    using System.Threading;
    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
    /// <summary>
    /// 伝票印刷クラス
    /// </summary>
    /// <remarks>
    /// 移植元：MAHNB01012AA.cs SalesSlipInputAcs.PrintSlip(bool) 2359行目<br/>
    /// 本クラスは自動回答処理でのみ使用されるため、売伝初期データはSCM全体設定マスタを用います。
    /// </remarks>
    public sealed class SlipPrinter
    {
        private const string MY_NAME = "SlipPrinter";   // ログ用

        #region 伝票印刷情報データ

        /// <summary>
        /// 伝票印刷情報データ構造体
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.SlipPrintInfoValue 1019行目より移植
        /// </remarks>
        public struct SlipPrintInfoValue
        {
            int _acptAnOdrStatus;
            string _salesSlipNum;

            /// <summary>
            /// 伝票印刷情報データ構造体コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus"></param>
            /// <param name="salesSlipNum"></param>
            internal SlipPrintInfoValue(int acptAnOdrStatus, string salesSlipNum)
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
            }

            /// <summary>受注ステータスプロパティ</summary>
            internal int AcptAnOdrStatus
            {
                get { return this._acptAnOdrStatus; }
                set { this._acptAnOdrStatus = value; }
            }

            /// <summary>伝票番号プロパティ</summary>
            internal string SalesSlipNum
            {
                get { return this._salesSlipNum; }
                set { this._salesSlipNum = value; }
            }
        }

        #endregion // 伝票印刷情報データ

        /// <summary>保存前の売上伝票番号</summary>
        private const string SALES_SLIP_NUM_BEFORE_SAVE = "000000000";

        #region 企業コード

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;
        /// <summary>企業コードを取得します。</summary>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion // 企業コード

        #region <拠点コード>

        /// <summary>拠点コード</summary>
        private readonly string _sectionCode;
        /// <summary>拠点コードを取得します。</summary>
        private string SectionCode { get { return _sectionCode; } }

        #endregion // </拠点コード>

        #region <売伝初期データ>

        /// <summary>
        /// 現在のSCM全体設定を取得します。
        /// </summary>
        /// <value>該当する設定が存在しない場合、<c>null</c>を返します。</value>
        private SCMTtlSt CurrentSCMTotalSetting
        {
            get
            {
                SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                    EnterpriseCode,
                    SectionCode
                );
                if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                return foundTotalSetting;
            }
        }

        /// <summary>
        /// 印刷できるか判断します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <returns>
        /// <c>true</c> :印刷できます。<br/>
        /// <c>false</c>:印刷できません。
        /// </returns>
        private bool CanPrint(SalesSlipInputAcs.AcptAnOdrStatusState acptAnOdrStatus)
        {
            if (CurrentSCMTotalSetting == null) return false;

            const int CAN_PRINT = 1;    // 0:しない／1:する

            switch (acptAnOdrStatus)
            {
                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:       // 見積
                    return !CurrentSCMTotalSetting.EstimatePrtDiv.Equals(CAN_PRINT);    // 見積書発行区分は0/1が逆

                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:          // 売上
                    // zhouzy update 20110927 begin
                    //return CurrentSCMTotalSetting.SalesSlipPrtDiv.Equals(CAN_PRINT);
                    return true;
                    // zhouzy update 20110927 end
                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:  // 受注
                    return CurrentSCMTotalSetting.AcpOdrrSlipPrtDiv.Equals(CAN_PRINT);

                default:
                    return false;
            }
        }

        #region <参考>

        ///// <summary>
        ///// 見積初期値設定を取得します。
        ///// </summary>
        ///// <returns>見積初期値設定</returns>
        //private EstimateDefSet GetEstimateDefSet()
        //{
        //    return EstimateDefSetServer.Singleton.Instance.Find(EnterpriseCode, SectionCode) ?? new EstimateDefSet();
        //}

        ///// <summary>
        ///// 売上全体設定を取得します。
        ///// </summary>
        ///// <returns>売上全体設定</returns>
        //private SalesTtlSt GetSalesTtlSt()
        //{
        //    return SalesTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode);
        //}

        ///// <summary>
        ///// 受発注管理全体設定を取得します。
        ///// </summary>
        ///// <returns>受発注管理全体設定</returns>
        //private AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        //{
        //    return AcptAnOdrTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode) ?? new AcptAnOdrTtlSt();
        //}

        #endregion // </参考>

        #endregion // </売伝初期データ>

        #region 売上伝票印刷キー情報

        /// <summary>売上伝票印刷キー情報(key:伝票番号 value:受注ステータス,保存前伝票番号)</summary>
        private readonly Dictionary<string, SlipPrintInfoValue> _printSalesKeyInfo;
        //----- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応------->>>>>
        private const string CT_PORTNAME = "\\{0}_{1}_{2}_{3}.pdf";
        private const string CT_LOCALPORT = ",XcvMonitor Local Port";
        private const string CT_ZERO = "\0";
        private const string CT_ADDPORT = "AddPort";
        private const string CT_DELETEPORT = "DeletePort";
        private const string METHOD_NAME_PORT1 = "PrinterPortNameChange";
        private const string METHOD_NAME_PORT2 = "PrinterPortNameRecovery";
        private const string CT_PRINTER = "Microsoft Print to PDF";
        private const string CT_DEFALUT_PORTNAME = "PORTPROMPT:";
        private const string CT_XMLEBOOKSFILEFOLDERXMLINFO = "MAKAU03000U_EBooksLinkSetting.XML";
        private const string CT_EBOOKSFOLDER = "\\eBooks\\eBooks";
        private const string CT_CUSTOMERFOLDER = "\\eBooks\\Customer";
        private const string CT_TEMPFOLDER = "\\Temp\\SCMAutoEBooks";
        private const string CT_RENAMEOLDER = "\\Rename";
        private const string CT_LOGFOLDER = "\\Log\\eBooks";
        private const string CT_LOGFILENM = "\\{0}_SCMAutoEBooks_{1}.txt";
        private const string CT_FOLDERSPLIT = "\\";
        private const string CT_STRSPLIT = "\"";
        private const string CT_EBOOKSFLPATH = "\\nN2_{0}_{1}.csv";
        private const string CT_CUSTOMERFLPATH = "\\nN7_CustomerRF_Diff_{0}.csv";
        private const string CT_DATETIMEFOMART = "yyyyMMddHHmmss";
        private const string CT_YMDFOMART = "yyyyMMdd";
        private const string CT_LOGDATETIMEFOMART = "yyyy/MM/dd HH:mm:ss";
        private const string CT_LOGCOUNT = "{0}件";
        private const string CT_OPLOGMSG = "{0}件を同期　Log：{1}";
        private const string PGNAME_STR = "BLP自動回答";
        private const string ASSID_PMSCM01010U = "PMSCM01010U";
        private const string PGID_VIRTUALPRINTER = "VirtualPrinterController.exe";
        private const string CT_NAME_SALE = "売上";
        private const string CT_NAME_ESTIMATE = "見積";
        private const string CT_NAME_EBOOK = "Partsman_DenchoDX_VirtualPrinterMutex";
        private const string CT_MODE_SALE = "1";
        private const int OPERATIONCODE_EBOOKS = 0;
        private const int STATUS_NORMAL= 0;
        private const int COMMAND_THREE = 3;
        private const int COMMAND_ZERO = 0;
        private const int LEVEL_TWO = 2;
        private const int LEVEL_ZERO = 0;
        private const int CBBUF_ZERO = 0;
        private const int DESIREDACCESS_ONE = 1;
        private const int CT_INT_TWO = 2;
        private const int CT_INT_ZERO = 0;
        private const int CT_MUTEX_WAIT_MAX = 360; // 仮想プリンタ出力排他獲得最大待ち時間（6分）
        private const string CT_CUSTOMERCDFOMART = "00000000";
        private const string CT_SPLITSTR = "_";
        private const char CT_SPLITCHAR = '_';
        private const double RATE10 = 0.1;
        private const double RATE8 = 0.08;
        // 電帳出力設定XMLファイル
        private const string XML_PDFOUTPUTSETTINGS = "MAHNB01001U_PDFOutputSettings.xml";
        private const string PRINTER_NORMAL = "Microsoft Print to PDF";
        private const string PRINTER_CUBE = "CubePDF";
        //今回の電子帳簿対応ではダイアログ表示を使用しない
        private const string XML_PDFPRINTERSETTINGENABLE = "MAHNB01001U_PDFPrinterSettingEnable.xml";
        private const string MESS_PRINTERPORT_ERR = "PDFプリンタポートの設定に失敗しました({0})";
        private const string MESS_PRINTERMUTEX_ERR = "PDFプリンタへの出力に失敗しました（排他取得エラー）";
        // 禁止文字
        private char[] badChars = new char[] { '\\', '/', ':', '*', '?', '\"', '<', '>', '|', '_' };
        // ファイル保存ダイアログ表示
        private bool _fileDialogDisplay = false;
        // ポート名
        private string _portName = string.Empty;
        // 売上データ
        private Dictionary<string, SalesSlipWork> _svSalesSlipWorkDic = new Dictionary<string, SalesSlipWork>();
        // 売上明細データ
        private Dictionary<string, ArrayList> _svSalesDetailWorkDic = new Dictionary<string, ArrayList>();
        // 電子帳簿連携オプション
        private int _opt_PM_EBooks;
        /// <summary>
        /// 電子帳簿出力フラグ
        /// </summary>
        public static int PDFPrintStatus = 0;
        /// <summary>
        /// 電子帳簿出力フラグ
        /// </summary>
        public int PDFPrinterStatus_EXT
        {
            get { return PDFPrintStatus; }
        }
        /// <summary>
        /// 伝票PDF出力
        /// </summary>
        private enum OutputMode : int
        {
            /// <summary>しない</summary>
            PDFPrintUnable = 0,
            /// <summary>する</summary>
            PDFPrintEnable = 1,
            /// <summary>電子帳簿出力に従う</summary>
            PDFPrintCustom = 2,
        }
        /// <summary>
        /// 得意先電子帳簿出力
        /// </summary>
        private enum DmOutCode : int
        {
            /// <summary>する</summary>
            YES = 0,
            /// <summary>しない</summary>
            NO = 1,
        }
        /// <summary>
        /// 電子帳簿出力
        /// </summary>
        private enum PDFPrint : int
        {
            /// <summary>通常印刷</summary>
            Usually = 0,
            /// <summary>電子帳簿出力</summary>
            EBook = 1,
        }
        /// <summary>出力伝票区分 0:両方選択なし/1:売上/2:見積/3:両方選択あり </summary>
        private enum outPutSlipTypeEnum : int
        {
            No = 0,                 // 0:両方選択なし
            Sales = 1,              // 売上
            Estimate = 2,           // 見積
            All = 3,                // 両方選択あり
        }

        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        /// <summary>
        /// 電子帳簿連携オプション
        /// </summary>
        public int Opt_PM_EBooks
        {
            get { return this._opt_PM_EBooks; }
            set { this._opt_PM_EBooks = value; }
        }
        //----- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応-------<<<<<
        /// <summary>売上伝票印刷キー情報(key:伝票番号 value:受注ステータス,保存前伝票番号)を取得します。</summary>
        private Dictionary<string, SlipPrintInfoValue> PrintSalesKeyInfo { get { return _printSalesKeyInfo; } }

        #endregion // 売上伝票印刷キー情報

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.SaveDBData() 2007行目より移植
        /// </remarks>
        /// <param name="salesDataList">売伝リモートのパラメータ(書込み結果：統合リスト)</param>
        public SlipPrinter(ArrayList salesDataList)
        {
            _printSalesKeyInfo = new Dictionary<string, SlipPrintInfoValue>();

            if (salesDataList.Count.Equals(0)) return;
            // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            #region ●電子帳簿連携オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PM_EBooks = (int)Option.ON;
            }
            else
            {
                this._opt_PM_EBooks = (int)Option.OFF;
            }
            #endregion
            this._svSalesSlipWorkDic = new Dictionary<string, SalesSlipWork>();
            this._svSalesDetailWorkDic = new Dictionary<string, ArrayList>();
            // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
            //------------------------------------------------------
            // 売上データ取得
            //------------------------------------------------------
            CustomSerializeArrayList list = null;
            for (int i = 0; i < salesDataList.Count; i++)
            {
                list = salesDataList[i] as CustomSerializeArrayList;
                if (list == null) continue;
                string prtOutputKey = string.Empty;// ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応
                foreach (object obj in list)
                {
                    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
                    if (obj is ArrayList && ((ArrayList)obj).Count > 0)
                    {
                        ArrayList al = (ArrayList)obj;
                        if (al[0].GetType() == typeof(SalesDetailWork))
                        {
                            prtOutputKey = ((SalesDetailWork)al[0]).SalesSlipNum + ((SalesDetailWork)al[0]).AcptAnOdrStatus.ToString();
                            if (!this._svSalesDetailWorkDic.ContainsKey(prtOutputKey) && ((SalesDetailWork)al[0]).AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                            {
                                _svSalesDetailWorkDic.Add(prtOutputKey, al);
                            }                           
                        }
                        continue;
                    }
                    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
                    SalesSlipWork salesSlipWork = obj as SalesSlipWork;
                    if (salesSlipWork == null) continue;

                    _enterpriseCode = salesSlipWork.EnterpriseCode;
                    _sectionCode    = salesSlipWork.SectionCode;

                    SlipPrintInfoValue slipPrintInfoValue = new SlipPrintInfoValue(
                        salesSlipWork.AcptAnOdrStatus,
                        SALES_SLIP_NUM_BEFORE_SAVE
                    );
                    if (CanPrint((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus))
                    {
                        _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                        // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
                        if (!this._svSalesSlipWorkDic.ContainsKey(prtOutputKey) && salesSlipWork.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                        {
                            prtOutputKey = salesSlipWork.SalesSlipNum + salesSlipWork.AcptAnOdrStatus.ToString();
                            this._svSalesSlipWorkDic.Add(prtOutputKey, salesSlipWork);
                        }
                        // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
                    }
                    continue;

                    #region <参考>

                    //switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus)
                    //{
                    //    case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:       // 見積
                    //    //case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                    //        if (GetEstimateDefSet().EstimatePrtDiv == 0)
                    //        {
                    //            _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //        }
                    //        break;
                    //    case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:          // 売上
                    //        if (GetSalesTtlSt().SalesSlipPrtDiv == 0)
                    //        {
                    //            _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //        }
                    //        break;
                    //    //case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                    //    //    if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().ShipmSlipPrtDiv == 0) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //    //    break;
                    //    case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:  // 受注
                    //        if (GetAcptAnOdrTtlSt().AcpOdrrSlipPrtDiv == 1)
                    //        {
                    //            _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //        }
                    //        break;
                    //    default:
                    //        break;
                    //}   // switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus)

                    #endregion // </参考>
                }   // foreach (object obj in list)
            }   // for (int i = 0; i < salesDataList.Count; i++)
        }

        #endregion // </Constructor>

        /// <summary>
        /// 伝票印刷スレッド
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.PrintSlipThread() 12441行目より移植
        /// </remarks>
        public void PrintSlipThread()
        {
            PrintSlip(true);
        }

        /// <summary>
        /// 伝票印刷処理
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.PrintSlip(bool) 2359行目より移植
        /// </remarks>
        private void PrintSlip(bool printWithoutDialog)
        {
        #if DEBUG
            const string METHOD_NAME = "PrintSlip(bool)";   // ログ用
        #else
            const string METHOD_NAME = "PrintSlip(bool) @Thread";   // ログ用
        #endif

            #region ●初期処理
            DCCMN02000UA printDisp = new DCCMN02000UA(SectionCode); // 伝票印刷情報設定画面インスタンス生成
            {
                printDisp.IsService = 1;    // サービス起動対応
                // ADD 2011/08/12
                printDisp.IsAutoAns = 1;    // PCCUOE 自動回答起動対応
            }
            SalesSlipPrintCndtn.SalesSlipKey key = new SalesSlipPrintCndtn.SalesSlipKey(); // 伝票印刷用Keyインスタンス生成
            List<SalesSlipPrintCndtn.SalesSlipKey> keyList = new List<SalesSlipPrintCndtn.SalesSlipKey>(); // 伝票印刷用KeyListインスタンス生成
            bool reissueDiv = false;
            #endregion

            #region ●売上伝票Key情報セット
            foreach (string salesSlipNum in PrintSalesKeyInfo.Keys)
            {
                SlipPrintInfoValue slipPrintInfoValue = PrintSalesKeyInfo[salesSlipNum];
                //if (slipPrintInfoValue.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                //{
                key = new SalesSlipPrintCndtn.SalesSlipKey();
                key.AcptAnOdrStatus = slipPrintInfoValue.AcptAnOdrStatus;
                key.SalesSlipNum = salesSlipNum;
                keyList.Add(key);
                //}
                if (slipPrintInfoValue.SalesSlipNum != OtherAppComponent.ctDefaultSalesSlipNum) reissueDiv = true;
            }
            //PrintSalesKeyInfo.Clear();
            #endregion

            #region ●印刷情報パラメータセット
            SalesSlipPrintCndtn salesSlipPrintCndtn = new SalesSlipPrintCndtn();
            salesSlipPrintCndtn.EnterpriseCode = EnterpriseCode;
            salesSlipPrintCndtn.SalesSlipKeyList = keyList;
            salesSlipPrintCndtn.ReissueDiv = reissueDiv;
            // zhouzy 20110921 add begin
            ////PCC全体設定で、売上伝票発行区分は「1：する」の場合
            //if (CurrentSCMTotalSetting.SalesSlipPrtDiv.Equals(1))
            //{
            //    //印刷する
            //    salesSlipPrintCndtn.NomalSalesSlipPrintFlag = 0;
            //}
            //else
            //{
            //    //印刷しない
            //    salesSlipPrintCndtn.NomalSalesSlipPrintFlag = 1;
            //}
            salesSlipPrintCndtn.SCMTotalSettingSalesSlipPrtDiv = CurrentSCMTotalSetting.SalesSlipPrtDiv;
            salesSlipPrintCndtn.ScmFlg = true;
            // zhouzy 20110921 add end
            #endregion

            #region ●印刷処理

            #region <Log>

            string msg = string.Format(
                "DCCMN02000UA.IsService={0}, salesSlipPrintCndtn.SalesSlipKeyList.Count={1}",
                printDisp.IsService,
                salesSlipPrintCndtn.SalesSlipKeyList.Count
            );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            try
            {
                if (salesSlipPrintCndtn.SalesSlipKeyList.Count != 0)
                {
                    PDFPrintStatus = (int)PDFPrint.Usually;//ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応
                    printDisp.ShowDialog(salesSlipPrintCndtn, printWithoutDialog);
                    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>> 
                    //電帳.DXオプション有効の場合のみ
                    if (this._opt_PM_EBooks == (int)Option.ON)
                    {   
                        //電子帳簿出力
                        EbooksOutput(keyList, printWithoutDialog); 
                    }
                    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<< 

                }
            }
            catch (InvalidOperationException ex)
            {
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetExceptionMsg(
                    "DCCMN02000UA.ShowDialog()で例外が発生しました。",
                    ex,
                    true
                ));

                #endregion // </Log>
            }

            #endregion
        }
        // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        #region DllImport
        [StructLayout(LayoutKind.Sequential)]
        private class PRINTER_DEFAULTS
        {
            public string pDatatype;
            public IntPtr pDevMode;
            public int DesiredAccess;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public Int32 Attributes;
            public Int32 Priority;
            public Int32 DefaultPriority;
            public Int32 StartTime;
            public Int32 UntilTime;
            public Int32 Status;
            public Int32 cJobs;
            public Int32 AveragePPM;
        }
        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool GetPrinter(IntPtr hPrinter,
            int dwLevel, IntPtr pPrinter, int cbBuf, out int pcbNeeded);
        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr
        pPrinter, int Command);
        [DllImport("winspool.drv", EntryPoint = "XcvDataW", SetLastError = true)]
        private static extern bool XcvData(
            IntPtr hXcv,
            [MarshalAs(UnmanagedType.LPWStr)] string pszDataName,
            IntPtr pInputData,
            uint cbInputData,
            IntPtr pOutputData,
            uint cbOutputData,
            out uint pcbOutputNeeded,
            out uint pwdStatus);
        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        private static extern int OpenPrinter(
            string pPrinterName,
            ref IntPtr phPrinter,
            PRINTER_DEFAULTS pDefault);
        #endregion DllImport

        /// <summary>
        /// 電子帳簿出力
        /// </summary>
        /// <param name="keyList">伝票Key情報リスト</param>
        /// <param name="printWithoutDialog">ダイアログ表示なしフラグ</param> 
        /// <remarks>
        /// <br>Note        : 電子帳簿出力を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void EbooksOutput(List<SalesSlipPrintCndtn.SalesSlipKey> keyList, bool printWithoutDialog)
        {
            //電子帳簿連携サポート設定XMLファイル取得(MAHNB01001U_PDFOutputSettings.xml)
            eBooksOutputSetting eBookSetting = GetEBooksSettings();
            if (eBookSetting == null) return;

            //ＰＤＦダイアログ表示ファイルを取得
            GetFileDialogDisplay();

            //電子帳簿出力データ取得
            List<SalesSlipPrintCndtn.SalesSlipKey> printList;
            CustomerInfo customerInfo = new CustomerInfo();
            GetEbooksOutputData(eBookSetting, keyList, out printList, ref customerInfo);
            if (printList.Count == 0) return;

            //排他対象
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, CT_NAME_EBOOK);
            //電子帳簿出力制御(売上伝票入力/得意先電子元帳/BLP自動回答を排他)
            int count = 0;
            while (!mutex.WaitOne(0, false))
            {
                if (count++ >= CT_MUTEX_WAIT_MAX)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        "",
                        MESS_PRINTERMUTEX_ERR,
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                        form.TopMost = false;
                        return;
                }
                Thread.Sleep(1000);
            }

            try
            {
                // 電子帳簿出力フラグ:1(電子帳簿出力する)
                PDFPrintStatus = (int)PDFPrint.EBook;

                #region 電子帳簿出力
                #region tempフォルダ初期化
                // 電帳処理の場合、tempフォルダ初期化
                if (!Directory.Exists(System.Environment.CurrentDirectory + CT_TEMPFOLDER))
                {
                    Directory.CreateDirectory(System.Environment.CurrentDirectory + CT_TEMPFOLDER);
                }
                else
                {
                    foreach (string strFile in Directory.GetFiles(System.Environment.CurrentDirectory + CT_TEMPFOLDER))
                    {
                        File.Delete(strFile);
                    }
                }

                // ファイル保存ダイアログが表示しない時、作業フォルダ\Renameを初期化
                if (!this._fileDialogDisplay)
                {
                    string folderName = System.Environment.CurrentDirectory + CT_TEMPFOLDER + CT_RENAMEOLDER;
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    else
                    {
                        foreach (string strFile in Directory.GetFiles(folderName))
                        {
                            File.Delete(strFile);
                        }
                    }
                }
                #endregion

                #region PDFファイル生成
                // 伝票印刷情報設定画面インスタンス生成
                DCCMN02000UA printDisp = new DCCMN02000UA(SectionCode); // 伝票印刷情報設定画面インスタンス生成
                {
                    printDisp.IsService = 1;    // サービス起動対応
                    // ADD 2011/08/12
                    printDisp.IsAutoAns = 1;    // PCCUOE 自動回答起動対応
                }
                //再発行区分
                bool reissueDiv = false;
                //印刷リストを1つずつ下記の処理を行う
                foreach (SalesSlipPrintCndtn.SalesSlipKey slipKey in printList)
                {
                    if (slipKey.SalesSlipNum != OtherAppComponent.ctDefaultSalesSlipNum) reissueDiv = true;
                    _portName = string.Empty;
                    Process WindowController = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    //PDF出力監視の起動情報
                    startInfo.FileName = System.Environment.CurrentDirectory + CT_FOLDERSPLIT + PGID_VIRTUALPRINTER;
                    {
                        // パス
                        string filePath = CT_STRSPLIT + System.Environment.CurrentDirectory + CT_TEMPFOLDER + CT_STRSPLIT;
                        // 得意先コード
                        string customerCd = customerInfo.CustomerCode.ToString(CT_CUSTOMERCDFOMART);
                        // 得意先名
                        string cuntomerNm = CT_STRSPLIT + BadCharRemove(customerInfo.CustomerSnm.Trim()) + CT_STRSPLIT;
                        // 伝票区分
                        string acptAnOdrStatusNm = string.Empty;
                        if (slipKey.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales)
                        {
                            acptAnOdrStatusNm = CT_NAME_SALE;
                        }
                        else
                        {
                            acptAnOdrStatusNm = CT_NAME_ESTIMATE;
                        }
                        // 伝票番号
                        string salesSlipNo = slipKey.SalesSlipNum;
                        // 待機時間
                        string waitTime = eBookSetting.PDFPrinterWait.ToString();
                        // 起動元
                        string startFrom = CT_MODE_SALE; //仮想プリンタダイアログ制御に対して、売上伝票入力から呼ばれていることにする

                        startInfo.Arguments = filePath + " " + customerCd + " "
                                            + cuntomerNm + " " + acptAnOdrStatusNm + " " + salesSlipNo + " "
                                            + waitTime + " " + startFrom;
                        WindowController.StartInfo = startInfo;
                        //ファイル保存ダイアログが表示しない時、仮想プリンタのポート名を生成
                        if (!this._fileDialogDisplay)
                        {
                            // PDFファイル名「<得意先コード>_<得意先略称>_<伝票区分名>_<伝票番号>_<出力日時>.pdf」
                            _portName = string.Format(CT_PORTNAME, customerCd, BadCharRemove(customerInfo.CustomerSnm.Trim()), acptAnOdrStatusNm, salesSlipNo);
                        }
                        // PDF出力監視処理起動
                        WindowController.Start();
                    }
                    try
                    {
                        //ファイル保存ダイアログが表示しない時、仮想プリンタのポート名を変更
                        if (!this._fileDialogDisplay) PrinterPortNameChange();

                        List<SalesSlipPrintCndtn.SalesSlipKey> subKeysList = new List<SalesSlipPrintCndtn.SalesSlipKey>();
                        subKeysList.Add(slipKey);
                        SalesSlipPrintCndtn salesSlipPrintCndtn = new SalesSlipPrintCndtn();
                        salesSlipPrintCndtn.EnterpriseCode = EnterpriseCode;
                        salesSlipPrintCndtn.SalesSlipKeyList = subKeysList;
                        salesSlipPrintCndtn.ReissueDiv = reissueDiv;
                        salesSlipPrintCndtn.SCMTotalSettingSalesSlipPrtDiv = CurrentSCMTotalSetting.SalesSlipPrtDiv;
                        salesSlipPrintCndtn.ScmFlg = true;
                        salesSlipPrintCndtn.RemoteSalesSlipPrintFlag = 1;// リモート伝票発行しない
                        // 伝票印刷実行
                        printDisp.ShowDialog(salesSlipPrintCndtn, printWithoutDialog);

                        // PDF出力監視処理終了後、続け
                        WindowController.WaitForExit();
                    }
                    finally
                    {
                        //ファイル保存ダイアログが表示しない時、仮想プリンタのポート元に戻す
                        if (!this._fileDialogDisplay) PrinterPortNameRecovery();
                    }
                }
                #endregion PDFファイル生成

                //電子帳簿受け渡し用フォルダ取得
                EBooksLinkSetInfo eBooksFileFolderXmlInfo = GetEBooksFileFolderXmlInfo();
                // インデックスファイル
                List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList;
                MakeIndexFile(printList, eBooksFileFolderXmlInfo, out denchoDXIndexCSVEntityList);

                //取引先リスト作成
                DenchoDXCustomerExportAcs denchoDXCustomerExportAcs = new DenchoDXCustomerExportAcs();
                denchoDXCustomerExportAcs.MakeCustomerCSVDifference(EnterpriseCode, eBooksFileFolderXmlInfo.CustomFolder + string.Format(CT_CUSTOMERFLPATH, DateTime.Now.ToString(CT_DATETIMEFOMART)));

                //ログ出力
                OutEBooksLog(DateTime.Now, denchoDXIndexCSVEntityList);
                #endregion 電子帳簿出力
            }
            finally
            {
                // 電子帳簿出力フラグ:0(通常納品書出力)
                PDFPrintStatus = (int)PDFPrint.Usually;
                //ミューテックスを解放する
                mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// 電子帳簿ログ出力
        /// </summary>
        /// <param name="stDateTime">システム時間</param>
        /// <param name="denchoDXIndexCSVEntityList">インデックスcsvファイルリスト</param>
        /// <remarks>
        /// <br>Note        : 電子帳簿ログ出力を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void OutEBooksLog(DateTime stDateTime, List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList)
        {
            System.IO.StreamWriter writer = null;
            try
            {
                // 端末番号取得
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                int cashRegisterNo;
                posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, LoginInfoAcquisition.EnterpriseCode);

                string path = System.Environment.CurrentDirectory + CT_LOGFOLDER;
                // フォルダ作成
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                string logPath = System.Environment.CurrentDirectory + CT_LOGFOLDER + string.Format(CT_LOGFILENM, DateTime.Now.ToString(CT_YMDFOMART), cashRegisterNo.ToString());
                writer = new System.IO.StreamWriter(logPath, true, System.Text.Encoding.Default);

                // 出力日時
                writer.Write(stDateTime.ToString(CT_LOGDATETIMEFOMART));
                writer.Write(Environment.NewLine);

                // 件数
                writer.Write(string.Format(CT_LOGCOUNT, denchoDXIndexCSVEntityList.Count.ToString()));
                writer.Write(Environment.NewLine);

                // ファイル名
                foreach (DenchoDXIndexCSVEntity work in denchoDXIndexCSVEntityList)
                {
                    writer.Write(work.Filename);
                    writer.Write(Environment.NewLine);
                }

                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                string opLogMsg = string.Format(CT_OPLOGMSG, denchoDXIndexCSVEntityList.Count.ToString(), logPath);
                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_PMSCM01010U, PGNAME_STR, string.Empty, OPERATIONCODE_EBOOKS, 0, opLogMsg, string.Empty);
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// 電子帳簿受け渡し用フォルダ取得
        /// </summary>
        /// <remarks>
        /// <br>Note        : 電子帳簿受け渡し用フォルダ取得処理を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private EBooksLinkSetInfo GetEBooksFileFolderXmlInfo()
        {
            EBooksLinkSetInfo eBooksFileFolderXmlInfo = new EBooksLinkSetInfo();
            try
            {
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XMLEBOOKSFILEFOLDERXMLINFO)))
                {
                    // XMLからチェック区分を取得する
                    eBooksFileFolderXmlInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XMLEBOOKSFILEFOLDERXMLINFO));
                }
                else
                {
                    // デフォルトフォルダ
                    eBooksFileFolderXmlInfo.EBooksFolder = System.Environment.CurrentDirectory + CT_EBOOKSFOLDER;
                    eBooksFileFolderXmlInfo.CustomFolder = System.Environment.CurrentDirectory + CT_CUSTOMERFOLDER;
                }
            }
            catch
            {
                // デフォルトフォルダ
                eBooksFileFolderXmlInfo.EBooksFolder = System.Environment.CurrentDirectory + CT_EBOOKSFOLDER;
                eBooksFileFolderXmlInfo.CustomFolder = System.Environment.CurrentDirectory + CT_CUSTOMERFOLDER;
            }
            finally
            {
                // フォルダ作成
                if (!Directory.Exists(eBooksFileFolderXmlInfo.EBooksFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(eBooksFileFolderXmlInfo.EBooksFolder);
                }
                if (!Directory.Exists(eBooksFileFolderXmlInfo.CustomFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(eBooksFileFolderXmlInfo.CustomFolder);
                }
            }
            return eBooksFileFolderXmlInfo;
        }

        /// <summary>
        /// 電子帳簿出力データ取得
        /// </summary>
        /// <param name="eBookSetting">電子帳簿連携サポート設定XMLファイル</param>
        /// <param name="keyList">伝票リスト</param>
        /// <param name="printList">電子帳簿出力データ</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <remarks>
        /// <br>Note        : 電子帳簿出力データ取得処理を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void GetEbooksOutputData(eBooksOutputSetting eBookSetting, List<SalesSlipPrintCndtn.SalesSlipKey> keyList, out List<SalesSlipPrintCndtn.SalesSlipKey> printList, ref CustomerInfo customerInfo)
        {
            printList = new List<SalesSlipPrintCndtn.SalesSlipKey>();
            int customerCode = 0;
            //先頭伝票情報の得意先情報を取得
            if (keyList.Count >0)
            {
                SalesSlipPrintCndtn.SalesSlipKey key = (SalesSlipPrintCndtn.SalesSlipKey)keyList[0];
                // 売上データ
                string dicKey = key.SalesSlipNum + key.AcptAnOdrStatus.ToString();
                if (_svSalesSlipWorkDic.ContainsKey(dicKey)) customerCode = ((SalesSlipWork)_svSalesSlipWorkDic[dicKey]).CustomerCode;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                customerInfoAcs.ReadDBData(EnterpriseCode, customerCode, out customerInfo);
                if (customerInfo == null) return;

            }

            //伝票PDF出力 0:しない／1:する／2:電子帳簿出力に従う
            if (eBookSetting.OutputMode == (int)OutputMode.PDFPrintEnable ||
                ((eBookSetting.OutputMode == (int)OutputMode.PDFPrintCustom) && (customerInfo.DmOutCode == (int)DmOutCode.YES)))
            {
                //出力伝票区分 0:両方選択なし/1:売上/2:見積/3:両方選択あり
                foreach (SalesSlipPrintCndtn.SalesSlipKey slipKey in keyList)
                {
                    if ((slipKey.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales
                        && (eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.Sales || eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.All)) ||
                       (slipKey.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate
                        && (eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.Estimate || eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.All)))
                    {
                        //電子帳簿出力対象とする
                        printList.Add(slipKey);
                    }
                }
 
            }
        }

        /// <summary>
        /// インデックスファイル作成
        /// </summary>
        /// <param name="denchoDXIndexCSVEntityList">インデックスcsvファイルリスト</param>
        /// <param name="eBooksFileFolderXmlInfo">XMLファイル</param>
        /// <param name="keyList">伝票リスト</param>
        /// <remarks>
        /// <br>Note        : インデックスファイル作成処理を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void MakeIndexFile(List<SalesSlipPrintCndtn.SalesSlipKey> keyList, EBooksLinkSetInfo eBooksFileFolderXmlInfo, out List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList)
        {

            denchoDXIndexCSVEntityList = new List<DenchoDXIndexCSVEntity>();
            try
            {
                //ファイル名リスト
                Dictionary<string, ArrayList> pdfFileNmList = new Dictionary<string, ArrayList>();

                // PDF受け渡し
                //ファイルコピー
                DirectoryInfo dir;
                if (this._fileDialogDisplay)
                {
                    // 作業フォルダから取得
                    dir = new DirectoryInfo(System.Environment.CurrentDirectory + CT_TEMPFOLDER);
                }
                else
                {
                    // 作業フォルダ\Renameから取得
                    dir = new DirectoryInfo(System.Environment.CurrentDirectory + CT_TEMPFOLDER + CT_RENAMEOLDER);
                }
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        continue;
                    }
                    else
                    {
                        string[] subFlNm = i.FullName.Split(CT_SPLITCHAR);
                        if (pdfFileNmList.ContainsKey(subFlNm[3]))
                        {
                            pdfFileNmList[subFlNm[3]].Add(i.Name);
                        }
                        else
                        {
                            ArrayList al = new ArrayList();
                            al.Add(i.Name);
                            pdfFileNmList.Add(subFlNm[3], al);
                        }
                    }
                }
                if (pdfFileNmList.Count == 0) return;
                foreach (SalesSlipPrintCndtn.SalesSlipKey key in keyList)
                {
                    // 売上データ
                    string dicKey = key.SalesSlipNum + key.AcptAnOdrStatus.ToString();
                    SalesSlipWork salesSlipWork = new SalesSlipWork();
                    ArrayList salesDetailWorkList = new ArrayList();
                    if (_svSalesSlipWorkDic.ContainsKey(dicKey)) salesSlipWork = _svSalesSlipWorkDic[dicKey];
                    if (_svSalesDetailWorkDic.ContainsKey(dicKey)) salesDetailWorkList = _svSalesDetailWorkDic[dicKey];

                    // インデックスファイル作成用エンティティ
                    DenchoDXIndexCSVEntity denchoDXIndexCSVEntity = new DenchoDXIndexCSVEntity();

                    //システム区分
                    denchoDXIndexCSVEntity.Mcd = DenchoDXIndexCSVEntity.EMcdType.PMNS;
                    //取引先コード(自社)	
                    denchoDXIndexCSVEntity.Blcustomercd = LoginInfoAcquisition.EnterpriseCode;

                    //書類分類	
                    if (key.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales)
                    {
                        //納品書
                        denchoDXIndexCSVEntity.Doctype = DenchoDXIndexCSVEntity.EDocType.DeliverySlip;
                    }
                    else
                    {
                        //見積書
                        denchoDXIndexCSVEntity.Doctype = DenchoDXIndexCSVEntity.EDocType.Quotation;
                    }
                    //取引先コード	
                    denchoDXIndexCSVEntity.Customercd = salesSlipWork.CustomerCode.ToString(CT_CUSTOMERCDFOMART);
                    //取引先名称	
                    denchoDXIndexCSVEntity.Customername = BadCharRemove(salesSlipWork.CustomerSnm.Trim());
                    //書類番号	
                    denchoDXIndexCSVEntity.Docnumber = key.SalesSlipNum;
                    //得意先の転嫁方式：請求先/請求子の時
                    if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandParentLay ||
                        salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandChildLay)
                    {
                        //取引金額合計(税抜き)	
                        denchoDXIndexCSVEntity.Price_tax_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                        //取引金額合計(税込み)	
                        denchoDXIndexCSVEntity.Price_tax_included = (decimal)salesSlipWork.SalesTotalTaxExc;
                        //消費税金額合計	
                        denchoDXIndexCSVEntity.Total_tax = 0;
                    }
                    else
                    {
                        //取引金額合計(税込み)	
                        denchoDXIndexCSVEntity.Price_tax_included = (decimal)salesSlipWork.SalesTotalTaxInc;
                        //取引金額合計(税抜き)	
                        denchoDXIndexCSVEntity.Price_tax_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                        //消費税金額合計	
                        denchoDXIndexCSVEntity.Total_tax = (decimal)(salesSlipWork.SalesTotalTaxInc - salesSlipWork.SalesTotalTaxExc);
                    }
                    // 備考
                    denchoDXIndexCSVEntity.Memo = salesSlipWork.SlipNote;
                    // 登録番号(発行者)
                    denchoDXIndexCSVEntity.Aojcorporatenumber = string.Empty;
                    // 発行者名称
                    denchoDXIndexCSVEntity.Companyname = GetCompanyName();
                    // 発行拠点コード
                    denchoDXIndexCSVEntity.Sectioncd = Convert.ToUInt64(salesSlipWork.ResultsAddUpSecCd);
                    // 発行拠点名称
                    denchoDXIndexCSVEntity.Sectionname = GetSectionNm(salesSlipWork.ResultsAddUpSecCd.Trim());
                    //通貨単位
                    denchoDXIndexCSVEntity.Currencyunit = DenchoDXIndexCSVEntity.ECurrencyUnitType.JPY;

                    // 税率分金額取得
                    decimal price_taxrate1_excluded = decimal.Zero;
                    decimal price_taxrate1_included = decimal.Zero;
                    decimal tax1 = decimal.Zero;
                    decimal price_taxrate2_excluded = decimal.Zero;
                    decimal price_taxrate2_included = decimal.Zero;
                    decimal tax2 = decimal.Zero;
                    decimal price_taxrate3_excluded = decimal.Zero;
                    decimal price_taxrate3_included = decimal.Zero;
                    decimal tax3 = decimal.Zero;
                    GetPriceByRate(salesSlipWork, salesDetailWorkList,
                        out price_taxrate1_excluded, out price_taxrate1_included, out tax1,
                        out price_taxrate2_excluded, out price_taxrate2_included, out tax2,
                        out price_taxrate3_excluded, out price_taxrate3_included, out tax3);

                    // 税率(1)	
                    denchoDXIndexCSVEntity.Taxrate1 = 100;
                    // 税率(1)対象金額合計(税抜き)
                    denchoDXIndexCSVEntity.Price_taxrate1_excluded = price_taxrate1_excluded;
                    // 税率(1)対象金額合計(税込み)
                    denchoDXIndexCSVEntity.Price_taxrate1_included = price_taxrate1_included;
                    // 税額(1)
                    denchoDXIndexCSVEntity.Tax1 = tax1;
                    // 税率(2)	
                    denchoDXIndexCSVEntity.Taxrate2 = 80;
                    // 税率(2)対象金額合計(税抜き)
                    denchoDXIndexCSVEntity.Price_taxrate2_excluded = price_taxrate2_excluded;
                    // 税率(2)対象金額合計(税込み)
                    denchoDXIndexCSVEntity.Price_taxrate2_included = price_taxrate2_included;
                    // 税額(2)
                    denchoDXIndexCSVEntity.Tax2 = tax2;
                    // 税率(3)	
                    denchoDXIndexCSVEntity.Taxrate3 = 0;
                    // 税率(3)対象金額合計(税抜き)
                    denchoDXIndexCSVEntity.Price_taxrate3_excluded = price_taxrate3_excluded;
                    // 税率(3)対象金額合計(税込み)
                    denchoDXIndexCSVEntity.Price_taxrate3_included = price_taxrate3_included;
                    // 税額(3)
                    denchoDXIndexCSVEntity.Tax3 = tax3;
                    if (pdfFileNmList.Count > 0)
                    {
                        ArrayList al = pdfFileNmList[key.SalesSlipNum];
                        if (al.Count == 1)
                        {
                            //同一伝票が1件PDF生成のみ
                            //ファイル名	 
                            denchoDXIndexCSVEntity.Filename = (string)al[0];
                            //取引年月日
                            int idx = ((string)al[0]).LastIndexOf(CT_SPLITSTR);
                            string dateStr = ((string)al[0]).Substring(idx + 1, 14);
                            DateTime dateTime = DateTime.ParseExact(dateStr, CT_DATETIMEFOMART, System.Globalization.CultureInfo.CurrentCulture);
                            denchoDXIndexCSVEntity.Transactiondate = dateTime;
                            //取引時間	
                            denchoDXIndexCSVEntity.Transactiontime = dateTime;
                            denchoDXIndexCSVEntityList.Add(denchoDXIndexCSVEntity);
                        }
                        else
                        {
                            //同一伝票が複数件PDF生成
                            foreach (string fileName in al)
                            {
                                DenchoDXIndexCSVEntity csvEntity = DenchoDXIndexCSVEntityClone(denchoDXIndexCSVEntity);
                                //ファイル名
                                csvEntity.Filename = fileName;
                                //取引年月日
                                int idx = fileName.LastIndexOf(CT_SPLITSTR);
                                string dateStr = fileName.Substring(idx + 1, 14);
                                DateTime dateTime = DateTime.ParseExact(dateStr, CT_DATETIMEFOMART, System.Globalization.CultureInfo.CurrentCulture);
                                csvEntity.Transactiondate = dateTime;
                                //取引時間	
                                csvEntity.Transactiontime = dateTime;
                                denchoDXIndexCSVEntityList.Add(csvEntity);
                            }
                        }
                    }
                }

                DenchoDXIndexCSV denchoDXIndexCSV = new DenchoDXIndexCSV(denchoDXIndexCSVEntityList);
                string pathCSV = dir + string.Format(CT_EBOOKSFLPATH, LoginInfoAcquisition.EnterpriseCode, DateTime.Now.ToString(CT_DATETIMEFOMART));
                denchoDXIndexCSV.MakeIndexCSV(pathCSV);

                //ファイルコピー
                fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        continue;
                    }
                    else
                    {
                        File.Copy(i.FullName, eBooksFileFolderXmlInfo.EBooksFolder + CT_FOLDERSPLIT + i.Name);
                    }
                }
            }
            catch
            {
                //既存処理影響なし
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称取得を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks> 
        private string GetSectionNm(string sectionCode)
        {
            string sectionNm = string.Empty;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            if (secInfoAcs.SecInfoSetList != null)
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim())
                    {
                        // 拠点名取得
                        sectionNm = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            return sectionNm;
        }

        /// <summary>
        /// 自社名取得
        /// </summary>
        /// <returns>自社名</returns>
        /// <remarks>
        /// <br>Note        : 自社名取得を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private string GetCompanyName()
        {
            string companyName = string.Empty;
            CompanyInf companyInf;
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out companyInf, EnterpriseCode);
            if (companyInf != null) companyName = companyInf.CompanyName1.Trim();
            return companyName;
        }

        /// <summary>
        /// Clone処理
        /// </summary>
        /// <param name="denchoDXIndexCSVEntity">インデックスcsvファイル</param>
        /// <remarks>
        /// <br>Note        : Clone処理を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private DenchoDXIndexCSVEntity DenchoDXIndexCSVEntityClone(DenchoDXIndexCSVEntity denchoDXIndexCSVEntity)
        {
            DenchoDXIndexCSVEntity csvEntity = new DenchoDXIndexCSVEntity();
            //システム区分
            csvEntity.Mcd = denchoDXIndexCSVEntity.Mcd;
            //取引先コード(自社)	
            csvEntity.Blcustomercd = denchoDXIndexCSVEntity.Blcustomercd;
            //ファイル名	
            csvEntity.Filename = denchoDXIndexCSVEntity.Filename;
            //書類分類	
            csvEntity.Doctype = denchoDXIndexCSVEntity.Doctype;
            //取引先コード	
            csvEntity.Customercd = denchoDXIndexCSVEntity.Customercd;
            //取引先名称	
            csvEntity.Customername = denchoDXIndexCSVEntity.Customername;
            //書類番号	
            csvEntity.Docnumber = denchoDXIndexCSVEntity.Docnumber;
            //取引年月日	
            csvEntity.Transactiondate = denchoDXIndexCSVEntity.Transactiondate;
            //取引時間
            csvEntity.Transactiontime = denchoDXIndexCSVEntity.Transactiontime;
            //取引金額合計(税込み)	
            csvEntity.Price_tax_included = denchoDXIndexCSVEntity.Price_tax_included;
            //取引金額合計(税抜き)	
            csvEntity.Price_tax_excluded = denchoDXIndexCSVEntity.Price_tax_excluded;
            //消費税金額合計	
            csvEntity.Total_tax = denchoDXIndexCSVEntity.Total_tax;
            // 備考
            csvEntity.Memo = denchoDXIndexCSVEntity.Memo;
            // 登録番号(発行者)
            csvEntity.Aojcorporatenumber = denchoDXIndexCSVEntity.Aojcorporatenumber;
            // 発行者名称
            csvEntity.Companyname = denchoDXIndexCSVEntity.Companyname;
            // 発行拠点コード
            csvEntity.Sectioncd = denchoDXIndexCSVEntity.Sectioncd;
            // 発行拠点名称
            csvEntity.Sectionname = denchoDXIndexCSVEntity.Sectionname;
            //通貨単位
            csvEntity.Currencyunit = denchoDXIndexCSVEntity.Currencyunit;
            // 税率(1)	
            csvEntity.Taxrate1 = denchoDXIndexCSVEntity.Taxrate1;
            // 税率(1)対象金額合計(税抜き)
            csvEntity.Price_taxrate1_excluded = denchoDXIndexCSVEntity.Price_taxrate1_excluded;
            // 税率(1)対象金額合計(税込み)
            csvEntity.Price_taxrate1_included = denchoDXIndexCSVEntity.Price_taxrate1_included;
            // 税額(1)
            csvEntity.Tax1 = denchoDXIndexCSVEntity.Tax1;
            // 税率(2)	
            csvEntity.Taxrate2 = denchoDXIndexCSVEntity.Taxrate2;
            // 税率(2)対象金額合計(税抜き)
            csvEntity.Price_taxrate2_excluded = denchoDXIndexCSVEntity.Price_taxrate2_excluded;
            // 税率(2)対象金額合計(税込み)
            csvEntity.Price_taxrate2_included = denchoDXIndexCSVEntity.Price_taxrate2_included;
            // 税額(2)
            csvEntity.Tax2 = denchoDXIndexCSVEntity.Tax2;
            // 税率(3)	
            csvEntity.Taxrate3 = denchoDXIndexCSVEntity.Taxrate3;
            // 税率(3)対象金額合計(税抜き)
            csvEntity.Price_taxrate3_excluded = denchoDXIndexCSVEntity.Price_taxrate3_excluded;
            // 税率(3)対象金額合計(税込み)
            csvEntity.Price_taxrate3_included = denchoDXIndexCSVEntity.Price_taxrate3_included;
            // 税額(3)
            csvEntity.Tax3 = denchoDXIndexCSVEntity.Tax3;
            return csvEntity;

        }

        /// <summary>
        /// 税率１～税率３の金額を算出
        /// </summary>
        /// <param name="salesDetailWorkList">売上明細データリスト</param>
        /// <param name="salesSlipWork">売上伝票データリスト</param>
        /// <param name="price_taxrate1_excluded">税率(1)対象金額合計(税抜き)</param>
        /// <param name="price_taxrate1_included">税率(1)対象金額合計(税込み)</param>
        /// <param name="tax1">税額(1)</param>
        /// <param name="price_taxrate2_excluded">税率(2)対象金額合計(税抜き)</param>
        /// <param name="price_taxrate2_included">税率(2)対象金額合計(税込み)</param>
        /// <param name="tax2">税額(2)</param>
        /// <param name="price_taxrate3_excluded">税率(3)対象金額合計(税抜き)</param>
        /// <param name="price_taxrate3_included">税率(3)対象金額合計(税込み)</param>
        /// <param name="tax3">税額(3)</param>
        /// <remarks>
        /// <br>Note        : 税率１～税率３の金額を算出する</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void GetPriceByRate(SalesSlipWork salesSlipWork, ArrayList salesDetailWorkList,
                        out decimal price_taxrate1_excluded, out decimal price_taxrate1_included, out decimal tax1,
                        out decimal price_taxrate2_excluded, out decimal price_taxrate2_included, out decimal tax2,
                        out decimal price_taxrate3_excluded, out decimal price_taxrate3_included, out decimal tax3)
        {
            // 初期化
            price_taxrate1_excluded = decimal.Zero;
            price_taxrate1_included = decimal.Zero;
            tax1 = 0;
            price_taxrate2_excluded = decimal.Zero;
            price_taxrate2_included = decimal.Zero;
            tax2 = 0;
            price_taxrate3_excluded = decimal.Zero;
            price_taxrate3_included = decimal.Zero;
            tax3 = 0;

            // 非課税の場合
            if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                price_taxrate3_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                price_taxrate3_included = (decimal)salesSlipWork.SalesTotalTaxInc;
            }
            else
            {
                decimal price_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                decimal price_included = (decimal)salesSlipWork.SalesTotalTaxInc;
                decimal tax = (decimal)salesSlipWork.SalesSubtotalTax;
                decimal price_taxNone = decimal.Zero;
                foreach (SalesDetailWork detailWork in salesDetailWorkList)
                {
                    if (detailWork.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        // 非課税金額算出
                        price_taxNone = price_taxNone + detailWork.SalesMoneyTaxExc;
                    }
                }
                if (salesSlipWork.ConsTaxRate == RATE10)
                {
                    //得意先の転嫁方式：請求先/請求子の時
                    if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandParentLay ||
                        salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandChildLay)
                    {
                        price_taxrate1_excluded = price_excluded - price_taxNone;
                        price_taxrate1_included = price_taxrate1_excluded;
                        tax1 = 0;
                    }
                    else
                    {
                        price_taxrate1_excluded = price_excluded - price_taxNone;
                        price_taxrate1_included = price_included - price_taxNone;
                        tax1 = tax;
                    }

                }
                if (salesSlipWork.ConsTaxRate == RATE8)
                {
                    //得意先の転嫁方式：請求先/請求子の時
                    if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandParentLay ||
                        salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandChildLay)
                    {
                        price_taxrate2_excluded = price_excluded - price_taxNone;
                        price_taxrate2_included = price_taxrate2_excluded;
                        tax2 = 0;
                    }
                    else
                    {
                        price_taxrate2_excluded = price_excluded - price_taxNone;
                        price_taxrate2_included = price_included - price_taxNone;
                        tax2 = tax;
                    }
                }
                price_taxrate3_excluded = price_taxNone;
                price_taxrate3_included = price_taxNone;
            }
        }

        /// <summary>
        /// 禁止文字を削除する(「\」「/」「:」「*」「?」「"」「>」「|」「_」)
        /// </summary>
        /// <param name="customNm">得意先名</param>
        /// <returns>置換後の得意先名</returns>
        /// <remarks>
        /// <br>Note         : 禁止文字を削除する</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private string BadCharRemove(string customNm)
        {
            StringBuilder claimSnmStr = new StringBuilder();
            string[] result = customNm.Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in result)
            {
                claimSnmStr.Append(str);
            }
            return claimSnmStr.ToString();
        }

        /// <summary>
        /// 仮想プリンタのポート変更
        /// </summary>
        /// <remarks>
        /// <br>Note         : 仮想プリンタのポート変更</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private void PrinterPortNameChange()
        {
            // ポート名
            string portName = string.Empty;
            IntPtr hPrinter = IntPtr.Zero;
            IntPtr pPrinterInfo = IntPtr.Zero;
            PRINTER_DEFAULTS def;
            PRINTER_INFO_2 pi;
            try
            {
                // ポート名
                portName = System.Environment.CurrentDirectory + CT_TEMPFOLDER + _portName;
                //ローカルポートのデータ型、環境、初期化データ、およびアクセス権を指定
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = DESIREDACCESS_ONE;

                //ローカルポートのハンドルを取得する
                int n = OpenPrinter(CT_LOCALPORT, ref hPrinter, def);
                if (n == STATUS_NORMAL) return;

                if (!portName.EndsWith(CT_ZERO)) portName += CT_ZERO;
                uint size = (uint)(portName.Length * CT_INT_TWO);
                pPrinterInfo = Marshal.AllocHGlobal((int)size);
                Marshal.Copy(portName.ToCharArray(), CT_INT_ZERO, pPrinterInfo, portName.Length);

                uint needed;
                uint xcvResult;
                // ローカルポートを追加
                bool result = XcvData(hPrinter, CT_ADDPORT, pPrinterInfo, size, IntPtr.Zero, CT_INT_ZERO, out needed, out xcvResult);
                if (!result) return;
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);

                pi = new PRINTER_INFO_2();
                hPrinter = IntPtr.Zero;
                pPrinterInfo = IntPtr.Zero;
                int needed2;
                int temp;

                //プリンターのデータ型、環境、初期化データ、およびアクセス権を指定
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = 0xf000C;// PRINTER_ALL_ACCESS


                //仮想プリンタのハンドルを取得する
                n = OpenPrinter(CT_PRINTER, ref hPrinter, def);
                if (n == STATUS_NORMAL) return;
                //バッファに必要なバイト数を取得する
                GetPrinter(hPrinter, LEVEL_TWO, IntPtr.Zero, CBBUF_ZERO, out needed2);
                //メモリを割り当てる
                pPrinterInfo = Marshal.AllocHGlobal(needed2);
                //詳細なプリンタ情報を取得
                result = GetPrinter(hPrinter, LEVEL_TWO, (IntPtr)pPrinterInfo, needed2, out temp);
                if (!result) return;
                //PRINTER_INFO_2型にマーシャリングする
                pi = (PRINTER_INFO_2)Marshal.PtrToStructure(pPrinterInfo, typeof(PRINTER_INFO_2));

                //プリンタ設定：ポート名
                pi.pPortName = portName;
                Marshal.StructureToPtr(pi, pPrinterInfo, true);
                //仮想プリンタのポート変更時、ポート変更対象のプリンタのジョブをクリアする
                result = SetPrinter(hPrinter, LEVEL_ZERO, IntPtr.Zero, COMMAND_THREE);
                if (!result) return;
                //プリンタ設定情報を反映
                result = SetPrinter(hPrinter, LEVEL_TWO, pPrinterInfo, COMMAND_ZERO);
                if (!result) return;
            }
            catch(Exception ex)
            {
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME_PORT1, LogHelper.GetExceptionMsg(
                    string.Format(MESS_PRINTERPORT_ERR, 1),
                    ex,
                    true
                ));
                #endregion // </Log>
            }
        }

        /// <summary>
        /// 仮想プリンタのポート元に戻す
        /// </summary>
        /// <remarks>
        /// <br>Note         : 仮想プリンタのポート元に戻す</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private void PrinterPortNameRecovery()
        {
            IntPtr hPrinter = IntPtr.Zero;
            IntPtr pPrinterInfo = IntPtr.Zero;
            PRINTER_INFO_2 pi = new PRINTER_INFO_2();
            PRINTER_DEFAULTS def;
            try
            {
                int needed2;
                int temp;
                //プリンターのデータ型、環境、初期化データ、およびアクセス権を指定
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = 0xf000C;

                //仮想プリンタのハンドルを取得する
                int n = OpenPrinter(CT_PRINTER, ref hPrinter, def);
                if (n == STATUS_NORMAL) return;
                //バッファに必要なバイト数を取得する
                GetPrinter(hPrinter, LEVEL_TWO, IntPtr.Zero, CBBUF_ZERO, out needed2);
                //メモリを割り当てる
                pPrinterInfo = Marshal.AllocHGlobal(needed2);
                //詳細なプリンタ情報を取得
                bool result = GetPrinter(hPrinter, LEVEL_TWO, (IntPtr)pPrinterInfo, needed2, out temp);
                if (!result) return;
                //PRINTER_INFO_2型にマーシャリングする
                pi = (PRINTER_INFO_2)Marshal.PtrToStructure(pPrinterInfo, typeof(PRINTER_INFO_2));

                //プリンタ設定：デフォルトポートに戻す
                pi.pPortName = CT_DEFALUT_PORTNAME;
                Marshal.StructureToPtr(pi, pPrinterInfo, true);
                //プリンタ設定情報を反映
                result = SetPrinter(hPrinter, LEVEL_TWO, pPrinterInfo, COMMAND_ZERO);
                if (!result) return;
                //プリンタを閉じる
                ClosePrinter(hPrinter);
                Marshal.FreeHGlobal(pPrinterInfo);

                // 追加のローカルポート名
                string portName = System.Environment.CurrentDirectory + CT_TEMPFOLDER + _portName;
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = DESIREDACCESS_ONE;
                hPrinter = IntPtr.Zero;
                pPrinterInfo = IntPtr.Zero;

                //追加のローカルポートのハンドルを取得する
                n = OpenPrinter(CT_LOCALPORT, ref hPrinter, def);
                if (n == 0) return;
                if (!portName.EndsWith(CT_ZERO)) portName += CT_ZERO;
                uint size = (uint)(portName.Length * CT_INT_TWO);
                pPrinterInfo = Marshal.AllocHGlobal((int)size);
                Marshal.Copy(portName.ToCharArray(), CT_INT_ZERO, pPrinterInfo, portName.Length);

                uint needed;
                uint xcvResult;
                //追加のローカルポートを削除
                result = XcvData(hPrinter, CT_DELETEPORT, pPrinterInfo, size, IntPtr.Zero, CT_INT_ZERO, out needed, out xcvResult);
                if (!result) return;
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);
            }
            catch (Exception ex)
            {
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME_PORT1, LogHelper.GetExceptionMsg(
                    string.Format(MESS_PRINTERPORT_ERR, 2),
                    ex,
                    true
                ));
                #endregion // </Log>

            }
         // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
        }

        /// <summary>
        /// 電帳設定ファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 電帳設定ファイル取得</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private eBooksOutputSetting GetEBooksSettings()
        {
            eBooksOutputSetting eBooksOutputSetting = null;
            try
            {
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS)))
                {
                    // 電帳設定を取得する
                    eBooksOutputSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS));                   
                }
            }
            catch
            {
                //　既存処理影響なし
            }
            return eBooksOutputSetting;
        }

        /// <summary>
        /// ファイル保存ダイアログ表示を制御 ※今回の電子帳簿対応ではダイアログ表示を使用しない
        /// </summary>
        /// <remarks>
        /// <br>Note         : ファイル保存ダイアログ表示を制御する</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private void GetFileDialogDisplay()
        {
            try
            {
                // ファイル保存ダイアログ表示を制御
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFPRINTERSETTINGENABLE)))
                {
                    this._fileDialogDisplay = true;
                }
                else
                {
                    this._fileDialogDisplay = false;
                }
            }
            catch
            {
                this._fileDialogDisplay = false;
            }
        }
        // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
    }
    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    # region 電子帳簿プリンタ項目設定情報
    /// <summary>
    /// 電子帳簿プリンタ項目設定情報
    /// </summary>
    /// <remarks>
    /// <br>Note       : 電子帳簿プリンタ項目設定情報</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2022/05/26</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class eBooksOutputSetting
    {
        /// <summary>電子帳簿プリンタ項目設定情報</summary>
        public eBooksOutputSetting()
        {

        }

        /// <summary>伝票PDF出力</summary>
        private int _outputMode;
        /// <summary>出力伝票区分</summary>
        private int _outputSlipType;
        /// <summary>PDFプリンタ [Windows標準／その他] </summary>
        private int _pDFPrinter;
        /// <summary>割り当て済みのプリンタ管理番号 </summary>
        private int _pDFPrinterNumber;
        /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
        private int _pDFPrinterWait;

        /// <summary>伝票PDF出力</summary>
        public Int32 OutputMode
        {
            get { return _outputMode; }
            set { _outputMode = value; }
        }

        /// <summary>出力伝票区分</summary>
        public Int32 OutputSlipType
        {
            get { return _outputSlipType; }
            set { _outputSlipType = value; }
        }
        /// <summary>PDFプリンタ [Windows標準／その他] </summary>
        public Int32 PDFPrinter
        {
            get { return _pDFPrinter; }
            set { _pDFPrinter = value; }
        }

        /// <summary>割り当て済みのプリンタ管理番号 </summary>
        public Int32 PDFPrinterNumber
        {
            get { return _pDFPrinterNumber; }
            set { _pDFPrinterNumber = value; }
        }

        /// <summary>仮想プリンタ制御が終了するまでの待機時間</summary>
        public Int32 PDFPrinterWait
        {
            get { return _pDFPrinterWait; }
            set { _pDFPrinterWait = value; }
        }
    }
    # endregion
    // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
}
