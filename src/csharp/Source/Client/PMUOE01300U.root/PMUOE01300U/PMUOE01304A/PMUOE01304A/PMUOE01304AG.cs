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

using System;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using SupplierDB    = SingletonPolicy<SupplierDBAgent>;

    /// <summary>
    /// 計上情報の構築者クラス
    /// </summary>
    public abstract class SumUpInformationBuilder
    {
        #region <UOE送受信処理の再利用部品/>

        /// <summary>UOE送受信処理の再利用部品</summary>
        private readonly UOESendReceiveComponent _uoeSndRcvComponent;
        /// <summary>
        /// UOE送受信処理の再利用部品を取得します。
        /// </summary>
        /// <value>UOE送受信処理の再利用部品</value>
        protected UOESendReceiveComponent UoeSndRcvComponent { get { return _uoeSndRcvComponent; } }

        #endregion  // <UOE送受信処理の再利用部品/>

        #region <UOE発注先/>

        /// <summary>UOE発注先</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        protected UOESupplierHelper UoeSupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE発注先/>

        /// <summary>
        /// 計上情報に発注情報の内容をマージします。
        /// </summary>
        public abstract void Merge();

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        protected SumUpInformationBuilder(UOESupplierHelper uoeSupplier)
        {
            _uoeSndRcvComponent = new UOESendReceiveComponent();
            _uoeSupplier = uoeSupplier;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 卸商拠点設定区分の列挙体
        /// </summary>
        protected enum DistSectionSetDiv : int
        {
            /// <summary>仕入先マスタ</summary>
            Supplier = 0,
            /// <summary>発注データ</summary>
            OrderData = 1,
            /// <summary>自社マスタ</summary>
            LoginSection = 2
        }

        /// <summary>
        /// UOE自社設定マスタの卸商拠点設定に従い、拠点コードを取得します。
        /// </summary>
        /// <returns>
        /// 仕入先マスタ：発注先マスタの仕入先コードに対する仕入先マスタ上の管理拠点<br/>
        /// 発注データ　：計上元　※<c>string.Empty</c>を返します。<br/>
        /// 自社マスタ　：ログイン担当者の所属拠点コード（従業員設定マスタ）
        /// </returns>
        protected string GetSectionCodeFromUOESetting()
        {
            string sectionCode = string.Empty;

            switch (LoginWorkerAcs.Instance.Policy.UOESetting.DistSectionSetDiv)
            {
                case (int)DistSectionSetDiv.Supplier:       // 仕入先マスタ
                {
                    Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
                    if (supplier != null)
                    {
                        sectionCode = supplier.MngSectionCode;
                    }
                    break;
                }
                case (int)DistSectionSetDiv.OrderData:      // 発注データ
                    sectionCode = string.Empty;
                    break;
                case (int)DistSectionSetDiv.LoginSection:   // 自社マスタ
                    sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                    break;
            }

            return sectionCode;
        }
    }
}
