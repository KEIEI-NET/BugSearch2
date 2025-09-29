//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先マスタ(総括設定)アクセスクラス
// プログラム概要   : 仕入先マスタ(総括設定)で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 作 成 日  2012/08/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
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
    /// 仕入先マスタ(総括設定)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ(総括設定)のアクセス制御を行います。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/08/29</br>
    /// </remarks>
    public class SumSuppStAcs
    {
        #region ■ Private Members

        private ISumSuppStDB _iSumSuppStDB = null;

        #endregion ■ Private Members

        # region ■ Constructor

        /// <summary>
        /// 仕入先マスタ(総括設定)アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)アクセスクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public SumSuppStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iSumSuppStDB = (ISumSuppStDB)MediationSumSuppStDB.GetSumSuppStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSumSuppStDB = null;
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
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iSumSuppStDB == null) || (this._iSumSuppStDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 仕入先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を取得します。</br>
        /// <br>             全件取得を想定</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Search(out ArrayList sumSuppStList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumSuppStList, enterpriseCode, 0, string.Empty, logicalMode);

            return (status);
        }

        /// <summary>
        /// 仕入先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumSuppCode">総括仕入先コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Search(out ArrayList sumSuppStList, string enterpriseCode, int sumSuppCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumSuppStList, enterpriseCode, sumSuppCode, string.Empty, logicalMode);

            return (status);
        }

        /// <summary>
        /// 仕入先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumSuppCode">総括仕入先コード</param>
        /// <param name="sumSecCd">総括拠点コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を取得します。</br>
        /// <br>             詳細全件取得を想定</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Search(out ArrayList sumSuppStList, string enterpriseCode, int sumSuppCode, string sumSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumSuppStList, enterpriseCode, sumSuppCode, sumSecCd, logicalMode);

            return (status);
        }

        /// <summary>
        /// 仕入先マスタ(総括設定)更新処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を更新します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Write(ref ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                status = this._iSumSuppStDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumSuppStList = new ArrayList();
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// 仕入先マスタ(総括設定)論理削除処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を論理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                // 論理削除処理
                status = this._iSumSuppStDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumSuppStList = new ArrayList();
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// 仕入先マスタ(総括設定)削除処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Delete(ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                // 物理削除処理
                status = this._iSumSuppStDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 仕入先マスタ(総括設定)復活処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を復活します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Revival(ref ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                // 復活処理
                status = this._iSumSuppStDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumSuppStList = new ArrayList();
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// 仕入先マスタ(総括設定)取得処理
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ(総括設定)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumSuppCode">総括仕入先コード</param>
        /// <param name="sumSecCd">総括拠点コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ(総括設定)を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        private int SearchProc(out ArrayList sumSuppStList, string enterpriseCode, int sumSuppCode, string sumSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sumSuppStList = new ArrayList();

            try
            {
                // 検索条件設定
                SumSuppStWork paraWork  = new SumSuppStWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SumSupplierCd  = sumSuppCode;
                paraWork.SumSectionCd   = sumSecCd;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                object retObj = retList;

                // 全検索時はlogicalMode->0
                status = this._iSumSuppStDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// <param name="sumSuppSt">仕入先マスタ(総括設定)クラス</param>
        /// <returns>仕入先マスタ(総括設定)ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        private SumSuppStWork CopyToSumSuppStWorkFromSumSuppSt(SumSuppSt sumSuppSt)
        {
            SumSuppStWork sumSuppStWork = new SumSuppStWork();

            sumSuppStWork.CreateDateTime = sumSuppSt.CreateDateTime;
            sumSuppStWork.UpdateDateTime = sumSuppSt.UpdateDateTime;
            sumSuppStWork.EnterpriseCode = sumSuppSt.EnterpriseCode;
            sumSuppStWork.FileHeaderGuid = sumSuppSt.FileHeaderGuid;
            sumSuppStWork.UpdEmployeeCode = sumSuppSt.UpdEmployeeCode;
            sumSuppStWork.UpdAssemblyId1 = sumSuppSt.UpdAssemblyId1;
            sumSuppStWork.UpdAssemblyId2 = sumSuppSt.UpdAssemblyId2;
            sumSuppStWork.LogicalDeleteCode = sumSuppSt.LogicalDeleteCode;
            sumSuppStWork.SumSectionCd = sumSuppSt.SumSectionCd;
            sumSuppStWork.SumSupplierCd = sumSuppSt.SumSupplierCd;
            sumSuppStWork.SectionCode = sumSuppSt.SectionCode;
            sumSuppStWork.SupplierCode = sumSuppSt.SupplierCode;

            return sumSuppStWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="sumSuppStWork">仕入先マスタ(総括設定)ワーククラス</param>
        /// <returns>仕入先マスタ(総括設定)クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        private SumSuppSt CopyToSumSuppStFromSumSuppStWork(SumSuppStWork sumSuppStWork)
        {
            SumSuppSt sumSuppSt = new SumSuppSt();

            sumSuppSt.CreateDateTime = sumSuppStWork.CreateDateTime;
            sumSuppSt.UpdateDateTime = sumSuppStWork.UpdateDateTime;
            sumSuppSt.EnterpriseCode = sumSuppStWork.EnterpriseCode;
            sumSuppSt.FileHeaderGuid = sumSuppStWork.FileHeaderGuid;
            sumSuppSt.UpdEmployeeCode = sumSuppStWork.UpdEmployeeCode;
            sumSuppSt.UpdAssemblyId1 = sumSuppStWork.UpdAssemblyId1;
            sumSuppSt.UpdAssemblyId2 = sumSuppStWork.UpdAssemblyId2;
            sumSuppSt.LogicalDeleteCode = sumSuppStWork.LogicalDeleteCode;
            sumSuppSt.SumSectionCd = sumSuppStWork.SumSectionCd;
            sumSuppSt.SumSupplierCd = sumSuppStWork.SumSupplierCd;
            sumSuppSt.SectionCode = sumSuppStWork.SectionCode;
            sumSuppSt.SupplierCode = sumSuppStWork.SupplierCode;

            return sumSuppSt;
        }

        #endregion ■ Private Methods
    }
}
