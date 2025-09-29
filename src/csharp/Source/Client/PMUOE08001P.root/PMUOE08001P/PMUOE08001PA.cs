using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.Drawing;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 自由帳票(ＵＯＥ伝票)印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 自由帳票の印刷ドキュメントを作成します。</br>
    /// <br>               (売上伝票をベースに作成)</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note  : 劉洋　2009.07.24 オートバックス対応</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/24  22018 鈴木 正臣</br>
    /// <br>             : ＱＲコードの印刷機能を追加。</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/17  22018 鈴木 正臣</br>
    /// <br>             : サブレポート機能の追加。（森川部品個別対応の為）</br>
    /// <br></br>
    /// <br>Update Note  : 2011/05/27  30517 夏野 駿希</br>
    /// <br>             : 中村オートパーツ個別対応</br>
    /// <br>             : 特殊項目の追加（車台番号リテラル(入力時のみ)）</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 李占川     連番985</br>
    /// <br>             　【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
    /// <br></br>
    /// </remarks>
    public class PMUOE08001PA : ISlipPrintProc
    {
        #region PrivateMember
        // --------------------------------------------------------
        // ☆☆☆ 印刷データ系 ☆☆☆
        // --------------------------------------------------------
        // 印刷データ
        private DataSet _ds;
        // 自由帳票印字位置設定マスタ
        private FrePrtPSetWork _frePrtPSet;
        //// 透かし画像
        //private System.Drawing.Image _watermarkImage;

        // --------------------------------------------------------
        // ☆☆☆ 印刷設定データ系 ☆☆☆
        // --------------------------------------------------------
        // 伝票印刷設定マスタ
        private SlipPrtSetWork _slipPrtSet;
        // 伝票印刷設定伝票タイプ別設定
        private EachSlipTypeSet _eachSlipTypeSet;
        // 売上全体設定マスタ
        private SalesTtlStWork _salesTtlSt;
        // 全体初期表示
        private AllDefSetWork _allDefSet;
        // 伝票印刷パラメータ
        private SlipPrintParameter _slipPrintParameter;
        // 伝票印刷条件クラス
        private SlipPrintConditionInfo _slipPrintConditionInfo;
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        // サブレポートディクショナリ
        private Dictionary<string, ar.ActiveReport3> _subReportDic;
        // 自由帳票印字位置設定ディクショナリ
        private Dictionary<string, FrePrtPSetWork> _frePrtPSetDic;
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

        // --------------------------------------------------------
        // ☆☆☆ 印刷ドキュメント ☆☆☆
        // --------------------------------------------------------
        // プレビュードキュメントクラス
        private Document _previewDocument;
        // 印刷ドキュメントクラス
        private Document _printDocument;

        // --------------------------------------------------------
        // 印刷制御
        // --------------------------------------------------------
        private PMCMN02000CA _reportCtrl;

        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMUOE08001PA()
        {
            _previewDocument = new Document();
            _printDocument = new Document();

            _reportCtrl = PMCMN02000CA.GetInstance();
            _reportCtrl.DoubleHeightTargetList = PMUOE08001PB.GetDoubleHeightTargetList();
        }
        #endregion

        #region ISlipPrintProc メンバ
        /// <summary>
        /// 印刷ドキュメント（プレビュー用）
        /// </summary>
        public Document PreviewDocument
        {
            get { return _previewDocument; }
        }

        /// <summary>
        /// 印刷ドキュメント（印刷用）
        /// </summary>
        public Document PrintDocument
        {
            get { return _printDocument; }
        }

        /// <summary>
        /// 印刷用情報取得処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="slipPrintConditionInfo">印刷設定情報オブジェクト</param>
        /// <param name="slipPrintData">印刷内容情報オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷用データを取得します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// <br>Update Note : 2011/08/15 李占川</br>
        /// <br>             【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
        /// </remarks>
        public int SetPrintConditionInfoAndData(object sender, SlipPrintConditionInfo slipPrintConditionInfo, object slipPrintData)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                _slipPrintConditionInfo = slipPrintConditionInfo;

                // 印刷系データ取得
                if (slipPrintData != null)
                {
                    // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                    _frePrtPSetDic = null;
                    Dictionary<string, bool> decryptedFrePrtPSetDic = null;
                    // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                    // 設定系データ取得
                    # region [設定系データ取得]
                    if (slipPrintConditionInfo != null)
                    {
                        ArrayList extrInfoList = (ArrayList)slipPrintConditionInfo.ExtrInfo;

                        foreach (Object wkObj in extrInfoList)
                        {
                            // 伝票印刷設定マスタ
                            if (wkObj is SlipPrtSetWork)
                            {
                                _slipPrtSet = (SlipPrtSetWork)wkObj;
                                _eachSlipTypeSet = new EachSlipTypeSet(_slipPrtSet);
                            }
                            // 自由帳票印字位置設定マスタ
                            else if (wkObj is FrePrtPSetWork)
                            {
                                _frePrtPSet = (FrePrtPSetWork)wkObj;
                            }
                            // 売上全体設定マスタ
                            else if (wkObj is SalesTtlStWork)
                            {
                                _salesTtlSt = (SalesTtlStWork)wkObj;
                            }
                            // 全体初期表示設定マスタ
                            else if (wkObj is AllDefSetWork)
                            {
                                _allDefSet = (AllDefSetWork)wkObj;
                            }
                            // 伝票印刷パラメータ
                            else if (wkObj is Dictionary<string, object>)
                            {
                                _slipPrintParameter = new SlipPrintParameter((Dictionary<string, object>)wkObj);
                            }
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            // 自由帳票印字位置設定ディクショナリ
                            else if ( wkObj is Dictionary<string, FrePrtPSetWork> )
                            {
                                _frePrtPSetDic = (Dictionary<string, FrePrtPSetWork>)wkObj;
                            }
                            // 復号化済み自由帳票印字位置設定ディクショナリ
                            else if ( wkObj is Dictionary<string, bool> )
                            {
                                decryptedFrePrtPSetDic = (Dictionary<string, bool>)wkObj;
                            }
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                        }
                    }

                    if (CheckExistsMasters() == false)
                    {
                        return -1;
                    }
                    # endregion

                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    //// 印刷レイアウト情報取得
                    //Dictionary<string, string> columnVisibleTypeDic;
                    //Dictionary<string, string> titleDic;
                    //GetLayoutInfo(_frePrtPSet, out columnVisibleTypeDic, out titleDic);
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
                    // 印刷レイアウト情報取得
                    Dictionary<string, string> columnVisibleTypeDic = new Dictionary<string, string>();
                    Dictionary<string, string> titleDic = new Dictionary<string, string>();
                    GetLayoutInfo( _frePrtPSet, ref columnVisibleTypeDic, ref titleDic );
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                    // サブレポートディクショナリ更新（keyに合致するReportを取得して格納する）
                    ReflectSubReportDic( ref _subReportDic, _frePrtPSetDic, decryptedFrePrtPSetDic, ref columnVisibleTypeDic, ref titleDic );
                    _reportCtrl.SubReportDic = _subReportDic;
                    _reportCtrl.SubReportTargetList = new List<string>( new string[] { "FREEPRINT.SUBREPORT" } );
                    // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                    // 印刷データ展開
                    _ds = new DataSet();
                    List<ArrayList> slipPrintDataList = (List<ArrayList>)slipPrintData;
                    int index = 0;

                    foreach (ArrayList wkObj in slipPrintDataList)
                    {
                        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                        //// テーブルスキーム生成
                        //DataTable table = PMUOE08001PB.CreateFrePSalesSlipTable(index);

                        //FrePSalesSlipWork slipWork = (FrePSalesSlipWork)( wkObj as ArrayList )[0];
                        //List<FrePSalesDetailWork> detailWorks = (List<FrePSalesDetailWork>)( wkObj as ArrayList )[1];
                        //UoeSales uoeSales = (UoeSales)( wkObj as ArrayList )[2];

                        //// データ展開
                        //PMUOE08001PB.CopyToDataTable(ref table, slipWork, detailWorks, uoeSales, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _salesTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic);

                        //_ds.Tables.Add(table);
                        //index++;

                        List<DataTable> tables = new List<DataTable>();
                        FrePSalesSlipWork slipWork = (FrePSalesSlipWork)(wkObj as ArrayList)[0];
                        List<FrePSalesDetailWork> detailWorks = (List<FrePSalesDetailWork>)(wkObj as ArrayList)[1];
                        UoeSales uoeSales = (UoeSales)(wkObj as ArrayList)[2];

                        // データ展開
                        // --- UPD 李占川 2011/08/15---------->>>>>
                        //PMUOE08001PB.CopyToDataTable( ref tables, ref index, slipWork, detailWorks, uoeSales, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _salesTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic );
                        PMUOE08001PB.CopyToDataTable(ref tables, ref index, slipWork, detailWorks, uoeSales, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _salesTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic, this._subReportDic);
                        // --- UPD 李占川 2011/08/15----------<<<<<
                        
                        _ds.Tables.AddRange( tables.ToArray() );
                        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                string message = "印刷用情報取得処理にて例外が発生しました。"
                    + "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP
                    , ToString()
                    , "自由帳票伝票印刷"
                    , ex.TargetSite.ToString()
                    , TMsgDisp.OPE_PRINT
                    , message
                    , status
                    , null
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
                return -1;
            }

            return status;
        }
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// サブレポートディクショナリ更新処理
        /// </summary>
        /// <param name="subReportDic"></param>
        /// <param name="frePrtPSetDic"></param>
        /// <param name="decryptedFrePrtPSetDic"></param>
        private void ReflectSubReportDic( ref Dictionary<string, ar.ActiveReport3> subReportDic, Dictionary<string, FrePrtPSetWork> frePrtPSetDic, Dictionary<string, bool> decryptedFrePrtPSetDic, ref Dictionary<string, string> columnVisibleTypeDic, ref Dictionary<string, string> titleDic )
        {
            if ( subReportDic == null )
            {
                subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                return;
            }
            if ( frePrtPSetDic == null || decryptedFrePrtPSetDic == null )
            {
                return;
            }

            Dictionary<string, DataDynamics.ActiveReports.ActiveReport3> newDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();

            foreach ( string key in subReportDic.Keys )
            {
                if ( !frePrtPSetDic.ContainsKey( key ) ) continue;
                FrePrtPSetWork pSetWork = frePrtPSetDic[key];

                if ( !decryptedFrePrtPSetDic.ContainsKey( key ) )
                {
                    // まだ復号化していない⇒復号化する
                    FrePrtSettingController.DecryptPrintPosClassData( pSetWork );
                    decryptedFrePrtPSetDic.Add( key, true );
                }

                // レイアウト情報取得処理
                GetLayoutInfo( pSetWork, ref columnVisibleTypeDic, ref titleDic );

                // レポート情報からレイアウト情報を復元する
                using ( MemoryStream stream = new MemoryStream( pSetWork.PrintPosClassData ) )
                {
                    // レイアウト生成
                    ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                    stream.Position = 0;
                    prtRpt.LoadLayout( stream );

                    // スクリプトクリア
                    prtRpt.Script = string.Empty;

                    // ディクショナリに追加
                    newDic.Add( key, prtRpt );
                }
            }

            // ディクショナリを差し替える
            subReportDic = newDic;
        }
        /// <summary>
        /// サブレポートディクショナリ再生成処理
        /// </summary>
        /// <param name="subReportDic"></param>
        /// <param name="frePrtPSetDic"></param>
        private void RenewSubReportDic( ref Dictionary<string, ar.ActiveReport3> subReportDic, Dictionary<string, FrePrtPSetWork> frePrtPSetDic )
        {
            //--------------------------------------------
            // ※ページ切替、複写切替の際にメインのレポートの
            //   インスタンスは作り直しているので、
            //   それに関連付けるサブレポートも
            //   インスタンスを作り直す必要がある。
            //--------------------------------------------

            if ( subReportDic == null )
            {
                subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                return;
            }
            if ( frePrtPSetDic == null )
            {
                return;
            }

            Dictionary<string, ar.ActiveReport3> newDic = new Dictionary<string, ar.ActiveReport3>();

            foreach ( string key in subReportDic.Keys )
            {
                if ( !frePrtPSetDic.ContainsKey( key ) ) continue;
                FrePrtPSetWork pSetWork = frePrtPSetDic[key];

                // レポート情報からレイアウト情報を復元する
                using ( MemoryStream stream = new MemoryStream( pSetWork.PrintPosClassData ) )
                {
                    // レイアウト生成
                    ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                    stream.Position = 0;
                    prtRpt.LoadLayout( stream );

                    // スクリプトクリア
                    prtRpt.Script = string.Empty;

                    // ディクショナリに追加
                    newDic.Add( key, prtRpt );
                }
            }

            // ディクショナリを差し替える
            subReportDic = newDic;
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// 印刷レイアウト情報取得
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <param name="columnVisibleTypeDic"></param>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //private void GetLayoutInfo(FrePrtPSetWork frePrtPSet, out Dictionary<string, string> columnVisibleTypeDic, out Dictionary<string, string> titleDic)
        private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, ref Dictionary<string, string> columnVisibleTypeDic, ref Dictionary<string, string> titleDic )
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        {
            // 初期化
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //columnVisibleTypeDic = new Dictionary<string, string>();
            //titleDic = new Dictionary<string, string>();
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            //Dictionary<string, string> reportItemDic = new Dictionary<string, string>();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
            if ( columnVisibleTypeDic == null )
            {
                columnVisibleTypeDic = new Dictionary<string, string>();
            }
            if ( titleDic == null )
            {
                titleDic = new Dictionary<string, string>();
            }
            Dictionary<string, string> reportItemDic = PMUOE08001PB.ReportItemDic;
            if ( reportItemDic == null )
            {
                reportItemDic = new Dictionary<string, string>();
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<

            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //if (_frePrtPSet == null || _frePrtPSet.PrintPosClassData == null) return;
            // 
            //using (MemoryStream stream = new MemoryStream(_frePrtPSet.PrintPosClassData))

            if ( frePrtPSet == null || frePrtPSet.PrintPosClassData == null ) return;

            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            {
                // レイアウト生成
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout(stream);

                // レイアウト情報の取得
                foreach (DataDynamics.ActiveReports.Section section in prtRpt.Sections)
                {
                    foreach (DataDynamics.ActiveReports.ARControl arControl in section.Controls)
                    {
                        if (arControl is ar.TextBox && arControl.Tag is string)
                        {
                            // 【Tag情報の取得】
                            //   0: FreePrtPaperItemCd
                            //   1: PrintPageCtrlDivCd
                            //   2: GroupSuppressCd
                            //   3: DtlColorChangeCd
                            //   4: HeightAdjustDivCd);
                            string[] data = ( arControl.Tag as String ).Split(',');

                            // ※同一項目が複数ある場合は最初にヒットした情報を使用する。
                            string dataFieldName = arControl.DataField.ToUpper();
                            if (!columnVisibleTypeDic.ContainsKey(dataFieldName))
                            {
                                // 伝票印刷用に変更したPrintPageCtrlDivCdを格納
                                columnVisibleTypeDic.Add(dataFieldName, data[1]);
                            }

                            // 消費税ラベルテキスト退避
                            if (( arControl.Tag as String ).StartsWith("67,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_TaxTitle))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_TaxTitle, ( arControl as ar.Label ).Text);
                                }
                            }
                            // 小計ラベルテキスト退避
                            if (( arControl.Tag as String ).StartsWith("68,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_SubTotalTitle))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_SubTotalTitle, ( arControl as ar.Label ).Text);
                                }
                            }
                            // 受信時刻ラベルテキスト退避
                            if (( arControl.Tag as String ).StartsWith("69,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_ReceiveTimeLabel))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_ReceiveTimeLabel, ( arControl as ar.Label ).Text);
                                }
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
                            // レポート項目ディクショナリに追加
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD

                            // --- ADD 2009.07.24 劉洋 ---------->>>>>
                            // 出荷数マイナス符号 ラベルテキスト退避
                            //if ("DADD.SHIPMENTCNTMINUSSIGNRF".Equals(dataFieldName))
                            if (( arControl.Tag as String ).StartsWith("40,"))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_ShipmentCntMinusSignRF))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_ShipmentCntMinusSignRF, ( arControl as ar.Label ).Text);
                                }
                            }
                            // 売上金額（税抜き）売上金額マイナス符号 テキスト退避
                            if (( arControl.Tag as String ).StartsWith("41,"))
                            //if ("DADD.SALESMONEYTAXEXCMINUSSIGNRF".Equals(dataFieldName))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_SalesMoneyTaxExcMinusSignRF))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_SalesMoneyTaxExcMinusSignRF, ( arControl as ar.Label ).Text);
                                }
                            }
                            // AB本部原価金額マイナス符号 ラベルテキスト退避
                            if (( arControl.Tag as String ).StartsWith("42,"))
                            //if ("DADD.ABHQSALESUNITCOSTMINUSSIGNRF".Equals(dataFieldName))
                            {
                                if (!titleDic.ContainsKey(PMUOE08001PB.ct_ABHqSalesUnitCostMinusSignRF))
                                {
                                    titleDic.Add(PMUOE08001PB.ct_ABHqSalesUnitCostMinusSignRF, ( arControl as ar.Label ).Text);
                                }
                            }
                            // --- ADD 2009.07.24 劉洋 ----------<<<<<
                        }
                        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                        else if ( arControl is ar.Barcode )
                        {
                            string dataFieldName = (arControl as ar.Barcode).DataField.ToUpper();

                            // レポート項目ディクショナリに追加
                            if ( !reportItemDic.ContainsKey( dataFieldName ) )
                            {
                                reportItemDic.Add( dataFieldName, dataFieldName );
                            }
                        }
                        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        else if ( arControl is ar.Label )
                        {
                            ar.Label label = (arControl as ar.Label);
                            const string subReportDataField = "FREEPRINT.SUBREPORT";

                            // サブレポート機能の判定
                            if ( arControl.DataField == subReportDataField )
                            {
                                // Textをカンマで区切る。
                                string formName = label.Text.Split( ',' )[0];

                                if ( _subReportDic == null )
                                {
                                    _subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                                }

                                if ( !_subReportDic.ContainsKey( formName ) )
                                {
                                    // サブレポートディクショナリに追加（valueとなるReportは後で読み込んでセットする）
                                    _subReportDic.Add( formName, null );

                                    // レポート項目ディクショナリに追加
                                    if ( !reportItemDic.ContainsKey( subReportDataField ) )
                                    {
                                        reportItemDic.Add( subReportDataField, subReportDataField );
                                    }
                                }
                            }
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                    }
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.21 ADD
            PMUOE08001PB.ReportItemDic = reportItemDic;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.21 ADD
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckExistsMasters()
        {
            List<string> errorList = new List<string>();

            // 伝票印刷設定マスタ
            if (_slipPrtSet == null)
            {
                errorList.Add("伝票印刷設定");
            }
            // 自由帳票印字位置設定マスタ
            else if (_frePrtPSet == null)
            {
                errorList.Add("自由帳票印字位置設定");
            }
            // 売上全体設定マスタ
            else if (_salesTtlSt == null)
            {
                errorList.Add("売上全体設定");
            }
            // 全体初期表示設定マスタ
            else if (_allDefSet == null)
            {
                errorList.Add("全体初期表示設定");
            }

            if (errorList.Count == 0)
            {
                return true;
            }
            else
            {
                string errMsg = "以下のマスタ登録内容が不正な為、印刷できませんでした。" + Environment.NewLine + Environment.NewLine;
                foreach (string err in errorList)
                {
                    errMsg += string.Format("  {0}{1}", err, Environment.NewLine);
                }
                errMsg += Environment.NewLine;

                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP
                    , ToString()
                    , "自由帳票伝票印刷"
                    , ""
                    , TMsgDisp.OPE_PRINT
                    , errMsg
                    , -1
                    , null
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);

                return false;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD

        /// <summary>
        /// 印刷開始処理（プレビュー無し）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を開始します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        public int StartDirectPrint(object sender)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            status = StartPrint(true);

            return status;
        }

        /// <summary>
        /// 印刷開始処理（PDF出力）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: PDF出力処理を開始します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        public int StartPdfPrint(object sender)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            status = StartPrint(false);

            return status;
        }

        /// <summary>
        /// プレビュー処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を開始します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        public int StartPreview(object sender)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            status = StartPrint(false);

            return status;
        }

        /// <summary>
        /// 印刷開始処理（プレビュー有り）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を開始します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        public int StartPreviewPrint(object sender)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            status = StartPrint(false);

            return status;
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行います。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        private int StartPrint(bool isDirectPrint)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (_frePrtPSet == null || _frePrtPSet.PrintPosClassData == null) return status;

            // レポートドキュメント初期化
            _printDocument = new Document();
            _previewDocument = new Document();

            using (MemoryStream stream = new MemoryStream(_frePrtPSet.PrintPosClassData))
            {
                //ar.ActiveReport3 prvRpt = null;
                ar.ActiveReport3 prtRpt = null;

                for (int tableIndex = 0; tableIndex < _ds.Tables.Count; tableIndex++)
                {
                    // ---------------------------------
                    // 印刷用Documentの生成
                    // ---------------------------------

                    // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                    // QRｺｰﾄﾞの印字サイズ設定
                    _reportCtrl.QrCodeSizeDic = PMUOE08001PB.GetQRCodeSizeDictionary( _ds.Tables[tableIndex], _frePrtPSet.FormFeedLineCount );
                    // --- ADD m.suzuki 2010/03/24 ----------<<<<<

                    // 印刷部数分繰り返す
                    for (int circulateCount = 0; circulateCount < _slipPrtSet.PrtCirculation; circulateCount++)
                    {
                        // 複写枚数分繰り返す
                        for (int copyCount = 0; copyCount < _slipPrtSet.CopyCount; copyCount++)
                        {
                            prtRpt = new ar.ActiveReport3();
                            stream.Position = 0;
                            prtRpt.LoadLayout(stream);
                            // --- DEL m.suzuki 2010/03/24 ---------->>>>>
                            //# if false
                            //if ( circulateCount == 0 && copyCount == 0)
                            //{
                            //    prtRpt.SaveLayout( "d:\\PMUOE08001P.dat" );
                            //}
                            //# endif
                            // --- DEL m.suzuki 2010/03/24 ----------<<<<<
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 DEL
                            //SFANL08235CE.AddScriptReference( ref prtRpt );	// Script用参照追加
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 ADD
                            // 自由帳票標準のスクリプトを無効化する
                            prtRpt.Script = string.Empty;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 ADD
                            SetMargin(prtRpt);
                            SetPrinterInfo(prtRpt.Document);
                            SFANL08235CE.SetValidPaperKind(prtRpt);
                            _reportCtrl.SetReportProps(ref prtRpt); // 帳票共通設定
                            prtRpt.DataSource = _ds;
                            prtRpt.DataMember = _ds.Tables[tableIndex].TableName;

                            # region [同一ページ内コピー制御]
                            DataDynamics.ActiveReports.GroupHeader topHeader;
                            try
                            {
                                topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                            }
                            catch
                            {
                                prtRpt.Sections.Add(DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1");
                                topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                            }
                            topHeader.DataField = PMUOE08001PB.ct_InPageCopyCount;
                            topHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                            # endregion

                            // 複写等に伴うフィールド設定
                            SettingFieldInfoByTag(ref prtRpt, copyCount, _ds.Tables[tableIndex]);
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            # region [サブレポートにも適用]
                            // サブレポート情報の再作成
                            if ( tableIndex != 0 || circulateCount != 0 || copyCount != 0 )
                            {
                                RenewSubReportDic( ref _subReportDic, _frePrtPSetDic );
                                _reportCtrl.SubReportDic = _subReportDic;
                            }
                            // サブレポートに共通処理適用
                            foreach ( string key in _reportCtrl.SubReportDic.Keys )
                            {
                                ar.ActiveReport3 subReport = _reportCtrl.SubReportDic[key];
                                _reportCtrl.SetReportProps( ref subReport );
                                SettingFieldInfoByTag( ref subReport, copyCount, _ds.Tables[tableIndex] );
                            }
                            # endregion
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                            // 印刷実行
                            prtRpt.Run();

                            // 印刷用Documentにまとめる
                            _printDocument.Pages.AddRange(prtRpt.Document.Pages);

                            // プレビューは印刷部数によらず常に１部の分だけ表示する
                            if (circulateCount == 0 && copyCount == 0)
                            {
                                _previewDocument.Pages.AddRange(prtRpt.Document.Pages);
                            }
                        }
                    }
                }
                if (prtRpt != null)
                {
                    SetPrinterInfo(_printDocument);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                    _previewDocument.Printer.PrinterName = _printDocument.Printer.PrinterName;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD

                    // 用紙の種類を指定
                    _printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    _previewDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    // 用紙サイズがカスタムの時は用紙サイズまで指定
                    if (prtRpt.PageSettings.PaperKind == PaperKind.Custom)
                    {
                        _printDocument.Printer.PaperSize = new PaperSize("Custom", Convert.ToInt32(prtRpt.PageSettings.PaperWidth * 100), Convert.ToInt32(prtRpt.PageSettings.PaperHeight * 100));
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                        _previewDocument.Printer.PaperSize = _printDocument.Printer.PaperSize;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
                    }
                    // 用紙方向（縦・横）の設定
                    if (prtRpt.PageSettings.Orientation == PageOrientation.Landscape)
                    {
                        _printDocument.Printer.Landscape = true;
                        _previewDocument.Printer.Landscape = true;
                    }
                }

                // 直接印刷の場合
                if (isDirectPrint)
                {
                    _printDocument.Print(false, false, false);
                }

                stream.Close();
            }

            return status;
        }


        /// <summary>
        /// 複写等に伴うフィールド設定処理
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="copyCount"></param>
        /// <param name="dataTable"></param>
        /// <remarks>印字項目CD=51～100に対する処理。</remarks>
        /// 
        private void SettingFieldInfoByTag(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, int copyCount, DataTable dataTable)
        {
            // 消費税転嫁方式（0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税）
            int consTaxLayMethod = PMUOE08001PB.GetSALESSLIPRF_CONSTAXLAYMETHODRF(dataTable);

            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //売上伝票合計（税抜き）(マイナス符号なし)
            Double salestotaltaxexcnominusrf = PMUOE08001PB.GetHADD_SALESTOTALTAXEXCNOMINUSRF(dataTable);

            //AB本部原価金額合計(マイナス符号なし)
            Double abhqtotalcostnominusrf = PMUOE08001PB.GetHADD_ABHQTOTALCOSTNOMINUSRF(dataTable);
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<

            # region [複写色]
            Color backColor = GetBackColor(copyCount);
            Color backColorLight = MixColor(backColor, Color.FromArgb(77, 70, 87), 0);

            Color foreColor;
            // 背景が暗い場合は文字を白抜きにする
            if (IsDark(backColor))
            {
                foreColor = Color.White;
            }
            else
            {
                foreColor = Color.Black;
            }
            # endregion

            foreach (DataDynamics.ActiveReports.Section section in prtRpt.Sections)
            {
                foreach (DataDynamics.ActiveReports.ARControl arControl in section.Controls)
                {
                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //if (arControl.Tag is string)
                    if ( (arControl.Tag is string) && (arControl.Tag as string).Length >= 3 )
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    {
                        string tagSub = ( arControl.Tag as string ).Substring(0, 3);

                        # region [特殊項目(51～100)]
                        switch (tagSub)
                        {
                            // --- ADD 李占川 2011/08/15---------->>>>>
                            case "34,":
                                {
                                    //-------------------------------------------
                                    // 「34:タイトル１」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle11;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle21;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle31;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle41;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "35,":
                                {
                                    //-------------------------------------------
                                    // 「35:タイトル２」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle12;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle22;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle32;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle42;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "36,":
                                {
                                    //-------------------------------------------
                                    // 「36:タイトル３」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle13;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle23;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle33;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle43;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "37,":
                                {
                                    //-------------------------------------------
                                    // 「37:タイトル４」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle14;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle24;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle34;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle44;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "38,":
                                {
                                    //-------------------------------------------
                                    // 「38:タイトル５」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle15;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle25;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle35;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMUOE08001PB.ct_SlipTitle45;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            // --- ADD 李占川 2011/08/15----------<<<<<

                            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
                            case "43,":
                                {
                                    //-------------------------------------------
                                    // 「43:売上伝票合計（税抜き）マイナス符号」の場合
                                    //-------------------------------------------
                                    if (salestotaltaxexcnominusrf >= 0)
                                    {
                                        // 売上伝票合計（税抜き）マイナス符号 false
                                        ( arControl as ar.Label ).Visible = false;
                                    }
                                    else
                                    {
                                        // 売上伝票合計（税抜き）マイナス符号 true
                                    }
                                }
                                break;
                            case "44,":
                                {
                                    //-------------------------------------------
                                    // 「44:AB本部原価金額合計マイナス符号」の場合
                                    //-------------------------------------------
                                    if (abhqtotalcostnominusrf >= 0)
                                    {
                                        // AB本部原価金額合計マイナス符号 false
                                        ( arControl as ar.Label ).Visible = false;
                                    }
                                    else
                                    {
                                        // AB本部原価金額合計マイナス符号 true
                                    }
                                }
                                break;
                            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
                            // 2011/05/27 Add >>>
                            case "49,":
                                {
                                    //-------------------------------------------
                                    // 「49:車台番号リテラル(入力時のみ)」の場合
                                    //-------------------------------------------
                                    if (string.IsNullOrEmpty(PMUOE08001PB.GetHADD_FRAMENORF(dataTable)))
                                    {
                                        (arControl as ar.Label).Visible = false;
                                    }
                                    else
                                    {
                                        (arControl as ar.Label).Visible = true;
                                    }
                                }
                                break;
                            // 2011/05/27 Add <<<
                            case "51,":
                                {
                                    //-------------------------------------------
                                    // 「51:複写色背景固定文字」の場合
                                    //-------------------------------------------
                                    DataDynamics.ActiveReports.Label label = ( arControl as DataDynamics.ActiveReports.Label );
                                    label.BackColor = backColorLight;
                                    label.ForeColor = foreColor;
                                    // 矩形枠の色設定
                                    label.Border.TopColor = backColor;
                                    label.Border.BottomColor = backColor;
                                    label.Border.LeftColor = backColor;
                                    label.Border.RightColor = backColor;
                                }
                                break;
                            case "52,":
                                {
                                    //-------------------------------------------
                                    // 「52:複写色直線」の場合
                                    //-------------------------------------------
                                    ( arControl as DataDynamics.ActiveReports.Line ).LineColor = backColor;
                                }
                                break;
                            case "53,":
                                {
                                    //-------------------------------------------
                                    // 「53:複写色枠線」の場合
                                    //-------------------------------------------
                                    ( arControl as DataDynamics.ActiveReports.Shape ).LineColor = backColor;
                                }
                                break;
                            case "54,":
                                {
                                    //-------------------------------------------
                                    // 「54:複写色固定文字」の場合
                                    //-------------------------------------------
                                    ( arControl as DataDynamics.ActiveReports.TextBox ).ForeColor = backColor;
                                }
                                break;
                            case "55,":
                                {
                                    //-------------------------------------------
                                    // 「55:複写対応伝票タイトル」の場合
                                    //-------------------------------------------
                                    //(arControl as DataDynamics.ActiveReports.Label).Text = GetSlipTitle( copyCount );
                                    //(arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                    switch (copyCount)
                                    {
                                        case 0:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle1;
                                            break;
                                        case 1:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle2;
                                            break;
                                        case 2:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle3;
                                            break;
                                        case 3:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = PMUOE08001PB.ct_InPageCopyTitle4;
                                            break;
                                        default:
                                            ( arControl as DataDynamics.ActiveReports.Label ).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "56,":
                                {
                                    //-------------------------------------------
                                    // 「56:自社情報固定文字」の場合
                                    //-------------------------------------------
                                    // 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
                                    switch (_slipPrtSet.EnterpriseNamePrtCd)
                                    {
                                        case 2:
                                        case 3:
                                            {
                                                arControl.Visible = false;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "57,":
                                {
                                    //-------------------------------------------
                                    // 「57:時刻固定文字」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_slipPrtSet.TimePrintDivCd == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "58,":
                                {
                                    //-------------------------------------------
                                    // 「58:品番タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.GoodsNo == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "59,":
                                {
                                    //-------------------------------------------
                                    // 「59:BLコードタイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.BLGoodsCode == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "60,":
                                {
                                    //-------------------------------------------
                                    // 「60:標準価格タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.ListPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "61,":
                                {
                                    //-------------------------------------------
                                    // 「61:売価タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.SalesPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "62,":
                                {
                                    //-------------------------------------------
                                    // 「62:原価タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.Cost == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "63,":
                                {
                                    //-------------------------------------------
                                    // 「63:担当者タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.SalesEmployee == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "64,":
                                {
                                    //-------------------------------------------
                                    // 「64:受注者タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.FrontEmployee == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "65,":
                                {
                                    //-------------------------------------------
                                    // 「65:発行者タイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.SalesInput == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "66,":
                                {
                                    //-------------------------------------------
                                    // 「66:取寄マークタイトル」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if (_eachSlipTypeSet.SalesOrderDiv == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "67,":
                                {
                                    //-------------------------------------------
                                    // 「67:消費税タイトル」の場合
                                    //-------------------------------------------
                                    // 売価＝0:非印字,1:印字
                                    if (_eachSlipTypeSet.SalesPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                    else
                                    {
                                        // 転嫁方式
                                        switch (consTaxLayMethod)
                                        {
                                            case 0:
                                            case 1:
                                                {
                                                    // 消費税＝0:印字しない
                                                    if (_slipPrtSet.ConsTaxPrtCdRF == 0)
                                                    {
                                                        // 非印字
                                                        arControl.Visible = false;
                                                    }
                                                }
                                                break;
                                            case 2:
                                            case 3:
                                            default:
                                                {
                                                    // 非印字
                                                    arControl.Visible = false;
                                                }
                                                break;
                                        }
                                    }

                                    // ラベルの印字内容を制御する
                                    ( arControl as ar.Label ).DataField = PMUOE08001PB.ct_TaxTitle;
                                }
                                break;
                            case "68,":
                                {
                                    //-------------------------------------------
                                    // 「68:小計タイトル（明細・伝票転嫁）」の場合
                                    //-------------------------------------------
                                    // 売価＝0:非印字,1:印字
                                    if (_eachSlipTypeSet.SalesPrice == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                    else
                                    {
                                        // 転嫁方式
                                        switch (consTaxLayMethod)
                                        {
                                            case 0:
                                            case 1:
                                            default:
                                                {
                                                    // 消費税＝0:印字しない
                                                    if (_slipPrtSet.ConsTaxPrtCdRF == 0)
                                                    {
                                                        // 非印字
                                                        arControl.Visible = false;
                                                    }
                                                }
                                                break;
                                            case 2:
                                            case 3:
                                            case 9:
                                                {
                                                    // 非印字
                                                    arControl.Visible = false;
                                                }
                                                break;
                                        }
                                    }

                                    // ラベルの印字内容を制御する
                                    ( arControl as ar.Label ).DataField = PMUOE08001PB.ct_SubTotalTitle;
                                }
                                break;
                            case "69,":
                                {
                                    //-------------------------------------------
                                    // 69:受信時刻固定文字の場合
                                    //-------------------------------------------

                                    // 0:非印字,1:印字
                                    if (_slipPrtSet.TimePrintDivCd == 0)
                                    {
                                        arControl.Visible = false;
                                    }
                                    // ラベルの印字内容を制御する
                                    ( arControl as ar.Label ).DataField = PMUOE08001PB.ct_ReceiveTimeLabel;
                                }
                                break;
                            default:
                                break;
                        }
                        # endregion
                    }
                }


                //// --- ADD 2009.07.24 劉洋 ------ >>>>>>
                //if ("Detail1".Equals(section.Name))
                //{
                //    foreach (DataRow row in dataTable.Rows)
                //    {
                //        foreach (DataDynamics.ActiveReports.ARControl arControl in section.Controls)
                //        {
                //            if (arControl.Tag is string)
                //            {
                //                string tagSub = (arControl.Tag as string).Substring(0, 3);

                //                # region [特殊項目(40-42)]
                //                switch (tagSub)
                //                {
                //                    case "40,":
                //                        {
                //                            //-------------------------------------------
                //                            // 「40:出荷数マイナス符号」の場合
                //                            //-------------------------------------------
                //                            try
                //                            {
                //                                if (!row.IsNull("DADD.SHIPMENTCNTNOMINUSRF"))
                //                                {
                //                                    if ((Double)row["DADD.SHIPMENTCNTNOMINUSRF"] >= 0)
                //                                    {
                //                                        // 出荷数マイナス符号 false
                //                                        (arControl as ar.Label).Visible = false;
                //                                    }
                //                                    else
                //                                    {
                //                                        // 出荷数マイナス符号 true
                //                                    }
                //                                }
                //                                else
                //                                {
                //                                    // 出荷数マイナス符号 false
                //                                    (arControl as ar.Label).Visible = false;
                //                                }
                //                            }
                //                            catch
                //                            {

                //                            }
                //                        }
                //                        break;
                //                    case "41,":
                //                        {
                //                            //-------------------------------------------
                //                            // 「41:売上金額（税抜き）売上金額マイナス符号」の場合
                //                            //-------------------------------------------
                //                            if (!row.IsNull("DADD.SALESMONEYTAXEXCNOMINUSRF"))
                //                            {
                //                                if ((Double)row["DADD.SALESMONEYTAXEXCNOMINUSRF"] >= 0)
                //                                {
                //                                    // 売上金額（税抜き）売上金額マイナス符号 false
                //                                    (arControl as ar.Label).Visible = false;
                //                                }
                //                                else
                //                                {
                //                                    // 売上金額（税抜き）売上金額マイナス符号 true
                //                                }
                //                            }
                //                            else
                //                            {
                //                                // 売上金額（税抜き）売上金額マイナス符号 false
                //                                (arControl as ar.Label).Visible = false;
                //                            }
                //                        }
                //                        break;
                //                    case "42,":
                //                        {
                //                            //-------------------------------------------
                //                            // 「42:AB本部原価金額マイナス符号)」の場合
                //                            //-------------------------------------------
                //                            if (!row.IsNull("DADD.ABHQSALESUNITCOSTNOMINUSRF"))
                //                            {
                //                                if ((Double)row["DADD.ABHQSALESUNITCOSTNOMINUSRF"] >= 0)
                //                                {
                //                                    // AB本部原価金額マイナス符号 false
                //                                    (arControl as ar.Label).Visible = false;
                //                                }
                //                                else
                //                                {
                //                                    // AB本部原価金額マイナス符号 true
                //                                }
                //                            }
                //                            else
                //                            {
                //                                // AB本部原価金額マイナス符号 false
                //                                (arControl as ar.Label).Visible = false;
                //                            }
                //                        }
                //                        break;
                //                    default:
                //                        break;
                //                }
                //                # endregion [特殊項目(40-42)]

                //            }
                //        }
                //    }
                //}
                //// --- ADD 2009.07.24 劉洋 ------ <<<<<<
            }
        }
        # region [伝票複写対応]
        /// <summary>
        /// 複写対応伝票タイトル取得処理
        /// </summary>
        /// <param name="copyCount"></param>
        /// <returns></returns>
        private string GetSlipTitle(int copyCount)
        {
            switch (copyCount)
            {
                case 0:
                    return _slipPrtSet.TitleName1;
                case 1:
                    return _slipPrtSet.TitleName2;
                case 2:
                    return _slipPrtSet.TitleName3;
                case 3:
                    return _slipPrtSet.TitleName4;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 伝票背景色取得処理
        /// </summary>
        /// <param name="copyCountIndex">複写ページindex</param>
        /// <returns></returns>
        private Color GetBackColor(int copyCountIndex)
        {
            switch (copyCountIndex)
            {
                case 0:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed1, _slipPrtSet.SlipBaseColorGrn1, _slipPrtSet.SlipBaseColorBlu1);
                case 1:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed2, _slipPrtSet.SlipBaseColorGrn2, _slipPrtSet.SlipBaseColorBlu2);
                case 2:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed3, _slipPrtSet.SlipBaseColorGrn3, _slipPrtSet.SlipBaseColorBlu3);
                case 3:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed4, _slipPrtSet.SlipBaseColorGrn4, _slipPrtSet.SlipBaseColorBlu4);
                case 4:
                    return Color.FromArgb(_slipPrtSet.SlipBaseColorRed5, _slipPrtSet.SlipBaseColorGrn5, _slipPrtSet.SlipBaseColorBlu5);
                default:
                    return Color.Transparent;
            }
        }
        /// <summary>
        /// 色合成処理
        /// </summary>
        /// <param name="firstColor">合成元のColor構造体</param>
        /// <param name="secondColor">合成元のColor構造体</param>
        /// <param name="mixMode">合成モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : ２つのColor構造体から別のColor構造体を作成します。</br>
        /// <br>               （この処理はDC.NS流通伝票印刷の仕様に準拠しています。）</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        private static Color MixColor(Color firstColor, Color secondColor, int mixMode)
        {
            switch (mixMode)
            {
                case 0:
                    {
                        int redColor = firstColor.R + secondColor.R;
                        if (redColor > 255)
                        {
                            redColor = 255;
                        }
                        int greenColor = firstColor.G + secondColor.G;
                        if (greenColor > 255)
                        {
                            greenColor = 255;
                        }
                        int blueColor = firstColor.B + secondColor.B;
                        if (blueColor > 255)
                        {
                            blueColor = 255;
                        }

                        return Color.FromArgb(redColor, greenColor, blueColor);
                    }
            }
            return Color.Transparent;
        }
        /// <summary>
        /// 背景色　明暗判定
        /// </summary>
        /// <param name="backColor"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>（この処理はDC.NS流通伝票印刷の仕様に準拠しています。）</br>
        /// </remarks>
        private static bool IsDark(Color backColor)
        {
            // 判定しきい値
            int divColorPoint = 200;

            if ((int)backColor.R + (int)backColor.G + (int)backColor.B < divColorPoint)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        /// <summary>
        /// 余白設定処理
        /// </summary>
        /// <param name="rpt">アクティブレポートオブジェクト</param>
        /// <remarks>
        /// <br>Note		: 余白設定をします。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        private void SetMargin(ar.ActiveReport3 rpt)
        {
            // 上の余白を設定
            rpt.PageSettings.Margins.Top
                = ar.ActiveReport3.CmToInch((float)_slipPrtSet.TopMargin);
            // 下の余白を設定
            rpt.PageSettings.Margins.Bottom
                = ar.ActiveReport3.CmToInch((float)_slipPrtSet.BottomMargin);
            // 左の余白を設定
            rpt.PageSettings.Margins.Left
                = ar.ActiveReport3.CmToInch((float)_slipPrtSet.LeftMargin);
            // 右の余白を設定
            rpt.PageSettings.Margins.Right
                = ar.ActiveReport3.CmToInch((float)_slipPrtSet.RightMargin);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
            // ReportのPrintWidthがinch単位で中途半端な場合、不要な空ページが印刷されてしまうので防止する。
            // (小数第３位以降は切り捨てる)
            int width = (int)( (float)rpt.PrintWidth * (float)100.0f );
            rpt.PrintWidth = (float)width / (float)100.0f;
            // 余白分を除く
            rpt.PrintWidth -= ( rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
        }

        /// <summary>
        /// プリンター情報セット処理
        /// </summary>
        /// <param name="document">レポートDocument</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: プリンター情報を設定します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.11.18</br>
        /// </remarks>
        private void SetPrinterInfo(Document document)
        {
            // 使用プリンターの設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 DEL
            //foreach (string wkStr in PrinterSettings.InstalledPrinters)
            //{
            //    if (wkStr.Equals(_slipPrintConditionInfo.PrinterName))
            //    {
            //        document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            //        break;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD

            // 使用プリンタの有効有無チェック（有効では無い場合は仮想プリンタを使用）
            if (!document.Printer.PrinterSettings.IsValid)
                document.Printer.PrinterSettings.PrinterName = string.Empty;
        }
        #endregion
    }

    # region [伝票タイプ別設定]
    /// <summary>
    /// 伝票タイプ別設定
    /// </summary>
    internal struct EachSlipTypeSet
    {
        /// <summary>品番印字</summary>
        private int _goodsNo;
        /// <summary>ＢＬコード印字</summary>
        private int _bLGoodsCode;
        /// <summary>標準価格印字</summary>
        private int _listPrice;
        /// <summary>売価印字</summary>
        private int _salesPrice;
        /// <summary>原価印字</summary>
        private int _cost;
        /// <summary>担当者印字</summary>
        private int _salesEmployee;
        /// <summary>受注者印字</summary>
        private int _frontEmployee;
        /// <summary>発行者印字</summary>
        private int _salesInput;
        /// <summary>取寄マーク印字</summary>
        private int _salesOrderDiv;
        /// <summary>
        /// 品番印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }
        /// <summary>
        /// ＢＬコード印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }
        /// <summary>
        /// 標準価格印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }
        /// <summary>
        /// 売価印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }
        /// <summary>
        /// 原価印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        /// <summary>
        /// 担当者印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int SalesEmployee
        {
            get { return _salesEmployee; }
            set { _salesEmployee = value; }
        }
        /// <summary>
        /// 受注者印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int FrontEmployee
        {
            get { return _frontEmployee; }
            set { _frontEmployee = value; }
        }
        /// <summary>
        /// 発行者印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int SalesInput
        {
            get { return _salesInput; }
            set { _salesInput = value; }
        }
        /// <summary>
        /// 取寄マーク印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int SalesOrderDiv
        {
            get { return _salesOrderDiv; }
            set { _salesOrderDiv = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="goodsNo">品番印字</param>
        /// <param name="bLGoodsCode">ＢＬコード印字</param>
        /// <param name="listPrice">標準価格印字</param>
        /// <param name="salesPrice">売価印字</param>
        /// <param name="cost">原価印字</param>
        /// <param name="salesEmployee">担当者印字</param>
        /// <param name="frontEmployee">受注者印字</param>
        /// <param name="salesInput">発行者印字</param>
        /// <param name="salesOrderDiv">取寄マーク印字</param>
        public EachSlipTypeSet(int goodsNo, int bLGoodsCode, int listPrice, int salesPrice, int cost, int salesEmployee, int frontEmployee, int salesInput, int salesOrderDiv)
        {
            _goodsNo = goodsNo;
            _bLGoodsCode = bLGoodsCode;
            _listPrice = listPrice;
            _salesPrice = salesPrice;
            _cost = cost;
            _salesEmployee = salesEmployee;
            _frontEmployee = frontEmployee;
            _salesInput = salesInput;
            _salesOrderDiv = salesOrderDiv;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="slipPrtSet">伝票印刷設定</param>
        public EachSlipTypeSet(SlipPrtSetWork slipPrtSet)
        {
            _goodsNo = slipPrtSet.EachSlipTypeColPrt1;
            _bLGoodsCode = slipPrtSet.EachSlipTypeColPrt2;
            _listPrice = slipPrtSet.EachSlipTypeColPrt3;
            _salesPrice = slipPrtSet.EachSlipTypeColPrt4;
            _cost = slipPrtSet.EachSlipTypeColPrt5;
            _salesEmployee = slipPrtSet.EachSlipTypeColPrt6;
            _frontEmployee = slipPrtSet.EachSlipTypeColPrt7;
            _salesInput = slipPrtSet.EachSlipTypeColPrt8;
            _salesOrderDiv = slipPrtSet.EachSlipTypeColPrt9;
        }
    }
    # endregion

    # region ■　伝票印刷パラメータ構造体　■
    /// <summary>
    /// 伝票印刷パラメータ構造体
    /// </summary>
    /// <remarks>
    /// <br>※データクラスのメンバとして存在しないデータを</br>
    /// <br>　印刷ＤＬＬに受け渡す為の構造体です。</br>
    /// <br>※objectのディクショナリとの相互変換機能を持ちます。</br>
    /// </remarks>
    internal struct SlipPrintParameter
    {
        /// <summary>日付印字有無(0:しない/1:する)</summary>
        private int _slipDatePrintDiv;
        /// <summary>合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</summary>
        private int _totalPricePrtCd;
        /// <summary>再発行区分</summary>
        private bool _reissueDiv;
        /// <summary>
        /// 日付印字有無(0:しない/1:する)
        /// </summary>
        public int SlipDatePrintDiv
        {
            get { return _slipDatePrintDiv; }
            set { _slipDatePrintDiv = value; }
        }
        /// <summary>
        /// 合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)
        /// </summary>
        public int TotalPricePrtCd
        {
            get { return _totalPricePrtCd; }
            set { _totalPricePrtCd = value; }
        }
        /// <summary>
        /// 再発行区分
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="slipDatePrintDiv">日付印字有無(0:しない/1:する)</param>
        /// <param name="totalPricePrtCd">合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</param>
        /// <param name="reissueDiv">再発行区分</param>
        public SlipPrintParameter(int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv)
        {
            _slipDatePrintDiv = slipDatePrintDiv;
            _totalPricePrtCd = totalPricePrtCd;
            _reissueDiv = reissueDiv;
        }
        /// <summary>
        /// コンストラクタ (objectのディクショナリより)
        /// </summary>
        /// <param name="objectDictionary"></param>
        public SlipPrintParameter(Dictionary<string, object> objectDictionary)
        {
            // 初期値を設定
            _slipDatePrintDiv = 1;
            _totalPricePrtCd = 0;
            _reissueDiv = false;

            // 渡されたListの内容を格納
            if (objectDictionary != null)
            {
                if (objectDictionary.ContainsKey("SlipDatePrintDiv") && objectDictionary["SlipDatePrintDiv"] is int)
                {
                    _slipDatePrintDiv = (int)objectDictionary["SlipDatePrintDiv"];
                }
                if (objectDictionary.ContainsKey("TotalPricePrtCd") && objectDictionary["TotalPricePrtCd"] is int)
                {
                    _totalPricePrtCd = (int)objectDictionary["TotalPricePrtCd"];
                }
                if (objectDictionary.ContainsKey("ReissueDiv") && objectDictionary["ReissueDiv"] is bool)
                {
                    _reissueDiv = (bool)objectDictionary["ReissueDiv"];
                }
            }
        }
        /// <summary>
        /// ディクショナリへ変換
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary()
        {
            // メンバをディクショナリに格納
            Dictionary<string, object> objectDic = new Dictionary<string, object>();
            objectDic.Add("SlipDatePrintDiv", _slipDatePrintDiv);
            objectDic.Add("TotalPricePrtCd", _totalPricePrtCd);
            objectDic.Add("ReissueDiv", _reissueDiv);

            // Dictionaryを返す
            return objectDic;
        }
    }
    # endregion ■　伝票印刷パラメータ構造体　■
}
