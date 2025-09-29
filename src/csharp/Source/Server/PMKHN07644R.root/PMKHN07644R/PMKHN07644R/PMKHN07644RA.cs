//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ（インポート）
// プログラム概要   : 得意先マスタ（インポート）DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  2010/01/21  作成担当 : 大矢 睦美
// 修 正 日              修正内容 : 請求書タイプ毎の出力区分追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当：李亜博
// 修 正 日  2012/06/12  修正内容：大陽案件、Redmine#30393 
//                                 得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/03  修正内容 ：大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/05  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.30の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/09  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.39、NO.46、NO.47、NO.48、NO.49、NO.51の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/11  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/13  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.7、NO.48、NO.94、NO.95の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/20  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.94、NO.106、NO.107、NO.108の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/24  修正内容 ：大陽案件、Redmine#30387
//                                  動作検証、障害一覧の指摘NO.61、NO.106の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：朱猛
// 修 正 日  2012/8/3    修正内容 ：メールアドレス種別コードのチェック桁数を１桁から２桁へ変更
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：wangl2
// 修 正 日  2013/03/25  修正内容 ：Redmine#35047  No.1841得意先インポートの対応
//----------------------------------------------------------------------------//
// 管理番号  11570183-00 作成担当 ：田村顕成
// 修 正 日  2022/03/04  修正内容 ：電子帳簿連携対応 ラベル項目の変更（DM出力→電子帳簿出力）
//----------------------------------------------------------------------------//
// 管理番号  11900025-00 作成担当 ：3H 仰亮亮
// 修 正 日  2023/06/28  修正内容 ：インポート不具合対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;// ADD  2012/06/12  李亜博 Redmine#30393
using Broadleaf.Library.Globarization;// ADD  2012/06/12  李亜博 Redmine#30393

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ（インポート）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（インポート）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br>Update Note: 2012/06/12 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
    /// <br>Update Note: 2012/07/03 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
    /// <br>Update Note: 2012/07/05 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.30の対応</br>
    /// <br>Update Note: 2012/07/09 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.39、NO.46、NO.47、NO.48、NO.49、NO.51の対応</br>
    /// <br>Update Note: 2012/07/11 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応</br>
    /// <br>Update Note: 2012/07/13 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.7、NO.48、NO.94、NO.95の対応</br>
    /// <br>Update Note: 2012/07/20 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.94、NO.106、NO.107、NO.108の対応</br>
    /// <br>Update Note: 2012/07/24 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  動作検証、障害一覧の指摘NO.61、NO.106の対応</br>
    /// <br>Update Note: 2013/03/25 wangl2</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             Redmine#35047  No.1841得意先インポートの対応</br>
    /// </remarks>
    [Serializable]
    public class CustomerImportDB : RemoteDB, ICustomerImportDB
    {
        /// <summary>
        /// 得意先マスタ（インポート）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public CustomerImportDB()
            : base("PMKHN07644R", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "CustomerRF")
        {
        }

        # region [Import]
        /// <summary>
        /// 得意先マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="checkDiv">チェック区分</param>
        /// <param name="consTaxLay">消費税転嫁方式</param>
        /// <param name="importWorkTable">インポートデータテーブル</param>// ADD  2012/06/12  李亜博 Redmine#30393
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="logCnt">ログ件数</param>// ADD  2012/06/12  李亜博 Redmine#30393
        /// <param name="logArrayList">ログリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        /// <param name="enterpriseCode">企業コード</param>// ADD  2012/06/12  李亜博 Redmine#30393
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2012/07/03 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7、NO.48、NO.94、NO.95の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
        // public int Import(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)// DEL  2012/06/12  李亜博 Redmine#30393
        // public int Import(Int32 processKbn, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out DataTable logTable, string enterpriseCode, out string errMsg)// ADD  2012/06/12  李亜博 Redmine#30393  // DEL  2012/07/03  李亜博 Redmine#30393
        //public int Import(Int32 processKbn, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
        //public int Import(Int32 processKbn, Int32 consTaxLay, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
        //public int Import(Int32 processKbn, Int32 consTaxLay, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        public int Import(Int32 processKbn,Int32 checkDiv, Int32 consTaxLay, ref object importWorkTable, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayList, string enterpriseCode, out string errMsg)// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            // ------- ADD START 2012/06/12 Redmine#30393 李亜博---->>>>
            logCnt = 0;
            //logTable = new DataTable();  // DEL  2012/07/03  李亜博 Redmine#30393
            //logArrayList = new ArrayList(); // ADD  2012/07/03  李亜博 Redmine#30393// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            // ------- ADD END 2012/06/12 Redmine#30393 李亜博---->>>>
            logArrayList = null; // ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            errMsg = string.Empty;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // インポート処理
                // status = this.ImportProc(processKbn, ref importWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction);// DEL  2012/06/12  李亜博 Redmine#30393
                //status = this.ImportProc(processKbn, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logTable, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction);// ADD  2012/06/12  李亜博 Redmine#30393  // DEL  2012/07/03  李亜博 Redmine#30393
                //status = this.ImportProc(processKbn, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logArrayList, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction);  // ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
                //status = this.ImportProc(processKbn, consTaxLay, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logArrayList, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction); // ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                status = this.ImportProc(processKbn,checkDiv ,consTaxLay, ref importWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logArrayList, enterpriseCode, out errMsg, ref sqlConnection, ref sqlTransaction);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
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
        // --------------- DEL START 2012/06/12 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// 得意先マスタ（インポート）のインポート処理。
        ///// </summary>
        ///// <param name="processKbn">処理区分</param>
        ///// <param name="importWorkList">インポートデータリスト</param>
        ///// <param name="readCnt">読込件数</param>
        ///// <param name="addCnt">追加件数</param>
        ///// <param name="updCnt">処理件数</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <param name="sqlConnection">コレクション</param>
        ///// <param name="sqlTransaction">トランザクション</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ（インポート）のインポート処理を行う</br>
        ///// <br>Programmer : 劉学智</br>
        ///// <br>Date       : 2009.05.15</br>
        //private int ImportProc(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    readCnt = 0;
        //    addCnt = 0;
        //    updCnt = 0;
        //    errMsg = string.Empty;

        //    // 得意先のDBリモートクラス
        //    CustomerDB customerDB = new CustomerDB();

        //    try
        //    {
        //        // 企業コード
        //        string enterpriseCode = null;
        //        // 得意先コード配列
        //        int[] customerCodeArray = null;
        //        // 得意先情報クラス配列
        //        CustomerWork[] customerWorkArray = null;
        //        // ステータス配列
        //        int[] statusArray = null;

        //        // 検索パラメータの設定
        //        ArrayList importWorkArray = importWorkList as ArrayList;
        //        if (importWorkArray == null)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //            return status;
        //        }
        //        else
        //        {
        //            customerCodeArray = new int[importWorkArray.Count];
        //            for (int i = 0; i < importWorkArray.Count; i++)
        //            {
        //                CustomerWork customerWork = (CustomerWork)importWorkArray[i];
        //                enterpriseCode = customerWork.EnterpriseCode;
        //                customerCodeArray[i] = customerWork.CustomerCode;
        //            }
        //        }

        //        // 全てデータの検索処理
        //        customerDB.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //        }

        //        // Dictionaryの作成
        //        Dictionary<CustomerImportWorkWrap, CustomerWork> dict = new Dictionary<CustomerImportWorkWrap, CustomerWork>();
        //        foreach (CustomerWork work in customerWorkArray)
        //        {
        //            // 存在するデータをDictionaryへ格納する（他インポートPGと処理方法が違います。）
        //            if (work.CreateDateTime != DateTime.MinValue)
        //            {
        //               CustomerImportWorkWrap warp = new CustomerImportWorkWrap(work);
        //                dict.Add(warp, work);
        //            }
        //        }

        //        // 追加リスト
        //        ArrayList addList = new ArrayList();
        //        // 更新リスト
        //        ArrayList updList = new ArrayList();

        //        foreach (CustomerWork importWork in importWorkArray)
        //        {
        //            CustomerImportWorkWrap importWarp = new CustomerImportWorkWrap(importWork);

        //            if (!dict.ContainsKey(importWarp))
        //            {
        //                if (importWarp.customerWork.CustomerCode != 0)
        //                {
        //                    // レコードが存在しなければ、追加リストへ追加する。
        //                    addList.Add(ConvertToImportWork(importWork, null, false));
        //                }
        //            }
        //            else
        //            {
        //                // レコードが存在すれば、更新リストへ追加する。
        //                updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
        //            }
        //        }

        //        // 読込件数
        //        readCnt = importWorkArray.Count;

        //        // 重複エラー時の重複項目
        //        ArrayList duplicationItemList = new ArrayList();

        //        // 処理区分が「追加」の場合
        //        if (processKbn == 1)
        //        {
        //            if (addList != null && addList.Count > 0)
        //            {
        //                Object objAddList = addList as object;
        //                // 登録処理
        //                status = customerDB.Write(ref objAddList, out duplicationItemList);
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    addCnt = addList.Count;
        //                }
        //            }
        //        }
        //        // 処理区分が「更新」の場合
        //        else if (processKbn == 2)
        //        {
        //            if (updList != null && updList.Count > 0)
        //            {
        //                Object objUpdList = updList as object;
        //                // 更新処理
        //                status = customerDB.Write(ref objUpdList, out duplicationItemList);
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    updCnt = updList.Count;
        //                }
        //            }
        //        }
        //        // 処理区分が「追加更新」の場合
        //        else
        //        {
        //            // 登録更新リストの作成
        //            ArrayList addUpdList = new ArrayList();
        //            if (addList.Count > 0)
        //            {
        //                addUpdList.AddRange(addList.GetRange(0, addList.Count));
        //            }
        //            if (updList.Count > 0)
        //            {
        //                addUpdList.AddRange(updList.GetRange(0, updList.Count));
        //            }
        //            if (addUpdList.Count > 0)
        //            {
        //                Object objAddUpdList = addUpdList as object;
        //                // 登録更新処理
        //                status = customerDB.Write(ref objAddUpdList, out duplicationItemList);
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    addCnt = addList.Count;
        //                    updCnt = updList.Count;
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        errMsg = ex.Message;
        //        base.WriteSQLErrorLog(ex, errMsg, ex.Number);
        //        // ロールバック
        //        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                sqlTransaction.Commit();
        //            }

        //            sqlTransaction.Dispose();
        //        }

        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // --------------- DEL END 2012/06/12 Redmine#30393 李亜博--------<<<<

        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// 得意先マスタ掛率グループの取得する。
        /// </summary>
        /// <param name="customerWork">インポートデータ</param>
        /// <param name="PureCode">純正区分</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="custRateGrpPure">得意先掛率グループ</param>
        /// <returns>csvCustRateGroupWork</returns>
        /// <br>Note       : 得意先マスタ掛率グループの取得する。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        private CustRateGroupWork GetcsvCustRateGroup(CustomerRateWork customerWork, int PureCode, int goodsMakerCd, int custRateGrpPure)
        {
            CustRateGroupWork csvCustRateGroupWork = new CustRateGroupWork();

            csvCustRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode;
            csvCustRateGroupWork.CustomerCode = customerWork.CustomerCode;
            csvCustRateGroupWork.PureCode = PureCode;
            csvCustRateGroupWork.GoodsMakerCd = goodsMakerCd;
            csvCustRateGroupWork.CustRateGrpCode = custRateGrpPure;

            return csvCustRateGroupWork;
        }


        /// <summary>
        /// 得意先マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="checkDiv">チェック区分</param>
        /// <param name="csvObj">インポートデータテーブル</param>
        /// <param name="consTaxLay">消費税転嫁方式</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="logCnt">ログ件数</param>
        /// <param name="logArrayListWork">ログリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">コレクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7、NO.48、NO.94、NO.95の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
        //private int ImportProc(Int32 processKbn, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out DataTable logTable, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/06/12  李亜博 Redmine#30393  // DEL  2012/07/03  李亜博 Redmine#30393
        //private int ImportProc(Int32 processKbn, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
        //private int ImportProc(Int32 processKbn, Int32 consTaxLay, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out ArrayList logArrayList, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
        //private int ImportProc(Int32 processKbn, Int32 consTaxLay, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayListWork, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        private int ImportProc(Int32 processKbn, Int32 checkDiv, Int32 consTaxLay, ref object csvObj, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out object logArrayListWork, string enterpriseCode, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            logCnt = 0;
            //logTable = new DataTable();  // DEL  2012/07/03  李亜博 Redmine#30393
            //logArrayList = new ArrayList();// ADD  2012/07/03  李亜博 Redmine#30393// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            ArrayList logArrayList = new ArrayList();// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            logArrayListWork = null;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            errMsg = string.Empty;

            // 得意先のDBリモートクラス
            CustomerDB customerDB = new CustomerDB();

            //得意先掛率グループのDBリモートクラス
            CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
            try
            {
                // 得意先コード配列
                int[] customerCodeArray = null;
                // 得意先情報クラス配列
                CustomerWork[] customerWorkArray = null;

                // ステータス配列
                int[] statusArray = null;

                //インポートデータテーブル
                //DataTable csvDataTable = csvObj as DataTable;  // DEL  2012/07/03  李亜博 Redmine#30393
                ArrayList csvArrayList = csvObj as ArrayList;  // ADD  2012/07/03  李亜博 Redmine#30393
                //string msg = null; // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                Dictionary<int, int> rightCustCdDic = new Dictionary<int, int>();
                //CreateDataTable( ref logTable);  // DEL  2012/07/03  李亜博 Redmine#30393
                //if (csvDataTable == null)// DEL  2012/07/03  李亜博 Redmine#30393
                if (csvArrayList == null)// ADD  2012/07/03  李亜博 Redmine#30393
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
                    //customerCodeArray = new int[csvDataTable.Rows.Count];
                    //for (int i = 0; i < csvDataTable.Rows.Count; i++)
                    //{
                    //    //得意先コード
                    //    string customerCd = csvDataTable.Rows[i][0].ToString();

                    //    if (!Check_IsNull("得意先コード", customerCd, out msg))
                    //    {
                    //        ConverToDataSetCustomerLog(csvDataTable.Rows[i], ref logTable, msg);
                    //        continue;
                    //    }

                    //    if (!Check_ZeroIntAndLen("得意先コード", customerCd, 8, out msg))
                    //    {
                    //        ConverToDataSetCustomerLog(csvDataTable.Rows[i], ref logTable, msg);
                    //        continue;
                    //    }

                    //    if (!rightCustCdDic.ContainsKey(Convert.ToInt32(csvDataTable.Rows[i][0])))
                    //    {
                    //        rightCustCdDic.Add(i, Convert.ToInt32(csvDataTable.Rows[i][0]));
                    //    }

                    //    customerCodeArray[i] = Convert.ToInt32(csvDataTable.Rows[i][0]);
                    //}
                    // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
                    // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
                    customerCodeArray = new int[csvArrayList.Count];



                    for (int i = 0; i < csvArrayList.Count; i++)
                    {
                        // ------ DEL START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                        //CustomerGroupWork customerGroupWork = (CustomerGroupWork)csvArrayList[i];
                        //if (!Check_IsNull("得意先コード", customerGroupWork.CustomerCode, out msg))
                        //{
                        //    customerGroupWork.ErrorLog = msg;
                        //    logArrayList.Add(customerGroupWork);
                        //    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                        //    continue;
                        //}

                        //if (!Check_ZeroIntAndLen("得意先コード", customerGroupWork.CustomerCode, 8, out msg))
                        //{
                        //    customerGroupWork.ErrorLog = msg;
                        //    logArrayList.Add(customerGroupWork);
                        //    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                        //    continue;
                        //}
                        //if (!rightCustCdDic.ContainsKey(Convert.ToInt32(customerGroupWork.CustomerCode)))
                        //{
                        //    rightCustCdDic.Add(i, Convert.ToInt32(customerGroupWork.CustomerCode));
                        //}
                        //customerCodeArray[i] = Convert.ToInt32(customerGroupWork.CustomerCode);
                        // ------ DEL END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<


                        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                        CustomerGroupWork customerGroupWork = (CustomerGroupWork)csvArrayList[i];
                        if (!rightCustCdDic.ContainsKey(i))
                        {
                            rightCustCdDic.Add(i, ConvertToInt32(customerGroupWork.CustomerCode.Trim()));
                        }
                        customerCodeArray[i] = ConvertToInt32(customerGroupWork.CustomerCode.Trim());

                        // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<

                    }
                    // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
                }

                // 全てデータの検索処理
                customerDB.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Dictionaryの作成
                Dictionary<int, CustomerWork> dict = new Dictionary<int, CustomerWork>();

                foreach (CustomerWork workArray in customerWorkArray)
                {
                    // 存在するデータをDictionaryへ格納する（他インポートPGと処理方法が違います。）
                    if (workArray.CreateDateTime != DateTime.MinValue && !dict.ContainsKey(workArray.CustomerCode))
                    {
                        dict.Add(workArray.CustomerCode, workArray);
                    }
                }
                // 追加リスト
                ArrayList addList = new ArrayList();
                // 更新リスト
                ArrayList updList = new ArrayList();
                // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
                //for (int index = 0; index < csvDataTable.Rows.Count; index++)
                //{
                //    if (!rightCustCdDic.ContainsKey(index))
                //    {
                //        continue;
                //    }
                //    if (!dict.ContainsKey(Convert.ToInt32(csvDataTable.Rows[index][0])))
                //    {
                //        if (Convert.ToInt32(csvDataTable.Rows[index][0]) != 0)
                //        {
                //            // レコードが存在しなければ、追加リストへ追加する。
                //            addList.Add(index);
                //        }
                //    }
                //    else
                //    {
                //        // レコードが存在すれば、更新リストへ追加する。
                //        updList.Add(index);
                //    }
                //}
                // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
                // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>

                for (int index = 0; index < csvArrayList.Count; index++)
                {
                    if (!rightCustCdDic.ContainsKey(index))
                    {
                        continue;
                    }
                    CustomerGroupWork custom = csvArrayList[index] as CustomerGroupWork;

                    // ------ DEL START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                    //if (!dict.ContainsKey(Convert.ToInt32(custom.CustomerCode)))
                    //{
                    //    if (Convert.ToInt32(custom.CustomerCode) != 0)
                    //    {
                    //        // レコードが存在しなければ、追加リストへ追加する。
                    //        addList.Add(index);
                    //    }
                    //}
                    // ------ DEL END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<

                    // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                    if (!dict.ContainsKey(ConvertToInt32(custom.CustomerCode.Trim())))
                    {

                        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応-------->>>>
                        if (checkDiv == 1)
                        {
                            // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応--------<<<<

                            if (ConvertToInt32(custom.CustomerCode.Trim()) != 0)
                            {
                                // レコードが存在しなければ、追加リストへ追加する。
                                addList.Add(index);
                            }
                        }
                        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応-------->>>>
                        else
                        {
                            addList.Add(index);
                        }
                        // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応--------<<<<

                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<
                    else
                    {
                        // レコードが存在すれば、更新リストへ追加する。
                        updList.Add(index);
                    }
                }
                // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
                // 読込件数
                //readCnt = csvDataTable.Rows.Count;  // DEL  2012/07/03  李亜博 Redmine#30393
                readCnt = csvArrayList.Count; // ADD  2012/07/03  李亜博 Redmine#30393

                // 重複エラー時の重複項目
                ArrayList duplicationItemList = new ArrayList();

                ArrayList addImportWorkArray = new ArrayList();

                ArrayList updImportWorkArray = new ArrayList();
                //得意先掛率グループ追加リスト
                ArrayList addrateList = new ArrayList();
                // 得意先掛率グループ更新リスト
                ArrayList updrateList = new ArrayList();

                ArrayList workList = new ArrayList();

                // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応-------->>>>
                ArrayList importCustWorkArray = csvObj as ArrayList;
                List<CustomerGroupWork> importCustWorCheckList = new List<CustomerGroupWork>();
                CustomerGroupWork[] arr = (CustomerGroupWork[])importCustWorkArray.ToArray(typeof(CustomerGroupWork));
                importCustWorCheckList.AddRange(arr);

                // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応--------<<<<
                // 処理区分が「追加」の場合
                if (processKbn == 1)
                {
                    if (addList != null && addList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in addList)
                        {
                            int cust = -1;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            // GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, false, null);// DEL  2012/07/03  李亜博 Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            {
                                addImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, false));
                            }
                        }
                    }
                    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                    addList = workList;
                } // 処理区分が「更新」の場合
                else if (processKbn == 2)
                {
                    if (updList != null && updList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in updList)
                        {
                            int cust = -1;
                            CustomerWork custWork = null;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            dict.TryGetValue((int)cust, out custWork);
                            //GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, true, custWork);// DEL  2012/07/03  李亜博 Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            {
                                updImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, true));
                            }
                        }
                    }
                    logArrayListWork = (object)logArrayList;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                    updList = workList;
                }
                // 処理区分が「追加更新」の場合
                else
                {
                    if (addList != null && addList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in addList)
                        {
                            int cust = -1;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            //GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, false, null);// DEL  2012/07/03  李亜博 Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, false, null);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            //logArrayListWork = (object)logArrayList;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            {
                                addImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, false));
                            }
                        }
                        addList = workList;
                    }

                    if (updList != null && updList.Count > 0)
                    {
                        workList = new ArrayList();
                        foreach (int index in updList)
                        {
                            int cust = -1;
                            CustomerWork custWork = null;
                            CustomerRateWork work = new CustomerRateWork();
                            rightCustCdDic.TryGetValue(index, out cust);
                            dict.TryGetValue((int)cust, out custWork);
                            //GetLogTable(index, csvDataTable, ref logTable, enterpriseCode, ref work, true, custWork);// DEL  2012/07/03  李亜博 Redmine#30393
                            //GetLogTable(index, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
                            //GetLogTable(index, consTaxLay, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            GetLogTable(index, checkDiv, consTaxLay, importCustWorCheckList, csvArrayList, ref logArrayList, enterpriseCode, ref work, true, custWork);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            //logArrayListWork = (object)logArrayList;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                            //if (work.CustomerCode == cust)// DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            if (work.CustomerCode == cust && cust != 0) // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
                            {
                                updImportWorkArray.Add(work);
                                workList.Add(GetCustomerWork(work, true));
                            }
                        }
                        updList = workList;// ADD  2012/07/10  李亜博 Redmine#30393
                    }
                    //updList = workList;// DEL  2012/07/10  李亜博 Redmine#30393
                }
                //エラー件数
                //logCnt = logTable.Rows.Count;// DEL  2012/07/03  李亜博 Redmine#30393
                logCnt = logArrayList.Count;// ADD  2012/07/03  李亜博 Redmine#30393
                logArrayListWork = (object)logArrayList; // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                // 処理区分が「追加」の場合
                if (processKbn == 1)
                {
                    if (addList != null && addList.Count > 0)
                    {

                        Object objAddList = addList as object;
                        // 登録処理
                        status = customerDB.Write(ref objAddList, out duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            GetRateList(addImportWorkArray, addrateList, updrateList, enterpriseCode);
                            addCnt = addList.Count;
                        }

                    }
                }

                // 処理区分が「更新」の場合
                else if (processKbn == 2)
                {
                    if (updList != null && updList.Count > 0)
                    {
                        Object objUpdList = updList as object;
                        // 更新処理
                        status = customerDB.Write(ref objUpdList, out duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            GetRateList(updImportWorkArray, addrateList, updrateList, enterpriseCode);
                            updCnt = updList.Count;
                        }
                    }
                }
                // 処理区分が「追加更新」の場合
                else
                {
                    // 登録更新リストの作成
                    ArrayList addUpdList = new ArrayList();
                    if (addList.Count > 0)
                    {
                        addUpdList.AddRange(addList.GetRange(0, addList.Count));
                    }
                    if (updList.Count > 0)
                    {
                        addUpdList.AddRange(updList.GetRange(0, updList.Count));
                    }


                    if (addUpdList.Count > 0)
                    {
                        Object objAddUpdList = addUpdList as object;
                        // 登録更新処理
                        status = customerDB.Write(ref objAddUpdList, out duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            ArrayList addUpdRateList = new ArrayList();
                            if (addImportWorkArray.Count > 0)
                            {
                                addUpdRateList.AddRange(addImportWorkArray.GetRange(0, addList.Count));
                            }
                            if (updImportWorkArray.Count > 0)
                            {
                                addUpdRateList.AddRange(updImportWorkArray.GetRange(0, updList.Count));
                            }

                            GetRateList(addUpdRateList, addrateList, updrateList, enterpriseCode);
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        # endregion

        /// <summary>
        ///  得意先ワーク処理。
        /// </summary>
        /// <param name="custrate">得意先掛率グループワーク</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ログテーブル処理。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/09 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.39、NO.46、NO.47、NO.48、NO.49、NO.51の対応</br>
        /// <br>Update Note: 2023/06/28 3H 仰亮亮</br>
        /// <br>管理番号   : 11900025-00 インポート不具合対応</br>
        /// <br>           : ①集金月区分名称</br>
        /// <br>           : ②諸口名称</br>
        /// <br>           : ③入力拠点コード</br>
        /// <br>           : ④DM出力区分名称</br>
        /// <br>           : ⑤メールアドレス種別名称1</br>
        /// <br>           : ⑥メール送信区分名称1</br>
        /// <br>           : ⑦メールアドレス種別名称2</br>
        /// <br>           : ⑧メール送信区分名称2</br>
        private CustomerWork GetCustomerWork(CustomerRateWork custrate, bool isUpdFlg)
        {
            CustomerWork work = new CustomerWork();
            if (isUpdFlg)
            {
                // 更新の場合
                work.CreateDateTime = custrate.CreateDateTime;              // 作成日時
                work.UpdateDateTime = custrate.UpdateDateTime;              // 更新日時
                work.FileHeaderGuid = custrate.FileHeaderGuid;              // GUID
                work.LogicalDeleteCode = 0;                                 // 論理削除区分
                work.PureCode = custrate.PureCode;                          // 純正区分
                work.TotalAmountDispWayCd = custrate.TotalAmountDispWayCd;  // 総額表示方法区分
                work.TotalAmntDspWayRef = custrate.TotalAmntDspWayRef;      // 総額表示方法参照区分
                work.BillPartsNoPrtCd = custrate.BillPartsNoPrtCd;          // 品番印字区分(請求書)
                work.DeliPartsNoPrtCd = custrate.DeliPartsNoPrtCd;          // 品番印字区分(納品書）
                work.DefSalesSlipCd = custrate.DefSalesSlipCd;              // 伝票区分初期値
                work.LavorRateRank = custrate.LavorRateRank;                // 工賃レバレートランク
                work.SlipTtlPrn = custrate.SlipTtlPrn;                      // 伝票タイトルパターン
                work.DepoBankCode = custrate.DepoBankCode;                  // 入金銀行コード
                work.DeliHonorificTtl = custrate.DeliHonorificTtl;          // 納品書敬称
                work.BillHonorificTtl = custrate.BillHonorificTtl;          // 請求書敬称
                work.EstmHonorificTtl = custrate.EstmHonorificTtl;          // 見積書敬称
                work.RectHonorificTtl = custrate.RectHonorificTtl;          // 領収書敬称
                work.DeliHonorTtlPrtDiv = custrate.DeliHonorTtlPrtDiv;      // 納品書敬称印字区分
                work.BillHonorTtlPrtDiv = custrate.BillHonorTtlPrtDiv;      // 請求書敬称印字区分
                work.EstmHonorTtlPrtDiv = custrate.EstmHonorTtlPrtDiv;      // 見積書敬称印字区分
                work.RectHonorTtlPrtDiv = custrate.RectHonorTtlPrtDiv;      // 領収書敬称印字区分
                work.CustomerEpCode = custrate.CustomerEpCode;              // 得意先企業コード
                work.CustomerSecCode = custrate.CustomerSecCode;            // 得意先拠点コード
                work.OnlineKindDiv = custrate.OnlineKindDiv;                // オンライン種別区分
                work.SimplInqAcntAcntGrId = custrate.SimplInqAcntAcntGrId;  // オンラインアカウントID  ADD  2012/07/09  李亜博 Redmine#30393 for  障害一覧の指摘NO.47の対応
            }
            else
            {
                // 新規の場合
                work.PureCode = 0;                                            // 純正区分
                work.TotalAmountDispWayCd = 0;                                // 総額表示方法区分
                work.TotalAmntDspWayRef = 0;                                  // 総額表示方法参照区分
                work.BillPartsNoPrtCd = 0;                                    // 品番印字区分(請求書)
                work.DeliPartsNoPrtCd = 0;                                    // 品番印字区分(納品書）
                work.DefSalesSlipCd = 0;                                      // 伝票区分初期値
                work.LavorRateRank = 0;                                       // 工賃レバレートランク
                work.SlipTtlPrn = 0;                                          // 伝票タイトルパターン
                work.DepoBankCode = 0;                                        // 入金銀行コード
                work.DeliHonorificTtl = string.Empty;                         // 納品書敬称
                work.BillHonorificTtl = string.Empty;                         // 請求書敬称
                work.EstmHonorificTtl = string.Empty;                         // 見積書敬称
                work.RectHonorificTtl = string.Empty;                         // 領収書敬称
                work.DeliHonorTtlPrtDiv = 0;                                  // 納品書敬称印字区分
                work.BillHonorTtlPrtDiv = 0;                                  // 請求書敬称印字区分
                work.EstmHonorTtlPrtDiv = 0;                                  // 見積書敬称印字区分
                work.RectHonorTtlPrtDiv = 0;                                  // 領収書敬称印字区分
                work.CustomerEpCode = string.Empty;                           // 得意先企業コード
                work.CustomerSecCode = string.Empty;                          // 得意先拠点コード
                work.OnlineKindDiv = 0;                                       // オンライン種別区分

            }
            work.EnterpriseCode = custrate.EnterpriseCode;
            work.CustomerCode = custrate.CustomerCode;                        // 得意先コード
            work.CustomerSubCode = custrate.CustomerSubCode;                  // サブコード
            work.Name = custrate.Name;                                        // 得意先名１
            work.Name2 = custrate.Name2;                                      // 得意先名２
            work.CustomerSnm = custrate.CustomerSnm;                          // 得意先略称
            work.Kana = custrate.Kana;                                        // 得意先名カナ
            work.HonorificTitle = custrate.HonorificTitle;                    // 敬称
            work.OutputNameCode = custrate.OutputNameCode;                    // 諸口
            work.OutputName = GetOutputNameNew(custrate.OutputNameCode);      // 諸口名称 // ADD 2023/06/28 3H 仰亮亮
            work.MngSectionCode = custrate.MngSectionCode;                    // 管理拠点
            work.InpSectionCode = custrate.MngSectionCode;                    // 入力拠点コード // ADD 2023/06/28 3H 仰亮亮
            work.CustomerAgentCd = custrate.CustomerAgentCd;                  // 得意先担当
            work.OldCustomerAgentCd = custrate.OldCustomerAgentCd;            // 旧担当
            work.CustAgentChgDate = custrate.CustAgentChgDate;                // 担当者変更日
            work.TransStopDate = custrate.TransStopDate;                      // 取引中止日
            work.CarMngDivCd = custrate.CarMngDivCd;                          // 車輛管理
            work.CorporateDivCode = custrate.CorporateDivCode;                // 個人・法人
            work.AcceptWholeSale = custrate.AcceptWholeSale;                  // 得意先種別
            work.CustomerAttributeDiv = custrate.CustomerAttributeDiv;        // 得意先属性
            work.CustWarehouseCd = custrate.CustWarehouseCd;                  // 優先倉庫
            work.BusinessTypeCode = custrate.BusinessTypeCode;                // 業種
            work.JobTypeCode = custrate.JobTypeCode;                          // 職種
            work.SalesAreaCode = custrate.SalesAreaCode;                      // 地区
            work.CustAnalysCode1 = custrate.CustAnalysCode1;                  // 分析コード１
            work.CustAnalysCode2 = custrate.CustAnalysCode2;                  // 分析コード２
            work.CustAnalysCode3 = custrate.CustAnalysCode3;                  // 分析コード３
            work.CustAnalysCode4 = custrate.CustAnalysCode4;                  // 分析コード４
            work.CustAnalysCode5 = custrate.CustAnalysCode5;                  // 分析コード５
            work.CustAnalysCode6 = custrate.CustAnalysCode6;                  // 分析コード６
            work.ClaimSectionCode = custrate.ClaimSectionCode;                // 請求拠点
            work.ClaimCode = custrate.ClaimCode;                              // 請求コード
            work.TotalDay = custrate.TotalDay;                                // 締日
            work.CollectMoneyCode = custrate.CollectMoneyCode;                // 集金月
            work.CollectMoneyName = GetCollectMoneyName(custrate.CollectMoneyCode);// 集金月区分名称 // ADD 2023/06/28 3H 仰亮亮
            work.CollectMoneyDay = custrate.CollectMoneyDay;                  // 集金日
            work.CollectCond = custrate.CollectCond;                          // 回収条件
            work.CollectSight = custrate.CollectSight;                        // 回収サイト
            work.NTimeCalcStDate = custrate.NTimeCalcStDate;                  // 次回勘定
            work.BillCollecterCd = custrate.BillCollecterCd;                  // 集金担当
            work.CustCTaXLayRefCd = custrate.CustCTaXLayRefCd;                // 転嫁方式参照区分
            work.ConsTaxLayMethod = custrate.ConsTaxLayMethod;                // 消費税転嫁方式
            work.SalesUnPrcFrcProcCd = custrate.SalesUnPrcFrcProcCd;          // 単価端数処理
            work.SalesMoneyFrcProcCd = custrate.SalesMoneyFrcProcCd;          // 金額端数処理
            work.SalesCnsTaxFrcProcCd = custrate.SalesCnsTaxFrcProcCd;        // 消費税端数処理
            work.CreditMngCode = custrate.CreditMngCode;                      // 与信管理
            work.DepoDelCode = custrate.DepoDelCode;                          // 入金消込
            work.AccRecDivCd = custrate.AccRecDivCd;                          // 売掛区分
            work.PostNo = custrate.PostNo;                                    // 郵便番号
            work.Address1 = custrate.Address1;                                // 住所
            work.Address3 = custrate.Address3;                                // 住所２
            work.Address4 = custrate.Address4;                                // 住所３
            work.CustomerAgent = custrate.CustomerAgent;                      // 得意先担当者
            work.HomeTelNo = custrate.HomeTelNo;                              // 自宅ＴＥＬ
            work.OfficeTelNo = custrate.OfficeTelNo;                          // 勤務先電話１
            work.PortableTelNo = custrate.PortableTelNo;                      // 勤務先電話２
            work.OthersTelNo = custrate.OthersTelNo;                          // その他電話
            work.HomeFaxNo = custrate.HomeFaxNo;                              // 自宅ＦＡＸ
            work.OfficeFaxNo = custrate.OfficeFaxNo;                          // 勤務先ＦＡＸ
            work.SearchTelNo = custrate.SearchTelNo;                          // 検索番号
            work.MainContactCode = custrate.MainContactCode;                  // 主連絡先
            work.Note1 = custrate.Note1;                                      // 得意先備考１
            work.Note2 = custrate.Note2;                                      // 得意先備考２
            work.Note3 = custrate.Note3;                                      // 得意先備考３
            work.Note4 = custrate.Note4;                                      // 得意先備考４
            work.Note5 = custrate.Note5;                                      // 得意先備考５
            work.Note6 = custrate.Note6;                                      // 得意先備考６
            work.Note7 = custrate.Note7;                                      // 得意先備考７
            work.Note8 = custrate.Note8;                                      // 得意先備考８
            work.Note9 = custrate.Note9;                                      // 得意先備考９
            work.Note10 = custrate.Note10;                                    // 得意先備考１０
            work.MainSendMailAddrCd = custrate.MainSendMailAddrCd;            // 主送信先メールアドレス区分
            work.MailAddress1 = custrate.MailAddress1;                        // メールアドレス１
            work.MailSendCode1 = custrate.MailSendCode1;                      // メール送信区分コード１
            work.MailSendName1 = GetMailSendName1(custrate.MailSendCode1);    // メール送信区分名称1  // ADD 2023/06/28 3H 仰亮亮
            work.MailAddrKindCode1 = custrate.MailAddrKindCode1;              // メールアドレス種別コード１
            work.MailAddrKindName1 = GetMailAddrKindName1(custrate.MailAddrKindCode1); // メールアドレス種別名称1 // ADD 2023/06/28 3H 仰亮亮
            work.MailAddress2 = custrate.MailAddress2;                        // メールアドレス２
            work.MailSendCode2 = custrate.MailSendCode2;                      // メール送信区分コード２
            work.MailSendName2 = GetMailSendName2(custrate.MailSendCode2);    // メール送信区分名称2  // ADD 2023/06/28 3H 仰亮亮
            work.MailAddrKindCode2 = custrate.MailAddrKindCode2;              // メールアドレス種別コード２
            work.MailAddrKindName2 = GetMailAddrKindName2(custrate.MailAddrKindCode2); // メールアドレス種別名称2 // ADD 2023/06/28 3H 仰亮亮
            work.AccountNoInfo1 = custrate.AccountNoInfo1;                    // 銀行口座１
            work.AccountNoInfo2 = custrate.AccountNoInfo2;                    // 銀行口座２
            work.AccountNoInfo3 = custrate.AccountNoInfo3;                    // 銀行口座３
            work.ReceiptOutputCode = custrate.ReceiptOutputCode;              // 領収書出力
            work.DmOutCode = custrate.DmOutCode;                              // ＤＭ出力
            work.DmOutName = GetDmOutName(custrate.DmOutCode);                    // DM出力区分名称 // ADD 2023/06/28 3H 仰亮亮
            work.SalesSlipPrtDiv = custrate.SalesSlipPrtDiv;                  // 納品書出力
            work.AcpOdrrSlipPrtDiv = custrate.AcpOdrrSlipPrtDiv;              // 受注伝票出力
            work.ShipmSlipPrtDiv = custrate.ShipmSlipPrtDiv;                  // 貸出伝票出力
            work.EstimatePrtDiv = custrate.EstimatePrtDiv;                    // 見積伝票出力
            work.UOESlipPrtDiv = custrate.UOESlipPrtDiv;                      // ＵＯＥ伝票出力
            work.QrcodePrtCd = custrate.QrcodePrtCd;                          // ＱＲコード印刷
            work.CustSlipNoMngCd = custrate.CustSlipNoMngCd;                  // 相手伝票番号管理
            work.CustomerSlipNoDiv = custrate.CustomerSlipNoDiv;              // 相手伝票番号区分

            work.TotalBillOutputDiv = custrate.TotalBillOutputDiv;            // 合計請求書出力
            work.DetailBillOutputCode = custrate.DetailBillOutputCode;        // 明細請求書出力
            work.SlipTtlBillOutputDiv = custrate.SlipTtlBillOutputDiv;        // 伝票合計請求書出力区分
            return work;
        }
        /// <summary>
        /// ログテーブル処理。
        /// </summary>
        /// <param name="index">正しいデータの行数</param>
        /// <param name="checkDiv">チェック区分</param>
        /// <param name="consTaxLay">消費税転嫁方式</param>
        /// <param name="importCustWorCheckList">チェックリスト</param>
        /// <param name="csvArrayList">インポートデータリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        /// <param name="logArrayList">ログリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="isUpdFlag">更新フラグ（true:更新、false:追加）</param>
        /// <param name="work">CustomerWork</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ログテーブル処理。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.94、NO.106、NO.107、NO.108の対応</br>
        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        //private void GetLogTable(int index, DataTable csvDataTable, ref DataTable logTable,
        //    string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)
        //{

        //    CheckData(csvDataTable.Rows[index], ref work, ref logTable, enterpriseCode, isUpdFlag, searchWork);
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
        //private void GetLogTable(int index, ArrayList csvArrayList, ref ArrayList logArrayList,
        //    string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
        //private void GetLogTable(int index, Int32 consTaxLay, ArrayList csvArrayList, ref ArrayList logArrayList,
        //      string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        private void GetLogTable(int index, Int32 checkDiv, Int32 consTaxLay, List<CustomerGroupWork> importCustWorCheckList, ArrayList csvArrayList, ref ArrayList logArrayList,
               string enterpriseCode, ref CustomerRateWork work, bool isUpdFlag, CustomerWork searchWork)// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        {

            //CheckData((CustomerGroupWork)csvArrayList[index], ref work, ref logArrayList, enterpriseCode, isUpdFlag, searchWork);// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
            //CheckData((CustomerGroupWork)csvArrayList[index], consTaxLay, ref work, ref logArrayList, enterpriseCode, isUpdFlag, searchWork); // ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応   // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
            CheckData((CustomerGroupWork)csvArrayList[index], checkDiv, consTaxLay, importCustWorCheckList, ref work, ref logArrayList, enterpriseCode, isUpdFlag, searchWork);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
        /// <summary>
        /// 得意先掛率グループリストWrite処理。
        /// </summary>
        /// <param name="newImportWorkArray">正しいデータの行数</param>
        /// <param name="addrateList">得意先掛率グループ追加リスト</param>
        /// <param name="updrateList">得意先掛率グループ更新リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <br>Note       : 得意先掛率グループリストWrite処理。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/09 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.39、NO.46、NO.47、NO.48、NO.49、NO.51の対応</br>
        /// <br>Update Note: 2012/07/24 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  動作検証、障害一覧の指摘NO.61、NO.106の対応</br>
        private void GetRateList(ArrayList newImportWorkArray, ArrayList addrateList, ArrayList updrateList, string enterpriseCode)
        {
            Dictionary<CustomerRateImportWorkWrap, CustRateGroupWork> dictrate = new Dictionary<CustomerRateImportWorkWrap, CustRateGroupWork>();
            CustRateGroupDB custRateGroupDB = new CustRateGroupDB();

            // 全て得意先掛率グループの検索処理
            CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
            custRateGroupWork.EnterpriseCode = enterpriseCode;
            object custRateGroupObj = new object();
            object paramCustRateObj = (object)custRateGroupWork;
            custRateGroupDB.Search(ref custRateGroupObj, paramCustRateObj, 0, ConstantManagement.LogicalMode.GetDataAll);
            ArrayList searchCustRateGroupList = (ArrayList)custRateGroupObj;

            foreach (CustRateGroupWork workrate in searchCustRateGroupList)
            {
                // 存在するデータをDictionaryへ格納する（他インポートPGと処理方法が違います。）
                if (workrate.CreateDateTime != DateTime.MinValue)
                {
                    CustomerRateImportWorkWrap warprate = new CustomerRateImportWorkWrap(workrate);
                    dictrate.Add(warprate, workrate);
                }
            }
            foreach (CustomerRateWork customerWork in newImportWorkArray)
            {
                ArrayList csvCustRateGroupList = new ArrayList();
                addrateList = new ArrayList();
                updrateList = new ArrayList();

                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFine)); //得意先掛率グループ(優良)// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                #region  DEL 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応
                // --------------- DEL START 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応-------->>>>
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//得意先掛率グループ(優良ALL)// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 0, customerWork.CustRateGrpPureAll));//得意先掛率グループ(純正ALL)
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 1, customerWork.CustRateGrpPure1));  //得意先掛率グループ純正1
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 2, customerWork.CustRateGrpPure2));  //得意先掛率グループ純正2
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 3, customerWork.CustRateGrpPure3));  //得意先掛率グループ純正3
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 4, customerWork.CustRateGrpPure4));  //得意先掛率グループ純正4
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 5, customerWork.CustRateGrpPure5));  //得意先掛率グループ純正5
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 6, customerWork.CustRateGrpPure6));  //得意先掛率グループ純正6
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 7, customerWork.CustRateGrpPure7));  //得意先掛率グループ純正7
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 8, customerWork.CustRateGrpPure8));  //得意先掛率グループ純正8
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 9, customerWork.CustRateGrpPure9));  //得意先掛率グループ純正9
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 10, customerWork.CustRateGrpPure10));//得意先掛率グループ純正10
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 11, customerWork.CustRateGrpPure11));//得意先掛率グループ純正11
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 12, customerWork.CustRateGrpPure12));//得意先掛率グループ純正12
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 13, customerWork.CustRateGrpPure13));//得意先掛率グループ純正13
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 14, customerWork.CustRateGrpPure14));//得意先掛率グループ純正14
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 15, customerWork.CustRateGrpPure15));//得意先掛率グループ純正15
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 16, customerWork.CustRateGrpPure16));//得意先掛率グループ純正16
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 17, customerWork.CustRateGrpPure17));//得意先掛率グループ純正17
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 18, customerWork.CustRateGrpPure18));//得意先掛率グループ純正18
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 19, customerWork.CustRateGrpPure19));//得意先掛率グループ純正19
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 20, customerWork.CustRateGrpPure20));//得意先掛率グループ純正20
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 21, customerWork.CustRateGrpPure21));//得意先掛率グループ純正21
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 22, customerWork.CustRateGrpPure22));//得意先掛率グループ純正22
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 23, customerWork.CustRateGrpPure23));//得意先掛率グループ純正23
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 24, customerWork.CustRateGrpPure24));//得意先掛率グループ純正24
                //csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 25, customerWork.CustRateGrpPure25));//得意先掛率グループ純正25
                // --------------- DEL END 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応--------<<<<
                #endregion

                #region  ADD 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応
                // --------------- ADD START 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応-------->>>>
                if (!(customerWork.CustRateGrpPure1 == -1 && customerWork.CustRateGrpPure2 == -1 && customerWork.CustRateGrpPure3 == -1 && customerWork.CustRateGrpPure4 == -1 && customerWork.CustRateGrpPure5 == -1 &&
                        customerWork.CustRateGrpPure6 == -1 && customerWork.CustRateGrpPure7 == -1 && customerWork.CustRateGrpPure8 == -1 && customerWork.CustRateGrpPure9 == -1 && customerWork.CustRateGrpPure10 == -1 &&
                        customerWork.CustRateGrpPure11 == -1 && customerWork.CustRateGrpPure12 == -1 && customerWork.CustRateGrpPure13 == -1 && customerWork.CustRateGrpPure14 == -1 && customerWork.CustRateGrpPure15 == -1 &&
                        customerWork.CustRateGrpPure16 == -1 && customerWork.CustRateGrpPure17 == -1 && customerWork.CustRateGrpPure18 == -1 && customerWork.CustRateGrpPure19 == -1 && customerWork.CustRateGrpPure20 == -1 &&
                        customerWork.CustRateGrpPure21 == -1 && customerWork.CustRateGrpPure22 == -1 && customerWork.CustRateGrpPure23 == -1 && customerWork.CustRateGrpPure24 == -1 && customerWork.CustRateGrpPure25 == -1 &&
                        customerWork.CustRateGrpFineAll == -1 && customerWork.CustRateGrpPureAll == -1))
                {
                    // 得意先掛率グループ(純正ALL)ある場合
                    if (customerWork.CustRateGrpPureAll != -1)
                    {
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 0, customerWork.CustRateGrpPureAll));//得意先掛率グループ(純正ALL)
                        csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//得意先掛率グループ(優良ALL)
                        // 削除リスト
                        ArrayList delCustRateGroupWorkList = new ArrayList();
                        // 削除データ取得
                        foreach (CustRateGroupWork wk in searchCustRateGroupList)
                        {
                            if (wk.EnterpriseCode == customerWork.EnterpriseCode &&
                                wk.CustomerCode == customerWork.CustomerCode &&
                                wk.PureCode == 0 && wk.GoodsMakerCd != 0)
                            {
                                delCustRateGroupWorkList.Add(wk);
                            }
                        }
                        // データの削除
                        if (delCustRateGroupWorkList != null && delCustRateGroupWorkList.Count > 0)
                        {
                            // ArrayListから配列を生成
                            CustRateGroupWork[] works = (CustRateGroupWork[])delCustRateGroupWorkList.ToArray(typeof(CustRateGroupWork));

                            // XMLへ変換し、文字列のバイナリ化
                            byte[] parabyte = XmlByteSerializer.Serialize(works);

                            custRateGroupDB.Delete(parabyte);
                        }

                    }
                    else
                    {
                        // 得意先掛率グループ純正無場合
                        if (customerWork.CustRateGrpPure1 == -1 && customerWork.CustRateGrpPure2 == -1 && customerWork.CustRateGrpPure3 == -1 && customerWork.CustRateGrpPure4 == -1 && customerWork.CustRateGrpPure5 == -1 &&
                            customerWork.CustRateGrpPure6 == -1 && customerWork.CustRateGrpPure7 == -1 && customerWork.CustRateGrpPure8 == -1 && customerWork.CustRateGrpPure9 == -1 && customerWork.CustRateGrpPure10 == -1 &&
                            customerWork.CustRateGrpPure11 == -1 && customerWork.CustRateGrpPure12 == -1 && customerWork.CustRateGrpPure13 == -1 && customerWork.CustRateGrpPure14 == -1 && customerWork.CustRateGrpPure15 == -1 &&
                            customerWork.CustRateGrpPure16 == -1 && customerWork.CustRateGrpPure17 == -1 && customerWork.CustRateGrpPure18 == -1 && customerWork.CustRateGrpPure19 == -1 && customerWork.CustRateGrpPure20 == -1 &&
                            customerWork.CustRateGrpPure21 == -1 && customerWork.CustRateGrpPure22 == -1 && customerWork.CustRateGrpPure23 == -1 && customerWork.CustRateGrpPure24 == -1 && customerWork.CustRateGrpPure25 == -1)
                        {
                            csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 0, customerWork.CustRateGrpPureAll));// 得意先掛率グループ(純正ALL)
                            csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//得意先掛率グループ(優良ALL)
                            // 削除リスト
                            ArrayList delCustRateGroupWorkList = new ArrayList();
                            // 削除データ取得
                            foreach (CustRateGroupWork wk in searchCustRateGroupList)
                            {
                                if (wk.EnterpriseCode == customerWork.EnterpriseCode &&
                                    wk.CustomerCode == customerWork.CustomerCode &&
                                    wk.PureCode == 0 && wk.GoodsMakerCd != 0)
                                {
                                    delCustRateGroupWorkList.Add(wk);
                                }
                            }
                            // データの削除
                            if (delCustRateGroupWorkList != null && delCustRateGroupWorkList.Count > 0)
                            {
                                // ArrayListから配列を生成
                                CustRateGroupWork[] works = (CustRateGroupWork[])delCustRateGroupWorkList.ToArray(typeof(CustRateGroupWork));

                                // XMLへ変換し、文字列のバイナリ化
                                byte[] parabyte = XmlByteSerializer.Serialize(works);

                                custRateGroupDB.Delete(parabyte);
                            }
                        }
                        else
                        {
                            csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 1, 0, customerWork.CustRateGrpFineAll));//得意先掛率グループ(優良ALL)
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 1, customerWork.CustRateGrpPure1));  //得意先掛率グループ純正1
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 2, customerWork.CustRateGrpPure2));  //得意先掛率グループ純正2
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 3, customerWork.CustRateGrpPure3));  //得意先掛率グループ純正3
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 4, customerWork.CustRateGrpPure4));  //得意先掛率グループ純正4
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 5, customerWork.CustRateGrpPure5));  //得意先掛率グループ純正5
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 6, customerWork.CustRateGrpPure6));  //得意先掛率グループ純正6
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 7, customerWork.CustRateGrpPure7));  //得意先掛率グループ純正7
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 8, customerWork.CustRateGrpPure8));  //得意先掛率グループ純正8
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 9, customerWork.CustRateGrpPure9));  //得意先掛率グループ純正9
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 10, customerWork.CustRateGrpPure10));//得意先掛率グループ純正10
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 11, customerWork.CustRateGrpPure11));//得意先掛率グループ純正11
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 12, customerWork.CustRateGrpPure12));//得意先掛率グループ純正12
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 13, customerWork.CustRateGrpPure13));//得意先掛率グループ純正13
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 14, customerWork.CustRateGrpPure14));//得意先掛率グループ純正14
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 15, customerWork.CustRateGrpPure15));//得意先掛率グループ純正15
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 16, customerWork.CustRateGrpPure16));//得意先掛率グループ純正16
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 17, customerWork.CustRateGrpPure17));//得意先掛率グループ純正17
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 18, customerWork.CustRateGrpPure18));//得意先掛率グループ純正18
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 19, customerWork.CustRateGrpPure19));//得意先掛率グループ純正19
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 20, customerWork.CustRateGrpPure20));//得意先掛率グループ純正20
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 21, customerWork.CustRateGrpPure21));//得意先掛率グループ純正21
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 22, customerWork.CustRateGrpPure22));//得意先掛率グループ純正22
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 23, customerWork.CustRateGrpPure23));//得意先掛率グループ純正23
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 24, customerWork.CustRateGrpPure24));//得意先掛率グループ純正24
                csvCustRateGroupList.Add(GetcsvCustRateGroup(customerWork, 0, 25, customerWork.CustRateGrpPure25));//得意先掛率グループ純正25
                            // 削除リスト
                            ArrayList delCustRateGroupWorkList = new ArrayList();
                            // 削除データ取得
                            foreach (CustRateGroupWork wk in searchCustRateGroupList)
                            {
                                if (wk.EnterpriseCode == customerWork.EnterpriseCode &&
                                    wk.CustomerCode == customerWork.CustomerCode &&
                                    wk.PureCode == 0 && wk.GoodsMakerCd == 0)
                                {
                                    delCustRateGroupWorkList.Add(wk);
                                }
                            }
                            // データの削除
                            if (delCustRateGroupWorkList != null && delCustRateGroupWorkList.Count > 0)
                            {
                                // ArrayListから配列を生成
                                CustRateGroupWork[] works = (CustRateGroupWork[])delCustRateGroupWorkList.ToArray(typeof(CustRateGroupWork));

                                // XMLへ変換し、文字列のバイナリ化
                                byte[] parabyte = XmlByteSerializer.Serialize(works);

                                custRateGroupDB.Delete(parabyte);
                            }
                        }
                    }
                }
                // --------------- ADD END 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応--------<<<<
                #endregion
                foreach (CustRateGroupWork importRateWork in csvCustRateGroupList)
                {
                    CustomerRateImportWorkWrap importRateWarp = new CustomerRateImportWorkWrap(importRateWork);
                    if (!dictrate.ContainsKey(importRateWarp))
                    {
                        if (importRateWarp.custRateGroupWork.CustomerCode != 0)
                        {
                            // レコードが存在しなければ、追加リストへ追加する。
                            addrateList.Add(ConvertToImportRateWork(importRateWork, null, false));
                        }
                    }
                    else
                    {
                        // ------ ADD START 2012/07/24 Redmine#30393 李亜博 for 動作検証-------->>>>
                        if (dictrate[importRateWarp].LogicalDeleteCode == 0)
                        {
                            // ------ ADD END 2012/07/24 Redmine#30393 李亜博 for 動作検証--------<<<<
                            // レコードが存在すれば、更新リストへ追加する。
                            updrateList.Add(ConvertToImportRateWork(importRateWork, dictrate[importRateWarp], true));
                        }
                    }// ADD  2012/07/24  李亜博 Redmine#30393 for 動作検証
                }
                #region DEL 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応
                // --------------- DEL START 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応-------->>>>
                //// --------------- ADD START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.49の対応-------->>>>
                //int total=0;
                //if (addrateList.Count > 0)
                //{
                //    foreach (CustRateGroupWork custRate in addrateList)
                //    {
                //        total = total + custRate.CustRateGrpCode;
                //    }
                //    if (total == -addrateList.Count)
                //    {
                //        addrateList = new ArrayList();
                //    }
                //}
                //// --------------- ADD END 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.49の対応--------<<<<
                // --------------- DEL END 2013/03/25 Redmine#35047 wangl2 for No.1841得意先インポートの対応--------<<<<
                #endregion
                ArrayList addUpdRateList = new ArrayList();
                if (addrateList.Count > 0)
                {
                    addUpdRateList.AddRange(addrateList.GetRange(0, addrateList.Count));
                }
                if (updrateList.Count > 0)
                {
                    addUpdRateList.AddRange(updrateList.GetRange(0, updrateList.Count));
                }
                if (addUpdRateList.Count > 0)
                {
                    Object objAddUppRateList = addUpdRateList;
                    int status = custRateGroupDB.Write(ref objAddUppRateList);
                }
            }
        }
        # region チェック

        # region メッセージ

        //private const string FORMAT_ERRMSG_LEN = "{0}が{1}桁以内で入力してください。";// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.30の対応
        private const string FORMAT_ERRMSG_LEN = "{0}は{1}桁以内で入力してください。";// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.30の対応

        //private const string FORMAT_ERRMSG_TYPE = "{0}が{1}を入力してください。";// DEL  2012/07/05  李亜博 Redmine#30393 for 障害一覧の指摘NO.30の対応
        private const string FORMAT_ERRMSG_TYPE = "{0}は{1}を入力してください。";// ADD  2012/07/05  李亜博 Redmine#30393 for 障害一覧の指摘NO.30の対応

        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}を入力してください。";

        private const string FORMAT_ERRMSG_ERRORVAL = "{0}が不正です。";

        //private const string FORMAT_ERRMSG = "得意先掛率グループ(純正ALL)を入力しました。";// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
        private const string FORMAT_ERRMSG = "得意先掛率グループ(純正ALL)を設定した場合、得意先掛率グループ１～２５は設定できません。";// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応

        //private const string ERRMSG_DUPLICATE = "重複データしているため登録できません。";// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応 DEL  2012/07/24  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応
        private const string ERRMSG_DUPLICATE = "重複データがあるため登録できません。";//ADD  2012/07/24  李亜博 Redmine#30393 for 障害一覧の指摘NO.106の対応

        # endregion

        # region 処理

        /// <summary>
        /// 整数、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen">項目長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_IntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([-0-9]{1,})$") && val.Trim() != "-")
            {
                string regexStrLen = @"^([-0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数値");// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.39の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数字");// ADD  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応
                return false;
            }
        }
        /// <summary>
        /// 整数、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen">項目長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_CorIntAndLen(string fieldNm, string val, int numLen, out string msg)
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
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数値");// DEL  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数字"); // ADD  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数");// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                return false;
            }
        }
        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応-------->>>>
        /// <summary>
        /// 正整数、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen">項目長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_IntAndLenth(string fieldNm, string val, int numLen, out string msg)
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
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");
                return false;
            }
        }
        // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応--------<<<<

        /// <summary>
        /// 正整数、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen">項目長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_ZeroIntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))
            {
                // --------------- DEL START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.51の対応-------->>>>
                //if (Convert.ToInt32(val.Trim()) == 0)
                //{
                //    msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                //    return false;
                //}
                // --------------- DEL END 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.51の対応--------<<<<
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                // --------------- ADD START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.51の対応-------->>>>
                if (Convert.ToInt32(val.Trim()) == 0)
                {
                    msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                    return false;
                }
                // --------------- ADD END 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.51の対応--------<<<<
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数値");// DEL  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数字");// ADD  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数");// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                return false;
            }
        }
        /// <summary>
        /// 正整数、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen">項目長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_ZerIntAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            //if (Regex.IsMatch(val, @"^([0-9]{1,})$") && Convert.ToInt32(val.Trim()) != 0)// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.51の対応
            if (Regex.IsMatch(val, @"^([0-9]{1,})$"))// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.51の対応
            {
                string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                    return false;
                }
                // ------ DEL START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応-------->>>>
                // --------------- ADD START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.51の対応-------->>>>
                //if (Convert.ToInt32(val.Trim()) == 0)
                //{
                //    //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数字");// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //    //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数");// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応  // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //    msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //    return false;
                //}
                // --------------- ADD END 2012/07/09 Redmine#30393 李亜博  for 障害一覧の指摘NO.51の対応--------<<<<
                // ------ DEL END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応--------<<<<
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数値");// DEL  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数字");// ADD  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数");// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                return false;
            }
        }
        /// <summary>
        /// NULL判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
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
        /// 長さを指定しないの文字列チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
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
        /// 半角英数字、半角カタカナのチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //半角
            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                if (Regex.IsMatch(val, "[0-9a-zA-Z\uff70-\uff9d\uff9e\uff9f\uff67-\uff6f]{1,}"))
                {
                    if (val.Length > len)
                    {
                        msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, len.ToString());
                        return false;
                    }
                    return true;
                }
                else
                {
                    msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "半角英数字、半角カタカナ");
                    return false;
                }
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "半角英数字、半角カタカナ");
                return false;
            }
        }
        /// <summary>
        /// 半角数字のチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="numLen">長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_HalfNumFixedLength(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            //半角
            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                if (Regex.IsMatch(val, @"^([-0-9]{1,})$") && val.Trim() != "-")
                {
                    string regexStrLen = @"^([-0-9]{1," + numLen.ToString() + "})$";
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, numLen.ToString());
                        return false;
                    }
                    return true;
                }
                else
                {
                    //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数値");// DEL  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応
                    msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数字");// ADD  2012/07/09  李亜博 Redmine#30393  for 障害一覧の指摘NO.39の対応
                    return false;
                }
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "半角数字");
                return false;

            }
        }
        /// <summary>
        /// 日期チェック(20120201)
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        private bool Check_YYYYMMDD(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            try
            {
                if (Convert.ToInt32(val) != 0)
                {
                    DateTime dt = DateTime.ParseExact(val, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
            }
            catch
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }

            return true;
        }

        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// エラーログテーブル
        ///// </summary>
        ///// <param name="dataTable">テーブル</param>
        //private void CreateDataTable(ref DataTable dataTable)
        //{
        //    dataTable.Columns.Add("CustomerCodeRF", typeof(string));           //  得意先コード
        //    dataTable.Columns.Add("CustomerSubCodeRF", typeof(string));	      //  得意先サブコード
        //    dataTable.Columns.Add("NameRF", typeof(string));	              //  名称
        //    dataTable.Columns.Add("Name2RF", typeof(string));	              //  名称2
        //    dataTable.Columns.Add("CustomerSnmRF", typeof(string));	          //  得意先略称
        //    dataTable.Columns.Add("KanaRF", typeof(string));	              //  カナ
        //    dataTable.Columns.Add("HonorificTitleRF", typeof(string));	      //  敬称
        //    dataTable.Columns.Add("OutputNameCodeRF", typeof(string));	      //  諸口コード
        //    dataTable.Columns.Add("MngSectionCodeRF", typeof(string));	      //  管理拠点コード
        //    dataTable.Columns.Add("CustomerAgentCdRF", typeof(string));	      //  顧客担当従業員コード

        //    dataTable.Columns.Add("OldCustomerAgentCdRF", typeof(string));	  //  旧顧客担当従業員コード
        //    dataTable.Columns.Add("CustAgentChgDateRF", typeof(string));       //  顧客担当変更日
        //    dataTable.Columns.Add("TransStopDateRF", typeof(string));	      //  取引中止日	
        //    dataTable.Columns.Add("CarMngDivCdRF", typeof(string));	          //  車輌管理区分
        //    dataTable.Columns.Add("CorporateDivCodeRF", typeof(string));       //  個人・法人区分
        //    dataTable.Columns.Add("AcceptWholeSaleRF", typeof(string));	      //  業販先区分
        //    dataTable.Columns.Add("CustomerAttributeDivRF", typeof(string));	  //  得意先属性区分
        //    dataTable.Columns.Add("CustWarehouseCdRF", typeof(string));	      //  得意先優先倉庫コード
        //    dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));       //  業種コード
        //    dataTable.Columns.Add("JobTypeCodeRF", typeof(string));	          //  職種コード

        //    dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	      //  販売エリアコード
        //    dataTable.Columns.Add("CustAnalysCode1RF", typeof(string));        //  得意先分析コード1
        //    dataTable.Columns.Add("CustAnalysCode2RF", typeof(string));	      //  得意先分析コード2
        //    dataTable.Columns.Add("CustAnalysCode3RF", typeof(string));	      //  得意先分析コード3
        //    dataTable.Columns.Add("CustAnalysCode4RF", typeof(string));	      //  得意先分析コード4
        //    dataTable.Columns.Add("CustAnalysCode5RF", typeof(string));	      //  得意先分析コード5
        //    dataTable.Columns.Add("CustAnalysCode6RF", typeof(string));	      //  得意先分析コード6
        //    dataTable.Columns.Add("ClaimSectionCodeRF", typeof(string));	  //  請求拠点コード
        //    dataTable.Columns.Add("ClaimCodeRF", typeof(string));              //  請求先コード
        //    dataTable.Columns.Add("TotalDayRF", typeof(string));	              //  締日

        //    dataTable.Columns.Add("CollectMoneyCodeRF", typeof(string));	      //  集金月区分コード
        //    dataTable.Columns.Add("CollectMoneyDayRF", typeof(string));	      //  集金日
        //    dataTable.Columns.Add("CollectCondRF", typeof(string));	          //  回収条件
        //    dataTable.Columns.Add("CollectSightRF", typeof(string));	          //  回収サイト
        //    dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));        //  次回勘定開始日
        //    dataTable.Columns.Add("BillCollecterCdRF", typeof(string));	      //  集金担当従業員コード
        //    dataTable.Columns.Add("CustCTaXLayRefCdRF", typeof(string));	      //  得意先消費税転嫁方式参照区分
        //    dataTable.Columns.Add("ConsTaxLayMethodRF", typeof(string));	      //  消費税転嫁方式
        //    dataTable.Columns.Add("SalesUnPrcFrcProcCdRF", typeof(string));	  //  売上単価端数処理コード
        //    dataTable.Columns.Add("SalesMoneyFrcProcCdRF", typeof(string));	  //  売上金額端数処理コード

        //    dataTable.Columns.Add("SalesCnsTaxFrcProcCdRF", typeof(string));   //  売上消費税端数処理コード
        //    dataTable.Columns.Add("CreditMngCodeRF", typeof(string));	      //  与信管理区分 
        //    dataTable.Columns.Add("DepoDelCodeRF", typeof(string));	          //  入金消込区分
        //    dataTable.Columns.Add("AccRecDivCdRF", typeof(string));	          //  売掛区分
        //    dataTable.Columns.Add("PostNoRF", typeof(string));	              //  郵便番号
        //    dataTable.Columns.Add("Address1RF", typeof(string));	          //  住所1（都道府県市区郡・町村・字）
        //    dataTable.Columns.Add("Address3RF", typeof(string));	          //  住所3（番地）
        //    dataTable.Columns.Add("Address4RF", typeof(string));	          //  住所4（アパート名称）
        //    dataTable.Columns.Add("CustomerAgentRF", typeof(string));         //  得意先担当者

        //    dataTable.Columns.Add("HomeTelNoRF", typeof(string));             //  電話番号（自宅）
        //    dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	          //  電話番号（勤務先）
        //    dataTable.Columns.Add("PortableTelNoRF", typeof(string));	      //  電話番号（携帯）
        //    dataTable.Columns.Add("OthersTelNoRF", typeof(string));	          //  電話番号（その他）
        //    dataTable.Columns.Add("HomeFaxNoRF", typeof(string));	          //  FAX番号（自宅）
        //    dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	          //  FAX番号（勤務先）

        //    dataTable.Columns.Add("SearchTelNoRF", typeof(string));	          //  電話番号（検索用下4桁）
        //    dataTable.Columns.Add("MainContactCodeRF", typeof(string));	      //  主連絡先区分
        //    dataTable.Columns.Add("Note1RF", typeof(string));	              //  備考１
        //    dataTable.Columns.Add("Note2RF", typeof(string));	              //  備考２
        //    dataTable.Columns.Add("Note3RF", typeof(string));	              //  備考３

        //    dataTable.Columns.Add("Note4RF", typeof(string));	              //  備考４
        //    dataTable.Columns.Add("Note5RF", typeof(string));	              //  備考５ 
        //    dataTable.Columns.Add("Note6RF", typeof(string));	              //  備考６
        //    dataTable.Columns.Add("Note7RF", typeof(string));	              //  備考７
        //    dataTable.Columns.Add("Note8RF", typeof(string));	              //  備考８
        //    dataTable.Columns.Add("Note9RF", typeof(string));	              //  備考９
        //    dataTable.Columns.Add("Note10RF", typeof(string));	              // 備考１０
        //    dataTable.Columns.Add("MainSendMailAddrCdRF", typeof(string));	  //  主送信先メールアドレス区分
        //    dataTable.Columns.Add("MailAddress1RF", typeof(string));	      //  メールアドレス1	
        //    dataTable.Columns.Add("MailSendCode1RF", typeof(string));	      //  メール送信区分コード1

        //    dataTable.Columns.Add("MailAddrKindCode1RF", typeof(string));	  //  メールアドレス種別コード1
        //    dataTable.Columns.Add("MailAddress2RF", typeof(string));	      // メールアドレス２ 
        //    dataTable.Columns.Add("MailSendCode2RF", typeof(string));	      //  メール送信区分コード２
        //    dataTable.Columns.Add("MailAddrKindCode2RF", typeof(string));	  //  メールアドレス種別コード２
        //    dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	      //  銀行口座１
        //    dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	      //  銀行口座２
        //    dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	      //  銀行口座３
        //    dataTable.Columns.Add("ReceiptOutputCodeRF", typeof(string));	  // 領収書出力区分コード
        //    dataTable.Columns.Add("DmOutCodeRF", typeof(string));	          //  DM出力区分

        //    dataTable.Columns.Add("SalesSlipPrtDivRF", typeof(string));	      //  売上伝票発行区分
        //    dataTable.Columns.Add("AcpOdrrSlipPrtDivRF", typeof(string));	  //  受注伝票発行区分
        //    dataTable.Columns.Add("ShipmSlipPrtDivRF", typeof(string));	      //  出荷伝票発行区分
        //    dataTable.Columns.Add("EstimatePrtDivRF", typeof(string));	      //  見積書発行区分	
        //    dataTable.Columns.Add("UOESlipPrtDivRF", typeof(string));	      // UOE伝票発行区分	
        //    dataTable.Columns.Add("QrcodePrtCdRF", typeof(string));	          //  QRコード印刷
        //    dataTable.Columns.Add("CustSlipNoMngCdRF", typeof(string));	      //  相手伝票番号管理区分
        //    dataTable.Columns.Add("CustomerSlipNoDivRF", typeof(string));	  //  得意先伝票番号区分

        //    dataTable.Columns.Add("TotalBillOutputDivRF", typeof(string));      // 合計請求書出力区分
        //    dataTable.Columns.Add("DetailBillOutputCodeRF", typeof(string));    // 明細請求書出力区分
        //    dataTable.Columns.Add("SlipTtlBillOutputDivRF", typeof(string));    // 伝票合計請求書出力区分

        //    dataTable.Columns.Add("CustRateGrpFine", typeof(string));          //得意先掛率グループ(優良)
        //    dataTable.Columns.Add("CustRateGrpPureAll", typeof(string));       //得意先掛率グループ(純正ALL)
        //    dataTable.Columns.Add("CustRateGrpPure1", typeof(string));         //得意先掛率グループ純正１
        //    dataTable.Columns.Add("CustRateGrpPure2", typeof(string));         //得意先掛率グループ純正2
        //    dataTable.Columns.Add("CustRateGrpPure3", typeof(string));         //得意先掛率グループ純正3
        //    dataTable.Columns.Add("CustRateGrpPure4", typeof(string));         //得意先掛率グループ純正4
        //    dataTable.Columns.Add("CustRateGrpPure5", typeof(string));         //得意先掛率グループ純正5
        //    dataTable.Columns.Add("CustRateGrpPure6", typeof(string));         //得意先掛率グループ純正6
        //    dataTable.Columns.Add("CustRateGrpPure7", typeof(string));         //得意先掛率グループ純正7
        //    dataTable.Columns.Add("CustRateGrpPure8", typeof(string));         //得意先掛率グループ純正8
        //    dataTable.Columns.Add("CustRateGrpPure9", typeof(string));         //得意先掛率グループ純正9
        //    dataTable.Columns.Add("CustRateGrpPure10", typeof(string));        //得意先掛率グループ純正１0
        //    dataTable.Columns.Add("CustRateGrpPure11", typeof(string));        //得意先掛率グループ純正１1
        //    dataTable.Columns.Add("CustRateGrpPure12", typeof(string));        //得意先掛率グループ純正１2
        //    dataTable.Columns.Add("CustRateGrpPure13", typeof(string));        //得意先掛率グループ純正１3
        //    dataTable.Columns.Add("CustRateGrpPure14", typeof(string));        //得意先掛率グループ純正１4
        //    dataTable.Columns.Add("CustRateGrpPure15", typeof(string));        //得意先掛率グループ純正１5
        //    dataTable.Columns.Add("CustRateGrpPure16", typeof(string));        //得意先掛率グループ純正１6
        //    dataTable.Columns.Add("CustRateGrpPure17", typeof(string));        //得意先掛率グループ純正１7
        //    dataTable.Columns.Add("CustRateGrpPure18", typeof(string));        //得意先掛率グループ純正１8
        //    dataTable.Columns.Add("CustRateGrpPure19", typeof(string));        //得意先掛率グループ純正１9
        //    dataTable.Columns.Add("CustRateGrpPure20", typeof(string));        //得意先掛率グループ純正20
        //    dataTable.Columns.Add("CustRateGrpPure21", typeof(string));        //得意先掛率グループ純正21
        //    dataTable.Columns.Add("CustRateGrpPure22", typeof(string));        //得意先掛率グループ純正22
        //    dataTable.Columns.Add("CustRateGrpPure23", typeof(string));        //得意先掛率グループ純正23
        //    dataTable.Columns.Add("CustRateGrpPure24", typeof(string));        //得意先掛率グループ純正24
        //    dataTable.Columns.Add("CustRateGrpPure25", typeof(string));        //得意先掛率グループ純正25
        //    dataTable.Columns.Add("ErrorLog", typeof(string));                 //エラー内容
        //}
        ///// <summary>
        ///// データの検査
        ///// </summary>
        ///// <param name="customerGroupWork">CSVファイルの行</param>// ADD  2012/07/03  李亜博 Redmine#30393
        ///// <param name="work">CustomerWork</param>
        ///// <param name="logArrayList">ログリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        ///// <param name="enterpriseCode"> 企業コード</param>
        ///// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        ///// <param name="searchWork">検索したオブジェクト</param>
        //private void CheckData(DataRow csvRow, ref CustomerRateWork work, ref DataTable logTable, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)
        //{

        //    string msg = string.Empty;
        //    int mark = 1;
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("サブコード", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先名１", csvRow[mark++].ToString(), 30, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先名２", csvRow[mark++].ToString(), 30, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先略称", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("得意先名カナ", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_HalfEngNumFixedLength("得意先名カナ", csvRow[mark++].ToString(), 30, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("敬称", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("諸口", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("諸口", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("管理拠点", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("管理拠点", csvRow[mark++].ToString(), 2, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("得意先担当", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("旧担当", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_YYYYMMDD("担当者変更日", csvRow[mark].ToString(), out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }

        //        if (!Check_StrUnFixedLen("担当者変更日", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_YYYYMMDD("取引中止日", csvRow[mark].ToString(), out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //        if (!Check_StrUnFixedLen("取引中止日", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("車輌管理", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("車輌管理", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("個人・法人", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("個人・法人", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("得意先種別", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("得意先種別", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }

        //    if (!Check_IsNull("得意先属性", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("得意先属性", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("優先倉庫", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("業種", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("職種", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("地区", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("分析コード１", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("分析コード２", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("分析コード３", csvRow[mark++].ToString(), 3, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("分析コード４", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("分析コード５", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("分析コード６", csvRow[mark++].ToString(), 3, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("請求拠点", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("請求拠点", csvRow[mark++].ToString(), 2, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("請求コード", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("請求コード", csvRow[mark++].ToString(), 8, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("締日", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("締日", csvRow[mark++].ToString(), 2, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("集金月", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("集金月", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("集金日", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZeroIntAndLen("集金日", csvRow[mark++].ToString(), 2, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("回収条件", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_ZerIntAndLen("回収条件", csvRow[mark++].ToString(), 2, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("回収サイト", csvRow[mark++].ToString(), 3, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("次回勘定", csvRow[mark++].ToString(), 2, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("集金担当", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("転嫁方式参照区分", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("転嫁方式参照区分", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("消費税転嫁方式", csvRow[mark++].ToString(), 1, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("単価端数処理", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("金額端数処理", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("消費税端数処理", csvRow[mark++].ToString(), 8, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("与信管理", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("与信管理", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("入金消込", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("入金消込", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("売掛区分", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("売掛区分", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("郵便番号", csvRow[mark++].ToString(), 10, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("住所", csvRow[mark++].ToString(), 30, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("住所２", csvRow[mark++].ToString(), 22, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("住所３", csvRow[mark++].ToString(), 30, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先担当者", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("自宅ＴＥＬ", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("勤務先電話１", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("勤務先電話２", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("その他電話", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("自宅ＦＡＸ", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("勤務先ＦＡＸ", csvRow[mark++].ToString(), 16, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_HalfNumFixedLength("検索番号", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("主連絡先", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("主連絡先", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考１", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考２", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考３", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考４", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考５", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考６", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考７", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考８", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考９", csvRow[mark++].ToString(), 20, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("得意先備考１０", csvRow[mark++].ToString(), 20, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_CorIntAndLen("主送信先メールアドレス区分", csvRow[mark++].ToString(), 1, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("メールアドレス１", csvRow[mark++].ToString(), 64, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("メール送信区分コード１", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("メール送信区分コード１", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("メールアドレス種別コード１", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("メールアドレス種別コード１", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("メールアドレス２", csvRow[mark++].ToString(), 64, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    if (!Check_IsNull("メール送信区分コード２", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("メール送信区分コード２", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("メールアドレス種別コード２", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("メールアドレス種別コード２", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("銀行口座１", csvRow[mark++].ToString(), 60, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("銀行口座２", csvRow[mark++].ToString(), 60, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_StrUnFixedLen("銀行口座３", csvRow[mark++].ToString(), 60, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!Check_IsNull("領収書出力", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("領収書出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("ＤＭ出力", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("ＤＭ出力", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("納品書出力", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("納品書出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("受注伝票出力", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("受注伝票出力", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("貸出伝票出力", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("貸出伝票出力", csvRow[mark++].ToString(), 1, out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("見積伝票出力", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("見積伝票出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("ＵＯＥ伝票出力", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("ＵＯＥ伝票出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("ＱＲコード印刷", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("ＱＲコード印刷", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }

        //    if (!Check_IsNull("相手伝票番号管理", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("相手伝票番号管理", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("相手伝票番号区分", csvRow[mark].ToString(), out msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("相手伝票番号区分", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("合計請求書出力", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("合計請求書出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("明細請求書出力", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("明細請求書出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_IsNull("伝票合計請求書出力", csvRow[mark].ToString(), out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!Check_CorIntAndLen("伝票合計請求書出力", csvRow[mark++].ToString(), 1, out  msg))
        //    {
        //        ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ(優良)", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ(純正ALL)", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正３", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正４", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正５", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正６", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正７", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正８", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正９", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１０", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１１", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１２", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１３", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１４", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１５", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１６", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１７", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１８", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正１９", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２０", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２１", csvRow[mark++].ToString(), 4, out msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２２", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２３", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString().Trim()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２４", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }
        //    if (!string.IsNullOrEmpty(csvRow[mark].ToString()))
        //    {
        //        if (!Check_IntAndLen("得意先掛率グループ純正２５", csvRow[mark++].ToString(), 4, out  msg))
        //        {
        //            ConverToDataSetCustomerLog(csvRow, ref logTable, msg);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        mark++;
        //    }

        //    int index = 0;
        //    if (isUpdFlg)
        //    {
        //        // 更新の場合
        //        work.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
        //        work.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
        //        work.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
        //        work.LogicalDeleteCode = 0;                                   // 論理削除区分
        //        work.PureCode = searchWork.PureCode;                          // 純正区分
        //        work.TotalAmountDispWayCd = searchWork.TotalAmountDispWayCd;  // 総額表示方法区分
        //        work.TotalAmntDspWayRef = searchWork.TotalAmntDspWayRef;      // 総額表示方法参照区分
        //        work.BillPartsNoPrtCd = searchWork.BillPartsNoPrtCd;          // 品番印字区分(請求書)
        //        work.DeliPartsNoPrtCd = searchWork.DeliPartsNoPrtCd;          // 品番印字区分(納品書）
        //        work.DefSalesSlipCd = searchWork.DefSalesSlipCd;              // 伝票区分初期値
        //        work.LavorRateRank = searchWork.LavorRateRank;                // 工賃レバレートランク
        //        work.SlipTtlPrn = searchWork.SlipTtlPrn;                      // 伝票タイトルパターン
        //        work.DepoBankCode = searchWork.DepoBankCode;                  // 入金銀行コード
        //        work.DeliHonorificTtl = searchWork.DeliHonorificTtl;          // 納品書敬称
        //        work.BillHonorificTtl = searchWork.BillHonorificTtl;          // 請求書敬称
        //        work.EstmHonorificTtl = searchWork.EstmHonorificTtl;          // 見積書敬称
        //        work.RectHonorificTtl = searchWork.RectHonorificTtl;          // 領収書敬称
        //        work.DeliHonorTtlPrtDiv = searchWork.DeliHonorTtlPrtDiv;      // 納品書敬称印字区分
        //        work.BillHonorTtlPrtDiv = searchWork.BillHonorTtlPrtDiv;      // 請求書敬称印字区分
        //        work.EstmHonorTtlPrtDiv = searchWork.EstmHonorTtlPrtDiv;      // 見積書敬称印字区分
        //        work.RectHonorTtlPrtDiv = searchWork.RectHonorTtlPrtDiv;      // 領収書敬称印字区分
        //        work.CustomerEpCode = searchWork.CustomerEpCode;              // 得意先企業コード
        //        work.CustomerSecCode = searchWork.CustomerSecCode;            // 得意先拠点コード
        //        work.OnlineKindDiv = searchWork.OnlineKindDiv;                // オンライン種別区分
        //    }
        //    else
        //    {
        //        // 新規の場合
        //        work.PureCode = 0;                                            // 純正区分
        //        work.TotalAmountDispWayCd = 0;                                // 総額表示方法区分
        //        work.TotalAmntDspWayRef = 0;                                  // 総額表示方法参照区分
        //        work.BillPartsNoPrtCd = 0;                                    // 品番印字区分(請求書)
        //        work.DeliPartsNoPrtCd = 0;                                    // 品番印字区分(納品書）
        //        work.DefSalesSlipCd = 0;                                      // 伝票区分初期値
        //        work.LavorRateRank = 0;                                       // 工賃レバレートランク
        //        work.SlipTtlPrn = 0;                                          // 伝票タイトルパターン
        //        work.DepoBankCode = 0;                                        // 入金銀行コード
        //        work.DeliHonorificTtl = string.Empty;                         // 納品書敬称
        //        work.BillHonorificTtl = string.Empty;                         // 請求書敬称
        //        work.EstmHonorificTtl = string.Empty;                         // 見積書敬称
        //        work.RectHonorificTtl = string.Empty;                         // 領収書敬称
        //        work.DeliHonorTtlPrtDiv = 0;                                  // 納品書敬称印字区分
        //        work.BillHonorTtlPrtDiv = 0;                                  // 請求書敬称印字区分
        //        work.EstmHonorTtlPrtDiv = 0;                                  // 見積書敬称印字区分
        //        work.RectHonorTtlPrtDiv = 0;                                  // 領収書敬称印字区分
        //        work.CustomerEpCode = string.Empty;                           // 得意先企業コード
        //        work.CustomerSecCode = string.Empty;                          // 得意先拠点コード
        //        work.OnlineKindDiv = 0;                                       // オンライン種別区分

        //    }
        //    work.EnterpriseCode = enterpriseCode;
        //    work.CustomerCode = ConvertToInt32(csvRow, index++);            // 得意先コード
        //    work.CustomerSubCode = ConvertToEmpty(csvRow, index++);         // サブコード
        //    work.Name = ConvertToEmpty(csvRow, index++);                    // 得意先名１
        //    work.Name2 = ConvertToEmpty(csvRow, index++);                   // 得意先名２
        //    work.CustomerSnm = ConvertToEmpty(csvRow, index++);             // 得意先略称
        //    work.Kana = ConvertToEmpty(csvRow, index++);                    // 得意先名カナ
        //    work.HonorificTitle = ConvertToEmpty(csvRow, index++);          // 敬称
        //    work.OutputNameCode = ConvertToInt32(csvRow, index++);          // 諸口
        //    work.MngSectionCode = ConvertToStrCode(csvRow, index++, 2);     // 管理拠点
        //    work.CustomerAgentCd = ConvertToStrCode(csvRow, index++, 4);    // 得意先担当
        //    work.OldCustomerAgentCd = ConvertToStrCode(csvRow, index++, 4); // 旧担当
        //    work.CustAgentChgDate = ConvertToDateTime(csvRow, index++);     // 担当者変更日
        //    work.TransStopDate = ConvertToDateTime(csvRow, index++);        // 取引中止日
        //    work.CarMngDivCd = ConvertToInt32(csvRow, index++);             // 車輛管理
        //    work.CorporateDivCode = ConvertToInt32(csvRow, index++);        // 個人・法人
        //    work.AcceptWholeSale = ConvertToInt32(csvRow, index++);         // 得意先種別
        //    work.CustomerAttributeDiv = ConvertToInt32(csvRow, index++);    // 得意先属性
        //    work.CustWarehouseCd = ConvertToStrCode(csvRow, index++, 4);    // 優先倉庫
        //    work.BusinessTypeCode = ConvertToInt32(csvRow, index++);        // 業種
        //    work.JobTypeCode = ConvertToInt32(csvRow, index++);             // 職種
        //    work.SalesAreaCode = ConvertToInt32(csvRow, index++);           // 地区
        //    work.CustAnalysCode1 = ConvertToInt32(csvRow, index++);         // 分析コード１
        //    work.CustAnalysCode2 = ConvertToInt32(csvRow, index++);         // 分析コード２
        //    work.CustAnalysCode3 = ConvertToInt32(csvRow, index++);         // 分析コード３
        //    work.CustAnalysCode4 = ConvertToInt32(csvRow, index++);         // 分析コード４
        //    work.CustAnalysCode5 = ConvertToInt32(csvRow, index++);         // 分析コード５
        //    work.CustAnalysCode6 = ConvertToInt32(csvRow, index++);         // 分析コード６
        //    work.ClaimSectionCode = ConvertToStrCode(csvRow, index++, 2);   // 請求拠点
        //    work.ClaimCode = ConvertToInt32(csvRow, index++);               // 請求コード
        //    work.TotalDay = ConvertToInt32(csvRow, index++);                // 締日
        //    work.CollectMoneyCode = ConvertToInt32(csvRow, index++);        // 集金月
        //    work.CollectMoneyDay = ConvertToInt32(csvRow, index++);         // 集金日
        //    work.CollectCond = ConvertToInt32(csvRow, index++);             // 回収条件
        //    work.CollectSight = ConvertToInt32(csvRow, index++);            // 回収サイト
        //    work.NTimeCalcStDate = ConvertToInt32(csvRow, index++);         // 次回勘定
        //    work.BillCollecterCd = ConvertToStrCode(csvRow, index++, 4);    // 集金担当
        //    work.CustCTaXLayRefCd = ConvertToInt32(csvRow, index++);        // 転嫁方式参照区分
        //    work.ConsTaxLayMethod = ConvertToInt32(csvRow, index++);        // 消費税転嫁方式
        //    work.SalesUnPrcFrcProcCd = ConvertToInt32(csvRow, index++);     // 単価端数処理
        //    work.SalesMoneyFrcProcCd = ConvertToInt32(csvRow, index++);     // 金額端数処理
        //    work.SalesCnsTaxFrcProcCd = ConvertToInt32(csvRow, index++);    // 消費税端数処理
        //    work.CreditMngCode = ConvertToInt32(csvRow, index++);           // 与信管理
        //    work.DepoDelCode = ConvertToInt32(csvRow, index++);             // 入金消込
        //    work.AccRecDivCd = ConvertToInt32(csvRow, index++);             // 売掛区分
        //    work.PostNo = ConvertToEmpty(csvRow, index++);                  // 郵便番号
        //    work.Address1 = ConvertToEmpty(csvRow, index++);                // 住所
        //    work.Address3 = ConvertToEmpty(csvRow, index++);                // 住所２
        //    work.Address4 = ConvertToEmpty(csvRow, index++);                // 住所３
        //    work.CustomerAgent = ConvertToEmpty(csvRow, index++);           // 得意先担当者
        //    work.HomeTelNo = ConvertToEmpty(csvRow, index++);               // 自宅ＴＥＬ
        //    work.OfficeTelNo = ConvertToEmpty(csvRow, index++);             // 勤務先電話１
        //    work.PortableTelNo = ConvertToEmpty(csvRow, index++);           // 勤務先電話２
        //    work.OthersTelNo = ConvertToEmpty(csvRow, index++);             // その他電話
        //    work.HomeFaxNo = ConvertToEmpty(csvRow, index++);               // 自宅ＦＡＸ
        //    work.OfficeFaxNo = ConvertToEmpty(csvRow, index++);             // 勤務先ＦＡＸ
        //    work.SearchTelNo = ConvertToEmpty(csvRow, index++);             // 検索番号
        //    work.MainContactCode = ConvertToInt32(csvRow, index++);         // 主連絡先
        //    work.Note1 = ConvertToEmpty(csvRow, index++);                   // 得意先備考１
        //    work.Note2 = ConvertToEmpty(csvRow, index++);                   // 得意先備考２
        //    work.Note3 = ConvertToEmpty(csvRow, index++);                   // 得意先備考３
        //    work.Note4 = ConvertToEmpty(csvRow, index++);                   // 得意先備考４
        //    work.Note5 = ConvertToEmpty(csvRow, index++);                   // 得意先備考５
        //    work.Note6 = ConvertToEmpty(csvRow, index++);                   // 得意先備考６
        //    work.Note7 = ConvertToEmpty(csvRow, index++);                   // 得意先備考７
        //    work.Note8 = ConvertToEmpty(csvRow, index++);                   // 得意先備考８
        //    work.Note9 = ConvertToEmpty(csvRow, index++);                   // 得意先備考９
        //    work.Note10 = ConvertToEmpty(csvRow, index++);                  // 得意先備考１０
        //    work.MainSendMailAddrCd = ConvertToInt32(csvRow, index++);      // 主送信先メールアドレス区分
        //    work.MailAddress1 = ConvertToEmpty(csvRow, index++);            // メールアドレス１
        //    work.MailSendCode1 = ConvertToInt32(csvRow, index++);           // メール送信区分コード１
        //    work.MailAddrKindCode1 = ConvertToInt32(csvRow, index++);       // メールアドレス種別コード１
        //    work.MailAddress2 = ConvertToEmpty(csvRow, index++);            // メールアドレス２
        //    work.MailSendCode2 = ConvertToInt32(csvRow, index++);           // メール送信区分コード２
        //    work.MailAddrKindCode2 = ConvertToInt32(csvRow, index++);       // メールアドレス種別コード２
        //    work.AccountNoInfo1 = ConvertToEmpty(csvRow, index++);          // 銀行口座１
        //    work.AccountNoInfo2 = ConvertToEmpty(csvRow, index++);          // 銀行口座２
        //    work.AccountNoInfo3 = ConvertToEmpty(csvRow, index++);          // 銀行口座３
        //    work.ReceiptOutputCode = ConvertToInt32(csvRow, index++);       // 領収書出力
        //    work.DmOutCode = ConvertToInt32(csvRow, index++);               // ＤＭ出力
        //    work.SalesSlipPrtDiv = ConvertToInt32(csvRow, index++);         // 納品書出力
        //    work.AcpOdrrSlipPrtDiv = ConvertToInt32(csvRow, index++);       // 受注伝票出力
        //    work.ShipmSlipPrtDiv = ConvertToInt32(csvRow, index++);         // 貸出伝票出力
        //    work.EstimatePrtDiv = ConvertToInt32(csvRow, index++);          // 見積伝票出力
        //    work.UOESlipPrtDiv = ConvertToInt32(csvRow, index++);           // ＵＯＥ伝票出力
        //    work.QrcodePrtCd = ConvertToInt32(csvRow, index++);             // ＱＲコード印刷
        //    work.CustSlipNoMngCd = ConvertToInt32(csvRow, index++);         // 相手伝票番号管理
        //    work.CustomerSlipNoDiv = ConvertToInt32(csvRow, index++);       // 相手伝票番号区分

        //    work.TotalBillOutputDiv = ConvertToInt32(csvRow, index++);      // 合計請求書出力
        //    work.DetailBillOutputCode = ConvertToInt32(csvRow, index++);    // 明細請求書出力
        //    work.SlipTtlBillOutputDiv = ConvertToInt32(csvRow, index++);    // 伝票合計請求書出力区分

        //    work.CustRateGrpFine = ConvertRateToInt32(csvRow, index++);        //得意先掛率グループ(優良)
        //    work.CustRateGrpPureAll = ConvertRateToInt32(csvRow, index++);     //得意先掛率グループ(純正ALL)
        //    work.CustRateGrpPure1 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正１
        //    work.CustRateGrpPure2 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正2
        //    work.CustRateGrpPure3 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正3
        //    work.CustRateGrpPure4 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正4
        //    work.CustRateGrpPure5 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正5
        //    work.CustRateGrpPure6 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正6
        //    work.CustRateGrpPure7 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正7
        //    work.CustRateGrpPure8 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正8
        //    work.CustRateGrpPure9 = ConvertRateToInt32(csvRow, index++);       //得意先掛率グループ純正9
        //    work.CustRateGrpPure10 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１0
        //    work.CustRateGrpPure11 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１1
        //    work.CustRateGrpPure12 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１2
        //    work.CustRateGrpPure13 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１3
        //    work.CustRateGrpPure14 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１4
        //    work.CustRateGrpPure15 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１5
        //    work.CustRateGrpPure16 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１6
        //    work.CustRateGrpPure17 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１7
        //    work.CustRateGrpPure18 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１8
        //    work.CustRateGrpPure19 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正１9
        //    work.CustRateGrpPure20 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正20
        //    work.CustRateGrpPure21 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正2１
        //    work.CustRateGrpPure22 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正22
        //    work.CustRateGrpPure23 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正23
        //    work.CustRateGrpPure24 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正24
        //    work.CustRateGrpPure25 = ConvertRateToInt32(csvRow, index++);      //得意先掛率グループ純正25
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>

        /// <summary>
        /// データの検査
        /// </summary>
        /// <param name="customerGroupWork">CSVファイルの行</param>
        /// <param name="checkDiv">チェック区分</param>
        /// <param name="consTaxLay">消費税転嫁方式</param>
        /// <param name="importCustWorCheckList">チェックリスト</param>
        /// <param name="work">CustomerWork</param>
        /// <param name="logArrayList">ログリスト</param>
        /// <param name="enterpriseCode"> 企業コード</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <remarks>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/05 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.30の対応</br>
        /// <br>Update Note: 2012/07/09 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.39、NO.46、NO.47、NO.48、NO.49、NO.51の対応</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7、NO.48、NO.94、NO.95の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.94、NO.106、NO.107、NO.108の対応</br>
        /// <br>Update Note: 2012/07/24 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  動作検証、障害一覧の指摘NO.61、NO.106の対応</br>
        /// <br>Update Note: 2012/8/3 朱猛</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             メールアドレス種別コードのチェック桁数を１桁から２桁へ変更</br>
        /// <br>Update Note: 2022/03/04 田村顕成</br>
        /// <br>管理番号   : 11570183-00 電子帳簿連携対応</br>
        /// <br>             ラベル項目の変更（DM出力→電子帳簿出力）</br>
        /// </remarks>
        //private void CheckData(CustomerGroupWork customerGroupWork, ref CustomerRateWork work, ref ArrayList logArrayList, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
        //private void CheckData(CustomerGroupWork customerGroupWork, Int32 consTaxLay, ref CustomerRateWork work, ref ArrayList logArrayList, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応  // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        private void CheckData(CustomerGroupWork customerGroupWork, Int32 checkDiv, Int32 consTaxLay, List<CustomerGroupWork> importCustWorCheckList, ref CustomerRateWork work, ref ArrayList logArrayList, string enterpriseCode, bool isUpdFlg, CustomerWork searchWork)// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
        {
            // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
            if (checkDiv == 0)
            {
                string msg = string.Empty;
                // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<

                // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.107の対応-------->>>>
                if (ConvertToInt32(customerGroupWork.AcceptWholeSale) == 1 || ConvertToInt32(customerGroupWork.AcceptWholeSale) == 2)//得意先種別が:納入先
                {

                    if (!Check_IsNull("得意先コード", customerGroupWork.CustomerCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_ZeroIntAndLen("得意先コード", customerGroupWork.CustomerCode, 8, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                      
                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSubCode.Trim()))
                    {
                        if (!Check_StrUnFixedLen("サブコード", customerGroupWork.CustomerSubCode.Trim(), 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先名１", customerGroupWork.Name, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先名２", customerGroupWork.Name2, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSnm.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先略称", customerGroupWork.CustomerSnm, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Kana.Trim()))
                    {
                        if (!Check_HalfEngNumFixedLength("得意先名カナ", customerGroupWork.Kana, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HonorificTitle.Trim()))
                    {
                        if (!Check_StrUnFixedLen("敬称", customerGroupWork.HonorificTitle, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OutputNameCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("諸口", customerGroupWork.OutputNameCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MngSectionCode.Trim()))
                    {
                        if (!Check_IntAndLenth("管理拠点", customerGroupWork.MngSectionCode, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("得意先担当", customerGroupWork.CustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OldCustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("旧担当", customerGroupWork.OldCustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAgentChgDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("担当者変更日", customerGroupWork.CustAgentChgDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }

                        if (!Check_StrUnFixedLen("担当者変更日", customerGroupWork.CustAgentChgDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TransStopDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("取引中止日", customerGroupWork.TransStopDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        if (!Check_StrUnFixedLen("取引中止日", customerGroupWork.TransStopDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CarMngDivCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("車輌管理", customerGroupWork.CarMngDivCd, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CorporateDivCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("個人・法人", customerGroupWork.CorporateDivCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CorporateDivCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("得意先種別", customerGroupWork.CorporateDivCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAttributeDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("得意先属性", customerGroupWork.CustomerAttributeDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustWarehouseCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("優先倉庫", customerGroupWork.CustWarehouseCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BusinessTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("業種", customerGroupWork.BusinessTypeCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.JobTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("職種", customerGroupWork.JobTypeCode, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesAreaCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("地区", customerGroupWork.SalesAreaCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode1.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード１", customerGroupWork.CustAnalysCode1, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode2.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード２", customerGroupWork.CustAnalysCode2, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode3.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード３", customerGroupWork.CustAnalysCode3, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode4.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード４", customerGroupWork.CustAnalysCode4, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode5.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード５", customerGroupWork.CustAnalysCode5, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode6.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード６", customerGroupWork.CustAnalysCode6, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ClaimSectionCode.Trim()))
                    {
                        if (!Check_IntAndLenth("請求拠点", customerGroupWork.ClaimSectionCode, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ClaimCode.Trim()))
                    {
                        if (!Check_IntAndLenth("請求コード", customerGroupWork.ClaimCode, 8, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TotalDay.Trim()))
                    {
                        if (!Check_IntAndLenth("締日", customerGroupWork.TotalDay, 2, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CollectMoneyCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("集金月", customerGroupWork.CollectMoneyCode, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CollectMoneyDay.Trim()))
                    {
                        if (!Check_IntAndLenth("集金日", customerGroupWork.CollectMoneyDay, 2, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CollectCond.Trim()))
                    {
                        if (!Check_ZerIntAndLen("回収条件", customerGroupWork.CollectCond, 2, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CollectSight.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("回収サイト", customerGroupWork.CollectSight, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.NTimeCalcStDate.Trim()))
                    {
                        if (!Check_CorIntAndLen("次回勘定", customerGroupWork.NTimeCalcStDate, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BillCollecterCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("集金担当", customerGroupWork.BillCollecterCd, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustCTaXLayRefCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("転嫁方式参照区分", customerGroupWork.CustCTaXLayRefCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ConsTaxLayMethod.Trim()))
                    {
                        if (!Check_CorIntAndLen("消費税転嫁方式", customerGroupWork.ConsTaxLayMethod, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.SalesUnPrcFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("単価端数処理", customerGroupWork.SalesUnPrcFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesMoneyFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("金額端数処理", customerGroupWork.SalesMoneyFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesCnsTaxFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("消費税端数処理", customerGroupWork.SalesCnsTaxFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CreditMngCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("与信管理", customerGroupWork.CreditMngCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.DepoDelCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("入金消込", customerGroupWork.DepoDelCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.AccRecDivCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("売掛区分", customerGroupWork.AccRecDivCd, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.PostNo.Trim()))
                    {
                        if (!Check_IntAndLen("郵便番号", customerGroupWork.PostNo, 10, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("住所", customerGroupWork.Address1, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("住所２", customerGroupWork.Address3, 22, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("住所３", customerGroupWork.Address4, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgent.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先担当者", customerGroupWork.CustomerAgent, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("自宅ＴＥＬ", customerGroupWork.HomeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("勤務先電話１", customerGroupWork.OfficeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.PortableTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("勤務先電話２", customerGroupWork.PortableTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OthersTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("その他電話", customerGroupWork.OthersTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("自宅ＦＡＸ", customerGroupWork.HomeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("勤務先ＦＡＸ", customerGroupWork.OfficeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SearchTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("検索番号", customerGroupWork.SearchTelNo, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MainContactCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("主連絡先", customerGroupWork.MainContactCode, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考１", customerGroupWork.Note1, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考２", customerGroupWork.Note2, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考３", customerGroupWork.Note3, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考４", customerGroupWork.Note4, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note5.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考５", customerGroupWork.Note5, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note6.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考６", customerGroupWork.Note6, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note7.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考７", customerGroupWork.Note7, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note8.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考８", customerGroupWork.Note8, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note9.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考９", customerGroupWork.Note9, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note10.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考１０", customerGroupWork.Note10, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MainSendMailAddrCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("主送信先メールアドレス区分", customerGroupWork.MainSendMailAddrCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("メールアドレス１", customerGroupWork.MailAddress1, 64, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailSendCode1.Trim()))
                    {
                        if (!Check_CorIntAndLen("メール送信区分コード１", customerGroupWork.MailSendCode1, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddrKindCode1.Trim()))
                    {
                        //if (!Check_CorIntAndLen("メールアドレス種別コード１", customerGroupWork.MailAddrKindCode1, 1, out  msg)) // DEL BY 朱猛 ON 2012/8/3 FOR 桁数チェックを１桁から２桁へ変更
                        if (!Check_CorIntAndLen("メールアドレス種別コード１", customerGroupWork.MailAddrKindCode1, 2, out  msg)) // ADD BY 朱猛 ON 2012/8/3 FOR 桁数チェックを１桁から２桁へ変更
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("メールアドレス２", customerGroupWork.MailAddress2, 64, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.MailSendCode2.Trim()))
                    {
                        if (!Check_CorIntAndLen("メール送信区分コード２", customerGroupWork.MailSendCode2, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddrKindCode2.Trim()))
                    {
                        //if (!Check_CorIntAndLen("メールアドレス種別コード２", customerGroupWork.MailAddrKindCode2, 1, out msg)) // DEL BY 朱猛 ON 2012/8/3 FOR 桁数チェックを１桁から２桁へ変更
                        if (!Check_CorIntAndLen("メールアドレス種別コード２", customerGroupWork.MailAddrKindCode2, 2, out msg)) // ADD BY 朱猛 ON 2012/8/3 FOR 桁数チェックを１桁から２桁へ変更
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("銀行口座１", customerGroupWork.AccountNoInfo1, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("銀行口座２", customerGroupWork.AccountNoInfo2, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("銀行口座３", customerGroupWork.AccountNoInfo3, 60, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ReceiptOutputCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("領収書出力", customerGroupWork.ReceiptOutputCode, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.DmOutCode.Trim()))
                    {
//                        if (!Check_CorIntAndLen("ＤＭ出力", customerGroupWork.DmOutCode, 1, out msg)) // DEL 2022/03/04 田村顕成　電子帳簿連携
                        if (!Check_CorIntAndLen("電子帳簿出力", customerGroupWork.DmOutCode, 1, out msg)) // ADD 2022/03/04 田村顕成　電子帳簿連携 
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesSlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("納品書出力", customerGroupWork.SalesSlipPrtDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AcpOdrrSlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("受注伝票出力", customerGroupWork.AcpOdrrSlipPrtDiv, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.ShipmSlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("貸出伝票出力", customerGroupWork.ShipmSlipPrtDiv, 1, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.EstimatePrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("見積伝票出力", customerGroupWork.EstimatePrtDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.UOESlipPrtDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("ＵＯＥ伝票出力", customerGroupWork.UOESlipPrtDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.QrcodePrtCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("ＱＲコード印刷", customerGroupWork.QrcodePrtCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!string.IsNullOrEmpty(customerGroupWork.CustSlipNoMngCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("相手伝票番号管理", customerGroupWork.CustSlipNoMngCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSlipNoDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("相手伝票番号区分", customerGroupWork.CustomerSlipNoDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TotalBillOutputDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("合計請求書出力", customerGroupWork.TotalBillOutputDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }

                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.DetailBillOutputCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("明細請求書出力", customerGroupWork.DetailBillOutputCode, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SlipTtlBillOutputDiv.Trim()))
                    {
                        if (!Check_CorIntAndLen("伝票合計請求書出力", customerGroupWork.SlipTtlBillOutputDiv, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                   
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpFineAll.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ(優良ALL)", customerGroupWork.CustRateGrpFineAll, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ(純正ALL)", customerGroupWork.CustRateGrpPureAll, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１", customerGroupWork.CustRateGrpPure1, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２", customerGroupWork.CustRateGrpPure2, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正３", customerGroupWork.CustRateGrpPure3, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正４", customerGroupWork.CustRateGrpPure4, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正５", customerGroupWork.CustRateGrpPure5, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正６", customerGroupWork.CustRateGrpPure6, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正７", customerGroupWork.CustRateGrpPure7, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正８", customerGroupWork.CustRateGrpPure8, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正９", customerGroupWork.CustRateGrpPure9, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１０", customerGroupWork.CustRateGrpPure10, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１１", customerGroupWork.CustRateGrpPure11, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１２", customerGroupWork.CustRateGrpPure12, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１３", customerGroupWork.CustRateGrpPure13, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１４", customerGroupWork.CustRateGrpPure14, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１５", customerGroupWork.CustRateGrpPure15, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１６", customerGroupWork.CustRateGrpPure16, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１７", customerGroupWork.CustRateGrpPure17, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１８", customerGroupWork.CustRateGrpPure18, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１９", customerGroupWork.CustRateGrpPure19, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２０", customerGroupWork.CustRateGrpPure20, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２１", customerGroupWork.CustRateGrpPure21, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２２", customerGroupWork.CustRateGrpPure22, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２３", customerGroupWork.CustRateGrpPure23, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２４", customerGroupWork.CustRateGrpPure24, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２５", customerGroupWork.CustRateGrpPure25, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                }
                else
                {
                    // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.107の対応--------<<<<

                    // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.107の対応-------->>>>
                    if (!Check_IsNull("得意先コード", customerGroupWork.CustomerCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_ZeroIntAndLen("得意先コード", customerGroupWork.CustomerCode, 8, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.107の対応--------<<<<
                   
                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSubCode.Trim()))
                    {
                        if (!Check_StrUnFixedLen("サブコード", customerGroupWork.CustomerSubCode.Trim(), 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先名１", customerGroupWork.Name, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Name2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先名２", customerGroupWork.Name2, 30, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerSnm.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先略称", customerGroupWork.CustomerSnm, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("得意先名カナ", customerGroupWork.Kana, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_HalfEngNumFixedLength("得意先名カナ", customerGroupWork.Kana, 30, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.HonorificTitle.Trim()))
                    {
                        if (!Check_StrUnFixedLen("敬称", customerGroupWork.HonorificTitle, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("諸口", customerGroupWork.OutputNameCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("諸口", customerGroupWork.OutputNameCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("管理拠点", customerGroupWork.MngSectionCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("管理拠点", customerGroupWork.MngSectionCode, 2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("得意先担当", customerGroupWork.CustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OldCustomerAgentCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("旧担当", customerGroupWork.OldCustomerAgentCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAgentChgDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("担当者変更日", customerGroupWork.CustAgentChgDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }

                        if (!Check_StrUnFixedLen("担当者変更日", customerGroupWork.CustAgentChgDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.TransStopDate.Trim()))
                    {
                        if (!Check_YYYYMMDD("取引中止日", customerGroupWork.TransStopDate, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        if (!Check_StrUnFixedLen("取引中止日", customerGroupWork.TransStopDate, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("車輌管理", customerGroupWork.CarMngDivCd, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("車輌管理", customerGroupWork.CarMngDivCd, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("個人・法人", customerGroupWork.CorporateDivCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("個人・法人", customerGroupWork.CorporateDivCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("得意先種別", customerGroupWork.AcceptWholeSale, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("得意先種別", customerGroupWork.AcceptWholeSale, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_IsNull("得意先属性", customerGroupWork.CustomerAttributeDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("得意先属性", customerGroupWork.CustomerAttributeDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustWarehouseCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("優先倉庫", customerGroupWork.CustWarehouseCd, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BusinessTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("業種", customerGroupWork.BusinessTypeCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.JobTypeCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("職種", customerGroupWork.JobTypeCode, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesAreaCode.Trim()))
                    {
                        if (!Check_CorIntAndLen("地区", customerGroupWork.SalesAreaCode, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode1.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード１", customerGroupWork.CustAnalysCode1, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode2.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード２", customerGroupWork.CustAnalysCode2, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode3.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード３", customerGroupWork.CustAnalysCode3, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode4.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード４", customerGroupWork.CustAnalysCode4, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode5.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード５", customerGroupWork.CustAnalysCode5, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustAnalysCode6.Trim()))
                    {
                        if (!Check_CorIntAndLen("分析コード６", customerGroupWork.CustAnalysCode6, 3, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("請求拠点", customerGroupWork.ClaimSectionCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("請求拠点", customerGroupWork.ClaimSectionCode, 2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("請求コード", customerGroupWork.ClaimCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("請求コード", customerGroupWork.ClaimCode, 8, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("締日", customerGroupWork.TotalDay, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("締日", customerGroupWork.TotalDay, 2, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("集金月", customerGroupWork.CollectMoneyCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("集金月", customerGroupWork.CollectMoneyCode, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("集金日", customerGroupWork.CollectMoneyDay, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZeroIntAndLen("集金日", customerGroupWork.CollectMoneyDay, 2, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("回収条件", customerGroupWork.CollectCond, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_ZerIntAndLen("回収条件", customerGroupWork.CollectCond, 2, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CollectSight.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("回収サイト", customerGroupWork.CollectSight, 3, out msg))
                        {
                            customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.NTimeCalcStDate.Trim()))
                    {
                        if (!Check_CorIntAndLen("次回勘定", customerGroupWork.NTimeCalcStDate, 2, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.BillCollecterCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("集金担当", customerGroupWork.BillCollecterCd, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("転嫁方式参照区分", customerGroupWork.CustCTaXLayRefCd, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("転嫁方式参照区分", customerGroupWork.CustCTaXLayRefCd, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg; logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.ConsTaxLayMethod.Trim()))
                    {
                        if (!Check_CorIntAndLen("消費税転嫁方式", customerGroupWork.ConsTaxLayMethod, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.62の対応-------->>>>
                    if (ConvertToInt32(customerGroupWork.CustCTaXLayRefCd.Trim()) == 0)
                    {
                        if (ConvertToInt32(customerGroupWork.ConsTaxLayMethod.Trim()) != consTaxLay)
                        {
                            customerGroupWork.ErrorLog = string.Format(FORMAT_ERRMSG_ERRORVAL, "消費税転嫁方式");
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.62の対応--------<<<<
                    if (!string.IsNullOrEmpty(customerGroupWork.SalesUnPrcFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("単価端数処理", customerGroupWork.SalesUnPrcFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesMoneyFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("金額端数処理", customerGroupWork.SalesMoneyFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SalesCnsTaxFrcProcCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("消費税端数処理", customerGroupWork.SalesCnsTaxFrcProcCd, 8, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("与信管理", customerGroupWork.CreditMngCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("与信管理", customerGroupWork.CreditMngCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("入金消込", customerGroupWork.DepoDelCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("入金消込", customerGroupWork.DepoDelCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("売掛区分", customerGroupWork.AccRecDivCd, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("売掛区分", customerGroupWork.AccRecDivCd, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.62の対応-------->>>>
                    if (ConvertToInt32(customerGroupWork.CustCTaXLayRefCd.Trim()) == 1 && (ConvertToInt32(customerGroupWork.ConsTaxLayMethod.Trim()) == 2 || ConvertToInt32(customerGroupWork.ConsTaxLayMethod.Trim()) == 3))
                    {
                        if (ConvertToInt32(customerGroupWork.AccRecDivCd.Trim()) != 1)
                        {
                            customerGroupWork.ErrorLog = string.Format(FORMAT_ERRMSG_ERRORVAL, "売掛区分");
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.62の対応--------<<<<
                    if (!string.IsNullOrEmpty(customerGroupWork.PostNo.Trim()))
                    {
                        if (!Check_IntAndLen("郵便番号", customerGroupWork.PostNo, 10, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("住所", customerGroupWork.Address1, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("住所２", customerGroupWork.Address3, 22, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Address4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("住所３", customerGroupWork.Address4, 30, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustomerAgent.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先担当者", customerGroupWork.CustomerAgent, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("自宅ＴＥＬ", customerGroupWork.HomeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("勤務先電話１", customerGroupWork.OfficeTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.PortableTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("勤務先電話２", customerGroupWork.PortableTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OthersTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("その他電話", customerGroupWork.OthersTelNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.HomeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("自宅ＦＡＸ", customerGroupWork.HomeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.OfficeFaxNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("勤務先ＦＡＸ", customerGroupWork.OfficeFaxNo, 16, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.SearchTelNo.Trim()))
                    {
                        if (!Check_HalfNumFixedLength("検索番号", customerGroupWork.SearchTelNo, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("主連絡先", customerGroupWork.MainContactCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("主連絡先", customerGroupWork.MainContactCode, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.Note1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考１", customerGroupWork.Note1, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考２", customerGroupWork.Note2, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考３", customerGroupWork.Note3, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note4.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考４", customerGroupWork.Note4, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note5.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考５", customerGroupWork.Note5, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note6.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考６", customerGroupWork.Note6, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note7.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考７", customerGroupWork.Note7, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note8.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考８", customerGroupWork.Note8, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note9.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考９", customerGroupWork.Note9, 20, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.Note10.Trim()))
                    {
                        if (!Check_StrUnFixedLen("得意先備考１０", customerGroupWork.Note10, 20, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MainSendMailAddrCd.Trim()))
                    {
                        if (!Check_CorIntAndLen("主送信先メールアドレス区分", customerGroupWork.MainSendMailAddrCd, 1, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("メールアドレス１", customerGroupWork.MailAddress1, 64, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("メール送信区分コード１", customerGroupWork.MailSendCode1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("メール送信区分コード１", customerGroupWork.MailSendCode1, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("メールアドレス種別コード１", customerGroupWork.MailAddrKindCode1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("メールアドレス種別コード１", customerGroupWork.MailAddrKindCode1, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.MailAddress2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("メールアドレス２", customerGroupWork.MailAddress2, 64, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }


                    if (!Check_IsNull("メール送信区分コード２", customerGroupWork.MailSendCode2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("メール送信区分コード２", customerGroupWork.MailSendCode2, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("メールアドレス種別コード２", customerGroupWork.MailAddrKindCode2, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("メールアドレス種別コード２", customerGroupWork.MailAddrKindCode2, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo1.Trim()))
                    {
                        if (!Check_StrUnFixedLen("銀行口座１", customerGroupWork.AccountNoInfo1, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo2.Trim()))
                    {
                        if (!Check_StrUnFixedLen("銀行口座２", customerGroupWork.AccountNoInfo2, 60, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.AccountNoInfo3.Trim()))
                    {
                        if (!Check_StrUnFixedLen("銀行口座３", customerGroupWork.AccountNoInfo3, 60, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!Check_IsNull("領収書出力", customerGroupWork.ReceiptOutputCode, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("領収書出力", customerGroupWork.ReceiptOutputCode, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
//                    if (!Check_IsNull("ＤＭ出力", customerGroupWork.DmOutCode, out  msg)) // DEL 2022/03/04 田村顕成　電子帳簿連携
                    if (!Check_IsNull("電子帳簿出力", customerGroupWork.DmOutCode, out  msg)) // ADD 2022/03/04 田村顕成　電子帳簿連携
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
//                    if (!Check_CorIntAndLen("ＤＭ出力", customerGroupWork.DmOutCode, 1, out msg)) // DEL 2022/03/04 田村顕成　電子帳簿連携
                    if (!Check_CorIntAndLen("電子帳簿出力", customerGroupWork.DmOutCode, 1, out msg)) // ADD 2022/03/04 田村顕成　電子帳簿連携
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("納品書出力", customerGroupWork.SalesSlipPrtDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("納品書出力", customerGroupWork.SalesSlipPrtDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("受注伝票出力", customerGroupWork.AcpOdrrSlipPrtDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("受注伝票出力", customerGroupWork.AcpOdrrSlipPrtDiv, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("貸出伝票出力", customerGroupWork.ShipmSlipPrtDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("貸出伝票出力", customerGroupWork.ShipmSlipPrtDiv, 1, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("見積伝票出力", customerGroupWork.EstimatePrtDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("見積伝票出力", customerGroupWork.EstimatePrtDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("ＵＯＥ伝票出力", customerGroupWork.UOESlipPrtDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("ＵＯＥ伝票出力", customerGroupWork.UOESlipPrtDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("ＱＲコード印刷", customerGroupWork.QrcodePrtCd, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("ＱＲコード印刷", customerGroupWork.QrcodePrtCd, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }

                    if (!Check_IsNull("相手伝票番号管理", customerGroupWork.CustSlipNoMngCd, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("相手伝票番号管理", customerGroupWork.CustSlipNoMngCd, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("相手伝票番号区分", customerGroupWork.CustomerSlipNoDiv, out msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("相手伝票番号区分", customerGroupWork.CustomerSlipNoDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("合計請求書出力", customerGroupWork.TotalBillOutputDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("合計請求書出力", customerGroupWork.TotalBillOutputDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("明細請求書出力", customerGroupWork.DetailBillOutputCode, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("明細請求書出力", customerGroupWork.DetailBillOutputCode, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_IsNull("伝票合計請求書出力", customerGroupWork.SlipTtlBillOutputDiv, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    if (!Check_CorIntAndLen("伝票合計請求書出力", customerGroupWork.SlipTtlBillOutputDiv, 1, out  msg))
                    {
                        customerGroupWork.ErrorLog = msg;
                        logArrayList.Add(customerGroupWork);
                        return;
                    }
                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpFine.Trim()))// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpFineAll.Trim()))// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                    {
                        //if (!Check_IntAndLen("得意先掛率グループ(優良)", customerGroupWork.CustRateGrpFine, 4, out  msg))// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                        if (!Check_IntAndLen("得意先掛率グループ(優良ALL)", customerGroupWork.CustRateGrpFineAll, 4, out  msg))// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ(純正ALL)", customerGroupWork.CustRateGrpPureAll, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１", customerGroupWork.CustRateGrpPure1, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２", customerGroupWork.CustRateGrpPure2, 4, out msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  李亜博 Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3.Trim()))// ADD  2012/07/05  李亜博 Redmine#30393
                    {
                        //if (!Check_IntAndLen("得意先掛率グループ純正３", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  李亜博 Redmine#30393
                        if (!Check_IntAndLen("得意先掛率グループ純正３", customerGroupWork.CustRateGrpPure3, 4, out  msg))// ADD  2012/07/05  李亜博 Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  李亜博 Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4.Trim()))// ADD  2012/07/05  李亜博 Redmine#30393
                    {
                        //if (!Check_IntAndLen("得意先掛率グループ純正４", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  李亜博 Redmine#30393
                        if (!Check_IntAndLen("得意先掛率グループ純正４", customerGroupWork.CustRateGrpPure4, 4, out msg))// ADD  2012/07/05  李亜博 Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  李亜博 Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5.Trim()))// ADD  2012/07/05  李亜博 Redmine#30393
                    {
                        //if (!Check_IntAndLen("得意先掛率グループ純正５", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  李亜博 Redmine#30393
                        if (!Check_IntAndLen("得意先掛率グループ純正５", customerGroupWork.CustRateGrpPure5, 4, out  msg))// ADD  2012/07/05  李亜博 Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  李亜博 Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6.Trim()))// ADD  2012/07/05  李亜博 Redmine#30393
                    {
                        //if (!Check_IntAndLen("得意先掛率グループ純正６", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  李亜博 Redmine#30393
                        if (!Check_IntAndLen("得意先掛率グループ純正６", customerGroupWork.CustRateGrpPure6, 4, out  msg))// ADD  2012/07/05  李亜博 Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    //if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1.Trim()))// DEL  2012/07/05  李亜博 Redmine#30393
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7.Trim()))// ADD  2012/07/05  李亜博 Redmine#30393
                    {
                        //if (!Check_IntAndLen("得意先掛率グループ純正７", customerGroupWork.CustRateGrpPure1, 4, out  msg))// DEL  2012/07/05  李亜博 Redmine#30393
                        if (!Check_IntAndLen("得意先掛率グループ純正７", customerGroupWork.CustRateGrpPure7, 4, out  msg))// ADD  2012/07/05  李亜博 Redmine#30393
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正８", customerGroupWork.CustRateGrpPure8, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正９", customerGroupWork.CustRateGrpPure9, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１０", customerGroupWork.CustRateGrpPure10, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１１", customerGroupWork.CustRateGrpPure11, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１２", customerGroupWork.CustRateGrpPure12, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１３", customerGroupWork.CustRateGrpPure13, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１４", customerGroupWork.CustRateGrpPure14, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１５", customerGroupWork.CustRateGrpPure15, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１６", customerGroupWork.CustRateGrpPure16, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１７", customerGroupWork.CustRateGrpPure17, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１８", customerGroupWork.CustRateGrpPure18, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正１９", customerGroupWork.CustRateGrpPure19, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２０", customerGroupWork.CustRateGrpPure20, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２１", customerGroupWork.CustRateGrpPure21, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２２", customerGroupWork.CustRateGrpPure22, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２３", customerGroupWork.CustRateGrpPure23, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２４", customerGroupWork.CustRateGrpPure24, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25.Trim()))
                    {
                        if (!Check_IntAndLen("得意先掛率グループ純正２５", customerGroupWork.CustRateGrpPure25, 4, out  msg))
                        {
                            customerGroupWork.ErrorLog = msg;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }
                    // --------------- ADD START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.48の対応-------->>>>
                    //if (Convert.ToInt32(customerGroupWork.CustRateGrpPureAll.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                    if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPureAll) && Convert.ToInt32(customerGroupWork.CustRateGrpPureAll.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                    {
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure1.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure1) && Convert.ToInt32(customerGroupWork.CustRateGrpPure1.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure2.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure2) && Convert.ToInt32(customerGroupWork.CustRateGrpPure2.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure3.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure3) && Convert.ToInt32(customerGroupWork.CustRateGrpPure3.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure4.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure4) && Convert.ToInt32(customerGroupWork.CustRateGrpPure4.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure5.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure5) && Convert.ToInt32(customerGroupWork.CustRateGrpPure5.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure6.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure6) && Convert.ToInt32(customerGroupWork.CustRateGrpPure6.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure7.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure7) && Convert.ToInt32(customerGroupWork.CustRateGrpPure7.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure8.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure8) && Convert.ToInt32(customerGroupWork.CustRateGrpPure8.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure9.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure9) && Convert.ToInt32(customerGroupWork.CustRateGrpPure9.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure10.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure10) && Convert.ToInt32(customerGroupWork.CustRateGrpPure10.Trim()) >= 0) // ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure11.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure11) && Convert.ToInt32(customerGroupWork.CustRateGrpPure11.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure12.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure12) && Convert.ToInt32(customerGroupWork.CustRateGrpPure12.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure13.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure13) && Convert.ToInt32(customerGroupWork.CustRateGrpPure13.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure14.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure14) && Convert.ToInt32(customerGroupWork.CustRateGrpPure14.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure15.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure15) && Convert.ToInt32(customerGroupWork.CustRateGrpPure15.Trim()) >= 0) // ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure16.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure16) && Convert.ToInt32(customerGroupWork.CustRateGrpPure16.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure17.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure17) && Convert.ToInt32(customerGroupWork.CustRateGrpPure17.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure18.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure18) && Convert.ToInt32(customerGroupWork.CustRateGrpPure18.Trim()) >= 0) // ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure19.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure19) && Convert.ToInt32(customerGroupWork.CustRateGrpPure19.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure20.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure20) && Convert.ToInt32(customerGroupWork.CustRateGrpPure20.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure21.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure21) && Convert.ToInt32(customerGroupWork.CustRateGrpPure21.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure22.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure22) && Convert.ToInt32(customerGroupWork.CustRateGrpPure22.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure23.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure23) && Convert.ToInt32(customerGroupWork.CustRateGrpPure23.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure24.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure24) && Convert.ToInt32(customerGroupWork.CustRateGrpPure24.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                        //if (Convert.ToInt32(customerGroupWork.CustRateGrpPure25.Trim()) >= 0 && !string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25))// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        if (!string.IsNullOrEmpty(customerGroupWork.CustRateGrpPure25) && Convert.ToInt32(customerGroupWork.CustRateGrpPure25.Trim()) >= 0)// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.48の対応
                        {
                            customerGroupWork.ErrorLog = FORMAT_ERRMSG;
                            logArrayList.Add(customerGroupWork);
                            return;
                        }
                    }

                    // --------------- ADD END 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.48の対応--------<<<<
                } // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.107の対応
            }// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応 

            // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応-------->>>>
            int count = importCustWorCheckList.FindAll(
                       delegate(CustomerGroupWork p)
                       {
                           return (!string.IsNullOrEmpty(customerGroupWork.CustomerCode) && ConvertToInt32( p.CustomerCode) == ConvertToInt32(customerGroupWork.CustomerCode));
                       }).Count;

            if (count > 1)
            {
                customerGroupWork.ErrorLog = ERRMSG_DUPLICATE;
                logArrayList.Add(customerGroupWork);
                return;
            }
            // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.106の対応--------<<<<


            if (isUpdFlg)
            {
                // 更新の場合
                work.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                work.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
                work.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                work.LogicalDeleteCode = 0;                                   // 論理削除区分
                work.PureCode = searchWork.PureCode;                          // 純正区分
                work.TotalAmountDispWayCd = searchWork.TotalAmountDispWayCd;  // 総額表示方法区分
                work.TotalAmntDspWayRef = searchWork.TotalAmntDspWayRef;      // 総額表示方法参照区分
                work.BillPartsNoPrtCd = searchWork.BillPartsNoPrtCd;          // 品番印字区分(請求書)
                work.DeliPartsNoPrtCd = searchWork.DeliPartsNoPrtCd;          // 品番印字区分(納品書）
                work.DefSalesSlipCd = searchWork.DefSalesSlipCd;              // 伝票区分初期値
                work.LavorRateRank = searchWork.LavorRateRank;                // 工賃レバレートランク
                work.SlipTtlPrn = searchWork.SlipTtlPrn;                      // 伝票タイトルパターン
                work.DepoBankCode = searchWork.DepoBankCode;                  // 入金銀行コード
                work.DeliHonorificTtl = searchWork.DeliHonorificTtl;          // 納品書敬称
                work.BillHonorificTtl = searchWork.BillHonorificTtl;          // 請求書敬称
                work.EstmHonorificTtl = searchWork.EstmHonorificTtl;          // 見積書敬称
                work.RectHonorificTtl = searchWork.RectHonorificTtl;          // 領収書敬称
                work.DeliHonorTtlPrtDiv = searchWork.DeliHonorTtlPrtDiv;      // 納品書敬称印字区分
                work.BillHonorTtlPrtDiv = searchWork.BillHonorTtlPrtDiv;      // 請求書敬称印字区分
                work.EstmHonorTtlPrtDiv = searchWork.EstmHonorTtlPrtDiv;      // 見積書敬称印字区分
                work.RectHonorTtlPrtDiv = searchWork.RectHonorTtlPrtDiv;      // 領収書敬称印字区分
                work.CustomerEpCode = searchWork.CustomerEpCode;              // 得意先企業コード
                work.CustomerSecCode = searchWork.CustomerSecCode;            // 得意先拠点コード
                work.OnlineKindDiv = searchWork.OnlineKindDiv;                // オンライン種別区分
                work.SimplInqAcntAcntGrId = searchWork.SimplInqAcntAcntGrId;  // オンラインアカウントID  ADD  2012/07/09  李亜博 Redmine#30393 for  障害一覧の指摘NO.47の対応
            }
            else
            {
                // 新規の場合
                work.PureCode = 0;                                            // 純正区分
                work.TotalAmountDispWayCd = 0;                                // 総額表示方法区分
                work.TotalAmntDspWayRef = 0;                                  // 総額表示方法参照区分
                work.BillPartsNoPrtCd = 0;                                    // 品番印字区分(請求書)
                work.DeliPartsNoPrtCd = 0;                                    // 品番印字区分(納品書）
                work.DefSalesSlipCd = 0;                                      // 伝票区分初期値
                work.LavorRateRank = 0;                                       // 工賃レバレートランク
                work.SlipTtlPrn = 0;                                          // 伝票タイトルパターン
                work.DepoBankCode = 0;                                        // 入金銀行コード
                work.DeliHonorificTtl = string.Empty;                         // 納品書敬称
                work.BillHonorificTtl = string.Empty;                         // 請求書敬称
                work.EstmHonorificTtl = string.Empty;                         // 見積書敬称
                work.RectHonorificTtl = string.Empty;                         // 領収書敬称
                work.DeliHonorTtlPrtDiv = 0;                                  // 納品書敬称印字区分
                work.BillHonorTtlPrtDiv = 0;                                  // 請求書敬称印字区分
                work.EstmHonorTtlPrtDiv = 0;                                  // 見積書敬称印字区分
                work.RectHonorTtlPrtDiv = 0;                                  // 領収書敬称印字区分
                work.CustomerEpCode = string.Empty;                           // 得意先企業コード
                work.CustomerSecCode = string.Empty;                          // 得意先拠点コード
                work.OnlineKindDiv = 0;                                       // オンライン種別区分

            }
            work.EnterpriseCode = enterpriseCode;
            work.CustomerCode = ConvertToInt32(customerGroupWork.CustomerCode);                    // 得意先コード
            work.CustomerSubCode = customerGroupWork.CustomerSubCode;                              // サブコード
            work.Name = customerGroupWork.Name;                                                    // 得意先名１
            work.Name2 = customerGroupWork.Name2;                                                  // 得意先名２
            work.CustomerSnm = customerGroupWork.CustomerSnm;                                      // 得意先略称
            work.Kana = customerGroupWork.Kana;                                                    // 得意先名カナ
            work.HonorificTitle = customerGroupWork.HonorificTitle;                                // 敬称
            work.OutputNameCode = ConvertToInt32(customerGroupWork.OutputNameCode);                // 諸口
            work.MngSectionCode = ConvertToStrCode(customerGroupWork.MngSectionCode, 2);           // 管理拠点
            work.CustomerAgentCd = ConvertToStrCode(customerGroupWork.CustomerAgentCd, 4);         // 得意先担当
            work.OldCustomerAgentCd = ConvertToStrCode(customerGroupWork.OldCustomerAgentCd, 4);   // 旧担当
            work.CustAgentChgDate = ConvertToDateTime(customerGroupWork.CustAgentChgDate);         // 担当者変更日
            work.TransStopDate = ConvertToDateTime(customerGroupWork.TransStopDate);               // 取引中止日
            work.CarMngDivCd = ConvertToInt32(customerGroupWork.CarMngDivCd);                      // 車輛管理
            work.CorporateDivCode = ConvertToInt32(customerGroupWork.CorporateDivCode);            // 個人・法人
            work.AcceptWholeSale = ConvertToInt32(customerGroupWork.AcceptWholeSale);            // 得意先種別// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.61の対応 // ADD  2012/07/24  李亜博 Redmine#30393 for 障害一覧の指摘NO.61の対応
            // ------ DEL START 2012/07/24 Redmine#30393 李亜博 for 障害一覧の指摘NO.61の対応-------->>>>
            //// ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.61の対応-------->>>>
            //if (ConvertToInt32(customerGroupWork.AcceptWholeSale) == 0)
            //{
            //    work.AcceptWholeSale = 1;
            //}
            //else if (ConvertToInt32(customerGroupWork.AcceptWholeSale) == 1)
            //{
            //    work.AcceptWholeSale = 2;
            //}
            //else
            //{
            //    work.AcceptWholeSale = ConvertToInt32(customerGroupWork.AcceptWholeSale);
            //}
            //// ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.61の対応--------<<<<
            // ------ DEL END 2012/07/24 Redmine#30393 李亜博 for 障害一覧の指摘NO.61の対応--------<<<<
            //work.CustomerAttributeDiv = ConvertToInt32(customerGroupWork.CustomerAttributeDiv);    // 得意先属性// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.59の対応
            // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.59の対応-------->>>>
            if (ConvertToInt32(customerGroupWork.CustomerAttributeDiv) == 1)
            {
                work.CustomerAttributeDiv = 8;
            }
            else if (ConvertToInt32(customerGroupWork.CustomerAttributeDiv) == 2)
            {
                work.CustomerAttributeDiv = 9;
            }
            else
            {
                work.CustomerAttributeDiv = ConvertToInt32(customerGroupWork.CustomerAttributeDiv);
            }
            // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.59の対応--------<<<<
            work.CustWarehouseCd = ConvertToStrCode(customerGroupWork.CustWarehouseCd, 4);         // 優先倉庫
            work.BusinessTypeCode = ConvertToInt32(customerGroupWork.BusinessTypeCode);            // 業種
            work.JobTypeCode = ConvertToInt32(customerGroupWork.JobTypeCode);                      // 職種
            work.SalesAreaCode = ConvertToInt32(customerGroupWork.SalesAreaCode);                  // 地区
            work.CustAnalysCode1 = ConvertToInt32(customerGroupWork.CustAnalysCode1);              // 分析コード１
            work.CustAnalysCode2 = ConvertToInt32(customerGroupWork.CustAnalysCode2);              // 分析コード２
            work.CustAnalysCode3 = ConvertToInt32(customerGroupWork.CustAnalysCode3);              // 分析コード３
            work.CustAnalysCode4 = ConvertToInt32(customerGroupWork.CustAnalysCode4);              // 分析コード４
            work.CustAnalysCode5 = ConvertToInt32(customerGroupWork.CustAnalysCode5);              // 分析コード５
            work.CustAnalysCode6 = ConvertToInt32(customerGroupWork.CustAnalysCode6);              // 分析コード６
            work.ClaimSectionCode = ConvertToStrCode(customerGroupWork.ClaimSectionCode, 2);       // 請求拠点
            work.ClaimCode = ConvertToInt32(customerGroupWork.ClaimCode);                          // 請求コード
            work.TotalDay = ConvertToInt32(customerGroupWork.TotalDay);                            // 締日
            work.CollectMoneyCode = ConvertToInt32(customerGroupWork.CollectMoneyCode);            // 集金月
            work.CollectMoneyDay = ConvertToInt32(customerGroupWork.CollectMoneyDay);              // 集金日
            work.CollectCond = ConvertToInt32(customerGroupWork.CollectCond);                      // 回収条件
            work.CollectSight = ConvertToInt32(customerGroupWork.CollectSight);                    // 回収サイト
            work.NTimeCalcStDate = ConvertToInt32(customerGroupWork.NTimeCalcStDate);              // 次回勘定
            work.BillCollecterCd = ConvertToStrCode(customerGroupWork.BillCollecterCd, 4);         // 集金担当
            work.CustCTaXLayRefCd = ConvertToInt32(customerGroupWork.CustCTaXLayRefCd);            // 転嫁方式参照区分
            work.ConsTaxLayMethod = ConvertToInt32(customerGroupWork.ConsTaxLayMethod);            // 消費税転嫁方式
            work.SalesUnPrcFrcProcCd = ConvertToInt32(customerGroupWork.SalesUnPrcFrcProcCd);      // 単価端数処理
            work.SalesMoneyFrcProcCd = ConvertToInt32(customerGroupWork.SalesMoneyFrcProcCd);      // 金額端数処理
            work.SalesCnsTaxFrcProcCd = ConvertToInt32(customerGroupWork.SalesCnsTaxFrcProcCd);    // 消費税端数処理
            work.CreditMngCode = ConvertToInt32(customerGroupWork.CreditMngCode);                  // 与信管理
            work.DepoDelCode = ConvertToInt32(customerGroupWork.DepoDelCode);                      // 入金消込
            work.AccRecDivCd = ConvertToInt32(customerGroupWork.AccRecDivCd);                      // 売掛区分
            work.PostNo = customerGroupWork.PostNo;                                                // 郵便番号
            work.Address1 = customerGroupWork.Address1;                                            // 住所
            work.Address3 = customerGroupWork.Address3;                                            // 住所２
            work.Address4 = customerGroupWork.Address4;                                            // 住所３
            work.CustomerAgent = customerGroupWork.CustomerAgent;                                  // 得意先担当者
            work.HomeTelNo = customerGroupWork.HomeTelNo;                                          // 自宅ＴＥＬ
            work.OfficeTelNo = customerGroupWork.OfficeTelNo;                                      // 勤務先電話１
            work.PortableTelNo = customerGroupWork.PortableTelNo;                                  // 勤務先電話２
            work.OthersTelNo = customerGroupWork.OthersTelNo;                                      // その他電話
            work.HomeFaxNo = customerGroupWork.HomeFaxNo;                                          // 自宅ＦＡＸ
            work.OfficeFaxNo = customerGroupWork.OfficeFaxNo;                                      // 勤務先ＦＡＸ
            work.SearchTelNo = customerGroupWork.SearchTelNo;                                      // 検索番号
            work.MainContactCode = ConvertToInt32(customerGroupWork.MainContactCode);              // 主連絡先
            work.Note1 = customerGroupWork.Note1;                                                  // 得意先備考１
            work.Note2 = customerGroupWork.Note2;                                                  // 得意先備考２
            work.Note3 = customerGroupWork.Note3;                                                  // 得意先備考３
            work.Note4 = customerGroupWork.Note4;                                                  // 得意先備考４
            work.Note5 = customerGroupWork.Note5;                                                  // 得意先備考５
            work.Note6 = customerGroupWork.Note6;                                                  // 得意先備考６
            work.Note7 = customerGroupWork.Note7;                                                  // 得意先備考７
            work.Note8 = customerGroupWork.Note8;                                                  // 得意先備考８
            work.Note9 = customerGroupWork.Note9;                                                  // 得意先備考９
            work.Note10 = customerGroupWork.Note10;                                                // 得意先備考１０
            work.MainSendMailAddrCd = ConvertToInt32(customerGroupWork.MainSendMailAddrCd);        // 主送信先メールアドレス区分
            work.MailAddress1 = customerGroupWork.MailAddress1;                                    // メールアドレス１
            work.MailSendCode1 = ConvertToInt32(customerGroupWork.MailSendCode1);                  // メール送信区分コード１
            //work.MailAddrKindCode1 = ConvertToInt32(customerGroupWork.MailAddrKindCode1);          // メールアドレス種別コード１// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.60の対応
            // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.60の対応-------->>>>
            if (ConvertToInt32(customerGroupWork.MailAddrKindCode1) == 4)
            {
                work.MailAddrKindCode1 = 99;
            }
            else
            {
                work.MailAddrKindCode1 = ConvertToInt32(customerGroupWork.MailAddrKindCode1);
            }
            // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.60の対応--------<<<<
            work.MailAddress2 = customerGroupWork.MailAddress2;                                    // メールアドレス２
            work.MailSendCode2 = ConvertToInt32(customerGroupWork.MailSendCode2);                  // メール送信区分コード２
            //work.MailAddrKindCode2 = ConvertToInt32(customerGroupWork.MailAddrKindCode2);          // メールアドレス種別コード２// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.60の対応
            // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.60の対応-------->>>>
            if (ConvertToInt32(customerGroupWork.MailAddrKindCode2) == 4)
            {
                work.MailAddrKindCode2 = 99;
            }
            else
            {
                work.MailAddrKindCode2 = ConvertToInt32(customerGroupWork.MailAddrKindCode2);
            }
            // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.60の対応--------<<<<
            work.AccountNoInfo1 = customerGroupWork.AccountNoInfo1;                                // 銀行口座１
            work.AccountNoInfo2 = customerGroupWork.AccountNoInfo2;                                // 銀行口座２
            work.AccountNoInfo3 = customerGroupWork.AccountNoInfo3;                                // 銀行口座３
            work.ReceiptOutputCode = ConvertToInt32(customerGroupWork.ReceiptOutputCode);          // 領収書出力
            work.DmOutCode = ConvertToInt32(customerGroupWork.DmOutCode);                          // ＤＭ出力
            work.SalesSlipPrtDiv = ConvertToInt32(customerGroupWork.SalesSlipPrtDiv);              // 納品書出力
            work.AcpOdrrSlipPrtDiv = ConvertToInt32(customerGroupWork.AcpOdrrSlipPrtDiv);          // 受注伝票出力
            work.ShipmSlipPrtDiv = ConvertToInt32(customerGroupWork.ShipmSlipPrtDiv);              // 貸出伝票出力
            work.EstimatePrtDiv = ConvertToInt32(customerGroupWork.EstimatePrtDiv);                // 見積伝票出力
            work.UOESlipPrtDiv = ConvertToInt32(customerGroupWork.UOESlipPrtDiv);                  // ＵＯＥ伝票出力
            work.QrcodePrtCd = ConvertToInt32(customerGroupWork.QrcodePrtCd);                      // ＱＲコード印刷
            work.CustSlipNoMngCd = ConvertToInt32(customerGroupWork.CustSlipNoMngCd);              // 相手伝票番号管理
            work.CustomerSlipNoDiv = ConvertToInt32(customerGroupWork.CustomerSlipNoDiv);          // 相手伝票番号区分

            work.TotalBillOutputDiv = ConvertToInt32(customerGroupWork.TotalBillOutputDiv);        // 合計請求書出力
            work.DetailBillOutputCode = ConvertToInt32(customerGroupWork.DetailBillOutputCode);    // 明細請求書出力
            work.SlipTtlBillOutputDiv = ConvertToInt32(customerGroupWork.SlipTtlBillOutputDiv);    // 伝票合計請求書出力区分

            //work.CustRateGrpFine = ConvertRateToInt32(customerGroupWork.CustRateGrpFine);        //得意先掛率グループ(優良)// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            work.CustRateGrpFineAll = ConvertRateToInt32(customerGroupWork.CustRateGrpFineAll);    //得意先掛率グループ(優良ALL)// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            work.CustRateGrpPureAll = ConvertRateToInt32(customerGroupWork.CustRateGrpPureAll);    //得意先掛率グループ(純正ALL)
            work.CustRateGrpPure1 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure1);        //得意先掛率グループ純正１
            work.CustRateGrpPure2 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure2);        //得意先掛率グループ純正2
            work.CustRateGrpPure3 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure3);        //得意先掛率グループ純正3
            work.CustRateGrpPure4 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure4);        //得意先掛率グループ純正4
            work.CustRateGrpPure5 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure5);        //得意先掛率グループ純正5
            work.CustRateGrpPure6 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure6);        //得意先掛率グループ純正6
            work.CustRateGrpPure7 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure7);        //得意先掛率グループ純正7
            work.CustRateGrpPure8 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure8);        //得意先掛率グループ純正8
            work.CustRateGrpPure9 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure9);        //得意先掛率グループ純正9
            work.CustRateGrpPure10 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure10);      //得意先掛率グループ純正１0
            work.CustRateGrpPure11 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure11);      //得意先掛率グループ純正１1
            work.CustRateGrpPure12 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure12);      //得意先掛率グループ純正１2
            work.CustRateGrpPure13 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure13);      //得意先掛率グループ純正１3
            work.CustRateGrpPure14 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure14);      //得意先掛率グループ純正１4
            work.CustRateGrpPure15 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure15);      //得意先掛率グループ純正１5
            work.CustRateGrpPure16 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure16);      //得意先掛率グループ純正１6
            work.CustRateGrpPure17 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure17);      //得意先掛率グループ純正１7
            work.CustRateGrpPure18 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure18);      //得意先掛率グループ純正１8
            work.CustRateGrpPure19 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure19);      //得意先掛率グループ純正１9
            work.CustRateGrpPure20 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure20);      //得意先掛率グループ純正20
            work.CustRateGrpPure21 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure21);      //得意先掛率グループ純正2１
            work.CustRateGrpPure22 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure22);      //得意先掛率グループ純正22
            work.CustRateGrpPure23 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure23);      //得意先掛率グループ純正23
            work.CustRateGrpPure24 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure24);      //得意先掛率グループ純正24
            work.CustRateGrpPure25 = ConvertRateToInt32(customerGroupWork.CustRateGrpPure25);      //得意先掛率グループ純正25
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// ログテーブル
        ///// </summary>
        ///// <param name="row">CSVファイルの行</param>
        ///// <param name="logTable">ログテーブル</param>
        ///// <param name="msg">エラーメッセージ</param>
        //private void ConverToDataSetCustomerLog(DataRow row, ref DataTable logTable, string msg)
        //{
        //    DataRow dataRow = logTable.NewRow();
        //    int index = 0;

        //    dataRow["CustomerCodeRF"] = row[index++].ToString();
        //    dataRow["CustomerSubCodeRF"] = row[index++].ToString();
        //    dataRow["NameRF"] = row[index++].ToString();
        //    dataRow["Name2RF"] = row[index++].ToString();
        //    dataRow["CustomerSnmRF"] = row[index++].ToString();
        //    dataRow["KanaRF"] = row[index++].ToString();
        //    dataRow["HonorificTitleRF"] = row[index++].ToString();
        //    dataRow["OutputNameCodeRF"] = row[index++].ToString();
        //    dataRow["MngSectionCodeRF"] = row[index++].ToString();
        //    dataRow["CustomerAgentCdRF"] = row[index++].ToString();
        //    dataRow["OldCustomerAgentCdRF"] = row[index++].ToString();
        //    dataRow["CustAgentChgDateRF"] = row[index++].ToString();
        //    dataRow["TransStopDateRF"] = row[index++].ToString();
        //    dataRow["CarMngDivCdRF"] = row[index++].ToString();
        //    dataRow["CorporateDivCodeRF"] = row[index++].ToString();
        //    dataRow["AcceptWholeSaleRF"] = row[index++].ToString();
        //    dataRow["CustomerAttributeDivRF"] = row[index++].ToString();
        //    dataRow["CustWarehouseCdRF"] = row[index++].ToString();
        //    dataRow["BusinessTypeCodeRF"] = row[index++].ToString();
        //    dataRow["JobTypeCodeRF"] = row[index++].ToString();
        //    dataRow["SalesAreaCodeRF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode1RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode2RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode3RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode4RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode5RF"] = row[index++].ToString();
        //    dataRow["CustAnalysCode6RF"] = row[index++].ToString();
        //    dataRow["ClaimSectionCodeRF"] = row[index++].ToString();
        //    dataRow["ClaimCodeRF"] = row[index++].ToString();
        //    dataRow["TotalDayRF"] = row[index++].ToString();
        //    dataRow["CollectMoneyCodeRF"] = row[index++].ToString();
        //    dataRow["CollectMoneyDayRF"] = row[index++].ToString();
        //    dataRow["CollectCondRF"] = row[index++].ToString();
        //    dataRow["CollectSightRF"] = row[index++].ToString();
        //    dataRow["NTimeCalcStDateRF"] = row[index++].ToString();
        //    dataRow["BillCollecterCdRF"] = row[index++].ToString();
        //    dataRow["CustCTaXLayRefCdRF"] = row[index++].ToString();
        //    dataRow["ConsTaxLayMethodRF"] = row[index++].ToString();
        //    dataRow["SalesUnPrcFrcProcCdRF"] = row[index++].ToString();
        //    dataRow["SalesMoneyFrcProcCdRF"] = row[index++].ToString();
        //    dataRow["SalesCnsTaxFrcProcCdRF"] = row[index++].ToString();
        //    dataRow["CreditMngCodeRF"] = row[index++].ToString();
        //    dataRow["DepoDelCodeRF"] = row[index++].ToString();
        //    dataRow["AccRecDivCdRF"] = row[index++].ToString();
        //    dataRow["PostNoRF"] = row[index++].ToString();
        //    dataRow["Address1RF"] = row[index++].ToString();
        //    dataRow["Address3RF"] = row[index++].ToString();
        //    dataRow["Address4RF"] = row[index++].ToString();
        //    dataRow["CustomerAgentRF"] = row[index++].ToString();
        //    dataRow["HomeTelNoRF"] = row[index++].ToString();
        //    dataRow["OfficeTelNoRF"] = row[index++].ToString();
        //    dataRow["PortableTelNoRF"] = row[index++].ToString();
        //    dataRow["OthersTelNoRF"] = row[index++].ToString();
        //    dataRow["HomeFaxNoRF"] = row[index++].ToString();
        //    dataRow["OfficeFaxNoRF"] = row[index++].ToString();
        //    dataRow["SearchTelNoRF"] = row[index++].ToString();
        //    dataRow["MainContactCodeRF"] = row[index++].ToString();
        //    dataRow["Note1RF"] = row[index++].ToString();
        //    dataRow["Note2RF"] = row[index++].ToString();
        //    dataRow["Note3RF"] = row[index++].ToString();
        //    dataRow["Note4RF"] = row[index++].ToString();
        //    dataRow["Note5RF"] = row[index++].ToString();
        //    dataRow["Note6RF"] = row[index++].ToString();
        //    dataRow["Note7RF"] = row[index++].ToString();
        //    dataRow["Note8RF"] = row[index++].ToString();
        //    dataRow["Note9RF"] = row[index++].ToString();
        //    dataRow["Note10RF"] = row[index++].ToString();
        //    dataRow["MainSendMailAddrCdRF"] = row[index++].ToString();
        //    dataRow["MailAddress1RF"] = row[index++].ToString();
        //    dataRow["MailSendCode1RF"] = row[index++].ToString();
        //    dataRow["MailAddrKindCode1RF"] = row[index++].ToString();
        //    dataRow["MailAddress2RF"] = row[index++].ToString();
        //    dataRow["MailSendCode2RF"] = row[index++].ToString();
        //    dataRow["MailAddrKindCode2RF"] = row[index++].ToString();
        //    dataRow["AccountNoInfo1RF"] = row[index++].ToString();
        //    dataRow["AccountNoInfo2RF"] = row[index++].ToString();
        //    dataRow["AccountNoInfo3RF"] = row[index++].ToString();
        //    dataRow["ReceiptOutputCodeRF"] = row[index++].ToString();
        //    dataRow["DmOutCodeRF"] = row[index++].ToString();
        //    dataRow["SalesSlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["AcpOdrrSlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["ShipmSlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["EstimatePrtDivRF"] = row[index++].ToString();
        //    dataRow["UOESlipPrtDivRF"] = row[index++].ToString();
        //    dataRow["QrcodePrtCdRF"] = row[index++].ToString();
        //    dataRow["CustSlipNoMngCdRF"] = row[index++].ToString();
        //    dataRow["CustomerSlipNoDivRF"] = row[index++].ToString();
        //    dataRow["TotalBillOutputDivRF"] = row[index++].ToString();
        //    dataRow["DetailBillOutputCodeRF"] = row[index++].ToString();
        //    dataRow["SlipTtlBillOutputDivRF"] = row[index++].ToString();
        //    dataRow["CustRateGrpFine"] = row[index++].ToString();
        //    dataRow["CustRateGrpPureAll"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure1"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure2"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure3"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure4"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure5"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure6"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure7"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure8"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure9"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure10"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure11"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure12"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure13"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure14"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure15"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure16"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure17"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure18"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure19"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure20"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure21"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure22"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure23"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure24"] = row[index++].ToString();
        //    dataRow["CustRateGrpPure25"] = row[index++].ToString();
        //    dataRow["ErrorLog"] = msg;

        //    logTable.Rows.Add(dataRow);
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        # endregion

        # endregion

        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<

        #region ◎ 日時項目へ変換処理
        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// 日時項目へ変換処理
        ///// </summary>
        ///// <param name="csvDataArr">CSV項目配列</param>
        ///// <param name="index">インデックス</param>
        ///// <returns>変更した日時</returns>
        ///// <remarks>
        ///// <br>Note       : 項目数が足りない場合は最小日時へ変換処理処理を行う。</br>
        ///// <br>Programmer : 李亜博</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private DateTime ConvertToDateTime(DataRow csvDataArr, Int32 index)
        //{
        //    DateTime retDt = DateTime.MinValue;

        //    if (index < csvDataArr.ItemArray.Length)
        //    {
        //        Int32 tmpNumber = ConvertToInt32(csvDataArr, index);
        //        if (tmpNumber != 0)
        //        {
        //            retDt = TDateTime.LongDateToDateTime(tmpNumber);
        //        }
        //    }

        //    return retDt;
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// 日時項目へ変換処理
        /// </summary>
        /// <param name="str">CSV項目配列</param>
        /// <returns>変更した日時</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は最小日時へ変換処理処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private DateTime ConvertToDateTime(string str)
        {
            DateTime retDt = DateTime.MinValue;

            Int32 tmpNumber = ConvertToInt32(str);
            if (tmpNumber != 0)
            {
                retDt = TDateTime.LongDateToDateTime(tmpNumber);
            }

            return retDt;
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
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
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private string ConvertToEmpty(DataRow csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.ItemArray.Length)
            {
                retContent = csvDataArr[index].ToString();
            }

            return retContent;
        }
     
        #endregion

        #region ◎ コード文字列項目の変換処理
        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// コード文字列項目の変換処理
        ///// </summary>
        ///// <param name="csvDataArr">CSV項目配列</param>
        ///// <param name="index">インデックス</param>
        ///// <param name="maxLength">MAX桁数</param>
        ///// <returns>変更した項目</returns>
        ///// <remarks>
        ///// <br>Note       : コード文字列項目の変換処理を行う。</br>
        ///// <br>Programmer : 李亜博</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private string ConvertToStrCode(DataRow csvDataArr, Int32 index, Int32 maxLength)
        //{
        //    return ConvertToEmpty(csvDataArr, index).PadLeft(maxLength, '0');
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// コード文字列項目の変換処理
        /// </summary>
        /// <param name="str">CSV項目配列</param>
        /// <param name="maxLength">MAX桁数</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : コード文字列項目の変換処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/03</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.30、NO.48、NO.56、NO.59、NO.60、NO.61、NO.62の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7、NO.48、NO.94、NO.95の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.94、NO.106、NO.107、NO.108の対応</br>
        /// </remarks>
        private string ConvertToStrCode(string str, Int32 maxLength)
        {
            //return str.PadLeft(maxLength, '0');// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.56の対応
            // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.56の対応-------->>>>
            //if (!string.IsNullOrEmpty(str) && Convert.ToInt32(str.Trim()) != 0)// DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
            if (!string.IsNullOrEmpty(str) && ConvertToInt32(str.Trim()) != 0)// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
            {
                return str.PadLeft(maxLength, '0');
            }
            else
            {
                // ------ DEL START 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.95の対応-------->>>>
                //if (Convert.ToInt32(str.Trim()) == 0)
                //{
                //    return string.Empty;
                //}
                //else
                //{
                //    return str;
                //}
                // ------ DEL END 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.95の対応--------<<<<
                return string.Empty;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.95の対応
            }
            // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.56の対応--------<<<<
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
        #endregion
        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// 数値項目へ変換処理
        ///// </summary>
        ///// <param name="csvDataArr">CSV項目配列</param>
        ///// <param name="index">インデックス</param>
        ///// <returns>変更した数値</returns>
        ///// <remarks>
        ///// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        ///// <br>Programmer : 李亜博</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private Int32 ConvertToInt32(DataRow csvDataArr, Int32 index)
        //{
        //    Int32 retNum = 0;

        //    if (index < csvDataArr.ItemArray.Length)
        //    {
        //        try
        //        {
        //            retNum = Convert.ToInt32(csvDataArr[index]);
        //        }
        //        catch
        //        {
        //            retNum = 0;
        //        }
        //    }

        //    return retNum;
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="str">CSV項目配列</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/03</br>
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
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        ///// <summary>
        ///// 数値項目へ変換処理
        ///// </summary>
        ///// <param name="csvDataArr">CSV項目配列</param>
        ///// <param name="index">インデックス</param>
        ///// <returns>変更した数値</returns>
        ///// <remarks>
        ///// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        ///// <br>Programmer : 李亜博</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        
        //private Int32 ConvertRateToInt32(DataRow csvDataArr, Int32 index)
        //{
        //    Int32 retNum = 0;

        //    if (index < csvDataArr.ItemArray.Length)
        //    {
        //        try
        //        {
        //            if (Convert.ToInt32(csvDataArr[index]) >= 0)
        //            {
        //                retNum = Convert.ToInt32(csvDataArr[index]);
        //            }
        //            else
        //            {
        //                retNum = -1;
        //            }
        //        }
        //        catch
        //        {
        //            retNum = -1;
        //        }
        //    }

        //    return retNum;
        //}
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="str">CSV項目配列</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/03</br>
        /// </remarks>
        private Int32 ConvertRateToInt32(string str)
        {
            Int32 retNum = 0;

            try
            {
                if (Convert.ToInt32(str) >= 0)
                {
                    retNum = Convert.ToInt32(str);
                }
                else
                {
                    retNum = -1;
                }
            }
            catch
            {
                retNum = -1;
            }

            return retNum;
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<

        // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
        //#region DB登録用のオブジェクトの作成
        ///// <summary>
        ///// DB登録用のオブジェクトの作成
        ///// </summary>
        ///// <param name="csvWork">インポート用のオブジェクト</param>
        ///// <param name="searchWork">検索したオブジェクト</param>
        ///// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Programmer : 李亜博</br>
        ///// <br>Date       : 2012/06/12</br>
        ///// </remarks>
        //private CustomerWork ConvertToImportWork(CustomerWork csvWork, CustomerWork searchWork, bool isUpdFlg)
        //{
        //    CustomerWork importWork = new CustomerWork();
        //    if (isUpdFlg)
        //    {
        //        // 更新の場合
        //        importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
        //        importWork.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
        //        importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
        //        importWork.LogicalDeleteCode = 0;                                   // 論理削除区分
        //        importWork.PureCode = searchWork.PureCode;                          // 純正区分
        //        importWork.TotalAmountDispWayCd = searchWork.TotalAmountDispWayCd;  // 総額表示方法区分
        //        importWork.TotalAmntDspWayRef = searchWork.TotalAmntDspWayRef;      // 総額表示方法参照区分
        //        importWork.BillPartsNoPrtCd = searchWork.BillPartsNoPrtCd;          // 品番印字区分(請求書)
        //        importWork.DeliPartsNoPrtCd = searchWork.DeliPartsNoPrtCd;          // 品番印字区分(納品書）
        //        importWork.DefSalesSlipCd = searchWork.DefSalesSlipCd;              // 伝票区分初期値
        //        importWork.LavorRateRank = searchWork.LavorRateRank;                // 工賃レバレートランク
        //        importWork.SlipTtlPrn = searchWork.SlipTtlPrn;                      // 伝票タイトルパターン
        //        importWork.DepoBankCode = searchWork.DepoBankCode;                  // 入金銀行コード
        //        importWork.DeliHonorificTtl = searchWork.DeliHonorificTtl;          // 納品書敬称
        //        importWork.BillHonorificTtl = searchWork.BillHonorificTtl;          // 請求書敬称
        //        importWork.EstmHonorificTtl = searchWork.EstmHonorificTtl;          // 見積書敬称
        //        importWork.RectHonorificTtl = searchWork.RectHonorificTtl;          // 領収書敬称
        //        importWork.DeliHonorTtlPrtDiv = searchWork.DeliHonorTtlPrtDiv;      // 納品書敬称印字区分
        //        importWork.BillHonorTtlPrtDiv = searchWork.BillHonorTtlPrtDiv;      // 請求書敬称印字区分
        //        importWork.EstmHonorTtlPrtDiv = searchWork.EstmHonorTtlPrtDiv;      // 見積書敬称印字区分
        //        importWork.RectHonorTtlPrtDiv = searchWork.RectHonorTtlPrtDiv;      // 領収書敬称印字区分
        //        importWork.CustomerEpCode = searchWork.CustomerEpCode;              // 得意先企業コード
        //        importWork.CustomerSecCode = searchWork.CustomerSecCode;            // 得意先拠点コード
        //        importWork.OnlineKindDiv = searchWork.OnlineKindDiv;                // オンライン種別区分
        //    }
        //    else
        //    {
        //        // 新規の場合
        //        importWork.PureCode = 0;                                            // 純正区分
        //        importWork.TotalAmountDispWayCd = 0;                                // 総額表示方法区分
        //        importWork.TotalAmntDspWayRef = 0;                                  // 総額表示方法参照区分
        //        importWork.BillPartsNoPrtCd = 0;                                    // 品番印字区分(請求書)
        //        importWork.DeliPartsNoPrtCd = 0;                                    // 品番印字区分(納品書）
        //        importWork.DefSalesSlipCd = 0;                                      // 伝票区分初期値
        //        importWork.LavorRateRank = 0;                                       // 工賃レバレートランク
        //        importWork.SlipTtlPrn = 0;                                          // 伝票タイトルパターン
        //        importWork.DepoBankCode = 0;                                        // 入金銀行コード
        //        importWork.DeliHonorificTtl = string.Empty;                         // 納品書敬称
        //        importWork.BillHonorificTtl = string.Empty;                         // 請求書敬称
        //        importWork.EstmHonorificTtl = string.Empty;                         // 見積書敬称
        //        importWork.RectHonorificTtl = string.Empty;                         // 領収書敬称
        //        importWork.DeliHonorTtlPrtDiv = 0;                                  // 納品書敬称印字区分
        //        importWork.BillHonorTtlPrtDiv = 0;                                  // 請求書敬称印字区分
        //        importWork.EstmHonorTtlPrtDiv = 0;                                  // 見積書敬称印字区分
        //        importWork.RectHonorTtlPrtDiv = 0;                                  // 領収書敬称印字区分
        //        importWork.CustomerEpCode = string.Empty;                           // 得意先企業コード
        //        importWork.CustomerSecCode = string.Empty;                          // 得意先拠点コード
        //        importWork.OnlineKindDiv = 0;                                       // オンライン種別区分

        //    }
        //    importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // 企業コード
        //    importWork.CustomerCode = csvWork.CustomerCode;                         // 得意先コード
        //    importWork.CustomerSubCode = csvWork.CustomerSubCode;                   // サブコード
        //    importWork.Name = csvWork.Name;                                         // 名称
        //    importWork.Name2 = csvWork.Name2;                                       // 名称２
        //    importWork.CustomerSnm = csvWork.CustomerSnm;                           // 得意先略称
        //    importWork.Kana = csvWork.Kana;                                         // カナ
        //    importWork.HonorificTitle = csvWork.HonorificTitle;                     // 敬称
        //    importWork.OutputNameCode = csvWork.OutputNameCode;                     // 諸口コード
        //    importWork.OutputName = GetOutputName(csvWork.OutputNameCode);          // 諸口名称
        //    importWork.MngSectionCode = csvWork.MngSectionCode;                     // 管理拠点コード
        //    importWork.InpSectionCode = csvWork.MngSectionCode;                     // 入力拠点コード
        //    importWork.CustomerAgentCd = csvWork.CustomerAgentCd;                   // 顧客担当従業員コード
        //    importWork.OldCustomerAgentCd = csvWork.OldCustomerAgentCd;             // 旧顧客担当従業員コード
        //    importWork.CustAgentChgDate = csvWork.CustAgentChgDate;                 // 顧客担当変更日
        //    importWork.TransStopDate = csvWork.TransStopDate;                       // 取引中止日
        //    importWork.CarMngDivCd = csvWork.CarMngDivCd;                           // 車輌管理区分
        //    importWork.CorporateDivCode = csvWork.CorporateDivCode;                 // 個人・法人区分
        //    importWork.AcceptWholeSale = csvWork.AcceptWholeSale;                   // 業販先区分
        //    importWork.CustomerAttributeDiv = csvWork.CustomerAttributeDiv;         // 得意先属性区分
        //    importWork.CustWarehouseCd = csvWork.CustWarehouseCd;                   // 得意先優先倉庫コード
        //    importWork.BusinessTypeCode = csvWork.BusinessTypeCode;                 // 業種コード
        //    importWork.JobTypeCode = csvWork.JobTypeCode;                           // 職種コード
        //    importWork.SalesAreaCode = csvWork.SalesAreaCode;                       // 販売エリアコード
        //    importWork.CustAnalysCode1 = csvWork.CustAnalysCode1;                   // 得意先分析コード１
        //    importWork.CustAnalysCode2 = csvWork.CustAnalysCode2;                   // 得意先分析コード２
        //    importWork.CustAnalysCode3 = csvWork.CustAnalysCode3;                   // 得意先分析コード３
        //    importWork.CustAnalysCode4 = csvWork.CustAnalysCode4;                   // 得意先分析コード４
        //    importWork.CustAnalysCode5 = csvWork.CustAnalysCode5;                   // 得意先分析コード５
        //    importWork.CustAnalysCode6 = csvWork.CustAnalysCode6;                   // 得意先分析コード６
        //    importWork.ClaimSectionCode = csvWork.ClaimSectionCode;                 // 請求拠点コード
        //    importWork.ClaimCode = csvWork.ClaimCode;                               // 請求先コード
        //    importWork.TotalDay = csvWork.TotalDay;                                 // 締日
        //    importWork.CollectMoneyCode = csvWork.CollectMoneyCode;                 // 集金月区分コード
        //    importWork.CollectMoneyName = GetCollectMoneyName(csvWork.CollectMoneyCode);// 集金月区分名称
        //    importWork.CollectMoneyDay = csvWork.CollectMoneyDay;                   // 集金日
        //    importWork.CollectCond = csvWork.CollectCond;                           // 回収条件
        //    importWork.CollectSight = csvWork.CollectSight;                         // 回収サイト
        //    importWork.NTimeCalcStDate = csvWork.NTimeCalcStDate;                   // 次回勘定開始日
        //    importWork.BillCollecterCd = csvWork.BillCollecterCd;                   // 集金担当従業員コード
        //    importWork.CustCTaXLayRefCd = csvWork.CustCTaXLayRefCd;                 // 得意先消費税転嫁方式参照区分
        //    importWork.ConsTaxLayMethod = csvWork.ConsTaxLayMethod;                 // 消費税転嫁方式
        //    importWork.SalesUnPrcFrcProcCd = csvWork.SalesUnPrcFrcProcCd;           // 売上単価端数処理コード
        //    importWork.SalesMoneyFrcProcCd = csvWork.SalesMoneyFrcProcCd;           // 売上金額端数処理コード
        //    importWork.SalesCnsTaxFrcProcCd = csvWork.SalesCnsTaxFrcProcCd;         // 売上消費税端数処理コード
        //    importWork.CreditMngCode = csvWork.CreditMngCode;                       // 与信管理区分
        //    importWork.DepoDelCode = csvWork.DepoDelCode;                           // 入金消込区分
        //    importWork.AccRecDivCd = csvWork.AccRecDivCd;                           // 売掛区分
        //    importWork.PostNo = csvWork.PostNo;                                     // 郵便番号
        //    importWork.Address1 = csvWork.Address1;                                 // 住所1(都道府県市区郡・町村・字）
        //    importWork.Address3 = csvWork.Address3;                                 // 住所3(番地）
        //    importWork.Address4 = csvWork.Address4;                                 // 住所4(アパート名称）
        //    importWork.CustomerAgent = csvWork.CustomerAgent;                       // 得意先担当者
        //    importWork.HomeTelNo = csvWork.HomeTelNo;                               // 電話番号(自宅）
        //    importWork.OfficeTelNo = csvWork.OfficeTelNo;                           // 電話番号(勤務先）
        //    importWork.PortableTelNo = csvWork.PortableTelNo;                       // 電話番号(携帯）
        //    importWork.OthersTelNo = csvWork.OthersTelNo;                           // 電話番号(その他）
        //    importWork.HomeFaxNo = csvWork.HomeFaxNo;                               // FAX番号(自宅）
        //    importWork.OfficeFaxNo = csvWork.OfficeFaxNo;                           // FAX番号(勤務先）
        //    importWork.SearchTelNo = csvWork.SearchTelNo;                           // 電話番号(検索用下4桁）
        //    importWork.MainContactCode = csvWork.MainContactCode;                   // 主連絡先区分
        //    importWork.Note1 = csvWork.Note1;                                       // 備考１
        //    importWork.Note2 = csvWork.Note2;                                       // 備考２
        //    importWork.Note3 = csvWork.Note3;                                       // 備考３
        //    importWork.Note4 = csvWork.Note4;                                       // 備考４
        //    importWork.Note5 = csvWork.Note5;                                       // 備考５
        //    importWork.Note6 = csvWork.Note6;                                       // 備考６
        //    importWork.Note7 = csvWork.Note7;                                       // 備考７
        //    importWork.Note8 = csvWork.Note8;                                       // 備考８
        //    importWork.Note9 = csvWork.Note9;                                       // 備考９
        //    importWork.Note10 = csvWork.Note10;                                     // 備考１０
        //    importWork.MainSendMailAddrCd = csvWork.MainSendMailAddrCd;             // 主送信先メールアドレス区分
        //    importWork.MailAddress1 = csvWork.MailAddress1;                         // メールアドレス1
        //    importWork.MailSendCode1 = csvWork.MailSendCode1;                       // メール送信区分コード1
        //    importWork.MailSendName1 = GetMailSendName1(csvWork.MailSendCode1);     // メール送信区分名称1
        //    importWork.MailAddrKindCode1 = csvWork.MailAddrKindCode1;               // メールアドレス種別コード1
        //    importWork.MailAddrKindName1 = GetMailAddrKindName1(csvWork.MailAddrKindCode1); // メールアドレス種別名称1
        //    importWork.MailAddress2 = csvWork.MailAddress2;                         // メールアドレス２
        //    importWork.MailSendCode2 = csvWork.MailSendCode2;                       // メール送信区分コード２
        //    importWork.MailSendName2 = GetMailSendName2(csvWork.MailSendCode2);     // メール送信区分名称1
        //    importWork.MailAddrKindCode2 = csvWork.MailAddrKindCode2;               // メールアドレス種別コード２
        //    importWork.MailAddrKindName2 = GetMailAddrKindName2(csvWork.MailAddrKindCode2); // メールアドレス種別名称1
        //    importWork.AccountNoInfo1 = csvWork.AccountNoInfo1;                     // 銀行口座１
        //    importWork.AccountNoInfo2 = csvWork.AccountNoInfo2;                     // 銀行口座２
        //    importWork.AccountNoInfo3 = csvWork.AccountNoInfo3;                     // 銀行口座３
        //    importWork.BillOutputCode = csvWork.BillOutputCode;                     // 請求書出力区分コード
        //    importWork.BillOutputName = GetBillOutputName(csvWork.BillOutputCode);  // 請求書出力区分名称
        //    importWork.ReceiptOutputCode = csvWork.ReceiptOutputCode;               // 領収書出力区分コード
        //    importWork.DmOutCode = csvWork.DmOutCode;                               // DM出力区分
        //    importWork.DmOutName = GetDmOutName(csvWork.DmOutCode);                 // DM出力区分名称
        //    importWork.SalesSlipPrtDiv = csvWork.SalesSlipPrtDiv;                   // 売上伝票発行区分
        //    importWork.AcpOdrrSlipPrtDiv = csvWork.AcpOdrrSlipPrtDiv;               // 受注伝票発行区分
        //    importWork.ShipmSlipPrtDiv = csvWork.ShipmSlipPrtDiv;                   // 出荷伝票発行区分
        //    importWork.EstimatePrtDiv = csvWork.EstimatePrtDiv;                     // 見積書発行区分
        //    importWork.UOESlipPrtDiv = csvWork.UOESlipPrtDiv;                       // UOE伝票発行区分
        //    importWork.QrcodePrtCd = csvWork.QrcodePrtCd;                           // QRコード印刷
        //    importWork.CustSlipNoMngCd = csvWork.CustSlipNoMngCd;                   // 相手伝票番号管理区分
        //    importWork.CustomerSlipNoDiv = csvWork.CustomerSlipNoDiv;               // 得意先伝票番号区分
        //    importWork.TotalBillOutputDiv = csvWork.TotalBillOutputDiv;             // 合計請求書出力区分
        //    importWork.DetailBillOutputCode = csvWork.DetailBillOutputCode;         // 明細請求書出力区分
        //    importWork.SlipTtlBillOutputDiv = csvWork.SlipTtlBillOutputDiv;         // 伝票合計請求書出力区分

        //    return importWork;
        //}
        //#endregion
        // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
        #region DB登録用のオブジェクトの作成
        /// <summary>
        /// DB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private CustRateGroupWork ConvertToImportRateWork(CustRateGroupWork csvWork, CustRateGroupWork searchWork, bool isUpdFlg)
        {
            CustRateGroupWork importWork = new CustRateGroupWork();
            if (isUpdFlg)
            {
                // 更新の場合
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // 論理削除区分
            }
            importWork.CustRateGrpCode = csvWork.CustRateGrpCode;                   //得意先掛率グループコード
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // 企業コード
            importWork.CustomerCode = csvWork.CustomerCode;                         // 得意先コード
            importWork.PureCode = csvWork.PureCode;                                 // 純正区分
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         //商品メーカーコード
            return importWork;
        }
        #endregion
        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
        // --------------- ADD START 2023/06/28 3H 仰亮亮 -------->>>>
        #region 諸口名称の取得
        /// <summary>
        /// 諸口名称の取得
        /// </summary>
        /// <param name="code">諸口コード</param>
        /// <returns>名称</returns>
        /// <br>Note       : 諸口名称の取得処理を行う</br>
        /// <br>Programmer : 3H 仰亮亮</br>
        /// <br>Date       : 2023/06/28</br>
        private string GetOutputNameNew(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "得意先名称１・２";
                    break;
                case 1:
                    retName = "得意先名称１";
                    break;
                case 2:
                    retName = "得意先名称２";
                    break;
                case 3:
                    retName = "諸口名称";
                    break;
            }
            return retName;
        }
        #endregion
        // --------------- ADD END 2023/06/28 3H 仰亮亮--------<<<<
        #region 諸口名称の取得
        /// <summary>
        /// 諸口名称の取得
        /// </summary>
        /// <param name="code">諸口コード</param>
        /// <returns>名称</returns>
        /// <br>Note       : 諸口名称の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetOutputName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "顧客名称１・２";
                    break;
                case 1:
                    retName = "顧客名称１";
                    break;
                case 2:
                    retName = "顧客名称２";
                    break;
                case 3:
                    retName = "諸口名称";
                    break;
            }
            return retName;
        }
        #endregion

        #region 請求書出力区分名称の取得
        /// <summary>
        /// 請求書出力区分名称の取得
        /// </summary>
        /// <param name="code">請求書出力区分コード</param>
        /// <returns>名称</returns>
        /// <br>Note       : 請求書出力区分名称の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetBillOutputName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "する";
                    break;
                case 1:
                    retName = "しない";
                    break;
            }
            return retName;
        }
        #endregion

        #region 集金月区分名称の取得
        /// <summary>
        /// 集金月区分名称の取得
        /// </summary>
        /// <param name="code">集金月区分コード</param>
        /// <returns>名称</returns>
        /// <br>Note       : 集金月区分名称の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetCollectMoneyName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "当月";
                    break;
                case 1:
                    retName = "翌月";
                    break;
                case 2:
                    retName = "翌々月";
                    break;
                case 3:
                    retName = "翌々々月";
                    break;
            }
            return retName;
        }
        #endregion

        #region DM出力区分名称の取得
        /// <summary>
        /// DM出力区分名称の取得
        /// </summary>
        /// <param name="code">DM出力区分</param>
        /// <returns>名称</returns>
        /// <br>Note       : DM出力区分名称の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetDmOutName(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "する";
                    break;
                case 1:
                    retName = "しない";
                    break;
            }
            return retName;
        }
        #endregion

        #region メールアドレス種別名称1の取得
        /// <summary>
        /// メールアドレス種別名称1の取得
        /// </summary>
        /// <param name="code">メールアドレス種別コード１</param>
        /// <returns>名称</returns>
        /// <br>Note       : メールアドレス種別名称1の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailAddrKindName1(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "自宅";
                    break;
                case 1:
                    retName = "会社";
                    break;
                case 2:
                    retName = "携帯端末";
                    break;
                case 3:
                    retName = "本人以外";
                    break;
                case 99:
                    retName = "その他";
                    break;
            }
            return retName;
        }
        #endregion

        #region メール送信区分名称1の取得
        /// <summary>
        /// メール送信区分名称1の取得
        /// </summary>
        /// <param name="code">メール送信区分コード１</param>
        /// <returns>名称</returns>
        /// <br>Note       : メール送信区分名称1の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailSendName1(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "送信しない";
                    break;
                case 1:
                    retName = "送信する";
                    break;
            }
            return retName;
        }
        #endregion

        #region メールアドレス種別名称2の取得
        /// <summary>
        /// メールアドレス種別名称2の取得
        /// </summary>
        /// <param name="code">メールアドレス種別コード２</param>
        /// <returns>名称</returns>
        /// <br>Note       : メールアドレス種別名称2の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailAddrKindName2(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "自宅";
                    break;
                case 1:
                    retName = "会社";
                    break;
                case 2:
                    retName = "携帯端末";
                    break;
                case 3:
                    retName = "本人以外";
                    break;
                case 99:
                    retName = "その他";
                    break;
            }
            return retName;
        }
        #endregion

        #region メール送信区分名称2の取得
        /// <summary>
        /// メール送信区分名称2の取得
        /// </summary>
        /// <param name="code">メール送信区分コード２</param>
        /// <returns>名称</returns>
        /// <br>Note       : メール送信区分名称2の取得処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private string GetMailSendName2(Int32 code)
        {
            string retName = string.Empty;
            switch (code)
            {
                case 0:
                    retName = "送信しない";
                    break;
                case 1:
                    retName = "送信する";
                    break;
            }
            return retName;
        }
        #endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
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
    }

    #region 得意先情報オブジェクト
    /// <summary>
    /// 得意先情報オブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先情報オブジェクトです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class CustomerImportWorkWrap
    {
        #region Public Field
        public CustomerWork customerWork;
        #endregion

        #region クラスコンストラクタ
        /// <summary>
        /// 得意先情報オブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先情報オブジェクトを取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public CustomerImportWorkWrap(CustomerWork customer)
        {
            this.customerWork = customer;
        }
        #endregion

        #region 得意先情報オブジェクトのイコールの比較
        /// <summary>
        /// 得意先情報オブジェクトのイコールの比較
        /// </summary>
        /// <param name="obj">得意先情報オブジェクト</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報オブジェクトのイコールかどうかを比較する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            CustomerImportWorkWrap target = obj as CustomerImportWorkWrap;
            if (target == null) return false;
            // 企業コード、得意先コード
            // が同じ場合、得意先情報オブジェクトはイコールにする。
            return target.customerWork.EnterpriseCode == customerWork.EnterpriseCode
                     && target.customerWork.CustomerCode == customerWork.CustomerCode;
        }
        #endregion

        #region 得意先情報オブジェクトのハシコード
        /// <summary>
        /// 得意先情報オブジェクトのハシコード
        /// </summary>
        /// <returns>ハシコード</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報オブジェクトのハシコードを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return customerWork.EnterpriseCode.GetHashCode()
                     + customerWork.CustomerCode.GetHashCode();
        }
        #endregion
    }
    #endregion

    // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
    #region 得意先掛率グループオブジェクト
    /// <summary>
    /// 得意先掛率グループオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先掛率グループオブジェクトです。</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class CustomerRateImportWorkWrap
    {
        #region Public Field
        public CustRateGroupWork custRateGroupWork;
        #endregion

        #region クラスコンストラクタ
        /// <summary>
        /// 得意先掛率グループオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループオブジェクトを取得します。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public CustomerRateImportWorkWrap(CustRateGroupWork custRateGroup)
        {
            this.custRateGroupWork = custRateGroup;
        }
        #endregion

        #region 得意先掛率グループオブジェクトのイコールの比較
        /// <summary>
        /// 得意先掛率グループオブジェクトのイコールの比較
        /// </summary>
        /// <param name="obj">得意先掛率グループオブジェクト</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループオブジェクトのイコールかどうかを比較する。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            CustomerRateImportWorkWrap target = obj as CustomerRateImportWorkWrap;
            if (target == null) return false;
            // 企業コード、得意先コード
            // が同じ場合、得意先情報オブジェクトはイコールにする。
            return target.custRateGroupWork.EnterpriseCode == custRateGroupWork.EnterpriseCode
                     && target.custRateGroupWork.CustomerCode == custRateGroupWork.CustomerCode
                     && target.custRateGroupWork.PureCode == custRateGroupWork.PureCode
                     && target.custRateGroupWork.GoodsMakerCd == custRateGroupWork.GoodsMakerCd;
        }
        #endregion

        #region 得意先掛率グループオブジェクトのハシコード
        /// <summary>
        /// 得意先掛率グループオブジェクトのハシコード
        /// </summary>
        /// <returns>ハシコード</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループオブジェクトのハシコードを設定する。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return custRateGroupWork.EnterpriseCode.GetHashCode()
                     + custRateGroupWork.CustomerCode.GetHashCode()
                     + custRateGroupWork.PureCode.GetHashCode()
                     + custRateGroupWork.GoodsMakerCd.GetHashCode();
        }
        #endregion
    }
    #endregion
    // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
}
