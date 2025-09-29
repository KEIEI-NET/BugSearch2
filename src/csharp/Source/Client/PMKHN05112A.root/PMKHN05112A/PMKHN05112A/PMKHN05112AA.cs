//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換アクセスクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
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
    /// PM.NS統合ツール　担当者マスタコード変換アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換アクセスクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeConvertAcs
    {
        #region -- Member --

        /// <summary>担当者マスタコード変換リモートオブジェクト</summary>
        private IEmployeeConvertDB iEmployeeConvertDb = null;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　担当者マスタコード変換アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、担当者マスタコード変換アクセスクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public EmployeeConvertAcs()
        {
            // EmployeeConvertDBの初期化を行います。
            this.iEmployeeConvertDb = (IEmployeeConvertDB)MediationEmployeeConvertDB.GetEmployeeConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// 担当者マスタ検索処理
        /// </summary>
        /// <param name="dispWork">検索条件</param>
        /// <param name="employeeConvertList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した抽出条件から担当者マスタの情報を取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int SearchEmployee(EmployeeSearchDispWork dispWork, List<EmployeeDispInfo> employeeConvertList)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // リモートオブジェクトを実行するのに必要なパラメータを初期化します。
            object prmObj = this.DispInfoToSearchParamWork(dispWork);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // リモートオブジェクトを実行し、DBからデータを検索します。
            status = this.iEmployeeConvertDb.Search(prmObj, ref retObj);
            if (status == 0)
            {
                // データが取得できた場合は、employeeConvertListに格納します。
                retList = retObj as ArrayList;
                foreach (EmployeeSearchWork work in retList)
                {
                    employeeConvertList.Add(new EmployeeDispInfo(work.EmployeeCode, 
                        work.EmployeeName, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// 担当者コード変換処理
        /// </summary>
        /// <param name="trgTblList">変換対象テーブル情報</param>
        /// <param name="cnvDataList">>変換条件</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="numberOfTransactions">処理件数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に担当者コードのコード変換を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int ConvertEmployee(TargetTableListResult trgTblList, IList<EmployeeConvertData> cnvDataList,
            string enterpriseCode, ref int numberOfTransactions)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // リモートオブジェクトを実行するのに必要なパラメータの初期化を行います。
            object paramObj = this.DispInfoToConvertParamWork(trgTblList, cnvDataList, enterpriseCode);

            // リモートオブジェクトを実行し、コードの変換を実行します。
            status = this.iEmployeeConvertDb.Convert(paramObj, ref numberOfTransactions);

            return status;
        }

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableMap">コード変換対象テーブルのリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に担当者コードのコード変換を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, EmployeeTargetTableList> retObjMap = new Dictionary<string, EmployeeTargetTableList>();
            Object retObj = retObjMap;

            // リモートオブジェクトを実施し、コード変換対象のテーブルリスト(key:テーブル名,value：カラムのリスト)を取得します。
            status = this.iEmployeeConvertDb.GetConvertTableList(ref retObj);

            // ステータスが成功の場合は、XMLから取得した内容を変数に入れ替える
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, EmployeeTargetTableList>;
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
        /// <param name="dispInfo">変換前データ</param>
        /// <returns>変換後データ</returns>
        /// <remarks>
        /// <br>Note       : EmployeeSearchDispWorkからEmployeeSearchParamWorkにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private EmployeeSearchParamWork DispInfoToSearchParamWork(EmployeeSearchDispWork dispInfo)
        {
            EmployeeSearchParamWork prmWk = new EmployeeSearchParamWork();
            // 企業コード
            prmWk.EnterpriseCode = dispInfo.EnterpriseCode;
            // 担当者コード(開始)
            prmWk.EmployeeCodeStart = dispInfo.EmployeeCodeStart;
            // 担当者コード(終了)
            prmWk.EmployeeCodeEnd = dispInfo.EmployeeCodeEnd;

            return prmWk;
        }

        #endregion

        #region -- コード変換関連 --

        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="trgTblList">変換テーブル情報</param>
        /// <param name="cnvDataList">変換データのリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>変換後データ</returns>
        /// <remarks>
        /// <br>Note       : EmployeeConvertDataからEmployeeConvertParamInfoListにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private EmployeeConvertParamInfoList DispInfoToConvertParamWork(TargetTableListResult trgTblList, 
            IList<EmployeeConvertData> cnvDataList, string enterpriseCode)
        {
            EmployeeConvertParamInfoList prmInfoList = new EmployeeConvertParamInfoList();
            // 企業コード
            prmInfoList.EnterpriseCode = enterpriseCode;
            // コード変換対象テーブル(物理名)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // コード変換対象カラム名(物理名)のリスト
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // コード変換対象データのリスト
            prmInfoList.EmployeeConvertParamWorkList = new List<EmployeeConvertParamWork>(cnvDataList.Count);
            foreach (EmployeeConvertData cnvData in cnvDataList)
            {
                EmployeeConvertParamWork prmWk = new EmployeeConvertParamWork();
                // 変更前担当者コード
                prmWk.BfEmployeeCode = cnvData.BfEmployeeCd;
                // 変更後担当者コード
                prmWk.AfEmployeeCode = cnvData.AfEmployeeCd;
                prmInfoList.EmployeeConvertParamWorkList.Add(prmWk);
            }

            return prmInfoList;
        }

        #endregion

        #region -- テーブル情報取得処理関連 --

        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="trgTblList">テーブル情報</param>
        /// <returns>テーブル情報</returns>
        /// <remarks>
        /// <br>Note       : TargetTableListからTargetTableListResultにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(EmployeeTargetTableList trgTblList)
        {
            TargetTableListResult trgTblLstRslt = new TargetTableListResult();
            // 対象テーブル名(物理名)
            trgTblLstRslt.TargetTable = trgTblList.TargetTable;
            // 対象テーブル名(論理名)
            trgTblLstRslt.TargetTableName = trgTblList.TargetTableName;
            // 対象カラム名(物理名)のリスト
            trgTblLstRslt.ColumnList = trgTblList.ColumnList;

            return trgTblLstRslt;
        }

        #endregion

        #endregion
    }
}
