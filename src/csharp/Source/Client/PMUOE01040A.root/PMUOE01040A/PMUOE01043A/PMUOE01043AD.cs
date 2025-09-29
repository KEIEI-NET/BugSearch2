//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�i�m�k�i�݌Ɂj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d����M�i�m�k�i�݌Ɂj�A�N�Z�X���s��
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
	/// ����M�i�m�k�i�݌Ɂj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����M�i�m�k�i�݌Ɂj�A�N�Z�X�N���X</br>
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

        # region �t�n�d�����f�[�^���t�n�d����M�i�m�k���݌Ɂ�
        /// <summary>
        /// �t�n�d�����f�[�^���t�n�d����M�i�m�k���݌Ɂ�
        /// </summary>
        /// <param name="mode">0:�V�K 1:�X�V</param>
        /// <param name="uOEOrderDtlWork">�t�n�d�����f�[�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns></returns>
        public int stockJnlFromDtlWrite(List<UOEOrderDtlWork> uOEOrderDtlWork, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                StockSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);

                List<StockSndRcvJnl> JnlList = GetToStockFromOrderDtl(uOEOrderDtlWork);
                foreach (StockSndRcvJnl rst in JnlList)
                {
                    //����M�i�m�k�̕ۑ�
                    DataRow dr = StockTable.NewRow();
                    CreateStockSchemaFromJnl(ref dr, rst);
                    StockTable.Rows.Add(dr);
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

		# region ����M�i�m�k�i�݊m�j�f�[�^�e�[�u��Row�쐬
		/// <summary>
		/// ����M�i�m�k�i�݊m�j�f�[�^�e�[�u��Row�쐬
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private void CreateStockSchemaFromJnl(ref DataRow dr, StockSndRcvJnl rst)
		{
            dr[StockSndRcvJnlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime; // �쐬����
            dr[StockSndRcvJnlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime; // �X�V����
            dr[StockSndRcvJnlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode; // ��ƃR�[�h
            //dr[StockSndRcvJnlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid; // GUID
            dr[StockSndRcvJnlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            dr[StockSndRcvJnlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode; // �_���폜�敪
            dr[StockSndRcvJnlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd; // �V�X�e���敪
            dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo; // UOE�����ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo; // UOE�����s�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo; // ���M�[���ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd; // UOE������R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName; // UOE�����於��
            dr[StockSndRcvJnlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId; // �ʐM�A�Z���u��ID
            dr[StockSndRcvJnlSchema.ct_Col_OnlineNo] = rst.OnlineNo; // �I�����C���ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo; // �I�����C���s�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_SalesDate] = rst.SalesDate; // ������t
            dr[StockSndRcvJnlSchema.ct_Col_InputDay] = rst.InputDay; // ���͓�
            dr[StockSndRcvJnlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime; // �f�[�^�X�V����
            dr[StockSndRcvJnlSchema.ct_Col_UOEKind] = rst.UOEKind; // UOE���
            dr[StockSndRcvJnlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum; // ����`�[�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            dr[StockSndRcvJnlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum; // ���㖾�גʔ�
            dr[StockSndRcvJnlSchema.ct_Col_SectionCode] = rst.SectionCode; // ���_�R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode; // ����R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_CustomerCode] = rst.CustomerCode; // ���Ӑ�R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm; // ���Ӑ旪��
            dr[StockSndRcvJnlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo; // ���W�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo; // ���ʒʔ�
            dr[StockSndRcvJnlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal; // �d���`��
            dr[StockSndRcvJnlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo; // �d���`�[�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum; // �d�����גʔ�
            dr[StockSndRcvJnlSchema.ct_Col_BoCode] = rst.BoCode; // BO�敪
            dr[StockSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv; // �[�i�敪
            dr[StockSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm; // �[�i�敪����
            dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv; // �t�H���[�[�i�敪
            dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm; // �t�H���[�[�i�敪����
            dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection; // UOE�w�苒�_
            dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm; // UOE�w�苒�_����
            dr[StockSndRcvJnlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode; // �]�ƈ��R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_EmployeeName] = rst.EmployeeName; // �]�ƈ�����
            dr[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_MakerName] = rst.MakerName; // ���[�J�[����
            dr[StockSndRcvJnlSchema.ct_Col_GoodsNo] = rst.GoodsNo; // ���i�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen; // �n�C�t�������i�ԍ�
            dr[StockSndRcvJnlSchema.ct_Col_GoodsName] = rst.GoodsName; // ���i����
            dr[StockSndRcvJnlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode; // �q�ɃR�[�h
            dr[StockSndRcvJnlSchema.ct_Col_WarehouseName] = rst.WarehouseName; // �q�ɖ���
            dr[StockSndRcvJnlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo; // �q�ɒI��
            dr[StockSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt; // �󒍐���
            dr[StockSndRcvJnlSchema.ct_Col_ListPrice] = rst.ListPrice; // �艿�i�����j
            dr[StockSndRcvJnlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost; // �����P��
            dr[StockSndRcvJnlSchema.ct_Col_SupplierCd] = rst.SupplierCd; // �d����R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm; // �d���旪��
            dr[StockSndRcvJnlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1; // �t�n�d���}�[�N�P
            dr[StockSndRcvJnlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2; // �t�n�d���}�[�N�Q
            dr[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate; // ��M���t
            dr[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime; // ��M����
            dr[StockSndRcvJnlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd; // �񓚃��[�J�[�R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo; // �񓚕i��
            dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName; // �񓚕i��
            dr[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo; // ��֕i��
            dr[StockSndRcvJnlSchema.ct_Col_CenterSubstPartsNo] = rst.CenterSubstPartsNo; // ��֕i�ԁi�Z���^�[�j
            dr[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice; // �񓚒艿
            dr[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost; // �񓚌����P��
            dr[StockSndRcvJnlSchema.ct_Col_GoodsAPrice] = rst.GoodsAPrice; // ���i�`���i
            dr[StockSndRcvJnlSchema.ct_Col_UOEStopCd] = rst.UOEStopCd; // UOE���~�R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = rst.UOESubstCode; // UOE��փR�[�h
            dr[StockSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = rst.UOEDelivDateCd; // UOE�[���R�[�h
            dr[StockSndRcvJnlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd; // �w�ʃR�[�h
            dr[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice] = rst.ShopStUnitPrice; // �̔��X�d���P��
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode1] = rst.UOESectionCode1; // UOE���_�R�[�h�P
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode2] = rst.UOESectionCode2; // UOE���_�R�[�h�Q
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode3] = rst.UOESectionCode3; // UOE���_�R�[�h�R
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode4] = rst.UOESectionCode4; // UOE���_�R�[�h�S
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode5] = rst.UOESectionCode5; // UOE���_�R�[�h�T
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode6] = rst.UOESectionCode6; // UOE���_�R�[�h�U
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode7] = rst.UOESectionCode7; // UOE���_�R�[�h�V
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode8] = rst.UOESectionCode8; // UOE���_�R�[�h�W
            dr[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock] = rst.HeadQtrsStock; // �{���݌�
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = rst.UOESectionStock1; // UOE���_�݌ɐ��P
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = rst.UOESectionStock2; // UOE���_�݌ɐ��Q
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = rst.UOESectionStock3; // UOE���_�݌ɐ��R
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = rst.UOESectionStock4; // UOE���_�݌ɐ��S
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = rst.UOESectionStock5; // UOE���_�݌ɐ��T
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = rst.UOESectionStock6; // UOE���_�݌ɐ��U
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = rst.UOESectionStock7; // UOE���_�݌ɐ��V
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = rst.UOESectionStock8; // UOE���_�݌ɐ��W
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = rst.UOESectionStock9; // UOE���_�݌ɐ��X
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = rst.UOESectionStock10; // UOE���_�݌ɐ��P�O
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = rst.UOESectionStock11; // UOE���_�݌ɐ��P�P
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = rst.UOESectionStock12; // UOE���_�݌ɐ��P�Q
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = rst.UOESectionStock13; // UOE���_�݌ɐ��P�R
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = rst.UOESectionStock14; // UOE���_�݌ɐ��P�S
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = rst.UOESectionStock15; // UOE���_�݌ɐ��P�T
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = rst.UOESectionStock16; // UOE���_�݌ɐ��P�U
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = rst.UOESectionStock17; // UOE���_�݌ɐ��P�V
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = rst.UOESectionStock18; // UOE���_�݌ɐ��P�W
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = rst.UOESectionStock19; // UOE���_�݌ɐ��P�X
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = rst.UOESectionStock20; // UOE���_�݌ɐ��Q�O
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = rst.UOESectionStock21; // UOE���_�݌ɐ��Q�P
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = rst.UOESectionStock22; // UOE���_�݌ɐ��Q�Q
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = rst.UOESectionStock23; // UOE���_�݌ɐ��Q�R
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = rst.UOESectionStock24; // UOE���_�݌ɐ��Q�S
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = rst.UOESectionStock25; // UOE���_�݌ɐ��Q�T
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = rst.UOESectionStock26; // UOE���_�݌ɐ��Q�U
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = rst.UOESectionStock27; // UOE���_�݌ɐ��Q�V
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = rst.UOESectionStock28; // UOE���_�݌ɐ��Q�W
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = rst.UOESectionStock29; // UOE���_�݌ɐ��Q�X
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = rst.UOESectionStock30; // UOE���_�݌ɐ��R�O
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = rst.UOESectionStock31; // UOE���_�݌ɐ��R�P
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock32] = rst.UOESectionStock32; // UOE���_�݌ɐ��R�Q
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock33] = rst.UOESectionStock33; // UOE���_�݌ɐ��R�R
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock34] = rst.UOESectionStock34; // UOE���_�݌ɐ��R�S
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock35] = rst.UOESectionStock35; // UOE���_�݌ɐ��R�T
            dr[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage; // �w�b�h�G���[���b�Z�[�W
            dr[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage; // ���C���G���[���b�Z�[�W
            dr[StockSndRcvJnlSchema.ct_Col_DataSendCode] = rst.DataSendCode; // �f�[�^���M�敪
            dr[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv; // �f�[�^�����敪
        }
		# endregion

		# region ����M�i�m�k�i�݌Ɂj��DataRow �� �N���X���쐬
		/// <summary>
		/// ����M�i�m�k�i�݌Ɂj��DataRow �� �N���X���쐬
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private StockSndRcvJnl CreateStockJnlFromSchema(ref DataRow dr)
		{
			StockSndRcvJnl rst = new StockSndRcvJnl();

            //rst.CreateDateTime = (Int64)dr[StockSndRcvJnlSchema.ct_Col_CreateDateTime]; // �쐬����
            //rst.UpdateDateTime = (Int64)dr[StockSndRcvJnlSchema.ct_Col_UpdateDateTime]; // �X�V����
            rst.EnterpriseCode = (string)dr[StockSndRcvJnlSchema.ct_Col_EnterpriseCode]; // ��ƃR�[�h
            //rst.FileHeaderGuid = (Guid)dr[StockSndRcvJnlSchema.ct_Col_FileHeaderGuid]; // GUID
            rst.UpdEmployeeCode = (string)dr[StockSndRcvJnlSchema.ct_Col_UpdEmployeeCode]; // �X�V�]�ƈ��R�[�h
            rst.UpdAssemblyId1 = (string)dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId1]; // �X�V�A�Z���u��ID1
            rst.UpdAssemblyId2 = (string)dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId2]; // �X�V�A�Z���u��ID2
            rst.LogicalDeleteCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_LogicalDeleteCode]; // �_���폜�敪
            rst.SystemDivCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SystemDivCd]; // �V�X�e���敪
            rst.UOESalesOrderNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]; // UOE�����ԍ�
            rst.UOESalesOrderRowNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]; // UOE�����s�ԍ�
            rst.SendTerminalNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SendTerminalNo]; // ���M�[���ԍ�
            rst.UOESupplierCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESupplierCd]; // UOE������R�[�h
            rst.UOESupplierName = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESupplierName]; // UOE�����於��
            rst.CommAssemblyId = (string)dr[StockSndRcvJnlSchema.ct_Col_CommAssemblyId]; // �ʐM�A�Z���u��ID
            rst.OnlineNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_OnlineNo]; // �I�����C���ԍ�
            rst.OnlineRowNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_OnlineRowNo]; // �I�����C���s�ԍ�
            rst.SalesDate = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_SalesDate]; // ������t
            rst.InputDay = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_InputDay]; // ���͓�
            rst.DataUpdateDateTime = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_DataUpdateDateTime]; // �f�[�^�X�V����
            rst.UOEKind = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOEKind]; // UOE���
            rst.SalesSlipNum = (string)dr[StockSndRcvJnlSchema.ct_Col_SalesSlipNum]; // ����`�[�ԍ�
            rst.AcptAnOdrStatus = (Int32)dr[StockSndRcvJnlSchema.ct_Col_AcptAnOdrStatus]; // �󒍃X�e�[�^�X
            rst.SalesSlipDtlNum = (Int64)dr[StockSndRcvJnlSchema.ct_Col_SalesSlipDtlNum]; // ���㖾�גʔ�
            rst.SectionCode = (string)dr[StockSndRcvJnlSchema.ct_Col_SectionCode]; // ���_�R�[�h
            rst.SubSectionCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SubSectionCode]; // ����R�[�h
            rst.CustomerCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_CustomerCode]; // ���Ӑ�R�[�h
            rst.CustomerSnm = (string)dr[StockSndRcvJnlSchema.ct_Col_CustomerSnm]; // ���Ӑ旪��
            rst.CashRegisterNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_CashRegisterNo]; // ���W�ԍ�
            rst.CommonSeqNo = (Int64)dr[StockSndRcvJnlSchema.ct_Col_CommonSeqNo]; // ���ʒʔ�
            rst.SupplierFormal = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SupplierFormal]; // �d���`��
            rst.SupplierSlipNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SupplierSlipNo]; // �d���`�[�ԍ�
            rst.StockSlipDtlNum = (Int64)dr[StockSndRcvJnlSchema.ct_Col_StockSlipDtlNum]; // �d�����גʔ�
            rst.BoCode = (string)dr[StockSndRcvJnlSchema.ct_Col_BoCode]; // BO�敪
            rst.UOEDeliGoodsDiv = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv]; // �[�i�敪
            rst.DeliveredGoodsDivNm = (string)dr[StockSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm]; // �[�i�敪����
            rst.FollowDeliGoodsDiv = (string)dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv]; // �t�H���[�[�i�敪
            rst.FollowDeliGoodsDivNm = (string)dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm]; // �t�H���[�[�i�敪����
            rst.UOEResvdSection = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSection]; // UOE�w�苒�_
            rst.UOEResvdSectionNm = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSectionNm]; // UOE�w�苒�_����
            rst.EmployeeCode = (string)dr[StockSndRcvJnlSchema.ct_Col_EmployeeCode]; // �]�ƈ��R�[�h
            rst.EmployeeName = (string)dr[StockSndRcvJnlSchema.ct_Col_EmployeeName]; // �]�ƈ�����
            rst.GoodsMakerCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd]; // ���i���[�J�[�R�[�h
            rst.MakerName = (string)dr[StockSndRcvJnlSchema.ct_Col_MakerName]; // ���[�J�[����
            rst.GoodsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNo]; // ���i�ԍ�
            rst.GoodsNoNoneHyphen = (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen]; // �n�C�t�������i�ԍ�
            rst.GoodsName = (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsName]; // ���i����
            rst.WarehouseCode = (string)dr[StockSndRcvJnlSchema.ct_Col_WarehouseCode]; // �q�ɃR�[�h
            rst.WarehouseName = (string)dr[StockSndRcvJnlSchema.ct_Col_WarehouseName]; // �q�ɖ���
            rst.WarehouseShelfNo = (string)dr[StockSndRcvJnlSchema.ct_Col_WarehouseShelfNo]; // �q�ɒI��
            rst.AcceptAnOrderCnt = (Double)dr[StockSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt]; // �󒍐���
            rst.ListPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_ListPrice]; // �艿�i�����j
            rst.SalesUnitCost = (Double)dr[StockSndRcvJnlSchema.ct_Col_SalesUnitCost]; // �����P��
            rst.SupplierCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SupplierCd]; // �d����R�[�h
            rst.SupplierSnm = (string)dr[StockSndRcvJnlSchema.ct_Col_SupplierSnm]; // �d���旪��
            rst.UoeRemark1 = (string)dr[StockSndRcvJnlSchema.ct_Col_UoeRemark1]; // �t�n�d���}�[�N�P
            rst.UoeRemark2 = (string)dr[StockSndRcvJnlSchema.ct_Col_UoeRemark2]; // �t�n�d���}�[�N�Q
            rst.ReceiveDate = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_ReceiveDate]; // ��M���t
            rst.ReceiveTime = (Int32)dr[StockSndRcvJnlSchema.ct_Col_ReceiveTime]; // ��M����
            rst.AnswerMakerCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_AnswerMakerCd]; // �񓚃��[�J�[�R�[�h
            rst.AnswerPartsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo]; // �񓚕i��
            rst.AnswerPartsName = (string)dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsName]; // �񓚕i��
            rst.SubstPartsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_SubstPartsNo]; // ��֕i��
            rst.CenterSubstPartsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_CenterSubstPartsNo]; // ��֕i�ԁi�Z���^�[�j
            rst.AnswerListPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_AnswerListPrice]; // �񓚒艿
            rst.AnswerSalesUnitCost = (Double)dr[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost]; // �񓚌����P��
            rst.GoodsAPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_GoodsAPrice]; // ���i�`���i
            rst.UOEStopCd = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEStopCd]; // UOE���~�R�[�h
            rst.UOESubstCode = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESubstCode]; // UOE��փR�[�h
            rst.UOEDelivDateCd = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEDelivDateCd]; // UOE�[���R�[�h
            rst.PartsLayerCd = (string)dr[StockSndRcvJnlSchema.ct_Col_PartsLayerCd]; // �w�ʃR�[�h
            rst.ShopStUnitPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice]; // �̔��X�d���P��
            rst.UOESectionCode1 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode1]; // UOE���_�R�[�h�P
            rst.UOESectionCode2 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode2]; // UOE���_�R�[�h�Q
            rst.UOESectionCode3 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode3]; // UOE���_�R�[�h�R
            rst.UOESectionCode4 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode4]; // UOE���_�R�[�h�S
            rst.UOESectionCode5 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode5]; // UOE���_�R�[�h�T
            rst.UOESectionCode6 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode6]; // UOE���_�R�[�h�U
            rst.UOESectionCode7 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode7]; // UOE���_�R�[�h�V
            rst.UOESectionCode8 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode8]; // UOE���_�R�[�h�W
            rst.HeadQtrsStock = (string)dr[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock]; // �{���݌�
            rst.UOESectionStock1 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock1]; // UOE���_�݌ɐ��P
            rst.UOESectionStock2 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock2]; // UOE���_�݌ɐ��Q
            rst.UOESectionStock3 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock3]; // UOE���_�݌ɐ��R
            rst.UOESectionStock4 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock4]; // UOE���_�݌ɐ��S
            rst.UOESectionStock5 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock5]; // UOE���_�݌ɐ��T
            rst.UOESectionStock6 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock6]; // UOE���_�݌ɐ��U
            rst.UOESectionStock7 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock7]; // UOE���_�݌ɐ��V
            rst.UOESectionStock8 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock8]; // UOE���_�݌ɐ��W
            rst.UOESectionStock9 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock9]; // UOE���_�݌ɐ��X
            rst.UOESectionStock10 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock10]; // UOE���_�݌ɐ��P�O
            rst.UOESectionStock11 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock11]; // UOE���_�݌ɐ��P�P
            rst.UOESectionStock12 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock12]; // UOE���_�݌ɐ��P�Q
            rst.UOESectionStock13 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock13]; // UOE���_�݌ɐ��P�R
            rst.UOESectionStock14 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock14]; // UOE���_�݌ɐ��P�S
            rst.UOESectionStock15 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock15]; // UOE���_�݌ɐ��P�T
            rst.UOESectionStock16 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock16]; // UOE���_�݌ɐ��P�U
            rst.UOESectionStock17 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock17]; // UOE���_�݌ɐ��P�V
            rst.UOESectionStock18 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock18]; // UOE���_�݌ɐ��P�W
            rst.UOESectionStock19 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock19]; // UOE���_�݌ɐ��P�X
            rst.UOESectionStock20 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock20]; // UOE���_�݌ɐ��Q�O
            rst.UOESectionStock21 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock21]; // UOE���_�݌ɐ��Q�P
            rst.UOESectionStock22 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock22]; // UOE���_�݌ɐ��Q�Q
            rst.UOESectionStock23 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock23]; // UOE���_�݌ɐ��Q�R
            rst.UOESectionStock24 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock24]; // UOE���_�݌ɐ��Q�S
            rst.UOESectionStock25 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock25]; // UOE���_�݌ɐ��Q�T
            rst.UOESectionStock26 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock26]; // UOE���_�݌ɐ��Q�U
            rst.UOESectionStock27 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock27]; // UOE���_�݌ɐ��Q�V
            rst.UOESectionStock28 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock28]; // UOE���_�݌ɐ��Q�W
            rst.UOESectionStock29 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock29]; // UOE���_�݌ɐ��Q�X
            rst.UOESectionStock30 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock30]; // UOE���_�݌ɐ��R�O
            rst.UOESectionStock31 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock31]; // UOE���_�݌ɐ��R�P
            rst.UOESectionStock32 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock32]; // UOE���_�݌ɐ��R�Q
            rst.UOESectionStock33 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock33]; // UOE���_�݌ɐ��R�R
            rst.UOESectionStock34 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock34]; // UOE���_�݌ɐ��R�S
            rst.UOESectionStock35 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock35]; // UOE���_�݌ɐ��R�T
            rst.HeadErrorMassage = (string)dr[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage]; // �w�b�h�G���[���b�Z�[�W
            rst.LineErrorMassage = (string)dr[StockSndRcvJnlSchema.ct_Col_LineErrorMassage]; // ���C���G���[���b�Z�[�W
            rst.DataSendCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_DataSendCode]; // �f�[�^���M�敪
            rst.DataRecoverDiv = (Int32)dr[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv]; // �f�[�^�����敪

			return (rst);
		}
		# endregion

		# endregion
	}
}
