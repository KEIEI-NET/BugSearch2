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
    /// �݌Ɏ��яƉ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �݌Ɏ��яƉ�A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30350 �N�� ����</br>
    /// <br>Date        : 2008/11/25</br>
    /// <br>Update Note : 2009/07/27 ������ �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note : 2010/09/08 �k���r</br>
    /// <br>            �E��QID:14444 �e�L�X�g�o�͑Ή�</br>
    /// </remarks>
    public class StockHistoryDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IStockHisDspDB _iStockHistDspDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// �݌Ɏ��яƉ�A�N�Z�X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �݌Ɏ��яƉ�A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30350 �N�� ����</br>
        /// <br>Date        : 2008/11/25</br>
        /// 
        /// </remarks>
        public StockHistoryDspAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iStockHistDspDB = (IStockHisDspDB)MediationStockHisDspDB.GetStockHisDspDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iStockHistDspDB = null;
            }

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <param name="updHisDspWorkList">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Search(StockHistoryDspSearchParam extrInfo, out List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList paraList = new ArrayList();

            stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();

            // �N���X�����o�R�s�[����(E��D)
            StockHistoryDspSearchParamWork paraWork = CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(extrInfo);

            paraList.Add(paraWork);
            ArrayList retList;

            object paraObj = paraList;
            object retObj;

            

            try
            {
                status = this._iStockHistDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (StockHistoryDspSearchResultWork retWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        stockHistoryDspSearchResultList.Add(CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();
            }

            return (status);
        }

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <param name="updHisDspWorkList">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchAll(StockHistoryDspSearchParam extrInfo, out List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList paraList = new ArrayList();

            stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();

            // �N���X�����o�R�s�[����(E��D)
            StockHistoryDspSearchParamWork paraWork = CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(extrInfo);

            paraList.Add(paraWork);
            ArrayList retList;

            object paraObj = paraList;
            object retObj;

            try
            {
                status = this._iStockHistDspDB.SearchAll(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (StockHistoryDspSearchResultWork retWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        stockHistoryDspSearchResultList.Add(CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(retWork));
                    }
                }
            }
            catch(Exception ex)
            {
                status = -1;
                stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();
            }

            return (status);
        }
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

        #endregion Public Methods


        #region Private Methods


        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="para">�o�ו��i�\�������N���X</param>
        /// <returns>�o�ו��i�\���������[�N�N���X</returns>
        private StockHistoryDspSearchParamWork CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(StockHistoryDspSearchParam para)
        {
            StockHistoryDspSearchParamWork paraWork = new StockHistoryDspSearchParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.GoodsNo = para.GoodsNo;
            paraWork.GoodsMakerCd = para.GoodsMakerCd;
            paraWork.WarehouseCode = para.WarehouseCode;
            paraWork.StAddUpYearMonth = para.StAddUpYearMonth;
            paraWork.EdAddUpYearMonth = para.EdAddUpYearMonth;
            paraWork.StAddUpADate = para.StAddUpDate;
            paraWork.EdAddUpADate = para.EdAddUpDate;
            paraWork.SectionCodes = new string[1];
            paraWork.SectionCodes[0] = para.SectionCode;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            paraWork.WarehouseCodeList = para.WarehouseCodeList;
            paraWork.WarehouseShelfNoList = para.WarehouseShelfNoList;
            paraWork.BlGoodsCodeList = para.BlGoodsCodeList;
            paraWork.GoodsNoList = para.GoodsNoList;
            paraWork.MakerCodeList = para.MakerCodeList;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">�o�ו��i�\�����ʃ��[�N�N���X</param>
        /// <returns>�o�ו��i�\�����ʃN���X</returns>
        /// <br>Update Note : 2010/09/08 �k���r</br>
        /// <br>            �E��QID:14444 �e�L�X�g�o�͑Ή�</br>
        private StockHistoryDspSearchResult CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(StockHistoryDspSearchResultWork retWork)
        {
            StockHistoryDspSearchResult ret = new StockHistoryDspSearchResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.AddUpYearMonth = retWork.AddUpYearMonth;
            // --- UPD 2010/09/08-------------------------------->>>>>
            //ret.WarehouseCode = retWork.WarehouseCode;
            ret.WarehouseCode = retWork.WarehouseCode.Trim();
            // --- UPD 2010/09/08--------------------------------<<<<<
            ret.GoodsNo = retWork.GoodsNo;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            ret.GoodsName = retWork.GoodsName;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            ret.GoodsMakerCd = retWork.GoodsMakerCd;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
            ret.WarehouseShelfNo= retWork.WarehouseShelfNo;
            ret.BlGoodsCode = retWork.BlGoodsCode;
            ret.StockCreateDate = retWork.StockCreateDate;
            ret.LastSalesDate = retWork.LastSalesDate;
            ret.LastStockDate = retWork.LastStockDate;
            // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<
            ret.SalesTimes = retWork.SalesTimes;
            ret.SalesCount = retWork.SalesCount;
            ret.SalesMoneyTaxExc = retWork.SalesMoneyTaxExc;
            ret.StockTimes = retWork.StockTimes;
            ret.StockCount = retWork.StockCount;
            ret.StockPriceTaxExc = retWork.StockPriceTaxExc;
            ret.GrossProfit = retWork.GrossProfit;
            ret.MoveArrivalCnt = retWork.MoveArrivalCnt;
            ret.MoveArrivalPrice = retWork.MoveArrivalPrice;
            ret.MoveShipmentCnt = retWork.MoveShipmentCnt;
            ret.MoveShipmentPrice = retWork.MoveShipmentPrice;
            ret.SearchDiv = retWork.SearchDiv;

            return ret;
        }

        #endregion Private Methods
    }
}
