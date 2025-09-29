using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先マスタ（請求書管理）テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（請求書管理）テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/06/18</br>
    /// </remarks>
    public class CustDmdSetAcs
    {
        #region Private Members

        /// <summary>リモートオブジェクト</summary>
        private ICustDmdSetDB _iCustDmdSetDB = null;

        #endregion

        #region Constructor

        /// <summary>
        /// 得意先マスタ（請求書管理）テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
		/// </remarks>
        public CustDmdSetAcs()
		{
			try {
				// リモートオブジェクト取得
                this._iCustDmdSetDB = MediationCustDmdSetDB.GetCustDmdSetDB();
				}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iCustDmdSetDB = null;
			}
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCustDmdSetDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）登録・更新処理
        /// </summary>
        /// <param name="writeList">得意先マスタ（請求書管理）リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の登録・更新を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int Write(ref CustDmdSet custDmdSet)
        {
            int status = 0;

            try
            {
                // 得意先マスタ（請求書管理）クラスを得意先マスタ（請求書管理）ワーククラスへメンバコピー
                CustDmdSetWork custDmdSetWork = CopyToCustDmdSetWorkFromCustDmdSet(custDmdSet);

                ArrayList wkList = new ArrayList();
                wkList.Clear();

                wkList.Add(custDmdSetWork);

                // 保存
                Object paraObj = wkList;
                status = this._iCustDmdSetDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先マスタ（請求書管理）ワーククラスから得意先マスタ（請求書管理）クラスへメンバコピー
                    wkList = (ArrayList)paraObj;
                    custDmdSetWork = wkList[0] as CustDmdSetWork;
                    custDmdSet = CopyToCustDmdSetFromCustDmdSetWork(custDmdSetWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustDmdSetDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）論理削除処理
        /// </summary>
        /// <param name="estimateDefSet">得意先マスタ（請求書管理）オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int LogicalDelete(ref CustDmdSet custDmdSet)
        {
            int status = 0;

            try
            {
                // 得意先マスタ（請求書管理）クラスを得意先マスタ（請求書管理）ワーククラスへメンバコピー
                CustDmdSetWork custDmdSetWork = CopyToCustDmdSetWorkFromCustDmdSet(custDmdSet);

                ArrayList wkList = new ArrayList();
                wkList.Clear();

                wkList.Add(custDmdSetWork);

                // 得意先マスタ（請求書管理）を論理削除
                Object paraObj = wkList;
                status = this._iCustDmdSetDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先マスタ（請求書管理）ワーククラスを得意先マスタ（請求書管理）クラスにメンバコピー
                    wkList = (ArrayList)paraObj;
                    custDmdSetWork = wkList[0] as CustDmdSetWork;
                    custDmdSet = CopyToCustDmdSetFromCustDmdSetWork(custDmdSetWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustDmdSetDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）論理削除復活処理
        /// </summary>
        /// <param name="estimateDefSet">得意先マスタ（請求書管理）オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int Revival(ref CustDmdSet custDmdSet)
        {
            int status = 0;

            try
            {
                // 得意先マスタ（請求書管理）クラスを得意先マスタ（請求書管理）ワーククラスへメンバコピー
                CustDmdSetWork custDmdSetWork = CopyToCustDmdSetWorkFromCustDmdSet(custDmdSet);

                ArrayList wkList = new ArrayList();
                wkList.Clear();
                wkList.Add(custDmdSetWork);

                // 復活
                Object paraObj = wkList;
                status = this._iCustDmdSetDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先マスタ（請求書管理）ワーククラスを得意先マスタ（請求書管理）クラスにメンバコピー
                    wkList = (ArrayList)paraObj;
                    custDmdSetWork = wkList[0] as CustDmdSetWork;
                    custDmdSet = CopyToCustDmdSetFromCustDmdSetWork(custDmdSetWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustDmdSetDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）物理削除処理
        /// </summary>
        /// <param name="estimateDefSet">得意先マスタ（請求書管理）オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の物理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int Delete(CustDmdSet custDmdSet)
        {
            int status = 0;

            try
            {
                // 得意先マスタ（請求書管理）クラスを得意先マスタ（請求書管理）ワーククラスへメンバコピー
                CustDmdSetWork custDmdSetWork = CopyToCustDmdSetWorkFromCustDmdSet(custDmdSet);

                ArrayList wkList = new ArrayList();
                wkList.Clear();
                wkList.Add(custDmdSetWork);

                Object paraObj = wkList;

                // 得意先マスタ（請求書管理）物理削除
                status = this._iCustDmdSetDB.Delete(wkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iCustDmdSetDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバコピー処理（得意先マスタ（請求書管理）ワーククラス→得意先マスタ（請求書管理）クラス）
        /// </summary>
        /// <param name="slipIniSetWork">得意先マスタ（請求書管理）ワーククラス</param>
        /// <returns>得意先マスタ（請求書管理）クラス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）ワーククラスから得意先マスタ（請求書管理）クラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private CustDmdSet CopyToCustDmdSetFromCustDmdSetWork(CustDmdSetWork custDmdSetWork)
        {
            CustDmdSet custDmdSet = new CustDmdSet();

            // 作成日時
            custDmdSet.CreateDateTime = custDmdSetWork.CreateDateTime;
            // 更新日時
            custDmdSet.UpdateDateTime = custDmdSetWork.UpdateDateTime;
            // 企業コード
            custDmdSet.EnterpriseCode = custDmdSetWork.EnterpriseCode;
            // GUID
            custDmdSet.FileHeaderGuid = custDmdSetWork.FileHeaderGuid;
            // 更新従業員コード
            custDmdSet.UpdEmployeeCode = custDmdSetWork.UpdEmployeeCode;
            // 更新アセンブリID1
            custDmdSet.UpdAssemblyId1 = custDmdSetWork.UpdAssemblyId1;
            // 更新アセンブリID2
            custDmdSet.UpdAssemblyId2 = custDmdSetWork.UpdAssemblyId2;
            // 論理削除区分
            custDmdSet.LogicalDeleteCode = custDmdSetWork.LogicalDeleteCode;
            // 拠点コード
            custDmdSet.SectionCode = custDmdSetWork.SectionCode;
            // 得意先コード
            custDmdSet.CustomerCode  = custDmdSetWork.CustomerCode;
            // データ入力システム
            custDmdSet.DataInputSystem = custDmdSetWork.DataInputSystem;
            // 伝票印刷種別
            custDmdSet.SlipPrtKind = custDmdSetWork.SlipPrtKind;
            // 伝票印刷設定用帳票ID
            custDmdSet.SlipPrtSetPaperId = custDmdSetWork.SlipPrtSetPaperId;

            return custDmdSet;
        }

        /// <summary>
        /// クラスメンバコピー処理（得意先マスタ（請求書管理）クラス→得意先マスタ（請求書管理）クラスワーク）
        /// </summary>
        /// <param name="slipIniSet">得意先マスタ（請求書管理）クラス</param>
        /// <returns>得意先マスタ（請求書管理）ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）クラスから得意先マスタ（請求書管理）ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private CustDmdSetWork CopyToCustDmdSetWorkFromCustDmdSet(CustDmdSet custDmdSet)
        {
            CustDmdSetWork custDmdSetWork = new CustDmdSetWork();

            // 作成日時
            custDmdSetWork.CreateDateTime = custDmdSet.CreateDateTime;
            // 更新日時
            custDmdSetWork.UpdateDateTime = custDmdSet.UpdateDateTime;
            // 企業コード
            custDmdSetWork.EnterpriseCode = custDmdSet.EnterpriseCode;
            // GUID
            custDmdSetWork.FileHeaderGuid = custDmdSet.FileHeaderGuid;
            // 更新従業員コード
            custDmdSetWork.UpdEmployeeCode = custDmdSet.UpdEmployeeCode;
            // 更新アセンブリID1
            custDmdSetWork.UpdAssemblyId1 = custDmdSet.UpdAssemblyId1;
            // 更新アセンブリID2
            custDmdSetWork.UpdAssemblyId2 = custDmdSet.UpdAssemblyId2;
            // 論理削除区分
            custDmdSetWork.LogicalDeleteCode = custDmdSet.LogicalDeleteCode;
            // 拠点コード
            custDmdSetWork.SectionCode = custDmdSet.SectionCode; 
            // 得意先コード
            custDmdSetWork.CustomerCode = custDmdSet.CustomerCode;
            // データ入力システム
            custDmdSetWork.DataInputSystem = custDmdSet.DataInputSystem;
            // 伝票印刷種別
            custDmdSetWork.SlipPrtKind = custDmdSet.SlipPrtKind;
            // 伝票印刷設定用帳票ID
            custDmdSetWork.SlipPrtSetPaperId = custDmdSet.SlipPrtSetPaperId;

            return custDmdSetWork;
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（請求書管理）の検索処理を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            CustDmdSetWork custDmdSetWork = new CustDmdSetWork();
            custDmdSetWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = custDmdSetWork;
            object retobj = wkList;

            // 得意先マスタ（請求書管理）全件検索
            status = this._iCustDmdSetDB.Search(ref retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (CustDmdSetWork wkCustDmdSetWork in wkList)
                    {
                        retList.Add(CopyToCustDmdSetFromCustDmdSetWork(wkCustDmdSetWork));
                    }
                }
            }

            return status;
        }

        #endregion


    }
}
