//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSPインライン対応
// プログラム概要   : TSPインライン対応
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11670305-00  作成担当 : 3H 劉星光
// 作 成 日 : 2020/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Reflection;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TSP連携マスタ設定 テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note            : TSP連携マスタ設定 テーブルアクセスクラス。</br>
    /// <br>Programmer      : 3H 劉星光</br>
    /// <br>Date            : 2020/11/23</br>
    /// <br>管理番号        : 11670305-00</br>
    /// </remarks>
    public class TspCprtStAcs
    {
        #region Private Members
        /// <summary>TSP連携マスタ設定処理リモート</summary>
        private ITspCprtStDB iTspCprtSt = null;
        #endregion

        #region Constructor

        /// <summary>
        /// TSP連携マスタ設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note            : TSP連携マスタ設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public TspCprtStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this.iTspCprtSt = MediationTspCprtStDB.GetTspCprtStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this.iTspCprtSt = null;
            }
        }

        #endregion

        #region Public Methods

        #region 検索処理(ロジック削除分を含まない)
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定 データパラメータ</param>
        /// <param name="tspCprtStWorkList">結果リスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : 検索処理を行います。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Search(TspCprtStWork tspCprtStWork, out ArrayList tspCprtStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = new ArrayList();

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // 検索処理
                status = iTspCprtSt.Search(tspCprtStWork, out tspCprtStWorkObj, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWorkList = (ArrayList)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region 全検索処理(ロジック削除分を含む)
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定 データパラメータ</param>
        /// <param name="tspCprtStWorkList">結果リスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : 検索処理を行います。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int SearchAll(TspCprtStWork tspCprtStWork, out ArrayList tspCprtStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = new ArrayList();

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // 検索処理
                status = iTspCprtSt.Search(tspCprtStWork, out tspCprtStWorkObj, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWorkList = (ArrayList)tspCprtStWorkObj;
                }
            }
            catch(Exception )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region 追加と更新処理
        /// <summary>
        /// 追加と更新処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定 データパラメータ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : 追加と更新処理を行います。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Write(ref TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // 追加更新処理
                status = iTspCprtSt.Write(ref tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region 完全削除処理
        /// <summary>
        /// 完全削除処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定 データパラメータ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : 完全削除処理を行います。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Delete(TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // 完全削除処理
                status = iTspCprtSt.Delete(tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region ロジック削除処理
        /// <summary>
        /// ロジック削除処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定 データパラメータ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : ロジック削除処理を行います。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int LogicalDelete(ref TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // 論理削除処理
                status = iTspCprtSt.LogicalDelete(ref tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region 復活処理
        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定 データパラメータ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : 復活処理を行います。</br>
        /// <br>Programmer      : 3H 劉星光</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Relive(ref TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // 復活処理
                status = iTspCprtSt.Revival(ref tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion
        #endregion

    }
}
