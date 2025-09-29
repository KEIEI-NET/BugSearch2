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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 出荷部品表示アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 出荷部品表示アクセスクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2008/11/10</br>
    /// </remarks>
    public class ShipmentPartsDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private ISPartsDspDB _iSPartsDspDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// 出荷部品表示アクセスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 出荷部品表示アクセスクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        public ShipmentPartsDspAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iSPartsDspDB = (ISPartsDspDB)MediationSPartsDspDB.GetSPartsDspDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSPartsDspDB = null;
            }

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="updHisDspWorkList">検索結果リスト</param>
        /// <returns>ステータス</returns>
        public int Search(ShipmentPartsDspParam extrInfo, out List<ShipmentPartsDspResult> shipmentPartsDspResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            shipmentPartsDspResultList = new List<ShipmentPartsDspResult>();

            // クラスメンバコピー処理(E→D)
            ShipmentPartsDspParamWork paraWork = CopyToShipmentPartsDspParamWorkFromShipmentPartsDspParam(extrInfo);
            
            ArrayList retList;
            object paraObj = paraWork;
            object retObj;

            try
            {
                status = this._iSPartsDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (ShipmentPartsDspResultWork retWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        shipmentPartsDspResultList.Add(CopyToShipmentPartsDspResultFromShipmentPartsDspResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                shipmentPartsDspResultList = new List<ShipmentPartsDspResult>();
            }

            return (status);
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="para">出荷部品表示条件クラス</param>
        /// <returns>出荷部品表示条件ワーククラス</returns>
        private ShipmentPartsDspParamWork CopyToShipmentPartsDspParamWorkFromShipmentPartsDspParam(ShipmentPartsDspParam para)
        {
            ShipmentPartsDspParamWork paraWork = new ShipmentPartsDspParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.SectionCode = para.SectionCode;
            paraWork.StAddUpYearMonth = TDateTime.DateTimeToLongDate("YYYYMM", para.StAddUpYearMonth);
            paraWork.EdAddUpYearMonth = TDateTime.DateTimeToLongDate("YYYYMM", para.EdAddUpYearMonth);

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">出荷部品表示結果ワーククラス</param>
        /// <returns>出荷部品表示結果クラス</returns>
        private ShipmentPartsDspResult CopyToShipmentPartsDspResultFromShipmentPartsDspResultWork(ShipmentPartsDspResultWork retWork)
        {
            ShipmentPartsDspResult ret = new ShipmentPartsDspResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.RsltTtlDivCd = retWork.RsltTtlDivCd;
            ret.SalesTimes = retWork.SalesTimes;
            ret.SalesMoney = retWork.SalesMoney;
            ret.GrossProfit = retWork.GrossProfit;

            return ret;
        }

        #endregion Private Methods
    }
}
