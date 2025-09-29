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
    public class DelphiSalesSlipInputInitDataEighthAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataEighthAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataEighthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataEighthAcs == null)
            {
                _delphiSalesSlipInputInitDataEighthAcs = new DelphiSalesSlipInputInitDataEighthAcs();
            }
            return _delphiSalesSlipInputInitDataEighthAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataEighthAcs _delphiSalesSlipInputInitDataEighthAcs;
        private TaxRateSet _taxRateSet = null;                 // 税率設定マスタ
        private CompanyInf _companyInf = null;                 // 自社情報
        private double _taxRate = 0;
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        # endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataEighth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●自社情報設定マスタ SFUKN09002A
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out this._companyInf, enterpriseCode);
            #endregion

            #region ●税率設定マスタ SFUKK09002A
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._taxRateSet = (TaxRateSet)aList[0];
                this._taxRate = this.GetTaxRate(DateTime.Today);
            }
            #endregion

            return 0;
        }
        #endregion

        /// <summary>
        /// 税率取得処理
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        public double GetTaxRate(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRate = 0;
            }
            else
            {
                this._taxRate = 0;

                if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                    (addUpADate <= _taxRateSet.TaxRateEndDate))
                {
                    this._taxRate = _taxRateSet.TaxRate;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate2))
                {
                    this._taxRate = _taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate3))
                {
                    this._taxRate = _taxRateSet.TaxRate3;
                }
            }
            return this._taxRate;
        }

        // 自社情報設定マスタ
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }
        // 税率設定マスタ
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }
        public double GetTaxRate()
        {
            return this._taxRate;
        }
    }
}
