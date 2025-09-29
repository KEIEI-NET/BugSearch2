//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   簡単問合せ接続情報DBリモートオブジェクト
//                  :   PMSCM00205R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024　佐々木 健
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 簡単問合せ接続情報リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 簡単問合せ接続情報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SimplInqCnectInfoDB : RemoteDB,ISimplInqCnectInfoDB
    {
        /// <summary>
        /// 簡単問合せ接続情報DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public SimplInqCnectInfoDB() 
        {

        }

        # region [Delete]
        /// <summary>
        /// 簡単問合せ接続情報を削除します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">削除する簡単問合せ接続情報情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 簡単問合せ接続情報のキー値が一致する簡単問合せ接続情報を削除します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        public int Delete(string enterpriseCode, object simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // パラメータのキャスト
            ArrayList paraList = simplInqCnectInfoList as ArrayList;

            status = this.DeleteProc(enterpriseCode, paraList);

            return status;
        }

        /// <summary>
        /// 簡単問合せ接続情報を削除します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">簡単問合せ接続情報情報を格納する ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList に格納されている簡単問合せ接続情報情報を物理削除します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        private int DeleteProc(string enterpriseCode, ArrayList simplInqCnectInfoList)
        {
            List<SimplInqCnectInfo> delList = new List<SimplInqCnectInfo>();

            foreach (SimplInqCnectInfoWork work in simplInqCnectInfoList)
            {
                delList.Add(CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(work));
            }

            return SimplInqCnectInfoController.DeleteConnectionInfo(enterpriseCode, delList);
        }

        # endregion

        # region [Search]
        /// <summary>
        /// 簡単問合せ接続情報情報のリストを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">検索結果</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 対象企業の簡単問合せ接続情を全て取得します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        public int Search(string enterpriseCode, out object simplInqCnectInfoList)
        {
            ArrayList retList;
            int status = SearchProc(enterpriseCode, out retList);

            simplInqCnectInfoList = (object)retList;

            return status;
        }

        /// <summary>
        /// 簡単問合せ接続情報情報のリストを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">簡単問合せ接続情報情報を格納する ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 対象企業の簡単問合せ接続情報を全て ArrayList で取得します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        private int SearchProc(string enterpriseCode, out ArrayList simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            simplInqCnectInfoList = new ArrayList();
            List<SimplInqCnectInfo> infoList = SimplInqCnectInfoController.GetConnectionInfolist(enterpriseCode);

            if (infoList != null && infoList.Count > 0)
            {
                foreach (SimplInqCnectInfo info in infoList)
                {
                    simplInqCnectInfoList.Add(CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(info));
                }
            }

            if (simplInqCnectInfoList.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// 簡単問合せ接続情報情報を追加・更新します。
        /// </summary>
        /// <param name="simplInqCnectInfoList">追加・更新する簡単問合せ接続情報情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList に格納されている簡単問合せ接続情報情報を追加・更新します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        public int Write(string enterpriseCode, object simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList paraList = null;
            if (simplInqCnectInfoList is SimplInqCnectInfoWork)
            {
                paraList = new ArrayList();
                paraList.Add((SimplInqCnectInfoWork)simplInqCnectInfoList);
            }
            else if (simplInqCnectInfoList is ArrayList)
            {
                paraList = simplInqCnectInfoList as ArrayList;
            }

            return WriteProc(enterpriseCode, paraList);
        }

        /// <summary>
        /// 簡単問合せ接続情報情報を追加・更新します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">追加する簡単問合せ接続情報情報を格納する ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList に格納されている簡単問合せ接続情報情報を追加・更新します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        private int WriteProc(string enterpriseCode,ArrayList simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (simplInqCnectInfoList == null || simplInqCnectInfoList.Count == 0) return status;

            List<SimplInqCnectInfo> addList = new List<SimplInqCnectInfo>();

            foreach (SimplInqCnectInfoWork work in simplInqCnectInfoList)
            {
                addList.Add(CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(work));
            }

            if (addList.Count > 0)
            {
                status = SimplInqCnectInfoController.AddConnectionInfo(enterpriseCode, addList);
            }

            return status;
        }
        # endregion

        # region [クラス格納処理]

        /// <summary>
        /// クラス格納処理（SimplInqCnectInfo→SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="simplInqCnectInfo">CmtCnectInfoオブジェクト</param>
        /// <returns>CMTCnectInfoWorkオブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private SimplInqCnectInfoWork CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(SimplInqCnectInfo simplInqCnectInfo)
        {
            SimplInqCnectInfoWork work = new SimplInqCnectInfoWork();

            work.CashRegisterNo = simplInqCnectInfo.CashRegisterNo;
            work.CustomerCode = simplInqCnectInfo.CustomerCode;

            return work;
        }

        /// <summary>
        /// クラス格納処理（SimplInqCnectInfo→SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="simplInqCnectInfoWork">CMTCnectInfoWorkオブジェクト</param>
        /// <returns>CmtCnectInfoオブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private SimplInqCnectInfo CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(SimplInqCnectInfoWork simplInqCnectInfoWork)
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();

            info.CashRegisterNo = simplInqCnectInfoWork.CashRegisterNo;
            info.CustomerCode = simplInqCnectInfoWork.CustomerCode;

            return info;
        }

        # endregion
    }
}
