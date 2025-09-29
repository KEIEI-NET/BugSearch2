//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換アクセスクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
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
    /// PM.NS統合ツール　得意先マスタコード変換アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換アクセスクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerConvertAcs
    {
        #region -- Member --

        /// <summary>得意先マスタコード変換リモートオブジェクト</summary>
        private ICustomerConvertDB iCustomerConvertDb = null;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　得意先マスタコード変換アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、得意先マスタコード変換アクセスクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public CustomerConvertAcs()
        {
            // CustomerConvertDBの初期化を行います。
            this.iCustomerConvertDb = (ICustomerConvertDB)MediationCustomerConvertDB.GetCustomerConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// 担当者マスタ検索処理
        /// </summary>
        /// <param name="dispWork">検索条件</param>
        /// <param name="customerConvertList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した抽出条件から担当者マスタの情報を取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int SearchCustomer(CustomerSearchDispWork dispWork, List<CustomerDispInfo> customerConvertList)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // リモートオブジェクトを実行する為に必要なパラメータを初期化します。
            object prmObj = this.DispInfoToSearchParamWork(dispWork);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // リモートオブジェクトを実行し、DBからデータを検索します。
            status = this.iCustomerConvertDb.Search(prmObj, ref retObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データが取得できた場合は、customerConvertListに格納します。
                retList = retObj as ArrayList;
                foreach (CustomerSearchWork work in retList)
                {
                    customerConvertList.Add(new CustomerDispInfo(work.CustomerCode, 
                        work.CustomerName, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先コード変換処理
        /// </summary>
        /// <param name="trgTblList">変換対象テーブル情報</param>
        /// <param name="cnvDataList">>変換条件</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="numberOfTransactions">処理件数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に得意先コードのコード変換を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int ConvertCustomer(TargetTableListResult trgTblList, IList<CustomerConvertData> cnvDataList,
            string enterpriseCode, ref int numberOfTransactions)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // リモートオブジェクトを実行するのに必要なパラメータを初期化します。
            object paramObj = this.DispInfoToConvertParamWork(trgTblList, cnvDataList, enterpriseCode);

            // リモートオブジェクトを実行し、コードの変換を実行します。
            status = this.iCustomerConvertDb.Convert(paramObj, ref numberOfTransactions);
            return status;
        }

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableMap">コード変換対象テーブルのリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に得意先コードのコード変換を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, CustomerTargetTableList> retObjMap = new Dictionary<string, CustomerTargetTableList>();
            Object retObj = retObjMap;

            // リモートオブジェクトを実施し、コード変換対象のテーブルリスト(key:テーブル名,value:カラムのリスト)を取得します。
            status = this.iCustomerConvertDb.GetConvertTableList(ref retObj);

            // ステータスが成功の場合は、XMLから取得した内容を変数に入れ替える
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, CustomerTargetTableList>;
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
        /// <br>Note       : CustomerSearchDispWorkからCustomerSearchParamWorkにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerSearchParamWork DispInfoToSearchParamWork(CustomerSearchDispWork dispInfo)
        {
            CustomerSearchParamWork prmWk = new CustomerSearchParamWork();
            // 企業コード
            prmWk.EnterpriseCode = dispInfo.EnterpriseCode;
            // 得意先コード(開始)
            prmWk.CustomerCodeStart = dispInfo.CustomerCodeStart;
            // 得意先コード(終了)
            prmWk.CustomerCodeEnd = dispInfo.CustomerCodeEnd;

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
        /// <br>Note       : CustomerConvertDataからCustomerConvertParamInfoListにデータを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerConvertParamInfoList DispInfoToConvertParamWork(TargetTableListResult trgTblList,
            IList<CustomerConvertData> cnvDataList, string enterpriseCode)
        {
            CustomerConvertParamInfoList prmInfoList = new CustomerConvertParamInfoList();
            // 企業コード
            prmInfoList.EnterpriseCode = enterpriseCode;
            // コード変換対象テーブル(物理名)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // コード変換対象カラム名(物理名)のリスト
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // コード変換対象データのリスト
            prmInfoList.CustomerConvertParamWorkList = new List<CustomerConvertParamWork>(cnvDataList.Count);
            foreach (CustomerConvertData cnvData in cnvDataList)
            {
                CustomerConvertParamWork prmWk = new CustomerConvertParamWork();
                // 変更前得意先コード
                prmWk.BfCustomerCode = cnvData.BfCustomerCd;
                // 変更後得意先コード
                prmWk.AfCustomerCode = cnvData.AfCustomerCd;
                prmInfoList.CustomerConvertParamWorkList.Add(prmWk);
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
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(CustomerTargetTableList trgTblList)
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
