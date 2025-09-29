//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換アクセスクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換アクセスクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertAcs
    {
        #region -- Member --

        /// <summary>倉庫マスタコード変換リモートオブジェクト</summary>
        private IWarehouseConvertDB iWarehouseConvertDb;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　倉庫マスタコード変換アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、倉庫マスタコード変換アクセスクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public WarehouseConvertAcs()
        {
            // WarehouseConvertDBの初期化を行います
            this.iWarehouseConvertDb = (IWarehouseConvertDB)MediationWarehouseConvertDB.GetWarehouseConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// 倉庫マスタ検索処理
        /// </summary>
        /// <param name="prmWk">検索条件</param>
        /// <param name="warehouseConvertList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した抽出条件から倉庫マスタの情報を取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int SearchWarehouse(WarehouseConvertDispInfo dispInfo, List<WarehouseDispInfo> warehouseConvertList)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // リモートオブジェクトを実行するのに必要なパラメータを初期化します。
            object paramObj = this.DispInfoToSearchPrmWork(dispInfo);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // リモートオブジェクトを実行し、DBからデータを検索します。
            status = this.iWarehouseConvertDb.Search(paramObj, ref retObj);
            if (status == 0)
            {
                // データを取得できた場合はwarehouseConvertListに格納します。
                retList = retObj as ArrayList;
                foreach (WarehouseSearchWork work in retList)
                {
                    warehouseConvertList.Add(new WarehouseDispInfo(work.WarehouseCd, work.WarehouseNm, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// 倉庫コード変換処理
        /// </summary>
        /// <param name="trgTblList">変換対象テーブル情報</param>
        /// <param name="cnvDataList">>変換条件</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="errMes">エラーメッセージ</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に倉庫コードのコード変換を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int ConvertWarehouse(TargetTableListResult trgTblList,　IList<WarehouseConvertData> cnvDataList,
                string enterpriseCode, ref long numberOfTransactions)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // リモートオブジェクトを実行するのに必要なパラメータを初期化します。
            object paramObj = this.DispInfoToConvertPrmWork(trgTblList, cnvDataList, enterpriseCode);

            // リモートオブジェクトを実行し、コードの変換を実行します。
            status = this.iWarehouseConvertDb.Convert(paramObj, ref numberOfTransactions);

            return status;
        }

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableMap">コード変換対象テーブルのリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に倉庫コードのコード変換を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, WarehouseTargetTableList> retObjMap = new Dictionary<string, WarehouseTargetTableList>();
            Object retObj = retObjMap;

            // リモートオブジェクトを実施し、コード変換対象のテーブルのリスト(key:テーブル名,value:カラムのリスト)を取得します。
            status = this.iWarehouseConvertDb.GetConvertTableList(ref retObj);

            // ステータスが成功の場合は、XMLから取得した内容を変数に入れ替える
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, WarehouseTargetTableList>;
                foreach (string key in retObjMap.Keys)
                {
                    targetTableMap[key] = this.TargetTableListToTargetTableListResult(retObjMap[key]);
                }
            }

            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- 検索関連 --

        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="cvnData">変換前データ</param>
        /// <returns>変換後データ</returns>
        /// <remarks>
        /// <br>Note       : WarehouseConvertDispInfoからWarehouseSearchParamWorkにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private WarehouseSearchParamWork DispInfoToSearchPrmWork(WarehouseConvertDispInfo dispInfo)
        {
            WarehouseSearchParamWork prmWk = new WarehouseSearchParamWork();
            // 企業コード
            prmWk.EnterPriseCode = dispInfo.EnterpriseCode;
            // 倉庫コード(開始)
            prmWk.WarehouseStCd = dispInfo.WarehouseCdStart;
            // 倉庫コード(終了)
            prmWk.WarehouseEdCd = dispInfo.WarehouseCdEnd;

            return prmWk;
        }

        #endregion

        #region -- 変換関連 --

        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="trgTblList">変換テーブル情報</param>
        /// <param name="cnvDataList">変換データのリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>変換後データ</returns>
        /// <remarks>
        /// <br>Note       : WarehouseConvertDispInfoからWarehouseConvertPrmInfoListにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private WarehouseConvertPrmInfoList DispInfoToConvertPrmWork(TargetTableListResult trgTblList,
            IList<WarehouseConvertData> cnvDataList, string enterpriseCode)
        {
            WarehouseConvertPrmInfoList prmInfoList = new WarehouseConvertPrmInfoList();
            // 企業コード
            prmInfoList.EnterpriseCode = enterpriseCode;
            // コード変換対象テーブル(物理名)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // コード変換対象のカラムのリスト
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // コード変換データのリスト
            prmInfoList.WarehouseConvertPrmWorkList = new List<WarehouseConvertPrmWork>(cnvDataList.Count);
            foreach (WarehouseConvertData cnvData in cnvDataList)
            {
                WarehouseConvertPrmWork prmWk = new WarehouseConvertPrmWork(); 
                // 変換前倉庫コード
                prmWk.BfWarehouseCode = cnvData.BfWarehouseCd;
                // 変換後倉庫コード
                prmWk.AfWarehouseCode = cnvData.AfWarehouseCd;
                prmInfoList.WarehouseConvertPrmWorkList.Add(prmWk);
            }

            return prmInfoList;
        }

        #endregion

        #region -- テーブル情報取得関連 --

        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="trgTblList">テーブル情報</param>
        /// <returns>テーブル情報</returns>
        /// <remarks>
        /// <br>Note       : WarehouseTargetTableListからTargetTableListResultにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(WarehouseTargetTableList trgTblList)
        {
            TargetTableListResult trgTblLstRslt = new TargetTableListResult();
            // テーブル名(物理名)
            trgTblLstRslt.TargetTable = trgTblList.TargetTable;
            // テーブル名(論理名)
            trgTblLstRslt.TargetTableName = trgTblList.TargetTableName;
            // カラム名(物理名)のリスト
            trgTblLstRslt.ColumnList = new List<string>(trgTblList.ColumnList);

            return trgTblLstRslt;
        }

        #endregion

        #endregion
    }
}
