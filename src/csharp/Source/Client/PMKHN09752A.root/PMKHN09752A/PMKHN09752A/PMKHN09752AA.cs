//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 優先倉庫マスタ
// プログラム概要   : 優先倉庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : huangt
// 作 成 日  K2013/09/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 優先倉庫マスタ　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優先倉庫マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/11</br>
    /// </remarks>
    public class ProtyWarehouseAcs
    {
        #region Private Members

        /// <summary>リモートオブジェクト</summary>
        private IProtyWarehouseDB _iProtyWarehouseDB = null;

        #endregion

        #region Constructor

        /// <summary>
        /// 優先倉庫マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 優先倉庫マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
		/// </remarks>
        public ProtyWarehouseAcs()
		{
			try {
				// リモートオブジェクト取得
                this._iProtyWarehouseDB = MediationIProtyWarehouseDB.GetProtyWarehouseDB();
				}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iProtyWarehouseDB = null;
			}
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// 優先倉庫マスタ登録・更新処理
        /// </summary>
        /// <param name="protyWarehouseList">優先倉庫マスタリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタの登録・更新を行います</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        public int Write(ref ArrayList protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList paraList = new ArrayList();

            foreach (ProtyWarehouse protyWarehouse in protyWarehouseList)
            {
                ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();
                // UIデータクラス→ワーク
                protyWarehouseWork = CopyToProtyWarehouseWorkFromProtyWarehouse(protyWarehouse);

                // 登録・更新情報を設定
                paraList.Add(protyWarehouseWork);
            }

            object paraObj = paraList;

            try
            {
                status = this._iProtyWarehouseDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 優先倉庫設定ワーククラスから優先倉庫設定クラスへメンバコピー
                    paraList = (ArrayList)paraObj;
                    protyWarehouseList.Clear();

                    foreach(ProtyWarehouseWork protyWarehouseWork in paraList)
                    {
                        ProtyWarehouse protyWarehouse = new ProtyWarehouse();
                        // ワーク→UIデータクラス
                        protyWarehouse = CopyToProtyWarehouseFromProtyWarehouseWork(protyWarehouseWork);

                        protyWarehouseList.Add(protyWarehouse);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 優先倉庫マスタ論理削除処理
        /// </summary>
        /// <param name="protyWarehouse">優先倉庫マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタの論理削除を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList paraList = new ArrayList();

            foreach (ProtyWarehouse protyWarehouse in protyWarehouseList)
            {
                ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();
                // UIデータクラス→ワーク
                protyWarehouseWork = CopyToProtyWarehouseWorkFromProtyWarehouse(protyWarehouse);

                // 登録・更新情報を設定
                paraList.Add(protyWarehouseWork);
            }

            object paraObj = paraList;

            try
            {
                status = this._iProtyWarehouseDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 優先倉庫設定ワーククラスから優先倉庫設定クラスへメンバコピー
                    paraList = (ArrayList)paraObj;
                    protyWarehouseList.Clear();

                    foreach (ProtyWarehouseWork protyWarehouseWork in paraList)
                    {
                        ProtyWarehouse protyWarehouse = new ProtyWarehouse();
                        // ワーク→UIデータクラス
                        protyWarehouse = CopyToProtyWarehouseFromProtyWarehouseWork(protyWarehouseWork);

                        protyWarehouseList.Add(protyWarehouse);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 優先倉庫マスタ論理削除復活処理
        /// </summary>
        /// <param name="protyWarehouse">優先倉庫マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタの論理削除復活を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        public int Revival(ref ArrayList protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList paraList = new ArrayList();

            foreach (ProtyWarehouse protyWarehouse in protyWarehouseList)
            {
                ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();
                // UIデータクラス→ワーク
                protyWarehouseWork = CopyToProtyWarehouseWorkFromProtyWarehouse(protyWarehouse);

                // 登録・更新情報を設定
                paraList.Add(protyWarehouseWork);
            }

            object paraObj = paraList;

            try
            {
                status = this._iProtyWarehouseDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 優先倉庫設定ワーククラスから優先倉庫設定クラスへメンバコピー
                    paraList = (ArrayList)paraObj;
                    protyWarehouseList.Clear();

                    foreach (ProtyWarehouseWork protyWarehouseWork in paraList)
                    {
                        ProtyWarehouse protyWarehouse = new ProtyWarehouse();
                        // ワーク→UIデータクラス
                        protyWarehouse = CopyToProtyWarehouseFromProtyWarehouseWork(protyWarehouseWork);

                        protyWarehouseList.Add(protyWarehouse);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 優先倉庫マスタ物理削除処理
        /// </summary>
        /// <param name="protyWarehouse">優先倉庫マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタの物理削除を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        public int Delete(ArrayList protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList paraList = new ArrayList();

            foreach (ProtyWarehouse protyWarehouse in protyWarehouseList)
            {
                ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();
                // UIデータクラス→ワーク
                protyWarehouseWork = CopyToProtyWarehouseWorkFromProtyWarehouse(protyWarehouse);

                // 登録・更新情報を設定
                paraList.Add(protyWarehouseWork);
            }

            object paraObj = paraList;

            try
            {
                status = this._iProtyWarehouseDB.Delete(paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Read(out ArrayList protyWarehouseList, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            protyWarehouseList = new ArrayList();

            try
            {
                // 検索条件設定
                ProtyWarehouseWork paraWork = new ProtyWarehouseWork();
                paraWork.EnterpriseCode = enterpriseCode;    // 企業コード
                paraWork.SectionCode = sectionCode;          // 拠点コード

                object paraObj = paraWork;

                // 検索結果
                ArrayList retList = new ArrayList();
                object retObj = retList;

                // 優先倉庫設定情報取得
                status = this._iProtyWarehouseDB.Read(ref retObj, paraWork, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 優先倉庫設定ワーククラスから優先倉庫設定クラスへメンバコピー
                    retList = retObj as ArrayList;
                    foreach (ProtyWarehouseWork protyWarehouseWork in retList)
                    {
                        protyWarehouseList.Add(CopyToProtyWarehouseFromProtyWarehouseWork(protyWarehouseWork));
                    }
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 優先倉庫マスタ検索処理(メイン)
        /// </summary>
        /// <param name="protyWarehouseList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタの検索処理を行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        public int Search(out ArrayList protyWarehouseList, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            protyWarehouseList = new ArrayList();

            try
            {
                // 検索条件設定
                ProtyWarehouseWork paraWork = new ProtyWarehouseWork();
                paraWork.EnterpriseCode = enterpriseCode;   // 企業コード

                object paraObj = paraWork;

                // 検索結果
                ArrayList retList = new ArrayList();
                object retObj = retList;

                // 優先倉庫設定情報取得
                status = this._iProtyWarehouseDB.Search(ref retObj, paraWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 優先倉庫設定ワーククラスから優先倉庫設定クラスへメンバコピー
                    retList = retObj as ArrayList;
                    foreach (ProtyWarehouseWork protyWarehouseWork in retList)
                    {
                        protyWarehouseList.Add(CopyToProtyWarehouseFromProtyWarehouseWork(protyWarehouseWork));
                    }
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します(売伝からの指示書印刷制御の際に使用)
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int ReadWithWarehouse(out ArrayList protyWarehouseList, string enterpriseCode, string sectionCode, string warehouseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            protyWarehouseList = new ArrayList();

            try
            {
                // 検索条件設定
                ProtyWarehouseWork paraWork = new ProtyWarehouseWork();
                paraWork.EnterpriseCode = enterpriseCode;    // 企業コード
                paraWork.SectionCode = sectionCode;          // 拠点コード
                paraWork.WarehouseCode = warehouseCode;      // 倉庫コード

                object paraObj = paraWork;

                // 検索結果
                ArrayList retList = new ArrayList();
                object retObj = retList;

                // 優先倉庫設定情報取得
                status = this._iProtyWarehouseDB.ReadWithWarehouse(ref retObj, paraWork, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 優先倉庫設定ワーククラスから優先倉庫設定クラスへメンバコピー
                    retList = retObj as ArrayList;
                    foreach (ProtyWarehouseWork protyWarehouseWork in retList)
                    {
                        protyWarehouseList.Add(CopyToProtyWarehouseFromProtyWarehouseWork(protyWarehouseWork));
                    }
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iProtyWarehouseDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバコピー処理（優先倉庫マスタワーククラス→優先倉庫マスタクラス）
        /// </summary>
        /// <param name="slipIniSetWork">優先倉庫マスタワーククラス</param>
        /// <returns>優先倉庫マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタワーククラスから優先倉庫マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private ProtyWarehouse CopyToProtyWarehouseFromProtyWarehouseWork(ProtyWarehouseWork protyWarehouseWork)
        {
            ProtyWarehouse protyWarehouse = new ProtyWarehouse();

            // 作成日時
            protyWarehouse.CreateDateTime = protyWarehouseWork.CreateDateTime;
            // 更新日時
            protyWarehouse.UpdateDateTime = protyWarehouseWork.UpdateDateTime;
            // 企業コード
            protyWarehouse.EnterpriseCode = protyWarehouseWork.EnterpriseCode;
            // GUID
            protyWarehouse.FileHeaderGuid = protyWarehouseWork.FileHeaderGuid;
            // 更新従業員コード
            protyWarehouse.UpdEmployeeCode = protyWarehouseWork.UpdEmployeeCode;
            // 更新アセンブリID1
            protyWarehouse.UpdAssemblyId1 = protyWarehouseWork.UpdAssemblyId1;
            // 更新アセンブリID2
            protyWarehouse.UpdAssemblyId2 = protyWarehouseWork.UpdAssemblyId2;
            // 論理削除区分
            protyWarehouse.LogicalDeleteCode = protyWarehouseWork.LogicalDeleteCode;
            // 最新更新日時
            protyWarehouse.MaxUpdateDateTime = protyWarehouseWork.MaxUpdateDateTime;
            // 拠点コード
            protyWarehouse.SectionCode = protyWarehouseWork.SectionCode;
            // 拠点名称
            protyWarehouse.SectionName = protyWarehouseWork.SectionName;
            // 倉庫コード
            protyWarehouse.WarehouseCode = protyWarehouseWork.WarehouseCode;
            // 倉庫名称
            protyWarehouse.WarehouseName = protyWarehouseWork.WarehouseName;
            // 倉庫優先順位
            protyWarehouse.WarehProtyOdr = protyWarehouseWork.WarehProtyOdr;
            
            return protyWarehouse;
        }

        /// <summary>
        /// クラスメンバコピー処理（優先倉庫マスタクラス→優先倉庫マスタクラスワーク）
        /// </summary>
        /// <param name="slipIniSet">優先倉庫マスタクラス</param>
        /// <returns>優先倉庫マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 優先倉庫マスタクラスから優先倉庫マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/11</br>
        /// </remarks>
        private ProtyWarehouseWork CopyToProtyWarehouseWorkFromProtyWarehouse(ProtyWarehouse protyWarehouse)
        {
            ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();

            // 作成日時
            protyWarehouseWork.CreateDateTime = protyWarehouse.CreateDateTime;
            // 更新日時
            protyWarehouseWork.UpdateDateTime = protyWarehouse.UpdateDateTime;
            // 企業コード
            protyWarehouseWork.EnterpriseCode = protyWarehouse.EnterpriseCode;
            // GUID
            protyWarehouseWork.FileHeaderGuid = protyWarehouse.FileHeaderGuid;
            // 更新従業員コード
            protyWarehouseWork.UpdEmployeeCode = protyWarehouse.UpdEmployeeCode;
            // 更新アセンブリID1
            protyWarehouseWork.UpdAssemblyId1 = protyWarehouse.UpdAssemblyId1;
            // 更新アセンブリID2
            protyWarehouseWork.UpdAssemblyId2 = protyWarehouse.UpdAssemblyId2;
            // 論理削除区分
            protyWarehouseWork.LogicalDeleteCode = protyWarehouse.LogicalDeleteCode;
            // 最新更新日時
            protyWarehouseWork.MaxUpdateDateTime = protyWarehouse.MaxUpdateDateTime;
            // 拠点コード
            protyWarehouseWork.SectionCode = protyWarehouse.SectionCode;
            // 拠点名称
            protyWarehouseWork.SectionName = protyWarehouse.SectionName;
            // 倉庫コード
            protyWarehouseWork.WarehouseCode = protyWarehouse.WarehouseCode;
            // 倉庫名称
            protyWarehouseWork.WarehouseName = protyWarehouse.WarehouseName;
            // 倉庫優先順位
            protyWarehouseWork.WarehProtyOdr = protyWarehouse.WarehProtyOdr;


            return protyWarehouseWork;
        }

        #endregion

    }
}
