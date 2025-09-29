//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 従業員ロール設定マスタ
// プログラム概要   : 従業員ロール設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸　伸悟
// 作 成 日  2013/02/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//

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
    /// 従業員ロール設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員ロール設定のアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
    public class EmployeeRoleStAcs : IGeneralGuideData
    {
        #region -- リモートオブジェクト格納バッファ --
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private IEmployeeRoleStDB _iEmployeeRoleStDB = null;

        #endregion

        #region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        static EmployeeRoleStAcs()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public EmployeeRoleStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iEmployeeRoleStDB = (IEmployeeRoleStDB)MediationEmployeeRoleStDB.GetEmployeeRoleStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iEmployeeRoleStDB = null;
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
            if (this._iEmployeeRoleStDB == null)
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
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out EmployeeRoleSt employeeRoleSt, string enterpriseCode, string employeeCode, int roleGroupCode)
        {
            return ReadProc(out employeeRoleSt, enterpriseCode, employeeCode, roleGroupCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="roleGroupCode">ロールグループコード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out EmployeeRoleSt employeeRoleSt, string enterpriseCode, string employeeCode, int roleGroupCode)
        {
            int status = 0;

            employeeRoleSt = null;

            try
            {
                EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();
                employeeRoleStWork.EnterpriseCode = enterpriseCode;
                employeeRoleStWork.EmployeeCode = employeeCode;
                employeeRoleStWork.RoleGroupCode = roleGroupCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(employeeRoleStWork);

                status = this._iEmployeeRoleStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    employeeRoleStWork = (EmployeeRoleStWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeRoleStWork));
                    // ワーク→UIデータクラス
                    employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                }

                return status;
            }
            catch (Exception)
            {
                employeeRoleSt = null;
                // オフライン時はnullをセット
                this._iEmployeeRoleStDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 登録･更新処理 --
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            // UIデータクラス→ワーク
            EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

            object obj = employeeRoleStWork;

            try
            {
                // 書き込み処理
                status = this._iEmployeeRoleStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (obj is ArrayList)
                    {
                        employeeRoleStWork = (EmployeeRoleStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                    }
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iEmployeeRoleStDB = null;
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
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定の論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            // UIデータクラス→ワーク
            EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

            object obj = employeeRoleStWork;

            try
            {
                // 論理削除
                status = this._iEmployeeRoleStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    employeeRoleStWork = (EmployeeRoleStWork)obj;
                    // ワーク→UIデータクラス
                    employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iEmployeeRoleStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定の物理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Delete(EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(employeeRoleStWork);

                // 物理削除
                status = this._iEmployeeRoleStDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iEmployeeRoleStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 復活処理 --
        /// <summary>
        /// 従業員ロール設定復活処理
        /// </summary>
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

                object obj = employeeRoleStWork;

                // 復活処理
                status = this._iEmployeeRoleStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    employeeRoleStWork = (EmployeeRoleStWork)obj;
                    // ワーク→UIデータクラス
                    employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iEmployeeRoleStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// 従業員ロール設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, "");
        }

        /// <summary>
        /// 従業員ロール設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定の検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br></br>
        /// </remarks>
        public int Search3(out ArrayList retList, string enterpriseCode, string employeeCode)
        {
            return SearchProc(out retList, enterpriseCode, employeeCode);
        }

        /// <summary>
        /// 従業員ロール設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定の検索処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, string employeeCode)
        {
            int status = 0;

            EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();
            employeeRoleStWork.EnterpriseCode = enterpriseCode;
            employeeRoleStWork.EmployeeCode = employeeCode;

            retList = new ArrayList();

            object paraobj = employeeRoleStWork;
            object retobj = null;

            // 従業員ロール設定の全検索
            status = this._iEmployeeRoleStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (EmployeeRoleStWork wkEmployeeRoleStWork in workList)
                {
                    // 全件追加
                    retList.Add(CopyToEmployeeRoleStFromEmployeeRoleStWork(wkEmployeeRoleStWork));
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
            return Search2(ref ds, enterpriseCode, "");
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
        public int Search2(ref DataSet ds, string enterpriseCode, string employeeCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // マスタサーチ
            status = SearchProc(out retList, enterpriseCode, employeeCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (EmployeeRoleSt wkEmployeeRoleSt in workList)
            {
                if (wkEmployeeRoleSt.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkEmployeeRoleSt.RoleGroupCode, wkEmployeeRoleSt);
                }
            }

            EmployeeRoleSt[] employeeRoleSt = new EmployeeRoleSt[workSort.Count];

            // データを元に戻す
            for (int i = 0; i < workSort.Count; i++)
            {
                employeeRoleSt[i] = (EmployeeRoleSt)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(employeeRoleSt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
        /// </summary>
        /// <param name="employeeRoleStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
        /// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private EmployeeRoleSt CopyToEmployeeRoleStFromEmployeeRoleStWork(EmployeeRoleStWork employeeRoleStWork)
        {
            EmployeeRoleSt employeeRoleSt = new EmployeeRoleSt();

            employeeRoleSt.CreateDateTime = employeeRoleStWork.CreateDateTime;
            employeeRoleSt.UpdateDateTime = employeeRoleStWork.UpdateDateTime;
            employeeRoleSt.EnterpriseCode = employeeRoleStWork.EnterpriseCode;
            employeeRoleSt.FileHeaderGuid = employeeRoleStWork.FileHeaderGuid;
            employeeRoleSt.UpdEmployeeCode = employeeRoleStWork.UpdEmployeeCode;
            employeeRoleSt.UpdAssemblyId1 = employeeRoleStWork.UpdAssemblyId1;
            employeeRoleSt.UpdAssemblyId2 = employeeRoleStWork.UpdAssemblyId2;
            employeeRoleSt.LogicalDeleteCode = employeeRoleStWork.LogicalDeleteCode;
            employeeRoleSt.EmployeeCode = employeeRoleStWork.EmployeeCode;                      // 従業員コード
            employeeRoleSt.RoleGroupCode = employeeRoleStWork.RoleGroupCode;                    // ロールグループコード
            employeeRoleSt.RoleGroupName = employeeRoleStWork.RoleGroupName;                    // ロールグループ名称
            employeeRoleSt.EmployeeName = employeeRoleStWork.EmployeeName;                      // 従業員名称

            return employeeRoleSt;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
        /// </summary>
        /// <param name="employeeRoleSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private EmployeeRoleStWork CopyToEmployeeRoleStWorkFromEmployeeRoleSt(EmployeeRoleSt employeeRoleSt)
        {
            EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();

            employeeRoleStWork.CreateDateTime = employeeRoleSt.CreateDateTime;
            employeeRoleStWork.UpdateDateTime = employeeRoleSt.UpdateDateTime;
            employeeRoleStWork.EnterpriseCode = employeeRoleSt.EnterpriseCode;
            employeeRoleStWork.FileHeaderGuid = employeeRoleSt.FileHeaderGuid;
            employeeRoleStWork.UpdEmployeeCode = employeeRoleSt.UpdEmployeeCode;
            employeeRoleStWork.UpdAssemblyId1 = employeeRoleSt.UpdAssemblyId1;
            employeeRoleStWork.UpdAssemblyId2 = employeeRoleSt.UpdAssemblyId2;
            employeeRoleStWork.LogicalDeleteCode = employeeRoleSt.LogicalDeleteCode;
            employeeRoleStWork.EmployeeCode = employeeRoleSt.EmployeeCode;                      // 従業員コード
            employeeRoleStWork.RoleGroupCode = employeeRoleSt.RoleGroupCode;                    // ロールグループコード
            employeeRoleStWork.RoleGroupName = employeeRoleSt.RoleGroupName;                    // ロールグループ名称
            employeeRoleStWork.EmployeeName = employeeRoleSt.EmployeeName;                      // 従業員名称

            return employeeRoleStWork;
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

            // 従業員ロール設定マスタの読込
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
        /// 従業員ロール設定マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeRoleSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note        : 従業員ロール設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out EmployeeRoleSt employeeRoleSt)
        {
            return ExecuteGuid2(enterpriseCode, out employeeRoleSt);
        }

        /// <summary>
        /// 従業員ロール設定マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeRoleSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note        : 従業員ロール設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid2(string enterpriseCode, out EmployeeRoleSt employeeRoleSt)
        {
            int status = -1;
            employeeRoleSt = new EmployeeRoleSt();

            TableGuideParent tableGuideParent = new TableGuideParent("EMPLOYEEROLESTGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = retObj["RoleGroupCode"].ToString();
                employeeRoleSt.EmployeeCode = retObj["EmployeeCode"].ToString();
                employeeRoleSt.RoleGroupCode = int.Parse(strCode);
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
