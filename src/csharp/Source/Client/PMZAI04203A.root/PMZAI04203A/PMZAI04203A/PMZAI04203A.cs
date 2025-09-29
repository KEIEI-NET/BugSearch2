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
    /// 棚卸表示アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 棚卸表示アクセスクラス</br>
    /// <br>Programmer  : 30350 櫻井　亮太</br>
    /// <br>Date        : 2008/11/17</br>
    /// <br>Update Note : 2014/03/05 田建委</br>
    /// <br>            : Redmine#42247 印刷機能の追加</br>
    /// </remarks>
    public class InventoryDataDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IInventoryDtDspDB _iInventoryDtDspDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// 棚卸表示アクセスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 棚卸表示アクセスクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        public InventoryDataDspAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iInventoryDtDspDB = (IInventoryDtDspDB)MediationInventoryDtDspDB.GetInventoryDtDspDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iInventoryDtDspDB = null;
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
        public int Search(InventoryDataDspParam extrInfo, out List<InventoryDataDspResult> inventoryDataDspResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            inventoryDataDspResultList = new List<InventoryDataDspResult>();

            // クラスメンバコピー処理(E→D)
            InventoryDataDspParamWork paraWork = CopyToInventoryDataDspParamWorkFromInventoryDataDspParam(extrInfo);
            
            ArrayList retList;
            object paraObj = paraWork;
            object retObj;

            try
            {
                status = this._iInventoryDtDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (InventoryDataDspResultWork retWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        inventoryDataDspResultList.Add(CopyToInventoryDataDspResultFromInventoryDataDspResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                inventoryDataDspResultList = new List<InventoryDataDspResult>();
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
        private InventoryDataDspParamWork CopyToInventoryDataDspParamWorkFromInventoryDataDspParam(InventoryDataDspParam para)
        {
            InventoryDataDspParamWork paraWork = new InventoryDataDspParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.GoodsMakerCd = para.GoodsMakerCd;
            paraWork.WarehouseDiv = para.WarehouseDiv;
            paraWork.StWarehouseCode = para.StWarehouseCode;
            paraWork.EdWarehouseCode = para.EdWarehouseCode;
            paraWork.WarehouseCd01 = para.WarehouseCd01;
            paraWork.WarehouseCd02 = para.WarehouseCd02;
            paraWork.WarehouseCd03 = para.WarehouseCd03;
            paraWork.WarehouseCd04 = para.WarehouseCd04;
            paraWork.WarehouseCd05 = para.WarehouseCd05;
            paraWork.WarehouseCd06 = para.WarehouseCd06;
            paraWork.WarehouseCd07 = para.WarehouseCd07;
            paraWork.WarehouseCd08 = para.WarehouseCd08;
            paraWork.WarehouseCd09 = para.WarehouseCd09;
            paraWork.WarehouseCd10 = para.WarehouseCd10;
            paraWork.ListDiv = para.ListDiv2;
            paraWork.ListTypeDiv = para.ListTypeDiv;

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">出荷部品表示結果ワーククラス</param>
        /// <returns>出荷部品表示結果クラス</returns>
        /// <remarks>
        /// <br>Update Note : 2014/03/05 田建委</br>
        /// <br>            : Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        private InventoryDataDspResult CopyToInventoryDataDspResultFromInventoryDataDspResultWork(InventoryDataDspResultWork retWork)
        {
            InventoryDataDspResult ret = new InventoryDataDspResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.WarehouseName = retWork.WarehouseName;
            ret.InventoryItemCnt = retWork.InventoryItemCnt;
            ret.InventoryMony = retWork.InventoryMoney;
            ret.MaximuminventoryMony = retWork.MaximumInventoryMoney;
            ret.WarehouseCode = retWork.WarehouseCode; // ADD 2014/03/05 田建委 Redmine#42247

            return ret;
        }

        #endregion Private Methods
    }
}
