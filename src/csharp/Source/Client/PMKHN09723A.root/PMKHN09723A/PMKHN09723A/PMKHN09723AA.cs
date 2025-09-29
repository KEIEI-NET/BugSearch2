//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      アクセスクラス                                  //
//                  :   PMKHN09723A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ロールグループ名称設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ロールグループ名称設定のアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
    public class RoleGroupNameStAcs : IGeneralGuideData
    {
        #region -- リモートオブジェクト格納バッファ --
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private IRoleGroupNameStDB _iRoleGroupNameStDB = null;

        #endregion

        #region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        static RoleGroupNameStAcs()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public RoleGroupNameStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRoleGroupNameStDB = (IRoleGroupNameStDB)MediationRoleGroupNameStDB.GetRoleGroupNameStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRoleGroupNameStDB = null;
            }
        }
        #endregion

        #region -- オンラインモード取得処理 --
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iRoleGroupNameStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion

        #region -- 読み込み処理 --
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out RoleGroupNameSt roleGroupNameSt, string enterpriseCode, int roleGroupCode)
        {
            return ReadProc(out roleGroupNameSt, enterpriseCode, roleGroupCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out RoleGroupNameSt roleGroupNameSt, string enterpriseCode, int roleGroupCode)
        {
            int status = 0;

            roleGroupNameSt = null;

            try
            {
                RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();
                roleGroupNameStWork.EnterpriseCode = enterpriseCode;
                roleGroupNameStWork.RoleGroupCode = roleGroupCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(roleGroupNameStWork);

                status = this._iRoleGroupNameStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    roleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(parabyte, typeof(RoleGroupNameStWork));
                    // ワーク→UIデータクラス
                    roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                }

                return status;
            }
            catch (Exception)
            {
                roleGroupNameSt = null;
                // オフライン時はnullをセット
                this._iRoleGroupNameStDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 登録･更新処理 --
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            // UIデータクラス→ワーク
            RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

            object obj = roleGroupNameStWork;

            try
            {
                // 書き込み処理
                status = this._iRoleGroupNameStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (obj is ArrayList)
                    {
                        roleGroupNameStWork = (RoleGroupNameStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                    }
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRoleGroupNameStDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }
        #endregion

        #region -- 削除処理 --
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定の論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            // UIデータクラス→ワーク
            RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

            object obj = roleGroupNameStWork;

            try
            {
                // 論理削除
                status = this._iRoleGroupNameStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    roleGroupNameStWork = (RoleGroupNameStWork)obj;
                    // ワーク→UIデータクラス
                    roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupNameStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定の物理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Delete(RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(roleGroupNameStWork);

                // 物理削除
                status = this._iRoleGroupNameStDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupNameStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 復活処理 --
        /// <summary>
        /// ロールグループ名称設定復活処理
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

                object obj = roleGroupNameStWork;

                // 復活処理
                status = this._iRoleGroupNameStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    roleGroupNameStWork = (RoleGroupNameStWork)obj;
                    // ワーク→UIデータクラス
                    roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRoleGroupNameStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// ロールグループ名称設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// ロールグループ名称設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定の検索処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();
            roleGroupNameStWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = roleGroupNameStWork;
            object retobj = null;

            // ロールグループ名称設定の全検索
            status = this._iRoleGroupNameStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (RoleGroupNameStWork wkRoleGroupNameStWork in workList)
                {
                    // 全件追加
                    retList.Add(CopyToRoleGroupNameStFromRoleGroupNameStWork(wkRoleGroupNameStWork));
                }
            }

            return status;
        }

        /// <summary>
        /// マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 取得結果をDataSetで返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode)
        {
            return Search2(ref ds, enterpriseCode);
        }

        /// <summary>
        /// マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 取得結果をDataSetで返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search2(ref DataSet ds, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // マスタサーチ
            status = SearchProc(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (RoleGroupNameSt wkRoleGroupNameSt in workList)
            {
                if (wkRoleGroupNameSt.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkRoleGroupNameSt.RoleGroupCode, wkRoleGroupNameSt);
                }
            }

            RoleGroupNameSt[] roleGroupNameSt = new RoleGroupNameSt[workSort.Count];

            // データを元に戻す
            for (int i = 0; i < workSort.Count; i++)
            {
                roleGroupNameSt[i] = (RoleGroupNameSt)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(roleGroupNameSt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
        /// </summary>
        /// <param name="roleGroupNameStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
        /// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private RoleGroupNameSt CopyToRoleGroupNameStFromRoleGroupNameStWork(RoleGroupNameStWork roleGroupNameStWork)
        {
            RoleGroupNameSt roleGroupNameSt = new RoleGroupNameSt();

            roleGroupNameSt.CreateDateTime = roleGroupNameStWork.CreateDateTime;
            roleGroupNameSt.UpdateDateTime = roleGroupNameStWork.UpdateDateTime;
            roleGroupNameSt.EnterpriseCode = roleGroupNameStWork.EnterpriseCode;
            roleGroupNameSt.FileHeaderGuid = roleGroupNameStWork.FileHeaderGuid;
            roleGroupNameSt.UpdEmployeeCode = roleGroupNameStWork.UpdEmployeeCode;
            roleGroupNameSt.UpdAssemblyId1 = roleGroupNameStWork.UpdAssemblyId1;
            roleGroupNameSt.UpdAssemblyId2 = roleGroupNameStWork.UpdAssemblyId2;
            roleGroupNameSt.LogicalDeleteCode = roleGroupNameStWork.LogicalDeleteCode;

            roleGroupNameSt.RoleGroupCode = roleGroupNameStWork.RoleGroupCode;                  // ロールグループコード
            roleGroupNameSt.RoleGroupName = roleGroupNameStWork.RoleGroupName;                  // ロールグループ名称

            return roleGroupNameSt;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
        /// </summary>
        /// <param name="roleGroupNameSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private RoleGroupNameStWork CopyToRoleGroupNameStWorkFromRoleGroupNameSt(RoleGroupNameSt roleGroupNameSt)
        {
            RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();

            roleGroupNameStWork.CreateDateTime = roleGroupNameSt.CreateDateTime;
            roleGroupNameStWork.UpdateDateTime = roleGroupNameSt.UpdateDateTime;
            roleGroupNameStWork.EnterpriseCode = roleGroupNameSt.EnterpriseCode;
            roleGroupNameStWork.FileHeaderGuid = roleGroupNameSt.FileHeaderGuid;
            roleGroupNameStWork.UpdEmployeeCode = roleGroupNameSt.UpdEmployeeCode;
            roleGroupNameStWork.UpdAssemblyId1 = roleGroupNameSt.UpdAssemblyId1;
            roleGroupNameStWork.UpdAssemblyId2 = roleGroupNameSt.UpdAssemblyId2;
            roleGroupNameStWork.LogicalDeleteCode = roleGroupNameSt.LogicalDeleteCode;

            roleGroupNameStWork.RoleGroupCode = roleGroupNameSt.RoleGroupCode;                  // ロールグループコード
            roleGroupNameStWork.RoleGroupName = roleGroupNameSt.RoleGroupName;                  // ロールグループ名称

            return roleGroupNameStWork;
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note        : 汎用ガイド設定用データを取得します。</br>
        /// <br></br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // ロールグループ名称設定マスタの読込
            status = Search(ref guideList, enterpriseCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ロールグループ名称設定マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="roleGroupNameSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note        : ロールグループ名称設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out RoleGroupNameSt roleGroupNameSt)
        {
            return ExecuteGuid2(enterpriseCode, out roleGroupNameSt);
        }

        /// <summary>
        /// ロールグループ名称設定マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="roleGroupNameSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note        : ロールグループ名称設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid2(string enterpriseCode, out RoleGroupNameSt roleGroupNameSt)
        {
            int status = -1;
            roleGroupNameSt = new RoleGroupNameSt();

            TableGuideParent tableGuideParent = new TableGuideParent("ROLEGROUPNAMESTGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = retObj["RoleGroupCode"].ToString();
                roleGroupNameSt.RoleGroupCode = int.Parse(strCode);
                roleGroupNameSt.RoleGroupName = retObj["RoleGroupName"].ToString();
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
        #endregion
    }
}