//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : �d���f�[�^�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d���f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
    public partial class UoeSndRcvJnlAcs
	{
        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        # region �d���f�[�^�ǉ����f�[�^�N���X���f�[�^�[�e�[�u����
        /// <summary>
        /// �d���f�[�^�ǉ����f�[�^�N���X���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="rst">�d���f�[�^</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertTableFromStockSlipWork(DataTable tbl, StockSlipWork stockSlipWork, string commonSlipNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = tbl.NewRow();
                CreateStockSlipSchema(ref dr, stockSlipWork, commonSlipNo);
                tbl.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �d���f�[�^�X�V���f�[�^�N���X���f�[�^�[�e�[�u����
        /// <summary>
        /// �d���f�[�^�X�V���f�[�^�N���X���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="rst">�d���f�[�^</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromStockSlipWork(DataTable tbl, StockSlipWork stockSlipWork, string commonSlipNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockSlipRow = FindStockSlipDataTable(tbl, stockSlipWork.SupplierFormal, commonSlipNo, out message);

                //�d���f�[�^DataTable�̍X�V
                if (stockSlipRow != null)
                {
                    CreateStockSlipSchema(ref stockSlipRow, stockSlipWork);
                }
                //�d���f�[�^DataTable�̒ǉ�
                else
                {
                    status = InsertTableFromStockSlipWork(tbl, stockSlipWork, commonSlipNo, out message);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region �d���f�[�^�̓Ǎ�
        /// <summary>
        /// �d���f�[�^�̓Ǎ�
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�d���f�[�^</returns>
        public StockSlipWork ReadStockSlipWork(DataTable tbl, int supplierFormal, string commonSlipNo, out string message)
        {
            //�ϐ��̏�����
            StockSlipWork stockSlipWork = null;
            message = "";

            try
            {
                DataRow stockSlipRow = FindStockSlipDataTable(tbl, supplierFormal, commonSlipNo, out message);

                stockSlipWork = CreateStockSlipWorkFromSchema(stockSlipRow);
            }
            catch (Exception ex)
            {
                stockSlipWork = null;
                message = ex.Message;
            }

            return (stockSlipWork);
        }
        # endregion

        # region �d���f�[�^��DataRow �� �N���X���쐬
        /// <summary>
        /// �d���f�[�^��DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>�d���f�[�^�N���X</returns>
        public StockSlipWork CreateStockSlipWorkFromSchema(DataRow dr)
        {
            StockSlipWork rst = new StockSlipWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[StockSlipSchema.ct_Col_CreateDateTime];	// �쐬����
                rst.UpdateDateTime = (DateTime)dr[StockSlipSchema.ct_Col_UpdateDateTime];	// �X�V����
                rst.EnterpriseCode = (string)dr[StockSlipSchema.ct_Col_EnterpriseCode];	// ��ƃR�[�h
                rst.FileHeaderGuid = (Guid)dr[StockSlipSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[StockSlipSchema.ct_Col_UpdEmployeeCode];	// �X�V�]�ƈ��R�[�h
                rst.UpdAssemblyId1 = (string)dr[StockSlipSchema.ct_Col_UpdAssemblyId1];	// �X�V�A�Z���u��ID1
                rst.UpdAssemblyId2 = (string)dr[StockSlipSchema.ct_Col_UpdAssemblyId2];	// �X�V�A�Z���u��ID2
                rst.LogicalDeleteCode = (Int32)dr[StockSlipSchema.ct_Col_LogicalDeleteCode];	// �_���폜�敪
                rst.SupplierFormal = (Int32)dr[StockSlipSchema.ct_Col_SupplierFormal];	// �d���`��
                rst.SupplierSlipNo = (Int32)dr[StockSlipSchema.ct_Col_SupplierSlipNo];	// �d���`�[�ԍ�
                rst.SectionCode = (string)dr[StockSlipSchema.ct_Col_SectionCode];	// ���_�R�[�h
                rst.SubSectionCode = (Int32)dr[StockSlipSchema.ct_Col_SubSectionCode];	// ����R�[�h
                rst.DebitNoteDiv = (Int32)dr[StockSlipSchema.ct_Col_DebitNoteDiv];	// �ԓ`�敪
                rst.DebitNLnkSuppSlipNo = (Int32)dr[StockSlipSchema.ct_Col_DebitNLnkSuppSlipNo];	// �ԍ��A���d���`�[�ԍ�
                rst.SupplierSlipCd = (Int32)dr[StockSlipSchema.ct_Col_SupplierSlipCd];	// �d���`�[�敪
                rst.StockGoodsCd = (Int32)dr[StockSlipSchema.ct_Col_StockGoodsCd];	// �d�����i�敪
                rst.AccPayDivCd = (Int32)dr[StockSlipSchema.ct_Col_AccPayDivCd];	// ���|�敪
                rst.StockSectionCd = (string)dr[StockSlipSchema.ct_Col_StockSectionCd];	// �d�����_�R�[�h
                rst.StockAddUpSectionCd = (string)dr[StockSlipSchema.ct_Col_StockAddUpSectionCd];	// �d���v�㋒�_�R�[�h
                rst.StockSlipUpdateCd = (Int32)dr[StockSlipSchema.ct_Col_StockSlipUpdateCd];	// �d���`�[�X�V�敪
                rst.InputDay = (DateTime)dr[StockSlipSchema.ct_Col_InputDay];	// ���͓�
                rst.ArrivalGoodsDay = (DateTime)dr[StockSlipSchema.ct_Col_ArrivalGoodsDay];	// ���ד�
                rst.StockDate = (DateTime)dr[StockSlipSchema.ct_Col_StockDate];	// �d����
                rst.StockAddUpADate = (DateTime)dr[StockSlipSchema.ct_Col_StockAddUpADate];	// �d���v����t
                rst.DelayPaymentDiv = (Int32)dr[StockSlipSchema.ct_Col_DelayPaymentDiv];	// �����敪
                rst.PayeeCode = (Int32)dr[StockSlipSchema.ct_Col_PayeeCode];	// �x����R�[�h
                rst.PayeeSnm = (string)dr[StockSlipSchema.ct_Col_PayeeSnm];	// �x���旪��
                rst.SupplierCd = (Int32)dr[StockSlipSchema.ct_Col_SupplierCd];	// �d����R�[�h
                rst.SupplierNm1 = (string)dr[StockSlipSchema.ct_Col_SupplierNm1];	// �d���於1
                rst.SupplierNm2 = (string)dr[StockSlipSchema.ct_Col_SupplierNm2];	// �d���於2
                rst.SupplierSnm = (string)dr[StockSlipSchema.ct_Col_SupplierSnm];	// �d���旪��
                rst.BusinessTypeCode = (Int32)dr[StockSlipSchema.ct_Col_BusinessTypeCode];	// �Ǝ�R�[�h
                rst.BusinessTypeName = (string)dr[StockSlipSchema.ct_Col_BusinessTypeName];	// �Ǝ햼��
                rst.SalesAreaCode = (Int32)dr[StockSlipSchema.ct_Col_SalesAreaCode];	// �̔��G���A�R�[�h
                rst.SalesAreaName = (string)dr[StockSlipSchema.ct_Col_SalesAreaName];	// �̔��G���A����
                rst.StockInputCode = (string)dr[StockSlipSchema.ct_Col_StockInputCode];	// �d�����͎҃R�[�h
                rst.StockInputName = (string)dr[StockSlipSchema.ct_Col_StockInputName];	// �d�����͎Җ���
                rst.StockAgentCode = (string)dr[StockSlipSchema.ct_Col_StockAgentCode];	// �d���S���҃R�[�h
                rst.StockAgentName = (string)dr[StockSlipSchema.ct_Col_StockAgentName];	// �d���S���Җ���
                rst.SuppTtlAmntDspWayCd = (Int32)dr[StockSlipSchema.ct_Col_SuppTtlAmntDspWayCd];	// �d���摍�z�\�����@�敪
                rst.TtlAmntDispRateApy = (Int32)dr[StockSlipSchema.ct_Col_TtlAmntDispRateApy];	// ���z�\���|���K�p�敪
                rst.StockTotalPrice = (Int64)dr[StockSlipSchema.ct_Col_StockTotalPrice];	// �d�����z���v
                rst.StockSubttlPrice = (Int64)dr[StockSlipSchema.ct_Col_StockSubttlPrice];	// �d�����z���v
                rst.StockTtlPricTaxInc = (Int64)dr[StockSlipSchema.ct_Col_StockTtlPricTaxInc];	// �d�����z�v�i�ō��݁j
                rst.StockTtlPricTaxExc = (Int64)dr[StockSlipSchema.ct_Col_StockTtlPricTaxExc];	// �d�����z�v�i�Ŕ����j
                rst.StockNetPrice = (Int64)dr[StockSlipSchema.ct_Col_StockNetPrice];	// �d���������z
                rst.StockPriceConsTax = (Int64)dr[StockSlipSchema.ct_Col_StockPriceConsTax];	// �d�����z����Ŋz
                rst.TtlItdedStcOutTax = (Int64)dr[StockSlipSchema.ct_Col_TtlItdedStcOutTax];	// �d���O�őΏۊz���v
                rst.TtlItdedStcInTax = (Int64)dr[StockSlipSchema.ct_Col_TtlItdedStcInTax];	// �d�����őΏۊz���v
                rst.TtlItdedStcTaxFree = (Int64)dr[StockSlipSchema.ct_Col_TtlItdedStcTaxFree];	// �d����ېőΏۊz���v
                rst.StockOutTax = (Int64)dr[StockSlipSchema.ct_Col_StockOutTax];	// �d�����z����Ŋz�i�O�Łj
                rst.StckPrcConsTaxInclu = (Int64)dr[StockSlipSchema.ct_Col_StckPrcConsTaxInclu];	// �d�����z����Ŋz�i���Łj
                rst.StckDisTtlTaxExc = (Int64)dr[StockSlipSchema.ct_Col_StckDisTtlTaxExc];	// �d���l�����z�v�i�Ŕ����j
                rst.ItdedStockDisOutTax = (Int64)dr[StockSlipSchema.ct_Col_ItdedStockDisOutTax];	// �d���l���O�őΏۊz���v
                rst.ItdedStockDisInTax = (Int64)dr[StockSlipSchema.ct_Col_ItdedStockDisInTax];	// �d���l�����őΏۊz���v
                rst.ItdedStockDisTaxFre = (Int64)dr[StockSlipSchema.ct_Col_ItdedStockDisTaxFre];	// �d���l����ېőΏۊz���v
                rst.StockDisOutTax = (Int64)dr[StockSlipSchema.ct_Col_StockDisOutTax];	// �d���l������Ŋz�i�O�Łj
                rst.StckDisTtlTaxInclu = (Int64)dr[StockSlipSchema.ct_Col_StckDisTtlTaxInclu];	// �d���l������Ŋz�i���Łj
                rst.TaxAdjust = (Int64)dr[StockSlipSchema.ct_Col_TaxAdjust];	// ����Œ����z
                rst.BalanceAdjust = (Int64)dr[StockSlipSchema.ct_Col_BalanceAdjust];	// �c�������z
                rst.SuppCTaxLayCd = (Int32)dr[StockSlipSchema.ct_Col_SuppCTaxLayCd];	// �d�������œ]�ŕ����R�[�h
                rst.SupplierConsTaxRate = (Double)dr[StockSlipSchema.ct_Col_SupplierConsTaxRate];	// �d�������Őŗ�
                rst.AccPayConsTax = (Int64)dr[StockSlipSchema.ct_Col_AccPayConsTax];	// ���|�����
                rst.StockFractionProcCd = (Int32)dr[StockSlipSchema.ct_Col_StockFractionProcCd];	// �d���[�������敪
                rst.AutoPayment = (Int32)dr[StockSlipSchema.ct_Col_AutoPayment];	// �����x���敪
                rst.AutoPaySlipNum = (Int32)dr[StockSlipSchema.ct_Col_AutoPaySlipNum];	// �����x���`�[�ԍ�
                rst.RetGoodsReasonDiv = (Int32)dr[StockSlipSchema.ct_Col_RetGoodsReasonDiv];	// �ԕi���R�R�[�h
                rst.RetGoodsReason = (string)dr[StockSlipSchema.ct_Col_RetGoodsReason];	// �ԕi���R
                rst.PartySaleSlipNum = (string)dr[StockSlipSchema.ct_Col_PartySaleSlipNum];	// �����`�[�ԍ�
                rst.SupplierSlipNote1 = (string)dr[StockSlipSchema.ct_Col_SupplierSlipNote1];	// �d���`�[���l1
                rst.SupplierSlipNote2 = (string)dr[StockSlipSchema.ct_Col_SupplierSlipNote2];	// �d���`�[���l2
                rst.DetailRowCount = (Int32)dr[StockSlipSchema.ct_Col_DetailRowCount];	// ���׍s��
                rst.EdiSendDate = (DateTime)dr[StockSlipSchema.ct_Col_EdiSendDate];	// �d�c�h���M��
                rst.EdiTakeInDate = (DateTime)dr[StockSlipSchema.ct_Col_EdiTakeInDate];	// �d�c�h�捞��
                rst.UoeRemark1 = (string)dr[StockSlipSchema.ct_Col_UoeRemark1];	// �t�n�d���}�[�N�P
                rst.UoeRemark2 = (string)dr[StockSlipSchema.ct_Col_UoeRemark2];	// �t�n�d���}�[�N�Q
                rst.SlipPrintDivCd = (Int32)dr[StockSlipSchema.ct_Col_SlipPrintDivCd];	// �`�[���s�敪
                rst.SlipPrintFinishCd = (Int32)dr[StockSlipSchema.ct_Col_SlipPrintFinishCd];	// �`�[���s�ϋ敪
                rst.StockSlipPrintDate = (DateTime)dr[StockSlipSchema.ct_Col_StockSlipPrintDate];	// �d���`�[���s��
                rst.SlipPrtSetPaperId = (string)dr[StockSlipSchema.ct_Col_SlipPrtSetPaperId];	// �`�[����ݒ�p���[ID
                rst.SlipAddressDiv = (Int32)dr[StockSlipSchema.ct_Col_SlipAddressDiv];	// �`�[�Z���敪
                rst.AddresseeCode = (Int32)dr[StockSlipSchema.ct_Col_AddresseeCode];	// �[�i��R�[�h
                rst.AddresseeName = (string)dr[StockSlipSchema.ct_Col_AddresseeName];	// �[�i�於��
                rst.AddresseeName2 = (string)dr[StockSlipSchema.ct_Col_AddresseeName2];	// �[�i�於��2
                rst.AddresseePostNo = (string)dr[StockSlipSchema.ct_Col_AddresseePostNo];	// �[�i��X�֔ԍ�
                rst.AddresseeAddr1 = (string)dr[StockSlipSchema.ct_Col_AddresseeAddr1];	// �[�i��Z��1(�s���{���s��S�E�����E��)
                rst.AddresseeAddr3 = (string)dr[StockSlipSchema.ct_Col_AddresseeAddr3];	// �[�i��Z��3(�Ԓn)
                rst.AddresseeAddr4 = (string)dr[StockSlipSchema.ct_Col_AddresseeAddr4];	// �[�i��Z��4(�A�p�[�g����)
                rst.AddresseeTelNo = (string)dr[StockSlipSchema.ct_Col_AddresseeTelNo];	// �[�i��d�b�ԍ�
                rst.AddresseeFaxNo = (string)dr[StockSlipSchema.ct_Col_AddresseeFaxNo];	// �[�i��FAX�ԍ�
                rst.DirectSendingCd = (Int32)dr[StockSlipSchema.ct_Col_DirectSendingCd];	// �����敪
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion
        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �d���f�[�^�̌���
        /// <summary>
        /// �d�����ׂ̌���
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>DataRow</returns>
        private DataRow FindStockSlipDataTable(DataTable tbl, int supplierFormal, string commonSlipNo, out string message)
        {
            //�ϐ��̏�����
            DataRow stockSlipRow = null;
            message = "";

            try
            {
                object[] findStockSlip = new object[2];
                findStockSlip[0] = supplierFormal;
                findStockSlip[1] = commonSlipNo;
                stockSlipRow = tbl.Rows.Find(findStockSlip);
            }
            catch (Exception ex)
            {
                stockSlipRow = null;
                message = ex.Message;
            }

            return (stockSlipRow);
        }
        # endregion

        # region �d���f�[�^�e�[�u��Row�쐬��UOE�����ԍ�(���[�j�[�N�ԍ�)�X�V���聄
        /// <summary>
        /// �d���f�[�^�e�[�u��Row�쐬��UOE�����ԍ�(���[�j�[�N�ԍ�)�X�V���聄
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�d���f�[�^�N���X</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        private void CreateStockSlipSchema(ref DataRow dr, StockSlipWork rst, string commonSlipNo)
        {
            CreateStockSlipSchema(ref dr, rst);

            dr[StockSlipSchema.ct_Col_CommonSlipNo] = commonSlipNo;   //���ʓ`�[�ԍ�
        }
        # endregion

        # region �d���f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// �d���f�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�d���f�[�^�N���X</param>
        private void CreateStockSlipSchema(ref DataRow dr, StockSlipWork rst)
        {
            dr[StockSlipSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// �쐬����
            dr[StockSlipSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// �X�V����
            dr[StockSlipSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// ��ƃR�[�h
            dr[StockSlipSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[StockSlipSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
            dr[StockSlipSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
            dr[StockSlipSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
            dr[StockSlipSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// �_���폜�敪
            dr[StockSlipSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// �d���`��
            dr[StockSlipSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// �d���`�[�ԍ�
            dr[StockSlipSchema.ct_Col_SectionCode] = rst.SectionCode;	// ���_�R�[�h
            dr[StockSlipSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// ����R�[�h
            dr[StockSlipSchema.ct_Col_DebitNoteDiv] = rst.DebitNoteDiv;	// �ԓ`�敪
            dr[StockSlipSchema.ct_Col_DebitNLnkSuppSlipNo] = rst.DebitNLnkSuppSlipNo;	// �ԍ��A���d���`�[�ԍ�
            dr[StockSlipSchema.ct_Col_SupplierSlipCd] = rst.SupplierSlipCd;	// �d���`�[�敪
            dr[StockSlipSchema.ct_Col_StockGoodsCd] = rst.StockGoodsCd;	// �d�����i�敪
            dr[StockSlipSchema.ct_Col_AccPayDivCd] = rst.AccPayDivCd;	// ���|�敪
            dr[StockSlipSchema.ct_Col_StockSectionCd] = rst.StockSectionCd;	// �d�����_�R�[�h
            dr[StockSlipSchema.ct_Col_StockAddUpSectionCd] = rst.StockAddUpSectionCd;	// �d���v�㋒�_�R�[�h
            dr[StockSlipSchema.ct_Col_StockSlipUpdateCd] = rst.StockSlipUpdateCd;	// �d���`�[�X�V�敪
            dr[StockSlipSchema.ct_Col_InputDay] = rst.InputDay;	// ���͓�
            dr[StockSlipSchema.ct_Col_ArrivalGoodsDay] = rst.ArrivalGoodsDay;	// ���ד�
            dr[StockSlipSchema.ct_Col_StockDate] = rst.StockDate;	// �d����
            dr[StockSlipSchema.ct_Col_StockAddUpADate] = rst.StockAddUpADate;	// �d���v����t
            dr[StockSlipSchema.ct_Col_DelayPaymentDiv] = rst.DelayPaymentDiv;	// �����敪
            dr[StockSlipSchema.ct_Col_PayeeCode] = rst.PayeeCode;	// �x����R�[�h
            dr[StockSlipSchema.ct_Col_PayeeSnm] = rst.PayeeSnm;	// �x���旪��
            dr[StockSlipSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// �d����R�[�h
            dr[StockSlipSchema.ct_Col_SupplierNm1] = rst.SupplierNm1;	// �d���於1
            dr[StockSlipSchema.ct_Col_SupplierNm2] = rst.SupplierNm2;	// �d���於2
            dr[StockSlipSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// �d���旪��
            dr[StockSlipSchema.ct_Col_BusinessTypeCode] = rst.BusinessTypeCode;	// �Ǝ�R�[�h
            dr[StockSlipSchema.ct_Col_BusinessTypeName] = rst.BusinessTypeName;	// �Ǝ햼��
            dr[StockSlipSchema.ct_Col_SalesAreaCode] = rst.SalesAreaCode;	// �̔��G���A�R�[�h
            dr[StockSlipSchema.ct_Col_SalesAreaName] = rst.SalesAreaName;	// �̔��G���A����
            dr[StockSlipSchema.ct_Col_StockInputCode] = rst.StockInputCode;	// �d�����͎҃R�[�h
            dr[StockSlipSchema.ct_Col_StockInputName] = rst.StockInputName;	// �d�����͎Җ���
            dr[StockSlipSchema.ct_Col_StockAgentCode] = rst.StockAgentCode;	// �d���S���҃R�[�h
            dr[StockSlipSchema.ct_Col_StockAgentName] = rst.StockAgentName;	// �d���S���Җ���
            dr[StockSlipSchema.ct_Col_SuppTtlAmntDspWayCd] = rst.SuppTtlAmntDspWayCd;	// �d���摍�z�\�����@�敪
            dr[StockSlipSchema.ct_Col_TtlAmntDispRateApy] = rst.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
            dr[StockSlipSchema.ct_Col_StockTotalPrice] = rst.StockTotalPrice;	// �d�����z���v
            dr[StockSlipSchema.ct_Col_StockSubttlPrice] = rst.StockSubttlPrice;	// �d�����z���v
            dr[StockSlipSchema.ct_Col_StockTtlPricTaxInc] = rst.StockTtlPricTaxInc;	// �d�����z�v�i�ō��݁j
            dr[StockSlipSchema.ct_Col_StockTtlPricTaxExc] = rst.StockTtlPricTaxExc;	// �d�����z�v�i�Ŕ����j
            dr[StockSlipSchema.ct_Col_StockNetPrice] = rst.StockNetPrice;	// �d���������z
            dr[StockSlipSchema.ct_Col_StockPriceConsTax] = rst.StockPriceConsTax;	// �d�����z����Ŋz
            dr[StockSlipSchema.ct_Col_TtlItdedStcOutTax] = rst.TtlItdedStcOutTax;	// �d���O�őΏۊz���v
            dr[StockSlipSchema.ct_Col_TtlItdedStcInTax] = rst.TtlItdedStcInTax;	// �d�����őΏۊz���v
            dr[StockSlipSchema.ct_Col_TtlItdedStcTaxFree] = rst.TtlItdedStcTaxFree;	// �d����ېőΏۊz���v
            dr[StockSlipSchema.ct_Col_StockOutTax] = rst.StockOutTax;	// �d�����z����Ŋz�i�O�Łj
            dr[StockSlipSchema.ct_Col_StckPrcConsTaxInclu] = rst.StckPrcConsTaxInclu;	// �d�����z����Ŋz�i���Łj
            dr[StockSlipSchema.ct_Col_StckDisTtlTaxExc] = rst.StckDisTtlTaxExc;	// �d���l�����z�v�i�Ŕ����j
            dr[StockSlipSchema.ct_Col_ItdedStockDisOutTax] = rst.ItdedStockDisOutTax;	// �d���l���O�őΏۊz���v
            dr[StockSlipSchema.ct_Col_ItdedStockDisInTax] = rst.ItdedStockDisInTax;	// �d���l�����őΏۊz���v
            dr[StockSlipSchema.ct_Col_ItdedStockDisTaxFre] = rst.ItdedStockDisTaxFre;	// �d���l����ېőΏۊz���v
            dr[StockSlipSchema.ct_Col_StockDisOutTax] = rst.StockDisOutTax;	// �d���l������Ŋz�i�O�Łj
            dr[StockSlipSchema.ct_Col_StckDisTtlTaxInclu] = rst.StckDisTtlTaxInclu;	// �d���l������Ŋz�i���Łj
            dr[StockSlipSchema.ct_Col_TaxAdjust] = rst.TaxAdjust;	// ����Œ����z
            dr[StockSlipSchema.ct_Col_BalanceAdjust] = rst.BalanceAdjust;	// �c�������z
            dr[StockSlipSchema.ct_Col_SuppCTaxLayCd] = rst.SuppCTaxLayCd;	// �d�������œ]�ŕ����R�[�h
            dr[StockSlipSchema.ct_Col_SupplierConsTaxRate] = rst.SupplierConsTaxRate;	// �d�������Őŗ�
            dr[StockSlipSchema.ct_Col_AccPayConsTax] = rst.AccPayConsTax;	// ���|�����
            dr[StockSlipSchema.ct_Col_StockFractionProcCd] = rst.StockFractionProcCd;	// �d���[�������敪
            dr[StockSlipSchema.ct_Col_AutoPayment] = rst.AutoPayment;	// �����x���敪
            dr[StockSlipSchema.ct_Col_AutoPaySlipNum] = rst.AutoPaySlipNum;	// �����x���`�[�ԍ�
            dr[StockSlipSchema.ct_Col_RetGoodsReasonDiv] = rst.RetGoodsReasonDiv;	// �ԕi���R�R�[�h
            dr[StockSlipSchema.ct_Col_RetGoodsReason] = rst.RetGoodsReason;	// �ԕi���R
            dr[StockSlipSchema.ct_Col_PartySaleSlipNum] = rst.PartySaleSlipNum;	// �����`�[�ԍ�
            dr[StockSlipSchema.ct_Col_SupplierSlipNote1] = rst.SupplierSlipNote1;	// �d���`�[���l1
            dr[StockSlipSchema.ct_Col_SupplierSlipNote2] = rst.SupplierSlipNote2;	// �d���`�[���l2
            dr[StockSlipSchema.ct_Col_DetailRowCount] = rst.DetailRowCount;	// ���׍s��
            dr[StockSlipSchema.ct_Col_EdiSendDate] = rst.EdiSendDate;	// �d�c�h���M��
            dr[StockSlipSchema.ct_Col_EdiTakeInDate] = rst.EdiTakeInDate;	// �d�c�h�捞��
            dr[StockSlipSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// �t�n�d���}�[�N�P
            dr[StockSlipSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// �t�n�d���}�[�N�Q
            dr[StockSlipSchema.ct_Col_SlipPrintDivCd] = rst.SlipPrintDivCd;	// �`�[���s�敪
            dr[StockSlipSchema.ct_Col_SlipPrintFinishCd] = rst.SlipPrintFinishCd;	// �`�[���s�ϋ敪
            dr[StockSlipSchema.ct_Col_StockSlipPrintDate] = rst.StockSlipPrintDate;	// �d���`�[���s��
            dr[StockSlipSchema.ct_Col_SlipPrtSetPaperId] = rst.SlipPrtSetPaperId;	// �`�[����ݒ�p���[ID
            dr[StockSlipSchema.ct_Col_SlipAddressDiv] = rst.SlipAddressDiv;	// �`�[�Z���敪
            dr[StockSlipSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// �[�i��R�[�h
            dr[StockSlipSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// �[�i�於��
            dr[StockSlipSchema.ct_Col_AddresseeName2] = rst.AddresseeName2;	// �[�i�於��2
            dr[StockSlipSchema.ct_Col_AddresseePostNo] = rst.AddresseePostNo;	// �[�i��X�֔ԍ�
            dr[StockSlipSchema.ct_Col_AddresseeAddr1] = rst.AddresseeAddr1;	// �[�i��Z��1(�s���{���s��S�E�����E��)
            dr[StockSlipSchema.ct_Col_AddresseeAddr3] = rst.AddresseeAddr3;	// �[�i��Z��3(�Ԓn)
            dr[StockSlipSchema.ct_Col_AddresseeAddr4] = rst.AddresseeAddr4;	// �[�i��Z��4(�A�p�[�g����)
            dr[StockSlipSchema.ct_Col_AddresseeTelNo] = rst.AddresseeTelNo;	// �[�i��d�b�ԍ�
            dr[StockSlipSchema.ct_Col_AddresseeFaxNo] = rst.AddresseeFaxNo;	// �[�i��FAX�ԍ�
            dr[StockSlipSchema.ct_Col_DirectSendingCd] = rst.DirectSendingCd;	// �����敪
        }
        # endregion
        # endregion
	}
}
