using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先マスタ(掛率グループ)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 得意先マスタ(掛率グループ)のアクセス制御を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/10/03</br>
    /// <br>Update Note : 2009/10/19 朱俊成 得意先掛率グループコードを取得するメソッドの追加。</br>
    /// <br>Update Note : 2012/04/23 宮津 　掛率G無しと0000を誤認する障害の修正</br>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : 吉岡　孝憲
    // 修 正 日  2013/01/18  修正内容 : 2013/03/13配信　SCM障害№10475対応 速度改善
    //----------------------------------------------------------------------------//
    /// </remarks>
    public class CustRateGroupAcs
    {
        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        object retObjAuto = null;
        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #region ■ Private Members

        private ICustRateGroupDB _iCustRateGroupDB = null;

        #endregion ■ Private Members


        # region ■ Constructor

        /// <summary>
        /// 得意先マスタ(掛率グループ)アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)アクセスクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public CustRateGroupAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iCustRateGroupDB = (ICustRateGroupDB)MediationCustRateGroupDB.GetCustRateGroupDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustRateGroupDB = null;
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
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iCustRateGroupDB == null) || (this._iCustRateGroupDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 得意先マスタ(掛率グループ)読込処理
        /// </summary>
        /// <param name="custRateGroup">得意先マスタ(掛率グループ)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="pureCode">純正区分</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Read(out CustRateGroup custRateGroup, string enterpriseCode, int customerCode, int pureCode, int makerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            custRateGroup = new CustRateGroup();

            try
            {
                // 検索条件設定
                CustRateGroupWork paraWork = new CustRateGroupWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.CustomerCode = customerCode;
                paraWork.PureCode = pureCode;
                paraWork.GoodsMakerCd = makerCode;

                object paraObj = paraWork;

                status = this._iCustRateGroupDB.Read(ref paraObj, 0);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;

                    // クラスメンバコピー処理(D→E)
                    custRateGroup = CopyToCustRateGroupFromCustRateGroupWork((CustRateGroupWork)retList[0]);
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(掛率グループ)取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Search(out ArrayList custRateGroupList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out custRateGroupList, enterpriseCode, 0, 0, logicalMode);

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(掛率グループ)取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Search(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out custRateGroupList, enterpriseCode, customerCode, 0, logicalMode);

            return (status);
        }

        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 得意先マスタ(掛率グループ)取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を取得します。</br>
        /// </remarks>
        public int SearchForAuto(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            custRateGroupList = new ArrayList();

            try
            {
                // 検索条件設定
                CustRateGroupWork paraWork = new CustRateGroupWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.CustomerCode = customerCode;
                paraWork.PureCode = 0;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                if (retObjAuto == null)
                {
                    retObjAuto = retList;
                    status = this._iCustRateGroupDB.Search(ref retObjAuto, paraObj, 0, logicalMode);
                    if (status == 0)
                    {
                        retList = retObjAuto as ArrayList;
                        foreach (CustRateGroupWork custRateGroupWork in retList)
                        {
                            // クラスメンバコピー処理(D→E)
                            custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
                        }
                    }
                }
                else
                {
                    retList = retObjAuto as ArrayList;
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 得意先マスタ(掛率グループ)取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="pureCode">純正区分</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Search(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, int pureCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out custRateGroupList, enterpriseCode, customerCode, pureCode, logicalMode);

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(掛率グループ)更新処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を更新します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Write(ref ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                object paraObj = workList;

                status = this._iCustRateGroupDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    custRateGroupList = new ArrayList();
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// 得意先マスタ(掛率グループ)論理削除処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を論理削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                object paraObj = workList;

                // 論理削除処理
                status = this._iCustRateGroupDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    custRateGroupList = new ArrayList();
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// 得意先マスタ(掛率グループ)削除処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Delete(ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                // ArrayListから配列を生成
                CustRateGroupWork[] works = (CustRateGroupWork[])workList.ToArray(typeof(CustRateGroupWork));

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(works);

                // 物理削除処理
                status = this._iCustRateGroupDB.Delete(parabyte);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先マスタ(掛率グループ)復活処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を復活します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Revival(ref ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                object paraObj = workList;

                // 復活処理
                status = this._iCustRateGroupDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    custRateGroupList = new ArrayList();
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// 得意先掛率グループコードの取得。
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <remarks>
        /// <br>Note      : 得意先掛率グループコードを取得します。</br>
        /// <br>Programmer: 朱俊成</br>
        /// <br>Date      : 2009/10/19</br>
        /// </remarks>
        public void GetCustRateGrp(ArrayList custRateGrpCodeList, int customerCode, int goodsMakerCode, out int custRateGrpCode)
        {
            // -- UPD 2012/04/23 ------------------------------------->>>>
            //custRateGrpCode = 0;
            custRateGrpCode = -1;
            // -- UPD 2012/04/23 -------------------------------------<<<<

            // 純正／優良情報取得
            int pureCode = (goodsMakerCode < 1000) ? 0 : 1;

            // 単独キー判定
            foreach (CustRateGroup custRateGroup in custRateGrpCodeList)
            {
                // -- UPD 2012/04/23 ------------------------------------->>>>
                //if ((customerCode == custRateGroup.CustomerCode) && (goodsMakerCode == custRateGroup.GoodsMakerCd) && (pureCode == custRateGroup.PureCode))
                if ((customerCode == custRateGroup.CustomerCode) &&
                    (goodsMakerCode == custRateGroup.GoodsMakerCd) &&
                    (pureCode == custRateGroup.PureCode) &&
                    (custRateGroup.CustRateGrpCode >= 0))
                // -- UPD 2012/04/23 -------------------------------------<<<<
                {
                    custRateGrpCode = custRateGroup.CustRateGrpCode;
                    return;
                }
            }

            // 共通キー判定
            foreach (CustRateGroup custRateGroup in custRateGrpCodeList)
            {
                if ((customerCode == custRateGroup.CustomerCode) && (0 == custRateGroup.GoodsMakerCd) && (pureCode == custRateGroup.PureCode))
                {
                    custRateGrpCode = custRateGroup.CustRateGrpCode;
                    return;
                }
            }
        }

        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// 得意先マスタ(掛率グループ)取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="pureCode">純正区分</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(掛率グループ)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private int SearchProc(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, int pureCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            custRateGroupList = new ArrayList();

            try
            {
                // 検索条件設定
                CustRateGroupWork paraWork = new CustRateGroupWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.CustomerCode = customerCode;
                paraWork.PureCode = pureCode;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                object retObj = retList;
                status = this._iCustRateGroupDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// <param name="custRateGroup">得意先マスタ(掛率グループ)クラス</param>
        /// <returns>得意先マスタ(掛率グループ)ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private CustRateGroupWork CopyToCustRateGroupWorkFromCustRateGroup(CustRateGroup custRateGroup)
        {
            CustRateGroupWork custRateGroupWork = new CustRateGroupWork();

            custRateGroupWork.CreateDateTime = custRateGroup.CreateDateTime;
            custRateGroupWork.UpdateDateTime = custRateGroup.UpdateDateTime;
            custRateGroupWork.EnterpriseCode = custRateGroup.EnterpriseCode;
            custRateGroupWork.FileHeaderGuid = custRateGroup.FileHeaderGuid;
            custRateGroupWork.UpdEmployeeCode = custRateGroup.UpdEmployeeCode;
            custRateGroupWork.UpdAssemblyId1 = custRateGroup.UpdAssemblyId1;
            custRateGroupWork.UpdAssemblyId2 = custRateGroup.UpdAssemblyId2;
            custRateGroupWork.LogicalDeleteCode = custRateGroup.LogicalDeleteCode;
            custRateGroupWork.CustomerCode = custRateGroup.CustomerCode;
            custRateGroupWork.PureCode = custRateGroup.PureCode;
            custRateGroupWork.GoodsMakerCd = custRateGroup.GoodsMakerCd;
            custRateGroupWork.CustRateGrpCode = custRateGroup.CustRateGrpCode;

            return custRateGroupWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="custRateGroupWork">得意先マスタ(掛率グループ)ワーククラス</param>
        /// <returns>得意先マスタ(掛率グループ)クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private CustRateGroup CopyToCustRateGroupFromCustRateGroupWork(CustRateGroupWork custRateGroupWork)
        {
            CustRateGroup custRateGroup = new CustRateGroup();

            custRateGroup.CreateDateTime = custRateGroupWork.CreateDateTime;
            custRateGroup.UpdateDateTime = custRateGroupWork.UpdateDateTime;
            custRateGroup.EnterpriseCode = custRateGroupWork.EnterpriseCode;
            custRateGroup.FileHeaderGuid = custRateGroupWork.FileHeaderGuid;
            custRateGroup.UpdEmployeeCode = custRateGroupWork.UpdEmployeeCode;
            custRateGroup.UpdAssemblyId1 = custRateGroupWork.UpdAssemblyId1;
            custRateGroup.UpdAssemblyId2 = custRateGroupWork.UpdAssemblyId2;
            custRateGroup.LogicalDeleteCode = custRateGroupWork.LogicalDeleteCode;
            custRateGroup.CustomerCode = custRateGroupWork.CustomerCode;
            custRateGroup.PureCode = custRateGroupWork.PureCode;
            custRateGroup.GoodsMakerCd = custRateGroupWork.GoodsMakerCd;
            custRateGroup.CustRateGrpCode = custRateGroupWork.CustRateGrpCode;

            return custRateGroup;
        }

        #endregion ■ Private Methods
    }
}
