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
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;

    #region <仕入マスタ/>

    /// <summary>
    /// 仕入マスタDBアクセスの代理人クラス
    /// </summary>
    public sealed class SupplierDBAgent
    {
        #region <仕入マスタレコードマップ/>

        /// <summary>仕入マスタレコードのマップ</summary>
        /// <remarks>キー：仕入先コード("000000")</remarks>
        private readonly IDictionary<string, Supplier> _codedSupplierMap = new Dictionary<string, Supplier>();
        /// <summary>
        /// 仕入マスタレコードのマップを取得します。
        /// </summary>
        /// <value>仕入マスタレコードのマップ</value>
        private IDictionary<string, Supplier> CodedSupplierMap { get { return _codedSupplierMap; } }

        /// <summary>
        /// キーを取得します。
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先コード("000000")</returns>
        private static string GetKey(int supplierCode)
        {
            return supplierCode.ToString("000000");
        }

        #endregion  // <仕入マスタレコードマップ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SupplierDBAgent()
        {
            SupplierAcs supplierAcs = new SupplierAcs();
            {
                ArrayList retList = null;
                int status = supplierAcs.SearchAll(
                    out retList,
                    LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code
                );
                if (status.Equals((int)Result.RemoteStatus.Normal))
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode.Equals(0))
                        {
                            string key = GetKey(supplier.SupplierCd);
                            if (!CodedSupplierMap.ContainsKey(key))
                            {
                                CodedSupplierMap.Add(key, supplier);
                            }
                        }
                    }
                }
            }
        }

        #endregion  // <Constructor/>

        #region <検索/>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>
        /// 検索された仕入先マスタレコード
        /// （※検索されなかった場合、<c>null</c>を返します）
        /// </returns>
        public Supplier Find(UOESupplierHelper uoeSupplier)
        {
            return CodedSupplierMap[GetKey(uoeSupplier.RealUOESupplier.UOESupplierCd)];
        }

        #endregion  // <検索/>
    }

    #endregion  // <仕入マスタ/>

    #region <全体初期設定マスタ/>

    /// <summary>
    /// 全体初期設定マスタDBアクセスの代理人クラス
    /// </summary>
    public sealed class AllDefSetDBAgent
    {
        #region <全体初期設定マスタレコード/>

        /// <summary>全体初期設定マスタのレコード</summary>
        private readonly AllDefSet _allDefSet;
        /// <summary>
        /// 全体初期設定マスタのレコードを取得します。
        /// </summary>
        /// <value>全体初期設定マスタのレコード</value>
        public AllDefSet AllDefSet { get { return _allDefSet; } }

        #endregion  // <全体初期設定マスタレコード/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public AllDefSetDBAgent()
        {
            _allDefSet = GetAllDefSet(
                LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code,
                LoginWorkerAcs.Instance.Policy.SectionProfile.Code
            );
        }

        /// <summary>
        /// 全体初期値設定のレコードを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>全体初期値情報のレコード</returns>
        private static AllDefSet GetAllDefSet(
            string enterpriseCode,
            string sectionCode
        )
        {
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            {
                AllDefSet allDefSet = null;
                int status = allDefSetAcs.Read(out allDefSet, enterpriseCode, sectionCode);
                if (allDefSet == null)
                {
                    allDefSet = new AllDefSet();
                }
                return allDefSet;
            }
        }

        #endregion  // <Constructor/>
    }

    #endregion  // <全体初期設定マスタ/>

    #region <税率設定マスタ/>

    /// <summary>
    /// 税率設定マスタDBアクセスの代理人クラス
    /// </summary>
    public sealed class TaxRateSetDBAgent
    {
        #region <税率設定情報/>

        /// <summary>税率設定情報</summary>
        private readonly TaxRateSet _taxRateSetInfo;
        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <value>税率設定情報</value>
        private TaxRateSet TaxRateSetInfo { get { return _taxRateSetInfo; } }

        #endregion  // <税率設定情報/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public TaxRateSetDBAgent()
        {
            _taxRateSetInfo = GetTaxRateSet(LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code);
        }

        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>税率設定情報</returns>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                TaxRateSet taxRateSet = null;
                int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
                if (taxRateSet == null)
                {
                    taxRateSet = new TaxRateSet();
                }
                return taxRateSet;
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 今の税率を取得します。
        /// </summary>
        /// <value>今の税率</value>
        public double TaxRateOfNow
        {
            get
            {
                return GetTaxRate(TaxRateSetInfo, DateTime.Now);
            }
        }

        /// <summary>
        /// 税率を取得します。
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate
        )
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
    }

    #endregion  // <税率設定マスタ/>

    #region <UOEガイド名称マスタ/>

    /// <summary>
    /// UOEガイド名称マスタ
    /// </summary>
    public sealed class UOEGuideNameDBAgent
    {
        #region <UOEガイド名称コレクション/>

        /// <summary>UOEガイド名称レコードリストのマップ</summary>
        /// <remarks>キー：UOE発注先コード</remarks>
        private readonly IDictionary<int, IList<UOEGuideName>> _uoeGuideNameMap = new Dictionary<int, IList<UOEGuideName>>();
        /// <summary>
        /// UOEガイド名称レコードリストのマップを取得します。
        /// </summary>
        /// <remarks>キー：UOE発注先コード</remarks>
        /// <value>UOEガイド名称レコードリストのマップ</value>
        private IDictionary<int, IList<UOEGuideName>> UoeGuideNameMap
        {
            get { return _uoeGuideNameMap; }
        }

        #endregion  // <UOEガイド名称コレクション/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UOEGuideNameDBAgent()
        {
            UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();
            {
                ArrayList uoeGuideNameList          = new ArrayList();
                UOEGuideName searchingUOEGuideName  = new UOEGuideName();
                {
                    searchingUOEGuideName.EnterpriseCode    = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
                    searchingUOEGuideName.SectionCode       = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                    searchingUOEGuideName.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;
                    searchingUOEGuideName.UOEGuideDivCd     = 2;    // 2:納品区分
                }
                int status = uoeGuideNameAcs.Search(out uoeGuideNameList, searchingUOEGuideName);
                if (uoeGuideNameList == null || uoeGuideNameList.Count.Equals(0)) return;
                
                foreach (UOEGuideName uoeGuideName in uoeGuideNameList)
                {
                    if (!UoeGuideNameMap.ContainsKey(uoeGuideName.UOESupplierCd))
                    {
                        UoeGuideNameMap.Add(uoeGuideName.UOESupplierCd, new List<UOEGuideName>());
                    }
                    UoeGuideNameMap[uoeGuideName.UOESupplierCd].Add(uoeGuideName);
                }
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// UOEガイド名称レコードを返します。
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <param name="uoeGuideCode">UOEガイドコード（UOE発注データの納品区分）</param>
        /// <returns>
        /// 該当するUOEガイド名称レコード
        /// （該当するものがない場合、<c>null</c>を返します）
        /// </returns>
        public UOEGuideName Find(
            int uoeSupplierCd,
            string uoeGuideCode
        )
        {
            if (UoeGuideNameMap.ContainsKey(uoeSupplierCd))
            {
                foreach (UOEGuideName uoeGuideName in UoeGuideNameMap[uoeSupplierCd])
                {
                    if (uoeGuideName.UOEGuideCode.Trim().Equals(uoeGuideCode.Trim()))
                    {
                        return uoeGuideName;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }

    #endregion  // <UOEガイド名称マスタ/>

    #region <メーカーマスタ/>

    /// <summary>
    /// メーカーマスタDBアクセスの代理人クラス
    /// </summary>
    public sealed class MakerMasterDBAgent
    {
        #region <本物のアクセサ/>

        /// <summary></summary>
        private readonly MakerSetAcs _realReader = new MakerSetAcs();
        /// <summary>
        /// 
        /// </summary>
        private MakerSetAcs RealReader { get { return _realReader; } }

        #endregion  // <本物のアクセサ/>

        #region <メーカーセットのコレクション/>

        /// <summary>メーカーセットのマップ（キー：メーカーコード）</summary>
        private readonly IDictionary<int, MakerSet> _makerSetMap = new Dictionary<int, MakerSet>();
        /// <summary>
        /// メーカーセットのマップを取得します。
        /// </summary>
        /// <remarks>キー：メーカーコード</remarks>
        private IDictionary<int, MakerSet> MakerSetMap { get { return _makerSetMap; } }

        #endregion  // <メーカーセットのコレクション/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MakerMasterDBAgent() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// メーカーを検索します。
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>該当するメーカー（該当メーカーが無い場合、<c>null</c>を返します）</returns>
        public MakerSet Find(int makerCode)
        {
            if (MakerSetMap.ContainsKey(makerCode)) return MakerSetMap[makerCode];

            // 1パラ目
            ArrayList searchedRecordList = null;
            // 3パラ目
            MakerPrintWork searchingCondition = new MakerPrintWork();
            {
                searchingCondition.GoodsMakerCdSt = makerCode;
                searchingCondition.GoodsMakerCdEd = makerCode;
                searchingCondition.LogicalDeleteCode = 0;
            }

            int status = RealReader.SearchAll(
                out searchedRecordList,
                LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code,
                searchingCondition
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal))
            {
                return null;
            }
            if (searchedRecordList == null || searchedRecordList.Count.Equals(0))
            {
                return null;
            }

            foreach (MakerSet makerSet in searchedRecordList)
            {
                if (!MakerSetMap.ContainsKey(makerCode))
                {
                    MakerSetMap.Add(makerCode, makerSet);
                }
            }

            return MakerSetMap[makerCode];
        }
    }

    #endregion  // <メーカーマスタ/>
}
