//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せ接続情報アクセスクラス
// プログラム概要   : 簡単問合せ接続情報を追加・削除する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/25  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 簡単問合せ接続情報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br>----------------------------------------------------------------------------</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class SimplInqCnectInfoAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public SimplInqCnectInfoAcs()
        {
        }
        #endregion


        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Member

        private ISimplInqCnectInfoDB _SimplInqCnectInfoDB = null;
        private SimplInqCnectInfoDataSet _SimplInqCnectInfoDataSet = null;

        private List<SimplInqCnectInfo> _cacheList = null;
        private List<CustomerSearchRet> _customerSearchRetList = null;
        private PosTerminalMg _ownPosTerminalMg = null;
        private List<PosTerminalMg> _posTerminalMgList = null;

        #endregion


        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■ Property

        /// <summary>
        /// CMT接続情報テーブルプロパティ
        /// </summary>
        public SimplInqCnectInfoDataSet.SimplInqCnectInfoDataTable SimplInqCnectInfoTable
        {
            get
            {
                if (this._SimplInqCnectInfoDataSet == null) this._SimplInqCnectInfoDataSet = new SimplInqCnectInfoDataSet();

                return this._SimplInqCnectInfoDataSet.SimplInqCnectInfo;
            }
        }

        #endregion


        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■ Public Method

        #region ＵＩ用のメソッド

        /// <summary>
        /// 拠点マスタより、指定拠点の拠点名称を取得します。
        /// </summary>
        /// <returns>自拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public string GetOwnSectionName(string loginSectionCode)
        {
            string ownSectionName = string.Empty;

            // 自拠点の取得
            SecInfoAcs _secInfoAcs = new SecInfoAcs();
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // 自拠点コードの保存
                ownSectionName = secInfoSet.SectionGuideNm;
            }

            return ownSectionName;
        }

        /// <summary>
        /// 端末管理マスタ（ローカル）より、自端末の番号を取得します。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int GetOwnCashRegisterNo(string enterpriseCode)
        {
            if (_ownPosTerminalMg == null)
            {
                PosTerminalMgAcs acs = new PosTerminalMgAcs();
                acs.Search(out this._ownPosTerminalMg, enterpriseCode);
            }

            if (_ownPosTerminalMg == null) this._ownPosTerminalMg = new PosTerminalMg();

            return _ownPosTerminalMg.CashRegisterNo;
        }

        /// <summary>
        /// 指定された企業の簡単問合せ接続情報を取得します。(画面用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int Search(string enterpriseCode)
        {
            List<SimplInqCnectInfo> SimplInqCnectInfoList;

            return this.SearchProc(enterpriseCode, out SimplInqCnectInfoList, true, true);
        }

        /// <summary>
        /// 保存します（データテーブルで選択中の接続情報を削除します）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int Save(string enterpriseCode)
        {
            SimplInqCnectInfoDataSet.SimplInqCnectInfoRow[] rows = (SimplInqCnectInfoDataSet.SimplInqCnectInfoRow[])this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.Select(string.Format("{0} = True", this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.SelectedColumn.ColumnName));

            List<SimplInqCnectInfo> paraList = new List<SimplInqCnectInfo>();
            if (rows != null && rows.Length > 0)
            {
                foreach (SimplInqCnectInfoDataSet.SimplInqCnectInfoRow row in rows)
                {
                    paraList.Add(this.CopyToSimplInqCnectInfoFromRow(row));
                }

                return this.DeleteProc(enterpriseCode, paraList);
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion

        #region 部品として実装したメソッド

        /// <summary>
        /// 自端末の簡単問合せ接続情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">簡単問合せ接続情報リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int SearchOwnCnectInfoList(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            return this.SearchOwnCnectInfoListProc(enterpriseCode, out simplInqCnectInfoList);
        }

        /// <summary>
        /// 指定された企業の簡単問合せ接続情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">簡単問合せ接続情報リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int Search(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            return this.SearchProc(enterpriseCode, out simplInqCnectInfoList, false, false);
        }

        /// <summary>
        /// 簡単問合せ接続情報を追加します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int AddConnect(string enterpriseCode, int cashRegisterNo, int customerCode)
        {
            SimplInqCnectInfo inf = new SimplInqCnectInfo();
            inf.CashRegisterNo = cashRegisterNo;
            inf.CustomerCode = customerCode;
            return this.WriteProc(enterpriseCode, inf);
        }


        /// <summary>
        /// 簡単問合せ接続情報を削除します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 新規作成</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int DeleteConnect(string enterpriseCode, int cashRegisterNo, int customerCode)
        {
            List<SimplInqCnectInfo> list = new List<SimplInqCnectInfo>();
            SimplInqCnectInfo inf = new SimplInqCnectInfo();
            inf.CashRegisterNo = cashRegisterNo;
            inf.CustomerCode = customerCode;
            list.Add(inf);

            return this.DeleteProc(enterpriseCode, list);
        }

        #endregion

        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        #region [ 簡単問合せ接続情報関係 ]

        /// <summary>
        /// 簡単問合せ接続情報を検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList"></param>
        /// <returns></returns>
        private int SearchOwnCnectInfoListProc(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            simplInqCnectInfoList = null;

            List<SimplInqCnectInfo> tempList;
            int status = this.SearchProc(enterpriseCode, out tempList, false, false);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            int cashRegisterNo = this.GetOwnCashRegisterNo(enterpriseCode);
            if (cashRegisterNo != 0 && tempList != null)
            {
                simplInqCnectInfoList = tempList.FindAll(delegate(SimplInqCnectInfo target)
                {
                    if (target.CashRegisterNo == cashRegisterNo) return true;
                    return false;
                });
            }

            return status;
        }

        /// <summary>
        /// 簡単問合せ接続情報を検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">簡単問合せ接続情報リスト</param>
        /// <param name="cache">True:キャッシュする</param>
        /// <param name="createTable">True:テーブル作成する(得意先及び端末管理の検索が走ります)</param>
        /// <returns></returns>
        private int SearchProc(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList, bool cache, bool createTable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            simplInqCnectInfoList = null;

            if (_SimplInqCnectInfoDB == null)
            {
                _SimplInqCnectInfoDB = MediationSimplInqCnectInfoDB.GetSimplInqCnectInfoDB();
            }

            // ファイル
            object retObj;

            status = _SimplInqCnectInfoDB.Search(enterpriseCode, out retObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList al = (ArrayList)retObj;

                simplInqCnectInfoList = new List<SimplInqCnectInfo>();

                foreach (SimplInqCnectInfoWork work in al)
                {
                    simplInqCnectInfoList.Add(CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(work));
                }

                // TODO:あんまり良くないかも
                if (cache) this._cacheList = simplInqCnectInfoList;
            }

            // テーブル作成有り
            if (createTable)
            {
                if (this._SimplInqCnectInfoDataSet == null)
                    this._SimplInqCnectInfoDataSet = new SimplInqCnectInfoDataSet();
                else
                    this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.Rows.Clear();

                if (simplInqCnectInfoList != null)
                {
                    foreach (SimplInqCnectInfo SimplInqCnectInfo in simplInqCnectInfoList)
                    {
                        SimplInqCnectInfoDataSet.SimplInqCnectInfoRow row = this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.NewSimplInqCnectInfoRow();
                        row.CashRegisterNo = SimplInqCnectInfo.CashRegisterNo;
                        row.CustomerCode = SimplInqCnectInfo.CustomerCode;

                        // 得意先名称のセット
                        if (row.CustomerCode != 0)
                        {
                            CustomerSearchRet customer = this.FindCustomer(enterpriseCode, row.CustomerCode);
                            if (customer != null)
                            {
                                row.CustomerSnm = customer.Snm;
                            }
                        }

                        PosTerminalMg pos = this.FindPosTerminalMg(enterpriseCode, row.CashRegisterNo);
                        if (pos != null)
                        {
                            row.MachineName = pos.MachineName;
                        }
                        this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.AddSimplInqCnectInfoRow(row);
                    }
                }
            }

            return status;
        }


        /// <summary>
        /// 指定された簡単問合せ接続情報を書き込みます。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="simplInqCnectInfo"></param>
        /// <returns></returns>
        private int WriteProc(string enterpriseCode, SimplInqCnectInfo simplInqCnectInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_SimplInqCnectInfoDB == null)
            {
                _SimplInqCnectInfoDB = MediationSimplInqCnectInfoDB.GetSimplInqCnectInfoDB();
            }
            SimplInqCnectInfoWork para = this.CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(simplInqCnectInfo);
            status = _SimplInqCnectInfoDB.Write(enterpriseCode, (object)para);

            return status;
        }


        /// <summary>
        /// 指定された簡単問合せ接続情報を削除します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="simplInqCnectInfoList"></param>
        /// <returns></returns>
        private int DeleteProc(string enterpriseCode, List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_SimplInqCnectInfoDB == null)
            {
                _SimplInqCnectInfoDB = MediationSimplInqCnectInfoDB.GetSimplInqCnectInfoDB();
            }
            ArrayList paraList = new ArrayList();

            foreach (SimplInqCnectInfo info in simplInqCnectInfoList)
            {
                paraList.Add(this.CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(info));
            }

            status = _SimplInqCnectInfoDB.Delete(enterpriseCode, (object)paraList);

            return status;
        }

        #endregion

        #region [ 得意先関係 ]

        /// <summary>
        /// 得意先検索
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerSearchRet FindCustomer(string enterpriseCode, int customerCode)
        {
            if (this._customerSearchRetList == null) this.SearchCutomer(enterpriseCode);

            if (this._customerSearchRetList == null || this._customerSearchRetList.Count == 0) return null;

            return _customerSearchRetList.Find(
                delegate(CustomerSearchRet ret)
                {
                    if (ret.LogicalDeleteCode != 0) return false;
                    if (ret.CustomerCode != customerCode) return false;

                    return true;
                });
        }


        /// <summary>
        /// 得意先検索
        /// </summary>
        /// <param name="enterpriseCode"></param>
        private void SearchCutomer(string enterpriseCode)
        {
            this._customerSearchRetList = new List<CustomerSearchRet>();

            CustomerSearchAcs acs = new CustomerSearchAcs();

            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = enterpriseCode;

            CustomerSearchRet[] retList;
            int status = acs.Serch(out retList, para);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._customerSearchRetList.AddRange(retList);
            }
        }

        #endregion

        #region [ 端末管理関係 ]

        /// <summary>
        /// 端末管理検索
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private PosTerminalMg FindPosTerminalMg(string enterpriseCode, int cashRegisterNo)
        {
            if (this._posTerminalMgList == null) this.SearchPosTerminalMg(enterpriseCode);

            if (this._posTerminalMgList == null || this._posTerminalMgList.Count == 0) return null;

            return _posTerminalMgList.Find(
                delegate(PosTerminalMg ret)
                {
                    if (ret.LogicalDeleteCode != 0) return false;
                    if (ret.CashRegisterNo != cashRegisterNo) return false;

                    return true;
                });
        }

        /// <summary>
        /// 端末管理検索
        /// </summary>
        /// <param name="enterpriseCode"></param>
        private void SearchPosTerminalMg(string enterpriseCode)
        {
            this._posTerminalMgList = new List<PosTerminalMg>();
            
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            ArrayList al;

            int status = acs.SearchServer(out al, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._posTerminalMgList = new List<PosTerminalMg>();
                foreach (PosTerminalMg element in al)
                {
                    this._posTerminalMgList.Add(element);
                }
            }
        }

        #endregion

        # region [ クラス格納処理 ]

        /// <summary>
        /// クラス格納処理（SimplInqCnectInfo→SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="SimplInqCnectInfo">SimplInqCnectInfoオブジェクト</param>
        /// <returns>SimplInqCnectInfoWorkオブジェクト</returns>
        private SimplInqCnectInfoWork CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(SimplInqCnectInfo SimplInqCnectInfo)
        {
            SimplInqCnectInfoWork work = new SimplInqCnectInfoWork();

            work.CashRegisterNo = SimplInqCnectInfo.CashRegisterNo;
            work.CustomerCode = SimplInqCnectInfo.CustomerCode;

            return work;
        }

        /// <summary>
        /// クラス格納処理（SimplInqCnectInfo→SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="SimplInqCnectInfoWork">SimplInqCnectInfoWorkオブジェクト</param>
        /// <returns>SimplInqCnectInfoオブジェクト</returns>
        private SimplInqCnectInfo CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(SimplInqCnectInfoWork SimplInqCnectInfoWork)
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();

            info.CashRegisterNo = SimplInqCnectInfoWork.CashRegisterNo;
            info.CustomerCode = SimplInqCnectInfoWork.CustomerCode;

            return info;
        }

        /// <summary>
        ///  クラス格納処理（DataRow→SimplInqCnectInfo)
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private SimplInqCnectInfo CopyToSimplInqCnectInfoFromRow(SimplInqCnectInfoDataSet.SimplInqCnectInfoRow row)
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();

            info.CashRegisterNo = row.CashRegisterNo;
            info.CustomerCode = row.CustomerCode;

            return info;
        }

        # endregion

        #endregion

    }
}
