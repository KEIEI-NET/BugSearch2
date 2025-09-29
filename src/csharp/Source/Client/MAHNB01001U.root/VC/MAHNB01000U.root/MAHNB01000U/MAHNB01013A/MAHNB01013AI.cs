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
    public class DelphiSalesSlipInputInitDataSeventhAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataSeventhAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataSeventhAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataSeventhAcs == null)
            {
                _delphiSalesSlipInputInitDataSeventhAcs = new DelphiSalesSlipInputInitDataSeventhAcs();
            }
            return _delphiSalesSlipInputInitDataSeventhAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataSeventhAcs _delphiSalesSlipInputInitDataSeventhAcs;
        private AllDefSet _allDefSet = null;                   // 全体初期値設定マスタ
        private StockTtlSt _stockTtlSt = null;                 // 仕入在庫全体設定マスタ


        /// <summary> 入力モード</summary>
        private int _inputMode;
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

        /// <summary>オプション情報</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        # endregion

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        #endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataSeventh(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●仕入在庫全体設定マスタ SFSIR09002A
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();          // 仕入在庫全体設定マスタ
            status = stockTtlStAcs.SearchOnlyStockTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheStockTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ●全体初期値設定マスタ SFCMN09082A
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = (ctIsLocalDBRead == true) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;
            status = allDefSetAcs.Search(out aList, enterpriseCode, allDefSetSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, aList);
                if (this._allDefSet != null) this._inputMode = this._allDefSet.GoodsNoInpDiv;
            }
            #endregion

            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion

            return 0;
        }
        #endregion

        # region ■仕入在庫全体設定マスタ制御処理
        /// <summary>
        /// 仕入在庫全体設定マスタキャッシュ
        /// </summary>
        /// <param name="stockTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheStockTtlSt(ArrayList stockTtlStList, string enterpriseCode, string sectionCode)
        {
            if (stockTtlStList != null)
            {
                List<StockTtlSt> list = new List<StockTtlSt>((StockTtlSt[])stockTtlStList.ToArray(typeof(StockTtlSt)));

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._stockTtlSt != null) return;

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
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

        # region ■全体初期値設定マスタ制御処理
        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;
        }

        # endregion

        #region ■オプション情報制御処理
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●車両管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_CarMng = (int)Option.ON;
            }
            else
            {
                this._opt_CarMng = (int)Option.OFF;
            }
            #endregion

            #region ●自由検索オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FreeSearch = (int)Option.ON;
            }
            else
            {
                this._opt_FreeSearch = (int)Option.OFF;
            }
            #endregion

            #region ●ＰＣＣオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PCC = (int)Option.ON;
            }
            else
            {
                this._opt_PCC = (int)Option.OFF;
            }
            #endregion

            #region ●リサイクル連動オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_RCLink = (int)Option.ON;
            }
            else
            {
                this._opt_RCLink = (int)Option.OFF;
            }
            #endregion

            #region ●ＵＯＥオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_UOE = (int)Option.ON;
            }
            else
            {
                this._opt_UOE = (int)Option.OFF;
            }
            #endregion

            #region ●仕入支払管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockingPayment = (int)Option.ON;
            }
            else
            {
                this._opt_StockingPayment = (int)Option.OFF;
            }
            #endregion
        }
        #endregion


        public int GetOpt_CarMng()
        {
            return this._opt_CarMng;
        }
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }
    }
}
