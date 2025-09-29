using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataTenthAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataTenthAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataTenthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataTenthAcs == null)
            {
                _delphiSalesSlipInputInitDataTenthAcs = new DelphiSalesSlipInputInitDataTenthAcs();
            }
            return _delphiSalesSlipInputInitDataTenthAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataTenthAcs _delphiSalesSlipInputInitDataTenthAcs;
        private SalesTtlSt _salesTtlSt = null;                 // 売上全体設定マスタ
        private EstimateDefSet _estimateDefSet = null;         // 見積初期値設定マスタ
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";
        # endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataTenth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●売上全体設定マスタ DCKHN09212A
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタ
            salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ●見積初期値設定マスタ DCMIT09012A
            EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();  // 見積初期値設定マスタ
            status = estimateDefSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheEstimateDefSet(aList, enterpriseCode, sectionCode);
            }
            #endregion

            return 0;
        }
        #endregion

        # region ■見積初期値設定マスタ制御処理
        /// <summary>
        /// 見積初期値設定マスタキャッシュ
        /// </summary>
        /// <param name="estimateDefSetList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheEstimateDefSet(ArrayList estimateDefSetList, string enterpriseCode, string sectionCode)
        {
            if (estimateDefSetList != null)
            {
                List<EstimateDefSet> list = new List<EstimateDefSet>((EstimateDefSet[])estimateDefSetList.ToArray(typeof(EstimateDefSet)));

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == sectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._estimateDefSet != null) return;

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }

        # endregion

        # region ■売上全体設定マスタ制御処理
        /// <summary>
        /// 売上全体設定マスタキャッシュ
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
        {
            if (salesTtlStList != null)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])salesTtlStList.ToArray(typeof(SalesTtlSt)));

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }

        # endregion

        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
    }
}
