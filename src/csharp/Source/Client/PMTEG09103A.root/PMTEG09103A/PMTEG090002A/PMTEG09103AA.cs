//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受取手形データマスタメンテナンス
// プログラム概要   : 受取手形データの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/10/18  修正内容 : 抽出条件の追加
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;   
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受取手形データマスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受取手形データマスタメンテナンスのアクセス制御を行います。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.27</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// </remarks>
    public class RcvDraftDataAcs
    {
        # region -- リモートオブジェクト格納バッファ --
        private IRcvDraftDataDB _iRcvDraftDataDB = null;
        // --- ADD 2012/10/18 T.Nishi ----->>>>>
        private RcvDraftDataSet _rcvdraftDataSet = null;
        // --- ADD 2012/10/18 T.Nishi -----<<<<<
        # endregion

        # region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public RcvDraftDataAcs()
        {
            // リモートオブジェクト取得
            this._iRcvDraftDataDB = (IRcvDraftDataDB)MediationRcvDraftDataDB.GetRcvDraftDataDB();
            // --- ADD 2012/10/18 T.Nishi ----->>>>>
            this._rcvdraftDataSet = new RcvDraftDataSet();
            // --- ADD 2012/10/18 T.Nishi -----<<<<<
        }
        # endregion

        # region -- 検索処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">設定コード</param>
        /// <param name="paraRcvDraftData">受取手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2009.03.31</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int Search(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DepositRowNo = paraRcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositSlipNo = paraRcvDraftData.DepositSlipNo;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            rcvDraftDataWork.BankAndBranchCd = paraRcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.DraftDrawingDate = paraRcvDraftData.DraftDrawingDate;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
            // --- ADD 2012/10/18 T.Nishi ----->>>>>
            rcvDraftDataWork.ValidityTerm = paraRcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftKindCd = paraRcvDraftData.DraftKindCd;
            // --- ADD 2012/10/18 T.Nishi -----<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.Search(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">設定コード</param>
        /// <param name="paraRcvDraftData">受取手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithoutBabCd(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.SearchWithoutBabCd(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">設定コード</param>
        /// <param name="paraRcvDraftData">受取手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithBabCd(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;
            rcvDraftDataWork.BankAndBranchCd = paraRcvDraftData.BankAndBranchCd;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.SearchWithBabCd(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">設定コード</param>
        /// <param name="paraRcvDraftData">受取手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithDrawingDate(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftDrawingDate = paraRcvDraftData.DraftDrawingDate;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.SearchWithDrawingDate(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        # endregion

        # region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="rcvDraftDataList">UIデータList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public int Write(ref List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; ;

            ArrayList rcvDraftDataWorkList = new ArrayList();

            foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
            {
                // UIデータクラス→ワーク
                RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                rcvDraftDataWorkList.Add(rcvDraftDataWork);
            }

            object paraObj = rcvDraftDataWorkList;

            status = this._iRcvDraftDataDB.Write(ref paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rcvDraftDataWorkList = paraObj as ArrayList;

                rcvDraftDataList.Clear();
                foreach (RcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
                {
                    // ワーク→UIデータクラス
                    RcvDraftData rcvDraftData = CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWork);

                    rcvDraftDataList.Add(rcvDraftData);
                }
            }

            return status;
        }
        # endregion

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理(受取手形データマスタ)
        /// </summary>
        /// <param name="rcvDraftDataList">受取手形データマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタを論理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int LogicalDelete(ref List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList rcvDraftDataWorkList = new ArrayList();

                foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
                {
                    // UIデータクラス→ワーク
                    RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                    rcvDraftDataWorkList.Add(rcvDraftDataWork);
                }

                object paraObj = rcvDraftDataWorkList;

                // 論理削除処理
                status = this._iRcvDraftDataDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    rcvDraftDataWorkList = paraObj as ArrayList;

                    rcvDraftDataList.Clear();
                    foreach (RcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
                    {
                        // ワーク→UIデータクラス
                        RcvDraftData rcvDraftData = CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWork);

                        rcvDraftDataList.Add(rcvDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理(受取手形データマスタ)
        /// </summary>
        /// <param name="rcvDraftDataList">受取手形データマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタリストを物理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Delete(List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList rcvDraftDataWorkList = new ArrayList();

                foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
                {
                    // UIデータクラス→ワーク
                    RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                    rcvDraftDataWorkList.Add(rcvDraftDataWork);
                }

                object paraObj = rcvDraftDataWorkList;

                // 物理削除処理
                status = this._iRcvDraftDataDB.Delete(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region 復活処理
        /// <summary>
        /// 復活処理(受取手形データマスタ)
        /// </summary>
        /// <param name="rcvDraftDataList">受取手形データマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタを復活します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Revival(ref List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList rcvDraftDataWorkList = new ArrayList();

                foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
                {
                    // UIデータクラス→ワーク
                    RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                    rcvDraftDataWorkList.Add(rcvDraftDataWork);
                }

                object paraObj = rcvDraftDataWorkList;

                // 論理削除処理
                status = this._iRcvDraftDataDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    rcvDraftDataWorkList = paraObj as ArrayList;

                    rcvDraftDataList.Clear();
                    foreach (RcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
                    {
                        // ワーク→UIデータクラス
                        RcvDraftData rcvDraftData = CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWork);

                        rcvDraftDataList.Add(rcvDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（受取手形データマスタワーククラス⇒受取手形データマスタクラス）
        /// </summary>
        /// <param name="rcvDraftDataWork">受取手形データマスタワーククラス</param>
        /// <returns>受取手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタワーククラスから受取手形データマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private RcvDraftData CopyToRcvDraftDataFromRcvDraftDataWork(RcvDraftDataWork rcvDraftDataWork)
        {
            RcvDraftData rcvDraftData = new RcvDraftData();

            rcvDraftData.CreateDateTime = rcvDraftDataWork.CreateDateTime;
            rcvDraftData.UpdateDateTime = rcvDraftDataWork.UpdateDateTime;
            rcvDraftData.EnterpriseCode = rcvDraftDataWork.EnterpriseCode;
            rcvDraftData.FileHeaderGuid = rcvDraftDataWork.FileHeaderGuid;
            rcvDraftData.UpdEmployeeCode = rcvDraftDataWork.UpdEmployeeCode;
            rcvDraftData.UpdAssemblyId1 = rcvDraftDataWork.UpdAssemblyId1;
            rcvDraftData.UpdAssemblyId2 = rcvDraftDataWork.UpdAssemblyId2;
            rcvDraftData.LogicalDeleteCode = rcvDraftDataWork.LogicalDeleteCode;
            rcvDraftData.RcvDraftNo = rcvDraftDataWork.RcvDraftNo;
            rcvDraftData.DraftKindCd = rcvDraftDataWork.DraftKindCd;
            rcvDraftData.DraftDivide = rcvDraftDataWork.DraftDivide;
            rcvDraftData.Deposit = rcvDraftDataWork.Deposit;
            rcvDraftData.BankAndBranchCd = rcvDraftDataWork.BankAndBranchCd;
            rcvDraftData.BankAndBranchNm = rcvDraftDataWork.BankAndBranchNm;
            rcvDraftData.SectionCode = rcvDraftDataWork.SectionCode;
            rcvDraftData.AddUpSecCode = rcvDraftDataWork.AddUpSecCode;
            rcvDraftData.CustomerCode = rcvDraftDataWork.CustomerCode;
            rcvDraftData.CustomerName = rcvDraftDataWork.CustomerName;
            rcvDraftData.CustomerName2 = rcvDraftDataWork.CustomerName2;
            rcvDraftData.CustomerSnm = rcvDraftDataWork.CustomerSnm;
            rcvDraftData.ProcDate = rcvDraftDataWork.ProcDate;
            rcvDraftData.DraftDrawingDate = rcvDraftDataWork.DraftDrawingDate;
            rcvDraftData.ValidityTerm = rcvDraftDataWork.ValidityTerm;
            rcvDraftData.DraftStmntDate = rcvDraftDataWork.DraftStmntDate;
            rcvDraftData.Outline1 = rcvDraftDataWork.Outline1;
            rcvDraftData.Outline2 = rcvDraftDataWork.Outline2;
            rcvDraftData.AcptAnOdrStatus = rcvDraftDataWork.AcptAnOdrStatus;
            rcvDraftData.DepositSlipNo = rcvDraftDataWork.DepositSlipNo;
            rcvDraftData.DepositRowNo = rcvDraftDataWork.DepositRowNo;
            rcvDraftData.DepositDate = rcvDraftDataWork.DepositDate;

            return rcvDraftData;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（受取手形データマスタクラス⇒受取手形データマスタワーククラス）
        /// </summary>
        /// <param name="rcvDraftData">受取手形データマスタクラス</param>
        /// <returns>受取手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタクラスから受取手形データマスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromRcvDraftData(RcvDraftData rcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = rcvDraftData.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = rcvDraftData.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = rcvDraftData.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = rcvDraftData.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = rcvDraftData.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = rcvDraftData.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = rcvDraftData.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = rcvDraftData.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = rcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = rcvDraftData.DraftKindCd;
            rcvDraftDataWork.DraftDivide = rcvDraftData.DraftDivide;
            rcvDraftDataWork.Deposit = rcvDraftData.Deposit;
            rcvDraftDataWork.BankAndBranchCd = rcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = rcvDraftData.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = rcvDraftData.SectionCode;
            rcvDraftDataWork.AddUpSecCode = rcvDraftData.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = rcvDraftData.CustomerCode;
            rcvDraftDataWork.CustomerName = rcvDraftData.CustomerName;
            rcvDraftDataWork.CustomerName2 = rcvDraftData.CustomerName2;
            rcvDraftDataWork.CustomerSnm = rcvDraftData.CustomerSnm;
            rcvDraftDataWork.ProcDate = rcvDraftData.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = rcvDraftData.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = rcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = rcvDraftData.DraftStmntDate;
            rcvDraftDataWork.Outline1 = rcvDraftData.Outline1;
            rcvDraftDataWork.Outline2 = rcvDraftData.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = rcvDraftData.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = rcvDraftData.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = rcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositDate = rcvDraftData.DepositDate;

            return rcvDraftDataWork;
        }
        # endregion
    }

    /// <summary>
    /// 支払手形データマスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払手形データマスタメンテナンスのアクセス制御を行います。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.27</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// </remarks>
    public class PayDraftDataAcs
    {
        # region -- リモートオブジェクト格納バッファ --
        private IPayDraftDataDB _iPayDraftDataDB = null;
        # endregion

        # region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public PayDraftDataAcs()
        {
            // リモートオブジェクト取得
            this._iPayDraftDataDB = (IPayDraftDataDB)MediationPayDraftDataDB.GetPayDraftDataDB();
        }
        # endregion

        # region -- 検索処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">検索モード</param>
        /// <param name="paraPayDraftData">支払手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int Search(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;
            payDraftDataWork.PaymentRowNo = paraPayDraftData.PaymentRowNo;
            payDraftDataWork.PaymentSlipNo = paraPayDraftData.PaymentSlipNo;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            payDraftDataWork.BankAndBranchCd = paraPayDraftData.BankAndBranchCd;
            payDraftDataWork.DraftDrawingDate = paraPayDraftData.DraftDrawingDate;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.Search(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">検索モード</param>
        /// <param name="paraPayDraftData">支払手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithoutBab(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.SearchWithoutBab(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">検索モード</param>
        /// <param name="paraPayDraftData">支払手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithBab(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;
            payDraftDataWork.BankAndBranchCd = paraPayDraftData.BankAndBranchCd;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.SearchWithBab(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="readMode">検索モード</param>
        /// <param name="paraPayDraftData">支払手形データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithDrawingDate(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;
            payDraftDataWork.DraftDrawingDate = paraPayDraftData.DraftDrawingDate;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.SearchWithDrawingDate(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        # endregion

        # region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="payDraftDataList">UIデータList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int Write(ref List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; ;

            ArrayList payDraftDataWorkList = new ArrayList();

            foreach (PayDraftData payDraftData in payDraftDataList)
            {
                // UIデータクラス→ワーク
                PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                payDraftDataWorkList.Add(payDraftDataWork);
            }

            object paraObj = payDraftDataWorkList;

            status = this._iPayDraftDataDB.Write(ref paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                payDraftDataWorkList = paraObj as ArrayList;

                payDraftDataList.Clear();
                foreach (PayDraftDataWork payDraftDataWork in payDraftDataWorkList)
                {
                    // ワーク→UIデータクラス
                    PayDraftData payDraftData = CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWork);

                    payDraftDataList.Add(payDraftData);
                }
            }

            return status;
        }
        # endregion

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理(支払手形データマスタ)
        /// </summary>
        /// <param name="payDraftDataList">支払手形データマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタを論理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int LogicalDelete(ref List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList payDraftDataWorkList = new ArrayList();

                foreach (PayDraftData payDraftData in payDraftDataList)
                {
                    // UIデータクラス→ワーク
                    PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                    payDraftDataWorkList.Add(payDraftDataWork);
                }

                object paraObj = payDraftDataWorkList;

                // 論理削除処理
                status = this._iPayDraftDataDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    payDraftDataWorkList = paraObj as ArrayList;

                    payDraftDataList.Clear();
                    foreach (PayDraftDataWork payDraftDataWork in payDraftDataWorkList)
                    {
                        // ワーク→UIデータクラス
                        PayDraftData payDraftData = CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWork);

                        payDraftDataList.Add(payDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理(支払手形データマスタ)
        /// </summary>
        /// <param name="payDraftDataList">支払手形データマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタリストを物理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int Delete(List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList payDraftDataWorkList = new ArrayList();

                foreach (PayDraftData payDraftData in payDraftDataList)
                {
                    // UIデータクラス→ワーク
                    PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                    payDraftDataWorkList.Add(payDraftDataWork);
                }

                object paraObj = payDraftDataWorkList;

                // 物理削除処理
                status = this._iPayDraftDataDB.Delete(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region 復活処理
        /// <summary>
        /// 復活処理(支払手形データマスタ)
        /// </summary>
        /// <param name="payDraftDataList">支払手形データマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタを復活します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int Revival(ref List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList payDraftDataWorkList = new ArrayList();

                foreach (PayDraftData payDraftData in payDraftDataList)
                {
                    // UIデータクラス→ワーク
                    PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                    payDraftDataWorkList.Add(payDraftDataWork);
                }

                object paraObj = payDraftDataWorkList;

                // 論理削除処理
                status = this._iPayDraftDataDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    payDraftDataWorkList = paraObj as ArrayList;

                    payDraftDataList.Clear();
                    foreach (PayDraftDataWork payDraftDataWork in payDraftDataWorkList)
                    {
                        // ワーク→UIデータクラス
                        PayDraftData payDraftData = CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWork);

                        payDraftDataList.Add(payDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（支払手形データマスタワーククラス⇒支払手形データマスタクラス）
        /// </summary>
        /// <param name="payDraftDataWork">支払手形データマスタワーククラス</param>
        /// <returns>支払手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタワーククラスから支払手形データマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private PayDraftData CopyToPayDraftDataFromPayDraftDataWork(PayDraftDataWork payDraftDataWork)
        {
            PayDraftData payDraftData = new PayDraftData();

            payDraftData.CreateDateTime = payDraftDataWork.CreateDateTime;
            payDraftData.UpdateDateTime = payDraftDataWork.UpdateDateTime;
            payDraftData.EnterpriseCode = payDraftDataWork.EnterpriseCode;
            payDraftData.FileHeaderGuid = payDraftDataWork.FileHeaderGuid;
            payDraftData.UpdEmployeeCode = payDraftDataWork.UpdEmployeeCode;
            payDraftData.UpdAssemblyId1 = payDraftDataWork.UpdAssemblyId1;
            payDraftData.UpdAssemblyId2 = payDraftDataWork.UpdAssemblyId2;
            payDraftData.LogicalDeleteCode = payDraftDataWork.LogicalDeleteCode;
            payDraftData.PayDraftNo = payDraftDataWork.PayDraftNo;
            payDraftData.DraftKindCd = payDraftDataWork.DraftKindCd;
            payDraftData.DraftDivide = payDraftDataWork.DraftDivide;
            payDraftData.Payment = payDraftDataWork.Payment;
            payDraftData.BankAndBranchCd = payDraftDataWork.BankAndBranchCd;
            payDraftData.BankAndBranchNm = payDraftDataWork.BankAndBranchNm;
            payDraftData.SectionCode = payDraftDataWork.SectionCode;
            payDraftData.AddUpSecCode = payDraftDataWork.AddUpSecCode;
            payDraftData.SupplierCd = payDraftDataWork.SupplierCd;
            payDraftData.SupplierNm1 = payDraftDataWork.SupplierNm1;
            payDraftData.SupplierNm2 = payDraftDataWork.SupplierNm2;
            payDraftData.SupplierSnm = payDraftDataWork.SupplierSnm;
            payDraftData.ProcDate = payDraftDataWork.ProcDate;
            payDraftData.DraftDrawingDate = payDraftDataWork.DraftDrawingDate;
            payDraftData.ValidityTerm = payDraftDataWork.ValidityTerm;
            payDraftData.DraftStmntDate = payDraftDataWork.DraftStmntDate;
            payDraftData.Outline1 = payDraftDataWork.Outline1;
            payDraftData.Outline2 = payDraftDataWork.Outline2;
            payDraftData.SupplierFormal = payDraftDataWork.SupplierFormal;
            payDraftData.PaymentSlipNo = payDraftDataWork.PaymentSlipNo;
            payDraftData.PaymentRowNo = payDraftDataWork.PaymentRowNo;
            payDraftData.PaymentDate = payDraftDataWork.PaymentDate;


            return payDraftData;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（支払手形データマスタクラス⇒支払手形データマスタワーククラス）
        /// </summary>
        /// <param name="payDraftData">支払手形データマスタクラス</param>
        /// <returns>支払手形データマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタクラスから支払手形データマスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private PayDraftDataWork CopyToPayDraftDataWorkFromPayDraftData(PayDraftData payDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.CreateDateTime = payDraftData.CreateDateTime;
            payDraftDataWork.UpdateDateTime = payDraftData.UpdateDateTime;
            payDraftDataWork.EnterpriseCode = payDraftData.EnterpriseCode;
            payDraftDataWork.FileHeaderGuid = payDraftData.FileHeaderGuid;
            payDraftDataWork.UpdEmployeeCode = payDraftData.UpdEmployeeCode;
            payDraftDataWork.UpdAssemblyId1 = payDraftData.UpdAssemblyId1;
            payDraftDataWork.UpdAssemblyId2 = payDraftData.UpdAssemblyId2;
            payDraftDataWork.LogicalDeleteCode = payDraftData.LogicalDeleteCode;
            payDraftDataWork.PayDraftNo = payDraftData.PayDraftNo;
            payDraftDataWork.DraftKindCd = payDraftData.DraftKindCd;
            payDraftDataWork.DraftDivide = payDraftData.DraftDivide;
            payDraftDataWork.Payment = payDraftData.Payment;
            payDraftDataWork.BankAndBranchCd = payDraftData.BankAndBranchCd;
            payDraftDataWork.BankAndBranchNm = payDraftData.BankAndBranchNm;
            payDraftDataWork.SectionCode = payDraftData.SectionCode;
            payDraftDataWork.AddUpSecCode = payDraftData.AddUpSecCode;
            payDraftDataWork.SupplierCd = payDraftData.SupplierCd;
            payDraftDataWork.SupplierNm1 = payDraftData.SupplierNm1;
            payDraftDataWork.SupplierNm2 = payDraftData.SupplierNm2;
            payDraftDataWork.SupplierSnm = payDraftData.SupplierSnm;
            payDraftDataWork.ProcDate = payDraftData.ProcDate;
            payDraftDataWork.DraftDrawingDate = payDraftData.DraftDrawingDate;
            payDraftDataWork.ValidityTerm = payDraftData.ValidityTerm;
            payDraftDataWork.DraftStmntDate = payDraftData.DraftStmntDate;
            payDraftDataWork.Outline1 = payDraftData.Outline1;
            payDraftDataWork.Outline2 = payDraftData.Outline2;
            payDraftDataWork.SupplierFormal = payDraftData.SupplierFormal;
            payDraftDataWork.PaymentSlipNo = payDraftData.PaymentSlipNo;
            payDraftDataWork.PaymentRowNo = payDraftData.PaymentRowNo;
            payDraftDataWork.PaymentDate = payDraftData.PaymentDate;


            return payDraftDataWork;
        }
        # endregion
    }
}
