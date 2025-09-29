//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// UOE発注先のヘルパクラス
    /// </summary>
    public class UOESupplierHelper
    {
        #region <本物/>

        /// <summary>本物のUOE発注先</summary>
        private readonly UOESupplier _realUOESupplier;
        /// <summary>
        /// 本物のUOE発注先を取得します。
        /// </summary>
        public UOESupplier RealUOESupplier { get { return _realUOESupplier; } }

        #endregion  // <本物/>

        #region <企業プロフィール/>

        /// <summary>企業プロフィール</summary>
        private readonly CodeNamePair<string> _enterpriseProfile;
        /// <summary>
        /// 企業プロフィールを取得します。
        /// </summary>
        /// <value>企業コードおよび名称</value>
        public CodeNamePair<string> EnterpriseProfile { get { return _enterpriseProfile; } }

        #endregion  // <企業プロフィール/>

        #region <依頼者/>

        /// <summary>依頼者プロフィール</summary>
        private readonly CodeNamePair<string> _agentProfile;
        /// <summary>
        /// 依頼者プロフィールを取得します。
        /// </summary>
        /// <value>従業員コードおよび名称</value>
        public CodeNamePair<string> AgentProfile { get { return _agentProfile; } }

        /// <summary>
        /// 従業員のプロフィールを生成します。
        /// </summary>
        /// <param name="enterpriseCide">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員コードおよび名称</returns>
        private static CodeNamePair<string> CreateEmployeeProfile(
            string enterpriseCide,
            string employeeCode
        )
        {
            ArrayList searchedEmployeeList = null;
            {
                EmployeeAcs employeeAcs = new EmployeeAcs();
                {
                    ArrayList searchedEmployeeDetailedList = null;
                    int status = employeeAcs.Search(
                        out searchedEmployeeList,
                        out searchedEmployeeDetailedList,
                        enterpriseCide
                    );
                    if (searchedEmployeeList == null || searchedEmployeeList.Count.Equals(0))
                    {
                        return new CodeNamePair<string>(string.Empty, string.Empty);
                    }
                }
            }

            Employee foundEmployee = null;
            {
                foreach (Employee searchedEmployee in searchedEmployeeList)
                {
                    if (searchedEmployee.EmployeeCode.Trim().Equals(employeeCode.Trim()))
                    {
                        foundEmployee = searchedEmployee;
                        break;
                    }
                }
            }
            if (foundEmployee != null)
            {
                return new CodeNamePair<string>(employeeCode, foundEmployee.Name);
            }
            else
            {
                return new CodeNamePair<string>(string.Empty, string.Empty);
            }
        }

        #endregion  // <依頼者/>

        #region <電文の生成者/>

        /// <summary>電文の生成者</summary>
        private SendingStockReceptionTelegramEssence _telegramEssence;
        /// <summary>
        /// 電文の生成者を取得します。
        /// </summary>
        public SendingStockReceptionTelegramEssence TelegramEssence { get { return _telegramEssence; } }

        #endregion  // <電文の生成者/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realUOESupplier">本物のUOE発注先</param>
        /// <param name="enterpriseProfile">企業プロフィール</param>
        public UOESupplierHelper(
            UOESupplier realUOESupplier,
            CodeNamePair<string> enterpriseProfile
        )
        {
            // 本物のUOE発注先
            _realUOESupplier = realUOESupplier;
            {
                // ID番号に値が設定されていると、電文送信処理にて、ID交換処理が行われる
                // →卸商仕入受信では、ID交換処理は行わない
                _realUOESupplier.UOEIDNum = string.Empty;
            }

            // 企業プロフィール
            _enterpriseProfile = enterpriseProfile;

            // 依頼者
            if (string.IsNullOrEmpty(_realUOESupplier.EmployeeCode.Trim()))
            {
                _agentProfile = new CodeNamePair<string>(string.Empty, string.Empty);
            }
            else
            {
                _agentProfile = CreateEmployeeProfile(
                    _enterpriseProfile.Code,
                    _realUOESupplier.EmployeeCode.Trim()
                );
            }

            // 電文の生成者
            _telegramEssence = CreateTelegramEssence();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 接続バージョン区分が"新"であるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :新である<br/>
        /// <c>false</c>:新ではない
        /// </returns>
        public bool IsNewVersion()
        {
            const int NEW_VERSION = 1;  // 0:旧／1:新
            return RealUOESupplier.ConnectVersionDiv.Equals(NEW_VERSION);
        }

        /// <summary>
        /// 仕入受信処理が行えるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :行える。<br/>
        /// <c>false</c>:行えない。
        /// </returns>
        public virtual bool CanReceiveStoking()
        {
            return UOESupplierUtil.HasStockSlipData(RealUOESupplier.StockSlipDtRecvDiv);
        }

        /// <summary>
        /// 電文の生成者を生成します。
        /// </summary>
        /// <value>電文の生成者</value>
        protected virtual SendingStockReceptionTelegramEssence CreateTelegramEssence()
        {
            return new SendingStockReceptionTelegramEssence(
                RealUOESupplier.CommAssemblyId,
                RealUOESupplier.UOESupplierCd,
                RealUOESupplier.UOEHostCode,
                RealUOESupplier.UOEConnectPassword,
                this
            );
        }

        /// <summary>
        /// 卸商仕入受信処理のUOE発注先種別を取得します。
        /// </summary>
        /// <value>卸商仕入受信処理のUOE発注先種別</value>
        public virtual EnumUoeConst.ReceivingUOESupplier ReceivingUOESupplierType
        {
            get { return EnumUoeConst.ReceivingUOESupplier.SPK; }
        }

        /// <summary>
        /// 品番検索用のメーカーコード条件を生成します。
        /// </summary>
        /// <returns>品番検索用のメーカーコード条件</returns>
        public List<int> CreateSearchingMakerCodeListForGoodsAcs()
        {
            List<int> searchingMakerCodeList = new List<int>();
            {
                const int DISABLE_MAKER_CODE = 0;

                int enabledOdrMakerCd = DISABLE_MAKER_CODE;
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd1;
                            break;
                        case 1:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd2;
                            break;
                        case 2:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd3;
                            break;
                        case 3:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd4;
                            break;
                        case 4:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd5;
                            break;
                        case 5:
                            enabledOdrMakerCd = RealUOESupplier.EnableOdrMakerCd6;
                            break;
                    }
                    if (enabledOdrMakerCd.Equals(DISABLE_MAKER_CODE)) continue;

                    searchingMakerCodeList.Add(enabledOdrMakerCd);
                }
            }
            return searchingMakerCodeList;
        }
    }

    #region <SPK(その他)/>

    /// <summary>
    /// UOE発注先：SPK(その他)の装飾クラス
    /// </summary>
    public sealed class UOESPKDecorator : UOESupplierHelper
    {
        #region <UOE発注先/>

        /// <summary>UOE発注先</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        private UOESupplierHelper UOESupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE発注先/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public UOESPKDecorator(UOESupplierHelper uoeSupplier)
        : base(uoeSupplier.RealUOESupplier, uoeSupplier.EnterpriseProfile)
        {
            _uoeSupplier = uoeSupplier;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 仕入受信処理が行えるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :行える。<br/>
        /// <c>false</c>:行えない。
        /// </returns>
        /// <see cref="UOESupplierHelper"/>
        public override bool CanReceiveStoking()
        {
            // 仕入受信区分：あり && 受信有無区分：送受信可能
            return base.CanReceiveStoking()
                    &&
                RealUOESupplier.ReceiveCondition.Equals((int)UOESupplierUtil.ReceiveConditionDiv.CanSendAndReceive);
        }

        #endregion  // <Override/>
    }

    #endregion  // <SPK(その他)/>

    #region <明治産業/>

    /// <summary>
    /// UOE発注先：明治産業の装飾クラス
    /// </summary>
    public sealed class UOEMeijiDecorator : UOESupplierHelper
    {
        #region <UOE発注先/>

        /// <summary>UOE発注先</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        private UOESupplierHelper UOESupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE発注先/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public UOEMeijiDecorator(UOESupplierHelper uoeSupplier)
        : base(uoeSupplier.RealUOESupplier, uoeSupplier.EnterpriseProfile)
        {
            _uoeSupplier = uoeSupplier;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 仕入受信処理が行えるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :行える。<br/>
        /// <c>false</c>:行えない。
        /// </returns>
        /// <see cref="UOESupplierHelper"/>
        public override bool CanReceiveStoking()
        {
            // 仕入受信区分：あり && 受信有無区分：送信のみ
            return base.CanReceiveStoking()
                    &&
                RealUOESupplier.ReceiveCondition.Equals((int)UOESupplierUtil.ReceiveConditionDiv.SendOnly);
        }

        /// <summary>
        /// 電文の生成者を生成します。
        /// </summary>
        /// <returns>電文の生成者</returns>
        /// <see cref="UOESupplierHelper"/>
        protected override SendingStockReceptionTelegramEssence CreateTelegramEssence()
        {
            return new SendingStockReceptionTelegramEssence(
                RealUOESupplier.CommAssemblyId,
                RealUOESupplier.UOESupplierCd,
                " ",    // 明治産業の場合、ホストコードはスペース
                " ",    // 明治産業の場合、パスワードはスペース
                this,
                true    // 明治産業の場合、閉局電文は送信しない
            );
        }

        /// <summary>
        /// 卸商仕入受信処理の種別を取得します。
        /// </summary>
        /// <value>卸商仕入受信処理の種別</value>
        /// <see cref="UOESupplierHelper"/>
        public override EnumUoeConst.ReceivingUOESupplier ReceivingUOESupplierType
        {
            get { return EnumUoeConst.ReceivingUOESupplier.Meiji; }
        }

        #endregion  // <Override/>
    }

    #endregion  // <明治産業/>

    /// <summary>
    /// UOE発注先ユーティリティ
    /// </summary>
    public static class UOESupplierUtil
    {
        /// <summary>
        /// 受信状況（受信有無区分）列挙体
        /// </summary>
        public enum ReceiveConditionDiv : int
        {
            /// <summary>送受信可能</summary>
            CanSendAndReceive = 0,
            /// <summary>送信のみ</summary>
            SendOnly = 1
        }

        /// <summary>
        /// UOE発注先のヘルパを生成します。
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="enterpriseProfile">企業プロフィール（コードと名称）</param>
        /// <returns>UOE発注先のヘルパ</returns>
        public static UOESupplierHelper CreateHelper(
            UOESupplier uoeSupplier,
            CodeNamePair<string> enterpriseProfile
        )
        {
            // 条件1：仕入受信区分が有りなら、SPK(その他)か明治産業
            if (!HasStockSlipData(uoeSupplier.StockSlipDtRecvDiv))
            {
                return new UOESupplierHelper(uoeSupplier, enterpriseProfile);
            }

            // 条件2：受信有無区分
            switch (uoeSupplier.ReceiveCondition)
            {
                case (int)ReceiveConditionDiv.CanSendAndReceive:// 0:送受信可能
                    return new UOESPKDecorator(new UOESupplierHelper(uoeSupplier, enterpriseProfile));  // SPK(その他)

                case (int)ReceiveConditionDiv.SendOnly:         // 1:送信のみ
                    return new UOEMeijiDecorator(new UOESupplierHelper(uoeSupplier, enterpriseProfile));// 明治産業

                default:
                    return new UOESupplierHelper(uoeSupplier, enterpriseProfile);
            }
        }

        /// <summary>
        /// 仕入受信区分が有りか判定します。
        /// </summary>
        /// <param name="stockSlipDtRecvDiv">仕入受信区分</param>
        /// <returns>
        /// <c>true</c> :有り<br/>
        /// <c>false</c>:それ以外
        /// </returns>
        public static bool HasStockSlipData(int stockSlipDtRecvDiv)
        {
            const int HAD = 1;  // 1:有り
            return stockSlipDtRecvDiv.Equals(HAD);
        }
    }
}
