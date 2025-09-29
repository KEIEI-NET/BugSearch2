//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
//TODO:買掛オプションなしフラグ（デバッグ用）※リリース時には未定義状態にすること！
//#define HASNOT_STOCKING_PAYMENT_OPTION

using System;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ログイン担当者クラス
    /// </summary>
    public sealed class LoginWorker
    {
        #region <企業プロフィール/>

        /// <summary>企業プロフィール</summary>
        private readonly CodeNamePair<string> _enterpriseProfile;
        /// <summary>
        /// 企業プロフィールを取得します。
        /// </summary>
        /// <value>企業プロフィール</value>
        public CodeNamePair<string> EnterpriseProfile { get { return _enterpriseProfile; } }

        #endregion  // <企業プロフィール/>

        #region <従業員情報/>

        /// <summary>従業員情報</summary>
        private readonly Employee _profile;
        /// <summary>
        /// 従業員情報を取得します。
        /// </summary>
        public Employee Profile { get { return _profile; } }

        /// <summary>従業員情報の詳細</summary>
        private EmployeeDtl _detail;
        /// <summary>
        /// 従業員情報の詳細を取得します。
        /// </summary>
        /// <value>従業員情報の詳細</value>
        public EmployeeDtl Detail
        {
            get
            {
                if (_detail == null)
                {
                    _detail = GetEmployeeDtl(EnterpriseProfile.Code, Profile.EmployeeCode);
                }
                return _detail;
            }
        }
         
        /// <summary>
        /// 従業員情報の詳細を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員情報の詳細</returns>
        private static EmployeeDtl GetEmployeeDtl(
            string enterpriseCode,
            string employeeCode
        )
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            {
                Employee    employee    = null;
                EmployeeDtl employeeDtl = null;
                int status = employeeAcs.Read(
                    out employee,
                    out employeeDtl,
                    enterpriseCode,
                    employeeCode
                );
                if (employeeDtl == null)
                {
                    employeeDtl = new EmployeeDtl();
                }
                return employeeDtl;
            }
        }

        #endregion  // <従業員情報/>

        #region <買掛オプション/>

        /// <summary>買掛オプションありフラグ</summary>
        private readonly bool _hasStockingPaymentOption;
        /// <summary>
        /// 買掛オプションありフラグを取得します。
        /// </summary>
        /// <value>
        /// <c>true </c>:買掛オプションあり<br/>
        /// <c>false</c>:買掛オプションなし
        /// </value>
        public bool HasStockingPaymentOption
        {
            get
            {
            #if HASNOT_STOCKING_PAYMENT_OPTION
                return false;
            #else
                return _hasStockingPaymentOption;
            #endif
            }
        }

        /// <summary>
        /// 買掛管理ありか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :買掛管理あり<br/>
        /// <c>false</c>:買掛管理なし
        /// </returns>
        private static bool HasStockingPayment()
        {
            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment
            );
            return purchaseStatus >= PurchaseStatus.Contract;
        }

        #endregion  // <買掛オプション/>

        #region <端末番号/>

        /// <summary>端末番号</summary>
        private readonly int _cashRegisterNo;
        /// <summary>
        /// 端末番号を取得します。
        /// </summary>
        /// <value>端末番号</value>
        public int CashRegisterNo { get { return _cashRegisterNo; } }

        /// <summary>
        /// 端末番号を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        private static int GetCashRegisterNo(string enterpriseCode)
        {
            int cashRegisterNo = 0;

            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            {
                int status = posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, enterpriseCode);
                if (!status.Equals((int)Result.RemoteStatus.Normal))
                {
                    cashRegisterNo = 0;
                }
            }

            return cashRegisterNo;
        }

        #endregion  // <端末番号/>

        #region <拠点設定/>

        /// <summary>拠点設定</summary>
        private SecInfoSet _sectionInfo;
        /// <summary>
        /// 拠点設定を取得します。
        /// </summary>
        /// <value>拠点設定</value>
        public SecInfoSet SectionInfo
        {
            get
            {
                if (_sectionInfo == null)
                {
                    _sectionInfo = GetSectionInfo(EnterpriseProfile.Code, SectionProfile.Code);
                }
                return _sectionInfo;
            }
        }

        /// <summary>
        /// 拠点設定マスタを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点設定マスタ情報</returns>
        private static SecInfoSet GetSectionInfo(
            string enterpriseCode,
            string sectionCode
        )
        {
            ArrayList secInfoSetList = new ArrayList();

            SecInfoSetAcs sectionInfoAcs = new SecInfoSetAcs();
            int status = sectionInfoAcs.Search(out secInfoSetList, enterpriseCode);
            if (!status.Equals((int)Result.RemoteStatus.Normal) || secInfoSetList == null)
            {
                return new SecInfoSet();
            }

            foreach (SecInfoSet sectionInfo in secInfoSetList)
            {
                if (sectionInfo.SectionCode.Trim().Equals(sectionCode.Trim()))
                {
                    return sectionInfo;
                }
            }

            return new SecInfoSet();
        }

        #endregion  // <拠点設定/>

        #region <UOE自社設定/>

        /// <summary>
        /// 卸商入庫更新区分列挙体
        /// </summary>
        public enum OroshishoDistEnterDiv : int
        {
            /// <summary>自動</summary>
            Auto = 0,
            /// <summary>手動</summary>
            Manual = 1
        }

        /// <summary>
        /// 卸商拠点設定区分列挙体
        /// </summary>
        public enum OroshishoDistSectionSetDiv : int
        {
            /// <summary>仕入マスタ</summary>
            SupplierMaster = 0,
            /// <summary>発注データ</summary>
            OrderData = 1,
            /// <summary>自社マスタ</summary>
            UOESettingMaster = 2
        }

        /// <summary>UOE自社設定</summary>
        private UOESetting _uoeSetting;
        /// <summary>
        /// UOE自社設定を取得します。
        /// </summary>
        public UOESetting UOESetting
        {
            get
            {
                if (_uoeSetting == null)
                {
                    _uoeSetting = GetUOESetting(EnterpriseProfile.Code, SectionProfile.Code);
                }
                return _uoeSetting;
            }
        }

        /// <summary>
        /// UOE自社設定マスタ情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>UOE自社設定マスタ情報</returns>
        private static UOESetting GetUOESetting(
            string enterpriseCode,
            string sectionCode
        )
        {
            UOESetting uoeSetting = null;

            // UOE自社設定マスタを検索
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            int status = uoeSettingAcs.Read(out uoeSetting, enterpriseCode, sectionCode);
            if (!status.Equals((int)Result.RemoteStatus.Normal))
            {
                return null;
            }

            return uoeSetting;
        }

        #endregion  // <UOE自社設定/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public LoginWorker()
        {
            // 企業プロフィール
            _enterpriseProfile = new CodeNamePair<string>(
                LoginInfoAcquisition.EnterpriseCode.Trim(),
                LoginInfoAcquisition.EnterpriseName.Trim()
            );

            // 従業員情報
            _profile = LoginInfoAcquisition.Employee.Clone();

            // 買掛オプション
            _hasStockingPaymentOption = HasStockingPayment();

            // 端末番号
            _cashRegisterNo = GetCashRegisterNo(LoginInfoAcquisition.EnterpriseCode.Trim());
        }

        #endregion  // <Constructor/>

        #region <拠点プロフィール/>

        /// <summary>
        /// 拠点プロフィールを取得します。
        /// </summary>
        /// <value>拠点コードおよび拠点名称</value>
        public CodeNamePair<string> SectionProfile
        {
            get
            {
                return new CodeNamePair<string>(
                    Profile.BelongSectionCode.Trim(),
                    Profile.BelongSectionName.Trim()
                );
            }
        }

        #endregion  // <拠点プロフィール/>
    }
}
