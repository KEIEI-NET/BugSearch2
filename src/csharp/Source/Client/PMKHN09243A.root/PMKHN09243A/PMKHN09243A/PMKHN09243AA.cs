using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先マスタ(総括設定)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 得意先マスタ(総括設定)のアクセス制御を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/10/29</br>
    /// </remarks>
    public class SumCustStAcs
    {
        #region ■ Private Members

        private ISumCustStDB _iSumCustStDB = null;

        #endregion ■ Private Members


        # region ■ Constructor

        /// <summary>
        /// 得意先マスタ(総括設定)アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)アクセスクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public SumCustStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iSumCustStDB = (ISumCustStDB)MediationSumCustStDB.GetSumCustStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSumCustStDB = null;
            }
        }

        # endregion ■ Constructor


        #region ■ Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iSumCustStDB == null) || (this._iSumCustStDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 得意先マスタ(総括設定)読込処理
        /// </summary>
        /// <param name="sumCustSt">得意先マスタ(総括設定)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumClaimCustCode">総括請求得意先コード</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Read(out SumCustSt sumCustSt, string enterpriseCode, int sumClaimCustCode, string demandAddUpSecCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sumCustSt = new SumCustSt();

            try
            {
                // 検索条件設定
                SumCustStWork paraWork = new SumCustStWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SumClaimCustCode = sumClaimCustCode;
                paraWork.DemandAddUpSecCd = demandAddUpSecCd;

                object paraObj = paraWork;

                status = this._iSumCustStDB.Read(ref paraObj, 0);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;

                    // クラスメンバコピー処理(D→E)
                    sumCustSt = CopyToSumCustStFromSumCustStWork((SumCustStWork)retList[0]);
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Search(out ArrayList sumCustStList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumCustStList, enterpriseCode, 0, "", logicalMode);

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumClaimCustCode">総括請求得意先コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Search(out ArrayList sumCustStList, string enterpriseCode, int sumClaimCustCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumCustStList, enterpriseCode, sumClaimCustCode, "", logicalMode);

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumClaimCustCode">総括請求得意先コード</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Search(out ArrayList sumCustStList, string enterpriseCode, int sumClaimCustCode, string demandAddUpSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumCustStList, enterpriseCode, sumClaimCustCode, demandAddUpSecCd, logicalMode);

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)更新処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を更新します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Write(ref ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                status = this._iSumCustStDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumCustStList = new ArrayList();
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)論理削除処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を論理削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                // 論理削除処理
                status = this._iSumCustStDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumCustStList = new ArrayList();
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)削除処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Delete(ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                // 物理削除処理
                status = this._iSumCustStDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(総括設定)復活処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を復活します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Revival(ref ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                // 復活処理
                status = this._iSumCustStDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumCustStList = new ArrayList();
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// 得意先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumCustStList">得意先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumClaimCustCode">総括請求得意先コード</param>
        /// <param name="demandAddUpSecCd">請求計上拠点コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private int SearchProc(out ArrayList sumCustStList, string enterpriseCode, int sumClaimCustCode, string demandAddUpSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sumCustStList = new ArrayList();

            try
            {
                // 検索条件設定
                SumCustStWork paraWork = new SumCustStWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SumClaimCustCode = sumClaimCustCode;
                paraWork.DemandAddUpSecCd= demandAddUpSecCd;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                object retObj = retList;

                status = this._iSumCustStDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="sumCustSt">得意先マスタ(総括設定)クラス</param>
        /// <returns>得意先マスタ(総括設定)ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private SumCustStWork CopyToSumCustStWorkFromSumCustSt(SumCustSt sumCustSt)
        {
            SumCustStWork sumCustStWork = new SumCustStWork();

            sumCustStWork.CreateDateTime = sumCustSt.CreateDateTime;
            sumCustStWork.UpdateDateTime = sumCustSt.UpdateDateTime;
            sumCustStWork.EnterpriseCode = sumCustSt.EnterpriseCode;
            sumCustStWork.FileHeaderGuid = sumCustSt.FileHeaderGuid;
            sumCustStWork.UpdEmployeeCode = sumCustSt.UpdEmployeeCode;
            sumCustStWork.UpdAssemblyId1 = sumCustSt.UpdAssemblyId1;
            sumCustStWork.UpdAssemblyId2 = sumCustSt.UpdAssemblyId2;
            sumCustStWork.LogicalDeleteCode = sumCustSt.LogicalDeleteCode;
            sumCustStWork.SumClaimCustCode = sumCustSt.SumClaimCustCode;
            sumCustStWork.DemandAddUpSecCd = sumCustSt.DemandAddUpSecCd;
            sumCustStWork.CustomerCode = sumCustSt.CustomerCode;

            return sumCustStWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="custRateGroupWork">得意先マスタ(総括設定)ワーククラス</param>
        /// <returns>得意先マスタ(総括設定)クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private SumCustSt CopyToSumCustStFromSumCustStWork(SumCustStWork sumCustStWork)
        {
            SumCustSt sumCustSt = new SumCustSt();

            sumCustSt.CreateDateTime = sumCustStWork.CreateDateTime;
            sumCustSt.UpdateDateTime = sumCustStWork.UpdateDateTime;
            sumCustSt.EnterpriseCode = sumCustStWork.EnterpriseCode;
            sumCustSt.FileHeaderGuid = sumCustStWork.FileHeaderGuid;
            sumCustSt.UpdEmployeeCode = sumCustStWork.UpdEmployeeCode;
            sumCustSt.UpdAssemblyId1 = sumCustStWork.UpdAssemblyId1;
            sumCustSt.UpdAssemblyId2 = sumCustStWork.UpdAssemblyId2;
            sumCustSt.LogicalDeleteCode = sumCustStWork.LogicalDeleteCode;
            sumCustSt.SumClaimCustCode = sumCustStWork.SumClaimCustCode;
            sumCustSt.DemandAddUpSecCd = sumCustStWork.DemandAddUpSecCd;
            sumCustSt.CustomerCode = sumCustStWork.CustomerCode;

            return sumCustSt;
        }

        #endregion ■ Private Methods
    }
}
