//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�݌Ƀ}�X�^�ꗗ���
// �v���O�����T�v   �F�݌Ƀ}�X�^�ꗗ�̈�����s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/01/13     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/20     �C�����e�FMantis�y12127�z���x�A�b�v�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/27     �C�����e�FMantis�y11394�z�\�[�g���ݒ�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/05/21     �C�����e�FMantis�y12126�z�t�B�[�h�o�b�N�Ή� �����z�̎Z�o�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/04     �C�����e�FMantis�y13432�z�d����̒��o�������C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F����
// �C����    2013/06/18     �C�����e�FRedmine#36533 
//                          �����͑S�Аݒ�̊|�����炵���Z�o���Ă��Ȃ���Q�̏C��
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌Ƀ}�X�^�ꗗ����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�ꗗ����Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// </remarks>
    public class StockMasterTblAcs
    {
        #region �� Constructor
		/// <summary>
        /// �݌Ƀ}�X�^�ꗗ����A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�ꗗ����A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 30413 ����</br>
	    /// <br>Date       : 2009.01.13</br>
		/// </remarks>
		public StockMasterTblAcs()
		{
            this._iStockMasterTblDB = (IStockMasterTblDB)MediationStockMasterTblDB.GetStockMasterTblDB();
            this._goodsAcs = new GoodsAcs();
            // 2009.03.09 30413 ���� ���P���̎Z�o������ύX >>>>>>START
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            // 2009.03.09 30413 ���� ���P���̎Z�o������ύX <<<<<<END
        
            // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- >>>>>
            this._companyInfAcs = new CompanyInfAcs();
            this._companyInf = new CompanyInf();
            this.SetUnitPriceCalculation(LoginInfoAcquisition.EnterpriseCode);
            // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- <<<<<
        
            // ���i�A�N�Z�X�N���X�̏�����
            string message = "";
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);

            // 2009.03.09 30413 ���� ���P���̎Z�o������ύX >>>>>>START
            // �ŗ��擾
            TaxRateSet taxRateSet;
            if (this.TaxRateSetRead(out taxRateSet) == 0)
            {
                _taxRate = this.GetTaxRate(taxRateSet, DateTime.Now);
            }

            // �P���Z�o���W���[���̏����f�[�^�ݒ�
            this.ReadInitData();
            // 2009.03.09 30413 ���� ���P���̎Z�o������ύX <<<<<<END
        }

		/// <summary>
        /// �݌Ƀ}�X�^�ꗗ����\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�ꗗ����\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        static StockMasterTblAcs()
		{
			stc_Employee		= null;
			
			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;

        /// <summary>���i���}�X�^�L���b�V��</summary>
        private static List<List<GoodsUnitData>> _goodsUnitDataListList;

        // ADD 2009/04/20 ------>>>
        /// <summary>���i���L���b�V���f�B�N�V���i���[</summary>
        private static Dictionary<string, GoodsUnitData> _goodsUnitDataList;
        // ADD 2009/04/20 ------<<<
        #endregion �� Static Member

        #region �� Private Member
        IStockMasterTblDB _iStockMasterTblDB;           // �݌Ƀ}�X�^�ꗗ��������[�g
        GoodsAcs _goodsAcs;                             // ���i�A�N�Z�X�N���X
        // 2009.03.09 30413 ���� ���P���̎Z�o������ύX >>>>>>START
        TaxRateSetAcs _taxRateSetAcs;                   // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        UnitPriceCalculation _unitPriceCalculation;     // �P���Z�o���W���[��

        private double _taxRate = 0.0;                  // �ŗ�
        // 2009.03.09 30413 ���� ���P���̎Z�o������ύX <<<<<<END
        
        private DataSet _printDataSet;  // ���DataSet

        // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- >>>>>
        /// <summary>���Џ��ݒ� �A�N�Z�X�N���X</summary>
        private CompanyInfAcs _companyInfAcs;
        private CompanyInf _companyInf = null; // ���Џ��
        // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- <<<<<

        #endregion �� Private Member

        #region [public �v���p�e�B]
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet PrintDataSet
        {
            get { return this._printDataSet; }
        }
        #endregion

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �����f�[�^�擾
        /// <summary>
        /// �݌Ƀ}�X�^�ꗗ����f�[�^�擾
        /// </summary>
        /// <param name="cndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������݌Ƀ}�X�^�ꗗ����f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public int SearchStockMasterTbl(object cndtn, out string errMsg)
        {
            return this.SearchStockMasterTblProc(cndtn, out errMsg);
        }

        /// <summary>
        /// ������̃}�X�^�f�[�^�擾
        /// </summary>
        /// <param name="retMList">������̃}�X�^�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prpid">�v���O����ID</param>
        /// <param name="prinm">�v�����^��</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������̃}�X�^�f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public int SearchMasterData(out ArrayList retMList, string enterpriseCode, string prpid, string prinm)
        {
            return this.SearchMasterDataProc(out retMList, enterpriseCode, prpid, prinm);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �݌Ƀ}�X�^�ꗗ����f�[�^�擾
        /// <summary>
        /// �݌Ƀ}�X�^�ꗗ����f�[�^�擾
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������݌Ƀ}�X�^�ꗗ����f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int SearchStockMasterTblProc(object cndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            // �f�[�^�Z�b�g�E�f�[�^�e�[�u������
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add(PMZAI02029AB.CreateBillListTable());
            
            try
            {
                ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl = (ExtrInfo_StockMasterTbl)cndtn;
                ExtrInfo_StockMasterTblWork extrInfo_StockMasterTblWork = new ExtrInfo_StockMasterTblWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevStockMasterTbl(extrInfo_StockMasterTbl, out extrInfo_StockMasterTblWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                status = this._iStockMasterTblDB.Search(out retList, (object)extrInfo_StockMasterTblWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevPrintData(extrInfo_StockMasterTbl, (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (_printDataSet.Tables[PMZAI02029AB.CT_Tbl_StockList].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�݌Ƀ}�X�^�ꗗ����f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� �f�[�^�W�J����
        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">UI���o�����N���X</param>
        /// <param name="extrInfo_StockMasterTblWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevStockMasterTbl(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl, out ExtrInfo_StockMasterTblWork extrInfo_StockMasterTblWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            extrInfo_StockMasterTblWork = new ExtrInfo_StockMasterTblWork();

            try
            {
                extrInfo_StockMasterTblWork.EnterpriseCode = extrInfo_StockMasterTbl.EnterpriseCode;                // ��ƃR�[�h

                extrInfo_StockMasterTblWork.St_WarehouseCode = extrInfo_StockMasterTbl.St_WarehouseCode;            // �J�n�q�ɃR�[�h
                extrInfo_StockMasterTblWork.Ed_WarehouseCode = extrInfo_StockMasterTbl.Ed_WarehouseCode;            // �I���q�ɃR�[�h
                extrInfo_StockMasterTblWork.St_WarehouseShelfNo = extrInfo_StockMasterTbl.St_WarehouseShelfNo;      // �J�n�I��
                extrInfo_StockMasterTblWork.Ed_WarehouseShelfNo = extrInfo_StockMasterTbl.Ed_WarehouseShelfNo;	    // �I���I��
                // DEL 2009/06/04 ------>>>
                //extrInfo_StockMasterTblWork.St_SupplierCd = extrInfo_StockMasterTbl.St_SupplierCd;	              // �J�n�d����R�[�h
                //extrInfo_StockMasterTblWork.Ed_SupplierCd = extrInfo_StockMasterTbl.Ed_SupplierCd;                  // �I���d����R�[�h
                // DEL 2009/06/04 ------<<<
                extrInfo_StockMasterTblWork.St_GoodsMakerCd = extrInfo_StockMasterTbl.St_GoodsMakerCd;	            // �J�n���[�J�[�R�[�h
                extrInfo_StockMasterTblWork.Ed_GoodsMakerCd = extrInfo_StockMasterTbl.Ed_GoodsMakerCd;	            // �I�����[�J�[�R�[�h
                extrInfo_StockMasterTblWork.St_GoodsLGroup = extrInfo_StockMasterTbl.St_GoodsLGroup;	            // �J�n���i�啪��
                extrInfo_StockMasterTblWork.Ed_GoodsLGroup = extrInfo_StockMasterTbl.Ed_GoodsLGroup;	            // �I�����i�啪��
                extrInfo_StockMasterTblWork.St_GoodsMGroup = extrInfo_StockMasterTbl.St_GoodsMGroup;	            // �J�n���i������
                extrInfo_StockMasterTblWork.Ed_GoodsMGroup = extrInfo_StockMasterTbl.Ed_GoodsMGroup;	            // �I�����i������
                extrInfo_StockMasterTblWork.St_BLGroupCode = extrInfo_StockMasterTbl.St_BLGroupCode;	            // �J�n�O���[�v�R�[�h
                extrInfo_StockMasterTblWork.Ed_BLGroupCode = extrInfo_StockMasterTbl.Ed_BLGroupCode;	            // �I���O���[�v�R�[�h
                extrInfo_StockMasterTblWork.St_BLGoodsCode = extrInfo_StockMasterTbl.St_BLGoodsCode;	            // �J�nBL�R�[�h
                extrInfo_StockMasterTblWork.Ed_BLGoodsCode = extrInfo_StockMasterTbl.Ed_BLGoodsCode;	            // �I��BL�R�[�h
                extrInfo_StockMasterTblWork.St_GoodsNo = extrInfo_StockMasterTbl.St_GoodsNo;	                    // �J�n�i��
                extrInfo_StockMasterTblWork.Ed_GoodsNo = extrInfo_StockMasterTbl.Ed_GoodsNo;	                    // �I���i��
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region [�擾�f�[�^�W�J����]
        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="billCndtn">UI���o�����N���X</param>
        /// <param name="printList">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private void DevPrintData(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl, ArrayList printList)
        {
            DataTable table = _printDataSet.Tables[PMZAI02029AB.CT_Tbl_StockList];

            int regNo = 0;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            # region [�}�X�^�W�J]
            // �[���ԍ��i���W�ԍ��j
            PosTerminalMg posTerminalMg;
            if (GetPosTerminalMg(out posTerminalMg, extrInfo_StockMasterTbl.EnterpriseCode) == 0)
            {
                regNo = posTerminalMg.CashRegisterNo;
            }
            # endregion

            // �d����R�[�h�ݒ�
            ArrayList updPrintList = new ArrayList();
            foreach (RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork in printList)
            {
                if (rsltInfo_StockMasterTblWork.SupplierCd != 0)
                {
                    // �ݒ��
                    // TODO �d���於�̎擾
                }
                else
                {
                    // ���ݒ�
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    GetGoodsMngInfo(ref goodsUnitData, rsltInfo_StockMasterTblWork);
                    if (goodsUnitData != null)
                    {
                        rsltInfo_StockMasterTblWork.SupplierCd = goodsUnitData.SupplierCd;
                        rsltInfo_StockMasterTblWork.SupplierSnm = goodsUnitData.SupplierSnm;
                    }
                }

                if (CheckSupplierCd(extrInfo_StockMasterTbl, rsltInfo_StockMasterTblWork.SupplierCd))
                {
                    // ���o�Ώۂ̎d����
                    updPrintList.Add(rsltInfo_StockMasterTblWork);
                }
            }

            // ADD 2009/06/04 ------>>>
            if (updPrintList.Count == 0)
            {
                // ���o�Ώۂ��O���̏ꍇ�͏����I��
                return;
            }
            // ADD 2009/06/04 ------<<<
                
            // ���i���擾�̂��ߏ��i�A�N�Z�X�N���X���珤�i�A���f�[�^���擾
            SetCacheGoodsUnitDataList(updPrintList);

            // 2009.03.09 30413 ���� ���P���̎Z�o�������C�� >>>>>>START
            // �����P���|���}�[�N�̃f�B�N�V���i���[
            Dictionary<string, string> costUnPrcRateMarkDic = new Dictionary<string, string>();

            // ���i�̐ݒ�
            ArrayList updPricePrintList = new ArrayList();
            foreach (RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork in updPrintList)
            {
                GoodsPrice wkGoodsPrice;
                GoodsUnitData wkGoodsUnitData;
                // ���i���̎擾
                GetListPrice(rsltInfo_StockMasterTblWork, out wkGoodsPrice, out wkGoodsUnitData);
                rsltInfo_StockMasterTblWork.ListPrice = wkGoodsPrice.ListPrice;
                //rsltInfo_StockMasterTblWork.SalesUnitCost = wkGoodsPrice.SalesUnitCost;

                // ���P���̎Z�o
                if (wkGoodsPrice.PriceStartDate != DateTime.MinValue)
                {
                    UnitPriceCalcRet unitPriceCalcRet;
                    CalculateUnitCost(rsltInfo_StockMasterTblWork, wkGoodsUnitData, _taxRate, out unitPriceCalcRet);
                    rsltInfo_StockMasterTblWork.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                    if ((wkGoodsPrice.SalesUnitCost == 0) && (wkGoodsPrice.StockRate == 0))
                    {
                        if (unitPriceCalcRet.RateVal != 0.0)
                        {
                            // �|���}�X�^����Z�o�������P��
                            string key = PMZAI02029AB.CreateKey(rsltInfo_StockMasterTblWork);
                            if (!costUnPrcRateMarkDic.ContainsKey(key))
                            {
                                costUnPrcRateMarkDic.Add(key, "*");
                            }
                        }
                    }
                }
                else
                {
                    rsltInfo_StockMasterTblWork.SalesUnitCost = wkGoodsPrice.SalesUnitCost;
                }
                // 2009.03.09 30413 ���� ���P���̎Z�o�������C�� <<<<<<END

                updPricePrintList.Add(rsltInfo_StockMasterTblWork);
            }
            
            // �R�s�[����
            PMZAI02029AB.CopyToBillListTable(ref table, extrInfo_StockMasterTbl, updPricePrintList, regNo, sectionCode, costUnPrcRateMarkDic);
        }
        #endregion

        #region [�v�����^�ݒ�擾]
        /// <summary>
        /// �v�����^�ݒ�@�S�擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="prinm">�v�����^��</param>
        /// <returns></returns>
        /// <remarks>���v�����^�Ǘ��ݒ�̓��[�J���w�l�k��ǂݍ��݂܂��B</remarks>
        public List<PrtManage> SearchAllPrtManage(string enterpriseCode, string prinm)
        {
            PrtManageAcs _prtManageAcs = new PrtManageAcs();

            List<PrtManage> prtManageList = new List<PrtManage>();

            ArrayList retList;
            _prtManageAcs.SearchAll(out retList, enterpriseCode);

            foreach (PrtManage prtManage in retList)
            {
                if ((prtManage.LogicalDeleteCode == 0) || (prtManage.PrinterName.TrimEnd() == prinm.TrimEnd()))
                {
                    prtManageList.Add(prtManage);
                }
            }

            return prtManageList;
        }
        #endregion

        #region [�[���ݒ�擾]
        /// <summary>
        /// �[���ݒ�擾����
        /// </summary>
        /// <param name="posTerminalMg">POS�[���Ǘ��ݒ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion
        #endregion �� �f�[�^�W�J����

        #region �� �ݒ�}�X�^�擾
        /// <summary>
        /// ������̃}�X�^�f�[�^�擾
        /// </summary>
        /// <param name="retMList">������̃}�X�^�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prpid">�v���O����ID</param>
        /// <param name="prinm">�v�����^��</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������̃}�X�^�f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int SearchMasterDataProc(out ArrayList retMList, string enterpriseCode, string prpid, string prinm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            retMList = new ArrayList();

            // �`�[����ݒ�}�X�^�擾
            List<SlipPrtSetWork> slipPrtSetWorkList = new List<SlipPrtSetWork>();
            SlipPrtSetWork paraSlipPrtSetWork = new SlipPrtSetWork();
            paraSlipPrtSetWork.EnterpriseCode = enterpriseCode;
            status = this.SearchSlipPrtSetProc(out slipPrtSetWorkList, paraSlipPrtSetWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMList.Add(slipPrtSetWorkList);
            }
            else
            {
                return status;
            }

            // �`�[�^�C�v�Ǘ��ݒ�}�X�^�擾
            List<CustSlipMngWork> custSlipMngWorkList = new List<CustSlipMngWork>();
            CustSlipMngWork paraCustSlipMngWork = new CustSlipMngWork();
            paraCustSlipMngWork.EnterpriseCode = enterpriseCode;
            status = this.SearchCustSlipMngProc(out custSlipMngWorkList, paraCustSlipMngWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMList.Add(custSlipMngWorkList);
            }
            else
            {
                return status;
            }

            // ���R���[�󎚈ʒu�ݒ�}�X�^�擾
            List<FrePrtPSetWork> frePrtPSetWorkList = new List<FrePrtPSetWork>();
            List<FrePprSrtOWork> frePprSrtOWorkList = new List<FrePprSrtOWork>();   // ADD 2009/04/27
            //status = this.SearchFrePrtPSetProc(out frePrtPSetWorkList, enterpriseCode, prpid);    // DEL 2009/04/27
            status = this.SearchFrePrtPSetProc(out frePrtPSetWorkList, out frePprSrtOWorkList, enterpriseCode, prpid);  // ADD 2009/04/27
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMList.Add(frePrtPSetWorkList);
                retMList.Add(frePprSrtOWorkList);   // ADD 2009/04/27
            }
            else
            {
                return status;
            }

            // �v�����^�ݒ胊�X�g
            List<PrtManage> prtManageList = null;
            prtManageList = SearchAllPrtManage(enterpriseCode, prinm);
            if (prtManageList != null)
            {
                retMList.Add(prtManageList);
            }

            return status;
        }
        #endregion

        #region ���`�[����ݒ�}�X�^�擾
        /// <summary>
        /// �`�[����ݒ�}�X�^�擾
        /// </summary>
        /// <param name="slipPrtSetWorkList">���o�f�[�^���X�g</param>
        /// <param name="paraSlipPrtSetWork">���o����</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ݒ�}�X�^�̃f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private int SearchSlipPrtSetProc(out List<SlipPrtSetWork> slipPrtSetWorkList, SlipPrtSetWork paraSlipPrtSetWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            object retObj = new object();
            object paraObj = paraSlipPrtSetWork;

            slipPrtSetWorkList = new List<SlipPrtSetWork>();

            ISlipPrtSetDB iSlipPrtSetDB = (ISlipPrtSetDB)MediationSlipPrtSetDB.GetSlipPrtSetDB();

            status = iSlipPrtSetDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == 0)
            {
                foreach (SlipPrtSetWork slipPrtSetWork in retObj as ArrayList)
                {
                    if (slipPrtSetWorkList.Contains(slipPrtSetWork))
                    {
                        slipPrtSetWorkList.Remove(slipPrtSetWork);
                    }
                    slipPrtSetWorkList.Add(slipPrtSetWork);
                }
            }

            return status;
        }
        #endregion �� �`�[����ݒ�}�X�^�擾

        #region ���`�[�^�C�v�Ǘ��ݒ�}�X�^�擾
        /// <summary>
        /// �`�[�^�C�v�Ǘ��ݒ�}�X�^�擾
        /// </summary>
        /// <param name="custSlipMngWorkList">���o�f�[�^���X�g</param>
        /// <param name="paraCustSlipMngWork">���o����</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �`�[�^�C�v�Ǘ��ݒ�}�X�^�̃f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private int SearchCustSlipMngProc(out List<CustSlipMngWork> custSlipMngWorkList, CustSlipMngWork paraCustSlipMngWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            object retObj = new object();
            object paraObj = paraCustSlipMngWork;

            custSlipMngWorkList = new List<CustSlipMngWork>();

            ICustSlipMngDB iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();

            status = iCustSlipMngDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == 0)
            {
                foreach (CustSlipMngWork custSlipMngWork in retObj as ArrayList)
                {
                    if (custSlipMngWorkList.Contains(custSlipMngWork))
                    {
                        custSlipMngWorkList.Remove(custSlipMngWork);
                    }
                    custSlipMngWorkList.Add(custSlipMngWork);
                }
            }

            return status;
        }
        #endregion �� �`�[�^�C�v�Ǘ��ݒ�}�X�^�擾

        #region �����R���[�󎚈ʒu�ݒ�}�X�^�擾
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�}�X�^�擾
        /// </summary>
        /// <param name="frePrtPSetWorkList">���o�f�[�^���X�g</param>
        /// <param name="frePprSrtOWorkList">�\�[�g���ݒ胊�X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prpid">�v���O����ID</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�󎚈ʒu�ݒ�}�X�^�̃f�[�^���擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        //private int SearchFrePrtPSetProc(out List<FrePrtPSetWork> frePrtPSetWorkList, string enterpriseCode, string prpid)    // DEL 2009/04/27
        private int SearchFrePrtPSetProc(out List<FrePrtPSetWork> frePrtPSetWorkList, out List<FrePprSrtOWork> frePprSrtOWorkList, string enterpriseCode, string prpid)     // ADD 2009/04/27
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            object retObj = new object();
            byte[] printPos = null;
            bool msgDiv = true;
            string errMsg = "";

            frePrtPSetWorkList = new List<FrePrtPSetWork>();
            frePprSrtOWorkList = new List<FrePprSrtOWork>();    // ADD 2009/04/27

            IFrePrtPSetDB iFrePrtPSetDB = (IFrePrtPSetDB)MediationFrePrtPSetDB.GetFrePrtPSetDB();

            status = iFrePrtPSetDB.Read(enterpriseCode, prpid, 0, out retObj, out printPos, out msgDiv, out errMsg);

            if (status == 0)
            {
                foreach (ArrayList retList in retObj as CustomSerializeArrayList)
                {
                    // DEL 2009/04/27 ------>>>
                    //foreach (FrePrtPSetWork frePrtPSetWork in retList)
                    //{
                    //    frePrtPSetWork.PrintPosClassData = printPos;
                    //    if (frePrtPSetWorkList.Contains(frePrtPSetWork))
                    //    {
                    //        frePrtPSetWorkList.Remove(frePrtPSetWork);
                    //    }
                    //    // �󎚈ʒu�f�[�^�𕜍�������
                    //    //�i�����ӁFfrePrtPSet�X�V��frePrtPSetList�̊Y�����R�[�h�X�V���Ӗ����܂��j
                    //    FrePrtSettingController.DecryptPrintPosClassData(frePrtPSetWork);
                    //    frePrtPSetWorkList.Add(frePrtPSetWork);
                    //}
                    // DEL 2009/04/27 ------<<<

                    // ADD 2009/04/27 ------>>>
                    if (retList[0] is FrePrtPSetWork)
                    {
                        foreach (FrePrtPSetWork frePrtPSetWork in retList)
                        {
                            frePrtPSetWork.PrintPosClassData = printPos;
                            if (frePrtPSetWorkList.Contains(frePrtPSetWork))
                            {
                                frePrtPSetWorkList.Remove(frePrtPSetWork);
                            }
                            // �󎚈ʒu�f�[�^�𕜍�������
                            //�i�����ӁFfrePrtPSet�X�V��frePrtPSetList�̊Y�����R�[�h�X�V���Ӗ����܂��j
                            FrePrtSettingController.DecryptPrintPosClassData(frePrtPSetWork);
                            frePrtPSetWorkList.Add(frePrtPSetWork);
                        }
                    }
                    else if (retList[0] is FrePprSrtOWork)
                    {
                        frePprSrtOWorkList.AddRange((FrePprSrtOWork[])retList.ToArray(typeof(FrePprSrtOWork)));
                    }
                    // ADD 2009/04/27 ------<<<
                }
            }

            return status;
        }
        #endregion �� ���R���[�󎚈ʒu�ݒ�}�X�^�擾

        #region ���i�A�N�Z�X�N���X(���i�Ǘ����擾)
        /// <summary>
        /// ���i�A�N�Z�X�N���X(���i�Ǘ����擾)
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^�N���X</param>
        /// <param name="autoOrderResultWork">���o���ʃf�[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ������擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private void GetGoodsMngInfo(ref GoodsUnitData goodsUnitData, RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork)
        {
            // ���o�����ݒ�
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;             // ��ƃR�[�h
            goodsUnitData.SectionCode = rsltInfo_StockMasterTblWork.SectionCode;            // ���_�R�[�h
            goodsUnitData.GoodsMakerCd = rsltInfo_StockMasterTblWork.GoodsMakerCd;          // ���[�J�[�R�[�h
            goodsUnitData.GoodsNo = rsltInfo_StockMasterTblWork.GoodsNo;                    // �i��
            goodsUnitData.BLGoodsCode = rsltInfo_StockMasterTblWork.BLGoodsCode;            // BL�R�[�h
            goodsUnitData.GoodsMGroup = rsltInfo_StockMasterTblWork.GoodsMGroup;            // ���i������

            // ���i�Ǘ����̎擾
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
        }
        #endregion

        #region �d����̒��o�����`�F�b�N
        /// <summary>
        /// �d����̒��o�����`�F�b�N
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">���o����</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <remarks>
        /// <br>Note       : �d���悪���o�����ƈ�v���邩�`�F�b�N�B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private bool CheckSupplierCd(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl, int supplierCd)
        {
            int ed_SupplierCode = extrInfo_StockMasterTbl.Ed_SupplierCd;
            if (ed_SupplierCode == 0)
            {
                // �I�����ݒ�
                ed_SupplierCode = 999999;
            }

            if ((extrInfo_StockMasterTbl.St_SupplierCd <= supplierCd) && (supplierCd <= ed_SupplierCode))
            {
                // ���o�Ώ�
                return true;
            }
            else
            {
                // ���o�ΏۊO
                return false;
            }
        }
        #endregion

        #region ���i�A���f�[�^�̃L���b�V����
        /// <summary>
        /// ���i�A���f�[�^�̃L���b�V����
        /// </summary>
        /// <param name="printList">���o����</param>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^�̃L���b�V����</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private void SetCacheGoodsUnitDataList(ArrayList printList)
        {
            GoodsAcs goodsAcs = new GoodsAcs();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            string message = "";
            goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);

            foreach (RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork in printList)
            {
                // ���i�A�N�Z�X�N���X�̒��o������ݒ�
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //workGoodsCndtn.SectionCode = rsltInfo_StockMasterTblWork.SectionCode.Trim();          // DEL 2009/05/21
                workGoodsCndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ADD 2009/05/21 ���O�C�����_
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = rsltInfo_StockMasterTblWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = rsltInfo_StockMasterTblWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

                goodsCndtnList.Add(workGoodsCndtn);
            }

            // ���[�J���L���b�V��������
            _goodsUnitDataListList = new List<List<GoodsUnitData>>();
            _goodsUnitDataList = new Dictionary<string, GoodsUnitData>();       // ADD 2009/04/20

            // ���������������S��v�ŏ��i�����擾
            int status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out _goodsUnitDataListList, out message);
            // DEL 2009/04/20 ------>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    _goodsUnitDataListList = null;
            //}
            // DEL 2009/04/20 ------<<<

            // ADD 2009/04/20 ------>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
                {
                    // DEL 2009/05/21 ------>>>
                    //string key = wkGoodsUnitDataList[0].SectionCode.TrimEnd() + "-"
                    //           + wkGoodsUnitDataList[0].GoodsNo + "-"
                    //           + wkGoodsUnitDataList[0].GoodsMakerCd.ToString("0000");
                    // DEL 2009/05/21 ------<<<

                    if (wkGoodsUnitDataList[0].SectionCode.Trim() != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                    {
                        string section = wkGoodsUnitDataList[0].SectionCode.Trim();
                    }

                    // ADD 2009/05/21 ------>>>
                    // �L�[��i�ԁ{���[�J�[�ɏC��
                    string key = wkGoodsUnitDataList[0].GoodsNo + "-"
                               + wkGoodsUnitDataList[0].GoodsMakerCd.ToString("0000");
                    // ADD 2009/05/21 ------<<<
                    
                    if (!_goodsUnitDataList.ContainsKey(key))
                    {
                        _goodsUnitDataList.Add(key, wkGoodsUnitDataList[0]);
                    }
                }
            }
            // ADD 2009/04/20 ------<<<
        }
        #endregion

        #region ���i���̎擾
        /// <summary>
        /// ���i���̎擾
        /// </summary>
        /// <param name="printList">���o����</param>
        /// <remarks>
        /// <br>Note       : ���i���}�X�^���擾���܂�</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private void GetListPrice(RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork, out GoodsPrice goodsPrice, out GoodsUnitData goodsUnitData)
        {
            goodsPrice = new GoodsPrice();
            goodsUnitData = new GoodsUnitData();

            // DEL 2009/04/20 ------>>>
            //if (_goodsUnitDataListList == null)
            //{
            //    return;
            //}

            //string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);

            //foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
            //{
            //    foreach (GoodsUnitData wkGoodsUnitData in wkGoodsUnitDataList)
            //    {
            //        List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

            //        foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
            //        {
            //            if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
            //                (wkGoodsPrice.GoodsMakerCd == rsltInfo_StockMasterTblWork.GoodsMakerCd) &&
            //                (wkGoodsPrice.GoodsNo == rsltInfo_StockMasterTblWork.GoodsNo))
            //            {
            //                goodsPrice = wkGoodsPrice.Clone();
            //                goodsUnitData = wkGoodsUnitData.Clone();
            //                return;
            //            }
            //        }
            //    }
            //}
            // DEL 2009/04/20 ------<<<

            // ADD 2009/04/20 ------>>>
            if (_goodsUnitDataList.Count == 0)
            {
                return;
            }

            string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // DEL 2009/05/21 ------>>>
            //string key = rsltInfo_StockMasterTblWork.SectionCode.TrimEnd() + "-"
            //           + rsltInfo_StockMasterTblWork.GoodsNo + "-"
            //           + rsltInfo_StockMasterTblWork.GoodsMakerCd.ToString("0000");
            // DEL 2009/05/21 ------>>>
            
            // ADD 2009/05/21 ------>>>
            // �L�[��i�ԁ{���[�J�[�ɏC��
            string key = rsltInfo_StockMasterTblWork.GoodsNo + "-"
                       + rsltInfo_StockMasterTblWork.GoodsMakerCd.ToString("0000");
            // ADD 2009/05/21 ------<<<
            
            if (_goodsUnitDataList.ContainsKey(key))
            {
                GoodsUnitData wkGoodsUnitData = _goodsUnitDataList[key];

                List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

                foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
                {
                    if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
                        (wkGoodsPrice.GoodsMakerCd == rsltInfo_StockMasterTblWork.GoodsMakerCd) &&
                        (wkGoodsPrice.GoodsNo == rsltInfo_StockMasterTblWork.GoodsNo))
                    {
                        goodsPrice = wkGoodsPrice.Clone();
                        goodsUnitData = wkGoodsUnitData.Clone();
                        return;
                    }
                }
            }
            // ADD 2009/04/20 ------<<<
        
            return;
        }
        #endregion

        #region �ŗ��ݒ�}�X�^�A�N�Z�X�N���X(Read)
        /// <summary>
        /// �ŗ��ݒ�}�X�^�A�N�Z�X�N���X(Read)
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���N���X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�}�X�^�A�N�Z�X�N���X����ŗ��ݒ�����擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int TaxRateSetRead(out TaxRateSet taxRateSet)
        {
            int status = -1;

            // �ŗ��ݒ�����擾
            status = this._taxRateSetAcs.Read(out taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                taxRateSet = new TaxRateSet();
            }
            return status;
        }
        #endregion

        #region �ŗ��擾(�ŗ��ݒ�}�X�^)
        /// <summary>
        /// �ŗ��擾(�ŗ��ݒ�}�X�^)
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���</param>
        /// <param name="targetDate">�ŗ��K�p��</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        /// <remarks>
        /// <br>Note       : �ŗ��擾��񂩂�ŗ����擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
        #endregion

        #region �����P���v�Z����(�P���Z�o���W���[��)
        /// <summary>
        /// �����f�[�^�ݒ菈��(�P���Z�o���W���[��)
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �P���Z�o���W���[���̏����f�[�^��ݒ�����܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.03.09</br>
        /// </remarks>
        private void ReadInitData()
        {
            int status = -1;
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList returnStockProcMoney;

            // �d�����z�f�[�^�̎擾
            status = stockProcMoneyAcs.Search(out returnStockProcMoney, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            // �d�����z�[�������敪�ݒ�}�X�^�L���b�V������
            _unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// �����P���v�Z����(�P���Z�o���W���[��)
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="unitPriceCalcRet">�P���v�Z����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����P���v�Z���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.03.09</br>
        /// </remarks>
        private void CalculateUnitCost(RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork, GoodsUnitData goodsUnitData, double taxRate, out UnitPriceCalcRet unitPriceCalcRet)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList;
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcRet = new UnitPriceCalcRet();
            
            // �p�����[�^�ݒ�
            //unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode.TrimEnd();           // ���_�R�[�h // DEL 2013/06/18 gaofeng for Redmine#36533
            unitPriceCalcParam.SectionCode = rsltInfo_StockMasterTblWork.SectionCode.TrimEnd();// �݌ɊǗ����_��ݒ� // ADD 2013/06/18 gaofeng for Redmine#36533
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // �i��
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = rsltInfo_StockMasterTblWork.SupplierCd;         // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = DateTime.Now;                               // ���i�K�p��
            unitPriceCalcParam.CountFl = 1.0;                                               // ����            
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // �ېŋ敪
            unitPriceCalcParam.TaxRate = taxRate;                                           // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;   // �d������Œ[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;     // �d���P���[�������R�[�h
            
            // �����P���v�Z����
            _unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // �����P�����擾
                    unitPriceCalcRet = unitPriceCalcRetWk;
                    return;
                }
            }
        }
        #endregion

        // ---  ADD 2013/06/18 gaofeng for Redmine#36533 ------- >>>>>
        /// <summary>
        /// �|���D��敪�ɒǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���D��敪�ɒǉ�����B</br>
        /// </remarks>
        public void SetUnitPriceCalculation(string enterpriseCode)
        {

            this._companyInfAcs.Read(out this._companyInf, enterpriseCode);

            // �|���D��敪
            if (this._companyInf != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._companyInf.RatePriorityDiv;
            }
        }
        // ---  ADD 2013/06/18 gaofeng for Redmine#36533 ------- <<<<<

        #endregion �� Private Method

    }
}
