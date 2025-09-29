using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上目標設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上目標設定アクセスクラス</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/10/08</br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>             障害改良対応１２月</br>
    /// </remarks>
    public class SalesTargetAcs
    {
        #region ■ Private Members

        private IEmpSalesTargetDB _iEmpSalesTargetDB;       // 従業員別売上目標リモート
        private ICustSalesTargetDB _iCustSalesTargetDB;     // 得意先別売上目標リモート
        private IGcdSalesTargetDB _iGcdSalesTargetDB;       // 商品別売上目標リモート

        #endregion ■ Private Members

        
        #region ■ Constructor
        /// <summary>
        /// 売上目標設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上目標設定アクセスクラス</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public SalesTargetAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iEmpSalesTargetDB = (IEmpSalesTargetDB)MediationEmpSalesTargetDB.GetEmpSalesTargetDB();
                this._iCustSalesTargetDB = (ICustSalesTargetDB)MediationCustSalesTargetDB.GetCustSalesTargetDB();
                this._iGcdSalesTargetDB = (IGcdSalesTargetDB)MediationGcdSalesTargetDB.GetGcdSalesTargetDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iEmpSalesTargetDB = null;
                this._iCustSalesTargetDB = null;
                this._iGcdSalesTargetDB = null;
            }
        }
        #endregion ■ Constructor


        #region ■ Public Methods

        #region オンラインモード取得
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iEmpSalesTargetDB == null) || (this._iCustSalesTargetDB == null) || (this._iGcdSalesTargetDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion オンラインモード取得

        #region 検索処理
        /// <summary>
        /// 検索処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetList">従業員別売上目標リスト</param>
        /// <param name="searchEmpSalesTargetPara">従業員別売上目標検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Search(out List<EmpSalesTarget> empSalesTargetList, SearchEmpSalesTargetPara searchEmpSalesTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            empSalesTargetList = new List<EmpSalesTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // クラスメンバコピー処理(E→D)
                SearchEmpSalesTargetParaWork paraWork = CopyToSearchEmpSalesTargetParaWorkFromSearchEmpSalesTargetPara(searchEmpSalesTargetPara);

                object paraObj = paraWork;
                object retObj;

                // 検索処理
                status = this._iEmpSalesTargetDB.Search(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 検索処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標リスト</param>
        /// <param name="searchCustSalesTargetPara">得意先別売上目標検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Search(out List<CustSalesTarget> custSalesTargetList, SearchCustSalesTargetPara searchCustSalesTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            custSalesTargetList = new List<CustSalesTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // クラスメンバコピー処理(E→D)
                SearchCustSalesTargetParaWork paraWork = CopyToSearchCustSalesTargetParaWorkFromSearchCustSalesTargetPara(searchCustSalesTargetPara);

                object paraObj = paraWork;
                object retObj;

                // 検索処理
                status = this._iCustSalesTargetDB.Search(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 検索処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetList">商品別売上目標リスト</param>
        /// <param name="searchGcdSalesTargetPara">商品別売上目標検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Search(out List<GcdSalesTarget> gcdSalesTargetList, SearchGcdSalesTargetPara searchGcdSalesTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            gcdSalesTargetList = new List<GcdSalesTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // クラスメンバコピー処理(E→D)
                SearchGcdSalesTargetParaWork paraWork = CopyToSearchGcdSalesTargetParaWorkFromSearchGcdSalesTargetPara(searchGcdSalesTargetPara);

                object paraObj = paraWork;
                object retObj;

                // 検索処理
                status = this._iGcdSalesTargetDB.Search(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 検索処理

        #region 更新処理
        /// <summary>
        /// 更新処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetList">従業員別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタを更新します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Write(ref List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }

                object paraObj = paraList;

                // 更新処理
                status = this._iEmpSalesTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    empSalesTargetList.Clear();

                    // データ変換
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        // ---ADD 2010/12/20--------->>>>>
        /// <summary>
        /// 更新処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetWriteList">従業員別売上目標リスト(write用)</param>
        /// <param name="empSalesTargetDelList">従業員別売上目標リスト(delete用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタを更新します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        /// </remarks>
        public int WriteProc(ref List<EmpSalesTarget> empSalesTargetWriteList, List<EmpSalesTarget> empSalesTargetDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraWriteList = new ArrayList();
                foreach (EmpSalesTarget empSalesTarget in empSalesTargetWriteList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWriteList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }
                object paraWriteObj = paraWriteList;

                EmpSalesTargetWork[] paraWorkArray = new EmpSalesTargetWork[empSalesTargetDelList.Count];
                for (int index = 0; index < empSalesTargetDelList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTargetDelList[index]);
                }
                // XMLへ変換し、文字列のバイナリ化
                byte[] paraDeleteByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 更新処理
                status = this._iEmpSalesTargetDB.WriteProc(ref paraWriteObj, paraDeleteByte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraWriteObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    empSalesTargetWriteList.Clear();

                    // データ変換
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        empSalesTargetWriteList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 更新処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetWriteList">得意先別売上目標リスト(write用)</param>
        /// <param name="custSalesTargetDelList">得意先別売上目標リスト(delete用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタを更新します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        /// </remarks>
        public int WriteProc(ref List<CustSalesTarget> custSalesTargetWriteList, List<CustSalesTarget> custSalesTargetDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraWriteList = new ArrayList();
                foreach (CustSalesTarget custSalesTarget in custSalesTargetWriteList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWriteList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }
                object paraWriteObj = paraWriteList;

                CustSalesTargetWork[] paraWorkArray = new CustSalesTargetWork[custSalesTargetDelList.Count];
                for (int index = 0; index < custSalesTargetDelList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTargetDelList[index]);
                }
                // XMLへ変換し、文字列のバイナリ化
                byte[] paraDeleteByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 更新処理
                status = this._iCustSalesTargetDB.WriteProc(ref paraWriteObj, paraDeleteByte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraWriteObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    custSalesTargetWriteList.Clear();

                    // データ変換
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custSalesTargetWriteList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 更新処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetWriteList">商品別売上目標リスト(write用)</param>
        /// <param name="gcdSalesTargetDelList">商品別売上目標リスト(delete用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタを更新します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        /// </remarks>
        public int WriteProc(ref List<GcdSalesTarget> gcdSalesTargetWriteList, List<GcdSalesTarget> gcdSalesTargetDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraWriteList = new ArrayList();
                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetWriteList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWriteList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }
                object paraWriteObj = paraWriteList;

                GcdSalesTargetWork[] paraWorkArray = new GcdSalesTargetWork[gcdSalesTargetDelList.Count];
                for (int index = 0; index < gcdSalesTargetDelList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTargetDelList[index]);
                }
                // XMLへ変換し、文字列のバイナリ化
                byte[] paraDeleteByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 更新処理
                status = this._iGcdSalesTargetDB.WriteProc(ref paraWriteObj, paraDeleteByte);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraWriteObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    gcdSalesTargetWriteList.Clear();

                    // データ変換
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        gcdSalesTargetWriteList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        // ---ADD 2010/12/20---------<<<<<

        /// <summary>
        /// 更新処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタを更新します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Write(ref List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }

                object paraObj = paraList;

                // 更新処理
                status = this._iCustSalesTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    custSalesTargetList.Clear();

                    // データ変換
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 更新処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetList">商品別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタを更新します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Write(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }

                object paraObj = paraList;

                // 更新処理
                status = this._iGcdSalesTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    gcdSalesTargetList.Clear();

                    // データ変換
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 更新処理

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetList">従業員別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタを論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete(ref List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iEmpSalesTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    empSalesTargetList.Clear();

                    // データ変換
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 論理削除処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタを論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete(ref List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iCustSalesTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    custSalesTargetList.Clear();

                    // データ変換
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 論理削除処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetList">商品別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタを論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iGcdSalesTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    gcdSalesTargetList.Clear();

                    // データ変換
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 論理削除処理

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetList">従業員別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタを物理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete(List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                EmpSalesTargetWork[] paraWorkArray = new EmpSalesTargetWork[empSalesTargetList.Count];

                for (int index = 0; index < empSalesTargetList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTargetList[index]);
                }

                // XMLへ変換し、文字列のバイナリ化
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 物理削除処理
                status = this._iEmpSalesTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 物理削除処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタを物理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete(List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                CustSalesTargetWork[] paraWorkArray = new CustSalesTargetWork[custSalesTargetList.Count];

                for (int index = 0; index < custSalesTargetList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTargetList[index]);
                }

                // XMLへ変換し、文字列のバイナリ化
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 物理削除処理
                status = this._iCustSalesTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 物理削除処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetList">商品別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタを物理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete(List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                GcdSalesTargetWork[] paraWorkArray = new GcdSalesTargetWork[gcdSalesTargetList.Count];

                for (int index = 0; index < gcdSalesTargetList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTargetList[index]);
                }

                // XMLへ変換し、文字列のバイナリ化
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 物理削除処理
                status = this._iGcdSalesTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 物理削除処理

        #region 復活処理
        /// <summary>
        /// 復活処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetList">従業員別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタを復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival(ref List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iEmpSalesTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    empSalesTargetList.Clear();

                    // データ変換
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 復活処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタを復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival(ref List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iCustSalesTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    custSalesTargetList.Clear();

                    // データ変換
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 復活処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetList">商品別売上目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタを復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iGcdSalesTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    gcdSalesTargetList.Clear();

                    // データ変換
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 復活処理

        #endregion ■ Public Methods


        #region ■ Private Methods

        #region クラスメンバコピー処理(E→D)
        /// <summary>
        /// クラスメンバコピー処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTarget">従業員別売上目標設定マスタ</param>
        /// <returns>従業員別売上目標設定マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private EmpSalesTargetWork CopyToEmpSalesTargetWorkFromEmpSalesTarget(EmpSalesTarget empSalesTarget)
        {
            EmpSalesTargetWork empSalesTargetWork = new EmpSalesTargetWork();

            empSalesTargetWork.CreateDateTime = empSalesTarget.CreateDateTime;          // 作成日時
            empSalesTargetWork.UpdateDateTime = empSalesTarget.UpdateDateTime;          // 更新日時
            empSalesTargetWork.EnterpriseCode = empSalesTarget.EnterpriseCode;          // 企業コード
            empSalesTargetWork.FileHeaderGuid = empSalesTarget.FileHeaderGuid;          // GUID
            empSalesTargetWork.UpdEmployeeCode = empSalesTarget.UpdEmployeeCode;        // 更新従業員コード
            empSalesTargetWork.UpdAssemblyId1 = empSalesTarget.UpdAssemblyId1;          // 更新アセンブリID1
            empSalesTargetWork.UpdAssemblyId2 = empSalesTarget.UpdAssemblyId2;          // 更新アセンブリID2
            empSalesTargetWork.LogicalDeleteCode = empSalesTarget.LogicalDeleteCode;    // 論理削除区分
            empSalesTargetWork.SectionCode = empSalesTarget.SectionCode;                // 拠点コード
            empSalesTargetWork.TargetSetCd = empSalesTarget.TargetSetCd;                // 目標設定区分
            empSalesTargetWork.TargetContrastCd = empSalesTarget.TargetContrastCd;      // 目標対比区分
            empSalesTargetWork.TargetDivideCode = empSalesTarget.TargetDivideCode;      // 目標区分コード
            empSalesTargetWork.TargetDivideName = empSalesTarget.TargetDivideName;      // 目標区分名称
            empSalesTargetWork.EmployeeDivCd = empSalesTarget.EmployeeDivCd;            // 従業員区分
            empSalesTargetWork.SubSectionCode = empSalesTarget.SubSectionCode;          // 部門コード
            empSalesTargetWork.EmployeeCode = empSalesTarget.EmployeeCode;              // 従業員コード
            empSalesTargetWork.ApplyStaDate = empSalesTarget.ApplyStaDate;              // 適用開始日
            empSalesTargetWork.ApplyEndDate = empSalesTarget.ApplyEndDate;              // 適用終了日
            empSalesTargetWork.SalesTargetMoney = empSalesTarget.SalesTargetMoney;      // 売上目標金額
            empSalesTargetWork.SalesTargetProfit = empSalesTarget.SalesTargetProfit;    // 売上目標粗利額
            empSalesTargetWork.SalesTargetCount = empSalesTarget.SalesTargetCount;      // 売上目標数量

            return empSalesTargetWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTarget">得意先別売上目標設定マスタ</param>
        /// <returns>得意先別売上目標設定マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private CustSalesTargetWork CopyToCustSalesTargetWorkFromCustSalesTarget(CustSalesTarget custSalesTarget)
        {
            CustSalesTargetWork custSalesTargetWork = new CustSalesTargetWork();

            custSalesTargetWork.CreateDateTime = custSalesTarget.CreateDateTime;            // 作成日時
            custSalesTargetWork.UpdateDateTime = custSalesTarget.UpdateDateTime;            // 更新日時
            custSalesTargetWork.EnterpriseCode = custSalesTarget.EnterpriseCode;            // 企業コード
            custSalesTargetWork.FileHeaderGuid = custSalesTarget.FileHeaderGuid;            // GUID
            custSalesTargetWork.UpdEmployeeCode = custSalesTarget.UpdEmployeeCode;          // 更新従業員コード
            custSalesTargetWork.UpdAssemblyId1 = custSalesTarget.UpdAssemblyId1;            // 更新アセンブリID1
            custSalesTargetWork.UpdAssemblyId2 = custSalesTarget.UpdAssemblyId2;            // 更新アセンブリID2
            custSalesTargetWork.LogicalDeleteCode = custSalesTarget.LogicalDeleteCode;      // 論理削除区分
            custSalesTargetWork.SectionCode = custSalesTarget.SectionCode;                  // 拠点コード
            custSalesTargetWork.TargetSetCd = custSalesTarget.TargetSetCd;                  // 目標設定区分
            custSalesTargetWork.TargetContrastCd = custSalesTarget.TargetContrastCd;        // 目標対比区分
            custSalesTargetWork.TargetDivideCode = custSalesTarget.TargetDivideCode;        // 目標区分コード
            custSalesTargetWork.TargetDivideName = custSalesTarget.TargetDivideName;        // 目標区分名称
            custSalesTargetWork.BusinessTypeCode = custSalesTarget.BusinessTypeCode;        // 業種コード
            custSalesTargetWork.SalesAreaCode = custSalesTarget.SalesAreaCode;              // 販売エリアコード
            custSalesTargetWork.CustomerCode = custSalesTarget.CustomerCode;                // 得意先コード
            custSalesTargetWork.ApplyStaDate = custSalesTarget.ApplyStaDate;                // 適用開始日
            custSalesTargetWork.ApplyEndDate = custSalesTarget.ApplyEndDate;                // 適用終了日
            custSalesTargetWork.SalesTargetMoney = custSalesTarget.SalesTargetMoney;        // 売上目標金額
            custSalesTargetWork.SalesTargetProfit = custSalesTarget.SalesTargetProfit;      // 売上目標粗利額
            custSalesTargetWork.SalesTargetCount = custSalesTarget.SalesTargetCount;        // 売上目標数量

            return custSalesTargetWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTarget">商品別売上目標設定マスタ</param>
        /// <returns>商品別売上目標設定マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private GcdSalesTargetWork CopyToGcdSalesTargetWorkFromGcdSalesTarget(GcdSalesTarget gcdSalesTarget)
        {
            GcdSalesTargetWork gcdSalesTargetWork = new GcdSalesTargetWork();

            gcdSalesTargetWork.CreateDateTime = gcdSalesTarget.CreateDateTime;              // 作成日時
            gcdSalesTargetWork.UpdateDateTime = gcdSalesTarget.UpdateDateTime;              // 更新日時
            gcdSalesTargetWork.EnterpriseCode = gcdSalesTarget.EnterpriseCode;              // 企業コード
            gcdSalesTargetWork.FileHeaderGuid = gcdSalesTarget.FileHeaderGuid;              // GUID
            gcdSalesTargetWork.UpdEmployeeCode = gcdSalesTarget.UpdEmployeeCode;            // 更新従業員コード
            gcdSalesTargetWork.UpdAssemblyId1 = gcdSalesTarget.UpdAssemblyId1;              // 更新アセンブリID1
            gcdSalesTargetWork.UpdAssemblyId2 = gcdSalesTarget.UpdAssemblyId2;              // 更新アセンブリID2
            gcdSalesTargetWork.LogicalDeleteCode = gcdSalesTarget.LogicalDeleteCode;        // 論理削除区分
            gcdSalesTargetWork.SectionCode = gcdSalesTarget.SectionCode;                    // 拠点コード
            gcdSalesTargetWork.TargetSetCd = gcdSalesTarget.TargetSetCd;                    // 目標設定区分
            gcdSalesTargetWork.TargetContrastCd = gcdSalesTarget.TargetContrastCd;          // 目標対比区分
            gcdSalesTargetWork.TargetDivideCode = gcdSalesTarget.TargetDivideCode;          // 目標区分コード
            gcdSalesTargetWork.TargetDivideName = gcdSalesTarget.TargetDivideName;          // 目標区分名称
            gcdSalesTargetWork.GoodsMakerCd = gcdSalesTarget.GoodsMakerCd;                  // メーカーコード
            gcdSalesTargetWork.GoodsNo = gcdSalesTarget.GoodsNo;                            // 品番
            gcdSalesTargetWork.BLGroupCode = gcdSalesTarget.BLGroupCode;                    // グループコード
            gcdSalesTargetWork.BLGoodsCode = gcdSalesTarget.BLGoodsCode;                    // BLコード
            gcdSalesTargetWork.SalesCode = gcdSalesTarget.SalesCode;                        // 販売区分コード
            gcdSalesTargetWork.EnterpriseGanreCode = gcdSalesTarget.EnterpriseGanreCode;    // 商品区分
            gcdSalesTargetWork.ApplyStaDate = gcdSalesTarget.ApplyStaDate;                  // 適用開始日
            gcdSalesTargetWork.ApplyEndDate = gcdSalesTarget.ApplyEndDate;                  // 適用終了日
            gcdSalesTargetWork.SalesTargetMoney = gcdSalesTarget.SalesTargetMoney;          // 売上目標金額
            gcdSalesTargetWork.SalesTargetProfit = gcdSalesTarget.SalesTargetProfit;        // 売上目標粗利額
            gcdSalesTargetWork.SalesTargetCount = gcdSalesTarget.SalesTargetCount;          // 売上目標数量

            return gcdSalesTargetWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(従業員別売上目標検索条件)
        /// </summary>
        /// <param name="para">従業員別売上目標検索条件</param>
        /// <returns>従業員別売上目標検索条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private SearchEmpSalesTargetParaWork CopyToSearchEmpSalesTargetParaWorkFromSearchEmpSalesTargetPara(SearchEmpSalesTargetPara para)
        {
            SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork = new SearchEmpSalesTargetParaWork();

            searchEmpSalesTargetParaWork.EnterpriseCode = para.EnterpriseCode;              // 企業コード
            searchEmpSalesTargetParaWork.LogicalDeleteCode = para.LogicalDeleteCode;        // 論理削除区分
            searchEmpSalesTargetParaWork.SelectSectCd = para.SelectSectCd;                  // 選択拠点コード
            searchEmpSalesTargetParaWork.AllSecSelEpUnit = para.AllSecSelEpUnit;            // 全社選択
            searchEmpSalesTargetParaWork.AllSecSelSecUnit = para.AllSecSelSecUnit;          // 全拠点レコード出力
            searchEmpSalesTargetParaWork.TargetSetCd = para.TargetSetCd;                    // 目標設定区分
            searchEmpSalesTargetParaWork.TargetContrastCd = para.TargetContrastCd;          // 目標対比区分
            searchEmpSalesTargetParaWork.TargetDivideCode = para.TargetDivideCode;          // 目標区分コード
            searchEmpSalesTargetParaWork.TargetDivideName = para.TargetDivideName;          // 目標区分名称
            searchEmpSalesTargetParaWork.StartApplyStaDate = para.StartApplyStaDate;        // 適用開始日(開始)
            searchEmpSalesTargetParaWork.EndApplyStaDate = para.EndApplyStaDate;            // 適用開始日(終了)
            searchEmpSalesTargetParaWork.StartApplyEndDate = para.StartApplyEndDate;        // 適用終了日(開始)
            searchEmpSalesTargetParaWork.EndApplyEndDate = para.EndApplyEndDate;            // 適用終了日(終了)
            searchEmpSalesTargetParaWork.EmployeeCode = para.EmployeeCode;                  // 従業員コード
            searchEmpSalesTargetParaWork.EmployeeDivCd = para.EmployeeDivCd;                // 従業員区分
            searchEmpSalesTargetParaWork.SubSectionCode = para.SubSectionCode;              // 部門コード

            return searchEmpSalesTargetParaWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(得意先別売上目標検索条件)
        /// </summary>
        /// <param name="para">得意先別売上目標検索条件</param>
        /// <returns>得意先別売上目標検索条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private SearchCustSalesTargetParaWork CopyToSearchCustSalesTargetParaWorkFromSearchCustSalesTargetPara(SearchCustSalesTargetPara para)
        {
            SearchCustSalesTargetParaWork searchCustSalesTargetParaWork = new SearchCustSalesTargetParaWork();

            searchCustSalesTargetParaWork.EnterpriseCode = para.EnterpriseCode;             // 企業コード
            searchCustSalesTargetParaWork.LogicalDeleteCode = para.LogicalDeleteCode;       // 論理削除区分
            searchCustSalesTargetParaWork.SelectSectCd = para.SelectSectCd;                 // 選択拠点コード
            searchCustSalesTargetParaWork.AllSecSelEpUnit = para.AllSecSelEpUnit;           // 全社選択
            searchCustSalesTargetParaWork.AllSecSelSecUnit = para.AllSecSelSecUnit;         // 全拠点レコード出力
            searchCustSalesTargetParaWork.TargetSetCd = para.TargetSetCd;                   // 目標設定区分
            searchCustSalesTargetParaWork.TargetContrastCd = para.TargetContrastCd;         // 目標対比区分
            searchCustSalesTargetParaWork.TargetDivideCode = para.TargetDivideCode;         // 目標区分コード
            searchCustSalesTargetParaWork.TargetDivideName = para.TargetDivideName;         // 目標区分名称
            searchCustSalesTargetParaWork.StartApplyStaDate = para.StartApplyStaDate;       // 適用開始日(開始)
            searchCustSalesTargetParaWork.EndApplyStaDate = para.EndApplyStaDate;           // 適用開始日(終了)
            searchCustSalesTargetParaWork.StartApplyEndDate = para.StartApplyEndDate;       // 適用終了日(開始)
            searchCustSalesTargetParaWork.EndApplyEndDate = para.EndApplyEndDate;           // 適用終了日(終了)
            searchCustSalesTargetParaWork.CustomerCode = para.CustomerCode;                 // 得意先コード
            searchCustSalesTargetParaWork.BusinessTypeCode = para.BusinessTypeCode;         // 業種コード
            searchCustSalesTargetParaWork.SalesAreaCode = para.SalesAreaCode;               // 地区コード

            return searchCustSalesTargetParaWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(商品別売上目標検索条件)
        /// </summary>
        /// <param name="para">商品別売上目標検索条件</param>
        /// <returns>商品別売上目標検索条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private SearchGcdSalesTargetParaWork CopyToSearchGcdSalesTargetParaWorkFromSearchGcdSalesTargetPara(SearchGcdSalesTargetPara para)
        {
            SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork = new SearchGcdSalesTargetParaWork();

            searchGcdSalesTargetParaWork.EnterpriseCode = para.EnterpriseCode;              // 企業コード
            searchGcdSalesTargetParaWork.LogicalDeleteCode = para.LogicalDeleteCode;        // 論理削除区分
            searchGcdSalesTargetParaWork.SelectSectCd = para.SelectSectCd;                  // 選択拠点コード
            searchGcdSalesTargetParaWork.AllSecSelEpUnit = para.AllSecSelEpUnit;            // 全社選択
            searchGcdSalesTargetParaWork.AllSecSelSecUnit = para.AllSecSelSecUnit;          // 全拠点レコード出力
            searchGcdSalesTargetParaWork.TargetSetCd = para.TargetSetCd;                    // 目標設定区分
            searchGcdSalesTargetParaWork.TargetContrastCd = para.TargetContrastCd;          // 目標対比区分
            searchGcdSalesTargetParaWork.TargetDivideCode = para.TargetDivideCode;          // 目標区分コード
            searchGcdSalesTargetParaWork.TargetDivideName = para.TargetDivideName;          // 目標区分名称
            searchGcdSalesTargetParaWork.StartApplyStaDate = para.StartApplyStaDate;        // 適用開始日(開始)
            searchGcdSalesTargetParaWork.EndApplyStaDate = para.EndApplyStaDate;            // 適用開始日(終了)
            searchGcdSalesTargetParaWork.StartApplyEndDate = para.StartApplyEndDate;        // 適用終了日(開始)
            searchGcdSalesTargetParaWork.EndApplyEndDate = para.EndApplyEndDate;            // 適用終了日(終了)
            searchGcdSalesTargetParaWork.BLGoodsCode = para.BLGoodsCode;                    // BLコード
            searchGcdSalesTargetParaWork.BLGroupCode = para.BLGroupCode;                    // グループコード
            searchGcdSalesTargetParaWork.GoodsMakerCd = para.GoodsMakerCd;                  // メーカーコード
            searchGcdSalesTargetParaWork.GoodsNo = para.GoodsNo;                            // 品番
            searchGcdSalesTargetParaWork.EnterpriseGanreCode = para.EnterpriseGanreCode;    // 自社分類コード
            searchGcdSalesTargetParaWork.SalesCode = para.SalesCode;                        // 販売区分コード

            return searchGcdSalesTargetParaWork;
        }
        #endregion クラスメンバコピー処理(E→D)

        #region クラスメンバコピー処理(D→E)
        /// <summary>
        /// クラスメンバコピー処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetWork">従業員別売上目標設定マスタワーク</param>
        /// <returns>従業員別売上目標設定マスタ</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private EmpSalesTarget CopyToEmpSalesTargetFromEmpSalesTargetWork(EmpSalesTargetWork empSalesTargetWork)
        {
            EmpSalesTarget empSalesTarget = new EmpSalesTarget();

            empSalesTarget.CreateDateTime = empSalesTargetWork.CreateDateTime;          // 作成日時
            empSalesTarget.UpdateDateTime = empSalesTargetWork.UpdateDateTime;          // 更新日時
            empSalesTarget.EnterpriseCode = empSalesTargetWork.EnterpriseCode;          // 企業コード
            empSalesTarget.FileHeaderGuid = empSalesTargetWork.FileHeaderGuid;          // GUID
            empSalesTarget.UpdEmployeeCode = empSalesTargetWork.UpdEmployeeCode;        // 更新従業員コード
            empSalesTarget.UpdAssemblyId1 = empSalesTargetWork.UpdAssemblyId1;          // 更新アセンブリID1
            empSalesTarget.UpdAssemblyId2 = empSalesTargetWork.UpdAssemblyId2;          // 更新アセンブリID2
            empSalesTarget.LogicalDeleteCode = empSalesTargetWork.LogicalDeleteCode;    // 論理削除区分
            empSalesTarget.SectionCode = empSalesTargetWork.SectionCode;                // 拠点コード
            empSalesTarget.TargetSetCd = empSalesTargetWork.TargetSetCd;                // 目標設定区分
            empSalesTarget.TargetContrastCd = empSalesTargetWork.TargetContrastCd;      // 目標対比区分
            empSalesTarget.TargetDivideCode = empSalesTargetWork.TargetDivideCode;      // 目標区分コード
            empSalesTarget.TargetDivideName = empSalesTargetWork.TargetDivideName;      // 目標区分名称
            empSalesTarget.EmployeeDivCd = empSalesTargetWork.EmployeeDivCd;            // 従業員区分
            empSalesTarget.SubSectionCode = empSalesTargetWork.SubSectionCode;          // 部門コード
            empSalesTarget.EmployeeCode = empSalesTargetWork.EmployeeCode;              // 従業員コード
            empSalesTarget.ApplyStaDate = empSalesTargetWork.ApplyStaDate;              // 適用開始日
            empSalesTarget.ApplyEndDate = empSalesTargetWork.ApplyEndDate;              // 適用終了日
            empSalesTarget.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney;      // 売上目標金額
            empSalesTarget.SalesTargetProfit = empSalesTargetWork.SalesTargetProfit;    // 売上目標粗利額
            empSalesTarget.SalesTargetCount = empSalesTargetWork.SalesTargetCount;      // 売上目標数量

            return empSalesTarget;
        }

        /// <summary>
        /// クラスメンバコピー処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetWork">得意先別売上目標設定マスタワーク</param>
        /// <returns>得意先別売上目標設定マスタ</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private CustSalesTarget CopyToCustSalesTargetFromCustSalesTargetWork(CustSalesTargetWork custSalesTargetWork)
        {
            CustSalesTarget custSalesTarget = new CustSalesTarget();

            custSalesTarget.CreateDateTime = custSalesTargetWork.CreateDateTime;            // 作成日時
            custSalesTarget.UpdateDateTime = custSalesTargetWork.UpdateDateTime;            // 更新日時
            custSalesTarget.EnterpriseCode = custSalesTargetWork.EnterpriseCode;            // 企業コード
            custSalesTarget.FileHeaderGuid = custSalesTargetWork.FileHeaderGuid;            // GUID
            custSalesTarget.UpdEmployeeCode = custSalesTargetWork.UpdEmployeeCode;          // 更新従業員コード
            custSalesTarget.UpdAssemblyId1 = custSalesTargetWork.UpdAssemblyId1;            // 更新アセンブリID1
            custSalesTarget.UpdAssemblyId2 = custSalesTargetWork.UpdAssemblyId2;            // 更新アセンブリID2
            custSalesTarget.LogicalDeleteCode = custSalesTargetWork.LogicalDeleteCode;      // 論理削除区分
            custSalesTarget.SectionCode = custSalesTargetWork.SectionCode;                  // 拠点コード
            custSalesTarget.TargetSetCd = custSalesTargetWork.TargetSetCd;                  // 目標設定区分
            custSalesTarget.TargetContrastCd = custSalesTargetWork.TargetContrastCd;        // 目標対比区分
            custSalesTarget.TargetDivideCode = custSalesTargetWork.TargetDivideCode;        // 目標区分コード
            custSalesTarget.TargetDivideName = custSalesTargetWork.TargetDivideName;        // 目標区分名称
            custSalesTarget.BusinessTypeCode = custSalesTargetWork.BusinessTypeCode;        // 業種コード
            custSalesTarget.SalesAreaCode = custSalesTargetWork.SalesAreaCode;              // 販売エリアコード
            custSalesTarget.CustomerCode = custSalesTargetWork.CustomerCode;                // 得意先コード
            custSalesTarget.ApplyStaDate = custSalesTargetWork.ApplyStaDate;                // 適用開始日
            custSalesTarget.ApplyEndDate = custSalesTargetWork.ApplyEndDate;                // 適用終了日
            custSalesTarget.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney;        // 売上目標金額
            custSalesTarget.SalesTargetProfit = custSalesTargetWork.SalesTargetProfit;      // 売上目標粗利額
            custSalesTarget.SalesTargetCount = custSalesTargetWork.SalesTargetCount;        // 売上目標数量

            return custSalesTarget;
        }

        /// <summary>
        /// クラスメンバコピー処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetWork">商品別売上目標設定マスタワーク</param>
        /// <returns>商品別売上目標設定マスタ</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private GcdSalesTarget CopyToGcdSalesTargetFromGcdSalesTargetWork(GcdSalesTargetWork gcdSalesTargetWork)
        {
            GcdSalesTarget gcdSalesTarget = new GcdSalesTarget();

            gcdSalesTarget.CreateDateTime = gcdSalesTargetWork.CreateDateTime;              // 作成日時
            gcdSalesTarget.UpdateDateTime = gcdSalesTargetWork.UpdateDateTime;              // 更新日時
            gcdSalesTarget.EnterpriseCode = gcdSalesTargetWork.EnterpriseCode;              // 企業コード
            gcdSalesTarget.FileHeaderGuid = gcdSalesTargetWork.FileHeaderGuid;              // GUID
            gcdSalesTarget.UpdEmployeeCode = gcdSalesTargetWork.UpdEmployeeCode;            // 更新従業員コード
            gcdSalesTarget.UpdAssemblyId1 = gcdSalesTargetWork.UpdAssemblyId1;              // 更新アセンブリID1
            gcdSalesTarget.UpdAssemblyId2 = gcdSalesTargetWork.UpdAssemblyId2;              // 更新アセンブリID2
            gcdSalesTarget.LogicalDeleteCode = gcdSalesTargetWork.LogicalDeleteCode;        // 論理削除区分
            gcdSalesTarget.SectionCode = gcdSalesTargetWork.SectionCode;                    // 拠点コード
            gcdSalesTarget.TargetSetCd = gcdSalesTargetWork.TargetSetCd;                    // 目標設定区分
            gcdSalesTarget.TargetContrastCd = gcdSalesTargetWork.TargetContrastCd;          // 目標対比区分
            gcdSalesTarget.TargetDivideCode = gcdSalesTargetWork.TargetDivideCode;          // 目標区分コード
            gcdSalesTarget.TargetDivideName = gcdSalesTargetWork.TargetDivideName;          // 目標区分名称
            gcdSalesTarget.GoodsMakerCd = gcdSalesTargetWork.GoodsMakerCd;                  // メーカーコード
            gcdSalesTarget.GoodsNo = gcdSalesTargetWork.GoodsNo;                            // 品番
            gcdSalesTarget.BLGroupCode = gcdSalesTargetWork.BLGroupCode;                    // グループコード
            gcdSalesTarget.BLGoodsCode = gcdSalesTargetWork.BLGoodsCode;                    // BLコード
            gcdSalesTarget.SalesCode = gcdSalesTargetWork.SalesCode;                        // 販売区分コード
            gcdSalesTarget.EnterpriseGanreCode = gcdSalesTargetWork.EnterpriseGanreCode;    // 商品区分
            gcdSalesTarget.ApplyStaDate = gcdSalesTargetWork.ApplyStaDate;                  // 適用開始日
            gcdSalesTarget.ApplyEndDate = gcdSalesTargetWork.ApplyEndDate;                  // 適用終了日
            gcdSalesTarget.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney;          // 売上目標金額
            gcdSalesTarget.SalesTargetProfit = gcdSalesTargetWork.SalesTargetProfit;        // 売上目標粗利額
            gcdSalesTarget.SalesTargetCount = gcdSalesTargetWork.SalesTargetCount;          // 売上目標数量

            return gcdSalesTarget;
        }
        #endregion クラスメンバコピー処理(D→E)

        #endregion ■ Private Methods
    }
}
