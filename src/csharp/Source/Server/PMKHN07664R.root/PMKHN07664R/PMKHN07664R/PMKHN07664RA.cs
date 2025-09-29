//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ（インポート）
// プログラム概要   : 商品管理情報マスタ（インポート）DBリモートオブジェクト
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
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/25  修正内容 : 障害一覧の指摘NO.106の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 :李亜博
// 修 正 日  2012/07/26  修正内容 :大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.94の対応 エラーメッセージの変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/09/24　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。                             
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品管理情報マスタ（インポート）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理情報マスタ（インポート）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/26 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.94の対応 エラーメッセージの変更の対応</br>
    /// <br>Update Note: 2012/09/24 李亜博</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
    /// </remarks>
    [Serializable]
    public class GoodsMngImportDB : RemoteDB, IGoodsMngImportDB
    {
        /// <summary>
        /// 商品管理情報マスタ（インポート）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// </remarks>
        public GoodsMngImportDB()
            : base("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "GOODSMNGRF")
        {
        }
        /* --- DEL 2012/07/03 張曼 ----- >>>>>
        #region ■ Private Member
        // テーブル名称
        private const string PRINTSET_TABLE = "GoodsMngExp";
        // 拠点コード
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // 商品番号
        private const string GOODSNO_COLUMN = "GoodsNoRF";
        // 商品メーカーコード
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        // 仕入先コード
        private const string SUPPLIERCD_COLUMN = "SupplierCdRF";
        // 発注ロット
        private const string SUPPLIERLOT_COLUMN = "SupplierLotRF";
        //エラーメッセージ
        private const string GOODS_ERROR = "GoodsErrorRF";

        #endregion
           --- DEL 2012/07/03 張曼 ----- <<<<<*/

        # region [Import]
        /// <summary>
        /// 商品管理情報マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="checkKbn">チェック区分</param>
        /// <param name="importGoodsWorkList">商品管理情報マスタインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataList">エラーテーブル用</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/07/13 張曼</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// </remarks>
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt,out Int32 errCnt, out DataTable dataTable, out string errMsg) // DEL 2012/07/03 張曼
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out ArrayList dataList, out string errMsg)   // ADD 2012/07/03 張曼 // ---DEL 2012/07/13 張曼
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataList, out string errMsg)   // ---ADD 2012/07/13 張曼  // DEL 2012/07/19 姚学剛
        public int Import(Int32 processKbn, Int32 checkKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataList, out string errMsg)   // ADD 2012/07/19 姚学剛
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;
            //dataTable = null;// DEL 2012/07/03 張曼
            dataList = null;   // ADD 2012/07/03 張曼

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // インポート処理
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataTable, out errMsg, ref sqlConnection, ref sqlTransaction);// DEL 2012/07/03 張曼
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataList, out errMsg, ref sqlConnection, ref sqlTransaction);   // ADD 2012/07/03 張曼   // DEL 2012/07/19 姚学剛
                status = this.ImportProc(processKbn, checkKbn, ref importGoodsWorkList, out readCnt, out addCnt, out updCnt, out errCnt, out dataList, out errMsg, ref sqlConnection, ref sqlTransaction);    // ADD 2012/07/19 姚学剛
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 商品管理情報マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="checkKbn">チェック区分</param>
        /// <param name="importGoodsWorkList">商品管理情報マスタインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataObjectList">エラーテーブル用</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">コレクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/07/13 張曼</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// <br>Update Note: 2012/09/24 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
        /// </remarks>
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out DataTable dataTable, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) // DEL 2012/07/03 張曼
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out ArrayList dataList, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)    // ADD 2012/07/03 張曼 // ---DEL 2012/07/13 張曼
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataObjectList, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)    // ---ADD 2012/07/13 張曼  //DEL 姚学剛 2012/07/19 
        private int ImportProc(Int32 processKbn, Int32 checkKbn, ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out object dataObjectList, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)    //ADD 姚学剛 2012/07/19 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            //dataTable = null;// DEL 2012/07/03 張曼
            //dataList = null;   // ADD 2012/07/03 張曼 // ---DEL 2012/07/13 張曼
            dataObjectList = null; // ---ADD 2012/07/13 張曼
            errMsg = string.Empty;

            ArrayList GoodsMngList = new ArrayList();
            GoodsMngWork paraGoodsMngWork = new GoodsMngWork();

            // 商品管理情報マスタのDBリモートクラス
            GoodsMngDB GoodsMngDB = new GoodsMngDB();

            string enterpriseCode = string.Empty;

            try
            {
                // パラメータの設定
                // 商品管理情報マスタのパラメータの設定
                ArrayList importGoodsWorkArray = importGoodsWorkList as ArrayList;
                if (importGoodsWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    enterpriseCode = ((ImportGoodsMngWork)importGoodsWorkArray[0]).EnterpriseCode;
                    paraGoodsMngWork.EnterpriseCode = enterpriseCode;
                }

                // 全件検索処理を行う
                // 全て商品管理情報マスタのデータの検索処理
                GoodsMngDB.SearchGoodsMngProc(out GoodsMngList, paraGoodsMngWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
                ArrayList secList = new ArrayList();
                // 全件検索結果をDictionaryに格納する
                // 商品管理情報マスタのDictionaryの作成
                Dictionary<string, GoodsMngWork> goodsMngDict = new Dictionary<string, GoodsMngWork>();
                foreach (GoodsMngWork work in GoodsMngList)
                {
                    // --- DEL 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                    //string key = work.EnterpriseCode + "-" + work.SectionCode.Trim() + "-"
                    //             + work.GoodsMGroup.ToString() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0')
                    //             + "-" + work.BLGoodsCode.ToString() + "-" + work.GoodsNo.Trim();
                    // --- DEL 李亜博 2012/09/24 for Redmine#32367----------<<<<<
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                    string key = work.EnterpriseCode + "-" + work.SectionCode.Trim() + "-"
                                 + work.GoodsMGroup.ToString().PadLeft(4, '0') + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0')
                                 + "-" + work.BLGoodsCode.ToString().PadLeft(5, '0') + "-" + work.GoodsNo.Trim();
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
                    goodsMngDict.Add(key, work);
                }

                // 追加と更新データの作成
                // 商品管理情報マスタの追加リスト
                ArrayList addGoodsMngList = new ArrayList();
                // 商品管理情報マスタの更新リスト
                ArrayList updGoodsMngList = new ArrayList();

                // 商品管理情報マスタのエラーtable 
                //dataList = new ArrayList();                 // ADD 2012/07/03 張曼 // ---DEL 2012/07/13 張曼
                ArrayList dataList = new ArrayList();         // ---ADD 2012/07/13 張曼
                //dataTable = new DataTable(PRINTSET_TABLE);// DEL 2012/07/03 張曼
                //CreateDataTable(ref dataTable);           // DEL 2012/07/03 張曼

                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
                // 商品管理情報マスタチェック
                ArrayList importCheckWorkList = importGoodsWorkList as ArrayList;
                List<ImportGoodsMngWork> lst = new List<ImportGoodsMngWork>();
                ImportGoodsMngWork[] GoodsMngArray = (ImportGoodsMngWork[])importCheckWorkList.ToArray(typeof(ImportGoodsMngWork));
                lst.AddRange(GoodsMngArray);
                // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<

                foreach (ImportGoodsMngWork importWork in importGoodsWorkArray)
                {
                    string sectionCd = "";
                    string goodsMk = "";
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367-->>>>>
                    string blGoodsCd = "";
                    string goodsMGroup = "";
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367--<<<<<
                    //拠点コード
                    if (!string.IsNullOrEmpty(importWork.SectionCode.Trim()))
                    {
                        sectionCd = importWork.SectionCode.Trim().PadLeft(2, '0');
                    }
                    else
                    {
                        sectionCd = importWork.SectionCode.Trim();
                    }
                    //メーカーコード
                    if (!string.IsNullOrEmpty(importWork.GoodsMakerCd.ToString().Trim()))
                    {
                        goodsMk = importWork.GoodsMakerCd.Trim().PadLeft(4, '0');
                    }
                    else
                    {
                        goodsMk = importWork.GoodsMakerCd.Trim();
                    }

                    // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                    //BL商品コード
                    if (!string.IsNullOrEmpty(importWork.BLGoodsCode.ToString().Trim()))
                    {
                        blGoodsCd = importWork.BLGoodsCode.Trim().PadLeft(5, '0');
                    }
                    else
                    {
                        blGoodsCd = importWork.BLGoodsCode.Trim();
                    }
                    //商品中分類コード
                    if (!string.IsNullOrEmpty(importWork.GoodsMGroup.ToString().Trim()))
                    {
                        goodsMGroup = importWork.GoodsMGroup.Trim().PadLeft(4, '0');
                    }
                    else
                    {
                        goodsMGroup = importWork.GoodsMGroup.Trim();
                    }

                    string key = importWork.EnterpriseCode + "-" + sectionCd + "-"
                                 + goodsMGroup + "-" + goodsMk + "-"
                                 + blGoodsCd + "-" + importWork.GoodsNo.Trim();
                    // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
                    // --- DEL 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                    //string key = importWork.EnterpriseCode + "-" + sectionCd + "-"
                    //             + importWork.GoodsMGroup.ToString() + "-" + goodsMk + "-"
                    //             + importWork.BLGoodsCode.ToString() + "-" + importWork.GoodsNo.Trim();
                    // --- DEL 李亜博 2012/09/24 for Redmine#32367----------<<<<<
                    if (!goodsMngDict.ContainsKey(key))
                    {
                        // レコードが存在しなければ、追加リストへ追加する。
                        addGoodsMngList.Add(ConvertToGoodsMngImportWork(importWork, null, false));
                    }
                    else
                    {
                        // レコードが存在すれば、更新リストへ追加する。
                        updGoodsMngList.Add(ConvertToGoodsMngImportWork(importWork, goodsMngDict[key], true));
                    }
                }

                // 読込件数
                readCnt = importGoodsWorkArray.Count;

                // コレクションとトランザクション
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                ArrayList addUpdList = new ArrayList();
                ArrayList addUpdWorkList = new ArrayList();

                // 処理区分が「追加」の場合
                if (processKbn == 1)
                {
                    if (addGoodsMngList != null && addGoodsMngList.Count > 0)
                    {
                        // レコードが存在しなければ、追加リストへ追加する。
                        //AddUpdListCheck(addGoodsMngList, out addUpdList, ref errCnt, ref dataTable);// DEL 2012/07/03 張曼
                        //AddUpdListCheck(addGoodsMngList, out addUpdList, ref errCnt, ref dataList);   // ADD 2012/07/03 張曼  // DEL 2012/07/19 姚学剛
                        AddUpdListCheck(addGoodsMngList, out addUpdList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 姚学剛
                        dataObjectList = dataList; // ---ADD 2012/07/13 張曼

                        WriteAddUpdListCheck(addUpdList, out addUpdWorkList);

                        // 商品管理情報マスタの登録処理
                        status = GoodsMngDB.WriteGoodsMngProc(ref addUpdWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addUpdList.Count;
                        }
                    }
                }
                // 処理区分が「更新」の場合
                else if (processKbn == 2)
                {
                    if (updGoodsMngList != null && updGoodsMngList.Count > 0)
                    {

                        // レコードが存在しなければ、更新リストへ追加する。
                        //AddUpdListCheck(updGoodsMngList, out addUpdList, ref errCnt, ref dataTable);// DEL 2012/07/03 張曼
                        //AddUpdListCheck(updGoodsMngList, out addUpdList, ref errCnt, ref dataList);   // ADD 2012/07/03 張曼  // DEL 2012/07/19 姚学剛
                        AddUpdListCheck(updGoodsMngList, out addUpdList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 姚学剛
                        dataObjectList = dataList; // ---ADD 2012/07/13 張曼
                        WriteAddUpdListCheck(addUpdList, out addUpdWorkList);

                        // 商品管理情報マスタの更新処理
                        status = GoodsMngDB.WriteGoodsMngProc(ref addUpdWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            updCnt = addUpdList.Count;
                        }
                    }
                }
                // 処理区分が「追加更新」の場合
                else
                {
                    // 登録更新リストの作成
                    ArrayList addUpdGoodsMngList = new ArrayList();
                    ArrayList addList = new ArrayList();
                    ArrayList updList = new ArrayList();

                    // 追加
                    if (addGoodsMngList != null && addGoodsMngList.Count > 0)
                    {
                        // レコードが存在しなければ、追加リストへ追加する。
                        //AddUpdListCheck(addGoodsMngList, out addList, ref errCnt, ref dataTable);// DEL 2012/07/03 張曼
                        //AddUpdListCheck(addGoodsMngList, out addList, ref errCnt, ref dataList);   // ADD 2012/07/03 張曼  // DEL 2012/07/19 姚学剛
                        AddUpdListCheck(addGoodsMngList, out addList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 姚学剛
                    }

                    if (addList.Count > 0)
                    {
                        addUpdGoodsMngList.AddRange(addList.GetRange(0, addList.Count));
                    }

                    // 更新
                    if (updGoodsMngList != null && updGoodsMngList.Count > 0)
                    {
                        // レコードが存在しなければ、更新リストへ追加する。
                        //AddUpdListCheck(updGoodsMngList, out updList, ref errCnt, ref dataTable);// DEL 2012/07/03 張曼
                        //AddUpdListCheck(updGoodsMngList, out updList, ref errCnt, ref dataList);   // ADD 2012/07/03 張曼  // DEL 2012/07/19 姚学剛
                        AddUpdListCheck(updGoodsMngList, out updList, ref errCnt, ref dataList, lst, checkKbn);  // ADD 2012/07/19 姚学剛
                    }
                    dataObjectList = dataList; // ---ADD 2012/07/13 張曼

                    if (updList.Count > 0)
                    {
                        addUpdGoodsMngList.AddRange(updList.GetRange(0, updList.Count));
                    }
                    if (addUpdGoodsMngList.Count > 0)
                    {
                        WriteAddUpdListCheck(addUpdGoodsMngList, out addUpdWorkList);

                        // 商品管理情報マスタの登録更新処理
                        status = GoodsMngDB.WriteGoodsMngProc(ref addUpdWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null)
                    {
                        readCnt = 0;
                        addCnt = 0;
                        updCnt = 0;
                        sqlTransaction.Rollback();
                    }
                }

            }
            catch (SqlException ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errCnt = 0;
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 商品管理情報マスタにDB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/09/24 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
        /// </remarks>
        private ImportGoodsMngWork ConvertToGoodsMngImportWork(ImportGoodsMngWork csvWork, GoodsMngWork searchWork, bool isUpdFlg)
        {
            ImportGoodsMngWork importWork = new ImportGoodsMngWork();
            if (isUpdFlg)
            {
                // 更新の場合
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // 論理削除区分
            }

            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // 企業コード
            importWork.SectionCode = csvWork.SectionCode;                           // 拠点コード
            //importWork.GoodsMGroup = 0;                                            // 商品中分類コード// DEL 2012/09/24 李亜博 for Redmine#32367 
            importWork.GoodsMGroup = csvWork.GoodsMGroup;                           // 商品中分類コード// ADD 2012/09/24 李亜博 for Redmine#32367 
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         // 商品メーカーコード
            //importWork.BLGoodsCode = 0;                                             // BL商品コード// DEL 2012/09/24 李亜博 for Redmine#32367 
            importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BL商品コード// ADD 2012/09/24 李亜博 for Redmine#32367 
            importWork.GoodsNo = csvWork.GoodsNo;                                   // 商品番号
            importWork.SupplierCd = csvWork.SupplierCd;                             // 仕入先コード
            importWork.SupplierLot = csvWork.SupplierLot;                           // 発注ロット

            return importWork;
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion

        # region チェック

        #region データ取込チェック
        //private bool ImportCheck(ImportGoodsMngWork importWork, out string msg)   // DEL 2012/07/19 姚学剛 
        private bool ImportCheck(ImportGoodsMngWork importWork, out string msg, List<ImportGoodsMngWork> lst, Int32 checkKbn)   // ADD 2012/07/19 姚学剛
        {
            // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
            msg = string.Empty;
            // エラーチェックあり
            if (checkKbn == 0)  
            {
            // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
                //拠点チェック
                if (!Check_IsNull("拠点", importWork.SectionCode.Trim(), out msg))
                    return false;
                else if (!Check_IntAndLen("拠点", importWork.SectionCode.Trim(), importWork.SectionCode.Trim().Length, out msg))
                    return false;
                else if (!Check_StrUnFixedLen("拠点", importWork.SectionCode.Trim(), 2, out msg))
                    return false;

                //品番チェック
                if (!string.IsNullOrEmpty(importWork.GoodsNo.Trim().Trim()))
                {
                    if (!Check_HalfEngNumFixedLength("品番", importWork.GoodsNo.Trim(), out msg))
                        return false;
                    else if (!Check_StrUnFixedLen("品番", importWork.GoodsNo.Trim(), 24, out msg))
                        return false;
                }

                //メーカーチェック
                if (!Check_IsNull("メーカー", importWork.GoodsMakerCd.Trim(), out msg) || !Check_IsN("メーカー", importWork.GoodsMakerCd.Trim(), out msg))
                    return false;
                else if (!Check_IntAndLen("メーカー", importWork.GoodsMakerCd.Trim(), importWork.GoodsMakerCd.Trim().Length, out msg))
                    return false;
                else if (!Check_StrUnFixedLen("メーカー", importWork.GoodsMakerCd.Trim(), 4, out msg))
                    return false;

                // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
                //BL商品コードチェック
                if (!Check_IsNull("BLコード", importWork.BLGoodsCode, out msg))
                    return false;
                else if (!Check_IntAndLen("BLコード", importWork.BLGoodsCode.Trim(), 5, out msg))
                    return false;

                //商品中分類コードチェック 
                if (!Check_IsNull("中分類", importWork.GoodsMGroup, out msg))
                    return false;
                else if (!Check_IntAndLen("中分類", importWork.GoodsMGroup.Trim(), 4, out msg))
                    return false;

                // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<

                //仕入先チェック
                if (!Check_IsNull("仕入先", importWork.SupplierCd.Trim(), out msg) || !Check_IsN("仕入先", importWork.SupplierCd.Trim(), out msg))
                    return false;
                else if (!Check_IntAndLen("仕入先", importWork.SupplierCd.Trim(), importWork.SupplierCd.Trim().Length, out msg))
                    return false;
                else if (!Check_StrUnFixedLen("仕入先", importWork.SupplierCd.Trim(), 6, out msg))
                    return false;

                //発注ロットチェック
                if (!string.IsNullOrEmpty(importWork.SupplierLot.Trim()))
                {
                    if (!Check_IntAndLen("発注ロット", importWork.SupplierLot.Trim(), importWork.SupplierLot.Trim().Length, out msg))
                        return false;
                    else if (!Check_StrUnFixedLen("発注ロット", importWork.SupplierLot.Trim(), 4, out msg))
                        return false;
                }
            }   // ADD 2012/07/19 姚学剛

            // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
            int countGoodU = lst.FindAll(delegate(ImportGoodsMngWork tmp)
                            {
                                //return (importWork.SectionCode == tmp.SectionCode && importWork.GoodsMakerCd == tmp.GoodsMakerCd && importWork.GoodsNo == tmp.GoodsNo);// DEL 2012/09/24 李亜博 for Redmine#32367 
                                return (importWork.SectionCode == tmp.SectionCode && importWork.GoodsMakerCd == tmp.GoodsMakerCd && importWork.GoodsNo == tmp.GoodsNo && importWork.BLGoodsCode == tmp.BLGoodsCode && importWork.GoodsMGroup == tmp.GoodsMGroup);// ADD 2012/09/24 李亜博 for Redmine#32367 
                            }).Count;
            if (countGoodU > 1)
            {
                msg = ERRMSG_DUPLICATE;
                return false;
            }
            // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<
            return true; 
        }
        #endregion

        # region メッセージ

        private const string FORMAT_ERRMSG_LEN = "{0}の桁数{1}桁以内で入力してください。";

        private const string FORMAT_ERRMSG_TYPE = "{0}は{1}入力のみ可能です。";

        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}を入力してください。";

        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
        //private const string ERRMSG_DUPLICATE = "重複データしているため登録できません。";   // DEL 2012/07/25 姚学剛 
        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<

        private const string ERRMSG_DUPLICATE = "重複データがあるため登録できません。";   // ADD 2012/07/25 姚学剛

        # endregion

        # region 処理

        /// <summary>
        /// 整数、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen"></param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns></returns>
        private bool Check_IntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))
            {
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数値");// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                return false;
            }
        }

        /// <summary>
        /// NULL判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        private bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 0判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        private bool Check_IsN(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (val.Trim() == "0")
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 長さを指定しないの文字列チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            if (val.Trim().Length > len)
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, len);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 半角英数字、符号のチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;

            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "半角英数字、符号");
                return false;
            }

        }
        // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="str">CSV項目配列</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/09/24</br>
        /// </remarks>
        private Int32 ConvertToInt32(string str)
        {
            Int32 retNum = 0;
            try
            {
                retNum = Convert.ToInt32(str);
            }
            catch
            {
                retNum = 0;
            }
            return retNum;
        }
        // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<


        /// <summary>
        /// 商品管理情報マスタの追加リスト該当のデータが存在するかチェックを行います。
        /// </summary>
        /// <param name="ImportAddUpdList">チェックリスト</param>
        /// <param name="addUpdList">追加リスト</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataList">エラーテーブル用</param>
        /// <param name="lst">商品管理情報マスタチェックリスト</param>
        /// <param name="checkKbn">チェック区分</param>
        /// <remarks>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// </remarks>
        //private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref DataTable dataTable)// DEL 2012/07/03 張曼
        //private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref ArrayList dataList)   // ADD 2012/07/03 張曼   // DEL 2012/07/19 姚学剛 
        private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref ArrayList dataList, List<ImportGoodsMngWork> lst, Int32 checkKbn)   // ADD 2012/07/19 姚学剛 
        {
            string message = string.Empty;
            addUpdList = new ArrayList();

            foreach (ImportGoodsMngWork addUpdwork in ImportAddUpdList)
            {
                //bool checkRes = ImportCheck(addUpdwork, out message);    // DEL 2012/07/19 姚学剛
                bool checkRes = ImportCheck(addUpdwork, out message, lst, checkKbn);    // ADD 2012/07/19 姚学剛

                if (!checkRes)
                {
                    //ConverToDataSetCustomerInf(addUpdwork, message, ref dataTable);// DEL 2012/07/03 張曼
                    ConverToDataSetCustomerInf(addUpdwork, message, ref dataList);   // ADD 2012/07/03 張曼 
                    errCnt++;
                }
                else
                {
                    addUpdList.Add(addUpdwork);
                }
            }
        }

        /// <summary>
        /// 商品管理情報マスタ伝値
        /// </summary>
        /// <param name="addUpdList">ImportGoodsMngWork</param>
        /// <param name="addUpdWorkList">GoodsMngWork</param>
        private void WriteAddUpdListCheck(ArrayList addUpdList, out ArrayList addUpdWorkList)
        {
            addUpdWorkList = new ArrayList();
            foreach (ImportGoodsMngWork importWork in addUpdList)
            {
                GoodsMngWork work = new GoodsMngWork();
                work.CreateDateTime = importWork.CreateDateTime;        // 作成日時プロパティ
                work.UpdateDateTime = importWork.UpdateDateTime;        // 更新日時プロパティ
                work.EnterpriseCode = importWork.EnterpriseCode;        // 企業コードプロパティ
                work.FileHeaderGuid = importWork.FileHeaderGuid;        // GUIDプロパティ
                work.UpdEmployeeCode = importWork.UpdEmployeeCode;      // 更新従業員コードプロパティ
                work.UpdAssemblyId1 = importWork.UpdAssemblyId1;        // 更新アセンブリID1プロパティ
                work.UpdAssemblyId2 = importWork.UpdAssemblyId2;        // 更新アセンブリID2プロパティ
                work.LogicalDeleteCode = importWork.LogicalDeleteCode;  // 論理削除区分プロパティ
                work.SectionCode = importWork.SectionCode.Trim().PadLeft(2, '0');         // 拠点コードプロパティ               
                //work.GoodsMGroup = importWork.GoodsMGroup;              // 商品中分類コードプロパティ// DEL 2012/09/24 李亜博 for Redmine#32367 
                work.GoodsMGroup = ConvertToInt32(importWork.GoodsMGroup);  // 商品中分類コードプロパティ // ADD 2012/09/24 李亜博 for Redmine#32367 
                work.GoodsMakerCd = Convert.ToInt32(importWork.GoodsMakerCd);// 商品メーカーコードプロパティ
                //work.BLGoodsCode = importWork.BLGoodsCode;              // BL商品コードプロパティ// DEL 2012/09/24 李亜博 for Redmine#32367 
                work.BLGoodsCode = ConvertToInt32(importWork.BLGoodsCode);  // BL商品コードプロパティ// ADD 2012/09/24 李亜博 for Redmine#32367 
                work.GoodsNo = importWork.GoodsNo;                      // 商品番号プロパティ
                work.SupplierCd = Convert.ToInt32(importWork.SupplierCd);// 仕入先コードプロパティ
                if (!string.IsNullOrEmpty(importWork.SupplierLot.Trim()))
                {
                    work.SupplierLot = Convert.ToInt32(importWork.SupplierLot);// 発注ロットプロパティ
                }
                else
                {
                    work.SupplierLot = 0;
                }
                work.GoodsMGroupName = importWork.GoodsMGroupName;      // 商品中分類名称プロパティ
                work.MakerName = importWork.MakerName;                  // メーカー名称プロパティ
                work.GoodsName = importWork.GoodsName;                  // 商品名称プロパティ
                work.BLGoodsFullName = importWork.BLGoodsFullName;      // BL商品コード名称（全角）プロパティ
                work.SupplierSnm = importWork.SupplierSnm;              // 仕入先略称プロパティ
                work.SectionGuideNm = importWork.SectionGuideNm;        // 拠点ガイド名称プロパティ
                addUpdWorkList.Add(work);
            }
        }
        # endregion

        #region エラーデータテーブル関する
        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsMng">商品管理データ</param>
        /// <param name="dataList">テープル結果</param>
        ///<param name="message">えらーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/09/24 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
        /// </remarks>
        // --- ADD 2012/07/03 張曼 ----->>>>>
        private void ConverToDataSetCustomerInf(ImportGoodsMngWork goodsMng, string message, ref ArrayList dataList)
        {

            ImportGoodsMngWork tempWork = new ImportGoodsMngWork();

            // 拠点コード
            tempWork.SectionCode = goodsMng.SectionCode;
            // 品番
            tempWork.GoodsNo = goodsMng.GoodsNo;
            // 商品メーカーコード
            tempWork.GoodsMakerCd = goodsMng.GoodsMakerCd;
            // --- ADD 李亜博 2012/09/24 for Redmine#32367---------->>>>>
            //BL商品コード
            tempWork.BLGoodsCode = goodsMng.BLGoodsCode;
            //商品中分類コード
            tempWork.GoodsMGroup = goodsMng.GoodsMGroup;
            // --- ADD 李亜博 2012/09/24 for Redmine#32367----------<<<<<
            // 仕入先コード
            tempWork.SupplierCd = goodsMng.SupplierCd;
            // 発注ロット
            tempWork.SupplierLot = goodsMng.SupplierLot;
            // エラーメッセージ
            tempWork.ErroLogMessage = message;
            dataList.Add(tempWork);
        }
        // --- ADD 2012/07/03 張曼 -----<<<<<

        /*DEL 2012/07/03 張曼 ----->>>>>
        private void ConverToDataSetCustomerInf(ImportGoodsMngWork goodsMng, string message, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            // 拠点コード
            dataRow[SECTIONCODE_COLUMN] = goodsMng.SectionCode;
            // 品番
            dataRow[GOODSNO_COLUMN] = goodsMng.GoodsNo.Trim();
            // 商品メーカーコード
            dataRow[GOODSMAKERCD_COLUMN] = goodsMng.GoodsMakerCd.ToString();
            // 仕入先コード
            dataRow[SUPPLIERCD_COLUMN] = goodsMng.SupplierCd.ToString();
            // 発注ロット
            dataRow[SUPPLIERLOT_COLUMN] = goodsMng.SupplierLot.ToString();
            // エラーメッセージ
            dataRow[GOODS_ERROR] = message;

            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                  //  拠点コード
            dataTable.Columns.Add(GOODSNO_COLUMN, typeof(string));                      //  商品番号
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  商品メーカーコード
            dataTable.Columns.Add(SUPPLIERCD_COLUMN, typeof(string));                   //  仕入先コード
            dataTable.Columns.Add(SUPPLIERLOT_COLUMN, typeof(string));                  //  発注ロット
            dataTable.Columns.Add(GOODS_ERROR, typeof(string));                         //  エラーメッセージ
        }
         --- DEL 2012/07/03 張曼 -----<<<<<*/

        # endregion

        # endregion
    }
}
