//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10806793-00  �쐬�S�� : �c����
// �C �� ��  2012/12/13  �C�����e : 2013/03/13�z�M��  Redmine#33835
//                                  �o�׉񐔂�ǉ�����Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌Ƀ}�X�^�����X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�����ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2012/12/13 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#33835 �o�׉񐔂�ǉ�����Ή�</br>
    /// </remarks>
    public class StockMstAcs
    {
        #region ��Private Members
        private static StockMstAcs _stockMstAcs;
        /// <summary>���������[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IStockMstDB _stockMstDB;
        private IGoodsUDB _goodsUDB;
        #endregion

        #region ��Constructor 
        /// <summary>
        /// �݌Ƀ}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�A�N�Z�X�N���X�R���X�g���N�^�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public StockMstAcs()
        {
            try
            {
                // �����}�X�^�����[�g�I�u�W�F�N�g�擾
                this._stockMstDB = (IStockMstDB)MediationStockMstDB.GetStockMstDB();

            }
            catch (Exception)
            {
                this._stockMstDB = null;
            }
        }
        #endregion

        #region �� �݌Ƀ}�X�^�A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// �݌Ƀ}�X�^�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�A�N�Z�X�N���X �C���X�^���X�擾�����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>�݌Ƀ}�X�^�A�N�Z�X�N���X �C���X�^���X</returns>
        public static StockMstAcs GetInstance()
        {
            if (_stockMstAcs == null)
            {
                _stockMstAcs = new StockMstAcs();
            }

            return _stockMstAcs;
        }
        #endregion

        #region ��Public Methods
        /// <summary>
        /// �݌Ƀ}�X�^��������
        /// </summary>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCd">Ұ��</param>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^���������B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int SearchStockInfo(string enterPriseCode, string goodsNo, Int32 goodsMakerCd, out ArrayList stockList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList stockRemoteList = new ArrayList();

            status = this._stockMstDB.SearchStockInfo(enterPriseCode, goodsNo, goodsMakerCd, out stockRemoteList, out retMessage);

            stockList = new ArrayList();
            Stock _stock = null;

            foreach (StockWork _stockWork in stockRemoteList)
            {
                _stock = new Stock();

                _stock.CreateDateTime = _stockWork.CreateDateTime;
                _stock.UpdateDateTime = _stockWork.UpdateDateTime;
                _stock.EnterpriseCode = _stockWork.EnterpriseCode;
                _stock.FileHeaderGuid = _stockWork.FileHeaderGuid;
                _stock.UpdEmployeeCode = _stockWork.UpdEmployeeCode;
                _stock.UpdAssemblyId1 = _stockWork.UpdAssemblyId1;
                _stock.UpdAssemblyId2 = _stockWork.UpdAssemblyId2;
                _stock.LogicalDeleteCode = _stockWork.LogicalDeleteCode;
                _stock.SectionCode = _stockWork.SectionCode;
                _stock.WarehouseCode = _stockWork.WarehouseCode;
                _stock.GoodsMakerCd = _stockWork.GoodsMakerCd;
                _stock.GoodsNo = _stockWork.GoodsNo;
                _stock.StockUnitPriceFl = _stockWork.StockUnitPriceFl;
                _stock.SupplierStock = _stockWork.SupplierStock;
                _stock.AcpOdrCount = _stockWork.AcpOdrCount;
                _stock.MonthOrderCount = _stockWork.MonthOrderCount;
                _stock.SalesOrderCount = _stockWork.SalesOrderCount;
                _stock.StockDiv = _stockWork.StockDiv;
                _stock.MovingSupliStock = _stockWork.MovingSupliStock;
                _stock.ShipmentPosCnt = _stockWork.ShipmentPosCnt;
                _stock.StockTotalPrice = _stockWork.StockTotalPrice;
                _stock.LastStockDate = _stockWork.LastStockDate;
                _stock.LastSalesDate = _stockWork.LastSalesDate;
                _stock.LastInventoryUpdate = _stockWork.LastInventoryUpdate;
                _stock.MinimumStockCnt = _stockWork.MinimumStockCnt;
                _stock.MaximumStockCnt = _stockWork.MaximumStockCnt;
                _stock.NmlSalOdrCount = _stockWork.NmlSalOdrCount;
                _stock.SalesOrderUnit = _stockWork.SalesOrderUnit;
                _stock.StockSupplierCode = _stockWork.StockSupplierCode;
                _stock.GoodsNoNoneHyphen = _stockWork.GoodsNoNoneHyphen;
                _stock.WarehouseShelfNo = _stockWork.WarehouseShelfNo;
                _stock.DuplicationShelfNo1 = _stockWork.DuplicationShelfNo1;
                _stock.DuplicationShelfNo2 = _stockWork.DuplicationShelfNo2;
                _stock.PartsManagementDivide1 = _stockWork.PartsManagementDivide1;
                _stock.PartsManagementDivide2 = _stockWork.PartsManagementDivide2;
                _stock.StockNote1 = _stockWork.StockNote1;
                _stock.StockNote2 = _stockWork.StockNote2;
                _stock.ShipmentCnt = _stockWork.ShipmentCnt;
                _stock.ArrivalCnt = _stockWork.ArrivalCnt;
                _stock.StockCreateDate = _stockWork.StockCreateDate;
                _stock.UpdateDate = _stockWork.UpdateDate;
                stockList.Add(_stock);
            }

            return status;
        }

        //----- ADD 2012/12/13 �c���� Redmine#33835 ------------->>>>>
        /// <summary>
        /// �o�׉񐔌�������
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <param name="updHisDspWorkList">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�׉񐔌����������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        public int SearchStockHisDsp(StockHistoryDspSearchParam extrInfo, out List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
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
                status = this._stockMstDB.SearchStockHisDsp(out retObj, paraObj);
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

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="para">�o�ו��i�\�������N���X</param>
        /// <returns>�o�ו��i�\���������[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o�R�s�[����(E��D)���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private StockHistoryDspSearchParamWork CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(StockHistoryDspSearchParam para)
        {
            StockHistoryDspSearchParamWork paraWork = new StockHistoryDspSearchParamWork();

            // ��ƃR�[�h
            paraWork.EnterpriseCode = para.EnterpriseCode;
            // �i��
            paraWork.GoodsNo = para.GoodsNo;
            //���[�J�[
            paraWork.GoodsMakerCd = para.GoodsMakerCd;
            // �q�ɃR�[�h
            paraWork.WarehouseCode = para.WarehouseCode;
            // �J�n�N��
            paraWork.StAddUpYearMonth = para.StAddUpYearMonth;
            // �I���N��
            paraWork.EdAddUpYearMonth = para.EdAddUpYearMonth;
            // �J�n�N����
            paraWork.StAddUpADate = para.StAddUpDate;
            // �I���N����
            paraWork.EdAddUpADate = para.EdAddUpDate;

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="retWork">�o�ו��i�\�����ʃ��[�N�N���X</param>
        /// <returns>�o�ו��i�\�����ʃN���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o�R�s�[����(D��E)���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// </remarks>
        private StockHistoryDspSearchResult CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(StockHistoryDspSearchResultWork retWork)
        {
            StockHistoryDspSearchResult ret = new StockHistoryDspSearchResult();

            // ��ƃR�[�h
            ret.EnterpriseCode = retWork.EnterpriseCode;
            // �v��N��
            ret.AddUpYearMonth = retWork.AddUpYearMonth;
            // �q�ɃR�[�h
            ret.WarehouseCode = retWork.WarehouseCode.Trim();
            // �i��
            ret.GoodsNo = retWork.GoodsNo;
            //���[�J�[
            ret.GoodsMakerCd = retWork.GoodsMakerCd;
            // �o�׉�
            ret.SalesTimes = retWork.SalesTimes;

            return ret;
        }
        //----- ADD 2012/12/13 �c���� Redmine#33835 -------------<<<<<

        /// <summary>
        /// ���i�}�X�^���������u�i���̎擾�v
        /// </summary>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCd">Ұ��</param>
        /// <param name="goodsUWork">���i���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������u�i���̎擾�v�B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int SearchGoodsUInfo(string enterPriseCode, string goodsNo, Int32 goodsMakerCd, out GoodsUWork goodsUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object goodsUObj = new object();

            GoodsUWork goodsUCond = new GoodsUWork();
            goodsUCond.EnterpriseCode = enterPriseCode;
            goodsUCond.GoodsNo = goodsNo;
            goodsUCond.GoodsMakerCd = goodsMakerCd;
            goodsUCond.LogicalDeleteCode = 0;

            object goodsUCondObj = (object)goodsUCond;

            // �T�[�o�[���[�U�[�f�[�^
            if (this._goodsUDB == null)
            {
                this._goodsUDB = MediationGoodsUDB.GetGoodsUDB();
            }

            status = this._goodsUDB.Search(out goodsUObj, goodsUCondObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (goodsUObj != null)
            {
                goodsUWork = goodsUObj as GoodsUWork;
            }
            else
            {
                goodsUWork = null;
            }

            return status;
        }

        /// <summary>
        /// �݌Ƀ}�X�^�ۑ�����
        /// </summary>
        /// <param name="retStock">�݌Ƀf�[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�ۑ������B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int SaveStockInfo(Stock retStock, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ۑ��f�[�^
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.SectionCode = retStock.SectionCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.StockUnitPriceFl = retStock.StockUnitPriceFl;
            _stockWork.SupplierStock = retStock.SupplierStock;
            _stockWork.AcpOdrCount = retStock.AcpOdrCount;
            _stockWork.SalesOrderCount = retStock.SalesOrderCount;
            _stockWork.StockDiv = retStock.StockDiv;
            _stockWork.MovingSupliStock = retStock.MovingSupliStock;
            _stockWork.ShipmentPosCnt = retStock.ShipmentPosCnt;
            _stockWork.LastStockDate = retStock.LastStockDate;
            _stockWork.LastSalesDate = retStock.LastSalesDate;
            _stockWork.MinimumStockCnt = retStock.MinimumStockCnt;
            _stockWork.MaximumStockCnt = retStock.MaximumStockCnt;
            _stockWork.SalesOrderUnit = retStock.SalesOrderUnit;
            _stockWork.StockSupplierCode = retStock.StockSupplierCode;
            _stockWork.GoodsNoNoneHyphen = retStock.GoodsNoNoneHyphen;
            _stockWork.WarehouseShelfNo = retStock.WarehouseShelfNo;
            _stockWork.DuplicationShelfNo1 = retStock.DuplicationShelfNo1;
            _stockWork.DuplicationShelfNo2 = retStock.DuplicationShelfNo2;
            _stockWork.PartsManagementDivide1 = retStock.PartsManagementDivide1;
            _stockWork.PartsManagementDivide2 = retStock.PartsManagementDivide2;
            _stockWork.StockNote1 = retStock.StockNote1;
            _stockWork.StockNote2 = retStock.StockNote2;
            _stockWork.ShipmentCnt = retStock.ShipmentCnt;
            _stockWork.ArrivalCnt = retStock.ArrivalCnt;
            _stockWork.StockCreateDate = retStock.StockCreateDate;
            _stockWork.UpdateDate = retStock.UpdateDate;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.Write(stockList, out retMessage);

            return status;
        }

        /// <summary>
        /// �݌Ƀ}�X�^�_���폜����
        /// </summary>
        /// <param name="retStock">�݌Ƀf�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�_���폜�����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int LogicalDelete(Stock retStock)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ۑ��f�[�^
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.LogicalDelete(ref stockList);

            return status;
        }

        /// <summary>
        /// �݌Ƀ}�X�^��������
        /// </summary>
        /// <param name="retStock">�݌Ƀf�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref Stock retStock )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ۑ��f�[�^
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.RevivalLogicalDelete(ref stockList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockList != null && stockList.Count > 0)
                {
                    StockWork  stockWork = (StockWork)stockList[0];
                    retStock.UpdateDateTime = stockWork.UpdateDateTime;
                    retStock.UpdEmployeeCode = stockWork.UpdEmployeeCode; // ADD 2010/09/06
                    retStock.UpdAssemblyId1 = stockWork.UpdAssemblyId1; // ADD 2010/09/06
                    retStock.UpdAssemblyId2 = stockWork.UpdAssemblyId2; // ADD 2010/09/06
                    retStock.LogicalDeleteCode = stockWork.LogicalDeleteCode; // ADD 2010/09/06
                    retStock.SupplierStock = stockWork.SupplierStock; // ADD 2010/09/06
                }
            }

            return status;
        }

        /// <summary>
        /// �݌Ƀ}�X�^���S�폜����
        /// </summary>
        /// <param name="retStock">�݌Ƀf�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���S�폜�����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int Delete(Stock retStock)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �ۑ��f�[�^
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.Delete(stockList);

            return status;
        }
        #endregion
    }
}
