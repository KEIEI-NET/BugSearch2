//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 伝票番号引当処理
// プログラム概要   : 伝票番号引当処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/06/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2013/01/09  修正内容 : 2013/03/13配信分 Redmine #33989 担当者コード登録は不正の対応。
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 伝票番号引当処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : なし。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.06.01</br>
    /// </remarks>
    public class SlipNoAlwcInputAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private SlipNoAlwcInputAcs()
        {
            _slipNoAlwcData = new SlipNoAlwcData();
            _uOESupplierAcs = new UOESupplierAcs();
            _slipNoAlwcDataTable = new DataResult.SlipNoAlwcDataTable();
            _employeeDB = MediationEmployeeDB.GetEmployeeDB();
            _uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
            stc_Employee = null;

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public static SlipNoAlwcInputAcs GetInstance()
        {
            if (_slipNoAlwcInputAcs == null)
            {
                _slipNoAlwcInputAcs = new SlipNoAlwcInputAcs();
            }

            return _slipNoAlwcInputAcs;
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static SlipNoAlwcInputAcs _slipNoAlwcInputAcs = null;
        private SlipNoAlwcData _slipNoAlwcData = null;
        private ArrayList outUOESupplier = null;
        private UOESupplierAcs _uOESupplierAcs = null;
        private DataResult.SlipNoAlwcDataTable _slipNoAlwcDataTable = null;
        private IEmployeeDB _employeeDB = null;
        private Dictionary<string, string> employeeDic = new Dictionary<string,string>();
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs = null;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        private static Employee stc_Employee;
        #endregion

        // ===================================================================================== //
        // 属性
        // ===================================================================================== //
        # region ■Propertity

        /// <summary>
        /// UIデータ
        /// </summary>
        public SlipNoAlwcData SlipNoAlwcData
        {
            get { return this._slipNoAlwcData; }
        }

        /// <summary>
        /// データテープル
        /// </summary>
        public DataResult.SlipNoAlwcDataTable SlipNoAlwcDataTable
        {
            get { return this._slipNoAlwcDataTable; }
        }

        /// <summary>
        /// UOE発注先データ
        /// </summary>
        public ArrayList UOESupplierData
        {
            get { return this.outUOESupplier; }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods

        /// <summary>
        /// 検索データ初期インスタンス生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public void CreateSlipNoAlwcInitialData()
        {
            SlipNoAlwcData slipNoAlwcData = new SlipNoAlwcData();

            // 初期化処理
            slipNoAlwcData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            slipNoAlwcData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            slipNoAlwcData.SupplierCode = 0;
            // UOE発注先データ
            if (outUOESupplier.Count > 0)
            {
                UOESupplier uoeSupplier = (UOESupplier)outUOESupplier[0];
                slipNoAlwcData.UOESupplierCd = uoeSupplier.UOESupplierCd;
                slipNoAlwcData.UOESupplierName = uoeSupplier.UOESupplierName;
                slipNoAlwcData.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;
            }
            else
            {
                slipNoAlwcData.UOESupplierCd = 0;
                slipNoAlwcData.UOESupplierName = "";
                slipNoAlwcData.AnswerSaveFolder = "";
            }
            // しない
            slipNoAlwcData.PriceUpdateCode = 0;
            // しない
            slipNoAlwcData.StockDataCode = 0;

            this.CacheSlipNoAlwcData(slipNoAlwcData);
        }

        /// <summary>
        /// 検索データキャッシュ処理
        /// </summary>
        /// <param name="source">売上データインスタンス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public void CacheSlipNoAlwcData(SlipNoAlwcData source)
        {
            this._slipNoAlwcData = source.Clone();
        }

        /// <summary>
        /// 従業員マスタ読み
        /// </summary>
        public int ReadEmployeeData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            EmployeeWork paraEmployeeWork = new EmployeeWork();
            paraEmployeeWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            Object employeeList = null;

            status = _employeeDB.Search(out employeeList, paraEmployeeWork, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                employeeDic = new Dictionary<string, string>();
                ArrayList res = (ArrayList)employeeList;
                foreach (EmployeeWork employeeWork in res)
                {
                    employeeDic.Add(employeeWork.EmployeeCode, employeeWork.Name);
                }
            }

            return status;
        }

        /// <summary>
        /// 従業員取得
        /// </summary>
        /// <param name="employee">従業員コード</param>
        /// <returns>従業員名称</returns>
        public string GetEmployeeName(string employee)
        {
            string name = string.Empty;

            foreach (KeyValuePair<string, string> employeeData in employeeDic)
            {

                if (employeeData.Key.Trim().Equals(employee.PadLeft(4, '0')))
                {
                    name = employeeData.Value;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// UOE発注先検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">ログイン拠点</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode, string sectionCode, ref string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            outUOESupplier = new ArrayList();

            // 検索結果
            ArrayList uOESupplierList = new ArrayList();

            // ＵＯＥ発注先マスタを読み込み
            status = this._uOESupplierAcs.SearchAll(out uOESupplierList, enterpriseCode, sectionCode);

            // 正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                foreach (UOESupplier uOESupplier in uOESupplierList)
                {
                    if ("0502".Equals(uOESupplier.CommAssemblyId) && uOESupplier.LogicalDeleteCode == 0) 
                    {
                        outUOESupplier.Add(uOESupplier);
                    }
                }
            }
            else
            {
                msg = "ホンダＵＯＥ ＷＥＢ取得が失敗します。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="errorMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int SaveData(ref string errorMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 注文一覧ＣＳＶファイルの取得
            ArrayList csvFiles = new ArrayList();

            status = this.GetCSVFiles(out csvFiles, this._slipNoAlwcData.AnswerSaveFolder);

            // 正常場合
            if (status == 0)
            {
                // 処理対象のＣＳＶファイルが存在しない場合
                if (csvFiles.Count == 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                }

                foreach (FileInfo fileInfo in csvFiles)
                {
                    List<string[]> csvDataList;
                    // CSV情報取得処理
                    status = this.GetCSVData(out csvDataList, fileInfo.FullName);

                    // 取得正常場合
                    if (status == 0)
                    {
                        // CSV情報のフォーマットチェック
                        bool ret = this.CheckCSVFormat(csvDataList);

                        // フォーマットが正し場合
                        if (ret)
                        {
                            try
                            {
                                BuyOutLsthead buyOutLsthead = new BuyOutLsthead();

                                // CSV種別
                                buyOutLsthead.CsvKnd = 0;
                                // 企業コード
                                buyOutLsthead.EnterpriseCode = this._slipNoAlwcData.EnterpriseCode;
                                // 拠点コード
                                buyOutLsthead.SectionCode = this._slipNoAlwcData.SectionCode;
                                // 発注先コード
                                UOESupplier uoeSuppler = (UOESupplier)UOESupplierData[this._slipNoAlwcData.SupplierCode];
                                buyOutLsthead.UOESupplierCd = uoeSuppler.UOESupplierCd;
                                // 担当者コード
                                //buyOutLsthead.StockAgentCode = this._slipNoAlwcData.EmployeeCode;//DEL 2013/01/09 Redmine#33989 張曼
                                buyOutLsthead.StockAgentCode = this._slipNoAlwcData.EmployeeCode.PadLeft(4, '0');//ADD 2013/01/09 Redmine#33989 張曼

                                // 担当者名称
                                buyOutLsthead.StockAgentName = this._slipNoAlwcData.EmployeeName;
                                // 原価更新
                                buyOutLsthead.CostUpdtDiv = this._slipNoAlwcData.PriceUpdateCode;
                                // 仕入作成区分
                                buyOutLsthead.StcCreDiv = this._slipNoAlwcData.StockDataCode;
                                // ＣＳＶファイル名
                                buyOutLsthead.CsvName = fileInfo.Name;
                                // ＣＳＶファイルバス
                                buyOutLsthead.CsvFullPath = fileInfo.FullName;
                                // 更新結果
                                buyOutLsthead.UpdRsl = 9;

                                ArrayList buyOutDtlList = new ArrayList();
                                for (int i = 4; i < csvDataList.Count; i++)
                                {
                                    string[] data = csvDataList[i];

                                    BuyOutLstDtl buyOutLstDtl = new BuyOutLstDtl();

                                    // No
                                    if (!string.IsNullOrEmpty(data[0]))
                                    {
                                        buyOutLstDtl.No = Convert.ToInt32(data[0]);
                                    }
                                    // 注文月日
                                    if (!string.IsNullOrEmpty(data[1]))
                                    {
                                        buyOutLstDtl.OrderDate = Convert.ToDateTime(data[1]);
                                    }
                                    // お買上日
                                    if (!string.IsNullOrEmpty(data[2]))
                                    {
                                        buyOutLstDtl.BuyOutDate = Convert.ToDateTime(data[2]);
                                    }
                                    // 部番
                                    buyOutLstDtl.GoodsNo = data[3];
                                    // 品名
                                    buyOutLstDtl.GoodsName = data[4];
                                    // 数量
                                    if (!string.IsNullOrEmpty(data[5]))
                                    {
                                        buyOutLstDtl.ShipmentCnt = Convert.ToDouble(data[5]);
                                    }
                                    // 希望小売価格
                                    if (!string.IsNullOrEmpty(data[6]))
                                    {
                                        buyOutLstDtl.AnswerListPrice = Convert.ToDouble(data[6]);
                                    }
                                    // お買上単価
                                    if (!string.IsNullOrEmpty(data[7]))
                                    {
                                        buyOutLstDtl.BuyOutCost = Convert.ToDouble(data[7]);
                                    }
                                    // お買上額合計
                                    if (!string.IsNullOrEmpty(data[8]))
                                    {
                                        buyOutLstDtl.BuyOutTotalCost = Convert.ToDouble(data[8]);
                                    }
                                    // 伝票番号
                                    buyOutLstDtl.BuyOutSlipNo = data[9];
                                    // 注文伝票番号
                                    if (data[9].Length >= 6)
                                    {
                                        buyOutLstDtl.OrderSlipNo = data[9].Substring(0, 6);
                                    }
                                    else
                                    {
                                        buyOutLstDtl.OrderSlipNo = data[9];
                                    }
                                    // コメント
                                    buyOutLstDtl.Comment = data[10];

                                    buyOutDtlList.Add(buyOutLstDtl);
                                }

                                buyOutLsthead.LstDtl = buyOutDtlList;

                                // 更新処理
                                string msg = null;
                                List<BuyOutLsthead> buyOutLstheadList = new List<BuyOutLsthead>();
                                buyOutLstheadList.Add(buyOutLsthead);
                                status = this._uoeSndRcvCtlAcs.EpartsUoeWebBuyCtl(ref buyOutLstheadList, out msg);


                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    errorMsg = "ホンダUOE-WEB 伝票番号引当処理に失敗しました。";
                                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                else
                                {
                                    BuyOutLsthead resBuyOutLstHead = (BuyOutLsthead)buyOutLstheadList[0];
                                    if (resBuyOutLstHead.UpdRsl == -1)
                                    {
                                        errorMsg = "ホンダUOE-WEB 伝票番号引当処理に失敗しました。";
                                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                    }
                                    else if (resBuyOutLstHead.UpdRsl == 0)
                                    {
                                        // foreach (BuyOutLstDtl buyOutLstDtl in buyOutLsthead.LstDtl)
                                        foreach (BuyOutLstDtl buyOutLstDtl in resBuyOutLstHead.LstDtl)
                                        {
                                            // 画面表示
                                            DataResult.SlipNoAlwcRow row = this._slipNoAlwcDataTable.NewSlipNoAlwcRow();

                                            row.SupplierDate = buyOutLstDtl.BuyOutDate.Date.ToString().Substring(0, 10);
                                            row.OrderDate = buyOutLstDtl.OrderDate.Date.ToString().Substring(0, 10);
                                            row.OldSupplierSlipNo = buyOutLstDtl.OrderSlipNo;
                                            row.SupplierSlipNo = buyOutLstDtl.BuyOutSlipNo;
                                            row.GoodsNo = buyOutLstDtl.GoodsNo;
                                            row.GoodsName = buyOutLstDtl.GoodsName;
                                            row.UpdatePrice = buyOutLstDtl.OrderCost.ToString("N0");
                                            row.Price = buyOutLstDtl.BuyOutCost.ToString("N0");
                                            row.FilesName = buyOutLsthead.CsvName;
                                            if (buyOutLstDtl.UpdRsl == 1)
                                            {
                                                row.UpdateResult = "引当正常";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 2)
                                            {
                                                row.UpdateResult = "該当無";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 3)
                                            {
                                                row.UpdateResult = "明細不一致";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 9)
                                            {
                                                row.UpdateResult = "引当済";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 4)
                                            {
                                                row.UpdateResult = "締次更新処理済";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 5)
                                            {
                                                row.UpdateResult = "月次更新処理済";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 6)
                                            {
                                                row.UpdateResult = "仕入データ作成";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 7)
                                            {
                                                row.UpdateResult = "単価変更";
                                            }

                                            this._slipNoAlwcDataTable.AddSlipNoAlwcRow(row);
                                        }

                                        // ファイル削除
                                        this.DeleteCSVFile(fileInfo);
                                    }
                                }
                            }
                            catch
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            }
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
            }
            else
            {
                errorMsg = "ＣＳＶ取込処理に失敗しました。";
            }

            return status;
        }

        /// <summary>
        /// CSVファイルリスト取得処理
        /// </summary>
        /// <param name="csvFileList">CSVファイルリスト</param>
        /// <param name="filePath">ファイル名前</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : CSVファイルリストを取得処理する。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVFiles(out ArrayList csvFileList, string filePath)
        {
            int status = 0;

            csvFileList = new ArrayList();
            try
            {
                // フォルダ下のファイルを取り込
                string[] fileList = System.IO.Directory.GetFiles(filePath, "*.csv");

                foreach (string file in fileList)
                {
                    //CSVFileInfo cSVFileInfo = new CSVFileInfo();
                    FileInfo info = new FileInfo(file);
                    csvFileList.Add(info);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// CSV情報取得処理
        /// </summary>
        /// <param name="csvDataList">CSV情報</param>
        /// <param name="filePathName">ファイル名前</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVData(out List<string[]> csvDataList, string filePathName)
        {
            int status = 0;

            // CSV情報
            csvDataList = new List<string[]>();
            try
            {
                FileStream fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                Stream stream = new MemoryStream(bytes);

                TextFieldParser parser = new TextFieldParser(stream, System.Text.Encoding.GetEncoding("Shift_JIS"));
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // 区切り文字はコンマ
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1行読み込み
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// CSV情報のフォーマットチェック
        /// </summary>
        /// <param name="csvDataList">CSV情報</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private bool CheckCSVFormat(List<string[]> csvDataList)
        {

            if (csvDataList.Count < 5)
            {
                return false;
            }

            // 1行目
            string[] autoInfo1 = csvDataList[0];
            if (!autoInfo1[0].Contains("ダウンロード成功"))
            {
                return false;
            }

            // 2行目
            string[] autoInfo2 = csvDataList[1];
            if (!(autoInfo2[0].Equals("検索日付") && autoInfo2[1].Equals("日付検索")))
            {
                return false;
            }

            // 4行目
            string[] autoInfo4 = csvDataList[3];
            if (!(autoInfo4[0].Equals("NO") && autoInfo4[1].Equals("注文月日")
                && autoInfo4[2].Equals("お買上日") && autoInfo4[3].Equals("部番")
                && autoInfo4[4].Equals("品名")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// お買上ＣＳＶファイルの削除処理
        /// </summary>
        /// <param name="fileInfo">CSV情報</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : お買上ＣＳＶファイルを削除します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        private int DeleteCSVFile(FileInfo fileInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // ファイルを削除
                fileInfo.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
    }
}
