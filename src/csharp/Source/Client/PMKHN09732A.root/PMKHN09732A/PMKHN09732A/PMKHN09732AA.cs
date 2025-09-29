//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      アクセスクラス                                  //
//                  :   PMKHN09732A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ロールグループ権限設定マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ロールグループ権限設定マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// </remarks>
    public class RoleGroupAuthAcs
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // ロールグループ権限設定マスタ
        private IRoleGroupAuthDB _iRoleGroupAuthDB = null;

        #endregion

        #region Constructor

        /// <summary>
        /// ロールグループ権限設定マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupAuthAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRoleGroupAuthDB = (IRoleGroupAuthDB)MediationRoleGroupAuthDB.GetRoleGroupAuthDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupAuthDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iRoleGroupAuthDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 操作権限区分読み込み処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <param name="roleCategoryID">ロールカテゴリID</param>
        /// <param name="roleCategorySubID">ロールサブカテゴリID</param>
        /// <param name="roleItemID">ロールアイテムID</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 操作権限区分を読み込みます。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Read(out RoleGroupAuth roleGroupAuth, string enterpriseCode, Int32 roleGroupCode, Int32 roleCategoryID, Int32 roleCategorySubID, Int32 roleItemID)
        {
            try
            {
                // キー情報の設定
                roleGroupAuth = null;

                RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();
                roleGroupAuthWork.EnterpriseCode = enterpriseCode;
                roleGroupAuthWork.RoleGroupCode = roleGroupCode;
                roleGroupAuthWork.RoleCategoryID = roleCategoryID;
                roleGroupAuthWork.RoleCategorySubID = roleCategorySubID;
                roleGroupAuthWork.RoleItemID = roleItemID;

                // ロールグループ権限設定ワーカークラスをオブジェクトに設定
                object paraObj = (object)roleGroupAuthWork;

                // ロールグループ権限設定読み込み
                int status = this._iRoleGroupAuthDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // 読み込み結果をロールグループ権限設定ワーカークラスに設定
                    RoleGroupAuthWork wkRoleGroupAuthWork = (RoleGroupAuthWork)paraObj;
                    // ロールグループ権限設定ワーカークラスからロールグループ権限設定クラスにコピー
                    roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork(wkRoleGroupAuthWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupAuthDB = null;
                //通信エラーは-1を戻す
                roleGroupAuth = null;
                return -1;
            }
        }

        /// <summary>
        /// ロールグループ権限設定シリアライズ処理
        /// </summary>
        /// <param name="roleGroupAuth">シリアライズ対象ロールグループ権限設定クラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定のシリアライズを行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void Serialize(RoleGroupAuth roleGroupAuth, string fileName)
        {
            // ロールグループ権限設定クラスからロールグループ権限設定ワーカークラスにメンバコピー
            RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

            // ロールグループ権限設定ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(roleGroupAuthWork, fileName);
        }

        /// <summary>
        /// ロールグループ権限設定Listシリアライズ処理
        /// </summary>
        /// <param name="arrRoleGroupAuth">シリアライズ対象ロールグループ権限設定Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定List情報のシリアライズを行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void ListSerialize(ArrayList arrRoleGroupAuth, string fileName)
        {
            RoleGroupAuthWork[] roleGroupAuthWorks = new RoleGroupAuthWork[arrRoleGroupAuth.Count];

            for (int i = 0; i < arrRoleGroupAuth.Count; i++)
            {
                roleGroupAuthWorks[i] = CopyToRoleGroupAuthWorkFromRoleGroupAuth((RoleGroupAuth)arrRoleGroupAuth[i]);
            }

            // ロールグループ権限設定ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(roleGroupAuthWorks, fileName);
        }

        /// <summary>
        /// ロールグループ権限設定クラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>ロールグループ権限設定クラス</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupAuth Deserialize(string fileName)
        {
            RoleGroupAuth roleGroupAuth = null;

            // ファイル名を渡してロールグループ権限設定ワーククラスをデシリアライズする
            RoleGroupAuthWork roleGroupAuthWork = (RoleGroupAuthWork)XmlByteSerializer.Deserialize(fileName, typeof(RoleGroupAuthWork));

            // デシリアライズ結果をロールグループ権限設定クラスへコピー
            if (roleGroupAuthWork != null) roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork(roleGroupAuthWork);

            return roleGroupAuth;
        }

        /// <summary>
        /// ロールグループ権限設定登録・更新処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定クラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定の登録・更新を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Write(ref RoleGroupAuth roleGroupAuth)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            // ロールグループ権限設定クラスからロールグループ権限設定ワーククラスにメンバコピー
            roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

            // ロールグループ権限設定の登録・更新情報を設定
            ArrayList paraList = new ArrayList();
            paraList.Add(roleGroupAuthWork);
            object paraObj = paraList;

            int status = 0;
            try
            {
                // ロールグループ権限設定書き込み
                status = this._iRoleGroupAuthDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // ロールグループ権限設定クラスからロールグループ権限設定ワーククラスにメンバコピー
                    roleGroupAuth = this.CopyToRoleGroupAuthFromRoleGroupAuthWork((RoleGroupAuthWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRoleGroupAuthDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ロールグループ権限設定論理削除処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : ロールグループ権限設定情報の論理削除を行います。<br />
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int LogicalDelete(ref RoleGroupAuth roleGroupAuth)
        {
            int status = 0;

            try
            {
                RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

                ArrayList paraList = new ArrayList();
                paraList.Add(roleGroupAuthWork);
                object paraObj = paraList;

                // ロールグループ権限設定クラス論理削除
                status = this._iRoleGroupAuthDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // クラス内メンバコピー
                    roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork((RoleGroupAuthWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupAuthDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// ロールグループ権限設定物理削除処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : ロールグループ権限設定情報の物理削除を行います。<br />
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Delete(RoleGroupAuth roleGroupAuth)
        {
            try
            {
                RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

                ArrayList paraList = new ArrayList();
                paraList.Add(roleGroupAuthWork);
                object paraObj = paraList;

                // ロールグループ権限設定物理削除
                int status = this._iRoleGroupAuthDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupAuthDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// ロールグループ権限設定論理削除復活処理
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限設定名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : ロールグループ権限設定情報の復活を行います。<br />
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Revival(ref RoleGroupAuth roleGroupAuth)
        {
            try
            {
                RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);
                ArrayList paraList = new ArrayList();
                paraList.Add(roleGroupAuthWork);
                object paraobj = paraList;

                // 復活処理
                int status = this._iRoleGroupAuthDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // クラス内メンバコピー
                    roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork((RoleGroupAuthWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupAuthDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// ロールグループ権限設定マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 取得結果をDataSetで返します。</br>
        /// <br>Programmer  : 30746 高川 悟</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        public int Search(ref DataSet ds, int roleGroupCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // ロールグループ権限設定マスタサーチ
            status = SearchAll(roleGroupCode, out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();
            ArrayList ar = new ArrayList();


            foreach (RoleGroupAuth wkRoleGroupAuth in wkList)
            {
                if (wkRoleGroupAuth.LogicalDeleteCode == 0)
                {
                    if (roleGroupCode == 0)
                    {
                        wkSort.Add(wkRoleGroupAuth.Clone().RoleGroupCode, wkRoleGroupAuth.Clone());
                    }
                    else if (roleGroupCode.Equals(wkRoleGroupAuth.RoleGroupCode))
                    {
                        wkSort.Add(wkRoleGroupAuth.Clone().RoleGroupCode, wkRoleGroupAuth.Clone());

                    }
                }
            }
            ar.AddRange(wkSort.Values);

            RoleGroupAuth[] roleGroupAuths = new RoleGroupAuth[ar.Count];

            // データを元に戻す
            for (int i = 0; i < ar.Count; i++)
            {
                roleGroupAuths[i] = (RoleGroupAuth)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(roleGroupAuths);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// ロールグループコード指定 ロールグループ権限検索処理（論理削除含む）
        /// </summary>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>     
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int SearchAll(Int32 roleGroupCode, out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ユーザー
            status = SearchRoleGroupAuthProc(roleGroupCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:

                    return status;
            }

            // 検索結果件数が0件以外であればステータスを0(正常)に設定
            if (retTotalCnt != 0)
            {
                status = 0;
            }

            retList = list;

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（ロールグループ権限設定ワーククラス⇒ロールグループ権限設定クラス）
        /// </summary>
        /// <param name="roleGroupAuthWork">ロールグループ権限設定ワーククラス</param>
        /// <returns>ロールグループ権限設定クラス</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定ワーククラスからロールグループ権限設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupAuth CopyToRoleGroupAuthFromRoleGroupAuthWork(RoleGroupAuthWork roleGroupAuthWork)
        {
            RoleGroupAuth roleGroupAuth = new RoleGroupAuth();

            roleGroupAuth.CreateDateTime = roleGroupAuthWork.CreateDateTime;
            roleGroupAuth.UpdateDateTime = roleGroupAuthWork.UpdateDateTime;
            roleGroupAuth.EnterpriseCode = roleGroupAuthWork.EnterpriseCode;
            roleGroupAuth.FileHeaderGuid = roleGroupAuthWork.FileHeaderGuid;
            roleGroupAuth.UpdEmployeeCode = roleGroupAuthWork.UpdEmployeeCode;
            roleGroupAuth.UpdAssemblyId1 = roleGroupAuthWork.UpdAssemblyId1;
            roleGroupAuth.UpdAssemblyId2 = roleGroupAuthWork.UpdAssemblyId2;
            roleGroupAuth.LogicalDeleteCode = roleGroupAuthWork.LogicalDeleteCode;

            roleGroupAuth.RoleGroupCode = roleGroupAuthWork.RoleGroupCode;          // ロールグループコード
            roleGroupAuth.RoleCategoryID = roleGroupAuthWork.RoleCategoryID;        // ロールカテゴリID
            roleGroupAuth.RoleCategorySubID = roleGroupAuthWork.RoleCategorySubID;  // ロールサブカテゴリID
            roleGroupAuth.RoleItemID = roleGroupAuthWork.RoleItemID;                // ロールアイテムID
            roleGroupAuth.RoleLimitDiv = roleGroupAuthWork.RoleLimitDiv;            // ロール制限区分

            return roleGroupAuth;
        }

        /// <summary>
        /// クラスメンバーコピー処理（ロールグループ権限クラス⇒ロールグループ権限ワーククラス）
        /// </summary>
        /// <param name="roleGroupAuth">ロールグループ権限ワーククラス</param>
        /// <returns>ロールグループ権限クラス</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限クラスからロールグループ権限ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupAuthWork CopyToRoleGroupAuthWorkFromRoleGroupAuth(RoleGroupAuth roleGroupAuth)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            roleGroupAuthWork.CreateDateTime = roleGroupAuth.CreateDateTime;
            roleGroupAuthWork.UpdateDateTime = roleGroupAuth.UpdateDateTime;
            roleGroupAuthWork.EnterpriseCode = roleGroupAuth.EnterpriseCode;
            roleGroupAuthWork.FileHeaderGuid = roleGroupAuth.FileHeaderGuid;
            roleGroupAuthWork.UpdEmployeeCode = roleGroupAuth.UpdEmployeeCode;
            roleGroupAuthWork.UpdAssemblyId1 = roleGroupAuth.UpdAssemblyId1;
            roleGroupAuthWork.UpdAssemblyId2 = roleGroupAuth.UpdAssemblyId2;
            roleGroupAuthWork.LogicalDeleteCode = roleGroupAuth.LogicalDeleteCode;

            roleGroupAuthWork.RoleGroupCode = roleGroupAuth.RoleGroupCode;          // ロールグループコード
            roleGroupAuthWork.RoleCategoryID = roleGroupAuth.RoleCategoryID;        // ロールカテゴリID
            roleGroupAuthWork.RoleCategorySubID = roleGroupAuth.RoleCategorySubID;  // ロールサブカテゴリID
            roleGroupAuthWork.RoleItemID = roleGroupAuth.RoleItemID;                // ロールアイテムID
            roleGroupAuthWork.RoleLimitDiv = roleGroupAuth.RoleLimitDiv;            // ロール制限区分

            return roleGroupAuthWork;
        }

        /// <summary>
        /// ロールグループ権限検索処理
        /// </summary>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ権限設定の検索処理を行います。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private int SearchRoleGroupAuthProc(Int32 roleGroupCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // キー指定
                roleGroupAuthWork.RoleGroupCode = roleGroupCode;
                roleGroupAuthWork.EnterpriseCode = enterpriseCode;

                // ロールグループ権限設定ワーカークラスをオブジェクトに設定
                object paraObj = (object)roleGroupAuthWork;

                // ロールグループコード指定全件読込
                status = this._iRoleGroupAuthDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (RoleGroupAuthWork wkRoleGroupAuthWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                RoleGroupAuth wkRoleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork(wkRoleGroupAuthWork);
                                // データクラスを読込結果へコピー
                                retList.Add(wkRoleGroupAuth);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        #endregion

    }
}