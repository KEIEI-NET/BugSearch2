//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ����f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : ����f�[�^�A�N�Z�X���s��
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
	/// ����f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����f�[�^�A�N�Z�X�N���X</br>
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

        # region ������f�[�^
        # region ����f�[�^�X�V���f�[�^���X�g���f�[�^�[�e�[�u����
        /// <summary>
        /// ����f�[�^�X�V���f�[�^���X�g���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="list">����f�[�^�f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromSalesSlipList(DataTable tbl, List<SalesSlipWork> list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (SalesSlipWork salesSlipWork in list)
                {
                    status = UpdateTableFromSalesSlipWork(tbl, salesSlipWork, salesSlipWork.SalesSlipNum, out message);
                    if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
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

        # region ����f�[�^�X�V������f�[�^���f�[�^�[�e�[�u����
        /// <summary>
        /// ����f�[�^�X�V������f�[�^���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="salesSlipWork">����f�[�^(��)</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromSalesSlipWork(DataTable tbl, SalesSlipWork salesSlipWork, string tempSalesSlipNum, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //Find�p�����[�^�ݒ�
                object[] findSalesSlip = new object[2];
                findSalesSlip[0] = salesSlipWork.AcptAnOdrStatus;
                findSalesSlip[1] = tempSalesSlipNum;
                DataRow salesSlipRow = tbl.Rows.Find(findSalesSlip);

                //����f�[�^�X�V�̍X�V
                if (salesSlipRow != null)
                {
                    CreateSalesSlipSchema(ref salesSlipRow, salesSlipWork);
                }
                //����f�[�^�X�V�̒ǉ�
                else
                {
                    DataRow dr = tbl.NewRow();
                    CreateSalesSlipSchema(ref dr, salesSlipWork);
                    tbl.Rows.Add(dr);
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

        # region ����f�[�^�ǉ�������SalesSlipWork��SalesSlipTable��
        /// <summary>
        /// ����f�[�^�ǉ�������SalesSlipWork��SalesSlipTable��
        /// </summary>
        /// <param name="salesSlipWork">����f�[�^</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ�(��)</param>
        /// <param name="totalCnt">�o�ɐ����v</param>
        /// <param name="slipCd">UOE�`�[���</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertSalesSlipDataTable(SalesSlipWork salesSlipWork, string tempSalesSlipNum, Int32 totalCnt, Int32 slipCd, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //����M�i�m�k�̕ۑ�
                DataRow dr = SalesSlipTable.NewRow();
                CreateSalesSlipSchema(ref dr, salesSlipWork, tempSalesSlipNum, totalCnt, slipCd);
                SalesSlipTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region ����f�[�^�q�d�`�c
        /// <summary>
        /// ����f�[�^�q�d�`�c
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�(��)</param>
        /// <param name="slipCd">UOE�`�[���</param>
        /// <returns>�X�e�[�^�X</returns>
        public DataRow ReadSalesSlipDataTable(Int32 acptAnOdrStatus, string tempSalesSlipNum)
        {
            //�ϐ��̏�����
            DataRow salesSlipRow = null;

            try
            {
                object[] findSalesSlip = new object[2];
                findSalesSlip[0] = acptAnOdrStatus;
                findSalesSlip[1] = tempSalesSlipNum;
                salesSlipRow = SalesSlipTable.Rows.Find(findSalesSlip);
            }
            catch (Exception)
            {
                salesSlipRow = null;
            }

            return (salesSlipRow);
        }
        # endregion


        # endregion

        # region ���󒍃f�[�^
        # region �󒍃f�[�^�ǉ�������SalesSlipWork��AcptSlipTable��
        /// <summary>
        /// �󒍃f�[�^�ǉ�������SalesSlipWork��AcptSlipTable��
        /// </summary>
        /// <param name="list">�󒍃f�[�^</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertAcptTblFromSalesSlipWork(SalesSlipWork salesSlipWork, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //����M�i�m�k�̕ۑ�
                DataRow dr = AcptSlipTable.NewRow();
                CreateSalesSlipSchema(ref dr, salesSlipWork);
                AcptSlipTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region �󒍃f�[�^�q�d�`�c
        /// <summary>
        /// �󒍃f�[�^�q�d�`�c
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <returns>����f�[�^�N���X</returns>
        public SalesSlipWork ReadAcptSlipDataTable(Int32 acptAnOdrStatus, string salesSlipNum)
        {
            SalesSlipWork salesSlipWork = null;

            try
            {
                object[] findSalesSlip = new object[2];
                findSalesSlip[0] = acptAnOdrStatus;
                findSalesSlip[1] = salesSlipNum;
                DataRow salesSlipRow = AcptSlipTable.Rows.Find(findSalesSlip);
                salesSlipWork = CreateSalesSlipWorkFromSchemaProc(salesSlipRow);
            }
            catch (Exception)
            {
                salesSlipWork = null;
            }

            return (salesSlipWork);
        }
        # endregion
        # endregion

        # region ������
        # region ����(��)�f�[�^��DataRow �� �N���X���쐬
        /// <summary>
        /// ����(��)�f�[�^��DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>����f�[�^</returns>
        public SalesSlipWork CreateSalesSlipWorkFromSchema(DataRow dr)
        {
            return (CreateSalesSlipWorkFromSchemaProc(dr));
        }

        # endregion
        # endregion

        # endregion
        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region ����(��)�f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// ����(��)�f�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">����(��)�f�[�^�N���X</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ�(��)</param>
        /// <param name="totalCnt">�o�ɐ����v</param>
        /// <param name="slipCd">UOE�`�[���</param>
        private void CreateSalesSlipSchema(ref DataRow dr, SalesSlipWork rst, string tempSalesSlipNum, Int32 totalCnt, Int32 slipCd)
        {
            CreateSalesSlipSchema(ref dr, rst);

            dr[SalesSlipSchema.ct_Col_TempSalesSlipNum] = tempSalesSlipNum;
            dr[SalesSlipSchema.ct_Col_TotalCnt] = totalCnt;
            dr[SalesSlipSchema.ct_Col_SlipCd] = slipCd;
        }

        /// <summary>
        /// ����(��)�f�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">����(��)�f�[�^�N���X</param>
        private void CreateSalesSlipSchema(ref DataRow dr, SalesSlipWork rst)
        {
            //dr[SalesSlipSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// �쐬����
            //dr[SalesSlipSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// �X�V����
            dr[SalesSlipSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// ��ƃR�[�h
            //dr[SalesSlipSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            //dr[SalesSlipSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
            //dr[SalesSlipSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
            //dr[SalesSlipSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
            dr[SalesSlipSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// �_���폜�敪
            dr[SalesSlipSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// �󒍃X�e�[�^�X
            dr[SalesSlipSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// ����`�[�ԍ�
            dr[SalesSlipSchema.ct_Col_SectionCode] = rst.SectionCode;	// ���_�R�[�h
            dr[SalesSlipSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// ����R�[�h
            dr[SalesSlipSchema.ct_Col_DebitNoteDiv] = rst.DebitNoteDiv;	// �ԓ`�敪
            dr[SalesSlipSchema.ct_Col_DebitNLnkSalesSlNum] = rst.DebitNLnkSalesSlNum;	// �ԍ��A������`�[�ԍ�
            dr[SalesSlipSchema.ct_Col_SalesSlipCd] = rst.SalesSlipCd;	// ����`�[�敪
            dr[SalesSlipSchema.ct_Col_SalesGoodsCd] = rst.SalesGoodsCd;	// ���㏤�i�敪
            dr[SalesSlipSchema.ct_Col_AccRecDivCd] = rst.AccRecDivCd;	// ���|�敪
            dr[SalesSlipSchema.ct_Col_SalesInpSecCd] = rst.SalesInpSecCd;	// ������͋��_�R�[�h
            dr[SalesSlipSchema.ct_Col_DemandAddUpSecCd] = rst.DemandAddUpSecCd;	// �����v�㋒�_�R�[�h
            dr[SalesSlipSchema.ct_Col_ResultsAddUpSecCd] = rst.ResultsAddUpSecCd;	// ���ьv�㋒�_�R�[�h
            dr[SalesSlipSchema.ct_Col_UpdateSecCd] = rst.UpdateSecCd;	// �X�V���_�R�[�h
            dr[SalesSlipSchema.ct_Col_SalesSlipUpdateCd] = rst.SalesSlipUpdateCd;	// ����`�[�X�V�敪
            dr[SalesSlipSchema.ct_Col_SearchSlipDate] = rst.SearchSlipDate;	// �`�[�������t
            dr[SalesSlipSchema.ct_Col_ShipmentDay] = rst.ShipmentDay;	// �o�ד��t
            dr[SalesSlipSchema.ct_Col_SalesDate] = rst.SalesDate;	// ������t
            dr[SalesSlipSchema.ct_Col_AddUpADate] = rst.AddUpADate;	// �v����t
            dr[SalesSlipSchema.ct_Col_DelayPaymentDiv] = rst.DelayPaymentDiv;	// �����敪
            dr[SalesSlipSchema.ct_Col_EstimateFormNo] = rst.EstimateFormNo;	// ���Ϗ��ԍ�
            dr[SalesSlipSchema.ct_Col_EstimateDivide] = rst.EstimateDivide;	// ���ϋ敪
            dr[SalesSlipSchema.ct_Col_InputAgenCd] = rst.InputAgenCd;	// ���͒S���҃R�[�h
            dr[SalesSlipSchema.ct_Col_InputAgenNm] = rst.InputAgenNm;	// ���͒S���Җ���
            dr[SalesSlipSchema.ct_Col_SalesInputCode] = rst.SalesInputCode;	// ������͎҃R�[�h
            dr[SalesSlipSchema.ct_Col_SalesInputName] = rst.SalesInputName;	// ������͎Җ���
            dr[SalesSlipSchema.ct_Col_FrontEmployeeCd] = rst.FrontEmployeeCd;	// ��t�]�ƈ��R�[�h
            dr[SalesSlipSchema.ct_Col_FrontEmployeeNm] = rst.FrontEmployeeNm;	// ��t�]�ƈ�����
            dr[SalesSlipSchema.ct_Col_SalesEmployeeCd] = rst.SalesEmployeeCd;	// �̔��]�ƈ��R�[�h
            dr[SalesSlipSchema.ct_Col_SalesEmployeeNm] = rst.SalesEmployeeNm;	// �̔��]�ƈ�����
            dr[SalesSlipSchema.ct_Col_TotalAmountDispWayCd] = rst.TotalAmountDispWayCd;	// ���z�\�����@�敪
            dr[SalesSlipSchema.ct_Col_TtlAmntDispRateApy] = rst.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
            dr[SalesSlipSchema.ct_Col_SalesTotalTaxInc] = rst.SalesTotalTaxInc;	// ����`�[���v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_SalesTotalTaxExc] = rst.SalesTotalTaxExc;	// ����`�[���v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxInc] = rst.SalesPrtTotalTaxInc;	// ���㕔�i���v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxExc] = rst.SalesPrtTotalTaxExc;	// ���㕔�i���v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxInc] = rst.SalesWorkTotalTaxInc;	// �����ƍ��v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxExc] = rst.SalesWorkTotalTaxExc;	// �����ƍ��v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxInc] = rst.SalesSubtotalTaxInc;	// ���㏬�v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxExc] = rst.SalesSubtotalTaxExc;	// ���㏬�v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_SalesPrtSubttlInc] = rst.SalesPrtSubttlInc;	// ���㕔�i���v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_SalesPrtSubttlExc] = rst.SalesPrtSubttlExc;	// ���㕔�i���v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_SalesWorkSubttlInc] = rst.SalesWorkSubttlInc;	// �����Ə��v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_SalesWorkSubttlExc] = rst.SalesWorkSubttlExc;	// �����Ə��v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_SalesNetPrice] = rst.SalesNetPrice;	// ���㐳�����z
            dr[SalesSlipSchema.ct_Col_SalesSubtotalTax] = rst.SalesSubtotalTax;	// ���㏬�v�i�Łj
            dr[SalesSlipSchema.ct_Col_ItdedSalesOutTax] = rst.ItdedSalesOutTax;	// ����O�őΏۊz
            dr[SalesSlipSchema.ct_Col_ItdedSalesInTax] = rst.ItdedSalesInTax;	// ������őΏۊz
            dr[SalesSlipSchema.ct_Col_SalSubttlSubToTaxFre] = rst.SalSubttlSubToTaxFre;	// ���㏬�v��ېőΏۊz
            dr[SalesSlipSchema.ct_Col_SalesOutTax] = rst.SalesOutTax;	// ������z����Ŋz�i�O�Łj
            dr[SalesSlipSchema.ct_Col_SalAmntConsTaxInclu] = rst.SalAmntConsTaxInclu;	// ������z����Ŋz�i���Łj
            dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxExc] = rst.SalesDisTtlTaxExc;	// ����l�����z�v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_ItdedSalesDisOutTax] = rst.ItdedSalesDisOutTax;	// ����l���O�őΏۊz���v
            dr[SalesSlipSchema.ct_Col_ItdedSalesDisInTax] = rst.ItdedSalesDisInTax;	// ����l�����őΏۊz���v
            dr[SalesSlipSchema.ct_Col_ItdedPartsDisOutTax] = rst.ItdedPartsDisOutTax;	// ���i�l���Ώۊz���v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_ItdedPartsDisInTax] = rst.ItdedPartsDisInTax;	// ���i�l���Ώۊz���v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_ItdedWorkDisOutTax] = rst.ItdedWorkDisOutTax;	// ��ƒl���Ώۊz���v�i�Ŕ����j
            dr[SalesSlipSchema.ct_Col_ItdedWorkDisInTax] = rst.ItdedWorkDisInTax;	// ��ƒl���Ώۊz���v�i�ō��݁j
            dr[SalesSlipSchema.ct_Col_ItdedSalesDisTaxFre] = rst.ItdedSalesDisTaxFre;	// ����l����ېőΏۊz���v
            dr[SalesSlipSchema.ct_Col_SalesDisOutTax] = rst.SalesDisOutTax;	// ����l������Ŋz�i�O�Łj
            dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxInclu] = rst.SalesDisTtlTaxInclu;	// ����l������Ŋz�i���Łj
            dr[SalesSlipSchema.ct_Col_PartsDiscountRate] = rst.PartsDiscountRate;	// ���i�l����
            dr[SalesSlipSchema.ct_Col_RavorDiscountRate] = rst.RavorDiscountRate;	// �H���l����
            dr[SalesSlipSchema.ct_Col_TotalCost] = rst.TotalCost;	// �������z�v
            dr[SalesSlipSchema.ct_Col_ConsTaxLayMethod] = rst.ConsTaxLayMethod;	// ����œ]�ŕ���
            dr[SalesSlipSchema.ct_Col_ConsTaxRate] = rst.ConsTaxRate;	// ����Őŗ�
            dr[SalesSlipSchema.ct_Col_FractionProcCd] = rst.FractionProcCd;	// �[�������敪
            dr[SalesSlipSchema.ct_Col_AccRecConsTax] = rst.AccRecConsTax;	// ���|�����
            dr[SalesSlipSchema.ct_Col_AutoDepositCd] = rst.AutoDepositCd;	// ���������敪
            dr[SalesSlipSchema.ct_Col_AutoDepositSlipNo] = rst.AutoDepositSlipNo;	// ���������`�[�ԍ�
            dr[SalesSlipSchema.ct_Col_DepositAllowanceTtl] = rst.DepositAllowanceTtl;	// �����������v�z
            dr[SalesSlipSchema.ct_Col_DepositAlwcBlnce] = rst.DepositAlwcBlnce;	// ���������c��
            dr[SalesSlipSchema.ct_Col_ClaimCode] = rst.ClaimCode;	// ������R�[�h
            dr[SalesSlipSchema.ct_Col_ClaimSnm] = rst.ClaimSnm;	// �����旪��
            dr[SalesSlipSchema.ct_Col_CustomerCode] = rst.CustomerCode;	// ���Ӑ�R�[�h
            dr[SalesSlipSchema.ct_Col_CustomerName] = rst.CustomerName;	// ���Ӑ於��
            dr[SalesSlipSchema.ct_Col_CustomerName2] = rst.CustomerName2;	// ���Ӑ於��2
            dr[SalesSlipSchema.ct_Col_CustomerSnm] = rst.CustomerSnm;	// ���Ӑ旪��
            dr[SalesSlipSchema.ct_Col_HonorificTitle] = rst.HonorificTitle;	// �h��
            dr[SalesSlipSchema.ct_Col_OutputNameCode] = rst.OutputNameCode;	// �����R�[�h
            dr[SalesSlipSchema.ct_Col_OutputName] = rst.OutputName;	// ��������
            dr[SalesSlipSchema.ct_Col_CustSlipNo] = rst.CustSlipNo;	// ���Ӑ�`�[�ԍ�
            dr[SalesSlipSchema.ct_Col_SlipAddressDiv] = rst.SlipAddressDiv;	// �`�[�Z���敪
            dr[SalesSlipSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// �[�i��R�[�h
            dr[SalesSlipSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// �[�i�於��
            dr[SalesSlipSchema.ct_Col_AddresseeName2] = rst.AddresseeName2;	// �[�i�於��2
            dr[SalesSlipSchema.ct_Col_AddresseePostNo] = rst.AddresseePostNo;	// �[�i��X�֔ԍ�
            dr[SalesSlipSchema.ct_Col_AddresseeAddr1] = rst.AddresseeAddr1;	// �[�i��Z��1(�s���{���s��S�E�����E��)
            dr[SalesSlipSchema.ct_Col_AddresseeAddr3] = rst.AddresseeAddr3;	// �[�i��Z��3(�Ԓn)
            dr[SalesSlipSchema.ct_Col_AddresseeAddr4] = rst.AddresseeAddr4;	// �[�i��Z��4(�A�p�[�g����)
            dr[SalesSlipSchema.ct_Col_AddresseeTelNo] = rst.AddresseeTelNo;	// �[�i��d�b�ԍ�
            dr[SalesSlipSchema.ct_Col_AddresseeFaxNo] = rst.AddresseeFaxNo;	// �[�i��FAX�ԍ�
            dr[SalesSlipSchema.ct_Col_PartySaleSlipNum] = rst.PartySaleSlipNum;	// �����`�[�ԍ�
            dr[SalesSlipSchema.ct_Col_SlipNote] = rst.SlipNote;	// �`�[���l
            dr[SalesSlipSchema.ct_Col_SlipNote2] = rst.SlipNote2;	// �`�[���l�Q
            dr[SalesSlipSchema.ct_Col_SlipNote3] = rst.SlipNote3;	// �`�[���l�R
            dr[SalesSlipSchema.ct_Col_RetGoodsReasonDiv] = rst.RetGoodsReasonDiv;	// �ԕi���R�R�[�h
            dr[SalesSlipSchema.ct_Col_RetGoodsReason] = rst.RetGoodsReason;	// �ԕi���R
            dr[SalesSlipSchema.ct_Col_RegiProcDate] = rst.RegiProcDate;	// ���W������
            dr[SalesSlipSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo;	// ���W�ԍ�
            dr[SalesSlipSchema.ct_Col_PosReceiptNo] = rst.PosReceiptNo;	// POS���V�[�g�ԍ�
            dr[SalesSlipSchema.ct_Col_DetailRowCount] = rst.DetailRowCount;	// ���׍s��
            dr[SalesSlipSchema.ct_Col_EdiSendDate] = rst.EdiSendDate;	// �d�c�h���M��
            dr[SalesSlipSchema.ct_Col_EdiTakeInDate] = rst.EdiTakeInDate;	// �d�c�h�捞��
            dr[SalesSlipSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// �t�n�d���}�[�N�P
            dr[SalesSlipSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// �t�n�d���}�[�N�Q
            dr[SalesSlipSchema.ct_Col_SlipPrintDivCd] = rst.SlipPrintDivCd;	// �`�[���s�敪
            dr[SalesSlipSchema.ct_Col_SlipPrintFinishCd] = rst.SlipPrintFinishCd;	// �`�[���s�ϋ敪
            dr[SalesSlipSchema.ct_Col_SalesSlipPrintDate] = rst.SalesSlipPrintDate;	// ����`�[���s��
            dr[SalesSlipSchema.ct_Col_BusinessTypeCode] = rst.BusinessTypeCode;	// �Ǝ�R�[�h
            dr[SalesSlipSchema.ct_Col_BusinessTypeName] = rst.BusinessTypeName;	// �Ǝ햼��
            dr[SalesSlipSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// �����ԍ�
            dr[SalesSlipSchema.ct_Col_DeliveredGoodsDiv] = rst.DeliveredGoodsDiv;	// �[�i�敪
            dr[SalesSlipSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm;	// �[�i�敪����
            dr[SalesSlipSchema.ct_Col_SalesAreaCode] = rst.SalesAreaCode;	// �̔��G���A�R�[�h
            dr[SalesSlipSchema.ct_Col_SalesAreaName] = rst.SalesAreaName;	// �̔��G���A����
            dr[SalesSlipSchema.ct_Col_ReconcileFlag] = rst.ReconcileFlag;	// �����t���O
            dr[SalesSlipSchema.ct_Col_SlipPrtSetPaperId] = rst.SlipPrtSetPaperId;	// �`�[����ݒ�p���[ID
            dr[SalesSlipSchema.ct_Col_CompleteCd] = rst.CompleteCd;	// �ꎮ�`�[�敪
            dr[SalesSlipSchema.ct_Col_SalesPriceFracProcCd] = rst.SalesPriceFracProcCd;	// ������z�[�������敪
            dr[SalesSlipSchema.ct_Col_StockGoodsTtlTaxExc] = rst.StockGoodsTtlTaxExc;	// �݌ɏ��i���v���z�i�Ŕ��j
            dr[SalesSlipSchema.ct_Col_PureGoodsTtlTaxExc] = rst.PureGoodsTtlTaxExc;	// �������i���v���z�i�Ŕ��j
            dr[SalesSlipSchema.ct_Col_ListPricePrintDiv] = rst.ListPricePrintDiv;	// �艿����敪
            dr[SalesSlipSchema.ct_Col_EraNameDispCd1] = rst.EraNameDispCd1;	// �����\���敪�P
            dr[SalesSlipSchema.ct_Col_EstimaTaxDivCd] = rst.EstimaTaxDivCd;	// ���Ϗ���ŋ敪
            dr[SalesSlipSchema.ct_Col_EstimateFormPrtCd] = rst.EstimateFormPrtCd;	// ���Ϗ�����敪
            dr[SalesSlipSchema.ct_Col_EstimateSubject] = rst.EstimateSubject;	// ���ό���
            dr[SalesSlipSchema.ct_Col_Footnotes1] = rst.Footnotes1;	// �r���P
            dr[SalesSlipSchema.ct_Col_Footnotes2] = rst.Footnotes2;	// �r���Q
            dr[SalesSlipSchema.ct_Col_EstimateTitle1] = rst.EstimateTitle1;	// ���σ^�C�g���P
            dr[SalesSlipSchema.ct_Col_EstimateTitle2] = rst.EstimateTitle2;	// ���σ^�C�g���Q
            dr[SalesSlipSchema.ct_Col_EstimateTitle3] = rst.EstimateTitle3;	// ���σ^�C�g���R
            dr[SalesSlipSchema.ct_Col_EstimateTitle4] = rst.EstimateTitle4;	// ���σ^�C�g���S
            dr[SalesSlipSchema.ct_Col_EstimateTitle5] = rst.EstimateTitle5;	// ���σ^�C�g���T
            dr[SalesSlipSchema.ct_Col_EstimateNote1] = rst.EstimateNote1;	// ���ϔ��l�P
            dr[SalesSlipSchema.ct_Col_EstimateNote2] = rst.EstimateNote2;	// ���ϔ��l�Q
            dr[SalesSlipSchema.ct_Col_EstimateNote3] = rst.EstimateNote3;	// ���ϔ��l�R
            dr[SalesSlipSchema.ct_Col_EstimateNote4] = rst.EstimateNote4;	// ���ϔ��l�S
            dr[SalesSlipSchema.ct_Col_EstimateNote5] = rst.EstimateNote5;	// ���ϔ��l�T
            dr[SalesSlipSchema.ct_Col_EstimateValidityDate] = rst.EstimateValidityDate;	// ���ϗL������
            dr[SalesSlipSchema.ct_Col_PartsNoPrtCd] = rst.PartsNoPrtCd;	// �i�Ԉ󎚋敪
            dr[SalesSlipSchema.ct_Col_OptionPringDivCd] = rst.OptionPringDivCd;	// �I�v�V�����󎚋敪
            dr[SalesSlipSchema.ct_Col_RateUseCode] = rst.RateUseCode;	// �|���g�p�敪
        }
        # endregion

        # region ����(��)�f�[�^��DataRow �� �N���X���쐬
        /// <summary>
        /// ����(��)�f�[�^��DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>����(��)�f�[�^</returns>
        private SalesSlipWork CreateSalesSlipWorkFromSchemaProc(DataRow dr)
        {
            SalesSlipWork rst = new SalesSlipWork();

            try
            {
                //rst.CreateDateTime = (Int64)dr[SalesSlipSchema.ct_Col_CreateDateTime];	// �쐬����
                //rst.UpdateDateTime = (Int64)dr[SalesSlipSchema.ct_Col_UpdateDateTime];	// �X�V����
                rst.EnterpriseCode = (string)dr[SalesSlipSchema.ct_Col_EnterpriseCode];	// ��ƃR�[�h
                rst.FileHeaderGuid = (Guid)dr[SalesSlipSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[SalesSlipSchema.ct_Col_UpdEmployeeCode];	// �X�V�]�ƈ��R�[�h
                rst.UpdAssemblyId1 = (string)dr[SalesSlipSchema.ct_Col_UpdAssemblyId1];	// �X�V�A�Z���u��ID1
                rst.UpdAssemblyId2 = (string)dr[SalesSlipSchema.ct_Col_UpdAssemblyId2];	// �X�V�A�Z���u��ID2
                rst.LogicalDeleteCode = (Int32)dr[SalesSlipSchema.ct_Col_LogicalDeleteCode];	// �_���폜�敪
                rst.AcptAnOdrStatus = (Int32)dr[SalesSlipSchema.ct_Col_AcptAnOdrStatus];	// �󒍃X�e�[�^�X
                rst.SalesSlipNum = (string)dr[SalesSlipSchema.ct_Col_SalesSlipNum];	// ����`�[�ԍ�
                rst.SectionCode = (string)dr[SalesSlipSchema.ct_Col_SectionCode];	// ���_�R�[�h
                rst.SubSectionCode = (Int32)dr[SalesSlipSchema.ct_Col_SubSectionCode];	// ����R�[�h
                rst.DebitNoteDiv = (Int32)dr[SalesSlipSchema.ct_Col_DebitNoteDiv];	// �ԓ`�敪
                rst.DebitNLnkSalesSlNum = (string)dr[SalesSlipSchema.ct_Col_DebitNLnkSalesSlNum];	// �ԍ��A������`�[�ԍ�
                rst.SalesSlipCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesSlipCd];	// ����`�[�敪
                rst.SalesGoodsCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesGoodsCd];	// ���㏤�i�敪
                rst.AccRecDivCd = (Int32)dr[SalesSlipSchema.ct_Col_AccRecDivCd];	// ���|�敪
                rst.SalesInpSecCd = (string)dr[SalesSlipSchema.ct_Col_SalesInpSecCd];	// ������͋��_�R�[�h
                rst.DemandAddUpSecCd = (string)dr[SalesSlipSchema.ct_Col_DemandAddUpSecCd];	// �����v�㋒�_�R�[�h
                rst.ResultsAddUpSecCd = (string)dr[SalesSlipSchema.ct_Col_ResultsAddUpSecCd];	// ���ьv�㋒�_�R�[�h
                rst.UpdateSecCd = (string)dr[SalesSlipSchema.ct_Col_UpdateSecCd];	// �X�V���_�R�[�h
                rst.SalesSlipUpdateCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesSlipUpdateCd];	// ����`�[�X�V�敪
                rst.SearchSlipDate = (DateTime)dr[SalesSlipSchema.ct_Col_SearchSlipDate];	// �`�[�������t
                rst.ShipmentDay = (DateTime)dr[SalesSlipSchema.ct_Col_ShipmentDay];	// �o�ד��t
                rst.SalesDate = (DateTime)dr[SalesSlipSchema.ct_Col_SalesDate];	// ������t
                rst.AddUpADate = (DateTime)dr[SalesSlipSchema.ct_Col_AddUpADate];	// �v����t
                rst.DelayPaymentDiv = (Int32)dr[SalesSlipSchema.ct_Col_DelayPaymentDiv];	// �����敪
                rst.EstimateFormNo = (string)dr[SalesSlipSchema.ct_Col_EstimateFormNo];	// ���Ϗ��ԍ�
                rst.EstimateDivide = (Int32)dr[SalesSlipSchema.ct_Col_EstimateDivide];	// ���ϋ敪
                rst.InputAgenCd = (string)dr[SalesSlipSchema.ct_Col_InputAgenCd];	// ���͒S���҃R�[�h
                rst.InputAgenNm = (string)dr[SalesSlipSchema.ct_Col_InputAgenNm];	// ���͒S���Җ���
                rst.SalesInputCode = (string)dr[SalesSlipSchema.ct_Col_SalesInputCode];	// ������͎҃R�[�h
                rst.SalesInputName = (string)dr[SalesSlipSchema.ct_Col_SalesInputName];	// ������͎Җ���
                rst.FrontEmployeeCd = (string)dr[SalesSlipSchema.ct_Col_FrontEmployeeCd];	// ��t�]�ƈ��R�[�h
                rst.FrontEmployeeNm = (string)dr[SalesSlipSchema.ct_Col_FrontEmployeeNm];	// ��t�]�ƈ�����
                rst.SalesEmployeeCd = (string)dr[SalesSlipSchema.ct_Col_SalesEmployeeCd];	// �̔��]�ƈ��R�[�h
                rst.SalesEmployeeNm = (string)dr[SalesSlipSchema.ct_Col_SalesEmployeeNm];	// �̔��]�ƈ�����
                rst.TotalAmountDispWayCd = (Int32)dr[SalesSlipSchema.ct_Col_TotalAmountDispWayCd];	// ���z�\�����@�敪
                rst.TtlAmntDispRateApy = (Int32)dr[SalesSlipSchema.ct_Col_TtlAmntDispRateApy];	// ���z�\���|���K�p�敪
                rst.SalesTotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesTotalTaxInc];	// ����`�[���v�i�ō��݁j
                rst.SalesTotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesTotalTaxExc];	// ����`�[���v�i�Ŕ����j
                rst.SalesPrtTotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxInc];	// ���㕔�i���v�i�ō��݁j
                rst.SalesPrtTotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxExc];	// ���㕔�i���v�i�Ŕ����j
                rst.SalesWorkTotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxInc];	// �����ƍ��v�i�ō��݁j
                rst.SalesWorkTotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxExc];	// �����ƍ��v�i�Ŕ����j
                rst.SalesSubtotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxInc];	// ���㏬�v�i�ō��݁j
                rst.SalesSubtotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxExc];	// ���㏬�v�i�Ŕ����j
                rst.SalesPrtSubttlInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtSubttlInc];	// ���㕔�i���v�i�ō��݁j
                rst.SalesPrtSubttlExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtSubttlExc];	// ���㕔�i���v�i�Ŕ����j
                rst.SalesWorkSubttlInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkSubttlInc];	// �����Ə��v�i�ō��݁j
                rst.SalesWorkSubttlExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkSubttlExc];	// �����Ə��v�i�Ŕ����j
                rst.SalesNetPrice = (Int64)dr[SalesSlipSchema.ct_Col_SalesNetPrice];	// ���㐳�����z
                rst.SalesSubtotalTax = (Int64)dr[SalesSlipSchema.ct_Col_SalesSubtotalTax];	// ���㏬�v�i�Łj
                rst.ItdedSalesOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesOutTax];	// ����O�őΏۊz
                rst.ItdedSalesInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesInTax];	// ������őΏۊz
                rst.SalSubttlSubToTaxFre = (Int64)dr[SalesSlipSchema.ct_Col_SalSubttlSubToTaxFre];	// ���㏬�v��ېőΏۊz
                rst.SalesOutTax = (Int64)dr[SalesSlipSchema.ct_Col_SalesOutTax];	// ������z����Ŋz�i�O�Łj
                rst.SalAmntConsTaxInclu = (Int64)dr[SalesSlipSchema.ct_Col_SalAmntConsTaxInclu];	// ������z����Ŋz�i���Łj
                rst.SalesDisTtlTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxExc];	// ����l�����z�v�i�Ŕ����j
                rst.ItdedSalesDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesDisOutTax];	// ����l���O�őΏۊz���v
                rst.ItdedSalesDisInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesDisInTax];	// ����l�����őΏۊz���v
                rst.ItdedPartsDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedPartsDisOutTax];	// ���i�l���Ώۊz���v�i�Ŕ����j
                rst.ItdedPartsDisInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedPartsDisInTax];	// ���i�l���Ώۊz���v�i�ō��݁j
                rst.ItdedWorkDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedWorkDisOutTax];	// ��ƒl���Ώۊz���v�i�Ŕ����j
                rst.ItdedWorkDisInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedWorkDisInTax];	// ��ƒl���Ώۊz���v�i�ō��݁j
                rst.ItdedSalesDisTaxFre = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesDisTaxFre];	// ����l����ېőΏۊz���v
                rst.SalesDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_SalesDisOutTax];	// ����l������Ŋz�i�O�Łj
                rst.SalesDisTtlTaxInclu = (Int64)dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxInclu];	// ����l������Ŋz�i���Łj
                rst.PartsDiscountRate = (Double)dr[SalesSlipSchema.ct_Col_PartsDiscountRate];	// ���i�l����
                rst.RavorDiscountRate = (Double)dr[SalesSlipSchema.ct_Col_RavorDiscountRate];	// �H���l����
                rst.TotalCost = (Int64)dr[SalesSlipSchema.ct_Col_TotalCost];	// �������z�v
                rst.ConsTaxLayMethod = (Int32)dr[SalesSlipSchema.ct_Col_ConsTaxLayMethod];	// ����œ]�ŕ���
                rst.ConsTaxRate = (Double)dr[SalesSlipSchema.ct_Col_ConsTaxRate];	// ����Őŗ�
                rst.FractionProcCd = (Int32)dr[SalesSlipSchema.ct_Col_FractionProcCd];	// �[�������敪
                rst.AccRecConsTax = (Int64)dr[SalesSlipSchema.ct_Col_AccRecConsTax];	// ���|�����
                rst.AutoDepositCd = (Int32)dr[SalesSlipSchema.ct_Col_AutoDepositCd];	// ���������敪
                rst.AutoDepositSlipNo = (Int32)dr[SalesSlipSchema.ct_Col_AutoDepositSlipNo];	// ���������`�[�ԍ�
                rst.DepositAllowanceTtl = (Int64)dr[SalesSlipSchema.ct_Col_DepositAllowanceTtl];	// �����������v�z
                rst.DepositAlwcBlnce = (Int64)dr[SalesSlipSchema.ct_Col_DepositAlwcBlnce];	// ���������c��
                rst.ClaimCode = (Int32)dr[SalesSlipSchema.ct_Col_ClaimCode];	// ������R�[�h
                rst.ClaimSnm = (string)dr[SalesSlipSchema.ct_Col_ClaimSnm];	// �����旪��
                rst.CustomerCode = (Int32)dr[SalesSlipSchema.ct_Col_CustomerCode];	// ���Ӑ�R�[�h
                rst.CustomerName = (string)dr[SalesSlipSchema.ct_Col_CustomerName];	// ���Ӑ於��
                rst.CustomerName2 = (string)dr[SalesSlipSchema.ct_Col_CustomerName2];	// ���Ӑ於��2
                rst.CustomerSnm = (string)dr[SalesSlipSchema.ct_Col_CustomerSnm];	// ���Ӑ旪��
                rst.HonorificTitle = (string)dr[SalesSlipSchema.ct_Col_HonorificTitle];	// �h��
                rst.OutputNameCode = (Int32)dr[SalesSlipSchema.ct_Col_OutputNameCode];	// �����R�[�h
                rst.OutputName = (string)dr[SalesSlipSchema.ct_Col_OutputName];	// ��������
                rst.CustSlipNo = (Int32)dr[SalesSlipSchema.ct_Col_CustSlipNo];	// ���Ӑ�`�[�ԍ�
                rst.SlipAddressDiv = (Int32)dr[SalesSlipSchema.ct_Col_SlipAddressDiv];	// �`�[�Z���敪
                rst.AddresseeCode = (Int32)dr[SalesSlipSchema.ct_Col_AddresseeCode];	// �[�i��R�[�h
                rst.AddresseeName = (string)dr[SalesSlipSchema.ct_Col_AddresseeName];	// �[�i�於��
                rst.AddresseeName2 = (string)dr[SalesSlipSchema.ct_Col_AddresseeName2];	// �[�i�於��2
                rst.AddresseePostNo = (string)dr[SalesSlipSchema.ct_Col_AddresseePostNo];	// �[�i��X�֔ԍ�
                rst.AddresseeAddr1 = (string)dr[SalesSlipSchema.ct_Col_AddresseeAddr1];	// �[�i��Z��1(�s���{���s��S�E�����E��)
                rst.AddresseeAddr3 = (string)dr[SalesSlipSchema.ct_Col_AddresseeAddr3];	// �[�i��Z��3(�Ԓn)
                rst.AddresseeAddr4 = (string)dr[SalesSlipSchema.ct_Col_AddresseeAddr4];	// �[�i��Z��4(�A�p�[�g����)
                rst.AddresseeTelNo = (string)dr[SalesSlipSchema.ct_Col_AddresseeTelNo];	// �[�i��d�b�ԍ�
                rst.AddresseeFaxNo = (string)dr[SalesSlipSchema.ct_Col_AddresseeFaxNo];	// �[�i��FAX�ԍ�
                rst.PartySaleSlipNum = (string)dr[SalesSlipSchema.ct_Col_PartySaleSlipNum];	// �����`�[�ԍ�
                rst.SlipNote = (string)dr[SalesSlipSchema.ct_Col_SlipNote];	// �`�[���l
                rst.SlipNote2 = (string)dr[SalesSlipSchema.ct_Col_SlipNote2];	// �`�[���l�Q
                rst.SlipNote3 = (string)dr[SalesSlipSchema.ct_Col_SlipNote3];	// �`�[���l�R
                rst.RetGoodsReasonDiv = (Int32)dr[SalesSlipSchema.ct_Col_RetGoodsReasonDiv];	// �ԕi���R�R�[�h
                rst.RetGoodsReason = (string)dr[SalesSlipSchema.ct_Col_RetGoodsReason];	// �ԕi���R
                rst.RegiProcDate = (DateTime)dr[SalesSlipSchema.ct_Col_RegiProcDate];	// ���W������
                rst.CashRegisterNo = (Int32)dr[SalesSlipSchema.ct_Col_CashRegisterNo];	// ���W�ԍ�
                rst.PosReceiptNo = (Int32)dr[SalesSlipSchema.ct_Col_PosReceiptNo];	// POS���V�[�g�ԍ�
                rst.DetailRowCount = (Int32)dr[SalesSlipSchema.ct_Col_DetailRowCount];	// ���׍s��
                rst.EdiSendDate = (DateTime)dr[SalesSlipSchema.ct_Col_EdiSendDate];	// �d�c�h���M��
                rst.EdiTakeInDate = (DateTime)dr[SalesSlipSchema.ct_Col_EdiTakeInDate];	// �d�c�h�捞��
                rst.UoeRemark1 = (string)dr[SalesSlipSchema.ct_Col_UoeRemark1];	// �t�n�d���}�[�N�P
                rst.UoeRemark2 = (string)dr[SalesSlipSchema.ct_Col_UoeRemark2];	// �t�n�d���}�[�N�Q
                rst.SlipPrintDivCd = (Int32)dr[SalesSlipSchema.ct_Col_SlipPrintDivCd];	// �`�[���s�敪
                rst.SlipPrintFinishCd = (Int32)dr[SalesSlipSchema.ct_Col_SlipPrintFinishCd];	// �`�[���s�ϋ敪
                rst.SalesSlipPrintDate = (DateTime)dr[SalesSlipSchema.ct_Col_SalesSlipPrintDate];	// ����`�[���s��
                rst.BusinessTypeCode = (Int32)dr[SalesSlipSchema.ct_Col_BusinessTypeCode];	// �Ǝ�R�[�h
                rst.BusinessTypeName = (string)dr[SalesSlipSchema.ct_Col_BusinessTypeName];	// �Ǝ햼��
                rst.OrderNumber = (string)dr[SalesSlipSchema.ct_Col_OrderNumber];	// �����ԍ�
                rst.DeliveredGoodsDiv = (Int32)dr[SalesSlipSchema.ct_Col_DeliveredGoodsDiv];	// �[�i�敪
                rst.DeliveredGoodsDivNm = (string)dr[SalesSlipSchema.ct_Col_DeliveredGoodsDivNm];	// �[�i�敪����
                rst.SalesAreaCode = (Int32)dr[SalesSlipSchema.ct_Col_SalesAreaCode];	// �̔��G���A�R�[�h
                rst.SalesAreaName = (string)dr[SalesSlipSchema.ct_Col_SalesAreaName];	// �̔��G���A����
                rst.ReconcileFlag = (Int32)dr[SalesSlipSchema.ct_Col_ReconcileFlag];	// �����t���O
                rst.SlipPrtSetPaperId = (string)dr[SalesSlipSchema.ct_Col_SlipPrtSetPaperId];	// �`�[����ݒ�p���[ID
                rst.CompleteCd = (Int32)dr[SalesSlipSchema.ct_Col_CompleteCd];	// �ꎮ�`�[�敪
                rst.SalesPriceFracProcCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesPriceFracProcCd];	// ������z�[�������敪
                rst.StockGoodsTtlTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_StockGoodsTtlTaxExc];	// �݌ɏ��i���v���z�i�Ŕ��j
                rst.PureGoodsTtlTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_PureGoodsTtlTaxExc];	// �������i���v���z�i�Ŕ��j
                rst.ListPricePrintDiv = (Int32)dr[SalesSlipSchema.ct_Col_ListPricePrintDiv];	// �艿����敪
                rst.EraNameDispCd1 = (Int32)dr[SalesSlipSchema.ct_Col_EraNameDispCd1];	// �����\���敪�P
                rst.EstimaTaxDivCd = (Int32)dr[SalesSlipSchema.ct_Col_EstimaTaxDivCd];	// ���Ϗ���ŋ敪
                rst.EstimateFormPrtCd = (Int32)dr[SalesSlipSchema.ct_Col_EstimateFormPrtCd];	// ���Ϗ�����敪
                rst.EstimateSubject = (string)dr[SalesSlipSchema.ct_Col_EstimateSubject];	// ���ό���
                rst.Footnotes1 = (string)dr[SalesSlipSchema.ct_Col_Footnotes1];	// �r���P
                rst.Footnotes2 = (string)dr[SalesSlipSchema.ct_Col_Footnotes2];	// �r���Q
                rst.EstimateTitle1 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle1];	// ���σ^�C�g���P
                rst.EstimateTitle2 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle2];	// ���σ^�C�g���Q
                rst.EstimateTitle3 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle3];	// ���σ^�C�g���R
                rst.EstimateTitle4 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle4];	// ���σ^�C�g���S
                rst.EstimateTitle5 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle5];	// ���σ^�C�g���T
                rst.EstimateNote1 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote1];	// ���ϔ��l�P
                rst.EstimateNote2 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote2];	// ���ϔ��l�Q
                rst.EstimateNote3 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote3];	// ���ϔ��l�R
                rst.EstimateNote4 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote4];	// ���ϔ��l�S
                rst.EstimateNote5 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote5];	// ���ϔ��l�T
                rst.EstimateValidityDate = (DateTime)dr[SalesSlipSchema.ct_Col_EstimateValidityDate];	// ���ϗL������
                rst.PartsNoPrtCd = (Int32)dr[SalesSlipSchema.ct_Col_PartsNoPrtCd];	// �i�Ԉ󎚋敪
                rst.OptionPringDivCd = (Int32)dr[SalesSlipSchema.ct_Col_OptionPringDivCd];	// �I�v�V�����󎚋敪
                rst.RateUseCode = (Int32)dr[SalesSlipSchema.ct_Col_RateUseCode];	// �|���g�p�敪
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion
        # endregion
	}
}
