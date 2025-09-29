//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : wangf
// 作 成 日  K2013/06/27 修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : wujun
// 修 正 日  K2013/07/11 修正内容 : 端末未設定時、メッセージ出さずに常駐も起動しない
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : wujun
// 修 正 日  K2013/07/29 修正内容 : 次回送信実行時間計算の修正
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : 田建委
// 修 正 日  K2013/08/07  修正内容 : Redmine#39695 抽出結果無時の結果画面表示の変更対応
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : 田建委
// 修 正 日  K2013/08/12  修正内容 : Redmine#39695 抽出結果無時のログ内容の変更対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Microsoft.Win32;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信処理自起動
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信処理自起動UIフォームクラス</br>
    /// <br>Programmer : wangf</br>
    /// <br>Date       : K2013/06/27</br>
    /// <br>UpdateNote : K2013/08/12 田建委</br>
    /// <br>           : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
    /// </remarks>
    public partial class PMSAE04020UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Member
        // 売上データテキスト出力 アクセスクラス
        private SalesHistoryAcs _salesHistoryAcs;
        // 接続先情報設定 アクセスクラス
        private ConnectInfoWorkAcs _connectInfoWorkAcs;
        // XMLファイル　アクセスクラス
        private FormattedTextWriter _formattedTextWriter;
        // 企業コード
        private string _enterpriseCode;
        // バッチ起動時間
        //private DateTime _batchStartDate; // DEL BY wujun K2013/07/29
        // ファイル名称
        private string _fileName;
        // XMLメモファイル名称
        private const string _XMLMEMOFILEPATH = "PMSAE02010U.mem";
        // 仕入先コード
        private const int _SUPPLIERCD = 0;

        /// <summary>ログメッセージ：送信準備エラー</summary>
        private const string LOGMSG_ERROR = "送信準備エラー";

        /// <summary>ログメッセージ：フォルダー不存在</summary>
        private const string LOGMSG_FOLDERERROR = "指定されたフォルダが存在しません";

        // 一日(millisecond)
        private const int _INTERVAL = 86400000;

        // ADD BY wujun K2013/07/29--------->>>>>>>>>>
        // 一分
        private const int _INTERVALMin = 60000;

        // 自動送信処理フラグ
        private bool autoRunFlg = false;
        // ADD BY wujun K2013/07/29---------<<<<<<<<<

        // 接続先情報設定
        private ConnectInfoWork _connectInfoWork = null;
        // 端末設定
        private PosTerminalMg _posTerminalMg = null;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 送信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信データフォームクラス デフォルトコンストラクタ</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        public PMSAE04020UA()
        {
            // 初期化処理
            InitializeComponent();
            // ログイン企業コード
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // バッチ起動時間
            //_batchStartDate = DateTime.Now; // DEL BY wujun K2013/07/29

            // 売上データテキスト出力 アクセスクラス初期化
            _salesHistoryAcs = new SalesHistoryAcs();
            // 接続先アクセスクラス
            _connectInfoWorkAcs = new ConnectInfoWorkAcs();
            _formattedTextWriter = new FormattedTextWriter();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 接続先情報設定取得
        /// </summary>
        /// <returns>接続先情報</returns>
        /// <remarks>
        /// <br>Note		: 接続先情報設定取得を行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private ConnectInfoWork Read()
        {
            ConnectInfoWork connectInfoWork = null;
            //_connectInfoWorkAcs.Read(out connectInfoWork, this._enterpriseCode, _SUPPLIERCD); // DEL BY wujun K2013/07/29
            // ADD BY wujun K2013/07/29--------->>>>>>>>>>
            int status = _connectInfoWorkAcs.Read(out connectInfoWork, this._enterpriseCode, _SUPPLIERCD);
            if (connectInfoWork != null && connectInfoWork.LogicalDeleteCode == 0 &&
                status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
            return connectInfoWork;
        }
            else 
            {
                return null;
            }
            // ADD BY wujun K2013/07/29---------<<<<<<<<<<
            //return connectInfoWork; // DEL BY wujun K2013/07/29
        }

        /// <summary>
        /// 接続先情報設定
        /// </summary>
        /// <param name="connectInfoWork">接続先情報</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: 接続先情報設定を行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private int Write(ref ConnectInfoWork connectInfoWork)
        {
            int status = 0;
            status = _connectInfoWorkAcs.Write(ref connectInfoWork);
            return status;
        }

        /// <summary>
        /// 接続先マスタから検索パラメーター作成
        /// </summary>
        /// <remarks>
        /// <br>Note		: 接続先マスタから検索パラメーター作成を行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private SalesHistoryCndtn MakeSalesHistoryCndtn(ConnectInfoWork connectInfoWork)
        {
            SalesHistoryCndtn retSalesHistoryCndtn = new SalesHistoryCndtn();
            //企業コード
            retSalesHistoryCndtn.EnterpriseCode = this._enterpriseCode;

            // ADD BY wujun K2013/07/29--------->>>>>>>>>>
            // バッチ起動日付
            DateTime _batchStartDate = DateTime.Now;
            // ADD BY wujun K2013/07/29---------<<<<<<<<<

            if (0 == connectInfoWork.CnectSendDiv)
            {
                retSalesHistoryCndtn.PdfOutDiv = 2;
            }
            else if (1 == connectInfoWork.CnectSendDiv)
            {
                retSalesHistoryCndtn.PdfOutDiv = 0;
            }
            // 送信対象が「当日まで」の場合
            if (0 == connectInfoWork.CnectObjectDiv)
            {
                // 検索開始日付
                retSalesHistoryCndtn.AddUpADateSt = DateTimeToInt(_batchStartDate.AddDays(-45));
                // 検索終了日付
                retSalesHistoryCndtn.AddUpADateEd = DateTimeToInt(_batchStartDate);
            }
            else
            {
                // 検索開始日付
                retSalesHistoryCndtn.AddUpADateSt = DateTimeToInt(_batchStartDate.AddDays(-46));
                // 検索終了日付
                retSalesHistoryCndtn.AddUpADateEd = DateTimeToInt(_batchStartDate.AddDays(-1));
            }
            retSalesHistoryCndtn.SendDataDiv = 1; // 送信区分(0:手動;1:自動)

            return retSalesHistoryCndtn;
        }

        /// <summary>
        /// 時間フォマット変更
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: 時間フォマット変更を行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private int DateTimeToInt(DateTime dt)
        {
            return dt.Year * 10000 + dt.Month * 100 + dt.Day;
        }

        /// <summary>
        /// 送信データファイル作成
        /// </summary>
        /// <param name="connectInfoWork">接続先情報</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: 時送信データファイル作成を行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private void MakeOutFileNameFromXmlFile(ConnectInfoWork connectInfoWork)
        {
            string workDir;
            // ﾚｼﾞｽﾄﾘｷｰ取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            if (null == key)
            {
                workDir = @"C:\SFNETASM";
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\SFNETASM").ToString();
            }
            _fileName = string.Empty;

            _fileName = GetFolderPath(workDir, connectInfoWork);
        }

        /// <summary>
        /// ファイルパス作成
        /// </summary>
        /// <param name="workDir">フォルダ</param>
        /// <param name="connectInfoWork">抽出条件クラス</param>
        /// <returns>パス</returns>
        /// <remarks>
        /// <br>Note		: ファイルパスを行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private string GetFolderPath(string workDir, ConnectInfoWork connectInfoWork)
        {
            string path = string.Empty;
            string filePath = string.Empty;
            XmlDocument xmldoc = new XmlDocument();

            path = workDir + "\\" + Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, _XMLMEMOFILEPATH);
            if (File.Exists(path))
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(path);
                XmlNodeList xmlElems = xmldoc.DocumentElement.SelectSingleNode("//UiMemInputDataForm/UiMemInputDatas").ChildNodes;
                for (int i = 0; i < xmlElems.Count; i++)
                {
                    XmlElement xmlem = (XmlElement)xmlElems[i];
                    if (!"tEdit_FileName".Equals(xmlem["TargetName"].InnerText))
                    {
                        continue;
                    }
                    else
                    {
                        filePath = xmlem["InputData"].InnerText;
                        break;
                    }
                }
                if (!string.Empty.Equals(filePath))
                {
                    try
                    {
                        if (Directory.Exists(Path.GetDirectoryName(filePath)))
                        {
                            if (Path.GetDirectoryName(filePath).EndsWith("\\"))
                            {
                                filePath = Path.GetDirectoryName(filePath)
                                       + connectInfoWork.CnectFileId.Trim()
                                       + DateTime.Now.ToString("yyyyMMddHHmm") + ".TXT";
                            }
                            else
                            {
                                filePath = Path.GetDirectoryName(filePath)
                                       + "\\" + connectInfoWork.CnectFileId.Trim()
                                       + DateTime.Now.ToString("yyyyMMddHHmm") + ".TXT";
                            }
                            return filePath;
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                }
            }
            
            filePath = workDir + "\\" 
                       + Path.Combine(ConstantManagement_ClientDirectory.PRTOUT
                       , connectInfoWork.CnectFileId.Trim() + DateTime.Now.ToString("yyyyMMddHHmm") + ".TXT");

            return filePath;
        }

        /// <summary>
        /// FormattedTextWriterクラス設定処理FormattedTextWriterクラス条件)
        /// </summary>
        /// <remarks>
        /// <br>Note		: FormattedTextWriterクラス条件へ設定する。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private void SetFormattedTextWriter()
        {
            List<string> schemeList = new List<string>();
            schemeList.Add(PMSAE02014EA.ct_Col_SalesSlipNum);
            schemeList.Add(PMSAE02014EA.ct_Col_RequestDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd);
            schemeList.Add(PMSAE02014EA.ct_Col_AddUpADate);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompCd);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompRate);
            schemeList.Add(PMSAE02014EA.ct_Col_AbSalesRate);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesRowNo);
            schemeList.Add(PMSAE02014EA.ct_Col_AdministrationNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNameKana);
            schemeList.Add(PMSAE02014EA.ct_Col_AbGoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_ShipmentCnt);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_ShopMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_PriceMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode);
            schemeList.Add(PMSAE02014EA.ct_Col_AreaCd);
            schemeList.Add(PMSAE02014EA.ct_Col_SearchSlipDate);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierCd);
            schemeList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd);
            schemeList.Add(PMSAE02014EA.ct_Col_OrderNum);
            schemeList.Add(PMSAE02014EA.ct_Col_Filler);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesSlipNum, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_RequestDiv, 3);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddUpADate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodDiv, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbSalesRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesRowNo, 2);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AdministrationNo, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNo, 16);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNameKana, 20);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbGoodsNo, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShipmentCnt, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShopMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_PriceMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AreaCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SearchSlipDate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierCd, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_OrderNum, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_Filler, 1);

            _formattedTextWriter.DataSource = this._salesHistoryAcs.SalesHistoryDt;
            _formattedTextWriter.DataMember = String.Empty;
            _formattedTextWriter.OutputFileName = _fileName;
            //テキスト出力する項目名のリスト
            _formattedTextWriter.SchemeList = schemeList;
            _formattedTextWriter.Splitter = String.Empty;
            _formattedTextWriter.Encloser = String.Empty;
            _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            _formattedTextWriter.FormatList = null;
            _formattedTextWriter.CaptionOutput = false;
            _formattedTextWriter.FixedLength = true;
            _formattedTextWriter.ReplaceList = null;
            _formattedTextWriter.MaxLengthList = maxLengthList;
        }

        /// <summary>
        /// 自動送信XML生成
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note		: 自動送信XMLを生成する。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private int SaveNetSendSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            try
            {
                int rowsCount = this._salesHistoryAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // データ区分初期化
                XmlElement dtkbn = null;
                // TMY-ID分初期化
                XmlElement pmwscd = null;
                // 得意先ｺｰﾄﾞ初期化
                XmlElement kjcd = null;
                // 売上日付初期化
                XmlElement dndt = null;
                // 売上伝票番号初期化
                XmlElement dnno = null;
                // 売上行番号初期化
                XmlElement dngyno = null;
                // 商品番号初期化
                XmlElement pmncd = null;
                // 商品メーカーコード初期化
                XmlElement mkcd = null;
                // BL商品コード初期化
                XmlElement blcd = null;
                // 出荷数初期化
                XmlElement sksu = null;
                // 仕入先コード初期化
                XmlElement psicd = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // データ区分
                    dtkbn = xmldoc.CreateElement("DTKBN");
                    dtkbn.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["DataDiv"].ToString();
                    data.AppendChild(dtkbn);

                    // パーツマン端末コード
                    pmwscd = xmldoc.CreateElement("PMWSCD");
                    if (!String.IsNullOrEmpty(this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString()))
                    {
                        pmwscd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString();
                    }
                    data.AppendChild(pmwscd);

                    // 得意先ｺｰﾄﾞ
                    kjcd = xmldoc.CreateElement("KJCD");
                    kjcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["TxtCustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // 売上日付
                    dndt = xmldoc.CreateElement("DNDT");
                    dndt.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // 売上伝票番号
                    dnno = xmldoc.CreateElement("DNNO");
                    dnno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // 売上行番号
                    dngyno = xmldoc.CreateElement("DNGYNO");
                    dngyno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // 商品番号
                    pmncd = xmldoc.CreateElement("PHNCD");
                    pmncd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsNo"].ToString();
                    data.AppendChild(pmncd);

                    // 商品メーカーコード
                    mkcd = xmldoc.CreateElement("MKCD");
                    mkcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsMakerCd"].ToString();
                    data.AppendChild(mkcd);

                    // BL商品コード
                    blcd = xmldoc.CreateElement("BLCD");
                    if (this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"] == DBNull.Value || this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString() == "")
                    {
                        blcd.InnerText = "0000";
                    }
                    else
                    {
                        blcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString();
                    }
                    data.AppendChild(blcd);

                    // 出荷数
                    sksu = xmldoc.CreateElement("SKSU");
                    sksu.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // 仕入先コード
                    psicd = xmldoc.CreateElement("PSICD");
                    psicd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SupplierCd"].ToString();
                    data.AppendChild(psicd);

                    root.AppendChild(data);
                }

                //XML書き込み
                int index = _fileName.LastIndexOf(".");
                xmlFileName = _fileName.Substring(0, index) + ".XML";
                xmldoc.Save(xmlFileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// ファイルの削除処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : ファイルを削除します。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date	   : K2013/06/27</br>
        /// </remarks>
        private int DeleteFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList fileList = new ArrayList();

            try
            {
                // ファイルを削除
                FileInfo info = new FileInfo(_fileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date	   : K2013/06/27</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMSAE04020U",						// アセンブリＩＤまたはクラスＩＤ
                "",              					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// イベントLoad
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">インベントパラメーター</param>
        /// <remarks>
        /// <br>Note       : 計時Timer</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// <br>Update Note: wujun</br>
        /// <br>           : 端末未設定時、メッセージ出さずに常駐も起動しない</br>
        /// <br>Date       : K2013/07/11</br>
        /// </remarks>
        private void PMSAE04020UA_Load(object sender, EventArgs e)
        {
            // 接続先マスタ設定情報の取得
            this._connectInfoWork = this.Read();

            if (null == _connectInfoWork)
            {
                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "接続先マスタ設定情報の取得失敗", 0);  //DEL BY wujun  K2013/07/11
                this.Close();  //ADD BY wujun  K2013/07/11
                return;
            }

            // 端末設定の取得
            this.GetPosTerminalMg(out this._posTerminalMg, this._enterpriseCode);

            if (null == _posTerminalMg)
            {
                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "端末設定情報の取得失敗", 0);  //DEL BY wujun  K2013/07/11
                this.Close(); //ADD BY wujun  K2013/07/11
                return;
            }

            this.Visible = false;
            this.notifyIcon1.Visible = true;

            // 0：自動送信する && 自端末
            if (this._connectInfoWork.AutoSendDiv == 0 && this._posTerminalMg.MachineName.ToUpper().Trim() == this._connectInfoWork.SendMachineName.ToUpper().Trim())
            {
                string bootTime = this._connectInfoWork.BootTime.ToString().PadLeft(4,'0');
                // ADD BY wujun K2013/07/29--------->>>>>>>>>>
                int interval = getNextRunTime(bootTime);
                this.autoRunFlg = true;
                // ADD BY wujun K2013/07/29---------<<<<<<<<<<
                // DEL BY wujun K2013/07/29--------->>>>>>>>>>
                //int hours = 0;
                //int minitus = 0;
                //if (bootTime != "0")
                //{
                //    hours = Convert.ToInt16(bootTime.Substring(0, 2));
                //    minitus = Convert.ToInt16(bootTime.Substring(2, 2));
                //}
                //TimeSpan startTime = new TimeSpan(hours, minitus, 0);

                //int interval;
                //// 接続先マスタ設定の起動時間 >= Now
                //if (startTime.CompareTo(DateTime.Now.TimeOfDay) >= 0)
                //{
                //    interval = (int)(startTime.TotalMilliseconds - DateTime.Now.TimeOfDay.TotalMilliseconds);
                //}
                //else
                //{
                //    interval = (int)(_INTERVAL - ((DateTime.Now.TimeOfDay.TotalMilliseconds - startTime.TotalMilliseconds)) % _INTERVAL);
                //}
                // DEL BY wujun K2013/07/29---------<<<<<<<<<<

                // 起動頻度を設定
                timer1.Interval = interval;
                timer1.Enabled = true;
            }
            else
            {
                this.Close();
            }

        }

        // ADD BY wujun K2013/07/29--------->>>>>>>>>>
        /// <summary>
        /// Timerの次回起動時間算出
        /// </summary>
        /// <param name="bootTime">起動時間</param>
        /// <remarks>
        /// <br>Note       : 次回実行時間計算</br>
        /// <br>Programmer : wujun</br>
        /// <br>Date       : K2013/07/29</br>
        /// </remarks>
        private int getNextRunTime(String bootTime)
        {
            // システム時間取得
            double systemTime = DateTime.Now.TimeOfDay.TotalMilliseconds;

                int hours = 0;
                int minitus = 0;
                if (bootTime != "0")
                {
                    hours = Convert.ToInt16(bootTime.Substring(0, 2));
                    minitus = Convert.ToInt16(bootTime.Substring(2, 2));
                }
            double startTime = new TimeSpan(hours, minitus, 0).TotalMilliseconds;

                int interval;
                // 接続先マスタ設定の起動時間 >= Now
            if (startTime.CompareTo(systemTime) >= 0)
                {
                interval = (int)(startTime - systemTime);
                }
                else
                {
                interval = (int)(_INTERVAL - ((systemTime - startTime)) % _INTERVAL);
            }

            return interval;
        }
        // ADD BY wujun K2013/07/29---------<<<<<<<<<<

        /// <summary>
        /// 計時Timer
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">インベントパラメーター</param>
        /// <remarks>
        /// <br>Note       : 計時Timer</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                // 自動送信処理
                //this.SendDataAuto();　// DEL BY wujun K2013/07/29

                // ADD BY wujun K2013/07/29--------->>>>>>>>>>
                //起動起フラグ判断
                if (this.autoRunFlg)
                {
                    // 自動送信処理
                this.SendDataAuto();
                    this.autoRunFlg = false;
                    // 一分後に接続先マスタの起動時間再取得
                    timer1.Interval = _INTERVALMin;
                }
                else
                {
                    // 接続先マスタ設定情報の取得
                    this._connectInfoWork = this.Read();
                    if (null == _connectInfoWork)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "接続先情報設定マスタが登録されていません。", 0);
                        this.Close();
                        return;
                    }
                    string bootTime = this._connectInfoWork.BootTime.ToString().PadLeft(4, '0');

                    int interval = getNextRunTime(bootTime);
                    this.autoRunFlg = true;
                    timer1.Interval = interval;

                }
                // ADD BY wujun K2013/07/29---------<<<<<<<<<
                timer1.Enabled = true;
            }
            // 一日に一回
            //timer1.Interval = _INTERVAL;　// DEL BY wujun K2013/07/29
        }

        /// <summary>
        /// 送信ログの表示
        /// </summary>
        //private void ShowLog() // DEL 田建委 K2013/08/07 Redmine#39695
        private void ShowLog(int status) // ADD 田建委 K2013/08/07 Redmine#39695
        {
            PMSAE04010UA dialogForm = new PMSAE04010UA();
            //dialogForm.ShowDialog(1 // DEL 田建委 K2013/08/07 Redmine#39695
            dialogForm.ShowDialog(status // ADD 田建委 K2013/08/07 Redmine#39695
                                       , DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0')
                                       , 0
                                       , 0
                                       , 0
                                       , "");
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 自動送信処理を行う。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自動送信処理を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// <br>UpdateNote : 2013/08/12 田建委</br>
        /// <br>           : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
        /// </remarks>
        public void SendDataAuto()
        {
            int status = -1;
            string errMsg = "";

            int logStatus = 0;
            SAndESalSndLogListResultWork sAndESalSndLogWork = null;

            // テキストファイル名 
            MakeOutFileNameFromXmlFile(this._connectInfoWork);

            // 抽出条件クラス作成
            SalesHistoryCndtn salesHistoryCndtn = MakeSalesHistoryCndtn(this._connectInfoWork);

            try
            {
                //データ抽出処理
                status = this._salesHistoryAcs.SearchSalesHistoryProcMain(salesHistoryCndtn, out errMsg);
            }
            catch (Exception)
            {
                //ShowLog(); // DEL 田建委 K2013/08/07 Redmine#39695
                ShowLog(1); // ADD 田建委 K2013/08/07 Redmine#39695
                return; // ADD 田建委 K2013/08/07 Redmine#39695
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                //ShowLog(); // DEL 田建委 K2013/08/07 Redmine#39695
                //----- ADD 田建委 K2013/08/07 Redmine#39695 ---------->>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    ShowLog(2); // データ無しの場合、送信結果画面で送信結果：送信対象なし
                }
                else
                {
                    ShowLog(1);
                }
                //----- ADD 田建委 K2013/08/07 Redmine#39695 ----------<<<<<
                return;
            }
            //テキスト出力処理
            try
            {
                if (string.Empty.Equals(_fileName))
                {
                    this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, -1, LOGMSG_FOLDERERROR);
                    //ShowLog(); // DEL 田建委 K2013/08/07 Redmine#39695
                    ShowLog(1); // ADD 田建委 K2013/08/07 Redmine#39695
                    return;
                }
                int totalCount = 0;

                //FormattedTextWriterクラスのプロパティ
                SetFormattedTextWriter();

                status = _formattedTextWriter.TextOut(out totalCount);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = -1;
                this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logStatus = this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                //ShowLog(); // DEL 田建委 K2013/08/07 Redmine#39695
                ShowLog(1); // ADD 田建委 K2013/08/07 Redmine#39695
                return;
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                //logStatus = this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR); // DEL 田建委 K2013/08/12 Redmine#39695
                logStatus = this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, -1, LOGMSG_ERROR); // ADD 田建委 K2013/08/12 Redmine#39695
                //ShowLog(); // DEL 田建委 K2013/08/07 Redmine#39695
                ShowLog(1); // ADD 田建委 K2013/08/07 Redmine#39695
                return;
            }

            status = SaveNetSendSetting();
            if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = this._salesHistoryAcs.SendAndReceive(ref salesHistoryCndtn, _fileName, out sAndESalSndLogWork, out logStatus);
            }
            

            //S&E売上抽出データ更新処理
            try
            {
                if (status == 0)
                {
                    //データ抽出処理
                    status = this._salesHistoryAcs.Write(out errMsg);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // ファイル削除
                        status = this.DeleteFile();
                    }
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                // 送信結果画面表示
                string time = sAndESalSndLogWork.SendDateTimeEnd.ToString();
                string endTime = string.Empty;
                if (!time.Equals("0"))
                {
                    endTime = time.Substring(8, 2) + ":" + time.Substring(10, 2);
                }
                else
                {
                    endTime = string.Empty;
                }
                PMSAE04010UA dialogForm = new PMSAE04010UA();
                dialogForm.ShowDialog(sAndESalSndLogWork.SendResults
                                           , endTime
                                           , sAndESalSndLogWork.SendSlipCount
                                           , sAndESalSndLogWork.SendSlipDtlCnt
                                           , sAndESalSndLogWork.SendSlipTotalMny
                                           , sAndESalSndLogWork.SendErrorContents);
            }

            return;
        }
        #endregion

        # region [端末設定取得]
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 端末設定取得処理を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion
    }
}