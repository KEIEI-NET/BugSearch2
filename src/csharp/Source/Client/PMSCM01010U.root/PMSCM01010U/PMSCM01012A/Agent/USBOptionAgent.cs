//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11170206-00 作成担当 : 顧棟
// 作 成 日  2016/01/13  修正内容 : Redmine#47845とRedmine#47847 2016年2月配信分
//                                : フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// USBのオプションアクセスの代理人クラス
    /// </summary>
    public sealed class USBOptionAgent
    {
        /// <summary>
        /// オプション有効有無列挙型
        /// </summary>
        public enum OptionFlag : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }

        // --- ADD 2016/01/13 顧棟 Redmine#47845とRedmine#47847 フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する ----->>>>>
        #region <フタバ倉庫引当てオプション>

        /// <summary>フタバ倉庫引当てオプション</summary>
        private int _futabaWarehAlloc = -1;
        /// <summary>フタバ倉庫引当てオプションを取得します。</summary>
        public int FutabaWarehAllocOption
        {
            get
            {
                if (_futabaWarehAlloc < 0)
                {
                    _futabaWarehAlloc = GetFutabaWarehAllocOption();
                }
                return _futabaWarehAlloc;
            }
        }

        /// <summary>
        /// フタバ倉庫引当てオプションが有効か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public bool EnabledFutabaWarehAllocOption()
        {
            return FutabaWarehAllocOption.Equals((int)OptionFlag.ON);
        }

        /// <summary>
        /// フタバ倉庫引当てオプションを取得します。
        /// </summary>
        /// <returns>フタバ倉庫引当てオプション</returns>
        private static int GetFutabaWarehAllocOption()
        {
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc
           );
            return status.Equals(PurchaseStatus.Contract) ? (int)OptionFlag.ON : (int)OptionFlag.OFF;
        }

        #endregion // </フタバ倉庫引当てオプション>
        // --- ADD 2016/01/13 顧棟 Redmine#47845とRedmine#47847 フタバ倉庫引当てオプション  （個別）：OPT-CPM0100を追加する -----<<<<<

        #region <車両管理オプション>

        /// <summary>車両管理オプション</summary>
        private int _carManagementOption = -1;
        /// <summary>車両管理オプションを取得します。</summary>
        public int CarManagementOption
        {
            get
            {
                if (_carManagementOption < 0)
                {
                    _carManagementOption = GetCarManagementOption();
                }
                return _carManagementOption;
            }
        }

        /// <summary>
        /// 車両管理オプションが有効か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public bool EnabledCarManagementOption()
        {
            return CarManagementOption.Equals((int)OptionFlag.ON);
        }

        /// <summary>
        /// 車両管理オプションを取得します。
        /// </summary>
        /// <remarks>MAHNB01012AD.cs SalesSlipInitDataAcs.CacheOptionInfo() 1886行目より移植</remarks>
        /// <returns>車両管理オプション</returns>
        private static int GetCarManagementOption()
        {
             PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                 ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng
            );
            return status.Equals(PurchaseStatus.Contract) ? (int)OptionFlag.ON : (int)OptionFlag.OFF;
        }

        #endregion // </車両管理オプション>

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        #region <BLP参照倉庫追加オプション>

        /// <summary>BLP参照倉庫追加オプション</summary>
        private int _BLPPriWarehouseOption = -1;
        /// <summary>BLP参照倉庫追加オプションを取得します。</summary>
        public int BLPPriWarehouseOption
        {
            get
            {
                _BLPPriWarehouseOption = GetBLPPriWarehouseOption();
                return _BLPPriWarehouseOption;
            }
        }

        /// <summary>
        /// BLP参照倉庫追加オプションが有効か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public bool EnabledBLPPriWarehouseOption()
        {
            return BLPPriWarehouseOption.Equals((int)OptionFlag.ON);
        }
        /// <summary>
        /// BLP参照倉庫追加オプションを取得します。
        /// </summary>
        /// <remarks></remarks>
        /// <returns>BLP参照倉庫追加オプション</returns>
        private static int GetBLPPriWarehouseOption()
        {
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse
           );
            return status.Equals(PurchaseStatus.Contract) ? (int)OptionFlag.ON : (int)OptionFlag.OFF;
        }

        #endregion // </BLP参照倉庫追加オプション>

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public USBOptionAgent() { }

        #endregion // </Constructor>
    }
}
