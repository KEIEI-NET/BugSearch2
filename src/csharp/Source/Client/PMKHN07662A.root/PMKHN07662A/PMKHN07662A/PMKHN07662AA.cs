//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ（インポート）
// プログラム概要   : 商品管理情報マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/06/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2012/07/03  修正内容 : お客様の指摘の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2012/07/13  修正内容 : お客様の指摘の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/19  修正内容 : 障害一覧の指摘NO.110の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/09/24　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応                             
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品管理情報マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理情報マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br>Update Note: 2012/07/03 張曼 </br>
    /// <br>           : 10801804-00、大陽案件、お客様の指摘の対応</br>
    /// <br>Update Note: 2012/09/24 李亜博</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
    /// <br></br>
    /// </remarks>
    public class GoodsMngImportAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 商品管理情報マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public GoodsMngImportAcs()
        {
            this._iGoodsMngImportDB = (IGoodsMngImportDB)MediationGoodsMngImportDB.GetGoodsMngImportDB();
        }

        /// <summary>
        /// 商品管理情報マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        static GoodsMngImportAcs()
        {
        }
        #endregion ■ Constructor

        #region ■ Private Member
        // --- ADD 2012/07/03 張曼 ----- >>>>>
        // 拠点コード
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // 商品番号
        private const string GOODSNO_COLUMN = "GoodsNoRF";
        // 商品メーカーコード
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
        //BL商品コード
        private const string BLGOODSCODE_COLUMN = "BLGoodsCodeRF";
        //商品中分類コード
        private const string GOODSMGROUP_COLUMN = "GoodsMGrouptRF";
        // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
        // 仕入先コード
        private const string SUPPLIERCD_COLUMN = "SupplierCdRF";
        // 発注ロット
        private const string SUPPLIERLOT_COLUMN = "SupplierLotRF";
        //エラーメッセージ
        private const string GOODS_ERROR = "GoodsErrorRF";
        // --- ADD 2012/07/03 張曼 ----- <<<<<
        // テーブル名称
        private const string PRINTSET_TABLE = "GoodsMngExp";
        private const string ERROR_LOG_FILENAME = "PMKHN07660U_ERRORLOG.xml";

        // 商品管理情報マスタ（インポート）のリモートインタフェース
        private IGoodsMngImportDB _iGoodsMngImportDB;
        #endregion ■ Private Member

        #region ■ Public Method
        #region ◎ インポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public int Import(ExtrInfo_GoodsMngImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errCnt, out errMsg);
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ 商品管理情報マスタ（インポート）のインポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03 張曼 </br>
        /// <br>           : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/07/13 張曼</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_GoodsMngImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            object dataObjectList = null; // --- ADD 張曼 2012/07/13
            ArrayList dataList = new ArrayList();// --- ADD 張曼 2012/07/03
            DataTable dataTable = new DataTable(PRINTSET_TABLE);
            errMsg = string.Empty;

            try
            {
                ArrayList importGoodsMngWorkList = null;
                // 商品管理情報マスタのインポートワークの変換処理
                status = ConvertToGoodsMngImportWorkList(importWorkTbl, out importGoodsMngWorkList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    Object objGoodsMngImportWorkList = (object)importGoodsMngWorkList;
                    // リモートクラスを呼び出す。                    
                    //status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataTable, out errMsg);// ---DEL 2012/07/03 張曼
                    // ---ADD 2012/07/03 張曼 ----- >>>>>
                    //status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataList, out errMsg); // ---DEL 2012/07/13 張曼
                    // ---ADD 2012/07/13 張曼 ----- >>>>>
                    //status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataObjectList, out errMsg);  // DEL 2012/07/19 姚学剛 
                    status = this._iGoodsMngImportDB.Import(importWorkTbl.ProcessKbn, importWorkTbl.CheckKbn, ref objGoodsMngImportWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataObjectList, out errMsg);  // ADD 2012/07/19 姚学剛    
                    dataList = dataObjectList as ArrayList;
                    // ------------DEL 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                    // ---ADD 2012/07/13 張曼 ----- <<<<< 
                    //CreateDataTable(ref dataTable);
                    //ConverToDataSetCustomerInf(dataList, ref dataTable);
                    // ---ADD 2012/07/03 張曼 ----- <<<<< 
                    // ------------DEL 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
                    // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                    if (dataList != null && dataList.Count > 0)
                    {
                        CreateDataTable(ref dataTable);
                        ConverToDataSetCustomerInf(dataList, ref dataTable);
                    }
                    // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
                    if (dataTable.Rows.Count > 0)
                    {
                        errCnt = dataTable.Rows.Count;
                        this.DoOutPut(importWorkTbl.ErrorLogFileName, dataTable);
                    }
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region ◆ データ変換処理
        #region ◎ 商品管理情報マスタのインポートワークの変換処理
        /// <summary>
        /// 商品管理情報マスタのインポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタのインポートワークの変換処理を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/09/24 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
        /// </remarks>
        private int ConvertToGoodsMngImportWorkList(ExtrInfo_GoodsMngImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            ImportGoodsMngWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new ImportGoodsMngWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.SectionCode = ConvertToEmpty(csvDataArr, index++);             //拠点コード
                    work.GoodsNo = ConvertToEmpty(csvDataArr, index++);                 //商品番号
                    work.GoodsMakerCd = ConvertToEmpty(csvDataArr, index++);            //商品メーカーコード
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                    work.BLGoodsCode = ConvertToEmpty(csvDataArr, index++);             // BL商品コード
                    work.GoodsMGroup = ConvertToEmpty(csvDataArr, index++);             // 商品中分類コード
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
                    work.SupplierCd = ConvertToEmpty(csvDataArr, index++);              //仕入先コード
                    work.SupplierLot = ConvertToEmpty(csvDataArr, index++);             //発注ロット
                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region ◎ 空白項目へ変換処理
        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion
        #endregion

        #region ◎ CSV出力処理
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="errorLogFileName">エラーログファイル名プロパティ</param>
        /// <param name="table">データテーブル</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : 張曼　　　　　　　</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName, DataTable table)
        {
            int status = 0;

            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.prpid = ERROR_LOG_FILENAME;
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            // 出力パスと名前
            customTextProviderInfo.OutPutFileName = errorLogFileName;

            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = false;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            // データソースを設定
            DataSet dsOutData = new DataSet();
            DataView dv = table.DefaultView;
            dsOutData.Tables.Add(dv.ToTable());

            try
            {
                status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = -1;
            }
            dsOutData.Tables.Clear();

            return status;
        }
        #endregion ■ Private Method

        // ---ADD 2012/07/03 張曼 ----- >>>>>
        #region エラーデータテーブル関する
        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/09/24 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (ImportGoodsMngWork goodsMng in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // 拠点コード
                dataRow[SECTIONCODE_COLUMN] = goodsMng.SectionCode;
                // 品番
                dataRow[GOODSNO_COLUMN] = goodsMng.GoodsNo.Trim();
                // 商品メーカーコード
                dataRow[GOODSMAKERCD_COLUMN] = goodsMng.GoodsMakerCd.ToString();
                // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                //BL商品コード
                dataRow[BLGOODSCODE_COLUMN] = goodsMng.BLGoodsCode;
                //商品中分類コード
                dataRow[GOODSMGROUP_COLUMN] = goodsMng.GoodsMGroup;
                // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
                // 仕入先コード
                dataRow[SUPPLIERCD_COLUMN] = goodsMng.SupplierCd.ToString();
                // 発注ロット
                dataRow[SUPPLIERLOT_COLUMN] = goodsMng.SupplierLot.ToString();
                // エラーメッセージ
                dataRow[GOODS_ERROR] = goodsMng.ErroLogMessage;

                dataTable.Rows.Add(dataRow);
            }
        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/09/24 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                  //  拠点コード
            dataTable.Columns.Add(GOODSNO_COLUMN, typeof(string));                      //  商品番号
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  商品メーカーコード
            // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
            dataTable.Columns.Add(BLGOODSCODE_COLUMN, typeof(string));                  //  BL商品コード
            dataTable.Columns.Add(GOODSMGROUP_COLUMN, typeof(string));                  //  商品中分類コード
            // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
            dataTable.Columns.Add(SUPPLIERCD_COLUMN, typeof(string));                   //  仕入先コード
            dataTable.Columns.Add(SUPPLIERLOT_COLUMN, typeof(string));                  //  発注ロット
            dataTable.Columns.Add(GOODS_ERROR, typeof(string));                         //  エラーメッセージ
        }
        #endregion
        // ---ADD 2012/07/03 張曼 ----- <<<<< 

        #endregion ■ Private Method
    }
}
