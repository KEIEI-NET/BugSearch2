//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�i�m�k�i���ρj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d����M�i�m�k�i���ρj�A�N�Z�X���s��
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
	/// ����M�i�m�k�i���ρj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����M�i�m�k�i���ρj�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

        # region �t�n�d�����f�[�^���t�n�d����M�i�m�k�����ρ�
        /// <summary>
        /// �t�n�d�����f�[�^���t�n�d����M�i�m�k�����ρ�
        /// </summary>
        /// <param name="mode">0:�V�K 1:�X�V</param>
        /// <param name="uOEOrderDtlWork">�t�n�d�����f�[�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns></returns>
        public int estmtJnlFromDtlWrite(List<UOEOrderDtlWork> uOEOrderDtlWork, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                EstmtSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);

                List<EstmtSndRcvJnl> JnlList = GetToEstmtFromOrderDtl(uOEOrderDtlWork);

                foreach (EstmtSndRcvJnl rst in JnlList)
                {
                    //����M�i�m�k�̕ۑ�
                    DataRow dr = EstmtTable.NewRow();
                    CreateEstmSchemaFromJnl(ref dr, rst);
                    EstmtTable.Rows.Add(dr);
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

		# region ����M�i�m�k�i���ρj�f�[�^�e�[�u��Row�쐬
		/// <summary>
		/// ����M�i�m�k�i���ρj�f�[�^�e�[�u��Row�쐬
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private void CreateEstmSchemaFromJnl(ref DataRow dr, EstmtSndRcvJnl rst)
		{
            dr[EstmtSndRcvJnlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime; // �쐬����
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime; // �X�V����
            dr[EstmtSndRcvJnlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode; // ��ƃR�[�h
            //dr[EstmtSndRcvJnlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid; // GUID
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            dr[EstmtSndRcvJnlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode; // �_���폜�敪
            dr[EstmtSndRcvJnlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd; // �V�X�e���敪
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo; // UOE�����ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo; // UOE�����s�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo; // ���M�[���ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd; // UOE������R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName; // UOE�����於��
            dr[EstmtSndRcvJnlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId; // �ʐM�A�Z���u��ID
            dr[EstmtSndRcvJnlSchema.ct_Col_OnlineNo] = rst.OnlineNo; // �I�����C���ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo; // �I�����C���s�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesDate] = rst.SalesDate; // ������t
            dr[EstmtSndRcvJnlSchema.ct_Col_InputDay] = rst.InputDay; // ���͓�
            dr[EstmtSndRcvJnlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime; // �f�[�^�X�V����
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEKind] = rst.UOEKind; // UOE���
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum; // ����`�[�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum; // ���㖾�גʔ�
            dr[EstmtSndRcvJnlSchema.ct_Col_SectionCode] = rst.SectionCode; // ���_�R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode; // ����R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_CustomerCode] = rst.CustomerCode; // ���Ӑ�R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm; // ���Ӑ旪��
            dr[EstmtSndRcvJnlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo; // ���W�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo; // ���ʒʔ�
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal; // �d���`��
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo; // �d���`�[�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum; // �d�����גʔ�
            dr[EstmtSndRcvJnlSchema.ct_Col_BoCode] = rst.BoCode; // BO�敪
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv; // �[�i�敪
            dr[EstmtSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm; // �[�i�敪����
            dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv; // �t�H���[�[�i�敪
            dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm; // �t�H���[�[�i�敪����
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection; // UOE�w�苒�_
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm; // UOE�w�苒�_����
            dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode; // �]�ƈ��R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeName] = rst.EmployeeName; // �]�ƈ�����
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_MakerName] = rst.MakerName; // ���[�J�[����
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNo] = rst.GoodsNo; // ���i�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen; // �n�C�t�������i�ԍ�
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsName] = rst.GoodsName; // ���i����
            dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode; // �q�ɃR�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseName] = rst.WarehouseName; // �q�ɖ���
            dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo; // �q�ɒI��
            dr[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt; // �󒍐���
            dr[EstmtSndRcvJnlSchema.ct_Col_ListPrice] = rst.ListPrice; // �艿�i�����j
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost; // �����P��
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierCd] = rst.SupplierCd; // �d����R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm; // �d���旪��
            dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1; // �t�n�d���}�[�N�P
            dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2; // �t�n�d���}�[�N�Q
            dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = rst.EstimateRate; // ���σ��[�g
            dr[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = rst.SelectCode; // �I���R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate; // ��M���t
            dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime; // ��M����
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd; // �񓚃��[�J�[�R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo; // �񓚕i��
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName; // �񓚕i��
            dr[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo; // ��֕i��
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice; // �񓚒艿
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = rst.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            dr[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = rst.HeadQtrsStock; // �{���݌�
            dr[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = rst.BranchStock; // ���_�݌�
            dr[EstmtSndRcvJnlSchema.ct_Col_SectionStock] = rst.SectionStock; // �x�X�݌�
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode1] = rst.UOESectionCode1; // UOE���_�R�[�h�P
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode2] = rst.UOESectionCode2; // UOE���_�R�[�h�Q
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode3] = rst.UOESectionCode3; // UOE���_�R�[�h�R
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock1] = rst.UOESectionStock1; // UOE���_�݌ɐ��P
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock2] = rst.UOESectionStock2; // UOE���_�݌ɐ��Q
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock3] = rst.UOESectionStock3; // UOE���_�݌ɐ��R
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = rst.UOEDelivDateCd; // UOE�[���R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = rst.UOESubstCode; // UOE��փR�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode] = rst.UOEPriceCode; // UOE���i�R�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost; // �񓚌����P��
            dr[EstmtSndRcvJnlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd; // �w�ʃR�[�h
            dr[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage; // �w�b�h�G���[���b�Z�[�W
            dr[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage; // ���C���G���[���b�Z�[�W
            dr[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = rst.DataSendCode; // �f�[�^���M�敪
            dr[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv; // �f�[�^�����敪
        }
		# endregion

		# region ����M�i�m�k�i���ρj��DataRow �� �N���X���쐬
		/// <summary>
		/// ����M�i�m�k�i���ρj��DataRow �� �N���X���쐬
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private EstmtSndRcvJnl CreateEstmtJnlFromSchema(ref DataRow dr)
		{
			EstmtSndRcvJnl rst = new EstmtSndRcvJnl();

            //rst.CreateDateTime = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_CreateDateTime]; // �쐬����
            //rst.UpdateDateTime = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_UpdateDateTime]; // �X�V����
            rst.EnterpriseCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EnterpriseCode]; // ��ƃR�[�h
            //rst.FileHeaderGuid = (Guid)dr[EstmtSndRcvJnlSchema.ct_Col_FileHeaderGuid]; // GUID
            rst.UpdEmployeeCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UpdEmployeeCode]; // �X�V�]�ƈ��R�[�h
            rst.UpdAssemblyId1 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId1]; // �X�V�A�Z���u��ID1
            rst.UpdAssemblyId2 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId2]; // �X�V�A�Z���u��ID2
            rst.LogicalDeleteCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_LogicalDeleteCode]; // �_���폜�敪
            rst.SystemDivCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SystemDivCd]; // �V�X�e���敪
            rst.UOESalesOrderNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]; // UOE�����ԍ�
            rst.UOESalesOrderRowNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]; // UOE�����s�ԍ�
            rst.SendTerminalNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SendTerminalNo]; // ���M�[���ԍ�
            rst.UOESupplierCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd]; // UOE������R�[�h
            rst.UOESupplierName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierName]; // UOE�����於��
            rst.CommAssemblyId = (string)dr[EstmtSndRcvJnlSchema.ct_Col_CommAssemblyId]; // �ʐM�A�Z���u��ID
            rst.OnlineNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_OnlineNo]; // �I�����C���ԍ�
            rst.OnlineRowNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_OnlineRowNo]; // �I�����C���s�ԍ�
            rst.SalesDate = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_SalesDate]; // ������t
            rst.InputDay = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_InputDay]; // ���͓�
            rst.DataUpdateDateTime = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_DataUpdateDateTime]; // �f�[�^�X�V����
            rst.UOEKind = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOEKind]; // UOE���
            rst.SalesSlipNum = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipNum]; // ����`�[�ԍ�
            rst.AcptAnOdrStatus = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_AcptAnOdrStatus]; // �󒍃X�e�[�^�X
            rst.SalesSlipDtlNum = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipDtlNum]; // ���㖾�גʔ�
            rst.SectionCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SectionCode]; // ���_�R�[�h
            rst.SubSectionCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SubSectionCode]; // ����R�[�h
            rst.CustomerCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_CustomerCode]; // ���Ӑ�R�[�h
            rst.CustomerSnm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_CustomerSnm]; // ���Ӑ旪��
            rst.CashRegisterNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_CashRegisterNo]; // ���W�ԍ�
            rst.CommonSeqNo = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_CommonSeqNo]; // ���ʒʔ�
            rst.SupplierFormal = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierFormal]; // �d���`��
            rst.SupplierSlipNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSlipNo]; // �d���`�[�ԍ�
            rst.StockSlipDtlNum = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_StockSlipDtlNum]; // �d�����גʔ�
            rst.BoCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_BoCode]; // BO�敪
            rst.UOEDeliGoodsDiv = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv]; // �[�i�敪
            rst.DeliveredGoodsDivNm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm]; // �[�i�敪����
            rst.FollowDeliGoodsDiv = (string)dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv]; // �t�H���[�[�i�敪
            rst.FollowDeliGoodsDivNm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm]; // �t�H���[�[�i�敪����
            rst.UOEResvdSection = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSection]; // UOE�w�苒�_
            rst.UOEResvdSectionNm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSectionNm]; // UOE�w�苒�_����
            rst.EmployeeCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeCode]; // �]�ƈ��R�[�h
            rst.EmployeeName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeName]; // �]�ƈ�����
            rst.GoodsMakerCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsMakerCd]; // ���i���[�J�[�R�[�h
            rst.MakerName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_MakerName]; // ���[�J�[����
            rst.GoodsNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNo]; // ���i�ԍ�
            rst.GoodsNoNoneHyphen = (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen]; // �n�C�t�������i�ԍ�
            rst.GoodsName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsName]; // ���i����
            rst.WarehouseCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseCode]; // �q�ɃR�[�h
            rst.WarehouseName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseName]; // �q�ɖ���
            rst.WarehouseShelfNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseShelfNo]; // �q�ɒI��
            rst.AcceptAnOrderCnt = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt]; // �󒍐���
            rst.ListPrice = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_ListPrice]; // �艿�i�����j
            rst.SalesUnitCost = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnitCost]; // �����P��
            rst.SupplierCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierCd]; // �d����R�[�h
            rst.SupplierSnm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSnm]; // �d���旪��
            rst.UoeRemark1 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1]; // �t�n�d���}�[�N�P
            rst.UoeRemark2 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark2]; // �t�n�d���}�[�N�Q
            rst.EstimateRate = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate]; // ���σ��[�g
            rst.SelectCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SelectCode]; // �I���R�[�h
            rst.ReceiveDate = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate]; // ��M���t
            rst.ReceiveTime = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime]; // ��M����
            rst.AnswerMakerCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerMakerCd]; // �񓚃��[�J�[�R�[�h
            rst.AnswerPartsNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo]; // �񓚕i��
            rst.AnswerPartsName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName]; // �񓚕i��
            rst.SubstPartsNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo]; // ��֕i��
            rst.AnswerListPrice = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice]; // �񓚒艿
            rst.SalesUnPrcTaxExcFl = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl]; // ����P���i�Ŕ��C�����j
            rst.HeadQtrsStock = (string)dr[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock]; // �{���݌�
            rst.BranchStock = (string)dr[EstmtSndRcvJnlSchema.ct_Col_BranchStock]; // ���_�݌�
            rst.SectionStock = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SectionStock]; // �x�X�݌�
            rst.UOESectionCode1 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode1]; // UOE���_�R�[�h�P
            rst.UOESectionCode2 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode2]; // UOE���_�R�[�h�Q
            rst.UOESectionCode3 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode3]; // UOE���_�R�[�h�R
            rst.UOESectionStock1 = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock1]; // UOE���_�݌ɐ��P
            rst.UOESectionStock2 = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock2]; // UOE���_�݌ɐ��Q
            rst.UOESectionStock3 = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock3]; // UOE���_�݌ɐ��R
            rst.UOEDelivDateCd = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd]; // UOE�[���R�[�h
            rst.UOESubstCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode]; // UOE��փR�[�h
            rst.UOEPriceCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode]; // UOE���i�R�[�h
            rst.AnswerSalesUnitCost = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost]; // �񓚌����P��
            rst.PartsLayerCd = (string)dr[EstmtSndRcvJnlSchema.ct_Col_PartsLayerCd]; // �w�ʃR�[�h
            rst.HeadErrorMassage = (string)dr[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage]; // �w�b�h�G���[���b�Z�[�W
            rst.LineErrorMassage = (string)dr[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage]; // ���C���G���[���b�Z�[�W
            rst.DataSendCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_DataSendCode]; // �f�[�^���M�敪
            rst.DataRecoverDiv = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv]; // �f�[�^�����敪

			return (rst);
		}
		# endregion

		# endregion
	}
}
