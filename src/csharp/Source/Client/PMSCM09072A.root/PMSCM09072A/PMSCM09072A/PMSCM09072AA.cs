//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   売上連携設定テーブルアクセスクラス            //
//                  :   PMSCM09072A.DLL                               //
// Name Space       :   Broadleaf.Application.Controller              //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using System.Runtime.Remoting;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上連携設定テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上連携設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer       :   gaoy</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PM7RkSettingAcs
    {
        #region << Private Members >>

        //リモートオブジェクト格納バッファ
        private IPM7RkSettingDB _iPM7RkSettingDB = null;


        #endregion

        #region << Conductor >>

        public PM7RkSettingAcs()
        {
            try{
                // リモートオブジェクト取得
                this._iPM7RkSettingDB = (IPM7RkSettingDB)MediationPM7RkSettingDB.GetPM7RkSettingDB();
            }
            catch(Exception)
            {
                // オフライン時はnullをセット
                this._iPM7RkSettingDB = null;
            }
        }

        #endregion

        #region << Read Methods >>

        /// <summary>
        /// 売上連携設定読み込み処理 (通常)
        /// </summary>
        /// <param name="pm7RkSetting">売上連携設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上連携設定の読み込みを行います。</br>
        /// <br>Programmer       :   gaoy</br>
        /// <br>Date             :   2011/7/22</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public int Read(ref PM7RkSetting pm7RkSetting)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                PM7RkSettingWork pm7RkSettingWork = new PM7RkSettingWork();

                pm7RkSettingWork.EnterpriseCode = pm7RkSetting.EnterpriseCode;
                pm7RkSettingWork.SectionCode = pm7RkSetting.SectionCode;

                ArrayList pm7RkSettingArray = new ArrayList();
                pm7RkSettingArray.Add(pm7RkSettingWork);
                try
                {
                    status = this._iPM7RkSettingDB.Read(ref pm7RkSettingArray, 0);
                }
                catch (RemotingException)
                {
                    status = 10;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pm7RkSettingWork = (PM7RkSettingWork)pm7RkSettingArray[0];

                    if (pm7RkSettingWork != null)
                    {
                        pm7RkSetting = this.CopyToPM7RkSettingFromPM7RkSettingWork(pm7RkSettingWork);
                    }
                }
            }
            catch (Exception)
            {
                pm7RkSetting = null;
                this._iPM7RkSettingDB = null;
            }

            return status;
        }

        #endregion

        #region << Write Methods >>

        /// <summary>
        /// 売上連携設定書き込み処理 (通常)
        /// </summary>
        /// <param name="pm7RkSetting">売上連携設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上連携設定の書き込みを行います。</br>
        /// <br>Programmer       :   gaoy</br>
        /// <br>Date             :   2011/7/22</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public int Write(ref PM7RkSetting pm7RkSetting)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                PM7RkSettingWork pm7RkSettingWork = this.CopyToPM7RkSettingWorkFromPM7RkSetting(pm7RkSetting);

                byte[] parabyte = XmlByteSerializer.Serialize(pm7RkSettingWork);
                try
                {
                    status = this._iPM7RkSettingDB.Write(ref parabyte);
                }
                catch(Exception)
                {
                    status = -1;
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pm7RkSettingWork = (PM7RkSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(PM7RkSettingWork));
                    pm7RkSetting = this.CopyToPM7RkSettingFromPM7RkSettingWork(pm7RkSettingWork);
                }
            }
            catch (Exception)
            {
                this._iPM7RkSettingDB = null;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        #endregion

        #region << Class Member Copy Methods >>

        /// <summary>
        /// クラスメンバコピー処理（売上連携設定クラス→売上連携設定ワーククラス）
        /// </summary>
        /// <param name="alItmDspNm">売上連携設定クラス</param>
        /// <returns>売上連携設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 売上連携設定クラスから売上連携設定ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private PM7RkSettingWork CopyToPM7RkSettingWorkFromPM7RkSetting(PM7RkSetting pm7RkSetting)
        {
            PM7RkSettingWork pm7RkSettingWork = new PM7RkSettingWork();

            pm7RkSettingWork.CreateDateTime = pm7RkSetting.CreateDateTime;           //作成日時
            pm7RkSettingWork.UpdateDateTime = pm7RkSetting.UpdateDateTime;           //更新日時
            pm7RkSettingWork.EnterpriseCode = pm7RkSetting.EnterpriseCode;           //企業コード
            pm7RkSettingWork.FileHeaderGuid = pm7RkSetting.FileHeaderGuid;           //GUID
            pm7RkSettingWork.UpdEmployeeCode = pm7RkSetting.UpdEmployeeCode;         //更新従業員コード
            pm7RkSettingWork.UpdAssemblyId1 = pm7RkSetting.UpdAssemblyId1;           //更新アセンブリID1
            pm7RkSettingWork.UpdAssemblyId2 = pm7RkSetting.UpdAssemblyId2;           //更新アセンブリID2
            pm7RkSettingWork.LogicalDeleteCode = pm7RkSetting.LogicalDeleteCode;     //論理削除区分
            pm7RkSettingWork.SectionCode = pm7RkSetting.SectionCode;                 //拠点コード

            pm7RkSettingWork.SalesRkAutoCode = pm7RkSetting.SalesRkAutoCode;         //売上連携自動区分
            pm7RkSettingWork.SalesRkAutoSndTime = pm7RkSetting.SalesRkAutoSndTime;   //売上連携自動送信間隔
            pm7RkSettingWork.MasterRkAutoCode = pm7RkSetting.MasterRkAutoCode;       //マスタ連携自動区分
            pm7RkSettingWork.MasterRkAutoRcvTime = pm7RkSetting.MasterRkAutoRcvTime; //マスタ連携自動受信間隔
            pm7RkSettingWork.TextSaveFolder = pm7RkSetting.TextSaveFolder;                   //テキスト格納フォルダ

            return pm7RkSettingWork;
        }

        /// <summary>
        /// クラスメンバコピー処理（売上連携設定ワーククラス→売上連携設定クラス）
        /// </summary>
        /// <param name="alItmDspNm">売上連携設定ワーククラス</param>
        /// <returns>売上連携設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 売上連携設定ワーククラスから売上連携設定クラスへメンバコピーを行います。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private PM7RkSetting CopyToPM7RkSettingFromPM7RkSettingWork(PM7RkSettingWork pm7RkSettingWork)
        {
            PM7RkSetting pm7RkSetting = new PM7RkSetting();

            pm7RkSetting.CreateDateTime = pm7RkSettingWork.CreateDateTime;           //作成日時
            pm7RkSetting.UpdateDateTime = pm7RkSettingWork.UpdateDateTime;           //更新日時
            pm7RkSetting.EnterpriseCode = pm7RkSettingWork.EnterpriseCode;           //企業コード
            pm7RkSetting.FileHeaderGuid = pm7RkSettingWork.FileHeaderGuid;           //GUID
            pm7RkSetting.UpdEmployeeCode = pm7RkSettingWork.UpdEmployeeCode;         //更新従業員コード
            pm7RkSetting.UpdAssemblyId1 = pm7RkSettingWork.UpdAssemblyId1;           //更新アセンブリID1
            pm7RkSetting.UpdAssemblyId2 = pm7RkSettingWork.UpdAssemblyId2;           //更新アセンブリID2
            pm7RkSetting.LogicalDeleteCode = pm7RkSettingWork.LogicalDeleteCode;     //論理削除区分
            pm7RkSetting.SectionCode = pm7RkSettingWork.SectionCode;                 //拠点コード

            pm7RkSetting.SalesRkAutoCode = pm7RkSettingWork.SalesRkAutoCode;         //売上連携自動区分
            pm7RkSetting.SalesRkAutoSndTime = pm7RkSettingWork.SalesRkAutoSndTime;   //売上連携自動送信間隔
            pm7RkSetting.MasterRkAutoCode = pm7RkSettingWork.MasterRkAutoCode;       //マスタ連携自動区分
            pm7RkSetting.MasterRkAutoRcvTime = pm7RkSettingWork.MasterRkAutoRcvTime; //マスタ連携自動受信間隔
            pm7RkSetting.TextSaveFolder = pm7RkSettingWork.TextSaveFolder;                   //テキスト格納フォルダ
            
            return pm7RkSetting;
        }

        #endregion

    }
}
