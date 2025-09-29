//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品照会情報アクセスクラス
// プログラム概要   : 検品照会情報アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11470154-00 作成担当 : 陳艶丹                              
// 修 正 日  2018/10/16  修正内容 : ハンディターミナル五次対応
//                                  取消機能とテキスト出力機能の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 検品照会情報アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 検品照会情報のアクセス制御を行います。</br>
    /// <br>Programmer	: 譚洪</br>
    /// <br>Date		: 2017/07/20/br>
    /// <br>Update Note: 2018/10/16 陳艶丹</br>
    /// <br>　　　　　 : ハンディターミナル五次対応</br>
	/// </remarks>    
	public class InspectInfoAcs
	{
		# region ■Private Member
        /// <summary>インスタンス(singleton)</summary>
        private static InspectInfoAcs InspectInfoAccessor;
		/// <summary>リモートオブジェクト格納バッファ</summary>
        private IHandyInspectRefDataDB IHandyInspectRefDataDBAdapter = null;
        private Dictionary<string, string> EmployeeDic;
        /// <summary>従業員マスタアクセスクラス</summary>
        private EmployeeAcs EmployeeAccessor;
        
		# endregion				    
		  
		# region ■Constracter
		/// <summary>
        /// 検品照会情報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 検品照会情報アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
		/// </remarks>
        private InspectInfoAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this.IHandyInspectRefDataDBAdapter = (IHandyInspectRefDataDB)MediationHandyInspectRefDataDB.GetHandyInspectRefDataDB();
                // 従業員アクセスクラスを初期化します。
                this.EmployeeAccessor = new EmployeeAcs();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this.IHandyInspectRefDataDBAdapter = null;
            }
		}

        /// <summary>
        /// 検品照会情報アクセスクラスのシングルトンインスタンス取得処理
        /// </summary>
        /// <returns>検品照会情報アクセスクラスのシングルトンインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 検品照会情報アクセスクラスのシングルトンインスタンスを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public static InspectInfoAcs GetInstance()
        {
            if (InspectInfoAccessor == null)
            {
                InspectInfoAccessor = new InspectInfoAcs();
            }

            return InspectInfoAccessor;
        }
		# endregion

        # region public
        /// <summary>
        /// 検品照会情報リストの取得処理
        /// </summary>
        /// <param name="handyInspectParamWork">検索パラメータ</param>
        /// <param name="handyInspectDataList">検品照会情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品照会情報リストを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        public int Search(HandyInspectParamWork handyInspectParamWork, out ArrayList handyInspectDataList)
		{
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string ErrMsg = string.Empty;
            object HandyInspectResultObj = null;
            handyInspectDataList = new ArrayList();

            object HandyInspectParamObj = (object)handyInspectParamWork;

            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            try
            {
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                Status = this.IHandyInspectRefDataDBAdapter.Search(out HandyInspectResultObj, HandyInspectParamObj, out ErrMsg);
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            }
            catch (OutOfMemoryException)
            {
                Status = -100; // OutOfMemoryException
            }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                handyInspectDataList = HandyInspectResultObj as ArrayList;
            }
            return Status;
        }

        /// <summary>
        /// 検品照会情報の登録処理
        /// </summary>
        /// <param name="delHandyInspectDataList">先行検品データ物理削除データ</param>
        /// <param name="handyInspectDataList">検品登録データ</param>
        /// <param name="mode">0:手動検品データ登録処理,1:先行検品引当登録処理</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品照会情報の登録処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int WriteInspectData(ArrayList delHandyInspectDataList, ArrayList handyInspectDataList, int mode)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object DelHandyInspectDataObj = null;
            try
            {
                if (delHandyInspectDataList != null && delHandyInspectDataList.Count > 0)
                {
                    DelHandyInspectDataObj = (object)delHandyInspectDataList;
                }
                object HandyInspectDataObj = (object)handyInspectDataList;
                // 検品引当登録処理
                Status = this.IHandyInspectRefDataDBAdapter.WriteInspectData(DelHandyInspectDataObj, HandyInspectDataObj, mode);
            }
            catch
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return Status;
        }

        /// <summary>
        /// 検品ガイドデータの取得処理
        /// </summary>
        /// <param name="handyInspectParamWork">検索パラメータ</param>
        /// <param name="handyInspectDataList">検品データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品ガイドデータを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int SearchGuid(HandyInspectDataWork handyInspectParamWork, out ArrayList handyInspectDataList)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object InspectDataObj = null;
            handyInspectDataList = new ArrayList();
            try
            {
                object HandyInspectParamObj = (object)handyInspectParamWork;

                Status = this.IHandyInspectRefDataDBAdapter.SearchGuid(HandyInspectParamObj, out InspectDataObj);
                handyInspectDataList = InspectDataObj as ArrayList;
            }
            catch
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return Status;
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        /// <summary>
        /// 検品照会情報の削除処理
        /// </summary>
        /// <param name="delInspectDataObj">削除パラメータ</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品照会情報を削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2019/10/16</br>
        /// </remarks>
        public int DeleteInspectData(object delInspectDataObj, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            message = string.Empty;

            status = this.IHandyInspectRefDataDBAdapter.DeleteInspectData(delInspectDataObj, out message);

            return status;
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
        # endregion

        #region 従業員マスタ読込
        /// <summary>
        /// 従業員マスタ読込処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int ReadEmployee()
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            this.EmployeeDic = new Dictionary<string, string>();

            try
            {
                ArrayList RetList;
                ArrayList RetList2;
                Status = this.EmployeeAccessor.Search(out RetList, out RetList2, LoginInfoAcquisition.EnterpriseCode);
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Employee EmployeeWork in RetList)
                    {
                        if (EmployeeWork.LogicalDeleteCode == 0)
                        {
                            this.EmployeeDic.Add(EmployeeWork.EmployeeCode.Trim().PadLeft(4, '0'), EmployeeWork.Name.Trim());
                        }
                    }
                }
            }
            catch
            {
                // 処理なし
            }

            return Status;
        }
        #endregion 従業員マスタ読込

        #region 従業員名称取得
        /// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 従業員名称を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public string GetEmployeeName(string employeeCode)
        {
            string EmployeeName = string.Empty;

            if (this.EmployeeDic.ContainsKey(employeeCode.Trim().PadLeft(4, '0')))
            {
                EmployeeName = this.EmployeeDic[employeeCode.Trim().PadLeft(4, '0')];
            }

            return EmployeeName;
        }
        #endregion 従業員名称取得
    }
}
