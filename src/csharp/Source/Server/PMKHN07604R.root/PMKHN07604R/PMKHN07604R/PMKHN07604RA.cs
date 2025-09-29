//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（インポート）
// プログラム概要   : 在庫マスタ（インポート）DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangy3
// 作 成 日  2012/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10801804-00  作成担当 : zhangy3 
// 修 正 日 2012/07/03   修正内容 : Redmine#30387 商品マスタインボートチェックの追加
//----------------------------------------------------------------------------//
// 管理番号 10801804-00  作成担当 : zhangy3 
// 修 正 日 2012/07/05   修正内容 : Redmine#30387障害一覧の指摘NO.30の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/11  修正内容 ：Redmine#30387障害一覧の指摘NO.30の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/12  修正内容 ：Redmine#30387障害一覧の指摘NO.93の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/13  修正内容 ：Redmine#30387障害一覧の指摘NO.94の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/25  修正内容 : 大陽案件、Redmine#30387 重複チェックのメッセージを変更する
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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタ（インポート）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ（インポート）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : zhangy3</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/11 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             障害一覧の指摘NO.30の対応</br>
    /// <br>Update Note: 2012/07/12 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             障害一覧の指摘NO.93の対応</br>
    /// <br>Update Note: 2012/07/13 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             障害一覧の指摘NO.94の対応</br>
    /// <br>Update Note: 2012/07/20 zhangy3</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387 在庫マスタインボート仕様変更の対応</br>
    /// <br>Update Note: 2012/07/25 zhangy3</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387 重複チェックのメッセージを変更する</br>
    /// </remarks>
    [Serializable]
    public class StockImportDB : RemoteWithAppLockDB, IStockImportDB
    {

        # region Private Member
        //企業コード
        private string _enterpriseCode;
        //ログイン拠点コード
        private string _loginSectionCode;
        //ログイン拠点名称
        private string _loginSectionGuideNm;
        //ログイン従業員コード
        private string _employeeCode;
        //ログイン従業員名称
        private string _employeeName;
        #endregion

        #region IStockImportDB メンバ

        /// <summary>
        /// 在庫マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="importStockWorkList">在庫マスタリスト</param>
        /// <param name="objStockCheckList">在庫マスタチェックリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="loginSectionCode">ログイン拠点コード</param>
        /// <param name="loginSectionGuideNm">ログイン拠点名称</param>
        /// <param name="employeeCode">ログイン従業員コード</param>
        /// <param name="employeeName">ログイン従業員名称</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errStockCheckWorks">エラー在庫マスタチェックリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）のインポート処理</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        //public int Import(int processKbn, ref object importStockWorkList, ref object objStockCheckList,string enterpriseCode, string loginSectionCode, string loginSectionGuideNm, string employeeCode, string employeeName, out int readCnt, out int addCnt, out int updCnt, out int errCnt,out DataTable errTable,out string errMsg)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        //public int Import(int processKbn, ref object importStockWorkList, ref object objStockCheckList, string enterpriseCode, string loginSectionCode, string loginSectionGuideNm, string employeeCode, string employeeName, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
        public int Import(int processKbn, int dataCheckKbn, ref object importStockWorkList, ref object objStockCheckList, string enterpriseCode, string loginSectionCode, string loginSectionGuideNm, string employeeCode, string employeeName, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        {
            //ログイン従業員コード
            this._employeeCode = employeeCode;
            //ログイン従業員名称
            this._employeeName = employeeName;
            //企業コード
            this._enterpriseCode = enterpriseCode;
            //ログイン拠点コード
            this._loginSectionCode = loginSectionCode;
            //ログイン拠点名称
            this._loginSectionGuideNm = loginSectionGuideNm;
            //return this.ImportProc(processKbn, ref importStockWorkList, ref objStockCheckList, out readCnt, out addCnt, out updCnt, out errCnt, out errTable, out errMsg);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            //return this.ImportProc(processKbn, ref importStockWorkList, ref objStockCheckList, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
            return this.ImportProc(processKbn, dataCheckKbn, ref importStockWorkList, ref objStockCheckList, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        }

        /// <summary>
        /// 在庫マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="importStockWorkList">在庫マスタリスト</param>
        /// <param name="importStockWorkCheckList">在庫マスタチェックリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errStockCheckWorks">エラー在庫マスタチェックリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（インポート）のインポート処理</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        //private int ImportProc(int processKbn, ref object importStockWorkList, ref object importStockWorkCheckList, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out DataTable errTable, out string errMsg)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        //private int ImportProc(int processKbn, ref object importStockWorkList, ref object importStockWorkCheckList, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
        private int ImportProc(int processKbn, int dataCheckKbn, ref object importStockWorkList, ref object importStockWorkCheckList, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            //errTable = new DataTable();//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            int index = 0;
            errMsg = string.Empty;
            StockDB stockDB = new StockDB();
            StockAdjustDB stockAdjustDB = new StockAdjustDB();
            errStockCheckWorks = null;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
            try
            {
                //テーブルの作成
                //CreateDataTable(ref errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                // 在庫マスタ追加リスト
                ArrayList addList = new ArrayList();
                // 在庫マスタ更新リスト
                ArrayList updList = new ArrayList();

                ArrayList errList = new ArrayList();

                // 在庫マスタ
                ArrayList importWorkList = importStockWorkList as ArrayList;
                // 在庫マスタチェック
                ArrayList importCheckWorkList = importStockWorkCheckList as ArrayList;
               
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
                // エラー在庫マスタチェックリスト
                ArrayList errStockCheckWork = new ArrayList();
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<
                // 在庫情報全てデータの検索処理
                ArrayList stockWorkList = new ArrayList();

                object objectstockWork = stockWorkList as object;
                //パラメータの設定
                StockWork stockWork = new StockWork();
                if (importWorkList == null)
                {
                    //インポートワークがNULL時にERRORを戻る
                    return status;
                }
                else
                {
                    //コードを設定
                    stockWork.EnterpriseCode = ((StockWork)importWorkList[0]).EnterpriseCode;
                }
                //パラメータ
                object objectparastockWork = stockWork as object;
                
                // 在庫情報全てデータの捜す
                status = stockDB.Search(out objectstockWork, objectparastockWork, 0, ConstantManagement.LogicalMode.GetData01);

                stockWorkList = objectstockWork as ArrayList;

                // Dictionaryの作成
                Dictionary<StockSearchUImportWorkWrap, StockWork> dict = new Dictionary<StockSearchUImportWorkWrap, StockWork>();
                foreach (StockWork work in stockWorkList)
                {
                    work.WarehouseCode = work.WarehouseCode.Trim();
                    StockSearchUImportWorkWrap warp = new StockSearchUImportWorkWrap(work);
                    dict.Add(warp, work);
                }

                //追加のフラグ
                bool flgAdd = IsNeedAddCnt(1,processKbn);

                //更新のフラグ
                bool flgUp = IsNeedAddCnt(2, processKbn);

                //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                List<StockCheckWork> lst = new List<StockCheckWork>();
                StockCheckWork[] stockArray = (StockCheckWork[])importCheckWorkList.ToArray(typeof(StockCheckWork));
                lst.AddRange(stockArray);
                //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
                foreach (StockWork importWork in importWorkList)
                {
                    bool flg = false;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                    //CheckClass checkCls;//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                    StockSearchUImportWorkWrap importWarp = new StockSearchUImportWorkWrap(importWork);
                    StockCheckWork stockCheckWork = (StockCheckWork)importCheckWorkList[index];
                    index++;
                    if (!dict.ContainsKey(importWarp))
                    {
                        if (flgAdd)
                        {
                            //インポートのチェック
                            //ImportCheck(stockCheckWork, out checkCls);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            //flg = ImportCheck(ref stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                            flg = ImportCheck(stockCheckWork, dataCheckKbn, lst);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                            //エラーリストに存在しなければ、追加リストへできません。
                            //if (checkCls != null)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            if (flg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                            {
                                //InsertDataIntoTable(checkCls, ref errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errStockCheckWork.Add(stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errCnt++;
                                continue;
                            }
                        }
                        // レコードが存在しなければ、追加リストへ追加する。
                        addList.Add(ConvertToImportWork(importWork, null, false));
                    }
                    else
                    {
                        if (flgUp)
                        {
                            //インポートのチェック
                            //ImportCheck(stockCheckWork, out checkCls);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            //flg = ImportCheck(ref stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                            flg = ImportCheck(stockCheckWork, dataCheckKbn, lst);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                            //if (checkCls != null)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            if (flg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                            {
                                //InsertDataIntoTable(checkCls, ref errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errStockCheckWork.Add(stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errCnt++;
                                continue;
                            }
                        }
                        // レコードが存在すれば、更新リストへ追加する。
                        updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
                    }
                    
                }

                // 読込件数
                readCnt = importWorkList.Count;

                CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();

                // 処理区分が「追加」の場合
                if (processKbn == 1)
                {
                    if (addList.Count > 0)
                    {
                        saveDataList = this.CreateSaveData(addList, new ArrayList(), dict);

                        object objSaveData = (object)saveDataList;
                        
                        status = stockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        addCnt = addList.Count;
                    }
                }
                else if (processKbn == 2)
                {
                    // 処理区分が「更新」の場合
                    if (updList.Count > 0)
                    {
                        saveDataList = this.CreateSaveData(new ArrayList(), updList, dict);

                        object objSaveData = (object)saveDataList;

                        status = stockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        updCnt = updList.Count;
                    }
                }
                else
                {
                    if (addList.Count > 0 || updList.Count > 0)
                    {
                        // 処理区分が「追加更新」の場合
                        saveDataList = this.CreateSaveData(addList, updList, dict);

                        object objSaveData = (object)saveDataList;

                        status = stockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                errStockCheckWorks = (object)errStockCheckWork;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
   
        #endregion

        #region 在庫検索情報オブジェクト
        /// <summary>
        /// 在庫検索情報オブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫検索情報オブジェクトです。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        class StockSearchUImportWorkWrap
        {
            #region Public Field
            public StockWork stockWork;
            #endregion

            #region クラスコンストラクタ

            /// <summary>
            /// 在庫検索情報オブジェクト
            /// </summary>
            /// <param name="stockWork">在庫ワーク</param>
            /// <remarks>
            /// <br>Note       : 在庫検索情報オブジェクト</br>
            /// <br>Programmer : zhangy3</br>
            /// <br>Date       : 2012/06/12</br>
            /// </remarks>
            public StockSearchUImportWorkWrap(StockWork stockWork)
            {
                this.stockWork = stockWork;
            }

            #endregion

            #region 結合検索情報オブジェクトのイコールの比較
            /// <summary>
            /// 在庫検索情報オブジェクトのイコールの比較
            /// </summary>
            /// <param name="obj">在庫検索情報オブジェクト</param>
            /// <returns>比較結果</returns>
            /// <remarks>
            /// <br>Note       : 在庫検索情報オブジェクトのイコールの比較</br>
            /// <br>Programmer : zhangy3</br>
            /// <br>Date       : 2012/06/12</br>
            /// </remarks>
            public override bool Equals(object obj)
            {
                StockSearchUImportWorkWrap target = obj as StockSearchUImportWorkWrap;
                if (target == null) return false;
                // 倉庫コード、商品番号、商品メーカーコード
                // が同じ場合、在庫情報オブジェクトはイコールにする。
                return target.stockWork.EnterpriseCode == stockWork.EnterpriseCode
                         && target.stockWork.WarehouseCode == stockWork.WarehouseCode
                         && target.stockWork.GoodsNo == stockWork.GoodsNo
                         && target.stockWork.GoodsMakerCd == stockWork.GoodsMakerCd;
            }
             #endregion

            #region 在庫検索情報オブジェクトのハシコード
            /// <summary>
            /// 在庫検索情報オブジェクトのハシコード
            /// </summary>
            /// <returns>ハシコード</returns>
            /// <remarks>
            /// <br>Note       : 在庫検索情報オブジェクトのハシコード</br>
            /// <br>Programmer : zhangy3</br>
            /// <br>Date       : 2012/06/12</br>
            /// </remarks>
            public override int GetHashCode()
            {
                int val= stockWork.EnterpriseCode.GetHashCode()
                         + stockWork.WarehouseCode.GetHashCode()
                         + stockWork.GoodsNo.GetHashCode()
                         + stockWork.GoodsMakerCd.GetHashCode();
                return val;
            }
            #endregion
        }
        #endregion

        #region ◎ 保存用データの作成

        /// <summary>
        /// 保存用データ生成処理
        /// </summary>
        /// <param name="addList">追加リスト</param>
        /// <param name="updList">更新リスト</param>
        /// <param name="dict">Dictionary</param>
        /// <returns>保存用データ(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : 保存用データ生成処理。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(ArrayList addList, ArrayList updList, Dictionary<StockSearchUImportWorkWrap, StockWork> dict)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList dataList = new ArrayList();
            CustomSerializeArrayList tempList = new CustomSerializeArrayList();

            //更新の処理
            foreach (StockWork updWork in updList)
            {
                StockSearchUImportWorkWrap updWarp = new StockSearchUImportWorkWrap(updWork);

                if (Math.Abs(dict[updWarp].SupplierStock - updWork.SupplierStock) != 0)
                {
                    //在庫調整
                    CreateStockAdjust(ref stockAdjustWorkList);
                    //在庫調整明細
                    CreateStockAdjustDtl(ref stockAdjustDtlWorkList, updWork);
                }

                updWork.SupplierStock = updWork.SupplierStock - dict[updWarp].SupplierStock;
                updWork.AcpOdrCount = updWork.AcpOdrCount - dict[updWarp].AcpOdrCount;
                updWork.SalesOrderCount = updWork.SalesOrderCount - dict[updWarp].SalesOrderCount;
                updWork.MovingSupliStock = updWork.MovingSupliStock - dict[updWarp].MovingSupliStock;
                updWork.ShipmentCnt = updWork.ShipmentCnt - dict[updWarp].ShipmentCnt;
                updWork.ArrivalCnt = updWork.ArrivalCnt - dict[updWarp].ArrivalCnt;

            }

            //新規の処理
            foreach (StockWork addwork in addList)
            {
                if (!string.IsNullOrEmpty(addwork.SupplierStock.ToString()) && addwork.SupplierStock > 0)
                {
                    //在庫調整
                    CreateStockAdjust(ref stockAdjustWorkList);
                    //在庫調整明細
                    CreateStockAdjustDtl(ref stockAdjustDtlWorkList, addwork);
                }
            }

            if (stockAdjustWorkList.Count > 0)
            {
                // 在庫調整データ追加
                tempList.Add(stockAdjustWorkList);
            }

            if (stockAdjustDtlWorkList.Count > 0)
            {
                // 在庫調整明細データ追加
                tempList.Add(stockAdjustDtlWorkList);
            }

            if (addList.Count > 0)
            {
                dataList.AddRange(addList.GetRange(0, addList.Count));
            }
            if (updList.Count > 0)
            {
                dataList.AddRange(updList.GetRange(0, updList.Count));
            }

            if (dataList.Count > 0)
            {
                // 在庫マスタ追加
                tempList.Add(dataList);
            }

            saveDataList.Add(tempList);

            return saveDataList;
        }

        /// <summary>
        /// 在庫調整データワーククラス生成処理
        /// </summary>
        /// <param name="stockAdjustWorkList">在庫調整データワーククラス</param>
        /// <remarks>
        /// <br>Note       : 在庫調整データワーククラスを生成します。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateStockAdjust(ref ArrayList stockAdjustWorkList)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode.Trim();
            // 拠点名称
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 受払元伝票区分(42：マスタメンテ)
            workData.AcPaySlipCd = 42;
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;
            // 調整日付
            workData.AdjustDate = DateTime.Today;
            // 入力日付
            workData.InputDay = DateTime.Today;
            // 仕入拠点コード
            workData.StockSectionCd = this._loginSectionCode;
            // 仕入拠点名称
            workData.StockSectionGuideNm = this._loginSectionGuideNm;
            // 仕入入力者コード
            workData.StockInputCode = this._employeeCode;
            // 仕入担当者コード
            workData.StockAgentCode = this._employeeCode;
            if (this._employeeName.Length > 16)
            {
                // 仕入入力者名称
                workData.StockInputName = this._employeeName.Substring(0, 16);
                // 仕入担当者名称
                workData.StockAgentName = this._employeeName.Substring(0, 16);
            }
            else
            {
                // 仕入入力者名称
                workData.StockInputName = this._employeeName;
                // 仕入担当者名称
                workData.StockAgentName = this._employeeName;
            }

            stockAdjustWorkList.Add(workData);
        }

        /// <summary>
        /// 在庫調整明細データワーククラス生成処理
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">在庫調整明細データリスト</param>
        /// <param name="work">在庫ワーク</param>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラスを生成します。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateStockAdjustDtl(ref ArrayList stockAdjustDtlWorkList, StockWork work)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();
            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode.Trim();
            // 拠点名称
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
            // 受払元伝票区分(42：マスタメンテ)
            workData.AcPaySlipCd = 42;
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;
            // 調整日付
            workData.AdjustDate = DateTime.Today;
            // 入力日付
            workData.InputDay = DateTime.Today;
            // 商品番号
            workData.GoodsNo = work.GoodsNo;
            // 倉庫コード
            workData.WarehouseCode = work.WarehouseCode;

            stockAdjustDtlWorkList.Add(workData);
        }

        #endregion

        #region ◎ DB登録用のオブジェクトの作成
        /// <summary>
        /// DB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <returns>在庫ワーク</returns>
        /// <remarks>
        /// <br>Note       : DB登録用のオブジェクトの作成</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private StockWork ConvertToImportWork(StockWork csvWork, StockWork searchWork, bool isUpdFlg)
        {
            StockWork importWork = new StockWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = System.DateTime.Now;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // 有効
                importWork.UpdEmployeeCode = this._employeeCode;
                importWork.UpdAssemblyId1 = searchWork.UpdAssemblyId1;
                importWork.UpdAssemblyId2 = searchWork.UpdAssemblyId2;

                //M/O発注数
                importWork.MonthOrderCount = searchWork.MonthOrderCount;
                //在庫保有総額
                importWork.StockTotalPrice = searchWork.StockTotalPrice;
                //最終仕入年月日
                importWork.LastStockDate = searchWork.LastStockDate;
                //最終売上日
                importWork.LastSalesDate = searchWork.LastSalesDate;
                //最終棚卸更新日
                importWork.LastInventoryUpdate = searchWork.LastInventoryUpdate;
                //基準発注数
                importWork.NmlSalOdrCount = searchWork.NmlSalOdrCount;
                //ハイフン無商品番号
                importWork.GoodsNoNoneHyphen = searchWork.GoodsNoNoneHyphen;
                //在庫登録日
                importWork.StockCreateDate = searchWork.StockCreateDate;

                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)searchWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
            }
            else
            {
                //M/O発注数
                importWork.MonthOrderCount = 0;
                //在庫保有総額
                importWork.StockTotalPrice = 0;
                //基準発注数
                importWork.NmlSalOdrCount = 0;
                //ハイフン無商品番号
                importWork.GoodsNoNoneHyphen = string.Empty;
                //在庫登録日
                importWork.StockCreateDate = System.DateTime.Now;
            }

            importWork.EnterpriseCode = csvWork.EnterpriseCode;                  // 企業コード

            //拠点コード
            importWork.SectionCode = csvWork.SectionCode;
            //倉庫コード
            importWork.WarehouseCode = csvWork.WarehouseCode;
            //商品メーカーコード
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;
            //商品番号
            importWork.GoodsNo = csvWork.GoodsNo;
            //仕入単価（税抜,浮動）
            importWork.StockUnitPriceFl = csvWork.StockUnitPriceFl;
            //仕入在庫数
            importWork.SupplierStock = csvWork.SupplierStock;
            //受注数
            importWork.AcpOdrCount = csvWork.AcpOdrCount;
            //発注数
            importWork.SalesOrderCount = csvWork.SalesOrderCount;
            //在庫区分
            importWork.StockDiv = csvWork.StockDiv;
            //移動中仕入在庫数
            importWork.MovingSupliStock = csvWork.MovingSupliStock;
            //出荷可能数
            importWork.ShipmentPosCnt = csvWork.ShipmentPosCnt;
            //最低在庫数
            importWork.MinimumStockCnt = csvWork.MinimumStockCnt;
            //最高在庫数
            importWork.MaximumStockCnt = csvWork.MaximumStockCnt;
            //発注単位
            importWork.SalesOrderUnit = csvWork.SalesOrderUnit;
            //在庫発注先コード
            importWork.StockSupplierCode = csvWork.StockSupplierCode;
            //倉庫棚番
            importWork.WarehouseShelfNo = csvWork.WarehouseShelfNo;
            //重複棚番１
            importWork.DuplicationShelfNo1 = csvWork.DuplicationShelfNo1;
            //重複棚番２
            importWork.DuplicationShelfNo2 = csvWork.DuplicationShelfNo2;
            //部品管理区分１
            importWork.PartsManagementDivide1 = csvWork.PartsManagementDivide1;
            //部品管理区分２
            importWork.PartsManagementDivide2 = csvWork.PartsManagementDivide2;
            //在庫備考１
            importWork.StockNote1 = csvWork.StockNote1;
            //在庫備考２
            importWork.StockNote2 = csvWork.StockNote2;
            //出荷数（未計上）
            importWork.ShipmentCnt = csvWork.ShipmentCnt;
            //入荷数（未計上）
            importWork.ArrivalCnt = csvWork.ArrivalCnt;
            //更新年月日
            importWork.UpdateDate = System.DateTime.Now;

            return importWork;
        }

        #endregion

        # region 項目チェック
        /* DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
        /// <summary>
        /// テーブルに値を追加
        /// </summary>
        /// <param name="ckCls">エラーリスト</param>
        /// <param name="errTable">エラーテーブル</param>
        /// <remarks>
        /// <br>Note       : テーブルに値を追加</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void InsertDataIntoTable(CheckClass ckCls, ref DataTable errTable)
        {
            DataRow dr = errTable.NewRow();
            //----- 在庫マスタの内容をテーブルに追加する -----
            //拠点コード
            dr["SectionCode"] = ckCls.StockCheckWork.SectionCode;

            //倉庫コード
            dr["WarehouseCode"] = ckCls.StockCheckWork.WarehouseCode;

            //商品メーカーコード
            dr["GoodsMakerCd"] = ckCls.StockCheckWork.GoodsMakerCd;

            //商品番号
            dr["GoodsNo"] = ckCls.StockCheckWork.GoodsNo;

            //仕入単価（税抜,浮動）
            dr["StockUnitPriceFl"] = ckCls.StockCheckWork.StockUnitPriceFl;

            //仕入在庫数
            dr["SupplierStock"] = ckCls.StockCheckWork.SupplierStock;

            //入荷数（未計上）
            dr["ArrivalCnt"] = ckCls.StockCheckWork.ArrivalCnt;

            //出荷数（未計上）
            dr["ShipmentCnt"] = ckCls.StockCheckWork.ShipmentCnt;

            //受注数
            dr["AcpOdrCount"] = ckCls.StockCheckWork.AcpOdrCount;

            //移動中仕入在庫数
            dr["MovingSupliStock"] = ckCls.StockCheckWork.MovingSupliStock;

            //出荷可能数
            dr["ShipmentPosCnt"] = ckCls.StockCheckWork.ShipmentPosCnt;

            //発注数
            dr["SalesOrderCount"] = ckCls.StockCheckWork.SalesOrderCount;

            //在庫区分
            dr["StockDiv"] = ckCls.StockCheckWork.StockDiv;

            //最低在庫数
            dr["MinimumStockCnt"] = ckCls.StockCheckWork.MinimumStockCnt;

            //最高在庫数
            dr["MaximumStockCnt"] = ckCls.StockCheckWork.MaximumStockCnt;

            //発注単位
            dr["SalesOrderUnit"] = ckCls.StockCheckWork.SalesOrderUnit;

            //在庫発注先コード
            dr["StockSupplierCode"] = ckCls.StockCheckWork.StockSupplierCode;

            //倉庫棚番
            dr["WarehouseShelfNo"] = ckCls.StockCheckWork.WarehouseShelfNo;

            //重複棚番１
            dr["DuplicationShelfNo1"] = ckCls.StockCheckWork.DuplicationShelfNo1;

            //重複棚番２
            dr["DuplicationShelfNo2"] = ckCls.StockCheckWork.DuplicationShelfNo2;

            //部品管理区分１
            dr["PartsManagementDivide1"] = ckCls.StockCheckWork.PartsManagementDivide1;

            //部品管理区分２
            dr["PartsManagementDivide2"] = ckCls.StockCheckWork.PartsManagementDivide2;

            //在庫備考１
            dr["StockNote1"] = ckCls.StockCheckWork.StockNote1;

            //在庫備考２
            dr["StockNote2"] = ckCls.StockCheckWork.StockNote2;

            //----- エラーメッセージを追加する -----
            //メッセージ
            dr["ErrMsg"] = ckCls.Msg;

            errTable.Rows.Add(dr);
        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            //拠点コード
            dataTable.Columns.Add("SectionCode", typeof(string)); 
  
            //倉庫コード
            dataTable.Columns.Add("WarehouseCode", typeof(string)); 
            
            //商品メーカーコード
            dataTable.Columns.Add("GoodsMakerCd", typeof(string)); 

            //商品番号
            dataTable.Columns.Add("GoodsNo", typeof(string)); 

            //仕入単価（税抜,浮動）
            dataTable.Columns.Add("StockUnitPriceFl", typeof(string)); 
            
            //仕入在庫数
            dataTable.Columns.Add("SupplierStock", typeof(string)); 
            
            //入荷数（未計上）
            dataTable.Columns.Add("ArrivalCnt", typeof(string)); 
            
            //出荷数（未計上）
            dataTable.Columns.Add("ShipmentCnt", typeof(string)); 
            
            //受注数
            dataTable.Columns.Add("AcpOdrCount", typeof(string)); 
            
            //移動中仕入在庫数
            dataTable.Columns.Add("MovingSupliStock", typeof(string)); 
            
            //出荷可能数
            dataTable.Columns.Add("ShipmentPosCnt", typeof(string));
            
            //発注数
            dataTable.Columns.Add("SalesOrderCount", typeof(string));
            
            //在庫区分
            dataTable.Columns.Add("StockDiv", typeof(string));
            
            //最低在庫数
            dataTable.Columns.Add("MinimumStockCnt", typeof(string));
            
            //最高在庫数
            dataTable.Columns.Add("MaximumStockCnt", typeof(string));
            
            //発注単位
            dataTable.Columns.Add("SalesOrderUnit", typeof(string));
            
            //在庫発注先コード
            dataTable.Columns.Add("StockSupplierCode", typeof(string));
            
            //倉庫棚番
            dataTable.Columns.Add("WarehouseShelfNo", typeof(string));
            
            //重複棚番１
            dataTable.Columns.Add("DuplicationShelfNo1", typeof(string));
            
            //重複棚番２
            dataTable.Columns.Add("DuplicationShelfNo2", typeof(string));
            
            //部品管理区分１
            dataTable.Columns.Add("PartsManagementDivide1", typeof(string));
            
            //部品管理区分２
            dataTable.Columns.Add("PartsManagementDivide2", typeof(string));
            
            //在庫備考１
            dataTable.Columns.Add("StockNote1", typeof(string));
            
            //在庫備考２
            dataTable.Columns.Add("StockNote2", typeof(string));

            //メッセージ
            dataTable.Columns.Add("ErrMsg", typeof(string));
            
        }
        * DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<< */

        /// <summary>
        /// エラーリストに追加の必要を判断する
        /// </summary>
        /// <param name="val">値(1:追加2:更新)</param>
        /// <param name="processKbn">処理区分</param>
        /// <returns>判断結果</returns>
        /// <remarks>
        /// <br>Note       : Addの必要を判断する。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool IsNeedAddCnt(int val, int processKbn)
        {
            //処理区分は追加の場合
            if (processKbn == 1)
            {
                //追加ができます
                if (val == 1)
                    return true;
                //更新ができません
                else
                    return false;
            }
            //処理区分は更新の場合
            else if (processKbn == 2)
            {
                //追加ができません
                if (val == 1)
                    return false;
                //更新ができます
                else
                    return true;
            }
            //処理区分は更新追加の場合
            else
            {
                //更新や追加ができます
                return true;
            }
        }

        /* DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
        /// <summary>
        /// チェッククラスオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : チェッククラスオブジェクトです。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private class CheckClass
        {
            StockCheckWork _stockCheckWork;
            string _msg;

            #region クラスコンストラクタ

            /// <summary>
            /// 在庫マスタ
            /// </summary>
            public StockCheckWork StockCheckWork
            {
                get
                {
                    return _stockCheckWork;
                }
                set
                {
                    _stockCheckWork = value;
                }
            }
            
           /// <summary>
           /// メッセージ
           /// </summary>
            public string Msg
            {
                get
                {
                    return _msg;
                }
                set
                {
                    _msg = value;
                }
            }

            # endregion
        }
        * DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<< */

        /// <summary>
        /// インポートのチェック
        /// </summary>
        /// <param name="stockCheckCls">インポート用のオブジェクト</param>
        /// <param name="dataCheck">チェック区分</param>
        /// <param name="lst">在庫マスタチェックリスト</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : チェックオブジェクトです。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        //private void ImportCheck(StockCheckWork stockCheckCls, out CheckClass checkCls)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        //private bool ImportCheck(ref StockCheckWork stockCheckCls)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
        private bool ImportCheck(StockCheckWork stockCheckCls, int dataCheck, List<StockCheckWork> lst)//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        {
            //チェッククラスの作成
            //checkCls = null;//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            string msg;
            //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
            // チェック区分
            if (1 == dataCheck)
            {
                if (!ImportCheckProc(stockCheckCls, out msg))
                {
                    stockCheckCls.ERRMESSAGE = msg;
                    return true;
                }
            }
            bool repeatDataFlg = false;
            repeatDataFlg = lst.FindAll(delegate(StockCheckWork tmp)
             {
                 if (stockCheckCls.GoodsMakerCd.Equals(tmp.GoodsMakerCd) && stockCheckCls.GoodsNo.Equals(tmp.GoodsNo)
                     && stockCheckCls.WarehouseCode.Equals(tmp.WarehouseCode))
                     return true;
                 else
                     return false;
             }).Count > 1;
            if (repeatDataFlg)
            {
                stockCheckCls.ERRMESSAGE = ERRMSG_DUPLICATE;
                return true;
            }
            //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
            /* DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
            //インポートのチェックする
            if (!ImportCheckProc(stockCheckCls, out msg))
            {
             * DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<*/
            /* DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
                checkCls = new CheckClass();
                //在庫マスタ
                checkCls.StockCheckWork = stockCheckCls;
                //メッセージ
                checkCls.Msg = msg;
                 * DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<*/
            /* DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387--------------->>>>>>
                stockCheckCls.ERRMESSAGE = msg;
                return true;
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387---------------<<<<<<
             * DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<*/
            //}//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
            return false;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
        }

        /// <summary>
        /// インポートのチェック処理
        /// </summary>
        /// <param name="checkCls">在庫マストチェック</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : インポートのチェック処理です。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool ImportCheckProc(StockCheckWork checkCls,out string msg)
        {
            msg = string.Empty;
            //管理拠点
            if (!Check_IsNull("管理拠点", checkCls.SectionCode, out msg) || !Check_Zero("管理拠点", checkCls.SectionCode, out msg))
                return false;
            else
                if (!Check_IntDataAndLen("管理拠点", checkCls.SectionCode, 2, out msg))
                    return false;

            //倉庫
            if (!Check_IsNull("倉庫", checkCls.WarehouseCode, out msg) || !Check_Zero("倉庫", checkCls.WarehouseCode, out msg))
                return false;
            else
                if (!Check_IntDataAndLen("倉庫", checkCls.WarehouseCode, 4, out msg))
                    return false;

            //メーカー
            if (!Check_IsNull("メーカー", checkCls.GoodsMakerCd, out msg) || !Check_Zero("メーカー", checkCls.GoodsMakerCd, out msg))
                return false;
            else
                if (!Check_IntDataAndLen("メーカー", checkCls.GoodsMakerCd, 4, out msg))
                    return false;

            //品番
            if (!Check_IsNull("品番", checkCls.GoodsNo, out msg) || !Check_Zero("品番", checkCls.GoodsNo, out msg))
                return false;
            else
                if (!Check_StrUnFixedLen("品番", checkCls.GoodsNo, 24, out msg))
                    return false;
                else
                    if (!Check_HalfEngNumFixedLength("品番", checkCls.GoodsNo, 24, out msg))
                        return false;

            //棚卸評価単価
            if (!string.IsNullOrEmpty(checkCls.StockUnitPriceFl) && !Check_FloatAndLen("棚卸評価単価", checkCls.StockUnitPriceFl, 9, 2, out msg))
                return false;
                    
            //仕入在庫数
            if (!string.IsNullOrEmpty(checkCls.SupplierStock) && !Check_FloatAndLen("仕入在庫数", checkCls.SupplierStock, 8, 2, out msg))
                return false;

            //入荷数（未計上）
            if (!string.IsNullOrEmpty(checkCls.ArrivalCnt) && !Check_FloatAndLen("入荷数（未計上）", checkCls.ArrivalCnt, 8, 2, out msg))
                    return false;

            //貸出数（未計上）
            if (!string.IsNullOrEmpty(checkCls.ShipmentCnt) && !Check_FloatAndLen("貸出数（未計上）", checkCls.ShipmentCnt, 8, 2, out msg))
                return false;

            //受注数
            if (!string.IsNullOrEmpty(checkCls.AcpOdrCount) && !Check_FloatAndLen("受注数", checkCls.AcpOdrCount, 8, 2, out msg))
                return false;

            //移動中在庫仕入数
            if (!string.IsNullOrEmpty(checkCls.MovingSupliStock) && !Check_FloatAndLen("移動中在庫仕入数", checkCls.MovingSupliStock, 8, 2, out msg))
                return false;

            //現在庫数
            if (!string.IsNullOrEmpty(checkCls.ShipmentPosCnt) && !Check_FloatAndLen("現在庫数", checkCls.ShipmentPosCnt, 8, 2, out msg))
                return false;

            //発注残
            if (!string.IsNullOrEmpty(checkCls.SalesOrderCount) && !Check_FloatAndLen("発注残", checkCls.SalesOrderCount, 8, 2, out msg))
                return false;

            //在庫区分
            if (!string.IsNullOrEmpty(checkCls.StockDiv) && !Check_IntAndLen("在庫区分", checkCls.StockDiv, 1, out msg))
                return false;

            // ------ ADD START 2012/07/12 Redmine#30393 李亜博 for 障害一覧の指摘NO.93の対応-------->>>>
            //在庫区分
            if (!string.IsNullOrEmpty(checkCls.StockDiv) && Convert.ToInt32(checkCls.StockDiv.Trim()) != 0 && Convert.ToInt32(checkCls.StockDiv.Trim()) != 1)
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, "在庫区分");
                return false;
            }
            // ------ ADD END 2012/07/12 Redmine#30393 李亜博 for 障害一覧の指摘NO.93の対応--------<<<<

            //最低在庫数
            if (!string.IsNullOrEmpty(checkCls.MinimumStockCnt) && !Check_FloatAndLen("最低在庫数", checkCls.MinimumStockCnt, 8, 2, out msg))
                    return false;

            //最高在庫数
            if (!string.IsNullOrEmpty(checkCls.MaximumStockCnt) && !Check_FloatAndLen("最高在庫数", checkCls.MaximumStockCnt, 8, 2, out msg))
                return false;

            //発注ロット
            if (!string.IsNullOrEmpty(checkCls.SalesOrderUnit) && !Check_IntAndLen("発注ロット", checkCls.SalesOrderUnit, 6, out msg))
                return false;

            //発注先
            if (!string.IsNullOrEmpty(checkCls.StockSupplierCode) && !Check_IntAndLen("発注先", checkCls.StockSupplierCode, 6, out msg))
                return false;

            //棚番
            if (!Check_StrUnFixedLen("棚番", checkCls.WarehouseShelfNo, 8, out msg))
                return false;

            //重複棚番１
            if (!Check_StrUnFixedLen("重複棚番１", checkCls.DuplicationShelfNo1, 8, out msg))
                return false;

            //重複棚番２
            if (!Check_StrUnFixedLen("重複棚番２", checkCls.DuplicationShelfNo2, 8, out msg))
                return false;

            //管理区分１
            if (!string.IsNullOrEmpty(checkCls.PartsManagementDivide1) && !Check_IntAndLen("管理区分１", checkCls.PartsManagementDivide1, 1, out msg))
                return false;

            //管理区分２
            if (!string.IsNullOrEmpty(checkCls.PartsManagementDivide2) && !Check_IntAndLen("管理区分２", checkCls.PartsManagementDivide2, 1, out msg))
                return false;

            //在庫備考１
            if (!Check_StrUnFixedLen("在庫備考１", checkCls.StockNote1, 40, out msg))
                return false;
            //在庫備考２
            if (!Check_StrUnFixedLen("在庫備考２", checkCls.StockNote2, 20, out msg))
                return false;

            return true;
        }

        # region メッセージ
        //桁数チェック
        //private const string FORMAT_ERRMSG_LEN = "{0}が{1}桁以内で入力してください。";// DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.30の対応
        private const string FORMAT_ERRMSG_LEN = "{0}は{1}桁以内で入力してください。";// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.30の対応
        //タイプチェック
        //private const string FORMAT_ERRMSG_TYPE = "{0}が{1}のみ可能です。";//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
        private const string FORMAT_ERRMSG_TYPE = "{0}は{1}のみ可能です。";//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
        //必須入力チェック
        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}を入力してください。";
        //編集方法チェック
        private const string FORMAT_ERRMSG_ERRORVAL = "{0}が不正です。";

        //------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387--------->>>>
        //重複データチェック
        //private const string ERRMSG_DUPLICATE = "重複データしているため登録できません。";//DEL ZHANGY3 2012/07/25 FOR REDMINE#30387
        private const string ERRMSG_DUPLICATE = "重複データがあるため登録できません。";//ADD ZHANGY3 2012/07/25 FOR REDMINE#30387
        //------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387---------<<<<
        # endregion

        # region 処理

        /// <summary>
        /// 浮動値、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="valLen">項目長さ</param>
        /// <param name="dotLen">点箇所</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 浮動値、長さをチェックする。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_FloatAndLen(string fieldNm, string val, int valLen, int dotLen,out string msg)
        {
            msg = string.Empty;
            //タイプのチェック
            if (Regex.IsMatch(val, @"^[-+]?\d+(\.\d+)?$"))
            {
                //長さのチェック
                if(Check_StrUnFixedLen(fieldNm,val,valLen+1,out msg))
                {
                    string regexStrLen = @"^((-([0-9]){1," + (valLen - dotLen - 1).ToString() + "}([.][0-9]{0," + dotLen.ToString() + "})?)|(([0-9]){1," + (valLen - dotLen ).ToString() + "}([.][0-9]{0," + dotLen.ToString() + "})?))$";
                    //値のチェック
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数字");
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
        /// <remarks>
        /// <br>Note       : 整数、長さをチェックする。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        private bool Check_IntDataAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            //タイプのチェック
            if (Regex.IsMatch(val, @"^\d+(\.\d+)?$"))
            {
                //長さのチェック
                if (Check_StrUnFixedLen(fieldNm, val, numLen, out msg))
                {
                    string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                    //値のチェック
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数字");// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数");// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
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
        /// <remarks>
        /// <br>Note       : 整数、長さをチェックする。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
        /// </remarks>
        private bool Check_IntAndLen(string fieldNm, string val, int numLen,out string msg)
        {
            msg = string.Empty;
            //タイプのチェック
            if (Regex.IsMatch(val, @"^\d+(\.\d+)?$"))
            {
                //長さのチェック
                if (Check_StrUnFixedLen(fieldNm, val, numLen, out msg))
                {
                    string regexStrLen = @"^([0-9]{1," + (numLen).ToString() + "})$";
                    //値のチェック
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数字");// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "正数");// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.94の対応//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                return false;
            }
        }

        /// <summary>
        /// NULLの判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : NULLの判断。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            //NULLのチェック
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        private bool Check_Zero(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string compCharacter = "0";
            //NULLのチェック
            char[] charArr = val.ToCharArray();
            bool flg = false;
            foreach(char _char in charArr)
            {
                if(!compCharacter.Equals(_char.ToString()))
                {
                    flg = true;
                }
            }
            if (!flg)
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 長さを指定するの文字列チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 長さを指定するの文字列チェック。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_StrFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //長さのチェック
            if (val.Trim().Length != len)
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm,len);
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
        /// <remarks>
        /// <br>Note       : 長さを指定しないの文字列チェック。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //長さチェック
            if (val.Length > len)
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm,len);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 半角英数字、符号のチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 半角英数字、符号のチェック。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, int len,out string msg)
        {
            msg = string.Empty;
            string regexStr = @"^[a-zA-Z0-9 \-_.+=#$*&@%\\[~!_():;'?,/""<>\[\]^`{|}]{1," + len.ToString() + "}$";
            // 半角英数字、符号のチェック
            if (!Regex.IsMatch(val, regexStr))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "半角英数字、符号");
                return false;
            }
            return true;
        }

        # endregion

        # endregion



    }


    
  
}