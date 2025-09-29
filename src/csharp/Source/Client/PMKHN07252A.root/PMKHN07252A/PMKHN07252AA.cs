//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �݌Ƀ}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �݌Ƀ}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ƀ}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : �����</br>
	/// <br>Date       : 2009.05.14</br>
	/// <br></br>
    /// </remarks>
	public class StockSetExpAcs 
	{

        private static bool _isLocalDBRead = false;

        /// <summary>���i�Z�b�g�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IStockDB _iStockDB;

        private MakerAcs _makerAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �݌Ƀ}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ƀ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public StockSetExpAcs()
		{
            this._iStockDB = (IStockDB)MediationStockDB.GetStockDB();
            this._makerAcs = new MakerAcs();
        }

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

		/// <summary>
        /// �݌Ƀ}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockExpWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, StockExpWork stockExpWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, stockExpWork);
        }

		/// <summary>
        /// �݌Ƀ}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockExpWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, StockExpWork stockExpWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, stockExpWork);
        }

		/// <summary>
        /// �݌Ƀ}�X�^��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="stockExpWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�����������s���܂��B</br>
		/// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, StockExpWork stockExpWork)
        {
            StockWork paraStockWork = new StockWork();

            paraStockWork.EnterpriseCode = enterpriseCode;

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            // ��������
            retList = new ArrayList();
            retList.Clear();

            ArrayList resultList = new ArrayList();
            resultList.Clear();

            object paraobj = paraStockWork;
            object retobj = new ArrayList();

            status = this._iStockDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                resultList = retobj as ArrayList;
                foreach (StockWork stockWork in resultList)
                {
                    // ���o����
                    checkstatus = DataCheck(stockWork, stockExpWork);
                    if (checkstatus == 0)
                    {
                        //�a�k�O���[�v���N���X�փ����o�R�s�[
                        retList.Add(CopyToStockSetExpFromStockWork(stockWork, enterpriseCode));
                    }
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�݌Ƀ}�X�^���[�N�N���X�ˍ݌Ƀ}�X�^�N���X�j
        /// </summary>
        /// <param name="stockWork">�݌Ƀ}�X�^���[�N�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�݌Ƀ}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^���[�N�N���X����݌Ƀ}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private StockSetExp CopyToStockSetExpFromStockWork(StockWork stockWork, string enterpriseCode)
        {
            StockSetExp stockSetExp = new StockSetExp();

            stockSetExp.SectionCode = stockWork.SectionCode;
            stockSetExp.WarehouseCode = stockWork.WarehouseCode;
            stockSetExp.GoodsMakerCd = stockWork.GoodsMakerCd;
            stockSetExp.GoodsNo = stockWork.GoodsNo;
            stockSetExp.StockUnitPriceFl = stockWork.StockUnitPriceFl;
            stockSetExp.SupplierStock = stockWork.SupplierStock;
            stockSetExp.AcpOdrCount = stockWork.AcpOdrCount;
            stockSetExp.MonthOrderCount = stockWork.MonthOrderCount;
            stockSetExp.SalesOrderCount = stockWork.SalesOrderCount;
            stockSetExp.StockDiv = stockWork.StockDiv;
            stockSetExp.MovingSupliStock = stockWork.MovingSupliStock;
            stockSetExp.ShipmentPosCnt = stockWork.ShipmentPosCnt;
            stockSetExp.StockTotalPrice = stockWork.StockTotalPrice;
            stockSetExp.LastStockDate = stockWork.LastStockDate;
            stockSetExp.LastSalesDate = stockWork.LastSalesDate;
            stockSetExp.LastInventoryUpdate = stockWork.LastInventoryUpdate;
            stockSetExp.MinimumStockCnt = stockWork.MinimumStockCnt;
            stockSetExp.MaximumStockCnt = stockWork.MaximumStockCnt;
            stockSetExp.NmlSalOdrCount = stockWork.NmlSalOdrCount;
            stockSetExp.SalesOrderUnit = stockWork.SalesOrderUnit;
            stockSetExp.StockSupplierCode = stockWork.StockSupplierCode;
            stockSetExp.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen;
            stockSetExp.WarehouseShelfNo = stockWork.WarehouseShelfNo;
            stockSetExp.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1;
            stockSetExp.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2;
            stockSetExp.PartsManagementDivide1 = stockWork.PartsManagementDivide1;
            stockSetExp.PartsManagementDivide2 = stockWork.PartsManagementDivide2;
            stockSetExp.StockNote1 = stockWork.StockNote1;
            stockSetExp.StockNote2 = stockWork.StockNote2;
            stockSetExp.ShipmentCnt = stockWork.ShipmentCnt;
            stockSetExp.ArrivalCnt = stockWork.ArrivalCnt;

            return stockSetExp;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="stockWork">��������</param>
        /// <param name="stockExpWork">���o����</param>
        /// <returns></returns>
        private int DataCheck(StockWork stockWork, StockExpWork stockExpWork)
        {
            int status = 0;

            // �_���폜�敪
            if (stockWork.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // �q�ɃR�[�h
            if (!stockExpWork.WarehouseCodeSt.Trim().Equals(string.Empty) &&
                !stockExpWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.WarehouseCodeSt.CompareTo(stockWork.WarehouseCode.Trim()) > 0 ||
                    stockExpWork.WarehouseCodeEd.CompareTo(stockWork.WarehouseCode.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.WarehouseCodeSt.Trim().Equals(string.Empty))
            {
                if (stockExpWork.WarehouseCodeSt.CompareTo(stockWork.WarehouseCode.Trim()) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.WarehouseCodeEd.CompareTo(stockWork.WarehouseCode.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            // ���i���[�J�[�R�[�h
            if (stockExpWork.GoodsMakerCdSt != 0 &&
                stockExpWork.GoodsMakerCdEd != 0)
            {
                if (stockWork.GoodsMakerCd < stockExpWork.GoodsMakerCdSt ||
                   stockWork.GoodsMakerCd > stockExpWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (stockExpWork.GoodsMakerCdSt != 0)
            {
                if (stockWork.GoodsMakerCd < stockExpWork.GoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (stockExpWork.GoodsMakerCdEd != 0)
            {
                if (stockWork.GoodsMakerCd > stockExpWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            // ���i�ԍ�
            if (!stockExpWork.GoodsNoSt.Trim().Equals(string.Empty) &&
                !stockExpWork.GoodsNoEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.GoodsNoSt.CompareTo(stockWork.GoodsNo.Trim()) > 0 ||
                    stockExpWork.GoodsNoEd.CompareTo(stockWork.GoodsNo.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.GoodsNoSt.Trim().Equals(string.Empty))
            {
                if (stockExpWork.GoodsNoSt.CompareTo(stockWork.GoodsNo.Trim()) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.GoodsNoEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.GoodsNoEd.CompareTo(stockWork.GoodsNo.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
