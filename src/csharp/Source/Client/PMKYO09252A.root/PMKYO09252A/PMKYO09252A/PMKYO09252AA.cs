//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理接続先設定マスタメンテナンス
// プログラム概要   : 拠点管理接続先設定マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Microsoft.Win32;
using Broadleaf.Library.Resources;
using System.Security;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注点設定マスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点管理接続先設定マスタメンテナンスのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.04.23</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class SecMngConnectStAcs
    {
        # region -- リモートオブジェクト格納バッファ --
        private ISecMngConnectStDB _iSecMngConnectStDB = null;
        # endregion

        # region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public SecMngConnectStAcs()
        {
            // リモートオブジェクト取得
            this._iSecMngConnectStDB = (ISecMngConnectStDB)MediationSecMngConnectStDB.GetSecMngConnectStDB();
        }
        # endregion

        # region -- 検索処理 --
        /// <summary>拠点管理接続先設定マスタ読み処理</summary>
        /// <param name="secMngConnectSt">拠点管理接続先設定マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 接続先設定マスタを読み込みます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Search(out SecMngConnectSt secMngConnectSt, string enterpriseCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            secMngConnectSt = null;

            SecMngConnectStWork secMngConnectStWork = new SecMngConnectStWork();
            ArrayList resList = new ArrayList();
            try
            {
                secMngConnectStWork.EnterpriseCode = enterpriseCode;
                secMngConnectStWork.SectionCode = "0";

                object objResList = new object();

                //読みDBのデータ
                status = this._iSecMngConnectStDB.Search(out objResList, secMngConnectStWork, 0, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    resList = objResList as ArrayList;

                    SecMngConnectStWork resWork = (SecMngConnectStWork)resList[0];
                    // クラス内メンバコピー
                    secMngConnectSt = CopyToSecMngConnectStFromSecMngConnectStWork(resWork);
                }
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>レジストリ読み処理</summary>
        /// <param name="secMngConnectSt">拠点管理接続先設定マスタオブジェクト</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : レジストリを読み込みます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int GetRegistryKey(out SecMngConnectSt secMngConnectSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            secMngConnectSt = new SecMngConnectSt();

            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 == null)
                {
                    rKey1 = Registry.LocalMachine.CreateSubKey(rKeyName1);
                }

                if (rKey2 == null)
                {
                    rKey2 = Registry.LocalMachine.CreateSubKey(rKeyName2);
                }

                if (rKey1 != null && rKey2 != null)
                {
                    // レジストリ取込
                    string apServerIpAddress = rKey1.GetValue("%Domain%").ToString();
                    string sbServerIpAddress = rKey2.GetValue("%DataSource%").ToString();
                    secMngConnectSt.ApServerIpAddress = apServerIpAddress;
                    secMngConnectSt.DbServerIpAddress = sbServerIpAddress;
                }
            }
            catch (IOException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (SecurityException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /// <summary>接続先設定マスタ登録・更新処理</summary>
        /// <param name="secMngConnectSt">接続先設定マスタクラス</param>
        /// <returns>更新結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 接続先設定マスタの登録・更新を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Write(ref SecMngConnectSt secMngConnectSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SecMngConnectStWork secMngConnectStWork = CopyToSecMngConnectStWorkFromSecMngConnectSt(secMngConnectSt);

            try
            {
                object objSecMngConnectStWork = secMngConnectStWork;

                // サーバー用接続先更新処理
                status = this._iSecMngConnectStDB.UpdateRegistryKeyValue(ref objSecMngConnectStWork);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 実行端末（自端末）のレジストリを更新する。
                    status = this.UpdateRegistryKeyValue(ref secMngConnectStWork);
                }

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 拠点管理接続先マスタ更新処理
                    status = this._iSecMngConnectStDB.Write(ref objSecMngConnectStWork);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    secMngConnectStWork = objSecMngConnectStWork as SecMngConnectStWork;
                    secMngConnectSt = CopyToSecMngConnectStFromSecMngConnectStWork(secMngConnectStWork);
                }
            }
            catch (Exception)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// レジストリのキー項目を更新処理(実行端末（自端末）)
        /// </summary>
        /// <remarks>
        /// <param name="secMngConnectStWork">接続先設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : レジストリのキー項目を更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int UpdateRegistryKeyValue(ref SecMngConnectStWork secMngConnectStWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 == null)
                {
                    rKey1 = Registry.LocalMachine.CreateSubKey(rKeyName1);
                }

                if (rKey2 == null)
                {
                    rKey2 = Registry.LocalMachine.CreateSubKey(rKeyName2);
                }

                if (rKey1 != null && rKey2 != null)
                {
                    rKey1.SetValue("%Domain%", secMngConnectStWork.ApServerIpAddress, RegistryValueKind.String);
                    rKey2.SetValue("%DataSource%", secMngConnectStWork.DbServerIpAddress, RegistryValueKind.String);

                    // 既に%RequiredServerVersion%が存在時には更新対象外
                    if (rKey1.GetValue("RequiredServerVersion") == null)
                    {
                        rKey1.SetValue("RequiredServerVersion", "0", RegistryValueKind.DWord);
                    }
                }
            }
            catch (IOException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (SecurityException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（接続先設定マスタワーククラス⇒接続先設定マスタクラス）
        /// </summary>
        /// <param name="secMngConnectStWork">発注点設定マスタワーククラス</param>
        /// <returns>接続先設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 接続先設定マスタワーククラスから接続先設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private SecMngConnectSt CopyToSecMngConnectStFromSecMngConnectStWork(SecMngConnectStWork secMngConnectStWork)
        {
            SecMngConnectSt secMngConnectSt = new SecMngConnectSt();

            secMngConnectSt.CreateDateTime = secMngConnectStWork.CreateDateTime;
            secMngConnectSt.UpdateDateTime = secMngConnectStWork.UpdateDateTime;
            secMngConnectSt.EnterpriseCode = secMngConnectStWork.EnterpriseCode;
            secMngConnectSt.FileHeaderGuid = secMngConnectStWork.FileHeaderGuid;
            secMngConnectSt.UpdEmployeeCode = secMngConnectStWork.UpdEmployeeCode;
            secMngConnectSt.UpdAssemblyId1 = secMngConnectStWork.UpdAssemblyId1;
            secMngConnectSt.UpdAssemblyId2 = secMngConnectStWork.UpdAssemblyId2;
            secMngConnectSt.LogicalDeleteCode = secMngConnectStWork.LogicalDeleteCode;
            secMngConnectSt.SectionCode = secMngConnectStWork.SectionCode;
            secMngConnectSt.ConnectPointDiv = secMngConnectStWork.ConnectPointDiv;
            secMngConnectSt.ApServerIpAddress = secMngConnectStWork.ApServerIpAddress;
            secMngConnectSt.DbServerIpAddress = secMngConnectStWork.DbServerIpAddress;

            return secMngConnectSt;
        }

        /// <summary>クラスメンバーコピー処理（接続先設定マスタクラス⇒接続先設定マスタワーククラス）</summary>
        /// <param name="secMngConnectSt">接続先設定マスタワーククラス</param>
        /// <returns>接続先設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 接続先設定マスタクラスから接続先設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private SecMngConnectStWork CopyToSecMngConnectStWorkFromSecMngConnectSt(SecMngConnectSt secMngConnectSt)
        {
            SecMngConnectStWork secMngConnectStWork = new SecMngConnectStWork();

            secMngConnectStWork.CreateDateTime = secMngConnectSt.CreateDateTime;
            secMngConnectStWork.UpdateDateTime = secMngConnectSt.UpdateDateTime;
            secMngConnectStWork.EnterpriseCode = secMngConnectSt.EnterpriseCode;
            secMngConnectStWork.FileHeaderGuid = secMngConnectSt.FileHeaderGuid;
            secMngConnectStWork.UpdEmployeeCode = secMngConnectSt.UpdEmployeeCode;
            secMngConnectStWork.UpdAssemblyId1 = secMngConnectSt.UpdAssemblyId1;
            secMngConnectStWork.UpdAssemblyId2 = secMngConnectSt.UpdAssemblyId2;
            secMngConnectStWork.LogicalDeleteCode = secMngConnectSt.LogicalDeleteCode;
            secMngConnectStWork.SectionCode = secMngConnectSt.SectionCode;
            secMngConnectStWork.ConnectPointDiv = secMngConnectSt.ConnectPointDiv;
            secMngConnectStWork.ApServerIpAddress = secMngConnectSt.ApServerIpAddress;
            secMngConnectStWork.DbServerIpAddress = secMngConnectSt.DbServerIpAddress;

            return secMngConnectStWork;
        }
        # endregion
    }
}