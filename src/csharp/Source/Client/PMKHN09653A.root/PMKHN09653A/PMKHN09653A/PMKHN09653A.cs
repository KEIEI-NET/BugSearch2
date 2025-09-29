//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン目標設定マスタ
// プログラム概要   : キャンペーン目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン目標設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定アクセスクラス</br>
    /// <br>Programmer : 徐佳</br>
    /// <br>Date       : 2011/04/28</br>
    /// </remarks>
    public class CampaignTargetAcs
    {
        #region ■ Private Members

        private ICampaignTargetUDB _iCampaignTargetDB;      // キャンペーン目標リモート
        #endregion ■ Private Members


        #region ■ Constructor
        /// <summary>
        /// キャンペーン目標設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定アクセスクラス</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public CampaignTargetAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iCampaignTargetDB = (ICampaignTargetUDB)MediationCampaignTargetUDB.GetCampaignTargetUDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignTargetDB = null;
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
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignTargetDB == null)
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
        #endregion 検索処理

        #region 更新処理
        /// <summary>
        /// 更新処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタを更新します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Write(ref List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CampaignTarget campaignTarget in campaignTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTarget));
                }

                object paraObj = paraList;

                // 更新処理
                status = this._iCampaignTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    campaignTargetList.Clear();

                    // データ変換
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
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
        /// 論理削除処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタを論理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int LogicalDelete(ref List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CampaignTarget campaignTarget in campaignTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iCampaignTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    campaignTargetList.Clear();

                    // データ変換
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
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
        /// 物理削除処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタを物理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Delete(List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                CampaignTargetWork[] paraWorkArray = new CampaignTargetWork[campaignTargetList.Count];

                for (int index = 0; index < campaignTargetList.Count; index++)
                {
                    // クラスメンバコピー処理(E→D)
                    paraWorkArray[index] = CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTargetList[index]);
                }

                // XMLへ変換し、文字列のバイナリ化
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // 物理削除処理
                status = this._iCampaignTargetDB.Delete(paraByte);
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
        /// 復活処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタを復活します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Revival(ref List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CampaignTarget campaignTarget in campaignTargetList)
                {
                    // クラスメンバコピー処理(E→D)
                    paraList.Add(CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTarget));
                }

                object paraObj = paraList;

                // 論理削除処理
                status = this._iCampaignTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List初期化
                    campaignTargetList.Clear();

                    // データ変換
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
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
        #region 検索処理
        /// <summary>
        /// 検索処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標リスト</param>
        /// <param name="searchCampaignTargetPara">キャンペーン目標検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標定マスタを検索します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Search(ref List<CampaignTarget> campaignTargetList, CampaignTarget searchCampaignTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            campaignTargetList = new List<CampaignTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // クラスメンバコピー処理(E→D)
                CampaignTargetWork paraWork = CopyToSearchCampaignTargetParaWorkFromCampaignTarget(searchCampaignTargetPara);

                object paraObj = paraWork;
                ArrayList list = new ArrayList();
                object retObj = (object)list;

                // 検索処理
                status = this._iCampaignTargetDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
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
        #endregion ■ Public Methods


        #region ■ Private Methods

        #region クラスメンバコピー処理(E→D)
        /// <summary>
        /// クラスメンバコピー処理(キャンペーン目標)
        /// </summary>
        /// <param name="campaignTarget">キャンペーン目標設定マスタ</param>
        /// <returns>キャンペーン目標設定マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        private CampaignTargetWork CopyToSearchCampaignTargetParaWorkFromCampaignTarget(CampaignTarget campaignTarget)
        {
            CampaignTargetWork CampaignTargetWork = new CampaignTargetWork();

            //作成日時
            CampaignTargetWork.CreateDateTime = campaignTarget.CreateDateTime;
            //更新日時
            CampaignTargetWork.UpdateDateTime = campaignTarget.UpdateDateTime;
            //企業コード
            CampaignTargetWork.EnterpriseCode = campaignTarget.EnterpriseCode;
            //更新従業員コード
            CampaignTargetWork.UpdEmployeeCode = campaignTarget.UpdEmployeeCode;
            //更新アセンブリID1
            CampaignTargetWork.UpdAssemblyId1 = campaignTarget.UpdAssemblyId1;
            //更新アセンブリID2
            CampaignTargetWork.UpdAssemblyId2 = campaignTarget.UpdAssemblyId2;
            //論理削除区分
            CampaignTargetWork.LogicalDeleteCode = campaignTarget.LogicalDeleteCode;
            //キャンペーンコード
            CampaignTargetWork.CampaignCode = campaignTarget.CampaignCode;
            //目標対比区分
            CampaignTargetWork.TargetContrastCd = campaignTarget.TargetContrastCd;
            //従業員区分
            CampaignTargetWork.EmployeeDivCd = campaignTarget.EmployeeDivCd;
            //拠点コード
            CampaignTargetWork.SectionCode = campaignTarget.SectionCode;
            //従業員コード
            CampaignTargetWork.EmployeeCode = campaignTarget.EmployeeCode;
            //得意先コード
            CampaignTargetWork.CustomerCode = campaignTarget.CustomerCode;
            //販売エリアコード
            CampaignTargetWork.SalesAreaCode = campaignTarget.SalesAreaCode;
            //BLグループコード
            CampaignTargetWork.BLGroupCode = campaignTarget.BLGroupCode;
            //BL商品コード
            CampaignTargetWork.BLGoodsCode = campaignTarget.BLGoodsCode;
            //販売区分コード
            CampaignTargetWork.SalesCode = campaignTarget.SalesCode;
            //売上目標金額1
            CampaignTargetWork.SalesTargetMoney1 = campaignTarget.SalesTargetMoney1;
            //売上目標金額2
            CampaignTargetWork.SalesTargetMoney2 = campaignTarget.SalesTargetMoney2;
            //売上目標金額3
            CampaignTargetWork.SalesTargetMoney3 = campaignTarget.SalesTargetMoney3;
            //売上目標金額4
            CampaignTargetWork.SalesTargetMoney4 = campaignTarget.SalesTargetMoney4;
            //売上目標金額5
            CampaignTargetWork.SalesTargetMoney5 = campaignTarget.SalesTargetMoney5;
            //売上目標金額6
            CampaignTargetWork.SalesTargetMoney6 = campaignTarget.SalesTargetMoney6;
            //売上目標金額7
            CampaignTargetWork.SalesTargetMoney7 = campaignTarget.SalesTargetMoney7;
            //売上目標金額8
            CampaignTargetWork.SalesTargetMoney8 = campaignTarget.SalesTargetMoney8;
            //売上目標金額9
            CampaignTargetWork.SalesTargetMoney9 = campaignTarget.SalesTargetMoney9;
            //売上目標金額10
            CampaignTargetWork.SalesTargetMoney10 = campaignTarget.SalesTargetMoney10;
            //売上目標金額11
            CampaignTargetWork.SalesTargetMoney11 = campaignTarget.SalesTargetMoney11;
            //売上目標金額12
            CampaignTargetWork.SalesTargetMoney12 = campaignTarget.SalesTargetMoney12;
            //月間売上目標金額
            CampaignTargetWork.MonthlySalesTarget = campaignTarget.MonthlySalesTarget;
            //売上期間目標金額
            CampaignTargetWork.TermSalesTarget = campaignTarget.TermSalesTarget;
            //売上目標粗利額1
            CampaignTargetWork.SalesTargetProfit1 = campaignTarget.SalesTargetProfit1;
            //売上目標粗利額2
            CampaignTargetWork.SalesTargetProfit2 = campaignTarget.SalesTargetProfit2;
            //売上目標粗利額3
            CampaignTargetWork.SalesTargetProfit3 = campaignTarget.SalesTargetProfit3;
            //売上目標粗利額4
            CampaignTargetWork.SalesTargetProfit4 = campaignTarget.SalesTargetProfit4;
            //売上目標粗利額5
            CampaignTargetWork.SalesTargetProfit5 = campaignTarget.SalesTargetProfit5;
            //売上目標粗利額6
            CampaignTargetWork.SalesTargetProfit6 = campaignTarget.SalesTargetProfit6;
            //売上目標粗利額7
            CampaignTargetWork.SalesTargetProfit7 = campaignTarget.SalesTargetProfit7;
            //売上目標粗利額8
            CampaignTargetWork.SalesTargetProfit8 = campaignTarget.SalesTargetProfit8;
            //売上目標粗利額9
            CampaignTargetWork.SalesTargetProfit9 = campaignTarget.SalesTargetProfit9;
            //売上目標粗利額10
            CampaignTargetWork.SalesTargetProfit10 = campaignTarget.SalesTargetProfit10;
            //売上目標粗利額11
            CampaignTargetWork.SalesTargetProfit11 = campaignTarget.SalesTargetProfit11;
            //売上目標粗利額12
            CampaignTargetWork.SalesTargetProfit12 = campaignTarget.SalesTargetProfit12;
            //売上月間目標粗利額
            CampaignTargetWork.MonthlySalesTargetProfit = campaignTarget.MonthlySalesTargetProfit;
            //売上期間目標粗利額
            CampaignTargetWork.TermSalesTargetProfit = campaignTarget.TermSalesTargetProfit;
            //売上目標数量1
            CampaignTargetWork.SalesTargetCount1 = campaignTarget.SalesTargetCount1;
            //売上目標数量2
            CampaignTargetWork.SalesTargetCount2 = campaignTarget.SalesTargetCount2;
            //売上目標数量3
            CampaignTargetWork.SalesTargetCount3 = campaignTarget.SalesTargetCount3;
            //売上目標数量4
            CampaignTargetWork.SalesTargetCount4 = campaignTarget.SalesTargetCount4;
            //売上目標数量5
            CampaignTargetWork.SalesTargetCount5 = campaignTarget.SalesTargetCount5;
            //売上目標数量6
            CampaignTargetWork.SalesTargetCount6 = campaignTarget.SalesTargetCount6;
            //売上目標数量7
            CampaignTargetWork.SalesTargetCount7 = campaignTarget.SalesTargetCount7;
            //売上目標数量8
            CampaignTargetWork.SalesTargetCount8 = campaignTarget.SalesTargetCount8;
            //売上目標数量9
            CampaignTargetWork.SalesTargetCount9 = campaignTarget.SalesTargetCount9;
            //売上目標数量10
            CampaignTargetWork.SalesTargetCount10 = campaignTarget.SalesTargetCount10;
            //売上目標数量11
            CampaignTargetWork.SalesTargetCount11 = campaignTarget.SalesTargetCount11;
            //売上目標数量12
            CampaignTargetWork.SalesTargetCount12 = campaignTarget.SalesTargetCount12;
            //売上月間目標数量
            CampaignTargetWork.MonthlySalesTargetCount = campaignTarget.MonthlySalesTargetCount;
            //売上期間目標数量
            CampaignTargetWork.TermSalesTargetCount = campaignTarget.TermSalesTargetCount;

            return CampaignTargetWork;
        }

        #endregion クラスメンバコピー処理(E→D)

        #region クラスメンバコピー処理(D→E)
        /// <summary>
        /// クラスメンバコピー処理(キャンペーン目標)
        /// </summary>
        /// <param name="CampaignTargetWork">キャンペーン目標設定マスタワーク</param>
        /// <returns>キャンペーン目標設定マスタ</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        private CampaignTarget CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork CampaignTargetWork)
        {
            CampaignTarget campaignTarget = new CampaignTarget();

            //作成日時
            campaignTarget.CreateDateTime = CampaignTargetWork.CreateDateTime;
            //更新日時
            campaignTarget.UpdateDateTime = CampaignTargetWork.UpdateDateTime;
            //企業コード
            campaignTarget.EnterpriseCode = CampaignTargetWork.EnterpriseCode;
            //更新従業員コード
            campaignTarget.UpdEmployeeCode = CampaignTargetWork.UpdEmployeeCode;
            //更新アセンブリID1
            campaignTarget.UpdAssemblyId1 = CampaignTargetWork.UpdAssemblyId1;
            //更新アセンブリID2
            campaignTarget.UpdAssemblyId2 = CampaignTargetWork.UpdAssemblyId2;
            //論理削除区分
            campaignTarget.LogicalDeleteCode = CampaignTargetWork.LogicalDeleteCode;
            //キャンペーンコード
            campaignTarget.CampaignCode = CampaignTargetWork.CampaignCode;
            //目標対比区分
            campaignTarget.TargetContrastCd = CampaignTargetWork.TargetContrastCd;
            //従業員区分
            campaignTarget.EmployeeDivCd = CampaignTargetWork.EmployeeDivCd;
            //拠点コード
            campaignTarget.SectionCode = CampaignTargetWork.SectionCode;
            //従業員コード
            campaignTarget.EmployeeCode = CampaignTargetWork.EmployeeCode;
            //得意先コード
            campaignTarget.CustomerCode = CampaignTargetWork.CustomerCode;
            //販売エリアコード
            campaignTarget.SalesAreaCode = CampaignTargetWork.SalesAreaCode;
            //BLグループコード
            campaignTarget.BLGroupCode = CampaignTargetWork.BLGroupCode;
            //BL商品コード
            campaignTarget.BLGoodsCode = CampaignTargetWork.BLGoodsCode;
            //販売区分コード
            campaignTarget.SalesCode = CampaignTargetWork.SalesCode;
            //売上目標金額1
            campaignTarget.SalesTargetMoney1 = CampaignTargetWork.SalesTargetMoney1;
            //売上目標金額2
            campaignTarget.SalesTargetMoney2 = CampaignTargetWork.SalesTargetMoney2;
            //売上目標金額3
            campaignTarget.SalesTargetMoney3 = CampaignTargetWork.SalesTargetMoney3;
            //売上目標金額4
            campaignTarget.SalesTargetMoney4 = CampaignTargetWork.SalesTargetMoney4;
            //売上目標金額5
            campaignTarget.SalesTargetMoney5 = CampaignTargetWork.SalesTargetMoney5;
            //売上目標金額6
            campaignTarget.SalesTargetMoney6 = CampaignTargetWork.SalesTargetMoney6;
            //売上目標金額7
            campaignTarget.SalesTargetMoney7 = CampaignTargetWork.SalesTargetMoney7;
            //売上目標金額8
            campaignTarget.SalesTargetMoney8 = CampaignTargetWork.SalesTargetMoney8;
            //売上目標金額9
            campaignTarget.SalesTargetMoney9 = CampaignTargetWork.SalesTargetMoney9;
            //売上目標金額10
            campaignTarget.SalesTargetMoney10 = CampaignTargetWork.SalesTargetMoney10;
            //売上目標金額11
            campaignTarget.SalesTargetMoney11 = CampaignTargetWork.SalesTargetMoney11;
            //売上目標金額12
            campaignTarget.SalesTargetMoney12 = CampaignTargetWork.SalesTargetMoney12;
            //月間売上目標金額
            campaignTarget.MonthlySalesTarget = CampaignTargetWork.MonthlySalesTarget;
            //売上期間目標金額
            campaignTarget.TermSalesTarget = CampaignTargetWork.TermSalesTarget;
            //売上目標粗利額1
            campaignTarget.SalesTargetProfit1 = CampaignTargetWork.SalesTargetProfit1;
            //売上目標粗利額2
            campaignTarget.SalesTargetProfit2 = CampaignTargetWork.SalesTargetProfit2;
            //売上目標粗利額3
            campaignTarget.SalesTargetProfit3 = CampaignTargetWork.SalesTargetProfit3;
            //売上目標粗利額4
            campaignTarget.SalesTargetProfit4 = CampaignTargetWork.SalesTargetProfit4;
            //売上目標粗利額5
            campaignTarget.SalesTargetProfit5 = CampaignTargetWork.SalesTargetProfit5;
            //売上目標粗利額6
            campaignTarget.SalesTargetProfit6 = CampaignTargetWork.SalesTargetProfit6;
            //売上目標粗利額7
            campaignTarget.SalesTargetProfit7 = CampaignTargetWork.SalesTargetProfit7;
            //売上目標粗利額8
            campaignTarget.SalesTargetProfit8 = CampaignTargetWork.SalesTargetProfit8;
            //売上目標粗利額9
            campaignTarget.SalesTargetProfit9 = CampaignTargetWork.SalesTargetProfit9;
            //売上目標粗利額10
            campaignTarget.SalesTargetProfit10 = CampaignTargetWork.SalesTargetProfit10;
            //売上目標粗利額11
            campaignTarget.SalesTargetProfit11 = CampaignTargetWork.SalesTargetProfit11;
            //売上目標粗利額12
            campaignTarget.SalesTargetProfit12 = CampaignTargetWork.SalesTargetProfit12;
            //売上月間目標粗利額
            campaignTarget.MonthlySalesTargetProfit = CampaignTargetWork.MonthlySalesTargetProfit;
            //売上期間目標粗利額
            campaignTarget.TermSalesTargetProfit = CampaignTargetWork.TermSalesTargetProfit;
            //売上目標数量1
            campaignTarget.SalesTargetCount1 = CampaignTargetWork.SalesTargetCount1;
            //売上目標数量2
            campaignTarget.SalesTargetCount2 = CampaignTargetWork.SalesTargetCount2;
            //売上目標数量3
            campaignTarget.SalesTargetCount3 = CampaignTargetWork.SalesTargetCount3;
            //売上目標数量4
            campaignTarget.SalesTargetCount4 = CampaignTargetWork.SalesTargetCount4;
            //売上目標数量5
            campaignTarget.SalesTargetCount5 = CampaignTargetWork.SalesTargetCount5;
            //売上目標数量6
            campaignTarget.SalesTargetCount6 = CampaignTargetWork.SalesTargetCount6;
            //売上目標数量7
            campaignTarget.SalesTargetCount7 = CampaignTargetWork.SalesTargetCount7;
            //売上目標数量8
            campaignTarget.SalesTargetCount8 = CampaignTargetWork.SalesTargetCount8;
            //売上目標数量9
            campaignTarget.SalesTargetCount9 = CampaignTargetWork.SalesTargetCount9;
            //売上目標数量10
            campaignTarget.SalesTargetCount10 = CampaignTargetWork.SalesTargetCount10;
            //売上目標数量11
            campaignTarget.SalesTargetCount11 = CampaignTargetWork.SalesTargetCount11;
            //売上目標数量12
            campaignTarget.SalesTargetCount12 = CampaignTargetWork.SalesTargetCount12;
            //売上月間目標数量
            campaignTarget.MonthlySalesTargetCount = CampaignTargetWork.MonthlySalesTargetCount;
            //売上期間目標数量
            campaignTarget.TermSalesTargetCount = CampaignTargetWork.TermSalesTargetCount;


            return campaignTarget;
        }
        #endregion クラスメンバコピー処理(D→E)

        #endregion ■ Private Methods
    }
}
