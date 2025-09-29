using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 更新履歴表示アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 更新履歴表示アクセスクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2008/09/29</br>
    /// </remarks>
    public class UpdHisDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IUpdHisDspDB _iUpdHisDspDB;

        private SecInfoAcs _secInfoAcs;
        private SupplierAcs _supplierAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private DateGetAcs _dateGetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// 更新履歴表示アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 更新履歴表示アクセスクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public UpdHisDspAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iUpdHisDspDB = (IUpdHisDspDB)MediationUpdHisDspDB.GetUpdHisDspDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUpdHisDspDB = null;
            }

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            // 各種マスタ読込
            ReadSecInfoSet();
            ReadSupplier();
        }

        #endregion Constructor


        #region Public Methods

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note        : 得意先名称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        /// <remarks>
        /// <br>Note        : 仕入先名称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            if (this._supplierDic.ContainsKey(supplierCode))
            {
                supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
            }

            return supplierName;
        }

        /// <summary>
        /// 期首年月日取得処理
        /// </summary>
        /// <returns>期首年月日</returns>
        /// <remarks>
        /// <br>Note        : 期首年月日を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public DateTime GetStartYearDate()
        {
            DateTime startYearDate = new DateTime();

            try
            {
                int year;
                DateTime dateTime;

                this._dateGetAcs.GetThisYearMonth(out dateTime, out year, out dateTime, out dateTime, out startYearDate, out dateTime);
            }
            catch
            {
                startYearDate = new DateTime();
            }

            return startYearDate;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="updHisDspWorkList">検索結果リスト</param>
        /// <returns>ステータス</returns>
        public int Search(ExtrInfo_UpdHisDspWork extrInfo, out List<RsltInfo_UpdHisDspWork> updHisDspWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            updHisDspWorkList = new List<RsltInfo_UpdHisDspWork>();

            ArrayList retList;

            object paraObj = extrInfo;
            object retObj;

            try
            {
                status = this._iUpdHisDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (RsltInfo_UpdHisDspWork rsltInfo in retList)
                    {
                        updHisDspWorkList.Add(rsltInfo);
                    }
                }
            }
            catch
            {
                status = -1;
                updHisDspWorkList = new List<RsltInfo_UpdHisDspWork>();
            }

            return (status);
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// 仕入先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        :仕入先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._supplierDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        #endregion Private Methods
    }
}
